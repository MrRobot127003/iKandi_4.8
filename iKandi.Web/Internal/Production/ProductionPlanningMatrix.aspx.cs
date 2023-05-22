using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.BLL;
using iKandi.BLL.Production;
using iKandi.Common;
using iKandi.Web.Components;
using System.Web.UI.HtmlControls;

namespace iKandi.Web.Internal.Production
{
    public partial class ProductionPlanningMatrix : System.Web.UI.Page
    {
        public string StyleCode
        {
            get;
            set;
        }
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
        ProductionController objProductionController = new ProductionController();
        AdminController objadmin = new AdminController();
        int OrderDetailId_Row = -1;
        int DuplicateOrderDetailId = 0;
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["StyleCode"] != null)
            {
                StyleCode = Request.QueryString["StyleCode"].ToString();
                lblStylecode.Text = "(" + StyleCode + ")";
                if (OrderDetailID == -1)
                    lblHeader.Text = "Booked Details";
            }
            if (!IsPostBack)
            {
                tblMatrixHdr.Visible = false;
                tblMatrixGrid.Visible = false;
                ViewState["dsProdMatrixLine"] = null;
                ViewState["dsHeader_Matrix"] = null;
                BindControl();
                bindHeader();
            }
        }
        public void BindControl()
        {
            DataSet dsStyle = objProductionController.GetAllQuantity_ByStyleCode(StyleCode, OrderDetailID);

            if (dsStyle.Tables.Count > 0)
            {
                DataTable dtShipped = dsStyle.Tables[0];

                if (dtShipped.Rows.Count > 0)
                {
                    lblqtyorder.Text = dtShipped.Rows[0]["TatalQty"].ToString() == "0" ? "" : dtShipped.Rows[0]["TatalQty"].ToString();
                    if (dtShipped.Rows[0]["shippedqty"].ToString() != "")
                        lblshipedqty.Text = dtShipped.Rows[0]["shippedqty"].ToString() == "0" ? "" : dtShipped.Rows[0]["shippedqty"].ToString();
                    else
                        lblshipedqty.Text = "";
                }

            }
            if (dsStyle.Tables.Count > 1)
            {
                DataTable dtLinePlanFrame = dsStyle.Tables[1];
                if (dsStyle.Tables[1].Rows[0][1].ToString() != "-1")
                {
                    if (dtLinePlanFrame.Rows.Count > 1)
                    {
                        ViewState["dtLinePlanFrame"] = dtLinePlanFrame;
                        dvLinePlanFrame.Visible = true;
                        ddlLinePlanFrame.DataSource = dtLinePlanFrame;
                        ddlLinePlanFrame.DataTextField = "LinePlanFrameDetail";
                        ddlLinePlanFrame.DataValueField = "LinePlanFrameId";
                        ddlLinePlanFrame.DataBind();
                        //txtLineFrame.Text = ddlLinePlanFrame.SelectedValue;
                    }
                }
                else
                {
                    btnShowMatrix.Visible = false;
                    lblMessage.Text = dsStyle.Tables[1].Rows[0][0].ToString();
                }
            }
            else
            {

                btnShowMatrix.Visible = false;
                if (OrderDetailID == -1)
                    lblMessage.Text = "";
                else
                    lblMessage.Text = "Line not planned yet!";
            }
        }

        private void GetProductionMatrixStructure()
        {
            try
            {
                int FrameNo = -1;
                if (ViewState["dtLinePlanFrame"] != null)
                {
                    DataTable dtFrame = (DataTable)ViewState["dtLinePlanFrame"];
                    if (dtFrame.Rows.Count > 1)
                    {
                        FrameNo = Convert.ToInt32(ddlLinePlanFrame.SelectedValue);
                    }
                    else
                    {
                        btnShowMatrix.Visible = false;
                        btnHideMatrix.Visible = true;
                    }
                }
                else
                {
                    btnShowMatrix.Visible = false;
                    btnHideMatrix.Visible = true;
                }

                DataSet dsProdMatrixLine;
                dsProdMatrixLine = objProductionController.Production_Matrix_Structure(OrderDetailID, StyleCode, FrameNo);
                ViewState["dsProdMatrixLine"] = dsProdMatrixLine;

                DataTable ProductionMatrixHeader = dsProdMatrixLine.Tables[0];
                if (ProductionMatrixHeader.Rows.Count > 0)
                {
                    tblMatrixHdr.Visible = true;
                    lblWorkingHrs.Text = ProductionMatrixHeader.Rows[0]["TotalWorkingHrs"].ToString() == "0" ? "" : String.Format("{0:#,##0}", Convert.ToInt32(ProductionMatrixHeader.Rows[0]["TotalWorkingHrs"].ToString()));
                    lblLineQty.Text = ProductionMatrixHeader.Rows[0]["TotalLineQty"].ToString() == "0" ? "" : String.Format("{0:#,##0}", Convert.ToInt32(ProductionMatrixHeader.Rows[0]["TotalLineQty"].ToString()));
                    lblActualStitched.Text = ProductionMatrixHeader.Rows[0]["ActualStitched"].ToString() == "0" ? "" : String.Format("{0:#,##0}", Convert.ToInt32(ProductionMatrixHeader.Rows[0]["ActualStitched"].ToString()));
                    lblSAM.Text = ProductionMatrixHeader.Rows[0]["SAM"].ToString();
                    lblOB.Text = ProductionMatrixHeader.Rows[0]["OB"].ToString();
                    lblAvailMins.Text = ProductionMatrixHeader.Rows[0]["OrderAvailMins"].ToString() == "0" ? "" : String.Format("{0:#,##0}", Convert.ToInt32(ProductionMatrixHeader.Rows[0]["OrderAvailMins"].ToString()));
                    lblLines.Text = ProductionMatrixHeader.Rows[0]["Line"].ToString();
                }
                if (dsProdMatrixLine.Tables.Count > 1)
                {
                    tblMatrixGrid.Visible = true;
                    DataTable dtProductionMatrix = dsProdMatrixLine.Tables[1];
                    ViewState["dtProductionMatrix"] = dtProductionMatrix;

                    grdProductionMatrix.DataSource = dtProductionMatrix;
                    grdProductionMatrix.DataBind();
                }
                if (dsProdMatrixLine.Tables.Count > 2)
                {
                    DataTable dtFabricAccessMatrix = dsProdMatrixLine.Tables[2];
                    ViewState["dtFabricAccessMatrix"] = dtFabricAccessMatrix;

                    GetProductionMatrix_Fabric_Accessories();

                    grdFabricAccess.DataSource = dtFabricAccessMatrix;
                    grdFabricAccess.DataBind();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                btnShowMatrix.Visible = true;
            }

        }
        protected void bindHeader()
        {
            //StyleCode = Session["StyleCode_for_production_matrix"].ToString();
            if (ViewState["dsHeader_Matrix"] == null)
            {
                ds = objadmin.GetHeaderProductionMatrix(StyleCode);
                ViewState["dsHeader_Matrix"] = ds;
            }
            else
            {
                ds = (DataSet)ViewState["dsHeader_Matrix"];
            }
            if (grdProductionMatrixHeader.Columns.Count > 0)
            {
                grdProductionMatrixHeader.Columns.Clear();
            }
            TemplateField StyleNo = new TemplateField();
            StyleNo.HeaderText = "Style No.";
            StyleNo.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "StyleNo", "StyleNo");
            grdProductionMatrixHeader.Columns.Insert(0, StyleNo);
            StyleNo.HeaderStyle.Width = 160;
            StyleNo.HeaderStyle.CssClass = "align-center";


            TemplateField FitStatus = new TemplateField();
            FitStatus.HeaderText = "Fits Status";
            FitStatus.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "FitStatus", "FitStatus");
            grdProductionMatrixHeader.Columns.Insert(1, FitStatus);
            FitStatus.HeaderStyle.Width = 120;



            int Count = Convert.ToInt32(ds.Tables[1].Rows.Count) - 1;
            if (Convert.ToInt32(ds.Tables[1].Rows.Count) > 0)
            {
                for (int i = 0; i <= Count; i++)
                {
                    TemplateField Exfactory = new TemplateField();
                    Exfactory.HeaderText = Convert.ToString("<span  title='Ex-Factory'>" + ds.Tables[1].Rows[i]["Exfactory"]) + "</span>" + "<br/>" + (Convert.ToString(ds.Tables[1].Rows[i]["DcDate"]) != "" ? "(<span style='color:black;font-weight:normal !important;font-size: 8px !important;' title='DC Date'>" + Convert.ToString(ds.Tables[1].Rows[i]["DcDate"]) + "</span>)" : "");
                    Exfactory.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "Exfactory" + Convert.ToString(ds.Tables[1].Rows[i]["Exfactory"]) + Convert.ToString(ds.Tables[1].Rows[i]["DcDate"]), "DcDate" + Convert.ToString(ds.Tables[1].Rows[i]["DcDate"]));
                    // Exfactory.ItemStyle.CssClass = "accorforstyle14";
                    //CN.ItemStyle.Width = 80;
                    Exfactory.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    grdProductionMatrixHeader.Columns.Insert(i + 2, Exfactory);
                    Exfactory.HeaderStyle.Width = 100;
                    Exfactory.HeaderStyle.CssClass = "align-center";
                    Exfactory.HeaderStyle.Font.Bold = true;
                }
            }

            grdProductionMatrixHeader.DataSource = ds.Tables[0];
            grdProductionMatrixHeader.DataBind();

        }

        private void GetProductionMatrix_Fabric_Accessories()
        {
            DataSet dsFabricAccessories;
            dsFabricAccessories = objProductionController.Accessory_Fabric_ForMatrix(OrderDetailID, StyleCode);
            string sFabricName = "", sFabricDetail = "";
            string tablestring = "";

            if (dsFabricAccessories.Tables.Count > 0)
            {
                DataTable dtFabric = dsFabricAccessories.Tables[0];
                if (dtFabric.Rows.Count > 0)
                {
                    int ival = 1;
                    for (int i = 0; i < dtFabric.Rows.Count; i++)
                    {
                        string[] sFabricArr = dtFabric.Rows[i]["FabricName"].ToString().Split('$');

                        sFabricName = sFabricArr[1].ToString();
                        if (sFabricArr.Length > 2)
                        {
                            sFabricDetail = sFabricArr[2].ToString();
                        }
                        string FabricTooltip = sFabricName + " " + sFabricDetail;

                        TemplateField tfFabric = new TemplateField();
                        tfFabric.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "lblFabric" + ival, "lblFabric" + ival);
                        tfFabric.HeaderStyle.CssClass = "Fabtyle";
                        tfFabric.ItemStyle.CssClass = "Fabtyle";
                        tfFabric.ItemStyle.HorizontalAlign = HorizontalAlign.Center;

                        sFabricDetail = sFabricDetail == "" ? "" : "Fabric$" + sFabricDetail;

                        string FabricPart = sFabricName.Length > 10 ? sFabricName.Substring(0, 10) : sFabricName;

                        tablestring = tablestring + "<table cellpadding='0' cellspacing='0' border='0' frame='void' rules='all'>";
                        tablestring = tablestring + "<tr>";
                        tablestring = tablestring + "<td title='" + FabricTooltip + "' style='padding:0px 0px;' class='rotate'  align='center'>" + FabricPart + " (k) <input type='hidden' Id='hdnFabricName' name='hdnFabricName' value='" + sFabricName + "'/> <input type='hidden' Id='hdnFabricDetails' name='hdnFabricDetails' value='" + sFabricDetail + "'/></td>";
                        tablestring = tablestring + "</tr></table>";

                        tfFabric.HeaderText = tablestring;
                        tablestring = "";

                        grdFabricAccess.Columns.Add(tfFabric);
                        ival = ival + 1;
                    }
                }
            }
            if (dsFabricAccessories.Tables.Count > 1)
            {
                DataTable dtProdAcc = dsFabricAccessories.Tables[1];
                int ival = 1;
                for (int i = 0; i < dtProdAcc.Rows.Count; i++)
                {

                    string[] AccessNameArr = dtProdAcc.Rows[i]["AccessoryName"].ToString().Split('$');

                    string AccessName = AccessNameArr[1].ToString();

                    TemplateField tfAccessories = new TemplateField();
                    tfAccessories.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "lblAccessories" + ival, "lblAccessories" + ival);
                    tfAccessories.HeaderStyle.CssClass = "Accstyle";
                    tfAccessories.ItemStyle.CssClass = "Accstyle";
                    tfAccessories.ItemStyle.HorizontalAlign = HorizontalAlign.Center;

                    string AccessoriesPart = AccessName.Length > 10 ? AccessName.Substring(0, 10) : AccessName;

                    tablestring = tablestring + "<table cellpadding='0' cellspacing='0' border='0' frame='void' rules='all'>";
                    tablestring = tablestring + "<tr>";
                    tablestring = tablestring + "<td title='" + AccessName + "' style='padding:0px 0px;' class='rotate'  align='center'>" + AccessoriesPart + " (k) <input type='hidden' Id='hdnAccessName' name='hdnAccessName' value='" + AccessName + "'/></td>";
                    tablestring = tablestring + "</tr></table>";

                    tfAccessories.HeaderText = tablestring;
                    tablestring = "";

                    grdFabricAccess.Columns.Add(tfAccessories);
                    ival = ival + 1;
                }
            }
        }

        protected void grdProductionMatrixHeader_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string str = null;
                string[] strArr = null;
                DataRowView drv = (DataRowView)e.Row.DataItem;
                string StyleNo = drv.Row.ItemArray[0] == DBNull.Value ? "" : drv.Row.ItemArray[0].ToString();
                string Fitsstaus = drv.Row.ItemArray[3] == DBNull.Value ? "" : drv.Row.ItemArray[3].ToString();

                Label LabelStyleNo = e.Row.FindControl("StyleNo") as Label;
                LabelStyleNo.Text = StyleNo;
                LabelStyleNo.ForeColor = System.Drawing.Color.Gray;
                e.Row.Cells[0].CssClass = "align-left";
                e.Row.Cells[0].Width = 160;
                if (StyleNo != "To Be Shipped (Fabric Inhouse)" && StyleNo != "Pending Cut" && StyleNo != "Pending Stitch" && StyleNo != "Pending Finish")
                {
                    LabelStyleNo.ForeColor = System.Drawing.Color.Black;
                }

                Label FitStatus = e.Row.FindControl("FitStatus") as Label;
                FitStatus.Text = Fitsstaus;
                FitStatus.ForeColor = System.Drawing.Color.Gray;
                e.Row.Cells[1].CssClass = "align-left fitsstatus";
                e.Row.Cells[1].Width = 120;

                int Count = Convert.ToInt32(ds.Tables[1].Rows.Count);
                int IsCombined = 0;
                string StyleNoNew = StyleNo;
                DateTime Date, DcDate;
                if (Convert.ToInt32(ds.Tables[1].Rows.Count) > 0)
                {
                    for (int iExfactory = 0; iExfactory < Count; iExfactory++)
                    {
                        string StyleexFactor = Convert.ToString(ds.Tables[1].Rows[iExfactory]["ExFactoryDate"]);
                        //string StyleDCFactor = Convert.ToString(ds.Tables[1].Rows[iExfactory]["DcDate"]);
                        string StyleDCFactor = Convert.ToString(ds.Tables[1].Rows[iExfactory]["DcFactoryDate"]);
                        string gettotalcol = Convert.ToString(ds.Tables[1].Rows[iExfactory]["ExFactory"]);
                        if (StyleexFactor != "Total")
                            Date = Convert.ToDateTime(StyleexFactor);
                        else
                            Date = Convert.ToDateTime("1753-01-01");

                        if (StyleexFactor != "Total")
                            DcDate = Convert.ToDateTime(StyleDCFactor);
                        else
                            DcDate = Convert.ToDateTime("1753-01-01");

                        HtmlTableCell exfactorynew = e.Row.FindControl("Exfactory" + Convert.ToString(ds.Tables[1].Rows[iExfactory]["Exfactory"].ToString() + ds.Tables[1].Rows[iExfactory]["DcDate"].ToString())) as HtmlTableCell;
                        Label exfactory = e.Row.FindControl("Exfactory" + Convert.ToString(ds.Tables[1].Rows[iExfactory]["Exfactory"].ToString() + ds.Tables[1].Rows[iExfactory]["DcDate"].ToString())) as Label;

                        if (StyleNoNew != "To Be Shipped (Fabric Inhouse)" && StyleNoNew != "Pending Cut" && StyleNoNew != "Pending Stitch" && StyleNoNew != "Pending Finish")
                        {
                            str = objadmin.Get_ProductionmatrixPopUp(StyleNoNew, Convert.ToDateTime(Date), IsCombined, DcDate);
                            char[] splitchar = { '~' };
                            strArr = str.Split(splitchar);
                            if (gettotalcol != "Total")
                            {
                                if (strArr.ElementAtOrDefault(2) != null)
                                {
                                    exfactory.Text = strArr[0] + "<span style='float:right;color:Gray' title='Max fabric inhouse end eta'>" + strArr[2] + "<span>";
                                }
                                else
                                {
                                    exfactory.Text = strArr[0];
                                }
                            }
                            else
                            {
                                exfactory.Text = strArr[0];
                            }
                            if (StyleexFactor == "Total")
                            {
                                exfactory.Font.Bold = true;
                            }
                            else
                            {
                                exfactory.Font.Bold = false;
                                if (strArr[1] == "1")
                                    e.Row.Cells[iExfactory + 2].CssClass = "red";
                            }
                        }
                        else
                        {
                            exfactory.Text = objadmin.Get_ProductionmatrixPopUp_BelowGrid(StyleNoNew, Convert.ToDateTime(Date), StyleCode, IsCombined, Convert.ToDateTime(DcDate));
                            exfactory.Font.Bold = true;
                            e.Row.CssClass = "TotalBackColor";
                        }
                    }
                }

            }
        }

        protected void grdProductionMatrix_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnOrderDetailId = (HiddenField)e.Row.FindControl("hdnOrderDetailId");
                HiddenField hdnStitching = (HiddenField)e.Row.FindControl("hdnStitching");
                Label lblDayStitch = (Label)e.Row.FindControl("lblDayStitch");
                Label lblTotalDayStitch = (Label)e.Row.FindControl("lblTotalDayStitch");

                int DayStitch = DataBinder.Eval(e.Row.DataItem, "DayStitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DayStitch"));
                int TotalDayStitch = DataBinder.Eval(e.Row.DataItem, "TotalDayStitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalDayStitch"));


                lblDayStitch.Text = DayStitch == 0 ? "" : DayStitch.ToString("#,##0");
                lblTotalDayStitch.Text = TotalDayStitch == 0 ? "" : TotalDayStitch.ToString("#,##0");

                if (hdnOrderDetailId != null)
                {
                    OrderDetailId_Row = Convert.ToInt32(hdnOrderDetailId.Value);
                    if (DuplicateOrderDetailId == 0)
                    {
                        DuplicateOrderDetailId = OrderDetailId_Row;
                        e.Row.BackColor = System.Drawing.Color.Gray;
                    }
                    else
                    {
                        if (DuplicateOrderDetailId != OrderDetailId_Row)
                        {
                            DuplicateOrderDetailId = OrderDetailId_Row;
                            e.Row.BackColor = System.Drawing.Color.Gray;
                        }
                        else
                        {
                            e.Row.BackColor = System.Drawing.Color.Khaki;
                        }
                    }
                }
                if (hdnStitching != null)
                {
                    if ((hdnStitching.Value == "True") && (DayStitch > 0))
                        e.Row.Cells[5].BackColor = System.Drawing.Color.Green;
                }
            }
        }

        protected void grdFabricAccess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable dtFabricAccessMatrix = (DataTable)ViewState["dtFabricAccessMatrix"];
            int iIndex = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                iIndex = e.Row.RowIndex;
                int iColCount = 0;
                for (int icol = 3; icol < dtFabricAccessMatrix.Columns.Count; icol++)
                {
                    string ColName = dtFabricAccessMatrix.Columns[icol].ToString();

                    string sColor = dtFabricAccessMatrix.Rows[iIndex][ColName].ToString();
                    if (sColor == "Green")
                    {
                        e.Row.Cells[iColCount].CssClass = "ItemBackGreen";
                    }
                    else if (sColor == "Red")
                    {
                        e.Row.Cells[iColCount].CssClass = "ItemBackRed";
                    }
                    else
                    {

                    }
                    iColCount = iColCount + 1;
                }
            }
        }

        protected void btnShowMatrix_Click(object sender, EventArgs e)
        {
            bindHeader();
            if (ViewState["dsProdMatrixLine"] == null)
            {
                GetProductionMatrixStructure();
            }
            else
            {
                if (ViewState["dtLinePlanFrame"] != null)
                {
                    DataTable dtFrame = (DataTable)ViewState["dtLinePlanFrame"];
                    if (dtFrame.Rows.Count > 1)
                    {
                        GetProductionMatrixStructure();
                    }
                }
                else
                {
                    tblMatrixHdr.Visible = true;
                    tblMatrixGrid.Visible = true;
                    btnShowMatrix.Visible = false;
                    btnHideMatrix.Visible = true;
                }
            }
        }

        protected void btnHideMatrix_Click(object sender, EventArgs e)
        {
            bindHeader();
            tblMatrixHdr.Visible = false;
            tblMatrixGrid.Visible = false;
            lblMessage.Text = "";

            btnShowMatrix.Visible = true;
            btnHideMatrix.Visible = false;
        }


    }
}