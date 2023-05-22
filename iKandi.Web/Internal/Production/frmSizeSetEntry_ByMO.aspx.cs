using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using System.Data;
using System.Web.UI.HtmlControls;
using iKandi.BLL.Production;

namespace iKandi.Web.Internal.Production
{
    public partial class frmSizeSetEntry_ByMO : System.Web.UI.Page
    {
        ProductionController objProductionController = new ProductionController();
        DataSet ds = new DataSet();
        DataTable dtQty = new DataTable();
        DataTable dtOrderDetail = new DataTable();
        DataTable DTSize = new DataTable();
        public int OrderId
        {
            get;
            set;
        }
        public int OrderDetailId
        {
            get;
            set;
        }
        public string FormType
        {
            get;
            set;
        }
        public int StyleId
        {
            get;
            set;
        }
        public string StyleNumber
        {
            get;
            set;
        }
        //abhishek
        public string ControlID
        {
            get;
            set;
        }
        public int Quantity
        {
            get;
            set;
        }
        public int CutQty
        {
            get;
            set;
        }
        public int UnitId
        {
            get;
            set;
        }
        //end
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
        int Altpcs = 0;
        decimal OptionTotalFinal = 0;
        decimal PassTotalFinal = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetQueryString();
                BindSizeOptionData();
                btnSubmit.Attributes.Add("style", "display:none");
            }
        }
        private void GetQueryString()
        {
            if (null != Request.QueryString["orderid"])
            {
                OrderId = Convert.ToInt32(Request.QueryString["orderid"].ToString());
                hdnOrderId.Value = OrderId.ToString();
            }
            if (null != Request.QueryString["OrderDetailId"])
            {
                OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"].ToString());
                hdnOrderDetailId.Value = OrderDetailId.ToString();
            }
            if (null != Request.QueryString["Type"])
            {
                FormType = Request.QueryString["Type"].ToString();
                hdnType.Value = FormType;
            }
            //abhishek
            if (null != Request.QueryString["StyleNumber"])
            {
                StyleNumber = Request.QueryString["StyleNumber"].ToString();
                hdnStyleNumber.Value = StyleNumber;
            }
            if (null != Request.QueryString["CutQty"])
            {
                CutQty = Convert.ToInt32(Request.QueryString["CutQty"].ToString());
                lblCut.Text = "Cut Pcs :";
                lblCutPcs.Text = CutQty.ToString();
            }
            if (null != Request.QueryString["UnitId"])
            {
                UnitId = Convert.ToInt32(Request.QueryString["UnitId"].ToString());
                hdnUnitId.Value = UnitId.ToString();
            }
            //end
        }

        private void BindSizeOptionData()
        {
            FormType = hdnType.Value;
            OrderId = -1;
            OrderDetailId = Convert.ToInt32(hdnOrderDetailId.Value);
            UnitId = Convert.ToInt32(hdnUnitId.Value);
            StyleNumber = hdnStyleNumber.Value;
            
            if (FormType == "Cutting")
            {
                lblHeading.Text = "Cutting";                
            }
            if (FormType == "CutReady")
            {
                lblHeading.Text = "CutReady";               
            }
            else if (FormType == "Stitching")
            {
                lblHeading.Text = "Stitching";
            }
            else if (FormType == "Finishing")
            {
                lblHeading.Text = "Finishing/Packing";
            }
            ds = this.objProductionController.GetOrderContract_BySizeOption(OrderDetailId, OrderId, FormType, UnitId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdSizeOption1.DataSource = ds.Tables[0];
                grdSizeOption1.DataBind();
                grdSizeOption1.Visible = true;
                td1.Visible = true;
                grdSizeOption1.HeaderRow.Cells[0].ColumnSpan = 3;
                grdSizeOption1.HeaderRow.Cells[0].Text = "Style No. :-" + "(" + StyleNumber + ") " + " Client :-" + ds.Tables[0].Rows[0]["CompanyName"];
                lblTotalOrderQty.Text = "Total Order Quantity:- " + ds.Tables[0].Rows[0]["TotalQty"].ToString();
                grdSizeOption1.FooterRow.Cells[0].Visible = false;
                grdSizeOption1.FooterRow.Cells[1].Visible = false;
            }
            //string IsCutMsg = objProductionController.Check_Cut_For_Production(OrderDetailId, "INLINECUT");
            //if (IsCutMsg == "")
            //{
            //    lblMsg.Text = "";
            //    ds = this.objProductionController.GetOrderContract_BySizeOption(OrderDetailId, OrderId, FormType, UnitId);
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        grdSizeOption1.DataSource = ds.Tables[0];
            //        grdSizeOption1.DataBind();
            //        grdSizeOption1.Visible = true;
            //        td1.Visible = true;
            //        grdSizeOption1.HeaderRow.Cells[0].ColumnSpan = 3;
            //        grdSizeOption1.HeaderRow.Cells[0].Text = "Style No. :-" + "(" + StyleNumber + ") " + " Client :-" + ds.Tables[0].Rows[0]["CompanyName"];
            //        lblTotalOrderQty.Text = "Total Order Quantity:- " + ds.Tables[0].Rows[0]["TotalQty"].ToString();
            //        grdSizeOption1.FooterRow.Cells[0].Visible = false;
            //        grdSizeOption1.FooterRow.Cells[1].Visible = false;
            //    }
            //}
            //else
            //{
            //    lblMsg.Text = IsCutMsg.TrimEnd(',');
            //    ds = this.objProductionController.GetOrderContract_BySizeOption(OrderDetailId, OrderId, FormType, UnitId);
            //    DataTable dtSize = ds.Tables[0];
            //    dtSize.Clear();

            //    grdSizeOption1.DataSource = dtSize;
            //    grdSizeOption1.DataBind();
            //    grdSizeOption1.Visible = true;
            //    td1.Visible = true;
            //    btnSubmit.Visible = false;

            //}
            //History
            if (ds.Tables[1].Rows.Count > 0)
            {
                HistoryHeading.Visible = true;
                gdvOrderDetailsHistory.DataSource = ds.Tables[0];
                gdvOrderDetailsHistory.DataBind();
                gdvOrderDetailsHistory.HeaderRow.Cells[0].ColumnSpan = 2;
                gdvOrderDetailsHistory.HeaderRow.Cells[0].Text = "Style No. :-" + "(" + StyleNumber + ") " + " Client :-" + ds.Tables[0].Rows[0]["CompanyName"];
                gdvOrderDetailsHistory.HeaderRow.Cells[1].Visible = false;

                gdvSizeHistory.DataSource = ds.Tables[1];
                gdvSizeHistory.DataBind();
            }
        }
        protected void grdSizeOption1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int OrderDetailId = -1;
            int SizeOption = -1;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Attributes.Add("rowspan", "2");
                e.Row.Cells[1].Attributes.Add("rowspan", "2");
                HiddenField hdnGvOrderDetailId = (HiddenField)e.Row.FindControl("hdnGvOrderDetailId");
                HiddenField hdnSizeOption = (HiddenField)e.Row.FindControl("hdnSizeOption");

                TextBox txtOptionEntry1 = (TextBox)e.Row.FindControl("txtOptionEntry1");
                TextBox txtOptionEntry2 = (TextBox)e.Row.FindControl("txtOptionEntry2");
                TextBox txtOptionEntry3 = (TextBox)e.Row.FindControl("txtOptionEntry3");
                TextBox txtOptionEntry4 = (TextBox)e.Row.FindControl("txtOptionEntry4");
                TextBox txtOptionEntry5 = (TextBox)e.Row.FindControl("txtOptionEntry5");
                TextBox txtOptionEntry6 = (TextBox)e.Row.FindControl("txtOptionEntry6");
                TextBox txtOptionEntry7 = (TextBox)e.Row.FindControl("txtOptionEntry7");
                TextBox txtOptionEntry8 = (TextBox)e.Row.FindControl("txtOptionEntry8");
                TextBox txtOptionEntry9 = (TextBox)e.Row.FindControl("txtOptionEntry9");
                TextBox txtOptionEntry10 = (TextBox)e.Row.FindControl("txtOptionEntry10");
                TextBox txtOptionEntry11 = (TextBox)e.Row.FindControl("txtOptionEntry11");
                TextBox txtOptionEntry12 = (TextBox)e.Row.FindControl("txtOptionEntry12");
                TextBox txtOptionEntry13 = (TextBox)e.Row.FindControl("txtOptionEntry13");
                TextBox txtOptionEntry14 = (TextBox)e.Row.FindControl("txtOptionEntry14");
                TextBox txtOptionEntry15 = (TextBox)e.Row.FindControl("txtOptionEntry15");

                #region Gajendra
                Label lblOredrQty1 = (Label)e.Row.FindControl("lblOredrQty1");
                Label lblOredrQty2 = (Label)e.Row.FindControl("lblOredrQty2");
                Label lblOredrQty3 = (Label)e.Row.FindControl("lblOredrQty3");
                Label lblOredrQty4 = (Label)e.Row.FindControl("lblOredrQty4");
                Label lblOredrQty5 = (Label)e.Row.FindControl("lblOredrQty5");
                Label lblOredrQty6 = (Label)e.Row.FindControl("lblOredrQty6");
                Label lblOredrQty7 = (Label)e.Row.FindControl("lblOredrQty7");
                Label lblOredrQty8 = (Label)e.Row.FindControl("lblOredrQty8");
                Label lblOredrQty9 = (Label)e.Row.FindControl("lblOredrQty9");
                Label lblOredrQty10 = (Label)e.Row.FindControl("lblOredrQty10");
                Label lblOredrQty11 = (Label)e.Row.FindControl("lblOredrQty11");
                Label lblOredrQty12 = (Label)e.Row.FindControl("lblOredrQty12");
                Label lblOredrQty13 = (Label)e.Row.FindControl("lblOredrQty13");
                Label lblOredrQty14 = (Label)e.Row.FindControl("lblOredrQty14");
                Label lblOredrQty15 = (Label)e.Row.FindControl("lblOredrQty15");
                Label lblOrderQtyTotal = (Label)e.Row.FindControl("lblOrderQtyTotal");

                Label lblReadyQty1 = (Label)e.Row.FindControl("lblReadyQty1");
                Label lblReadyQty2 = (Label)e.Row.FindControl("lblReadyQty2");
                Label lblReadyQty3 = (Label)e.Row.FindControl("lblReadyQty3");
                Label lblReadyQty4 = (Label)e.Row.FindControl("lblReadyQty4");
                Label lblReadyQty5 = (Label)e.Row.FindControl("lblReadyQty5");
                Label lblReadyQty6 = (Label)e.Row.FindControl("lblReadyQty6");
                Label lblReadyQty7 = (Label)e.Row.FindControl("lblReadyQty7");
                Label lblReadyQty8 = (Label)e.Row.FindControl("lblReadyQty8");
                Label lblReadyQty9 = (Label)e.Row.FindControl("lblReadyQty9");
                Label lblReadyQty10 = (Label)e.Row.FindControl("lblReadyQty10");
                Label lblReadyQty11 = (Label)e.Row.FindControl("lblReadyQty11");
                Label lblReadyQty12 = (Label)e.Row.FindControl("lblReadyQty12");
                Label lblReadyQty13 = (Label)e.Row.FindControl("lblReadyQty13");
                Label lblReadyQty14 = (Label)e.Row.FindControl("lblReadyQty14");
                Label lblReadyQty15 = (Label)e.Row.FindControl("lblReadyQty15");
                Label lblReadyQtyTotal = (Label)e.Row.FindControl("lblReadyQtyTotal");

                #endregion

                HiddenField hdnOptionTotal1 = (HiddenField)e.Row.FindControl("hdnOptionTotal1");
                HiddenField hdnOptionTotal2 = (HiddenField)e.Row.FindControl("hdnOptionTotal2");
                HiddenField hdnOptionTotal3 = (HiddenField)e.Row.FindControl("hdnOptionTotal3");
                HiddenField hdnOptionTotal4 = (HiddenField)e.Row.FindControl("hdnOptionTotal4");
                HiddenField hdnOptionTotal5 = (HiddenField)e.Row.FindControl("hdnOptionTotal5");
                HiddenField hdnOptionTotal6 = (HiddenField)e.Row.FindControl("hdnOptionTotal6");
                HiddenField hdnOptionTotal7 = (HiddenField)e.Row.FindControl("hdnOptionTotal7");
                HiddenField hdnOptionTotal8 = (HiddenField)e.Row.FindControl("hdnOptionTotal8");
                HiddenField hdnOptionTotal9 = (HiddenField)e.Row.FindControl("hdnOptionTotal9");
                HiddenField hdnOptionTotal10 = (HiddenField)e.Row.FindControl("hdnOptionTotal10");
                HiddenField hdnOptionTotal11 = (HiddenField)e.Row.FindControl("hdnOptionTotal11");
                HiddenField hdnOptionTotal12 = (HiddenField)e.Row.FindControl("hdnOptionTotal12");
                HiddenField hdnOptionTotal13 = (HiddenField)e.Row.FindControl("hdnOptionTotal13");
                HiddenField hdnOptionTotal14 = (HiddenField)e.Row.FindControl("hdnOptionTotal14");
                HiddenField hdnOptionTotal15 = (HiddenField)e.Row.FindControl("hdnOptionTotal15");


                TextBox txtOptionAltPcs = (TextBox)e.Row.FindControl("txtOptionAltPcs");
                HiddenField hdnAltPcs = (HiddenField)e.Row.FindControl("hdnAltPcs");

                //Label OptionAltPcsTotal = (Label)e.Row.FindControl("OptionAltPcsTotal");
                // Label lblOptionTotal = (Label)e.Row.FindControl("lblOptionTotal");
                Label lblReadyQty = (Label)e.Row.FindControl("lblReadyQty");
                if (hdnGvOrderDetailId != null)
                {
                    OrderDetailId = Convert.ToInt32(hdnGvOrderDetailId.Value);
                }
                if (hdnSizeOption != null)
                {
                    SizeOption = Convert.ToInt32(hdnSizeOption.Value);
                }
                FormType = hdnType.Value;
                if (FormType != "Stitching")
                {
                    txtOptionAltPcs.Enabled = false;
                }
                dtQty = this.objProductionController.GetSizeQuantity_Option(OrderDetailId, SizeOption, FormType,UnitId);

                if (dtQty.Rows.Count > 0)
                {
                    lblOrderQtyTotal.Text = dtQty.Rows[0]["TotalOredrQty"] == DBNull.Value ? "" : dtQty.Rows[0]["TotalOredrQty"].ToString();
                    lblReadyQtyTotal.Text = dtQty.Rows[0]["TotalReadyQty"] == DBNull.Value ? "0" : dtQty.Rows[0]["TotalReadyQty"].ToString();
                    lblCutReadyPcs.Text = dtQty.Rows[0]["TotalReadyQty"] == DBNull.Value ? "0" : dtQty.Rows[0]["TotalReadyQty"].ToString(); ;

                    lblOredrQty1.Text = dtQty.Rows[0]["Qty"] == DBNull.Value ? "" : dtQty.Rows[0]["Qty"].ToString();
                    lblReadyQty1.Text = dtQty.Rows[0]["ReadyQty"] == DBNull.Value ? "" : dtQty.Rows[0]["ReadyQty"].ToString();
                    hdnOptionTotal1.Value = dtQty.Rows[0]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[0]["Quantity"].ToString();
                    TotalQuantity1 = TotalQuantity1 + Convert.ToInt32((dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString());
                    grdSizeOption1.HeaderRow.Cells[1].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();
                    if (dtQty.Rows[0]["ActualSize"] == DBNull.Value)
                        txtOptionEntry1.Enabled = false;

                    lblOredrQty2.Text = dtQty.Rows[1]["Qty"] == DBNull.Value ? "" : dtQty.Rows[1]["Qty"].ToString();
                    lblReadyQty2.Text = dtQty.Rows[1]["ReadyQty"] == DBNull.Value ? "" : dtQty.Rows[1]["ReadyQty"].ToString();
                    hdnOptionTotal2.Value = dtQty.Rows[1]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[1]["Quantity"].ToString();
                    TotalQuantity2 = TotalQuantity2 + Convert.ToInt32((dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString());
                    grdSizeOption1.HeaderRow.Cells[2].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();
                    if (dtQty.Rows[1]["ActualSize"] == DBNull.Value)
                        txtOptionEntry2.Enabled = false;

                    lblOredrQty3.Text = dtQty.Rows[2]["Qty"] == DBNull.Value ? "" : dtQty.Rows[2]["Qty"].ToString();
                    lblReadyQty3.Text = dtQty.Rows[2]["ReadyQty"] == DBNull.Value ? "" : dtQty.Rows[2]["ReadyQty"].ToString();
                    hdnOptionTotal3.Value = dtQty.Rows[2]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[2]["Quantity"].ToString();
                    TotalQuantity3 = TotalQuantity3 + Convert.ToInt32((dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString());
                    grdSizeOption1.HeaderRow.Cells[3].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();
                    if (dtQty.Rows[2]["ActualSize"] == DBNull.Value)
                        txtOptionEntry3.Enabled = false;

                    lblOredrQty4.Text = dtQty.Rows[3]["Qty"] == DBNull.Value ? "" : dtQty.Rows[3]["Qty"].ToString();
                    lblReadyQty4.Text = dtQty.Rows[3]["ReadyQty"] == DBNull.Value ? "" : dtQty.Rows[3]["ReadyQty"].ToString();
                    hdnOptionTotal4.Value = dtQty.Rows[3]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[3]["Quantity"].ToString();
                    TotalQuantity4 = TotalQuantity4 + Convert.ToInt32((dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString());
                    grdSizeOption1.HeaderRow.Cells[4].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();
                    if (dtQty.Rows[3]["ActualSize"] == DBNull.Value)
                        txtOptionEntry4.Enabled = false;

                    lblOredrQty5.Text = dtQty.Rows[4]["Qty"] == DBNull.Value ? "" : dtQty.Rows[4]["Qty"].ToString();
                    lblReadyQty5.Text = dtQty.Rows[4]["ReadyQty"] == DBNull.Value ? "" : dtQty.Rows[4]["ReadyQty"].ToString();
                    hdnOptionTotal5.Value = dtQty.Rows[4]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[4]["Quantity"].ToString();
                    TotalQuantity5 = TotalQuantity5 + Convert.ToInt32((dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString());
                    grdSizeOption1.HeaderRow.Cells[5].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();
                    if (dtQty.Rows[4]["ActualSize"] == DBNull.Value)
                        txtOptionEntry5.Enabled = false;

                    lblOredrQty6.Text = dtQty.Rows[5]["Qty"] == DBNull.Value ? "" : dtQty.Rows[5]["Qty"].ToString();
                    lblReadyQty6.Text = dtQty.Rows[5]["ReadyQty"] == DBNull.Value ? "" : dtQty.Rows[5]["ReadyQty"].ToString();
                    hdnOptionTotal6.Value = dtQty.Rows[5]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[5]["Quantity"].ToString();
                    TotalQuantity6 = TotalQuantity6 + Convert.ToInt32((dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString());
                    grdSizeOption1.HeaderRow.Cells[6].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();
                    if (dtQty.Rows[5]["ActualSize"] == DBNull.Value)
                        txtOptionEntry6.Enabled = false;

                    lblOredrQty7.Text = dtQty.Rows[6]["Qty"] == DBNull.Value ? "" : dtQty.Rows[6]["Qty"].ToString();
                    lblReadyQty7.Text = dtQty.Rows[6]["ReadyQty"] == DBNull.Value ? "" : dtQty.Rows[6]["ReadyQty"].ToString();
                    hdnOptionTotal7.Value = dtQty.Rows[6]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[6]["Quantity"].ToString();
                    TotalQuantity7 = TotalQuantity7 + Convert.ToInt32((dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString());
                    grdSizeOption1.HeaderRow.Cells[7].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();
                    if (dtQty.Rows[6]["ActualSize"] == DBNull.Value)
                        txtOptionEntry7.Enabled = false;

                    lblOredrQty8.Text = dtQty.Rows[7]["Qty"] == DBNull.Value ? "" : dtQty.Rows[7]["Qty"].ToString();
                    lblReadyQty8.Text = dtQty.Rows[7]["ReadyQty"] == DBNull.Value ? "" : dtQty.Rows[7]["ReadyQty"].ToString();
                    hdnOptionTotal8.Value = dtQty.Rows[7]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[7]["Quantity"].ToString();
                    TotalQuantity8 = TotalQuantity8 + Convert.ToInt32((dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString());
                    grdSizeOption1.HeaderRow.Cells[8].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();
                    if (dtQty.Rows[7]["ActualSize"] == DBNull.Value)
                        txtOptionEntry8.Enabled = false;

                    lblOredrQty9.Text = dtQty.Rows[8]["Qty"] == DBNull.Value ? "" : dtQty.Rows[8]["Qty"].ToString();
                    lblReadyQty9.Text = dtQty.Rows[8]["ReadyQty"] == DBNull.Value ? "" : dtQty.Rows[8]["ReadyQty"].ToString();
                    hdnOptionTotal9.Value = dtQty.Rows[8]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[8]["Quantity"].ToString();
                    TotalQuantity9 = TotalQuantity9 + Convert.ToInt32((dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString());
                    grdSizeOption1.HeaderRow.Cells[9].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();
                    if (dtQty.Rows[8]["ActualSize"] == DBNull.Value)
                        txtOptionEntry9.Enabled = false;

                    lblOredrQty10.Text = dtQty.Rows[9]["Qty"] == DBNull.Value ? "" : dtQty.Rows[9]["Qty"].ToString();
                    lblReadyQty10.Text = dtQty.Rows[9]["ReadyQty"] == DBNull.Value ? "" : dtQty.Rows[9]["ReadyQty"].ToString();
                    hdnOptionTotal10.Value = dtQty.Rows[9]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[9]["Quantity"].ToString();
                    TotalQuantity10 = TotalQuantity10 + Convert.ToInt32((dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString());
                    grdSizeOption1.HeaderRow.Cells[10].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();
                    if (dtQty.Rows[9]["ActualSize"] == DBNull.Value)
                        txtOptionEntry10.Enabled = false;

                    lblOredrQty11.Text = dtQty.Rows[10]["Qty"] == DBNull.Value ? "" : dtQty.Rows[10]["Qty"].ToString();
                    lblReadyQty11.Text = dtQty.Rows[10]["ReadyQty"] == DBNull.Value ? "" : dtQty.Rows[10]["ReadyQty"].ToString();
                    hdnOptionTotal11.Value = dtQty.Rows[10]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[10]["Quantity"].ToString();
                    TotalQuantity11 = TotalQuantity11 + Convert.ToInt32((dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString());
                    grdSizeOption1.HeaderRow.Cells[11].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();
                    if (dtQty.Rows[10]["ActualSize"] == DBNull.Value)
                        txtOptionEntry11.Enabled = false;

                    lblOredrQty12.Text = dtQty.Rows[11]["Qty"] == DBNull.Value ? "" : dtQty.Rows[11]["Qty"].ToString();
                    lblReadyQty12.Text = dtQty.Rows[11]["ReadyQty"] == DBNull.Value ? "" : dtQty.Rows[11]["ReadyQty"].ToString();
                    hdnOptionTotal12.Value = dtQty.Rows[11]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[11]["Quantity"].ToString();
                    TotalQuantity12 = TotalQuantity12 + Convert.ToInt32((dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString());
                    grdSizeOption1.HeaderRow.Cells[12].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();
                    if (dtQty.Rows[11]["ActualSize"] == DBNull.Value)
                        txtOptionEntry12.Enabled = false;

                    lblOredrQty13.Text = dtQty.Rows[12]["Qty"] == DBNull.Value ? "" : dtQty.Rows[12]["Qty"].ToString();
                    lblReadyQty13.Text = dtQty.Rows[12]["ReadyQty"] == DBNull.Value ? "" : dtQty.Rows[12]["ReadyQty"].ToString();
                    hdnOptionTotal13.Value = dtQty.Rows[12]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[12]["Quantity"].ToString();
                    TotalQuantity13 = TotalQuantity13 + Convert.ToInt32((dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString());
                    grdSizeOption1.HeaderRow.Cells[13].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();
                    if (dtQty.Rows[12]["ActualSize"] == DBNull.Value)
                        txtOptionEntry13.Enabled = false;

                    lblOredrQty14.Text = dtQty.Rows[13]["Qty"] == DBNull.Value ? "" : dtQty.Rows[13]["Qty"].ToString();
                    lblReadyQty14.Text = dtQty.Rows[13]["ReadyQty"] == DBNull.Value ? "" : dtQty.Rows[13]["ReadyQty"].ToString();
                    hdnOptionTotal14.Value = dtQty.Rows[13]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[13]["Quantity"].ToString();
                    TotalQuantity14 = TotalQuantity14 + Convert.ToInt32((dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString());
                    grdSizeOption1.HeaderRow.Cells[14].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();
                    if (dtQty.Rows[13]["ActualSize"] == DBNull.Value)
                        txtOptionEntry14.Enabled = false;

                    lblOredrQty15.Text = dtQty.Rows[14]["Qty"] == DBNull.Value ? "" : dtQty.Rows[14]["Qty"].ToString();
                    lblReadyQty15.Text = dtQty.Rows[14]["ReadyQty"] == DBNull.Value ? "" : dtQty.Rows[14]["ReadyQty"].ToString();
                    hdnOptionTotal15.Value = dtQty.Rows[14]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[14]["Quantity"].ToString();
                    TotalQuantity15 = TotalQuantity15 + Convert.ToInt32((dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString());
                    grdSizeOption1.HeaderRow.Cells[15].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();
                    if (dtQty.Rows[14]["ActualSize"] == DBNull.Value)
                        txtOptionEntry15.Enabled = false;

                    grdSizeOption1.HeaderRow.Cells[16].Text = "Alt / Rej.";
                    grdSizeOption1.HeaderRow.Cells[17].Text = "Total / Pass";
                    grdSizeOption1.HeaderRow.Cells[18].Visible = false;

                    decimal OptionTotal = Math.Round(Convert.ToDecimal(hdnOptionTotal1.Value == "" ? 0 : Convert.ToDecimal(hdnOptionTotal1.Value))
                                            + Convert.ToDecimal(hdnOptionTotal2.Value == "" ? 0 : Convert.ToDecimal(hdnOptionTotal2.Value))
                                            + Convert.ToDecimal(hdnOptionTotal3.Value == "" ? 0 : Convert.ToDecimal(hdnOptionTotal3.Value))
                                            + Convert.ToDecimal(hdnOptionTotal4.Value == "" ? 0 : Convert.ToDecimal(hdnOptionTotal4.Value))
                                            + Convert.ToDecimal(hdnOptionTotal5.Value == "" ? 0 : Convert.ToDecimal(hdnOptionTotal5.Value))
                                            + Convert.ToDecimal(hdnOptionTotal6.Value == "" ? 0 : Convert.ToDecimal(hdnOptionTotal6.Value))
                                            + Convert.ToDecimal(hdnOptionTotal7.Value == "" ? 0 : Convert.ToDecimal(hdnOptionTotal7.Value))
                                            + Convert.ToDecimal(hdnOptionTotal8.Value == "" ? 0 : Convert.ToDecimal(hdnOptionTotal8.Value))
                                            + Convert.ToDecimal(hdnOptionTotal9.Value == "" ? 0 : Convert.ToDecimal(hdnOptionTotal9.Value))
                                            + Convert.ToDecimal(hdnOptionTotal10.Value == "" ? 0 : Convert.ToDecimal(hdnOptionTotal10.Value))
                                            + Convert.ToDecimal(hdnOptionTotal11.Value == "" ? 0 : Convert.ToDecimal(hdnOptionTotal11.Value))
                                            + Convert.ToDecimal(hdnOptionTotal12.Value == "" ? 0 : Convert.ToDecimal(hdnOptionTotal12.Value))
                                            + Convert.ToDecimal(hdnOptionTotal13.Value == "" ? 0 : Convert.ToDecimal(hdnOptionTotal13.Value))
                                            + Convert.ToDecimal(hdnOptionTotal14.Value == "" ? 0 : Convert.ToDecimal(hdnOptionTotal14.Value))
                                            + Convert.ToDecimal(hdnOptionTotal15.Value == "" ? 0 : Convert.ToDecimal(hdnOptionTotal15.Value)));

                    //OptionTotal = OptionTotal + Convert.ToDecimal(OptionAltPcsTotal.Text == "" ? 0 : Convert.ToDecimal(OptionAltPcsTotal.Text));
                    OptionTotalFinal = OptionTotalFinal + OptionTotal; //+ Convert.ToDecimal(hdnAltPcs.Value == "" ? 0 : Convert.ToDecimal(hdnAltPcs.Value)); Commented by Gajendra
                    PassTotalFinal = PassTotalFinal + OptionTotal;

                    //lblOptionTotal.Text = Math.Round(OptionTotal, 0).ToString();
                    Label lblPcs = (Label)e.Row.FindControl("lblPcs");
                    if (FormType == "Cutting")
                    {
                        lblPcs.Text = "Cut Pcs.";
                    }
                    if (FormType == "CutReady")
                    {
                        lblPcs.Text = "Cut Ready Pcs.";
                        lblReadyQty.Text = "Cut Qty.";
                    }
                    else if (FormType == "Stitching")
                    {
                        lblPcs.Text = "Stitch Pcs.";
                    }
                    else if (FormType == "Finishing")
                    {
                        lblPcs.Text = "Finish/Pack Pcs.";
                        lblReadyQty.Text = "Stitch Qty.";
                    }

                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblGrandTotal1 = (Label)e.Row.FindControl("lblGrandTotal1");
                Label lblGrandTotal2 = (Label)e.Row.FindControl("lblGrandTotal2");
                Label lblGrandTotal3 = (Label)e.Row.FindControl("lblGrandTotal3");
                Label lblGrandTotal4 = (Label)e.Row.FindControl("lblGrandTotal4");
                Label lblGrandTotal5 = (Label)e.Row.FindControl("lblGrandTotal5");
                Label lblGrandTotal6 = (Label)e.Row.FindControl("lblGrandTotal6");
                Label lblGrandTotal7 = (Label)e.Row.FindControl("lblGrandTotal7");
                Label lblGrandTotal8 = (Label)e.Row.FindControl("lblGrandTotal8");
                Label lblGrandTotal9 = (Label)e.Row.FindControl("lblGrandTotal9");
                Label lblGrandTotal10 = (Label)e.Row.FindControl("lblGrandTotal10");
                Label lblGrandTotal11 = (Label)e.Row.FindControl("lblGrandTotal11");
                Label lblGrandTotal12 = (Label)e.Row.FindControl("lblGrandTotal12");
                Label lblGrandTotal13 = (Label)e.Row.FindControl("lblGrandTotal13");
                Label lblGrandTotal14 = (Label)e.Row.FindControl("lblGrandTotal14");
                Label lblGrandTotal15 = (Label)e.Row.FindControl("lblGrandTotal15");

                HiddenField hdnGrandTotal1 = (HiddenField)e.Row.FindControl("hdnGrandTotal1");
                HiddenField hdnGrandTotal2 = (HiddenField)e.Row.FindControl("hdnGrandTotal2");
                HiddenField hdnGrandTotal3 = (HiddenField)e.Row.FindControl("hdnGrandTotal3");
                HiddenField hdnGrandTotal4 = (HiddenField)e.Row.FindControl("hdnGrandTotal4");
                HiddenField hdnGrandTotal5 = (HiddenField)e.Row.FindControl("hdnGrandTotal5");
                HiddenField hdnGrandTotal6 = (HiddenField)e.Row.FindControl("hdnGrandTotal6");
                HiddenField hdnGrandTotal7 = (HiddenField)e.Row.FindControl("hdnGrandTotal7");
                HiddenField hdnGrandTotal8 = (HiddenField)e.Row.FindControl("hdnGrandTotal8");
                HiddenField hdnGrandTotal9 = (HiddenField)e.Row.FindControl("hdnGrandTotal9");
                HiddenField hdnGrandTotal10 = (HiddenField)e.Row.FindControl("hdnGrandTotal10");
                HiddenField hdnGrandTotal11 = (HiddenField)e.Row.FindControl("hdnGrandTotal11");
                HiddenField hdnGrandTotal12 = (HiddenField)e.Row.FindControl("hdnGrandTotal12");
                HiddenField hdnGrandTotal13 = (HiddenField)e.Row.FindControl("hdnGrandTotal13");
                HiddenField hdnGrandTotal14 = (HiddenField)e.Row.FindControl("hdnGrandTotal14");
                HiddenField hdnGrandTotal15 = (HiddenField)e.Row.FindControl("hdnGrandTotal15");

                if (dtQty.Rows.Count > 0)
                {
                    hdnGrandTotal1.Value = dtQty.Rows[0]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[0]["Quantity"].ToString();
                    hdnGrandTotal2.Value = dtQty.Rows[1]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[1]["Quantity"].ToString();
                    hdnGrandTotal3.Value = dtQty.Rows[2]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[2]["Quantity"].ToString();
                    hdnGrandTotal4.Value = dtQty.Rows[3]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[3]["Quantity"].ToString();
                    hdnGrandTotal5.Value = dtQty.Rows[4]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[4]["Quantity"].ToString();
                    hdnGrandTotal6.Value = dtQty.Rows[5]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[5]["Quantity"].ToString();
                    hdnGrandTotal7.Value = dtQty.Rows[6]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[6]["Quantity"].ToString();
                    hdnGrandTotal8.Value = dtQty.Rows[7]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[7]["Quantity"].ToString();
                    hdnGrandTotal9.Value = dtQty.Rows[8]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[8]["Quantity"].ToString();
                    hdnGrandTotal10.Value = dtQty.Rows[9]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[9]["Quantity"].ToString();
                    hdnGrandTotal11.Value = dtQty.Rows[10]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[10]["Quantity"].ToString();
                    hdnGrandTotal12.Value = dtQty.Rows[11]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[11]["Quantity"].ToString();
                    hdnGrandTotal13.Value = dtQty.Rows[12]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[12]["Quantity"].ToString();
                    hdnGrandTotal14.Value = dtQty.Rows[13]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[13]["Quantity"].ToString();
                    hdnGrandTotal15.Value = dtQty.Rows[14]["Quantity"] == DBNull.Value ? "" : dtQty.Rows[14]["Quantity"].ToString();

                }

                if (TotalQuantity1 != 0)
                    lblGrandTotal1.Text = TotalQuantity1.ToString();
                if (TotalQuantity2 != 0)
                    lblGrandTotal2.Text = TotalQuantity2.ToString();
                if (TotalQuantity3 != 0)
                    lblGrandTotal3.Text = TotalQuantity3.ToString();
                if (TotalQuantity4 != 0)
                    lblGrandTotal4.Text = TotalQuantity4.ToString();
                if (TotalQuantity5 != 0)
                    lblGrandTotal5.Text = TotalQuantity5.ToString();
                if (TotalQuantity6 != 0)
                    lblGrandTotal6.Text = TotalQuantity6.ToString();
                if (TotalQuantity7 != 0)
                    lblGrandTotal7.Text = TotalQuantity7.ToString();
                if (TotalQuantity8 != 0)
                    lblGrandTotal8.Text = TotalQuantity8.ToString();
                if (TotalQuantity9 != 0)
                    lblGrandTotal9.Text = TotalQuantity9.ToString();
                if (TotalQuantity10 != 0)
                    lblGrandTotal10.Text = TotalQuantity10.ToString();
                if (TotalQuantity11 != 0)
                    lblGrandTotal11.Text = TotalQuantity11.ToString();
                if (TotalQuantity12 != 0)
                    lblGrandTotal12.Text = TotalQuantity12.ToString();
                if (TotalQuantity13 != 0)
                    lblGrandTotal13.Text = TotalQuantity13.ToString();
                if (TotalQuantity14 != 0)
                    lblGrandTotal14.Text = TotalQuantity14.ToString();
                if (TotalQuantity15 != 0)
                    lblGrandTotal15.Text = TotalQuantity15.ToString();

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

                Label lblFinalGrandTotal = (Label)e.Row.FindControl("lblFinalGrandTotal");
                lblFinalGrandTotal.Text = Math.Round(OptionTotalFinal, 0).ToString();
                HiddenField hdnFinalPassValue = (HiddenField)e.Row.FindControl("hdnFinalPassValue");
                hdnFinalPassValue.Value = Math.Round(PassTotalFinal, 0).ToString();

                //Label lblOptionEntry = (Label)e.Row.FindControl("lblOptionEntry");
                Label lblGrandTotal = (Label)e.Row.FindControl("lblGrandTotal");
                Label lblCutPercent = (Label)e.Row.FindControl("lblCutPercent");
               
                if (FormType == "Cutting")
                {                    
                    lblGrandTotal.Text = "Cut Total";
                    lblCutPercent.Text = "Cut %";
                }
                if (FormType == "CutReady")
                {                    
                    lblGrandTotal.Text = "Cut Ready Total";
                    lblCutPercent.Text = "Cut Ready %";
                }
                else if (FormType == "Stitching")
                {                    
                    lblGrandTotal.Text = "Stitched Total";
                    lblCutPercent.Text = "Stitched %";
                }
                else if (FormType == "Finishing")
                {                   
                    lblGrandTotal.Text = "Finish/Pack Total";
                    lblCutPercent.Text = "Finish/Pack %";
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int SizeOption = -1;
            if (grdSizeOption1.Rows.Count > 0)
            {
                foreach (GridViewRow gvr in grdSizeOption1.Rows)
                {
                    //int OrderDetailId;
                    HiddenField hdnGvOrderDetailId = (HiddenField)gvr.FindControl("hdnGvOrderDetailId");
                    HiddenField hdnQuantity = (HiddenField)gvr.FindControl("hdnQuantity");
                    HiddenField hdnSizeOption = (HiddenField)gvr.FindControl("hdnSizeOption");

                    HiddenField hdnAltPcs = (HiddenField)gvr.FindControl("hdnAltPcs");
                    if (hdnQuantity != null)
                    {
                        Quantity = Convert.ToInt32(hdnQuantity.Value);
                    }
                    if (hdnSizeOption != null)
                    {
                        SizeOption = Convert.ToInt32(hdnSizeOption.Value);
                    }
                    if (hdnOrderDetailId != null)
                    {
                        OrderDetailId = Convert.ToInt32(hdnGvOrderDetailId.Value);

                        FormType = hdnType.Value;

                        dtQty = this.objProductionController.GetSizeQuantity_Option(OrderDetailId, SizeOption, FormType,UnitId);

                        if (hdnAltPcs.Value != "")
                        {
                            Altpcs = Convert.ToInt32(hdnAltPcs.Value);
                        }

                    }
                }
                var footerRow = grdSizeOption1.FooterRow;
                if (footerRow != null)
                {
                    HiddenField hdnGrandTotal1 = (HiddenField)grdSizeOption1.FooterRow.FindControl("hdnGrandTotal1");
                    HiddenField hdnGrandTotal2 = (HiddenField)grdSizeOption1.FooterRow.FindControl("hdnGrandTotal2");
                    HiddenField hdnGrandTotal3 = (HiddenField)grdSizeOption1.FooterRow.FindControl("hdnGrandTotal3");
                    HiddenField hdnGrandTotal4 = (HiddenField)grdSizeOption1.FooterRow.FindControl("hdnGrandTotal4");
                    HiddenField hdnGrandTotal5 = (HiddenField)grdSizeOption1.FooterRow.FindControl("hdnGrandTotal5");
                    HiddenField hdnGrandTotal6 = (HiddenField)grdSizeOption1.FooterRow.FindControl("hdnGrandTotal6");
                    HiddenField hdnGrandTotal7 = (HiddenField)grdSizeOption1.FooterRow.FindControl("hdnGrandTotal7");
                    HiddenField hdnGrandTotal8 = (HiddenField)grdSizeOption1.FooterRow.FindControl("hdnGrandTotal8");
                    HiddenField hdnGrandTotal9 = (HiddenField)grdSizeOption1.FooterRow.FindControl("hdnGrandTotal9");
                    HiddenField hdnGrandTotal10 = (HiddenField)grdSizeOption1.FooterRow.FindControl("hdnGrandTotal10");
                    HiddenField hdnGrandTotal11 = (HiddenField)grdSizeOption1.FooterRow.FindControl("hdnGrandTotal11");
                    HiddenField hdnGrandTotal12 = (HiddenField)grdSizeOption1.FooterRow.FindControl("hdnGrandTotal12");
                    HiddenField hdnGrandTotal13 = (HiddenField)grdSizeOption1.FooterRow.FindControl("hdnGrandTotal13");
                    HiddenField hdnGrandTotal14 = (HiddenField)grdSizeOption1.FooterRow.FindControl("hdnGrandTotal14");
                    HiddenField hdnGrandTotal15 = (HiddenField)grdSizeOption1.FooterRow.FindControl("hdnGrandTotal15");

                    if (dtQty.Rows.Count > 0)
                    {

                        dtQty.Rows[0]["Quantity"] = hdnGrandTotal1.Value == "" ? 0 : Convert.ToInt32(hdnGrandTotal1.Value);
                        dtQty.Rows[1]["Quantity"] = hdnGrandTotal2.Value == "" ? 0 : Convert.ToInt32(hdnGrandTotal2.Value);
                        dtQty.Rows[2]["Quantity"] = hdnGrandTotal3.Value == "" ? 0 : Convert.ToInt32(hdnGrandTotal3.Value);
                        dtQty.Rows[3]["Quantity"] = hdnGrandTotal4.Value == "" ? 0 : Convert.ToInt32(hdnGrandTotal4.Value);
                        dtQty.Rows[4]["Quantity"] = hdnGrandTotal5.Value == "" ? 0 : Convert.ToInt32(hdnGrandTotal5.Value);
                        dtQty.Rows[5]["Quantity"] = hdnGrandTotal6.Value == "" ? 0 : Convert.ToInt32(hdnGrandTotal6.Value);
                        dtQty.Rows[6]["Quantity"] = hdnGrandTotal7.Value == "" ? 0 : Convert.ToInt32(hdnGrandTotal7.Value);
                        dtQty.Rows[7]["Quantity"] = hdnGrandTotal8.Value == "" ? 0 : Convert.ToInt32(hdnGrandTotal8.Value);
                        dtQty.Rows[8]["Quantity"] = hdnGrandTotal9.Value == "" ? 0 : Convert.ToInt32(hdnGrandTotal9.Value);
                        dtQty.Rows[9]["Quantity"] = hdnGrandTotal10.Value == "" ? 0 : Convert.ToInt32(hdnGrandTotal10.Value);
                        dtQty.Rows[10]["Quantity"] = hdnGrandTotal11.Value == "" ? 0 : Convert.ToInt32(hdnGrandTotal11.Value);
                        dtQty.Rows[11]["Quantity"] = hdnGrandTotal12.Value == "" ? 0 : Convert.ToInt32(hdnGrandTotal12.Value);
                        dtQty.Rows[12]["Quantity"] = hdnGrandTotal13.Value == "" ? 0 : Convert.ToInt32(hdnGrandTotal13.Value);
                        dtQty.Rows[13]["Quantity"] = hdnGrandTotal14.Value == "" ? 0 : Convert.ToInt32(hdnGrandTotal14.Value);
                        dtQty.Rows[14]["Quantity"] = hdnGrandTotal15.Value == "" ? 0 : Convert.ToInt32(hdnGrandTotal15.Value);

                        dtQty.AcceptChanges();
                    }

                    dtOrderDetail.Columns.Add("OrderDetailId", typeof(Int64));
                    dtOrderDetail.Columns.Add("Quantity", typeof(int));
                    dtOrderDetail.Columns.Add("FinalPassValue", typeof(int));
                    dtOrderDetail.Columns.Add("AltPcs", typeof(int));

                    DataRow dr = dtOrderDetail.NewRow();
                    dr["OrderDetailId"] = OrderDetailId;
                    dr["Quantity"] = Quantity;
                    dr["FinalPassValue"] = 0;
                    dr["AltPcs"] = Altpcs;
                    dtOrderDetail.Rows.Add(dr);
                    dtOrderDetail.AcceptChanges();
                    DTSize = dtQty;


                    string IsCutMsg = "";

                    HiddenField hdnFinalPassValue = (HiddenField)footerRow.FindControl("hdnFinalPassValue");
                    if (hdnFinalPassValue.Value != "0")
                    {
                        if ((FormType == "Cutting") || (FormType == "CutReady"))
                        {
                            int FinalVal = Convert.ToInt32(hdnFinalPassValue.Value);
                            if (FinalVal < 20)
                            {
                                IsCutMsg = objProductionController.Check_Cut_For_Production(OrderDetailId, "INLINECUT");
                            }
                            else
                            {
                                IsCutMsg = objProductionController.Check_Cut_For_Production(OrderDetailId, "CUTTING");
                            }                          

                            lblMsg.Text = IsCutMsg == "" ? "" : IsCutMsg.ToString();                            

                        }
                    }

                    if ((FormType == "Cutting") || (FormType == "CutReady"))
                    {
                        if (IsCutMsg == "")
                        {
                            SaveSizeEntry();
                        }
                    }
                    else
                    {
                        SaveSizeEntry();
                    }
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "ShowMsg", "CallBackParentPage();", true);
                }
            }
        }
        private void SaveSizeEntry()
        {
            if (DTSize != null)
            {
                try
                {
                    string Size1, Size2, Size3, Size4, Size5, Size6, Size7, Size8, Size9, Size10, Size11, Size12, Size13, Size14, Size15;
                    int Quantity1, Quantity2, Quantity3, Quantity4, Quantity5, Quantity6, Quantity7, Quantity8, Quantity9, Quantity10, Quantity11, Quantity12, Quantity13, Quantity14, Quantity15;
                    
                    int OrderDetailId;
                    FormType = hdnType.Value;

                    if (dtOrderDetail.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtOrderDetail.Rows.Count; i++)
                        {
                            OrderDetailId = Convert.ToInt32(dtOrderDetail.Rows[i]["OrderDetailId"]);
                            //Altpcs = Convert.ToInt32(dtOrderDetail.Rows[i]["Altpcs"]);
                            string _sqlWhere = "OrderDetailId = " + dtOrderDetail.Rows[i]["OrderDetailId"];
                            DataTable dtSize = DTSize.Select(_sqlWhere).CopyToDataTable();

                            Size1 = (dtSize.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtSize.Rows[0]["Size"])).ToString();
                            Quantity1 = dtSize.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtSize.Rows[0]["Quantity"]);

                            Size2 = (dtSize.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtSize.Rows[1]["Size"])).ToString();
                            Quantity2 = dtSize.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtSize.Rows[1]["Quantity"]);

                            Size3 = (dtSize.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtSize.Rows[2]["Size"])).ToString();
                            Quantity3 = dtSize.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtSize.Rows[2]["Quantity"]);

                            Size4 = (dtSize.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtSize.Rows[3]["Size"])).ToString();
                            Quantity4 = dtSize.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtSize.Rows[3]["Quantity"]);

                            Size5 = (dtSize.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtSize.Rows[4]["Size"])).ToString();
                            Quantity5 = dtSize.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtSize.Rows[4]["Quantity"]);

                            Size6 = (dtSize.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtSize.Rows[5]["Size"])).ToString();
                            Quantity6 = dtSize.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtSize.Rows[5]["Quantity"]);

                            Size7 = (dtSize.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtSize.Rows[6]["Size"])).ToString();
                            Quantity7 = dtSize.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtSize.Rows[6]["Quantity"]);

                            Size8 = (dtSize.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtSize.Rows[7]["Size"])).ToString();
                            Quantity8 = dtSize.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtSize.Rows[7]["Quantity"]);

                            Size9 = (dtSize.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtSize.Rows[8]["Size"])).ToString();
                            Quantity9 = dtSize.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtSize.Rows[8]["Quantity"]);

                            Size10 = (dtSize.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtSize.Rows[9]["Size"])).ToString();
                            Quantity10 = dtSize.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtSize.Rows[9]["Quantity"]);

                            Size11 = (dtSize.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtSize.Rows[10]["Size"])).ToString();
                            Quantity11 = dtSize.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtSize.Rows[10]["Quantity"]);

                            Size12 = (dtSize.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtSize.Rows[11]["Size"])).ToString();
                            Quantity12 = dtSize.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtSize.Rows[11]["Quantity"]);


                            Size13 = (dtSize.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtSize.Rows[12]["Size"])).ToString();
                            Quantity13 = dtSize.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtSize.Rows[12]["Quantity"]);

                            Size14 = (dtSize.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtSize.Rows[13]["Size"])).ToString();
                            Quantity14 = dtSize.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtSize.Rows[13]["Quantity"]);

                            Size15 = (dtSize.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtSize.Rows[14]["Size"])).ToString();
                            Quantity15 = dtSize.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtSize.Rows[14]["Quantity"]);

                            UnitId = Convert.ToInt32(hdnUnitId.Value);
                            Altpcs = Convert.ToInt32(hdnTotalAlt.Value);
                            //int TotalQty = Quantity1 + Quantity2 + Quantity3 + Quantity4 + Quantity5 + Quantity6 + Quantity7 + Quantity8 + Quantity9 + Quantity10 + Quantity11 + Quantity12 + Quantity13 + Quantity14 + Quantity15;
                            int iSave = objProductionController.SaveQuantityBySize(OrderDetailId, Size1, Size2, Size3, Size4, Size5, Size6, Size7, Size8, Size9, Size10, Size11, Size12, Size13, Size14, Size15, Quantity1, Quantity2, Quantity3, Quantity4, Quantity5, Quantity6, Quantity7, Quantity8, Quantity9, Quantity10, Quantity11, Quantity12, Quantity13, Quantity14, Quantity15, Altpcs, FormType, UnitId);

                            int TotalQty = Convert.ToInt32(hdnTotalEntry.Value);
                            
                            int iSaveProd = objProductionController.Update_Production_Outhouse(OrderDetailId, TotalQty, Altpcs, UnitId, FormType,iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID);

                        }
                    }
                }
                catch { }
            }
        }
        protected void gdvSizeHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSlotCreatedDate = (Label)e.Row.FindControl("lblSlotCreatedDate");
                Label lblQty1 = (Label)e.Row.FindControl("lblQty1");
                Label lblQty2 = (Label)e.Row.FindControl("lblQty2");
                Label lblQty3 = (Label)e.Row.FindControl("lblQty3");
                Label lblQty4 = (Label)e.Row.FindControl("lblQty4");
                Label lblQty5 = (Label)e.Row.FindControl("lblQty5");
                Label lblQty6 = (Label)e.Row.FindControl("lblQty6");
                Label lblQty7 = (Label)e.Row.FindControl("lblQty7");
                Label lblQty8 = (Label)e.Row.FindControl("lblQty8");
                Label lblQty9 = (Label)e.Row.FindControl("lblQty9");
                Label lblQty10 = (Label)e.Row.FindControl("lblQty10");
                Label lblQty11 = (Label)e.Row.FindControl("lblQty11");
                Label lblQty12 = (Label)e.Row.FindControl("lblQty12");
                Label lblQty13 = (Label)e.Row.FindControl("lblQty13");
                Label lblQty14 = (Label)e.Row.FindControl("lblQty14");
                Label lblQty15 = (Label)e.Row.FindControl("lblQty15");
                Label lblAlt = (Label)e.Row.FindControl("lblAlt");
                Label lblAltpercent = (Label)e.Row.FindControl("lblAltpercent");
                Label lblTotalPass = (Label)e.Row.FindControl("lblTotalPass");
                double TotalPass = 0; double AltPcs = 0; double Altpercent = 0;
                UnitId = Convert.ToInt32(hdnUnitId.Value);
                DateTime CreatedDate = Convert.ToDateTime(lblSlotCreatedDate.Text);
                DataTable dtHistory = this.objProductionController.GetOredrHistoryDetails(OrderDetailId, CreatedDate, FormType, UnitId);
                if (dtHistory.Rows.Count > 0)
                {
                    lblAlt.Text = (dtHistory.Rows[0]["AltPcs"] == DBNull.Value ? "0" : Convert.ToString(dtHistory.Rows[0]["AltPcs"])).ToString();
                    gdvSizeHistory.HeaderRow.Cells[1].Text = (dtHistory.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtHistory.Rows[0]["Size"])).ToString();
                    lblQty1.Text = (dtHistory.Rows[0]["Qty"] == DBNull.Value ? "0" : Convert.ToString(dtHistory.Rows[0]["Qty"])).ToString();
                    TotalPass = Convert.ToInt32(lblQty1.Text);
                    lblQty1.Text = lblQty1.Text == "0" ? "" : lblQty1.Text;
                    if (dtHistory.Rows.Count > 1)
                    {
                        gdvSizeHistory.HeaderRow.Cells[2].Text = (dtHistory.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtHistory.Rows[1]["Size"])).ToString();
                        lblQty2.Text = (dtHistory.Rows[1]["Qty"] == DBNull.Value ? "0" : Convert.ToString(dtHistory.Rows[1]["Qty"])).ToString();
                        TotalPass += Convert.ToInt32(lblQty2.Text);
                        lblQty2.Text = lblQty2.Text == "0" ? "" : lblQty2.Text;
                    }
                    if (dtHistory.Rows.Count > 2)
                    {
                        gdvSizeHistory.HeaderRow.Cells[3].Text = (dtHistory.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtHistory.Rows[2]["Size"])).ToString();
                        lblQty3.Text = (dtHistory.Rows[2]["Qty"] == DBNull.Value ? "0" : Convert.ToString(dtHistory.Rows[2]["Qty"])).ToString();
                        TotalPass += Convert.ToInt32(lblQty3.Text);
                        lblQty3.Text = lblQty3.Text == "0" ? "" : lblQty3.Text;
                    }
                    if (dtHistory.Rows.Count > 3)
                    {
                        gdvSizeHistory.HeaderRow.Cells[4].Text = (dtHistory.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtHistory.Rows[3]["Size"])).ToString();
                        lblQty4.Text = (dtHistory.Rows[3]["Qty"] == DBNull.Value ? "0" : Convert.ToString(dtHistory.Rows[3]["Qty"])).ToString();
                        TotalPass += Convert.ToInt32(lblQty4.Text);
                        lblQty4.Text = lblQty4.Text == "0" ? "" : lblQty4.Text;
                    }
                    if (dtHistory.Rows.Count > 4)
                    {
                        gdvSizeHistory.HeaderRow.Cells[5].Text = (dtHistory.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtHistory.Rows[4]["Size"])).ToString();
                        lblQty5.Text = (dtHistory.Rows[4]["Qty"] == DBNull.Value ? "0" : Convert.ToString(dtHistory.Rows[4]["Qty"])).ToString();
                        TotalPass += Convert.ToInt32(lblQty5.Text);
                        lblQty5.Text = lblQty5.Text == "0" ? "" : lblQty5.Text;
                    }
                    if (dtHistory.Rows.Count > 5)
                    {
                        gdvSizeHistory.HeaderRow.Cells[6].Text = (dtHistory.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtHistory.Rows[5]["Size"])).ToString();
                        lblQty6.Text = (dtHistory.Rows[5]["Qty"] == DBNull.Value ? "0" : Convert.ToString(dtHistory.Rows[5]["Qty"])).ToString();
                        TotalPass += Convert.ToInt32(lblQty6.Text);
                        lblQty6.Text = lblQty6.Text == "0" ? "" : lblQty6.Text;
                    }
                    if (dtHistory.Rows.Count > 6)
                    {
                        gdvSizeHistory.HeaderRow.Cells[7].Text = (dtHistory.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtHistory.Rows[6]["Size"])).ToString();
                        lblQty7.Text = (dtHistory.Rows[6]["Qty"] == DBNull.Value ? "0" : Convert.ToString(dtHistory.Rows[6]["Qty"])).ToString();
                        TotalPass += Convert.ToInt32(lblQty7.Text);
                        lblQty7.Text = lblQty7.Text == "0" ? "" : lblQty7.Text;

                    }
                    if (dtHistory.Rows.Count > 7)
                    {
                        gdvSizeHistory.HeaderRow.Cells[8].Text = (dtHistory.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtHistory.Rows[7]["Size"])).ToString();
                        lblQty8.Text = (dtHistory.Rows[7]["Qty"] == DBNull.Value ? "0" : Convert.ToString(dtHistory.Rows[7]["Qty"])).ToString();
                        TotalPass += Convert.ToInt32(lblQty8.Text);
                        lblQty8.Text = lblQty8.Text == "0" ? "" : lblQty8.Text;
                    }
                    if (dtHistory.Rows.Count > 8)
                    {
                        gdvSizeHistory.HeaderRow.Cells[9].Text = (dtHistory.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtHistory.Rows[8]["Size"])).ToString();
                        lblQty9.Text = (dtHistory.Rows[8]["Qty"] == DBNull.Value ? "0" : Convert.ToString(dtHistory.Rows[8]["Qty"])).ToString();
                        TotalPass += Convert.ToInt32(lblQty9.Text);
                        lblQty9.Text = lblQty9.Text == "0" ? "" : lblQty9.Text;
                    }
                    if (dtHistory.Rows.Count > 9)
                    {
                        gdvSizeHistory.HeaderRow.Cells[10].Text = (dtHistory.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtHistory.Rows[9]["Size"])).ToString();
                        lblQty10.Text = (dtHistory.Rows[9]["Qty"] == DBNull.Value ? "0" : Convert.ToString(dtHistory.Rows[9]["Qty"])).ToString();
                        TotalPass += Convert.ToInt32(lblQty10.Text);
                        lblQty10.Text = lblQty10.Text == "0" ? "" : lblQty10.Text;
                    }
                    if (dtHistory.Rows.Count > 10)
                    {
                        gdvSizeHistory.HeaderRow.Cells[11].Text = (dtHistory.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtHistory.Rows[10]["Size"])).ToString();
                        lblQty11.Text = (dtHistory.Rows[10]["Qty"] == DBNull.Value ? "0" : Convert.ToString(dtHistory.Rows[10]["Qty"])).ToString();
                        TotalPass += Convert.ToInt32(lblQty11.Text);
                        lblQty11.Text = lblQty11.Text == "0" ? "" : lblQty11.Text;
                    }
                    if (dtHistory.Rows.Count > 11)
                    {
                        gdvSizeHistory.HeaderRow.Cells[12].Text = (dtHistory.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtHistory.Rows[11]["Size"])).ToString();
                        lblQty12.Text = (dtHistory.Rows[11]["Qty"] == DBNull.Value ? "0" : Convert.ToString(dtHistory.Rows[11]["Qty"])).ToString();
                        TotalPass += Convert.ToInt32(lblQty12.Text);
                        lblQty12.Text = lblQty12.Text == "0" ? "" : lblQty12.Text;

                    }
                    if (dtHistory.Rows.Count > 12)
                    {
                        gdvSizeHistory.HeaderRow.Cells[13].Text = (dtHistory.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtHistory.Rows[12]["Size"])).ToString();
                        lblQty13.Text = (dtHistory.Rows[12]["Qty"] == DBNull.Value ? "0" : Convert.ToString(dtHistory.Rows[12]["Qty"])).ToString();
                        TotalPass += Convert.ToInt32(lblQty13.Text);
                        lblQty13.Text = lblQty13.Text == "0" ? "" : lblQty13.Text;

                    }
                    if (dtHistory.Rows.Count > 13)
                    {
                        gdvSizeHistory.HeaderRow.Cells[14].Text = (dtHistory.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtHistory.Rows[13]["Size"])).ToString();
                        lblQty14.Text = (dtHistory.Rows[13]["Qty"] == DBNull.Value ? "0" : Convert.ToString(dtHistory.Rows[13]["Qty"])).ToString();
                        TotalPass += Convert.ToInt32(lblQty14.Text);
                        lblQty14.Text = lblQty14.Text == "0" ? "" : lblQty14.Text;
                    }
                    if (dtHistory.Rows.Count > 14)
                    {
                        gdvSizeHistory.HeaderRow.Cells[15].Text = (dtHistory.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtHistory.Rows[14]["Size"])).ToString();
                        lblQty15.Text = (dtHistory.Rows[14]["Qty"] == DBNull.Value ? "0" : Convert.ToString(dtHistory.Rows[14]["Qty"])).ToString();
                        TotalPass += Convert.ToInt32(lblQty15.Text);
                        lblQty15.Text = lblQty15.Text == "0" ? "" : lblQty15.Text;
                    }
                   // gdvSizeHistory.Columns[16].HeaderText = "Alt / Rej. (%) ";
                    gdvSizeHistory.HeaderRow.Cells[16].Text = "Alt / Rej. val (%) ";
                    if (!string.IsNullOrEmpty(e.Row.Cells[16].Text))
                    {
                        e.Row.Cells[16].Text = e.Row.Cells[16].Text + "(" + e.Row.Cells[17].Text + "%)";
                    }
                    else
                    {
 
                    }
                                

                    gdvSizeHistory.Columns[17].Visible = false;

                    //gdvSizeHistory.HeaderRow.Cells[16].Text = "Alt / Rej.";
                    //gdvSizeHistory.HeaderRow.Cells[17].Text = "Alt / Rej.%";
                    gdvSizeHistory.HeaderRow.Cells[18].Text = "Total Pass";


                    AltPcs = Convert.ToDouble(lblAlt.Text);
                    lblTotalPass.Text = (TotalPass).ToString();
                    Altpercent = (AltPcs / (AltPcs + TotalPass)) * 100;
                    if (!Double.IsNaN(Altpercent))
                        lblAltpercent.Text = Math.Round(Altpercent, 0).ToString() == "0" ? "" : Math.Round(Altpercent, 0).ToString();
                }
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                Label lblDate = (Label)e.Row.FindControl("lblDate");
                if (FormType == "Cutting")
                {
                    lblDate.Text = "Cut Date";                    
                }
                if (FormType == "CutReady")
                {
                    lblDate.Text = "Cut Ready Date";
                }
                else if (FormType == "Stitching")
                {
                    lblDate.Text = "Stitch Date";
                }
                else if (FormType == "Finishing")
                {
                    lblDate.Text = "Finish/Pack Date";
                }
            }
        }
    }
}