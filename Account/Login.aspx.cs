using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

public partial class Account_Login : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["kladionicaConnectionString1"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
       // RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        string username = LoginUser.UserName;
        string password = LoginUser.Password;
        Models.User user = null;
        using (SqlCommand command = new SqlCommand("select * from accounts where username='" +  username + "' and password='" + password + "'", connection))
        {
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    user = new Models.User(reader["username"].ToString().Trim(),
                        reader["password"].ToString().Trim(),
                        reader["account"].ToString().Trim());
                    break;
                }
            }
        }

        if (user != null) {
            Session["user"] = user;
            FormsAuthentication.SetAuthCookie(username.ToString(), false);
            Response.Redirect("..\\Default.aspx");
        }
    }
}
