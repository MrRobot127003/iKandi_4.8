using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using iKandi.DAL;
using System.Web.Security;

namespace iKandi.BLL
{
    public class PartnerController : BaseController
    {
        #region Ctor

        public PartnerController()
        {
        }

        public PartnerController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Partner Methods

        public Partner SavePartner(Partner objPartner)
        {
            MembershipUser mUser;
            User InternalUser = new User();

            if (objPartner.PartnerID == -1)
            {
               //Add Logic to create user
                string password = Membership.GeneratePassword(6, 0);
                string PasswordQuestion = "Company Name";
                string PasswordAnswer = "Boutiqe";
                MembershipCreateStatus status;
                mUser = Membership.CreateUser(objPartner.UserName, password, objPartner.UserName, PasswordQuestion, PasswordAnswer, true, out status);

                //mUser = Membership.CreateUser(objPartner.UserName, password, objPartner.UserName);
                
                Roles.AddUserToRole(mUser.UserName, Role.Partner.ToString());

                InternalUser.MembershipUserId = mUser.ProviderUserKey.ToString();
                InternalUser.FirstName = objPartner.PartnerName;
                InternalUser.LastName = objPartner.PartnerName;
                InternalUser.ManagerID = -1;
                InternalUser.Company = (iKandi.Common.Company)Convert.ToInt32(-1);
                InternalUser.PhotoPath = "";
                InternalUser.Address = objPartner.Address;
                InternalUser.Phone = objPartner.Phone;
                InternalUser.Mobile = objPartner.Phone;
                InternalUser.PrimaryGroupID = -1;
                InternalUser.DesignationID = -1;
                InternalUser.DesignerCode = "";
                InternalUser.BirthDay = Convert.ToDateTime("1/1/1900");
                InternalUser.Anniversary = Convert.ToDateTime("1/1/1900");
                InternalUser.HomePhone = "";
                InternalUser.PersonalEmail = objPartner.Email;
                InternalUser.iGlobalAcc = 1;

                this.CreateUserProfile(InternalUser);

                UserDetails usd = new UserDetails();
                objPartner.UserID = usd.GetUserId(mUser.UserName);                

                int partnerID = this.PartnerDataProviderInstance.InsertPartner(objPartner);
            }
            else
            {
                this.PartnerDataProviderInstance.UpdatePartner(objPartner);
                
            }
            return objPartner;
        }

        public bool CreateUserProfile(User InternalUser)
        {

            return this.MembershipDataProviderInstance.CreateUserProfile(InternalUser);

        }

        ////public void InsertPartnerClient(PartnerClient objPartnerClient)
        ////{
        ////    this.PartnerDataProviderInstance.InsertPartnerClient(objPartnerClient);
        ////}

        public Partner GetPartner(int Id)
        {
            Partner partner;
            partner =  this.PartnerDataProviderInstance.GetPartner(Id);
            partner.EmailDetails = this.PartnerDataProviderInstance.GetPartnerEmail(Id);
            return partner;
        }

        public List<Partner> GetAllPartner()
        {
            return this.PartnerDataProviderInstance.GetAllPartner();
        }

        public Boolean DeletePartner(int PartnerId)
        {
            return this.PartnerDataProviderInstance.DeletePartner(PartnerId);
        }

        ////public Boolean DeletePartnerClient(int PartnerId)
        ////{
        ////    return this.PartnerDataProviderInstance.DeletePartnerClient(PartnerId);
        ////}

        public List<PartnerEmail> GetPartnerEmail(int PartnerID)
        {
            return this.PartnerDataProviderInstance.GetPartnerEmail(PartnerID);
        }

        public Partner GetPartnerByUserID(int UserID)
        {
            return this.PartnerDataProviderInstance.GetPartnerByUserID(UserID);
        }

        # endregion



    }
}


