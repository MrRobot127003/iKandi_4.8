using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.BLL;
using iKandi.Web.Components;
using System.Data;

namespace iKandi.Web.Internal.Sales
{
    public partial class IkandiCommitSales_AdminNew : System.Web.UI.Page
    {
        ClientController ClientControllerInstance = new ClientController();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Onload", "load();", true);
            if (!IsPostBack)
            {
                BindClient();
                BindGrid();
            }
        }
        public void BindGrid()
        {
            string FinancialYear = GetCurrentFinancialYear();
            string[] year = FinancialYear.Split('-');
            DataSet ds = this.ClientControllerInstance.GetIkandiSales_AdminByYearNew(Convert.ToInt32(year[0]), Convert.ToInt32(year[1]));
            grdIkandiCommitSales_Admin.DataSource = ds;
            grdIkandiCommitSales_Admin.DataBind();
            ViewState["BindData"] = ds;
            double total = 0;
            int i = 2;
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int k = 4; k < ds.Tables[0].Columns.Count; k++)
                {
                    if (k % 2 == 0)
                    {
                        total = ds.Tables[0].AsEnumerable().Sum(row => row.Field<double>(ds.Tables[0].Columns[k].ToString()));
                        grdIkandiCommitSales_Admin.FooterRow.Cells[i].Text = total.ToString() == "0" ? "" : "&#65505; " + (total / 1000).ToString("0.00") + " K";
                        grdIkandiCommitSales_Admin.FooterRow.Cells[i].Font.Bold = true;
                        grdIkandiCommitSales_Admin.FooterRow.Cells[i].ForeColor = System.Drawing.Color.Green;
                        grdIkandiCommitSales_Admin.FooterRow.Cells[i].ToolTip = total.ToString("#,##0");
                    }
                    else
                    {
                        total = ds.Tables[0].AsEnumerable().Sum(row => row.Field<double>(ds.Tables[0].Columns[k].ToString()));
                        grdIkandiCommitSales_Admin.FooterRow.Cells[i].Text = total.ToString() == "0" ? "" : (total / 1000).ToString("0.00") + " K";
                        grdIkandiCommitSales_Admin.FooterRow.Cells[i].Font.Bold = true;
                        grdIkandiCommitSales_Admin.FooterRow.Cells[i].ToolTip = total.ToString("#,##0");
                    }
                    i++;
                }

                grdIkandiCommitSales_Admin.FooterRow.Cells[0].ColumnSpan = 2;
                grdIkandiCommitSales_Admin.FooterRow.Cells.RemoveAt(1);

