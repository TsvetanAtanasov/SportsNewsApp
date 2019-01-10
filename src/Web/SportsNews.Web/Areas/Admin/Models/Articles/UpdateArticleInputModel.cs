using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsNews.Web.Areas.Admin.Models.Articles
{
    using Data.Models;
    using Services.Mapping;
    using SportsNews.Services.Models.Articles;
    using System.ComponentModel.DataAnnotations;

    public class UpdateArticleInputModel : IMapFrom<Article>
    {
        private const int ContentMinLength = 20;


        public int Id { get; set; }

        [Required]
        [MinLength(ContentMinLength)]
        public string Content { get; set; }

        [ValidCategoryId]
        public int CategoryId { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
