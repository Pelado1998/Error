using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using System.Collections.Generic;

namespace Bankbot
{
    public enum State
    {
        CreateUser,
        DeleteUser,
        Login,
        CreateAccount,
        DeleteAccount,
        Transaction,
        Converting,
        Init,
        Dispatcher,
        Loged,
        LoggedAccounts,
    }
    public class Conversation
    {
        public string Id { get; set; }
        public State State { get; set; }
        public User User { get; set; }
        public Dictionary<string, object> Temp { get; set; }
        public string Message { get; set; }
        public IChannel Channel { get; set; }
        public Conversation(string id)
        {
            this.Id = id;
            this.State = State.Init;
            this.User = null;
            this.Temp = new Dictionary<string, object>();
        }
        public void CleanTemp()
        {
        }

        public T GetDictionaryValue<T>(string key)
        {
            return (T)Temp[key];
        }
    }
}