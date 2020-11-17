using System.Collections.Generic;

namespace Bankbot
{
    public class Search
    {
        private static Search instance;
        public static Search Instance
        {
            get
            {
                if (instance == null) instance = new Search();
                return instance;
            }
        }

        private Search() { }
        public void ApplyFilter(string id, List<Transaction> list)
        {
            var data = Session.Instance.GetChat(id);
            IPipe lastPipe = null;
            data.Filters.Reverse();

            foreach (var item in data.Filters)
            {
                IPipe nextPipe = lastPipe == null ? new PipeNull() : lastPipe;
                IPipe pipe = new FilterPipe(item, nextPipe);
                lastPipe = pipe;
            }

            if (data.Filters.Count == 0)
            {
                lastPipe = new FilterPipe(new FilterNull(), new PipeNull());
            }

            Session.Instance.Printer.Print(lastPipe.Send(list));
        }
    }
}