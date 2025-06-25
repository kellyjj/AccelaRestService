namespace MTDataConversion;

class Program
{
    static void Main(string[] args)
    {
        /* kelly jaramillo gray quarter 12-18-2024.  This is the data conversion for Montana EStop data conversion into Accela
        */
        ConfigFile CFG = new ConfigFile();
        CFG.LoadConfigFile("MTDataConvConfig.xml");

        LogFile LOG = new LogFile();
        LOG.CreateLogFile(CFG.Accela_LogPath,"",1,false);
        LOG.StartThread();

        try
        {
        
            Boolean success = true;
            ErrorLog mainLog = new ErrorLog();

            mainLog.ifResult = ErrorLog.IfaceResult.INFO;
            mainLog.Message = "Data Conversion Starting "+DateTime.Now.ToString();
            LOG.WriteLogLineItemFile(mainLog);
            
            AccelaRestServiceCls ars = new  AccelaRestServiceCls(CFG,LOG);

            /*  this is the array used for dividing up the work amongst hte threads
            */
            AccelaRecordsRoot[] accelaobjs = new  AccelaRecordsRoot[Convert.ToInt32(CFG.NumberOfThreads)];
            for (int x = 0;x<Convert.ToInt32(CFG.NumberOfThreads);x++)
            {
                accelaobjs[x] = new AccelaRecordsRoot();
            }

            DateTime myDate = DateTime.Parse("2025-04-30");
            /* this is the object that will hold and handle the legacy data.  A way to making this more generic so in 
                future conversions there will be less re-work
            */
            MTData mtconv = new MTData(CFG,LOG,ref success);
            
            DB_SQL estopdb = new DB_SQL(CFG,LOG,ref success);
            if (success)
            {
                mainLog.ifResult = ErrorLog.IfaceResult.SUCCESS;
                mainLog.Message = "Success Connecting To DataBase ";
                LOG.WriteLogLineItemFile(mainLog);
                Console.WriteLine(mainLog.Message);
                Console.WriteLine("Start of DataFile "+DateTime.Now.ToString());

                if (CFG.GetAttachments=="1")
                {
                    estopdb.ConvertDataToFile();
                    Console.WriteLine("End of DataFile "+DateTime.Now.ToString());
                }
                else 
                {
                    /*  main code snippet for conversion.  This is where we load client data, filter it into the appropiate classes, 
                        and then push into accela through the rest services
                    */
                    mtconv.BuildoutLists(estopdb);

                    // estopdb.CloseDB();
                    mtconv.BuildAccelaLists(ref accelaobjs);
                    ars.restMtData = mtconv;

                    ars.CreateRecord(accelaobjs);
                    // ars.CreateRelatedRecs();

                }

            }
            else 
            {
                mainLog.ifResult = ErrorLog.IfaceResult.FAIL;
                mainLog.Message = "Error Connecting To DataBase ";
                LOG.WriteLogLineItemFile(mainLog);
                Console.WriteLine(mainLog.Message);
            }

        }
        catch(Exception ex)
        {
            ErrorLog CritErr = new ErrorLog();
            CritErr.ifResult = ErrorLog.IfaceResult.FAIL;
            CritErr.Message = "Critical Error Running Data Conversion ["+ex.Message+"]";
            LOG.WriteLogLineItemFile(CritErr);
        }
        finally
        {
            ErrorLog finallog = new ErrorLog();
            finallog.ifResult = ErrorLog.IfaceResult.INFO;
            finallog.Message = "Conversion Done Running "+DateTime.Now.ToString();
            Console.WriteLine(finallog.Message);
            LOG.WriteLogLineItemFile(finallog);

            LOG.CloseLogFile();
        }


        // Console.ReadLine();
    }
}
