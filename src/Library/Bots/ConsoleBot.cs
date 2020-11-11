using System;
// using Telegram.Bot;
// using Telegram.Bot.Args;
// using Telegram.Bot.Types;

namespace Bankbot
{
    public class ConsoleBot : IChannel
    {
        private AbstractHandler<IMessage> Handler;
        private static ConsoleBot instance;
        public static ConsoleBot Instance
        {
            get
            {
                if (instance == null) instance = new ConsoleBot();

                return instance;
            }
        }
        private ConsoleBot()
        {}
        public void Start()
        {
            this.StartUp();
            System.Console.WriteLine("Para salir escriba \"Exit\"");
            while (true)
            {
                string text = System.Console.ReadLine().ToString();   
                if (text == "Exit") return;
                TelegramMessage message = new TelegramMessage("UNIQUE_CONSOLE",text);
                HandleMessage(message);
            }
        }


        public void StartUp()
        {
            Handler = StartupConfig.HandlerConfig();
        }
        public void HandleMessage(IMessage message)
        {
            CreateChat(message);
            Handler.Handler(message);
        }
        public void SendMessage(string id, string message)
        {
            System.Console.WriteLine(message); 
        }
        public void CreateChat(IMessage request)
        {
            if(!AllChats.Instance.ChatExist(request.id))
            {
                AllChats.Instance.AddChat(request);
                AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"] = new ConsoleBot();
            }
        }
    }
}

