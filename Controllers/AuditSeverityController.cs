using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditSeverityModule.Models;
using AuditSeverityModule.Providers;
using AuditSeverityModule.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuditSeverityModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditSeverityController : ControllerBase
    {
        private ISeverityService severityService;
        public AuditSeverityController(ISeverityService severityService)
        {
            this.severityService = severityService;
        }

        [HttpGet]
        public IActionResult GetProjectExecutionStatus()
        { 
            return Ok("SUCCESS");
        }



        [HttpPost]
        public IActionResult GetProjectExecutionStatus([FromBody] AuditRequest request)
        {

            if (request == null)
                return BadRequest();

            else if (request.Auditdetails.Type != "Internal" && request.Auditdetails.Type != "SOX")
                return BadRequest("Wrong Audit Type");
            else
            try
            {
                AuditResponse Response = severityService.GetSeverityResponse(request);
                return Ok(Response);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }

        }


    }
}
