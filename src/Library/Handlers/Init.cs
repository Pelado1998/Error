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
                ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Bienvenido!");
            }
            Options(request);
            ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"También puedes utilizar el comando /Abort para abortar cualquier actividad que estés realizando");
            AllChats.Instance.ChatsDictionary[request.id].DataDictionary["LastCommand"] = "/Init";
        }
         public static void Options(IMessage request)
        {
            ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Elija un comando de la siguiente lista:\n"+ AllCommands.CommandsString(request));          
        }
    }
}