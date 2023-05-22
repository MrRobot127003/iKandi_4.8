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
using System.Text.RegularExpressions;
using System.Web.Caching;
using iKandi.Common;
using iKandi.Web.Components;
using System.Web.Services;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;


namespace iKandi.Web.Internal.Fabric
{
    public partial class FrmBarrierWastage : System.Web.UI.Page
    {
        FabricController fabobj = new FabricController();
        public static int FabricQualityID
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

            ds = fabobj.GetFabricWastage("GET");
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                grdwastage.DataSource = dt;
                grdwastage.DataBind();

            }
        }
        protected void grdedit_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //GridViewRow row = grdedit.Rows[e.RowIndex];
            //HiddenField hdnSupplierPO_ETA_Id = (HiddenField)row.FindControl("hdnSupplierPO_ETA_Id");
        }
        public void BindWastagedetails(int fabricqualityid)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            ds = fabobj.GetFabricWastageDetails("GET2", fabricqualityid);
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                grdedit.DataSource = dt;
                grdedit.DataBind();

            }
        }
        protected void grdwastage_RowDatabound(object sender, GridViewRowEventArgs e)
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
                Label lblDyed = (Label)e.Row.FindControl("lblDyed");
                Label lblFinished = (Label)e.Row.FindControl("lblFinished");
                Label lblVA = (Label)e.Row.FindControl("lblVA");
                HiddenField hdnfabricqualityid = (HiddenField)e.Row.FindControl("hdnfabricqualityid");                   

                ds = fabobj.GetFabricWastageDetails("GET2", Convert.ToInt32(hdnfabricqualityid.Value));
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

                if (lblDyed.Text != "")
                {
                    lblDyed.Text = lblDyed.Text + "<span style='float:right;padding-left:2px'> % </span>";
                }

                if (lblPrinted.Text != "")
                {
                    lblPrinted.Text = lblPrinted.Text + "<span style='float:right;padding-left:2px'> % </span>";
                }

                if (lblFinished.Text != "")
                {
                    lblFinished.Text = lblFinished.Text + "<span style='float:right;padding-left:2px'> % </span>";
                }

                if (lblVA.Text != "")
                {
                    lblVA.Text = lblVA.Text + "<span style='float:right;padding-left:2px'> % </span>";
                }
                //str.Append("<table>");
                //foreach (DataRow dtRow in dt.Rows)
                //{
                //    str.Append("<tr>");
                //    str.Append("<td>");
                //    str.Append(dtRow["From_Qty"].ToString());
                //    str.Append(dtRow["To_Qty"].ToString());
                //    str.Append(" " + dtRow["UnitName"].ToString());
                //    str.Append("</td>");
                //    str.Append("</tr>");

                //}
                //str.Append("</table>");
                //lblfromqtyrange.Text = dt["From_Qty"].ToString();
                //lblPrinted.Text = dtRow["Solid_Barrier"].ToString();

            }
        }
        protected void grdwastage_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName.Equals("Select"))
            {
                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int RowIndex = gvr.RowIndex;
                HiddenField hdnfabricqualityid = (HiddenField)grdwastage.Rows[RowIndex].FindControl("hdnfabricqualityid");
                BindWastagedetails(Convert.ToInt32(hdnfabricqualityid.Value));
                FabricQualityID = Convert.ToInt32(hdnfabricqualityid.Value);
                grdwastage.Visible = false;
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
                        HiddenField hdnfabricqualityid = (HiddenField)grdedit.Rows[RowIndex].FindControl("hdnfabricqualityid");
                        if (hdnfabricqualityid != null)
                        {
                            HiddenField hdnFabricBarrierWastage = (HiddenField)grdedit.Rows[RowIndex].FindControl("hdnFabricBarrierWastage");
                            BindWastagedetails(Convert.ToInt32(hdnfabricqualityid.Value));
                            FabricQualityID = Convert.ToInt32(hdnfabricqualityid.Value);
                            int FabricBarrierWastage = Convert.ToInt32(hdnFabricBarrierWastage.Value);

                            int obj = fabobj.DeleteWastage("DELETE", FabricQualityID, FabricBarrierWastage);
                        }
                    }
                }
                grdwastage.Visible = false;
                tbladdnew.Visible = true;
                txtfrom.Text = "";
                txtto.Text = "";
                txtprintqty.Text = "";
                txtsolidval.Text = "";

                txtdyedqty.Text = "";
                txtFinishedqty.Text = "";
                txtVAqty.Text = "";

                BindWastagedetails(FabricQualityID);

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

            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) != DataControlRowState.Edit)
            {
                //LinkButton btndelete = e.Row.FindControl("btndelete") as LinkButton;              
                //PostBackTrigger trigger = new PostBackTrigger();
                //trigger.ControlID = btndelete.UniqueID;
                ////trigger.EventName = "Click";
                //UpdatePanel2.Triggers.Add(trigger);


                Label lblSolid = (Label)e.Row.FindControl("lblSolid");
                Label lblPrinted = (Label)e.Row.FindControl("lblPrinted");
                Label lblDyed = (Label)e.Row.FindControl("lblDyed");
                Label lblFinished = (Label)e.Row.FindControl("lblFinished");
                Label lblVA = (Label)e.Row.FindControl("lblVA");


                if (lblSolid.Text != "")
                {
                    lblSolid.Text = lblSolid.Text + "<span style='float:right;padding-left:2px'> % </span>";
                }
                if (lblPrinted.Text != "")
                {
                    lblPrinted.Text = lblPrinted.Text + "<span style='float:right;padding-left:2px'> % </span>";
                }

                if (lblDyed.Text != "")
                {
                    lblDyed.Text = lblDyed.Text + "<span style='float:right;padding-left:2px'> % </span>";
                }
                if (lblFinished.Text != "")
                {
                    lblFinished.Text = lblFinished.Text + "<span style='float:right;padding-left:2px'> % </span>";
                }
                if (lblVA.Text != "")
                {
                    lblVA.Text = lblVA.Text + "<span style='float:right;padding-left:2px'> % </span>";
                }

            }

        }
        public void addrow()
        {
            int fromqty = 0;
            int toqty = 0;
            int solid = 0;
            int print = 0;
            int dyed = 0;
            int finished = 0;
            int VA = 0;
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
                ShowAlert("Solid qty cannot be zero or empty");
                return;
            }
            if (txtprintqty.Text == "0")
            {
                ShowAlert("Print qty cannot be zero or empty");
                return;
            }

            if (txtdyedqty.Text == "0")
            {
                ShowAlert("Dyed qty cannot be zero or empty");
                return;
            }

            if (txtFinishedqty.Text == "0")
            {
                ShowAlert("Finished qty cannot be zero or empty");
                return;
            }

            if (txtVAqty.Text == "0")
            {
                ShowAlert("VA qty cannot be zero or empty");
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

            dyed = Convert.ToInt32(txtdyedqty.Text);
            finished = Convert.ToInt32(txtFinishedqty.Text);
            VA = Convert.ToInt32(txtVAqty.Text);

            int issave = fabobj.UpdateFabricWastageDetails("INSERT", FabricQualityID, 0, fromqty, toqty, solid, print, dyed, finished, VA);
            if (issave > 0)
            {
                ShowAlert("Save successfully");
                grdwastage.Visible = false;
                tbladdnew.Visible = true;
                txtfrom.Text = "";
                txtto.Text = "";
                txtprintqty.Text = "";
                txtsolidval.Text = "";
                txtdyedqty.Text = "";
                txtFinishedqty.Text = "";
                txtVAqty.Text = "";
                BindWastagedetails(FabricQualityID);


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
                        //if ((Convert.ToInt32(txtto.Text) > Convert.ToInt32(lblfromqtyrange.Text)) && ((Convert.ToInt32(txtto.Text) > Convert.ToInt32(lbltoqtyrange.Text))))
                        //{
                        //    result = true;
                        //}
                        //else
                        //{
                        //    result = false;
                        //}
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

        protected void grdwastage_DataBound(object sender, EventArgs e)
        {
            for (int i = grdwastage.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdwastage.Rows[i];
                GridViewRow previousRow = grdwastage.Rows[i - 1];

                Label lblFactory = (Label)row.FindControl("lblfabricquality");
                Label lblPreviousFactory = (Label)previousRow.FindControl("lblfabricquality");

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
                        if (previousRow.Cells[7].RowSpan == 0)
                        {
                            if (row.Cells[7].RowSpan == 0)
                            {
                                previousRow.Cells[7].RowSpan += 2;
                            }
                            else
                            {
                                previousRow.Cells[7].RowSpan = row.Cells[0].RowSpan + 1;
                            }
                            row.Cells[7].Visible = false;
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

                Label lblFactory = (Label)row.FindControl("lblfabricquality");
                Label lblPreviousFactory = (Label)previousRow.FindControl("lblfabricquality");

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
                    //if (LinkButton.Text == lblPreviousLinkButton.Text)
                    //{
                    //    if (previousRow.Cells[0].RowSpan == 0)
                    //    {
                    //        if (row.Cells[0].RowSpan == 0)
                    //        {
                    //            previousRow.Cells[0].RowSpan += 2;
                    //        }
                    //        else
                    //        {
                    //            previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                    //        }
                    //        row.Cells[0].Visible = false;
                    //    }
                    //}
                }


            }
        }

        protected void grdedit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdedit.EditIndex = e.NewEditIndex;            
            BindWastagedetails(FabricQualityID);
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
            TextBox txtDyed = grdedit.Rows[e.RowIndex].FindControl("txtDyed") as TextBox;
            TextBox txtPrinted = grdedit.Rows[e.RowIndex].FindControl("txtPrinted") as TextBox;
            TextBox txtFinished = grdedit.Rows[e.RowIndex].FindControl("txtFinished") as TextBox;
            TextBox txtVA = grdedit.Rows[e.RowIndex].FindControl("txtVA") as TextBox;
            HiddenField hdnfabricqualityid = grdedit.Rows[e.RowIndex].FindControl("hdnfabricqualityid") as HiddenField;
            HiddenField hdnFabricBarrierWastage = grdedit.Rows[e.RowIndex].FindControl("hdnFabricBarrierWastage") as HiddenField;


            int fromqty = 0;
            int toqty = 0;
            int solid = 0;
            int print = 0;
            int dyed = 0;
            int finished = 0;
            int VA = 0;

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
            if (txtDyed.Text == "" || Convert.ToInt32(txtDyed.Text) <= 0)
            {
                ShowAlert("Dyed qty cannot be zero or empty");
                return;
            }

            if (txtPrinted.Text == "" || Convert.ToInt32(txtPrinted.Text) <= 0)
            {
                ShowAlert("Print qty cannot be zero or empty");
                return;
            }

            if (txtFinished.Text == "" || Convert.ToInt32(txtFinished.Text) <= 0)
            {
                ShowAlert("Finished qty cannot be zero or empty");
                return;
            }

            if (txtVA.Text == "" || Convert.ToInt32(txtVA.Text) <= 0)
            {
                ShowAlert("VA qty cannot be zero or empty");
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
                    ShowAlert("from qty cannot be less than " + (Convert.ToInt32(lblPrevToRange.Text.Replace(",",""))+1).ToString() );
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
            print = Convert.ToInt32(txtDyed.Text);

            dyed = Convert.ToInt32(txtPrinted.Text);
            finished = Convert.ToInt32(txtFinished.Text);
            VA = Convert.ToInt32(txtVA.Text);
            int FabricQualityID = Convert.ToInt32(hdnfabricqualityid.Value);
            int FabricWastageBarrier = Convert.ToInt32(hdnFabricBarrierWastage.Value);
            int issave = fabobj.UpdateFabricWastageDetails("UPDATE", FabricQualityID, FabricWastageBarrier, fromqty, toqty, solid, print, dyed, finished, VA);
            if (issave > 0)
            {
                ShowAlert("Updated successfully");
                grdedit.EditIndex = -1;
                BindWastagedetails(FabricQualityID);


            }
        }

        protected void grdedit_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdedit.EditIndex = -1;            
            BindWastagedetails(FabricQualityID);
        }

    }

}
