using BlogRazorPage.Infrastructure;

namespace BlogRazorPage.Models.Role
{
    public class CreateRoleCommand
    {
        public string Title { get; set; }
        public List<Permission> Permissions { get; set; }
    }
    public record class DeleteRoleCommand(long roleId);
    public class EditRoleCommand
    {
        public string Title { get; set; }
        public List<Permission> Permissions { get; set; }
        public long Id { get; set; }
    }


}
