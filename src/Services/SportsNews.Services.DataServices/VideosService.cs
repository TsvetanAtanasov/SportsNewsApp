using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsNews.Services.DataServices
{
    using Data.Models;
    using SportsNews.Data.Common;
    using SportsNews.Services.Mapping;
    using SportsNews.Services.Models.Videos;

    public class VideosService : IVideosService
    {
        private readonly IRepository<Video> videosRepository;

        public VideosService(IRepository<Video> videosRepository)
        {
            this.videosRepository = videosRepository;
        }
        public async Task Create(int articleId, string videoUrl)
        {
            var video = new Video()
            {
                ArticleId = articleId,
                Url = videoUrl
            };

            await this.videosRepository.AddAsync(video);
            await this.videosRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var video = this.videosRepository.All().FirstOrDefault(x => x.Id == id);
            this.videosRepository.Delete(video);
            await this.videosRepository.SaveChangesAsync();
        }

        public IEnumerable<VideoViewModel> GetAllByArticleId(int articleId)
        {
            var videos = this.videosRepository.All()
                .Where(x => x.ArticleId == articleId)
                .To<VideoViewModel>().ToList();

            return videos;
        }
    }
}
