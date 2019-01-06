using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsNews.Services.DataServices
{
    using Data.Models;
    using SportsNews.Data.Common;

    public class VideosService : IVideosService
    {
        private readonly IRepository<Video> videosRepository;

        public VideosService(IRepository<Video> videosRepository)
        {
            this.videosRepository = videosRepository;
        }
        public async Task Create(int articleId, string videoUrl)
        {
            var image = new Video()
            {
                ArticleId = articleId,
                VideoUrl = videoUrl
            };

            await this.videosRepository.AddAsync(image);
            await this.videosRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var image = this.videosRepository.All().FirstOrDefault(x => x.Id == id);
            this.videosRepository.Delete(image);
            await this.videosRepository.SaveChangesAsync();
        }
    }
}
