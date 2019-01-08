using SportsNews.Data.Models;
using SportsNews.Services.Mapping;

namespace SportsNews.Services.Models.Home
{
    using System.Collections.Generic;
    using Images;

    public class ArticleViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<ImageViewModel> Images { get; set; }

        public string VideoUrl { get; set; }
    }
}
