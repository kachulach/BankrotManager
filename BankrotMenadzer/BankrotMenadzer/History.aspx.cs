using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BankrotManager.Models;

namespace BankrotManager
{
    public partial class History : System.Web.UI.Page
    {
        private Database db;
        protected override void OnLoad(EventArgs e)
        {
            //Get from login
            if (Session["user_id"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            db = new Database();
            DateTime from = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0, 0));
            DateTime to = DateTime.Now;
            if (Request.QueryString.HasKeys())
            {
                from = Convert.ToDateTime(Request.QueryString["start"]);
                to = Convert.ToDateTime(Request.QueryString["end"]);
            }
            ShowData(from, to);
        }

        void ShowData(DateTime from, DateTime to, int type = 0)
        {
            var transactions = db.getFromToTransactions(int.Parse(Session["user_id"].ToString()), from, to, type);

            this.repeater_stats.DataSource = CreateStatisticsFromTransactions(transactions);
            this.repeater_stats.DataBind();

            this.repeater_rawdata.DataSource = transactions;
            this.repeater_rawdata.DataBind();
        }

        List<Statistic> CreateStatisticsFromTransactions(List<Transaction> transactions)
        {
            var stats = new List<Statistic>();
            var dict = new Dictionary<string, Statistic>();
            var totalAmount = 0;

            foreach (var t in transactions)
            {
                if (dict.ContainsKey(t.Category.Name))
                {
                    dict[t.Category.Name].UpdateStat(t);
                }
                else
                {
                    dict.Add(t.Category.Name, new Statistic());
                    dict[t.Category.Name].UpdateStat(t);
                }
                totalAmount += Math.Abs(t.Amount);
            }
            foreach (var kv in dict)
            {
                kv.Value.Percent = ((float)kv.Value.Amount / totalAmount) * 100f;
                stats.Add(kv.Value);
            }
            return stats;
        }

    }
}