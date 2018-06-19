using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LizenzManager.Models
{
    public class Credentials
    {
        public Credentials(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public Credentials(string username, string password, bool authorized)
        {
            Username = username;
            Password = password;
            Authorized = authorized;
        }

        public Credentials()
        {
            
        }

        public string Password { get; set; }

        public string Username { get; set; }

        public bool Authorized = false;
    }
}
