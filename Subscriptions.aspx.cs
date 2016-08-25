using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Subscriptions : System.Web.UI.Page
{
    private string url = ConfigurationManager.AppSettings["url"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {
        Models.User user = Session["user"] as Models.User;
        if (user == null)
        {
            ImageButton1.Visible = false;
            RadioButton1.Enabled = false;
            RadioButton2.Enabled = false;
            RadioButton3.Enabled = false;
            RadioButton4.Enabled = false;
        }
        else
        {
            ImageButton1.Visible = true;
            RadioButton1.Enabled = true;
            RadioButton2.Enabled = true;
            RadioButton3.Enabled = true;
            RadioButton4.Enabled = true;
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        int ammount = 59;
        string option = "1 month";
        if (RadioButton2.Checked)
        {
            ammount = 159;
            option = "3 months";
        }
        else if (RadioButton3.Checked)
        {
            ammount = 279;
            option = "6 months";
        }
        else if (RadioButton4.Checked)
        {
            ammount = 499;
            option = "12 months";
        }
        Session["ammount"] = ammount;
        Response.Redirect("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&business=support@betting-portfolio.com&item_name=" + option + "&amount=" + ammount + "&currency_code=EUR&return=" + url + "/Success.aspx&cancel_return=" + url + "/Failed.aspx");
    }
}
