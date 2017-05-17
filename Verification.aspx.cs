using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Verification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string username = Request.QueryString["username"].Trim();
        string token = Request.QueryString["token"].Trim();

        int result;
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {

            using (SqlCommand cmd = new SqlCommand("Verify_User"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@token", token);
                    cmd.Connection = con;
                    con.Open();
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    switch (result)
                    {
                        case 1:
                            msg.InnerHtml = "Successfully Validated";
                            break;
                        case -1:
                            msg.InnerHtml = "Invalid Verification";
                            break;
                    }
                }
            }
        }
    }
}