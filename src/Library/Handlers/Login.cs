namespace Bankbot
{
    public class Login : AbstractHandler<Conversation>
    {
        public Login(LoginCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(Conversation request)
        {
            if (!request.Temp.ContainsKey("username"))
            {
                request.Temp.Add("username", request.Message);
                request.Channel.SendMessage(request.Id, "Ingrese una contraseña:");
            }
            else if (request.Temp.ContainsKey("username") && !request.Temp.ContainsKey("password"))
            {
                request.Temp.Add("password", request.Message);
            }

            if (request.Temp.ContainsKey("username") && request.Temp.ContainsKey("password"))
            {
                string username = request.GetDictionaryValue<string>("username");
                string password = request.GetDictionaryValue<string>("password");

                request.User = Session.Instance.GetUser(username, password);

                if (request.User != null)
                {
                    request.Channel.SendMessage(request.Id, "Se ha conectado correctamente.");
                }
                else
                {
                    request.Channel.SendMessage(request.Id, "Credenciales incorrectas, vuelva a intentarlo.");
                }
                request.Temp.Clear();
                request.State = State.Dispatcher;
            }
        }
    }
}