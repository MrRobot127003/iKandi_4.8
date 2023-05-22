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
using iKandi.Common;
using iKandi.Web.Components;
using iKandi.BLL;

namespace iKandi.Web.UserControls.Lists
{
    public partial class GarmentTypeAdmin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //BindTables();
                //GrdBind();
                //BindTextBox();
            }
        }
        public void GrdBind()
        {
            DataTable dt = (DataTable)ViewState["dtGrdBind"];
            GrdCTM.DataSource = dt;
            GrdCTM.DataBind();
        }
        public void BindTables()
        {
            ViewState["dtGrdBind"] = null;
            ViewState["dtDDLBind"] = null;
            AdminController objAdminController = new AdminController();
            DataSet ds = objAdminController.GetGarmentTypeBAL();
            DataTable dtGrd = ds.Tables[0];
            DataTable dtddl = ds.Tables[1];
            ViewState["dtGrdBind"] = dtGrd;
            ViewState["dtDDLBind"] = dtddl;
        }
        public void BindTextBox()
        {
            //(reader["StyleNumber_d"] == DBNull.Value) ? "-1" : Convert.ToString(reader["StyleNumber_d"]);
            DataTable dt = (DataTable)ViewState["dtGrdBind"];
            int intRowCount = dt.Rows.Count;
            if (intRowCount == 0)
            {
                txtDefaultValue.Text = "1000";
            }
            else
            {
                int i = (dt.Rows[0]["ExQtyDefault"] == DBNull.Value) ? 1000 : Convert.ToInt32(dt.Rows[0]["ExQtyDefault"]);
                txtDefaultValue.Text = Convert.ToString(i);
            }

        }
        protected void GrdCTM_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
               
                DataTable dt = (DataTable)ViewState["dtGrdBind"];
                //  
                TextBox txtsamFooter = GrdCTM.FooterRow.FindControl("txtsamFooter") as TextBox;
                TextBox txtOption = GrdCTM.FooterRow.FindControl("txtOptionFooter") as TextBox;
                TextBox txtBox5 = GrdCTM.FooterRow.FindControl("txt500Footer") as TextBox;
                TextBox txtBox15 = GrdCTM.FooterRow.FindControl("txt1500Footer") as TextBox;
                TextBox txtBox30 = GrdCTM.FooterRow.FindControl("txt3000Footer") as TextBox;
                TextBox txtBox50 = GrdCTM.FooterRow.FindControl("txt5000Footer") as TextBox;
                TextBox txtBox100 = GrdCTM.FooterRow.FindControl("txt10000Footer") as TextBox;
                TextBox txtAbv = GrdCTM.FooterRow.FindControl("txtabv10000Footer") as TextBox;
                DropDownList ddllist = GrdCTM.FooterRow.FindControl("ddlgrmtypeFooter") as DropDownList;
                string ss = ddllist.SelectedValue;
                DataRow row;
                row = dt.NewRow();
                row["ID"] = 0;
                row["Garment_Type"] = ss;

                row["Option"] = "New" + Convert.ToString(txtsamFooter.Text.Trim());// Convert.ToString(txtOption.Text);

                if (Convert.ToString(txtsamFooter.Text.Trim()) == "")
                    row["sam"] = 0;
                else
                    row["sam"] = Convert.ToInt32(txtsamFooter.Text.Trim());

                if (Convert.ToString(txtBox5.Text) == "")
                    row["Upto_500"] = 0;
                else
                    row["Upto_500"] = Convert.ToInt32(txtBox5.Text);


                if (Convert.ToString(txtBox15.Text) == "")
                    row["Upto_1500"] = 0;
                else
                    row["Upto_1500"] = Convert.ToInt32(txtBox15.Text);
                if (Convert.ToString(txtBox30.Text) == "")
                    row["Upto_3000"] = 0;
                else
                    row["Upto_3000"] = Convert.ToInt32(txtBox30.Text);
                if (Convert.ToString(txtBox50.Text) == "")
                    row["Upto_5000"] = 0;
                else
                    row["Upto_5000"] = Convert.ToInt32(txtBox50.Text);


                if (Convert.ToString(txtBox100.Text) == "")
                    row["Upto_10000"] = 0;
                else
                    row["Upto_10000"] = Convert.ToInt32(txtBox100.Text);



                if (Convert.ToString(txtAbv.Text) == "")
                    row["Above_10000"] = 0;
                else
                    row["Above_10000"] = Convert.ToInt32(txtAbv.Text);
                dt.Rows.Add(row);
                ViewState["dtGrdBind"] = dt;
                GrdBind();
                btnSave_Click(btnSave, new EventArgs());
                BindTables(); GrdBind();
            }
            if (e.CommandName == "addnew")
            {
                DataTable dt = (DataTable)ViewState["dtGrdBind"];
                Table tbl = (Table)GrdCTM.Controls[0];
                GridViewRow grv = (GridViewRow)tbl.Controls[0];
                TextBox txtnam = (TextBox)grv.FindControl("txtIdBlank");
                DropDownList ddllist = (DropDownList)grv.FindControl("ddlBlank") as DropDownList;
                string ss = ddllist.SelectedValue;
                TextBox txtOptionBlank = (TextBox)grv.FindControl("txtOptionBlank");
                TextBox txtRange5Blank = (TextBox)grv.FindControl("txtRange5Blank");
                TextBox txtRange15Blank = (TextBox)grv.FindControl("txtRange15Blank");
                TextBox txtRange30Blank = (TextBox)grv.FindControl("txtRange30Blank");
                TextBox txtRange50Blank = (TextBox)grv.FindControl("txtRange50Blank");
                TextBox txtRange100Blank = (TextBox)grv.FindControl("txtRange100Blank");
                TextBox txtAbove100Blank = (TextBox)grv.FindControl("txtAbove100Blank");
                DataRow row;
                row = dt.NewRow();
                row["ID"] = 0;
                row["Garment_Type"] = ss;
                row["Option"] = Convert.ToString(txtOptionBlank.Text);
                if (Convert.ToString(txtRange5Blank.Text) == "")
                    row["Upto_500"] = 0;
                else
                    row["Upto_500"] = Convert.ToInt32(txtRange5Blank.Text);
                if (Convert.ToString(txtRange15Blank.Text) == "")
                    row["Upto_1500"] = 0;
                else
                    row["Upto_1500"] = Convert.ToInt32(txtRange15Blank.Text);
                if (Convert.ToString(txtRange30Blank.Text) == "")
                    row["Upto_3000"] = 0;
                else
                    row["Upto_3000"] = Convert.ToInt32(txtRange30Blank.Text);
                if (Convert.ToString(txtRange50Blank.Text) == "")
                    row["Upto_5000"] = 0;
                else
                    row["Upto_5000"] = Convert.ToInt32(txtRange50Blank.Text);
                if (Convert.ToString(txtRange100Blank.Text) == "")
                    row["Upto_10000"] = 0;
                else
                    row["Upto_10000"] = Convert.ToInt32(txtRange100Blank.Text);
                if (Convert.ToString(txtAbove100Blank.Text) == "")
                    row["Above_10000"] = 0;
                else
                    row["Above_10000"] = Convert.ToInt32(txtAbove100Blank.Text);
                dt.Rows.Add(row);
                ViewState["dtGrdBind"] = dt;
                GrdBind();
            }
        }

        protected void GrdCTM_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["dtDDLBind"];
                DropDownList ddl = (DropDownList)e.Row.FindControl("ddlgrmtype");
                HiddenField hdnGType = (HiddenField)e.Row.FindControl("hdnGarmentType");
                ddl.DataSource = dt;
                ddl.DataValueField = "Garment_Type";
                ddl.DataTextField = "Garment_Name";
                ddl.DataBind();
                ddl.SelectedValue = hdnGType.Value;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataTable dt = (DataTable)ViewState["dtDDLBind"];
                DropDownList ddl = (DropDownList)e.Row.FindControl("ddlgrmtypeFooter");
                ddl.DataSource = dt;
                ddl.DataValueField = "Garment_Type";
                ddl.DataTextField = "Garment_Name";
                ddl.DataBind();
            }

            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                DataTable dt = (DataTable)ViewState["dtDDLBind"];
                DropDownList ddl = (DropDownList)e.Row.FindControl("ddlBlank");
                ddl.DataSource = dt;
                ddl.DataValueField = "Garment_Type";
                ddl.DataTextField = "Garment_Name";
                ddl.DataBind();
            }



        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt2 = (DataTable)ViewState["dtGrdBind"];
            string script = string.Empty;
            DataTable tempdt = new DataTable();
            DataColumn cd1 = new DataColumn("Garment_Type");
            tempdt.Columns.Add(cd1);
            DataColumn cd2 = new DataColumn("Option");
            tempdt.Columns.Add(cd2);
            foreach (GridViewRow rowtemp in GrdCTM.Rows)
            {
                DataRow row;
                row = tempdt.NewRow();
                row["Garment_Type"] = ((DropDownList)rowtemp.FindControl("ddlgrmtype")).Text;
                if (((TextBox)rowtemp.FindControl("txtOption")).Text == "")
                {
                    script = "ShowHideMessageBox(true,'Blank Option Found.');";
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), script, true);
                    return;
                }
                else
                    row["Option"] = ((TextBox)rowtemp.FindControl("txtOption")).Text;
                tempdt.Rows.Add(row);
            }


            foreach (GridViewRow ChecRow in GrdCTM.Rows)
            {
                DropDownList ddlCheck = (DropDownList)ChecRow.FindControl("ddlgrmtype");
                TextBox txtCheck = (TextBox)ChecRow.FindControl("txtOption");
                foreach (GridViewRow rowtemp in GrdCTM.Rows)
                {

                    DropDownList ddlgt = (DropDownList)rowtemp.FindControl("ddlgrmtype");
                    TextBox txtop = (TextBox)rowtemp.FindControl("txtOption");
                    if (ChecRow.RowIndex != rowtemp.RowIndex)
                    {
                        if (ddlCheck.SelectedValue == ddlgt.SelectedValue && txtCheck.Text.ToUpper() == txtop.Text.ToUpper())
                        {
                            script = "ShowHideMessageBox(true, 'Duplicate Option found for Same Type');";
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), script, true);
                            ddlCheck.Focus();
                            return;
                        }
                    }
                }
            }

            DataView dv = tempdt.DefaultView;
            dv.Sort = "Option";
            tempdt = dv.ToTable();


            foreach (GridViewRow row in GrdCTM.Rows)
            {
                int intCell4;
                int intCell5;
                int intCell6;
                int intCell7;
                int intCell8;
                int intCell9;
                int intCell1 = Convert.ToInt32(((HiddenField)row.FindControl("txtID")).Value);
                string stringCell2 = ((DropDownList)row.FindControl("ddlgrmtype")).Text;
                string stringOption = ((TextBox)row.FindControl("txtOption")).Text;
                if (((TextBox)row.FindControl("txt500")).Text.ToString() == "")
                    intCell4 = 0;
                else
                    intCell4 = Convert.ToInt32(((TextBox)row.FindControl("txt500")).Text);

                if (((TextBox)row.FindControl("txt1500")).Text.ToString() == "")
                    intCell5 = 0;
                else
                    intCell5 = Convert.ToInt32(((TextBox)row.FindControl("txt1500")).Text);
                if (((TextBox)row.FindControl("txt3000")).Text.ToString() == "")
                    intCell6 = 0;
                else
                    intCell6 = Convert.ToInt32(((TextBox)row.FindControl("txt3000")).Text);

                if (((TextBox)row.FindControl("txt5000")).Text.ToString() == "")
                    intCell7 = 0;
                else
                    intCell7 = Convert.ToInt32(((TextBox)row.FindControl("txt5000")).Text);

                if (((TextBox)row.FindControl("txt10000")).Text.ToString() == "")
                    intCell8 = 0;
                else
                    intCell8 = Convert.ToInt32(((TextBox)row.FindControl("txt10000")).Text);

                if (((TextBox)row.FindControl("txtabv10000")).Text.ToString() == "")
                    intCell9 = 0;
                else
                    intCell9 = Convert.ToInt32(((TextBox)row.FindControl("txtabv10000")).Text);
                int intDefaultValue = Convert.ToInt32(txtDefaultValue.Text.Trim());
                int intSam = Convert.ToInt32(((TextBox)row.FindControl("txtsam")).Text);
                AdminController objAdminController = new AdminController();
                objAdminController.UpdateGarmentTypeBAL(intSam, intCell1, stringCell2, stringOption, intCell4, intCell5, intCell6, intCell7, intCell8, intCell9, intDefaultValue);
                BindTables();
                GrdBind();
            }
            script = "ShowHideMessageBox(true, 'Update Successfully');";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), script, true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script1, true);

            DataTable dt = (DataTable)ViewState["dtGrdBind"];
            GrdBind();
        }

        protected void GrdCTM_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int ints = 0; string script = string.Empty;
            int intKeyValue = int.Parse(GrdCTM.DataKeys[e.RowIndex].Value.ToString());
            if (intKeyValue == 0)
            {
                DataTable tempTable = new DataTable();
                tempTable = (DataTable)ViewState["dtGrdBind"];
                tempTable.Rows.RemoveAt(i);
                tempTable.AcceptChanges();
                ViewState["dtGrdBind"] = tempTable;
                GrdBind();
            }
            if (intKeyValue > 0)
            {
                DataTable tempTable = new DataTable();
                tempTable = (DataTable)ViewState["dtGrdBind"];
                tempTable.Rows.RemoveAt(i);
                tempTable.AcceptChanges();
                ViewState["dtGrdBind"] = tempTable;
                AdminController objAdminController = new AdminController();

                ints = objAdminController.DeleteGarmentTypeBAL(intKeyValue);
                if (ints == 1)
                {
                    script = "ShowHideMessageBox(true, 'Costing has been tagged for this option');";
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), script, true);
                }
                BindTables();
                GrdBind();
            }


        }








    }
}