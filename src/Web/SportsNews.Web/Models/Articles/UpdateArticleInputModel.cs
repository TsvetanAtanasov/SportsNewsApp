using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsNews.Web.Models.Articles
{
    using Data.Models;
    using Services.Mapping;

    public class UpdateArticleInputModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }
    }
}
