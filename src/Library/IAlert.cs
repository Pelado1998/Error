using System;
using System.Collections.Generic;

namespace Bankbot
{
     /// <summary>
    /// La interface IAlert cumple con el patron Observer siendo el IObserver(observador) ,ya que es la que recibe 
    /// del IObservable(observado) las notificaciones de los cambios realizados y se encarga de enviar
    /// las alertas correspondientes.
    /// </summary>
    public interface IAlert
    {
        IObservable Obvservables{get;set;}
        void SendAlert()
        {
            //TODO
        }
    }
}