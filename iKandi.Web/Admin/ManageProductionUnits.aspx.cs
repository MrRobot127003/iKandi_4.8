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
using iKandi.Common;
using iKandi.Web.Components;
using iKandi.BLL;
using System.IO;

//using System.Globalization;
//using System.Web.Hosting;


namespace iKandi.Web.Internal.Merchandising
{
    public partial class ManageProductionUnits : BasePage
    {
        #region Constants



        #endregion

        #region Properties

        private int ProductionUnitId
        {
            get
            {
                if (null != ViewState["puid"])
                {
                    int puid = 0;
                    int.TryParse(ViewState["puid"].ToString(), out puid);

                    if (puid > 0)
                        return puid;
                }

                return -1;
            }
            set
            {
                ViewState["puid"] = value;
            }
        }
        AdminController objAdminController = new AdminController();
        PrintController objprintController = new PrintController();
        DataTable dtFactoryUnit = new DataTable();
        DataTable  dtuserall = new DataTable();

        private ProductionUnitCollection ProductionUnits
        {
            get
            {
                if (null == Session["producitonUnits"])
                    Session["producitonUnits"] = this.AllocationControllerInstance.GetProductionUnits("%%");

                return (ProductionUnitCollection)Session["producitonUnits"];
            }
            set
            {
                Session["producitonUnits"] = value;
            }
        }

        #endregion
        public static string FinshingValue
        {
            get;
            set;
        }
        public static string CuttingVal
        {
            get;
            set;
        }

        public string Finshingjsvaribale
        {
            get;
            set;
        }
        public string Cuttingjsvaribale
        {
            get;
            set;
        }
        #region Event Handlers

        string strclientValue = string.Empty;
        string strFactoryIEvalue = string.Empty;
        string strwriterIEvalue = string.Empty;

        string FinalClientNameCollected = string.Empty;
     
         int ProductionUnitID = 0;

        String ProductionFolderPath = "~/" + System.Configuration.ConfigurationManager.AppSettings["photo.folder"];
        
        protected void Page_Load(object sender, EventArgs e)
        {   
            if (!IsPostBack)
            {  
                DropdownHelper.BindUsersByDesignation(ddlProductionUnitManager, (int)Designation.BIPL_Production_FactoryManager);
                DropdownHelper.BindUsersByDesignation(ddlFactoryHead, (int)Designation.BIPL_QA_FACTORY_HEAD);

                Bindclinet();                
                BindProductionUnits();
            }
            if (hdn_capicityval.Value != "")            
                txtCapacity.Text = hdn_capicityval.Value;
            
          
        }
        
        public void Bindclinet()
        {   
            DataSet ds = new DataSet();

            ds = objAdminController.GetClientlist(1);
            Listclientname.DataSource = ds.Tables[0];
            Listclientname.DataTextField = "clientcode";
            Listclientname.DataValueField = "ClientId";
            Listclientname.DataBind();
            string workinday = ds.Tables[1].Rows[0]["WorkingDays"].ToString();
            string workinhrs = ds.Tables[1].Rows[0]["WorkingHrs"].ToString();

            hdn_cmt_workingdays.Value = workinday.ToString();
            hdn_cmt_workinghourse.Value = workinhrs.ToString();
            

            if (ds.Tables[2].Rows.Count > 0)
            {
                listFactoryIE.DataSource = ds.Tables[2];
                listFactoryIE.DataTextField = "FIRSTNAME";
                listFactoryIE.DataValueField = "USERID";
                listFactoryIE.DataBind();
              
            }

            if (ds.Tables[3].Rows.Count > 0)
            {
                listwirterIE.DataSource = ds.Tables[3];
                listwirterIE.DataTextField = "FIRSTNAME";
                listwirterIE.DataValueField = "USERID";
                listwirterIE.DataBind();
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                ddlfinishingSupervisor.DataSource = ds.Tables[4];
                ddlfinishingSupervisor.DataTextField = "FIRSTNAME";
                ddlfinishingSupervisor.DataValueField = "USERID";
                ddlfinishingSupervisor.DataBind();
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                ddlFinishingIncharge.DataSource = ds.Tables[5];
                ddlFinishingIncharge.DataTextField = "FIRSTNAME";
                ddlFinishingIncharge.DataValueField = "USERID";
                ddlFinishingIncharge.DataBind();
            }

            if (ds.Tables[6].Rows.Count > 0)
            {
                ddlfinishingqa.DataSource = ds.Tables[6];
                ddlfinishingqa.DataTextField = "FIRSTNAME";
                ddlfinishingqa.DataValueField = "USERID";
                ddlfinishingqa.DataBind();
            }

            ddlfinishingSupervisor.Items.Insert(0, new ListItem("Select", "-1"));
            ddlFinishingIncharge.Items.Insert(0, new ListItem("Select", "-1"));
            ddlfinishingqa.Items.Insert(0, new ListItem("Select", "-1"));

            if (ds.Tables[8].Rows.Count > 0)
            {
                dtuserall = ds.Tables[8];
            }
            if (ds.Tables[7].Rows.Count > 0)
            {               
                rptuser.DataSource = ds.Tables[7];
                rptuser.DataBind();
            }
        }

