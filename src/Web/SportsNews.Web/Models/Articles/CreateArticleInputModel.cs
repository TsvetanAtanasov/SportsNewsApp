using System.ComponentModel.DataAnnotations;

namespace SportsNews.Services.Models.Articles
{
    public class CreateArticleInputModel
    {
        [Required]
        [MinLength(20)]
        public string Content { get; set; }

        [ValidCategoryId]
        public int CategoryId { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
