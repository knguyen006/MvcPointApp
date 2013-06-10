using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Entity;

namespace PointSiteTest
{
    public partial class Login : System.Web.UI.Page
    {
        PointAppDBContainer db = new PointAppDBContainer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /*
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string txtuser, txtpass;

            txtuser = username.Text.ToString();
            txtpass = userpass.Text.ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionString["PointAppDBContainer"].ConnectionString))
            }
            catch
            {
                throw new ArgumentException("Invalid Account!");
            }
        }
         * */

        private bool IsvalidUser(string txtuser, string txtpass)
        {
            PointAppDBContainer db = new PointAppDBContainer();

            var query = from m in db.members
                        where m.username == txtuser
                        && m.userpass == txtpass
                        select m;

            if (query.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void ValidateLogin(string txtuser, string txtpass)
        {
            try
            {
                bool loginValid;

                loginValid = IsvalidUser(txtuser, txtpass);

                if (loginValid == true)
                {
                    Response.Redirect("Welcome.aspx");
                }
                else
                {
                    lblWarning.Text = "ERROR - Login Id and Password doesn't match.Please try again!";
                }
            }
            catch
            {
                throw new ArgumentException("Invalide Login page");
            }
        }
        
    }
}