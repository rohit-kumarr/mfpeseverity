using AuditSeverityModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditSeverityModule.Providers
{
    public interface ISeverityService
    {
        public AuditResponse GetSeverityResponse(AuditRequest Req);

    }
}
