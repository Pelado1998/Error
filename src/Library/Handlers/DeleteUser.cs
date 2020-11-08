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
            if ((String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["DeleteUser"] == string.Empty && request.message== "\\DeleteUser")
            {
                System.Console.WriteLine("Ingrese la Password para eliminarlo");
            }
            else if ((String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["DeleteUser"] == string.Empty)
            {
                if (((User)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["User"]).Password == request.message)
                {
                    AllChats.Instance.ChatsDictionary[request.id].DataDictionary["DeleteUser"] = request.message;
                    System.Console.WriteLine("Confirme que quiera borrar la cuenta ingresando la contraseña nuevamente");
                }
                else 
                {
                    System.Console.WriteLine("Contaseña incorrecta. Vuelva a intentarlo");
                    AllChats.Instance.ChatsDictionary[request.id].ClearDeleteUser();
                }
            }
            else if ((String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["DeleteUserConfirmation"] == string.Empty)
            {
                AllChats.Instance.ChatsDictionary[request.id].DataDictionary["DeleteUserConfirmation"] = request.message;
                if ((String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["DeleteUser"] == (String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["DeleteUserConfirmation"])
                {
                    System.Console.WriteLine("Usuario eliminado con éxito!");
                    AllChats.Instance.ChatsDictionary[request.id].ClearDeleteUser();
                }
                else
                {
                    System.Console.WriteLine("El usuario no fue eliminado porque la contraseña no fue confirmada correctamente");
                    AllChats.Instance.ChatsDictionary[request.id].ClearDeleteUser();
                }
            }
        }
    }
}
