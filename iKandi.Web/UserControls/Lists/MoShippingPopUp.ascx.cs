using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;

namespace iKandi.Web.UserControls.Lists
{
    public partial class MoShippingPopUp : BaseUserControl
    {
        public int styleId
        {
            get;
            set;
        }

        public string remark
        {
            get;
            set;
        }

        public string exfactorydate
        {
            get;
            set;
        }

        public string stylenumber
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
                BindControl();
        }

        public void BindControl()
        {
            DataTable dtPermission = new DataTable();
            btnSubmit.Visible = false;
            int desigId = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Designation);
            int DeptId = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID);
            // int UserID = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID);
            //Added By Ashish on 20/1/2015
            int ColumnId = 59;
            bool IsPermission = this.OrderControllerInstance.IscheckShippingRemarksPermission(desigId, DeptId, ColumnId);
            //END

            //if (desigId == 19)
            if (IsPermission == true)
                btnSubmit.Visible = true;
            else
                btnSubmit.Visible = false;

            //Added By Ashish on 16/10/2014 for Show Mo Shipping Remarks
            string[] separators = { "$$" };
            string StrRem = remark.Replace("!<@#", "'");
            //string StrRemarks = StrRem.Replace("!>@#", "/");
            string[] words = StrRem.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                lblShowRemark.Text = lblShowRemark.Text + "</br>" + word;
            }

            //END
            //lblShowRemark.Text = remark;
            lblStyleNumber.Text = stylenumber;
            //hfexFactoryDate.Value = exfactorydate;
            List<MoShippingDetail> ds = this.OrderControllerInstance.GetMoShippingInfo(styleId);


            dtPermission = this.OrderControllerInstance.IscheckShippingPermissionExFactory(desigId, DeptId, 13);
            if (dtPermission.Rows.Count > 0)
            {
                string MoColumnName = dtPermission.Rows[0]["MoColumnName"].ToString();
                bool ExFactoryRead = Convert.ToBoolean(dtPermission.Rows[0]["PermisionRead"].ToString());
                bool ExFactoryWrite = Convert.ToBoolean(dtPermission.Rows[0]["PermisionWrite"].ToString());

                if (ExFactoryRead == true && ExFactoryWrite == true)
                {
                    txtExFactory.Enabled = true;
                    txtExFactory.Visible = true;
                }
                else if (ExFactoryRead == true && ExFactoryWrite == false)
                {
                    txtExFactory.Enabled = false;
                    txtExFactory.Visible = true;
                }

            }
            else
            {
                txtExFactory.Visible = false;
            }

            gv.Columns[4].Visible = this.OrderControllerInstance.IscheckShippingPermission(desigId, DeptId, 15);


            //GridView1.Columns[23].Visible = PermissionHelper.IsReadPermittedOnColumn((int)AppModuleColumn.MANAGE_ORDERS_FILE_MARCHANDISING_SANJEEV_REMARKS);
            //GridView1.Columns[24].Visible = PermissionHelper.IsReadPermittedOnColumn((int)AppModuleColumn.MANAGE_ORDERS_FILE_MARCHANDISING_MERCHANT_NOTES);
            //GridView1.Columns[17].Visible = PermissionHelper.IsReadPermittedOnColumn((int)AppModuleColumn.MANAGE_ORDERS_FILE_MARCHANDISING_EXFACTORY);
            //GridView1.Columns[18].Visible = PermissionHelper.IsReadPermittedOnColumn((int)AppModuleColumn.MANAGE_ORDERS_FILE_MARCHANDISING_DC);
            gv.DataSource = ds;
            gv.DataBind();
        }

        // iKandi.Web.Components.ApplicationHelper.
        //iKandi.Web.Components.ApplicationHelper.

        protected void gv_rowdatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            MoShippingDetail od = (e.Row.DataItem as MoShippingDetail);
            e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml(od.ExFactoryColor);
        }

        protected void CheckHeader_OnCheckedChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < gv.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)gv.Rows[i].FindControl("CheckBox1");
                cb.Checked = true;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string ids = "";
            foreach (GridViewRow gvr in gv.Rows)
            {
                if (((CheckBox)gvr.FindControl("CheckHeader")).Checked)
                {
                    if (!string.IsNullOrEmpty(ids))
                        ids += ",";
                    ids += ((HiddenField)gvr.FindControl("hf")).Value.Trim();
                }
            }

            string str = txtremarks.Text.Trim(); ;
            string strMassage = str.Replace("\\s", "");

            // this.OrderControllerInstance.UpdateRemarksShipping(strMassage, ids, txtExFactory.Text.Trim());
        }
    }
}