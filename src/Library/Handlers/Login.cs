using System;

namespace Bankbot
{
    public class Login : AbstractHandler<IMessage>
    {
        public Login(LoginCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            var data = Session.Instance.GetChat(request.Id);

            if (!data.Temp.ContainsKey("username"))
            {
                data.Temp.Add("username", request.Text);
                data.Channel.SendMessage(request.Id, "Ingrese una contraseña:");
            }
            else if (!data.Temp.ContainsKey("password"))
            {
                data.Temp.Add("password", request.Text);
            }

            if (data.Temp.ContainsKey("username") && data.Temp.ContainsKey("password"))
            {
                string username = data.GetDictionaryValue<string>("username");
                string password = data.GetDictionaryValue<string>("password");

                data.User = Session.Instance.GetUser(username, password);

                if (data.User != null)
                {
                    data.Channel.SendMessage(request.Id, "Se ha conectado correctamente.");
                    data.Channel.SendMessage(request.Id, "Para continuar puedes ingresar los siguientes comandos:\n" + AllCommands.Instance.CommandList((request.Id)));
                }
                else
                {
                    data.Channel.SendMessage(request.Id, "Credenciales incorrectas, vuelva a intentarlo.");
                }

                data.ClearOperation();
            }
        }
    }
}