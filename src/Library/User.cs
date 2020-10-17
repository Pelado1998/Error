using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Bankbot
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        private Guid Id { get; set; }
        public List<Account> Accounts { get; set; }
        public List<String> IncomeList { get; set; }
        public List<String> OutcomeList { get; set; }
        private long ChatId { get; set; }
        public Account SelectedAccount { get; set; }

        public User(string userName, string password, long telegramId)
        {
            this.UserName = userName;
            this.Password = Cypher(password);
            this.Id = Guid.NewGuid();
            this.Accounts = new List<Account> { };
            this.ChatId = telegramId;
            this.SelectedAccount = null;
            this.IncomeList = new List<String> { "Salario", "Regalo" };
            this.OutcomeList = new List<String> { "Comida", "Transporte", "Ocio", "Alquiler", "Impuestos" };
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
        public void AddAccount(Account account)
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
            this.Password = Cypher(newPassword);
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
        public void AddItem(string name, string option)
        {
            //Income
            if (option == "1" && !this.OutcomeList.Contains(name))
            {
                this.IncomeList.Add(name);
            }
            //Outcome
            else if (option == "2" && !this.IncomeList.Contains(name))
            {
                this.OutcomeList.Add(name);
            }
            else if (this.IncomeList.Contains(name) || this.OutcomeList.Contains(name))
            {
                System.Console.WriteLine("Este elemento ya existe.");
            }
            else
            {
                System.Console.WriteLine("Opción incorrecta");
            }
        }
        public void RemoveItem(string name)
        {
            //Income
            if (this.IncomeList.Contains(name))
            {
                this.IncomeList.Remove(name);
            }
            //Outcome
            else if (this.OutcomeList.Contains(name))
            {
                this.OutcomeList.Remove(name);
            }
            else
            {
                System.Console.WriteLine("No existe dicho elemento en los rubros.");
            }
        }
        public void ShowItems()
        {
            StringBuilder res = new StringBuilder();
            res.Append("Income:\n\n");
            foreach (String item in this.IncomeList)
            {
                res.Append((this.IncomeList.IndexOf(item) + 1).ToString() + " - " + item + "\n");
            }
            res.Append("Outcome:\n\n");
            foreach (string item in this.OutcomeList)
            {
                res.Append((this.IncomeList.IndexOf(item) + 1).ToString() + " - " + item + "\n");
            }
        }



        //PasswordCode

        /// <summary>
        /// Clase que utilizando la funcion de derivacion clave PBKDF2 genera una contraseña cifrada y es capaz de descifrarla
        /// </summary>
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
        /// Compara ambas contraseñas provistas
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