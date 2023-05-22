using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL.CmtAdmin;
using System.Data;
using iKandi.Common.Entities;
using iKandi.BLL;

namespace iKandi.Web.UserControls.Forms
{
    public partial class frmCMTAdmin : BaseUserControl
    {
        decimal ActualSalary;
        decimal costPerDay;
        decimal costPerHour;
        decimal WorkingDays;
        decimal LabourBaseSalary;
        decimal PFESI;
        decimal DiwaliGift;
        decimal Gratuity;
        decimal WorkPerMonth;

        AdminController objadmincontroller = new AdminController();
        CmtAdminController obj_CmtAdmin = new CmtAdminController();
        iKandi.Common.Entities.CMTAdmin Pro_Cmt = new iKandi.Common.Entities.CMTAdmin();
        //added by abhishek on 27/8/2015
        //public void bindOtCmtValue()
        //{
        //    //DataTable cmt_dt = new DataTable();
        //    //DataTable Financial_dt = new DataTable();
        //    //DataTable ProductionCost_dt = new DataTable();
        //    //DataTable OBPerPicesCost_dt = new DataTable();
        //    //cmt_dt = obj_CmtAdmin.getOtCMTdetails();
        //    //Financial_dt = obj_CmtAdmin.Financial_dt();
        //    //ProductionCost_dt = obj_CmtAdmin.ProductionCost_dt();
        //    //OBPerPicesCost_dt = obj_CmtAdmin.OBCost_dt();


        //    if (cmt_dt.Rows.Count > 0)
        //    {
        //        txtot1.Text = cmt_dt.Rows[0]["OT1"].ToString();
        //        txtot2.Text = cmt_dt.Rows[0]["OT2"].ToString();
        //        txtot3.Text = cmt_dt.Rows[0]["OT3"].ToString();
        //        txtot4.Text = cmt_dt.Rows[0]["OT4"].ToString();
        //    }
        //    if (Financial_dt.Rows.Count > 0)
        //    {
        //        ddlFromMonth.SelectedValue = Financial_dt.Rows[0]["StartFinancialFromMonth"].ToString();
        //        ddlToMonth.SelectedValue = Financial_dt.Rows[0]["StartFinancialToMonth"].ToString();

        //    }
        //    if (ProductionCost_dt.Rows.Count > 0)
        //    {
        //        txtStiching.Text = ProductionCost_dt.Rows[0]["StichingPerOBCost"].ToString();
        //        txtFinishing.Text = ProductionCost_dt.Rows[0]["FinishingPerOBCost"].ToString();

        //    }
        //    if (OBPerPicesCost_dt.Rows.Count > 0)
        //    {
        //        txtCuttingCost.Text = OBPerPicesCost_dt.Rows[0]["CuttingCostPer_Pieces"].ToString();
        //        txtOverHeadCost.Text = OBPerPicesCost_dt.Rows[0]["FactoryOverheadPer_Pieces"].ToString();
        //        txtOBPerCost.Text = OBPerPicesCost_dt.Rows[0]["PlanEffciency"].ToString();
        //        txtFinishingCost.Text = OBPerPicesCost_dt.Rows[0]["FinishingCostPer_Pieces"].ToString();
        //    }

        //}
        //End abhishek on 27/8/2015

        //added by abhishek on 26/10/2015
        //public void bindOtCmtValue_barriedays()
        //{
        //    DataTable cmt_dt_barriedays = new DataTable();
        //    cmt_dt_barriedays = obj_CmtAdmin.getOtCMTdetails_barrieday();
        //    if (cmt_dt_barriedays.Rows.Count > 0)
        //    {
        //        txtbih.Text = cmt_dt_barriedays.Rows[0]["BIHDays"].ToString();

        //        txtBarrierDaysSlot1Max.Text = cmt_dt_barriedays.Rows[0]["Barrier_Days_Slot_1_Max"].ToString();
        //        txtbarrierdaysCalculate.Text = cmt_dt_barriedays.Rows[0]["Barrier_Days_Slot_1_Values"].ToString();
        //        txtBarrierDaysSlot2Min.Text = cmt_dt_barriedays.Rows[0]["Barrier_Days_Slot_2_Min"].ToString();
        //        txtBarrierDaysSlot2Max.Text = cmt_dt_barriedays.Rows[0]["Barrier_Days_Slot_2_Max"].ToString();
        //        txtbarriedaycalu2.Text = cmt_dt_barriedays.Rows[0]["Barrier_Days_Slot_2_Values"].ToString();
        //        txtBarrierDaysSlot3Min.Text = cmt_dt_barriedays.Rows[0]["Barrier_Days_Slot_3_Min"].ToString();
        //        txtbarriedaycal3.Text = cmt_dt_barriedays.Rows[0]["Barrier_Days_Slot_3_Values"].ToString();
        //    }

