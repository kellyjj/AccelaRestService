/* this class file will hold all the stuff for interacting with Sql server
*/
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Globalization;

namespace MTDataConversion
{
#region estopclasses
    public class Inspections
    {
        int? _InspectionId ;
        int? _LicenseNumber ;
        int? _LicenseTypeId ;
        int? _LicenseSubTypeId ;
        string _InspectionDate ;
        int? _Accepted ;
        string _Who ;
        int? _NotTested ;
        int? _Rejected ;
        DateTime? _When ;

        
        public int? InspectionId 
        { 
            get
            {
                return _InspectionId;
            }  
            set 
            {
                if (value!=null)
                {
                    _InspectionId=value;
                }
                else 
                {
                    _InspectionId=0;
                }
            } 
        }
        public int? LicenseNumber 
        { 
            get
            {
                return _LicenseNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _LicenseNumber=value;
                }
                else 
                {
                    _LicenseNumber=0;
                }
            } 
        }
        public int? LicenseTypeId 
        { 
            get
            {
                return _LicenseTypeId;
            }  
            set 
            {
                if (value!=null)
                {
                    _LicenseTypeId=value;
                }
                else 
                {
                    _LicenseTypeId=0;
                }
            } 
        }
        public int? LicenseSubTypeId 
        { 
            get
            {
                return _LicenseSubTypeId;
            }  
            set 
            {
                if (value!=null)
                {
                    _LicenseSubTypeId=value;
                }
                else 
                {
                    _LicenseSubTypeId=0;
                }
            } 
        }
        public string InspectionDate 
        { 
            get 
            {
                return _InspectionDate; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _InspectionDate = string.Empty;
                }
                else 
                {
                    _InspectionDate = value;
                }
            }
        }
        public int? Accepted 
        { 
            get
            {
                return _Accepted;
            }  
            set 
            {
                if (value!=null)
                {
                    _Accepted=value;
                }
                else 
                {
                    _Accepted=0;
                }
            } 
        }
        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }

        public DateTime? When 
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }

            }
            
        }
        public int? NotTested 
        { 
            get
            {
                return _NotTested;
            }  
            set 
            {
                if (value!=null)
                {
                    _NotTested=value;
                }
                else 
                {
                    _NotTested=0;
                }
            } 
        }
        public int? Rejected 
        { 
            get
            {
                return _Rejected;
            }  
            set 
            {
                if (value!=null)
                {
                    _Rejected=value;
                }
                else 
                {
                    _Rejected=0;
                }
            } 
        }

        public Inspections()
        {
            
        }
    }

    public class AgencyBill
    {
        int? _LocationNumber ;
        int? _LicenseNumber ;
        string _LicenseType ;
        string _RenewalPeriod; 
        string _BillDate ;
        string _Who ;
        DateTime? _When;

        public int? LocationNumber 
        {
            get
            {
                return _LocationNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _LocationNumber=value;
                }
                else 
                {
                    _LocationNumber=0;
                }
            } 
        }

        public int? LicenseNumber 
        {
            get
            {
                return _LicenseNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _LicenseNumber=value;
                }
                else 
                {
                    _LicenseNumber=0;
                }
            } 
        }

        public string LicenseType 
        {
            get 
            {
                return _LicenseType; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _LicenseType = string.Empty;
                }
                else 
                {
                    _LicenseType = value;
                }
            }
        }

        public string RenewalPeriod 
        {
            get 
            {
                return _RenewalPeriod; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _RenewalPeriod = string.Empty;
                }
                else 
                {
                    _RenewalPeriod = value;
                }
            }
        }
        public string BillDate 
        {
            get 
            {
                return _BillDate; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _BillDate = string.Empty;
                }
                else 
                {
                    _BillDate = value;
                }
            }
        }
        public string Who 
        {
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }
        public DateTime? When 
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }
            }
        }

    }

    public class Users
    {
        string _UserName;
        string _FullName ;

        public string UserName 
        {
            get 
            {
                return _UserName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _UserName = string.Empty;
                }
                else 
                {
                    _UserName = value;
                }
            }
        }

        public string FullName 
        {
            get 
            {
                return _FullName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _FullName = string.Empty;
                }
                else 
                {
                    _FullName = value;
                }
            }
        }

    }

    public class LocationDates
    {
        int? _LocationDateId ;
        int? _LocationNumber ;
        string _RenewalPrintDate ;
        string _LicensePrintDate ;
        string _LicenseExpirationDate ;
        bool? _NeedsBillPrinted ;
        bool? _LicensePrintApproved ;
        int? _Ver ;
        bool? _IsCurrentVersion ;
        string _Who ;
        DateTime? _Commence;
        DateTime? _Cease;
        DateTime? _When;
        public int? LocationDateId 
        {
            get
            {
                return _LocationDateId;
            }  
            set 
            {
                if (value!=null)
                {
                    _LocationDateId=value;
                }
                else 
                {
                    _LocationDateId=0;
                }
            } 
        }

        public int? LocationNumber 
        {
            get
            {
                return _LocationNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _LocationNumber=value;
                }
                else 
                {
                    _LocationNumber=0;
                }
            } 
        }

        public string RenewalPrintDate 
        { 
            get 
            {
                return _RenewalPrintDate; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _RenewalPrintDate = string.Empty;
                }
                else 
                {
                    _RenewalPrintDate = value;
                }
            }
        }

        public string LicensePrintDate 
        { 
            get 
            {
                return _LicensePrintDate; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _LicensePrintDate = string.Empty;
                }
                else 
                {
                    _LicensePrintDate = value;
                }
            }
        }

        public string LicenseExpirationDate 
        { 
            get 
            {
                return _LicenseExpirationDate; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _LicenseExpirationDate = string.Empty;
                }
                else 
                {
                    _LicenseExpirationDate = value;
                }
            }
        }

        public bool? NeedsBillPrinted 
        { 
            get 
            {
                return _NeedsBillPrinted; 
            } 
            set
            {
                if (value==null)
                {
                    _NeedsBillPrinted = false;
                }
                else 
                {
                    _NeedsBillPrinted = value;
                }
            }
        }
        public bool? LicensePrintApproved 
        { 
            get 
            {
                return _LicensePrintApproved; 
            } 
            set
            {
                if (value==null)
                {
                    _LicensePrintApproved = false;
                }
                else 
                {
                    _LicensePrintApproved = value;
                }
            }
        }

        public int? Ver 
        {
            get
            {
                return _Ver;
            }  
            set 
            {
                if (value!=null)
                {
                    _Ver=value;
                }
                else 
                {
                    _Ver=0;
                }
            } 
        }

        public bool? IsCurrentVersion 
        { 
            get 
            {
                return _IsCurrentVersion; 
            } 
            set
            {
                if (value==null)
                {
                    _IsCurrentVersion = false;
                }
                else 
                {
                    _IsCurrentVersion = value;
                }
            }
        }

        public DateTime? Commence 
        {
            get 
            {
                return _Commence; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Commence=value;
                }
                else 
                {
                    _Commence=DateTime.MinValue;
                }

            }
            
        }
        public DateTime? Cease 
        {
            get 
            {
                return _Cease; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Cease=value;
                }
                else 
                {
                    _Cease=DateTime.MinValue;
                }

            }
            
        }

        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }

        public DateTime? When 
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }

            }
            
        }
        
    }

    public class UsersInRoles
    {
        string _UserName { get; set; }
        string _RoleName { get; set; }
        string _ApplicationName { get; set; }
        string _AddedBy { get; set; }
        DateTime? _DateAdded;

        public string UserName 
        { 
            get 
            {
                return _UserName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _UserName = string.Empty;
                }
                else 
                {
                    _UserName = value;
                }
            }
        }

        public string RoleName 
        { 
            get 
            {
                return _RoleName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _RoleName = string.Empty;
                }
                else 
                {
                    _RoleName = value;
                }
            }
        }

        public string ApplicationName 
        { 
            get 
            {
                return _ApplicationName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _ApplicationName = string.Empty;
                }
                else 
                {
                    _ApplicationName = value;
                }
            }
        }

        public string AddedBy 
        { 
            get 
            {
                return _AddedBy; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _AddedBy = string.Empty;
                }
                else 
                {
                    _AddedBy = value;
                }
            }
        }

        public DateTime? DateAdded 
        {
            get 
            {
                return _DateAdded; 
            } 
            set 
            {
                if (value!=null)
                {
                    _DateAdded=value;
                }
                else 
                {
                    _DateAdded=DateTime.MinValue;
                }

            }
            
        }
        
    }

    public class Location
    {
        int? _LocationId ;
        int? _LocationNumber ;
        int? _EntityNumber ;
        string _LocationName ;
        bool? _IsActive ;
        string _StatusDate ;
        string _Address1 ;
        string _Address2 ;
        string _City ;
        string _State ;
        string _ZipCode ;
        string _ZipCodePlus4 ;
        int? _CountyId ;
        string _CertificationDate ;
        string _PhoneNumber ;
        int? _Ver ;
        bool? _IsCurrentVersion ;
        string _Who ;
        string _DateApplicationReceived ;
        DateTime? _Commence;
        DateTime? _Cease;
        DateTime? _When;
        
        public int? LocationId 
        {
            get
            {
                return _LocationId;
            }  
            set 
            {
                if (value!=null)
                {
                    _LocationId=value;
                }
                else 
                {
                    _LocationId=0;
                }
            } 
        }

        public int? LocationNumber 
        {
            get
            {
                return _LocationNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _LocationNumber=value;
                }
                else 
                {
                    _LocationNumber=0;
                }
            } 
        }

        public int? EntityNumber 
        {
            get
            {
                return _EntityNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _EntityNumber=value;
                }
                else 
                {
                    _EntityNumber=0;
                }
            } 
        }

        public string LocationName 
        { 
            get 
            {
                return _LocationName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _LocationName = string.Empty;
                }
                else 
                {
                    _LocationName = value;
                }
            }
        }

        public bool? IsActive 
        { 
            get 
            {
                return _IsActive; 
            } 
            set
            {
                if (value==null)
                {
                    _IsActive = false;
                }
                else 
                {
                    _IsActive = value;
                }
            }
        }

        public string StatusDate 
        { 
            get 
            {
                return _StatusDate; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _StatusDate = string.Empty;
                }
                else 
                {
                    _StatusDate = value;
                }
            }
        }

        public string Address2 
        { 
            get 
            {
                return _Address2; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Address2 = string.Empty;
                }
                else 
                {
                    _Address2 = value;
                }
            }
        }

        public string Address1 
        { 
            get 
            {
                return _Address1; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Address1 = string.Empty;
                }
                else 
                {
                    _Address1 = value;
                }
            }
        }

        public string City 
        { 
            get 
            {
                return _City; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _City = string.Empty;
                }
                else 
                {
                    _City = value;
                }
            }
        }

        public string State 
        { 
            get 
            {
                return _State; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _State = string.Empty;
                }
                else 
                {
                    _State = value;
                }
            }
        }

        public string ZipCode 
        { 
            get 
            {
                return _ZipCode; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _ZipCode = string.Empty;
                }
                else 
                {
                    _ZipCode = value;
                }
            }
        }

        public string ZipCodePlus4 
        { 
            get 
            {
                return _ZipCodePlus4; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _ZipCodePlus4 = string.Empty;
                }
                else 
                {
                    _ZipCodePlus4 = value;
                }
            }
        }

        public int? CountyId 
        {
            get
            {
                return _CountyId;
            }  
            set 
            {
                if (value!=null)
                {
                    _CountyId=value;
                }
                else 
                {
                    _CountyId=0;
                }
            } 
        }

        public string CertificationDate 
        { 
            get 
            {
                return _CertificationDate; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _CertificationDate = string.Empty;
                }
                else 
                {
                    _CertificationDate = value;
                }
            }
        }

        public string PhoneNumber 
        { 
            get 
            {
                return _PhoneNumber; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _PhoneNumber = string.Empty;
                }
                else 
                {
                    _PhoneNumber = value;
                }
            }
        }

        public int? Ver 
        {
            get
            {
                return _Ver;
            }  
            set 
            {
                if (value!=null)
                {
                    _Ver=value;
                }
                else 
                {
                    _Ver=0;
                }
            } 
        }
        public bool? IsCurrentVersion 
        { 
            get 
            {
                return _IsCurrentVersion; 
            } 
            set
            {
                if (value==null)
                {
                    _IsCurrentVersion = false;
                }
                else 
                {
                    _IsCurrentVersion = value;
                }
            }
        }
        public DateTime? Commence 
        {
            get 
            {
                return _Commence; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Commence=value;
                }
                else 
                {
                    _Commence=DateTime.MinValue;
                }

            }
            
        }
     
        public DateTime? Cease 
        {
            get 
            {
                return _Cease; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Cease=value;
                }
                else 
                {
                    _Cease=DateTime.MinValue;
                }

            }
            
        }
        
        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }

        public DateTime? When 
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }

            }
            
        }
        
        public string DateApplicationReceived 
        { 
            get 
            {
                return _DateApplicationReceived; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _DateApplicationReceived = string.Empty;
                }
                else 
                {
                    _DateApplicationReceived = value;
                }
            }
        }

    }

    public class NurseryViolations
    {
        int? _InspectionId ;
        int? _ViolationId ;


        public int? InspectionId 
        {
            get
            {
                return _InspectionId;
            }  
            set 
            {
                if (value!=null)
                {
                    _InspectionId=value;
                }
                else 
                {
                    _InspectionId=0;
                }
            } 
        }

        public int? ViolationId 
        {
            get
            {
                return _ViolationId;
            }  
            set 
            {
                if (value!=null)
                {
                    _ViolationId=value;
                }
                else 
                {
                    _ViolationId=0;
                }
            } 
        }

    }

    public class License
    {
        #region fields
        int? _LicenseId ;
        int? _LocationNumber ;
        int? _LicenseNumber ;
        int? _LicenseTypeId ;
        int? _LicenseSubTypeId ;
        int? _Count ;
        int? _StatusId ;
        string _StatusDate ;
        int? _Ver ;
        bool? _IsCurrentVersion ;
        string _Who ;
        string _RiskCategory;
        string _SpecialRestrictions;

        DateTime? _Commence;
        DateTime? _Cease;
        DateTime? _When;
        #endregion
        public int? LicenseId 
        {
            get
            {
                return _LicenseId;
            }  
            set 
            {
                if (value!=null)
                {
                    _LicenseId=value;
                }
                else 
                {
                    _LicenseId=0;
                }
            } 
        }

        public int? LocationNumber 
        {
            get
            {
                return _LocationNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _LocationNumber=value;
                }
                else 
                {
                    _LocationNumber=0;
                }
            } 
        }

        public int? LicenseNumber 
        {
            get
            {
                return _LicenseNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _LicenseNumber=value;
                }
                else 
                {
                    _LicenseNumber=0;
                }
            } 
        }

        public int? LicenseTypeId 
        {
            get
            {
                return _LicenseTypeId;
            }  
            set 
            {
                if (value!=null)
                {
                    _LicenseTypeId=value;
                }
                else 
                {
                    _LicenseTypeId=0;
                }
            } 
        }

        public int? LicenseSubTypeId 
        {
            get
            {
                return _LicenseSubTypeId;
            }  
            set 
            {
                if (value!=null)
                {
                    _LicenseSubTypeId=value;
                }
                else 
                {
                    _LicenseSubTypeId=0;
                }
            } 
        }

        public int? Count 
        {
            get
            {
                return _Count;
            }  
            set 
            {
                if (value!=null)
                {
                    _Count=value;
                }
                else 
                {
                    _Count=0;
                }
            } 
        }

        public int? StatusId 
        {
            get
            {
                return _StatusId;
            }  
            set 
            {
                if (value!=null)
                {
                    _StatusId=value;
                }
                else 
                {
                    _StatusId=0;
                }
            } 
        }

        public string StatusDate 
        { 
            get 
            {
                return _StatusDate; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _StatusDate = string.Empty;
                }
                else 
                {
                    _StatusDate = value;
                }
            }
        }

        public string RiskCategory 
        { 
            get 
            {
                return _RiskCategory; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _RiskCategory = string.Empty;
                }
                else 
                {
                    _RiskCategory = value;
                }
            }
        }
        public string SpecialRestrictions 
        { 
            get 
            {
                return _SpecialRestrictions; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _SpecialRestrictions = string.Empty;
                }
                else 
                {
                    _SpecialRestrictions = value;
                }
            }
        }


        public int? Ver 
        {
            get
            {
                return _Ver;
            }  
            set 
            {
                if (value!=null)
                {
                    _Ver=value;
                }
                else 
                {
                    _Ver=0;
                }
            } 
        }

        public bool? IsCurrentVersion 
        { 
            get 
            {
                return _IsCurrentVersion; 
            } 
            set
            {
                if (value==null)
                {
                    _IsCurrentVersion = false;
                }
                else 
                {
                    _IsCurrentVersion = value;
                }
            }
        }

        public DateTime? Commence 
        {
            get 
            {
                return _Commence; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Commence=value;
                }
                else 
                {
                    _Commence=DateTime.MinValue;
                }

            }
            
        }

        public DateTime? Cease 
        {
            get 
            {
                return _Cease; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Cease=value;
                }
                else 
                {
                    _Cease=DateTime.MinValue;
                }

            }
            
        }
       
        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }

        public DateTime? When 
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }

            }
            
        }

    }

    public class PrintBatchDetail
    {
        int? _PrintDetailId { get; set; }
        int? _PrintBatchId { get; set; }
        string _LicenseExpirationDate { get; set; }
        int? _LocationNumber { get; set; }
        string _LocationName { get; set; }
        string _Locationaddress1 { get; set; }
        string _LocationCity { get; set; }
        string _LocationZipCode { get; set; }
        string _EntityName { get; set; }
        string _EntityAddress1 { get; set; }
        string _EntityAddress2 { get; set; }
        string _EntityCity { get; set; }
        string _EntityState { get; set; }
        string _EntityZipCode { get; set; }
        string _EntityZipCodePlus4 { get; set; }
        string _EntityCountry { get; set; }
        string _LicenseType { get; set; }
        int? _LicenseNumber { get; set; }
        string _LicenseNotes { get; set; }
        string _FeeDescription { get; set; }
        double? _ItemAmount { get; set; }
        double? _TotalAmount { get; set; }
        string _Who { get; set; }
        int? _EntityNumber { get; set; }
        DateTime? _When;

        public int? PrintDetailId 
        {
            get
            {
                return _PrintDetailId;
            }  
            set 
            {
                if (value!=null)
                {
                    _PrintDetailId=value;
                }
                else 
                {
                    _PrintDetailId=0;
                }
            } 
        }

        public int? PrintBatchId 
        {
            get
            {
                return _PrintBatchId;
            }  
            set 
            {
                if (value!=null)
                {
                    _PrintBatchId=value;
                }
                else 
                {
                    _PrintBatchId=0;
                }
            } 
        }

        public string LicenseExpirationDate { get; set; }
        public int? LocationNumber 
        {
            get
            {
                return _LocationNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _LocationNumber=value;
                }
                else 
                {
                    _LocationNumber=0;
                }
            } 
        }

        public string LocationName 
        { 
            get 
            {
                return _LocationName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _LocationName = string.Empty;
                }
                else 
                {
                    _LocationName = value;
                }
            }
        }

        public string Locationaddress1 
        { 
            get 
            {
                return _Locationaddress1; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Locationaddress1 = string.Empty;
                }
                else 
                {
                    _Locationaddress1 = value;
                }
            }
        }

        public string LocationCity 
        { 
            get 
            {
                return _LocationCity; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _LocationCity = string.Empty;
                }
                else 
                {
                    _LocationCity = value;
                }
            }
        }

        public string LocationZipCode 
        { 
            get 
            {
                return _LocationZipCode; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _LocationZipCode = string.Empty;
                }
                else 
                {
                    _LocationZipCode = value;
                }
            }
        }

        public string EntityName 
        { 
            get 
            {
                return _EntityName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _EntityName = string.Empty;
                }
                else 
                {
                    _EntityName = value;
                }
            }
        }

        public string EntityAddress1 
        { 
            get 
            {
                return _EntityAddress1; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _EntityAddress1 = string.Empty;
                }
                else 
                {
                    _EntityAddress1 = value;
                }
            }
        }

        public string EntityAddress2 
        { 
            get 
            {
                return _EntityAddress2; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _EntityAddress2 = string.Empty;
                }
                else 
                {
                    _EntityAddress2 = value;
                }
            }
        }

        public string EntityCity 
        { 
            get 
            {
                return _EntityCity; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _EntityCity = string.Empty;
                }
                else 
                {
                    _EntityCity = value;
                }
            }
        }

        public string EntityState 
        { 
            get 
            {
                return _EntityState; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _EntityState = string.Empty;
                }
                else 
                {
                    _EntityState = value;
                }
            }
        }

        public string EntityZipCode 
        { 
            get 
            {
                return _EntityZipCode; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _EntityZipCode = string.Empty;
                }
                else 
                {
                    _EntityZipCode = value;
                }
            }
        }

        public string EntityZipCodePlus4         
        { 
            get 
            {
                return _EntityZipCodePlus4; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _EntityZipCodePlus4 = string.Empty;
                }
                else 
                {
                    _EntityZipCodePlus4 = value;
                }
            }
        }

        public string EntityCountry 
        { 
            get 
            {
                return _EntityCountry; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _EntityCountry = string.Empty;
                }
                else 
                {
                    _EntityCountry = value;
                }
            }
        }

        public string LicenseType 
        { 
            get 
            {
                return _LicenseType; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _LicenseType = string.Empty;
                }
                else 
                {
                    _LicenseType = value;
                }
            }
        }

        public int? LicenseNumber 
        {
            get
            {
                return _LicenseNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _LicenseNumber=value;
                }
                else 
                {
                    _LicenseNumber=0;
                }
            } 
        }

        public string LicenseNotes 
        { 
            get 
            {
                return _LicenseNotes; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _LicenseNotes = string.Empty;
                }
                else 
                {
                    _LicenseNotes = value;
                }
            }
        }

        public string FeeDescription 
        { 
            get 
            {
                return _FeeDescription; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _FeeDescription = string.Empty;
                }
                else 
                {
                    _FeeDescription = value;
                }
            }
        }

        public double? ItemAmount 
        {
            get
            {
                return _ItemAmount;
            }  
            set 
            {
                if (value!=null)
                {
                    _ItemAmount=value;
                }
                else 
                {
                    _ItemAmount=0.0;
                }
            } 
        }

        public double? TotalAmount 
        {
            get
            {
                return _TotalAmount;
            }  
            set 
            {
                if (value!=null)
                {
                    _TotalAmount=value;
                }
                else 
                {
                    _TotalAmount=0.0;
                }
            } 
        }

        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }

        public DateTime? When 
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }

            }
            
        }
        
        public int? EntityNumber 
        {
            get
            {
                return _EntityNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _EntityNumber=value;
                }
                else 
                {
                    _EntityNumber=0;
                }
            } 
        }

    }

    public class SabhrsTransactions
    {
        int? _SabhrsTransId ;
        string _SabhrsType ;
        int? _LocationNumber ;
        string _BusinessUnit ;
        string _Account ;
        string _Fund ;
        string _Org ;
        int? _BudgetYear ;
        string _Subclass ;
        double? _Amount ;
        string _Reference ;
        string _Description ;
        int? _Ver ;
        bool? _IsCurrentVersion ;
        string _Who ;
        DateTime? _When;
        DateTime? _Commence;
        DateTime? _Cease;
        public int? SabhrsTransId 
        {
            get
            {
                return _SabhrsTransId;
            }  
            set 
            {
                if (value!=null)
                {
                    _SabhrsTransId=value;
                }
                else 
                {
                    _SabhrsTransId=0;
                }
            } 
        }


        public string SabhrsType 
        { 
            get 
            {
                return _SabhrsType; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _SabhrsType = string.Empty;
                }
                else 
                {
                    _SabhrsType = value;
                }
            }
        }

        public int? LocationNumber 
        {
            get
            {
                return _LocationNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _LocationNumber=value;
                }
                else 
                {
                    _LocationNumber=0;
                }
            } 
        }

        public string BusinessUnit 
        { 
            get 
            {
                return _BusinessUnit; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _BusinessUnit = string.Empty;
                }
                else 
                {
                    _BusinessUnit = value;
                }
            }
        }

        public string Account         
        { 
            get 
            {
                return _Account; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Account = string.Empty;
                }
                else 
                {
                    _Account = value;
                }
            }
        }

        public string Fund 
        { 
            get 
            {
                return _Fund; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Fund = string.Empty;
                }
                else 
                {
                    _Fund = value;
                }
            }
        }

        public string Org 
        { 
            get 
            {
                return _Org; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Org = string.Empty;
                }
                else 
                {
                    _Org = value;
                }
            }
        }

        public int? BudgetYear 
        {
            get
            {
                return _BudgetYear;
            }  
            set 
            {
                if (value!=null)
                {
                    _BudgetYear=value;
                }
                else 
                {
                    _BudgetYear=0;
                }
            } 
        }

        public string Subclass 
        { 
            get 
            {
                return _Subclass; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Subclass = string.Empty;
                }
                else 
                {
                    _Subclass = value;
                }
            }
        }

        public double? Amount 
        {
            get
            {
                return _Amount;
            }  
            set 
            {
                if (value!=null)
                {
                    _Amount=value;
                }
                else 
                {
                    _Amount=0;
                }
            } 
        }

        public string Reference 
        { 
            get 
            {
                return _Reference; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Reference = string.Empty;
                }
                else 
                {
                    _Reference = value;
                }
            }
        }

        public string Description 
        { 
            get 
            {
                return _Description; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Description = string.Empty;
                }
                else 
                {
                    _Description = value;
                }
            }
        }

        public int? Ver 
        {
            get
            {
                return _Ver;
            }  
            set 
            {
                if (value!=null)
                {
                    _Ver=value;
                }
                else 
                {
                    _Ver=0;
                }
            } 
        }

        public bool? IsCurrentVersion 
        { 
            get 
            {
                return _IsCurrentVersion; 
            } 
            set
            {
                if (value==null)
                {
                    _IsCurrentVersion = false;
                }
                else 
                {
                    _IsCurrentVersion = value;
                }
            }
        }

        public DateTime? Commence 
        {
            get 
            {
                return _Commence; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Commence=value;
                }
                else 
                {
                    _Commence=DateTime.MinValue;
                }

            }
            
        }
        
        public DateTime? Cease 
        {
            get 
            {
                return _Cease; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Cease=value;
                }
                else 
                {
                    _Cease=DateTime.MinValue;
                }

            }
            
        }
        
        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }

        public DateTime? When 
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }

            }
            
        }


    }

    public class RoleEmailCls
    {
        int? _RoleEmailId ;
        string _RoleName ;
        string _RoleEmail ;
        string _Who ;
        string _HowToUse ;
        DateTime? _Commence;


        public int? RoleEmailId 
        {
            get
            {
                return _RoleEmailId;
            }  
            set 
            {
                if (value!=null)
                {
                    _RoleEmailId=value;
                }
                else 
                {
                    _RoleEmailId=0;
                }
            } 
        }

        public string RoleName 
        { 
            get 
            {
                return _RoleName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _RoleName = string.Empty;
                }
                else 
                {
                    _RoleName = value;
                }
            }
        }

        public string RoleEmail 
        { 
            get 
            {
                return _RoleEmail; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _RoleEmail = string.Empty;
                }
                else 
                {
                    _RoleEmail = value;
                }
            }
        }

        public DateTime? Commence 
        {
            get 
            {
                return _Commence; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Commence=value;
                }
                else 
                {
                    _Commence=DateTime.MinValue;
                }

            }
            
        }

        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }

        public string HowToUse 
        { 
            get 
            {
                return _HowToUse; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _HowToUse = string.Empty;
                }
                else 
                {
                    _HowToUse = value;
                }
            }
        }

    }

    public class Fees
    {
        int? _FeeId { get; set; }
        int? _LicenseTypeId { get; set; }
        int? _LicenseSubTypeId { get; set; }
        double? _Amount { get; set; }
        string _FeeType { get; set; }
        string _Description { get; set; }
        int? _Ver { get; set; }
        bool? _IsCurrentVersion { get; set; }
        string _Who { get; set; }
        DateTime? _Commence;
        DateTime? _When;

        public int? FeeId 
        {
            get
            {
                return _FeeId;
            }  
            set 
            {
                if (value!=null)
                {
                    _FeeId=value;
                }
                else 
                {
                    _FeeId=0;
                }
            } 
        }

        public int? LicenseTypeId 
        {
            get
            {
                return _LicenseTypeId;
            }  
            set 
            {
                if (value!=null)
                {
                    _LicenseTypeId=value;
                }
                else 
                {
                    _LicenseTypeId=0;
                }
            } 
        }

        public int? LicenseSubTypeId 
        {
            get
            {
                return _LicenseSubTypeId;
            }  
            set 
            {
                if (value!=null)
                {
                    _LicenseSubTypeId=value;
                }
                else 
                {
                    _LicenseSubTypeId=0;
                }
            } 
        }

        public double? Amount 
        {
            get
            {
                return _Amount;
            }  
            set 
            {
                if (value!=null)
                {
                    _Amount=value;
                }
                else 
                {
                    _Amount=0;
                }
            } 
        }

        public string FeeType 
        { 
            get 
            {
                return _FeeType; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _FeeType = string.Empty;
                }
                else 
                {
                    _FeeType = value;
                }
            }
        }


        public string Description 
        { 
            get 
            {
                return _Description; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Description = string.Empty;
                }
                else 
                {
                    _Description = value;
                }
            }
        }

        public int? Ver 
        {
            get
            {
                return _Ver;
            }  
            set 
            {
                if (value!=null)
                {
                    _Ver=value;
                }
                else 
                {
                    _Ver=0;
                }
            } 
        }

        public bool? IsCurrentVersion 
        { 
            get 
            {
                return _IsCurrentVersion; 
            } 
            set
            {
                if (value==null)
                {
                    _IsCurrentVersion = false;
                }
                else 
                {
                    _IsCurrentVersion = value;
                }
            }
        }


        public DateTime? Commence 
        {
            get 
            {
                return _Commence; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Commence=value;
                }
                else 
                {
                    _Commence=DateTime.MinValue;
                }

            }
            
        }

        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }

        public DateTime? When 
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }

            }
            
        }


    }

    public class NurseryInspection
    {
        int? _InspectionId ;
        int? _LocationNumber ;
        int? _LicenseNumber ;
        bool?  _HasBotanicalName ;
        bool?  _HasCommonName ;
        bool?  _HasVariety ;
        bool?  _HasAccurateAge ;
        string _ArePlantsQuarantined ;
        string _LoadingDockArea ;
        string _AreSolidWoodPackingUsed ;
        string _PottingAreaSurface ;
        string _HasPasteurizedPottingMedia ;
        string _HasCleanPottingArea ;
        string _PottingContainerUsage ;
        string _IsWaterReused ;
        string _IsWaterFilteredBeforeReuse ;
        string _IsRunoffFilteredBeforeReuse ;
        string _StandingWater ;
        string _HasClearDrainageAreas ;
        string _HasCullCompostReused ;
        string _Notes ;
        string _NurseryDescriptionId;
        string _InspectionDate;
        bool?  _BillingConfirmed ;
        bool? _BillingApproved ;
        string _Activity;

        public string Activity 
        { 
            get 
            {
                return _Activity; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Activity = string.Empty;
                }
                else 
                {
                    _Activity = value;
                }
            }
        }

        public int? InspectionId 
        {
            get
            {
                return _InspectionId;
            }  
            set 
            {
                if (value!=null)
                {
                    _InspectionId=value;
                }
                else 
                {
                    _InspectionId=0;
                }
            } 
        }

        public int? LocationNumber 
        {
            get
            {
                return _LocationNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _LocationNumber=value;
                }
                else 
                {
                    _LocationNumber=0;
                }
            } 
        }

        public int? LicenseNumber 
        {
            get
            {
                return _LicenseNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _LicenseNumber=value;
                }
                else 
                {
                    _LicenseNumber=0;
                }
            } 
        }

        public bool? HasBotanicalName 
        { 
            get 
            {
                return _HasBotanicalName; 
            } 
            set
            {
                if (value==null)
                {
                    _HasBotanicalName = false;
                }
                else 
                {
                    _HasBotanicalName = value;
                }
            }
        }

        public bool? HasCommonName 
        { 
            get 
            {
                return _HasCommonName; 
            } 
            set
            {
                if (value==null)
                {
                    _HasCommonName = false;
                }
                else 
                {
                    _HasCommonName = value;
                }
            }
        }

        public bool? HasVariety 
        { 
            get 
            {
                return _HasVariety; 
            } 
            set
            {
                if (value==null)
                {
                    _HasVariety = false;
                }
                else 
                {
                    _HasVariety = value;
                }
            }
        }

        public bool? HasAccurateAge 
        { 
            get 
            {
                return _HasAccurateAge; 
            } 
            set
            {
                if (value==null)
                {
                    _HasAccurateAge = false;
                }
                else 
                {
                    _HasAccurateAge = value;
                }
            }
        }

        public string ArePlantsQuarantined 
        { 
            get 
            {
                return _ArePlantsQuarantined; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _ArePlantsQuarantined = string.Empty;
                }
                else 
                {
                    _ArePlantsQuarantined = value;
                }
            }
        }

        public string LoadingDockArea 
        { 
            get 
            {
                return _LoadingDockArea; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _LoadingDockArea = string.Empty;
                }
                else 
                {
                    _LoadingDockArea = value;
                }
            }
        }

        public string NurseryDescriptionId 
        { 
            get 
            {
                return _NurseryDescriptionId; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _NurseryDescriptionId = string.Empty;
                }
                else 
                {
                    _NurseryDescriptionId = value;
                }
            }
        }


        public string AreSolidWoodPackingUsed 
        { 
            get 
            {
                return _AreSolidWoodPackingUsed; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _AreSolidWoodPackingUsed = string.Empty;
                }
                else 
                {
                    _AreSolidWoodPackingUsed = value;
                }
            }
        }

        public string PottingAreaSurface 
        { 
            get 
            {
                return _PottingAreaSurface; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _PottingAreaSurface = string.Empty;
                }
                else 
                {
                    _PottingAreaSurface = value;
                }
            }
        }

        public string HasPasteurizedPottingMedia         
        { 
            get 
            {
                return _HasPasteurizedPottingMedia; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _HasPasteurizedPottingMedia = string.Empty;
                }
                else 
                {
                    _HasPasteurizedPottingMedia = value;
                }
            }
        }

        public string HasCleanPottingArea 
        { 
            get 
            {
                return _HasCleanPottingArea; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _HasCleanPottingArea = string.Empty;
                }
                else 
                {
                    _HasCleanPottingArea = value;
                }
            }
        }

        public string PottingContainerUsage 
        { 
            get 
            {
                return _PottingContainerUsage; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _PottingContainerUsage = string.Empty;
                }
                else 
                {
                    _PottingContainerUsage = value;
                }
            }
        }

        public string IsWaterReused 
        { 
            get 
            {
                return _IsWaterReused; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _IsWaterReused = string.Empty;
                }
                else 
                {
                    _IsWaterReused = value;
                }
            }
        }

        public string IsWaterFilteredBeforeReuse 
        { 
            get 
            {
                return _IsWaterFilteredBeforeReuse; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _IsWaterFilteredBeforeReuse = string.Empty;
                }
                else 
                {
                    _IsWaterFilteredBeforeReuse = value;
                }
            }
        }

        public string IsRunoffFilteredBeforeReuse 
        { 
            get 
            {
                return _IsRunoffFilteredBeforeReuse; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _IsRunoffFilteredBeforeReuse = string.Empty;
                }
                else 
                {
                    _IsRunoffFilteredBeforeReuse = value;
                }
            }
        }

        public string StandingWater 
        { 
            get 
            {
                return _StandingWater; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _StandingWater = string.Empty;
                }
                else 
                {
                    _StandingWater = value;
                }
            }
        }

        public string HasClearDrainageAreas 
        { 
            get 
            {
                return _HasClearDrainageAreas; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _HasClearDrainageAreas = string.Empty;
                }
                else 
                {
                    _HasClearDrainageAreas = value;
                }
            }
        }

        public string HasCullCompostReused 
        { 
            get 
            {
                return _HasCullCompostReused; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _HasCullCompostReused = string.Empty;
                }
                else 
                {
                    _HasCullCompostReused = value;
                }
            }
        }

        public string Notes 
        { 
            get 
            {
                return _Notes; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Notes = string.Empty;
                }
                else 
                {
                    _Notes = value;
                }
            }
        }

        public bool? BillingConfirmed 
        { 
            get 
            {
                return _BillingConfirmed; 
            } 
            set
            {
                if (value==null)
                {
                    _BillingConfirmed = false;
                }
                else 
                {
                    _BillingConfirmed = value;
                }
            }
        }

        public bool? BillingApproved 
        { 
            get 
            {
                return _BillingApproved; 
            } 
            set
            {
                if (value==null)
                {
                    _BillingApproved = false;
                }
                else 
                {
                    _BillingApproved = value;
                }
            }
        }

        public string InspectionDate 
        { 
            get 
            {
                return _InspectionDate; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _InspectionDate = string.Empty;
                }
                else 
                {
                    _InspectionDate = value;
                }
            }
        }

    }

    public class County
    {
        int? _CountyId ;
        string _CountyName ;
        string _CountySeat ;
        int? _AlphaOrder ;
        int? _GovCode ;
        string _AgDistrict ;
        int? _DliRegion ;

        public int? CountyId 
        {
            get
            {
                return _CountyId;
            }  
            set 
            {
                if (value!=null)
                {
                    _CountyId=value;
                }
                else 
                {
                    _CountyId=0;
                }
            } 
        }

        public string CountyName        
        { 
            get 
            {
                return _CountyName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _CountyName = string.Empty;
                }
                else 
                {
                    _CountyName = value;
                }
            }
        }

        public string CountySeat 
        { 
            get 
            {
                return _CountySeat; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _CountySeat = string.Empty;
                }
                else 
                {
                    _CountySeat = value;
                }
            }
        }

        public int? AlphaOrder 
        {
            get
            {
                return _AlphaOrder;
            }  
            set 
            {
                if (value!=null)
                {
                    _AlphaOrder=value;
                }
                else 
                {
                    _AlphaOrder=0;
                }
            } 
        }

        public int? GovCode 
        {
            get
            {
                return _GovCode;
            }  
            set 
            {
                if (value!=null)
                {
                    _GovCode=value;
                }
                else 
                {
                    _GovCode=0;
                }
            } 
        }


        public string AgDistrict 
        { 
            get 
            {
                return _AgDistrict; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _AgDistrict = string.Empty;
                }
                else 
                {
                    _AgDistrict = value;
                }
            }
        }

        public int? DliRegion 
        {
            get
            {
                return _DliRegion;
            }  
            set 
            {
                if (value!=null)
                {
                    _DliRegion=value;
                }
                else 
                {
                    _DliRegion=0;
                }
            } 
        }


    }


    public class Role
    {
        string _RoleName ;
        string _ApplicationName ;

        public string RoleName 
        { 
            get 
            {
                return _RoleName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _RoleName = string.Empty;
                }
                else 
                {
                    _RoleName = value;
                }
            }
        }

        public string ApplicationName 
        { 
            get 
            {
                return _ApplicationName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _ApplicationName = string.Empty;
                }
                else 
                {
                    _ApplicationName = value;
                }
            }
        }


    }

    public class FoodEndorsement
    {
        int? _FoodEndorsementId ;
        int? _LicenseNumber ;
        int? _EndorsementId ;
        string _Who ;
        DateTime? _When;
        DateTime? _Commence;
        DateTime? _Cease;

        public int? FoodEndorsementId 
        {
            get
            {
                return _FoodEndorsementId;
            }  
            set 
            {
                if (value!=null)
                {
                    _FoodEndorsementId=value;
                }
                else 
                {
                    _FoodEndorsementId=0;
                }
            } 
        }


        public int? LicenseNumber 
        {
            get
            {
                return _LicenseNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _LicenseNumber=value;
                }
                else 
                {
                    _LicenseNumber=0;
                }
            } 
        }

        public int? EndorsementId 
        {
            get
            {
                return _EndorsementId;
            }  
            set 
            {
                if (value!=null)
                {
                    _EndorsementId=value;
                }
                else 
                {
                    _EndorsementId=0;
                }
            } 
        }

        public DateTime? Commence 
        {
            get 
            {
                return _Commence; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Commence=value;
                }
                else 
                {
                    _Commence=DateTime.MinValue;
                }

            }
            
        }
        public DateTime? Cease 
        {
            get 
            {
                return _Cease; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Cease=value;
                }
                else 
                {
                    _Cease=DateTime.MinValue;
                }

            }
            
        }

        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }

        public DateTime? When 
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }

            }
            
        }


    }

    public class NurseryInspectionBilling
    {
        int? _InspectionId ;
        int? _FeeId ;
        int? _Quantity ;

        public int? InspectionId 
        {
            get
            {
                return _InspectionId;
            }  
            set 
            {
                if (value!=null)
                {
                    _InspectionId=value;
                }
                else 
                {
                    _InspectionId=0;
                }
            } 
        }

        public int? FeeId 
        {
            get
            {
                return _FeeId;
            }  
            set 
            {
                if (value!=null)
                {
                    _FeeId=value;
                }
                else 
                {
                    _FeeId=0;
                }
            } 
        }

        public int? Quantity 
        {
            get
            {
                return _Quantity;
            }  
            set 
            {
                if (value!=null)
                {
                    _Quantity=value;
                }
                else 
                {
                    _Quantity=0;
                }
            } 
        }


    }

    public class NurseryControlledSales
    {
        int? _SalesVarietyId ;
        int? _InspectionId ;
        string _SalesType ;
        int? _SpeciesId ;


        public int? SalesVarietyId 
        {
            get
            {
                return _SalesVarietyId;
            }  
            set 
            {
                if (value!=null)
                {
                    _SalesVarietyId=value;
                }
                else 
                {
                    _SalesVarietyId=0;
                }
            } 
        }

        public int? InspectionId
        {
            get
            {
                return _InspectionId;
            }  
            set 
            {
                if (value!=null)
                {
                    _InspectionId=value;
                }
                else 
                {
                    _InspectionId=0;
                }
            } 
        }
        public string SalesType 
        { 
            get 
            {
                return _SalesType; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _SalesType = string.Empty;
                }
                else 
                {
                    _SalesType = value;
                }
            }
        }

        public int? SpeciesId 
        {
            get
            {
                return _SpeciesId;
            }  
            set 
            {
                if (value!=null)
                {
                    _SpeciesId=value;
                }
                else 
                {
                    _SpeciesId=0;
                }
            } 
        }
        


    }

    public class NurserySample
    {
        int? _SampleId ;
        int? _InspectionId ;
        string _SampleType ;
        string _SentTo ;
        string _SampleResults ;
        string _Description ;

        public int? SampleId 
        {
            get
            {
                return _SampleId;
            }  
            set 
            {
                if (value!=null)
                {
                    _SampleId=value;
                }
                else 
                {
                    _SampleId=0;
                }
            } 
        }

        public int? InspectionId 
        {
            get
            {
                return _InspectionId;
            }  
            set 
            {
                if (value!=null)
                {
                    _InspectionId=value;
                }
                else 
                {
                    _InspectionId=0;
                }
            } 
        }

        public string SampleType 
        { 
            get 
            {
                return _SampleType; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _SampleType = string.Empty;
                }
                else 
                {
                    _SampleType = value;
                }
            }
        }

        public string SentTo 
        { 
            get 
            {
                return _SentTo; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _SentTo = string.Empty;
                }
                else 
                {
                    _SentTo = value;
                }
            }
        }

        public string SampleResults 
        { 
            get 
            {
                return _SampleResults; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _SampleResults = string.Empty;
                }
                else 
                {
                    _SampleResults = value;
                }
            }
        }

        public string Description 
        { 
            get 
            {
                return _Description; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Description = string.Empty;
                }
                else 
                {
                    _Description = value;
                }
            }
        }


    }

    public class SabhrsTreasuryWire
    {
        int? _SabhrsTreasuryWireId ;
        string _Business_Unit ;
        long? _Bank_Reference_N ;
        double? _Monetary_Amount ;
        string _Mt_Pay_Message_N ;
        bool? _BankReferenceUsed ;
        DateTime? _Trans_Date_N;
        DateTime? _DateInserted;

        public int? SabhrsTreasuryWireId 
        {
            get
            {
                return _SabhrsTreasuryWireId;
            }  
            set 
            {
                if (value!=null)
                {
                    _SabhrsTreasuryWireId=value;
                }
                else 
                {
                    _SabhrsTreasuryWireId=0;
                }
            } 
        }

        public DateTime? Trans_Date_N 
        {
            get 
            {
                return _Trans_Date_N; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Trans_Date_N=value;
                }
                else 
                {
                    _Trans_Date_N=DateTime.MinValue;
                }

            }
            
        }

        public string Business_Unit 
        { 
            get 
            {
                return _Business_Unit; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Business_Unit = string.Empty;
                }
                else 
                {
                    _Business_Unit = value;
                }
            }
        }


        public long? Bank_Reference_N 
        {
            get
            {
                return _Bank_Reference_N;
            }  
            set 
            {
                if (value!=null)
                {
                    _Bank_Reference_N=value;
                }
                else 
                {
                    _Bank_Reference_N=0;
                }
            } 
        }

        public double? Monetary_Amount 
        {
            get
            {
                return _Monetary_Amount;
            }  
            set 
            {
                if (value!=null)
                {
                    _Monetary_Amount=value;
                }
                else 
                {
                    _Monetary_Amount=0;
                }
            } 
        }

        public string Mt_Pay_Message_N 
        { 
            get 
            {
                return _Mt_Pay_Message_N; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Mt_Pay_Message_N = string.Empty;
                }
                else 
                {
                    _Mt_Pay_Message_N = value;
                }
            }
        }


        public DateTime? DateInserted 
        {
            get 
            {
                return _DateInserted; 
            } 
            set 
            {
                if (value!=null)
                {
                    _DateInserted=value;
                }
                else 
                {
                    _DateInserted=DateTime.MinValue;
                }

            }
            
        }

        public bool? BankReferenceUsed 
        { 
            get 
            {
                return _BankReferenceUsed; 
            } 
            set
            {
                if (value==null)
                {
                    _BankReferenceUsed = false;
                }
                else 
                {
                    _BankReferenceUsed = value;
                }
            }
        }



    }

    public class LocationDetailXRef
    {
        int? _TransactionDetailId ;
        int? _ReferenceId ;
        bool? _ReferenceIsDetail ;

        public int? TransactionDetailId 
        {
            get
            {
                return _TransactionDetailId;
            }  
            set 
            {
                if (value!=null)
                {
                    _TransactionDetailId=value;
                }
                else 
                {
                    _TransactionDetailId=0;
                }
            } 
        }

        public int? ReferenceId 
        {
            get
            {
                return _ReferenceId;
            }  
            set 
            {
                if (value!=null)
                {
                    _ReferenceId=value;
                }
                else 
                {
                    _ReferenceId=0;
                }
            } 
        }

        public bool? ReferenceIsDetail 
        { 
            get 
            {
                return _ReferenceIsDetail; 
            } 
            set
            {
                if (value==null)
                {
                    _ReferenceIsDetail = false;
                }
                else 
                {
                    _ReferenceIsDetail = value;
                }
            }
        }



    }

    public class DocumentType
    {
        string _DocumentTypeID ;
        public string DocumentTypeID 
        { 
            get 
            {
                return _DocumentTypeID; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _DocumentTypeID = string.Empty;
                }
                else 
                {
                    _DocumentTypeID = value;
                }
            }
        }

    }

    public class AspnetEntityPasscode
    {
        int? _EntityNumber ;
        string _Passcode ;

        public int? EntityNumber 
        {
            get
            {
                return _EntityNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _EntityNumber=value;
                }
                else 
                {
                    _EntityNumber=0;
                }
            } 
        }

        public string Passcode 
        { 
            get 
            {
                return _Passcode; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Passcode = string.Empty;
                }
                else 
                {
                    _Passcode = value;
                }
            }
        }


    }

    public class NurserySupplier
    {
        int? _SupplierId ;
        int? _InspectionId ;
        string _SupplierName ;
        string _SupplierLocation ;
        int? _BusinessNumber ;

        public int? SupplierId 
        {
            get
            {
                return _SupplierId;
            }  
            set 
            {
                if (value!=null)
                {
                    _SupplierId=value;
                }
                else 
                {
                    _SupplierId=0;
                }
            } 
        }

        public int? InspectionId 
        {
            get
            {
                return _InspectionId;
            }  
            set 
            {
                if (value!=null)
                {
                    _InspectionId=value;
                }
                else 
                {
                    _InspectionId=0;
                }
            } 
        }

        public string SupplierName 
        { 
            get 
            {
                return _SupplierName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _SupplierName = string.Empty;
                }
                else 
                {
                    _SupplierName = value;
                }
            }
        }

        public string SupplierLocation 
        { 
            get 
            {
                return _SupplierLocation; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _SupplierLocation = string.Empty;
                }
                else 
                {
                    _SupplierLocation = value;
                }
            }
        }

        public int? BusinessNumber 
        {
            get
            {
                return _BusinessNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _BusinessNumber=value;
                }
                else 
                {
                    _BusinessNumber=0;
                }
            } 
        }

    }

    public class PageSecurity
    {
        string _PageFileName ;
        string _ApplicationName ;
        public string PageFileName 
        { 
            get 
            {
                return _PageFileName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _PageFileName = string.Empty;
                }
                else 
                {
                    _PageFileName = value;
                }
            }
        }

        public string ApplicationName         
        { 
            get 
            {
                return _ApplicationName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _ApplicationName = string.Empty;
                }
                else 
                {
                    _ApplicationName = value;
                }
            }
        }
    }

    public class SabhrsReversalInfo
    {
        string _ReversalType { get; set; }
        string _Description { get; set; }
        string _BusinessUnit { get; set; }
        string _Account { get; set; }
        string _Fund { get; set; }
        string _Subclass { get; set; }
        int? _Ver { get; set; }
        bool? _IsCurrentVersion { get; set; }
        string _Who { get; set; }
        DateTime? _Commence;
        DateTime? _When;

        public string ReversalType 
        { 
            get 
            {
                return _ReversalType; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _ReversalType = string.Empty;
                }
                else 
                {
                    _ReversalType = value;
                }
            }
        }

        public string Description 
        { 
            get 
            {
                return _Description; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Description = string.Empty;
                }
                else 
                {
                    _Description = value;
                }
            }
        }

        public string BusinessUnit 
        { 
            get 
            {
                return _BusinessUnit; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _BusinessUnit = string.Empty;
                }
                else 
                {
                    _BusinessUnit = value;
                }
            }
        }

        public string Account 
        { 
            get 
            {
                return _Account; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Account = string.Empty;
                }
                else 
                {
                    _Account = value;
                }
            }
        }

        public string Fund 
        { 
            get 
            {
                return _Fund; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Fund = string.Empty;
                }
                else 
                {
                    _Fund = value;
                }
            }
        }

        public string Subclass 
        { 
            get 
            {
                return _Subclass; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Subclass = string.Empty;
                }
                else 
                {
                    _Subclass = value;
                }
            }
        }

        public int? Ver 
        {
            get
            {
                return _Ver;
            }  
            set 
            {
                if (value!=null)
                {
                    _Ver=value;
                }
                else 
                {
                    _Ver=0;
                }
            } 
        }

        public bool? IsCurrentVersion         
        { 
            get 
            {
                return _IsCurrentVersion; 
            } 
            set
            {
                if (value==null)
                {
                    _IsCurrentVersion = false;
                }
                else 
                {
                    _IsCurrentVersion = value;
                }
            }
        }

        public DateTime? Commence 
        {
            get 
            {
                return _Commence; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Commence=value;
                }
                else 
                {
                    _Commence=DateTime.MinValue;
                }

            }
            
        }

        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }
   
        public DateTime? When 
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }

            }
            
        }
    }

    public class NurseryPlantsInspected
    {
        int? _InspectionId ;
        int? _PlantMaterialId ;

        public int? InspectionId 
        {
            get
            {
                return _InspectionId;
            }  
            set 
            {
                if (value!=null)
                {
                    _InspectionId=value;
                }
                else 
                {
                    _InspectionId=0;
                }
            } 
        }

        public int? PlantMaterialId 
        {
            get
            {
                return _PlantMaterialId;
            }  
            set 
            {
                if (value!=null)
                {
                    _PlantMaterialId=value;
                }
                else 
                {
                    _PlantMaterialId=0;
                }
            } 
        }


    }

    public class NurseryNoxiousWeed
    {
        int? _WeedId ;
        string _ScientificName ;
        string _CommonName ;

        public int? WeedId 
        {
            get
            {
                return _WeedId;
            }  
            set 
            {
                if (value!=null)
                {
                    _WeedId=value;
                }
                else 
                {
                    _WeedId=0;
                }
            } 
        }

        public string ScientificName 
        { 
            get 
            {
                return _ScientificName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _ScientificName = string.Empty;
                }
                else 
                {
                    _ScientificName = value;
                }
            }
        }

        public string CommonName 
        { 
            get 
            {
                return _CommonName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _CommonName = string.Empty;
                }
                else 
                {
                    _CommonName = value;
                }
            }
        }



    }

    public class Payment
    {
        int? _PaymentId { get; set; }
        string _BatchNumber { get; set; }
        string _SabhrsType { get; set; }
        string _RoutingNumber { get; set; }
        string _AccountNumber { get; set; }
        string _CheckNumber { get; set; }
        bool? _CanBeReversed { get; set; }
        string _Who { get; set; }
        DateTime? _When;

        public int? PaymentId 
        {
            get
            {
                return _PaymentId;
            }  
            set 
            {
                if (value!=null)
                {
                    _PaymentId=value;
                }
                else 
                {
                    _PaymentId=0;
                }
            } 
        }


        public string BatchNumber 
        { 
            get 
            {
                return _BatchNumber; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _BatchNumber = string.Empty;
                }
                else 
                {
                    _BatchNumber = value;
                }
            }
        }


        public string SabhrsType 
        { 
            get 
            {
                return _SabhrsType; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _SabhrsType = string.Empty;
                }
                else 
                {
                    _SabhrsType = value;
                }
            }
        }

        public string RoutingNumber 
        { 
            get 
            {
                return _RoutingNumber; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _RoutingNumber = string.Empty;
                }
                else 
                {
                    _RoutingNumber = value;
                }
            }
        }

        public string AccountNumber 
        { 
            get 
            {
                return _AccountNumber; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _AccountNumber = string.Empty;
                }
                else 
                {
                    _AccountNumber = value;
                }
            }
        }
        public string CheckNumber 
        { 
            get 
            {
                return _CheckNumber; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _CheckNumber = string.Empty;
                }
                else 
                {
                    _CheckNumber = value;
                }
            }
        }
        public bool? CanBeReversed 
        { 
            get 
            {
                return _CanBeReversed; 
            } 
            set
            {
                if (value==null)
                {
                    _CanBeReversed = false;
                }
                else 
                {
                    _CanBeReversed = value;
                }
            }
        }

        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }
        public DateTime? When 
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }

            }
            
        }


    }

    public class Holidays
    {
        DateTime? _HolidayDate { get; set; }
        public DateTime? HolidayDate
        {
            get 
            {
                return _HolidayDate; 
            } 
            set 
            {
                if (value!=null)
                {
                    _HolidayDate=value;
                }
                else 
                {
                    _HolidayDate=DateTime.MinValue;
                }

            }
            
        }

    }

    public class PrintBatch
    {
        int? _PrintbatchId ;
        string _PrintDate ;
        string _PrintType ;
        string _ReportFileName ;
        bool? _SentToPrint ;
        bool? _EBillBatch ;

        public int? PrintbatchId 
        {
            get
            {
                return _PrintbatchId;
            }  
            set 
            {
                if (value!=null)
                {
                    _PrintbatchId=value;
                }
                else 
                {
                    _PrintbatchId=0;
                }
            } 
        }

        public string PrintDate 
        { 
            get 
            {
                return _PrintDate; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _PrintDate = string.Empty;
                }
                else 
                {
                    _PrintDate = value;
                }
            }
        }

        public string PrintType 
        { 
            get 
            {
                return _PrintType; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _PrintType = string.Empty;
                }
                else 
                {
                    _PrintType = value;
                }
            }
        }

        public string ReportFileName 
        { 
            get 
            {
                return _ReportFileName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _ReportFileName = string.Empty;
                }
                else 
                {
                    _ReportFileName = value;
                }
            }
        }

        public bool? SentToPrint 
        { 
            get 
            {
                return _SentToPrint; 
            } 
            set
            {
                if (value==null)
                {
                    _SentToPrint = false;
                }
                else 
                {
                    _SentToPrint = value;
                }
            }
        }

        public bool? EBillBatch 
        { 
            get 
            {
                return _EBillBatch; 
            } 
            set
            {
                if (value==null)
                {
                    _EBillBatch = false;
                }
                else 
                {
                    _EBillBatch = value;
                }
            }
        }


    }

    public class Note
    {
        int? _NoteId ;
        int? _EntityNumber ;
        string _NoteText ;
        string _Who ;
        DateTime? _When;

        public int? NoteId 
        {
            get
            {
                return _NoteId;
            }  
            set 
            {
                if (value!=null)
                {
                    _NoteId=value;
                }
                else 
                {
                    _NoteId=0;
                }
            } 
        }


        public int? EntityNumber 
        {
            get
            {
                return _EntityNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _EntityNumber=value;
                }
                else 
                {
                    _EntityNumber=0;
                }
            } 
        }

        public string NoteText 
        { 
            get 
            {
                return _NoteText; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _NoteText = string.Empty;
                }
                else 
                {
                    _NoteText = value;
                }
            }
        }

        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }

        public DateTime? When
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }

            }
            
        }
    }


    public class Entity
    {
        int? _EntityId { get; set; }
        int? _EntityNumber { get; set; }
        string _EntityName { get; set; }
        string _Fein { get; set; }
        int? _EntityTypeId { get; set; }
        int? _LicenseExpirationMonth { get; set; }
        bool? _IsActive { get; set; }
        string _StatusDate { get; set; }
        string _Address1 { get; set; }
        string _City { get; set; }
        string _State { get; set; }
        string _ZipCode { get; set; }
        string _Country { get; set; }
        string _PhoneNumber { get; set; }
        string _FaxNumber { get; set; }
        int? _Ver { get; set; }
        bool? _IsCurrentVersion { get; set; }
        string _Who { get; set; }
        bool? _IsElectronicOnly { get; set; }
        DateTime? _When;
        DateTime? _Commence;
        DateTime? _Cease;

        public int? EntityId         
        {
            get
            {
                return _EntityId;
            }  
            set 
            {
                if (value!=null)
                {
                    _EntityId=value;
                }
                else 
                {
                    _EntityId=0;
                }
            } 
        }

        public int? EntityNumber 
        {
            get
            {
                return _EntityNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _EntityNumber=value;
                }
                else 
                {
                    _EntityNumber=0;
                }
            } 
        }

        public string EntityName 
        { 
            get 
            {
                return _EntityName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _EntityName = string.Empty;
                }
                else 
                {
                    _EntityName = value;
                }
            }
        }

        public string Fein 
        { 
            get 
            {
                return _Fein; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Fein = string.Empty;
                }
                else 
                {
                    _Fein = value;
                }
            }
        }

        public int? EntityTypeId 
        {
            get
            {
                return _EntityTypeId;
            }  
            set 
            {
                if (value!=null)
                {
                    _EntityTypeId=value;
                }
                else 
                {
                    _EntityTypeId=0;
                }
            } 
        }

        public int? LicenseExpirationMonth 
        {
            get
            {
                return _LicenseExpirationMonth;
            }  
            set 
            {
                if (value!=null)
                {
                    _LicenseExpirationMonth=value;
                }
                else 
                {
                    _LicenseExpirationMonth=0;
                }
            } 
        }

        public bool? IsActive 
        { 
            get 
            {
                return _IsActive; 
            } 
            set
            {
                if (value==null)
                {
                    _IsActive = false;
                }
                else 
                {
                    _IsActive = value;
                }
            }
        }


        public string StatusDate 
        { 
            get 
            {
                return _StatusDate; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _StatusDate = string.Empty;
                }
                else 
                {
                    _StatusDate = value;
                }
            }
        }


        public string Address1 
        { 
            get 
            {
                return _Address1; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Address1 = string.Empty;
                }
                else 
                {
                    _Address1 = value;
                }
            }
        }

        public string City 
        { 
            get 
            {
                return _City; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _City = string.Empty;
                }
                else 
                {
                    _City = value;
                }
            }
        }

        public string State 
        { 
            get 
            {
                return _State; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _State = string.Empty;
                }
                else 
                {
                    _State = value;
                }
            }
        }

        public string ZipCode 
        { 
            get 
            {
                return _ZipCode; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _ZipCode = string.Empty;
                }
                else 
                {
                    _ZipCode = value;
                }
            }
        }

        public string Country 
        { 
            get 
            {
                return _Country; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Country = string.Empty;
                }
                else 
                {
                    _Country = value;
                }
            }
        }

        public string PhoneNumber 
        { 
            get 
            {
                return _PhoneNumber; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _PhoneNumber = string.Empty;
                }
                else 
                {
                    _PhoneNumber = value;
                }
            }
        }

        public string FaxNumber 
        { 
            get 
            {
                return _FaxNumber; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _FaxNumber = string.Empty;
                }
                else 
                {
                    _FaxNumber = value;
                }
            }
        }

        public int? Ver 
        {
            get
            {
                return _Ver;
            }  
            set 
            {
                if (value!=null)
                {
                    _Ver=value;
                }
                else 
                {
                    _Ver=0;
                }
            } 
        }

        public bool? IsCurrentVersion 
        { 
            get 
            {
                return _IsCurrentVersion; 
            } 
            set
            {
                if (value==null)
                {
                    _IsCurrentVersion = false;
                }
                else 
                {
                    _IsCurrentVersion = value;
                }
            }
        }


        public DateTime? Commence 
        {
            get 
            {
                return _Commence; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Commence=value;
                }
                else 
                {
                    _Commence=DateTime.MinValue;
                }

            }
            
        }
        public DateTime? Cease 
        {
            get 
            {
                return _Cease; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Cease=value;
                }
                else 
                {
                    _Cease=DateTime.MinValue;
                }

            }
            
        }

        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }

        public DateTime? When 
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }

            }
            
        }
        public bool? IsElectronicOnly 
        { 
            get 
            {
                return _IsElectronicOnly; 
            } 
            set
            {
                if (value==null)
                {
                    _IsElectronicOnly = false;
                }
                else 
                {
                    _IsElectronicOnly = value;
                }
            }
        }



    }


    public class NurseryBlackRustUsdaList
    {
        int? _SpeciesId ;

        public int? SpeciesId 
        {
            get
            {
                return _SpeciesId;
            }  
            set 
            {
                if (value!=null)
                {
                    _SpeciesId=value;
                }
                else 
                {
                    _SpeciesId=0;
                }
            } 
        }


    }

    public class Batch
    {
        string _BatchNumber { get; set; }
        string _SabhrsType { get; set; }
        string _ReceivedDate { get; set; }
        double? _Amount { get; set; }
        int? _StatusId { get; set; }
        string _StatusDate { get; set; }
        int? _BatchTypeId { get; set; }
        int? _Ver { get; set; }
        public bool? _IsCurrentVersion { get; set; }
        
        string _Who { get; set; }
        DateTime? _Commence;
        DateTime? _When;

        public string BatchNumber 
        { 
            get 
            {
                return _BatchNumber; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _BatchNumber = string.Empty;
                }
                else 
                {
                    _BatchNumber = value;
                }
            }
        }


        public string SabhrsType 
        { 
            get 
            {
                return _SabhrsType; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _SabhrsType = string.Empty;
                }
                else 
                {
                    _SabhrsType = value;
                }
            }
        }

        public string ReceivedDate 
        { 
            get 
            {
                return _ReceivedDate; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _ReceivedDate = string.Empty;
                }
                else 
                {
                    _ReceivedDate = value;
                }
            }
        }

        public double? Amount 
        {
            get
            {
                return _Amount;
            }  
            set 
            {
                if (value!=null)
                {
                    _Amount=value;
                }
                else 
                {
                    _Amount=0;
                }
            } 
        }

        public int? StatusId 
        {
            get
            {
                return _StatusId;
            }  
            set 
            {
                if (value!=null)
                {
                    _StatusId=value;
                }
                else 
                {
                    _StatusId=0;
                }
            } 
        }

        public string StatusDate 
        { 
            get 
            {
                return _StatusDate; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _StatusDate = string.Empty;
                }
                else 
                {
                    _StatusDate = value;
                }
            }
        }

        public int? BatchTypeId 
        {
            get
            {
                return _BatchTypeId;
            }  
            set 
            {
                if (value!=null)
                {
                    _BatchTypeId=value;
                }
                else 
                {
                    _BatchTypeId=0;
                }
            } 
        }

        public int? Ver 
        {
            get
            {
                return _Ver;
            }  
            set 
            {
                if (value!=null)
                {
                    _Ver=value;
                }
                else 
                {
                    _Ver=0;
                }
            } 
        }

        public bool? IsCurrentVersion 
        { 
            get 
            {
                return _IsCurrentVersion; 
            } 
            set
            {
                if (value==null)
                {
                    _IsCurrentVersion = false;
                }
                else 
                {
                    _IsCurrentVersion = value;
                }
            }
        }

        public DateTime? Commence 
        {
            get 
            {
                return _Commence; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Commence=value;
                }
                else 
                {
                    _Commence=DateTime.MinValue;
                }

            }
            
        }
        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }


        public DateTime? When 
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }

            }
            
        }
    }


    public class Person
    {
        int? _PersonId ;
        string _FirstName ;
        string _PhoneNumber ;
        string _PhoneNumber2 ;
        string _FaxNumber ;
        string _EmailAddress ;
        string _LastName ;
        string _Who ;
        DateTime? _When;

        public int? PersonId 
        {
            get
            {
                return _PersonId;
            }  
            set 
            {
                if (value!=null)
                {
                    _PersonId=value;
                }
                else 
                {
                    _PersonId=0;
                }
            } 
        }

        public string FirstName 
        { 
            get 
            {
                return _FirstName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _FirstName = string.Empty;
                }
                else 
                {
                    _FirstName = value;
                }
            }
        }

        public string LastName 
        { 
            get 
            {
                return _LastName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _LastName = string.Empty;
                }
                else 
                {
                    _LastName = value;
                }
            }
        }

        public string PhoneNumber 
        { 
            get 
            {
                return _PhoneNumber; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _PhoneNumber = string.Empty;
                }
                else 
                {
                    _PhoneNumber = value;
                }
            }
        }
        public string PhoneNumber2 
        { 
            get 
            {
                return _PhoneNumber2; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _PhoneNumber2 = string.Empty;
                }
                else 
                {
                    _PhoneNumber2 = value;
                }
            }
        }

        public string FaxNumber 
        { 
            get 
            {
                return _FaxNumber; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _FaxNumber = string.Empty;
                }
                else 
                {
                    _FaxNumber = value;
                }
            }
        }

        public string EmailAddress 
        { 
            get 
            {
                return _EmailAddress; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _EmailAddress = string.Empty;
                }
                else 
                {
                    _EmailAddress = value;
                }
            }
        }

        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }

        public DateTime? When 
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }

            }
            
        }



    }

    public class SabhrsFeeInfo
    {
        int? _FeeId ;
        string _BusinessUnit ;
        string _Account ;
        string _Fund ;
        string _Org ;
        string _Subclass ;
        int? _Ver ;
        bool? _IsCurrentVersion ;
        string _Who;
        DateTime? _When;
        DateTime? _Commence;

        public int? FeeId 
        {
            get
            {
                return _FeeId;
            }  
            set 
            {
                if (value!=null)
                {
                    _FeeId=value;
                }
                else 
                {
                    _FeeId=0;
                }
            } 
        }

        public string BusinessUnit 
        { 
            get 
            {
                return _BusinessUnit; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _BusinessUnit = string.Empty;
                }
                else 
                {
                    _BusinessUnit = value;
                }
            }
        }

        public string Account 
        { 
            get 
            {
                return _Account; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Account = string.Empty;
                }
                else 
                {
                    _Account = value;
                }
            }
        }

        public string Fund 
        { 
            get 
            {
                return _Fund; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Fund = string.Empty;
                }
                else 
                {
                    _Fund = value;
                }
            }
        }

        public string Org 
        { 
            get 
            {
                return _Org; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Org = string.Empty;
                }
                else 
                {
                    _Org = value;
                }
            }
        }

        public string Subclass 
        { 
            get 
            {
                return _Subclass; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Subclass = string.Empty;
                }
                else 
                {
                    _Subclass = value;
                }
            }
        }

        public int? Ver 
        {
            get
            {
                return _Ver;
            }  
            set 
            {
                if (value!=null)
                {
                    _Ver=value;
                }
                else 
                {
                    _Ver=0;
                }
            } 
        }

        public bool? IsCurrentVersion 
        { 
            get 
            {
                return _IsCurrentVersion; 
            } 
            set
            {
                if (value==null)
                {
                    _IsCurrentVersion = false;
                }
                else 
                {
                    _IsCurrentVersion = value;
                }
            }
        }

        public DateTime? Commence 
        {
            get 
            {
                return _Commence; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Commence=value;
                }
                else 
                {
                    _Commence=DateTime.MinValue;
                }

            }
            
        }

        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }

        public DateTime? When 
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }

            }
            
        }



    }

    public class Attachment
    {
        int? _AttachmentId { get; set; }
        int? _LocationNumber { get; set; }
        int? _InspectionId { get; set; }
        string _FileName { get; set; }
        string _Description { get; set; }
        string _FileContents { get; set; }
        bool? _ContainsFein { get; set; }
        bool? _IsActive { get; set; }
        DateTime? _When;

        public int? AttachmentId 
        {
            get
            {
                return _AttachmentId;
            }  
            set 
            {
                if (value!=null)
                {
                    _AttachmentId=value;
                }
                else 
                {
                    _AttachmentId=0;
                }
            } 
        }

        public int? LocationNumber 
        {
            get
            {
                return _LocationNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _LocationNumber=value;
                }
                else 
                {
                    _LocationNumber=0;
                }
            } 
        }

        public int? InspectionId 
        {
            get
            {
                return _InspectionId;
            }  
            set 
            {
                if (value!=null)
                {
                    _InspectionId=value;
                }
                else 
                {
                    _InspectionId=0;
                }
            } 
        }

        public string FileName 
        { 
            get 
            {
                return _FileName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _FileName = string.Empty;
                }
                else 
                {
                    _FileName = value;
                }
            }
        }


        public string Description 
        { 
            get 
            {
                return _Description; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Description = string.Empty;
                }
                else 
                {
                    _Description = value;
                }
            }
        }

        public string FileContents         
        { 
            get 
            {
                return _FileContents; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _FileContents = string.Empty;
                }
                else 
                {
                    _FileContents = value;
                }
            }
        }

        public bool? ContainsFein 
        { 
            get 
            {
                return _ContainsFein; 
            } 
            set
            {
                if (value==null)
                {
                    _ContainsFein = false;
                }
                else 
                {
                    _ContainsFein = value;
                }
            }
        }


        public bool? IsActive 
        { 
            get 
            {
                return _IsActive; 
            } 
            set
            {
                if (value==null)
                {
                    _IsActive = false;
                }
                else 
                {
                    _IsActive = value;
                }
            }
        }

        public DateTime? When 
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }

            }
            
        }



    }

    public class NurseryQuarantine
    {
        int? _QuarantineId ;
        int? _InspectionId ;
        int? _SupplierId ;
        bool? _ProvidesSeedPotato ;
        bool? _ProvidesTomatoPlant ;
        bool? _ProvidesPinusSpp ;
        bool? _ProvidesContainerStock ;
        bool? _ProvidesRhododendron ;

        public int? QuarantineId 
        {
            get
            {
                return _QuarantineId;
            }  
            set 
            {
                if (value!=null)
                {
                    _QuarantineId=value;
                }
                else 
                {
                    _QuarantineId=0;
                }
            } 
        }

        public int? InspectionId 
        {
            get
            {
                return _InspectionId;
            }  
            set 
            {
                if (value!=null)
                {
                    _InspectionId=value;
                }
                else 
                {
                    _InspectionId=0;
                }
            } 
        }

        public int? SupplierId 
        {
            get
            {
                return _SupplierId;
            }  
            set 
            {
                if (value!=null)
                {
                    _SupplierId=value;
                }
                else 
                {
                    _SupplierId=0;
                }
            } 
        }

        public bool? ProvidesSeedPotato 
        { 
            get 
            {
                return _ProvidesSeedPotato; 
            } 
            set
            {
                if (value==null)
                {
                    _ProvidesSeedPotato = false;
                }
                else 
                {
                    _ProvidesSeedPotato = value;
                }
            }
        }

        public bool? ProvidesTomatoPlant 
        { 
            get 
            {
                return _ProvidesTomatoPlant; 
            } 
            set
            {
                if (value==null)
                {
                    _ProvidesTomatoPlant = false;
                }
                else 
                {
                    _ProvidesTomatoPlant = value;
                }
            }
        }

        public bool? ProvidesPinusSpp 
        { 
            get 
            {
                return _ProvidesPinusSpp; 
            } 
            set
            {
                if (value==null)
                {
                    _ProvidesPinusSpp = false;
                }
                else 
                {
                    _ProvidesPinusSpp = value;
                }
            }
        }

        public bool? ProvidesContainerStock 
        { 
            get 
            {
                return _ProvidesContainerStock; 
            } 
            set
            {
                if (value==null)
                {
                    _ProvidesContainerStock = false;
                }
                else 
                {
                    _ProvidesContainerStock = value;
                }
            }
        }

        public bool? ProvidesRhododendron 
        { 
            get 
            {
                return _ProvidesRhododendron; 
            } 
            set
            {
                if (value==null)
                {
                    _ProvidesRhododendron = false;
                }
                else 
                {
                    _ProvidesRhododendron = value;
                }
            }
        }

    }

    public class AttachmentSecurity
    {
        int? _AttachmentId ;
        string _RoleName ;
        string _Who ;

        public int? AttachmentId 
        {
            get
            {
                return _AttachmentId;
            }  
            set 
            {
                if (value!=null)
                {
                    _AttachmentId=value;
                }
                else 
                {
                    _AttachmentId=0;
                }
            } 
        }

        public string RoleName 
        { 
            get 
            {
                return _RoleName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _RoleName = string.Empty;
                }
                else 
                {
                    _RoleName = value;
                }
            }
        }

        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }


    }

    public class LicensePaymentStatus
    {
        int? _LicensePaymentStatusId { get; set; }
        int? _LocationNumber { get; set; }
        int? _LicenseNumber { get; set; }
        int? _LicenseTypeId { get; set; }
        int? _LicenseSubTypeId { get; set; }
        int? _PaymentStatusId { get; set; }
        int? _Ver { get; set; }
        bool? _IsCurrentVersion { get; set; }
        DateTime? _Commence { get; set; }
        DateTime? _Cease { get; set; }
        string _Who { get; set; }
        DateTime? _When { get; set; }

        public int? LicensePaymentStatusId 
        {
            get
            {
                return _LicensePaymentStatusId;
            }  
            set 
            {
                if (value!=null)
                {
                    _LicensePaymentStatusId=value;
                }
                else 
                {
                    _LicensePaymentStatusId=0;
                }
            } 
        }

        public int? LocationNumber 
        {
            get
            {
                return _LocationNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _LocationNumber=value;
                }
                else 
                {
                    _LocationNumber=0;
                }
            } 
        }

        public int? LicenseNumber 
        {
            get
            {
                return _LicenseNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _LicenseNumber=value;
                }
                else 
                {
                    _LicenseNumber=0;
                }
            } 
        }

        public int? LicenseTypeId 
        {
            get
            {
                return _LicenseTypeId;
            }  
            set 
            {
                if (value!=null)
                {
                    _LicenseTypeId=value;
                }
                else 
                {
                    _LicenseTypeId=0;
                }
            } 
        }

        public int? LicenseSubTypeId 
        {
            get
            {
                return _LicenseSubTypeId;
            }  
            set 
            {
                if (value!=null)
                {
                    _LicenseSubTypeId=value;
                }
                else 
                {
                    _LicenseSubTypeId=0;
                }
            } 
        }

        public int? PaymentStatusId 
        {
            get
            {
                return _PaymentStatusId;
            }  
            set 
            {
                if (value!=null)
                {
                    _PaymentStatusId=value;
                }
                else 
                {
                    _PaymentStatusId=0;
                }
            } 
        }

        public int? Ver 
        {
            get
            {
                return _Ver;
            }  
            set 
            {
                if (value!=null)
                {
                    _Ver=value;
                }
                else 
                {
                    _Ver=0;
                }
            } 
        }

        public bool? IsCurrentVersion 
        { 
            get 
            {
                return _IsCurrentVersion; 
            } 
            set
            {
                if (value==null)
                {
                    _IsCurrentVersion = false;
                }
                else 
                {
                    _IsCurrentVersion = value;
                }
            }
        }

        public DateTime? Commence 
        {
            get 
            {
                return _Commence; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Commence=value;
                }
                else 
                {
                    _Commence=DateTime.MinValue;
                }

            }
            
        }
        public DateTime? Cease 
        {
            get 
            {
                return _Cease; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Cease=value;
                }
                else 
                {
                    _Cease=DateTime.MinValue;
                }

            }
            
        }
   
        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }

        public DateTime? When 
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }

            }
            
        }
    }

    public class Machine
    {
        int? _MachineId { get; set; }
        int? _LocationNumber { get; set; }
        int? _MachineTypeId { get; set; }
        string _SerialNumber { get; set; }
        int? _RetailerLocationNumber { get; set; }
        bool? _IsActive { get; set; }
        string _StatusDate { get; set; }
        int? _Ver { get; set; }
        bool? _IsCurrentVersion { get; set; }
        string _Who { get; set; }
        DateTime? _When;
        DateTime? _Commence;
        DateTime? _Cease;

        public int? MachineId 
        {
            get
            {
                return _MachineId;
            }  
            set 
            {
                if (value!=null)
                {
                    _MachineId=value;
                }
                else 
                {
                    _MachineId=0;
                }
            } 
        }

        public int? LocationNumber 
        {
            get
            {
                return _LocationNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _LocationNumber=value;
                }
                else 
                {
                    _LocationNumber=0;
                }
            } 
        }

        public int? MachineTypeId 
        {
            get
            {
                return _MachineTypeId;
            }  
            set 
            {
                if (value!=null)
                {
                    _MachineTypeId=value;
                }
                else 
                {
                    _MachineTypeId=0;
                }
            } 
        }

        public string SerialNumber 
        { 
            get 
            {
                return _SerialNumber; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _SerialNumber = string.Empty;
                }
                else 
                {
                    _SerialNumber = value;
                }
            }
        }

        public int? RetailerLocationNumber 
        {
            get
            {
                return _RetailerLocationNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _RetailerLocationNumber=value;
                }
                else 
                {
                    _RetailerLocationNumber=0;
                }
            } 
        }

        public bool? IsActive 
        { 
            get 
            {
                return _IsActive; 
            } 
            set
            {
                if (value==null)
                {
                    _IsActive = false;
                }
                else 
                {
                    _IsActive = value;
                }
            }
        }

        public string StatusDate 
        { 
            get 
            {
                return _StatusDate; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _StatusDate = string.Empty;
                }
                else 
                {
                    _StatusDate = value;
                }
            }
        }

        public int? Ver 
        {
            get
            {
                return _Ver;
            }  
            set 
            {
                if (value!=null)
                {
                    _Ver=value;
                }
                else 
                {
                    _Ver=0;
                }
            } 
        }

        public bool? IsCurrentVersion 
        {   
            get 
            {
                return _IsCurrentVersion; 
            } 
            set
            {
                if (value==null)
                {
                    _IsCurrentVersion = false;
                }
                else 
                {
                    _IsCurrentVersion = value;
                }
            }
        }

        public DateTime? Commence 
        {
            get 
            {
                return _Commence; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Commence=value;
                }
                else 
                {
                    _Commence=DateTime.MinValue;
                }

            }
            
        }
        public DateTime? Cease 
        {
            get 
            {
                return _Cease; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Cease=value;
                }
                else 
                {
                    _Cease=DateTime.MinValue;
                }

            }
            
        }
        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }

        public DateTime? When 
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }

            }
            
        }

    }

    public class ReportParameter
    {
        int? _ReportParameterId ;
        int? _ReportId ;
        string _ParameterName ;
        string _ParameterPrompt ;
        string _ControlType ;
        string _SqlString ;
        bool? _Required ;
        string _DataType ;

        public int? ReportParameterId 
        {
            get
            {
                return _ReportParameterId;
            }  
            set 
            {
                if (value!=null)
                {
                    _ReportParameterId=value;
                }
                else 
                {
                    _ReportParameterId=0;
                }
            } 
        }

        public int? ReportId 
                {
            get
            {
                return _ReportId;
            }  
            set 
            {
                if (value!=null)
                {
                    _ReportId=value;
                }
                else 
                {
                    _ReportId=0;
                }
            } 
        }

        public string ParameterName 
        { 
            get 
            {
                return _ParameterName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _ParameterName = string.Empty;
                }
                else 
                {
                    _ParameterName = value;
                }
            }
        }

        public string ParameterPrompt 
        { 
            get 
            {
                return _ParameterPrompt; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _ParameterPrompt = string.Empty;
                }
                else 
                {
                    _ParameterPrompt = value;
                }
            }
        }

        public string ControlType 
        { 
            get 
            {
                return _ControlType; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _ControlType = string.Empty;
                }
                else 
                {
                    _ControlType = value;
                }
            }
        }

        public string SqlString 
        { 
            get 
            {
                return _SqlString; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _SqlString = string.Empty;
                }
                else 
                {
                    _SqlString = value;
                }
            }
        }

        public bool? Required 
        { 
            get 
            {
                return _Required; 
            } 
            set
            {
                if (value==null)
                {
                    _Required = false;
                }
                else 
                {
                    _Required = value;
                }
            }
        }

        public string DataType 
        { 
            get 
            {
                return _DataType; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _DataType = string.Empty;
                }
                else 
                {
                    _DataType = value;
                }
            }
        }


    }

    public class ReportCategory
    {
        int? _ReportCategoryId ;
        string _CategoryDescription ;

        public int? ReportCategoryId 
        {
            get
            {
                return _ReportCategoryId;
            }  
            set 
            {
                if (value!=null)
                {
                    _ReportCategoryId=value;
                }
                else 
                {
                    _ReportCategoryId=0;
                }
            } 
        }

        public string CategoryDescription 
        { 
            get 
            {
                return _CategoryDescription; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _CategoryDescription = string.Empty;
                }
                else 
                {
                    _CategoryDescription = value;
                }
            }
        }


    }


    public class Report
    {
        int? _ReportId ;
        int? _ReportCategoryId ;
        string _ReportName ;
        string _ReportDescription ;
        string _ReportFileName ;

        public int? ReportId 
        {
            get
            {
                return _ReportId;
            }  
            set 
            {
                if (value!=null)
                {
                    _ReportId=value;
                }
                else 
                {
                    _ReportId=0;
                }
            } 
        }

        public int? ReportCategoryId 
        {
            get
            {
                return _ReportCategoryId;
            }  
            set 
            {
                if (value!=null)
                {
                    _ReportCategoryId=value;
                }
                else 
                {
                    _ReportCategoryId=0;
                }
            } 
        }

        public string ReportName 
        { 
            get 
            {
                return _ReportName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _ReportName = string.Empty;
                }
                else 
                {
                    _ReportName = value;
                }
            }
        }

        public string ReportDescription 
        { 
            get 
            {
                return _ReportDescription; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _ReportDescription = string.Empty;
                }
                else 
                {
                    _ReportDescription = value;
                }
            }
        }

        public string ReportFileName 
        { 
            get 
            {
                return _ReportFileName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _ReportFileName = string.Empty;
                }
                else 
                {
                    _ReportFileName = value;
                }
            }
        }



    }

    public class ReportGroup
    {
        int? _ReportGroupId { get; set; }
        int? _ReportId { get; set; }
        string _RoleName { get; set; }

        public int? ReportGroupId 
        {
            get
            {
                return _ReportGroupId;
            }  
            set 
            {
                if (value!=null)
                {
                    _ReportGroupId=value;
                }
                else 
                {
                    _ReportGroupId=0;
                }
            } 
        }

        public int? ReportId 
        {
            get
            {
                return _ReportId;
            }  
            set 
            {
                if (value!=null)
                {
                    _ReportId=value;
                }
                else 
                {
                    _ReportId=0;
                }
            } 
        }

        public string RoleName 
        { 
            get 
            {
                return _RoleName; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _RoleName = string.Empty;
                }
                else 
                {
                    _RoleName = value;
                }
            }
        }


    }

    public class LocationTransactionDetail
    {
        int? _TransactionDetailId ;
        int? _TransactionId ;
        string _TransactionType ;
        double? _Amount ;
        int? _FeeId ;
        int? _Count ;
        bool? _Allocated ;
        string _RenewalPeriod ;
        int? _Ver ;
        bool? _IsCurrentVersion ;
        string _Who ;
        DateTime? _When;
        DateTime? _Commence;
        DateTime? _Cease;

        public int? TransactionDetailId 
        {
            get
            {
                return _TransactionDetailId;
            }  
            set 
            {
                if (value!=null)
                {
                    _TransactionDetailId=value;
                }
                else 
                {
                    _TransactionDetailId=0;
                }
            } 
        }

        public int? TransactionId 
        {
            get
            {
                return _TransactionId;
            }  
            set 
            {
                if (value!=null)
                {
                    _TransactionId=value;
                }
                else 
                {
                    _TransactionId=0;
                }
            } 
        }

        public string TransactionType 
               { 
            get 
            {
                return _TransactionType; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _TransactionType = string.Empty;
                }
                else 
                {
                    _TransactionType = value;
                }
            }
        }

        public double? Amount 
        {
            get
            {
                return _Amount;
            }  
            set 
            {
                if (value!=null)
                {
                    _Amount=value;
                }
                else 
                {
                    _Amount=0;
                }
            } 
        }

        
        public int? FeeId 
        {
            get
            {
                return _FeeId;
            }  
            set 
            {
                if (value!=null)
                {
                    _FeeId=value;
                }
                else 
                {
                    _FeeId=0;
                }
            } 
        }

        public int? Count 
        {
            get
            {
                return _Count;
            }  
            set 
            {
                if (value!=null)
                {
                    _Count=value;
                }
                else 
                {
                    _Count=0;
                }
            } 
        }

        public bool? Allocated 
        { 
            get 
            {
                return _Allocated; 
            } 
            set
            {
                if (value==null)
                {
                    _Allocated = false;
                }
                else 
                {
                    _Allocated = value;
                }
            }
        }

        public string RenewalPeriod 
        { 
            get 
            {
                return _RenewalPeriod; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _RenewalPeriod = string.Empty;
                }
                else 
                {
                    _RenewalPeriod = value;
                }
            }
        }

        public int? Ver 
        {
            get
            {
                return _Ver;
            }  
            set 
            {
                if (value!=null)
                {
                    _Ver=value;
                }
                else 
                {
                    _Ver=0;
                }
            } 
        }

        public bool? IsCurrentVersion 
        { 
            get 
            {
                return _IsCurrentVersion; 
            } 
            set
            {
                if (value==null)
                {
                    _IsCurrentVersion = false;
                }
                else 
                {
                    _IsCurrentVersion = value;
                }
            }
        }

        public DateTime? Commence 
        {
            get 
            {
                return _Commence; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Commence=value;
                }
                else 
                {
                    _Commence=DateTime.MinValue;
                }

            }
            
        }

        public DateTime? Cease 
        {
            get 
            {
                return _Cease; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Cease=value;
                }
                else 
                {
                    _Cease=DateTime.MinValue;
                }

            }
            
        }

        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }

        public DateTime? When 
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }

            }
            
        }

        public string GetAccelaFeeType(MTData mtdata,int? FeeId,LogFile lf)
        {
            string accelaFeeType = string.Empty;
            List<FEETYPE> thefeetypelist = new List<FEETYPE>();

            try
            {
                if (FeeId!=0)
                {
                    using (StreamReader file = File.OpenText("accelaFeeTypes.json"))
                    {
                        string jsonstring = file.ReadToEnd();
                        thefeetypelist = JsonConvert.DeserializeObject<List<FEETYPE>>(jsonstring);
                    }


                    FEETYPE ft = new FEETYPE();
                    ft = thefeetypelist.Find(x=>x.FeeId==FeeId);
                    if (ft!=null)
                    {
                        accelaFeeType = ft.AccelaFeeCode;
                    }
                    else  
                    {
                        ErrorLog dberr = new ErrorLog();
                        dberr.ifResult = ErrorLog.IfaceResult.FAIL;
                        dberr.Message = "GetAccelaFeeType No Feee Code Found  "+FeeId.ToString();
                        lf.WriteLogLineItemFile(dberr);
                    }

                }

            }
            catch(Exception ex)
            {
                //Console.WriteLine(ex.Message);
                ErrorLog dberr = new ErrorLog();
                dberr.ifResult = ErrorLog.IfaceResult.FAIL;
                dberr.Message = "Critical Error GetAccelaFeeType.  ";
                dberr.Message += " Error ["+ex.Message+"]";
                lf.WriteLogLineItemFile(dberr);

            }


            return accelaFeeType;
        }

    }


    public class ProcessStatus
    {
        int? _Month ;
        bool? _RenewalError ;
        bool? _DelinquentError ;
        DateTime? _RenewalLastRun;
        DateTime? _DelinquentLastRun;

        public int? Month 
        {
            get
            {
                return _Month;
            }  
            set 
            {
                if (value!=null)
                {
                    _Month=value;
                }
                else 
                {
                    _Month=0;
                }
            } 
        }

        public DateTime? RenewalLastRun 
        {
            get 
            {
                return _RenewalLastRun; 
            } 
            set 
            {
                if (value!=null)
                {
                    _RenewalLastRun=value;
                }
                else 
                {
                    _RenewalLastRun=DateTime.MinValue;
                }

            }
            
        }

        public bool? RenewalError 
        { 
            get 
            {
                return _RenewalError; 
            } 
            set
            {
                if (value==null)
                {
                    _RenewalError = false;
                }
                else 
                {
                    _RenewalError = value;
                }
            }
        }

        public DateTime? DelinquentLastRun 
        {
            get 
            {
                return _DelinquentLastRun; 
            } 
            set 
            {
                if (value!=null)
                {
                    _DelinquentLastRun=value;
                }
                else 
                {
                    _DelinquentLastRun=DateTime.MinValue;
                }

            }
            
        }

        public bool? DelinquentError 
        { 
            get 
            {
                return _DelinquentError; 
            } 
            set
            {
                if (value==null)
                {
                    _DelinquentError = false;
                }
                else 
                {
                    _DelinquentError = value;
                }
            }
        }


    }


    public class LocationTransaction
    {
        int? _TransactionId { get; set; }
        int? _LocationNumber { get; set; }
        string _TransactionType { get; set; }
        double? _Amount { get; set; }
        string _Process { get; set; }
        string _PaymentDetailId { get; set; }
        bool? _Allocated { get; set; }
        string _RenewalPeriod { get; set; }
        int? _Ver { get; set; }
        bool? _IsCurrentVersion { get; set; }
        string _Who { get; set; }
        DateTime? _When;
        DateTime? _Commence;

        public int? TransactionId 
        {
            get
            {
                return _TransactionId;
            }  
            set 
            {
                if (value!=null)
                {
                    _TransactionId=value;
                }
                else 
                {
                    _TransactionId=0;
                }
            } 
        }

        public int? LocationNumber 
        {
            get
            {
                return _LocationNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _LocationNumber=value;
                }
                else 
                {
                    _LocationNumber=0;
                }
            } 
        }

        public string TransactionType 
        { 
            get 
            {
                return _TransactionType; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _TransactionType = string.Empty;
                }
                else 
                {
                    _TransactionType = value;
                }
            }
        }

        public double? Amount 
        {
            get
            {
                return _Amount;
            }  
            set 
            {
                if (value!=null)
                {
                    _Amount=value;
                }
                else 
                {
                    _Amount=0;
                }
            } 
        }

        public string Process 
        { 
            get 
            {
                return _Process; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Process = string.Empty;
                }
                else 
                {
                    _Process = value;
                }
            }
        }

        public string PaymentDetailId 
        { 
            get 
            {
                return _PaymentDetailId; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _PaymentDetailId = string.Empty;
                }
                else 
                {
                    _PaymentDetailId = value;
                }
            }
        }

        public bool? Allocated 
        { 
            get 
            {
                return _Allocated; 
            } 
            set
            {
                if (value==null)
                {
                    _Allocated = false;
                }
                else 
                {
                    _Allocated = value;
                }
            }
        }

        public string RenewalPeriod 
        { 
            get 
            {
                return _RenewalPeriod; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _RenewalPeriod = string.Empty;
                }
                else 
                {
                    _RenewalPeriod = value;
                }
            }
        }

        public int? Ver 
        {
            get
            {
                return _Ver;
            }  
            set 
            {
                if (value!=null)
                {
                    _Ver=value;
                }
                else 
                {
                    _Ver=0;
                }
            } 
        }

        public bool? IsCurrentVersion 
        { 
            get 
            {
                return _IsCurrentVersion; 
            } 
            set
            {
                if (value==null)
                {
                    _IsCurrentVersion = false;
                }
                else 
                {
                    _IsCurrentVersion = value;
                }
            }
        }

        public DateTime? Commence 
        {
            get 
            {
                return _Commence; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Commence=value;
                }
                else 
                {
                    _Commence=DateTime.MinValue;
                }

            }
            
        }

        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }

        public DateTime? When 
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }

            }
            
        }
    }

    public class LocationBalance
    {
        int? _BalanceId ;
        int? _LocationNumber ;
        double? _Balance ;
        int? _Ver ;
        bool? _IsCurrentVersion ;
        string _Who ;
        DateTime? _When;
        DateTime? _Commence;
        DateTime? _Cease;

        public int? BalanceId 
        {
            get
            {
                return _BalanceId;
            }  
            set 
            {
                if (value!=null)
                {
                    _BalanceId=value;
                }
                else 
                {
                    _BalanceId=0;
                }
            } 
        }

        public int? LocationNumber 
        {
            get
            {
                return _LocationNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _LocationNumber=value;
                }
                else 
                {
                    _LocationNumber=0;
                }
            } 
        }

        public double? Balance 
        {
            get
            {
                return _Balance;
            }  
            set 
            {
                if (value!=null)
                {
                    _Balance=value;
                }
                else 
                {
                    _Balance=0;
                }
            } 
        }

        public int? Ver 
        {
            get
            {
                return _Ver;
            }  
            set 
            {
                if (value!=null)
                {
                    _Ver=value;
                }
                else 
                {
                    _Ver=0;
                }
            } 
        }

        public bool? IsCurrentVersion 
        { 
            get 
            {
                return _IsCurrentVersion; 
            } 
            set
            {
                if (value==null)
                {
                    _IsCurrentVersion = false;
                }
                else 
                {
                    _IsCurrentVersion = value;
                }
            }
        }


        public DateTime? Commence 
        {
            get 
            {
                return _Commence; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Commence=value;
                }
                else 
                {
                    _Commence=DateTime.MinValue;
                }

            }
            
        }

        public DateTime? Cease 
        {
            get 
            {
                return _Cease; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Cease=value;
                }
                else 
                {
                    _Cease=DateTime.MinValue;
                }

            }
            
        }

        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }


        public DateTime? When 
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }

            }
            
        }
    }

    public class PeopleLocations
    {
        int? _PersonLocationId ;
        int? _PersonId ;
        int? _EntityNumber ;
        int? _LocationNumber ;
        int? _PersonRoleId ;
        bool? _IsActive ;
        int? _Ver ;
        bool? _IsCurrentVersion ;
        string _Who ;
DateTime? _When;
DateTime? _Commence;

        public int? PersonLocationId 
        {
            get
            {
                return _PersonLocationId;
            }  
            set 
            {
                if (value!=null)
                {
                    _PersonLocationId=value;
                }
                else 
                {
                    _PersonLocationId=0;
                }
            } 
        }


        public int? PersonId 
        {
            get
            {
                return _PersonId;
            }  
            set 
            {
                if (value!=null)
                {
                    _PersonId=value;
                }
                else 
                {
                    _PersonId=0;
                }
            } 
        }

        public int? EntityNumber 
        {
            get
            {
                return _EntityNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _EntityNumber=value;
                }
                else 
                {
                    _EntityNumber=0;
                }
            } 
        }

        public int? LocationNumber 
        {
            get
            {
                return _LocationNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _LocationNumber=value;
                }
                else 
                {
                    _LocationNumber=0;
                }
            } 
        }

        public int? PersonRoleId 
        {
            get
            {
                return _PersonRoleId;
            }  
            set 
            {
                if (value!=null)
                {
                    _PersonRoleId=value;
                }
                else 
                {
                    _PersonRoleId=0;
                }
            } 
        }

        public bool? IsActive 
        { 
            get 
            {
                return _IsActive; 
            } 
            set
            {
                if (value==null)
                {
                    _IsActive = false;
                }
                else 
                {
                    _IsActive = value;
                }
            }
        }

        public int? Ver 
        {
            get
            {
                return _Ver;
            }  
            set 
            {
                if (value!=null)
                {
                    _Ver=value;
                }
                else 
                {
                    _Ver=0;
                }
            } 
        }

        public bool? IsCurrentVersion 
        { 
            get 
            {
                return _IsCurrentVersion; 
            } 
            set
            {
                if (value==null)
                {
                    _IsCurrentVersion = false;
                }
                else 
                {
                    _IsCurrentVersion = value;
                }
            }
        }

        public DateTime? Commence 
        {
            get 
            {
                return _Commence; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Commence=value;
                }
                else 
                {
                    _Commence=DateTime.MinValue;
                }

            }
            
        }
        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }

        public DateTime? When 
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }

            }
            
        }

    }

    public class PrintApprovalHold
    {
        int? _LocationNumber ;

        public int? LocationNumber 
        {
            get
            {
                return _LocationNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _LocationNumber=value;
                }
                else 
                {
                    _LocationNumber=0;
                }
            } 
        }


    }

    public class Parms
    {
        int? _ParmId ;
        string _ParmType ;
        string _ParmValue ;
        string _ParmDescription ;
        bool? _IsActive ;
        int? _Ver ;
        bool? _IsCurrentVersion ;
        string _Who ;
        DateTime? _When;
        DateTime? _Commence;

        public int? ParmId 
        {
            get
            {
                return _ParmId;
            }  
            set 
            {
                if (value!=null)
                {
                    _ParmId=value;
                }
                else 
                {
                    _ParmId=0;
                }
            } 
        }

        public string ParmType 
        { 
            get 
            {
                return _ParmType; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _ParmType = string.Empty;
                }
                else 
                {
                    _ParmType = value;
                }
            }
        }

        public string ParmValue 
        { 
            get 
            {
                return _ParmValue; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _ParmValue = string.Empty;
                }
                else 
                {
                    _ParmValue = value;
                }
            }
        }
   
        public string ParmDescription
        { 
            get 
            {
                return _ParmDescription; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _ParmDescription = string.Empty;
                }
                else 
                {
                    _ParmDescription = value;
                }
            }
        }
 
        
        public bool? IsActive 
        { 
            get 
            {
                return _IsActive; 
            } 
            set
            {
                if (value==null)
                {
                    _IsActive = false;
                }
                else 
                {
                    _IsActive = value;
                }
            }
        }


        public int? Ver 
        {
            get
            {
                return _Ver;
            }  
            set 
            {
                if (value!=null)
                {
                    _Ver=value;
                }
                else 
                {
                    _Ver=0;
                }
            } 
        }

        public bool? IsCurrentVersion 
        { 
            get 
            {
                return _IsCurrentVersion; 
            } 
            set
            {
                if (value==null)
                {
                    _IsCurrentVersion = false;
                }
                else 
                {
                    _IsCurrentVersion = value;
                }
            }
        }


        public DateTime? Commence 
        {
            get 
            {
                return _Commence; 
            } 
            set 
            {
                if (value!=null)
                {
                    _Commence=value;
                }
                else 
                {
                    _Commence=DateTime.MinValue;
                }

            }
            
        }

        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }

        public DateTime? When 
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }

            }
            
        }



    }

    public class PaymentDetails
    {
        int? _PaymentDetailId { get; set; }
        int? _PaymentId { get; set; }
        int? _LocationNumber { get; set; }
        double? _Amount { get; set; }
        string _Who { get; set; }
        DateTime? _When;

        public int? PaymentDetailId 
        {
            get
            {
                return _PaymentDetailId;
            }  
            set 
            {
                if (value!=null)
                {
                    _PaymentDetailId=value;
                }
                else 
                {
                    _PaymentDetailId=0;
                }
            } 
        }

        public int? PaymentId 
        {
            get
            {
                return _PaymentId;
            }  
            set 
            {
                if (value!=null)
                {
                    _PaymentId=value;
                }
                else 
                {
                    _PaymentId=0;
                }
            } 
        }

        public int? LocationNumber 
        {
            get
            {
                return _LocationNumber;
            }  
            set 
            {
                if (value!=null)
                {
                    _LocationNumber=value;
                }
                else 
                {
                    _LocationNumber=0;
                }
            } 
        }

        public double? Amount 
        {
            get
            {
                return _Amount;
            }  
            set 
            {
                if (value!=null)
                {
                    _Amount=value;
                }
                else 
                {
                    _Amount=0;
                }
            } 
        }

        public string Who 
        { 
            get 
            {
                return _Who; 
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Who = string.Empty;
                }
                else 
                {
                    _Who = value;
                }
            }
        }

        public DateTime? When 
        {
            get 
            {
                return _When; 
            } 
            set 
            {
                if (value!=null)
                {
                    _When=value;
                }
                else 
                {
                    _When=DateTime.MinValue;
                }

            }
            
        }


    }

