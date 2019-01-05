namespace SportsNews.Services.DataServices
{
    using System.Threading.Tasks;

    public interface IImageService
    {
        Task Create(int articleId, string imageUrl);

        Task Delete(int id);
    }
}
