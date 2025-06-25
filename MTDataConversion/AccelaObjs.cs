using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Net.Http;
using System.Text.Json; 
using RestSharp;
using RestSharp.Authenticators;

namespace MTDataConversion
{

/*  these classes are for the accela records brought back by the rest service.
*/

    public class AccelaFeeCode
    {
        public string text {get; set;}
        public string value {get; set;}
        
    }

    public class Accelaversion
    {
        public string text {get; set;}
        public string value {get; set;}
        
    }

    public class Accelaschedule
    {
        public string text {get; set;}
        public string value {get; set;}
        
    }
    public class AccelapaymentPeriod
    {
        public string text {get; set;}
        public string value {get; set;}
        
    }

    public class AccelaFee
    {
        public string quantity = string.Empty;
        public string feeNotes = string.Empty;
        public AccelapaymentPeriod paymentPeriod = new AccelapaymentPeriod();
        public Accelaschedule schedule = new Accelaschedule();
        public Accelaversion version = new Accelaversion();
        public AccelaFeeCode code = new AccelaFeeCode();
    }

    public class FEETYPE
    {
        [JsonProperty("Accela Fee Code")]
        public string AccelaFeeCode { get; set; }
        public int FeeId { get; set; }
        public string Description { get; set; }
    }

    public class FEETYPELIST
    {
        public List<FEETYPE> feetype = new List<FEETYPE>();
    }

    public class ConstructionType
    {
        public string value { get; set; }
        public string text { get; set; }
    }

    public class RenewalInfo
    {
        public Status expirationStatus { get; set; }
        public string expirationDate { get; set; }
    }

    public class InspStatus
    {
        public Status status = new Status();
    }


    public class Status
    {
        [JsonProperty("result/status/value")]
        public string value { get; set; }
        [JsonProperty("result/status/text")]
        public string text { get; set; }
    }

    public class wftStatus
    {
        public Status status = new Status();
    }

    public class AccelaType
    {
        [JsonProperty("result/type/module")]
        public string module { get; set; }
        [JsonProperty("result/type/value")]
        public string value { get; set; }
        [JsonProperty("result/type/type")]
        public string type { get; set; }
        [JsonProperty("result/type/text")]
        public string text { get; set; }
        [JsonProperty("result/type/group")]
        public string group { get; set; }
        [JsonProperty("result/type/alias")]
        public string alias { get; set; }
        [JsonProperty("result/type/subType")]
        public string subType { get; set; }
        [JsonProperty("result/type/category")]
        public string category { get; set; }
        [JsonProperty("result/type/id")]
        public string id { get; set; }
    }
    public class Records
    {
        public string id { get; set; }
        public AccelaType type { get; set; }
        public string description { get; set; }
        public string module { get; set; }
        [JsonProperty("result/status")]
        public Status status { get; set; }
        public string serviceProviderCode { get; set; }
        public long trackingId { get; set; }
        public double jobValue { get; set; }
        // [JsonIgnore]
        public RenewalInfo renewalInfo { get; set; }
        public string openedDate { get; set; }
        public int housingUnits { get; set; }
        public string initiatedProduct { get; set; }
        public string createdBy { get; set; }
        public string statusDate { get; set; }
        public string recordClass { get; set; }
        public string updateDate { get; set; }
        public ConstructionType constructionType { get; set; }
        public int numberOfBuildings { get; set; }
        public double totalJobCost { get; set; }
        public double undistributedCost { get; set; }
        public string customId { get; set; }
        public string value { get; set; }
        public double totalFee { get; set; }
        public double totalPay { get; set; }
        public double balance { get; set; }
        public bool booking { get; set; }
        public bool infraction { get; set; }
        public bool misdemeanor { get; set; }
        public bool offenseWitnessed { get; set; }
        public bool defendantSignature { get; set; }
        public bool publicOwned { get; set; }
        [JsonIgnore]
        public List<CustomForm> customForms { get; set; }



