using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Bankbot
{
    /*Esta clase cumple con los principios GRAPS, ya que es experta en información sobre los usuarios, se encarga de 
    crear instancias de la clase Account para luego almacenarlos. Por esta razón cumple con los patrones Expert
    y Creator dentro de estos principios.
    Por otro lado cumple con el patrón OCP al ser una clase abierta a la extensión y cerrada a la modificación.*/
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        private Guid Id { get; set; }
        public List<Account> Accounts { get; set; }
        public List<String> OutcomeList { get; set; }

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = Cypher(password);
            this.Id = Guid.NewGuid();
            this.Accounts = new List<Account> { };
            this.OutcomeList = new List<String> { "Comida", "Transporte", "Ocio", "Alquiler", "Impuestos" };
        }

        /// <summary>
        /// Agregar un objeto Account a la la lista List<Account>
        /// </summary>
        /// <param name="account"></param>
        public Account AddAccount(AccountType type, string name, Currency currency, double balance, Objective objective)
        {
            if (this.Accounts == null)
            {
                this.Accounts = new List<Account> { };
            }
            foreach (var account in Accounts)
            {
                if (account.Name == name)
                {
                    return null;
                }
            }
            var newAccount = new Account(name, type, currency, balance, objective);
            this.Accounts.Add(newAccount);
            return newAccount;
        }

        public bool AccountNameExists(string name)
        {
            string accountName = String.Empty;

            foreach (var item in Accounts)
            {
                if (item.Name == name) accountName = item.Name;
            }

            return accountName == name;
        }

        /// <summary>
        /// Quita un objeto Account de la lista List<Account>
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
        /// <param name="newUsername"></param>
        public void ChangeUsername(string newUsername)
        {
            this.Username = newUsername;
        }

        /// <summary>
        /// Cambia la contraseña generando un nuevo string cifrado
        /// </summary>
        /// <param name="newPassword"></param>
        public void ChangePassword(string newPassword)
        {
            this.Password = Cypher(newPassword);
        }

        public string ShowAccountList()
        {
            StringBuilder accountList = new StringBuilder();
            foreach (var account in Accounts)
            {
                string index = (Accounts.IndexOf(account) + 1).ToString();
                accountList.Append(index + " - " + account.Name + "\n");
            }
            return accountList.ToString();
        }
        public string ShowItemList()
        {
            StringBuilder outcomeList = new StringBuilder();
            foreach (var outcome in OutcomeList)
            {
                string index = (OutcomeList.IndexOf(outcome) + 1).ToString();
                outcomeList.Append(index + " - " + outcome + "\n");
            }
            return outcomeList.ToString();
        }

        public bool ContainsItem(string newItem)
        {
            string exists = string.Empty;
            foreach (var item in OutcomeList)
            {
                if (item.ToLower() == newItem) exists = item;
            }
            return exists == newItem;
        }


        //Password Code

        /*Clase que utilizando la funcion de derivacion clave PBKDF2 genera una contraseña cifrada y es capaz de descifrarla.*/
        private const int SaltByteSize = 24;
        private const int HashByteSize = 20;
        private const int Pbkdf2Iterations = 1000;
        private const int IterationIndex = 0;
        private const int SaltIndex = 1;
        private const int Pbkdf2Index = 2;

        /// <summary>
        /// Recibiendo un string por parametro este metodo se encarga de generar un Salt, para luego por medio del metodo GetPbkdf2Bytes recibir un hash
        /// de esta forma generando una contraseña cifrada
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>

        public bool Login(string password)
        {
            return Decrypt(password, this.Password);
        }

        private string Cypher(string password)
        {
            var cryptoProvider = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SaltByteSize];
            cryptoProvider.GetBytes(salt);

            var hash = GetPbkdf2Bytes(password, salt, Pbkdf2Iterations, HashByteSize);
            return Pbkdf2Iterations + ":" +
                   Convert.ToBase64String(salt) + ":" +
                   Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Recibe un string y una contraseña cifrada, reevierte el proceso de Cypher y devuelve un bool comparando ambas contraseñas
        /// </summary>
        /// <param name="password"></param>
        /// <param name="correctHash"></param>
        /// <returns></returns>

        private bool Decrypt(string password, string correctHash)
        {
            char[] delimiter = { ':' };
            var split = correctHash.Split(delimiter);
            var iterations = Int32.Parse(split[IterationIndex]);
            var salt = Convert.FromBase64String(split[SaltIndex]);
            var hash = Convert.FromBase64String(split[Pbkdf2Index]);

            var testHash = GetPbkdf2Bytes(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        /// <summary>
        /// Compara ambas contraseñas provistas.<!--
        /// -->
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>

        private bool SlowEquals(byte[] a, byte[] b)
        {
            var diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <param name="iterations"></param>
        /// <param name="outputBytes"></param>
        /// <returns></returns>

        private byte[] GetPbkdf2Bytes(string password, byte[] salt, int iterations, int outputBytes)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }

    }
}