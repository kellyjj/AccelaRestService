using System.Threading;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Net.Mail;
using System.Reflection;
// using System.Runtime.Caching;
using System.Collections;



namespace MTDataConversion
{
    public class EmailNotClassStruct
    {
        /* this class will hold the properties for the notification.  will be access through a list 
         */

        public string scadatagname { get; set; }
        public int compkey { get; set; }
        public int detailkey { get; set; }
        public Boolean Valid { get; set; }
        public string issueDesc { get; set; }
        public string UnitID { get; set; }

        void SetDefaultValues()
        {
            /* this sets all the default values.  using reflection */
            Type thetype = typeof(EmailNotClassStruct);
            PropertyInfo[] BaseStringInfo = thetype.GetProperties();
            string name = string.Empty;
            string t = string.Empty;

            try
            {
                foreach (PropertyInfo pi in BaseStringInfo)
                {
                    name = pi.Name;
                    t = pi.PropertyType.ToString();

                    string k = string.Empty;

                    if (pi.PropertyType.ToString() == "System.Decimal")
                    {
                        pi.SetValue(this, (decimal)0, null);
                    }
                    else if (pi.PropertyType.ToString() == "System.DateTime")
                    {
                        pi.SetValue(this, DateTime.MinValue, null);
                    }
                    else if (pi.PropertyType.ToString() == "System.Int32")
                    {
                        pi.SetValue(this, 0, null);
                    }
                    else if (pi.PropertyType.ToString() == "System.Double")
                    {
                        pi.SetValue(this, (double)0, null);
                    }
                    else if (pi.PropertyType.IsEnum)
                    {
                        //pi.SetValue(this, CDR_TYPES.NONE, null);
                    }
                    else if (pi.PropertyType.ToString() == "System.Boolean")
                    {
                        pi.SetValue(this, false, null);
                    }
                    else if (pi.PropertyType.ToString() == "System.Single")
                    {
                        pi.SetValue(this, (float)0, null);
                    }
                    else
                    {
                        pi.SetValue(this, string.Empty, null);
                    }
                }
            }
            catch (Exception ex)
            {
                string a = ex.Message + name + t;
            }
        }


        public EmailNotClassStruct()
        {
            SetDefaultValues();
        }

    }

    public class EmailNotClass
    {
        /*  this class will set up and email the status of what was going on in the iface.
         *  
         */
        public List<EmailNotClassStruct> ErrorList = new List<EmailNotClassStruct>();
        public int prog = 0;
        public int totupdate = 0;
        public int toterror = 0;
        public int TotalHansenRecs = 0;
        public int TotalScada = 0;
        string emailsubject = string.Empty;
        string emailbody = string.Empty;
        string emailsummary = string.Empty;

        public void BuildEmailBody()
        {
            /* this will build the body of the email and the subject of email
             */

            emailsubject = string.Format("SCADA / Hansen Interface - {0} Processed {1} Updated {2} Errors ", prog.ToString(), totupdate.ToString(), toterror.ToString());
            emailsummary = string.Format("\n Total Records Processed [{0}] Total Records Updated [{1}] Total Errors [{2}] ", prog.ToString(), totupdate.ToString(), toterror.ToString());

            emailbody = "Summary of Errors \n";
            foreach (EmailNotClassStruct st in ErrorList)
            {
                emailbody += string.Format("Hansen Asset {0} Tagname {1} Issue [{2}]\n", st.UnitID, st.scadatagname, st.issueDesc);
            }
        }

        //public void SendEmail(ConfigFile cfg, LogFile lf)
        //{
        //    /*  this will send the email.
        //     */
        //    BuildEmailBody();
        //    MailMessage email = new MailMessage(cfg.NotificationFrom, cfg.NOTIFCATIONEMAIL);
        //    SmtpClient smtpclient = new SmtpClient();




        //    smtpclient.Host = cfg.SMTP_INFO;
        //    email.Subject = emailsubject;
        //    email.Body = emailsummary;// + emailbody;
        //    email.Attachments.Add(new System.Net.Mail.Attachment(cfg.Hansen_LogPath));

        //    smtpclient.Send(email);


        //}


        public EmailNotClass()
        {

        }
    }

    public class ErrorLog
    {
        /*  this class will be where we add in our messages, etc...  the other class "logfile" will worry about writting to the logs.
         */
        public enum IfaceResult { NONE, SUCCESS, FAIL, INFO, WARNING,CONVERTED,CONVERTEDBASE,CONVERTEDCUSTOM,CONVERTEDINSPECTION,CONVERTEDADDRESS,CONVERTEDFEES,CONVERTEDPEOPLE,CONVERTCONFIGISSUE,CONVERTRELATED }  //the results for the interface

