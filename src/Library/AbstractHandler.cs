using System;


namespace Bankbot
{
    public abstract class AbstractHandler <T>
    {
        protected abstract void handleRequest (ref T request);
        private ICondition <T> condition;
        public AbstractHandler <T> Succesor {get;set;}
        protected AbstractHandler(ICondition<T> condition)
        {
            this.condition = condition;
        }
        public virtual void Handler(ref T request)
        {
            if (this.condition.IsSatisfied(request))
            {
                this.handleRequest(ref request);
            }
            else
            {
                if (this.Succesor!=null)
                {
                    this.Succesor.Handler(ref request);
                }
            }
        }
    }
}
