using System;

namespace Bankbot
{
    public class Logout : AbstractHandler<IMessage>
    {
        public Logout(LogoutCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            AllChats.Instance.ChatsDictionary[request.id].ClearUser();
            ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Usted se a deslogueado");
        }
    }
}