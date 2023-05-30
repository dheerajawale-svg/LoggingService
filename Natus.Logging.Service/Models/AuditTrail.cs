namespace Natus.Logging.Service.Models
{
    public class AuditTrail
    {
        public string ProductName { get; set; }
        
        public string ProductVersion { get; set; }
        
        public string FeatureName { get; set; }

        public string FeatureVersion { get; set; }

        public string UserName { get; set; }
        
        public string Message { get; set; }
    }
}
