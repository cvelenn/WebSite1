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
    private string email = ConfigurationManager.AppSettings["emailaddress"].ToString();
    private string toEmail = ConfigurationManager.AppSettings["toemailaddress"].ToString();
    private string emailpassword = ConfigurationManager.AppSettings["emailpassword"].ToString();
    private string smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
    private string smtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();

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

    private void sendEmail() 
    {

        string subject = "New User";
        string body = "Username: '" + UserName.Text + "'\n";
        body += "Email: " + Email.Text + "\n";
        body += "Full Name: " + FullName.Text + "\n";
        //https://www.google.com/settings/security/lesssecureapps?rfn=27&rfnc=1&asae=2&anexp=lbe-R1_A
        // smtp settings
        var smtp = new System.Net.Mail.SmtpClient();
        {
            smtp.Host = smtpHost;
            smtp.Port = int.Parse(smtpPort);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(email, emailpassword);
            smtp.Timeout = 20000;
        }
        // Passing values to smtp object
        smtp.Send(email, toEmail, subject, body); 

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
        sendEmail();

        Response.Redirect("PendingRegistration.aspx");
    }

}
