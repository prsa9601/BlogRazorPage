using BlogRazorPage.Infrastructure.RazorUtils;
using BlogRazorPage.Models.Role;
using BlogRazorPage.Services.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogRazorPage.Pages.Admin.Role
{
    public class RolesModel : BaseRazorFilter<RoleFilterParam>
    {
        private readonly IRoleService _service;
        public RolesModel(IRoleService service)
        {
            _service = service;
        }
        [BindProperty(SupportsGet = true)]
        public RoleFilterResult FilterResult { get; set; }

        public async Task OnGet(int pageId = 1, int take = 8)
        {
            FilterResult = await _service.GetRoleByFilter(new RoleFilterParam()
            {
                PageId = pageId,
                Take = take
            });
        }
        public void OnPost()
        {
        }
    }
}
