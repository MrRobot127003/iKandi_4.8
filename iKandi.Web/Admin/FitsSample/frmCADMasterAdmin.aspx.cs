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
using System.Text;
using System.Collections.Generic;
using iKandi.BLL;


namespace iKandi.Web.Admin.FitsSample
{
    public partial class frmCADMasterAdmin : System.Web.UI.Page
    {
        AdminController objAdmin = new AdminController();
        public int IsActive
        {
            get;
            set;
        }
        public string PrimaryClientID
        {
            get;
            set;
        }
        public string secoundryClientID
        {
            get;
            set;
        }
        public int MasterID
        {
            get;
            set;
        }
        public int IsReplace
        {
            get;
            set;
        }
        public int NewMAsterID
        {
            get;
            set;
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindCadMAster();
                BindChangeMastertype();
                btnopen.Visible = true;
            }
        }
        
        public void BindCadMAster()
        {

            iKandi.Web.Components.DropdownHelper.FillDropDownCAD(ddlMastertype);

            DataSet ds = new DataSet();
            ds = objAdmin.GetClientlist( 1);
            list1.DataSource = ds.Tables[0];
            list1.DataTextField = "clientcode";
            list1.DataValueField = "ClientId";
            list1.DataBind();
           

            iKandi.Web.Components.DropdownHelper.GetMasterName(ddlcadmaster);
            iKandi.Web.Components.DropdownHelper.GetMasterName(ddlreplacemaster);
            if (ddlcadmaster.SelectedValue != "-1")
            {
            
                ListItem itemToRemove = ddlreplacemaster.Items.FindByValue(ddlcadmaster.SelectedValue);
                if (itemToRemove != null)
                {
                    ddlreplacemaster.Items.Remove(itemToRemove);
                }
            }
        }
        public void BindChangeMastertype()
        {
            AdminController objadmin = new AdminController();


            DataTable dts = objadmin.GetMasterName();
            foreach (DataRow dr in dts.Rows)
            {
                if (dr["ID"].ToString() == "-1")
                    dr.Delete();
            }
            dts.AcceptChanges();


            //grdMasterType.DataSource = objadmin.GetMasterName();
            //grdMasterType.DataBind();

            grdMasterType.DataSource = dts;
            grdMasterType.DataBind();
        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        protected void grdMasterType_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddlMasterTypeType = (e.Row.FindControl("ddlMasterTypeType") as DropDownList);
                    HiddenField hdnmasterid = (e.Row.FindControl("hdnmasterid") as HiddenField);

                    if (ddlMasterTypeType != null)
                    {
                        iKandi.Web.Components.DropdownHelper.FillDropDownCAD(ddlMasterTypeType);
                       
                        DataSet ds = objAdmin.GetClientMatserAssociationDetails(Convert.ToInt32(hdnmasterid.Value), 1);
                        DataTable dt = ds.Tables[0];
                        int CadID =Convert.ToInt32(dt.Rows[0]["CADid"].ToString());
                        if (ddlMasterTypeType.Items.FindByValue(CadID.ToString()) != null)
                        {
                            ddlMasterTypeType.SelectedValue = CadID.ToString();
                        }
                    }
                }
            }
            catch
            {

            }

        }
        protected void ddlMasterTypeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            try
            {
                //DropDownList ddl_status = (DropDownList)sender;
                //GridViewRow row = (GridViewRow)ddl_status.Parent.Parent;
                //int idx = row.RowIndex;


                DropDownList ddlLabTest = (DropDownList)sender;
                GridViewRow row = (GridViewRow)ddlLabTest.NamingContainer;
                DropDownList ddlMasterTypeType = (DropDownList)row.FindControl("ddlMasterTypeType");
                HiddenField hdnmasterid = (HiddenField)row.FindControl("hdnmasterid");

                
                



                if (ddlMasterTypeType.SelectedValue == "-1")
                {
                    ShowAlert("Select master role first");
                    return;

                }                
                else
                {
                    string str = objAdmin.UpdateMasterDetailsRole(Convert.ToInt32(hdnmasterid.Value), Convert.ToInt32(ddlMasterTypeType.SelectedValue));
                    if (str == "EXIST")
                    {
                        ShowAlert(txtMasterName.Text + " already exist");
                        return;
                    }
                    else if (str == "UPDATE")
                    {
                        ShowAlert("Updated successfully");

                    }

                }
                ShowAlert("Updated successfully");
                //Response.Redirect(Request.RawUrl, false);
                BindChangeMastertype();

            }
            catch(Exception ex)
            {
                ShowAlert(ex.ToString());

            }
        }
        protected void btnAddMAster_Click(object sender, EventArgs e)
        {
            if (txtMasterName.Text == "")
            {
                ShowAlert("Enter master name first");
                return;

            }
            else if(ddlMastertype.SelectedValue=="-1")
            {
                ShowAlert("Select MasterType first");
                return;
            }
            else
            {
                string str = objAdmin.UpdateMasterDetails(txtMasterName.Text.Trim(), Convert.ToInt32(ddlMastertype.SelectedValue));
                if (str == "EXIST")
                {
                    ShowAlert(txtMasterName.Text+" already exist");
                    return;
                }
                else if (str == "UPDATE")
                {
                    ShowAlert("Updated successfully");
                   
                }
                
            }
            BindCadMAster();
        }
        //protected void btndeactivate_Click(object sender, EventArgs e)
        //{

        //    if (ddlcadmaster.SelectedValue == "-1")
        //    {
        //        ShowAlert("Select master for deactivate");
        //        return;
        //    }
        //    else
        //    {
        //        ddlcadmaster.Enabled = false;
        //        IsActive = 0;
        //        pnlcad.Enabled = false;
        //        EnableControl(false);
        //        divreplace.Visible = true;

                
        //    }

           

        //}
        //protected void btnactivatemaster_Click(object sender, EventArgs e)
        //{

        //    ddlcadmaster.Enabled = true;
        //    IsActive = 1;
        //    pnlcad.Enabled = true;
        //    EnableControl(true);
        //    iKandi.Web.Components.DropdownHelper.GetMasterName(ddlcadmaster);
        //    divreplace.Visible = false;
        //}
        protected void btnreplace_Click(object sender, EventArgs e)
        {

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (ddlcadmaster.Enabled)
            {
                if (ddlcadmaster.SelectedValue != "-1")
                {
                    if (list2.Items.Count == 0 && list3.Items.Count == 0)
                    {
                        ShowAlert("Select At least 1 client on primary or secoundry client");
                        return;
                    }
                    //if (list3.Items.Count == 0)
                    //{
                    //    ShowAlert("Select At least on secoundry client");
                    //    return;
                    //}
                    PrimaryClientID = GetPrimarySecondryClientID(list2);
                    secoundryClientID = GetPrimarySecondryClientID(list3);

                }
                else
                {
                    ShowAlert("Please select at least one master name ");
                    return;
                }
                
            }
            //else
            //{
            //    ShowAlert("Please activate user first ");
            //    return;
            //}
            SaveMasterDetails();
        }
        public void EnableControl(Boolean t)
        {
            btnAdds.Enabled = t;
            btnAddAlls.Enabled = t;
            btnRemoves.Enabled = t;
            btnRemoveAlls.Enabled = t;

            btnAdd2s.Enabled = t;
            btnAddAll2s.Enabled = t;
            btnRemove2s.Enabled = t;
            btnRemoveAll2s.Enabled = t;

            btnAdd3s.Enabled = t;
            btnAddAll3s.Enabled = t;
            btnRemove3s.Enabled = t;
            btnRemoveAll3s.Enabled = t;




         
        }
        public string GetPrimarySecondryClientID(ListBox listitm)
        {
            String ClientID = "";

            for (int i = 0; i < listitm.Items.Count; i++)
            {
                //if (listitm.Items[i].Selected)
                //{
                    ClientID = ClientID + listitm.Items[i].Value + ",";
                //}
            }
            return ClientID;
        }
        ArrayList arraylist1 = new ArrayList();
        ArrayList arraylist2 = new ArrayList();
        protected void btnAdds_Click(object sender, EventArgs e)
        {
            if (list1.SelectedIndex >= 0)
            {
                for (int i = 0; i < list1.Items.Count; i++)
                {
                    if (list1.Items[i].Selected)
                    {
                        if (!arraylist1.Contains(list1.Items[i]))
                        {
                            arraylist1.Add(list1.Items[i]);
                        }
                    }
                }
                for (int i = 0; i < arraylist1.Count; i++)
                {
                    if (!list2.Items.Contains(((ListItem)arraylist1[i])))
                    {
                        list2.Items.Add(((ListItem)arraylist1[i]));
                    }
                    list1.Items.Remove(((ListItem)arraylist1[i]));
                }
                list2.SelectedIndex = -1;
            }
            else
            {
                //lbltxt.Visible = true;
                //lbltxt.Text = "Please select atleast one in Listbox1 to move";
                ShowAlert("Please select atleast one in client to move");
            }
        }

        protected void btnAddAlls_Click(object sender, EventArgs e)
        {
            while (list1.Items.Count != 0)
            {
                for (int i = 0; i < list1.Items.Count; i++)
                {
                    list2.Items.Add(list1.Items[i]);
                    list1.Items.Remove(list1.Items[i]);
                }
            }
        }

        protected void btnRemoves_Click(object sender, EventArgs e)
        {
            if (list2.SelectedIndex >= 0)
            {
                for (int i = 0; i < list2.Items.Count; i++)
                {
                    if (list2.Items[i].Selected)
                    {
                        if (!arraylist2.Contains(list2.Items[i]))
                        {
                            arraylist2.Add(list2.Items[i]);
                        }
                    }
                }
                for (int i = 0; i < arraylist2.Count; i++)
                {
                    if (!list1.Items.Contains(((ListItem)arraylist2[i])))
                    {
                        list1.Items.Add(((ListItem)arraylist2[i]));
                    }
                    list2.Items.Remove(((ListItem)arraylist2[i]));
                }
                list1.SelectedIndex = -1;
            }
            else
            {
                //lbltxt.Visible = true;
                //lbltxt.Text = "Please select atleast one in Listbox2 to move";

                ShowAlert("Please select atleast one in primary client to move");
            }

        }

        protected void btnRemoveAlls_Click(object sender, EventArgs e)
        {
            while (list2.Items.Count != 0)
            {
                for (int i = 0; i < list2.Items.Count; i++)
                {
                    list1.Items.Add(list2.Items[i]);
                    list2.Items.Remove(list2.Items[i]);
                }
            }
        }
        ArrayList arraylist3 = new ArrayList();
        ArrayList arraylist4 = new ArrayList();
        protected void btnAdd2s_Click(object sender, EventArgs e)
        {
            if (list1.SelectedIndex >= 0)
            {
                for (int i = 0; i < list1.Items.Count; i++)
                {
                    if (list1.Items[i].Selected)
                    {
                        if (!arraylist3.Contains(list1.Items[i]))
                        {
                            arraylist3.Add(list1.Items[i]);
                        }
                    }
                }
                for (int i = 0; i < arraylist3.Count; i++)
                {
                    if (!list3.Items.Contains(((ListItem)arraylist3[i])))
                    {
                        list3.Items.Add(((ListItem)arraylist3[i]));
                    }
                    list1.Items.Remove(((ListItem)arraylist3[i]));
                }
                list3.SelectedIndex = -1;
            }
            else
            {
                //lbltxt.Visible = true;
                //lbltxt.Text = "Please select atleast one in Listbox1 to move";
                ShowAlert("Please select atleast one in client to move");
            }
        }

        protected void btnAddAll2s_Click(object sender, EventArgs e)
        {
            while (list1.Items.Count != 0)
            {
                for (int i = 0; i < list1.Items.Count; i++)
                {
                    list3.Items.Add(list1.Items[i]);
                    list1.Items.Remove(list1.Items[i]);
                }
            }
        }

        protected void btnRemove2s_Click(object sender, EventArgs e)
        {
            if (list3.SelectedIndex >= 0)
            {
                for (int i = 0; i < list3.Items.Count; i++)
                {
                    if (list3.Items[i].Selected)
                    {
                        if (!arraylist4.Contains(list3.Items[i]))
                        {
                            arraylist4.Add(list3.Items[i]);
                        }
                    }
                }
                for (int i = 0; i < arraylist4.Count; i++)
                {
                    if (!list1.Items.Contains(((ListItem)arraylist4[i])))
                    {
                        list1.Items.Add(((ListItem)arraylist4[i]));
                    }
                    list3.Items.Remove(((ListItem)arraylist4[i]));
                }
                list1.SelectedIndex = -1;
            }
            else
            {
                //lbltxt.Visible = true;
                //lbltxt.Text = "Please select atleast one in Listbox2 to move";

                ShowAlert("Please select atleast one in secoundry client to move");
            }
        }

        protected void btnRemoveAll2s_Click(object sender, EventArgs e)
        {
            while (list3.Items.Count != 0)
            {
                for (int i = 0; i < list3.Items.Count; i++)
                {
                    list1.Items.Add(list3.Items[i]);
                    list3.Items.Remove(list3.Items[i]);
                }
            }
        }
        ArrayList arraylist5 = new ArrayList();
        ArrayList arraylist6 = new ArrayList();
        protected void btnAdd3s_Click(object sender, EventArgs e)
        {
            if (list2.SelectedIndex >= 0)
            {
                for (int i = 0; i < list2.Items.Count; i++)
                {
                    if (list2.Items[i].Selected)
                    {
                        if (!arraylist5.Contains(list2.Items[i]))
                        {
                            arraylist5.Add(list2.Items[i]);
                        }
                    }
                }
                for (int i = 0; i < arraylist5.Count; i++)
                {
                    if (!list3.Items.Contains(((ListItem)arraylist5[i])))
                    {
                        list3.Items.Add(((ListItem)arraylist5[i]));
                    }
                    list2.Items.Remove(((ListItem)arraylist5[i]));
                }
                list3.SelectedIndex = -1;
            }
            else
            {
                //lbltxt.Visible = true;
                //lbltxt.Text = "Please select atleast one in Listbox1 to move";
                ShowAlert("Please select atleast one in client to move");
            }
        }

        protected void btnAddAll3s_Click(object sender, EventArgs e)
        {
            while (list2.Items.Count != 0)
            {
                for (int i = 0; i < list2.Items.Count; i++)
                {
                    list3.Items.Add(list2.Items[i]);
                    list2.Items.Remove(list2.Items[i]);
                }
            }
        }

        protected void btnRemove3s_Click(object sender, EventArgs e)
        {
            if (list3.SelectedIndex >= 0)
            {
                for (int i = 0; i < list3.Items.Count; i++)
                {
                    if (list3.Items[i].Selected)
                    {
                        if (!arraylist5.Contains(list3.Items[i]))
                        {
                            arraylist5.Add(list3.Items[i]);
                        }
                    }
                }
                for (int i = 0; i < arraylist5.Count; i++)
                {
                    if (!list2.Items.Contains(((ListItem)arraylist5[i])))
                    {
                        list2.Items.Add(((ListItem)arraylist5[i]));
                    }
                    list3.Items.Remove(((ListItem)arraylist5[i]));
                }
                list2.SelectedIndex = -1;
            }
            else
            {
                //lbltxt.Visible = true;
                //lbltxt.Text = "Please select atleast one in Listbox2 to move";

                ShowAlert("Please select atleast one in secoundry client to move");
            }

        }

        protected void btnRemoveAll3s_Click(object sender, EventArgs e)
        {
            while (list3.Items.Count != 0)
            {
                for (int i = 0; i < list3.Items.Count; i++)
                {
                    list2.Items.Add(list3.Items[i]);
                    list3.Items.Remove(list3.Items[i]);
                }
            }
        }
        public void SaveMasterDetails()
        {
            IsReplace = 0;
            IsActive = 1;
            NewMAsterID = 0;
            if (ddlcadmaster.Enabled==false)
            {
                if (ddlcadmaster.SelectedValue != "-1")
                {
                    MasterID = Convert.ToInt32(ddlcadmaster.SelectedValue);
                    IsReplace = ddlcadmaster.Enabled == true ? 0 : 1;
                    IsActive = 0;
                    if (ddlreplacemaster.SelectedValue != "-1")
                    {

                        NewMAsterID = Convert.ToInt32(ddlreplacemaster.SelectedValue);


                    }
                    else
                    {
                        ShowAlert("select new master name");
                        return;
 
                    }

                }
                else
                {
                    ShowAlert("select new master name");
                    return;
                }
                string str = objAdmin.UpdateMasterDetailsClientAssosi(IsActive, PrimaryClientID, secoundryClientID, MasterID, IsReplace, NewMAsterID);
                if (str == "")
                {
                    ShowAlert("Record not updated successfully");
                    return;
                }
                else if (str == "UPDATE")
                {


                    txtMasterName.Text = "";

                    Response.Redirect(Request.RawUrl, false);
                    ShowAlert("Updated successfully");
                }
            }
            else
            {
                if (ddlcadmaster.SelectedValue != "-1")
                {
                    MasterID = Convert.ToInt32(ddlcadmaster.SelectedValue);
                    IsReplace = 0;
                    IsActive = 1;
                    if (ddlreplacemaster.SelectedValue != "-1")
                    {
                        NewMAsterID = Convert.ToInt32(ddlreplacemaster.SelectedValue);
                    }
                    PrimaryClientID = GetPrimarySecondryClientID(list2);
                    secoundryClientID = GetPrimarySecondryClientID(list3);

                    //if (PrimaryClientID == "")
                    //{
                    //    ShowAlert("Select at least one primary client");
                    //    return;
                    //}
                    //if (secoundryClientID == "")
                    //{
                    //    ShowAlert("Select at least one Secoundry Client");
                    //    return;
                    //}
                    if (PrimaryClientID == "" && secoundryClientID == "")
                    {
                        ShowAlert("Select At least 1 client on primary or secoundry client");
                        return;
                    }
                    
                }
                else
                {
                    ShowAlert("select master name");
                    return;
                }
                string str = objAdmin.UpdateMasterDetailsClientAssosi(IsActive,PrimaryClientID, secoundryClientID, MasterID,IsReplace,NewMAsterID);
                if (str == "")
                {
                    ShowAlert("Record not updated successfully");
                    return;
                }
                else if (str == "UPDATE")
                {
                   

                    txtMasterName.Text = "";

                    Response.Redirect(Request.RawUrl,false);
                    ShowAlert("Updated successfully");
                }
            }
 
        }
        protected void ddlcadmaster_SelectedIndexChanged(object sender, EventArgs e)
        {

            

            list2.Items.Clear();
            list3.Items.Clear();

            iKandi.Web.Components.DropdownHelper.GetMasterName(ddlreplacemaster);

            if (ddlcadmaster.SelectedValue != "-1")
            {


                DataSet ds = objAdmin.GetClientMatserAssociationDetails(Convert.ToInt32(ddlcadmaster.SelectedValue), 2);
                DataTable dt = ds.Tables[0];
                if (dt.Rows[0]["Result"].ToString() == "YES")
                {
                    chkdeactivate.Visible = true;
                    //string script = "<script type=\"text/javascript\"> alert('You can't deactivate due to existing allocation!'); </script>";

                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "key", script);

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:showalert();", true);
                    lblerrormsg.Visible = true;


                    chkdeactivate.Enabled = false;
                    //return;

                }
                else
                {
                    chkdeactivate.Enabled = true;
                    lblerrormsg.Visible = false;
                    chkdeactivate.Visible = true;
                }


                ListItem itemToRemove = ddlreplacemaster.Items.FindByValue(ddlcadmaster.SelectedValue);
                if (itemToRemove != null)
                {
                    ddlreplacemaster.Items.Remove(itemToRemove);
                }
                BindClinetDetails(Convert.ToInt32(ddlcadmaster.SelectedValue));

                
                pnlcad.Visible = true;
               
                lblTailor.Visible = true;


                

            }
            else
            {
                pnlcad.Visible = false;
                chkdeactivate.Visible = false;
                lblTailor.Visible = false;
                lblerrormsg.Visible = false;
               
            }
        }
        public void BindClinetDetails(int masterid)
        {
            DataSet dsa = new DataSet();
            dsa = objAdmin.GetClientlist(1);
            list1.DataSource = dsa.Tables[0];
            list1.DataTextField = "clientcode";
            list1.DataValueField = "ClientId";
            list1.DataBind();

            DataSet ds = new DataSet();
            ds = objAdmin.GetClientMatserAssociationDetails(masterid,1);
            DataTable dt = ds.Tables[0];
            DataTable dtprimary = ds.Tables[1];
            DataTable dtSecoundry = ds.Tables[2];


            if (dt.Rows.Count > 0)
            {
                lblTailor.Visible = true;
                lblTailor.Text = dt.Rows[0]["name"].ToString();
            }
            else
                lblTailor.Visible = false;

            if (dtprimary.Rows.Count > 0)
            {
                list2.DataSource = dtprimary;
                list2.DataTextField = "clientcode";
                list2.DataValueField = "ClientId";
                list2.DataBind();

                foreach (ListItem item in list2.Items)
                {
                    if (list1.Items.Contains(item))   // notice change of reference
                    {
                        list1.Items.Remove(item);
                    }
                }
            }
            else
            {
                //list2.DataSource = null;            
                //list2.DataBind();
                list2.Items.Clear();
            }
            if (dtSecoundry.Rows.Count > 0)
            {
                list3.DataSource = dtSecoundry;
                list3.DataTextField = "clientcode";
                list3.DataValueField = "ClientId";
                list3.DataBind();

                foreach (ListItem item in list3.Items)
                {
                    if (list1.Items.Contains(item))   // notice change of reference
                    {
                        list1.Items.Remove(item);
                    }
                }
            }
            else
            {
                //list3.DataSource = null;
                //list3.DataBind();
                list3.Items.Clear();
            }


        }


       

        public void GrdEditCadMasterselected_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
                Label lblMasterName = (Label)e.Row.FindControl("lblMasterName");
                Label lblAssignMaster = (Label)e.Row.FindControl("lblAssignMaster");

          
        }

        protected void chkdeactivate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkdeactivate.Checked)
            {
                ddlcadmaster.Enabled = true;
                IsActive = 1;
                pnlcad.Enabled = true;
                EnableControl(true);
                iKandi.Web.Components.DropdownHelper.GetMasterName(ddlcadmaster);
                divreplace.Visible = false;
                list2.Items.Clear();
                list3.Items.Clear();
                lblTailor.Text = "";
                pnlcad.Visible = false;

                DataSet ds = new DataSet();
                ds = objAdmin.GetClientlist(1);
                list1.DataSource = ds.Tables[0];
                list1.DataTextField = "clientcode";
                list1.DataValueField = "ClientId";
                list1.DataBind();
                chkdeactivate.Visible = false;

            }
            else
            {
               
                if (ddlcadmaster.SelectedValue == "-1")
                {
                    ShowAlert("Select master for deactivate");
                    chkdeactivate.Checked = true;
                    return;
                }
                else
                {
                    ddlcadmaster.Enabled = false;
                    IsActive = 0;
                    pnlcad.Enabled = false;
                    EnableControl(false);
                    divreplace.Visible = true;


                }
            }
        }

        protected void btnopen_Click(object sender, EventArgs e)
        {
            grdMasterType.Visible = true;
            btnopen.Visible = false;
            btnclose.Visible = true;

        }
        protected void btnclose_Click(object sender, EventArgs e)
        {
            grdMasterType.Visible = false;
            btnclose.Visible = false;
            btnopen.Visible = true;
        }
       
    }
}