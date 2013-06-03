using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataLayer
{
    class MemberService
    {
        public bool IsUserValid(string username, string userpass)
        {
            var db = new PointAppDBContainer();
            //var user = db.GetUser(username, userpasword);

            //return (user != null);
            return true;
        }
    }
}
