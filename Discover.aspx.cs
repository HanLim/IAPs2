using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Discover : System.Web.UI.Page
{
    public int count = 0;
    ArrayList itemInCart = new ArrayList();
    
    void addToCart(object sender, CommandEventArgs e)
    {
        
        itemInCart.Add(e.CommandArgument.ToString());
        Session["cart"] = itemInCart;
        cart.Text = "Cart(" + itemInCart.Count.ToString() + ")";
        Response.Redirect(Request.Url.AbsolutePath);

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        bool loggedIn = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
        if (Session["cart"] != null && loggedIn)
        {
            itemInCart = (ArrayList)System.Web.HttpContext.Current.Session["cart"];
            cart.Text = "Cart("+itemInCart.Count.ToString()+")";
        }
        

        string ConnStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection newCon = new SqlConnection(ConnStr))
        {
            SqlCommand newCmd = new SqlCommand("Select * from Phones", newCon);


            newCon.Open();
            SqlDataReader rdr = newCmd.ExecuteReader();

            while (rdr.Read())
            {

                HtmlGenericControl items = new HtmlGenericControl("div");
                HtmlGenericControl detailContainer = new HtmlGenericControl("div");

                HtmlGenericControl itemName = new HtmlGenericControl("p");
                HtmlGenericControl divider = new HtmlGenericControl("p");
                HtmlGenericControl price = new HtmlGenericControl("p");

                Button itemAdd = new Button();
                HtmlGenericControl itemImg = new HtmlGenericControl("img");

                items.Attributes.Add("class", "items");
                detailContainer.Attributes.Add("class", "detailContainer");

                itemName.Attributes.Add("class", "itemName");
                itemName.InnerHtml = rdr.GetString(rdr.GetOrdinal("itemName")).ToString();
                divider.Attributes.Add("class", "divider");
                divider.InnerHtml = "|";
                price.Attributes.Add("class", "price");
                price.InnerHtml = "RM" + rdr.GetDecimal(rdr.GetOrdinal("price")).ToString();

                itemAdd.Attributes.Add("class", "itemAdd");
                itemAdd.Text = "Add To Cart";
                itemAdd.CommandArgument = rdr.GetString(rdr.GetOrdinal("itemName")).ToString();
                itemAdd.Command += addToCart;
                itemAdd.UseSubmitBehavior = false;

                itemImg.Attributes.Add("class", "itemImg");
                itemImg.Attributes.Add("src", rdr.GetString(rdr.GetOrdinal("imgLink")).ToString());

                //shop.InnerHtml += rdr.GetDecimal(rdr.GetOrdinal("price")).ToString();
                //div.InnerText = rdr.GetDecimal(rdr.GetOrdinal("price")).ToString();
                
                if (!loggedIn)
                {
                    itemAdd.Attributes.Add("style", "cursor: not-allowed");
                    itemAdd.Attributes.Add("onclick", "return false;");

                    cart.Attributes.Add("style", "cursor: not-allowed");
                    cart.Attributes.Add("onclick", "return false;");
                }
                items.Controls.Add(itemImg);
                detailContainer.Controls.Add(itemName);
                detailContainer.Controls.Add(divider);
                detailContainer.Controls.Add(price);
                items.Controls.Add(detailContainer);
                items.Controls.Add(itemAdd);
                shopContainer.Controls.Add(items);
            }
            newCon.Close();
        }

    }


    protected void cart_Click(object sender, EventArgs e)
    {
        Response.Redirect("Cart.aspx");
    }
}