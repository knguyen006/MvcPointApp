﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public interface ISignupSvc : IService
    {
        void addSignup(signup sign);
        signup GetById(int id);
        List<signup> GetAll();
        void editSignup(signup sign);
        void deleteSignup(signup sign);
    }
}