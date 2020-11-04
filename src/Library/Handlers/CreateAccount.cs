using System;
using System.Collections.Generic;
using System.Text;

namespace Bankbot
{
    public class CreateAccount : AbstractHandler<Chats>
    {
        public CreateAccount(CreateAccountCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(Chats request)
        {
            switch (request.State)
            {
                case State.CreateAccountName:
                    
                    request.State = State.CreateAccountType;
                    request.Temp.Add(request.Message.Text);
                    System.Console.WriteLine("Ingrese un tipo de cuenta\n" + ShowAccountType());

                break;
                case State.CreateAccountType:

                    switch (request.Message.Text)
                    {
                        
                        request.Temp.Add((AccountType[request.Message.Text]))
                        case "1":

                            request.Temp.Add(AccountType.CuentaDeAhorro);

                        break;
                        case "2":

                            request.Temp.Add(AccountType.Credito);

                        case "3":

                            request.Temp.Add(AccountType.Debito);

                        default:
                            System.Console.WriteLine("Valor Incorrecto");
                            System.Console.WriteLine("Ingrese nuevamente un tipo de cuenta\n" + ShowAccountType());
                            return;                    
                    }
                    request.State = State.CreateAccountCurrency;
                    System.Console.WriteLine("Ingrese una divisa\n" + ShowCurrencyList());
                    
                break;                  
                case State.CreateAccountCurrency:

                    int idx;
                    if (Int32.TryParse(request.Message.Text,out idx))
                    {
                        request.Temp.Add(Bank.Instance.CurrencyList[idx]);
                        request.State = State.CreateAccountAmount;
                    }
                    else
                    {
                        System.Console.WriteLine("Ingrese un valor válido");
                        System.Console.WriteLine("Ingrese una divisa\n" + ShowCurrencyList());
                    }
                    System.Console.WriteLine("Ingrese un monto para la cuenta");

                break;
                case State.CreateAccountAmount:

                    if (Int32.TryParse(request.Message.Text,out idx))
                    {
                        request.Temp.Add(Bank.Instance.CurrencyList[idx]);
                        request.State = State.CreateAccountObjective;
                    }
                    else
                    {
                        System.Console.WriteLine("Ingrese un valor válido");
                    }
                    System.Console.WriteLine("Ingrese un objetivo para la cuenta");

                break;               
                case State.CreateAccountObjective:

                    if (Int32.TryParse(request.Message.Text,out idx))
                    {
                        request.Temp.Add(Bank.Instance.CurrencyList[idx]);
                        request.State = State.CreateAccountObjective;
                    }
                    else
                    {
                        System.Console.WriteLine("Ingrese un valor válido");
                    }
                    request.User.AddAccount(request.Temp[0],request.Temp[1],request.Temp[2],request.Temp[3],request.Temp[4]);
                    System.Console.WriteLine("Cuenta creada con éxito!");
                    request.CleanTemp();

                break;
            }

        } 
        private static string ShowAccountType()
        {
            StringBuilder enumToText = new StringBuilder();
            var accountType = Enum.GetNames(typeof(AccountType));
            foreach (var item in accountType)
            {
                enumToText.Append($"{Array.IndexOf(accountType, item) + 1 } - {item}\n");
            }
            return enumToText.ToString();
        }
        private static string ShowCurrencyList()
         {
             StringBuilder currencies = new StringBuilder();
             foreach (Currency currency in Bank.Instance.CurrencyList)
             {
                 System.Console.WriteLine(currency.CodeISO);
                 currencies.Append($"{Bank.Instance.CurrencyList.IndexOf(currency) + 1} - {currency.CodeISO}\n");
             }
             return currencies.ToString();
         }
    }
    public class CreateAccountCondition : ICondition<Chats>
    {
        public bool IsSatisfied(Chats request)
        {
            return request.User != null
                &&
                (
                   request.State == State.CreateAccountName
                && request.State == State.CreateAccountType
                && request.State == State.CreateAccountCurrency
                && request.State == State.CreateAccountAmount
                && request.State == State.CreateAccountObjective
                );
        }
    }
}