using System;
using System.Collections.Generic;
using System.Text;
using static Bankbot.Account;
using static Bankbot.Bank;

namespace Bankbot
{
    public class CreateAccount : AbstractHandler<Chats>
    {
        public CreateAccount(ICondition<Chats> condition) : base(condition)
        {
        }

        protected override void handleRequest(Chats request)
        {
            switch (request.State)
            {
                case State.CreateAccountName:
                    
                    request.State = State.CreateAccountType;
                    request.AccountName = request.Message.Text;
                    System.Console.WriteLine("Ingrese un tipo de cuenta\n" + ShowAccountType());

                break;
                case State.CreateAccountType:
                    int index;
                    if (Int32.TryParse(request.Message.Text,out index) && index<=Account.AmountTypes())
                    {
                        request.AccountType = (AccountType) index;  //TODO:
                    }
                    else
                    {
                        System.Console.WriteLine("Valor Incorrecto");
                        System.Console.WriteLine("Ingrese nuevamente un tipo de cuenta\n" + ShowAccountType());
                        return;  
                    }   
                    request.State = State.CreateAccountCurrency;
                    System.Console.WriteLine("Ingrese una divisa\n" + ShowCurrencyList());
                    
                break;                  
                case State.CreateAccountCurrency:

                    int idx;
                    if (Int32.TryParse(request.Message.Text,out idx) && idx<=Bank.Instance.CurrencyList.Count )
                    {
                        request.AccountCurrency = Bank.Instance.CurrencyList[idx];
                        request.State = State.CreateAccountAmount;
                        System.Console.WriteLine("Ingrese un monto para la cuenta");
                    }
                    else
                    {
                        System.Console.WriteLine("Ingrese un valor válido");
                        System.Console.WriteLine("Ingrese una divisa\n" + ShowCurrencyList());
                    }

                break;
                case State.CreateAccountAmount:

                    double amount;
                    if (Double.TryParse(request.Message.Text,out amount))
                    {
                        request.AccountAmount = amount;
                        request.State = State.CreateAccountObjective;
                    }
                    else
                    {
                        System.Console.WriteLine("Ingrese un valor válido");
                        System.Console.WriteLine("Ingrese un monto para la cuenta");
                        return;
                    }
                    System.Console.WriteLine("Ingrese un objetivo para la cuenta");

                break;               
                case State.CreateAccountObjective:

                    int objective;
                    if (Int32.TryParse(request.Message.Text,out objective))
                    {
                        request.AccountObjective = objective;
                        Login.LoginState(request);
                    }
                    else
                    {
                        System.Console.WriteLine("Ingrese un valor válido");
                        return;
                    }
                    request.User.AddAccount(request.AccountName, request.AccountType,request.AccountCurrency,request.AccountAmount,request.AccountObjective);
                    System.Console.WriteLine("Cuenta creada con éxito!");
                    request.CleanTemp();
                    Init.Options(request);
                    Login.LoginState(request);
                break;
            }
        } 
    }        
}