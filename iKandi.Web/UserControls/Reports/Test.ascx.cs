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
using System.Collections.Generic;
using System.Text;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web.UserControls.Reports
{
    public partial class Test : System.Web.UI.UserControl
    {
        AdminController objadmin = new AdminController();
        MembershipController onjmem = new MembershipController(ApplicationHelper.LoggedInUser);
        int Count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            bindHeader();
            GridViewRow grdPoUploadPendingBreakDownrow = grdattendence.Rows[(grdattendence.Rows.Count) - 1];
        }
        protected void bindHeader()
        {

            DataSet ds = new DataSet();
            ds = objadmin.GetHeaderstaffAtten(Convert.ToInt32(Application["Hr_AttandenceSheet"]));
            if (grdattendence.Columns.Count > 0)
            {
                grdattendence.Columns.Clear();

            }

            TemplateField DepartmentName = new TemplateField();
            DepartmentName.HeaderText = "Dpt. Name";
            DepartmentName.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "DepartmentName", "DepartmentName");
            DepartmentName.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdattendence.Columns.Insert(0, DepartmentName);
            //DepartmentName.HeaderStyle.Width = 90;
            DepartmentName.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
            DepartmentName.HeaderStyle.CssClass = "w-90";

            TemplateField serilno = new TemplateField();
            serilno.HeaderText = "Sr. No";
            serilno.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "SerialNo", "SerialNo");
            grdattendence.Columns.Insert(1, serilno);
            // serilno.HeaderStyle.Width = 30;
            serilno.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
            serilno.HeaderStyle.CssClass = "w-30";


            TemplateField EmployeeName = new TemplateField();
            EmployeeName.HeaderText = "Employee Name";
            EmployeeName.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "EmployeeName", "EmployeeName");
            EmployeeName.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdattendence.Columns.Insert(2, EmployeeName);
            //EmployeeName.HeaderStyle.Width = 100;
            EmployeeName.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
            EmployeeName.HeaderStyle.CssClass = "w-100";

            TemplateField Designation = new TemplateField();
            Designation.HeaderText = "Designation";
            Designation.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "Designation", "Designation");
            Designation.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdattendence.Columns.Insert(3, Designation);
            //Designation.HeaderStyle.Width = 100;
            Designation.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
            Designation.HeaderStyle.CssClass = "w-100";

            //TemplateField Image = new TemplateField();
            //Image.HeaderText = "Img";
            //Image.ItemTemplate = new iKandi.Common.GridViewTemplate("img", "Image", "Image");
            //Image.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //grdattendence.Columns.Insert(4, Image);
            ////Image.HeaderStyle.Width = 30;
            //Image.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
            //Image.HeaderStyle.CssClass = "w-30";




            TemplateField AverageInTime = new TemplateField();
            AverageInTime.HeaderText = "Avg. In Time";
            AverageInTime.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "AverageInTime", "AverageInTime");
            AverageInTime.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdattendence.Columns.Insert(4, AverageInTime);
            // AverageInTime.HeaderStyle.Width = 50;
            AverageInTime.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
            AverageInTime.HeaderStyle.CssClass = "w-50";

            TemplateField AverageOutTime = new TemplateField();
            AverageOutTime.HeaderText = "Avg. Out Time";
            AverageOutTime.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "AverageOutTime", "AverageOutTime");
            AverageOutTime.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdattendence.Columns.Insert(5, AverageOutTime);
            // AverageOutTime.HeaderStyle.Width = 50;
            AverageOutTime.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
            AverageOutTime.HeaderStyle.CssClass = "w-50";


            TemplateField AverageHoursperday = new TemplateField();
            AverageHoursperday.HeaderText = "Avg. Hrs. per day";
            AverageHoursperday.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "AverageHoursperday", "AverageHoursperday");
            AverageHoursperday.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdattendence.Columns.Insert(6, AverageHoursperday);
            //AverageHoursperday.HeaderStyle.Width = 50;
            AverageHoursperday.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
            AverageHoursperday.HeaderStyle.CssClass = "w-50";

            TemplateField AverageHoursWeeklys = new TemplateField();
            AverageHoursWeeklys.HeaderText = "Avg. Hrs. Wkly";
            AverageHoursWeeklys.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "AverageHoursWeeklys", "AverageHoursWeeklys");
            AverageHoursWeeklys.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdattendence.Columns.Insert(7, AverageHoursWeeklys);
            AverageHoursWeeklys.HeaderStyle.Width = 50;
            AverageHoursWeeklys.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
            AverageHoursWeeklys.HeaderStyle.CssClass = "w-50";

            //TemplateField Totalleavetaken = new TemplateField();
            //Totalleavetaken.HeaderText = "Tot. leave taken";
            //Totalleavetaken.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "Totalleavetaken", "Totalleavetaken");
            //Totalleavetaken.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //grdattendence.Columns.Insert(9, Totalleavetaken);
            //// Totalleavetaken.HeaderStyle.Width = 50;
            //Totalleavetaken.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
            //Totalleavetaken.HeaderStyle.CssClass = "w-50";


            TemplateField MonthlyAveragePlannedLeave = new TemplateField();
            // MonthlyAveragePlannedLeave.HeaderText = "Monthly Average Planned Leave (3M)";
            MonthlyAveragePlannedLeave.HeaderText = "Monthly Avg (Based on last 3M)";

            MonthlyAveragePlannedLeave.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "MonthlyAveragePlannedLeaveNew", "MonthlyAveragePlannedLeaveNew");
            MonthlyAveragePlannedLeave.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdattendence.Columns.Insert(8, MonthlyAveragePlannedLeave);
            // MonthlyAveragePlannedLeave.HeaderStyle.Width = 50;
            MonthlyAveragePlannedLeave.HeaderStyle.BackColor = System.Drawing.Color.Green;
            MonthlyAveragePlannedLeave.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
            MonthlyAveragePlannedLeave.HeaderStyle.CssClass = "w-50";



            TemplateField MonthlyAverageUnPlannedLeave = new TemplateField();
            MonthlyAverageUnPlannedLeave.HeaderText = "Monthly Average Un Planned Leave (3M)";
            MonthlyAverageUnPlannedLeave.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "MonthlyAverageUnPlannedLeave", "MonthlyAverageUnPlannedLeave");
            MonthlyAverageUnPlannedLeave.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdattendence.Columns.Insert(9, MonthlyAverageUnPlannedLeave);
            //MonthlyAverageUnPlannedLeave.ShowHeader = false;
            MonthlyAverageUnPlannedLeave.HeaderStyle.Width = 1;
            MonthlyAverageUnPlannedLeave.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
            MonthlyAverageUnPlannedLeave.HeaderStyle.CssClass = "disp-none";


            TemplateField MonthlyAverageUnauthorisedAbsent = new TemplateField();
            MonthlyAverageUnauthorisedAbsent.HeaderText = "Monthly Average Unauthorised Absent (3M)";
            MonthlyAverageUnauthorisedAbsent.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "MonthlyAverageUnauthorisedAbsent", "MonthlyAverageUnauthorisedAbsent");
            MonthlyAverageUnauthorisedAbsent.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdattendence.Columns.Insert(10, MonthlyAverageUnauthorisedAbsent);
            // MonthlyAverageUnauthorisedAbsent.ShowHeader = false;
            MonthlyAverageUnauthorisedAbsent.HeaderStyle.Width = 1;
            MonthlyAverageUnauthorisedAbsent.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
            MonthlyAverageUnauthorisedAbsent.HeaderStyle.CssClass = "disp-none";

            TemplateField totalleavetaken3 = new TemplateField();
            totalleavetaken3.HeaderText = "Totalleavetaken (3M)";
            totalleavetaken3.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "totalleavetaken3", "totalleavetaken3");
            totalleavetaken3.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdattendence.Columns.Insert(11, totalleavetaken3);
            totalleavetaken3.HeaderStyle.Width = 1;
            totalleavetaken3.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
            totalleavetaken3.HeaderStyle.CssClass = "disp-none";




            Count = Convert.ToInt32(ds.Tables[1].Rows.Count) - 1;
            if (Convert.ToInt32(ds.Tables[1].Rows.Count) > 0)
            {
                for (int i = 0; i <= Count; i++)
                {
                    TemplateField Dates = new TemplateField();
                    //Dates.HeaderText = Convert.ToString(ds.Tables[1].Rows[i]["Dates"]);

                    Dates.HeaderText = String.Format("{0:d, MMM}", Convert.ToDateTime(ds.Tables[1].Rows[i]["Dates"]));
                    Dates.HeaderText = "<div style='width:100%;padding-bottom:6px;'>" + Convert.ToDateTime(ds.Tables[1].Rows[i]["Dates"]).ToString("dd MMM (ddd)") + "</div> <div style='width:100%;border-top:1px solid gray; '> <div style='width:49% !important; font-size:10px; float:left; border-right:1px solid gray;color:gray'>In <br/>Time</div> <div style='width:49% !important; font-size:10px; float:left;color:gray'>Out <br/>Time</div></div>";
                    Dates.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "Dates" + Convert.ToString(ds.Tables[1].Rows[i]["Dates"]), "Dates" + Convert.ToString(ds.Tables[1].Rows[i]["Dates"]));

                    Dates.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    grdattendence.Columns.Insert(i + 12, Dates);

                    // Dates.HeaderStyle.Width = 80;
                    Dates.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
                    Dates.HeaderStyle.CssClass = "font-10 w-80";
                    Dates.HeaderStyle.VerticalAlign = VerticalAlign.Bottom;
                }

            }
            grdattendence.DataSource = ds.Tables[0];
            grdattendence.DataBind();
        }
        // int ColCount = 0;
        public string CheckWeekoff(string UserID, DateTime attendencedate)
        {
            string result = "";
            User user = onjmem.GetUser(Convert.ToInt32(UserID));
            string[] SelectedWkOff = user.WeekOff.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            DateTime checksunday = attendencedate;
            DayOfWeek day = checksunday.DayOfWeek;
            foreach (string wk in SelectedWkOff)
            {
                //if (day.ToString().ToLower() == wk.ToLower() && day != null)
                if (day.ToString().ToLower() == wk.ToLower())
                {
                    result = "WO";
                    break;
                }
            }
            return result;
        }
        int rowno = 1;
        protected void grdattendence_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[8].Text = "<div style='width:100%'>Monthly Avg Based on last 6M</div> <div style='width:100%;border-top:1px solid gray; '> <span style='width:40px !important; display:inline-block; font-size:10px; border-right:1px solid gray;padding: 3px 0px;'>Plnd <br/> Leave</span> <span style='width:45px !important; display:inline-block; font-size:10px; border-right:1px solid gray;padding: 3px 0px;'>Un Plnd Leave</span> <span style='width:45px !important; display:inline-block; font-size:10px;border-right: 1px solid #999; padding: 3px 0px;'>Unauth Absent</span><span style='width:45px !important;display:inline-block; font-size:10px;'>Avg. Leave</span></div>";
                e.Row.Cells[8].CssClass = "fullwidthTd";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataSet ds = new DataSet();
                ds = objadmin.GetHeaderstaffAtten(Convert.ToInt32(Convert.ToInt32(Application["Hr_AttandenceSheet"])));
                DataRowView drv = (DataRowView)e.Row.DataItem;


                string Srno = e.Row.RowIndex.ToString();
                string Seqid = drv.Row.ItemArray[0] == DBNull.Value ? "" : drv.Row.ItemArray[0].ToString();
                string UserName = drv.Row.ItemArray[1] == DBNull.Value ? "" : drv.Row.ItemArray[1].ToString();
                string DesignationName = drv.Row.ItemArray[2] == DBNull.Value ? "" : drv.Row.ItemArray[2].ToString();
                //string ImagePath = drv.Row.ItemArray[3] == DBNull.Value ? "" : drv.Row.ItemArray[3].ToString();
                string DepartmentName = drv.Row.ItemArray[3] == DBNull.Value ? "" : drv.Row.ItemArray[4].ToString();
                string DepartmentID = drv.Row.ItemArray[4] == DBNull.Value ? "" : drv.Row.ItemArray[5].ToString();
                string DesignationID = drv.Row.ItemArray[5] == DBNull.Value ? "" : drv.Row.ItemArray[6].ToString();
                string UserID = drv.Row.ItemArray[6] == DBNull.Value ? "" : drv.Row.ItemArray[7].ToString();
                string countDepartmentName = drv.Row.ItemArray[7] == DBNull.Value ? "" : drv.Row.ItemArray[8].ToString();
                //string dd = drv.Row.ItemArray[11] == DBNull.Value ? "" : drv.Row.ItemArray[11].ToString();
                Label SerialNo = e.Row.FindControl("SerialNo") as Label;
                SerialNo.Text = Srno;
                SerialNo.Style.Add("color", "gray");
                //e.Row.Cells[1].Width = 30;
                e.Row.Cells[1].CssClass = "bgpartial w-30";

                HiddenField DeparmentID_s = e.Row.FindControl("DeparmentID") as HiddenField;
                HiddenField DesignationID_s = e.Row.FindControl("DesignationID") as HiddenField;
                HiddenField UserID_s = e.Row.FindControl("UserID") as HiddenField;

                Label MonthlyAveragePlannedLeaveNew = e.Row.FindControl("MonthlyAveragePlannedLeaveNew") as Label;
                Label MonthlyAverageUnPlannedLeave = e.Row.FindControl("MonthlyAverageUnPlannedLeave") as Label;
                Label MonthlyAverageUnauthorisedAbsent = e.Row.FindControl("MonthlyAverageUnauthorisedAbsent") as Label;
                MonthlyAveragePlannedLeaveNew.ForeColor = System.Drawing.Color.Black;
                MonthlyAverageUnPlannedLeave.ForeColor = System.Drawing.Color.Black;
                MonthlyAverageUnauthorisedAbsent.ForeColor = System.Drawing.Color.Black;
                //MonthlyAveragePlannedLeaveNew.Text = "123wer";


                Label DepartmentNames = e.Row.FindControl("DepartmentName") as Label;
                DepartmentNames.Text = DepartmentName;
                //e.Row.Cells[0].Width = 90;              
                //DepartmentNames.Style.Add("color", "black");
                //DepartmentNames.Style.Add("font-size", "11px");
                if (Convert.ToInt32(countDepartmentName) > 3)
                {
                    DepartmentNames.CssClass = "rotate";
                }
                else
                {
                    try
                    {
                        DepartmentNames.CssClass.Remove(0);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                        System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    }

                    DepartmentNames.CssClass = "rotate2";
                }

                e.Row.Cells[0].CssClass = "bgpartial w-90";

                Label EmployeeName = e.Row.FindControl("EmployeeName") as Label;
                EmployeeName.Text = UserName;
                // e.Row.Cells[2].Width = 100;
                EmployeeName.Style.Add("color", "black");
                EmployeeName.Style.Add("font-size", "11px");
                e.Row.Cells[2].CssClass = "bgpartial w-100";



                Label Designation = e.Row.FindControl("Designation") as Label;
                Designation.Text = DesignationName;
                //e.Row.Cells[3].Width = 100;
                Designation.Style.Add("font-size", "11px");
                e.Row.Cells[3].CssClass = "bgpartial w-100";

                //Image Image = e.Row.FindControl("Image") as Image;
                //e.Row.Cells[4].CssClass = "bgpartial previewNew w-30";
                //Image.Style.Add("width", "30px");
                //Image.Style.Add("height", "30px");
                //if (ImagePath != "")
                //{
                //    if ((System.IO.File.Exists(Constants.PHOTO_FOLDER_PATH + ImagePath)))
                //    {
                //        Image.ImageUrl = ResolveUrl("~/uploads/photo/" + ImagePath);
                //    }
                //    else
                //    {
                //        Image.Visible = false;
                //    }

                //}
                //else
                //{

                //    Image.Visible = false;


                //}
                //  Image.Attributes.Add("Class", "preview");
                Label SerialNo_s = e.Row.FindControl("SerialNo") as Label;
                SerialNo_s.Text = rowno.ToString();

                rowno = rowno + 1;



                int Count = Convert.ToInt32(ds.Tables[1].Rows.Count);
                string UserName_s = UserName;
                //  lblDtColumnCount.InnerText = Count.ToString();
                //string grdattendenceWidth = Convert.ToString(750 + (Count * 80)) + "px";
                string grdattendenceWidth = Convert.ToString(720 + (Count * 80) + 12 + Count) + "px";
                grdattendence.Style.Add("width", grdattendenceWidth);
                if (Convert.ToInt32(ds.Tables[1].Rows.Count) > 0)
                {
                    for (int iExfactory = 0; iExfactory < Count; iExfactory++)
                    {
                        //if (EmployeeName.Text == "Department Manager")
                        //{
                        //  //e.Row.Cells[0].Style.Add("height", "25px");
                        //  e.Row.Cells[iExfactory + 5].Attributes.Add("class", "NoPadding");
                        //  e.Row.Cells[iExfactory + 5].Style.Add("width", "80px");
                        //  e.Row.Cells[iExfactory + 5].Style["background-color"] = "#EBF1DE";
                        //  e.Row.Cells[iExfactory + 5].Text = "<table cellpadding='0' cellspacing='0' style='background-color: #EBF1DE;' width='100%' rules='all' frame='void'><tr><td style='background-color: #EBF1DE;height: 25px;' width='50%'>In Ti. </td><td style='background-color: #EBF1DE;height: 25px;'> Out Ti.</td></tr></table>";
                        //  //ColCount = ColCount + 1;
                        //  e.Row.Cells[Count + 10].Text = "Plnd Leave";
                        //  e.Row.Cells[Count + 10].Style.Add("font-size", "11px");
                        //  e.Row.Cells[Count + 10].Width = 50;
                        //  e.Row.Cells[Count + 11].Text = "Un Plnd Leave";
                        //  e.Row.Cells[Count + 11].Style.Add("font-size", "11px");
                        //  e.Row.Cells[Count + 11].Width = 50;
                        //  e.Row.Cells[Count + 12].Text = "Unauth Absent";
                        //  e.Row.Cells[Count + 12].Style.Add("font-size", "11px");
                        //  e.Row.Cells[Count + 12].Width = 50;


                        //}
                        //else
                        //{
                        //  if (Seqid != "-99")
                        //  {
                        //    e.Row.Cells[Count + 11].Height = 30;
                        //  }
                        //}
                        string Dates = Convert.ToString(ds.Tables[1].Rows[iExfactory]["Dates"]);
                        DateTime checksunday = Convert.ToDateTime(ds.Tables[1].Rows[iExfactory]["Dates"]);
                        e.Row.Cells[iExfactory + 12].CssClass = "font-10 w-80";
                        DayOfWeek day = checksunday.DayOfWeek;
                        //HtmlTableCell exfactorynew = e.Row.FindControl("Exfactory" + Convert.ToString(ds.Tables[1].Rows[iExfactory]["Exfactory"])) as HtmlTableCell;
                        Label exfactory = e.Row.FindControl("Dates" + Convert.ToString(ds.Tables[1].Rows[iExfactory]["Dates"])) as Label;

                        DataTable dtdata = objadmin.GetHeaderstaffAtten_Report(Convert.ToInt32(DepartmentID), Convert.ToInt32(DesignationID), Convert.ToInt32(UserID), Convert.ToDateTime(Dates)).Tables[0];
                        if (day == DayOfWeek.Sunday && exfactory != null)
                        {
                            e.Row.Cells[iExfactory + 12].Style["background-color"] = "#FFFF00";
                            if (exfactory.Text == "")
                            {
                                exfactory.Text = "WO";
                            }
                        }
                        //if (DepartmentID == "34" && DepartmentName == "IT")
                        //{
                        //    if (day == DayOfWeek.Saturday && exfactory != null)//for IT
                        //    {
                        //        e.Row.Cells[iExfactory + 13].Style["background-color"] = "#FFFF00";
                        //        exfactory.Text = "";
                        //        exfactory.Text = "WO";
                        //    }
                        //}
                        if (CheckWeekoff(UserID, Convert.ToDateTime(Dates)) != "")
                        {
                            e.Row.Cells[iExfactory + 12].Style["background-color"] = "#FFFF00";
                            exfactory.Text = "";
                            exfactory.Text = "WO";
                        }
                        if (dtdata.Rows.Count > 0)
                        {
                            if (dtdata.Rows[0]["HRRemarks"].ToString() != "")
                            {
                                e.Row.Cells[iExfactory + 12].Attributes.Add("Title", dtdata.Rows[0]["HRRemarks"].ToString());
                                e.Row.Cells[iExfactory + 12].CssClass = "font-10 tooltip w-80"; //.Attributes.Add("class", "tooltip");
                            }
                            string intime = dtdata.Rows[0]["InTime"].ToString();
                            string Outime = dtdata.Rows[0]["OutTime"].ToString();
                            string ExtraOutime = dtdata.Rows[0]["ExtraOutTime"].ToString();
                            if (dtdata.Rows[0]["InTime"].ToString() != "")
                            {
                                string strislate = ValidateLateComing(dtdata.Rows[0]["InTime"].ToString(), Convert.ToInt32(DepartmentID), Convert.ToInt32(UserID));
                                if (strislate == "RED")
                                {
                                    if (!string.IsNullOrEmpty(ExtraOutime))
                                    {
                                        exfactory.Text = "<div  style='height: 20px; padding-top:10px; width:49% !important; float:left;border-right:1px solid #7E7E7E;'><span style='color: red;'>" + intime + "</span></div><div style='width:49% !important;padding-top:10px; float:right'><span style='color:black;font-weight: bold;'>" + ExtraOutime + "</sapn></div> <div style='clear:both;'></div>";
                                    }
                                    else
                                    {
                                        exfactory.Text = "<div  style='height: 20px; padding-top:10px; width:49% !important; float:left;border-right:1px solid #7E7E7E;'><span style='color: red;'>" + intime + "</span></div><div style='width:49% !important;padding-top:10px; float:right'><span style='color:black'>" + Outime + "</sapn></div> <div style='clear:both;'></div>";
                                    }

                                    if (dtdata.Rows[0]["InTime"].ToString() == "")
                                    {
                                        exfactory.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0034");
                                    }

                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(ExtraOutime))
                                    {
                                        exfactory.Text = "<div  style='height: 20px;padding-top:10px; width:49% !important; float:left;border-right:1px solid #7E7E7E;'><span style='color:black'>" + intime + "</span></div><div style='width:49% !important;padding-top:10px; float:right'><span style='color:black;font-weight: bold;'>" + ExtraOutime + "</span></div> <div style='clear:both;'></div>";
                                    }
                                    else
                                    {
                                        exfactory.Text = "<div  style='height: 20px;padding-top:10px; width:49% !important; float:left;border-right:1px solid #7E7E7E;'><span style='color:black'>" + intime + "</span></div><div style='width:49% !important;padding-top:10px; float:right'><span style='color:black'>" + Outime + "</span></div> <div style='clear:both;'></div>";
                                    }
                                    //exfactory.Text = "<DIV style='Border:1px solid black; float:left; width:43%;height: 16px;'>" + intime + "</DIV> <div style='width:9%; float:left; text-align:center'> : </div><DIV style='Border:1px solid black; float:right; width:43%;height: 16px;'>" + Outime + "</DIV>";
                                }
                            }
                            exfactory.Style.Add("class", "w-80");

                            if (dtdata.Rows[0]["StatusID"].ToString() == "-1")
                            {
                                if (dtdata.Rows[0]["InTime"].ToString() != "")
                                {
                                    string strislates = ValidateLateComing(dtdata.Rows[0]["InTime"].ToString(), Convert.ToInt32(DepartmentID), Convert.ToInt32(UserID));
                                    if (strislates == "RED")
                                    {
                                        if (!string.IsNullOrEmpty(ExtraOutime))
                                        {
                                            exfactory.Text = "<div  style='height: 20px;padding-top:10px; width:49% !important; float:left;border-right:1px solid #7E7E7E;'><span style='color: red;'>" + intime + "</span></div><div style='padding-top:10px; width:49% !important; float:right'><span style='color:black;font-weight: bold;'>" + ExtraOutime + "</span></div> <div style='clear:both;'></div>";
                                        }
                                        else
                                        {
                                            exfactory.Text = "<div  style='height: 20px;padding-top:10px; width:49% !important; float:left;border-right:1px solid #7E7E7E;'><span style='color: red;'>" + intime + "</span></div><div style='padding-top:10px; width:49% !important; float:right'><span style='color:black'>" + Outime + "</span></div> <div style='clear:both;'></div>";

                                        }

                                        if (dtdata.Rows[0]["InTime"].ToString() == "")
                                        {
                                            exfactory.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0034");
                                        }

                                    }
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(ExtraOutime))
                                        {
                                            exfactory.Text = "<div  style='height: 20px;padding-top:10px; width:49% !important; float:left;border-right:1px solid #7E7E7E;'><span style='color:black'>" + intime + "</span></div><div style='width:49% !important;padding-top:10px; float:right'><span style='color:black;font-weight: bold;'>" + ExtraOutime + "</span></div> <div style='clear:both;'></div>";
                                        }
                                        else
                                        {
                                            exfactory.Text = "<div  style='height: 20px;padding-top:10px; width:49% !important; float:left;border-right:1px solid #7E7E7E;'><span style='color:black'>" + intime + "</span></div><div style='width:49% !important;padding-top:10px; float:right'><span style='color:black'>" + Outime + "</span></div> <div style='clear:both;'></div>";
                                        }
                                    }
                                }


                            }
                            else if (dtdata.Rows[0]["StatusID"].ToString() == "1")
                            {
                                e.Row.Cells[iExfactory + 12].Style["background-color"] = "#DDDFE4";
                            }
                            else if (dtdata.Rows[0]["StatusID"].ToString() == "2")
                            {
                                if (exfactory.Text == "0" || exfactory.Text == "")
                                {
                                    exfactory.Text = "WO";
                                }
                                e.Row.Cells[iExfactory + 12].Style["background-color"] = "#FFFF00";
                            }
                            else if (dtdata.Rows[0]["StatusID"].ToString() == "3")
                            {
                                e.Row.Cells[iExfactory + 12].Style["background-color"] = "#FFD27D";
                            }
                            else if (dtdata.Rows[0]["StatusID"].ToString() == "4")
                            {
                                e.Row.Cells[iExfactory + 12].Style["background-color"] = "#80e5a6";
                            }
                            else if (dtdata.Rows[0]["StatusID"].ToString() == "5")
                            {
                                e.Row.Cells[iExfactory + 12].Style["background-color"] = "#54C4EC";

                            }
                            else
                            {
                                //e.Row.Cells[iExfactory + 3].CssClass = "Background-red";

                            }

                            e.Row.Cells[iExfactory + 12].Style.Add("class", "w-80");

                        }
                        DataTable dtCheckHoliday = objadmin.CheckHoliday(Convert.ToDateTime(Dates));//check holiday
                        if (dtCheckHoliday.Rows.Count > 0)
                        {
                            e.Row.Cells[iExfactory + 12].Style["background-color"] = "#FFFF00";
                            exfactory.Text = "";
                            exfactory.Text = "HLD";

                        }

                    }
                }
                //----------------------End Of Loop----------------------//
                //if (UserID == "25" || UserID == "22")
                //{
                //    string s = "";
                //}
                DataSet dsleave = objadmin.GetHeaderstaffAtten_ReportMothIse(Convert.ToInt32(DepartmentID), Convert.ToInt32(DesignationID), Convert.ToInt32(UserID), Convert.ToInt32(Application["Hr_AttandenceSheet"]));
                DataTable dtdatan = dsleave.Tables[1];
                if (dsleave.Tables.Count > 0)
                {

                    string leavecount = "0";
                    if (dtdatan.Rows.Count > 0)
                    {
                        leavecount = dtdatan.Rows[0]["LeaveDays"].ToString() == "" ? "" : dtdatan.Rows[0]["LeaveDays"].ToString();
                    }
                    //Label Totalleavetaken = e.Row.FindControl("Totalleavetaken") as Label;
                    //Totalleavetaken.ForeColor = System.Drawing.Color.Black;
                    Label totalleavetaken3 = e.Row.FindControl("totalleavetaken3") as Label;
                    totalleavetaken3.ForeColor = System.Drawing.Color.Black;

                    //e.Row.Cells[5].Style.Add("width", "50px");
                    e.Row.Cells[4].CssClass = "bgpartial w-50";
                    //  e.Row.Cells[6].Style.Add("width", "50px");
                    e.Row.Cells[5].CssClass = "bgpartial w-50";
                    //  e.Row.Cells[7].Style.Add("width", "50px");
                    e.Row.Cells[6].CssClass = "bgpartial w-50";
                    //  e.Row.Cells[8].Style.Add("width", "50px");
                    e.Row.Cells[7].CssClass = "bgpartial w-50";
                    // e.Row.Cells[9].Style.Add("width", "50px");
                    e.Row.Cells[8].CssClass = "bgpartial monthlyavg";
                    e.Row.Cells[8].Style.Add("width", "47px");
                    e.Row.Cells[9].CssClass = "bgpartial monthlyavg";
                    e.Row.Cells[9].Style.Add("width", "50px");
                    e.Row.Cells[10].CssClass = "bgpartial monthlyavg";
                    e.Row.Cells[10].Style.Add("width", "49px");
                    e.Row.Cells[11].CssClass = "bgpartial monthlyavg";
                    e.Row.Cells[11].Style.Add("width", "53px");

                    //if (leavecount == "" || leavecount == "0")
                    //{
                    //    Totalleavetaken.Text = "";
                    //    //e.Row.Cells[5].Width = 50;
                    //}
                    //else
                    //{
                    //    Totalleavetaken.Text = leavecount;
                    //    // e.Row.Cells[5].Width = 50;
                    //}
                    if (leavecount == "" || leavecount == "0" || leavecount == "0.0")
                    {
                        //Totalleavetaken.Text = "";
                        totalleavetaken3.Text = "";
                        //e.Row.Cells[5].Width = 50;
                    }
                    else
                    {
                        //ToString("0.##");   
                        //Totalleavetaken.Text = Convert.ToDecimal(leavecount).ToString("G29");
                        totalleavetaken3.Text = Convert.ToDecimal(leavecount).ToString("G29");
                        //e.Row.Cells[5].Width = 50;
                    }

                }
                string IntimeAvg = "";
                if (dtdatan.Rows.Count > 0)
                {
                    IntimeAvg = dtdatan.Rows[0]["InTimeAvg"].ToString() == "" ? "" : dtdatan.Rows[0]["InTimeAvg"].ToString();
                }
                Label AverageInTime = e.Row.FindControl("AverageInTime") as Label;
                //AverageInTime.Font.Bold = true;
                if (IntimeAvg == "")
                {
                    AverageInTime.Text = "";
                    // e.Row.Cells[6].Width = 50;
                }
                else
                {
                    AverageInTime.Text = IntimeAvg;
                    //e.Row.Cells[6].Width = 50;
                }
                if (AverageInTime.Text != "")
                {
                    string strislates = ValidateLateComing(AverageInTime.Text, Convert.ToInt32(DepartmentID), Convert.ToInt32(UserID));
                    if (strislates == "RED")
                    {
                        AverageInTime.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        AverageInTime.ForeColor = System.Drawing.Color.Black;
                    }
                }
                string OuttimeAvg = "";
                if (dtdatan.Rows.Count > 0)
                {
                    OuttimeAvg = dtdatan.Rows[0]["OutTimeAvg"].ToString() == "" ? "" : dtdatan.Rows[0]["OutTimeAvg"].ToString();
                }
                Label AverageOutTime = e.Row.FindControl("AverageOutTime") as Label;
                AverageOutTime.ForeColor = System.Drawing.Color.Black;
                //AverageOutTime.Font.Bold = true;
                if (OuttimeAvg == "")
                {
                    AverageOutTime.Text = "";
                    // e.Row.Cells[7].Width = 50;
                }
                else
                {
                    AverageOutTime.Text = OuttimeAvg;
                    // e.Row.Cells[7].Width = 50;
                }
                int extratime = 0;
                if (!string.IsNullOrEmpty(AverageOutTime.Text))
                {
                    string H = AverageOutTime.Text.Split(':')[0];
                    string M = AverageOutTime.Text.Split(':')[1];
                    if (Convert.ToInt32(H) > 24)
                    {
                        extratime = Convert.ToInt32(H) - 24;
                        AverageOutTime.Text = extratime.ToString() + ":" + M.ToString();
                        AverageOutTime.ForeColor = System.Drawing.Color.Black;
                        AverageOutTime.Font.Bold = true;
                    }

                }
                string PerDayHousrAvg = "";
                Label AverageHoursperday = e.Row.FindControl("AverageHoursperday") as Label;
                AverageHoursperday.ForeColor = System.Drawing.Color.Black;
                //AverageHoursperday.Font.Bold = true;
                if (dtdatan.Rows.Count > 0)
                {
                    PerDayHousrAvg = dtdatan.Rows[0]["PerDayAvg"].ToString() == "" ? "" : dtdatan.Rows[0]["PerDayAvg"].ToString();
                }

                if (PerDayHousrAvg == "" || PerDayHousrAvg == "0")
                {
                    AverageHoursperday.Text = "";
                    // e.Row.Cells[8].Width = 50;
                }
                else
                {
                    AverageHoursperday.Text = PerDayHousrAvg;
                    //  e.Row.Cells[8].Width = 50;
                }

                string strAverageHoursWeekly = "";
                Label AverageHoursWeeklys = e.Row.FindControl("AverageHoursWeeklys") as Label;
                AverageHoursWeeklys.ForeColor = System.Drawing.Color.Black;
                //AverageHoursWeeklys.Font.Bold = true;
                if (dtdatan.Rows.Count > 0)
                {
                    strAverageHoursWeekly = dtdatan.Rows[0]["PerDayAvgWeek"].ToString() == "" ? "" : dtdatan.Rows[0]["PerDayAvgWeek"].ToString();
                }
                if (strAverageHoursWeekly == "" || strAverageHoursWeekly == "0")
                {
                    AverageHoursWeeklys.Text = "";
                    // e.Row.Cells[9].Width = 50;
                }
                else
                {
                    AverageHoursWeeklys.Text = strAverageHoursWeekly;
                    e.Row.Cells[8].Width = 50;
                }

                string PlannedLeave = "";
                if (dtdatan.Rows.Count > 0)
                {
                    PlannedLeave = dtdatan.Rows[0]["PlannedLeaveCount"].ToString() == "" ? "" : dtdatan.Rows[0]["PlannedLeaveCount"].ToString();
                }

                if (PlannedLeave == "" || PlannedLeave == "0")
                {
                    MonthlyAveragePlannedLeaveNew.Text = "";
                    e.Row.Cells[9].Width = 50;
                    //  e.Row.Cells[Count + 1].Text = "i love u";
                }
                else
                {
                    MonthlyAveragePlannedLeaveNew.Text = PlannedLeave;
                    //e.Row.Cells[10].Width = 50;
                }
                string UnPlanned = "";
                if (dtdatan.Rows.Count > 0)
                {
                    UnPlanned = dtdatan.Rows[0]["UnPlannedLeaveCount"].ToString() == "" ? "" : dtdatan.Rows[0]["UnPlannedLeaveCount"].ToString();
                }
                if (UnPlanned == "" || UnPlanned == "0")
                {
                    MonthlyAverageUnPlannedLeave.Text = "";
                    // e.Row.Cells[11].Width = 50;
                }
                else
                {
                    MonthlyAverageUnPlannedLeave.Text = UnPlanned;
                    // e.Row.Cells[Count + 1].Width = 70;
                }
                string Unauthorised = "";
                if (dtdatan.Rows.Count > 0)
                {
                    Unauthorised = dtdatan.Rows[0]["UnauthorisedLeaveCount"].ToString() == "" ? "" : dtdatan.Rows[0]["UnauthorisedLeaveCount"].ToString();
                }
                if (Unauthorised == "" || Unauthorised == "0")
                {
                    MonthlyAverageUnauthorisedAbsent.Text = "";
                    // e.Row.Cells[Count + 1].Width = 70;
                }
                else
                {
                    MonthlyAverageUnauthorisedAbsent.Text = Unauthorised;
                    // e.Row.Cells[12].Width = 50;
                }

            }
        }
        public string ValidateLateComing(string starttime, int DepartmentID, int UserID)
        {
            User user = onjmem.GetUser(Convert.ToInt32(UserID));
            double Bufferminuts = 20;
            string Result = string.Empty;
            if (DepartmentID != 34)//non IT
            {
                
                string two = starttime;
                string H = starttime.Split(':')[0];
                string M = starttime.Split(':')[1];
                string stattH = "";
                string stattM = "";
                if (H.Length == 1)
                {
                    starttime = "0" + starttime;
                    stattH = "0" + H;
                }
                else
                {
                    stattH = H;

                }
                if (M.Length == 1)
                {
                    starttime = "0" + starttime;
                    stattM = "0" + M;
                }
                else
                {
                    stattM = M;
                }
                starttime = stattH.Trim() + ":" + stattM.Trim();
                string iString = "2005-05-05 " + starttime;
                DateTime InTime = DateTime.ParseExact(iString, "yyyy-MM-dd HH:mm", null);
                // string ostring = "2005-05-05 " + "09:50";
                string ostring = "2005-05-05 " + user.Intime.Substring(0, 5);
                DateTime officetime = DateTime.ParseExact(ostring, "yyyy-MM-dd HH:mm", null);
                if (InTime > officetime.AddMinutes(Bufferminuts))
                {
                    Result = "RED";
                }
            }
            if (DepartmentID == 34)//for IT
            {
                
                string two = starttime;
                string H = starttime.Split(':')[0];
                string M = starttime.Split(':')[1];
                string stattH = "";
                string stattM = "";
                if (H.Length == 1)
                {
                    starttime = "0" + starttime;
                    stattH = "0" + H;
                }
                else
                {
                    stattH = H;

                }
                if (M.Length == 1)
                {
                    starttime = "0" + starttime;
                    stattM = "0" + M;
                }
                else
                {
                    stattM = M;
                }
                starttime = stattH.Trim() + ":" + stattM.Trim();
                string iString = "2005-05-05 " + starttime;
                DateTime InTime = DateTime.ParseExact(iString, "yyyy-MM-dd HH:mm", null);
                string ostring = "2005-05-05 " + user.Intime.Substring(0, 5);
                DateTime officetime = DateTime.ParseExact(ostring, "yyyy-MM-dd HH:mm", null);
                if (InTime > officetime.AddMinutes(Bufferminuts))
                {
                    Result = "RED";
                }
            }
            return Result;
        }


        protected void grdattendence_DataBound(object sender, EventArgs e)
        {
            for (int i = grdattendence.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdattendence.Rows[i];
                GridViewRow previousRow = grdattendence.Rows[i - 1];

                Label lblDepartmentName = (Label)row.Cells[0].FindControl("DepartmentName");
                Label lblPreviousDepartmentName = (Label)previousRow.Cells[0].FindControl("DepartmentName");

                if (lblDepartmentName.Text == lblPreviousDepartmentName.Text)
                {
                    if (previousRow.Cells[0].RowSpan == 0)
                    {
                        if (row.Cells[0].RowSpan == 0)
                        {
                            previousRow.Cells[0].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                            //lblDepartmentName.CssClass.Remove(0);
                            //lblDepartmentName.CssClass = "rotate2";
                        }
                        row.Cells[0].Visible = false;
                    }
                }
            }
        }
    }
}