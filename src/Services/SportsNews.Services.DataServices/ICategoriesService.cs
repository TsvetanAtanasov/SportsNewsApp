namespace SportsNews.Services.DataServices
{
    using System.Collections.Generic;
    using Models.Categories;

    public interface ICategoriesService
    {
        IEnumerable<CategoryIdAndNameViewModel> GetAll();
        bool IsCategoryIdValid(int categoryId);
    }
}
