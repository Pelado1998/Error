using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class Data
    {
        public Dictionary<string,Object> DataDictionary { get; set; }

        public static Data Empty { get; internal set; }

        public Data()
        {
            this.DataDictionary = new Dictionary<string,Object>(); 
            this.DataDictionary.Add("CreateUserPassword", string.Empty);
            this.DataDictionary.Add("CreateUserUsername", string.Empty);
            this.DataDictionary.Add("DeleteUser", string.Empty);
            this.DataDictionary.Add("DeleteUserConfirmation", string.Empty);
            this.DataDictionary.Add("LoginUsername", string.Empty);
            this.DataDictionary.Add("LoginPassword", string.Empty);
            this.DataDictionary.Add("CreateAccountName", string.Empty);
            this.DataDictionary.Add("CreateAccountType", AccountType.Empty);
            this.DataDictionary.Add("CreateAccountCurrency", Currency.Empty);
            this.DataDictionary.Add("CreateAccountAmount", 0.0);
            this.DataDictionary.Add("CreateAccountObjective", 0.0);
            this.DataDictionary.Add("DeleteAccount", string.Empty);
            this.DataDictionary.Add("DeleteAccountConfirmation", string.Empty);
            this.DataDictionary.Add("CreateTransactionAccount", string.Empty);
            this.DataDictionary.Add("CreateTransactionType", 0);
            this.DataDictionary.Add("CreateTransactionCurrency", Currency.Empty);
            this.DataDictionary.Add("CreateTransactionAmount", 0.0);
            this.DataDictionary.Add("CreateTransactionItem", string.Empty);
            this.DataDictionary.Add("CreateTransactionDescription", string.Empty);
            this.DataDictionary.Add("ConvertFrom", Currency.Empty);
            this.DataDictionary.Add("ConvertTo",Currency.Empty);
            this.DataDictionary.Add("ConvertAmount",0.0);
            this.DataDictionary.Add("User", User.Empty);
            this.DataDictionary.Add("LastCommand", string.Empty);
            this.DataDictionary.Add("Channel", ConsoleBot.Instance);
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
            this.DataDictionary["CreateTransactionAccount"] = string.Empty;
            this.DataDictionary["CreateTransactionType"] = 0;
            this.DataDictionary["CreateTransactionCurrency"] = Currency.Empty;
            this.DataDictionary["CreateTransactionAmount"] = 0.0;
            this.DataDictionary["CreateTransactionItem"] = string.Empty;
            this.DataDictionary["CreateTransactionDescription"] =string.Empty;
            ClearLastCommand();
        }

        public void ClearDeleteAccount()
        {
            this.DataDictionary["DeleteAccount"] = string.Empty;
            this.DataDictionary["DeleteAccountConfirmation"] = string.Empty;
            ClearLastCommand();
        }

        public void ClearCreateAccount()
        {
            this.DataDictionary["CreateAccountName"] = string.Empty;
            this.DataDictionary["CreateAccountType"] = AccountType.Empty;
            this.DataDictionary["CreateAccountCurrency"] = Currency.Empty;
            this.DataDictionary["CreateAccountAmount"] = 0.0;
            this.DataDictionary["CreateAccountObjective"] = 0.0;
            ClearLastCommand();
        }

        public void ClearLogin()
        {
            this.DataDictionary["LoginUsername"] = string.Empty;
            this.DataDictionary["LoginPassword"] = string.Empty;
            ClearLastCommand();
        }

        public void ClearDeleteUser()
        {
            this.DataDictionary["DeleteUser"] = string.Empty;
            this.DataDictionary["DeleteUserConfirmation"] = string.Empty;
            ClearLastCommand();
        }

        public void ClearCreateUser()
        {
            this.DataDictionary["CreateUserPassword"] = string.Empty;
            this.DataDictionary["CreateUserUsername"] = string.Empty;
            ClearLastCommand();
        }
    }
}