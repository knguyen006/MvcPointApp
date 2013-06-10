using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using System.Data.SqlClient;
using System.Web;

namespace DataLayerService
{
    class AccountSvcImpl
    {
        public int SelectCount(string txtname, string txtpass)
        {
            int nCount = 0;

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) "
                          + "FROM member where username='"
                          + txtname + "' and password='" + txtpass + "'");

            try
            {
                nCount = (int)cmd.ExecuteScalar();
            }
            catch 
            {
                throw new ArgumentException("The account is not exist!");
            }

            return nCount;
        }
        public void Logon(string txtname, string txtpass)
        {
            int nMember = 0;

            nMember = SelectCount(txtname, txtpass);

            if (nMember > 0)
            {
                
            }
            else
            {
                throw new Exception("Login Incorrect!");
            }

        }

        public void Register()
        {
        }
    }
}
