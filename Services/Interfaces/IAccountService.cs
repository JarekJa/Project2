using Project2.Models.Account;
using Project2.Models.UserData;


namespace Project2.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<bool> LoginUser(UserLogin user);
        public Task LoginOutUser();
        public Task<UserData?> GetUser();
        public Task<bool> ModifyUser(UserData userData);
        public Task<bool> ModifyPassword(UserPassword password);
    }
}
