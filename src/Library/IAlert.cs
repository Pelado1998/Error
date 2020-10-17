using System;
using System.Collections.Generic;

namespace Bankbot
{
    public interface IAlert
    {
        IObservable obvservable{get;set;}
        string alertName {get;set;}
        void SendAlert()
        {
            //TODO
        }

    }
}