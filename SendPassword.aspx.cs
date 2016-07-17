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

public partial class SendPassword : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["kladionicaConnectionString1"].ConnectionString);
    private string toEmail = ConfigurationManager.AppSettings["toemailaddress"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        UsernameMessage.Text = string.Empty;

    }


    private Models.User getUser() 
    {
        Models.User user = null;
        DateTime date = DateTime.MinValue;
        using (SqlCommand command = new SqlCommand("select * from accounts where username=@username", connection))
        {
            command.Parameters.AddWithValue("@username", UserName.Text);

            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    user = new Models.User(reader["username"].ToString().Trim(),
                        reader["password"].ToString().Trim(),
                        reader["account"].ToString().Trim(),
                        date);
                    user.Email = reader["email"].ToString().Trim();
                    return user;
                    
                }
            }
            connection.Close();
        }
        return user;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Models.User user = getUser();
        if (user != null)
        {
            string body = "Username: '" + UserName.Text + "'\n";
            body += "Password: " + user.password + "\n";

            SendMail.SendEmail("Password", body, user.Email);

            Response.Redirect("Default.aspx");
        }
        else 
        {
            UsernameMessage.Text = "User with username: " + UserName.Text + " does not exist.";
        }
    }

}
