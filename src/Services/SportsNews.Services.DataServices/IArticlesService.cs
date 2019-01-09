using System.Collections.Generic;
using SportsNews.Data.Models;

namespace SportsNews.Services.DataServices
{
    using Models.Home;
    using System.Threading.Tasks;
    using Models.Articles;

    public interface IArticlesService
    {
        IEnumerable<ArticleViewModel> GetArticles();

        int GetCount();

        Task<int> Create(int categoryId, string content, string title);

        TViewModel GetArticleById<TViewModel>(int id);

        IEnumerable<ArticleViewModel> GetAllByCategory(int categoryId);

        Task Update(int articleId, string content, int categoryId);

        Task Delete(int id);
    }
}