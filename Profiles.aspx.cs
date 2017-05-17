﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Profiles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        username.InnerHtml = "<font size='20em;'>" + Page.User.Identity.Name + "</font>";
    }
    protected void userLogout(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("Home.aspx");
    }
}