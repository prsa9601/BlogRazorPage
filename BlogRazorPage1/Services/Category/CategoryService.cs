using BlogRazorPage.Models;
using BlogRazorPage.Models.Category;

namespace BlogRazorPage.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _client;
        private const string ModuleName = "Category";

        public CategoryService(HttpClient client)
        {
            _client = client;
        }
        public async Task<ApiResult> Create(CreateCategoryCommand command)
        {
            var result = await _client.PostAsJsonAsync(ModuleName, command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> Edit(EditCategoryCommand command)
        {
            var result = await _client.PatchAsJsonAsync(ModuleName, command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }
          
        public async Task<ApiResult> Delete(long id)
        {
            var result = await _client.DeleteAsync($"{ModuleName}/{id}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<CategoryDto?> GetById(long id)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<CategoryDto?>>($"{ModuleName}/{id}");
            return result?.Data;
        }

        public async Task<List<CategoryDto?>> GetCategories()
        {
            var result = await _client.GetFromJsonAsync<ApiResult<List<CategoryDto?>>>($"{ModuleName}");
            return result?.Data;
        }

        public async Task<CategoryForShopDto?> GetCategoryForShop(long id)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<CategoryForShopDto?>>($"{ModuleName}/CategoriesForShop/{id}");
            return result?.Data;
        }

        public async Task<List<CategoryForShopDto?>> GetCategoriesForShop()
        {
            var result = await _client.GetFromJsonAsync<ApiResult<List<CategoryForShopDto?>>>($"{ModuleName}/CategoriesForShop");
            return result?.Data;
        }
    }
}
