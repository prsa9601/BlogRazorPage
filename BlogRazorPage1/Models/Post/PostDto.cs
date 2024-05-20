using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BlogRazorPage.Models.Post
{
    public class PostDto : BaseDto
    {
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public long CategoryId { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public int Visit { get; set; }
        //public string MetaTag { get; set; }
        public string MetaDescription { get; set; }

    }
    public class PostFilterDataDto : BaseDto
    {
        public string ImageName { get; set; }
        public string CategoryTitle { get; set; }
        public string UserFullName { get; set; }
        public string Title { get; set; }
        public int Visit { get; set; }
        public string Slug { get; set; }
        public string MetaDescription { get; set; }
        public string Description { get; set; }
    }
    public class PostFilterParam : BaseFilterParam
    {
        public string? Slug { get; set; } = "";
        public string? Search { get; set; } = "";
        public PostSearchOrderBy? SearchOrderBy { get; set; }
        public string? Title { get; set; }
        public long CategoryId { get; set; }

    }
    public class PostFilterResult : BaseFilter<PostFilterDataDto, PostFilterParam>
    {
    }

    public enum PostSearchOrderBy
    {
        visit,
        latest

    }
}
