using System;
using System.Collections.Generic;

namespace Bankbot
{
    public abstract class AbstractHandler <T>
    {
        protected abstract void handleRequest (T request);
        private ICondition <T> condition;
        public AbstractHandler <T> Succesor {get;set;}
        protected AbstractHandler(ICondition<T> condition)
        {
            this.condition = condition;
        }
        public virtual void Handler(T request)
        {
            if (this.condition.IsSatisfied(request))
            {
                this.handleRequest(request);
            }
            else
            {
                if (this.Succesor!=null)
                {
                    this.Succesor.Handler(request);
                }
            }
        }
    }
}
