using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BankrotManager
{
    public class HelperTools
    {
        public static bool isInitialized = false;
        public static Dictionary<int, string> Categories;
        public static string FormatToChartData(DataSet transactionRawData)
        {
            //transactionRawData.Tables[0].Rows[0].AcceptChanges
            return "";
        }

        public static void Initialize()
        {
            Categories = new Dictionary<int, string>();
            Categories.Add(0, "Not categorized");
            Database db = new Database();
            var cat = db.getAllCategories();
            foreach (DataRow c in cat.Tables[0].Rows)
            {
                Categories.Add(int.Parse(c["category_id"].ToString()), (string)c["name"]);
            }
            isInitialized = true;
        }

        
    }
}