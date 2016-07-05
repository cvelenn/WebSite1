using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class EditTip : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["kladionicaConnectionString1"].ConnectionString);
    
    protected void Page_Load(object sender, EventArgs e)
    {

        Models.User user = Session["user"] as Models.User;
        if (user == null || !user.CanChangeTips())
        {
            Response.Redirect("Logout.aspx");
        }

        if (Session["EditData"] != null)
        {
            if (!IsPostBack)
            {
                GetTip(Session["EditData"] as List<string>);
            }
        }

    }

    protected void GetTip(List<string> cell) 
    {

        this.league.Text = cell[1].Trim();
        this.Event.Text = cell[2].ToString().Trim();
        this.Date.Text = cell[3].ToString().Trim();
        this.section.Text = cell[4].ToString().Trim();
        this.odd.Text = cell[5].ToString().Trim();
        this.stake.Text = cell[6].ToString().Trim();
        this.profit.Text = cell[7].ToString().Trim();
        this.result.Text = cell[8].ToString().Trim();
        this.bookmarker.Text = cell[9].ToString().Trim();

    }

    protected void UpdateTipButton_Click(object sender, EventArgs e)
    {

        string league = this.league.Text.Trim();
        string Event = this.Event.Text.Trim();
        DateTime datetime;
        if (!DateTime.TryParse(Request.Form[Date.UniqueID], out datetime))
        {
            datetime = DateTime.UtcNow;
        }
        string bookmarker = this.bookmarker.Text.Trim();
        string odd = this.odd.Text.Trim();
        string section = this.section.Text.Trim();
        string stake = this.stake.Text.Trim();
        string profit = this.profit.Text.Trim();
        string result = this.result.Text.Trim();
        string editId = (Session["EditData"] as List<string>)[0].Trim();

        SqlCommand command = new SqlCommand("update tips set id=@id, league=@league, event=@event, date=@date, selection=@selection, odd=@odd, stake=@stake, profit=@profit, result=@result, bookmaker=@bookmaker where id=@id2;", connection);
        connection.Open();

        command.Parameters.AddWithValue("@id", editId);
        command.Parameters.AddWithValue("@league", league);
        command.Parameters.AddWithValue("@event", Event);
        command.Parameters.AddWithValue("@date", datetime);
        command.Parameters.AddWithValue("@selection", section);
        command.Parameters.AddWithValue("@odd", odd);
        command.Parameters.AddWithValue("@stake", stake);
        command.Parameters.AddWithValue("@profit", profit);
        command.Parameters.AddWithValue("@result", result);
        command.Parameters.AddWithValue("@bookmaker", bookmarker);
        command.Parameters.AddWithValue("@id2", editId);

        int a = command.ExecuteNonQuery();
        connection.Close();

        Session["EditData"] = null;
        Response.Redirect("Overall.aspx");

    }
    
}