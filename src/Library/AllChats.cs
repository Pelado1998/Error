using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class AllChats
    {
        public Dictionary<string,Data> ChatsDictionary { get; set; }
        private static AllChats instance;
        
        public static AllChats Instance
        {
            get
            {
                if (instance == null) instance = new AllChats();
                return instance;
            }
        }
        private AllChats()
        {
            this.ChatsDictionary = new Dictionary<string,Data>();         
        }
        public bool ChatExist(string id)
        {
            return instance.ChatsDictionary.ContainsKey(id);
        }
        public void AddChat(IMessage message)
        {
            Data data = new Data();
            data.DataDictionary["LastCommand"] = "/Init";
            this.ChatsDictionary.Add(message.id,data);
        }
    }
}
