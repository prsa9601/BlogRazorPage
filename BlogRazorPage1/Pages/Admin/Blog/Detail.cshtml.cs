using BlogRazorPage.Infrastructure;
using BlogRazorPage.Infrastructure.RazorUtils;
using BlogRazorPage.Models.Comment;
using BlogRazorPage.Models.Post;
using BlogRazorPage.Services.Comment;
using BlogRazorPage.Services.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Net.Mime.MediaTypeNames;

namespace BlogRazorPage.Pages.Admin.Blog
{
    
    public class DetailModel : BaseRazorFilter<CommentFilterParamProduct>
    {
        private readonly IPostService _service;
        private readonly ICommentService _commentServiceService;
        public DetailModel(IPostService service, ICommentService commentServiceService)
        {
            _service = service;
            _commentServiceService = commentServiceService;
        }

        [BindProperty(SupportsGet = true)]
        public PostDto post { get; set; }

        [BindProperty(SupportsGet = true)]
        public CommentFilterResultProduct commentResult { get; set; }
        //public async Task OnGet(long id)
        //{ 
        //    post = await _service.GetPostByIdInBack(id);
        //}
        public async Task OnGet(long id, int pageId = 1)
        {
            post = await _service.GetPostByIdInBack(id);
            //post = await _postService.GetPostById(id);

            commentResult = await _commentServiceService.GetPostComments(pageId, 6, id);
        
        }
    }
}
