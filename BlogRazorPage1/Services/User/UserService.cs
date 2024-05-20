using BlogRazorPage.Infrastructure;
using BlogRazorPage.Models;
using BlogRazorPage.Models.User;

namespace BlogRazorPage.Services.User
{
    public class UserService : IUserService
    {
        private readonly HttpClient _client;
        private const string ModuleName = "User";

        public UserService(HttpClient client)
        {
            _client = client;
        }
        public Task<UserFilterResult?> GetUsers(UserFilterParams filterParams)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto?> GetCurrentUser()
        {
             var result = await _client.GetFromJsonAsync<ApiResult<UserDto?>>($"{ModuleName}/current");
            return result.Data;
        }

        public async Task<UserDto?> GetById(long userId)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<UserDto?>>($"{ModuleName}/{userId}");
            return result.Data;
        }

        public async Task<ApiResult> ChangePassword(ChangeUserPasswordCommand command)
        {
            var result = await _client.PutAsJsonAsync($"{ModuleName}/ChangePassword", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> Create(CreateUserCommand command)
        {
            var result = await _client.PostAsJsonAsync(ModuleName, command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> EditUserCurrent(EditUserCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.PhoneNumber), "PhoneNumber");

            if (command.Avatar != null)
                formData.Add(new StreamContent(command.Avatar.OpenReadStream()), "Avatar", command.Avatar.FileName);

            formData.Add(new StringContent(command.UserName.ToString()), "UserName");
            formData.Add(new StringContent(command.Name), "Name");
            formData.Add(new StringContent(command.Family), "Family");
            formData.Add(new StringContent(command.PhoneNumber), "PhoneNumber");

            var result = await _client.PutAsync($"{ModuleName}/current", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> Edit(EditUserCommand command)
        {
            var UserId = command.UserId.ToString();
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.PhoneNumber), "PhoneNumber");

            if (command.Avatar != null)
                formData.Add(new StreamContent(command.Avatar.OpenReadStream()), "Avatar", command.Avatar.FileName);

            formData.Add(new StringContent(command.UserName.ToString()), "UserName");
            formData.Add(new StringContent(command.Name), "Name");
            formData.Add(new StringContent(command.Family), "Family");
            formData.Add(new StringContent(command.PhoneNumber), "PhoneNumber");
            formData.Add(new StringContent(UserId), "Id");

            var result = await _client.PutAsync($"{ModuleName}", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ApiResult> SetRole(SetRoleCommand command)
        {
            var result = await _client.PatchAsJsonAsync($"{ModuleName}/setRole", command);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }
        public async Task<UserFilterResult> GetUsersByFilter(UserFilterParams filterParams)
        {
            var url = filterParams.GenerateBaseFilterUrl(ModuleName);
            if (filterParams.UserName != null)
                url += $"&userName={filterParams.UserName}";
            if (filterParams.PhoneNumber != null)
                url += $" &phoneNumber={filterParams.PhoneNumber}";
            if (filterParams.Id != null)
                url += $"&id={filterParams.Id}";
                     
            var result = await _client.GetFromJsonAsync<ApiResult<UserFilterResult>>(url);
            return result.Data;
        }
        public async Task<ApiResult> Delete(long id)
        {
            var result = await _client.DeleteAsync($"{ModuleName}/{id}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

    }
}
