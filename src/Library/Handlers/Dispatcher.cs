namespace Bankbot
{
    public class Dispatcher : AbstractHandler<IMessage>
    {
        public Dispatcher(DispatcherCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            var data = Session.Instance.GetChat(request.Id);
            data.State = State.HandlingCommand;

            switch (request.Text.ToLower())
            {
                case "/commands":
                    data.Channel.SendMessage(request.Id, AllCommands.Instance.CommandList(request.Id));
                    data.State = State.Dispatcher;
                    break;

                case "/createuser":

                    if (data.User == null)
                    {
                        data.Command = request.Text.ToLower();
                        data.Channel.SendMessage(request.Id, "Ingrese un nuevo nombre de usuario:");
                        break;
                    }
                    data.Channel.SendMessage(request.Id, "Debes estar desconectado para realizar esta operación.");
                    break;

                case "/login":
                    if (data.User == null)
                    {
                        data.Command = request.Text;
                        data.Channel.SendMessage(request.Id, "Ingrese un nombre de usuario:");
                        break;
                    }
                    data.Channel.SendMessage(request.Id, "Debes estar desconectado para realizar esta operación.");
                    break;

                case "/logout":

                    if (data.User != null)
                    {
                        data.User = null;
                        data.Channel.SendMessage(request.Id, "Se ha desconectado correctamente.");
                        data.Channel.SendMessage(request.Id, "Para continuar puedes ingresar los siguientes comandos:\n" + AllCommands.Instance.CommandList((request.Id)));
                        data.State = State.Dispatcher;
                        break;
                    }
                    data.Channel.SendMessage(request.Id, "Debes estar conectado para realizar esta operación.");
                    data.State = State.Dispatcher;
                    break;

                case "/createaccount":

                    if (data.User != null)
                    {
                        data.Command = request.Text;
                        data.Channel.SendMessage(request.Id, "Ingrese el tipo de cuenta:\n" + Account.ShowAccountType());
                        break;
                    }

                    data.Channel.SendMessage(request.Id, "Debes estar conectado para realizar esta operación.");
                    break;

                case "/convert":

                    data.Command = request.Text;
                    data.Channel.SendMessage(request.Id, "Seleccione la moneda desde la que desea convertir:\n" + Bank.Instance.ShowCurrencyList());
                    break;

                case "/deleteuser":

                    data.Command = request.Text;
                    data.Channel.SendMessage(request.Id, "Ingrese el nombre de usuario que desea eliminar:");
                    break;

                case "/deleteaccount":
                    if (data.User != null)
                    {
                        data.Command = request.Text;
                        data.Channel.SendMessage(request.Id, "indique que cuenta desea eliminar:\n" + data.User.ShowAccountList());
                        break;
                    }
                    data.Channel.SendMessage(request.Id, "Debes estar conectado para realizar esta operación.");
                    break;

                case "/transaction":
                    if (data.User != null)
                    {
                        data.Command = request.Text;
                        data.Channel.SendMessage(request.Id, "Ingrese el tipo de transacción:\n1 - Ingreso\n2 - Gasto");
                        break;
                    }
                    data.Channel.SendMessage(request.Id, "Debes estar conectado para realizar esta operación.");
                    break;

                case "/filter":
                    if (data.User != null)
                    {
                        data.Command = request.Text;
                        data.Channel.SendMessage(request.Id, "Seleccione una cuenta para ver el historial:\n" + data.User.ShowAccountList());
                        break;
                    }
                    data.Channel.SendMessage(request.Id, "Debes estar conectado para realizar esta operación.");
                    break;

                case "/additem":
                    if (data.User != null)
                    {
                        data.Command = request.Text;
                        data.Channel.SendMessage(request.Id, "Ingrese un nuevo rubro:");
                        break;
                    }
                    data.Channel.SendMessage(request.Id, "Debes estar conectado para realizar esta operación.");
                    break;

                case "/changeobjective":
                    if (data.User != null)
                    {
                        data.Command = request.Text;
                        data.Channel.SendMessage(request.Id, "Seleccione una cuenta para cambiar el objetivo:\n" + data.User.ShowAccountList());
                        break;
                    }
                    data.Channel.SendMessage(request.Id, "Debes estar conectado para realizar esta operación.");
                    break;

                case "/addcurrency":
                    if (data.User != null)
                    {
                        data.Command = request.Text;
                        data.Channel.SendMessage(request.Id, "Ingrese el código ISO de la nueva moneda:");
                        break;
                    }
                    data.Channel.SendMessage(request.Id, "Debes estar conectado para realizar esta operación.");
                    break;

                case "/balance":
                    if (data.User != null)
                    {
                        data.Command = request.Text;
                        data.Channel.SendMessage(request.Id, "Seleccione una cuenta para recibir el balance:\n" + data.User.ShowAccountList());
                        break;
                    }
                    data.Channel.SendMessage(request.Id, "Debes estar conectado para realizar esta operación.");
                    break;
            }
        }
    }
}