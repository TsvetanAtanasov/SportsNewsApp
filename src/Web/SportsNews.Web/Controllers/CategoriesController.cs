namespace SportsNews.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Controllers;
    using Services.DataServices;
    using SportsNews.Web.Models.Categories;

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
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.categoriesService.Create(input.Name);
            return this.RedirectToAction("Index","Home");
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
