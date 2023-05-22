using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using iKandi.Web.Components;
using iKandi.BLL;
using iKandi.Common;
using System.Drawing;



namespace iKandi.Web.Admin.FitsSample

{
    public partial class CadManagerMaster : System.Web.UI.UserControl
    {
        public int styleid
        {
            get;
            set;
        }
        public int flagvalue
        {
            get;
            set;
        }
        public string Status
        {
            get;
            set;
        }
        AdminController odjadminController = new AdminController();
        protected void Page_Load(object sender, EventArgs e)
        {
          if (null != Request.QueryString["styleid"])
          {
            styleid = Convert.ToInt32(Request.QueryString["styleid"]);
          }
          if (null != Request.QueryString["flagvalue"])
          {
            flagvalue = Convert.ToInt32(Request.QueryString["flagvalue"]);
          }
          if (null != Request.QueryString["Status"])
          {
            Status = Request.QueryString["Status"].ToString();
          }
          
            if (!IsPostBack)
            {
                if (flagvalue != 2)
                {
                    TailorTable.Visible = true;
                    CadTable.Visible = false;
                    
                    DataTable dtClients = odjadminController.getCadManagerTailor();
                    if (dtClients.Rows.Count > 0)
                    {
                        txtTailorRole.Text = dtClients.Rows[0]["TailorOnLoad"].ToString();
                        txtTailorPresent.Text = dtClients.Rows[0]["TailorPresent"].ToString();
                        lblSampleSent.Text = dtClients.Rows[0]["samplesent"].ToString();
                        txtMadeCount.Text = dtClients.Rows[0]["SampleMadeCount"].ToString();
                        if (txtTailorRole.Text == "0")
                        {
                            txtTailorRole.Text = "";
                        }
                        if (txtTailorPresent.Text == "0")
                        {
                            txtTailorPresent.Text = "";
                        }
                        if (lblSampleSent.Text == "0")
                        {
                            lblSampleSent.Text = "";
                        }

                        if (txtMadeCount.Text == "0")
                        {
                            txtMadeCount.Text = "";
                        }

                    }
                }


                if (flagvalue == 2)
                {
                    TailorTable.Visible = false;
                    CadTable.Visible = true;
                 
                    DataTable dtCadMasterStatus = odjadminController.getCadManagerStatus("GET", styleid, Status);
                    lblMasterName.Text = dtCadMasterStatus.Rows[0]["MasterName"].ToString();
                    lblSampleStatus.Text = dtCadMasterStatus.Rows[0]["Status"].ToString();
                    lblperiviouscount.Text = (dtCadMasterStatus.Rows[0]["SumRemakeCount"].ToString() == "0" ? "" : dtCadMasterStatus.Rows[0]["SumRemakeCount"].ToString());
                    lblCountoverall.Text = (dtCadMasterStatus.Rows[0]["OverallCount"].ToString() == "0" ? "" : "overall :"+dtCadMasterStatus.Rows[0]["OverallCount"].ToString());
                }
            }   
        }

        protected void btnsub_Click(object sender, EventArgs e)
        {
          var TailorOnLoad = txtTailorRole.Text;
          var TailorPresent = txtTailorPresent.Text;
          var SampleMadeCount = txtMadeCount.Text;
          int result = 0;
          //var TailorLoad_id = hdnTailorLoad_id.Value;
          //var Sample_Sent = lblSampleSent.Text;                
          if (flagvalue == 1)
          {
            result = odjadminController.InsertUpdateCadManagerTailor(Convert.ToInt32(TailorOnLoad), Convert.ToInt32(TailorPresent), Convert.ToInt32(SampleMadeCount),DateTime.Now);
          }
          if (flagvalue == 2)
          {
            if (txtRemarkCount.Text == "")
              txtRemarkCount.Text = "0";

            if (Convert.ToInt32(txtRemarkCount.Text) <= 0)
            {
              Page.ClientScript.RegisterStartupScript(this.GetType(), "close", "<script language=javascript>alert('Remake count cannot be 0');</script>");
              return;
            }
            result = odjadminController.UpdateCadManagerStatus("UPDATE", Convert.ToInt32(txtRemarkCount.Text), styleid, Status);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "close", "<script language=javascript>alert('Data saved successfully!');</script>");
            //Page.Response.Redirect(Page.Request.Url.ToString(), true);
          }
          //string message = "Your details have been saved successfully.";
          //string script = "window.onload = function(){ alert('";
          //script += message;
          //script += "')};";

          //Page.ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
          //string radalertscript = "<script language='javascript'>window.parent.Shadowbox.close();</script>";
          //Page.ClientScript.RegisterStartupScript(this.GetType(), "radalert", radalertscript);

          
        }
    }
}