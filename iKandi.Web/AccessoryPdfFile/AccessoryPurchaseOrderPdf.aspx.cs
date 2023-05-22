using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.BLL;
using System.Data;
using iKandi.Web.Components;

namespace iKandi.Web
{
    public partial class AccessoryPurchaseOrderPdf : System.Web.UI.Page
    {
        public int SupplierPoId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["SupplierPoId"]))
                {
                    return Convert.ToInt32(Request.QueryString["SupplierPoId"]);
                }
                return -1;
            }
        }
        public int AccessoryMasterId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["AccessoryMasterId"]))
                {
                    return Convert.ToInt32(Request.QueryString["AccessoryMasterId"]);
                }
                return -1;
            }
        }
        public string Size
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Size"]))
                {
                    return Request.QueryString["Size"].ToString();
                }
                return "";
            }
        }
        public string ColorPrint
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ColorPrint"]))
                {
                    return Request.QueryString["ColorPrint"].ToString();
                }
                return "";
            }
        }
        public int AccessoryType
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["AccessoryType"]))
                {
                    return Convert.ToInt32(Request.QueryString["AccessoryType"]);
                }
                return -1;
            }
        }
        public int QtyToOrder
        {
            get;
            set;
        }

        public double Shrinkage;
        public double Wastage;
        string host = "";
        AccessoryWorkingController objAccessory = new AccessoryWorkingController();
        AccessoryQualityController objAccessQuality = new AccessoryQualityController();

        protected void Page_Load(object sender, EventArgs e)
        {
            host = "http://" + Request.Url.Authority;
            if (!IsPostBack)
            {
                BindData();
                Bind_Eta_History();
                DataTable dt = objAccessory.Getbipladdress("pdf_BIPLAddress");
                divbipladdress.InnerHtml = dt.Rows[0]["VALUE"].ToString();
                BindRemarks();
            }
        }


        public void BindRemarks()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = objAccessory.GetAccessoryRemarks(lblPoNo.Text.Trim());
            dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dt.Rows[0]["AccessoryRemarks"].ToString()))
                {

                    lblRemarks.Text = dt.Rows[0]["AccessoryRemarks"].ToString();



                }
            }
        }

        private void BindData()
        {
            try
            {
                List<AccessoryPending> AccessList = objAccessory.GetAccessory_SupplierPurchaseOrder(AccessoryMasterId, Size, ColorPrint, SupplierPoId, AccessoryType);
                
                if (AccessList[0].Status == 1) { PoWaterMark.Visible = true; }

                lblPoNo.Text = AccessList[0].PoNumber;
                lblPoDate.Text = Convert.ToDateTime(AccessList[0].PoDate) == DateTime.MinValue ? DateTime.Now.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(AccessList[0].PoDate).ToString("dd MMM yy (ddd)");
                lblETADate.Text = Convert.ToDateTime(AccessList[0].PoEta) == DateTime.MinValue ? DateTime.Now.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(AccessList[0].PoEta).ToString("dd MMM yy (ddd)");

                if (AccessList[0].HistoryExist == 1)
                {
                    ShowImgHis.Visible = true;
                }
                string[] SupplierDetail = AccessList[0].SupplierNameWithRate.Split('-');
                lblSupplierName.Text = SupplierDetail[0].ToString();
                lblSupplierDetail.Text = SupplierDetail[1].ToString();
                //RajeevS 13022023
                string HSNCode = AccessList[0].HSNCode.ToString();
                if(HSNCode=="")
                {
                    spn_HSNCode.InnerHtml = "";
                    lblHSNCode.Visible = false;
                }
                else
                {
                    lblHSNCode.Visible = true;
                    spn_HSNCode.InnerHtml = "HSNCode";
                    lblHSNCode.Text = HSNCode;
                }
                //RajeevS
                lblAccessoryQuality.Text = AccessList[0].AccessoryName;
                if (AccessList[0].Size != "")
                    lblSize.Text = AccessList[0].Size == "Default" ? "" : "(" + AccessList[0].Size + ")";

                lblcolorprint.Text = AccessList[0].Color_Print;

                lblShrinkage.Text = AccessList[0].Shrinkage == 0 ? "" : AccessList[0].Shrinkage.ToString() + " %";
                hdnShrinkage.Value = AccessList[0].Shrinkage.ToString();

                lblWastage.Text = AccessList[0].Wastage == 0 ? "" : AccessList[0].Wastage.ToString() + " %";
                lblClientCode.Text = AccessList[0].ClientCode;

                if (AccessoryType == 1)
                {
                    lblAccessType.Text = "Greige";
                    Order_text.InnerHtml = "Purchase Order";
                }
                else if (AccessoryType == 2)
                {
                    lblAccessType.Text = "Process";
                    Order_text.InnerHtml = "Process Order";

                }
                else if (AccessoryType == 3)
                {
                    lblAccessType.Text = "Finish";
                    Order_text.InnerHtml = "Purchase Order";

                }
                if (AccessoryType == 2)
                {
                    if (AccessList[0].SendQty > 0)
                    {
                        if (AccessList[0].UnitChange)
                        {
                            lblSendQty.Text = AccessList[0].New_SendQty.ToString("#,##0");
                            hdnSendQty.Value = AccessList[0].New_SendQty.ToString();
                        }
                        else
                        {
                            lblSendQty.Text = AccessList[0].SendQty.ToString("#,##0");
                            hdnSendQty.Value = AccessList[0].SendQty.ToString();
                        }
                    }
                    else
                    {
                        hdnSendQty.Value = QtyToOrder.ToString();
                        lblSendQty.Text = QtyToOrder == 0 ? "" : QtyToOrder.ToString("#,##0");
                    }
                    int SendQty = Convert.ToInt32(hdnSendQty.Value);
                    int RecievedQty = 0;

                    Shrinkage = AccessList[0].Shrinkage == 0 ? Shrinkage : AccessList[0].Shrinkage;
                    if (Shrinkage > 0)
                    {
                        RecievedQty = Convert.ToInt32(Convert.ToDouble(SendQty) - ((Convert.ToDouble(SendQty) * Convert.ToDouble(Shrinkage)) / 100));
                    }
                    else
                    {
                        RecievedQty = SendQty;
                    }

                    hdnReceivedQty.Value = RecievedQty.ToString();
                    lblReceivedqty.Text = RecievedQty.ToString("#,##0");
                }
                else
                {
                    if (AccessList[0].ReceivedQty > 0)
                    {
                        if (AccessList[0].UnitChange)
                        {
                            hdnReceivedQty.Value = AccessList[0].New_RecievedQty.ToString();
                            lblReceivedqty.Text = AccessList[0].New_RecievedQty.ToString("#,##0");
                            hdnConversionVal.Value = AccessList[0].ConversionValue.ToString();
                        }
                        else
                        {
                            hdnReceivedQty.Value = AccessList[0].ReceivedQty.ToString();
                            lblReceivedqty.Text = AccessList[0].ReceivedQty.ToString("#,##0");
                        }
                    }
                    else
                    {
                        hdnReceivedQty.Value = QtyToOrder.ToString();
                        lblReceivedqty.Text = QtyToOrder == 0 ? "" : QtyToOrder.ToString("#,##0");
                    }
                }
                if (AccessList[0].GarmentUnit > 0)
                {
                    if (AccessList[0].UnitChange)
                    {
                        lblAccessUnit.Text = AccessList[0].DefaultGarmentUnitName;
                        dvAccessUnit.Style.Add("background-color", "yellow");
                    }
                    else
                    {
                        lblAccessUnit.Text = AccessList[0].GarmentUnitName;
                    }
                }

                if (AccessList[0].FinalRate > 0)
                {
                    lblRate.Text = AccessList[0].FinalRate.ToString();
                    if (AccessList[0].UnitChange)
                    {
                        lblTotalAmount.Text = (AccessList[0].New_RecievedQty * AccessList[0].FinalRate).ToString("#,##0");
                    }
                    else
                    {
                        lblTotalAmount.Text = (AccessList[0].ReceivedQty * AccessList[0].FinalRate).ToString("#,##0");
                    }
                    AddIndianCurrency.Attributes.Add("class", "AddCuurency");
                }

                boutiqueImg.ImageUrl = host + "/images/boutique-logo.png";

                if (AccessList[0].IsAuthorizedSignatory == true)
                {
                    divAuthorizedSigchk.Visible = false;
                    divAuthorizedSig.Visible = true;
                    //foreach (var user in ApplicationHelper.Users)
                    //{
                    //    if (AccessList[0].AuthorizedSignatureBy == user.UserID)
                    //    {
                    //        lblAuthorizedName.Text = user.FirstName + " " + user.LastName;
                    //        imgAuthorizedSignatory.ImageUrl = user.SignPath != string.Empty ? host + "/Uploads/Photo/" + user.SignPath : host + "/Uploads/Photo/NotSign.jpg";
                    //        if (AccessList[0].AuthorizedSignatureDate != DateTime.MinValue)
                    //            lblAuthorizedDate.Text = AccessList[0].AuthorizedSignatureDate.ToString("dd MMM yy (ddd)");
                    //    }
                    //}
                    var user = ApplicationHelper.Users.Where(x => x.UserID == AccessList[0].AuthorizedSignatureBy).FirstOrDefault();
                    if (user != null)
                    {
                        lblAuthorizedName.Text = user.FirstName + " " + user.LastName;

                        imgAuthorizedSignatory.ImageUrl = user.SignPath != string.Empty ? host + "/Uploads/Photo/" + user.SignPath : host + "/Uploads/Photo/NotSign.jpg";
                        if (AccessList[0].AuthorizedSignatureDate != DateTime.MinValue)
                            lblAuthorizedDate.Text = AccessList[0].AuthorizedSignatureDate.ToString("dd MMM yy (ddd)");

                    }
                }

                if (AccessList[0].IsPartySignature == true)
                {
                    divPartySigchk.Visible = false;
                    divPartySig.Visible = true;
                    //foreach (var user in ApplicationHelper.Users)
                    //{
                    //    if (AccessList[0].PartySignatureBy == user.UserID)
                    //    {
                    //        lblPartyName.Text = user.FirstName + " " + user.LastName;
                    //        imgpartysingature.ImageUrl = user.SignPath != string.Empty ? host + "/Uploads/Photo/" + user.SignPath : host + "/Uploads/Photo/NotSign.jpg";
                    //        if (AccessList[0].PartySignatureDate != DateTime.MinValue)
                    //            lblPartyDate.Text = AccessList[0].PartySignatureDate.ToString("dd MMM yy (ddd)");
                    //    }
                    //}

                    var user = ApplicationHelper.Users.Where(x => x.UserID == AccessList[0].PartySignatureBy).FirstOrDefault();
                    if (user != null)
                    {
                        lblPartyName.Text = user.FirstName + " " + user.LastName + "</br>" + "<span style=Font-size:8px;>(On Behalf of " + AccessList[0].SupplierName + ")</span>";
                        lblPartyName.Style.Add("Text-align", "Center");

                        lblPartyName.Style.Add("font-size", "8px");

                        imgpartysingature.ImageUrl = user.SignPath != string.Empty ? host + "/Uploads/Photo/" + user.SignPath : host + "/Uploads/Photo/NotSign.jpg";
                        if (AccessList[0].PartySignatureDate != DateTime.MinValue)
                            lblPartyDate.Text = AccessList[0].PartySignatureDate.ToString("dd MMM yy (ddd)");

                    }
                }



            }
            catch (Exception ex)
            {

            }
        }

        private void Bind_Eta_History()
        {
            DataTable dtEta = new DataTable();

            DataSet ds = objAccessory.GetAccessory_SupplierPurchase_Eta_History(SupplierPoId, AccessoryType);
            DataTable dtHistory = ds.Tables[0];

            if (dtHistory.Rows.Count > 0)
            {
                grdHistoryQty.DataSource = dtHistory;
                grdHistoryQty.DataBind();
                dvHeader.InnerHtml = "History Of Revise Purchase Order";
                dvHeader.Style.Add("display", "");
                if ((AccessoryType == 1) || (AccessoryType == 3))
                {
                    grdHistoryQty.Columns[1].Visible = false;
                }
            }
            if (ViewState["dtEta"] == null)
            {
                dtEta = ds.Tables[1];
                if (dtEta.Rows.Count > 0)
                {
                    ViewState["dtEta"] = dtEta;
                }
                else
                {
                    DataRow dr = dtEta.NewRow();
                    dr["SupplierPO_ETA_Id"] = 1;
                    dr["SupplierPO_Id"] = SupplierPoId;
                    dr["RowNumber"] = 1;
                    dr["FromQty"] = 1;
                    dr["ToQty"] = hdnReceivedQty.Value == "" ? -1 : Convert.ToInt32(hdnReceivedQty.Value);

                    dr["POETADate"] = DateTime.ParseExact(lblETADate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
                    dtEta.Rows.Add(dr);
                    ViewState["dtEta"] = dtEta;
                }
            }
            dtEta = (DataTable)ViewState["dtEta"];
            grdQtyRange.DataSource = dtEta;
            grdQtyRange.DataBind();

            DataTable dtPOInstruction = ds.Tables[2];
            divguidline.InnerHtml = dtPOInstruction.Rows[0]["value"].ToString();
        }

        protected void grdQtyRange_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int iRowIndex = e.Row.RowIndex;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                Label lblHdrFromQty = (Label)e.Row.FindControl("lblHdrFromQty");
                Label lblHdrToQty = (Label)e.Row.FindControl("lblHdrToQty");

                lblHdrFromQty.Text = "From Qty.";
                lblHdrToQty.Text = "To Qty.";

            }
            if ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == DataControlRowState.Alternate))
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblFromQty = (Label)e.Row.FindControl("lblFromQty");
                    Label lblToQty = (Label)e.Row.FindControl("lblToQty");
                    if (lblFromQty.Text != "")
                    {
                        lblFromQty.Text = Convert.ToInt32(lblFromQty.Text).ToString("N0");
                    }
                    if (lblToQty.Text != "")
                    {
                        lblToQty.Text = Convert.ToInt32(lblToQty.Text).ToString("N0");
                    }
                }
            }
        }

        protected void grdHistoryQty_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSendQty = (Label)e.Row.FindControl("lblSendQty");
                Label lblPoQuantity = (Label)e.Row.FindControl("lblPoQuantity");

                int SendQty = DataBinder.Eval(e.Row.DataItem, "SendQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SendQty"));
                int POQuantity = DataBinder.Eval(e.Row.DataItem, "POQuantity") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "POQuantity"));
                string UnitName = DataBinder.Eval(e.Row.DataItem, "UnitName").ToString();

                if (SendQty != 0)
                {
                    string sQuantity = SendQty.ToString("#,##0") + " <span style='color:gray;font-weight:600'>" + UnitName + "</span>";
                    lblSendQty.Text = sQuantity;
                }
                if (POQuantity != 0)
                {
                    string sQuantity = POQuantity.ToString("#,##0") + " <span style='color:gray;font-weight:600'>" + UnitName + "</span>";
                    lblPoQuantity.Text = sQuantity;
                }
            }
        }
    }
}