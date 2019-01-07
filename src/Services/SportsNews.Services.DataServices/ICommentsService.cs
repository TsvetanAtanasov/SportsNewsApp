namespace SportsNews.Services.DataServices
{
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task Create(int articleId, string userId, string content);

        Task Delete(int id);
    }
}
