namespace SportsNews.Services.DataServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Images;

    public interface IImageService
    {
        Task Create(int articleId, string imageUrl);
        
        IEnumerable<ImageViewModel> GetAllByArticleId(int articleId);

        Task Delete(int id);
    }
}
