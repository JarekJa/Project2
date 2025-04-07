using Project2.Models.UserData;
using Project2.Models.Users;
using Project2.Services.Interfaces;

namespace Project2.Services
{
    public class UserUpdater : IUserUpdater
    {
        public void Visit(User user, UserData data)
        {
           user.FirstName = data.FirstName;
            user.LastName = data.LastName;
            user.UserName = data.Login;
        }


         public void Visit(Admin user, UserData data)
        {
            Visit((User)user, data);
            AdminData adminData = data as AdminData;

        }
        public void Visit(ProjectEmployee user, UserData data)
        {
            Visit((User)user, data);
             PEmployeeData pEmployeeData = data as PEmployeeData;

        }
        public void Visit(HRManager user, UserData data)
        {
            Visit((User)user, data);
            HRManagerData HRManagerData = data as HRManagerData;
        }
        public void Visit(ProjectManager user, UserData data)
        {
            Visit((User)user, data);

            PManagerData pManagerData = data as PManagerData;
        }
        public void Visit(Boss user, UserData data)
        {
            Visit((User)user, data);

            BossData bossData = data as BossData;
        }

    }
}
