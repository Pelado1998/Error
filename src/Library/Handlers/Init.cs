using System;
using System.Collections.Generic;

namespace Bankbot
{
    //Implementacion
    public class Init : AbstractHandler<IMessage>
    {
        public Init(InitCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            AllChats.Instance.AddChat(request);
            System.Console.WriteLine("Bienvenido!");
            Options(request);

        }
         public static void Options(IMessage request)
        {
            if((User)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["User"]==User.Empty)
            {
                System.Console.WriteLine("Elija un comando de la siguiente lista:\n"+ AllCommands.CommandsString(1));
            }
            else if (((User)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["User"]).Accounts.Count == 0)
            {
                System.Console.WriteLine("Elija un comando de la siguiente lista:"+ AllCommands.CommandsString(2));
            }
            else 
            {
                System.Console.WriteLine("Elija un comando de la siguiente lista:" + AllCommands.CommandsString(3));
            }
        }
    }
}