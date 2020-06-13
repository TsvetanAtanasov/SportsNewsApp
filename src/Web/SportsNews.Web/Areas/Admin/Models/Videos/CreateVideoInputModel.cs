namespace SportsNews.Web.Areas.Admin.Models.Videos
{
    using System.ComponentModel.DataAnnotations;

    public class CreateVideoInputModel
    {
        public int ArticleId { get; set; }

        [Required]
        public string VideoUrl { get; set; }
    }
}
