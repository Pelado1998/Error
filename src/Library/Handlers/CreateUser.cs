using System;

namespace Bankbot
{
    public class CreateUser : AbstractHandler<IMessage>
    {
        public CreateUser(CreateUserCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            var data = Session.Instance.GetChat(request.Id);


            if (!data.Temp.ContainsKey("username"))
            {
                if (Session.Instance.UsernameExists(request.Text))
                {
                    data.Channel.SendMessage(request.Id, "Ya existe un usuario con este nombre 😟.\nVuelva a ingresar un nombre de usuario:");
                }
                else
                {
                    data.Temp.Add("username", request.Text);
                    data.Channel.SendMessage(request.Id, "Ingrese una contraseña:");
                }
            }
            else if (!data.Temp.ContainsKey("password"))
            {
                data.Temp.Add("password", request.Text);
            }

            if (data.Temp.ContainsKey("username") && data.Temp.ContainsKey("password"))
            {
                string username = data.GetDictionaryValue<string>("username");
                string password = data.GetDictionaryValue<string>("password");

                Session.Instance.AddUser(username, password);
                User user = Session.Instance.GetUser(username, password);

                if (user != null)
                {
                    data.Channel.SendMessage(request.Id, "Usuario creado correctamente.");
                    data.Channel.SendMessage(request.Id, "Elija un comando de la siguiente lista:\n" + AllCommands.Instance.CommandList(request.Id));
                }
                // Exception 
                else
                {
                    data.Channel.SendMessage(request.Id, "Ha ocurrido un error.");
                }
                data.Temp.Clear();
                data.State = State.Dispatcher;
            }
        }
    }
}