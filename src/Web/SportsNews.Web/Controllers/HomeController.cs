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
    using Services.DataServices;
    using Services.Models.Categories;
    using Services.Models.Home;
    using SportsNews.Services.Models;

    public class HomeController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public HomeController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }
        public IActionResult Index()
        {
            //var articles = this.articlesService.GetArticles();
            //var viewModel = new IndexViewModel
            //{
            //    Articles = articles
            //};
            var categories = this.categoriesService.GetAll();
            var viewModel = new AllCategoriesViewModel
            {
                Categories = categories
            };
            return View(viewModel);
        }

        public IActionResult About()
        {
            //ViewData["Message"] = $"My application has {this.articlesService.GetCount()} articles.";

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
