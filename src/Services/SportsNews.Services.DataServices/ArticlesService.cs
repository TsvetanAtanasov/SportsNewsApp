namespace SportsNews.Services.DataServices
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Common;
    using Data.Models;
    using SportsNews.Services.Models.Home;

    public class ArticlesService : IArticlesService
    {
        private readonly IRepository<Article> articlesRepository;

        public ArticlesService(IRepository<Article> articlesRepository)
        {
            this.articlesRepository = articlesRepository;
        }
        public IEnumerable<ArticleViewModel> GetArticles()
        {
            var articles = this.articlesRepository.All()
                .Select(x => new ArticleViewModel
                {
                    Content = x.Content,
                    CategoryName = x.Category.Name
                }).ToList();

            return articles;
        }

        public int GetCount()
        {
            return this.articlesRepository.All().Count();
        }
    }
    
}
