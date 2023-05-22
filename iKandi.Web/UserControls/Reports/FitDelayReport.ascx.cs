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
using iKandi.Web.Components;
using System.Collections.Generic;

namespace iKandi.Web.UserControls.Reports
{
    public partial class FitDelayReport : BaseUserControl
    {      

        protected void Page_Load(object sender, EventArgs e)
        {           
                BindGrid();              
           
        }
        private void BindGrid()
        {
            DataSet Ds = new DataSet();
            DataSet Dsfactory = new DataSet();
            DataTable Dt = new DataTable();
            DataTable Dtfactory = new DataTable();
            DataRow dr;
            DataRow drfactory;
            int TotalFactoryWise;
            int rowi;
            int rows;
            Ds=this.ReportControllerInstance.GetFitDelay();
            Dsfactory = this.ReportControllerInstance.GetFitDelayforFactory();
            if (Ds.Tables[0].Rows.Count > 0)
            {
                for(rowi=0;rowi<=Ds.Tables[0].Rows.Count-1;rowi++)
                {
                    if (Convert.ToString(Ds.Tables[0].Rows[rowi]["Target"]).Contains("0000000"))
                    {
                        Dt.Columns.Add("Delayed");                        
                    }
                    else 
                    {
                        Dt.Columns.Add(Convert.ToString(Ds.Tables[0].Rows[rowi]["Target"]), typeof(string));
                    }
                }
                dr = Dt.NewRow();
                for (rowi = 0; rowi <= Ds.Tables[0].Rows.Count - 1; rowi++)
                {
                    dr[rowi] = Ds.Tables[0].Rows[rowi]["DataItem"];
                }
                Dt.Rows.Add(dr);               

            }
            Dtfactory.Columns.Add("Factory", typeof(string));
            if (Dsfactory.Tables[0].Rows.Count > 0)
            {
                for (rows = 0; rows <= Dsfactory.Tables[0].Rows.Count - 1; rows++)
                {
                    if (!Dtfactory.Columns.Contains(Convert.ToString(Dsfactory.Tables[0].Rows[rows]["Target"])))
                        Dtfactory.Columns.Add(Convert.ToString(Dsfactory.Tables[0].Rows[rows]["Target"]), typeof(string));
                }
                Dtfactory.Columns.Add("Total");
                
                for (int rows1 = 0; rows1 <= Dsfactory.Tables[0].Rows.Count - 1; rows1++)
                {

                    if (!IsFactoryExists(Dtfactory, Convert.ToString(Dsfactory.Tables[0].Rows[rows1]["ProductionUnit"])))
                    {
                        drfactory = Dtfactory.NewRow();
                        drfactory[0] = Convert.ToString(Dsfactory.Tables[0].Rows[rows1]["ProductionUnit"]);
                        drfactory["Total"] = 0;
                        for (int cols = 1; cols <= Dtfactory.Columns.Count - 1; cols++)
                        {
                            drfactory[cols] = null;
                        }
                        Dtfactory.Rows.Add(drfactory);
                    }
                }
                int TotalFactory = 0;
                for (int rows1 = 0; rows1 <= Dsfactory.Tables[0].Rows.Count - 1; rows1++)
                {
                    for (int dtRow = 0; dtRow <= Dtfactory.Rows.Count - 1; dtRow++)
                    {
                        if (Dtfactory.Rows[dtRow]["Factory"].ToString() == Convert.ToString(Dsfactory.Tables[0].Rows[rows1]["ProductionUnit"]))
                        {
                            Dtfactory.Rows[dtRow][Convert.ToString(Dsfactory.Tables[0].Rows[rows1]["Target"])] = Convert.ToString(Dsfactory.Tables[0].Rows[rows1]["DataItem"]);
                            break;
                        }
                    }

                }
                drfactory = Dtfactory.NewRow();               
                drfactory[0]="TOTAL";
                string[] ordernum=new string[2];
                int total = 0;
                for (int cols = 1; cols <= Dtfactory.Columns.Count - 1; cols++)
                {
                    for (int rows1 = 0; rows1 <= Dtfactory.Rows.Count - 1; rows1++)
                    {
                        ordernum = Convert.ToString(Dtfactory.Rows[rows1][cols]).Split('$');
                        if (Convert.ToString(Dtfactory.Rows[rows1][cols]) != "" || Convert.ToString(Dtfactory.Rows[rows1][cols]) != string.Empty)
                        total += Convert.ToInt32(ordernum[0]);
                    }
                    drfactory[cols] = total;
                    total = 0;
                }
                drfactory["Total"] = 0;
                Dtfactory.Rows.Add(drfactory);
                TotalFactoryWise = 0;
                for (int rowno = 0; rowno <= Dtfactory.Rows.Count - 2; rowno++)
                {
                    for (int colno = 1; colno <= Dtfactory.Columns.Count - 2; colno++)
                    {
                        string[] dataval;
                        dataval= Convert.ToString(Dtfactory.Rows[rowno][colno]).ToString().Split('$');
                        if(dataval.Length>1)
                        TotalFactory += Convert.ToInt32(dataval[0].ToString());   
                        
                    }
                    TotalFactoryWise += TotalFactory;
                    Dtfactory.Rows[rowno]["Total"] = TotalFactory;
                    TotalFactory = 0;
                }
                Dtfactory.Rows[Dtfactory.Rows.Count - 1]["Total"] = TotalFactoryWise;
               
            }
            gvfactorypending.DataSource = Dtfactory;
            gvfactorypending.DataBind();
         
            gvDelay.DataSource = Dt;
            gvDelay.DataBind();

        }
        private bool UpdateRecord(DataTable Dtfactory, DataSet MasterDS, int RowId)
        {

            return true;
        }

