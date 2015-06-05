using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankrotManager
{
    public class User
    {
        public int user_id {set; get;}
        public String username {set; get; }
        public String password { set; get; }
        public String name { set; get; }

        public float funds { set; get; }
        public String email { set; get; }
       
        public User()
        {}

        public string getName()
        {
            return this.name;
        }
        public int getUserId()
        {
            return this.user_id;
        }
        public string getUsername()
        {
            return this.username;
        }
        public float getFunds()
        {
            return this.funds;
        }

        public string getEmail()
        {
            return this.email;
        }
    }
}