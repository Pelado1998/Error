using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class DeleteUser : AbstractHandler<IMessage>
    {
        public DeleteUser(DeleteUserCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            if ((String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["DeleteUser"] == string.Empty && request.message== "/DeleteUser")
            {
                ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese la Password para eliminarlo");
            }
            else if ((String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["DeleteUser"] == string.Empty)
            {
                if (((User)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["User"]).Password == request.message)
                {
                    AllChats.Instance.ChatsDictionary[request.id].DataDictionary["DeleteUser"] = request.message;
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Confirme que quiera borrar la cuenta ingresando la contraseña nuevamente");
                }
                else 
                {
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Contaseña incorrecta. Vuelva a intentarlo");
                    AllChats.Instance.ChatsDictionary[request.id].ClearDeleteUser();
                }
            }
            else if ((String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["DeleteUserConfirmation"] == string.Empty)
            {
                AllChats.Instance.ChatsDictionary[request.id].DataDictionary["DeleteUserConfirmation"] = request.message;
                if ((String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["DeleteUser"] == (String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["DeleteUserConfirmation"])
                {
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Usuario eliminado con éxito!");
                    AllChats.Instance.ChatsDictionary[request.id].ClearDeleteUser();
                }
                else
                {
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"El usuario no fue eliminado porque la contraseña no fue confirmada correctamente");
                    AllChats.Instance.ChatsDictionary[request.id].ClearDeleteUser();
                }
            }
        }
    }
}
