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
            if ((String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateUserUsername"] == string.Empty && request.message== "\\CreateUser")
            {
                System.Console.WriteLine("Ingrese un Username");
            }
            else if ((String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateUserUsername"] == string.Empty)
            {
                AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateUserUsername"] = request.message;
                System.Console.WriteLine("Ingrese una Password");
            }
            else if ((String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateUserPassword"] == string.Empty)
            {
                AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateUserPassword"] = request.message;
                AllChats.Instance.ChatsDictionary[request.id].ClearCreateUser();
                System.Console.WriteLine("Usuario Creado con éxito!");
            }
        }
    }
}