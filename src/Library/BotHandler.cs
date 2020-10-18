using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using System.Text;
using System.Collections.Generic;

namespace Bankbot
{
    /// <summary>
    /// Esta clase implementa el patron controlador ya que implementa la interfaz IAlert y sus algoritmos
    /// correspondientes.
    /// </summary>
    public class BotHandler:IAlert
    {

        //public static bool creatingUser = false;
        //public static string userName = string.Empty;
        //public static string password = string.Empty;
        //public static bool login = false;
        //public static string selectedUserName = string.Empty;
        //public static string selectedPassword = string.Empty;
        //public static bool logout = false;
        //public static bool selectingAccount = false;
        //public static bool makingTransaction = false;
        //public static TransactionType transactionType = TransactionType.Null;
        //public static CurrencyType transactionCurrency = CurrencyType.Null;
        //public static double transactionAmount = -1;
        public static List<User> userList = new List<User>(){};
        public static ITelegramBotClient Bot = TelegramBot.TelegramBot.Bot();

        public IObservable Obvservables { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string alertName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
            /*
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
                    if (userName != string.Empty)
                    {
                        password = message.Text;
                    }
                    else if (userName == string.Empty)
                    {
                        userName = message.Text;
                        await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Ingresa una contraseña");
                    }
                    if (userName != string.Empty && password != string.Empty)
                    {
                        User newUser = new User(userName, password, chatInfo.Id);
                        AllUsers.Instance.UserList.Add(newUser);
                        await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Usuario creado");
                        userName = string.Empty;
                        password = string.Empty;
                        creatingUser = false;
                    }
                }
                else if (login)
                {
                    if (selectedUserName != string.Empty)
                    {
                        selectedPassword = message.Text;
                    }
                    else if (selectedUserName == string.Empty)
                    {
                        selectedUserName = message.Text;
                        await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Ingresa una contraseña");
                    }
                    if (selectedUserName != string.Empty && selectedPassword != string.Empty)
                    {
                        foreach (User user in AllUsers.Instance.UserList)
                        {
                            if (user.UserName == selectedUserName && AllUsers.Login(selectedPassword, user.Password))
                            {
                                AllUsers.Instance.SelectedUser = user;
                            }
                        }
                        if (AllUsers.Instance.SelectedUser != null)
                        {
                            await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Logged In");
                            selectedUserName = string.Empty;
                            selectedPassword = string.Empty;
                            login = false;
                        }
                        else
                        {
                            await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Credenciales incorrectas");
                            selectedUserName = string.Empty;
                            selectedPassword = string.Empty;
                            await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Ingresa un nombre de usuario");
                        }
                    }
                }
                else if (logout)
                {
                    await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: $"Se ha desconectado de {AllUsers.Instance.SelectedUser.UserName}");
                    AllUsers.Instance.SelectedUser = null;
                    logout = false;
                }
                else if (selectingAccount)
                {
                    var userInput = Int32.Parse(message.Text);
                    AllUsers.Instance.SelectedUser.SelectedAccount = AllUsers.Instance.SelectedUser.Accounts[userInput - 1];
                    await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: $"{AllUsers.Instance.SelectedUser.SelectedAccount.Name} seleccionada.");
                    selectingAccount = false;
                }
                else if (makingTransaction)
                {
                    if (transactionType != TransactionType.Null && transactionCurrency != CurrencyType.Null)
                    {
                        transactionAmount = Double.Parse(message.Text);
                    }
                    else if (transactionType != TransactionType.Null && transactionCurrency == CurrencyType.Null)
                    {
                        if (Int32.Parse(message.Text) == 1)
                        {
                            transactionCurrency = CurrencyType.USS;
                        }
                        else if (Int32.Parse(message.Text) == 2)
                        {
                            transactionCurrency = CurrencyType.URU;
                        }
                        else if (Int32.Parse(message.Text) == 3)
                        {
                            transactionCurrency = CurrencyType.ARG;
                        }
                        else
                        {
                            await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Valor incorrecto.");
                        }
                        if (transactionCurrency != CurrencyType.Null)
                        {
                            await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Ingrese el valor de la transacción:");
                        }
                    }
                    else if (transactionType == TransactionType.Null && transactionCurrency == CurrencyType.Null && transactionAmount < 0)
                    {
                        if (Int32.Parse(message.Text) == 1)
                        {
                            transactionType = TransactionType.Income;
                        }
                        else if (Int32.Parse(message.Text) == 2)
                        {
                            transactionType = TransactionType.Outcome;
                        }
                        else
                        {
                            await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Valor incorrecto.");
                        }
                        if (transactionType != TransactionType.Null)
                        {
                            await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Ingrese el tipo de moneda:");
                            await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: $"1 - {CurrencyType.USS.ToString()}\n2 - {CurrencyType.URU.ToString()}\n3 - {CurrencyType.ARG.ToString()}");
                        }
                    }
                    else
                    {
                        await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Valor incorrecto.");
                    }
                    if (transactionType != TransactionType.Null && transactionCurrency != CurrencyType.Null && transactionAmount > 0)
                    {
                        var response = AllUsers.Instance.SelectedUser.SelectedAccount.MakeTransaction(transactionAmount, transactionCurrency, transactionType);
                        await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: response);
                        transactionAmount = -1;
                        transactionCurrency = CurrencyType.Null;
                        transactionType = TransactionType.Null;
                        makingTransaction = false;
                    }
                }
                else if (!creatingUser && !login && !logout)
                {
                    switch (messageText)
                    {
                        case "/commands":
                        case "/comandos":
                            StringBuilder commandsStringBuilder = new StringBuilder("Lista de Comandos:\n")
                            .Append("/createuser\n")
                            .Append("/showusers\n")
                            .Append("/login\n")
                            .Append("/logout\n")
                            .Append("/transaction\n")
                            .Append("/showaccounts\n")
                            .Append("/selectaccount\n")
                            .Append("/transaction\n")
                            .Append("/accounthistory\n");

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
                                await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: $"{AllUsers.Instance.UserList.IndexOf(userName) + 1} - {userName.UserName}");
                            }
                            break;

                        case "/login":
                            login = true;
                            await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Ingresa un nombre de usuario");
                            break;

                        case "/logout":
                            logout = true;
                            break;

                        case "/showaccounts":
                            if (AllUsers.Instance.SelectedUser == null)
                            {
                                await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Es necesario loguearse para esto");
                            }
                            else
                            {
                                await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: AllUsers.Instance.SelectedUser.ShowAccounts().ToString());
                            }
                            break;

                        case "/selectaccount":
                            selectingAccount = true;
                            await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Ingrese el indice de cuenta:");
                            await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: AllUsers.Instance.SelectedUser.ShowAccounts().ToString());
                            break;

                        case "/transaction":
                            if (AllUsers.Instance.SelectedUser.SelectedAccount != null)
                            {
                                makingTransaction = true;
                                await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Ingrese el tipo de transferencia:");
                                await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: $"1 - {TransactionType.Income.ToString()}\n2 - {TransactionType.Outcome.ToString()}");
                            }
                            else
                            {
                                await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Debe seleccionar una cuenta primero. /selectaccount");
                            }
                            break;

                        case "/accounthistory":
                            if (AllUsers.Instance.SelectedUser.SelectedAccount == null)
                            {
                                await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: "Es necesario seleccionar una cuenta para esto.");
                            }
                            else
                            {
                                await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: AllUsers.Instance.SelectedUser.SelectedAccount.ShowHistory().ToString());
                            }
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
        */
        }
        private void SendAlert()
        {
            //Manda la alerta
        }
    }
}
