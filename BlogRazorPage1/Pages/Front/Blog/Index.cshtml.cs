using BlogRazorPage.Infrastructure.RazorUtils;
using BlogRazorPage.Models.Category;
using BlogRazorPage.Models.Post;
using BlogRazorPage.Services.Category;
using BlogRazorPage.Services.Post;
using Microsoft.AspNetCore.Mvc;

namespace BlogRazorPage.Pages.Front.Blog
{
    [BindProperties(SupportsGet = true)]
    public class IndexModel : BaseRazorFilter<PostFilterParam>
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;

        public IndexModel(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;
        }

        public PostFilterResult FilterResult { get; set; }
        public PostFilterResult latestResult { get; set; }
        public PostFilterResult visitResult { get; set; }
        public List<CategoryForShopDto> categories { get; set; }
        //search,visit,latest
        public async Task OnGet(int pageId = 1, string search = "")
        {
            categories = await _categoryService.GetCategoriesForShop();
            latestResult = await _postService.GetPosts(new PostFilterParam()
            {
                Take = 4,
                PageId = 1,
                SearchOrderBy = PostSearchOrderBy.latest
            });
          
            visitResult = await _postService.GetPosts(new PostFilterParam()
            {
                Take = 4,
                PageId = 1,
                SearchOrderBy = PostSearchOrderBy.visit
            });
            
            FilterResult = await _postService.GetPosts(new PostFilterParam()
            {
                Take = 9,
                PageId = pageId,
                Search = search
            });
        }
    }
}
