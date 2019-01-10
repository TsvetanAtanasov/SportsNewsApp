using SportsNews.Services.Models.Articles;
using System.ComponentModel.DataAnnotations;

namespace SportsNews.Web.Areas.Admin.Models.Articles
{
    public class CreateArticleInputModel
    {
        private const int ContentMinLength = 20;

        [Required]
        [MinLength(ContentMinLength)]
        public string Content { get; set; }

        [ValidCategoryId]
        public int CategoryId { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
