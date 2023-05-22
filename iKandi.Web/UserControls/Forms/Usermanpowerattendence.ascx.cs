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
using System.Globalization;

namespace iKandi.Web.UserControls.Forms
{
    public partial class Usermanpowerattendence : System.Web.UI.UserControl
    {

        public string UserId
        {
            get;
            set;
        }
        public string Date
        {
            get;
            set;

        }
        public int OTs
        {
            get;
            set;

        }
        public int FactoryWorkId
        {
            get;
            set;

        }

        public int Edit
        {
            get;
            set;
        }
        public string AttandanceDate
        {
            get;
            set;
        }

        AdminController objadmin = new AdminController();
        DataTable dtproudtion = new DataTable();
        DataTable dtmanpower = new DataTable();
        DataTable dtfrokfroceid = new DataTable();
        DataTable productionvalue = new DataTable();

        DataSet dtUnitType = new DataSet();
        int BiplValue = 0;
       
        string StaffName = "";
       

        //public void Bindfactory()
        //{
        //    DataTable dt = objadmin.Getfactoryworkforce();//here
        //    grdmanpowerattendence.DataSource = dt;
        //    grdmanpowerattendence.DataBind();
        //}


        protected void Page_Load(object sender, EventArgs e)        {
            //if (DateTime.Today.AddDays(-1).DayOfWeek.ToString().Contains("Sunday"))            
            //    lblcurrentdate.Text = DateTime.Today.AddDays(-2).ToString("dd MMM yy (ddd)");           
            //else
            //    lblcurrentdate.Text = DateTime.Today.AddDays(-1).ToString("dd MMM yy (ddd)");

            AttandanceDate = objadmin.GetAttandanceDate();
            hdnAttandanceDate.Value = AttandanceDate;

            this.UserId = ApplicationHelper.LoggedInUser.UserData.UserID.ToString();
            dtproudtion = objadmin.GetProductionHouse();
            productionvalue = objadmin.GetmanpowerValueWithoutid();
            if (!Page.IsPostBack)
            {
                hdnIsEdit.Value = Edit.ToString();
                hdnEditDate.Value = Date;                
                lblcurrentdate.Text = Convert.ToDateTime(AttandanceDate).ToString("dd MMM yy (ddd)");

                //string todayDate = "";
                //if (DateTime.Today.AddDays(-1).DayOfWeek.ToString().Contains("Sunday"))    
                //todayDate = DateTime.Today.AddDays(-2).ToString("yyyy-MM-dd");
                //else
                //    todayDate = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
                //todayDate = objadmin.GetAttandanceDate();

                dtUnitType = objadmin.GetFactoryUnitType(FactoryWorkId, OTs, AttandanceDate, Edit, "");
                if (dtUnitType.Tables[1].Rows.Count > 0)
                {
                    for (int i = 1; i < dtUnitType.Tables[1].Rows.Count + 1; i++)
                    {
                        BoundField boundField = new BoundField();
                        boundField.HeaderText = "";
                        boundField.ItemStyle.CssClass = "tdgrid";
                        grdmanpowerattendence.Columns.Add(boundField);
                    }
                }

            }
            BindGrid();


        }

        protected void BindGrid()
        {
            DataSet dsBindGrid = new DataSet();
            string todayDate = "";
            //if (DateTime.Today.AddDays(-1).DayOfWeek.ToString().Contains("Sunday"))    
            //todayDate = DateTime.Today.AddDays(-2).ToString("yyyy-MM-dd");
            //else
            //    todayDate = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
            todayDate = hdnAttandanceDate.Value;
            dsBindGrid = objadmin.GetFactoryUnitType(FactoryWorkId, OTs, AttandanceDate, Edit, "");
            grdmanpowerattendence.DataSource = dsBindGrid.Tables[0];
            grdmanpowerattendence.DataBind();
        }
        public string restundate(string datetofarse)
        {
            string date = string.Empty;
            string user_todate = datetofarse;
            if (user_todate.IndexOf("/") != -1)
            {
                string[] str_2 = user_todate.Split('/');
                string _dd = str_2[0];
                string mm = str_2[1];
                string yy = str_2[2];
                date = str_2[2] + "-" + str_2[1] + "-" + str_2[0];

            }
            else
            {
                string[] str_2 = user_todate.Split('-');
                string _dd = str_2[0];
                string mm = str_2[1];
                string yy = str_2[2];
                date = str_2[2] + "-" + str_2[1] + "-" + str_2[0];
            }

            return date;

        }


