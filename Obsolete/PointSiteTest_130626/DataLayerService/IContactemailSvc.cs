using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public interface IContactemailSvc : IService
    {
        void addEmail(contactemail email);
        contactemail GetById(int id);
        List<contactemail> GetAll();
        void editEmail(contactemail email);
        void deleteEmail(contactemail email);
    }
}
