using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class Dispatcher : AbstractHandler<Chats>
    {
        public Dispatcher(DispatcherCondition condition) : base(condition)
        {
        }

        protected override void handleRequest( Chats request)
        {
            switch (request.Message.Text)
            {
                case "0":
                    if (request.State == State.Dispatcher)
                    {
                        request.State = State.LoginUsername;
                        System.Console.WriteLine("Ingrese el Username");
                    }
                break;
                case "1":
                    request.State = State.ConvertFrom;
                    System.Console.WriteLine("Ingrese la divisa desde la cual quiere convertir");
                break;
                case "2":
                    request.State = State.CreateUsername;
                    System.Console.WriteLine("Ingrese un Username");
                break;
                case "3":
                    if (request.State == State.Loged || request.State == State.LogedAccounts )
                    {
                        request.State = State.DeleteUserName;
                        System.Console.WriteLine("Ingrese el Username que quiere eliminar");  
                    }
                break;
                case "4":
                    if (request.State == State.Loged || request.State == State.LogedAccounts )
                    {
                        request.State = State.CreateAccountName;
                        System.Console.WriteLine("Ingrese un AccountName");
                    } 
                break;
                case "5":
                    if (request.State == State.LogedAccounts )
                    {
                        request.State = State.DeleteAccountName;
                        System.Console.WriteLine("Ingrese el AccontName de la cuenta que quiere borrar");
                    }
                break;
                case "6":
                    if (request.State == State.LogedAccounts )
                    {
                        request.State = State.CreateTransactionAccount;
                        System.Console.WriteLine("Ingrese un monto para la transacción");
                    }
                break;
                default:
                    System.Console.WriteLine("Ingrese un valor correcto por favor");
                    Init.Options(request);
                break;
            }
        }
    }
    public class DispatcherCondition : ICondition<Chats>
    {
        public bool IsSatisfied(Chats request)
        {
            return request.State == State.Dispatcher || request.State == State.Loged || request.State == State.LogedAccounts;
        }
    }
}