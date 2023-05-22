using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.Web.Components;
using System.Data;
using System.Text;




namespace iKandi.Web.UserControls.Forms
{
    public partial class TaskMapping : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDept();
            }
        }
        public void BindDept()
        {
            DataSet ds = this.TaskContollerInstance.GetALLDeptForTaskMappingBAL();
            ddlDept.DataSource = ds.Tables[0];
            ddlDept.DataTextField = "Name";
            ddlDept.DataValueField = "Id";
            ddlDept.DataBind();
        }
        public bool IsValidSeletedValue(DropDownList ddl, GridViewRow ddlrow)
        {
            bool falge = true; ;
            int ddlseletedValueCurent = Convert.ToInt32(ddl.SelectedValue);

            HiddenField hdnTaskIdCurrent = (HiddenField)(ddlrow.FindControl("hdnTaskId"));
            HiddenField hdnTableIdCurrent = (HiddenField)(ddlrow.FindControl("hdnTableId"));
            //  hdnTableId

            foreach (GridViewRow row in grdTask.Rows)
            {

                HiddenField hdnTaskIdAll = row.FindControl("hdnTaskId") as HiddenField;
                HiddenField hdnTableIdAll = row.FindControl("hdnTableId") as HiddenField;
                DropDownList ddlAssDes = row.FindControl("lstDesg") as DropDownList;
                if (Convert.ToInt32(hdnTableIdAll.Value) != Convert.ToInt32(hdnTableIdCurrent.Value) && Convert.ToInt32(hdnTaskIdAll.Value) == Convert.ToInt32(hdnTaskIdCurrent.Value) && ddlseletedValueCurent == Convert.ToInt32(ddlAssDes.SelectedValue))
                {
                    falge = false;
                    break;
                }
            }
            return falge;
        }
        protected void lstDesg_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList lstlm = (DropDownList)sender;
            GridViewRow row = (GridViewRow)lstlm.NamingContainer;
            if (IsValidSeletedValue(lstlm, row))
            {
                if (row != null)
                {
                    if (Convert.ToInt32(lstlm.SelectedValue) != -1)
                    {
                        ListBox ll = (ListBox)(row.FindControl("lstLineMgr"));
                        HiddenField hdnSelValue = (HiddenField)(row.FindControl("hdnAssDes"));
                        HiddenField hdnTaskId = (HiddenField)(row.FindControl("hdnTaskId"));
                        HiddenField hdnTaskWiseDesgId = (HiddenField)(row.FindControl("hdnTaskWiseDesgId"));

                        DataTable dtTemp = new DataTable();
                        if (Convert.ToInt32(hdnSelValue.Value) == Convert.ToInt32(lstlm.SelectedValue))
                        {
                            dtTemp = (DataTable)ViewState["AllMgr"];
                            DataTable NewDt = (DataTable)ViewState["AllMgr"];
                            var query = from customer in NewDt.AsEnumerable()
                                        where customer.Field<Int32>("TaskId") == Convert.ToInt32(hdnTaskId.Value) && customer.Field<Int32>("TaskWiseDesgId") == Convert.ToInt32(hdnTaskWiseDesgId.Value)
                                        select customer;
                            try
                            {
                                DataTable DataTableForListbox = query.CopyToDataTable();
                                ll.DataSource = DataTableForListbox;
                                ll.DataTextField = "Mgr";
                                ll.DataValueField = "DesId";
                                ll.DataBind();
                                DataTable dataTableForSeleted = new DataTable();
                                foreach (ListItem item in ll.Items)
                                {
                                    var query2 = from customer2 in DataTableForListbox.AsEnumerable()
                                                 where customer2.Field<Int32>("DesId") == Convert.ToInt32(item.Value)
                                                 select customer2;
                                    dataTableForSeleted = query2.CopyToDataTable();
                                    if (Convert.ToInt64(dataTableForSeleted.Rows[0]["IsAssociate"]) == 1)
                                        item.Selected = true;
                                }
                            }
                            catch
                            {
                                ListBox llCatch = (ListBox)(row.FindControl("lstLineMgr"));
                                llCatch.DataSource = string.Empty;
                                llCatch.DataBind();
                            }
                        }
                        else
                        {
                            ListBox llElse = (ListBox)(row.FindControl("lstLineMgr"));
                            llElse.DataSource = this.TaskContollerInstance.GetLineMgrMappingBAL(Convert.ToInt32(lstlm.SelectedValue)).Tables[0];
                            llElse.DataTextField = "LineMgr";
                            llElse.DataValueField = "deSIGNATIONiD";
                            llElse.DataBind();

                            foreach (ListItem item in llElse.Items)
                            {
                                item.Selected = true;
                            }

                        }
                    }
                    else
                    {
                        ListBox ll = (ListBox)(row.FindControl("lstLineMgr"));
                        ll.DataSource = string.Empty;
                        ll.DataBind();
                    }
                }
            }
            else
            {

                DropDownList lbl = (DropDownList)(row.FindControl("lstDesg"));
                HiddenField hdnSelValue = (HiddenField)(row.FindControl("hdnAssDes"));

                lbl.SelectedValue = hdnSelValue.Value;
            }
        }


        public bool IsForUpdate(HiddenField hdnTaskNameForUpdate, TextBox txtTaskNameOld, HiddenField hdnAssDes, DropDownList DLLDesgOld, HiddenField hdnListedItemForUpdate, ListBox lstLineMgrOld, HiddenField Purpose, TextBox txtPurpose)
        {
            bool flag = true;
            string ListItems = string.Empty;
            ListBox LineMgr = lstLineMgrOld;
            foreach (ListItem item in LineMgr.Items)
            {
                if (item.Selected)
                    ListItems = ListItems + item.Text;
            }
            if (hdnTaskNameForUpdate.Value == txtTaskNameOld.Text.Trim() && Convert.ToInt32(hdnAssDes.Value) == Convert.ToInt32(DLLDesgOld.SelectedValue) && hdnListedItemForUpdate.Value == ListItems && txtPurpose.Text.Trim() == Purpose.Value)
            {
                return false;
            }
            return flag;
        }

        protected void btnSbmt_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grdTask.Rows)
            {
                HiddenField hdnTaskId = row.FindControl("hdnTaskId") as HiddenField;
                HiddenField hdnTaskWiseDesgId = row.FindControl("hdnTaskWiseDesgId") as HiddenField;
                DropDownList ddlAssDes = row.FindControl("lstDesg") as DropDownList;
                ListBox lstbx = row.FindControl("lstLineMgr") as ListBox;
                int MgeLevel = 0;


                HiddenField hdnTaskNameForUpdate = row.FindControl("hdnTaskNameForUpdate") as HiddenField;
                HiddenField hdnAssDes = row.FindControl("hdnAssDes") as HiddenField;
                HiddenField hdnListedItemForUpdate = row.FindControl("hdnListedItemForUpdate") as HiddenField;

                TextBox txtTaskNameOld = row.FindControl("txtTaskName") as TextBox;
                DropDownList lstDesgOld = row.FindControl("lstDesg") as DropDownList;
                ListBox lstLineMgrOld = row.FindControl("lstLineMgr") as ListBox;

                TextBox TaskNameNew = row.FindControl("txtTaskName") as TextBox;
                TextBox PurposeNew = row.FindControl("txtPurpose") as TextBox;

                HiddenField hdnPurposeForUpdate = row.FindControl("hdnPurposeForUpdate") as HiddenField;

                //   bool rr = IsForUpdate(hdnTaskNameForUpdate, txtTaskNameOld, hdnAssDes, lstDesgOld, hdnListedItemForUpdate, lstLineMgrOld);
                if (IsForUpdate(hdnTaskNameForUpdate, txtTaskNameOld, hdnAssDes, lstDesgOld, hdnListedItemForUpdate, lstLineMgrOld, hdnPurposeForUpdate, PurposeNew) == true)
                {
                    foreach (ListItem item in lstbx.Items)
                    {
                        MgeLevel = MgeLevel + 1;
                        int IsAsso = 0;
                        if (item.Selected == true)
                        {
                            IsAsso = 1;
                        }
                        else
                            IsAsso = 0;

                        this.TaskContollerInstance.UpdateMgrBAL(
                            Convert.ToInt32(hdnTaskId.Value),
                            Convert.ToInt32(ddlAssDes.SelectedValue),
                            Convert.ToInt32(item.Value),
                            MgeLevel,
                            IsAsso,
                            Convert.ToInt32(ddlAssDes.SelectedValue), Convert.ToInt32(ddlDept.SelectedValue), Convert.ToString(TaskNameNew.Text.Trim()), Convert.ToString(PurposeNew.Text.Trim()), Convert.ToInt32(hdnAssDes.Value)
                            );
                        // public DataSet UpdateMgrDAL(int intTaskId, int intDesgId, int MgrId, int MgeLevel, int IsAssociate, int TaskWiseDesgId)                  
                    }
                    if (Convert.ToInt32(lstbx.Items.Count) < 1)
                    {
                        this.TaskContollerInstance.UpdateMgrBAL(
                                             Convert.ToInt32(hdnTaskId.Value),
                                             Convert.ToInt32(ddlAssDes.SelectedValue),
                                             Convert.ToInt32(0),
                                             1,
                                             0,
                                             Convert.ToInt32(ddlAssDes.SelectedValue), Convert.ToInt32(ddlDept.SelectedValue), Convert.ToString(TaskNameNew.Text.Trim()), Convert.ToString(PurposeNew.Text.Trim()), Convert.ToInt32(hdnAssDes.Value)
                                             );
                    }
                }
            }
            BindGrid();
        }

        protected void grdTask_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {



                DropDownList lbl = e.Row.FindControl("lstDesg") as DropDownList;
                HiddenField hdnSelValue = e.Row.FindControl("hdnAssDes") as HiddenField;
                HiddenField hdnTaskId = e.Row.FindControl("hdnTaskId") as HiddenField;
                HiddenField hdnTaskWiseDesgId = e.Row.FindControl("hdnTaskWiseDesgId") as HiddenField;
                HiddenField yy = e.Row.FindControl("hdnTaskNameForUpdate") as HiddenField;


                lbl.DataSource = (DataTable)ViewState["AllDesg"];
                lbl.DataTextField = "Name";
                lbl.DataValueField = "Id";
                lbl.DataBind();
                lbl.SelectedValue = hdnSelValue.Value;
                DataTable NewDt = (DataTable)ViewState["AllMgr"];
                var query = from customer in NewDt.AsEnumerable()
                            where customer.Field<Int32>("TaskId") == Convert.ToInt32(hdnTaskId.Value) && customer.Field<Int32>("TaskWiseDesgId") == Convert.ToInt32(hdnTaskWiseDesgId.Value)
                            select customer;
                try
                {
                    DataTable dataTableForListBox = query.CopyToDataTable();
                    DataTable DataTableForSeleted = new DataTable();
                    ListBox ll = e.Row.FindControl("lstLineMgr") as ListBox;
                    ll.DataSource = dataTableForListBox;
                    ll.DataTextField = "Mgr";
                    ll.DataValueField = "DesId";
                    ll.DataBind();
                    foreach (ListItem item in ll.Items)
                    {

                        var query2 = from customer2 in dataTableForListBox.AsEnumerable()
                                     where customer2.Field<Int32>("DesId") == Convert.ToInt32(item.Value)
                                     select customer2;
                        DataTableForSeleted = query2.CopyToDataTable();

                        if (Convert.ToInt64(DataTableForSeleted.Rows[0]["IsAssociate"]) == 1)
                        {
                            item.Selected = true;
                        }
                    }
                }
                catch
                {
                    ListBox ll = e.Row.FindControl("lstLineMgr") as ListBox;
                    ll.DataSource = string.Empty;
                    ll.DataBind();
                }
                HiddenField hdnListedItemForUpdate = e.Row.FindControl("hdnListedItemForUpdate") as HiddenField;
                string ListItems = string.Empty;
                ListBox LineMgr = e.Row.FindControl("lstLineMgr") as ListBox;
                foreach (ListItem item in LineMgr.Items)
                {
                    if (item.Selected)
                        ListItems = ListItems + item.Text;
                }

                hdnListedItemForUpdate.Value = ListItems;

            }
        }

        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public void BindGrid()
        {
            DataSet dss = this.TaskContollerInstance.GetTaskMappingBAL(Convert.ToInt32(ddlDept.SelectedValue));
            ViewState["AllDesg"] = dss.Tables[1];
            ViewState["AllMgr"] = dss.Tables[2];
            grdTask.DataSource = dss.Tables[0];
            grdTask.DataBind();
        }
        protected void btnGO_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            BindGrid();
        }


    }
}

