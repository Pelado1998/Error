using System;
using System.Text;
using System.Collections.Generic;

namespace Bankbot
{
    public enum AccountType
    {
        CuentaDeAhorro = 1,
        Debito = 2,
        Credito = 3
    }
    /*
    Esta clase cumple con el principio de asignacion de responsabilidades GRASP, experto en información. 
    Cumple con el patrón Creator el cual identifica quien debe ser responsable de la creación de nuevos objetos.
    Este patrón nos dice que esta nueva clase debe ser creada por otra, quien tendra toda la información necesaria para la creación del
    objeto, tambien esta clase debe ser la que utiliza de forma directa las instancias creadas del objeto o almacena las mismas, por último, tambien
    puede ser responsable de contener o agregar el objeto creado.
    En nuestro caso, el método MakeTransaction es parte de la clase Account ya que es el encargado de crear instancias del objeto Transaction,
    el cual, una vez creado se almacenara en una List<Transaction> formando asi el Historial de transacciones de la cuenta.
    A su vez cumple con el patrón OCP (Open - Closed Principle) de los principios SOLID, ya que es una clase que se encuentra abierta a la extensión,
    pero cerrada a la modificación.*/

    /// <summary>
    /// Clase cuenta la cual pueden ser de diferentes típos y contener diferentes divisas.
    /// </summary>
    public class Account
    {
        public string Name { get; set; }
        public List<Transaction> History { get; set; }
        public AccountType AccountType { get; set; }
        public Currency Currency { get; set; }
        public double Balance { get; set; }
        public Objective Objective { get; set; }

        /// <summary>
        /// Constructor de una cuenta.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="currency"></param>
        /// <param name="balance"></param>
        /// <param name="objective"></param>
        public Account(string name, AccountType type, Currency currency, double balance, Objective objective)
        {
            this.Name = name;
            this.History = new List<Transaction>();
            this.AccountType = type;
            this.Currency = currency;
            this.Balance = balance;
            this.Objective = objective;
        }

        /// <summary>
        /// Cambiar el objetivo de una cuenta.
        /// </summary>
        /// <param name="newObjective"></param>

        public void ChangeObjective(Objective newObjective)
        {
            this.Objective = newObjective;
        }

        /// <summary>
        /// Añadir una transacción a una cuenta.
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="amount"></param>
        /// <param name="description"></param>

        public void AddTransaction(Currency currency, double amount, string description)
        {
            Transaction transaction = new Transaction(amount, currency, DateTime.Now, description);
            this.History.Add(transaction);
            this.Balance += amount;
        }

        /// <summary>
        /// Mostrar el tipo de cuenta.
        /// </summary>
        /// <returns></returns>

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
