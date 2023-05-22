using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.DAL;
using System.Web.Security;
using iKandi.BLL.Security;
using iKandi.Common;
using System.Data;

namespace iKandi.BLL
{
    public class ClientController : BaseController
    {
        #region

        public ClientController()
        {
        }

        public ClientController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public iKandi.Common.Client SaveClient(iKandi.Common.Client ClientUser)
        {
            //MembershipUser mUser;
            User InternalUser = new User();

            if (ClientUser.ClientID == -1)
            {
                int clientID = this.ClientDataProviderInstance.CreateClient(ClientUser);
                StringBuilder sb = new StringBuilder();

                if (clientID > 0)
                {

                    ClientUser.ClientID = clientID;

                    foreach (ClientDepartment cd in ClientUser.Departments)
                    {
                        if (cd.DeptID == -1 && cd.IsDeletedDept == 0)
                        {
                            cd.ClientID = ClientUser.ClientID;
                            this.ClientDataProviderInstance.CreateClientDept(cd);
                        }
                    }

                    //string password = (cd.Name).ToLower().Replace("e","3").Replace(" ","").Replace("i","1").Replace("o","0").Replace("1","@");

                    // //string password = ClientUser.Name.Substring(0, 2) + "@123";
                    //string password = "ikandi@01";
                    //string PasswordQuestion = "Company Name";
                    //string PasswordAnswer = "Boutiqe";
                    // MembershipCreateStatus status;
                    // mUser = Membership.CreateUser(ClientUser.Username, password, cd.Username, PasswordQuestion, PasswordAnswer, true, out status);

                    // if (mUser == null)
                    // {
                    //     GetErrorMessage(status);
                    // }

                    //Roles.AddUserToRole(mUser.UserName, Role.Client.ToString());

                    //InternalUser.MembershipUserId = mUser.ProviderUserKey.ToString();                            
                    //InternalUser.iGlobalAcc = 1;

                    //this.CreateClientUser(InternalUser);

                    //UserDetails usd = new UserDetails();
                    //cd.UserId = usd.GetClientUserId(mUser.UserName);

                    //this.ClientDataProviderInstance.CreateClientDept(cd);
                    //sb.Append("Dept: " + cd.Name + ", Username: " + cd.Username + ", Password: " + password);
                    //sb.AppendLine();
                    //    }
                    //}

                    foreach (ClientContact cc in ClientUser.Contacts)
                    {
                        if (cc.ContactID == -1 && cc.IsDeletedContact == 0)
                        {
                            cc.ClientID = ClientUser.ClientID;
                            this.ClientDataProviderInstance.CreateClientContact(cc);
                        }
                    }

                    //if (sb.Length > 0)
                    //    this.NotificationControllerInstance.SendClientRegistrationEmail(ClientUser.CompanyName, sb.ToString(), this.LoggedInUser.UserData.Email);

                }
            }
            else
            {
                this.ClientDataProviderInstance.UpdateClient(ClientUser);
                StringBuilder sb = new StringBuilder();

                foreach (ClientDepartment cd in ClientUser.Departments)
                {
                    cd.ClientID = ClientUser.ClientID;
                    if (cd.DeptID == -1 && cd.IsDeletedDept == 0)
                    {
                        this.ClientDataProviderInstance.CreateClientDept(cd);
                    }
                   
                    //Code Update on 23-11-2018 for Parent and Sub Department (Delete and Insert)
                    if (cd.IsDeletedDept == 1)
                    {
                        foreach (ClientDepartmentAssociation cda in cd.ClientDepartmentAssociation)
                        {
                            cda.DeptID = cd.DeptID;
                            this.ClientDataProviderInstance.DeleteClientDeptAssociation(cda);
                        }
                        foreach (ClientDepartmentAssociation cda in cd.ClientDepartmentAssociation)
                        {
                            cda.DeptID = cd.ParentId;
                            this.ClientDataProviderInstance.DeleteClientDeptAssociation(cda);
                        }
                        this.ClientDataProviderInstance.DeleteClientDept(cd);
                        
                    }
                    if (cd.DeptID > 0 && cd.IsDeletedDept == 0)
                    {
                        foreach (ClientDepartmentAssociation cda in cd.ClientDepartmentAssociation)
                        {
                            cda.DeptID = cd.DeptID;
                            this.ClientDataProviderInstance.DeleteClientDeptAssociation(cda);
                        }
                        foreach (ClientDepartmentAssociation cda in cd.ClientDepartmentAssociation)
                        {
                            cda.DeptID = cd.ParentId;
                            this.ClientDataProviderInstance.DeleteClientDeptAssociation(cda);
                        }
                        this.ClientDataProviderInstance.UpdateClientDept(cd);

                    }
                    //End
                }

                foreach (ClientContact cc in ClientUser.Contacts)
                {
                    cc.ClientID = ClientUser.ClientID;
                    if (cc.ContactID == -1 && cc.IsDeletedContact == 0)
                    {

                        this.ClientDataProviderInstance.CreateClientContact(cc);
                    }
                    if (cc.IsDeletedContact == 1)
                    {

                        this.ClientDataProviderInstance.DeleteClientContact(cc);
                    }
                    if (cc.ContactID > 0 && cc.IsDeletedContact == 0)
                    {

                        this.ClientDataProviderInstance.UpdateClientContact(cc);

                    }



                }

                //if (sb.Length > 0)
                //    this.NotificationControllerInstance.SendClientRegistrationEmail(ClientUser.CompanyName, sb.ToString(), this.LoggedInUser.UserData.Email);

            }

            return ClientUser;
        }



