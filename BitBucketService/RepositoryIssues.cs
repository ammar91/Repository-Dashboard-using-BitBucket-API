using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitBucketGateway;
using BitBucketService.Helpers;
using Common;
using RestSharp.Extensions;
using SharpBuckets = SharpBucket.V1.Pocos;

namespace BitBucketService
{
    public class RepositoryIssues
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        public string ReportedBy { get; set; }
        public string Kind { get; set; }
        public string Priority { get; set; }
        public string Component { get; set; }
        public string Version { get; set; }
        public DateTime Created { get; set; }
        public List<RepositoryIssues> GetAll(string accountName, string slug)
        {
            var issuesRepository = new BitBucketRepositoryIssue();
            var issues = issuesRepository.GetAll(accountName, slug);
            var mappedIssues = new List<RepositoryIssues>();
            if (issues != null & issues.Count > 0)
            {
                mappedIssues = issues.ConvertAll(BitBucketRepositoryMapper.MapSharpBucketIssuesToRepositoryIssues);
            }

            return mappedIssues;
        }

        public RepositoryIssues GetById(string accountName, string slug, int issueId)
        {
            var issuesRepository = new BitBucketRepositoryIssue();
            var issue = issuesRepository.GetById(accountName, slug, issueId);
            var mappedIssue = new RepositoryIssues();
            if (issue != null)
            {
               mappedIssue = BitBucketRepositoryMapper.MapSharpBucketIssuesToRepositoryIssues(issue);
            }
            return mappedIssue;
        }

        public void Save(RepositoryIssues newIssue, string accountName, string slug)
        {
            var issuesRepository = new BitBucketRepositoryIssue();
            var mappedToSharpBucketRepositoryIssue = BitBucketRepositoryMapper.MapRepositoryIssuesToSharpBucketIssues(newIssue);
            var savedIssue = issuesRepository.Save(mappedToSharpBucketRepositoryIssue, accountName, slug);
            EmailService.NotifyOnIssueCreate(savedIssue.title);
        }

        public void Update(RepositoryIssues updatedIssue, string accountName, string slug)
        {
            var issuesRepository = new BitBucketRepositoryIssue();
            var mappedToSharpBucketRepositoryIssue = BitBucketRepositoryMapper.MapRepositoryIssuesToSharpBucketIssues(updatedIssue);
            issuesRepository.Update(mappedToSharpBucketRepositoryIssue, accountName, slug);
        }
    }
}

