using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using System.Collections.Generic;

namespace Bankbot
{
    public enum State
    {   
        #region CreateUser
            CreateUsername,
            CreatePassword,    
        #endregion

        #region DeleteUser
            DeleteUser,
            DeleteUserConfirmation,
        #endregion

        #region Login
            LoginUsername,
            LoginPassword,
        #endregion
        
        #region CreateAccount
            CreateAccountName,
            CreateAccountType,
            CreateAccountCurrency,
            CreateAccountAmount,
            CreateAccountObjective,
        #endregion
        
        #region DeleteAccount
            DeleteAccount,
            DeleteAccountConfirmation,
        #endregion

        #region Transaction
            CreateTransactionAccount,
            CreateTransactionType,
            CreateTransactionCurrency,
            CreateTransactionAmount,
            CreateTransactionItem,
        #endregion

        #region Convertion
            ConvertFrom,
            ConvertTo,
            ConvertAmount,
        #endregion
        
        #region Default
            Idle,
            Dispatcher,
            Loged,
            LogedAccounts,
        #endregion
    }
    public class Chats
    {
        public Data Data {get;set;}
        public Chats(String id)
        {
            this.Data = Data.Instance;
        }
    }
}