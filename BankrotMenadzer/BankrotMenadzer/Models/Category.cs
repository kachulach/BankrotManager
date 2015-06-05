using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BankrotManager.Models
{
    public class Category
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

        public Category(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append(string.Format("{0}: '{1}'", "name", Name));
            sb.Append(string.Format("{0}: '{1}'", "id", ID));
            sb.Append("}");
            return sb.ToString();
        }

    }
}