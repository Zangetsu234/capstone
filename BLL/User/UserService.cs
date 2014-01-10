using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class UserService
    {
        public UsersVM GetUsers()
        {
            UserDAO dao = new UserDAO();
            List<User> users = dao.GetAllUsers();
            UsersVM usersVM = new UsersVM();
            foreach (User user in users)
            {
                UserVM userVM = new UserVM();
                userVM.ID = user.ID;
                userVM.Username = user.Username;
                userVM.Email = user.Email;
                usersVM.Users.Add(userVM);
            }
            return usersVM;
        }

    }
}