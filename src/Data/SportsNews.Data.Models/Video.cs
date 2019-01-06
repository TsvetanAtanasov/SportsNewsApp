namespace SportsNews.Data.Models
{
    using Common;

    public class Video : BaseModel<int>
    {
        public string VideoUrl { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }
    }
}
