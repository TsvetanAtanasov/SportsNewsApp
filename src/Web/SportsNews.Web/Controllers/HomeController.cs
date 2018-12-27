using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsNews.Web.Models;

namespace SportsNews.Web.Controllers
{
    using Data.Common;
    using Data.Models;

    public class HomeController : Controller
    {
        private IRepository<Article> articlesRepository;

        public HomeController(IRepository<Article> articlesRepository)
        {
            this.articlesRepository = articlesRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = $"My application has {this.articlesRepository.All().Count()} articles.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