                MegrgeRowinGridViewClient();
            }
        }
        protected void grdIkandiCommitSales_Admin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.Header)
            //{
            //    GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            //    GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            //    headerRow1.Attributes.Add("class", "HeaderClass");
            //    headerRow2.Attributes.Add("class", "HeaderClass");

            //    TableCell HeaderCell = new TableCell();
            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Clients";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.RowSpan = 2;
            //    HeaderCell.Width = 100;
            //    headerRow1.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Parent Dept.";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.RowSpan = 2;
            //    headerRow1.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "April";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.ColumnSpan = 2;
            //    headerRow1.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "May";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.ColumnSpan = 2;
            //    headerRow1.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "June";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.ColumnSpan = 2;
            //    headerRow1.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "July";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.ColumnSpan = 2;
            //    headerRow1.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "August";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.ColumnSpan = 2;
            //    headerRow1.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "September";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.ColumnSpan = 2;
            //    headerRow1.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "October";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.ColumnSpan = 2;
            //    headerRow1.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "November";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.ColumnSpan = 2;
            //    headerRow1.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "December";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.ColumnSpan = 2;
            //    headerRow1.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "January";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.ColumnSpan = 2;
            //    headerRow1.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "February";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.ColumnSpan = 2;
            //    headerRow1.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "March";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.ColumnSpan = 2;
            //    headerRow1.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Action";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.RowSpan = 2;
            //    headerRow1.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Val";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 70;
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Pcs";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 50;
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Val";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 70;
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Pcs";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 50;
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Val";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 70;
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Pcs";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 50;
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Val";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 70;
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Pcs";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 50;
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Val";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 70;
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Pcs";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 50;
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Val";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 70;
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Pcs";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 50;
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Val";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 70;
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Pcs";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 50;
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Val";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 70;
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Pcs";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 50;
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Val";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 70;
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Pcs";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 50;
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Val";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 70;
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Pcs";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 50;
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Val";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 70;
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Pcs";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 50;
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Val";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 70;
            //    headerRow2.Cells.Add(HeaderCell);

            //    HeaderCell = new TableCell();
            //    HeaderCell.Text = "Pcs";
            //    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //    HeaderCell.Width = 50;
            //    headerRow2.Cells.Add(HeaderCell);               


            //    grdIkandiCommitSales_Admin.Controls[0].Controls.AddAt(0, headerRow2);
            //    grdIkandiCommitSales_Admin.Controls[0].Controls.AddAt(0, headerRow1);
            //}
            if ((e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
            {

                // Add by Surendra 2 for put loop all data rows on 04-04-2018.
                foreach (DataControlFieldCell cell in e.Row.Cells)
                {
                    // check all cells in one row
                    foreach (Control control in cell.Controls)
                    {
                        LinkButton button = control as LinkButton;
                        if (button != null && button.CommandName == "Update")
                        {
                            // Add delete confirmation
                            button.OnClientClick = "return validateControl(this);";
                        }
                    }
                }

                //DataRowView rowView = (DataRowView)e.Row.DataItem;
                //DropDownList ddlClient = e.Row.FindControl("ddlClient") as DropDownList;
                //HiddenField hdnClient = e.Row.FindControl("hdnClient") as HiddenField;

                //DropdownHelper.BindAllClients(ddlClient);
                //ddlClient.Items.Insert(0, new ListItem("Select", "-1"));
                //ddlClient.SelectedValue = hdnClient.Value.ToString();
                //ddlClient.Enabled = false;

                //DropDownList ddlParentDept = e.Row.FindControl("ddlParentDept") as DropDownList;
                //HiddenField hdnParentDeptId = e.Row.FindControl("hdnParentDeptId") as HiddenField;

                //List<ClientDepartment> objClientDepartment = this.ClientControllerInstance.GetClientDeptsByClientID_ForDesignForm(Convert.ToInt32(hdnClient.Value.ToString()), -1, -1, "Parent");

                //foreach (ClientDepartment cdept in objClientDepartment)
                //{
                //    ddlParentDept.Items.Add(new ListItem(cdept.Name, cdept.DeptID.ToString()));
                //}
                //ddlParentDept.Items.Insert(0, new ListItem("Select", "-1"));
                //ddlParentDept.SelectedValue = hdnParentDeptId.Value.ToString();
                //ddlParentDept.Enabled = false;

                //DropDownList ddlDept = e.Row.FindControl("ddlDept") as DropDownList;
                //HiddenField hdnDeptId = e.Row.FindControl("hdnDeptId") as HiddenField;

                //List<ClientDepartment> objClientDepartment1 = this.ClientControllerInstance.GetClientDeptsByClientID_ForDesignForm(Convert.ToInt32(hdnClient.Value.ToString()), -1, Convert.ToInt32(hdnParentDeptId.Value.ToString()), "SubParent");

                //foreach (ClientDepartment cdept in objClientDepartment1)
                //{
                //    ddlDept.Items.Add(new ListItem(cdept.Name, cdept.DeptID.ToString()));
                //}
                //ddlDept.Items.Insert(0, new ListItem("Select", "-1"));
                //ddlDept.SelectedValue = hdnDeptId.Value.ToString();
                //ddlDept.Enabled = false;
            }

        }

        protected void grdIkandiCommitSales_Admin_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdIkandiCommitSales_Admin.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void grdIkandiCommitSales_Admin_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //int count = 0;
            int CreatedBy = Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID.ToString());
            HiddenField hdnClient = (HiddenField)grdIkandiCommitSales_Admin.Rows[e.RowIndex].FindControl("hdnClient");
            HiddenField hdnParentDeptId = (HiddenField)grdIkandiCommitSales_Admin.Rows[e.RowIndex].FindControl("hdnParentDeptId");
            string FinancialYear = GetCurrentFinancialYear();
            string[] year = FinancialYear.Split('-');
            int x = 0;
            int y = 4;
            try
            {
                for (int i = 1; i <= 21; i++)
                {
                    TextBox txtVal = (TextBox)grdIkandiCommitSales_Admin.Rows[e.RowIndex].FindControl("txtVal" + i);
                    TextBox txtPcs = (TextBox)grdIkandiCommitSales_Admin.Rows[e.RowIndex].FindControl("txtPcs" + i);
                    int o = this.ClientControllerInstance.UpdateIkandiSales_AdminNew(Convert.ToInt32(hdnClient.Value), Convert.ToInt32(hdnParentDeptId.Value), Convert.ToInt32(y), Convert.ToInt32(year[x].ToString()), Convert.ToInt32(txtVal.Text.Trim()), Convert.ToInt32(txtPcs.Text.Trim()), Convert.ToInt32(CreatedBy));
                    if (y == 21)
                    {
                        y = 1;
                        x = 1;
                    }
                    else
                    {
                        y++;
                    }
                }
                string message = "Your details have been Update successfully.";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);
                grdIkandiCommitSales_Admin.EditIndex = -1;
                BindGrid();
            }
            catch (Exception ex)
            {
                var script_fail2 = "";
                string er = ex.Message.Substring(0, ex.Message.Length - 3);
                if (er == "Record already exists.")
                    script_fail2 = "Record already exists this financial year.";
                else
                    script_fail2 = "Some error has occured, Error is : " + ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + script_fail2 + "');", true);
            }
        }

        protected void grdIkandiCommitSales_Admin_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdIkandiCommitSales_Admin.EditIndex = -1;
            BindGrid();
        }

        //protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
        //    DropDownList ddlClient = (DropDownList)gvr.FindControl("ddlClient");
        //    DropDownList ddlParentDept = (DropDownList)gvr.FindControl("ddlParentDept");

        //    ddlParentDept.Items.Clear();

        //    List<ClientDepartment> objClientDepartment = this.ClientControllerInstance.GetClientDeptsByClientID_ForDesignForm(Convert.ToInt32(ddlClient.SelectedValue.ToString()), -1, -1, "Parent");

        //    foreach (ClientDepartment cdept in objClientDepartment)
        //    {
        //        ddlParentDept.Items.Add(new ListItem(cdept.Name, cdept.DeptID.ToString()));
        //    }
        //    ddlParentDept.Items.Insert(0, new ListItem("Select", "-1"));
        //}

        //protected void ddlParentDept_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    GridViewRow gvr = (GridViewRow)(((Control)sender).NamingContainer);
        //    DropDownList ddlClient = (DropDownList)gvr.FindControl("ddlClient");
        //    DropDownList ddlParentDept = (DropDownList)gvr.FindControl("ddlParentDept");
        //    DropDownList ddlDept = (DropDownList)gvr.FindControl("ddlDept");

        //    ddlDept.Items.Clear();
        //    List<ClientDepartment> objClientDepartment = this.ClientControllerInstance.GetClientDeptsByClientID_ForDesignForm(Convert.ToInt32(ddlClient.SelectedValue.ToString()), -1, Convert.ToInt32(ddlParentDept.SelectedValue), "SubParent");

        //    foreach (ClientDepartment cdept in objClientDepartment)
        //    {
        //        ddlDept.Items.Add(new ListItem(cdept.Name, cdept.DeptID.ToString()));
        //    }
        //    ddlDept.Items.Insert(0, new ListItem("Select", "-1"));
        //}

        public void BindClient()
        {
            DropdownHelper.BindAllClients(ddl_Client);
            ddl_Client.Items.Insert(0, new ListItem("Select", "-1"));
        }
        protected void ddl_Client_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsfind = (DataSet)ViewState["BindData"];
            DataRow[] datarow = null;
            if (dsfind.Tables[0].Rows.Count > 0)
            {
                datarow = dsfind.Tables[0].Select("ClientID=" + ddl_Client.SelectedValue);
            }
            List<ClientDepartment> objClientDepartment = this.ClientControllerInstance.GetClientDeptsByClientID_ForDesignForm(Convert.ToInt32(ddl_Client.SelectedValue.ToString()), -1, -1, "Parent");

            //foreach (ClientDepartment cdept in objClientDepartment)
            //{
            //    ddl_ParentDept.Items.Add(new ListItem(cdept.Name, cdept.DeptID.ToString()));
            //}

            //ddl_ParentDept.Items.Insert(0, new ListItem("Select", "-1"));
            LB_ParantDept.Items.Clear();
            foreach (ClientDepartment ui in objClientDepartment)
            {
                int count = 0;
                ListItem li = new ListItem();
                li.Text = ui.Name;
                li.Value = Convert.ToString(ui.DeptID);
                if (datarow != null)
                {
                    for (int i = 0; i < datarow.Length; i++)
                    {
                        if (datarow[i]["PDeptId"].ToString() == ui.DeptID.ToString())
                        {
                            count++;
                        }
                    }
                }
                if (count == 0)
                {
                    li.Selected = true;
                }
                LB_ParantDept.Items.Add(li);
            }
            LB_ParantDept.DataBind();
        }


        public string GetCurrentFinancialYear()
        {
            int CurrentYear = DateTime.Today.Year;
            int PreviousYear = DateTime.Today.Year - 1;
            int NextYear = DateTime.Today.Year + 1;
            string PreYear = PreviousYear.ToString();
            string NexYear = NextYear.ToString();
            string CurYear = CurrentYear.ToString();
            string FinYear = null;

            if (DateTime.Today.Month > 3)
                FinYear = CurYear + "-" + NexYear;
            else
                FinYear = PreYear + "-" + CurYear;
            return FinYear.Trim();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string FinancialYear = GetCurrentFinancialYear();
            string[] year = FinancialYear.Split('-');            
            try
            {
                for (int j = 0; j < LB_ParantDept.Items.Count; j++)
                {
                    int x = 0;
                    int y = 4;
                    if (LB_ParantDept.Items[j].Selected == true)
                    {
                        for (int i = 0; i < 21; i++)
                        {
                            int o = this.ClientControllerInstance.InsertIkandiSales_AdminNew(Convert.ToInt32(ddl_Client.SelectedValue), Convert.ToInt32(LB_ParantDept.Items[j].Value), Convert.ToInt32(y), Convert.ToInt32(year[x].ToString()), 0, 0, Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID));
                            if (y == 21)
                            {
                                y = 1;
                                x = 1;
                            }
                            else
                            {
                                y++;
                            }
                        }
                    }
                }
                defualtval();
                string message = "Your details have been Add successfully.";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);
            }
            catch (Exception ex)
            {
                var script_fail2 = "";
                string er = ex.Message.Substring(0, ex.Message.Length - 3);
                if (er == "Record already exists.")
                    script_fail2 = "Record already exists this financial year.";
                else
                    script_fail2 = "Some error has occured, Error is : " + ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + script_fail2 + "');", true);
            }
        }

        public void defualtval()
        {
            ddl_Client.SelectedValue = "-1";
            LB_ParantDept.Items.Clear();
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            defualtval();
            BindGrid();
            divIkandi_Admin.Visible = false;
        }

        protected void ImgAddClient_Click(object sender, ImageClickEventArgs e)
        {
            divIkandi_Admin.Visible = true;
            BindGrid();
            Page page = HttpContext.Current.Handler as Page;
            ScriptManager.RegisterStartupScript(page, page.GetType(), "showpopup", "showpopup()", true);
        }

        public void MegrgeRowinGridViewClient()
        {
            int index = grdIkandiCommitSales_Admin.Rows.Count - 1;
            for (int i = grdIkandiCommitSales_Admin.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdIkandiCommitSales_Admin.Rows[i];
                GridViewRow previousRow = grdIkandiCommitSales_Admin.Rows[index - 1];

                Label lblClient = (Label)row.FindControl("lblClient");
                Label lblPreviousClient = (Label)previousRow.FindControl("lblClient");

                if (lblClient.Text == lblPreviousClient.Text)
                {
                    if (previousRow.Cells[0].RowSpan == 0)
                    {
                        if (row.Cells[0].RowSpan == 0)
                        {
                            previousRow.Cells[0].RowSpan = 2;
                        }
                        else
                        {
                            previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                        }
                        row.Cells[0].Visible = false;
                    }
                }
                index = index - 1;
            }
        }

    }
}