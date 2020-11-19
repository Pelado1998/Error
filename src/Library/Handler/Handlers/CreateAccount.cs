using System;
using System.Collections.Generic;
using System.Text;
using static Bankbot.Account;
using static Bankbot.Bank;

namespace Bankbot
{
    /*Cumple con ## SRP ## 
    Cumple con ## EXPERT ##*/

    /// <summary>
    /// Handler para crear la cuenta.
    /// </summary>
    public class CreateAccountHandler : AbstractHandler<IMessage>
    {
        public CreateAccountHandler(ICondition<IMessage> condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {

            var data = Session.Instance.GetChat(request.Id);

            if (!data.Temp.ContainsKey("type"))
            {
                int index;
                if (Int32.TryParse(request.Text, out index) && index <= Enum.GetNames(typeof(AccountType)).Length)
                {
                    data.Temp.Add("type", (AccountType)index - 1);
                    data.Channel.SendMessage(request.Id, "Ingrese un nombre de cuenta:");
                }
                else
                {
                    data.Channel.SendMessage(request.Id, "Debe ingresar el índece correspondiente.");
                    data.Channel.SendMessage(request.Id, "Ingrese el tipo de cuenta:\n" + Account.ShowAccountType());
                }
            }
            else if (!data.Temp.ContainsKey("name"))
            {
                if (!data.User.AccountNameExists(request.Text))
                {
                    data.Temp.Add("name", request.Text);
                    data.Channel.SendMessage(request.Id, "Ingrese el tipo de moneda de la cuenta:\n" + Bank.Instance.ShowCurrencyList());
                }
                else
                {
                    data.Channel.SendMessage(request.Id, "Ya existe una cuenta con este nombre, vuelva a ingresar un nombre de cuenta.");
                }
            }
            else if (!data.Temp.ContainsKey("currency"))
            {
                int index;
                if (Int32.TryParse(request.Text, out index) && index <= Bank.Instance.CurrencyList.Count)
                {
                    data.Temp.Add("currency", Bank.Instance.CurrencyList[index - 1]);
                    data.Channel.SendMessage(request.Id, "Ingrese el saldo inicial de la cuenta:");
                }
                else
                {
                    data.Channel.SendMessage(request.Id, "Debe ingresar el índece correspondiente.");
                    data.Channel.SendMessage(request.Id, "Ingrese el tipo de moneda de la cuenta:\n" + Bank.Instance.ShowCurrencyList());
                }
            }
            else if (!data.Temp.ContainsKey("amount"))
            {
                double amount;
                if (double.TryParse(request.Text, out amount) && amount > 0)
                {
                    data.Temp.Add("amount", amount);
                    data.Channel.SendMessage(request.Id, "Ingrese el objetivo máximo de la cuenta:");
                }
                else
                {
                    data.Channel.SendMessage(request.Id, "Debe ingresar un valor válido.");
                    data.Channel.SendMessage(request.Id, "Ingrese el saldo inicial de la cuenta:");
                }
            }
            else if (!data.Temp.ContainsKey("maxObjective"))
            {
                double amount;
                if (double.TryParse(request.Text, out amount) && amount > 1)
                {
                    data.Temp.Add("maxObjective", amount);
                    data.Channel.SendMessage(request.Id, "Ingrese el objetivo mínimo de la cuenta:");
                }
                else
                {
                    data.Channel.SendMessage(request.Id, "Debe ingresar un valor válido.");
                    data.Channel.SendMessage(request.Id, "Ingrese el objetivo máximo de la cuenta:");
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
                    data.Channel.SendMessage(request.Id, "Ingrese el objetivo mínimo de la cuenta:");
                }
            }

            if (data.Temp.ContainsKey("type") && data.Temp.ContainsKey("name") && data.Temp.ContainsKey("currency") && data.Temp.ContainsKey("amount") && data.Temp.ContainsKey("maxObjective") && data.Temp.ContainsKey("minObjective"))
            {
                var type = data.GetDictionaryValue<AccountType>("type");
                var name = data.GetDictionaryValue<string>("name");
                var currency = data.GetDictionaryValue<Currency>("currency");
                var amount = data.GetDictionaryValue<double>("amount");
                var maxObjective = data.GetDictionaryValue<double>("maxObjective");
                var minObjective = data.GetDictionaryValue<double>("minObjective");

                var account = data.User.AddAccount(type, name, currency, amount, new Objective(maxObjective, minObjective));

                if (account != null)
                {
                    data.Channel.SendMessage(request.Id, "Cuenta creada exitosamente.");
                }
                // Exception
                else
                {
                    data.Channel.SendMessage(request.Id, "Ha ocurrido un problema.");
                }

                data.ClearOperation();
            }
        }
    }
}