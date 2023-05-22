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
    public partial class ProductionMatrixPopup : System.Web.UI.Page
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

                return 10503;
            }
        }
        private int LineCount = 1;
        ProductionController objProductionController = new ProductionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetProductionMatrix();
            }
        }

        private void GetProductionMatrix()
        {
            DataSet dsProdMatrix;
            int i = 0;
            dsProdMatrix = objProductionController.GetProductionMatrix_ByLine(OrderDetailID, out i);
            LineCount = dsProdMatrix.Tables.Count;
            ViewState["dsProdMatrix"] = dsProdMatrix;
            BindProductionMatrix_Dynamic();
        }

        private void BindProductionMatrix_Dynamic()
        {
            grdProductionMatrix.Columns.Clear();            
            if (LineCount > 0)
            {
                for (int ival = 1; ival <= LineCount; ival++)
                {
                    TemplateField tfDayWorkingHrs = new TemplateField();
                    tfDayWorkingHrs.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "lblDayWorkingHrs" + ival, "lblDayWorkingHrs" + ival); 
                    tfDayWorkingHrs.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    tfDayWorkingHrs.HeaderText = "Act.Cal.Wrk.Hrs";
                    grdProductionMatrix.Columns.Add(tfDayWorkingHrs);

                    TemplateField tftxtHrsAdd = new TemplateField();
                    tftxtHrsAdd.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "txtHrsAdd" + ival, "txtHrsAdd" + ival);                    
                    tftxtHrsAdd.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    tftxtHrsAdd.HeaderText = "Add Hrs to Adjst";
                    grdProductionMatrix.Columns.Add(tftxtHrsAdd);

                    TemplateField tfProdDay = new TemplateField();
                    tfProdDay.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "lblProdDay" + ival, "lblProdDay" + ival);
                    tfProdDay.HeaderStyle.CssClass = "Fabtyle";
                    tfProdDay.ItemStyle.CssClass = "days-back";
                    tfProdDay.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    tfProdDay.HeaderText = "Days";
                    grdProductionMatrix.Columns.Add(tfProdDay);

                    TemplateField tfTargetEff = new TemplateField();
                    tfTargetEff.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "lblTargetEff" + ival, "lblTargetEff" + ival);                    
                    tfTargetEff.ItemStyle.CssClass = "blue";
                    tfTargetEff.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    tfTargetEff.HeaderText = "Target Eff.";
                    grdProductionMatrix.Columns.Add(tfTargetEff);

                    TemplateField tfActualEff = new TemplateField();
                    tfActualEff.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "lblActualEff" + ival, "lblActualEff" + ival);
                    tfActualEff.ItemStyle.CssClass = "blue";
                    tfActualEff.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    tfActualEff.HeaderText = "Actual Eff.";
                    grdProductionMatrix.Columns.Add(tfActualEff);

                    TemplateField tfDayStitch = new TemplateField();
                    tfDayStitch.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "lblDayStitch" + ival, "lblDayStitch" + ival);                   
                    tfDayStitch.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    tfDayStitch.HeaderText = "Day Stitch / Packed";
                    grdProductionMatrix.Columns.Add(tfDayStitch);

                    TemplateField tfTotalDayStitch = new TemplateField();
                    tfTotalDayStitch.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "lblTotalDayStitch" + ival, "lblTotalDayStitch" + ival);
                    tfTotalDayStitch.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    tfTotalDayStitch.HeaderText = "Total Stitch / Packed";
                    grdProductionMatrix.Columns.Add(tfTotalDayStitch);
                    
                }
            }
           
        }

        protected void grdProductionMatrix_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}