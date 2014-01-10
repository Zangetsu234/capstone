using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
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
        public bool CreateUser(UserRegisterFM userFM)
        {
            if (IsValidUser(userFM))
            {
                UserDAO dao = new UserDAO();
                User user = new User();
                user.Username = userFM.Username;
                user.Email = userFM.Email;
                user.Password = userFM.Password;
                dao.CreateUser(user);
                return true;
            }
            return false;
        }
        public bool IsValidUser(UserRegisterFM userFM)
        {
            UserDAO dao = new UserDAO();
            if (dao.GetUserByEmail(userFM.Email) == null)
            {
                return true;
            }
            return false;
        }
        public bool ValidEmail(string email)
        {
            if (email.Length < 101)
            {
                try
                {
                    var addr = new MailAddress(email);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        public bool ConfirmEmailLength(UserRegisterFM userFM)
        {
            UserDAO dao = new UserDAO();
            if (userFM.Email != null && userFM.Email.Length > 5)
            {
                return true;
            }
            return false;
        }
        public UserFM GetUserFM(int ID)
        {
            UserDAO dao = new UserDAO();
            User user = dao.GetUserByID(ID);
            UserFM userFM = new UserFM(user);
            return userFM;
        }
        public void UpdateUser(UserFM userFM)
        {
            UserDAO dao = new UserDAO();
            User user = dao.GetUserByID(userFM.ID);
            user.Email = userFM.Email;
            dao.UpdateUser(user);
        }
        public UserPassFM GetUserPassFM(int ID)
        {
            UserDAO dao = new UserDAO();
            User user = dao.GetUserByID(ID);
            UserPassFM passFM = new UserPassFM(user);
            return passFM;
        }
        public bool VerifyPassword(UserPassFM passFM)
        {
            if (passFM.CurrentPassword == GetUserPassFM(passFM.ID).CurrentPassword)
            {
                return true;
            }
            return false;
        }
        public void UpdatePassword(UserPassFM passFM)
        {
            UserDAO dao = new UserDAO();
            User user = dao.GetUserByID(passFM.ID);
            user.Password = passFM.NewPassword;
            dao.UpdateUser(user);
        }
        public void RemoveUser(int ID)
        {
            UserDAO dao = new UserDAO();
            dao.RemoveUser(ID);
        }
        public UserLoginVM UserLogin(UserLoginFM login)
        {
            UserLoginVM userVM = null;
            UserDAO dao = new UserDAO();
            User user = dao.GetUserByEmail(login.Email);
            if (user != null && user.Password == login.Password)
            {
                userVM = new UserLoginVM();
                userVM.Email = user.Email;
                userVM.ID = user.ID;
            }
            return userVM;
        }
    }
}