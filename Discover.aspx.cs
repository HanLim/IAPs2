using System;
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
    protected void Page_Load(object sender, EventArgs e)
    {
        string ConnStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection newCon = new SqlConnection(ConnStr))
        {
            SqlCommand newCmd = new SqlCommand("Select * from Phones", newCon);

           
            newCon.Open();
            SqlDataReader rdr = newCmd.ExecuteReader();

            while (rdr.Read())
            {
                //shop.InnerHtml += rdr.GetDecimal(rdr.GetOrdinal("price")).ToString();
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.InnerText = rdr.GetDecimal(rdr.GetOrdinal("price")).ToString();
                div.Attributes.Add("class", "items");
                shopContainer.Controls.Add(div);
            }
            newCon.Close();
        }

    }
    void myLnkBtn_Click(object sender, EventArgs e)
    {
        
    }
}