        public List<LocationTransactionDetail> GetLocationTransactionDetailsFromLicense(List<LocationTransaction> loctran,MTData mtdat)
        {
            List<LocationTransactionDetail> lt = new List<LocationTransactionDetail>();

            foreach( LocationTransaction loct in loctran)
            {
                List<LocationTransactionDetail> ltls = new List<LocationTransactionDetail>();
                ltls = mtdat.LocationTransactionDetailList.FindAll(x=> x.TransactionId.ToString() == loct.TransactionId.ToString());
                foreach(LocationTransactionDetail ld in ltls)
                {
                    lt.Add(ld);
                }

            }



            return lt;
        }

        public List<LocationTransaction> GetLocationTransactionFromLicense(string locnum,MTData mtdat)
        {
            List<LocationTransaction> lt = new List<LocationTransaction>();

            lt = mtdat.LocationTransactionList.FindAll(x=> x.LocationNumber.ToString() == locnum);



            return lt;
        }


        public string GetCountyFromLicense(string licenseNumber,List<Location> locs,List<License> lics,List<County> c,Records ar)
        {
            Location Locnumber = new Location();
            string thecountys = string.Empty;

            List<Location> thelocs = new List<Location>();
            List<License> thelics = new List<License>();
            List<County> thecounts = new List<County>();

            if (ar.type.value != "eStop/Master Location/Record/NA")
            {
                thelics = lics.FindAll(x=> x.LicenseNumber.ToString() == licenseNumber);
            }
            else 
            {
                thelics = lics.FindAll(x=> x.LocationNumber.ToString() == licenseNumber);
            }


            foreach(License l in thelics)
            {
                thelocs = locs.FindAll(x=> x.LocationNumber == l.LocationNumber);
                foreach(Location lc in thelocs)
                {
                    thecounts = c.FindAll(x=> x.CountyId == lc.CountyId);
                    foreach(County cc in thecounts)
                    {
                    thecountys = cc.CountyName;
                    }
                }
            }

            return thecountys;
        }

        public Location GetLocationNumberFromLicense(string licenseNumber,List<Location> locs,List<License> lics,Records ar,string curloc)
        {
            Location Locnumber = new Location();
            
            if (ar.type.value != "eStop/Master Location/Record/NA")
            {
                List<Location> thelocs = new List<Location>();
                List<License> thelics = new List<License>();
                thelics = lics.FindAll(x=> x.LicenseNumber.ToString() == licenseNumber);
                foreach(License l in thelics)
                {
                    if (l.LocationNumber.ToString()==curloc)
                    {
                        thelocs = locs.FindAll(x=> x.LocationNumber == l.LocationNumber);
                        foreach(Location lc in thelocs)
                        {
                            Locnumber = lc;
                        }
                    }
                }
            }
            else 
            {
                List<Location> thelocs = new List<Location>();
                List<License> thelics = new List<License>();
                thelics = lics.FindAll(x=> x.LocationNumber.ToString() == licenseNumber);
                foreach(License l in thelics)
                {
                    thelocs = locs.FindAll(x=> x.LocationNumber == l.LocationNumber);
                    foreach(Location lc in thelocs)
                    {
                        Locnumber = lc;
                    }
                }
            }

            return Locnumber;
        }

        public string GetLicenseFromDescription()
        {
            string licnum = string.Empty;
            int indx = description.IndexOf("[");
            string sub = description.Substring(indx);
            sub = sub.Replace("[","");
            licnum = sub.Replace("]","");

            return licnum;
        }

    }

