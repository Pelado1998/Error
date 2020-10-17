using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class AllUsers
    {
        public List<User> UserList { get; set; }
        public User SelectedUser { get; set; }
        private static AllUsers instance;
        public static AllUsers Instance
        {
            get
            {
                if (instance == null) instance = new AllUsers();
                return instance;
            }
        }

        public AllUsers()
        {
            this.UserList = new List<User>();
        }

        public static bool Login(string password, string hash)
        {
            return PasswordCypher.Decrypt(password, hash);
        }
    }
}
