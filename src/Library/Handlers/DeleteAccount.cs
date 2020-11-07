using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class DeleteAccount : AbstractHandler<Conversation>
    {
        public DeleteAccount(DeleteAccountCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(Conversation request)
        {
            // switch (request.State)
            // {
            //     case State.DeleteAccount:
            //         if (request.User.AccountExist(request.Message.Text))
            //         {
            //             request.State = State.DeleteAccountConfirmation;
            //             request.DeleteAccount = request.Message.Text;
            //             System.Console.WriteLine("Vuelva a ingresar el AccountName para confirmar que desea eliminarlo");
            //         }
            //         else
            //         {
            //             System.Console.WriteLine("Esa no es una cuenta válida. Vuelva a intentarlo.");
            //             Init.Options(request);
            //             Init.RenewState(request);
            //         }

            //         break;
            //     case State.DeleteAccountConfirmation:
            //         request.DeleteAccountConfirmation = request.Message.Text;
            //         if (request.DeleteAccount == request.DeleteAccountConfirmation)
            //         {
            //             request.User.RemoveAccount(request.Message.Text);
            //             System.Console.WriteLine("Cuenta Borrada.");
            //             request.CleanTemp();
            //             Login.LoginState(request);
            //             Init.Options(request);
            //         }
            //         else
            //         {
            //             System.Console.WriteLine("Accion abortada porque las cuentas no coincidieron.");
            //             request.CleanTemp();
            //             Login.LoginState(request);
            //             Init.Options(request);
            //         }

            //         break;
            // }

        }
    }
}