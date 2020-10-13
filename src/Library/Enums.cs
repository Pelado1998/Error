using System;
using System.Collections.Generic;
using System.Security;

namespace Bankbot
{
    public class Enums
    {
        public enum AccountType
        {
            CuentaDeAhorro = 1,
            Debito = 2,
            Credito = 3
        }
        public enum Coin
        {
            USS = 0,
            URU = 1,
            ARG = 2,
        }

        public enum TransactionType
        {
            Debit = 0,
            Accredit = 1,
        }
        public enum Item
        {
            Salario = 0,
            Comida = 1,
            Transporte = 2,
            Ocio = 3,
            Alquiler = 4,
            Impuestos = 5,

        }
    }
}