using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsNews.Services.Models.Articles
{
    using Data.Models;
    using Mapping;

    public class ArticleSimpleViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Content { get; set; }
    }
}
