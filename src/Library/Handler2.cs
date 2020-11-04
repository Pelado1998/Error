using System;

namespace Bankbot
{
    //Implementacion
    public class Handler2 : AbstractHandler<Chats>
    {
        public Handler2(Condition2 condition) : base(condition)
        {
        }

        protected override void handleRequest(ref Chats request)
        {
            System.Console.WriteLine("Crear un usuario");
        }
    }
    public class Condition2 : ICondition<Chats>
    {
        public bool IsSatisfied(Chats request)
        {
            return request.State == State.CreateAccountAmount;
        }
    }
}