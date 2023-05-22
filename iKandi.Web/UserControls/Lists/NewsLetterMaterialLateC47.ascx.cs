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


namespace iKandi.Web.UserControls.Lists
{
    public partial class NewsLetterMaterialLateC47 : BaseUserControl
    {
        int UnitId;
        NewsLetter objNewsLetter = new NewsLetter();
        ProductionController objProductionController = new ProductionController();
        int LinePlanFrameId = -1;
        string StyleCode = string.Empty;

     
        protected void Page_Load(object sender, EventArgs e)
        {
            UnitId = 3;
            if (!IsPostBack)
            {
                GetMaterialLate();
            }
        }

        private void GetMaterialLate()
        {
            DataSet dsMaterialFrame = objProductionController.GetMaterialLate(UnitId, StyleCode, LinePlanFrameId, 1);
            gvMaterialShort.DataSource = dsMaterialFrame;
            gvMaterialShort.DataBind();
        }

       
        protected void gvMaterialShort_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblStyleCode = (Label)e.Row.FindControl("lblStyleCode");
                Label lblFrame = (Label)e.Row.FindControl("lblFrame");
                Label lblSerialNumber = (Label)e.Row.FindControl("lblSerialNumber");

                StyleCode = lblStyleCode.Text == "" ? string.Empty : lblStyleCode.Text;
                LinePlanFrameId = lblFrame.Text == "" ? -1 : Convert.ToInt32(lblFrame.Text);
              
                Repeater rptFabric = e.Row.FindControl("rptFabric") as Repeater;
                Repeater rptAccess = e.Row.FindControl("rptAccess") as Repeater;
                Repeater rptStatus = e.Row.FindControl("rptStatus") as Repeater;

                DataSet dsMaterialFrame = objProductionController.GetMaterialLate(UnitId, StyleCode, LinePlanFrameId, 2);
                DataTable dtSerialNumber = dsMaterialFrame.Tables[0];
                DataTable dtFabric = dsMaterialFrame.Tables[1];
                DataTable dtAccess = dsMaterialFrame.Tables[2];
                DataTable dtStatus = dsMaterialFrame.Tables[3];               

