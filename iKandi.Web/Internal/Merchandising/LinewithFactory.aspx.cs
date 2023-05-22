using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.Web.Components;

namespace iKandi.Web.Internal.Merchandising
{
    public partial class LinewithFactory : System.Web.UI.Page
    {
        iKandi.BLL.OrderController ord = new BLL.OrderController();
        public int OrderDetailId
        {
            get;
            set;
        }

        public int Unitid
        {
            get;
            set;
        }

        public int StyleId
        {
          get;
          set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                BindlineGrid();
            }
        }

        private void BindlineGrid()
        {
            try
            {
                if (null != Request.QueryString["OrderDetailId"])
                {
                    OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"]);
                }

                if (null != Request.QueryString["unitid"])
                {
                    Unitid = Convert.ToInt32(Request.QueryString["unitid"]);
                }

                if (null != Request.QueryString["StyleId"])
                {
                  StyleId = Convert.ToInt32(Request.QueryString["StyleId"]);
                }
                
                DataSet dsAllocation = new DataSet();

                dsAllocation = ord.GetReAllocationDetailsById(OrderDetailId, Unitid);
                gvReAllocation.DataSource = dsAllocation.Tables[2];
              
                gvReAllocation.DataBind();
                ViewState["UnallocatedQty"] = dsAllocation.Tables[4].Rows[0]["Totalunallocated"].ToString();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }


        protected void gvReAllocation_rowdatabound(object sender, GridViewRowEventArgs e)
        {
        }


        protected void gvReAllocation_RowCommand(object sender, GridViewRowEventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            int AddQty = 0, minusQty = 0, lineQty = 0, sumaddQty = 0, summinqty = 0, lineplanid = 0, unstichedQty = 0, sumunstichedQty=0,totunallocated=0;
            try
            {
                if (null != Request.QueryString["OrderDetailId"])
                {
                    OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"]);
                }

                if (null != Request.QueryString["unitid"])
                {
                    Unitid = Convert.ToInt32(Request.QueryString["unitid"]);
                }

                if (null != Request.QueryString["StyleId"])
                {
                  StyleId = Convert.ToInt32(Request.QueryString["StyleId"]);
                }

                foreach (GridViewRow gvr in gvReAllocation.Rows)
                {


                    TextBox txtreshflueplus = (TextBox)gvr.FindControl("txtreshflueplus");
                    TextBox txtunstichedQty = (TextBox)gvr.FindControl("txtunstichedQty");
                    TextBox txtreshflueminus = (TextBox)gvr.FindControl("txtreshflueminus");
                    Label lbllineQty = (Label)gvr.FindControl("lbllineQty");
                    Label lbllineplain = (Label)gvr.FindControl("lbllineplain");

                    lineplanid = Convert.ToInt32(lbllineplain.Text);

                    if (txtunstichedQty.Text != "")
                    {

                        unstichedQty = Convert.ToInt32((txtunstichedQty.Text).Replace(",", ""));
                        sumunstichedQty = sumunstichedQty + unstichedQty;
                    }
                    if (txtreshflueplus.Text != "")
                    {

                        AddQty = Convert.ToInt32(txtreshflueplus.Text);
                        sumaddQty = sumaddQty + AddQty;
                    }

                    if (txtreshflueminus.Text != null)
                    {
                        minusQty = Convert.ToInt32(txtreshflueminus.Text);
                        summinqty = summinqty + minusQty;
                    }

                    lineQty = Convert.ToInt32((lbllineQty.Text).Replace(",", ""));
                    lineQty = lineQty + (AddQty - minusQty);

                    
                }
                if (ViewState["UnallocatedQty"] != null)
                {
                    totunallocated = Convert.ToInt32(ViewState["UnallocatedQty"].ToString());
                }

                int tot = (totunallocated + sumunstichedQty);

                if (sumunstichedQty+(sumaddQty - summinqty) > tot)
                {
                    lblnm.Text = "Cannot Submit in this Case";
                    return;
                }       

                foreach (GridViewRow gvr in gvReAllocation.Rows)
                {
                    sumaddQty = 0; summinqty = 0;

                    TextBox txtreshflueplus = (TextBox)gvr.FindControl("txtreshflueplus");
                    TextBox txtunstichedQty = (TextBox)gvr.FindControl("txtunstichedQty");
                    TextBox txtreshflueminus = (TextBox)gvr.FindControl("txtreshflueminus");
                    Label lbllineQty = (Label)gvr.FindControl("lbllineQty");
                    Label lbllineplain = (Label)gvr.FindControl("lbllineplain");

                     lineplanid = Convert.ToInt32(lbllineplain.Text);

                     if (txtunstichedQty.Text != "")
                     {

                         unstichedQty = Convert.ToInt32((txtunstichedQty.Text).Replace(",", "")); 
                         sumunstichedQty = sumunstichedQty + unstichedQty;
                     }
                    if (txtreshflueplus.Text != "")
                    {
                       
                        AddQty = Convert.ToInt32(txtreshflueplus.Text);
                        sumaddQty = sumaddQty + AddQty;
                    }

                    if (txtreshflueminus.Text != null)
                    {
                        minusQty = Convert.ToInt32(txtreshflueminus.Text);
                        summinqty = summinqty + minusQty;
                    }

                    lineQty = Convert.ToInt32((lbllineQty.Text).Replace(",", ""));
                    lineQty = lineQty + (AddQty - minusQty);

                    int UserID = ApplicationHelper.LoggedInUser.UserData.UserID;
                    int iSaveComment = ord.UpdatelineQty_unitQty(lineQty, Unitid, OrderDetailId, "lineQty", lineplanid, UserID);
                  
                }
                lineQty = sumaddQty - summinqty;
                if (lineQty > 0)
                {
                   // int iSaveComment1 = ord.UpdatelineQty_unitQty(lineQty, Unitid, OrderDetailId, "unitQty", lineplanid);
                }

                iKandi.BLL.AdminController oAdminController = new iKandi.BLL.AdminController();               
                oAdminController = null;
            
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.reload();", true);
            }

            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }



        }
            
          
       

        
    

           
          
          
        
    }
}