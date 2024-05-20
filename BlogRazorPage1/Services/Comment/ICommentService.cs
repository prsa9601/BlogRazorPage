using BlogRazorPage.Models.Comment;
using BlogRazorPage.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogRazorPage.Services.Comment
{
    public interface ICommentService
    {
        Task<CommentFilterResult?> GetCommentByFilter([FromQuery] CommentFilterParam filterParams);
        Task<CommentFilterResultProduct?> GetPostComments(int pageId = 1, int take = 10, long postId = 0);
        Task<CommentDto?> GetCommentById(long commentId);
        Task<ApiResult> CreateComment(CreateCommentCommand command);
        Task<ApiResult> EditComment(EditCommentCommand command);
        Task<ApiResult> ChangeCommentStatus(ChangeStatusCommentCommand command);
        Task<ApiResult> DeleteComment(long commentId);

    }
}
