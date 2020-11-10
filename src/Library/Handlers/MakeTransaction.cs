using System;

namespace Bankbot
{
    public class MakeTransaction : AbstractHandler<IMessage>
    {
        public MakeTransaction(TransactionCondition condition) : base(condition)
        {
        }

        protected override void handleRequest(IMessage request)
        {
            if(((User)(AllChats.Instance.ChatsDictionary[request.id].DataDictionary["User"])) == User.Empty)
            {
                ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Igresar a un usuario si tienes uno con el comando /Login o crear uno con el comando /CreateUser en caso de que no tengas uno antes de crear una transacción.\n Luego debes tener una cuenta a lo sumo. Para crear una cuenta utiliza el comando /CreateAccount");
                AllChats.Instance.ChatsDictionary[request.id].ClearTransaction();
            }
            else if (((User)(AllChats.Instance.ChatsDictionary[request.id].DataDictionary["User"])).Accounts.Count == 0)
            {
                ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Debes tener una cuenta antes de realizar una transacción. Prueba con el comando /CreateAccount");
                AllChats.Instance.ChatsDictionary[request.id].ClearTransaction();
            }
            else if ((String)(AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateTransactionAccount"])==String.Empty && request.message == "/Transaction")
            {
                ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese el AccountName de la cuenta a la que quiere realizar una transacción");
            }
            else if ((String)(AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateTransactionAccount"])==String.Empty)
            {
                if (((User)(AllChats.Instance.ChatsDictionary[request.id].DataDictionary["User"])).AccountExist(request.message))
                {
                    AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateTransactionAccount"] = request.message;
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese el tipo de transacción que desea realizar:\n1-Ingreso\n2-Gasto");
                }
                else
                {
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese una cuenta válida");
                }
            }
            else if ((Int32)(AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateTransactionType"])== 0)
            {
                int option;
                if (Int32.TryParse(request.message,out option) && option==1)    //Ingreso
                {
                    AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateTransactionType"]= 1;
                     ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese una cantidad para realizar la transacción");
                }
                else if (Int32.TryParse(request.message,out option) && option==2)   //Gasto
                {
                    AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateTransactionType"]= -1;
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese una cantidad para realizar la transacción");

                }
                else
                {
                  ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese un valor válido");   
                }
            }
            else if ((Double)(AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateTransactionAmount"])== 0.0)
            {
                Double ammount;
                if (Double.TryParse(request.message,out ammount) && ammount>0)
                {
                    AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateTransactionAmount"]= ammount;
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese una divisa para realizar la transacción\n" + Bank.ShowCurrencyList());   
                }
                else
                {
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese un valor válido");   
                }

            }
            else if ((Currency)(AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateTransactionCurrency"])== Currency.Empty)
            {
                Int32 idx;
                if (Int32.TryParse(request.message,out idx) && idx>0 && idx<= Bank.Instance.CurrencyList.Count)
                {
                    AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateTransactionCurrency"]= Bank.Instance.CurrencyList[idx];
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese un rubro dentro del cuál se registrará la transacción");   
                }
                else
                {
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese un valor válido");   
                }
            }
            else if ((String)(AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateTransactionItem"])== String.Empty)
            {
                AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateTransactionItem"]= request.message;
                ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Ingrese una descripción de la transacción");   
            }
            else if ((String)(AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateTransactionDescription"])== String.Empty)
            {
                AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateTransactionDescription"]= request.message;
                if (((User)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["User"]).GetAccount((String)(AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateTransactionAccount"])).MakeTransaction
                (
                    (Double)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateTransactionAmount"]*
                    Convert.ToDouble(((Int32)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateTransactionType"])),
                    (Currency)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateTransactionCurrency"],
                    (String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateTransactionItem"],
                    (String)AllChats.Instance.ChatsDictionary[request.id].DataDictionary["CreateTransactionDescription"]

                ))
                {
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"Se ha realizado la transación con éxito!");   
                    AllChats.Instance.ChatsDictionary[request.id].ClearTransaction();
                }
                else
                {
                    ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,"No se ha podido realizar la transacción. Pruebe nuevamente con el comando /Transaction");   
                    AllChats.Instance.ChatsDictionary[request.id].ClearTransaction();
                }
            }
        }
    }
}
