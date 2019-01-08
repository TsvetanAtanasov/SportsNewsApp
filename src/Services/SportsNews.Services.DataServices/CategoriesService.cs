using System.Collections.Generic;
using SportsNews.Services.Models.Categories;

namespace SportsNews.Services.DataServices
{
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Common;
    using Data.Models;

    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categoriesRepository;

        public CategoriesService(IRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public async Task Create(string name, string image)
        {
            var category = new Category()
            {
                Name = name,
                Image = image
            };

            await this.categoriesRepository.AddAsync(category);
            await this.categoriesRepository.SaveChangesAsync();
        }

        public IEnumerable<CategoryIdAndNameViewModel> GetAll()
        {
            var categories = this.categoriesRepository.All().OrderBy(x => x.Name)
                .Select(x => new CategoryIdAndNameViewModel{ Id = x.Id, Name = x.Name }).ToList();
            return categories;
        }

        public bool IsCategoryIdValid(int categoryId)
        {
            return this.categoriesRepository.All().Any(x => x.Id == categoryId);
        }
    }
}
