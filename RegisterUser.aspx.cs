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

public partial class RegisterUser : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["kladionicaConnectionString1"].ConnectionString);
    private string toEmail = ConfigurationManager.AppSettings["toemailaddress"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        FullNameMessage.Text = string.Empty;
        UsernameMessage.Text = string.Empty;
        PasswordMessage.Text = string.Empty;
        EmailMessage.Text = string.Empty;
        ConfirmPasswordMessage.Text = string.Empty;
        ConditionsMessage.Text = string.Empty;
    }

    private bool checkBasicFieldInformation()
    {
        bool fieldCondition = true;

        if (!Conditions.Checked)
        {
            ConditionsMessage.Text = "User must accept conditions";
            fieldCondition = false;
        }
        if (string.IsNullOrEmpty(FullName.Text))
        {
            FullNameMessage.Text = "Empty field";
            fieldCondition = false;
        }
        if (string.IsNullOrEmpty(UserName.Text))
        {
            UsernameMessage.Text = "Empty field";
            fieldCondition = false;
        }
        if (string.IsNullOrEmpty(Password.Text))
        {
            PasswordMessage.Text = "Empty field";
            fieldCondition = false;
        }
        if (string.IsNullOrEmpty(ConfirmPassword.Text))
        {
            ConfirmPasswordMessage.Text = "Empty field";
            fieldCondition = false;
        }
        if (string.IsNullOrEmpty(Email.Text))
        {
            EmailMessage.Text = "Empty field";
            fieldCondition = false;
        }
        if (!ConfirmPassword.Text.Equals(Password.Text))
        {
            ConfirmPasswordMessage.Text = "Password was not the same";
            fieldCondition = false;
        }

        return fieldCondition;
    }

    private bool checkIfDataAlreadyExists() 
    {
        
        DateTime date = DateTime.MinValue;
        using (SqlCommand command = new SqlCommand("select * from accounts where username=@username or email=@email", connection))
        {
            command.Parameters.AddWithValue("@username", UserName.Text);
            command.Parameters.AddWithValue("@email", Email.Text);

            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader["username"].ToString().Trim().Equals(UserName.Text))
                    {
                        UsernameMessage.Text = "Choose another username";
                        connection.Close();
                        return false;
                    }

                    if (reader["email"].ToString().Trim().Equals(Email.Text))
                    {
                        EmailMessage.Text = "Email already in use";
                        connection.Close();
                        return false;
                    }
                    
                }
            }
            connection.Close();
        }
        return true;
    }

    private void InsertRegistration()
    {
        SqlCommand command = new SqlCommand("insert into accounts (username, fullname, password, email, account) values (@username, @fullname, @password, @email, @account)", connection);

        command.Parameters.AddWithValue("@username", UserName.Text);
        command.Parameters.AddWithValue("@fullname", FullName.Text);
        command.Parameters.AddWithValue("@password", Password.Text);
        command.Parameters.AddWithValue("@email", Email.Text);
        command.Parameters.AddWithValue("@account", "pending");
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!checkBasicFieldInformation())
        {
            return;
        }
        if (!checkIfDataAlreadyExists())
        {
            return;
        }

        InsertRegistration();
        string body = "Username: '" + UserName.Text + "'\n";
        body += "Email: " + Email.Text + "\n";
        body += "Full Name: " + FullName.Text + "\n";

        SendMail.SendEmail("New User", body, toEmail);

        Response.Redirect("PendingRegistration.aspx");
    }

}
