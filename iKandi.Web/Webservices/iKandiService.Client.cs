using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Services;
using iKandi.BLL;
using System.Collections.Generic;
using iKandi.Common;

namespace iKandi.Web
{
    public partial class iKandiService
    {
        [WebMethod(EnableSession = true)]
        public List<ClientDepartment> GetClientDeptsByClientID(int ClientID)
        {
            return this.ClientControllerInstance.GetClientDeptsByClientID(ClientID);
        }
        [WebMethod(EnableSession = true)]
        public List<ClientDepartment> GetClientDeptsByClientID_ForDesignForm(int ClientID, int UserID, int ParentDeptId, string type)
        {
            return this.ClientControllerInstance.GetClientDeptsByClientID_ForDesignForm(ClientID, UserID, ParentDeptId, type);
        }

        [WebMethod(EnableSession = true)]
        public List<ClientDepartment> GetClientDeptsByClientIDs(string ClientIDs)
        {
            return this.ClientControllerInstance.GetClientDeptsByClientIDs(ClientIDs);
        }

        [WebMethod(EnableSession = true)]
        public double GetClientDiscountByClientId(int clientId)
        {
            return this.ClientControllerInstance.GetClientDiscountByClientId(clientId);
        }

        [WebMethod(EnableSession = true)]
        public Client GetClientDetailByID(int ClientID)
        {
            return this.ClientControllerInstance.GetClientAssociatedUserDetailByID(ClientID);
        }

        [WebMethod(EnableSession = true)]
        public List<ClientDepartment> GetClientDeptsByClientIDByUserID(int ClientID)
        {
            return this.ClientControllerInstance.GetClientDeptsByClientIDByUserID(ClientID);
        }

        [WebMethod(EnableSession = true)]
        public List<Season> GetSeasonByClient(int ClientID, string StyleID)
        {
            DataTable dt;
            dt = this.ClientControllerInstance.GetSeasonByClient(ClientID, StyleID);
            DataRow dr1 = dt.NewRow();
            dr1["FinalSeason"] = "N.A";
            dr1["Id"] = "0";
            dr1["Isdefault"] = "0";
            dt.Rows.InsertAt(dr1, 0);
            dt.AcceptChanges();

            List<Season> seasons = new List<Season>();
            foreach (DataRow dr in dt.Rows)
            {
                Season season = new Season();
                season.SeasonName = Convert.ToString(dr["FinalSeason"]);
                season.SeasonID = Convert.ToInt32(dr["Id"]);
                season.IsDefault = Convert.ToInt32(dr["Isdefault"]);
                seasons.Add(season);
            }
            return seasons;

        }

        [WebMethod(EnableSession = true)]
        public List<Client> BindClientsDesignProxy(int BuyingHouseID)
        {
            ClientController controller = new ClientController(iKandi.Web.Components.ApplicationHelper.LoggedInUser);

            List<Client> clients = controller.GetAllClientsName(BuyingHouseID);


            return clients;

        }
        //Gajendra Design
        [WebMethod(EnableSession = true)]
        public List<Client> BindBuyingHouseProxy(string DivisionID)
        {
            DataTable dt = this.PrintControllerInstance.GetBuyingHouseByDivision(DivisionID);
            if (dt.Rows.Count > 0)
                dt.Rows.RemoveAt(0);
            DataRow dr1 = dt.NewRow();
            dr1["ID"] = -1;
            dr1["CompanyName"] = "Select";
            dt.Rows.InsertAt(dr1, 0);
            dt.AcceptChanges();
            List<Client> clients = new List<Client>();
            foreach (DataRow dr in dt.Rows)
            {
                Client client = new Client();
                client.BuyingHouseId = Convert.ToInt32(dr["ID"]);
                client.BuyingHouseName = Convert.ToString(dr["CompanyName"]);
                clients.Add(client);
            }
            return clients;
        }
        [WebMethod(EnableSession = true)]
        public List<ClientDepartment> GetClientDeptsByClientID_New(int ClientID)
        {
            return this.ClientControllerInstance.GetClientDeptsByClientID_New(ClientID);
        }
        //[WebMethod(EnableSession = true)]
        //public List<Client> BindDeptListAgainstCliets(int UserId, int ClientId, int FitMerchantID)
        //{
        //  AdminController objadmin=new AdminController();
        //  return objadmin.BindDeptListAgainstCliets(UserId, ClientId, FitMerchantID);
        //}
    }
}
