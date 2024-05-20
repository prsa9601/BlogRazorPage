using BlogRazorPage.Models.Role;
using BlogRazorPage.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogRazorPage.Services.Role
{
    public interface IRoleService
    {
        Task<List<RoleDto?>> GetRoles();
        Task<RoleDto?> GetRoleById(long roleId);
        Task<RoleFilterResult?> GetRoleByFilter(RoleFilterParam filterParams);
        Task<ApiResult> CreateRole(CreateRoleCommand command);
        Task<ApiResult> EditRole(EditRoleCommand command);

        Task<ApiResult> DeleteRole(long id);


    }
}
