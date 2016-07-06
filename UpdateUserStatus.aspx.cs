using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Net;

public partial class UpdateUserStatus : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["kladionicaConnectionString1"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        Models.User user = Session["user"] as Models.User;
        if (user == null || !user.CanChangeTips())
        {
            Response.Redirect("Logout.aspx");
        }

        RegisterCX.Visible = false;
        Label2.Visible = false;
        Label3.Visible =  false;
        Date.Visible = false;
        UpdateUser.Visible = false;
    }

    private void searchForUser() 
    {
        Models.User user = null;
        DateTime date = DateTime.MinValue;

        using (SqlCommand command = new SqlCommand("select * from accounts where username=@username", connection))
        {
            command.Parameters.AddWithValue("@username", UsernameTB.Text);

            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!DateTime.TryParse(reader["account"].ToString().Trim(), out date))
                    {
                        date = DateTime.MinValue;
                    }
                    user = new Models.User(reader["username"].ToString().Trim(),
                        reader["password"].ToString().Trim(),
                        reader["account"].ToString().Trim(),
                        date);
                    user.Email = reader["email"].ToString().Trim();
                    Session["RegistingUser"] = user;
                }
            }
            
            connection.Close();
        }

        if (user != null)
        {
            
            if (user.account.Equals("pending"))
            {
                Label2.Visible = true;
                RegisterCX.Visible = true;
            }
            Label3.Visible = true;
            Date.Visible = true;
            UpdateUser.Visible = true;
        }
    }

    protected void Search_Click(object sender, EventArgs e)
    {
        searchForUser();
    }

    protected void UpdateUser_Click(object sender, EventArgs e)
    {
        string registrated = string.Empty;
        DateTime expDate = DateTime.MinValue;
        string body = "Username: '" + UsernameTB.Text + "'\n";

        Models.User user = Session["RegistingUser"] as Models.User;

        if (RegisterCX.Checked) {
            registrated = "user";
        }
        bool DateEntered = true;
        DateTime datetime;
        if (!DateTime.TryParse(Request.Form[Date.UniqueID], out datetime))
        {
            datetime = DateTime.MinValue;
            DateEntered = false;
        }

        if (user.account.Equals("pending"))
        {
            body += "User is registrated'\n";
        }
        if (DateEntered)
        {
            body += "Date-time expires at " + datetime.ToString();
        }

        try
        {
            SqlCommand command = new SqlCommand("update accounts set account=@account, date=@date where username=@username;", connection);
            connection.Open();

            command.Parameters.AddWithValue("@account", "user");
            command.Parameters.AddWithValue("@date", datetime);
            command.Parameters.AddWithValue("@username", user.username);

            command.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception)
        {

        }
        finally
        {
            SendMail.SendEmail("User Info", body, user.Email);
        }

        
    }
}
