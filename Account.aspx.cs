using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Net.Mail;
using System.Net;
using System.Text;

public partial class Account : System.Web.UI.Page
{
    private static Random random = new Random();
    private string RandomString(int Size)
    {
        string input = "abcdefghijklmnopqrstuvwxyz0123456789";
        StringBuilder builder = new StringBuilder();
        char ch;
        for (int i = 0; i < Size; i++)
        {
            ch = input[random.Next(0, input.Length)];
            builder.Append(ch);
        }
        return builder.ToString();
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ValidateUser(object sender, EventArgs e)
    {
        int userId = 0;
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("Validate_User"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", loginUserName.Text);
                cmd.Parameters.AddWithValue("@Password", loginPWInput.Text);
                cmd.Connection = con;
                con.Open();
                userId = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            switch (userId)
            {
                case -1:
                    err1.InnerHtml = "Not activated";
                    break;
                case -2:
                    err1.InnerHtml = "Invalid Credential";
                    break;
                default:
                    FormsAuthentication.SetAuthCookie(loginUserName.Text, true);
                    Response.Redirect("Home.aspx");
                    break;
            }
        }

    }
    protected void RegisterUser(object sender, EventArgs e)
    {
        if (signupEmailInput.Text == String.Empty || signupEmailInput.Text == String.Empty || signupPWInput.Text == String.Empty || signupPWInput2.Text == String.Empty)
        {
            err2.InnerHtml = "<font color='#ff5050'>Please fill in all the fields</font>";
        }
        else
        {
            if (signupPWInput.Text.Length < 8 || signupPWInput.Text.Length > 12)
            {
                err2.InnerHtml = "<font color='#ff5050'>Password must consists of 8 - 12 characters</font>";
            }
            else if (signupPWInput.Text != signupPWInput2.Text)
            {
                err2.InnerHtml = "<font color='#ff5050'>Password confirmation does not match password input</font>";
            }
            else
            {
                err2.InnerHtml = "";
                int userId = 0;
                String token = RandomString(15).Trim();
                string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {

                    using (SqlCommand cmd = new SqlCommand("Insert_User"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Username", signupUserName.Text.Trim());
                            cmd.Parameters.AddWithValue("@Password", signupPWInput.Text.Trim());
                            cmd.Parameters.AddWithValue("@Email", signupEmailInput.Text.Trim());
                            cmd.Parameters.AddWithValue("@verificationToken", token.Trim());
                            cmd.Connection = con;
                            con.Open();
                            userId = Convert.ToInt32(cmd.ExecuteScalar());

                            con.Close();
                        }
                    }
                    string message = string.Empty;
                    switch (userId)
                    {
                        case -1:
                            err2.InnerHtml = "<font color='#ff5050'>Username used</font>";
                            break;
                        case -2:
                            err2.InnerHtml = "<font color='#ff5050'>Email used</font>";
                            break;
                        default:
                            err2.InnerHtml = "Registered";
                            using (var client = new SmtpClient("smtp.gmail.com", 587)
                            {
                                Credentials = new NetworkCredential("dummyAccForIap@gmail.com", "dummyAccForIap12"),
                                EnableSsl = true
                            })
                            {
                                MailMessage msg = new MailMessage("dummyAccForIap@gmail.com",
                        "choohanlim96@gmail.com", "Account Verification", "Please go to the following URL to activate your account. " + Request.Url.Authority + "/Verification.aspx?username=" + signupUserName.Text + "&token=" + token);

                                msg.IsBodyHtml = true;
                                client.Send(msg);
                            }
                            break;
                    }
                }
            }
        }
    }
}