using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpBucket.V1;

namespace BitBucketGateway
{
    internal class BitBucketInitializer
    {
        internal static SharpBucketV1 Initialize()
        {
            var consumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
            var consumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
            var sharpBucket = new SharpBucketV1();
            sharpBucket.OAuth2LeggedAuthentication(consumerKey, consumerSecret);
            return sharpBucket;
        }
    }
}
