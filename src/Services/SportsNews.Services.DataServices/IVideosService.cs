using System.Threading.Tasks;

namespace SportsNews.Services.DataServices
{
    public interface IVideosService
    {
        Task Create(int articleId, string videoUrl);

        Task Delete(int id);
    }
}
