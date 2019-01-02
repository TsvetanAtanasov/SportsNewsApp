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

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            var categories = this.categoriesService.GetAll().ToList();
            
            return this.View(categories);
        }

        public IActionResult Details(int id)
        {
           throw new NotImplementedException();
        }
    }
}
