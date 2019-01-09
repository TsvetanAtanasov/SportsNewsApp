using SportsNews.Data.Models;
using SportsNews.Services.Mapping;

namespace SportsNews.Services.Models.Home
{
    using System.Collections.Generic;
    using System.Linq;
    using Images;
    using Microsoft.Extensions.FileProviders;

    public class ArticleViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ShortContent
        {
            get
            {
                if (Content.Length > 200)
                {
                    return $"{Content.Substring(0, 150)} ...";
                }

                return Content;
            }
        }

        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<ImageViewModel> Images { get; set; }

        public string VideoUrl { get; set; }
    }
}
