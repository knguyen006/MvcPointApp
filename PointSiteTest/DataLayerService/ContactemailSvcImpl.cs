﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public class ContactemailSvcImpl: Repository<contactemail>, IContactemailSvc
    {
        public ContactemailSvcImpl(PointAppDBContext context)
            : base(context)
        {
        }
    }
}