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
                    request.UserUsername = request.Message.Text;
                    System.Console.WriteLine("Ingrese una contraseña");
                
                break;
                case State.CreatePassword:      //Crear Usuario con la contraseña
                    
                    request.UserPassword =request.Message.Text;
                    AllUsers.Instance.AddUser(request.UserUsername,request.UserPassword);
                    System.Console.WriteLine("Usuario Creado\nUsername:\t"+ request.UserUsername+"\nPassword:\t"+new String('*',(request.UserPassword).Length));
                    request.CleanTemp();
                    Login.LoginState(request);
                    Init.Options(request);
                    request.State=State.Dispatcher;
                break;
            }

        }
    }
    public class CreateUserCondition : ICondition<Chats>
    {
        public bool IsSatisfied(Chats request)
        {
            return request.State == State.CreateUsername || request.State == State.CreatePassword;
        }
    }
}