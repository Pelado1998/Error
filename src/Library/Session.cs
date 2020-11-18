using System.Collections.Generic;

namespace Bankbot
{
    /// <summary>
    /// Esta clase cumple con el patron ## observer ## ya que se encarga de ser la que le brinda la información necesaria a IAlert
    /// que es el Observer para que pueda actualizarse cada vez que hay un cambio y notificar a el/los usuarios.
    /// Cumple con el patrón ## EXPERT ## ya que es la mejor encargada de la información que maneja.
    /// También cumple con ## SRP ## porque no tiene mas de una razón de cambio, que en este caso sería el user.
    /// Cumple con ## SINGLETON ## ya que se desea almacenar una única vez el usuario en dicha lista la cual se fijará
    /// si el mismo esta iniciado en la session o no y le enviara comandos correspondientes.
    /// </summary>
    public class Session 
    {
        public List<User> AllUsers;
        public Dictionary<string, Data> DataMap;
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
            Data chat;
            if (DataMap.TryGetValue(id, out chat))
            {
                chat.Channel = newChannel;
            }
        }
    }
}