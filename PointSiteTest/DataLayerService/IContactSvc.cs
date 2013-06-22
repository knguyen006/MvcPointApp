using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public interface IContactSvc : IService
    {
        void addContact(contact con);
        contact GetAll(int id);
        void editContact(contact con);
        void deleteContact(contact con);
    }
}
