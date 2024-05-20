using BlogRazorPage.Models.Post;
using BlogRazorPage.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogRazorPage.Services.Post
{
    public interface IPostService
    {
        Task<ApiResult> CreatePost(CreatePostCommand command);
        Task<ApiResult> AddImagePost(AddImageCommand command);
        Task<ApiResult> EditPost(EditPostCommand command);
        Task<PostDto?> GetPostById(long id);
        Task<PostDto?> GetPostByIdInBack(long id);
        Task<PostDto?> GetPostBySlug(string slug);
        Task<ApiResult> DeletePost(long id);
        Task<PostFilterResult?> GetPosts(PostFilterParam filterParams);


    }
}
