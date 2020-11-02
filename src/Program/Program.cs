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
            chats.Message = "2";
            AbstractHandler<Chats> handler1 = new Handler1(new Condition1());
            AbstractHandler<Chats> handler2 = new Handler2(new Condition2());
            handler1.Succesor = handler2;
            handler1.Handler(ref chats);
            
        }
    }
}
