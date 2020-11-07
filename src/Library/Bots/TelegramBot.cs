// using System;
// using Telegram.Bot;
// using Telegram.Bot.Args;
// using Telegram.Bot.Types;

// namespace Bankbot
// {
//     public class TelegramBot : IChannel
//     {
//         private static ITelegramBotClient Bot;
//         private const string Token = "1365916215:AAEE-yM7Jnz4XFZE6ExdDezyLXU-i5zqGnw";
//         private AbstractHandler<Chats> Handler;
//         private static TelegramBot instance;
//         public static TelegramBot Instance
//         {
//             get
//             {
//                 if (instance == null) instance = new TelegramBot();
//                 return instance;
//             }
//         }
//         private TelegramBot() { }
//         public void Start()
//         {
//             Bot = new TelegramBotClient(Token);
//             StartUp();

//             Bot.OnMessage += OnMessage;

//             Bot.StartReceiving();

//             Console.WriteLine("Press any key to exit");
//             Console.ReadKey();

//             Bot.StopReceiving();
//         }
//         private static async void OnMessage(object sender, MessageEventArgs messageEventArgs)
//         {
//             System.Console.WriteLine($"{messageEventArgs.Message.Chat.FirstName}: {messageEventArgs.Message.Text}");
//             Message message = messageEventArgs.Message;
//             Chat chatInfo = message.Chat;
//         }

//         public void StartUp()
//         {
//             Handler = StartupConfig.HandlerConfig();
//         }
//         public void HandleMessage(long id, string message)
//         {
//             var chat = Session.Instance.GetChat(id);
//             Session.Instance.SetChannel(id, TelegramBot.Instance);
//             Handler.Handler(chat);
//         }
//         public void SendMessage(long id, string message)
//         {
//             Bot.SendTextMessageAsync(id, message);
//         }
//     }
// }

