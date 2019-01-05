namespace SportsNews.Services.Models.Articles
{
    using System.Collections.Generic;
    using Comments;
    using Data.Models;
    using Mapping;

    public class ArticleDetailsViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string CategoryName { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
