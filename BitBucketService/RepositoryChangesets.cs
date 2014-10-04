using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitBucketGateway;
using BitBucketService.Helpers;
using SharpBuckets = SharpBucket.V1.Pocos;

namespace BitBucketService
{
    public class RepositoryChangesets
    {
        public string Author { get; set; }
        public string Message { get; set; }
        public List<RepositoryChangesets> GetAll(string accountName, string slug)
        {
            var changesetsRepository = new BitBucketRepositoryChangesets();
            var changesets = changesetsRepository.GetAll(accountName, slug);
            var mappedIssues = new List<RepositoryChangesets>();
            if (changesets != null && changesets.Count > 0)
            {
                mappedIssues = changesets.ConvertAll(BitBucketRepositoryMapper.MapSharpBucketChangesetsToRepositoryChangesets);
            }
            return mappedIssues;
        }
    }
}
