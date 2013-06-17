using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PointSiteTest.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cancelBtn.Click += new EventHandler(this.cancelBtn_Click);
            createUserBtn.Click += new EventHandler(this.createuserBtn_Click);
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Default.aspx");
        }

        protected void createuserBtn_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("/Welcome.aspx");
        }

    }
}