        protected void grdmanpowerattendence_RowDataBound(object sender, GridViewRowEventArgs e)
        {



            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            HiddenField hdnFactoryWorkSpaceId = (HiddenField)e.Row.FindControl("hdnFactoryWorkSpaceId");
            Label lblFactory = (Label)e.Row.FindControl("lblFactory");
            string todayDate = "";
            todayDate = hdnAttandanceDate.Value;
            //if (DateTime.Today.AddDays(-1).DayOfWeek.ToString().Contains("Sunday"))    
            //todayDate = DateTime.Today.AddDays(-2).ToString("yyyy-MM-dd");
            //else
            //    todayDate = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");

            dtUnitType = objadmin.GetFactoryUnitType(FactoryWorkId, OTs, todayDate, Edit,"");

            int UnitCount = dtUnitType.Tables[1].Rows.Count;

            int RowIndex = e.Row.RowIndex;
            lblFactory.Attributes.Add("class", "Factorycls" + RowIndex);


            if (UnitCount > 0)
            {
                for (int i = 0; i < UnitCount; i++)
                {
                    string UnitName = dtUnitType.Tables[1].Rows[i]["UnitName"].ToString();
                    int UnitId = Convert.ToInt32(dtUnitType.Tables[1].Rows[i]["Id"]);
                    grdmanpowerattendence.HeaderRow.Cells[i + 2].Text = UnitName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lbl" + i;
                    lblName.Text = UnitName;
                    lblName.Width = 70;
                    
                    grdmanpowerattendence.HeaderRow.Style.Add("width", "250px");
                    grdmanpowerattendence.HeaderRow.Style.Add("class", "topMenu2");
                    grdmanpowerattendence.HeaderRow.Style.Add("text-align", "center");
                    grdmanpowerattendence.HeaderRow.Cells[i + 2].Controls.Add(lblName);

                    DataTable dtWorkerCount = new DataTable();
                    int FactoryWorkSpaceId = 0;
                    if (hdnFactoryWorkSpaceId.Value != "")
                        FactoryWorkSpaceId = Convert.ToInt32(hdnFactoryWorkSpaceId.Value);
                    if (UnitId == 11)
                    {

                    }
                    if (UnitId == 12)
                    {

                    }
                    if (Edit == 1)
                    {
                        if (FactoryWorkSpaceId == FactoryWorkId)
                        {
                            FactoryWorkSpaceId = FactoryWorkId;
                            string strDate = restundate(Date);
                            dtWorkerCount = objadmin.DailyManpowerAttandence(UnitId, FactoryWorkSpaceId, OTs, strDate);
                        }
                    }
                    else
                    {
                        string OtDate = "";
                        OtDate = hdnAttandanceDate.Value;
                        //if (DateTime.Today.AddDays(-1).DayOfWeek.ToString().Contains("Sunday"))    
                        //    OtDate = DateTime.Today.AddDays(-2).ToString("yyyy-MM-dd");
                        //else
                        //    OtDate = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");

                        dtWorkerCount = objadmin.DailyManpowerAttandence(UnitId, FactoryWorkSpaceId, -1, OtDate);
                    }


                    //DateTime OtDate = System.DateTime.Now;
                    //dtWorkerCount = objadmin.DailyManpowerAttandence(UnitId, FactoryWorkSpaceId, -1, OtDate);


                    int WorkerCount = 0;
                    if (dtWorkerCount.Rows.Count > 0)
                    {

                        WorkerCount = ((dtWorkerCount.Rows[0]["WorkerCount"] == DBNull.Value) ? 0 : Convert.ToInt32(dtWorkerCount.Rows[0]["WorkerCount"]));
                    }

                    BiplValue = BiplValue + Convert.ToInt32(WorkerCount.ToString());

                    if (UnitId == -1)
                    {
                        Label txtBipl = new Label();
                        txtBipl.EnableViewState = true;
                        txtBipl.Enabled = true;
                        txtBipl.ID = "txtUnit" + "_" + i + "_" + UnitId;
                        if (BiplValue != 0)
                        {
                            txtBipl.Text = BiplValue.ToString();
                        }
                        else
                        {
                            txtBipl.Text = "";
                        }
                        txtBipl.Width = 50;
                        txtBipl.CssClass = "BIPLcls" +"_"+ RowIndex;
                        e.Row.Cells[i + 2].Controls.Add(txtBipl);

                    }
                    else
                    {

                        TextBox txtUnit = new TextBox();
                        txtUnit.EnableViewState = true;
                        txtUnit.Enabled = true;
                        txtUnit.ID = "txtUnit" + "_" + i + "_" + UnitId;

                        if (WorkerCount == 0)
                        {
                            txtUnit.Text = "";
                        }
                        else
                        {
                            txtUnit.Text = WorkerCount.ToString();
                        }
                        txtUnit.Width = 50;
                        txtUnit.CssClass = "Unitcls" + UnitId+"_"+ RowIndex;
                        txtUnit.MaxLength = 4;
                        txtUnit.Attributes.Add("onchange", "javascript:return SaveManpowerdetails(this)");
                        txtUnit.Attributes.Add("onblur", "numbersonly(this)");
                        e.Row.Cells[i + 2].Controls.Add(txtUnit);

                    }
                }

                BiplValue = 0;

            }


            string Count = "0";
            Label lblStaffDept = (Label)e.Row.FindControl("lblStaffDept");
            if (lblStaffDept != null)
            {
                if (StaffName != lblStaffDept.Text)
                {
                    StaffName = lblStaffDept.Text;

                    dtUnitType = objadmin.GetFactoryUnitType(FactoryWorkId, OTs, todayDate, Edit, lblStaffDept.Text);
                    Count = dtUnitType.Tables[2].Rows[0]["Staff"].ToString();

                    if (Convert.ToInt32(Count) < 6)
                    {
                      lblStaffDept.CssClass = "normal";
                    }


                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        int Index = 0;
                        if (Index % Convert.ToInt32(Count) == 0)
                        {
                            if (Edit != 1)
                            {
                                e.Row.Cells[0].Attributes.Add("rowspan", Count);
                            }
                            //else
                            //{
                            //    lblStaffDept.CssClass.Remove(0);
                            //    lblStaffDept.CssClass = "rotate2";
                            //}
                          
                        }
                       
                    }
                }
                else
                {
                    e.Row.Cells[0].Visible = false;
                }

            }
        }

