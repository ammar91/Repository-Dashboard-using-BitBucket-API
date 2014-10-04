using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBucket.V1;
using SharpBucket.V1.Pocos;

namespace BitBucketGateway
{
    public class BitBucketRepositoryChangesets : BitBucketRepositoryBase
    {
        public List<Changeset> GetAll(string accountName, string slug)
        {
            var repository = SharpBucket.Repositories(accountName, slug);
            var changesets = repository.ListChangeset();
            return changesets.changesets;
        }
    }
}
