using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class DeleteAccount : AbstractHandler<IMessage>
    {
        public DeleteAccount(DeleteAccountCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            if ((String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["DeleteAccount"] == string.Empty && request.message== "/DeleteAccount")
            {
                ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese un AccountName para eliminar");
            }
            else if ((String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["DeleteAccount"] == string.Empty)
            {
                if (((User)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["User"]).AccountExist(request.message))
                {
                    AllChats.Instance.ChatsDictionary[request.id].DataDictionary["DeleteAccount"] = request.message;
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Confirme que quiera borrar la cuenta ingresando nuevamente el AccountName");
                }
                else 
                {
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"La cuenta no existe. Vuelva a intentarlo");
                    AllChats.Instance.ChatsDictionary[request.id].ClearDeleteAccount();
                }
            }
            else if ((String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["DeleteAccountConfirmation"] == string.Empty)
            {
                AllChats.Instance.ChatsDictionary[request.id].DataDictionary["DeleteAccountConfirmation"] = request.message;
                if ((String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["DeleteAccount"] == (String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["DeleteAccountConfirmation"])
                {
                    ((User) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["User"]).RemoveAccount((String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["DeleteAccount"]);
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Cuenta eliminada con éxito!");
                    AllChats.Instance.ChatsDictionary[request.id].ClearDeleteAccount();
                }
                else
                {
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"La cuenta no fue eliminada porque no fue confirmada correctamente");
                    AllChats.Instance.ChatsDictionary[request.id].ClearDeleteAccount();
                }
            }
            
            // this.DataDictionary.Add("DeleteAccount", String.Empty);
            // this.DataDictionary.Add("DeleteAccountConfirmation", String.Empty);
        }
    }
}