using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public interface ISessiontypeSvc : IService
    {
        void addSessiontype(sessiontype type);
        sessiontype GetById(int id);
        List<sessiontype> GetAll();
        void editSessiontype(sessiontype type);
        void deleteSessiontype(sessiontype type);
    }
}
