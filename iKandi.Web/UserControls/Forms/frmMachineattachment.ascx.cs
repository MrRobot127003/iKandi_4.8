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
    public partial class frmMachineattachment : System.Web.UI.UserControl
    {
        int CurrentLoggedInUserID = ApplicationHelper.LoggedInUser.UserData.UserID;
        AdminController objAdminController;
       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindCheckbox();
                //DDl_ManpowerType.Items.Add(new ListItem("Select", "0", true));

                Bind_DDl();
                bindgrd();
            }

            
            
        }
        public void bindgrd()
        {

            AdminController objAdminController = new AdminController();
            DataSet ds = objAdminController.GetMachienattDetailsBAL();
            grdMachinetype.DataSource = ds.Tables[0];
            grdMachinetype.DataBind();

        }
        public void BindCheckbox()
        {
            AdminController objAdminController = new AdminController();
            DataSet ds = objAdminController.BindCheckboxBAL();

            chklst_attchment.DataSource = ds;
            chklst_attchment.DataTextField = "AttachmentName";
            chklst_attchment.DataValueField = "AttachmentID";
            chklst_attchment.DataBind();
            


        }
        public void Bind_DDl()
        {
            AdminController objAdminController = new AdminController();
            DataSet ds = objAdminController.BindDDlBAL();
            DDl_ManpowerType.DataSource = ds;
            DDl_ManpowerType.DataTextField = "WorkerType";
            DDl_ManpowerType.DataValueField = "FactoryWorkSpace";
            DDl_ManpowerType.DataBind();

            DDl_ManpowerType.Items.Insert(0, "Select");




        }

        protected void grdMachinetype_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdMachinetype.EditIndex = -1;

            bindgrd();
        }
        //protected void ddl_gmanpower_SelectedIndexChanged(object sender, EventArgs e)
        //{

            
        //}
        protected void g_checkboxlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
       
        protected void grdMachinetype_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //int DDl_SelectdValue = -1;
            string Dllselectedtext = string.Empty;
            AdminController objAdminController = new AdminController();
            GridViewRow Rows = grdMachinetype.Rows[e.RowIndex];

            HiddenField hdn_MachienAttID = Rows.FindControl("hdnFiled1") as HiddenField;
            TextBox txt_gmachinetype = Rows.FindControl("txt_gmachinetype") as TextBox;
            DropDownList ddl_Manpower = Rows.FindControl("ddl_gmanpower") as DropDownList;

            string strCheckList=string.Empty;
            //GridViewRow selected_row = gvTest.Rows[e.RowIndex];

            var total_column_drop_down_list = (DropDownList)Rows.FindControl("ddl_gmanpower");

           // DDl_SelectdValue = Convert.ToInt32(total_column_drop_down_list.SelectedItem.Value);
            Dllselectedtext = (total_column_drop_down_list.SelectedItem.Text);

            //DDl_SelectdValue = Int32.Parse(ddl_Manpower.SelectedValue.ToString());
           

            CheckBoxList CheklistAttName = Rows.FindControl("g_checkboxlist") as CheckBoxList;

            string StrCount = string.Empty;
            //get CheckListValue
            for (int i = 0; i < CheklistAttName.Items.Count; i++)
            {

                if (CheklistAttName.Items[i].Selected)
                {

                    StrCount += CheklistAttName.Items[i].Value + ",";
                }

            }

            if (!string.IsNullOrEmpty(StrCount))
            {
                strCheckList = StrCount.Remove(StrCount.Length - 1);
 
            }
             


            int id = Convert.ToInt32(hdn_MachienAttID.Value);
            


            int Result = -1;

            Result = objAdminController.UpdateMachienAttchmentBAL(txt_gmachinetype.Text, Dllselectedtext, strCheckList, CurrentLoggedInUserID, id);
           
            if (Result >=0)
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Machine type updated successfully','Machine attchment form');";

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                grdMachinetype.EditIndex = -1;
                bindgrd();
            }
          





        }
        
        protected void grdMachinetype_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdMachinetype.EditIndex = e.NewEditIndex;
           

            bindgrd();

            
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            objAdminController = new AdminController();



            string s = string.Empty;
              string Chklist =string.Empty;
            int Counts = 0;
            for (int i = 0; i < chklst_attchment.Items.Count; i++)
            {

                if (chklst_attchment.Items[i].Selected)
                {
                    Counts += 1;
                    s += chklst_attchment.Items[i].Value + ",";
                }

            }
           
            if (!string.IsNullOrEmpty(s))
            {
                Chklist = s.Remove(s.Length - 1);
 
            }


           
            



            string DdlselectedValue = DDl_ManpowerType.SelectedValue;
            //string a = DDl_ManpowerType.SelectedItem.Value;
            if (DdlselectedValue.ToUpper() == "SELECT")
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, ' Select manpower type','Machine attchment form');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                return;

            }
            string Machien_typ = txt_machineType.Value.Trim();




            int result = objAdminController.InsertMachienAttchmentBAL(Machien_typ, Chklist, DdlselectedValue, CurrentLoggedInUserID);
            if (result > 0)
            {
               
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Machine type save successfully.','Machine attchment form');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

                txt_machineType.Value = "";
                DDl_ManpowerType.SelectedValue = "Select";
                foreach (ListItem item in chklst_attchment.Items)
                {
                    //check anything out here
                    if (item.Selected)
                        item.Selected = false;
                }
                
                bindgrd();

            }
            else
            {
               
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Duplicate Record Found .','Machine attchment form');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

                txt_machineType.Value = "";
                DDl_ManpowerType.SelectedValue = "Select";
                foreach (ListItem item in chklst_attchment.Items)
                {
                    //check anything out here
                    if (item.Selected)
                        item.Selected = false;
                }
                bindgrd();

            }




        }

        protected void grdMachinetype_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //check if is in edit mode
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddl_gmanpower = (DropDownList)e.Row.FindControl("ddl_gmanpower");
                    //if (ddl_gmanpower == null)
                    //{

                    //}
                    //bind dropdownlist
                    DataSet ds = new DataSet();
                    objAdminController = new AdminController();
                    ds = objAdminController.BindDDlBAL();
                    DataTable dt = ds.Tables[0];

                    ddl_gmanpower.DataTextField = "WorkerType";
                    ddl_gmanpower.DataValueField = "FactoryWorkSpace";
                    ddl_gmanpower.DataSource = dt;
                    ddl_gmanpower.DataBind();

                    DataRowView dr = e.Row.DataItem as DataRowView;
                    ddl_gmanpower.SelectedItem.Text = dr["WorkerType"].ToString();





                    Label lbl_Machinattachment = (Label)e.Row.FindControl("lbl_Machinattachment");
                    CheckBoxList checklist = (CheckBoxList)e.Row.FindControl("g_checkboxlist");


                    ds = new DataSet();
                    objAdminController = new AdminController();
                    ds = objAdminController.BindCheckboxBAL();

                    checklist.DataSource = ds;
                    checklist.DataTextField = "AttachmentName";
                    checklist.DataValueField = "AttachmentID";
                    checklist.DataBind();


                    DataRowView drs = e.Row.DataItem as DataRowView;

                    string strAttid = drs["Att_Id"].ToString();
                    string[] AttIdArray = strAttid.Split(',');//for get attaachment ID



                   


                    foreach (string word in AttIdArray)
                    {
                        try
                        {
                            checklist.Items.FindByValue(word).Selected = true;
                        }
                        catch (Exception exp)
                        {
                            System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                            System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), exp.Message, exp.StackTrace));
                        }
                    }

                   





                }
                else
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        Label lbl_Machinattachment = (Label)e.Row.FindControl("lbl_Machinattachment");

                        string[] str = lbl_Machinattachment.Text.Split(',');
                        string Str_Attname = string.Empty;

                        if (str[0] == "")
                        {
                            if (str.Length <= 2)
                            {

                                for (int i = 1; i < str.Length; i++)
                                {

                                    Str_Attname += str[i] + " ";
                                }

                            }
                            else
                            
                            {
                                for (int i = 1; i < str.Length; i++)
                                {

                                    Str_Attname += str[i] + ","+" ";
                                }
                                Str_Attname = Str_Attname.Remove(Str_Attname.Length - 2);
 
                            }
                            
                           
                            
                        }
                        else
                        {
                            if (str.Length <= 1)
                            {

                                for (int i = 0; i < str.Length; i++)
                                {

                                    Str_Attname += str[i] + " ";
                                }

                            }
                            else
                            {
                                for (int i = 0; i < str.Length; i++)
                                {

                                    Str_Attname += str[i] + ","+" ";
                                }
                                Str_Attname = Str_Attname.Remove(Str_Attname.Length - 2);

                            }




                            //for (int i = 0; i < str.Length; i++)
                            //{


                            //    Str_Attname += "," + str[i] + " ";
                            //}
                           
                        }


                        lbl_Machinattachment.Text = Str_Attname;
                        //lbl_Machinattachment.DataBind();
                        //e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='FFCCFF'");
                       // e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='white'");
                        //e.Row.Cells[2].Attributes.Add("onmouseover", "this.style.backgroundColor='#3D9970  '");
                        //e.Row.Cells[2].Attributes.Add("onmouseout", "this.style.backgroundColor='white'");




                    }



                }

            }


        }
        

       

        protected void grdMachinetype_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            
            bindgrd();
            grdMachinetype.PageIndex = e.NewPageIndex;
            grdMachinetype.DataBind(); 
           

        }





    }
}