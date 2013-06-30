using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace DataLayerService
{
    public class MemberSvcImpl : IMemberSvc
    {
        PointAppDBContext db = new PointAppDBContext();

        public void addMember(member mem)
        {
            try
            {
                using (var dbList = new PointAppDBContext())
                {
                    var crypto = new SimpleCrypto.PBKDF2();
                    var encrpPass = crypto.Compute(mem.userpass);
                    var memdb = db.members.Create();

                    memdb.username = mem.username;
                    memdb.userpass = encrpPass;
                    memdb.passsalt = crypto.Salt;
                    //memdb.memberid = Guid.NewGuid();

                    db.members.Add(memdb);
                    db.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                var errors = ex.EntityValidationErrors.First();

                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                /*
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                  {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                      Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName,validationError.ErrorMessage);                 
                    
                    }
                  }
                /*
                var sb = new System.Text.StringBuilder();
                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new Exception(sb.ToString());
                 */
            }
        }

        public member GetById(int id)
        {
            return db.members.Find(id);
        }

        public List<member> GetAll()
        {
            return db.members.ToList();
        }

        public void editMember(member mem)
        {
            var dbList = db.members.Single(p => p.memberid == mem.memberid);

            dbList.username = mem.username;
            dbList.userpass = mem.userpass;
            dbList.passsalt = mem.passsalt;

            db.SaveChanges();
        }

        public void deleteMember(member mem)
        {
            db.members.Remove(mem);
            db.SaveChanges();
        }

        public List<member> GetAccount(member mem)
        {
            var logindb = (from d in db.members
                           where d.username.Contains(mem.username)
                           select d);
            return logindb.ToList();
        }

        public bool UserIsValid(string nuser, string npass)
        {
            bool isValid = false;
            var crypto = new SimpleCrypto.PBKDF2();

            using (var db = new PointAppDBContext())
            {
                var mem = db.members.FirstOrDefault(u => u.username == nuser);
                if (mem != null)
                {
                    if (mem.userpass == crypto.Compute(npass, mem.passsalt))
                    {
                        isValid = true;
                    }
                }
            }
            return isValid;
        }

        public member GetAdminUser()
        {
            return db.members.SingleOrDefault(mem => mem.username == "adminuser");
        }

    }
}
