using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public interface ILoginSvc : IService
    {
        List<member> GetAccount(member mem);
        //bool UserIsValid(string nuser, string npass);
    }
}
