using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public interface IApproleSvc : IService
    {
        void addRole(approle role);
        approle GetById(int id);
        List<approle> GetAll();
        void editRole(approle role);
        void deleteRole(approle role);

        approle GetRole(int id);
        approle GetRole(string name);
    }
}
