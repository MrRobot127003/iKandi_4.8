using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using iKandi.Web.Components;



namespace iKandi.Web
{
    public partial class ClientDepartmentorderReport :BaseUserControl
    {
        # region Event Handler

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindControls();
        }

        # endregion

        # region Methods
        private void BindControls()
        {
            DataSet ds = this.ReportControllerInstance.GetClientDepartmentOrder(ApplicationHelper.LoggedInUser.ClientData.DeptID);
            grdClientOrderDept.DataSource = ds;
            grdClientOrderDept.DataBind();

        }
        # endregion



    }
}