        public bool CreateClientUser(User InternalUser)
        {

            return this.ClientDataProviderInstance.CreateUserClient(InternalUser);

        }

        public List<iKandi.Common.Client> GetAllClients(int PageSize, int PageIndex, out int TotalPageCount, int BuyingHuoseid, int Clientid)
        {
            return this.ClientDataProviderInstance.GetAllClients(PageSize, PageIndex, out TotalPageCount, BuyingHuoseid, Clientid);
        }

        public List<iKandi.Common.Client> GetAllClients()
        {
            return this.ClientDataProviderInstance.GetAllClients();
        }

        public List<iKandi.Common.Client> GetAll_Clients_WithCode()
        {
            return this.ClientDataProviderInstance.GetAll_Clients_WithCode();
        }

        public List<iKandi.Common.Client> BindDesignListAllClient(string flag, int UserID)
        {
            return this.ClientDataProviderInstance.BindDesignListAllClient(flag, UserID);
        }

        //Add By Prabhaker 22-Mar-2018

        public List<Department> BindAllPrintDept(int ClientId)
        {
            return this.ClientDataProviderInstance.BindAllPrintDept(ClientId);
        }
        //End Of Code


        public int GetClientsInfo_BuyingHouse(int ClientID)
        {
            return this.ClientDataProviderInstance.GetClientsInfo_BuyingHouse(ClientID);
        }
        public int GetDuplicateStyleNo(string styleDuplicateNo)
        {
            return this.ClientDataProviderInstance.GetDuplicateStyleNo(styleDuplicateNo);
        }
        public int checkStylecode(string styleDuplicateNo)
        {
            return this.ClientDataProviderInstance.checkStylecode(styleDuplicateNo);
        }
        public List<iKandi.Common.Client> GetAllClients(int BuyingHouseId)
        {
            return this.ClientDataProviderInstance.GetAllClients(BuyingHouseId);
        }

        public List<iKandi.Common.Client> GetAllClientsName()
        {
            return this.ClientDataProviderInstance.GetAllClientsName();
        }
        public List<iKandi.Common.Client> GetAllClientsNameForFabric()
        {
            return this.ClientDataProviderInstance.GetAllClientsNameForFabric();
        }

        public List<iKandi.Common.Client> GetAllClientsName(int BuyingHouseID)
        {
            return this.ClientDataProviderInstance.GetAllClientsName(BuyingHouseID);
        }

        public List<iKandi.Common.Client> GetAllClientsNameIkandi()
        {
            return this.ClientDataProviderInstance.GetAllClientsNameIkandi();
        }

