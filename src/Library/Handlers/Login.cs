using System;

namespace Bankbot
{
    public class Login : AbstractHandler<IMessage>
    {
        public Login(LoginCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            if((String) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["LoginUsername"] == String.Empty && request.message== "\\Login")
            {
                System.Console.WriteLine("Ingrese un Username");
            }
            else if ((String) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["LoginUsername"] == String.Empty)
            {
                AllChats.Instance.ChatsDictionary[request.id].DataDictionary["LoginUsername"] = request.message;
                System.Console.WriteLine("Ingrese una Password");
            }
            else if((String) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["LoginUsername"] != String.Empty)
            {
                AllChats.Instance.ChatsDictionary[request.id].DataDictionary["LoginPassword"] = request.message;
                User user = AllUsers.Instance.Login((String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["LoginUser"],(String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["LoginPassword"]);
                if (user != User.Empty)
                {
                    AllChats.Instance.ChatsDictionary[request.id].DataDictionary["User"] = user;
                    AllChats.Instance.ChatsDictionary[request.id].ClearLogin();
                    System.Console.WriteLine("Login Exitoso");
                }
                else 
                {
                    System.Console.WriteLine("Username o Password incorrectos. Vuelva a intentarlo");
                }
            }
        }
    }
}