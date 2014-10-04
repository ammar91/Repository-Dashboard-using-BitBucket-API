using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitBucketService;
using BitBucketWeb.Models;

namespace BitBucketWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repository _repository;
        private readonly RepositoryIssues _issuesRepository;
        private readonly RepositoryChangesets _changesetRepository;
        public HomeController()
        {
            _repository = new Repository();
            _issuesRepository = new RepositoryIssues();
            _changesetRepository = new RepositoryChangesets();
        }
        public ActionResult Index()
        {
            var model = _repository.GetAll();
            return View(model);
        }

        public ActionResult Activity(string accountName, string slug)
        {
            ViewBag.AccountName = accountName;
            ViewBag.Slug = slug;

            var issues = _issuesRepository.GetAll(accountName, slug);
            var changesets = _changesetRepository.GetAll(accountName, slug);

            var activityViewModel = new ActivityViewModel
            {
                RepositoryIssues = issues,
                RepositoryChangesets = changesets
            };

            return View(activityViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}