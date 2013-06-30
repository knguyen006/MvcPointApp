using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public interface IProfileSvc : IService
    {
        void addProfile(profile pro);
        profile GetById(int id);
        List<profile> GetAll();
        void editProfile(profile pro);
        void deleteProfile(profile pro);
        
    }
}