        #region thefields

        #endregion

        public string Message { get; set; }
        public IfaceResult ifResult { get; set; }

        void SetDefaultValues()
        {
            /* this sets all the default values.  using reflection */
            Type thetype = typeof(ErrorLog);
            PropertyInfo[] BaseStringInfo = thetype.GetProperties();
            string name = string.Empty;
            string t = string.Empty;

            try
            {
                foreach (PropertyInfo pi in BaseStringInfo)
                {
                    name = pi.Name;
                    t = pi.PropertyType.ToString();

                    string k = string.Empty;

                    if (pi.PropertyType.ToString() == "System.Decimal")
                    {
                        pi.SetValue(this, (decimal)0, null);
                    }
                    else if (pi.PropertyType.ToString() == "System.DateTime")
                    {
                        pi.SetValue(this, DateTime.MinValue, null);
                    }
                    else if (pi.PropertyType.ToString() == "System.Int32")
                    {
                        pi.SetValue(this, 0, null);
                    }
                    else if (pi.PropertyType.ToString() == "System.Double")
                    {
                        pi.SetValue(this, (double)0, null);
                    }
                    else if (pi.PropertyType.IsEnum)
                    {
                        //pi.SetValue(this, CDR_TYPES.NONE, null);
                    }
                    else if (pi.PropertyType.ToString() == "System.Boolean")
                    {
                        pi.SetValue(this, false, null);
                    }
                    else if (pi.PropertyType.ToString() == "System.Single")
                    {
                        pi.SetValue(this, (float)0, null);
                    }
                    else
                    {
                        pi.SetValue(this, string.Empty, null);
                    }
                }
            }
            catch (Exception ex)
            {
                string a = ex.Message + name + t;
            }
        }

        public ErrorLog()
        {
            SetDefaultValues();
        }

    }

    public class LogFile
    {
        /* this class is the log class for iface */

        /* this var is for the hansen ticket cache just for logs */
        // ObjectCache LogticketCache = MemoryCache.Default;

        /*  this will be eventually be a base class for the my logs.  will end up using delegates at some point to handle custom 
         *  agency logs (such as another web site, or table
         */

        XmlTextWriter xmlfile;

        Queue<ErrorLog> LogEntrieQDB = new Queue<ErrorLog>();
        Queue<ErrorLog> LogEntrieQFile = new Queue<ErrorLog>();
        Queue<ErrorLog> LogEntrieQSystem = new Queue<ErrorLog>();

        Thread WriteOutLogsDB;
        Thread WriteOutLogsFIle;
        Thread WriteOutLogsSystem;

        ConfigFile Logcfg = new ConfigFile();

        int LogLevel = 0;  //0=Everything, 1= Only Error messages
        public Boolean FileCreated = false;
        public string logpath;
        public string bizPath;
        public string apstr;
        public Boolean threading = false;
        public string ticket = string.Empty;
        public Int32 QSize = 10;  //default to 10. making public so we can change it from somewhere else.
        public Int32 SleepTime = 8000;   // this is the value to sleep when processing threads.
        public Boolean logrest = false;  // if set to true, any system logging or agency table will be used through rest.


        #region "FileLog"
        public void WriteXML_Log(ErrorLog el)
        {

            xmlfile.WriteStartElement("LogEntry");
            xmlfile.Formatting = Formatting.Indented;
            xmlfile.Indentation = 5;

            xmlfile.WriteStartElement("TimeStamp");
            xmlfile.WriteString(DateTime.Now.ToString());
            xmlfile.WriteEndElement();

            xmlfile.WriteStartElement("Result");
            xmlfile.WriteString(el.ifResult.ToString());
            xmlfile.WriteEndElement();

            xmlfile.WriteStartElement("Message");
            xmlfile.WriteString(el.Message);
            xmlfile.WriteEndElement();

            xmlfile.WriteEndElement();
            xmlfile.Flush();
        }