    public class AccelaRecordsRoot
    {
        public List<Records> records { get; set; }
        public int status { get; set; }
    }


/***************************************************/
    public class Root
    {
        public int actualProductionUnit { get; set; }
        public List<Address> addresses { get; set; }
        public DateTime appearanceDate { get; set; }
        public string appearanceDayOfWeek { get; set; }
        public DateTime assignedDate { get; set; }
        public string assignedToDepartment { get; set; }
        public string assignedUser { get; set; }
        public int balance { get; set; }
        public bool booking { get; set; }
        public string closedByDepartment { get; set; }
        public string closedByUser { get; set; }
        public DateTime closedDate { get; set; }
        public DateTime completeDate { get; set; }
        public string completedByDepartment { get; set; }
        public string completedByUser { get; set; }
        public List<ConditionOfApproval> conditionOfApprovals { get; set; }
        public List<Condition> conditions { get; set; }
        public ConstructionType constructionType { get; set; }
        public List<Contact> contacts { get; set; }
        public int costPerUnit { get; set; }
        public string createdBy { get; set; }
        public string createdByCloning { get; set; }
        public List<CustomForm> customForms { get; set; }
        public string customId { get; set; }
        public List<CustomTable> customTables { get; set; }
        public bool defendantSignature { get; set; }
        public string description { get; set; }
        public string enforceDepartment { get; set; }
        public string enforceUser { get; set; }
        public string enforceUserId { get; set; }
        public int estimatedCostPerUnit { get; set; }
        public DateTime estimatedDueDate { get; set; }
        public int estimatedProductionUnit { get; set; }
        public int estimatedTotalJobCost { get; set; }
        public DateTime firstIssuedDate { get; set; }
        public int housingUnits { get; set; }
        public string id { get; set; }
        public int inPossessionTime { get; set; }
        public bool infraction { get; set; }
        public string initiatedProduct { get; set; }
        public string inspectorDepartment { get; set; }
        public string inspectorId { get; set; }
        public string inspectorName { get; set; }
        public int jobValue { get; set; }
        public bool misdemeanor { get; set; }
        public string module { get; set; }
        public string name { get; set; }
        public int numberOfBuildings { get; set; }
        public bool offenseWitnessed { get; set; }
        public DateTime openedDate { get; set; }
        public int overallApplicationTime { get; set; }
        public List<Owner> owners { get; set; }
        public List<Parcel> parcels { get; set; }
        public Priority priority { get; set; }
        public List<Professional> professionals { get; set; }
        public bool publicOwned { get; set; }
        public string recordClass { get; set; }
        public RenewalInfo renewalInfo { get; set; }
        public ReportedChannel reportedChannel { get; set; }
        public ReportedType reportedType { get; set; }
        public DateTime scheduledDate { get; set; }
        public Severity severity { get; set; }
        public string shortNotes { get; set; }
        public Status status { get; set; }
        public StatusReason statusReason { get; set; }
        public string statusType { get; set; }
        public int totalJobCost { get; set; }
        public int totalPay { get; set; }
        public int trackingId { get; set; }
        public Type type { get; set; }
        public int undistributedCost { get; set; }
        public DateTime updateDate { get; set; }
    }

