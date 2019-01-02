namespace SportsNews.Web.Controllers
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Services.Controllers;
    using Services.DataServices;

    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IArticlesService articlesService;

        public CategoriesController(ICategoriesService categoriesService, IArticlesService articlesService)
        {
            this.categoriesService = categoriesService;
            this.articlesService = articlesService;
        }

        public IActionResult Index()
        {
            var categories = this.categoriesService.GetAll().ToList();
            
            return this.View(categories);
        }

        public IActionResult Details(int id)
        {
            var articlesInCategory = this.articlesService.GetAllByCategory(id).ToList();

            return this.View(articlesInCategory);
        }
    }
}
