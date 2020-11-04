using System;
using System.Collections.Generic;

namespace Bankbot
{
    //Implementacion
    public class Init : AbstractHandler<Chats>
    {
        public Init(InitCondition condition) : base(condition)
        {
        }

        protected override void handleRequest( Chats request)
        {
            if(request.User == null)
            {
                System.Console.WriteLine("Elija una de las siguientes opciones:\n\t1-Login\n\t2-CreateUser");
            }
            else
            {
                System.Console.WriteLine("Elija una de las siguientes opciones:\n\t1-CreateUser\n\t2-CreateUser");
            }
        }
    }
    public class InitCondition : ICondition<Chats>
    {
        public bool IsSatisfied(Chats request)
        {
            return request.State == State.Idle && request.Message.Text == string.Empty ;
        }
    }
}