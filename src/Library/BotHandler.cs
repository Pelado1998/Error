// using System;
// using Telegram.Bot;
// using Telegram.Bot.Args;
// using Telegram.Bot.Types;
// using System.Text;
// using System.Collections.Generic;

// namespace Bankbot
// {
//     /// <summary>
//     /// La calse BotHandler será la encargada de procesar la comunicación entre el usuario y el bot,
//     /// se encargará de recibir mensajes y responder acorde a los mismos, como tambien llamar a los métodos
//     /// correspondientes, por esta razón cumple con el patrón Controler de los principios GRASP.
//     /// A su vez implementa la interfaz IAlert y sus algoritmos correspondientes.
//     /// </summary>
//     public class BotHandler
//     {
//         private static User LoggedUser;
//         private static ITelegramBotClient Bot = TelegramBot.TelegramBot.Bot();
//         private static bool CreatingUser = false;
//         private static string NewUserName;
//         private static string NewPassword;
//         private static bool LogIn = false;
//         private static string LogInUserName;
//         private static string LogInPassword;
//         private static bool CreatingAccount = false;
//         private static string NewAccountName;
//         private static AccountType? NewAccountType;
//         private static Currency NewAccountCurrency;
//         private static double? NewAccountAmount;
//         private static double? NewAccountObjective;
//         private static bool MakingTransaction = false;
//         private static Account TransactionAccount;
//         private static string TransactionType;
//         private static double? TransactionAmount;
//         private static Currency TransactionCurrency;
//         private static string TransactionItem = String.Empty;
//         // private IObservable Obvservables { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
//         // private string alertName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

//         public static void BotStarter()
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
//             string messageText = message.Text.ToLower();

//             if (messageText != null)
//             {
//                 ITelegramBotClient client = TelegramBot.TelegramBot.Instance.Client;
//                 Console.WriteLine($"{chatInfo.FirstName}: envío {message.Text}");
//             }

//             if (CreatingUser)
//             {
//                 CreateNewUser(message);
//             }
//             else if (LogIn)
//             {
//                 UserLogIn(message);
//             }
//             else if (CreatingAccount)
//             {
//                 CreateAccount(message);
//             }
//             else if (MakingTransaction)
//             {
//                 MakeTransaction(message);
//             }
//             else
//             {
//                 switch (messageText)
//                 {
//                     case "/commands":
//                     case "/comandos":
//                         StringBuilder commandsStringBuilder = new StringBuilder("Lista de Comandos:\n")
//                         .Append("/createuser\n")
//                         .Append("/showusers\n")
//                         .Append("/login\n")
//                         .Append("/logout\n")
//                         .Append("/transaction\n")
//                         .Append("/showaccounts\n")
//                         .Append("/addaccount\n")
//                         .Append("/transaction\n")
//                         .Append("/accounthistory\n")
//                         .Append("/prueba");

//                         SendMessage(chatInfo.Id, commandsStringBuilder.ToString());
//                         break;

//                     case "/createuser":
//                         CreatingUser = true;
//                         SendMessage(chatInfo.Id, "Ingrese un nombre de usuario");
//                         break;

//                     case "/showusers":
//                         foreach (User userName in UserList)
//                         {
//                             SendMessage(chatInfo.Id, $"{UserList.IndexOf(userName) + 1} - {userName.UserName}");
//                         }
//                         break;

//                     case "/login":
//                         LogIn = true;
//                         SendMessage(chatInfo.Id, "Ingrese un nombre de usuario");
//                         break;

//                     case "/logout":
//                         var sendMessage = $"Se ha desconectado de {LoggedUser.UserName}";
//                         LoggedUser = null;
//                         if (LoggedUser == null)
//                         {
//                             SendMessage(chatInfo.Id, sendMessage);
//                         }
//                         break;

//                     case "/showaccounts":
//                         if (LoggedUser == null)
//                         {
//                             SendMessage(chatInfo.Id, "Es necesario loguearse para esto");
//                         }
//                         else
//                         {
//                             SendMessage(chatInfo.Id, LoggedUser.ShowAccounts().ToString());
//                         }
//                         break;
//                     case "/addaccount":
//                         if (LoggedUser != null)
//                         {
//                             CreatingAccount = true;
//                             SendMessage(chatInfo.Id, "Seleccione un tipo de cuenta:");
//                             SendMessage(chatInfo.Id, ShowAccountType());
//                         }
//                         else
//                         {
//                             SendMessage(chatInfo.Id, "Debes estar logueado para poder hacer esto.");
//                         }
//                         break;

