using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web.UserControls.Forms
{
    public partial class SupplierAdmin : BaseUserControl
    {
        private bool _showProcess = false;
        private int SupplierId
        {
            get
            {
                if (Request.QueryString["Sid"] != null)
                    return Convert.ToInt32(Request.QueryString["Sid"]);
                return -1;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            errlbl.Text = "";
            if (!IsPostBack)
            {
                BindControls();
            }
        }

        protected void BindControls()
        {
            SupplierTables supplierTables = this.SupplierControllerInstance.GetAllSupplierTables();
            cblSupplyType.DataSource = supplierTables.PoTypes;
            cblSupplyType.DataBind();
            cblProcess.DataSource = supplierTables.Processes;
            cblProcess.DataBind();
            cblFgN.DataSource = supplierTables.Groups;
            cblFgN.DataBind();
            ddlPaymentTerm.DataSource = supplierTables.Days;
            ddlPaymentTerm.DataBind();
            ddlPaymentTerm.Items.Insert(0, new ListItem("--Select--", "-1"));
            BindControlsFromDatabase();
            if(_showProcess)
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript1",
                                                            "$(function(){ShowProcess();});", true);
            else
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript1",
                                                            "$(function(){HideProcess();});", true);
        }

        private void BindControlsFromDatabase()
        {
            if(SupplierId==-1)
                return;
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript",
                                                        "$(function(){FillContacts(" + SupplierId + ");supplierId=" +
                                                        SupplierId + "});", true);
            //PageHelper.AddJScriptVariable("SupplierId", SupplierId);

            SupplierTables supplierTables = this.SupplierControllerInstance.GetSupplierTableById(SupplierId);
            txtGroupInit.Text = supplierTables.Supplier.GroupInitial;
            txtGroupName.Text = supplierTables.Supplier.GroupName;
            txtSupplierInit.Text = supplierTables.Supplier.SupplierInitial;
            txtSupplierName.Text = supplierTables.Supplier.SupplierName;
            txtSltime.Text = supplierTables.Supplier.Leadtime.ToString();
            txtMonthlyCapacity.Text = supplierTables.Supplier.MonthlyCapacity == 0 ? "" : supplierTables.Supplier.MonthlyCapacity.ToString();
            txtSupplierAddress.Text = supplierTables.Supplier.Address;
            lblGrade.Text = supplierTables.Supplier.Grade;
            if (ddlUnit.Items.FindByText(supplierTables.Supplier.Unit) != null)
                ddlUnit.Text = supplierTables.Supplier.Unit;

            if (ddlPaymentTerm.Items.FindByValue(supplierTables.Supplier.PaymentTerms) != null)
                ddlPaymentTerm.SelectedValue = supplierTables.Supplier.PaymentTerms;

            if (supplierTables.PoTypes != null && supplierTables.PoTypes.Count > 0)
            {
                foreach (Po_Type pt in supplierTables.PoTypes)
                {
                   // if (pt.Id != 1)
                     //   showProcess = true;
                    if(cblSupplyType.Items.FindByValue(pt.Id.ToString())!=null)
                        cblSupplyType.Items.FindByValue(pt.Id.ToString()).Selected = true;
                }
            }

            if (supplierTables.Processes != null && supplierTables.Processes.Count > 0)
            {
                foreach (ProcessAdmin pt in supplierTables.Processes)
                {
                    if (cblProcess.Items.FindByValue(pt.Id.ToString()) != null)
                        cblProcess.Items.FindByValue(pt.Id.ToString()).Selected = true;
                }
                _showProcess = true;
            }

            if (supplierTables.Groups != null && supplierTables.Groups.Count > 0)
            {
                foreach (var pt in supplierTables.Groups)
                {
                    if (cblFgN.Items.FindByValue(pt.Id.ToString()) != null)
                        cblFgN.Items.FindByValue(pt.Id.ToString()).Selected = true;
                }
            }
        }

        protected void cblProcess_DataBound(object sender, EventArgs e)
        {
            
        }

        protected void SaveData()
        {
            SupplierTables sTable = new SupplierTables();
            sTable.Supplier = new Common.SupplierAdmin();
            sTable.Supplier.GroupInitial = txtGroupInit.Text.Trim();
            sTable.Supplier.GroupName = txtGroupName.Text.Trim();
            sTable.Supplier.SupplierName = txtSupplierName.Text.Trim();

            int cnt = this.SupplierControllerInstance.GetDuplicateSupplier(sTable.Supplier.GroupName,
                                                                            sTable.Supplier.SupplierName, SupplierId);
            if(cnt>0)
            {
                errlbl.Text = "Supplier already exists";
                //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript",
                  //                                              "$(function(){alert('Duplicate supplier found')});",
                    //                                            true);
                return;
            }
            sTable.Supplier.SupplierInitial = txtSupplierInit.Text.Trim();
            sTable.Supplier.Address = txtSupplierAddress.Text.Trim();
            sTable.Supplier.MonthlyCapacity = string.IsNullOrEmpty(txtMonthlyCapacity.Text.Trim())
                                                  ? 0
                                                  : Convert.ToInt64(txtMonthlyCapacity.Text.Trim());
            sTable.Supplier.Unit = ddlUnit.SelectedItem.Value;
            sTable.Supplier.PaymentTerms = ddlPaymentTerm.SelectedItem.Value;
            sTable.Supplier.Grade = lblGrade.Text.Trim();
            sTable.Supplier.Leadtime = Convert.ToInt32(txtSltime.Text.Trim());

            sTable.Processes = new List<ProcessAdmin>();
            foreach (ListItem li in cblProcess.Items)
            {
                if (li.Selected)
                {
                    sTable.Processes.Add(new ProcessAdmin { Id = Convert.ToInt32(li.Value) });
                }
            }

            sTable.PoTypes = new List<Po_Type>();
            foreach (ListItem li in cblSupplyType.Items)
            {
                if (li.Selected)
                {
                    sTable.PoTypes.Add(new Po_Type { Id = Convert.ToInt32(li.Value) });
                }
            }

            sTable.Groups = new List<FabricGroupAdmin>();
            foreach (ListItem li in cblFgN.Items)
            {
                if (li.Selected)
                {
                    sTable.Groups.Add(new FabricGroupAdmin { Id = Convert.ToInt32(li.Value) });
                }
            }

            sTable.Contacts = GetContactPersons();

            sTable.Id = SupplierId;
            sTable.IU = SupplierId == -1 ? 1 : 2;
            sTable.Supplier.ModifiedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
            int result = this.SupplierControllerInstance.Insert_Update_SupplierTables(sTable);
            switch (result)
            {
                case 1:
                    mainPanel.Visible = false;
                    pnlMessage.Visible = true;
                    //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript",
                    //                                            "$(function(){alert('Record successfully saved.')});",
                    //                                            true);
                    //hf.Value = "";
                    break;
                case 2:
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript",
                                                                "$(function(){alert('Supplier already exists.')});",
                                                                true);
                    SavePreviousData();
                    break;
            }
        }

        private List<SupplierContact> GetContactPersons()
        {
            List<SupplierContact> scs = new List<SupplierContact>();
            if (Request.Params["hdntotal"] != null)
            {
                int total = Convert.ToInt32(Request.Params["hdntotal"].Trim());
                for (int i = 1; i <= total; i++)
                {
                    if (string.IsNullOrEmpty(Request.Params["txtcp_" + i]))
                        continue;
                    string cp = "";
                    string email = "";
                    string phone = "";
                    string rem = "";
                    if (!string.IsNullOrEmpty(Request.Params["txtcp_" + i].Trim()))
                        cp = Request.Params["txtcp_" + i].Trim();
                    if (!string.IsNullOrEmpty(Request.Params["txtemail_" + i].Trim()))
                        email = Request.Params["txtemail_" + i].Trim();
                    if (!string.IsNullOrEmpty(Request.Params["txtphone_" + i].Trim()))
                        phone = Request.Params["txtphone_" + i].Trim();
                    if (!string.IsNullOrEmpty(Request.Params["txtrem_" + i].Trim()))
                        rem = Request.Params["txtrem_" + i].Trim();
                    SupplierContact sc = new SupplierContact();
                    sc.Name = cp;
                    sc.Phone = phone;
                    sc.Remarks = rem;
                    sc.Email = email;
                    scs.Add(sc);
                }
            }
            return scs;
        }

        protected void btnSubmit_Click(object sender,EventArgs e)
        {
            if (!Page.IsValid)
            {
                SavePreviousData();
                return;
            }
            int cnt = this.SupplierControllerInstance.GetDuplicateSupplier(txtGroupName.Text.Trim(),
                                                                            txtSupplierName.Text.Trim(), SupplierId);
            if (cnt > 0)
            {
                SavePreviousData();
                errlbl.Text = "Supplier already exists";
                return;
            }
            SaveData();
        }

        private void SavePreviousData()
        {
            if (string.IsNullOrEmpty(txtGroupName.Text.Trim()) || txtGroupName.Text.Trim().Length < 3)
            {
                txtGroupInit.Text = "";
                txtSupplierInit.Text = "";
                return;
            }
            string gName = txtGroupName.Text.Trim();
            txtGroupInit.Text = this.SupplierControllerInstance.GetGroupName(gName);
            if (string.IsNullOrEmpty(txtSupplierName.Text.Trim()) || txtSupplierName.Text.Trim().Length < 3)
            {
                txtSupplierInit.Text = "";
                return;
            }
            string sName = txtSupplierName.Text.Trim();
            txtSupplierInit.Text = gName.Substring(0, 3) + "-" + sName.Substring(0, 3);

            List<SupplierContact> scs = GetContactPersons();

            if (scs.Count < 1)
            {
                hf.Value = "";
                return;
            }
            List<SupplierContactJs> sjs = new List<SupplierContactJs>();
            foreach (var supplierContact in scs)
            {
                SupplierContactJs sj = new SupplierContactJs();
                sj.Name = supplierContact.Name;
                sj.Phone = supplierContact.Phone;
                sj.Email = supplierContact.Email;
                sj.Remarks = supplierContact.Remarks;
                sjs.Add(sj);
            }

            JavaScriptSerializer oSerializer = new JavaScriptSerializer();

            string sJson = oSerializer.Serialize(sjs);

            sJson = sJson.Replace("[", "").Replace("]", "").Replace("{", "");

            hf.Value = sJson;
        }
    }
}