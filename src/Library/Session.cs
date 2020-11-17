using System.Collections.Generic;

namespace Bankbot
{
    public class Session
    {
        public List<User> AllUsers;
        public Dictionary<string, Data> DataMap;
        public IPrinter Printer { get; set; }
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
            this.DataMap = new Dictionary<string, Data>();

            //Agregar por setup
            this.Printer = new HtmlPrinter();
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

        public Data GetChat(string id)
        {
            Data chat;
            if (DataMap.TryGetValue(id, out chat))
            {
                return chat;
            }

            chat = new Data();
            DataMap.Add(id, chat);
            return chat;

        }

        public void SetChannel(string id, IChannel newChannel)
        {
            GetChat(id).Channel = newChannel;
        }
    }
}