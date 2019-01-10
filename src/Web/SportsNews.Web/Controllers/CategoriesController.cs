namespace SportsNews.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Controllers;
    using Services.DataServices;
    using SportsNews.Web.Areas.Admin.Models.Categories;

    public class CategoriesController : BaseController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IArticlesService articlesService;

        public CategoriesController(ICategoriesService categoriesService, IArticlesService articlesService)
        {
            this.categoriesService = categoriesService;
            this.articlesService = articlesService;
        }

        [Authorize]
        public IActionResult Index()
        {
                var categories = this.categoriesService.GetAll().ToList();

                return this.View(categories);
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var articlesInCategory = this.articlesService.GetAllByCategory(id).ToList();

            return this.View(articlesInCategory);
        }
    }
}
