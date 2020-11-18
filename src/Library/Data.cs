using System.Collections.Generic;

namespace Bankbot
{
    public enum State
    {
        Init,
        Dispatcher,
        HandlingCommand
    }
    /// <summary>
    /// 
    /// </summary>
    public class Data
    {
        public State State { get; set; }
        public string Command { get; set; }
        public User User { get; set; }
        public Dictionary<string, object> Temp { get; set; }
        public IChannel Channel { get; set; }
        public string Id { get; set;}
        public Data(string Id)
        {
            this.State = State.Init;
            this.Command = string.Empty;
            this.User = null;
            this.Temp = new Dictionary<string, object>();
            this.Channel = null;
            this.Id = Id;
        }

        public T GetDictionaryValue<T>(string key)
        {
            return (T)Temp[key];
        }
    }
}