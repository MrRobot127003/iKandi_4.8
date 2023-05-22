using System;
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
    public partial class MOPermissionFormNew : System.Web.UI.UserControl
    {
        PermissionController obj_Permission = new PermissionController();
        DataTable dt;
        
        DataSet dsPermission;
        DataTable dtFilter;
        DataTable dtgrd1;
        DataTable dtDesignCount;
        DataSet DS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DS = obj_Permission.GetNewMoSection(1);
                dt = DS.Tables[0];
                dtgrd1 = DS.Tables[1];
                dtDesignCount = DS.Tables[2];

                //dt = obj_Permission.GetMoDesignation(1);
                //dtgrd1 = obj_Permission.GetMoDesignationgrd1(1);
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
            DataTable dtgrd = new DataTable();
            dtgrd = obj_Permission.GetNewMoSection(0).Tables[3];
            //DataTable dt1 = dtgrd.AsEnumerable().Take(10).CopyToDataTable();
            grdPermission.DataSource = dtgrd;
            grdPermission.DataBind();

            grdPermission.Width = 400 + 103 * dtgrd.Rows.Count;

            //GridView1.DataSource = dtgrd;
            //GridView1.DataBind();


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
            dt = obj_Permission.GetNewMoSection(1).Tables[0];

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
                    // DataRow[] result = dtPermission.Select("DepartmentID =" + DeptId + " AND DesignationID=" + DesigId + " AND SectionID=" + hdnMOSectionID.Value + " AND CoulmeID=" + hdnMOCoulmeID.Value);
                    dsPermission = obj_Permission.GetAllPermissionListById(DeptId, DesigId, Convert.ToInt32(hdnMOSectionID.Value), Convert.ToInt32(hdnMOCoulmeID.Value));
                    dtFilter = obj_Permission.GetFilterPermissionById(DeptId, DesigId);
                    //For Bind Designation Header
                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lal" + i;
                    lblName.Text = colName;
                    lblName.Style.Add("display", "block");
                    grdPermission.HeaderRow.Style.Add("width", "100px");
                    grdPermission.HeaderRow.Style.Add("class", "topMenu2");
                    grdPermission.HeaderRow.Style.Add("text-align", "center");
                    grdPermission.HeaderRow.Cells[i + 2].Controls.Add(lblName);

                    CheckBox chkHRead = new CheckBox();
                    chkHRead.EnableViewState = true;
                    chkHRead.Enabled = true;
                    chkHRead.ID = "HchkR_" + DeptId + "_" + DesigId + "_" + i;
                    chkHRead.Text = "Read";
                    //if (dsPermission.Tables[1].Rows.Count > 0)
                    //{
                    //    chkHRead.Checked = Convert.ToBoolean(dsPermission.Tables[1].Rows[0]["Read"].ToString());
                    //}
                    //else
                    //{
                    //    chkHRead.Checked = false;
                    //}
                    chkHRead.Attributes.Add("class", "HR" + DeptId + DesigId + " " + "fontbold");
                    chkHRead.Attributes.Add("onclick", "javascript:return checkboxReadCheckedAll(this)");
                    grdPermission.HeaderRow.Cells[i + 2].Controls.Add(chkHRead);

                    CheckBox chkHwrite = new CheckBox();
                    chkHwrite.EnableViewState = true;
                    chkHwrite.Enabled = true;
                    chkHwrite.ID = "HchkW_" + DeptId + "_" + DesigId + "_" + i;
                    chkHwrite.Text = "write";
                    //if (dsPermission.Tables[1].Rows.Count > 0)
                    //{
                    //    chkHwrite.Checked = Convert.ToBoolean(dsPermission.Tables[1].Rows[0]["Write"].ToString());
                    //}
                    //else
                    //{
                    //    chkHwrite.Checked = false;
                    //}
                    chkHwrite.Attributes.Add("class", "HW" + DeptId + DesigId + " " + "fontbold");
                    chkHwrite.Attributes.Add("onclick", "javascript:return checkboxWriteCheckedAll(this)");
                    grdPermission.HeaderRow.Cells[i + 2].Controls.Add(chkHwrite);

                    chkHRead.Enabled = Convert.ToBoolean(dsPermission.Tables[2].Rows[0]["ReadEnable"].ToString());
                    chkHwrite.Enabled = Convert.ToBoolean(dsPermission.Tables[2].Rows[0]["WriteEnable"].ToString());
                    //
                    //For Bind Common Checkbox
                    //=================================================================================
                    CheckBox chkRead = new CheckBox();
                    chkRead.EnableViewState = true;
                    chkRead.Enabled = true;
                    chkRead.ID = "chkR" + DeptId + "_" + DesigId + "_" + i;
                    chkRead.Text = "Read";
                    //if (result.Length > 0)
                    //{
                    //    chkRead.Checked = Convert.ToBoolean(result[0].ItemArray[9]);
                    //}

                    chkRead.Attributes.Add("class", "R" + DeptId + DesigId + hdnMOCoulmeID.Value);
                    chkRead.Attributes.Add("onclick", "javascript:return checkboxReadChecked(this)");
                    e.Row.Cells[i + 2].Controls.Add(chkRead);

                    CheckBox chkWrite = new CheckBox();
                    chkWrite.EnableViewState = true;
                    chkWrite.Enabled = true;
                    chkWrite.ID = "chkW" + DeptId + "_" + DesigId + "_" + i;
                    chkWrite.Text = "Write";
                    chkWrite.Attributes.Add("class", "W" + DeptId + DesigId + hdnMOCoulmeID.Value);
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
                    Read.Enabled = Convert.ToBoolean(dsPermission.Tables[2].Rows[0]["ReadEnable"].ToString());
                    Write.Enabled = Convert.ToBoolean(dsPermission.Tables[2].Rows[0]["WriteEnable"].ToString());
                    //
                    //For Buying House
                    if (hdnMOSectionID.Value == "-1" && hdnMOCoulmeID.Value == "110")
                    {
                        DropDownList ddlGroupBy = new DropDownList();
                        ddlGroupBy.EnableViewState = true;
                        ddlGroupBy.Enabled = true;
                        ddlGroupBy.ID = "ddlGroupBy_" + DeptId + "_" + DesigId + "_" + i;
                        ddlGroupBy.Width = 100;
                        ddlGroupBy.Attributes.Add("class", "ddl" + DeptId + DesigId);
                        ddlGroupBy.Items.Add(new ListItem("Slect All", "-1"));
                        ddlGroupBy.Items.Add(new ListItem("Ex-Factory", "1"));
                        ddlGroupBy.Items.Add(new ListItem("D C", "2"));
                        ddlGroupBy.Items.Add(new ListItem("Order Date", "3"));
                        //ddlGroupBy.Attributes.Add("onchange", "javascript:return SelectFilterOption(this,'GroupBy')");
                        e.Row.Cells[i + 2].Controls.Add(ddlGroupBy);

                        BuyingHouseController objBuyingHouseController = new BuyingHouseController();
                        DropDownList ddlGroup = (DropDownList)e.Row.FindControl("ddlGroupBy_" + DeptId + "_" + DesigId + "_" + i);
                        if (dtFilter.Rows.Count > 0)
                        {
                            int GroupId = Convert.ToInt32(dtFilter.Rows[0]["RecordGroupBy"]);
                            ddlGroup.SelectedValue = GroupId.ToString();
                        }
                        if (Read.Checked != false)
                        {
                            ddlGroup.Enabled = false;

                        }
                        else
                        {
                            ddlGroup.Enabled = true;
                        }
                    }
                    //
                    //For Buying House
                    if (hdnMOSectionID.Value == "-1" && hdnMOCoulmeID.Value == "111")
                    {
                        DropDownList ddlBuyingHouse = new DropDownList();
                        ddlBuyingHouse.EnableViewState = true;
                        ddlBuyingHouse.Enabled = true;
                        ddlBuyingHouse.ID = "ddlBuyingHouse_" + DeptId + "_" + DesigId + "_" + i;
                        ddlBuyingHouse.Width = 100;
                        ddlBuyingHouse.Attributes.Add("class", "ddl" + DeptId + DesigId);
                        //ddlBuyingHouse.Attributes.Add("onchange", "javascript:return SelectFilterOption(this,'BuyingHouse')");
                        e.Row.Cells[i + 2].Controls.Add(ddlBuyingHouse);

                        BuyingHouseController objBuyingHouseController = new BuyingHouseController();
                        DropDownList ddlBH = (DropDownList)e.Row.FindControl("ddlBuyingHouse_" + DeptId + "_" + DesigId + "_" + i);
                        if (dtFilter.Rows.Count > 0)
                        {
                            int BuyingHouseId = Convert.ToInt32(dtFilter.Rows[0]["BuyingHouseSelection"]);
                            ddlBH.SelectedValue = BuyingHouseId.ToString();
                        }
                        if (Read.Checked != false)
                        {
                            ddlBH.Enabled = false;
                        }
                        else
                        {
                            ddlBH.Enabled = true;
                        }
                        ddlBH.DataSource = objBuyingHouseController.GetAllBuyingHouseBAL(ApplicationHelper.LoggedInUser.UserData.CompanyID);
                        ddlBH.DataTextField = "CompanyName";
                        ddlBH.DataValueField = "ID";
                        ddlBH.DataBind();
                    }
                    //
                    //For Status From
                    if (hdnMOSectionID.Value == "-1" && hdnMOCoulmeID.Value == "112")
                    {
                        DropDownList ddlStatusFrm = new DropDownList();
                        ddlStatusFrm.EnableViewState = true;
                        ddlStatusFrm.Enabled = true;
                        ddlStatusFrm.ID = "ddlStatusFrom_" + DeptId + "_" + DesigId + "_" + i;
                        ddlStatusFrm.Width = 100;
                        ddlStatusFrm.Attributes.Add("class", "ddl" + DeptId + DesigId);
                        ddlStatusFrm.Items.Add(new ListItem("select", "0"));
                        //ddlStatusFrm.Attributes.Add("onchange", "javascript:return SelectFilterOption(this,'StatusFrom')");
                        e.Row.Cells[i + 2].Controls.Add(ddlStatusFrm);

                        DropDownList ddlStatusF = (DropDownList)e.Row.FindControl("ddlStatusFrom_" + DeptId + "_" + DesigId + "_" + i);
                        if (Read.Checked != false)
                        {
                            ddlStatusF.Enabled = false;
                        }
                        else
                        {
                            ddlStatusF.Enabled = true;
                        }
                        //DropdownHelper.BindFilteredStatusModeBySequence(ddlStatusFrm,
                        //                                            ApplicationHelper.LoggedInUser.UserData.DesignationID);
                        if (dtFilter.Rows.Count > 0)
                        {
                            int StatusFromId = Convert.ToInt32(dtFilter.Rows[0]["StatusFrom"]);
                            ddlStatusF.SelectedValue = StatusFromId.ToString();
                        }

                    }
                    //For Status To
                    if (hdnMOSectionID.Value == "-1" && hdnMOCoulmeID.Value == "113")
                    {
                        DropDownList ddlStatusTo = new DropDownList();
                        ddlStatusTo.EnableViewState = true;
                        ddlStatusTo.Enabled = true;
                        ddlStatusTo.ID = "ddlStatusTo_" + DeptId + "_" + DesigId + "_" + i;
                        ddlStatusTo.Width = 100;
                        ddlStatusTo.Attributes.Add("class", "ddl" + DeptId + DesigId);
                        ddlStatusTo.Items.Add(new ListItem("All", "0"));
                        //ddlStatusTo.Attributes.Add("onchange", "javascript:return SelectFilterOption(this,'StatusTo')");
                        e.Row.Cells[i + 2].Controls.Add(ddlStatusTo);

                        DropDownList ddlStatusT = (DropDownList)e.Row.FindControl("ddlStatusTo_" + DeptId + "_" + DesigId + "_" + i);
                        if (Read.Checked != false)
                        {
                            ddlStatusT.Enabled = false;
                        }
                        else
                        {
                            ddlStatusT.Enabled = true;
                        }
                        //DropdownHelper.BindFilteredStatusModeBySequence(ddlStatusT,
                        //                                            ApplicationHelper.LoggedInUser.UserData.DesignationID);
                        if (dtFilter.Rows.Count > 0)
                        {
                            int StatusToId = Convert.ToInt32(dtFilter.Rows[0]["StatusTo"]);
                            ddlStatusT.SelectedValue = StatusToId.ToString();
                        }
                    }
                    //
                    //For Filter OrderBy
                    if (hdnMOSectionID.Value == "-1" && hdnMOCoulmeID.Value == "114")
                    {
                        DropDownList ddlFilter1 = new DropDownList();
                        ddlFilter1.EnableViewState = true;
                        ddlFilter1.Enabled = true;
                        ddlFilter1.ID = "ddl1_" + DeptId + "_" + DesigId + "_" + i;
                        ddlFilter1.Width = 100;
                        ddlFilter1.Attributes.Add("class", "ddl" + DeptId + DesigId);
                        ddlFilter1.Items.Add(new ListItem("Slect All", "-1"));
                        ddlFilter1.Items.Add(new ListItem("Buyer", "1"));
                        ddlFilter1.Items.Add(new ListItem("Style Number", "2"));
                        ddlFilter1.Items.Add(new ListItem("Dept.", "3"));
                        ddlFilter1.Items.Add(new ListItem("Ex-Factory", "4"));
                        ddlFilter1.Items.Add(new ListItem("Status", "5"));
                        ddlFilter1.Items.Add(new ListItem("Order Date", "6"));

                        ddlFilter1.Attributes.Add("onchange", "javascript:return SelectFilterOption(this,1)");
                        e.Row.Cells[i + 2].Controls.Add(ddlFilter1);

                        DropDownList ddlFilter2 = new DropDownList();
                        ddlFilter2.EnableViewState = true;
                        ddlFilter2.Enabled = true;
                        ddlFilter2.ID = "ddl2_" + DeptId + "_" + DesigId + "_" + i;
                        ddlFilter2.Attributes.Add("class", "ddl" + DeptId + DesigId);
                        ddlFilter2.Width = 100;
                        ddlFilter2.Attributes.Add("class", "ddl" + DeptId + DesigId);
                        ddlFilter2.Items.Add(new ListItem("Slect All", "-1"));
                        ddlFilter2.Items.Add(new ListItem("Buyer", "1"));
                        ddlFilter2.Items.Add(new ListItem("Style Number", "2"));
                        ddlFilter2.Items.Add(new ListItem("Dept.", "3"));
                        ddlFilter2.Items.Add(new ListItem("Ex-Factory", "4"));
                        ddlFilter2.Items.Add(new ListItem("Status", "5"));
                        ddlFilter2.Items.Add(new ListItem("Order Date", "6"));
                        ddlFilter2.Attributes.Add("onchange", "javascript:return SelectFilterOption(this,2)");
                        e.Row.Cells[i + 2].Controls.Add(ddlFilter2);

                        DropDownList ddlFilter3 = new DropDownList();
                        ddlFilter3.EnableViewState = true;
                        ddlFilter3.Enabled = true;
                        ddlFilter3.ID = "ddl3_" + DeptId + "_" + DesigId + "_" + i;
                        ddlFilter3.Width = 100;
                        ddlFilter3.Attributes.Add("class", "ddl" + DeptId + DesigId);
                        ddlFilter3.Items.Add(new ListItem("Slect All", "-1"));
                        ddlFilter3.Items.Add(new ListItem("Buyer", "1"));
                        ddlFilter3.Items.Add(new ListItem("Style Number", "2"));
                        ddlFilter3.Items.Add(new ListItem("Dept.", "3"));
                        ddlFilter3.Items.Add(new ListItem("Ex-Factory", "4"));
                        ddlFilter3.Items.Add(new ListItem("Status", "5"));
                        ddlFilter3.Items.Add(new ListItem("Order Date", "6"));
                        ddlFilter3.Attributes.Add("onchange", "javascript:return SelectFilterOption(this,3)");
                        e.Row.Cells[i + 2].Controls.Add(ddlFilter3);

                        DropDownList ddlFilter4 = new DropDownList();
                        ddlFilter4.EnableViewState = true;
                        ddlFilter4.Enabled = true;
                        ddlFilter4.ID = "ddl4_" + DeptId + "_" + DesigId + "_" + i;
                        ddlFilter4.Width = 100;
                        ddlFilter4.Attributes.Add("class", "ddl" + DeptId + DesigId);
                        ddlFilter4.Items.Add(new ListItem("Slect All", "-1"));
                        ddlFilter4.Items.Add(new ListItem("Buyer", "1"));
                        ddlFilter4.Items.Add(new ListItem("Style Number", "2"));
                        ddlFilter4.Items.Add(new ListItem("Dept.", "3"));
                        ddlFilter4.Items.Add(new ListItem("Ex-Factory", "4"));
                        ddlFilter4.Items.Add(new ListItem("Status", "5"));
                        ddlFilter4.Items.Add(new ListItem("Order Date", "6"));
                        ddlFilter4.Attributes.Add("onchange", "javascript:return SelectFilterOption(this,4)");
                        e.Row.Cells[i + 2].Controls.Add(ddlFilter4);

                        DropDownList ddlFilter5 = new DropDownList();
                        ddlFilter5.EnableViewState = true;
                        ddlFilter5.Enabled = true;
                        ddlFilter5.ID = "ddl5_" + DeptId + "_" + DesigId + "_" + i;
                        ddlFilter5.Width = 100;
                        ddlFilter5.Attributes.Add("class", "ddl" + DeptId + DesigId);
                        ddlFilter5.Items.Add(new ListItem("Slect All", "-1"));
                        ddlFilter5.Items.Add(new ListItem("Buyer", "1"));
                        ddlFilter5.Items.Add(new ListItem("Style Number", "2"));
                        ddlFilter5.Items.Add(new ListItem("Dept.", "3"));
                        ddlFilter5.Items.Add(new ListItem("Ex-Factory", "4"));
                        ddlFilter5.Items.Add(new ListItem("Status", "5"));
                        ddlFilter5.Items.Add(new ListItem("Order Date", "6"));
                        ddlFilter5.Attributes.Add("onchange", "javascript:return SelectFilterOption(this,5)");
                        e.Row.Cells[i + 2].Controls.Add(ddlFilter5);

                        DropDownList ddlFilter6 = new DropDownList();
                        ddlFilter6.EnableViewState = true;
                        ddlFilter6.Enabled = true;
                        ddlFilter6.ID = "ddl6_" + DeptId + "_" + DesigId + "_" + i;
                        ddlFilter6.Width = 100;
                        ddlFilter6.Attributes.Add("class", "ddl" + DeptId + DesigId);
                        ddlFilter6.Items.Add(new ListItem("Slect All", "-1"));
                        ddlFilter6.Items.Add(new ListItem("BuyerOrderBY", "1"));
                        ddlFilter6.Items.Add(new ListItem("StyleOrderBY", "2"));
                        ddlFilter6.Items.Add(new ListItem("DeptOrderBY", "3"));
                        ddlFilter6.Items.Add(new ListItem("Ex-FactoryOrderBY", "4"));
                        ddlFilter6.Items.Add(new ListItem("StatusOrderBY", "5"));
                        ddlFilter6.Items.Add(new ListItem("Order Date", "6"));
                        ddlFilter6.Attributes.Add("onchange", "javascript:return SelectFilterOption(this,6)");
                        e.Row.Cells[i + 2].Controls.Add(ddlFilter6);


                        DropDownList ddlF1 = (DropDownList)e.Row.FindControl("ddl1_" + DeptId + "_" + DesigId + "_" + i);
                        DropDownList ddlF2 = (DropDownList)e.Row.FindControl("ddl2_" + DeptId + "_" + DesigId + "_" + i);
                        DropDownList ddlF3 = (DropDownList)e.Row.FindControl("ddl3_" + DeptId + "_" + DesigId + "_" + i);
                        DropDownList ddlF4 = (DropDownList)e.Row.FindControl("ddl4_" + DeptId + "_" + DesigId + "_" + i);
                        DropDownList ddlF5 = (DropDownList)e.Row.FindControl("ddl5_" + DeptId + "_" + DesigId + "_" + i);
                        DropDownList ddlF6 = (DropDownList)e.Row.FindControl("ddl6_" + DeptId + "_" + DesigId + "_" + i);
                        if (dtFilter.Rows.Count > 0)
                        {
                            int Buyer = Convert.ToInt32(dtFilter.Rows[0]["BuyerOrderBy"]);
                            ddlF1.SelectedValue = Buyer.ToString();
                            int Style = Convert.ToInt32(dtFilter.Rows[0]["StyleOrderBy"]);
                            ddlF2.SelectedValue = Style.ToString();
                            int Deptartment = Convert.ToInt32(dtFilter.Rows[0]["DeptOrderBy"]);
                            ddlF3.SelectedValue = Deptartment.ToString();
                            int ExFactory = Convert.ToInt32(dtFilter.Rows[0]["ExfactoryOrderBy"]);
                            ddlF4.SelectedValue = ExFactory.ToString();
                            int Status = Convert.ToInt32(dtFilter.Rows[0]["StatusOrderBy"]);
                            ddlF5.SelectedValue = Status.ToString();
                            int OrderDate = Convert.ToInt32(dtFilter.Rows[0]["OrderDateOrderBy"]);
                            ddlF6.SelectedValue = OrderDate.ToString();
                        }
                        if (Read.Checked != false)
                        {
                            ddlF1.Enabled = false;
                            ddlF2.Enabled = false;
                            ddlF3.Enabled = false;
                            ddlF4.Enabled = false;
                            ddlF5.Enabled = false;
                            ddlF6.Enabled = false;
                        }
                        else
                        {
                            ddlF1.Enabled = true;
                            ddlF2.Enabled = true;
                            ddlF3.Enabled = true;
                            ddlF4.Enabled = true;
                            ddlF5.Enabled = true;
                            ddlF6.Enabled = true;
                        }
                    }
                    //

                }
            }


           // grdPermission.Columns[0].Visible = false;
           // grdPermission.Columns[1].Visible = false;

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
            GridViewRow HeaderGridRow = new GridViewRow(1, 2, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = GetHeaerCell();
            HeaderCell.Text = "Section";
            HeaderCell.Width = 150;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = GetHeaerCell();
            HeaderCell.Text = "Field";
            HeaderCell.Width = 250;
            HeaderGridRow.Cells.Add(HeaderCell);

            foreach (DataRow DR in dtDesignCount.Rows)
            {
                HeaderCell = GetHeaerCell();
                HeaderCell.Text = DR["DepartmentName"].ToString();
                HeaderCell.ColumnSpan = Convert.ToInt32(DR["DesignCount"].ToString());
                HeaderCell.Width = 100 * Convert.ToInt32(DR["DesignCount"]) + Convert.ToInt32(DR["DesignCount"]) - 1;
                HeaderGridRow.Cells.Add(HeaderCell);
            }

            #region Gajendra
            //int count=0;
            //HeaderCell.Text = "Section";
            //HeaderCell.ColumnSpan = 0;
            //HeaderGridRow.Cells.Add(HeaderCell);

            //HeaderCell = GetHeaerCell();
            //HeaderCell.Text = "Field";
            //HeaderCell.ColumnSpan = 0;
            //HeaderGridRow.Cells.Add(HeaderCell);

            //HeaderCell = GetHeaerCell();
            //HeaderCell.Text = "Design";
            //int ColCount1 = Convert.ToInt32(obj_Permission.GetMoDeptcount(1));
            ////count = Convert.ToInt32(obj_Permission.GetMoSection(1));
            ////ViewState["count"]= count;
            ////LinkButton lnkPuls = new LinkButton();
            ////lnkPuls.EnableViewState = true;
            ////lnkPuls.Enabled = true;
            ////lnkPuls.ID = "chkW_" + 11 + "_" + 12;
            ////lnkPuls.Text = "Design"+" "+ "+";
            ////HeaderCell.Controls.Add(lnkPuls);
            ////
            //HeaderCell.ColumnSpan = ColCount1;
            //HeaderCell.Width = 150;
            //HeaderGridRow.Cells.Add(HeaderCell);

            //HeaderCell = GetHeaerCell();
            //HeaderCell.Text = "Sales ikandi";
            //int ColCount2 = Convert.ToInt32(obj_Permission.GetMoDeptcount(2));
            //HeaderCell.ColumnSpan = ColCount2;
            //HeaderGridRow.Cells.Add(HeaderCell);

            //HeaderCell = GetHeaerCell();
            //HeaderCell.Text = "Technical iKandi";
            //int ColCount3 = Convert.ToInt32(obj_Permission.GetMoDeptcount(3));
            //HeaderCell.ColumnSpan = ColCount3;
            //HeaderGridRow.Cells.Add(HeaderCell);

            //HeaderCell = GetHeaerCell();
            //HeaderCell.Text = "Finance/Logistics";
            //int ColCount4 = Convert.ToInt32(obj_Permission.GetMoDeptcount(4));
            //HeaderCell.ColumnSpan = ColCount4;
            //HeaderGridRow.Cells.Add(HeaderCell);

            //HeaderCell = GetHeaerCell();
            //HeaderCell.Text = "Top Management BIPL";
            //int ColCount5 = Convert.ToInt32(obj_Permission.GetMoDeptcount(5));
            //HeaderCell.ColumnSpan = ColCount5;
            //HeaderGridRow.Cells.Add(HeaderCell);

            //HeaderCell = GetHeaerCell();
            //HeaderCell.Text = "Merchandising";
            //int ColCount6 = Convert.ToInt32(obj_Permission.GetMoDeptcount(6));
            //HeaderCell.ColumnSpan = ColCount6;
            //HeaderGridRow.Cells.Add(HeaderCell);

            //HeaderCell = GetHeaerCell();
            //HeaderCell.Text = "Fabrics";
            //int ColCount7 = Convert.ToInt32(obj_Permission.GetMoDeptcount(7));
            //HeaderCell.ColumnSpan = ColCount7;
            //HeaderGridRow.Cells.Add(HeaderCell);

            //HeaderCell = GetHeaerCell();
            //HeaderCell.Text = "Accessory";
            //int ColCount8 = Convert.ToInt32(obj_Permission.GetMoDeptcount(8));
            //HeaderCell.ColumnSpan = ColCount8;
            //HeaderGridRow.Cells.Add(HeaderCell);

            //HeaderCell = GetHeaerCell();
            //HeaderCell.Text = "QA";
            //int ColCount9 = Convert.ToInt32(obj_Permission.GetMoDeptcount(9));
            //HeaderCell.ColumnSpan = ColCount9;
            //HeaderGridRow.Cells.Add(HeaderCell);

            //HeaderCell = GetHeaerCell();
            //HeaderCell.Text = "Production";
            //int ColCount10 = Convert.ToInt32(obj_Permission.GetMoDeptcount(10));
            //HeaderCell.ColumnSpan = ColCount10;
            //HeaderGridRow.Cells.Add(HeaderCell);

            //HeaderCell = GetHeaerCell();
            //HeaderCell.Text = "Logistics";
            //int ColCount11 = Convert.ToInt32(obj_Permission.GetMoDeptcount(11));
            //count = Convert.ToInt32(obj_Permission.GetMoDeptcount(11));
            //ViewState["count"] = count;
            //HeaderCell.ColumnSpan = ColCount11;
            //HeaderGridRow.Cells.Add(HeaderCell);

            //HeaderCell = GetHeaerCell();
            //HeaderCell.Text = "TopManagement Ikandi";
            //int ColCount12 = Convert.ToInt32(obj_Permission.GetMoDeptcount(12));
            //HeaderCell.ColumnSpan = ColCount12;
            //HeaderGridRow.Cells.Add(HeaderCell);

            //HeaderCell = GetHeaerCell();
            //HeaderCell.Text = "Technical BIPL";
            //int ColCount13 = Convert.ToInt32(obj_Permission.GetMoDeptcount(15));
            //HeaderCell.ColumnSpan = ColCount13;
            //HeaderGridRow.Cells.Add(HeaderCell);


            //HeaderCell = GetHeaerCell();
            //HeaderCell.Text = "Client";
            //HeaderCell.ColumnSpan = 2;
            //HeaderGridRow.Cells.Add(HeaderCell);
            #endregion

            HeaderGrid.Controls[0].Controls.AddAt(0, HeaderGridRow);

        }

        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType != DataControlRowType.DataRow)
        //        return;
        //    string colName = string.Empty;
        //    string DesignationId = string.Empty;
        //    int DeptId = 0;
        //    int DesigId = 0;
        //    dtgrd1  = DS.Tables[1];
        //    if (dt.Rows.Count > 0)
        //    {

        //        for (int i = 0; i < dtgrd1.Rows.Count; i++)
        //        {
        //            //colName = dt.Rows[i]["Name"].ToString();
        //            DesignationId = dt.Rows[i]["DesignationId"].ToString();
        //            DeptId = Convert.ToInt32(dt.Rows[i]["DeptId"].ToString());
        //            DesigId = Convert.ToInt32(dt.Rows[i]["DesignationId"].ToString());
        //            //GridView1.HeaderRow.Cells[i + 2].Text = colName;

        //            HiddenField hdnMOSectionID = (HiddenField)e.Row.FindControl("hdnMOSectionID");
        //            HiddenField hdnMOCoulmeID = (HiddenField)e.Row.FindControl("hdnMOCoulmeID");
        //            //dsPermission = obj_Permission.GetAllPermissionListById(DeptId, DesigId, Convert.ToInt32(hdnMOSectionID.Value), Convert.ToInt32(hdnMOCoulmeID.Value));

        //            ////For Bind Designation Header
        //            //Label lblName = new Label();
        //            //lblName.EnableViewState = true;
        //            //lblName.Enabled = true;
        //            //lblName.ID = "lal" + i;
        //            // //lblName.Text = colName;
        //            //lblName.Width = 16;
        //            //GridView1.HeaderRow.Style.Add("height", "50px");
        //            //GridView1.HeaderRow.Style.Add("width", "250px");
        //            //GridView1.HeaderRow.Style.Add("text-align", "center");
        //            //GridView1.HeaderRow.Cells[i + 2].Controls.Add(lblName);

        //            //TextBox chkRead1 = new TextBox();
        //            //chkRead1.EnableViewState = true;
        //            //chkRead1.Enabled = true;
        //            //chkRead1.ID = "chkR" + DeptId + "_" + DesigId + "_" + i;
        //            //chkRead1.Text = "";
        //            //chkRead1.Attributes.Add("class", "R" + DeptId + DesigId);
        //            //e.Row.Cells[i + 2].Controls.Add(chkRead1);


        //            dsPermission = obj_Permission.GetAllPermissionListById(DeptId, DesigId, Convert.ToInt32(hdnMOSectionID.Value), Convert.ToInt32(hdnMOCoulmeID.Value));
        //            dtFilter = obj_Permission.GetFilterPermissionById(DeptId, DesigId);
        //            //For Bind Designation Header

        //            Label lblName = new Label();
        //            lblName.EnableViewState = true;
        //            lblName.Enabled = true;
        //            lblName.ID = "lal" + i;
        //            //lblName.Text = colName;
        //            lblName.Width = 16;
        //            GridView1.HeaderRow.Style.Add("height", "10px");
        //            GridView1.HeaderRow.Style.Add("width", "150px");
        //            GridView1.HeaderRow.Style.Add("text-align", "center");
        //            GridView1.HeaderRow.Cells[i + 2].Controls.Add(lblName);

        //            //
        //            //For Bind Common Checkbox

        //            TextBox txtBlanck = new TextBox();
        //            txtBlanck.EnableViewState = true;
        //            txtBlanck.Enabled = true;
        //            txtBlanck.Enabled = false;
        //            txtBlanck.ID = "chkBlanck" + DeptId + "_" + DesigId + "_" + i;
        //            txtBlanck.Width = 20;
        //            txtBlanck.Height = 16;
        //            txtBlanck.Attributes.Add("class", "hasborder");
        //            e.Row.Cells[i + 2].Controls.Add(txtBlanck);

        //            //
        //            //For Buying House
        //            if (hdnMOSectionID.Value == "-1" && hdnMOCoulmeID.Value == "110")
        //            {
        //                //DropDownList ddlGroupBy = new DropDownList();
        //                //ddlGroupBy.EnableViewState = true;
        //                //ddlGroupBy.Enabled = true;
        //                //ddlGroupBy.ID = "ddlBlanckGroupBy_" + DeptId + "_" + DesigId + "_" + i;
        //                //ddlGroupBy.Width = 20;
        //                //ddlGroupBy.Enabled = false;
        //                //ddlGroupBy.Items.Add(new ListItem("", "-1"));
        //                //ddlGroupBy.Items.Add(new ListItem("Ex-Factory", "1"));
        //                //ddlGroupBy.Items.Add(new ListItem("D C", "2"));
        //                //ddlGroupBy.Items.Add(new ListItem("Order Date", "3"));
        //                //e.Row.Cells[i + 2].Controls.Add(ddlGroupBy);

        //                TextBox txtGroupBy = new TextBox();
        //                txtGroupBy.EnableViewState = true;
        //                txtGroupBy.Enabled = true;
        //                txtGroupBy.ID = "txtGroupBy_" + DeptId + "_" + DesigId + "_" + i;
        //                txtGroupBy.Width = 20;
        //                txtGroupBy.Height = 13;
        //                txtGroupBy.Attributes.Add("class", "hasborder");
        //                //ddlGroupBy.Enabled = false;
        //                e.Row.Cells[i + 2].Controls.Add(txtGroupBy);
        //            }
        //            //
        //            //For Buying House
        //            if (hdnMOSectionID.Value == "-1" && hdnMOCoulmeID.Value == "111")
        //            {
        //                //DropDownList ddlBuyingHouse = new DropDownList();
        //                //ddlBuyingHouse.EnableViewState = true;
        //                //ddlBuyingHouse.Enabled = true;
        //                //ddlBuyingHouse.ID = "ddlBlanckBuyingHouse_" + DeptId + "_" + DesigId + "_" + i;
        //                //ddlBuyingHouse.Width = 20;
        //                //ddlBuyingHouse.Enabled = false;
        //                //e.Row.Cells[i + 2].Controls.Add(ddlBuyingHouse);
        //                TextBox txtBuyingHouse = new TextBox();
        //                txtBuyingHouse.EnableViewState = true;
        //                txtBuyingHouse.Enabled = true;
        //                txtBuyingHouse.ID = "txtBuyingHouse_" + DeptId + "_" + DesigId + "_" + i;
        //                txtBuyingHouse.Width = 20;
        //                txtBuyingHouse.Height = 13;
        //                txtBuyingHouse.Attributes.Add("class", "hasborder");
        //                //ddlGroupBy.Enabled = false;
        //                e.Row.Cells[i + 2].Controls.Add(txtBuyingHouse);
        //            }
        //            //
        //            //For Status From
        //            if (hdnMOSectionID.Value == "-1" && hdnMOCoulmeID.Value == "112")
        //            {
        //                //DropDownList ddlStatusFrm = new DropDownList();
        //                //ddlStatusFrm.EnableViewState = true;
        //                //ddlStatusFrm.Enabled = true;
        //                //ddlStatusFrm.ID = "ddlBlanckStatusFrom_" + DeptId + "_" + DesigId + "_" + i;
        //                //ddlStatusFrm.Width = 20;
        //                //ddlStatusFrm.Enabled = false;
        //                //ddlStatusFrm.Items.Add(new ListItem("", "0"));
        //                //e.Row.Cells[i + 2].Controls.Add(ddlStatusFrm);

        //                TextBox ddlStatusFrm = new TextBox();
        //                ddlStatusFrm.EnableViewState = true;
        //                ddlStatusFrm.Enabled = true;
        //                ddlStatusFrm.ID = "ddlBlanckStatusFrom_" + DeptId + "_" + DesigId + "_" + i;
        //                ddlStatusFrm.Width = 20;
        //                ddlStatusFrm.Height = 13;
        //                ddlStatusFrm.Enabled = false;
        //                e.Row.Cells[i + 2].Controls.Add(ddlStatusFrm);

        //            }
        //            //For Status To
        //            if (hdnMOSectionID.Value == "-1" && hdnMOCoulmeID.Value == "113")
        //            {
        //                //DropDownList ddlStatusTo = new DropDownList();
        //                //ddlStatusTo.EnableViewState = true;
        //                //ddlStatusTo.Enabled = true;
        //                //ddlStatusTo.ID = "ddlBlanckStatusTo_" + DeptId + "_" + DesigId + "_" + i;
        //                //ddlStatusTo.Width = 20;
        //                //ddlStatusTo.Enabled = false;
        //                //ddlStatusTo.Items.Add(new ListItem("", "0"));
        //                //e.Row.Cells[i + 2].Controls.Add(ddlStatusTo);

        //                TextBox ddlStatusTo = new TextBox();
        //                ddlStatusTo.EnableViewState = true;
        //                ddlStatusTo.Enabled = true;
        //                ddlStatusTo.ID = "ddlBlanckStatusTo_" + DeptId + "_" + DesigId + "_" + i;
        //                ddlStatusTo.Width = 20;
        //                ddlStatusTo.Enabled = false;
        //                ddlStatusTo.Height = 13;
        //                e.Row.Cells[i + 2].Controls.Add(ddlStatusTo);
        //            }
        //            //
        //            //For Filter OrderBy
        //            if (hdnMOSectionID.Value == "-1" && hdnMOCoulmeID.Value == "114")
        //            {

        //                TextBox ddlFilter1 = new TextBox();
        //                ddlFilter1.EnableViewState = true;
        //                ddlFilter1.Enabled = true;
        //                ddlFilter1.ID = "ddlBlanck1_" + DeptId + "_" + DesigId + "_" + i;
        //                ddlFilter1.Width = 20;
        //                ddlFilter1.Height = 93;
        //                ddlFilter1.Enabled = false;
        //                e.Row.Cells[i + 2].Controls.Add(ddlFilter1);

        //                #region Commented
        //                //DropDownList ddlFilter1 = new DropDownList();
        //                //ddlFilter1.EnableViewState = true;
        //                //ddlFilter1.Enabled = true;
        //                //ddlFilter1.ID = "ddlBlanck1_" + DeptId + "_" + DesigId + "_" + i;
        //                //ddlFilter1.Width = 20;
        //                //ddlFilter1.Enabled = false;
        //                //ddlFilter1.Items.Add(new ListItem("", "-1"));
        //                //ddlFilter1.Items.Add(new ListItem("Buyer", "1"));
        //                //ddlFilter1.Items.Add(new ListItem("Style Number", "2"));
        //                //ddlFilter1.Items.Add(new ListItem("Dept.", "3"));
        //                //ddlFilter1.Items.Add(new ListItem("Ex-Factory", "4"));
        //                //ddlFilter1.Items.Add(new ListItem("Status", "5"));
        //                //ddlFilter1.Items.Add(new ListItem("Order Date", "6"));
        //                //e.Row.Cells[i + 2].Controls.Add(ddlFilter1);

        //                //DropDownList ddlFilter2 = new DropDownList();
        //                //ddlFilter2.EnableViewState = true;
        //                //ddlFilter2.Enabled = true;
        //                //ddlFilter2.ID = "ddlBlanck2_" + DeptId + "_" + DesigId + "_" + i;
        //                //ddlFilter2.Attributes.Add("class", "ddl" + DeptId + DesigId);
        //                //ddlFilter2.Width = 20;
        //                //ddlFilter2.Enabled = false;
        //                //ddlFilter2.Items.Add(new ListItem("", "-1"));
        //                //ddlFilter2.Items.Add(new ListItem("Buyer", "1"));
        //                //ddlFilter2.Items.Add(new ListItem("Style Number", "2"));
        //                //ddlFilter2.Items.Add(new ListItem("Dept.", "3"));
        //                //ddlFilter2.Items.Add(new ListItem("Ex-Factory", "4"));
        //                //ddlFilter2.Items.Add(new ListItem("Status", "5"));
        //                //ddlFilter2.Items.Add(new ListItem("Order Date", "6"));
        //                //e.Row.Cells[i + 2].Controls.Add(ddlFilter2);

        //                //DropDownList ddlFilter3 = new DropDownList();
        //                //ddlFilter3.EnableViewState = true;
        //                //ddlFilter3.Enabled = true;
        //                //ddlFilter3.ID = "ddlBlanck3_" + DeptId + "_" + DesigId + "_" + i;
        //                //ddlFilter3.Width = 20;
        //                //ddlFilter3.Enabled = false;
        //                //ddlFilter3.Items.Add(new ListItem("", "-1"));
        //                //ddlFilter3.Items.Add(new ListItem("Buyer", "1"));
        //                //ddlFilter3.Items.Add(new ListItem("Style Number", "2"));
        //                //ddlFilter3.Items.Add(new ListItem("Dept.", "3"));
        //                //ddlFilter3.Items.Add(new ListItem("Ex-Factory", "4"));
        //                //ddlFilter3.Items.Add(new ListItem("Status", "5"));
        //                //ddlFilter3.Items.Add(new ListItem("Order Date", "6"));
        //                //e.Row.Cells[i + 2].Controls.Add(ddlFilter3);

        //                //DropDownList ddlFilter4 = new DropDownList();
        //                //ddlFilter4.EnableViewState = true;
        //                //ddlFilter4.Enabled = true;
        //                //ddlFilter4.ID = "ddlBlanck4_" + DeptId + "_" + DesigId + "_" + i;
        //                //ddlFilter4.Width = 20;
        //                //ddlFilter4.Enabled = false;
        //                //ddlFilter4.Items.Add(new ListItem("", "-1"));
        //                //ddlFilter4.Items.Add(new ListItem("Buyer", "1"));
        //                //ddlFilter4.Items.Add(new ListItem("Style Number", "2"));
        //                //ddlFilter4.Items.Add(new ListItem("Dept.", "3"));
        //                //ddlFilter4.Items.Add(new ListItem("Ex-Factory", "4"));
        //                //ddlFilter4.Items.Add(new ListItem("Status", "5"));
        //                //ddlFilter4.Items.Add(new ListItem("Order Date", "6"));
        //                //e.Row.Cells[i + 2].Controls.Add(ddlFilter4);

        //                //DropDownList ddlFilter5 = new DropDownList();
        //                //ddlFilter5.EnableViewState = true;
        //                //ddlFilter5.Enabled = true;
        //                //ddlFilter5.ID = "ddlBlanck5_" + DeptId + "_" + DesigId + "_" + i;
        //                //ddlFilter5.Width = 20;
        //                //ddlFilter5.Enabled = false;
        //                //ddlFilter5.Items.Add(new ListItem("", "-1"));
        //                //ddlFilter5.Items.Add(new ListItem("Buyer", "1"));
        //                //ddlFilter5.Items.Add(new ListItem("Style Number", "2"));
        //                //ddlFilter5.Items.Add(new ListItem("Dept.", "3"));
        //                //ddlFilter5.Items.Add(new ListItem("Ex-Factory", "4"));
        //                //ddlFilter5.Items.Add(new ListItem("Status", "5"));
        //                //ddlFilter5.Items.Add(new ListItem("Order Date", "6"));
        //                //e.Row.Cells[i + 2].Controls.Add(ddlFilter5);

        //                //DropDownList ddlFilter6 = new DropDownList();
        //                //ddlFilter6.EnableViewState = true;
        //                //ddlFilter6.Enabled = true;
        //                //ddlFilter6.ID = "ddlBlanck6_" + DeptId + "_" + DesigId + "_" + i;
        //                //ddlFilter6.Width = 20;
        //                //ddlFilter6.Enabled = false;
        //                //ddlFilter6.Items.Add(new ListItem("", "-1"));
        //                //ddlFilter6.Items.Add(new ListItem("BuyerOrderBY", "1"));
        //                //ddlFilter6.Items.Add(new ListItem("StyleOrderBY", "2"));
        //                //ddlFilter6.Items.Add(new ListItem("DeptOrderBY", "3"));
        //                //ddlFilter6.Items.Add(new ListItem("Ex-FactoryOrderBY", "4"));
        //                //ddlFilter6.Items.Add(new ListItem("StatusOrderBY", "5"));
        //                //ddlFilter6.Items.Add(new ListItem("Order Date", "6"));
        //                //e.Row.Cells[i + 2].Controls.Add(ddlFilter6);
        //                #endregion
        //            }

        //        }
        //    }

        //}

        //protected void GridView1_RowCreated1(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType != DataControlRowType.Header)
        //        return;

        //    GridView HeaderGrid = (GridView)sender;
        //    GridViewRow HeaderGridRow = new GridViewRow(1, 1, DataControlRowType.Header, DataControlRowState.Insert);

        //    TableCell HeaderCell = GetHeaerCell();
        //    HeaderCell.Text = "Section";
        //    HeaderCell.ColumnSpan = 0;
        //    HeaderGridRow.Cells.Add(HeaderCell);

        //    HeaderCell = GetHeaerCell();
        //    HeaderCell.Text = "Field";
        //    HeaderCell.ColumnSpan = 0;
        //    HeaderGridRow.Cells.Add(HeaderCell);

        //    HeaderCell = GetHeaerCell();
        //    HeaderCell.Text = "";
        //    HeaderCell.ColumnSpan = 0;
        //    HeaderGridRow.Cells.Add(HeaderCell);

        //    HeaderGrid.Controls[0].Controls.AddAt(0, HeaderGridRow);
        //    HeaderGridRow = new GridViewRow(1, 2, DataControlRowType.Header, DataControlRowState.Insert);
        //    HeaderGrid.Controls[0].Controls.AddAt(1, HeaderGridRow);
        //}
    }
}
