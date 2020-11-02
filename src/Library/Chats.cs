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

        #region Login
        LoginUsername,
        #endregion
        
        #region CreateAccount
            CreateAccountName,
            CreateAccountType,
            CreateAccountCurrency,
            CreateAccountAmount,
            CreateAccountObjective,
        #endregion
        
        #region DeleteAccount
            DeleteAccountName,
            DeleteAccountConfirmation,
        #endregion

        #region CreateTransaction
            CreateTransactionAccount,
            CreateTransactionType,
            CreateTransactionCurrency,
            CreateTransactionAmount,
            CreateTransactionItem,
        #endregion

        #region Convert
            ConvertFrom,
            ConvertTo,
            ConvertAmount,
        #endregion
        
        #region Default
            Idle,    
        #endregion
    }
    public class Chats
    {
        public long Id { get; set; }
        public List<string> History { get; set; }
        public State State { get; set; }
        public User User { get; set; }
        public List<Object> Temp {get;set;}
        public String Message {get;set;}
        public Chats(long id)
        {
            this.Id = id;
            this.History = new List<string>();
            this.State = State.Idle;
            this.User = null;
            this.Temp = new List<Object> ();
        }
    }
}