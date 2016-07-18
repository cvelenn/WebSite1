using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;

public partial class _Default : System.Web.UI.Page
{
    //<add name="kladionicaConnectionString1" connectionString="Data Source=188.121.44.217;Initial Catalog=kladionica2;Integrated Security=False;User ID=rastko86;Password=Dajpara1509!;Connect Timeout=15;Encrypt=False;Packet Size=4096" providerName="System.Data.SqlClient" />
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["kladionicaConnectionString1"].ConnectionString);

    public string TotalProfit = string.Empty;
    public string Yield = string.Empty;
    public string WinRate = string.Empty;
    public string AverageOdds = string.Empty;
    public string NumberOfTips = string.Empty;

    public Dictionary<DateTime, double> ChartDates = new Dictionary<DateTime, double>();
    public List<string> MonthList = new List<string>();
    public List<string> ProfitList = new List<string>();
    public List<string> YieldList = new List<string>();
    public List<string> NumberOfTipsList = new List<string>();

    protected void Page_Load(object sender, EventArgs e)
    {
        String sqlCommand = "SELECT top 10 [id], [league], [event], [date], [selection], [odd], [stake], [profit], [result], [bookmaker] FROM [tips] {0} order by [date] DESC";
        String whereClause = "";
        Models.User user = Session["user"] as Models.User;
        if (user == null || !user.CanSeeTips())
        {
            whereClause = "where [result] != ''";
        }

        SqlDataSource2.SelectCommand = string.Format(sqlCommand, whereClause);

        SqlCommand command = new SqlCommand("SELECT [date], [odd], [stake], [profit], [result] FROM [tips] where [result] != ''  order by [date] DESC", connection);
        List<DateTime> dates = new List<DateTime>();
        List<double> odds = new List<double>();
        List<double> stake = new List<double>();
        List<double> profit = new List<double>();
        List<bool> result = new List<bool>();
        int startYear = -1;
        int startMonth = -1;
        string start = string.Empty;

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

            Dictionary<string, List<double>> profitDict = new Dictionary<string, List<double>>();
            Dictionary<string, List<double>> stakeDict = new Dictionary<string, List<double>>();

            for (int i = 0; i < profit.Count; i++)
            {
                if (startMonth == -1 || startYear < dates[i].Year || (startMonth > dates[i].Month && startYear == dates[i].Year))
                {
                    startMonth = dates[i].Month;
                    startYear = dates[i].Year;
                    start = dates[i].ToString("MMMM/yy");
                    MonthList.Add(start);
                    profitDict.Add(start, new List<double>());
                    stakeDict.Add(start, new List<double>());
                }
                if (!ChartDates.ContainsKey(dates[i]))
                {
                    ChartDates.Add(dates[i], profit[i]);
                }
                else 
                {
                    ChartDates[dates[i]] += profit[i];
                }

                profitDict[start].Add(profit[i]);
                stakeDict[start].Add(stake[i]);
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

            Series s = Chart1.Series["Series1"];
            foreach (string key in profitDict.Keys)
            {
                double prof2 = 0;
                double st2 = 0;
                int count = 0;
                for (int i = 0; i < profitDict[key].Count; i++)
                {
                    prof2 += profitDict[key][i];
                    st2 += stakeDict[key][i];
                    count++;
                }
                YieldList.Add(string.Format("{0:0.00}", ((prof2 / st2) * 100)));
                ProfitList.Add(prof2.ToString());
                NumberOfTipsList.Add(count.ToString());
                
            }
            var keys = ChartDates.Keys.ToArray();
            double previouse = 0;
            for (int i = keys.Length - 1; i >= 0; i--)
            {
                ChartDates[keys[i]] += previouse;
                s.Points.AddXY(keys[i], ChartDates[keys[i]]);
                previouse = ChartDates[keys[i]];
            }

            System.Drawing.Color c = System.Drawing.Color.FromArgb(93, 123, 157);
            s.Color = c;
            //title
            Title title = new Title("Profit", Docking.Top);
            title.ForeColor = c;
            Chart1.Titles.Add(title);
            s.Color = System.Drawing.Color.Green;
            //axis labels
            Chart1.ChartAreas[0].AxisY.LabelStyle.Format = "{0:} units";
            Chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = c;
            Chart1.ChartAreas[0].AxisX.LabelStyle.Format = "{0:MM/yy}";

            // ToolTip="Date: #VALX, Profit: #VALY units"

            reader.Close();
        }
        connection.Close();

    }

}
