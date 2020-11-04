using System;
using System.Collections.Generic;

namespace Bankbot
{
    //Implementacion
    public class MainOptions : AbstractHandler<Chats>
    {
        public MainOptions(MainCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(Chats request)
        {
            switch (request.Message.Text)
            {
                case "1":
                    request.State = State.LoginUsername;
                    TelegramBot.Instance.SendMessage(request.Id, "Ingrese un Username");
                    break;
                case "2":
                    request.State = State.CreateUsername;
                    TelegramBot.Instance.SendMessage(request.Id, "Ingrese un Username");
                    break;
                default:
                    TelegramBot.Instance.SendMessage(request.Id, "Ingrese un valor correcto: 1 o 2");
                    System.Console.WriteLine("Ingrese un valor correcto: 1 o 2");
                    break;
            }
        }
    }
}