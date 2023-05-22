using System;
using System.Data;
using iKandi.BLL;
using iKandi.Web.Components;


namespace iKandi.Web.UserControls.Reports
{
    public partial class ClosedResolutionTask : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bindcontol();
        }
        public void bindcontol()
        {
            int ClientID = ApplicationHelper.LoggedInUser.UserData.UserID;
            CommonController objCommonController = new CommonController();
            DataTable dt = objCommonController.GetClosedTask(ClientID);
            grdClosedTask.DataSource = dt;
            grdClosedTask.DataBind();
            if (dt.Rows.Count == 0)
                this.Parent.Visible = false; 

            //grdClosedTask.DataSource = CreateTable();
            //grdClosedTask.DataBind();
        } 

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SerialNumber");
            dt.Columns.Add("StyleNumber");
            dt.Columns.Add("ContractNumber");
            dt.Rows.Add("aaa", "bbb", "ccc");
            dt.Rows.Add("aaa", "bbb", "ccc");
            dt.Rows.Add("aaa", "bbb", "ccc");
            dt.Rows.Add("aaa", "bbb", "ccc");
            return dt;
        }
    }
}