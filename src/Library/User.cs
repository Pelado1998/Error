using System;
using System.Text;
using System.Collections.Generic;


namespace Bankbot
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        private Guid Id { get; set; }
        public List<Account> Accounts { get; set; }
        private long ChatId { get; set; }
        public Account SelectedAccount { get; set; }

        public User(string userName, string password, long telegramId)
        {
            this.UserName = userName;
            this.Password = PasswordCypher.Cypher(password);
            this.Id = Guid.NewGuid();
            this.Accounts = new List<Account> { };
            this.ChatId = telegramId;
            this.SelectedAccount = null;
        }


        /// <summary>
        /// Metodo para probar por consola creacion de usuarios
        /// </summary>
        /// <returns></returns>
        public static User CreateUser()
        {
            System.Console.WriteLine("Ingresa un nombre de usuario: \n");
            var user = System.Console.ReadLine();
            System.Console.WriteLine("Ingresa una contraseña: \n");
            var password = System.Console.ReadLine();
            return new User(user, password, 1111);
        }


        /// <summary>
        /// Agregar un objeto Account a la la lista List<Account>
        /// </summary>
        /// <param name="account"></param>
        public void AddAcount(Account account)
        {
            if (this.Accounts == null)
            {
                this.Accounts = new List<Account> { };
                this.Accounts.Add(account);
            }
            else
            {
                this.Accounts.Add(account);
            }
        }

        /// <summary>
        /// Quita un objeto Account a la la lista List<Account>
        /// </summary>
        /// <param name="account"></param>
        public void RemoveAcount(Account account)
        {
            if (this.Accounts.Contains(account))
            {
                this.Accounts.Remove(account);
            }
            else
            {
                System.Console.WriteLine("No se ha encontrado la cuenta " + account.Name);
            }
        }

        /// <summary>
        /// Cambia el nombre de usuario
        /// </summary>
        /// <param name="newUserName"></param>
        public void ChangeUserName(string newUserName)
        {
            this.UserName = newUserName;
        }


        /// <summary>
        /// Cambia la contraseña generando un nuevo string cifrado
        /// </summary>
        /// <param name="newPassword"></param>
        public void ChangePassword(string newPassword)
        {
            this.Password = PasswordCypher.Cypher(newPassword);
        }


        /// <summary>
        /// Muestra todas las cuentas disponibles en consola de forma indexada
        /// </summary>
        public StringBuilder ShowAccounts()
        {
            StringBuilder accounts = new StringBuilder();
            if (this.Accounts.Count == 0)
            {
                accounts.Append("No hay cuentas asociadas a este usuario.");
            }
            else
            {
                foreach (Account account in this.Accounts)
                {
                    accounts.Append($"{this.Accounts.IndexOf(account) + 1} - {account.Name}\n");
                }
            }
            System.Console.WriteLine(accounts);
            return accounts;
        }
    }
}