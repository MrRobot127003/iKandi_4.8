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
    public partial class frmSizeSet_History : System.Web.UI.Page
    {
        ProductionController objProductionController = new ProductionController();
        DataSet ds = new DataSet();
        DataTable dtQty = new DataTable();
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
        public int UnitId
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetQueryString();
                BindSizeOptionData();
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
            if (null != Request.QueryString["StyleId"])
            {
                StyleId = Convert.ToInt32(Request.QueryString["StyleId"].ToString());
                hdnStyleId.Value = StyleId.ToString();
            }
            if (null != Request.QueryString["StyleNumber"])
            {
                StyleNumber = Request.QueryString["StyleNumber"].ToString();
                hdnStyleNumber.Value = StyleNumber;
            }
            if (null != Request.QueryString["UnitId"])
            {
                UnitId = Convert.ToInt32(Request.QueryString["UnitId"].ToString());
                hdnUnitId.Value = UnitId.ToString();
            }
        }
        private void BindSizeOptionData()
        {
            FormType = hdnType.Value;
            OrderId = Convert.ToInt32(hdnOrderId.Value);
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
            if (ds.Tables[1].Rows.Count > 0)
            {
                gdvOrderDetailsHistory.DataSource = ds.Tables[0];
                gdvOrderDetailsHistory.DataBind();
                gdvOrderDetailsHistory.HeaderRow.Cells[0].ColumnSpan = 2;
                gdvOrderDetailsHistory.HeaderRow.Cells[0].Text = "Style No. :-" + "(" + StyleNumber + ") " + " Client :-" + ds.Tables[0].Rows[0]["CompanyName"];
                gdvOrderDetailsHistory.HeaderRow.Cells[1].Visible = false;

                gdvSizeHistory.DataSource = ds.Tables[1];
                gdvSizeHistory.DataBind();
                if (FormType != "Stitching")
                {
                    gdvSizeHistory.Columns[16].Visible = false;
                    gdvSizeHistory.Columns[17].Visible = false;
                }
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
                FormType = hdnType.Value;
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
                    gdvSizeHistory.HeaderRow.Cells[16].Text = "Alt / Rej.";
                    gdvSizeHistory.HeaderRow.Cells[17].Text = "Alt / Rej.%";
                    gdvSizeHistory.HeaderRow.Cells[18].Text = "Total Pass";

                    AltPcs = Convert.ToDouble(lblAlt.Text);
                    lblTotalPass.Text = (TotalPass).ToString();
                    Altpercent = (AltPcs / (AltPcs + TotalPass)) * 100;
                    lblAltpercent.Text = Math.Round(Altpercent, 0).ToString() + " %";
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