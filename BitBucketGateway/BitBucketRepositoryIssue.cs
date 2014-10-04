using SharpBucket.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBucket.V1.EndPoints;
using SharpBucket.V1.Pocos;

namespace BitBucketGateway
{
    public class BitBucketRepositoryIssue : BitBucketRepositoryBase
    {
        public List<Issue> GetAll(string accountName, string slug)
        {
            var repository = SharpBucket.Repositories(accountName, slug);
            var issues = repository.ListIssues().issues.Where(i => i.status == "open").ToList();
            return issues;
        }

        public Issue GetById(string accountName, string slug, int issueId)
        {
            var repository = SharpBucket.Repositories(accountName, slug);
            var issues = repository.GetIssue(issueId);
            return issues;
        }

        public Issue Save(Issue newIssue, string accountName, string slug)
        {
            var repository = SharpBucket.Repositories(accountName, slug);
            return repository.PostIssue(newIssue);
        }

        public void Update(Issue updatedIssue, string accountName, string slug)
        {
            var repository = SharpBucket.Repositories(accountName, slug);
            repository.PutIssue(updatedIssue);
        }
    }
}
