using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PointSiteTest
{
    public partial class LoginTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["PointAppDBContainer"].ConnectionString;
        }

        private void ExecuteInsert(string username, string userpassword, string passphrase, string membertype)
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            string sql = "INSERT INTO member (username, userpassword, passphrase, membertype, approleid) VALUES "
                + "(@username, @userpassword, @passphrase, @membertype, 2)";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@username", SqlDbType.VarChar, 30);
                param[1] = new SqlParameter("@userpass", SqlDbType.VarChar, 32);
                param[2] = new SqlParameter("@passphrase", SqlDbType.VarChar, 50);
                param[3] = new SqlParameter("@membertype", SqlDbType.VarChar, 10);

                param[0].Value = username;
                param[1].Value = userpassword;
                param[2].Value = passphrase;
                param[3].Value = membertype;

                for (int i = 0; i < param.Length; i++)
                {
                    cmd.Parameters.Add(param[i]);
                }

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error: ";
                msg += ex.Message;
                throw new Exception(msg);
            }

            finally
            {
                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (userpassword.Text == reuserpass.Text)
            {
                ExecuteInsert(username.Text,
                              userpassword.Text,
                              passphrase.Text,
                              DropDownList1.SelectedItem.Text);
                Response.Write("Record was successfully added!");
                ClearControls(Page);
            }
            else
            {
                Response.Write("Password did not match");
                userpassword.Focus();
            }
        }

        public static void ClearControls(Control Parent)
        {
            if (Parent is TextBox)
            {
                (Parent as TextBox).Text = string.Empty;
            }
            else
            {
                foreach (Control c in Parent.Controls)
                    ClearControls(c);
            }
        }
    }
}