using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using DataLayer;
using System.Data;

namespace PointSiteTest
{
    public partial class Logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool ValidateUser (string userName, string userPass) {
            SqlConnection conn;
            SqlCommand cmd;
            string lookupPass = null;

            // Check for invalid username
            if((null == userName) || (0 == userName.Length) || (userName.Length > 0))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed." );
		        return false;
	        }

	        // Check for invalid userPass.
	        // userPass must not be null and must be between 1 and 25 characters.
	        if ( (  null == userPass ) || ( 0 == userPass.Length ) || ( userPass.Length > 25 ) )
	        {
		        System.Diagnostics.Trace.WriteLine( "[ValidateUser] Input validation of userPass failed." );
		        return false;
	        }

	        try
	        {
		        // Consult with your SQL Server administrator for an appropriate connection
		        // string to use to connect to your local SQL Server.
		        conn = new SqlConnection( "server=localhost;Integrated Security=SSPI;database=pubs" );
		        conn.Open();

		        // Create SqlCommand to select pwd field from users table given supplied userName.
		        cmd = new SqlCommand( "Select userpass from member where username=@userName", conn );
		        cmd.Parameters.Add( "@userName", SqlDbType.VarChar, 25 );
		        cmd.Parameters["@userName"].Value = userName;

		        // Execute command and fetch pwd field into lookupPass string.
		        lookupPass = (string) cmd.ExecuteScalar();

		        // Cleanup command and connection objects.
		        cmd.Dispose();
		        conn.Dispose();
	        }
	        catch ( Exception ex )
	        {
		        // Add error handling here for debugging.
		        // This error message should not be sent back to the caller.
		        System.Diagnostics.Trace.WriteLine( "[ValidateUser] Exception " + ex.Message );
	        }

	        // If no userPass found, return false.
	        if ( null == lookupPass ) 
	        {
		        // You could write failed login attempts here to event log for additional security.
		        return false;
	        }

	        // Compare lookupPass and input userPass, using a case-sensitive comparison.
	        return ( 0 == string.Compare( lookupPass, userPass, false ) );
        }

        private void cmdLogin_ServerClick(object sender, System.EventArgs e)
        {
            if (ValidateUser(txtUsername.Value, txtUserpass.Value))
            {
                FormsAuthenticationTicket tkt;
                string cookiestr;
                HttpCookie ck;
                tkt = new FormsAuthenticationTicket(1, txtUsername.Value, DateTime.Now,
          DateTime.Now.AddMinutes(30), chkPersistCookie.Checked, "your custom data");
                cookiestr = FormsAuthentication.Encrypt(tkt);
                ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                if (chkPersistCookie.Checked)
                    ck.Expires = tkt.Expiration;
                ck.Path = FormsAuthentication.FormsCookiePath;
                Response.Cookies.Add(ck);

                string strRedirect;
                strRedirect = Request["ReturnUrl"];
                if (strRedirect == null)
                    strRedirect = "default.aspx";
                Response.Redirect(strRedirect, true);
            }
            else
                Response.Redirect("logon.aspx", true);
        }
    }
}