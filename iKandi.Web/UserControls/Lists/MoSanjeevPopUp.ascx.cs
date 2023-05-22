using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using System.Text;
using iKandi.BLL;

namespace iKandi.Web.UserControls.Lists
{
    public partial class MoSanjeevPopUp : BaseUserControl
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
        public int OrderDetailId
        {
            get;
            set;
        }
        public string DelayOrderDetailIds
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (null != Request.QueryString["styleId"])
            {
                styleId = Convert.ToInt32(Request.QueryString["styleId"]);
            }
            if (null != Request.QueryString["OrderDetailId"])
            {
                OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"]);
            }
            if (null != Request.QueryString["exfactorydate"])
            {
                exfactorydate = Request.QueryString["exfactorydate"].ToString();
            }
            if (null != Request.QueryString["stylenumber"])
            {
                stylenumber = Request.QueryString["stylenumber"].ToString();
            }
            if (null != Request.QueryString["DelayOrderDetailIds"])
            {
                DelayOrderDetailIds = Request.QueryString["DelayOrderDetailIds"].ToString();
            }
            DelayOrderDetailIds = DelayOrderDetailIds == "" ? "0" : DelayOrderDetailIds;

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

            // Added By Ravi kumar on 2/2/2015
            remark = this.OrderControllerInstance.Get_SanjeevRemark(OrderDetailId);

            //if (desigId == 19)
            if (IsPermission == true)
                btnSubmit.Visible = true;
            else
                btnSubmit.Visible = false;


            string[] separators = { "~" };
            string StrRem = remark.Replace("!<@#", " ");
            //string StrRemarks = StrRem.Replace("!>@#", "/");
            string[] words = StrRem.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                lblShowRemark.Text = lblShowRemark.Text + "</br>" + word;
                lblShowRemark.Attributes.Add("style","float:left");
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

            gv.Columns[5].Visible = this.OrderControllerInstance.IscheckShippingPermission(desigId, DeptId, 15);

            gv.DataSource = ds;
            gv.DataBind();
        }

      
        protected void gv_rowdatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                MoShippingDetail od = (e.Row.DataItem as MoShippingDetail);
                e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml(od.ExFactoryColor);

               // Label lblPcdDate = (Label)gv.FindControl("lblPcdDate");
                Label lblPcdDate = e.Row.FindControl("lblPcdDate") as Label;
                // lblPcdDate.Text = Convert.ToDateTime(lblPcdDate.Text).ToString("dd MMM yy (ddd)");
                lblPcdDate.Text = Convert.ToDateTime(od.PcdDate).ToString("dd MMM yy (ddd)");

                HiddenField hdnpcdDates = e.Row.FindControl("hdnpcdDates") as HiddenField;
              hdnpcdDates.Value=  Convert.ToDateTime(od.PcdDate).ToString("dd MMM yy (ddd)");

            }
        }

        protected void CheckHeader_OnCheckedChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < gv.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)gv.Rows[i].FindControl("CheckBox1");
                cb.Checked = true;
            }
        }

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    string ids = "";
        //    foreach (GridViewRow gvr in gv.Rows)
        //    {
        //        HiddenField hdnpcdDate = (HiddenField)gvr.FindControl("hdnpcdDate");
        //        HiddenField hdnexfactDate = (HiddenField)gvr.FindControl("hdnexfactDate");

                

        //        if (((CheckBox)gvr.FindControl("CheckHeader")).Checked)
        //        {
        //            if (!string.IsNullOrEmpty(ids))
        //                ids += ",";
        //            ids += ((HiddenField)gvr.FindControl("hf")).Value.Trim();

        //            if (hdnpcdDate != null && hdnexfactDate != null)
        //            {
        //                var Exfact = Convert.ToDateTime(hdnexfactDate.Value);
        //                var PCD = Convert.ToDateTime(hdnpcdDate.Value);

        //                DateTime exfac = Exfact.Date;
        //                DateTime pcddate = PCD.Date;

                      

        //                if (pcddate > exfac)
        //                {
        //                    ShowAlert("PCD date cannot be greater then Exfactory date check again.!");
        //                    return;
        //                }
 
        //            }



        //        }
        //    }
        //   // Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "MyFunction()", true);

        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "UpdateMoShipping();", true);

        //    string str = txtremarks.Text.Trim(); ;
        //    string strMassage = str.Replace("\\s", "");

        //    // this.OrderControllerInstance.UpdateRemarksShipping(strMassage, ids, txtExFactory.Text.Trim());

        //}
        public static string OrderDeID
        {
            get;
            set;
        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        //added by abishek on 12/8/2016
        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            string ids = "";
            OrderDeID = "";
            
                foreach (GridViewRow gvr in gv.Rows)
                {
                    HiddenField hdnpcdDate = (HiddenField)gvr.FindControl("hdnpcdDates");
                    HiddenField hdnexfactDate = (HiddenField)gvr.FindControl("hdnexfactDate");
                    HiddenField hdnDcdate = (HiddenField)gvr.FindControl("hdnDcdate");

                    if (((CheckBox)gvr.FindControl("cb")).Checked)
                    {
                        if (!string.IsNullOrEmpty(ids))
                            ids += ",";
                        ids += ((HiddenField)gvr.FindControl("hf")).Value.Trim();

                        gdnOrderID.Value = ids;
                        if (txtExFactory.Text != "")
                        {
                            if (hdnpcdDate != null && hdnexfactDate != null)
                            {
                                var Exfact = iKandi.Web.Components.DateHelper.ParseDate(txtExFactory.Text).Value;
                                var PCD = iKandi.Web.Components.DateHelper.ParseDate(hdnpcdDate.Value).Value;
                                var DCDate = iKandi.Web.Components.DateHelper.ParseDate(hdnDcdate.Value).Value;

                                DateTime exfac = Exfact.Date;
                                DateTime pcddate = PCD.Date;
                                DateTime DCdate_date = DCDate.Date;

                                if (pcddate >= exfac)
                                {
                                    ShowAlert("PCD date cannot be greater then Exfactory date check again.!");
                                    return;
                                }
                                //else if (DCdate_date <= exfac)
                                //{
                                //    ShowAlert("DC date cannot be less then Exfactory date check again.!");
                                //    return;
                                //}
                            }
                        }
                    }
                }
                
                ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "UpdateMoShipping("+ DelayOrderDetailIds+");", true);

                string str = txtremarks.Text.Trim(); ;
                string strMassage = str.Replace("\\s", "");

                Session["PageIndex"] = "1";

            // this.OrderControllerInstance.UpdateRemarksShipping(strMassage, ids, txtExFactory.Text.Trim());
        }
        
     }
}