//                     case "/transaction":
//                         if (LoggedUser != null)
//                         {
//                             MakingTransaction = true;
//                             SendMessage(chatInfo.Id, "Seleccione la cuenta en que desea realizar la transacción:");
//                             SendMessage(chatInfo.Id, ShowAccountList());
//                         }
//                         else
//                         {
//                             SendMessage(chatInfo.Id, "Debes estar logueado para poder hacer esto.");
//                         }
//                         break;

//                     case "/accounthistory":
//                         //                         else
//                         // {
//                         //     await Bot.SendTextMessageAsync(chatId: chatInfo.Id, text: AllUsers.Instance.SelectedUser.SelectedAccount.ShowHistory().ToString());
//                         // }
//                         break;

//                     default:
//                         await Bot.SendTextMessageAsync(
//                                               chatId: chatInfo.Id,
//                                               text: $"{chatInfo.FirstName}, no comprendo lo que dices 😕"
//                                             );
//                         break;
//                 }
//             }
//         }
//         /// <summary>
//         /// Método utilizado para enviar mensajes al usuario
//         /// </summary>
//         /// <param name="_id">ID Telegram</param>
//         /// <param name="_message">Mensaje que se desea enviar</param>
//         private async static void SendMessage(long _id, string _message)
//         {
//             await Bot.SendTextMessageAsync(chatId: _id, text: _message);
//         }

//         /// <summary>
//         /// Método para crear usuario una vez que el usuario ingresa /createuser
//         /// Cada bloque de if valida el mensaje recibido
//         /// </summary>
//         /// <param name="_message"></param>
//         private static void CreateNewUser(Message _message)
//         {
//             /// <summary>
//             /// Seleccionar nombre de usuario
//             /// </summary>
//             /// <returns></returns>
//             if (String.IsNullOrEmpty(NewUserName))
//             {
//                 if (String.IsNullOrEmpty(_message.Text))
//                 {
//                     var messageText = "Debe Ingreser un nombre de usuario.";
//                     SendMessage(_message.Chat.Id, messageText);
//                 }
//                 else
//                 {
//                     var exists = false;
//                     foreach (User user in UserList)
//                     {
//                         if (user.UserName == _message.Text)
//                         {
//                             exists = true;
//                         }
//                     }
//                     if (exists)
//                     {
//                         var messageText = "Ya existe un usuario con este nombre.";
//                         SendMessage(_message.Chat.Id, messageText);
//                     }
//                     else
//                     {

//                         NewUserName = _message.Text;
//                         var messageText = "Ingrese una constraseña:";
//                         SendMessage(_message.Chat.Id, messageText);
//                     }
//                 }
//             }
//             /// <summary>
//             /// Seleccionar contraseña
//             /// </summary>
//             /// <returns></returns>
//             else if (!String.IsNullOrEmpty(NewUserName) && String.IsNullOrEmpty(NewPassword))
//             {
//                 if (String.IsNullOrEmpty(_message.Text))
//                 {
//                     var messageText = "Debe Ingreser una contraseña.";
//                     SendMessage(_message.Chat.Id, messageText);
//                 }
//                 else
//                 {
//                     NewPassword = _message.Text;
//                 }
//             }
//             /// <summary>
//             /// Cuando el usuario ingresa un nombre de usuario y contraseñas validas se crea
//             /// un nuevo usuario y se resetean los valores.
//             /// </summary>
//             /// <returns></returns>
//             if (!String.IsNullOrEmpty(NewUserName) && !String.IsNullOrEmpty(NewPassword))
//             {
//                 var user = new User(NewUserName, NewPassword, _message.Chat.Id);
//                 UserList.Add(user);
//                 NewUserName = String.Empty;
//                 NewPassword = String.Empty;
//                 CreatingUser = false;
//                 var messageText = $"El usuario {user.UserName} ha sido creado.";
//                 SendMessage(_message.Chat.Id, messageText);
//             }
//         }

