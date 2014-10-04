using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SharpBucket.V1;
using SharpBucket.V1.Pocos;

namespace BitBucketGateway
{
    public class BitBucketUserRepository : BitBucketRepositoryBase
    {
        public List<Repository> GetAll()
        {
            var user = SharpBucket.User();
            var repositories = user.ListRepositories();
            return repositories;
        }
    }
}
