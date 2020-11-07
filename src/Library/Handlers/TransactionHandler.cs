using System;

namespace Bankbot
{
    public class TransactionHandler : AbstractHandler<Conversation>
    {
        public TransactionHandler(TransactionCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(Conversation request)
        {
            System.Console.WriteLine("asd");
            if (!request.Temp.ContainsKey("type"))
            {
                int index;
                if (Int32.TryParse(request.Message, out index) && (index > 0 && index < 3))
                {
                    System.Console.WriteLine(index + 123456786435);
                    request.Temp.Add("type", index);
                    request.Channel.SendMessage(request.Id, "Ingrese la cuenta en la cual desea realizar la transacción:\n" + request.User.ShowAccountList());
                }
                else
                {
                    request.Channel.SendMessage(request.Id, "Debe ingresar un valor correspondiente al índice del tipo.");
                    request.Channel.SendMessage(request.Id, "Ingrese el tipo de transacción:\n1 - Ingreso\n2 - Gasto");
                }
            }
            else if (request.Temp.ContainsKey("type") && !request.Temp.ContainsKey("account"))
            {
                int index;
                if (Int32.TryParse(request.Message, out index) && index <= request.User.Accounts.Count)
                {
                    request.Temp.Add("account", request.User.Accounts[index - 1]);
                    request.Channel.SendMessage(request.Id, "Ingrese la moneda en la cual desea realizar la transacción:\n" + Bank.Instance.ShowCurrencyList());
                }
                else
                {
                    request.Channel.SendMessage(request.Id, "Debe ingresar un valor correspondiente al índice de la cuenta.");
                    request.Channel.SendMessage(request.Id, "Ingrese la cuenta en la cual desea realizar la transacción:\n" + request.User.ShowAccountList());
                }
            }
            else if (request.Temp.ContainsKey("account") && !request.Temp.ContainsKey("currency"))
            {
                int index;
                if (Int32.TryParse(request.Message, out index) && index < Bank.Instance.CurrencyList.Count)
                {
                    request.Temp.Add("currency", Bank.Instance.CurrencyList[index - 1]);
                    request.Channel.SendMessage(request.Id, "Ingrese el monto de la transacción:");
                }
                else
                {
                    request.Channel.SendMessage(request.Id, "Debe ingresar un valor correspondiente al índice de la moneda.");
                    request.Channel.SendMessage(request.Id, "Ingrese la moneda en la cual desea realizar la transacción:\n" + Bank.Instance.ShowCurrencyList());
                }
            }
            else if (request.Temp.ContainsKey("currency") && !request.Temp.ContainsKey("amount"))
            {
                float amount;
                if (float.TryParse(request.Message, out amount) && amount > 0)
                {
                    request.Temp.Add("amount", amount);
                    if (request.GetDictionaryValue<int>("type") == 1)
                    {
                        request.Channel.SendMessage(request.Id, "Ingrese una descripción de la transacción:");
                    }
                    else
                    {
                        request.Channel.SendMessage(request.Id, "Seleccione el rubro del gasto:\n" + request.User.ShowItemList());
                    }
                }
                else
                {
                    request.Channel.SendMessage(request.Id, "Debe ingresar un valor numérico mayor a 0.");
                    request.Channel.SendMessage(request.Id, "Ingrese el monto de la transacción:");
                }
            }
            else if (request.Temp.ContainsKey("type") && request.GetDictionaryValue<int>("type") == 2 && !request.Temp.ContainsKey("item"))
            {
                int index;
                if (Int32.TryParse(request.Message, out index) && index < request.User.OutcomeList.Count)
                {
                    request.Temp.Add("item", request.User.OutcomeList[index - 1]);
                    request.Channel.SendMessage(request.Id, "Ingrese una descripción de la transacción:");
                }
                else
                {
                    request.Channel.SendMessage(request.Id, "Debe ingresar un valor correspondiente al índice del rubro");
                    request.Channel.SendMessage(request.Id, "Seleccione el rubro del gasto:\n" + request.User.ShowItemList());
                }
            }
            else if (request.Temp.ContainsKey("type") && !request.Temp.ContainsKey("description"))
            {
                request.Temp.Add("description", request.Message);
            }



            if (request.Temp.ContainsKey("type") && request.Temp.ContainsKey("account") && request.Temp.ContainsKey("currency") && request.Temp.ContainsKey("amount") && request.Temp.ContainsKey("description"))
            {
                var type = request.GetDictionaryValue<int>("type");
                var account = request.GetDictionaryValue<Account>("account");
                var currency = request.GetDictionaryValue<Currency>("currency");
                var amount = request.GetDictionaryValue<float>("amount");
                var description = request.GetDictionaryValue<string>("description");

                if (type == 1)
                {

                    account.AddIncome(currency, amount, description);
                }
                else if (type == 2)
                {
                    var item = request.GetDictionaryValue<string>("item");
                    account.AddOutcome(currency, -amount, item, description);
                }

                request.Channel.SendMessage(request.Id, "Se ha realizado una transacción.");
                request.Temp.Clear();
                request.State = State.Dispatcher;
            }
        }
    }
}
