using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public interface IActivitySvc : IService
    {
        void addActivity(activity act);
        activity GetById(int id);
        List<activity> GetAll();
        void editActivity(activity act);
        void deleteActivity(activity act);
        
    }
}
