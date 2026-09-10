using System;
using System.Collections.Generic;
using System.Text;

namespace CodeStream20
{
    [Serializable]
    internal class User
    {
        public const string UsersFilePath = "Users.json";
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public User() { }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
