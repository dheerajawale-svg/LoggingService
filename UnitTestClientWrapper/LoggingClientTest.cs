using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Natus.Logging.Service.Models;
using Natus.Logging.Client;
using Moq.Protected;
using NSubstitute;
using Moq;
using Microsoft.Extensions.Configuration;

namespace UnitTestClientWrapper
{
    public class LoggingClientTest
    {
        //private readonly Mock<INatusLogger> mock;
        private readonly Mock<HttpMessageHandler> _handlerMock;
        private readonly IConfiguration _configuration;

        public LoggingClientTest()
        {
            var AppSetings = @"{""response"": {
                                    ""Info""        : ""Information ack - succeded!"",
                                    ""Debug""       : ""Debug ack - succeded!"",
                                    ""Warning""     : ""Warning ack - succeded!"",
                                    ""Error""       : ""Error ack - succeded!"",
                                    ""Fatal""       : ""Fatal ack - succeded!"",
                                    ""UserAction""  : ""UserAction ack - succeded!"",
                                    ""AuditTrail""  : ""AuditTrail ack - succeded!"",
                               }}";

            var builder = new ConfigurationBuilder();
            builder.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(AppSetings)));
            _configuration = builder.Build();

            //mock = new Mock<INatusLogger>();
            _handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        }

        [Fact]
        public async Task Info_client()
        {
            //- Arrange
            var message = _configuration.GetValue<string>("response:Info") ?? "";
            HttpResponseMessage result = new HttpResponseMessage();

            //- Define behavior of HttpMessageHandler
            _handlerMock
                .Protected()    //- Access protected SendAsync method in HttpMessageHandler
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(), //- Use ItExpr for 'protected' member
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(result)
                .Verifiable();

            //var fakeHttpMessageHandler = new FakeHttpMessageHandler(new HttpResponseMessage() {
            //    StatusCode = HttpStatusCode.OK,
            //    Content = new StringContent(JsonConvert.SerializeObject(moviecollection), Encoding.UTF8, "application/json")
            //});
            //var fakeHttpClient = new HttpClient(fakeHttpMessageHandler);

            var _httpClientFactory = Substitute.For<IHttpClientFactory>();
            var _httpClient = new HttpClient(_handlerMock.Object);
            _httpClientFactory.CreateClient().Returns(_httpClient);

            var configMock = new Mock<IConfiguration>();
            var post = new NatusLogger(_httpClientFactory, configMock.Object);
            await post.Info(message);

            //- Assert
            //_handlerMock.Verify(r => r.request)
            //Assert.IsNotNull(result);
        }

        [Fact]
        public async Task Debug_client()
        {
            //- Arrange
            var message = _configuration.GetValue<string>("response:Debug") ?? "";
            HttpResponseMessage result = new HttpResponseMessage();

            //- Define behavior of HttpMessageHandler
            _handlerMock
                .Protected()    //- Access protected SendAsync method in HttpMessageHandler
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(), //- Use ItExpr for 'protected' member
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(result)
                .Verifiable();

            var _httpClientFactory = Substitute.For<IHttpClientFactory>();
            var _httpClient = new HttpClient(_handlerMock.Object);
            _httpClientFactory.CreateClient().Returns(_httpClient);

            var configMock = new Mock<IConfiguration>();
            var post = new NatusLogger(_httpClientFactory, configMock.Object);
            await post.Debug(message);
        }

        [Fact]
        public async Task Warning_client()
        {
            //- Arrange
            var message = _configuration.GetValue<string>("response:Warning") ?? "";
            HttpResponseMessage result = new HttpResponseMessage();

            //- Define behavior of HttpMessageHandler
            _handlerMock
                .Protected()    //- Access protected SendAsync method in HttpMessageHandler
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(), //- Use ItExpr for 'protected' member
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(result)
                .Verifiable();

            var _httpClientFactory = Substitute.For<IHttpClientFactory>();
            var _httpClient = new HttpClient(_handlerMock.Object);
            _httpClientFactory.CreateClient().Returns(_httpClient);

            var configMock = new Mock<IConfiguration>();
            var post = new NatusLogger(_httpClientFactory, configMock.Object);
            await post.Warning(message);
        }

        [Fact]
        public async Task Error_client()
        {
            //- Arrange
            var message = _configuration.GetValue<string>("response:Error") ?? "";
            HttpResponseMessage result = new HttpResponseMessage();

            //- Define behavior of HttpMessageHandler
            _handlerMock
                .Protected()    //- Access protected SendAsync method in HttpMessageHandler
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(), //- Use ItExpr for 'protected' member
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(result)
                .Verifiable();

            var _httpClientFactory = Substitute.For<IHttpClientFactory>();
            var _httpClient = new HttpClient(_handlerMock.Object);
            _httpClientFactory.CreateClient().Returns(_httpClient);

            var configMock = new Mock<IConfiguration>();
            var post = new NatusLogger(_httpClientFactory, configMock.Object);
            await post.Error(message);
        }

        [Fact]
        public async Task Fatal_client()
        {
            //- Arrange
            var message = _configuration.GetValue<string>("response:Fatal") ?? "";
            HttpResponseMessage result = new HttpResponseMessage();

            //- Define behavior of HttpMessageHandler
            _handlerMock
                .Protected()    //- Access protected SendAsync method in HttpMessageHandler
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(), //- Use ItExpr for 'protected' member
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(result)
                .Verifiable();

            var _httpClientFactory = Substitute.For<IHttpClientFactory>();
            var _httpClient = new HttpClient(_handlerMock.Object);
            _httpClientFactory.CreateClient().Returns(_httpClient);

            var configMock = new Mock<IConfiguration>();
            var post = new NatusLogger(_httpClientFactory, configMock.Object);
            await post.Fatal(message);
        }

        [Fact]
        public async Task UserAction_client()
        {
            //- Arrange
            var message = _configuration.GetValue<string>("response:UserAction") ?? "";
            HttpResponseMessage result = new HttpResponseMessage();

            //- Define behavior of HttpMessageHandler
            _handlerMock
                .Protected()    //- Access protected SendAsync method in HttpMessageHandler
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(), //- Use ItExpr for 'protected' member
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(result)
                .Verifiable();

            var _httpClientFactory = Substitute.For<IHttpClientFactory>();
            var _httpClient = new HttpClient(_handlerMock.Object);
            _httpClientFactory.CreateClient().Returns(_httpClient);

            var configMock = new Mock<IConfiguration>();
            var post = new NatusLogger(_httpClientFactory, configMock.Object);
            var ua = this.GetUserAction();
            await post.UserAction(ua.ProductName, ua.ProductVersion, ua.FeatureName,
                                    ua.FeatureVersion, ua.Message);
        }

        [Fact]
        public async Task AuditTrail_client()
        {
            //- Arrange
            var message = _configuration.GetValue<string>("response:AuditTrail") ?? "";
            HttpResponseMessage result = new HttpResponseMessage();

            //- Define behavior of HttpMessageHandler
            _handlerMock
                .Protected()    //- Access protected SendAsync method in HttpMessageHandler
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(), //- Use ItExpr for 'protected' member
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(result)
                .Verifiable();

            var _httpClientFactory = Substitute.For<IHttpClientFactory>();
            var _httpClient = new HttpClient(_handlerMock.Object);
            _httpClientFactory.CreateClient().Returns(_httpClient);

            var configMock = new Mock<IConfiguration>();
            var post = new NatusLogger(_httpClientFactory, configMock.Object);
            var at = this.GetAuditTrail();
            await post.AuditTrail(at.ProductName, at.ProductVersion, at.FeatureName,
                                    at.FeatureVersion, at.UserName, at.Message);
        }

        #region DATA
        private AuditTrail GetAuditTrail(string prodName = "default", string prodVer = "0.0", string feature = "default",
                                string featureVer = "0.0", string userN = "default", string msg = "default")
        {
            return new AuditTrail()
            {
                ProductName = prodName,
                ProductVersion = prodVer,
                FeatureName = feature,
                FeatureVersion = featureVer,
                UserName = userN,
                Message = msg
            };
        }
        private UserAction GetUserAction(string prodName = "default", string prodVer = "0.0", string feature = "default",
                                        string featureVer = "0.0", string msg = "default")
        {
            return new UserAction()
            {
                ProductName = prodName,
                ProductVersion = prodVer,
                FeatureName = feature,
                FeatureVersion = featureVer,
                Message = msg
            };
        }
        #endregion DATA
    }
}