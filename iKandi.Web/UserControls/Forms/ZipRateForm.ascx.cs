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

using iKandi.Web.Components;
using iKandi.Common;



namespace iKandi.Web.UserControls.Forms
{
    public partial class ZipRateForm : BaseUserControl
    {
        #region Properties

        public int Id
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                {
                    return Convert.ToInt32(Request.QueryString["Id"]);
                }

                return -1;
            }
        }

        #endregion

        #region Event Handlers


        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            if (!IsPostBack)
            {
                BindControls();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            SaveZipRate();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtDetail.Text = "";
            ddlType.SelectedValue = "-1";
            txtSize.Text = "";
            txtRate.Text = "";
            Response.Redirect("~/Admin/ZipRate/ZipRateListing.aspx");
        }

        #endregion

        #region Private Method

        private void SaveZipRate()
        {
            Zip z = new Zip();
            z.Id = this.Id;
            z.Detail = txtDetail.Text;
            z.Type = ddlType.SelectedItem.Text;
            z.Size = Convert.ToInt32(txtSize.Text);
            z.Rate = Convert.ToDouble(txtRate.Text);

            this.AdminControllerInstance.Save(z);

            pnlForm.Visible = false;
            pnlMessage.Visible = true;
        }

        private void BindControls()
        {

            Zip z = new Zip();
            DropdownHelper.BindZipRateType(ddlType as ListControl);
            if (Id != -1)
            {
                PopulateZipRateData();
            }

        }

        private void PopulateZipRateData()
        {
            Zip z = this.AdminControllerInstance.GetZipRateById(Id);
            txtDetail.Text = z.Detail;
           ddlType.SelectedValue = z.Type;
            txtSize.Text = z.Size.ToString();
            txtRate.Text = z.Rate.ToString();
            
        }

       #endregion

    }
}