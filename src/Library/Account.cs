using System;
using System.Text;
using System.Collections.Generic;
using static System.Math;

namespace Bankbot
{
    /// <summary>
    /// 
    /// </summary>

    public enum AccountType
    {
        CuentaDeAhorro = 1,
        Debito = 2,
        Credito = 3,
        Empty = 4, //Asegurarse de que sea siempre el último por ahora
    }
    public class Account : IObservable
    /// <summary>
    /// Esta clase cumple con el principio de asignacion de responsabilidades GRASP, experto en información. 
    /// Cumple con el patrón Creator el cual identifica quien debe ser responsable de la creación de nuevos objetos.
    /// Este patrón nos dice que esta nueva clase debe ser creada por otra, quien tendra toda la información necesaria para la creación del
    /// objeto, tambien esta clase debe ser la que utiliza de forma directa las instancias creadas del objeto o almacena las mismas, por último, tambien
    /// puede ser responsable de contener o agregar el objeto creado.
    /// En nuestro caso, el método MakeTransaction es parte de la clase Account ya que es el encargado de crear instancias del objeto Transaction,
    /// el cual, una vez creado se almacenara en una List<Transaction> formando asi el Historial de transacciones de la cuenta.
    /// A su vez cumple con el patrón OCP (Open - Closed Principle) de los principios SOLID, ya que es una clase que se encuentra abierta a la extensión,
    /// pero cerrada a la modificación
    {
        public string Name { get; set; }
        public List<Transaction> History { get; set; }
        public AccountType? AccountType { get; set; }
        public Currency Currency { get; set; }
        public double Amount { get; set; }
        public double Objective { get; set; }
        public static Account Empty { get; internal set; }

        public Account(string name, AccountType? type, Currency currency, double amount, double objective)
        {
            this.Name = name;
            this.History = new List<Transaction>();
            this.AccountType = type;
            this.Currency = currency;
            this.Amount = amount;
            this.Objective = objective;
        }

        public void ChangeObjective(double newObjective)
        {
            this.Objective = newObjective;
        }

        public string MakeTransaction(double amount, Currency currency, String item)
        {
            if (amount + this.Amount < 0)
            {
                return "Saldo insuficiente.";
            }
            else if (amount + this.Amount > 0)
            {
                double convertedAmount = Bank.Convert(amount, currency, this.Currency);
                Transaction transaction = new Transaction(convertedAmount, this.Currency, DateTime.Now, item);
                this.Amount += convertedAmount;
                this.History.Add(transaction);
                return "Trasferencia existosa.";
            }
            else
            {
                return "Valor inválido.";
            }
        }

        public string ShowHistory(IMessage request)
        {
            StringBuilder status = new StringBuilder();
            status.Append("--- Historial de la cuenta " + this.Name + " ---\n");
            if (this.History.Count != 0)
            {
                foreach (Transaction transaction in this.History)
                {
                    var type = Sign(transaction.Amount) == 1 ? "Ingreso" : "Egreso";
                    status.Append($"{type}: {transaction.Currency} {transaction.Amount} {transaction.Date.ToString("dd/MM/yyyy H:mm")} \n");
                }
            }
            else
            {
                status.Append("Esta cuenta está vacía.\n");
                ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,status.ToString());
            }
            status.Append($"Total: {this.Amount} / {this.Objective}");
            if (this.Amount >= this.Objective)
            {
                status.Append("'😁'\n");
            }
            else
            {
                status.Append("'🥺'\n");
            }
            status.Append("-----------------------------------------");
            ((IChannel) AllChats.Instance.ChatsDictionary[request.id].DataDictionary["Channel"]).SendMessage(request.id,status.ToString());
            return status.ToString();
        }
        public static string ShowAccountType()
        {
            StringBuilder enumToText = new StringBuilder();
            var accountType = Enum.GetNames(typeof(AccountType));
            foreach (String item in accountType)
            {
                if (item != Bankbot.AccountType.Empty.ToString())
                {
                    enumToText.Append($"{Array.IndexOf(accountType, item) + 1 } - {item}\n");
                }
            }
            return enumToText.ToString();
        }
        public static int AmountTypes()
        {
            return (Enum.GetNames(typeof(AccountType))).Length;
        }
    }
}
