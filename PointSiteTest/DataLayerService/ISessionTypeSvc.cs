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
        sessiontype GetAll(int id);
        void editSessiontype(sessiontype type);
        void deleteSessiontype(sessiontype type);
    }
}
