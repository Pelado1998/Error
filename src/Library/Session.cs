using System.Collections.Generic;

namespace Bankbot
{
    /*Cumple con el patrón ## EXPERT ## ya que es la mejor encargada de la información que maneja.
    También cumple con ## SRP ## porque no tiene mas de una razón de cambio, que en este caso sería el user.
    Cumple con ## SINGLETON ## ya que se desea almacenar una única vez el usuario en dicha lista la cual se fijará
    si el mismo esta iniciado en la session o no y le enviara comandos correspondientes.*/

    /// <summary>
    /// Se crea una sesión diferente y única para cada usuario de la plataforma.
    /// </summary>
    public class Session 
    {
        public List<User> AllUsers { get; set; }
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
            this.Printer = new HtmlPrinter();
        }

        /// <summary>
        /// Agrega un usuario nuevo a la lista de usuarios en caso que no esté(para diferenciarlos).
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void AddUser(string username, string password)
        {
            foreach (var user in AllUsers)
            {
                if (user.Username == username) return;
            }
            AllUsers.Add(new User(username, password));
        }

        /// <summary>
        /// Remueve de la lista el usuario deseado.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
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

        /// <summary>
        ///     Chequea si existe o no el usuario.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>

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

        /// <summary>
        /// Setea el canal de comunicación.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newChannel"></param>

        public void SetChannel(string id, IChannel newChannel)
        {
            GetChat(id).Channel = newChannel;
        }
    }
}