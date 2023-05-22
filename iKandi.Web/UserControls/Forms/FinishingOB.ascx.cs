using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.BLL;

namespace iKandi.Web.UserControls.Forms
{
    public partial class FinishingOB : System.Web.UI.UserControl
    {

        DataSet dsMachine = new DataSet();
        DataTable dtBindGrid = new DataTable();
        DataTable dtGarmentType = new DataTable();
        DataTable dtmerge = new DataTable();
        //DataTable dtBOSam = new DataTable();
        DataSet dtMachine = new DataSet();
        AdminController obj_AdminController = new AdminController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dsMachine = obj_AdminController.GetFactoryWork("Finishing");
                dtGarmentType = dsMachine.Tables[1];
                hdnCuttingOB.Value = dtGarmentType.Rows.Count.ToString();
                if (dtGarmentType.Rows.Count > 0)
                {
                    for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                    {
                        BoundField boundField = new BoundField();
                        boundField.HeaderText = "";
                        boundField.ItemStyle.CssClass = "tdgrid";
                        grdFinishingOB.Columns.Add(boundField);
                    }
                }
            }

            BindGrid();
        }

        protected void BindGrid()
        {


            if (ViewState["dtnew"] == null)
            {
                dtBindGrid = obj_AdminController.GetFinishingOB(0, 0, "");
                grdFinishingOB.DataSource = dtBindGrid;
                grdFinishingOB.DataBind();
            }
            else
            {
                if (ViewState["txtval"] != null)
                {
                    dtBindGrid = obj_AdminController.GetFinishingOB(0, 0, "");
                    grdFinishingOB.DataSource = dtBindGrid;
                    grdFinishingOB.DataBind();
                    ViewState["txtval"] = "";
                }
                else
                {
                    DataTable dtnew = new DataTable();
                    dtnew = (DataTable)(ViewState["dtnew"]);
                    dtBindGrid = obj_AdminController.GetFinishingOB(0, 0, "");
                    grdFinishingOB.DataSource = dtnew;
                    grdFinishingOB.DataBind();
                }
            }

        }

        protected void grdFinishingOB_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            //CheckBoxList chkMachine = (CheckBoxList)e.Row.FindControl("chkMachine");
            ListBox chkMachine = (ListBox)e.Row.FindControl("chkMachine");
            //HiddenField hdnCuttingOB = (HiddenField)e.Row.FindControl("hdnCuttingOB");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");


            dsMachine = obj_AdminController.GetFactoryWork("Finishing");

            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            if (hdnOperationId.Value != "")
            {
                dtMachine = obj_AdminController.GetMachineFinishingOB(Convert.ToInt32(hdnOperationId.Value));

                if (dtMachine.Tables[0].Rows.Count > 0)
                {
                    string opration = dtMachine.Tables[0].Rows[0]["Description"].ToString();
                    string[] words = opration.Split(',');
                    //
                    lstMachine.DataSource = dtMachine.Tables[1];
                    lstMachine.DataTextField = "FactoryWorkSpace";
                    lstMachine.DataBind();
                    //
                    foreach (var oprval in words)
                    {
                        if (chkMachine.Items.FindByValue(oprval.ToString()) != null)
                            chkMachine.Items.FindByValue(oprval.ToString()).Selected = true;
                    }
                }
            }

            dtGarmentType = dsMachine.Tables[1];

            if (dtGarmentType.Rows.Count > 0)
            {

                for (int i = 0; i < dtGarmentType.Rows.Count; i++)
                {
                    string colName = dtGarmentType.Rows[i]["GarmentType"].ToString();
                    int GarmentId = Convert.ToInt32(dtGarmentType.Rows[i]["GarmentTypeID"]);
                    grdFinishingOB.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdFinishingOB.HeaderRow.Style.Add("width", "250px");
                    grdFinishingOB.HeaderRow.Style.Add("class", "topMenu2");
                    grdFinishingOB.HeaderRow.Style.Add("text-align", "center");
                    grdFinishingOB.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();
                    if (hdnOperationId.Value != "")
                        dtBOSam = obj_AdminController.GetFinishingOBSam(Convert.ToInt32(hdnOperationId.Value), GarmentId);


                    Decimal OBSam = 0;
                    if (dtBOSam.Rows.Count > 0)
                    {
                        OBSam = Convert.ToDecimal(dtBOSam.Rows[0]["CuttingSam"]);
                    }
                    TextBox txtGarmentType = new TextBox();
                    txtGarmentType.EnableViewState = true;
                    txtGarmentType.Enabled = true;
                    txtGarmentType.ID = "txtGarment" + "_" + i + "_" + GarmentId;
                    if (OBSam == 0)
                    {
                        txtGarmentType.Text = "";
                    }
                    else
                    {
                        txtGarmentType.Text = OBSam.ToString();
                    }
                    txtGarmentType.Width = 50;
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveFinishingOBSam(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }


            }


        }

        protected void btnFinishing_Click(object sender, EventArgs e)
        {
            dtBindGrid = obj_AdminController.GetFinishingOB(0, 0, "");
            grdFinishingOB.DataSource = dtBindGrid;
            grdFinishingOB.DataBind();
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if (ViewState["dtnew"] != null)
            {
                DataTable dtnew = new DataTable();
                //dtnew = (DataTable)(ViewState["dtnew"]);
                dtnew = obj_AdminController.GetFinishingOB(0, 0, "");
                DataRow newrow = dtnew.NewRow();
                dtnew.Rows.Add(newrow);
                dtmerge = dtnew;
                grdFinishingOB.DataSource = dtmerge;
                grdFinishingOB.DataBind();
                ViewState["dtnew"] = dtmerge;
            }
            else
            {
                dtBindGrid = obj_AdminController.GetFinishingOB(0, 0, "");
                DataRow newrow = dtBindGrid.NewRow();
                dtBindGrid.Rows.Add(newrow);
                dtmerge = dtBindGrid;
                grdFinishingOB.DataSource = dtmerge;
                grdFinishingOB.DataBind();
                ViewState["dtnew"] = dtmerge;
            }

        }

        protected void txtOperation_TextChanged(object sender, EventArgs e)
        {
            string strtxt = ((TextBox)(sender)).Text.Trim();
            // HiddenField hdnOperationId = (HiddenField)grdFinishingOB.FindControl("hdnOperationId");
            GridViewRow gvr = ((TextBox)sender).Parent.Parent as GridViewRow;

            HiddenField hdnOperationId = (HiddenField)gvr.FindControl("hdnOperationId");

            if (hdnOperationId.Value == "")
            {
                int result = obj_AdminController.InsertFinishing(strtxt);
                ViewState["txtval"] = "First";
                BindGrid();

            }
            else
            {
                int result = obj_AdminController.InsertUpdateFinishingOB(Convert.ToInt32(hdnOperationId.Value), strtxt, "1");
                BindGrid();
                //ViewState["txtval"] = "First";

            }


        }


    }
}