using System.Collections.Generic;

namespace Bankbot
{
    public class FilterPipe : IPipe
    {
        private IFilter Filter;
        private IPipe Next;
        public FilterPipe(IFilter filter, IPipe next)
        {
            this.Filter = filter;
            this.Next = next;
        }

        public List<Transaction> Send(List<Transaction> list)
        {
            list = this.Filter.Filter(list);
            return this.Next.Send(list);
        }

    }
}