using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class CreateUser : AbstractHandler<Chats>
    {
        public CreateUser(CreateUserCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(Chats request)
        {
            switch (request.State)
            {
                case State.CreateUsername:      //Crear Usuario con el user

                    request.State = State.CreatePassword;
                    request.CreateUserUsername = request.Message.Text;
                    System.Console.WriteLine("Ingrese una contraseña");
                
                break;
                case State.CreatePassword:      //Crear Usuario con la contraseña
                    
                    request.CreateUserPassword =request.Message.Text;
                    AllUsers.Instance.AddUser(request.CreateUserUsername,request.CreateUserPassword);
                    System.Console.WriteLine("Usuario Creado\nUsername:\t"+ request.CreateUserUsername+"\nPassword:\t"+new String('*',(request.CreateUserPassword).Length));
                    request.CleanTemp();
                    Login.LoginState(request);
                    Init.Options(request);
                    request.State = State.Dispatcher;
                break;
            }

        }
    }
}