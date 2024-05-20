using BlogRazorPage.Models.User;
using BlogRazorPage.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogRazorPage.Services.User
{
    public interface IUserService
    {
        Task<UserFilterResult?> GetUsers(UserFilterParams filterParams);
        Task<UserDto?> GetCurrentUser();
        Task<UserDto?> GetById(long userId);
        Task<ApiResult> ChangePassword(ChangeUserPasswordCommand command);
        Task<ApiResult> Create(CreateUserCommand command);
        Task<ApiResult> EditUserCurrent(EditUserCommand command);
        Task<ApiResult> Edit(EditUserCommand command);
        Task<ApiResult> SetRole(SetRoleCommand command);
        Task<UserFilterResult> GetUsersByFilter(UserFilterParams filterParams);
        Task<ApiResult> Delete(long id);

    }
}
