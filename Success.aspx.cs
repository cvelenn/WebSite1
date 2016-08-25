using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Success : System.Web.UI.Page
{
    private string toEmail = ConfigurationManager.AppSettings["toemailaddress"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {

        Models.User user = Session["user"] as Models.User;
        if (user != null)
        {
            string body = "Username: '" + user.username + "'\n";
            body += "Email: " + user.Email + "\n";
            body += "User has made payment. " + "\n";
            if (Session["ammount"] != null) {
                body += Session["ammount"].ToString();
                Session["ammount"] = null;
            }
            SendMail.SendEmail("New payment", body, toEmail);
        }
        
    }

}
