using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class Convertion : AbstractHandler<Conversation>
    {
        public Convertion(ConvertionCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(Conversation request)
        {
            if (!request.Temp.ContainsKey("from"))
            {
                int index;
                if (Int32.TryParse(request.Message, out index) && index <= Bank.Instance.CurrencyList.Count)
                {
                    request.Temp.Add("from", Bank.Instance.CurrencyList[index - 1]);
                    request.Channel.SendMessage(request.Id, "Seleccione a que moneda desea convertir:\n" + Bank.Instance.ShowCurrencyList());
                    return;
                }
                request.Channel.SendMessage(request.Id, "Debe seleecionar un valor correspondiente al índice de la moneda.");
                request.Channel.SendMessage(request.Id, "Seleccione la moneda desde la que desea convertir:\n" + Bank.Instance.ShowCurrencyList());
            }
            else if (!request.Temp.ContainsKey("to"))
            {
                int index;
                if (Int32.TryParse(request.Message, out index) && index <= Bank.Instance.CurrencyList.Count)
                {
                    if (Bank.Instance.CurrencyList[index - 1] != request.GetDictionaryValue<Currency>("from"))
                    {
                        request.Temp.Add("to", Bank.Instance.CurrencyList[index - 1]);
                        request.Channel.SendMessage(request.Id, "Ingrese el monto que desea convertir:");
                        return;
                    }
                    request.Channel.SendMessage(request.Id, "Debe seleecionar una moneda diferente.");
                    request.Channel.SendMessage(request.Id, "Seleccione la moneda desde la que desea convertir:\n" + Bank.Instance.ShowCurrencyList());
                    return;
                }
                request.Channel.SendMessage(request.Id, "Debe seleecionar un valor correspondiente al índice de la moneda.");
                request.Channel.SendMessage(request.Id, "Seleccione la moneda desde la que desea convertir:\n" + Bank.Instance.ShowCurrencyList());
            }
            else if (!request.Temp.ContainsKey("amount"))
            {
                float amount;
                if (float.TryParse(request.Message, out amount) && amount > 0)
                {
                    request.Temp.Add("amount", amount);
                }
                request.Channel.SendMessage(request.Id, "Debe ingresar un valor numérico mayor a 0.");
                request.Channel.SendMessage(request.Id, "Ingrese el monto que desea convertir:");
            }

            if (request.Temp.ContainsKey("from") && request.Temp.ContainsKey("to") && request.Temp.ContainsKey("amount"))
            {
                var amount = request.GetDictionaryValue<float>("amount");
                var from = request.GetDictionaryValue<Currency>("from");
                var to = request.GetDictionaryValue<Currency>("to");

                var newAmount = Bank.Instance.Convert(amount, from, to);
                request.Channel.SendMessage(request.Id, $"{from.CodeISO} {amount} equivalen a {to.CodeISO} {newAmount}");

                request.Temp.Clear();
                request.State = State.Dispatcher;
            }
        }
    }
}