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
            if (AllChats.Instance.ChatsDictionary[request.id].DataDictionary["User"] !=User.Empty)
            {
                 AllChats.Instance.ChatsDictionary[request.id].ClearUser();
                ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Usted se a deslogueado");
            }
            else
            {
                ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Usted ya se encuentra deslogueado");
            }
        }
    }
}