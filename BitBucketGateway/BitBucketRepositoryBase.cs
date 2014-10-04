using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBucket.V1;

namespace BitBucketGateway
{
    public class BitBucketRepositoryBase
    {
        protected readonly SharpBucketV1 SharpBucket;
        public BitBucketRepositoryBase()
        {
            SharpBucket = BitBucketInitializer.Initialize();
        }
    }
}
