using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class InsertTip2 : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["kladionicaConnectionString1"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["user"] as Models.User == null) 
        {
            Response.Redirect("Logout.aspx");
        }

    }

    protected void InsertTipButton_Click(object sender, EventArgs e)
    {
        string league = this.league.Text;
        string Event = this.Event.Text;
        DateTime datetime;
        if (DateTime.TryParse(Request.Form[Date.UniqueID], out datetime))
        {
            datetime = DateTime.UtcNow;
        }
        string bookmarker = this.bookmarker.Text;
        string odd = this.odd.Text;
        string section = this.section.Text;
        string stake = this.stake.Text;
        string profit = this.profit.Text;
        string result = this.result.Text;
        string id = DateTime.UtcNow.Ticks.ToString();

        SqlCommand command = new SqlCommand("insert into tips (id, league, event, date, selection, odd, stake, profit, result, bookmaker) values ('" +
            id + "',"
            + "'" + league + "',"
            + "'" + Event + "',"
            + "'" + datetime + "',"
            + "'" + section + "',"
            + "'" + odd + "',"
            + "'" + stake + "',"
            + "'" + profit + "',"
            + "'" + result + "',"
            + "'" + bookmarker
            +"')", connection);

        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
        Response.Redirect("Default.aspx");
 
    }
    
}