using BlogRazorPage.Infrastructure;
using BlogRazorPage.Infrastructure.RazorUtils;
using BlogRazorPage.Models.Role;
using BlogRazorPage.Models.User;
using BlogRazorPage.Pages.Front.Blog;
using BlogRazorPage.Services.Role;
using BlogRazorPage.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogRazorPage.Pages.Admin.User
{
    [Authorize]
    public class SetRolesModel : BaseRazorPage
    {
        private readonly IRoleService _service;
        private readonly IUserService _userService;
        
        public SetRolesModel(IRoleService service, IUserService userService)
        {
            _service = service;
            _userService = userService;
        }
        // public List<RoleDto> roles { get; set; }
        [BindProperty]
        public long Id { get; set; }

        [BindProperty]
        public List<UserRoleDto> role { get; set; }
        public async Task OnGet(long id)
        {
            Id = id;
            // roles = await _service.GetRoles();
            var users = await _userService.GetById(id);
            role = users.Roles;
        }
        public async Task<IActionResult> OnPost(List<long> role)
        {
            var result = await _userService.SetRole(new Models.User.SetRoleCommand()
            {
                //userId = User.GetUserId(),
                userId = Id,
                rolesId = role
            });
            return RedirectAndShowAlert(result,Redirect("Index"));
        }
    }
}
