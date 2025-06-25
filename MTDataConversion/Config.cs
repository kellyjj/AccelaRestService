using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using System.Reflection;
using System.Configuration;
using System.Dynamic;

namespace MTDataConversion
{
    public  class ConfigFile
    {
        //string _FTP_dir;

        public string AccelaRestServiceAuthURL {get; set;}           // accela restservices url
        public string AccelaServrovider { get; set; }       // accela wev services data provider
        public string Accela_UserName { get; set; }         // accela user name to logon w/ 
        public string Accela_Password { get; set; }         // accela user pwd to logon
        public string Accela_LogPath { get; set; }          // accela path where log file will be written
        public string Accela_clientID {get; set; }          // client id from accela dev portal, under my apps
        public string Accela_clientSecret {get; set; }      // client secret from accela dev portal, under my apps
        public string Accela_agencyname {get; set; }        // the accela agency name
        public string Accela_agencyEnviroment {get; set; }  // the intance.  TEST, SUPP, etc..
        public string Accela_scope {get; set; }             // the parts of accela we want access to
        public string Accela_granttype {get; set; }         // how are we authenticating
        public string Accela_AuthEndPoint {get; set;}
        public string AccelaRestServiceAPIBaseURL {get; set;}
        public string AccelaRestServiceGetRecordsEndPoint {get; set;}
        public string AccelaRestServiceGetSingleRecordEndPoint {get; set; }
        public string AccelaRestServiceCreateInspection {get; set;}
        public string AccelaRestServiceSchedulePendingInsp {get; set;}
        public string AccelaRestServiceSResultInsp {get; set;}
        public string AccelaDatabaseFilePath {get; set;}
        public string AccelaDatabaseFilePathSQL {get; set;}
        public string AccelaDatabaseFilePathSQL2 {get; set;}
        public string AccelaDatabaseFilePathContentCol2 {get; set;}
        public string AccelaDatabaseFilePathFileName2 {get;set;}
        public string TestBatchSize {get; set;}
        public string TestBatch {get; set;}
        public string GetAttachments {get; set;}
        public string AccelaDatabaseFilePathContentCol {get; set;}
        public string AccelaDatabaseFilePathFileName {get; set;}
        public string AccelaRestServiceSCreateRecordFees {get; set;}
        public string AccelaRestServiceSRecordAddress {get; set;}
        public string AccelaRestServiceSCreateUPdateRecordPeople {get; set;}
        public string AccelaRestServiceSGetFeeScedsApType {get; set;}
        public string AccelaRestServiceSCreateRecordInvoiceFees {get; set;}
        public string AccelaRestServiceContactCustomForms {get; set;}
        public string AccelaRestServiceSCreateRelatedRecords {get; set;}
        public string AccelaRestServiceSUpdateTask {get; set;}
        public string AccelaRestServiceGetUpdateRecordEndPoint {get; set;}
        public string GoLiveDate {get; set;}
        public string AccelaRestServiceSGetAllTasks {get; set;}
        public string SingleRecord {get; set;}
        public string SingleRecordNumber{get; set;}
        public string PaymentJsonFile {get; set;}
        public string BaseSqlwhere {get; set;}
        public string CacheTimeout {get; set;}

        /* these are for specifically this code. */
        public string SleepTime { get; set; }           // number of Seconds to sleep if we  have nothing to do
        public string Stop_File { get; set; }           // if this file exists, the program stops running
        public string StartProcessDate { get; set; }       // the date we will use to process items anything before this won't be dealt with
        public string DBConnectionString{ get; set; } 
        public string BaseSql{ get; set; } 
        public string SessionTimeOut{ get; set; } 
        public string AccelaRestServiceCreateRecordEndPoint {get; set;}
        public string NumberOfThreads {get; set;}
        public string AccelaRestServiceUpdateCustomFormsEndPoint {get; set;}

  
        private string CfgFileName = String.Empty;   // the file name of the config file


        public void LoadWebConfig()
        {
            /* lets pull stuff from web.config */
            Type thetype = typeof(ConfigFile);
            PropertyInfo[] BaseStringInfo = thetype.GetProperties();
            string name = string.Empty;
            string t = string.Empty;

            foreach (PropertyInfo pi in BaseStringInfo)
            {
                //pi.SetValue(this, ConfigurationManager.AppSettings[pi.Name]);
            }

        }

        public void LoadConfigFile(string path)
        {
            CfgFileName = path;
            string childname = string.Empty;
            
            try
            {

                /* load in the configuration.  email, urls, etc....*/
                if (File.Exists(path))
                {
                    try
                    {
                        //
                        //Read in the settings from the settings xml file. 
                        XmlDocument doc = new XmlDocument();
                        doc.Load(path);
                        XmlNode HanNode = doc.SelectSingleNode("//Hansen");
                        if (HanNode != null)
                        {
                            Type thetype = typeof(ConfigFile);

                            foreach (XmlNode child in HanNode.ChildNodes)
                            {

                                if (child.Name != "#comment")
                                {
                                    childname= child.Name;
                                    PropertyInfo pi = thetype.GetProperty(child.Name);
                                    pi.SetValue(this, child.InnerText);
                                }
                            }//end foreach

                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Critical Error Loading Config File : " + ex.Message+" "+childname);

                    }
                }
                else
                {
                    Console.WriteLine("Error Loading Config File : File Does Not Exist");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Loading Config File : File Does Not Exist "+ex.Message);
            }
        }

        void SetDefaultValues()
        {
            /* this sets all the default values.  using reflection */
            Type thetype = typeof(ConfigFile);
            PropertyInfo[] BaseStringInfo = thetype.GetProperties();

            foreach (PropertyInfo pi in BaseStringInfo)
            {
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

        public ConfigFile()
        {
            SetDefaultValues();
        }
    } //
}