//         /// <summary>
//         /// Método para loguearse a un usuario existente mediante el ingreso
//         /// de un nombre de usuario y contraseña.
//         /// </summary>
//         /// <param name="_message"></param>
//         private static void UserLogIn(Message _message)
//         {
//             /// <summary>
//             /// Selecciona nombre de usuario
//             /// </summary>
//             /// <returns></returns>
//             if (String.IsNullOrEmpty(LogInUserName))
//             {
//                 if (String.IsNullOrEmpty(_message.Text))
//                 {
//                     var messageText = "Debe Ingreser un nombre de usuario.";
//                     SendMessage(_message.Chat.Id, messageText);
//                 }
//                 else
//                 {
//                     LogInUserName = _message.Text;
//                     var messageText = "Ingrese una constraseña:";
//                     SendMessage(_message.Chat.Id, messageText);
//                 }
//             }
//             /// <summary>
//             /// Selecciona contraseña
//             /// </summary>
//             /// <returns></returns>
//             else if (LogInUserName != String.Empty && String.IsNullOrEmpty(LogInPassword))
//             {
//                 if (String.IsNullOrEmpty(_message.Text))
//                 {
//                     var messageText = "Debe Ingreser una contraseña.";
//                     SendMessage(_message.Chat.Id, messageText);
//                 }
//                 else
//                 {
//                     LogInPassword = _message.Text;
//                 }
//             }
//             /// <summary>
//             /// Una vez ingresados el nombre de usuario y contraseña, se busca este nmombre de
//             /// usuario en la lista de usuarios, si se encuentra se utiliza el método Login
//             /// de la isntancia Usuario, el cual valida la contraseña ingresada.
//             /// </summary>
//             /// <returns></returns>
//             if (!String.IsNullOrEmpty(LogInUserName) && !String.IsNullOrEmpty(LogInPassword))
//             {
//                 User selectedUser = null;
//                 foreach (User user in UserList)
//                 {
//                     if (user.UserName == LogInUserName)
//                     {
//                         selectedUser = user;
//                     }
//                 }
//                 if (selectedUser.Login(LogInPassword))
//                 {
//                     LoggedUser = selectedUser;
//                     var messageText = $"Se ha Ingresedo correctamente a {LoggedUser.UserName}";
//                     SendMessage(_message.Chat.Id, messageText);
//                     LogInUserName = String.Empty;
//                     LogInPassword = String.Empty;
//                     LogIn = false;
//                 }
//                 else
//                 {
//                     var messageText = "Credenciales incorrectas.";
//                     SendMessage(_message.Chat.Id, messageText);
//                 }
//             }
//         }

//         /// <summary>
//         /// Método para crear una nueva cuenta dentro de un User existente.
//         /// Para poder acceder a este método debe de existir un LoggedUser
//         /// </summary>
//         /// <param name="_message"></param>
//         private static void CreateAccount(Message _message)
//         {
//             /// <summary>
//             /// Guarda el tipo de cuenta ingresado
//             /// </summary>
//             if (NewAccountType == null)
//             {
//                 if (String.IsNullOrEmpty(_message.Text) || (_message.Text != "1" && _message.Text != "2" && _message.Text != "3"))
//                 {
//                     System.Console.WriteLine(String.IsNullOrEmpty(_message.Text));
//                     var messageText = "Debe seleccionar un tipo de cuenta \n \n";
//                     SendMessage(_message.Chat.Id, messageText);
//                     messageText = "Seleccione un tipo de cuenta:";
//                     SendMessage(_message.Chat.Id, messageText);
//                     SendMessage(_message.Chat.Id, ShowAccountType());
//                 }
//                 else
//                 {
//                     NewAccountType = (AccountType)Enum.Parse(typeof(AccountType), _message.Text);
//                     System.Console.WriteLine(NewAccountType);
//                     var messageText = "Ingrese un nombre de cuenta:";
//                     SendMessage(_message.Chat.Id, messageText);
//                 }
//             }
//             /// <summary>
//             /// Guarda el nombre de cuenta ingresado siempre y cuando no exista una cuenta
//             /// con este nombre
//             /// </summary>
//             /// <returns></returns>
//             else if (NewAccountType != null && String.IsNullOrEmpty(NewAccountName))
//             {
//                 var exists = false;
//                 foreach (Account account in LoggedUser.Accounts)
//                 {
//                     if (account.Name == _message.Text)
//                     {
//                         exists = true;
//                     }
//                 }
//                 if (String.IsNullOrEmpty(_message.Text))
//                 {
//                     var messageText = "Debe ingresar un nombre de cuenta.\n\n";
//                     SendMessage(_message.Chat.Id, messageText);
//                     messageText = "Ingrese un nombre de cuenta:";
//                     SendMessage(_message.Chat.Id, messageText);
//                 }
//                 else if (exists)
//                 {
//                     var messageText = "Ya existe una cuenta con este nombre.\n\n";
//                     SendMessage(_message.Chat.Id, messageText);
//                     messageText = "Ingrese un nombre de cuenta:";
//                     SendMessage(_message.Chat.Id, messageText);
//                 }
//                 else
//                 {
//                     NewAccountName = _message.Text;
//                     var messageText = "Seleccione un tipo de moneda:";
//                     SendMessage(_message.Chat.Id, messageText);
//                     SendMessage(_message.Chat.Id, ShowCurrencyList());
//                 }
//             }
//             /// <summary>
//             /// Se muestran todas las monedas dentro de Bank.CurrencyList y se guarda la seleccionada
//             /// </summary>
//             /// <returns></returns>
//             else if (!String.IsNullOrEmpty(NewAccountName) && NewAccountCurrency == null)
//             {
//                 int number;
//                 if (String.IsNullOrEmpty(_message.Text) && Int32.TryParse(_message.Text, out number) && Bank.Instance.CurrencyList[Int32.Parse(_message.Text) - 1] == null)
//                 {


