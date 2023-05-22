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
using System.Text;

namespace iKandi.Web
{
  
    public partial class BuyingHouseForm : BaseUserControl
    {
        #region Properties

        public int BuyingHouseID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["bhid"]))
                {
                    return Convert.ToInt32(Request.QueryString["bhid"]);
                }

                return -1;
            }
        }

        #endregion

        #region Event Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Request.QueryString["btn"]) == "1")
            {
                HtmlInputButton htmbtn = (HtmlInputButton)this.FindControl("btnPrint");
                htmbtn.Attributes.Add("style", "display:none");
                btnSubmit.Visible = false;
            }
            if (!IsPostBack)
            {
                if (BuyingHouseID != -1)
                {
                    PopulateData();
                }
            }
          

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            CreateBuyingHouse();
        }
        #endregion

        #region Private Methods

        private void PopulateData()
        {

            BuyingHouse bh = this.BuyingHouseController.GetBHByID(BuyingHouseID);
                  
            txtCompany.Text = bh.CompanyName;
            txtWebsite.Text = bh.Website;
            txtAddress.Text = bh.Address;           
            txtClient.Text = bh.ClientSince.ToString("dd MMM yy (ddd)") == "01 Jan 01 (Mon)" ? "" : bh.ClientSince.ToString("dd MMM yy (ddd)"); 
            txtEmail.Text = bh.Email;
            txtPhone.Text = bh.Phone;
            txtBHCode.Text = bh.BHCode;

            CheckIsActive.Checked = Convert.ToBoolean(bh.IsActive);

        }

        private void CreateBuyingHouse()
        {
          //  if(CheckIsActive.Checked==false)
                if (this.BuyingHouseController.GetBuyingHouseStatusBAL(this.BuyingHouseID) > 0 && CheckIsActive.Checked == false)
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true,'This buying house  is tagged with one or more clients.');";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), script, true);
                CheckIsActive.Checked = true;
                return;
            }
            BuyingHouse bhouse = new BuyingHouse();
            bhouse.BuyingHouseID = this.BuyingHouseID;
            bhouse.CompanyName = txtCompany.Text;
            bhouse.Website = txtWebsite.Text;
            bhouse.Address = txtAddress.Text;
            bhouse.BHCode = txtBHCode.Text;
            bhouse.Email = txtEmail.Text;
            bhouse.Phone = txtPhone.Text;
            if (CheckIsActive.Checked == true)
                bhouse.IsActive = 1;
            else
                bhouse.IsActive = 0;
            bhouse.ClientSince = DateHelper.ParseDate(txtClient.Text).Value;
            this.BuyingHouseController.SaveBuyingHouse(bhouse);
            pnlForm.Visible = false;
            pnlMessage.Visible = true;
        }


        #endregion


    }
}