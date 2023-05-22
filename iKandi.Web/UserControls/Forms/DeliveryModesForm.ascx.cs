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
using iKandi.Common;
using iKandi.Web.Components;
using iKandi.BLL;



namespace iKandi.Web
{
    public partial class DeliveryModesForm : BaseUserControl
    {
        List<DeliveryMode> DeliveryModeCollection = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControl();
                Bindclinet();
            }
        }
        public void Bindclinet()//Get Client list 
        {
            //DataTable dt=new DataTable();









        }
        private void BindControl()
        {
            DeliveryModeCollection = this.AdminControllerInstance.GetAllDeliveryModes();
            rptModes.DataSource = DeliveryModeCollection;
            rptModes.DataBind();
        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        protected void rptModes_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (DeliveryModeCollection != null && DeliveryModeCollection.Count > 0)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    ((HiddenField)e.Item.FindControl("hdnID")).Value = DeliveryModeCollection[e.Item.ItemIndex].Id.ToString();
                    ((HiddenField)e.Item.FindControl("hdnisdeleting")).Value = DeliveryModeCollection[e.Item.ItemIndex].Id.ToString();
                    //((TextBox)e.Item.FindControl("txtSupply")).Text = Enum.GetName(typeof(SupplyType), Convert.ToInt16(DeliveryModeCollection[e.Item.ItemIndex].SupplyType));
                    //((TextBox)e.Item.FindControl("txtMode")).Text = Enum.GetName(typeof(ModeType), Convert.ToInt16(DeliveryModeCollection[e.Item.ItemIndex].ModeType));
                    //((TextBox)e.Item.FindControl("txtPacking")).Text = Enum.GetName(typeof(PackingType), Convert.ToInt16(DeliveryModeCollection[e.Item.ItemIndex].PackingType));
                    //((TextBox)e.Item.FindControl("txtTerms")).Text = Enum.GetName(typeof(Terms), Convert.ToInt16(DeliveryModeCollection[e.Item.ItemIndex].Terms));
                   // ListBox Listclientname = e.Item.FindControl("Listclientname") as ListBox;
                   // DataSet ds = new DataSet();

                   // ds = this.AdminControllerInstance.GetClientlist();
                    //Listclientname.DataSource = ds.Tables[0];
                    //Listclientname.DataTextField = "clientcode";
                    //Listclientname.DataValueField = "ClientId";
                    //Listclientname.DataBind();
                    //string[] Findbytextvalue = null;
                    //if (Convert.ToString(DeliveryModeCollection[e.Item.ItemIndex].ClientMapping) != "" && Convert.ToString(DeliveryModeCollection[e.Item.ItemIndex].ClientMapping) != null)
                    //{
                    //    Findbytextvalue = Convert.ToString(DeliveryModeCollection[e.Item.ItemIndex].ClientMapping).Split(',');
                    //    for (int i = 0; i < Findbytextvalue.Length - 1; i++)
                    //    {

                    //        string value = Listclientname.Items[i].Value;
                    //        bool checkexist = false;

                    //        foreach (ListItem itm in Listclientname.Items)
                    //        {
                    //            if (itm.Value == Findbytextvalue[i])
                    //            {
                    //                checkexist = true;
                    //                break;
                    //            }
                    //            else
                    //            {
                    //                checkexist = false;
                    //            }

                    //        }

                    //        if (!string.IsNullOrEmpty(Findbytextvalue[i]) && checkexist == true)
                    //        {
                    //            Listclientname.Items.FindByValue(Convert.ToString(Findbytextvalue[i])).Selected = true;
                    //        }


                    //    }
                    //}

                    ((DropDownList)e.Item.FindControl("ddlSupply")).SelectedValue = (Convert.ToInt16(Enum.Parse(typeof(SupplyType), DeliveryModeCollection[e.Item.ItemIndex].SupplyType.ToString()))).ToString();
                    ((DropDownList)e.Item.FindControl("ddlMode")).SelectedValue = (Convert.ToInt16(Enum.Parse(typeof(ModeType), DeliveryModeCollection[e.Item.ItemIndex].ModeType.ToString()))).ToString();
                    ((DropDownList)e.Item.FindControl("ddlPacking")).SelectedValue = (Convert.ToInt16(Enum.Parse(typeof(PackingType), DeliveryModeCollection[e.Item.ItemIndex].PackingType.ToString()))).ToString();
                    ((DropDownList)e.Item.FindControl("ddlTerms")).SelectedValue = (Convert.ToInt16(Enum.Parse(typeof(Terms), DeliveryModeCollection[e.Item.ItemIndex].Terms.ToString()))).ToString();

                    DropDownList ddlTypeOfPacking = e.Item.FindControl("ddlTypeOfPacking") as DropDownList;
                    DropdownHelper.BindAllOrderTypeOfPacking(ddlTypeOfPacking as ListControl);
                    ddlTypeOfPacking.SelectedValue = DeliveryModeCollection[e.Item.ItemIndex].OrderPackingType.ToString();

                    ((TextBox)e.Item.FindControl("txtCode")).Text = DeliveryModeCollection[e.Item.ItemIndex].Code.ToString();
                    ((TextBox)e.Item.FindControl("txtSystemdcex")).Text = DeliveryModeCollection[e.Item.ItemIndex].SystemExDC.ToString();
                    ((TextBox)e.Item.FindControl("txtActualdcex")).Text = DeliveryModeCollection[e.Item.ItemIndex].ActualExDC.ToString();
                    ((TextBox)e.Item.FindControl("txtGreenStart")).Text = DeliveryModeCollection[e.Item.ItemIndex].GreenRangeStart.ToString();
                    ((TextBox)e.Item.FindControl("txtAmberStart")).Text = DeliveryModeCollection[e.Item.ItemIndex].AmberRangeStart.ToString();
                    ((TextBox)e.Item.FindControl("txtRedStart")).Text = DeliveryModeCollection[e.Item.ItemIndex].RedRangeStart.ToString();
                    ((TextBox)e.Item.FindControl("txtGreenEnd")).Text = DeliveryModeCollection[e.Item.ItemIndex].GreenRangeEnd.ToString();
                    ((TextBox)e.Item.FindControl("txtAmberEnd")).Text = DeliveryModeCollection[e.Item.ItemIndex].AmberRangeEnd.ToString();
                    ((TextBox)e.Item.FindControl("txtRedEnd")).Text = DeliveryModeCollection[e.Item.ItemIndex].RedRangeEnd.ToString();
                    ((TextBox)e.Item.FindControl("txtTooltip")).Text = DeliveryModeCollection[e.Item.ItemIndex].ToolTip.ToString();
                    ((TextBox)e.Item.FindControl("txtColor")).Text = DeliveryModeCollection[e.Item.ItemIndex].Color.ToString();
                    ((TextBox)e.Item.FindControl("txtLeadTime")).Text = DeliveryModeCollection[e.Item.ItemIndex].LeadTime.ToString();

                    // Added By Yadvendra on 22/10/2019
                    if (DeliveryModeCollection[e.Item.ItemIndex].USSystemEXDC != 0)
                        ((TextBox)e.Item.FindControl("txtUSSystemEXDC")).Text = DeliveryModeCollection[e.Item.ItemIndex].USSystemEXDC.ToString();

                    if (DeliveryModeCollection[e.Item.ItemIndex].USLeadTime != 0)
                        ((TextBox)e.Item.FindControl("txtUSLeadTime")).Text = DeliveryModeCollection[e.Item.ItemIndex].USLeadTime.ToString();

                    if (DeliveryModeCollection[e.Item.ItemIndex].BLSystemEXDC != 0)
                        ((TextBox)e.Item.FindControl("txtBLSystemEXDC")).Text = DeliveryModeCollection[e.Item.ItemIndex].BLSystemEXDC.ToString();

                    if (DeliveryModeCollection[e.Item.ItemIndex].BLLeadTime != 0)
                        ((TextBox)e.Item.FindControl("txtBLLeadTime")).Text = DeliveryModeCollection[e.Item.ItemIndex].BLLeadTime.ToString();
                    //
                    // Added By Bharat on 06/12/2019
                    if (DeliveryModeCollection[e.Item.ItemIndex].PLSystemEXDC != 0)
                        ((TextBox)e.Item.FindControl("txtPLSystemEXDC")).Text = DeliveryModeCollection[e.Item.ItemIndex].PLSystemEXDC.ToString();

                    if (DeliveryModeCollection[e.Item.ItemIndex].PLLeadTime != 0)
                        ((TextBox)e.Item.FindControl("txtPLLeadTime")).Text = DeliveryModeCollection[e.Item.ItemIndex].PLLeadTime.ToString();

                    if (DeliveryModeCollection[e.Item.ItemIndex].KRSystemEXDC != 0)
                        ((TextBox)e.Item.FindControl("txtKRSystemEXDC")).Text = DeliveryModeCollection[e.Item.ItemIndex].KRSystemEXDC.ToString();

                    if (DeliveryModeCollection[e.Item.ItemIndex].KRLeadTime != 0)
                        ((TextBox)e.Item.FindControl("txtKRLeadTime")).Text = DeliveryModeCollection[e.Item.ItemIndex].KRLeadTime.ToString();

                    if (DeliveryModeCollection[e.Item.ItemIndex].RKSystemEXDC != 0)
                        ((TextBox)e.Item.FindControl("txtRKSystemEXDC")).Text = DeliveryModeCollection[e.Item.ItemIndex].RKSystemEXDC.ToString();

                    if (DeliveryModeCollection[e.Item.ItemIndex].RKLeadTime != 0)
                        ((TextBox)e.Item.FindControl("txtRKLeadTime")).Text = DeliveryModeCollection[e.Item.ItemIndex].RKLeadTime.ToString();
                    //

                    if (DeliveryModeCollection[e.Item.ItemIndex].INSystemEXDC != 0)
                        ((TextBox)e.Item.FindControl("txtINSystemEXDC")).Text = DeliveryModeCollection[e.Item.ItemIndex].INSystemEXDC.ToString();

                    if (DeliveryModeCollection[e.Item.ItemIndex].INLeadTime != 0)
                        ((TextBox)e.Item.FindControl("txtINLeadTime")).Text = DeliveryModeCollection[e.Item.ItemIndex].INLeadTime.ToString();
                    if (DeliveryModeCollection[e.Item.ItemIndex].NSSystemEXDC != 0)
                        ((TextBox)e.Item.FindControl("txtNSSystemEXDC")).Text = DeliveryModeCollection[e.Item.ItemIndex].NSSystemEXDC.ToString();

                    if (DeliveryModeCollection[e.Item.ItemIndex].NSLeadTime != 0)
                        ((TextBox)e.Item.FindControl("txtNSLeadTime")).Text = DeliveryModeCollection[e.Item.ItemIndex].NSLeadTime.ToString();


                    ((CheckBox)e.Item.FindControl("chkDelete")).Checked = (DeliveryModeCollection[e.Item.ItemIndex].IsVisible == 1);
                    ((TextBox)e.Item.FindControl("txtSystemdcex")).Attributes.Add("onchange", "javascript:ValidateLeadTime(this)");
                    ((TextBox)e.Item.FindControl("txtActualdcex")).Attributes.Add("onchange", "javascript:ValidateLeadTime(this)");
                    ((TextBox)e.Item.FindControl("txtLeadTime")).Attributes.Add("onchange", "javascript:ValidateLeadTime(this)");

                    // Added By Yadvendra on 22/10/2019
                    ((TextBox)e.Item.FindControl("txtUSSystemEXDC")).Attributes.Add("onchange", "javascript:ValidateLeadTime(this)");
                    ((TextBox)e.Item.FindControl("txtUSLeadTime")).Attributes.Add("onchange", "javascript:ValidateLeadTime(this)");
                    ((TextBox)e.Item.FindControl("txtBLSystemEXDC")).Attributes.Add("onchange", "javascript:ValidateLeadTime(this)");

                    ((TextBox)e.Item.FindControl("txtBLLeadTime")).Attributes.Add("onchange", "javascript:ValidateLeadTime(this)");
                    ((TextBox)e.Item.FindControl("txtPLSystemEXDC")).Attributes.Add("onchange", "javascript:ValidateLeadTime(this)");
                    ((TextBox)e.Item.FindControl("txtPLLeadTime")).Attributes.Add("onchange", "javascript:ValidateLeadTime(this)");

                    ((TextBox)e.Item.FindControl("txtKRSystemEXDC")).Attributes.Add("onchange", "javascript:ValidateLeadTime(this)");
                    ((TextBox)e.Item.FindControl("txtKRLeadTime")).Attributes.Add("onchange", "javascript:ValidateLeadTime(this)");
                    ((TextBox)e.Item.FindControl("txtRKSystemEXDC")).Attributes.Add("onchange", "javascript:ValidateLeadTime(this)");
                    ((TextBox)e.Item.FindControl("txtRKLeadTime")).Attributes.Add("onchange", "javascript:ValidateLeadTime(this)");
                    //
                    ((TextBox)e.Item.FindControl("txtINSystemEXDC")).Attributes.Add("onchange", "javascript:ValidateLeadTime(this)");
                    ((TextBox)e.Item.FindControl("txtINLeadTime")).Attributes.Add("onchange", "javascript:ValidateLeadTime(this)");
                    
                    ((TextBox)e.Item.FindControl("txtNSSystemEXDC")).Attributes.Add("onchange", "javascript:ValidateLeadTime(this)");
                    ((TextBox)e.Item.FindControl("txtNSLeadTime")).Attributes.Add("onchange", "javascript:ValidateLeadTime(this)");



                    string DeliveryDays = DeliveryModeCollection[e.Item.ItemIndex].Days.ToString();
                    string IsDeleteing = "";
                    if (DeliveryModeCollection[e.Item.ItemIndex].IsDeleteing == null)
                    {
                        IsDeleteing = "";
                    }
                    else
                    {
                        IsDeleteing = DeliveryModeCollection[e.Item.ItemIndex].IsDeleteing.ToString();
                    }

                    LinkButton lnkDelete = e.Item.FindControl("lnkDelete") as LinkButton;
                    lnkDelete.Visible = false;
                    if (IsDeleteing == "")
                    {
                        lnkDelete.Visible = true; ;
                    }

                    string[] con = DeliveryDays.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);


                    foreach (string a in con)
                    {
                        foreach (System.Web.UI.WebControls.ListItem item in ((CheckBoxList)e.Item.FindControl("ckhdays")).Items)
                        {
                            if (item.Value == a)
                            {
                                item.Selected = true;
                                //item.Enabled = false;
                            }
                        }
                    }
                }
            }
        }

        protected void rptModes_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddRow")
            {
                DeliveryModeCollection = new List<DeliveryMode>();
                DeliveryMode DeliveryMode = new DeliveryMode();

                foreach (RepeaterItem rpt in rptModes.Items)
                {
                    DeliveryMode = new DeliveryMode();
                    DeliveryMode.Id = Convert.ToInt32(((HiddenField)rpt.FindControl("hdnID")).Value);
                    DeliveryMode.IsDeleteing = Convert.ToString(((HiddenField)rpt.FindControl("hdnisdeleting")).Value);
                    //DeliveryMode.SupplyType = Convert.ToInt16(Enum.Parse(SupplyType.DIRECT_EX_FACTORY.GetType(), ((TextBox)rpt.FindControl("txtSupply")).Text));
                    //DeliveryMode.ModeType = Convert.ToInt16(Enum.Parse(ModeType.AIR.GetType(), ((TextBox)rpt.FindControl("txtMode")).Text));
                    //DeliveryMode.PackingType = Convert.ToInt16(Enum.Parse(PackingType.BOX_HANGING.GetType(), ((TextBox)rpt.FindControl("txtPacking")).Text));
                    //DeliveryMode.Terms = Convert.ToInt16(Enum.Parse(Terms.CIF.GetType(), ((TextBox)rpt.FindControl("txtTerms")).Text));

                    DeliveryMode.SupplyType = (SupplyType)Convert.ToInt32(((DropDownList)rpt.FindControl("ddlSupply")).SelectedValue);
                    DeliveryMode.ModeType = (ModeType)Convert.ToInt32(((DropDownList)rpt.FindControl("ddlMode")).SelectedValue);
                    DeliveryMode.PackingType = (PackingType)Convert.ToInt32(((DropDownList)rpt.FindControl("ddlPacking")).SelectedValue);
                    DeliveryMode.Terms = (Terms)Convert.ToInt32(((DropDownList)rpt.FindControl("ddlTerms")).SelectedValue);
                    DeliveryMode.OrderPackingType = Convert.ToInt32(((DropDownList)rpt.FindControl("ddlTypeOfPacking")).SelectedValue);

                    DeliveryMode.Code = ((TextBox)rpt.FindControl("txtCode")).Text;
                    if (Convert.ToInt32(((TextBox)rpt.FindControl("txtSystemdcex")).Text) <= 0)
                    {
                        ((TextBox)rpt.FindControl("txtSystemdcex")).Text = "1";
                    }
                    DeliveryMode.SystemExDC = Convert.ToInt32(((TextBox)rpt.FindControl("txtSystemdcex")).Text);
                    if (Convert.ToInt32(((TextBox)rpt.FindControl("txtActualdcex")).Text) <= 0)
                    {
                        ((TextBox)rpt.FindControl("txtActualdcex")).Text = "1";
                    }
                    DeliveryMode.ActualExDC = Convert.ToInt32(((TextBox)rpt.FindControl("txtActualdcex")).Text);

                    DeliveryMode.GreenRangeStart = Convert.ToInt16(((TextBox)rpt.FindControl("txtGreenStart")).Text);
                    DeliveryMode.GreenRangeEnd = Convert.ToInt16(((TextBox)rpt.FindControl("txtGreenEnd")).Text);


                    DeliveryMode.AmberRangeStart = Convert.ToInt16(((TextBox)rpt.FindControl("txtAmberStart")).Text);
                    DeliveryMode.AmberRangeEnd = Convert.ToInt16(((TextBox)rpt.FindControl("txtAmberEnd")).Text);

                    DeliveryMode.RedRangeStart = Convert.ToInt16(((TextBox)rpt.FindControl("txtRedStart")).Text);
                    DeliveryMode.RedRangeEnd = Convert.ToInt16(((TextBox)rpt.FindControl("txtRedEnd")).Text);

                    if (((TextBox)rpt.FindControl("txtUSSystemEXDC")).Text != "")
                    {
                        DeliveryMode.USSystemEXDC = Convert.ToInt32(((TextBox)rpt.FindControl("txtUSSystemEXDC")).Text);
                    }

                    if (((TextBox)rpt.FindControl("txtUSLeadTime")).Text != "")
                    {
                        DeliveryMode.USLeadTime = Convert.ToInt32(((TextBox)rpt.FindControl("txtUSLeadTime")).Text);
                    }
                    if (((TextBox)rpt.FindControl("txtBLSystemEXDC")).Text != "")
                    {
                        DeliveryMode.BLSystemEXDC = Convert.ToInt32(((TextBox)rpt.FindControl("txtBLSystemEXDC")).Text);
                    }

                    if (((TextBox)rpt.FindControl("txtBLLeadTime")).Text != "")
                    {
                        DeliveryMode.BLLeadTime = Convert.ToInt32(((TextBox)rpt.FindControl("txtBLLeadTime")).Text);
                    }

                    if (((TextBox)rpt.FindControl("txtPLSystemEXDC")).Text != "")
                    {
                        DeliveryMode.PLSystemEXDC = Convert.ToInt32(((TextBox)rpt.FindControl("txtPLSystemEXDC")).Text);
                    }

                    if (((TextBox)rpt.FindControl("txtPLLeadTime")).Text != "")
                    {
                        DeliveryMode.PLLeadTime = Convert.ToInt32(((TextBox)rpt.FindControl("txtPLLeadTime")).Text);
                    }

                    if (((TextBox)rpt.FindControl("txtKRSystemEXDC")).Text != "")
                    {
                        DeliveryMode.KRSystemEXDC = Convert.ToInt32(((TextBox)rpt.FindControl("txtKRSystemEXDC")).Text);
                    }

                    if (((TextBox)rpt.FindControl("txtKRLeadTime")).Text != "")
                    {
                        DeliveryMode.KRLeadTime = Convert.ToInt32(((TextBox)rpt.FindControl("txtKRLeadTime")).Text);
                    }

                    if (((TextBox)rpt.FindControl("txtRKSystemEXDC")).Text != "")
                    {
                        DeliveryMode.RKSystemEXDC = Convert.ToInt32(((TextBox)rpt.FindControl("txtRKSystemEXDC")).Text);
                    }

                    if (((TextBox)rpt.FindControl("txtRKLeadTime")).Text != "")
                    {
                        DeliveryMode.RKLeadTime = Convert.ToInt32(((TextBox)rpt.FindControl("txtRKLeadTime")).Text);
                    }

                   
                    if (((TextBox)rpt.FindControl("txtINSystemEXDC")).Text != "")
                    {
                        DeliveryMode.INSystemEXDC = Convert.ToInt32(((TextBox)rpt.FindControl("txtINSystemEXDC")).Text);
                    }
                    if (((TextBox)rpt.FindControl("txtINLeadTime")).Text != "")
                    {
                        DeliveryMode.INLeadTime = Convert.ToInt32(((TextBox)rpt.FindControl("txtINLeadTime")).Text);
                    }

                    if (((TextBox)rpt.FindControl("txtNSSystemEXDC")).Text != "")
                    {
                        DeliveryMode.NSSystemEXDC = Convert.ToInt32(((TextBox)rpt.FindControl("txtNSSystemEXDC")).Text);
                    }
                    if (((TextBox)rpt.FindControl("txtNSLeadTime")).Text != "")
                    {
                        DeliveryMode.NSLeadTime = Convert.ToInt32(((TextBox)rpt.FindControl("txtNSLeadTime")).Text);
                    }
                    CheckBoxList ckhdays = (CheckBoxList)rpt.FindControl("ckhdays");
                    string selected = string.Empty;

                    foreach (ListItem li in ckhdays.Items)
                    {
                        if (li.Selected)
                        {
                            selected += li.Value + ",";
                        }
                    }
                    if (selected == "")
                    {
                        selected = "1";
                    }
                    DeliveryMode.Days = selected;

                    if (Convert.ToInt32(((TextBox)rpt.FindControl("txtLeadTime")).Text) <= 0)
                    {
                        ((TextBox)rpt.FindControl("txtLeadTime")).Text = "1";
                    }
                    DeliveryMode.LeadTime = Convert.ToInt32(((TextBox)rpt.FindControl("txtLeadTime")).Text);

                    DeliveryMode.ToolTip = ((TextBox)rpt.FindControl("txtTooltip")).Text;

                    DeliveryMode.Color = ((TextBox)rpt.FindControl("txtColor")).Text;

                    if (((CheckBox)rpt.FindControl("chkDelete")).Checked)
                    {
                        DeliveryMode.IsVisible = 1;
                    }


                    DeliveryModeCollection.Add(DeliveryMode);
                }

                DeliveryMode = new DeliveryMode();
                DeliveryMode.Id = -1;

                DeliveryMode.SupplyType = SupplyType.LANDED;
                DeliveryMode.ModeType = ModeType.AIR;
                DeliveryMode.PackingType = PackingType.HANGING;
                DeliveryMode.Terms = Terms.FOB;
                DeliveryMode.OrderPackingType = 1;
                DeliveryMode.SystemExDC = 1;
                DeliveryMode.ActualExDC = 1;

                DeliveryMode.GreenRangeStart = 0;
                DeliveryMode.GreenRangeEnd = 0;

                DeliveryMode.AmberRangeStart = 0;
                DeliveryMode.AmberRangeEnd = 0;
                DeliveryMode.Days = "0";
                DeliveryMode.RedRangeStart = 0;
                DeliveryMode.RedRangeEnd = 0;

                DeliveryMode.LeadTime = 1;
                DeliveryMode.Code = "";
                DeliveryMode.ToolTip = "";
                DeliveryMode.USSystemEXDC = 0;
                DeliveryMode.USLeadTime = 0;
                DeliveryMode.BLSystemEXDC = 0;
                DeliveryMode.BLLeadTime = 0;
                DeliveryMode.PLSystemEXDC = 0;
                DeliveryMode.PLLeadTime = 0;
                
                DeliveryMode.KRSystemEXDC = 0;
                DeliveryMode.KRLeadTime = 0;
                DeliveryMode.RKSystemEXDC = 0;
                DeliveryMode.RKLeadTime = 0;

                DeliveryMode.Color = "";
                DeliveryMode.IsVisible = 1;
                DeliveryMode.IsDeleteing = "";

                DeliveryModeCollection.Add(DeliveryMode);

                rptModes.DataSource = DeliveryModeCollection;
                rptModes.DataBind();

                RepeaterItem rptItem = rptModes.Items[rptModes.Items.Count - 1];
                LinkButton ddlOperator = (LinkButton)rptItem.FindControl("lnkDelete");
                ddlOperator.Focus();

            }
            if (e.CommandName == "Delete")
            {

                LinkButton lnkDelete = (LinkButton)e.Item.FindControl("lnkDelete");
                HiddenField hdnID = (HiddenField)e.Item.FindControl("hdnID");
                int a = this.AdminControllerInstance.UpdateDeliveryModesdelete(Convert.ToInt32(hdnID.Value));
                if (a == 0)
                {
                    ShowAlert("This mode is mapped can't delete");

                }
                else
                {

                    Response.Redirect(Request.RawUrl);
                }
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            BLLCache.ClearDeliverModesCache();

            SaveDeliveryModeDetails();

        }

        private void SaveDeliveryModeDetails()
        {

            DeliveryModeCollection = new List<DeliveryMode>();
            foreach (RepeaterItem rpt in rptModes.Items)
            {
                string RangeVal = string.Empty;
                DeliveryMode DeliveryMode = new DeliveryMode();
                DeliveryMode.Id = Convert.ToInt32(((HiddenField)rpt.FindControl("hdnID")).Value);

                DeliveryMode.SupplyType = (SupplyType)Convert.ToInt32(((DropDownList)rpt.FindControl("ddlSupply")).SelectedValue);
                DeliveryMode.ModeType = (ModeType)Convert.ToInt32(((DropDownList)rpt.FindControl("ddlMode")).SelectedValue);
                DeliveryMode.PackingType = (PackingType)Convert.ToInt32(((DropDownList)rpt.FindControl("ddlPacking")).SelectedValue);
                DeliveryMode.Terms = (Terms)Convert.ToInt32(((DropDownList)rpt.FindControl("ddlTerms")).SelectedValue);
                DeliveryMode.OrderPackingType = Convert.ToInt32(((DropDownList)rpt.FindControl("ddlTypeOfPacking")).SelectedValue);

                DeliveryMode.Code = ((TextBox)rpt.FindControl("txtCode")).Text;
                DeliveryMode.SystemExDC = Convert.ToInt32(((TextBox)rpt.FindControl("txtSystemdcex")).Text);
                DeliveryMode.ActualExDC = Convert.ToInt32(((TextBox)rpt.FindControl("txtActualdcex")).Text);

                RangeVal = ((TextBox)rpt.FindControl("txtGreenStart")).Text;
                DeliveryMode.GreenRangeStart = Convert.ToInt16((RangeVal == "-" || RangeVal == "") ? "0" : RangeVal);

                RangeVal = ((TextBox)rpt.FindControl("txtGreenEnd")).Text;
                DeliveryMode.GreenRangeEnd = Convert.ToInt16((RangeVal == "-" || RangeVal == "") ? "0" : RangeVal);

                RangeVal = ((TextBox)rpt.FindControl("txtAmberStart")).Text;
                DeliveryMode.AmberRangeStart = Convert.ToInt16((RangeVal == "-" || RangeVal == "") ? "0" : RangeVal);

                RangeVal = ((TextBox)rpt.FindControl("txtAmberEnd")).Text;
                DeliveryMode.AmberRangeEnd = Convert.ToInt16((RangeVal == "-" || RangeVal == "") ? "0" : RangeVal);

                RangeVal = ((TextBox)rpt.FindControl("txtRedStart")).Text;
                DeliveryMode.RedRangeStart = Convert.ToInt16((RangeVal == "-" || RangeVal == "") ? "0" : RangeVal);

                RangeVal = ((TextBox)rpt.FindControl("txtRedEnd")).Text;
                DeliveryMode.RedRangeEnd = Convert.ToInt16((RangeVal == "-" || RangeVal == "") ? "0" : RangeVal);

                DeliveryMode.LeadTime = Convert.ToInt32(((TextBox)rpt.FindControl("txtLeadTime")).Text);

                // Added By Yadvendra on 22/10/2019
                if (((TextBox)rpt.FindControl("txtUSSystemEXDC")).Text != "")
                    DeliveryMode.USSystemEXDC = Convert.ToInt32(((TextBox)rpt.FindControl("txtUSSystemEXDC")).Text);
                if (((TextBox)rpt.FindControl("txtUSLeadTime")).Text != "")
                    DeliveryMode.USLeadTime = Convert.ToInt32(((TextBox)rpt.FindControl("txtUSLeadTime")).Text);
                if (((TextBox)rpt.FindControl("txtBLSystemEXDC")).Text != "")
                    DeliveryMode.BLSystemEXDC = Convert.ToInt32(((TextBox)rpt.FindControl("txtBLSystemEXDC")).Text);
                if (((TextBox)rpt.FindControl("txtBLLeadTime")).Text != "")
                    DeliveryMode.BLLeadTime = Convert.ToInt32(((TextBox)rpt.FindControl("txtBLLeadTime")).Text);
                //
                // Added By Yadvendra on 22/10/2019
                if (((TextBox)rpt.FindControl("txtPLSystemEXDC")).Text != "")
                    DeliveryMode.PLSystemEXDC = Convert.ToInt32(((TextBox)rpt.FindControl("txtPLSystemEXDC")).Text);
                if (((TextBox)rpt.FindControl("txtPLLeadTime")).Text != "")
                    DeliveryMode.PLLeadTime = Convert.ToInt32(((TextBox)rpt.FindControl("txtPLLeadTime")).Text);
                if (((TextBox)rpt.FindControl("txtKRSystemEXDC")).Text != "")
                    DeliveryMode.KRSystemEXDC = Convert.ToInt32(((TextBox)rpt.FindControl("txtKRSystemEXDC")).Text);
                if (((TextBox)rpt.FindControl("txtKRLeadTime")).Text != "")
                    DeliveryMode.KRLeadTime = Convert.ToInt32(((TextBox)rpt.FindControl("txtKRLeadTime")).Text);

                if (((TextBox)rpt.FindControl("txtRKSystemEXDC")).Text != "")
                    DeliveryMode.RKSystemEXDC = Convert.ToInt32(((TextBox)rpt.FindControl("txtRKSystemEXDC")).Text);
                if (((TextBox)rpt.FindControl("txtRKLeadTime")).Text != "")
                    DeliveryMode.RKLeadTime = Convert.ToInt32(((TextBox)rpt.FindControl("txtRKLeadTime")).Text);

                // Added By abhishek on 4 june 2021
                if (((TextBox)rpt.FindControl("txtINSystemEXDC")).Text != "")
                    DeliveryMode.INSystemEXDC = Convert.ToInt32(((TextBox)rpt.FindControl("txtINSystemEXDC")).Text);
                if (((TextBox)rpt.FindControl("txtINLeadTime")).Text != "")
                    DeliveryMode.INLeadTime = Convert.ToInt32(((TextBox)rpt.FindControl("txtINLeadTime")).Text);
                // Added by shubhendu 13 dec 21
                if (((TextBox)rpt.FindControl("txtNSSystemEXDC")).Text != "")
                    DeliveryMode.NSSystemEXDC = Convert.ToInt32(((TextBox)rpt.FindControl("txtNSSystemEXDC")).Text);
                if (((TextBox)rpt.FindControl("txtNSLeadTime")).Text != "")
                    DeliveryMode.NSLeadTime = Convert.ToInt32(((TextBox)rpt.FindControl("txtNSLeadTime")).Text);

                //
                //
                DeliveryMode.ToolTip = ((TextBox)rpt.FindControl("txtTooltip")).Text;
                DeliveryMode.Color = ((TextBox)rpt.FindControl("txtColor")).Text;

                if (((CheckBox)rpt.FindControl("chkDelete")).Checked)
                {
                    DeliveryMode.IsVisible = 1;
                }
                else
                {
                    DeliveryMode.IsVisible = 0;
                }
                CheckBoxList ckhdays = (CheckBoxList)rpt.FindControl("ckhdays");
                string selected = string.Empty;

                foreach (ListItem li in ckhdays.Items)
                {
                    if (li.Selected)
                    {
                        selected += li.Value + ",";
                    }
                }
                DeliveryMode.Days = selected;
                //string Chklist = string.Empty;
                //ListBox Listclientname = (ListBox)rpt.FindControl("Listclientname");

                //if (Listclientname.Items.Count > 0)
                //{
                //    for (int i = 0; i < Listclientname.Items.Count; i++)
                //    {
                //        if (Listclientname.Items[i].Selected)
                //        {
                //            Chklist = Chklist + Listclientname.Items[i].Value + ",";

                //        }
                //    }
                //}
                //DeliveryMode.ClientMapping = Chklist;

                DeliveryModeCollection.Add(DeliveryMode);
            }
            
            string message = string.Empty;


            this.AdminControllerInstance.UpdateModes(DeliveryModeCollection, ref message);
            if (message != "")
            {
                ShowAlert(message);
                return;
            }

            BindControl();

        }
    }
}