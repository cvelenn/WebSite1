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

    protected void Page_Load(object sender, EventArgs e)
    {
        String sqlCommand = "SELECT top 10 [id], [league], [event], [date], [selection], [odd], [stake], [profit], [result], [bookmaker] FROM [tips] {0} order by [date] DESC";
        String whereClause = "";
        if (Session["user"] as Models.User == null)
        {
            whereClause = "where [result] != ''";
        }

        SqlDataSource2.SelectCommand = string.Format(sqlCommand, whereClause);
    }

}
