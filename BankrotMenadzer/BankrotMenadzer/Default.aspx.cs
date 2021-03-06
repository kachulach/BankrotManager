﻿using BankrotManager;
using BankrotManager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankrotManager
{
    public enum TransactionType
    {
        Spending = 1,
        Saving = 2,
        Wishlist = 3,
        Transfer = 4
    }

    public partial class Default : System.Web.UI.Page
    {
        private int user_id;
        private int total_funds;
        Database database = new Database();
        public static Dictionary<int, string> Categories;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            user_id = int.Parse(Session["user_id"].ToString());

            total_funds = database.currentFunds(user_id) + database.getSavedFunds(user_id);

            if (repeater_categories != null)
            {
                Categories = new Dictionary<int, string>();

                if (!HelperTools.isInitialized)
                {
                    HelperTools.Initialize();
                }

                repeater_categories.DataSource = HelperTools.Categories;
                repeater_categories.DataBind();
            }

            var wishlist = database.getAffordableItemsWishlist(user_id, total_funds);
            if (wishlist != null)
            {
                var rnd = new Random();
                var result = wishlist.OrderBy(item => rnd.Next());
                if (wishlist.Count <= 3)
                {
                    repeater_wishlist.DataSource = wishlist;
                    repeater_wishlist.DataBind();
                }
                else
                {
                    var data = result.Take(3);
                    repeater_wishlist.DataSource = data;
                    repeater_wishlist.DataBind();
                }
            }
        }
        /// <summary>
        /// AJAX Call with data from the website.
        /// </summary>
        [WebMethod(EnableSession = true)]
        public static string AJAX_AddTransaction(string type, string name, string amount, string category, string comment)
        {
            //DB query to add transaction and return new daily transaction state
            TransactionType tType = TransactionType.Spending;
            switch (type)
            {
                case "1":
                    tType = TransactionType.Saving;
                    break;
                case "2":
                    tType = TransactionType.Spending;
                    break;
                case "3":
                    tType = TransactionType.Wishlist;
                    break;
                case "4":
                    tType = TransactionType.Transfer;
                    break;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                return "{ }";
            }

            int amt = -1;
            if (string.IsNullOrWhiteSpace(amount))
            {
                return "{ }";
            }
            amt = int.Parse(amount);

            if (string.IsNullOrWhiteSpace(category))
            {
                return "{ }";
            }
            var cat = int.Parse(category);


            return ValidateAndAdd(tType, name, amt, cat, comment).ToString();
        }

        private static Transaction ValidateAndAdd(TransactionType type, string name, int amount, int category_id, string comment)
        {
            Database db = new Database();
            var user = int.Parse(HttpContext.Current.Session["user_id"].ToString());
            int comment_id = -1;
            if (!string.IsNullOrWhiteSpace(comment))
            {
                comment_id = (int)db.addComment(comment);
                db.addTransaction(category_id, user, (int)comment_id, amount, DateTime.Now, name, type == TransactionType.Wishlist);
            }
            else
            {
                db.addTransactionBezKomentar(category_id, user, amount, DateTime.Now, name, type == TransactionType.Wishlist);
            }

            return new Transaction()
            {
                Category = new Category(category_id, HelperTools.Categories[category_id]),
                Date = DateTime.Now,
                Type = (int)type,
                Amount = amount,
                Comment_ID = comment_id,
                ID = -1,
                Name = name
            };
        }

        [WebMethod]
        public static string AJAX_GetCurrentFunds()
        {
            Database db = new Database();
            int user_id = (int)HttpContext.Current.Session["user_id"];
            int saved_funds = db.getSavedFunds(user_id);
            int curr_funds = db.currentFunds(user_id);
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append("\"funds\": ");
            sb.Append(curr_funds);
            sb.Append(", ");
            sb.Append("\"saved_funds\": ");
            sb.Append(saved_funds);
            sb.Append("}");
            return sb.ToString();
        }

        [WebMethod]
        public static string AJAX_DailyStats(string type)
        {
            Database db = new Database();
            List<Transaction> transactions = null;
            switch (type)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
            }
            transactions = db.getFromToTransactions(int.Parse(HttpContext.Current.Session["user_id"].ToString()), DateTime.Now.Subtract(new TimeSpan(7, 0, 0, 0, 0)), DateTime.Now, int.Parse(type));
            //return chart data
            return HelperTools.FormatToChartData(transactions);
        }

        [WebMethod]
        public static string AJAX_TransactionData(string from, string to, string type)
        {
            DateTime dateFrom = Convert.ToDateTime(from);
            DateTime dateTo = Convert.ToDateTime(to);

            Database db = new Database();
            var transactions = db.getFromToTransactions(int.Parse(HttpContext.Current.Session["user_id"].ToString()), dateFrom, dateTo, int.Parse(type));
            //return chart data
            return HelperTools.FormatTransactions(transactions);

        }



        protected void btn_BuyWishlist_OnClick(object sender, EventArgs e)
        {
            
        }
    }
}
