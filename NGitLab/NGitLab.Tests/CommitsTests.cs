﻿using NGitLab.Models;
using NUnit.Framework;

namespace NGitLab.Tests
{
    public class CommitsTests
    {
        private static bool _ciEnabled;
        private ICommitClient _commits;

        [OneTimeSetUp]
        public void FixtureSetup()
        {
            _commits = Initialize.GitLabClient.GetCommits(Initialize.UnitTestProject.Id);
            EnableCiOnTestProject();
        }
        
        public static void EnableCiOnTestProject()
        {
            var projectId = Initialize.UnitTestProject.Id;

            if (!_ciEnabled)
            {
                const string yml =
                    @"
build:
  script: 
  - echo OK
  artifacts:
    untracked: true
    expire_in: 1h

manual:
  when: manual
  script: 
  - echo manual OK
";

                var repository = Initialize.GitLabClient.GetRepository(projectId);
                repository.Files.Create(new FileUpsert
                {
                    Path = ".gitlab-ci.yml",
                    Branch = "master",
                    CommitMessage = "Enable ci",
                    RawContent = yml
                });

                Initialize.GitLabClient.Runners.EnableRunner(projectId, new RunnerId(RunnerTests.GetDefaultRunner().Id));
                _ciEnabled = true;                
            }            
        }
    }
}