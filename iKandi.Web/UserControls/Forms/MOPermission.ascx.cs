using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using iKandi.Web.Components;
using System.Data;
using iKandi.BLL;
using iKandi.Common;

using System.Data.SqlClient;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Collections;

namespace iKandi.Web.UserControls.Forms
{
    public partial class MOPermission : System.Web.UI.UserControl
    {
        PermissionController obj_Permission = new PermissionController();
        List<MOPermissionForm> PermissionList = new List<MOPermissionForm>();
        MOPermissionForm Permission = new MOPermissionForm();

        private int DesignationID
        {
            get
            {
                if (null != Request.QueryString["DesignationID"])
                {
                    // string str = Convert.ToString(Session.SessionID);
                    int DesignationID;

                    if (int.TryParse(Request.QueryString["DesignationID"].ToString(), out DesignationID))
                        return DesignationID;
                }

                return -1;
            }
        }


        private int DepartmentId
        {
            get
            {
                if (null != Request.QueryString["DepartmentId"])
                {
                    // string str = Convert.ToString(Session.SessionID);
                    int DepartmentId;

                    if (int.TryParse(Request.QueryString["DepartmentId"].ToString(), out DepartmentId))
                        return DepartmentId;
                }

                return -1;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDept();

                if (DesignationID != -1)
                {
                    BindControl(DesignationID, DepartmentId);
                }
            }
        }

        protected void BindDept()
        {
            DataTable dtDept = new DataTable();
            dtDept = obj_Permission.GetDepartmentList();
            ddlDept.DataSource = dtDept;
            ddlDept.DataTextField = "Name";
            ddlDept.DataValueField = "Id";
            ddlDept.DataBind();

            DataTable dtDesig = new DataTable();
            dtDesig = obj_Permission.GetSectionList();
            listSection.DataSource = dtDesig;
            listSection.DataValueField = "MOSectionID";
            listSection.DataTextField = "Description";
            listSection.DataBind();


            chkSection.DataSource = dtDesig;
            chkSection.DataValueField = "MOSectionID";
            chkSection.DataTextField = "Description";
            chkSection.DataBind();

            //DataTable dtPermission = new DataTable();
            //dtPermission = obj_Permission.getPermission();
            //GridView1.DataSource = dtPermission;
            //GridView1.DataBind();



        }

