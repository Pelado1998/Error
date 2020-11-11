using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace Bankbot
{
    public class TelegramBot : IChannel
    {
        private ITelegramBotClient Bot;
        //BankBot
        // private const string Token = "1365916215:AAEE-yM7Jnz4XFZE6ExdDezyLXU-i5zqGnw";
        //BankBot Testing
        private const string Token = "1499140541:AAF_y-gfrPJZAPl4mBiNkawCRXFyt6TCcgE";
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

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            Bot.StopReceiving();
        }
        private async void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            Message message = messageEventArgs.Message;
            string chatId = message.Chat.Id.ToString();

            IMessage msg = new BotMessage(chatId, message.Text);
            TelegramBot.Instance.HandleMessage(msg);


        }
        public void StartUp()
        {
            Handler = StartupConfig.HandlerConfig();
        }
        public void HandleMessage(IMessage message)
        {
            var data = Session.Instance.GetChat(message.Id);
            Session.Instance.SetChannel(message.Id, TelegramBot.Instance);

            Handler.Handler(message);
        }
        public void SendMessage(string id, string message)
        {
            //Exception si no se puede pasar a long == id de otro bot
            var chatId = long.Parse(id);
            Bot.SendTextMessageAsync(chatId, message);
            System.Console.WriteLine(message);
        }
    }
}

