using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class DeleteAccount : AbstractHandler<Conversation>
    {
        public DeleteAccount(DeleteAccountCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(Conversation request)
        {
            if (!request.Temp.ContainsKey("account"))
            {
                int index;
                if (Int32.TryParse(request.Message, out index) && index <= request.User.Accounts.Count)
                {
                    request.Temp.Add("account", request.User.Accounts[index - 1]);
                    request.Channel.SendMessage(request.Id, "Ingrese su contraseña para eliminar esta cuenta:");
                    return;
                }
                request.Channel.SendMessage(request.Id, "Debe ingresar el índice correspondiente a la cuenta que desea eliminar.");
                request.Channel.SendMessage(request.Id, "indique que cuenta desea eliminar:\n" + request.User.ShowAccountList());
            }

            else if (!request.Temp.ContainsKey("password"))
            {
                if (request.User.Login(request.Message))
                {
                    request.Channel.SendMessage(request.Id, "¿Esta seguro que desea realizar esta operación? Vuelva a ingresar su contraseña para confirmar.");
                    request.Temp.Add("confirmation", "");
                    return;
                }

                request.Channel.SendMessage(request.Id, "Credenciales incorrectas. Ingrese /deleteaccount para volver a realizar esta operación.");
                request.Temp.Clear();
                request.State = State.Dispatcher;
            }

            else if (!request.Temp.ContainsKey("confirmation"))
            {
                if (request.User.Login(request.Message))
                {
                    Account account = request.GetDictionaryValue<Account>("account");
                    request.User.RemoveAcount(account);
                    if (!request.User.Accounts.Contains(account))
                    {
                        request.Channel.SendMessage(request.Id, "Cuenta eliminada correctamente.");
                    }
                    else
                    {
                        request.Channel.SendMessage(request.Id, "Credenciales incorrectas. Ingrese /deleteaccount para volver a realizar esta operación.");
                    }

                    request.Temp.Clear();
                    request.State = State.Dispatcher;
                }
            }
        }
    }
}