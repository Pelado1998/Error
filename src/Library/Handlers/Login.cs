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

                    request.Temp.Add(request.Message.Text);
                    request.State = State.LoginPassword;
                    System.Console.WriteLine("Ingrese la contraseña");

                break;
                case State.LoginPassword:

                    User user = AllUsers.Instance.Login(request.Temp[0].ToString(),request.Message.Text);
                    if (user == null)
                    {
                        System.Console.WriteLine("Wrong User or Password\nElija una de las siguientes opciones:\n\t1-Login\n\t2-CreateUser");
                    }
                    else
                    {
                        request.User = user;
                        System.Console.WriteLine("Hola " + user.UserName + "! 👋🏻\n\nBienvenido!!");
                    }
                    request.State = State.Idle;
                    request.CleanTemp();

                break;

            }

        }
    }
    public class LoginCondition : ICondition<Chats>
    {
        public bool IsSatisfied(Chats request)
        {
            return request.State == State.LoginUsername || request.State == State.LoginPassword ;
        }
    }
}