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
                        request.AccountType = (AccountType) index;
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
                    if (Int32.TryParse(request.Message.Text,out idx) && Bank.Instance.CurrencyList.Count-1 <=idx)
                    {
                        request.AccountCurrency = Bank.Instance.CurrencyList[idx];
                        request.State = State.CreateAccountAmount;
                    }
                    else
                    {
                        System.Console.WriteLine("Ingrese un valor válido");
                        System.Console.WriteLine("Ingrese una divisa\n" + ShowCurrencyList());
                        return;
                    }
                    System.Console.WriteLine("Ingrese un monto para la cuenta");

                break;
                case State.CreateAccountAmount:

                    int amount;
                    if (Int32.TryParse(request.Message.Text,out amount))
                    {
                        request.AccountAmount = amount;
                        request.State = State.CreateAccountObjective;
                    }
                    else
                    {
                        System.Console.WriteLine("Ingrese un valor válido");
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

                break;
            }
        } 
    }        
        

    
    public class CreateAccountCondition : Bankbot.ICondition<Chats>
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