using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;

namespace iKandi.Web
{
    public partial class ClientView : BaseUserControl
    {
        int clientId = -1;
        #region Properties
        public int ClientId {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ClientId"]))
                {
                    return Convert.ToInt32(Request.QueryString["ClientId"]);
                }
                return -1;
            }
            set
            {
                clientId = value;
            }
        }
       # endregion    

        protected void Page_Load(object sender, EventArgs e)
        {

            if (clientId != -1)
            {
                BindControls();
            }
        }
        private void BindControls() 
        {
           // System.Diagnostics.Debugger.Break();

            Client client = this.ClientControllerInstance.GetClientViewById(clientId);
           lbl_com_name.Text = client.CompanyName + " / " + client.BuyingHouseName;
           lbl_clnt_snce.Text = client.ClientSince == DateTime.MinValue ? "" : client.ClientSince.ToString("dd MMM yy (DDD)");
            lbl_clnt_wbsite.Text = client.Website;
            lbl_addrs.Text = client.Address;
            lbl_phn.Text = client.Phone;
            lbl_clnt_code.Text = client.ClientCode;
            lbl_email.Text = client.Email;
            lbl_aql_stdrd.Text = Convert.ToString(client.Aql);
            if (client.IsMDARequired > 0)
            {
                lbl_mda_reqrd.Text = "Y";
            }
            else
            {
                lbl_mda_reqrd.Text = "N";
            }
            lbl_dscount.Text = Convert.ToString(client.Discount);
            lbl_paymnt_trms.Text = Convert.ToString(client.PaymentTerms);
            lbl_oficial_name.Text = Convert.ToString(client.OfficialName);
            lbl_bllng_addrs.Text = client.BillingAddess;
           
            repeater_department.DataSource =client.Departments;
             repeater_department.DataBind();
            
        //// client.Departments   = this.ClientControllerInstance.GetClientDeptsByClientID(Convert.ToInt32(Request.QueryString["ClientId"]));
        //    for (int i = 0;i < client.Departments.Count; i++)
        //    {
        //        lbl_deprtmt.Text = client.Departments[i].Name;
        //        lbl_usrname.Text = client.Departments[i].Username;
        //        lbl_mon.Text = Convert.ToString(client.Departments[i].Mon);
        //        lbl_tue.Text = Convert.ToString(client.Departments[i].Tue);
        //        lbl_wed.Text = Convert.ToString(client.Departments[i].Wed);
        //        lbl_thu.Text = Convert.ToString(client.Departments[i].Thu);
        //        lbl_fri.Text = Convert.ToString(client.Departments[i].Fri);
        //        lbl_sales.Text = client.Departments[i].SalesManagerIDs;
        //        lbl_desgner.Text = client.Departments[i].DesignerIDs;
        //        lbl_acc_manager.Text = client.Departments[i].AccountManagerIDs;
        //        lbl_technolgst.Text = client.Departments[i].TechnologistIDs;
        //        lbl_shippng_mngr.Text = client.Departments[i].ShippingManagerIDs;
        //        lbl_delvry_mngr.Text = client.Departments[i].DeliveryManagerIDs;
        //        lbl_fit_merchant.Text = client.Departments[i].FITMerchantIDs;
        //        lbl_smplng_merchat.Text = client.Departments[i].SamplingMerchantIDs;
        //    }
            
            //for (int i = 0; i < client.Contacts.Count; i++)
            //{
            //    lbl_name.Text = client.Contacts[i].Name;
            //    lbl_email1.Text = client.Contacts[i].Email;
            //    lbl_phone.Text = client.Contacts[i].Phone;
            //}

            if (client.Contacts.Count == 0)
            {
                pnlEx.CssClass = "hide_me";
            }
           
            repeater_extrnl_assignment.DataSource = client.Contacts;
            repeater_extrnl_assignment.DataBind();


        }
    }
}