using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsNews.Services.DataServices
{
    using Models.Videos;

    public interface IVideosService
    {
        Task Create(int articleId, string videoUrl);

        IEnumerable<VideoViewModel> GetAllByArticleId(int articleId);

        Task Delete(int id);
    }
}
