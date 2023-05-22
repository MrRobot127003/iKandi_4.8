using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.BLL;

namespace iKandi.Web.UserControls.Lists
{
    public partial class MOPermissionList : System.Web.UI.UserControl
    {
        PermissionController obj_Permission = new PermissionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindList();
            }
        }

        protected void BindList()
        {
            DataTable dtPermission = new DataTable();
            dtPermission = obj_Permission.getPermission();
            GridView1.DataSource = dtPermission;
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType != DataControlRowType.DataRow)
                    return;
                Label ltIndex = (Label)e.Row.FindControl("ltIndex");

                ltIndex.Text = ((GridView1.PageIndex * GridView1.PageSize) + e.Row.RowIndex + 1).ToString();
                HiddenField hdnDepartmentID = (HiddenField)e.Row.FindControl("hdnDepartmentID");
            }
            catch (Exception ex)
            {
                string strMsg = ex.Message;
            }
        }
    }
}

