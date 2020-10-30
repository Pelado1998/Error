using System;
using System.Collections.Generic;

namespace Bankbot
{
    public enum State
    {
        Idle,
        Login,
        CreateUser
    }
    public class Chats
    {
        public long Id { get; set; }
        public List<string> History { get; set; }
        public State State { get; set; }
        public User User { get; set; }

        public Chats(long id)
        {
            this.Id = id;
            this.History = new List<string>();
            this.State = State.Idle;
            this.User = null;
        }
    }
}