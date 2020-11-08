using System;
using System.Collections.Generic;
using System.Text;
using static Bankbot.Account;
using static Bankbot.Bank;

namespace Bankbot
{
    public class CreateAccount : AbstractHandler<Conversation>
    {
        public CreateAccount(ICondition<Conversation> condition) : base(condition)
        {
        }

        protected override void handleRequest(Conversation request)
        {

            if (!request.Temp.ContainsKey("type"))
            {
                int index;
                if (Int32.TryParse(request.Message, out index) && index < Enum.GetNames(typeof(AccountType)).Length)
                {
                    request.Temp.Add("type", (AccountType)index - 1);
                    request.Channel.SendMessage(request.Id, "Ingrese un nombre de cuenta:");
                }
                else
                {
                    request.Channel.SendMessage(request.Id, "Debe ingresar el índece correspondiente.");
                    request.Channel.SendMessage(request.Id, "Ingrese el tipo de cuenta:\n" + Account.ShowAccountType());
                }
            }
            else if (!request.Temp.ContainsKey("name"))
            {
                if (!request.User.AccountNameExists(request.Message))
                {
                    request.Temp.Add("name", request.Message);
                    request.Channel.SendMessage(request.Id, "Ingrese el tipo de moneda de la cuenta:\n" + Bank.Instance.ShowCurrencyList());
                }
                else
                {
                    request.Channel.SendMessage(request.Id, "Ya existe una cuenta con este nombre, vuelva a ingresar un nombre de cuenta.");
                }
            }
            else if (!request.Temp.ContainsKey("currency"))
            {
                int index;
                if (Int32.TryParse(request.Message, out index) && index < Bank.Instance.CurrencyList.Count)
                {
                    request.Temp.Add("currency", Bank.Instance.CurrencyList[index - 1]);
                    request.Channel.SendMessage(request.Id, "Ingrese el saldo inicial de la cuenta:");
                }
                else
                {
                    request.Channel.SendMessage(request.Id, "Debe ingresar el índece correspondiente.");
                    request.Channel.SendMessage(request.Id, "Ingrese el tipo de moneda de la cuenta:\n" + Bank.Instance.ShowCurrencyList());
                }
            }
            else if (!request.Temp.ContainsKey("amount"))
            {
                float amount;
                if (float.TryParse(request.Message, out amount) && amount > 0)
                {
                    request.Temp.Add("amount", amount);
                    request.Channel.SendMessage(request.Id, "Ingrese el objetivo de la cuenta:");
                }
                else
                {
                    request.Channel.SendMessage(request.Id, "Debe ingresar un valor válido.");
                    request.Channel.SendMessage(request.Id, "Ingrese el saldo inicial de la cuenta:");
                }
            }
            else if (!request.Temp.ContainsKey("objective"))
            {
                float amount;
                if (float.TryParse(request.Message, out amount) && amount > 0)
                {
                    request.Temp.Add("objective", amount);
                }
                else
                {
                    request.Channel.SendMessage(request.Id, "Debe ingresar un valor válido.");
                    request.Channel.SendMessage(request.Id, "Ingrese el objetivo de la cuenta:");
                }
            }

            if (request.Temp.ContainsKey("type") && request.Temp.ContainsKey("name") && request.Temp.ContainsKey("currency") && request.Temp.ContainsKey("amount") && request.Temp.ContainsKey("objective"))
            {
                var type = request.GetDictionaryValue<AccountType>("type");
                var name = request.GetDictionaryValue<string>("name");
                var currency = request.GetDictionaryValue<Currency>("currency");
                var amount = request.GetDictionaryValue<float>("amount");
                var objective = request.GetDictionaryValue<float>("objective");

                var account = request.User.AddAccount(type, name, currency, amount, objective);

                if (account != null)
                {
                    request.Channel.SendMessage(request.Id, "Cuenta creada exitosamente.");
                }
                // Exception
                else
                {
                    request.Channel.SendMessage(request.Id, "Ha ocurrido un problema.");
                }

                request.Temp.Clear();
                request.State = State.Dispatcher;
            }
        }
    }
}