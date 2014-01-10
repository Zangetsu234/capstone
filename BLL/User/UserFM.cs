using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class UserFM
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserFM(User user)
        {
            this.ID = user.ID;
            this.Username = user.Username;
            this.Email = user.Email;
            this.Password = user.Password;
        }
        public UserFM()
	    {

	    }

    }
}