//                     var messageText = "Debe seleccionar un tipo de moneda.\n\n";
//                     SendMessage(_message.Chat.Id, messageText);
//                     messageText = "Seleccione un tipo de moneda:";
//                     SendMessage(_message.Chat.Id, messageText);
//                     SendMessage(_message.Chat.Id, ShowCurrencyList());

//                 }
//                 else
//                 {
//                     NewAccountCurrency = Bank.Instance.CurrencyList[Int32.Parse(_message.Text) - 1];
//                     var messageText = "Ingrese el saldo inicial de la cuenta:";
//                     SendMessage(_message.Chat.Id, messageText);
//                 }
//             }
//             /// <summary>
//             /// Guarda el saldo total inicial de la cuenta
//             /// </summary>
//             /// <param name="!"></param>
//             /// <returns></returns>
//             else if (NewAccountCurrency != null && NewAccountAmount == null)
//             {
//                 try
//                 {
//                     NewAccountAmount = Convert.ToDouble(_message.Text);
//                     var messageText = "Ingrese el objetivo de la cuenta:";
//                     SendMessage(_message.Chat.Id, messageText);
//                 }
//                 catch
//                 {
//                     var messageText = "Debe ingresar un valor válido.\n \n";
//                     SendMessage(_message.Chat.Id, messageText);
//                     messageText = "Ingrese el saldo inicial de la cuenta:";
//                     SendMessage(_message.Chat.Id, messageText);
//                 }
//             }
//             /// <summary>
//             /// Guarda el objetivo de la cuenta
//             /// </summary>
//             /// <param name="!"></param>
//             /// <returns></returns>
//             else if (NewAccountAmount != null && NewAccountObjective == null)
//             {
//                 try
//                 {
//                     NewAccountObjective = Convert.ToDouble(_message.Text);
//                 }
//                 catch
//                 {
//                     var messageText = "Debe ingresar un valor válido.\n \n";
//                     SendMessage(_message.Chat.Id, messageText);
//                     messageText = "Ingrese el objetivo de la cuenta:";
//                     SendMessage(_message.Chat.Id, messageText);
//                 }
//             }
//             /// <summary>
//             /// Se crea una nueva cuenta con todos los datos ingresados utilizando el método
//             /// AddAccount dentro de la instancia User.
//             /// </summary>
//             if (NewAccountType != null && NewAccountName != null && NewAccountCurrency != null && NewAccountAmount != null && NewAccountObjective != null)
//             {
//                 LoggedUser.AddAccount(NewAccountName, (AccountType)NewAccountType, NewAccountCurrency, (double)NewAccountAmount, (double)NewAccountObjective);
//                 var messageText = $"Se ha creado la cuenta {NewAccountName}";
//                 SendMessage(_message.Chat.Id, messageText);
//                 NewAccountType = null;
//                 NewAccountName = String.Empty;
//                 NewAccountCurrency = null;
//                 NewAccountAmount = null;
//                 NewAccountObjective = null;
//                 CreatingAccount = false;
//             }
//         }