        public void GetClientSelectedValue()
        {
            string Chklist = string.Empty;
            if (Listclientname.Items.Count > 0)
            {
                for (int i = 0; i < Listclientname.Items.Count; i++)
                {
                    if (Listclientname.Items[i].Selected)
                    {
                        Chklist = Chklist + Listclientname.Items[i].Value + ",";

                    }
                }
            }
           
            if (!string.IsNullOrEmpty(Chklist))
            {
                strclientValue = Chklist.Remove(Chklist.Length - 1);
            }
            
            string chklistfactory = string.Empty;
            if (listFactoryIE.Items.Count > 0)
            {
                for (int i = 0; i < listFactoryIE.Items.Count; i++)
                {
                    if (listFactoryIE.Items[i].Selected)
                    {
                        chklistfactory = chklistfactory + listFactoryIE.Items[i].Value + ",";

                    }
                }
            }

            if (!string.IsNullOrEmpty(chklistfactory))
            {
                strFactoryIEvalue = chklistfactory.Remove(chklistfactory.Length - 1);
            }

            string chklistWriterIE = string.Empty;
            if (listwirterIE.Items.Count > 0)
            {
                for (int i = 0; i < listwirterIE.Items.Count; i++)
                {
                    if (listwirterIE.Items[i].Selected)
                    {
                        chklistWriterIE = chklistWriterIE + listwirterIE.Items[i].Value + ",";

                    }
                }
            }

            if (!string.IsNullOrEmpty(chklistWriterIE))
            {
                strwriterIEvalue = chklistWriterIE.Remove(chklistWriterIE.Length - 1);
            }
        }
       
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            binddllfactory(-1);
            ResetControls();
            ShowHideProductionUnits(false);
            Bindclinet();

            int s = objAdminController.getProdctionID(-1);

            divUpload.Visible = true;
            lblupload.Visible = true;

            hlkViewSnap1.Visible = false;
            hlkViewSnap2.Visible = false;
            hlkViewSnap3.Visible = false;
            hlkViewSnap4.Visible = false;

        }
       
