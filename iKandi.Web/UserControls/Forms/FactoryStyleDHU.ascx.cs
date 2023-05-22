
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.Data;

namespace iKandi.Web.UserControls.Forms
{
    public partial class FactoryStyleDHU : System.Web.UI.UserControl
    {
        int Unitid = 11;
        int lineno = 1;
        OrderController objOrderController = new OrderController();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<string, int> Factory1 = new Dictionary<string, int>();
            Dictionary<string, int> Factory2 = new Dictionary<string, int>();
            Dictionary<string, int> Factory3 = new Dictionary<string, int>();
            Factory1.Add("C45-46", 11);
            Factory2.Add("B 45", 12);

            Factory3.Add("C 47", 3);

            dtlist1.DataSource = Factory1;
            dtlist1.DataBind();
            ds = objOrderController.GetDHUDAYTAByStyle(Unitid, lineno);
            grdFactEff.DataSource = ds.Tables[2];
            grdFactEff.DataBind();

            DataList2.DataSource = Factory2;
            DataList2.DataBind();
            ds = objOrderController.GetDHUDAYTAByStyle(Unitid, lineno);
            GrdEff2.DataSource = ds.Tables[2];
            GrdEff2.DataBind();

            DataList3.DataSource = Factory3;
            DataList3.DataBind();
            ds = objOrderController.GetDHUDAYTAByStyle(Unitid, lineno);
            grdeff3.DataSource = ds.Tables[2];
            grdeff3.DataBind();

            //for( int i=0;i<=3;i++)
            //{
            //    dtlist1.DataSource = Factory;
            //    dtlist1.DataBind();

            //    ds = objOrderController.GetDHUDAYTAByStyle(Unitid, lineno);
            //    grdFactEff.DataSource = ds.Tables[2];
            //    grdFactEff.DataBind();
            //}
           

            ds = objOrderController.GetDHUDAYTAByStyleAllFactory(Unitid, lineno);
                grdFactEffBIPL.DataSource = ds.Tables[0];
                grdFactEffBIPL.DataBind();
          
           
           
           
        }

        protected void dtlist_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataTable tbl = ((DataRowView)e.Item.DataItem).Row.Table;
                Label lbllines = (Label)e.Item.FindControl("lbllines");
                GridView grd = (GridView)e.Item.FindControl("Grdeff");
             ///   GridView grdFactEff = (GridView)e.Item.FindControl("grdFactEff");
                Label lblavg=(Label)e.Item.FindControl("lblavg");
               // GridView grdFactEffBIPL = (GridView)e.Item.FindControl("grdFactEffBIPL");
                HiddenField hidline = (HiddenField)e.Item.FindControl("hidline");
                //DataList dtlist = (DataList)e.Item.FindControl("dtlist");
              //  grdFactEff.Visible = false;
              //  grdFactEffBIPL.Visible = false;
                lineno = Convert.ToInt32(hidline.Value);
                if (e.Item.ItemIndex == tbl.Rows.Count - 1)
                { 
                    int row =e.Item.ItemIndex;
                    
                    lblavg.Visible = true;
                  //  grdFactEff.Visible = true;
                    e.Item.CssClass = "Heading";
                    
                   // ds = objOrderController.GetDHUDAYTAByStyle(Unitid, lineno);
                  //  grdFactEff.DataSource = ds.Tables[2];
                  //  grdFactEff.DataBind();
                    
                  
                }


               
                ds = objOrderController.GetDHUDAYTAByStyle(Unitid, lineno);
                grd.DataSource = ds.Tables[1];
                grd.DataBind();
               
               
            }
        }
     
        protected void Grdeff_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblActual = (Label)e.Row.FindControl("lblActual");
                     Label lblmaxActual = (Label)e.Row.FindControl("lblmaxActual");
                  Label LblActualDth = (Label)e.Row.FindControl("LblActualDth");
                  Label lblmindth = (Label)e.Row.FindControl("lblmindth");
                  if (lblActual.Text == "0")
                  {
                      lblActual.Text = "";
                  }
                  else
                  {
                      lblActual.Text = lblActual.Text + "%";
                  }

                  if (lblmaxActual.Text == "0")
                  {
                      lblmaxActual.Text = "";
                  }
                  else
                  {
                      lblmaxActual.Text = "("+lblmaxActual.Text +"%)";
                  }



                  if (LblActualDth.Text == "0")
                  {
                      LblActualDth.Text = "";
                  }
                  else
                  {
                      LblActualDth.Text = LblActualDth.Text +"%";
                  }


                  if (lblmindth.Text == "0")
                  {
                      lblmindth.Text = "";
                  }
                  else
                  {
                      lblmindth.Text = "("+lblmindth.Text+"%)";
                  }
             

                
            }
        }

        protected void grdFactEff_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
              
                Label line = (Label)e.Row.FindControl("line");
                Label Label1 = (Label)e.Row.FindControl("Label1");
                if (line.Text == "0")
                {
                    line.Text = "";
                }
                else
                {
                    line.Text = line.Text + "%";
                }

                if (Label1.Text == "0")
                {
                    Label1.Text = "";
                }
                else
                {
                    Label1.Text = Label1.Text + "%";
                }

                 

                
                    
            }
        }

        protected void grdFactEffBIPL_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label line = (Label)e.Row.FindControl("line");
                Label Label1 = (Label)e.Row.FindControl("Label1");
                Label linemaxAvg = (Label)e.Row.FindControl("linemaxAvg");
                Label lblmaxDHU = (Label)e.Row.FindControl("lblmaxDHU");
                Label lblbestAvg = (Label)e.Row.FindControl("lblbestAvg");
                Label lblbestDhu = (Label)e.Row.FindControl("lblbestDhu");
               

                if (line.Text =="0")
                {
                    line.Text = "";
                }
                else
                {
                    line.Text = line.Text + "%";
                }

                if (Label1.Text == "0")
                {
                    Label1.Text = "";
                }
                else
                {
                    Label1.Text = Label1.Text + "%";
                }

                if (linemaxAvg.Text == "0")
                {
                    linemaxAvg.Text = "";
                }
                else
                {
                    linemaxAvg.Text = linemaxAvg.Text + "%";
                }

                if (lblmaxDHU.Text == "0")
                {
                    lblmaxDHU.Text = "";
                }
                else
                {
                    lblmaxDHU.Text = lblmaxDHU.Text + "%";
                }

                if (lblbestAvg.Text == "0")
                {
                    lblbestAvg.Text = "";
                }
                else
                {
                    lblbestAvg.Text = lblbestAvg.Text + "%";
                }

                if (lblbestDhu.Text == "0")
                {
                    lblbestDhu.Text = "";
                }
                else
                {
                    lblbestDhu.Text = lblbestDhu.Text + "%";
                }
            }
        }

        protected void dtlist1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            HiddenField hidUnitid = (HiddenField)e.Item.FindControl("hidUnitid");
            Unitid = Convert.ToInt32(hidUnitid.Value);
            DataList dtlist = (DataList)e.Item.FindControl("dtlist");
            ds = objOrderController.GetDHUDAYTAByStyle(Unitid, lineno);

            
            dtlist.DataSource = ds;
            dtlist.DataBind();
            
            dtlist.RepeatColumns = ds.Tables[0].Rows.Count;
            int Count = ds.Tables[0].Rows.Count;
        }
    }
}