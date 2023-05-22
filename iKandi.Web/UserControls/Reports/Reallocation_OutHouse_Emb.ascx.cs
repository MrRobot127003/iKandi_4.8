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
    public partial class Reallocation_OutHouse_Emb : System.Web.UI.UserControl
    {
        int total = 0;
        int Foo_rcvdVaTdyQty = 0;
        QualityController objQuality = new QualityController();
        DataTable dtFooter=new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindOutHouseEmb();
               
            }
            
        }
        protected void BindOutHouseEmb()
        {
            DataSet Reallocation_OutHouse_Emb = this.objQuality.GetReallocation_OutHouse_Emb("Reallocation_OutHouse_Emb");            
            DataTable dtReallocation_OutHouse_Emb = Reallocation_OutHouse_Emb.Tables[0];
            dtFooter =Reallocation_OutHouse_Emb.Tables[1];
            frmReallocation_OutHouse_Emb.DataSource = dtReallocation_OutHouse_Emb;
            frmReallocation_OutHouse_Emb.DataBind();            
        }

        protected void frmReallocation_OutHouse_Emb_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblExDate = (Label)e.Row.FindControl("lblExDate");
                HiddenField hdnBgColor = (HiddenField)e.Row.FindControl("hdnBgColor");
                 TableCell rowCell = (TableCell)lblExDate.Parent;
                 HiddenField hdnImgStyle = (HiddenField)e.Row.FindControl("hdnImgStyle");
                 HtmlImage imgStyle = (HtmlImage)e.Row.FindControl("imgStyle");
                 
                
                // HtmlAnchor imgStyleHyper = (HtmlAnchor)e.Row.FindControl("imgStyleHyper");
                 imgStyle.Src = "/uploads/style/thumb-" + hdnImgStyle.Value;
               //  imgStyleHyper.Title = "/uploads/style/thumb-" + hdnImgStyle.Value;
                 if (hdnBgColor.Value != "1")
                 {
                     rowCell.Style["background"] = "green";
                 }
                 else
                 {
                     rowCell.Style["background"] = "red";
                 }
                 string valueAdd = DataBinder.Eval(e.Row.DataItem, "ValueAddedQty").ToString();
                 if (valueAdd == "")
                 {
                     valueAdd = "0";
                 }
                 else
                 {
                     valueAdd = valueAdd.ToString();
                 }
                 total = total + Convert.ToInt32(valueAdd);

                 string rcvdVaTdyQty = DataBinder.Eval(e.Row.DataItem, "PerdayValueAddedQty").ToString();

                 if (rcvdVaTdyQty == "")
                 {
                     rcvdVaTdyQty = "0";
                 }
                 else
                 {
                     rcvdVaTdyQty = rcvdVaTdyQty.ToString();
                 }
                 Foo_rcvdVaTdyQty = Foo_rcvdVaTdyQty + Convert.ToInt32(rcvdVaTdyQty);
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblFoo_ValueAddedQty = (Label)e.Row.FindControl("lblFoo_ValueAddedQty");
                Label lblFoo_Pcsday = (Label)e.Row.FindControl("lblFoo_Pcsday");
                Label lblFoo_POQty = (Label)e.Row.FindControl("lblFoo_POQty");
                Label lblFoo_rcvdVaTdyQty = (Label)e.Row.FindControl("lblFoo_rcvdVaTdyQty");
                e.Row.Cells[0].ColumnSpan = 7;
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
               // e.Row.Cells[7].Visible = false;

               // e.Row.Cells[10].ColumnSpan = 2;
               // e.Row.Cells[11].Visible = false;
               // e.Row.Cells[12].Visible = false;
                lblFoo_ValueAddedQty.Text = total.ToString() == "0" ? "" : String.Format("{0:#,##0}", Convert.ToInt32(total.ToString()));
                lblFoo_rcvdVaTdyQty.Text = Foo_rcvdVaTdyQty.ToString() == "0" ? "" : String.Format("{0:#,##0}", Convert.ToInt32(Foo_rcvdVaTdyQty.ToString()));
                if (dtFooter.Rows.Count > 0)
                {
                    lblFoo_Pcsday.Text = dtFooter.Rows[0]["PcsPerday"].ToString() == "0" ? "" :String.Format("{0:#,##0}", Convert.ToInt32(dtFooter.Rows[0]["PcsPerday"].ToString()));
                    lblFoo_POQty.Text =  dtFooter.Rows[0]["Order_Qty"].ToString() == "0" ? "" :String.Format("{0:#,##0}", Convert.ToInt32(dtFooter.Rows[0]["Order_Qty"].ToString()));                   
                }
            }
        }
    }
}