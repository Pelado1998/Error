using System;


namespace Bankbot
{
    //Implementacion
    public class Handler1 : AbstractHandler<Chats>
    {
        public Handler1(Condition1 condition) : base(condition)
        {
        }

        protected override void handleRequest(ref Chats request)
        {
            System.Console.WriteLine("Elija una de las siguientes opciones\n\t1-Login\n\t2-CreateUser");
            switch (request.Message)
            {
                case "1":
                    request.State = State.LoginUsername;
                    System.Console.WriteLine("Ingrese el Username");
                break;
                case "2":
                    request.State = State.CreateUsername;
                    System.Console.WriteLine("Ingrese un Username");
                break;
                default:
                    System.Console.WriteLine("Ingrese un valor correcto: 1 o 2");
                break;
            }
        }
    }
    public class Condition1 : ICondition<Chats>
    {
        public bool IsSatisfied(Chats request)
        {
            return request.State == State.Idle && request.User == null;
        }
    }
}