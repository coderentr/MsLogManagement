using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceB.Dtos;
using ServiceB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly ILogService _logService;
        public ValuesController(ILogService logService)
        {
            _logService = logService;
        }
        [HttpGet("RunBService")]
        public IActionResult RunServiceB()
        {
            return Ok("Service b is run !");
        }
        [HttpPost("SaveLogToLogService")]
        public IActionResult SaveLogToLogService()
        {
            try
            {
                var demoarr = new int[] { 1, 2, 3 };
                return Ok(demoarr[4]);
            }
            catch (Exception ex)
            {
                var exModel = new ExceptionModel
                {
                    ActionName = "ExampleDbLog",
                    Message = ex.Message,
                    ServiceName = "ServiceA",
                    StackTrace = ex.StackTrace,
                };
                _logService.Save_Exception_Log_To_ExceptionLogDb(exModel);
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("ExampleRabbitMqLog")]
        public IActionResult ExampleRabbitMqLog()
        {
            try
            {
                var demoarr = new int[] { 1, 2, 3 };
                return Ok(demoarr[4]);
            }
            catch (Exception ex)
            {
                var exModel = new ExceptionModel
                {
                    ActionName = "ExampleRabbitMqLog",
                    Message = ex.Message,
                    ServiceName = "BService",
                    StackTrace = ex.StackTrace,
                    CreatedBy = "cleims.email ets.",
                    CreatedDate = DateTime.Now,
                };
                _logService.Produce_Exception_Log_To_RabbitMq(exModel);
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
