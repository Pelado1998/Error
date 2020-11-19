using System.Collections.Generic;

namespace Bankbot
{
    public enum State
    {
        Init,
        Dispatcher,
        HandlingCommand
    }
    public class Data
    {
        public State State { get; set; }
        public string Command { get; set; }
        public User User { get; set; }
        public Dictionary<string, object> Temp { get; set; }
        public IChannel Channel { get; set; }
        public List<IFilter> Filters { get; set; }
        public Data()
        {
            this.State = State.Init;
            this.Command = string.Empty;
            this.User = null;
            this.Temp = new Dictionary<string, object>();
            this.Channel = null;
            this.Filters = new List<IFilter>();
        }

        public void ClearOperation()
        {
            this.State = State.Dispatcher;
            this.Temp.Clear();
            this.Command = string.Empty;
        }
        public T GetDictionaryValue<T>(string key)
        {
            return (T)Temp[key];
        }
    }
}