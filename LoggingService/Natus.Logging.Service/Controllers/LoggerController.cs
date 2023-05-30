using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Natus.Logging.Service.Models;

namespace Natus.Logging.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        private readonly ILogger<LoggerController> _logger;
        private readonly IConfiguration _config;

        public LoggerController(ILogger<LoggerController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("Info")]
        public IActionResult Info([FromBody] string message)
        {
            try
            {                
                _logger.LogInformation("{message}", message);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPost]
        [Route("Debug")]
        public IActionResult Debug([FromBody] string message)
        {
            try
            {                
                _logger.LogDebug("{message}", message);
                return Ok();
            }
            catch (Exception ex) { return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString()); }
        }

        [HttpPost]
        [Route("Warning")]
        public IActionResult Warning([FromBody] string message)
        {
            try
            {                
                _logger.LogWarning("{message}", message);
                return Ok();
            }
            catch (Exception ex) { return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString()); }
        }

        [HttpPost]
        [Route("Error")]
        public IActionResult Error([FromBody] string message)
        {
            try
            {                
                _logger.LogError("{message}", message);
                return Ok();
            }
            catch (Exception ex) { return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString()); }
        }

        [HttpPost]
        [Route("Fatal")]
        public IActionResult Fatal([FromBody] string message)
        {
            try
            {                
                _logger.LogCritical("{message}", message);
                return Ok();
            }
            catch (Exception ex) { return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString()); }
        }

        [HttpPost]
        [Route("UserAction")]
        public IActionResult UserAction([FromBody] UserAction action)
        {
            try
            {                
                _logger.LogInformation("{@action}", JsonSerializer.Serialize(action));

                return Ok();
            }
            catch (Exception ex) { return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString()); }
        }

        [HttpPost]
        [Route("AuditTrail")]
        public IActionResult AuditTrail([FromBody] AuditTrail trail)
        {
            try
            {                
                _logger.LogInformation("{@trail}", JsonSerializer.Serialize(trail));

                return Ok();
            }
            catch (Exception ex) { return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString()); }
        }
    }
}