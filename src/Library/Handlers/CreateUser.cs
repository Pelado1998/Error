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
            if ((string)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateUserUsername"] == string.Empty && request.message== "/CreateUser")
            {
                ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese un Username");
            }
            else if ((string)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateUserUsername"] == string.Empty)
            {
                if (!AllUsers.Instance.UserExist(request.message))
                {
                    AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateUserUsername"] = request.message;
                ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese una Password");
                }
                else
                {
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ese Username ya existe 😟\nElija otro por favor!");
                }
                
            }
            else if ((string)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateUserPassword"] == string.Empty)
            {
                AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateUserPassword"] = request.message;
                AllUsers.Instance.AddUser((string) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateUserUsername"],(string) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateUserPassword"]);
                AllChats.Instance.ChatsDictionary[request.id].ClearCreateUser();
                ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Usuario Creado con éxito!");
            }
        }
    }
}