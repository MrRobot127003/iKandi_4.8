using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.BLL;
using System.Web.Services;

namespace iKandi.Web.UserControls.Forms
{
    public partial class CuttingOB : System.Web.UI.UserControl
    {
        DataSet dsMachine = new DataSet();
        DataTable dtBindGrid = new DataTable();
        DataTable dtGarmentType = new DataTable();
        DataTable dtmerge = new DataTable();

        DataSet dtMachine = new DataSet();
        AdminController obj_AdminController = new AdminController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dsMachine = obj_AdminController.GetFactoryWork("Cutting");
                dtGarmentType = dsMachine.Tables[1];
                hdnCuttingOB.Value = dtGarmentType.Rows.Count.ToString();
                if (dtGarmentType.Rows.Count > 0)
                {
                    for (int i = 1; i < dtGarmentType.Rows.Count + 1; i++)
                    {
                        BoundField boundField = new BoundField();
                        boundField.HeaderText = "";
                        boundField.ItemStyle.CssClass = "tdgrid";
                        grdCuttingOB.Columns.Add(boundField);
                    }
                }
            }

            BindGrid();
        } 

        protected void btnCutting_Click(object sender, EventArgs e)
        {
            //BindGrid();
            //hdnCutting.Value = "1";
            dtBindGrid = obj_AdminController.GetCuttingOB(0, 0);
            grdCuttingOB.DataSource = dtBindGrid;
            grdCuttingOB.DataBind();
        }
        protected void BindGrid()
        {
           
            if (ViewState["dtnew"] == null)
            {
                dtBindGrid = obj_AdminController.GetCuttingOB(0, 0);
                grdCuttingOB.DataSource = dtBindGrid;
                grdCuttingOB.DataBind();
            }
            else
            {
                    DataTable dtnew = new DataTable();
                    dtnew = (DataTable)(ViewState["dtnew"]);
                    dtBindGrid = obj_AdminController.GetCuttingOB(0, 0);
                    grdCuttingOB.DataSource = dtnew;
                    grdCuttingOB.DataBind();
            }
        }

        protected void grdCuttingOB_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            HiddenField hdnMachine = (HiddenField)e.Row.FindControl("hdnMachine");
            ListBox chkMachine = (ListBox)e.Row.FindControl("chkMachine");
            //HiddenField hdnCuttingOB = (HiddenField)e.Row.FindControl("hdnCuttingOB");
            HiddenField hdnOperationId = (HiddenField)e.Row.FindControl("hdnOperationId");
            ListBox lstMachine = (ListBox)e.Row.FindControl("lstMachine");


            DataTable dtFactoryWorkSpace = new DataTable();
            dsMachine = obj_AdminController.GetFactoryWork("Cutting");

            chkMachine.DataSource = dsMachine.Tables[0];
            chkMachine.DataValueField = "FactoryWorkSpace";
            chkMachine.DataTextField = "WorkerType";
            chkMachine.DataBind();

            if (hdnOperationId.Value!="")
            {
            dtMachine = obj_AdminController.GetMachineOB(Convert.ToInt32(hdnOperationId.Value));
            string strMachine = string.Empty;
            string OperationVal = string.Empty;
            //
            string strMachineType = string.Empty;
            string strMachineTypeVal = string.Empty;
            //
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
                    {
                        chkMachine.Items.FindByValue(oprval.ToString()).Selected = true;
                        strMachine += ',' + oprval.ToString();
                        OperationVal = strMachine.Remove(strMachine.IndexOf(","), 1);
                        
                    }
                    
                    hdnMachine.Value = OperationVal;
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
                    grdCuttingOB.HeaderRow.Cells[i + 3].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName + "(SAM)";
                    lblName.Width = 70;
                    grdCuttingOB.HeaderRow.Style.Add("width", "250px");
                    grdCuttingOB.HeaderRow.Style.Add("class", "topMenu2");
                    grdCuttingOB.HeaderRow.Style.Add("text-align", "center");
                    grdCuttingOB.HeaderRow.Cells[i + 3].Controls.Add(lblName);
                    DataTable dtBOSam = new DataTable();

                    if (hdnOperationId.Value!="")
                    dtBOSam = obj_AdminController.GetCuttingOBSam(Convert.ToInt32(hdnOperationId.Value), GarmentId);


                    Decimal OBSam=0;
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
                    txtGarmentType.CssClass = "numeric-field-with-decimal-places";
                    txtGarmentType.Attributes.Add("onchange", "javascript:return SaveCuttingOBSam(this)");
                    e.Row.Cells[i + 3].Controls.Add(txtGarmentType);
                }


            }


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if (ViewState["dtnew"] != null)
            {
                DataTable dtnew = new DataTable();
                //dtnew = (DataTable)(ViewState["dtnew"]);
                dtnew=obj_AdminController.GetCuttingOB(0, 0);
                DataRow newrow = dtnew.NewRow();
                dtnew.Rows.Add(newrow);
                dtmerge = dtnew;
                grdCuttingOB.DataSource = dtmerge;
                grdCuttingOB.DataBind();
                ViewState["dtnew"] = dtmerge;
            }
            else
            {
                dtBindGrid = obj_AdminController.GetCuttingOB(0, 0);
                DataRow newrow = dtBindGrid.NewRow();
                dtBindGrid.Rows.Add(newrow);
                dtmerge = dtBindGrid;
                grdCuttingOB.DataSource = dtmerge;
                grdCuttingOB.DataBind();
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



        #region "METHOD FOR SHOW ALERT"
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        #endregion



    }
}