        protected void btnSave_Click(object sender, EventArgs e)
        {  
            if(txtProductionUnitCode.Text=="")
            {
                ShowAlert("Enter prodution unit code");
                return;
            }

            
            if (txtProductionUnitName.Text == "")
            {
                ShowAlert("Enter prodution unit name");
                return;
            }
           
            if (txtNumberOfMachines.Text == "")
            {
                ShowAlert("Enter Number Of machines");
                return;
            }

            
            if (txtNumberOfLines.Text == "")
            {
                ShowAlert("Enter Number Of Lines");
                return;
            }
            
            if (txtNumberOfFloors.Text == "")
            {
                ShowAlert("Enter Number Of floors");
                return;
            }
          
            if (txtAddress.Text == "")
            {
                ShowAlert("Enter Address");
                return;
            }
           
            if (ddlProductionUnitManager.SelectedValue == "-1")
            {
                ShowAlert("Please select Factory Manager");
                return;
            }
           
            if (ddlclasfication.SelectedValue == "-1")
            {
                ShowAlert("Please select classification");
                return;
            }
            
            if (txt_mothlyoverhead.Text == "")
            {
                ShowAlert("Enter Cutting Share");
                return;
            }
          
            if (txt_1.Text == "")
            {
                ShowAlert("Enter Stitching Share ");
                return;
            }
           
            if (txt_2.Text == "")
            {
                ShowAlert("Enter Finishing Share");
                return;
            }

           
            if (txt_3.Text == "")
            {
                ShowAlert("Enter Client Association  value");
                return;
            }

            int countlistitem = 0;

            if (Listclientname.Items.Count > 0)
            {
                for (int i = 0; i < Listclientname.Items.Count; i++)
                {
                    if (Listclientname.Items[i].Selected == true)
                    {
                        countlistitem = countlistitem + 1;

                    }
                }
            }           

            int CountListFactory = 0;
            int CountListWriterIE = 0;
            if (listFactoryIE.Items.Count > 0)
            {
                for (int i = 0; i < listFactoryIE.Items.Count; i++)
                {
                    if (listFactoryIE.Items[i].Selected == true)
                    {
                        CountListFactory = CountListFactory + 1;

                    }
                }
            }
            if (listwirterIE.Items.Count > 0)
            {
                for (int i = 0; i < listwirterIE.Items.Count; i++)
                {
                    if (listwirterIE.Items[i].Selected == true)
                    {
                        CountListWriterIE = CountListWriterIE + 1;

                    }
                }
            }

            GetClientSelectedValue();

            ProductionUnit objProductionUnit = new ProductionUnit();

            if (ProductionUnitId > 0)
            {
                objProductionUnit.ProductionUnitId = ProductionUnitId;
            }

            objProductionUnit.FactoryCode = txtProductionUnitCode.Text;
            objProductionUnit.FactoryName = txtProductionUnitName.Text;
            objProductionUnit.Address = txtAddress.Text;
            objProductionUnit.EmailId = txtemail.Text;

            objProductionUnit.NumberOfMachines = (txtNumberOfMachines.Text == string.Empty) ? 0 : Convert.ToInt32(txtNumberOfMachines.Text);
            objProductionUnit.NumberOfLines = (txtNumberOfLines.Text == string.Empty) ? 0 : Convert.ToInt32(txtNumberOfLines.Text);
            objProductionUnit.NumberOfFloors = (txtNumberOfFloors.Text == string.Empty) ? 0 : Convert.ToInt32(txtNumberOfFloors.Text);

            objProductionUnit.Cluster = (txtcluster.Text == string.Empty) ? 0 : Convert.ToInt32(txtcluster.Text);
            
            double inputValue = (txtCapacity.Text == "") ? 0 : Convert.ToDouble(txtCapacity.Text);
            Math.Round(inputValue, 2);

            objProductionUnit.Capacity = Math.Round(inputValue, 2);

            objProductionUnit.ProductionUnitColor = "";

            objProductionUnit.ProductionUnitManagerId = (ddlProductionUnitManager.SelectedIndex == 0) ? 0 : Convert.ToInt32(ddlProductionUnitManager.SelectedValue);
            objProductionUnit.QAFactoryHeadId = Convert.ToInt32(ddlFactoryHead.SelectedValue);
            objProductionUnit.Classification = Convert.ToInt32(ddlclasfication.SelectedValue);
            if (string.IsNullOrEmpty(txt_mothlyoverhead.Text))
            {
                objProductionUnit.Unit_Monthly_Overheads = 0;
            }
            else
            {
                objProductionUnit.Unit_Monthly_Overheads = Convert.ToInt32(txt_mothlyoverhead.Text);
            }
            
            objProductionUnit.Cuttingshare = (txt_1.Text == string.Empty) ? 0 : Convert.ToInt32(txt_1.Text);
            objProductionUnit.stitchingshar = (txt_2.Text == string.Empty) ? 0 : Convert.ToInt32(txt_2.Text);
            objProductionUnit.finishingshar = (txt_3.Text == string.Empty) ? 0 : Convert.ToInt32(txt_3.Text);
                        
            objProductionUnit.Clientname = strclientValue;
            if (chk_finishing_act.Checked == true)
            {
                objProductionUnit.Finishing_Active = 1;
            }
            else
            {
                objProductionUnit.Finishing_Active = 0;
            }
            if (chk_cutting_act.Checked == true)
            {
                objProductionUnit.Cutting_Active = 1;
            }
            else
            {
                objProductionUnit.Cutting_Active = 0;
            }


            objProductionUnit.FactoryIE = strFactoryIEvalue;
            objProductionUnit.WirterIE = strwriterIEvalue;

            if (ddlfinishing.Enabled == true)
            {
                if (ddlfinishing.SelectedValue != "-1")
                {
                    objProductionUnit.FinishingAllocate_Unit = Convert.ToInt32(ddlfinishing.SelectedValue);
                }
                else if (ddlfinishing.SelectedValue == "-1")
                {   
                    ShowAlert("Select at least one finshing factory");
                    Control cnt = LoadControl("~/UserControls/Forms/FactorySpecificLineAdminControl.ascx");
                    placeZHolder1.Controls.Add(cnt);
                    return;
                }
            }
            if (ddlcutting.Enabled == true)
            {
                if (ddlcutting.SelectedValue != "-1")
                {
                    objProductionUnit.CuttingAllocate_Unit = Convert.ToInt32(ddlcutting.SelectedValue);
                }
                else if (ddlcutting.SelectedValue == "-1")
                {  
                    ShowAlert("Select at least one cutting factory");
                    Control cnt = LoadControl("~/UserControls/Forms/FactorySpecificLineAdminControl.ascx");
                    placeZHolder1.Controls.Add(cnt);
                    return;
                }
            }

            if (ViewState["fileupload1"] != null)
            {
                objProductionUnit.FileUploadUrl1 = ViewState["fileupload1"].ToString();
            }
            if (ViewState["fileupload2"] != null)
            {
                objProductionUnit.FileUploadUrl2 = ViewState["fileupload2"].ToString();
            }
            if (ViewState["fileupload3"] != null)
            {
                objProductionUnit.FileUploadUrl3 = ViewState["fileupload3"].ToString();
            }
            if (ViewState["fileupload4"] != null)
            {
                objProductionUnit.FileUploadUrl4 = ViewState["fileupload4"].ToString();
            }
            if (ChkISVaEnabled.Checked == true)
            {
                objProductionUnit.IsVA_Enabled = 1;
            }
            else
            {
                objProductionUnit.IsVA_Enabled = 0;
            }

            objProductionUnit.finishingSupervisor = Convert.ToInt32(ddlfinishingSupervisor.SelectedValue);
            objProductionUnit.FinishingIncharge = Convert.ToInt32(ddlFinishingIncharge.SelectedValue);

            objProductionUnit.finishingQa = Convert.ToInt32(ddlfinishingqa.SelectedValue);
            this.AllocationControllerInstance.SaveProductionUnit(objProductionUnit);
            int NewOrExistproductionId;

            if (ProductionUnitId > 0)
            {
                NewOrExistproductionId = ProductionUnitId;
            }
            else
            {              
                NewOrExistproductionId = objProductionUnit.ProductionUnitId;
            }
            bool IsValid = true;
            foreach (RepeaterItem item in rptuser.Items)
            {
                HiddenField hdndesignation = (HiddenField)item.FindControl("hdndesignation");
                DropDownList ddldesignation = (DropDownList)item.FindControl("ddldesignation");
                Label lbldesignation = (Label)item.FindControl("lbldesignation");
                int DesignationID = Convert.ToInt32(hdndesignation.Value);
                int UserId = Convert.ToInt32(ddldesignation.SelectedValue);
                if (UserId == -1)
                {
                    ShowAlert("Please select user first");
                    IsValid = false;
                    
                }                
            }
            if (IsValid == true)
            {
                foreach (RepeaterItem item in rptuser.Items)
                {
                    HiddenField hdndesignation = (HiddenField)item.FindControl("hdndesignation");
                    DropDownList ddldesignation = (DropDownList)item.FindControl("ddldesignation");
                    Label lbldesignation = (Label)item.FindControl("lbldesignation");
                    int DesignationID = Convert.ToInt32(hdndesignation.Value);
                    int UserId = Convert.ToInt32(ddldesignation.SelectedValue);
                    if (UserId == -1)
                    {   
                        ShowAlert("Please select user first");
                        return;
                    }
                    this.AllocationControllerInstance.InserUpdateUserProduction(NewOrExistproductionId, DesignationID, UserId);
                }
                BindProductionUnits();
                ShowHideProductionUnits(true);
            }
        }
        ProductionUnit objProductionUnit = new ProductionUnit();
        public string GetclientName(string ids)
        {
            string strclientname = string.Empty;
            DataTable dt = new DataTable();
            dt = objAdminController.GetClientlistFillter(ids);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strclientname = strclientname + dt.Rows[i]["ClientCode"].ToString() + "," + " ";

            }
            objProductionUnit.fillterClientname = strclientname;
            return strclientname;
        }
       
        public string GetIeName(string ids)
        {
            string str_IE = string.Empty;
            DataTable dt = new DataTable();
            dt = objAdminController.GeIedetails(ids);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str_IE = str_IE + dt.Rows[i]["FIRSTNAME"].ToString() + "," + " ";

            }
            objProductionUnit.FactoryIE = str_IE;
            return str_IE;
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField hdndesignation = (HiddenField)e.Item.FindControl("hdndesignation");
            DropDownList ddldesignation = (DropDownList)e.Item.FindControl("ddldesignation");
            
            DataTable dtFilter = dtuserall;
            DataTable dt = null;

              dtFilter.DefaultView.RowFilter = "DesignationID=" + hdndesignation.Value;
              DataView dv = dtFilter.DefaultView;
              dt = dv.ToTable();

              ddldesignation.DataSource = dt;
              ddldesignation.DataTextField = "FIRSTNAME";
              ddldesignation.DataValueField = "USERID";
              ddldesignation.DataBind();          
              ddldesignation.Items.Insert(0, new ListItem("Select", "-1"));
        }
        protected void gridProductionUnits_RowDataBound(object sender, GridViewRowEventArgs e)
        {
             
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int puid = ProductionUnits[e.Row.DataItemIndex].ProductionUnitId;
                string ClientID = ProductionUnits[e.Row.DataItemIndex].Clientname;

                int Cuttingshare =  ProductionUnits[e.Row.DataItemIndex].Cuttingshare;
                int stitchingshar = ProductionUnits[e.Row.DataItemIndex].stitchingshar;
                int finishingshar = ProductionUnits[e.Row.DataItemIndex].finishingshar;
                
                int finshing_IsAct = ProductionUnits[e.Row.DataItemIndex].Finishing_Active;
                int stiching_IsAct = ProductionUnits[e.Row.DataItemIndex].Cutting_Active;

                int IsVA_Enabled = ProductionUnits[e.Row.DataItemIndex].IsVA_Enabled;

                if (IsVA_Enabled == 1)
                {
                    e.Row.Cells[22].Text = "Active";

                }
                else
                {
                    e.Row.Cells[22].Text = "In-Active";
                }
                if (finshing_IsAct == 1)
                {
                    e.Row.Cells[16].Text = "Active";
                   
                }
                else
                {
                    e.Row.Cells[16].Text = "In-Active";
                }
                if (stiching_IsAct == 1)
                {

                    e.Row.Cells[17].Text = "Active";
                }
                else
                {
                    e.Row.Cells[17].Text = "In-Active";
                }
               
                e.Row.Cells[12].Text = Cuttingshare + "%";
                e.Row.Cells[13].Text = stitchingshar + "%";
                e.Row.Cells[14].Text = finishingshar + "%";

                string Classifi = string.Empty;

                string finalclientname = string.Empty;
                string ss = string.Empty;
                finalclientname = GetclientName(ClientID);

                if (!string.IsNullOrEmpty(finalclientname))
                {
                    ss = finalclientname.Remove(finalclientname.Length - 2, 2);

                }
             
                string FactoryIE_value = ProductionUnits[e.Row.DataItemIndex].FactoryIE;
                string WirterIE_value = ProductionUnits[e.Row.DataItemIndex].WirterIE;
              

                string factoryIE = string.Empty;
                string str_factoryIE = string.Empty;
                factoryIE = GetIeName(FactoryIE_value);
                if (!string.IsNullOrEmpty(factoryIE))
                {
                    str_factoryIE = factoryIE.Remove(factoryIE.Length - 2, 2);

                }

                string WirterIE = string.Empty;
                string str_WriterIE = string.Empty;
                WirterIE = GetIeName(WirterIE_value);



                if (!string.IsNullOrEmpty(WirterIE))
                {
                    str_WriterIE = WirterIE.Remove(WirterIE.Length - 2, 2);

                }

                e.Row.Cells[18].Text = str_factoryIE;
                e.Row.Cells[19].Text = str_WriterIE;
                e.Row.Cells[15].Text = ss.ToUpper();

                
                int GetClassification = ProductionUnits[e.Row.DataItemIndex].Classification;
                if (GetClassification == 1)
                {
                    Classifi = "In House";
                }
                if (GetClassification == 0)
                {
                    Classifi = "Out House";

                }
                e.Row.Cells[10].Text = Classifi;
               
                int dllfinshingval;
                int ddlcuttingval;
                dllfinshingval = ProductionUnits[e.Row.DataItemIndex].FinishingAllocate_Unit;
                ddlcuttingval = ProductionUnits[e.Row.DataItemIndex].CuttingAllocate_Unit;
                DataTable dts = new DataTable();

                dts = objprintController.GetAllfactoryUnit(0);
                DataRow[] resultfinishing = dts.Select("id=" + dllfinshingval);                         
                DataRow[] resultcutting = dts.Select("id=" + ddlcuttingval);

                foreach (DataRow row in resultfinishing)
                {
                    e.Row.Cells[20].Text = row["Name"].ToString();

                    Finshingjsvaribale = row["Name"].ToString();
                    hdn_finshingcheck.Value = row["Name"].ToString();
                   
                }
                if (hdn_finshingcheck.Value != "")
                {
                    hdn_finshingcheck.Value = "1";
                }
                else
                {
                    hdn_finshingcheck.Value = "0";
                }

                foreach (DataRow row2 in resultcutting)
                {
                    e.Row.Cells[21].Text = row2["Name"].ToString();
                    Cuttingjsvaribale = row2["Name"].ToString();
                    hdn_cuttingcheck.Value = row2["Name"].ToString(); 
                }
                if (hdn_cuttingcheck.Value != "")
                {
                    hdn_cuttingcheck.Value = "1";
                }
                else
                {
                    hdn_cuttingcheck.Value = "0";
                }

                string FinishingSuper = string.Empty;
                string FinshingInchar = string.Empty;
                string FinishingQa = string.Empty;

                string FinishingSuper_ = string.Empty;
                string FinshingInchar_ = string.Empty;
                string FinishingQa_ = string.Empty;
             
                FinishingSuper = GetIeName(ProductionUnits[e.Row.DataItemIndex].finishingSupervisor.ToString());
                FinshingInchar = GetIeName(ProductionUnits[e.Row.DataItemIndex].FinishingIncharge.ToString());
                FinishingQa = GetIeName(ProductionUnits[e.Row.DataItemIndex].finishingQa.ToString());

                if (!string.IsNullOrEmpty(FinishingSuper))
                {
                    FinishingSuper_ = FinishingSuper.Remove(FinishingSuper.Length - 2, 2);
                }

                if (!string.IsNullOrEmpty(FinshingInchar))
                {
                    FinshingInchar_ = FinshingInchar.Remove(FinshingInchar.Length - 2, 2);
                }
                if (!string.IsNullOrEmpty(FinishingQa))
                {
                    FinishingQa_ = FinishingQa.Remove(FinishingQa.Length - 2, 2);
                }
            
                if (!string.IsNullOrEmpty(FinishingSuper_))
                {
                    e.Row.Cells[22].Text = FinishingSuper_;
                }

                if (!string.IsNullOrEmpty(FinshingInchar_))
                {
                    e.Row.Cells[23].Text = FinshingInchar_;
                }

                if (!string.IsNullOrEmpty(FinishingQa_))
                {
                    e.Row.Cells[24].Text = FinishingQa_;
                }
                LinkButton lnkDelete = e.Row.Cells[27].Controls[0] as LinkButton;

                lnkDelete.OnClientClick = "ShowHideConfirmationBox(true, 'Are you sure want to delete?', 'Produciton Unit', DeleteProductionUnit, " + puid + "); return false;";
              
                e.Row.Cells[7].ToolTip = "Capicity=(No of machine*26*11.25*60)";
              

            }
        }

        protected void gridProductionUnits_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridProductionUnits.PageIndex = e.NewPageIndex;
            BindProductionUnits();            
        }

        protected void gridProductionUnits_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ResetControls();
           
            ProductionUnit objProductionUnit = new ProductionUnit();
            ShowHideProductionUnits(false);
            try
            {
                objProductionUnit = ProductionUnits[gridProductionUnits.Rows[e.NewEditIndex].DataItemIndex];


                ProductionUnitId = objProductionUnit.ProductionUnitId;

            }
            catch (ArgumentOutOfRangeException ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            ProductionUnitID = objProductionUnit.ProductionUnitId;
            binddllfactory(ProductionUnitID);           

            txtProductionUnitName.Text = objProductionUnit.FactoryName;
            txtProductionUnitCode.Text = objProductionUnit.FactoryCode;
            txtAddress.Text = objProductionUnit.Address;
            txtemail.Text = objProductionUnit.EmailId;
            txtNumberOfMachines.Text = objProductionUnit.NumberOfMachines.ToString();
            txtNumberOfLines.Text = objProductionUnit.NumberOfLines.ToString();
            txtNumberOfFloors.Text = objProductionUnit.NumberOfFloors.ToString();
            txtCapacity.Text = objProductionUnit.Capacity.ToString();
            hdn_capicityval.Value = "";
            txtcluster.Text = objProductionUnit.Cluster.ToString() == "-1" ? "" : objProductionUnit.Cluster.ToString();
            if (ProductionUnitID != 3 && ProductionUnitID != 11 && ProductionUnitID != 96 && ProductionUnitID != 120)
                txtcluster.Enabled = false;
         
            if (ddlProductionUnitManager.Items.FindByValue(objProductionUnit.ProductionUnitManagerId.ToString()) != null)
            {
                ddlProductionUnitManager.SelectedValue = (objProductionUnit.ProductionUnitManagerId == 0) ? string.Empty : objProductionUnit.ProductionUnitManagerId.ToString();
            }
            else
            {
                ddlProductionUnitManager.SelectedItem.Text = "--Select--";

            }

            if (ddlFactoryHead.Items.FindByValue(objProductionUnit.QAFactoryHeadId.ToString()) != null)
            {

                if (objProductionUnit.QAFactoryHeadId.ToString() != string.Empty)
                {
                    ddlFactoryHead.SelectedValue = objProductionUnit.QAFactoryHeadId.ToString();

                }
                else
                {
                    ddlFactoryHead.SelectedItem.Text = "--Select--";
                }

            }
            else
            {
                ddlFactoryHead.SelectedItem.Text = "--Select--";

            }

            if (ddlclasfication.Items.FindByValue(objProductionUnit.Classification.ToString()) != null)
            {
                ddlclasfication.SelectedValue = objProductionUnit.Classification.ToString();
            }
            else
            {
               ddlclasfication.SelectedValue = "1";
            }        
            txt_mothlyoverhead.Text = objProductionUnit.Unit_Monthly_Overheads.ToString();
            string str1 = GetclientName(objProductionUnit.Clientname);

           
            string[] Findbytextvalue=null;
            if (objProductionUnit.Clientname != ""&&objProductionUnit.Clientname !=null)
            {
                Findbytextvalue = objProductionUnit.Clientname.Split(',');
                for (int i = 0; i < Findbytextvalue.Length; i++)
                {

                    string value = Listclientname.Items[i].Value;
                    bool checkexist = false;

                    foreach (ListItem itm in Listclientname.Items)
                    {
                        if (itm.Value == Findbytextvalue[i])
                        {
                            checkexist = true;
                            break;
                        }
                        else
                        {
                            checkexist = false;
                        }

                    }

                    if (!string.IsNullOrEmpty(Findbytextvalue[i]) && checkexist == true)
                    {
                        Listclientname.Items.FindByValue(Convert.ToString(Findbytextvalue[i])).Selected = true;
                    }

                   
                }
            }
                   
            txt_1.Text = objProductionUnit.Cuttingshare.ToString();
            txt_2.Text = objProductionUnit.stitchingshar.ToString();
            txt_3.Text = objProductionUnit.finishingshar.ToString();
            
           
            if (objProductionUnit.Finishing_Active == 1)
            {
                chk_finishing_act.Checked = true;
            }
            if (objProductionUnit.Cutting_Active == 1)
            {
                chk_cutting_act.Checked = true;

            }         

            if (objProductionUnit.IsVA_Enabled == 1)
            {
                ChkISVaEnabled.Checked = true;

            }
            
            string[] factoryIEalue=null;
          
            if (!string.IsNullOrEmpty(objProductionUnit.FactoryIE))
            {
                factoryIEalue = objProductionUnit.FactoryIE.Split(',');
               
            }

            if (factoryIEalue!=null)
            {
                for (int i = 0; i < factoryIEalue.Length; i++)
                {

                    if (!string.IsNullOrEmpty(factoryIEalue[i]))
                    {
                        listFactoryIE.Items.FindByValue(Convert.ToString(factoryIEalue[i])).Selected = true;
                    }
                }


            }
            string[] findwirterIE = null;
            if (!string.IsNullOrEmpty(objProductionUnit.WirterIE))
            {
                findwirterIE = objProductionUnit.WirterIE.Split(',');
            }

            if (findwirterIE != null)
            {
                for (int i = 0; i < findwirterIE.Length; i++)
                {
                    if (!string.IsNullOrEmpty(findwirterIE[i]))
                    {
                        listwirterIE.Items.FindByValue(Convert.ToString(findwirterIE[i])).Selected = true;
                    }
                }
            }

            if (objProductionUnit.FinishingAllocate_Unit == 0 || objProductionUnit.FinishingAllocate_Unit ==-1)
            {
                ddlfinishing.SelectedIndex =-1 ;
            }
            else
            {
                try
                {
                   
                    ddlfinishing.SelectedValue = objProductionUnit.FinishingAllocate_Unit.ToString();
                }
                catch
                {
                    ddlfinishing.SelectedValue = "-1";
                  
                }
            }
               
                if (objProductionUnit.Finishing_Active == 1)
                {
                    
                    ddlfinishing.Enabled = false;
                }
                else
                {
                    ddlfinishing.Enabled = true;
                }
            
            

            if (objProductionUnit.CuttingAllocate_Unit == 0 || objProductionUnit.CuttingAllocate_Unit ==-1)
            {
                ddlcutting.SelectedIndex = -1;
            }
            else
            {
                try
                {
                    ddlcutting.SelectedValue = objProductionUnit.CuttingAllocate_Unit.ToString();
                   
                }
                catch
                {
                    ddlcutting.SelectedValue = "-1";
                   
                }
            
            }

            if (objProductionUnit.Cutting_Active == 1)
            {

                ddlcutting.Enabled = false;
            }
            else
            {
                ddlcutting.Enabled = true;

            }

              FinshingValue = objProductionUnit.FinishingAllocate_Unit.ToString();
              CuttingVal = objProductionUnit.CuttingAllocate_Unit.ToString();
             
                  Session["Productidid"] = ProductionUnitId;
                  Control cnt = LoadControl("~/UserControls/Forms/FactorySpecificLineAdminControl.ascx");
                  placeZHolder1.Controls.Add(cnt);
              
              


              hdnupload1.Value = objProductionUnit.FileUploadUrl1;
              if (hdnupload1.Value != "")
              {
                  hlkViewSnap1.Visible = true;

                  hlkViewSnap1.NavigateUrl = ProductionFolderPath + hdnupload1.Value;
              }
              else

              {
                  hlkViewSnap1.Visible = false;
              }


              hdnupload2.Value = objProductionUnit.FileUploadUrl2;
              if (hdnupload2.Value != "")
              {
                  hlkViewSnap2.Visible = true;

                  hlkViewSnap2.NavigateUrl = ProductionFolderPath + hdnupload2.Value;
              }
              else

              {
                  hlkViewSnap2.Visible = false;
 
              }

              hdnupload3.Value = objProductionUnit.FileUploadUrl3;
              if (hdnupload3.Value != "")
              {
                  hlkViewSnap3.Visible = true;

                  hlkViewSnap3.NavigateUrl = ProductionFolderPath + hdnupload3.Value;
              }
              else
              {
                  hlkViewSnap3.Visible = false;
 
              }

              hdnupload4.Value = objProductionUnit.FileUploadUrl4;
              if (hdnupload4.Value != "")
              {
                  hlkViewSnap4.Visible = true;

                  hlkViewSnap4.NavigateUrl = ProductionFolderPath + hdnupload4.Value;
              }
              else

              {
                  hlkViewSnap4.Visible = false;
              }
              if (objProductionUnit.Classification.ToString() != "-1")
              {
                  if (objProductionUnit.Classification.ToString() == "0")
                  {
                      divUpload.Visible = true;
                      lblupload.Visible = true;
                  }
                  else
                  {
                      divUpload.Visible = false;
                      lblupload.Visible = false;

                  }
 
              }

              if (objProductionUnit.finishingSupervisor.ToString() != "0")
              {
                  ddlfinishingSupervisor.SelectedValue = objProductionUnit.finishingSupervisor.ToString();

              }
              else
              {
                  ddlfinishingSupervisor.SelectedValue = "-1";
              }

              if (objProductionUnit.FinishingIncharge.ToString() != "0")
              {
                  ddlFinishingIncharge.SelectedValue = objProductionUnit.FinishingIncharge.ToString();
                  
              }
              else
              {
                  ddlFinishingIncharge.SelectedValue = "-1";
              }


              if (objProductionUnit.finishingQa.ToString() != "0")
              {
                  ddlfinishingqa.SelectedValue = objProductionUnit.finishingQa.ToString();

              }
              else
              {
                  ddlfinishingqa.SelectedValue = "-1";
              }
              try
              {
                  foreach (RepeaterItem item in rptuser.Items)
                  {
                      HiddenField hdndesignation = (HiddenField)item.FindControl("hdndesignation");
                      DropDownList ddldesignation = (DropDownList)item.FindControl("ddldesignation");
                      int DesignationID = Convert.ToInt32(hdndesignation.Value);
                      DataTable dt = this.AllocationControllerInstance.GetSaveProductionDesignation(ProductionUnitId, DesignationID);
                      if (dt.Rows.Count > 0)
                      {
                          string UserId = dt.Rows[0]["Userid"].ToString();
                          if (!string.IsNullOrEmpty(UserId))
                          {
                              ddldesignation.SelectedValue = UserId;
                          }
                          else
                          {
                              ddldesignation.SelectedValue = "-1";
                          }
                      }
                      else
                      {
                          ddldesignation.SelectedValue = "-1";
                      }
                  }
   
                  
              }
              catch (Exception ex)
              {
                  ShowAlert(ex.ToString());
              }
              if (ApplicationHelper.LoggedInUser.UserData.UserID != 2)
              {
                  txtNumberOfMachines.Enabled = false;
                  txtNumberOfLines.Enabled = false;
                  txtNumberOfMachines.ToolTip = "You have no permission to access this filed";
                  txtNumberOfLines.ToolTip = "You have no permission to access this filed";
 
              }
        }
      
        

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ShowHideProductionUnits(true);
        }

        protected void gridProductionUnits_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productionUnitId = ProductionUnits[gridProductionUnits.Rows[e.RowIndex].DataItemIndex].ProductionUnitId;
            int iReturn;
            iReturn = this.AllocationControllerInstance.DeleteProductionUnit_ByUnitId(productionUnitId);
            if (iReturn == 1)            
                BindProductionUnits();
            
        }

        #endregion

        #region Methods
       

        public void BindProductionUnits()
        {
            ProductionUnits = this.AllocationControllerInstance.GetProductionUnits("%%");
            gridProductionUnits.DataSource = ProductionUnits;
            gridProductionUnits.DataBind();
            txtSearchKeyWords.Text = "";
        }

        private void ShowHideProductionUnits(bool showProductionUnits)
        {
            tblProductionUnits.Visible = showProductionUnits;
            tblProductionUnitDetails.Visible = !showProductionUnits;
        }

        private void ResetControls()
        {
           
            ProductionUnitId = -1;
           
            txtProductionUnitCode.Text = "";
            txtProductionUnitName.Text = "";
            txtAddress.Text = "";
            txtemail.Text = "";
            txtNumberOfMachines.Text = "";
            txtNumberOfLines.Text = "";
            txtNumberOfFloors.Text = "";
            txtCapacity.Text = "";
            
            txt_mothlyoverhead.Text = "";
            ddlProductionUnitManager.SelectedIndex = -1;
            ddlFactoryHead.SelectedIndex = -1;
            ddlclasfication.SelectedIndex = 1;
            txt_mothlyoverhead.Text = "";
            Listclientname.ClearSelection();
            txt_1.Text = "";
            txt_2.Text = "";
            txt_3.Text = "";
            
            chk_cutting_act.Checked = false;
            chk_finishing_act.Checked = false;
            listFactoryIE.ClearSelection();
            listwirterIE.ClearSelection();
            ddlfinishing.SelectedIndex = -1;
            ddlcutting.SelectedIndex = -1;
            ddlfinishing.Enabled = true;
            ddlcutting.Enabled = true;

        }

        #endregion

        protected void chk_finishing_act_CheckedChanged(object sender, EventArgs e)
        {  
            if (chk_finishing_act.Checked == true)
            {
                ddlfinishing.SelectedIndex = -1;
                ddlfinishing.Enabled = false;
            }
            else
            {
                ddlfinishing.Enabled = true;
                ddlfinishing.SelectedValue = (FinshingValue == "0") ? "-1" : FinshingValue;
            }
           
            Control cnt = LoadControl("~/UserControls/Forms/FactorySpecificLineAdminControl.ascx");
            placeZHolder1.Controls.Add(cnt);
        }

        protected void chk_cutting_act_CheckedChanged(object sender, EventArgs e)
        {  
            if (chk_cutting_act.Checked == true)
            {
                ddlcutting.SelectedIndex = -1;
                ddlcutting.Enabled = false;
            }
            else
            {
                ddlcutting.Enabled = true;
                ddlcutting.SelectedValue = (CuttingVal == "0") ? "-1" : CuttingVal;
            }
           
            Control cnt = LoadControl("~/UserControls/Forms/FactorySpecificLineAdminControl.ascx");
            placeZHolder1.Controls.Add(cnt);
           
        }
        public void binddllfactory(int prodctionid)
        {   
            dtFactoryUnit = objprintController.GetAllfactoryUnit(prodctionid);

            ddlfinishing.DataSource = dtFactoryUnit;
            ddlfinishing.DataTextField = "Name";
            ddlfinishing.DataValueField = "id";
            ddlfinishing.DataBind();

            ddlcutting.DataSource = dtFactoryUnit;
            ddlcutting.DataTextField = "Name";
            ddlcutting.DataValueField = "id";
            ddlcutting.DataBind();
        }

        protected void ddlsreachfactory_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        
        AllocationController Objallocation = new AllocationController();
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
    

        protected void ddlclasfication_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (ddlclasfication.SelectedValue == "0")
            {
                divUpload.Visible = true;
                lblupload.Visible = true;
            }
            if (ddlclasfication.SelectedValue == "1")
            {
                divUpload.Visible = false;
                lblupload.Visible = false;
            }
           
            Control cnt = LoadControl("~/UserControls/Forms/FactorySpecificLineAdminControl.ascx");
            placeZHolder1.Controls.Add(cnt);
        }

        protected void btn_upload_Click(object sender, EventArgs e)
        {
            string fileUpload1 = string.Empty;
            string fileUpload2 = string.Empty;
            string fileUpload3 = string.Empty;
            string fileUpload4 = string.Empty;

            fileUpload1 = upload_1.FileName;
            fileUpload2 = upload_2.FileName;
            fileUpload3 = upload_3.FileName;
            fileUpload4 = upload_4.FileName;

            if (fileUpload1 != "")
            {
                if (upload_1.HasFile)
                {
                    String ext = System.IO.Path.GetExtension(upload_1.FileName);
                                        
                    string fileNameStyle1 = string.Empty;
                        if (ProductionUnitId > 0)
                        {
                            fileNameStyle1 = ProductionUnitId + "-" + "Upload1" + "-" + fileUpload1;
                        }
                        else
                        {
                            fileNameStyle1 = "-1" + "-" + "Upload1" + "-" + fileUpload1;
                        }
                        ViewState["fileupload1"] = fileNameStyle1;
                        upload_1.SaveAs(Server.MapPath(ProductionFolderPath) + fileNameStyle1);
                        objProductionUnit.FileUploadUrl1 = fileNameStyle1 == "" ? "" : fileNameStyle1;
                        hlkViewSnap1.Visible = true;
                        hlkViewSnap1.NavigateUrl = (string.IsNullOrEmpty(objProductionUnit.FileUploadUrl1)) ? "" : ProductionFolderPath + objProductionUnit.FileUploadUrl1;
                        objProductionUnit.FileUploadUrl1 = fileNameStyle1;
                   

                }
            }
            if (fileUpload2 != "")
            {
                if (upload_2.HasFile)
                {
                    String ext = System.IO.Path.GetExtension(upload_2.FileName);
                     string fileNameStyle2 = string.Empty;

                        if (ProductionUnitId > 0)
                        {
                            fileNameStyle2 = ProductionUnitId + "-" + "Upload2" + "-" + fileUpload2;
                        }
                        else
                        {
                            fileNameStyle2 = "-1" + "-" + "Upload2" + "-" + fileUpload2;
                        }
                        ViewState["fileupload2"] = fileNameStyle2;

                        upload_2.SaveAs(Server.MapPath(ProductionFolderPath) + fileNameStyle2);
                        objProductionUnit.FileUploadUrl2 = fileNameStyle2 == "" ? "" : fileNameStyle2;
                        hlkViewSnap2.Visible = true;
                        hlkViewSnap2.NavigateUrl = (string.IsNullOrEmpty(objProductionUnit.FileUploadUrl2)) ? "" : ProductionFolderPath + objProductionUnit.FileUploadUrl2;

                        objProductionUnit.FileUploadUrl2 = fileNameStyle2;
                  

                }
            }
            if (fileUpload3 != "")
            {
                if (upload_3.HasFile)
                {
                    String ext = System.IO.Path.GetExtension(upload_3.FileName);
                   
                    
                        string fileNameStyle3 = string.Empty;


                        if (ProductionUnitId > 0)
                        {
                            fileNameStyle3 = ProductionUnitId + "-" + "Upload3" + "-" + fileUpload3;
                        }
                        else
                        {
                            fileNameStyle3 = "-1" + "-" + "Upload3" + "-" + fileUpload3;
                        }
                       
                        fileNameStyle3 = "-1" + "-" + "Upload3" + "-" + fileUpload3;
                        ViewState["fileupload3"] = fileNameStyle3;
                        
                        upload_3.SaveAs(Server.MapPath(ProductionFolderPath) + fileNameStyle3);
                        objProductionUnit.FileUploadUrl3 = fileNameStyle3 == "" ? "" : fileNameStyle3;
                        hlkViewSnap3.Visible = true;
                        hlkViewSnap3.NavigateUrl = (string.IsNullOrEmpty(objProductionUnit.FileUploadUrl3)) ? "" : ProductionFolderPath + objProductionUnit.FileUploadUrl3;
                        objProductionUnit.FileUploadUrl3 = fileNameStyle3;                   
                }
            }
            if (fileUpload4 != "")
            {
                if (upload_4.HasFile)
                {
                    String ext = System.IO.Path.GetExtension(upload_4.FileName);                   
                        string fileNameStyle4 = string.Empty;

                        if (ProductionUnitId > 0)
                        {
                            fileNameStyle4 = ProductionUnitId + "-" + "Upload4" + "-" + fileUpload4;
                        }
                        else
                        {
                            fileNameStyle4 = "-1" + "-" + "Upload4" + "-" + fileUpload4;
                        }
                        ViewState["fileupload4"] = fileNameStyle4;
                        upload_4.SaveAs(Server.MapPath(ProductionFolderPath) + fileNameStyle4);
                        objProductionUnit.FileUploadUrl4 = fileNameStyle4 == "" ? "" : fileNameStyle4;
                        hlkViewSnap4.Visible = true;
                        hlkViewSnap4.NavigateUrl = (string.IsNullOrEmpty(objProductionUnit.FileUploadUrl4)) ? "" : ProductionFolderPath + objProductionUnit.FileUploadUrl4;
                        objProductionUnit.FileUploadUrl4 = fileNameStyle4;
                   
                }
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowHideProductionUnits(true);
            string SearchTxt = "%" + txtSearchKeyWords.Text.Trim() + "%";
            ProductionUnits = this.AllocationControllerInstance.GetProductionUnits(SearchTxt);
            gridProductionUnits.DataSource = ProductionUnits;
            gridProductionUnits.DataBind();
        }      
        
    }
}
