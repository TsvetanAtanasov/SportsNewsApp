using Microsoft.EntityFrameworkCore;
using SportsNews.Data;
using SportsNews.Web.Models;
using System.Threading.Tasks;
using Xunit;

namespace SportsNews.Services.DataServices.Tests
{
    using Data.Models;
    using System.Linq;

    public class CommentsServiceTests
    {
        [Fact]
        public async Task CreateArticleShouldBeSuccessfull()
        {
            var options = new DbContextOptionsBuilder<SportsNewsContext>()
                .UseInMemoryDatabase(databaseName: "CommentsTests")
                .Options;

            var dbContext = new SportsNewsContext(options);

            var repository = new DbRepository<Comment>(dbContext);
            var commentsService = new CommentsService(repository);

            await commentsService.Create(1, "1", "test");
            var count = repository.All().Count();
            Assert.Equal(1, count);
        }

        [Fact]
        public async Task DeleteShouldBeSuccessfull()
        {
            var options = new DbContextOptionsBuilder<SportsNewsContext>()
                    .UseInMemoryDatabase(databaseName: "CommentsTests")
                    .Options;

            var dbContext = new SportsNewsContext(options);

            var repository = new DbRepository<Comment>(dbContext);
            var commentsService = new CommentsService(repository);

            await commentsService.Create(1, "1", "dasasd");
            await commentsService.Create(1, "2", "dasasd");
            var id = repository.All().FirstOrDefault().Id;
            await commentsService.Delete(id);
            var count = repository.All().Count();
            Assert.Equal(2, count);
        }
    }
}
