using System;
using System.Text;
using System.Collections.Generic;
using static System.Math;

namespace Bankbot
{
    public enum AccountType
    {
        CuentaDeAhorro = 1,
        Debito = 2,
        Credito = 3
    }
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
    /// <summary>
    public class Account : IObservable
    {
        public string Name { get; set; }
        public List<Transaction> History { get; set; }
        public AccountType AccountType { get; set; }
        public Currency Currency { get; set; }
        public float Amount { get; set; }
        public float Objective { get; set; }
        public Account(string name, AccountType type, Currency currency, float amount, float objective)
        {
            this.Name = name;
            this.History = new List<Transaction>();
            this.AccountType = type;
            this.Currency = currency;
            this.Amount = amount;
            this.Objective = objective;
        }

        public void ChangeObjective(float newObjective)
        {
            this.Objective = newObjective;
        }

        public void AddIncome(Currency currency, float amount, string description)
        {
            Transaction transaction = new Income(amount, currency, DateTime.Now, description);
            History.Add(transaction);
        }
        public void AddOutcome(Currency currency, float amount, string item, string description)
        {
            Transaction transaction = new Outcome(amount, currency, DateTime.Now, item, description);
            History.Add(transaction);
        }

        public static string ShowAccountType()
        {
            StringBuilder enumToText = new StringBuilder();
            var accountType = Enum.GetNames(typeof(AccountType));
            foreach (var item in accountType)
            {
                enumToText.Append($"{Array.IndexOf(accountType, item) + 1 } - {item}\n");
            }
            return enumToText.ToString();
        }
    }
}
