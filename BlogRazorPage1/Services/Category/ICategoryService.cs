using BlogRazorPage.Models.Category;
using BlogRazorPage.Models;

namespace BlogRazorPage.Services.Category
{
    public interface ICategoryService
    {
        Task<ApiResult> Create(CreateCategoryCommand command);
        Task<ApiResult> Edit(EditCategoryCommand command);
        Task<ApiResult> Delete(long id);
        Task<CategoryDto?> GetById(long id);
        Task<List<CategoryDto?>> GetCategories();
        Task<CategoryForShopDto?> GetCategoryForShop(long id);
        Task<List<CategoryForShopDto?>> GetCategoriesForShop();



    }
}