        //}
        //End abhishek on 26/10/2015
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindText();
                BindTargetDays();
                BindAchievmentLabels();
                BarrierDaysBAL();
                int UserID = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID);
                hdnUId.Value = UserID.ToString();
                BindGridViewCuttingWs();
                BindGridViewOrderQty();
            }
            //added by abhishek on 27/8/2015
            //bindOtCmtValue();
            //End abhishek on 27/8/2015

            //added by abhishek on 26/10/2015
            //bindOtCmtValue_barriedays();
            //End abhishek on 26/10/2015
        }

        public void BindGridViewCuttingWs()
        {
            DataSet ds = new DataSet();
            ds = objadmincontroller.GetStyleCodeInterval();
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            grdStyleCodeInterval.DataSource = dt;
            grdStyleCodeInterval.DataBind();
        }

        public void BindGridViewOrderQty()
        {
            DataSet ds = new DataSet();
            ds = objadmincontroller.GetOrderQuantity();
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            grdorderquantity.DataSource = dt;
            grdorderquantity.DataBind();
        }

        protected void grdStyleCodeInterval_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("EmptyInsert"))
            {
                TextBox txt_Empty_fromQty = grdStyleCodeInterval.Controls[0].Controls[0].FindControl("txt_Empty_fromQty") as TextBox;
                TextBox txt_Empty_toQty = grdStyleCodeInterval.Controls[0].Controls[0].FindControl("txt_Empty_toQty") as TextBox;

                var fromQty = txt_Empty_fromQty.Text.Trim();
                var toQty = txt_Empty_toQty.Text.Trim();

                if (fromQty == "")
                {
                    string message = "Please enter From Qty Value!";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                    return;
                }
                if (toQty == "")
                {
                    string message = "Please enter To Qty Value!";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                    return;
                }
                else
                {
                    if (Convert.ToInt32(toQty) <= Convert.ToInt32(fromQty))
                    {
                        string message = "To Qty Value is Not Less than from Qty!";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                        return;
                    }
                }
                int result = objadmincontroller.Insert_Delete_StyleCodeInterval(0, fromQty, toQty, 3);
                //if (result > 0)
                //{
                //    //string message = "Your details has been saved successfully.";
                //    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                //}

                BindGridViewCuttingWs();
            }

            if (e.CommandName.Equals("Insert"))
            {
                TextBox Foo_FromQty = (TextBox)grdStyleCodeInterval.FooterRow.FindControl("foo_txtfromQty") as TextBox;
                TextBox Foo_ToQty = (TextBox)grdStyleCodeInterval.FooterRow.FindControl("Foo_txttoQty") as TextBox;

                var fromQty = Foo_FromQty.Text.Trim();
                var toQty = Foo_ToQty.Text.Trim();

                if (fromQty == "")
                {
                    string message = "Please enter From Qty Value!";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                    return;
                }
                if (toQty == "")
                {
                    string message = "Please enter To Qty Value!";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                    return;
                }
                else
                {
                    if (Convert.ToInt32(toQty) <= Convert.ToInt32(fromQty))
                    {
                        string message = "To Qty Value is Not Less than from value!";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                        return;
                    }
                }
                int result = objadmincontroller.Insert_Delete_StyleCodeInterval(0, fromQty, toQty, 3);
                if (result > 0)
                {
                    //string message = "Your details has been saved successfully.";
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                }
                else
                {
                    string message = "Duplicate record found!";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                }

                BindGridViewCuttingWs();

            }

            if (e.CommandName.Equals("Delete"))
            {
                GridViewRow row = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                int index = row.RowIndex;
                HiddenField hdnRowID = (HiddenField)grdStyleCodeInterval.Rows[index].FindControl("hdnRowID") as HiddenField;
                int result = objadmincontroller.Insert_Delete_StyleCodeInterval(Convert.ToInt32(hdnRowID.Value), "", "", 2);
                if (result > 0)
                {
                    string message = "Your details has been Deleted successfully.";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                }
                BindGridViewCuttingWs();
            }
        }

        protected void Add_data(object sender, EventArgs e)
        {

        }
        protected void grdStyleCodeInterval_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void DeleteAllData(object sender, EventArgs e)
        {
            try
            {
                int result = objadmincontroller.Insert_Delete_StyleCodeInterval(0, "", "", 4);
                if (result > 0)
                {
                    string message = "Your details has been Deleted successfully.";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                }
                BindGridViewCuttingWs();
            }
            catch { }
        }

       
        public void BindText()
        {
            DataTable dtCmt = new DataTable();
            dtCmt = obj_CmtAdmin.GetCmt();
            DataTable Financial_dt = new DataTable();
            Financial_dt = obj_CmtAdmin.Financial_dt();

            decimal MCost = Convert.ToDecimal(dtCmt.Rows[0]["AvlMinCost"].ToString());
            decimal Hour = Convert.ToDecimal(dtCmt.Rows[0]["hrs"].ToString());
            decimal Barrier = Convert.ToDecimal(dtCmt.Rows[0]["barrierDays"].ToString());

            decimal ProdAvlibleCost = Convert.ToDecimal(dtCmt.Rows[0]["ProdAvailMin"].ToString());

            decimal Proction_Hour = Convert.ToDecimal(dtCmt.Rows[0]["WorkingHrs"].ToString());

            hdnCMT.Value = dtCmt.Rows[0]["CmtID"].ToString();

            txtAvilMinCost.Text = Math.Round(MCost, 2).ToString();
            txtHour.Text = Math.Round(Hour, 2).ToString();
            txtBarrierDays.Text = Math.Round(Barrier, 2).ToString();
            txtpro_availble_mincost.Text = Math.Round(ProdAvlibleCost, 2).ToString();
            txtproductionhrs.Text = Math.Round(Proction_Hour, 2).ToString();

            txtot1.Text = dtCmt.Rows[0]["OT1"].ToString();
            txtot2.Text = dtCmt.Rows[0]["OT2"].ToString();
            txtot3.Text = dtCmt.Rows[0]["OT3"].ToString();
            txtot4.Text = dtCmt.Rows[0]["OT4"].ToString();

            txtStiching.Text = dtCmt.Rows[0]["StichingPerOBCost"].ToString();
            txtFinishing.Text = dtCmt.Rows[0]["FinishingPerOBCost"].ToString();

            txtCuttingCost.Text = dtCmt.Rows[0]["CuttingCostPer_Pieces"].ToString();
            txtOverHeadCost.Text = dtCmt.Rows[0]["FactoryOverheadPer_Pieces"].ToString();
            txtOBPerCost.Text = dtCmt.Rows[0]["PlanEffciency"].ToString();
            txtFinishingCost.Text = dtCmt.Rows[0]["FinishingCostPer_Pieces"].ToString();
            txtFabric.Text = dtCmt.Rows[0]["Fabric_Quality_Barrier_Rate"].ToString();
            txtAccesories.Text = dtCmt.Rows[0]["Accesories_Quality_Barrier_Rate"].ToString();

            //new code 07 feb 2020 start            
            txtLabourBaseSalary.Text = dtCmt.Rows[0]["LabourBaseSalary"].ToString();

            LabourBaseSalary = Convert.ToDecimal(txtLabourBaseSalary.Text);            
            txtLabourBaseSalary.Text = Math.Round(LabourBaseSalary).ToString("#,##0");
            
            txtPFEsi.Text = dtCmt.Rows[0]["PFESI"].ToString();
            PFESI = Convert.ToDecimal(txtPFEsi.Text);

            txtGovtBonus.Text = dtCmt.Rows[0]["DiwaliGift"].ToString();
            DiwaliGift = Convert.ToDecimal(txtGovtBonus.Text);

            txtGraduatity.Text = dtCmt.Rows[0]["Gratuity"].ToString();
            Gratuity = Convert.ToDecimal(txtGraduatity.Text);
          
            txtActualWorkingDays.Text = dtCmt.Rows[0]["ActualWorkingDays"].ToString();
            WorkingDays = Convert.ToDecimal(dtCmt.Rows[0]["ActualWorkingDays"].ToString())/12;
            txtWorkPerMonth.Text = Math.Round(WorkingDays).ToString();
            WorkPerMonth = Convert.ToDecimal(txtWorkPerMonth.Text);  
          
            txtIGST.Text = dtCmt.Rows[0]["IGST"].ToString();
            txtCGST.Text = dtCmt.Rows[0]["CGST"].ToString();
            txtSGST.Text = dtCmt.Rows[0]["SGST"].ToString();
            txtCMTOH.Text = dtCmt.Rows[0]["SlotOverHead"].ToString();

            if (txtLabourBaseSalary.Text != "" && txtPFEsi.Text != "" && txtGovtBonus.Text != "" && txtGraduatity.Text!="")
            {
                LabourBaseSalary = Convert.ToDecimal(txtLabourBaseSalary.Text);
                PFESI = Convert.ToDecimal(txtPFEsi.Text);
                DiwaliGift = Convert.ToDecimal(txtGovtBonus.Text);
                Gratuity = Convert.ToDecimal(txtGraduatity.Text);                
                ActualSalary = LabourBaseSalary + (((PFESI + DiwaliGift + Gratuity) * LabourBaseSalary) / 100);

                txtActualSalary.Text = Math.Round(ActualSalary).ToString("#,##0");

                
                //string formatted = string.Format(CultureInfo.InvariantCulture, "{0:N0}", integerValue);
            }

            if (txtWorkPerMonth.Text != "" && txtActualSalary.Text !="")
            {
                costPerDay = ActualSalary / WorkingDays;
                txtCostPerDay.Text = Math.Round(costPerDay).ToString();
                
            }

            if (txtCostPerDay.Text != "")
            {
                costPerHour = costPerDay / 8;
                txtCostPerHour.Text = Math.Round(costPerHour).ToString();
            }

            //new code 07 feb 2020 end

            ddlFromMonth.SelectedValue = Financial_dt.Rows[0]["StartFinancialFromMonth"].ToString();
            ddlToMonth.SelectedValue = Financial_dt.Rows[0]["StartFinancialToMonth"].ToString();

            chkSundayWorking.Checked = dtCmt.Rows[0]["IsSundayWorking"] == DBNull.Value ? false : Convert.ToBoolean(dtCmt.Rows[0]["IsSundayWorking"]);
        }

        public void BindTargetDays()
        {
            DataTable dtTargetDays = new DataTable();
            dtTargetDays = obj_CmtAdmin.GetTargetDays();
            grdTargetDays.DataSource = dtTargetDays;
            grdTargetDays.DataBind();
        }

        public void BarrierDaysBAL()
        {
            DataTable dtBarrierDays = new DataTable();
            dtBarrierDays = obj_CmtAdmin.BarrierDaysBAL();
            grdBarrierDays.DataSource = dtBarrierDays;
            grdBarrierDays.DataBind();
        }

        public void BindAchievmentLabels()
        {
            DataTable dtAchievmentLabels = new DataTable();
            dtAchievmentLabels = obj_CmtAdmin.GetAchievmentLabels();
            grdAchiev.DataSource = dtAchievmentLabels;
            grdAchiev.DataBind();
        }

    //this code added by bharat on 25-july
        protected void grdorderquantity_RowDatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                headerRow1.Attributes.Add("class", "header1");
                headerRow2.Attributes.Add("class", "header1");

                TableCell HeaderCell = new TableCell();
                //Adding the Row at the 0th position (first row) in the Grid
                HeaderCell = new TableCell();
                HeaderCell.Text = "Sr. No.";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 40;
                HeaderCell.RowSpan = 2;
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Order Quantity";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 100;
                HeaderCell.ColumnSpan = 2;
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Min";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                HeaderCell.Attributes.Add("Class", "headerfontsize");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Max";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                HeaderCell.Attributes.Add("Class", "headerfontsize");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Allowed Extra";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 80;
                HeaderCell.RowSpan = 2;
                headerRow1.Cells.Add(HeaderCell);

                grdorderquantity.Controls[0].Controls.AddAt(0, headerRow2);
                grdorderquantity.Controls[0].Controls.AddAt(0, headerRow1);
               
            }
        }

        //end
        protected void grdTargetDays_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                Pro_Cmt.CreatedBy = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID);
                Pro_Cmt.ModifyBy = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID);

                if (e.CommandName == "Insert")
                {
                    TextBox txtTDays = grdTargetDays.FooterRow.FindControl("txtTDaysFooter") as TextBox;
                    TextBox txtTDayEff = grdTargetDays.FooterRow.FindControl("txtTDayEffFooter") as TextBox;
                    TextBox txtCostingTDayEffFooter = grdTargetDays.FooterRow.FindControl("txtCostingTDayEffFooter") as TextBox;

                    Pro_Cmt.Day = Convert.ToInt32(txtTDays.Text.Trim());
                    //Pro_Cmt.TargetDayEff = Convert.ToDecimal(txtTDayEff.Text.Trim());

                    string str = txtTDayEff.Text.Trim();
                    string strCosting = txtCostingTDayEffFooter.Text.Trim();

                    double Num;
                    double NumCosting;
                    bool isNum = double.TryParse(str, out Num);
                    bool isNumCosting = double.TryParse(strCosting, out NumCosting);

                    if ((!isNum) && (!isNumCosting))
                    {
                        ShowAlert("Please Enter Target Days");
                        return;
                    }

                    decimal TDayEff = Convert.ToDecimal(txtTDayEff.Text.Trim());
                    decimal TDayEffCosting = Convert.ToDecimal(txtCostingTDayEffFooter.Text.Trim());
                    Pro_Cmt.TargetDayEff = Math.Round(TDayEff, 2);
                    Pro_Cmt.TargetDayCostingEff = TDayEffCosting;

                    int Result = obj_CmtAdmin.InsertUpdateCMTEff(Pro_Cmt);
                    if (Result > 0)
                    {
                        ShowAlert("Data has been saved successfully!");
                    }

                    else
                    {
                        ShowAlert("Data has been not saved successfully!");
                    }
                    BindTargetDays();
                }
                if (e.CommandName == "addnew")
                {
                    Table tblGrdviewApplet = (Table)grdTargetDays.Controls[0];
                    GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];
                    TextBox txtDays = (TextBox)rows.FindControl("txtDaysEmpty") as TextBox;
                    TextBox txtTDayEff = (TextBox)rows.FindControl("txtTDayEffEmpty") as TextBox;
                    Pro_Cmt.Day = Convert.ToInt32(txtDays.Text.Trim());
                    //Pro_Cmt.TargetDayEff = Convert.ToDecimal(txtTDayEff.Text.Trim());

                    string str = txtTDayEff.Text.Trim();
                    double Num;
                    bool isNum = double.TryParse(str, out Num);
                    if (!isNum)
                    {
                        ShowAlert("Please Enter Target Days");
                        return;
                    }


                    decimal TDayEff = Convert.ToDecimal(txtTDayEff.Text.Trim());
                    Pro_Cmt.TargetDayEff = Math.Round(TDayEff, 2);

                    int Result = obj_CmtAdmin.InsertUpdateCMTEff(Pro_Cmt);
                    if (Result > 0)
                    {
                        ShowAlert("Data has been saved successfully!");
                    }

                    else
                    {
                        ShowAlert("Data has been not saved successfully!");
                    }
                    BindTargetDays();
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }


        #region "Method For show Alert Message"
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        #endregion

        protected void grdTargetDays_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow Rows = grdTargetDays.Rows[e.RowIndex];
                HiddenField hdnCurrancyId = Rows.FindControl("hdnTargetEffID") as HiddenField;
                TextBox txtDays = Rows.FindControl("txtDays") as TextBox;
                TextBox txtTDayEff = Rows.FindControl("txtTDayEff") as TextBox;
                TextBox txtCostingDayEff = Rows.FindControl("txtCostingDayEff") as TextBox;


                HiddenField hdnTargetEffID = Rows.FindControl("hdnTargetEffID") as HiddenField;
                Pro_Cmt.Day = Convert.ToInt32(txtDays.Text.Trim());
                //Pro_Cmt.TargetDayEff = Convert.ToDecimal(txtTDayEff.Text.Trim());

                string str = txtTDayEff.Text.Trim();
                string str1 = txtCostingDayEff.Text.Trim();
                double Num;
                double Num1;
                bool isNum = double.TryParse(str, out Num);
                bool isNum1 = double.TryParse(str, out Num1);
                if ((!isNum) && (!isNum1))
                {
                    ShowAlert("Please Enter Target Days");
                    return;
                }



                decimal TDayEff = Convert.ToDecimal(txtTDayEff.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtTDayEff.Text.Trim()));
                decimal TDayCostingEff = Convert.ToDecimal(txtCostingDayEff.Text.Trim()==""?0: Convert.ToDecimal(txtCostingDayEff.Text.Trim()));
                Pro_Cmt.TargetDayEff = Math.Round(TDayEff, 2);
                Pro_Cmt.TargetDayCostingEff = Math.Round(TDayCostingEff, 2);



                Pro_Cmt.TargetEffID = Convert.ToInt32(hdnTargetEffID.Value);

                Pro_Cmt.CreatedBy = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID);
                Pro_Cmt.ModifyBy = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID);

                int Result = obj_CmtAdmin.InsertUpdateCMTEff(Pro_Cmt);
                if (Result > 0)
                {
                    ShowAlert("Data has been saved successfully!");
                }
                else
                {
                    ShowAlert("Data has been not saved successfully!");
                }
                grdTargetDays.EditIndex = -1;
                BindTargetDays();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        protected void grdTargetDays_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdTargetDays.EditIndex = e.NewEditIndex;
            GridViewRow Rows = grdTargetDays.Rows[e.NewEditIndex];
            TextBox txtDays = Rows.FindControl("txtDays") as TextBox;
            TextBox txtTDayEff = Rows.FindControl("txtTDayEff") as TextBox;
            TextBox txtCostingDayEff = Rows.FindControl("txtCostingDayEff") as TextBox;

            BindTargetDays();
        }

        protected void grdTargetDays_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdTargetDays.EditIndex = -1;
            BindTargetDays();
        }

        protected void grdTargetDays_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTargetDays.PageIndex = e.NewPageIndex;
            grdTargetDays.EditIndex = -1;
            BindTargetDays();
        }

        protected void grdAchiev_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                Pro_Cmt.CreatedBy = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID);
                Pro_Cmt.ModifyBy = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID);
                if (e.CommandName == "Insert")
                {
                    TextBox txtAchievement = grdAchiev.FooterRow.FindControl("txtAchivementlabelsFooter") as TextBox;
                    //Pro_Cmt.Achievement = Convert.ToDecimal(txtAchievement.Text.Trim());
                    string str = txtAchievement.Text.Trim();
                    double Num;
                    bool isNum = double.TryParse(str, out Num);
                    if (!isNum)
                    {
                        ShowAlert("Please Enter Valid Achievement");
                        return;
                    }



                    decimal achiev = Convert.ToDecimal(txtAchievement.Text.Trim());
                    Pro_Cmt.Achievement = Math.Round(achiev, 2);
                    if (Pro_Cmt.Achievement > Convert.ToDecimal(100.00))
                    {
                        ShowAlert("Achievement Label can not be greater than 100.");
                        return;
                    }
                    int Result = obj_CmtAdmin.InsertUpdateCMTEAchievement(Pro_Cmt);
                    if (Result > 0)
                    {
                        ShowAlert("Data has been saved successfully!");
                    }

                    else
                    {
                        ShowAlert("Data has been not saved successfully!");
                    }
                    BindAchievmentLabels();
                }
                if (e.CommandName == "addnew")
                {
                    Table tblGrdviewApplet = (Table)grdAchiev.Controls[0];
                    GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];
                    TextBox txtAchievement = (TextBox)rows.FindControl("txtAchievementEmpty") as TextBox;
                    //Pro_Cmt.Achievement = Convert.ToDecimal(txtAchievement.Text.Trim());

                    string str = txtAchievement.Text.Trim();
                    double Num;
                    bool isNum = double.TryParse(str, out Num);
                    if (!isNum)
                    {
                        ShowAlert("Please Enter Valid Achievement");
                        return;
                    }


                    decimal achiev = Convert.ToDecimal(txtAchievement.Text.Trim());
                    Pro_Cmt.Achievement = Math.Round(achiev, 2);
                    if (Pro_Cmt.Achievement > Convert.ToDecimal(100.00))
                    {
                        ShowAlert("Achievement Label can not be greater than 100.");
                        return;
                    }
                    int Result = obj_CmtAdmin.InsertUpdateCMTEAchievement(Pro_Cmt);
                    if (Result > 0)
                    {
                        ShowAlert("Save Successfully");
                    }

                    else
                    {
                        ShowAlert("Not Save Successfully");
                    }
                    BindAchievmentLabels();
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        protected void grdAchiev_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdAchiev.EditIndex = e.NewEditIndex;
            GridViewRow Rows = grdAchiev.Rows[e.NewEditIndex];
            TextBox txtAchivementlabels = Rows.FindControl("txtAchivementlabels") as TextBox;

            BindAchievmentLabels();
        }

        protected void grdAchiev_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow Rows = grdAchiev.Rows[e.RowIndex];
                HiddenField hdnCurrancyId = Rows.FindControl("hdnTargetEffID") as HiddenField;
                TextBox txtAchivementlabels = Rows.FindControl("txtAchivementlabels") as TextBox;

                HiddenField hdnTargetEffID = Rows.FindControl("hdnAchievementlabelsID") as HiddenField;
                //Pro_Cmt.Achievement = Convert.ToDecimal(txtAchivementlabels.Text.Trim());

                string str = txtAchivementlabels.Text.Trim();
                double Num;
                bool isNum = double.TryParse(str, out Num);
                if (!isNum)
                {
                    ShowAlert("Please Enter Valid Achievement");
                    return;
                }

                decimal achiev = Convert.ToDecimal(txtAchivementlabels.Text.Trim());
                Pro_Cmt.AchievementlabelsID = Convert.ToInt32(hdnTargetEffID.Value);
                Pro_Cmt.Achievement = Math.Round(achiev, 2);

                if (Pro_Cmt.Achievement > Convert.ToDecimal(100.00))
                {
                    ShowAlert("Achievement Label can not be greater than 100.");
                    return;
                }

                Pro_Cmt.CreatedBy = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID);
                Pro_Cmt.ModifyBy = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID);

                int Result = obj_CmtAdmin.InsertUpdateCMTEAchievement(Pro_Cmt);
                if (Result > 0)
                {
                    ShowAlert("Data has been saved successfully!");
                }
                else
                {
                    ShowAlert("Data has been not saved successfully!");
                }
                grdAchiev.EditIndex = -1;
                BindAchievmentLabels();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        protected void grdAchiev_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdAchiev.PageIndex = e.NewPageIndex;
            grdAchiev.EditIndex = -1;
            BindAchievmentLabels();
        }

        protected void grdAchiev_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdAchiev.EditIndex = -1;
            BindAchievmentLabels();
        }

        protected void grdBarrierDays_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void grdBarrierDays_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdBarrierDays.EditIndex = e.NewEditIndex;
            GridViewRow Rows = grdBarrierDays.Rows[e.NewEditIndex];
            TextBox txtStartMin = Rows.FindControl("txtStartMin") as TextBox;
            TextBox txtEndMin = Rows.FindControl("txtEndMin") as TextBox;
            TextBox txtBarrier = Rows.FindControl("txtBarrier") as TextBox;
            BarrierDaysBAL();
        }

        protected void grdBarrierDays_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow Rows = grdBarrierDays.Rows[e.RowIndex];
                HiddenField hdnCurrancyId = Rows.FindControl("hdnTargetEffID") as HiddenField;
                TextBox txtStartMin = Rows.FindControl("txtStartMin") as TextBox;
                TextBox txtEndMin = Rows.FindControl("txtEndMin") as TextBox;
                TextBox txtBarrier = Rows.FindControl("txtBarrier") as TextBox;
                HiddenField hdnBarrierId = Rows.FindControl("hdnBarrierId") as HiddenField;

                //string str = txtTDayEff.Text.Trim();
                //double Num;
                //bool isNum = double.TryParse(str, out Num);
                //if (!isNum)
                //{
                //    ShowAlert("Please Enter Target Days");
                //    return;
                //}
                Pro_Cmt.BarrierId = Convert.ToInt32(hdnBarrierId.Value);
                Pro_Cmt.StartMin = Convert.ToDecimal(txtStartMin.Text.Trim());
                Pro_Cmt.EndMin = Convert.ToDecimal(txtEndMin.Text.Trim());
                Pro_Cmt.Barrier = Convert.ToInt32(txtBarrier.Text);

                int Result = obj_CmtAdmin.UpdateBarrierDays(Pro_Cmt);
                if (Result > 0)
                {
                    ShowAlert("Data has been saved successfully!");
                }
                else
                {
                    ShowAlert("Data has been not saved successfully!");
                }
                grdBarrierDays.EditIndex = -1;
                BarrierDaysBAL();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        protected void grdBarrierDays_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdBarrierDays_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdBarrierDays.EditIndex = -1;
            BarrierDaysBAL();
        }






    }
}