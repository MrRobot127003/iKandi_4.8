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
using System.Text.RegularExpressions;


namespace iKandi.Web.UserControls.Forms
{

    public partial class FrmFactoryLineAdmin : System.Web.UI.UserControl
    {

        AdminController objadmin = new AdminController();

        public string UserId
        {

            get;

            set;

        }
        public string Cutting_ck
        {
            get;
            set;
        }
        public string finishing_ck
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            UserId = ApplicationHelper.LoggedInUser.UserData.UserID.ToString();

            if (!Page.IsPostBack)
            {

                BindGrd();

                //bindDropDownList();

                txtserach.Text = "";

                updaterec();

            }

        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {

            //string s=rdolistfillter.SelectedValue;

            //int all=-2;

            //int act=-2;

            int inactall = -2;



            if (rdo_ALL.Checked == true)
            {

                inactall = Convert.ToInt32(rdo_ALL.Value);

            }

            if (rdo_Active.Checked == true)
            {

                inactall = Convert.ToInt32(rdo_Active.Value);

            }

            if (rdo_in_active.Checked == true)
            {

                inactall = Convert.ToInt32(rdo_in_active.Value);

            }

            // Convert.ToInt32(rdolistfillter.SelectedValue

            getFilterReccord(txtserach.Text, inactall);

        }



        private void BindGrd()
        {

            grdslot.DataSource = objadmin.getslotdetails();

            grdslot.DataBind();

        }



        public void getFilterReccord(string Searchtxt, int IsAct)
        {

            DataTable dt = new DataTable();

            dt = objadmin.getfillterrecord(Searchtxt, IsAct);

            grdslot.DataSource = dt;

            grdslot.DataBind();

            //bindDropDownList();

        }



