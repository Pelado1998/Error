using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class Convertion : AbstractHandler<IMessage>
    {
        public Convertion(ConvertionCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            
        }
    }
}