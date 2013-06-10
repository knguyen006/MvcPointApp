using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerService
{
    interface IAccountSvc
    {
        int SelectCount(string txtname, string txtpass);
        void Logon(string txtname, string txtpass);
        void Register();
    }
}
