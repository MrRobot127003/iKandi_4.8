using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL.Production;
using iKandi.Common;
using System.Data;

namespace iKandi.Web.UserControls.Forms
{
    public partial class ProductionPlanningMatrix : BaseUserControl
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
        private string StyleCode
        {
            get
            {
                if (null != Request.QueryString["StyleCode"])
                {
                    string StyleCode;
                    StyleCode = Request.QueryString["StyleCode"].ToString();
                    return StyleCode;
                }

                return "";
            }
        }
        int OrderDetailId_Row = -1;
        
        int DuplicateOrderDetailId = 0;
        ProductionController objProductionController = new ProductionController();

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            GetProductionMatrixStructure();
            //GetProductionMatrix_Fabric_Accessories();
        }

        private void GetProductionMatrixStructure()
        {
            int FrameNo = -1;          
            TextBox txtLineFrame = this.Parent.FindControl("txtLineFrame") as TextBox;
            if (txtLineFrame != null)
                FrameNo = Convert.ToInt32(txtLineFrame.Text);

            DataSet dsProdMatrixLine;
            dsProdMatrixLine = objProductionController.Production_Matrix_Structure(OrderDetailID, StyleCode, FrameNo);

            DataTable ProductionMatrixHeader = dsProdMatrixLine.Tables[0];
            if (ProductionMatrixHeader.Rows.Count > 0)
            {              
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
                DataTable dtProductionMatrix = dsProdMatrixLine.Tables[1];
                ViewState["dtProductionMatrix"] = dtProductionMatrix;

                grdProductionMatrix.DataSource = dtProductionMatrix;
                grdProductionMatrix.DataBind();
            }
            if (dsProdMatrixLine.Tables.Count > 2)
            {
                DataTable dtFabricAccessMatrix = dsProdMatrixLine.Tables[2];
                ViewState["dtFabricAccessMatrix"] = dtFabricAccessMatrix;

                //GetProductionMatrix_Fabric_Accessories();
                BindFabricAccessGrid();

                grdFabricAccess.DataSource = dtFabricAccessMatrix;
                grdFabricAccess.DataBind();
            }
        }

        private void BindFabricAccessGrid()
        {
            grdFabricAccess.Columns.Clear();
            DataTable dtFabricAccessMatrix = (DataTable)ViewState["dtFabricAccessMatrix"];           
            if (dtFabricAccessMatrix.Columns.Count > 0)
            {
                int ival = 1;
                for (int i = 2; i < dtFabricAccessMatrix.Columns.Count; i++)
                {
                    TemplateField tfFabric = new TemplateField();
                    tfFabric.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "lblFabric" + ival, "lblFabric" + ival);
                    tfFabric.HeaderStyle.CssClass = "Fabtyle";
                    tfFabric.ItemStyle.CssClass = "Fabtyle";
                    tfFabric.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    tfFabric.HeaderText = dtFabricAccessMatrix.Columns[i].ToString();

                    //sFabricDetail = sFabricDetail == "" ? "" : "Fabric$" + sFabricDetail;

                    //string FabricPart = sFabricName.Length > 10 ? sFabricName.Substring(0, 10) : sFabricName;

                    //tablestring = tablestring + "<table cellpadding='0' cellspacing='0' border='0' frame='void' rules='all'>";
                    //tablestring = tablestring + "<tr>";
                    //tablestring = tablestring + "/<td title='" + FabricTooltip + "' style='padding:0px 0px;' class='rotate'  align='center'>" + FabricPart + " (k) <input type='hidden' Id='hdnFabricName' name='hdnFabricName' value='" + sFabricName + "'/> <input type='hidden' Id='hdnFabricDetails' name='hdnFabricDetails' value='" + sFabricDetail + "'/></td>";
                    //tablestring = tablestring + "</tr><table>";

                    //tfFabric.HeaderText = tablestring;
                    //tablestring = "";

                    grdFabricAccess.Columns.Add(tfFabric);
                    ival = ival + 1;
                }
            }
        }


        private void GetProductionMatrix_Fabric_Accessories()
        {
            DataSet dsFabricAccessories;
            dsFabricAccessories = objProductionController.Accessory_Fabric_ForMatrix(OrderDetailID, StyleCode);
            if (dsFabricAccessories.Tables.Count > 0)
            {
                DataTable dtFabric = dsFabricAccessories.Tables[0];
                ViewState["dtFabric"] = dtFabric;
            }
            if (dsFabricAccessories.Tables.Count > 1)
            {
                DataTable dtProdAcc = dsFabricAccessories.Tables[1];
                ViewState["dtProdAcc"] = dtProdAcc;
            }

            //CreateFabric_AccessoriesTable();
           
            BindFabricAccessGrid();

            //DataTable dtFabric_Accessories = (DataTable)ViewState["dtFabric_Accessories"];
            //DataTable dtProductionMatrix = (DataTable)ViewState["dtProductionMatrix"];
            //MatrixCol = dtProductionMatrix.Columns.Count;

            //DataTable dtMatrix_Fabric_Accessories = new DataTable();
            //dtMatrix_Fabric_Accessories = dtProductionMatrix.Copy();

            //if (dtFabric_Accessories.Columns.Count > 0)
            //{
            //    dtMatrix_Fabric_Accessories.Merge(dtFabric_Accessories);
            //    ViewState["dtMatrix_Fabric_Accessories"] = dtMatrix_Fabric_Accessories;

            //    grdFabricAccess.DataSource = dtMatrix_Fabric_Accessories;
            //    grdFabricAccess.DataBind();
               
            //}  
           
        }


        private void CreateFabric_AccessoriesTable()
        {
            DataTable dtFabric = (DataTable)ViewState["dtFabric"];
            DataTable dtProdAcc = (DataTable)ViewState["dtProdAcc"];
            DataTable dtFabric_Accessories = new DataTable();
            if (dtFabric.Rows.Count > 0)
            {
                foreach (DataRow dr in dtFabric.Rows)
                {
                    dtFabric_Accessories.Columns.Add(new DataColumn(dr["FabricName"].ToString(), typeof(string)));
                    dtFabric_Accessories.AcceptChanges();
                }
            }
            if (dtProdAcc.Rows.Count > 0)
            {
                foreach (DataRow dr in dtProdAcc.Rows)
                {
                    dtFabric_Accessories.Columns.Add(new DataColumn(dr["AccessoryName"].ToString(), typeof(string)));
                    dtFabric_Accessories.AcceptChanges();
                }
            }
            ViewState["dtFabric_Accessories"] = dtFabric_Accessories;
        }

        //private void BindFabricAccessGrid()
        //{
        //    grdFabricAccess.Columns.Clear();
        //    DataTable dtFabric = (DataTable)ViewState["dtFabric"];
        //    DataTable dtProdAcc = (DataTable)ViewState["dtProdAcc"];
        //    string sFabricName = "", sFabricDetail = "";
        //    string tablestring = "";
        //    if (dtFabric.Rows.Count > 0)
        //    {
        //        int ival = 1;
        //        for (int i = 0; i < dtFabric.Rows.Count; i++)
        //        {
        //            string[] sFabricArr = dtFabric.Rows[i]["FabricName"].ToString().Split('$');

        //            sFabricName = sFabricArr[1].ToString();
        //            if (sFabricArr.Length > 2)
        //            {
        //                sFabricDetail = sFabricArr[2].ToString();
        //            }
        //            string FabricTooltip = sFabricName + " " + sFabricDetail;

        //            TemplateField tfFabric = new TemplateField();
        //            tfFabric.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "lblFabric" + ival, "lblFabric" + ival);
        //            tfFabric.HeaderStyle.CssClass = "Fabtyle";
        //            tfFabric.ItemStyle.CssClass = "Fabtyle";
        //            tfFabric.ItemStyle.HorizontalAlign = HorizontalAlign.Center;

        //            sFabricDetail = sFabricDetail == "" ? "" : "Fabric$" + sFabricDetail;

        //            string FabricPart = sFabricName.Length > 10 ? sFabricName.Substring(0, 10) : sFabricName;

        //            tablestring = tablestring + "<table cellpadding='0' cellspacing='0' border='0' frame='void' rules='all'>";
        //            tablestring = tablestring + "<tr>";
        //            tablestring = tablestring + "<td title='" + FabricTooltip + "' style='padding:0px 0px;' class='rotate'  align='center'>" + FabricPart + " (k) <input type='hidden' Id='hdnFabricName' name='hdnFabricName' value='" + sFabricName + "'/> <input type='hidden' Id='hdnFabricDetails' name='hdnFabricDetails' value='" + sFabricDetail + "'/></td>";
        //            tablestring = tablestring + "</tr></table>";

        //            tfFabric.HeaderText = tablestring;
        //            tablestring = "";

        //            grdFabricAccess.Columns.Add(tfFabric);
        //            ival = ival + 1;
        //        }
        //    }
        //    if (dtProdAcc.Rows.Count > 0)
        //    {
        //        int ival = 1;
        //        for (int i = 0; i < dtProdAcc.Rows.Count; i++)
        //        {

        //            string[] AccessNameArr = dtProdAcc.Rows[i]["AccessoryName"].ToString().Split('$');

        //            string AccessName = AccessNameArr[1].ToString();

        //            TemplateField tfAccessories = new TemplateField();
        //            tfAccessories.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "lblAccessories" + ival, "lblAccessories" + ival);
        //            tfAccessories.HeaderStyle.CssClass = "Accstyle";
        //            tfAccessories.ItemStyle.CssClass = "Accstyle";
        //            tfAccessories.ItemStyle.HorizontalAlign = HorizontalAlign.Center;

        //            string AccessoriesPart = AccessName.Length > 10 ? AccessName.Substring(0, 10) : AccessName;

        //            tablestring = tablestring + "<table cellpadding='0' cellspacing='0' border='0' frame='void' rules='all'>";
        //            tablestring = tablestring + "<tr>";
        //            tablestring = tablestring + "<td title='" + AccessName + "' style='padding:0px 0px;' class='rotate'  align='center'>" + AccessoriesPart + " (k) <input type='hidden' Id='hdnAccessName' name='hdnAccessName' value='" + AccessName + "'/></td>";
        //            tablestring = tablestring + "</tr></table>";

        //            tfAccessories.HeaderText = tablestring;
        //            tablestring = "";

        //            grdFabricAccess.Columns.Add(tfAccessories);
        //            ival = ival + 1;
        //        }

        //    }
        //}

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

                if(hdnOrderDetailId != null)
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
            //DataTable dtMatrix_Fabric_Accessories = (DataTable)ViewState["dtMatrix_Fabric_Accessories"];
            //int iIndex = 0, OrderDetailId, TotalDayStitch = 0;
            //string sType = "", FabricName = "", FabricDetail = "", Accessories = "";

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
            }

        }

        //protected void grdFabricAccess_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
          
        //    DataTable dtMatrix_Fabric_Accessories = (DataTable)ViewState["dtMatrix_Fabric_Accessories"];
        //    int iIndex = 0, OrderDetailId, TotalDayStitch = 0;
        //    string sType = "", FabricName = "", FabricDetail = "", Accessories = "";  

        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        iIndex = e.Row.RowIndex;

        //        OrderDetailId = Convert.ToInt32(dtMatrix_Fabric_Accessories.Rows[iIndex]["OrderDetailId"]);

        //        if(dtMatrix_Fabric_Accessories.Rows[iIndex]["TotalDayStitch"] != DBNull.Value)
        //        {
        //            TotalDayStitch = Convert.ToInt32(dtMatrix_Fabric_Accessories.Rows[iIndex]["TotalDayStitch"]);
        //        }
        //        int FabricCount = 0;
        //        for(int iColumn = MatrixCol; iColumn < dtMatrix_Fabric_Accessories.Columns.Count; iColumn ++)
        //        {
        //            string FabAccess = dtMatrix_Fabric_Accessories.Columns[iColumn].ColumnName;
        //            string[] FabAccessArr = FabAccess.Split('$');
        //            sType = FabAccessArr[0].ToString();
        //            if(sType == "Fabric")
        //            {
        //                FabricName = FabAccessArr[1].ToString();
        //                if (FabAccessArr.Length > 2)
        //                {
        //                    FabricDetail = FabAccessArr[2].ToString();
        //                }
        //            }
        //            if(sType == "Access")
        //            {
        //                Accessories = FabAccessArr[1].ToString();
        //            }
        //            string sColor = "";//objProductionController.Production_Matrix_Color(OrderDetailId, sType, FabricName, FabricDetail, Accessories, TotalDayStitch);
        //            if (sColor == "Green")
        //            {
        //                e.Row.Cells[FabricCount].CssClass = "ItemBackGreen";
        //            }
        //            else if (sColor == "Red")
        //            {
        //                e.Row.Cells[FabricCount].CssClass = "ItemBackRed";
        //            }
        //            else
        //            {

        //            }

        //            FabricCount = FabricCount + 1;
        //        }
        //    }        
                           
        //}
        
        protected void grdFabricAccess_DataBound(object sender, EventArgs e)
        {
            
        }

    }
}