using System.Collections.Generic;
using SportsNews.Data.Models;

namespace SportsNews.Services.DataServices
{
    using Models.Home;

    public interface IArticlesService
    {
        IEnumerable<ArticleViewModel> GetArticles();

        int GetCount();
    }
}