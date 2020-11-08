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
            Data data = Data.Empty;
            if (!AllChats.Instance.ChatsDictionary.TryGetValue(request.id, out data))
            {
                AllChats.Instance.AddChat(request);
                System.Console.WriteLine("Bienvenido!");
            }
            Options(request);
            AllChats.Instance.ChatsDictionary[request.id].DataDictionary["LastCommand"] = "\\Init";
        }
         public static void Options(IMessage request)
        {
            System.Console.WriteLine("Elija un comando de la siguiente lista:\n"+ AllCommands.CommandsString(request));            
        }
    }
}