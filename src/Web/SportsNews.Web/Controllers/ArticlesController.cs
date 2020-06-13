namespace SportsNews.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using DataServices;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using SportsNews.Services.Models.Articles;
    using SportsNews.Services.Models.Home;

    public class ArticlesController : BaseController
    {
        private readonly IArticlesService articlesService;
        private readonly ICategoriesService categoriesService;

        public ArticlesController(IArticlesService articlesService, ICategoriesService categoriesService)
        {
            this.articlesService = articlesService;
            this.categoriesService = categoriesService;
        }
        [Authorize]
        public IActionResult AllByCategory(int id, string searching)
        {
            var articles = this.articlesService.GetAllByCategory(id);
            if (searching != null)
            {
                articles = articles.Where(x => x.Title.Contains(searching, StringComparison.InvariantCultureIgnoreCase));
            }
            var viewModel = new IndexViewModel
            {
                Articles = articles
            };
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult All(string searching)
        {
            var articles = this.articlesService.GetArticles();
            if (searching != null)
            {
                articles = articles.Where(x => x.Title.Contains(searching, StringComparison.InvariantCultureIgnoreCase));
            }
            var viewModel = new IndexViewModel
            {
                Articles = articles
            };
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var article = this.articlesService.GetArticleById<ArticleDetailsViewModel>(id);
            return this.View(article);
        }
    }
}
