using System;
using System.Collections.Generic;

namespace Bankbot
{
    public enum Channel
    {
    Telegram=1,
    Whatsapp=2,
    Twitter=3
    }
    public interface IAlert
    {
        IObservable obvservable{get;set;}
        string alertName {get;set;}
        List<Channel> channels {get;set;}
        void SendAlert()
        {
            //TODO
        }

    }
}