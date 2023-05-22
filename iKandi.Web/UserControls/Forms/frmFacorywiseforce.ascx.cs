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
using System.IO;
using System.Globalization;

namespace iKandi.Web.UserControls.Forms
{
    public partial class frmFacorywiseforce : System.Web.UI.UserControl
    {
        public string CmtValue
        {
            get;
            set;
        }
       
        AdminController objAdminController = new AdminController();
        int CurrentLoggedInUserID = ApplicationHelper.LoggedInUser.UserData.UserID;
        protected void Page_Load(object sender, EventArgs e)
        {            

            if (!IsPostBack)
            {
                bindgrd();
                //bindgrdOT();
                BindDllCatagory(0);
                
                
            }

        }
        DataTable dt_staff;
        public void bindgrd()
        {


            DataSet ds = objAdminController.GetworkerType();
            dt_staff = new DataTable();
            dt_staff = ds.Tables[0];
            grdCurrency.DataSource = ds.Tables[0];
            grdCurrency.DataBind();

        }
        //2/6/2015 
        //public void bindgrdOT()
        //{

        //    AdminController objAdminController = new AdminController();
        //    DataSet ds_ot = objAdminController.GetManpowerOT();

        //    Grid_ot.DataSource = ds_ot.Tables[0];
        //    Grid_ot.DataBind();

        //}
        //END
      

        protected void grdCurrency_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdCurrency.EditIndex = -1;

            bindgrd();
           
        }
        protected void grdCurrency_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int Machine_Count_rdo;
            int MmrCount;
            string DdlStaff = string.Empty;
            int Isfactorystaff;
            AdminController objAdminController = new AdminController();
            GridViewRow Rows = grdCurrency.Rows[e.RowIndex];

            HiddenField hdnworkerType = Rows.FindControl("hdnworkerType") as HiddenField;
            TextBox txtWorkertype = Rows.FindControl("txtWorkerType") as TextBox;
            //Label txtCurrencySymbol = Rows.FindControl("txtCurrencySymbol") as Label;
            TextBox txtsalary = Rows.FindControl("txtsalary") as TextBox;
            char[] str = txtsalary.Text.ToCharArray();
            
