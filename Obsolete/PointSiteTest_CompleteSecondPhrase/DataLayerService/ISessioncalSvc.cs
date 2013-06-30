using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public interface ISessioncalSvc : IService
    {
        void addSessioncal(sessioncal cal);
        sessioncal GetById(int id);
        List<sessioncal> GetAll();
        void editSessioncal(sessioncal cal);
        void deleteSessioncal(sessioncal cal);
    }
}
