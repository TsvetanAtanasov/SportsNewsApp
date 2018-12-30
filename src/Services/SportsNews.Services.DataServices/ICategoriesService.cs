namespace SportsNews.Services.DataServices
{
    using System.Collections.Generic;
    using Models.Categories;

    public interface ICategoriesService
    {
        IEnumerable<IdAndNameViewModel> GetAll();
        bool IsCategoryIdValid(int categoryId);
    }
}
