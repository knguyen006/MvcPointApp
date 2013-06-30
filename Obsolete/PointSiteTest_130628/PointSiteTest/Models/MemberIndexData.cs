using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;

namespace PointSiteTest.Models
{
    public class MemberIndexData
    {
        public IEnumerable<member> members { get; set; }
        public IEnumerable<profile> profiles { get; set; }
        public IEnumerable<student> students { get; set; }
        public IEnumerable<activity> activities { get; set; }
        public IEnumerable<feerequest> feerequests { get; set; }
        public IEnumerable<signup> signups { get; set; }
    }
}