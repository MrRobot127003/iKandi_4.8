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
using iKandi.BLL;
using iKandi.Web.Components;
using iKandi.Common;
using System.Collections.Generic;
using System.Drawing;

namespace iKandi.Web.UserControls.Lists
{
    public partial class MoStitchPopup : BaseUserControl
    {
        private int OrderDetailID
        {
            get
            {
                if (null != Request.QueryString["OrderDetailID"])
                {
                    int OrderDetailID;

                    if (int.TryParse(Request.QueryString["OrderDetailID"].ToString(), out OrderDetailID))
                        return OrderDetailID;
                }

                return -1;
            }
        }

        public static String Flag
        {
            get;
            set;
        }
        private int OrderID
        {
            get
            {
                if (null != Request.QueryString["OrderId"])
                {
                    int OrderID;

                    if (int.TryParse(Request.QueryString["OrderId"].ToString(), out OrderID))
                        return OrderID;
                }

                return -1;
            }
        }
        public string FileUploadName
        {
            get;
            set;
        }
        public static string CutQty
        {
            get;
            set;
        }
        public int CalauclateExactSortShipment()
        {
            int Reuslt = 0;

            int cutQtyvalue = 0;
            int ShipedQntyValue = 0;
            if (CutQty != "")
            {
                cutQtyvalue = Convert.ToInt32(CutQty);

            }
            else
            {
                cutQtyvalue = 0;
            }
            if (txtStitchQty.Text != "")
            {
                ShipedQntyValue = Convert.ToInt32(txtStitchQty.Text);

            }
            else
            {
                ShipedQntyValue = 0;
            }
            Reuslt = cutQtyvalue - ShipedQntyValue;
            return Reuslt;

        }
        public int OrderDetailID_s
        {
            get
            {
                if (null != Request.QueryString["OrderDetailID"])
                {
                    int OrderDetailID;

                    if (int.TryParse(Request.QueryString["OrderDetailID"].ToString(), out OrderDetailID))
                        return OrderDetailID;
                }

                return -1;
            }
        }
        //private string ShippedDate
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(Request.QueryString["ShippedDate"]))
        //        {
        //            return Request.QueryString["ShippedDate"];
        //        }
        //        return "";
        //    }
        //}

