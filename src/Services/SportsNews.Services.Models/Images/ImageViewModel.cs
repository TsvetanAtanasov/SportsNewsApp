namespace SportsNews.Services.Models.Images
{
    using Data.Models;
    using Mapping;

    public class ImageViewModel : IMapFrom<Image>
    { 
        public int Id { get; set; }

        public string Url { get; set; }

        public int ArticleId { get; set; }
    }
}
