/* this class file will hold all the stuff for interacting with rest api of accela
*/
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Reflection;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Net.Http;
using System.Text.Json; 
using System.Diagnostics;
using RestSharp;
using RestSharp.Authenticators;
using System.ComponentModel;

namespace MTDataConversion
{
    public class FEECODE
    {
        public string R1_FEE_CODE { get; set; }
        public string R1_GF_COD { get; set; }
    }

    public class RestResult
    {
        public string id { get; set; }
        public string customId {get; set;}
        public string message { get; set; }
        public bool isSuccess { get; set; }
    }

    public class RestResultContentFee
    {
        // public string message { get; set; }
        public List<RestResult> result { get; set; }
        public int status { get; set; }
    }

    public class RestResultContent
    {
        public string message { get; set; }
        public RestResult result { get; set; }
        public int status { get; set; }
    }

    public class AccelaRestAuthenticated
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }       
    }

    public class AccelaRelatedRecords
    {
        public string MasterRecId {get; set;}
        public string LocationNumber {get; set;}
        public string childRecId {get; set;}
    }

    public class AccelaRestServiceCls
    {
        ConfigFile restCfg = new ConfigFile();
        LogFile restLog = new LogFile();
        MemoryCache memoryCache = MemoryCache.Default;
        CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
        public MTData restMtData ;
        public List<FEECODE> feecodeList = new List<FEECODE>();
        public List<int?> ProcdRecs = new List<int?>();
        public List<int?> ProcdLocs = new List<int?>();
        public List<string> FeesAdded = new List<string>();
        public List<AccelaRelatedRecords> relatedrecs = new List<AccelaRelatedRecords>();

        public AccelaRestAuthenticated authobj = new AccelaRestAuthenticated();
        public RestClient rsclient ;

#region  privateMethods

        Accelaschedule GetAccelaFeeSchedule(string aptype)
        {
            Accelaschedule acelasched = new Accelaschedule();

            // switch(aptype)
            // {

            // }

            return acelasched;
        }

        string BuildRecordFeeJsonstring(string accelaRecordID,MTData mtdata,Records rec,string licnum)
        {
            string json = string.Empty;
            List<License> lics = new List<License>();
            List<AccelaFee> afee = new List<AccelaFee>();
            
            List<int?> usedLocnums = new List<int?>();

            lics = mtdata.LicenseList.FindAll(x=> x.LicenseNumber.ToString() == licnum);

            // int k = 0;
            foreach(License l in lics)
            {
                List<int?> foundusedLocs = usedLocnums.FindAll(x=>x==l.LocationNumber);
                Boolean locused = foundusedLocs.Count>0;
                List<LocationTransaction> loctran = new List<LocationTransaction>();
                loctran =mtdata.LocationTransactionList.FindAll(x=> x.LocationNumber.ToString() == l.LocationNumber.ToString() && !locused);

                usedLocnums.Add(l.LocationNumber);

                int k1 = 0;
                foreach(LocationTransaction lt in loctran)
                {
                    List<LocationTransactionDetail> loctrandets = new List<LocationTransactionDetail>();
                    loctrandets = mtdata.LocationTransactionDetailList.FindAll(x=> x.TransactionId.ToString() == lt.TransactionId.ToString());


                    foreach(LocationTransactionDetail ltd in loctrandets)
                    {
                        
                        string feecode = ltd.GetAccelaFeeType(mtdata,ltd.FeeId,restLog);
                        if (ltd.FeeId>0 && !feecode.Contains("No Fee Configured") && !feecode.Contains("Does not map exactly") && !String.IsNullOrEmpty(feecode))
                        {
                            k1++;
                            AccelaFee f = new AccelaFee();
                            f.feeNotes = "Converted from Legacy License "+licnum;
                            f.code.text = feecode;
                            f.code.value = feecode;
                            f.paymentPeriod.text = "FINAL";
                            f.paymentPeriod.value = "FINAL";
                            f.quantity = "1";
                            string[] ap = rec.type.value.Split("/");
                            
                            f.schedule.text =ap[0];
                            f.schedule.value =ap[0];
                            f.version.text = "V1";
                            f.version.value = "V1";
                            
                            if (IsFeeScheduleLinkedToApType(rec,ap[0],feecode))
                            {
                                afee.Add(f);
                            }
                            else 
                            {
                                string lg = string.Format("License [{0}] FeeCode [{1}] Are not linked in Accela Configuration ",licnum,feecode);
                                WriteOutError(lg,ErrorLog.IfaceResult.CONVERTCONFIGISSUE);
                            }

                        }
                    }
                }
            }

            json =  @JsonConvert.SerializeObject(afee);

            return json.Replace("result/type/","") ;
        }

        string BuildRecordPeopleJsonstring(string accelaRecordID,List<Person> perlist ,List<License> liclist,List<PeopleLocations> peeploclist,List<Location> loclist,Records rec,string licnum)
        {
            string json = string.Empty;
            List<License> lics = new List<License>();
            List<Contact> contlist = new List<Contact>();
            List<string> procdPeople = new List<string>();

            if (rec.type.value!="eStop/Master Location/Record/NA")
            {
                lics = liclist.FindAll(x=> x.LicenseNumber.ToString() == licnum);
            }
            else 
            {
                lics = liclist.FindAll(x=> x.LocationNumber.ToString() == licnum);

            }

            foreach(License l in lics)
            {
                List<Location> thelocs = loclist.FindAll(x=> x.LocationId.ToString() == l.LocationNumber.ToString());
                foreach(Location lc in thelocs)
                {
                    List<PeopleLocations> pl = new List<PeopleLocations>();
                    pl = peeploclist.FindAll(x=> x.LocationNumber.ToString() == l.LocationNumber.ToString());
                    // pl = peeploclist.FindAll(x=> x.LocationNumber.ToString() == "21440");
                    foreach(PeopleLocations p in pl)
                    {
                        List<Person> per = new List<Person>();
                        per = perlist.FindAll(x=> x.PersonId.ToString() == p.PersonId.ToString());  
                        // per = perlist.FindAll(x=> x.PersonId.ToString() == "12341");  
                        foreach(Person ps in per)
                        {
                            List<string> foundList = new List<string>();
                            foundList = procdPeople.FindAll(x=> x==ps.PersonId.ToString());

                            if (foundList.Count()<=0)
                            {
                                Contact cnt = new Contact();
                                cnt.firstName = ps.FirstName;
                                cnt.lastName = ps.LastName;
                                cnt.phone1 = ps.PhoneNumber;
                                cnt.phone2 = ps.PhoneNumber2;
                                cnt.fax = ps.FaxNumber;
                                cnt.email = ps.EmailAddress;
                                cnt.type = new AccelaType();
                                cnt.type.text = "Legacy eStop Contact";
                                cnt.type.value = "Legacy eStop Contact";

                                contlist.Add(cnt);
                                procdPeople.Add(ps.PersonId.ToString());
                            }
                        }

                    }

                }
            }

            json =  @JsonConvert.SerializeObject(contlist);

            return json.Replace("result/type/","") ;
        }
        
        string BuildRecordAddressJsonstring(string accelaRecordID,List<Location> loclist,List<County> countlist,List<License> liclist,Records rec,string licnum,Records ar,string curloc)
        {
            string json = string.Empty;
            Address ad = new Address();
            Location loc = new Location();

            loc = rec.GetLocationNumberFromLicense(licnum,loclist,liclist,ar,curloc);
            ad.addressLine1 = loc.Address1;
            ad.addressLine2 = loc.Address2;
            if (!string.IsNullOrEmpty(loc.Address1))
            {
                string[] addy1 = loc.Address1.Split(' ');
                try
                {
                    // ad.streetStart = Convert.ToInt32(addy1[0]);
                    int streetstart = 0;
                    Boolean valid = Int32.TryParse(addy1[0],out streetstart);
                    if (valid)
                    {
                        ad.streetStart = streetstart;
                        for (int x =1; x<addy1.Length;x++)
                        {
                            ad.streetName +=addy1[x]+" ";
                        }
                    }
                    else 
                    {
                        ad.streetName = loc.Address1;
                    }

                }
                catch(Exception ex)
                {
                    string lg = "Critical Error Building Record Address String "+ex.Message;
                    lg += "REC ID ["+accelaRecordID+"]  Lic Num ["+licnum+"]";
                    WriteOutError(lg,ErrorLog.IfaceResult.FAIL);                    
                    Console.WriteLine(lg);
                }
                
                ad.city = loc.City;
                ad.county = rec.GetCountyFromLicense(licnum,loclist,liclist,countlist,ar);
                json =  @JsonConvert.SerializeObject(ad);
            }

            return json ;
        }

        string BuildInspectionJsonstring(string accelaRecordID,string inspdate)
        {
            string json = string.Empty;
            InspRoot ir = new InspRoot();
            ir.recordId = new RecordId();
            ir.type = new inspType();

            ir.type.value = "WM";
            ir.type.text = "WM";
            ir.type.id = 3350;
            ir.type.group = "WM";

            ir.recordId.id = accelaRecordID;
            ir.completedDate = inspdate;
            
            json =  @JsonConvert.SerializeObject(ir);

            return json ;
        }

        string BuildNurseryInspectionJsonstring(string accelaRecordID, NurseryInspection ni)
        {
            string json = string.Empty;
            InspRoot ir = new InspRoot();
            ir.recordId = new RecordId();
            ir.type = new inspType();
            ir.completedDate = ni.InspectionDate;

            switch(ni.Activity)
            {
                case "INSPECTION":
                    ir.type.value = "Inspection";
                    ir.type.text = "Inspection";
                    ir.type.id = 3369;
                    ir.type.group = "NUR";
                    break;
                case "INVESTIGATION":
                    ir.type.value = "Investigation";
                    ir.type.text = "Investigation";
                    ir.type.id = 3370;
                    ir.type.group = "NUR";
                    break;
                case "INQUIRY":
                    ir.type.value = "Inquiry";
                    ir.type.text = "Inquiry";
                    ir.type.id = 3371;
                    ir.type.group = "NUR";
                    break;
            }


            ir.recordId.id = accelaRecordID;
            
            json =  @JsonConvert.SerializeObject(ir);

            return json ;

        }

        string BuildCustomFormJsonString(List<CustomForm> cfl)
        {
            string json = "[";

            foreach(CustomForm cf in cfl)
            {
                json+=cf.FormJsonString()+",";
            }

            json = json.Remove(json.Length - 1);
            return json+"]";
        }

        string BuildCustomContactFormJsonString(string  cfl,string licnum)
        {
            string json = string.Empty;
            List<License> lics = new List<License>();
            CustomForm cf = new CustomForm();
            try
            {
                lics = restMtData.LicenseList.FindAll(x=> x.LicenseNumber.ToString() == licnum);

                foreach(License l in lics)
                {
                    List<Location> thelocs = restMtData.LocationList.FindAll(x=> x.LocationId.ToString() == l.LocationNumber.ToString());
                    foreach(Location lc in thelocs)
                    {
                        List<PeopleLocations> pl = new List<PeopleLocations>();
                        pl = restMtData.PeopleLocationList.FindAll(x=> x.LocationNumber.ToString() == l.LocationNumber.ToString());
                        // pl = peeploclist.FindAll(x=> x.LocationNumber.ToString() == "21440");
                        foreach(PeopleLocations p in pl)
                        {
                            Parms pa = new Parms();
                            pa = restMtData.ParmsList.Find(x=>x.ParmId==p.PersonRoleId);
                            cf.aCustomFieldName = "Role";
                            cf.aCustomFieldValue = pa.ParmDescription;
                            cf.id = "ESTP_CON_APP-ESTOP.cAPPLICANT";
                        }
                    }
                }

                if (!string.IsNullOrEmpty(cf.id))
                {
                    json = cf.FormJsonString();
                }
                else 
                {
                    json = string.Empty;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Criticet Error BuildCustomContactFormJsonString "+ex.Message);
            }
//            json =  @JsonConvert.SerializeObject(contlist);

            return "["+json.Replace("result/type/","")+"]" ;
        }


        void WriteOutError(string errmsg,ErrorLog.IfaceResult ir)
        {
            ErrorLog elg = new ErrorLog();
            elg.ifResult = ir;
            elg.Message = errmsg;
            
            restLog.WriteLogLineItemFile(elg);
            // Console.WriteLine(elg.Message);

        }

        Boolean recprocessed(int? recnum,string aptype,Location temploc )
        {
            Boolean processed = false;

            if (aptype!="eStop/Master Location/Record/NA")
            {
                lock(ProcdRecs)
                {
                        List<int?> lst = new List<int?>();
                        lst = ProcdRecs.FindAll(x=>x ==recnum);
                        processed = lst.Count>0;
                }
            }
            else 
            {
                lock(ProcdLocs)
                {
                    List<int?> lst = new List<int?>();
                    lst = ProcdLocs.FindAll(x=>x ==temploc.LocationNumber);
                    processed = lst.Count>0;
                }
            }


            return processed;
        }

        void recprocessedAddToList(int? recnum,string aptype,Location temploc)
        {
            if (aptype!="eStop/Master Location/Record/NA")
            {
                lock(ProcdRecs)
                {
                    ProcdRecs.Add(recnum);
                }
            }
            else 
            {
                lock(ProcdLocs)
                {
                    ProcdLocs.Add(temploc.LocationNumber);
                }

            }

        }


        void AddFeesAdded(string apnum)
        {
            lock(FeesAdded)
            {
                FeesAdded.Add(apnum);
            }
        }

        void RemoveLicense(string licnum,MTData mtdat)
        {
            mtdat.LicenseList.RemoveAll(x=>x.LicenseNumber.ToString()==licnum);
        }

        void BuildRelatedList(Records ar,string locationnumber,string recid)
        {
            AccelaRelatedRecords r = new AccelaRelatedRecords();

            try
            {
                if (ar.type.value=="eStop/Master Location/Record/NA")
                {
                    r.MasterRecId = recid;
                    r.LocationNumber = locationnumber;
                    r.childRecId = string.Empty;
                }
                else 
                {
                    r.MasterRecId = string.Empty;
                    r.LocationNumber = locationnumber;
                    r.childRecId = recid;

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Critical Error building related list "+ex.Message);
            }

            relatedrecs.Add(r);
        }

#endregion


#region publicMethods
        public string ReturnAccessToken()
        {
            string authtoken = string.Empty;
            try
            {
                if (memoryCache.Contains("AuthObj"))
                {
                    AccelaRestAuthenticated cachedauth  = (AccelaRestAuthenticated) memoryCache.Get("AuthObj");
                    authtoken=  cachedauth.access_token;
                }
                else 
                {
                    LoginToAccelaRest();
                    //Thread.Sleep(10000);
                    cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddMinutes(Convert.ToInt32(restCfg.CacheTimeout));
                    // cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(Convert.ToInt32(restCfg.CacheTimeout));
                    // cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddSeconds(Convert.ToInt32(restCfg.CacheTimeout));
                    memoryCache.Add("AuthObj",authobj,cacheItemPolicy);
                    authtoken=  authobj.access_token;
                }
            }
            catch(Exception ex)
            {
                string lg = "Critical Error Returning Access Token For Accela ["+ex.Message+"]";
                WriteOutError(lg,ErrorLog.IfaceResult.FAIL);

            }

            return authtoken;

         }

        public Boolean LoginToAccelaRest()
        {
            Boolean success = true;

            try
            {
                var options = new RestClientOptions(restCfg.AccelaRestServiceAuthURL);
                options.Timeout = TimeSpan.FromMinutes(5);

                rsclient = new RestClient(options);
                var request = new RestRequest(restCfg.Accela_AuthEndPoint, Method.Post);
                request.Timeout = TimeSpan.FromMinutes(5);

                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddParameter("client_id", restCfg.Accela_clientID);
                request.AddParameter("client_secret", restCfg.Accela_clientSecret);
                request.AddParameter("grant_type", restCfg.Accela_granttype);
                request.AddParameter("username", restCfg.Accela_UserName);
                request.AddParameter("password", restCfg.Accela_Password);
                request.AddParameter("scope", restCfg.Accela_scope);
                request.AddParameter("agency_name", restCfg.Accela_agencyname);
                request.AddParameter("environment", restCfg.Accela_agencyEnviroment);


                var resp = rsclient.ExecutePost(request);
                if (resp.IsSuccessful && resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    try
                    {
                        authobj = JsonConvert.DeserializeObject<AccelaRestAuthenticated>(resp.Content);

                    }
                    catch(Exception ex)
                    {
                        string lg = "Critical Error LoginToAccelaRest Deserialize Auth Object ["+ex.Message+"]";
                        WriteOutError(lg,ErrorLog.IfaceResult.FAIL);
                    }
                }
                else 
                {
                    string elg = "Error Logging Into Accela Rest Services Error ["+resp.Content+"]";
                    WriteOutError(elg,ErrorLog.IfaceResult.FAIL);
                }


            }
            catch(Exception ex)
            {
                string lg = "Critical Error Logging Into Accela Rest Services Error ["+ex.Message+"]";
                WriteOutError(lg,ErrorLog.IfaceResult.FAIL);

            }
            finally
            {

            }

            return success;
        }

        public Boolean IsFeeScheduleLinkedToApType(Records ar,string feesched, string feetype)
        {
            Boolean success = false;

            try
            {
                List<FEECODE> fc = new List<FEECODE>();
                fc = feecodeList.FindAll(x=>x.R1_GF_COD==feetype && x.R1_FEE_CODE==feesched);
                success = fc.Count>0;
            }
            catch(Exception ex)
            {
                string lg = "Critical Error IsFeeScheduleLinkedToApType Rest Services Error ["+ex.Message+"] ";
                WriteOutError(lg,ErrorLog.IfaceResult.FAIL);
            }
            finally
            {

            }

            return success;
        }


        public Boolean GetAllRecordFromAccela(ref AccelaRecordsRoot ar)
        {
            Boolean success = true;

            try
            {
                var options = new RestClientOptions(restCfg.AccelaRestServiceAPIBaseURL);
                options.Timeout = TimeSpan.FromMinutes(5);

                rsclient = new RestClient(options);
                var request = new RestRequest(restCfg.AccelaRestServiceAPIBaseURL+"/"+restCfg.AccelaRestServiceGetRecordsEndPoint, Method.Get);
                request.Timeout = TimeSpan.FromMinutes(5);

                
                request.AddHeader("Authorization", ReturnAccessToken() );
                
                var resp = rsclient.ExecuteGet(request);
                if (resp.IsSuccessful && resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    try
                    {
                        AccelaRecordsRoot arl = new AccelaRecordsRoot();
                        arl = JsonConvert.DeserializeObject<AccelaRecordsRoot>(resp.Content);
                    }
                    catch(Exception ex)
                    {
                        string lg = "Critical Error GetAllRecordFromAccela Deserialize Record Object ["+ex.Message+"] ";
                        WriteOutError(lg,ErrorLog.IfaceResult.FAIL);
                    }

                }
                else 
                {
                    string elg = "Error GetAllRecordFromAccela Rest Services Error ["+resp.Content+"] ";
                    WriteOutError(elg,ErrorLog.IfaceResult.FAIL);
                }


 
            }
            catch(Exception ex)
            {
                string lg = "Critical Error GetAllRecordFromAccela Rest Services Error ["+ex.Message+"] ";
                WriteOutError(lg,ErrorLog.IfaceResult.FAIL);

            }
            finally
            {

            }

            return success;
        }

        public Boolean UpdateTaskFromRecord(Records ar,string accelaRecordID, WorkFlowTask wft,string wftstatus)
        {
            Boolean success = true;

            try
            {
                string taskid = string.Empty;
                
                foreach(WorkFlowTaskResult t in wft.result)
                {
                    taskid = t.id;
                }

                
                var options = new RestClientOptions(restCfg.AccelaRestServiceAPIBaseURL);
                options.Timeout = TimeSpan.FromMinutes(5);

                rsclient = new RestClient(options);
                string endpoint = restCfg.AccelaRestServiceSUpdateTask.Replace("recordId",accelaRecordID).Replace("id",taskid);

                wftStatus stat = new wftStatus();
                
                var request = new RestRequest(restCfg.AccelaRestServiceAPIBaseURL+"/"+endpoint, Method.Put);
                request.Timeout = TimeSpan.FromMinutes(5);

                switch(wftstatus.ToUpper())
                {
                    case "ACTIVE":
                    case "CANCELLED":
                        stat.status.text = wftstatus;
                        stat.status.value =wftstatus;         
                        break;
                    case "CONDITIONAL APPROVAL":
                    case "HOLD LICENSE":
                    case "TEMPORARY AUTHORITY":
                    case "NON USE":
                    case "TRANSFER":
                        stat.status.text = "Active";
                        stat.status.value ="Active";         
                        break;
                    case "DISAPPROVED":
                    case "WITHDRAWN":
                        stat.status.text = "Closed";
                        stat.status.value ="Closed";         
                        break;
                    case "PENDING":
                    case "PENDING APPROVAL":
                    case "PENDING COMPLIANCE":
                    case "PENDING VALIDATION":
                        stat.status.text = "Pending";
                        stat.status.value ="Pending";         
                        break;

            }
                

                var ar_string =  @JsonConvert.SerializeObject(stat);

                request.AddStringBody(ar_string.Replace("result/status/",""), DataFormat.Json);

                request.AddHeader("Authorization", ReturnAccessToken() );
                
                var resp = rsclient.ExecutePut(request);
                if (resp.IsSuccessful && resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    try
                    {
                        //WorkFlowTask arl = new WorkFlowTask();
                        // wft = JsonConvert.DeserializeObject<WorkFlowTask>(resp.Content);
                        int k = 0;
                    }
                    catch(Exception ex)
                    {
                        string lg = " Error UpdateTaskFromRecord Deserialize Record Object ["+ex.Message+"] ";
                        WriteOutError(lg,ErrorLog.IfaceResult.FAIL);
                    }

                }
                else 
                {
                    string elg = "Error UpdateTaskFromRecord Rest Services Error ["+resp.Content+"] ";
                    WriteOutError(elg,ErrorLog.IfaceResult.FAIL);
                }


            }
            catch(Exception ex)
            {
                string lg = "Critical Error UpdateTaskFromRecord Rest Services Error ["+ex.Message+"] ";
                WriteOutError(lg,ErrorLog.IfaceResult.FAIL);

            }

            return success;
        }


        public Boolean GetAllTaskFromRecord(Records ar,string accelaRecordID,string licnum,ref WorkFlowTask wft)
        {
            Boolean success = true;

            try
            {
                var options = new RestClientOptions(restCfg.AccelaRestServiceAPIBaseURL);
                options.Timeout = TimeSpan.FromMinutes(5);

                rsclient = new RestClient(options);
                var request = new RestRequest(restCfg.AccelaRestServiceAPIBaseURL+"/"+restCfg.AccelaRestServiceSGetAllTasks.Replace("recordId",accelaRecordID), Method.Get);
                request.Timeout = TimeSpan.FromMinutes(5);

                
                request.AddHeader("Authorization", ReturnAccessToken() );
                
                var resp = rsclient.ExecuteGet(request);
                if (resp.IsSuccessful && resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    try
                    {
                        //WorkFlowTask arl = new WorkFlowTask();
                        wft = JsonConvert.DeserializeObject<WorkFlowTask>(resp.Content);
                        int k = 0;
                    }
                    catch(Exception ex)
                    {
                        string lg = "Critical Error GetAllRecordFromAccela Deserialize Record Object ["+ex.Message+"] ";
                        WriteOutError(lg,ErrorLog.IfaceResult.FAIL);
                    }

                }
                else 
                {
                    string elg = "Error GetAllRecordFromAccela Rest Services Error ["+resp.Content+"] ";
                    WriteOutError(elg,ErrorLog.IfaceResult.FAIL);
                }


            }
            catch(Exception ex)
            {
                string lg = "Critical Error GetAllTaskFromRecord Rest Services Error ["+ex.Message+"] ";
                WriteOutError(lg,ErrorLog.IfaceResult.FAIL);

            }

            return success;
        }
        public Boolean GetARecordFromAccela(string id,ref AccelaRecordsRoot ar)
        {
            Boolean success = true;

            try
            {
                var options = new RestClientOptions(restCfg.AccelaRestServiceAPIBaseURL);
                options.Timeout = TimeSpan.FromMinutes(5);

                rsclient = new RestClient(options);
                var request = new RestRequest(restCfg.AccelaRestServiceAPIBaseURL+"/"+restCfg.AccelaRestServiceGetSingleRecordEndPoint+id, Method.Get);
                request.Timeout = TimeSpan.FromMinutes(5);                

                request.AddHeader("Authorization", ReturnAccessToken() );
                
                var resp = rsclient.ExecuteGet(request);
                if (resp.IsSuccessful && resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    try
                    {
                        AccelaRecordsRoot arl = new AccelaRecordsRoot();
                        arl = JsonConvert.DeserializeObject<AccelaRecordsRoot>(resp.Content);

                    }
                    catch(Exception ex)
                    {
                        string lg = "Critical Error GetARecordFromAccela Deserialize Record Object ["+ex.Message+"] ID ["+id+"]";
                        WriteOutError(lg,ErrorLog.IfaceResult.FAIL);
                    }

                }
                else 
                {
                    string elg = "Error Getting GetARecordFromAccela Rest Services Error ["+resp.Content+"] ID ["+id+"]";
                    WriteOutError(elg,ErrorLog.IfaceResult.FAIL);
                }




            }
            catch(Exception ex)
            {
                string lg = "Critical Error GetARecordFromAccela Rest Services Error ["+ex.Message+"] ID ["+id+"]";
                WriteOutError(lg,ErrorLog.IfaceResult.FAIL);

            }
            finally
            {

            }

            return success;
        }

        public Boolean CreateAccelaInspection(Records ar,string accelaRecordID,string licnum)
        {
            /*  this creates the inspections associated to a record.
            */
            Boolean success = true;

            try
            {
                List<Inspections> theinspections = new List<Inspections>();
                List<NurseryInspection> thenurseryinsp = new List<NurseryInspection>();
                theinspections = restMtData.inspList.FindAll(x=> x.LicenseNumber.ToString() == licnum);
                thenurseryinsp = restMtData.nurseryInspectionList.FindAll(x=> x.LicenseNumber.ToString() == licnum);

                if (licnum=="1116")
                {
                    // int kj = 0;
                }
                foreach(Inspections i in theinspections)
                {

                    string insp_json =  @BuildInspectionJsonstring(accelaRecordID,i.InspectionDate);

                    var options = new RestClientOptions(restCfg.AccelaRestServiceAPIBaseURL);
                    options.Timeout = TimeSpan.FromMinutes(5);

                    rsclient = new RestClient(options);

                    var request = new RestRequest(restCfg.AccelaRestServiceAPIBaseURL+"/"+restCfg.AccelaRestServiceCreateInspection, Method.Post);
                    request.Timeout = TimeSpan.FromMinutes(5);


                    request.AddHeader("Authorization", ReturnAccessToken() );
                    // request.AddHeader("Content-Type", "text/plain");
                    request.AddHeader("Content-Type", "application/json");

                    request.AddStringBody(insp_json, DataFormat.Json);
                    
                    RestResponse resp = rsclient.ExecutePost(request);
                    RestResultContent rc = new RestResultContent();
                    rc = JsonConvert.DeserializeObject<RestResultContent>(resp.Content);
                    if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string id = rc.result.id;
                        // Console.WriteLine("Inspection Created");
                        string lg = "Inspection Created. Accela Record ID["+accelaRecordID+"] Legacy License ["+ar.GetLicenseFromDescription()+"]";
                        WriteOutError(lg,ErrorLog.IfaceResult.CONVERTEDINSPECTION);
                        
                        ResultInspection(id);
                        
                    }
                    else 
                    {
                        string lg = "Error Creating Inspections Accela Rest Services Error ["+resp.Content+"] "+accelaRecordID;
                        WriteOutError(lg,ErrorLog.IfaceResult.FAIL);
                    }

                }

                foreach(NurseryInspection ni in thenurseryinsp)
                {
                    string insp_json =  @BuildNurseryInspectionJsonstring(accelaRecordID,ni);

                    var options = new RestClientOptions(restCfg.AccelaRestServiceAPIBaseURL);
                    options.Timeout = TimeSpan.FromMinutes(5);

                    rsclient = new RestClient(options);

                    var request = new RestRequest(restCfg.AccelaRestServiceAPIBaseURL+"/"+restCfg.AccelaRestServiceCreateInspection, Method.Post);
                    request.Timeout = TimeSpan.FromMinutes(5);


                    request.AddHeader("Authorization", ReturnAccessToken() );
                    // request.AddHeader("Content-Type", "text/plain");
                    request.AddHeader("Content-Type", "application/json");

                    request.AddStringBody(insp_json, DataFormat.Json);
                    
                    RestResponse resp = rsclient.ExecutePost(request);
                    RestResultContent rc = new RestResultContent();
                    rc = JsonConvert.DeserializeObject<RestResultContent>(resp.Content);
                    if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        // Console.WriteLine("Inspection Created ");
                        ResultInspection(rc.result.id);

                    }
                    else 
                    {
                        string lg = "Error Creating Inspections Accela Rest Services Error ["+resp.ErrorMessage+"] "+accelaRecordID;
                        WriteOutError(lg,ErrorLog.IfaceResult.FAIL);
                    }
                }




            }
            catch(Exception ex)
            {
                string lg = "Critical Error Creating Inspection Accela Rest Services Error ["+ex.Message+"] ";
                WriteOutError(lg,ErrorLog.IfaceResult.FAIL);
            }
            finally
            {

            }


            return success;
        }

        public Boolean ResultInspection(string id)
        {
            /*  this results the inspections associated with the record.
            */
            Boolean success = true;

            try
            {
                var options = new RestClientOptions(restCfg.AccelaRestServiceAPIBaseURL);
                options.Timeout = TimeSpan.FromMinutes(5);

                rsclient = new RestClient(options);

                InspStatus stat = new InspStatus();
                stat.status.text="Completed";
                stat.status.value ="Completed";

                string inspRes =  @JsonConvert.SerializeObject(stat);

                inspRes = inspRes.Replace("result/status/","");
                var request = new RestRequest(restCfg.AccelaRestServiceAPIBaseURL+"/"+restCfg.AccelaRestServiceSResultInsp.Replace("id",id), Method.Put);
                
                request.Timeout = TimeSpan.FromMinutes(5);


                request.AddHeader("Authorization", ReturnAccessToken() );
                // request.AddHeader("Content-Type", "text/plain");
                request.AddHeader("Content-Type", "application/json");

                request.AddStringBody(inspRes, DataFormat.Json);
                
                RestResponse resp = rsclient.ExecutePut(request);
                RestResultContent rc = new RestResultContent();
                rc = JsonConvert.DeserializeObject<RestResultContent>(resp.Content);

                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // Console.WriteLine("Inspection Resulted");
                    string lg = "Record Inspection Created. Accela Record ID["+id+"] ";
                    WriteOutError(lg,ErrorLog.IfaceResult.CONVERTEDINSPECTION);

                }
                else 
                {
                    string lg = "Error Resulting Inspections Accela Rest Services Error ["+resp.ErrorMessage+"] "+id;
                    WriteOutError(lg,ErrorLog.IfaceResult.FAIL);
                }

            }
            catch(Exception ex)
            {
                string lg = "Critical Error Resulting Inspections Accela Rest Services Error ["+ex.Message+"] "+id;
                WriteOutError(lg,ErrorLog.IfaceResult.FAIL);

            }
            finally
            {

            }


            return success;
        }

        public Boolean CreateUpdateContactCustomForm(Records ar,string accelaRecordID,string cntcID,string licnum)
        {
            /*  this pushes in the custom form data.  this is agency data.
            */
            Boolean success = true;

            try
            {

                var options = new RestClientOptions(restCfg.AccelaRestServiceAPIBaseURL);
                options.Timeout = TimeSpan.FromMinutes(5);

                rsclient = new RestClient(options);

                string endpoint = restCfg.AccelaRestServiceContactCustomForms.Replace("recordId",accelaRecordID);
                endpoint = endpoint.Replace("contactId",cntcID);

                var request = new RestRequest(restCfg.AccelaRestServiceAPIBaseURL+"/"+endpoint, Method.Put);
                request.Timeout = TimeSpan.FromMinutes(5);


                request.AddHeader("Authorization", ReturnAccessToken() );
                // request.AddHeader("Content-Type", "text/plain");
                request.AddHeader("Content-Type", "application/json");

                // var ar_string = @JsonConvert.SerializeObject(ar.customForms);
                var ar_string = @BuildCustomContactFormJsonString(cntcID,licnum);

                request.AddStringBody(ar_string, DataFormat.Json);
                
                if (ar_string=="[]")
                {
                    return true;
                }

                RestResponse resp = rsclient.ExecutePut(request);
                RestResultContent rc = new RestResultContent();
                // rc = JsonConvert.DeserializeObject<RestResultContent>(resp.Content);
                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // Console.WriteLine("Custom Form Updated");
                    string lg = "Record Contact Custom Form Created. Accela Record ID["+accelaRecordID+"] Legacy License ["+ar.GetLicenseFromDescription()+"]";
                    WriteOutError(lg,ErrorLog.IfaceResult.CONVERTEDCUSTOM);

                }
                else 
                {
                    string lg = "Error Contact Creating Custom Forms Accela Rest Services Error ["+resp.ErrorException.Message+"] "+accelaRecordID+"\n  [";
                    lg+= ar_string+"]";
                    WriteOutError(lg,ErrorLog.IfaceResult.FAIL);
                }

            }
            catch(Exception ex)
            {
                string lg = "Critical Contact Custom Error Custom Forms Accela Rest Services Error ["+ex.Message+"] ";
                WriteOutError(lg,ErrorLog.IfaceResult.FAIL);

            }
            finally
            {

            }

            return success;
 
        }


        public Boolean CreateUpdateCustomForm(Records ar,string accelaRecordID)
        {
            /*  this pushes in the custom form data.  this is agency data.
            */
            Boolean success = true;

            try
            {

                var options = new RestClientOptions(restCfg.AccelaRestServiceAPIBaseURL);
                options.Timeout = TimeSpan.FromMinutes(5);

                rsclient = new RestClient(options);

                var request = new RestRequest(restCfg.AccelaRestServiceAPIBaseURL+"/"+restCfg.AccelaRestServiceUpdateCustomFormsEndPoint.Replace("recordId",accelaRecordID), Method.Put);
                request.Timeout = TimeSpan.FromMinutes(5);


                request.AddHeader("Authorization", ReturnAccessToken() );
                // request.AddHeader("Content-Type", "text/plain");
                request.AddHeader("Content-Type", "application/json");

                // var ar_string = @JsonConvert.SerializeObject(ar.customForms);
                var ar_string = @BuildCustomFormJsonString(ar.customForms);

                request.AddStringBody(ar_string, DataFormat.Json);
                
                RestResponse resp = rsclient.ExecutePut(request);
                RestResultContent rc = new RestResultContent();
                // rc = JsonConvert.DeserializeObject<RestResultContent>(resp.Content);
                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // Console.WriteLine("Custom Form Updated");
                    string lg = "Record Custom Form Created. Accela Record ID["+accelaRecordID+"] Legacy License ["+ar.GetLicenseFromDescription()+"]";
                    WriteOutError(lg,ErrorLog.IfaceResult.CONVERTEDCUSTOM);

                }
                else 
                {
                    string lg = "Error Creating Custom Forms Accela Rest Services Error ["+resp.ErrorException.Message+"] "+accelaRecordID+"\n  [";
                    lg+= ar_string+"]";
                    WriteOutError(lg,ErrorLog.IfaceResult.FAIL);
                }

            }
            catch(Exception ex)
            {
                string lg = "Critical Error Custom Forms Accela Rest Services Error ["+ex.Message+"] ";
                WriteOutError(lg,ErrorLog.IfaceResult.FAIL);

            }
            finally
            {

            }

            return success;
 
        }

        public Boolean CreateUpdateRecordFees(Records ar,string accelaRecordID,MTData mtdat,string licnums,string curloc)
        {
            Boolean success = true;

            try
            {
                string transid = string.Empty;
                Location locs = new Location();
                locs = ar.GetLocationNumberFromLicense(licnums,mtdat.LocationList,mtdat.LicenseList,ar,curloc);

                List<LocationTransaction> loctrans = new List<LocationTransaction>();
                loctrans = ar.GetLocationTransactionFromLicense(locs.LocationNumber.ToString(),mtdat);

                List<LocationTransactionDetail> loctransdets = new List<LocationTransactionDetail>();
                loctransdets = ar.GetLocationTransactionDetailsFromLicense(loctrans,mtdat);



                var options = new RestClientOptions(restCfg.AccelaRestServiceAPIBaseURL);
                options.Timeout = TimeSpan.FromMinutes(5);

                rsclient = new RestClient(options);

                var request = new RestRequest(restCfg.AccelaRestServiceAPIBaseURL+"/"+restCfg.AccelaRestServiceSCreateRecordFees.Replace("recordId",accelaRecordID), Method.Post);
                request.Timeout = TimeSpan.FromMinutes(5);


                request.AddHeader("Authorization", ReturnAccessToken() );
                request.AddHeader("Content-Type", "application/json");

                // string raddy = @BuildRecordAddressJsonstring(accelaRecordID,loclist,counts,liclist,ar,licnums);
                // var ar_string = @JsonConvert.SerializeObject(raddy);
                // var ar_string ="[" +@BuildRecordPeopleJsonstring(accelaRecordID,pers,liclist,peeploclist,ar,licnums)+"]";
                var ar_string = @BuildRecordFeeJsonstring(accelaRecordID,mtdat,ar,licnums);


                if (ar_string=="[]")
                {
                    Console.WriteLine("No Fees found in License Location  "+licnums);
                }
                else 
                {
                    request.AddStringBody(ar_string, DataFormat.Json);
                    
                    RestResponse resp = rsclient.ExecutePost(request);
                    RestResultContentFee rc = new RestResultContentFee();
                    rc = JsonConvert.DeserializeObject<RestResultContentFee>(resp.Content);
                    if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        List<string> feeids = new List<string>();
                        Console.WriteLine("Record Fees Updated");
                        string lg = "Record Fees Updated. Accela Record ID["+accelaRecordID+"] Legacy License ["+ar.GetLicenseFromDescription()+"]";
                        foreach(RestResult r in rc.result)
                        {
                            feeids.Add(r.id);
                        }
                        
                        CreateUpdateRecordInvoiceFees( ar,accelaRecordID, mtdat,licnums,feeids);
                        AddFeesAdded(accelaRecordID);
                        WriteOutError(lg,ErrorLog.IfaceResult.CONVERTEDFEES);

                    }
                    else 
                    {
                        string lg = "Error Creating Record Fees Accela Rest Services Error ["+resp.ErrorException.Message+"] "+accelaRecordID+"\n [";
                        //lg+= ar_string+"]";
                        WriteOutError(lg,ErrorLog.IfaceResult.FAIL);
                    }

                }

            }
            catch(Exception ex)
            {
                string lg = "Critical Error Record Fees Accela Rest Services Error ["+ex.Message+"] ";
                WriteOutError(lg,ErrorLog.IfaceResult.FAIL);

            }
            finally
            {

            }

            return success;
 
        }

        public Boolean CreateUpdateRecordInvoiceFees(Records ar,string accelaRecordID,MTData mtdat,string licnums,List<string> rc)
        {
            Boolean success = true;

            try
            {
                string transid = string.Empty;

                var options = new RestClientOptions(restCfg.AccelaRestServiceAPIBaseURL);
                options.Timeout = TimeSpan.FromMinutes(5);

                rsclient = new RestClient(options);

                var request = new RestRequest(restCfg.AccelaRestServiceAPIBaseURL+"/"+restCfg.AccelaRestServiceSCreateRecordInvoiceFees.Replace("recordId",accelaRecordID), Method.Post);
                request.Timeout = TimeSpan.FromMinutes(5);


                request.AddHeader("Authorization", ReturnAccessToken() );
                request.AddHeader("Content-Type", "application/json");

                // string raddy = @BuildRecordAddressJsonstring(accelaRecordID,loclist,counts,liclist,ar,licnums);
                var ar_string = @JsonConvert.SerializeObject(rc.ToArray());
                // var ar_string ="[" +@BuildRecordPeopleJsonstring(accelaRecordID,pers,liclist,peeploclist,ar,licnums)+"]";
                // var ar_string = @BuildRecordFeeJsonstring(accelaRecordID,mtdat,ar,licnums);
                // var ar_string = rc.ToString();


                if (ar_string=="[]")
                {
                    Console.WriteLine("No Fees found in License Location  "+licnums);
                }
                else 
                {
                    ar_string = ar_string.Replace("\"","");
                    request.AddStringBody(ar_string, DataFormat.Json);
                    
                    RestResponse resp = rsclient.ExecutePost(request);
                    // RestResultContent rc = new RestResultContent();
                    // rc = JsonConvert.DeserializeObject<RestResultContent>(resp.Content);
                    if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Console.WriteLine("Record Fees Updated");
                        string lg = "Record Fees Updated. Accela Record ID["+accelaRecordID+"] Legacy License ["+ar.GetLicenseFromDescription()+"]";
                        WriteOutError(lg,ErrorLog.IfaceResult.CONVERTEDFEES);

                    }
                    else 
                    {
                        string lg = "Error Creating Record Fees Accela Rest Services Error ["+resp.ErrorException.Message+"] "+accelaRecordID+"\n [";
                        //lg+= ar_string+"]";
                        WriteOutError(lg,ErrorLog.IfaceResult.FAIL);
                    }

                }

            }
            catch(Exception ex)
            {
                string lg = "Critical Error Record Fees Accela Rest Services Error ["+ex.Message+"] ";
                WriteOutError(lg,ErrorLog.IfaceResult.FAIL);

            }
            finally
            {

            }

            return success;
 
        }


        public Boolean CreateUpdatePeople(Records ar,string accelaRecordID,List<Person> pers,List<License> liclist,List<PeopleLocations> peeploclist,List<Location> loclist,string licnums)
        {
            Boolean success = true;

            try
            {

                var options = new RestClientOptions(restCfg.AccelaRestServiceAPIBaseURL);
                options.Timeout = TimeSpan.FromMinutes(5);

                rsclient = new RestClient(options);

                var request = new RestRequest(restCfg.AccelaRestServiceAPIBaseURL+"/"+restCfg.AccelaRestServiceSCreateUPdateRecordPeople.Replace("recordId",accelaRecordID), Method.Post);
                request.Timeout = TimeSpan.FromMinutes(5);


                request.AddHeader("Authorization", ReturnAccessToken() );
                request.AddHeader("Content-Type", "application/json");

                // string raddy = @BuildRecordAddressJsonstring(accelaRecordID,loclist,counts,liclist,ar,licnums);
                // var ar_string = @JsonConvert.SerializeObject(raddy);
                // var ar_string ="[" +@BuildRecordPeopleJsonstring(accelaRecordID,pers,liclist,peeploclist,ar,licnums)+"]";
                
                var ar_string = @BuildRecordPeopleJsonstring(accelaRecordID,pers,liclist,peeploclist,loclist,ar,licnums);
                if (ar_string=="[]")
                {
                    // int k = 0;
                    // Console.WriteLine("No contact found in License Location  "+licnums);
                }
                else 
                {
                    request.AddStringBody(ar_string, DataFormat.Json);
                    
                    RestResponse resp = rsclient.ExecutePost(request);
                    RestResultContentFee rc = new RestResultContentFee();
                    rc = JsonConvert.DeserializeObject<RestResultContentFee>(resp.Content);
                    if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string theid = string.Empty;
                        foreach(RestResult rf in rc.result)
                        {
                            theid = rf.id;
                        }
                        CreateUpdateContactCustomForm(ar,accelaRecordID,theid,licnums);
                        // Console.WriteLine("Record People Updated");
                        string lg = "Record People Updated. Accela Record ID["+accelaRecordID+"] Legacy License ["+ar.GetLicenseFromDescription()+"]";
                        WriteOutError(lg,ErrorLog.IfaceResult.CONVERTEDPEOPLE);

                    }
                    else 
                    {
                        string lg = "Error Creating People Accela Rest Services Error ["+resp.ErrorMessage+"] "+accelaRecordID;
                        WriteOutError(lg,ErrorLog.IfaceResult.FAIL);
                    }

                }

            }
            catch(Exception ex)
            {
                string lg = "Critical Error Creating People Accela Rest Services Error ["+ex.Message+"] ";
                WriteOutError(lg,ErrorLog.IfaceResult.FAIL);

            }
            finally
            {

            }

            return success;
 
        }

        public Boolean CreateUpdateRecordAddress(Records ar,string accelaRecordID,List<Location> loclist,List<License> liclist,List<County> counts,string licnums,string curloc)
        {
            Boolean success = true;

            try
            {

                var options = new RestClientOptions(restCfg.AccelaRestServiceAPIBaseURL);
                options.Timeout = TimeSpan.FromMinutes(5);

                rsclient = new RestClient(options);

                var request = new RestRequest(restCfg.AccelaRestServiceAPIBaseURL+"/"+restCfg.AccelaRestServiceSRecordAddress.Replace("recordId",accelaRecordID), Method.Post);
                request.Timeout = TimeSpan.FromMinutes(5);


                request.AddHeader("Authorization", ReturnAccessToken() );
                request.AddHeader("Content-Type", "application/json");

                // string raddy = @BuildRecordAddressJsonstring(accelaRecordID,loclist,counts,liclist,ar,licnums);
                // var ar_string = @JsonConvert.SerializeObject(raddy);
                var ar_string ="[" +@BuildRecordAddressJsonstring(accelaRecordID,loclist,counts,liclist,ar,licnums,ar,curloc)+"]";

                if (string.IsNullOrEmpty(ar_string) ||ar_string=="[]"  )
                {
                    return true;
                }
                request.AddStringBody(ar_string, DataFormat.Json);
                
                RestResponse resp = rsclient.ExecutePost(request);
                RestResultContent rc = new RestResultContent();
                // rc = JsonConvert.DeserializeObject<RestResultContent>(resp.Content);
                if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // Console.WriteLine("Record Address Updated");
                    string lg = "Record Address Updated. Accela Record ID["+accelaRecordID+"] Legacy License ["+ar.GetLicenseFromDescription()+"]";
                    WriteOutError(lg,ErrorLog.IfaceResult.CONVERTEDADDRESS);


                }
                else 
                {
                    string lg = "Error Creating Record Address Accela Rest Services Error ["+resp.ErrorMessage+"] "+accelaRecordID;
                    WriteOutError(lg,ErrorLog.IfaceResult.FAIL);
                }



            }
            catch(Exception ex)
            {
                string lg = "Critical Error Creating Record Address Accela Rest Services Error ["+ex.Message+"] ";
                WriteOutError(lg,ErrorLog.IfaceResult.FAIL);

            }
            finally
            {

            }

            return success;
 
        }


        public RenewalInfo BuildRenewalInfo(Records ar)
        {
            RenewalInfo ri = new RenewalInfo();

            try
            {
                int? lic = Convert.ToInt32(ar.GetLicenseFromDescription());
                List<License> thelics = new List<License>();
                thelics = restMtData.LicenseList.FindAll(x=>x.LicenseNumber==lic);
                DateTime tempdate = new DateTime();
                tempdate = DateTime.MinValue;
                foreach(License l in thelics)
                {
                    List<LocationDates> locdates = new List<LocationDates>();
                    locdates = restMtData.LocationDatesList.FindAll(x=> x.LocationNumber == l.LocationNumber);
                    foreach(LocationDates ld in locdates)
                    {
                        if (!string.IsNullOrEmpty(ld.LicenseExpirationDate))
                        {
                            DateTime myDate = DateTime.Parse(ld.LicenseExpirationDate);
                            if (myDate>tempdate)
                            {
                                tempdate = myDate;
                            }
                            
                        }
                    }
                }

                ri.expirationDate = tempdate.ToString();
                ri.expirationStatus = new Status();

                DateTime GoliveDate = DateTime.Parse(restCfg.GoLiveDate);
                
                ri.expirationStatus.text = "Active";
                ri.expirationStatus.value = "Active";

                if (tempdate < DateTime.Now)
                {
                    ri.expirationStatus.text = "About to Expire";
                    ri.expirationStatus.value = "About to Expire";
                }

                TimeSpan duration = GoliveDate - tempdate;
                if (duration.TotalDays<=60)
                {
                    ri.expirationStatus.text = "About to Expire";
                    ri.expirationStatus.value = "About to Expire";

                }
                else 
                {

                }

            }
            catch(Exception ex)
            {
                string lg = "Critical Error BuildRenewalInfo Error ["+ex.Message+"] ";
                WriteOutError(lg,ErrorLog.IfaceResult.FAIL);
            }


            return ri;
        }

        public Boolean UpdateRecordNoCustom(string ar_string,string accelaRecordID)
        {
            try
            {
                var options = new RestClientOptions(restCfg.AccelaRestServiceAPIBaseURL);
                options.Timeout = TimeSpan.FromMinutes(5);

                rsclient = new RestClient(options);
                var request = new RestRequest(restCfg.AccelaRestServiceAPIBaseURL+"/"+restCfg.AccelaRestServiceGetUpdateRecordEndPoint.Replace("id",accelaRecordID), Method.Put);
                request.Timeout = TimeSpan.FromMinutes(5);


                request.AddHeader("Authorization", ReturnAccessToken() );
                // request.AddHeader("Content-Type", "text/plain");
                request.AddHeader("Content-Type", "application/json");
                
                
                ar_string = ar_string.Replace("result/","");
                ar_string = ar_string.Replace("type/","");
                ar_string = ar_string.Replace("status/","");

                string rec_update_json = ar_string;
                request.AddStringBody(ar_string, DataFormat.Json);
                // request.AddJsonBody(ar_string,false);

                RestResponse resp = rsclient.ExecutePut(request);
                RestResultContent rc = new RestResultContent();
                rc = JsonConvert.DeserializeObject<RestResultContent>(resp.Content);
                if (rc.status==200)
                {
                    string lg = "Base Record Update. Accela Record ID["+accelaRecordID+"]";
                    WriteOutError(lg,ErrorLog.IfaceResult.CONVERTEDBASE);
                }
                else 
                {
                    string lg = "Error Base Record Update. Accela Record ID["+accelaRecordID+"]";
                    WriteOutError(lg,ErrorLog.IfaceResult.FAIL);
                }
            }
            catch(Exception ex)
            {
                string lg = "Critical Error UpdateRecordNoCustom Rest Services Error ["+ex.Message+"] ";
                WriteOutError(lg,ErrorLog.IfaceResult.FAIL);
            }

            return true;
        }

        public Boolean CreateRecordNoCustom( Records ar )
        {
            /*  this goes and creates the base accela record/permit.  it makes calls to add the other auxilary items.
            */
            Boolean success = true;

            try
            {
                // Console.WriteLine("The Value "+ar.type.value);
                // return true;
                string accelaRecordID = string.Empty;
                var options = new RestClientOptions(restCfg.AccelaRestServiceAPIBaseURL);
                options.Timeout = TimeSpan.FromMinutes(5);

                rsclient = new RestClient(options);
                var request = new RestRequest(restCfg.AccelaRestServiceAPIBaseURL+"/"+restCfg.AccelaRestServiceCreateRecordEndPoint, Method.Post);
                request.Timeout = TimeSpan.FromMinutes(5);


                request.AddHeader("Authorization", ReturnAccessToken() );
                // request.AddHeader("Content-Type", "text/plain");
                request.AddHeader("Content-Type", "application/json");
                
                ar.renewalInfo = BuildRenewalInfo(ar);

                var ar_string = @JsonConvert.SerializeObject(ar);
                
                ar_string = ar_string.Replace("result/","");
                ar_string = ar_string.Replace("type/","");
                ar_string = ar_string.Replace("status/","");
                string rec_update_json = ar_string;
                request.AddStringBody(ar_string, DataFormat.Json);
                // request.AddJsonBody(ar_string,false);

                int? lic = Convert.ToInt32(ar.GetLicenseFromDescription());
                

                
                Location temploc = new Location();
                temploc = ar.GetLocationNumberFromLicense(ar.GetLicenseFromDescription(),restMtData.LocationList,restMtData.LicenseList,ar,string.Empty);
                string countys = ar.GetCountyFromLicense(ar.GetLicenseFromDescription(),restMtData.LocationList,restMtData.LicenseList,restMtData.CountyList,ar);
                string licnums = ar.GetLicenseFromDescription();

                if (!recprocessed(lic,ar.type.value,temploc))
                {
                    RestResponse resp = rsclient.ExecutePost(request);
                    RestResultContent rc = new RestResultContent();
                    rc = JsonConvert.DeserializeObject<RestResultContent>(resp.Content);
                    if (rc.status==200)
                    {
                        // Console.WriteLine("Base Record Created.  Adding Auxillary Items");
                        string lg = "Base Record Created. Accela Record ID["+rc.result.id+"] Custom ID ["+rc.result.customId+"] Legacy License ["+ar.GetLicenseFromDescription()+"]";
                        WriteOutError(lg,ErrorLog.IfaceResult.CONVERTEDBASE);
                        
                        accelaRecordID = rc.result.id;
                        UpdateRecordNoCustom( ar_string, accelaRecordID);


                        if (ar.customForms.Count>0 && ar.type.value!="eStop/Master Location/Record/NA")
                        {
                            CreateUpdateCustomForm(ar,accelaRecordID);
                        }

                        
                        if (ar.status.value.ToUpper()!="ACTIVE")
                        {
                            WorkFlowTask wft = new WorkFlowTask();
                            GetAllTaskFromRecord(ar,accelaRecordID,licnums,ref  wft);
                            UpdateTaskFromRecord(ar,accelaRecordID,wft,ar.status.text);
                        }

                        CreateAccelaInspection(ar,accelaRecordID,licnums);

                        List<License> loclic = new List<License>();
                        loclic = restMtData.LicenseList.FindAll(x=>x.LicenseNumber.ToString()==licnums);
                        foreach(License loclics in loclic)
                        {
                            List<Location> lc = new List<Location>();

                            CreateUpdateRecordAddress(ar,accelaRecordID,restMtData.LocationList,restMtData.LicenseList,restMtData.CountyList,licnums,loclics.LocationNumber.ToString());
                            CreateUpdateRecordFees(ar,accelaRecordID,restMtData,licnums,loclics.LocationNumber.ToString());
                        }
                        
                        // foreach
                        CreateUpdatePeople(ar,accelaRecordID,restMtData.PersonList,restMtData.LicenseList,restMtData.PeopleLocationList,restMtData.LocationList,licnums);
                        recprocessedAddToList(lic,ar.type.value,temploc);
                        BuildRelatedList(ar,temploc.LocationNumber.ToString(),accelaRecordID);
                    }
                    else 
                    {
                        string lg = "Error Creating Record Accela Rest Services Error ["+rc.message+"] ";
                        WriteOutError(lg,ErrorLog.IfaceResult.FAIL);

                    }
                }
                else 
                {
                    // int kjj=0;
                }
            }
            catch(Exception ex)
            {
                string lg = "Critical Error Creating Record Accela Rest Services Error ["+ex.Message+"] ";
                WriteOutError(lg,ErrorLog.IfaceResult.FAIL);

            }
            finally
            {
                //  Console.WriteLine("The Lenght of related "+relatedrecs.Count().ToString());
            }

            return success;
        }

        public Boolean CreateRelatedRecs()
        {
            Boolean success = true;

            try
            {
                List<AccelaRelatedRecords> MatsterRecords = new List<AccelaRelatedRecords>();
                MatsterRecords = relatedrecs.FindAll(x=>!string.IsNullOrEmpty(x.MasterRecId));

                foreach(AccelaRelatedRecords master in MatsterRecords)
                {
                    List<AccelaRelatedRecords> child = new List<AccelaRelatedRecords>();
                    child = relatedrecs.FindAll(x=>x.LocationNumber==master.LocationNumber);

                    List<string> relatedchildren = new List<string>();
                    foreach(AccelaRelatedRecords chld in child )
                    {
                        if (!string.IsNullOrEmpty(chld.childRecId))                        
                        {
                            relatedchildren.Add(chld.childRecId);
                        }
                    }

                    if (relatedchildren.Count() <=0)
                    {
                        continue;
                    }

                    var options = new RestClientOptions(restCfg.AccelaRestServiceAPIBaseURL);
                    options.Timeout = TimeSpan.FromMinutes(5);

                    rsclient = new RestClient(options);
                    var request = new RestRequest(restCfg.AccelaRestServiceAPIBaseURL+"/"+restCfg.AccelaRestServiceSCreateRelatedRecords.Replace("recordId",master.MasterRecId), Method.Post);
                    request.Timeout = TimeSpan.FromMinutes(5);


                    request.AddHeader("Authorization", ReturnAccessToken() );
                    // request.AddHeader("Content-Type", "text/plain");
                    request.AddHeader("Content-Type", "application/json");

                    var ar_string = @JsonConvert.SerializeObject(relatedchildren);
                    ar_string = ar_string.Replace("result/","");
                    ar_string = ar_string.Replace("type/","");
                    ar_string = ar_string.Replace("status/","");
                    
                    request.AddStringBody(ar_string, DataFormat.Json);

                    RestResponse resp = rsclient.ExecutePost(request);
                    RestResultContent rc = new RestResultContent();
                    // rc = JsonConvert.DeserializeObject<RestResultContent>(resp.Content);
                    if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string lg = "Related Record Created. Accela Record ID["+master.MasterRecId+"] ";
                        WriteOutError(lg,ErrorLog.IfaceResult.CONVERTRELATED);

                    }
                    else 
                    {
                        string lg = "Error Creating Related Record Accela Rest Services Error ["+resp.Content+"] RecordId ["+master.MasterRecId+"]";
                        // lg += " Lic ["++"]"
                        WriteOutError(lg,ErrorLog.IfaceResult.FAIL);
                    }


                }
            }
            catch (Exception ex)
            {
                string lg = "Critical Error Creating Related Record Accela Rest Services Error ["+ex.Message+"] ";
                WriteOutError(lg,ErrorLog.IfaceResult.FAIL);

            }


            return success;
        }
        public Boolean CreateRecord(AccelaRecordsRoot[] arr)
        {
            /*  this is the main worker method.  This will go throuh and fire off the threads to to do the conversion.

            */
            Boolean success = true;
            int numthreads = Convert.ToInt32(restCfg.NumberOfThreads);
            try
            {
                List<Task> ConvertTasks = new List<Task>();
                Stopwatch[] stopwatch = new Stopwatch[numthreads];
                // stopwatch.Start();


                for (int x=0;x<numthreads;x++)
                {
                    var indx = x;
                    if (restCfg.SingleRecord=="1")
                    {
                        AccelaRecordsRoot ar = arr[indx];
                        foreach(Records r in ar.records )
                        {
                            List<License> datefilter = restMtData.LicenseList.FindAll(x=>x.LicenseNumber.ToString()==r.GetLicenseFromDescription());
                            Boolean doreturn= false;

                            DateTime tempdate = new DateTime();
                            tempdate = DateTime.MinValue;

                            foreach(License liclic in datefilter)
                            {
                                DateTime a = liclic.When.GetValueOrDefault();
                                if (a>tempdate) tempdate = a;
                            }

                            doreturn = tempdate.Year<2023;


                            if (doreturn)
                            {
                                if (indx!=0)
                                {
                                    Console.WriteLine("Looping "+r.GetLicenseFromDescription());
                                    continue;
                                }
                            }
                            else 
                            {
                                if (indx!=0) 
                                {
                                    Console.WriteLine("Moving On  "+r.GetLicenseFromDescription());
                                    Thread.Sleep(5000);
                                    continue;
                                }

                            }

                            if (r.GetLicenseFromDescription()==restCfg.SingleRecordNumber)
                            {
                                CreateRecordNoCustom(r);
                            }
                            // CreateRecordNoCustom(r);
                            // switch (r.GetLicenseFromDescription()/*=="700595"*/  )
                            // {
                            //     // case "7396":
                            //     // case "7397":
                            //     case "41767":
                            //         CreateRecordNoCustom(r);
                            //         break;
                            //     case "7401":
                            //         CreateRecordNoCustom(r);
                            //         break;
                            // }
                        }
                    }
                    else 
                    {
                    /* this is the task/thread where we will do our work.  */
                        Task ct = new Task
                        (
                            () =>
                            {
                                int reccnt = 0;
                                AccelaRecordsRoot ar = arr[indx];
                                Stopwatch sw = new Stopwatch();
                                sw.Start();
                                stopwatch[indx] = sw;
                                foreach(Records r in ar.records )
                                {
                                    List<License> datefilter = restMtData.LicenseList.FindAll(x=>x.LicenseNumber.ToString()==r.GetLicenseFromDescription());
                                    Boolean doreturn= false;
                                    
                                    DateTime tempdate = new DateTime();
                                    tempdate = DateTime.MinValue;

                                    foreach(License liclic in datefilter)
                                    {
                                        DateTime dt = (DateTime) liclic.When.GetValueOrDefault();
                                        if (dt>tempdate) tempdate = dt;
                                    }

                                    doreturn = tempdate.Year<2023;

                                    reccnt++;
                                    if (doreturn)
                                    {
                                        if (indx!=0)
                                        {
                                            // Console.WriteLine("Looping "+r.GetLicenseFromDescription());
                                            // Thread.Sleep(15000);
                                            continue;
                                        }
                                    }
                                    else 
                                    {
                                        if (indx!=0) 
                                        {
                                            // Console.WriteLine("Moving On  "+r.GetLicenseFromDescription());
                                            // Thread.Sleep(5000);
                                        }

                                    }

                                    Console.WriteLine("indx "+indx+" Legacy License "+r.GetLicenseFromDescription()+"\nreccnt "+reccnt.ToString()+"/"+ar.records.Count.ToString());

                                    string reclog = "Processing Legacy License "+r.GetLicenseFromDescription();
                                    WriteOutError(reclog,ErrorLog.IfaceResult.INFO);

                                    CreateRecordNoCustom( r);

                                    if (restCfg.TestBatch=="1" && reccnt>Convert.ToInt32(restCfg.TestBatchSize))
                                    {
                                        break;
                                    }
                                }
                                stopwatch[indx].Stop();
                                Console.WriteLine("Thread "+indx.ToString()+"  Total Time Running "+stopwatch[indx].Elapsed.Minutes.ToString());

                                // Console.WriteLine(x.ToString());
                            }
                        );
                        ConvertTasks.Add(ct);
                        ct.Start();
                    }
                }


                // give the threads a chance to start before we start monitoring.
                Thread.Sleep(60000);
                Boolean ThreadsDone = false;

                if (restCfg.SingleRecord!="1")
                {
                    // this is the waiting loop.
                    while(!ThreadsDone)
                    {
                        string ThreadStats = string.Empty;
                        int threadcnt = 0;
                        foreach(Task t in ConvertTasks)
                        {
                            ThreadsDone = true;
                            ThreadStats+="Thread ["+threadcnt.ToString()+"]   ThreadStatus ["+t.Status.ToString()+"] \n";

                            if (t.Status== TaskStatus.Running)
                            {
                                ThreadsDone = false;
                            }
                            threadcnt++;
                        }
                        Console.WriteLine(ThreadStats+"\n ThreadsDone "+ThreadsDone.ToString()+"  \n"+DateTime.Now.ToString());
                        // Console.WriteLine("Total Time Running "+stopwatch.Elapsed.Minutes.ToString());
                        if(!ThreadsDone)
                        {
                            Thread.Sleep(180000);
                        }
                    }
                }
                // Task.WaitAll(ConvertTasks.ToArray());
                
                // int kj = 0;
            }
            catch(Exception ex)
            {
                string lg = "Critical Error Create Record Accela Rest Services Error ["+ex.Message+"] ";
                WriteOutError(lg,ErrorLog.IfaceResult.FAIL);
            }
            finally
            {
                // this takes the list of fees that we have to pay for, and sets the json for us to run in accela.
                Console.WriteLine("The Lenght of related "+relatedrecs.Count().ToString());
                string apnumsjson = JsonConvert.SerializeObject(FeesAdded);
                File.WriteAllText(restCfg.PaymentJsonFile, apnumsjson);
                // int aa=0;
            }

            return success;
        }


#endregion

        public AccelaRestServiceCls(ConfigFile CFG, LogFile LF)
        {
            restCfg = CFG;
            restLog = LF;
            Boolean success = true;
            restMtData = new MTData(CFG,LF,ref success);

            try
            {
            using (StreamReader file = File.OpenText("accelaFeeCodes.json"))
            {
                string jsonstring = file.ReadToEnd();
                feecodeList = JsonConvert.DeserializeObject<List<FEECODE>>(jsonstring);
            }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // LoginToAccelaRest();
            // cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddMinutes(Convert.ToInt32(restCfg.CacheTimeout));
            // memoryCache.Add("AuthObj",authobj,cacheItemPolicy);
        }
    }
    
}