        private int Qty
        {
            get
            {
                if (null != Request.QueryString["Qty"])
                {
                    int Qty;

                    if (int.TryParse(Request.QueryString["Qty"].ToString(), out Qty))
                        return Qty;
                }

                return -1;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (null != Request.QueryString["Flag"])
            {
                Flag = Request.QueryString["Flag"].ToString();
            }
            else
            {
                Flag = "";
            }
            if (!IsPostBack)
            {
                BindControls();
            }
            if (this.OrderControllerInstance.bCheckOrderIsShipped(OrderDetailID) == true)
                btnsubmit.Visible = false;
        }

        private void BindControls()
        {
            if (Flag == "QCOpen")
            {
                tblBusiness.Attributes.Add("style", "display:none");
            }
            hdnOrderDetailID.Value = Convert.ToString(OrderDetailID);

            if (Qty != -1)
            {
                txtContractQty.Text = Qty.ToString();
            }
            int DesignationID = ApplicationHelper.LoggedInUser.UserData.DesignationID;
            int Departmentid = ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID;

            DataSet ds = this.OrderControllerInstance.GetShippedDetailByID(OrderDetailID, DesignationID, Departmentid);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                ddlShipingUnit.SelectedValue = dt.Rows[0]["UnitID"].ToString();
            }
            DataTable dt1 = ds.Tables[1];
            DataTable dt2 = ds.Tables[2];
            DataTable dt3 = ds.Tables[3];
            ViewState["Faultname"] = dt3;
            if (ViewState["datatable"] != null)
            {
                grdQafault.DataSource = (DataTable)ViewState["datatable"];
                grdQafault.DataBind();
                //ViewState["datatable"] = ds.Tables[0];



            }
            else
            {
                if (dt2.Rows.Count > 0)
                {
                    grdQafault.DataSource = dt2;
                    grdQafault.DataBind();
                    ViewState["datatable"] = dt2;
                    grdQafault.Visible = true;
                }
                else
                {
                    grdQafault.DataSource = null;
                    grdQafault.DataBind();
                    ViewState["datatable"] = dt2;
                }
            }

            if (dt.Rows.Count > 0)
            {

                if (dt.Rows[0]["shippedqty"].ToString() == "1")
                    txtStitchQty.Text = dt.Rows[0]["shippedqty"].ToString();
                else
                    txtStitchQty.Text = dt.Rows[0]["shippedqty"].ToString();


                txtStitchQty.Text = ViewState["ShipedValue"] == null ? dt.Rows[0]["shippedqty"].ToString() : ViewState["ShipedValue"].ToString();




                txtcutqty.Text = dt.Rows[0]["CutQty"].ToString();
                CutQty = dt.Rows[0]["CutQty"].ToString();
                #region Commented
                txtExpressAiringToUK.Text = (dt.Rows[0]["ExpressAiringToUK"].ToString() == "0") ? "" : dt.Rows[0]["ExpressAiringToUK"].ToString();
                txtCIFAir.Text = (dt.Rows[0]["CIFAir"].ToString() == "0") ? "" : dt.Rows[0]["CIFAir"].ToString();
                txtFiftyPercentCIFAir.Text = (dt.Rows[0]["FiftyPercentCIFAir"].ToString() == "0") ? "" : dt.Rows[0]["FiftyPercentCIFAir"].ToString();
                txtAirToMumbai.Text = (dt.Rows[0]["AirToMumbai"].ToString() == "0") ? "" : dt.Rows[0]["AirToMumbai"].ToString();
                txtInspectionFailandTransport.Text = (dt.Rows[0]["InspectionFailandTransport"].ToString() == "0") ? "" : dt.Rows[0]["InspectionFailandTransport"].ToString();
                txtTotalPenalty.Text = (dt.Rows[0]["TotalPenalty"].ToString() == "0") ? "" : dt.Rows[0]["TotalPenalty"].ToString();
                txtShippedValue.Text = (dt.Rows[0]["ShippedValue"].ToString() == "0") ? "" : dt.Rows[0]["ShippedValue"].ToString();
                txtPenaltyPercentAge.Text = (dt.Rows[0]["PenaltyPercentAge"].ToString() == "0") ? "" : dt.Rows[0]["PenaltyPercentAge"].ToString();
                txtorderDiscount.Text = (dt.Rows[0]["OrderDiscount"].ToString() == "0") ? "" : dt.Rows[0]["OrderDiscount"].ToString();
                chkDiscount.Checked = (dt.Rows[0]["IsPercent"] == DBNull.Value) ? false : Convert.ToBoolean((dt.Rows[0]["IsPercent"]).ToString());
                #endregion

                hdnBP_CR.Value = (dt.Rows[0]["BP_CR"].ToString() == "0") ? "" : dt.Rows[0]["BP_CR"].ToString();
                string IsShipedOn = "";
                if (!string.IsNullOrEmpty(dt.Rows[0]["IsShipedOn"].ToString()))
                {
                    IsShipedOn = (Convert.ToDateTime(dt.Rows[0]["IsShipedOn"].ToString()) == Convert.ToDateTime("01/01/0001") || Convert.ToDateTime(dt.Rows[0]["IsShipedOn"].ToString()) == Convert.ToDateTime("1/1/1900")) ? "" : Convert.ToDateTime(dt.Rows[0]["IsShipedOn"].ToString()).ToString("dd MMM yy (ddd)");
                }

                int StatusOrderId = dt.Rows[0]["StatusOrderId"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["StatusOrderId"]);
                FileUploadName = dt.Rows[0]["PenaltyFileUpload"] == DBNull.Value ? "" : (dt.Rows[0]["PenaltyFileUpload"]).ToString();
                if (FileUploadName != "")
                {
                    lblFileUpload.ForeColor = System.Drawing.Color.Blue;
                }

                //hdnFileName.Value = dt.Rows[0]["PenaltyFileUpload"] == DBNull.Value ? "" : (dt.Rows[0]["PenaltyFileUpload"]).ToString();
                //if (StatusOrderId >= 61)
                //{
                //    btnsubmit.Visible = false;
                //}
                txtISShippedDate.Text = ViewState["ShipedDate"] == null ? IsShipedOn : ViewState["ShipedDate"].ToString();
            }
            if (dt1.Rows.Count > 0)
            {
                txtISShippedDate.Visible = Convert.ToBoolean(dt1.Rows[0]["IsShipedWrite"].ToString());
                txtISShippedDate.Enabled = Convert.ToBoolean(dt1.Rows[0]["IsShipedWrite"].ToString());
            }


        }



        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            bool BcheckPopup = false;
            grdQafault.Visible = true;

