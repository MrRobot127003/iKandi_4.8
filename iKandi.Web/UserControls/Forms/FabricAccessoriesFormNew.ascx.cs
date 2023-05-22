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
using System.Collections.Generic;
using System.Text;

using iKandi.Common;
using iKandi.Web.Components;
using iKandi.BLL;

namespace iKandi.Web.UserControls.Forms
{
    public partial class FabricAccessoriesFormNew : BaseUserControl
    {
        #region Fields

        iKandi.Common.Order objOrderDetail;
        iKandi.Common.AccessoryWorking objAccessoryWorking;
        Int32 rptFabricOrderSize_RowIndex = 0;
        double TotalQuantityPerSize = 0;
        double TotalQuantityExtra = 0;
        double TotalQuantity = 0;
        double PercentageExtra = 4.4f;
        public String CellWidth = String.Empty;
        String TextBoxId = String.Empty;
        //DataSet ds = new DataSet();
        DataSet ds = null;
        DataSet ds1;
        DataSet dsCompleteData = null;
        DataTable dtmerge = new DataTable();

        DataSet dsContract = new DataSet();
        DataTable dtQty = new DataTable();
        string strODId1 = "";
        string strODId2 = "";
        string strODId3 = "";
        string strODId4 = "";
        string strODId5 = "";
        string strODId6 = "";
        string strODId7 = "";
        string strODId8 = "";
        string strODId9 = "";
        string strODId10 = "";
        string strODId11 = "";
        string strODId12 = "";
        string strODId13 = "";
        string strODId14 = "";
        string strODId15 = "";
        string strODId16 = "";
        string strODId17 = "";
        string strODId18 = "";
        string strODId19 = "";


        int TotalQuantity1 = 0;
        int TotalQuantity2 = 0;
        int TotalQuantity3 = 0;
        int TotalQuantity4 = 0;
        int TotalQuantity5 = 0;
        int TotalQuantity6 = 0;
        int TotalQuantity7 = 0;
        int TotalQuantity8 = 0;
        int TotalQuantity9 = 0;
        int TotalQuantity10 = 0;
        int TotalQuantity11 = 0;
        int TotalQuantity12 = 0;
        int TotalQuantity13 = 0;
        int TotalQuantity14 = 0;
        int TotalQuantity15 = 0;
        int TotalQuantity16 = 0;
        int TotalQuantity17 = 0;
        int TotalQuantity18 = 0;
        int TotalQuantity19 = 0;
        #endregion

        //public static string session;

        #region Properties

        private int OrderID
        {
            get
            {
                if (null != Request.QueryString["orderid"])
                {
                    string str = Convert.ToString(Session.SessionID);
                    int orderid;

                    if (int.TryParse(Request.QueryString["orderid"].ToString(), out orderid))
                        return orderid;
                }

                return -1;
            }
        }
        //abhishek added 
        public string User_Session
        {
            get;
            set;
        }
        public string Print
        {
            get;
            set;
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (null != Request.QueryString["Print"])
            {
                Print = Request.QueryString["Print"];
            }
            Guid id = Guid.NewGuid();
            string sessionDummy = Convert.ToString(id).Replace("-", "");
            StringBuilder s = new StringBuilder(sessionDummy);
            s[0] = 'q';
            string session = s.ToString();
            User_Session = s.ToString();

            if (Request.QueryString["btn"] == "1")
            {
                //trprint2.Attributes.Add("class", "do-not-print");
                trprint21.Attributes.Add("class", "do-not-print");
                trprint3.Attributes.Add("class", "do-not-print");
            }
            if (Request.QueryString["btn"] == "2")
            {
                //trprint1.Attributes.Add("class", "do-not-print");
                trprint11.Attributes.Add("class", "do-not-print");
                trprint12.Attributes.Add("class", "do-not-print");
                trprint3.Attributes.Add("class", "do-not-print");
            }
            if (Request.QueryString["btn"] == "3")
            {
                //trprint1.Attributes.Add("class", "do-not-print");
                trprint11.Attributes.Add("class", "do-not-print");
                trprint12.Attributes.Add("class", "do-not-print");
                //trprint2.Attributes.Add("class", "do-not-print");
                trprint21.Attributes.Add("class", "do-not-print");
            }
            //Page.ClientScript.GetPostBackEventReference(this, string.Empty);
            if (!IsPostBack)
            {
                //this.DataBind();
                ViewState["dtCompleteData"] = null;
                BindContractGrid();
                BindControl(session);


            }
            A1.HRef = "~/Internal/Fabric/FabricAccessoriesWorkSheet.aspx?orderid=" + OrderID + "&Print=Yes";
            GridHeader(OrderID, Convert.ToInt32(hdnAccesoriedID.Value), session);

            if (Print == "Yes")
            {
                btnPrint.Visible = true;
                btnSubmit.Visible = false;
            }

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            // Save();
            //GridHeader(Convert.ToInt32(hdnAccesoriedID.Value), OrderID);
            SaveFabricAccessoriesDetails(grdAccessories);
            //ShowAlert("Saved successfully");
            ////Response.Redirect("http://localhost:5033/Internal/Fabric/FabricAccessoriesWorkSheet.aspx?orderid=9899");

            //btnPrint.Visible = true;
        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }


        protected void btnAddRow_Click(object sender, EventArgs e)
        {

        }
        protected void rptAccessories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (objAccessoryWorking != null && objAccessoryWorking.AccessoryWorkingDetail != null && objAccessoryWorking.AccessoryWorkingDetail.Count > 0)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    TextBoxId = ((Label)e.Item.FindControl("lblQuantity")).ClientID;
                    ((TextBox)e.Item.FindControl("txtNumber")).Text = objAccessoryWorking.AccessoryWorkingDetail[e.Item.ItemIndex].Number.ToString();
                    ((Label)e.Item.FindControl("lblQuantity")).Text = objAccessoryWorking.AccessoryWorkingDetail[e.Item.ItemIndex].Quantity.ToString("N0");
                    ((TextBox)e.Item.FindControl("txtDetails")).Text = objAccessoryWorking.AccessoryWorkingDetail[e.Item.ItemIndex].Details;
                    //((TextBox)e.Item.FindControl("txtName")).Text = objAccessoryWorking.AccessoryWorkingDetail[e.Item.ItemIndex].AccessoryName;
                    ((CheckBox)e.Item.FindControl("chkIdDTM")).Checked = objAccessoryWorking.AccessoryWorkingDetail[e.Item.ItemIndex].IsDTM;

