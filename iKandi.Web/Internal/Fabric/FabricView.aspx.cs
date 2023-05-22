using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections.Generic;
using iKandi.BLL;
using System.Text.RegularExpressions;
using iKandi.Common;
using iKandi.Web.Components;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;

using Pechkin;
using System.Net;
using System.Net.Mail;



namespace iKandi.Web.Internal.Fabric
{
    public partial class FabricView : System.Web.UI.Page
    {
        FabricController fabobj = new FabricController();

        public string Fabtype { get; set; }
        public string Userid { get; set; }
        public int IcheckHideCol { get; set; }
        public int MasterPoID { get; set; }
        public int SupplierCount { get; set; }
        public string SupplierPO { get; set; }
        public string SelectedTab { get; set; }
        public string FabricQuality { get; set; }
        public string FabricQualityDetails { get; set; }
        public string MailPoNumber { get; set; }
        public string MailSupplierID { get; set; }
        public string MailIsMailSend { get; set; }
        public void getquerystring()
        {
            if (Request.QueryString["Fabtype"] != null)
            {
                Fabtype = Request.QueryString["Fabtype"].ToString();
            }
            else
            {
                Fabtype = "";
            }
            if (Request.QueryString["SupplierPO"] != null)
            {
                SupplierPO = Request.QueryString["SupplierPO"].ToString();
            }
            else
            {
                SupplierPO = "";
            }

            if (Request.QueryString["Po_number"] != null)
            {
                MailPoNumber = Request.QueryString["Po_number"].ToString();
            }
            else
            {
                MailPoNumber = "";
            }

            if (Request.QueryString["SupplierNasterID"] != null)
            {
                MailSupplierID = Request.QueryString["SupplierNasterID"].ToString();
            }
            else
            {
                MailSupplierID = "";
            }
            if (Request.QueryString["IsMailSend"] != null)
            {
                MailIsMailSend = Request.QueryString["IsMailSend"].ToString();
            }
            else
            {
                MailIsMailSend = "";
            }
        }

        string host = "";

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            host = "http://" + Request.Url.Authority;

            Userid = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID.ToString();

            getquerystring();
            Fabtype = hdnFabtype.Value;

             if (!Page.IsPostBack)
            {
                if (Session["q"] != null && Session["q"].ToString() != "")
                {
                    if (MailPoNumber != "")
                    {
                        hdnponumber.Value = MailPoNumber;
                        hdnmasterpoid.Value = MailSupplierID;
                        hdnIsMailSend.Value = MailIsMailSend;
                    }
                    var uri = new Uri(host + "/../../FabricPurChasedFormPrint.aspx?" + Session["q"].ToString());
                    var query = HttpUtility.ParseQueryString(uri.Query);
                    hdnStageName.Value = query.Get("FabType").ToString();
                    if (query.Get("FabType").ToString().ToLower() == "griege".ToLower())
                    {
                        hdnStageName.Value = "GRIEGE";
                    }
                    Fabtype = hdnStageName.Value;
                    hdnFabtype.Value = hdnStageName.Value;
                    btnSearch_Click(sender, e);
                }
                else
                {
                    hdnIsMailSend.Value = "";
                    BindAll();
                    SaveGerigeData();
                    SaveFinishData();
                    SaveDayedData();
                    SavePrintData();
                    SaveRFDData();
                    SaveEmbellishmentData();
                    SaveEmbroideryData();
                    ShowHideControls();
                    margerows();
                }


            }


            Session["q"] = null;

            if (Request.RawUrl.Contains("#"))
            {
                string s = HttpUtility.UrlEncode(Request.RawUrl);
                HttpContext.Current.Server.UrlEncode(Request.RawUrl);

            }
        }
        private void BindAll(string Refreshgrd = "")
        {


            //Get the Current Page Name.


            //Get the Previous Page Name.
            if (Request.UrlReferrer != null)
            {
                string previousPageName = Request.UrlReferrer.Segments[Request.UrlReferrer.Segments.Length - 1];
                if (previousPageName == "frmMO.aspx")
                {


                    if (Request.QueryString["TradeName"] != null)
                    {
                        //Response.Write("Previous Page: " + previousPageName);
                        //   txtsearchkeyswords.Text = Request.QueryString["FabricDetails"].ToString();
                        txtsearchkeyswords.Text = Request.QueryString["TradeName"].ToString();
                        //hdnFabtype.Value = Request.QueryString["TradeName"].ToString();
                    }
                }
                else if (previousPageName == "PendingOrderSummary.aspx")
                {

                    if (Request.QueryString["TradeName"] != null)
                    {

                        txtsearchkeyswords.Text = Request.QueryString["TradeName"].ToString();
                    }

                }
                else if (previousPageName == "FabricView.aspx")
                {
                    if (Request.QueryString["TradeName"] != null)
                    {
                        txtsearchkeyswords.Text = Request.QueryString["TradeName"].ToString();
                    }
                }
            }

            if (!string.IsNullOrEmpty(SupplierPO))
            {
                txtsearchkeyswords.Text = SupplierPO;
            }
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            // getquerystring();
            if (Refreshgrd.ToLower() == "" || Refreshgrd.ToLower() == "GRIEGE".ToLower())
            {
                if (Fabtype.ToLower() == "GRIEGE".ToLower() || Fabtype.ToLower() == "")
                {
                    // Margecol_Gerige();
                    ds = fabobj.GetfabricViewdetails("GRIEGE", "GET", 0, 0, "", txtsearchkeyswords.Text.Trim());
                    dt = ds.Tables[0];
                    //if (dt.Rows.Count > 0)
                    //{

                    grdgreigerasiepo.DataSource = dt;
                    grdgreigerasiepo.DataBind();
                    MergeRowsgrige(grdgreigerasiepo);

                    //}

                }

                if (Refreshgrd.ToLower() == "FINISHING".ToLower())
                {
                    Margecol_Finishing();
                    ds = fabobj.GetfabricViewdetails("FINISHING", "GET", 0, 0, "", txtsearchkeyswords.Text.Trim());
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        grdfinishing.DataSource = dt;
                        grdfinishing.DataBind();
                    }
                }

                if (Refreshgrd.ToLower() == "DAYED".ToLower())
                {
                    //Margecol_Finishing();

                    List<FabricGroupAdmin.FabricDetailsDayed> fabbasic = fabobj.GetFabricDayedDetailsFirst(txtsearchkeyswords.Text.Trim());
                    if (fabbasic.Count > 0)
                    {
                        grdgayed.DataSource = fabbasic;
                        grdgayed.DataBind();
                    }
                }
            }
            else
            {
                if (Refreshgrd != "")
                {
                    if (Refreshgrd.ToLower() == "GRIEGE".ToLower())
                    {
                        ds = fabobj.GetfabricViewdetails("GRIEGE", "GET", 0, 0, "", txtsearchkeyswords.Text.Trim(), 0);
                        dt = ds.Tables[0];

                        // Margecol_Gerige();
                        grdgreigerasiepo.DataSource = dt;
                        grdgreigerasiepo.DataBind();
                        MergeRowsgrige(grdgreigerasiepo);
                    }
                    else if (Refreshgrd.ToLower() == "FINISHING".ToLower())
                    {
                        ds = fabobj.GetfabricViewdetails("FINISHING", "GET", 0, 0, "", txtsearchkeyswords.Text.Trim(), 0);
                        dt = ds.Tables[0];

                        Margecol_Finishing();
                        grdfinishing.DataSource = dt;
                        grdfinishing.DataBind();
                    }
                    else if (Refreshgrd.ToLower() == "DYED".ToLower())
                    {
                        List<FabricGroupAdmin.FabricDetailsDayed> fabbasicDayed = fabobj.GetFabricDayedDetailsFirst(txtsearchkeyswords.Text.Trim(), 0);

                        grdgayed.DataSource = fabbasicDayed;
                        grdgayed.DataBind();
                        //MergeRowsPrintcal(grdgayed);
                        MergeRowsPrint(grdgayed);
                    }
                    else if (Refreshgrd.ToLower() == "PRINT".ToLower())
                    {


                        List<FabricGroupAdmin.FabricDetailsDayed> fabbasicPrint = fabobj.GetFabricPrintDetailsFirst(txtsearchkeyswords.Text.Trim(), 0);

                        grdprint.DataSource = fabbasicPrint;
                        grdprint.DataBind();
                        // MergeRowsPrintcal(grdprint);
                        MergeRowsPrint(grdprint);
                    }
                    else if (Refreshgrd.ToLower() == "RFD".ToLower())
                    {


                        List<FabricGroupAdmin.FabricDetailsDayed> fabbasicVA = fabobj.GetFabricRFDDetailsFirst(txtsearchkeyswords.Text.Trim(), 0);

                        grdvalueadditionRFD.DataSource = fabbasicVA;
                        grdvalueadditionRFD.DataBind();
                        // MergeRowsPrintcal(grdvalueadditionRFD);
                        MergeRowsPrint(grdvalueadditionRFD);
                    }
                    else if (Refreshgrd.ToLower() == "Embellishment".ToLower())
                    {


                        List<FabricGroupAdmin.FabricDetailsDayed> fabbasicEmbellishment = fabobj.GetFabricEmbellishmentDetailsFirst(txtsearchkeyswords.Text.Trim(), 0);

                        grdEmbellishment.DataSource = fabbasicEmbellishment;
                        grdEmbellishment.DataBind();
                        //MergeRowsPrintcal(grdEmbellishment);
                        MergeRowsPrint(grdEmbellishment);

                    }
                    else if (Refreshgrd.ToLower() == "Embroidery".ToLower())
                    {
                        List<FabricGroupAdmin.FabricDetailsDayed> fabbasicEmbroidery = fabobj.GetFabricEmbroideryDetailsFirst(txtsearchkeyswords.Text.Trim(), 0);

                        grdEmbroidery.DataSource = fabbasicEmbroidery;
                        grdEmbroidery.DataBind();
                        //MergeRowsPrintcal(grdEmbroidery);
                        MergeRowsPrint(grdEmbroidery);
                    }
                }
                else
                {
                    ds = fabobj.GetfabricViewdetails("GRIEGE", "GET", 0, 0, "", txtsearchkeyswords.Text.Trim(), 0);
                    dt = ds.Tables[0];


                    grdgreigerasiepo.DataSource = dt;
                    grdgreigerasiepo.DataBind();
                    MergeRowsgrige(grdgreigerasiepo);

                    ds = fabobj.GetfabricViewdetails("FINISHING", "GET", 0, 0, "", txtsearchkeyswords.Text.Trim(), 0);
                    dt = ds.Tables[0];

                    Margecol_Finishing();
                    grdfinishing.DataSource = dt;
                    grdfinishing.DataBind();

                    List<FabricGroupAdmin.FabricDetailsDayed> fabbasicDayed = fabobj.GetFabricDayedDetailsFirst(txtsearchkeyswords.Text.Trim(), 0);

                    grdgayed.DataSource = fabbasicDayed;
                    grdgayed.DataBind();
                    //MergeRowsPrintcal(grdgayed);
                    MergeRowsPrint(grdgayed);

                    List<FabricGroupAdmin.FabricDetailsDayed> fabbasicPrint = fabobj.GetFabricPrintDetailsFirst(txtsearchkeyswords.Text.Trim(), 0);

                    grdprint.DataSource = fabbasicPrint;
                    grdprint.DataBind();
                    //MergeRowsPrintcal(grdprint);
                    MergeRowsPrint(grdprint);

                    List<FabricGroupAdmin.FabricDetailsDayed> fabbasicVA = fabobj.GetFabricRFDDetailsFirst(txtsearchkeyswords.Text.Trim(), 0);

                    grdvalueadditionRFD.DataSource = fabbasicVA;
                    grdvalueadditionRFD.DataBind();
                    //MergeRowsPrintcal(grdvalueadditionRFD);
                    MergeRowsPrint(grdvalueadditionRFD);

                    List<FabricGroupAdmin.FabricDetailsDayed> fabbasicEmbellishment = fabobj.GetFabricEmbellishmentDetailsFirst(txtsearchkeyswords.Text.Trim(), 0);

                    grdEmbellishment.DataSource = fabbasicEmbellishment;
                    grdEmbellishment.DataBind();
                    //MergeRowsPrintcal(grdEmbellishment);
                    MergeRowsPrint(grdEmbellishment);

                    List<FabricGroupAdmin.FabricDetailsDayed> fabbasicEmbroidery = fabobj.GetFabricEmbroideryDetailsFirst(txtsearchkeyswords.Text.Trim(), 0);

                    grdEmbroidery.DataSource = fabbasicEmbroidery;
                    grdEmbroidery.DataBind();
                    //MergeRowsPrintcal(grdEmbroidery);
                    MergeRowsPrint(grdEmbroidery);

                }
            }

