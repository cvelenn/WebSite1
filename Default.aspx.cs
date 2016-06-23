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
        bool hasPermission = false;
        if (Session["user"] as Models.User != null)
        {
            hasPermission = true;
        }
        //update
        GridView1.Columns[0].Visible = hasPermission;
        //delete
        GridView1.Columns[1].Visible = hasPermission;
        //id
        GridView1.Columns[2].Visible = hasPermission;
        //{"The data types ntext and varchar are incompatible in the equal to operator."}
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            //Write code to add to card

            int RowIndex = int.Parse(e.CommandArgument.ToString());
            List<string> editData = new List<string>();
            for (int i = 0; i < 10; i++ )
            {
                editData.Add(GridView1.Rows[RowIndex].Cells[i + 2].Text);
            }
            
            Session["EditData"] = editData;

            Response.Redirect("EditTip.aspx");
        }
        if (e.CommandName == "DeleteRow")
        {
            int RowIndex = int.Parse(e.CommandArgument.ToString());
            string id = GridView1.Rows[RowIndex].Cells[2].Text;

            SqlCommand command = new SqlCommand("delete from tips where id like '" + id + "'", connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            Response.Redirect("Default.aspx");
        }
    }
}
