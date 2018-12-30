namespace SportsNews.Services.Models.Articles
{
    using Data.Models;
    using Mapping;

    public class ArticleDetailsViewModel : IMapFrom<Article>
    {
        public string Content { get; set; }

        public string CategoryName { get; set; }
    }
}
