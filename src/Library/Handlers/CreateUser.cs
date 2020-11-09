using System;

namespace Bankbot
{
    public class CreateUser : AbstractHandler<IMessage>
    {
        public CreateUser(CreateUserCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            if ((String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateUserUsername"] == string.Empty && request.message== "/CreateUser")
            {
                ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese un Username");
            }
            else if ((String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateUserUsername"] == string.Empty)
            {
                AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateUserUsername"] = request.message;
                ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese una Password");
            }
            else if ((String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateUserPassword"] == string.Empty)
            {
                AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateUserPassword"] = request.message;
                AllUsers.Instance.AddUser((String) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateUserUsername"],(String) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateUserPassword"]);
                AllChats.Instance.ChatsDictionary[request.id].ClearCreateUser();
                ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Usuario Creado con éxito!");
            }
        }
    }
}