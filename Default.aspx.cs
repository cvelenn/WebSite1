using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["kladionicaConnectionString1"].ConnectionString);

    public string TotalProfit = string.Empty;
    public string Yield = string.Empty;
    public string WinRate = string.Empty;
    public string AverageOdds = string.Empty;
    public string NumberOfTips = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        String sqlCommand = "SELECT top 10 [id], [league], [event], [date], [selection], [odd], [stake], [profit], [result], [bookmaker] FROM [tips] {0} order by [date] DESC";
        String whereClause = "";
        if (Session["user"] as Models.User == null)
        {
            whereClause = "where [result] != ''";
        }

        SqlDataSource2.SelectCommand = string.Format(sqlCommand, whereClause);



        SqlCommand command = new SqlCommand("SELECT [date], [odd], [stake], [profit], [result] FROM [tips] where [result] != ''", connection);
        List<DateTime> dates = new List<DateTime>();
        List<double> odds = new List<double>();
        List<double> stake = new List<double>();
        List<double> profit = new List<double>();
        List<bool> result = new List<bool>();

        connection.Open();

        SqlDataReader reader = command.ExecuteReader();
        try
        {
            while (reader.Read())
            {
                dates.Add(DateTime.Parse(reader[0].ToString()));
                odds.Add(double.Parse(reader[1].ToString()));
                stake.Add(double.Parse(reader[2].ToString()));
                profit.Add(double.Parse(reader[3].ToString()));
                result.Add(reader[4].ToString().ToLower().Trim().Equals("won"));
            }
        }
        catch(Exception)
        {
            TotalProfit = string.Empty;
            Yield = string.Empty;
            WinRate = string.Empty;
            AverageOdds = string.Empty;
            NumberOfTips = string.Empty;
        }
        finally
        {
            double prof = 0;
            double st = 0;
            double winRate = 0;
            double avg = 0;
            for (int i = 0; i < profit.Count; i++)
            {
                prof += profit[i];
                st += stake[i];
                avg += odds[i];
                if (result[i])
                {
                    winRate += 1;
                }
            }
            TotalProfit = prof.ToString();
            Yield = string.Format("{0:0.00}", ((prof/st)*100));
            WinRate = string.Format("{0:0.00}", ((winRate / profit.Count) * 100));
            AverageOdds = string.Format("{0:0.00}", (avg / profit.Count));
            NumberOfTips = profit.Count.ToString();

            reader.Close();
        }
        connection.Close();

    }

}
