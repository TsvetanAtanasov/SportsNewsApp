namespace SportsNews.Services.Models.Videos
{
    using Data.Models;
    using Mapping;

    public class VideoViewModel : IMapFrom<Video>
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int ArticleId { get; set; }
    }
}
