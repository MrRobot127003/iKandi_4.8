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


namespace iKandi.Web.UserControls.Forms
{
    public partial class AQL_Admin : System.Web.UI.UserControl
    {
        public string AQLNO
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {


            if (null != Request.QueryString["AQLNO"])
            {
                AQLNO = Request.QueryString["AQLNO"].ToString();
                BindAQLWithQuerystring();
            }


            if (!IsPostBack)
            {
                BindDropDown();
            }

           
        }
        public void BindDropDown()
        {
            DataTable dt = new DataTable();            
            QualityController obj = new QualityController();
            dt = obj.GetAllAqlStanderdBAL(0);
            ddlExistingAQL.DataSource = dt;
            ddlExistingAQL.DataTextField = "AQLType";
            ddlExistingAQL.DataValueField = "AQLType";
            ddlExistingAQL.DataBind();            
        }
        public void BindgrdAQL(double AQLtype, double DoubleNewAQL)
        {            
            DataTable dt = new DataTable();
            QualityController obj = new QualityController();
            dt = obj.GetAllAqlExistingStanderdBAL(AQLtype, DoubleNewAQL);
            grdAQL.DataSource=dt;
            grdAQL.DataBind();

        }
        public void BindAQLWithQuerystring()
        {
            BindgrdAQL(Convert.ToDouble(AQLNO), 0.0);
            //btnSave.Visible = false;
            //ddlExistingAQL.Visible = false;
            //btnGO.Visible = false;
            //txtAddNew.Visible = false;
            //btnAddNew.Visible = false;
            //rdofinal.Visible = false;
            //rdomid.Visible = false;
            //rdoinline.Visible = false;

            divAqlfilter.Visible = false;
            divheading.Visible = false;
            btnClose.Visible = true;

            //grdAQL.Columns[4].Visible = false;
            //grdAQL.Columns[5].Visible = false;
            //grdAQL.Columns[6].Visible = false;
            //grdAQL.Columns[7].Visible = false;
            grdAQL.Enabled = false;

        }
        protected void btnGO_Click(object sender, EventArgs e)
        {

            BindgrdAQL(Convert.ToDouble(ddlExistingAQL.SelectedValue),0.0);
            txtAddNew.Text = "";
            btnSave.Visible = true;
            DivMidLine.Visible = false;
            grdAQL.Visible = true;
        }
        public bool CheckTxtNew()
        {
            if (txtAddNew.Text.Trim() == "")
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true,'New Value Required.');";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), script, true);
                return false;
            }
            else
                return true;
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            if (CheckTxtNew())
            {
                Double DoubleNewAQL = Convert.ToDouble(txtAddNew.Text.Trim());
                BindgrdAQL(0.0, DoubleNewAQL);
                btnSave.Visible = true;          
            }
            DivMidLine.Visible = false;
        }
        public bool checkGrd()
        {
            string script = string.Empty;
            int intTemp = 0;
            int s=0;
            foreach (GridViewRow rowTemp in grdAQL.Rows)
            {
                if (((TextBox)rowTemp.FindControl("txtAQLType")).Text == "" &&
                       ((TextBox)rowTemp.FindControl("txtSampleSize")).Text == "" &&
                 ((TextBox)rowTemp.FindControl("txtMajorDefectsPass")).Text == "" &&
                 ((TextBox)rowTemp.FindControl("txtMajorDefectsFail")).Text == "" &&
                 ((TextBox)rowTemp.FindControl("txtMinorDefectsPass")).Text == "" &&
                 ((TextBox)rowTemp.FindControl("txtMinorDefectsFail")).Text == "")
                {
                    s = s + 1;
                }
            }
            if (s == 10)
            {
                script = "ShowHideMessageBox(true,'All AQL Blank Found.');";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), script, true);
                return false;
 
            }
            foreach(GridViewRow rowLast in grdAQL.Rows)
            {
                if (((TextBox)rowLast.FindControl("txtAQLType")).Text != "" ||
                       ((TextBox)rowLast.FindControl("txtSampleSize")).Text != "" ||
                 ((TextBox)rowLast.FindControl("txtMajorDefectsPass")).Text != "" ||
                 ((TextBox)rowLast.FindControl("txtMajorDefectsFail")).Text != "" ||
                 ((TextBox)rowLast.FindControl("txtMinorDefectsPass")).Text != "" ||
                 ((TextBox)rowLast.FindControl("txtMinorDefectsFail")).Text != "")
                {
                    
                    if(((TextBox)rowLast.FindControl("txtSampleSizeFrom")).Text == "")// || ((TextBox)rowLast.FindControl("txtSampleSizeTo")).Text == "" )
                    {
                        script = "ShowHideMessageBox(true,'Shipment Size Blank Found.');";
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), script, true);
                        return false;
                    }                                       
                }
            }
            foreach (GridViewRow row1 in grdAQL.Rows)
            {
                if (((TextBox)row1.FindControl("txtAQLType")).Text != "") 
                {
                    double doubleAQLType = Convert.ToDouble(((TextBox)row1.FindControl("txtAQLType")).Text.Trim());
                    foreach (GridViewRow row2 in grdAQL.Rows)
                    {

                        if (((TextBox)row2.FindControl("txtAQLType")).Text != "")
                        {
                            if (doubleAQLType != Convert.ToDouble(((TextBox)row2.FindControl("txtAQLType")).Text.Trim()))
                            {                               
                                    script = "ShowHideMessageBox(true,'AQL Should be Same.');";
                                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), script, true);
                                    return false;
                              
                            }
                        }
                    }
                }
 
            }
            foreach (GridViewRow row in grdAQL.Rows)
            {
                intTemp = intTemp + 1;
                if (((TextBox)row.FindControl("txtSampleSize")).Text != "" ||
                 ((TextBox)row.FindControl("txtMajorDefectsPass")).Text != "" ||
                 ((TextBox)row.FindControl("txtMajorDefectsFail")).Text != "" ||
                 ((TextBox)row.FindControl("txtMinorDefectsPass")).Text != "" ||
                 ((TextBox)row.FindControl("txtMinorDefectsFail")).Text != "")
                {
                    if (((TextBox)row.FindControl("txtAQLType")).Text == "")
                    {
                        string stringMSG = "Blank AQL Found at Row " + intTemp;
                        script = "ShowHideMessageBox(true,'" + stringMSG + "');";
                        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), script, true);                        
                        return false;
                    }                                    
                }              
            }

            foreach (GridViewRow r in grdAQL.Rows)
            {
                if (((TextBox)r.FindControl("txtAQLType")).Text != "")
                    {
                        if (((TextBox)r.FindControl("txtSampleSize")).Text =="" ||((TextBox)r.FindControl("txtMajorDefectsPass")).Text == "" ||
                 ((TextBox)r.FindControl("txtMajorDefectsFail")).Text == "" ||
                 ((TextBox)r.FindControl("txtMinorDefectsPass")).Text == "" ||
                 ((TextBox)r.FindControl("txtMinorDefectsFail")).Text == "")
                        {
                            string stringMSG = "Fill All Details.";
                            script = "ShowHideMessageBox(true,'" + stringMSG + "');";
                            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), script, true);
                            return false;


                        }
                    }
                        
                        
                     
                
            }




            return true;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool boolStatus = checkGrd();
            if (boolStatus == true)
            {
                string strQuery = "<table>";

                foreach (GridViewRow row in grdAQL.Rows)
                {

                    if (((TextBox)row.FindControl("txtAQLType")).Text == "" &&
                       ((TextBox)row.FindControl("txtSampleSizeFrom")).Text == "" &&
                       ((TextBox)row.FindControl("txtSampleSizeTo")).Text == "" &&
                       ((TextBox)row.FindControl("txtSampleSize")).Text == "" &&
                       ((TextBox)row.FindControl("txtMajorDefectsPass")).Text == "" &&
                       ((TextBox)row.FindControl("txtMajorDefectsFail")).Text == "" &&
                       ((TextBox)row.FindControl("txtMinorDefectsPass")).Text == "" &&
                       ((TextBox)row.FindControl("txtMinorDefectsFail")).Text == "")
                        continue;
                    if (((TextBox)row.FindControl("txtAQLType")).Text == "" &&
                       ((TextBox)row.FindControl("txtSampleSize")).Text == "" &&
                       ((TextBox)row.FindControl("txtMajorDefectsPass")).Text == "" &&
                       ((TextBox)row.FindControl("txtMajorDefectsFail")).Text == "" &&
                       ((TextBox)row.FindControl("txtMinorDefectsPass")).Text == "" &&
                       ((TextBox)row.FindControl("txtMinorDefectsFail")).Text == "")
                        continue;
                    double? AQLType = null;
                    int? SampleSizeFrom = null;
                    int? SampleSizeTo = null;
                    int? SampleSize = null;
                    int? MajorDefectsPass = null;
                    int? MajorDefectsFail = null;
                    int? MinorDefectsPass = null;
                    int? MinorDefectsFail = null;
                    int RangeId=0;

                    if (((TextBox)row.FindControl("txtAQLType")).Text != "")
                        AQLType = Convert.ToDouble(((TextBox)row.FindControl("txtAQLType")).Text.Trim());
                    if (((TextBox)row.FindControl("txtSampleSizeFrom")).Text != "")
                    {
                        SampleSizeFrom = Convert.ToInt32(((TextBox)row.FindControl("txtSampleSizeFrom")).Text.Trim());
                        RangeId = Convert.ToInt16(((HiddenField)row.FindControl("hdnRangeId")).Value);
                    }
                    if (((TextBox)row.FindControl("txtSampleSizeTo")).Text != "")
                        SampleSizeTo = Convert.ToInt32(((TextBox)row.FindControl("txtSampleSizeTo")).Text.Trim());
                    if (((TextBox)row.FindControl("txtSampleSize")).Text != "")
                        SampleSize = Convert.ToInt32(((TextBox)row.FindControl("txtSampleSize")).Text.Trim());
                    if (((TextBox)row.FindControl("txtMajorDefectsPass")).Text != "")
                        MajorDefectsPass = Convert.ToInt32(((TextBox)row.FindControl("txtMajorDefectsPass")).Text.Trim());
                    if (((TextBox)row.FindControl("txtMajorDefectsFail")).Text != "")
                        MajorDefectsFail = Convert.ToInt32(((TextBox)row.FindControl("txtMajorDefectsFail")).Text.Trim());
                    if (((TextBox)row.FindControl("txtMinorDefectsPass")).Text != "")
                        MinorDefectsPass = Convert.ToInt32(((TextBox)row.FindControl("txtMinorDefectsPass")).Text.Trim());
                    if (((TextBox)row.FindControl("txtMinorDefectsFail")).Text != "")
                        MinorDefectsFail = Convert.ToInt32(((TextBox)row.FindControl("txtMinorDefectsFail")).Text.Trim());
                    strQuery = strQuery + "<AQLType>" + AQLType + "</AQLType><SampleSizeFrom>" + SampleSizeFrom +
                    "</SampleSizeFrom><SampleSizeTo>" + SampleSizeTo + "</SampleSizeTo><SampleSize>" + SampleSize +
                    "</SampleSize><MajorDefectsPass>" + MajorDefectsPass + "</MajorDefectsPass><MajorDefectsFail>" + MajorDefectsFail +
                    "</MajorDefectsFail><MinorDefectsPass>" + MinorDefectsPass + "</MinorDefectsPass><MinorDefectsFail>" + MinorDefectsFail +
                    "</MinorDefectsFail><RangeId>"+RangeId.ToString()+"</RangeId>";
                }
                strQuery = strQuery + "</table>";
                if (strQuery != "<table></table>")
                {
                    string script = string.Empty;
                    QualityController obj = new QualityController();
                    obj.InserNewAQLBAL(strQuery);
                    script = "ShowHideMessageBox(true,'Added New AQL Successfully.');";
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), script, true);
                    return;

                }
            }
        }

        protected void grdAQL_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "AQL";
                HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "SIZE CHART";
                HeaderCell.ColumnSpan = 3;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

               
                    HeaderCell = new TableCell();
                    HeaderCell.Text = "MAJOR DEFECTS";
                    HeaderCell.ColumnSpan = 2;
                    HeaderCell.Style.Add("text-align", "center");
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                    HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    HeaderGridRow.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "MINOR DEFECTS";
                    HeaderCell.ColumnSpan = 2;
                    HeaderCell.Style.Add("text-align", "center");
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                    HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    HeaderGridRow.Cells.Add(HeaderCell);
               

                grdAQL.Controls[0].Controls.AddAt(0, HeaderGridRow);

                GridViewRow HeaderGridRow1 = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                HeaderCell = new TableCell();
                HeaderCell.Text = "SHIPMENT SIZE";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.ColumnSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow1.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "AQL SAMPLE SIZE ";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow1.Cells.Add(HeaderCell);
                
                    HeaderCell = new TableCell();
                    HeaderCell.Text = "PASS";
                    HeaderCell.Style.Add("text-align", "center");
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                    HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    HeaderGridRow1.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "FAIL";
                    HeaderCell.Style.Add("text-align", "center");
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                    HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    HeaderGridRow1.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "PASS";
                    HeaderCell.Style.Add("text-align", "center");
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                    HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    HeaderGridRow1.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "FAIL";
                    HeaderCell.Style.Add("text-align", "center");
                    HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                    HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    HeaderGridRow1.Cells.Add(HeaderCell);
                

                grdAQL.Controls[0].Controls.AddAt(1, HeaderGridRow1); 

            }
        }

        protected void grdAQL_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
              //  e.Row.Cells[1].ColumnSpan = 2;
              //  e.Row.Cells[2].ColumnSpan = 2;

              

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               // e.Row.Cells[1].ColumnSpan = 2;
               // e.Row.Cells[2].ColumnSpan = 2;

               
            }

        }
        //added by abhishek on 11/5/2016
        protected void rdofinal_CheckedChanged(object sender, EventArgs e)
        {
            DivMidLine.Visible = false;
            grdAQL.Visible = true;
            btnSave.Visible = true;
            divfinal.Visible = true;

            BindgrdAQL(Convert.ToDouble(ddlExistingAQL.SelectedValue), 0.0);
            txtAddNew.Text = "";
            btnSave.Visible = true;
            DivMidLine.Visible = false;
            grdAQL.Visible = true;
           
           
        }

        protected void rdomid_CheckedChanged(object sender, EventArgs e)
        {
            string AQLType = string.Empty;
            string type = string.Empty;

            if (rdofinal.Checked)
            {
                AQLType = "FINALAQL";
            }
            if (rdomid.Checked)
            {
                AQLType = "MIDAQL";
                type = "MID AQL";
            }
            if (rdoinline.Checked)
            {
                AQLType = "INLINE";
                type = "INLINE AQL";
            }
            DivMidLine.Visible = true;
            grdAQL.Visible = false;
            btnSave.Visible = false;
            divfinal.Visible = false;
            this.BindMidLineGrd(AQLType);
        }

        protected void rdoinline_CheckedChanged(object sender, EventArgs e)
        {
            string AQLType = string.Empty;
            string type = string.Empty;

            if (rdofinal.Checked)
            {
                AQLType = "FINALAQL";
            }
            if (rdomid.Checked)
            {
                AQLType = "MIDAQL";
                type = "MID AQL";
            }
            if (rdoinline.Checked)
            {
                AQLType = "INLINE";
                type = "INLINE AQL";
            }
            DivMidLine.Visible = true;
            grdAQL.Visible = false;
            btnSave.Visible = false;
            divfinal.Visible = false;
            this.BindMidLineGrd(AQLType);

        }
        public void BindMidLineGrd(string AQLType)
        {
            DataTable dt = new DataTable();

            QualityController obj = new QualityController();
            dt = obj.GetAllAqlExistingStanderdMINLINEDAL(AQLType);
            if (dt.Rows.Count > 0)
            {
                txtSampleSize.Text = dt.Rows[0]["SampleSize"].ToString() == "0" ? "" : dt.Rows[0]["SampleSize"].ToString();
                MajorPass.Text = dt.Rows[0]["MajorDefectsPass"].ToString() == "0" ? "" : dt.Rows[0]["MajorDefectsPass"].ToString();
                MajorFail.Text = dt.Rows[0]["MajorDefectsFail"].ToString() == "0" ? "" : dt.Rows[0]["MajorDefectsFail"].ToString();
                MinorPass.Text = dt.Rows[0]["MinorDefectsPass"].ToString() == "0" ? "" : dt.Rows[0]["MinorDefectsPass"].ToString();
                MinorFail.Text = dt.Rows[0]["MinorDefectsFail"].ToString() == "0" ? "" : dt.Rows[0]["MinorDefectsFail"].ToString();
            }
           

 

        }
        protected void btnsavemid_Click(object sender, EventArgs e)
        {
            
           
            int SampleSize ;
            int MajorDefectsPass;
            int MajorDefectsFail ;
            int MinorDefectsPass ;
            int MinorDefectsFail ;
            SampleSize = Convert.ToInt32(txtSampleSize.Text.Trim());
            MajorDefectsPass = Convert.ToInt32(MajorPass.Text.Trim());
            MajorDefectsFail = Convert.ToInt32(MajorFail.Text.Trim());

            MinorDefectsPass = Convert.ToInt32(MinorPass.Text.Trim());
            MinorDefectsFail = Convert.ToInt32(MinorFail.Text.Trim());

          




            string AQLType = string.Empty;
            string type = string.Empty;

            if (rdofinal.Checked)
            {
                AQLType = "FINALAQL";
            }
            if (rdomid.Checked)
            {
                AQLType = "MIDAQL";
                type = "MID AQL";
            }
            if (rdoinline.Checked)
            {
                AQLType = "INLINE";
                type = "INLINE AQL";
            }
            string script = string.Empty;
            if (MajorDefectsPass >= SampleSize)
            {
                script = "ShowHideMessageBox(true,'Major Defects Pass quantity should be less then sample size quantity.!');";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), script, true);
                MajorPass.Focus();
                MajorPass.BorderColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                MajorPass.BorderWidth = 1;
             
                return;
            }
            else if (MajorDefectsFail <= MajorDefectsPass)
            {
                script = "ShowHideMessageBox(true,'Major Defects Fail quantity should be always greater then Major Defects Pass quantity');";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), script, true);
                MajorFail.Focus();
                MajorFail.CssClass = "error";
                return;
            }
            else if (MajorDefectsFail >= SampleSize)
            {
                script = "ShowHideMessageBox(true,'Major Defects Fail quantity cannot be greater then sampleSize quantity');";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), script, true);
                txtSampleSize.Focus();
                txtSampleSize.CssClass = "error";
                return;
            }

            if (MinorDefectsPass >= SampleSize)
            {
                script = "ShowHideMessageBox(true,'Minor Defects Pass quantity should be less then sample size quantity.!');";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), script, true);
                MinorPass.Focus();
                MinorPass.CssClass = "error";
                return;
            }
            else if (MinorDefectsFail <= MinorDefectsPass)
            {
                script = "ShowHideMessageBox(true,'Minor Defects Fail quantity should be always greater then Minor Defects Pass quantity');";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), script, true);

                return;
            }
            else if (MinorDefectsFail >= SampleSize)
            {
                script = "ShowHideMessageBox(true,'Minor Defects Fail quantity cannot be greater then sampleSize quantity');";
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), script, true);

                return;
            }
            QualityController obj = new QualityController();
            int result = obj.InserNewAQLMidInLineDAL(SampleSize, MajorDefectsPass, MajorDefectsFail, MinorDefectsPass, MinorDefectsFail, AQLType);
            script = "ShowHideMessageBox(true,'Updated" +" "+ type + " "+"Successfully.');";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), script, true);
            this.BindMidLineGrd(AQLType);
            return;

        }
        //end by abhishek on 11/5/2016
    }
}