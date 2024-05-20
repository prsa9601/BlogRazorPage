using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using BlogRazorPage.Infrastructure;
using BlogRazorPage.Infrastructure.RazorUtils;
using BlogRazorPage.Models.Role;
using BlogRazorPage.Services.Role;

namespace BlogRazorPage.Pages.Admin.Role
{
    public class EditModel : BaseRazorPage
    {
        private readonly IRoleService _roleService;

        public EditModel(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [BindProperty(SupportsGet = true)]
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Title { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<Permission> Permissions { get; set; }

        public async Task<IActionResult> OnGet(long id)
        {
            var role = await _roleService.GetRoleById(id);
            if (role == null)
                return RedirectToPage("Roles");

            Title = role.Title;
            Permissions = role.Permissions;
            return Page();
        }

        public async Task<IActionResult> OnPost(long id, List<Permission> permissions)
        {
            var result = await _roleService.EditRole(new EditRoleCommand()
            {
                Title = Title,
                Permissions = permissions,
                Id = id
            });

            // return RedirectAndShowAlert(result, RedirectToPage("Roles"), RedirectToPage("Edit", new { id }));
            return RedirectAndShowAlert(result, RedirectToPage("roles"));
        }
    }
}