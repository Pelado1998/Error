using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class ChangeAccountObjectiveHandler : AbstractHandler<IMessage>
    {
        public ChangeAccountObjectiveHandler(ChangeAccountObjective condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            var data = Session.Instance.GetChat(request.Id);

            if (!data.Temp.ContainsKey("account"))
            {
                int index;
                if (Int32.TryParse(request.Text, out index) && index <= data.User.Accounts.Count)
                {
                    data.Temp.Add("account", data.User.Accounts[index - 1]);
                    data.Channel.SendMessage(request.Id, "Ingrese un nuevo objetivo máximo:");
                }
                else
                {
                    data.Channel.SendMessage(request.Id, "Debe ingresar un valor igual al índice indicado.");
                    data.Channel.SendMessage(request.Id, "Seleccione una cuenta para cambiar el objetivo:\n" + data.User.ShowAccountList());
                }
                return;
            }
            else if (!data.Temp.ContainsKey("maxObjective"))
            {
                double amount;
                if (double.TryParse(request.Text, out amount) && amount > 1)
                {
                    data.Temp.Add("maxObjective", amount);
                    data.Channel.SendMessage(request.Id, "Ingrese un nuevo objetivo mínimo:");
                }
                else
                {
                    data.Channel.SendMessage(request.Id, "Debe ingresar un valor válido.");
                    data.Channel.SendMessage(request.Id, "Ingrese un nuevo objetivo máximo:");
                }
            }
            else if (!data.Temp.ContainsKey("minObjective"))
            {
                double amount;
                if (double.TryParse(request.Text, out amount) && amount > 0 && amount < data.GetDictionaryValue<double>("maxObjective"))
                {
                    data.Temp.Add("minObjective", amount);
                }
                else
                {
                    data.Channel.SendMessage(request.Id, "Debe ingresar un valor válido.");
                    data.Channel.SendMessage(request.Id, "Ingrese un nuevo objetivo mínimo:");
                }
            }

            if (data.Temp.ContainsKey("maxObjective") && data.Temp.ContainsKey("minObjective"))
            {
                var account = data.GetDictionaryValue<Account>("account");
                var maxObjective = data.GetDictionaryValue<double>("maxObjective");
                var minObjective = data.GetDictionaryValue<double>("minObjective");

                account.ChangeObjective(maxObjective, minObjective);
                data.Channel.SendMessage(request.Id, "Se han cambiado los objetivos de la cuenta.");

                data.ClearOperation();
            }
        }
    }
}