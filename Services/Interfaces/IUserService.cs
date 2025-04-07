

using Project2.Models.ManageUser;

namespace Project2.Services.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<UserList>> GetUserList();
        public Task<bool> DeleteUser(string id);
    }
}
