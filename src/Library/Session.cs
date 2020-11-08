using System.Collections.Generic;

namespace Bankbot
{
    public class Session
    {
        public List<User> AllUsers;
        public Dictionary<string, Conversation> AllConversation;
        private static Session instance;
        public static Session Instance
        {
            get
            {
                if (instance == null) instance = new Session();
                return instance;
            }
        }
        private Session()
        {
            this.AllUsers = new List<User>();
            this.AllConversation = new Dictionary<string, Conversation>();
        }
        public void AddUser(string username, string password)
        {
            foreach (var user in AllUsers)
            {
                if (user.Username == username) return;
            }
            AllUsers.Add(new User(username, password));
        }
        public void RemoveUser(string username, string password)
        {
            if (UsernameExists(username))
            {
                AllUsers.Remove(GetUser(username, password));
            }
        }

        public User GetUser(string username, string password)
        {
            foreach (var item in AllUsers)
            {
                if (item.Username == username && item.Login(password)) return item;
            }
            return null;
        }

        public bool UsernameExists(string username)
        {
            string user = "";
            foreach (var item in AllUsers)
            {
                if (item.Username == username) user = item.Username;
            }
            return user == username;
        }

        public Conversation GetChat(string id)
        {
            Conversation chat;
            if (AllConversation.TryGetValue(id, out chat))
            {
                return chat;
            }
            else
            {
                chat = new Conversation(id);
                AllConversation.Add(id, chat);
                return chat;
            }
        }

        public void SetChannel(string id, IChannel newChannel)
        {
            Conversation chat;
            if (AllConversation.TryGetValue(id, out chat))
            {
                chat.Channel = newChannel;
            }
        }
    }
}