        //protected void grdmanpowerattendence_RowCreated(object sender, GridViewRowEventArgs e)
        //{
        //    for (int i = grdmanpowerattendence.Rows.Count - 1; i > 0; i--)
        //    {
        //        GridViewRow row = grdmanpowerattendence.Rows[i];
        //        GridViewRow previousRow = grdmanpowerattendence.Rows[i - 1];

        //        for (int j = 0; j < row.Cells.Count - 1; j++)
        //        {
        //            Label lblStaffDept = (Label)row.Cells[j].FindControl("lblStaffDept");
        //            Label lblPreviousStaffDept = (Label)previousRow.Cells[j].FindControl("lblStaffDept");

        //            if (lblStaffDept.Text == lblPreviousStaffDept.Text)
        //            {
        //                if (previousRow.Cells[j].RowSpan == 0)
        //                {
        //                    if (row.Cells[j].RowSpan == 0)
        //                    {
        //                        previousRow.Cells[j].RowSpan += 2;
        //                    }
        //                    else
        //                    {
        //                        previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
        //                    }
        //                    row.Cells[j].Visible = false;
        //                }
        //            }
        //        }
        //    }
        //}


        //public class GridDecorator
        //{
        //    public static void MergeRows(GridView gridView)
        //    {
        //        for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        //        {
        //            GridViewRow row = gridView.Rows[rowIndex];
        //            GridViewRow previousRow = gridView.Rows[rowIndex + 1];

        //            for (int i = 0; i < row.Cells.Count; i++)
        //            {
        //                if (row.Cells[i].Text == previousRow.Cells[i].Text)
        //                {
        //                    row.Cells[i].RowSpan = previousRow.Cells[i].RowSpan < 2 ? 2 :
        //                                           previousRow.Cells[i].RowSpan + 1;
        //                    previousRow.Cells[i].Visible = false;
        //                }
        //            }
        //        }
        //    }
        //}
    }
}