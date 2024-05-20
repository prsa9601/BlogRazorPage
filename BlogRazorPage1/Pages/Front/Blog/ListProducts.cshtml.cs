using BlogRazorPage.Infrastructure.RazorUtils;
using BlogRazorPage.Models.Category;
using BlogRazorPage.Models.Post;
using BlogRazorPage.Services.Category;
using BlogRazorPage.Services.Post;
using Microsoft.AspNetCore.Mvc;

namespace BlogRazorPage.Pages.Front.Blog
{
    public class ListProductsModel : BaseRazorFilter<PostFilterParam>
    {
        private readonly IPostService _service;
        private readonly ICategoryService _categoryService;

        public ListProductsModel(IPostService service, ICategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }

        [BindProperty(SupportsGet = true)]
        public List<CategoryForShopDto> categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public PostFilterResult latestResult { get; set; }

        [BindProperty(SupportsGet = true)]
        public PostFilterResult result { get; set; }
        public async Task OnGet(long id, int pageId = 1)
        {
          
            result = await _service.GetPosts(new PostFilterParam()
            {
                PageId = pageId,
                Take = 9,
                CategoryId = id
            });
            latestResult = await _service.GetPosts(new PostFilterParam()
            {
                Take = 4,
                PageId = 1,
                SearchOrderBy = PostSearchOrderBy.latest
            });
            categories = await _categoryService.GetCategoriesForShop();

        }
    }
}