    public class Address
    {
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public AddressTypeFlag addressTypeFlag { get; set; }
        public string city { get; set; }
        public Country country { get; set; }
        public string crossStreetNameStart { get; set; }
        public string crossStreetNameEnd { get; set; }
        public string county { get; set; }
        public string description { get; set; }
        public Direction direction { get; set; }
        public int distance { get; set; }
        public string houseAlphaStart { get; set; }
        public string houseAlphaEnd { get; set; }
        public HouseFractionStart houseFractionStart { get; set; }
        public HouseFractionEnd houseFractionEnd { get; set; }
        public int id { get; set; }
        public string inspectionDistrict { get; set; }
        public string inspectionDistrictPrefix { get; set; }
        public string isPrimary { get; set; }
        public string levelEnd { get; set; }
        public string levelPrefix { get; set; }
        public string levelStart { get; set; }
        public string locationType { get; set; }
        public string neighborhood { get; set; }
        public string neighborhoodPrefix { get; set; }
        public string postalCode { get; set; }
        public RecordId recordId { get; set; }
        public int refAddressId { get; set; }
        public string secondaryStreet { get; set; }
        public int secondaryStreetNumber { get; set; }
        public string serviceProviderCode { get; set; }
        public State state { get; set; }
        public Status status { get; set; }
        public string streetAddress { get; set; }
        public int streetEnd { get; set; }
        public int streetEndFrom { get; set; }
        public int streetEndTo { get; set; }
        public string streetName { get; set; }
        public string streetNameStart { get; set; }
        public string streetNameEnd { get; set; }
        public string streetPrefix { get; set; }
        public int streetStart { get; set; }
        public int streetStartFrom { get; set; }
        public int streetStartTo { get; set; }
        public StreetSuffix streetSuffix { get; set; }
        public StreetSuffixDirection streetSuffixDirection { get; set; }
        public Type type { get; set; }
        public string unitStart { get; set; }
        public string unitEnd { get; set; }
        public UnitType unitType { get; set; }
        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }
    }

    public class ConditionOfApproval
    {
        public ActionbyDepartment actionbyDepartment { get; set; }
        public ActionbyUser actionbyUser { get; set; }
        public ActiveStatus activeStatus { get; set; }
        public string additionalInformation { get; set; }
        public string additionalInformationPlainText { get; set; }
        public string agencyListSQL { get; set; }
        public DateTime appliedDate { get; set; }
        public AppliedbyDepartment appliedbyDepartment { get; set; }
        public AppliedbyUser appliedbyUser { get; set; }
        public string dispAdditionalInformationPlainText { get; set; }
        public bool displayNoticeInAgency { get; set; }
        public bool displayNoticeInCitizens { get; set; }
        public bool displayNoticeInCitizensFee { get; set; }
        public int displayOrder { get; set; }
        public DateTime effectiveDate { get; set; }
        public DateTime expirationDate { get; set; }
        public Group group { get; set; }
        public int id { get; set; }
        public Inheritable inheritable { get; set; }
        public bool isIncludeNameInNotice { get; set; }
        public bool isIncludeShortCommentsInNotice { get; set; }
        public string longComments { get; set; }
        public string name { get; set; }
        public Priority priority { get; set; }
        public string publicDisplayMessage { get; set; }
        public RecordId recordId { get; set; }
        public string resAdditionalInformationPlainText { get; set; }
        public string resolutionAction { get; set; }
        public string serviceProviderCode { get; set; }
        public string serviceProviderCodes { get; set; }
        public Severity severity { get; set; }
        public string shortComments { get; set; }
        public Status status { get; set; }
        public DateTime statusDate { get; set; }
        public string statusType { get; set; }
        public Type type { get; set; }
    }

    public class Condition
    {
        public ActionbyDepartment actionbyDepartment { get; set; }
        public ActionbyUser actionbyUser { get; set; }
        public ActiveStatus activeStatus { get; set; }
        public string additionalInformation { get; set; }
        public string additionalInformationPlainText { get; set; }
        public string agencyListSQL { get; set; }
        public DateTime appliedDate { get; set; }
        public AppliedbyDepartment appliedbyDepartment { get; set; }
        public AppliedbyUser appliedbyUser { get; set; }
        public string dispAdditionalInformationPlainText { get; set; }
        public bool displayNoticeInAgency { get; set; }
        public bool displayNoticeInCitizens { get; set; }
        public bool displayNoticeInCitizensFee { get; set; }
        public int displayOrder { get; set; }
        public DateTime effectiveDate { get; set; }
        public DateTime expirationDate { get; set; }
        public Group group { get; set; }
        public int id { get; set; }
        public Inheritable inheritable { get; set; }
        public bool isIncludeNameInNotice { get; set; }
        public bool isIncludeShortCommentsInNotice { get; set; }
        public string longComments { get; set; }
        public string name { get; set; }
        public Priority priority { get; set; }
        public string publicDisplayMessage { get; set; }
        public RecordId recordId { get; set; }
        public string resAdditionalInformationPlainText { get; set; }
        public string resolutionAction { get; set; }
        public string serviceProviderCode { get; set; }
        public string serviceProviderCodes { get; set; }
        public Severity severity { get; set; }
        public string shortComments { get; set; }
        public Status status { get; set; }
        public DateTime statusDate { get; set; }
        public string statusType { get; set; }
        public Type type { get; set; }
    }


    public class Contact
    {
        public Address address { get; set; }
        public BirthCity birthCity { get; set; }
        [JsonIgnore]
        public DateTime birthDate { get; set; }
        public BirthRegion birthRegion { get; set; }
        public BirthState birthState { get; set; }
        public string businessName { get; set; }
        public string comment { get; set; }
        [JsonIgnore]
        public DateTime deceasedDate { get; set; }
        public string driverLicenseNumber { get; set; }
        public DriverLicenseState driverLicenseState { get; set; }
        public string email { get; set; }
        [JsonIgnore]
        public DateTime endDate { get; set; }
        public string fax { get; set; }
        public string faxCountryCode { get; set; }
        public string federalEmployerId { get; set; }
        public string firstName { get; set; }
        public string fullName { get; set; }
        public Gender gender { get; set; }
        public string id { get; set; }
        public string individualOrOrganization { get; set; }
        public string isPrimary { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string organizationName { get; set; }
        public string passportNumber { get; set; }
        public string phone1 { get; set; }
        public string phone1CountryCode { get; set; }
        public string phone2 { get; set; }
        public string phone2CountryCode { get; set; }
        public string phone3 { get; set; }
        public string phone3CountryCode { get; set; }
        public string postOfficeBox { get; set; }
        public PreferredChannel preferredChannel { get; set; }
        public Race race { get; set; }
        public RecordId recordId { get; set; }
        public string referenceContactId { get; set; }
        public Relation relation { get; set; }
        public Salutation salutation { get; set; }
        public string socialSecurityNumber { get; set; }
        [JsonIgnore]
        public DateTime startDate { get; set; }
        public string stateIdNumber { get; set; }
        public Status status { get; set; }
        public string suffix { get; set; }
        public string title { get; set; }
        public string tradeName { get; set; }
        public AccelaType type { get; set; }
    }

    public class Severity
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class RecordId
    {
        public string customId { get; set; }
        public string id { get; set; }
        public string serviceProviderCode { get; set; }
        public int trackingId { get; set; }
        public string value { get; set; }
    }

    public class Priority
    {
        public string text { get; set; }
        public string value { get; set; }
    }


    public class Inheritable
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class Group
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class AppliedbyUser
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class AppliedbyDepartment
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class ActiveStatus
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class Salutation
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class Relation
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class ActionbyDepartment
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class ActionbyUser
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class UnitType
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class Race
    {
        public string text { get; set; }
        public string value { get; set; }
    }


    public class StreetSuffix
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class StreetSuffixDirection
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class State
    {
        public string text { get; set; }
        public string value { get; set; }
    }


    public class HouseFractionEnd
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class HouseFractionStart
    {
        public string text { get; set; }
        public string value { get; set; }
    }


    public class PreferredChannel
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class Gender
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class DriverLicenseState
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class Direction
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class BirthState
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class StatusReason
    {
        public string text { get; set; }
        public string value { get; set; }
    }


    public class ReportedType
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class Country
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class ReportedChannel
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class AddressTypeFlag
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class BirthCity
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class BirthRegion
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    // public class BirthState
    // {
    //     public string text { get; set; }
    //     public string value { get; set; }
    // }

    public class Professional
    {
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string addressLine3 { get; set; }
        public DateTime birthDate { get; set; }
        public string businessLicense { get; set; }
        public string businessName { get; set; }
        public string businessName2 { get; set; }
        public string city { get; set; }
        public string comment { get; set; }
        public Country country { get; set; }
        public string email { get; set; }
        public DateTime expirationDate { get; set; }
        public string fax { get; set; }
        public string federalEmployerId { get; set; }
        public string firstName { get; set; }
        public string fullName { get; set; }
        public Gender gender { get; set; }
        public string id { get; set; }
        public string isPrimary { get; set; }
        public string lastName { get; set; }
        public DateTime lastRenewalDate { get; set; }
        public string licenseNumber { get; set; }
        public LicenseType licenseType { get; set; }
        public LicensingBoard licensingBoard { get; set; }
        public string middleName { get; set; }
        public DateTime originalIssueDate { get; set; }
        public string phone1 { get; set; }
        public string phone2 { get; set; }
        public string phone3 { get; set; }
        public string postOfficeBox { get; set; }
        public string postalCode { get; set; }
        public RecordId recordId { get; set; }
        public string referenceLicenseId { get; set; }
        public Salutation salutation { get; set; }
        public string serviceProviderCode { get; set; }
        public State state { get; set; }
        public string suffix { get; set; }
        public string title { get; set; }
    }

    public class Parcel
    {
        public string block { get; set; }
        public string book { get; set; }
        public string censusTract { get; set; }
        public string councilDistrict { get; set; }
        public int exemptionValue { get; set; }
        public int gisSequenceNumber { get; set; }
        public string id { get; set; }
        public int improvedValue { get; set; }
        public string isPrimary { get; set; }
        public int landValue { get; set; }
        public string legalDescription { get; set; }
        public string lot { get; set; }
        public string mapNumber { get; set; }
        public string mapReferenceInfo { get; set; }
        public string page { get; set; }
        public string parcel { get; set; }
        public int parcelArea { get; set; }
        public string parcelNumber { get; set; }
        public string planArea { get; set; }
        public string range { get; set; }
        public int section { get; set; }
        public Status status { get; set; }
        public Subdivision subdivision { get; set; }
        public string supervisorDistrict { get; set; }
        public string township { get; set; }
        public string tract { get; set; }
    }


    public class Subdivision
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class LicensingBoard
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class Owner
    {
        public string email { get; set; }
        public string fax { get; set; }
        public string firstName { get; set; }
        public string fullName { get; set; }
        public int id { get; set; }
        public string isPrimary { get; set; }
        public string lastName { get; set; }
        public MailAddress mailAddress { get; set; }
        public string middleName { get; set; }
        public string parcelId { get; set; }
        public string phone { get; set; }
        public string phoneCountryCode { get; set; }
        public RecordId recordId { get; set; }
        public int refOwnerId { get; set; }
        public Status status { get; set; }
        public string taxId { get; set; }
        public string title { get; set; }
        public string type { get; set; }
    }


    public class CustomTable
    {
        public string id { get; set; }
        public List<Row> rows { get; set; }
    }

    public class Row
    {
        public string action { get; set; }
        public Fields fields { get; set; }
        public string id { get; set; }
    }


    public class Fields
    {
        public string id { get; set; }

        [JsonProperty("<aCustomFieldName>")]
        public string aCustomFieldName { get; set; }

        [JsonProperty("<aCustomFieldValue>")]
        public string aCustomFieldValue { get; set; }
    }


    public class MailAddress
    {
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string addressLine3 { get; set; }
        public string city { get; set; }
        public Country country { get; set; }
        public string postalCode { get; set; }
        public State state { get; set; }
    }


    public class LicenseType
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    // public class CustomForm
    // {
    //     public string id { get; set; }
    //     public string fieldname {get; set;}
    //     public string field
    //     public Dictionary<string,string> FiledValue {get; set;}
        
    // }

    public class CustomForm
    {
        public string id { get; set; }
        
        [JsonProperty("<aCustomFieldName>")]
        public string aCustomFieldName { get; set; }

        [JsonProperty("<aCustomFieldValue>")]
        public string aCustomFieldValue { get; set; }



        public string FormJsonString()
        {
            string json = "{\"id\":\""+id+"\",\""+aCustomFieldName;
            json+="\":\""+aCustomFieldValue+"\"}";

            return json;
        }
    }

    public class CustomFormVals
    {

        // public Dictionary<string,string> ;
        public string Field {get; set;}        
        public string Value {get; set;}
    }

//****************************************************
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AssignedToDepartment
    {
        public string value { get; set; }
        public string text { get; set; }
    }

    public class WorkFlowTaskResult
    {
        public string description { get; set; }
        public string serviceProviderCode { get; set; }
        public string id { get; set; }
    }

    public class WorkFlowTask
    {
        public List<WorkFlowTaskResult> result { get; set; }
        public int status { get; set; }
    }


}