        protected void SavePermission()
        {
            MOPermissionForm MOPermissionList = new MOPermissionForm();
            DataTable dtSection = new DataTable();
            DataTable dtColumn = new DataTable();
            int DepartmentId = 0;
            int DesignationId = 0;
            bool SalesView = false;
            int SectionId = 0;
            int ColumnId = 0;
            bool Read = false;
            bool Write = false;
            string V_list = string.Empty;
            string V_listName = string.Empty;
            var r = "";
            var w = "";
            int Result = 0;
            int desigID = 0;
            var allRead = "";
            var allwrite = "";
            bool ReadWritePermission = false;

            // bool WriteAll = false;
            try
            {
                obj_Permission.DeleteMoPermission(Convert.ToInt32(ddlDesig.SelectedValue), Convert.ToInt32(ddlDept.SelectedValue));

                string[] strVal = hdnval.Value.Split(',');

                for (int i = 0; i < strVal.Length; i++)
                {

                    if (!string.IsNullOrEmpty(Request.Params["checkboxRead_" + strVal[i]]))
                        r = Request.Params["checkboxRead_" + strVal[i]];

                    if (!string.IsNullOrEmpty(Request.Params["checkboxWrit_" + strVal[i]]))
                        w = Request.Params["checkboxWrit_" + strVal[i]];

                    //Added By ashish on 6/3/2014
                    if (!string.IsNullOrEmpty(Request.Params["checkboxReadAll_" + 1]))
                        allRead = Request.Params["checkboxReadAll_" + 1];

                    if (!string.IsNullOrEmpty(Request.Params["checkboxwrite_1"]))
                        allwrite = Request.Params["checkboxwrite_1"];
                    //END
                    if (allRead == "on")
                    {
                        ReadWritePermission = false;
                    }
                    else
                    {
                        ReadWritePermission = true;
                    }
                    //if (r != "" || w != "")
                    //{
                    MOPermissionForm prm_MOPermission = new MOPermissionForm();
                    DepartmentId = Convert.ToInt32(ddlDept.SelectedValue);
                    DesignationId = Convert.ToInt32(ddlDesig.SelectedValue);
                    if (chkSalesView.Checked == true)
                    {
                        SalesView = true;
                    }
                    else
                    {
                        SalesView = false;
                    }


                    prm_MOPermission.SalesView = SalesView;
                    //Sorting = ddlOrders.SelectedItem.Text;

                    //prm_MOPermission.OrderBy1 = Convert.ToInt32(ddlOrder1.SelectedValue);
                    //prm_MOPermission.OrderBy2 = Convert.ToInt32(ddlOrder2.SelectedValue);
                    //prm_MOPermission.OrderBy3 = Convert.ToInt32(ddlOrder3.SelectedValue);
                    //prm_MOPermission.OrderBy4 = Convert.ToInt32(ddlOrder4.SelectedValue);
                    //prm_MOPermission.OrderBy5 = Convert.ToInt32(ddlOrder5.SelectedValue);
                    //prm_MOPermission.OrderBy6 = Convert.ToInt32(ddlOrder6.SelectedValue);
                    prm_MOPermission.DepartmentId = DepartmentId;
                    prm_MOPermission.DesignationId = DesignationId;

                    if (r == "on" || r == "on,on")
                    {
                        Read = true;
                    }
                    else
                    {
                        Read = false;
                    }
                    if (w == "on" || w == "on,on")
                    {

                        Write = true;
                    }
                    else
                    {

                        Write = false;
                    }

                    if (!string.IsNullOrEmpty(Request.Params["hdnSectionColumn_" + strVal[i]]))
                        V_listName = Request.Params["hdnSectionColumn_" + strVal[i]];
                    string[] ColumnName = V_listName.Split('(');
                    string[] columnName1 = ColumnName[1].Split(')');
                    dtSection = obj_Permission.GetSectionIdBySection(columnName1[0]);
                    if (dtSection.Rows.Count > 0)
                    {
                        SectionId = Convert.ToInt32(dtSection.Rows[0]["MOSectionID"].ToString());
                    }
                    else
                    {
                        SectionId = 0;
                    }
                    dtColumn = obj_Permission.GetColumnIdByColumn(ColumnName[0]);
                    if (dtColumn.Rows.Count > 0)
                    {
                        ColumnId = Convert.ToInt32(dtColumn.Rows[0]["MOCoulmeID"].ToString());
                    }
                    else
                    {
                        ColumnId = 0;
                    }
                    prm_MOPermission.SectionId = SectionId;
                    prm_MOPermission.ColumnId = ColumnId;
                    prm_MOPermission.Read = Read;
                    prm_MOPermission.Write = Write;
                    desigID = DesignationId;
                    prm_MOPermission.AllReadWritePermission = ReadWritePermission;
                    Result = obj_Permission.InsertMOpermission(prm_MOPermission);
                    r = "";
                    w = "";
                }



                //}
                if (Result > 0)
                {
                    Response.Redirect("~/Admin/Permission/MOPermissionList.aspx");

                }
                else
                {
                    Alert("Permission Not Save");
                }
                //obj_Permission.InsertMOpermissionSet(MOPermissionList, desigID);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }


        public void Alert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);

        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            SavePermission();
        }

