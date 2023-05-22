using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Text;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web.UserControls.Reports
{
    public partial class frmProductionMatrix : System.Web.UI.UserControl
    {
        string StyleCode;
        AdminController objadmin = new AdminController();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            bindHeader();
        }

        protected void bindHeader()
        {
           
            StyleCode = Session["StyleCode_for_production_matrix"].ToString();
            ds = objadmin.GetHeaderProductionMatrix(StyleCode);
            if (grdProductionMatrix.Columns.Count > 0)
            {
                grdProductionMatrix.Columns.Clear();
            }
            TemplateField StyleNo = new TemplateField();
            StyleNo.HeaderText = "Style No.";
            StyleNo.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "StyleNo", "StyleNo");
            grdProductionMatrix.Columns.Insert(0, StyleNo);
            StyleNo.HeaderStyle.Width = 160;
            StyleNo.HeaderStyle.CssClass = "align-center";


            TemplateField FitStatus = new TemplateField();
            FitStatus.HeaderText = "Fits Status";
            FitStatus.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "FitStatus", "FitStatus");
            grdProductionMatrix.Columns.Insert(1, FitStatus);
            FitStatus.HeaderStyle.Width = 120;
           


            int Count = Convert.ToInt32(ds.Tables[1].Rows.Count) - 1;
            if (Convert.ToInt32(ds.Tables[1].Rows.Count) > 0)
            {
                for (int i = 0; i <= Count; i++)
                {
                    TemplateField Exfactory = new TemplateField();
                    Exfactory.HeaderText = Convert.ToString(ds.Tables[1].Rows[i]["Exfactory"]);
                    Exfactory.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "Exfactory" + Convert.ToString(ds.Tables[1].Rows[i]["Exfactory"]), "Exfactory" + Convert.ToString(ds.Tables[1].Rows[i]["Exfactory"]));
                    // Exfactory.ItemStyle.CssClass = "accorforstyle14";
                    //CN.ItemStyle.Width = 80;
                    Exfactory.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    grdProductionMatrix.Columns.Insert(i + 2, Exfactory);
                    Exfactory.HeaderStyle.Width = 100;
                    Exfactory.HeaderStyle.CssClass = "align-center";
                }
            }

            

            grdProductionMatrix.DataSource = ds.Tables[0];
            grdProductionMatrix.DataBind();

        }

        protected void grdProductionMatrix_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //DataSet ds = new DataSet();
                //ds = objadmin.GetHeaderProductionMatrix(StyleCode);
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
               // e.Row.Cells[1].Font.Size = 7;

                //string FitStatus = drv.Row.ItemArray[3] == DBNull.Value ? "" : drv.Row.ItemArray[3].ToString();
                //Label LabelFitStatus = e.Row.FindControl("FitStatus") as Label;
                //LabelFitStatus.Text = FitStatus;
                //LabelFitStatus.ForeColor = System.Drawing.Color.Gray;
                //LabelFitStatus.Font.Size=11;
                //e.Row.Cells[1].CssClass = "align-left";
                //e.Row.Cells[1].Width = 250;

                int Count = Convert.ToInt32(ds.Tables[1].Rows.Count);
                string StyleNoNew = StyleNo;
                if (Convert.ToInt32(ds.Tables[1].Rows.Count) > 0)
                {
                    for (int iExfactory = 0; iExfactory < Count; iExfactory++)
                    {
                        string StyleexFactor = Convert.ToString(ds.Tables[1].Rows[iExfactory]["Exfactory"]);
                        HtmlTableCell exfactorynew = e.Row.FindControl("Exfactory" + Convert.ToString(ds.Tables[1].Rows[iExfactory]["Exfactory"])) as HtmlTableCell;
                        Label exfactory = e.Row.FindControl("Exfactory" + Convert.ToString(ds.Tables[1].Rows[iExfactory]["Exfactory"])) as Label;
                        if (StyleNoNew != "To Be Shipped (Fabric Inhouse)" && StyleNoNew != "Pending Cut" && StyleNoNew != "Pending Stitch" && StyleNoNew != "Pending Finish")
                        {
                            exfactory.Text = objadmin.Get_ProductionmatrixPopUp_Another(StyleNoNew, StyleexFactor);
                            if (StyleexFactor == "Total")
                            {
                                exfactory.Font.Bold = true;
                            }
                            else
                                exfactory.Font.Bold = false;   
                        }
                        else
                        {
                           // exfactory.Text = objadmin.Get_ProductionmatrixPopUp_BelowGrid(StyleNoNew, StyleexFactor, StyleCode);                            
                            exfactory.Font.Bold = true;
                            e.Row.CssClass = "TotalBackColor";
                           
                        }         
                    }
                }
                
            }
        }
    }
}