using BlogRazorPage.Models;
using BlogRazorPage.Models.Comment;
using BlogRazorPage.Models.Post;

namespace BlogRazorPage.Services.Comment
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _client;
        private const string ModuleName = "Comment";

        public CommentService(HttpClient client)
        {
            _client = client;
        }
        public async Task<CommentFilterResult?> GetCommentByFilter(CommentFilterParam filterParams)
        {
            var url = $"{ModuleName}?pageId={filterParams.PageId}&take={filterParams.Take}";

            if (filterParams.UserId != null)
                url += $"userId={filterParams.UserId}";

            if (filterParams.CommentStatus != null)
                url += $"commentStatus={filterParams.CommentStatus}";

            if (filterParams.OrderBy != null)
                url += $"&orderBy={filterParams.OrderBy}";

            if (filterParams.StartDate != null)
                url += $"&StartDate{filterParams.StartDate}";

            if (filterParams.EndDate != null)
                url += $"&EndDate{filterParams.EndDate}";

            if (filterParams.PostId != null)
                url += $"&postId={filterParams.PostId}";

            var result = await _client.GetFromJsonAsync<ApiResult<CommentFilterResult>>(url);
            return result?.Data;
        }

        public async Task<CommentFilterResultProduct?> GetPostComments(int pageId = 1, int take = 10, long postId = 0)
        {
            var url = $"{ModuleName}/getCommentByFilterProduct?pageId={pageId}&take={take}&postId={postId}";

            var result = await _client.GetFromJsonAsync<ApiResult<CommentFilterResultProduct>>(url);
            return result?.Data;
        }

        public async Task<CommentDto?> GetCommentById(long commentId)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<CommentDto?>>($"{ModuleName}/{commentId}");
            return result?.Data;
        }

        public async Task<ApiResult> CreateComment(CreateCommentCommand command)
        {
            var result = await _client.PostAsJsonAsync(ModuleName, command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> EditComment(EditCommentCommand command)
        {
            var result = await _client.PutAsJsonAsync(ModuleName, command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> ChangeCommentStatus(ChangeStatusCommentCommand command)
        {
            var result = await _client.PostAsJsonAsync(ModuleName, command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> DeleteComment(long commentId)
        {
            var result = await _client.DeleteAsync($"{ModuleName}/{commentId}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }
    }
}
