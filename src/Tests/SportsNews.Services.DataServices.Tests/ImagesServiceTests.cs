using Microsoft.EntityFrameworkCore;
using SportsNews.Data;
using SportsNews.Web.Models;
using System.Threading.Tasks;
using Xunit;

namespace SportsNews.Services.DataServices.Tests
{
    using Data.Models;
    using System.Linq;

    public class ImagesServiceTests
    {
        [Fact]
        public async Task CreateArticleShouldBeSuccessfull()
        {
            var options = new DbContextOptionsBuilder<SportsNewsContext>()
                .UseInMemoryDatabase(databaseName: "ImagesTests")
                .Options;

            var dbContext = new SportsNewsContext(options);

            var repository = new DbRepository<Image>(dbContext);
            var imageService = new ImageService(repository);

            await imageService.Create(1, "test");
            var count = repository.All().Count();
            Assert.Equal(1, count);
        }

        [Fact]
        public async Task DeleteShouldBeSuccessfull()
        {
            var options = new DbContextOptionsBuilder<SportsNewsContext>()
                .UseInMemoryDatabase(databaseName: "ImagesTests2")
                .Options;

            var dbContext = new SportsNewsContext(options);

            var repository = new DbRepository<Image>(dbContext);
            var imageService = new ImageService(repository);

            await imageService.Create(1, "dasasd");
            await imageService.Create(1, "dasasd");
            var id = repository.All().FirstOrDefault().Id;
            await imageService.Delete(id);
            var count = repository.All().Count();
            Assert.Equal(1, count);
        }
    }
}
