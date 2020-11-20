using System;

namespace Bankbot
{
    /*Cumple con ## SRP ## 
    Cumple con ## EXPERT ##*/
    /// <summary>
    /// Handler para realizar una transacción.
    /// </summary>
    public class TransactionHandler : AbstractHandler<IMessage>
    {
        public TransactionHandler(TransactionCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            var data = Session.Instance.GetChat(request.Id);

            if (!data.Temp.ContainsKey("type"))
            {
                int index;
                if (Int32.TryParse(request.Text, out index) && index > 0 && (index == 1 || index == 2))
                {
                    data.Temp.Add("type", index);
                    data.Channel.SendMessage(request.Id, "Ingrese la cuenta en la cual desea realizar la transacción:\n" + data.User.ShowAccountList());
                }
                else
                {
                    data.Channel.SendMessage(request.Id, "Debe ingresar un valor correspondiente al índice del tipo.");
                    data.Channel.SendMessage(request.Id, "Ingrese el tipo de transacción:\n1 - Ingreso\n2 - Gasto");
                }
            }
            else if (!data.Temp.ContainsKey("account"))
            {
                int index;
                if (Int32.TryParse(request.Text, out index) && index > 0 && index <= data.User.Accounts.Count)
                {
                    data.Temp.Add("account", data.User.Accounts[index - 1]);
                    data.Channel.SendMessage(request.Id, "Ingrese la moneda en la cual desea realizar la transacción:\n" + Bank.Instance.ShowCurrencyList());
                }
                else
                {
                    data.Channel.SendMessage(request.Id, "Debe ingresar un valor correspondiente al índice de la cuenta.");
                    data.Channel.SendMessage(request.Id, "Ingrese la cuenta en la cual desea realizar la transacción:\n" + data.User.ShowAccountList());
                }


            }
            else if (!data.Temp.ContainsKey("currency"))
            {
                int index;
                if (Int32.TryParse(request.Text, out index) && index > 0 && index <= Bank.Instance.CurrencyList.Count)
                {
                    data.Temp.Add("currency", Bank.Instance.CurrencyList[index - 1]);
                    data.Channel.SendMessage(request.Id, "Ingrese el monto de la transacción:");
                }
                else
                {
                    data.Channel.SendMessage(request.Id, "Debe ingresar un valor correspondiente al índice de la moneda.");
                    data.Channel.SendMessage(request.Id, "Ingrese la moneda en la cual desea realizar la transacción:\n" + Bank.Instance.ShowCurrencyList());
                }


            }
            else if (!data.Temp.ContainsKey("amount"))
            {
                double amount;
                if (double.TryParse(request.Text, out amount) && amount > 0)
                {
                    amount = data.GetDictionaryValue<int>("type") == 1 ? amount : -amount;
                    data.Temp.Add("amount", amount);

                    if (data.GetDictionaryValue<int>("type") == 1)
                    {
                        data.Channel.SendMessage(request.Id, "Ingrese una descripción de la transacción:");
                    }
                    else
                    {
                        data.Channel.SendMessage(request.Id, "Seleccione el rubro del gasto:\n" + data.User.ShowItemList());
                    }
                }
                else
                {
                    data.Channel.SendMessage(request.Id, "Debe ingresar un valor numérico mayor a 0.");
                    data.Channel.SendMessage(request.Id, "Ingrese el monto de la transacción:");
                }


            }
            else if (!data.Temp.ContainsKey("description"))
            {
                if (data.GetDictionaryValue<int>("type") == 2)
                {
                    int index;
                    if (Int32.TryParse(request.Text, out index) && index > 0 && index <= data.User.OutcomeList.Count)
                    {
                        data.Temp.Add("description", data.User.OutcomeList[index - 1]);
                    }
                    else
                    {
                        data.Channel.SendMessage(request.Id, "Debe ingresar un valor correspondiente al índice del rubro");
                        data.Channel.SendMessage(request.Id, "Seleccione el rubro del gasto:\n" + data.User.ShowItemList());
                        return;
                    }

                }
                else if (data.GetDictionaryValue<int>("type") == 1)
                {
                    data.Temp.Add("description", request.Text);
                }
            }



            if (data.Temp.ContainsKey("type") && data.Temp.ContainsKey("account") && data.Temp.ContainsKey("currency") && data.Temp.ContainsKey("amount") && data.Temp.ContainsKey("description"))
            {
                var type = data.GetDictionaryValue<int>("type");
                var account = data.GetDictionaryValue<Account>("account");
                var currency = data.GetDictionaryValue<Currency>("currency");
                var amount = data.GetDictionaryValue<double>("amount");
                var description = data.GetDictionaryValue<string>("description");

                account.AddTransaction(currency, amount, description);

                data.Channel.SendMessage(request.Id, "Se ha realizado una transacción.");

                if (account.Objective.Min > account.Balance)
                {
                    data.Channel.SendMessage(request.Id, "Ha sobrepasado su objetivo mínimo. Debe ahorrar más.");
                }
                else if (account.Objective.Max < account.Balance)
                {
                    data.Channel.SendMessage(request.Id, "Ha superado su objetivo máximo. Empiece a gastar.");
                }

                data.ClearOperation();
                return;
            }
        }
    }
}
