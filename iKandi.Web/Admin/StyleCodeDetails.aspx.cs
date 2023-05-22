using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using iKandi.BLL;
using iKandi.Web.Components;
using iKandi.Common;
using System.IO;
using System.Text;
using System.Globalization;

namespace iKandi.Web.Admin
{
    public partial class StyleCodeDetails : System.Web.UI.Page
    {
        public string StyleCode
        {
            get;
            set;
        }
        AdminController objAdmin = new AdminController();
        string strex = string.Empty;
        
        int TotalQty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["StyleCode"] != null)
            {
                StyleCode = Request.QueryString["StyleCode"].ToString();
                stylecode.Text = Request.QueryString["StyleCode"].ToString();
                stylecode.Text = "(" + stylecode.Text + ")";
            }
            if (!IsPostBack)
            {
                BindControl();              
            }
        }
        public void BindControl()
        {
            DataSet dsStyle = objAdmin.GetPendingQty_ByStyleCode(StyleCode);
            if (dsStyle.Tables.Count > 0)
            {

                DataTable dtShipped = dsStyle.Tables[0];
                if (dtShipped.Rows.Count > 0)
                {
                    lblqtyorder.Text = dtShipped.Rows[0]["TatalQty"].ToString() == "0" ? "" : String.Format("{0:#,##0}", Convert.ToInt32(dtShipped.Rows[0]["TatalQty"].ToString()));
                    lblshipedqty.Text = dtShipped.Rows[0]["shippedqty"].ToString() == "0" ? "" : String.Format("{0:#,##0}", Convert.ToInt32(dtShipped.Rows[0]["shippedqty"].ToString()));
                }
            }
            if (dsStyle.Tables.Count > 1)
            {
                DataTable dtPending = dsStyle.Tables[1];
                ViewState["dtPending"] = dtPending;
                if (dtPending.Rows.Count > 0)
                {
                    gvPending.DataSource = dtPending;
                    gvPending.DataBind();

                    HidePendingUnUsedCol();
                }
            }
        }

        private void HidePendingUnUsedCol()
        {
            DataTable dtPending = (DataTable)ViewState["dtPending"];
            int ColCount = dtPending.Columns.Count;

            for (int i = ColCount; i <= 11; i++)
            {
                gvPending.Columns[i].Visible = false;
            }
        }

        protected void gvPending_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable dtPending = (DataTable)ViewState["dtPending"];
            int ColCount = dtPending.Columns.Count;
            int RowIndex = 0;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < ColCount; i++)
                {
                    if (i == 0)
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    else if (i == 11)
                    {
                        e.Row.Cells[i].Text = "Future Qty";
                        e.Row.Cells[i].Width = 100;
                    }
                    else
                    {
                        string ExFactory = dtPending.Columns[i].ColumnName;
                        ExFactory = ExFactory.Substring(2, 8);
                        string year = ExFactory.Substring(0, 4);
                        string Month = ExFactory.Substring(4, 2);
                        string Days = ExFactory.Substring(6, 2);
          
                        strex = Days + "-" + Month + "-" + year;


                        DateTime strexDT  = Convert.ToDateTime(DateTime.ParseExact(strex, "dd-MM-yyyy", CultureInfo.InvariantCulture));
       
                        e.Row.Cells[i].Text = strexDT.ToString("dd MMM (ddd)");
                        e.Row.Cells[i].Width = 70;
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPendingCol = (Label)e.Row.FindControl("lblPendingCol");
                Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                TotalQty = 0;
                RowIndex = e.Row.RowIndex;
                for (int i = 0; i < ColCount; i++)
                {
                    if (i != 0)
                    {                      

                        if (lblPendingCol.Text == "Stitch")
                        {
                            e.Row.Cells[i].Font.Bold = true;
                            lblTotal.Font.Bold = true;
                        }

                        if(dtPending.Rows[RowIndex][dtPending.Columns[i].ColumnName].ToString() != "")
                        {
                            int iQuantity = Convert.ToInt32(dtPending.Rows[RowIndex][dtPending.Columns[i].ColumnName]);
                            e.Row.Cells[i].Text = iQuantity.ToString() == "0" ? "" : iQuantity.ToString("#,##0");

                            TotalQty = TotalQty + Convert.ToInt32(dtPending.Rows[RowIndex][dtPending.Columns[i].ColumnName].ToString());
                        }
                    }
                }

                lblTotal.Text = TotalQty.ToString() == "0" ? "" : TotalQty.ToString("#,##0");
            }

        }

    }
}