#endregion

    public class MTData
    {
        #region publicPropertiesFields
        public List<Inspections> inspList = new List<Inspections>();
        public List<AgencyBill> AgencybillList = new List<AgencyBill>();
        public List<Users> UsersList = new List<Users>();
        public List<LocationDates> LocationDatesList = new List<LocationDates>();
        public List<UsersInRoles> usersInRolesList = new List<UsersInRoles>();
        public List<Location> LocationList = new List<Location>();
        public List<NurseryViolations> nurseryViolationsList = new List<NurseryViolations>();
        public List<License> LicenseList = new List<License>();
        public List<PrintBatchDetail> printBatchDetailList = new List<PrintBatchDetail>();
        public List<SabhrsTransactions> sabhrsTransactionsList = new List<SabhrsTransactions>();
        public List<RoleEmailCls> roleEmailClsList = new List<RoleEmailCls>();
        public List<Fees> FeesList = new List<Fees>();
        public List<NurseryInspection> nurseryInspectionList = new List<NurseryInspection>();
        public List<County> CountyList = new List<County>();
        public List<FoodEndorsement> foodEndorsementList = new List<FoodEndorsement>();
        public List<NurseryInspectionBilling> nurseryInspectionBillingList = new List<NurseryInspectionBilling>();
        public List<NurseryControlledSales> nurseryControlledSalesList = new List<NurseryControlledSales>();
        public List<NurserySample> nurserySampleList = new List<NurserySample>();
        public List<SabhrsTreasuryWire> sabhrsTreasuryWireList = new List<SabhrsTreasuryWire>();
        public List<LocationDetailXRef> locationDetailXRefList = new List<LocationDetailXRef>();
        public List<DocumentType> documentTypeList = new List<DocumentType>();
        public List<AspnetEntityPasscode> aspnetEntityPasscodeList = new List<AspnetEntityPasscode>();
        public List<NurserySupplier> nurserySupplierList = new List<NurserySupplier>();
        public List<PageSecurity> pageSecurityList = new List<PageSecurity>();
        public List<SabhrsReversalInfo> sabhrsReversalInfoList = new List<SabhrsReversalInfo>();
        public List<NurseryPlantsInspected> nurseryPlantsInspectedList = new List<NurseryPlantsInspected>();
        public List<NurseryNoxiousWeed> nurseryNoxiousWeed = new List<NurseryNoxiousWeed>();
        public List<Payment> PaymentList = new List<Payment>();
        public List<Holidays> HolidaysList = new List<Holidays>();
        public List<PrintBatch> printBatchList = new List<PrintBatch>();
        public List<Note> NoteList = new List<Note>();
        public List<Entity> EntityList = new List<Entity>();
        public List<NurseryBlackRustUsdaList> nurseryBlackRustUsdaListList = new List<NurseryBlackRustUsdaList>();
        public List<Batch> BatchList = new List<Batch>();
        public List<SabhrsFeeInfo> sabhrsFeeInfoList = new List<SabhrsFeeInfo>();
        public List<Attachment> AttachmentList = new List<Attachment>();
        public List<NurseryQuarantine> nurseryQuarantineList = new List<NurseryQuarantine>();
        public List<AttachmentSecurity> attachmentSecurityList = new List<AttachmentSecurity>();
        public List<LicensePaymentStatus> licensePaymentStatusList = new List<LicensePaymentStatus>();
        public List<Machine> MachineList = new List<Machine>();
        public List<ReportParameter> reportParameterList = new List<ReportParameter>();
        public List<ReportCategory> ReportCategoryList = new List<ReportCategory>();
        public List<Report> ReportList = new List<Report>();
        public List<ReportGroup> ReportGroupsList = new List<ReportGroup>();
        public List<LocationTransactionDetail> LocationTransactionDetailList = new List<LocationTransactionDetail>();
        public List<ProcessStatus> processStatusList = new List<ProcessStatus>();
        public List<LocationTransaction> LocationTransactionList = new List<LocationTransaction>();
        public List<LocationBalance> LocationBalanceList = new List<LocationBalance>();
        public List<PeopleLocations> PeopleLocationList = new List<PeopleLocations>();
        public List<PaymentDetails> PaymentDetailList = new List<PaymentDetails>();
        public List<Parms> ParmsList = new List<Parms>();
        public List<Person> PersonList = new List<Person>();
        public List<PrintApprovalHold> printApprovalHoldList = new List<PrintApprovalHold>();
        #endregion

        #region privatePropertiesFields
        ConfigFile estopCfg  = new ConfigFile();
        LogFile estoplf = new LogFile();
  
        #endregion

#region publicMethods

        #region BuildLists
         public Boolean BuildList<T>(string jsonstring, ref List<T> thelist)
         {
            Boolean success = true;
            try
            {
                thelist = JsonConvert.DeserializeObject<List<T>>(jsonstring);

            }
            catch(Exception ex)
            {
                string lg = "Critical Error Estop Building List Error ["+ex.Message+"]";
                WriteOutError(lg,ErrorLog.IfaceResult.FAIL);
            }
            finally
            {

            }

            return success;
         }

        public async void BuildoutLists(DB_SQL db)
        {
            /* this connects tot he legacy data, and fills out the legacy classes for us to pull data from
            */
            Boolean success = true;
            try
            {
                // string datasetInJson2 = string.Empty;
                // datasetInJson2 = db.RunSqlStatement(estopCfg.BaseSql,"Location");
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                /*  we break up the idividual groups of tables into these tasks/threads.  This is improve the speed of the 
                        the data loading.
                */
                Task<int> task1 = Task.Run
                (
                    () =>
                    {
                        Console.WriteLine("Start Task 1");

                        string datasetInJson = string.Empty;

                        datasetInJson = db.RunSqlStatement(estopCfg.BaseSql,"People","1");
                        BuildList<Person>(datasetInJson,ref PersonList);

                        datasetInJson = db.RunSqlStatement(estopCfg.BaseSql,"Location","1");
                        BuildList<Location>(datasetInJson,ref LocationList);                


                        datasetInJson = db.RunSqlStatement(estopCfg.BaseSql,"RoleEmail","1");
                        BuildList<RoleEmailCls>(datasetInJson,ref roleEmailClsList);                

                        datasetInJson = db.RunSqlStatement(estopCfg.BaseSql,"Fees","1");
                        BuildList<Fees>(datasetInJson,ref FeesList);                

                        datasetInJson = db.RunSqlStatement(estopCfg.BaseSql,"AgencyBill","1");
                        BuildList<AgencyBill>(datasetInJson,ref AgencybillList);

                        datasetInJson = db.RunSqlStatement(estopCfg.BaseSql,"Inspection","1");
                        BuildList<Inspections>(datasetInJson,ref inspList);                

                        datasetInJson = db.RunSqlStatement(estopCfg.BaseSql,"Users","1");
                        BuildList<Users>(datasetInJson,ref UsersList);                

                        datasetInJson = db.RunSqlStatement(estopCfg.BaseSql,"LocationDates","1");
                        BuildList<LocationDates>(datasetInJson,ref LocationDatesList);                

                        datasetInJson = db.RunSqlStatement(estopCfg.BaseSql,"UsersInRoles","1");
                        BuildList<UsersInRoles>(datasetInJson,ref usersInRolesList);                

                        datasetInJson = db.RunSqlStatement(estopCfg.BaseSql,"DocumentType","1");
                        BuildList<DocumentType>(datasetInJson,ref documentTypeList);                

                        datasetInJson = db.RunSqlStatement(estopCfg.BaseSql,"aspnet_EntityPasscode","1");
                        BuildList<AspnetEntityPasscode>(datasetInJson,ref aspnetEntityPasscodeList);                

                        datasetInJson = db.RunSqlStatement(estopCfg.BaseSql,"NurserySupplier","1");
                        BuildList<NurserySupplier>(datasetInJson,ref nurserySupplierList);                

                        datasetInJson = db.RunSqlStatement(estopCfg.BaseSql,"PageSecurity","1");
                        BuildList<PageSecurity>(datasetInJson,ref pageSecurityList);                

                        datasetInJson = db.RunSqlStatement(estopCfg.BaseSql,"SabhrsReversalInfo","1");
                        BuildList<SabhrsReversalInfo>(datasetInJson,ref sabhrsReversalInfoList);                

                        datasetInJson = db.RunSqlStatement(estopCfg.BaseSql,"Machine","1");
                        BuildList<Machine>(datasetInJson,ref MachineList);                

                        datasetInJson = db.RunSqlStatement(estopCfg.BaseSql,"ReportParameter","1");
                        BuildList<ReportParameter>(datasetInJson,ref reportParameterList);                

                        datasetInJson = db.RunSqlStatement(estopCfg.BaseSql,"ReportCategory","1");
                        BuildList<ReportCategory>(datasetInJson,ref ReportCategoryList);                

                        datasetInJson = db.RunSqlStatement(estopCfg.BaseSql,"Report","1");
                        BuildList<Report>(datasetInJson,ref ReportList);                

                        datasetInJson = db.RunSqlStatement(estopCfg.BaseSql,"ReportGroup","1");
                        BuildList<ReportGroup>(datasetInJson,ref ReportGroupsList);                

                        datasetInJson = db.RunSqlStatement(estopCfg.BaseSql,"LocationTransactionDetail","1");
                        BuildList<LocationTransactionDetail>(datasetInJson,ref LocationTransactionDetailList);                


                        return 1;
                    }
                );

                Thread.Sleep(2000);

                Task<int> task2 = Task.Run
                (
                    () =>
                    {
                        DB_SQL task2db = new DB_SQL(estopCfg,estoplf,ref success);
 
                        Console.WriteLine("Start Task 2");
                        string datasetInJson2 = string.Empty;


                        datasetInJson2 = task2db.RunSqlStatement(estopCfg.BaseSql,"SabhrsTransactions","2");
                        BuildList<SabhrsTransactions>(datasetInJson2,ref sabhrsTransactionsList);                


                        return 1;
                    }
                );


                Task<int> task3 = Task.Run
                (
                    () =>
                    {
                        Console.WriteLine("Start Task 3");
                        string datasetInJson3 = string.Empty;
                        DB_SQL task3db = new DB_SQL(estopCfg,estoplf,ref success);

                        datasetInJson3 = task3db.RunSqlStatement(estopCfg.BaseSql,"NurseryInspection","3");
                        BuildList<NurseryInspection>(datasetInJson3,ref nurseryInspectionList);                

                        datasetInJson3 = task3db.RunSqlStatement(estopCfg.BaseSql,"County","3");
                        BuildList<County>(datasetInJson3,ref CountyList);                

                        datasetInJson3 = task3db.RunSqlStatement(estopCfg.BaseSql,"FoodEndorsement","3");
                        BuildList<FoodEndorsement>(datasetInJson3,ref foodEndorsementList);                

                        datasetInJson3 = task3db.RunSqlStatement(estopCfg.BaseSql,"NurseryInspectionBilling","3");
                        BuildList<NurseryInspectionBilling>(datasetInJson3,ref nurseryInspectionBillingList);                

                        datasetInJson3 = task3db.RunSqlStatement(estopCfg.BaseSql,"NurseryControlledSales","3");
                        BuildList<NurseryControlledSales>(datasetInJson3,ref nurseryControlledSalesList);                

                        datasetInJson3 = task3db.RunSqlStatement(estopCfg.BaseSql,"NurserySample","3");
                        BuildList<NurserySample>(datasetInJson3,ref nurserySampleList);                

                        datasetInJson3 = task3db.RunSqlStatement(estopCfg.BaseSql,"SabhrsTreasuryWire","3");
                        BuildList<SabhrsTreasuryWire>(datasetInJson3,ref sabhrsTreasuryWireList);                

                        datasetInJson3 = task3db.RunSqlStatement(estopCfg.BaseSql,"LocationDetailXRef","3");
                        BuildList<LocationDetailXRef>(datasetInJson3,ref locationDetailXRefList);                

                        datasetInJson3 = task3db.RunSqlStatement(estopCfg.BaseSql,"Entity","3");
                        BuildList<Entity>(datasetInJson3,ref EntityList);                

                        datasetInJson3 = task3db.RunSqlStatement(estopCfg.BaseSql,"NurseryBlackRustUsdaList","3");
                        BuildList<NurseryBlackRustUsdaList>(datasetInJson3,ref nurseryBlackRustUsdaListList);                

                        datasetInJson3 = task3db.RunSqlStatement(estopCfg.BaseSql,"Batch","3");
                        BuildList<Batch>(datasetInJson3,ref BatchList);                

                        datasetInJson3 = task3db.RunSqlStatement(estopCfg.BaseSql,"SabhrsFeeInfo","3");
                        BuildList<SabhrsFeeInfo>(datasetInJson3,ref sabhrsFeeInfoList);                

                        // datasetInJson3 = task3db.RunSqlStatement(estopCfg.BaseSql,"Attachment","3");
                        // BuildList<Attachment>(datasetInJson3,ref AttachmentList);                

                        datasetInJson3 = task3db.RunSqlStatement(estopCfg.BaseSql,"NurseryQuarantine","3");
                        BuildList<NurseryQuarantine>(datasetInJson3,ref nurseryQuarantineList);                

                        datasetInJson3 = task3db.RunSqlStatement(estopCfg.BaseSql,"AttachmentSecurity","3");
                        BuildList<AttachmentSecurity>(datasetInJson3,ref attachmentSecurityList);                

                        datasetInJson3 = task3db.RunSqlStatement(estopCfg.BaseSql,"LicensePaymentStatus","3");
                        BuildList<LicensePaymentStatus>(datasetInJson3,ref licensePaymentStatusList);                



                        return 1;
                    }
                );

                Task<int> task4 = Task.Run
                (
                    () =>
                    {
                        Console.WriteLine("Start Task 4");
                        string datasetInJson4 = string.Empty;
                        DB_SQL task4db = new DB_SQL(estopCfg,estoplf,ref success);

                        // datasetInJson3 = task3db.RunSqlStatement(estopCfg.BaseSql,"Attachment","4");
                        // BuildList<Attachment>(datasetInJson3,ref AttachmentList);                
                        datasetInJson4 = task4db.RunSqlStatement(estopCfg.BaseSql,"PrintBatchDetail","4");
                        BuildList<PrintBatchDetail>(datasetInJson4,ref printBatchDetailList);                

                        datasetInJson4 = task4db.RunSqlStatement(estopCfg.BaseSql,"NurseryViolations","4");
                        BuildList<NurseryViolations>(datasetInJson4,ref nurseryViolationsList);                

                        datasetInJson4 = task4db.RunSqlStatement(estopCfg.BaseSql,"License","4");
                        BuildList<License>(datasetInJson4,ref LicenseList);                

                        datasetInJson4 = task4db.RunSqlStatement(estopCfg.BaseSql,"NurseryPlantsInspected","4");
                        BuildList<NurseryPlantsInspected>(datasetInJson4,ref nurseryPlantsInspectedList);                

                        datasetInJson4 = task4db.RunSqlStatement(estopCfg.BaseSql,"NurseryNoxiousWeed","4");
                        BuildList<NurseryNoxiousWeed>(datasetInJson4,ref nurseryNoxiousWeed);                

                        datasetInJson4 = task4db.RunSqlStatement(estopCfg.BaseSql,"Payment","4");
                        BuildList<Payment>(datasetInJson4,ref PaymentList);                

                        datasetInJson4 = task4db.RunSqlStatement(estopCfg.BaseSql,"Holidays","4");
                        BuildList<Holidays>(datasetInJson4,ref HolidaysList);                

                        datasetInJson4 = task4db.RunSqlStatement(estopCfg.BaseSql,"PrintBatch","4");
                        BuildList<PrintBatch>(datasetInJson4,ref printBatchList);                

                        datasetInJson4 = task4db.RunSqlStatement(estopCfg.BaseSql,"Note","4");
                        BuildList<Note>(datasetInJson4,ref NoteList);                

                        datasetInJson4 = task4db.RunSqlStatement(estopCfg.BaseSql,"ProcessStatus","4");
                        BuildList<ProcessStatus>(datasetInJson4,ref processStatusList);                

                        datasetInJson4 = task4db.RunSqlStatement(estopCfg.BaseSql,"LocationTransaction","4");
                        BuildList<LocationTransaction>(datasetInJson4,ref LocationTransactionList);                

                        datasetInJson4 = task4db.RunSqlStatement(estopCfg.BaseSql,"LocationBalance","4");
                        BuildList<LocationBalance>(datasetInJson4,ref LocationBalanceList);                

                        datasetInJson4 = task4db.RunSqlStatement(estopCfg.BaseSql,"PeopleLocations","4");
                        BuildList<PeopleLocations>(datasetInJson4,ref PeopleLocationList);                

                        datasetInJson4 = task4db.RunSqlStatement(estopCfg.BaseSql,"PaymentDetails","4");
                        BuildList<PaymentDetails>(datasetInJson4,ref PaymentDetailList);                

                        datasetInJson4 = task4db.RunSqlStatement(estopCfg.BaseSql,"Parms","4");
                        BuildList<Parms>(datasetInJson4,ref ParmsList);                

                        datasetInJson4 = task4db.RunSqlStatement(estopCfg.BaseSql,"PrintApprovalHold","4");
                        BuildList<PrintApprovalHold>(datasetInJson4,ref printApprovalHoldList);                

                        return 1;
                    }
                );

                Thread.Sleep(2000);

                while (task1.Status== TaskStatus.Running || task2.Status==TaskStatus.Running || task3.Status==TaskStatus.Running ||
                        task4.Status==TaskStatus.Running)
                {
                    Console.WriteLine("Task1 ["+task1.Status.ToString()+"] Task2 ["+task2.Status.ToString()+"] Task3 ["+task3.Status.ToString()+"] Task4 ["+task4.Status.ToString()+"]");
                    Thread.Sleep(60000);
                }

                int res = await task1;
                res = await task2;
                res = await task3;
                res = await task4;
                stopwatch.Stop();

                string totaltime ="Total RunTime for DB Collecting "+stopwatch.Elapsed.Minutes.ToString(); 
                WriteOutError(totaltime,ErrorLog.IfaceResult.INFO);
                Console.WriteLine(totaltime);

                Console.WriteLine("We are done building from DB");
            }
            catch(Exception ex)
            {
                string lg = "Critical Error Building out Lists Error ["+ex.Message+"]";
                WriteOutError(lg,ErrorLog.IfaceResult.FAIL);

            }

            // return success;
        }


        public Boolean BuildAccelaLists(ref AccelaRecordsRoot[] accelaobjs )
        {
            /*  this is where we go through and start the filling out of the accela classes.
                    the number of items in the accela array will be equal to the number of threads we are processing.
            */
            Boolean success = true;
            int numthreads = Convert.ToInt32(estopCfg.NumberOfThreads);
            int? licnum = 0;

            try
            {

                int reccnt = 1;
                List<License>[] licthreads = new List<License>[numthreads];
                for (int x = 0; x<numthreads;x++)
                {
                    licthreads[x] = new List<License>();
                    accelaobjs[x].records = new List<Records>();
                }



                foreach (License l in LicenseList)
                {
                    licnum = l.LicenseNumber;
                    if (licnum<=-1)
                    {
                        continue;
                    }

                    if (reccnt>=numthreads) reccnt = 1;
                    if (l.LicenseNumber==3106)
                    {
                        // int kjj=0;
                    }

                    Records rec = new Records();
                    //to do,  map status numbers from legacy to accela values
                    rec.status = SetAccelaStatus(l);
                    rec.type = SetAccelaType(l);
                    rec.renewalInfo = SetAccelaRenewalInfo(l);
                    rec.description = "Converted Record Legacy License Number ["+l.LicenseNumber+"]";
                    CustomForm cf = new CustomForm();
                    if (l.LicenseNumber==146)
                    {
                        // int j = 0;
                    }
                    rec.customForms = Setcustomform(l,rec.type);
                    
                    accelaobjs[reccnt].records.Add(rec);

                    // licthreads[reccnt].Add(l);


                    reccnt++;

                }


                reccnt = 0;
                foreach(Location loc in LocationList)
                {
                    licnum = loc.LocationNumber;
                    if (licnum<=-1)
                    {
                        continue;
                    }

                    if (reccnt>=numthreads) reccnt = 0;

                    Records rec = new Records();
                    rec.customForms = new List<CustomForm>();
                    //to do,  map status numbers from legacy to accela values
                    rec.status = new Status();
                    rec.status.value = "Active";
                    rec.status.text = "Active"; 

                    rec.type = new AccelaType();
                    rec.type.value = "eStop/Master Location/Record/NA";
                    rec.type.type = "Master Location";
                    rec.type.category = "NA";
                    rec.type.subType= "Record";

                    rec.renewalInfo = new RenewalInfo();
                    rec.renewalInfo.expirationDate = string.Empty; 
                    rec.renewalInfo.expirationStatus = new Status();
                    rec.description = "Converted Record Legacy Location Number ["+licnum+"]";
                    // CustomForm cf = new CustomForm();
                    // if (l.LicenseNumber==146)
                    // {
                    //     int j = 0;
                    // }
                    // rec.customForms = Setcustomform(l,rec.type);
                    
                    accelaobjs[reccnt].records.Add(rec);

                    // licthreads[reccnt].Add(l);


                    // reccnt++;

                }
                int kj = 0;

            }
            catch(Exception ex)
            {
                string lg = "Critical Error Build Accela Lists Error ["+ex.Message+"] "+licnum.ToString();
                WriteOutError(lg,ErrorLog.IfaceResult.FAIL);

            }
            finally
            {

            }

            return success;
        }

    #endregion 
#endregion

        #region privateMethods
        List<CustomForm> Setcustomform(License l, AccelaType at)
        {
            List<CustomForm> cflist = new List<CustomForm>();
            CustomForm[] cfAry = new CustomForm[200];
            int itemcnt = 0;
            switch(at.value)
            {
                case "UST/Storage Tank/License/NA":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-FINANCIAL.cRESPONSIBILITY";
                    cfAry[itemcnt].aCustomFieldName = "Cleanup Fund (PTRCF)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-FINANCIAL.cRESPONSIBILITY";
                    cfAry[itemcnt].aCustomFieldName = "Trust Fund";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-FINANCIAL.cRESPONSIBILITY";
                    cfAry[itemcnt].aCustomFieldName = "Letter of Credit";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-FINANCIAL.cRESPONSIBILITY";
                    cfAry[itemcnt].aCustomFieldName = "Certificate of Tangible Net Worth";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-FINANCIAL.cRESPONSIBILITY";
                    cfAry[itemcnt].aCustomFieldName = "Insurance/Risk Group Coverage";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-FINANCIAL.cRESPONSIBILITY";
                    cfAry[itemcnt].aCustomFieldName = "Financial Test of Self Insurance";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-FINANCIAL.cRESPONSIBILITY";
                    cfAry[itemcnt].aCustomFieldName = "Standby Trust Fund";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-FINANCIAL.cRESPONSIBILITY";
                    cfAry[itemcnt].aCustomFieldName = "Guarantee";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-FINANCIAL.cRESPONSIBILITY";
                    cfAry[itemcnt].aCustomFieldName = "Montana Petroleum Tank Release";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-FINANCIAL.cRESPONSIBILITY";
                    cfAry[itemcnt].aCustomFieldName = "Surety Bond";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-LOCAL.cGOVERNMENT.cONLY";
                    cfAry[itemcnt].aCustomFieldName = "Bond Rating Test";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-LOCAL.cGOVERNMENT.cONLY";
                    cfAry[itemcnt].aCustomFieldName = "Financial Test";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-LOCAL.cGOVERNMENT.cONLY";
                    cfAry[itemcnt].aCustomFieldName = "Dedicated Fund";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-LOCAL.cGOVERNMENT.cONLY";
                    cfAry[itemcnt].aCustomFieldName = "Local Gov Guarantee";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Business Name";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Master Location Record ID";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Number";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-OWNER.3.cFACILITY.cINFO";
                    cfAry[itemcnt].aCustomFieldName = "Type of Owner";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-OWNER.3.cFACILITY.cINFO";
                    cfAry[itemcnt].aCustomFieldName = "Type of Facility";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-OWNER.3.cFACILITY.cINFO";
                    cfAry[itemcnt].aCustomFieldName = "Other Owner Type";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-OWNER.3.cFACILITY.cINFO";
                    cfAry[itemcnt].aCustomFieldName = "Tribal Owner";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-OWNER.3.cFACILITY.cINFO";
                    cfAry[itemcnt].aCustomFieldName = "Tribe or Nation";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-OWNER.3.cFACILITY.cINFO";
                    cfAry[itemcnt].aCustomFieldName = "Tribal Land";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-APPLICATION.cTYPE";
                    cfAry[itemcnt].aCustomFieldName = "Type of Application";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_LIC-LEGACY.cINFORMATION";

                    cfAry[itemcnt].aCustomFieldName ="License Number";
                    cfAry[itemcnt].aCustomFieldValue = l.LicenseNumber.ToString();
                    itemcnt++;

                    break;
                case "UST/Storage Tank/Application/NA":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_APP-FINANCIAL.cRESPONSIBILITY";
                    cfAry[itemcnt].aCustomFieldName = "Cleanup Fund (PTRCF)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_APP-FINANCIAL.cRESPONSIBILITY";
                    cfAry[itemcnt].aCustomFieldName = "Trust Fund";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_APP-FINANCIAL.cRESPONSIBILITY";
                    cfAry[itemcnt].aCustomFieldName = "Letter of Credit";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_APP-FINANCIAL.cRESPONSIBILITY";
                    cfAry[itemcnt].aCustomFieldName = "Certificate of Tangible Net Worth";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_APP-FINANCIAL.cRESPONSIBILITY";
                    cfAry[itemcnt].aCustomFieldName = "Insurance/Risk Group Coverage";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_APP-FINANCIAL.cRESPONSIBILITY";
                    cfAry[itemcnt].aCustomFieldName = "Financial Test of Self Insurance";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_APP-FINANCIAL.cRESPONSIBILITY";
                    cfAry[itemcnt].aCustomFieldName = "Standby Trust Fund";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_APP-FINANCIAL.cRESPONSIBILITY";
                    cfAry[itemcnt].aCustomFieldName = "Guarantee";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_APP-FINANCIAL.cRESPONSIBILITY";
                    cfAry[itemcnt].aCustomFieldName = "Montana Petroleum Tank Release";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_APP-FINANCIAL.cRESPONSIBILITY";
                    cfAry[itemcnt].aCustomFieldName = "Surety Bond";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_APP-LOCAL.cGOVERNMENT.cONLY";
                    cfAry[itemcnt].aCustomFieldName = "Bond Rating Test";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_APP-LOCAL.cGOVERNMENT.cONLY";
                    cfAry[itemcnt].aCustomFieldName = "Financial Test";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_APP-LOCAL.cGOVERNMENT.cONLY";
                    cfAry[itemcnt].aCustomFieldName = "Dedicated Fund";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_APP-LOCAL.cGOVERNMENT.cONLY";
                    cfAry[itemcnt].aCustomFieldName = "Local Gov Guarantee";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_APP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Business Name";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_APP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Master Location Record ID";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_APP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Number";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_APP-OWNER.3.cFACILITY.cINFO";
                    cfAry[itemcnt].aCustomFieldName = "Type of Owner";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_APP-OWNER.3.cFACILITY.cINFO";
                    cfAry[itemcnt].aCustomFieldName = "Type of Facility";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_APP-OWNER.3.cFACILITY.cINFO";
                    cfAry[itemcnt].aCustomFieldName = "Other Owner Type";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_APP-OWNER.3.cFACILITY.cINFO";
                    cfAry[itemcnt].aCustomFieldName = "Tribal Owner";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_APP-OWNER.3.cFACILITY.cINFO";
                    cfAry[itemcnt].aCustomFieldName = "Tribe or Nation";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_APP-OWNER.3.cFACILITY.cINFO";
                    cfAry[itemcnt].aCustomFieldName = "Tribal Land";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "UST_APP-APPLICATION.cTYPE";
                    cfAry[itemcnt].aCustomFieldName = "Type of Application";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    break;
                case "NUR/Nursery/License/NA":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "NURS_LIC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Business Name";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "NURS_LIC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Master Location Record ID";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "NURS_LIC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Number";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "NURS_LIC-APPLICATION.cTYPE";
                    cfAry[itemcnt].aCustomFieldName = "Type of Application";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "NURS_LIC-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Risk Category";
                    cfAry[itemcnt].aCustomFieldValue = l.RiskCategory;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "NURS_LIC-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "NURS_LIC-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Other Description";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "NURS_LIC-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Description of Nursery";

                    NurseryInspection ni = new NurseryInspection();
                    ni = GetNuseryInspectionRec(l);

                    cfAry[itemcnt].aCustomFieldValue = ni.NurseryDescriptionId;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "NURS_LIC-LEGACY.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Number";
                    cfAry[itemcnt].aCustomFieldValue = l.LicenseNumber.ToString();
                    itemcnt++;


                    break;
                case "NUR/Nursery/Application/NA":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "NURS_APP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Business Name";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "NURS_APP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Master Location Record ID";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "NURS_APP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Number";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "NURS_APP-APPLICATION.cTYPE";
                    cfAry[itemcnt].aCustomFieldName = "Type of Application";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "NURS_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Risk Category";
                    cfAry[itemcnt].aCustomFieldValue = l.RiskCategory;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "NURS_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;


                    break;
                case "BIT/Alt Nicotine or Vapor Product/Application/NA":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ANVP_APP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Business Name";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ANVP_APP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Master Location Record ID";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ANVP_APP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Number";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ANVP_APP-APPLICATION.cTYPE";
                    cfAry[itemcnt].aCustomFieldName = "Type of Application";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ANVP_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Business or Direct to Consumer";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ANVP_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Retailer- Alternative Nicotine or Vapor Products";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    break;
                case "LOT/Traditional Lottery/License/NA":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TRAD_LOT_LIC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Business Name";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TRAD_LOT_LIC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Master Location Record ID";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TRAD_LOT_LIC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Number";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TRAD_LOT_LIC-APPLICATION.cTYPE";
                    cfAry[itemcnt].aCustomFieldName = "Type of Application";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TRAD_LOT_LIC-LEGACY.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Number";
                    cfAry[itemcnt].aCustomFieldValue = l.LicenseNumber.ToString();
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TRAD_LOT_LIC-LEGACY.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Owner Number";
                    cfAry[itemcnt].aCustomFieldValue = l.LocationNumber.ToString();
                    itemcnt++;

                    break;
                case "LOT/Traditional Lottery/Application/NA":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TRAD_LOT_APP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Business Name";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TRAD_LOT_APP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Master Location Record ID";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TRAD_LOT_APP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Number";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TRAD_LOT_APP-APPLICATION.cTYPE";
                    cfAry[itemcnt].aCustomFieldName = "Type of Application";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    break;
                case "LOT/Sports Wagering/License/NA":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "SWAG_LIC-GAMBLING.cLICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Gambling License Number";
                    cfAry[itemcnt].aCustomFieldValue = l.LicenseNumber.ToString();
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "SWAG_LIC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Business Name";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "SWAG_LIC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Master Location Record ID";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "SWAG_LIC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Number";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "SWAG_LIC-APPLICATION.cTYPE";
                    cfAry[itemcnt].aCustomFieldName = "Type of Application";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "SWAG_LIC-LEGACY.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Number";
                    cfAry[itemcnt].aCustomFieldValue = l.LicenseNumber.ToString();
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "SWAG_LIC-LEGACY.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Owner Number";
                    cfAry[itemcnt].aCustomFieldValue = l.LocationNumber.ToString();
                    itemcnt++;

                    break;
                case "LOT/Sports Wagering/Application/NA":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "SWAG_APP-GAMBLING.cLICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Gambling License Number";
                    cfAry[itemcnt].aCustomFieldValue = l.LicenseNumber.ToString();
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "SWAG_APP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Business Name";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "SWAG_APP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Master Location Record ID";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "SWAG_APP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Number";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "SWAG_APP-APPLICATION.cTYPE";
                    cfAry[itemcnt].aCustomFieldName = "Type of Application";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    break;
                case "EH/Retail Food/Renewal/NA":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_REN-RENEWAL.cACTION";
                    cfAry[itemcnt].aCustomFieldName = "Renew or Cancel";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_REN-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Water Hauler";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_REN-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Meat Market (Onsite Retail Only)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_REN-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Food Service Establishment";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_REN-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Food Service/ Catering (Retail)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_REN-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Tavern or Bar";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_REN-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Mobile Food Service";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_REN-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Perishable Food Dealer (Retail Only)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_REN-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Produce (Onsite Retail Only)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_REN-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_REN-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Food Manufacturer (Onsite Retail- Take Out)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_REN-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Bakery (Onsite Retail Only)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_REN-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Schools";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    // cfAry[itemcnt] = new CustomForm();
                    // cfAry[itemcnt].id =  "FOOD_REN-LICENSE.cINFORMATION";
                    // cfAry[itemcnt].aCustomFieldName = "Food Service/ Delicatessen (Onsite Retail)";
                    // cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    // itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_REN-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Water Hauler";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;


                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_REN-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Meat Market (Onsite Retail Only)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_REN-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Food Service Establishment";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_REN-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Food Service/ Catering (Retail)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_REN-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Tavern or Bar";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_REN-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Mobile Food Service";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_REN-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Perishable Food Dealer (Retail Only)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_REN-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Produce (Onsite Retail Only)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_REN-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Food Manufacturer (Onsite Retail- Take Out)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_REN-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Bakery (Onsite Retail Only)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_REN-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Schools";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    // cfAry[itemcnt] = new CustomForm();
                    // cfAry[itemcnt].id =  "FOOD_REN-FOOD.cENDORSEMENTS";
                    // cfAry[itemcnt].aCustomFieldName = "Food Service/ Delicatessen (Onsite Retail)";
                    // cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    // itemcnt++;

                    break;
                case "EH/Retail Food/License/NA":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_LIC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Business Name";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_LIC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Master Location Record ID";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_LIC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Number";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_LIC-APPLICATION.cTYPE";
                    cfAry[itemcnt].aCustomFieldName = "Type of Application";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_LIC-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_LIC-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Special Restrictions";
                    cfAry[itemcnt].aCustomFieldValue = l.SpecialRestrictions;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_LIC-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Water Hauler";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_LIC-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Meat Market (Onsite Retail Only)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_LIC-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Food Service Establishment";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_LIC-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Food Service/ Catering (Retail)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_LIC-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Tavern or Bar";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_LIC-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Mobile Food Service";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_LIC-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Perishable Food Dealer (Retail Only)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_LIC-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Produce (Onsite Retail Only)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_LIC-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Food Manufacturer (Onsite Retail- Take Out)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_LIC-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Bakery (Onsite Retail Only)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_LIC-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Schools";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    // cfAry[itemcnt] = new CustomForm();
                    // cfAry[itemcnt].id =  "Food Service/ Delicatessen (Onsite Retail)";
                    // cfAry[itemcnt].aCustomFieldName = "Schools";
                    // cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    // itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_LIC-LEGACY.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Number";
                    cfAry[itemcnt].aCustomFieldValue = l.LicenseNumber.ToString();
                    itemcnt++;

                    break;
                case "EH/Retail Food/Application/NA":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Business Name";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Master Location Record ID";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Number";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-APPLICATION.cTYPE";
                    cfAry[itemcnt].aCustomFieldName = "Type of Application";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Water Hauler";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Meat Market (Onsite Retail Only)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Food Service Establishment";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Bakery";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Food Service/ Catering (Retail)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Tavern or Bar";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Mobile Food Service";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Perishable Food Dealer (Retail Only)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Produce (Onsite Retail Only)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Food Manufacturer (Onsite Retail- Take Out)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Bakery (Onsite Retail Only)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Schools";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    // cfAry[itemcnt] = new CustomForm();
                    // cfAry[itemcnt].id =  "FOOD_APP-LICENSE.cINFORMATION";
                    // cfAry[itemcnt].aCustomFieldName = "Food Service/ Delicatessen (Onsite Retail)";
                    // cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    // itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Water Hauler";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Meat Market (Onsite Retail Only)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Food Service Establishment";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Food Service/ Catering (Retail)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Tavern or Bar";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Mobile Food Service";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Perishable Food Dealer (Retail Only)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Produce (Onsite Retail Only)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Food Manufacturer (Onsite Retail- Take Out)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Bakery (Onsite Retail Only)";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "FOOD_APP-FOOD.cENDORSEMENTS";
                    cfAry[itemcnt].aCustomFieldName = "Schools";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    // cfAry[itemcnt] = new CustomForm();
                    // cfAry[itemcnt].id =  "FOOD_APP-FOOD.cENDORSEMENTS";
                    // cfAry[itemcnt].aCustomFieldName = "Food Service/ Delicatessen (Onsite Retail)";
                    // cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    // itemcnt++;

                    break;
                case "BIT/Tobacco Products/Renewal/NA":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_REN-RENEWAL.cACTION";
                    cfAry[itemcnt].aCustomFieldName = "Renew or Cancel";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_REN-GEN.cTAX";
                    cfAry[itemcnt].aCustomFieldName = "Gen Tax Account #";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_REN-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype- Wholesaler";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_REN-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype- Vendor";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_REN-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Wholesaler Product Type";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_REN-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Changes since Last Renewal";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_REN-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype- Retailer-Tobacco";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_REN-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype- Importer";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_REN-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype- Retailer-Vendor";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_REN-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype- Subjobber";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;

                    break;
                case "BIT/Tobacco Products/License/NA":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_LIC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Business Name";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_LIC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Master Location Record ID";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_LIC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Number";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_LIC-GEN.cTAX";
                    cfAry[itemcnt].aCustomFieldName = "Gen Tax Account #";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_LIC-APPLICATION.cTYPE";
                    cfAry[itemcnt].aCustomFieldName = "Type of Application";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_LIC-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype- Wholesaler";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_LIC-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype- Vendor";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_LIC-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Wholesaler Product Type";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_LIC-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_LIC-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype- Retailer-Tobacco";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_LIC-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Retailer Location Known?";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_LIC-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype- Importer";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_LIC-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype- Retailer-Vendor";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_LIC-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype- Subjobber";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_LIC-LEGACY.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Number";
                    cfAry[itemcnt].aCustomFieldValue = l.LicenseNumber.ToString();
                    itemcnt++;

                    break;
                case "BIT/Tobacco Products/Application/NA":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_APP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Business Name";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_APP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Master Location Record ID";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_APP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Number";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_APP-APPLICATION.cTYPE";
                    cfAry[itemcnt].aCustomFieldName = "Type of Application";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype- Wholesaler";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype- Vendor";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Wholesaler Product Type";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype- Retailer-Tobacco";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Retailer Location Known?";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype- Importer";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype- Retailer-Vendor";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "TOB_APP-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype- Subjobber";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    break;
                case "BIT/Alt Nicotine or Vapor Product/License/NA":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ANVP_LIC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Business Name";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ANVP_LIC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Master Location Record ID";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ANVP_LIC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Number";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ANVP_LIC-GEN.cTAX";
                    cfAry[itemcnt].aCustomFieldName = "Gen Tax Account #";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ANVP_LIC-APPLICATION.cTYPE";
                    cfAry[itemcnt].aCustomFieldName = "Type of Application";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ANVP_LIC-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ANVP_LIC-LEGACY.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Number";
                    cfAry[itemcnt].aCustomFieldValue = l.LicenseNumber.ToString();
                    itemcnt++;
                    break;
                case "BIT/Alt Nicotine or Vapor Product/Renewal/NA":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ANVP_REN-RENEWAL.cACTION";
                    cfAry[itemcnt].aCustomFieldName = "Renew or Cancel";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ANVP_REN-GEN.cTAX";
                    cfAry[itemcnt].aCustomFieldName = "Gen Tax Account #";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ANVP_REN-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Changes since last renewal";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ANVP_REN-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;
                    break;

                case "ABCD/Beer and Wine/Application/NA":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "BEERWINE_APP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Business Name";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "BEERWINE_APP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Master Location Record ID";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "BEERWINE_APP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Number";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "BEERWINE_APP-LOCATION.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Location Type";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "BEERWINE_APP-LOCATION.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "BEERWINE_APP-LOCATION.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Business Gross Income Agreement";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "BEERWINE_APP-APPLICATION.cTYPE";
                    cfAry[itemcnt].aCustomFieldName = "Type of Application";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "BEERWINE_APP-GROCERY.cSTORE.cINVENTORY";
                    cfAry[itemcnt].aCustomFieldName = "Total Retail Inventory";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    break;
                case "ABCD/Beer and Wine/Renewal/NA":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "BEERWINE_REN-RENEWAL.cACTION";
                    cfAry[itemcnt].aCustomFieldName = "Renew or Cancel";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "BEERWINE_REN-LOCATION.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Location Type";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "BEERWINE_REN-LOCATION.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "BEERWINE_REN-LOCATION.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Business Gross Income Agreement";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "BEERWINE_REN-GROCERY.cSTORE.cINVENTORY";
                    cfAry[itemcnt].aCustomFieldName = "Total Retail Inventory";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    break;
                case "ABCD/Beer and Wine/License/NA":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "BEERWINE_LIC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Number";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "BEERWINE_LIC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Business Name";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "BEERWINE_LIC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Master Location Record ID";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "BEERWINE_LIC-LOCATION.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Location Type";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "BEERWINE_LIC-LOCATION.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Subtype";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "BEERWINE_LIC-LOCATION.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Business Gross Income Agreement";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "BEERWINE_LIC-APPLICATION.cTYPE";
                    cfAry[itemcnt].aCustomFieldName = "Type of Application";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "BEERWINE_LIC-GROCERY.cSTORE.cINVENTORY";
                    cfAry[itemcnt].aCustomFieldName = "Total Retail Inventory";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "BEERWINE_LIC-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Off Premises Account ID";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "BEERWINE_LIC-LICENSE.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Special Restrictions";
                    cfAry[itemcnt].aCustomFieldValue = l.SpecialRestrictions;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "BEERWINE_LIC-LEGACY.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "License Number";
                    cfAry[itemcnt].aCustomFieldValue = l.LicenseNumber.ToString();
                    itemcnt++;

                    break;                   
                case "eStop/Master Location/Application/NA":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRAPP-APP.cDISCLAIMER";
                    cfAry[itemcnt].aCustomFieldName = "Disclaimer";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRAPP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Business Name";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRAPP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Master Location Record ID";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRAPP-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Number";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRAPP-LICENSE.cTYPES";
                    cfAry[itemcnt].aCustomFieldName = "Weights and Measures Meters License";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRAPP-LICENSE.cTYPES";
                    cfAry[itemcnt].aCustomFieldName = "Nursery License";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRAPP-LICENSE.cTYPES";
                    cfAry[itemcnt].aCustomFieldName = "Retail Food Establishment License";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRAPP-LICENSE.cTYPES";
                    cfAry[itemcnt].aCustomFieldName = "Tobacco Products License";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRAPP-LICENSE.cTYPES";
                    cfAry[itemcnt].aCustomFieldName = "Storage Tank License";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRAPP-LICENSE.cTYPES";
                    cfAry[itemcnt].aCustomFieldName = "Weights and Measures Scales License";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRAPP-LICENSE.cTYPES";
                    cfAry[itemcnt].aCustomFieldName = "Lottery License";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRAPP-LICENSE.cTYPES";
                    cfAry[itemcnt].aCustomFieldName = "Off Premises Beer and Wine License";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRAPP-LICENSE.cTYPES";
                    cfAry[itemcnt].aCustomFieldName = "Alternative Nicotine or Vapor Products License";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRAPP-LICENSE.cTYPES";
                    cfAry[itemcnt].aCustomFieldName = "Sports Wagering License";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRAPP-APPLICATION.cTYPE";
                    cfAry[itemcnt].aCustomFieldName = "Type of Application";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    break;
                case "eStop/Master Location/Renewal/NA":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRREN-LEGACY.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Owner Number";
                    cfAry[itemcnt].aCustomFieldValue = l.LocationNumber.ToString();
                    itemcnt++;

                    break;
                case "eStop/Master Location Amendment/Amendment/Add a License Type":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPADDLIC-LICENSE.cTYPES";
                    cfAry[itemcnt].aCustomFieldName = "Weights and Measures Meters License";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPADDLIC-LICENSE.cTYPES";
                    cfAry[itemcnt].aCustomFieldName = "Nursery License";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPADDLIC-LICENSE.cTYPES";
                    cfAry[itemcnt].aCustomFieldName = "Retail Food Establishment License";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPADDLIC-LICENSE.cTYPES";
                    cfAry[itemcnt].aCustomFieldName = "Tobacco Products License";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPADDLIC-LICENSE.cTYPES";
                    cfAry[itemcnt].aCustomFieldName = "Storage Tank License";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPADDLIC-LICENSE.cTYPES";
                    cfAry[itemcnt].aCustomFieldName = "Weights and Measures Scales License";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPADDLIC-LICENSE.cTYPES";
                    cfAry[itemcnt].aCustomFieldName = "Lottery License";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPADDLIC-LICENSE.cTYPES";
                    cfAry[itemcnt].aCustomFieldName = "Off Premises Beer and Wine License";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPADDLIC-LICENSE.cTYPES";
                    cfAry[itemcnt].aCustomFieldName = "Alternative Nicotine or Vapor Products License";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPADDLIC-LICENSE.cTYPES";
                    cfAry[itemcnt].aCustomFieldName = "Sports Wagering License";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    break;
                case "eStop/Master Location/Record/NA":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRLOC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Business Name";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRLOC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Master Location Record ID";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRLOC-TRANSFER.cOF.cOWNERSHIP";
                    cfAry[itemcnt].aCustomFieldName = "Previous Owner Number";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRLOC-APPLICATION.cTYPE";
                    cfAry[itemcnt].aCustomFieldName = "Type of Application";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRLOC-LEGACY.cINFORMATION";
                    cfAry[itemcnt].aCustomFieldName = "Owner Number";
                    cfAry[itemcnt].aCustomFieldValue = l.LocationNumber.ToString();
                    itemcnt++;

                    break;
                case "eStop/Master Location Amendment/Amendment/NA":
                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRAMN-UPDATE.cTYPE";
                    cfAry[itemcnt].aCustomFieldName = "Add or Remove Storage Tanks";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRAMN-UPDATE.cTYPE";
                    cfAry[itemcnt].aCustomFieldName = "Add or Remove Scales";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRAMN-UPDATE.cTYPE";
                    cfAry[itemcnt].aCustomFieldName = "Update Contacts";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRAMN-UPDATE.cTYPE";
                    cfAry[itemcnt].aCustomFieldName = "Add or Remove Meters";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRAMN-CONTACT.cTO.cBE.cUPDATED";
                    cfAry[itemcnt].aCustomFieldName = "Update Location Manager";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRAMN-CONTACT.cTO.cBE.cUPDATED";
                    cfAry[itemcnt].aCustomFieldName = "Update Agency Representative";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRAMN-CONTACT.cTO.cBE.cUPDATED";
                    cfAry[itemcnt].aCustomFieldName = "Update Applicant";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    cfAry[itemcnt] = new CustomForm();
                    cfAry[itemcnt].id =  "ESTOPMSTRAMN-CONTACT.cTO.cBE.cUPDATED";
                    cfAry[itemcnt].aCustomFieldName = "Update Other Contact";
                    cfAry[itemcnt].aCustomFieldValue = string.Empty;
                    itemcnt++;

                    break;
            }

            for (int x =0;x<itemcnt;x++)
            {
                if (cfAry!=null)
                {
                    cflist.Add(cfAry[x]);
                }
            }
            return cflist;
        }

        ConstructionType SetAccelaConstrutionType(License l)
        {
            ConstructionType ct = new ConstructionType();


            return ct;
        }

        RenewalInfo SetAccelaRenewalInfo(License l)
        {
            RenewalInfo ri = new RenewalInfo();

            ri.expirationDate = string.Empty;
            ri.expirationStatus = new Status();

            return ri;
        }

        Status SetAccelaStatus(License l)
        {
            //to do  set status 
            Status stat = new Status();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            var status = ParmsList.Find(x=> x.ParmId == l.StatusId);
            
            stat.value = textInfo.ToTitleCase(status.ParmDescription.ToLower()); 
            stat.text = textInfo.ToTitleCase(status.ParmDescription.ToLower()); 

            return stat;
        }

        AccelaType SetAccelaType(License l)
        {
            //to do set mapping to type
            AccelaType at = new AccelaType();
            switch(l.LicenseTypeId)
            {
                case 106:
                    at.value = "NUR/Nursery/License/NA";
                    at.type = "Nursery";
                    at.category = "NA";
                    at.subType= "License";
                    break;
                case 107:
                    at.value = "BIT/Tobacco Products/License/NA";
                    at.type = "Tobacco Products";
                    at.category = "NA";
                    at.subType= "License";
                    break;
                case 108:
                    at.value = "ABCD/Beer and Wine/License/NA";
                    at.type = "Beer and Wine";
                    at.category = "NA";
                    at.subType= "License";
                    break;
                case 109:
                    at.value = "WM/Meters/License/NA";
                    at.type = "Meters";
                    at.category = "NA";
                    at.subType= "License";
                    break;
                case 110:
                    at.value = "WM/Scales- Weighing/License/NA";
                    at.type = "Scales- Weighing";
                    at.category = "NA";
                    at.subType= "License";
                    break;
                case 111:
                    at.value = "EH/Retail Food/License/NA";
                    at.type = "Retail Food";
                    at.category = "NA";
                    at.subType= "License";
                    break;
                case 112:
                    at.value = "UST/Storage Tank/License/NA";
                    at.type = "Storage Tank";
                    at.category = "NA";
                    at.subType= "License";
                    break;
                case 290:
                    at.value = "LOT/Traditional Lottery/License/NA";
                    at.type = "Traditional Lottery";
                    at.category = "NA";
                    at.subType= "License";
                    break;
            }



            return at;
        } 

        NurseryInspection GetNuseryInspectionRec(License l)
        {
            NurseryInspection ni = new NurseryInspection();

            ni = nurseryInspectionList.Find(x=> x.LicenseNumber == l.LicenseNumber);

            return (ni==null?new NurseryInspection():ni);
        }

        void WriteOutError(string errmsg,ErrorLog.IfaceResult ir)
        {
            ErrorLog elg = new ErrorLog();
            elg.ifResult = ir;
            elg.Message = errmsg;
            
            estoplf.WriteLogLineItemFile(elg);
            Console.WriteLine(elg.Message);

        }

        #endregion


        public MTData(ConfigFile CFG, LogFile LF, ref Boolean success )
        {
            estopCfg = CFG;
            estoplf = LF;
            success = true;


        }
        
    }
    
}