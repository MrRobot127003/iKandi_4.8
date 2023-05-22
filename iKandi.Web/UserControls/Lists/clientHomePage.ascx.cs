using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using iKandi.BLL;
using iKandi.Web.Components;
using iKandi.Common;
using System.Text;

namespace iKandi.Web
{
    public partial class clientHomePage : BaseUserControl
    {
      
        #region Properties

        public int IsClient
        {
            get;
            set;

        }
        public int BuyingHouse
        {
            get;
            set;
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int ClientID = 0;
            int DeptID = 0;
            if (ApplicationHelper.LoggedInUser.ClientData != null)
            {
                this.IsClient = 1;
                ClientID = ApplicationHelper.LoggedInUser.ClientData.Client.ClientID;
                DeptID = ApplicationHelper.LoggedInUser.ClientData.DeptID;
            }
            else
            {
                this.IsClient = 0;
            }
            if (!IsPostBack)
            {
                iKandi.BLL.ClientController ClientControllerInstance = new iKandi.BLL.ClientController();
                DataSet ds = ClientControllerInstance.GetClientDeptAssociationByClientIDDeptID(DeptID);
                if (ds != null)
                {
                    if (ds.Tables[0] != null)
                    {
                        grdBipl.DataSource = ds.Tables[0];
                        grdBipl.DataBind();
                    }
                    if (ds.Tables[1] != null)
                    {
                        grdIkandi.DataSource = ds.Tables[1];
                        grdIkandi.DataBind();
                    }
                }
            }
        }
    }
}