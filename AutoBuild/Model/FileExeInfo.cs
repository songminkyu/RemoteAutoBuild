using AutoBuild.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AutoBuild.Model
{
    public class FileExeInfo
    { 
        public string Path { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]    
        public OrganCategory OrganName {get;set;}

        [JsonConverter(typeof(StringEnumConverter))]      
        public ProductCategory ProductName { get; set; }
    }
}