            if (txtsalary.Text=="")
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Enter salary','Manpower form');";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                return;

            }
            if (str[0] == '0')
            {
                if (str.Length > 1)
                {
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Salary could not start from 0 (zero)','Manpower form');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                    return;

                }
                else
                {
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Salary could not be  0 (zero)','Manpower form');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                    return;

                }
            }


            DropDownList ddlstaff = Rows.FindControl("ddl_Depart") as DropDownList;
            RadioButton rdo_machine_count_updating1 = Rows.FindControl("rdo_machine_count1") as RadioButton;
            RadioButton rdo_obased1 = Rows.FindControl("rdo_obased1") as RadioButton;
            RadioButton rdo_isstaff1 = Rows.FindControl("rdo_isstaff1") as RadioButton;
            TextBox txt_Discription = Rows.FindControl("txt_discription") as TextBox;

            TextBox txt_OT1 = Rows.FindControl("txt_OT1") as TextBox;
            TextBox txt_OT2 = Rows.FindControl("txt_OT2") as TextBox;
            TextBox txt_OT3 = Rows.FindControl("txt_OT3") as TextBox;
            TextBox txt_OT4 = Rows.FindControl("txt_OT4") as TextBox;

            DropDownList ddl_Departgrd = Rows.FindControl("ddl_Departgrd") as DropDownList;
            TextBox txtqntygrd = Rows.FindControl("txtqntygrd") as TextBox;
            TextBox txtpercnetgrd = Rows.FindControl("txtpercnetgrd") as TextBox;
            TextBox txtMeasurementgrd = Rows.FindControl("txtMeasurementgrd") as TextBox;
          

            if (string.IsNullOrEmpty(txt_OT1.Text))
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Enter OT1','Manpower form');";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                return;

            }

            if (string.IsNullOrEmpty(txt_OT2.Text))
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Enter OT2','Manpower form');";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                return;

            }
            if (string.IsNullOrEmpty(txt_OT3.Text))
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Enter OT3','Manpower form');";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                return;

            }
            if (string.IsNullOrEmpty(txt_OT4.Text))
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Enter OT4','Manpower form');";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                return;

            }
            int OT1 = Convert.ToInt32(txt_OT1.Text.Trim());
            int OT2 = Convert.ToInt32(txt_OT2.Text.Trim());
            int OT3 = Convert.ToInt32(txt_OT3.Text.Trim());
            int OT4 = Convert.ToInt32(txt_OT4.Text.Trim());


            DdlStaff = ddlstaff.SelectedItem.Text;

            if (rdo_machine_count_updating1.Checked == true)
            {
                Machine_Count_rdo = 1;

            }
            else
            {
                Machine_Count_rdo = 0;
            }
            if (rdo_obased1.Checked == true)
            {
                MmrCount = 1;

            }
            else
            {
                MmrCount = 0;
            }


            //if (rdo_isstaff1.Checked == true)
            //{
            //    Isfactorystaff = 1;

            //}
            //else
           // {
                Isfactorystaff = 0;
           // }

            int id = Convert.ToInt32(hdnworkerType.Value);
            int salary = Convert.ToInt32(txtsalary.Text);

            string ddlcatogar = ddl_Departgrd.SelectedItem.Text == "Select" ? "0" : ddl_Departgrd.SelectedItem.Text;
            
            if ((DdlStaff == "Finishing") || (DdlStaff == "Cutting")  || (DdlStaff == "Stitching"))
            {
                if (ddlcatogar == "0")
                {
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Select Category & Garment','Manpower form');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                    return;
                }

            }
           
            decimal measurment = txtMeasurementgrd.Text == "" ? 0 : Math.Round(Convert.ToDecimal(txtMeasurementgrd.Text),2);
           
            decimal Qntys = txtqntygrd.Text == "" ? 0 : Convert.ToDecimal(txtqntygrd.Text);
            decimal Percentages = txtpercnetgrd.Text == "" ? 0 : Convert.ToDecimal(txtpercnetgrd.Text);

            if (ddl_Departgrd.SelectedItem.Text == "Pcs Per hour based")
            {
                if (txtqntygrd.Text == "" && txtpercnetgrd.Text == "")
                {
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Enter quantity value or percent value','Manpower form');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                    return;
                }
 
            }
            if (ddl_Departgrd.SelectedItem.Text == "Factory Based" || ddl_Departgrd.SelectedItem.Text == "Line Based" || ddl_Departgrd.SelectedItem.Text == "Floor Based")
            {
                Qntys = 0;
                Percentages = 0;
                if (txtMeasurementgrd.Text == "")
                {
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Enter Measurement value','Manpower form');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                    return;
                }
                else
                {
                    string text1 = txtMeasurementgrd.Text;
                    decimal percent;
                    bool res = decimal.TryParse(text1, out percent);
                    if (res == false)
                    {
                        string script = string.Empty;
                        script = "ShowHideMessageBox(true, 'Enter measurement in correct format','Manpower form');";
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                        return;
                    }
                    else
                    {
                        if (percent > 100.00M)
                        {

                            string script = string.Empty;
                            script = "ShowHideMessageBox(true, 'Enter measurement percentage should be less than or equal to 100','Manpower form');";
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                            return;
                        }
                    }
                }

            }
            int Result = -1;

            Result = objAdminController.UpdateWorkerBAL(txtWorkertype.Text, salary, CurrentLoggedInUserID, id, DdlStaff, Machine_Count_rdo, MmrCount, txt_Discription.Text, OT1, OT2, OT3, OT4, Isfactorystaff, ddlcatogar, measurment, Qntys, Percentages);
            if (Result == 0)
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Record not updated ','Manpower form');";
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                grdCurrency.EditIndex = -1;
                bindgrd();

            }
            else
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Record updated successfully ','Manpower form');";
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

                grdCurrency.EditIndex = -1;
                bindgrd();

            }



        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        protected void grdCurrency_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdCurrency.EditIndex = e.NewEditIndex;

            bindgrd();

            GridViewRow Rows = grdCurrency.Rows[e.NewEditIndex];

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (txtWorker.Value.Length == 0)
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Enter worker type','Manpower form');";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                return;

            }
            if (DDl_Dept.SelectedValue == "-1")
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Select worker department','Manpower form');";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                return;

            }
            if (ddlcatogary.SelectedValue == "-1")
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Select category & % garment','Manpower form');";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                return;


            } 
            else
            {
                if (ddlcatogary.SelectedValue == "4")
                {
                    if (string.IsNullOrEmpty(txtQnty.Value) && string.IsNullOrEmpty(txtPercentage.Value))
                    {
                        string script = string.Empty;
                        script = "ShowHideMessageBox(true, 'Enter Qnty or percent value','Manpower form');";
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                        return;

                    }
                }
                else
                {
                    if (txtmeasurement.Value == "")
                    {
                        string script = string.Empty;
                        script = "ShowHideMessageBox(true, 'Enter measurement value','Manpower form');";
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                        return;
                    }
                    else
                    {
                        string text1 = txtmeasurement.Value;
                        decimal percent;
                        bool res = decimal.TryParse(text1, out percent);
                        if (res == false)
                        {
                            string script = string.Empty;
                            script = "ShowHideMessageBox(true, 'Enter measurement in correct format','Manpower form');";
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                            return;
                        }
                        else
                        {
                            if (percent > 100.00M)
                            {

                                string script = string.Empty;
                                script = "ShowHideMessageBox(true, 'Enter measurement percentage should be less than or equal to 100','Manpower form');";
                                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                                return;
                            }
                        }
                    }
                }
            }
            if (txtsalary.Value.Length ==0)
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Enter salary','Manpower form');";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                return;

            }
            char[] str = txtsalary.Value.ToCharArray();
            if (str[0] == '0')
            {
                if (str.Length > 1)
                {
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Salary could not start from 0 (zero)','Manpower form');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                    return;

                }
                else
                {
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Salary could not be  0 (zero)','Manpower form');";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                    return;

                }


            }
            if (rdo_machinecount.Checked == false && rdo_machinecount2.Checked == false)
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'select part of machine count','Manpower form');";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                return;

            }
            if (obnased1.Checked == false && obnased2.Checked == false)
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Select OB based','Manpower form');";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                return;

            }
            //if (rdo_isstaff1.Checked == false && rdo_isstaff2.Checked == false)
            //{
            //    string script = string.Empty;
            //    script = "ShowHideMessageBox(true, 'Select is staff based or variable based pay','Manpower form');";
            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
            //    return;

            //}
            AdminController objAdminController = new AdminController();
            string ddlstaffvalue = DDl_Dept.SelectedItem.Text;
            int machinecount;
            int Obbased;
            int isstaff;
            //if (string.IsNullOrEmpty(txtOT1.Value) || string.IsNullOrEmpty(txtOT2.Value) || string.IsNullOrEmpty(txtOT3.Value) || string.IsNullOrEmpty(txtOT3.Value) || string.IsNullOrEmpty(txtOT4.Value))
            //{
            //    string script = string.Empty;
            //    script = "ShowHideMessageBox(true, 'Enter OT','Manpower form');";
            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
            //    return;

            //}


            if (string.IsNullOrEmpty(txtOT1.Value))
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Enter OT1','Manpower form');";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                return;

            }

            if (string.IsNullOrEmpty(txtOT2.Value))
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Enter OT2','Manpower form');";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                return;

            }
            if (string.IsNullOrEmpty(txtOT3.Value))
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Enter OT3','Manpower form');";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                return;

            }
            if (string.IsNullOrEmpty(txtOT4.Value))
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Enter OT4','Manpower form');";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                return;

            }
            int OT1 = Convert.ToInt32(txtOT1.Value);
            int OT2 = Convert.ToInt32(txtOT2.Value);
            int OT3 = Convert.ToInt32(txtOT3.Value);
            int OT4 = Convert.ToInt32(txtOT4.Value);



            string Discription = string.Empty;
            if (rdo_machinecount.Checked == true)
            {
                machinecount = 1;

            }
            else
            {
                machinecount = 0;
            }
            if (obnased1.Checked == true)
            {
                Obbased = 1;

            }
            else
            {
                Obbased = 0;
            }

            //if (rdo_isstaff1.Checked == true)
            //{
            //    isstaff = 1;

            //}
            //else
            //{
                isstaff = 0;
            //}
            Discription = txt_discription.Text;
            //commented as per ravi sir 
            //if (ddlcatogary.SelectedValue == "-1")
            //{
            //    string script = string.Empty;
            //    script = "ShowHideMessageBox(true, 'Select catogary','Manpower form');";
            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
            //    return;

            //}
           
            //if (txtsalary.Value.Length ==0)
            //{
            //    string script = string.Empty;
            //    script = "ShowHideMessageBox(true, 'Enter salary','Manpower form');";
            //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
            //    return;

            //}
            
        
               
            
            decimal measurment =txtmeasurement.Value==""?0: Math.Round(Convert.ToDecimal(txtmeasurement.Value),2);
            decimal Qntys =txtQnty.Value==""?0: Convert.ToDecimal(txtQnty.Value);
            decimal Percentages = txtPercentage.Value==""?0:Convert.ToDecimal(txtPercentage.Value);
            string ddlCatogarySelected = string.Empty;
            ddlCatogarySelected = ddlcatogary.SelectedItem.Text == "Select" ? "0" : ddlcatogary.SelectedItem.Text;
            int result = objAdminController.InsertUpdateWorkerBAL(txtWorker.Value.Trim(), Convert.ToInt32(txtsalary.Value.Trim()), CurrentLoggedInUserID, machinecount, Obbased, ddlstaffvalue, Discription,
                OT1, OT2, OT3, OT4, isstaff, ddlCatogarySelected, measurment, Qntys, Percentages);
            if (result > 0)
            {

                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Worker type save successfully.','Manpower form');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                //Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "RestControlVal();", true);
                txtsalary.Value = "";
                txtWorker.Value = "";
                txtWorker.Focus();
                rdo_machinecount.Checked = false;
                rdo_machinecount2.Checked = false;
                obnased1.Checked = false;
                obnased2.Checked = false;
                DDl_Dept.SelectedValue = "-1";
                txt_discription.Text = "";
                txtOT1.Value = "";
                txtOT2.Value = "";
                txtOT3.Value = "";
                txtOT4.Value = "";
                txtmeasurement.Value = "";
                txtQnty.Value = "";
                txtPercentage.Value = "";
                ddlcatogary.SelectedValue = "-1";
                Divpercentage.Visible = false;
                bindgrd();

            }
            else if (result == -1)
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Duplicate Record Found.','Manpower form');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                // Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "RestControlVal();", true);
                txtsalary.Value = "";
                txtWorker.Value = "";
                txtWorker.Focus();
                rdo_machinecount.Checked = false;
                rdo_machinecount2.Checked = false;
                obnased1.Checked = false;
                obnased2.Checked = false;
                DDl_Dept.SelectedValue = "-1";
                txt_discription.Text = "";
                txtOT1.Value = "";
                txtOT2.Value = "";
                txtOT3.Value = "";
                txtOT4.Value = "";
                txtmeasurement.Value = "";
                txtQnty.Value = "";
                txtPercentage.Value = "";
                ddlcatogary.SelectedValue = "-1";
                Divpercentage.Visible = false;
                bindgrd();

            }
            else
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Record  not save .','Manpower form');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                // Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "RestControlVal();", true);
                txtsalary.Value = "";
                txtWorker.Value = "";
                txtWorker.Focus();
                rdo_machinecount.Checked = false;
                rdo_machinecount2.Checked = false;
                obnased1.Checked = false;
                obnased2.Checked = false;
                DDl_Dept.SelectedValue = "-1";
                txt_discription.Text = "";
                txtOT1.Value = "";
                txtOT2.Value = "";
                txtOT3.Value = "";
                txtOT4.Value = "";

                txtmeasurement.Value = "";
                txtQnty.Value = "";
                txtPercentage.Value = "";
                ddlcatogary.SelectedValue = "-1";
                Divpercentage.Visible = false;
                bindgrd();
            }




        }

        protected void grdCurrency_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //check if is in edit mode
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddl_Depart = (DropDownList)e.Row.FindControl("ddl_Depart");
                    if (ddl_Depart == null)
                    {

                    }
                    //bind dropdownlist
                    ddl_Depart.Items.Clear();

                    //ddlStaffItem = new ListItem("irornig", "4");
                    ddl_Depart.Items.Insert(0, new ListItem("Stitching"));
                    ddl_Depart.Items.Insert(1, new ListItem("Finishing"));
                    ddl_Depart.Items.Insert(2, new ListItem("Cutting"));
                    ddl_Depart.Items.Insert(3, new ListItem("Misc"));
                    ddl_Depart.Items.Insert(3, new ListItem("Xny"));
                    ddl_Depart.Items.Insert(4, new ListItem("Accessory"));
                    ddl_Depart.Items.Insert(5, new ListItem("R&D"));
                    ddl_Depart.Items.Insert(6, new ListItem("Fabric"));
                    
                     


                    DataRowView dr = e.Row.DataItem as DataRowView;
                    // ddl_Depart.SelectedItem.Text = dr["StaffDept"].ToString();
                    ddl_Depart.SelectedValue = dr["StaffDept"].ToString();
                    
                   

                    //Label txtCurrencySymbol = (Label)e.Row.FindControl("txtCurrencySymbol");
                    //txtCurrencySymbol.Text = Convert.ToDouble(objds.Tables[0].Rows[0]["ListPrice"].ToString()).ToString("#,##0");
                    Label lbl_MachineCount = (Label)e.Row.FindControl("lbl_MachineCount");
                    RadioButton rdo_machine_count1 = (RadioButton)e.Row.FindControl("rdo_machine_count1");
                    RadioButton rdo_machine_count2 = (RadioButton)e.Row.FindControl("rdo_machine_count2");
                    HiddenField hdn_Machine_count = (HiddenField)e.Row.FindControl("hdn_Machine_count");

                   

                    //txtCurrencySymbol...ToString("#,##0"); = txtCurrencySymbol.Text
                    if (dr["PartOfMachineCount"].ToString() == "True")
                    {
                        rdo_machine_count1.Checked = true;
                    }
                    else
                    {
                        rdo_machine_count2.Checked = true;
                    }
                    Label lbl_obsed = (Label)e.Row.FindControl("lbl_obsed");
                    RadioButton rdo_obased1 = (RadioButton)e.Row.FindControl("rdo_obased1");
                    RadioButton rdo_obased2 = (RadioButton)e.Row.FindControl("rdo_obased2");
                    //new
                    RadioButton rdo_isstaff1 = (RadioButton)e.Row.FindControl("rdo_isstaff1");
                    HiddenField hdn_Part_Of_MMR = (HiddenField)e.Row.FindControl("hdn_Part_Of_MMR");
                   

                    DropDownList ddl_Departgrd = (DropDownList)e.Row.FindControl("ddl_Departgrd");
                    //ddl_Departgrd.Items.Insert(-1, new ListItem("Select"));
                    //ddl_Departgrd.Items.Insert(1, new ListItem("Factory Based"));
                    //ddl_Departgrd.Items.Insert(2, new ListItem("Line Based"));
                    //ddl_Departgrd.Items.Insert(3, new ListItem("Floor Based"));
                    //ddl_Departgrd.Items.Insert(4, new ListItem("Pcs Per hour based"));
                    
                    

                    HtmlGenericControl diveditgrd = e.Row.FindControl("diveditgrd") as HtmlGenericControl;
                    TextBox txtMeasurementgrd = (TextBox)e.Row.FindControl("txtMeasurementgrd");

                    if (dr["StaffDept"].ToString() == "Cutting" || dr["StaffDept"].ToString() == "Finishing")
                    {
                        BindDllCatagorygrd(0, ddl_Departgrd);

                    }
                    else if (dr["StaffDept"].ToString() == "MISC" || dr["StaffDept"].ToString() == "Xny")
                    {
                        BindDllCatagorygrd(0, ddl_Departgrd);
                    }
                    else if (dr["StaffDept"].ToString() == "Stitching")
                    {
                        BindDllCatagorygrd(0, ddl_Departgrd);
                    }
                    else
                    {
                        BindDllCatagorygrd(0, ddl_Departgrd);
                    }
                    ListItem selectedListItem = ddl_Departgrd.Items.FindByText(dr["Category"].ToString());

                    if (selectedListItem != null)
                    {
                        selectedListItem.Selected = true;
                    }
                    else
                    {
                        ddl_Departgrd.SelectedValue = "-1";
                    }
                    //ddl_Departgrd.SelectedItem.Text = dr["Category"].ToString();
                    diveditgrd.Visible = dr["Category"].ToString() == "Pcs Per hour based" ? true : false;
                    txtMeasurementgrd.ReadOnly = dr["Category"].ToString() == "Pcs Per hour based" ? true : false;

                    if (dr["OBBased"].ToString() == "True")
                    {
                        rdo_obased1.Checked = true;
                    }
                    else
                    {
                        rdo_obased2.Checked = true;
                    }



                    //if (dr["IsFactoryStaff"].ToString() == "True")
                    //{
                    //    rdo_isstaff1.Checked = true;
                    //}
                    //else
                    //{
                    //    rdo_isstaff2.Checked = true;
                    //}



                    //Label lbl_OT1 = (Label)e.Row.FindControl("lbl_OT1");
                    //TextBox txt_OT1 = (TextBox)e.Row.FindControl("txt_OT1");







                }
                else
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        DataRowView dr = e.Row.DataItem as DataRowView;
                        CmtValue = dr["WorkingDays"].ToString();
                        hdn_cmt_workingdays.Value = dr["WorkingDays"].ToString();
                        //Label lbl_Machinattachment = (Label)e.Row.FindControl("lbl_Machinattachment");
                        Label lblmachine_counts = (Label)e.Row.FindControl("lbl_MachineCount");
                        Label lbl_obsed = (Label)e.Row.FindControl("lbl_obsed");
                        Label lbl_staff = (Label)e.Row.FindControl("lbl_staff");

                        Label lblMeasurement = (Label)e.Row.FindControl("lblMeasurement");
                        Label lblcatogary = (Label)e.Row.FindControl("lblcatogary");
                        HtmlGenericControl divgrd = e.Row.FindControl("divgrd") as HtmlGenericControl;
                        divgrd.Visible = lblcatogary.Text == "Pcs Per hour based" ? true : false;
                        lblMeasurement.Text = Math.Round(Convert.ToDecimal(lblMeasurement.Text),2).ToString(); ;
                        if (lblmachine_counts.Text == "True")
                        {
                            lblmachine_counts.Text = "YES";
                        }
                        else
                        {
                            lblmachine_counts.Text = "NO";
                        }

                        if (lbl_obsed.Text == "True")
                        {
                            lbl_obsed.Text = "OB Based";
                        }
                        else
                        {
                            lbl_obsed.Text = "Non OB based";
                        }

                        //if (lbl_staff.Text == "True")
                        //{
                        //    lbl_staff.Text = "YES";
                        //}
                        //else
                        //{
                        //    lbl_staff.Text = "NO";
                        //}




                    }



                }

            }

        }

        protected void grdCurrency_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            bindgrd();
            grdCurrency.PageIndex = e.NewPageIndex;
            grdCurrency.DataBind();

        }

        protected void ddlcatogary_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtmeasurement.Value = "";
            txtPercentage.Value = "";
            txtQnty.Value = "";

            int Val = Convert.ToInt32(ddlcatogary.SelectedValue);
            
            if (Val == 4)
            {
                txtmeasurement.Attributes.Add("readonly", "readonly");
                Divpercentage.Visible = true;
            }
            else
            
            {
               
                Divpercentage.Visible = false;
                // txtmeasurement.Attributes.Add("readonly", "");
                txtmeasurement.Attributes.Remove("readonly");
            }
            

        }

        protected void ddl_Departgrd_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl_Departgrd = (DropDownList)sender;
            GridViewRow row1 = (GridViewRow)ddl_Departgrd.NamingContainer;//get the 

            TextBox txtqntygrd = (TextBox)row1.FindControl("txtqntygrd");
            TextBox txtpercnetgrd = (TextBox)row1.FindControl("txtpercnetgrd");
            HtmlGenericControl diveditgrd = (HtmlGenericControl)row1.FindControl("diveditgrd");
            diveditgrd.Visible = ddl_Departgrd.SelectedItem.Text == "Pcs Per hour based" ? true : false;
            TextBox txtMeasurementgrd = (TextBox)row1.FindControl("txtMeasurementgrd");
            if (ddl_Departgrd.SelectedItem.Text != "Pcs Per hour based")
            {
                //txtMeasurementgrd.Attributes.Remove("readonly");
                txtMeasurementgrd.ReadOnly = false;
            }
            else
            {
                txtMeasurementgrd.ReadOnly = true;
               // txtMeasurementgrd.Attributes.Add("readonly", "readonly");
            }
            /*Reseting Control value when user chnage dropdown index*/
            txtqntygrd.Text = string.Empty;
            txtpercnetgrd.Text = string.Empty;
            txtMeasurementgrd.Text = string.Empty;
        }

        protected void txtqntygrd_TextChanged(object sender, EventArgs e)
        {
            TextBox txtqntygrds = (TextBox)sender;
            GridViewRow row1 = (GridViewRow)txtqntygrds.NamingContainer;//get the 

            TextBox txtqntygrd = (TextBox)row1.FindControl("txtqntygrd");
            TextBox txtpercnetgrd = (TextBox)row1.FindControl("txtpercnetgrd");
            TextBox txtMeasurementgrd = (TextBox)row1.FindControl("txtMeasurementgrd");
            string txtQnty = txtqntygrd.Text == "" ? "0" : txtqntygrd.Text;
            string txtPercen = txtpercnetgrd.Text == "" ? "0" : txtpercnetgrd.Text;
            string res = string.Empty; ;
            decimal Q;
            decimal P;
            if (txtQnty == "0" && txtPercen == "0")
            {
                return;
            }
            else
            {
                Q = Convert.ToInt32(txtQnty);
                P = Convert.ToInt32(txtPercen);
            }
            decimal Res = Math.Round(Q * P / 100,2);
            txtMeasurementgrd.Text = Res.ToString();
        }

        protected void txtpercnetgrd_TextChanged(object sender, EventArgs e)
        {
            TextBox txtqntygrds = (TextBox)sender;
            GridViewRow row1 = (GridViewRow)txtqntygrds.NamingContainer;//get the 

            TextBox txtqntygrd = (TextBox)row1.FindControl("txtqntygrd");
            TextBox txtpercnetgrd = (TextBox)row1.FindControl("txtpercnetgrd");
            TextBox txtMeasurementgrd = (TextBox)row1.FindControl("txtMeasurementgrd");
            string txtQnty = txtqntygrd.Text == "" ? "0" : txtqntygrd.Text;
            string txtPercen = txtpercnetgrd.Text == "" ? "0" : txtpercnetgrd.Text;

            string res = string.Empty; ;
            decimal Q;
            decimal P;
            if (txtQnty == "0" && txtPercen == "0")
            {
                return;
            }
            else
            {
                Q = Convert.ToInt32(txtQnty);
                P = Convert.ToInt32(txtPercen);
            }
            decimal Res = Math.Round(Q * P / 100,2);
            txtMeasurementgrd.Text = Res.ToString();
            

        }
        public void BindDllCatagory(int FilteOption)
        {
            DataTable table = new DataTable();
            table.Clear();
            ddlcatogary.Items.Clear();

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("catogary", typeof(string));
            FilteOption = 2;
            switch (FilteOption)
            {
                case 0:

                    table.Rows.Add(-1, "Select");
                    table.Rows.Add(1, "Factory Based");
                    table.Rows.Add(2, "Line Based");
                    table.Rows.Add(3, "Floor Based");
                    table.Rows.Add(4, "Pcs Per hour based");

                    ddlcatogary.DataSource = table;
                    ddlcatogary.DataTextField = table.Columns["catogary"].ToString();
                    ddlcatogary.DataValueField = table.Columns["ID"].ToString();
                    ddlcatogary.DataBind();
                    break;

                case 1:
                case 2:
            
                    table.Rows.Add(-1, "Select");
                    table.Rows.Add(1, "Factory Based");
                    table.Rows.Add(2, "Line Based");
                    table.Rows.Add(3, "Floor Based");
                    table.Rows.Add(4, "Pcs Per hour based");

                    ddlcatogary.DataSource = table;
                    ddlcatogary.DataTextField = table.Columns["catogary"].ToString();
                    ddlcatogary.DataValueField = table.Columns["ID"].ToString();
                    ddlcatogary.DataBind();
                    break;
                case 3:
                case 4:
                    table.Rows.Add(-1, "Select");
                    //table.Rows.Add(1, "Factory Based");
                    //table.Rows.Add(2, "Line Based");
                    //table.Rows.Add(3, "Floor Based");
                   // table.Rows.Add(4, "Pcs Per hour based");

                    ddlcatogary.DataSource = table;
                    ddlcatogary.DataTextField = table.Columns["catogary"].ToString();
                    ddlcatogary.DataValueField = table.Columns["ID"].ToString();
                    ddlcatogary.DataBind();
                    break;
                default:


                   table.Rows.Add(-1, "Select");
                    table.Rows.Add(1, "Factory Based");
                    table.Rows.Add(2, "Line Based");
                    table.Rows.Add(3, "Floor Based");
                    table.Rows.Add(4, "Pcs Per hour based");

                    ddlcatogary.DataSource = table;
                    ddlcatogary.DataTextField = table.Columns["catogary"].ToString();
                    ddlcatogary.DataValueField = table.Columns["ID"].ToString();
                    ddlcatogary.DataBind();
                    break;
            }

        }
        public void BindDllCatagorygrd(int FilteOption, DropDownList ddl)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            ddl.Items.Clear();

            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("catogary", typeof(string));



            switch (FilteOption)
            {
                case 0:

                    dt.Rows.Add(-1, "Select");
                    dt.Rows.Add(1, "Factory Based");
                    dt.Rows.Add(2, "Line Based");
                    dt.Rows.Add(3, "Floor Based");
                    dt.Rows.Add(4, "Pcs Per hour based");

                    ddl.DataSource = dt;
                    ddl.DataTextField = dt.Columns["catogary"].ToString();
                    ddl.DataValueField = dt.Columns["ID"].ToString();
                    ddl.DataBind();
                    break;

                case 1:
                case 2:

                    dt.Rows.Add(-1, "Select");
                    dt.Rows.Add(1, "Factory Based");
                    //table.Rows.Add(2, "Line Based");
                    dt.Rows.Add(3, "Floor Based");
                    dt.Rows.Add(4, "Pcs Per hour based");

                    ddl.DataSource = dt;
                    ddl.DataTextField = dt.Columns["catogary"].ToString();
                    ddl.DataValueField = dt.Columns["ID"].ToString();
                    ddl.DataBind();
                    break;
                case 3:
                case 4:
                    dt.Rows.Add(-1, "Select");
                    //table.Rows.Add(1, "Factory Based");
                    //table.Rows.Add(2, "Line Based");
                    //table.Rows.Add(3, "Floor Based");
                    // table.Rows.Add(4, "Pcs Per hour based");

                    ddl.DataSource = dt;
                    ddl.DataTextField = dt.Columns["catogary"].ToString();
                    ddl.DataValueField = dt.Columns["ID"].ToString();
                    ddl.DataBind();
                    break;
                default:


                    dt.Rows.Add(-1, "Select");
                    dt.Rows.Add(1, "Factory Based");
                    dt.Rows.Add(2, "Line Based");
                    dt.Rows.Add(3, "Floor Based");
                    dt.Rows.Add(4, "Pcs Per hour based");

                    ddl.DataSource = dt;
                    ddl.DataTextField = dt.Columns["catogary"].ToString();
                    ddl.DataValueField = dt.Columns["ID"].ToString();
                    ddl.DataBind();
                    break;
            }

        }
        protected void DDl_Dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            Divpercentage.Visible = false;
            int Option = Convert.ToInt32(DDl_Dept.SelectedValue);
            BindDllCatagory(Option);



        }

        protected void ddl_Depart_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl_Depart = (DropDownList)sender;
            GridViewRow row1 = (GridViewRow)ddl_Depart.NamingContainer;
            DropDownList ddl_Departgrd = (DropDownList)row1.FindControl("ddl_Departgrd");
            TextBox txtMeasurementgrd = (TextBox)row1.FindControl("txtMeasurementgrd");
            int option = ddl_Depart.SelectedIndex.ToString() == "-1" ? 3 : Convert.ToInt32(ddl_Depart.SelectedIndex.ToString());
            BindDllCatagorygrd(0, ddl_Departgrd);
            txtMeasurementgrd.Text = string.Empty;
            
            HtmlGenericControl diveditgrd = (HtmlGenericControl)row1.FindControl("diveditgrd");
            diveditgrd.Visible = false;
           

        }
        protected void txtSalary_TextChanged(object sender, EventArgs e)
        { 
            TextBox txtqntygrds = (TextBox)sender;
            GridViewRow row1 = (GridViewRow)txtqntygrds.NamingContainer;//get the 
            TextBox txtSalary = (TextBox)row1.FindControl("txtSalary");

            TextBox txt_OT1 = (TextBox)row1.FindControl("txt_OT1");
            TextBox txt_OT2 = (TextBox)row1.FindControl("txt_OT2");
            TextBox txt_OT3 = (TextBox)row1.FindControl("txt_OT3");
            TextBox txt_OT4 = (TextBox)row1.FindControl("txt_OT4");
            if (txtSalary.Text != "")
            { //ot = (Math.round(Math.round(otcount / 24.33 / 8) * 1.1)).toFixed(0);
                decimal d = 1.1M;
                //decimal wk=24.33m;
                decimal wk = Convert.ToDecimal(hdn_cmt_workingdays.Value);
                decimal result = Math.Round(Math.Round( Convert.ToDecimal(txtSalary.Text) /wk/8)* d);
                txt_OT1.Text = result.ToString();
                txt_OT2.Text= result.ToString();
                txt_OT3.Text=result.ToString();
                txt_OT4.Text = result.ToString();
            }
           
           
        }
       
        
    }
}