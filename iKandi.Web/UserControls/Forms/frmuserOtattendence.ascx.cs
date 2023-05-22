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
    public partial class frmuserOtattendence : System.Web.UI.UserControl
    {
        //private string defalutDate = string.Empty;
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
        int TotalManPower = 0;
        int TotalBudget = 0;
        int TotalConsummed = 0;
        string StaffName = "";
        
     

        protected void Page_Load(object sender, EventArgs e)
        {
            dtproudtion = objadmin.GetProductionHouse();
            productionvalue = objadmin.GetmanpowerValueWithoutid();
            if (!Page.IsPostBack)
            {

                BindGrid();
                hdnLoginUserId.Value = ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID.ToString();
                grdotAtte.Visible = false;
                divHead.Visible = false;
                if (string.IsNullOrEmpty(Date))
                {
                    //DateTime times = DateTime.Today.AddDays(-1);
                    //string SelectDay = times.DayOfWeek.ToString();
                    //if (SelectDay == "Sunday")
                    //{
                    //  txtDate1.Text = times.AddDays(-1).ToString("dd-MM-yyyy");
                    //}
                    //else
                    //{
                    //  txtDate1.Text = times.ToString("dd-MM-yyyy");
                    //}                   
                    AttandanceDate = objadmin.GetAttandanceDate();
                    txtDate1.Text = Convert.ToDateTime(AttandanceDate).ToString("dd-MM-yyyy");
                    txtDate1.Attributes.Add("readonly", "readonly");
                }
                else
                {
                    txtDate1.Text = Date;
                    txtDate1.Attributes.Add("readonly", "readonly");
                }
            }
        }
        //Added By Ashish
        private TableCell GetHeaerCell()
        {
            TableCell HeaderCell = new TableCell();
           // HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589C");
           // HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
           // HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#151515");
            HeaderCell.CssClass = "TopTh";           

            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.BorderWidth = 1;
            return HeaderCell;
        }

        

        protected void grdotAtte_RowCreated1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.Header)
                return;

            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(2, 2, DataControlRowType.Header, DataControlRowState.Insert);


            TableCell HeaderCell = GetHeaerCell();


            HeaderCell = GetHeaerCell();
            
            HeaderCell.Text = "Staff Dept.";
            HeaderCell.ColumnSpan = 1;
            HeaderCell.Width = 130;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = GetHeaerCell();
            HeaderCell.Text = "Factory";
            HeaderCell.ColumnSpan = 1;
            HeaderCell.Width = 250;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = GetHeaerCell();
            HeaderCell.Text = "C 47";
            HeaderCell.ColumnSpan = 2;
            
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = GetHeaerCell();
            HeaderCell.Text = "C 45-46";
            HeaderCell.ColumnSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = GetHeaerCell();
            HeaderCell.Text = "B 45";
            HeaderCell.ColumnSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = GetHeaerCell();
            HeaderCell.Text = "BIPL";
            HeaderCell.ColumnSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);


            HeaderGrid.Controls[0].Controls.AddAt(0, HeaderGridRow);
            HeaderGridRow = new GridViewRow(1, 2, DataControlRowType.Header, DataControlRowState.Insert);
            HeaderGrid.Controls[0].Controls.AddAt(1, HeaderGridRow);
        }

        //END
        protected void BindGrid()
        {
            DataSet dsBindGrid = new DataSet();
            dsBindGrid = objadmin.GetFactorySubHeader(FactoryWorkId, Edit,"");
            grdotAtte.DataSource = dsBindGrid.Tables[1];
            grdotAtte.DataBind();

            DataTable dtGlobalValue = new DataTable();
            string retdate = "";
            int OTs = Convert.ToInt32(ddl_Ot.SelectedValue);
             
            if (txtDate1.Text != "")
            {
                retdate = restundate(txtDate1.Text.Trim());
                //dtGlobalValue = objadmin.GetAttendanceGlobalBudget(OTs, Convert.ToDateTime(retdate));
                dtGlobalValue = objadmin.GetAttendanceGlobalBudget(OTs, retdate);
            }

            if (dtGlobalValue.Rows.Count > 0)
            {
                int IsBudgetFound = Convert.ToInt32(dtGlobalValue.Rows[0]["IsBudgetFound"].ToString());
                if (IsBudgetFound != 0)
                {
                    lblGlobTotalBudget.Text = dtGlobalValue.Rows[0]["TotalBudget"].ToString() + " " + "Hrs";
                    lblGlobTotalBudgetCMT.Text = "(" + dtGlobalValue.Rows[0]["TotalBudCost"].ToString() + " " + "CR)";

                    lblBudgetConsummed.Text = dtGlobalValue.Rows[0]["Consummed"].ToString() + " " + "Hrs";
                    lblGlobTotalConsummedCMT.Text = "(" + dtGlobalValue.Rows[0]["TotalConsummedCost"].ToString() + " " + "CR)";

                    lblPerDayBudget.Text = dtGlobalValue.Rows[0]["TotalBudPerDay"].ToString() + " " + "Hrs";
                    lblPerDayBudgetCMT.Text = "(" + dtGlobalValue.Rows[0]["TotalBudPerDayCost"].ToString() + " " + "L)";

                    lblPerDayConsummed.Text = dtGlobalValue.Rows[0]["AvgPerDay"].ToString() + " " + "Hrs";
                    lblPerDayConsummedCMT.Text = "(" + dtGlobalValue.Rows[0]["AvgPerDayCost"].ToString() + " " + "L)";
                }
                else
                {
                    ShowAlert("Budget not Found On Selected Date");
                    lblGlobTotalBudget.Text = "";
                    lblGlobTotalBudgetCMT.Text = "";
                    lblBudgetConsummed.Text = "";
                    lblGlobTotalConsummedCMT.Text = "";
                    lblPerDayBudget.Text = "";
                    lblPerDayBudgetCMT.Text = "";
                    lblPerDayConsummed.Text = "";
                    lblPerDayConsummedCMT.Text = "";
                    return;
                }
            }
        }

        public static DataTable GetTable()
        {
            DataTable table = new DataTable();
            //table.Columns.Add("Budget", typeof(string));
            //table.Columns.Add("Consummed", typeof(string));

            // Here we add five DataRows.
            table.Rows.Add("1,000", "5000");
            return table;
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


        protected void grdotAtte_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            HiddenField hdnFactoryWorkSpaceId = (HiddenField)e.Row.FindControl("hdnFactoryWorkSpaceId");
            TextBox lblManPower2 = (TextBox)e.Row.FindControl("lblManPower2");
            Label lblHours1 = (Label)e.Row.FindControl("lblHours1");
            Label lblBudget1 = (Label)e.Row.FindControl("lblBudget1");            
            Label lblConsummed1 = (Label)e.Row.FindControl("lblConsummed1");

            TextBox lblManPower3 = (TextBox)e.Row.FindControl("lblManPower3");
            Label lblHours2 = (Label)e.Row.FindControl("lblHours2");
            Label lblBudget2 = (Label)e.Row.FindControl("lblBudget2");
            Label lblConsummed2 = (Label)e.Row.FindControl("lblConsummed2");

            TextBox lblManPower4 = (TextBox)e.Row.FindControl("lblManPower4");
            Label lblHours3 = (Label)e.Row.FindControl("lblHours3");
            Label lblBudget3 = (Label)e.Row.FindControl("lblBudget3");
            Label lblConsummed3 = (Label)e.Row.FindControl("lblConsummed3");

            Label lblManPower5 = (Label)e.Row.FindControl("lblManPower5");
            Label lblHours4 = (Label)e.Row.FindControl("lblHours4");
            Label lblBudget4 = (Label)e.Row.FindControl("lblBudget4");
            Label lblConsummed4 = (Label)e.Row.FindControl("lblConsummed4");


            dtUnitType = objadmin.GetFactorySubHeader(FactoryWorkId, Edit,"");
            int UnitCount = dtUnitType.Tables[0].Rows.Count;


            for (int i = 0; i < UnitCount; i++)
            {
                string Name = dtUnitType.Tables[0].Rows[i]["Column1"].ToString();
                int Column2 = Convert.ToInt32(dtUnitType.Tables[0].Rows[i]["Column2"]);
                int FactoryUnitId = Convert.ToInt32(dtUnitType.Tables[0].Rows[i]["FactoryUnitId"]);
                if (Column2 == 1)
                {
                    grdotAtte.HeaderRow.Cells[i + 2].Text = "</BR>" + "<Table cellpadding='0' cellspacing='0' style='border-right:0px solid black;border-Top:0px solid black;border-bottom:1px solid gray' width='100%'><tr height=30%><td style='border-right:0px solid black;  width:50%;' height='100%' class='thaligntable'><label class='Manpowerlabel'>" + Name + "</label></td></tr></Table> ";

                }
                else 
                {
                    //grdotAtte.HeaderRow.Cells[i + 2].Text = "</BR>" + Name + "<Table cellpadding='0' cellspacing='0' Border='1' width='100%' style='background-color:#39589C; color:#FFFFFF'><tr><td style='border-right:0px solid black;  width:50%;' height='100%'>Total Budget</td><td>Total Consumed</td></tr></Table> ";
                    grdotAtte.HeaderRow.Cells[i + 2].Text = "</BR>" + Name + "<div  class='botto-head' height='100%' align='left'>Total Budget (Total Consumed)</div>";

                }


                DataTable dtSetValues = new DataTable();
                //DateTime retdate;
                int hdnWorkSpaceId = 0;
                int OTs = Convert.ToInt32(ddl_Ot.SelectedValue);
                if (txtDate1.Text != "")
                {

                    //retdate = DateHelper.ParseDate(txtDate1.Text).Value;
                    string HeaderDate = restundate(txtDate1.Text);
                    DateTime date = Convert.ToDateTime(HeaderDate);
                    string sdate = date.ToString("dd-MM-yyyy");

                    if (hdnFactoryWorkSpaceId != null)
                        hdnWorkSpaceId = Convert.ToInt32(hdnFactoryWorkSpaceId.Value);

                    dtSetValues = objadmin.GetManPowerCountByUnitId(hdnWorkSpaceId, FactoryUnitId, sdate, OTs);

                }
                if (dtSetValues.Rows.Count > 0)
                {
                    if (FactoryUnitId == 3)
                    {
                        if (lblManPower2 != null)
                        {
                            txtWorkinghours.Text = "";//((dtSetValues.Rows[0]["Workinghrs"] == DBNull.Value) ? 0 : (dtSetValues.Rows[0]["Workinghrs"])).ToString();

                            lblManPower2.Text = ((dtSetValues.Rows[0]["WorkerCount"] == DBNull.Value) ? 0 : (dtSetValues.Rows[0]["WorkerCount"])).ToString();                            
                            lblBudget1.Text = ((dtSetValues.Rows[0]["TotalBudget"] == DBNull.Value) ? 0 : (dtSetValues.Rows[0]["TotalBudget"])).ToString();
                            string Consummed1 =((dtSetValues.Rows[0]["Consummed"] == DBNull.Value) ? 0 : (dtSetValues.Rows[0]["Consummed"])).ToString() ;

                            if (Consummed1 != "0")
                            lblConsummed1.Text = "(" + ((dtSetValues.Rows[0]["Consummed"] == DBNull.Value) ? "" : (dtSetValues.Rows[0]["Consummed"])).ToString() + ")";
                            if(dtSetValues.Rows[0]["Workinghrs"] != DBNull.Value) 
                            {
                                lblHours1.Text =  "(" + (dtSetValues.Rows[0]["Workinghrs"]).ToString() + ")";
                            }
                            else
                            {
                            lblHours1.Text =  "" ;
                            }

                            TotalManPower = TotalManPower + Convert.ToInt32(lblManPower2.Text);
                            TotalBudget = TotalBudget + Convert.ToInt32(lblBudget1.Text);
                            TotalConsummed = TotalConsummed + Convert.ToInt32(Consummed1);
                        }
                    }
                    if (FactoryUnitId == 11)
                    {
                        if (lblManPower2 != null)
                        {

                            lblManPower3.Text = ((dtSetValues.Rows[0]["WorkerCount"] == DBNull.Value) ? 0 : (dtSetValues.Rows[0]["WorkerCount"])).ToString();                            
                            lblBudget2.Text = ((dtSetValues.Rows[0]["TotalBudget"] == DBNull.Value) ? 0 : (dtSetValues.Rows[0]["TotalBudget"])).ToString();
                            string Consummed2 = ((dtSetValues.Rows[0]["Consummed"] == DBNull.Value) ? 0 : (dtSetValues.Rows[0]["Consummed"])).ToString();

                            if (Consummed2 != "0")
                            lblConsummed2.Text = "(" + ((dtSetValues.Rows[0]["Consummed"] == DBNull.Value) ? "" : (dtSetValues.Rows[0]["Consummed"])).ToString() + ")";

                            if (dtSetValues.Rows[0]["Workinghrs"] != DBNull.Value)
                            {
                                lblHours2.Text = "(" + (dtSetValues.Rows[0]["Workinghrs"]).ToString() + ")";
                            }
                            else
                            {
                                lblHours2.Text = "";
                            }

                           
                            TotalManPower = TotalManPower + Convert.ToInt32(lblManPower3.Text);
                            TotalBudget = TotalBudget + Convert.ToInt32(lblBudget2.Text);
                            TotalConsummed = TotalConsummed + Convert.ToInt32(Consummed2);
                        }
                    }
                    if (FactoryUnitId == 12)
                    {
                        if (lblManPower2 != null)
                        {

                            lblManPower4.Text = ((dtSetValues.Rows[0]["WorkerCount"] == DBNull.Value) ? 0 : (dtSetValues.Rows[0]["WorkerCount"])).ToString();
                            lblBudget3.Text = ((dtSetValues.Rows[0]["TotalBudget"] == DBNull.Value) ? 0 : (dtSetValues.Rows[0]["TotalBudget"])).ToString();
                            string Consummed3 = ((dtSetValues.Rows[0]["Consummed"] == DBNull.Value) ? 0 : (dtSetValues.Rows[0]["Consummed"])).ToString();


                            if (Consummed3 != "0")
                            lblConsummed3.Text = "(" + ((dtSetValues.Rows[0]["Consummed"] == DBNull.Value) ? "" : (dtSetValues.Rows[0]["Consummed"])).ToString() + ")";

                            if (dtSetValues.Rows[0]["Workinghrs"] != DBNull.Value)
                            {
                                lblHours3.Text = "(" + (dtSetValues.Rows[0]["Workinghrs"]).ToString() + ")";
                            }
                            else
                            {
                                lblHours3.Text = "";
                            }

                            TotalManPower = TotalManPower + Convert.ToInt32(lblManPower4.Text);
                            TotalBudget = TotalBudget + Convert.ToInt32(lblBudget3.Text);
                            TotalConsummed = TotalConsummed + Convert.ToInt32(Consummed3);
                        }

                    }
                }
            }

            TotalManPower = TotalManPower / 2;
            if (TotalManPower>0)
            lblManPower5.Text = TotalManPower.ToString();

            TotalBudget = TotalBudget / 2;
            //if (TotalBudget > 0)
            lblBudget4.Text = TotalBudget.ToString();

            TotalConsummed = TotalConsummed / 2;
            if (TotalConsummed > 0)
            lblConsummed4.Text = "(" + TotalConsummed.ToString() + ")";


            lblManPower2.Text = (lblManPower2.Text == "0") ? "" : lblManPower2.Text;            
            lblConsummed1.Text = (lblConsummed1.Text == "0") ? "" : lblConsummed1.Text;
            if (lblConsummed1.Text == "")
            {
                lblBudget1.Text = (lblBudget1.Text == "0") ? "" : lblBudget1.Text;
            }

            lblManPower3.Text = (lblManPower3.Text == "0") ? "" : lblManPower3.Text;           
            lblConsummed2.Text = (lblConsummed2.Text == "0") ? "" : lblConsummed2.Text;
            if (lblConsummed2.Text == "")
            {
                lblBudget2.Text = (lblBudget2.Text == "0") ? "" : lblBudget2.Text;
            }

            lblManPower4.Text = (lblManPower4.Text == "0") ? "" : lblManPower4.Text;           
            lblConsummed3.Text = (lblConsummed3.Text == "0") ? "" : lblConsummed3.Text;
            if (lblConsummed3.Text == "")
            {
                lblBudget3.Text = (lblBudget3.Text == "0") ? "" : lblBudget3.Text;
            }

            lblManPower5.Text = (lblManPower5.Text == "0") ? "" : lblManPower5.Text;            
            lblConsummed4.Text = (lblConsummed4.Text == "0") ? "" : lblConsummed4.Text;
            if (lblConsummed4.Text == "")
            {
                lblBudget4.Text = (lblBudget4.Text == "0") ? "" : lblBudget4.Text;
            }

            TotalManPower = 0;
            TotalBudget = 0;
            TotalConsummed = 0;
            
            string Count = "0";
            Label lblStaffDept = (Label)e.Row.FindControl("lblStaffDept");
            if (lblStaffDept != null)
            {
                if (StaffName != lblStaffDept.Text)
                {
                    StaffName = lblStaffDept.Text;

                    dtUnitType = objadmin.GetFactorySubHeader(FactoryWorkId, Edit, lblStaffDept.Text);
                    Count = dtUnitType.Tables[2].Rows[0]["Staff"].ToString();


                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        int Index = 0;
                        if (Index % Convert.ToInt32(Count) == 0)
                        {
                            if (Edit != 1)
                            {
                                e.Row.Cells[0].Attributes.Add("rowspan", Count);
                            }
                            else
                            {
                                lblStaffDept.CssClass.Remove(0);
                                lblStaffDept.CssClass = "rotate2";
                            }
                          
                        }
                    }
                }
                else
                {
                    e.Row.Cells[0].Visible = false;
                }

            }

        }
        protected void ddl_Ot_SelectedIndexChanged(object sender, EventArgs e)
        {
            //added by abhishek on 26/8/2015
            string SelectedOT = hdnSelectedValue.Value;
            ddl_Ot.SelectedValue = SelectedOT;
            //end by abhishek 

           

        }

        protected void txtDate1_TextChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        #region "METHOD FOR SHOW ALERT"
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        #endregion

        protected void txtDate1_TextChanged1(object sender, EventArgs e)
        {
            //if(ddl_Ot.SelectedValue!="-1")
            //ddl_Ot.SelectedValue = "-1";

            //if (txtDate1.Text != "")
            //{
            //    string retdate = restundate(txtDate1.Text.Trim());
            //    DateTime enterdate = Convert.ToDateTime(retdate);
            //    string user_enterdate = enterdate.ToString("dd MMM yy (ddd)");

            //    lblMAinDay.Text = user_enterdate;
            //}
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            string SelectedOT = hdnSelectedValue.Value;
            ddl_Ot.SelectedValue = SelectedOT;
            if (txtDate1.Text != "")
            {
                string retdate = restundate(txtDate1.Text.Trim());
                DateTime enterdate = Convert.ToDateTime(retdate);
                string user_enterdate = enterdate.ToString("dd-MM-yyyy");
                string dateToday = DateTime.Today.ToString("dd-MM-yyyy");
                string yesterday_day = DateTime.Now.AddDays(-1).ToString("dd-MM-yyyy");
                string day = DateTime.Now.DayOfWeek.ToString();
                string SelectDay = enterdate.DayOfWeek.ToString();

                string HeaderDate = restundate(txtDate1.Text.Trim());
                DateTime date = Convert.ToDateTime(HeaderDate);
                lblMAinDay.Text = date.ToString("dd MMM yy (ddd)");

                if (SelectDay == "Sunday")
                {
                    txtDate1.Text = DateTime.Now.AddDays(-1).ToString("dd-MM-yyyy");
                    ShowAlert("Selected Date Is Sunday! Please Select another Date");
                    ddl_Ot.SelectedValue = "-1";
                    return;
                }
                if (ddl_Ot.SelectedValue != "-1")
                {
                    grdotAtte.Visible = true;
                    divHead.Visible = true;
                    BindGrid();
                    //if (user_enterdate == dateToday || user_enterdate == yesterday_day || SelectDay == "Saturday")
                    //{
                    //    grdotAtte.Visible = true;
                    //    divHead.Visible = true;
                    //    BindGrid();
                    //}
                    //else
                    //{
                    //    ShowAlert("You can select only today or yesterday");
                    //    ddl_Ot.SelectedValue = "-1";
                    //    grdotAtte.Visible = false;
                    //    divHead.Visible = false;
                    //    return;
                    //}
                }
                else
                {
                    ddl_Ot.SelectedValue = "-1";
                    grdotAtte.Visible = false;
                    divHead.Visible = false;
                }


            }
            else
            {
                if (ddl_Ot.SelectedValue != "-1")
                {
                    ShowAlert("Please Select Date");
                    ddl_Ot.SelectedValue = "-1";
                    grdotAtte.Visible = false;
                    divHead.Visible = true;
                    return;
                }
            }
        }
    }
}