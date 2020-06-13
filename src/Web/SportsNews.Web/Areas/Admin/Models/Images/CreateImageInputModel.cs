namespace SportsNews.Web.Areas.Admin.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CreateImageInputModel
    {
        public int ArticleId { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
