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
            AbstractHandler<Chats> convertion = new Convertion(new ConvertionCondition());
            AbstractHandler<Chats> dispatcher = new Dispatcher (new DispatcherCondition());
            AbstractHandler<Chats> login = new Login(new LoginCondition());           
            AbstractHandler<Chats> createUser = new CreateUser(new CreateUserCondition());
            AbstractHandler<Chats> deleteUser = new DeleteUser(new DeleteUserCondition());
            AbstractHandler<Chats> createAccount = new CreateAccount(new CreateAccountCondition());
            AbstractHandler<Chats> deleteAccount = new DeleteAccount(new DeleteAccountCondition());
            AbstractHandler<Chats> def = new Default(new DefaultCondition());

            init.AddSuccesor(convertion);
            convertion.AddSuccesor(dispatcher);
            dispatcher.AddSuccesor(login); 
            login.AddSuccesor(createUser);
            createUser.AddSuccesor(deleteUser);
            deleteUser.AddSuccesor(createAccount);
            createAccount.AddSuccesor(deleteAccount);
            deleteAccount.AddSuccesor(def);
            Chats chats = new Chats(123);      
            while(true)
            {
                init.Handler(chats);
                Read(chats);}
        }
    }
}