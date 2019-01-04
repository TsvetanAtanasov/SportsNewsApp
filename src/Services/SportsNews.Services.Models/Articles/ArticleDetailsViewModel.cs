namespace SportsNews.Services.Models.Articles
{
    using Data.Models;
    using Mapping;

    public class ArticleDetailsViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string CategoryName { get; set; }
    }
}
