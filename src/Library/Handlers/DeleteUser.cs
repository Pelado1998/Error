using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class DeleteUser : AbstractHandler<Chats>
    {
        public DeleteUser(DeleteUserCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(Chats request)
        {
            switch (request.State)
            {
                case State.DeleteUser:      
                    if (AllUsers.Instance.UserExist(request.Message.Text) && request.User.UserName == request.Message.Text)
                    {
                        request.State = State.DeleteUserConfirmation;
                        request.DeleteUserUsername = request.Message.Text;
                        System.Console.WriteLine("Vuelva a ingresar el Username para confirmar que desea eliminarlo");
                    }
                    else 
                    {
                        System.Console.WriteLine("Ese no es su usuario. Vuelva a intentarlo.");
                        Init.Options(request);
                        Init.RenewState(request);
                    }
                    
                break;
                case State.DeleteUserConfirmation:
                    request.DeleteUserConfirmation =request.Message.Text;
                    if (request.DeleteUserUsername == request.DeleteUserConfirmation)
                    {
                        AllUsers.Instance.RemoveUser(request.DeleteUserConfirmation,request);
                        System.Console.WriteLine("Usuario Borrado.");
                        request.CleanTemp();
                        Login.LoginState(request);
                        Init.Options(request);
                        request.State = State.Dispatcher;
                    }
                    else 
                    {
                        System.Console.WriteLine("Accion abortada porque los usuarios no coincidieron.");
                        request.CleanTemp();
                        Login.LoginState(request);
                        Init.Options(request);
                        request.State = State.Dispatcher;
                    }
                    
                break;
            }

        }
    }
}