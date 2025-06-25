/* this class file will hold all the stuff for interacting with Sql server
*/
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MTDataConversion
{

    
    public class DB_SQL
    {
        #pragma warning disable 618
        /* this class will hold all the code for pulling information
        */
        Dictionary<string,string> estopTables = new System.Collections.Generic.Dictionary<string,string>();
        ConfigFile dbcfg  = new ConfigFile();
        LogFile dblf = new LogFile();
        SqlConnection conn ;
        SqlConnection conn2 ;

#region privateMethods
        Boolean ConnectiToDB()
        {
            Boolean success = true;
            try
            {
                conn = new SqlConnection(dbcfg.DBConnectionString);
                conn.Open(); // opens the database connection
            }
            catch(Exception ex)
            {
                ErrorLog connecttodbError = new ErrorLog();
                connecttodbError.ifResult = ErrorLog.IfaceResult.FAIL;
                connecttodbError.Message = "Critical Error Connecting to DB.  Error ["+ex.Message+"]";
                dblf.WriteLogLineItemFile(connecttodbError);
                success = false;
            }
            finally
            {

            }


            return success;
        }

#endregion

#region publicMethods
        public Boolean CloseDB()
        {
            Boolean success = true;
            try
            {
                // conn = new SqlConnection(dbcfg.DBConnectionString);
                conn.Close(); // opens the database connection
            }
            catch(Exception ex)
            {
                ErrorLog connecttodbError = new ErrorLog();
                connecttodbError.ifResult = ErrorLog.IfaceResult.FAIL;
                connecttodbError.Message = "Critical Error Closing to DB.  Error ["+ex.Message+"]";
                dblf.WriteLogLineItemFile(connecttodbError);
                success = false;
            }
            finally
            {

            }


            return success;

        }
        public string RunSqlStatement(string sqlstatement,string tablename, string taskid)
        {
            string JSONString = string.Empty;
            Console.WriteLine("Entering RunsqlStatement "+tablename+" Task "+taskid+"  "+DateTime.Now.ToString());
            try
            {
                sqlstatement+= estopTables[tablename];
                
                SqlCommand command = new SqlCommand(sqlstatement, conn);
                // command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    JSONString = JsonConvert.SerializeObject(dataTable);

                    // while (reader.Read())
                    // {
                    //     Console.WriteLine(String.Format("{0}, {1}",
                    //     reader["InspectionId"], reader["InspectionId"]));// etc
                    // }
                }
                catch(Exception ex)
                {
                    ErrorLog dberr = new ErrorLog();
                    dberr.ifResult = ErrorLog.IfaceResult.FAIL;
                    dberr.Message = "Critical Error Running Sql Statement. Table Load SQL Statement ["+sqlstatement+"] ";
                    dberr.Message += " Error ["+ex.Message+"]";
                    dblf.WriteLogLineItemFile(dberr);

                    Console.WriteLine(dberr);
                }
            }
            catch(Exception ex)
            {
                ErrorLog dberr = new ErrorLog();
                dberr.ifResult = ErrorLog.IfaceResult.FAIL;
                dberr.Message = "Critical Error Running Sql Statement.  SQL Statement ["+sqlstatement+"] ";
                dberr.Message += " Error ["+ex.Message+"]";
                dblf.WriteLogLineItemFile(dberr);

                Console.WriteLine(dberr);
                JSONString = string.Empty;

            }
            finally
            {
                Console.WriteLine("Leaving RunsqlStatement "+tablename+" "+DateTime.Now.ToString());

            }

            return JSONString;
        }

        public async void ConvertDataToFile()
        {

            try
            {

                Task<int> task1 = Task.Run
                (
                    () =>
                    {

                        SqlCommand sqlCmd = new SqlCommand(dbcfg.AccelaDatabaseFilePathSQL, conn); 
                        sqlCmd.CommandTimeout = 300;
                        SqlDataReader reader = sqlCmd.ExecuteReader(); 
                        Console.WriteLine("");
                        int x =0;
                        while (reader.Read() )
                        {
                            Boolean NotGoodFileName = reader[dbcfg.AccelaDatabaseFilePathFileName].ToString().Contains('?');
                            if (!NotGoodFileName)
                            {
                                byte[] buffer = (byte[])reader[dbcfg.AccelaDatabaseFilePathContentCol];
                                string FilePath = dbcfg.AccelaDatabaseFilePath+"/"+reader[dbcfg.AccelaDatabaseFilePathFileName].ToString();
                                File.WriteAllBytes(FilePath, buffer);
                                if ((x % 100)==0) 
                                {
                                    Console.WriteLine("Document Number of FIles Processed "+x.ToString());
                                }
                                x++;
                            }
                        }

                        return 1;
                    }
                );

                Thread.Sleep(2000);

                Task<int> task2 = Task.Run
                (
                    () =>
                    {
                        conn2 = new SqlConnection(dbcfg.DBConnectionString);
                        conn2.Open(); // opens the database connection

                        SqlCommand sqlCmd2 = new SqlCommand(dbcfg.AccelaDatabaseFilePathSQL2, conn2); 
                        sqlCmd2.CommandTimeout = 300;
                        SqlDataReader reader2 = sqlCmd2.ExecuteReader(); 
                        Console.WriteLine("");
                        int y =0;
                        while (reader2.Read() )
                        {
                            Boolean NotGoodFileName2 = reader2[dbcfg.AccelaDatabaseFilePathFileName2].ToString().Contains('?');
                            if (!NotGoodFileName2)
                            {
                                byte[] buffer2 = (byte[])reader2[dbcfg.AccelaDatabaseFilePathContentCol2];
                                string FilePath2 = dbcfg.AccelaDatabaseFilePath+"/"+reader2[dbcfg.AccelaDatabaseFilePathFileName2].ToString();
                                File.WriteAllBytes(FilePath2, buffer2);
                                if ((y % 1500)==0) 
                                {
                                    Console.WriteLine("Attachment Number of FIles Processed "+y.ToString());
                                }
                                y++;
                            }

                        }
                        conn2.Close();
                        return 1;
                    }
                );

                while (task1.Status== TaskStatus.Running || task2.Status==TaskStatus.Running )
                {
                    Console.WriteLine("Task1 ["+task1.Status.ToString()+"] Task2 ["+task2.Status.ToString()+"] "+DateTime.Now.ToString());
                    Thread.Sleep(120000);
                }

                int res = await task1;
                res = await task2;


            }
            catch(Exception ex)
            {
                ErrorLog dberr = new ErrorLog();
                dberr.ifResult = ErrorLog.IfaceResult.FAIL;
                dberr.Message = "Critical Error Extracting File Attachments Sql Statement.  ";
                dberr.Message += " Error ["+ex.Message+"]";
                dblf.WriteLogLineItemFile(dberr);

                Console.WriteLine(dberr);

            }
            finally
            {

            }

        }
#endregion


        public DB_SQL(ConfigFile CFG, LogFile LF, ref Boolean success )
        {
            dbcfg = CFG;
            dblf = LF;
            success = true;

            estopTables.Add("Inspection","Inspection");
            estopTables.Add("AgencyBill","AgencyBill");
            estopTables.Add("Users","Users");
            estopTables.Add("LocationDates","LocationDates");
            estopTables.Add("UsersInRoles","UsersInRoles");
            estopTables.Add("Location","Location");
            estopTables.Add("NurseryViolations","NurseryViolations");
            estopTables.Add("License","License");
            estopTables.Add("PrintBatchDetail","PrintBatchDetail");
            estopTables.Add("SabhrsTransactions","SabhrsTransactions");
            estopTables.Add("sysdiagrams","sysdiagrams");
            estopTables.Add("RoleEmail","RoleEmail");
            estopTables.Add("Fees","Fees");
            estopTables.Add("NurseryInspection","NurseryInspection");
            estopTables.Add("County","County");
            estopTables.Add("Roles","Roles");
            estopTables.Add("FoodEndorsement","FoodEndorsement");
            estopTables.Add("NurseryInspectionBilling","NurseryInspectionBilling");
            estopTables.Add("Document","Document");


            estopTables.Add("NurseryControlledSales","NurseryControlledSales");
            estopTables.Add("NurserySample","NurserySample");
            estopTables.Add("SabhrsTreasuryWire","SabhrsTreasuryWire");
            estopTables.Add("LocationDetailXRef","LocationDetailXRef");
            estopTables.Add("DocumentType","DocumentType");
            estopTables.Add("aspnet_EntityPasscode","aspnet_EntityPasscode");
            estopTables.Add("NurserySupplier","NurserySupplier");
            estopTables.Add("PageSecurity","PageSecurity");

            estopTables.Add("SabhrsReversalInfo","SabhrsReversalInfo");
            estopTables.Add("NurseryPlantsInspected","NurseryPlantsInspected");
            estopTables.Add("NurseryNoxiousWeed","NurseryNoxiousWeed");
            estopTables.Add("Payment","Payment");
            estopTables.Add("Holidays","Holidays");
            estopTables.Add("PrintBatch","PrintBatch");
            estopTables.Add("Note","Note");
            estopTables.Add("Entity","Entity");
            estopTables.Add("NurseryBlackRustUsdaList","NurseryBlackRustUsdaList");
            estopTables.Add("Batch","Batch");
            estopTables.Add("People","People");
            estopTables.Add("SabhrsFeeInfo","SabhrsFeeInfo");
            estopTables.Add("Attachment","Attachment");
            estopTables.Add("NurseryQuarantine","NurseryQuarantine");
            estopTables.Add("AttachmentSecurity","AttachmentSecurity");
            estopTables.Add("LicensePaymentStatus","LicensePaymentStatus");
            estopTables.Add("Machine","Machine");
            estopTables.Add("ReportParameter","ReportParameter");
            estopTables.Add("ReportCategory","ReportCategory");
            estopTables.Add("Report","Report");
            estopTables.Add("ReportGroup","ReportGroup");
            estopTables.Add("LocationTransactionDetail","LocationTransactionDetail");
            estopTables.Add("ProcessStatus","ProcessStatus");
            estopTables.Add("LocationTransaction","LocationTransaction");
            estopTables.Add("LocationBalance","LocationBalance");
            estopTables.Add("PeopleLocations","PeopleLocations");
            estopTables.Add("PaymentDetails","PaymentDetails");
            estopTables.Add("Parms","Parms");
            estopTables.Add("PrintApprovalHold","PrintApprovalHold");

            success = ConnectiToDB();

        }
    }
}