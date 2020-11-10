using System;
using System.Collections.Generic;
using System.Text;
using static Bankbot.Account;
using static Bankbot.Bank;

namespace Bankbot
{
    public class CreateAccount : AbstractHandler<IMessage>
    {
        public CreateAccount(ICondition<IMessage> condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            if ((String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateAccountName"] == string.Empty && request.message== "/CreateAccount")
            {
                ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese un AccountName");
            }
            else if ((String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateAccountName"] == string.Empty && (((User)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["User"]).AccountExist(request.message)))
            {
                ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Esa cuenta ya existe. Ingrese otro AccountName que no exista por favor");
            }
            else if ((String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateAccountName"] == string.Empty && !(((User)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["User"]).AccountExist(request.message)))
            {
                AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateAccountName"] = request.message;
                ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese un AccountType:\n" + ShowAccountType());
            }
            else if ((AccountType)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateAccountType"] == AccountType.Empty)
            {
                int idx;
                if (Int32.TryParse(request.message, out idx) && idx<=Account.AmountTypes() && idx>0 )
                {
                    AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateAccountType"] = (AccountType) idx;
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese un Currency:\n" + ShowCurrencyList()); 
                }
                else 
                {
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese un valor válido" + ShowAccountType());
                }
            }
            else if ((Currency)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateAccountCurrency"] == Currency.Empty)
            {
                int idx;
                if (Int32.TryParse(request.message, out idx) && idx<=Bank.Instance.CurrencyList.Count && idx>0 )
                {
                    AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateAccountCurrency"] = Bank.Instance.CurrencyList[idx];
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese un Ammount\n"); 
                }
                else 
                {
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese un valor válido\n" + ShowCurrencyList());
                }
            }
            else if ((Double)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateAccountAmount"] == 0.0)
            {
                Double ammount;
                if (Double.TryParse(request.message, out ammount) && ammount>0 )
                {
                    AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateAccountAmount"] = ammount;
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese un Objetive"); 
                }
                else
                {
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese un valor válido por favor");
                }
            }
            else if ((Double)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateAccountObjective"] == 0.0)
            {
                Double ammount;
                if (Double.TryParse(request.message, out ammount) && ammount>0 )
                {
                    AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateAccountObjective"] = ammount;
                    Account account = new Account
                    (
                        (String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateAccountName"],
                        (AccountType)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateAccountType"],
                        (Currency)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateAccountCurrency"],
                        (Double)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateAccountAmount"],
                        (Double)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateAccountObjective"]
                    );
                    ((User) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["User"]).Accounts.Add(account);
                    AllChats.Instance.ChatsDictionary[request.id].ClearCreateAccount();
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Cuenta creada con éxito");
                }
                else
                {
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese un valor válido por favor");
                }
            }
        }
    }
}