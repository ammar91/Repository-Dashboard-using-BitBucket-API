using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBuckets = SharpBucket.V1.Pocos;

namespace BitBucketService.Helpers
{
    public static class BitBucketRepositoryMapper
    {

        public static Repository MapSharpBucketRepoToRepository(SharpBuckets.Repository r)
        {
            return new Repository
            {
                Name = r.name,
                Created = DateTime.Parse(r.created_on),
                Owner = r.owner,
                Slug = r.slug
            };
        }

        public static RepositoryIssues MapSharpBucketIssuesToRepositoryIssues(SharpBuckets.Issue issue)
        {
            return new RepositoryIssues
            {
                Id = issue.local_id,
                Title = issue.title,
                Content = issue.content,
                Status = issue.status,
                Kind = issue.metadata.kind,
                Priority = issue.priority,
                ReportedBy = issue.reported_by.username,
                Created = DateTime.Parse(issue.created_on),
            };
        }

        public static SharpBuckets.Issue MapRepositoryIssuesToSharpBucketIssues(RepositoryIssues issue)
        {

            return new SharpBuckets.Issue()
            {
                local_id = issue.Id,
                title = issue.Title,
                content = issue.Content,
                priority = issue.Priority,
                kind = issue.Kind,
                metadata = new SharpBuckets.Metadata { component = issue.Component, kind = issue.Kind, version = issue.Version }
            };
        }

        public static RepositoryChangesets MapSharpBucketChangesetsToRepositoryChangesets(SharpBuckets.Changeset changeset)
        {
            return new RepositoryChangesets
            {
                Author = changeset.author,
                Message = changeset.message,
            };
        }
    }
}