                if (dtSerialNumber.Rows.Count > 0)
                {
                    lblSerialNumber.Text = dtSerialNumber.Rows[0]["SerialNumber"].ToString().Replace(",","  ");
                }
                if (dtFabric.Rows.Count > 0)
                {
                    List<NewsLetter> NewsLetterCollection = new List<NewsLetter>();
                    for (int i = 0; i < dtFabric.Rows.Count; i++)
                    {
                        NewsLetter objNewsLetter = new NewsLetter();
                        objNewsLetter.OrderDetailId = dtFabric.Rows[i]["OrderDetailId"] == DBNull.Value ? 0 :Convert.ToInt64(dtFabric.Rows[i]["OrderDetailId"]);
                        objNewsLetter.ContractNumber = dtFabric.Rows[i]["ContractNumber"] == DBNull.Value ? "" : Convert.ToString(dtFabric.Rows[i]["ContractNumber"]);
                        objNewsLetter.SerialNumber = dtFabric.Rows[i]["SerialNumber"] == DBNull.Value ? "" : Convert.ToString(dtFabric.Rows[i]["SerialNumber"]);
                        objNewsLetter.FabricName = dtFabric.Rows[i]["FabricName"] == DBNull.Value ? "" : Convert.ToString(dtFabric.Rows[i]["FabricName"]);
                        objNewsLetter.FabricColor = dtFabric.Rows[i]["FabricColor"] == DBNull.Value ? "" : Convert.ToString(dtFabric.Rows[i]["FabricColor"]);
                        objNewsLetter.FabricShortDate = dtFabric.Rows[i]["FabricShortDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dtFabric.Rows[i]["FabricShortDate"]);
                        objNewsLetter.FabricStartEta = dtFabric.Rows[i]["FabricStartEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dtFabric.Rows[i]["FabricStartEta"]);
                        objNewsLetter.FabricEndEta = dtFabric.Rows[i]["FabricEndEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dtFabric.Rows[i]["FabricEndEta"]);   

                        NewsLetterCollection.Add(objNewsLetter);                      

                    }
                    rptFabric.DataSource = NewsLetterCollection;
                    rptFabric.DataBind();
                }
                if (dtAccess.Rows.Count > 0)
                {
                    List<NewsLetter> NewsLetterCollection = new List<NewsLetter>();
                    for (int i = 0; i < dtAccess.Rows.Count; i++)
                    {
                        NewsLetter objNewsLetter = new NewsLetter();
                        objNewsLetter.OrderDetailId = dtAccess.Rows[i]["OrderDetailId"] == DBNull.Value ? 0 : Convert.ToInt64(dtAccess.Rows[i]["OrderDetailId"]);
                        objNewsLetter.ContractNumber = dtAccess.Rows[i]["ContractNumber"] == DBNull.Value ? "" : Convert.ToString(dtAccess.Rows[i]["ContractNumber"]);
                        objNewsLetter.SerialNumber = dtAccess.Rows[i]["SerialNumber"] == DBNull.Value ? "" : Convert.ToString(dtAccess.Rows[i]["SerialNumber"]);
                        objNewsLetter.AccessName = dtAccess.Rows[i]["Accessories"] == DBNull.Value ? "" : Convert.ToString(dtAccess.Rows[i]["Accessories"]);
                        objNewsLetter.AccessShortDate = dtAccess.Rows[i]["AccessoryShortDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dtAccess.Rows[i]["AccessoryShortDate"]);
                        objNewsLetter.AccessEta = dtAccess.Rows[i]["AccessoriesEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dtAccess.Rows[i]["AccessoriesEta"]);
                        
                        NewsLetterCollection.Add(objNewsLetter);                        
                    }

                    rptAccess.DataSource = NewsLetterCollection;
                    rptAccess.DataBind();
                }

                if (dtStatus.Rows.Count > 0)
                {
                    List<NewsLetter> NewsLetterCollection = new List<NewsLetter>();
                    for (int i = 0; i < dtStatus.Rows.Count; i++)
                    {
                        NewsLetter objNewsLetter = new NewsLetter();
                        objNewsLetter.status = dtStatus.Rows[i]["Status"] == DBNull.Value ? "" : Convert.ToString(dtStatus.Rows[i]["Status"]);
                        objNewsLetter.StatusEta = dtStatus.Rows[i]["StatusEta"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dtStatus.Rows[i]["StatusEta"]);
                        objNewsLetter.CWIP = dtStatus.Rows[i]["WIPDetail"] == DBNull.Value ? "" : Convert.ToString(dtStatus.Rows[i]["WIPDetail"]);
                        objNewsLetter.SerialNumber = dtStatus.Rows[i]["SerialNumber"] == DBNull.Value ? "" : Convert.ToString(dtStatus.Rows[i]["SerialNumber"]);
                        NewsLetterCollection.Add(objNewsLetter);
                    }

                    rptStatus.DataSource = NewsLetterCollection;
                    rptStatus.DataBind();
                }

            }
        }

        protected void rptFabric_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Add By Prabhaker 01-feb-2018

                Label lblFabric = e.Item.FindControl("lblFabric") as Label;
                Label lblFabColor = e.Item.FindControl("lblFabColor") as Label;
                Label lblFabShortDate = e.Item.FindControl("lblFabShortDate") as Label;
                Label lblFabStartEta = e.Item.FindControl("lblFabStartEta") as Label;
                Label lblFabEndEta = e.Item.FindControl("lblFabEndEta") as Label;
                Label lblContractNo = e.Item.FindControl("lblContractNo") as Label;
                HiddenField hdnFabricShortDate = e.Item.FindControl("hdnFabricShortDate") as HiddenField;

                DateTime CurrentDate = DateTime.Today;
                TimeSpan ts = Convert.ToDateTime(hdnFabricShortDate.Value) - CurrentDate;
                lblContractNo.Text = lblContractNo.Text.Replace('/', ' ');
                // Difference in days.
                int differenceInDays = ts.Days; // lblContractNo This is in int
                if (differenceInDays <= 1)
                {                  
                    lblFabShortDate.CssClass = "oneday";
                    lblFabStartEta.CssClass = "oneday";
                    lblFabEndEta.CssClass = "oneday";

                }
                if (differenceInDays > 1 && differenceInDays <= 2)
                {                  
                    lblFabShortDate.CssClass = "twoday";
                    lblFabStartEta.CssClass = "twoday";
                    lblFabEndEta.CssClass = "twoday";
                }
                if (differenceInDays >= 3)
                {                  
                    lblFabShortDate.CssClass = "threeday";
                    lblFabStartEta.CssClass = "threeday";
                    lblFabEndEta.CssClass = "threeday";
                }
                //End Of Code

            }
        }

        protected void rptAcc_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Add By Prabhaker 01-feb-2018

                Label lblAccQty = e.Item.FindControl("lblAccQty") as Label;
                Label lblAccShortDate = e.Item.FindControl("lblAccShortDate") as Label;
                Label lblAccEta = e.Item.FindControl("lblAccEta") as Label;
               Label lblAccContractNo = e.Item.FindControl("lblAccContractNo") as Label;
               lblAccContractNo.Text = lblAccContractNo.Text.Replace('/', ' ');

               HiddenField hdnAccShortDate = e.Item.FindControl("hdnAccShortDate") as HiddenField;

                DateTime CurrentDate = DateTime.Today;
                TimeSpan ts = Convert.ToDateTime(hdnAccShortDate.Value) - CurrentDate;

                // Difference in days.
                int differenceInDays = ts.Days; // This is in int
                if (differenceInDays <= 1)
                {
                   // lblAccQty.CssClass = "oneday";
                    lblAccShortDate.CssClass = "oneday";
                    lblAccEta.CssClass = "oneday";
                   

                }
                if (differenceInDays > 1 && differenceInDays <= 2)
                {
                   // lblAccQty.CssClass = "twoday";
                    lblAccShortDate.CssClass = "twoday";
                    lblAccEta.CssClass = "twoday";
                   
                }
                if (differenceInDays >= 3)
                {
                  //  lblAccQty.CssClass = "threeday";
                    lblAccShortDate.CssClass = "threeday";
                    lblAccEta.CssClass = "threeday";
                  
                }
                //End Of Code

            }
        }

        protected void rptStatus_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblStausEta = (Label)e.Item.FindControl("lblStausEta");

                DateTime dtStatusEta = Convert.ToDateTime(DataBinder.Eval(e.Item.DataItem, "StatusEta"));
                string Status = DataBinder.Eval(e.Item.DataItem, "status").ToString();
                string WIPDetail = DataBinder.Eval(e.Item.DataItem, "CWIP").ToString();

                if (Status == "WIP Cutting")
                    lblStausEta.Text = WIPDetail;
                else
                    lblStausEta.Text = dtStatusEta == DateTime.MinValue ? "" : dtStatusEta.ToString("dd MMM (ddd)");
            }
        }

       
    }
}