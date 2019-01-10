using Microsoft.EntityFrameworkCore;
using SportsNews.Web.Models;
using System.Threading.Tasks;
using Xunit;

namespace SportsNews.Services.DataServices.Tests
{
    using System.Linq;
    using Data.Models;
    using SportsNews.Data;

    public class CategoriesServiceTests
    {
        [Fact]
        public async Task CreateArticleShouldBeSuccessfull()
        {
            var options = new DbContextOptionsBuilder<SportsNewsContext>()
                .UseInMemoryDatabase(databaseName: "CategoryTests")
                .Options;

            var dbContext = new SportsNewsContext(options);

            var repository = new DbRepository<Category>(dbContext);
            var categoriesService = new CategoriesService(repository);

            await categoriesService.Create("Football", "dsdaasd");
            var count = repository.All().Count();
            Assert.Equal(1, count);
        }

        [Fact]
        public async Task CategoryShouldBeValid()
        {
            var options = new DbContextOptionsBuilder<SportsNewsContext>()
                .UseInMemoryDatabase(databaseName: "CategoryTests2")
                .Options;

            var dbContext = new SportsNewsContext(options);

            var repository = new DbRepository<Category>(dbContext);
            var categoriesService = new CategoriesService(repository);

            await categoriesService.Create("Basket", "dsasddas");
            var categoryId = repository.All().FirstOrDefault().Id;
            var isValid = categoriesService.IsCategoryIdValid(categoryId);
            Assert.True(isValid);
        }
    }
}