        public void WriteLogLineItemFile(ErrorLog errlog)
        {
            /* this either sneds to log, or  qs up the log for the thread 
             */
            try
            {
                if (FileCreated)
                {
                    if (!threading)
                    {
                        WriteXML_Log(errlog);
                    }
                    else
                    {
                        lock (LogEntrieQFile)
                        {
                            LogEntrieQFile.Enqueue(errlog);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Critical Error in Log Adding Que File " + ex.Message);
                //Console.ReadLine();
            }
        }

        public void CreateLogFile(string Path, string BizLog, int Level,string tk )
        {
            /* getting the ticket, so this is for web services and no hansen logging if ticket is empty */
            LogLevel = Level;
            logpath = Path;
            bizPath = BizLog;

            ticket = tk;
            xmlfile = new XmlTextWriter(Path, null);
            try
            {
                xmlfile.Formatting = Formatting.Indented;
                xmlfile.Indentation = 5;
                xmlfile.WriteStartDocument();
                xmlfile.WriteStartElement("ErrorLog");
                FileCreated = true;


            }
            catch
            {
                
            }



        }

        public void CreateLogFile(string Path, string BizLog, int Level, Boolean userest)
        {
            /*  for creating the file, and setting us to using rest for hansen logging */

            LogLevel = Level;
            logpath = Path;
            bizPath = BizLog;

            logrest = userest ;
            xmlfile = new XmlTextWriter(Path, null);
            try
            {
                xmlfile.Formatting = Formatting.Indented;
                xmlfile.Indentation = 5;
                xmlfile.WriteStartDocument();
                xmlfile.WriteStartElement("ErrorLog");
                FileCreated = true;
            }
            catch
            {

            }

        }

        void WriteOutThreadLogFile()
        {
            /*  if we are doing threading,  this will do the dump of hte q.  default to 10 items.
            *  this is for text file logs.  
            */

            string ld = string.Empty;
            string a = string.Empty;
            try
            {
                while (threading)
                {
                    if (LogEntrieQFile.Count > QSize)
                    {
                        lock (LogEntrieQFile)
                        {
                            while (LogEntrieQFile.Count > 0)
                            {
                                ErrorLog el = new ErrorLog();
                                el = (ErrorLog)LogEntrieQFile.Dequeue();

                                if (el != null)
                                {
                                    WriteXML_Log(el);
                                }

                            }
                        }
                    }
                    Thread.Sleep(SleepTime);
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Console.WriteLine(" ");
                Console.WriteLine("Critical Error in  File Log " + a + " --- " + ex.Message);
                //Console.ReadLine();
                string err2 = ld;
            }
        }

        #endregion


        #region "DB"
        public void WriteLogLineItemDB(ErrorLog errlog, int WONumber, bool errFlag)
        {
            /*  this is the method that handled db logs.  will turn into a delegate 
             */
            try
            {
                if (!threading && ticket.Length > 1)
                {
                    WriteOutErrorLogs(errlog);
                }
                else if (ticket.Length > 1)
                {
                    lock (LogEntrieQDB)
                    {
                        LogEntrieQDB.Enqueue(errlog);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Critical Error in Log Adding Que DB " + ex.Message);
                //Console.ReadLine();
            }
        }

        void WriteOutErrorLogs(ErrorLog errrec)
        {
            /*  this will go away from this class.  will keep here for example
             */
            //WebServiceResult res = new WebServiceResult();
            //System.Data.DataSet dsDetails = new System.Data.DataSet();  // this is just the ms data objects
            //Hansen.Core.WebServices.ExtensionDataService GenDetails = new Hansen.Core.WebServices.ExtensionDataService();   // this is the hansen ws object for dealing with agency tables.
            //GenDetails.Ticket = ticket;

            //try
            //{
            //    //Console.WriteLine("Doing the Log");
            //    /*for new or existing.  if new, will use the data struct returned.  Other wise update the bad boy */
            //    res = GenDetails.LoadDetailRecord("InforClient.AWU_AFD.Afd2IPSLog", "Afd2IPSLogKey", "0", out dsDetails);
            //    if (res.IsSuccess && !res.IsNoDataFound)
            //    {
            //        /* should never drop down into this */
            //    }
            //    else if (res.IsSuccess && res.IsNoDataFound)
            //    {
            //        /* add the records */
            //        System.Data.DataRow newGenDetail = dsDetails.Tables[0].NewRow();

            //        //newGenDetail["ADMINSTATUS"] = errrec.AdminStatus;
            //        //newGenDetail["APPARATUSNAME"] = errrec.ApparatusName;
            //        //newGenDetail["ASSIGN_STATION_1"] = errrec.Assign_Station_1;
            //        //newGenDetail["BATT_AREA"] = errrec.BATT_AREA;
            //        //newGenDetail["BATT_ASSIGN"] = errrec.BATT_ASSIGN;
            //        //newGenDetail["COMMENTS"] = errrec.Comments;
            //        //if (errrec.CreationDate.Year == 1)
            //        //{
            //        //    newGenDetail["CREATIONDATE"] = DBNull.Value ;
            //        //}
            //        //else
            //        //{
            //        //    newGenDetail["CREATIONDATE"] =  errrec.CreationDate;
            //        //}

            //        //newGenDetail["CREATOR"] = errrec.Creator;
            //        //if (errrec.Date_Inspected.Year == 1)
            //        //{
            //        //    newGenDetail["DATE_INSPECTED"] = DBNull.Value;
            //        //}
            //        //else
            //        //{
            //        //    newGenDetail["DATE_INSPECTED"] =  errrec.Date_Inspected;
            //        //}

            //        //if (errrec.EditDate.Year == 1)
            //        //{
            //        //    newGenDetail["EDITDATE"] = DBNull.Value;
            //        //}
            //        //else
            //        //{
            //        //    newGenDetail["EDITDATE"] = errrec.EditDate;
            //        //}

            //        //newGenDetail["EDITOR"] = errrec.Editor;
            //        //newGenDetail["EDITSTATUS"] = errrec.EditStatus;
            //        //newGenDetail["F2016"] = errrec.F2016;
            //        //newGenDetail["GLOBALID"] = errrec.GlobalID;
            //        //newGenDetail["HYDRANT_STATUS"] = errrec.Hydrant_Status;
            //        //newGenDetail["IFACERESULT"] = errrec.IfaceResult;
            //        //newGenDetail["INSPECTION_COMPLETE"] = errrec.Inspection_Complete;
            //        //newGenDetail["MAINTAINEDBY"] = errrec.MaintainedBy;
            //        //newGenDetail["MESSAGE"] = errrec.Message;
            //        //newGenDetail["OBJECTID"] = errrec.OBJECTID;
            //        //newGenDetail["OPERATIONALSTATUS"] = errrec.OperationalStatus;
            //        //if (errrec.Out_of_Service_Date.Year == 1)
            //        //{
            //        //    newGenDetail["OUT_OF_SERVICE_DATE"] = DBNull.Value;
            //        //}
            //        //else
            //        //{
            //        //    newGenDetail["OUT_OF_SERVICE_DATE"] = errrec.Out_of_Service_Date;
            //        //}

            //        //newGenDetail["PROBLEM1"] = errrec.Problem1;
            //        //newGenDetail["PROBLEM2"] = errrec.Problem2;
            //        //newGenDetail["PROBLEM3"] = errrec.Problem3;
            //        //newGenDetail["PROBLEM4"] = errrec.Problem4;
            //        //newGenDetail["SHIFT"] = errrec.Shift;
            //        //newGenDetail["UNIT_COMPLETING_INSPECTION"] = errrec.Unit_Completing_Inspection;
            //        //newGenDetail["UNITID"] = errrec.UnitID;
            //        //newGenDetail["WWW_ID"] = errrec.WWW_ID;


            //        dsDetails.Tables[0].Rows.Clear();
            //        dsDetails.Tables[0].Rows.Add(newGenDetail);
            //        //res = GenDetails.AddDetailRecords("InforClient.AWU_BarCodeIface.ERRAUSBARCODE", dsDetails);
            //        res = GenDetails.AddDetailRecords("InforClient.AWU_AFD.Afd2IPSLog", dsDetails);
            //        if (res.IsSuccess)
            //        {
            //        }
            //        else
            //        {
            //            ErrorLog Error = new ErrorLog();
            //            Error.Message = "Error Writing Log out to DB.  Error [" + res.Message + "]";
            //            WriteLogLineItemFile(Error );
            //        }
            //    }
            //    else
            //    {
            //        ErrorLog Error = new ErrorLog();
            //        Error.Message = "Error Loading Data Structure Log out to DB.  Error ["+res.Message+"]";
            //        WriteLogLineItemFile(Error );
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ErrorLog crit = new ErrorLog();
            //    crit.Message = "Critical Error Writing Out DB Log "+ex.Message;
            //    WriteLogLineItemFile(crit );
            //}
            //finally
            //{
            //}
        }

        void WriteOutThreadLogDB()
        {
            /*  if we are doing threading,  this will do the dump of hte q.  default to 10 items.
             *  this is for db logs.  not sure what we will do with this
             */
            string ld = string.Empty;
            string a = string.Empty;
            try
            {
                while (threading)
                {
                    if (LogEntrieQDB.Count > QSize)
                    {
                        lock (LogEntrieQDB)
                        {
                            while (LogEntrieQDB.Count > 0)
                            {
                                ErrorLog el = new ErrorLog();
                                el = (ErrorLog)LogEntrieQDB.Dequeue();

                                if (el != null)
                                {
                                    WriteOutErrorLogs(el);
                                }
                                //LogEntrieQ.Dequeue();
                            }
                        }
                    }
                    Thread.Sleep(SleepTime);
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Console.WriteLine(" ");
                Console.WriteLine("Critical Error in DB Log " + a + " --- " + ex.Message);
                //Console.ReadLine();
                string err2 = ld;
            }
        }


        #endregion

        #region "SystemLogs"
        public void WriteH8SystemLog(ErrorLog el)
        {
            // this is for sending items to the system  logs

            // WebServiceResult res = new WebServiceResult();
            // Hansen.Core.SystemLog syslog = new Hansen.Core.SystemLog();
            // Hansen.Core.WebServices.SystemLogService syslogWS = new Hansen.Core.WebServices.SystemLogService();
            // Hansen.Core.SystemLogMessage syslogMsg = new Hansen.Core.SystemLogMessage();
            // Hansen.Core.WebServices.SystemLogMessageService syslogMsgWS = new Hansen.Core.WebServices.SystemLogMessageService();

            // syslogMsgWS.Ticket = ticket;
            // syslogWS.Ticket = ticket;

            // try
            // {
            //     syslogMsg.Message = el.Message;
            //     res = syslogMsgWS.Add (ref syslogMsg);
            //     if (res.IsSuccess )
            //     {
            //         syslog.Code = 8000;
            //         syslog.LogType = "Applet"; // need to maintain as a global variable
            //         syslog.Severity = el.ifResult.ToString();
            //         syslog.Source = "h82sl_service"; // Interface Name
            //         syslog.SystemLogMessage = Convert.ToInt32(syslogMsg.SystemLogMessageKey);
            //         syslog.ShortMessage = (el.Message.Length >300?el.Message.Substring(0,300):el.Message );

            //         res = syslogWS.Add(ref syslog);
            //         if (res.IsSuccess )
            //         {

            //         }
            //         else
            //         {

            //         }

            //     }
            //     else
            //     {
            //         ErrorLog sysmsg = new ErrorLog();
            //         sysmsg.Message = "Error Writing Out System Log Message" + res.Message;
            //         WriteLogLineItemFile(sysmsg);

            //     }
            // }
            // catch (Exception ex)
            // {
            //     ErrorLog crit = new ErrorLog();
            //     crit.Message = "Critical Error Writing Out System Log " + ex.Message;
            //     WriteLogLineItemFile(crit);
            // }
        }


        public void WriteH8SystemLogRest(ErrorLog el)
        {

            
            // this is for sending items to the system  logs using REST services

            // WebServiceResult res = new WebServiceResult();
            // Hansen.Core.SystemLog syslog = new Hansen.Core.SystemLog();
            // Hansen.Core.WebServices.SystemLogService syslogWS = new Hansen.Core.WebServices.SystemLogService();
            // Hansen.Core.SystemLogMessage syslogMsg = new Hansen.Core.SystemLogMessage();
            // Hansen.Core.WebServices.SystemLogMessageService syslogMsgWS = new Hansen.Core.WebServices.SystemLogMessageService();

            // syslogMsgWS.Ticket = ticket;
            // syslogWS.Ticket = ticket;

            // try
            // {
            //     syslogMsg.Message = el.Message;
            //     res = syslogMsgWS.Add(ref syslogMsg);
            //     if (res.IsSuccess)
            //     {
            //         syslog.Code = 8000;
            //         syslog.LogType = "Applet"; // need to maintain as a global variable
            //         syslog.Severity = el.ifResult.ToString();
            //         syslog.Source = "h82sl_service"; // Interface Name
            //         syslog.SystemLogMessage = Convert.ToInt32(syslogMsg.SystemLogMessageKey);
            //         syslog.ShortMessage = (el.Message.Length > 300 ? el.Message.Substring(0, 300) : el.Message);

            //         res = syslogWS.Add(ref syslog);
            //         if (res.IsSuccess)
            //         {

            //         }
            //         else
            //         {

            //         }

            //     }
            //     else
            //     {
            //         ErrorLog sysmsg = new ErrorLog();
            //         sysmsg.Message = "Error Writing Out System Log Message" + res.Message;
            //         WriteLogLineItemFile(sysmsg);

            //     }
            // }
            // catch (Exception ex)
            // {
            //     ErrorLog crit = new ErrorLog();
            //     crit.Message = "Critical Error Writing Out System Log " + ex.Message;
            //     WriteLogLineItemFile(crit);
            // }
            
        }


        public void WriteLogLineItem_System(ErrorLog el)
        {
            // this will either send log or q up the log for the thread
            /* kjj 4-7-2020  added if then to check to see if we have a ticket,  we are assuming that the ticket is valid if it is there
             */
            try
            {
                if (ticket.Length > 1)
                {
                    if (!threading)
                    {
                        WriteH8SystemLog(el);
                    }
                    else
                    {
                        lock (LogEntrieQSystem)
                        {
                            LogEntrieQSystem.Enqueue(el);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Critical Error in Log Adding Que File " + ex.Message);
                //Console.ReadLine();
            }
        }

        public void WriteOutThreadSSystemLog()
        {
            /*  if we are doing threading,  this will do the dump of hte q.  default to 10 items.
            *  this is for systemLogs 
            */

            string ld = string.Empty;
            string a = string.Empty;
            try
            {
                while (threading)
                {
                    if (LogEntrieQSystem.Count > QSize)
                    {
                        lock (LogEntrieQSystem)
                        {
                            while (LogEntrieQSystem.Count > 0)
                            {
                                ErrorLog el = new ErrorLog();
                                el = (ErrorLog)LogEntrieQSystem.Dequeue();

                                if (el != null)
                                {
                                    WriteH8SystemLog(el);
                                }

                            }
                        }
                    }
                    Thread.Sleep(SleepTime);
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                Console.WriteLine(" ");
                Console.WriteLine("Critical Error in  File Log " + a + " --- " + ex.Message);
                //Console.ReadLine();
                string err2 = ld;
            }

        }

        public void RefreshTicket(string tk)
        {
            /* refresh the hansen ticket if using web services */
            ticket = tk;
        }

        #endregion

        public void StartThread()
        {
            threading = true;
            WriteOutLogsDB = new Thread(new ThreadStart(() => WriteOutThreadLogDB()));

            WriteOutLogsDB.Start();

            WriteOutLogsFIle = new Thread(new ThreadStart(() => WriteOutThreadLogFile()));

            WriteOutLogsFIle.Start();


            WriteOutLogsSystem = new Thread(new ThreadStart(() => WriteOutThreadSSystemLog()));

            WriteOutLogsSystem.Start();

        }

        public void CloseLogFile()
        {
            try
            {
                threading = false;
                // clean up the db log thread 
                if (ticket.Length > 1)
                {
                     //clean up system log
                    while (WriteOutLogsSystem.ThreadState == ThreadState.Running)
                    {
                        Thread.Sleep(100);
                    }

                    while (LogEntrieQSystem.Count > 0)
                    {
                        ErrorLog el = new ErrorLog();
                        el = (ErrorLog)LogEntrieQSystem.Dequeue();

                        if (el != null)
                        {
                            WriteH8SystemLog(el);
                        }
                    }
                }

                /* clean up the db logs, if any */
                while (WriteOutLogsDB.ThreadState == ThreadState.Running)
                {
                    Thread.Sleep(100);
                }

                while (LogEntrieQDB.Count > 0)
                {
                    ErrorLog el = new ErrorLog();
                    el = (ErrorLog)LogEntrieQDB.Dequeue();

                    if (el != null)
                    {
                        WriteOutErrorLogs(el);
                    }
                }

                if (FileCreated )
                {
                    // clean up log file thread
                    while (WriteOutLogsFIle.ThreadState == ThreadState.Running)
                    {
                        Thread.Sleep(100);
                    }

                    while (LogEntrieQFile.Count > 0)
                    {
                        ErrorLog el = new ErrorLog();
                        el = (ErrorLog)LogEntrieQFile.Dequeue();

                        if (el != null)
                        {
                            WriteXML_Log(el);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Critical Error Closing Logs " + ex.Message);
            }
            finally
            {
                threading = false;
                xmlfile.WriteEndElement();
                xmlfile.WriteEndDocument();
                xmlfile.Close();
            }

        }


    }  // end of class login
}
