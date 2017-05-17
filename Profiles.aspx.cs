using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Profiles : System.Web.UI.Page
{
    protected void changepw(object sender, EventArgs e)
    {
        if(oldpw.Text == String.Empty || pw.Text == String.Empty || pw2.Text == String.Empty)
        {
            err.InnerHtml = "<font color='#ff5050'>Please fill in all the fields</font>";
        }
        else if (pw.Text != pw2.Text)
        {
            err.InnerHtml = "<font color='#ff5050'>Password confirmation does not match password input</font>";
        }
        else if (pw.Text.Length < 8 || pw.Text.Length > 12)
        {
            err.InnerHtml = "<font color='#ff5050'>Password must consists of 8 - 12 characters</font>";
        }
        else
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Change_PW"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@oldpw", oldpw.Text.Trim());
                        cmd.Parameters.AddWithValue("@pw", oldpw.Text.Trim());
                        cmd.Parameters.AddWithValue("@username", Page.User.Identity.Name.Trim());
                        cmd.Connection = con;
                        con.Open();

                        con.Close();
                    }
                }
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        bool loggedIn = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
        if (loggedIn)
        {
            username.InnerHtml = "<font size='20em;'>" + Page.User.Identity.Name + "</font>";
        }
        else
        {
            Response.Redirect("Account.aspx");
        }
    }
    protected void userLogout(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        FormsAuthentication.SignOut();
        Response.Redirect("Home.aspx");
    }
}