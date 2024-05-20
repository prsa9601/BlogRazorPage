using BlogRazorPage.Models;
using BlogRazorPage.Models.Post;

namespace BlogRazorPage.Services.Post
{
    public class PostService : IPostService
    {
        private readonly HttpClient _client;
        private const string ModuleName = "Post";

        public PostService(HttpClient client)
        {
            _client = client;
        }
        public async Task<ApiResult> CreatePost(CreatePostCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.Slug.ToString()), "Slug");
            formData.Add(new StringContent(command.Description.ToString()), "Description");
            formData.Add(new StringContent(command.CategoryId.ToString()), "CategoryId");
            formData.Add(new StringContent(command.UserId.ToString()), "UserId");
            formData.Add(new StringContent(command.Title.ToString()), "Title");
            formData.Add(new StringContent(command.MetaDescription), "MetaDescription");
            formData.Add(new StreamContent(command.ImageFile.OpenReadStream()), "ImageFile",command.ImageFile.FileName);
            var result = await _client.PostAsync($"{ModuleName}", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> AddImagePost(AddImageCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.PostId.ToString()), "Id");
            formData.Add(new StreamContent(command.ImageFile.OpenReadStream()), "ImageFile", command.ImageFile.FileName);
            var result = await _client.PostAsync($"{ModuleName}", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> EditPost(EditPostCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.Slug.ToString()), "Slug");
            formData.Add(new StringContent(command.Description.ToString()), "Description");
            formData.Add(new StringContent(command.CategoryId.ToString()), "CategoryId");
            formData.Add(new StringContent(command.Id.ToString()), "Id");
            formData.Add(new StringContent(command.Title.ToString()), "Title");
            formData.Add(new StringContent(command.MetaDescription.ToString()), "MetaDescription");
            formData.Add(new StreamContent(command.ImageFile.OpenReadStream()), "ImageFile", command.ImageFile.FileName);
            var result = await _client.PatchAsync($"{ModuleName}", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<PostDto?> GetPostById(long id)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<PostDto?>>($"{ModuleName}/getById/{id}");
            return result?.Data;
        }
        public async Task<PostDto?> GetPostByIdInBack(long id)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<PostDto?>>($"{ModuleName}/getPostByIdInBack/{id}");
            return result?.Data;
        }

        public async Task<PostDto?> GetPostBySlug(string slug)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<PostDto?>>($"{ModuleName}/getBySlug/{slug}");
            return result?.Data;
        }

        public async Task<ApiResult> DeletePost(long id)
        {
            var result = await _client.DeleteAsync($"{ModuleName}/{id}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<PostFilterResult?> GetPosts(PostFilterParam filterParams)
        {
            var url = $"{ModuleName}?PageId={filterParams.PageId}&Take={filterParams.Take}";

            if (filterParams.Title != null)
                url += $"&Title={filterParams.Title}";

            if (filterParams.Slug != null)
                url += $"&Slug={filterParams.Slug}";

            if (filterParams.Search != null)
                url += $"&Search={filterParams.Search}";
            
            if (filterParams.CategoryId != null && filterParams.CategoryId != 0)
                url += $"&CategoryId={filterParams.CategoryId}";

            if (filterParams.SearchOrderBy != null)
                url += $"&SearchOrderBy={filterParams.SearchOrderBy}";

            var result = await _client.GetFromJsonAsync<ApiResult<PostFilterResult>>(url);
            return result?.Data;
        }
    }
}