                    if (!String.IsNullOrEmpty(objAccessoryWorking.AccessoryWorkingDetail[e.Item.ItemIndex].FilePath))
                    {
                        ((Image)e.Item.FindControl("imgSwatch")).ImageUrl = "~/uploads/accessory/thumb-" + objAccessoryWorking.AccessoryWorkingDetail[e.Item.ItemIndex].FilePath;
                    }
                    else
                    {
                        ((Image)e.Item.FindControl("imgSwatch")).Visible = false;
                    }
                }
            }
        }


        //protected void rptAccessories_ItemCommand(object sender, RepeaterCommandEventArgs e)
        //{
        //    if (e.CommandName == "AddRow")
        //    {
        //        objAccessoryWorking = new AccessoryWorking();
        //        objAccessoryWorking.AccessoryWorkingDetail = new List<AccessoryWorkingDetail>();
        //        AccessoryWorkingDetail objAccessoryWorkingDetail = new AccessoryWorkingDetail();

        //        foreach (RepeaterItem rptItemAccessory in rptAccessories.Items)
        //        {
        //            objAccessoryWorkingDetail = new AccessoryWorkingDetail();
        //            objAccessoryWorkingDetail.Number = Convert.ToDecimal((((TextBox)rptItemAccessory.FindControl("txtNumber")).Text.Trim() != "" ? ((TextBox)rptItemAccessory.FindControl("txtNumber")).Text.Trim() : "0"));
        //            objAccessoryWorkingDetail.Quantity = Convert.ToInt32(Math.Round(objAccessoryWorkingDetail.Number * Convert.ToInt32(hdnTotalCount.Value), MidpointRounding.ToEven));
        //            objAccessoryWorkingDetail.Details = ((TextBox)rptItemAccessory.FindControl("txtDetails")).Text;
        //            objAccessoryWorkingDetail.AccessoryName = ((TextBox)rptItemAccessory.FindControl("txtName")).Text;
        //            objAccessoryWorkingDetail.IsDTM = ((CheckBox)rptItemAccessory.FindControl("chkIdDTM")).Checked;
        //            objAccessoryWorkingDetail.FilePath = ((FileUpload)rptItemAccessory.FindControl("fuFile")).HasFile ? SaveUploadedFile(((FileUpload)rptItemAccessory.FindControl("fuFile"))) : GetFilePath(((Image)rptItemAccessory.FindControl("imgSwatch")));
        //            objAccessoryWorking.AccessoryWorkingDetail.Add(objAccessoryWorkingDetail);
        //        }

        //        objAccessoryWorkingDetail = new AccessoryWorkingDetail();
        //        objAccessoryWorkingDetail.Number = 0;
        //        objAccessoryWorkingDetail.Quantity = 0;
        //        objAccessoryWorkingDetail.Details = "";
        //        objAccessoryWorkingDetail.AccessoryName = "";
        //        objAccessoryWorking.AccessoryWorkingDetail.Add(objAccessoryWorkingDetail);

        //        rptAccessories.DataSource = objAccessoryWorking.AccessoryWorkingDetail;
        //        rptAccessories.DataBind();
        //    }

        //}

        protected void rptFabricOrderSizeItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            TotalQuantityPerSize = 0;
            if (e.Item.ItemType == ListItemType.Header)
            {
                CellWidth = (100 / objOrderDetail.OrderBreakdown.Count).ToString() + "%";

                ((Repeater)e.Item.FindControl("rptFabricOrderDetail")).DataSource = objOrderDetail.OrderBreakdown;
                ((Repeater)e.Item.FindControl("rptFabricOrderDetail")).DataBind();
            }

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CellWidth = (100 / objOrderDetail.OrderBreakdown.Count).ToString() + "%";

                ((Repeater)e.Item.FindControl("rptFabricOrderDetail")).DataSource = objOrderDetail.OrderBreakdown;
                ((Repeater)e.Item.FindControl("rptFabricOrderDetail")).DataBind();
                rptFabricOrderSize_RowIndex = rptFabricOrderSize_RowIndex + 1;

                ((Label)e.Item.FindControl("lblTotalQuantity")).Text = TotalQuantityPerSize.ToString("N0");
                //((Label)e.Item.FindControl("lblTotalQuantityExtra")).Text = (TotalQuantityPerSize + Math.Round((TotalQuantityPerSize * PercentageExtra) / 100, MidpointRounding.ToEven)).ToString("N0");
                TotalQuantityExtra = TotalQuantityExtra + Convert.ToInt32((TotalQuantityPerSize + Math.Round((TotalQuantityPerSize * PercentageExtra) / 100, MidpointRounding.ToEven)));
                TotalQuantity = TotalQuantity + TotalQuantityPerSize;
            }


            if (e.Item.ItemType == ListItemType.Footer)
            {
                ((Repeater)e.Item.FindControl("rptFabricOrderDetail")).DataSource = objOrderDetail.OrderBreakdown;
                ((Repeater)e.Item.FindControl("rptFabricOrderDetail")).DataBind();
                //Int32 i = 0;
                //Repeater rptAccessoriesNew = (Repeater)e.Item.FindControl("rptFabricOrderDetail").Parent.Parent.Parent.FindControl("rptAccessories");
                //HiddenField hdnCnQty = (HiddenField)(rptAccessoriesNew.Items[i].FindControl("hiddenCnQty"));
                //foreach (OrderDetail od in objOrderDetail.OrderBreakdown)
                //{
                //    hdnCnQty.Value = hdnCnQty.Value + od.ContractNumber + ": [X" + i + "]" + "<br />";
                //    i++;
                //}

                ((Repeater)e.Item.FindControl("rptFabricOrderDetailExtra")).DataSource = objOrderDetail.OrderBreakdown;
                ((Repeater)e.Item.FindControl("rptFabricOrderDetailExtra")).DataBind();


                ((Label)e.Item.FindControl("lblTotalQuantity")).Text = TotalQuantity.ToString("N0");
                //((Label)e.Item.FindControl("lblTotalQuantityExtra")).Text = TotalQuantityExtra.ToString("N0");
                ((Label)e.Item.FindControl("lblTotalQuantityExtra1")).Text = TotalQuantityExtra.ToString("N0");
                ((Label)e.Item.FindControl("lblTotalQuantityExtra2")).Text = TotalQuantityExtra.ToString("N0");

                if (TotalQuantityExtra > 0)
                    hdnTotalCount.Value = TotalQuantityExtra.ToString();

            }
        }

        protected void rptFabricOrderDetailItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (objOrderDetail.OrderBreakdown.Count > e.Item.ItemIndex && objOrderDetail.OrderBreakdown[e.Item.ItemIndex].OrderSizes.Count > rptFabricOrderSize_RowIndex)
                {
                    ((Label)e.Item.FindControl("lblQuantity")).Text = objOrderDetail.OrderBreakdown[e.Item.ItemIndex].OrderSizes[rptFabricOrderSize_RowIndex].Quantity.ToString("N0");
                    if (((Label)e.Item.FindControl("lblQuantity")).Text == "")
                    {
                        ((Label)e.Item.FindControl("lblQuantity")).Text = "0";
                    }
                    TotalQuantityPerSize = TotalQuantityPerSize + objOrderDetail.OrderBreakdown[e.Item.ItemIndex].OrderSizes[rptFabricOrderSize_RowIndex].Quantity;
                    if (TotalQuantityPerSize == 156)
                    {

                    }
                }
                else
                {
                    ((Label)e.Item.FindControl("lblQuantity")).Text = "0";

                }

                //if (objOrderDetail.OrderBreakdown[0].OrderSizes[rptFabricOrderSize_RowIndex] != null)
                //{
                //}
                //else
                //{
                //    ((Label)e.Item.FindControl("lblQuantity")).Text = "0";
                //}
            }

            //((Label)e.Item.FindControl("lblQuantity")).Text = "0";



        }



        protected void rptFabricOrderDetailItemDataBoundFooter(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                double totalQuantityPerSize = 0;

                if (objOrderDetail.OrderBreakdown.Count > e.Item.ItemIndex)
                {
                    foreach (OrderDetailSizes obj in objOrderDetail.OrderBreakdown[e.Item.ItemIndex].OrderSizes)
                    {
                        totalQuantityPerSize = totalQuantityPerSize + obj.Quantity;
                    }
                    ((Label)e.Item.FindControl("lblQuantity")).Text = totalQuantityPerSize.ToString("N0");
                }
            }
        }

        protected void rptFabricOrderDetailItemDataBoundFooterExtra(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                double totalQuantityPerSize = 0;
                double calcval = 0;
                if (objOrderDetail.OrderBreakdown.Count > e.Item.ItemIndex)
                {
                    foreach (OrderDetailSizes obj in objOrderDetail.OrderBreakdown[e.Item.ItemIndex].OrderSizes)
                    {
                        calcval = Math.Round((obj.Quantity * PercentageExtra) / 100, MidpointRounding.ToEven);
                        totalQuantityPerSize = totalQuantityPerSize + obj.Quantity + calcval;
                        //totalQuantityPerSize = totalQuantityPerSize + obj.Quantity;
                    }
                    //                    ((Label)e.Item.FindControl("lblQuantity")).Text = (totalQuantityPerSize + Math.Round((totalQuantityPerSize * PercentageExtra) / 100, MidpointRounding.ToEven)).ToString("N0");
                    ((Label)e.Item.FindControl("lblQuantity")).Text = totalQuantityPerSize.ToString("N0");
                }
            }
        }

        protected void btnRefresh_click(object sender, EventArgs e)
        {
            // BindControl();
        }
        // update by sushil for tooltip on date 27/3/3015
        private void BindContractGrid()
        {


            ds = this.OrderControllerInstance.GetAccesoriesDetails(OrderID);
            int count = ds.Tables[0].Rows.Count;

            if (ds.Tables[1].Rows.Count > 0)
            {


                grdCuttingOption1.DataSource = ds.Tables[1];
                grdCuttingOption1.DataBind();
                //AddGridview(ds.Tables[2], grdCuttingOption1);
                grdCuttingOption1.Visible = true;

            }

            if (ds.Tables[2].Rows.Count > 0)
            {


                grdCuttinOption2.DataSource = ds.Tables[2];
                grdCuttinOption2.DataBind();
                grdCuttinOption2.Visible = true;
                //AddGridview(ds.Tables[4], grdCuttinOption2);
            }


            if (ds.Tables[3].Rows.Count > 0)
            {

                grdCuttingOption3.DataSource = ds.Tables[3];
                grdCuttingOption3.DataBind();
                grdCuttingOption3.Visible = true;
                //AddGridview(ds.Tables[6], grdCuttingOption3);
            }

            if (ds.Tables[4].Rows.Count > 0)
            {

                grdCuttingOption4.DataSource = ds.Tables[4];
                grdCuttingOption4.DataBind();
                grdCuttingOption4.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }


            if (ds.Tables[5].Rows.Count > 0)
            {

                grdCuttingOption5.DataSource = ds.Tables[5];
                grdCuttingOption5.DataBind();
                grdCuttingOption5.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }



            if (ds.Tables[6].Rows.Count > 0)
            {

                grdCuttingOption6.DataSource = ds.Tables[6];
                grdCuttingOption6.DataBind();
                grdCuttingOption6.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }


            if (ds.Tables[7].Rows.Count > 0)
            {

                grdCuttingOption7.DataSource = ds.Tables[7];
                grdCuttingOption7.DataBind();
                grdCuttingOption7.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }


            if (ds.Tables[8].Rows.Count > 0)
            {

                grdCuttingOption8.DataSource = ds.Tables[8];
                grdCuttingOption8.DataBind();
                grdCuttingOption8.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }


            if (ds.Tables[9].Rows.Count > 0)
            {

                grdCuttingOption9.DataSource = ds.Tables[9];
                grdCuttingOption9.DataBind();
                grdCuttingOption9.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }


            if (ds.Tables[10].Rows.Count > 0)
            {

                grdCuttingOption10.DataSource = ds.Tables[10];
                grdCuttingOption10.DataBind();
                grdCuttingOption10.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }


            if (ds.Tables[11].Rows.Count > 0)
            {

                grdCuttingOption11.DataSource = ds.Tables[11];
                grdCuttingOption11.DataBind();
                grdCuttingOption11.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }


            if (ds.Tables[12].Rows.Count > 0)
            {

                grdCuttingOption12.DataSource = ds.Tables[12];
                grdCuttingOption12.DataBind();
                grdCuttingOption12.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }


            if (ds.Tables[13].Rows.Count > 0)
            {

                grdCuttingOption13.DataSource = ds.Tables[13];
                grdCuttingOption13.DataBind();
                grdCuttingOption13.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }


            if (ds.Tables[14].Rows.Count > 0)
            {

                grdCuttingOption14.DataSource = ds.Tables[14];
                grdCuttingOption14.DataBind();
                grdCuttingOption14.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }


            if (ds.Tables[15].Rows.Count > 0)
            {


                grdCuttingOption15.DataSource = ds.Tables[15];
                grdCuttingOption15.DataBind();
                grdCuttingOption15.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }
            if (ds.Tables[16].Rows.Count > 0)
            {


                grdCuttingOption16.DataSource = ds.Tables[16];
                grdCuttingOption16.DataBind();
                grdCuttingOption16.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }
            if (ds.Tables[17].Rows.Count > 0)
            {


                grdCuttingOption17.DataSource = ds.Tables[17];
                grdCuttingOption17.DataBind();
                grdCuttingOption17.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }
            if (ds.Tables[18].Rows.Count > 0)
            {


                grdCuttingOption18.DataSource = ds.Tables[18];
                grdCuttingOption18.DataBind();
                grdCuttingOption18.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }
            if (ds.Tables[19].Rows.Count > 0)
            {


                grdCuttingOption19.DataSource = ds.Tables[19];
                grdCuttingOption19.DataBind();
                grdCuttingOption19.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }

        }
        // end by sushil for tooltip on date 27/3/3015 

        public void AddGridview(DataTable dt, GridView gv)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string colName = dt.Rows[i]["Size"].ToString();
                    gv.HeaderRow.Cells[1 + i].Text = colName;

                }
            }
        }
        private void BindControl(string UserSession)
        {

            objAccessoryWorking = this.AccessoryWorkingControllerInstance.GetAccessoryWorking(OrderID);
            hdnAccesoriedID.Value = Convert.ToString(objAccessoryWorking.Id);
            GridHeader(OrderID, objAccessoryWorking.Id, UserSession);

            if (objAccessoryWorking.AccessoryWorkingDetail != null && objAccessoryWorking.AccessoryWorkingDetail.Count > 0)
            {
                //rptAccessories.DataSource = objAccessoryWorking.AccessoryWorkingDetail;
                //rptAccessories.DataBind();
            }
            else
            {
                objAccessoryWorking.AccessoryWorkingDetail = new List<AccessoryWorkingDetail>();

                List<Accessory> objAccessoryColl = this.AccessoryWorkingControllerInstance.GetAllAccessory(OrderID);

                int i = 0;
                foreach (Accessory obj in objAccessoryColl)
                {
                    objAccessoryWorking.AccessoryWorkingDetail.Add(new AccessoryWorkingDetail());
                    objAccessoryWorking.AccessoryWorkingDetail[i].AccessoryName = obj.Name;
                    objAccessoryWorking.AccessoryWorkingDetail[i].Number = obj.Quantity;
                    objAccessoryWorking.AccessoryWorkingDetail[i].Quantity = obj.TotalQuantity;
                    i++;
                }

                if (objAccessoryColl.Count > 0)
                {
                    //rptAccessories.DataSource = objAccessoryWorking.AccessoryWorkingDetail;
                    //rptAccessories.DataBind();
                }
                else
                {
                    //rptAccessories.DataSource = "a";  // "a" will work as array collection of one item( This will add one row when there is no row exist in AccessoryWorkingDetail collaction)
                    //rptAccessories.DataBind();
                }
            }


            if (OrderID < 0) return;

            //objOrderDetail = this.OrderControllerInstance.GetOrder(OrderID);
            objOrderDetail = this.OrderControllerInstance.GetOrderAccesories(OrderID);
            if (objOrderDetail.OrderBreakdown != null)
            {
                lblCreationDate.Text = objOrderDetail.OrderDate == DateTime.MinValue ? "" : objOrderDetail.OrderDate.ToString("dd MMM yy (ddd)");
                lblSerial.Text = objOrderDetail.SerialNumber;
                lblStyleNumber.Text = objOrderDetail.Style.StyleNumber;
                lblDepartment.Text = objOrderDetail.Style.cdept.Name;
                lblBulkEta.Text = objOrderDetail.BulkETA == DateTime.MinValue ? "" : "" + objOrderDetail.BulkETA.ToString("dd MMM yy (ddd)");
                lblDesc.Text = objOrderDetail.Description;
                //lblComments.Text = objOrderDetail.OrderLimitation.Count > 0 ? objOrderDetail.OrderLimitation[0].AccessoriesComments : "NA";
                //lblAccessoryBulkETA.Text = objOrderDetail.OrderLimitation.Count > 0 ? objOrderDetail.OrderLimitation[0].AccessoriesBulkETA.ToString("dd MMM yy (ddd)") : "NA";
                //lblAccessoryBulkETA.Text = objOrderDetail.OrderDetail.BulkApprovalTarget == DateTime.MinValue ? "" : " - " + objOrderDetail.OrderDetail.BulkApprovalTarget.ToString("dd MMM yy (ddd)");
                lblAccessoryBulkETA.Text = objOrderDetail.OrderBreakdown.Count > 0 ? objOrderDetail.OrderBreakdown[0].BulkApprovalTarget.ToString("dd MMM yy (ddd)") : "NA";
                // txtMainLabel.Text = objAccessoryWorking.MainLabel;
                //   txtSizeLabel.Text = objAccessoryWorking.SizeLabel;
                //   txtTags.Text = objAccessoryWorking.Tags;

                //   txtWashcare.Text = objAccessoryWorking.WashCare;
                //    txtSwatch.Text = objAccessoryWorking.Swatch;
                chkBoxAccessoryManager.Checked = objAccessoryWorking.ApprovedByAccessoryManager > 0 ? true : false;
                //as per as discuss by surender sir 2/1/2016

                //chkBoxAccessoryManager.Enabled = !chkBoxAccessoryManager.Checked && ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Accessory_Manager;
                chkBoxAccountManager.Checked = objAccessoryWorking.ApprovedByAccountManager > 0 ? true : false;
                ///   chkBoxAccountManager.Enabled = !chkBoxAccountManager.Checked && (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_AccountManager || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_FitMerchant);
                //if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_FitMerchant)
                //{
                //    chkBoxAccessoryManager.Enabled = false;
                //    chkBoxAccountManager.Enabled = false;
                //}
                if (objAccessoryWorking.History != null && objAccessoryWorking.History.IndexOf("$$") > -1)
                {
                    objAccessoryWorking.History = objAccessoryWorking.History.Replace("$$", "<br/>");
                    lblHistory.Text = objAccessoryWorking.History.Replace("<br/><br/>", "<br/>");
                }
                else
                {
                    lblHistory.Text = objAccessoryWorking.History;
                }


                Boolean HideRow = false;

                if (!String.IsNullOrEmpty(objOrderDetail.Style.SampleImageURL1))
                {
                    imgStyle.ImageUrl = "~/" + System.Configuration.ConfigurationManager.AppSettings["style.folder"] + System.Configuration.ConfigurationManager.AppSettings["image.prefix"] + objOrderDetail.Style.SampleImageURL1;
                    // imgStyle.Attributes.Add("onclick", "showStylePhoto(" + objOrderDetail.Style.StyleID.ToString() + "," + OrderID.ToString() + ",-1);");
                    imgStyle.Attributes.Add("onclick", "showStylePhotoWithOutScroll(" + objOrderDetail.Style.StyleID.ToString() + "," + OrderID.ToString() + ",-1);");


                    HideRow = true;
                }
                else
                {
                    imgStyle.Visible = false;
                }
                if (!String.IsNullOrEmpty(objOrderDetail.Style.SampleImageURL2))
                {
                    imgPrint.ImageUrl = "~/" + System.Configuration.ConfigurationManager.AppSettings["style.folder"] + System.Configuration.ConfigurationManager.AppSettings["image.prefix"] + objOrderDetail.Style.SampleImageURL2;
                    HideRow = true;
                }
                else
                {
                    imgPrint.Visible = false;
                }

                imgRow.Visible = HideRow;

                if (objOrderDetail.OrderBreakdown.Count == 0)
                {
                    return;
                }

                if (objOrderDetail.OrderBreakdown[0].Fabric1 != "")
                {

                    lblFabric1.Text = objOrderDetail.OrderBreakdown[0].Fabric1.Trim() + " : ";
                    lblFabric1.ToolTip = objOrderDetail.OrderBreakdown[0].Fabric1.Trim() + " : " + objOrderDetail.OrderBreakdown[0].Fabric1Details;
                    if (objOrderDetail.OrderFabrichistroy.Count > 0)
                    {
                        if (objOrderDetail.OrderFabrichistroy[0].Fab1BulkStatus.Trim() != "")
                        {
                            lblFab1Date.Text = "(" + objOrderDetail.OrderFabrichistroy[0].Fab1BulkStatus.Trim() + ")" == "" ? string.Empty : "(" + objOrderDetail.OrderFabrichistroy[0].Fab1BulkStatus.Trim() + ")";
                        }
                    }
                }
                if (objOrderDetail.OrderBreakdown[0].Fabric2 != "")
                {
                    lblFabric2.Text = objOrderDetail.OrderBreakdown[0].Fabric2.Trim() + " : ";
                    lblFabric2.ToolTip = objOrderDetail.OrderBreakdown[0].Fabric2.Trim() + " : " + objOrderDetail.OrderBreakdown[0].Fabric2Details;
                    if (objOrderDetail.OrderFabrichistroy.Count > 0)
                    {
                        if (objOrderDetail.OrderFabrichistroy[0].Fab2BulkStatus.Trim() != "")
                        {
                            lblFab2Date.Text = "(" + objOrderDetail.OrderFabrichistroy[0].Fab2BulkStatus.Trim() + ")" == "" ? string.Empty : "(" + objOrderDetail.OrderFabrichistroy[0].Fab2BulkStatus.Trim() + ")";
                        }
                    }
                }
                if (objOrderDetail.OrderBreakdown[0].Fabric3 != "")
                {
                    lblFabric3.Text = objOrderDetail.OrderBreakdown[0].Fabric3.Trim() + " : ";
                    lblFabric3.ToolTip = objOrderDetail.OrderBreakdown[0].Fabric3.Trim() + " : " + objOrderDetail.OrderBreakdown[0].Fabric3Details;
                    if (objOrderDetail.OrderFabrichistroy.Count > 0)
                    {
                        if (objOrderDetail.OrderFabrichistroy[0].Fab3BulkStatus.Trim() != "")
                        {
                            lblFab3Date.Text = "(" + objOrderDetail.OrderFabrichistroy[0].Fab3BulkStatus.Trim() + ")" == "" ? string.Empty : "(" + objOrderDetail.OrderFabrichistroy[0].Fab3BulkStatus.Trim() + ")";
                        }
                    }
                }
                if (objOrderDetail.OrderBreakdown[0].Fabric4 != "")
                {
                    lblFabric4.Text = objOrderDetail.OrderBreakdown[0].Fabric4.Trim() + " : ";
                    lblFabric4.ToolTip = objOrderDetail.OrderBreakdown[0].Fabric4.Trim() + " : " + objOrderDetail.OrderBreakdown[0].Fabric4Details;
                    if (objOrderDetail.OrderFabrichistroy.Count > 0)
                    {
                        if (objOrderDetail.OrderFabrichistroy[0].Fab4BulkStatus.Trim() != "")
                        {
                            lblFab4Date.Text = objOrderDetail.OrderFabrichistroy[0].Fab4BulkStatus.Trim() == "" ? string.Empty : "(" + objOrderDetail.OrderFabrichistroy[0].Fab4BulkStatus.Trim() + ")";
                        }
                    }
                }






                //lblFabric11.Text = objOrderDetail.OrderBreakdown[0].CCGSM1.Trim();
                //lblFabric12.Text = objOrderDetail.OrderBreakdown[0].CCGSM2.Trim();
                //lblFabric13.Text = objOrderDetail.OrderBreakdown[0].CCGSM3.Trim();
                //lblFabric14.Text = objOrderDetail.OrderBreakdown[0].CCGSM4.Trim();





                if (objOrderDetail.OrderFabrichistroy.Count > 0)
                {
                    if (objOrderDetail.OrderFabrichistroy[0].Fab1Precent != 0)
                    {
                        lblFab1Prcent.Text = "(" + objOrderDetail.OrderFabrichistroy[0].Fab1Precent.ToString() + ")" == "" ? string.Empty : "(" + objOrderDetail.OrderFabrichistroy[0].Fab1Precent.ToString() + "%)";
                    }
                }

                if (objOrderDetail.OrderFabrichistroy.Count > 0)
                {
                    if (objOrderDetail.OrderFabrichistroy[0].Fab2Precent != 0)
                    {
                        lblFab2Prcent.Text = "(" + objOrderDetail.OrderFabrichistroy[0].Fab2Precent.ToString() + ")" == "" ? string.Empty : "(" + objOrderDetail.OrderFabrichistroy[0].Fab2Precent.ToString() + "%)";
                    }
                }

                if (objOrderDetail.OrderFabrichistroy.Count > 0)
                {
                    if (objOrderDetail.OrderFabrichistroy[0].Fab3Precent != 0)
                    {
                        lblFab3Prcent.Text = "(" + objOrderDetail.OrderFabrichistroy[0].Fab3Precent.ToString() + ")" == "" ? string.Empty : "(" + objOrderDetail.OrderFabrichistroy[0].Fab3Precent.ToString() + "%)";
                    }
                }
                if (objOrderDetail.OrderFabrichistroy.Count > 0)
                {
                    if (objOrderDetail.OrderFabrichistroy[0].Fab4Precent != 0)
                    {
                        lblFab4Prcent.Text = "(" + objOrderDetail.OrderFabrichistroy[0].Fab4Precent.ToString() + ")" == "" ? string.Empty : "(" + objOrderDetail.OrderFabrichistroy[0].Fab4Precent.ToString() + "%)";
                    }
                }
                string MarchantNotes = objOrderDetail.MarchantNotes;
                hiddenMerchant.Value = MarchantNotes;
                string Remarks = objOrderDetail.Remarks;
                hdnRemarks.Value = Remarks;
                string strNotes = Constants.GetLastComments(MarchantNotes.ToString(), "$$", "....", 100);
                if (strNotes != "")
                {
                    string[] strMNotes = strNotes.Split('(');
                    lblMName.Text = strMNotes[0];
                    lblmerchantNotes.Text = "(" + strMNotes[1];
                }
                string strRemark = Constants.GetLastComments(Remarks.ToString(), "$$", "....", 100);
                if (strRemark != "")
                {
                    string[] strMRemark = strRemark.Split('(');
                    lblRName.Text = strMRemark[0];
                    lblFabricBulkRemark.Text = "(" + strMRemark[1];
                }

                //    lblmerchantNotes.Text = Constants.GetLastComments(MarchantNotes.ToString(), "$$", "....", 100);
                //  lblFabricBulkRemark.Text = Constants.GetLastComments(Remarks.ToString(), "$$", "....", 100);
                //accRemarksForlabel = iKandi.Common.Constants.GetLastComments(AccessaryRemarks.ToString(), "$$", ".....", 100);


                bool setTotalCount = false;

                setTotalCount = objOrderDetail.OrderBreakdown[0].OrderSizes == null || objOrderDetail.OrderBreakdown[0].OrderSizes.Count == 0;

                if (!setTotalCount)
                {
                    List<OrderDetailSizes> sizes = objOrderDetail.OrderBreakdown[0].OrderSizes.FindAll(delegate(OrderDetailSizes ods) { return ods.Quantity > 0; });

                    if (sizes.Count == 0)
                        setTotalCount = true;
                }

                if (setTotalCount)
                {
                    double totalQty = 0;

                    foreach (OrderDetail od in objOrderDetail.OrderBreakdown)
                    {
                        totalQty += od.Quantity;

                        od.OrderSizes = new List<OrderDetailSizes>();
                        OrderDetailSizes ods = new OrderDetailSizes();
                        ods.Quantity = od.Quantity;

                        od.OrderSizes.Add(ods);
                    }

                    hdnTotalCount.Value = (Math.Round(totalQty * (1.044))).ToString();
                }

                if (objOrderDetail.OrderBreakdown.Count > 0)
                {
                    repeaterOrderBreakdown.DataSource = objOrderDetail.OrderBreakdown;
                    repeaterOrderBreakdown.DataBind();
                }
                else
                {
                    repeaterOrderBreakdown.DataSource = "a";
                    repeaterOrderBreakdown.DataBind();
                }

                //rptFabricOrderSize.DataSource = objOrderDetail.OrderBreakdown[0].OrderSizes;
                //rptFabricOrderSize.DataBind();

                if (objOrderDetail.StatusModeSequence >= objOrderDetail.ORDER_CONFIRMED_SALES_StatusID)
                    btnSubmit.Visible = true;
            }
            //added by abhishek on  15/3/2016

            chkBoxAccountManager.Enabled = objAccessoryWorking.ApprovedByAccountManager > 0 ? false : true;

            if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Accessory_Manager)
            {
                chkBoxAccessoryManager.Enabled = true;
                chkBoxAccessoryManager.Enabled = objAccessoryWorking.ApprovedByAccessoryManager > 0 ? false : true;
            }
            else
            {
                chkBoxAccessoryManager.Enabled = false;
            }
            //end by abhishek on 15/3/2016

            //Add By Surendra on 09-5-2018
            PermissionController objpermissionController = new PermissionController();
            int IsOrderConfirm = objpermissionController.IsOrderConfirm(OrderID);
            if (IsOrderConfirm != 1)
            {
                btnSubmit.Visible = false;
            }
        }

        private void SaveFabricAccessoriesDetails(GridView grd)
        {
            //GridHeader(Convert.ToInt32(hdnAccesoriedID.Value), OrderID);
            if (grdAccessories.Columns.Count > 0)
            {
                grdAccessories.Columns.Clear();
            }
            grd.DataSource = null;
            if (OrderID < 0) return;
            // check if insertion is for valid order id  


            Boolean isNew = true;
            string differences = "";
            AccessoryWorking accessoryWorking = this.AccessoryWorkingControllerInstance.GetAccessoryWorking(OrderID);

            // AccessoryWorking accessoryWorkingDelete = this.AccessoryWorkingControllerInstance.GetAccessoryWorking(OrderID);

            if (accessoryWorking != null && accessoryWorking.AccessoryWorkingDetailCount != null)
            {
                isNew = false;
            }

            if (isNew)
            {
                accessoryWorking = new AccessoryWorking();
                accessoryWorking.Order = new iKandi.Common.Order();
                accessoryWorking.Order.OrderID = OrderID;
                if (chkBoxAccessoryManager.Checked)
                {
                    accessoryWorking.ApprovedByAccessoryManager = ApplicationHelper.LoggedInUser.UserData.UserID;
                    accessoryWorking.ApprovedByAccessoryManagerOn = DateTime.Now;
                }
                else
                {
                    accessoryWorking.ApprovedByAccessoryManagerOn = DateTime.MinValue;
                }
                if (chkBoxAccountManager.Checked)
                {
                    accessoryWorking.ApprovedByAccountManager = ApplicationHelper.LoggedInUser.UserData.UserID; // To Do: Need to change code as per Accessory Manager Id
                    accessoryWorking.ApprovedByAccountManagerOn = DateTime.Now;
                }
                else
                {
                    accessoryWorking.ApprovedByAccountManagerOn = DateTime.MinValue;
                }

                accessoryWorking.AccessoryWorkingDetail = new List<AccessoryWorkingDetail>();


                foreach (GridViewRow row in grd.Rows)
                {
                    AccessoryWorkingDetail accessoryWorkingDetail = new AccessoryWorkingDetail();
                    accessoryWorkingDetail.AccessoryName = ((HtmlInputText)row.FindControl("AccessoriesName")).Value;
                    //accessoryWorkingDetail.Number = Convert.ToDecimal(((HtmlInputText)row.FindControl("Number")).Value);
                    //accessoryWorkingDetail.Quantity = Convert.ToDecimal(((HtmlInputText)row.FindControl("txtQuantity")).Value);

                    if (((HtmlInputText)row.FindControl("Number")).Value != "")
                    {
                        accessoryWorkingDetail.Number = Convert.ToDecimal(((HtmlInputText)row.FindControl("Number")).Value);
                    }
                    else
                    {
                        accessoryWorkingDetail.Number = 0;
                    }
                    if (((HtmlInputText)row.FindControl("txtQuantity")).Value != "")
                    {
                        accessoryWorkingDetail.Quantity = Convert.ToDecimal(((HtmlInputText)row.FindControl("txtQuantity")).Value);
                    }
                    else
                    {
                        accessoryWorkingDetail.Number = 0;
                    }



                    accessoryWorkingDetail.Details = ((HtmlInputText)row.FindControl("txtDetails")).Value;
                    accessoryWorkingDetail.IsDTM = ((CheckBox)row.FindControl("IsDTM")).Checked;
                    accessoryWorkingDetail.FilePath = ((FileUpload)row.FindControl("UploadFiles")).FileName;
                    accessoryWorkingDetail.Swatch = ((Label)row.FindControl("Swatch")).Text;
                    accessoryWorkingDetail.IsOld = ((CheckBox)row.FindControl("Deleted")).Checked;

                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["Count"]) > 0)
                    {
                        string Strp1 = "";
                        string StrCN1 = "";
                        string p1 = "";
                        string CN1 = "";
                        string strFw = "";
                        string Fw1 = "";
                        int Count = Convert.ToInt32(ds.Tables[0].Rows[0]["Count"]);
                        for (int iCheck = 1; iCheck <= Count; iCheck++)
                        {
                            //if (accessoryWorkingDetail.AccessoryName.IndexOf("SHA") > 0 && accessoryWorkingDetail.AccessoryName.IndexOf("Thread") > 0)
                            //{
                            //    Fw1 = "";//((HtmlInputText)row.FindControl("FlatW" + iCheck)).Value;
                            //    strFw = "";//strFw + "," + Fw1;
                            //}
                            //else
                            //{
                            //    Fw1 = ((HtmlInputText)row.FindControl("FlatW" + iCheck)).Value;
                            //    strFw = strFw + "," + Fw1;
                            //}

                            Fw1 = ((HtmlInputText)row.FindControl("FlatW" + iCheck)).Value;
                            strFw = strFw + "," + Fw1;
                            p1 = ((HtmlInputText)row.FindControl("CP" + iCheck)).Value;
                            CN1 = ((HtmlInputText)row.FindControl("Cont" + iCheck)).Value;
                            Strp1 = Strp1 + "," + p1;
                            StrCN1 = StrCN1 + "," + CN1;
                        }
                        //
                        accessoryWorkingDetail.FinalFw1 = strFw.Remove(0, 1);
                        accessoryWorkingDetail.FinalP1 = Strp1.Remove(0, 1);
                        accessoryWorkingDetail.FinalCN1 = StrCN1.Remove(0, 1);

                    }
                    // accessoryWorking = new AccessoryWorking();
                    accessoryWorking.AccessoryWorkingDetail.Add(accessoryWorkingDetail);
                    //AccessoryWorkingControllerInstance.AllAccessoryDetailsSave(AccessoriesName, Number, txtQuantity, txtDetails, IsDTM, UploadFiles, Swatch);
                }

                differences = this.ShowDifferences(accessoryWorking);
                accessoryWorking.History = differences;
                accessoryWorking = this.AccessoryWorkingControllerInstance.InsertAccessoryWorking(accessoryWorking);
            }
            else
            {
                if (chkBoxAccessoryManager.Checked && chkBoxAccessoryManager.Enabled)
                {
                    accessoryWorking.ApprovedByAccessoryManager = ApplicationHelper.LoggedInUser.UserData.UserID;
                    accessoryWorking.ApprovedByAccessoryManagerOn = DateTime.Now;
                }
                if (chkBoxAccountManager.Checked && chkBoxAccountManager.Enabled)
                {
                    accessoryWorking.ApprovedByAccountManager = ApplicationHelper.LoggedInUser.UserData.UserID; // To Do: Need to change code as per Accessory Manager Id
                    accessoryWorking.ApprovedByAccountManagerOn = DateTime.Now;
                }


                int i = 0;
                foreach (GridViewRow row in grdAccessories.Rows)
                {
                    if (i >= accessoryWorking.AccessoryWorkingDetailCount.Count)
                    // if (i >= 12)
                    {
                        accessoryWorking.AccessoryWorkingDetailCount.Add(new AccessoryWorkingDetail());
                    }

                    accessoryWorking.AccessoryWorkingDetailCount[i].AccessoryName = ((HtmlInputText)row.FindControl("AccessoriesName")).Value;
                    //accessoryWorking.AccessoryWorkingDetailCount[i].Number = Convert.ToDecimal(((HtmlInputText)row.FindControl("Number")).Value);
                    //accessoryWorking.AccessoryWorkingDetailCount[i].Quantity = Convert.ToDecimal(((HtmlInputText)row.FindControl("txtQuantity")).Value);

                    if (((HtmlInputText)row.FindControl("Number")).Value != "")
                    {
                        accessoryWorking.AccessoryWorkingDetailCount[i].Number = Convert.ToDecimal(((HtmlInputText)row.FindControl("Number")).Value);
                    }
                    else
                    {
                        accessoryWorking.AccessoryWorkingDetailCount[i].Number = 0;
                    }
                    if (((HtmlInputText)row.FindControl("txtQuantity")).Value != "")
                    {
                        accessoryWorking.AccessoryWorkingDetailCount[i].Quantity = Convert.ToDecimal(((HtmlInputText)row.FindControl("txtQuantity")).Value);
                    }
                    else
                    {
                        accessoryWorking.AccessoryWorkingDetailCount[i].Quantity = 0;
                    }

                    accessoryWorking.AccessoryWorkingDetailCount[i].Details = ((HtmlInputText)row.FindControl("txtDetails")).Value;
                    accessoryWorking.AccessoryWorkingDetailCount[i].IsDTM = ((CheckBox)row.FindControl("IsDTM")).Checked;
                    accessoryWorking.AccessoryWorkingDetailCount[i].FilePath = ((FileUpload)row.FindControl("UploadFiles")).FileName;
                    accessoryWorking.AccessoryWorkingDetailCount[i].Swatch = ((Label)row.FindControl("Swatch")).Text;
                    accessoryWorking.AccessoryWorkingDetailCount[i].IsOld = ((CheckBox)row.FindControl("Deleted")).Checked;

                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["Count"]) > 0)
                    {
                        string Strp1 = "";
                        string StrCN1 = "";
                        string p1 = "";
                        string CN1 = "";
                        string strFw = "";
                        string Fw1 = "";
                        int Count = Convert.ToInt32(ds.Tables[0].Rows[0]["Count"]);
                        for (int iCheck = 1; iCheck <= Count; iCheck++)
                        {
                            //if (accessoryWorking.AccessoryWorkingDetailCount[i].AccessoryName.IndexOf("SHA") > 0 && accessoryWorking.AccessoryWorkingDetailCount[i].AccessoryName.IndexOf("Thread") > 0)
                            //{
                            //    Fw1 = "";//((HtmlInputText)row.FindControl("FlatW" + iCheck)).Value;
                            //    strFw = "";//strFw + "," + Fw1;
                            //}
                            //else
                            //{
                            //    Fw1 = ((HtmlInputText)row.FindControl("FlatW" + iCheck)).Value;
                            //    strFw = strFw + "," + Fw1;
                            //}

                            Fw1 = ((HtmlInputText)row.FindControl("FlatW" + iCheck)).Value;
                            p1 = ((HtmlInputText)row.FindControl("CP" + iCheck)).Value;
                            CN1 = ((HtmlInputText)row.FindControl("Cont" + iCheck)).Value;

                            strFw = strFw + "," + Fw1;
                            Strp1 = Strp1 + "," + p1;
                            StrCN1 = StrCN1 + "," + CN1;
                        }

                        accessoryWorking.AccessoryWorkingDetailCount[i].FinalFw1 = strFw.Remove(0, 1);
                        accessoryWorking.AccessoryWorkingDetailCount[i].FinalP1 = Strp1.Remove(0, 1);
                        accessoryWorking.AccessoryWorkingDetailCount[i].FinalCN1 = StrCN1.Remove(0, 1);

                    }

                    // accessoryWorking.AccessoryWorkingDetail.Add(accessoryWorkingDetail);
                    //AccessoryWorkingControllerInstance.AllAccessoryDetailsSave(AccessoriesName, Number, txtQuantity, txtDetails, IsDTM, UploadFiles, Swatch);
                    i++;
                }

                differences = this.ShowDifferences(accessoryWorking);
                try
                {
                    //if (differences == string.Empty)
                    //{
                    //    diffe
                    //}

                    accessoryWorking.History = accessoryWorking.History + "$$" + differences;

                    accessoryWorking = this.AccessoryWorkingControllerInstance.UpdateAccessoryWorking(accessoryWorking, differences);
                }
                catch (Exception ex)
                {
                    string script = "ShowHideMessageBox(true,  'Data that you want to delete belongs to Inline PPM Forms, System is unable to delete data" + " !', 'Unable To Update System Data', '', '/internal/Fabric/FabricAccessoriesWorkSheet.aspx?orderid=" + OrderID + "');";
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "scr", script, true);
                    return;
                }


                //addde by abhishek 16/5/2016
                DeleteUserSession(User_Session);

            }

            objAccessoryWorking = accessoryWorking;
            DeleteUserSession(User_Session);
            //rptAccessories.DataSource = objAccessoryWorking.AccessoryWorkingDetail;
            //rptAccessories.DataBind();

            pnlForm.Visible = false;
            pnlMessage.Visible = true;
            DeleteUserSession(User_Session);
        }
        // addde by abhishek 16/5/2016
        public void DeleteUserSession(string User_Session)
        {
            this.AccessoryWorkingControllerInstance.DropUserSessions(this.User_Session);

        }

        private String SaveUploadedFile(FileUpload FileUploadCtrl)
        {
            if (FileUploadCtrl.HasFile)
            {
                return FileHelper.SaveFile(FileUploadCtrl.PostedFile.InputStream, FileUploadCtrl.FileName, Constants.ACCESSORY_FOLDER_PATH, true, string.Empty);
            }
            else
            {
                return "";
            }
        }

        private String GetFilePath(Image objImg)
        {
            String ImageName = objImg.ImageUrl.Length > 0 ? objImg.ImageUrl.Split('\\')[objImg.ImageUrl.Split('\\').Length - 1] : String.Empty;

            if (ImageName.Length > 0 && System.Configuration.ConfigurationManager.AppSettings["image.prefix"].Length > 0)
            {
                ImageName = ImageName.Replace(System.Configuration.ConfigurationManager.AppSettings["image.prefix"].ToString(), String.Empty);

                int index = ImageName.LastIndexOf("/");

                ImageName = ImageName.Substring(index + 1);

            }

            return ImageName;
        }

        private string ShowDifferences(iKandi.Common.AccessoryWorking accessoryWorking)
        {
            string Differences = "";
            int i = 0;


            NotificationEmailHistory NEH = new NotificationEmailHistory();
            BLL.NotificationController nn = new BLL.NotificationController();
            NEH.Type = "101";
            NEH.EmailID = "13";
            NEH.OrderDetailsID = "-1";
            NEH.OrderID = OrderID.ToString();
            DataTable dtComleteData = new DataTable();
            AccessoryWorking accessoryWorkingOld = this.AccessoryWorkingControllerInstance.GetAccessoryWorking(OrderID);

            if (ViewState["dtCompleteData"] != null)
            {
                dtComleteData = (DataTable)ViewState["dtCompleteData"];
            }
            //if (accessoryWorkingOld.AccessoryWorkingDetailCount != null && accessoryWorkingOld.AccessoryWorkingDetailCount.Count > 0)
            //{
            //    int RowcountDiff = accessoryWorking.AccessoryWorkingDetailCount.Count - accessoryWorkingOld.AccessoryWorkingDetailCount.Count;
            //    if (RowcountDiff < 0)
            //    {

            //    }
            //    else
            //    {
            if (dtComleteData.Rows.Count > 0 && accessoryWorking.AccessoryWorkingDetailCount != null)
            {
                foreach (AccessoryWorkingDetail aw in accessoryWorking.AccessoryWorkingDetailCount)
                {
                    if (dtComleteData.Rows.Count >= i + 1)
                    {
                        if (dtComleteData.Rows[i]["AccessoryName"].ToString() != accessoryWorking.AccessoryWorkingDetailCount[i].AccessoryName)
                        {
                            // Abhishek updated  2/5/2016
                            //Differences = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + "</b> <b>" + lblStyleNumber.Text + "</b>" + " AccessoryName changed by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + "</b> <b>" + accessoryWorking.AccessoryWorkingDetailCount[i].AccessoryName + "</b> was <b>" + dtComleteData.Rows[i]["AccessoryName"].ToString() + "</b>";
                            //NEH.Remarks = Differences;
                            //nn.NotificationEmailHistory_Ins(NEH);
                            Differences = DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "Type changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + accessoryWorking.AccessoryWorkingDetailCount[i].AccessoryName + " was " + accessoryWorkingOld.AccessoryWorkingDetailCount[i].AccessoryName;


                            NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + "</b> <b>" + lblStyleNumber.Text + "</b>" + " AccessoryName changed by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + "</b> <b>" + accessoryWorking.AccessoryWorkingDetailCount[i].AccessoryName + "</b> was <b>" + dtComleteData.Rows[i]["AccessoryName"].ToString() + "</b>"; ;
                            nn.NotificationEmailHistory_Ins(NEH);

                        }

                        if (Math.Round(Convert.ToDouble(dtComleteData.Rows[i]["Quantity"]), 0).ToString() != Math.Round(accessoryWorking.AccessoryWorkingDetailCount[i].Quantity, 0).ToString())
                        {

                            Differences = DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + accessoryWorking.AccessoryWorkingDetailCount[i].AccessoryName + " : " + "Quantity changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + Math.Round(accessoryWorking.AccessoryWorkingDetailCount[i].Quantity, 0).ToString() + " was " + Math.Round(Convert.ToDouble(dtComleteData.Rows[i]["Quantity"]), 0).ToString();
                            NEH.Remarks = DateTime.Now.ToString("dd MMM yy (ddd)") + ": <b>" + lblSerial.Text + "</b> <b>" + lblStyleNumber.Text + "</b>" + "<b>" + accessoryWorking.AccessoryWorkingDetailCount[i].AccessoryName + "</b>" + " Quantity changed by <b>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + "</b> <b>" + Math.Round(accessoryWorking.AccessoryWorkingDetailCount[i].Quantity, 0).ToString() + "</b> was <b>" + Math.Round(Convert.ToDouble(dtComleteData.Rows[i]["Quantity"]), 0).ToString() + "</b>"; ;
                            nn.NotificationEmailHistory_Ins(NEH);

                        }
                    }

                    i++;
                }
                ViewState["dtCompleteData"] = null;

            }



            return Differences;
        }


        protected void GridHeader(int orderid, int accesoriesID, string userSession)
        {
            // add by sushil on date 27/3/2015
            DataTable CNtooltip = new DataTable();
            CNtooltip = AccessoryWorkingControllerInstance.Getfabrictooltip(OrderID).Tables[0];
            ViewState["fabinfo"] = CNtooltip;
            // END by sushil on date 27/3/2015
            dsCompleteData = null;

            ds = AccessoryWorkingControllerInstance.GetAllAccessoryDetails(OrderID, accesoriesID, userSession);

            for (int iOrderCount = 1; iOrderCount < Convert.ToInt32(ds.Tables[0].Rows[0]["Count"]) + 1; iOrderCount++)
            {
                AccessoryWorkingControllerInstance.GetCountAccesoriesDetails(orderid, accesoriesID, iOrderCount, userSession);
            }
            if (ViewState["dtnew"] == null)
            {
                dsCompleteData = AccessoryWorkingControllerInstance.GetAllAccessoryDetailsCompleteData(orderid, accesoriesID, userSession);
                if (ViewState["dtCompleteData"] == null)
                    ViewState["dtCompleteData"] = dsCompleteData.Tables[0];
            }

            int i1 = 0;
            int i2 = 0;
            int i3 = 0;
            int i4 = 0;

            if (grdAccessories.Columns.Count > 0)
            {
                grdAccessories.Columns.Clear();

            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                TemplateField AccessoriesName = new TemplateField();
                AccessoriesName.HeaderText = "Accessories";
                AccessoriesName.ItemTemplate = new iKandi.Common.GridViewTemplate("textBox", "AccessoriesName", "AccessoriesName");
                AccessoriesName.ItemStyle.CssClass = "accorforstyle13 minWidth";
                //AccessoriesName.ItemStyle.Width = 250;
                grdAccessories.Columns.Insert(0, AccessoriesName);



                TemplateField txtNumber = new TemplateField();
                txtNumber.HeaderText = "Number";
                txtNumber.ItemTemplate = new iKandi.Common.GridViewTemplate("textBox", "Number", "txtNumber");
                txtNumber.ItemStyle.CssClass = "accorforstyle14";
                txtNumber.ItemStyle.CssClass = "accorforstyle15";
                txtNumber.ItemStyle.Width = 100;

                txtNumber.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                grdAccessories.Columns.Insert(1, txtNumber);


                if (Convert.ToInt32(ds.Tables[0].Rows[0]["Count"]) > 0)
                {

                    int Count = Convert.ToInt32(ds.Tables[0].Rows[0]["Count"]);
                    hdnCNCount.Value = Convert.ToInt32(Count).ToString();
                    for (int i = 1; i <= Count; i++)
                    {

                        if (Count == 1)
                        {
                            i1 = i + 1;
                            i2 = i + 2;
                            i3 = i + 3;

                            TemplateField FW = new TemplateField();
                            FW.HeaderText = "% Flat Wst.";
                            FW.ItemTemplate = new iKandi.Common.GridViewTemplate("textBox", "txtFw" + i, "txtExtra" + i);
                            FW.ItemStyle.CssClass = "accorforstyle14";
                            FW.ItemStyle.Width = 60;
                            FW.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                            grdAccessories.Columns.Insert(i1, FW);
                            grdAccessories.HeaderStyle.Height = 59;


                            TemplateField Extra = new TemplateField();
                            Extra.HeaderText = "% Wastage";
                            Extra.ItemTemplate = new iKandi.Common.GridViewTemplate("textBox", "txtExtra" + i, "txtExtra" + i);
                            Extra.ItemStyle.CssClass = "accorforstyle14";
                            Extra.ItemStyle.Width = 50;
                            Extra.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                            grdAccessories.Columns.Insert(i2, Extra);
                            grdAccessories.HeaderStyle.Height = 59;

                            TemplateField CN = new TemplateField();
                            CN.HeaderText = "CN" + i;
                            CN.ItemTemplate = new iKandi.Common.GridViewTemplate("textBox", "CN" + i, "CN" + i);
                            CN.ItemStyle.CssClass = "accorforstyle14";
                            CN.ItemStyle.Width = 70;
                            CN.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                            grdAccessories.Columns.Insert(i3, CN);
                        }
                        else
                        {
                            if (i == 1)
                            {
                                i1 = i + 1;
                                i2 = i1 + 1;
                                i3 = i2 + 1;
                            }
                            else
                            {
                                i1 = i4;
                                i2 = i1 + 1;
                                i3 = i2 + 1;
                            }

                            TemplateField FW = new TemplateField();
                            FW.HeaderText = "% Flat Wst.";
                            FW.ItemTemplate = new iKandi.Common.GridViewTemplate("textBox", "txtFw" + i, "txtExtra" + i);
                            FW.ItemStyle.CssClass = "accorforstyle14";
                            //Extra.ItemStyle.Width = 80;
                            FW.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                            grdAccessories.Columns.Insert(i1, FW);
                            grdAccessories.HeaderStyle.Height = 59;


                            TemplateField Extra = new TemplateField();
                            Extra.HeaderText = "% Wastage" + i;
                            Extra.ItemTemplate = new iKandi.Common.GridViewTemplate("textBox", "txtExtra" + i, "txtExtra" + i);
                            Extra.ItemStyle.CssClass = "accorforstyle14";
                            //Extra.ItemStyle.Width = 80;
                            Extra.ItemStyle.HorizontalAlign = HorizontalAlign.Center;

                            grdAccessories.Columns.Insert(i2, Extra);

                            TemplateField CN = new TemplateField();
                            CN.HeaderText = "CN" + i;
                            CN.ItemTemplate = new iKandi.Common.GridViewTemplate("textBox", "CN" + i, "CN" + i);
                            CN.ItemStyle.CssClass = "accorforstyle14";
                            //CN.ItemStyle.Width = 80;
                            CN.ItemStyle.HorizontalAlign = HorizontalAlign.Center;

                            grdAccessories.Columns.Insert(i3, CN);
                            i4 = i3 + 1;
                        }

                    }
                }
                TemplateField Total = new TemplateField();
                Total.HeaderText = "Total Quantity";
                Total.ItemTemplate = new iKandi.Common.GridViewTemplate("textBox", "txtQuantity", "txtQuantity");
                Total.ItemStyle.CssClass = "accorforstyle14 ";
                Total.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                //Total.ItemStyle.Width = 120;

                grdAccessories.Columns.Insert(i3 + 1, Total);

                TemplateField Details = new TemplateField();
                Details.HeaderText = "Details";
                Details.ItemTemplate = new iKandi.Common.GridViewTemplate("textBox", "txtDetails", "txtDetails");
                Details.ItemStyle.CssClass = "accorforstyle14";
                Details.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //Details.ItemStyle.Width = 200;

                grdAccessories.Columns.Insert(i3 + 2, Details);

                TemplateField isDTM = new TemplateField();
                isDTM.HeaderText = "IsDTM";
                isDTM.ItemTemplate = new iKandi.Common.GridViewTemplate("checkbox", "IsDTM", "IsDTM");
                isDTM.ItemStyle.CssClass = "accorforstyle14";
                isDTM.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //isDTM.ItemStyle.Width = 80;

                grdAccessories.Columns.Insert(i3 + 3, isDTM);

                TemplateField File = new TemplateField();
                File.HeaderText = "UploadFiles";
                File.ItemTemplate = new iKandi.Common.GridViewTemplate("file", "UploadFiles", "UploadFiles");
                File.ItemStyle.CssClass = "accorforstyle14";
                File.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //File.ItemStyle.Width = 150;

                grdAccessories.Columns.Insert(i3 + 4, File);

                TemplateField swatch = new TemplateField();
                swatch.HeaderText = "Swatch";
                swatch.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "Swatch", "Swatch");
                swatch.ItemStyle.CssClass = "accorforstyle14";
                swatch.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //swatch.ItemStyle.Width = 210;

                grdAccessories.Columns.Insert(i3 + 5, swatch);

                TemplateField Deleted = new TemplateField();
                Deleted.HeaderText = "Deleted";
                Deleted.ItemTemplate = new iKandi.Common.GridViewTemplate("checkbox", "Deleted", "Deleted");
                Deleted.ItemStyle.CssClass = "accorforstyle14";
                Deleted.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                //Deleted.ItemStyle.Width = 80;

                grdAccessories.Columns.Insert(i3 + 6, Deleted);

            }

            if (ViewState["dtnew"] == null)
            {
                //grdAccessories.DataSource = dsCompleteData.Tables[0];
                //DataTable dtnew = new DataTable();
                //dtnew = (DataTable)(ViewState["dtnew"]);
                grdAccessories.DataSource = dsCompleteData.Tables[0];
                grdAccessories.DataBind();
            }
            else
            {

                DataTable dtnew = new DataTable();
                dtnew = (DataTable)(ViewState["dtnew"]);
                //for (int i = 0; i < dtmerge.Rows.Count; i++)
                //{
                //    int Count = Convert.ToInt32(ds.Tables[0].Rows[0]["Count"]);
                //    for(int j=)

                //}
                grdAccessories.DataSource = dtnew;
                grdAccessories.DataBind();
            }
        }


        protected void grdAccessories_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // ViewState["fabinfo"] add by sushil for tooltip on date 25/3/3015
            // updated  By sushil on 26/3/2015
            if (e.Row.RowType == DataControlRowType.Header)
            {
                int incmt = 0;
                DataTable dtfab = new DataTable();
                dtfab = (DataTable)(ViewState["fabinfo"]);
                if (dtfab.Rows.Count > 0)
                {
                    foreach (TableCell cell in e.Row.Cells)
                    {

                        string cellval = "";
                        cellval = cell.Text.Substring(0, 2);
                        if (cellval == "CN")
                        {
                            if (dtfab.Rows.Count > incmt)
                            {
                                cell.Attributes.Add("title", dtfab.Rows[incmt]["Fabtooltip"].ToString());
                            }
                            incmt++;
                        }
                    }
                }
            }
            //End updated  By sushil on 26/3/2015
            //............  /////
            int FW1 = 0;
            int P1 = 0;
            int CN1 = 0;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                OrderDetail od = (e.Row.DataItem as OrderDetail);
                DataRowView drv = (DataRowView)e.Row.DataItem;
                string Accessories = drv["AccessoryName"] == DBNull.Value ? "" : drv["AccessoryName"].ToString();
                decimal Number = drv["Number"] == DBNull.Value ? 0 : Convert.ToDecimal(drv["Number"].ToString());

                int quantity = drv["quantity"] == DBNull.Value ? 0 : Convert.ToInt32(drv["quantity"]);
                string Details = drv["Details"] == DBNull.Value ? "" : Convert.ToString(drv["Details"]);
                bool IsDTM = drv["IsDTM"] == DBNull.Value ? false : Convert.ToBoolean(drv["IsDTM"]);
                string File = drv["UploadFiles"] == DBNull.Value ? "" : drv["UploadFiles"].ToString();
                string Swaatch = drv["Swatch"] == DBNull.Value ? "" : drv["Swatch"].ToString();

                HtmlInputText AccessoriesName = e.Row.FindControl("AccessoriesName") as HtmlInputText;
                AccessoriesName.Value = Accessories;
                AccessoriesName.Style.Add("height", "25px");
                AccessoriesName.Style.Add("width", "98%");
                AccessoriesName.Style.Add("border", "none");
                AccessoriesName.Attributes.Add("class", "AccessoriesName accorforstyle10");
                AccessoriesName.Attributes.Add("onkeypress", "javascript:return isSpecialKey(event)");
                if (ApplicationHelper.LoggedInUser.UserData.DesignationID == 45)
                    AccessoriesName.Attributes.Add("onblur", "javascript:return CheckThreadName(this)");

                HtmlInputText number = e.Row.FindControl("Number") as HtmlInputText;
                number.Value = Number.ToString();
                number.Style.Add("height", "25px");
                number.Style.Add("width", "50px");
                number.Style.Add("text-align", "center");
                number.Attributes.Add("class", "accorforstyle10");
                number.Style.Add("border", "none");
                //number.Attributes.Add("onblur", "javascript:return CalculateNumber(this)");
                number.Attributes.Add("onkeypress", "javascript:return CalculateNumber(this)");


                if (Convert.ToInt32(ds.Tables[0].Rows[0]["Count"]) > 0)
                {
                    DataTable dtnew = new DataTable();
                    DataSet dsTotQty = new DataSet();
                    int j = 0;
                    int tcount = 0;
                    int Totalcont = 0;
                    decimal ECN = 0;
                    int Total = 0;
                    int FinalQty = 0;
                    int Count = Convert.ToInt32(ds.Tables[0].Rows[0]["Count"]);
                    for (int i = 1; i <= Count; i++)
                    {
                        dsTotQty = AccessoryWorkingControllerInstance.GetOrderQuantity(OrderID);

                        decimal EFW = drv["FW" + i] == DBNull.Value ? 0 : Convert.ToDecimal(drv["FW" + i].ToString());
                        // ********************** Bellow code updated by Ravikumar 20 july *******************
                        if (Accessories.ToLower().Contains("sha") == true)
                        {
                            if (EFW == -1)
                                EFW = 2;
                            else if (Convert.ToDecimal(drv["FW" + i].ToString()) == 0)
                                EFW = 0;
                        }
                        else
                        {
                            if (EFW == 0)
                                EFW = 2;
                        }
                        // ********************** End of code updated by Ravikumar 20 july *******************
                        decimal EP = drv["P" + i] == DBNull.Value ? 0 : Convert.ToDecimal(drv["P" + i].ToString());


                        if (ViewState["dtnew"] == null)
                        {
                            j = i - 1;
                            if (dsTotQty.Tables[0].Rows.Count > 0)
                            {
                                tcount = Convert.ToInt32(dsTotQty.Tables[0].Rows[j]["Quantity"]);
                                ECN = Convert.ToInt32(dsTotQty.Tables[0].Rows[j]["Quantity"]);

                                Total = Convert.ToInt32(Convert.ToDecimal(((tcount * Convert.ToDecimal(Number)) * (1 + ((Convert.ToDecimal(EFW / 100)) + (Convert.ToDecimal(EP / 100)))))));
                            }
                            else
                            {
                                Total = 0;
                                ECN = 0;
                            }
                            //tcount = Convert.ToInt32(dsCompleteData.Tables[0].Rows[0]["CNTotal" + i]);
                        }
                        else
                        {
                            j = i - 1;
                            dtnew = (DataTable)(ViewState["dtnew"]);
                            //tcount = Convert.ToInt32(dtnew.Rows[0]["CNTotal" + i]);
                            tcount = Convert.ToInt32(dsTotQty.Tables[0].Rows[j]["Quantity"]);

                        }
                        int FW = (FW1 + i);
                        int P = (P1 + i);
                        int CN = (CN1 + i);
                        //int Totalcont = drv["CNTotal" + i] == DBNull.Value ? 0 : Convert.ToInt32(drv["CNTotal" + i].ToString());

                        if (EFW == 0 && AccessoriesName.Value == "")
                        {
                            EFW = 2;
                        }


                        if (dsTotQty.Tables[0].Rows.Count > 0)
                        {
                            j = i - 1;
                            Totalcont = Convert.ToInt32(dsTotQty.Tables[0].Rows[j]["Quantity"]);
                            ECN = Convert.ToInt32(dsTotQty.Tables[0].Rows[j]["Quantity"]);
                            Total = Convert.ToInt32(Convert.ToDecimal(((tcount * Convert.ToDecimal(Number)) * (1 + ((Convert.ToDecimal(EFW / 100)) + (Convert.ToDecimal(EP / 100)))))));
                        }
                        else
                        {
                            Total = 0;
                            ECN = 0;
                        }

                        FinalQty += Total;

                        //decimal ECN = drv["CN" + i] == DBNull.Value ? 0 : Convert.ToDecimal(drv["CN" + i].ToString());

                        HtmlInputText FlatW = e.Row.FindControl("txtFW" + i) as HtmlInputText;
                        //CP.Value = P1.ToString();
                        FlatW.ID = "FlatW" + i;
                        // ********************** Bellow code updated by Ravikumar 20 july *******************

                        //    //FlatW.Value = "2"; // EFW.ToString();
                        FlatW.Value = EFW.ToString(); // EFW.ToString();

                        // *************** End ofBellow code updated by Ravikumar 20 july *******************
                        FlatW.Style.Add("height", "25px");
                        FlatW.Style.Add("width", "50px");
                        FlatW.Style.Add("text-align", "center");
                        FlatW.Attributes.Add("class", "accorforstyle3");
                        FlatW.Style.Add("border", "none");
                        // ********************** Bellow code updated by Ravikumar 20 july *******************

                        //    //FlatW.Value = "2"; // EFW.ToString();

                        if (Accessories.ToLower().Contains("sha") == false)
                        {
                            FlatW.Attributes.Add("readonly", "readonly");
                        }
                        // *************** End ofBellow code updated by Ravikumar 20 july *******************


                        HtmlInputText ExtraP = e.Row.FindControl("txtExtra" + i) as HtmlInputText;
                        //CP.Value = P1.ToString();

                        ExtraP.ID = "CP" + i;
                        ExtraP.Value = EP.ToString();
                        ExtraP.Style.Add("height", "25px");
                        ExtraP.Style.Add("width", "50px");
                        ExtraP.Style.Add("text-align", "center");
                        ExtraP.Attributes.Add("class", "accorforstyle10");
                        ExtraP.Style.Add("border", "none");
                        //ExtraP.Attributes.Add("onkeypress", "javascript:return CalculateContract(this)");
                        ExtraP.Attributes.Add("onchange", "javascript:return CalculateContract(this)");

                        HtmlInputText Cont = e.Row.FindControl("CN" + i) as HtmlInputText;
                        Cont.ID = "Cont" + i;
                        Cont.Value = Total.ToString();
                        Cont.Style.Add("height", "25px");
                        Cont.Style.Add("width", "50px");
                        Cont.Style.Add("text-align", "center");
                        Cont.Attributes.Add("class", "accorforstyle3");
                        Cont.Style.Add("border", "none");
                        Cont.Attributes.Add("readonly", "readonly");
                        HtmlInputHidden hypECN = new HtmlInputHidden();
                        if (Totalcont == 0)
                        {
                            hypECN.Value = tcount.ToString();
                        }
                        else
                        {
                            hypECN.Value = Totalcont.ToString();
                        }
                        hypECN.ID = "hdyECN" + i;
                        e.Row.Cells[0].Controls.Add(hypECN);

                    }

                    HtmlInputText qty = e.Row.FindControl("txtQuantity") as HtmlInputText;
                    //qty.Value = quantity.ToString();
                    qty.Value = FinalQty.ToString();
                    qty.Style.Add("height", "25px");
                    qty.Style.Add("width", "50px");
                    qty.Attributes.Add("class", "accorforstyle3");
                    qty.Style.Add("padding-left", "5px");
                    qty.Attributes.Add("readonly", "readonly");
                    qty.Style.Add("text-align", "center");

                    HtmlInputHidden hypqty = new HtmlInputHidden();
                    hypqty.Value = quantity.ToString();
                    hypqty.ID = "hypqty";
                    e.Row.Cells[0].Controls.Add(hypqty);


                    HtmlInputText Details1 = e.Row.FindControl("txtDetails") as HtmlInputText;
                    Details1.Value = Details.ToString();
                    Details1.Style.Add("height", "25px");
                    Details1.Attributes.Add("class", "accorforstyle10");
                    Details1.Style.Add("width", "150px");
                    Details1.Style.Add("text-align", "center");
                    Details1.Attributes.Add("cols", "40");
                    Details1.Attributes.Add("rows", "5");

                    CheckBox chk = e.Row.FindControl("IsDTM") as CheckBox;
                    chk.Checked = IsDTM;


                    FileUpload FileUpload = e.Row.FindControl("UploadFiles") as FileUpload;

                    FileUpload.Style.Add("width", "50px");
                    FileUpload.Style.Add("text-align", "center");
                    FileUpload.Style.Add("vertical-align", "middle");
                    FileUpload.Style.Add("text-align", "center");

                    Label Swt = e.Row.FindControl("Swatch") as Label;
                    Swt.Text = Swaatch;
                    Swt.Style.Add("height", "25px");
                    Swt.Style.Add("width", "10%");
                    Swt.Style.Add("text-align", "center");
                    //isDTM

                    CheckBox chkDelete = e.Row.FindControl("Deleted") as CheckBox;
                    // chkDelete.Checked = IsDTM;
                }
            }

        }



        protected void grdAccessories_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void imgBtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            if (ViewState["dtnew"] != null)
            {
                DataTable dtnew = new DataTable();
                dtnew = (DataTable)(ViewState["dtnew"]);
                DataRow newrow = dtnew.NewRow();
                dtnew.Rows.Add(newrow);

                //DataRow newrow1 = dsCompleteData.Tables[0].NewRow();
                //DataTable dtAddNew = new DataTable();
                dtmerge = dtnew;
                grdAccessories.DataSource = dtmerge;
                grdAccessories.DataBind();
                ViewState["dtnew"] = dtmerge;
            }
            else
            {
                DataRow newrow = dsCompleteData.Tables[0].NewRow();
                dsCompleteData.Tables[0].Rows.Add(newrow);
                //newrow.ItemArray = objrow;

                dtmerge = dsCompleteData.Tables[0];
                grdAccessories.DataSource = dtmerge;
                grdAccessories.DataBind();
                ViewState["dtnew"] = dtmerge;
            }
        }


        protected void grdCuttingOption1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId1");
                HiddenField hndSize1 = (HiddenField)e.Row.FindControl("hndSize1");
                HiddenField hndSize2 = (HiddenField)e.Row.FindControl("hndSize2");
                HiddenField hndSize3 = (HiddenField)e.Row.FindControl("hndSize3");
                HiddenField hndSize4 = (HiddenField)e.Row.FindControl("hndSize4");
                HiddenField hndSize5 = (HiddenField)e.Row.FindControl("hndSize5");
                HiddenField hndSize6 = (HiddenField)e.Row.FindControl("hndSize6");
                HiddenField hndSize7 = (HiddenField)e.Row.FindControl("hndSize7");
                HiddenField hndSize8 = (HiddenField)e.Row.FindControl("hndSize8");
                HiddenField hndSize9 = (HiddenField)e.Row.FindControl("hndSize9");
                HiddenField hndSize10 = (HiddenField)e.Row.FindControl("hndSize10");
                HiddenField hndSize11 = (HiddenField)e.Row.FindControl("hndSize11");
                HiddenField hndSize12 = (HiddenField)e.Row.FindControl("hndSize12");

                Label lblMinsize1 = (Label)e.Row.FindControl("lblMinsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblMinsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblMinsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblMinsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblMinsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblMinsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblMinsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblMinsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblMinsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblMinsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblMinsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblMinsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblMinsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblMinsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblMinsize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblMinTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);


                if (lblMinsize1 != null)
                {


                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 1);


                    if (strODId1 == "")
                    {
                        strODId1 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId1 = strODId1 + "," + OrderDetailId.ToString();
                    }
                    //strODId = strODId + ',' + strODId;
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        grdCuttingOption1.HeaderRow.Cells[1].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();
                        //lblMaxSize1.Text = Math.Round(Convert.ToDecimal(lblMinsize1.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize1.Text) * (4.4 / 100)))).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        grdCuttingOption1.HeaderRow.Cells[2].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        grdCuttingOption1.HeaderRow.Cells[3].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        grdCuttingOption1.HeaderRow.Cells[4].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        grdCuttingOption1.HeaderRow.Cells[5].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        grdCuttingOption1.HeaderRow.Cells[6].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        grdCuttingOption1.HeaderRow.Cells[7].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        grdCuttingOption1.HeaderRow.Cells[8].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        grdCuttingOption1.HeaderRow.Cells[9].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        grdCuttingOption1.HeaderRow.Cells[10].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();


                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        grdCuttingOption1.HeaderRow.Cells[11].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        grdCuttingOption1.HeaderRow.Cells[12].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        grdCuttingOption1.HeaderRow.Cells[13].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();


                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        grdCuttingOption1.HeaderRow.Cells[14].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        grdCuttingOption1.HeaderRow.Cells[15].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();

                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        lblMinTotal1.Text = MinTotal.ToString();


                    }
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize1 = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");

                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");

                Label lblTotalQuantity1 = (Label)e.Row.FindControl("lblTotalQuantity1");

                dtTotalSize1 = this.OrderControllerInstance.GetTotalSizeByContract(strODId1);
                //lblTotalSize1.Text = (dtTotalSize1.Tables[0].Rows[0]["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize1.Tables[0].Rows[0]["TotalQuantity"])).ToString();
                //lblTotalSize2.Text = (dtTotalSize1.Tables[0].Rows[1]["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize1.Tables[0].Rows[1]["TotalQuantity"])).ToString();
                //lblTotalSize3.Text = (dtTotalSize1.Tables[0].Rows[2]["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize1.Tables[0].Rows[2]["TotalQuantity"])).ToString();
                //lblTotalSize4.Text = (dtTotalSize1.Tables[0].Rows[3]["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize1.Tables[0].Rows[3]["TotalQuantity"])).ToString();
                //lblTotalSize5.Text = (dtTotalSize1.Tables[0].Rows[4]["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize1.Tables[0].Rows[4]["TotalQuantity"])).ToString();
                //lblTotalSize6.Text = (dtTotalSize1.Tables[0].Rows[5]["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize1.Tables[0].Rows[5]["TotalQuantity"])).ToString();
                //lblTotalSize7.Text = (dtTotalSize1.Tables[0].Rows[6]["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize1.Tables[0].Rows[6]["TotalQuantity"])).ToString();
                //lblTotalSize8.Text = (dtTotalSize1.Tables[0].Rows[7]["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize1.Tables[0].Rows[7]["TotalQuantity"])).ToString();
                //lblTotalSize9.Text = (dtTotalSize1.Tables[0].Rows[8]["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize1.Tables[0].Rows[8]["TotalQuantity"])).ToString();
                //lblTotalSize10.Text = (dtTotalSize1.Tables[0].Rows[9]["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize1.Tables[0].Rows[9]["TotalQuantity"])).ToString();
                //lblTotalSize11.Text = (dtTotalSize1.Tables[0].Rows[10]["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize1.Tables[0].Rows[10]["TotalQuantity"])).ToString();
                //lblTotalSize12.Text = (dtTotalSize1.Tables[0].Rows[11]["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize1.Tables[0].Rows[11]["TotalQuantity"])).ToString();
                lblTotalSize1.Text = TotalQuantity1.ToString();
                lblTotalSize2.Text = TotalQuantity2.ToString();
                lblTotalSize3.Text = TotalQuantity3.ToString();
                lblTotalSize4.Text = TotalQuantity4.ToString();
                lblTotalSize5.Text = TotalQuantity5.ToString();
                lblTotalSize6.Text = TotalQuantity6.ToString();
                lblTotalSize7.Text = TotalQuantity7.ToString();
                lblTotalSize8.Text = TotalQuantity8.ToString();
                lblTotalSize9.Text = TotalQuantity9.ToString();
                lblTotalSize10.Text = TotalQuantity10.ToString();
                lblTotalSize11.Text = TotalQuantity11.ToString();
                lblTotalSize12.Text = TotalQuantity12.ToString();

                lblTotalSize13.Text = TotalQuantity13.ToString();
                lblTotalSize14.Text = TotalQuantity14.ToString();
                lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
                lblTotalQuantity1.Text = (dtTotalSize1.Tables[1].Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize1.Tables[1].Rows[0]["Quantity"])).ToString();

            }
        }

        protected void grdCuttinOption2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId2");
                HiddenField hndSize1 = (HiddenField)e.Row.FindControl("hndOP2Size1");
                HiddenField hndSize2 = (HiddenField)e.Row.FindControl("hndOP2Size2");
                HiddenField hndSize3 = (HiddenField)e.Row.FindControl("hndOP2Size3");
                HiddenField hndSize4 = (HiddenField)e.Row.FindControl("hndOP2Size4");
                HiddenField hndSize5 = (HiddenField)e.Row.FindControl("hndOP2Size5");
                HiddenField hndSize6 = (HiddenField)e.Row.FindControl("hndOP2Size6");
                HiddenField hndSize7 = (HiddenField)e.Row.FindControl("hndOP2Size7");
                HiddenField hndSize8 = (HiddenField)e.Row.FindControl("hndOP2Size8");
                HiddenField hndSize9 = (HiddenField)e.Row.FindControl("hndOP2Size9");
                HiddenField hndSize10 = (HiddenField)e.Row.FindControl("hndOP2Size10");
                HiddenField hndSize11 = (HiddenField)e.Row.FindControl("hndOP2Size11");
                HiddenField hndSize12 = (HiddenField)e.Row.FindControl("hndOP2Size12");

                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP2Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP2Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP2Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP2Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP2Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP2Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP2Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP2Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP2Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP2Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP2Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP2Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP2Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP2Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP2Minsize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP2MinTotal1");


                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);


                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 2);
                    if (strODId2 == "")
                    {
                        strODId2 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId2 = strODId2 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        grdCuttinOption2.HeaderRow.Cells[1].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        grdCuttinOption2.HeaderRow.Cells[2].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        grdCuttinOption2.HeaderRow.Cells[3].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        grdCuttinOption2.HeaderRow.Cells[4].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        grdCuttinOption2.HeaderRow.Cells[5].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        grdCuttinOption2.HeaderRow.Cells[6].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        grdCuttinOption2.HeaderRow.Cells[7].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        grdCuttinOption2.HeaderRow.Cells[8].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        grdCuttinOption2.HeaderRow.Cells[9].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        grdCuttinOption2.HeaderRow.Cells[10].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        grdCuttinOption2.HeaderRow.Cells[11].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        grdCuttinOption2.HeaderRow.Cells[12].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        grdCuttinOption2.HeaderRow.Cells[13].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();


                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        grdCuttinOption2.HeaderRow.Cells[14].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        grdCuttinOption2.HeaderRow.Cells[15].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();

                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                             + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                             + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                             + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                             + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                             + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                             + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                             + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        lblMinTotal1.Text = MinTotal.ToString();


                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize2 = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");

                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");

                Label lblTotalQuantity1 = (Label)e.Row.FindControl("lblTotalQuantity2");
                dtTotalSize2 = this.OrderControllerInstance.GetTotalSizeByContract(strODId2);

                lblTotalSize1.Text = TotalQuantity1.ToString();
                lblTotalSize2.Text = TotalQuantity2.ToString();
                lblTotalSize3.Text = TotalQuantity3.ToString();
                lblTotalSize4.Text = TotalQuantity4.ToString();
                lblTotalSize5.Text = TotalQuantity5.ToString();
                lblTotalSize6.Text = TotalQuantity6.ToString();
                lblTotalSize7.Text = TotalQuantity7.ToString();
                lblTotalSize8.Text = TotalQuantity8.ToString();
                lblTotalSize9.Text = TotalQuantity9.ToString();
                lblTotalSize10.Text = TotalQuantity10.ToString();
                lblTotalSize11.Text = TotalQuantity11.ToString();
                lblTotalSize12.Text = TotalQuantity12.ToString();

                lblTotalSize13.Text = TotalQuantity13.ToString();
                lblTotalSize14.Text = TotalQuantity14.ToString();
                lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
                lblTotalQuantity1.Text = (dtTotalSize2.Tables[1].Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize2.Tables[1].Rows[0]["Quantity"])).ToString();

            }
        }

        protected void grdCuttingOption3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // return;
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId3");
                HiddenField hndSize1 = (HiddenField)e.Row.FindControl("hndOP3Size1");
                HiddenField hndSize2 = (HiddenField)e.Row.FindControl("hndOP3Size2");
                HiddenField hndSize3 = (HiddenField)e.Row.FindControl("hndOP3Size3");
                HiddenField hndSize4 = (HiddenField)e.Row.FindControl("hndOP3Size4");
                HiddenField hndSize5 = (HiddenField)e.Row.FindControl("hndOP3Size5");
                HiddenField hndSize6 = (HiddenField)e.Row.FindControl("hndOP3Size6");
                HiddenField hndSize7 = (HiddenField)e.Row.FindControl("hndOP3Size7");
                HiddenField hndSize8 = (HiddenField)e.Row.FindControl("hndOP3Size8");
                HiddenField hndSize9 = (HiddenField)e.Row.FindControl("hndOP3Size9");
                HiddenField hndSize10 = (HiddenField)e.Row.FindControl("hndOP3Size10");
                HiddenField hndSize11 = (HiddenField)e.Row.FindControl("hndOP3Size11");
                HiddenField hndSize12 = (HiddenField)e.Row.FindControl("hndOP3Size12");

                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP3Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP3Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP3Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP3Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP3Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP3Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP3Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP3Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP3Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP3Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP3Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP3Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP3Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP3Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP3Minsize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP3MinTotal1");


                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);



                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 3);
                    if (strODId3 == "")
                    {
                        strODId3 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId3 = strODId3 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        grdCuttingOption3.HeaderRow.Cells[1].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        grdCuttingOption3.HeaderRow.Cells[2].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        grdCuttingOption3.HeaderRow.Cells[3].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        grdCuttingOption3.HeaderRow.Cells[4].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        grdCuttingOption3.HeaderRow.Cells[5].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        grdCuttingOption3.HeaderRow.Cells[6].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        grdCuttingOption3.HeaderRow.Cells[7].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        grdCuttingOption3.HeaderRow.Cells[8].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        grdCuttingOption3.HeaderRow.Cells[9].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        grdCuttingOption3.HeaderRow.Cells[10].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        grdCuttingOption3.HeaderRow.Cells[11].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        grdCuttingOption3.HeaderRow.Cells[12].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        grdCuttingOption3.HeaderRow.Cells[13].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();


                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        grdCuttingOption3.HeaderRow.Cells[14].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        grdCuttingOption3.HeaderRow.Cells[15].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();

                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        lblMinTotal1.Text = MinTotal.ToString();


                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize3 = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");

                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");

                Label lblTotalQuantity1 = (Label)e.Row.FindControl("lblTotalQuantity3");
                dtTotalSize3 = this.OrderControllerInstance.GetTotalSizeByContract(strODId3);

                lblTotalSize1.Text = TotalQuantity1.ToString();
                lblTotalSize2.Text = TotalQuantity2.ToString();
                lblTotalSize3.Text = TotalQuantity3.ToString();
                lblTotalSize4.Text = TotalQuantity4.ToString();
                lblTotalSize5.Text = TotalQuantity5.ToString();
                lblTotalSize6.Text = TotalQuantity6.ToString();
                lblTotalSize7.Text = TotalQuantity7.ToString();
                lblTotalSize8.Text = TotalQuantity8.ToString();
                lblTotalSize9.Text = TotalQuantity9.ToString();
                lblTotalSize10.Text = TotalQuantity10.ToString();
                lblTotalSize11.Text = TotalQuantity11.ToString();
                lblTotalSize12.Text = TotalQuantity12.ToString();

                lblTotalSize13.Text = TotalQuantity13.ToString();
                lblTotalSize14.Text = TotalQuantity14.ToString();
                lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
                lblTotalQuantity1.Text = (dtTotalSize3.Tables[1].Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize3.Tables[1].Rows[0]["Quantity"])).ToString();
            }
        }

        protected void grdCuttingOption4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;
            {
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId4");
                HiddenField hndSize1 = (HiddenField)e.Row.FindControl("hndOP4Size1");
                HiddenField hndSize2 = (HiddenField)e.Row.FindControl("hndOP4Size2");
                HiddenField hndSize3 = (HiddenField)e.Row.FindControl("hndOP4Size3");
                HiddenField hndSize4 = (HiddenField)e.Row.FindControl("hndOP4Size4");
                HiddenField hndSize5 = (HiddenField)e.Row.FindControl("hndOP4Size5");
                HiddenField hndSize6 = (HiddenField)e.Row.FindControl("hndOP4Size6");
                HiddenField hndSize7 = (HiddenField)e.Row.FindControl("hndOP4Size7");
                HiddenField hndSize8 = (HiddenField)e.Row.FindControl("hndOP4Size8");
                HiddenField hndSize9 = (HiddenField)e.Row.FindControl("hndOP4Size9");
                HiddenField hndSize10 = (HiddenField)e.Row.FindControl("hndO43Size10");
                HiddenField hndSize11 = (HiddenField)e.Row.FindControl("hndOP4Size11");
                HiddenField hndSize12 = (HiddenField)e.Row.FindControl("hndOP4Size12");

                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP4Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP4Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP4Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP4Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP4Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP4Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP4Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP4Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP4Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP4Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP4Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP4Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP4Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP4Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP4Minsize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP4MinTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);


                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 4);
                    if (strODId4 == "")
                    {
                        strODId4 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId4 = strODId4 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        grdCuttingOption4.HeaderRow.Cells[1].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        grdCuttingOption4.HeaderRow.Cells[2].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        grdCuttingOption4.HeaderRow.Cells[3].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        grdCuttingOption4.HeaderRow.Cells[4].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        grdCuttingOption4.HeaderRow.Cells[5].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        grdCuttingOption4.HeaderRow.Cells[6].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        grdCuttingOption4.HeaderRow.Cells[7].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        grdCuttingOption4.HeaderRow.Cells[8].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        grdCuttingOption4.HeaderRow.Cells[9].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        grdCuttingOption4.HeaderRow.Cells[10].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        grdCuttingOption4.HeaderRow.Cells[11].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        grdCuttingOption4.HeaderRow.Cells[12].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        grdCuttingOption4.HeaderRow.Cells[13].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();


                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        grdCuttingOption4.HeaderRow.Cells[14].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        grdCuttingOption4.HeaderRow.Cells[15].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();

                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        lblMinTotal1.Text = MinTotal.ToString();


                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize4 = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");

                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");

                Label lblTotalQuantity1 = (Label)e.Row.FindControl("lblTotalQuantity4");
                dtTotalSize4 = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                lblTotalSize1.Text = TotalQuantity1.ToString();
                lblTotalSize2.Text = TotalQuantity2.ToString();
                lblTotalSize3.Text = TotalQuantity3.ToString();
                lblTotalSize4.Text = TotalQuantity4.ToString();
                lblTotalSize5.Text = TotalQuantity5.ToString();
                lblTotalSize6.Text = TotalQuantity6.ToString();
                lblTotalSize7.Text = TotalQuantity7.ToString();
                lblTotalSize8.Text = TotalQuantity8.ToString();
                lblTotalSize9.Text = TotalQuantity9.ToString();
                lblTotalSize10.Text = TotalQuantity10.ToString();
                lblTotalSize11.Text = TotalQuantity11.ToString();
                lblTotalSize12.Text = TotalQuantity12.ToString();

                lblTotalSize13.Text = TotalQuantity13.ToString();
                lblTotalSize14.Text = TotalQuantity14.ToString();
                lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
                lblTotalQuantity1.Text = (dtTotalSize4.Tables[1].Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize4.Tables[1].Rows[0]["Quantity"])).ToString();
            }
        }


        protected void grdCuttingOption5_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;
            {
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId5");


                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP5Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP5Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP5Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP5Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP5Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP5Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP5Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP5Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP5Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP5Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP5Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP5Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP5Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP5Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP5Minsize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP5MinTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);


                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 5);
                    if (strODId5 == "")
                    {
                        strODId5 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId5 = strODId5 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        grdCuttingOption5.HeaderRow.Cells[1].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        grdCuttingOption5.HeaderRow.Cells[2].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        grdCuttingOption5.HeaderRow.Cells[3].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        grdCuttingOption5.HeaderRow.Cells[4].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        grdCuttingOption5.HeaderRow.Cells[5].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        grdCuttingOption5.HeaderRow.Cells[6].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        grdCuttingOption5.HeaderRow.Cells[7].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        grdCuttingOption5.HeaderRow.Cells[8].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        grdCuttingOption5.HeaderRow.Cells[9].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        grdCuttingOption5.HeaderRow.Cells[10].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        grdCuttingOption5.HeaderRow.Cells[11].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        grdCuttingOption5.HeaderRow.Cells[12].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        grdCuttingOption5.HeaderRow.Cells[13].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();


                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        grdCuttingOption5.HeaderRow.Cells[14].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        grdCuttingOption5.HeaderRow.Cells[15].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();

                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                             + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                             + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                             + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                             + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                             + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                             + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                             + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        lblMinTotal1.Text = MinTotal.ToString();



                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize4 = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");

                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");

                Label lblTotalQuantity1 = (Label)e.Row.FindControl("lblTotalQuantity5");
                dtTotalSize4 = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                lblTotalSize1.Text = TotalQuantity1.ToString();
                lblTotalSize2.Text = TotalQuantity2.ToString();
                lblTotalSize3.Text = TotalQuantity3.ToString();
                lblTotalSize4.Text = TotalQuantity4.ToString();
                lblTotalSize5.Text = TotalQuantity5.ToString();
                lblTotalSize6.Text = TotalQuantity6.ToString();
                lblTotalSize7.Text = TotalQuantity7.ToString();
                lblTotalSize8.Text = TotalQuantity8.ToString();
                lblTotalSize9.Text = TotalQuantity9.ToString();
                lblTotalSize10.Text = TotalQuantity10.ToString();
                lblTotalSize11.Text = TotalQuantity11.ToString();
                lblTotalSize12.Text = TotalQuantity12.ToString();

                lblTotalSize13.Text = TotalQuantity13.ToString();
                lblTotalSize14.Text = TotalQuantity14.ToString();
                lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
                lblTotalQuantity1.Text = (dtTotalSize4.Tables[1].Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize4.Tables[1].Rows[0]["Quantity"])).ToString();
            }
        }

        protected void grdCuttingOption6_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;
            {
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId6");


                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP6Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP6Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP6Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP6Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP6Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP6Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP6Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP6Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP6Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP6Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP6Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP6Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP6Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP6Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP6Minsize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP6MinTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);


                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 6);
                    if (strODId6 == "")
                    {
                        strODId6 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId6 = strODId6 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        grdCuttingOption6.HeaderRow.Cells[1].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        grdCuttingOption6.HeaderRow.Cells[2].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        grdCuttingOption6.HeaderRow.Cells[3].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        grdCuttingOption6.HeaderRow.Cells[4].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        grdCuttingOption6.HeaderRow.Cells[5].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        grdCuttingOption6.HeaderRow.Cells[6].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        grdCuttingOption6.HeaderRow.Cells[7].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        grdCuttingOption6.HeaderRow.Cells[8].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        grdCuttingOption6.HeaderRow.Cells[9].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        grdCuttingOption6.HeaderRow.Cells[10].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        grdCuttingOption6.HeaderRow.Cells[11].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        grdCuttingOption6.HeaderRow.Cells[12].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        grdCuttingOption6.HeaderRow.Cells[13].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();


                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        grdCuttingOption6.HeaderRow.Cells[14].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        grdCuttingOption6.HeaderRow.Cells[15].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();

                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        lblMinTotal1.Text = MinTotal.ToString();


                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize4 = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");

                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");

                Label lblTotalQuantity1 = (Label)e.Row.FindControl("lblTotalQuantity6");
                dtTotalSize4 = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                lblTotalSize1.Text = TotalQuantity1.ToString();
                lblTotalSize2.Text = TotalQuantity2.ToString();
                lblTotalSize3.Text = TotalQuantity3.ToString();
                lblTotalSize4.Text = TotalQuantity4.ToString();
                lblTotalSize5.Text = TotalQuantity5.ToString();
                lblTotalSize6.Text = TotalQuantity6.ToString();
                lblTotalSize7.Text = TotalQuantity7.ToString();
                lblTotalSize8.Text = TotalQuantity8.ToString();
                lblTotalSize9.Text = TotalQuantity9.ToString();
                lblTotalSize10.Text = TotalQuantity10.ToString();
                lblTotalSize11.Text = TotalQuantity11.ToString();
                lblTotalSize12.Text = TotalQuantity12.ToString();

                lblTotalSize13.Text = TotalQuantity13.ToString();
                lblTotalSize14.Text = TotalQuantity14.ToString();
                lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
                lblTotalQuantity1.Text = (dtTotalSize4.Tables[1].Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize4.Tables[1].Rows[0]["Quantity"])).ToString();
            }
        }

        protected void grdCuttingOption7_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;
            {
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId7");


                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP7Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP7Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP7Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP7Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP7Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP7Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP7Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP7Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP7Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP7Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP7Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP7Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP7Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP7Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP7Minsize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP7MinTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);


                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 7);
                    if (strODId7 == "")
                    {
                        strODId7 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId7 = strODId7 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        grdCuttingOption7.HeaderRow.Cells[1].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        grdCuttingOption7.HeaderRow.Cells[2].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        grdCuttingOption7.HeaderRow.Cells[3].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        grdCuttingOption7.HeaderRow.Cells[4].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        grdCuttingOption7.HeaderRow.Cells[5].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        grdCuttingOption7.HeaderRow.Cells[6].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        grdCuttingOption7.HeaderRow.Cells[7].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        grdCuttingOption7.HeaderRow.Cells[8].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        grdCuttingOption7.HeaderRow.Cells[9].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        grdCuttingOption7.HeaderRow.Cells[10].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        grdCuttingOption7.HeaderRow.Cells[11].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        grdCuttingOption7.HeaderRow.Cells[12].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        grdCuttingOption7.HeaderRow.Cells[13].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();


                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        grdCuttingOption7.HeaderRow.Cells[14].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        grdCuttingOption7.HeaderRow.Cells[15].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();

                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        lblMinTotal1.Text = MinTotal.ToString();


                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize4 = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");

                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");

                Label lblTotalQuantity7 = (Label)e.Row.FindControl("lblTotalQuantity7");
                dtTotalSize4 = this.OrderControllerInstance.GetTotalSizeByContract(strODId7);

                lblTotalSize1.Text = TotalQuantity1.ToString();
                lblTotalSize2.Text = TotalQuantity2.ToString();
                lblTotalSize3.Text = TotalQuantity3.ToString();
                lblTotalSize4.Text = TotalQuantity4.ToString();
                lblTotalSize5.Text = TotalQuantity5.ToString();
                lblTotalSize6.Text = TotalQuantity6.ToString();
                lblTotalSize7.Text = TotalQuantity7.ToString();
                lblTotalSize8.Text = TotalQuantity8.ToString();
                lblTotalSize9.Text = TotalQuantity9.ToString();
                lblTotalSize10.Text = TotalQuantity10.ToString();
                lblTotalSize11.Text = TotalQuantity11.ToString();
                lblTotalSize12.Text = TotalQuantity12.ToString();

                lblTotalSize13.Text = TotalQuantity13.ToString();
                lblTotalSize14.Text = TotalQuantity14.ToString();
                lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;

                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;

                lblTotalQuantity7.Text = (dtTotalSize4.Tables[1].Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize4.Tables[1].Rows[0]["Quantity"])).ToString();
            }
        }

        protected void grdCuttingOption8_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;
            {
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId8");


                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP8Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP8Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP8Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP8Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP8Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP8Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP8Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP8Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP8Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP8Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP8Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP8Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP8Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP8Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP8Minsize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP8MinTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);


                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 8);
                    if (strODId8 == "")
                    {
                        strODId8 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId8 = strODId8 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        grdCuttingOption8.HeaderRow.Cells[1].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        grdCuttingOption8.HeaderRow.Cells[2].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        grdCuttingOption8.HeaderRow.Cells[3].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        grdCuttingOption8.HeaderRow.Cells[4].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        grdCuttingOption8.HeaderRow.Cells[5].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        grdCuttingOption8.HeaderRow.Cells[6].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        grdCuttingOption8.HeaderRow.Cells[7].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        grdCuttingOption8.HeaderRow.Cells[8].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        grdCuttingOption8.HeaderRow.Cells[9].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        grdCuttingOption8.HeaderRow.Cells[10].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        grdCuttingOption8.HeaderRow.Cells[11].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        grdCuttingOption8.HeaderRow.Cells[12].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        grdCuttingOption8.HeaderRow.Cells[13].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();


                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        grdCuttingOption8.HeaderRow.Cells[14].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        grdCuttingOption8.HeaderRow.Cells[15].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();

                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        lblMinTotal1.Text = MinTotal.ToString();


                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize4 = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");

                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");

                Label lblTotalQuantity1 = (Label)e.Row.FindControl("lblTotalQuantity8");
                dtTotalSize4 = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                lblTotalSize1.Text = TotalQuantity1.ToString();
                lblTotalSize2.Text = TotalQuantity2.ToString();
                lblTotalSize3.Text = TotalQuantity3.ToString();
                lblTotalSize4.Text = TotalQuantity4.ToString();
                lblTotalSize5.Text = TotalQuantity5.ToString();
                lblTotalSize6.Text = TotalQuantity6.ToString();
                lblTotalSize7.Text = TotalQuantity7.ToString();
                lblTotalSize8.Text = TotalQuantity8.ToString();
                lblTotalSize9.Text = TotalQuantity9.ToString();
                lblTotalSize10.Text = TotalQuantity10.ToString();
                lblTotalSize11.Text = TotalQuantity11.ToString();
                lblTotalSize12.Text = TotalQuantity12.ToString();

                lblTotalSize13.Text = TotalQuantity13.ToString();
                lblTotalSize14.Text = TotalQuantity14.ToString();
                lblTotalSize15.Text = TotalQuantity15.ToString();


                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
                lblTotalQuantity1.Text = (dtTotalSize4.Tables[1].Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize4.Tables[1].Rows[0]["Quantity"])).ToString();
            }
        }

        protected void grdCuttingOption9_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;
            {
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId9");


                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP9Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP9Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP9Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP9Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP9Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP9Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP9Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP9Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP9Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP9Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP9Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP9Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP9Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP9Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP9Minsize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP9MinTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);


                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 9);
                    if (strODId9 == "")
                    {
                        strODId9 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId9 = strODId9 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        grdCuttingOption9.HeaderRow.Cells[1].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        grdCuttingOption9.HeaderRow.Cells[2].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        grdCuttingOption9.HeaderRow.Cells[3].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        grdCuttingOption9.HeaderRow.Cells[4].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        grdCuttingOption9.HeaderRow.Cells[5].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        grdCuttingOption9.HeaderRow.Cells[6].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        grdCuttingOption9.HeaderRow.Cells[7].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        grdCuttingOption9.HeaderRow.Cells[8].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        grdCuttingOption9.HeaderRow.Cells[9].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        grdCuttingOption9.HeaderRow.Cells[10].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        grdCuttingOption9.HeaderRow.Cells[11].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        grdCuttingOption9.HeaderRow.Cells[12].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        grdCuttingOption9.HeaderRow.Cells[13].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();


                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        grdCuttingOption9.HeaderRow.Cells[14].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        grdCuttingOption9.HeaderRow.Cells[15].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();

                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        lblMinTotal1.Text = MinTotal.ToString();


                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize4 = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");


                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");


                Label lblTotalQuantity1 = (Label)e.Row.FindControl("lblTotalQuantity9");
                dtTotalSize4 = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                lblTotalSize1.Text = TotalQuantity1.ToString();
                lblTotalSize2.Text = TotalQuantity2.ToString();
                lblTotalSize3.Text = TotalQuantity3.ToString();
                lblTotalSize4.Text = TotalQuantity4.ToString();
                lblTotalSize5.Text = TotalQuantity5.ToString();
                lblTotalSize6.Text = TotalQuantity6.ToString();
                lblTotalSize7.Text = TotalQuantity7.ToString();
                lblTotalSize8.Text = TotalQuantity8.ToString();
                lblTotalSize9.Text = TotalQuantity9.ToString();
                lblTotalSize10.Text = TotalQuantity10.ToString();
                lblTotalSize11.Text = TotalQuantity11.ToString();
                lblTotalSize12.Text = TotalQuantity12.ToString();

                lblTotalSize13.Text = TotalQuantity13.ToString();
                lblTotalSize14.Text = TotalQuantity14.ToString();
                lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;

                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
                lblTotalQuantity1.Text = (dtTotalSize4.Tables[1].Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize4.Tables[1].Rows[0]["Quantity"])).ToString();
            }
        }


        protected void grdCuttingOption10_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;
            {
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId10");


                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP10Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP10Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP10Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP10Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP10Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP10Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP10Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP10Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP10Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP10Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP10Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP10Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP10Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP10Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP10Minsize15");


                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP10MinTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);


                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 10);
                    if (strODId10 == "")
                    {
                        strODId10 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId10 = strODId10 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        grdCuttingOption10.HeaderRow.Cells[1].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        grdCuttingOption10.HeaderRow.Cells[2].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        grdCuttingOption10.HeaderRow.Cells[3].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        grdCuttingOption10.HeaderRow.Cells[4].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        grdCuttingOption10.HeaderRow.Cells[5].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        grdCuttingOption10.HeaderRow.Cells[6].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        grdCuttingOption10.HeaderRow.Cells[7].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        grdCuttingOption10.HeaderRow.Cells[8].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        grdCuttingOption10.HeaderRow.Cells[9].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        grdCuttingOption10.HeaderRow.Cells[10].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        grdCuttingOption10.HeaderRow.Cells[11].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        grdCuttingOption10.HeaderRow.Cells[12].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();


                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        grdCuttingOption10.HeaderRow.Cells[13].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();


                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        grdCuttingOption10.HeaderRow.Cells[14].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        grdCuttingOption10.HeaderRow.Cells[15].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();

                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        lblMinTotal1.Text = MinTotal.ToString();


                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize4 = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");

                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");

                Label lblTotalQuantity1 = (Label)e.Row.FindControl("lblTotalQuantity10");
                dtTotalSize4 = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                lblTotalSize1.Text = TotalQuantity1.ToString();
                lblTotalSize2.Text = TotalQuantity2.ToString();
                lblTotalSize3.Text = TotalQuantity3.ToString();
                lblTotalSize4.Text = TotalQuantity4.ToString();
                lblTotalSize5.Text = TotalQuantity5.ToString();
                lblTotalSize6.Text = TotalQuantity6.ToString();
                lblTotalSize7.Text = TotalQuantity7.ToString();
                lblTotalSize8.Text = TotalQuantity8.ToString();
                lblTotalSize9.Text = TotalQuantity9.ToString();
                lblTotalSize10.Text = TotalQuantity10.ToString();
                lblTotalSize11.Text = TotalQuantity11.ToString();
                lblTotalSize12.Text = TotalQuantity12.ToString();
                lblTotalSize13.Text = TotalQuantity13.ToString();
                lblTotalSize14.Text = TotalQuantity14.ToString();
                lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
                lblTotalQuantity1.Text = (dtTotalSize4.Tables[1].Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize4.Tables[1].Rows[0]["Quantity"])).ToString();
            }
        }


        protected void grdCuttingOption11_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;
            {
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId11");


                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP11Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP11Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP11Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP11Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP11Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP11Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP11Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP11Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP11Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP11Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP11Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP11Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP11Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP11Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP11Minsize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP11MinTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);


                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 11);
                    if (strODId11 == "")
                    {
                        strODId11 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId11 = strODId11 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        grdCuttingOption11.HeaderRow.Cells[1].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        grdCuttingOption11.HeaderRow.Cells[2].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        grdCuttingOption11.HeaderRow.Cells[3].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        grdCuttingOption11.HeaderRow.Cells[4].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        grdCuttingOption11.HeaderRow.Cells[5].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        grdCuttingOption11.HeaderRow.Cells[6].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        grdCuttingOption11.HeaderRow.Cells[7].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        grdCuttingOption11.HeaderRow.Cells[8].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        grdCuttingOption11.HeaderRow.Cells[9].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        grdCuttingOption11.HeaderRow.Cells[10].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        grdCuttingOption11.HeaderRow.Cells[11].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        grdCuttingOption11.HeaderRow.Cells[12].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        grdCuttingOption11.HeaderRow.Cells[13].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();


                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        grdCuttingOption11.HeaderRow.Cells[14].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        grdCuttingOption11.HeaderRow.Cells[15].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();

                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        lblMinTotal1.Text = MinTotal.ToString();


                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize4 = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");

                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");

                Label lblTotalQuantity1 = (Label)e.Row.FindControl("lblTotalQuantity11");
                dtTotalSize4 = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                lblTotalSize1.Text = TotalQuantity1.ToString();
                lblTotalSize2.Text = TotalQuantity2.ToString();
                lblTotalSize3.Text = TotalQuantity3.ToString();
                lblTotalSize4.Text = TotalQuantity4.ToString();
                lblTotalSize5.Text = TotalQuantity5.ToString();
                lblTotalSize6.Text = TotalQuantity6.ToString();
                lblTotalSize7.Text = TotalQuantity7.ToString();
                lblTotalSize8.Text = TotalQuantity8.ToString();
                lblTotalSize9.Text = TotalQuantity9.ToString();
                lblTotalSize10.Text = TotalQuantity10.ToString();
                lblTotalSize11.Text = TotalQuantity11.ToString();
                lblTotalSize12.Text = TotalQuantity12.ToString();

                lblTotalSize13.Text = TotalQuantity13.ToString();
                lblTotalSize14.Text = TotalQuantity14.ToString();
                lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
                lblTotalQuantity1.Text = (dtTotalSize4.Tables[1].Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize4.Tables[1].Rows[0]["Quantity"])).ToString();
            }
        }

        protected void grdCuttingOption12_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;
            {
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId12");


                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP12Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP12Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP12Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP12Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP12Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP12Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP12Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP12Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP12Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP12Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP12Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP12Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP12Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP12Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP12Minsize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP12MinTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);


                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 12);
                    if (strODId12 == "")
                    {
                        strODId12 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId12 = strODId12 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        grdCuttingOption12.HeaderRow.Cells[1].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        grdCuttingOption12.HeaderRow.Cells[2].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        grdCuttingOption12.HeaderRow.Cells[3].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        grdCuttingOption12.HeaderRow.Cells[4].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        grdCuttingOption12.HeaderRow.Cells[5].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        grdCuttingOption12.HeaderRow.Cells[6].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        grdCuttingOption12.HeaderRow.Cells[7].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        grdCuttingOption12.HeaderRow.Cells[8].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        grdCuttingOption12.HeaderRow.Cells[9].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        grdCuttingOption12.HeaderRow.Cells[10].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        grdCuttingOption12.HeaderRow.Cells[11].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        grdCuttingOption12.HeaderRow.Cells[12].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        grdCuttingOption12.HeaderRow.Cells[13].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();


                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        grdCuttingOption12.HeaderRow.Cells[14].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        grdCuttingOption12.HeaderRow.Cells[15].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();

                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        lblMinTotal1.Text = MinTotal.ToString();


                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize4 = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");

                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");

                Label lblTotalQuantity1 = (Label)e.Row.FindControl("lblTotalQuantity12");
                dtTotalSize4 = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                lblTotalSize1.Text = TotalQuantity1.ToString();
                lblTotalSize2.Text = TotalQuantity2.ToString();
                lblTotalSize3.Text = TotalQuantity3.ToString();
                lblTotalSize4.Text = TotalQuantity4.ToString();
                lblTotalSize5.Text = TotalQuantity5.ToString();
                lblTotalSize6.Text = TotalQuantity6.ToString();
                lblTotalSize7.Text = TotalQuantity7.ToString();
                lblTotalSize8.Text = TotalQuantity8.ToString();
                lblTotalSize9.Text = TotalQuantity9.ToString();
                lblTotalSize10.Text = TotalQuantity10.ToString();
                lblTotalSize11.Text = TotalQuantity11.ToString();
                lblTotalSize12.Text = TotalQuantity12.ToString();

                lblTotalSize13.Text = TotalQuantity13.ToString();
                lblTotalSize14.Text = TotalQuantity14.ToString();
                lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
                lblTotalQuantity1.Text = (dtTotalSize4.Tables[1].Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize4.Tables[1].Rows[0]["Quantity"])).ToString();
            }
        }


        protected void grdCuttingOption13_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;
            {
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId13");


                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP13Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP13Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP13Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP13Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP13Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP13Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP13Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP13Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP13Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP13Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP13Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP13Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP13Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP13Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP13Minsize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP13MinTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);


                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 13);
                    if (strODId13 == "")
                    {
                        strODId13 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId13 = strODId13 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        grdCuttingOption13.HeaderRow.Cells[1].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        grdCuttingOption13.HeaderRow.Cells[2].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        grdCuttingOption13.HeaderRow.Cells[3].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        grdCuttingOption13.HeaderRow.Cells[4].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        grdCuttingOption13.HeaderRow.Cells[5].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        grdCuttingOption13.HeaderRow.Cells[6].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        grdCuttingOption13.HeaderRow.Cells[7].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        grdCuttingOption13.HeaderRow.Cells[8].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        grdCuttingOption13.HeaderRow.Cells[9].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        grdCuttingOption13.HeaderRow.Cells[10].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        grdCuttingOption13.HeaderRow.Cells[11].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        grdCuttingOption13.HeaderRow.Cells[12].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        grdCuttingOption13.HeaderRow.Cells[13].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();


                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        grdCuttingOption13.HeaderRow.Cells[14].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        grdCuttingOption13.HeaderRow.Cells[15].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();
                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        lblMinTotal1.Text = MinTotal.ToString();


                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize4 = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");


                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");

                Label lblTotalQuantity1 = (Label)e.Row.FindControl("lblTotalQuantity13");
                dtTotalSize4 = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                lblTotalSize1.Text = TotalQuantity1.ToString();
                lblTotalSize2.Text = TotalQuantity2.ToString();
                lblTotalSize3.Text = TotalQuantity3.ToString();
                lblTotalSize4.Text = TotalQuantity4.ToString();
                lblTotalSize5.Text = TotalQuantity5.ToString();
                lblTotalSize6.Text = TotalQuantity6.ToString();
                lblTotalSize7.Text = TotalQuantity7.ToString();
                lblTotalSize8.Text = TotalQuantity8.ToString();
                lblTotalSize9.Text = TotalQuantity9.ToString();
                lblTotalSize10.Text = TotalQuantity10.ToString();
                lblTotalSize11.Text = TotalQuantity11.ToString();
                lblTotalSize12.Text = TotalQuantity12.ToString();
                lblTotalSize13.Text = TotalQuantity13.ToString();
                lblTotalSize14.Text = TotalQuantity14.ToString();
                lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
                lblTotalQuantity1.Text = (dtTotalSize4.Tables[1].Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize4.Tables[1].Rows[0]["Quantity"])).ToString();
            }
        }


        protected void grdCuttingOption14_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;
            {
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId14");


                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP14Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP14Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP14Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP14Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP14Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP14Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP14Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP14Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP14Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP14Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP14Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP14Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP14Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP14Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP14Minsize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP14MinTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);


                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 14);
                    if (strODId14 == "")
                    {
                        strODId14 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId14 = strODId14 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        grdCuttingOption14.HeaderRow.Cells[1].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        grdCuttingOption14.HeaderRow.Cells[2].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        grdCuttingOption14.HeaderRow.Cells[3].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        grdCuttingOption14.HeaderRow.Cells[4].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        grdCuttingOption14.HeaderRow.Cells[5].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        grdCuttingOption14.HeaderRow.Cells[6].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        grdCuttingOption14.HeaderRow.Cells[7].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        grdCuttingOption14.HeaderRow.Cells[8].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        grdCuttingOption14.HeaderRow.Cells[9].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        grdCuttingOption14.HeaderRow.Cells[10].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        grdCuttingOption14.HeaderRow.Cells[11].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        grdCuttingOption14.HeaderRow.Cells[12].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        grdCuttingOption14.HeaderRow.Cells[13].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();


                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        grdCuttingOption14.HeaderRow.Cells[14].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        grdCuttingOption14.HeaderRow.Cells[15].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();

                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        lblMinTotal1.Text = MinTotal.ToString();


                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize4 = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");

                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");

                Label lblTotalQuantity1 = (Label)e.Row.FindControl("lblTotalQuantity14");
                dtTotalSize4 = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                lblTotalSize1.Text = TotalQuantity1.ToString();
                lblTotalSize2.Text = TotalQuantity2.ToString();
                lblTotalSize3.Text = TotalQuantity3.ToString();
                lblTotalSize4.Text = TotalQuantity4.ToString();
                lblTotalSize5.Text = TotalQuantity5.ToString();
                lblTotalSize6.Text = TotalQuantity6.ToString();
                lblTotalSize7.Text = TotalQuantity7.ToString();
                lblTotalSize8.Text = TotalQuantity8.ToString();
                lblTotalSize9.Text = TotalQuantity9.ToString();
                lblTotalSize10.Text = TotalQuantity10.ToString();
                lblTotalSize11.Text = TotalQuantity11.ToString();
                lblTotalSize12.Text = TotalQuantity12.ToString();

                lblTotalSize13.Text = TotalQuantity13.ToString();
                lblTotalSize14.Text = TotalQuantity14.ToString();
                lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
                lblTotalQuantity1.Text = (dtTotalSize4.Tables[1].Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize4.Tables[1].Rows[0]["Quantity"])).ToString();
            }
        }


        protected void grdCuttingOption15_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;
            {
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId15");


                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP15Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP15Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP15Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP15Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP15Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP15Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP15Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP15Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP15Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP15Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP15Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP15Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP15Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP15Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP15Minsize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP15MinTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);


                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 15);
                    if (strODId15 == "")
                    {
                        strODId15 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId15 = strODId15 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        grdCuttingOption15.HeaderRow.Cells[1].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        grdCuttingOption15.HeaderRow.Cells[2].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        grdCuttingOption15.HeaderRow.Cells[3].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        grdCuttingOption15.HeaderRow.Cells[4].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        grdCuttingOption15.HeaderRow.Cells[5].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        grdCuttingOption15.HeaderRow.Cells[6].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        grdCuttingOption15.HeaderRow.Cells[7].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        grdCuttingOption15.HeaderRow.Cells[8].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        grdCuttingOption15.HeaderRow.Cells[9].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        grdCuttingOption15.HeaderRow.Cells[10].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        grdCuttingOption15.HeaderRow.Cells[11].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        grdCuttingOption15.HeaderRow.Cells[12].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        grdCuttingOption15.HeaderRow.Cells[13].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();


                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        grdCuttingOption15.HeaderRow.Cells[14].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        grdCuttingOption15.HeaderRow.Cells[15].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();

                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        lblMinTotal1.Text = MinTotal.ToString();


                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize4 = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");

                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");

                Label lblTotalQuantity1 = (Label)e.Row.FindControl("lblTotalQuantity15");
                dtTotalSize4 = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                lblTotalSize1.Text = TotalQuantity1.ToString();
                lblTotalSize2.Text = TotalQuantity2.ToString();
                lblTotalSize3.Text = TotalQuantity3.ToString();
                lblTotalSize4.Text = TotalQuantity4.ToString();
                lblTotalSize5.Text = TotalQuantity5.ToString();
                lblTotalSize6.Text = TotalQuantity6.ToString();
                lblTotalSize7.Text = TotalQuantity7.ToString();
                lblTotalSize8.Text = TotalQuantity8.ToString();
                lblTotalSize9.Text = TotalQuantity9.ToString();
                lblTotalSize10.Text = TotalQuantity10.ToString();
                lblTotalSize11.Text = TotalQuantity11.ToString();
                lblTotalSize12.Text = TotalQuantity12.ToString();

                lblTotalSize13.Text = TotalQuantity13.ToString();
                lblTotalSize14.Text = TotalQuantity14.ToString();
                lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
                lblTotalQuantity1.Text = (dtTotalSize4.Tables[1].Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize4.Tables[1].Rows[0]["Quantity"])).ToString();
            }
        }

        protected void grdCuttingOption16_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;
            {
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId16");


                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP16Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP16Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP16Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP16Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP16Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP16Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP16Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP16Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP16Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP16Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP16Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP16Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP16Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP16Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP16Minsize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP16MinTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);


                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 16);
                    if (strODId16 == "")
                    {
                        strODId16 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId16 = strODId16 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        grdCuttingOption16.HeaderRow.Cells[1].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        grdCuttingOption16.HeaderRow.Cells[2].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        grdCuttingOption16.HeaderRow.Cells[3].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        grdCuttingOption16.HeaderRow.Cells[4].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        grdCuttingOption16.HeaderRow.Cells[5].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        grdCuttingOption16.HeaderRow.Cells[6].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        grdCuttingOption16.HeaderRow.Cells[7].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        grdCuttingOption16.HeaderRow.Cells[8].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        grdCuttingOption16.HeaderRow.Cells[9].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        grdCuttingOption16.HeaderRow.Cells[10].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        grdCuttingOption16.HeaderRow.Cells[11].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        grdCuttingOption16.HeaderRow.Cells[12].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        grdCuttingOption16.HeaderRow.Cells[13].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();


                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        grdCuttingOption16.HeaderRow.Cells[14].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        grdCuttingOption16.HeaderRow.Cells[15].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();

                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        lblMinTotal1.Text = MinTotal.ToString();


                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize4 = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");

                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");

                Label lblTotalQuantity1 = (Label)e.Row.FindControl("lblTotalQuantity16");
                dtTotalSize4 = this.OrderControllerInstance.GetTotalSizeByContract(strODId16);

                lblTotalSize1.Text = TotalQuantity1.ToString();
                lblTotalSize2.Text = TotalQuantity2.ToString();
                lblTotalSize3.Text = TotalQuantity3.ToString();
                lblTotalSize4.Text = TotalQuantity4.ToString();
                lblTotalSize5.Text = TotalQuantity5.ToString();
                lblTotalSize6.Text = TotalQuantity6.ToString();
                lblTotalSize7.Text = TotalQuantity7.ToString();
                lblTotalSize8.Text = TotalQuantity8.ToString();
                lblTotalSize9.Text = TotalQuantity9.ToString();
                lblTotalSize10.Text = TotalQuantity10.ToString();
                lblTotalSize11.Text = TotalQuantity11.ToString();
                lblTotalSize12.Text = TotalQuantity12.ToString();

                lblTotalSize13.Text = TotalQuantity13.ToString();
                lblTotalSize14.Text = TotalQuantity14.ToString();
                lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
                lblTotalQuantity1.Text = (dtTotalSize4.Tables[1].Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize4.Tables[1].Rows[0]["Quantity"])).ToString();
            }
        }
        protected void grdCuttingOption17_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;
            {
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId17");


                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP17Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP17Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP17Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP17Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP17Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP17Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP17Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP17Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP17Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP17Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP17Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP17Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP17Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP17Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP17Minsize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP17MinTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);


                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 17);
                    if (strODId17 == "")
                    {
                        strODId17 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId17 = strODId17 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        grdCuttingOption17.HeaderRow.Cells[1].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        grdCuttingOption17.HeaderRow.Cells[2].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        grdCuttingOption17.HeaderRow.Cells[3].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        grdCuttingOption17.HeaderRow.Cells[4].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        grdCuttingOption17.HeaderRow.Cells[5].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        grdCuttingOption17.HeaderRow.Cells[6].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        grdCuttingOption17.HeaderRow.Cells[7].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        grdCuttingOption17.HeaderRow.Cells[8].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        grdCuttingOption17.HeaderRow.Cells[9].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        grdCuttingOption17.HeaderRow.Cells[10].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        grdCuttingOption17.HeaderRow.Cells[11].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        grdCuttingOption17.HeaderRow.Cells[12].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        grdCuttingOption17.HeaderRow.Cells[13].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();


                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        grdCuttingOption17.HeaderRow.Cells[14].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        grdCuttingOption17.HeaderRow.Cells[15].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();

                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        lblMinTotal1.Text = MinTotal.ToString();


                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize4 = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");

                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");

                Label lblTotalQuantity1 = (Label)e.Row.FindControl("lblTotalQuantity17");
                dtTotalSize4 = this.OrderControllerInstance.GetTotalSizeByContract(strODId16);

                lblTotalSize1.Text = TotalQuantity1.ToString();
                lblTotalSize2.Text = TotalQuantity2.ToString();
                lblTotalSize3.Text = TotalQuantity3.ToString();
                lblTotalSize4.Text = TotalQuantity4.ToString();
                lblTotalSize5.Text = TotalQuantity5.ToString();
                lblTotalSize6.Text = TotalQuantity6.ToString();
                lblTotalSize7.Text = TotalQuantity7.ToString();
                lblTotalSize8.Text = TotalQuantity8.ToString();
                lblTotalSize9.Text = TotalQuantity9.ToString();
                lblTotalSize10.Text = TotalQuantity10.ToString();
                lblTotalSize11.Text = TotalQuantity11.ToString();
                lblTotalSize12.Text = TotalQuantity12.ToString();

                lblTotalSize13.Text = TotalQuantity13.ToString();
                lblTotalSize14.Text = TotalQuantity14.ToString();
                lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
                lblTotalQuantity1.Text = (dtTotalSize4.Tables[1].Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize4.Tables[1].Rows[0]["Quantity"])).ToString();
            }
        }
        protected void grdCuttingOption18_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;
            {
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId18");


                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP18Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP18Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP18Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP18Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP18Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP18Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP18Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP18Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP18Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP18Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP18Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP18Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP18Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP18Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP18Minsize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP18MinTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);


                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 18);
                    if (strODId18 == "")
                    {
                        strODId18 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId18 = strODId18 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        grdCuttingOption18.HeaderRow.Cells[1].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        grdCuttingOption18.HeaderRow.Cells[2].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        grdCuttingOption18.HeaderRow.Cells[3].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        grdCuttingOption18.HeaderRow.Cells[4].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        grdCuttingOption18.HeaderRow.Cells[5].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        grdCuttingOption18.HeaderRow.Cells[6].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        grdCuttingOption18.HeaderRow.Cells[7].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        grdCuttingOption18.HeaderRow.Cells[8].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        grdCuttingOption18.HeaderRow.Cells[9].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        grdCuttingOption18.HeaderRow.Cells[10].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        grdCuttingOption18.HeaderRow.Cells[11].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        grdCuttingOption18.HeaderRow.Cells[12].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        grdCuttingOption18.HeaderRow.Cells[13].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();


                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        grdCuttingOption18.HeaderRow.Cells[14].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        grdCuttingOption18.HeaderRow.Cells[15].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();

                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        lblMinTotal1.Text = MinTotal.ToString();


                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize4 = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");

                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");

                Label lblTotalQuantity1 = (Label)e.Row.FindControl("lblTotalQuantity18");
                dtTotalSize4 = this.OrderControllerInstance.GetTotalSizeByContract(strODId16);

                lblTotalSize1.Text = TotalQuantity1.ToString();
                lblTotalSize2.Text = TotalQuantity2.ToString();
                lblTotalSize3.Text = TotalQuantity3.ToString();
                lblTotalSize4.Text = TotalQuantity4.ToString();
                lblTotalSize5.Text = TotalQuantity5.ToString();
                lblTotalSize6.Text = TotalQuantity6.ToString();
                lblTotalSize7.Text = TotalQuantity7.ToString();
                lblTotalSize8.Text = TotalQuantity8.ToString();
                lblTotalSize9.Text = TotalQuantity9.ToString();
                lblTotalSize10.Text = TotalQuantity10.ToString();
                lblTotalSize11.Text = TotalQuantity11.ToString();
                lblTotalSize12.Text = TotalQuantity12.ToString();

                lblTotalSize13.Text = TotalQuantity13.ToString();
                lblTotalSize14.Text = TotalQuantity14.ToString();
                lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
                lblTotalQuantity1.Text = (dtTotalSize4.Tables[1].Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize4.Tables[1].Rows[0]["Quantity"])).ToString();
            }
        }

        protected void grdCuttingOption19_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;
            {
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId19");


                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP19Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP19Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP19Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP19Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP19Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP19Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP19Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP19Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP19Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP19Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP19Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP19Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP19Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP19Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP19Minsize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP19MinTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);


                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 19);
                    if (strODId19 == "")
                    {
                        strODId19 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId19 = strODId19 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        grdCuttingOption19.HeaderRow.Cells[1].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        grdCuttingOption19.HeaderRow.Cells[2].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        grdCuttingOption19.HeaderRow.Cells[3].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        grdCuttingOption19.HeaderRow.Cells[4].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        grdCuttingOption19.HeaderRow.Cells[5].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        grdCuttingOption19.HeaderRow.Cells[6].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        grdCuttingOption19.HeaderRow.Cells[7].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        grdCuttingOption19.HeaderRow.Cells[8].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        grdCuttingOption19.HeaderRow.Cells[9].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        grdCuttingOption19.HeaderRow.Cells[10].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        grdCuttingOption19.HeaderRow.Cells[11].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        grdCuttingOption19.HeaderRow.Cells[12].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        grdCuttingOption19.HeaderRow.Cells[13].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();


                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        grdCuttingOption19.HeaderRow.Cells[14].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        grdCuttingOption19.HeaderRow.Cells[15].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();

                        decimal MinTotal = Math.Round(Convert.ToDecimal(
                                            Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                             + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                             + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                             + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)
                                            ));
                        lblMinTotal1.Text = MinTotal.ToString();


                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize4 = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");

                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");

                Label lblTotalQuantity19 = (Label)e.Row.FindControl("lblTotalQuantity19");
                dtTotalSize4 = this.OrderControllerInstance.GetTotalSizeByContract(strODId19);

                lblTotalSize1.Text = TotalQuantity1.ToString();
                lblTotalSize2.Text = TotalQuantity2.ToString();
                lblTotalSize3.Text = TotalQuantity3.ToString();
                lblTotalSize4.Text = TotalQuantity4.ToString();
                lblTotalSize5.Text = TotalQuantity5.ToString();
                lblTotalSize6.Text = TotalQuantity6.ToString();
                lblTotalSize7.Text = TotalQuantity7.ToString();
                lblTotalSize8.Text = TotalQuantity8.ToString();
                lblTotalSize9.Text = TotalQuantity9.ToString();
                lblTotalSize10.Text = TotalQuantity10.ToString();
                lblTotalSize11.Text = TotalQuantity11.ToString();
                lblTotalSize12.Text = TotalQuantity12.ToString();

                lblTotalSize13.Text = TotalQuantity13.ToString();
                lblTotalSize14.Text = TotalQuantity14.ToString();
                lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
                lblTotalQuantity19.Text = (dtTotalSize4.Tables[1].Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize4.Tables[1].Rows[0]["Quantity"])).ToString();
            }
        }
    }
}









