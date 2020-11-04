using System.Collections.Generic;

namespace Bankbot
{
    public class Session
    {
        public List<User> AllUsers;
        public Dictionary<long, Chats> AllChats;
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
            this.AllChats = new Dictionary<long, Chats>();
        }
        public void AddUser(string userName, string password)
        {
            foreach (var user in AllUsers)
            {
                if (user.UserName == userName) return;
            }
            AllUsers.Add(new User(userName, password));
        }
        public User GetUser(string userName, string password)
        {
            foreach (var item in AllUsers)
            {
                if (item.Login(password)) return item;
            }
            return null;
        }
        public Chats GetChat(long id)
        {
            Chats chat;
            if (AllChats.TryGetValue(id, out chat))
            {
                return chat;
            }
            else
            {
                chat = new Chats(id);
                AllChats.Add(id, chat);
                return chat;
            }
        }

        // Responsabilidad de session o chat?
        public void SetChannel(long id, IChannel newChannel)
        {
            Chats chat;
            if (AllChats.TryGetValue(id, out chat))
            {
                chat.Channel = newChannel;
            }
        }
    }
}