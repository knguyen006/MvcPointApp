using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ApproleHelp
    {
        public void Main(string[] args)
        {
        }

        public string addName(string newrole)
        {
            return newrole;
        }

        public string addNote(string newnote)
        {
            return newnote;
        }

        public approle getID(int newID)
        {
            PointAppDBContainer db = new PointAppDBContainer();
            var data = from item in db.approles
                       where item.approleid == newID
                       select item;
            return data.SingleOrDefault();
        }

        
    }
}