        protected void listSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtuser = new DataTable();
            DataTable dsNewUser = new DataTable();
            int DesigId = 0;
            int countId = 0;
            DataTable dtmarge = new DataTable();
            int SelectCount = 1;
            try
            {
                foreach (ListItem item in listSection.Items)
                {

                    if (item.Selected)
                    {

                        if (SelectCount == 1)
                        {
                            ViewState["User"] = null;
                        }
                        SelectCount = SelectCount + 1;
                        //Convert.ToInt32(listSection.SelectedItem.Value);
                        DesigId = Convert.ToInt32(item.Value);
                        dtuser = obj_Permission.GetColumnBySectionId(DesigId);
                        countId = dtuser.Rows.Count;

                        if (ViewState["User"] != null)
                        {
                            dtmarge = (DataTable)(ViewState["User"]);
                            dtmarge = (DataTable)(ViewState["User"]);
                            dtmarge.Merge(dtuser);
                            ViewState["User"] = dtmarge;
                        }
                        else
                        {
                            if (ViewState["flagUpdate"] != null)
                            {
                                DataTable dt = new DataTable();
                                dt = (DataTable)(ViewState["dtuser"]);
                                string Name = "";
                                DataTable dt1 = new DataTable();

                                string[] strSummCities = dtuser.AsEnumerable().Select(s => s.Field<string>("Description")).ToArray<string>();
                                for (int i = 0; i < countId; i++)
                                {
                                    Name = dtuser.Rows[i]["Description"].ToString();
                                }
                                if (dt.Columns.Contains("MOCoulmeID"))
                                {
                                    dt.Columns.Remove("MOCoulmeID");
                                }
                                else
                                {
                                    dt.Merge(dtuser);
                                    var groups = dtmarge.AsEnumerable();
                                    var result = groups.GroupBy(a => a.Field<string>("Description")).Select(b => b.First()).CopyToDataTable();
                                    //
                                    listColumn.DataSource = result;
                                    listColumn.DataValueField = "MOCoulmeID";
                                    listColumn.DataTextField = "Description";
                                    listColumn.DataBind();
                                    return;
                                }
                                dt.Merge(dtuser);
                                var groups1 = dtmarge.AsEnumerable();
                                var result1 = groups1.GroupBy(a => a.Field<string>("Description")).Select(b => b.First()).CopyToDataTable();

                                listColumn.DataSource = result1;
                                listColumn.DataValueField = "MOCoulmeID";
                                listColumn.DataTextField = "Description";
                                listColumn.DataBind();
                                return;
                            }
                            else
                            {
                                ViewState["User"] = dtuser;
                                dtmarge = dtuser;
                            }
                        }
                    }
                }


                if (dtmarge.Rows.Count > 0)
                {
                    var groups2 = dtmarge.AsEnumerable();
                    var result2 = groups2.GroupBy(a => a.Field<string>("Description")).Select(b => b.First()).CopyToDataTable();

                    listColumn.DataSource = result2;
                    listColumn.DataValueField = "MOCoulmeID";
                    listColumn.DataTextField = "Description";
                    listColumn.DataBind();
                    hdnval.Value = "";
                    hdntxt.Value = "";

                    for (int i = 0; i < result2.Rows.Count; i++)
                    {

                        if (hdnval.Value == "")
                        {
                            hdnval.Value = result2.Rows[i]["MOCoulmeID"].ToString();
                            hdntxt.Value = result2.Rows[i]["Description"].ToString();
                            //hdnval.Value = i.ToString();
                        }
                        else
                        {
                            hdnval.Value += (hdnval.Value == string.Empty) ? result2.Rows[i]["MOCoulmeID"].ToString() : "," + result2.Rows[i]["MOCoulmeID"].ToString();
                            hdntxt.Value += (hdnval.Value == string.Empty) ? result2.Rows[i]["Description"].ToString() : "," + result2.Rows[i]["Description"].ToString();
                        }
                    }


                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript",
                                                                "$(function(){BindCheckBox(" + DesigId + ");supplierId=" +
                                                                DesigId + "});", true);
                }
            }
            catch (Exception ex)
            {
                string strMsg = ex.Message;
            }

        }
        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            int DeptId = Convert.ToInt32(ddlDept.SelectedValue);

            DataTable dtDesig = new DataTable();
            dtDesig = obj_Permission.GetDesignationByDepartId(DeptId);
            ddlDesig.DataSource = dtDesig;
            ddlDesig.DataTextField = "Name";
            ddlDesig.DataValueField = "Id";
            ddlDesig.DataBind();


        }

        protected void chkSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable dtuser = new DataTable();
            //DataTable dsNewUser = new DataTable();
            //int DesigId = 0;

            //int countId = 0;
            //DataTable dtmarge = new DataTable();


            //foreach (ListItem item in chkSection.Items)
            //{

            //    if (item.Selected)
            //    {
            //        //Convert.ToInt32(listSection.SelectedItem.Value);
            //        DesigId = Convert.ToInt32(item.Value);
            //        dtuser = obj_Permission.GetColumnBySectionId(DesigId);
            //        countId = dtuser.Rows.Count;

            //        if (ViewState["User"] != null)
            //        {
            //            dtmarge = (DataTable)(ViewState["User"]);
            //            dtmarge = (DataTable)(ViewState["User"]);
            //            dtmarge.Merge(dtuser);
            //            ViewState["User"] = dtmarge;
            //        }
            //        else
            //        {
            //            if (ViewState["flagUpdate"] != null)
            //            {
            //                DataTable dt = new DataTable();
            //                dt = (DataTable)(ViewState["dtuser"]);
            //                string Name = "";
            //                DataTable dt1 = new DataTable();

            //                string[] strSummCities = dtuser.AsEnumerable().Select(s => s.Field<string>("Description")).ToArray<string>();
            //                for (int i = 0; i < countId; i++)
            //                {
            //                    Name = dtuser.Rows[i]["Description"].ToString();
            //                }
            //                if (dt.Columns.Contains("MOCoulmeID"))
            //                {
            //                    dt.Columns.Remove("MOCoulmeID");
            //                }
            //                else
            //                {
            //                    dt.Merge(dtuser);
            //                    var groups = dtmarge.AsEnumerable();
            //                    var result = groups.GroupBy(a => a.Field<string>("Description")).Select(b => b.First()).CopyToDataTable();
            //                    //
            //                    listColumn.DataSource = result;
            //                    listColumn.DataValueField = "MOCoulmeID";
            //                    listColumn.DataTextField = "Description";
            //                    listColumn.DataBind();
            //                    return;
            //                }
            //                dt.Merge(dtuser);
            //                var groups1 = dtmarge.AsEnumerable();
            //                var result1 = groups1.GroupBy(a => a.Field<string>("Description")).Select(b => b.First()).CopyToDataTable();

            //                listColumn.DataSource = result1;
            //                listColumn.DataValueField = "MOCoulmeID";
            //                listColumn.DataTextField = "Description";
            //                listColumn.DataBind();
            //                return;
            //            }
            //            else
            //            {
            //                ViewState["User"] = dtuser;
            //                dtmarge = dtuser;
            //            }
            //        }
            //    }
            //}


            //if (dtmarge.Rows.Count > 0)
            //{
            //    var groups2 = dtmarge.AsEnumerable();
            //    var result2 = groups2.GroupBy(a => a.Field<string>("Description")).Select(b => b.First()).CopyToDataTable();

            //    listColumn.DataSource = result2;
            //    listColumn.DataValueField = "MOCoulmeID";
            //    listColumn.DataTextField = "Description";
            //    listColumn.DataBind();
            //    hdnval.Value = "";
            //    hdntxt.Value = "";

            //    for (int i = 0; i < result2.Rows.Count; i++)
            //    {

            //        if (hdnval.Value == "")
            //        {
            //            hdnval.Value = result2.Rows[i]["MOCoulmeID"].ToString();
            //            hdntxt.Value = result2.Rows[i]["Description"].ToString();
            //            //hdnval.Value = i.ToString();
            //        }
            //        else
            //        {
            //            hdnval.Value += (hdnval.Value == string.Empty) ? result2.Rows[i]["MOCoulmeID"].ToString() : "," + result2.Rows[i]["MOCoulmeID"].ToString();
            //            hdntxt.Value += (hdnval.Value == string.Empty) ? result2.Rows[i]["Description"].ToString() : "," + result2.Rows[i]["Description"].ToString();
            //        }
            //    }


            //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript",
            //                                                "$(function(){createCheckBox(" + DesigId + ");supplierId=" +
            //                                                DesigId + "});", true);
            //}
        }


        protected void BindControl(int DesigId, int DeptId)
        {
            DataTable dtDesig = new DataTable();
            PermissionList = obj_Permission.GetMoPermissionList(DesigId, DeptId);
            hdnDesig.Value = DesigId.ToString();
            hdnDept.Value = DeptId.ToString();
            BindDept();
            int DepId = 0;
            int desigId = 0;

            foreach (var sec in PermissionList)
            {
                if (listSection.Items.FindByValue(sec.Section.ToString()) != null)
                    listSection.Items.FindByValue(sec.Section.ToString()).Selected = true;
            }

            //ddlOrders.Items.Insert(0, new ListItem("Select....", "-1"));
            foreach (var item in PermissionList)
            {
                ddlDept.SelectedValue = item.DepartmentId.ToString();
                ddlOrder1.SelectedValue = item.OrderBy1.ToString();
                ddlOrder2.SelectedValue = item.OrderBy2.ToString();
                ddlOrder3.SelectedValue = item.OrderBy3.ToString();
                ddlOrder4.SelectedValue = item.OrderBy4.ToString();
                ddlOrder5.SelectedValue = item.OrderBy5.ToString();
                ddlOrder6.SelectedValue = item.OrderBy6.ToString();

                chkSalesView.Checked = item.SalesView;


                DepId = Convert.ToInt32(item.DepartmentId);
                desigId = Convert.ToInt32(item.DesignationId);

                if (item.AllReadWritePermission == true)
                {
                    hdnReadWritePermission.Value = "1";
                }
                else
                {
                    hdnReadWritePermission.Value = "0";
                }

                if (hdnval.Value == "")
                {
                    hdnval.Value = item.Column.ToString();
                    hdntxt.Value = item.ColumnName.ToString();
                    //hdnval.Value = i.ToString();

                }
                else
                {
                    hdnval.Value += (hdnval.Value == string.Empty) ? item.Column.ToString() : "," + item.Column.ToString();
                    hdntxt.Value += (hdnval.Value == string.Empty) ? item.ColumnName.ToString() : "," + item.ColumnName.ToString();
                }
                if (hdnRead.Value == "")
                {
                    hdnRead.Value = item.Read.ToString();
                }
                else
                {
                    hdnRead.Value += (hdnRead.Value == string.Empty) ? item.Read.ToString() : "," + item.Read.ToString();
                }

                if (hdnWrite.Value == "")
                {
                    hdnWrite.Value = item.Write.ToString();

                }
                else
                {
                    hdnWrite.Value += (hdnWrite.Value == string.Empty) ? item.Write.ToString() : "," + item.Write.ToString();
                }
            }
            dtDesig = obj_Permission.GetDesignationByDepartId(DepId);
            ddlDesig.DataSource = dtDesig;
            ddlDesig.DataTextField = "Name";
            ddlDesig.DataValueField = "Id";
            ddlDesig.DataBind();

            ddlDesig.SelectedValue = desigId.ToString();


            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript",
                                                              "$(function(){BindCheckBox(" + 1 + ");supplierId=" +
                                                              1 + "});", true);

        }




        //protected void GridView1_RowUpdating1(object sender, GridViewUpdateEventArgs e)
        //{
        //    GridViewRow Rows = GridView1.Rows[e.RowIndex];
        //    HiddenField hdnCurrancyId = Rows.FindControl("hdnCurrancyId") as HiddenField;
        //    string str = hdnCurrancyId.Value;

        //    ViewState["DepartId"] = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0].ToString());
        //}


    }
}

