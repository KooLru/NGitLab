﻿using System;
using System.Collections.Generic;
using System.IO;
using NGitLab.Models;

namespace NGitLab.Impl
{
    public class JobClient : IJobClient
    {
        private readonly API _api;
        private readonly string _jobsPath;

        public JobClient(API api, int projectId)
        {
            _api = api;
            _jobsPath = $"{Project.Url}/{projectId}/jobs";
        }

        public IEnumerable<Job> GetJobs(JobScopeMask scope)
        {
            return GetJobs(new JobQuery { Scope = scope });
        }

        public IEnumerable<Job> GetJobs(JobQuery query)
        {
            var url = _jobsPath;

            if (query.Scope != JobScopeMask.All)
            {
                foreach (Enum value in Enum.GetValues(query.Scope.GetType()))
                {
                    if (query.Scope.HasFlag(value))
                    {
                        url = Utils.AddParameter(url, "scope[]", value.ToString().ToLowerInvariant());
                    }
                }
            }

            if (query.PerPage != null)
                url = Utils.AddParameter(url, "per_page", query.PerPage);

            return _api.Get().GetAll<Job>(url);
        }

        public Job RunAction(int jobId, JobAction action) => _api.Post().To<Job>($"{_jobsPath}/{jobId}/{action.ToString().ToLowerInvariant()}");

        public Job Get(int jobId) => _api.Get().To<Job>($"{_jobsPath}/{jobId}");

        public byte[] GetJobArtifacts(int jobId)
        {
            byte[] result = null;
            _api.Get().Stream($"{_jobsPath}/{jobId}/artifacts", s =>
            {
                using var ms = new MemoryStream();
                s.CopyTo(ms);
                result = ms.ToArray();
            });
            return result;
        }

        public string GetTrace(int jobId)
        {
            var result = string.Empty;
            _api.Get().Stream($"{_jobsPath}/{jobId}/trace", s =>
            {
                result = new StreamReader(s).ReadToEnd();
            });
            return result;
        }
    }
}