//         /// <summary>
//         /// Método para la creación de una nueva transacción.
//         /// Para poder acceder a este método debe existir un LoggedUser
//         /// </summary>
//         /// <param name="_message"></param>
//         private static void MakeTransaction(Message _message)
//         {
//             /// <summary>
//             /// Utilizando las cuentas creadas dentro de LoggedUser, se muestran las mismas
//             /// y el usuario selecciona una de las mismas, luego se procede a validar y guardar
//             /// el valor ingresado
//             /// </summary>
//             if (TransactionAccount == null)
//             {
//                 int number;

//                 if (!Int32.TryParse(_message.Text, out number) || String.IsNullOrEmpty(_message.Text) || LoggedUser.Accounts[Int32.Parse(_message.Text) - 1] == null)
//                 {
//                     var messageText = "Debe ingresar un valor válido.\n \n";
//                     SendMessage(_message.Chat.Id, messageText);
//                     messageText = "Seleccione la cuenta en que desea realizar la transacción:";
//                     SendMessage(_message.Chat.Id, messageText);
//                 }
//                 else
//                 {
//                     TransactionAccount = LoggedUser.Accounts[Int32.Parse(_message.Text) - 1];
//                     var messageText = "Seleccione el tipo de transacción:";
//                     SendMessage(_message.Chat.Id, messageText);
//                     SendMessage(_message.Chat.Id, ShowCurrencyList());
//                 }
//             }
//             /// <summary>
//             /// El usuario selecciona el tipo de transacción, los únicos valores posibles son
//             /// "Income" y "Outcome"
//             /// </summary>
//             /// <returns></returns>
//             else if (TransactionAccount != null && String.IsNullOrEmpty(TransactionType))
//             {
//                 if (String.IsNullOrEmpty(_message.Text) || (_message.Text != "1" && _message.Text != "2"))
//                 {
//                     var messageText = "Debe ingresar un valor válido.\n \n";
//                     SendMessage(_message.Chat.Id, messageText);
//                     messageText = "Seleccione el tipo de transacción:";
//                     SendMessage(_message.Chat.Id, messageText);
//                 }
//                 else
//                 {
//                     TransactionType = _message.Text == "1" ? "Income" : "Outcome";
//                     var messageText = "Selecciona la moneda en la cual desea realizar la transacción:";
//                     SendMessage(_message.Chat.Id, messageText);
//                 }
//             }
//             /// <summary>
//             /// Se selecciona la moneda deseada para la transacción
//             /// </summary>
//             /// <param name="!"></param>
//             /// <returns></returns>
//             else if (TransactionType != null && TransactionCurrency == null)
//             {
//                 int number;
//                 if (!Int32.TryParse(_message.Text, out number) || String.IsNullOrEmpty(_message.Text) || Bank.Instance.CurrencyList[Int32.Parse(_message.Text) - 1] == null)
//                 {
//                     var messageText = "Debe ingresar un valor válido.\n \n";
//                     SendMessage(_message.Chat.Id, messageText);
//                     messageText = "Selecciona la moneda en la cual desea realizar la transacción:";
//                     SendMessage(_message.Chat.Id, messageText);
//                 }
//                 else
//                 {
//                     TransactionCurrency = Bank.Instance.CurrencyList[Int32.Parse(_message.Text) - 1];
//                     var messageText = "Ingrese el monto de la transacción:";
//                     SendMessage(_message.Chat.Id, messageText);
//                 }
//             }
//             /// <summary>
//             /// Se ingresa el valor de la transacción
//             /// </summary>
//             /// <param name="!"></param>
//             /// <returns></returns>
//             else if (TransactionCurrency != null && TransactionAmount == null)
//             {
//                 double number;
//                 if (!Double.TryParse(_message.Text, out number) || String.IsNullOrEmpty(_message.Text))
//                 {
//                     var messageText = "Debe ingresar un valor válido.\n \n";
//                     SendMessage(_message.Chat.Id, messageText);
//                     messageText = "Ingrese el monto de la transacción:";
//                     SendMessage(_message.Chat.Id, messageText);
//                 }
//                 else
//                 {
//                     var amount = Double.Parse(_message.Text);
//                     if (amount <= 0)
//                     {
//                         var messageText = "Debe ingresar un valor mayor a 0.\n \n";
//                         SendMessage(_message.Chat.Id, messageText);
//                     }
//                     else
//                     {
//                         TransactionAmount = amount;

