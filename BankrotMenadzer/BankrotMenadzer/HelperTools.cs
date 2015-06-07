using BankrotManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace BankrotManager
{
    public class HelperTools
    {
        public static bool isInitialized = false;
        public static Dictionary<int, string> Categories;
        public static string FormatToChartData(List<Transaction> transactions)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int i = 0; i < transactions.Count; i++) 
            {
                var t = transactions[i];
                if (i != transactions.Count - 1)
                {
                    sb.Append(t.ChartData());
                    sb.Append(", \n");
                }
                else
                {
                    sb.Append(t.ChartData());
                }
            }
            sb.Append("]");
            return sb.ToString();
        }

        /// <summary>
        /// Returns JSON Formatted array of transactions
        /// </summary>
        /// <param name="transactions">List of transactions</param>
        /// <returns>JSON Data</returns>
        public static string FormatTransactions(List<Transaction> transactions)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int i = 0; i < transactions.Count; i++)
            {
                var t = transactions[i];
                if (i != transactions.Count - 1)
                {
                    sb.Append(t);
                    sb.Append(", \n");
                }
                else
                {
                    sb.Append(t.ChartData());
                }
            }
            sb.Append("]");
            return sb.ToString();
        }

        public static void Initialize()
        {
            if (Categories == null)
            {
                Categories = new Dictionary<int, string>();
                Database db = new Database();
                var cat = db.getAllCategories();
                foreach (var c in cat)
                {
                    Categories.Add(c.ID, c.Name);
                }
            }
            isInitialized = true;
        }

        
    }
}