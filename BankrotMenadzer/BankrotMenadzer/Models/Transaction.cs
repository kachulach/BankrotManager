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

        public int Comment_ID
        {
            get;
            set;
        }

        public int User_ID
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

        public bool IsWishlist
        {
            get;
            set;
        }

        public bool IsBought
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
            this.ID = tran_id;
            this.Name = name;
            this.Category = new Category(cat_id, HelperTools.Categories[cat_id]);
            this.Amount = price;
            this.Date = datum;
            this.Comment_ID = kom_id;
            this.User_ID = user_id;
            this.IsWishlist = wish;
            this.IsBought = bo;
        }

        /// <summary>
        /// Convert transaction to smaller chart data with label and value
        /// </summary>
        /// <returns>JSON Text data</returns>
        public string ChartData()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append(string.Format("\"{0}\": {1}, ", "value", Amount));
            sb.Append(string.Format("\"{0}\": \"{1}\" ", "label", Category.Name));
            sb.Append("}");
            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append(string.Format("\"{0}\": \"{1}\", ", "name", Name));
            sb.Append(string.Format("\"{0}\": {1}, ", "amount", Amount));
            sb.Append(string.Format("\"{0}\": {1}, ", "comment", Comment_ID));
            sb.Append(string.Format("\"{0}\": {1}, ", "type", Type));
            sb.Append(string.Format("\"{0}\": \"{1}\", ", "category", Category.Name));
            sb.Append(string.Format("\"{0}\": \"{1}\"", "date", Date.ToShortDateString()));
            sb.Append("}");
            return sb.ToString();
        }

    }
}