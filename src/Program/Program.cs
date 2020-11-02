using System;
using System.IO;
using System.Collections.Generic;

namespace Bankbot
{
    //Mejoras, implementar una clse password y Name, para que se determine si una contrasenia es valida y fuerte, y el nombre debe contener nombre y apellido
    //Ver como hacemos el historial
    //Tipos de cuenta como enums
    //IPrintable?

    class Program
    {
        static void Main(string[] args)
        {
            Chats chats = new Chats(123);                                       //Chat de prueba
            chats.History = new List<string>{"1","2"};
            chats.State = State.Idle;
            chats.Temp = new List<Object> {1,"Prueba"};
            chats.User = null;
            AbstractHandler<Chats> handler = new Handler1(new Condition1());    //
            handler.Handler(chats);
        }
    }
}
