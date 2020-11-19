using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace Bankbot
{
    public class TelegramBot : AbstractBot
    {
        private ITelegramBotClient Bot;
        //BankBot
        // private const string Token = "1365916215:AAEE-yM7Jnz4XFZE6ExdDezyLXU-i5zqGnw";

        //BankBot Testing
        private const string Token = "1499140541:AAF_y-gfrPJZAPl4mBiNkawCRXFyt6TCcgE";
        private static TelegramBot instance;
        public static TelegramBot Instance
        {
            get
            {
                if (instance == null) instance = new TelegramBot();

                return instance;
            }
        }
        private TelegramBot() : base()
        {
            this.Bot = new TelegramBotClient(Token);
        }

        public override void Start()
        {
            Bot.OnMessage += OnMessage;

            Bot.StartReceiving();

            // Console.WriteLine("Press any key to exit");
            // Console.ReadKey();

            // Bot.StopReceiving();
        }
        private async void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            Message message = messageEventArgs.Message;
            string chatId = message.Chat.Id.ToString();

            IMessage msg = new BotMessage(chatId, message.Text);
            SetChannel(chatId, this);
            TelegramBot.Instance.HandleMessage(msg);
        }
        public override void SendMessage(string id, string message)
        {
            //Exception si no se puede pasar a long == id de otro bot
            var chatId = long.Parse(id);
            Bot.SendTextMessageAsync(chatId, message);
        }

        public override async void SendFile(string id, string path)
        {
            var chatId = long.Parse(id);
            var fs = System.IO.File.OpenRead(path);
            await Bot.SendDocumentAsync(chatId, new InputOnlineFile(fs, path));
        }
    }
}