        public List<ClientDepartment> GetClientDeptsByClientID(int ClientID)
        {
            return this.ClientDataProviderInstance.GetClientDeptsByClientID(ClientID);
        }
        public List<ClientDepartment> GetClientDeptsByClientID_ForDesignForm(int ClientId, int UserID, int ParentDeptId, string type)
        {
            return this.ClientDataProviderInstance.GetClientDeptsByClientID_ForDesignForm(ClientId, UserID, ParentDeptId, type);
        }

        public List<ClientDepartment> GetClientDeptsByClientIDOnlyForOrders(int ClientID, string StyleCodeVersion)
        {
            return this.ClientDataProviderInstance.GetClientDeptsByClientIDOnlyForOrders(ClientID, StyleCodeVersion);
        }

        public iKandi.Common.Client GetClientById(int ClientId)
        {
            iKandi.Common.Client client = this.ClientDataProviderInstance.GetClientByID(ClientId);
            client.Departments = this.ClientDataProviderInstance.GetClientDeptByClientID(ClientId);
            client.Contacts = this.ClientDataProviderInstance.GetClientContactByClientID(ClientId);
            return client;
        }
        #region Gajendra Client Form Updates
        //Gajendra Client Form 27-11-2015
        public System.Data.DataTable GetDesignationByDivision(string DivisionID)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.ClientDataProviderInstance.GetDesignationByDivision(DivisionID);
            return dt;
        }
        //Gajendra Client Form 30-11-2015
        public System.Data.DataTable GetUserListByDeptid(string DptID)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.ClientDataProviderInstance.GetUserListByDeptid(DptID);
            return dt;
        }
        //Gajendra Client Form 02-12-2015
        public System.Data.DataTable GETDepartmentByClientID(string ClientID)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.ClientDataProviderInstance.GETDepartmentByClientID(ClientID);
            return dt;
        }
        //Gajendra Client Form 02-12-2015
        public System.Data.DataTable GetUserListNameByDeptID(string DeptId)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.ClientDataProviderInstance.GetUserListNameByDeptID(DeptId);
            return dt;
        }
        #endregion

        public System.Data.DataTable GetClientByIdDataTable(int ClientId)
        {
            //manisha 21 june 2011
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.ClientDataProviderInstance.GetClientDeptByClientIDDataTable(ClientId);

            return dt;
        }

        public System.Data.DataTable GetClientDeptAssociationByDeptIDDataTable(int DeptID)
        {
            //manisha 21 june 2011
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = this.ClientDataProviderInstance.GetClientDeptAssociationByDeptIDDataTable(DeptID);
            return dt;
        }
        public ClientDepartment GetClientDeptAssociationByDeptIDList(int DeptID)
        {
            //manisha 21 june 2011
            return this.ClientDataProviderInstance.GetClientDeptAssociationByDeptID(DeptID);
        }
        public System.Data.DataSet GetClientDeptAssociationByClientIDDeptID(int DeptID)
        {
            //manisha 21 june 2011
            return this.ClientDataProviderInstance.GetClientDeptAssociationByClientIDDeptID(DeptID);
        }

        public iKandi.Common.Client GetClientViewById(int ClientId)
        {
            iKandi.Common.Client client = this.ClientDataProviderInstance.GetClientByID(ClientId);
            client.Departments = this.ClientDataProviderInstance.GetClientViewDepartmentByClientID(ClientId);
            client.Contacts = this.ClientDataProviderInstance.GetClientContactByClientID(ClientId);
            return client;
        }

        public Client GetClientAssociatedUserDetailByID(int ClientId)
        {
            return this.ClientDataProviderInstance.GetClientAssociatedUserDetailByID(ClientId);
        }

        public List<User> GetClientAccMgrByClientID(int DepartmentId)
        {
            return this.ClientDataProviderInstance.GetClientAccMgrByClientID(DepartmentId, 21);//Gajendra Design
        }
        /// <summary>
        /// yaten: For binding all Clients
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetAllClientBAL()
        {
            return this.ClientDataProviderInstance.GetAllClientDAL();
        }

        public System.Data.DataTable GetAllSeasonListInfoBAL()
        {
            return this.ClientDataProviderInstance.GetAllSeasonListInfoDAL();
        }


        public System.Data.DataTable GetAllSeasonListInfoWithClientBAL(int iSeasonID)
        {
            return this.ClientDataProviderInstance.GetAllSeasonListInfoWithClientDAL(iSeasonID);
        }



        public System.Data.DataSet GetAllSeasonUpdateBAL(int iSeasonID)
        {
            return this.ClientDataProviderInstance.GetAllSeasonUpdateDAL(iSeasonID);
        }

        public System.Data.DataTable GetSeasonByClient(int ClientID, string StyleID)
        {
            System.Data.DataTable dt;
            dt = this.ClientDataProviderInstance.GetSeasonByClient(ClientID, StyleID);
            return dt;
        }



        public void InsertSeasonBAL(int[] SeasonDates, int intID, string SeasonName, DateTime StartDate, DateTime endDate, string clientXML, int IsActive)
        {
            this.ClientDataProviderInstance.InsertSeasonDAL(SeasonDates, intID, SeasonName, StartDate, endDate, clientXML, IsActive);
        }


        public int CheckDateStatusBAL(int[] SeasonDates, int intID, DateTime StartDate, DateTime endDate, int ClientID)
        {
            return this.ClientDataProviderInstance.CheckDateStatusDAL(SeasonDates, intID, StartDate, endDate, ClientID);
        }


        //Add by Surendra2 on 01/11/2018.
        public int InsertIkandiSales_Admin(int Client, int PDept, int Dept, int Month, int Year, int Value, int Pcs, int UserId)
        {
            return this.ClientDataProviderInstance.InsertIkandiSales_Admin(Client, PDept, Dept, Month, Year, Value, Pcs, UserId);
        }
        public int UpdateIkandiSales_Admin(int Client, int PDept, int Dept, int Month, int Year, int Value, int Pcs, int UserId)
        {
            return this.ClientDataProviderInstance.UpdateIkandiSales_Admin(Client, PDept, Dept, Month, Year, Value, Pcs, UserId);
        }
        public System.Data.DataSet GetIkandiSales_AdminByYear(int PrevYear, int NextYear)
        {
            return this.ClientDataProviderInstance.GetIkandiSales_AdminByYear(PrevYear, NextYear);
        }

        //Add by Surendra2 on 05/11/2018.
        public int InsertIkandiSales_AdminNew(int Client, int PDept, int Month, int Year, int Value, int Pcs, int UserId)
        {
            return this.ClientDataProviderInstance.InsertIkandiSales_AdminNew(Client, PDept, Month, Year, Value, Pcs, UserId);
        }
        public int UpdateIkandiSales_AdminNew(int Client, int PDept, int Month, int Year, int Value, int Pcs, int UserId)
        {
            return this.ClientDataProviderInstance.UpdateIkandiSales_AdminNew(Client, PDept, Month, Year, Value, Pcs, UserId);
        }
        public System.Data.DataSet GetIkandiSales_AdminByYearNew(int PrevYear, int NextYear)
        {
            return this.ClientDataProviderInstance.GetIkandiSales_AdminByYearNew(PrevYear, NextYear);
        }
        public System.Data.DataSet GetIkandiSales_AdminByYearNew_Report(int PrevYear, int NextYear)
        {
            return this.ClientDataProviderInstance.GetIkandiSales_AdminByYearNew_Report(PrevYear, NextYear);
        }
        //added by abhishek 26/112/2018
        public System.Data.DataSet GetIkandiSales_AdminByYearNew_Critical_Path_Report(int PrevYear, int NextYear, int PDeptID)
        {
          return this.ClientDataProviderInstance.GetIkandiSales_AdminByYearNew_Critical_Path_Report(PrevYear, NextYear, PDeptID);
        }

        //below added by Girish on 2023-03-30
        public DataSet GetDataFor_grdIkandiadminCommit_sales_Grid(string DeptID)
        {
            return this.ClientDataProviderInstance.GetDataFor_grdIkandiadminCommit_sales_Grid(DeptID);
        }

        /// <summary>
        /// For duplicate seasonm
        /// </summary>
        /// <param name="intID"></param>
        /// <param name="StartDate"></param>
        /// <param name="endDate"></param>
        /// <param name="ClientID"></param>
        /// <returns></returns>
        public int CheckDuplicateSeasonBAL(string SeasonName, int SeasonId)
        {
            return this.ClientDataProviderInstance.CheckDuplicateSeasonDAL(SeasonName, SeasonId);
        }

        public int CheckClientStatusBAL(int SeasonId, int ClientID)
        {
            return this.ClientDataProviderInstance.CheckClientStatusDAL(SeasonId, ClientID);
        }


        public ClientDepartment GetClientDepartmentByUserID(int UserID)
        {
            return this.ClientDataProviderInstance.GetClientDepartmentByUserID(UserID);
        }

        public double GetClientDiscountByClientId(int clientId)
        {
            return this.ClientDataProviderInstance.GetClientDiscountByClientId(clientId);
        }

        public List<ClientDepartment> GetClientListAssismentByClientID(int ClientID)
        {
            return this.ClientDataProviderInstance.GetClientListAssismentByClientID(ClientID);
        }

        public List<ClientDepartment> GetClientDeptsByClientIDByUserID(int ClientID)
        {
            return this.ClientDataProviderInstance.GetClientDeptsByClientIDByUserID(ClientID);
        }

        public List<ClientDepartment> GetClientDeptsByClientIDs(string ClientIDs)
        {

            return this.ClientDataProviderInstance.GetClientDeptsByClientIDs(ClientIDs);

        }



        public System.Data.DataTable GetAllClientsNameBAL(int BuyingHouseID, int temp)
        {
            return this.ClientDataProviderInstance.GetAllClientsName(BuyingHouseID, temp);
        }

        public string GetErrorMessage(MembershipCreateStatus status)
        {
            switch (status)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

        public string[] GetClientDeptByUserId(int UserId)
        {
            return ClientDataProviderInstance.GetClientDeptByUserId(UserId);
        }
        //Added By Ashish on 17/4/2015
        public List<iKandi.Common.Client> GetAllClientsNameForIkandi(int BuyingHouseId, int ClientId, int DateType, string YearRange, int UserId)
        {
            return this.ClientDataProviderInstance.GetAllClientsNameForIkandi(Convert.ToInt32(BuyingHouseId), ClientId, DateType, YearRange, UserId);
        }
        public List<ClientDepartment> GetClientDeptsByClientID_New(int ClientID)
        {
            return this.ClientDataProviderInstance.GetClientDeptsByClientID_New(ClientID);
        }
        //END
        //// for fits only
        //public List<ClientDepartment> GetClientDeptsByDeptID(int ClientID, int DeptID, int StyleNumber)
        //{
        //    return this.ClientDataProviderInstance.GetClientDeptsByDeptID(ClientID, DeptID, StyleNumber);
        //}

        public List<Client> get_all_clients_Order(int UnitId)
        {
            return this.ClientDataProviderInstance.get_all_clients_Order(UnitId);
        }
        public System.Data.DataSet GetIkandiSales_AdminByYearNew_Report_DC(int PrevYear, int NextYear)
        {
            return this.ClientDataProviderInstance.GetIkandiSales_AdminByYearNew_Report_DC(PrevYear, NextYear);
        }

        public string GetCountryById(string CountryId)
        {
            return this.ClientDataProviderInstance.GetCountryById(CountryId);
        }

        public DataSet GetCountryCodesByClientID(int ClientID)
        {
            return this.ClientDataProviderInstance.GetCountryCodesByClientID(ClientID);
        }

        public int SaveCountryCodes(int ClientID, int CountryCodeId, string Flag)
        {
            return this.ClientDataProviderInstance.SaveCountryCodes(ClientID,CountryCodeId,Flag);
        }
    }
}

