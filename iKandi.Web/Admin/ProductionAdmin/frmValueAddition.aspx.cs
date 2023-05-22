using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using System.Data;
using System.Web.UI.HtmlControls;
using iKandi.BLL.Production;

namespace iKandi.Web.Admin.ProductionAdmin
{
  public partial class frmValueAddition : System.Web.UI.Page
  {
    ProductionController objProductionController = new ProductionController();
    DataTable dtstatusmod = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrd();
            BindStatusdll();
            

           
        }

    }
    protected void ddldfromstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldfromstatus.SelectedValue == "10")
        {
            //Load DropDownList2
            ListItem removeItem = ddltostatus.Items.FindByValue("10");
            ddltostatus.Items.Remove(removeItem);

            ListItem removeItem37 = ddltostatus.Items.FindByValue("37");
            ddltostatus.Items.Remove(removeItem37);

            ListItem removeItem39 = ddltostatus.Items.FindByValue("39");
            ddltostatus.Items.Remove(removeItem39);

            ListItem removeItem40 = ddltostatus.Items.FindByValue("40");
            ddltostatus.Items.Remove(removeItem40);
        }
        else
        {
            dtstatusmod = objProductionController.GetProductionStatus();
            ddltostatus.DataSource = dtstatusmod;
            ddltostatus.DataTextField = "name";
            ddltostatus.DataValueField = "id";
            ddltostatus.DataBind();

            ddltostatus.Items.Insert(0, new ListItem("Select", "-1"));
        }



    }
    protected void grdddl(DropDownList ddlfrom, DropDownList ddlto)
    {
        if (ddlfrom.SelectedValue == "10")
        {
            //Load DropDownList2
            ListItem removeItem = ddlto.Items.FindByValue("10");
            ddlto.Items.Remove(removeItem);

            ListItem removeItem37 = ddlto.Items.FindByValue("37");
            ddlto.Items.Remove(removeItem37);

            ListItem removeItem39 = ddlto.Items.FindByValue("39");
            ddlto.Items.Remove(removeItem39);

            ListItem removeItem40 = ddlto.Items.FindByValue("40");
            ddlto.Items.Remove(removeItem40);
        }
        else
        {
            dtstatusmod = objProductionController.GetProductionStatus();
            ddlto.DataSource = dtstatusmod;
            ddlto.DataTextField = "name";
            ddlto.DataValueField = "id";
            ddlto.DataBind();

            ddlto.Items.Insert(0, new ListItem("Select", "-1"));
        }



    }
    public void BindStatusdll()
    {
        dtstatusmod = objProductionController.GetProductionStatus();
        ddldfromstatus.DataSource = dtstatusmod;
        ddldfromstatus.DataTextField = "name";
        ddldfromstatus.DataValueField = "id";
        ddldfromstatus.DataBind();

        ddltostatus.DataSource = dtstatusmod;
        ddltostatus.DataTextField = "name";
        ddltostatus.DataValueField = "id";
        ddltostatus.DataBind();

        ddltostatus.Items.Insert(0, new ListItem("Select", "-1"));
        ddldfromstatus.Items.Insert(0, new ListItem("Select", "-1"));
        

    }
    public void BindStatusdllgrid(DropDownList ddlfrom,DropDownList ddlto)
    {
        dtstatusmod = objProductionController.GetProductionStatus();
        ddlfrom.DataSource = dtstatusmod;
        ddlfrom.DataTextField = "name";
        ddlfrom.DataValueField = "id";
        ddlfrom.DataBind();

        ddlto.DataSource = dtstatusmod;
        ddlto.DataTextField = "name";
        ddlto.DataValueField = "id";
        ddlto.DataBind();


    }
    public void BindGrd()
    {
        grdValueAddititon.SelectedIndex = -1;
        DataTable dt = objProductionController.GetValueAddtionDetails();

        grdValueAddititon.DataSource = dt;
        grdValueAddititon.DataBind();

        
    }
    
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string result = string.Empty;
        int fromStatus = 0;
        int tostatus = 0;
        string ValueAddtion = string.Empty;
        decimal Rate = 0;
        bool IsAct = false;

        fromStatus = Convert.ToInt32(ddldfromstatus.SelectedValue);
        tostatus = Convert.ToInt32(ddltostatus.SelectedValue);
        ValueAddtion = txtVaname.Text;
        if (txtRateHeader.Text != "")
        {
            Rate = Convert.ToDecimal(txtRateHeader.Text);
        }
        
        if (chkIsAct.Checked == true)
        {
            IsAct = true;
        }
        else
        {
            IsAct = false;
        }
        if (fromStatus == -1)
        {
            string script = string.Empty;
            script = "ShowHideMessageBox(true, 'Please select from status','Value addition admin');";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
            ddldfromstatus.BorderColor = System.Drawing.Color.Red;
            ddldfromstatus.BorderStyle = BorderStyle.Solid;
            ddldfromstatus.Focus();
            return;
        }
        else
        {
          

            ddldfromstatus.BorderColor = System.Drawing.Color.Black;
            ddldfromstatus.BorderStyle = BorderStyle.None;
 
        }
        if (tostatus == -1)
        {
            string script = string.Empty;
            script = "ShowHideMessageBox(true, 'Please select to status','Value addition admin');";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

            ddltostatus.BorderColor = System.Drawing.Color.Red;
            ddltostatus.BorderStyle = BorderStyle.Solid;
            ddltostatus.Focus();
            return;
        }
        else
        {
            ddltostatus.BorderColor = System.Drawing.Color.Black;
            ddltostatus.BorderStyle = BorderStyle.None;
        }

        if (txtRateHeader.Text == "")
        {
            string script = string.Empty;
            script = "ShowHideMessageBox(true, 'Please enter Rate','Value addition admin');";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

            txtRateHeader.BorderColor = System.Drawing.Color.Red;
            txtRateHeader.BorderStyle = BorderStyle.Solid;
            txtRateHeader.Focus();
            return;
        }
        else
        {
            txtRateHeader.BorderColor = System.Drawing.Color.Black;
            txtRateHeader.BorderStyle = BorderStyle.None;
        }

        if (ValueAddtion == "")
        {
            string script = string.Empty;
            script = "ShowHideMessageBox(true, 'Please enter Value addtion','Value addition admin');";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

            txtVaname.BorderColor = System.Drawing.Color.Red;
            txtVaname.BorderStyle = BorderStyle.Solid;
            txtVaname.Focus();
            return;
        }
        else
        {
            txtVaname.BorderColor = System.Drawing.Color.Black;
            txtVaname.BorderStyle = BorderStyle.None;
        }
        //if (IsAct ==false)
        //{
        //    string script = string.Empty;
        //    script = "ShowHideMessageBox(true, 'Please select Is Active','Value addtion admin');";
        //    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);           
        //    return;
        //}

        result = objProductionController.InsertUpdateValueAddtion(fromStatus, tostatus, ValueAddtion, IsAct, 0, Rate);

        if (result == "INSERTED")
        {
            string script = string.Empty;
            script = "ShowHideMessageBox(true, 'Record inserted successfully','Value addition admin');";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
            ResetControl();
            BindGrd();
 
        }
        else if (result == "NOTINSERTED")
        {
            string script = string.Empty;
            script = "ShowHideMessageBox(true, 'Record already exists ','Value addition admin');";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
            ResetControl();
            BindGrd();
        }
        else
        {
            string script = string.Empty;
            script = "ShowHideMessageBox(true, 'Record not inserted check inserted value','Value addition admin');";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
            ResetControl();
            BindGrd();
 
        }
        

    }
    public void ResetControl()
    {
        ddldfromstatus.SelectedValue = "-1";
        ddltostatus.SelectedValue = "-1";
        txtVaname.Text = "";
        chkIsAct.Checked = false;
        txtRateHeader.Text = "";
    }
    protected void grdValueAddititon_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        if (e.Row.RowType == DataControlRowType.DataRow)
        {

           
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {

                DropDownList ddlfromstatus = (DropDownList)e.Row.FindControl("ddlfromstatus");
                DropDownList ddltostatus = (DropDownList)e.Row.FindControl("ddltostatus");
                CheckBox chkIsact = (CheckBox)e.Row.FindControl("chkIsact");

                ddlfromstatus.Items.Clear();
                ddltostatus.Items.Clear();

                BindStatusdllgrid(ddlfromstatus, ddltostatus);
               



                DataRowView dr = e.Row.DataItem as DataRowView;

                ddlfromstatus.SelectedValue = dr["FromStatus"].ToString();
                ddltostatus.SelectedValue = dr["ToStatus"].ToString();

                grdddl(ddlfromstatus, ddltostatus);

                if (dr["IsAct"].ToString() == "True")
                {
                    chkIsact.Checked = true;
                }
                else
                {
                    chkIsact.Checked = false;
                }               

            }
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                    DataRowView dr = e.Row.DataItem as DataRowView;

                    if (dr["IsUsing"].ToString() == "1")
                    {
                      lnkEdit.Enabled = false;
                      e.Row.Cells[5].BackColor=System.Drawing.ColorTranslator.FromHtml("#bd9d9d");
                      lnkEdit.ToolTip = "This Value addition already in use";
                    }
                    else
                    {
                      lnkEdit.Enabled = true;
                    }

                    CheckBox chkIsact = (CheckBox)e.Row.FindControl("chkIsact");

                    Label lblIsact = (Label)e.Row.FindControl("lblIsact");

                    if (dr["IsAct"].ToString() == "True")
                    {
                        lblIsact.Text = "ACTIVE";
                    }
                    else
                    {
                        lblIsact.Text = "IN ACTIVE";
                    }
                }
            }
        }

    }
    protected void grdValueAddititon_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdValueAddititon.EditIndex = e.NewEditIndex;

        BindGrd();

        GridViewRow Rows = grdValueAddititon.Rows[e.NewEditIndex];

    }
    protected void grdValueAddititon_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrd();
        grdValueAddititon.PageIndex = e.NewPageIndex;
        grdValueAddititon.DataBind();

    }

    protected void grdValueAddititon_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdValueAddititon.EditIndex = -1;

        BindGrd();
    }

    protected void grdValueAddititon_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string result = string.Empty;
        int fromStatus = 0;
        int tostatus = 0;
        string ValueAddtion = string.Empty;
        bool IsAct = false;
        decimal Rate=0;

        GridViewRow Rows = grdValueAddititon.Rows[e.RowIndex];

        HiddenField hdnid = Rows.FindControl("hdnid") as HiddenField;
        TextBox txtvaname_edit = Rows.FindControl("txtvaname_edit") as TextBox;
        TextBox txtRate_edit = Rows.FindControl("txtRate") as TextBox;
        DropDownList ddlfromstatus = Rows.FindControl("ddlfromstatus") as DropDownList;
        DropDownList ddltostatus = Rows.FindControl("ddltostatus") as DropDownList;
        CheckBox chkIsact = Rows.FindControl("chkIsact") as CheckBox;



        fromStatus = Convert.ToInt32(ddlfromstatus.SelectedValue);
        tostatus = Convert.ToInt32(ddltostatus.SelectedValue);
        ValueAddtion = txtvaname_edit.Text;
        Rate = Convert.ToDecimal(txtRate_edit.Text);
        if (chkIsact.Checked == true)
        {
            IsAct = true;
        }
        else
        {
            IsAct = false;
        }

        if (txtRate_edit.Text=="")
        {
            string script = string.Empty;
            script = "ShowHideMessageBox(true, 'Please enter Rate','Value addition admin');";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
            txtRate_edit.BorderColor = System.Drawing.Color.Red;
            txtRate_edit.BorderStyle = BorderStyle.Solid;
            txtRate_edit.Focus();
            return;
        }
        else
        {
            txtRate_edit.BorderColor = System.Drawing.Color.Black;
            txtRate_edit.BorderStyle = BorderStyle.None;
        }


        if (ValueAddtion == "")
        {
            string script = string.Empty;
            script = "ShowHideMessageBox(true, 'Please enter Value addtion','Value addition admin');";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
            txtvaname_edit.BorderColor = System.Drawing.Color.Red;
            txtvaname_edit.BorderStyle = BorderStyle.Solid;
            txtvaname_edit.Focus();
            return;
        }
        else
        {
            txtvaname_edit.BorderColor = System.Drawing.Color.Black;
            txtvaname_edit.BorderStyle = BorderStyle.None;
        }
        

        result = objProductionController.InsertUpdateValueAddtion(fromStatus, tostatus, ValueAddtion, IsAct,Convert.ToInt32(hdnid.Value),Convert.ToDecimal(Rate));

        if (result == "UPDATED")
        {
            string script = string.Empty;
            script = "ShowHideMessageBox(true, 'Record update successfully','Value addition admin');";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
            grdValueAddititon.EditIndex = -1;
            BindGrd();

        }
        else if (result == "NOTUPDATED")
        {
            string script = string.Empty;
            script = "ShowHideMessageBox(true, 'Record already exists ','Value addition admin');";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
            grdValueAddititon.EditIndex = -1;
            BindGrd();
        }
        else
        {
            string script = string.Empty;
            script = "ShowHideMessageBox(true, 'Record not update check inserted value','Value addition admin');";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
            grdValueAddititon.EditIndex = -1;
            BindGrd();

        }

           

    }
    //public void SearchValueAd()
    //{
    //    string SelectedCheckBoz = "";
    //    //foreach (ListItem item in chklist.Items)
    //    //{
    //    //    if (item.Selected)
    //    //    {
    //    //        SelectedCheckBoz = SelectedCheckBoz + item.Value + ",";
    //    //    }
    //    //}
    //    SelectedCheckBoz = SelectedCheckBoz.TrimEnd(',');
    //    //HideColumn = SelectedCheckBoz;
    //    DataSet ds_contact = new DataSet();
    //    ds_contact = objProductionController.GetValueAddtionDetails(3, 0, Convert.ToInt32(ddldfromstatus.SelectedValue), Convert.ToInt32(ddltostatus.SelectedValue), txtVaname.Text.Trim());

    //    if (ds_contact.Tables[0].Rows.Count > 0)
    //    {
    //        grdValueAddititon.DataSource = ds_contact.Tables[0];
    //        grdValueAddititon.DataBind();
    //    }
    //    else
    //    {
    //        grdValueAddititon.DataSource = null;
    //        grdValueAddititon.DataBind();
    //        //grdEditView.Rows[0].Cells[2].Text = "<img src='../../images/sorry.png' alt='No record found' >";//"No Record Found";
    //    }
    //}

    //protected void btnSearch_Click(object sender, EventArgs e)
    //{

    //}


  
    
  }
}