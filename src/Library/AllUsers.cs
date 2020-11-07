using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class AllUsers
    {
        public List<User> UserList { get; set; }
        private static AllUsers instance;
        
        public static AllUsers Instance
        {
            get
            {
                if (instance == null) instance = new AllUsers();
                return instance;
            }
        }
        private AllUsers()
        {
            this.UserList = new List<User>();         
        }
        public User Login(string username, string password)
        {   
            foreach (User user in this.UserList)
            {
                if(user.UserName == username && user.Login(password)) return user;
            }
            return null;
        }
        public void AddUser(string username, string password)
        {
            if(!UserExist(username)) this.UserList.Add(new User(username,password));
        }
        public bool UserExist(string username)
        {
            foreach (User user in this.UserList)
            {
                if(user.UserName == username) return true;
            }
            return false;
        } 
        public void RemoveUser(string username, Chats request)
        {
            foreach (User user in this.UserList)
            {
                if(user.UserName == username)
                {
                    this.UserList.Remove(user);
                    request.User = null;
                    return;
                }
            }
        }
    }
}
