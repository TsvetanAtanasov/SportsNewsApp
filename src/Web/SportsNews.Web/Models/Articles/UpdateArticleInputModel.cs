using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsNews.Web.Models.Articles
{
    using Data.Models;
    using Services.Mapping;
    using SportsNews.Services.Models.Articles;
    using System.ComponentModel.DataAnnotations;

    public class UpdateArticleInputModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(20)]
        public string Content { get; set; }

        [ValidCategoryId]
        public int CategoryId { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
