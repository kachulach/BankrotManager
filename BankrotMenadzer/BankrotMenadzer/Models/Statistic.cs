using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankrotManager.Models
{
    public class Statistic
    {
        public string Category
        {
            get;
            set;
        }
        public int Amount
        {
            get;
            set;
        }
        public int Transactions
        {
            get;
            set;
        }
        public float Percent
        {
            get;
            set;
        }

        public void UpdateStat(Transaction t)
        {
            this.Amount += t.Amount;
            this.Transactions ++;
            this.Category = t.Category.Name;
        }
    }

}