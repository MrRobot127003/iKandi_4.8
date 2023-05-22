using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;
using System.Data;

namespace iKandi.Web.Internal
{
    public partial class SupplierQuotationScreen : BasePage
    {
        private string SupplierName;
        private int UserId;
        int SupplyType;
        AccessoryWorkingController objAccessory = new AccessoryWorkingController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            if (!IsPostBack)
            {
                string baseSiteUrl = Constants.BaseSiteUrl.ToUpper().Replace("HTTP://", "").Replace("WWW.", "");
                string siteBaseUrl = Constants.SITE_BASE_URL.ToUpper().Replace("HTTP://", "").Replace("WWW.", "");
                if (baseSiteUrl.Contains(siteBaseUrl))
                {
                    boutiquelogo.ImageUrl = "~/App_Themes/ikandi/images/ikandi.gif";
                }
                else
                {
                    boutiquelogo.ImageUrl = "~/App_Themes/ikandi/images/new-boutique-logo.png";
                }

                if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Supplier)
                {
                    divlog.Visible = true;
                    UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                }
                else
                {
                    //ShowMenubar();
                    UserId = -1;
                    if (!string.IsNullOrEmpty(Request.QueryString["SupplyType"]))
                    {
                        SupplyType = Convert.ToInt32(Request.QueryString["SupplyType"]);
                        hdnSupplyType.Value = SupplyType.ToString();
                    }
                }
                hdnUserId.Value = UserId.ToString();
                if (UserId > 0)
                {
                    DataTable dt = objAccessory.GetSupplier_Type(UserId);
                    if (dt.Rows.Count > 0)
                    {
                        SupplierName = dt.Rows[0]["SupplierName"].ToString();
                        int SupplyType = Convert.ToInt32(dt.Rows[0]["SupplyType"]);
                        lblusername.Text = "Welcome: <b>" + ApplicationHelper.LoggedInUser.UserData.FirstName + " " + ApplicationHelper.LoggedInUser.UserData.LastName + " (" + SupplierName + ")</b>";


                        if (SupplyType == 1 || SupplyType == 0)
                        {
                            tabFabric.Style.Add("display", "");
                            tabFabricStyle.Style.Add("display", "none");
                            tabFabric.Attributes.Add("class", "tabFabricCls Active");
                            dvFabricQuotation.Style.Add("display", "");
                            dvAccessoryQuotation.Style.Add("display", "none");
                            tabFabricStyle.Style.Add("display", "");
                            tabAccessory.Visible = false;
                        }
                        else if (SupplyType == 2)
                        {
                            tabFabric.Style.Add("display", "none");
                            tabFabricStyle.Style.Add("display", "none");
                            tabAccessory.Style.Add("display", "");
                            tabAccessory.Attributes.Add("class", "tabAccessoryCls Active");
                            dvFabricQuotation.Style.Add("display", "none");
                            dvAccessoryQuotation.Style.Add("display", "");
                            dvfabricstylequatation.Style.Add("display", "none");
                            tabFabric.Visible = false;
                        }
                        else if (SupplyType == 3)
                        {
                            tabFabric.Style.Add("display", "none");
                            tabFabricStyle.Style.Add("display", "");
                            tabAccessory.Style.Add("display", "none");
                            tabFabricStyle.Attributes.Add("class", "tabFabricStyleCls Active");
                            dvFabricQuotation.Style.Add("display", "none");
                            dvfabricstylequatation.Style.Add("display", "");
                            dvAccessoryQuotation.Style.Add("display", "none");
                        }
                    }
                }
                else
                {
                    SupplyType = Convert.ToInt32(hdnSupplyType.Value);

                    tabFabric.Attributes.Remove("class");
                    tabFabricStyle.Attributes.Remove("class");
                    tabAccessory.Attributes.Remove("class");

                    tabFabric.Style.Add("display", "");
                    tabFabricStyle.Style.Add("display", "");
                    tabAccessory.Style.Add("display", "");

                    if (SupplyType == 1)
                    {
                        tabFabric.Attributes.Add("class", "tabFabricCls Active");
                        dvFabricQuotation.Style.Add("display", "");
                        dvAccessoryQuotation.Style.Add("display", "none");
                        dvfabricstylequatation.Style.Add("display", "none");
                    }
                    else if (SupplyType == 2)
                    {
                        tabFabricStyle.Attributes.Add("class", "tabFabricStyleCls Active");
                        dvFabricQuotation.Style.Add("display", "none");
                        dvAccessoryQuotation.Style.Add("display", "none");
                        dvfabricstylequatation.Style.Add("display", "");
                    }
                    else if (SupplyType == 3)
                    {
                        tabAccessory.Attributes.Add("class", "tabAccessoryCls Active");
                        dvFabricQuotation.Style.Add("display", "none");
                        dvfabricstylequatation.Style.Add("display", "none");
                        dvAccessoryQuotation.Style.Add("display", "");
                    }
                }
                if (Session["tabs"] != null)
                {
                    SetTab();
                }
                //Session["tabs"] = null;
            }

        }
        public void SetTab()
        {
            //SupplyType = Convert.ToInt32(hdnSupplyType.Value);
            if (Session["tabs"] != null)
            {
                string s = Session["tabs"].ToString();
                tabFabric.Attributes.Remove("class");
                tabFabricStyle.Attributes.Remove("class");
                tabAccessory.Attributes.Remove("class");

                tabFabric.Style.Add("display", "");
                tabFabricStyle.Style.Add("display", "");
                tabAccessory.Style.Add("display", "");

                if (s == "Fabric")
                {
                    tabFabric.Attributes.Add("class", "tabFabricCls Active");
                    dvFabricQuotation.Style.Add("display", "");
                    dvAccessoryQuotation.Style.Add("display", "none");
                    dvfabricstylequatation.Style.Add("display", "none");
                }
                else if (s == "FabricStyle")
                {
                    tabFabricStyle.Attributes.Add("class", "tabFabricStyleCls Active");
                    dvFabricQuotation.Style.Add("display", "none");
                    dvAccessoryQuotation.Style.Add("display", "none");
                    dvfabricstylequatation.Style.Add("display", "");
                    ClientScript.RegisterStartupScript(this.GetType(), "ShowHideSupplierTabAfter", "ShowHideSupplierTabAfter('" + s + "');", true);
                }
                else if (s == "Accessory")
                {
                    tabAccessory.Attributes.Add("class", "tabAccessoryCls Active");
                    dvFabricQuotation.Style.Add("display", "none");
                    dvfabricstylequatation.Style.Add("display", "none");
                    dvAccessoryQuotation.Style.Add("display", "");
                }
            }
        }
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            SupplyType = Convert.ToInt32(hdnSupplyType.Value);
            if (SupplyType == 1)
            {
                Session["tabs"] = "Fabric";
            }
            else if (SupplyType == 2)
            {
                Session["tabs"] = "FabricStyle";
            }
            else if (SupplyType == 3)
            {
                Session["tabs"] = "Accessory";
            }

            Response.Redirect(Request.RawUrl, false);
            //SupplyType = Convert.ToInt32(hdnSupplyType.Value);

            //tabFabric.Attributes.Remove("class");
            //tabFabricStyle.Attributes.Remove("class");
            //tabAccessory.Attributes.Remove("class");

            //tabFabric.Style.Add("display", "");
            //tabFabricStyle.Style.Add("display", "");
            //tabAccessory.Style.Add("display", "");

            //if (SupplyType == 1)
            //{
            //    tabFabric.Attributes.Add("class", "tabFabricCls Active");
            //    dvFabricQuotation.Style.Add("display", "");
            //    dvAccessoryQuotation.Style.Add("display", "none");
            //    dvfabricstylequatation.Style.Add("display", "none");
            //}
            //else if (SupplyType == 2)
            //{
            //    tabFabricStyle.Attributes.Add("class", "tabFabricStyleCls Active");
            //    dvFabricQuotation.Style.Add("display", "none");
            //    dvAccessoryQuotation.Style.Add("display", "none");
            //    dvfabricstylequatation.Style.Add("display", "");
            //}
            //else if (SupplyType == 3)
            //{
            //    tabAccessory.Attributes.Add("class", "tabAccessoryCls Active");
            //    dvFabricQuotation.Style.Add("display", "none");
            //    dvfabricstylequatation.Style.Add("display", "none");
            //    dvAccessoryQuotation.Style.Add("display", "");
            //}

        }
        public void ShowMenubar()
        {
            //Load the control   
            Control _dummyUserControl = (Control)Page.LoadControl("~/UserControls/Forms/TopNavigation.ascx");

            // Add the control to the panel  
            pnlDynamicControl.Controls.Add(_dummyUserControl);
        }
    }
}