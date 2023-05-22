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
using System.Globalization;
using System.Threading;
using System.Drawing;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iKandi.BLL;
using System.Reflection;
using System.Diagnostics;
using System.Text;



namespace iKandi.Web
{
    public partial class CriticalpathReport : System.Web.UI.Page
    {
        DataTable dtexcel = new DataTable();
        OrderController objControler = new OrderController();

        static string[] strarryPerv_m = { "" };
        static string[] strarryCurrent_m = { "" };
        static string[] strarryNext_m = { "" };

        protected void Page_Load(object sender, EventArgs e)
        {

            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            if (!IsPostBack)
            {
                //grdSampleTracker.Enabled = false; //By shubhendu

                rdb_FilterBy.SelectedValue = "0";
                rdb_FilterBy_SampleTracker.SelectedValue = "0";

                if (Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.DesignationID) == 48)
                {
                    div_ParentDeptID.Visible = false;
                    BindClientDepartment();
                    div_ParentDeptIDSt.Visible = false;
                    BindClientDepartmentTracker();
                }
                else
                {
                    div_ParentDeptID.Visible = true;
                    BindDepartment();
                    div_ParentDeptIDSt.Visible = true;
                    BindDepartmentTracker();
                    if (Convert.ToInt32(ddlDeptID.SelectedValue) == -1)
                    {
                        ChkIsAll.Checked = false;
                    }
                    if (Convert.ToInt32(DropDownList1.SelectedValue) == -1)
                    {
                        ChkBoxall1.Checked = false;
                    }
                }
                CheckDefualt(true);
                CheckDefualtTracker(true);

                Bindgrd(ReturnDeptID());
                BindTrackerGrid(ReturnDeptIDTracker());
                BindGrid();
            }
            GetQuaterMonthName();
            if (Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.DesignationID) == 48)
            {
                grdcriticalpath.Columns[9].Visible = false;
                grdcriticalpath.Columns[10].Visible = false;
            }
            else
            {
                grdcriticalpath.Columns[9].Visible = true;
                grdcriticalpath.Columns[10].Visible = true;

            }
        }

        public void GetQuaterMonthName()
        {
            strarryPerv_m[0] = DateTime.Now.AddMonths(-1).ToString("MMMM");
            strarryCurrent_m[0] = DateTime.Now.ToString("MMMM");
            strarryNext_m[0] = DateTime.Now.AddMonths(1).ToString("MMMM");
        }

        //By shubhendu 10/9/2021

        public void BindTrackerGrid(string ClinetDepIds)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataSet dsSampleTrackerUserTracker = new DataSet();
            // int ClientDeptId = Convert.ToInt32(DropDownList1.SelectedValue);
            ds = objControler.GetSampleTrackerDetails(ApplicationHelper.LoggedInUser.UserData.UserID, ClinetDepIds, Convert.ToInt32(rdb_FilterBy_SampleTracker.SelectedValue));
            dsSampleTrackerUserTracker = objControler.GetSampleTrackerWiseUser(ApplicationHelper.LoggedInUser.UserData.UserID, ClinetDepIds);
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                lbldmmST.Text = dsSampleTrackerUserTracker.Tables[0].Rows[0].ItemArray[0].ToString();
                lblaccountmgrST.Text = dsSampleTrackerUserTracker.Tables[1].Rows[0].ItemArray[0].ToString();
                lblfitmerchantST.Text = dsSampleTrackerUserTracker.Tables[2].Rows[0].ItemArray[0].ToString();

                grdSampleTracker.DataSource = dt;
                grdSampleTracker.DataBind();
            }
            else
            {
                lbldmm.Text = "";
                lblaccountmgr.Text = "";
                lblfitmerchant.Text = "";
                grdSampleTracker.DataSource = null;
                grdSampleTracker.DataBind();

            }
            if (Session["TrackerDept"] != null)
            {
                Session["TrackerDept"] = null;
            }
            Session["TrackerDept"] = dt;
        }

        //abhishek 5/1/2016
        public void Bindgrd(string DeptID)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataSet dsDepertmentWiseUser = new DataSet();
            DataTable dtDepertmentWiseUser = new DataTable();

            ds = objControler.GetCriticalPathReportNew(ApplicationHelper.LoggedInUser.UserData.UserID, DeptID, Convert.ToInt32(rdb_FilterBy.SelectedValue));
            dsDepertmentWiseUser = objControler.GetCriticalDepertmentWiseUser(ApplicationHelper.LoggedInUser.UserData.UserID, DeptID);

            dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                lbldmm.Text = dsDepertmentWiseUser.Tables[0].Rows[0].ItemArray[0].ToString();
                lblaccountmgr.Text = dsDepertmentWiseUser.Tables[1].Rows[0].ItemArray[0].ToString();
                lblfitmerchant.Text = dsDepertmentWiseUser.Tables[2].Rows[0].ItemArray[0].ToString();
                grdcriticalpath.DataSource = dt;
                grdcriticalpath.DataBind();
            }
            else
            {
                lbldmm.Text = "";
                lblaccountmgr.Text = "";
                lblfitmerchant.Text = "";
                grdcriticalpath.DataSource = null;
                grdcriticalpath.DataBind();

            }
            //dtexcel = dt;
            if (Session["Dept"] != null)
            {
                Session["Dept"] = null;
            }
            Session["Dept"] = dt;
        }

        public void CheckDefualt(bool check)
        {
            if (check == true)
            {
                foreach (System.Web.UI.WebControls.ListItem item in ChklistClientDep.Items)
                {
                    item.Selected = true;
                    item.Enabled = false;
                }
            }
            else if (check == false)
            {
                foreach (System.Web.UI.WebControls.ListItem item in ChklistClientDep.Items)
                {
                    item.Selected = false;
                    item.Enabled = true;
                }
            }


        }
        //Added by Shubhendu

        public void CheckDefualtTracker(bool check)
        {
            if (check == true)
            {
                foreach (System.Web.UI.WebControls.ListItem item in Chkboxlist1.Items)
                {
                    item.Selected = true;
                    item.Enabled = false;
                }
            }
            else if (check == false)
            {
                foreach (System.Web.UI.WebControls.ListItem item in Chkboxlist1.Items)
                {
                    item.Selected = false;
                    item.Enabled = true;
                }
            }

        }

        public string ReturnDeptID()
        {
            string selected = string.Join(", ", ChklistClientDep.Items.Cast<System.Web.UI.WebControls.ListItem>()
                                    .Where(li => li.Selected).Select(x => x.Value).ToArray());
            return selected;
        }

        //added by shubhendu 
        public string ReturnDeptIDTracker()
        {
            string selected = string.Join(", ", Chkboxlist1.Items.Cast<System.Web.UI.WebControls.ListItem>()
                                    .Where(li => li.Selected).Select(x => x.Value).ToArray());
            return selected;
        }

        public void BindClientDepartment()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = objControler.GetClientDepartment(ApplicationHelper.LoggedInUser.UserData.UserID);
            dt = ds.Tables[0];
            ChklistClientDep.DataSource = dt;
            ChklistClientDep.DataTextField = "DepartmentName";
            ChklistClientDep.DataValueField = "DeptID";
            ChklistClientDep.DataBind();

        }

        public void BindClientDepartmentTracker()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = objControler.GetClientDepartment(ApplicationHelper.LoggedInUser.UserData.UserID);
            dt = ds.Tables[0];
            Chkboxlist1.DataSource = dt;
            Chkboxlist1.DataTextField = "DepartmentName";
            Chkboxlist1.DataValueField = "DeptID";
            Chkboxlist1.DataBind();

        }

        public void BindChildDept(int ParentDeptID)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = objControler.GetChildDepartment(ParentDeptID);
            dt = ds.Tables[0];
            ChklistClientDep.DataSource = dt;
            ChklistClientDep.DataTextField = "DepartmentName";
            ChklistClientDep.DataValueField = "DeptID";
            ChklistClientDep.DataBind();
        }

        //added by shubhendu
        public void BindChildDeptTracker(int ParentDeptID)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = objControler.GetChildDepartment(ParentDeptID);
            dt = ds.Tables[0];
            Chkboxlist1.DataSource = dt;
            Chkboxlist1.DataTextField = "DepartmentName";
            Chkboxlist1.DataValueField = "DeptID";
            Chkboxlist1.DataBind();
            //   ChklistClientDep.DataTextField = "DepartmentName";
            //ChklistClientDep.DataValueField = "DeptID";
            //  ChklistClientDep.DataBind();
        }

        public void BindDepartment()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = objControler.GetParentDepartment();
            dt = ds.Tables[0];
            ddlDeptID.DataSource = dt;
            ddlDeptID.DataTextField = "DepartmentName";
            ddlDeptID.DataValueField = "DeptID";
            ddlDeptID.DataBind();
        }

        public void BindDepartmentTracker()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = objControler.GetParentDepartment();
            dt = ds.Tables[0];
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "DepartmentName";
            DropDownList1.DataValueField = "DeptID";
            DropDownList1.DataBind();
        }

        //below added by Girish on 2023-03-30
        protected void FilterGridBySelectedValue(object sender, EventArgs e)
        {
            Bindgrd(ReturnDeptID());
        }
        //below added by Girish on 2023-04-03
        protected void FilterGridBySelectedValue_SampleTracker(object sender, EventArgs e)
        {
            BindTrackerGrid(ReturnDeptIDTracker());
        }

        protected void grdcriticalpath_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblDcdate = (Label)e.Row.FindControl("lblDcdate");
                Label lblETAtoWareHouse = (Label)e.Row.FindControl("lblETA_to_WareHouse");
                Label lblMDA = (Label)e.Row.FindControl("lblMDA");
                Label lblEID = (Label)e.Row.FindControl("lblEID");
                Label lblInitialExFactoryDate = (Label)e.Row.FindControl("lblInitialExFactoryDate");
                Label lblDept = (Label)e.Row.FindControl("lblDept");
                Label lblTechnicalBihdate = (Label)e.Row.FindControl("lblTechnicalBihdate");

                lblDept.Text = lblDept.Text == "Casual_Dresses" ? "Woven Day Dresses WO" : lblDept.Text;

                if (lblETAtoWareHouse.Text != "")
                {
                    lblETAtoWareHouse.Text = Convert.ToDateTime(lblETAtoWareHouse.Text).ToString("dd MMM yyyy");
                }

                //if (Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.DesignationID) != 48)
                //{
                //    e.Row.Cells[9].Visible = true;
                //    e.Row.Cells[10].Visible = true;
                //}
                if (lblTechnicalBihdate.Text != "")
                {
                    lblTechnicalBihdate.Text = Convert.ToDateTime(lblTechnicalBihdate.Text).ToString("dd MMM yyyy");
                }
                if (lblMDA.Text != "")
                {
                    lblMDA.Text = "'" + lblMDA.Text;
                }
                if (lblEID.Text != "")
                {
                    lblEID.Text = Convert.ToDateTime(lblEID.Text).ToString("dd MMM yyyy");
                }
                if (lblDcdate.Text != "")
                {
                    lblDcdate.Text = Convert.ToDateTime(lblDcdate.Text).ToString("dd MMM yyyy");
                }
                if (lblInitialExFactoryDate.Text != "")
                {
                    lblInitialExFactoryDate.Text = Convert.ToDateTime(lblInitialExFactoryDate.Text).ToString("dd MMM yyyy");
                }
            }
        }

        protected void btntoExcel_Click(object sender, EventArgs e)
        {
            //string filename = "CriticalPathReport_" + DateTime.Now.ToString("ddMMMyyyy") + ".xls";
            //Response.ClearContent();
            //Response.AddHeader("content-disposition", "attachment; filename=" + filename);
            //Response.ContentType = "application/excel";
            //System.IO.StringWriter sw = new System.IO.StringWriter();
            //HtmlTextWriter htw = new HtmlTextWriter(sw);
            //grdcriticalpath.RenderControl(htw);
            //Response.Write(sw.ToString());
            //Response.End();


            //Response.ClearContent();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", filename));
            //Response.ContentType = "application/ms-excel";
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter htw = new HtmlTextWriter(sw);
            //grdcriticalpath.AllowPaging = false;
            //grdcriticalpath.DataSource = dtexcel;
            //grdcriticalpath.DataBind();

            //for (int i = 0; i < grdcriticalpath.HeaderRow.Cells.Count; i++)
            //{
            //    grdcriticalpath.HeaderRow.Cells[i].Style.Add("background-color", "#39589c");
            //}
            //foreach (GridViewRow row in grdcriticalpath.Rows)
            //{
            //    HtmlImage imgstyle = (HtmlImage)row.FindControl("imgstyle");
            //     Label lblurl = (Label)row.FindControl("lblurl");

            //    HiddenField hdnfilepath = (HiddenField)row.FindControl("hdnfilepath");
            //    HyperLink hy = (HyperLink)row.FindControl("hy"); 

            //    if(hdnfilepath.Value!="")
            //    {
            //       imgstyle.Src = "http://ikandi.org.uk:82/" + ResolveUrl("~/uploads/style/thumb-" + hdnfilepath.Value);//chnage the path to live TODO
            //        //lblurl.Text = "http://ikandi.org.uk:82/" + ResolveUrl("~/uploads/style/thumb-" + hdnfilepath.Value);
            //       // hy.NavigateUrl = "http://ikandi.org.uk:82/" + ResolveUrl("~/uploads/style/thumb-" + hdnfilepath.Value);
            //        //hy.Text="http://ikandi.org.uk:82/" + ResolveUrl("~/uploads/style/thumb-" + hdnfilepath.Value);
            //       // imgstyle.Attributes.Add("style","width:60px");
            //        imgstyle.Height = 85;
            //        imgstyle.Width = 100;
            //    }


            //}
            //grdcriticalpath.RenderControl(htw);
            //Response.Write(sw.ToString());
            //Response.End();



            GenerateExcel();
        }

        protected void btntoExcelTracker_Click(object sender, EventArgs e) // added by shubhendu
        {
            GenerateTrakerExcel();

        }

        //public override void VerifyRenderingInServerForm(Control control)
        //{
        //    /*Tell the compiler that the control is rendered
        //     * explicitly by overriding the VerifyRenderingInServerForm event.*/
        //}

        protected void grdcriticalpath_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdcriticalpath.PageIndex = e.NewPageIndex;
            Bindgrd(ReturnDeptID());

        }

        // added by shubhendu
        protected void grdSampleTracker_PageIndexChanging(object sender, GridViewPageEventArgs e)// added by shubhendu
        {
            grdSampleTracker.PageIndex = e.NewPageIndex;
            BindTrackerGrid(ReturnDeptIDTracker());
        }

        // added by shubhendu
        public void GenerateTrakerExcel()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dtexcel = (DataTable)Session["TrackerDept"];

            if (dtexcel.Rows.Count > 0)
            {
                sb.Append("<TABLE width=100% cellpadding=0 cellspacing=0 border=1>");

                sb.Append("<TR>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>StyleNumber</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white; color:white; width:150px;'>Sketch</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white; color:white; width:150px;'>BuyerStyle No.</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white; color:white; width:150px;'>Sketch Recv Date</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white; color:white; width:150px;'>AWB Number</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>FabricName</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>Trims</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>Status</TH>");

                sb.Append("</TR>");

                foreach (DataRow row in dtexcel.Rows)
                {
                    sb.Append("<TR>");
                    // StyleNumber 
                    if (row["Stylenumber"].ToString() != "")
                        sb.Append("<TD style='text-align:center;valign:center;'>" + row["Stylenumber"].ToString() + "</TD>");
                    else
                        sb.Append("<TD style='text-align:center;valign:center;'>" + "No record found" + "</TD>");

                    // Image
                    if (row["SketchURL"].ToString() != "")
                    {
                        string str = "http://ikandi.org.uk/uploads/style/thumb-" + row["SketchURL"].ToString();
                        sb.Append("<TD style='width:150px; height:110px; valign:center;'>" + "<img  src='" + str + "' width='150' height='108' style='font-size:9px;' alt='Image not found'/>" + "</TD>");
                    }
                    else
                    {
                        sb.Append("<TD style='width:200px; height:100px;valign:center;'> </TD>");
                    }

                    // Supplier Reference block URL
                    if (row["ReferenceBlockURL"].ToString() != "")
                    {
                        string str = "http://ikandi.org.uk/uploads/style/thumb-" + row["ReferenceBlockURL"].ToString();
                        sb.Append("<TD style='width:150px; height:110px; valign:center;'>" + "<img  src='" + str + "' width='150' height='108' style='font-size:9px;' alt='Image not found'/>" + "</TD>");
                    }
                    else
                    {
                        sb.Append("<TD style='width:200px; height:100px;valign:center;'> </TD>");
                    }
                    // Created date
                    sb.Append("<TD style='text-align:center;valign:center;'>" + Convert.ToDateTime(row["CreatedOn"]).ToString("dd MMM yyyy") + "</TD>");

                    sb.Append("<TD style='text-align:center;valign:center;'>" + Convert.ToDateTime(row["CreatedOn"]).ToString("dd MMM yyyy") + "</TD>");

                    // FabricName
                    sb.Append("<TD style='text-align:center;valign:center;'>" + row["AWBNumber"].ToString() + "</TD>");
                    // Style Trims
                    sb.Append("<TD style='text-align:center;valign:center;'>" + row["Trims"].ToString() + "</TD>");
                    // Remarks 

                    sb.Append("<TD style='text-align:center;valign:center;'>" + row["Remarks"].ToString() + "</TD>");

                    sb.Append("</TR>");
                }

                sb.Append("</TABLE>");

                try
                {
                    string fileName = "attachment;fileName=ExportToExcelTracker.xls";
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("Content-Disposition", fileName);

                    string[] font = new string[] { "Verdana", "Arial", "Sans-Serif" };

                    Response.Charset = "";

                    this.EnableViewState = false;

                    StringWriter strwiriter = new System.IO.StringWriter();

                    strwiriter.Write(sb.ToString());

                    HtmlTextWriter ohtmltextwriter = new HtmlTextWriter(strwiriter);

                    Repeater rt = new Repeater();

                    rt.RenderControl(ohtmltextwriter);

                    Response.Write(strwiriter.ToString());

                    Response.End();

                }
                catch (Exception ex)
                {
                    string str = ex.Message.ToString();
                }
            }
        }

        public void GenerateExcel()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dtexcel = (DataTable)Session["Dept"];

            if (dtexcel.Rows.Count > 0)
            {
                sb.Append("<TABLE width=100% cellpadding=0 cellspacing=0 border=1>");

                sb.Append("<TR>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>Department</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white; color:white; width:150px;'>Image</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>Supplier Reference</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>Department Category</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>Style</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>Style Description</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>PO Number</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>MDA</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>Initial ExFactory Date</TH>");
                if (Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.DesignationID) != 48)
                {
                    sb.Append("<TH style='background-color : #39589c; color:white;'>STC Date</TH>");
                    sb.Append("<TH style='background-color : #39589c; color:white;'>Fits/TOP status</TH>");
                }

                sb.Append("<TH style='background-color : #39589c; color:white;'>Delivery Date</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>Fulfilment Center</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>PO Quantity Units</TH>");

                sb.Append("<TH style='background-color : #39589c; color:white;'>Ikandi Price</TH>");

                sb.Append("<TH style='background-color : #39589c; color:white;'>IKandi Order Reference</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>Order Status</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>IKandi Shipped Quantity</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>Shipment Mode</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>ETD</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>ETA To Warehouse</TH>");
                sb.Append("<TH style='background-color : #39589c; color:white;'>IKandi Comments</TH>");
                sb.Append("</TR>");

                foreach (DataRow row in dtexcel.Rows)
                {
                    sb.Append("<TR>");
                    // Department 
                    if (row["DepartmentName"].ToString() == "Casual_Dresses")
                        sb.Append("<TD style='text-align:center;valign:center;'>" + "Woven Day Dresses WO" + "</TD>");
                    else
                        sb.Append("<TD style='text-align:center;valign:center;'>" + row["DepartmentName"].ToString() + "</TD>");

                    // Image
                    if (row["SampleImageURL1"].ToString() != "")
                    {
                        string str = "http://ikandi.org.uk/uploads/style/thumb-" + row["SampleImageURL1"].ToString();
                        sb.Append("<TD style='width:150px; height:110px; valign:center;'>" + "<img  src='" + str + "' width='150' height='108' style='font-size:9px;' alt='Image not found'/>" + "</TD>");
                    }
                    else
                    {
                        sb.Append("<TD style='width:200px; height:100px;valign:center;'> </TD>");
                    }

                    // Supplier Reference
                    sb.Append("<TD style='text-align:center;valign:center;'>" + row["StyleNumber"].ToString() + "</TD>");
                    // Department Category
                    sb.Append("<TD style='text-align:center;valign:center;'>" + row["DepartmentCatg"].ToString() + "</TD>");
                    // Style
                    sb.Append("<TD style='text-align:center;valign:center;'>" + row["LineItemNumber"].ToString() + "</TD>");
                    // Style Description
                    sb.Append("<TD style='text-align:center;valign:center;'>" + row["Description"].ToString() + "</TD>");
                    // PO Number
                    sb.Append("<TD style='text-align:center;valign:center;'>" + row["PoNumber"].ToString() + "</TD>");
                    // MDA
                    if (row["MDA"].ToString() != string.Empty)
                        sb.Append("<TD style='text-align:center;valign:center;'>" + "'" + row["MDA"].ToString() + "</TD>");
                    else
                        sb.Append("<TD></TD>");
                    // Initial ExFactory
                    if (row["ETD"].ToString() != string.Empty)
                        sb.Append("<TD style='text-align:center;valign:center;'>" + Convert.ToDateTime(row["ETD"]).ToString("dd MMM yyyy") + "</TD>");
                    else
                        sb.Append("<TD></TD>");
                    if (Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.DesignationID) != 48)
                    {
                        //// STC Date
                        if (row["STCBIHdate"].ToString() != string.Empty)
                            sb.Append("<TD style='text-align:center;valign:center;'>" + Convert.ToDateTime(row["STCBIHdate"]).ToString("dd MMM yyyy") + "</TD>");
                        else
                            sb.Append("<TD></TD>");
                        //// Fits/TOP status
                        sb.Append("<TD style='text-align:center;valign:center;'>" + row["FitsStatus"].ToString() + "</TD>");
                    }
                    // Delivery Date
                    if (row["DC"].ToString() != "")
                    {
                        sb.Append("<TD style='text-align:center;valign:center;'>" + Convert.ToDateTime(row["DC"]).ToString("dd MMM yyyy") + "</TD>");
                    }
                    else
                    {
                        sb.Append("<TD></TD>");
                    }
                    // Fulfilment Center
                    sb.Append("<TD style='text-align:center;valign:center;'>" + row["FulfilmentCenter"].ToString() + "</TD>");
                    // PO Quantity Units
                    sb.Append("<TD style='text-align:center;valign:center;'>" + row["Quantity"].ToString() + "</TD>");

                    sb.Append("<TD style='text-align:center;valign:center;'>" + row["IkandiPrice"].ToString() + "</TD>");

                    // IKandi Order Reference
                    sb.Append("<TD style='text-align:center;valign:center;'>" + row["SerialNumber"].ToString() + "</TD>");
                    // Order Status
                    sb.Append("<TD style='text-align:center;valign:center;'>" + row["OrderStatus"].ToString() + "</TD>");
                    // IKandi Shipped Quantity
                    sb.Append("<TD style='text-align:center;valign:center;'>" + row["ShippedQty"].ToString() + "</TD>");
                    // Shipment Mode
                    sb.Append("<TD style='text-align:center;valign:center;'>" + row["ShippedMode"].ToString() + "</TD>");
                    // ETD
                    if (row["ETD"].ToString() != string.Empty)
                        sb.Append("<TD style='text-align:center;valign:center;'>" + Convert.ToDateTime(row["ETD"]).ToString("dd MMM yyyy") + "</TD>");
                    else
                        sb.Append("<TD></TD>");
                    // ETA to Warehouse
                    if (row["ETA_to_WareHouse"].ToString() != string.Empty)
                        sb.Append("<TD style='text-align:center;valign:center;'>" + Convert.ToDateTime(row["ETA_to_WareHouse"]).ToString("dd MMM yyyy") + "</TD>");
                    else
                        sb.Append("<TD></TD>");
                    // Ikandi Comments
                    sb.Append("<TD style='text-align:center;valign:center;'>" + row["IkandiComment"].ToString() + "</TD>");

                    sb.Append("</TR>");
                }

                sb.Append("</TABLE>");

                try
                {

                    string fileName = "attachment;fileName=ExportToExcel.xls";
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("Content-Disposition", fileName);

                    string[] font = new string[] { "Verdana", "Arial", "Sans-Serif" };

                    Response.Charset = "";

                    this.EnableViewState = false;



                    StringWriter strwiriter = new System.IO.StringWriter();

                    strwiriter.Write(sb.ToString());

                    HtmlTextWriter ohtmltextwriter = new HtmlTextWriter(strwiriter);

                    Repeater rt = new Repeater();

                    rt.RenderControl(ohtmltextwriter);

                    Response.Write(strwiriter.ToString());

                    Response.End();


                }
                catch (Exception ex)
                {
                    string str = ex.Message.ToString();
                }
            }
        }

        protected void ChkIsAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckDefualt(ChkIsAll.Checked);
            Bindgrd(ReturnDeptID());
            BindGrid();
        }

        //by me shubhendu
        protected void ChkBoxall1_CheckedChanged(object sender, EventArgs e)
        {
            CheckDefualtTracker(ChkBoxall1.Checked);
            BindTrackerGrid(ReturnDeptIDTracker());
        }

        protected void ChklistClientDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bindgrd(ReturnDeptID());

            if (CheckboxListSelections(ChklistClientDep) == ChklistClientDep.Items.Count)
            {
                foreach (System.Web.UI.WebControls.ListItem item in ChklistClientDep.Items)
                {
                    item.Selected = true;
                    item.Enabled = false;
                    ChkIsAll.Checked = true;
                }
            }
            BindGrid();
        }

        //added by shubhendu 
        protected void Chkboxlist1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindTrackerGrid(ReturnDeptIDTracker());

            if (CheckboxListSelectionsTracker(Chkboxlist1) == Chkboxlist1.Items.Count)
            {
                foreach (System.Web.UI.WebControls.ListItem item in Chkboxlist1.Items)
                {
                    item.Selected = true;
                    item.Enabled = false;
                    ChkIsAll.Checked = true;
                }
            }
        }

        public int CheckboxListSelections(System.Web.UI.WebControls.CheckBoxList list)
        {
            int a = 0;
            // ArrayList values = new ArrayList();
            for (int counter = 0; counter < list.Items.Count; counter++)
            {
                if (list.Items[counter].Selected)
                {
                    a += 1;
                }
            }
            return a;
        }

        //added by shubhendu
        public int CheckboxListSelectionsTracker(System.Web.UI.WebControls.CheckBoxList list)
        {
            int a = 0;
            for (int counter = 0; counter < list.Items.Count; counter++)
            {
                if (list.Items[counter].Selected)
                {
                    a += 1;
                }
            }
            return a;
        }

        public void BindGrid()
        {
            ClientController objclient = new ClientController();
            //string FinancialYear = GetCurrentFinancialYear();
            //string[] year = FinancialYear.Split('-');

            //DataSet ds = objclient.GetIkandiSales_AdminByYearNew_Critical_Path_Report(Convert.ToInt32(year[0]), Convert.ToInt32(year[1]), ApplicationHelper.LoggedInUser.UserData.UserID);

            DataSet ds = objclient.GetDataFor_grdIkandiadminCommit_sales_Grid(ReturnDeptID());


            if (ds.Tables[0].Rows.Count > 0)
            {
                grdIkandiadminCommit_sales.RowDataBound += new GridViewRowEventHandler(grdIkandiadminCommit_sales_RowDataBound);
                grdIkandiadminCommit_sales.DataSource = ds.Tables[0];
                grdIkandiadminCommit_sales.DataBind();

            }

            //below added by Girish On 2023-03-30
            if (ds.Tables[1].Rows.Count > 0)
            {
                spn_Year.InnerHtml = "(" + ds.Tables[1].Rows[0]["FinancialYear"].ToString() + ")";

                lblSalesManager.Text = ds.Tables[1].Rows[0]["Salesmanager"].ToString();
                _lblSalesManager.Text = ds.Tables[1].Rows[0]["Salesmanager"].ToString();

                lbldesigner.Text = ds.Tables[1].Rows[0]["Deisgner"].ToString();
                _lblDesigner.Text = ds.Tables[1].Rows[0]["Deisgner"].ToString();
            }

            //commented below code by Girish on 2023-03-30

            //int i = 2;
            //int y = 1;

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    for (int k = 4; k < ds.Tables[0].Columns.Count; k++)
            //    {
            //        if (k % 2 == 0)
            //        {
            //            //total = ds.Tables[0].AsEnumerable().Sum(row => row.Field<double>(ds.Tables[0].Columns[k].ToString()));
            //            //grdIkandiadminCommit_sales.FooterRow.Cells[i].Text = total.ToString() == "0" ? "" : symbol + (total / 1000).ToString("0.00") + " K";
            //            //grdIkandiadminCommit_sales.FooterRow.Cells[i].Font.Bold = true;
            //            //grdIkandiadminCommit_sales.FooterRow.Cells[i].ForeColor = System.Drawing.Color.Gray;
            //            //grdIkandiadminCommit_sales.FooterRow.Cells[i].ToolTip = total.ToString("#,##0");
            //        }
            //        else
            //        {
            //            //total = ds.Tables[0].AsEnumerable().Sum(row => row.Field<double>(ds.Tables[0].Columns[k].ToString()));
            //            //grdIkandiadminCommit_sales.FooterRow.Cells[i].Text = total.ToString() == "0" ? "" : symbol + (total / 1000).ToString("0.00") + " K";
            //            //grdIkandiadminCommit_sales.FooterRow.Cells[i].Font.Bold = true;
            //            //grdIkandiadminCommit_sales.FooterRow.Cells[i].ToolTip = total.ToString("#,##0");
            //            //grdIkandiadminCommit_sales.FooterRow.Cells[i].ForeColor = System.Drawing.Color.Green;
            //            //if (y % 2 == 0)
            //            //{
            //            //    symbol = "&#65505; ";
            //            //}
            //            //else
            //            //{
            //            //    symbol = "";
            //            //}
            //            y++;
            //        }
            //        i++;
            //    }

            //    //grdIkandiadminCommit_sales.FooterRow.Cells[0].ColumnSpan = 2;
            //    //grdIkandiadminCommit_sales.FooterRow.Cells.RemoveAt(1);

            //    //MegrgeRowinGridViewClient();
            //}
        }

        public string get()
        {

            string Cu = "April " + DateTime.Today.Year.ToString();
            if (DateTime.Today.Month <= 12)
            {
                Cu = Cu + DateTime.Now.AddMonths(-1) + DateTime.Today.Year.ToString();
            }
            else
            {
                Cu = Cu + (DateTime.Now.AddMonths(-1).ToString() + DateTime.Today.AddYears(1).Year).ToString();
            }
            return Cu;
        }

        public string GetCurrentFinancialYear()
        {
            int CurrentYear = DateTime.Today.Year;
            int PreviousYear = DateTime.Today.Year - 1;
            int NextYear = DateTime.Today.Year + 1;
            string PreYear = PreviousYear.ToString();
            string NexYear = NextYear.ToString();
            string CurYear = CurrentYear.ToString();
            string FinYear = null;

            if (DateTime.Today.Month > 3)
                FinYear = CurYear + "-" + NexYear;
            else
                FinYear = PreYear + "-" + CurYear;
            return FinYear.Trim();
        }

        //below added by Girish on 2023-03-30
        protected void grdIkandiadminCommit_sales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex == 0)
            {
                e.Row.Cells[0].Text = "Total Sales " + ChangeColor(e.Row.Cells[0].Text, "TotalSales");
                e.Row.Cells[1].Text = "Total Sales " + ChangeColor(e.Row.Cells[1].Text, "TotalSales");
                e.Row.Cells[2].Text = "Total Sales " + ChangeColor(e.Row.Cells[2].Text, "TotalSales");
            }
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex == 1)
            {
                e.Row.Cells[0].Text = "TotalUnit Booked " + ChangeColor(e.Row.Cells[0].Text, "TotalUnitBooked");
                e.Row.Cells[1].Text = "TotalUnit Booked " + ChangeColor(e.Row.Cells[1].Text, "TotalUnitBooked");
                e.Row.Cells[2].Text = "TotalUnit Booked " + ChangeColor(e.Row.Cells[2].Text, "TotalUnitBooked");
            }
        }

        //below added by Girish on 2023-03-30
        private string ChangeColor(string str, string flag)
        {
            string result = "";

            string[] parts = str.Split(' ');

            if (parts.Length > 1 && parts[0].Trim() != "" && parts[0].Trim() !="&nbsp;")
            {
                decimal firstNumber = decimal.Parse(parts[0]);

                if (parts[1].Trim() != "")
                {
                    decimal secondNumber = decimal.Parse(parts[1].Trim('(', ')'));

                    if (firstNumber < secondNumber)
                    {
                        if (flag.ToLower() == "TotalSales".ToLower())
                        {
                            result = "<span style='color:red;'>" + FormatNumber(firstNumber, "TotalSales") + "</span>";
                        }
                        else
                        {
                            result = "<span style='color:red;'>" + FormatNumber(firstNumber, "TotalUnitBooked") + "</span>";
                        }
                    }
                    else if (firstNumber >= secondNumber)
                    {
                        if (flag.ToLower() == "TotalSales".ToLower())
                        {
                            result = "<span style='color:green;'>" + FormatNumber(firstNumber, "TotalSales") + "</span>";
                        }
                        else
                        {
                            result = "<span style='color:green;'>" + FormatNumber(firstNumber, "TotalUnitBooked") + "</span>";
                        }
                    }
                    if (flag.ToLower() == "TotalSales".ToLower())
                    {
                        result = result + (FormatNumber(secondNumber, "TotalSales") == "" ? "" : "<span style='color:gray;'>" + " (" + FormatNumber(secondNumber, "TotalSales") + ")" + "</span>");
                    }
                    else
                    {
                        result = result + (FormatNumber(secondNumber, "TotalUnitBooked") == "" ? "" : "<span style='color:gray;'>" + " (" + FormatNumber(secondNumber, "TotalUnitBooked") + ")" + "</span>");
                    }
                }
                else
                {
                    if (flag.ToLower() == "TotalSales".ToLower())
                    {
                        result = FormatNumber(firstNumber, "TotalSales") == "" ? "" : "<span style='color:gray;'" + " (" + FormatNumber(firstNumber, "TotalSales") + ")" + "</span>";
                    }
                    else
                    {
                        result = FormatNumber(firstNumber, "TotalUnitBooked") == "" ? "" : "<span style='color:gray;'" + " (" + FormatNumber(firstNumber, "TotalUnitBooked") + ")" + "</span>";
                    }
                }
            }
            else
            {
                if (str.Trim('(', ')') != "" && parts[0].Trim() != "&nbsp;")
                {
                    if (flag.ToLower() == "TotalSales".ToLower())
                    {
                        result = FormatNumber(Convert.ToDecimal(str.Trim('(', ')')), "TotalSales") == "" ? "" : "<span style='color:gray'>" + " (" + FormatNumber(Convert.ToDecimal(str.Trim('(', ')')), "TotalSales") + ")" + "</span>";
                    }
                    else
                    {
                        result = FormatNumber(Convert.ToDecimal(str.Trim('(', ')')), "TotalUnitBooked") == "" ? "" : "<span style='color:gray'>" + " (" + FormatNumber(Convert.ToDecimal(str.Trim('(', ')')), "TotalUnitBooked") + ")" + "</span>";
                    }
                }
            }
            return result;
        }

        //below added by Girish on 2023-03-30
        private string FormatNumber(Decimal number, string flag)
        {
            string result = "";
            if (flag.ToLower() == "TotalSales".ToLower())
            {
                result = Math.Round(number / 1000, 0) == 0 ? "" : "￡" + Math.Round((number / 1000)).ToString() + "K";
            }
            else if (flag.ToLower() == "TotalUnitBooked".ToLower())
            {
                result = Math.Round(number / 1000, 0) == 0 ? "" : Math.Round((number / 1000)).ToString() + "K";
            }
            return result;
        }

        //below commented by Girish on 2023-03-30

        //public void MaintainMonthColumn(TableCell HeaderCell, string RowIndex = "0", string MonthName = "")
        //{
        //    if (RowIndex == "0")
        //    {
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        if (HeaderCell.Text.ToLower() == strarryPerv_m[0].ToLower() || HeaderCell.Text.ToLower() == strarryCurrent_m[0].ToLower() || HeaderCell.Text.ToLower() == strarryNext_m[0].ToLower())
        //        {
        //            HeaderCell.Visible = true;
        //            if (HeaderCell.Text.ToLower() == strarryPerv_m[0].ToLower())
        //            {
        //                HeaderCell.Attributes.Remove("display:none");
        //                HeaderCell.Attributes.Add("class", "displayblock");
        //                HeaderCell.Attributes.Add("style", "background:#b1acac;border-right: 1px solid #b70505;");
        //            }
        //            if (HeaderCell.Text.ToLower() == strarryCurrent_m[0].ToLower())
        //            {
        //                HeaderCell.Attributes.Remove("display:none");
        //                HeaderCell.Attributes.Add("class", "displayblock");
        //                HeaderCell.Attributes.Add("style", "background:#b1acac;border-top:1px solid #b70505;border-right: 1px solid #b70505;");
        //            }
        //            if (HeaderCell.Text.ToLower() == strarryNext_m[0].ToLower())
        //            {
        //                HeaderCell.Attributes.Remove("display:none");
        //                HeaderCell.Attributes.Add("class", "displayblock");
        //                HeaderCell.Attributes.Add("style", "background:#b1acac");
        //            }

        //        }
        //        else
        //        {
        //            //HeaderCell.Visible = false;
        //            HeaderCell.Attributes.Add("class", "displaynone");
        //            HeaderCell.Attributes.Add("style", "background:#b1acac");
        //        }
        //    }
        //    else if (RowIndex == "2")
        //    {
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        if (MonthName.ToLower() == strarryPerv_m[0].ToLower())
        //        {
        //            HeaderCell.Attributes.Remove("display:none");
        //            HeaderCell.Attributes.Add("class", "displayblock");
        //            HeaderCell.Text = "Total <span style='Color:green'>sales</span>";
        //            HeaderCell.Attributes.Add("style", "background:#dcd6d6;border-right: 1px solid #b70505;");
        //        }
        //        else if (MonthName.ToLower() == strarryCurrent_m[0].ToLower())
        //        {
        //            HeaderCell.Attributes.Remove("display:none");
        //            HeaderCell.Attributes.Add("class", "displayblock");
        //            HeaderCell.Text = "Total <span style='Color:green'>sales</span>";
        //            HeaderCell.Attributes.Add("style", "background:#dcd6d6;border-right: 1px solid #b70505;");
        //        }
        //        else if (MonthName.ToLower() == strarryNext_m[0].ToLower())
        //        {
        //            HeaderCell.Attributes.Remove("display:none");
        //            HeaderCell.Attributes.Add("class", "displayblock");
        //            HeaderCell.Text = "Total <span style='Color:green'>sales</span>";
        //            HeaderCell.Attributes.Add("style", "background:#dcd6d6");
        //        }
        //        else
        //        {
        //            //HeaderCell.Visible = false;
        //            HeaderCell.Attributes.Add("class", "displaynone");
        //            HeaderCell.Attributes.Add("style", "background:#b1acac");
        //        }

        //    }
        //    else if (RowIndex == "3")
        //    {
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        if (MonthName.ToLower() == strarryPerv_m[0].ToLower())
        //        {
        //            HeaderCell.Attributes.Remove("display:none");
        //            HeaderCell.Attributes.Add("class", "displayblock");
        //            HeaderCell.Text = "Total <span style='Color:green'> Units Booked</span>";
        //            HeaderCell.Attributes.Add("style", "background:#dcd6d6;border-right: 1px solid #b70505;");
        //            HeaderCell.Attributes.Add("class", "minWidthTarget");
        //        }
        //        else if (MonthName.ToLower() == strarryCurrent_m[0].ToLower())
        //        {
        //            HeaderCell.Attributes.Remove("display:none");
        //            HeaderCell.Attributes.Add("class", "displayblock");
        //            HeaderCell.Text = "Total <span style='Color:green'> Units Booked</span>";
        //            HeaderCell.Attributes.Add("style", "background:#dcd6d6;border-right: 1px solid red;");
        //            HeaderCell.Attributes.Add("class", "minWidthActual");
        //        }
        //        else if (MonthName.ToLower() == strarryNext_m[0].ToLower())
        //        {
        //            HeaderCell.Attributes.Remove("display:none");
        //            HeaderCell.Attributes.Add("class", "displayblock");
        //            HeaderCell.Text = "Total <span style='Color:green'> Units Booked</span>";
        //            HeaderCell.Attributes.Add("style", "background:#dcd6d6");
        //            HeaderCell.Attributes.Add("class", "minWidthTarget");
        //        }
        //        else
        //        {
        //            HeaderCell.Attributes.Add("class", "displaynone");
        //            HeaderCell.Attributes.Add("style", "background:#b1acac");
        //        }

        //    }

        //}



        //below commented by Girish on 2023-03-30

        //protected void grdIkandiadminCommit_sales_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.Header)
        //    {
        //        GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
        //        GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
        //        GridViewRow headerRow3 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

        //        headerRow1.Attributes.Add("class", "HeaderClass");
        //        headerRow2.Attributes.Add("class", "HeaderClass");
        //        headerRow3.Attributes.Add("class", "HeaderClass");

        //        TableCell HeaderCell = new TableCell();


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "April";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 4;
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        HeaderCell.Attributes.Add("style", "background:#b1acac");
        //        headerRow1.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "May";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 4;
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        HeaderCell.Attributes.Add("style", "background:#b1acac");
        //        headerRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "June";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 4;
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        HeaderCell.Attributes.Add("style", "background:#b1acac");
        //        headerRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "July";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 4;
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        HeaderCell.Attributes.Add("style", "background:#b1acac");
        //        headerRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "August";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 4;
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        HeaderCell.Attributes.Add("style", "background:#b1acac");
        //        headerRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "September";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 4;
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        HeaderCell.Attributes.Add("style", "background:#b1acac");
        //        headerRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "October";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        MaintainMonthColumn(HeaderCell);
        //        headerRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "November";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        MaintainMonthColumn(HeaderCell);
        //        headerRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "December";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        MaintainMonthColumn(HeaderCell);
        //        headerRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "January";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;

        //        MaintainMonthColumn(HeaderCell);
        //        headerRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "February";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;

        //        MaintainMonthColumn(HeaderCell);
        //        headerRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "March";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        MaintainMonthColumn(HeaderCell);
        //        headerRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "April";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        MaintainMonthColumn(HeaderCell);
        //        headerRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Pcs";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 2;
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow2.Cells.Add(HeaderCell);
        //        //april


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Val";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 2;
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Pcs";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 2;
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow2.Cells.Add(HeaderCell);
        //        //may

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Val";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 2;
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Pcs";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 2;
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow2.Cells.Add(HeaderCell);
        //        //june

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Val";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 2;
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Pcs";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 2;
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow2.Cells.Add(HeaderCell);
        //        //july

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Val";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 2;
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Pcs";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 2;
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow2.Cells.Add(HeaderCell);
        //        //aug

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Val";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 2;
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Pcs";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 2;
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow2.Cells.Add(HeaderCell);
        //        //Sep

        //        HeaderCell = new TableCell();
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        MaintainMonthColumn(HeaderCell, "2", "October");
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        MaintainMonthColumn(HeaderCell, "2", "November");
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        MaintainMonthColumn(HeaderCell, "2", "December");
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        MaintainMonthColumn(HeaderCell, "2", "January");
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        MaintainMonthColumn(HeaderCell, "2", "february");
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        MaintainMonthColumn(HeaderCell, "2", "March");
        //        headerRow2.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        MaintainMonthColumn(HeaderCell, "2", "April");
        //        headerRow2.Cells.Add(HeaderCell);

        //        //HeaderCell = new TableCell();
        //        //HeaderCell.Text = "Val";
        //        //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        //HeaderCell.ColumnSpan = 2;
        //        //headerRow2.Cells.Add(HeaderCell);

        //        //HeaderCell = new TableCell();
        //        //HeaderCell.Text = "Pcs";
        //        //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        //HeaderCell.ColumnSpan = 2;
        //        //headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Val";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 2;
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Pcs";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 2;
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Val";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 2;
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Pcs";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 2;
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Val";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 2;
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Pcs";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 2;
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow2.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Target";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthTarget");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Actual";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthActual");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Target";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthTarget");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Actual";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthActual");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);
        //        //april


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Target";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthTarget");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Actual";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthActual");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Target";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthTarget");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Actual";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthActual");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);
        //        //may


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Target";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthTarget");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Actual";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthActual");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Target";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthTarget");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Actual";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthActual");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);
        //        //june


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Target";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthTarget");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Actual";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthActual");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Target";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthTarget");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Actual";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthActual");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);
        //        //july



        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Target";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthTarget");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Actual";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthActual");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Target";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthTarget");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Actual";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthActual");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);
        //        //aug



        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Target";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthTarget");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Actual";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthActual");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Target";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthTarget");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Actual";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthActual");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);
        //        //sep



        //        HeaderCell = new TableCell();
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        MaintainMonthColumn(HeaderCell, "3", "October");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        MaintainMonthColumn(HeaderCell, "3", "November");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        MaintainMonthColumn(HeaderCell, "3", "December");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        MaintainMonthColumn(HeaderCell, "3", "January");
        //        headerRow3.Cells.Add(HeaderCell);
        //        //jan

        //        HeaderCell = new TableCell();
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        MaintainMonthColumn(HeaderCell, "3", "february");
        //        headerRow3.Cells.Add(HeaderCell);
        //        //feb

        //        HeaderCell = new TableCell();
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        MaintainMonthColumn(HeaderCell, "3", "March");
        //        headerRow3.Cells.Add(HeaderCell);
        //        //March

        //        HeaderCell = new TableCell();
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        MaintainMonthColumn(HeaderCell, "3", "April");
        //        headerRow3.Cells.Add(HeaderCell);
        //        //March



        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Target";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthTarget");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Actual";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthActual");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Target";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthTarget");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Actual";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthActual");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);
        //        //jan

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Target";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthTarget");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Actual";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthActual");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Target";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthTarget");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Actual";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthActual");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);
        //        //feb

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Target";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthTarget");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Actual";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthActual");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Target";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthTarget");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Actual";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("class", "minWidthActual");
        //        HeaderCell.Attributes.Add("class", "displaynone");
        //        headerRow3.Cells.Add(HeaderCell);
        //        //mar


        //        grdIkandiadminCommit_sales.Controls[0].Controls.AddAt(0, headerRow3);
        //        grdIkandiadminCommit_sales.Controls[0].Controls.AddAt(0, headerRow2);
        //        grdIkandiadminCommit_sales.Controls[0].Controls.AddAt(0, headerRow1);
        //    }
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        if ("November".ToLower() == strarryCurrent_m[0].ToLower())
        //        {

        //            e.Row.Cells[24].CssClass = "displayblocks BorderPerRight";
        //            e.Row.Cells[25].CssClass = "displayblocks RedBorder";
        //            e.Row.Cells[26].CssClass = "displayblocks";
        //        }
        //        if ("December".ToLower() == strarryCurrent_m[0].ToLower())
        //        {
        //            e.Row.Cells[25].CssClass = "displayblocks BorderPerRight";
        //            e.Row.Cells[26].CssClass = "displayblocks RedBorder";
        //            e.Row.Cells[27].CssClass = "displayblocks";
        //        }
        //        if ("January".ToLower() == strarryCurrent_m[0].ToLower())
        //        {
        //            e.Row.Cells[26].CssClass = "displayblocks BorderPerRight";
        //            e.Row.Cells[27].CssClass = "displayblocks RedBorder";
        //            e.Row.Cells[28].CssClass = "displayblocks";
        //        }
        //        if ("february".ToLower() == strarryCurrent_m[0].ToLower())
        //        {
        //            e.Row.Cells[27].CssClass = "displayblocks BorderPerRight";
        //            e.Row.Cells[28].CssClass = "displayblocks RedBorder";
        //            e.Row.Cells[29].CssClass = "displayblocks";
        //        }
        //        if ("March".ToLower() == strarryCurrent_m[0].ToLower())
        //        {
        //            e.Row.Cells[28].CssClass = "displayblocks BorderPerRight";
        //            e.Row.Cells[29].CssClass = "displayblocks RedBorder";
        //            e.Row.Cells[30].CssClass = "displayblocks";
        //        }

        //        int x = 2;
        //        int y = 4;
        //        for (int i = 1; i <= 12; i++)
        //        {
        //            Label lblval = e.Row.FindControl("lblVal" + i) as Label;
        //            Label lblpcs = e.Row.FindControl("lblPcs" + i) as Label;
        //            Label lblvalAct = e.Row.FindControl("lblValAct" + i) as Label;
        //            Label lblpcsAct = e.Row.FindControl("lblPcsAct" + i) as Label;

        //            if (lblval.Text != "")
        //            {
        //                if (lblvalAct.Text == "")
        //                {
        //                }
        //                else if (Convert.ToDouble(lblvalAct.Text.Replace("K", "").Replace("￡", "")) < Convert.ToDouble(lblval.Text.Replace("K", "").Replace("￡", "")))
        //                {
        //                    //e.Row.Cells[i + x].Style.Add("color", "red !important");
        //                    lblvalAct.Style.Add("color", "red !important");
        //                }
        //                else
        //                {
        //                    // e.Row.Cells[i + x].Style.Add("color", "green !important");
        //                    lblvalAct.Style.Add("color", "green !important");
        //                }

        //            }
        //            else
        //            {
        //                if (lblvalAct.Text == "")
        //                {
        //                }
        //                else
        //                    //e.Row.Cells[i + x].Style.Add("color", "green  !important");
        //                    lblvalAct.Style.Add("color", "green  !important");

        //            }
        //            if (lblpcs.Text != "")
        //            {
        //                if (lblpcsAct.Text == "")
        //                {
        //                }
        //                else if (Convert.ToDouble(lblpcsAct.Text.Replace("K", "")) < Convert.ToDouble(lblpcs.Text.Replace("K", "")))
        //                {
        //                    //e.Row.Cells[i + y].Style.Add("color", "red  !important");
        //                    lblpcsAct.Style.Add("color", "red  !important");
        //                }
        //                else
        //                {
        //                    //e.Row.Cells[i + y].Style.Add("color", "green  !important");
        //                    lblpcsAct.Style.Add("color", "green  !important");
        //                }
        //            }
        //            else
        //            {
        //                if (lblpcsAct.Text == "")
        //                {
        //                }
        //                else
        //                    // e.Row.Cells[i + y].Style.Add("color", "green  !important");
        //                    lblpcsAct.Style.Add("color", "green  !important");
        //            }

        //            x = x + 3;
        //            y = y + 3;
        //            //lblvalAct.Text = GetRoundVal(lblvalAct.Text.Replace("K", "").Replace("￡", ""));
        //            //lblpcsAct.Text = GetRoundVal(lblpcsAct.Text.Replace("K", "").Replace("￡", ""));
        //            //lblpcs.Text = GetRoundVal(lblpcs.Text.Replace("K", "").Replace("￡", ""));
        //            //lblval.Text = GetRoundVal(lblval.Text.Replace("K", "").Replace("￡", ""));
        //        }
        //    }


        //}

        //below Commenetd By Girish on 2023-03-30

        //public string GetRoundVal(string amtval)
        //{
        //    string strval = "";
        //    if (amtval.IndexOf('.') > -1)
        //    {
        //        string[] val = amtval.Split('.');
        //        if (val.Length > 1)
        //        {
        //            if (Convert.ToDecimal(val[1]) >= 50)
        //            {
        //                strval = Convert.ToDecimal(val[0] + 1).ToString();
        //            }
        //            else
        //            {
        //                strval = val[0];
        //            }
        //        }
        //    }
        //    else
        //    {
        //        strval = amtval;
        //    }
        //    return strval;
        //}

        //below Commenetd By Girish on 2023-03-30

        //public void MegrgeRowinGridViewClient()
        //{
        //    int index = grdIkandiadminCommit_sales.Rows.Count - 1;
        //    for (int i = grdIkandiadminCommit_sales.Rows.Count - 1; i > 0; i--)
        //    {
        //        GridViewRow row = grdIkandiadminCommit_sales.Rows[i];
        //        GridViewRow previousRow = grdIkandiadminCommit_sales.Rows[index - 1];

        //        Label lblClient = (Label)row.FindControl("lblClient");
        //        Label lblPreviousClient = (Label)previousRow.FindControl("lblClient");

        //        if (lblClient.Text == lblPreviousClient.Text)
        //        {
        //            if (previousRow.Cells[0].RowSpan == 0)
        //            {
        //                if (row.Cells[0].RowSpan == 0)
        //                {
        //                    previousRow.Cells[0].RowSpan = 2;
        //                }
        //                else
        //                {
        //                    previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
        //                }
        //                row.Cells[0].Visible = false;
        //            }
        //        }
        //        index = index - 1;
        //    }
        //}

        protected void ddl_SelectIndexChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);

            ChkIsAll.Checked = false;
            BindChildDept(Convert.ToInt16(ddlDeptID.SelectedValue));
            ChkIsAll.Checked = true;
            CheckDefualt(ChkIsAll.Checked);
            Bindgrd(ReturnDeptID());
            switch (hdntab.Value)
            {
                case "maindiv":
                    maindiv.Style.Add("display", "block");
                    maindiv.Visible = true;
                    break;
                case "Main2":
                    Main2.Visible = true;
                    Main2.Style.Add("display", "block");
                    break;
                default:
                    goto case "maindiv";
            }

        }

        protected void ddl_SelectIndexChanged1(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            ChkBoxall1.Checked = false;
            BindChildDeptTracker(Convert.ToInt32(DropDownList1.SelectedValue));

            ChkBoxall1.Checked = true;
            CheckDefualtTracker(ChkBoxall1.Checked);
            BindTrackerGrid(ReturnDeptIDTracker());

            switch (hdntab.Value)
            {
                case "maindiv":

                    maindiv.Visible = true;
                    maindiv.Style.Add("display", "block");
                    // Main2.Style.Add("display", "none");
                    //  Main2.Visible = false;
                    break;
                case "Main2":


                    Main2.Visible = true;
                    // maindiv.Style.Add("display", "none");
                    Main2.Style.Add("display", "block");
                    //  maindiv.Visible = false;
                    break;
                default:
                    goto case "maindiv";
            }


        }

        // added by shubhendu
        protected void grdSampleTracker_(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HtmlImage htmlimg = e.Row.FindControl("refimg") as HtmlImage;
                string src = htmlimg.Src;
                if (src == "/Uploads/Style/thumb-")
                {
                    htmlimg.Style.Add("display", "none");
                }
                else
                {
                    htmlimg.Style.Add("display", "block");
                }
                ImageButton imgbtn = (e.Row.FindControl("ImgbtnRemarks")) as ImageButton;
                if (Session["DomainName"] != null)
                {
                    string DomainNameN = "";
                    DomainNameN = Convert.ToString(Session["DomainName"]);

                    if (DomainNameN != "@boutique.in")
                    {
                        imgbtn.Enabled = false;
                    }
                    Label lblSketchRecvDate = e.Row.FindControl("lblSketchRecvDate") as Label;
                    if (lblSketchRecvDate.Text != "")
                    {

                        lblSketchRecvDate.Text = Convert.ToDateTime(lblSketchRecvDate.Text).ToString("dd MMM yyyy");
                    }
                }
            }
        }
        //end
    }
}