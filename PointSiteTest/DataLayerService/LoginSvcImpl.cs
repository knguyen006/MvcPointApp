using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public class LoginSvcImpl : ILoginSvc
    {
        PointAppDBContext db = new PointAppDBContext();

        public List<member> GetAccount(member mem)
        {
            using (var db = new PointAppDBContext())
            {
                var loginList = (from m in db.members
                                 where m.username == mem.username &&
                                       m.userpass == mem.userpass
                                 select m);

                return loginList.ToList();
            }
        }

        /*
        private bool UserIsValid(string nuser, string npass)
        {
            bool isValid = false;

            using (var db = new PointAppDBContext())
            {
                var mem = db.members.FirstOrDefault(u => u.username == nuser);
                if (mem != null)
                {
                    if (mem.userpass != null)
                    {
                        isValid = true;
                    }
                }
            }
            return isValid;
        }
         * */
    }
}
