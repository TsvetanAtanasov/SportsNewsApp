using System;

namespace SportsNews.Services.DataServices.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Common;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Moq;
    using Web.Models;
    using Xunit;

    public class ArticlesServiceTests
    {
        [Fact]
        public void GetCountShouldReturnCorrectNumber()
        {
            var articlesRepository = new Mock<IRepository<Article>>();
            articlesRepository.Setup(r => r.All()).Returns(new List<Article>
            {
                new Article(),
                new Article(),
                new Article(),
            }.AsQueryable());

            var service = new ArticlesService(articlesRepository.Object, null);
            Assert.Equal(3, service.GetCount());
            articlesRepository.Verify(x => x.All(), Times.Once);
        }

        [Fact]
        public async Task GetCountShouldReturnCorrectNumberUsingDbContext()
        {
            var options = new DbContextOptionsBuilder<SportsNewsContext>()
                .UseInMemoryDatabase(databaseName: "Find_User_Database")
                .Options;

            var dbContext = new SportsNewsContext(options);
            dbContext.Articles.Add(new Article());
            dbContext.Articles.Add(new Article());
            dbContext.Articles.Add(new Article());
            await dbContext.SaveChangesAsync();

            var repository = new DbRepository<Article>(dbContext);
            var articlesService = new ArticlesService(repository, null);

            var count = articlesService.GetCount();
            Assert.Equal(3, count);

        }

        [Fact]
        public async Task CreateArticleShouldBeSuccessfull()
        {
            var options = new DbContextOptionsBuilder<SportsNewsContext>()
                .UseInMemoryDatabase(databaseName: "Find_User_Database2")
                .Options;

            var dbContext = new SportsNewsContext(options);

            var repository = new DbRepository<Article>(dbContext);
            var articlesService = new ArticlesService(repository, null);

            await articlesService.Create(1, "sdsda", "dasasd");
            var count = articlesService.GetCount();

            Assert.Equal(1, count);
        }

        [Fact]
        public async Task DeleteArticleShouldBeSuccessfull()
        {
            var options = new DbContextOptionsBuilder<SportsNewsContext>()
                .UseInMemoryDatabase(databaseName: "Find_User_Database3")
                .Options;

            var dbContext = new SportsNewsContext(options);
            var repository = new DbRepository<Article>(dbContext);
            var articlesService = new ArticlesService(repository, null);

            await articlesService.Create(1, "sdsda", "dasasd");
            await articlesService.Create(1, "sdsda", "dasasd");
            await articlesService.Create(1, "sdsda", "dasasd");
            var id = repository.All().FirstOrDefault().Id;
            await articlesService.Delete(id); 
            var count = repository.All().Count();
            Assert.Equal(2, count);
        }

        [Fact]
        public async Task UpdateArticleShouldBeSuccessfull()
        {
            var options = new DbContextOptionsBuilder<SportsNewsContext>()
                .UseInMemoryDatabase(databaseName: "Find_User_Database4")
                .Options;

            var dbContext = new SportsNewsContext(options);
            var repository = new DbRepository<Article>(dbContext);
            var articlesService = new ArticlesService(repository, null);

            await articlesService.Create(1, "sdsda", "dasasd");
            var id = repository.All().FirstOrDefault().Id;
            await articlesService.Update(id, "Changed", 2,"Ok");
            var article = repository.All().FirstOrDefault();
            Assert.Equal("Changed", article.Content);
        }
    }
}