//                         var messageText = TransactionType == "Outcome" ? "Seleccione la razón de gasto:" : "Seleccione la razón de ingreso:";
//                         SendMessage(_message.Chat.Id, messageText);
//                         SendMessage(_message.Chat.Id, ShowItemList());
//                     }
//                 }
//             }
//             /// <summary>
//             /// Según el tipo de transacción indicado previamente se muestran diferentes rubros
//             /// acorde al valor seleccionado.
//             /// </summary>
//             /// <returns></returns>
//             else if (TransactionAmount != null && String.IsNullOrEmpty(TransactionItem))
//             {
//                 var list = TransactionType == "Income" ? LoggedUser.IncomeList : LoggedUser.OutcomeList;
//                 int number;
//                 if (!Int32.TryParse(_message.Text, out number) || String.IsNullOrEmpty(_message.Text) || list[Int32.Parse(_message.Text) - 1] == null)
//                 {
//                     var messageText = "Debe ingresar un valor válido.\n \n";
//                     SendMessage(_message.Chat.Id, messageText);
//                     messageText = "Ingrese el monto de la transacción:";
//                     SendMessage(_message.Chat.Id, messageText);
//                 }
//                 else
//                 {
//                     TransactionItem = list[Int32.Parse(_message.Text) - 1];
//                 }
//             }
//             /// <summary>
//             /// Se crea la transacción con todos los valores ingresados y se guarda dentro de la cuenta
//             /// seleccionada.
//             /// </summary>
//             if (TransactionAccount != null && TransactionCurrency != null && TransactionAmount != null && TransactionItem != null)
//             {
//                 TransactionAccount.MakeTransaction((double)TransactionAmount, TransactionCurrency, TransactionItem);
//                 var messageText = "Transferencia exitosa.";
//                 SendMessage(_message.Chat.Id, messageText);
//             }
//         }
//         private static string ShowAccountType()
//         {
//             StringBuilder enumToText = new StringBuilder();
//             var accountType = Enum.GetNames(typeof(AccountType));
//             foreach (var item in accountType)
//             {
//                 enumToText.Append($"{Array.IndexOf(accountType, item) + 1 } - {item}\n");
//             }
//             return enumToText.ToString();
//         }
//         private static string ShowCurrencyList()
//         {
//             StringBuilder currencies = new StringBuilder();
//             foreach (Currency currency in Bank.Instance.CurrencyList)
//             {
//                 System.Console.WriteLine(currency.CodeISO);
//                 currencies.Append($"{Bank.Instance.CurrencyList.IndexOf(currency) + 1} - {currency.CodeISO}\n");
//             }
//             return currencies.ToString();
//         }
//         private static string ShowAccountList()
//         {
//             StringBuilder accountList = new StringBuilder();
//             foreach (Account account in LoggedUser.Accounts)
//             {
//                 accountList.Append($"{LoggedUser.Accounts.IndexOf(account) + 1} - {account.Name}\n");
//             }
//             return accountList.ToString();
//         }
//         private static string ShowItemList()
//         {
//             var list = TransactionType == "Income" ? LoggedUser.IncomeList : LoggedUser.OutcomeList;
//             StringBuilder itemList = new StringBuilder();
//             foreach (string item in list)
//             {
//                 itemList.Append($"{LoggedUser.OutcomeList.IndexOf(item) + 1} - {item}\n");
//             }
//             return itemList.ToString();
//         }
//         private static void Algo(object sender, MessageEventArgs messageEventArgs)
//         {
//             SendMessage(messageEventArgs.Message.Chat.Id, "Si señor");
//         }
//     }
//     //     private void SendAlert()
//     //     {
//     //         Manda la alerta
//     //             }
//     // }
// }

