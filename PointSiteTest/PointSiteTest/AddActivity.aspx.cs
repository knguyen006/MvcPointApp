using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;

namespace PointSiteTest
{
    public partial class AddActivity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Activity.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == string.Empty)
            {
                Label1.Text = "Please enter proper details first";
                return;
            }

            Activity txtdb = new Activity();
            txtdb.actname = TextBox1.Text;
            /*
            PointAppDBContainer db = new PointAppDBContainer();
            db.activities.AddObject(txtdb);
            if (db.SaveChanges() == 1)
            {
                Label1.Text = "Contact added Successfully";
            }
             */
        }
    }
}