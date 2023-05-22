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

namespace iKandi.Web.UserControls.Lists
{
    public partial class SeasonList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)          
                BindGrd();
            
        }

        public void BindGrd()
        {
            ClientController obj = new ClientController();
            grdAllSeason.DataSource = obj.GetAllSeasonListInfoBAL();
            grdAllSeason.DataBind();       
        }

       

        protected void grdAllSeason_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ClientController obj = new ClientController();
           
            foreach (GridViewRow grd in grdAllSeason.Rows)
            {
              
    
                HiddenField hdnIdvalue = (HiddenField)grd.FindControl("hdnID");
                DataTable dt = obj.GetAllSeasonListInfoWithClientBAL(Convert.ToInt32(hdnIdvalue.Value)); 
                GridView grdserver = (GridView)grd.FindControl("grdClient");
                Label lbl = (Label)grd.FindControl("lbl");
                lbl.Text = Convert.ToString(dt.Rows[0]["officialname"]);
              
            }
        }

       


    }
}