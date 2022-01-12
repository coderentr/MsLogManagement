using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceA.Dtos;
using ServiceA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceA.Controllers
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
        [HttpGet("RunAService")]
        public IActionResult RunServiceA()
        {
            return Ok("Service a is run !");
        }
        [HttpPost("ExampleDbLog")]
        public IActionResult ExampleDbLog()
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
                _logService.Save_Exception_Log_To_Db(exModel);
                return BadRequest(new { message=ex.Message });
            }
        }
        [HttpPost("ExampleRabbitMqLog")]
        public  IActionResult ExampleRabbitMqLog()
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
                    ServiceName = "AService",
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
