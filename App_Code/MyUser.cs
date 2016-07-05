using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class User
    {
        public string username;
        public string password;
        /// <summary>
        /// states can be 
        /// admin - all permissions
        /// pending - as if not loggedin but wainting
        /// user - registrated player. sees all but unable to insert, update and delete
        /// </summary>
        public string account;
        public DateTime date;

        public bool CanChangeTips() 
        {
            return account.Equals("admin");
        }

        public bool CanSeeTips() 
        {
            if (account.Equals("admin"))
            {
                return true;
            } else if (account.Equals("user") && date <= DateTime.UtcNow) 
            {
                return true;
            }

            return false;
        }

        public User(string username, string password, string account, DateTime date)
        {
            this.username = username;
            this.password = password;
            this.account = account;
            this.date = date;
        }
    }
}

