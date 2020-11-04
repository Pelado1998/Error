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
        public static void Read(Chats chats)
        {
            chats.Message.Text = System.Console.ReadLine();
        }
        static void Main(string[] args)
        {
            AbstractHandler<Chats> init = new Init(new InitCondition());
            AbstractHandler<Chats> mainOptions = new MainOptions(new MainCondition());
            AbstractHandler<Chats> createUser = new CreateUser(new CreateUserCondition());
            AbstractHandler<Chats> login = new Login(new LoginCondition());
            AbstractHandler<Chats> def = new Default(new DefaultCondition());


            init.Succesor = mainOptions;
            mainOptions.Succesor = createUser;
            createUser.Succesor = login;
            login.Succesor = def;

            Chats chats = new Chats(123);
            chats.State = State.Idle;
            chats.Temp = new List<Object>{};
            chats.User = null;
            chats.Message.Text = string.Empty;       
            while(true)
            {
                init.Handler(chats);
                Read(chats);
            }
        }
    }
}