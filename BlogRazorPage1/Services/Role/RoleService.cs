using BlogRazorPage.Models;
using BlogRazorPage.Models.Role;

namespace BlogRazorPage.Services.Role
{
    public class RoleService : IRoleService
    {
        private readonly HttpClient _client;
        private const string ModuleName = "Role";

        public RoleService(HttpClient client)
        {
            _client = client;
        }
        public async Task<List<RoleDto?>> GetRoles()
        {
            var result = await _client.GetFromJsonAsync<ApiResult<List<RoleDto?>>>($"{ModuleName}");
            return result?.Data;
        }

        public async Task<RoleDto?> GetRoleById(long roleId)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<RoleDto?>>($"{ModuleName}/{roleId}");
            return result?.Data;
        }

        public async Task<RoleFilterResult?> GetRoleByFilter(RoleFilterParam filterParams)
        {
            var url = $"{ModuleName}/filter?PageId={filterParams.PageId}&Take={filterParams.Take}";

            if (filterParams.Title != null)
                url += $"&title={filterParams.Title}";

            var result = await _client.GetFromJsonAsync<ApiResult<RoleFilterResult?>>(url);
            return result?.Data;
        }

        public async Task<ApiResult> CreateRole(CreateRoleCommand command)
        {
            var result = await _client.PostAsJsonAsync(ModuleName, command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> EditRole(EditRoleCommand command)
        {
            var result = await _client.PutAsJsonAsync(ModuleName, command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> DeleteRole(long id)
        {
            var result = await _client.DeleteAsync($"{ModuleName}/{id}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }
    }
}
