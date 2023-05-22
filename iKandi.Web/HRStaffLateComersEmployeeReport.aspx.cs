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
using System.Text;
using System.Collections.Generic;
using iKandi.BLL;
using System.Text.RegularExpressions;
using System.Web.Caching;
using iKandi.Common;
using iKandi.Web.Components;
namespace iKandi.Web
{
  public partial class HRStaffLateComersEmployeeReport : System.Web.UI.Page
  {
    AdminController objadmin = new AdminController();
    protected void Page_Load(object sender, EventArgs e)
         
    {
      DateTime now = DateTime.Now;

      string WriteFile = "";
      string Day = now.ToString("dd");
      string Month = "";
      Month = now.ToString("MMM");
      string Attandence_url = "AttandenceSheet_" + Day + Month + ".html";
      WriteFile = "http://www.boutique.in/uploads/NewsLetter/" + Attandence_url;
      aLinkAttandenceSheet.HRef = WriteFile;
      if (!Page.IsPostBack)
      {
        bindgrd();

      }

    }
    public void bindgrd()
    {
      DataSet ds = objadmin.attlatecommerc();
      grdattlatecommerc.DataSource = ds.Tables[0];
      grdattlatecommerc.DataBind();

      
      grdleave.DataSource = ds.Tables[1];
      grdleave.DataBind();


      GrvTopPerformers.DataSource = ds.Tables[2];
      GrvTopPerformers.DataBind();

      GrvBIPLSummary.DataSource = ds.Tables[3];
      GrvBIPLSummary.DataBind(); 

    }
  
    protected void grdattlatecommerc_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      //DataRowView drv = e.Row.DataItem as DataRowView;

      if (e.Row.RowType == DataControlRowType.DataRow)
      {
          Label lblAvgIntime = (Label)e.Row.FindControl("lblavg");
          Label lblIntime = (Label)e.Row.FindControl("lblIntime");
          Label lblIntimes = (Label)e.Row.FindControl("lblIntimes");
          Label lblIdealAvgIntimes = (Label)e.Row.FindControl("lblIdealAvgIntimes");
          Label lblIdealAvgIntimes_3m = (Label)e.Row.FindControl("lblIdealAvgIntimes_3m");

          DateTime t1 = DateTime.Parse("2012/12/12 " + lblAvgIntime.Text + ":00.000");
          DateTime t2 = DateTime.Parse("2012/12/12 "+ lblIntimes.Text +":00.000");
         // DateTime t3 = DateTime.Parse("2012/12/12 " + lblIntime.Text + ":00.000");

          // updated code by bharat on 25-mar
          TimeSpan duration12month = DateTime.Parse(lblAvgIntime.Text).Subtract(DateTime.Parse(lblIntime.Text));
          string time12month = duration12month.ToString();
          double Totalmin12month = TimeSpan.Parse(time12month).TotalMinutes;
          lblIdealAvgIntimes.Text = Totalmin12month.ToString() + " " + "Min";
       
          TimeSpan duration3month = DateTime.Parse(lblIntimes.Text).Subtract(DateTime.Parse(lblIntime.Text));
          string time3month = duration3month.ToString();
          double Totalmin3month = TimeSpan.Parse(time3month).TotalMinutes;
          lblIdealAvgIntimes_3m.Text =  Totalmin3month.ToString() + " " + "Min";
          // end
          if (t1.TimeOfDay > t2.TimeOfDay)
          {
              lblIntimes.Font.Bold=true;
              lblIntimes.ForeColor=System.Drawing.Color.Black;
          }
          else
          {
              lblIntimes.Font.Bold = true;
              lblIntimes.ForeColor = System.Drawing.Color.Red;
          }


      }

    }

    protected void GrvTopPerformers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblAvgIntime = (Label)e.Row.FindControl("lblavg");
            Label lblIntime = (Label)e.Row.FindControl("lblIntime");
            Label lblIntimes = (Label)e.Row.FindControl("lblIntimes");
            Label lblIdealAvgIntimes = (Label)e.Row.FindControl("lblIdealAvgIntimes");
            Label lblIdealAvgIntimes_3m = (Label)e.Row.FindControl("lblIdealAvgIntimes_3m");
            if (lblAvgIntime.Text == "")
                lblAvgIntime.Text = lblIdealAvgIntimes.Text;
            DateTime t1 = DateTime.Parse("2012/12/12 " + lblAvgIntime.Text + ":00.000");
            DateTime t2 = DateTime.Parse("2012/12/12 " + lblIntimes.Text + ":00.000");
            // DateTime t3 = DateTime.Parse("2012/12/12 " + lblIntime.Text + ":00.000");
            TimeSpan duration12month = DateTime.Parse("1900-01-01 00:00:00.000").Subtract(DateTime.Parse("1900-01-01 00:00:00.000"));
            // updated code by bharat on 25-mar
            if (lblIntime.Text != "")
            {
                duration12month = DateTime.Parse(lblAvgIntime.Text).Subtract(DateTime.Parse(lblIntime.Text));
            }
            
            string time12month = duration12month.ToString();
            double Totalmin12month = TimeSpan.Parse(time12month).TotalMinutes;
            lblIdealAvgIntimes.Text = Totalmin12month.ToString() + " " + "Min";

            TimeSpan duration3month = DateTime.Parse("1900-01-01 00:00:00.000").Subtract(DateTime.Parse("1900-01-01 00:00:00.000"));
            if (lblIntime.Text != "")
            {
                duration3month = DateTime.Parse(lblIntimes.Text).Subtract(DateTime.Parse(lblIntime.Text));
            }
            string time3month = duration3month.ToString();
            double Totalmin3month = TimeSpan.Parse(time3month).TotalMinutes;
            lblIdealAvgIntimes_3m.Text = Totalmin3month.ToString() + " " + "Min";
            // end
            //if (t1.TimeOfDay > t2.TimeOfDay)
            //{
                lblIntimes.Font.Bold = true;
                lblIntimes.ForeColor = System.Drawing.Color.Green;
            //}
            //else
            //{
            //    lblIntimes.Font.Bold = true;
            //    lblIntimes.ForeColor = System.Drawing.Color.Red;
            //}
        }
    }

    protected void grdleave_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //DataRowView drv = e.Row.DataItem as DataRowView;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblIntime = (Label)e.Row.FindControl("lblavg");
            Label lblIntimes = (Label)e.Row.FindControl("lblavg3");

         

            if (Convert.ToInt32(lblIntime.Text) > Convert.ToInt32(lblIntimes.Text))
            {
                lblIntimes.Font.Bold = true;
                lblIntimes.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                lblIntimes.Font.Bold = true;
                lblIntimes.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    protected void GrvBIPLSummary_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView drv = e.Row.DataItem as DataRowView;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Label lblIntime = (Label)e.Row.FindControl("lblavg");
            //Label lblIntimes = (Label)e.Row.FindControl("lblavg3");
            //if (Convert.ToInt32(lblIntime.Text) > Convert.ToInt32(lblIntimes.Text))
            //{
            //    lblIntimes.Font.Bold = true;
            //    lblIntimes.ForeColor = System.Drawing.Color.Black;
            //}
            //else
            //{
            //    lblIntimes.Font.Bold = true;
            //    lblIntimes.ForeColor = System.Drawing.Color.Red;
            //}
        }
    }
  }
}