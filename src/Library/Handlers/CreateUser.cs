namespace Bankbot
{
    public class CreateUser : AbstractHandler<Conversation>
    {
        public CreateUser(CreateUserCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(Conversation request)
        {
            if (!request.Temp.ContainsKey("username"))
            {
                if (Session.Instance.UsernameExists(request.Message))
                {
                    request.Channel.SendMessage(request.Id, "Ya existe un usuario con este nombre. Vuelva a ingresar un nombre de usuario:");
                }
                else
                {
                    request.Temp.Add("username", request.Message);
                    request.Channel.SendMessage(request.Id, "Ingrese una contraseña:");
                }
            }
            else if (!request.Temp.ContainsKey("password"))
            {
                request.Temp.Add("password", request.Message);
            }

            if (request.Temp.ContainsKey("username") && request.Temp.ContainsKey("password"))
            {
                string username = request.GetDictionaryValue<string>("username");
                string password = request.GetDictionaryValue<string>("password");

                Session.Instance.AddUser(username, password);
                User user = Session.Instance.GetUser(username, password);

                if (user != null)
                {
                    request.Channel.SendMessage(request.Id, "Usuario creado correctamente.");
                }
                // Exception 
                else
                {
                    request.Channel.SendMessage(request.Id, "Ha ocurrido un error.");
                }
                request.Temp.Clear();
                request.State = State.Dispatcher;
            }
        }
    }
}