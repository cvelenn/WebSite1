﻿using System;
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

public partial class ContactUs : System.Web.UI.Page
{
    private string email = ConfigurationManager.AppSettings["emailaddress"].ToString();  
    protected void Page_Load(object sender, EventArgs e)
    {
        UsernameMessage.Text = string.Empty;

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string mail = UserName.Text;
        if (!string.IsNullOrWhiteSpace(mail))
        {
            string body = "Question from: '" + UserName.Text + "'\n";

            body += "Question: " + Request.Form["S1"] + "\n";

            SendMail.SendEmail("Question", body, mail);

            Response.Redirect("Default.aspx");
        }
        else 
        {
            UsernameMessage.Text = "Must enter email address.";
        }
    }

}
