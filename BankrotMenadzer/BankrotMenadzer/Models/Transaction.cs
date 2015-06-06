using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace BankrotManager.Models
{
    public class Transaction
    {
        public int ID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }

        public int Type
        {
            get;
            set;
        }
        public int Amount
        {
            get;
          set;
        }

        public string Comment
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public Category Category
        {
            get;
            set;
        }
        
        public Transaction()
        {

        }

        public Transaction(DataRow tableRow)
        {
            //Create Transaction object from table row
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append(string.Format("\"{0}\": \"{1}\", ",  "name", Name));
            sb.Append(string.Format("\"{0}\": \"{1}\", ",  "amount", Amount));
            sb.Append(string.Format("\"{0}\": \"{1}\", ",  "comment", Comment));
            sb.Append(string.Format("\"{0}\": \"{1}\", ",  "type", Type));
            sb.Append(string.Format("\"{0}\": \"{1}\", ", "category", Category.Name));
            sb.Append(string.Format("\"{0}\": \"{1}\"",     "date", Date.ToShortDateString()));
            sb.Append("}");
            return sb.ToString();
        }

    }
}