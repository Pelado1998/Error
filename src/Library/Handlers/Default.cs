using System;
using System.Collections.Generic;

namespace Bankbot
{
    //Implementacion
    public class Default : AbstractHandler<IMessage>
    {
        public Default(DefaultCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            System.Console.WriteLine("No te entendi. Vuelve a intentarlo.");
        }
    }
}