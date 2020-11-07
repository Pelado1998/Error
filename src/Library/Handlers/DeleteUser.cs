using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class DeleteUser : AbstractHandler<Conversation>
    {
        public DeleteUser(DeleteUserCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(Conversation request)
        {
            if (!request.Temp.ContainsKey("username"))
            {
                if (Session.Instance.UserNameExists(request.Message))
                {
                    request.Channel.SendMessage(request.Id, "Ya existe un usuario con este nombre. Vuelva a ingresar un nombre de usuario:");
                }
                else
                {
                    request.Temp.Add("username", request.Message);
                    request.Channel.SendMessage(request.Id, "Ingrese una contraseña:");
                }
            }
            else if (request.Temp.ContainsKey("username") && !request.Temp.ContainsKey("password"))
            {
                request.Temp.Add("password", request.Message);
            }

            if (request.Temp.ContainsKey("username") && request.Temp.ContainsKey("password"))
            {
                string userName = request.GetDictionaryValue<string>("username");
                string password = request.GetDictionaryValue<string>("password");

                User user = Session.Instance.GetUser(userName, password);

                if (user != null)
                {
                    request.Channel.SendMessage(request.Id, "¿Estas seguro que deseas borrar ete usuario?");
                    request.Temp.Add("confirmation", "needed");
                }
                else
                {
                    request.Channel.SendMessage(request.Id, "Credenciales incorrectas, vuelva a intentarlo.");
                }
                request.Temp.Clear();
                request.State = State.Dispatcher;
            }
            else if (request.Temp.ContainsKey("confirmation"))
            {
                if (request.Message.ToLower() == "si")
                {
                }
                else
                {
                }
            }

            // switch (request.State)
            // {
            //     case State.DeleteUser:
            //         if (AllUsers.Instance.UserExist(request.Message.Text) && request.User.UserName == request.Message.Text)
            //         {
            //             request.State = State.DeleteUserConfirmation;
            //             request.DeleteUserUsername = request.Message.Text;
            //             System.Console.WriteLine("Vuelva a ingresar el Username para confirmar que desea eliminarlo");
            //         }
            //         else
            //         {
            //             System.Console.WriteLine("Ese no es su usuario. Vuelva a intentarlo.");
            //             Init.Options(request);
            //             Init.RenewState(request);
            //         }

            //         break;
            //     case State.DeleteUserConfirmation:
            //         request.DeleteUserConfirmation = request.Message.Text;
            //         if (request.DeleteUserUsername == request.DeleteUserConfirmation)
            //         {
            //             AllUsers.Instance.RemoveUser(request.DeleteUserConfirmation, request);
            //             System.Console.WriteLine("Usuario Borrado.");
            //             request.CleanTemp();
            //             Login.LoginState(request);
            //             Init.Options(request);
            //             request.State = State.Dispatcher;
            //         }
            //         else
            //         {
            //             System.Console.WriteLine("Accion abortada porque los usuarios no coincidieron.");
            //             request.CleanTemp();
            //             Login.LoginState(request);
            //             Init.Options(request);
            //             request.State = State.Dispatcher;
            //         }

            //         break;
            // }

        }
    }
}