using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using System.Configuration;

namespace DataLayerService
{
    public class PointAppSvcFactory_OLD
    {
        private PointAppDBContainer db = new PointAppDBContainer();
        /*
        private IActivitySvc actSvc;
        private IStudentSvc studentSvc;
        private IContactSvc contactSvc;
        private IMemberSvc memberSvc;
        private IAppRoleSvc approleSvc;
        private ISessionCalSvc sessioncalSvc;
        private ISessionTypeSvc sessiontypeSvc;
        private ISignUpSvc signupSvc;
        private IFeeRequestSvc feerequestSvc;
        private IContactEmailSvc contactemailSvc;

        public IActivitySvc GetActivitySvc
        {
            get
            {
                return actSvc ?? (actSvc = new ActivitySvcImpl(db));
            }
        }

        public IStudentSvc GetStudentSvc
        {
            get
            {
                return studentSvc ?? (studentSvc = new StudentSvcImpl(db));
            }
        }

        public IMemberSvc GetMemberSvc
        {
            get
            {
                return memberSvc ?? (memberSvc = new MemberSvcImpl(db));
            }
        }

        public IAppRoleSvc GetAppRoleSvc
        {
            get
            {
                return approleSvc ?? (approleSvc = new AppRoleSvcImpl(db));
            }
        }

        public ISignUpSvc GetSignUpSvc
        {
            get
            {
                return signupSvc ?? (signupSvc = new SignUpSvcImpl(db));
            }
        }

        public ISessionCalSvc GetSessionCalSvc
        {
            get
            {
                return sessioncalSvc ?? (sessioncalSvc = new SessionCalSvcImpl(db));
            }
        }

        public ISessionTypeSvc GetSessionTypeSvc
        {
            get
            {
                return sessiontypeSvc ?? (sessiontypeSvc = new SessionTypeSvcImpl(db));
            }
        }

        public IContactSvc GetContactSvc
        {
            get
            {
                return contactSvc ?? (contactSvc = new ContactSvcImpl(db));
            }
        }

        public IContactEmailSvc GetContactEmailSvc
        {
            get
            {
                return contactemailSvc ?? (contactemailSvc = new ContactEmailSvcImpl(db));
            }
        }

        public IFeeRequestSvc GetFeeRequestSvc
        {
            get
            {
                return feerequestSvc ?? (feerequestSvc = new FeeRequestSvcImpl(db));
            }
        }
         * */
    }
}

