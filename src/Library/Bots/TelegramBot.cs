// // using System;
// // using Telegram.Bot;
// // using Telegram.Bot.Args;
// // using Telegram.Bot.Types;

// using Telegram.Bot;
// using Telegram.Bot.Args;
// using Telegram.Bot.Types;

// namespace Bankbot
// {
//     public class TelegramBot : IChannel
//     {
//         private ITelegramBotClient Bot;
//         private const string Token = "1365916215:AAEE-yM7Jnz4XFZE6ExdDezyLXU-i5zqGnw";
//         private AbstractHandler<Conversation> Handler;
//         private static TelegramBot instance;
//         public static TelegramBot Instance
//         {
//             get
//             {
//                 if (instance == null) instance = new TelegramBot();

//                 return instance;
//             }
//         }
//         private TelegramBot()
//         {
//             this.Bot = new TelegramBotClient(Token);
//         }

//         public void Start()
//         {
//             this.StartUp();

// //             Bot.OnMessage += OnMessage;

// //             Bot.StartReceiving();

// //             Console.WriteLine("Press any key to exit");
// //             Console.ReadKey();

//             Bot.StopReceiving();
//         }
//         private async void OnMessage(object sender, MessageEventArgs messageEventArgs)
//         {
//             System.Console.WriteLine($"{messageEventArgs.Message.Chat.FirstName}: {messageEventArgs.Message.Text}");
//             Message message = messageEventArgs.Message;
//             string chatId = message.Chat.Id.ToString();

//             var chat = Session.Instance.GetChat(chatId);
//             Session.Instance.SetChannel(chatId, TelegramBot.Instance);
//             chat.Message = message.Text;

//             TelegramBot.Instance.HandleMessage(chatId);
//         }

//         public void StartUp()
//         {
//             Handler = StartupConfig.HandlerConfig();
//         }
//         public void HandleMessage(string id)
//         {
//             Handler.Handler(Session.Instance.GetChat(id));
//         }
//         public void SendMessage(string id, string message)
//         {
//             //Exception si no se puede pasar a long == id de otro bot
//             var chatId = long.Parse(id);
//             Bot.SendTextMessageAsync(chatId, message);
//             System.Console.WriteLine(message);
//         }
//     }
// }