        protected void bindDropDownList()
        {

            try
            {

                DataTable dt1 = new DataTable();

                DataTable dt2 = new DataTable();

                DataSet ds = new DataSet();

                ds = objadmin.GetLinedesignationDetails();

                dt1 = ds.Tables[0];

                dt2 = ds.Tables[1];



                DropDownList ddlDesignationFooter = grdslot.FooterRow.FindControl("ddlDesignationFooter") as DropDownList;

                DropDownList ddlFactoryFooter = grdslot.FooterRow.FindControl("ddlFactoryFooter") as DropDownList;

                ddlDesignationFooter.DataSource = dt1;

                ddlDesignationFooter.DataValueField = "LineDesignationID";

                ddlDesignationFooter.DataTextField = "Name";

                ddlDesignationFooter.DataBind();

                ddlFactoryFooter.DataSource = dt2;

                ddlFactoryFooter.DataValueField = "Id";

                ddlFactoryFooter.DataTextField = "Name";

                ddlFactoryFooter.DataBind();





                ddlDesignationFooter.Items.Insert(0, new ListItem("Select", "-1"));

                ddlFactoryFooter.Items.Insert(0, new ListItem("Select", "-1"));

            }

            catch (Exception sqlex)
            {

                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), sqlex.Message, sqlex.StackTrace));

            }

        }

        TextBox txtname = null;

        protected void grdslot_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                DropDownList ddlDesignation_1 = (DropDownList)e.Row.FindControl("ddlDesignationItem") as DropDownList;
                ddlDesignation_1.SelectedIndexChanged += new EventHandler(ddlDesignation_1_SelectedIndexChanged);
                DropDownList ddlFactory_1 = (DropDownList)e.Row.FindControl("ddlFactoryItem") as DropDownList;
                HiddenField hdnDesignationItem = (HiddenField)e.Row.FindControl("hdnDesignationItem") as HiddenField;
                HiddenField hdnFactoryItem = (HiddenField)e.Row.FindControl("hdnFactoryItem") as HiddenField;
                HiddenField hdnID = (HiddenField)e.Row.FindControl("hdnID") as HiddenField;

                //RadioButtonList rbtnIsActiveItem = (RadioButtonList)e.Row.FindControl("rbtnIsActiveItem") as RadioButtonList;

                HtmlInputRadioButton rdo_active = (HtmlInputRadioButton)e.Row.FindControl("rdo_active") as HtmlInputRadioButton;



                HtmlInputRadioButton rdo_inactive = (HtmlInputRadioButton)e.Row.FindControl("rdo_inactive") as HtmlInputRadioButton;



                TextBox txtNameItem = (TextBox)e.Row.FindControl("txtNameItem") as TextBox;

                txtname = txtNameItem;



                HtmlInputCheckBox chk_stitching = (HtmlInputCheckBox)e.Row.FindControl("chk_stitching") as HtmlInputCheckBox;

                HtmlInputCheckBox Chk_Finishing = (HtmlInputCheckBox)e.Row.FindControl("Chk_Finishing") as HtmlInputCheckBox;

                HtmlInputCheckBox Chk_cutting = (HtmlInputCheckBox)e.Row.FindControl("Chk_cutting") as HtmlInputCheckBox;



                HiddenField hdnhdnstiching = (HiddenField)e.Row.FindControl("hdnstiching") as HiddenField;

                HiddenField hdnfinshing = (HiddenField)e.Row.FindControl("hdnfinshing") as HiddenField;

                HiddenField hdncutting = (HiddenField)e.Row.FindControl("hdncutting") as HiddenField;



                HiddenField hdn_cutting_act = (HiddenField)e.Row.FindControl("hdn_cutting_act") as HiddenField;

                HiddenField hdn_finishing_act = (HiddenField)e.Row.FindControl("hdn_finishing_act") as HiddenField;









                if (hdnhdnstiching.Value.ToUpper() == "TRUE")
                {

                    chk_stitching.Checked = true;



                }

                else
                {

                    chk_stitching.Checked = false;

                }

                if (hdnfinshing.Value.ToUpper() == "TRUE")
                {

                    Chk_Finishing.Checked = true;

                }

                else
                {

                    Chk_Finishing.Checked = false;

                    //Chk_Finishing.Disabled = true;

                }

                if (hdncutting.Value.ToUpper() == "TRUE")
                {

                    Chk_cutting.Checked = true;

                }

                else
                {

                    Chk_cutting.Checked = false;

                    //Chk_cutting.Disabled = true;

                }





                if (hdn_finishing_act.Value.ToUpper() == "TRUE")
                {

                    Chk_Finishing.Disabled = true;

                }

                else
                {

                    Chk_Finishing.Disabled = false;

                }

                if (hdn_cutting_act.Value.ToUpper() == "TRUE")
                {

                    Chk_cutting.Disabled = true;

                }

                else
                {

                    Chk_cutting.Disabled = false;

                }





                HiddenField hdnIsActive = (HiddenField)e.Row.FindControl("hdnIsActive") as HiddenField;



                DataRowView dr = e.Row.DataItem as DataRowView;



                if (hdnIsActive.Value.ToUpper() == "TRUE")
                {

                    rdo_active.Checked = true;



                    //Chk_cutting.Disabled = false;

                    //Chk_Finishing.Disabled = false;

                    //chk_stitching.Disabled = false;



                    //ddlFactory_1.Enabled = true;

                }

                else
                {

                    rdo_inactive.Checked = true;



                    //Chk_cutting.Disabled = true;

                    //Chk_Finishing.Disabled = true;

                    //chk_stitching.Disabled = true;



                    //ddlFactory_1.Enabled = false;

                }

                DataTable dt1 = new DataTable();

                DataTable dt2 = new DataTable();

                DataSet ds = new DataSet();

                ds = objadmin.GetLinedesignationDetails();

                dt1 = ds.Tables[0];

                dt2 = ds.Tables[1];



                ddlDesignation_1.DataSource = dt1;

                ddlDesignation_1.DataValueField = "LineDesignationID";

                ddlDesignation_1.DataTextField = "Name";

                ddlDesignation_1.DataBind();



                if (hdnDesignationItem != null)
                {

                    ddlDesignation_1.SelectedValue = hdnDesignationItem.Value;

                }



                ddlFactory_1.DataSource = dt2;

                ddlFactory_1.DataValueField = "Id";

                ddlFactory_1.DataTextField = "Name";

                ddlFactory_1.DataBind();



                if (hdnFactoryItem != null)
                {



                    ddlFactory_1.SelectedValue = hdnFactoryItem.Value;

                    //----this code for map stitching and cutting finshing check box link with Manage production admin produtction------------//

                    int SelectedUnitID = Convert.ToInt32(hdnFactoryItem.Value);

                    DataTable dt = new DataTable();

                    //dt = GetFactorynames(SelectedUnitID, Convert.ToInt32(id.Value));

                    dt = GetFactorynamesforfoter(SelectedUnitID);

                    int cutting;
                    
                    if (dt.Rows[0]["Cuttingtrue"] == DBNull.Value)
                    {
                        cutting = -1;
                    }

                    else
                    {

                        cutting = Convert.ToInt32(dt.Rows[0]["Cuttingtrue"]);


                        if (dt.Rows[0]["Cuttingtrue"].ToString() == "True")
                        {

                            Chk_cutting.Disabled = true;

                        }
                        else
                        {
                            Chk_cutting.Disabled = false;

                        }

                    }

                    if (dt.Rows[0]["finishingtrue"] == DBNull.Value)
                    {



                    }

                    else
                    {


                        if (dt.Rows[0]["finishingtrue"].ToString() == "True")
                        {
                            Chk_Finishing.Disabled = true;

                        }
                        else
                        {
                            Chk_Finishing.Disabled = false;
                        }


                    }

                    //if (hdnIsActive.Value.ToUpper() == "TRUE")
                    //{

                    //    rdo_active.Checked = true;



                    //    Chk_cutting.Disabled = false;

                    //    Chk_Finishing.Disabled = false;

                    //    chk_stitching.Disabled = false;



                    //    ddlFactory_1.Enabled = true;

                    //}

                    //else
                    //{

                    //    rdo_inactive.Checked = true;



                    //    Chk_cutting.Disabled = true;

                    //    Chk_Finishing.Disabled = true;

                    //    chk_stitching.Disabled = true;



                    //    ddlFactory_1.Enabled = false;

                    //}



                    //----end-------------------------------------------------------------------------------------------------------------------//

                }

            }



            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {

                Table tblGrdviewApplet = (Table)grdslot.Controls[0];

                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];

                DropDownList ddlDesignationEmpty = (DropDownList)rows.FindControl("ddlDesignationEmpty") as DropDownList;

                DropDownList ddlFactoryEmpty = (DropDownList)rows.FindControl("ddlFactoryEmpty") as DropDownList;



                DataTable dt1 = new DataTable();

                DataTable dt2 = new DataTable();

                DataSet ds = new DataSet();

                ds = objadmin.GetLinedesignationDetails();

                dt1 = ds.Tables[0];

                dt2 = ds.Tables[1];



                ddlDesignationEmpty.DataSource = dt1;

                ddlDesignationEmpty.DataValueField = "LineDesignationID";

                ddlDesignationEmpty.DataTextField = "Name";

                ddlDesignationEmpty.DataBind();



                ddlFactoryEmpty.DataSource = dt2;

                ddlFactoryEmpty.DataValueField = "Id";

                ddlFactoryEmpty.DataTextField = "Name";

                ddlFactoryEmpty.DataBind();





            }

        }



        protected void grdslot_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Insert")
            {

                DataSet ds = new DataSet();

                Table tblGrdviewApplet = (Table)grdslot.Controls[0];

                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];



                TextBox txtNameItem = grdslot.FooterRow.FindControl("txtNameFooter") as TextBox;



                DropDownList ddlDesignationItem = grdslot.FooterRow.FindControl("ddlDesignationFooter") as DropDownList;

                RadioButtonList rbtnIsActiveFooter = grdslot.FooterRow.FindControl("rbtnIsActiveFooter") as RadioButtonList;

                DropDownList ddlFactoryEmpty = grdslot.FooterRow.FindControl("ddlFactoryFooter") as DropDownList;



                int stiching;

                int finshing;

                int cutting;



                //RadioButtonList rbtnIsfinshing_footer = grdslot.FooterRow.FindControl("rbtnIsfinshing_footer") as RadioButtonList;

                // int selectedvalue = rbtnIsfinshing_footer.SelectedValue == "" ? -1 : Convert.ToInt32(rbtnIsfinshing_footer.SelectedValue);



                //int selectedvalue = Convert.ToInt32(rbtnIsfinshing_footer.SelectedValue);



                CheckBox chk_footer_stitching = grdslot.FooterRow.FindControl("chk_footer_stitching") as CheckBox;

                CheckBox Chk_footer_Finishing = grdslot.FooterRow.FindControl("Chk_footer_Finishing") as CheckBox;

                CheckBox Chk_footer_cutting = grdslot.FooterRow.FindControl("Chk_footer_cutting") as CheckBox;



                if (chk_footer_stitching.Checked == true)
                {

                    stiching = 1;

                }

                else
                {

                    stiching = 0;

                }

                if (Chk_footer_Finishing.Checked == true)
                {

                    finshing = 1;

                }

                else
                {

                    finshing = 0;

                }

                if (Chk_footer_cutting.Checked == true)
                {

                    cutting = 1;

                }

                else
                {

                    cutting = 0;

                }
                if (stiching == 0 && finshing == 0 && cutting == 0)
                {
                    string script = string.Empty;

                    script = "ShowHideMessageBox(true, 'Value not save .! & at least one department association check box should be check','');";

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

                    return;
 
                }


                if (ddlDesignationItem.SelectedValue == "-1")
                {

                    string script = string.Empty;

                    script = "ShowHideMessageBox(true, 'select designation first','');";

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

                    return;

                }

                if (txtNameItem.Text == "")
                {

                    string script = string.Empty;

                    script = "ShowHideMessageBox(true, 'Enter name','');";

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

                    return;

                }

                if (rbtnIsActiveFooter.SelectedValue == "")
                {

                    string script = string.Empty;

                    script = "ShowHideMessageBox(true, 'select active or in in active','');";

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

                    return;

                }

                if (ddlFactoryEmpty.SelectedValue == "-1")
                {

                    string script = string.Empty;

                    script = "ShowHideMessageBox(true, 'select factory','');";

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

                    return;

                }

                //if (rbtnIsfinshing_footer.SelectedValue == "" || selectedvalue==-1)

                //{

                //    string script = string.Empty;

                //    script = "ShowHideMessageBox(true, 'Select At least one of them (Stitching, Finishing, Cutting)','');";

                //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

                //    return;

                //}



                int ddldesignationid = Convert.ToInt32(ddlDesignationItem.SelectedValue);

                int Isactive = Convert.ToInt32(rbtnIsActiveFooter.SelectedValue);

                string txtname = txtNameItem.Text;

                int ddlfactoryID = Convert.ToInt32(ddlFactoryEmpty.SelectedValue);

                int CurrentLoggedInUserID = ApplicationHelper.LoggedInUser.UserData.UserID;



                String Validname = @"/[@,.}{@?;'\/|123456789]";

                if (Regex.IsMatch(txtNameItem.Text, Validname))
                {

                    string script = string.Empty;

                    script = "ShowHideMessageBox(true, 'Line Designation name should be start with letter.!','');";

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

                    return;

                }

                String Validname2 = @"/[a-zA-Z]/";

                if (Regex.IsMatch(txtNameItem.Text, Validname2))
                {

                    string script = string.Empty;

                    script = "ShowHideMessageBox(true, 'Entered Line Designation name not valid.!','');";

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

                    return;

                }



                string firstword = txtNameItem.Text.Substring(0, 1);



                if (firstword == "@" || firstword == "/" || firstword == "'" || firstword == "1" || firstword == "2" || firstword == "3" || firstword == "4" || firstword == "5" || firstword == "6" || firstword == "7" || firstword == "8" || firstword == "9" || firstword == "." || firstword == "0" || firstword == "=" || firstword == ":" || firstword == "?" || firstword == "," || firstword == "*" || firstword == "(" || firstword == ")" || firstword == "*" || firstword == "/")
                {

                    string script = string.Empty;

                    script = "ShowHideMessageBox(true, 'Line Designation name should be start with letter.!','');";

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

                    return;

                }





                int result = objadmin.InsertUpdateLineDesignation(ddldesignationid, ddlfactoryID, Isactive, CurrentLoggedInUserID, txtname, stiching, finshing, cutting);

                if (result == -1)
                {

                    string SussMsg = string.Empty;



                    SussMsg = "ShowHideMessageBox(true, 'Record already exists ','');";

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", SussMsg, true);

                    BindGrd();

                    //bindDropDownList();

                }

                else
                {

                    string SussMsg = string.Empty;



                    SussMsg = "ShowHideMessageBox(true, 'Record add successfully','');";

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", SussMsg, true);



                    BindGrd();

                    //bindDropDownList();

                }





            }



            if (e.CommandName == "addnew")
            {

                DataSet ds = new DataSet();

                Table tblGrdviewApplet = (Table)grdslot.Controls[0];

                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];



                TextBox txtemptyname = (TextBox)rows.FindControl("txtNameEmpty") as TextBox;



                DropDownList ddlDesignationEmpty = (DropDownList)rows.FindControl("ddlDesignationEmpty") as DropDownList;

                RadioButtonList rdolist = (RadioButtonList)rows.FindControl("rbtnIsActiveItemEmpty") as RadioButtonList;



                DropDownList ddlFactoryEmpty = (DropDownList)rows.FindControl("ddlFactoryEmpty") as DropDownList;

                //RadioButtonList rbtnIsfinshing_add = (RadioButtonList)rows.FindControl("rbtnIsfinshing_add") as RadioButtonList;

                int stiching;

                int finshing;

                int cutting;

                // rbtnIsfinshing_add.SelectedValue == "" ? -1 : Convert.ToInt32(rbtnIsfinshing_add.SelectedValue);

                // int selectedvalue = rbtnIsfinshing_add.SelectedValue == "" ? -1 : Convert.ToInt32(rbtnIsfinshing_add.SelectedValue);





                //HtmlInputCheckBox chk_stitching_empty = grdslot.FooterRow.FindControl("chk_stitching_empty") as HtmlInputCheckBox;

                //HtmlInputCheckBox Chk_Finishing_empty = grdslot.FooterRow.FindControl("Chk_Finishing_empty") as HtmlInputCheckBox;

                //HtmlInputCheckBox Chk_cutting_empty = grdslot.FooterRow.FindControl("Chk_cutting_empty") as HtmlInputCheckBox;



                HtmlInputCheckBox chk_stitching_empty = (HtmlInputCheckBox)rows.FindControl("chk_stitching_empty") as HtmlInputCheckBox;

                HtmlInputCheckBox Chk_Finishing_empty = (HtmlInputCheckBox)rows.FindControl("Chk_Finishing_empty") as HtmlInputCheckBox;

                HtmlInputCheckBox Chk_cutting_empty = (HtmlInputCheckBox)rows.FindControl("Chk_cutting_empty") as HtmlInputCheckBox;



                if (chk_stitching_empty.Checked == true)
                {

                    stiching = 1;

                }

                else
                {

                    stiching = 0;

                }

                if (Chk_Finishing_empty.Checked == true)
                {

                    finshing = 1;

                }

                else
                {

                    finshing = 0;

                }

                if (Chk_cutting_empty.Checked == true)
                {

                    cutting = 1;

                }

                else
                {

                    cutting = 0;

                }



                if (ddlDesignationEmpty.SelectedValue == "-1")
                {

                    string script = string.Empty;

                    script = "ShowHideMessageBox(true, 'select designation first','');";

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

                    return;

                }

                if (txtemptyname.Text == "")
                {

                    string script = string.Empty;

                    script = "ShowHideMessageBox(true, 'Enter name','');";

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

                    return;

                }

                if (rdolist.SelectedValue == "")
                {

                    string script = string.Empty;

                    script = "ShowHideMessageBox(true, 'select Active or in active','');";

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

                    return;

                }

                if (ddlFactoryEmpty.SelectedValue == "-1")
                {

                    string script = string.Empty;

                    script = "ShowHideMessageBox(true, 'select factory','');";

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

                    return;

                }



                int ddldesignationid = Convert.ToInt32(ddlDesignationEmpty.SelectedValue);

                int Isactive = Convert.ToInt32(rdolist.SelectedValue);

                string txtname = txtemptyname.Text;

                int ddlfactoryID = Convert.ToInt32(ddlFactoryEmpty.SelectedValue);

                int CurrentLoggedInUserID = ApplicationHelper.LoggedInUser.UserData.UserID;

                int result = objadmin.InsertUpdateLineDesignation(ddldesignationid, ddlfactoryID, Isactive, CurrentLoggedInUserID, txtname, stiching, finshing, cutting);



                string SussMsg = string.Empty;

                SussMsg = "ShowHideMessageBox(true, 'Record add successfully','');";

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", SussMsg, true);



                BindGrd();

            }

        }



        //protected void rdolistfillter_SelectedIndexChanged(object sender, EventArgs e)

        //{

        //    getFilterReccord(txtserach.Text, Convert.ToInt32(rdolistfillter.SelectedValue));



        //}

        protected void ddlDesignation_1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Reset Textbox..name

            txtname.Text = "";

            txtname.Focus();





        }



        protected void ddlFactoryItem_SelectedIndexChanged(object sender, EventArgs e)
        {

            DropDownList ddlSpin2 = (DropDownList)sender;

            GridViewRow gridrow = (GridViewRow)ddlSpin2.NamingContainer;

            int rowIndex = gridrow.RowIndex;



            // GridViewRow gvrow = gridrow.RowIndex.

            HiddenField unitid = new HiddenField();

            HiddenField id = new HiddenField();



            unitid = (HiddenField)grdslot.Rows[rowIndex].FindControl("hdnFactoryItem");

            id = (HiddenField)grdslot.Rows[rowIndex].FindControl("hdnID");



            HtmlInputCheckBox chk_stitching = (HtmlInputCheckBox)grdslot.Rows[rowIndex].FindControl("chk_stitching") as HtmlInputCheckBox;


            HtmlInputCheckBox Chk_Finishing = (HtmlInputCheckBox)grdslot.Rows[rowIndex].FindControl("Chk_Finishing") as HtmlInputCheckBox;

            // HtmlInputCheckBox Chk_cutting = (HtmlInputCheckBox)grdslot.Rows[rowIndex].FindControl("Chk_cutting") as HtmlInputCheckBox;



            //HtmlInputCheckBox Chk_cutting = (HtmlInputCheckBox)grdslot.Rows[rowIndex].FindControl("Chk_cutting") as HtmlInputCheckBox;
            var Chk_cutting = (HtmlInputCheckBox)grdslot.Rows[rowIndex].FindControl("Chk_cutting");

            HiddenField hdnCuttingCheck = (HiddenField)grdslot.Rows[rowIndex].FindControl("hdnCuttingCheck") as HiddenField;
            HiddenField hdnFinshingCheck = (HiddenField)grdslot.Rows[rowIndex].FindControl("hdnFinshingCheck") as HiddenField;



            //HiddenField hdnFactoryItem = (HiddenField)gridrow.RowIndex..FindControl("hdnFactoryItem");

            //HiddenField hdnID = (HiddenField)gridrow.FindControl("hdnID");



            int SelectedUnitID = Convert.ToInt32(ddlSpin2.SelectedValue);





            DataTable dt = new DataTable();

            //dt = GetFactorynames(SelectedUnitID, Convert.ToInt32(id.Value));

            dt = GetFactorynamesforfoter(SelectedUnitID);



            int cutting = -1;

            int finshing;



            if (dt.Rows[0]["Cuttingtrue"] == DBNull.Value)
            {



                cutting = -1;
                Cutting_ck = "-1";



            }

            else
            {

                cutting = Convert.ToInt32(dt.Rows[0]["Cuttingtrue"]);

                if (hdnCuttingCheck != null)
                {
                    if (dt.Rows[0]["Cuttingtrue"].ToString() == "True")
                    {
                        hdnCuttingCheck.Value = "1";
                        Cutting_ck = dt.Rows[0]["Cuttingtrue"].ToString();
                        Chk_cutting.Disabled = true;

                    }
                    else
                    {
                        hdnCuttingCheck.Value = "-1";
                    }

                }

            }

            if (dt.Rows[0]["finishingtrue"] == DBNull.Value)
            {

                finshing = -1;
                finishing_ck = "-1";

            }

            else
            {


                if (dt.Rows[0]["finishingtrue"].ToString() == "True")
                {
                    finshing = Convert.ToInt32(dt.Rows[0]["finishingtrue"]);



                    hdnFinshingCheck.Value = "1";
                    finishing_ck = dt.Rows[0]["finishingtrue"].ToString();

                }
                else
                {
                    hdnFinshingCheck.Value = "-1";
                }


            }






            //BindGrd();
            // bindDropDownList();


            //string jsFunc = "myFunc()";
            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "myJsFn", jsFunc, true);


            //Chk_cutting.Disabled = true;

            //Reset Textbox..name

            //txtname.Text = "";

            //txtname.Focus();







        }

        public DataTable GetFactorynames(int unitID, int id)
        {

            DataTable dt = new DataTable();

            dt = objadmin.GetFactorynames(unitID, id);

            return dt;

        }





        public DataTable GetFactorynamesforfoter(int unitID)
        {

            DataTable dt = new DataTable();

            dt = objadmin.GetFactorynamesforfoter(unitID);

            return dt;

        }



        protected void ddlFactoryFooter_SelectedIndexChanged(object sender, EventArgs e)
        {

            DropDownList ddlSpin2footer = (DropDownList)sender;

            GridViewRow gridrowfootter = (GridViewRow)ddlSpin2footer.NamingContainer;
            DropDownList ddl_factoryUnit = grdslot.FooterRow.FindControl("ddlFactoryFooter") as DropDownList;
            DropDownList ddlDesignationFooter = grdslot.FooterRow.FindControl("ddlDesignationFooter") as DropDownList;

            CheckBox chk_footer_stitching = grdslot.FooterRow.FindControl("chk_footer_stitching") as CheckBox;

            CheckBox Chk_footer_Finishing = grdslot.FooterRow.FindControl("Chk_footer_Finishing") as CheckBox;

            CheckBox Chk_footer_cutting = grdslot.FooterRow.FindControl("Chk_footer_cutting") as CheckBox;



            int UnitId = Convert.ToInt32(ddl_factoryUnit.SelectedValue);

            DataTable dt = new DataTable();

            dt = GetFactorynamesforfoter(UnitId);



            int cutting;

            int finshing;



            if (dt.Rows[0]["Cuttingtrue"] == DBNull.Value)
            {



                cutting = -1;

            }

            else
            {

                cutting = Convert.ToInt32(dt.Rows[0]["Cuttingtrue"]);

            }

            if (dt.Rows[0]["finishingtrue"] == DBNull.Value)
            {

                finshing = -1;

            }

            else
            {

                finshing = Convert.ToInt32(dt.Rows[0]["finishingtrue"]);

            }



            if (cutting == 1)
            {

                Chk_footer_cutting.Checked = false;
                Chk_footer_cutting.Enabled = false;


            }

            else
            {

                Chk_footer_cutting.Enabled = true;

            }

            if (finshing == 1)
            {
                Chk_footer_Finishing.Checked = false;

                Chk_footer_Finishing.Enabled = false;

            }

            else
            {
                Chk_footer_Finishing.Enabled = true;
            }


            //var firstitemFactoryNAme = ddl_factoryUnit.Items[0];

            //var firstLineDesignation = ddlDesignationFooter.Items[0];

            //var ddl_factoryUnit_selectedVal = ddl_factoryUnit.SelectedValue;

            //var ddl_firstLineDesignation_selectedVal = ddlDesignationFooter.SelectedValue;



            //ddl_factoryUnit.Items.Clear();

            //ddl_factoryUnit.Items.Add(firstitemFactoryNAme);



            //ddlDesignationFooter.Items.Clear();

            //ddlDesignationFooter.Items.Add(firstLineDesignation);



            //ddl_factoryUnit.SelectedValue = ddl_factoryUnit_selectedVal;



            //ddlDesignationFooter.SelectedValue = ddl_firstLineDesignation_selectedVal;

            //bindDropDownList();



        }

        public void updaterec()
        {
            DataSet ds = objadmin.getslotdetails();
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                int DesignationID; int factoryId; int IsAct; int UserId; string Name; int id; int stiching; int finishing; int cutting;
                DesignationID = Convert.ToInt32(dr["LineDesignationID"].ToString());
                factoryId = Convert.ToInt32(dr["UnitID"].ToString());
                IsAct = Convert.ToInt32(dr["IsActive"]);
                UserId = 2;
                Name = dr["LineDesignationName"].ToString();
                id = Convert.ToInt32(dr["ID"]);
                stiching = Convert.ToInt32(dr["stitching"]);
                finishing = Convert.ToInt32(dr["Finishing"]);
                cutting = Convert.ToInt32(dr["Cutting"]);
                int res = objadmin.updateSlot(DesignationID, factoryId, IsAct, UserId, Name, id, stiching, finishing, cutting);
            }
            BindGrd();
        }





        

    }

}


