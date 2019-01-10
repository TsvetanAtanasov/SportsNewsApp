namespace SportsNews.Services.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using DataServices;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using SportsNews.Services.Models.Articles;
    using SportsNews.Services.Models.Home;
    using Web.Models.Articles;

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
        public IActionResult AllByCategory(int id)
        {
            var articles = this.articlesService.GetAllByCategory(id);
            var viewModel = new IndexViewModel
            {
                Articles = articles
            };
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult All()
        {
            var articles = this.articlesService.GetArticles();
            var viewModel = new IndexViewModel
            {
                Articles = articles
            };
            return this.View(viewModel);
        }
        
        public IActionResult Create()
        {
            if (this.User.IsInRole("Administrator"))
            {
                this.ViewData["Categories"] = this.categoriesService.GetAll()
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Name
                    });
                return this.View();
            }

            return this.RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateArticleInputModel input)
        {
            if (this.User.IsInRole("Administrator"))
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View(input);
                }

                var id = await this.articlesService.Create(input.CategoryId, input.Content, input.Title);
                return this.RedirectToAction("Details", new { id = id });
            }
            return this.RedirectToAction("Index", "Home");
        }
        
        public IActionResult Update(int id)
        {
            if (this.User.IsInRole("Administrator"))
            {
                var model = this.articlesService.GetArticles()
                    .Where(x => x.Id == id)
                    .Select(x => new UpdateArticleInputModel
                    {
                        Content = x.Content,
                        CategoryId = x.CategoryId,
                        Title = x.Title
                    }).FirstOrDefault();
                return this.View(model);
            }
            return this.RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateArticleInputModel input)
        {
            if (this.User.IsInRole("Administrator"))
            {

                if (!this.ModelState.IsValid)
                {
                    return this.View(input);
                }

                await this.articlesService.Update(input.Id, input.Content, input.CategoryId, input.Title);
                return this.RedirectToAction("Details", new { id = input.Id });
            }
            return this.RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (this.User.IsInRole("Administrator"))
            {
                await this.articlesService.Delete(id);
            }
            return this.RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var article = this.articlesService.GetArticleById<ArticleDetailsViewModel>(id);
            return this.View(article);
        }
    }
}
