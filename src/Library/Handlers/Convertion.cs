using System;
using System.Collections.Generic;

namespace Bankbot
{
    public class Convertion : AbstractHandler<IMessage>
    {
        public Convertion(ConvertionCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        { 
            if ((Double) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["ConvertAmount"]== 0.0 && request.message == "/Convertion")
            {
                ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese un valor para convertir");
            }
            else if ((Double) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["ConvertAmount"]== 0.0)
            {
                Double ammount;
                if (Double.TryParse(request.message, out ammount) && ammount> 0.0)
                {
                    AllChats.Instance.ChatsDictionary[request.id].DataDictionary["ConvertAmount"] = ammount;
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese la divisa que desea convertir\n" + Bank.ShowCurrencyList());

                }
                else
                {
                     ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese un valor válido");
                }
            }
            else if ((Currency) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["ConvertFrom"]== Currency.Empty)
            {
                int idx;
                if (Int32.TryParse(request.message,out idx) && idx>0 && idx<= Bank.Instance.CurrencyList.Count)
                {
                    AllChats.Instance.ChatsDictionary[request.id].DataDictionary["ConvertFrom"] = Bank.Instance.CurrencyList[idx];
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese la divisa a la que desea convertir\n" + Bank.ShowCurrencyList());
                }
                else
                {
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese un valor válido");
                }
            }
            else if ((Currency) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["ConvertTo"]== Currency.Empty)
            {
                int idx;
                if (Int32.TryParse(request.message,out idx) && idx>0 && idx<= Bank.Instance.CurrencyList.Count)
                {
                    double converted;
                    AllChats.Instance.ChatsDictionary[request.id].DataDictionary["ConvertTo"] = Bank.Instance.CurrencyList[idx];
                    converted = Bank.Convert((Double)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["ConvertAmount"],(Currency)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["ConvertFrom"],(Currency)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["ConvertTo"]);
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Resultado de la conversión:\n"+
                    (Double)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["ConvertAmount"] + " " +
                    ((Currency)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["ConvertFrom"]).CodeISO+
                    " ~ " +
                    converted + " "+
                    ((Currency)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["ConvertTo"]).CodeISO
                    );
                    AllChats.Instance.ChatsDictionary[request.id].ClearConvertion();
                }
                else
                {
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese un valor válido");
                }
            }
        }
    }
}