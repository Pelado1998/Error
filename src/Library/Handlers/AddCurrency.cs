using System;

namespace Bankbot
{
    public class AddCurrencyHandler : AbstractHandler<IMessage>
    {
        public AddCurrencyHandler(AddCurrency condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            var data = Session.Instance.GetChat(request.Id);

            if (!data.Temp.ContainsKey("iso"))
            {
                data.Temp.Add("iso", request.Text);
                data.Channel.SendMessage(request.Id, "Ingrese el símbolo de la nueva moneda:");
            }
            else if (!data.Temp.ContainsKey("symbol"))
            {
                data.Temp.Add("symbol", request.Text);
                data.Channel.SendMessage(request.Id, "Ingrese la taza de cambio basada en doalr:");
            }
            else if (!data.Temp.ContainsKey("rate"))
            {
                double rate;
                if (double.TryParse(request.Text, out rate) && rate > 0)
                {
                    data.Temp.Add("rate", rate);
                }
                else
                {
                    data.Channel.SendMessage(request.Id, "Debe ingresar un valor numérico mayor a 0");
                    data.Channel.SendMessage(request.Id, "Ingrese la taza de cambio basada en doalr:");
                }
            }

            if (data.Temp.ContainsKey("iso") && data.Temp.ContainsKey("symbol") && data.Temp.ContainsKey("rate"))
            {
                var iso = data.GetDictionaryValue<string>("iso");
                var symbol = data.GetDictionaryValue<string>("symbol");
                var rate = data.GetDictionaryValue<double>("rate");

                if (!Bank.Instance.CurrencyExists(iso, symbol))
                {
                    Bank.Instance.AddCurrency(iso, symbol, rate);
                    data.Channel.SendMessage(request.Id, "Se ha agregado una nueva moneda.");
                }
                else
                {
                    data.Channel.SendMessage(request.Id, "Esta moneda ya existe, para crear una nueva moneda ingrese /addcurrency.");
                }
                data.ClearOperation();
            }
        }
    }
}