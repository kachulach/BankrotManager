using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BankrotMenadzer.Models
{
    public class Transaction
    {

        public string Name
        {
            get;
            private set;
        }

        public int Type
        {
            get;
            private set;
        }

        public int Amount
        {
            get;
            private set;
        }

        public string Comment
        {
            get;
            private set;
        }

        public DateTime Date
        {
            get;
            private set;
        }
        
        public Transaction()
        {

        }

        public Transaction(DataRow tableRow)
        {
            //Create Transaction object from table row
        }

    }
}