using System.Security;
using BlogRazorPage.Infrastructure;

namespace BlogRazorPage.Models.Role
{
    public class RoleDto : BaseDto
    {
        public string Title { get; set; }
        public List<Permission> Permissions { get; set; }
    }
    public class RoleFilterData : BaseDto
    {
        public string Title { get; set; }
        public List<Permission> permissions { get; set; }
    }
    public class RoleFilterParam : BaseFilterParam
    {
        public string? Title { get; set; }
    }
    public class RoleFilterResult : BaseFilter<RoleFilterData, RoleFilterParam>
    {
    }
}
