using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool loggedIn = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
        if (loggedIn)
        {
            account.Text = Page.User.Identity.Name;
        }
        else
        {
            account.Text = "Account";
        }
    }

    protected void checkLogIn(object sender, EventArgs e)
    {
        bool loggedIn = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
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
