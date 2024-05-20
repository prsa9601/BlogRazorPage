using BlogRazorPage.Infrastructure.RazorUtils;
using BlogRazorPage.Models.Post;
using BlogRazorPage.Services.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogRazorPage.Pages.Admin.Blog
{
    public class IndexModel : BaseRazorFilter<PostFilterParam>
    {
        [BindProperty(SupportsGet = true)]
        public PostFilterResult FilterResult { get; set; }

        private readonly IPostService _service;

        public IndexModel(IPostService service)
        {
            _service = service;
        }

        public async Task OnGet(int pageId = 1, int take = 8)
        {
            
            FilterResult = await _service.GetPosts(new PostFilterParam()
            {
                PageId = pageId,
                Take = take
            });
        }
    }
}
