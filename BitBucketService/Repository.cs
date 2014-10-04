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
    public class Repository
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Slug { get; set; }
        public DateTime Created { get; set; }

        public List<Repository> GetAll()
        {
            var userRepository = new BitBucketUserRepository();
            var repositories = userRepository.GetAll();
            var mappedRepositories = new List<Repository>();
            if (repositories != null & repositories.Count > 0)
            {
                mappedRepositories = repositories.ConvertAll(BitBucketRepositoryMapper.MapSharpBucketRepoToRepository);
            }

            return mappedRepositories;
        }


    }
}
