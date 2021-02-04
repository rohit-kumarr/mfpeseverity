﻿using AuditSeverityModule.Models;
using AuditSeverityModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AuditSeverityModule.Providers
{
    public class SeverityService : ISeverityService
    {
        private ISeverityRepo severityRepo;
        public SeverityService(ISeverityRepo severityRepo)
        {
            this.severityRepo = severityRepo;
        }
        public AuditResponse GetSeverityResponse(AuditRequest Req)
        {
            try
            {
                List<AuditBenchmark> listFromRepository = severityRepo.Response();

                int count = 0;
                int acceptableNo = 0;

                if (Req.Auditdetails.Questions.Question1 == false)
                    count++;
                if (Req.Auditdetails.Questions.Question2 == false)
                    count++;
                if (Req.Auditdetails.Questions.Question3 == false)
                    count++;
                if (Req.Auditdetails.Questions.Question4 == false)
                    count++;
                if (Req.Auditdetails.Questions.Question5 == false)
                    count++;

                if (Req.Auditdetails.Type == listFromRepository[0].AuditType)
                    acceptableNo = listFromRepository[0].BenchmarkNoAnswers;
                else if (Req.Auditdetails.Type == listFromRepository[1].AuditType)
                    acceptableNo = listFromRepository[1].BenchmarkNoAnswers;


                Random randomNumber = new Random();


                AuditResponse auditResponse = new AuditResponse();
                if (Req.Auditdetails.Type == "Internal" && count <= acceptableNo)
                {
                    auditResponse.AuditId = randomNumber.Next();
                    auditResponse.ProjectExexutionStatus = Repository.SeverityRepo.ActionToTakeAndStatus[0].ProjectExexutionStatus;
                    auditResponse.RemedialActionDuration = Repository.SeverityRepo.ActionToTakeAndStatus[0].RemedialActionDuration;
                }
                else if (Req.Auditdetails.Type == "Internal" && count > acceptableNo)
                {
                    auditResponse.AuditId = randomNumber.Next();
                    auditResponse.ProjectExexutionStatus = Repository.SeverityRepo.ActionToTakeAndStatus[1].ProjectExexutionStatus;
                    auditResponse.RemedialActionDuration = Repository.SeverityRepo.ActionToTakeAndStatus[1].RemedialActionDuration;
                }
                else if (Req.Auditdetails.Type == "SOX" && count <= acceptableNo)
                {
                    auditResponse.AuditId = randomNumber.Next();
                    auditResponse.ProjectExexutionStatus = Repository.SeverityRepo.ActionToTakeAndStatus[0].ProjectExexutionStatus;
                    auditResponse.RemedialActionDuration = Repository.SeverityRepo.ActionToTakeAndStatus[0].RemedialActionDuration;
                }
                else if (Req.Auditdetails.Type == "SOX" && count > acceptableNo)
                {
                    auditResponse.AuditId = randomNumber.Next();
                    auditResponse.ProjectExexutionStatus = Repository.SeverityRepo.ActionToTakeAndStatus[2].ProjectExexutionStatus;
                    auditResponse.RemedialActionDuration = Repository.SeverityRepo.ActionToTakeAndStatus[2].RemedialActionDuration;
                }


                return auditResponse;
            }
            catch(Exception ex)
            {
                return null;
            }

            
        }
    }
}
