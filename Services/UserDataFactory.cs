using Microsoft.AspNetCore.Identity;
using Project2.Models.UserData;
using Project2.Models.Users;

namespace Project2.Services
{
    public static class UserDataFactory
    {
        public static UserData CreateFromUser(User user, string role)
        {
            return role switch
            {
                "Administrator" => CreateAdminUserData(user),
                "HRManager" => CreateHrManagerUserData(user),
                "ProjectManager" => CreateProjectManagerUserData(user),
                "ProjectEmployee" => CreateBossUserData(user),
                "Boss" => CreateBossUserData(user),
                _ => CreateDefaultUserData(user) 
            };
              
        }

        private static UserData CreateAdminUserData(User user)
        {
            var admin = user as Admin;
            AdminData data = new AdminData { FirstName = user.FirstName, LastName = user.LastName, Login = user.UserName, Role = user.Role };
            return data;
        }

        private static UserData CreateHrManagerUserData(User user)
        {
            var hRManager = user as HRManager;
            HRManagerData data = new HRManagerData { FirstName = user.FirstName, LastName = user.LastName, Login = user.UserName, Role = user.Role };
            return data;
        }

        private static UserData CreateProjectManagerUserData(User user)
        {
            var projectManager = user as ProjectManager;
            PManagerData data = new PManagerData { FirstName = user.FirstName, LastName = user.LastName, Login = user.UserName, Role = user.Role };
            return data;
        }

        private static UserData CreateBossUserData(User user)
        {
            var projectEmployee = user as Boss;
            BossData data = new BossData { FirstName = user.FirstName, LastName = user.LastName, Login = user.UserName, Role = user.Role };
            return data;
            
        }

        private static UserData CreateDefaultUserData(User user)
        {
            return new UserData { FirstName = user.FirstName, LastName = user.LastName,Login= user.UserName, Role=user.Role };
        }
    }
}
