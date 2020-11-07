using System;
using System.Text;

namespace Bankbot
{
    public class Dispatcher : AbstractHandler<Conversation>
    {
        public Dispatcher(DispatcherCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(Conversation request)
        {
            switch (request.Message.ToLower())
            {
                case "/createuser":

                    request.State = State.CreateUser;
                    request.Channel.SendMessage(request.Id, "Ingrese un nuevo nombre de usuario:");
                    break;

                case "/login":

                    request.State = State.Login;
                    request.Channel.SendMessage(request.Id, "Ingrese un nombre de usuario:");
                    break;

                case "/logout":

                    if (request.User != null)
                    {
                        request.User = null;
                        request.Channel.SendMessage(request.Id, "Se ha desconectado correctamente.");
                    }
                    else
                    {
                        request.Channel.SendMessage(request.Id, "Debes estar conectado para realizar esta operación.");
                    }
                    break;

                case "/createaccount":

                    if (request.User != null)
                    {
                        request.State = State.CreateAccount;
                        request.Channel.SendMessage(request.Id, "Ingrese el tipo de cuenta:\n" + Account.ShowAccountType());

                    }
                    else
                    {
                        request.Channel.SendMessage(request.Id, "Debes estar conectado para realizar esta operación.");
                    }
                    break;

                case "/convert":

                    request.State = State.Converting;
                    request.Channel.SendMessage(request.Id, "Ingrese la cantidad que desea convertir:");
                    break;

                case "/deleteuser":

                    request.State = State.DeleteUser;
                    request.Channel.SendMessage(request.Id, "Ingrese el nombre de usuario que desea eliminar:");
                    break;

                case "/deleteaccount":
                    if (request.User != null)
                    {
                        request.State = State.DeleteAccount;
                        request.Channel.SendMessage(request.Id, "Ingrese el nombre de cuenta que desea eliminar:");
                    }
                    else
                    {
                        request.Channel.SendMessage(request.Id, "Debes estar conectado para realizar esta operación.");
                    }
                    break;

                case "/transaction":
                    if (request.User != null)
                    {
                        request.State = State.Transaction;
                        request.Channel.SendMessage(request.Id, "Ingrese el tipo de transacción:\n1 - Ingreso\n2 - Gasto");
                    }
                    else
                    {
                        request.Channel.SendMessage(request.Id, "Debes estar conectado para realizar esta operación.");
                    }
                    break;
            }
        }
    }
}