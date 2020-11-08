using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class DeleteUser : AbstractHandler<Conversation>
    {
        public DeleteUser(DeleteUserCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(Conversation request)
        {
            if (!request.Temp.ContainsKey("username"))
            {
                request.Temp.Add("username", request.Message);
                request.Channel.SendMessage(request.Id, "Ingrese una constraseña:");

            }
            else if (!request.Temp.ContainsKey("password"))
            {
                request.Temp.Add("password", request.Message);
            }

            if (request.Temp.ContainsKey("username") && request.Temp.ContainsKey("password"))
            {
                string username = request.GetDictionaryValue<string>("username");
                string password = request.GetDictionaryValue<string>("password");

                User user = Session.Instance.GetUser(username, password);

                if (user == null)
                {
                    request.Channel.SendMessage(request.Id, "Credenciales incorrectas, vuelva a intentarlo.");
                    return;
                }

                request.Channel.SendMessage(request.Id, "¿Estas seguro que deseas borrar este usuario? Vuelva a ingresar su contraseña:");
                request.Temp.Add("confirmation", "");

            }
            else if (request.Temp.ContainsKey("confirmation"))
            {
                string username = request.GetDictionaryValue<string>("username");
                string password = request.GetDictionaryValue<string>("password");
                string confirmationPassword = request.Message;

                if (password == confirmationPassword)
                {
                    Session.Instance.RemoveUser(username, password);
                    request.Channel.SendMessage(request.Id, "Usuario eliminado correctamente.");
                }
                else
                {
                    request.Channel.SendMessage(request.Id, "Credenciales incorrectas.");
                }

                request.Temp.Clear();
                request.State = State.Dispatcher;
            }
        }
    }
}
