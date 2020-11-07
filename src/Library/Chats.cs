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
        public long Id { get; set; }
        public State State { get; set; }
        public User User { get; set; }
        public Message Message {get;set;}
        #region Temps
            #region CreateUser
                public String CreateUserUsername { get; set; }
                public String CreateUserPassword { get; set; }
            #endregion
            #region DeleteUser
                public String DeleteUserUsername { get; set; }
                public String DeleteUserConfirmation { get; set; }
            #endregion
            #region Login
                public String LoginUsername { get; set; }
                public String LoginPassword { get; set; }
            #endregion
            #region CreateAccount
                public String AccountName { get; set; }
                public AccountType? AccountType {get;set;}
                public Currency AccountCurrency {get;set;}
                public double AccountAmount {get;set;}
                public double AccountObjective  {get;set;}
            #endregion
            #region DeleteAccount
                public String DeleteAccount { get; set; }
                public String DeleteAccountConfirmation { get; set; }
            #endregion
            #region Transaction
                public double TransactionAmount {get;set;}
                public Currency TransactionCurrency {get;set;}
                public DateTime TransactionDate {get;set;}
                public String TransactionItem {get;set;}
                public String TransactionDescription {get;set;}
            #endregion
            #region Convertion
                public double ConvertionAmount {get;set;}
                public Currency ConvertionFrom {get;set;}
                public Currency ConvertionTo {get;set;}
                
            #endregion      
        #endregion
        public Chats(long id)
        {
            this.State = State.Idle;
            this.User = null;
            this.Message = new Message();
            this.Message.Text = string.Empty;
            this.Id = id;
            CleanTemp();
        }
        public void CleanTemp()
        {
            #region Temps
                #region CreateUser
                    this.CreateUserUsername = null;
                    this.CreateUserPassword = null;
                #endregion
                #region Login
                    this.LoginUsername = null;
                    this.LoginPassword = null;
                #endregion
                #region DeleteUser
                    this.DeleteUserUsername = null;
                    this.DeleteUserConfirmation = null;
                #endregion
                #region CreateAccount
                    this.AccountName = null;
                    this.AccountType = null;
                    this.AccountCurrency = null;
                    this.AccountAmount = 0;
                    this.AccountObjective = 0;
                #endregion
                #region DeleteAccount
                    this.DeleteAccount = null;
                    this.DeleteAccountConfirmation = null;
                #endregion
                #region Transaction
                    this.TransactionAmount = 0;
                    this.TransactionCurrency = null;
                    this.TransactionDate = DateTime.MinValue;
                    this.TransactionItem = null;
                    this.TransactionDescription = null;
                #endregion
                #region Convertion
                this.ConvertionFrom = null;
                this.ConvertionTo = null;
                this.ConvertionAmount = 0;
            #endregion      
            #endregion
        }
    }
}