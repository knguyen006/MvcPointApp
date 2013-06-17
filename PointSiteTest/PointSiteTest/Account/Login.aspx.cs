using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PointSiteTest.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cancelBtn.Click += new EventHandler(this.cancelBtn_Click);
            logonBtn.Click += new EventHandler(this.logonBtn_Click);
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }

        private bool memberAuthentication(string username, string password)
        {
            if (username == null && password == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        protected void logonBtn_Click(object sender, EventArgs e)
        {
            string txtusername;
            string txtpassword;
            bool isValid = false;

            txtusername = username.Text;
            txtpassword = password.Text;

            isValid = memberAuthentication(txtusername, txtpassword);

            if (isValid == false)
            {
                warninglbl.Text = "The username/password is incorrect!";
            }
            else
            {
                //warninglbl.Text = "The username/password is incorrect!" + isValid;
                Response.Redirect("/Welcome.aspx");
            }
               
        }

        private void OnAuthenticate(object sender, AuthenticateEventArgs e)
        {
            bool Authenticated = false;
            //Authenticated = memberAuthentication(Login.username, Login.password);

            e.Authenticated = Authenticated;
}
    }
}