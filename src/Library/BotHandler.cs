using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using System.Text;

namespace Bankbot
{
    public class BotHandler
    {
        public static bool creatingUser = false;
        public static string userName = string.Empty;
        public static string password = string.Empty;
        public static bool login = false;
        public static User currentUser = null;
        public static string selectedUserName = string.Empty;
        public static string selectedPassword = string.Empty;
        public static ITelegramBotClient Bot = TelegramBot.TelegramBot.Bot();
        public static void BotStarter()
        {
            Bot.OnMessage += OnMessage;

            //Inicio la escucha de mensajes
            Bot.StartReceiving();


            Console.WriteLine("Presiona una tecla para terminar");
            Console.ReadKey();

            //Detengo la escucha de mensajes 
            Bot.StopReceiving();
        }
        private static async void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            System.Console.WriteLine(sender);
            Message message = messageEventArgs.Message;
            Chat chatInfo = message.Chat;
            string messageText = message.Text.ToLower();

            if (messageText != null)
            {
                ITelegramBotClient client = TelegramBot.TelegramBot.Instance.Client;
                Console.WriteLine($"{chatInfo.FirstName}: envío {message.Text}");
                if (creatingUser)
                {
                    if (userName != "")
                    {
                        password = message.Text;
                    }
                    else if (userName == "")
                    {
                        userName = message.Text;
                        await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Ingresa una contraseña");
                    }
                    if (userName != "" && password != "")
                    {
                        User newUser = new User(userName, password, chatInfo.Id);
                        AllUsers.Instance.UserList.Add(newUser);
                        await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Usuario creado");
                        userName = "";
                        password = "";
                        creatingUser = false;
                    }
                }
                else if (login)
                {
                    if (selectedUserName != "")
                    {
                        selectedPassword = message.Text;
                    }
                    else if (selectedUserName == "")
                    {
                        selectedUserName = message.Text;
                        await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Ingresa una contraseña");
                    }
                    if (selectedUserName != "" && selectedPassword != "")
                    {
                        foreach (User user in AllUsers.Instance.UserList)
                        {
                            if (user.UserName == selectedUserName && AllUsers.Login(selectedPassword, user.Password))
                            {
                                currentUser = user;
                            }
                        }
                        if (currentUser != null)
                        {
                            await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Logged In");
                            selectedUserName = "";
                            selectedPassword = "";
                            login = false;
                        }
                        else
                        {
                            await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Credenciales incorrectas");
                            selectedUserName = "";
                            selectedPassword = "";
                            await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Ingresa un nombre de usuario");
                        }
                    }
                }
                else if (!creatingUser && !login)
                {
                    switch (messageText)
                    {
                        case "/commands":
                        case "/comandos":
                            StringBuilder commandsStringBuilder = new StringBuilder("Lista de Comandos:\n")
                            .Append("/createuser\n")
                            .Append("/showusers\n")
                            .Append("/login\n")
                            .Append("/transaction\n");

                            await client.SendTextMessageAsync(
                                                      chatId: chatInfo.Id,
                                                       text: commandsStringBuilder.ToString());
                            break;

                        case "/createuser":
                            creatingUser = true;
                            await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Ingresa un nombre de usuario");

                            break;
                        case "/showusers":
                            foreach (User userName in AllUsers.Instance.UserList)
                            {
                                await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: userName.UserName);
                            }

                            break;
                        case "/login":
                            login = true;
                            await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Ingresa un nombre de usuario");

                            break;
                        default:
                            await client.SendTextMessageAsync(
                                                  chatId: chatInfo.Id,
                                                  text: $"{chatInfo.FirstName}, no comprendo lo que dices 😕"
                                                );
                            break;
                    }
                }
            }
        }
    }
}
