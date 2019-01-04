namespace SportsNews.Data.Models
{
    using Common;
    using Web.Areas.Identity.Data;

    public class Comment : BaseModel<int>
    {
        public string Content { get; set; }

        public int UserId { get; set; }

        public SportsNewsUser User { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }
    }
}
