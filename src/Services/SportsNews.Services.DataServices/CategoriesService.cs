using System.Collections.Generic;
using SportsNews.Services.Models.Categories;

namespace SportsNews.Services.DataServices
{
    using System.Linq;
    using Data.Common;
    using Data.Models;

    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categoriesRepository;

        public CategoriesService(IRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<IdAndNameViewModel> GetAll()
        {
            var categories = this.categoriesRepository.All().OrderBy(x => x.Name)
                .Select(x => new IdAndNameViewModel{ Id = x.Id, Name = x.Name }).ToList();
            return categories;
        }

        public bool IsCategoryIdValid(int categoryId)
        {
            return this.categoriesRepository.All().Any(x => x.Id == categoryId);
        }
    }
}
