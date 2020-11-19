using System;
using System.Collections.Generic;

namespace Bankbot
{
    /*Cumple con ## SRP ## 
    Cumple con ## EXPERT ##*/

    /// <summary>
    /// Handler para borrar las cuentas.
    /// </summary>
    public class DeleteAccountHandler : AbstractHandler<IMessage>
    {
        public DeleteAccountHandler(DeleteAccountCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            var data = Session.Instance.GetChat(request.Id);

            if (!data.Temp.ContainsKey("account"))
            {
                int index;
                if (Int32.TryParse(request.Text, out index) && index > 0 && index <= data.User.Accounts.Count)
                {
                    data.Temp.Add("account", data.User.Accounts[index - 1]);
                    data.Channel.SendMessage(request.Id, "Ingrese su contraseña para eliminar esta cuenta:");
                }
                else
                {
                    data.Channel.SendMessage(request.Id, "Debe ingresar el índice correspondiente a la cuenta que desea eliminar.");
                    data.Channel.SendMessage(request.Id, "indique que cuenta desea eliminar:\n" + data.User.ShowAccountList());
                }
            }

            else if (!data.Temp.ContainsKey("password"))
            {
                if (data.User.Login(request.Text))
                {
                    data.Channel.SendMessage(request.Id, "¿Esta seguro que desea realizar esta operación? Vuelva a ingresar su contraseña para confirmar.");
                    data.Temp.Add("password", "");
                }
                else
                {
                    data.Channel.SendMessage(request.Id, "Credenciales incorrectas. Ingrese /deleteaccount para volver a realizar esta operación.");
                    data.ClearOperation();
                }
            }

            else if (!data.Temp.ContainsKey("confirmation"))
            {
                if (data.User.Login(request.Text))
                {
                    Account account = data.GetDictionaryValue<Account>("account");
                    data.User.RemoveAcount(account);
                    if (!data.User.Accounts.Contains(account))
                    {
                        data.Channel.SendMessage(request.Id, "Cuenta eliminada correctamente.");
                    }
                    else
                    {
                        data.Channel.SendMessage(request.Id, "Credenciales incorrectas. Ingrese /deleteaccount para volver a realizar esta operación.");
                    }

                    data.ClearOperation();
                }
            }
        }
    }
}