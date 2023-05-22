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

namespace iKandi.Web.Internal.Production
{
    public partial class ProductionPlanning : System.Web.UI.Page
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
        string strex = string.Empty;        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["StyleCode"] != null)
            {
                StyleCode = Request.QueryString["StyleCode"].ToString();
                Session["StyleCode_for_production_matrix"] = StyleCode;
                lblStylecode.Text = "(" + StyleCode + ")";
            }
            //System.Threading.Thread.Sleep(1000);
            if (!IsPostBack)
            {
                BindControl();
            }
            else
            {
                if (ViewState["dsStyle"] != null)
                {
                    BindDataAfterPostBack();
                }
            }
        }

        public void BindControl()
        {
            DataSet dsStyle = objProductionController.GetAllQuantity_ByStyleCode(StyleCode, OrderDetailID);
            ViewState["dsStyle"] = dsStyle;
            if (dsStyle.Tables.Count > 0)
            {
                DataTable dtShipped = dsStyle.Tables[0];
                ViewState["dtShipped"] = dtShipped;
                if (dtShipped.Rows.Count > 0)
                {
                    lblqtyorder.Text = dtShipped.Rows[0]["TatalQty"].ToString() == "0" ? "" : String.Format("{0:#,##0}", Convert.ToInt32(dtShipped.Rows[0]["TatalQty"].ToString()));
                    if (dtShipped.Rows[0]["shippedqty"].ToString() != "")
                        lblshipedqty.Text = dtShipped.Rows[0]["shippedqty"].ToString() == "0" ? "" : String.Format("{0:#,##0}", Convert.ToInt32(dtShipped.Rows[0]["shippedqty"].ToString()));
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
                        txtLineFrame.Text = ddlLinePlanFrame.SelectedValue;
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
                lblMessage.Text = "Line not planned yet!";
            }
        }

        private void BindDataAfterPostBack()
        {
            DataSet dsStyle = (DataSet)ViewState["dsStyle"];
            if (dsStyle.Tables.Count > 0)
            {

                DataTable dtShipped = (DataTable)ViewState["dtShipped"];
                if (dtShipped.Rows.Count > 0)
                {
                    lblqtyorder.Text = dtShipped.Rows[0]["TatalQty"].ToString() == "0" ? "" : String.Format("{0:#,##0}", Convert.ToInt32(dtShipped.Rows[0]["TatalQty"].ToString()));
                    lblshipedqty.Text = dtShipped.Rows[0]["shippedqty"].ToString() == "0" ? "" : String.Format("{0:#,##0}", Convert.ToInt32(dtShipped.Rows[0]["shippedqty"].ToString()));
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
                        txtLineFrame.Text = ddlLinePlanFrame.SelectedValue;
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
                lblMessage.Text = "Line not planned yet!";
            }
            //if (dsStyle.Tables.Count > 1)
            //{
            //    DataTable dtPending = (DataTable)ViewState["dtPending"];           

            //    if (dtPending.Rows.Count > 0)
            //    {
            //        //gvPending.DataSource = dtPending;
            //       // gvPending.DataBind();

            //        HidePendingUnUsedCol();

            //    }
            //}
            //if (dsStyle.Tables.Count > 2)
            //{
            //    if (ViewState["dtLinePlanFrame"] != null)
            //    {
            //        DataTable dtLinePlanFrame = (DataTable)ViewState["dtLinePlanFrame"];
            //        if (dtLinePlanFrame.Rows.Count > 1)
            //        {
            //            hdnFrameNo.Value = ddlLinePlanFrame.SelectedValue;
            //        }
            //    }
            //}
        }

        //private void AddTotalToDataTable()
        //{
        //    DataTable dtPending = (DataTable)ViewState["dtPending"];
        //    dtPending.Columns.Add("Total", typeof(System.String));
        //    int ColCount = dtPending.Columns.Count;
        //    int PendingCutQty = 0, TotalFabricInhouse, TotalToBeShipped, TotalPendingCutQty, TotalToBeStitch, TotalHrs, TotalToBeFinish, TotalFinishHrs, FabricInHouseCount;
        //    foreach (DataRow dr in dtPending.Rows)
        //    {
               
        //        string Details = dr["Detail"].ToString();

        //        TotalFabricInhouse = 0;
        //        TotalToBeShipped = 0;
        //        TotalPendingCutQty = 0;                
        //        TotalToBeStitch = 0;
        //        TotalHrs = 0;               
        //        TotalToBeFinish = 0;
        //        TotalFinishHrs = 0;
        //        FabricInHouseCount = 0;

        //        for (int i = 4; i < ColCount; i++)
        //        {
        //            if (Details == "To Be Shipped (Fabric Inhouse)")
        //            {
        //                if (dr[dtPending.Columns[i].ColumnName].ToString() != "")
        //                {
        //                    string[] strQty = dr[dtPending.Columns[i].ColumnName].ToString().Split('(');

        //                    int ToBeShipped = Convert.ToInt32(strQty[0]);
        //                    TotalToBeShipped = TotalToBeShipped + ToBeShipped;
                           
        //                    if (strQty.Length > 1)
        //                    {                             
        //                        int FabricInhouse = Convert.ToInt32(strQty[1].TrimEnd(')'));

        //                        if (FabricInhouse > 0)
        //                            FabricInHouseCount = FabricInHouseCount + 1;

        //                        TotalFabricInhouse = TotalFabricInhouse + FabricInhouse;
        //                    }
        //                }

        //                if (i == ColCount - 1)
        //                {
        //                    if(FabricInHouseCount > 0)
        //                        TotalFabricInhouse = TotalFabricInhouse / FabricInHouseCount;

        //                    dr["Total"] = TotalToBeShipped.ToString() + " (" + TotalFabricInhouse + ")";
        //                    dtPending.AcceptChanges();
        //                }

        //            }
        //            else if (Details == "Pending Cut")
        //            {
        //                if (dr[dtPending.Columns[i].ColumnName].ToString() != "")
        //                {
        //                    PendingCutQty = dr[dtPending.Columns[i].ColumnName].ToString() == "" ? 0 : Convert.ToInt32(dr[dtPending.Columns[i].ColumnName].ToString());
                            
        //                    TotalPendingCutQty = TotalPendingCutQty + PendingCutQty;
        //                }
        //                if (i == ColCount - 1)
        //                {
        //                    dr["Total"] = TotalPendingCutQty.ToString();
        //                    dtPending.AcceptChanges();
        //                }
        //            }
        //            else if (Details == "Pending Stitch")
        //            {
        //                if (dr[dtPending.Columns[i].ColumnName].ToString() != "")
        //                {
        //                    string[] strQty = dr[dtPending.Columns[i].ColumnName].ToString().Split('(');

        //                    int ToBeStitch = Convert.ToInt32(strQty[0]);
        //                    TotalToBeStitch = TotalToBeStitch + ToBeStitch;
                           
        //                    if (strQty.Length > 1)
        //                    {                
        //                        int Hrs = Convert.ToInt32(strQty[1].TrimEnd(')'));
        //                        TotalHrs = TotalHrs + Hrs;
        //                    }
        //                }

        //                if (i == ColCount - 1)
        //                {
        //                    dr["Total"] = TotalToBeStitch.ToString() + " (" + TotalHrs + ")";
        //                    dtPending.AcceptChanges();
        //                }

        //            }
        //            else if (Details == "Pending Finish")
        //            {
        //                if (dr[dtPending.Columns[i].ColumnName].ToString() != "")
        //                {
        //                    string[] strQty = dr[dtPending.Columns[i].ColumnName].ToString().Split('(');

        //                    int ToBeFinish = Convert.ToInt32(strQty[0]);
        //                    TotalToBeFinish = TotalToBeFinish + ToBeFinish;

        //                    if (strQty.Length > 1)
        //                    {
        //                        int Hrs = Convert.ToInt32(strQty[1].TrimEnd(')'));
        //                        TotalFinishHrs = TotalFinishHrs + Hrs;
        //                    }
        //                }

        //                if (i == ColCount - 1)
        //                {
        //                    dr["Total"] = TotalToBeFinish.ToString() + " (" + TotalFinishHrs + ")";
        //                    dtPending.AcceptChanges();
        //                }
        //            }                    
        //        }              
        //    }

        //    //ViewState["dtPending"] = dtPending;

        //    //if (dtPending.Rows.Count > 0)
        //    //{
        //    //   // gvPending.DataSource = dtPending;
        //    //   // gvPending.DataBind();

        //    //    HidePendingUnUsedCol();
        //    //}
        //}

        //private void HidePendingUnUsedCol()
        //{
        //    DataTable dtPending = (DataTable)ViewState["dtPending"];
        //    int ColCount = dtPending.Columns.Count;

        //    for (int i = ColCount - 1; i < 15; i++)
        //    {
        //        gvPending.Columns[i-1].Visible = false;
        //    }
        //    if (!dtPending.Columns.Contains("FutureQty"))
        //    {
        //        gvPending.Columns[12].Visible = false;
        //    }
        //}

        //protected void gvPending_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    DataTable dtPending = (DataTable)ViewState["dtPending"];
        //    int ColCount = dtPending.Columns.Count;
        //    int RowIndex = 0;
        //    string strHeaderText = "";
        //    Label lblFitsStatus = (Label)e.Row.FindControl("lblFitsStatus");
        //    if (e.Row.RowType == DataControlRowType.Header)
        //    {
        //        for (int i = 0; i < ColCount; i++)
        //        {
        //            if ((i > 3) && (i < ColCount - 1) && (i != 14))
        //            {
        //                string ExFactory = dtPending.Columns[i].ColumnName;
        //                ExFactory = ExFactory.Substring(2, 8);
        //                string year = ExFactory.Substring(0, 4);
        //                string Month = ExFactory.Substring(4, 2);
        //                string Days = ExFactory.Substring(6, 2);
        //                strex = Month + "-" + Days + "-" + year;

        //                DateTime strexDT = Convert.ToDateTime(strex);
        //                e.Row.Cells[i - 2].Text = strexDT.ToString("dd MMM");                       
        //                e.Row.Cells[i - 2].Font.Bold = true;
        //            }
        //            if (i == 14)
        //            {
        //                e.Row.Cells[i - 2].Text = "Remaining";                        
        //            }
        //            if (i == ColCount - 1)
        //            {
        //                e.Row.Cells[i - 2].Text = "Total";                        
        //                e.Row.Cells[i - 2].Font.Bold = true;                        
        //            }
        //        }
        //    }
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        Label lblStyleNo = (Label)e.Row.FindControl("lblStyleNo");
        //        //Label lblDetail = (Label)e.Row.FindControl("lblDetail");
        //        HiddenField hdnDetail = (HiddenField)e.Row.FindControl("hdnDetail");              
        //        if (lblStyleNo.Text == "Total")
        //        {
        //            lblStyleNo.Font.Size = 10;                   
        //            e.Row.CssClass = "TotalBackColor";
        //            e.Row.Cells[1].Text = hdnDetail.Value;
        //        }
                          
        //        RowIndex = e.Row.RowIndex;
        //        for (int i = 0; i < ColCount; i++)
        //        {
        //            if (i > 3)
        //            {
        //                if (hdnDetail.Value == "To Be Shipped (Fabric Inhouse)")
        //                {
        //                    string[] strDetail = hdnDetail.Value.Split('(');
        //                    string OrderDetail = strDetail[0].ToString();
        //                    string ShipDetail = "(" + strDetail[1].ToString();
                            
        //                        //lblDetail.Text = "<span style='color:#696969;'>" + OrderDetail + "</span>" + "<span style='color:Black;'>" + ShipDetail + "</span>";

        //                    if (dtPending.Rows[RowIndex][dtPending.Columns[i].ColumnName].ToString() != "")
        //                    {
        //                        string[] strQty = dtPending.Rows[RowIndex][dtPending.Columns[i].ColumnName].ToString().Split('(');

        //                        int ToBeShipped = Convert.ToInt32(strQty[0]);
        //                        int FabricInHouse = 0;
        //                        if (strQty.Length > 1)
        //                        {
        //                            FabricInHouse = Convert.ToInt32(strQty[1].TrimEnd(')'));
        //                        }
        //                        string strBeShipped = "";

        //                        if (ToBeShipped > 0)
        //                            strBeShipped = ToBeShipped >= 1000 ? Math.Round(Convert.ToDecimal(ToBeShipped) / 1000, 1).ToString() + " k" : ToBeShipped.ToString();

        //                        string strFabricInHouse = FabricInHouse == 0 ? "" : " (" + FabricInHouse.ToString() + " %)";
                                
        //                        strHeaderText = gvPending.HeaderRow.Cells[i - 2].Text;

        //                        if (strHeaderText == "Total")
        //                            e.Row.Cells[i - 2].Text = "<span title='" + "To Be Shipped : " + ToBeShipped.ToString() + "' style='color:Black; font-weight:bold;text-transform:lowercase !important'>" + strBeShipped + "</span>" + "<span title='" + "Fabric Inhouse : " + FabricInHouse.ToString() + "%' style='color:#696969; font-weight:bold;'>" + strFabricInHouse + "</span>";
        //                        else
        //                            e.Row.Cells[i - 2].Text = "<span title='" + "To Be Shipped : " + ToBeShipped.ToString() + "' style='color:Black;text-transform:lowercase !important'>" + strBeShipped + "</span>" + "<span title='" + "Fabric Inhouse : " + FabricInHouse.ToString() + "%' style='color:#696969;'>" + strFabricInHouse + "</span>";
                                
        //                    }
                            
        //                }
        //                else if (hdnDetail.Value == "Pending Stitch")
        //                {
        //                    //------------Commented by Prabhaker for (hrs)-------------------//
        //                   // string[] strDetail = hdnDetail.Value.Split('(');
        //                   // string StitchDetail = strDetail[0].ToString();
        //                   // string HrsDetail = "(" + strDetail[1].ToString();
        //                    //------------Commented by Prabhaker for (hrs)-------------------//
        //                    //lblDetail.Text = "<span style='color:#696969;'>" + StitchDetail + "</span>" + "<span style='color:Black;'>" + HrsDetail + "</span>";

        //                    if (dtPending.Rows[RowIndex][dtPending.Columns[i].ColumnName].ToString() != "")
        //                    {
        //                        string[] strQty = dtPending.Rows[RowIndex][dtPending.Columns[i].ColumnName].ToString().Split('(');
        //                        int iQuantity = Convert.ToInt32(strQty[0]);
        //                        string Hrs = "";
        //                        string strQuantity = "";
        //                        if (strQty.Length > 1)
        //                        {
        //                            string[] strHrs = strQty[1].Split(')');
        //                            Hrs = strHrs[0] == "0" ? "" : " (" + strHrs[0].ToString() + ")";
        //                        }
        //                        if (iQuantity > 0)
        //                        {
        //                            strQuantity = iQuantity >= 1000 ? Math.Round(Convert.ToDecimal(iQuantity) / 1000, 1).ToString() + " k" : iQuantity.ToString();
        //                            strQuantity = strQuantity.Replace(".0 k", " k");
        //                        }
        //                        strHeaderText = gvPending.HeaderRow.Cells[i - 2].Text;

        //                        if (strHeaderText == "Total")
        //                            e.Row.Cells[i - 2].Text = "<span title='" + "Pending Stitch : " + iQuantity.ToString() + "' style='color:Black; font-weight:bold;text-transform:lowercase !important'>" + strQuantity + "</span>" + "<span title='Hrs: " + Hrs + "' style='color:#696969; font-weight:bold;'>" + Hrs + "</span>";
        //                        else
        //                            e.Row.Cells[i - 2].Text = "<span title='" + "Pending Stitch : " + iQuantity.ToString() + "' style='color:Black;text-transform:lowercase !important'>" + strQuantity + "</span>" + "<span title='Hrs: " + Hrs + "' style='color:#696969;'>" + Hrs + "</span>";
        //                    }
        //                }
        //                else if (hdnDetail.Value == "Pending Finish")
        //                {
        //                   //------------Commented by Prabhaker for (hrs)-------------------//
        //                   // string[] strDetail = hdnDetail.Value.Split('(');
        //                   // string FinishDetail = strDetail[0].ToString();
        //                   // string HrsDetail = "(" + strDetail[1].ToString();
        //                    //------------Commented by Prabhaker for (hrs)-------------------//
        //                    //lblDetail.Text = "<span style='color:#696969;'>" + FinishDetail + "</span>" + "<span style='color:Black;'>" + HrsDetail + "</span>";

        //                    if (dtPending.Rows[RowIndex][dtPending.Columns[i].ColumnName].ToString() != "")
        //                    {

        //                        string[] strQty = dtPending.Rows[RowIndex][dtPending.Columns[i].ColumnName].ToString().Split('(');

        //                        int iQuantity = Convert.ToInt32(strQty[0]);
        //                        string Hrs = "";
        //                        string strQuantity = "";
        //                        if (strQty.Length > 1)
        //                        {                                    
        //                            string[] strHrs = strQty[1].Split(')');
        //                            Hrs = strHrs[0] == "0" ? "" : " (" + strHrs[0].ToString() + ")";
        //                        }
        //                        //string strQuantity = Math.Round(Convert.ToDecimal(iQuantity) / 1000, 1).ToString() == "0" ? "" : Math.Round(Convert.ToDecimal(iQuantity) / 1000, 1).ToString() + " k"; ;
        //                        if (iQuantity > 0)
        //                        {
        //                            strQuantity = iQuantity >= 1000 ? Math.Round(Convert.ToDecimal(iQuantity) / 1000, 1).ToString() + " k" : iQuantity.ToString();
        //                            strQuantity = strQuantity.Replace(".0 k", " k");
        //                        }
        //                        strHeaderText = gvPending.HeaderRow.Cells[i - 2].Text;

        //                        if (strHeaderText == "Total")
        //                            e.Row.Cells[i - 2].Text = "<span title='" + "Pending Finish : " + iQuantity.ToString() + "' style='color:Black; font-weight:bold;text-transform:lowercase !important'>" + strQuantity + "</span>" + "<span title='Hrs: " + Hrs + "' style='color:#696969; font-weight:bold;'>" + Hrs + "</span>";
        //                        else
        //                            e.Row.Cells[i - 2].Text = "<span title='" + "Pending Finish : " + iQuantity.ToString() + "' style='color:Black;text-transform:lowercase !important'>" + strQuantity + "</span>" + "<span title='Hrs: " + Hrs + "' style='color:#696969;'>" + Hrs + "</span>";
                                                                
        //                    }
        //                }
        //                else if (hdnDetail.Value == "Pending Cut") 
        //                {                            
        //                        //lblDetail.Text = "<span style='color:Black;'>" + hdnDetail.Value + "</span>";

        //                    if (dtPending.Rows[RowIndex][dtPending.Columns[i].ColumnName].ToString() != "")
        //                    {
        //                        int iQuantity = Convert.ToInt32(dtPending.Rows[RowIndex][dtPending.Columns[i].ColumnName]);
        //                        string strQuantity = "";// Math.Round(Convert.ToDecimal(iQuantity) / 1000, 1).ToString() == "0" ? "" : Math.Round(Convert.ToDecimal(iQuantity) / 1000, 1).ToString() + " k"; ;
        //                        if (iQuantity > 0)
        //                        {
        //                            strQuantity = iQuantity >= 1000 ? Math.Round(Convert.ToDecimal(iQuantity) / 1000, 1).ToString() + " k" : iQuantity.ToString();
        //                          strQuantity= strQuantity.Replace(".0 k", " k");
        //                        }
        //                        strHeaderText = gvPending.HeaderRow.Cells[i - 2].Text;

        //                        if (strHeaderText == "Total")
        //                            e.Row.Cells[i - 2].Text = "<span title='" + "Pending Cut : " + iQuantity.ToString() + "' style='color:Black;text-transform:lowercase !important; font-weight:bold;'>" + strQuantity + "</span>";
        //                        else
        //                            e.Row.Cells[i - 2].Text = "<span title='" + "Pending Cut : " + iQuantity.ToString() + "' style='color:Black;text-transform:lowercase !important'>" + strQuantity + "</span>";

        //                    }
        //                }
                       
        //            }
        //        }
                
        //    }           

        //}

        //protected void gvPending_DataBound(object sender, EventArgs e)
        //{
        //    for (int i = gvPending.Rows.Count - 1; i > 0; i--)
        //    {
        //        GridViewRow row = gvPending.Rows[i];
        //        GridViewRow previousRow = gvPending.Rows[i - 1];

        //        Label lblStyleNo = (Label)row.Cells[0].FindControl("lblStyleNo");
        //        Label lblPreviousStyleNo = (Label)previousRow.Cells[0].FindControl("lblStyleNo");

        //        if (lblStyleNo.Text == lblPreviousStyleNo.Text)
        //        {
        //            if (previousRow.Cells[0].RowSpan == 0)
        //            {
        //                if (row.Cells[0].RowSpan == 0)
        //                {
        //                    previousRow.Cells[0].RowSpan += 2;
        //                }
        //                else
        //                {
        //                    previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
        //                }
        //                row.Cells[0].Visible = false;
        //            }
        //        }
        //    }
        //}

        protected void btnShowMatrix_Click(object sender, EventArgs e)
        {           
            
            btnShowMatrix.Visible = false;
            btnHideMatrix.Visible = true;
            if (ViewState["dtLinePlanFrame"] != null)
            {
                DataTable dtLinePlanFrame = (DataTable)ViewState["dtLinePlanFrame"];
                if (dtLinePlanFrame.Rows.Count > 1)
                {
                    btnShowMatrix.Visible = true;
                    btnHideMatrix.Visible = false;
                }
            }
            try
            {
                UserControl ProductionPlanningMatrix = LoadControl("~/UserControls/Forms/ProductionPlanningMatrix.ascx") as UserControl;
                MatrixPlaceHolder.Controls.Add(ProductionPlanningMatrix);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                btnShowMatrix.Visible = true;
                btnHideMatrix.Visible = false;
            }            
            
        }

        protected void btnHideMatrix_Click(object sender, EventArgs e)
        {
            MatrixPlaceHolder.Controls.Clear();
            btnShowMatrix.Visible = true;
            btnHideMatrix.Visible = false;
        }
    }
}