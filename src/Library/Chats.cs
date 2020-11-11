using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using System.Collections.Generic;

namespace Bankbot
{
    public class Chats
    {
        public Data Data {get;set;}
        public Chats(string id)
        {
            this.Data = new Data();
        }
    }
}