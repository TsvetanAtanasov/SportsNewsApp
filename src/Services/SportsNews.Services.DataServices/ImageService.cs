using System.Threading.Tasks;

namespace SportsNews.Services.DataServices
{
    using System.Linq;
    using Data.Common;
    using Data.Models;

    public class ImageService : IImageService
    {
        private readonly IRepository<Image> imageRepository;

        public ImageService(IRepository<Image> imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        public async Task Create(int articleId, string imageUrl)
        {
            var image = new Image()
            {
                ArticleId = articleId,
                Url = imageUrl
            };

            await this.imageRepository.AddAsync(image);
            await this.imageRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var image = this.imageRepository.All().FirstOrDefault(x => x.Id == id);
            this.imageRepository.Delete(image);
            await this.imageRepository.SaveChangesAsync();
        }
    }
}
