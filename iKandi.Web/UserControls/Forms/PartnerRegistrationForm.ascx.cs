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
using System.Collections.Generic;
using System.Text;

using iKandi.Web.Components;
using iKandi.Common;
 
namespace iKandi.Web
{
    public partial class PartnerRegistrationForm : BaseUserControl
    {

        #region Properties

        public int PartnerID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["PartnerId"]))
                {
                    return Convert.ToInt32(Request.QueryString["PartnerId"]);
                }

                return -1;
            }
        }

        #endregion

        iKandi.Common.Partner objPartner;
       

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //this.txtPartnerName.Attributes.Add("onchange", "SetLoginId()");
                //this.ddlDeliveryMode.Attributes.Add("onchange", "SetLoginId()");
                PopulatePartnerData();            
                                                           
            }
            txtLogin.Text = txtPartnerName.Text.ToLower().Trim() + "@";
            if (Convert.ToInt32(ddlDeliveryMode.SelectedValue) != -1)
            {
                txtLogin.Text = txtLogin.Text.ToLower().Trim() + ddlDeliveryMode.SelectedItem.Text.ToLower().Trim();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            SavePartner();

        }
        protected void rptPartner_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                DropDownList ddlFunction = (DropDownList)e.Item.FindControl("ddlFunction");
                if (Convert.ToInt32(ddlDeliveryMode.SelectedValue) == (int)PartnerDeliveryMode.FOB)
                {
                    ddlFunction.Enabled = false;
                    ddlFunction.SelectedValue = ((int)PartnerEmailFunction.DELIVERY).ToString();

                }
                else if (Convert.ToInt32(ddlDeliveryMode.SelectedValue) == (int)PartnerDeliveryMode.LANDED && Convert.ToInt32(ddlPartnerType.SelectedValue) != (int)PartnerType.HANGING)
                {
                    ddlFunction.Enabled = false;
                    ddlFunction.SelectedValue = ((int)PartnerEmailFunction.DELIVERY).ToString();

                }
                else
                {
                    ddlFunction.Enabled = true;
                    ddlFunction.SelectedValue = ((int)PartnerEmailFunction.UNKNOWN).ToString();

                }

                if (objPartner != null && objPartner.EmailDetails != null && objPartner.EmailDetails.Count > 0)
                {
                    
                    ((HiddenField)e.Item.FindControl("hdnPartnerEmailID")).Value = objPartner.EmailDetails[e.Item.ItemIndex].PartnerEmailId.ToString();
                    ((TextBox)e.Item.FindControl("txtName")).Text = objPartner.EmailDetails[e.Item.ItemIndex].Name;
                    ((TextBox)e.Item.FindControl("txtEmail")).Text = objPartner.EmailDetails[e.Item.ItemIndex].Email;
                    
                    if(Convert.ToInt32(ddlDeliveryMode.SelectedValue) == (Int32)PartnerDeliveryMode.LANDED && Convert.ToInt32(ddlPartnerType.SelectedValue) != (int)PartnerType.HANGING)
                    {
                        ddlFunction.SelectedValue = ((int)PartnerEmailFunction.DELIVERY).ToString();
                    }
                    else if (Convert.ToInt32(ddlDeliveryMode.SelectedValue) == (Int32)PartnerDeliveryMode.FOB)
                    {

                        ddlFunction.SelectedValue = ((int)PartnerEmailFunction.DELIVERY).ToString();
                    }
                    else
                    {
                        ddlFunction.SelectedValue = ((int)objPartner.EmailDetails[e.Item.ItemIndex].Function).ToString();
                    }
                    ((CheckBox)e.Item.FindControl("chkIsDelete")).Checked = objPartner.EmailDetails[e.Item.ItemIndex].IsDeletedContact;
                }
            }
           
        }


        protected void rptPartner_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddRow")
            {
                objPartner = new Partner();
                objPartner.EmailDetails = new List<PartnerEmail>();
                PartnerEmail  objPartnerEmail = new PartnerEmail();

                foreach (RepeaterItem rptItemAccessory in rptPartner.Items)
                {
                    objPartnerEmail  = new PartnerEmail();
                    if (((HiddenField)rptItemAccessory.FindControl("hdnPartnerEmailID")).Value == "")
                    {
                        objPartnerEmail.PartnerEmailId = -1;
                    }
                    else
                    {
                        objPartnerEmail.PartnerEmailId = Convert.ToInt32(((HiddenField)rptItemAccessory.FindControl("hdnPartnerEmailID")).Value);
                    }
                    objPartnerEmail.PartnerId = PartnerID;
                    objPartnerEmail.Name = ((TextBox)rptItemAccessory.FindControl("txtName")).Text;
                    objPartnerEmail.Email = ((TextBox)rptItemAccessory.FindControl("txtEmail")).Text;
                    objPartnerEmail.Function = (PartnerEmailFunction) Convert.ToInt32(((DropDownList)rptItemAccessory.FindControl("ddlFunction")).SelectedValue);
                    objPartnerEmail.IsDeletedContact = ((CheckBox)rptItemAccessory.FindControl("chkIsDelete")).Checked;
                    objPartner.EmailDetails.Add(objPartnerEmail);
                }

                objPartnerEmail = new PartnerEmail();
                objPartnerEmail.PartnerEmailId = -1;
                objPartnerEmail.PartnerId = PartnerID;
                objPartnerEmail.Name = "";
                objPartnerEmail.Function = PartnerEmailFunction.UNKNOWN;
                objPartnerEmail.IsDeletedContact = false;
                objPartner.EmailDetails.Add(objPartnerEmail);

                
                
                rptPartner.DataSource = objPartner.EmailDetails;
                rptPartner.DataBind();
                
            }

        }

        protected void ddlDeliveryMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetVisibilityforPartnerType();

            if (Convert.ToInt32( ddlDeliveryMode.SelectedValue) == (int)PartnerDeliveryMode.FOB )
            {
                foreach (RepeaterItem item in rptPartner.Items)
                {
                    DropDownList dropDownList = (DropDownList)item.FindControl("ddlFunction");
                    dropDownList.Enabled = false;
                    dropDownList.SelectedValue = ((int)PartnerEmailFunction.DELIVERY).ToString();
                }
            }
            else
            {
                foreach (RepeaterItem item in rptPartner.Items)
                {
                    DropDownList dropDownList = (DropDownList)item.FindControl("ddlFunction");
                    dropDownList.Enabled = true;
                    dropDownList.SelectedValue = ((int)PartnerEmailFunction.UNKNOWN).ToString();
                }
                
            }
        }

        protected void ddlPartnerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddlDeliveryMode.SelectedValue) == (int)PartnerDeliveryMode.LANDED && Convert.ToInt32(ddlPartnerType.SelectedValue) != (int)PartnerType.HANGING )
            {
                foreach (RepeaterItem item in rptPartner.Items)
                {
                    DropDownList dropDownList = (DropDownList)item.FindControl("ddlFunction");
                    dropDownList.Enabled = false;
                    dropDownList.SelectedValue = ((int)PartnerEmailFunction.DELIVERY).ToString();
                }
            }
            else
            {
                foreach (RepeaterItem item in rptPartner.Items)
                {
                    DropDownList dropDownList = (DropDownList)item.FindControl("ddlFunction");
                    dropDownList.Enabled = true;
                    dropDownList.SelectedValue = ((int)PartnerEmailFunction.UNKNOWN).ToString();
                }

            }

        }


        #endregion

        #region Private Methods

       
        private void PopulatePartnerData()
        {
            DropdownHelper.BindClients(lstClients);
            if (PartnerID > 0)
            {
                objPartner = this.PartnerControllerInstance.GetPartner(PartnerID);

                txtPartnerOfficialName.Text = objPartner.PartnerName;
                txtPartnerName.Text = objPartner.PartnerCode;
                txtWebsite.Text = objPartner.Website;
                txtPhone.Text = objPartner.Phone;
                txtEmail.Text = objPartner.Email;

                foreach (PartnerClient partnerClient in objPartner.PartnerClient)
                {
                    lstClients.Items.FindByValue(partnerClient.Client.ClientID.ToString()).Selected = true;
                }
                
                txtAddress.Text = objPartner.Address;
                hiddenUserId.Value = objPartner.UserID.ToString();
                ddlDeliveryMode.SelectedValue = ((int)objPartner.DeliveryMode).ToString();
                ddlPartnerType.SelectedValue = ((int)objPartner.PartnerType).ToString();

                SetVisibilityforPartnerType();

                //txtLogin.Text = objPartner.PartnerCode + "@" + Enum.GetName(typeof(PartnerDeliveryMode), objPartner.DeliveryMode);
                txtLogin.Text = objPartner.PartnerCode + "@" + Enum.GetName(typeof(PartnerDeliveryMode), objPartner.DeliveryMode);

                if (objPartner.EmailDetails != null && objPartner.EmailDetails.Count > 0)
                {
                    rptPartner.DataSource = objPartner.EmailDetails;
                    rptPartner.DataBind();
                }
                else
                {
                    rptPartner.DataSource = "a";  // "a" will work as array collection of one item( This will add one row when there is no row exist in AccessoryWorkingDetail collaction)
                    rptPartner.DataBind();
                }
            }
            else
            {
                rptPartner.DataSource = "a";  // "a" will work as array collection of one item( This will add one row when there is no row exist in AccessoryWorkingDetail collaction)
                rptPartner.DataBind();
            }
        }

        private void SavePartner()
        {

            
            Partner partner = new Partner();

            partner.PartnerName = txtPartnerOfficialName.Text;
            partner.PartnerCode = txtPartnerName.Text;
            partner.Website = txtWebsite.Text;
            partner.Phone = txtPhone.Text;
            partner.Email = txtEmail.Text;
            
            partner.PartnerClient = new System.Collections.Generic.List<PartnerClient>();

            foreach (ListItem item in lstClients.Items)
            {

                if (!item.Selected) continue;

                PartnerClient pc = new PartnerClient();
                pc.Client = new Client();
                pc.Partner = new Partner();
                pc.Partner.PartnerID = PartnerID;
                pc.Client.ClientID = Convert.ToInt32(item.Value);
                
                partner.PartnerClient.Add(pc);
                //this.PartnerControllerInstance.InsertPartnerClient(pc);
            }
            partner.Address = txtAddress.Text;
            partner.DeliveryMode =(PartnerDeliveryMode) Convert.ToInt32(ddlDeliveryMode.SelectedValue);
            if (hiddenUserId.Value != "")
            {
                partner.UserID = Convert.ToInt32(hiddenUserId.Value);
            }
            // To create user
            partner.UserName = txtLogin.Text.ToLower();
            //partner.Password = DateTime.Now.Ticks.ToString(); // To generate password Dynamically
            
            partner.PartnerID = PartnerID;
            partner.PartnerType = (PartnerType) Convert.ToInt32( ddlPartnerType.SelectedValue);

            partner.EmailDetails = new List<PartnerEmail>();
            PartnerEmail objPartnerEmail;

            foreach (RepeaterItem rptItemAccessory in rptPartner.Items)
            {
                objPartnerEmail = new PartnerEmail();

                if (((HiddenField)rptItemAccessory.FindControl("hdnPartnerEmailID")).Value == "")
                {
                    objPartnerEmail.PartnerEmailId = -1;
                }
                else
                {
                    objPartnerEmail.PartnerEmailId = Convert.ToInt32(((HiddenField)rptItemAccessory.FindControl("hdnPartnerEmailID")).Value);
                }

                
                objPartnerEmail.PartnerId = PartnerID;
                objPartnerEmail.Name = ((TextBox)rptItemAccessory.FindControl("txtName")).Text;
                objPartnerEmail.Email = ((TextBox)rptItemAccessory.FindControl("txtEmail")).Text;
                objPartnerEmail.Function = (PartnerEmailFunction) Convert.ToInt32(((DropDownList)rptItemAccessory.FindControl("ddlFunction")).SelectedValue);
                objPartnerEmail.IsDeletedContact = ((CheckBox)rptItemAccessory.FindControl("chkIsDelete")).Checked;
                partner.EmailDetails.Add(objPartnerEmail);
            }
            

            this.PartnerControllerInstance.SavePartner(partner);

            Response.Redirect("~/Internal/Users/PartnerRegistrationListing.aspx");
            pnlMessage.Visible = true;
        }

        private void SetVisibilityforPartnerType()
        {
            if (Convert.ToInt32(ddlDeliveryMode.SelectedValue) == (int)PartnerDeliveryMode.LANDED)
            {
                ddlPartnerType.Visible = true;
                lblPartnerType.Visible = true;
                rfvPartnerType.Visible = true;
            }
            else
            {
                ddlPartnerType.SelectedValue = "-1";
                ddlPartnerType.Visible = false;
                lblPartnerType.Visible = false;
                rfvPartnerType.Visible = false;
            }
        }
        #endregion

       
        

    }
}