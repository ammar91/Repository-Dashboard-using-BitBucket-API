using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitBucketService;

namespace BitBucketWeb.Controllers
{
    public class IssueController : Controller
    {

        private readonly RepositoryIssues _issuesRepository;

        public IssueController()
        {
            _issuesRepository = new RepositoryIssues();
        }

        // GET: Issue
        public ActionResult Create(string accountName, string slug)
        {
            ViewBag.AccountName = accountName;
            ViewBag.Slug = slug;
            return View();
        }

        [HttpPost]
        public ActionResult Create(RepositoryIssues newIssue, string accountName, string slug)
        {
            try
            {
                _issuesRepository.Save(newIssue, accountName, slug);
                return RedirectToAction("Activity", "Home", new { accountName = accountName, slug = slug });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(string accountName, string slug, int issueId)
        {
            ViewBag.AccountName = accountName;
            ViewBag.Slug = slug;

            var issue = _issuesRepository.GetById(accountName, slug, issueId);
            return View(issue);
        }

        [HttpPost]
        public ActionResult Edit(RepositoryIssues updatedIssue, string accountName, string slug)
        {
            try
            {
                _issuesRepository.Update(updatedIssue, accountName, slug);
                return RedirectToAction("Activity", "Home", new { accountName = accountName, slug = slug });
            }
            catch
            {
                return View();
            }
        }
    }
}