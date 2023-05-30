using System.Threading.Tasks;

namespace Natus.Logging.Client
{
    public interface INatusLogger
    {
        Task<string> Debug(string message);

        Task<string> Info(string message);

        Task<string> Warning(string message);

        Task<string> Error(string message);

        Task<string> Fatal(string message);

        Task<string> UserAction(string productName, string productVersion, 
                        string featureName, string featureVersion, string message);

        Task<string> AuditTrail(string productName, string productVersion, 
                        string featureName, string featureVersion, string userName, string message);
    }
}
