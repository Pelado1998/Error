// using System;
// using Telegram.Bot;
// using Telegram.Bot.Args;
// using Telegram.Bot.Types;
// using System.Text;
// using System.Collections.Generic;

// namespace Bankbot
// {
//     public class NewBotHandler
//     {
//         private static ITelegramBotClient Bot = TelegramBot.TelegramBot.Bot();
//         private static List<User> AllUsers = new List<User>();
//         private static List<Chats> AllChats = new List<Chats>();
//         public static void NewBotStarter()
//         {
//             Bot.OnMessage += OnMessage;

//             //Inicio la escucha de mensajes
//             Bot.StartReceiving();


//             Console.WriteLine("Presiona una tecla para terminar");
//             Console.ReadKey();

//             //Detengo la escucha de mensajes
//             Bot.StopReceiving();
//         }
//         private static async void OnMessage(object sender, MessageEventArgs messageEventArgs)
//         {
//             System.Console.WriteLine(sender);
//             Message message = messageEventArgs.Message;
//             Chat chatInfo = message.Chat;

//             // foreach (var chat in AllChats)
//             // {
//             //     if (chat.Id == chatInfo.Id) return;
//             // }
//             // AllChats.Add(new Chats(chatInfo.Id));
//         }

//     }
// }

