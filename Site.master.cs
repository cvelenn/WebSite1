using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Models.User user = Session["user"] as Models.User;
        if (user == null || !user.CanChangeTips())
        {
            var menu = FindControl("NavigationMenu");
            foreach (MenuItem menuItem in (menu as Menu).Items) 
            {
                if (menuItem.Value.Equals("InsertTip"))
                {
                    (menu as Menu).Items.Remove(menuItem);
                    break;
                }
            }
            foreach (MenuItem menuItem in (menu as Menu).Items)
            {
                if (menuItem.Value.Equals("UpdateUserStatus"))
                {
                    (menu as Menu).Items.Remove(menuItem);
                    break;
                }
            }
        }
    }

}
