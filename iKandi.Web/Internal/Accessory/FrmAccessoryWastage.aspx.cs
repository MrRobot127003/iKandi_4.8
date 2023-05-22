using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.Data;
using System.Text;

namespace iKandi.Web.Internal.Accessory
{
    public partial class FrmAccessoryWastage : System.Web.UI.Page
    {
        AccessoryWorkingController accessoryobj = new AccessoryWorkingController();
        public static int AccessoryQualityID
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID.ToString();
            if (!Page.IsPostBack)
            {
                Bind();
                tbladdnew.Visible = false;

            }
        }

        public void Bind()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            ds = accessoryobj.GetAccessoryWastage("GET");
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                grdAccessory.DataSource = dt;
                grdAccessory.DataBind();

            }
        }

        protected void grdedit_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
        }

        public void BindWastagedetails(int accessoryqualityid)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            ds = accessoryobj.GetAccessoryWastageDetails("GET2", accessoryqualityid);
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                grdedit.DataSource = dt;
                grdedit.DataBind();

            }
        }
        protected void grdAccessory_RowDatabound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Header)
            {

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                Label lblfromqtyrange = (Label)e.Row.FindControl("lblfromqtyrange");
                Label lbltoqtyrange = (Label)e.Row.FindControl("lbltoqtyrange");
                Label lblSolid = (Label)e.Row.FindControl("lblSolid");
                Label lblPrinted = (Label)e.Row.FindControl("lblPrinted");
                HiddenField hdnaccessoryqualityid = (HiddenField)e.Row.FindControl("hdnaccessoryqualityid");

                ds = accessoryobj.GetAccessoryWastageDetails("GET2", Convert.ToInt32(hdnaccessoryqualityid.Value));
                dt = ds.Tables[0];
                StringBuilder str = new StringBuilder();
                if (lblfromqtyrange.Text == "")
                {
                    e.Row.Cells[1].Text = "";
                }
                if (lblSolid.Text == "")
                {
                    e.Row.Cells[2].Text = "";
                }

                if (lblPrinted.Text == "")
                {
                    e.Row.Cells[3].Text = "";
                }
                if (lblSolid.Text != "")
                {
                    lblSolid.Text = lblSolid.Text + "<span style='float:right;padding-left:2px'> % </span>";
                }

                if (lblPrinted.Text != "")
                {
                    lblPrinted.Text = lblPrinted.Text + "<span style='float:right;padding-left:2px'> % </span>";
                }
            }
        }
        protected void grdAccessory_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName.Equals("Select"))
            {
                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int RowIndex = gvr.RowIndex;
                HiddenField hdnaccessoryqualityid = (HiddenField)grdAccessory.Rows[RowIndex].FindControl("hdnaccessoryqualityid");
                BindWastagedetails(Convert.ToInt32(hdnaccessoryqualityid.Value));
                AccessoryQualityID = Convert.ToInt32(hdnaccessoryqualityid.Value);
                grdAccessory.Visible = false;
                tbladdnew.Visible = true;

            }
        }
        protected void grdedit_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName.Equals("delete"))
            {
                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int RowIndex = gvr.RowIndex;
                for (; RowIndex <= grdedit.Rows.Count; RowIndex++)
                {
                    if (RowIndex <= grdedit.Rows.Count - 1)
                    {
                        HiddenField hdnaccessoryqualityid = (HiddenField)grdedit.Rows[RowIndex].FindControl("hdnaccessoryqualityid");
                        if (hdnaccessoryqualityid != null)
                        {
                            HiddenField hdnAccessoryBarrierWastage = (HiddenField)grdedit.Rows[RowIndex].FindControl("hdnAccessoryBarrierWastage");
                            BindWastagedetails(Convert.ToInt32(hdnaccessoryqualityid.Value));
                            AccessoryQualityID = Convert.ToInt32(hdnaccessoryqualityid.Value);
                            int AccessoryBarrierWastageId = Convert.ToInt32(hdnAccessoryBarrierWastage.Value);

                            int obj = accessoryobj.DeleteWastage("DELETE", AccessoryQualityID, AccessoryBarrierWastageId);
                        }
                    }
                }
                grdAccessory.Visible = false;
                tbladdnew.Visible = true;
                txtfrom.Text = "";
                txtto.Text = "";
                txtprintqty.Text = "";
                txtsolidval.Text = "";
                BindWastagedetails(AccessoryQualityID);

            }
        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        protected void grdedit_RowDatabound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Header)
            {
            }
            //if (e.Row.RowType == DataControlRowType.DataRow)
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) != DataControlRowState.Edit)
            {
                Label lblSolid = (Label)e.Row.FindControl("lblSolid");
                Label lblPrinted = (Label)e.Row.FindControl("lblPrinted");
                if (lblSolid.Text != "")
                {
                    lblSolid.Text = lblSolid.Text + "<span style='float:right;padding-left:2px'> % </span>";
                }
                if (lblPrinted.Text != "")
                {
                    lblPrinted.Text = lblPrinted.Text + "<span style='float:right;padding-left:2px'> % </span>";
                }
            }
        }
        public void addrow()
        {
            int fromqty = 0;
            int toqty = 0;
            int solid = 0;
            int print = 0;
            int createdBy = 0;
            if (txtfrom.Text == "0")
            {
                ShowAlert("from qty cannot be zero or empty");
                return;
            }
            if (txtto.Text == "0")
            {
                ShowAlert("To qty cannot be zero or empty");
                return;
            }
            if (txtsolidval.Text == "0")
            {
                ShowAlert("solid qty cannot be zero or empty");
                return;
            }
            if (txtprintqty.Text == "0")
            {
                ShowAlert("print qty cannot be zero or empty");
                return;
            }
            if (Convert.ToInt32(txtfrom.Text) > Convert.ToInt32(txtto.Text))
            {
                ShowAlert("from qty cannot be greater than to qty");
                return;
            }
            fromqty = Convert.ToInt32(txtfrom.Text);
            toqty = Convert.ToInt32(txtto.Text);
            solid = Convert.ToInt32(txtsolidval.Text);
            print = Convert.ToInt32(txtprintqty.Text);
            createdBy = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            int issave = accessoryobj.UpdateAccessoryWastageDetails("INSERT", AccessoryQualityID,0 ,fromqty, toqty, solid, print, createdBy);
            if (issave > 0)
            {
                ShowAlert("Save successfully");
                grdAccessory.Visible = false;
                tbladdnew.Visible = true;
                txtfrom.Text = "";
                txtto.Text = "";
                txtprintqty.Text = "";
                txtsolidval.Text = "";
                BindWastagedetails(AccessoryQualityID);


            }
        }

        public bool validateqty()
        {
            bool result = true;

            foreach (GridViewRow row in grdedit.Rows)
            {

                Label lblfromqtyrange = (Label)row.FindControl("lblfromqtyrange");
                Label lbltoqtyrange = (Label)row.FindControl("lbltoqtyrange");
                if (lblfromqtyrange.Text != "" && lbltoqtyrange.Text != "")
                {
                    if (result)
                    {
                        if ((Convert.ToInt32(txtfrom.Text) > Convert.ToInt32(lblfromqtyrange.Text.Replace(",", ""))) && ((Convert.ToInt32(txtfrom.Text) > Convert.ToInt32(lbltoqtyrange.Text.Replace(",", "")))))
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }

            }
            return result;
        }
        protected void btngotolist_Click(object sender, EventArgs e)
        {

            Response.Redirect(Request.RawUrl);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {


            if (Convert.ToInt32(txtfrom.Text) > (Convert.ToInt32(txtto.Text)))
            {
                ShowAlert("from qty cannot be less then to qty");
                return;
            }
            if (!validateqty())
            {
                ShowAlert("from qty and to qty should be between qty");
                return;
            }
            else
            {
                addrow();
            }
        }

        protected void grdAccessory_DataBound(object sender, EventArgs e)
        {
            for (int i = grdAccessory.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdAccessory.Rows[i];
                GridViewRow previousRow = grdAccessory.Rows[i - 1];

                Label lblFactory = (Label)row.FindControl("lblaccessoryquality");
                Label lblPreviousFactory = (Label)previousRow.FindControl("lblaccessoryquality");

                LinkButton LinkButton = (LinkButton)row.FindControl("btnselect");
                LinkButton lblPreviousLinkButton = (LinkButton)previousRow.FindControl("btnselect");

                if (lblFactory.Text == lblPreviousFactory.Text)
                {
                    if (previousRow.Cells[0].RowSpan == 0)
                    {
                        if (row.Cells[0].RowSpan == 0)
                        {
                            previousRow.Cells[0].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                        }
                        row.Cells[0].Visible = false;
                    }
                    if (LinkButton.Text == lblPreviousLinkButton.Text)
                    {
                        if (previousRow.Cells[4].RowSpan == 0)
                        {
                            if (row.Cells[4].RowSpan == 0)
                            {
                                previousRow.Cells[4].RowSpan += 2;
                            }
                            else
                            {
                                previousRow.Cells[4].RowSpan = row.Cells[0].RowSpan + 1;
                            }
                            row.Cells[4].Visible = false;
                        }
                    }
                }


            }
        }
        protected void grdedit_DataBound(object sender, EventArgs e)
        {
            for (int i = grdedit.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdedit.Rows[i];
                GridViewRow previousRow = grdedit.Rows[i - 1];

                Label lblFactory = (Label)row.FindControl("lblaccessoryquality");
                Label lblPreviousFactory = (Label)previousRow.FindControl("lblaccessoryquality");

                LinkButton LinkButton = (LinkButton)row.FindControl("btnselect");
                LinkButton lblPreviousLinkButton = (LinkButton)previousRow.FindControl("btnselect");

                if (lblFactory.Text == lblPreviousFactory.Text)
                {
                    if (previousRow.Cells[0].RowSpan == 0)
                    {
                        if (row.Cells[0].RowSpan == 0)
                        {
                            previousRow.Cells[0].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                        }
                        row.Cells[0].Visible = false;
                    }
                }
            }
        }


        protected void grdedit_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdedit.EditIndex = -1;            
            BindWastagedetails(AccessoryQualityID);
        }

        protected void grdedit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdedit.EditIndex = e.NewEditIndex;
            BindWastagedetails(AccessoryQualityID);
        }

        protected void grdedit_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label lblPrevFromRange = null;
            Label lblPrevToRange = null;
            TextBox txtCurrentFrom = null;
            TextBox txtCurrentTo = null;
            Label lblNextFromRange = null, lblNextToRange = null;




            TextBox txtfromqtyrange = grdedit.Rows[e.RowIndex].FindControl("txtfromqtyrange") as TextBox;
            TextBox txttoqtyrange = grdedit.Rows[e.RowIndex].FindControl("txttoqtyrange") as TextBox;
            TextBox txtSolid = grdedit.Rows[e.RowIndex].FindControl("txtSolid") as TextBox;            
            TextBox txtPrinted = grdedit.Rows[e.RowIndex].FindControl("txtPrinted") as TextBox;
            HiddenField hdnaccessoryqualityid = grdedit.Rows[e.RowIndex].FindControl("hdnaccessoryqualityid") as HiddenField;
            HiddenField hdnAccessoryBarrierWastage = grdedit.Rows[e.RowIndex].FindControl("hdnAccessoryBarrierWastage") as HiddenField;


            int fromqty = 0;
            int toqty = 0;
            int solid = 0;
            int print = 0;            

            if (txtfromqtyrange.Text == "" || Convert.ToInt32(txtfromqtyrange.Text) <= 0)
            {
                ShowAlert("From qty cannot be zero or empty");
                return;
            }
            if (txttoqtyrange.Text == "" || Convert.ToInt32(txttoqtyrange.Text) <= 0)
            {
                ShowAlert("To qty cannot be zero or empty");
                return;
            }
            if (txtSolid.Text == "" || Convert.ToInt32(txtSolid.Text) <= 0)
            {
                ShowAlert("Solid qty cannot be zero or empty");
                return;
            }
            

            if (txtPrinted.Text == "" || Convert.ToInt32(txtPrinted.Text) <= 0)
            {
                ShowAlert("Print qty cannot be zero or empty");
                return;
            }

            
            
            if (Convert.ToInt32(txtfromqtyrange.Text.Replace(",", "")) >= Convert.ToInt32(txttoqtyrange.Text.Replace(",", "")))
            {
                ShowAlert("from qty cannot be greater than or equal to qty");
                return;
            }

            txtCurrentFrom = grdedit.Rows[e.RowIndex].FindControl("txtfromqtyrange") as TextBox;
            txtCurrentTo = grdedit.Rows[e.RowIndex].FindControl("txttoqtyrange") as TextBox;

            try
            {
                lblPrevFromRange = grdedit.Rows[e.RowIndex - 1].FindControl("lblfromqtyrange") as Label;
                lblPrevToRange = grdedit.Rows[e.RowIndex - 1].FindControl("lbltoqtyrange") as Label;
            }
            catch (Exception ex)

            { }

            try
            {
                lblNextFromRange = grdedit.Rows[e.RowIndex + 1].FindControl("lblfromqtyrange") as Label;
                lblNextToRange = grdedit.Rows[e.RowIndex + 1].FindControl("lbltoqtyrange") as Label;

            }
            catch (Exception ex)

            { }


            // Next Row Starting Value
            if (e.RowIndex < grdedit.Rows.Count)
            {

            }
            if (lblNextFromRange != null && lblNextToRange != null)
            {
                if (Convert.ToInt32(txtCurrentFrom.Text) >= Convert.ToInt32(lblNextFromRange.Text.Replace(",", "")) || Convert.ToInt32(txtCurrentFrom.Text) >= Convert.ToInt32(lblNextToRange.Text.Replace(",", "")))
                {
                    ShowAlert("from qty cannot be greater than " + (Convert.ToInt32(lblNextFromRange.Text.Replace(",", "")) - 1).ToString());
                    return;
                }

                if (Convert.ToInt32(txtCurrentTo.Text) >= Convert.ToInt32(lblNextFromRange.Text.Replace(",", "")) || Convert.ToInt32(txtCurrentTo.Text) >= Convert.ToInt32(lblNextToRange.Text.Replace(",", "")))
                {
                    ShowAlert("to qty cannot be greater than " + (Convert.ToInt32(lblNextFromRange.Text.Replace(",", "")) - 1).ToString());
                    return;
                }
            }
            if (lblPrevFromRange != null && lblPrevToRange != null)
            {
                if (Convert.ToInt32(txtCurrentFrom.Text) <= Convert.ToInt32(lblPrevFromRange.Text.Replace(",", "")) || Convert.ToInt32(txtCurrentFrom.Text.Replace(",", "")) <= Convert.ToInt32(lblPrevToRange.Text.Replace(",", "")))
                {
                    ShowAlert("from qty cannot be less than " + (Convert.ToInt32(lblPrevToRange.Text.Replace(",", "")) + 1).ToString());
                    return;
                }

                if (Convert.ToInt32(txtCurrentTo.Text) <= Convert.ToInt32(lblPrevFromRange.Text.Replace(",", "")) || Convert.ToInt32(txtCurrentTo.Text.Replace(",", "")) <= Convert.ToInt32(lblPrevToRange.Text.Replace(",", "")))
                {
                    ShowAlert("to qty cannot be less than " + (Convert.ToInt32(lblPrevToRange.Text.Replace(",", "")) + 1).ToString());
                    return;
                }
            }


            fromqty = Convert.ToInt32(txtfromqtyrange.Text);
            toqty = Convert.ToInt32(txttoqtyrange.Text);
            solid = Convert.ToInt32(txtSolid.Text);
            print = Convert.ToInt32(txtPrinted.Text);

            int AccessoryQualityID = Convert.ToInt32(hdnaccessoryqualityid.Value);
            int AccessoryWastageBarrier = Convert.ToInt32(hdnAccessoryBarrierWastage.Value);
            int createdBy = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            int issave = accessoryobj.UpdateAccessoryWastageDetails("UPDATE", AccessoryQualityID, AccessoryWastageBarrier, fromqty, toqty, solid, print, createdBy);
            if (issave > 0)
            {
                ShowAlert("Updated successfully");
                grdedit.EditIndex = -1;
                BindWastagedetails(AccessoryQualityID);


            }
        }

    }
}