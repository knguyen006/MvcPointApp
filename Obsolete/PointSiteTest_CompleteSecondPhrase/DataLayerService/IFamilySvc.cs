using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public interface IFamilySvc : IService
    {
        void addName(family fam);
        family GetById(int id);
        List<family> GetAll();
        void editName(family fam);
        void deleteName(family fam);
        
    }
}
