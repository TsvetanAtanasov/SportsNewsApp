using SportsNews.Data.Common;

namespace SportsNews.Data.Models
{
    public class Category : BaseModel<int>
    {
        public string Name { get; set; }
    }
}
