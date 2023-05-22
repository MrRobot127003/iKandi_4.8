using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Common;
using System.Data;
using System.Web.UI.HtmlControls;
using iKandi.Web.Components;

namespace iKandi.Web
{
    public partial class CadManagerTailor : System.Web.UI.Page
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
            //styleid=32248;
            //Status="Buying Sample";
            //flagvalue = 1;

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
                        lblPreviousDayCount.Text = dtClients.Rows[0]["SampleMadeCount"].ToString();
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

                        if (lblPreviousDayCount.Text == "0")
                        {
                            txtMadeCount.Text = "";
                        }

                    }
                }


                if (flagvalue == 2)
                {
                    TailorTable.Visible =false;
                    CadTable.Visible = true;
                    DataTable dtCadMasterStatus = odjadminController.getCadManagerStatus("GET", styleid, Status);
                    lblMasterName.Text=dtCadMasterStatus.Rows[0]["MasterName"].ToString();
                    lblSampleStatus.Text=dtCadMasterStatus.Rows[0]["Status"].ToString();
                }
            }   
        }
      
        protected void Submit_Click(object sender, EventArgs e)
        {

            var TailorOnLoad = txtTailorRole.Text;
            var TailorPresent = txtTailorPresent.Text;
            var SampleMadeCount = txtMadeCount.Text;
            int result = 0;
            //var TailorLoad_id = hdnTailorLoad_id.Value;
        //var Sample_Sent = lblSampleSent.Text;                
            if (flagvalue == 1)
            {
                DateTime requestdate;
                requestdate = DateTime.ParseExact(Status, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
                result = odjadminController.InsertUpdateCadManagerTailor(Convert.ToInt32(TailorOnLoad), Convert.ToInt32(TailorPresent), Convert.ToInt32(SampleMadeCount), requestdate);
            }
            if (flagvalue == 2)
            {
                if (txtRemarkCount.Text == "")
                    txtRemarkCount.Text = "0";
                result = odjadminController.UpdateCadManagerStatus("UPDATE", Convert.ToInt32(txtRemarkCount.Text), styleid, Status);
            }
           string message = "Your details have been saved successfully.";
    string script = "window.onload = function(){ alert('";
    script += message;
    script += "')};";
    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
   
        }
       
    }
}