            int OrderDetailId = 0;
            int StitchQty = 0;
            int IsShiped = 0;
            txtTotalPenalty.Text = hdnTotalPenalty.Value.ToString();


            if (hdnShippedValue.Value.ToString() == "" || hdnShippedValue.Value.ToString() == "0")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "CloseWindow", "alert('Shipped Value is Zero.Please Check.');", true);
                return;
            }


            if (hdnShippedValue.Value.ToString() != "")
                txtShippedValue.Text = hdnShippedValue.Value.ToString();
            //txtShippedValue.Text = hdnShippedValue.Value.ToString();
            txtPenaltyPercentAge.Text = hdnPenaltyPercentAge.Value.ToString();
            string UploadeFile = hdnFileName.Value == "" ? FileUploadName : hdnFileName.Value;

            float ExpressAiringToUK = 0; float CIFAir = 0; float FiftyPercentCIFAir = 0; float AirToMumbai = 0; float InspectionFailandTransport = 0; float TotalPenalty = 0; float ShippedValue = 0; float PenaltyPercentAge = 0;
            float OrderDisacout = 0; bool ChkIsPercent = false;

            if (txtStitchQty.Text == "" && Flag == "")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "CloseWindow", "alert('Please fill Shipped Quantity.');", true);
                return;
            }
            if (Flag == "")
            {
                if (string.IsNullOrEmpty(txtISShippedDate.Text) && txtISShippedDate.Visible)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "CloseWindow", "alert('Please select Shipped date.');", true);
                    return;
                }
            }
            int HasRecord = grdQafault.Rows.Count;
            int OneShippedQty = 0;
            if (txtStitchQty.Text == "1" || txtStitchQty.Text == "")
                OneShippedQty = 0;
            else
                OneShippedQty = Convert.ToInt32(txtStitchQty.Text);
            if (txtStitchQty.Text != "" && txtStitchQty.Text != "0" && OneShippedQty != 1)
            //if (ViewState["datatable"] == null)
            {
                if (CutQty == "")
                    CutQty = "0";
                if (Convert.ToInt32(txtStitchQty.Text) < Convert.ToInt32(CutQty))
                {
                    if (HasRecord == 0 || HasRecord <= 0)
                    {

                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "CloseWindow", "alert('Fill short shipment details first.');", true);
                        grdQafault.Visible = true;
                        return;



                    }

                }
                int TotatCutQty = 0;
                foreach (GridViewRow row in grdQafault.Rows)
                {


                    string txtqty = ((TextBox)row.FindControl("txtQnty")).Text;
                    if (txtqty != "")
                    {
                        if (txtqty == "0")
                        {
                            ShowAlert("please enter valid qty.!");
                            return;
                        }

                        TotatCutQty += Convert.ToInt32(((TextBox)row.FindControl("txtQnty")).Text);
                    }
                    //if (TotatCutQty > Convert.ToInt32(CutQty))
                    //{
                    //    ShowAlert("Enterd cut qnty cannot be grather then actual cut qnty.!");
                    //    return;

                    //}



                }
                //if (TotatCutQty > CalauclateExactSortShipment())
                //{
                //    ShowAlert("Entered cut qty  cannot be grather then actual cut qty .!");
                //    return;

                //}
                if (TotatCutQty < CalauclateExactSortShipment())
                {
                    ShowAlert("Please fill complete cut qty .!");
                    return;

                }

            }


            DataTable dtRecord;
            string Flasg = string.Empty;
            DataTable dtnewvalidate = new DataTable();
            dtnewvalidate = (DataTable)(ViewState["Faultname"]);

            if (ViewState["datatable"] != null)
            {
                dtRecord = (DataTable)ViewState["datatable"];


                if (dtRecord.Rows.Count > 0)
                {
                    foreach (DataRow row in dtRecord.Rows)
                    {
                        foreach (DataColumn col in dtRecord.Columns)
                        {
                            if (row["fault"].ToString() == string.Empty || row["fault"] == DBNull.Value)
                            {
                                ShowAlert("fault name could not be  blank");
                                return;
                            }
                            else if (row["UnshippedQty"].ToString() == string.Empty || row["UnshippedQty"] == DBNull.Value)
                            {
                                ShowAlert("Unshipped Qty could not be  blank");
                                return;
                            }

                        }
                    }
                    foreach (GridViewRow rows in grdQafault.Rows)
                    {
                        TextBox txtFaultname = (TextBox)rows.FindControl("txtFaultname");
                        TextBox txtQnty = (TextBox)rows.FindControl("txtQnty");


                        //FaulName = txtFaultname.Text.Trim();

                        //qnty = Convert.ToInt32(txtQnty.Text.Trim());

                        foreach (DataRow dr in dtnewvalidate.Rows)
                        {
                            if (dr["TextFields"].ToString().Trim() == txtFaultname.Text.Trim())
                            {
                                Flasg = "HAS";
                            }
                        }
                        if (Flasg == "HAS")
                        {

                        }
                        else
                        {
                            ShowAlert("You can select either fault or unaccounted only" + " (" + txtFaultname.Text + ") " + "not a valid");
                            return;
                        }
                        Flasg = "";

                    }

                }




                #region Commented
                //if (string.IsNullOrEmpty(txtCIFAir.Text))
                //{
                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "CloseWindow", "alert('Please fill CIF Air');", true);
                //    return;
                //}
                //if (string.IsNullOrEmpty(txtFiftyPercentCIFAir.Text))
                //{
                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "CloseWindow", "alert('Please fill 50% CIF Air');", true);
                //    return;
                //}
                //if (string.IsNullOrEmpty(txtAirToMumbai.Text))
                //{
                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "CloseWindow", "alert('Please fill Air To Mumbai');", true);
                //    return;
                //}
                //if (string.IsNullOrEmpty(txtInspectionFailandTransport.Text))
                //{
                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "CloseWindow", "alert('Please fill Inspection Fail & Transport');", true);
                //    return;
                //}
                //if (string.IsNullOrEmpty(txtTotalPenalty.Text))
                //{
                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "CloseWindow", "alert('Please fill Total Penalty');", true);
                //    return;
                //}
                //if (string.IsNullOrEmpty(txtShippedValue.Text))
                //{
                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "CloseWindow", "alert('Please fill Shipped Value');", true);
                //    return;
                //}
                //if (string.IsNullOrEmpty(txtPenaltyPercentAge.Text))
                //{
                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "CloseWindow", "alert('Please fill Penalty %Age To Shipped Value');", true);
                //    return;
                //}
                #endregion

                if (hdnOrderDetailID.Value != "")
                {
                    OrderDetailId = Convert.ToInt32(hdnOrderDetailID.Value);
                }
                DateTime dShippedDate = new DateTime();
                var ShippedDate = txtISShippedDate.Text;
                if (!string.IsNullOrEmpty(ShippedDate))
                {
                    dShippedDate = DateTime.ParseExact(ShippedDate, "dd MMM yy (ddd)", null);
                }
                if (Flag == "")
                    IsShiped = 1;
                if (txtStitchQty.Text == "")
                    StitchQty = 1;
                else
                    StitchQty = Convert.ToInt32(txtStitchQty.Text);

                ExpressAiringToUK = string.IsNullOrEmpty(txtExpressAiringToUK.Text) ? 0 : float.Parse(txtExpressAiringToUK.Text);
                CIFAir = string.IsNullOrEmpty(txtCIFAir.Text) ? 0 : float.Parse(txtCIFAir.Text);
                FiftyPercentCIFAir = string.IsNullOrEmpty(txtFiftyPercentCIFAir.Text) ? 0 : float.Parse(txtFiftyPercentCIFAir.Text);
                AirToMumbai = string.IsNullOrEmpty(txtAirToMumbai.Text) ? 0 : float.Parse(txtAirToMumbai.Text);
                InspectionFailandTransport = string.IsNullOrEmpty(txtInspectionFailandTransport.Text) ? 0 : float.Parse(txtInspectionFailandTransport.Text);
                TotalPenalty = string.IsNullOrEmpty(txtTotalPenalty.Text) ? 0 : float.Parse(txtTotalPenalty.Text);
                ShippedValue = string.IsNullOrEmpty(txtShippedValue.Text) ? 0 : float.Parse(txtShippedValue.Text);
                PenaltyPercentAge = string.IsNullOrEmpty(txtPenaltyPercentAge.Text) ? 0 : float.Parse(txtPenaltyPercentAge.Text);
                OrderDisacout = string.IsNullOrEmpty(txtorderDiscount.Text) ? 0 : float.Parse(txtorderDiscount.Text);
                ChkIsPercent = chkDiscount.Checked == true ? true : false;

                int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                int results = 0;
                bool result;
                ValidateduplicateRecird(out result);
                if (result == false)
                {
                    return;
                }

                bool ibool = this.OrderControllerInstance.UpdateIsShiped_For_Current(OrderDetailId, IsShiped, dShippedDate, StitchQty, ExpressAiringToUK, CIFAir, FiftyPercentCIFAir, AirToMumbai, InspectionFailandTransport, TotalPenalty, ShippedValue, PenaltyPercentAge, OrderDisacout, ChkIsPercent, UploadeFile, Convert.ToInt16(ddlShipingUnit.SelectedValue), UserId);
                if (ibool)
                {
                    int IsDeletedOld = this.OrderControllerInstance.DeleteAddFualtDetails(OrderDetailId, 0, "", "DELETE");

                    if (IsDeletedOld > 0)
                    {
                        int qnty = 0;
                        string FaulName = string.Empty;
                        string FlagIsDelete = "NO";
                        foreach (GridViewRow row in grdQafault.Rows)
                        {
                            TextBox txtFaultname = (TextBox)row.FindControl("txtFaultname");
                            TextBox txtQnty = (TextBox)row.FindControl("txtQnty");


                            FaulName = txtFaultname.Text.Trim();

                            qnty = Convert.ToInt32(txtQnty.Text.Trim());

                            results = this.OrderControllerInstance.DeleteAddFualtDetails(OrderDetailId, qnty, FaulName, FlagIsDelete);
                        }
                        if (results > 0)
                        {
                            BcheckPopup = true;
                            ShowAlert("Record updated successfully");
                            ViewState["datatable"] = null;
                            BindControls();
                        }
                    }

                    if (Flag == "")
                    {
                        //if (dShippedDate >= DateTime.Now.Date)
                        //{
                        bool IsShipedTodayDate = this.OrderControllerInstance.UpdateIsShipedTodayDate(OrderDetailId);
                        WorkflowInstance instance = WorkflowControllerInstance.UpdatePostOrder_ForApprovedToEx_And_Exfactoried(OrderID, OrderDetailId, TaskMode.Approved_To_EX_Shipping, UserId);
                        instance = WorkflowControllerInstance.UpdatePostOrder_ForApprovedToEx_And_Exfactoried(OrderID, OrderDetailId, TaskMode.EXFACTORIED, UserId);
                        instance = WorkflowControllerInstance.CreateTaskFor_Consolidated(OrderID, OrderDetailId, TaskMode.Consolidated, UserId);
                        //int i = WorkflowControllerInstance.Usp_UpdateWorkflowTask_PostOrder_WorkingCreated_Live_Approved_toEx(OrderID, OrderDetailId, TaskMode.Approved_toEx, UserId);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "CloseWindow", "CloseWindow();", true);
                        //}
                        //else
                        //{
                        //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "CloseWindow", "CloseWindow();", true);
                        //}
                    }
                    if (BcheckPopup == false)
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "CloseWindow", "alert('Record updated successfully');", true);
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "CloseWindow", "CloseWindow();", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "CloseWindow", "alert('Some error occured during saving');", true);
                }

            }
        }
        protected void grdQafault_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdQafault.Rows[e.RowIndex];

            HiddenField hdnAutoincretment = (HiddenField)row.FindControl("hdnAutoincretment");

            HiddenField hdnfaultid = (HiddenField)row.FindControl("hdnfaultid");
            DataTable dtnew = new DataTable();
            int rowIdnex = e.RowIndex;
            if (ViewState["datatable"] != null)
            {
                dtnew = (DataTable)(ViewState["datatable"]);
                if (hdnAutoincretment.Value != "0")
                {
                    dtnew.Rows.Remove(dtnew.Select("ID=" + hdnfaultid.Value)[0]);
                }
                else
                {
                    dtnew.Rows.Remove(dtnew.Select("dataTableId=" + hdnfaultid.Value)[0]);
                }
                ViewState["datatable"] = dtnew;
            }


            grdQafault.EditIndex = -1;
            BindControls();

        }
        protected void grdQafault_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //string Username = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            ////string[] name = Username.Split('@');
            //string date = DateTime.Now.ToString("dd MMM yyyy");

            DataTable dtnewvalidate = new DataTable();
            dtnewvalidate = (DataTable)(ViewState["Faultname"]);
            string Result = string.Empty;
            if (e.CommandName == "Insert")
            {
                TextBox txtfoterfaultname = grdQafault.FooterRow.FindControl("txtfoterfaultname") as TextBox;
                TextBox txtfoterqnty = grdQafault.FooterRow.FindControl("txtfoterqnty") as TextBox;

                HiddenField hdnIDfoter = grdQafault.FooterRow.FindControl("hdnAutoincretmentfoter") as HiddenField;

                LinkButton abtnAdd = grdQafault.FooterRow.FindControl("abtnAdd") as LinkButton;

                DataTable dtnew = new DataTable();

                string faultname = string.Empty;
                string qty = string.Empty;

                if (txtfoterfaultname != null && txtfoterfaultname.Text == string.Empty)
                {
                    ShowAlert("Enter fault name");
                    return;
                }
                else
                {
                    faultname = txtfoterfaultname.Text;
                }
                if (txtfoterqnty == null || txtfoterqnty.Text == string.Empty)
                {
                    ShowAlert("Enter qty");
                    return;
                }
                else
                {
                    qty = txtfoterqnty.Text;
                }

                if (ViewState["datatable"] != null)
                {
                    dtnew = (DataTable)(ViewState["datatable"]);
                    int i = 0;
                    for (; i < grdQafault.Rows.Count; i++)
                    {
                        dtnew.Rows[i]["ID"] = i + 1;
                        dtnew.Rows[i]["OrderDetailsID"] = OrderDetailID;
                        dtnew.Rows[i]["FaultsID"] = i + 1;

                        dtnew.Rows[i]["UnshippedQty"] = ((TextBox)grdQafault.Rows[i].FindControl("txtQnty")).Text;
                        dtnew.Rows[i]["FaultID"] = i + 1;


                        foreach (DataRow dr in dtnewvalidate.Rows)
                        {
                            if (dr["TextFields"].ToString() == ((TextBox)grdQafault.Rows[i].FindControl("txtFaultname")).Text)
                            {
                                Flag = "HAS";
                            }
                        }
                        if (Flag == "HAS")
                        {
                            dtnew.Rows[i]["fault"] = ((TextBox)grdQafault.Rows[i].FindControl("txtFaultname")).Text;
                        }
                        else
                        {
                            //((TextBox)grdQafault.Rows[i].FindControl("txtQnty")).Text = "";
                            //((TextBox)grdQafault.Rows[i].FindControl("txtFaultname")).Text="";
                            ShowAlert("You can select either fault or unaccounted only" + " (" + ((TextBox)grdQafault.Rows[i].FindControl("txtFaultname")).Text + ") " + "not a valid");
                            return;
                        }
                        Flag = "";




                    }


                    //dtnew.Rows.Add(i + 1, faultname, qty);

                    //dtnew.Rows[i+1]["OrderDetailsID"] = OrderDetailID;
                    //dtnew.Rows[i+1]["FaultsID"] = i + 1;

                    //dtnew.Rows[i + 1]["UnshippedQty"] = txtfoterfaultname.Text;
                    //dtnew.Rows[i+1]["FaultID"] = i + 1;
                    //dtnew.Rows[i + 1]["fault"] = txtfoterqnty.Text;

                    DataRow row = dtnew.NewRow();
                    row["OrderDetailsID"] = OrderDetailID;
                    row["FaultsID"] = i + 1;
                    row["UnshippedQty"] = txtfoterqnty.Text;
                    row["FaultID"] = i + 1;
                    row["ID"] = i + 1;
                    foreach (DataRow dr in dtnewvalidate.Rows)
                    {
                        if (dr["TextFields"].ToString() == txtfoterfaultname.Text)
                        {
                            Flag = "HAS";
                        }
                    }
                    if (Flag == "HAS")
                    {
                        row["fault"] = txtfoterfaultname.Text;
                    }
                    else
                    {
                        txtfoterfaultname.Text = "";
                        txtfoterqnty.Text = "";
                        ShowAlert("You can select either fault or unaccounted only" + " (" + txtfoterfaultname.Text + ") " + "not a valid");
                        return;
                    }
                    Flag = "";

                    dtnew.Rows.Add(row);

                    dtnew.AcceptChanges();



                    ViewState["datatable"] = dtnew;

                }

                ViewState["ShipedValue"] = txtStitchQty.Text.Trim();
                ViewState["ShipedDate"] = txtISShippedDate.Text.Trim();

                BindControls();





            }
            if (e.CommandName == "addnew")
            {

                Table tblGrdviewApplet = (Table)grdQafault.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];


                TextBox txtemptyfaultname = (TextBox)rows.FindControl("txtemptyfaultname");
                TextBox txtemptyqnty = (TextBox)rows.FindControl("txtemptyqnty");

                //HiddenField hdnIDfoter = grdQafault.FooterRow.FindControl("hdnAutoincretmentfoter") as HiddenField;


                if (txtemptyqnty.Text == "")
                {
                    txtemptyqnty.Text = "0";
                    
                }

                if (Convert.ToInt32(txtemptyqnty.Text) > Convert.ToInt32(CutQty))
                {
                    ShowAlert("Entered cutqnty cannot be grather then actual cutqnty.!");
                    return;
                }

                DataTable dtnew = new DataTable();

                string faultname = string.Empty;
                string qty = string.Empty;


                if (txtemptyfaultname != null && txtemptyfaultname.Text == string.Empty)
                {
                    ShowAlert("Enter fault name");
                    return;
                }
                else
                {
                    faultname = txtemptyfaultname.Text;
                }
                if (txtemptyqnty == null && txtemptyqnty.Text == string.Empty)
                {
                    ShowAlert("Enter qty");
                    return;
                }
                else
                {
                    qty = txtemptyqnty.Text;
                }








                if (ViewState["datatable"] != null)
                {
                    dtnew = (DataTable)(ViewState["datatable"]);

                    //for (int i = 0; i < grdQafault.Rows.Count; i++)
                    //{
                    //dtnew.Rows[i]["fault"] = ((TextBox)grdQafault.Rows[i].FindControl("fault")).Text;
                    //dtnew.Rows[i]["qnty"] = ((TextBox)grdQafault.Rows[i].FindControl("qnty")).Text;
                    // }

                    DataRow row = dtnew.NewRow();
                    row["OrderDetailsID"] = OrderDetailID;
                    row["FaultsID"] = 0;
                    row["UnshippedQty"] = qty;
                    row["FaultID"] = 0;
                    row["ID"] = 0;
                    row["fault"] = faultname;

                    dtnew.Rows.Add(row);
                    dtnew.AcceptChanges();

                    //dtnew.Rows[0]["fault"] = txtemptyfaultname.Text;
                    //dtnew.Rows[0]["qnty"] = txtemptyqnty.Text;

                    //dtnew.AcceptChanges();

                    //dtnew.Rows.Add(OrderDetailID,0,qty,0, faultname);
                    ViewState["datatable"] = dtnew;
                }

                ViewState["ShipedValue"] = txtStitchQty.Text.Trim();
                ViewState["ShipedDate"] = txtISShippedDate.Text.Trim();

                BindControls();
            }
        }

        protected void grdQafault_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
            //    ltIndex.Text = ((grdHoppmFabricRemark.PageIndex * grdHoppmFabricRemark.PageSize) + e.Row.RowIndex + 1).ToString();
            //}
            //bool EnableHOPPM = grdHoppmFabricRemark.Enabled;
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Literal ltIndex = (Literal)e.Row.FindControl("ltIndex");
            //    //ltIndex.Text = ((grdHoppmFabricRemark.PageIndex * grdHoppmFabricRemark.PageSize) + e.Row.RowIndex + 1).ToString();
            //    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");


            //    if (!EnableHOPPM)
            //    {
            //        lnkDelete.Visible = false;
            //    }



            //    TextBox txtRemarkEdit = (TextBox)e.Row.FindControl("txtRemarkEdit");
            //    NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
            //    if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true)
            //    {
            //        if (NewRefrence == 1)
            //        {
            //            txtRemarkEdit.Enabled = true;
            //            lnkDelete.Visible = true;
            //            lnkDelete.Attributes.Add("style", "display:block;");
            //        }
            //        else
            //        {
            //            txtRemarkEdit.Enabled = false;
            //            lnkDelete.Visible = false;
            //            lnkDelete.Attributes.Add("style", "display:none;");
            //        }
            //    }

            //}
            //if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    LinkButton abtnAdd = (LinkButton)e.Row.FindControl("abtnAdd");
            //    if (!EnableHOPPM)
            //    {
            //        abtnAdd.Visible = false;
            //    }
            //    NewRefrence = Convert.ToInt32(hdnHoppmNewRef.Value);
            //    TextBox txtRemarkFooter = (TextBox)e.Row.FindControl("txtRemarkFooter");
            //    if (chkProdQAMgr.Checked == true && chkMM.Checked == true && chkFactoryPPMComplete.Checked == true && chkHOPPMComplete.Checked == true)
            //    {
            //        if (NewRefrence == 1)
            //        {
            //            txtRemarkFooter.Enabled = true;
            //            abtnAdd.Visible = true;
            //        }
            //        else
            //        {
            //            txtRemarkFooter.Enabled = false;
            //            abtnAdd.Visible = false;
            //        }

            //    }
            //}
            //if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            //{
            //    LinkButton addbutton = (LinkButton)e.Row.FindControl("addbutton");
            //    if (!EnableHOPPM)
            //    {
            //        addbutton.Visible = false;
            //    }
            //}
        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        public void ValidateduplicateRecird(out bool IsValid)
        {
            IsValid = true;
            int Count = 0;
            foreach (GridViewRow row in grdQafault.Rows)
            {
                TextBox txtFaultname = (TextBox)row.FindControl("txtFaultname");
                if (txtFaultname != null)
                {
                    Count = 0;
                    if (txtFaultname.Text != "")
                    {
                        foreach (GridViewRow rows in grdQafault.Rows)
                        {
                            TextBox txtFaultname_nextrow = (TextBox)rows.FindControl("txtFaultname");
                            if (txtFaultname_nextrow != null)
                            {
                                if (txtFaultname_nextrow.Text != "")
                                {
                                    if (txtFaultname.Text.Trim() == txtFaultname_nextrow.Text.Trim())
                                    {
                                        Count += 1;

                                        if (Count > 1)
                                        {
                                            txtFaultname_nextrow.BorderColor = Color.Red;
                                            txtFaultname_nextrow.BorderWidth = 1;
                                            ShowAlert("Duplicate fault name found");
                                            IsValid = false;
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}