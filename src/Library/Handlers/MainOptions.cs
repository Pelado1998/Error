using System;
using System.Collections.Generic;

namespace Bankbot
{
    //Implementacion
    public class MainOptions : AbstractHandler<Chats>
    {
        public MainOptions(MainCondition condition) : base(condition)
        {
        }

        protected override void handleRequest( Chats request)
        {
            switch (request.Message.Text)
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
    public class MainCondition : ICondition<Chats>
    {
        public bool IsSatisfied(Chats request)
        {
            return request.State == State.Idle && request.User == null;
        }
    }
}