using ExceptionLogService.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionLogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private ILogService _logService;
        public LogController(ILogService logService)
        {
            _logService = logService;
        }
        [HttpPost("SaveExceptionLog")]
        public IActionResult SaveLog([FromForm] ExceptionModel model)
        {
            try
            {
                _logService.Save_Exception_Log_To_Db(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
