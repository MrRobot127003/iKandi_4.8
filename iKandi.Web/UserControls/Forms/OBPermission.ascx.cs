﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.BLL;
using System.Web.UI.HtmlControls;
using iKandi.Web.Components;
using iKandi.Common;

namespace iKandi.Web.UserControls.Forms
{
    public partial class OBPermission : System.Web.UI.UserControl
    {
        PermissionController obj_Permission = new PermissionController();
        DataTable dt;
      
        DataSet dsPermission;
        
        DataTable dtgrd1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dt = obj_Permission.GetMoDesignation(1);
                dtgrd1 = obj_Permission.GetMoDesignationgrd1(1);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 2; i < dt.Rows.Count + 2; i++)
                    {
                        BoundField boundField = new BoundField();
                        boundField.HeaderText = "";

                        grdPermission.Columns.Add(boundField);
                    }
                }
                //if (dtgrd1.Rows.Count > 0)
                //{
                //    for (int i = 2; i < dtgrd1.Rows.Count + 2; i++)
                //    {
                //        BoundField boundField = new BoundField();
                //        boundField.HeaderText = "";


                //        GridView1.Columns.Add(boundField);
                //    }
                //}
                BindGrd();



            }

        }
        protected void BindGrd()
        {
            DataSet dst = new DataSet();

           
            DataTable dtgrd = new DataTable();
            dtgrd = obj_Permission.GetOBSection();
           
            grdPermission.DataSource = dtgrd;
            grdPermission.DataBind();

            GridView1.DataSource = dtgrd;
            GridView1.DataBind();
            

        }
        public void AddGridview(DataTable dt, GridView gv)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string colName = dt.Rows[i]["Name"].ToString();
                    gv.HeaderRow.Cells[i].Text = colName;
                    //gv.RowHeaderColumn = colName;

                }
            }
        }
        protected void grdPermission_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            string colName = string.Empty;
            string DesignationId = string.Empty;
            int DeptId = 0;
            int DesigId = 0;
            dt = obj_Permission.GetMoDesignation(1);

            if (dt.Rows.Count > 0)
            {

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                     
                    colName = dt.Rows[i]["Name"].ToString();
                    DesignationId = dt.Rows[i]["DesignationId"].ToString();
                    DeptId = Convert.ToInt32(dt.Rows[i]["DeptId"].ToString());
                    DesigId = Convert.ToInt32(dt.Rows[i]["DesignationId"].ToString());
                    grdPermission.HeaderRow.Cells[i + 2].Text = colName;

                    HiddenField hdnMOSectionID = (HiddenField)e.Row.FindControl("hdnMOSectionID");
                    HiddenField hdnMOCoulmeID = (HiddenField)e.Row.FindControl("hdnMOCoulmeID");
                    dsPermission = obj_Permission.GetAllPermissionListById_For_OB(DeptId, DesigId, Convert.ToInt32(hdnMOSectionID.Value), Convert.ToInt32(hdnMOCoulmeID.Value));
                    //dtFilter = obj_Permission.GetFilterPermissionById(DeptId, DesigId);
                   
                    
                    
                    //For Bind Designation Header
                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName;
                    lblName.Width = 160;
                    lblName.Height = 30;
                    grdPermission.HeaderRow.Style.Add("height", "30px");
                    grdPermission.HeaderRow.Style.Add("width", "250px");
                    grdPermission.HeaderRow.Style.Add("class", "topMenu2");
                    grdPermission.HeaderRow.Style.Add("text-align", "center");
                    grdPermission.HeaderRow.Cells[i + 2].Controls.Add(lblName);

                    CheckBox chkHRead = new CheckBox();
                    chkHRead.EnableViewState = true;
                    chkHRead.Enabled = true;
                    chkHRead.ID = "HchkR_" + DeptId + "_" + DesigId + "_" + i;
                    chkHRead.Text = "Read";
                    if (dsPermission.Tables[1].Rows.Count > 0)
                    {
                        chkHRead.Checked = Convert.ToBoolean(dsPermission.Tables[1].Rows[0]["Read"].ToString());
                    }
                    else
                    {
                        chkHRead.Checked = false;
                    }
                    chkHRead.Attributes.Add("class", "HR" + DeptId + DesigId + " " + "fontbold");
                    chkHRead.Attributes.Add("onclick", "javascript:return checkboxReadCheckedAll(this)");
                    grdPermission.HeaderRow.Cells[i + 2].Controls.Add(chkHRead);

                    CheckBox chkHwrite = new CheckBox();
                    chkHwrite.EnableViewState = true;
                    chkHwrite.Enabled = true;
                    chkHwrite.ID = "HchkW_" + DeptId + "_" + DesigId + "_" + i;
                    chkHwrite.Text = "write";
                    if (dsPermission.Tables[1].Rows.Count > 0)
                    {
                        chkHwrite.Checked = Convert.ToBoolean(dsPermission.Tables[1].Rows[0]["Write"].ToString());
                    }
                    else
                    {
                        chkHwrite.Checked = false;
                    }
                    chkHwrite.Attributes.Add("class", "HW" + DeptId + DesigId + " " + "fontbold");
                    chkHwrite.Attributes.Add("onclick", "javascript:return checkboxWriteCheckedAll(this)");
                    grdPermission.HeaderRow.Cells[i + 2].Controls.Add(chkHwrite);
                    //
                    //For Bind Common Checkbox
                    CheckBox chkRead = new CheckBox();
                    chkRead.EnableViewState = true;
                    chkRead.Enabled = true;
                    chkRead.ID = "chkR" + DeptId + "_" + DesigId + "_" + i;
                    chkRead.Text = "Read";
                    //if (result.Length > 0)
                    //{
                    //    chkRead.Checked = Convert.ToBoolean(result[0].ItemArray[9]);
                    //}
                    chkRead.Attributes.Add("class", "R" + DeptId + DesigId);
                    chkRead.Attributes.Add("onclick", "javascript:return checkboxReadChecked(this)");
                    e.Row.Cells[i + 2].Controls.Add(chkRead);

                    CheckBox chkWrite = new CheckBox();
                    chkWrite.EnableViewState = true;
                    chkWrite.Enabled = true;
                    chkWrite.ID = "chkW" + DeptId + "_" + DesigId + "_" + i;
                    chkWrite.Text = "Write";
                    chkWrite.Attributes.Add("class", "W" + DeptId + DesigId);
                    chkWrite.Attributes.Add("onclick", "javascript:return checkboxWriteChecked(this)");
                    e.Row.Cells[i + 2].Controls.Add(chkWrite);

                    CheckBox Read = (CheckBox)e.Row.FindControl("chkR" + DeptId + "_" + DesigId + "_" + i);
                    CheckBox Write = (CheckBox)e.Row.FindControl("chkW" + DeptId + "_" + DesigId + "_" + i);

                    if (dsPermission.Tables[0].Rows.Count > 0)
                    {
                        Read.Checked = Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["PermisionRead"].ToString());
                    }
                    else
                    {
                        Read.Checked = false;
                    }

                    if (dsPermission.Tables[0].Rows.Count > 0)
                    {
                        Write.Checked = Convert.ToBoolean(dsPermission.Tables[0].Rows[0]["PermisionWrite"].ToString());
                    }
                    else
                    {
                        Write.Checked = false;
                    }


                }



            }

            grdPermission.Columns[0].Visible = false;
            grdPermission.Columns[1].Visible = false;

        }

        private TableCell GetHeaerCell()
        {
            TableCell HeaderCell = new TableCell();
            HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#eaeaea");
            HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#151515");
            HeaderCell.CssClass = "bgimg";

            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BorderWidth = 1;
            return HeaderCell;
        }

        protected void grdPermission_RowCreated1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header)
                return;

            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(2, 2, DataControlRowType.Header, DataControlRowState.Insert);

            int count = 0;

            TableCell HeaderCell = GetHeaerCell();
           

            HeaderCell = GetHeaerCell();
            HeaderCell.Text = "Design";
            int ColCount1 = Convert.ToInt32(obj_Permission.GetMoDeptcount(1));
           
            HeaderCell.ColumnSpan = ColCount1;
            HeaderCell.Width = 150;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = GetHeaerCell();
            HeaderCell.Text = "Sales ikandi";
            int ColCount2 = Convert.ToInt32(obj_Permission.GetMoDeptcount(2));
            HeaderCell.ColumnSpan = ColCount2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = GetHeaerCell();
            HeaderCell.Text = "Technical iKandi";
            int ColCount3 = Convert.ToInt32(obj_Permission.GetMoDeptcount(3));
            HeaderCell.ColumnSpan = ColCount3;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = GetHeaerCell();
            HeaderCell.Text = "Finance/Logistics";
            int ColCount4 = Convert.ToInt32(obj_Permission.GetMoDeptcount(4));
            HeaderCell.ColumnSpan = ColCount4;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = GetHeaerCell();
            HeaderCell.Text = "Top Management BIPL";
            int ColCount5 = Convert.ToInt32(obj_Permission.GetMoDeptcount(5));
            HeaderCell.ColumnSpan = ColCount5;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = GetHeaerCell();
            HeaderCell.Text = "Merchandising";
            int ColCount6 = Convert.ToInt32(obj_Permission.GetMoDeptcount(6));
            HeaderCell.ColumnSpan = ColCount6;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = GetHeaerCell();
            HeaderCell.Text = "Fabrics";
            int ColCount7 = Convert.ToInt32(obj_Permission.GetMoDeptcount(7));
            HeaderCell.ColumnSpan = ColCount7;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = GetHeaerCell();
            HeaderCell.Text = "Accessory";
            int ColCount8 = Convert.ToInt32(obj_Permission.GetMoDeptcount(8));
            HeaderCell.ColumnSpan = ColCount8;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = GetHeaerCell();
            HeaderCell.Text = "QA";
            int ColCount9 = Convert.ToInt32(obj_Permission.GetMoDeptcount(9));
            HeaderCell.ColumnSpan = ColCount9;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = GetHeaerCell();
            HeaderCell.Text = "Production";
            int ColCount10 = Convert.ToInt32(obj_Permission.GetMoDeptcount(10));
            HeaderCell.ColumnSpan = ColCount10;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = GetHeaerCell();
            HeaderCell.Text = "Logistics";
            int ColCount11 = Convert.ToInt32(obj_Permission.GetMoDeptcount(11));
            count = Convert.ToInt32(obj_Permission.GetMoDeptcount(11));
            ViewState["count"] = count;
            HeaderCell.ColumnSpan = ColCount11;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = GetHeaerCell();
            HeaderCell.Text = "TopManagement Ikandi";
            int ColCount12 = Convert.ToInt32(obj_Permission.GetMoDeptcount(12));
            HeaderCell.ColumnSpan = ColCount12;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = GetHeaerCell();
            HeaderCell.Text = "Technical BIPL";
            int ColCount13 = Convert.ToInt32(obj_Permission.GetMoDeptcount(15));
            HeaderCell.ColumnSpan = ColCount13;
            HeaderGridRow.Cells.Add(HeaderCell);


            HeaderCell = GetHeaerCell();
            HeaderCell.Text = "Client";
            HeaderCell.ColumnSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderGrid.Controls[0].Controls.AddAt(0, HeaderGridRow);
            HeaderGridRow = new GridViewRow(1, 2, DataControlRowType.Header, DataControlRowState.Insert);
            HeaderGrid.Controls[0].Controls.AddAt(1, HeaderGridRow);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            string colName = string.Empty;
            string DesignationId = string.Empty;
            dtgrd1 = obj_Permission.GetMoDesignationgrd1(1);

            if (dt.Rows.Count > 0)
            {

              for (int i = 0; i < dtgrd1.Rows.Count; i++)
              {
            //        //colName = dt.Rows[i]["Name"].ToString();
            //        DesignationId = dt.Rows[i]["DesignationId"].ToString();
            //        DeptId = Convert.ToInt32(dt.Rows[i]["DeptId"].ToString());
            //        DesigId = Convert.ToInt32(dt.Rows[i]["DesignationId"].ToString());

            //        HiddenField hdnMOSectionID = (HiddenField)e.Row.FindControl("hdnMOSectionID");
            //        HiddenField hdnMOCoulmeID = (HiddenField)e.Row.FindControl("hdnMOCoulmeID");
            //        dsPermission = obj_Permission.GetAllPermissionListById(DeptId, DesigId, Convert.ToInt32(hdnMOSectionID.Value), Convert.ToInt32(hdnMOCoulmeID.Value));
            //        dtFilter = obj_Permission.GetFilterPermissionById(DeptId, DesigId);
            //        //For Bind Designation Header

                Label lblName = new Label();
                lblName.EnableViewState = true;
                lblName.Enabled = true;
                lblName.ID = "lal" + i;
                lblName.Width = 16;
                lblName.Height = 10;
                lblName.Text = "";
                //GridView1.HeaderRow.Style.Add("background-color", "#50d07d");
                GridView1.HeaderRow.Style.Add("height", "10px");
                GridView1.HeaderRow.Style.Add("width", "250px");
                GridView1.HeaderRow.Style.Add("text-align", "center");
                GridView1.HeaderRow.Cells[i].Controls.Add(lblName);


              

                }
            }

        }

        protected void GridView1_RowCreated1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header)
                return;

            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(2, 2, DataControlRowType.Header, DataControlRowState.Insert);

            //int count = 0;

            TableCell HeaderCell = GetHeaerCell();
            HeaderCell.Text = "Section";
            HeaderCell.ColumnSpan = 0;
            
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = GetHeaerCell();
            HeaderCell.Text = "Field";
            HeaderCell.ColumnSpan = 0;
            HeaderGridRow.Cells.Add(HeaderCell);

            //HeaderCell = GetHeaerCell();
            //HeaderCell.Text = "";
            //HeaderCell.ColumnSpan = 0;
            //HeaderGridRow.Cells.Add(HeaderCell);


            HeaderGrid.Controls[0].Controls.AddAt(0, HeaderGridRow);
            HeaderGridRow = new GridViewRow(1, 2, DataControlRowType.Header, DataControlRowState.Insert);
            HeaderGrid.Controls[0].Controls.AddAt(1, HeaderGridRow);
        }
       


    }
}