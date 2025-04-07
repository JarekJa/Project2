using Project2.Models.UserData;
using Project2.Models.Users;

namespace Project2.Services.Interfaces
{
    public interface IUserUpdater
    {
        void Visit(User user, UserData data);
    }
}
