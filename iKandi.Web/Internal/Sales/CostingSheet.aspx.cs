using System;
using System.Web.UI;
using iKandi.Common;
using iKandi.Web.Components;
using System.Data;

namespace iKandi.Web
{
    public partial class CostingSheet : BasePage
    {
        #region Properties

        private string StyleNumber
        {
            get
            {
                if (null == Request.QueryString["sn"])
                    return string.Empty;

                string sn = Request.QueryString["sn"].Trim();
                if (SingleVersion == 0)
                {
                    if (sn.IndexOf('$') > -1)
                    {
                        sn = sn.Replace("!", "");

                        if (sn.IndexOf(' ') > -1)
                            sn = sn.Substring(0, sn.LastIndexOf(' '));

                        sn = sn.Replace('$', ' ');
                        return sn;
                    }
                    // Code applied for duplicate costing by RSB dated on 16 march 2017
                    if (sn.Split(' ').Length == 3)
                        sn = sn.Substring(0, sn.LastIndexOf(' ') + 1);
                }
                else
                {
                }
                // end of Code applied for duplicate costing by RSB dated on 16 march 2017
                return sn;
            }
        }

        public int IsUcknowledge
        {
            get
            {
                if (null != Request.QueryString["IsUcknowledge"])
                {
                    int isUcknowledg;

                    if (int.TryParse(Request.QueryString["IsUcknowledge"], out isUcknowledg))
                        return isUcknowledg;
                }

                return -1;
            }
        }
        public int SingleVersion
        {
            get
            {
                if (null != Request.QueryString["SingleVersion"])
                {
                    int SingleVersion;

                    if (int.TryParse(Request.QueryString["SingleVersion"], out SingleVersion))
                        return SingleVersion;
                }

                return 0;
            }
        }

        #endregion

        #region Event Handlers

        protected override void Render(HtmlTextWriter writer)
        {
            Page.ClientScript.RegisterForEventValidation(ddlBuyer.ClientID);
            Page.ClientScript.RegisterForEventValidation(ddlDept.ClientID);

            base.Render(writer);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnIsUcknowledge.Value = IsUcknowledge.ToString();
            if (!string.IsNullOrEmpty(StyleNumber))
            {
                var service = new iKandiService();
                CostingCollection objCostingCollection = service.GetCostingByStyleNumber(StyleNumber, 1, SingleVersion);

                if (null != objCostingCollection && objCostingCollection.Count > 0)
                {
                    //CostingForm1.Visible = false;                    

                    repeaterCostingTabs.DataSource = repeaterCostingSheets.DataSource = objCostingCollection;
                    repeaterCostingTabs.DataBind();
                    repeaterCostingSheets.DataBind();

                    int iUserId = 0;
                    string Flag = string.Empty;
                    string v = Request.QueryString["Emailid"];
                    if (v != null && v!="")
                    {
                        Flag = v;

                        if (ApplicationHelper.LoggedInUser.UserData != null)

                            iUserId = ApplicationHelper.LoggedInUser.UserData.UserID;

                        UserDetails usd = new UserDetails();


                        SessionInfo sessionInfo = new SessionInfo();

                        iKandi.Common.User user = null;

                        user = this.MembershipControllerInstance.GetUser(Convert.ToInt32(iUserId));
                        ApplicationHelper objApplicationHelper = new ApplicationHelper();
                        DataSet ds = objApplicationHelper.GetNotifactionRemarks(user.DesignationID, Convert.ToInt32(Flag), "Form", iUserId);
                    }

                   
                }
                else
                {
                    string script = "ShowHideValidationBox(true, 'No Costing Sheet exists for you.', 'Costing Sheet');";
                    ScriptManager.RegisterStartupScript(Page, typeof (Page), "ShowMessage", script, true);
                }

                if (!IsPostBack)
                {
                    BindStyleControls();
                }
            }
        }

        protected void btnSaveStyle_Click(object sender, EventArgs e)
        {
        }

        #endregion

        #region Private Methods

        private void BindStyleControls()
        {
            DropdownHelper.BindClients(ddlBuyer);
        }

        #endregion

        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}