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
using iKandi.BLL;
using iKandi.Common;
using System.Collections.Generic;
using iKandi.Web.Components;
using System.IO;

/////////
namespace iKandi.Web.UserControls.Forms
{
    public partial class QualityControlHistory : BaseUserControl
    {

        #region Properties

        public int OrderDetailID
        {
            get
            {
                if (null != Request.QueryString["orderDetailID"])
                {
                    int orderDetailID;

                    if (int.TryParse(Request.QueryString["orderDetailID"].ToString(), out orderDetailID))
                        return orderDetailID;
                }

                return -1;
            }
        }

        #endregion



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControls();
            }
        }
        public void BindControls()
        {
            DataSet ds = this.QualityControllerInstance.GET_FinalAuditAndQualityAssuranceBAL(OrderDetailID);
            ViewState["failCount"] = ds;
            DataTable dtTempForEmpty = new DataTable();
            DataColumn dcTempForEmpty = new DataColumn("Empty");
            dtTempForEmpty.Columns.Add(dcTempForEmpty);
            DataRow drTempForEmpty = dtTempForEmpty.NewRow();
            drTempForEmpty["Empty"] = "No History Is Available";
            dtTempForEmpty.Rows.Add(drTempForEmpty);

            if (ds.Tables[0].Rows.Count == 0 && ds.Tables[1].Rows.Count == 0 && ds.Tables[2].Rows.Count == 0)
            {
                //Repeater1.DataSource = dtTempForEmpty;
                //Repeater1.DataBind();
                lbl.Text = "No History Is Available";
               tblmain.Visible = true;
            }
            else
            {
               tblmain.Visible = false;
                Repeater1.DataSource = ds.Tables[1];
                Repeater1.DataBind();
            }
        }
        public DataTable PivotTable(DataTable dt)
        {
            int RowCount = dt.Rows.Count;
            DataTable dttemp = new DataTable();
            //string stemp = "";
            DataColumn dctemp = new DataColumn("Type");
            dttemp.Columns.Add(dctemp);

            for (int i = 0; i <= RowCount - 1; i++)
            {
                DataColumn dc = new DataColumn("Fabric" + i);
                dttemp.Columns.Add(dc);
            }
            for (int z = 1; z <= 3; z++)
            {
                DataRow row = dttemp.NewRow();
                if (z == 1)
                {
                    row["Type"] = "Size";
                    for (int f = 0; f <= RowCount - 1; f++)
                    {

                        row["Fabric" + f] = dt.Rows[f]["size"].ToString();

                    }

                    dttemp.Rows.Add(row);
                }
                if (z == 2)
                {
                    row["Type"] = "TOTAL QTY IN STOCK";
                    for (int f2 = 0; f2 <= RowCount - 1; f2++)
                    {

                        row["Fabric" + f2] = dt.Rows[f2]["TOTAL QTY IN STOCK"].ToString();

                    }

                    dttemp.Rows.Add(row);
                }
                if (z == 3)
                {
                    row["Type"] = "Quantity Checked";
                    for (int f3 = 0; f3 <= RowCount - 1; f3++)
                    {
                        row["Fabric" + f3] = dt.Rows[f3]["Quantity Checked"].ToString();

                    }

                    dttemp.Rows.Add(row);

                }
            }
            return dttemp;
        }
        protected void GrdFaultReporing_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void GrdFaultSummary_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // e.Row.Cells[5].Visible = false;
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int failCount = Convert.ToInt32(((HiddenField)e.Item.FindControl("HdnFailCount")).Value);
            DataSet ds = (DataSet)ViewState["failCount"];
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[2];
                dt1.DefaultView.RowFilter = "FailCount=" + failCount;                
                dt1 = (dt1.DefaultView).ToTable();
                dt1.Columns["FailCount"].ColumnName = "Fail Count";

                ((Label)e.Item.FindControl("lblReAuditDate")).Text = Convert.ToString(dt1.Rows[0]["History_Date"]);

                GridView gv = (GridView)e.Item.FindControl("GrdFaultMatrix");
                dt1 = PivotTable(dt1);
                gv.DataSource = dt1;
                gv.DataBind();

                dt.DefaultView.RowFilter = "FailCount=" + failCount;
                DataView dv = dt.DefaultView;
                dt = dv.ToTable();
                dt.Columns["FailCount"].ColumnName = "Fail Count";



                GridView gvNF = (GridView)e.Item.FindControl("GrdFaultNature");
                gvNF.DataSource = dt;
                gvNF.DataBind();




                GridView GFR = (GridView)e.Item.FindControl("GrdFaultReporing");
                
                DataTable dtGRF = ds.Tables[3];
                dtGRF.DefaultView.RowFilter = "FailCount=" + failCount;
                dtGRF = (dtGRF.DefaultView).ToTable();
                dtGRF.Columns["FailCount"].ColumnName = "Fail Count";


                GFR.DataSource = dtGRF;
                GFR.DataBind();
                //  gvNF.Columns[3].Visible = false;





                GridView GFS = (GridView)e.Item.FindControl("GrdFaultSummary");

                DataTable dtGFS = ds.Tables[4];
                dtGFS.DefaultView.RowFilter = "FailCount=" + failCount;
                dtGFS = (dtGFS.DefaultView).ToTable();
                dtGFS.Columns["FailCount"].ColumnName = "Fail Count";


                GFS.DataSource = dtGFS;
                GFS.DataBind();
                // gvNF.Columns[3].Visible = false;








                //Panel pnl =(Panel) e.Item.FindControl("Panel1");
                ///
                //LiteralControl lc = new LiteralControl();
                //lc.Text = "<table>";




                foreach (DataRow dr in dt.Rows)
                {
                    //lc.Text += "<tr><td>";
                    //lc.Text += Convert.ToString(dr["Fault_Nature"]);
                    //lc.Text +="</td><td>";
                    //lc.Text += Convert.ToString(dr["Type"]);
                    //lc.Text += "</td><td>";
                    //lc.Text += Convert.ToString(dr["Name"]);
                    //lc.Text += "</td><td>";
                    //lc.Text += Convert.ToString(dr["FaultResolution"]);
                    //lc.Text += "</td></tr>";

                    //Label lb = new Label();
                    //lb.Text = Convert.ToString(dr["Fault_Nature"]);
                    //pnl.Controls.Add(lb);



                    //((Label)e.Item.FindControl("Fault_Nature")).Text = Convert.ToString(dr["Fault_Nature"]);
                    //((Label)e.Item.FindControl("Type")).Text = Convert.ToString(dr["Type"]);
                    //((Label)e.Item.FindControl("Name")).Text = Convert.ToString(dr["Name"]);
                    //((Label)e.Item.FindControl("FaultResolution")).Text = Convert.ToString(dr["FaultResolution"]);
                    //((Label)e.Item.FindControl("lblQA")).Text = Convert.ToString(dr["QA_Name"]);


                }
                //lc.Text = "<table>";
                //pnl.Controls.Add(lc);


            }

        }










    }
}

