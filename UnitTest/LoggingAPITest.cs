using AutoFixture;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Natus.Logging.Service.Controllers;
using Natus.Logging.Service.Models;
using System;
using System.Threading.Tasks;

namespace UnitTest
{
    public class LoggingAPITest
    {
        private readonly IFixture _fixture;
        private readonly Mock<ILogger<LoggerController>> _mockLogger;
        private readonly Mock<IConfiguration> _config;
        private readonly LoggerController _loggerController;

        //private readonly ConfigurationBuilder _configBuilder;
        //private readonly Mock<IConfigurationSection> _configSec;

        public LoggingAPITest()
        {
            _config = new Mock<IConfiguration>();
            _config.SetupGet(x => x[It.Is<string>(s => s == "ContentType")]).Returns("text/plain; charset=utf-8");
            _config.SetupGet(x => x[It.Is<string>(s => s == "response:Info")]).Returns("Info ack - succeded!");
            _config.SetupGet(x => x[It.Is<string>(s => s == "response:Debug")]).Returns("Debug ack - succeded!");
            _config.SetupGet(x => x[It.Is<string>(s => s == "response:Warning")]).Returns("Warning ack - succeded!");
            _config.SetupGet(x => x[It.Is<string>(s => s == "response:Error")]).Returns("Error ack - succeded!");
            _config.SetupGet(x => x[It.Is<string>(s => s == "response:Fatal")]).Returns("Fatal ack - succeded!");
            _config.SetupGet(x => x[It.Is<string>(s => s == "response:UserAction")]).Returns("UserAction ack - succeded!");
            _config.SetupGet(x => x[It.Is<string>(s => s == "response:AuditTrail")]).Returns("AuditTrail ack - succeded!");

            //_configSec = new Mock<IConfigurationSection>();
            //_configSec.Setup(a => a.Key).Returns("text/plain; charset=utf-8, 2, 3, 5, 7, 9");
            //_config.Setup(c => c.GetSection(It.IsAny<String>())).Returns(new Mock<IConfigurationSection>().Object);
            //_config.Setup(a => a.GetSection("MyKey")).Returns(_configSec.Object);

            _fixture = new Fixture();
            _mockLogger = new Mock<ILogger<LoggerController>>();
            _loggerController = new LoggerController(_mockLogger.Object);
        }

        [Fact]
        public void Debug_ControllerApi()
        {
            //- Arrange
            var msg = (_config.Object)["response:Debug"].ToString();

            //- Act
            var res =  _loggerController.Debug(msg);

            //- Assert
            _mockLogger.Verify(
                x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);


            //var errorResult = Assert.IsType<StatusCodeResult>(res);
            //Assert.Equal(500, errorResult.StatusCode);

            //_mockLogger.Verify(x => x.LogError(_config., It.IsAny<Exception>()), Times.Once);
            //var errorResult = Assert.IsType<StatusCodeResult>(result);
            //Assert.Equal(500, errorResult.StatusCode);

            // when:
            //Action a = () => new LoggerController(_mockLogger.Object,_config.Object);
            //Assert.Throws<ArgumentException>(a);

            //// Arrange.
            //var expectedStatusCode = System.Net.HttpStatusCode.OK;
            //var updatedBook = new Book(6, "Awesome book #6 - Updated");
            //var stopwatch = Stopwatch.StartNew();
            //// Act.
            //var response =  _httpClient.PutAsync("/books", TestHelpers.GetJsonStringContent(updatedBook));
            //// Assert.
            //TestHelpers.AssertCommonResponseParts(stopwatch, response, expectedStatusCode);
        }

        [Fact]
        public void Info_ControllerApi()
        {
            //- Arrange
            var msg = (_config.Object)["response:Info"].ToString();

            //- Act
            var res =  _loggerController.Info(msg);

            //- Assert
            _mockLogger.Verify(
                x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);
        }

        [Fact]
        public void Warning_ControllerApi()
        {
            //- Arrange
            var msg = (_config.Object)["response:Warning"].ToString();

            //- Act
            var res =  _loggerController.Warning(msg);

            //- Assert
            _mockLogger.Verify(
                x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);
        }

        [Fact]
        public void Error_ControllerApi()
        {
            //- Arrange
            var msg = (_config.Object)["response:Error"].ToString();

            //- Act
            var res =  _loggerController.Error(msg);

            //- Assert
            _mockLogger.Verify(
                x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);
        }

        [Fact]
        public void Fatal_ControllerApi()
        {
            //- Arrange
            var msg = (_config.Object)["response:Fatal"].ToString();

            //- Act
            var res =  _loggerController.Fatal(msg);

            //- Assert
            _mockLogger.Verify(
                x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);
        }

        [Fact]
        public void UserAction_ControllerApi()
        {
            //- Arrange
            var msg = (_config.Object)["response:UserAction"].ToString();

            //- Act
            var res =  _loggerController.UserAction(GetUserAction());

            //- Assert
            _mockLogger.Verify(
                x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);

            //var employeeDTO = new Employee()
            //{
            //    Id = 1,
            //    Name = "JK",
            //    Desgination = "SDE"
            //};
            //mock.Setup(p => p.GetEmployeeDetails(1)).ReturnsAsync(employeeDTO);
            //EmployeeController emp = new EmployeeController(mock.Object);
            //var result =  emp.GetEmployeeDetails(1);
            //Assert.True(employeeDTO.Equals(result));
        }

        [Fact]
        public void AuditTrail_ControllerApi()
        {
            //- Arrange
            var msg = (_config.Object)["response:AuditTrail"].ToString();

            //- Act
            var res =  _loggerController.AuditTrail(GetAuditTrail());

            //- Assert
            _mockLogger.Verify(
                x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);
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