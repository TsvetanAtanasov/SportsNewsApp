namespace SportsNews.Data.Models
{
    using Common;

    public class Image : BaseModel<int>
    {
        public string ImageUrl { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }
    }
}
