using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class Convertion : AbstractHandler<IMessage>
    {
        public Convertion(ConvertionCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            var data = Session.Instance.GetChat(request.Id);

            if (!data.Temp.ContainsKey("from"))
            {
                int index;
                if (Int32.TryParse(request.Text, out index) && index <= Bank.Instance.CurrencyList.Count)
                {
                    data.Temp.Add("from", Bank.Instance.CurrencyList[index - 1]);
                    data.Channel.SendMessage(request.Id, "Seleccione a que moneda desea convertir:\n" + Bank.Instance.ShowCurrencyList());
                }
                else
                {
                    data.Channel.SendMessage(request.Id, "Debe seleecionar un valor correspondiente al índice de la moneda.");
                    data.Channel.SendMessage(request.Id, "Seleccione la moneda desde la que desea convertir:\n" + Bank.Instance.ShowCurrencyList());
                }
            }
            else if (!data.Temp.ContainsKey("to"))
            {
                int index;
                if (Int32.TryParse(request.Text, out index) && index <= Bank.Instance.CurrencyList.Count)
                {
                    if (Bank.Instance.CurrencyList[index - 1] != data.GetDictionaryValue<Currency>("from"))
                    {
                        data.Temp.Add("to", Bank.Instance.CurrencyList[index - 1]);
                        data.Channel.SendMessage(request.Id, "Ingrese el monto que desea convertir:");
                    }
                    else
                    {
                        data.Channel.SendMessage(request.Id, "Debe seleecionar una moneda diferente.");
                        data.Channel.SendMessage(request.Id, "Seleccione la moneda desde la que desea convertir:\n" + Bank.Instance.ShowCurrencyList());
                    }
                }
                data.Channel.SendMessage(request.Id, "Debe seleecionar un valor correspondiente al índice de la moneda.");
                data.Channel.SendMessage(request.Id, "Seleccione la moneda desde la que desea convertir:\n" + Bank.Instance.ShowCurrencyList());
            }
            else if (!data.Temp.ContainsKey("amount"))
            {
                double amount;
                if (double.TryParse(request.Text, out amount) && amount > 0)
                {
                    data.Temp.Add("amount", amount);
                }

                data.Channel.SendMessage(request.Id, "Debe ingresar un valor numérico mayor a 0.");
                data.Channel.SendMessage(request.Id, "Ingrese el monto que desea convertir:");
            }

            if (data.Temp.ContainsKey("from") && data.Temp.ContainsKey("to") && data.Temp.ContainsKey("amount"))
            {
                var amount = data.GetDictionaryValue<double>("amount");
                var from = data.GetDictionaryValue<Currency>("from");
                var to = data.GetDictionaryValue<Currency>("to");

                var newAmount = Bank.Instance.Convert(amount, from, to);
                data.Channel.SendMessage(request.Id, $"{from.CodeISO} {amount} equivalen a {to.CodeISO} {newAmount}");

                data.ClearOperation();
            }
        }
    }
}