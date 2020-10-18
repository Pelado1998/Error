using System;
using System.Collections.Generic;

namespace Bankbot
{
    public interface IAlert
    {
        IObservable Obvservables{get;set;}
        string alertName {get;set;}
        void SendAlert()
        {
            //TODO
        }
    }
}