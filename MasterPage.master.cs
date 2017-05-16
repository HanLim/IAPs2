using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    bool loggedIn = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (loggedIn)
        {
            account.Text = "Profile";
        }
        else
        {
            account.Text = "Account";
        }
    }

    protected void checkLogIn(object sender, EventArgs e)
    {
        
        if (loggedIn)
        {
            Response.Redirect("Profiles.aspx", true);
        }
        else
        {
            Response.Redirect("Account.aspx", true);
        }
    }
}
