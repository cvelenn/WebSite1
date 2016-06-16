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
        public string account;

        public User(string username, string password, string account)
        {
            this.username = username;
            this.password = password;
            this.account = account;
        }
    }
}

