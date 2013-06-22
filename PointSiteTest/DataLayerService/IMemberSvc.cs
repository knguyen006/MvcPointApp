using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public interface IMemberSvc : IService
    {
        void addMember(member mem);
        member GetById(int id);
        List<member> GetAll();
        void editMember(member mem);
        void deleteMember(member mem);

        member GetAccount(member mem);
    }
}
