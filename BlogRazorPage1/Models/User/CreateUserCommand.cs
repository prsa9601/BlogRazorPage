namespace BlogRazorPage.Models.User
{
    public class CreateUserCommand
    {
        public CreateUserCommand(string name, string family, string phoneNumber, string password, string userName)
        {
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Password = password;
            UserName = userName;
        }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }

    }
    public class EditUserCommand
    {
        public EditUserCommand(long userId, IFormFile? avatar, string name, string family, string phoneNumber, string userName)
        {
            UserId = userId;
            Avatar = avatar;
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            UserName = userName;
        }
        public long UserId { get; set; }
        public IFormFile? Avatar { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string UserName { get; private set; }
    }
    public class RegisterUserCommand 
    {
        public RegisterUserCommand(string phoneNumber, string password, string userName)
        {
            PhoneNumber = phoneNumber;
            Password = password;
            UserName = userName;
        }
        public string PhoneNumber { get; private set; }
        public string Password { get; private set; }
        public string UserName { get; private set; }
    }
    public class ChangeUserPasswordCommand 
    {
        public long UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string Password { get; set; }
    }
    public class AddUserTokenCommand 
    {
        public AddUserTokenCommand(long userId, string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            UserId = userId;
            HashJwtToken = hashJwtToken;
            HashRefreshToken = hashRefreshToken;
            TokenExpireDate = tokenExpireDate;
            RefreshTokenExpireDate = refreshTokenExpireDate;
            Device = device;
        }
        public long UserId { get; }
        public string HashJwtToken { get; }
        public string HashRefreshToken { get; }
        public DateTime TokenExpireDate { get; }
        public DateTime RefreshTokenExpireDate { get; }
        public string Device { get; }
    }
    public class SetRoleCommand
    {
        public long userId { get; set; }
        public List<long> rolesId { get; set; }
    }

}

