using System;
using System.Collections.Generic;
using System.Text;

namespace CodeStream20
{
    [Serializable]
    internal class User
    {
        public string Username {  get; set; }
        public string Password { get; set; }

        public User() { }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
