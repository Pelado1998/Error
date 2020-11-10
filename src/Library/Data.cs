using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class Data
    {
        public Dictionary<String,Object> DataDictionary { get; set; }
        private static Data instance;
        
        public static Data Instance
        {
            get
            {
                if (instance == null) instance = new Data();
                return instance;
            }
        }

        public static Data Empty { get; internal set; }


        private Data()
        {
            this.DataDictionary = new Dictionary<String,Object>(); 
            this.DataDictionary.Add("CreateUserPassword", String.Empty);
            this.DataDictionary.Add("CreateUserUsername", String.Empty);
            this.DataDictionary.Add("DeleteUser", String.Empty);
            this.DataDictionary.Add("DeleteUserConfirmation", String.Empty);
            this.DataDictionary.Add("LoginUsername", String.Empty);
            this.DataDictionary.Add("LoginPassword", String.Empty);
            this.DataDictionary.Add("CreateAccountName", String.Empty);
            this.DataDictionary.Add("CreateAccountType", AccountType.Empty);
            this.DataDictionary.Add("CreateAccountCurrency", Currency.Empty);
            this.DataDictionary.Add("CreateAccountAmount", 0.0);
            this.DataDictionary.Add("CreateAccountObjective", 0.0);
            this.DataDictionary.Add("DeleteAccount", String.Empty);
            this.DataDictionary.Add("DeleteAccountConfirmation", String.Empty);
            this.DataDictionary.Add("CreateTransactionAccount", String.Empty);
            this.DataDictionary.Add("CreateTransactionType", 0);
            this.DataDictionary.Add("CreateTransactionCurrency", Currency.Empty);
            this.DataDictionary.Add("CreateTransactionAmount", 0.0);
            this.DataDictionary.Add("CreateTransactionItem", String.Empty);
            this.DataDictionary.Add("CreateTransactionDescription", String.Empty);
            this.DataDictionary.Add("ConvertFrom", Currency.Empty);
            this.DataDictionary.Add("ConvertTo",Currency.Empty);
            this.DataDictionary.Add("ConvertAmount",0.0);
            this.DataDictionary.Add("User", User.Empty);
            this.DataDictionary.Add("LastCommand", String.Empty);
            this.DataDictionary.Add("Channel", TelegramBot.Instance);
        }
        public void Abort()
        {
            ClearLastCommand();
            ClearConvertion();
            ClearTransaction();
            ClearDeleteAccount();
            ClearCreateAccount();
            ClearLogin();
            ClearDeleteUser();
            ClearCreateUser();
        }
        public void ClearLastCommand()
        {
            this.DataDictionary["LastCommand"] = "/Init";
        }

        public void ClearUser()
        {
            this.DataDictionary["User"] = User.Empty;
            ClearLastCommand();
        }

        public void ClearConvertion()
        {
            this.DataDictionary["ConvertFrom"] = Currency.Empty;
            this.DataDictionary["ConvertTo"] = Currency.Empty;
            this.DataDictionary["ConvertAmount"] = 0.0;
            ClearLastCommand();
        }

        public void ClearTransaction()
        {
            this.DataDictionary["CreateTransactionAccount"] = String.Empty;
            this.DataDictionary["CreateTransactionType"] = 0;
            this.DataDictionary["CreateTransactionCurrency"] = Currency.Empty;
            this.DataDictionary["CreateTransactionAmount"] = 0.0;
            this.DataDictionary["CreateTransactionItem"] = String.Empty;
            this.DataDictionary["CreateTransactionDescription"] =String.Empty;
            ClearLastCommand();
        }

        public void ClearDeleteAccount()
        {
            this.DataDictionary["DeleteAccount"] = String.Empty;
            this.DataDictionary["DeleteAccountConfirmation"] = String.Empty;
            ClearLastCommand();
        }

        public void ClearCreateAccount()
        {
            this.DataDictionary["CreateAccountName"] = String.Empty;
            this.DataDictionary["CreateAccountType"] = AccountType.Empty;
            this.DataDictionary["CreateAccountCurrency"] = Currency.Empty;
            this.DataDictionary["CreateAccountAmount"] = 0.0;
            this.DataDictionary["CreateAccountObjective"] = 0.0;
            ClearLastCommand();
        }

        public void ClearLogin()
        {
            this.DataDictionary["LoginUsername"] = String.Empty;
            this.DataDictionary["LoginPassword"] = String.Empty;
            ClearLastCommand();
        }

        public void ClearDeleteUser()
        {
            this.DataDictionary["DeleteUser"] = String.Empty;
            this.DataDictionary["DeleteUserConfirmation"] = String.Empty;
            ClearLastCommand();
        }

        public void ClearCreateUser()
        {
            this.DataDictionary["CreateUserPassword"] = String.Empty;
            this.DataDictionary["CreateUserUsername"] = String.Empty;
            ClearLastCommand();
        }
    }
}