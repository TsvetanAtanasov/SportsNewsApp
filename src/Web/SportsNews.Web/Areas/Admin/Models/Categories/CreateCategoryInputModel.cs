namespace SportsNews.Web.Areas.Admin.Models.Categories
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCategoryInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