            // BindSupplierSpecificTab();
            // txtsearchkeyswords.Text = "";
            //  margerows();
        }
        //public void BindSupplierSpecificTab()
        //{
        //    DataSet ds = new DataSet();
        //    DataTable dtFabtype = new DataTable();
        //    DataTable dtSupplier = new DataTable();
        //    //ds = fabobj.GetGriegeFabDetailsUserID("9", iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID);
        //    //dtFabtype = ds.Tables[0];
        //    //dtSupplier = ds.Tables[1];
        //    if (dtSupplier.Rows.Count > 0)
        //    {
        //        //lblusername.Text = dtSupplier.Rows[0]["FirstName"].ToString();
        //    }

        //    if (hdnFabtype.Value.ToLower() == "FINISHING".ToLower())
        //    {
        //        afinished.Attributes.Add("class", "activeback tab1finished");
        //        hdnFabtype.Value = "FINISHING";
        //        grdfinishing.Style.Add("display", "block");
        //    }
        //    else if (hdnFabtype.Value.ToLower() == "GRIEGE".ToLower())
        //    {
        //        agreige.Attributes.Add("class", "activeback tab1greige");
        //        hdnFabtype.Value = "GRIEGE";
        //        //grdgreigerasiepo.Style.Add("display", "block");
        //        grdgreigerasiepo.Style.Remove("display");
        //    }
        //    else if (hdnFabtype.Value.ToLower() == "DYED".ToLower())
        //    {
        //        adayed.Attributes.Add("class", "activeback tab1Dayed");
        //        hdnFabtype.Value = "DYED";
        //        grdgayed.Style.Add("display", "block");
        //    }
        //    else if (hdnFabtype.Value.ToLower() == "PRINT".ToLower())
        //    {
        //        aprint.Attributes.Add("class", "activeback tab1Print");
        //        hdnFabtype.Value = "PRINT";
        //        grdprint.Style.Remove("display");//TODO:change to actual grd name
        //    }
        //    else if (hdnFabtype.Value.ToLower() == "RFD".ToLower())
        //    {
        //        ava.Attributes.Add("class", "activeback tab1VA");
        //        hdnFabtype.Value = "RFD";
        //        grdvalueadditionRFD.Style.Remove("display");//TODO:change to actual grd name
        //    }
        //    else if (hdnFabtype.Value.ToLower() == "Embellishment".ToLower())
        //    {
        //        aEmbellishment.Attributes.Add("class", "activeback tabEmbellishment");
        //        hdnFabtype.Value = "Embellishment";
        //        grdEmbellishment.Style.Remove("display");//TODO:change to actual grd name
        //    }
        //    else if (hdnFabtype.Value.ToLower() == "Embroidery".ToLower())
        //    {
        //        aEmbroidery.Attributes.Add("class", "activeback tabEmbroidery");
        //        hdnFabtype.Value = "Embroidery";
        //        grdEmbroidery.Style.Remove("display");//TODO:change to actual grd name
        //    }
        //    else
        //    {
        //        agreige.Attributes.Add("class", "activeback tab1greige");
        //        grdgreigerasiepo.Style.Add("display", "block");
        //    }
        //}

        #region Save GridView
        public void SaveGerigeData()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            FabricGroupAdmin.FabricDetails Fabdet = new FabricGroupAdmin.FabricDetails();
            int Qty = 0;
            int CancelQty = 0;
            int DeleteQty = 0;
            int HoldQty = 0;
            int CancelPoQty = 0;
            foreach (GridViewRow row in grdgreigerasiepo.Rows)
            {
                HiddenField hdnfabricQuality = (HiddenField)row.FindControl("hdnfabricQuality");
                Label lblfabriccolor = (Label)row.FindControl("lblfabriccolor");
                Label lblcutwastgae = (Label)row.FindControl("lblcutwastgae");
                Label lblbalanceinhouseqty = (Label)row.FindControl("lblbalanceinhouseqty");
                int bal = (lblbalanceinhouseqty.Text == "" ? 0 : (Convert.ToInt32(Math.Round(Convert.ToDecimal(lblbalanceinhouseqty.Text)))));
                ds = fabobj.GetfabricViewdetails("GRIEGE", "RERAISESUPPLIER", Convert.ToInt32(hdnfabricQuality.Value));
                dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel)
                        {
                            Qty = Qty + Convert.ToInt32(dt.Rows[i]["ReceivedQty"].ToString());
                            HoldQty = HoldQty + Convert.ToInt32(dt.Rows[i]["HoldQty"].ToString());
                        }
                        Decimal x = 0;
                        if (lblcutwastgae.Text == "")
                        {
                            x = 0;

                        }
                        else
                        {
                            x = Convert.ToDecimal(lblcutwastgae.Text);
                        }
                        bool IsSavecut = fabobj.UpdateCutwastage("UPDATECUTWASTAGE", dt.Rows[i]["PO_Number"].ToString(), x);
                    }
                    if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == FabricPOStatus.Cancel)
                    {
                        CancelQty = CancelQty + Convert.ToInt32(dt.Rows[i]["ReceivedQty"].ToString());
                    }
                    if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                    {
                        DeleteQty = DeleteQty + Convert.ToInt32(dt.Rows[i]["ReceivedQty"].ToString());
                    }

                    CancelPoQty = CancelPoQty + Convert.ToInt32(dt.Rows[i]["CancelPoQty"].ToString());
                }
                Qty = Qty - CancelPoQty;
                TextBox txtGreige_Sh = (TextBox)row.FindControl("txtGreige_Sh");
                TextBox txtResidualSh = (TextBox)row.FindControl("txtResidualSh");
                CheckBox chkApplyResShrinkage = (CheckBox)row.FindControl("chkApplyResShrinkage");

                Label QtyToOrder = (Label)row.FindControl("lblfabricorderavg");
                Label PendingQtyToOrder = (Label)row.FindControl("lblFabQtyRemaning2");
                Fabdet.FabricQualityID = (Convert.ToInt32(hdnfabricQuality.Value));
                Fabdet.GreigedShrinkage = (txtGreige_Sh.Text == "" ? 0 : (float)Convert.ToDouble(txtGreige_Sh.Text));
                Fabdet.QtyToOrder = (PendingQtyToOrder.Text == "" ? 0 : Convert.ToInt32(Math.Round(Convert.ToDecimal(PendingQtyToOrder.Text))));
                if (chkApplyResShrinkage.Checked)
                {
                    Fabdet.GreigedResidualShrinkage = (txtResidualSh.Text == "" ? 0 : (float)Convert.ToDouble(txtResidualSh.Text));
                    Fabdet.IsGerigeShrinkage = 1;
                }
                else
                {
                    Fabdet.GreigedResidualShrinkage = 0;
                    Fabdet.IsGerigeShrinkage = 0;
                }
                Fabdet.PendingQtyToOrder = (PendingQtyToOrder.Text == "" ? 0 : (Convert.ToInt32(Math.Round(Convert.ToDecimal(PendingQtyToOrder.Text.Replace(",", "")))) - (Qty + HoldQty + bal)));
                //  Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder + CancelQty) - ((HoldQty + Fabdet.BalanceQty));
                //if (Fabdet.PendingQtyToOrder <= 0)
                //{
                //    Fabdet.PendingQtyToOrder = 0;
                //}
                //commented as Per ravi shankar
                //Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder + CancelQty) - ((HoldQty + Fabdet.BalanceQty));
                //Fabdet.ColorPrint = lblfabriccolor.Text;
                Fabdet.Flag = "GRIEGE";
                Fabdet.FlagOption = "UPDATE";
                Fabdet.UserID = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                bool IsSave = fabobj.updatePendingGreigeOrders(Fabdet);
                Qty = 0;
                HoldQty = 0;

            }


        }
        public void SaveFinishData()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            FabricGroupAdmin.FabricDetails Fabdet = new FabricGroupAdmin.FabricDetails();
            int Qty = 0;
            int CancelQty = 0;
            int HoldQty = 0;
            int CutIssueDonePoQty = 0;
            int CancelPoQty = 0;
            foreach (GridViewRow row in grdfinishing.Rows)
            {
                HiddenField hdnfabricQuality = (HiddenField)row.FindControl("hdnfabricQuality");
                HiddenField hdnfabprint = (HiddenField)row.FindControl("hdnfabprint");
                Label lblcutwastgae = (Label)row.FindControl("lblcutwastgae");

                Label lblbalanceinhouseqty = (Label)row.FindControl("lblbalanceinhouseqty");
                int bal = (lblbalanceinhouseqty.Text == "" ? 0 : (Convert.ToInt32(Math.Round(Convert.ToDecimal(lblbalanceinhouseqty.Text)))));
                Label lblcolor = (Label)row.FindControl("lblcolor");
                ds = fabobj.GetfabricViewdetails("FINISHING", "RERAISESUPPLIER", Convert.ToInt32(hdnfabricQuality.Value), 0, hdnfabprint.Value);
                dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //CutIssueDonePoQty = Convert.ToInt32(dt.Rows[0]["CutIssueDonePoQty"].ToString());
                    if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                        {
                            Qty = Qty + Convert.ToInt32(dt.Rows[i]["ReceivedQty"].ToString());
                            HoldQty = HoldQty + Convert.ToInt32(dt.Rows[i]["HoldQty"].ToString());
                        }
                    }
                    Decimal x = 0;
                    if (lblcutwastgae.Text == "")
                    {
                        x = 0;

                    }
                    else
                    {
                        x = Convert.ToDecimal(lblcutwastgae.Text);
                    }
                    bool IsSavecut = fabobj.UpdateCutwastage("UPDATECUTWASTAGE", dt.Rows[i]["PO_Number"].ToString(), x);
                    if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == FabricPOStatus.Cancel)
                    {
                        CancelQty = CancelQty + Convert.ToInt32(dt.Rows[i]["SendQty"].ToString());
                    }
                    CancelPoQty = CancelPoQty + Convert.ToInt32(dt.Rows[i]["CancelPoQty"].ToString());
                }
                Qty = Qty - CancelPoQty;
                TextBox txtFinishedResidualShrinkage = (TextBox)row.FindControl("txtFinishedResidualShrinkage");
                Label QtyToOrder = (Label)row.FindControl("lblfabricorderavg");
                Label PendingQtyToOrder = (Label)row.FindControl("lblFabQtyRemaning2");
                Fabdet.FabricQualityID = (Convert.ToInt32(hdnfabricQuality.Value));
                Fabdet.GreigedShrinkage = (txtFinishedResidualShrinkage.Text == "" ? 0 : (float)Convert.ToDouble(txtFinishedResidualShrinkage.Text));
                Fabdet.QtyToOrder = (PendingQtyToOrder.Text == "" ? 0 : Convert.ToInt32(Math.Round(Convert.ToDecimal(PendingQtyToOrder.Text))));
                Fabdet.PendingQtyToOrder = (PendingQtyToOrder.Text == "" ? 0 : (Convert.ToInt32(Math.Round(Convert.ToDecimal(PendingQtyToOrder.Text)) + CancelQty) - (Qty + HoldQty + bal + CutIssueDonePoQty)));
                //if (Fabdet.PendingQtyToOrder <= 0)
                //{
                //    Fabdet.PendingQtyToOrder = 0;
                //}
                // Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder + CancelQty) - ((HoldQty + Fabdet.BalanceQty));
                Fabdet.Flag = "FINISHING";
                Fabdet.FlagOption = "UPDATE";
                Fabdet.ColorPrint = hdnfabprint.Value;
                Fabdet.UserID = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                bool IsSave = fabobj.updatePendingGreigeOrders(Fabdet);
                Qty = 0;
                HoldQty = 0;
            }


        }
        public void SaveDayedData()
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).Text = ((TextBox)x).Text.Replace(",", "");
                }
                else if (x is Label)
                {
                    ((Label)x).Text = ((Label)x).Text.Replace(",", "");
                }

            }
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            FabricGroupAdmin.FabricDetails Fabdet = new FabricGroupAdmin.FabricDetails();
            int Qty = 0;
            int CancelQty = 0;
            int HoldQty = 0;
            int CancelPoQty = 0;
            foreach (GridViewRow row in grdgayed.Rows)
            {
                HiddenField hdnfabricQuality = (HiddenField)row.FindControl("hdnfabricQuality");
                Label lblfabriccolor = (Label)row.FindControl("lblfabriccolor");
                Label lblcutwastgae = (Label)row.FindControl("lblcutwastgae");
                HiddenField hdnstage1 = (HiddenField)row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)row.FindControl("hdnstage4");
                HiddenField hdnStyleID = (HiddenField)row.FindControl("hdnStyleID");
                HiddenField hdnCurrentstage = (HiddenField)row.FindControl("hdnCurrentstage");
                HiddenField hdnperiviousstgae = (HiddenField)row.FindControl("hdnperiviousstgae");
                HiddenField hdnIsStyleSpecific = (HiddenField)row.FindControl("hdnIsStyleSpecific");

                HiddenField hdnadjustmentqty = (HiddenField)row.FindControl("hdnadjustmentqty");
                HiddenField hdnPreviousadjustmentqty = (HiddenField)row.FindControl("hdnPreviousadjustmentqty");
                hdnPreviousadjustmentqty.Value = hdnPreviousadjustmentqty.Value == "" ? "0" : hdnPreviousadjustmentqty.Value;
                hdnadjustmentqty.Value = hdnadjustmentqty.Value == "" ? "0" : hdnadjustmentqty.Value;

                ds = fabobj.GetfabricViewdetails("Dyed", "RERAISESUPPLIER", Convert.ToInt32(hdnfabricQuality.Value), 0, lblfabriccolor.Text, "", 0, Convert.ToInt32(hdnCurrentstage.Value), Convert.ToInt32(hdnperiviousstgae.Value), Convert.ToBoolean(hdnIsStyleSpecific.Value), (Convert.ToBoolean(hdnIsStyleSpecific.Value) == true ? Convert.ToInt32(hdnStyleID.Value) : -1), Convert.ToInt32(hdnstage1.Value), Convert.ToInt32(hdnstage2.Value), Convert.ToInt32(hdnstage3.Value), Convert.ToInt32(hdnstage4.Value));
                dt = ds.Tables[0];
                Fabdet.SendQty = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel)
                        {
                            Qty = Qty + Convert.ToInt32(dt.Rows[i]["ReceivedQty"].ToString());
                            Fabdet.SendQty = Fabdet.SendQty + Convert.ToInt32(dt.Rows[i]["SendQty"].ToString());
                            HoldQty = HoldQty + Convert.ToInt32(dt.Rows[i]["HoldQty"].ToString());
                        }

                        Decimal x = 0;
                        if (lblcutwastgae.Text == "")
                        {
                            x = 0;

                        }
                        else
                        {
                            x = Convert.ToDecimal(lblcutwastgae.Text);
                        }
                        bool IsSavecut = fabobj.UpdateCutwastage("UPDATECUTWASTAGE", dt.Rows[i]["PO_Number"].ToString(), x);
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == FabricPOStatus.Cancel)
                        {
                            CancelQty = CancelQty + Convert.ToInt32(dt.Rows[i]["SendQty"].ToString());
                        }
                    }
                    CancelPoQty = CancelPoQty + Convert.ToInt32(dt.Rows[i]["CancelPoQty"].ToString());
                }


                TextBox txtResidualShak = (TextBox)row.FindControl("txtResidualShak");
                TextBox txtGreigeshrk = (TextBox)row.FindControl("txtGreigeshrk");
                Label lblbalanceinhouseqty = (Label)row.FindControl("lblbalanceinhouseqty");
                // Need to use this for PO raise
                Label lblfabricQty = (Label)row.FindControl("lblfabricQty");
                // End
                Label lbltotalqtytosend = (Label)row.FindControl("lbltotalqtytosend");
                Label lblpriorstageQty = (Label)row.FindControl("lblpriorstageQty");


                Label PendingQtyToOrder = (Label)row.FindControl("lblFabQtyRemaning");
                HiddenField hdnfabprint = (HiddenField)row.FindControl("hdnfabprint");
                Fabdet.FabricQualityID = (Convert.ToInt32(hdnfabricQuality.Value));
                Fabdet.ResidualShrinkage = (txtResidualShak.Text == "" ? 0 : (float)Convert.ToDouble(txtResidualShak.Text.Replace(",", "")));
                Fabdet.GreigedShrinkage = (txtGreigeshrk.Text == "" ? 0 : (float)Convert.ToDouble(txtGreigeshrk.Text.Replace(",", "")));
                Fabdet.BalanceQty = (lblbalanceinhouseqty.Text == "" ? 0 : Convert.ToInt32(lblbalanceinhouseqty.Text.Replace(",", ""))); // qty from stock
                //Fabdet.PendingQtyToOrder = lblpriorstageQty.Text == "" ? 0 : (Convert.ToInt32(lblpriorstageQty.Text.Replace(",", "")) - (Fabdet.SendQty));
                // Redefine as per requirement
                Fabdet.PendingQtyToOrder = lblfabricQty.Text == "" ? 0 : (Convert.ToInt32(lblfabricQty.Text.Replace(",", "")) - (Fabdet.SendQty));
                // End
                Fabdet.SendQty = Qty;
                Fabdet.SendQty = Fabdet.SendQty - CancelPoQty;
                //Fabdet.PendingQtyToOrder = lblpriorstageQty.Text == "" ? 0 : (Convert.ToInt32(lblpriorstageQty.Text.Replace(",", "")) - Qty);

                int fabricQty = 0;
                // Commented on dated 28 Jan 2021
                //if (!string.IsNullOrEmpty(lblpriorstageQty.Text))
                //    //fabricQty = Convert.ToInt32(lblfabricQty.Text.Replace(",", ""));
                //    fabricQty = Convert.ToInt32(lblpriorstageQty.Text.Replace(",", ""));
                // End
                if (!string.IsNullOrEmpty(lblfabricQty.Text))
                    fabricQty = Convert.ToInt32(lblfabricQty.Text.Replace(",", ""));

                int balQty = 0;
                if (!string.IsNullOrEmpty(lblbalanceinhouseqty.Text))
                    balQty = Convert.ToInt32(lblbalanceinhouseqty.Text.Replace(",", ""));

                decimal fabqty = (Convert.ToInt32(fabricQty) - Convert.ToInt32(balQty));
                decimal ResidualShak = Convert.ToDecimal(txtResidualShak.Text == "" ? 0 : Convert.ToDecimal(txtResidualShak.Text.Replace(",", "")));
                decimal GerigeShak = Convert.ToDecimal(txtGreigeshrk.Text == "" ? 0 : Convert.ToDecimal(txtGreigeshrk.Text.Replace(",", "")));

                //fabqty = fabqty + ((fabqty * ResidualShak) / Convert.ToDecimal(100));
                //fabqty = fabqty + ((fabqty * GerigeShak) / Convert.ToDecimal(100));
                Fabdet.QtyToOrder = Convert.ToInt32(Math.Round(fabqty, 0));

                //if (Fabdet.PendingQtyToOrder <= 0)
                //{
                //    Fabdet.PendingQtyToOrder = 0;
                //}
                //commented as Per ravi shankar
                //Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder + CancelQty) - ((HoldQty + Fabdet.BalanceQty));

                if (hdnCurrentstage.Value != "1")
                {
                    Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder - (Convert.ToInt32(hdnPreviousadjustmentqty.Value)));
                }
                else
                {
                    Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder - (Convert.ToInt32(balQty)));
                }
                Fabdet.Flag = "DYED";
                Fabdet.FlagOption = "UPDATE";
                Fabdet.ColorPrint = hdnfabprint.Value;
                Fabdet.UserID = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

                Fabdet.stage1 = Convert.ToInt32(hdnstage1.Value);
                Fabdet.stage2 = Convert.ToInt32(hdnstage2.Value);
                Fabdet.stage3 = Convert.ToInt32(hdnstage3.Value);
                Fabdet.stage4 = Convert.ToInt32(hdnstage4.Value);
                Fabdet.StyleID = Convert.ToInt32(hdnStyleID.Value);
                Fabdet.Currentstage = Convert.ToInt32(hdnCurrentstage.Value);
                Fabdet.periviousstgae = Convert.ToInt32(hdnperiviousstgae.Value);
                Fabdet.IsStyleSpecific = Convert.ToBoolean(hdnIsStyleSpecific.Value == "False" ? false : true);

                bool IsSave = fabobj.updatePendingDayedOrders(Fabdet);
                Qty = 0;
            }
        }
        public void SavePrintData()
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).Text = ((TextBox)x).Text.Replace(",", "");
                }
                else if (x is Label)
                {
                    ((Label)x).Text = ((Label)x).Text.Replace(",", "");
                }

            }
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            FabricGroupAdmin.FabricDetails Fabdet = new FabricGroupAdmin.FabricDetails();
            int Qty = 0;
            int CancelQty = 0;
            int HoldQty = 0;
            int CancelPoQty = 0;
            foreach (GridViewRow row in grdprint.Rows)
            {
                Label lblcolor = (Label)row.FindControl("lblcolor");
                Label lblcutwastgae = (Label)row.FindControl("lblcutwastgae");
                HiddenField hdnstage1 = (HiddenField)row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)row.FindControl("hdnstage4");
                HiddenField hdnCurrentstage = (HiddenField)row.FindControl("hdnCurrentstage");
                HiddenField hdnperiviousstgae = (HiddenField)row.FindControl("hdnperiviousstgae");
                HiddenField hdnIsStyleSpecific = (HiddenField)row.FindControl("hdnIsStyleSpecific");
                HiddenField hdnStyleID = (HiddenField)row.FindControl("hdnStyleID");
                HiddenField hdnfabricQuality = (HiddenField)row.FindControl("hdnfabricQuality");

                HiddenField hdnadjustmentqty = (HiddenField)row.FindControl("hdnadjustmentqty");
                HiddenField hdnPreviousadjustmentqty = (HiddenField)row.FindControl("hdnPreviousadjustmentqty");
                hdnPreviousadjustmentqty.Value = hdnPreviousadjustmentqty.Value == "" ? "0" : hdnPreviousadjustmentqty.Value;
                hdnadjustmentqty.Value = hdnadjustmentqty.Value == "" ? "0" : hdnadjustmentqty.Value;


                ds = fabobj.GetfabricViewdetails("PRINT", "RERAISESUPPLIER", Convert.ToInt32(hdnfabricQuality.Value), 0, lblcolor.Text, "", 0, Convert.ToInt32(hdnCurrentstage.Value), Convert.ToInt32(hdnperiviousstgae.Value), Convert.ToBoolean(hdnIsStyleSpecific.Value), (Convert.ToBoolean(hdnIsStyleSpecific.Value) == true ? Convert.ToInt32(hdnStyleID.Value) : -1), Convert.ToInt32(hdnstage1.Value), Convert.ToInt32(hdnstage2.Value), Convert.ToInt32(hdnstage3.Value), Convert.ToInt32(hdnstage4.Value));
                dt = ds.Tables[0];
                Fabdet.SendQty = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel)
                        {
                            Qty = Qty + Convert.ToInt32(dt.Rows[i]["ReceivedQty"].ToString());
                            Fabdet.SendQty = Fabdet.SendQty + Convert.ToInt32(dt.Rows[i]["SendQty"].ToString());
                            HoldQty = HoldQty + Convert.ToInt32(dt.Rows[i]["HoldQty"].ToString());
                        }
                        Decimal x = 0;
                        if (lblcutwastgae.Text == "")
                        {
                            x = 0;

                        }
                        else
                        {
                            x = Convert.ToDecimal(lblcutwastgae.Text);
                        }
                        bool IsSavecut = fabobj.UpdateCutwastage("UPDATECUTWASTAGE", dt.Rows[i]["PO_Number"].ToString(), x);
                    }
                    if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == FabricPOStatus.Cancel)
                    {
                        CancelQty = CancelQty + Convert.ToInt32(dt.Rows[i]["SendQty"].ToString());
                    }
                    CancelPoQty = CancelPoQty + Convert.ToInt32(dt.Rows[i]["CancelPoQty"].ToString());
                }
                Fabdet.SendQty = Fabdet.SendQty - CancelPoQty;
                TextBox txtResidualShak = (TextBox)row.FindControl("txtResidualShak");
                TextBox txtGreigeshrk = (TextBox)row.FindControl("txtGreigeshrk");
                Label lblbalanceinhouseqty = (Label)row.FindControl("lblbalanceinhouseqty");
                // Need to use this for PO raise
                Label lblfabricQty = (Label)row.FindControl("lblfabricQty");
                // End
                Label lbltotalqtytosend = (Label)row.FindControl("lbltotalqtytosend");
                Label lblpriorstageQty = (Label)row.FindControl("lblpriorstageQty");

                Label PendingQtyToOrder = (Label)row.FindControl("lblFabQtyRemaning");


                Fabdet.FabricQualityID = (Convert.ToInt32(hdnfabricQuality.Value));
                Fabdet.ResidualShrinkage = (txtResidualShak.Text == "" ? 0 : (float)Convert.ToDouble(txtResidualShak.Text.Replace(",", "")));
                Fabdet.GreigedShrinkage = (txtGreigeshrk.Text == "" ? 0 : (float)Convert.ToDouble(txtGreigeshrk.Text.Replace(",", "")));
                Fabdet.BalanceQty = (lblbalanceinhouseqty.Text == "" ? 0 : Convert.ToInt32(lblbalanceinhouseqty.Text.Replace(",", ""))); // qty from stock
                // Fabdet.SendQty = Qty;
                // Fabdet.PendingQtyToOrder = lblpriorstageQty.Text == "" ? 0 : (Convert.ToInt32(lblpriorstageQty.Text.Replace(",", "")) - Qty);                
                //Fabdet.PendingQtyToOrder = lblpriorstageQty.Text == "" ? 0 : (Convert.ToInt32(lblpriorstageQty.Text.Replace(",", "")) - (Fabdet.SendQty));
                // Redefine as per requirement
                Fabdet.PendingQtyToOrder = lblfabricQty.Text == "" ? 0 : (Convert.ToInt32(lblfabricQty.Text.Replace(",", "")) - (Fabdet.SendQty));
                // End
                int fabricQty = 0;
                //if (!string.IsNullOrEmpty(lblpriorstageQty.Text))
                //    //fabricQty = Convert.ToInt32(lblfabricQty.Text.Replace(",", ""));
                //    fabricQty = Convert.ToInt32(lblpriorstageQty.Text.Replace(",", ""));
                if (!string.IsNullOrEmpty(lblfabricQty.Text))
                    fabricQty = Convert.ToInt32(lblfabricQty.Text.Replace(",", ""));

                int balQty = 0;
                if (!string.IsNullOrEmpty(lblbalanceinhouseqty.Text))
                    balQty = Convert.ToInt32(lblbalanceinhouseqty.Text.Replace(",", ""));

                decimal fabqty = (Convert.ToInt32(fabricQty) - Convert.ToInt32(balQty));
                decimal ResidualShak = Convert.ToDecimal(txtResidualShak.Text == "" ? 0 : Convert.ToDecimal(txtResidualShak.Text.Replace(",", "")));
                decimal GerigeShak = Convert.ToDecimal(txtGreigeshrk.Text == "" ? 0 : Convert.ToDecimal(txtGreigeshrk.Text.Replace(",", "")));

                //fabqty = fabqty + ((fabqty * ResidualShak) / Convert.ToDecimal(100));
                //fabqty = fabqty + ((fabqty * GerigeShak) / Convert.ToDecimal(100));
                Fabdet.QtyToOrder = Convert.ToInt32(Math.Round(fabqty, 0));

                //if (Fabdet.PendingQtyToOrder <= 0)
                //{
                //    Fabdet.PendingQtyToOrder = 0;
                //}
                //commented as Per ravi shankar
                //Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder + CancelQty) - ((HoldQty + Fabdet.BalanceQty));

                if (hdnCurrentstage.Value != "1")
                {
                    Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder - (Convert.ToInt32(hdnPreviousadjustmentqty.Value)));
                }
                else
                {
                    Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder - (Convert.ToInt32(balQty)));
                }

                Fabdet.Flag = "PRINT";
                Fabdet.FlagOption = "UPDATE";
                Fabdet.ColorPrint = lblcolor.Text;
                Fabdet.UserID = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                Fabdet.stage1 = Convert.ToInt32(hdnstage1.Value);
                Fabdet.stage2 = Convert.ToInt32(hdnstage2.Value);
                Fabdet.stage3 = Convert.ToInt32(hdnstage3.Value);
                Fabdet.stage4 = Convert.ToInt32(hdnstage4.Value);
                Fabdet.StyleID = Convert.ToInt32(hdnStyleID.Value);
                Fabdet.Currentstage = Convert.ToInt32(hdnCurrentstage.Value);
                Fabdet.periviousstgae = Convert.ToInt32(hdnperiviousstgae.Value);
                Fabdet.IsStyleSpecific = Convert.ToBoolean(hdnIsStyleSpecific.Value == "False" ? false : true);
                bool IsSave = fabobj.updatePendingDayedOrders(Fabdet);
                Qty = 0;
            }
        }
        public void SaveRFDData()
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).Text = ((TextBox)x).Text.Replace(",", "");
                }
                else if (x is Label)
                {
                    ((Label)x).Text = ((Label)x).Text.Replace(",", "");
                }

            }
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            FabricGroupAdmin.FabricDetails Fabdet = new FabricGroupAdmin.FabricDetails();
            int Qty = 0;
            int CancelQty = 0;
            int HoldQty = 0;
            int CancelPoQty = 0;
            foreach (GridViewRow row in grdvalueadditionRFD.Rows)
            {
                Label lblcolor = (Label)row.FindControl("lblcolor");
                Label lblcutwastgae = (Label)row.FindControl("lblcutwastgae");

                HiddenField hdnfabricQuality = (HiddenField)row.FindControl("hdnfabricQuality");
                HiddenField hdnCurrentstage = (HiddenField)row.FindControl("hdnCurrentstage");
                HiddenField hdnperiviousstgae = (HiddenField)row.FindControl("hdnperiviousstgae");
                HiddenField hdnIsStyleSpecific = (HiddenField)row.FindControl("hdnIsStyleSpecific");
                HiddenField hdnStyleID = (HiddenField)row.FindControl("hdnStyleID");
                HiddenField hdnstage1 = (HiddenField)row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)row.FindControl("hdnstage4");

                //ds = fabobj.GetfabricViewdetails("RFD", "RERAISESUPPLIER", Convert.ToInt32(hdnfabricQuality.Value), 0, lblcolor.Text);
                ds = fabobj.GetfabricViewdetails("RFD", "RERAISESUPPLIER", Convert.ToInt32(hdnfabricQuality.Value), 0, lblcolor.Text, "", 0, Convert.ToInt32(hdnCurrentstage.Value), Convert.ToInt32(hdnperiviousstgae.Value), Convert.ToBoolean(hdnIsStyleSpecific.Value), (Convert.ToBoolean(hdnIsStyleSpecific.Value) == true ? Convert.ToInt32(hdnStyleID.Value) : -1), Convert.ToInt32(hdnstage1.Value), Convert.ToInt32(hdnstage2.Value), Convert.ToInt32(hdnstage3.Value), Convert.ToInt32(hdnstage4.Value));
                bool hasRows = ds.Tables.Cast<DataTable>().Any(table => table.Rows.Count != 0);
                if (hasRows)
                {
                    dt = ds.Tables[0];
                }
                Fabdet.SendQty = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel)
                        {
                            Qty = Qty + Convert.ToInt32(dt.Rows[i]["ReceivedQty"].ToString());
                            if (Convert.ToInt32(hdnstage1.Value) == 29)
                            {
                                Fabdet.SendQty = Fabdet.SendQty + Convert.ToInt32(dt.Rows[i]["ReceivedQty"].ToString());
                            }
                            else
                            {
                                Fabdet.SendQty = Fabdet.SendQty + Convert.ToInt32(dt.Rows[i]["SendQty"].ToString());
                            }
                            HoldQty = HoldQty + Convert.ToInt32(dt.Rows[i]["HoldQty"].ToString());
                        }
                        Decimal x = 0;
                        if (lblcutwastgae.Text == "")
                        {
                            x = 0;

                        }
                        else
                        {
                            x = Convert.ToDecimal(lblcutwastgae.Text);
                        }
                        bool IsSavecut = fabobj.UpdateCutwastage("UPDATECUTWASTAGE", dt.Rows[i]["PO_Number"].ToString(), x);

                    }
                    if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == FabricPOStatus.Cancel)
                    {
                        CancelQty = CancelQty + Convert.ToInt32(dt.Rows[i]["SendQty"].ToString());
                    }
                    CancelPoQty = CancelPoQty + Convert.ToInt32(dt.Rows[i]["CancelPoQty"].ToString());
                }
                Fabdet.SendQty = Fabdet.SendQty - CancelPoQty;
                TextBox txtResidualShak = (TextBox)row.FindControl("txtResidualShak");
                TextBox txtGreigeshrk = (TextBox)row.FindControl("txtGreigeshrk");
                Label lblbalanceinhouseqty = (Label)row.FindControl("lblbalanceinhouseqty");
                Label lblfabricQty = (Label)row.FindControl("lblfabricQty");
                Label lbltotalqtytosend = (Label)row.FindControl("lbltotalqtytosend");
                Label lblpriorstageQty = (Label)row.FindControl("lblpriorstageQty");

                Label PendingQtyToOrder = (Label)row.FindControl("lblFabQtyRemaning");
                //HiddenField hdnstage1 = (HiddenField)row.FindControl("hdnstage1");
                //HiddenField hdnstage2 = (HiddenField)row.FindControl("hdnstage2");
                //HiddenField hdnstage3 = (HiddenField)row.FindControl("hdnstage3");
                //HiddenField hdnstage4 = (HiddenField)row.FindControl("hdnstage4");
                //HiddenField hdnCurrentstage = (HiddenField)row.FindControl("hdnCurrentstage");
                //HiddenField hdnperiviousstgae = (HiddenField)row.FindControl("hdnperiviousstgae");
                //HiddenField hdnIsStyleSpecific = (HiddenField)row.FindControl("hdnIsStyleSpecific");
                //HiddenField hdnStyleID = (HiddenField)row.FindControl("hdnStyleID");
                HiddenField hdnadjustmentqty = (HiddenField)row.FindControl("hdnadjustmentqty");
                HiddenField hdnPreviousadjustmentqty = (HiddenField)row.FindControl("hdnPreviousadjustmentqty");
                hdnPreviousadjustmentqty.Value = hdnPreviousadjustmentqty.Value == "" ? "0" : hdnPreviousadjustmentqty.Value;
                hdnadjustmentqty.Value = hdnadjustmentqty.Value == "" ? "0" : hdnadjustmentqty.Value;

                Fabdet.FabricQualityID = (Convert.ToInt32(hdnfabricQuality.Value));
                Fabdet.ResidualShrinkage = (txtResidualShak.Text == "" ? 0 : (float)Convert.ToDouble(txtResidualShak.Text.Replace(",", "")));
                Fabdet.GreigedShrinkage = (txtGreigeshrk.Text == "" ? 0 : (float)Convert.ToDouble(txtGreigeshrk.Text.Replace(",", "")));
                Fabdet.BalanceQty = (lblbalanceinhouseqty.Text == "" ? 0 : Convert.ToInt32(lblbalanceinhouseqty.Text.Replace(",", "")));

                if (Convert.ToInt32(hdnstage1.Value) == 29)
                {
                    Fabdet.PendingQtyToOrder = lbltotalqtytosend.Text == "" ? 0 : (Convert.ToInt32(lbltotalqtytosend.Text.Replace(",", "")) - (Fabdet.SendQty));
                    Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder + CancelQty) - ((HoldQty + Fabdet.BalanceQty));
                }
                else
                {
                    //Fabdet.PendingQtyToOrder = lblpriorstageQty.Text == "" ? 0 : (Convert.ToInt32(lblpriorstageQty.Text.Replace(",", "")) - (Fabdet.SendQty));
                    Fabdet.PendingQtyToOrder = lblfabricQty.Text == "" ? 0 : (Convert.ToInt32(lblfabricQty.Text.Replace(",", "")) - (Fabdet.SendQty) - Convert.ToInt32(hdnPreviousadjustmentqty.Value));
                    //Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder + CancelQty) - ((HoldQty + Fabdet.BalanceQty));
                }

                //commenting for second stage onwards
                //Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder + CancelQty) - ((HoldQty + Fabdet.BalanceQty));

                int fabricQty = 0;
                if (Convert.ToInt32(hdnstage1.Value) == 29)
                {
                    if (!string.IsNullOrEmpty(lblpriorstageQty.Text))
                        fabricQty = Convert.ToInt32(lblpriorstageQty.Text.Replace(",", ""));
                }
                else
                {
                    if (!string.IsNullOrEmpty(lblfabricQty.Text))
                        fabricQty = Convert.ToInt32(lblfabricQty.Text.Replace(",", ""));
                }

                int balQty = 0;
                if (!string.IsNullOrEmpty(lblbalanceinhouseqty.Text))
                    balQty = Convert.ToInt32(lblbalanceinhouseqty.Text.Replace(",", ""));

                decimal fabqty = (Convert.ToInt32(fabricQty) - Convert.ToInt32(balQty));
                decimal ResidualShak = Convert.ToDecimal(txtResidualShak.Text == "" ? 0 : Convert.ToDecimal(txtResidualShak.Text.Replace(",", "")));
                decimal GerigeShak = Convert.ToDecimal(txtGreigeshrk.Text == "" ? 0 : Convert.ToDecimal(txtGreigeshrk.Text.Replace(",", "")));
                if (Convert.ToInt32(hdnstage1.Value) == 29)
                {
                    Fabdet.QtyToOrder = lbltotalqtytosend.Text == "" ? 0 : (Convert.ToInt32(lbltotalqtytosend.Text.Replace(",", "")));
                }
                else
                {
                    Fabdet.QtyToOrder = Convert.ToInt32(Math.Round(fabqty, 0));
                }
                //if (Fabdet.PendingQtyToOrder <= 0)
                //{
                //    Fabdet.PendingQtyToOrder = 0;
                //}
                Fabdet.Flag = "RFD";
                Fabdet.FlagOption = "UPDATE";
                Fabdet.ColorPrint = lblcolor.Text;
                Fabdet.UserID = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                Fabdet.stage1 = Convert.ToInt32(hdnstage1.Value);
                Fabdet.stage2 = Convert.ToInt32(hdnstage2.Value);
                Fabdet.stage3 = Convert.ToInt32(hdnstage3.Value);
                Fabdet.stage4 = Convert.ToInt32(hdnstage4.Value);
                Fabdet.StyleID = Convert.ToInt32(hdnStyleID.Value);
                Fabdet.Currentstage = Convert.ToInt32(hdnCurrentstage.Value);
                Fabdet.periviousstgae = Convert.ToInt32(hdnperiviousstgae.Value);
                Fabdet.IsStyleSpecific = Convert.ToBoolean(hdnIsStyleSpecific.Value == "False" ? false : true);
                bool IsSave = fabobj.updatePendingDayedOrders(Fabdet);
                Qty = 0;
                CancelQty = 0;
            }
        }
        public void SaveEmbellishmentData()
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).Text = ((TextBox)x).Text.Replace(",", "");
                }
                else if (x is Label)
                {
                    ((Label)x).Text = ((Label)x).Text.Replace(",", "");
                }

            }
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            FabricGroupAdmin.FabricDetails Fabdet = new FabricGroupAdmin.FabricDetails();
            int Qty = 0;
            int CancelQty = 0;
            int HoldQty = 0;
            int CancelPoQty = 0;
            foreach (GridViewRow row in grdEmbellishment.Rows)
            {
                Label lblcolor = (Label)row.FindControl("lblcolor");
                Label lblcutwastgae = (Label)row.FindControl("lblcutwastgae");
                HiddenField hdnstage1 = (HiddenField)row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)row.FindControl("hdnstage4");
                HiddenField hdnCurrentstage = (HiddenField)row.FindControl("hdnCurrentstage");
                HiddenField hdnperiviousstgae = (HiddenField)row.FindControl("hdnperiviousstgae");
                HiddenField hdnIsStyleSpecific = (HiddenField)row.FindControl("hdnIsStyleSpecific");
                HiddenField hdnStyleID = (HiddenField)row.FindControl("hdnStyleID");
                HiddenField hdnfabricQuality = (HiddenField)row.FindControl("hdnfabricQuality");
                ds = fabobj.GetfabricViewdetails("Embellishment", "RERAISESUPPLIER", Convert.ToInt32(hdnfabricQuality.Value), 0, lblcolor.Text, "", 0, Convert.ToInt32(hdnCurrentstage.Value), Convert.ToInt32(hdnperiviousstgae.Value), Convert.ToBoolean(hdnIsStyleSpecific.Value), (Convert.ToBoolean(hdnIsStyleSpecific.Value) == true ? Convert.ToInt32(hdnStyleID.Value) : -1), Convert.ToInt32(hdnstage1.Value), Convert.ToInt32(hdnstage2.Value), Convert.ToInt32(hdnstage3.Value), Convert.ToInt32(hdnstage4.Value));
                bool hasRows = ds.Tables.Cast<DataTable>().Any(table => table.Rows.Count != 0);
                if (hasRows)
                {
                    dt = ds.Tables[0];
                }
                Fabdet.SendQty = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel)
                        {
                            Qty = Qty + Convert.ToInt32(dt.Rows[i]["ReceivedQty"].ToString());
                            Fabdet.SendQty = Fabdet.SendQty + Convert.ToInt32(dt.Rows[i]["SendQty"].ToString());
                            HoldQty = HoldQty + Convert.ToInt32(dt.Rows[i]["HoldQty"].ToString());
                        }
                        Decimal x = 0;
                        if (lblcutwastgae.Text == "")
                        {
                            x = 0;

                        }
                        else
                        {
                            x = Convert.ToDecimal(lblcutwastgae.Text);
                        }
                        bool IsSavecut = fabobj.UpdateCutwastage("UPDATECUTWASTAGE", dt.Rows[i]["PO_Number"].ToString(), x);
                    }
                    if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == FabricPOStatus.Cancel)
                    {
                        CancelQty = CancelQty + Convert.ToInt32(dt.Rows[i]["SendQty"].ToString());
                    }

                    CancelPoQty = CancelPoQty + Convert.ToInt32(dt.Rows[i]["CancelPoQty"].ToString());
                }
                Fabdet.SendQty = Fabdet.SendQty - CancelPoQty;
                TextBox txtResidualShak = (TextBox)row.FindControl("txtResidualShak");
                TextBox txtGreigeshrk = (TextBox)row.FindControl("txtGreigeshrk");
                Label lblbalanceinhouseqty = (Label)row.FindControl("lblbalanceinhouseqty");
                Label lblfabricQty = (Label)row.FindControl("lblfabricQty");
                Label lbltotalqtytosend = (Label)row.FindControl("lbltotalqtytosend");
                Label lblpriorstageQty = (Label)row.FindControl("lblpriorstageQty");

                Label PendingQtyToOrder = (Label)row.FindControl("lblFabQtyRemaning");

                HiddenField hdnadjustmentqty = (HiddenField)row.FindControl("hdnadjustmentqty");
                HiddenField hdnPreviousadjustmentqty = (HiddenField)row.FindControl("hdnPreviousadjustmentqty");
                hdnPreviousadjustmentqty.Value = hdnPreviousadjustmentqty.Value == "" ? "0" : hdnPreviousadjustmentqty.Value;
                hdnadjustmentqty.Value = hdnadjustmentqty.Value == "" ? "0" : hdnadjustmentqty.Value;

                Fabdet.FabricQualityID = (Convert.ToInt32(hdnfabricQuality.Value));
                Fabdet.ResidualShrinkage = (txtResidualShak.Text == "" ? 0 : (float)Convert.ToDouble(txtResidualShak.Text.Replace(",", "")));
                Fabdet.GreigedShrinkage = (txtGreigeshrk.Text == "" ? 0 : (float)Convert.ToDouble(txtGreigeshrk.Text.Replace(",", "")));
                Fabdet.BalanceQty = (lblbalanceinhouseqty.Text == "" ? 0 : Convert.ToInt32(lblbalanceinhouseqty.Text.Replace(",", "")));
                // Redefine as per requirement
                Fabdet.PendingQtyToOrder = lblfabricQty.Text == "" ? 0 : (Convert.ToInt32(lblfabricQty.Text.Replace(",", "")) - (Fabdet.SendQty));
                // End
                //Fabdet.PendingQtyToOrder = lblpriorstageQty.Text == "" ? 0 : (Convert.ToInt32(lblpriorstageQty.Text.Replace(",", "")) - (Fabdet.SendQty));

                int fabricQty = 0;
                //if (!string.IsNullOrEmpty(lblpriorstageQty.Text))
                //    fabricQty = Convert.ToInt32(lblpriorstageQty.Text.Replace(",", ""));
                if (!string.IsNullOrEmpty(lblfabricQty.Text))
                    fabricQty = Convert.ToInt32(lblfabricQty.Text.Replace(",", ""));

                int balQty = 0;
                if (!string.IsNullOrEmpty(lblbalanceinhouseqty.Text))
                    balQty = Convert.ToInt32(lblbalanceinhouseqty.Text.Replace(",", ""));

                decimal fabqty = (Convert.ToInt32(fabricQty) - Convert.ToInt32(balQty));
                decimal ResidualShak = Convert.ToDecimal(txtResidualShak.Text == "" ? 0 : Convert.ToDecimal(txtResidualShak.Text.Replace(",", "")));
                decimal GerigeShak = Convert.ToDecimal(txtGreigeshrk.Text == "" ? 0 : Convert.ToDecimal(txtGreigeshrk.Text.Replace(",", "")));

                Fabdet.QtyToOrder = Convert.ToInt32(Math.Round(fabqty, 0));

                if (Fabdet.PendingQtyToOrder <= 0)
                {
                    Fabdet.PendingQtyToOrder = 0;
                }

                //commented as Per ravi shankar
                //Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder + CancelQty) - ((HoldQty + Fabdet.BalanceQty));
                if (hdnCurrentstage.Value != "1")
                {
                    Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder - (Convert.ToInt32(hdnPreviousadjustmentqty.Value)));
                }
                else
                {
                    Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder - (Convert.ToInt32(balQty) - Convert.ToInt32(hdnadjustmentqty.Value)));
                }


                Fabdet.Flag = "Embellishment";
                Fabdet.FlagOption = "UPDATE";
                Fabdet.ColorPrint = lblcolor.Text;
                Fabdet.UserID = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                Fabdet.stage1 = Convert.ToInt32(hdnstage1.Value);
                Fabdet.stage2 = Convert.ToInt32(hdnstage2.Value);
                Fabdet.stage3 = Convert.ToInt32(hdnstage3.Value);
                Fabdet.stage4 = Convert.ToInt32(hdnstage4.Value);
                Fabdet.StyleID = Convert.ToInt32(hdnStyleID.Value);
                Fabdet.Currentstage = Convert.ToInt32(hdnCurrentstage.Value);
                Fabdet.periviousstgae = Convert.ToInt32(hdnperiviousstgae.Value);
                Fabdet.IsStyleSpecific = Convert.ToBoolean(hdnIsStyleSpecific.Value == "False" ? false : true);
                bool IsSave = fabobj.updatePendingDayedOrders(Fabdet);
                Qty = 0;
            }
        }
        public void SaveEmbroideryData()
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    ((TextBox)x).Text = ((TextBox)x).Text.Replace(",", "");
                }
                else if (x is Label)
                {
                    ((Label)x).Text = ((Label)x).Text.Replace(",", "");
                }

            }
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            FabricGroupAdmin.FabricDetails Fabdet = new FabricGroupAdmin.FabricDetails();
            int Qty = 0;
            int CancelQty = 0;
            int HoldQty = 0;
            int CancelPoQty = 0;
            foreach (GridViewRow row in grdEmbroidery.Rows)
            {
                Label lblcolor = (Label)row.FindControl("lblcolor");
                Label lblcutwastgae = (Label)row.FindControl("lblcutwastgae");
                HiddenField hdnstage1 = (HiddenField)row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)row.FindControl("hdnstage4");
                HiddenField hdnCurrentstage = (HiddenField)row.FindControl("hdnCurrentstage");
                HiddenField hdnperiviousstgae = (HiddenField)row.FindControl("hdnperiviousstgae");
                HiddenField hdnIsStyleSpecific = (HiddenField)row.FindControl("hdnIsStyleSpecific");
                HiddenField hdnStyleID = (HiddenField)row.FindControl("hdnStyleID");
                HiddenField hdnadjustmentqty = (HiddenField)row.FindControl("hdnadjustmentqty");
                HiddenField hdnPreviousadjustmentqty = (HiddenField)row.FindControl("hdnPreviousadjustmentqty");
                hdnPreviousadjustmentqty.Value = hdnPreviousadjustmentqty.Value == "" ? "0" : hdnPreviousadjustmentqty.Value;
                hdnadjustmentqty.Value = hdnadjustmentqty.Value == "" ? "0" : hdnadjustmentqty.Value;
                HiddenField hdnfabricQuality = (HiddenField)row.FindControl("hdnfabricQuality");
                ds = fabobj.GetfabricViewdetails("Embroidery", "RERAISESUPPLIER", Convert.ToInt32(hdnfabricQuality.Value), 0, lblcolor.Text, "", 0, Convert.ToInt32(hdnCurrentstage.Value), Convert.ToInt32(hdnperiviousstgae.Value), Convert.ToBoolean(hdnIsStyleSpecific.Value), (Convert.ToBoolean(hdnIsStyleSpecific.Value) == true ? Convert.ToInt32(hdnStyleID.Value) : -1), Convert.ToInt32(hdnstage1.Value), Convert.ToInt32(hdnstage2.Value), Convert.ToInt32(hdnstage3.Value), Convert.ToInt32(hdnstage4.Value));
                bool hasRows = ds.Tables.Cast<DataTable>().Any(table => table.Rows.Count != 0);
                if (hasRows)
                {
                    dt = ds.Tables[0];
                }
                Fabdet.SendQty = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel)
                        {
                            Qty = Qty + Convert.ToInt32(dt.Rows[i]["ReceivedQty"].ToString());
                            Fabdet.SendQty = Fabdet.SendQty + Convert.ToInt32(dt.Rows[i]["SendQty"].ToString());
                            HoldQty = HoldQty + Convert.ToInt32(dt.Rows[i]["HoldQty"].ToString());
                        }
                        Decimal x = 0;
                        if (lblcutwastgae.Text == "")
                        {
                            x = 0;

                        }
                        else
                        {
                            x = Convert.ToDecimal(lblcutwastgae.Text);
                        }
                        bool IsSavecut = fabobj.UpdateCutwastage("UPDATECUTWASTAGE", dt.Rows[i]["PO_Number"].ToString(), x);
                    }
                    if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == FabricPOStatus.Cancel)
                    {
                        CancelQty = CancelQty + Convert.ToInt32(dt.Rows[i]["SendQty"].ToString());
                    }
                    CancelPoQty = CancelPoQty + Convert.ToInt32(dt.Rows[i]["CancelPoQty"].ToString());
                }
                Fabdet.SendQty = Fabdet.SendQty - CancelPoQty;
                TextBox txtResidualShak = (TextBox)row.FindControl("txtResidualShak");
                TextBox txtGreigeshrk = (TextBox)row.FindControl("txtGreigeshrk");
                Label lblbalanceinhouseqty = (Label)row.FindControl("lblbalanceinhouseqty");
                Label lblfabricQty = (Label)row.FindControl("lblfabricQty");
                Label lbltotalqtytosend = (Label)row.FindControl("lbltotalqtytosend");
                Label lblpriorstageQty = (Label)row.FindControl("lblpriorstageQty");

                Label PendingQtyToOrder = (Label)row.FindControl("lblFabQtyRemaning");


                Fabdet.FabricQualityID = (Convert.ToInt32(hdnfabricQuality.Value));
                Fabdet.ResidualShrinkage = (txtResidualShak.Text == "" ? 0 : (float)Convert.ToDouble(txtResidualShak.Text.Replace(",", "")));
                Fabdet.GreigedShrinkage = (txtGreigeshrk.Text == "" ? 0 : (float)Convert.ToDouble(txtGreigeshrk.Text.Replace(",", "")));
                Fabdet.BalanceQty = (lblbalanceinhouseqty.Text == "" ? 0 : Convert.ToInt32(lblbalanceinhouseqty.Text.Replace(",", "")));

                //Fabdet.PendingQtyToOrder = lblpriorstageQty.Text == "" ? 0 : (Convert.ToInt32(lblpriorstageQty.Text.Replace(",", "")) - (Fabdet.SendQty));
                // Redefine as per requirement
                Fabdet.PendingQtyToOrder = lblfabricQty.Text == "" ? 0 : (Convert.ToInt32(lblfabricQty.Text.Replace(",", "")) - (Fabdet.SendQty));
                // End
                int fabricQty = 0;
                //if (!string.IsNullOrEmpty(lblpriorstageQty.Text))
                //    fabricQty = Convert.ToInt32(lblpriorstageQty.Text.Replace(",", ""));
                if (!string.IsNullOrEmpty(lblfabricQty.Text))
                    fabricQty = Convert.ToInt32(lblfabricQty.Text.Replace(",", ""));

                int balQty = 0;
                if (!string.IsNullOrEmpty(lblbalanceinhouseqty.Text))
                    balQty = Convert.ToInt32(lblbalanceinhouseqty.Text.Replace(",", ""));

                decimal fabqty = (Convert.ToInt32(fabricQty) - Convert.ToInt32(balQty));
                decimal ResidualShak = Convert.ToDecimal(txtResidualShak.Text == "" ? 0 : Convert.ToDecimal(txtResidualShak.Text.Replace(",", "")));
                decimal GerigeShak = Convert.ToDecimal(txtGreigeshrk.Text == "" ? 0 : Convert.ToDecimal(txtGreigeshrk.Text.Replace(",", "")));

                Fabdet.QtyToOrder = Convert.ToInt32(Math.Round(fabqty, 0));

                if (Fabdet.PendingQtyToOrder <= 0)
                {
                    Fabdet.PendingQtyToOrder = 0;
                }   //commented as Per ravi shankar
                //Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder + CancelQty) - ((HoldQty + Fabdet.BalanceQty));
                if (hdnCurrentstage.Value != "1")
                {
                    Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder - (Convert.ToInt32(hdnPreviousadjustmentqty.Value)));
                }
                else
                {
                    Fabdet.PendingQtyToOrder = (Fabdet.PendingQtyToOrder - (Convert.ToInt32(balQty) - Convert.ToInt32(hdnadjustmentqty.Value)));
                }

                Fabdet.Flag = "Embroidery";
                Fabdet.FlagOption = "UPDATE";
                Fabdet.ColorPrint = lblcolor.Text;
                Fabdet.UserID = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                Fabdet.stage1 = Convert.ToInt32(hdnstage1.Value);
                Fabdet.stage2 = Convert.ToInt32(hdnstage2.Value);
                Fabdet.stage3 = Convert.ToInt32(hdnstage3.Value);
                Fabdet.stage4 = Convert.ToInt32(hdnstage4.Value);
                Fabdet.StyleID = Convert.ToInt32(hdnStyleID.Value);
                Fabdet.Currentstage = Convert.ToInt32(hdnCurrentstage.Value);
                Fabdet.periviousstgae = Convert.ToInt32(hdnperiviousstgae.Value);
                Fabdet.IsStyleSpecific = Convert.ToBoolean(hdnIsStyleSpecific.Value == "False" ? false : true);
                bool IsSave = fabobj.updatePendingDayedOrders(Fabdet);
                Qty = 0;
            }
        }
        #endregion

        public void Margecol_Gerige()
        {
            DataTable dt = fabobj.GetfabricViewdetails("GRIEGE", "GETCOUNTSUPPLIER").Tables[0];
            if (dt.Rows.Count > 0)
            {
                SupplierCount = Convert.ToInt32(dt.Rows[0]["MOST_FREQUENT"]);
            }
        }
        public void Margecol_Finishing()
        {
            // below is comented on 21/09/2021 by sanjeev becouse of no use
            //DataTable dt = fabobj.GetfabricViewdetails("FINISHING", "GETCOUNTSUPPLIER").Tables[0];
            //if (dt.Rows.Count > 0)
            //{
            //    SupplierCount = Convert.ToInt32(dt.Rows[0]["MOST_FREQUENT"]);
            //}
        }


        protected void grdgreigerasiepo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int SupplierMasterID = 0;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                //  headerRow1.Attributes.Add("class", "HeaderClass");
                headerRow2.Attributes.Add("class", "HeaderClass");

                TableCell HeaderCell = new TableCell();

                HeaderCell = new TableCell();
                HeaderCell.Text = "<Table><tr><td colspan='3' style='border:0px'>Fabric Quality (GSM) C&C Width<br>Color/Print (Unit)</td></tr><tr><TD>Current Stage</TD><TD>Previous Stage</TD><TD>Style Specific</TD></tr></table>";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("min-width", "180px");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Style No. (Serial No.)";
                HeaderCell.Style.Add("min-width", "150px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "<Table><tr><td style='border:0px'>Overall to order/send</td></tr><tr><TD>required qty</TD></tr></table>";
                HeaderCell.Style.Add("Width", "60px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);



                HeaderCell = new TableCell();
                HeaderCell.Text = "Balance <br>In House ";
                HeaderCell.Style.Add("Width", "40px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Quantity To Order ";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Visible = false;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Quote 1 (Rate & Time)<br>Supplier Name<br>Lead Time";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("Width", "160px");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quote 2 (Rate & Time)<br>Supplier Name<br>Lead Time";
                HeaderCell.Style.Add("Width", "160px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quote 3 (Rate & Time)<br>Supplier Name<br>Lead Time";
                HeaderCell.Style.Add("Width", "160px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Number";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Supplier Name";
                HeaderCell.Style.Add("min-width", "130px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Rcvd. Qty. ";
                HeaderCell.Style.Add("Width", "60px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Revise PO";
                HeaderCell.Attributes.Add("class", "widthAction");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Qty. to Raise PO";
                HeaderCell.Attributes.Add("class", "widthPending");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                grdgreigerasiepo.Controls[0].Controls.AddAt(0, headerRow2);
                //  grdgreigerasiepo.Controls[0].Controls.AddAt(0, headerRow1);



            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataTable dtForQuotCheck = new DataTable();
                DataTable dtfabQty = new DataTable();
                HiddenField hdnfabricQuality = (HiddenField)e.Row.FindControl("hdnfabricQuality");
                Label lblfabricorderavg = (Label)e.Row.FindControl("lblfabricorderavg");
                Label lblfabricorderavg2 = (Label)e.Row.FindControl("lblfabricorderavg2");
                Label lblbalanceinhouseqty = (Label)e.Row.FindControl("lblbalanceinhouseqty");
                //Label lblstyleno = (Label)e.Row.FindControl("lblstyleno");
                Label lblFabQtyRemaning = (Label)e.Row.FindControl("lblFabQtyRemaning");
                Label lblFabQtyRemaning2 = (Label)e.Row.FindControl("lblFabQtyRemaning2");
                Label lblTotalFabRequired = (Label)e.Row.FindControl("lblTotalFabRequired");


                Label lblQouteRate_1 = (Label)e.Row.FindControl("lblQouteRate_1");
                Label lblQouteTime_1 = (Label)e.Row.FindControl("lblQouteTime_1");
                Label lblQouteSupplierName_1 = (Label)e.Row.FindControl("lblQouteSupplierName_1");
                Label lblQouteLeadDays_1 = (Label)e.Row.FindControl("lblQouteLeadDays_1");


                Label lblQouteRate_2 = (Label)e.Row.FindControl("lblQouteRate_2");
                Label lblQouteTime_2 = (Label)e.Row.FindControl("lblQouteTime_2");
                Label lblQouteSupplierName_2 = (Label)e.Row.FindControl("lblQouteSupplierName_2");
                Label lblQouteLeadDays_2 = (Label)e.Row.FindControl("lblQouteLeadDays_2");


                Label lblQouteRate_3 = (Label)e.Row.FindControl("lblQouteRate_3");
                Label lblQouteTime_3 = (Label)e.Row.FindControl("lblQouteTime_3");
                Label lblQouteSupplierName_3 = (Label)e.Row.FindControl("lblQouteSupplierName_3");
                Label lblQouteLeadDays_3 = (Label)e.Row.FindControl("lblQouteLeadDays_3");

                Label pendingQtyinorder = (Label)e.Row.FindControl("pendingQtyinorder");
                Label lblcolor = (Label)e.Row.FindControl("lblcolor");
                Label recqty = (Label)e.Row.FindControl("recqty");
                Button btnrapo = (Button)e.Row.FindControl("btnrapo");
                TextBox txtGreige_Sh = (TextBox)e.Row.FindControl("txtGreige_Sh");
                TextBox txtResidualSh = (TextBox)e.Row.FindControl("txtResidualSh");
                HtmlGenericControl divraise = e.Row.FindControl("divraise") as HtmlGenericControl;
                Label lblresidualshrink = (Label)e.Row.FindControl("lblresidualshrink");
                CheckBox chkApplyResShrinkage = (CheckBox)e.Row.FindControl("chkApplyResShrinkage");
                GridView grdstylenumber = (GridView)e.Row.FindControl("grdstylenumber");

                Label lblcutwastgae = (Label)e.Row.FindControl("lblcutwastgae");
                HiddenField hdnstage1 = (HiddenField)e.Row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)e.Row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)e.Row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)e.Row.FindControl("hdnstage4");

                HiddenField hdnadjustmentqty = (HiddenField)e.Row.FindControl("hdnadjustmentqty");
                Label lblBalanceTooltip = (Label)e.Row.FindControl("lblBalanceTooltip");
                if (lblbalanceinhouseqty.Text != "")
                {
                    //if (hdnadjustmentqty.Value != "0")
                    //lblbalanceinhouseqty.Attributes.Add("title", "<span style=color:black>" + "Adjustment qty from further stage:" + "</span> <span style=color:black>" + hdnadjustmentqty.Value + "</span>");
                    if (hdnadjustmentqty.Value != "0" && hdnadjustmentqty.Value != "")
                    {
                        lblBalanceTooltip.Text = "Adjustment qty from further stage: <span style='color:yellow'>" + hdnadjustmentqty.Value.ToString() + "</span>";
                        lblBalanceTooltip.CssClass = "TooltipTxt";
                    }
                }

                //btnrapo.Attributes.Add("OnClientClick", "javascript:ShowpurchasedSupplierForm(this," + hdnfabricQuality.Value + "); return false;");
                txtGreige_Sh.Attributes.Add("onchange", "javascript:UpdateGrige(this," + hdnfabricQuality.Value + ");");
                txtResidualSh.Attributes.Add("onchange", "javascript:showhideresidualshrinke(this);");


                Label lblFabricQuality = (Label)e.Row.FindControl("lblFabricQuality");
                Label lblgsm = (Label)e.Row.FindControl("lblgsm");
                Label lblcountconstraction = (Label)e.Row.FindControl("lblcountconstraction");
                Label lblwidth = (Label)e.Row.FindControl("lblwidth");
                Label lblrequiredqty = (Label)e.Row.FindControl("lblrequiredqty");
                string ccn = "<span style='color:blue;'>" + lblFabricQuality.Text + "</span><span style='color:gray;'> " + lblgsm.Text + " " + lblcountconstraction.Text + " " + lblwidth.Text + "</span> ";

                string geriege = "0";
                string Residual = "0";
                string cutwastage = "0";
                geriege = txtGreige_Sh.Text;

                if (chkApplyResShrinkage.Checked)
                {
                    Residual = txtResidualSh.Text;
                }

                ds = fabobj.GetfabricViewdetails("GRIEGE", "STYLE", Convert.ToInt32(hdnfabricQuality.Value), 0, lblcolor.Text, "", 0, -1, -1, Convert.ToBoolean(0), -1, Convert.ToInt32(hdnstage1.Value));
                dt = ds.Tables[1];
                dtfabQty = ds.Tables[2];
                if (dt.Rows.Count > 0)
                {
                    grdstylenumber.DataSource = dt;
                    grdstylenumber.DataBind();

                    //  MergeRowsnew(grdstylenumber);
                }
                // lblfabricorderavg.Text = ds.Tables[0].Rows.Count > 0 ? (ds.Tables[0].Rows[0]["FabricQty"].ToString() == "0" ? "" : ds.Tables[0].Rows[0]["FabricQty"].ToString()) : "";
                // lblfabricorderavg2.Text = ds.Tables[0].Rows.Count > 0 ? (ds.Tables[0].Rows[0]["FabricQty"].ToString() == "0" ? "" : Convert.ToDecimal(ds.Tables[0].Rows[0]["FabricQty"].ToString()).ToString("N0")) : "";
                if (dtfabQty.Rows.Count > 0)
                {
                    //lblbalanceinhouseqty.Text = dtfabQty.Rows[0]["BalanceinHouseQty"].ToString() == "0" ? "" : dtfabQty.Rows[0]["BalanceinHouseQty"].ToString();
                    lblFabQtyRemaning.Text = dtfabQty.Rows[0]["RemainingFabQty"].ToString() == "0" ? "" : dtfabQty.Rows[0]["RemainingFabQty"].ToString();
                    lblfabricorderavg.Text = dtfabQty.Rows[0]["TotalReuiredFabQty"].ToString() == "" ? "" : Convert.ToDecimal(dtfabQty.Rows[0]["TotalReuiredFabQty"].ToString()).ToString("N0");
                    lblfabricorderavg2.Text = dtfabQty.Rows[0]["TotalReuiredFabQty"].ToString() == "" ? "" : Convert.ToDecimal(dtfabQty.Rows[0]["TotalReuiredFabQty"].ToString()).ToString("N0");
                    lblFabQtyRemaning2.Text = dtfabQty.Rows[0]["TotalReuiredFabQty"].ToString() == "" ? "" : Convert.ToDecimal(dtfabQty.Rows[0]["TotalReuiredFabQty"].ToString()).ToString("N0");
                    lblTotalFabRequired.Text = dtfabQty.Rows[0]["TotalReuiredFabQty"].ToString() == "0" ? "" : dtfabQty.Rows[0]["TotalReuiredFabQty"].ToString();
                    lblresidualshrink.Text = dtfabQty.Rows[0]["Residual_Sh"].ToString() == "0" ? "" : dtfabQty.Rows[0]["Residual_Sh"].ToString();
                    lblcutwastgae.Text = dtfabQty.Rows[0]["CuttingWastage"].ToString() == "0" ? "" : dtfabQty.Rows[0]["CuttingWastage"].ToString();
                    cutwastage = lblcutwastgae.Text;
                    lblrequiredqty.Text = dtfabQty.Rows[0]["RequiredQty"].ToString() == "0" ? "" : Convert.ToDecimal(dtfabQty.Rows[0]["RequiredQty"].ToString()).ToString("N0");
                }
                if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager) || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_TopManagement_Manager))
                {
                    //lblfabricorderavg2.Attributes.Add("onclick", "OpenWastageAdmin('" + 1 + "','" + hdnfabricQuality.Value + "','" + "FabricDetails" + "');");
                    lblrequiredqty.Attributes.Add("onclick", "OpenWastageAdmin('" + 1 + "','" + hdnfabricQuality.Value + "','" + "FabricDetails" + "','" + lblcutwastgae.Text + "');");
                }
                //if (lblFabQtyRemaning2.Text != "")
                //{
                //    decimal _cutwastage = lblcutwastgae.Text == "" ? 0 : Convert.ToDecimal(lblcutwastgae.Text);
                //    //   decimal Totalre = Convert.ToDecimal(lblFabQtyRemaning2.Text) + (Convert.ToDecimal(lblFabQtyRemaning2.Text) * _cutwastage) / Convert.ToDecimal(100);
                //    decimal Totalre = ((Convert.ToDecimal(lblFabQtyRemaning2.Text) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - (Convert.ToDecimal(_cutwastage))));

                //    lblFabQtyRemaning2.Text = Math.Round(Totalre, 0).ToString("N0");



                //}
                //if (dt.Rows.Count > 0)
                //{
                //    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        sb.Append("<table style='width:60%;float: left;'>");
                //        sb.AppendFormat("<tr>");
                //        string[] screenShotUrlCollection = dt.Rows[i]["SerialNumber"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                //        sb.AppendFormat("<td rowspan='"+screenShotUrlCollection.Length+"'>" + dt.Rows[i]["StyleNumber"].ToString() + "</td>");
                //        sb.Append("</table>");
                //        foreach (string value in screenShotUrlCollection)
                //        {
                //            sb.Append("<table style='width:38%;float: right;'>");
                //            sb.AppendFormat("<tr>");
                //            sb.AppendFormat("<td>" + value.Replace("(", "").Replace(")", "") + "</td>");
                //            sb.AppendFormat("</tr>");
                //            sb.Append("</table>"); 
                //        }

                //    }

                //    e.Row.Cells[1].Text = sb.ToString();

                //}
                ds = fabobj.GetfabricViewdetails("GRIEGE", "GETTOP3SUPPLIER_GRIGE", Convert.ToInt32(hdnfabricQuality.Value), 3);
                dt = ds.Tables[0];
                dtForQuotCheck = ds.Tables[2];
                if (dtForQuotCheck.Rows.Count > 0)
                {

                    if (dt.Rows.Count == 3)
                    {
                        lblQouteRate_1.Text = "<span style='color: green; font-size: 11px;padding-right:2px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[0]["QuotedLandedRate"].ToString() + " " + "</span><span style='color:gray'>(" + dt.Rows[0]["times"].ToString() + ")</span>";
                        lblQouteSupplierName_1.Text = dt.Rows[0]["SupplierName"].ToString();
                        lblQouteLeadDays_1.Text = dt.Rows[0]["LeadTimes"].ToString() + " (<span style='color:gray'>" + "Days" + "</span>)";

                        lblQouteRate_2.Text = "<span style='color: green; font-size: 11px;padding-right:2px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[1]["QuotedLandedRate"].ToString() + " " + " </span><span style='color:gray'>(" + dt.Rows[1]["times"].ToString() + ")</span>";
                        lblQouteSupplierName_2.Text = dt.Rows[1]["SupplierName"].ToString();
                        lblQouteLeadDays_2.Text = dt.Rows[1]["LeadTimes"].ToString() + " (<span style='color:gray'>" + "Days" + "</span>)";

                        lblQouteRate_3.Text = "<span style='color: green; font-size: 11px;padding-right:2px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[2]["QuotedLandedRate"].ToString() + " " + " </span><span style='color:gray'>(" + dt.Rows[2]["times"].ToString() + ")</span>";
                        lblQouteSupplierName_3.Text = dt.Rows[2]["SupplierName"].ToString();
                        lblQouteLeadDays_3.Text = dt.Rows[2]["LeadTimes"].ToString() + " (<span style='color:gray'>" + "Days" + "</span>)";
                        IcheckHideCol = 1;
                    }
                    if (dt.Rows.Count == 2)
                    {

                        lblQouteRate_1.Text = "<span style='color: green; font-size: 12px;padding-right:2px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[0]["QuotedLandedRate"].ToString() + " " + "</span><span style='color:gray'>(" + dt.Rows[0]["times"].ToString() + ")</span>";
                        lblQouteSupplierName_1.Text = dt.Rows[0]["SupplierName"].ToString();
                        lblQouteLeadDays_1.Text = dt.Rows[0]["LeadTimes"].ToString() + " (<span style='color:gray'>" + "Days" + "</span>)";

                        lblQouteRate_2.Text = "<span style='color: green; font-size: 11px;position:relative;top:1px;padding-right:2px'>₹</span><span style='color:#000'>" + dt.Rows[1]["QuotedLandedRate"].ToString() + " " + "</span><span style='color:gray'>(" + dt.Rows[1]["times"].ToString() + ")</span>";
                        lblQouteSupplierName_2.Text = dt.Rows[1]["SupplierName"].ToString();
                        lblQouteLeadDays_2.Text = dt.Rows[1]["LeadTimes"].ToString() + " (<span style='color:gray'>" + "Days" + "</span>)";
                        //if (IcheckHideCol <= 0)
                        //{
                        //  grdgreigerasiepo.Columns[9].Visible = false;
                        //  grdgreigerasiepo.HeaderRow.Cells[9].ColumnSpan = 13;
                        //}


                    }
                    if (dt.Rows.Count == 1)
                    {

                        lblQouteRate_1.Text = "<span style='color: green; font-size: 11px;padding-right:2px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[0]["QuotedLandedRate"].ToString() + " " + "</span><span style='color:gray'>(" + dt.Rows[0]["times"].ToString() + ")</span>";
                        lblQouteSupplierName_1.Text = dt.Rows[0]["SupplierName"].ToString();
                        lblQouteLeadDays_1.Text = dt.Rows[0]["LeadTimes"].ToString() + " (<span style='color:gray'>" + "Days" + "</span>)";
                        //if (IcheckHideCol <= 0)
                        //{
                        //  grdgreigerasiepo.Columns[8].Visible = false;
                        //  grdgreigerasiepo.Columns[9].Visible = false;
                        //  GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                        //  headerRow1.Cells[8].ColumnSpan = 12;
                        //}
                        //IcheckHideCol = 1;

                    }
                }
                else
                {
                    divraise.Attributes.Add("Class", "HideRaisebtn");
                }
                ds = fabobj.GetfabricViewdetails("GRIEGE", "RERAISESUPPLIER", Convert.ToInt32(hdnfabricQuality.Value));
                dt = ds.Tables[0];
                DataTable dtremaningqty = ds.Tables[1];
                if (dtremaningqty.Rows.Count > 0)
                {
                    if (dtremaningqty.Rows[0]["RemaningQty"].ToString() != "")
                    {
                        pendingQtyinorder.Text = Convert.ToDecimal(dtremaningqty.Rows[0]["RemaningQty"].ToString()).ToString("N0");
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    // pendingQtyinorder.Text = Convert.ToDecimal(dt.Rows[0]["RemaningQty"].ToString()).ToString("N0");
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                        {
                            sb.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #e2dddd99;'><span class='per'>" + dt.Rows[i]["PO_Number"].ToString() + "</span></td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[10].Text = sb.ToString();
                }
                if (dt.Rows.Count > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                        {
                            sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + dt.Rows[i]["SupplierName"].ToString() + "</td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[11].Text = sb.ToString();
                }
                if (dt.Rows.Count > 0)
                {
                    int HoldQty = 0;
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                        {

                            string Qty = "";
                            if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                            {
                                Qty = Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()).ToString("N0");
                            }

                            HoldQty = HoldQty + Convert.ToInt32(dt.Rows[i]["HoldQty"].ToString());

                            sb.AppendFormat("<tr><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + Qty + "</td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[12].Text = sb.ToString();
                    pendingQtyinorder.ToolTip = "Hold Qty: " + HoldQty.ToString();
                }
                decimal Qtys = 0;
                if (dt.Rows.Count > 0)
                {

                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string Qty = "";
                        MasterPoID = Convert.ToInt32(dt.Rows[i]["MasterPO_Id"].ToString());
                        SupplierMasterID = Convert.ToInt32(dt.Rows[i]["SupplierID"].ToString());

                        if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                        {
                            Qty = Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()).ToString("N0");
                        }

                        //sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #999;width: 77px;'>" + "<div class='btnrepo tooltip' onclick=ShowpurchasedSupplierFormReraise('" + hdnfabricQuality.Value + "','" + SupplierMasterID + "','" + MasterPoID + "'); > Re.PO<span class='tooltiptext'>You don't have permission</span></div><img src='../../images/del-butt.png' /></td></tr>");
                        if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 1 || Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 2)
                        {


                            string Status = "";
                            if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 1)
                            {
                                Status = "Canceled";
                            }
                            else if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 2)
                            {
                                Status = "closed";
                            }
                            if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 40px;'>" + "<div style='Color:grey' class=''  > " + Status + "</div></td></tr>");
                            }
                        }
                        else
                        {
                            if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager) || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_TopManagement_Manager))
                            {
                                //sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div class='btnrepo' onclick=ShowpurchasedSupplierFormReraise('" + hdnfabricQuality.Value + "','" + SupplierMasterID + "','" + lblcolor.Text + "'); > Re.PO</div><img src='../../images/del-butt.png' /></td></tr>");
                                if (Residual == "")
                                    Residual = "0";

                                if (geriege == "")
                                    geriege = "0";

                                if (cutwastage == "")
                                    cutwastage = "0";

                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 40px;'>" + "<div class='btnrepo' onclick='ShowpurchasedSupplierFormReraise(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "&apos;" + lblcolor.Text + "&apos;" + "," + geriege + "," + Residual + "," + cutwastage + "," + "&apos;" + hdnfabricQuality.ClientID + "&apos;" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + ");' > Re.PO</div></td></tr>");
                            }
                            else
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 40px;'>" + "<div style='Color:grey' class='btnrepo tooltip'  > Re.PO</div></td></tr>");
                            }
                        }
                    }

                    sb.Append("</table>");
                    e.Row.Cells[13].Text = sb.ToString();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != 1)
                        {
                            if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                            {
                                Qtys += Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString());
                            }
                        }
                    }
                    recqty.Text = Math.Round(Qtys, 0).ToString();

                }
                decimal Remaning = lblFabQtyRemaning2.Text == "" ? 0 : Convert.ToDecimal(lblFabQtyRemaning2.Text);
                decimal balanceInhOuse = lblbalanceinhouseqty.Text == "" ? 0 : Convert.ToDecimal(lblbalanceinhouseqty.Text);
                if (lblFabQtyRemaning2.Text != "")
                {
                    decimal _cutwastage = lblcutwastgae.Text == "" ? 0 : Convert.ToDecimal(lblcutwastgae.Text);
                    decimal Totalre = ((Convert.ToDecimal(lblFabQtyRemaning2.Text) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - (Convert.ToDecimal(_cutwastage))));
                    //decimal Totalre = Convert.ToDecimal(lblFabQtyRemaning2.Text) + (Convert.ToDecimal(lblFabQtyRemaning2.Text) * _cutwastage) / Convert.ToDecimal(100);
                    // lblFabQtyRemaning2.Text = Math.Round(Totalre, 0).ToString("N0");

                    //decimal pendingqty = (Remaning) - (Convert.ToDecimal((Math.Round(Convert.ToDecimal(Qtys), 0)) + Convert.ToDecimal(balanceInhOuse)));
                    //pendingQtyinorder.Text = Convert.ToInt32(Math.Round(pendingqty, 0)).ToString("N0");
                }
                if (pendingQtyinorder.Text != "")
                {
                    if (pendingQtyinorder.Text.Replace(",", "") == "0")
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                        pendingQtyinorder.Text = "";
                    }
                    else if (Convert.ToDouble(pendingQtyinorder.Text.Replace(",", "")) <= 0)
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                        //pendingQtyinorder.Text = "";
                    }
                    else
                    {
                        if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager) || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_TopManagement_Manager))
                        {
                            divraise.Attributes.Add("onclick", "ShowpurchasedSupplierForm('" + divraise.ClientID + "','" + hdnfabricQuality.Value + "','" + SupplierMasterID + "','" + 0 + "','" + lblcolor.Text + "','" + txtGreige_Sh.Text + "','" + Residual + "','" + cutwastage + "','" + hdnstage1.Value + "','" + hdnstage2.Value + "','" + hdnstage3.Value + "','" + hdnstage4.Value + "')");
                        }
                        else
                        {
                            //divraise.Attributes.Add("onclick", "alert('You do not have permission');");
                            divraise.Attributes.Add("onclick", "PermissionAlertMsg();");
                            //  divraise.Attributes.Add("style", "Color:grey");
                        }
                    }
                }
                else
                {
                    divraise.Attributes.Add("Class", "HideRaisebtn");
                    pendingQtyinorder.Text = "";
                }
                HtmlAnchor lnkProductionpopup = e.Row.FindControl("lnkProductionpopup") as HtmlAnchor;
                DataSet dsSupplier = new DataSet();
                DataTable dtsupplierQuoted = new DataTable();
                DataTable dtSystemQuoted = new DataTable();
                dsSupplier = fabobj.GetfabricViewdetails("GRIEGE", "GETTOP3SUPPLIER_GRIGE", Convert.ToInt32(hdnfabricQuality.Value), 100, lblcolor.Text);
                dtsupplierQuoted = dsSupplier.Tables[0];
                dtSystemQuoted = dsSupplier.Tables[1];

                if (dtsupplierQuoted.Rows.Count > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table class='topsupplier'>");
                    sb.AppendFormat("<tr><th colspan='5' style='background: #536EA9 !important; color: #fff !important;font-size: 11px !important;'>All Quotations<span style='float:right;padding-right:10px;cursor: pointer;color:#fff' titel='Close' onclick='HideSupplierDiv();'>X</span></th></tr>");
                    sb.AppendFormat("<tr><th>Fabric Quality (GSM) C&C Width<br> Color/Print</th><th style='display:none;'>Griege Sh. (%)</th><th> Best Quote For Ref.</th><th>Supplier Name</th><th>Quoted Rate &  Lead Time</th></tr>");

                    int x = 0;
                    for (int i = 0; i < dtsupplierQuoted.Rows.Count; i++)
                    {

                        sb.Append("<tr>");
                        if (x <= 0)
                        {
                            System.Text.StringBuilder sbfab = new System.Text.StringBuilder();
                            sb.AppendFormat("<td rowspan='" + dtsupplierQuoted.Rows.Count + "'>");

                            sbfab.Append("<table style='border: none;' class='topsupplier' cellspacing='0' cellpadding='0'>");

                            sbfab.Append("<tr>");
                            sbfab.Append("<TD style='border: none;'>");
                            //sbfab.Append(dtsupplierQuoted.Rows[0]["FabricDetails"].ToString());
                            sbfab.Append(ccn);

                            sbfab.Append("</TD>");
                            sbfab.Append("</tr>");

                            sbfab.Append("<tr>");
                            sbfab.Append("<TD style='border: none;'>");
                            sbfab.Append(lblcolor.Text.Trim());
                            sbfab.Append("</TD>");
                            sbfab.Append("</tr>");

                            sbfab.Append("</table>");
                            sb.AppendFormat(sbfab.ToString());
                            sb.AppendFormat("</td>");

                        }
                        if (x <= 0)
                        {
                            sb.AppendFormat("<td style='display:none;' rowspan='" + dtsupplierQuoted.Rows.Count + "'>");
                            sb.AppendFormat(dtsupplierQuoted.Rows[0]["GriegeShrinkage"].ToString());
                            sb.AppendFormat("</td>");
                        }
                        if (dtSystemQuoted.Rows.Count > 0)
                        {
                            if (x <= 0)
                            {
                                sb.AppendFormat("<td style='background: lightgreen;' rowspan='" + dtsupplierQuoted.Rows.Count + "'>");
                                sb.AppendFormat("<span style='color: green; font-size: 11px;'><span>&#8377;</span> </span><span style='color:#000'>" + dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString() + "</span>");
                                sb.AppendFormat("</td>");
                            }
                        }

                        sb.AppendFormat("<td>");
                        string dd = dtsupplierQuoted.Rows[i]["Create_Update_Date"].ToString() == "" ? "" : Convert.ToDateTime(dtsupplierQuoted.Rows[i]["Create_Update_Date"].ToString()).ToString("dd MMM yyyy");
                        sb.AppendFormat(dtsupplierQuoted.Rows[i]["SupplierName"].ToString() + " " + "(" + dd + ")");
                        sb.AppendFormat("</td>");

                        string days = "";
                        if (dtsupplierQuoted.Rows[i]["LeadTimes"].ToString() != "" && dtsupplierQuoted.Rows[i]["LeadTimes"].ToString() != "0")
                        {
                            days = "(" + dtsupplierQuoted.Rows[i]["LeadTimes"].ToString() + " Days)";
                        }
                        string str = "";
                        if (dtsupplierQuoted.Rows[i]["QuotedLandedRate"].ToString() != "0")
                            str = "<span style='color: green; font-size: 12px;'>₹ </span><span style='color:#000'>" + dtsupplierQuoted.Rows[i]["QuotedLandedRate"].ToString() + "</span>";
                        else
                            str = "<span style='color: green; font-size: 12px;'> </span>";

                        sb.AppendFormat("<td>");
                        sb.AppendFormat(str + "   " + days);

                        sb.AppendFormat("</td>");


                        x = x + 1;

                        sb.Append("</tr>");
                    }

                    sb.Append("</table>");
                    //lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier(\"" + sb.ToString() + "\")");
                    lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier2(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "'" + lblcolor.Text + "'" + "," + geriege + "," + Residual + "," + cutwastage + "," + "'" + hdnfabricQuality.ClientID + "'" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + "," + "'" + ccn.Replace("'", "") + "'" + ");");
                }
                else
                {
                    //lnkProductionpopup.Style.Add("display", "none;");
                    //lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier(\"" + "empty" + "\")");
                    lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier2(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "'" + lblcolor.Text + "'" + "," + geriege + "," + Residual + "," + cutwastage + "," + "'" + hdnfabricQuality.ClientID + "'" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + "," + "'" + ccn.Replace("'", "") + "'" + ");");
                }

            }
        }
        public string RemoveAt(string s, int index)
        {
            return s.Remove(index, 1);
        }
        protected void grdfinishing_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int SupplierMasterID = 0;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                //  headerRow1.Attributes.Add("class", "HeaderClass");
                headerRow2.Attributes.Add("class", "HeaderClass");

                TableCell HeaderCell = new TableCell();

                HeaderCell = new TableCell();
                HeaderCell.Text = "<Table><tr><td colspan='3' style='border:0px;'>Fabric Quality (GSM) C&C Width<br>Color/Print (Unit)</td></tr><tr><TD>Current Stage</TD><TD>Previous Stage</TD><TD>Style Specific</TD></tr></table>";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("min-width", "200px");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Style No. (Serial No.)";
                HeaderCell.Style.Add("min-width", "150px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "<Table><tr><td style='border:0px'>Overall to order/send</td></tr><tr><TD>required qty</TD></tr></table>";
                HeaderCell.Style.Add("Width", "60px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Balance <br>In House ";
                HeaderCell.Style.Add("Width", "40px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Quantity To Order ";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;

                HeaderCell.Visible = false;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quote 1 (Rate & Time)<br>Supplier Name<br>Lead Time";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("Width", "150px");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quote 2 (Rate & Time)<br>Supplier Name<br>Lead Time";
                HeaderCell.Style.Add("Width", "160px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quote 3 (Rate & Time)<br>Supplier Name<br>Lead Time";
                HeaderCell.Style.Add("Width", "150px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Number";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Supplier Name";
                HeaderCell.Style.Add("min-width", "120px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Rcvd. Qty. ";
                HeaderCell.Style.Add("min-width", "50px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Revise PO";
                HeaderCell.Attributes.Add("class", "widthAction");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Qty. to Raise PO";
                HeaderCell.Attributes.Add("class", "widthPending");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                grdfinishing.Controls[0].Controls.AddAt(0, headerRow2);
                //   grdfinishing.Controls[0].Controls.AddAt(0, headerRow1);



            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataTable dtForQuotCheck = new DataTable();
                DataTable dtfabQty = new DataTable();
                Label recqty = (Label)e.Row.FindControl("recqty");
                HiddenField hdnfabricQuality = (HiddenField)e.Row.FindControl("hdnfabricQuality");
                Label lblfabricorderavg = (Label)e.Row.FindControl("lblfabricorderavg");
                Label lblfabricorderavg2 = (Label)e.Row.FindControl("lblfabricorderavg2");
                Label lblbalanceinhouseqty = (Label)e.Row.FindControl("lblbalanceinhouseqty");
                //Label lblstyleno = (Label)e.Row.FindControl("lblstyleno");
                Label lblFabQtyRemaning = (Label)e.Row.FindControl("lblFabQtyRemaning");
                Label lblFabQtyRemaning2 = (Label)e.Row.FindControl("lblFabQtyRemaning2");
                Label lblTotalFabRequired = (Label)e.Row.FindControl("lblTotalFabRequired");


                Label lblQouteRate_1 = (Label)e.Row.FindControl("lblQouteRate_1");
                Label lblQouteTime_1 = (Label)e.Row.FindControl("lblQouteTime_1");
                Label lblQouteSupplierName_1 = (Label)e.Row.FindControl("lblQouteSupplierName_1");
                Label lblQouteLeadDays_1 = (Label)e.Row.FindControl("lblQouteLeadDays_1");


                Label lblQouteRate_2 = (Label)e.Row.FindControl("lblQouteRate_2");
                Label lblQouteTime_2 = (Label)e.Row.FindControl("lblQouteTime_2");
                Label lblQouteSupplierName_2 = (Label)e.Row.FindControl("lblQouteSupplierName_2");
                Label lblQouteLeadDays_2 = (Label)e.Row.FindControl("lblQouteLeadDays_2");


                Label lblQouteRate_3 = (Label)e.Row.FindControl("lblQouteRate_3");
                Label lblQouteTime_3 = (Label)e.Row.FindControl("lblQouteTime_3");
                Label lblQouteSupplierName_3 = (Label)e.Row.FindControl("lblQouteSupplierName_3");
                Label lblQouteLeadDays_3 = (Label)e.Row.FindControl("lblQouteLeadDays_3");

                Label pendingQtyinorder = (Label)e.Row.FindControl("pendingQtyinorder");
                Label lblcolor = (Label)e.Row.FindControl("lblcolor");
                Label lblcutwastgae = (Label)e.Row.FindControl("lblcutwastgae");
                Button btnrapo = (Button)e.Row.FindControl("btnrapo");
                TextBox txtFinishedResidualShrinkage = (TextBox)e.Row.FindControl("txtFinishedResidualShrinkage");
                TextBox txtqtytosend = (TextBox)e.Row.FindControl("txtqtytosend");
                HtmlGenericControl divraise = e.Row.FindControl("divraise") as HtmlGenericControl;
                GridView grdstylenumber = e.Row.FindControl("grdstylenumber") as GridView;
                HiddenField hdnstage1 = (HiddenField)e.Row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)e.Row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)e.Row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)e.Row.FindControl("hdnstage4");
                //btnrapo.Attributes.Add("OnClientClick", "javascript:ShowpurchasedSupplierForm(this," + hdnfabricQuality.Value + "); return false;");
                //txtFinishedResidualShrinkage.Attributes.Add("onchange", "javascript:UpdateResidualShrinkage(this," + hdnfabricQuality.Value + ");");
                Label lblfabriccolor = (Label)e.Row.FindControl("lblfabriccolor");
                Label lblFabricQuality = (Label)e.Row.FindControl("lblFabricQuality");
                Label lblgsm = (Label)e.Row.FindControl("lblgsm");
                Label lblcountconstraction = (Label)e.Row.FindControl("lblcountconstraction");
                Label lblwidth = (Label)e.Row.FindControl("lblwidth");
                Label lblrequiredqty = (Label)e.Row.FindControl("lblrequiredqty");

                HiddenField hdnadjustmentqty = (HiddenField)e.Row.FindControl("hdnadjustmentqty");
                Label lblBalanceTooltip = (Label)e.Row.FindControl("lblBalanceTooltip");
                if (lblbalanceinhouseqty.Text != "")
                {

                    if (hdnadjustmentqty.Value != "0" && hdnadjustmentqty.Value != "")
                    {
                        lblBalanceTooltip.Text = "Adjustment qty from further stage: <span style='color:yellow'>" + hdnadjustmentqty.Value.ToString() + "</span>";
                        lblBalanceTooltip.CssClass = "TooltipTxt";
                    }
                }

                string ccn = "<span style='color:blue;'>" + lblFabricQuality.Text + "</span><span style='color:gray;'> " + lblgsm.Text + " " + lblcountconstraction.Text + " " + lblwidth.Text + " </span>" + "<br><b style='color:#000;'>" + lblcolor.Text + "</b>";

                string geriege = "0";
                string Residual = "0";
                string cutwastage = "0";
                Residual = txtFinishedResidualShrinkage.Text;

                ds = fabobj.GetfabricViewdetails("FINISHING", "STYLE", Convert.ToInt32(hdnfabricQuality.Value), 0, lblcolor.Text.Trim(), "", -1, -1, -1, Convert.ToBoolean(0), -1, Convert.ToInt16(hdnstage1.Value));
                dt = ds.Tables[1];
                dtfabQty = ds.Tables[2];
                //lblfabricorderavg.Text = ds.Tables[0].Rows.Count > 0 ? (ds.Tables[0].Rows[0]["FabricQty"].ToString() == "" ? "" : ds.Tables[0].Rows[0]["FabricQty"].ToString()) : "";
                //lblfabricorderavg2.Text = ds.Tables[0].Rows.Count > 0 ? (ds.Tables[0].Rows[0]["FabricQty"].ToString() == "" ? "" : Convert.ToDecimal(ds.Tables[0].Rows[0]["FabricQty"].ToString()).ToString("N0")) : "";
                if (dtfabQty.Rows.Count > 0)
                {
                    // lblbalanceinhouseqty.Text = dtfabQty.Rows[0]["BalanceinHouseQty"].ToString() == "0" ? "" : dtfabQty.Rows[0]["BalanceinHouseQty"].ToString();
                    lblFabQtyRemaning.Text = dtfabQty.Rows[0]["RemainingFabQty"].ToString() == "0" ? "" : dtfabQty.Rows[0]["RemainingFabQty"].ToString();
                    lblFabQtyRemaning2.Text = (dtfabQty.Rows[0]["RemainingFabQty"].ToString() == "" || dtfabQty.Rows[0]["RemainingFabQty"].ToString() == "0") ? "" : Convert.ToDecimal(dtfabQty.Rows[0]["RemainingFabQty"].ToString()).ToString("N0");

                    lblfabricorderavg.Text = (dtfabQty.Rows[0]["RemainingFabQty"].ToString() == "" || dtfabQty.Rows[0]["RemainingFabQty"].ToString() == "0") ? "" : Convert.ToDecimal(dtfabQty.Rows[0]["RemainingFabQty"].ToString()).ToString("N0");
                    lblfabricorderavg2.Text = (dtfabQty.Rows[0]["RemainingFabQty"].ToString() == "" || dtfabQty.Rows[0]["RemainingFabQty"].ToString() == "0") ? "" : Convert.ToDecimal(dtfabQty.Rows[0]["RemainingFabQty"].ToString()).ToString("N0");


                    lblTotalFabRequired.Text = dtfabQty.Rows[0]["TotalReuiredFabQty"].ToString() == "0" ? "" : "(" + dtfabQty.Rows[0]["TotalReuiredFabQty"].ToString() + ")";
                    lblcutwastgae.Text = dtfabQty.Rows[0]["CuttingWastage"].ToString() == "0" ? "" : dtfabQty.Rows[0]["CuttingWastage"].ToString();
                    cutwastage = lblcutwastgae.Text;
                    lblrequiredqty.Text = (dtfabQty.Rows[0]["RequiredQty"].ToString() == "" || dtfabQty.Rows[0]["RequiredQty"].ToString() == "0") ? "" : Convert.ToDecimal(dtfabQty.Rows[0]["RequiredQty"].ToString()).ToString("N0");
                    if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager) || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_TopManagement_Manager))
                    {
                        //lblfabricorderavg2.Attributes.Add("onclick", "OpenWastageAdmin('" + 10 + "','" + hdnfabricQuality.Value + "','" + lblcolor.Text.Trim() + "');");
                        lblrequiredqty.Attributes.Add("onclick", "OpenWastageAdmin('" + 10 + "','" + hdnfabricQuality.Value + "','" + lblcolor.Text.Trim() + "','" + lblcutwastgae.Text + "');");
                    }
                    //if (lblFabQtyRemaning2.Text != "")
                    //{
                    //    decimal _cutwastage = lblcutwastgae.Text == "" ? 0 : Convert.ToDecimal(lblcutwastgae.Text);
                    //   // decimal Totalre = Convert.ToDecimal(lblFabQtyRemaning2.Text) + (Convert.ToDecimal(lblFabQtyRemaning2.Text) * _cutwastage) / Convert.ToDecimal(100);
                    //    decimal Totalre = ((Convert.ToDecimal(lblFabQtyRemaning2.Text) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - (Convert.ToDecimal(_cutwastage)))); 
                    //    lblFabQtyRemaning2.Text = Math.Round(Totalre, 0).ToString("N0");



                    //}
                }
                if (dt.Rows.Count > 0)
                {
                    //System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    //sb.Append("<table>");
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    string List_ = "";
                    //    string[] serialnumber = dt.Rows[i]["SerialNumber"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    //    for (int x = 0; x < serialnumber.Length; x++)
                    //    {
                    //        List_ = List_ + serialnumber[x].Trim() + ",";
                    //    }
                    //    if (List_.LastIndexOf(",") > 0)
                    //    {
                    //        List_ = RemoveAt(List_, List_.LastIndexOf(","));
                    //    }
                    //    sb.AppendFormat("<tr><td>" + dt.Rows[i]["StyleNumber"].ToString() + "</td><td>" + "(" + List_ + ")" + "</td></tr>");
                    //}
                    //sb.Append("</table>");
                    //e.Row.Cells[1].Text = sb.ToString();

                    grdstylenumber.DataSource = dt;
                    grdstylenumber.DataBind();

                }

                ds = fabobj.GetfabricViewdetails("FINISHING", "GETTOP3SUPPLIER_FINISH", Convert.ToInt32(hdnfabricQuality.Value), 3, lblcolor.Text.Trim());
                dt = ds.Tables[0];
                dtForQuotCheck = ds.Tables[2];
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    dt = ds.Tables[1];
                }
                if (dtForQuotCheck.Rows.Count > 0)
                {

                    if (dt.Rows.Count == 3)
                    {
                        string times = dt.Rows[0]["times"].ToString();
                        if (times != "" && times != "")
                        {
                            lblQouteRate_1.Text = "<span style='color: green; font-size: 11px; padding-right:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[0]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[0]["times"].ToString() + ")</span>";
                        }
                        else
                        {
                            lblQouteRate_1.Text = "<span style='color: green; font-size: 11px; padding-right:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[0]["QuotedLandedRate"].ToString() + "</span>";
                        }

                        //lblQouteRate_1.Text = "<span style='color: green; font-size: 11px; padding-right:3px;position:relative;top:1px'>₹</span>" + dt.Rows[0]["QuotedLandedRate"].ToString() + "<span class='gray'> (" + dt.Rows[0]["times"].ToString() + ")</span>";
                        lblQouteSupplierName_1.Text = dt.Rows[0]["SupplierName"].ToString();
                        lblQouteLeadDays_1.Text = dt.Rows[0]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")";

                        times = dt.Rows[0]["times"].ToString();
                        if (times != "" && times != "")
                        {
                            lblQouteRate_2.Text = "<span style='color: green; font-size: 11px; padding-right:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[1]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[1]["times"].ToString() + ")</span>";
                        }
                        else
                        {
                            lblQouteRate_2.Text = "<span style='color: green; font-size: 11px; padding-right:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[1]["QuotedLandedRate"].ToString() + "</span>";
                        }

                        // lblQouteRate_2.Text = "<span style='color: green; font-size: 11px; padding-right:3px;position:relative;top:1px'>₹</span>" + dt.Rows[1]["QuotedLandedRate"].ToString() + "<span class='gray'> (" + dt.Rows[1]["times"].ToString() + ")</span>";
                        lblQouteSupplierName_2.Text = dt.Rows[1]["SupplierName"].ToString();
                        lblQouteLeadDays_2.Text = dt.Rows[1]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")";

                        times = dt.Rows[0]["times"].ToString();
                        if (times != "" && times != "")
                        {
                            lblQouteRate_3.Text = "<span style='color: green; font-size: 11px; padding-right:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[2]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[2]["times"].ToString() + ")</span>";
                        }
                        else
                        {
                            lblQouteRate_3.Text = "<span style='color: green; font-size: 11px; padding-right:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[2]["QuotedLandedRate"].ToString() + "</span>";
                        }

                        //lblQouteRate_3.Text = "<span style='color: green; font-size: 11px; padding-right:3px;position:relative;top:1px'>₹</span>" + dt.Rows[2]["QuotedLandedRate"].ToString() + "<span class='gray'> (" + dt.Rows[2]["times"].ToString() + ")</span>";
                        lblQouteSupplierName_3.Text = dt.Rows[2]["SupplierName"].ToString();
                        lblQouteLeadDays_3.Text = dt.Rows[2]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")";
                        IcheckHideCol = 1;
                    }
                    if (dt.Rows.Count == 2)
                    {
                        string times = dt.Rows[0]["times"].ToString();
                        if (times != "" && times != "")
                        {
                            lblQouteRate_1.Text = "<span style='color: green; font-size: 11px; padding-right:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[0]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[0]["times"].ToString() + ")</span>";
                        }
                        else
                        {
                            lblQouteRate_1.Text = "<span style='color: green; font-size: 11px; padding-right:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[0]["QuotedLandedRate"].ToString() + "</span>";
                        }

                        //lblQouteRate_1.Text = "<span style='color: green; font-size: 11px; padding-right:3px;position:relative;top:1px'>₹</span>" + dt.Rows[0]["QuotedLandedRate"].ToString() + "<span class='gray'> (" + dt.Rows[0]["times"].ToString() + ")</span>";
                        lblQouteSupplierName_1.Text = dt.Rows[0]["SupplierName"].ToString();
                        lblQouteLeadDays_1.Text = dt.Rows[0]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")";

                        times = dt.Rows[0]["times"].ToString();
                        if (times != "" && times != "")
                        {
                            lblQouteRate_2.Text = "<span style='color: green; font-size: 11px; padding-right:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[1]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[1]["times"].ToString() + ")</span>";
                        }
                        else
                        {
                            lblQouteRate_2.Text = "<span style='color: green; font-size: 11px; padding-right:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[1]["QuotedLandedRate"].ToString() + "</span>";
                        }

                        // lblQouteRate_2.Text = "<span style='color: green; font-size: 11px; padding-right:3px;position:relative;top:1px'>₹</span>" + dt.Rows[1]["QuotedLandedRate"].ToString() + "<span class='gray'> (" + dt.Rows[1]["times"].ToString() + ")</span>";
                        lblQouteSupplierName_2.Text = dt.Rows[1]["SupplierName"].ToString();
                        lblQouteLeadDays_2.Text = dt.Rows[1]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")";

                    }
                    if (dt.Rows.Count == 1)
                    {
                        string times = dt.Rows[0]["times"].ToString();
                        if (times != "" && times != "")
                        {
                            lblQouteRate_1.Text = "<span style='color: green; font-size: 11px; padding-right:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[0]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[0]["times"].ToString() + ")</span>";
                        }
                        else
                        {
                            lblQouteRate_1.Text = "<span style='color: green; font-size: 11px; padding-right:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[0]["QuotedLandedRate"].ToString() + "</span>";
                        }


                        lblQouteSupplierName_1.Text = dt.Rows[0]["SupplierName"].ToString();
                        lblQouteLeadDays_1.Text = dt.Rows[0]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")";
                    }
                }

                else
                {
                    divraise.Attributes.Add("Class", "HideRaisebtn");
                }
                ds = fabobj.GetfabricViewdetails("FINISHING", "RERAISESUPPLIER", Convert.ToInt32(hdnfabricQuality.Value), 0, lblcolor.Text.Trim());
                dt = ds.Tables[0];
                DataTable dtremaningqty = ds.Tables[1];
                if (dtremaningqty.Rows.Count > 0)
                {
                    if (dtremaningqty.Rows[0]["RemaningQty"].ToString() != "")
                    {
                        pendingQtyinorder.Text = Convert.ToDecimal(dtremaningqty.Rows[0]["RemaningQty"].ToString()).ToString("N0");
                    }
                    //if (dtremaningqty.Rows[0]["AdjustRemainingQty"].ToString() != "")
                    //{
                    //    Decimal AdjustRemainingQty = Convert.ToDecimal(dtremaningqty.Rows[0]["AdjustRemainingQty"].ToString());
                    //    lblFabQtyRemaning2.Text = Convert.ToString(Convert.ToDecimal(lblFabQtyRemaning2.Text) - AdjustRemainingQty);
                    //}
                }
                if (dt.Rows.Count > 0)
                {

                    // pendingQtyinorder.Text = Convert.ToDecimal(dt.Rows[0]["RemaningQty"].ToString()).ToString("N0");
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                        {
                            sb.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #e2dddd99;'><span class='per'>" + dt.Rows[i]["PO_Number"].ToString() + "</span></td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[9].Text = sb.ToString();
                }
                if (dt.Rows.Count > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                        {
                            sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + dt.Rows[i]["SupplierName"].ToString() + "</td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[10].Text = sb.ToString();
                }
                decimal Qtys = 0;
                if (dt.Rows.Count > 0)
                {
                    int HoldQty = 0;
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                        {
                            string Qty = "";
                            if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                            {
                                Qty = Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()).ToString("N0");
                            }
                            HoldQty = HoldQty + Convert.ToInt32(dt.Rows[i]["HoldQty"].ToString());
                            sb.AppendFormat("<tr><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + Qty + "</td></tr>");
                        }
                    }
                    pendingQtyinorder.ToolTip = "Hold Qty: " + HoldQty.ToString();
                    sb.Append("</table>");
                    e.Row.Cells[11].Text = sb.ToString();


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != 1)
                        {
                            if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                            {
                                Qtys += Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString());
                            }
                        }
                    }
                    recqty.Text = Math.Round(Qtys, 0).ToString();




                }
                decimal Remaning = lblFabQtyRemaning2.Text == "" ? 0 : Convert.ToDecimal(lblFabQtyRemaning2.Text);
                decimal balanceInhOuse = lblbalanceinhouseqty.Text == "" ? 0 : Convert.ToDecimal(lblbalanceinhouseqty.Text);
                if (lblFabQtyRemaning2.Text != "")
                {
                    decimal _cutwastage = lblcutwastgae.Text == "" ? 0 : Convert.ToDecimal(lblcutwastgae.Text);
                    decimal Totalre = ((Convert.ToDecimal(lblFabQtyRemaning2.Text) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - (Convert.ToDecimal(_cutwastage))));
                    //decimal Totalre = Convert.ToDecimal(lblFabQtyRemaning2.Text) + (Convert.ToDecimal(lblFabQtyRemaning2.Text) * _cutwastage) / Convert.ToDecimal(100);
                    // lblFabQtyRemaning2.Text = Math.Round(Totalre, 0).ToString("N0");

                    //decimal pendingqty = (Remaning) - (Convert.ToDecimal((Math.Round(Qtys, 0)) + Convert.ToDecimal(balanceInhOuse)));
                    //pendingQtyinorder.Text = Convert.ToInt32(Math.Round(pendingqty, 0)).ToString("N0");
                }
                if (dt.Rows.Count > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        MasterPoID = Convert.ToInt32(dt.Rows[i]["MasterPO_Id"].ToString());
                        SupplierMasterID = Convert.ToInt32(dt.Rows[i]["SupplierID"].ToString());
                        string Qty = "";
                        if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                        {
                            Qty = Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()).ToString("N0");
                        }
                        if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 1 || Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 2)
                        {
                            string Status = "";
                            if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 1)
                            {
                                Status = "Canceled";
                            }
                            else if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 2)
                            {
                                Status = "closed";
                            }
                            if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 40px;'>" + "<div style='Color:grey' class=''  > " + Status + "</div></td></tr>");
                            }
                        }
                        else
                        {
                            if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager) || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_TopManagement_Manager))
                            {

                                //sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div class='btnrepo' onclick='ShowpurchasedSupplierFormReraise(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "&apos;" + lblcolor.Text + "&apos;" + ");' > Re.PO</div><img src='../../images/del-butt.png' /></td></tr>");
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div class='btnrepo' onclick='ShowpurchasedSupplierFormReraise(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "&apos;" + lblcolor.Text + "&apos;" + "," + geriege + "," + Residual + "," + cutwastage + "," + "&apos;" + hdnfabricQuality.ClientID + "&apos;" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + ");' > Re.PO</div></td></tr>");
                            }
                            else
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div style='Color:grey' class='btnrepo tooltip' > Re.PO</div></td></tr>");
                            }
                        }

                    }
                    sb.Append("</table>");
                    e.Row.Cells[12].Text = sb.ToString();
                }
                if (pendingQtyinorder.Text != "")
                {
                    if (pendingQtyinorder.Text.Replace(",", "") == "0")
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                        pendingQtyinorder.Text = "";
                    }
                    else if (Convert.ToDouble(pendingQtyinorder.Text.Replace(",", "")) <= 0)
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                        //pendingQtyinorder.Text = "";
                    }
                    else
                    {
                        if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager) || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_TopManagement_Manager))
                        {
                            //divraise.Attributes.Add("onclick", "javascript:alert(" + "You have permission 1" + ")");
                            //divraise.Attributes.Add("onclick", "ShowpurchasedSupplierForm('" + hdnfabricQuality.Value + "','" + SupplierMasterID + "','" + 0 + "','" + lblcolor.Text + "')");
                            divraise.Attributes.Add("onclick", "ShowpurchasedSupplierForm('" + divraise.ClientID + "','" + hdnfabricQuality.Value + "','" + SupplierMasterID + "','" + 0 + "','" + lblcolor.Text + "','" + geriege + "','" + Residual + "','" + cutwastage + "','" + hdnstage1.Value + "','" + hdnstage2.Value + "','" + hdnstage3.Value + "','" + hdnstage4.Value + "')");
                        }
                        else
                        {
                            //divraise.Attributes.Add("onclick", "alert('" + "You do not have permission" + "')");
                            divraise.Attributes.Add("onclick", "PermissionAlertMsg();");
                            // divraise.Attributes.Add("style", "Color:grey");
                        }

                    }
                }
                else
                {
                    divraise.Attributes.Add("Class", "HideRaisebtn");
                    pendingQtyinorder.Text = "";
                }
                HtmlAnchor lnkProductionpopup = e.Row.FindControl("lnkProductionpopup") as HtmlAnchor;
                DataSet dsSupplier = new DataSet();
                DataTable dtsupplierQuoted = new DataTable();
                DataTable dtSystemQuoted = new DataTable();
                dsSupplier = fabobj.GetfabricViewdetails("FINISHING", "GETTOP3SUPPLIER_FINISH", Convert.ToInt32(hdnfabricQuality.Value), 100, lblcolor.Text.Trim());
                dtsupplierQuoted = dsSupplier.Tables[0];
                dtSystemQuoted = dsSupplier.Tables[1];

                if (dtsupplierQuoted.Rows.Count > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table class='topsupplier'>");
                    sb.AppendFormat("<tr><th colspan='4' style='background: #39589c !important;color:#fff !important'>All Quotations<span style='float:right;padding-right:10px;cursor: pointer;color:#fff' titel='Close' onclick='HideSupplierDiv();'>X</span></th></tr>");
                    sb.AppendFormat("<tr><th>Fabric Quality (GSM) C&C Width <br>Color/Print</th><th style='display:none'>Residual Sh. (%)</th><th> Best Quote For Ref.</th><th>Supplier Name</th><th>Quoted Rate & Lead Time</th></tr>");

                    int x = 0;
                    for (int i = 0; i < dtsupplierQuoted.Rows.Count; i++)
                    {

                        sb.Append("<tr>");
                        if (x <= 0)
                        {
                            System.Text.StringBuilder sbfab = new System.Text.StringBuilder();
                            sb.AppendFormat("<td rowspan='" + dtsupplierQuoted.Rows.Count + "'>");

                            sbfab.Append("<table style='border: none;' class='topsupplier' cellspacing='0' cellpadding='0'>");

                            sbfab.Append("<tr>");
                            sbfab.Append("<TD style='border: none;'>");
                            //    sbfab.Append(dtsupplierQuoted.Rows[0]["FabricDetails"].ToString());
                            sbfab.Append(ccn);

                            sbfab.Append("</TD>");
                            sbfab.Append("</tr>");

                            sbfab.Append("<tr>");
                            sbfab.Append("<TD style='border: none;'>");
                            //sbfab.Append(lblcolor.Text.Trim());
                            sbfab.Append("</TD>");
                            sbfab.Append("</tr>");

                            sbfab.Append("</table>");
                            sb.AppendFormat(sbfab.ToString());
                            //sb.AppendFormat(dtsupplierQuoted.Rows[0]["FabricDetails"].ToString());

                            //sb.AppendFormat("<br/>");
                            //sb.AppendFormat(lblcolor.Text.Trim());
                            sb.AppendFormat("</td>");
                        }
                        if (x <= 0)
                        {
                            sb.AppendFormat("<td style='display:none;' rowspan='" + dtsupplierQuoted.Rows.Count + "'>");
                            sb.AppendFormat(dtsupplierQuoted.Rows[0]["GriegeShrinkage"].ToString());
                            sb.AppendFormat("</td>");
                        }
                        if (dtSystemQuoted.Rows.Count > 0)
                        {
                            if (x <= 0)
                            {
                                sb.AppendFormat("<td style='background: lightgreen;' rowspan='" + dtsupplierQuoted.Rows.Count + "'>");
                                sb.AppendFormat("<span style='color: green; font-size: 12px;'>₹ </span><span style='color:#000'>" + dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString() + "</span>");
                                sb.AppendFormat("</td>");
                            }
                        }

                        sb.AppendFormat("<td>");
                        string dd = dtsupplierQuoted.Rows[i]["Create_Update_Date"].ToString() == "" ? "" : Convert.ToDateTime(dtsupplierQuoted.Rows[i]["Create_Update_Date"].ToString()).ToString("dd MMM yyyy");
                        sb.AppendFormat(dtsupplierQuoted.Rows[i]["SupplierName"].ToString() + " " + "(" + dd + ")");
                        sb.AppendFormat("</td>");

                        string days = "";
                        if (dtsupplierQuoted.Rows[i]["LeadTimes"].ToString() != "" && dtsupplierQuoted.Rows[i]["LeadTimes"].ToString() != "0")
                        {
                            days = "(" + dtsupplierQuoted.Rows[i]["LeadTimes"].ToString() + " Days)";
                        }
                        string str = "";
                        if (dtsupplierQuoted.Rows[i]["QuotedLandedRate"].ToString() != "0")
                            str = "<span style='color: green; font-size: 12px;'>₹ </span><span style='color:#000'>" + dtsupplierQuoted.Rows[i]["QuotedLandedRate"].ToString() + "</span>";
                        else
                            str = "<span style='color: green; font-size: 12px;'> </span>";

                        sb.AppendFormat("<td>");
                        sb.AppendFormat(str + "   " + days);

                        sb.AppendFormat("</td>");


                        x = x + 1;

                        sb.Append("</tr>");
                    }
                    sb.Append("</table>");
                    //lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier(\"" + sb.ToString() + "\")");
                    lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier2(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "'" + lblcolor.Text.Trim() + "'" + "," + geriege + "," + Residual + "," + cutwastage + "," + "'" + hdnfabricQuality.ClientID + "'" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + "," + "'" + ccn.Replace("'", "") + "'" + ");");
                }
                else
                {
                    //lnkProductionpopup.Style.Add("display", "none;");
                    //lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier(\"" + "empty" + "\")");
                    lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier2(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "'" + lblcolor.Text.Trim() + "'" + "," + geriege + "," + Residual + "," + cutwastage + "," + "'" + hdnfabricQuality.ClientID + "'" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + "," + "'" + ccn.Replace("'", "") + "'" + ");");
                }

            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {

        }
        public static void MergeRows(GridView gridView)
        {
            if (gridView.Rows.Count > 1)
            {
                for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
                {
                    GridViewRow row = gridView.Rows[rowIndex];
                    GridViewRow previousRow = gridView.Rows[rowIndex + 1];
                    if (row.Cells[0].Text != "" && previousRow.Cells[0].Text != "")
                    {
                        if (row.Cells[0].Text == previousRow.Cells[0].Text)
                        {
                            row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 :
                                                   previousRow.Cells[0].RowSpan + 1;
                            previousRow.Cells[0].Visible = false;
                            gridView.Rows[0].Cells[0].Style.Add("border", "0px !important;");
                            gridView.Rows[0].Cells[1].Style.Add("border", "0px !important;");

                        }
                        else
                        {
                            gridView.Rows[0].Cells[0].Style.Add("border", "0px !important;");
                            gridView.Rows[0].Cells[1].Style.Add("border", "0px !important;");
                        }
                    }
                    gridView.Rows[0].Cells[0].Style.Add("border", "0px !important;");
                    gridView.Rows[0].Cells[1].Style.Add("border", "0px !important;");
                }
            }
            else
            {
                if (gridView.Rows.Count > 0)
                {
                    gridView.Rows[0].Cells[0].Style.Add("border", "0px !important;");
                    gridView.Rows[0].Cells[1].Style.Add("border", "0px !important;");
                }
            }
        }
        protected void grdgayed_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                // headerRow1.Attributes.Add("class", "HeaderClass");
                headerRow2.Attributes.Add("class", "HeaderClass");

                TableCell HeaderCell = new TableCell();

                HeaderCell = new TableCell();
                HeaderCell.Text = "<Table><tr><td colspan='3' style='border:0px;'>Fabric Quality (GSM) C&C Width<br>Color/Print (Unit)</td></tr><tr><TD>Current Stage</TD><TD>Previous Stage</TD><TD>Style Specific</TD></tr></table>";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("min-width", "200px");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Style No. (Serial No.)";
                HeaderCell.Style.Add("min-width", "150px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "<Table><tr><td style='border:0px'>Overall to order/send</td></tr><tr><TD>required qty</TD></tr></table>";
                HeaderCell.Style.Add("Width", "60px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Balance <br>In House ";
                HeaderCell.Style.Add("Width", "40px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Total To Send ";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Visible = false;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Total In House ";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Total Send ";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                // if (SupplierCount == 3)
                // {
                HeaderCell = new TableCell();
                HeaderCell.Text = "Quote 1 (Rate & Time)<br>Supplier Name<br>Lead Time";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("Width", "160px");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quote 2 (Rate & Time)<br>Supplier Name<br>Lead Time";
                HeaderCell.Style.Add("Width", "160px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quote 3 (Rate & Time)<br>Supplier Name<br>Lead Time";
                HeaderCell.Style.Add("Width", "160px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Number";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Supplier Name";
                HeaderCell.Style.Add("min-width", "130px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Rcvd. Qty.";
                HeaderCell.Style.Add("Width", "60px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Revise PO";
                HeaderCell.Attributes.Add("class", "widthAction");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Qty. to Raise PO ";
                HeaderCell.Attributes.Add("class", "widthPending");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                grdgayed.Controls[0].Controls.AddAt(0, headerRow2);
                // grdgayed.Controls[0].Controls.AddAt(0, headerRow1);



            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int SupplierMasterID = -1;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataTable dtForQuotCheck = new DataTable();
                DataTable dtfabQty = new DataTable();
                HiddenField hdnfabricQuality = (HiddenField)e.Row.FindControl("hdnfabricQuality");
                Label lblfabricorderavg = (Label)e.Row.FindControl("lblfabricorderavg");
                Label lblfabricorderavg2 = (Label)e.Row.FindControl("lblfabricorderavg2");
                Label lblbalanceinhouseqty = (Label)e.Row.FindControl("lblbalanceinhouseqty");
                //Label lblstyleno = (Label)e.Row.FindControl("lblstyleno");
                Label lblFabQtyRemaning = (Label)e.Row.FindControl("lblFabQtyRemaning");
                Label lblFabQtyRemaning2 = (Label)e.Row.FindControl("lblFabQtyRemaning2");
                Label lblTotalFabRequired = (Label)e.Row.FindControl("lblTotalFabRequired");


                Label lblQouteRate_1 = (Label)e.Row.FindControl("lblQouteRate_1");
                Label lblQouteTime_1 = (Label)e.Row.FindControl("lblQouteTime_1");
                Label lblQouteSupplierName_1 = (Label)e.Row.FindControl("lblQouteSupplierName_1");
                Label lblQouteLeadDays_1 = (Label)e.Row.FindControl("lblQouteLeadDays_1");


                Label lblQouteRate_2 = (Label)e.Row.FindControl("lblQouteRate_2");
                Label lblQouteTime_2 = (Label)e.Row.FindControl("lblQouteTime_2");
                Label lblQouteSupplierName_2 = (Label)e.Row.FindControl("lblQouteSupplierName_2");
                Label lblQouteLeadDays_2 = (Label)e.Row.FindControl("lblQouteLeadDays_2");


                Label lblQouteRate_3 = (Label)e.Row.FindControl("lblQouteRate_3");
                Label lblQouteTime_3 = (Label)e.Row.FindControl("lblQouteTime_3");
                Label lblQouteSupplierName_3 = (Label)e.Row.FindControl("lblQouteSupplierName_3");
                Label lblQouteLeadDays_3 = (Label)e.Row.FindControl("lblQouteLeadDays_3");
                Label pendingQtyinorder = (Label)e.Row.FindControl("pendingQtyinorder");
                Label lblfabriccolor = (Label)e.Row.FindControl("lblfabriccolor");
                Label lblfabricQty = (Label)e.Row.FindControl("lblfabricQty");
                Label lblFabQtyToOrder = (Label)e.Row.FindControl("lblFabQtyToOrder");
                Label recqty = (Label)e.Row.FindControl("recqty");
                Label lblcutwastgae = (Label)e.Row.FindControl("lblcutwastgae");
                Label lblcolor = (Label)e.Row.FindControl("lblcolor");
                Button btnrapo = (Button)e.Row.FindControl("btnrapo");
                TextBox txtGreigeshrk = (TextBox)e.Row.FindControl("txtGreigeshrk");
                TextBox txtResidualShak = (TextBox)e.Row.FindControl("txtResidualShak");
                TextBox txtqtytosend = (TextBox)e.Row.FindControl("txtqtytosend");

                Label lblisstylespecific = (Label)e.Row.FindControl("lblisstylespecific");
                HiddenField hdnCurrentstage = (HiddenField)e.Row.FindControl("hdnCurrentstage");
                HiddenField hdnperiviousstgae = (HiddenField)e.Row.FindControl("hdnperiviousstgae");
                HiddenField hdnIsStyleSpecific = (HiddenField)e.Row.FindControl("hdnIsStyleSpecific");
                HiddenField hdnStyleID = (HiddenField)e.Row.FindControl("hdnStyleID");
                Label lbltotalqtytosend = (Label)e.Row.FindControl("lbltotalqtytosend");
                HiddenField hdnstage1 = (HiddenField)e.Row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)e.Row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)e.Row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)e.Row.FindControl("hdnstage4");

                Label lblFabricQuality = (Label)e.Row.FindControl("lblFabricQuality");
                Label lblgsm = (Label)e.Row.FindControl("lblgsm");
                Label lblcountconstraction = (Label)e.Row.FindControl("lblcountconstraction");
                Label lblwidth = (Label)e.Row.FindControl("lblwidth");
                Label lblrequiredqty = (Label)e.Row.FindControl("lblrequiredqty");
                string ccn = "<span style='color:blue;'>" + lblFabricQuality.Text + "</span><span style='color:gray;'> " + lblgsm.Text + " " + lblcountconstraction.Text + " " + lblwidth.Text + " </span>" + "<br><b style='color:#000;'>" + lblfabriccolor.Text + "</b>";

                HiddenField hdnadjustmentqty = (HiddenField)e.Row.FindControl("hdnadjustmentqty");
                Label lblBalanceTooltip = (Label)e.Row.FindControl("lblBalanceTooltip");
                if (lblbalanceinhouseqty.Text != "")
                {

                    if (hdnadjustmentqty.Value != "0" && hdnadjustmentqty.Value != "")
                    {
                        lblBalanceTooltip.Text = "Adjustment qty from further stage: <span style='color:yellow'>" + hdnadjustmentqty.Value.ToString() + "</span>";
                        lblBalanceTooltip.CssClass = "TooltipTxt";
                    }
                }



                HtmlGenericControl divraise = e.Row.FindControl("divraise") as HtmlGenericControl;
                GridView grdstylenumber = e.Row.FindControl("grdstylenumber") as GridView;
                // FabricGroupAdmin.FabricDetailsDayed fabbasic = fabobj.GetFabricDayedDetailsFirst(txtsearchkeyswords.Text.Trim())[e.Row.RowIndex];
                // List<FabricGroupAdmin.FabricContractDetails> FabricDayed = fabobj.GetFabricDayedDetails(fabbasic.FabricQualityID, lblfabriccolor.Text.Trim());
                //if (FabricDayed.Count > 0)
                //{
                //    grdstylenumber.DataSource = FabricDayed;
                //    grdstylenumber.DataBind();
                //    lblfabricQty.Text = FabricDayed[0].FabricQty.ToString("N0");
                //    lblFabQtyToOrder.Text = FabricDayed[0].FinalFabricQtyToOrder.ToString("N0");
                //    lblcutwastgae.Text = FabricDayed[0].CuttingWastage.ToString();
                //}

                //MergeRows(grdstylenumber);


                FabricGroupAdmin.FabricDetailsDayed fabbasic = fabobj.GetFabricDayedDetailsFirst(txtsearchkeyswords.Text.Trim())[e.Row.RowIndex];
                List<FabricGroupAdmin.FabricContractDetails> FabricDayed = fabobj.GetFabricDayedDetails(fabbasic.FabricQualityID, lblfabriccolor.Text, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, Convert.ToInt16(hdnstage1.Value), Convert.ToInt16(hdnstage2.Value), Convert.ToInt16(hdnstage3.Value), Convert.ToInt16(hdnstage4.Value), Convert.ToInt32(hdnStyleID.Value));
                if (FabricDayed.Count > 0)
                {
                    grdstylenumber.DataSource = FabricDayed;
                    grdstylenumber.DataBind();
                    //lblfabricQty.Text = FabricDayed[0].FabricQty.ToString("N0");
                    lblfabricQty.Text = FabricDayed[0].FinalFabricQtyToOrder.ToString("N0");
                    lblFabQtyToOrder.Text = FabricDayed[0].FinalFabricQtyToOrder.ToString("N0");
                    lblcutwastgae.Text = FabricDayed[0].CuttingWastage.ToString();
                    lbltotalqtytosend.Text = FabricDayed[0].FinalFabricQtyToOrder.ToString("N0");
                    lblrequiredqty.Text = FabricDayed[0].RequiredQty.ToString("N0");
                }
                MergeRows(grdstylenumber);
                int IsStyelSepecfic = 0;
                if (hdnIsStyleSpecific.Value != null && hdnIsStyleSpecific.Value != "")
                {
                    IsStyelSepecfic = Convert.ToInt32(hdnIsStyleSpecific.Value == "False" ? 0 : 1);
                }
                if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager) || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_TopManagement_Manager))
                {
                    if (hdnIsStyleSpecific.Value != null && hdnIsStyleSpecific.Value != "")
                    {
                        IsStyelSepecfic = Convert.ToInt32(hdnIsStyleSpecific.Value == "False" ? 0 : 1);
                    }
                    //lblfabricQty.Attributes.Add("onclick", "OpenWastageAdminPrint('" + 2 + "','" + hdnfabricQuality.Value + "','" + lblfabriccolor.Text.Trim() + "','" + hdnCurrentstage.Value + "','" + hdnperiviousstgae.Value + "','" + IsStyelSepecfic + "','" + hdnStyleID.Value + "','" + fabbasic.stage1 + "','" + fabbasic.stage2 + "','" + fabbasic.stage3 + "','" + fabbasic.stage4 + "','" + lblcutwastgae.Text + "');");
                    lblrequiredqty.Attributes.Add("onclick", "OpenWastageAdminPrint('" + 2 + "','" + hdnfabricQuality.Value + "','" + lblfabriccolor.Text.Trim() + "','" + hdnCurrentstage.Value + "','" + hdnperiviousstgae.Value + "','" + IsStyelSepecfic + "','" + hdnStyleID.Value + "','" + fabbasic.stage1 + "','" + fabbasic.stage2 + "','" + fabbasic.stage3 + "','" + fabbasic.stage4 + "','" + lblcutwastgae.Text + "');");
                }
                //ds = fabobj.GetfabricViewdetails("Dyed", "GETTOP3SUPPLIER_DAYED", Convert.ToInt32(hdnfabricQuality.Value), 3, lblfabriccolor.Text.Trim());
                //dt = ds.Tables[0];
                //dtForQuotCheck = ds.Tables[2];
                #region Dayed
                #endregion
                if (IsStyelSepecfic == 0)
                {
                    ds = fabobj.GetfabricViewdetails("DYED", "GETTOP3SUPPLIER_DAYEDNONSTYLE", Convert.ToInt32(hdnfabricQuality.Value), 3, lblfabriccolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, fabbasic.stage1, fabbasic.stage2, fabbasic.stage3, fabbasic.stage4);
                    dt = ds.Tables[0];
                }
                else if (IsStyelSepecfic == 1)
                {
                    ds = fabobj.GetfabricViewdetails("DYED", "GETTOP3SUPPLIER_DAYEDSTYLE", Convert.ToInt32(hdnfabricQuality.Value), 3, lblfabriccolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, Convert.ToInt32(hdnStyleID.Value), fabbasic.stage1, fabbasic.stage2, fabbasic.stage3, fabbasic.stage4);
                    dt = ds.Tables[0];
                }


                string geriege = "0";
                string Residual = "0";
                string cutwastage = "0";
                geriege = txtGreigeshrk.Text;
                Residual = txtResidualShak.Text;
                cutwastage = lblcutwastgae.Text;
                if (txtResidualShak.Text == "0")
                {
                    txtResidualShak.Text = "";
                }


                if (dt.Rows.Count == 3)
                {
                    lblQouteRate_1.Text = "<span style='color: green; font-size: 11px;padding-right:3px;potion:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[0]["QuotedLandedRate"].ToString() + "</span><span style='color:gray'> (" + dt.Rows[0]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_1.Text = dt.Rows[0]["SupplierName"].ToString();
                    lblQouteLeadDays_1.Text = dt.Rows[0]["LeadTimes"].ToString() + "<span style='color:gray'> (" + "Days" + ")</span>";

                    lblQouteRate_2.Text = "<span style='color: green; font-size: 11px;padding-right:3px;potion:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[1]["QuotedLandedRate"].ToString() + "</span><span style='color:gray'> (" + dt.Rows[1]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_2.Text = dt.Rows[1]["SupplierName"].ToString();
                    lblQouteLeadDays_2.Text = dt.Rows[1]["LeadTimes"].ToString() + "<span style='color:gray'> (" + "Days" + ")</span>";

                    lblQouteRate_3.Text = "<span style='color: green; font-size: 11px; padding-right:3px;potion:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[2]["QuotedLandedRate"].ToString() + "</span><span style='color:gray'> (" + dt.Rows[2]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_3.Text = dt.Rows[2]["SupplierName"].ToString();
                    lblQouteLeadDays_3.Text = dt.Rows[2]["LeadTimes"].ToString() + "<span style='color:gray'> (" + "Days" + ")</span>";
                    IcheckHideCol = 1;
                }
                else if (dt.Rows.Count == 2)
                {

                    lblQouteRate_1.Text = "<span style='color: green; font-size: 11px;padding-right:3px;potion:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[0]["QuotedLandedRate"].ToString() + "</span><span style='color:gray'> (" + dt.Rows[0]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_1.Text = dt.Rows[0]["SupplierName"].ToString();
                    lblQouteLeadDays_1.Text = dt.Rows[0]["LeadTimes"].ToString() + "<span style='color:gray'> (" + "Days" + ")</span>";

                    lblQouteRate_2.Text = "<span style='color: green; font-size: 11px;padding-right:3px;potion:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[1]["QuotedLandedRate"].ToString() + "</span><span style='color:gray'> (" + dt.Rows[1]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_2.Text = dt.Rows[1]["SupplierName"].ToString();
                    lblQouteLeadDays_2.Text = dt.Rows[1]["LeadTimes"].ToString() + "<span style='color:gray'> (" + "Days" + ")</span>";


                }
                else if (dt.Rows.Count == 1)
                {

                    lblQouteRate_1.Text = "<span style='color: green; font-size: 11px;padding-right:3px;potion:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[0]["QuotedLandedRate"].ToString() + "</span><span style='color:gray'> (" + dt.Rows[0]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_1.Text = dt.Rows[0]["SupplierName"].ToString();
                    lblQouteLeadDays_1.Text = dt.Rows[0]["LeadTimes"].ToString() + "<span style='color:gray'> (" + "Days" + ")</span>";

                }
                else
                {
                    divraise.Attributes.Add("Class", "HideRaisebtn");
                }
                ds = fabobj.GetfabricViewdetails("Dyed", "RERAISESUPPLIER", Convert.ToInt32(hdnfabricQuality.Value), 100, lblfabriccolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, (fabbasic.IsStyleSpecific == false ? -1 : Convert.ToInt32(hdnStyleID.Value)), Convert.ToInt16(hdnstage1.Value), Convert.ToInt16(hdnstage2.Value), Convert.ToInt16(hdnstage3.Value), Convert.ToInt16(hdnstage4.Value));

                dt = ds.Tables[0];
                DataTable dtremaningqty = ds.Tables[1];
                if (dtremaningqty.Rows.Count > 0)
                {
                    if (dtremaningqty.Rows[0]["RemaningQty"].ToString() != "")
                    {
                        pendingQtyinorder.Text = Convert.ToDecimal(dtremaningqty.Rows[0]["RemaningQty"].ToString()).ToString("N0");
                    }
                }
                if (dt.Rows.Count > 0)
                {


                    // pendingQtyinorder.Text = Convert.ToDecimal(dt.Rows[0]["RemaningQty"].ToString()).ToString("N0");
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                        {
                            sb.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #e2dddd99;'><span class='per'>" + dt.Rows[i]["PO_Number"].ToString() + "</span></td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[12].Text = sb.ToString();
                }
                if (dt.Rows.Count > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                        {
                            sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 40px;'>" + dt.Rows[i]["SupplierName"].ToString() + "</td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[13].Text = sb.ToString();
                }
                if (dt.Rows.Count > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string Qty = "";
                        if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                        {
                            Qty = Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()).ToString("N0");
                        }

                        sb.AppendFormat("<tr><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + Qty + "</td></tr>");
                    }
                    sb.Append("</table>");
                    e.Row.Cells[14].Text = sb.ToString();
                }

                if (dt.Rows.Count > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        MasterPoID = Convert.ToInt32(dt.Rows[i]["MasterPO_Id"].ToString());
                        SupplierMasterID = Convert.ToInt32(dt.Rows[i]["SupplierID"].ToString());
                        string Qty = "";
                        if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                        {
                            Qty = Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()).ToString("N0");
                        }

                        //sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #999;width: 77px;'>" + "<div class='btnrepo tooltip' onclick=ShowpurchasedSupplierFormReraise('" + hdnfabricQuality.Value + "','" + SupplierMasterID + "','" + MasterPoID + "'); > Re.PO<span class='tooltiptext'>You don't have permission</span></div><img src='../../images/del-butt.png' /></td></tr>");
                        if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 1 || Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 2)
                        {
                            string Status = "";
                            if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 1)
                            {
                                Status = "Canceled";
                            }
                            else if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 2)
                            {
                                Status = "closed";
                            }
                            if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 40px;'>" + "<div style='Color:grey' class=''  > " + Status + "</div></td></tr>");
                            }
                        }
                        else
                        {
                            if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager) || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_TopManagement_Manager))
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div class='btnrepo' onclick='ShowpurchasedSupplierFormReraise(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "&apos;" + lblfabriccolor.Text + "&apos;" + "," + geriege + "," + Residual + "," + cutwastage + "," + "&apos;" + hdnfabricQuality.ClientID + "&apos;" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + ");' > Re.PO</div></td></tr>");

                            }
                            else
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div style='Color:grey' class='btnrepo tooltip'  > Re.PO</div></td></tr>");
                            }
                        }
                    }

                    sb.Append("</table>");
                    e.Row.Cells[15].Text = sb.ToString();
                    decimal Qtys = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        if (Convert.ToDecimal(dt.Rows[i]["SendQty"].ToString()) > 0)
                        {
                            Qtys += Convert.ToDecimal(dt.Rows[i]["SendQty"].ToString());
                        }
                    }
                    recqty.Text = Math.Round(Qtys, 0).ToString();
                    txtqtytosend.Text = Math.Round(Qtys, 0).ToString("N0");
                }
                if (pendingQtyinorder.Text != "")
                {
                    if (pendingQtyinorder.Text.Replace(",", "") == "0")
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                        pendingQtyinorder.Text = "";
                    }
                    else if (Convert.ToDouble(pendingQtyinorder.Text.Replace(",", "")) <= 0)
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                        //pendingQtyinorder.Text = "";
                    }
                    else
                    {
                        if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager) || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_TopManagement_Manager))
                        {

                            divraise.Attributes.Add("onclick", "ShowpurchasedSupplierForm('" + divraise.ClientID + "','" + hdnfabricQuality.Value + "','" + SupplierMasterID + "','" + 0 + "','" + lblfabriccolor.Text + "','" + geriege + "','" + Residual + "','" + cutwastage + "','" + hdnstage1.Value + "','" + hdnstage2.Value + "','" + hdnstage3.Value + "','" + hdnstage4.Value + "')");
                        }
                        else
                        {
                            //divraise.Attributes.Add("onclick", "alert('You do not have permission');");
                            divraise.Attributes.Add("onclick", "PermissionAlertMsg();");
                            //divraise.Attributes.Add("style", "Color:grey");
                        }
                    }
                }
                else
                {
                    divraise.Attributes.Add("Class", "HideRaisebtn");
                    pendingQtyinorder.Text = "";
                }
                HtmlAnchor lnkProductionpopup = e.Row.FindControl("lnkProductionpopup") as HtmlAnchor;
                //DataSet dsSupplier = new DataSet();
                //DataTable dtsupplierQuoted = new DataTable();
                //DataTable dtSystemQuoted = new DataTable();
                //dsSupplier = fabobj.GetfabricViewdetails("Dyed", "GETTOP3SUPPLIER_DAYED", Convert.ToInt32(hdnfabricQuality.Value), 100, lblfabriccolor.Text);
                //dtsupplierQuoted = dsSupplier.Tables[0];
                //dtSystemQuoted = dsSupplier.Tables[1];



                DataSet dsSupplier = new DataSet();
                DataTable dtsupplierQuoted = new DataTable();
                DataTable dtSystemQuoted = new DataTable();
                //dsSupplier = fabobj.GetfabricViewdetails("PRINT", "GETTOP3SUPPLIER_PRINT", Convert.ToInt32(hdnfabricQuality.Value), 100, lblcolor.Text);
                //dtsupplierQuoted = dsSupplier.Tables[0];
                //dtSystemQuoted = dsSupplier.Tables[1];

                if (IsStyelSepecfic == 0)
                {
                    ds = fabobj.GetfabricViewdetails("Dyed", "GETTOP3SUPPLIER_DAYEDNONSTYLE", Convert.ToInt32(hdnfabricQuality.Value), 100, lblfabriccolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, -1, fabbasic.stage1, fabbasic.stage2, fabbasic.stage3, fabbasic.stage4);
                    dt = ds.Tables[0];
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtsupplierQuoted = ds.Tables[0];
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        dtSystemQuoted = ds.Tables[1];
                    }

                }
                else if (IsStyelSepecfic == 1)
                {
                    ds = fabobj.GetfabricViewdetails("Dyed", "GETTOP3SUPPLIER_DAYEDSTYLE", Convert.ToInt32(hdnfabricQuality.Value), 100, lblfabriccolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, Convert.ToInt32(hdnStyleID.Value), fabbasic.stage1, fabbasic.stage2, fabbasic.stage3, fabbasic.stage4);


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtsupplierQuoted = ds.Tables[0];
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        dtSystemQuoted = ds.Tables[1];
                    }
                }



                if (dtsupplierQuoted.Rows.Count > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table class='topsupplier'>");
                    sb.AppendFormat("<tr><th colspan='5'  style='background: #39589c !important;color:#fff !important'>All Quotations<span style='float:right;padding-right:10px;cursor: pointer;color:#fff' title='Close' onclick='HideSupplierDiv();'>x</span></th></tr>");
                    sb.AppendFormat("<tr><th>Fabric Quality (GSM) C&C Width <br>Color/Print</th><th style='display:none;'>Res. Sh.(%)</th><th> Best Quote For Ref.</th><th>Supplier Name</th><th>Quoted Rate &  Lead Time</th></tr>");

                    int x = 0;
                    for (int i = 0; i < dtsupplierQuoted.Rows.Count; i++)
                    {
                        sb.Append("<tr>");
                        if (x <= 0)
                        {
                            System.Text.StringBuilder sbfab = new System.Text.StringBuilder();
                            sb.AppendFormat("<td rowspan='" + dtsupplierQuoted.Rows.Count + "'>");

                            sbfab.Append("<table style='border: none;' class='topsupplier' cellspacing='0' cellpadding='0'>");

                            sbfab.Append("<tr>");
                            sbfab.Append("<TD style='border: none;'>");
                            //sbfab.Append(dtsupplierQuoted.Rows[0]["FabricDetails"].ToString());
                            sbfab.Append(ccn);
                            sbfab.Append("</TD>");
                            sbfab.Append("</tr>");
                            // this code commented by Bharat on 15-may-20
                            //sbfab.Append("<tr>");
                            //sbfab.Append("<TD style='border: none;'>");
                            //sbfab.Append(lblfabriccolor.Text.Trim());
                            //sbfab.Append("</TD>");
                            //sbfab.Append("</tr>");
                            //end
                            sbfab.Append("</table>");
                            sb.AppendFormat(sbfab.ToString());
                            //sb.AppendFormat(dtsupplierQuoted.Rows[0]["FabricDetails"].ToString());

                            //sb.AppendFormat("<br/>");
                            //sb.AppendFormat(lblcolor.Text.Trim());
                            sb.AppendFormat("</td>");
                        }
                        if (x <= 0)
                        {
                            sb.AppendFormat("<td style='display:none;' rowspan='" + dtsupplierQuoted.Rows.Count + "'>");
                            sb.AppendFormat(dtsupplierQuoted.Rows[0]["GriegeShrinkage"].ToString());
                            sb.AppendFormat("</td>");
                        }
                        if (dtSystemQuoted.Rows.Count > 0)
                        {
                            if (x <= 0)
                            {
                                sb.AppendFormat("<td style='background: lightgreen;' rowspan='" + dtsupplierQuoted.Rows.Count + "'>");
                                sb.AppendFormat("<span style='color: green; font-size: 11px;'>₹ </span><span style='color:#000'>" + dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString() + "</span>");
                                sb.AppendFormat("</td>");
                            }
                        }

                        sb.AppendFormat("<td>");
                        string dd = dtsupplierQuoted.Rows[i]["Create_Update_Date"].ToString() == "" ? "" : Convert.ToDateTime(dtsupplierQuoted.Rows[i]["Create_Update_Date"].ToString()).ToString("dd MMM yyyy");
                        sb.AppendFormat(dtsupplierQuoted.Rows[i]["SupplierName"].ToString() + " " + "(" + dd + ")");
                        sb.AppendFormat("</td>");

                        string days = "";
                        if (dtsupplierQuoted.Rows[i]["LeadTimes"].ToString() != "" && dtsupplierQuoted.Rows[i]["LeadTimes"].ToString() != "0")
                        {
                            days = "(" + dtsupplierQuoted.Rows[i]["LeadTimes"].ToString() + " Days)";
                        }
                        string str = "";
                        if (dtsupplierQuoted.Rows[i]["QuotedLandedRate"].ToString() != "0")
                            str = "<span style='color: green; font-size: 12px;'>₹ </span><span style='color:#000'>" + dtsupplierQuoted.Rows[i]["QuotedLandedRate"].ToString() + "</span>";
                        else
                            str = "<span style='color: green; font-size: 12px;'> </span>";

                        sb.AppendFormat("<td>");
                        sb.AppendFormat(str + "   " + days);

                        sb.AppendFormat("</td>");


                        x = x + 1;
                        sb.Append("</tr>");
                    }
                    sb.Append("</table>");
                    //lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier(\"" + sb.ToString() + "\")");
                    lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier2(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "'" + lblfabriccolor.Text + "'" + "," + geriege + "," + Residual + "," + cutwastage + "," + "'" + hdnfabricQuality.ClientID + "'" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + "," + "'" + ccn.Replace("'", "") + "'" + ");");
                }
                else
                {
                    //lnkProductionpopup.Style.Add("display", "none;");
                    //lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier(\"" + "empty" + "\")");
                    lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier2(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "'" + lblfabriccolor.Text + "'" + "," + geriege + "," + Residual + "," + cutwastage + "," + "'" + hdnfabricQuality.ClientID + "'" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + "," + "'" + ccn.Replace("'", "") + "'" + ");");
                }
            }
        }
        protected void grdprint_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                headerRow1.Attributes.Add("class", "HeaderClass");
                headerRow2.Attributes.Add("class", "HeaderClass");

                TableCell HeaderCell = new TableCell();

                HeaderCell = new TableCell();
                HeaderCell.Text = "<Table><tr><td colspan='3' style='border:0px;'>Fabric Quality (GSM) C&C Width<br>Color/Print (Unit)</td></tr><tr><TD>Current Stage</TD><TD>Previous Stage</TD><TD>Style Specific</TD></tr></table>";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("min-width", "200px");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Style No. (Serial No.)";
                HeaderCell.Style.Add("min-width", "150px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "<Table><tr><td style='border:0px'>Overall to order/send</td></tr><tr><TD>required qty</TD></tr></table>";
                HeaderCell.Style.Add("Width", "60px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Balance <br>In House ";
                HeaderCell.Style.Add("Width", "40px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Total To Send ";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Visible = false;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Total In House ";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Total Send ";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                // if (SupplierCount == 3)
                // {
                HeaderCell = new TableCell();
                HeaderCell.Text = "Quote 1 (Rate & Time)<br>Supplier Name<br>Lead Time";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("Width", "160px");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quote 2 (Rate & Time)<br>Supplier Name<br>Lead Time";
                HeaderCell.Style.Add("Width", "160px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quote 3 (Rate & Time)<br>Supplier Name<br>Lead Time";
                HeaderCell.Style.Add("Width", "160px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Number";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Supplier Name";
                HeaderCell.Style.Add("min-width", "130px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Rcvd. Qty. ";
                HeaderCell.Style.Add("Width", "60px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Revise PO";
                HeaderCell.Attributes.Add("class", "widthAction");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Qty. to Raise PO ";
                HeaderCell.Attributes.Add("class", "widthPending");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                grdprint.Controls[0].Controls.AddAt(0, headerRow2);
                // grdprint.Controls[0].Controls.AddAt(0, headerRow1);



            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int SupplierMasterID = -1;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataTable dtForQuotCheck = new DataTable();
                DataTable dtfabQty = new DataTable();
                HiddenField hdnfabricQuality = (HiddenField)e.Row.FindControl("hdnfabricQuality");
                HiddenField hdnIsStyleSpecific = (HiddenField)e.Row.FindControl("hdnIsStyleSpecific");
                Label lblfabricorderavg = (Label)e.Row.FindControl("lblfabricorderavg");
                Label lblfabricorderavg2 = (Label)e.Row.FindControl("lblfabricorderavg2");
                Label lblbalanceinhouseqty = (Label)e.Row.FindControl("lblbalanceinhouseqty");
                //  Label lblstyleno = (Label)e.Row.FindControl("lblstyleno");
                Label lblFabQtyRemaning = (Label)e.Row.FindControl("lblFabQtyRemaning");
                Label lblFabQtyRemaning2 = (Label)e.Row.FindControl("lblFabQtyRemaning2");
                Label lblTotalFabRequired = (Label)e.Row.FindControl("lblTotalFabRequired");


                Label lblQouteRate_1 = (Label)e.Row.FindControl("lblQouteRate_1");
                Label lblQouteTime_1 = (Label)e.Row.FindControl("lblQouteTime_1");
                Label lblQouteSupplierName_1 = (Label)e.Row.FindControl("lblQouteSupplierName_1");
                Label lblQouteLeadDays_1 = (Label)e.Row.FindControl("lblQouteLeadDays_1");


                Label lblQouteRate_2 = (Label)e.Row.FindControl("lblQouteRate_2");
                Label lblQouteTime_2 = (Label)e.Row.FindControl("lblQouteTime_2");
                Label lblQouteSupplierName_2 = (Label)e.Row.FindControl("lblQouteSupplierName_2");
                Label lblQouteLeadDays_2 = (Label)e.Row.FindControl("lblQouteLeadDays_2");


                Label lblQouteRate_3 = (Label)e.Row.FindControl("lblQouteRate_3");
                Label lblQouteTime_3 = (Label)e.Row.FindControl("lblQouteTime_3");
                Label lblQouteSupplierName_3 = (Label)e.Row.FindControl("lblQouteSupplierName_3");
                Label lblQouteLeadDays_3 = (Label)e.Row.FindControl("lblQouteLeadDays_3");
                Label pendingQtyinorder = (Label)e.Row.FindControl("pendingQtyinorder");
                Label lblcolor = (Label)e.Row.FindControl("lblcolor");
                Label lblfabricQty = (Label)e.Row.FindControl("lblfabricQty");
                Label lblFabQtyToOrder = (Label)e.Row.FindControl("lblFabQtyToOrder");
                Label recqty = (Label)e.Row.FindControl("recqty");
                TextBox txtqtytosend = (TextBox)e.Row.FindControl("txtqtytosend");
                Button btnrapo = (Button)e.Row.FindControl("btnrapo");
                TextBox txtGreigeshrk = (TextBox)e.Row.FindControl("txtGreigeshrk");
                TextBox txtResidualShak = (TextBox)e.Row.FindControl("txtResidualShak");
                Label lblcutwastgae = (Label)e.Row.FindControl("lblcutwastgae");
                HtmlGenericControl divraise = e.Row.FindControl("divraise") as HtmlGenericControl;
                GridView grdstylenumber = e.Row.FindControl("grdstylenumber") as GridView;
                Label lblisstylespecific = (Label)e.Row.FindControl("lblisstylespecific");
                HiddenField hdnCurrentstage = (HiddenField)e.Row.FindControl("hdnCurrentstage");
                HiddenField hdnperiviousstgae = (HiddenField)e.Row.FindControl("hdnperiviousstgae");
                HiddenField hdnStyleID = (HiddenField)e.Row.FindControl("hdnStyleID");
                Label lbltotalqtytosend = (Label)e.Row.FindControl("lbltotalqtytosend");
                HiddenField hdnstage1 = (HiddenField)e.Row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)e.Row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)e.Row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)e.Row.FindControl("hdnstage4");

                Label lblfabriccolor = (Label)e.Row.FindControl("lblfabriccolor");
                Label lblFabricQuality = (Label)e.Row.FindControl("lblFabricQuality");
                Label lblgsm = (Label)e.Row.FindControl("lblgsm");
                Label lblcountconstraction = (Label)e.Row.FindControl("lblcountconstraction");
                Label lblwidth = (Label)e.Row.FindControl("lblwidth");
                Label lblrequiredqty = (Label)e.Row.FindControl("lblrequiredqty");
                string ccn = "<span style='color:blue;'>" + lblFabricQuality.Text + "</span><span style='color:gray;'> " + lblgsm.Text + " " + lblcountconstraction.Text + " " + lblwidth.Text + " </span>" + "<br><b style='color:#000;'>" + lblfabriccolor.Text + "</b>";
                HiddenField hdnadjustmentqty = (HiddenField)e.Row.FindControl("hdnadjustmentqty");
                Label lblBalanceTooltip = (Label)e.Row.FindControl("lblBalanceTooltip");
                if (lblbalanceinhouseqty.Text != "")
                {

                    if (hdnadjustmentqty.Value != "0" && hdnadjustmentqty.Value != "")
                    {
                        lblBalanceTooltip.Text = "Adjustment qty from further stage: <span style='color:yellow'>" + hdnadjustmentqty.Value.ToString() + "</span>";
                        lblBalanceTooltip.CssClass = "TooltipTxt";
                    }
                }

                FabricGroupAdmin.FabricDetailsDayed fabbasic = fabobj.GetFabricPrintDetailsFirst(txtsearchkeyswords.Text.Trim())[e.Row.RowIndex];
                List<FabricGroupAdmin.FabricContractDetails> FabricDayed = fabobj.GetFabricPrintDetails(fabbasic.FabricQualityID, lblcolor.Text, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, Convert.ToInt16(hdnstage1.Value), Convert.ToInt16(hdnstage2.Value), Convert.ToInt16(hdnstage3.Value), Convert.ToInt16(hdnstage4.Value), Convert.ToInt32(hdnStyleID.Value));
                if (FabricDayed.Count > 0)
                {
                    grdstylenumber.DataSource = FabricDayed;
                    grdstylenumber.DataBind();
                    // lblfabricQty.Text = FabricDayed[0].FabricQty.ToString("N0");
                    lblfabricQty.Text = FabricDayed[0].FinalFabricQtyToOrder.ToString("N0");
                    lblFabQtyToOrder.Text = FabricDayed[0].FinalFabricQtyToOrder.ToString("N0");
                    lblcutwastgae.Text = FabricDayed[0].CuttingWastage.ToString();
                    lbltotalqtytosend.Text = FabricDayed[0].FinalFabricQtyToOrder.ToString("N0");
                    lblrequiredqty.Text = FabricDayed[0].RequiredQty.ToString("N0");
                }
                //MergeRows(grdstylenumber);
                int IsStyelSepecfic = 0;
                if (hdnIsStyleSpecific.Value != null && hdnIsStyleSpecific.Value != "")
                {
                    IsStyelSepecfic = Convert.ToInt32(hdnIsStyleSpecific.Value == "False" ? 0 : 1);
                }
                if (IsStyelSepecfic == 0)
                {
                    ds = fabobj.GetfabricViewdetails("PRINT", "GETTOP3SUPPLIER_PRINTNONSTYLE", Convert.ToInt32(hdnfabricQuality.Value), 3, lblcolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, -1, fabbasic.stage1, fabbasic.stage2, fabbasic.stage3, fabbasic.stage4);
                    dt = ds.Tables[0];
                }
                else if (IsStyelSepecfic == 1)
                {
                    ds = fabobj.GetfabricViewdetails("PRINT", "GETTOP3SUPPLIER_PRINTSTYLE", Convert.ToInt32(hdnfabricQuality.Value), 3, lblcolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, Convert.ToInt32(hdnStyleID.Value), fabbasic.stage1, fabbasic.stage2, fabbasic.stage3, fabbasic.stage4);
                    dt = ds.Tables[0];
                }
                //dtForQuotCheck = ds.Tables[2];
                // dtForQuotCheck = ds.Tables[1];
                string geriege = "0";
                string Residual = "0";
                string cutwastage = "0";
                geriege = txtGreigeshrk.Text;
                Residual = txtResidualShak.Text;
                cutwastage = lblcutwastgae.Text;
                if (txtResidualShak.Text == "0")
                {
                    txtResidualShak.Text = "";
                }
                //if (lblFabQtyToOrder.Text != "")
                //{
                //    decimal _cutwastage = lblcutwastgae.Text == "" ? 0 : Convert.ToDecimal(lblcutwastgae.Text);

                //    decimal Totalre = ((Convert.ToDecimal(lblFabQtyToOrder.Text) * Convert.ToDecimal(100)) / (Convert.ToDecimal(100) - (Convert.ToDecimal(_cutwastage))));
                //    lbltotalqtytosend.Text = Math.Round(Totalre, 0).ToString("N0");



                //}
                //if (dtForQuotCheck.Rows.Count > 0)
                //{

                if (dt.Rows.Count == 3)
                {
                    lblQouteRate_1.Text = "<span style='color: green; font-size: 12px; padding-left:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[0]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[0]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_1.Text = dt.Rows[0]["SupplierName"].ToString();
                    lblQouteLeadDays_1.Text = dt.Rows[0]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")</span>";

                    lblQouteRate_2.Text = "<span style='color: green; font-size: 12px;padding-left:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[1]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[1]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_2.Text = dt.Rows[1]["SupplierName"].ToString();
                    lblQouteLeadDays_2.Text = dt.Rows[1]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")</span>";

                    lblQouteRate_3.Text = "<span style='color: green; font-size: 12px;padding-left:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[2]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[2]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_3.Text = dt.Rows[2]["SupplierName"].ToString();
                    lblQouteLeadDays_3.Text = dt.Rows[2]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")</span>";
                    IcheckHideCol = 1;
                }
                else if (dt.Rows.Count == 2)
                {

                    lblQouteRate_1.Text = "<span style='color: green; font-size: 12px;padding-left:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[0]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[0]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_1.Text = dt.Rows[0]["SupplierName"].ToString();
                    lblQouteLeadDays_1.Text = dt.Rows[0]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")</span>";

                    lblQouteRate_2.Text = "<span style='color: green; font-size: 12px;padding-left:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[1]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[1]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_2.Text = dt.Rows[1]["SupplierName"].ToString();
                    lblQouteLeadDays_2.Text = dt.Rows[1]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")</span>";


                }
                else if (dt.Rows.Count == 1)
                {

                    lblQouteRate_1.Text = "<span style='color: green; font-size: 12px;padding-left:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[0]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[0]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_1.Text = dt.Rows[0]["SupplierName"].ToString();
                    lblQouteLeadDays_1.Text = dt.Rows[0]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")</span>";

                }
                else
                {
                    divraise.Attributes.Add("Class", "HideRaisebtn");
                }
                // }
                //else
                //{
                //    divraise.Attributes.Add("Class", "HideRaisebtn");
                //}
                if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager) || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_TopManagement_Manager))
                {

                    if (hdnIsStyleSpecific.Value != null && hdnIsStyleSpecific.Value != "")
                    {
                        IsStyelSepecfic = Convert.ToInt32(hdnIsStyleSpecific.Value == "False" ? 0 : 1);
                    }
                    //lblfabricQty.Attributes.Add("onclick", "OpenWastageAdminPrint('" + 3 + "','" + hdnfabricQuality.Value + "','" + lblcolor.Text.Trim() + "','" + hdnCurrentstage.Value + "','" + hdnperiviousstgae.Value + "','" + IsStyelSepecfic + "','" + hdnStyleID.Value + "','" + fabbasic.stage1 + "','" + fabbasic.stage2 + "','" + fabbasic.stage3 + "','" + fabbasic.stage4 + "','" + lblcutwastgae.Text + "');");
                    lblrequiredqty.Attributes.Add("onclick", "OpenWastageAdminPrint('" + 3 + "','" + hdnfabricQuality.Value + "','" + lblcolor.Text.Trim() + "','" + hdnCurrentstage.Value + "','" + hdnperiviousstgae.Value + "','" + IsStyelSepecfic + "','" + hdnStyleID.Value + "','" + fabbasic.stage1 + "','" + fabbasic.stage2 + "','" + fabbasic.stage3 + "','" + fabbasic.stage4 + "','" + lblcutwastgae.Text + "');");
                }
                //   public DataSet GetfabricViewdetails(string flag, string flagoption, int FabQualityID = 0, int SupplierCount = 0, string fabricDeatils = "", string searchtxt = "", int SupplierPO = 0, int CurrentStage = 0, int PreviousStage = 0, bool IsStylespecific = false, int StyleID = 0, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0)
                ds = fabobj.GetfabricViewdetails("PRINT", "RERAISESUPPLIER", Convert.ToInt32(hdnfabricQuality.Value), 0, lblcolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, (fabbasic.IsStyleSpecific == false ? -1 : Convert.ToInt32(hdnStyleID.Value)), fabbasic.stage1, fabbasic.stage2, fabbasic.stage3, fabbasic.stage4);
                dt = ds.Tables[0];
                DataTable dtremaningqty = ds.Tables[1];
                if (dtremaningqty.Rows.Count > 0)
                {
                    if (dtremaningqty.Rows[0]["RemaningQty"].ToString() != "")
                    {
                        pendingQtyinorder.Text = Convert.ToDecimal(dtremaningqty.Rows[0]["RemaningQty"].ToString()).ToString("N0");
                    }
                }
                if (dt.Rows.Count > 0)
                {


                    // pendingQtyinorder.Text = Convert.ToDecimal(dt.Rows[0]["RemaningQty"].ToString()).ToString("N0");
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                        {
                            sb.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #e2dddd99;'><span class='per'>" + dt.Rows[i]["PO_Number"].ToString() + "</span></td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[12].Text = sb.ToString();
                }
                if (dt.Rows.Count > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                        {
                            sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 40px;'>" + dt.Rows[i]["SupplierName"].ToString() + "</td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[13].Text = sb.ToString();
                }
                if (dt.Rows.Count > 0)
                {
                    int HoldQty = 0;
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                        {
                            string Qty = "";
                            if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                            {
                                Qty = Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()).ToString("N0");
                            }
                            HoldQty = HoldQty + Convert.ToInt32(dt.Rows[i]["HoldQty"].ToString());
                            sb.AppendFormat("<tr><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + Qty + "</td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[14].Text = sb.ToString();
                    pendingQtyinorder.ToolTip = "Hold Qty: " + HoldQty.ToString();
                }

                if (dt.Rows.Count > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        MasterPoID = Convert.ToInt32(dt.Rows[i]["MasterPO_Id"].ToString());
                        SupplierMasterID = Convert.ToInt32(dt.Rows[i]["SupplierID"].ToString());
                        string Qty = "";
                        if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                        {
                            Qty = Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()).ToString("N0");
                        }

                        //sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #999;width: 77px;'>" + "<div class='btnrepo tooltip' onclick=ShowpurchasedSupplierFormReraise('" + hdnfabricQuality.Value + "','" + SupplierMasterID + "','" + MasterPoID + "'); > Re.PO<span class='tooltiptext'>You don't have permission</span></div><img src='../../images/del-butt.png' /></td></tr>");
                        if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 1 || Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 2)
                        {
                            string Status = "";
                            if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 1)
                            {
                                Status = "Canceled";
                            }
                            else if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 2)
                            {
                                Status = "closed";
                            }
                            if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 40px;'>" + "<div style='Color:grey' class=''  > " + Status + "</div></td></tr>");
                            }
                        }
                        else
                        {
                            if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager) || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_TopManagement_Manager))
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div class='btnrepo' onclick='ShowpurchasedSupplierFormReraise(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "&apos;" + lblcolor.Text + "&apos;" + "," + geriege + "," + Residual + "," + cutwastage + "," + "&apos;" + hdnfabricQuality.ClientID + "&apos;" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + ");' > Re.PO</div></td></tr>");
                            }
                            else
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div style='Color:grey' class='btnrepo tooltip'  > Re.PO</div></td></tr>");
                            }
                        }
                    }

                    sb.Append("</table>");
                    e.Row.Cells[15].Text = sb.ToString();
                    decimal Qtys = 0;
                    decimal SQty = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != 1)
                        {

                            if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                            {
                                Qtys += Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString());
                            }
                            if (Convert.ToDecimal(dt.Rows[i]["SendQty"].ToString()) > 0)
                            {
                                SQty += Convert.ToDecimal(dt.Rows[i]["SendQty"].ToString());
                            }
                        }
                    }
                    recqty.Text = Math.Round(Qtys, 0).ToString();
                    txtqtytosend.Text = Math.Round(SQty, 0).ToString("N0");
                }
                if (pendingQtyinorder.Text != "")
                {
                    if (pendingQtyinorder.Text.Replace(",", "") == "0")
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                        pendingQtyinorder.Text = "";
                    }
                    else if (Convert.ToDouble(pendingQtyinorder.Text.Replace(",", "")) <= 0)
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                        //pendingQtyinorder.Text = "";
                    }
                    else
                    {
                        if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager) || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_TopManagement_Manager))
                        {
                            divraise.Attributes.Add("onclick", "ShowpurchasedSupplierForm('" + divraise.ClientID + "','" + hdnfabricQuality.Value + "','" + SupplierMasterID + "','" + 0 + "','" + lblcolor.Text + "','" + geriege + "','" + Residual + "','" + cutwastage + "','" + hdnstage1.Value + "','" + hdnstage2.Value + "','" + hdnstage3.Value + "','" + hdnstage4.Value + "')");
                        }
                        else
                        {
                            //divraise.Attributes.Add("onclick", "alert('You do not have permission');");
                            divraise.Attributes.Add("onclick", "PermissionAlertMsg();");
                            //divraise.Attributes.Add("style", "Color:grey");
                        }
                    }
                }
                else
                {
                    divraise.Attributes.Add("Class", "HideRaisebtn");
                    pendingQtyinorder.Text = "";
                }
                HtmlAnchor lnkProductionpopup = e.Row.FindControl("lnkProductionpopup") as HtmlAnchor;
                DataSet dsSupplier = new DataSet();
                DataTable dtsupplierQuoted = new DataTable();
                DataTable dtSystemQuoted = new DataTable();
                //dsSupplier = fabobj.GetfabricViewdetails("PRINT", "GETTOP3SUPPLIER_PRINT", Convert.ToInt32(hdnfabricQuality.Value), 100, lblcolor.Text);
                //dtsupplierQuoted = dsSupplier.Tables[0];
                //dtSystemQuoted = dsSupplier.Tables[1];

                if (IsStyelSepecfic == 0)
                {
                    ds = fabobj.GetfabricViewdetails("PRINT", "GETTOP3SUPPLIER_PRINTNONSTYLE", Convert.ToInt32(hdnfabricQuality.Value), 100, lblcolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, -1, fabbasic.stage1, fabbasic.stage2, fabbasic.stage3, fabbasic.stage4);
                    dt = ds.Tables[0];
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtsupplierQuoted = ds.Tables[0];
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        dtSystemQuoted = ds.Tables[1];
                    }

                }
                else if (IsStyelSepecfic == 1)
                {
                    ds = fabobj.GetfabricViewdetails("PRINT", "GETTOP3SUPPLIER_PRINTSTYLE", Convert.ToInt32(hdnfabricQuality.Value), 100, lblcolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, Convert.ToInt32(hdnStyleID.Value), fabbasic.stage1, fabbasic.stage2, fabbasic.stage3, fabbasic.stage4);


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtsupplierQuoted = ds.Tables[0];
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        dtSystemQuoted = ds.Tables[1];
                    }

                }


                if (dtsupplierQuoted.Rows.Count > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table class='topsupplier'>");
                    sb.AppendFormat("<tr><th colspan='5'  style='background: #39589c !important;color:#fff !important'>All Quotations<span style='float:right;padding-right:10px;cursor: pointer;color:#fff' titel='Close' onclick='HideSupplierDiv();'>X</span></th></tr>");
                    sb.AppendFormat("<tr><th>Fabric Quality (GSM) C&C Width <br>Color/Print</th><th style='display:none;'>Res. Sh.(%)</th><th> Best Quote For Ref.</th><th>Supplier Name</th><th>Quoted Rate &  Lead Time</th></tr>");

                    int x = 0;
                    for (int i = 0; i < dtsupplierQuoted.Rows.Count; i++)
                    {
                        sb.Append("<tr>");
                        if (x <= 0)
                        {
                            System.Text.StringBuilder sbfab = new System.Text.StringBuilder();
                            sb.AppendFormat("<td rowspan='" + dtsupplierQuoted.Rows.Count + "'>");

                            sbfab.Append("<table style='border: none;' class='topsupplier' cellspacing='0' cellpadding='0'>");

                            sbfab.Append("<tr>");
                            sbfab.Append("<TD style='border: none;'>");
                            sbfab.Append(ccn);
                            sbfab.Append("</TD>");
                            sbfab.Append("</tr>");

                            //sbfab.Append("<tr>");
                            //sbfab.Append("<TD style='border: none;'>");
                            //sbfab.Append(lblcolor.Text.Trim());
                            //sbfab.Append("</TD>");
                            //sbfab.Append("</tr>");

                            sbfab.Append("</table>");
                            sb.AppendFormat(sbfab.ToString());
                            sb.AppendFormat("</td>");

                        }
                        if (x <= 0)
                        {
                            sb.AppendFormat("<td style='display:none;' rowspan='" + dtsupplierQuoted.Rows.Count + "'>");
                            sb.AppendFormat(dtsupplierQuoted.Rows[0]["GriegeShrinkage"].ToString());
                            sb.AppendFormat("</td>");
                        }
                        if (dtSystemQuoted.Rows.Count > 0)
                        {
                            if (x <= 0)
                            {
                                sb.AppendFormat("<td style='background: lightgreen;' rowspan='" + dtsupplierQuoted.Rows.Count + "'>");
                                sb.AppendFormat("<span style='color: green; font-size: 12px;'>₹ </span><span style='color:#000'>" + dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString() + "</span>");
                                sb.AppendFormat("</td>");
                            }
                        }

                        sb.AppendFormat("<td>");
                        string dd = dtsupplierQuoted.Rows[i]["Create_Update_Date"].ToString() == "" ? "" : Convert.ToDateTime(dtsupplierQuoted.Rows[i]["Create_Update_Date"].ToString()).ToString("dd MMM yyyy");
                        sb.AppendFormat(dtsupplierQuoted.Rows[i]["SupplierName"].ToString() + " " + "(" + dd + ")");
                        sb.AppendFormat("</td>");

                        string days = "";
                        if (dtsupplierQuoted.Rows[i]["LeadTimes"].ToString() != "" && dtsupplierQuoted.Rows[i]["LeadTimes"].ToString() != "0")
                        {
                            days = "(" + dtsupplierQuoted.Rows[i]["LeadTimes"].ToString() + " Days)";
                        }
                        string str = "";
                        if (dtsupplierQuoted.Rows[i]["QuotedLandedRate"].ToString() != "0")
                            str = "<span style='color: green; font-size: 12px;'>₹ </span><span style='color:#000'>" + dtsupplierQuoted.Rows[i]["QuotedLandedRate"].ToString() + "</span>";
                        else
                            str = "<span style='color: green; font-size: 12px;'> </span>";

                        sb.AppendFormat("<td>");
                        sb.AppendFormat(str + "   " + days);

                        sb.AppendFormat("</td>");


                        x = x + 1;
                        sb.Append("</tr>");
                    }
                    sb.Append("</table>");
                    //lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier(\"" + sb.ToString() + "\")");
                    lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier2(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "'" + lblfabriccolor.Text + "'" + "," + geriege + "," + Residual + "," + cutwastage + "," + "'" + hdnfabricQuality.ClientID + "'" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + "," + "'" + ccn.Replace("'", "") + "'" + ");");
                }
                else
                {
                    //lnkProductionpopup.Style.Add("display", "none;");
                    //lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier(\"" + "empty" + "\")");
                    lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier2(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "'" + lblfabriccolor.Text + "'" + "," + geriege + "," + Residual + "," + cutwastage + "," + "'" + hdnfabricQuality.ClientID + "'" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + "," + "'" + ccn.Replace("'", "") + "'" + ");");
                }
            }
        }
        protected void grdvalueadditionRFD_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                //  headerRow1.Attributes.Add("class", "HeaderClass");
                headerRow2.Attributes.Add("class", "HeaderClass");

                TableCell HeaderCell = new TableCell();

                HeaderCell = new TableCell();
                HeaderCell.Text = "<Table><tr><td colspan='3' style='border:0px;'>Fabric Quality (GSM) C&C Width<br>Color/Print (Unit)</td></tr><tr><TD>Current Stage</TD><TD>Previous Stage</TD><TD>Style Specific</TD></tr></table>";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("min-width", "200px");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Style No. (Serial No.)";
                HeaderCell.Style.Add("min-width", "150px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "<Table><tr><td style='border:0px'>Overall to order/send</td></tr><tr><TD>required qty</TD></tr></table>";
                HeaderCell.Style.Add("Width", "60px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Balance <br>In House ";
                HeaderCell.Style.Add("Width", "40px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Total To Send ";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Visible = false;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Total In House ";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Total Send ";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Quote 1 (Rate & Time)<br>Supplier Name<br>Lead Time";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("Width", "160px");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quote 2 (Rate & Time)<br>Supplier Name<br>Lead Time";
                HeaderCell.Style.Add("Width", "160px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quote 3 (Rate & Time)<br>Supplier Name<br>Lead Time";
                HeaderCell.Style.Add("Width", "160px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Number";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Supplier Name";
                HeaderCell.Style.Add("min-width", "130px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Rcvd. Qty. ";
                HeaderCell.Style.Add("Width", "60px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Revise PO";
                HeaderCell.Attributes.Add("class", "widthAction");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Qty. to Raise PO ";
                HeaderCell.Attributes.Add("class", "widthPending");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                grdvalueadditionRFD.Controls[0].Controls.AddAt(0, headerRow2);
                // grdvalueadditionRFD.Controls[0].Controls.AddAt(0, headerRow1);

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int SupplierMasterID = -1;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataTable dtForQuotCheck = new DataTable();
                DataTable dtfabQty = new DataTable();
                HiddenField hdnfabricQuality = (HiddenField)e.Row.FindControl("hdnfabricQuality");
                HiddenField hdnIsStyleSpecific = (HiddenField)e.Row.FindControl("hdnIsStyleSpecific");
                Label lblfabricorderavg = (Label)e.Row.FindControl("lblfabricorderavg");
                Label lblfabricorderavg2 = (Label)e.Row.FindControl("lblfabricorderavg2");
                Label lblbalanceinhouseqty = (Label)e.Row.FindControl("lblbalanceinhouseqty");
                //  Label lblstyleno = (Label)e.Row.FindControl("lblstyleno");
                Label lblFabQtyRemaning = (Label)e.Row.FindControl("lblFabQtyRemaning");
                Label lblFabQtyRemaning2 = (Label)e.Row.FindControl("lblFabQtyRemaning2");
                Label lblTotalFabRequired = (Label)e.Row.FindControl("lblTotalFabRequired");


                Label lblQouteRate_1 = (Label)e.Row.FindControl("lblQouteRate_1");
                Label lblQouteTime_1 = (Label)e.Row.FindControl("lblQouteTime_1");
                Label lblQouteSupplierName_1 = (Label)e.Row.FindControl("lblQouteSupplierName_1");
                Label lblQouteLeadDays_1 = (Label)e.Row.FindControl("lblQouteLeadDays_1");


                Label lblQouteRate_2 = (Label)e.Row.FindControl("lblQouteRate_2");
                Label lblQouteTime_2 = (Label)e.Row.FindControl("lblQouteTime_2");
                Label lblQouteSupplierName_2 = (Label)e.Row.FindControl("lblQouteSupplierName_2");
                Label lblQouteLeadDays_2 = (Label)e.Row.FindControl("lblQouteLeadDays_2");


                Label lblQouteRate_3 = (Label)e.Row.FindControl("lblQouteRate_3");
                Label lblQouteTime_3 = (Label)e.Row.FindControl("lblQouteTime_3");
                Label lblQouteSupplierName_3 = (Label)e.Row.FindControl("lblQouteSupplierName_3");
                Label lblQouteLeadDays_3 = (Label)e.Row.FindControl("lblQouteLeadDays_3");
                Label pendingQtyinorder = (Label)e.Row.FindControl("pendingQtyinorder");
                Label lblcolor = (Label)e.Row.FindControl("lblcolor");
                Label lblfabricQty = (Label)e.Row.FindControl("lblfabricQty");
                Label lblFabQtyToOrder = (Label)e.Row.FindControl("lblFabQtyToOrder");
                Label recqty = (Label)e.Row.FindControl("recqty");
                TextBox txtqtytosend = (TextBox)e.Row.FindControl("txtqtytosend");
                Button btnrapo = (Button)e.Row.FindControl("btnrapo");
                TextBox txtGreigeshrk = (TextBox)e.Row.FindControl("txtGreigeshrk");
                TextBox txtResidualShak = (TextBox)e.Row.FindControl("txtResidualShak");
                Label lblcutwastgae = (Label)e.Row.FindControl("lblcutwastgae");
                HtmlGenericControl divraise = e.Row.FindControl("divraise") as HtmlGenericControl;
                GridView grdstylenumber = e.Row.FindControl("grdstylenumber") as GridView;
                Label lblisstylespecific = (Label)e.Row.FindControl("lblisstylespecific");
                HiddenField hdnCurrentstage = (HiddenField)e.Row.FindControl("hdnCurrentstage");
                HiddenField hdnperiviousstgae = (HiddenField)e.Row.FindControl("hdnperiviousstgae");
                HiddenField hdnStyleID = (HiddenField)e.Row.FindControl("hdnStyleID");
                Label lbltotalqtytosend = (Label)e.Row.FindControl("lbltotalqtytosend");
                HiddenField hdnstage1 = (HiddenField)e.Row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)e.Row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)e.Row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)e.Row.FindControl("hdnstage4");


                Label lblfabriccolor = (Label)e.Row.FindControl("lblfabriccolor");
                Label lblFabricQuality = (Label)e.Row.FindControl("lblFabricQuality");
                Label lblgsm = (Label)e.Row.FindControl("lblgsm");
                Label lblcountconstraction = (Label)e.Row.FindControl("lblcountconstraction");
                Label lblwidth = (Label)e.Row.FindControl("lblwidth");
                Label lblrequiredqty = (Label)e.Row.FindControl("lblrequiredqty");
                string ccn = "<span style='color:blue;'>" + lblFabricQuality.Text + "</span><span style='color:gray;'> " + lblgsm.Text + " " + lblcountconstraction.Text + " " + lblwidth.Text + " </span>" + "<br><b style='color:#000;'>" + lblfabriccolor.Text + "</b>";
                string fabdetails = DataBinder.Eval(e.Row.DataItem, "FabricColor").ToString();
                HiddenField hdnadjustmentqty = (HiddenField)e.Row.FindControl("hdnadjustmentqty");
                Label lblBalanceTooltip = (Label)e.Row.FindControl("lblBalanceTooltip");


                if (lblbalanceinhouseqty.Text != "")
                {

                    if (hdnadjustmentqty.Value != "0" && hdnadjustmentqty.Value != "")
                    {
                        lblBalanceTooltip.Text = "Adjustment qty from further stage: <span style='color:yellow'>" + hdnadjustmentqty.Value.ToString() + "</span>";
                        lblBalanceTooltip.CssClass = "TooltipTxt";
                    }
                }

                FabricGroupAdmin.FabricDetailsDayed fabbasic = fabobj.GetFabricRFDDetailsFirst(txtsearchkeyswords.Text.Trim())[e.Row.RowIndex];
                if (fabbasic.CurrentStage > 1)
                {
                    lblcolor.Text = fabbasic.FabricColor;
                }
                else
                {
                    lblcolor.Text = "";
                }

                List<FabricGroupAdmin.FabricContractDetails> FabricRFD = fabobj.GetFabricRFDDetails(fabbasic.FabricQualityID, lblcolor.Text, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, Convert.ToInt16(hdnstage1.Value), Convert.ToInt16(hdnstage2.Value), Convert.ToInt16(hdnstage3.Value), Convert.ToInt16(hdnstage4.Value), Convert.ToInt32(hdnStyleID.Value));
                if (FabricRFD.Count > 0)
                {

                    grdstylenumber.DataSource = FabricRFD;
                    grdstylenumber.DataBind();
                    //lblfabricQty.Text = FabricRFD[0].FabricQty.ToString("N0");
                    lblfabricQty.Text = FabricRFD[0].FinalFabricQtyToOrder.ToString("N0");

                    lblFabQtyToOrder.Text = FabricRFD[0].FinalFabricQtyToOrder.ToString("N0");
                    lblcutwastgae.Text = FabricRFD[0].CuttingWastage.ToString();
                    lbltotalqtytosend.Text = FabricRFD[0].FinalFabricQtyToOrder.ToString("N0");
                    lblrequiredqty.Text = FabricRFD[0].RequiredQty.ToString("N0");
                }

                //MergeRows(grdstylenumber);
                int IsStyelSepecfic = 0;
                if (hdnIsStyleSpecific.Value != null && hdnIsStyleSpecific.Value != "")
                {
                    IsStyelSepecfic = Convert.ToInt32(hdnIsStyleSpecific.Value == "False" ? 0 : 1);
                }
                if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager) || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_TopManagement_Manager))
                {

                    if (hdnIsStyleSpecific.Value != null && hdnIsStyleSpecific.Value != "")
                    {
                        IsStyelSepecfic = Convert.ToInt32(hdnIsStyleSpecific.Value == "False" ? 0 : 1);
                    }
                    //lblfabricQty.Attributes.Add("onclick", "OpenWastageAdminPrint('" + 29 + "','" + hdnfabricQuality.Value + "','" + fabdetails + "','" + hdnCurrentstage.Value + "','" + hdnperiviousstgae.Value + "','" + IsStyelSepecfic + "','" + hdnStyleID.Value + "','" + fabbasic.stage1 + "','" + fabbasic.stage2 + "','" + fabbasic.stage3 + "','" + fabbasic.stage4 + "','" + lblcutwastgae.Text + "');");
                    lblrequiredqty.Attributes.Add("onclick", "OpenWastageAdminPrint('" + 29 + "','" + hdnfabricQuality.Value + "','" + fabdetails + "','" + hdnCurrentstage.Value + "','" + hdnperiviousstgae.Value + "','" + IsStyelSepecfic + "','" + hdnStyleID.Value + "','" + fabbasic.stage1 + "','" + fabbasic.stage2 + "','" + fabbasic.stage3 + "','" + fabbasic.stage4 + "','" + lblcutwastgae.Text + "');");

                }

                if (IsStyelSepecfic == 0)
                {
                    ds = fabobj.GetfabricViewdetails("RFD", "GETTOP3SUPPLIERFAB_RFDNONSTYLE", Convert.ToInt32(hdnfabricQuality.Value), 3, lblcolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, -1, fabbasic.stage1, fabbasic.stage2, fabbasic.stage3, fabbasic.stage4);
                    dt = ds.Tables[0];
                }
                else if (IsStyelSepecfic == 1)
                {
                    ds = fabobj.GetfabricViewdetails("RFD", "GETTOP3SUPPLIERFAB_RFDSTYLE", Convert.ToInt32(hdnfabricQuality.Value), 3, lblcolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, Convert.ToInt32(hdnStyleID.Value), fabbasic.stage1, fabbasic.stage2, fabbasic.stage3, fabbasic.stage4);
                    dt = ds.Tables[0];
                }
                //dtForQuotCheck = ds.Tables[2];
                // dtForQuotCheck = ds.Tables[1];
                string geriege = "0";
                string Residual = "0";
                string cutwastage = "0";
                geriege = txtGreigeshrk.Text;
                Residual = txtResidualShak.Text;
                cutwastage = lblcutwastgae.Text;
                if (txtResidualShak.Text == "0")
                {
                    txtResidualShak.Text = "";
                }

                if (dt.Rows.Count == 3)
                {
                    lblQouteRate_1.Text = "<span style='color: green; font-size: 12px; padding-left:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[0]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[0]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_1.Text = dt.Rows[0]["SupplierName"].ToString();
                    lblQouteLeadDays_1.Text = dt.Rows[0]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")</span>";

                    lblQouteRate_2.Text = "<span style='color: green; font-size: 12px;padding-left:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[1]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[1]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_2.Text = dt.Rows[1]["SupplierName"].ToString();
                    lblQouteLeadDays_2.Text = dt.Rows[1]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")</span>";

                    lblQouteRate_3.Text = "<span style='color: green; font-size: 12px;padding-left:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[2]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[2]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_3.Text = dt.Rows[2]["SupplierName"].ToString();
                    lblQouteLeadDays_3.Text = dt.Rows[2]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")</span>";
                    IcheckHideCol = 1;
                }
                else if (dt.Rows.Count == 2)
                {

                    lblQouteRate_1.Text = "<span style='color: green; font-size: 12px;padding-left:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[0]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[0]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_1.Text = dt.Rows[0]["SupplierName"].ToString();
                    lblQouteLeadDays_1.Text = dt.Rows[0]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")</span>";

                    lblQouteRate_2.Text = "<span style='color: green; font-size: 12px;padding-left:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[1]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[1]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_2.Text = dt.Rows[1]["SupplierName"].ToString();
                    lblQouteLeadDays_2.Text = dt.Rows[1]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")</span>";


                }
                else if (dt.Rows.Count == 1)
                {

                    lblQouteRate_1.Text = "<span style='color: green; font-size: 12px;padding-left:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[0]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[0]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_1.Text = dt.Rows[0]["SupplierName"].ToString();
                    lblQouteLeadDays_1.Text = dt.Rows[0]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")</span>";

                }
                else
                {
                    divraise.Attributes.Add("Class", "HideRaisebtn");
                }

                ds = fabobj.GetfabricViewdetails("RFD", "RERAISESUPPLIER", Convert.ToInt32(hdnfabricQuality.Value), 0, lblcolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, (fabbasic.IsStyleSpecific == true ? Convert.ToInt32(hdnStyleID.Value) : -1), fabbasic.stage1, fabbasic.stage2, fabbasic.stage3, fabbasic.stage4);
                dt = ds.Tables[0];
                DataTable dtremaningqty = ds.Tables[1];
                if (dtremaningqty.Rows.Count > 0)
                {
                    if (dtremaningqty.Rows[0]["RemaningQty"].ToString() != "")
                    {
                        pendingQtyinorder.Text = Convert.ToDecimal(dtremaningqty.Rows[0]["RemaningQty"].ToString()).ToString("N0");
                    }
                }
                if (pendingQtyinorder.Text != "")
                {
                    if (pendingQtyinorder.Text.Replace(",", "") == "0")
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                        pendingQtyinorder.Text = "";
                    }
                    else if (Convert.ToDouble(pendingQtyinorder.Text.Replace(",", "")) <= 0)
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                        //pendingQtyinorder.Text = "";
                    }
                    else
                    {
                        if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager) || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_TopManagement_Manager))
                        {
                            divraise.Attributes.Add("onclick", "ShowpurchasedSupplierForm('" + divraise.ClientID + "','" + hdnfabricQuality.Value + "','" + SupplierMasterID + "','" + 0 + "','" + lblcolor.Text + "','" + geriege + "','" + Residual + "','" + cutwastage + "','" + hdnstage1.Value + "','" + hdnstage2.Value + "','" + hdnstage3.Value + "','" + hdnstage4.Value + "')");
                        }
                        else
                        {
                            //divraise.Attributes.Add("onclick", "alert('You do not have permission');");
                            divraise.Attributes.Add("onclick", "PermissionAlertMsg();");
                            divraise.Attributes.Add("style", "Color:grey");
                        }
                    }
                }
                else
                {
                    divraise.Attributes.Add("Class", "HideRaisebtn");
                    pendingQtyinorder.Text = "";
                }
                if (dt.Rows.Count > 0)
                {


                    // pendingQtyinorder.Text = Convert.ToDecimal(dt.Rows[0]["RemaningQty"].ToString()).ToString("N0");
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                        {
                            sb.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #e2dddd99;'><span class='per'>" + dt.Rows[i]["PO_Number"].ToString() + "</span></td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[12].Text = sb.ToString();
                }
                if (dt.Rows.Count > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                        {
                            sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 40px;'>" + dt.Rows[i]["SupplierName"].ToString() + "</td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[13].Text = sb.ToString();
                }
                if (dt.Rows.Count > 0)
                {
                    int HoldQty = 0;
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                        {
                            string Qty = "";
                            if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                            {
                                Qty = Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()).ToString("N0");
                            }

                            HoldQty = HoldQty + Convert.ToInt32(dt.Rows[i]["HoldQty"].ToString());
                            sb.AppendFormat("<tr><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + Qty + "</td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[14].Text = sb.ToString();
                    pendingQtyinorder.ToolTip = "Hold Qty: " + HoldQty.ToString();
                }

                if (dt.Rows.Count > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        MasterPoID = Convert.ToInt32(dt.Rows[i]["MasterPO_Id"].ToString());
                        SupplierMasterID = Convert.ToInt32(dt.Rows[i]["SupplierID"].ToString());
                        string Qty = "";
                        if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                        {
                            Qty = Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()).ToString("N0");
                        }

                        //sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #999;width: 77px;'>" + "<div class='btnrepo tooltip' onclick=ShowpurchasedSupplierFormReraise('" + hdnfabricQuality.Value + "','" + SupplierMasterID + "','" + MasterPoID + "'); > Re.PO<span class='tooltiptext'>You don't have permission</span></div><img src='../../images/del-butt.png' /></td></tr>");
                        if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 1 || Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 2)
                        {
                            string Status = "";
                            if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 1)
                            {
                                Status = "Canceled";
                            }
                            else if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 2)
                            {
                                Status = "closed";
                            }
                            if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 40px;'>" + "<div style='Color:grey' class=''  > " + Status + "</div></td></tr>");
                            }
                        }
                        else
                        {
                            if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager) || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_TopManagement_Manager))
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div class='btnrepo' onclick='ShowpurchasedSupplierFormReraise(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "&apos;" + lblcolor.Text + "&apos;" + "," + geriege + "," + Residual + "," + cutwastage + "," + "&apos;" + hdnfabricQuality.ClientID + "&apos;" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + ");' > Re.PO</div></td></tr>");
                            }
                            else
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div style='Color:grey' class='btnrepo tooltip'  > Re.PO</div></td></tr>");
                            }
                        }
                    }

                    sb.Append("</table>");
                    e.Row.Cells[15].Text = sb.ToString();
                    decimal Qtys = 0;
                    decimal SQty = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != 1)
                        {
                            if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                            {
                                Qtys += Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString());
                            }
                            if (Convert.ToDecimal(dt.Rows[i]["SendQty"].ToString()) > 0)
                            {
                                if (Convert.ToInt32(hdnstage1.Value) == 29)
                                {

                                }
                                else
                                {
                                    SQty += Convert.ToDecimal(dt.Rows[i]["SendQty"].ToString());
                                }


                            }
                        }


                    }

                    recqty.Text = Math.Round(Qtys, 0).ToString();
                    if (SQty > 0)
                        txtqtytosend.Text = Math.Round(SQty, 0).ToString("N0");
                }
                HtmlAnchor lnkProductionpopup = e.Row.FindControl("lnkProductionpopup") as HtmlAnchor;
                DataSet dsSupplier = new DataSet();
                DataTable dtsupplierQuoted = new DataTable();
                DataTable dtSystemQuoted = new DataTable();

                if (IsStyelSepecfic == 0)
                {
                    ds = fabobj.GetfabricViewdetails("RFD", "GETTOP3SUPPLIER_RFDNONSTYLE", Convert.ToInt32(hdnfabricQuality.Value), 100, lblcolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, -1, fabbasic.stage1, fabbasic.stage2, fabbasic.stage3, fabbasic.stage4);
                    dt = ds.Tables[0];
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtsupplierQuoted = ds.Tables[0];
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        dtSystemQuoted = ds.Tables[1];
                    }

                }
                else if (IsStyelSepecfic == 1)
                {
                    ds = fabobj.GetfabricViewdetails("RFD", "GETTOP3SUPPLIER_RFDSTYLE", Convert.ToInt32(hdnfabricQuality.Value), 100, lblcolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, Convert.ToInt32(hdnStyleID.Value), fabbasic.stage1, fabbasic.stage2, fabbasic.stage3, fabbasic.stage4);


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtsupplierQuoted = ds.Tables[0];
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        dtSystemQuoted = ds.Tables[1];
                    }
                }
                if (dtsupplierQuoted.Rows.Count > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table class='topsupplier'>");
                    sb.AppendFormat("<tr><th colspan='5'  style='background: #39589c !important;color:#fff !important'>All Quotations<span style='float:right;padding-right:10px;cursor: pointer;color:#fff' titel='Close' onclick='HideSupplierDiv();'>X</span></th></tr>");
                    sb.AppendFormat("<tr><th>Fabric Quality (GSM) C&C Width<br> Color/Print</th><th style='display:none;'>Res. Sh.(%)</th><th> Best Quote For Ref.</th><th>Supplier Name</th><th>Quoted Rate &  Lead Time</th></tr>");

                    int x = 0;
                    for (int i = 0; i < dtsupplierQuoted.Rows.Count; i++)
                    {
                        sb.Append("<tr>");
                        if (x <= 0)
                        {
                            System.Text.StringBuilder sbfab = new System.Text.StringBuilder();
                            sb.AppendFormat("<td rowspan='" + dtsupplierQuoted.Rows.Count + "'>");

                            sbfab.Append("<table style='border: none;' class='topsupplier' cellspacing='0' cellpadding='0'>");

                            sbfab.Append("<tr>");
                            sbfab.Append("<TD style='border: none;' rowspan='" + dtsupplierQuoted.Rows.Count + "'>");
                            sbfab.Append(ccn);
                            sbfab.Append("</TD>");
                            sbfab.Append("</tr>");

                            sbfab.Append("<tr>");
                            sbfab.Append("<TD style='border: none;'>");
                            //sbfab.Append(lblcolor.Text.Trim());
                            sbfab.Append("</TD>");
                            sbfab.Append("</tr>");

                            sbfab.Append("</table>");
                            sb.AppendFormat(sbfab.ToString());
                            sb.AppendFormat("</td>");

                        }
                        if (x <= 0)
                        {
                            sb.AppendFormat("<td style='display:none;' rowspan='" + dtsupplierQuoted.Rows.Count + "'>");
                            sb.AppendFormat(dtsupplierQuoted.Rows[0]["GriegeShrinkage"].ToString());
                            sb.AppendFormat("</td>");
                        }
                        if (dtSystemQuoted.Rows.Count > 0)
                        {
                            if (x <= 0)
                            {
                                string ratecon = dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString();
                                string showRate;
                                if (ratecon != " ")
                                {
                                    showRate = "₹  ";
                                }
                                else
                                {
                                    showRate = "";
                                }
                                sb.AppendFormat("<td style='background: lightgreen;' rowspan='" + dtsupplierQuoted.Rows.Count + "'>");
                                sb.AppendFormat("<span style='color: green; font-size: 12px;'>" + showRate + " </span><span style='color:#000'>" + dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString() + "</span>");
                                sb.AppendFormat("</td>");
                            }
                        }

                        sb.AppendFormat("<td>");
                        string dd = dtsupplierQuoted.Rows[i]["Create_Update_Date"].ToString() == "" ? "" : Convert.ToDateTime(dtsupplierQuoted.Rows[i]["Create_Update_Date"].ToString()).ToString("dd MMM yyyy");
                        sb.AppendFormat(dtsupplierQuoted.Rows[i]["SupplierName"].ToString() + " " + "(" + dd + ")");
                        sb.AppendFormat("</td>");

                        string days = "";
                        if (dtsupplierQuoted.Rows[i]["LeadTimes"].ToString() != "" && dtsupplierQuoted.Rows[i]["LeadTimes"].ToString() != "0")
                        {
                            days = "(" + dtsupplierQuoted.Rows[i]["LeadTimes"].ToString() + " Days)";
                        }
                        string str = "";
                        if (dtsupplierQuoted.Rows[i]["QuotedLandedRate"].ToString() != "0")
                            str = "<span style='color: green; font-size: 12px;'>₹ </span><span style='color:#000'>" + dtsupplierQuoted.Rows[i]["QuotedLandedRate"].ToString() + "</span>";
                        else
                            str = "<span style='color: green; font-size: 12px;'> </span>";

                        sb.AppendFormat("<td>");
                        sb.AppendFormat(str + "   " + days);

                        sb.AppendFormat("</td>");


                        x = x + 1;
                        sb.Append("</tr>");
                    }
                    sb.Append("</table>");
                    //lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier(\"" + sb.ToString() + "\")");
                    lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier2(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "'" + lblfabriccolor.Text + "'" + "," + geriege + "," + Residual + "," + cutwastage + "," + "'" + hdnfabricQuality.ClientID + "'" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + "," + "'" + ccn.Replace("'", "") + "'" + ");");
                }
                else
                {
                    //lnkProductionpopup.Style.Add("display", "none;");
                    //lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier(\"" + "empty" + "\")");
                    lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier2(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "'" + lblfabriccolor.Text + "'" + "," + geriege + "," + Residual + "," + cutwastage + "," + "'" + hdnfabricQuality.ClientID + "'" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + "," + "'" + ccn.Replace("'", "") + "'" + ");");
                }



            }


        }
        protected void grdEmbellishment_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                // headerRow1.Attributes.Add("class", "HeaderClass");
                headerRow2.Attributes.Add("class", "HeaderClass");

                TableCell HeaderCell = new TableCell();

                HeaderCell = new TableCell();
                HeaderCell.Text = "<Table><tr><td colspan='3' style='border:0px;'>Fabric Quality (GSM) C&C Width<br>Color/Print (Unit)</td></tr><tr><TD>Current Stage</TD><TD>Previous Stage</TD><TD>Style Specific</TD></tr></table>";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("min-width", "200px");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Style No. (Serial No.)";
                HeaderCell.Style.Add("min-width", "150px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "<Table><tr><td style='border:0px'>Overall to order/send</td></tr><tr><TD>required qty</TD></tr></table>";
                HeaderCell.Style.Add("Width", "60px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Balance <br>In House ";
                HeaderCell.Style.Add("Width", "40px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Total To Send ";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Visible = false;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Total In House ";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Total Send ";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                // if (SupplierCount == 3)
                // {
                HeaderCell = new TableCell();
                HeaderCell.Text = "Quote 1 (Rate & Time)<br>Supplier Name<br>Lead Time";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("Width", "160px");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quote 2 (Rate & Time)<br>Supplier Name<br>Lead Time";
                HeaderCell.Style.Add("Width", "160px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quote 3 (Rate & Time)<br>Supplier Name<br>Lead Time";
                HeaderCell.Style.Add("Width", "160px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Number";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Supplier Name";
                HeaderCell.Style.Add("min-width", "130px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Rcvd. Qty. ";
                HeaderCell.Style.Add("Width", "60px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Revise PO";
                HeaderCell.Attributes.Add("class", "widthAction");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Qty. to Raise PO ";
                HeaderCell.Attributes.Add("class", "widthPending");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                grdEmbellishment.Controls[0].Controls.AddAt(0, headerRow2);
                // grdEmbellishment.Controls[0].Controls.AddAt(0, headerRow1);

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int SupplierMasterID = -1;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataTable dtForQuotCheck = new DataTable();
                DataTable dtfabQty = new DataTable();
                HiddenField hdnfabricQuality = (HiddenField)e.Row.FindControl("hdnfabricQuality");
                HiddenField hdnIsStyleSpecific = (HiddenField)e.Row.FindControl("hdnIsStyleSpecific");
                Label lblfabricorderavg = (Label)e.Row.FindControl("lblfabricorderavg");
                Label lblfabricorderavg2 = (Label)e.Row.FindControl("lblfabricorderavg2");
                Label lblbalanceinhouseqty = (Label)e.Row.FindControl("lblbalanceinhouseqty");
                //  Label lblstyleno = (Label)e.Row.FindControl("lblstyleno");
                Label lblFabQtyRemaning = (Label)e.Row.FindControl("lblFabQtyRemaning");
                Label lblFabQtyRemaning2 = (Label)e.Row.FindControl("lblFabQtyRemaning2");
                Label lblTotalFabRequired = (Label)e.Row.FindControl("lblTotalFabRequired");


                Label lblQouteRate_1 = (Label)e.Row.FindControl("lblQouteRate_1");
                Label lblQouteTime_1 = (Label)e.Row.FindControl("lblQouteTime_1");
                Label lblQouteSupplierName_1 = (Label)e.Row.FindControl("lblQouteSupplierName_1");
                Label lblQouteLeadDays_1 = (Label)e.Row.FindControl("lblQouteLeadDays_1");


                Label lblQouteRate_2 = (Label)e.Row.FindControl("lblQouteRate_2");
                Label lblQouteTime_2 = (Label)e.Row.FindControl("lblQouteTime_2");
                Label lblQouteSupplierName_2 = (Label)e.Row.FindControl("lblQouteSupplierName_2");
                Label lblQouteLeadDays_2 = (Label)e.Row.FindControl("lblQouteLeadDays_2");


                Label lblQouteRate_3 = (Label)e.Row.FindControl("lblQouteRate_3");
                Label lblQouteTime_3 = (Label)e.Row.FindControl("lblQouteTime_3");
                Label lblQouteSupplierName_3 = (Label)e.Row.FindControl("lblQouteSupplierName_3");
                Label lblQouteLeadDays_3 = (Label)e.Row.FindControl("lblQouteLeadDays_3");
                Label pendingQtyinorder = (Label)e.Row.FindControl("pendingQtyinorder");
                Label lblcolor = (Label)e.Row.FindControl("lblcolor");
                Label lblfabricQty = (Label)e.Row.FindControl("lblfabricQty");
                Label lblFabQtyToOrder = (Label)e.Row.FindControl("lblFabQtyToOrder");
                Label recqty = (Label)e.Row.FindControl("recqty");
                TextBox txtqtytosend = (TextBox)e.Row.FindControl("txtqtytosend");
                Button btnrapo = (Button)e.Row.FindControl("btnrapo");
                TextBox txtGreigeshrk = (TextBox)e.Row.FindControl("txtGreigeshrk");
                TextBox txtResidualShak = (TextBox)e.Row.FindControl("txtResidualShak");
                Label lblcutwastgae = (Label)e.Row.FindControl("lblcutwastgae");
                HtmlGenericControl divraise = e.Row.FindControl("divraise") as HtmlGenericControl;
                GridView grdstylenumber = e.Row.FindControl("grdstylenumber") as GridView;
                Label lblisstylespecific = (Label)e.Row.FindControl("lblisstylespecific");
                HiddenField hdnCurrentstage = (HiddenField)e.Row.FindControl("hdnCurrentstage");
                HiddenField hdnperiviousstgae = (HiddenField)e.Row.FindControl("hdnperiviousstgae");
                HiddenField hdnStyleID = (HiddenField)e.Row.FindControl("hdnStyleID");
                Label lbltotalqtytosend = (Label)e.Row.FindControl("lbltotalqtytosend");
                HiddenField hdnstage1 = (HiddenField)e.Row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)e.Row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)e.Row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)e.Row.FindControl("hdnstage4");


                Label lblfabriccolor = (Label)e.Row.FindControl("lblfabriccolor");
                Label lblFabricQuality = (Label)e.Row.FindControl("lblFabricQuality");
                Label lblgsm = (Label)e.Row.FindControl("lblgsm");
                Label lblcountconstraction = (Label)e.Row.FindControl("lblcountconstraction");
                Label lblwidth = (Label)e.Row.FindControl("lblwidth");
                Label lblrequiredqty = (Label)e.Row.FindControl("lblrequiredqty");

                string ccn = "<span style='color:blue'>" + lblFabricQuality.Text + "</span><span style='color:gray'> " + lblgsm.Text + " " + lblcountconstraction.Text + " " + lblwidth.Text + "</span> " + "<br><b style='color:#000;'>" + lblfabriccolor.Text + "</b>";

                HiddenField hdnadjustmentqty = (HiddenField)e.Row.FindControl("hdnadjustmentqty");
                Label lblBalanceTooltip = (Label)e.Row.FindControl("lblBalanceTooltip");
                if (lblbalanceinhouseqty.Text != "")
                {

                    if (hdnadjustmentqty.Value != "0" && hdnadjustmentqty.Value != "")
                    {
                        lblBalanceTooltip.Text = "Adjustment qty from further stage: <span style='color:yellow'>" + hdnadjustmentqty.Value.ToString() + "</span>";
                        lblBalanceTooltip.CssClass = "TooltipTxt";
                    }
                }

                FabricGroupAdmin.FabricDetailsDayed fabbasic = fabobj.GetFabricEmbellishmentDetailsFirst(txtsearchkeyswords.Text.Trim())[e.Row.RowIndex];
                List<FabricGroupAdmin.FabricContractDetails> FabricEmbellishment = fabobj.GetFabricEmbellishmentDetails(fabbasic.FabricQualityID, lblcolor.Text, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, Convert.ToInt16(hdnstage1.Value), Convert.ToInt16(hdnstage2.Value), Convert.ToInt16(hdnstage3.Value), Convert.ToInt16(hdnstage4.Value), Convert.ToInt32(hdnStyleID.Value));
                if (FabricEmbellishment.Count > 0)
                {
                    grdstylenumber.DataSource = FabricEmbellishment;
                    grdstylenumber.DataBind();
                    //lblfabricQty.Text = FabricEmbellishment[0].FabricQty.ToString("N0");
                    lblfabricQty.Text = FabricEmbellishment[0].FinalFabricQtyToOrder.ToString("N0");
                    lblFabQtyToOrder.Text = FabricEmbellishment[0].FinalFabricQtyToOrder.ToString("N0");
                    lblcutwastgae.Text = FabricEmbellishment[0].CuttingWastage.ToString();
                    lbltotalqtytosend.Text = FabricEmbellishment[0].FinalFabricQtyToOrder.ToString("N0");
                    lblrequiredqty.Text = FabricEmbellishment[0].RequiredQty.ToString("N0");
                }

                //MergeRows(grdstylenumber);
                int IsStyelSepecfic = 0;
                if (hdnIsStyleSpecific.Value != null && hdnIsStyleSpecific.Value != "")
                {
                    IsStyelSepecfic = Convert.ToInt32(hdnIsStyleSpecific.Value == "False" ? 0 : 1);
                }
                if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager) || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_TopManagement_Manager))
                {

                    if (hdnIsStyleSpecific.Value != null && hdnIsStyleSpecific.Value != "")
                    {
                        IsStyelSepecfic = Convert.ToInt32(hdnIsStyleSpecific.Value == "False" ? 0 : 1);
                    }
                    //lblfabricQty.Attributes.Add("onclick", "OpenWastageAdminPrint('" + 30 + "','" + hdnfabricQuality.Value + "','" + lblcolor.Text.Trim() + "','" + hdnCurrentstage.Value + "','" + hdnperiviousstgae.Value + "','" + IsStyelSepecfic + "','" + hdnStyleID.Value + "','" + fabbasic.stage1 + "','" + fabbasic.stage2 + "','" + fabbasic.stage3 + "','" + fabbasic.stage4 + "','" + lblcutwastgae.Text + "');");
                    lblrequiredqty.Attributes.Add("onclick", "OpenWastageAdminPrint('" + 30 + "','" + hdnfabricQuality.Value + "','" + lblcolor.Text.Trim() + "','" + hdnCurrentstage.Value + "','" + hdnperiviousstgae.Value + "','" + IsStyelSepecfic + "','" + hdnStyleID.Value + "','" + fabbasic.stage1 + "','" + fabbasic.stage2 + "','" + fabbasic.stage3 + "','" + fabbasic.stage4 + "','" + lblcutwastgae.Text + "');");
                }

                if (IsStyelSepecfic == 0)
                {
                    ds = fabobj.GetfabricViewdetails("Embellishment", "GETTOP3SUPPLIER_EmbellishmentNONSTYLE", Convert.ToInt32(hdnfabricQuality.Value), 3, lblcolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, -1, fabbasic.stage1, fabbasic.stage2, fabbasic.stage3, fabbasic.stage4);
                    dt = ds.Tables[0];
                }
                else if (IsStyelSepecfic == 1)
                {
                    ds = fabobj.GetfabricViewdetails("Embellishment", "GETTOP3SUPPLIER_EmbellishmentSTYLE", Convert.ToInt32(hdnfabricQuality.Value), 3, lblcolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, Convert.ToInt32(hdnStyleID.Value), fabbasic.stage1, fabbasic.stage2, fabbasic.stage3, fabbasic.stage4);
                    dt = ds.Tables[0];
                }
                //dtForQuotCheck = ds.Tables[2];
                // dtForQuotCheck = ds.Tables[1];
                string geriege = "0";
                string Residual = "0";
                string cutwastage = "0";
                geriege = txtGreigeshrk.Text;
                Residual = txtResidualShak.Text;
                cutwastage = lblcutwastgae.Text;
                if (txtResidualShak.Text == "0")
                {
                    txtResidualShak.Text = "";
                }

                if (dt.Rows.Count == 3)
                {
                    lblQouteRate_1.Text = "<span style='color: green; font-size: 12px; padding-left:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[0]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[0]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_1.Text = dt.Rows[0]["SupplierName"].ToString();
                    lblQouteLeadDays_1.Text = dt.Rows[0]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")</span>";

                    lblQouteRate_2.Text = "<span style='color: green; font-size: 12px;padding-left:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[1]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[1]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_2.Text = dt.Rows[1]["SupplierName"].ToString();
                    lblQouteLeadDays_2.Text = dt.Rows[1]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")</span>";

                    lblQouteRate_3.Text = "<span style='color: green; font-size: 12px;padding-left:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[2]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[2]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_3.Text = dt.Rows[2]["SupplierName"].ToString();
                    lblQouteLeadDays_3.Text = dt.Rows[2]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")</span>";
                    IcheckHideCol = 1;
                }
                else if (dt.Rows.Count == 2)
                {

                    lblQouteRate_1.Text = "<span style='color: green; font-size: 12px;padding-left:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[0]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[0]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_1.Text = dt.Rows[0]["SupplierName"].ToString();
                    lblQouteLeadDays_1.Text = dt.Rows[0]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")</span>";

                    lblQouteRate_2.Text = "<span style='color: green; font-size: 12px;padding-left:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[1]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[1]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_2.Text = dt.Rows[1]["SupplierName"].ToString();
                    lblQouteLeadDays_2.Text = dt.Rows[1]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")</span>";


                }
                else if (dt.Rows.Count == 1)
                {

                    lblQouteRate_1.Text = "<span style='color: green; font-size: 12px;padding-left:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[0]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[0]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_1.Text = dt.Rows[0]["SupplierName"].ToString();
                    lblQouteLeadDays_1.Text = dt.Rows[0]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")</span>";

                }
                else
                {
                    divraise.Attributes.Add("Class", "HideRaisebtn");
                }

                ds = fabobj.GetfabricViewdetails("Embellishment", "RERAISESUPPLIER", Convert.ToInt32(hdnfabricQuality.Value), 0, lblcolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, Convert.ToInt32(hdnStyleID.Value), fabbasic.stage1, fabbasic.stage2, fabbasic.stage3, fabbasic.stage4);
                dt = ds.Tables[0];
                DataTable dtremaningqty = ds.Tables[1];
                if (dtremaningqty.Rows.Count > 0)
                {
                    if (dtremaningqty.Rows[0]["RemaningQty"].ToString() != "")
                    {
                        pendingQtyinorder.Text = Convert.ToDecimal(dtremaningqty.Rows[0]["RemaningQty"].ToString()).ToString("N0");
                    }
                }
                if (pendingQtyinorder.Text != "")
                {
                    if (pendingQtyinorder.Text.Replace(",", "") == "0")
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                        pendingQtyinorder.Text = "";
                    }
                    else if (Convert.ToDouble(pendingQtyinorder.Text.Replace(",", "")) <= 0)
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                        //pendingQtyinorder.Text = "";
                    }
                    else
                    {
                        if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager) || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_TopManagement_Manager))
                        {
                            divraise.Attributes.Add("onclick", "ShowpurchasedSupplierForm('" + divraise.ClientID + "','" + hdnfabricQuality.Value + "','" + SupplierMasterID + "','" + 0 + "','" + lblcolor.Text + "','" + geriege + "','" + Residual + "','" + cutwastage + "','" + hdnstage1.Value + "','" + hdnstage2.Value + "','" + hdnstage3.Value + "','" + hdnstage4.Value + "')");
                        }
                        else
                        {
                            //divraise.Attributes.Add("onclick", "alert('You do not have permission');");
                            divraise.Attributes.Add("onclick", "PermissionAlertMsg();");
                            divraise.Attributes.Add("style", "Color:grey");
                        }
                    }
                }
                else
                {
                    divraise.Attributes.Add("Class", "HideRaisebtn");
                    pendingQtyinorder.Text = "";
                }

                if (dt.Rows.Count > 0)
                {


                    // pendingQtyinorder.Text = Convert.ToDecimal(dt.Rows[0]["RemaningQty"].ToString()).ToString("N0");
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                        {
                            sb.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #e2dddd99;'><span class='per'>" + dt.Rows[i]["PO_Number"].ToString() + "</span></td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[12].Text = sb.ToString();
                }
                if (dt.Rows.Count > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                        {
                            sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 40px;'>" + dt.Rows[i]["SupplierName"].ToString() + "</td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[13].Text = sb.ToString();
                }
                if (dt.Rows.Count > 0)
                {
                    int HoldQty = 0;
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                        {
                            string Qty = "";
                            if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                            {
                                Qty = Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()).ToString("N0");
                            }
                            HoldQty = HoldQty + Convert.ToInt32(dt.Rows[i]["HoldQty"].ToString());
                            sb.AppendFormat("<tr><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + Qty + "</td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[14].Text = sb.ToString();
                    pendingQtyinorder.ToolTip = "Hold Qty: " + HoldQty.ToString();
                }

                if (dt.Rows.Count > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        MasterPoID = Convert.ToInt32(dt.Rows[i]["MasterPO_Id"].ToString());
                        SupplierMasterID = Convert.ToInt32(dt.Rows[i]["SupplierID"].ToString());
                        string Qty = "";
                        if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                        {
                            Qty = Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()).ToString("N0");
                        }

                        //sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #999;width: 77px;'>" + "<div class='btnrepo tooltip' onclick=ShowpurchasedSupplierFormReraise('" + hdnfabricQuality.Value + "','" + SupplierMasterID + "','" + MasterPoID + "'); > Re.PO<span class='tooltiptext'>You don't have permission</span></div><img src='../../images/del-butt.png' /></td></tr>");
                        if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 1 || Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 2)
                        {
                            string Status = "";
                            if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 1)
                            {
                                Status = "Canceled";
                            }
                            else if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 2)
                            {
                                Status = "closed";
                            }

                            if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 40px;'>" + "<div style='Color:grey' class=''  > " + Status + "</div></td></tr>");
                            }
                        }
                        else
                        {
                            if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager) || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_TopManagement_Manager))
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div class='btnrepo' onclick='ShowpurchasedSupplierFormReraise(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "&apos;" + lblcolor.Text + "&apos;" + "," + geriege + "," + Residual + "," + cutwastage + "," + "&apos;" + hdnfabricQuality.ClientID + "&apos;" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + ");' > Re.PO</div></td></tr>");
                            }
                            else
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div style='Color:grey' class='btnrepo tooltip'  > Re.PO</div></td></tr>");
                            }
                        }
                    }

                    sb.Append("</table>");
                    e.Row.Cells[15].Text = sb.ToString();
                    decimal Qtys = 0;
                    decimal SQty = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != 1)
                        {

                            if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                            {
                                Qtys += Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString());
                            }
                            if (Convert.ToDecimal(dt.Rows[i]["SendQty"].ToString()) > 0)
                            {
                                SQty += Convert.ToDecimal(dt.Rows[i]["SendQty"].ToString());
                            }
                        }
                    }
                    recqty.Text = Math.Round(Qtys, 0).ToString();
                    txtqtytosend.Text = Math.Round(SQty, 0).ToString("N0");
                }

                HtmlAnchor lnkProductionpopup = e.Row.FindControl("lnkProductionpopup") as HtmlAnchor;
                DataSet dsSupplier = new DataSet();
                DataTable dtsupplierQuoted = new DataTable();
                DataTable dtSystemQuoted = new DataTable();

                if (IsStyelSepecfic == 0)
                {
                    ds = fabobj.GetfabricViewdetails("Embellishment", "GETTOP3SUPPLIER_EmbellishmentNONSTYLE", Convert.ToInt32(hdnfabricQuality.Value), 100, lblcolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, -1, fabbasic.stage1, fabbasic.stage2, fabbasic.stage3, fabbasic.stage4);
                    dt = ds.Tables[0];
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtsupplierQuoted = ds.Tables[0];
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        dtSystemQuoted = ds.Tables[1];
                    }

                }
                else if (IsStyelSepecfic == 1)
                {
                    ds = fabobj.GetfabricViewdetails("Embellishment", "GETTOP3SUPPLIER_EmbellishmentSTYLE", Convert.ToInt32(hdnfabricQuality.Value), 100, lblcolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, Convert.ToInt32(hdnStyleID.Value), fabbasic.stage1, fabbasic.stage2, fabbasic.stage3, fabbasic.stage4);


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtsupplierQuoted = ds.Tables[0];
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        dtSystemQuoted = ds.Tables[1];
                    }
                }
                if (dtsupplierQuoted.Rows.Count > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table class='topsupplier'>");
                    sb.AppendFormat("<tr><th colspan='5'  style='background: #39589c !important;color:#fff !important'>All Quotations<span style='float:right;padding-right:10px;cursor: pointer;color:#fff' titel='Close' onclick='HideSupplierDiv();'>X</span></th></tr>");
                    sb.AppendFormat("<tr><th>Fabric Quality (GSM) C&C Width<br> Color/Print</th><th style='display:none;'>Res. Sh.(%)</th><th> Best Quote For Ref.</th><th>Supplier Name</th><th>Quoted Rate &  Lead Time</th></tr>");

                    int x = 0;
                    for (int i = 0; i < dtsupplierQuoted.Rows.Count; i++)
                    {
                        sb.Append("<tr>");
                        if (x <= 0)
                        {
                            System.Text.StringBuilder sbfab = new System.Text.StringBuilder();
                            sb.AppendFormat("<td rowspan='" + dtsupplierQuoted.Rows.Count + "'>");

                            sbfab.Append("<table style='border: none;' class='topsupplier' cellspacing='0' cellpadding='0'>");

                            sbfab.Append("<tr>");
                            sbfab.Append("<TD style='border: none;' rowspan='" + dtsupplierQuoted.Rows.Count + "'>");
                            sbfab.Append(ccn);
                            sbfab.Append("</TD>");
                            sbfab.Append("</tr>");

                            sbfab.Append("<tr>");
                            sbfab.Append("<TD style='border: none;'>");
                            //sbfab.Append(lblcolor.Text.Trim());
                            sbfab.Append("</TD>");
                            sbfab.Append("</tr>");

                            sbfab.Append("</table>");
                            sb.AppendFormat(sbfab.ToString());
                            sb.AppendFormat("</td>");

                        }
                        if (x <= 0)
                        {
                            sb.AppendFormat("<td style='display:none;' rowspan='" + dtsupplierQuoted.Rows.Count + "'>");
                            sb.AppendFormat(dtsupplierQuoted.Rows[0]["GriegeShrinkage"].ToString());
                            sb.AppendFormat("</td>");
                        }
                        if (dtSystemQuoted.Rows.Count > 0)
                        {
                            if (x <= 0)
                            {
                                sb.AppendFormat("<td style='background: lightgreen;' rowspan='" + dtsupplierQuoted.Rows.Count + "'>");
                                sb.AppendFormat("<span style='color: green; font-size: 12px;'>₹ </span><span style='color:#000'>" + dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString() + "</span>");
                                sb.AppendFormat("</td>");
                            }
                        }

                        sb.AppendFormat("<td>");
                        string dd = dtsupplierQuoted.Rows[i]["Create_Update_Date"].ToString() == "" ? "" : Convert.ToDateTime(dtsupplierQuoted.Rows[i]["Create_Update_Date"].ToString()).ToString("dd MMM yyyy");
                        sb.AppendFormat(dtsupplierQuoted.Rows[i]["SupplierName"].ToString() + " " + "(" + dd + ")");
                        sb.AppendFormat("</td>");

                        string days = "";
                        if (dtsupplierQuoted.Rows[i]["LeadTimes"].ToString() != "" && dtsupplierQuoted.Rows[i]["LeadTimes"].ToString() != "0")
                        {
                            days = "(" + dtsupplierQuoted.Rows[i]["LeadTimes"].ToString() + " Days)";
                        }
                        string str = "";
                        if (dtsupplierQuoted.Rows[i]["QuotedLandedRate"].ToString() != "0")
                            str = "<span style='color: green; font-size: 12px;'>₹ </span><span style='color:#000'>" + dtsupplierQuoted.Rows[i]["QuotedLandedRate"].ToString() + "</span>";
                        else
                            str = "<span style='color: green; font-size: 12px;'> </span>";

                        sb.AppendFormat("<td>");
                        sb.AppendFormat(str + "   " + days);

                        sb.AppendFormat("</td>");


                        x = x + 1;
                        sb.Append("</tr>");
                    }
                    sb.Append("</table>");
                    //lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier(\"" + sb.ToString() + "\")");
                    lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier2(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "'" + lblfabriccolor.Text + "'" + "," + geriege + "," + Residual + "," + cutwastage + "," + "'" + hdnfabricQuality.ClientID + "'" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + "," + "'" + ccn.Replace("'", "") + "'" + ");");
                }
                else
                {
                    //lnkProductionpopup.Style.Add("display", "none;");
                    //lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier(\"" + "empty" + "\")");
                    lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier2(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "'" + lblfabriccolor.Text + "'" + "," + geriege + "," + Residual + "," + cutwastage + "," + "'" + hdnfabricQuality.ClientID + "'" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + "," + "'" + ccn.Replace("'", "") + "'" + ");");
                }



            }


        }
        protected void grdEmbroidery_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                headerRow1.Attributes.Add("class", "HeaderClass");
                headerRow2.Attributes.Add("class", "HeaderClass");

                TableCell HeaderCell = new TableCell();

                HeaderCell = new TableCell();
                HeaderCell.Text = "<Table><tr><td colspan='3' style='border:0px;'>Fabric Quality (GSM) C&C Width<br>Color/Print (Unit)</td></tr><tr><TD>Current Stage</TD><TD>Previous Stage</TD><TD>Style Specific</TD></tr></table>";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("min-width", "200px");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Style No. (Serial No.)";
                HeaderCell.Style.Add("min-width", "150px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "<Table><tr><td style='border:0px'>Overall to order/send</td></tr><tr><TD>required qty</TD></tr></table>";
                HeaderCell.Style.Add("Width", "60px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Balance <br>In House ";
                HeaderCell.Style.Add("Width", "40px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Total To Send ";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Visible = false;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Total In House ";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Total Send ";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Quote 1 (Rate & Time)<br>Supplier Name<br>Lead Time";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Style.Add("Width", "160px");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quote 2 (Rate & Time)<br>Supplier Name<br>Lead Time";
                HeaderCell.Style.Add("Width", "160px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quote 3 (Rate & Time)<br>Supplier Name<br>Lead Time";
                HeaderCell.Style.Add("Width", "160px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Number";
                HeaderCell.Style.Add("Width", "80px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Supplier Name";
                HeaderCell.Style.Add("min-width", "130px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Rcvd. Qty. ";
                HeaderCell.Style.Add("Width", "60px");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Revise PO";
                HeaderCell.Attributes.Add("class", "widthAction");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Qty. to Raise PO";
                HeaderCell.Attributes.Add("class", "widthPending");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                grdEmbroidery.Controls[0].Controls.AddAt(0, headerRow2);
                // grdEmbroidery.Controls[0].Controls.AddAt(0, headerRow1);

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int SupplierMasterID = -1;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataTable dtForQuotCheck = new DataTable();
                DataTable dtfabQty = new DataTable();
                HiddenField hdnfabricQuality = (HiddenField)e.Row.FindControl("hdnfabricQuality");
                HiddenField hdnIsStyleSpecific = (HiddenField)e.Row.FindControl("hdnIsStyleSpecific");
                Label lblfabricorderavg = (Label)e.Row.FindControl("lblfabricorderavg");
                Label lblfabricorderavg2 = (Label)e.Row.FindControl("lblfabricorderavg2");
                Label lblbalanceinhouseqty = (Label)e.Row.FindControl("lblbalanceinhouseqty");
                //  Label lblstyleno = (Label)e.Row.FindControl("lblstyleno");
                Label lblFabQtyRemaning = (Label)e.Row.FindControl("lblFabQtyRemaning");
                Label lblFabQtyRemaning2 = (Label)e.Row.FindControl("lblFabQtyRemaning2");
                Label lblTotalFabRequired = (Label)e.Row.FindControl("lblTotalFabRequired");


                Label lblQouteRate_1 = (Label)e.Row.FindControl("lblQouteRate_1");
                Label lblQouteTime_1 = (Label)e.Row.FindControl("lblQouteTime_1");
                Label lblQouteSupplierName_1 = (Label)e.Row.FindControl("lblQouteSupplierName_1");
                Label lblQouteLeadDays_1 = (Label)e.Row.FindControl("lblQouteLeadDays_1");


                Label lblQouteRate_2 = (Label)e.Row.FindControl("lblQouteRate_2");
                Label lblQouteTime_2 = (Label)e.Row.FindControl("lblQouteTime_2");
                Label lblQouteSupplierName_2 = (Label)e.Row.FindControl("lblQouteSupplierName_2");
                Label lblQouteLeadDays_2 = (Label)e.Row.FindControl("lblQouteLeadDays_2");


                Label lblQouteRate_3 = (Label)e.Row.FindControl("lblQouteRate_3");
                Label lblQouteTime_3 = (Label)e.Row.FindControl("lblQouteTime_3");
                Label lblQouteSupplierName_3 = (Label)e.Row.FindControl("lblQouteSupplierName_3");
                Label lblQouteLeadDays_3 = (Label)e.Row.FindControl("lblQouteLeadDays_3");
                Label pendingQtyinorder = (Label)e.Row.FindControl("pendingQtyinorder");
                Label lblcolor = (Label)e.Row.FindControl("lblcolor");
                Label lblfabricQty = (Label)e.Row.FindControl("lblfabricQty");
                Label lblFabQtyToOrder = (Label)e.Row.FindControl("lblFabQtyToOrder");
                Label recqty = (Label)e.Row.FindControl("recqty");
                TextBox txtqtytosend = (TextBox)e.Row.FindControl("txtqtytosend");
                Button btnrapo = (Button)e.Row.FindControl("btnrapo");
                TextBox txtGreigeshrk = (TextBox)e.Row.FindControl("txtGreigeshrk");
                TextBox txtResidualShak = (TextBox)e.Row.FindControl("txtResidualShak");
                Label lblcutwastgae = (Label)e.Row.FindControl("lblcutwastgae");
                HtmlGenericControl divraise = e.Row.FindControl("divraise") as HtmlGenericControl;
                GridView grdstylenumber = e.Row.FindControl("grdstylenumber") as GridView;
                Label lblisstylespecific = (Label)e.Row.FindControl("lblisstylespecific");
                HiddenField hdnCurrentstage = (HiddenField)e.Row.FindControl("hdnCurrentstage");
                HiddenField hdnperiviousstgae = (HiddenField)e.Row.FindControl("hdnperiviousstgae");
                HiddenField hdnStyleID = (HiddenField)e.Row.FindControl("hdnStyleID");
                Label lbltotalqtytosend = (Label)e.Row.FindControl("lbltotalqtytosend");
                HiddenField hdnstage1 = (HiddenField)e.Row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)e.Row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)e.Row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)e.Row.FindControl("hdnstage4");


                Label lblfabriccolor = (Label)e.Row.FindControl("lblfabriccolor");
                Label lblFabricQuality = (Label)e.Row.FindControl("lblFabricQuality");
                Label lblgsm = (Label)e.Row.FindControl("lblgsm");
                Label lblcountconstraction = (Label)e.Row.FindControl("lblcountconstraction");
                Label lblwidth = (Label)e.Row.FindControl("lblwidth");
                Label lblrequiredqty = (Label)e.Row.FindControl("lblrequiredqty");
                string ccn = "<span style='color:blue;'>" + lblFabricQuality.Text + "</span><span style='color:gray;'> " + lblgsm.Text + " " + lblcountconstraction.Text + " " + lblwidth.Text + " </span>" + "<br><b style='color:#000;'>" + lblfabriccolor.Text + "</b>";
                HiddenField hdnadjustmentqty = (HiddenField)e.Row.FindControl("hdnadjustmentqty");
                Label lblBalanceTooltip = (Label)e.Row.FindControl("lblBalanceTooltip");
                if (lblbalanceinhouseqty.Text != "")
                {

                    if (hdnadjustmentqty.Value != "0" && hdnadjustmentqty.Value != "")
                    {
                        lblBalanceTooltip.Text = "Adjustment qty from further stage: <span style='color:yellow'>" + hdnadjustmentqty.Value.ToString() + "</span>";
                        lblBalanceTooltip.CssClass = "TooltipTxt";
                    }
                }
                FabricGroupAdmin.FabricDetailsDayed fabbasic = fabobj.GetFabricEmbroideryDetailsFirst(txtsearchkeyswords.Text.Trim())[e.Row.RowIndex];
                List<FabricGroupAdmin.FabricContractDetails> FabricEmbroidery = fabobj.GetFabricEmbroideryDetails(fabbasic.FabricQualityID, lblcolor.Text, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, Convert.ToInt16(hdnstage1.Value), Convert.ToInt16(hdnstage2.Value), Convert.ToInt16(hdnstage3.Value), Convert.ToInt16(hdnstage4.Value), Convert.ToInt32(hdnStyleID.Value));
                if (FabricEmbroidery.Count > 0)
                {
                    grdstylenumber.DataSource = FabricEmbroidery;
                    grdstylenumber.DataBind();
                    //lblfabricQty.Text = FabricEmbroidery[0].FabricQty.ToString("N0");
                    lblfabricQty.Text = FabricEmbroidery[0].FinalFabricQtyToOrder.ToString("N0");
                    lblFabQtyToOrder.Text = FabricEmbroidery[0].FinalFabricQtyToOrder.ToString("N0");
                    lblcutwastgae.Text = FabricEmbroidery[0].CuttingWastage.ToString();
                    lbltotalqtytosend.Text = FabricEmbroidery[0].FinalFabricQtyToOrder.ToString("N0");
                    lblrequiredqty.Text = FabricEmbroidery[0].RequiredQty.ToString("N0");
                }

                //MergeRows(grdstylenumber);
                int IsStyelSepecfic = 0;
                if (hdnIsStyleSpecific.Value != null && hdnIsStyleSpecific.Value != "")
                {
                    IsStyelSepecfic = Convert.ToInt32(hdnIsStyleSpecific.Value == "False" ? 0 : 1);
                }
                if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager) || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_TopManagement_Manager))
                {

                    if (hdnIsStyleSpecific.Value != null && hdnIsStyleSpecific.Value != "")
                    {
                        IsStyelSepecfic = Convert.ToInt32(hdnIsStyleSpecific.Value == "False" ? 0 : 1);
                    }
                    //lblfabricQty.Attributes.Add("onclick", "OpenWastageAdminPrint('" + 31 + "','" + hdnfabricQuality.Value + "','" + lblcolor.Text.Trim() + "','" + hdnCurrentstage.Value + "','" + hdnperiviousstgae.Value + "','" + IsStyelSepecfic + "','" + hdnStyleID.Value + "','" + fabbasic.stage1 + "','" + fabbasic.stage2 + "','" + fabbasic.stage3 + "','" + fabbasic.stage4 + "','" + lblcutwastgae.Text + "');");
                    lblrequiredqty.Attributes.Add("onclick", "OpenWastageAdminPrint('" + 31 + "','" + hdnfabricQuality.Value + "','" + lblcolor.Text.Trim() + "','" + hdnCurrentstage.Value + "','" + hdnperiviousstgae.Value + "','" + IsStyelSepecfic + "','" + hdnStyleID.Value + "','" + fabbasic.stage1 + "','" + fabbasic.stage2 + "','" + fabbasic.stage3 + "','" + fabbasic.stage4 + "','" + lblcutwastgae.Text + "');");
                }

                if (IsStyelSepecfic == 0)
                {
                    ds = fabobj.GetfabricViewdetails("Embroidery", "GETTOP3SUPPLIER_EmbroideryNONSTYLE", Convert.ToInt32(hdnfabricQuality.Value), 3, lblcolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, -1, fabbasic.stage1, fabbasic.stage2, fabbasic.stage3, fabbasic.stage4);
                    dt = ds.Tables[0];
                }
                else if (IsStyelSepecfic == 1)
                {
                    ds = fabobj.GetfabricViewdetails("Embroidery", "GETTOP3SUPPLIER_EmbroiderySTYLE", Convert.ToInt32(hdnfabricQuality.Value), 3, lblcolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, Convert.ToInt32(hdnStyleID.Value), fabbasic.stage1, fabbasic.stage2, fabbasic.stage3, fabbasic.stage4);
                    dt = ds.Tables[0];
                }
                //dtForQuotCheck = ds.Tables[2];
                // dtForQuotCheck = ds.Tables[1];
                string geriege = "0";
                string Residual = "0";
                string cutwastage = "0";
                geriege = txtGreigeshrk.Text;
                Residual = txtResidualShak.Text;
                cutwastage = lblcutwastgae.Text;
                if (txtResidualShak.Text == "0")
                {
                    txtResidualShak.Text = "";
                }

                if (dt.Rows.Count == 3)
                {
                    lblQouteRate_1.Text = "<span style='color: green; font-size: 12px; padding-left:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[0]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[0]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_1.Text = dt.Rows[0]["SupplierName"].ToString();
                    lblQouteLeadDays_1.Text = dt.Rows[0]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")</span>";

                    lblQouteRate_2.Text = "<span style='color: green; font-size: 12px;padding-left:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[1]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[1]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_2.Text = dt.Rows[1]["SupplierName"].ToString();
                    lblQouteLeadDays_2.Text = dt.Rows[1]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")</span>";

                    lblQouteRate_3.Text = "<span style='color: green; font-size: 12px;padding-left:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[2]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[2]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_3.Text = dt.Rows[2]["SupplierName"].ToString();
                    lblQouteLeadDays_3.Text = dt.Rows[2]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")</span>";
                    IcheckHideCol = 1;
                }
                else if (dt.Rows.Count == 2)
                {

                    lblQouteRate_1.Text = "<span style='color: green; font-size: 12px;padding-left:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[0]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[0]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_1.Text = dt.Rows[0]["SupplierName"].ToString();
                    lblQouteLeadDays_1.Text = dt.Rows[0]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")</span>";

                    lblQouteRate_2.Text = "<span style='color: green; font-size: 12px;padding-left:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[1]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[1]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_2.Text = dt.Rows[1]["SupplierName"].ToString();
                    lblQouteLeadDays_2.Text = dt.Rows[1]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")</span>";


                }
                else if (dt.Rows.Count == 1)
                {

                    lblQouteRate_1.Text = "<span style='color: green; font-size: 12px;padding-left:3px;position:relative;top:1px'>₹</span><span style='color:#000'>" + dt.Rows[0]["QuotedLandedRate"].ToString() + "</span><span class='gray'> (" + dt.Rows[0]["times"].ToString() + ")</span>";
                    lblQouteSupplierName_1.Text = dt.Rows[0]["SupplierName"].ToString();
                    lblQouteLeadDays_1.Text = dt.Rows[0]["LeadTimes"].ToString() + "<span class='gray'> (" + "Days" + ")</span>";

                }
                else
                {
                    divraise.Attributes.Add("Class", "HideRaisebtn");
                }

                ds = fabobj.GetfabricViewdetails("Embroidery", "RERAISESUPPLIER", Convert.ToInt32(hdnfabricQuality.Value), 0, lblcolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, Convert.ToInt32(hdnStyleID.Value), fabbasic.stage1, fabbasic.stage2, fabbasic.stage3, fabbasic.stage4);
                dt = ds.Tables[0];
                DataTable dtremaningqty = ds.Tables[1];
                if (dtremaningqty.Rows.Count > 0)
                {
                    if (dtremaningqty.Rows[0]["RemaningQty"].ToString() != "")
                    {
                        pendingQtyinorder.Text = Convert.ToDecimal(dtremaningqty.Rows[0]["RemaningQty"].ToString()).ToString("N0");
                    }
                }
                if (pendingQtyinorder.Text != "")
                {
                    if (pendingQtyinorder.Text.Replace(",", "") == "0")
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                        pendingQtyinorder.Text = "";
                    }
                    else if (Convert.ToDouble(pendingQtyinorder.Text.Replace(",", "")) <= 0)
                    {
                        divraise.Attributes.Add("Class", "HideRaisebtn");
                        //pendingQtyinorder.Text = "";
                    }
                    else
                    {
                        if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager) || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_TopManagement_Manager))
                        {
                            divraise.Attributes.Add("onclick", "ShowpurchasedSupplierForm('" + divraise.ClientID + "','" + hdnfabricQuality.Value + "','" + SupplierMasterID + "','" + 0 + "','" + lblcolor.Text + "','" + geriege + "','" + Residual + "','" + cutwastage + "','" + hdnstage1.Value + "','" + hdnstage2.Value + "','" + hdnstage3.Value + "','" + hdnstage4.Value + "')");
                        }
                        else
                        {
                            //divraise.Attributes.Add("onclick", "alert('You do not have permission');");
                            divraise.Attributes.Add("onclick", "PermissionAlertMsg();");
                            divraise.Attributes.Add("style", "Color:grey");
                        }
                    }
                }
                else
                {
                    divraise.Attributes.Add("Class", "HideRaisebtn");
                    pendingQtyinorder.Text = "";
                }

                if (dt.Rows.Count > 0)
                {


                    // pendingQtyinorder.Text = Convert.ToDecimal(dt.Rows[0]["RemaningQty"].ToString()).ToString("N0");
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                        {
                            sb.AppendFormat("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #e2dddd99;'><span class='per'>" + dt.Rows[i]["PO_Number"].ToString() + "</span></td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[12].Text = sb.ToString();
                }
                if (dt.Rows.Count > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                        {
                            sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 40px;'>" + dt.Rows[i]["SupplierName"].ToString() + "</td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[13].Text = sb.ToString();
                }
                if (dt.Rows.Count > 0)
                {
                    int HoldQty = 0;
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                        {
                            string Qty = "";
                            if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                            {
                                Qty = Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()).ToString("N0");
                            }
                            HoldQty = HoldQty + Convert.ToInt32(dt.Rows[i]["HoldQty"].ToString());
                            sb.AppendFormat("<tr><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + Qty + "</td></tr>");
                        }
                    }
                    sb.Append("</table>");
                    e.Row.Cells[14].Text = sb.ToString();

                    pendingQtyinorder.ToolTip = "Hold Qty: " + HoldQty.ToString();
                }

                if (dt.Rows.Count > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table id='data' class='process'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        MasterPoID = Convert.ToInt32(dt.Rows[i]["MasterPO_Id"].ToString());
                        SupplierMasterID = Convert.ToInt32(dt.Rows[i]["SupplierID"].ToString());
                        string Qty = "";
                        if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                        {
                            Qty = Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()).ToString("N0");
                        }

                        //sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #999;width: 77px;'>" + "<div class='btnrepo tooltip' onclick=ShowpurchasedSupplierFormReraise('" + hdnfabricQuality.Value + "','" + SupplierMasterID + "','" + MasterPoID + "'); > Re.PO<span class='tooltiptext'>You don't have permission</span></div><img src='../../images/del-butt.png' /></td></tr>");
                        if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 1 || Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 2)
                        {
                            string Status = "";
                            if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 1)
                            {
                                Status = "Canceled";
                            }
                            else if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) == 2)
                            {
                                Status = "closed";
                            }
                            if ((FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Cancel && (FabricPOStatus)Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != FabricPOStatus.Close)
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 40px;'>" + "<div style='Color:grey' class=''  > " + Status + "</div></td></tr>");
                            }
                        }
                        else
                        {
                            if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager) || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_TopManagement_Manager))
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div class='btnrepo' onclick='ShowpurchasedSupplierFormReraise(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "&apos;" + lblcolor.Text + "&apos;" + "," + geriege + "," + Residual + "," + cutwastage + "," + "&apos;" + hdnfabricQuality.ClientID + "&apos;" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + ");' > Re.PO</div></td></tr>");
                            }
                            else
                            {
                                sb.AppendFormat("<tr ><td class='process' style='border-bottom: 1px solid #e2dddd99;width: 77px;'>" + "<div style='Color:grey' class='btnrepo tooltip'  > Re.PO</div></td></tr>");
                            }
                        }
                    }

                    sb.Append("</table>");
                    e.Row.Cells[15].Text = sb.ToString();
                    decimal Qtys = 0;
                    decimal SQty = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dt.Rows[i]["PoStatus"].ToString()) != 1)
                        {
                            if (Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString()) > 0)
                            {
                                Qtys += Convert.ToDecimal(dt.Rows[i]["ReceivedQty"].ToString());
                            }
                            if (Convert.ToDecimal(dt.Rows[i]["SendQty"].ToString()) > 0)
                            {
                                SQty += Convert.ToDecimal(dt.Rows[i]["SendQty"].ToString());
                            }
                        }
                    }
                    recqty.Text = Math.Round(Qtys, 0).ToString();
                    txtqtytosend.Text = Math.Round(SQty, 0).ToString("N0");
                }

                HtmlAnchor lnkProductionpopup = e.Row.FindControl("lnkProductionpopup") as HtmlAnchor;
                DataSet dsSupplier = new DataSet();
                DataTable dtsupplierQuoted = new DataTable();
                DataTable dtSystemQuoted = new DataTable();

                if (IsStyelSepecfic == 0)
                {
                    ds = fabobj.GetfabricViewdetails("Embroidery", "GETTOP3SUPPLIER_EmbroideryNONSTYLE", Convert.ToInt32(hdnfabricQuality.Value), 100, lblcolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, -1, fabbasic.stage1, fabbasic.stage2, fabbasic.stage3, fabbasic.stage4);
                    dt = ds.Tables[0];
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtsupplierQuoted = ds.Tables[0];
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        dtSystemQuoted = ds.Tables[1];
                    }

                }
                else if (IsStyelSepecfic == 1)
                {
                    ds = fabobj.GetfabricViewdetails("Embroidery", "GETTOP3SUPPLIER_EmbroiderySTYLE", Convert.ToInt32(hdnfabricQuality.Value), 100, lblcolor.Text, "", 0, fabbasic.CurrentStage, fabbasic.PeriviousStage, fabbasic.IsStyleSpecific, Convert.ToInt32(hdnStyleID.Value), fabbasic.stage1, fabbasic.stage2, fabbasic.stage3, fabbasic.stage4);


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtsupplierQuoted = ds.Tables[0];
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        dtSystemQuoted = ds.Tables[1];
                    }
                }
                if (dtsupplierQuoted.Rows.Count > 0)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<table class='topsupplier'>");
                    sb.AppendFormat("<tr><th colspan='5'  style='background: #39589c !important;color:#fff !important'>All Quotations<span style='float:right;padding-right:10px;cursor: pointer;color:#fff' titel='Close' onclick='HideSupplierDiv();'>X</span></th></tr>");
                    sb.AppendFormat("<tr><th>Fabric Quality (GSM) C&C Width <br> Color/Print</th><th style='display:none;'>Res. Sh.(%)</th><th> Best Quote For Ref.</th><th>Supplier Name</th><th>Quoted Rate &  Lead Time</th></tr>");

                    int x = 0;
                    for (int i = 0; i < dtsupplierQuoted.Rows.Count; i++)
                    {
                        sb.Append("<tr>");
                        if (x <= 0)
                        {
                            System.Text.StringBuilder sbfab = new System.Text.StringBuilder();
                            sb.AppendFormat("<td rowspan='" + dtsupplierQuoted.Rows.Count + "'>");

                            sbfab.Append("<table style='border: none;' class='topsupplier' cellspacing='0' cellpadding='0'>");

                            sbfab.Append("<tr>");
                            sbfab.Append("<TD style='border: none;' rowspan='" + dtsupplierQuoted.Rows.Count + "'>");
                            sbfab.Append(ccn);
                            sbfab.Append("</TD>");
                            sbfab.Append("</tr>");

                            sbfab.Append("<tr>");
                            sbfab.Append("<TD style='border: none;'>");
                            //sbfab.Append(lblcolor.Text.Trim());
                            sbfab.Append("</TD>");
                            sbfab.Append("</tr>");

                            sbfab.Append("</table>");
                            sb.AppendFormat(sbfab.ToString());
                            sb.AppendFormat("</td>");

                        }
                        if (x <= 0)
                        {
                            sb.AppendFormat("<td style='display:none;' rowspan='" + dtsupplierQuoted.Rows.Count + "'>");
                            sb.AppendFormat(dtsupplierQuoted.Rows[0]["GriegeShrinkage"].ToString());
                            sb.AppendFormat("</td>");
                        }
                        if (dtSystemQuoted.Rows.Count > 0)
                        {
                            if (x <= 0)
                            {
                                sb.AppendFormat("<td style='background: lightgreen;' rowspan='" + dtsupplierQuoted.Rows.Count + "'>");
                                sb.AppendFormat("<span style='color: green; font-size: 12px;'>₹ </span><span style='color:#000'>" + dtSystemQuoted.Rows[0]["QuotedLandedRate"].ToString() + "</span>");
                                sb.AppendFormat("</td>");
                            }
                        }

                        sb.AppendFormat("<td>");
                        string dd = dtsupplierQuoted.Rows[i]["Create_Update_Date"].ToString() == "" ? "" : Convert.ToDateTime(dtsupplierQuoted.Rows[i]["Create_Update_Date"].ToString()).ToString("dd MMM yyyy");
                        sb.AppendFormat(dtsupplierQuoted.Rows[i]["SupplierName"].ToString() + " " + "(" + dd + ")");
                        sb.AppendFormat("</td>");

                        string days = "";
                        if (dtsupplierQuoted.Rows[i]["LeadTimes"].ToString() != "" && dtsupplierQuoted.Rows[i]["LeadTimes"].ToString() != "0")
                        {
                            days = "(" + dtsupplierQuoted.Rows[i]["LeadTimes"].ToString() + " Days)";
                        }
                        string str = "";
                        if (dtsupplierQuoted.Rows[i]["QuotedLandedRate"].ToString() != "0")
                            str = "<span style='color: green; font-size: 12px;'>₹ </span>" + dtsupplierQuoted.Rows[i]["QuotedLandedRate"].ToString();
                        else
                            str = "<span style='color: green; font-size: 12px;'> </span>";

                        sb.AppendFormat("<td>");
                        sb.AppendFormat(str + "   " + days);

                        sb.AppendFormat("</td>");


                        x = x + 1;
                        sb.Append("</tr>");
                    }
                    sb.Append("</table>");
                    //lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier(\"" + sb.ToString() + "\")");
                    lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier2(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "'" + lblfabriccolor.Text + "'" + "," + geriege + "," + Residual + "," + cutwastage + "," + "'" + hdnfabricQuality.ClientID + "'" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + "," + "'" + ccn.Replace("'", "") + "'" + ");");
                }
                else
                {
                    //lnkProductionpopup.Style.Add("display", "none;");
                    //lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier(\"" + "empty" + "\")");
                    lnkProductionpopup.Attributes.Add("onclick", "ShowAllSupplier2(" + hdnfabricQuality.Value + "," + SupplierMasterID + "," + MasterPoID + "," + "'" + lblfabriccolor.Text + "'" + "," + geriege + "," + Residual + "," + cutwastage + "," + "'" + hdnfabricQuality.ClientID + "'" + "," + hdnstage1.Value + "," + hdnstage2.Value + "," + hdnstage3.Value + "," + hdnstage4.Value + "," + "'" + ccn.Replace("'", "") + "'" + ");");
                }



            }


        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindAll(hdnFabtype.Value);
            if (hdnFabtype.Value.ToLower() == "GRIEGE".ToLower())
            {
                SaveGerigeData();
            }
            else if (hdnFabtype.Value.ToLower() == "FINISHING".ToLower())
            {
                SaveFinishData();
            }
            else if (hdnFabtype.Value.ToLower() == "DYED".ToLower())
            {
                SaveDayedData();
            }
            else if (hdnFabtype.Value.ToLower() == "PRINT".ToLower())
            {
                SavePrintData();
            }
            else if (hdnFabtype.Value.ToLower() == "RFD".ToLower())
            {
                SaveRFDData();
            }
            else if (hdnFabtype.Value.ToLower() == "Embellishment".ToLower())
            {
                SaveEmbellishmentData();
            }
            else if (hdnFabtype.Value.ToLower() == "Embroidery".ToLower())
            {
                SaveEmbroideryData();
            }
            BindAll(hdnFabtype.Value);
            margerows();
            ShowHideControls();
            if (hdnIsMailSend.Value != "")
            {
                randorHtml();
            }
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.parent.Shadowbox.close();", true);
        }
        protected void grdstylenumber_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex > 0)
            {
                GridView grid = (GridView)sender;
                var rowView = (DataRowView)e.Row.DataItem;
                int lastRowIndex = e.Row.RowIndex - 1;
                var lastRowView = (DataRowView)grid.Rows[lastRowIndex].DataItem;
                // replace Region with the correct column name 
                String region = rowView.Row.Field<String>("StyleNumber");
                String lastRegion = lastRowView.Row.Field<String>("StyleNumber");
                // replace LblRegion with the correct ID of your Label
                Label lblSerialNumber = (Label)e.Row.FindControl("lblSerialNumber");
                lblSerialNumber.Text = region != lastRegion ? region : "";
            }
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex > 0)
                {
                    GridView grid = (GridView)sender;
                    GridViewRow previousRow = grid.Rows[e.Row.RowIndex - 1];
                    if (e.Row.Cells[0].Text == previousRow.Cells[0].Text)
                    {
                        if (previousRow.Cells[0].RowSpan == 0)
                        {
                            previousRow.Cells[0].RowSpan += 2;
                            e.Row.Cells[0].Visible = false;
                        }
                    }
                }
            }
        }
        public void margerows()
        {
            foreach (GridViewRow row in grdgreigerasiepo.Rows)
            {
                GridView grdstylenumber = row.FindControl("grdstylenumber") as GridView;
                MergeRowsnew(grdstylenumber);
            }
            foreach (GridViewRow row in grdfinishing.Rows)
            {
                GridView grdstylenumber = row.FindControl("grdstylenumber") as GridView;
                MergeRowsnew(grdstylenumber);
            }
            foreach (GridViewRow row in grdgayed.Rows)
            {
                GridView grdstylenumber = row.FindControl("grdstylenumber") as GridView;
                MergeRowsnew(grdstylenumber);
            }
            foreach (GridViewRow row in grdprint.Rows)
            {
                GridView grdstylenumber = row.FindControl("grdstylenumber") as GridView;
                MergeRowsnew(grdstylenumber);
            }
            foreach (GridViewRow row in grdvalueadditionRFD.Rows)
            {
                GridView grdstylenumber = row.FindControl("grdstylenumber") as GridView;
                MergeRowsnew(grdstylenumber);
            }
            foreach (GridViewRow row in grdEmbellishment.Rows)
            {
                GridView grdstylenumber = row.FindControl("grdstylenumber") as GridView;
                MergeRowsnew(grdstylenumber);
            }
            foreach (GridViewRow row in grdEmbroidery.Rows)
            {
                GridView grdstylenumber = row.FindControl("grdstylenumber") as GridView;
                MergeRowsnew(grdstylenumber);
            }
        }
        public static void MergeRowsnew(GridView GridView1)
        {
            for (int i = GridView1.Rows.Count - 1; i > 0; i--)
            {

                GridViewRow row = GridView1.Rows[i];
                GridViewRow previousRow = GridView1.Rows[i - 1];
                Label lblStyleNumber = (Label)row.FindControl("lblStyleNumber");
                Label lblStyleNumberpreviousRow = (Label)previousRow.FindControl("lblStyleNumber");


                if (lblStyleNumber.Text == lblStyleNumberpreviousRow.Text)
                {
                    if (previousRow.Cells[0].RowSpan == 0)
                    {
                        if (row.Cells[0].RowSpan == 0)
                        {
                            previousRow.Cells[0].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                        }
                        row.Cells[0].Visible = false;
                    }
                }

            }
        }
        public static void MergeRowsgrige(GridView gridView)
        {
            for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = gridView.Rows[rowIndex];
                GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                Label lblFabricQuality = (Label)row.FindControl("lblFabricQuality");
                Label lblFabricQualitynew = (Label)previousRow.FindControl("lblFabricQuality");

                HiddenField fabricQuality = (HiddenField)row.FindControl("hdnfabricQuality");
                HiddenField fabricQualityNew = (HiddenField)previousRow.FindControl("hdnfabricQuality");

                Label lblfabriccolor = (Label)row.FindControl("lblfabriccolor");
                Label lblcolornew = (Label)previousRow.FindControl("lblfabriccolor");

                string A = fabricQuality.Value;
                string B = fabricQualityNew.Value;


                if (A == B)
                {
                    row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 : previousRow.Cells[0].RowSpan + 1;
                    previousRow.Cells[0].Visible = false;

                    row.Cells[1].RowSpan = previousRow.Cells[1].RowSpan < 2 ? 2 : previousRow.Cells[1].RowSpan + 1;
                    previousRow.Cells[1].Visible = false;

                    row.Cells[2].RowSpan = previousRow.Cells[2].RowSpan < 2 ? 2 : previousRow.Cells[2].RowSpan + 1;
                    previousRow.Cells[2].Visible = false;

                    row.Cells[3].RowSpan = previousRow.Cells[3].RowSpan < 2 ? 2 : previousRow.Cells[3].RowSpan + 1;
                    previousRow.Cells[3].Visible = false;

                    row.Cells[4].RowSpan = previousRow.Cells[4].RowSpan < 2 ? 2 : previousRow.Cells[4].RowSpan + 1;
                    previousRow.Cells[4].Visible = false;

                    row.Cells[5].RowSpan = previousRow.Cells[5].RowSpan < 2 ? 2 : previousRow.Cells[5].RowSpan + 1;
                    previousRow.Cells[5].Visible = false;

                    row.Cells[6].RowSpan = previousRow.Cells[6].RowSpan < 2 ? 2 : previousRow.Cells[6].RowSpan + 1;
                    previousRow.Cells[6].Visible = false;

                    row.Cells[7].RowSpan = previousRow.Cells[7].RowSpan < 2 ? 2 : previousRow.Cells[7].RowSpan + 1;
                    previousRow.Cells[7].Visible = false;

                    row.Cells[8].RowSpan = previousRow.Cells[8].RowSpan < 2 ? 2 : previousRow.Cells[8].RowSpan + 1;
                    previousRow.Cells[8].Visible = false;

                    row.Cells[9].RowSpan = previousRow.Cells[9].RowSpan < 2 ? 2 : previousRow.Cells[9].RowSpan + 1;
                    previousRow.Cells[9].Visible = false;

                    row.Cells[10].RowSpan = previousRow.Cells[10].RowSpan < 2 ? 2 : previousRow.Cells[10].RowSpan + 1;
                    previousRow.Cells[10].Visible = false;

                    row.Cells[11].RowSpan = previousRow.Cells[11].RowSpan < 2 ? 2 : previousRow.Cells[11].RowSpan + 1;
                    previousRow.Cells[11].Visible = false;


                    row.Cells[12].RowSpan = previousRow.Cells[12].RowSpan < 2 ? 2 : previousRow.Cells[12].RowSpan + 1;
                    previousRow.Cells[12].Visible = false;


                    row.Cells[13].RowSpan = previousRow.Cells[13].RowSpan < 2 ? 2 : previousRow.Cells[13].RowSpan + 1;
                    previousRow.Cells[13].Visible = false;


                    row.Cells[14].RowSpan = previousRow.Cells[14].RowSpan < 2 ? 2 : previousRow.Cells[14].RowSpan + 1;
                    previousRow.Cells[14].Visible = false;


                    //row.Cells[15].RowSpan = previousRow.Cells[15].RowSpan < 2 ? 2 : previousRow.Cells[15].RowSpan + 1;
                    //previousRow.Cells[15].Visible = false;


                    //row.Cells[16].RowSpan = previousRow.Cells[16].RowSpan < 2 ? 2 : previousRow.Cells[16].RowSpan + 1;
                    //previousRow.Cells[16].Visible = false;

                }
            }
        }
        public static void MergeRowsPrintcal(GridView gridView)
        {
            try
            {
                int balinhouseqty = 0; int balinhouseqtytooltip = 0;
                for (int rowIndex = gridView.Rows.Count - 1; rowIndex >= 0; rowIndex--)
                {

                    GridViewRow row = gridView.Rows[rowIndex];
                    GridViewRow previousRow = gridView.Rows[rowIndex - 1];

                    if (previousRow != null)
                    {


                        Label lblFabricQuality = (Label)row.FindControl("lblFabricQuality");
                        Label lblFabricQualitynew = (Label)previousRow.FindControl("lblFabricQuality");

                        Label lblfabriccolor = (Label)row.FindControl("lblfabriccolor");
                        Label lblcolornew = (Label)previousRow.FindControl("lblfabriccolor");

                        string A = lblFabricQuality.Text + lblfabriccolor.Text;
                        string B = lblFabricQualitynew.Text + lblcolornew.Text;



                        Label lblGreige_Sh = (Label)row.FindControl("lblGreige_Sh");
                        Label lblGreige_Shnew = (Label)previousRow.FindControl("lblGreige_Sh");


                        Label lblstylenumber = (Label)row.FindControl("lblstylenumber");
                        Label lblstylenumbernext = (Label)previousRow.FindControl("lblstylenumber");




                        Label lblQuantityToOrder = (Label)row.FindControl("lblQuantityToOrder");
                        Label lblQuantityToOrdernew = (Label)previousRow.FindControl("lblQuantityToOrder");

                        Label lblbalanceinhouseqty = (Label)row.FindControl("lblbalanceinhouseqty");
                        Label lblbalanceinhouseqtynew = (Label)previousRow.FindControl("lblbalanceinhouseqty");


                        Label lblBestQuotedRate = (Label)row.FindControl("lblBestQuotedRate");
                        Label llblBestQuotedRatenew = (Label)previousRow.FindControl("lblBestQuotedRate");

                        Label lblBestQuotedRatedays = (Label)row.FindControl("lblBestQuotedRatedays");
                        Label lblBestQuotedRatedaysnew = (Label)previousRow.FindControl("lblBestQuotedRatedays");

                        Label lblgerigeshrinkage = (Label)row.FindControl("lblgerigeshrinkage");
                        Label lblgerigeshrinkagenew = (Label)previousRow.FindControl("lblgerigeshrinkage");

                        HiddenField hdnCurrentstage = (HiddenField)row.FindControl("hdnCurrentstage");
                        HiddenField hdnCurrentstageNext = (HiddenField)previousRow.FindControl("hdnCurrentstage");

                        HiddenField hdnperiviousstgae = (HiddenField)row.FindControl("hdnperiviousstgae");
                        HiddenField hdnperiviousstgaeNext = (HiddenField)previousRow.FindControl("hdnperiviousstgae");


                        HiddenField hdnIsStyleSpecific = (HiddenField)row.FindControl("hdnIsStyleSpecific");
                        HiddenField hdnIsStyleSpecificNext = (HiddenField)previousRow.FindControl("hdnIsStyleSpecific");

                        HiddenField hdnStyleID = (HiddenField)row.FindControl("hdnStyleID");
                        HiddenField hdnStyleIDNext = (HiddenField)previousRow.FindControl("hdnStyleID");

                        Label lblBalanceTooltip = (Label)row.FindControl("lblBalanceTooltip");
                        Label lblBalanceTooltipnext = (Label)previousRow.FindControl("lblBalanceTooltip");


                        HiddenField hdnadjustmentqty = (HiddenField)row.FindControl("hdnadjustmentqty");
                        HiddenField hdnadjustmentqtyNext = (HiddenField)previousRow.FindControl("hdnadjustmentqty");





                        if (hdnIsStyleSpecific.Value == "True")
                        {

                            A = A + hdnCurrentstage.Value + hdnperiviousstgae.Value + hdnIsStyleSpecific.Value + hdnStyleID.Value;
                            B = B + hdnCurrentstageNext.Value + hdnperiviousstgaeNext.Value + hdnIsStyleSpecificNext.Value + hdnStyleIDNext.Value;

                        }
                        else
                        {

                            A = A + hdnCurrentstage.Value + hdnperiviousstgae.Value + hdnIsStyleSpecific.Value;
                            B = B + hdnCurrentstageNext.Value + hdnperiviousstgaeNext.Value + hdnIsStyleSpecificNext.Value;

                        }

                        if (A == B)
                        {
                            if (lblbalanceinhouseqty.Text != "")
                                balinhouseqty = balinhouseqty + Convert.ToInt32(lblbalanceinhouseqty.Text.Replace(",", ""));

                            if (lblbalanceinhouseqtynew.Text != "")
                                balinhouseqty = balinhouseqty + Convert.ToInt32(lblbalanceinhouseqtynew.Text.Replace(",", ""));


                            if (hdnadjustmentqty.Value != "")
                                balinhouseqtytooltip = balinhouseqtytooltip + Convert.ToInt32(hdnadjustmentqty.Value.Replace(",", ""));

                            if (hdnadjustmentqtyNext.Value != "")
                                balinhouseqtytooltip = balinhouseqtytooltip + Convert.ToInt32(hdnadjustmentqtyNext.Value.Replace(",", ""));







                        }
                        lblbalanceinhouseqty.Text = balinhouseqty.ToString();
                        lblbalanceinhouseqtynew.Text = balinhouseqty.ToString();
                        balinhouseqty = 0;
                        if (lblbalanceinhouseqty.Text != "")
                        {

                            //lblBalanceTooltip.Text = "Adjustment qty from further stage: <span style='color:yellow'>" + balinhouseqtytooltip.ToString() + "</span>";
                            //lblBalanceTooltip.CssClass = "TooltipTxt";
                        }
                        balinhouseqtytooltip = 0;
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }
        public static void MergeRowsPrint(GridView gridView)
        {
            try
            {
                int balinhouseqty = 0; int balinhouseqtytooltip = 0;
                for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
                {

                    GridViewRow row = gridView.Rows[rowIndex];
                    GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                    Label lblFabricQuality = (Label)row.FindControl("lblFabricQuality");
                    Label lblFabricQualitynew = (Label)previousRow.FindControl("lblFabricQuality");

                    Label lblfabriccolor = (Label)row.FindControl("lblfabriccolor");
                    Label lblcolornew = (Label)previousRow.FindControl("lblfabriccolor");

                    string A = lblFabricQuality.Text + lblfabriccolor.Text;
                    string B = lblFabricQualitynew.Text + lblcolornew.Text;



                    Label lblGreige_Sh = (Label)row.FindControl("lblGreige_Sh");
                    Label lblGreige_Shnew = (Label)previousRow.FindControl("lblGreige_Sh");


                    Label lblstylenumber = (Label)row.FindControl("lblstylenumber");
                    Label lblstylenumbernext = (Label)previousRow.FindControl("lblstylenumber");




                    Label lblQuantityToOrder = (Label)row.FindControl("lblQuantityToOrder");
                    Label lblQuantityToOrdernew = (Label)previousRow.FindControl("lblQuantityToOrder");

                    Label lblbalanceinhouseqty = (Label)row.FindControl("lblbalanceinhouseqty");
                    Label lblbalanceinhouseqtynew = (Label)previousRow.FindControl("lblbalanceinhouseqty");


                    Label lblBestQuotedRate = (Label)row.FindControl("lblBestQuotedRate");
                    Label llblBestQuotedRatenew = (Label)previousRow.FindControl("lblBestQuotedRate");

                    Label lblBestQuotedRatedays = (Label)row.FindControl("lblBestQuotedRatedays");
                    Label lblBestQuotedRatedaysnew = (Label)previousRow.FindControl("lblBestQuotedRatedays");

                    Label lblgerigeshrinkage = (Label)row.FindControl("lblgerigeshrinkage");
                    Label lblgerigeshrinkagenew = (Label)previousRow.FindControl("lblgerigeshrinkage");

                    HiddenField hdnCurrentstage = (HiddenField)row.FindControl("hdnCurrentstage");
                    HiddenField hdnCurrentstageNext = (HiddenField)previousRow.FindControl("hdnCurrentstage");

                    HiddenField hdnperiviousstgae = (HiddenField)row.FindControl("hdnperiviousstgae");
                    HiddenField hdnperiviousstgaeNext = (HiddenField)previousRow.FindControl("hdnperiviousstgae");


                    HiddenField hdnIsStyleSpecific = (HiddenField)row.FindControl("hdnIsStyleSpecific");
                    HiddenField hdnIsStyleSpecificNext = (HiddenField)previousRow.FindControl("hdnIsStyleSpecific");

                    HiddenField hdnStyleID = (HiddenField)row.FindControl("hdnStyleID");
                    HiddenField hdnStyleIDNext = (HiddenField)previousRow.FindControl("hdnStyleID");

                    Label lblBalanceTooltip = (Label)row.FindControl("lblBalanceTooltip");
                    Label lblBalanceTooltipnext = (Label)previousRow.FindControl("lblBalanceTooltip");


                    HiddenField hdnadjustmentqty = (HiddenField)row.FindControl("hdnadjustmentqty");
                    HiddenField hdnadjustmentqtyNext = (HiddenField)previousRow.FindControl("hdnadjustmentqty");





                    if (hdnIsStyleSpecific.Value == "True")
                    {

                        A = A + hdnCurrentstage.Value + hdnperiviousstgae.Value + hdnIsStyleSpecific.Value + hdnStyleID.Value;
                        B = B + hdnCurrentstageNext.Value + hdnperiviousstgaeNext.Value + hdnIsStyleSpecificNext.Value + hdnStyleIDNext.Value;

                    }
                    else
                    {

                        A = A + hdnCurrentstage.Value + hdnperiviousstgae.Value + hdnIsStyleSpecific.Value;
                        B = B + hdnCurrentstageNext.Value + hdnperiviousstgaeNext.Value + hdnIsStyleSpecificNext.Value;

                    }

                    if (A == B)
                    {
                        //if (lblbalanceinhouseqty.Text != "")
                        //    balinhouseqty = balinhouseqty + Convert.ToInt32(lblbalanceinhouseqty.Text.Replace(",", ""));

                        //if (lblbalanceinhouseqtynew.Text != "")
                        //    balinhouseqty = balinhouseqty + Convert.ToInt32(lblbalanceinhouseqtynew.Text.Replace(",", ""));


                        //if (hdnadjustmentqty.Value != "")
                        //    balinhouseqtytooltip = balinhouseqtytooltip + Convert.ToInt32(hdnadjustmentqty.Value.Replace(",", ""));

                        //if (hdnadjustmentqtyNext.Value != "")
                        //    balinhouseqtytooltip = balinhouseqtytooltip + Convert.ToInt32(hdnadjustmentqtyNext.Value.Replace(",", ""));




                        row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 : previousRow.Cells[0].RowSpan + 1;
                        previousRow.Cells[0].Visible = false;

                        row.Cells[1].RowSpan = previousRow.Cells[1].RowSpan < 2 ? 2 : previousRow.Cells[1].RowSpan + 1;
                        previousRow.Cells[1].Visible = false;

                        row.Cells[2].RowSpan = previousRow.Cells[2].RowSpan < 2 ? 2 : previousRow.Cells[2].RowSpan + 1;
                        previousRow.Cells[2].Visible = false;

                        row.Cells[3].RowSpan = previousRow.Cells[3].RowSpan < 2 ? 2 : previousRow.Cells[3].RowSpan + 1;
                        previousRow.Cells[3].Visible = false;

                        row.Cells[4].RowSpan = previousRow.Cells[4].RowSpan < 2 ? 2 : previousRow.Cells[4].RowSpan + 1;
                        previousRow.Cells[4].Visible = false;

                        row.Cells[5].RowSpan = previousRow.Cells[5].RowSpan < 2 ? 2 : previousRow.Cells[5].RowSpan + 1;
                        previousRow.Cells[5].Visible = false;

                        row.Cells[6].RowSpan = previousRow.Cells[6].RowSpan < 2 ? 2 : previousRow.Cells[6].RowSpan + 1;
                        previousRow.Cells[6].Visible = false;

                        row.Cells[7].RowSpan = previousRow.Cells[7].RowSpan < 2 ? 2 : previousRow.Cells[7].RowSpan + 1;
                        previousRow.Cells[7].Visible = false;

                        row.Cells[8].RowSpan = previousRow.Cells[8].RowSpan < 2 ? 2 : previousRow.Cells[8].RowSpan + 1;
                        previousRow.Cells[8].Visible = false;

                        row.Cells[9].RowSpan = previousRow.Cells[9].RowSpan < 2 ? 2 : previousRow.Cells[9].RowSpan + 1;
                        previousRow.Cells[9].Visible = false;

                        row.Cells[10].RowSpan = previousRow.Cells[10].RowSpan < 2 ? 2 : previousRow.Cells[10].RowSpan + 1;
                        previousRow.Cells[10].Visible = false;

                        row.Cells[11].RowSpan = previousRow.Cells[11].RowSpan < 2 ? 2 : previousRow.Cells[11].RowSpan + 1;
                        previousRow.Cells[11].Visible = false;


                        row.Cells[12].RowSpan = previousRow.Cells[12].RowSpan < 2 ? 2 : previousRow.Cells[12].RowSpan + 1;
                        previousRow.Cells[12].Visible = false;


                        row.Cells[13].RowSpan = previousRow.Cells[13].RowSpan < 2 ? 2 : previousRow.Cells[13].RowSpan + 1;
                        previousRow.Cells[13].Visible = false;


                        row.Cells[14].RowSpan = previousRow.Cells[14].RowSpan < 2 ? 2 : previousRow.Cells[14].RowSpan + 1;
                        previousRow.Cells[14].Visible = false;


                        row.Cells[15].RowSpan = previousRow.Cells[15].RowSpan < 2 ? 2 : previousRow.Cells[15].RowSpan + 1;
                        previousRow.Cells[15].Visible = false;


                        row.Cells[16].RowSpan = previousRow.Cells[16].RowSpan < 2 ? 2 : previousRow.Cells[16].RowSpan + 1;
                        previousRow.Cells[16].Visible = false;
                        row.Attributes.Add("class", "bgon" + row.RowIndex.ToString());
                        previousRow.Attributes.Add("class", "bgon" + row.RowIndex.ToString());
                        row.Attributes.Add("onclick", "funcolor(" + "'" + row.RowIndex.ToString() + "'" + ")");
                        previousRow.Attributes.Add("onclick", "funcolor(" + "'" + row.RowIndex.ToString() + "'" + ")");


                    }
                    //lblbalanceinhouseqty.Text = balinhouseqty.ToString();
                    //balinhouseqty = 0;
                    //if (lblbalanceinhouseqty.Text != "")
                    //{

                    //    lblBalanceTooltip.Text = "Adjustment qty from further stage: <span style='color:yellow'>" + balinhouseqtytooltip.ToString() + "</span>";
                    //    lblBalanceTooltip.CssClass = "TooltipTxt";
                    //}
                    //balinhouseqtytooltip = 0;
                }
            }
            catch (Exception ex)
            {

            }

        }
        //public void a(string type)
        //{
        //    BindAll(type);
        //    if (type == "GRIEGE")
        //    {
        //        SaveGerigeData();
        //    }
        //    else if (type == "FINISHING")
        //    {
        //        SaveFinishData();
        //    }
        //    else if (type == "DYED")
        //    {
        //        SaveDayedData();
        //    }
        //    else if (type == "PRINT")
        //    {
        //        SavePrintData();
        //    }
        //    else if (type == "RFD")
        //    {
        //        SaveRFDData();
        //    }
        //    else if (type == "Embellishment".ToLower())
        //    {
        //        SaveEmbellishmentData();
        //    }
        //    else if (type == "Embroidery".ToLower())
        //    {
        //        SaveEmbroideryData();
        //    }
        //    BindAll(hdnFabtype.Value);
        //    margerows();
        //    switch (hdnFabtype.Value)
        //    {

        //        case "GRIEGE":
        //            adayed.Attributes.Remove("class");
        //            aprint.Attributes.Remove("class");
        //            afinished.Attributes.Remove("class");
        //            ava.Attributes.Remove("class");
        //            aEmbellishment.Attributes.Remove("class");
        //            aEmbroidery.Attributes.Remove("class");

        //            grdgreigerasiepo.Style.Remove("display");
        //            grdgayed.Style.Add("display", "none");
        //            grdprint.Style.Add("display", "none");
        //            grdfinishing.Style.Add("display", "none");
        //            grdvalueadditionRFD.Style.Add("display", "none");
        //            grdEmbellishment.Style.Add("display", "none");
        //            grdEmbroidery.Style.Add("display", "none");

        //            agreige.Attributes.Add("class", "tab1greige activeback ");
        //            adayed.Attributes.Add("class", "tab1Dayed ");
        //            aprint.Attributes.Add("class", "tab1Print ");
        //            afinished.Attributes.Add("class", "tab1finished ");
        //            ava.Attributes.Add("class", "tab1VA ");
        //            aEmbellishment.Attributes.Add("class", "tabEmbellishment ");
        //            aEmbroidery.Attributes.Add("class", "tabEmbroidery ");
        //            break;

        //        case "DYED":
        //            adayed.Attributes.Remove("class");
        //            aprint.Attributes.Remove("class");
        //            afinished.Attributes.Remove("class");
        //            ava.Attributes.Remove("class");
        //            aEmbellishment.Attributes.Remove("class");
        //            aEmbroidery.Attributes.Remove("class");

        //            grdgreigerasiepo.Style.Add("display", "none");
        //            grdgayed.Style.Remove("display");
        //            grdprint.Style.Add("display", "none");
        //            grdfinishing.Style.Add("display", "none");
        //            grdvalueadditionRFD.Style.Add("display", "none");
        //            grdEmbellishment.Style.Add("display", "none");
        //            grdEmbroidery.Style.Add("display", "none");

        //            agreige.Attributes.Add("class", "tab1greige ");
        //            adayed.Attributes.Add("class", "tab1Dayed activeback ");
        //            aprint.Attributes.Add("class", "tab1Print ");
        //            afinished.Attributes.Add("class", "tab1finished ");
        //            ava.Attributes.Add("class", "tab1VA ");
        //            aEmbellishment.Attributes.Add("class", "tabEmbellishment ");
        //            aEmbroidery.Attributes.Add("class", "tabEmbroidery ");

        //            break;

        //        case "PRINT":
        //            adayed.Attributes.Remove("class");
        //            aprint.Attributes.Remove("class");
        //            afinished.Attributes.Remove("class");
        //            ava.Attributes.Remove("class");
        //            aEmbellishment.Attributes.Remove("class");
        //            aEmbroidery.Attributes.Remove("class");

        //            grdgreigerasiepo.Style.Add("display", "none");
        //            grdgayed.Style.Add("display", "none");
        //            grdprint.Style.Remove("display");
        //            grdfinishing.Style.Add("display", "none");
        //            grdvalueadditionRFD.Style.Add("display", "none");
        //            grdEmbellishment.Style.Add("display", "none");
        //            grdEmbroidery.Style.Add("display", "none");

        //            agreige.Attributes.Add("class", "tab1greige ");
        //            adayed.Attributes.Add("class", "tab1Dayed ");
        //            aprint.Attributes.Add("class", "tab1Print activeback");
        //            afinished.Attributes.Add("class", "tab1finished ");
        //            ava.Attributes.Add("class", "tab1VA ");
        //            aEmbellishment.Attributes.Add("class", "tabEmbellishment ");
        //            aEmbroidery.Attributes.Add("class", "tabEmbroidery ");

        //            break;
        //        case "FINISHING":
        //            adayed.Attributes.Remove("class");
        //            aprint.Attributes.Remove("class");
        //            afinished.Attributes.Remove("class");
        //            ava.Attributes.Remove("class");
        //            aEmbellishment.Attributes.Remove("class");
        //            aEmbroidery.Attributes.Remove("class");

        //            grdgreigerasiepo.Style.Add("display", "none");
        //            grdgayed.Style.Add("display", "none");
        //            grdprint.Style.Add("display", "none");
        //            grdfinishing.Style.Remove("display");
        //            grdvalueadditionRFD.Style.Add("display", "none");
        //            grdEmbellishment.Style.Add("display", "none");
        //            grdEmbroidery.Style.Add("display", "none");

        //            agreige.Attributes.Add("class", "tab1greige ");
        //            adayed.Attributes.Add("class", "tab1Dayed ");
        //            aprint.Attributes.Add("class", "tab1Print ");
        //            afinished.Attributes.Add("class", "tab1finished activeback ");
        //            ava.Attributes.Add("class", "tab1VA ");
        //            aEmbellishment.Attributes.Add("class", "tabEmbellishment ");
        //            aEmbroidery.Attributes.Add("class", "tabEmbroidery ");
        //            break;
        //        case "RFD":
        //            adayed.Attributes.Remove("class");
        //            aprint.Attributes.Remove("class");
        //            afinished.Attributes.Remove("class");
        //            ava.Attributes.Remove("class");
        //            aEmbellishment.Attributes.Remove("class");
        //            aEmbroidery.Attributes.Remove("class");

        //            grdgreigerasiepo.Style.Add("display", "none");
        //            grdgayed.Style.Add("display", "none");
        //            grdprint.Style.Add("display", "none");
        //            grdfinishing.Style.Add("display", "none");
        //            grdvalueadditionRFD.Style.Remove("display");
        //            grdEmbellishment.Style.Add("display", "none");
        //            grdEmbroidery.Style.Add("display", "none");

        //            agreige.Attributes.Add("class", "tab1greige ");
        //            adayed.Attributes.Add("class", "tab1Dayed ");
        //            aprint.Attributes.Add("class", "tab1Print ");
        //            afinished.Attributes.Add("class", "tab1finished  ");
        //            ava.Attributes.Add("class", "tab1VA activeback ");
        //            aEmbellishment.Attributes.Add("class", "tabEmbellishment ");
        //            aEmbroidery.Attributes.Add("class", "tabEmbroidery ");
        //            break;
        //        case "Embellishment":
        //            adayed.Attributes.Remove("class");
        //            aprint.Attributes.Remove("class");
        //            afinished.Attributes.Remove("class");
        //            ava.Attributes.Remove("class");
        //            aEmbellishment.Attributes.Remove("class");
        //            aEmbroidery.Attributes.Remove("class");

        //            grdgreigerasiepo.Style.Add("display", "none");
        //            grdgayed.Style.Add("display", "none");
        //            grdprint.Style.Add("display", "none");
        //            grdfinishing.Style.Add("display", "none");
        //            grdvalueadditionRFD.Style.Add("display", "none");
        //            grdEmbellishment.Style.Remove("display");
        //            grdEmbroidery.Style.Add("display", "none");

        //            agreige.Attributes.Add("class", "tab1greige ");
        //            adayed.Attributes.Add("class", "tab1Dayed ");
        //            aprint.Attributes.Add("class", "tab1Print ");
        //            afinished.Attributes.Add("class", "tab1finished  ");
        //            ava.Attributes.Add("class", "tab1VA  ");
        //            aEmbellishment.Attributes.Add("class", "tabEmbellishment activeback ");
        //            aEmbroidery.Attributes.Add("class", "tabEmbroidery ");
        //            break;

        //        case "Embroidery":
        //            adayed.Attributes.Remove("class");
        //            aprint.Attributes.Remove("class");
        //            afinished.Attributes.Remove("class");
        //            ava.Attributes.Remove("class");
        //            aEmbellishment.Attributes.Remove("class");
        //            aEmbroidery.Attributes.Remove("class");

        //            grdgreigerasiepo.Style.Add("display", "none");
        //            grdgayed.Style.Add("display", "none");
        //            grdprint.Style.Add("display", "none");
        //            grdfinishing.Style.Add("display", "none");
        //            grdvalueadditionRFD.Style.Add("display", "none");
        //            grdEmbellishment.Style.Add("display", "none");
        //            grdEmbroidery.Style.Remove("display");

        //            agreige.Attributes.Add("class", "tab1greige ");
        //            adayed.Attributes.Add("class", "tab1Dayed ");
        //            aprint.Attributes.Add("class", "tab1Print ");
        //            afinished.Attributes.Add("class", "tab1finished  ");
        //            ava.Attributes.Add("class", "tab1VA  ");
        //            aEmbellishment.Attributes.Add("class", "tabEmbellishment ");
        //            aEmbroidery.Attributes.Add("class", "tabEmbroidery activeback ");
        //            break;

        //        default:
        //            goto case "GRIEGE";

        //    }
        //}
        //===============================================================================================Print area

        public void randorHtml()
        {
            try
            {
                AdminController objadmin = new AdminController();

                string strHTML = "";
                string ss = host + "/../../FabricPurChasedFormPrint.aspx?" + Session["q"].ToString() + "&AuthName=" + "" + "&AuthPhoto=" + "" + "&ApproName=" + "" + "&ApproPhoto=" + "" + "&PoNumberPrint=" + hdnponumber.Value;
                //FabricQualityID=17&Fabtype=GRIEGE&Potype=RERAISE&MasterPoID=55&colorprintdetail=&gerige=3&residual=2&cutwastage=7&currentstage=0&previousstage=0&isStyleSpecific=0&styleid=0&stage1=1&stage2=3&stage3=31&stage4=30";
                Uri requestUri = null;
                Uri.TryCreate((ss), UriKind.Absolute, out requestUri);
                NetworkCredential nc = new NetworkCredential(ApplicationHelper.LoggedInUser.UserData.Username, ApplicationHelper.LoggedInUser.UserData.Password);
                CredentialCache cache = new CredentialCache();
                cache.Add(requestUri, "Basic", nc);
                cache.Add(new Uri(ss), "NTLM", new NetworkCredential(ApplicationHelper.LoggedInUser.UserData.Username, ApplicationHelper.LoggedInUser.UserData.Password));

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUri);
                request.Credentials = cache;

                request.Method = WebRequestMethods.Http.Get;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader respStream = new StreamReader(response.GetResponseStream());
                strHTML = respStream.ReadToEnd();


                string filename = "POFabric_view" + hdnponumber.Value + ".HTML";
                string strFileNameashtml = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + "" + filename);
                //new System.IO.DirectoryInfo(@"C:\Temp").Delete(true);

                if ((File.Exists(strFileNameashtml)))
                {
                    File.Delete(strFileNameashtml);
                }
                using (FileStream fs = File.Create(strFileNameashtml))
                {
                    Byte[] title = new UTF8Encoding(true).GetBytes(strHTML);
                    fs.Write(title, 0, title.Length);
                }
                if (hdnIsMailSend.Value == "1")
                {
                    genertaePdf(strHTML, "ss");
                    
                    DataTable dtgrid = new DataTable();
                    dtgrid = objadmin.GetSuppliarDetails(Convert.ToInt32(hdnmasterpoid.Value)).Tables[0];
                    if (dtgrid.Rows.Count > 0)
                    {
                        DataRow dr = dtgrid.Select("IsUserlogin1 = " + "True").First();
                        string SupplierMailID = dr["Email"].ToString();

                        try
                        {
                            List<Attachment> atts = new List<Attachment>();
                            String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");
                            List<String> to = new List<String>();
                            NotificationController objcontroller = new NotificationController();
                            to.Add(SupplierMailID);
                            //to.Add("bipl_itsupport@boutique.in");
                            string name = "POFabric_" + hdnponumber.Value + ".pdf";
                            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + name);
                            if (File.Exists(Constants.FITS_FOLDER_PATH + name))
                            {

                                string FitsPath = Path.Combine(Constants.FITS_FOLDER_PATH, name);
                                atts.Add(new Attachment(FitsPath));
                            }

                            this.SendEmail(fromName, to, null, null, "Fabric PO (" + hdnponumber.Value + ")", name, atts, false, false);

                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                            System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));

                        }


                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  randorHtml function  on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            Session["q"] = null;
            hdnIsMailSend.Value = "";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "alert('Mail sent')", true);
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.parent.Shadowbox.close();", true);

        }
        public Boolean SendEmail(String FromEmail, List<String> To, List<String> CC, List<String> BCC, String Subject, String Content, List<Attachment> Attachments, Boolean hasAppendAttachment, Boolean isAsync)
        {

            var uri = new Uri(host + "/../../FabricPurChasedFormPrint.aspx?" + Session["q"].ToString());
            var query = HttpUtility.ParseQueryString(uri.Query);

            var FabricQuality = query.Get("FabricQuality");
            hdnStageName.Value = query.Get("FabType").ToString();
            if (hdnStageName.Value.ToLower() == "griege")
            {
                hdnFabTypeForMail.Value = "Greige";
            }
            else
            {
                hdnFabTypeForMail.Value = hdnStageName.Value;
            }

            //hdnFabricQuality.Value = hdnFabricQuality.Value.Contains('(') ? hdnFabricQuality.Value.Substring(0, hdnFabricQuality.Value.IndexOf('(')) : hdnFabricQuality.Value;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(FromEmail);
            mailMessage.ReplyTo = new MailAddress(FromEmail);
            mailMessage.Priority = MailPriority.Normal;
            mailMessage.Subject = Subject;
            //mailMessage.Body = "<span style='font-size:13px; font-family:Arial'>Dear Supplier, <br><br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; With due respect, a Purchase Order " + hdintialsuppliercode.Value + " is raised against for  <span style='color:gray'>" + "Fabric Quality - " + hdnFabricQuality.Value + "</span> for stage  <span style='color:gray'> " + Fabtype.ToString() + "</span>. Please find the attached PDF File having all details. <br> <br> <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style='font-size:10px;font-family:Arial;'> <u>Disclaimer</u> : This is system generated mail, for detail communicate at <span style='color:blue'> +91 120 67979 </span> </span> <br><br><b> Thanks & Regards </b> <br> BIPL Team</span>";
            mailMessage.Body = "<span style='font-size:13px; font-family:Arial'>Dear Supplier, <br><br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; With due respect, a <span style='color:gray'>Purchase Order</span><span style='color:#2f5597'> " + hdnponumber.Value + "</span> is raised  for <span style='color:gray'>" + "Fabric Quality - </span><span style='color:#2f5597'>" + FabricQuality + "</span><span style='color:gray'> for stage </span> <span style='color:#2f5597'> " + hdnFabTypeForMail.Value + "</span>. Please find the attached PDF File having all details. <br> <br> <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style='font-size:10px;font-family:Arial;'> Disclaimer: This is system generated mail, for detail communicate at <span style='color:blue'> +91 120 67979 </span> </span> <br><br><b> Thanks & Regards </b> <br> BIPL Team</span>";
            mailMessage.IsBodyHtml = true;

            //AlternateView htmlView = AlternateView.CreateAlternateViewFromString(Subject, null, "text/html");
            //mailMessage.AlternateViews.Add(htmlView);

            if (hasAppendAttachment && Attachments != null)
            {
                int i = 1;

                foreach (Attachment attachment in Attachments)
                {
                    if (attachment.ContentStream.Length > 0)
                    {
                        LinkedResource imageId = new LinkedResource(attachment.ContentStream, "image/jpeg");
                        imageId.ContentId = "imageId" + i.ToString();
                        imageId.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
                        //htmlView.LinkedResources.Add(imageId);
                    }

                    i++;
                }
            }
            else
            {
                //mailMessage.Body = Subject;                
                mailMessage.Body = mailMessage.Body;
            }

            Boolean isDebug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["isDebug"]);

            if (isDebug)
            {
                // TODO
                mailMessage.To.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);
                mailMessage.Bcc.Add(Constants.WEBMASTER_EMAIL);
                mailMessage.CC.Add("itsupport@boutique.in");
            }
            else
            {
                foreach (String to in To)
                    mailMessage.To.Add(to);

                if (CC != null)
                    foreach (String to in CC)
                        mailMessage.CC.Add(to);

                if (BCC != null)
                    foreach (String to in BCC)
                        mailMessage.Bcc.Add(to);


                mailMessage.Bcc.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);


            }

            SmtpClient smtpClient = new SmtpClient(Constants.SMTP_HOST, Constants.SMTP_PORT);

            if (!hasAppendAttachment && Attachments != null)
            {
                foreach (Attachment att in Attachments)
                {
                    mailMessage.Attachments.Add(att);
                }
            }

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Timeout = Constants.SMTP_TIMEOUT;

            if (Constants.SMTP_SECURE)
            {
                smtpClient.EnableSsl = true;
            }

            if (Constants.SMTP_IS_AUTH_REQUIRED)
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(Constants.SMTP_USERNAME, Constants.SMTP_PASSWORD);
            }
            try
            {
                smtpClient.Timeout = 300000;
                smtpClient.Send(mailMessage);
                System.Diagnostics.Trace.WriteLine("Email Having Subject of --" + Subject.ToString() + " is send successfully on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
                // ShowAlert("Mail Sent successfully");
                return true;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Some error has been occur in Email having subject of ---" + Subject.ToString() + " On" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                System.Diagnostics.Trace.WriteLine("Sorry !! Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
                return false;
            }

            finally
            {
                try
                {
                    if (Attachments != null)
                    {
                        foreach (Attachment att in Attachments)
                        {
                            att.Dispose();
                        }

                        Attachments = null;
                    }

                    foreach (Attachment att in mailMessage.Attachments)
                    {
                        att.Dispose();
                    }

                    mailMessage = null;

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
        }
        public void genertaePdf(string HTMLCode, string PolicyFile)
        {
            string strFileName = "";
            HTMLCode = getImage(HTMLCode);
            getvartypeHTML(HTMLCode, strFileName);
        }
        public void getvartypeHTML(string HTMLCode, string PolicyFile)
        {
            try
            {
                string filename = "POFabric_" + hdnponumber.Value + ".pdf";
                string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + "" + filename);
                using (var pechkin = Factory.Create(new GlobalConfig()))
                {
                    var pdf = pechkin.Convert(new ObjectConfig()
                                            .SetLoadImages(true).SetZoomFactor(1.5)
                                            .SetPrintBackground(true)
                                            .SetScreenMediaType(true)
                                            .SetCreateExternalLinks(true), (HTMLCode.Replace("flow-root;", "none;")));

                    using (FileStream file = System.IO.File.Create(strFileName))
                    {
                        file.Write(pdf, 0, pdf.Length);
                    }
                }

            }
            catch { }
        }
        public string getTitle(string input)
        {
            if (input == null)
                return string.Empty;
            string tempInput = input;
            string pattern = @"(?<=<title.*>)([\s\S]*)(?=</title>)";
            string title = string.Empty;

            //get and remove Title in HTML..
            foreach (Match m1 in Regex.Matches(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline))
            {
                if (m1.Success)
                {
                    string tempM = m1.Value;
                    try
                    {
                        //tempM = tempM.Remove(m1.Index, m1.Length);
                        tempM = tempM.Replace(m1.Value, title);

                        //insert new url img tag in whole html code
                        //tempInput = tempInput.Remove(m1.Index, m1.Length);
                        tempInput = tempInput.Replace(m1.Value, tempM);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                        System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    }
                }
                else
                {
                    return "";
                }
            }
            return tempInput;
        }
        public string getImage(string input)
        {
            if (input == null)
                return string.Empty;
            string tempInput = input;
            string pattern = @"<img(.|\n)+?>";
            string src = string.Empty;
            HttpContext context = HttpContext.Current;

            //Change the relative URL's to absolute URL's for an image, if any in the HTML code.
            foreach (Match m in Regex.Matches(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline |

            RegexOptions.RightToLeft))
            {
                if (m.Success)
                {
                    string tempM = m.Value;
                    string pattern1 = "src=[\'|\"](.+?)[\'|\"]";
                    Regex reImg = new Regex(pattern1, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    Match mImg = reImg.Match(m.Value);

                    if (mImg.Success)
                    {
                        src = mImg.Value.ToLower().Replace("src=", "").Replace("\"", "");
                        if (src == "../../signatured.jpg" || src == "../signatured.jpg")
                        {
                            string imgsrc = @Server.MapPath("~/Signature/SignatureD.jpg");
                            //src = src.Replace("../../", "/ErmNew/");
                            //src = src.Replace("../", "/ErmNew/");
                            src = "src=\"" + imgsrc + "\"";
                        }
                        if (src == "../../signdt.jpg" || src == "../signdt.jpg")
                        {
                            string imgsrc = @Server.MapPath("~/Signature/signdt.jpg");
                            //src = src.Replace("../../", "/ErmNew/");
                            //src = src.Replace("../", "/ErmNew/");
                            src = "src=\"" + imgsrc + "\"";
                        }
                        if (src.ToLower().Contains("http://") == false)
                        {
                            //Insert new URL in img tag
                            //src = "src=\"" + context.Request.Url.Scheme + "://" +
                            //context.Request.Url.Authority + src + "\"";
                            try
                            {
                                tempM = tempM.Remove(mImg.Index, mImg.Length);
                                tempM = tempM.Insert(mImg.Index, src);

                                //insert new url img tag in whole html code
                                tempInput = tempInput.Remove(m.Index, m.Length);
                                tempInput = tempInput.Insert(m.Index, tempM);
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                                //string imgsrc = @Server.MapPath("~/imgSignature/" + dt + ".jpg");
                                //string html = "<html><div><img src='" + imgsrc + "'</div></html>";
                                //generatepdf(html);
                                //File.Delete(imgsrc);
                            }
                        }
                    }
                }
            }
            return tempInput;
        }
        public void CreatePDFDocument(string strHtml)
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/fits/Summery.pdf");
            iTextSharp.text.Document document = new iTextSharp.text.Document();
            PdfWriter.GetInstance(document, new FileStream(strFileName, FileMode.Create));
            StringReader se = new StringReader(strHtml);
            HTMLWorker obj = new HTMLWorker(document);
            document.Open();
            obj.Parse(se);
            document.Close();
        }


        public void ShowHideControls()
        {
            agreige.Attributes.Remove("class");
            adayed.Attributes.Remove("class");
            aprint.Attributes.Remove("class");
            afinished.Attributes.Remove("class");
            ava.Attributes.Remove("class");
            aEmbellishment.Attributes.Remove("class");
            aEmbroidery.Attributes.Remove("class");

            agreige.Attributes.Add("class", "tab1greige");
            adayed.Attributes.Add("class", "tab1Dayed ");
            aprint.Attributes.Add("class", "tab1Print ");
            afinished.Attributes.Add("class", "tab1finished ");
            ava.Attributes.Add("class", "tab1VA ");
            aEmbellishment.Attributes.Add("class", "tabEmbellishment ");
            aEmbroidery.Attributes.Add("class", "tabEmbroidery ");

            grdgreigerasiepo.Visible = false;
            grdgayed.Visible = false;
            grdprint.Visible = false;
            grdfinishing.Visible = false;
            grdvalueadditionRFD.Visible = false;
            grdEmbellishment.Visible = false;
            grdEmbroidery.Visible = false;

            switch (hdnFabtype.Value.ToLower())
            {

                case "griege":
                    grdgreigerasiepo.Visible = true;
                    agreige.Attributes.Remove("class");
                    agreige.Attributes.Add("class", "tab1greige activeback ");
                    break;

                case "dyed":
                    grdgayed.Visible = true;
                    adayed.Attributes.Remove("class");
                    adayed.Attributes.Add("class", "tab1Dayed activeback ");
                    break;

                case "print":
                    grdprint.Visible = true;
                    aprint.Attributes.Remove("class");
                    aprint.Attributes.Add("class", "tab1Print activeback");
                    break;

                case "finishing":
                    grdfinishing.Visible = true;
                    afinished.Attributes.Remove("class");
                    afinished.Attributes.Add("class", "tab1finished activeback ");
                    break;

                case "rfd":
                    grdvalueadditionRFD.Visible = true;
                    ava.Attributes.Remove("class");
                    ava.Attributes.Add("class", "tab1VA activeback ");
                    break;

                case "embellishment":
                    grdEmbellishment.Visible = true;
                    aEmbellishment.Attributes.Remove("class");
                    aEmbellishment.Attributes.Add("class", "tabEmbellishment activeback ");
                    break;

                case "embroidery":
                    grdEmbroidery.Visible = true;
                    aEmbroidery.Attributes.Remove("class");
                    aEmbroidery.Attributes.Add("class", "tabEmbroidery activeback ");
                    break;

                default:
                    goto case "griege";

            }
        }
    }
}