        private bool IsFactoryExists(DataTable Dtfactory,string NewFactory)
        {
            bool RetVal = false;
            for (int i = 0; i <= Dtfactory.Rows.Count - 1; i++)
            {
                if (Convert.ToString(Dtfactory.Rows[i]["Factory"]) == NewFactory)
                {
                    RetVal = true;
                    break;
                }
            }

            return RetVal;
        }
        protected void gvDelay_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {            
                    for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
                    {
                        string [] count = new string[2];
                        count= e.Row.Cells[i].Text.Split('$');
                        string txt = count[1];
                        LinkButton lbl = new LinkButton();
                        //lbl.Attributes.Add("onclick", "popWin();return false;");
                        lbl.Text = count[0];
                        lbl.CommandArgument = txt;
                        e.Row.Cells[i].Controls.Add(lbl);
                        lbl.Click +=new EventHandler(lbl_Click);
                    }
            }
        }

        protected void lbl_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            Session["OrderDetailIds"+ApplicationHelper.LoggedInUser.UserData.UserID.ToString()] = Convert.ToString(lnk.CommandArgument);
            
            string stringIds = Convert.ToString(lnk.CommandArgument);
            if (stringIds != "")
            Page.ClientScript.RegisterStartupScript(this.GetType(), "windowopen", "popWin('a');", true);
            else
            Page.ClientScript.RegisterStartupScript(this.GetType(), "windowopen", "popWin('z');", true);
        }

        protected void gvfactorypending_RowDataBound(object sender, GridViewRowEventArgs e)
        {           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 1; i <= e.Row.Cells.Count - 2; i++)
                {
                    if (e.Row.Cells[0].Text != "TOTAL")
                    {

                        string txtfactory = string.Empty;
                        string[] count = new string[2];
                        count = e.Row.Cells[i].Text.Split('$');
                        LinkButton btnlbl = new LinkButton();
                        if (e.Row.Cells[i].Text == "&nbsp;")
                        {
                            btnlbl.Visible = false;
                        }
                        else
                        {
                            btnlbl.Text = count[0];
                            txtfactory = count[1];
                            btnlbl.CommandArgument = txtfactory;
                            e.Row.Cells[i].Controls.Add(btnlbl);
                        }
                        btnlbl.Click += new EventHandler(lbl_Click);
                    }
                }
            }

        }
    }
}