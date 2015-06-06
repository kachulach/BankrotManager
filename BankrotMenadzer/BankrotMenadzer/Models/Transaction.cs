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
        private int tran_id;
        private int cat_id;
        private int price;
        private DateTime datum;
        private int kom_id;
        private int user_id;
        private bool wish;
        private bool bo;

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

        public Transaction(int tran_id, string name, int cat_id, int price, DateTime datum, int kom_id, int user_id, bool wish, bool bo)
        {
            // TODO: Complete member initialization
            // izvadi sto treba od site ovie podatoci 
            this.tran_id = tran_id;
            this.Name = name;
            this.cat_id = cat_id;
            this.price = price;
            this.datum = datum;
            this.kom_id = kom_id;
            this.user_id = user_id;
            this.wish = wish;
            this.bo = bo;

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