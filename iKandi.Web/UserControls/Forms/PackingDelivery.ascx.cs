using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Web.Components;
using iKandi.Common;
using System.Web.UI;
using System.IO;
using System.Text;
using System.Collections;



namespace iKandi.Web.UserControls.Forms
{
    public partial class psckingDelivery : BaseUserControl
    {
        #region Properties
        String Deliveryfolder = "~/" + System.Configuration.ConfigurationManager.AppSettings["delivery.docs.folder"];
        public int OrderID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["orderid"]))
                {
                    return Convert.ToInt32(Request.QueryString["orderid"]);
                }

                return -1;
            }
        }
        public string Flag
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Flag"]))
                {
                    return Convert.ToString(Request.QueryString["Flag"]);
                }

                return "";
            }
        }
        public static int LoggedInUserID
        {

            get
            {
                if (ApplicationHelper.LoggedInUser.UserData.UserID.ToString() != "" && ApplicationHelper.LoggedInUser.UserData.UserID.ToString() != "-1")
                    return Convert.ToInt32((ApplicationHelper.LoggedInUser.UserData.UserID));
                return -1;
            }

        }
        public int OrderDetailID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["OrderDetailID"]))
                {
                    return Convert.ToInt32(Request.QueryString["OrderDetailID"]);
                }

                return -1;
            }
        }
        public int ShippingID = -1;

        public int ShipmentNoID
        {

            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ShipmentNoID"]))
                {
                    return Convert.ToInt32(Request.QueryString["ShipmentNoID"]);
                }
                return -1;
            }


        }
        public string ShipmentNoQuery
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ShipmentNoQuery"]))
                {
                    return Convert.ToString(Request.QueryString["ShipmentNoQuery"]).Replace(" ", "-").Replace("%", "-").ToUpper();

                }
                return "";
            }


        }
        //public string BankRefNoQuery
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(Request.QueryString["BankRefNoQuery"]))
        //        {
        //            return Convert.ToString(Request.QueryString["BankRefNoQuery"]).Replace(" ", "-").Replace("%", "-").ToUpper();

        //        }
        //        return "";
        //    }
        //  set
        //  {

        //  }


        //}
        public string BankRefNoQuery;

        public static string BankRefNo;
        int parentRow = -1;
        string BankRefNumber = "";
     

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {


            // DivPro.Visible = true;
            // Flag = "CONSOLIDATION";
            //Flag = "INVOICEPAYMENT";
            //OrderDetailID = 13087;
            if (!Page.IsPostBack)
            {
                //DataSet ds = this.InvoiceControllerInstance.GetBankRefNoForGrouping("DELETE",-1);
                if (!string.IsNullOrEmpty(Request.QueryString["BankRefNoQuery"]))
                {
                    BankRefNoQuery = (Request.QueryString["BankRefNoQuery"]).ToString();
                }
                else
                {
                    BankRefNoQuery = "";
                }

                BindPackingGrd();



            }
            if (!CheckLoginSession())
            {
                ShowAlert("Your login session expire please login again");
                return;
            }
            //HideProg();
            //  DivPro.Attributes.Add("style", "display:none");


            // Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript", "hide();", true);

        }
        //public void ShowProg()
        //{
        //  //DivPro.Attributes.Add("style", "display:none");
        //  DivPro.Attributes.Add("style", "display:block");
        //}
        //public void HideProg()
        //{
        //  DivPro.Attributes.Add("style", "display:none");
        // // DivPro.Attributes.Add("style", "display:block");
        //}

        public bool CheckLoginSession()
        {
            bool check = true;
            //if (LoggedInUserID == null || LoggedInUserID == -1)
            if (LoggedInUserID == -1)
            {
                check = false;
                //ShowAlert("Your login session expire please login again");
            }
            return check;

        }
        public void BindPackingGrd()
        {
            DataSet ds = new DataSet();
            //ds=this.InvoiceControllerInstance.GetPackingInvoiceDetails(Flag, OrderID);

            ds = this.InvoiceControllerInstance.GetPackingInvoiceDetails(Flag, OrderID, OrderDetailID);//TODO:


            if (Flag == "" || Flag == "PACKING")
            {
                tblinvoice.Visible = false;
                //trlandingETA.Visible = false;
                //  trlInvoice1.Visible = false;
                trlInvoice2.Visible = false;
                //   trlInvoice3.Visible = false;
                trlInvoice4.Visible = false;
                //  trConsolidation.Visible = false;
                divSearch.Visible = false;
                BindConsolidationGrd();
                Headertext.Text = "Packing List";
                tblinvoice.Visible = false;
            }
            else if (Flag == "CONSOLIDATION")
            {
                //pnlDisable
                Headertext.Text = "Consolidation";
                tblPacking.Visible = true;
                //   trlInvoice1.Visible = false;
                trlInvoice2.Visible = false;
                //   trlInvoice3.Visible = false;
                trlInvoice4.Visible = false;
                divSearch.Visible = true;

                BindshippingDetails(ds.Tables[1]);
                //BindInvoiceDetails(ds.Tables[1]);
                string ShippingNo = string.Empty;
                ShippingID = Convert.ToInt32(ddlshipingno.SelectedValue);
                if (ddlshipingno.SelectedValue != "999")
                {
                    ShippingNo = ddlshipingno.SelectedItem.Text.ToUpper();
                    ds = this.InvoiceControllerInstance.GetPackingDetailsByShippingNo("SIPPINGDETAIL", OrderID, OrderDetailID, ShippingNo, Convert.ToInt32(ddlshipingno.SelectedValue), txtsearch.Text.Trim());//TODO:
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {

                        if (dt.Rows[0]["LandingETA"].ToString() != "1/1/1900 12:00:00 AM")
                        {

                            txtlandingETA.Text = Convert.ToDateTime(dt.Rows[0]["LandingETA"].ToString()).ToString("dd MMM yy (ddd)");
                        }
                        else
                        {
                            txtlandingETA.Text = string.Empty;
                        }

                        txtAwb.Text = dt.Rows[0]["AWBNo"].ToString();
                        txtFlightDetails.Text = dt.Rows[0]["FlightSailingDetails"].ToString();

                    }
                }
                else
                {
                    ShowAlert("Selected shipping number " + "[ " + ddlshipingno.SelectedItem.Text.ToUpper() + " ]" + " is new choose this for fresh entry");
                    ShippingID = -1;
                    txtlandingETA.Text = "";
                    txtAwb.Text = "";
                    txtFlightDetails.Text = "";


                }
                BindConsolidationGrd();
            }
            else if (Flag == "INVOICED")
            {
                //Headertext.Text = "Invoicing & Consolidation";
                Headertext.Text = "Invoicing";
                tblPacking.Visible = false;
                tblinvoice.Visible = true;
                // trlandingETA.Visible = true;
                //trlInvoice1.Visible = true;
                trlInvoice2.Visible = true;
                // trlInvoice3.Visible = true;
                trlInvoice4.Visible = true;
                divSearch.Visible = true;
                BindInvoiceDetails(ds.Tables[1]);
                string ShippingNo = string.Empty;
                ShippingID = Convert.ToInt32(ddlshipingno.SelectedValue);
                if (ddlshipingno.SelectedValue != "999")
                {
                    ShippingNo = ddlshipingno.SelectedItem.Text.ToUpper();
                    ddlshipingno.Enabled = false;
                    ds = this.InvoiceControllerInstance.GetPackingDetailsByShippingNo("SIPPINGDETAIL", OrderID, OrderDetailID, ShippingNo, Convert.ToInt32(ddlshipingno.SelectedValue), txtsearch.Text.Trim());//TODO:
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["LandingETA"].ToString() != "1/1/1900 12:00:00 AM")
                        {
                            txtlandingETA.Text = Convert.ToDateTime(dt.Rows[0]["LandingETA"].ToString()).ToString("dd MMM yy (ddd)");
                        }
                        else
                        {
                            txtlandingETA.Text = string.Empty;
                        }
                        txtAwb.Text = dt.Rows[0]["AWBNo"].ToString();
                        txtFlightDetails.Text = dt.Rows[0]["FlightSailingDetails"].ToString();
                        txtInvoiceNo.Text = dt.Rows[0]["InvoiceNumber"].ToString();
                        hdninvoiceno.Value = dt.Rows[0]["InvoiceNumber"].ToString();
                        // txtInvoiceAmt.Text = (dt.Rows[0]["InvoiceAmt"].ToString() == "0" ? "" : Convert.ToDouble(dt.Rows[0]["InvoiceAmt"]).ToString());
                        txtInvoiceAmt.Text = (Convert.ToDouble(dt.Rows[0]["TotShipvalue"]) <= 0 ? "" : Convert.ToDouble(dt.Rows[0]["TotShipvalue"]).ToString("F"));
                        txtfrightcharge.Text = (Convert.ToDouble(dt.Rows[0]["FrieghtCharge"]) <= 0 ? "" : Convert.ToDouble(dt.Rows[0]["FrieghtCharge"]).ToString("F"));
                        txtInsuranceAmt.Text = (Convert.ToDouble(dt.Rows[0]["InsuranceAmt"]) <= 0 ? "" : Convert.ToDouble(dt.Rows[0]["InsuranceAmt"]).ToString("F"));
                        txtDiscountAmt.Text = (Convert.ToDouble(dt.Rows[0]["DiscCommissionAmt"]) <= 0 ? "" : Convert.ToDouble(dt.Rows[0]["DiscCommissionAmt"]).ToString("F"));
                        if (Convert.ToDouble(dt.Rows[0]["InvoiceAmt"]) <= 0)
                            txtinvoicetotalAmt.Text = txtInvoiceAmt.Text;
                        else
                            txtinvoicetotalAmt.Text = (Convert.ToDouble(dt.Rows[0]["InvoiceAmt"]) <= 0 ? "" : Convert.ToDouble(dt.Rows[0]["InvoiceAmt"]).ToString("F"));

                        //Edit By Surendra2 on 17-04-2018.
                        txtinvoiceDate.Text = Convert.ToDateTime(dt.Rows[0]["InvoiceDate"].ToString()).ToString() == Convert.ToDateTime("01/01/1900").ToString() ? "" : Convert.ToDateTime(dt.Rows[0]["InvoiceDate"].ToString()).ToString("dd MMM yy (ddd)");
                        txtsbDate.Text = Convert.ToDateTime(dt.Rows[0]["SBDate"].ToString()).ToString() == Convert.ToDateTime("01/01/1900").ToString() ? "" : Convert.ToDateTime(dt.Rows[0]["SBDate"].ToString()).ToString("dd MMM yy (ddd)");
                        txtPaymentDueDate.Text = Convert.ToDateTime(dt.Rows[0]["PaymentDueDate"].ToString()).ToString() == Convert.ToDateTime("01/01/1900").ToString() ? "" : Convert.ToDateTime(dt.Rows[0]["PaymentDueDate"].ToString()).ToString("dd MMM yy (ddd)");
                        
                        txtsbNo.Text = dt.Rows[0]["SBNumber"].ToString();
                    }
                }
                else
                {
                    ShowAlert("Selected shipping number " + "[ " + ddlshipingno.SelectedItem.Text.ToUpper() + " ]" + " is new choose this for fresh entry");
                    ShippingID = -1;
                    txtlandingETA.Text = "";
                    txtAwb.Text = "";
                    txtFlightDetails.Text = "";
                    txtInvoiceNo.Text = "";
                    hdninvoiceno.Value = "";
                    txtInvoiceAmt.Text = "";
                    txtinvoicetotalAmt.Text = "";
                    txtinvoiceDate.Text = "";
                    txtsbDate.Text = "";
                    txtPaymentDueDate.Text = "";
                }

                BindConsolidationGrd();
            }
            else if (Flag == "INVOICEPAYMENT")
            {
                tblinvoice.Visible = false;
                divSearch.Visible = false;
                Headertext.Text = "Invoice Grouping, Bank Ref.No. & Payment Receive";
                BindInvoicePayment();


            }



        }
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            string bankrefNo = "",  IsAction = "N";
            List<PackingDelivery> PackingDelivery = this.InvoiceControllerInstance.GetBIPLInvoiceDetails(Flag, bankrefNo, IsAction, txtsearch.Text.Trim());
            var filterdList = new List<PackingDelivery>();
            if (txtSearch2.Text.Trim() != "")
            {
                foreach (var InvNo in PackingDelivery)
                {

                    if (InvNo.InvoiceNumber.ToLower() == txtSearch2.Text.Trim().ToLower())
                    {
                        filterdList.Add(InvNo);
                    }


                }
                grdinvoice.DataSource = filterdList;
                grdinvoice.DataBind();

            }
            else
            {
                grdinvoice.DataSource = PackingDelivery;
                grdinvoice.DataBind();
            }



        }
        public void BindInvoicePayment(string bankrefNo = "", string IsAction = "N")
        {
            bankrefNo = (bankrefNo == "" ? BankRefNoQuery : bankrefNo);
            if (Flag == "INVOICEPAYMENT")
            {
                tblPacking.Visible = false;
                //trlInvoice1.Visible = false;
                trlInvoice2.Visible = false;
                // trlInvoice3.Visible = false;
                trlInvoice4.Visible = false;
                divSearch.Visible = true;
                //  trConsolidation.Visible = false;
                // trlandingETA.Visible = false;
                divSearch.Visible = false;
                grdpacking.Visible = false;
                grdinvoice.Visible = true;
                List<PackingDelivery> PackingDelivery = this.InvoiceControllerInstance.GetBIPLInvoiceDetails(Flag, bankrefNo, IsAction, txtsearch.Text.Trim());
                
                grdinvoice.DataSource = PackingDelivery;
                grdinvoice.DataBind();
                if (PackingDelivery[0].IsFullPaymentCleard == 1)
                    // DisablePageControls(false); // To enable                  
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "RefreshParentPage", "<script language='javascript'>disablePage();</script>");

                // DisablePageControls(true); // To disable  




            }
        }
        public void DisablePageControls(bool status)
        {
            foreach (Control c in Page.Controls)
            {
                foreach (Control ctrl in c.Controls)
                {
                    if (ctrl is TextBox)
                        ((TextBox)ctrl).Enabled = status;
                    else if (ctrl is Button)
                        ((Button)ctrl).Enabled = status;
                    else if (ctrl is RadioButton)
                        ((RadioButton)ctrl).Enabled = status;
                    else if (ctrl is RadioButtonList)
                        ((RadioButtonList)ctrl).Enabled = status;
                    else if (ctrl is ImageButton)
                        ((ImageButton)ctrl).Enabled = status;
                    else if (ctrl is CheckBox)
                        ((CheckBox)ctrl).Enabled = status;
                    else if (ctrl is CheckBoxList)
                        ((CheckBoxList)ctrl).Enabled = status;
                    else if (ctrl is DropDownList)
                        ((DropDownList)ctrl).Enabled = status;
                    else if (ctrl is HyperLink)
                        ((HyperLink)ctrl).Enabled = status;
                }
            }
        }
        /*public void BindConsolidationGrd() //packing List
        {
           
            DataSet ds = new DataSet();
            if (Flag == "PACKING")
            {
                ds = this.InvoiceControllerInstance.GetPackingDetailsByShippingNo(Flag, OrderID, OrderDetailID, "", -1, txtsearch.Text.Trim());//TODO:
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    grdpacking.DataSource = dt;
                    grdpacking.DataBind();


                    hdnpackinglistfile.Value = dt.Rows[0]["PackingListUploadPath"].ToString();
                    if (hdnpackinglistfile.Value != "")
                    {
                        viewpackinglist.Visible = true;
                        viewpackinglist.NavigateUrl = Deliveryfolder + hdnpackinglistfile.Value;
                        viewpackinglist.Attributes.Add("style", "display:block;");

                    }
                }
            }
            if (Flag == "PACKING" || Flag == "CONSOLIDATION")
            {
                ds = this.InvoiceControllerInstance.GetPackingDetailsByShippingNo(Flag, OrderID, OrderDetailID, "", -1, txtsearch.Text.Trim());//TODO:
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    grdpacking.DataSource = dt;
                    grdpacking.DataBind();


                    hdnpackinglistfile.Value = dt.Rows[0]["PackingListUploadPath"].ToString();
                    if (hdnpackinglistfile.Value != "")
                    {
                        viewpackinglist.Visible = true;
                        viewpackinglist.NavigateUrl = Deliveryfolder + hdnpackinglistfile.Value;
                        viewpackinglist.Attributes.Add("style", "display:block;");

                    }
                }
            }
            if (Flag == "CONSOLIDATION")
            {
                String ShippingNo = (ddlshipingno != null ? ddlshipingno.SelectedItem.Text.Trim().ToUpper() : "");
                ds = this.InvoiceControllerInstance.GetPackingDetailsByShippingNo(Flag, OrderID, OrderDetailID, ShippingNo, Convert.ToInt32(ddlshipingno.SelectedValue), txtsearch.Text.Trim());//TODO:
                grdpacking.DataSource = ds.Tables[0];
                grdpacking.DataBind();
            }
            if (Flag == "INVOICED")
            {
                String ShippingNo = (ddlshipingno != null ? ddlshipingno.SelectedItem.Text.Trim().ToUpper() : "");
                ds = this.InvoiceControllerInstance.GetPackingDetailsByShippingNo(Flag, OrderID, OrderDetailID, ShipmentNoQuery, Convert.ToInt32(ddlshipingno.SelectedValue), txtsearch.Text.Trim());//TODO:
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    grdpacking.DataSource = dt;
                    grdpacking.DataBind();

                    hdnnovicelistfile.Value = dt.Rows[0]["InvoiceFilePath"].ToString();
                    if (hdnnovicelistfile.Value != "")
                    {
                        hyplnkinvoice.Visible = true;
                        hyplnkinvoice.NavigateUrl = ResolveUrl("~/Uploads/Delivery/" + hdnnovicelistfile.Value);
                       // hyplnkinvoice.Attributes.Add("style", "display:block;");

                    }
                 
                    if (dt.Rows[0]["ConvertTo"].ToString() != "")
                    {                   
                        string currencyName = "GBP";
                        string currencySign = "&pound;";
                        int ClientCurrency=Convert.ToInt32(dt.Rows[0]["ConvertTo"].ToString());
                        lblCurrencySy.Visible = true; lblcur1.Visible = true; lblcur2.Visible = true;;lblcur3.Visible = true;
                   
                        if(Enum.IsDefined(typeof(Currency), Convert.ToInt32(ClientCurrency)))
                        {
                             currencyName = Enum.GetName(typeof(Currency), Convert.ToInt32(ClientCurrency));
                             lblCurrencySy.Text = currencySign;lblcur1.Text = currencySign;lblcur2.Text = currencySign;lblcur3.Text = currencySign;
                        }

                    }

                }
            }

        }*/
        public void BindConsolidationGrd() //packing List
        {

            DataSet ds = new DataSet();
            if (Flag == "PACKING" || Flag == "CONSOLIDATION")
            {

                ds = this.InvoiceControllerInstance.GetPackingDetailsByShippingNo("PACKING", OrderID, OrderDetailID, ddlshipingno.SelectedItem.Text, -1, txtsearch.Text.Trim());//TODO:
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    //grdpacking.DataSource = dt;
                    //grdpacking.DataBind();


                    hdnpackinglistfile.Value = dt.Rows[0]["PackingListUploadPath"].ToString();
                    if (hdnpackinglistfile.Value != "")
                    {
                        viewpackinglist.Visible = true;
                        viewpackinglist.NavigateUrl = Deliveryfolder + hdnpackinglistfile.Value;
                        viewpackinglist.Attributes.Add("style", "display:block;");
                    }
                    else
                    {
                        viewpackinglist.Visible = false;
                        viewpackinglist.NavigateUrl = "";
                    }
                }
                else
                {
                    viewpackinglist.Visible = false;
                    viewpackinglist.NavigateUrl = "";

                }
            }

            if (Flag == "CONSOLIDATION")
            {
                String ShippingNo = (ddlshipingno != null ? ddlshipingno.SelectedItem.Text.Trim().ToUpper() : "");
                ds = this.InvoiceControllerInstance.GetPackingDetailsByShippingNo(Flag, OrderID, OrderDetailID, ShippingNo, Convert.ToInt32(ddlshipingno.SelectedValue), txtsearch.Text.Trim());//TODO:
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdpacking.DataSource = ds.Tables[0];
                    grdpacking.DataBind();
                }
                else
                {
                    grdpacking.DataSource = new List<object>();
                    grdpacking.DataBind();
                }

            }
            if (Flag == "INVOICED")
            {
                String ShippingNo = (ddlshipingno != null ? ddlshipingno.SelectedItem.Text.Trim().ToUpper() : "");
                ds = this.InvoiceControllerInstance.GetPackingDetailsByShippingNo(Flag, OrderID, OrderDetailID, ShipmentNoQuery, Convert.ToInt32(ddlshipingno.SelectedValue), txtsearch.Text.Trim());//TODO:
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    grdpacking.DataSource = dt;
                    grdpacking.DataBind();
                    GetShipValue();

                    hdnnovicelistfile.Value = dt.Rows[0]["InvoiceFilePath"].ToString();
                    if (hdnnovicelistfile.Value != "")
                    {
                        hyplnkinvoice.Visible = true;
                        hyplnkinvoice.NavigateUrl = ResolveUrl("~/Uploads/Delivery/" + hdnnovicelistfile.Value);
                        // hyplnkinvoice.Attributes.Add("style", "display:block;");

                    }

                    if (dt.Rows[0]["ConvertTo"].ToString() != "")
                    {
                        string currencyName = "GBP";
                        string currencySign = "&pound;";
                        int ClientCurrency = Convert.ToInt32(dt.Rows[0]["ConvertTo"].ToString());
                        lblCurrencySy.Visible = true; lblcur1.Visible = true; lblcur2.Visible = true; ; lblcur3.Visible = true; lblcur4.Visible = true;

                        if (Enum.IsDefined(typeof(Currency), Convert.ToInt32(ClientCurrency)))
                        {
                            currencyName = Enum.GetName(typeof(Currency), Convert.ToInt32(ClientCurrency));
                            lblCurrencySy.Text = currencySign; lblcur1.Text = currencySign; lblcur2.Text = currencySign; lblcur3.Text = currencySign; lblcur4.Text = currencySign;
                        }

                    }

                }
                else
                {
                    grdpacking.DataSource = new List<object>();
                    grdpacking.DataBind();
                }
            }

        }
        public void BindshippingDetails(DataTable dt)
        {
            if (Flag == "CONSOLIDATION")
            {
                BindDdlShippingNo();
                if (dt.Rows.Count > 0)
                {

                    ListItem item = ddlshipingno.Items.FindByText(dt.Rows[0]["ShipmentNo"].ToString());
                    if (item != null)
                    {
                        // ddlshipingno.Items.FindByText(dt.Rows[0]["ShipmentNo"].ToString()).Selected = true;
                        //ddlshipingno.SelectedValue = dt.Rows[0]["ShipmentNo_Invoice_Details_PkID"].ToString();
                        string itemToCompare = string.Empty;
                        string itemOrigin = dt.Rows[0]["ShipmentNo"].ToString().ToLower();
                        foreach (ListItem items in ddlshipingno.Items)
                        {
                            itemToCompare = items.Text.ToLower();
                            if (itemOrigin == itemToCompare)
                            {
                                ddlshipingno.ClearSelection();
                                items.Selected = true;
                            }

                        }
                    }
                    if (dt.Rows[0]["LandingETA"].ToString() != "1/1/1900 12:00:00 AM")
                    {
                        //DateTime LandingETA = iKandi.Web.Components.DateHelper.ParseDate(dt.Rows[0]["LandingETA"].ToString()).Value;
                        txtlandingETA.Text = Convert.ToDateTime(dt.Rows[0]["LandingETA"].ToString()).ToString("dd MMM yy (ddd)");
                    }
                    txtAwb.Text = dt.Rows[0]["AWBNo"].ToString();
                    txtFlightDetails.Text = dt.Rows[0]["FlightSailingDetails"].ToString();

                    ShippingID = Convert.ToInt32(ddlshipingno.SelectedValue);
                }
                else
                {
                    ListItem lastItem = ddlshipingno.Items[ddlshipingno.Items.Count - 1];
                    lastItem.Selected = true;
                }
            }
        }
        public void BindInvoiceDetails(DataTable dt)
        {
            BindDdlShippingNo();
            if (dt.Rows.Count > 0)
            {
                ListItem item = ddlshipingno.Items.FindByText(dt.Rows[0]["ShipmentNo"].ToString());
                if (item != null)
                {
                    string itemToCompare = string.Empty;
                    string itemOrigin = dt.Rows[0]["ShipmentNo"].ToString().ToLower();
                    foreach (ListItem items in ddlshipingno.Items)
                    {
                        itemToCompare = items.Text.ToLower();
                        if (itemOrigin == itemToCompare)
                        {
                            ddlshipingno.ClearSelection();
                            items.Selected = true;
                        }
                    }
                }
                ShippingID = Convert.ToInt32(ddlshipingno.SelectedValue);
            }
        }
        public void BindDdlShippingNo()
        {
            DataSet ds = new DataSet();
            ds = this.InvoiceControllerInstance.GetPackingShippingNo("SHIPPING", OrderDetailID);
            if (Flag == "CONSOLIDATION")
            {
                if (ds.Tables[0].Rows[0]["bnkrefNo"].ToString() != "")

                    pnlDisable.Enabled = false;
                else
                    pnlDisable.Enabled = true;

                if (ds.Tables[0].Rows[0]["InvoiceNo"].ToString() != "")

                    ddlshipingno.Enabled = false;
                else
                    ddlshipingno.Enabled = true;

            }
            else if (Flag == "INVOICED")
            {
                if (ds.Tables[0].Rows[0]["bnkrefNo"].ToString() != "")
                    pnlDisable.Enabled = false;
                else
                    pnlDisable.Enabled = true;
            }
            ddlshipingno.DataSource = ds.Tables[0];
            ddlshipingno.DataTextField = "ShipmentNo";
            ddlshipingno.DataValueField = "ShipmentNo_Invoice_Details_PkID";

            ddlshipingno.DataBind();

        }
        protected void grdpacking_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox ChkConsoli = e.Row.FindControl("ChkConsoli") as CheckBox;
                    CheckBox Chkinvice = e.Row.FindControl("Chkinvice") as CheckBox;
                    HiddenField hdnOrderDetailID = e.Row.FindControl("hdnOrderDetailID") as HiddenField;
                    if (Flag == "CONSOLIDATION")
                    {
                        if (hdnOrderDetailID.Value == OrderDetailID.ToString())
                        {
                            ChkConsoli.Checked = true;
                            ChkConsoli.Enabled = false;
                        }
                        ChkConsoli.Visible = true;
                        Chkinvice.Visible = false;
                    }
                    if (ChkConsoli.Checked)
                    {
                        //DataTable dt = this.InvoiceControllerInstance.GetInvoiceShippedValue("SHIPPEDVALUE", Convert.ToInt32(hdnOrderDetailID.Value));
                        //ShippedValueSum = ShippedValueSum + Convert.ToInt32((dt.Rows[0]["ShippedValue"]));
                        if (Flag == "INVOICED")
                        {
                            Chkinvice.Enabled = false;
                            ChkConsoli.Visible = false;
                            Chkinvice.Visible = true;
                        }

                    }
                    //txtInvoiceAmt.Text = (ShippedValueSum<=0?"0": ShippedValueSum.ToString());
                    //txtinvoicetotalAmt.Text = txtInvoiceAmt.Text;
                    //hdninvoicetotalAmt.Value=txtInvoiceAmt.Text;
                    //GetInvoiceActualAmt();


                }
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }

        }

        //protected void btnSave_Click(object sender, EventArgs e)
        //{
            //try
            //{
            //    btnSave.Enabled = false;
            //    // DataSet ds = this.InvoiceControllerInstance.GetBankRefNoForGrouping("DELETE",-1); //delete action check box
            //    //if (Flag == "PACKING")
            //    //{
            //    //    SavePackingDetails();
            //    //}
            //    if (Flag == "CONSOLIDATION")
            //    {
            //        SaveConsolidationDetails();
            //        bool IsTrue;
            //        SavePackingDetails(out IsTrue);
            //        if (!IsTrue)
            //        {
            //            return;
            //        }
            //        else
            //            BindConsolidationGrd();
            //    }
            //    else if (Flag == "INVOICED")
            //    {
            //        SaveInvoiceDetails();
            //    }
            //    else if (Flag == "INVOICEPAYMENT")
            //    {
            //        if (ValidateActionCheckBox() == false)
            //        {
            //            Response.Redirect(Request.RawUrl);
            //            return;
            //            //ShowAlert("Please select at least one action check box");
            //            //return;

            //        }

            //        string StrErrorSingleSplit = "";
            //        string StrErrorMultipleSplit = "";
            //        bool IsSingl = false;
            //        bool IsMultple = false;
            //        IsSingl = SaveInvoicePaymentDetails(out StrErrorSingleSplit);
            //        if (IsSingl)
            //        {
            //            IsMultple = UpdateSplitOderBillingDetail(out StrErrorMultipleSplit);
            //        }
            //        if (IsSingl && IsMultple)
            //        {
            //            ShowAlert("Payment details updated successfully");
            //            BankRefNo = ""; BankRefNoQuery = "";
            //            BindPackingGrd();

            //        }
            //        else
            //        {
            //            ShowAlert("Some error occurred while updating record please contact with website administration");
            //            btnSave.Enabled = true;
            //            return;
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    ShowAlert(ex.ToString());
            //}
            //finally
            //{
            //    btnSave.Enabled = true;
            //}
       // }
        public bool ValidateContract()
        {
            bool Result = false;
            int rowCount = grdpacking.Rows.Count;
            foreach (GridViewRow row in grdpacking.Rows)
            {
                CheckBox ChkConsoliValidate = (CheckBox)row.FindControl("ChkConsoli");
                if (ChkConsoliValidate != null)
                {
                    if (ChkConsoliValidate.Checked == true)
                    {
                        Result = true;
                        break;
                    }
                }

            }
            return Result;

        }

        //public void SavePackingDetails()  packing list separate code 
        //{

        //    iKandi.Common.PackingDelivery PackingDelivery = new iKandi.Common.PackingDelivery();
        //    PackingDelivery.LoggedInUserID = LoggedInUserID;

        //    if (Flag == "PACKING")
        //    {

        //        PackingDelivery.Flag = Flag;
        //        if (UpPackingFile.HasFile)
        //        {

        //        }
        //        else
        //        {
        //            if (!string.IsNullOrEmpty(hdnpackinglistfile.Value))
        //            { }
        //            else
        //            {
        //                ShowAlert("Please select packing document");
        //                return;
        //            }

        //        }
        //        if (ValidateContract() == false)
        //        {
        //            ShowAlert("Please select at least on contract");
        //            return;
        //        }
        //        bool result = false;
        //        foreach (GridViewRow row in grdpacking.Rows)
        //        {
        //            HiddenField hdnOrderDetailID = (HiddenField)row.FindControl("hdnOrderDetailID");
        //            CheckBox ChkConsoli = (CheckBox)row.FindControl("ChkConsoli");
        //            Label lblContractNo = (Label)row.FindControl("lblContractNo");

        //            PackingDelivery.IsConsolidation = (ChkConsoli.Checked == true ? 1 : 0);
        //            if (hdnOrderDetailID != null && ChkConsoli != null)
        //            {
        //                if (Flag == "PACKING")
        //                {

        //                    string PackingFileName = string.Empty;
        //                    PackingDelivery.PackingListFilePath = "";
        //                    if (ChkConsoli.Checked)
        //                    {

        //                        if (UpPackingFile.HasFile)
        //                        {
        //                            PackingDelivery.PackingListFilePath = hdnOrderDetailID.Value + "_" + "PackingList" +"_"+ Path.GetFileNameWithoutExtension(this.UpPackingFile.FileName) + Path.GetExtension(this.UpPackingFile.FileName);
        //                            if (File.Exists(Server.MapPath(Deliveryfolder) + PackingDelivery.PackingListFilePath))
        //                            {
        //                                // File.Delete(Server.MapPath(Deliveryfolder) + PackingDelivery.PackingListFilePath);
        //                            }
        //                            else
        //                            {
        //                                //PackingDelivery.InvoiceFilePath = iKandi.Web.Components.FileHelper.SaveFile(UpPackingFile.PostedFile.InputStream, PackingDelivery.PackingListFilePath, Constants.DELIVERY_FOLDER_PATH, false, PackingDelivery.PackingListFilePath);
        //                                UpPackingFile.SaveAs(Server.MapPath(Deliveryfolder) + PackingDelivery.PackingListFilePath);
        //                            }
        //                        }
        //                        else if (!string.IsNullOrEmpty(hdnpackinglistfile.Value))
        //                        {                                   
        //                            string[] stringArray = hdnpackinglistfile.Value.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);                                  
        //                            PackingDelivery.PackingListFilePath = hdnOrderDetailID.Value + "_" + stringArray[1] + "_" + stringArray[2];
        //                            if (File.Exists(Server.MapPath(Deliveryfolder) + PackingDelivery.PackingListFilePath))
        //                            {
        //                                //File.Delete(Server.MapPath(Deliveryfolder) + PackingDelivery.PackingListFilePath);
        //                            }
        //                            else
        //                            {
        //                                CopyFileWithDiffName(hdnpackinglistfile.Value, PackingDelivery.PackingListFilePath);
        //                                //PackingDelivery.PackingListFilePath = iKandi.Web.Components.FileHelper.SaveFile(UpPackingFile.PostedFile.InputStream, PackingDelivery.PackingListFilePath, Constants.DELIVERY_FOLDER_PATH, false, PackingDelivery.PackingListFilePath);
        //                                //UpPackingFile.SaveAs(Server.MapPath(Deliveryfolder) + PackingDelivery.PackingListFilePath);
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        PackingDelivery.PackingListFilePath = "";
        //                    }

        //                        PackingDelivery.InvoiceFilePath = PackingDelivery.PackingListFilePath;

        //                        //PackingDelivery.InvoiceFilePath = iKandi.Web.Components.FileHelper.SaveFile(UpPackingFile.PostedFile.InputStream, PackingDelivery.PackingListFilePath, Constants.PHOTO_FOLDER_PATH, false, PackingDelivery.PackingListFilePath);
        //                        PackingDelivery.OrderDetailsID = Convert.ToInt32(hdnOrderDetailID.Value);
        //                        result = this.InvoiceControllerInstance.UpdatePackingList(PackingDelivery);
        //                }



        //            }

        //        }
        //        if (result)
        //        {
        //            ShowAlert("Packing file for contract updated successfully");
        //            BindPackingGrd();
        //            //foreach (GridViewRow row in grdpacking.Rows)
        //            //{
        //            //    HiddenField hdnOrderDetailID = (HiddenField)row.FindControl("hdnOrderDetailID");
        //            //    HiddenField hdnOrderID = (HiddenField)row.FindControl("hdnOrderID");
        //            //    CheckBox ChkConsoli = (CheckBox)row.FindControl("ChkConsoli");
        //            //    Label lblContractNo = (Label)row.FindControl("lblContractNo");

        //            //    if (hdnOrderDetailID != null && ChkConsoli != null)
        //            //    {
        //            //        if (ChkConsoli.Checked)
        //            //        {
        //            //            PackingDelivery.OrderDetailsID = Convert.ToInt32(hdnOrderDetailID.Value);
        //            //            WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(Convert.ToInt32(hdnOrderID.Value), Convert.ToInt32(hdnOrderDetailID.Value), TaskMode.InvoicePackingList, LoggedInUserID);
        //            //        }
        //            //    }

        //            //}
        //        }
        //        else
        //        {
        //            ShowAlert("Some error occurred while updating record please contact with website administration");
        //            return;
        //        }
        //    }


        //}
        //public void SavePackingDetails(out bool IsSave)
        //{
        //    IsSave = true;
        //    iKandi.Common.PackingDelivery PackingDelivery = new iKandi.Common.PackingDelivery();
        //    PackingDelivery.LoggedInUserID = LoggedInUserID;

        //    if (Flag == "PACKING" || Flag == "CONSOLIDATION")
        //    {

        //        PackingDelivery.Flag = Flag;
        //        if (UpPackingFile.HasFile)
        //        {

        //        }
        //        else
        //        {
        //            if (!string.IsNullOrEmpty(hdnpackinglistfile.Value))
        //            { }
        //            else
        //            {
        //                ShowAlert("Please select packing document");
        //                IsSave = false;
        //                return;
        //            }

        //        }
        //        if (ValidateContract() == false)
        //        {
        //            ShowAlert("Please select at least on contract");
        //            IsSave = false;
        //            return;
        //        }
        //        bool result = false;
        //        foreach (GridViewRow row in grdpacking.Rows)
        //        {
        //            HiddenField hdnOrderDetailID = (HiddenField)row.FindControl("hdnOrderDetailID");
        //            CheckBox ChkConsoli = (CheckBox)row.FindControl("ChkConsoli");
        //            Label lblContractNo = (Label)row.FindControl("lblContractNo");

        //            PackingDelivery.IsConsolidation = (ChkConsoli.Checked == true ? 1 : 0);
        //            if (hdnOrderDetailID != null && ChkConsoli != null)
        //            {
        //                if (Flag == "PACKING" || Flag == "CONSOLIDATION")
        //                {

        //                    string PackingFileName = string.Empty;
        //                    PackingDelivery.PackingListFilePath = "";
        //                    if (ChkConsoli.Checked)
        //                    {

        //                        if (UpPackingFile.HasFile)
        //                        {
        //                            PackingDelivery.PackingListFilePath = hdnOrderDetailID.Value + "_" + "PackingList" + "_" + Path.GetFileNameWithoutExtension(this.UpPackingFile.FileName) + Path.GetExtension(this.UpPackingFile.FileName);
        //                            if (File.Exists(Server.MapPath(Deliveryfolder) + PackingDelivery.PackingListFilePath))
        //                            {
        //                                // File.Delete(Server.MapPath(Deliveryfolder) + PackingDelivery.PackingListFilePath);
        //                            }
        //                            else
        //                            {
        //                                //PackingDelivery.InvoiceFilePath = iKandi.Web.Components.FileHelper.SaveFile(UpPackingFile.PostedFile.InputStream, PackingDelivery.PackingListFilePath, Constants.DELIVERY_FOLDER_PATH, false, PackingDelivery.PackingListFilePath);
        //                                UpPackingFile.SaveAs(Server.MapPath(Deliveryfolder) + PackingDelivery.PackingListFilePath);
        //                            }
        //                        }
        //                        else if (!string.IsNullOrEmpty(hdnpackinglistfile.Value))
        //                        {
        //                            string[] stringArray = hdnpackinglistfile.Value.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
        //                            PackingDelivery.PackingListFilePath = hdnOrderDetailID.Value + "_" + stringArray[1] + "_" + stringArray[2];
        //                            if (File.Exists(Server.MapPath(Deliveryfolder) + PackingDelivery.PackingListFilePath))
        //                            {
        //                                //File.Delete(Server.MapPath(Deliveryfolder) + PackingDelivery.PackingListFilePath);
        //                            }
        //                            else
        //                            {
        //                                CopyFileWithDiffName(hdnpackinglistfile.Value, PackingDelivery.PackingListFilePath);
        //                                //PackingDelivery.PackingListFilePath = iKandi.Web.Components.FileHelper.SaveFile(UpPackingFile.PostedFile.InputStream, PackingDelivery.PackingListFilePath, Constants.DELIVERY_FOLDER_PATH, false, PackingDelivery.PackingListFilePath);
        //                                //UpPackingFile.SaveAs(Server.MapPath(Deliveryfolder) + PackingDelivery.PackingListFilePath);
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        PackingDelivery.PackingListFilePath = "";
        //                    }

        //                    PackingDelivery.InvoiceFilePath = PackingDelivery.PackingListFilePath;

        //                    //PackingDelivery.InvoiceFilePath = iKandi.Web.Components.FileHelper.SaveFile(UpPackingFile.PostedFile.InputStream, PackingDelivery.PackingListFilePath, Constants.PHOTO_FOLDER_PATH, false, PackingDelivery.PackingListFilePath);
        //                    PackingDelivery.OrderDetailsID = Convert.ToInt32(hdnOrderDetailID.Value);
        //                    result = this.InvoiceControllerInstance.UpdatePackingList(PackingDelivery, "PACKING");

        //                }



        //            }

        //        }
        //        if (result)
        //        {
        //            //ShowAlert("Packing file for contract updated successfully");
        //           // BindPackingGrd();
        //        }
        //        else
        //        {
        //            ShowAlert("Some error occurred while updating record please contact with website administration");
        //            return;
        //        }
        //    }


        //}
        public void SavePackingDetails(out bool IsSave)
        {
            IsSave = true;
            iKandi.Common.PackingDelivery PackingDelivery = new iKandi.Common.PackingDelivery();
            PackingDelivery.LoggedInUserID = LoggedInUserID;
            PackingDelivery.Flag = Flag;
            bool result = false;
            PackingDelivery.IsConsolidation = 1;
            PackingDelivery.PackingListFilePath = "";
            if (UpPackingFile.HasFile)
            {
                PackingDelivery.PackingListFilePath = ddlshipingno.SelectedItem.Text + "_" + Path.GetFileNameWithoutExtension(this.UpPackingFile.FileName) + Path.GetExtension(this.UpPackingFile.FileName);
                if (!File.Exists(Server.MapPath(Deliveryfolder) + PackingDelivery.PackingListFilePath))
                {
                    UpPackingFile.SaveAs(Server.MapPath(Deliveryfolder) + PackingDelivery.PackingListFilePath);
                }
            }
            else if (!string.IsNullOrEmpty(hdnpackinglistfile.Value))
            {

                PackingDelivery.PackingListFilePath = hdnpackinglistfile.Value;
            }
            PackingDelivery.InvoiceFilePath = PackingDelivery.PackingListFilePath;
            PackingDelivery.ShippingNo = ddlshipingno.SelectedItem.Text;
            PackingDelivery.OrderDetailsID = -1;
            result = this.InvoiceControllerInstance.UpdatePackingList(PackingDelivery, "PACKING");
        }
        public void SaveConsolidationDetails()
        {
            //bool IsTrue;
            //SavePackingDetails(out IsTrue);
            //if (!IsTrue)
            //{
            //    return;
            //}
            iKandi.Common.PackingDelivery PackingDelivery = new iKandi.Common.PackingDelivery();
            PackingDelivery.LoggedInUserID = LoggedInUserID;



            PackingDelivery.Flag = Flag;
            if (txtlandingETA.Text == string.Empty)
            {
                ShowAlert("Please select Landing ETA it could not be blank");
                return;
            }

            //if (ValidateContract() == false)
            //{
            //    ShowAlert("Please select at least on contract");
            //    return;
            //}
            PackingDelivery.ConsolidationShippingID = Convert.ToInt32(ddlshipingno.SelectedValue);
            PackingDelivery.ShippingNo = ddlshipingno.SelectedItem.Text;
            PackingDelivery.LandingETA = txtlandingETA.Text.Trim();
            PackingDelivery.BIno = txtAwb.Text.Trim();
            PackingDelivery.FlightDetails = txtFlightDetails.Text.Trim();

            bool result = false;
            if (ddlshipingno.SelectedValue == "999")
            {
                result = this.InvoiceControllerInstance.AddShippingNumber(PackingDelivery, out ShippingID);
                result = false;
            }
            if (ShippingID > 0)
            {
                PackingDelivery.ConsolidationShippingID = ShippingID;//auto increment new ID for new shipping entry
                foreach (GridViewRow row in grdpacking.Rows)
                {
                    HiddenField hdnOrderDetailID = (HiddenField)row.FindControl("hdnOrderDetailID");
                    CheckBox ChkConsoli = (CheckBox)row.FindControl("ChkConsoli");
                    Label lblContractNo = (Label)row.FindControl("lblContractNo");

                    if (hdnOrderDetailID != null && ChkConsoli != null)
                    {
                        //if (ChkConsoli.Checked)
                        //{
                        PackingDelivery.OrderDetailsID = Convert.ToInt32(hdnOrderDetailID.Value);
                        PackingDelivery.IsConsolidation = (ChkConsoli.Checked == true ? 1 : 0);
                        result = this.InvoiceControllerInstance.UpdateConsolidation(PackingDelivery);
                        //}
                    }

                }
                foreach (GridViewRow row in grdpacking.Rows)
                {
                  HiddenField hdnOrderDetailID = (HiddenField)row.FindControl("hdnOrderDetailID");
                  HiddenField hdnOrderID = (HiddenField)row.FindControl("hdnOrderID");
                  CheckBox ChkConsoli = (CheckBox)row.FindControl("ChkConsoli");
                  Label lblContractNo = (Label)row.FindControl("lblContractNo");

                  if (hdnOrderDetailID != null && ChkConsoli != null)
                  {
                    if (ChkConsoli.Checked)
                    {
                      PackingDelivery.OrderDetailsID = Convert.ToInt32(hdnOrderDetailID.Value);
                      WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(Convert.ToInt32(hdnOrderID.Value), Convert.ToInt32(hdnOrderDetailID.Value), TaskMode.Consolidated, LoggedInUserID);
                    }
                  }

                }
                if (result)
                {
                    ShowAlert("Data has been updated successfully");
                    //BindPackingGrd();
                }
                else
                {
                    ShowAlert("Some error occurred while updating record please contact with website administration");
                    return;
                }
            }
            else
            {
                PackingDelivery.ConsolidationShippingID = Convert.ToInt32(ddlshipingno.SelectedValue);
                foreach (GridViewRow row in grdpacking.Rows)
                {
                    HiddenField hdnOrderDetailID = (HiddenField)row.FindControl("hdnOrderDetailID");
                    CheckBox ChkConsoli = (CheckBox)row.FindControl("ChkConsoli");
                    Label lblContractNo = (Label)row.FindControl("lblContractNo");

                    if (hdnOrderDetailID != null && ChkConsoli != null)
                    {
                        //if (ChkConsoli.Checked)
                        //{
                        PackingDelivery.OrderDetailsID = Convert.ToInt32(hdnOrderDetailID.Value);
                        PackingDelivery.IsConsolidation = (ChkConsoli.Checked == true ? 1 : 0);
                        result = this.InvoiceControllerInstance.UpdateConsolidation(PackingDelivery);
                        //}
                    }

                }
                //foreach (GridViewRow row in grdpacking.Rows)
                //{
                //  HiddenField hdnOrderDetailID = (HiddenField)row.FindControl("hdnOrderDetailID");
                //  HiddenField hdnOrderID = (HiddenField)row.FindControl("hdnOrderID");
                //  CheckBox ChkConsoli = (CheckBox)row.FindControl("ChkConsoli");
                //  Label lblContractNo = (Label)row.FindControl("lblContractNo");

                //  if (hdnOrderDetailID != null && ChkConsoli != null)
                //  {
                //    if (ChkConsoli.Checked)
                //    {
                //      PackingDelivery.OrderDetailsID = Convert.ToInt32(hdnOrderDetailID.Value);
                //      WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(Convert.ToInt32(hdnOrderID.Value), Convert.ToInt32(hdnOrderDetailID.Value), TaskMode.Consolidated, LoggedInUserID);
                //    }
                //  }

                //}
                //if (result)
                //{
                //    ShowAlert("Data has been updated successfully");                  
                //    foreach (GridViewRow row in grdpacking.Rows)
                //    {
                //        HiddenField hdnOrderDetailID = (HiddenField)row.FindControl("hdnOrderDetailID");
                //        HiddenField hdnOrderID = (HiddenField)row.FindControl("hdnOrderID");
                //        CheckBox ChkConsoli = (CheckBox)row.FindControl("ChkConsoli");
                //        Label lblContractNo = (Label)row.FindControl("lblContractNo");

                //        if (hdnOrderDetailID != null && ChkConsoli != null)
                //        {
                //            if (ChkConsoli.Checked)
                //            {
                //                PackingDelivery.OrderDetailsID = Convert.ToInt32(hdnOrderDetailID.Value);
                //                WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(Convert.ToInt32(hdnOrderID.Value), Convert.ToInt32(hdnOrderDetailID.Value), TaskMode.Consolidated, LoggedInUserID);
                //            }
                //        }

                //    }
                //}
                //else
                //{
                //    ShowAlert("Some error occurred while updating record please contact with website administration");
                //    return;
                //}

            }

        }
        public void SaveInvoiceDetails()
        {
            iKandi.Common.PackingDelivery PackingDelivery = new iKandi.Common.PackingDelivery();
            PackingDelivery.LoggedInUserID = LoggedInUserID;



            PackingDelivery.Flag = Flag;
            if (txtlandingETA.Text == string.Empty)
            {
                ShowAlert("Please select Landing ETA it could not be blank");
                return;
            }
            if (UpInvoice.HasFile)
            { }
            else
            {
                if (!string.IsNullOrEmpty(hdnnovicelistfile.Value))
                { }
                else
                {
                    ShowAlert("Please select invoice document");
                    return;
                }
            }
            if (txtInvoiceNo.Text == string.Empty)
            {
                ShowAlert("Please enter invoice number");
                return;
            }
            if (txtInvoiceAmt.Text == string.Empty && Convert.ToInt32(txtInvoiceAmt.Text) <= 0)
            {
                ShowAlert("Please enter invoice amount");
                return;
            }
            if (txtinvoiceDate.Text == string.Empty)
            {
                ShowAlert("Please enter invoice date");
                return;
            }
            if (txtPaymentDueDate.Text == string.Empty)
            {
                ShowAlert("Please enter payment due date");
                return;
            }
            if (ValidateContract() == false)
            {
                ShowAlert("Please select at least on contract");
                return;
            }
            PackingDelivery.ConsolidationShippingID = Convert.ToInt32(ddlshipingno.SelectedValue);
            PackingDelivery.ShippingNo = ddlshipingno.SelectedItem.Text;
            PackingDelivery.LandingETA = txtlandingETA.Text.Trim();
            PackingDelivery.BIno = txtAwb.Text.Trim();
            PackingDelivery.FlightDetails = txtFlightDetails.Text.Trim();
            PackingDelivery.InvoiceNumber = txtInvoiceNo.Text.Trim();
            PackingDelivery.InvoiceShipValue = Convert.ToDouble(txtInvoiceAmt.Text.Trim());
            //PackingDelivery.InvoiceAmount = Convert.ToDouble(txtinvoicetotalAmt.Text.Trim());
            PackingDelivery.InvoiceAmount = (Convert.ToDouble(hdntotalamt.Value) <= 0) ? Convert.ToDouble(txtinvoicetotalAmt.Text.Trim()) : Convert.ToDouble(hdntotalamt.Value);
            PackingDelivery.FrightCharge = (txtfrightcharge.Text.Trim() == "" ? 0 : Convert.ToDouble(txtfrightcharge.Text.Trim()));
            PackingDelivery.InsuranceAmt = (txtInsuranceAmt.Text.Trim() == "" ? 0 : Convert.ToDouble(txtInsuranceAmt.Text.Trim()));
            PackingDelivery.DiscountAmt = (txtDiscountAmt.Text.Trim() == "" ? 0 : Convert.ToDouble(txtDiscountAmt.Text.Trim()));
            PackingDelivery.InvoiceDate = txtinvoiceDate.Text;
            PackingDelivery.SBno = txtsbNo.Text.Trim();
            PackingDelivery.SBDate = txtsbDate.Text;
            PackingDelivery.PaymentDueDate = txtPaymentDueDate.Text;
            bool result = false;


            //PackingDelivery.ConsolidationShippingID = ShippingID;//auto increment new ID for new shipping entry
            int IsRollBackInvoice = 0;
            foreach (GridViewRow row in grdpacking.Rows)
            {
                HiddenField hdnOrderDetailID = (HiddenField)row.FindControl("hdnOrderDetailID");
                CheckBox Chkinvice = (CheckBox)row.FindControl("Chkinvice");
                Label lblContractNo = (Label)row.FindControl("lblContractNo");
                HiddenField hdnOrderID = (HiddenField)row.FindControl("hdnOrderID");
                PackingDelivery.InvoiceFilePath = "";
                if (hdnOrderDetailID != null && Chkinvice != null)
                {
                    //if (ChkConsoli.Checked)
                    //{
                    string Invoicefilepath = string.Empty;

                    PackingDelivery.IsConsolidation = (Chkinvice.Checked == true ? 1 : 0);
                    if (Chkinvice.Checked)
                    {
                        if (UpInvoice.HasFile)
                        {
                            PackingDelivery.InvoiceFilePath = hdnOrderDetailID.Value + "_" + "Invoice" + "_" + Path.GetFileNameWithoutExtension(this.UpInvoice.FileName) + Path.GetExtension(this.UpInvoice.FileName);
                            if (File.Exists(Server.MapPath(Deliveryfolder) + PackingDelivery.InvoiceFilePath))
                            {
                                // File.Delete(Server.MapPath(Deliveryfolder) + PackingDelivery.PackingListFilePath);
                            }
                            else
                            {
                                UpInvoice.SaveAs(Server.MapPath(Deliveryfolder) + PackingDelivery.InvoiceFilePath);
                            }
                        }
                        else if (!string.IsNullOrEmpty(hdnnovicelistfile.Value))
                        {
                            //UpInvoice.SaveAs(Server.MapPath(Deliveryfolder) + PackingDelivery.InvoiceFilePath);
                            string[] stringArray = hdnnovicelistfile.Value.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
                            PackingDelivery.InvoiceFilePath = hdnOrderDetailID.Value + "_" + stringArray[1] + "_" + stringArray[2];
                            if (File.Exists(Server.MapPath(Deliveryfolder) + PackingDelivery.InvoiceFilePath))
                            {
                                //File.Delete(Server.MapPath(Deliveryfolder) + PackingDelivery.PackingListFilePath);
                            }
                            else
                            {
                                CopyFileWithDiffName(hdnnovicelistfile.Value, PackingDelivery.InvoiceFilePath);
                            }
                        }
                    }
                    //PackingDelivery.InvoiceFilePath = iKandi.Web.Components.FileHelper.SaveFile(UpInvoice.PostedFile.InputStream, PackingDelivery.InvoiceFilePath, Constants.DELIVERY_FOLDER_PATH, false, string.Empty);                    
                    PackingDelivery.OrderDetailsID = Convert.ToInt32(hdnOrderDetailID.Value);
                    result = this.InvoiceControllerInstance.UpdateInvoice(PackingDelivery);
                    if (result)
                    {
                        if ((Chkinvice.Checked) && (IsRollBackInvoice.ToString() == "0"))
                        {
                            PackingDelivery.OrderDetailsID = Convert.ToInt32(hdnOrderDetailID.Value);
                            WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(Convert.ToInt32(hdnOrderID.Value), Convert.ToInt32(hdnOrderDetailID.Value), TaskMode.INVOICED, LoggedInUserID);
                        }
                    }
                }
            }
            if (result)
            {
                ShowAlert("Data has been updated successfully");
                BindPackingGrd();
                //foreach (GridViewRow row in grdpacking.Rows)
                //{
                //    HiddenField hdnOrderDetailID = (HiddenField)row.FindControl("hdnOrderDetailID");
                //    HiddenField hdnOrderID = (HiddenField)row.FindControl("hdnOrderID");
                //    CheckBox ChkConsoli = (CheckBox)row.FindControl("ChkConsoli");
                //    Label lblContractNo = (Label)row.FindControl("lblContractNo");

                //    if (hdnOrderDetailID != null && ChkConsoli != null)
                //    {
                //        if (ChkConsoli.Checked)
                //        {
                //            PackingDelivery.OrderDetailsID = Convert.ToInt32(hdnOrderDetailID.Value);
                //            WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(Convert.ToInt32(hdnOrderID.Value), Convert.ToInt32(hdnOrderDetailID.Value), TaskMode.INVOICED, LoggedInUserID);
                //        }
                //    }

                //}
            }
            else
            {

                ShowAlert("Some error occurred while updating record please contact with website administration");
                return;
            }
        }
        public void ShowAlert(string stringAlertMsg)
        {
            // Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "scr", "jQuery.facebox('" + stringAlertMsg + "');", true);
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "jQuery.facebox('" + myStringVariable + "');", true);
        }
        protected void grdpacking_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // RememberOldValues();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            if (Flag == "CONSOLIDATION")
            {
                String ShippingNo = (ddlshipingno != null ? ddlshipingno.SelectedItem.Text.Trim().ToUpper() : "");
                ds = this.InvoiceControllerInstance.GetPackingDetailsByShippingNo(Flag, OrderID, OrderDetailID, ShippingNo, Convert.ToInt32(ddlshipingno.SelectedValue), txtsearch.Text.Trim());//TODO:
                dt = ds.Tables[0];

            }
            if (Flag == "INVOICED")
            {
                String ShippingNo = (ddlshipingno != null ? ddlshipingno.SelectedItem.Text.Trim().ToUpper() : "");
                ds = this.InvoiceControllerInstance.GetPackingDetailsByShippingNo(Flag, OrderID, OrderDetailID, ShipmentNoQuery, Convert.ToInt32(ddlshipingno.SelectedValue), txtsearch.Text.Trim());//TODO:
                dt = ds.Tables[0];
            }
            grdpacking.DataSource = dt;
            grdpacking.PageIndex = e.NewPageIndex;

            grdpacking.DataBind();
            // RePopulateValues();

            //BindPackingGrd();
            // PopulateCheckedValues();
            //GetShipValue();

        }

        protected void ddlshipingno_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ShippingNo = string.Empty;
            ShippingID = Convert.ToInt32(ddlshipingno.SelectedValue);
            if (ddlshipingno.SelectedValue != "999")
            {
                ShippingNo = ddlshipingno.SelectedItem.Text.ToUpper();
                DataSet ds = this.InvoiceControllerInstance.GetPackingDetailsByShippingNo("SIPPINGDETAIL", OrderID, OrderDetailID, ShippingNo, Convert.ToInt32(ddlshipingno.SelectedValue), txtsearch.Text.Trim());//TODO:
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {

                    if (dt.Rows[0]["LandingETA"].ToString() != "1/1/1900 12:00:00 AM")
                    {

                        txtlandingETA.Text = Convert.ToDateTime(dt.Rows[0]["LandingETA"].ToString()).ToString("dd MMM yy (ddd)");
                    }
                    else
                    {
                        txtlandingETA.Text = string.Empty;
                    }

                    txtAwb.Text = dt.Rows[0]["AWBNo"].ToString();
                    txtFlightDetails.Text = dt.Rows[0]["FlightSailingDetails"].ToString();
                    txtInvoiceNo.Text = dt.Rows[0]["InvoiceNumber"].ToString();
                    hdninvoiceno.Value = dt.Rows[0]["InvoiceNumber"].ToString(); ;
                    txtInvoiceAmt.Text = (dt.Rows[0]["InvoiceAmt"].ToString() == "0" ? "" : Convert.ToDouble(dt.Rows[0]["InvoiceAmt"]).ToString());
                    ////txtinvoicetotalAmt.Text = txtInvoiceAmt.Text;
                    if (dt.Rows[0]["InvoiceDate"].ToString() != "1/1/1900 12:00:00 AM")
                    {

                        txtinvoiceDate.Text = Convert.ToDateTime(dt.Rows[0]["InvoiceDate"].ToString()).ToString("dd MMM yy (ddd)");
                    }
                    else
                    {
                        txtinvoiceDate.Text = string.Empty;
                    }
                    if (dt.Rows[0]["SBDate"].ToString() != "1/1/1900 12:00:00 AM")
                    {

                        txtsbDate.Text = Convert.ToDateTime(dt.Rows[0]["SBDate"].ToString()).ToString("dd MMM yy (ddd)");
                    }
                    else
                    {
                        txtsbDate.Text = string.Empty;
                    }

                    txtsbNo.Text = dt.Rows[0]["SBNumber"].ToString();
                    if (dt.Rows[0]["PaymentDueDate"].ToString() != "1/1/1900 12:00:00 AM")
                    {

                        txtPaymentDueDate.Text = Convert.ToDateTime(dt.Rows[0]["PaymentDueDate"].ToString()).ToString("dd MMM yy (ddd)");
                    }
                    else
                    {
                        txtPaymentDueDate.Text = string.Empty;
                    }


                }
            }
            else
            {
                ShowAlert("Selected shipping number " + "[ " + ddlshipingno.SelectedItem.Text.ToUpper() + " ]" + " is new choose this for fresh entry");
                ShippingID = -1;
                txtlandingETA.Text = "";
                txtAwb.Text = "";
                txtFlightDetails.Text = "";
                txtInvoiceNo.Text = "";
                hdninvoiceno.Value = "";
                txtInvoiceAmt.Text = "";
                txtinvoicetotalAmt.Text = "";
                hdninvoicetotalAmt.Value = "0";
                txtinvoiceDate.Text = "";
                txtsbDate.Text = "";
                txtPaymentDueDate.Text = "";

            }
            BindConsolidationGrd();
        }

        protected void btnsaerch_Click(object sender, EventArgs e)
        {
            btnsaerch.Enabled = false;
            BindConsolidationGrd();
            BindInvoicePayment();
            btnsaerch.Enabled = true;
        }

        protected void btnUploadDoc_Click(object sender, EventArgs e)
        {

        }

        protected void btnInovieUpload_Click(object sender, EventArgs e)
        {

        }
        protected void grdinvoice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string currencyName = "GBP";
            string currencySign = "&pound;";

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //e.Row.Attributes.Add("onmouseover", "this.style.cursor='hand';this.style.backgroundColor='#E6E6FA'");
                    //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");

                    Label lblinvoiceAmt = e.Row.FindControl("lblinvoiceAmt") as Label;
                    Label lbltotalBeAmount = e.Row.FindControl("lbltotalBeAmount") as Label;
                    HiddenField hdnConvertTo = e.Row.FindControl("hdnConvertTo") as HiddenField;
                    DropDownList ddlBankRefNo = e.Row.FindControl("ddlBankRefNo") as DropDownList;
                    // DropDownList ddlBankRefNo = e.Row.FindControl("ddlBankRefNo") as DropDownList;
                    TextBox txtBankrefNo = e.Row.FindControl("txtBankrefNo") as TextBox;
                    TextBox txtPaymentRecAmt = e.Row.FindControl("txtPaymentRecAmt") as TextBox;
                    Label lblCurrencyTag = e.Row.FindControl("lblCurrencyTag") as Label;
                    HiddenField hdnRepeatCount = e.Row.FindControl("hdnRepeatCount") as HiddenField;

                    TextBox txtpaymentClearDate = e.Row.FindControl("txtpaymentClearDate") as TextBox;
                    TextBox txtTenure = e.Row.FindControl("txtTenure") as TextBox;
                    TextBox txtPaymentDueDate = e.Row.FindControl("txtPaymentDueDate") as TextBox;
                    TextBox txtPaymentRecDate = e.Row.FindControl("txtPaymentRecDate") as TextBox;
                    HiddenField hdnconvertto = e.Row.FindControl("hdnconvertto") as HiddenField;
                    CheckBox chk = (CheckBox)e.Row.FindControl("chkIsSplit");
                    CheckBox chkaction = (CheckBox)e.Row.FindControl("chkaction");
                    CheckBox ChkIsFullPayemntRec = (CheckBox)e.Row.FindControl("ChkIsFullPayemntRec");
                    Label lblPendingAmt = e.Row.FindControl("lblPendingAmt") as Label;
                    Repeater rptserial = e.Row.FindControl("rptserial") as Repeater;
                    Label lblshipmentNo = e.Row.FindControl("lblshipmentNo") as Label;
                    GetSerialNumber(rptserial, lblshipmentNo.Text.Trim());
                    //ddlBankRefNo.Attributes.Add("onChange", "if (!confirm('Are you sure want to change bank reference number ?')) return false;");

                    // ddlBankRefNo.Attributes.Add("onChange", "javascript:return confirmfunction();");
                    //if (Session["BankRefNo"] != null)
                    //{


                    //}
                    Label lblStyleNo = e.Row.FindControl("lblStyleNo") as Label;
                    //if (!string.IsNullOrEmpty(lblStyleNo.Text))
                    //{
                    //    if (lblStyleNo.Text.Contains(",") == true)
                    //    {
                    //        string[] stringArray = lblStyleNo.Text.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    //        lblStyleNo.Text = "";
                    //        foreach (string a in stringArray)
                    //        {
                    //            string[] stringArrays = a.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries);
                    //            int y = 1;

                    //            foreach (string x in stringArrays)
                    //            {
                    //                if (y == 1)
                    //                {
                    //                    lblStyleNo.Text = lblStyleNo.Text + x.Trim();
                    //                }
                    //                else
                    //                {
                    //                    lblStyleNo.Text = "<br/>" + lblStyleNo.Text + x.Trim();
                    //                    lblStyleNo.ForeColor = System.Drawing.Color.Gray;
                    //                }
                    //                y = y + 1;
                    //            }
                    //        }

                    //        lblStyleNo.Text.Replace("@", "");
                    //    }        
                    //}//ASO 2503(DR 68600849 cT), ASO 2639(DR 8600604 d)
                    if (!string.IsNullOrEmpty(txtPaymentRecAmt.Text) && Convert.ToDouble(txtPaymentRecAmt.Text) > 0)
                    {
                        ddlBankRefNo.Enabled = false;
                        ddlBankRefNo.ToolTip = "Bank ref cannot change because you have taken some amount from bank" + " " + Convert.ToDouble(txtPaymentRecAmt.Text).ToString("N2");
                    }
                    BankRefNo = txtBankrefNo.Text;
                    if (ddlBankRefNo.Visible)
                    {
                        this.BindInvoiceBankRefNo(ddlBankRefNo, txtBankrefNo.Text, Convert.ToInt32(hdnconvertto.Value));
                    }

                    // ddlBankRefNo.Attributes.Add("onChange", "javascript:return ShowConfirm(" + ddlBankRefNo.ClientID + "," + ddlBankRefNo.SelectedItem.Text + ");");
                    iKandi.BLL.Configuration.Configuration config = new iKandi.BLL.Configuration.Configuration();
                    //if (ddlBankRefNo.SelectedItem.Text == "NEW")
                    //{
                    //    txtBankrefNo.Enabled = true;
                    //}
                    if (Enum.IsDefined(typeof(Currency), Convert.ToInt32(hdnConvertTo.Value)))
                    {
                        currencyName = Enum.GetName(typeof(Currency), Convert.ToInt32(hdnConvertTo.Value));
                        currencySign = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType(Convert.ToInt32(hdnConvertTo.Value));
                        if (lblinvoiceAmt.Text != "" && lblinvoiceAmt != null)
                        {

                            lblinvoiceAmt.Text = currencySign + " " + Convert.ToDouble(lblinvoiceAmt.Text).ToString("N2");
                        }
                        if (lbltotalBeAmount.Text != "" && lbltotalBeAmount != null)
                        {

                            lbltotalBeAmount.Text = currencySign + " " + Convert.ToDouble(lbltotalBeAmount.Text).ToString("N2");
                        }
                        if (txtPaymentRecAmt.Text != "" && txtPaymentRecAmt != null && txtPaymentRecAmt.Text != "0")
                        {

                            txtPaymentRecAmt.Text = Convert.ToDouble(txtPaymentRecAmt.Text).ToString("N2");
                        }
                        lblPendingAmt.Text = currencySign + " " + Convert.ToDouble(lblPendingAmt.Text).ToString("N2");
                        lblCurrencyTag.Text = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType(Convert.ToInt32(hdnConvertTo.Value));
                        txtPaymentRecAmt.Text = (txtPaymentRecAmt.Text == "0" ? "" : txtPaymentRecAmt.Text);
                    }



                    PackingDelivery PackingDelivery = e.Row.DataItem as PackingDelivery;
                    HiddenField hdnBankRefNo = e.Row.FindControl("hdnBankRefNo") as HiddenField;
                    HiddenField hdnIsSingle = e.Row.FindControl("hdnIsSingle") as HiddenField;
                    HiddenField hdnBankRefID = e.Row.FindControl("hdnBankRefID") as HiddenField;
                    chkaction.Checked = (PackingDelivery.IsAction == 1 ? true : false);
                    if (PackingDelivery != null && BankRefNumber == PackingDelivery.BankRefNumber && PackingDelivery.IsSingle == "N")
                    {
                        grdinvoice.Rows[parentRow].Cells[5].RowSpan += 1;
                        grdinvoice.Rows[parentRow].Cells[6].RowSpan += 1;
                        grdinvoice.Rows[parentRow].Cells[7].RowSpan += 1;
                        grdinvoice.Rows[parentRow].Cells[8].RowSpan += 1;
                        //grdinvoice.Rows[parentRow].Cells[9].RowSpan += 1;
                        //grdinvoice.Rows[parentRow].Cells[10].RowSpan += 1;

                        e.Row.Cells[5].Visible = false;
                        e.Row.Cells[6].Visible = false;
                        e.Row.Cells[7].Visible = false;
                        e.Row.Cells[8].Visible = false;
                        //e.Row.Cells[9].Visible = false;

                        //TextBox txtBankrefNos = e.Row.Cells[6].FindControl("txtBankrefNo") as TextBox;
                        //txtBankrefNos.Visible = false;
                        txtBankrefNo.Enabled = false;
                        txtpaymentClearDate.Enabled = false;
                        txtTenure.Enabled = false;
                        txtPaymentDueDate.Enabled = false;
                        txtPaymentRecDate.Enabled = false;
                        chk.Enabled = false;
                        txtPaymentRecAmt.Enabled = false;
                        ChkIsFullPayemntRec.Enabled = false;
                    }
                    else if (PackingDelivery != null && BankRefNumber == PackingDelivery.BankRefNumber && PackingDelivery.IsSingle == "Y")
                    {
                        grdinvoice.Rows[parentRow].Cells[5].RowSpan += 1;
                        grdinvoice.Rows[parentRow].Cells[6].RowSpan += 1;
                        grdinvoice.Rows[parentRow].Cells[7].RowSpan += 1;
                        //grdinvoice.Rows[parentRow].Cells[8].RowSpan += 1;
                        //grdinvoice.Rows[parentRow].Cells[9].RowSpan += 1;
                        //grdinvoice.Rows[parentRow].Cells[10].RowSpan += 1;

                        e.Row.Cells[5].Visible = false;
                        e.Row.Cells[6].Visible = false;
                        e.Row.Cells[7].Visible = false;
                        //e.Row.Cells[8].Visible = false;
                        //e.Row.Cells[9].Visible = false;

                        txtBankrefNo.Enabled = false;
                        txtpaymentClearDate.Enabled = false;
                        txtTenure.Enabled = false;
                        txtPaymentDueDate.Enabled = false;
                        //txtPaymentRecDate.Enabled = false;

                        if (PackingDelivery.IsSingle == "Y")
                        {
                            chk.Visible = true;
                            chk.Checked = (PackingDelivery.IsSingle == "Y") ? true : false;

                        }
                        else
                            if (PackingDelivery.IsFullPaymentCleard == 0)
                            {
                                chk.Checked = true;
                                chk.Visible = true;
                            }
                            else
                                chk.Visible = false;
                        if (hdnRepeatCount.Value == "1")
                        {
                            chk.Visible = false;
                            chk.Checked = false;
                        }
                    }
                    else
                    {
                        parentRow = e.Row.RowIndex;
                        BankRefNumber = PackingDelivery.BankRefNumber;

                        txtBankrefNo.Enabled = true;
                        txtpaymentClearDate.Enabled = true;
                        txtTenure.Enabled = true;
                        txtPaymentDueDate.Enabled = true;
                        txtPaymentRecDate.Enabled = true;
                        chk.Enabled = true;
                        txtPaymentRecAmt.Enabled = true;
                        ChkIsFullPayemntRec.Enabled = true;

                        e.Row.Cells[5].RowSpan = 1;
                        e.Row.Cells[6].RowSpan = 1;
                        e.Row.Cells[7].RowSpan = 1;
                        e.Row.Cells[8].RowSpan = 1;
                        e.Row.Cells[9].RowSpan = 1;
                        e.Row.Cells[10].RowSpan = 1;
                        if (PackingDelivery.IsSingle == "Y")
                        {
                            chk.Visible = true;
                            chk.Checked = (PackingDelivery.IsSingle == "Y") ? true : false;


                            if (PackingDelivery.IsFullPaymentCleard > 0)
                            {
                                chk.Visible = false;
                            }
                        }
                        else if (PackingDelivery.IsSingle == "Y")
                        {
                            if (PackingDelivery.IsFullPaymentCleard == 0)
                            {
                                chk.Checked = true;
                                chk.Visible = true;
                            }
                            else
                                chk.Visible = false;
                        }

                        if (PackingDelivery.IsFullPaymentCleard > 0)
                        {
                            chk.Visible = false;
                        }


                    }

                    if (hdnRepeatCount.Value == "1")
                    {
                        chk.Visible = false;
                        chk.Checked = false;
                    }

                    //dis(txtBankrefNo,ddlBankRefNo);
                }
            }
            catch
            {

            }
        }
        protected void grdinvoice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdinvoice.PageIndex = e.NewPageIndex;
            BindInvoicePayment();
        }
        //protected void grdinvoice_DataBound(object sender, EventArgs e)
        //{
        //    for (int i = grdinvoice.Rows.Count - 1; i > 0; i--)
        //    {
        //        GridViewRow row = grdinvoice.Rows[i];
        //        GridViewRow previousRow = grdinvoice.Rows[i - 1];

        //        TextBox lblFromStatus_ToStatus = (TextBox)row.Cells[6].FindControl("txtBankrefNo");
        //        TextBox lblPreviousFromStatus_ToStatus = (TextBox)previousRow.Cells[6].FindControl("txtBankrefNo");

        //        if (lblFromStatus_ToStatus.Text == lblPreviousFromStatus_ToStatus.Text)
        //        {
        //            if (previousRow.Cells[6].RowSpan == 0)
        //            {
        //                if (row.Cells[6].RowSpan == 0)
        //                {
        //                    previousRow.Cells[6].RowSpan += 2;
        //                    previousRow.Cells[7].RowSpan += 2;
        //                    previousRow.Cells[8].RowSpan += 2;
        //                    previousRow.Cells[9].RowSpan += 2;
        //                }
        //                else
        //                {
        //                    previousRow.Cells[6].RowSpan = row.Cells[6].RowSpan + 1;
        //                    previousRow.Cells[7].RowSpan = row.Cells[7].RowSpan + 1;
        //                    previousRow.Cells[8].RowSpan = row.Cells[8].RowSpan + 1;
        //                    previousRow.Cells[9].RowSpan = row.Cells[9].RowSpan + 1;
        //                }
        //                row.Cells[6].Visible = false;
        //                row.Cells[7].Visible = false;
        //                row.Cells[8].Visible = false;
        //                row.Cells[9].Visible = false;
        //            }
        //        }
        //    }
        //}
        //protected void rptsplitpayment_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    RepeaterItem item = e.Item;
        //    if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
        //    {
        //        //Literal lit_Age = (Literal)item.FindControl("lit_Age");
        //        //if (String.IsNullOrEmpty(lit_Age.Text))
        //        //{
        //        //    Literal lit_Name = (Literal)item.FindControl("lit_Name");
        //        //    Literal lit_Notes = (Literal)item.FindControl("lit_Notes");
        //        //    lit_Age.Text = "-";
        //        //    lit_Notes.Text = lit_Name.Text + "'s age is unknown.";
        //        //}
        //    }
        //}
        //protected void chkIsSplit_CheckedChanged(object sender, EventArgs e)
        //{
        //    GridViewRow row = ((GridViewRow)((CheckBox)sender).NamingContainer);
        //    int index = row.RowIndex;
        //    CheckBox chkIsSplit = (CheckBox)grdinvoice.Rows[index].FindControl("chkIsSplit");  
        //    HiddenField hdnBankRefID = (HiddenField)grdinvoice.Rows[index].FindControl("hdnBankRefID");   
        //    HiddenField hdnBankRefNo = (HiddenField)grdinvoice.Rows[index].FindControl("hdnBankRefNo"); 
        //    //HiddenField hdnBankRefNo = (HiddenField)grdinvoice.Rows[index].FindControl("hdnBankRefNo"); 
        //    string IsSingle = (chkIsSplit.Checked == true) ? "Y" : "N";


        //    if (hdnBankRefNo != null && hdnBankRefNo.Value != "")
        //    {
        //        bool Res = this.InvoiceControllerInstance.UpdateInvoiceIsSingle(hdnBankRefNo.Value, Convert.ToInt32(hdnBankRefID.Value), IsSingle);
        //        BindInvoicePayment();
        //    }
        //    else
        //    {
        //        ShowAlert("Please first select Bank ref no. before split");
        //        return;
        //    }
        //}
        protected void chkIsSplit_CheckChanged(object sender, EventArgs e)
        {
            int Index = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
            GridViewRow gvr = grdinvoice.Rows[Index];

            //CheckBox chkIsSplit = (CheckBox)grdinvoice.Rows[index].FindControl("chkIsSplit");
            //HiddenField hdnBankRefID = (HiddenField)grdinvoice.Rows[index].FindControl("hdnBankRefID");
            //HiddenField hdnBankRefNo = (HiddenField)grdinvoice.Rows[index].FindControl("hdnBankRefNo");

            CheckBox chkIsSplit = (CheckBox)gvr.FindControl("chkIsSplit");
            HiddenField hdnBankRefID = (HiddenField)gvr.FindControl("hdnBankRefID");
            HiddenField hdnBankRefNo = (HiddenField)gvr.FindControl("hdnBankRefNo");
            string IsSingle = (chkIsSplit.Checked == true) ? "Y" : "N";
            if (hdnBankRefNo != null && hdnBankRefNo.Value != "")
            {
                bool Res = this.InvoiceControllerInstance.UpdateInvoiceIsSingle(hdnBankRefNo.Value, Convert.ToInt32(hdnBankRefID.Value), IsSingle);
                BindInvoicePayment();
            }
            else
            {
                ShowAlert("Please first select Bank ref no. before split");
                return;
            }


        }
        public void BindInvoiceBankRefNo(DropDownList ddlbankref, string selectedlistitem, int ClientCurrency)
        {
            DataSet ds = this.InvoiceControllerInstance.GetBankRefNoForGrouping("GROUPINVOICEBANKREF", ClientCurrency);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                ddlbankref.DataSource = dt;
                ddlbankref.DataTextField = "BankRefNo";
                ddlbankref.DataBind();

                //ListItem item = ddlshipingno.Items.FindByText(selectedlistitem);
                //if (item != null)
                //{

                //    string itemToCompare = string.Empty;
                //    string itemOrigin = selectedlistitem.ToLower();
                //    foreach (ListItem items in ddlbankref.Items)
                //    {
                //        itemToCompare = items.Text.ToLower();
                //        if (itemOrigin == itemToCompare)
                //        {
                //            ddlbankref.ClearSelection();
                //            items.Selected = true;
                //        }
                //    }
                //}
                string itemToCompare = string.Empty;
                string itemOrigin = selectedlistitem.ToLower();
                foreach (ListItem item in ddlbankref.Items)
                {
                    itemToCompare = item.Text.ToLower();
                    if (itemOrigin == itemToCompare)
                    {
                        ddlbankref.ClearSelection();
                        item.Selected = true;
                    }
                }


            }
        }
        protected void ddlBankRefNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlBankRefNo = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlBankRefNo.NamingContainer;
            DropDownList ddlBankRefNos = (DropDownList)row.FindControl("ddlBankRefNo");
            TextBox txtBankrefNo = (TextBox)row.FindControl("txtBankrefNo");
            HiddenField hdnShipmentNo__PkID = (HiddenField)row.FindControl("hdnShipmentNo__PkID");

            //string StrNewBankRefNo = (ddlBankRefNos.SelectedItem.Text == "NEW" ? "" : ddlBankRefNos.SelectedItem.Text);
            string StrNewBankRefNo = ddlBankRefNos.SelectedItem.Text.ToUpper();
            // bool res = this.InvoiceControllerInstance.UpdateBankRefNo(Convert.ToInt32(hdnShipmentNo__PkID.Value), txtBankrefNo.Text.Trim(), StrNewBankRefNo);
            //if (res == true)
            //    ShowAlert("Bank ref. updated successfully");
            //else
            //    ShowAlert("Bank ref. not updated error occurred !");


            txtBankrefNo.Text = ddlBankRefNos.SelectedItem.Text;

            // BindInvoicePayment();
            // Response.Redirect(Request.RawUrl);


            // DataSet ds = this.InvoiceControllerInstance.GetBankRefNoForGrouping("DELETE",-1);
        }
        public bool SaveInvoicePaymentDetails(out string IsErrorSingleSplit)
        {

            iKandi.Common.PackingDelivery PackingDelivery = new iKandi.Common.PackingDelivery();
            PackingDelivery.LoggedInUserID = LoggedInUserID;
            IsErrorSingleSplit = "";
            bool result = true;

            PackingDelivery.Flag = Flag;

            //string ValidMsg = "";
            //bool IsValid = ValidateInvoicePaymentDetails(out ValidMsg);
            //if (IsValid == false)
            //{
            //    ShowAlert(ValidMsg);
            //    return;
            //}
            try
            {
                foreach (GridViewRow row in grdinvoice.Rows)
                {
                    HiddenField hdnOrderDetailID = (HiddenField)row.FindControl("hdnOrderDetailID");
                    CheckBox ChkConsoli = (CheckBox)row.FindControl("ChkConsoli");
                    Label lblContractNo = (Label)row.FindControl("lblContractNo");
                    TextBox txtBankrefNo = (TextBox)row.FindControl("txtBankrefNo");
                    TextBox txtpaymentClearDate = (TextBox)row.FindControl("txtpaymentClearDate");
                    TextBox txtTenure = (TextBox)row.FindControl("txtTenure");
                    TextBox txtPaymentDueDate = (TextBox)row.FindControl("txtPaymentDueDate");
                    TextBox txtPaymentRecDate = (TextBox)row.FindControl("txtPaymentRecDate");
                    TextBox txtPaymentRecAmt = (TextBox)row.FindControl("txtPaymentRecAmt");
                    DropDownList ddlBankRefNo = (DropDownList)row.FindControl("ddlBankRefNo");
                    HiddenField hdnShipmentNo__PkID = (HiddenField)row.FindControl("hdnShipmentNo__PkID");
                    CheckBox chkIsSplit = (CheckBox)row.FindControl("chkIsSplit");
                    CheckBox ChkIsFullPayemntRec = (CheckBox)row.FindControl("ChkIsFullPayemntRec");
                    CheckBox chkaction = (CheckBox)row.FindControl("chkaction");
                    HiddenField hdnBankRefNoCopy = (HiddenField)row.FindControl("hdnBankRefNoCopy");


                    if (!string.IsNullOrEmpty(txtBankrefNo.Text))
                    {
                        if (chkaction.Checked)
                        {
                            //if (txtBankrefNo.en)
                            if (chkIsSplit.Checked == false)
                            {
                                if (GetEnableControlRowValue(row) == true)
                                {

                                    PackingDelivery.Flag = "BIPLPAYMENT";
                                    PackingDelivery.OrderDetailsID = Convert.ToInt32(hdnOrderDetailID.Value);
                                    PackingDelivery.BankRefNumber = txtBankrefNo.Text.Trim();
                                    PackingDelivery.PaymentClearDate = txtpaymentClearDate.Text;
                                    PackingDelivery.Tenure = (txtTenure.Text == "" ? "0" : txtTenure.Text);
                                    PackingDelivery.PaymentDueDate = txtPaymentDueDate.Text;
                                    PackingDelivery.PaymentReceiveDate = txtPaymentRecDate.Text;
                                    PackingDelivery.ShipmentNo__PkID = Convert.ToInt32(hdnShipmentNo__PkID.Value);
                                    PackingDelivery.IsSingle = (chkIsSplit.Checked == true) ? "Y" : "N";
                                    PackingDelivery.IsFullPaymentReceive = (ChkIsFullPayemntRec.Checked == true) ? 1 : 0;
                                    PackingDelivery.OldBnkRefNo = hdnBankRefNoCopy.Value;

                                    if (txtPaymentRecAmt.Text.Trim() == "")
                                    {
                                        PackingDelivery.BankPaymentRecAmt = 0;
                                    }
                                    else
                                    {
                                        PackingDelivery.BankPaymentRecAmt = Convert.ToDouble(txtPaymentRecAmt.Text.Trim());
                                    }
                                    PackingDelivery.IsFullPaymentCleard = (ChkIsFullPayemntRec.Checked == true ? 1 : 0);
                                    result = this.InvoiceControllerInstance.UpdateInvoiceBankPayment(PackingDelivery);
                                }
                            }

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                IsErrorSingleSplit = ex.ToString();

            }
            return result;
        }
        public bool ValidateInvoicePaymentDetails(out string ValidationMsg)
        {
            bool result = true;
            ValidationMsg = "";
            foreach (GridViewRow row in grdinvoice.Rows)
            {
                HiddenField hdnOrderDetailID = (HiddenField)row.FindControl("hdnOrderDetailID");
                CheckBox ChkConsoli = (CheckBox)row.FindControl("ChkConsoli");
                Label lblContractNo = (Label)row.FindControl("lblContractNo");
                TextBox txtBankrefNo = (TextBox)row.FindControl("txtBankrefNo");
                TextBox txtpaymentClearDate = (TextBox)row.FindControl("txtpaymentClearDate");
                TextBox txtTenure = (TextBox)row.FindControl("txtTenure");
                TextBox txtPaymentDueDate = (TextBox)row.FindControl("txtPaymentDueDate");
                TextBox txtPaymentRecDate = (TextBox)row.FindControl("txtPaymentRecDate");
                TextBox txtPaymentRecAmt = (TextBox)row.FindControl("txtPaymentRecAmt");
                DropDownList ddlBankRefNo = (DropDownList)row.FindControl("ddlBankRefNo");

                if (txtBankrefNo == null || txtBankrefNo.Text == string.Empty)
                {
                    ValidationMsg = "Please enter bank ref no.";
                    result = false;
                    break;
                }

                if (txtpaymentClearDate == null || txtpaymentClearDate.Text == string.Empty)
                {
                    ValidationMsg = "Please enter payment clear date";
                    result = false;
                    break;
                }

                if (txtTenure == null || txtTenure.Text == string.Empty)
                {
                    ValidationMsg = "Please enter Tenure value";
                    result = false;
                    break;
                }

                else if (Convert.ToInt32(txtTenure.Text) <= 0)
                {
                    ValidationMsg = "Please enter valid tenure value";
                    result = false;
                    break;

                }

                if (txtPaymentDueDate == null || txtPaymentDueDate.Text == string.Empty)
                {
                    ValidationMsg = "Please enter payment due date";
                    result = false;
                    break;

                }

                if (txtPaymentRecDate == null || txtPaymentRecDate.Text == string.Empty)
                {
                    ValidationMsg = "Please enter payment receive date";
                    result = false;
                    break;

                }

                if (txtPaymentRecAmt == null || txtPaymentRecAmt.Text == string.Empty)
                {
                    ValidationMsg = "Please enter payment receive amount";
                    result = false;
                    break;

                }
                else if (Convert.ToInt32(txtPaymentRecAmt.Text) <= 0)
                {
                    ValidationMsg = "Please enter valid Payment amount";
                    result = false;
                    break;
                }
            }
            return result;
        }

        protected void chkaction_CheckChanged(object sender, EventArgs e)
        {
            int Index = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
            GridViewRow gvr = grdinvoice.Rows[Index];
            CheckBox chkaction = (CheckBox)gvr.FindControl("chkaction");
            HiddenField hdnBankRefID = (HiddenField)gvr.FindControl("hdnBankRefID");
            HiddenField hdnBankRefNo = (HiddenField)gvr.FindControl("hdnBankRefNo");
            HiddenField hdnRepeatCount = (HiddenField)gvr.FindControl("hdnRepeatCount");

            //foreach (GridViewRow row in grdinvoice.Rows)
            //{
            //    HiddenField hdnOrderDetailID = (HiddenField)row.FindControl("hdnOrderDetailID");
            //    HiddenField hdnBankRefNoCopy = (HiddenField)row.FindControl("hdnBankRefNoCopy");
            //    CheckBox chkactionloop = (CheckBox)row.FindControl("chkaction");

            //    if (hdnBankRefNo.Value == hdnBankRefNoCopy.Value)
            //    {
            //        chkactionloop.Checked = true;
            //    }
            //}


            //Session["BankRefNo"] = hdnBankRefNo.Value;
            BindInvoicePayment(hdnBankRefNo.Value, (chkaction.Checked == true ? "Y" : "N"));



        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            // DataSet ds = this.InvoiceControllerInstance.GetBankRefNoForGrouping("DELETE",-1);
        }
        public bool GetEnableControlRowValue(GridViewRow Row)
        {
            bool IsDisableCtl = true;

            CheckBox ChkConsoli = (CheckBox)Row.FindControl("ChkConsoli");
            Label lblContractNo = (Label)Row.FindControl("lblContractNo");
            TextBox txtBankrefNo = (TextBox)Row.FindControl("txtBankrefNo");
            TextBox txtpaymentClearDate = (TextBox)Row.FindControl("txtpaymentClearDate");
            TextBox txtTenure = (TextBox)Row.FindControl("txtTenure");
            TextBox txtPaymentDueDate = (TextBox)Row.FindControl("txtPaymentDueDate");
            TextBox txtPaymentRecDate = (TextBox)Row.FindControl("txtPaymentRecDate");
            TextBox txtPaymentRecAmt = (TextBox)Row.FindControl("txtPaymentRecAmt");
            DropDownList ddlBankRefNo = (DropDownList)Row.FindControl("ddlBankRefNo");
            HiddenField hdnShipmentNo__PkID = (HiddenField)Row.FindControl("hdnShipmentNo__PkID");
            CheckBox chkIsSplit = (CheckBox)Row.FindControl("chkIsSplit");
            CheckBox ChkIsFullPayemntRec = (CheckBox)Row.FindControl("ChkIsFullPayemntRec");
            CheckBox chkaction = (CheckBox)Row.FindControl("chkaction");
            HiddenField hdnIsSingle = (HiddenField)Row.FindControl("hdnIsSingle");

            //if (hdnIsSingle != null && string.Equals(hdnIsSingle.Value, "Y", StringComparison.InvariantCultureIgnoreCase))
            //{
            //    if (txtBankrefNo.Enabled == false && txtpaymentClearDate.Enabled == false && txtTenure.Enabled == false && txtPaymentDueDate.Enabled == false)
            //    {
            //        IsDisableCtl = false;
            //    }
            //}
            //else if (hdnIsSingle != null && string.Equals(hdnIsSingle.Value, "N", StringComparison.InvariantCultureIgnoreCase))
            //{
            //    if (txtBankrefNo.Enabled == false && txtpaymentClearDate.Enabled == false && txtTenure.Enabled == false && txtPaymentDueDate.Enabled == false && chkIsSplit.Enabled == false
            //                                   && txtPaymentRecDate.Enabled == false && txtPaymentRecAmt.Enabled == false && ChkIsFullPayemntRec.Enabled == false)
            //    {
            //        IsDisableCtl = false;
            //    }
            //}

            if (hdnIsSingle != null && string.Equals(hdnIsSingle.Value, "N", StringComparison.InvariantCultureIgnoreCase))
            {
                if (txtBankrefNo.Enabled == false && txtpaymentClearDate.Enabled == false && txtTenure.Enabled == false && txtPaymentDueDate.Enabled == false && chkIsSplit.Enabled == false
                                               && txtPaymentRecDate.Enabled == false && txtPaymentRecAmt.Enabled == false && ChkIsFullPayemntRec.Enabled == false)
                {
                    IsDisableCtl = false;
                }
            }

            return IsDisableCtl;
        }
        protected void btntrackedcancel_Click(object sender, EventArgs e)
        {
            if (UpPackingFile.HasFile)
            {

            }
            BindInvoicePayment();
        }
        public bool ValidateActionCheckBox()
        {
            bool result = false;
            int count = 0;
            foreach (GridViewRow row in grdinvoice.Rows)
            {
                CheckBox chkaction = (CheckBox)row.FindControl("chkaction");
                if (chkaction.Checked)
                {
                    count = count + 1;
                }
                if (count > 0)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        public bool UpdateSplitOderBillingDetail(out string IsError)
        {
            IsError = "";
            bool IsSave = true;
            #region FIELDS
            string Var_BankRefNo = string.Empty;
            string Var_PaymentClearDate = string.Empty;
            int Var_Tenure = 0;
            string Var_PaymentDueDate = string.Empty;

            #endregion

            PackingDelivery SplitPackingDelivery = new PackingDelivery();
            //SplitPackingDelivery.SplitDetails = new List<SplitOrderBillingDetails>();
            //SplitOrderBillingDetails SBillingDetails = new SplitOrderBillingDetails();           
            try
            {
                foreach (GridViewRow row in grdinvoice.Rows)
                {

                    HiddenField hdnOrderDetailID = (HiddenField)row.FindControl("hdnOrderDetailID");
                    CheckBox ChkConsoli = (CheckBox)row.FindControl("ChkConsoli");
                    Label lblContractNo = (Label)row.FindControl("lblContractNo");
                    TextBox txtBankrefNo = (TextBox)row.FindControl("txtBankrefNo");
                    TextBox txtpaymentClearDate = (TextBox)row.FindControl("txtpaymentClearDate");
                    TextBox txtTenure = (TextBox)row.FindControl("txtTenure");
                    TextBox txtPaymentDueDate = (TextBox)row.FindControl("txtPaymentDueDate");
                    TextBox txtPaymentRecDate = (TextBox)row.FindControl("txtPaymentRecDate");
                    TextBox txtPaymentRecAmt = (TextBox)row.FindControl("txtPaymentRecAmt");
                    DropDownList ddlBankRefNo = (DropDownList)row.FindControl("ddlBankRefNo");
                    HiddenField hdnShipmentNo__PkID = (HiddenField)row.FindControl("hdnShipmentNo__PkID");
                    CheckBox chkIsSplit = (CheckBox)row.FindControl("chkIsSplit");
                    CheckBox ChkIsFullPayemntRec = (CheckBox)row.FindControl("ChkIsFullPayemntRec");
                    CheckBox chkaction = (CheckBox)row.FindControl("chkaction");
                    HiddenField hdnBankRefNoCopy = (HiddenField)row.FindControl("hdnBankRefNoCopy");

                    if (chkaction.Checked)
                    {
                        if (chkIsSplit.Checked == true)
                        {
                            if (txtBankrefNo.Enabled == true && txtpaymentClearDate.Enabled == true && txtTenure.Enabled == true && txtPaymentDueDate.Enabled == true)
                            {
                                Var_BankRefNo = txtBankrefNo.Text.Trim();
                                Var_PaymentClearDate = txtpaymentClearDate.Text;
                                if (!string.IsNullOrEmpty(txtTenure.Text))
                                {
                                    if (Convert.ToInt32(txtTenure.Text) > 0)
                                    {
                                        Var_Tenure = Convert.ToInt32(txtTenure.Text);
                                    }
                                }
                                Var_PaymentDueDate = txtPaymentDueDate.Text.Trim();

                                foreach (GridViewRow Split_row in grdinvoice.Rows)
                                {
                                    HiddenField Split_hdnOrderDetailID = (HiddenField)row.FindControl("hdnOrderDetailID");
                                    CheckBox Split_ChkConsoli = (CheckBox)row.FindControl("ChkConsoli");
                                    Label Split_lblContractNo = (Label)row.FindControl("lblContractNo");
                                    TextBox Split_txtBankrefNo = (TextBox)Split_row.FindControl("txtBankrefNo");
                                    TextBox Split_txtpaymentClearDate = (TextBox)Split_row.FindControl("txtpaymentClearDate");
                                    TextBox Split_txtTenure = (TextBox)Split_row.FindControl("txtTenure");
                                    TextBox Split_txtPaymentDueDate = (TextBox)Split_row.FindControl("txtPaymentDueDate");
                                    TextBox Split_txtPaymentRecDate = (TextBox)Split_row.FindControl("txtPaymentRecDate");
                                    TextBox Split_txtPaymentRecAmt = (TextBox)Split_row.FindControl("txtPaymentRecAmt");
                                    DropDownList Split_ddlBankRefNo = (DropDownList)Split_row.FindControl("ddlBankRefNo");
                                    HiddenField Split_hdnShipmentNo__PkID = (HiddenField)Split_row.FindControl("hdnShipmentNo__PkID");
                                    CheckBox Split_chkIsSplit = (CheckBox)Split_row.FindControl("chkIsSplit");
                                    CheckBox Split_ChkIsFullPayemntRec = (CheckBox)Split_row.FindControl("ChkIsFullPayemntRec");
                                    CheckBox Split_chkaction = (CheckBox)Split_row.FindControl("chkaction");

                                    if (Split_txtBankrefNo != null && string.Equals(Split_txtBankrefNo.Text.Trim().ToUpper(), Var_BankRefNo.Trim().ToUpper(), StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        SplitPackingDelivery.Flag = "BIPLPAYMENT";
                                        SplitPackingDelivery.OrderDetailsID = Convert.ToInt32(Split_hdnOrderDetailID.Value);
                                        SplitPackingDelivery.BankRefNumber = Var_BankRefNo;
                                        SplitPackingDelivery.PaymentClearDate = Var_PaymentClearDate;
                                        SplitPackingDelivery.Tenure = Var_Tenure.ToString();
                                        SplitPackingDelivery.PaymentDueDate = Var_PaymentDueDate;
                                        SplitPackingDelivery.PaymentReceiveDate = Split_txtPaymentRecDate.Text;
                                        SplitPackingDelivery.ShipmentNo__PkID = Convert.ToInt32(Split_hdnShipmentNo__PkID.Value);
                                        SplitPackingDelivery.IsSingle = (Split_chkIsSplit.Checked == true) ? "Y" : "N";
                                        SplitPackingDelivery.OldBnkRefNo = Split_ddlBankRefNo.SelectedItem.Text;
                                        if (Split_txtPaymentRecAmt.Text.Trim() == "")
                                            SplitPackingDelivery.BankPaymentRecAmt = 0;
                                        else
                                        {
                                            if (Convert.ToDouble(Split_txtPaymentRecAmt.Text.Trim()) > 0)
                                                SplitPackingDelivery.BankPaymentRecAmt = Convert.ToDouble(Split_txtPaymentRecAmt.Text.Trim());
                                            else
                                                SplitPackingDelivery.BankPaymentRecAmt = 0;
                                        }
                                        SplitPackingDelivery.IsFullPaymentCleard = (Split_ChkIsFullPayemntRec.Checked == true ? 1 : 0);
                                        IsSave = this.InvoiceControllerInstance.UpdateInvoiceBankPayment(SplitPackingDelivery);
                                    }

                                }


                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                IsError = ex.ToString();
            }
            return IsSave;
        }
        protected void Chkinvice_CheckChanged(object sender, EventArgs e)
        {
            //double ShippedValueSum = 0;
            //foreach (GridViewRow row in grdpacking.Rows)
            //{
            //    CheckBox ChkConsoli = (CheckBox)row.FindControl("ChkConsoli");
            //    HiddenField hdnOrderDetailID = (HiddenField)row.FindControl("hdnOrderDetailID");
            //    if (ChkConsoli != null && ChkConsoli.Checked)
            //    {                  
            //            DataTable dt = this.InvoiceControllerInstance.GetInvoiceShippedValue("SHIPPEDVALUE", Convert.ToInt32(hdnOrderDetailID.Value));
            //            ShippedValueSum = ShippedValueSum + Convert.ToInt32((dt.Rows[0]["ShippedValue"]));                                         
            //    }
            //}
            //if (ShippedValueSum.ToString() == "0" || ShippedValueSum.ToString() == "0")
            //{
            //    txtInvoiceAmt.Text = "";
            //}
            //else
            //{
            //    txtInvoiceAmt.Text = (ShippedValueSum <= 0 ? "" : ShippedValueSum.ToString());
            //    txtinvoicetotalAmt.Text = txtInvoiceAmt.Text;
            //    hdninvoicetotalAmt.Value = txtInvoiceAmt.Text;
            //}
            //GetInvoiceActualAmt();
            GetShipValue();

        }
        public bool ValidateInvoiceNumber(string invoiceno)
        {
            bool result = true;
            if (ddlshipingno.SelectedValue != "999")
            {
                DataTable dt = this.InvoiceControllerInstance.ValidateinvoiceNo("GETSHIPPINGALL", invoiceno.ToUpper());
                if (dt.Rows[0]["Result"].ToString() == "1")
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            return result;

        }
        protected void txtInvoiceNo_TextChanged(object sender, System.EventArgs e)
        {
            if (!ValidateInvoiceNumber(txtInvoiceNo.Text.Trim().ToUpper()))
            {
                ShowAlert("Invoice number already associated with another shipment number");
                if (hdninvoiceno.Value != "")
                {
                    txtInvoiceNo.Text = hdninvoiceno.Value;
                }
                else
                {
                    txtInvoiceNo.Text = "";
                }
            }
        }
        public void GetSerialNumber(Repeater rpt, string ShipmentNo)
        {
            DataTable dt = this.InvoiceControllerInstance.GetSerialNumber("GETSERIALNO", ShipmentNo);
            if (dt.Rows.Count > 0)
            {
                rpt.DataSource = dt;
                rpt.DataBind();
            }
        }
        public void CopyFileWithDiffName(string OldFileName, string NewFileName)
        {
            string oldPath = OldFileName;
            //string newpath = @"C:\NewFolder\";
            string newpath = Server.MapPath(Deliveryfolder);
            string newFileName = NewFileName;

            FileInfo f1 = new FileInfo(Server.MapPath(Deliveryfolder) + OldFileName);
            if (f1.Exists)
            {
                if (!Directory.Exists(Server.MapPath(Deliveryfolder)))
                {
                    Directory.CreateDirectory(newpath);
                }
                f1.CopyTo(string.Format("{0}{1}{2}", newpath, newFileName, ""));
            }

        }
        public void GetInvoiceActualAmt()
        {
            try
            {
                double frightcharge = 0, InsuranceAmt = 0, DiscountAmt = 0, invoicetotalAmt = 0, ShipValie = 0, Result = 0, InvoiceTotalAmt = 0;
                if (!string.IsNullOrEmpty(txtfrightcharge.Text))
                    frightcharge = Convert.ToDouble(txtfrightcharge.Text);
                if (!string.IsNullOrEmpty(txtInsuranceAmt.Text))
                    InsuranceAmt = Convert.ToDouble(txtInsuranceAmt.Text);
                if (!string.IsNullOrEmpty(txtDiscountAmt.Text))
                    DiscountAmt = Convert.ToDouble(txtDiscountAmt.Text);
                if (!string.IsNullOrEmpty(txtinvoicetotalAmt.Text))
                    invoicetotalAmt = Convert.ToDouble(txtinvoicetotalAmt.Text);
                if (!string.IsNullOrEmpty(txtInvoiceAmt.Text))
                    ShipValie = Convert.ToDouble(txtInvoiceAmt.Text);
                if (!string.IsNullOrEmpty(txtinvoicetotalAmt.Text))
                    InvoiceTotalAmt = Convert.ToDouble(txtinvoicetotalAmt.Text);

                Result = ((frightcharge + InsuranceAmt) - DiscountAmt);
                if (Result > 0)
                {

                    txtinvoicetotalAmt.Text = (InvoiceTotalAmt + Result).ToString("F");
                }
                else if (Result < 0)
                {

                    txtinvoicetotalAmt.Text = (InvoiceTotalAmt - Math.Abs(Result)).ToString("F");
                }
                else
                { txtinvoicetotalAmt.Text = txtInvoiceAmt.Text; }

                txtinvoicetotalAmt.Text = (txtinvoicetotalAmt.Text == "" ? "" : Convert.ToDouble(txtinvoicetotalAmt.Text).ToString("N2"));
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }
        protected void rptserial_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Label lblSerialNo = (Label)e.Item.FindControl("lblSerialNo");

            if (lblSerialNo != null && lblSerialNo.Text != "")
            {
                string[] ss = lblSerialNo.Text.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                StringBuilder builder = new StringBuilder();
                foreach (string a in ss)
                {
                    builder.Append("<DIV>").Append(a).Append("</DIV>");
                }
                lblSerialNo.Text = builder.ToString();
            }
        }
        public void GetShipValue()
        {
            if (Flag == "INVOICED")
            {
                double ShippedValueSum = 0;
                grdpacking.AllowPaging = false;
                //grdpacking.DataBind();
                foreach (GridViewRow row in grdpacking.Rows)
                {
                    CheckBox Chkinvice = (CheckBox)row.FindControl("Chkinvice");
                    HiddenField hdnOrderDetailID = (HiddenField)row.FindControl("hdnOrderDetailID");
                    if (Chkinvice != null && Chkinvice.Checked)
                    {
                        DataTable dt = this.InvoiceControllerInstance.GetInvoiceShippedValue("SHIPPEDVALUE", Convert.ToInt32(hdnOrderDetailID.Value));
                        ShippedValueSum = ShippedValueSum + Convert.ToDouble((dt.Rows[0]["ShippedValue"]));
                    }
                }
                if (ShippedValueSum.ToString() == "0" || ShippedValueSum.ToString() == "0")
                {
                    txtInvoiceAmt.Text = "";
                }
                else
                {
                    txtInvoiceAmt.Text = (ShippedValueSum <= 0 ? "" : ShippedValueSum.ToString("F"));
                    txtinvoicetotalAmt.Text = txtInvoiceAmt.Text;
                    hdninvoicetotalAmt.Value = txtInvoiceAmt.Text;

                    txtInvoiceAmt.Text = (txtInvoiceAmt.Text == "0" ? "" : Convert.ToDouble(txtInvoiceAmt.Text).ToString("N2"));
                }
                GetInvoiceActualAmt();
                grdpacking.AllowPaging = true;
                //grdpacking.DataBind();
            }

        }
        //private void RememberOldValues()
        //{
        //    ArrayList categoryIDList = new ArrayList();
        //    int index = -1;
        //    foreach (GridViewRow row in grdpacking.Rows)
        //    {
        //        index = (int)grdpacking.DataKeys[row.RowIndex].Value;
        //        bool result = ((CheckBox)row.FindControl("chkSelect")).Checked;

        //        if (Session["CHECKED_ITEMS"] != null)
        //            categoryIDList = (ArrayList)Session["CHECKED_ITEMS"];
        //        if (result)
        //        {
        //            if (!categoryIDList.Contains(index))
        //                categoryIDList.Add(index);
        //        }
        //        else
        //            categoryIDList.Remove(index);
        //    }
        //    if (categoryIDList != null && categoryIDList.Count > 0)
        //        Session["CHECKED_ITEMS"] = categoryIDList;
        //}

        //private void RePopulateValues()
        //{
        //    ArrayList categoryIDList = (ArrayList)Session["CHECKED_ITEMS"];
        //    if (categoryIDList != null && categoryIDList.Count > 0)
        //    {
        //        foreach (GridViewRow row in grdpacking.Rows)
        //        {
        //            int index = (int)grdpacking.DataKeys[row.RowIndex].Value;
        //            if (categoryIDList.Contains(index))
        //            {
        //                CheckBox myCheckBox = (CheckBox)row.FindControl("chkSelect");
        //                myCheckBox.Checked = true;
        //            }
        //        }
        //    }
        //}

        public void dis(TextBox txt, DropDownList ddl)
        {
            ListItem item = ddl.Items.FindByText(txt.Text);
            if (item != null)
            {

                string itemToCompare = string.Empty;
                string itemOrigin = txt.Text;
                foreach (ListItem items in ddl.Items)
                {
                    itemToCompare = items.Text.ToLower();
                    if (itemOrigin == itemToCompare)
                    {
                        ddlshipingno.ClearSelection();
                        // items.Selected = true;

                        items.Attributes.Add("style", "color:gray;");
                        items.Attributes.Add("disabled", "true");
                        items.Value = "-1";


                    }

                }
            }

        }

        protected void btnSave_Click(object sender, EventArgs e) 
        {
          try 
          {
            btnSave.Enabled = false;
            // DataSet ds = this.InvoiceControllerInstance.GetBankRefNoForGrouping("DELETE",-1); //delete action check box
            //if (Flag == "PACKING")
            //{
            //    SavePackingDetails();
            //}
            if (Flag == "CONSOLIDATION")
            {
              SaveConsolidationDetails();
              bool IsTrue;
              SavePackingDetails(out IsTrue);
              if (!IsTrue)
              {
                return;
              }
              else
              {
               
                ////BindConsolidationGrd();
                Response.Redirect(Request.RawUrl);
              }
            }
            else if (Flag == "INVOICED")
            {
              SaveInvoiceDetails();
            }
            else if (Flag == "INVOICEPAYMENT")
            {
              if (ValidateActionCheckBox() == false)
              {
                Response.Redirect(Request.RawUrl);
                return;
                //ShowAlert("Please select at least one action check box");
                //return;

              }

              string StrErrorSingleSplit = "";
              string StrErrorMultipleSplit = "";
              bool IsSingl = false;
              bool IsMultple = false;
              IsSingl = SaveInvoicePaymentDetails(out StrErrorSingleSplit);
              if (IsSingl)
              {
                IsMultple = UpdateSplitOderBillingDetail(out StrErrorMultipleSplit);
              }
              if (IsSingl && IsMultple)
              {
                ShowAlert("Payment details updated successfully");
                BankRefNo = ""; BankRefNoQuery = "";
                BindPackingGrd();

              }
              else
              {
                ShowAlert("Some error occurred while updating record please contact with website administration");
                btnSave.Enabled = true;
                return;
              }

            }
          }
          catch (Exception ex)
          {
            ShowAlert(ex.ToString());
          }
          finally
          {
            btnSave.Enabled = true;
          }
        }



    }
}