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
            // switch (request.State)
            // {
            //     case State.ConvertAmount:
            //         int amount;
            //         if (Int32.TryParse(request.Message, out amount))
            //         {
            //             request.ConvertionAmount = amount;
            //             request.State = State.ConvertFrom;
            //             System.Console.WriteLine("Ingrese una divisa de partida\n" + Bank.ShowCurrencyList());
            //         }
            //         else
            //         {
            //             System.Console.WriteLine("Ingrese un valor válido");
            //             System.Console.WriteLine("Ingrese un monto para la transacción");
            //         }

            //         break;
            //     case State.ConvertFrom:
            //         int idx;
            //         if (Int32.TryParse(request.Message.Text, out idx) && idx <= Bank.Instance.CurrencyList.Count)
            //         {
            //             request.ConvertionFrom = Bank.Instance.CurrencyList[idx - 1];
            //             request.State = State.ConvertTo;
            //             System.Console.WriteLine("Ingrese una divisa de llegada\n" + Bank.ShowCurrencyList());
            //         }
            //         else
            //         {
            //             System.Console.WriteLine("Ingrese un valor válido");
            //             System.Console.WriteLine("Ingrese una divisa\n" + Bank.ShowCurrencyList());
            //         }
            //         break;
            //     case State.ConvertTo:
            //         int index;
            //         if (Int32.TryParse(request.Message.Text, out index) && index <= Bank.Instance.CurrencyList.Count)
            //         {
            //             request.ConvertionTo = Bank.Instance.CurrencyList[index - 1];
            //             System.Console.WriteLine("Conversión:");
            //             System.Console.WriteLine($"{request.ConvertionAmount} {request.ConvertionFrom} ~ {Bank.Convert(request.ConvertionAmount, request.ConvertionFrom, request.ConvertionTo)} {request.ConvertionTo}");
            //             request.CleanTemp();
            //             Init.Options(request);
            //             Login.LoginState(request);
            //         }
            //         else
            //         {
            //             System.Console.WriteLine("Ingrese un valor válido");
            //             System.Console.WriteLine("Ingrese una divisa\n" + Bank.ShowCurrencyList());
            //         }
            //         break;
            // }
        }
    }
}