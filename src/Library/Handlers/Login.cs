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
            if ((User) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["User"] != User.Empty)
            {
                ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Usted ya se encuentra logueado");
                AllChats.Instance.ChatsDictionary[request.id].ClearLogin();
            }
            else if((String) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["LoginUsername"] == String.Empty && request.message== "/Login")
            {
                ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese un Username");
            }
            else if ((String) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["LoginUsername"] == String.Empty)
            {
                AllChats.Instance.ChatsDictionary[request.id].DataDictionary["LoginUsername"] = request.message;
                ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese una Password");
            }
            else if((String) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["LoginUsername"] != String.Empty)
            {
                AllChats.Instance.ChatsDictionary[request.id].DataDictionary["LoginPassword"] = request.message;
                User user = AllUsers.Instance.Login((String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["LoginUsername"], (String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["LoginPassword"]);
                if (user != User.Empty)
                {
                    AllChats.Instance.ChatsDictionary[request.id].DataDictionary["User"] = user;
                    AllChats.Instance.ChatsDictionary[request.id].ClearLogin();
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Login Exitoso");
                }
                else 
                {
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Username o Password incorrectos. Vuelva a intentarlo ingresando el comando /Login u otro comando");
                    AllChats.Instance.ChatsDictionary[request.id].ClearLogin();
                }
            }
        }
    }
}