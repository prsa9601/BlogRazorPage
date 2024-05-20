using System.ComponentModel.DataAnnotations;
using BlogRazorPage.Infrastructure;
using BlogRazorPage.Infrastructure.RazorUtils;
using BlogRazorPage.Models.Category;
using BlogRazorPage.Models.Comment;
using BlogRazorPage.Models.Post;
using BlogRazorPage.Models.User;
using BlogRazorPage.Services.Category;
using BlogRazorPage.Services.Comment;
using BlogRazorPage.Services.Post;
using BlogRazorPage.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogRazorPage.Pages.Front.Blog
{

    public class DetailModel : BaseRazorFilter<CommentFilterParamProduct>
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentServiceService;

        public DetailModel(IPostService postService, ICategoryService categoryService, ICommentService commentServiceService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _commentServiceService = commentServiceService;
        }
        [BindProperty]
        [Display(Name = "دیدگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Text { get; set; }
        [BindProperty]
        public long PostId { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public PostFilterResult latestResult { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public PostDto post { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public CommentFilterResultProduct commentResult { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public List<CategoryForShopDto> categories { get; set; }
        
        [BindProperty]
        public string Slug {  get; set; }
        //search,visit,latest

      
      
        public async Task OnGet(string slug ,int pageId = 1)
        {
            Slug = slug;
            categories = await _categoryService.GetCategoriesForShop();
            post = await _postService.GetPostBySlug(slug);
            //latestResult = await _postService.GetPosts(new PostFilterParam()
            //{
            //    Take = 4,
            //    PageId = 1,
            //    SearchOrderBy = PostSearchOrderBy.latest
            //});
            // AjaxTryCatch( () => {  _commentServiceService.GetPostComments(pageId, 6, id); });
            //  return await AjaxTryCatch(() => { return _service.Delete(categoryId); });

             commentResult = await _commentServiceService.GetPostComments(pageId, 6, post.Id);
            //new { id = id };
            //return Page(new {id=id});
        }
 
        [Authorize]
        public async Task<IActionResult> OnPostComment()
        {
            //if (User.Identity.IsAuthenticated == false)
            //{
            //    ErrorAlert("شما لاگین نکردید!");
            //    return RedirectToPage("detail", new { id = PostId });
            //}

            var result = await _commentServiceService.CreateComment(new CreateCommentCommand()
            {
                Text = Text,
                UserId = User.GetUserId(),
                ProductId = PostId
            });
            if (result.IsSuccess == false)
            {
                ErrorAlert(result.MetaData.Message);
                return Page();
            }
            SuccessAlert("نظر شما ثبت شد ، بعد از تایید در سایت نمایش داده می شود");
            return RedirectToPage("detail", new{ slug = post.Slug});

        }
    }
}
