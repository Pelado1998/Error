// using System;
// using Telegram.Bot;
// using Telegram.Bot.Args;
// using Telegram.Bot.Types;

using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace Bankbot
{
    public class TelegramBot : IChannel
    {
        private ITelegramBotClient Bot;
        private const string Token = "1365916215:AAEE-yM7Jnz4XFZE6ExdDezyLXU-i5zqGnw";
        private AbstractHandler<IMessage> Handler;
        private static TelegramBot instance;
        public static TelegramBot Instance
        {
            get
            {
                if (instance == null) instance = new TelegramBot();

                return instance;
            }
        }
        private TelegramBot()
        {
            this.Bot = new TelegramBotClient(Token);
        }

        public void Start()
        {
            this.StartUp();

             Bot.OnMessage += OnMessage;

             Bot.StartReceiving();
             System.Console.WriteLine("Press any key to exit");
             //System.Console.ReadKey();

            //Bot.StopReceiving();
        }
        private async void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            System.Console.WriteLine($"{messageEventArgs.Message.Chat.FirstName}: {messageEventArgs.Message.Text}");
            IMessage menssage = new TelegramMessage(messageEventArgs.Message.Chat.Id.ToString(), messageEventArgs.Message.Text);
            TelegramBot.Instance.HandleMessage(menssage);
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
            Bot.SendTextMessageAsync(long.Parse(id), message);
            System.Console.WriteLine(message);
        }

        public void CreateChat(IMessage request)
        {
            if(!AllChats.Instance.ChatExist(request.id))
            {
                AllChats.Instance.AddChat(request);
                AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"] = new TelegramBot();
            }
        }
    }
}

