using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Cart : System.Web.UI.Page
{
    protected void Pay(object sender, EventArgs e)
    {
        if (cardNum.Text == String.Empty || secCode.Text == String.Empty || address.Text == String.Empty)
        {
            err.InnerHtml = "<font color='#ff5050'>Please fill in all the fields</font>";
        }
        else
        {
            int n;
            bool isNumeric = int.TryParse(secCode.Text.ToString(), out n);

            Regex r = new Regex("^[a-zA-Z0-9]*$");

            if (cardNum.Text.Length !=16 || secCode.Text.Length !=3)
            {
                err.InnerHtml = "<font color='#ff5050'>Invalid Input</font>";
            }
            else if (!isNumeric)
            {
                err.InnerHtml = "<font color='#ff5050'>Wrong security code format</font>";
            }
            else if (r.IsMatch(cardNum.Text.ToString()))
            {
                err.InnerHtml = "<font color='#ff5050'>Wrong card number code</font>";
            }
            else
            {
                string Receipt = "Receipt" + Environment.NewLine;
                ArrayList itemInCart = (ArrayList)System.Web.HttpContext.Current.Session["cart"];
                foreach (var i in itemInCart)
                {
                    Receipt += i.ToString();
                    Receipt += Environment.NewLine;
                    string ConnStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    using (SqlConnection newCon = new SqlConnection(ConnStr))
                    {
                        newCon.Open();
                        var sql = "INSERT INTO PaymentTransaction VALUES (@userName, @itemName)";
                        var cmd = new SqlCommand(sql, newCon);
                        cmd.Parameters.AddWithValue("@userName", SqlDbType.VarChar).Value = Page.User.Identity.Name;
                        cmd.Parameters.AddWithValue("@itemName", SqlDbType.VarChar).Value = i.ToString();
                        cmd.ExecuteNonQuery();
                        newCon.Close();

                    }
                }

                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\" + "a.txt", Receipt);
                downloadLink.Attributes.Add("href", AppDomain.CurrentDomain.BaseDirectory + @"\" + "receipt.txt");
                downloadLink.Attributes.Add("style", "display: block");
                System.IO.File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"\" + "a.txt" + "a.txt");
                Session.Clear();
                Session.Abandon();
            }
        }
    }
    void removeItem(object sender, CommandEventArgs e)
    {
        ArrayList itemInCart = (ArrayList)System.Web.HttpContext.Current.Session["cart"];
        itemInCart.Remove(e.CommandArgument.ToString());
        Session["cart"] = itemInCart;
        Server.Transfer(Request.Url.AbsolutePath);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        bool loggedIn = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
        if (Session["cart"] != null && loggedIn)
        {
            ArrayList itemInCart = (ArrayList)System.Web.HttpContext.Current.Session["cart"];
            foreach(var i in itemInCart)
            {
                HtmlTableRow row = new HtmlTableRow();
                HtmlTableCell cell = new HtmlTableCell();
                HtmlTableCell remove = new HtmlTableCell();
                Button removebtn = new Button();
                removebtn.Text = "Remove";
                removebtn.Attributes.Add("type", "button");
                removebtn.Attributes.Add("value", "remove");
                removebtn.UseSubmitBehavior = false;
                removebtn.CommandArgument = i.ToString();
                removebtn.Command += removeItem;
                cell.InnerHtml = i.ToString();
                remove.Controls.Add(removebtn);
                row.Cells.Add(cell);
                row.Cells.Add(remove);
                table.Rows.Add(row);
            }
        }
    }
}