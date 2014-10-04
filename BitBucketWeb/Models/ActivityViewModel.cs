using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BitBucketService;

namespace BitBucketWeb.Models
{
    public class ActivityViewModel
    {
        public List<RepositoryIssues> RepositoryIssues { get; set; }
        public List<RepositoryChangesets> RepositoryChangesets { get; set; }
    }
}