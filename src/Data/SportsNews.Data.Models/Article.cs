using SportsNews.Data.Common;

namespace SportsNews.Data.Models
{
    public class Article : BaseModel<int>
    {
        public string Content { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
