namespace SportsNews.Services.DataServices
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Common;
    using Data.Models;
    using SportsNews.Services.Models.Articles;
    using SportsNews.Services.Models.Home;

    public class ArticlesService : IArticlesService
    {
        private readonly IRepository<Article> articlesRepository;
        private readonly IRepository<Category> categoryRepository;

        public ArticlesService(IRepository<Article> articlesRepository, IRepository<Category> categoryRepository)
        {
            this.articlesRepository = articlesRepository;
            this.categoryRepository = categoryRepository;
        }

        public async Task<int> Create(int categoryId, string content)
        {
            var article = new Article()
            {
               CategoryId = categoryId,
               Content = content
            };

            await this.articlesRepository.AddAsync(article);
            await this.articlesRepository.SaveChangesAsync();

            return article.Id;
        }

        public IEnumerable<ArticleViewModel> GetArticles()
        {
            var articles = this.articlesRepository.All()
                .Select(x => new ArticleViewModel
                {
                    Id = x.Id,
                    Content = x.Content,
                    CategoryName = x.Category.Name
                }).ToList();

            return articles;
        }

        public int GetCount()
        {
            return this.articlesRepository.All().Count();
        }

        public ArticleDetailsViewModel GetArticleById(int id)
        {
            var article = this.articlesRepository.All().Where(x => x.Id == id).Select(x => new ArticleDetailsViewModel
            {
                Content = x.Content,
                CategoryName = x.Category.Name
            }).FirstOrDefault();

            return article;
        }
    }
    
}
