using System;
using System.Collections.Generic;

namespace Bankbot
{
    //Implementacion
    public class Login : AbstractHandler<Chats>
    {
        public Login(LoginCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(Chats request)
        {  
            switch (request.State)
            {
                case State.LoginUsername:

                    request.LoginUsername = request.Message.Text;
                    request.State = State.LoginPassword;
                    System.Console.WriteLine("Ingrese la contraseña");

                break;
                case State.LoginPassword:
                    request.LoginPassword = request.Message.Text;

                    User user = AllUsers.Instance.Login(request.LoginUsername,request.LoginPassword);
                    
                    if (user != null)
                    {
                        request.User = user;
                        System.Console.WriteLine("Hola " + user.UserName + "!\t👋🏻 Bienvenido!!\n");
                    }
                    else
                    {
                        System.Console.WriteLine("Wrong User or Password");
                        request.State = State.Idle;
                    }
                    LoginState(request);
                    Init.Options(request);                    
                    request.CleanTemp();
                break;
            }
        }
        public static void LoginState(Chats request)
        {
            if(request.User == null )
            {
                request.State = State.Dispatcher;
            }
            else if (request.User.Accounts.Count == 0)
            {
                request.State = State.Loged;
            }
            else if (request.User.Accounts.Count != 0)
            {
                request.State = State.LogedAccounts;
            }
        }
    }
}