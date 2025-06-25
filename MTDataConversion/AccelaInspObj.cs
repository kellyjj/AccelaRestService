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

    public class InspRoot
    {
        public RecordId recordId { get; set; }
        public inspType type { get; set; }
        public string unitNumber { get; set; }
        public int units { get; set; }
        public string vehicleId { get; set; }
        public string completedDate {get; set;}
    }

    public class inspType
    {
        public string value { get; set; }
        public int id { get; set; }
        public string group { get; set; }
        public string text { get; set; }
    }


}