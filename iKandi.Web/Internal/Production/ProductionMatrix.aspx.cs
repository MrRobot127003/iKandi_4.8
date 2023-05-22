using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.BLL.Production;
using iKandi.Web.Components;
using System.Web.UI.HtmlControls;
using System.Data;

namespace iKandi.Web.Internal.Production
{
    public partial class ProductionMatrix : System.Web.UI.Page
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
        private int LineCount = 1;
        ProductionController objProductionController = new ProductionController();
        int TargetEff = 0;
        int ActualEff = 0;
        int Stitching = 0;
        int DayStitch = 0;
        double ExtraHrs = 0;        
        DateTime LinePlanningDate;
        DateTime ExFactoryDate;
        int Lineno, UnitId;
        DateTime ProductionDate;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            if (!IsPostBack)
            {               
                hdnOrderDetailId.Value = OrderDetailID.ToString();
                GetProductionMatrixLine();               
            }
        }

        private void GetProductionMatrixLine()
        {
            DataSet dsProdMatrixLine;
            int ExFactoryOld = 0;
            int IsHalfStitch = 0;
            int LinePlanningId = 0;
            dsProdMatrixLine = objProductionController.GetProductionMatrix_ByLine(OrderDetailID, out ExFactoryOld);
            if (ExFactoryOld == 0)
            {
                lblExFactoryOld.Text = "";
                LineCount = dsProdMatrixLine.Tables.Count;

                for (int iLine = 0; iLine < LineCount; iLine++)
                {
                    if (iLine == 0)
                    {
                        grdProductionMatrix_Line1.DataSource = dsProdMatrixLine.Tables[0];
                        grdProductionMatrix_Line1.DataBind();
                        tblLine1.Style.Add("display", "block");
                        tdPeakEff1.Style.Add("display", "block");
                        IsHalfStitch = dsProdMatrixLine.Tables[0].Rows[0]["IsHalfStitch"] == DBNull.Value ? 0 : Convert.ToInt32(dsProdMatrixLine.Tables[0].Rows[0]["IsHalfStitch"]);
                        if(IsHalfStitch == 1)
                            lblOperationName1.Text = "Operation Name : " + dsProdMatrixLine.Tables[0].Rows[0]["OperationName"].ToString();

                        hdnLine1.Value = dsProdMatrixLine.Tables[0].Rows[0]["LineNo"].ToString();
                        hdnUnit1.Value = dsProdMatrixLine.Tables[0].Rows[0]["UnitId"].ToString();
                        lblLineNo1.Text = dsProdMatrixLine.Tables[0].Rows[0]["LineNo"].ToString();
                        lblUnit1.Text = dsProdMatrixLine.Tables[0].Rows[0]["FactoryName"].ToString();
                        lblSlot1.Text = dsProdMatrixLine.Tables[0].Rows[0]["LastSlot"].ToString();
                        lblLineQty1.Text = dsProdMatrixLine.Tables[0].Rows[0]["LineQty"].ToString();                        
                        lblLineOB1.Text = dsProdMatrixLine.Tables[0].Rows[0]["LineOB"].ToString();
                        lblLineSAM1.Text = dsProdMatrixLine.Tables[0].Rows[0]["LineSam"].ToString();
                        hdnLinePlanningId1.Value = dsProdMatrixLine.Tables[0].Rows[0]["LinePlanningId"].ToString();
                        Lineno = hdnLine1.Value == "" ? 0 : Convert.ToInt32(hdnLine1.Value);
                        UnitId = hdnUnit1.Value == "" ? 0 : Convert.ToInt32(hdnUnit1.Value);
                        LinePlanningId = dsProdMatrixLine.Tables[0].Rows[0]["LinePlanningId"] == DBNull.Value ? 0 : Convert.ToInt32(dsProdMatrixLine.Tables[0].Rows[0]["LinePlanningId"]);
                        GetPeakCapecity1(LinePlanningId, UnitId);
                    }
                    if (iLine == 1)
                    {
                        grdProductionMatrix_Line2.DataSource = dsProdMatrixLine.Tables[1];
                        grdProductionMatrix_Line2.DataBind();
                        tblLine2.Style.Add("display", "block");
                        tdPeakEff2.Style.Add("display", "block");
                        IsHalfStitch = dsProdMatrixLine.Tables[1].Rows[0]["IsHalfStitch"] == DBNull.Value ? 0 : Convert.ToInt32(dsProdMatrixLine.Tables[1].Rows[0]["IsHalfStitch"]);
                        if (IsHalfStitch == 1)
                            lblOperationName2.Text = "Operation Name : " + dsProdMatrixLine.Tables[1].Rows[0]["OperationName"].ToString();

                        hdnLine2.Value = dsProdMatrixLine.Tables[1].Rows[0]["LineNo"].ToString();
                        hdnUnit2.Value = dsProdMatrixLine.Tables[1].Rows[0]["UnitId"].ToString();
                        lblSlot2.Text = dsProdMatrixLine.Tables[1].Rows[0]["LastSlot"].ToString();
                        lblLineNo2.Text = dsProdMatrixLine.Tables[1].Rows[0]["LineNo"].ToString();
                        lblUnit2.Text = dsProdMatrixLine.Tables[1].Rows[0]["FactoryName"].ToString();
                        lblLineQty2.Text = dsProdMatrixLine.Tables[1].Rows[0]["LineQty"].ToString();
                        lblLineOB2.Text = dsProdMatrixLine.Tables[1].Rows[0]["LineOB"].ToString();
                        lblLineSAM2.Text = dsProdMatrixLine.Tables[1].Rows[0]["LineSam"].ToString();
                        hdnLinePlanningId2.Value = dsProdMatrixLine.Tables[1].Rows[0]["LinePlanningId"].ToString();
                        Lineno = hdnLine2.Value == "" ? 0 : Convert.ToInt32(hdnLine2.Value);
                        UnitId = hdnUnit2.Value == "" ? 0 : Convert.ToInt32(hdnUnit2.Value);
                        LinePlanningId = dsProdMatrixLine.Tables[1].Rows[0]["LinePlanningId"] == DBNull.Value ? 0 : Convert.ToInt32(dsProdMatrixLine.Tables[1].Rows[0]["LinePlanningId"]);
                        GetPeakCapecity2(LinePlanningId, UnitId);                        
                    }
                    if (iLine == 2)
                    {
                        grdProductionMatrix_Line3.DataSource = dsProdMatrixLine.Tables[2];
                        grdProductionMatrix_Line3.DataBind();
                        tblLine3.Style.Add("display", "block");
                        tdPeakEff3.Style.Add("display", "block");
                        IsHalfStitch = dsProdMatrixLine.Tables[2].Rows[0]["IsHalfStitch"] == DBNull.Value ? 0 : Convert.ToInt32(dsProdMatrixLine.Tables[2].Rows[0]["IsHalfStitch"]);
                        if (IsHalfStitch == 1)
                            lblOperationName3.Text = "Operation Name : " + dsProdMatrixLine.Tables[2].Rows[0]["OperationName"].ToString();

                        hdnLine3.Value = dsProdMatrixLine.Tables[2].Rows[0]["LineNo"].ToString();
                        hdnUnit3.Value = dsProdMatrixLine.Tables[2].Rows[0]["UnitId"].ToString();
                        lblSlot3.Text = dsProdMatrixLine.Tables[2].Rows[0]["LastSlot"].ToString();
                        lblLineNo3.Text = dsProdMatrixLine.Tables[2].Rows[0]["LineNo"].ToString();
                        lblUnit3.Text = dsProdMatrixLine.Tables[2].Rows[0]["FactoryName"].ToString();
                        lblLineQty3.Text = dsProdMatrixLine.Tables[2].Rows[0]["LineQty"].ToString();
                        lblLineOB3.Text = dsProdMatrixLine.Tables[2].Rows[0]["LineOB"].ToString();
                        lblLineSAM3.Text = dsProdMatrixLine.Tables[2].Rows[0]["LineSam"].ToString();
                        hdnLinePlanningId3.Value = dsProdMatrixLine.Tables[2].Rows[0]["LinePlanningId"].ToString();
                        Lineno = hdnLine3.Value == "" ? 0 : Convert.ToInt32(hdnLine3.Value);
                        UnitId = hdnUnit3.Value == "" ? 0 : Convert.ToInt32(hdnUnit3.Value);
                        LinePlanningId = dsProdMatrixLine.Tables[2].Rows[0]["LinePlanningId"] == DBNull.Value ? 0 : Convert.ToInt32(dsProdMatrixLine.Tables[2].Rows[0]["LinePlanningId"]);
                        GetPeakCapecity3(LinePlanningId, UnitId);   
                        //GetPeakCapecity3(Lineno, UnitId);
                    }
                    if (iLine == 3)
                    {
                        grdProductionMatrix_Line4.DataSource = dsProdMatrixLine.Tables[3];
                        grdProductionMatrix_Line4.DataBind();
                        tblLine4.Style.Add("display", "block");
                        tdPeakEff4.Style.Add("display", "block");
                        IsHalfStitch = dsProdMatrixLine.Tables[3].Rows[0]["IsHalfStitch"] == DBNull.Value ? 0 : Convert.ToInt32(dsProdMatrixLine.Tables[3].Rows[0]["IsHalfStitch"]);
                        if (IsHalfStitch == 1)
                            lblOperationName4.Text = "Operation Name : " + dsProdMatrixLine.Tables[3].Rows[0]["OperationName"].ToString();

                        hdnLine4.Value = dsProdMatrixLine.Tables[3].Rows[0]["LineNo"].ToString();
                        hdnUnit4.Value = dsProdMatrixLine.Tables[3].Rows[0]["UnitId"].ToString();
                        lblSlot4.Text = dsProdMatrixLine.Tables[3].Rows[0]["LastSlot"].ToString();
                        lblLineNo4.Text = dsProdMatrixLine.Tables[3].Rows[0]["LineNo"].ToString();
                        lblUnit4.Text = dsProdMatrixLine.Tables[3].Rows[0]["FactoryName"].ToString();
                        lblLineQty4.Text = dsProdMatrixLine.Tables[3].Rows[0]["LineQty"].ToString();
                        lblLineOB4.Text = dsProdMatrixLine.Tables[3].Rows[0]["LineOB"].ToString();
                        lblLineSAM4.Text = dsProdMatrixLine.Tables[3].Rows[0]["LineSam"].ToString();
                        hdnLinePlanningId4.Value = dsProdMatrixLine.Tables[3].Rows[0]["LinePlanningId"].ToString();
                        Lineno = hdnLine4.Value == "" ? 0 : Convert.ToInt32(hdnLine4.Value);
                        UnitId = hdnUnit4.Value == "" ? 0 : Convert.ToInt32(hdnUnit4.Value);
                        LinePlanningId = dsProdMatrixLine.Tables[3].Rows[0]["LinePlanningId"] == DBNull.Value ? 0 : Convert.ToInt32(dsProdMatrixLine.Tables[3].Rows[0]["LinePlanningId"]);
                        GetPeakCapecity4(LinePlanningId, UnitId);   
                        //GetPeakCapecity4(Lineno, UnitId);
                    }
                }

                ViewState["dsProdMatrixLine"] = dsProdMatrixLine;                
            }
            else
            {
                lblExFactoryOld.Text = "Ex Factory of this contract is less than today so you can not Plan this.";
            }
            GetProductionMatrix();
        }
        
        private void GetProductionMatrix()
        {
            if (OrderDetailID != -1)
            {
                try
                {         
                    DataSet dsProductionMatrix;
                    dsProductionMatrix = objProductionController.GetProductionMatrix(OrderDetailID);
                    
                    DataTable dtProdHeader = dsProductionMatrix.Tables[0];
                    DataTable dtProdMatrix = dsProductionMatrix.Tables[1];
                    DataTable dtFabric = dsProductionMatrix.Tables[2];
                    DataTable dtProdAcc = dsProductionMatrix.Tables[3];

                    ViewState["dtProdHeader"] = dtProdHeader;
                    ViewState["dtProdAcc"] = dtProdAcc;
                    ViewState["dtFabric"] = dtFabric;

                    lblWorkingHrs.Text = dtProdHeader.Rows[0]["ActualWrkHrs"].ToString();
                    lblOrderQty.Text = dtProdHeader.Rows[0]["OrderQty"].ToString();
                    lblActualStitched.Text = dtProdHeader.Rows[0]["ActualStitched"].ToString();
                    lblSAM.Text = dtProdHeader.Rows[0]["SAM"].ToString();
                    lblOB.Text = dtProdHeader.Rows[0]["OB"].ToString();
                    lblAvailMins.Text = dtProdHeader.Rows[0]["OrderAvailMins"].ToString();
                    lblLines.Text = dtProdHeader.Rows[0]["Line"].ToString();
                    lblSerialNo.Text = dtProdHeader.Rows[0]["SerialNo"].ToString();
                    hdnExFactory.Value = dtProdHeader.Rows[0]["ExFactory"].ToString();
                    chkHalfStitch.Checked = dtProdHeader.Rows[0]["IsHalfStitch"] == DBNull.Value ? false : Convert.ToBoolean(dtProdHeader.Rows[0]["IsHalfStitch"]);
                    if (hdnExFactory.Value != "")
                    {
                        DateTime dtExFactory = Convert.ToDateTime(hdnExFactory.Value).AddDays(1);
                        lblExFactory.Text = dtExFactory.ToString("dd-MMM-yy");
                    }
                    if (dtProdHeader.Rows[0]["TotalExtraHrs"].ToString() != "0")
                        lblShowExtrahrs.Text = "Extra <span style='font-weight:bold;'>" + dtProdHeader.Rows[0]["TotalExtraHrs"].ToString() + "</span> Hrs required on <span style='font-weight:bold;'>" + Convert.ToDateTime(hdnExFactory.Value).ToString("dd-MMM-yy") + "</span> with <span style='font-weight:bold;'>" + dtProdHeader.Rows[0]["TargetEff"].ToString() + "% </span> Eff.";
                    else
                        lblShowExtrahrs.Text = "";

                    grdProductionMatrix.DataSource = dtProdMatrix;
                    grdProductionMatrix.DataBind();

                    CreateAccessoriesTableFinal();
                    CreateAccessoriesTable();


                    DataTable dtFabricAccessories = new DataTable();
                    dtFabricAccessories = dtFabric.Copy();

                    if (dtFabricAccessories.Rows.Count > 0)
                        dtFabricAccessories.Rows.Clear();
                    if (dtProdAcc.Rows.Count > 0)
                    {
                        DataTable dtAccessories = (DataTable)ViewState["dtAccessories"];
                        dtFabricAccessories.Merge(dtAccessories);
                    }
                    BindFabricAccessGrid();

                    if (dtFabricAccessories.Columns.Count > 0)
                    {
                        dtFabricAccessories.Merge(dtProdMatrix);
                        grdFabricAccess.DataSource = dtFabricAccessories;
                        grdFabricAccess.DataBind();
                    }  

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
           
        }

        private void CreateAccessoriesTableFinal()
        {
            DataTable dtProdHeader = (DataTable)ViewState["dtProdHeader"];
            DataTable dtFabric = (DataTable)ViewState["dtFabric"];
            DataTable dtProdAcc = (DataTable)ViewState["dtProdAcc"];
            
            string tablestring = "";
            tablestring = tablestring + "<table  cellpadding='0' cellspacing='0' border='1' style='border-collapse:collapse; border-bottom:0PX !important'>";
           
            //Rqd Qty
            tablestring = tablestring + "<tr><td>";
            if (dtFabric.Columns.Count > 0)
            {
                tablestring = tablestring + "<table  cellpadding='0' cellspacing='0' border='1' style='border-collapse:collapse;' frame='void' rules='all'>";
                tablestring = tablestring + "<tr>";
                double FabricFinal = 0;
                string FabVal = "";
                for (int iFabric = 1; iFabric <= dtFabric.Columns.Count; iFabric++)
                {
                    if (iFabric == 1)
                    {                        
                        FabricFinal = Convert.ToDouble(dtProdHeader.Rows[0]["Fabric1Final"]) > 0 ? Math.Round(Convert.ToDouble(dtProdHeader.Rows[0]["Fabric1Final"]) / 1000, 1) : 0;
                        FabVal = FabricFinal.ToString() == "0" ? "" : FabricFinal.ToString();
                        tablestring = tablestring + "<td style='padding:4px 0px;' class='Accstyle-new'  align='center'>" + FabVal + "</td>";
                    }
                    if (iFabric == 2)
                    {
                        FabricFinal = Convert.ToDouble(dtProdHeader.Rows[0]["Fabric2Final"]) > 0 ? Math.Round(Convert.ToDouble(dtProdHeader.Rows[0]["Fabric2Final"]) / 1000, 1) : 0;
                        FabVal = FabricFinal.ToString() == "0" ? "" : FabricFinal.ToString();
                        tablestring = tablestring + "<td style='padding:4px 0px;' class='Accstyle-new'  align='center'>" + FabVal + "</td>";
                    }
                    if (iFabric == 3)
                    {
                        FabricFinal = Convert.ToDouble(dtProdHeader.Rows[0]["Fabric3Final"]) > 0 ? Math.Round(Convert.ToDouble(dtProdHeader.Rows[0]["Fabric3Final"]) / 1000, 1) : 0;
                        FabVal = FabricFinal.ToString() == "0" ? "" : FabricFinal.ToString();
                        tablestring = tablestring + "<td style='padding:4px 0px;' class='Accstyle-new'  align='center'>" + FabVal + "</td>";
                    }
                    if (iFabric == 4)
                    {
                        FabricFinal = Convert.ToDouble(dtProdHeader.Rows[0]["Fabric4Final"]) > 0 ? Math.Round(Convert.ToDouble(dtProdHeader.Rows[0]["Fabric4Final"]) / 1000, 1) : 0;
                        FabVal = FabricFinal.ToString() == "0" ? "" : FabricFinal.ToString();
                        tablestring = tablestring + "<td style='padding:4px 0px;' class='Accstyle-new'  align='center'>" + FabVal + "</td>";
                    }
                }
                
                tablestring = tablestring + "</tr></table></td>";
            }
            if (dtProdAcc.Rows.Count > 0)
            {
                tablestring = tablestring + "<td><table cellpadding='0' cellspacing='0' border='1' style='border-collapse:collapse;' frame='void' rules='all'>";
                tablestring = tablestring + "<tr>";
                int ival = 1;
                double AccsssQty = 0;
                string AccessVal = "";
                foreach (DataRow dr in dtProdAcc.Rows)
                {                   
                    AccsssQty = Convert.ToDouble(dr["AccsssQty"]) > 0 ? Math.Round(Convert.ToDouble(dr["AccsssQty"]) / 1000, 1) : 0;
                    AccessVal = AccsssQty.ToString() == "0" ? "" : AccsssQty.ToString();
                    tablestring = tablestring + "<td style='padding:4px 0px;' class='Accstyle-new'  align='center'>" + AccessVal + " <input type='hidden' class='hdnAccessoryInhousecls" + ival + "' name='hdnAccessoryAccsssQty" + ival + "' value='" + dr["AccsssQty"].ToString() + "'/></td>";
                    ival = ival + 1;
                }
                tablestring = tablestring + "</tr></table></td>";
            }
            
            tablestring = tablestring + "</tr></table>";
            dvFabricAccFinal.InnerHtml = tablestring;

        }

        private void CreateAccessoriesTable()
        {
            DataTable dtProdHeader = (DataTable)ViewState["dtProdHeader"];
            DataTable dtFabric = (DataTable)ViewState["dtFabric"];
            DataTable dtProdAcc = (DataTable)ViewState["dtProdAcc"];
            DataTable dtAccessories = new DataTable();
            string tablestring = "";
            tablestring = tablestring + "<table  cellpadding='0' cellspacing='0' border='1' style='border-collapse:collapse;'>";
           
            tablestring = tablestring + "<tr><td>";
            if (dtFabric.Columns.Count > 0)
            {
                tablestring = tablestring + "<table  cellpadding='0' cellspacing='0' border='1' style='border-collapse:collapse;' frame='void' rules='all'>";
                // ETA
                tablestring = tablestring + "<tr>";
                string FabVal = "";
                for (int iFabric = 1; iFabric <= dtFabric.Columns.Count; iFabric++)
                {
                    if (iFabric == 1)
                    {
                        FabVal = dtProdHeader.Rows[0]["Fabric1ENDETA"].ToString() == "" ? "" : Convert.ToDateTime(dtProdHeader.Rows[0]["Fabric1ENDETA"]).ToString("dd MMM");
                        tablestring = tablestring + "<td style='padding:4px 0px;' class='Accstyle-new'  align='center'>" + FabVal + "</td>";
                    }
                    if (iFabric == 2)
                    {
                        FabVal = dtProdHeader.Rows[0]["Fabric2ENDETA"].ToString() == "" ? "" : Convert.ToDateTime(dtProdHeader.Rows[0]["Fabric2ENDETA"]).ToString("dd MMM");
                        tablestring = tablestring + "<td style='padding:4px 0px;' class='Accstyle-new'  align='center'>" + FabVal + "</td>";
                    }
                    if (iFabric == 3)
                    {
                        FabVal = dtProdHeader.Rows[0]["Fabric3ENDETA"].ToString() == "" ? "" : Convert.ToDateTime(dtProdHeader.Rows[0]["Fabric3ENDETA"]).ToString("dd MMM");
                        tablestring = tablestring + "<td style='padding:4px 0px;' class='Accstyle-new'  align='center'>" + FabVal + "</td>";
                    }
                    if (iFabric == 4)
                    {
                        FabVal = dtProdHeader.Rows[0]["Fabric4ENDETA"].ToString() == "" ? "" : Convert.ToDateTime(dtProdHeader.Rows[0]["Fabric4ENDETA"]).ToString("dd MMM");
                        tablestring = tablestring + "<td style='padding:4px 0px;' class='Accstyle-new'  align='center'>" + FabVal + "</td>";
                    }
                }
                tablestring = tablestring + "</tr>";

                //In house
                tablestring = tablestring + "<tr>";
                FabVal = "";
                double FabInHouse = 0;
                for (int iFabric = 1; iFabric <= dtFabric.Columns.Count; iFabric++)
                {
                    if (iFabric == 1)
                    {
                        FabInHouse = Convert.ToDouble(dtProdHeader.Rows[0]["Fabric1Inhouse"]) > 0 ? Math.Round(Convert.ToDouble(dtProdHeader.Rows[0]["Fabric1Inhouse"]) / 1000, 1) : 0;
                        FabVal = FabInHouse.ToString() == "0" ? "" : FabInHouse.ToString();
                        tablestring = tablestring + "<td style='padding:4px 0px;' class='Accstyle-new'  align='center'>" + FabVal + "</td>";
                    }
                    if (iFabric == 2)
                    {
                        FabInHouse = Convert.ToDouble(dtProdHeader.Rows[0]["Fabric2Inhouse"]) > 0 ? Math.Round(Convert.ToDouble(dtProdHeader.Rows[0]["Fabric2Inhouse"]) / 1000, 1) : 0;
                        FabVal = FabInHouse.ToString() == "0" ? "" : FabInHouse.ToString();
                        tablestring = tablestring + "<td style='padding:4px 0px;' class='Accstyle-new'  align='center'>" + FabVal + "</td>";
                    }
                    if (iFabric == 3)
                    {
                        FabInHouse = Convert.ToDouble(dtProdHeader.Rows[0]["Fabric3Inhouse"]) > 0 ? Math.Round(Convert.ToDouble(dtProdHeader.Rows[0]["Fabric3Inhouse"]) / 1000, 1) : 0;
                        FabVal = FabInHouse.ToString() == "0" ? "" : FabInHouse.ToString();
                        tablestring = tablestring + "<td style='padding:4px 0px;' class='Accstyle-new'  align='center'>" + FabVal + "</td>";
                    }
                    if (iFabric == 4)
                    {
                        FabInHouse = Convert.ToDouble(dtProdHeader.Rows[0]["Fabric4Inhouse"]) > 0 ? Math.Round(Convert.ToDouble(dtProdHeader.Rows[0]["Fabric4Inhouse"]) / 1000, 1) : 0;
                        FabVal = FabInHouse.ToString() == "0" ? "" : FabInHouse.ToString();
                        tablestring = tablestring + "<td style='padding:4px 0px;' class='Accstyle-new'  align='center'>" + FabVal + "</td>";
                    }
                }
                tablestring = tablestring + "</tr>";
                //Avg
                tablestring = tablestring + "<tr>";
                for (int iFabric = 1; iFabric <= dtFabric.Columns.Count; iFabric++)
                {
                    if (iFabric == 1)
                    {
                        FabVal = dtProdHeader.Rows[0]["Fabric1Avg"].ToString() == "0" ? "" : dtProdHeader.Rows[0]["Fabric1Avg"].ToString();
                        tablestring = tablestring + "<td style='padding:4px 0px;' class='Accstyle-new'  align='center'>" + FabVal + "</td>";
                    }
                    if (iFabric == 2)
                    {
                        FabVal = dtProdHeader.Rows[0]["Fabric2Avg"].ToString() == "0" ? "" : dtProdHeader.Rows[0]["Fabric2Avg"].ToString();
                        tablestring = tablestring + "<td style='padding:4px 0px;' class='Accstyle-new'  align='center'>" + FabVal + "</td>";
                    }
                    if (iFabric == 3)
                    {
                        FabVal = dtProdHeader.Rows[0]["Fabric3Avg"].ToString() == "0" ? "" : dtProdHeader.Rows[0]["Fabric3Avg"].ToString();
                        tablestring = tablestring + "<td style='padding:4px 0px;' class='Accstyle-new'  align='center'>" + FabVal + "</td>";
                    }
                    if (iFabric == 4)
                    {
                        FabVal = dtProdHeader.Rows[0]["Fabric4Avg"].ToString() == "0" ? "" : dtProdHeader.Rows[0]["Fabric4Avg"].ToString();
                        tablestring = tablestring + "<td style='padding:4px 0px;' class='Accstyle-new'  align='center'>" + FabVal + "</td>";
                    }
                }
                tablestring = tablestring + "</tr></table></td>";
            }
            if (dtProdAcc.Rows.Count > 0)
            {
                tablestring = tablestring + "<td><table cellpadding='0' cellspacing='0' border='1' style='border-collapse:collapse;' frame='void' rules='all'>";
                // Accessory ETA
                tablestring = tablestring + "<tr>";
                int ival = 1;
                string AccessVal = "";
                foreach (DataRow dr in dtProdAcc.Rows)
                {
                    AccessVal = dr["AccesoriesETA"].ToString() == "" ? "" : Convert.ToDateTime(dr["AccesoriesETA"]).ToString("dd MMM");
                    tablestring = tablestring + "<td style='padding:4px 0px;' class='Accstyle-new'  align='center'>" + AccessVal + " <input type='hidden' class='hdnAccesoriesETAcls" + ival + "' name='hdnAccesoriesETAId" + ival + "' value='" + dr["AccesoriesETA"].ToString() + "'/></td>";
                    ival = ival + 1;
                }
                tablestring = tablestring + "</tr>";

                // Accessory Inhouse
                tablestring = tablestring + "<tr>";
                ival = 1;
                double AccessInhouse = 0;
                AccessVal = "";
                foreach (DataRow dr in dtProdAcc.Rows)
                {
                    dtAccessories.Columns.Add(new DataColumn(dr["AccessoryName"].ToString(), typeof(string)));
                    dtAccessories.AcceptChanges();
                    AccessInhouse = Convert.ToDouble(dr["AccessoryInhouse"]) > 0 ? Math.Round(Convert.ToDouble(dr["AccessoryInhouse"]) / 1000, 1) : 0;
                    AccessVal = AccessInhouse.ToString() == "0" ? "" : AccessInhouse.ToString();
                    tablestring = tablestring + "<td style='padding:4px 0px;' class='Accstyle-new'  align='center'>" + AccessVal + " <input type='hidden' class='hdnAccessoryInhousecls" + ival + "' name='hdnAccessoryInhouseId" + ival + "' value='" + dr["AccessoryInhouse"].ToString() + "'/></td>";
                    ival = ival + 1;

                }
                tablestring = tablestring + "</tr>";

                ival = 1;
                tablestring = tablestring + "<tr>";
                foreach (DataRow dr in dtProdAcc.Rows)
                {
                    AccessVal = dr["Number"].ToString() == "0" ? "" : dr["Number"].ToString();
                    tablestring = tablestring + "<td style='padding:4px 0px;' class='Accstyle-new'  align='center'>" + AccessVal + " <input type='hidden' class='hdnNumbercls" + ival + "' name='hdnNumberId" + ival + "' value='" + dr["AccessoryInhouse"].ToString() + "'/></td>";
                    ival = ival + 1;
                }
                ViewState["dtAccessories"] = dtAccessories;
                tablestring = tablestring + "</tr></table></td>";
            }
            tablestring = tablestring + "</tr></table>";
            dvFabricAcc.InnerHtml = tablestring;


        }

        private void BindFabricAccessGrid()
        {
            grdFabricAccess.Columns.Clear();
            DataTable dtFabric = (DataTable)ViewState["dtFabric"];
            DataTable dtProdAcc = (DataTable)ViewState["dtProdAcc"];
            if (dtFabric.Rows.Count > 0)
            {
                int ival = 1;
                for (int i = 0; i < dtFabric.Columns.Count; i++)
                {
                    string sFabricName = dtFabric.Rows[0]["Fabric" + ival].ToString();
                    string FabricTitle = dtFabric.Rows[0]["Fabric" + ival].ToString();
                    TemplateField tfFabric = new TemplateField();
                    tfFabric.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "lblFabric" + ival, "lblFabric" + ival);
                    tfFabric.HeaderStyle.CssClass = "Fabtyle";
                    tfFabric.ItemStyle.CssClass = "Fabtyle";
                    tfFabric.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                   // tfFabric.HeaderText = sFabricName.Length > 10 ? sFabricName.Substring(0, 10) : sFabricName;
                    tfFabric.HeaderText = sFabricName.Length > 10 ? "<span class='rotate' title='" + FabricTitle + "'>" + sFabricName.Substring(0, 10) + " (k)" + "</span>" : "<span class='rotate' title='" + FabricTitle + "'>" + sFabricName + " (k)" + "</span>";
                   
                    grdFabricAccess.Columns.Add(tfFabric);
                    ival = ival + 1;
                }
            }
            if (dtProdAcc.Rows.Count > 0)
            {
                DataTable dtAccessories = (DataTable)ViewState["dtAccessories"];
                if (dtAccessories.Columns.Count > 0)
                {
                    int ival = 1;
                    for (int i = 0; i < dtAccessories.Columns.Count; i++)
                    {
                        string AccessName = dtAccessories.Columns[i].ColumnName.ToString();
                        TemplateField tfAccessories = new TemplateField();
                        tfAccessories.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "lblAccessories" + ival, "lblAccessories" + ival);
                        tfAccessories.HeaderStyle.CssClass = "Accstyle";
                        tfAccessories.ItemStyle.CssClass = "Accstyle";
                        tfAccessories.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        //tfAccessories.HeaderText = AccessName.Length > 10 ? AccessName.Substring(0, 10) : AccessName;
                        tfAccessories.HeaderText = AccessName.Length > 10 ? "<span class='rotate' title='" + AccessName + "'>" + AccessName.Substring(0, 10) + " (k)" + "</span>" : "<span class='rotate' title='" + AccessName + "'>" + AccessName + " (k)" + "</span>";
                        grdFabricAccess.Columns.Add(tfAccessories);
                        ival = ival + 1;
                    }
                }
            }
        }

        protected void grdProductionMatrix_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {               

                Label lblTotalDayStitch = (Label)e.Row.FindControl("lblTotalDayStitch");
                if (lblTotalDayStitch.Text == "0")
                    lblTotalDayStitch.Text = "";

                lblTotalDayStitch.CssClass = "TotalBackStitch number-with-commas";

                Label lblExtraHrs = (Label)e.Row.FindControl("lblExtraHrs");
                if (lblExtraHrs.Text == "0")
                    lblExtraHrs.Text = "";

                LinePlanningDate = DataBinder.Eval(e.Row.DataItem, "LinePlanningDate") == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "LinePlanningDate"));
                Stitching = DataBinder.Eval(e.Row.DataItem, "Stitching") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Stitching"));
                Label lblDayStitch = (Label)e.Row.FindControl("lblDayStitch");

                if (lblDayStitch.Text == "0")
                    lblDayStitch.Text = "";

                if (Stitching == 1)
                {
                    e.Row.Cells[3].CssClass = "ItemBackStitch number-with-commas";                            
                }               

                if (hdnExFactory.Value != "")
                    ExFactoryDate = Convert.ToDateTime(hdnExFactory.Value);

                if (LinePlanningDate > ExFactoryDate)
                    e.Row.CssClass = "rowcolor number-with-commas";                    
            }
        }

        protected void grdFabricAccess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable dtFabric = (DataTable)ViewState["dtFabric"];
            DataTable dtProdHeader = (DataTable)ViewState["dtProdHeader"];
            DataTable dtProdAcc = (DataTable)ViewState["dtProdAcc"];            
            int TotalDayStitch = 0;
            double StitchInThousands = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TotalDayStitch = grdFabricAccess.DataKeys[e.Row.RowIndex].Values[0].ToString() == "" ? 0 : Convert.ToInt32(grdFabricAccess.DataKeys[e.Row.RowIndex].Values[0]);
                StitchInThousands = Math.Round(Convert.ToDouble(TotalDayStitch) / 1000, 1);

                int FabricCount = 0;
                for (int i = 1; i <= dtFabric.Columns.Count; i++)
                {
                    if (TotalDayStitch > 0)
                    {                        
                        Label lblFabric = (Label)e.Row.FindControl("lblFabric" + i);
                        if (i == 1)
                        {
                            //double Fabric1Avg = 0;
                            //double Fabric1Stitch = 0;                        
                            //if (dtProdHeader.Rows[0]["Fabric1Avg"].ToString() != "0")
                            //{
                            //    Fabric1Avg = Convert.ToDouble(dtProdHeader.Rows[0]["Fabric1Avg"]);
                            //    Fabric1Stitch = Convert.ToDouble(TotalDayStitch) * Fabric1Avg;
                            //    FabricStitch =  Math.Round(Convert.ToDouble(TotalDayStitch) / 1000, 1);
                            //    lblFabric.Text = FabricStitch.ToString() == "0" ? "" : FabricStitch.ToString();
                            //}  
                            double Fabric1Inhouse = Convert.ToDouble(dtProdHeader.Rows[0]["Fabric1Inhouse"]);
                            if (Convert.ToDouble(TotalDayStitch) <= Fabric1Inhouse)
                            {
                                // green
                                e.Row.Cells[FabricCount].CssClass = "ItemBackGreen";
                            }
                            else
                            {
                                //red
                                e.Row.Cells[FabricCount].CssClass = "ItemBackRed";
                                lblFabric.Text = StitchInThousands.ToString() == "0" ? "" : StitchInThousands.ToString();
                            }

                            FabricCount = FabricCount + 1;
                        }
                        if (i == 2)
                        {
                            //double Fabric2Avg = 0;
                            //double Fabric2Stitch = 0;
                            //if (dtProdHeader.Rows[0]["Fabric2Avg"].ToString() != "0")
                            //{
                            //    Fabric2Avg = Convert.ToDouble(dtProdHeader.Rows[0]["Fabric2Avg"]);
                            //    Fabric2Stitch = Convert.ToDouble(TotalDayStitch) * Fabric2Avg;
                            //    FabricStitch = Fabric2Stitch > 0 ? Math.Round(Fabric2Stitch / 1000, 1) : Fabric2Stitch;
                            //    lblFabric.Text = FabricStitch.ToString() == "0" ? "" : FabricStitch.ToString();
                            //}
                            //if (Fabric2Stitch <= Fabric2Inhouse)
                            //    // green
                            //    e.Row.Cells[FabricCount].CssClass = "ItemBackGreen";
                            //else
                            //    //red
                            //    e.Row.Cells[FabricCount].CssClass = "ItemBackRed";

                            double Fabric2Inhouse = Convert.ToDouble(dtProdHeader.Rows[0]["Fabric2Inhouse"]);                            
                            if (Convert.ToDouble(TotalDayStitch) <= Fabric2Inhouse)
                            {
                                // green
                                e.Row.Cells[FabricCount].CssClass = "ItemBackGreen";
                            }
                            else
                            {
                                //red
                                e.Row.Cells[FabricCount].CssClass = "ItemBackRed";
                                lblFabric.Text = StitchInThousands.ToString() == "0" ? "" : StitchInThousands.ToString();
                            }

                            FabricCount = FabricCount + 1;

                        }
                        if (i == 3)
                        {
                            //double Fabric3Avg = 0;
                            //double Fabric3Stitch = 0;
                            //if (dtProdHeader.Rows[0]["Fabric3Avg"].ToString() != "0")
                            //{
                            //    Fabric3Avg = Convert.ToDouble(dtProdHeader.Rows[0]["Fabric3Avg"]);
                            //    Fabric3Stitch = Convert.ToDouble(TotalDayStitch) * Fabric3Avg;
                            //    FabricStitch = Fabric3Stitch > 0 ? Math.Round(Fabric3Stitch / 1000, 1) : Fabric3Stitch;
                            //    lblFabric.Text = FabricStitch.ToString() == "0" ? "" : FabricStitch.ToString();
                            //}
                            //double Fabric3Inhouse = Convert.ToDouble(dtProdHeader.Rows[0]["Fabric3Inhouse"]);
                            //if (Fabric3Stitch <= Fabric3Inhouse)
                            //    // green
                            //    e.Row.Cells[FabricCount].CssClass = "ItemBackGreen";
                            //else
                            //    //red
                            //    e.Row.Cells[FabricCount].CssClass = "ItemBackRed";

                            double Fabric3Inhouse = Convert.ToDouble(dtProdHeader.Rows[0]["Fabric3Inhouse"]);
                            if (Convert.ToDouble(TotalDayStitch) <= Fabric3Inhouse)
                            {
                                // green
                                e.Row.Cells[FabricCount].CssClass = "ItemBackGreen";
                            }
                            else
                            {
                                //red
                                e.Row.Cells[FabricCount].CssClass = "ItemBackRed";
                                lblFabric.Text = StitchInThousands.ToString() == "0" ? "" : StitchInThousands.ToString();
                            }

                            FabricCount = FabricCount + 1;
                        }
                        if (i == 4)
                        {
                            //double Fabric4Avg = 0;
                            //double Fabric4Stitch = 0;
                            //if (dtProdHeader.Rows[0]["Fabric4Avg"].ToString() != "0")
                            //{
                            //    Fabric4Avg = Convert.ToDouble(dtProdHeader.Rows[0]["Fabric4Avg"]);
                            //    Fabric4Stitch = Convert.ToDouble(TotalDayStitch) * Fabric4Avg;
                            //    FabricStitch = Fabric4Stitch > 0 ? Math.Round(Fabric4Stitch / 1000, 1) : Fabric4Stitch;
                            //    lblFabric.Text = FabricStitch.ToString() == "0" ? "" : FabricStitch.ToString();
                            //}
                            //double Fabric4Inhouse = Convert.ToDouble(dtProdHeader.Rows[0]["Fabric4Inhouse"]);
                            //if (Fabric4Stitch <= Fabric4Inhouse)
                            //    // green
                            //    e.Row.Cells[FabricCount].CssClass = "ItemBackGreen";
                            //else
                            //    //red
                            //    e.Row.Cells[FabricCount].CssClass = "ItemBackRed";

                            double Fabric4Inhouse = Convert.ToDouble(dtProdHeader.Rows[0]["Fabric4Inhouse"]);
                            if (Convert.ToDouble(TotalDayStitch) <= Fabric4Inhouse)
                            {
                                // green
                                e.Row.Cells[FabricCount].CssClass = "ItemBackGreen";
                            }
                            else
                            {
                                //red
                                e.Row.Cells[FabricCount].CssClass = "ItemBackRed";
                                lblFabric.Text = StitchInThousands.ToString() == "0" ? "" : StitchInThousands.ToString();
                            }

                            FabricCount = FabricCount + 1;
                        }
                    }
                }
                int ival = 1;
                int ColCount = FabricCount;
                if (dtProdAcc.Rows.Count > 0)
                {
                    for (int i = 0; i < dtProdAcc.Rows.Count; i++)
                    {                        
                        Label lblAccessories = (Label)e.Row.FindControl("lblAccessories" + ival);
                        //double AccessNumber = 0;
                        //double AccessStitch = 0;
                        //double AccessVal = 0;
                        //if (dtProdAcc.Rows[i]["Number"].ToString() != "")
                        //{
                        //    AccessNumber = Convert.ToDouble(dtProdAcc.Rows[i]["Number"]);
                        //    AccessStitch = Convert.ToDouble(TotalDayStitch) * AccessNumber;
                        //    AccessVal = AccessStitch > 0 ? Math.Round(AccessStitch / 1000, 1) : AccessStitch;
                        //    lblAccessories.Text = AccessVal.ToString() == "0" ? "" : AccessVal.ToString();                            
                        //}
                        if (dtProdAcc.Rows[i]["AccessoryInhouse"].ToString() != "")
                        {
                            double AcceessoryInhouse = Convert.ToDouble(dtProdAcc.Rows[i]["AccessoryInhouse"]);
                            if (Convert.ToDouble(TotalDayStitch) <= AcceessoryInhouse)
                            {
                                //green  
                                e.Row.Cells[ColCount].CssClass = "ItemBackGreen";
                            }
                            else
                            {
                                //red                             
                                e.Row.Cells[ColCount].CssClass = "ItemBackRed";
                                lblAccessories.Text = StitchInThousands.ToString() == "0" ? "" : StitchInThousands.ToString();  
                            }
                        }
                        else
                        { //red
                            e.Row.Cells[ColCount].CssClass = "ItemBackRed";                           
                        }
                        ColCount = ColCount + 1;
                        ival = ival + 1;
                    }
                }
            }
        }
              
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            ViewState["dtProdHeader"] = null;
            ViewState["dtProdAcc"] = null;
            ViewState["dtFabric"] = null;
            ViewState["dtAccessories"] = null;
            grdProductionMatrix.DataSource = null;
            grdProductionMatrix.DataBind();
            grdFabricAccess.DataSource = null;
            grdFabricAccess.DataBind();
            GetProductionMatrixLine();           
        }

        private void GetPeakCapecity1(int LinePlanningId, int UnitId)
        {
            DataTable dtPeakCapecity;
            dtPeakCapecity = objProductionController.Get_PeakEfficiency(OrderDetailID, LinePlanningId, UnitId);
            int IsPlaning = 0;
            if (dtPeakCapecity.Rows.Count > 0)
            {
                IsPlaning = Convert.ToInt32(dtPeakCapecity.Rows[0]["UsingInPlanning"]);
                txtPeakEff1.Text = dtPeakCapecity.Rows[0]["Efficiency"].ToString();
                txtProdDay1.Text = dtPeakCapecity.Rows[0]["ProdDay"].ToString();
                txtPeakcap1.Text = dtPeakCapecity.Rows[0]["PeakCapecity"].ToString();
                txtPeakOB1.Text = dtPeakCapecity.Rows[0]["PeakOB"].ToString();
                
                txtCustomEff1.Text = dtPeakCapecity.Rows[0]["CustEfficiency"].ToString();
                txtCustProdDay1.Text = dtPeakCapecity.Rows[0]["CustProdDay"].ToString();
                if (txtPeakEff1.Text == "")
                    rbtnEff1.Items[1].Enabled = false;

                if (IsPlaning == 0)
                {
                    rbtnEff1.Items[0].Selected = true;
                    rbtnEff1.Items[1].Selected = false;
                    rbtnEff1.Items[2].Selected = false;
                    txtCustomEff1.Attributes.Add("disabled", "disabled");
                    txtCustProdDay1.Attributes.Add("disabled", "disabled");
                }
                if (IsPlaning == 1)
                {
                    rbtnEff1.Items[0].Selected = false;
                    rbtnEff1.Items[1].Selected = true;
                    rbtnEff1.Items[2].Selected = false;
                    txtCustomEff1.Attributes.Add("disabled", "disabled");
                    txtCustProdDay1.Attributes.Add("disabled", "disabled");
                }
                if (IsPlaning == 2)
                {
                    rbtnEff1.Items[0].Selected = false;
                    rbtnEff1.Items[1].Selected = false;
                    rbtnEff1.Items[2].Selected = true;
                }
            }
            else
            {
                rbtnEff1.Items[0].Selected = true;
                rbtnEff1.Items[1].Selected = false;
                rbtnEff1.Items[2].Selected = false;
                rbtnEff1.Items[1].Enabled = false;
                txtCustomEff1.Attributes.Add("disabled", "disabled");
                txtCustProdDay1.Attributes.Add("disabled", "disabled");
            }
        }

        private void GetPeakCapecity2(int LinePlanningId, int UnitId)
        {
            DataTable dtPeakCapecity;
            dtPeakCapecity = objProductionController.Get_PeakEfficiency(OrderDetailID, LinePlanningId, UnitId);
            int IsPlaning = 0;
            if (dtPeakCapecity.Rows.Count > 0)
            {
                IsPlaning = Convert.ToInt32(dtPeakCapecity.Rows[0]["UsingInPlanning"]);
                txtPeakEff2.Text = dtPeakCapecity.Rows[0]["Efficiency"].ToString();
                txtProdDay2.Text = dtPeakCapecity.Rows[0]["ProdDay"].ToString();
                txtPeakcap2.Text = dtPeakCapecity.Rows[0]["PeakCapecity"].ToString();
                txtPeakOB2.Text = dtPeakCapecity.Rows[0]["PeakOB"].ToString();

                txtCustomEff2.Text = dtPeakCapecity.Rows[0]["CustEfficiency"].ToString();
                txtCustProdDay2.Text = dtPeakCapecity.Rows[0]["CustProdDay"].ToString();
                if (txtPeakEff2.Text == "")
                    rbtnEff2.Items[1].Enabled = false;

                if (IsPlaning == 0)
                {
                    rbtnEff2.Items[0].Selected = true;
                    rbtnEff2.Items[1].Selected = false;
                    rbtnEff2.Items[2].Selected = false;
                    txtCustomEff2.Attributes.Add("disabled", "disabled");
                    txtCustProdDay2.Attributes.Add("disabled", "disabled");
                }
                if (IsPlaning == 1)
                {
                    rbtnEff2.Items[0].Selected = false;
                    rbtnEff2.Items[1].Selected = true;
                    rbtnEff2.Items[2].Selected = false;
                    txtCustomEff2.Attributes.Add("disabled", "disabled");
                    txtCustProdDay2.Attributes.Add("disabled", "disabled");
                }
                if (IsPlaning == 2)
                {
                    rbtnEff2.Items[0].Selected = false;
                    rbtnEff2.Items[1].Selected = false;
                    rbtnEff2.Items[2].Selected = true;
                }
            }
            else
            {
                rbtnEff2.Items[0].Selected = true;
                rbtnEff2.Items[1].Selected = false;
                rbtnEff2.Items[2].Selected = false;
                rbtnEff2.Items[1].Enabled = false;
                txtCustomEff2.Attributes.Add("disabled", "disabled");
                txtCustProdDay2.Attributes.Add("disabled", "disabled");
            }
        }

        private void GetPeakCapecity3(int LinePlanningId, int UnitId)
        {
            DataTable dtPeakCapecity;
            dtPeakCapecity = objProductionController.Get_PeakEfficiency(OrderDetailID, LinePlanningId, UnitId);
            int IsPlaning = 0;
            if (dtPeakCapecity.Rows.Count > 0)
            {
                IsPlaning = Convert.ToInt32(dtPeakCapecity.Rows[0]["UsingInPlanning"]);
                txtPeakEff3.Text = dtPeakCapecity.Rows[0]["Efficiency"].ToString();
                txtProdDay3.Text = dtPeakCapecity.Rows[0]["ProdDay"].ToString();
                txtPeakcap3.Text = dtPeakCapecity.Rows[0]["PeakCapecity"].ToString();
                txtPeakOB3.Text = dtPeakCapecity.Rows[0]["PeakOB"].ToString();

                txtCustomEff3.Text = dtPeakCapecity.Rows[0]["CustEfficiency"].ToString();
                txtCustProdDay3.Text = dtPeakCapecity.Rows[0]["CustProdDay"].ToString();
                if (txtPeakEff3.Text == "")
                    rbtnEff3.Items[1].Enabled = false;

                if (IsPlaning == 0)
                {
                    rbtnEff3.Items[0].Selected = true;
                    rbtnEff3.Items[1].Selected = false;
                    rbtnEff3.Items[2].Selected = false;
                    txtCustomEff3.Attributes.Add("disabled", "disabled");
                    txtCustProdDay3.Attributes.Add("disabled", "disabled");
                }
                if (IsPlaning == 1)
                {
                    rbtnEff3.Items[0].Selected = false;
                    rbtnEff3.Items[1].Selected = true;
                    rbtnEff3.Items[2].Selected = false;
                    txtCustomEff3.Attributes.Add("disabled", "disabled");
                    txtCustProdDay3.Attributes.Add("disabled", "disabled");
                }
                if (IsPlaning == 2)
                {
                    rbtnEff3.Items[0].Selected = false;
                    rbtnEff3.Items[1].Selected = false;
                    rbtnEff3.Items[2].Selected = true;
                }
            }
            else
            {
                rbtnEff3.Items[0].Selected = true;
                rbtnEff3.Items[1].Selected = false;
                rbtnEff3.Items[2].Selected = false;
                rbtnEff3.Items[1].Enabled = false;
                txtCustomEff3.Attributes.Add("disabled", "disabled");
                txtCustProdDay3.Attributes.Add("disabled", "disabled");
            }
        }

        private void GetPeakCapecity4(int LinePlanningId, int UnitId)
        {
            DataTable dtPeakCapecity;
            dtPeakCapecity = objProductionController.Get_PeakEfficiency(OrderDetailID, LinePlanningId, UnitId);
            int IsPlaning = 0;
            if (dtPeakCapecity.Rows.Count > 0)
            {
                IsPlaning = Convert.ToInt32(dtPeakCapecity.Rows[0]["UsingInPlanning"]);
                txtPeakEff4.Text = dtPeakCapecity.Rows[0]["Efficiency"].ToString();
                txtProdDay4.Text = dtPeakCapecity.Rows[0]["ProdDay"].ToString();
                txtPeakcap4.Text = dtPeakCapecity.Rows[0]["PeakCapecity"].ToString();
                txtPeakOB4.Text = dtPeakCapecity.Rows[0]["PeakOB"].ToString();

                txtCustomEff4.Text = dtPeakCapecity.Rows[0]["CustEfficiency"].ToString();
                txtCustProdDay4.Text = dtPeakCapecity.Rows[0]["CustProdDay"].ToString();

                if (txtPeakEff4.Text == "")
                    rbtnEff4.Items[1].Enabled = false;

                if (IsPlaning == 0)
                {
                    rbtnEff4.Items[0].Selected = true;
                    rbtnEff4.Items[1].Selected = false;
                    rbtnEff4.Items[2].Selected = false;
                    txtCustomEff4.Attributes.Add("disabled", "disabled");
                    txtCustProdDay4.Attributes.Add("disabled", "disabled");
                }
                if (IsPlaning == 1)
                {
                    rbtnEff4.Items[0].Selected = false;
                    rbtnEff4.Items[1].Selected = true;
                    rbtnEff4.Items[2].Selected = false;
                    txtCustomEff4.Attributes.Add("disabled", "disabled");
                    txtCustProdDay4.Attributes.Add("disabled", "disabled");
                }
                if (IsPlaning == 2)
                {
                    rbtnEff4.Items[0].Selected = false;
                    rbtnEff4.Items[1].Selected = false;
                    rbtnEff4.Items[2].Selected = true;
                }
            }
            else
            {
                rbtnEff4.Items[0].Selected = true;
                rbtnEff4.Items[1].Selected = false;
                rbtnEff4.Items[2].Selected = false;
                rbtnEff4.Items[1].Enabled = false;
                txtCustomEff4.Attributes.Add("disabled", "disabled");
                txtCustProdDay4.Attributes.Add("disabled", "disabled");
            }
        }

        protected void btnSubmit1_Click(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null)
            {                
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "CloseWindow();", true);
            }
            else
            {
                int UsingInPlanning = 0;
                double CustEfficiency = 0;
                int CustProdDay = 0;
                int LinePlanningId = 0;
                UsingInPlanning = Convert.ToInt32(rbtnEff1.SelectedItem.Value);
                if (UsingInPlanning == 2)
                {
                    if (txtCustomEff1.Text != "")
                        CustEfficiency = Convert.ToInt32(txtCustomEff1.Text);
                    if (txtCustProdDay1.Text != "")
                        CustProdDay = Convert.ToInt32(txtCustProdDay1.Text);
                }
                int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                Lineno = hdnLine1.Value == "" ? 0 : Convert.ToInt32(hdnLine1.Value);
                UnitId = hdnUnit1.Value == "" ? 0 : Convert.ToInt32(hdnUnit1.Value);
                LinePlanningId = hdnLinePlanningId1.Value == "" ? 0 : Convert.ToInt32(hdnLinePlanningId1.Value);
                foreach (GridViewRow gvr in grdProductionMatrix_Line1.Rows)
                {
                    //HiddenField hdnLinePlanningId = (HiddenField)gvr.FindControl("hdnLinePlanningId");
                    //if (hdnLinePlanningId.Value != "")
                    //    LinePlanningId = Convert.ToInt32(hdnLinePlanningId.Value);

                    HiddenField hdnLinePlanningDate = (HiddenField)gvr.FindControl("hdnLinePlanningDate");
                    if (hdnLinePlanningDate.Value != "")
                    {
                        ProductionDate = Convert.ToDateTime(hdnLinePlanningDate.Value).Date;
                    }
                    DropDownList ddlHrsAdd = (DropDownList)gvr.FindControl("ddlHrsAdd");                  
                    if (hdnLinePlanningDate.Value != "")
                    {
                        if (ProductionDate >= DateTime.Now.Date)
                        {
                            ExtraHrs = ddlHrsAdd.SelectedValue == "" ? 0 : Convert.ToDouble(ddlHrsAdd.SelectedValue);

                            int iExtraHrsSave = objProductionController.SaveProduction_ExtraHrs(OrderDetailID, ProductionDate.ToString("MM/dd/yyyy"), ExtraHrs, LinePlanningId, UnitId);
                        }
                    }                   
                }

                int isave = objProductionController.SavePeakCapecity_ByProdPlanning(OrderDetailID, UsingInPlanning, CustEfficiency, CustProdDay, LinePlanningId, UnitId, UserId);
                System.Threading.Thread.Sleep(1000);
                ViewState["dtProdHeader"] = null;
                ViewState["dtProdAcc"] = null;
                ViewState["dtFabric"] = null;
                ViewState["dtAccessories"] = null;
                grdProductionMatrix.DataSource = null;
                grdProductionMatrix.DataBind();
                grdFabricAccess.DataSource = null;
                grdFabricAccess.DataBind();
                grdProductionMatrix_Line1.DataSource = null;
                grdProductionMatrix_Line1.DataBind();
                GetProductionMatrixLine();                
            }
        }

        protected void btnSubmit2_Click(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "CloseWindow();", true);
            }
            else
            {
                int UsingInPlanning = 0;
                double CustEfficiency = 0;
                int CustProdDay = 0;
                int LinePlanningId = 0;
                UsingInPlanning = Convert.ToInt32(rbtnEff2.SelectedItem.Value);
                if (UsingInPlanning == 2)
                {
                    if (txtCustomEff2.Text != "")
                        CustEfficiency = Convert.ToInt32(txtCustomEff2.Text);
                    if (txtCustProdDay2.Text != "")
                        CustProdDay = Convert.ToInt32(txtCustProdDay2.Text);
                }
                int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                Lineno = hdnLine2.Value == "" ? 0 : Convert.ToInt32(hdnLine2.Value);
                UnitId = hdnUnit2.Value == "" ? 0 : Convert.ToInt32(hdnUnit2.Value);
                LinePlanningId = hdnLinePlanningId2.Value == "" ? 0 : Convert.ToInt32(hdnLinePlanningId2.Value);
                foreach (GridViewRow gvr in grdProductionMatrix_Line2.Rows)
                {
                    HiddenField hdnLinePlanningId = (HiddenField)gvr.FindControl("hdnLinePlanningId");
                    if (hdnLinePlanningId.Value != "")
                        LinePlanningId = Convert.ToInt32(hdnLinePlanningId.Value);

                    HiddenField hdnLinePlanningDate = (HiddenField)gvr.FindControl("hdnLinePlanningDate");
                    if (hdnLinePlanningDate.Value != "")
                    {
                        ProductionDate = Convert.ToDateTime(hdnLinePlanningDate.Value).Date;
                    }
                    DropDownList ddlHrsAdd = (DropDownList)gvr.FindControl("ddlHrsAdd");                    
                    if (hdnLinePlanningDate.Value != "")
                    {
                        if (ProductionDate >= DateTime.Now.Date)
                        {
                            ExtraHrs = ddlHrsAdd.SelectedValue == "" ? 0 : Convert.ToDouble(ddlHrsAdd.SelectedValue);

                            int iExtraHrsSave = objProductionController.SaveProduction_ExtraHrs(OrderDetailID, ProductionDate.ToString("MM/dd/yyyy"), ExtraHrs, LinePlanningId, UnitId);
                        }
                    }                  
                }


                int isave = objProductionController.SavePeakCapecity_ByProdPlanning(OrderDetailID, UsingInPlanning, CustEfficiency, CustProdDay, LinePlanningId, UnitId, UserId);

                System.Threading.Thread.Sleep(1000);
                ViewState["dtProdHeader"] = null;
                ViewState["dtProdAcc"] = null;
                ViewState["dtFabric"] = null;
                ViewState["dtAccessories"] = null;
                grdProductionMatrix.DataSource = null;
                grdProductionMatrix.DataBind();
                grdFabricAccess.DataSource = null;
                grdFabricAccess.DataBind();
                GetProductionMatrixLine();
                //GetProductionMatrix();
            }
        }

        protected void btnSubmit3_Click(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "CloseWindow();", true);
            }
            else
            {
                int UsingInPlanning = 0;
                double CustEfficiency = 0;
                int CustProdDay = 0;
                int LinePlanningId = 0;
                UsingInPlanning = Convert.ToInt32(rbtnEff3.SelectedItem.Value);
                if (UsingInPlanning == 2)
                {
                    if (txtCustomEff3.Text != "")
                        CustEfficiency = Convert.ToInt32(txtCustomEff3.Text);
                    if (txtCustProdDay2.Text != "")
                        CustProdDay = Convert.ToInt32(txtCustProdDay3.Text);
                }
                int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                Lineno = hdnLine3.Value == "" ? 0 : Convert.ToInt32(hdnLine3.Value);
                UnitId = hdnUnit3.Value == "" ? 0 : Convert.ToInt32(hdnUnit3.Value);
                LinePlanningId = hdnLinePlanningId3.Value == "" ? 0 : Convert.ToInt32(hdnLinePlanningId3.Value);
                foreach (GridViewRow gvr in grdProductionMatrix_Line3.Rows)
                {
                    //HiddenField hdnLinePlanningId = (HiddenField)gvr.FindControl("hdnLinePlanningId");
                    //if (hdnLinePlanningId.Value != "")
                    //    LinePlanningId = Convert.ToInt32(hdnLinePlanningId.Value);

                    HiddenField hdnLinePlanningDate = (HiddenField)gvr.FindControl("hdnLinePlanningDate");
                    if (hdnLinePlanningDate.Value != "")
                    {
                        ProductionDate = Convert.ToDateTime(hdnLinePlanningDate.Value).Date;
                    }
                    DropDownList ddlHrsAdd = (DropDownList)gvr.FindControl("ddlHrsAdd");                    
                    if (hdnLinePlanningDate.Value != "")
                    {
                        if (ProductionDate >= DateTime.Now.Date)
                        {
                            ExtraHrs = ddlHrsAdd.SelectedValue == "" ? 0 : Convert.ToDouble(ddlHrsAdd.SelectedValue);
                            int iExtraHrsSave = objProductionController.SaveProduction_ExtraHrs(OrderDetailID, ProductionDate.ToString("MM/dd/yyyy"), ExtraHrs, LinePlanningId, UnitId);
                        }
                    }                   
                }

                int isave = objProductionController.SavePeakCapecity_ByProdPlanning(OrderDetailID, UsingInPlanning, CustEfficiency, CustProdDay, LinePlanningId, UnitId, UserId);

                System.Threading.Thread.Sleep(1000);
                ViewState["dtProdHeader"] = null;
                ViewState["dtProdAcc"] = null;
                ViewState["dtFabric"] = null;
                ViewState["dtAccessories"] = null;
                grdProductionMatrix.DataSource = null;
                grdProductionMatrix.DataBind();
                grdFabricAccess.DataSource = null;
                grdFabricAccess.DataBind();
                GetProductionMatrixLine();
                //GetProductionMatrix();
            }
        }

        protected void btnSubmit4_Click(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "CloseWindow();", true);
            }
            else
            {
                int UsingInPlanning = 0;
                double CustEfficiency = 0;
                int CustProdDay = 0;
                int LinePlanningId = 0;
                UsingInPlanning = Convert.ToInt32(rbtnEff4.SelectedItem.Value);
                if (UsingInPlanning == 2)
                {
                    if (txtCustomEff4.Text != "")
                        CustEfficiency = Convert.ToInt32(txtCustomEff4.Text);
                    if (txtCustProdDay4.Text != "")
                        CustProdDay = Convert.ToInt32(txtCustProdDay4.Text);
                }
                int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                Lineno = hdnLine4.Value == "" ? 0 : Convert.ToInt32(hdnLine4.Value);
                UnitId = hdnUnit4.Value == "" ? 0 : Convert.ToInt32(hdnUnit4.Value);
                LinePlanningId = hdnLinePlanningId4.Value == "" ? 0 : Convert.ToInt32(hdnLinePlanningId4.Value);
                foreach (GridViewRow gvr in grdProductionMatrix_Line4.Rows)
                {
                    //HiddenField hdnLinePlanningId = (HiddenField)gvr.FindControl("hdnLinePlanningId");
                    //if (hdnLinePlanningId.Value != "")
                    //    LinePlanningId = Convert.ToInt32(hdnLinePlanningId.Value);

                    HiddenField hdnLinePlanningDate = (HiddenField)gvr.FindControl("hdnLinePlanningDate");
                    if (hdnLinePlanningDate.Value != "")
                    {
                        ProductionDate = Convert.ToDateTime(hdnLinePlanningDate.Value).Date;
                    }
                    DropDownList ddlHrsAdd = (DropDownList)gvr.FindControl("ddlHrsAdd");                   
                    if (hdnLinePlanningDate.Value != "")
                    {
                        if (ProductionDate >= DateTime.Now.Date)
                        {
                            ExtraHrs = ddlHrsAdd.SelectedValue == "" ? 0 : Convert.ToDouble(ddlHrsAdd.SelectedValue);

                            int iExtraHrsSave = objProductionController.SaveProduction_ExtraHrs(OrderDetailID, ProductionDate.ToString("MM/dd/yyyy"), ExtraHrs, LinePlanningId, UnitId);
                        }
                    }
                  
                }

                int isave = objProductionController.SavePeakCapecity_ByProdPlanning(OrderDetailID, UsingInPlanning, CustEfficiency, CustProdDay, LinePlanningId, UnitId, UserId);
                System.Threading.Thread.Sleep(1000);
                ViewState["dtProdHeader"] = null;
                ViewState["dtProdAcc"] = null;
                ViewState["dtFabric"] = null;
                ViewState["dtAccessories"] = null;
                grdProductionMatrix.DataSource = null;
                grdProductionMatrix.DataBind();
                grdFabricAccess.DataSource = null;
                grdFabricAccess.DataBind();
                GetProductionMatrixLine();
                //GetProductionMatrix();
            }
        }            
      
        protected void grdProductionMatrix_Line1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                TargetEff = DataBinder.Eval(e.Row.DataItem, "TargetEff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TargetEff"));
                ActualEff = DataBinder.Eval(e.Row.DataItem, "ActualEff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ActualEff"));
                Stitching = DataBinder.Eval(e.Row.DataItem, "Stitching") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Stitching"));
                ExtraHrs = DataBinder.Eval(e.Row.DataItem, "ExtraHours") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ExtraHours"));
                DayStitch = DataBinder.Eval(e.Row.DataItem, "DayStitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DayStitch"));
                LinePlanningDate = DataBinder.Eval(e.Row.DataItem, "LinePlanningDate") == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "LinePlanningDate"));
                ExFactoryDate = DataBinder.Eval(e.Row.DataItem, "ExFactory") == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "ExFactory"));

                Label lblTargetEff = (Label)e.Row.FindControl("lblTargetEff");
                Label lblActualEff = (Label)e.Row.FindControl("lblActualEff");
                DropDownList ddlHrsAdd = (DropDownList)e.Row.FindControl("ddlHrsAdd");
                Label lblDayStitch = (Label)e.Row.FindControl("lblDayStitch");
                Label lblTotalDayStitch = (Label)e.Row.FindControl("lblTotalDayStitch");

                if (lblTotalDayStitch.Text == "0")
                    lblTotalDayStitch.Text = "";

                lblTotalDayStitch.CssClass = "TotalBackStitch number-with-commas";

                if ((ExtraHrs == 0) || (ExtraHrs == 3.25) || (ExtraHrs == 8))
                {
                    ddlHrsAdd.SelectedValue = ExtraHrs.ToString();
                }

                if (Stitching == 1)
                {
                    ddlHrsAdd.Enabled = false;
                    e.Row.Cells[5].CssClass = "ItemBackStitch number-with-commas";
                    e.Row.Cells[6].CssClass = "ItemBackStitch number-with-commas";
                }
                if (LinePlanningDate == DateTime.Now.Date)
                    ddlHrsAdd.Enabled = true;

                if (LinePlanningDate < DateTime.Now.Date)
                    ddlHrsAdd.Enabled = false;

                if (TargetEff != 0)
                    lblTargetEff.Text = TargetEff.ToString() + "%";
                else
                    lblTargetEff.Text = "";

                if (ActualEff != 0)
                    lblActualEff.Text = ActualEff.ToString() + "%";
                else
                    lblActualEff.Text = "";

               
                if (DayStitch == 0)
                    lblDayStitch.Text = "";               

                if (LinePlanningDate > ExFactoryDate)
                    e.Row.CssClass = "rowcolor Line1Row number-with-commas";
            }
        }

        protected void grdProductionMatrix_Line2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                TargetEff = DataBinder.Eval(e.Row.DataItem, "TargetEff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TargetEff"));
                ActualEff = DataBinder.Eval(e.Row.DataItem, "ActualEff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ActualEff"));
                Stitching = DataBinder.Eval(e.Row.DataItem, "Stitching") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Stitching"));
                ExtraHrs = DataBinder.Eval(e.Row.DataItem, "ExtraHours") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ExtraHours"));
                DayStitch = DataBinder.Eval(e.Row.DataItem, "DayStitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DayStitch"));
                LinePlanningDate = DataBinder.Eval(e.Row.DataItem, "LinePlanningDate") == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "LinePlanningDate"));
                ExFactoryDate = DataBinder.Eval(e.Row.DataItem, "ExFactory") == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "ExFactory"));

                Label lblTargetEff = (Label)e.Row.FindControl("lblTargetEff");
                Label lblActualEff = (Label)e.Row.FindControl("lblActualEff");
                DropDownList ddlHrsAdd = (DropDownList)e.Row.FindControl("ddlHrsAdd");
                Label lblDayStitch = (Label)e.Row.FindControl("lblDayStitch");
                Label lblTotalDayStitch = (Label)e.Row.FindControl("lblTotalDayStitch");

                if (lblTotalDayStitch.Text == "0")
                    lblTotalDayStitch.Text = "";

                lblTotalDayStitch.CssClass = "TotalBackStitch number-with-commas";

                if ((ExtraHrs == 0) || (ExtraHrs == 3.25) || (ExtraHrs == 8))
                {
                    ddlHrsAdd.SelectedValue = ExtraHrs.ToString();
                }

                if (Stitching == 1)
                {
                    e.Row.Cells[5].CssClass = "ItemBackStitch number-with-commas";
                    e.Row.Cells[6].CssClass = "ItemBackStitch number-with-commas";
                    ddlHrsAdd.Enabled = false;
                }
                if (LinePlanningDate == DateTime.Now.Date)
                    ddlHrsAdd.Enabled = true;

                if (LinePlanningDate < DateTime.Now.Date)
                    ddlHrsAdd.Enabled = false;

                if (TargetEff != 0)
                    lblTargetEff.Text = TargetEff.ToString() + "%";
                else
                    lblTargetEff.Text = "";

                if (ActualEff != 0)
                    lblActualEff.Text = ActualEff.ToString() + "%";
                else
                    lblActualEff.Text = "";                

                if (DayStitch == 0)
                    lblDayStitch.Text = "";                

                if (LinePlanningDate > ExFactoryDate)
                    e.Row.CssClass = "rowcolor Line2Row number-with-commas";
            }
        }

        protected void grdProductionMatrix_Line3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                TargetEff = DataBinder.Eval(e.Row.DataItem, "TargetEff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TargetEff"));
                ActualEff = DataBinder.Eval(e.Row.DataItem, "ActualEff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ActualEff"));
                Stitching = DataBinder.Eval(e.Row.DataItem, "Stitching") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Stitching"));
                ExtraHrs = DataBinder.Eval(e.Row.DataItem, "ExtraHours") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ExtraHours"));
                DayStitch = DataBinder.Eval(e.Row.DataItem, "DayStitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DayStitch"));
                LinePlanningDate = DataBinder.Eval(e.Row.DataItem, "LinePlanningDate") == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "LinePlanningDate"));
                ExFactoryDate = DataBinder.Eval(e.Row.DataItem, "ExFactory") == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "ExFactory"));

                Label lblTargetEff = (Label)e.Row.FindControl("lblTargetEff");
                Label lblActualEff = (Label)e.Row.FindControl("lblActualEff");
                DropDownList ddlHrsAdd = (DropDownList)e.Row.FindControl("ddlHrsAdd");
                Label lblDayStitch = (Label)e.Row.FindControl("lblDayStitch");
                Label lblTotalDayStitch = (Label)e.Row.FindControl("lblTotalDayStitch");

                if (lblTotalDayStitch.Text == "0")
                    lblTotalDayStitch.Text = "";

                lblTotalDayStitch.CssClass = "TotalBackStitch number-with-commas";

                if ((ExtraHrs == 0) || (ExtraHrs == 3.25) || (ExtraHrs == 8))
                {
                    ddlHrsAdd.SelectedValue = ExtraHrs.ToString();
                }

                if (Stitching == 1)
                {
                    e.Row.Cells[5].CssClass = "ItemBackStitch number-with-commas";
                    e.Row.Cells[6].CssClass = "ItemBackStitch number-with-commas";
                    ddlHrsAdd.Enabled = false;
                }
                if (LinePlanningDate == DateTime.Now.Date)
                    ddlHrsAdd.Enabled = true;

                if (LinePlanningDate < DateTime.Now.Date)
                    ddlHrsAdd.Enabled = false;

                if (TargetEff != 0)
                    lblTargetEff.Text = TargetEff.ToString() + "%";
                else
                    lblTargetEff.Text = "";

                if (ActualEff != 0)
                    lblActualEff.Text = ActualEff.ToString() + "%";
                else
                    lblActualEff.Text = "";
                

                if (DayStitch == 0)
                    lblDayStitch.Text = "";               

                if (LinePlanningDate > ExFactoryDate)
                    e.Row.CssClass = "rowcolor Line3Row number-with-commas";
            }
        }

        protected void grdProductionMatrix_Line4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                TargetEff = DataBinder.Eval(e.Row.DataItem, "TargetEff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TargetEff"));
                ActualEff = DataBinder.Eval(e.Row.DataItem, "ActualEff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ActualEff"));
                Stitching = DataBinder.Eval(e.Row.DataItem, "Stitching") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Stitching"));
                ExtraHrs = DataBinder.Eval(e.Row.DataItem, "ExtraHours") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ExtraHours"));
                DayStitch = DataBinder.Eval(e.Row.DataItem, "DayStitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DayStitch"));
                LinePlanningDate = DataBinder.Eval(e.Row.DataItem, "LinePlanningDate") == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "LinePlanningDate"));
                ExFactoryDate = DataBinder.Eval(e.Row.DataItem, "ExFactory") == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "ExFactory"));

                Label lblTargetEff = (Label)e.Row.FindControl("lblTargetEff");
                Label lblActualEff = (Label)e.Row.FindControl("lblActualEff");
                DropDownList ddlHrsAdd = (DropDownList)e.Row.FindControl("ddlHrsAdd");
                Label lblDayStitch = (Label)e.Row.FindControl("lblDayStitch");
                Label lblTotalDayStitch = (Label)e.Row.FindControl("lblTotalDayStitch");

                if (lblTotalDayStitch.Text == "0")
                    lblTotalDayStitch.Text = "";

                lblTotalDayStitch.CssClass = "TotalBackStitch number-with-commas";

                if ((ExtraHrs == 0) || (ExtraHrs == 3.25) || (ExtraHrs == 8))
                {
                    ddlHrsAdd.SelectedValue = ExtraHrs.ToString();
                }

                if (Stitching == 1)
                {
                    e.Row.Cells[5].CssClass = "ItemBackStitch number-with-commas";
                    e.Row.Cells[6].CssClass = "ItemBackStitch number-with-commas";
                    ddlHrsAdd.Enabled = false;
                }
                if (LinePlanningDate == DateTime.Now.Date)
                    ddlHrsAdd.Enabled = true;

                if (LinePlanningDate < DateTime.Now.Date)
                    ddlHrsAdd.Enabled = false;

                if (TargetEff != 0)
                    lblTargetEff.Text = TargetEff.ToString() + "%";
                else
                    lblTargetEff.Text = "";

                if (ActualEff != 0)
                    lblActualEff.Text = ActualEff.ToString() + "%";
                else
                    lblActualEff.Text = "";                

                if (DayStitch == 0)
                    lblDayStitch.Text = "";                

                if (LinePlanningDate > ExFactoryDate)
                    e.Row.CssClass = "rowcolor Line4Row number-with-commas";
            }
        }

        
    }
}