using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Natus.Logging.Client
{
    public class NatusLogger : INatusLogger
    {
        private readonly HttpClient _httpClient;

        #region Constants

        //public const string _baseURL = "https://localhost:7116/";      //- As Local
        //public const string _baseURL = "https://localhost:5000/";    //- As Windows Service - Deployed
        
        private const string ServiceSubPath = "api/Logger/";
        private const string MIMEType = "application/json";

        private const string debug = ServiceSubPath + "Debug";
        private const string info = ServiceSubPath + "Info";
        private const string warning = ServiceSubPath + "Warning";
        private const string error = ServiceSubPath + "Error";
        private const string fatal = ServiceSubPath + "Fatal";
        private const string userAction = ServiceSubPath + "UserAction";
        private const string auditTrail = ServiceSubPath + "AuditTrail";

        #endregion

        public NatusLogger(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            var baseUrl = configuration["ServiceUrl"];
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(baseUrl);
        }

        public StringContent JConvert(String content)
        {            
            return new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, MIMEType);
        }

        public async Task<string>  Info(string message)
        {
            var res = await _httpClient.PostAsync(info, JConvert(message));
            string output = await res.Content?.ReadAsStringAsync();

            return output;
        }

        public async Task<string>  Debug(string message)
        {
            var res = await _httpClient.PostAsync(debug, JConvert(message));
            string output = await res.Content?.ReadAsStringAsync();

            return output;
        }

        public async Task<string>  Warning(string message)
        {
            var res = await _httpClient.PostAsync(warning, JConvert(message));
            string output = await res.Content?.ReadAsStringAsync();

            return output;
        }

        public async Task<string>  Error(string message)
        {
            var res = await _httpClient.PostAsync(error, JConvert(message));
            string output = await res.Content?.ReadAsStringAsync();

            return output;
        }

        public async Task<string>  Fatal(string message)
        {
            var res = await _httpClient.PostAsync(fatal, JConvert(message));
            string output = await res.Content?.ReadAsStringAsync();

            return output;
        }

        public async Task<string>  UserAction(string productName, string productVersion, string featureName, string featureVersion, string message)
        {
            var jsonMesssage = JsonSerializer.Serialize(new
            {
                ProductName = productName,
                ProductVersion = productVersion,
                FeatureName = featureName,
                FeatureVersion = featureVersion,
                Message = message
            });

            var res = await _httpClient.PostAsync(userAction, JConvert(jsonMesssage));
            string output = await res.Content?.ReadAsStringAsync();

            return output;
        }

        public async Task<string>  AuditTrail(string productName, string productVersion, string featureName, string featureVersion, string userName, string message)
        {
            var jsonMesssage = JsonSerializer.Serialize(new
            {
                ProductName = productName,
                ProductVersion = productVersion,
                FeatureName = featureName,
                FeatureVersion = featureVersion,
                UserName = userName,
                Message = message
            });

            var res = await _httpClient.PostAsync(auditTrail, JConvert(jsonMesssage));
            string output = await res.Content?.ReadAsStringAsync();

            return output;
        }
    }
}
