using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Web.Components;
using iKandi.Common;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Linq;
using System.Text;


namespace iKandi.Web.Internal.Sales
{
    public partial class AccessoryOrdersSummaryOld : System.Web.UI.Page
    {
        AccessoryQualityController objacc = new AccessoryQualityController();
        AccessoryWorkingController objwc = new AccessoryWorkingController();
        public int orderid
        {
            get;
            set;
        }
        public int OrderTab
        {
            get;
            set;
        }
        public static int TaskStatus
        {
            get;
            set;
        }
        int iCountloop = 0;
        DataTable DtAccName = new DataTable();
        DataTable DtContract = new DataTable();
        DataTable dtCheck = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["orderid"] != null)
            {
                orderid = Convert.ToInt32(Request.QueryString["orderid"]);
            }
            hdnOrderID.Value = orderid.ToString();
            // this code added by bharat on 26-june
            if (Request.QueryString["OrderTab"] != null)
            {
                OrderTab = Convert.ToInt32(Request.QueryString["OrderTab"]);
            }
            else
            {
                OrderTab = 3;
                // grdaccsize.CssClass = "gridleft headertopfixed";
            }
            if (Request.QueryString["TaskStatus"] != null)
            {
                TaskStatus = Convert.ToInt32(Request.QueryString["TaskStatus"]);
                grdaccsize.CssClass = "gridleft headertopfixed";
            }
            else
            {
                TaskStatus = -1;
            }
            hdnorderTabClose.Value = OrderTab.ToString();

            hdnUserId.Value = ApplicationHelper.LoggedInUser.UserData.UserID.ToString();
            // end
            if (!IsPostBack)
            {
                Bindalloptiongrd();
                BindAccSizeGrd();
                CalculateColSum();

                //int GridWidth = grdaccsize.wi
            }

        }
        public void Bindalloptiongrd()
        {
            DataTable DtOrderDetails = new DataTable();
            DataSet ds = new DataSet();
            DataTable dtsizeoptioncount = new DataTable();

            ds = objacc.GetAccessoryOrderSizedeatils("1", orderid, "");

            DtOrderDetails = ds.Tables[2];
            lblacname.Text = DtOrderDetails.Rows[0]["AcName"].ToString();
            lblserialno.Text = DtOrderDetails.Rows[0]["serialno"].ToString();
            lblstylenumber.Text = DtOrderDetails.Rows[0]["stylenumber"].ToString();

            dtsizeoptioncount = ds.Tables[0];

            if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ACCESSORY_DETAIL_AVG_CHECKED))
            {
                chkboxAccountMgr.Enabled = false;
            }

        }
        public void SetData(int orderdetaildID, string sizeno, Label lblqty)
        {
            if (sizeno != "")
            {
                DataSet dsdata = objacc.GetAccessoryOrderSizedeatils("3", orderid, "", orderdetaildID, sizeno);
                if (dsdata.Tables.Count > 0)
                {
                    DataTable dt = dsdata.Tables[0];
                    if (dsdata.Tables[0].Rows.Count > 0)
                    {
                        lblqty.Text = dsdata.Tables[0].Rows[0]["Quantity"].ToString();
                    }
                }
            }
        }

        bool IsCheck, IsCutting, IsHistoryExist;
        //-------------------------------------------------------------------------------------------------------//
        public void BindAccSizeGrd()
        {
            iCountloop = 0;
            int TotalWidth = 260;
            DataSet ds = new DataSet();
            DataSet dsAccName = new DataSet();


            ds = objacc.GetAccOrderShrinkage(1, orderid);//CN  
            DtContract = ds.Tables[0];



            dsAccName = objacc.GetAccOrderShrinkage(2, orderid);//for AccName
            DtAccName = dsAccName.Tables[0];

            //added by raghvinder on 23-10-2020 start

            dtCheck = dsAccName.Tables[1];

            IsCheck = dtCheck.Rows[0]["IsApprovedAMForAccessory"].ToString() == "" ? false : Convert.ToBoolean(dtCheck.Rows[0]["IsApprovedAMForAccessory"]);

            IsCutting = dtCheck.Rows[0]["IsCutting"].ToString() == "" ? false : Convert.ToBoolean(dtCheck.Rows[0]["IsCutting"]);

            IsHistoryExist = dtCheck.Rows[0]["HistoryExist"].ToString() == "" ? false : Convert.ToBoolean(dtCheck.Rows[0]["HistoryExist"]);

            if (IsCheck == true)
            {
                chkboxAccountMgr.Checked = true;
                chkboxAccountMgr.Enabled = false;
            }

            if (IsHistoryExist == true)
            {
                ShowImgHis.Visible = true;
            }

            if (grdaccsize.Columns.Count > 0)
            {
                grdaccsize.Columns.Clear();
            }

            TemplateField Contarctno = new TemplateField();
            Contarctno.HeaderText = "Contract No.";
            Contarctno.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "Contarctno", "Contarctno");
            Contarctno.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdaccsize.Columns.Insert(0, Contarctno);
            Contarctno.HeaderStyle.CssClass = "headerCont";
            Contarctno.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");

            TemplateField CNQty = new TemplateField();
            CNQty.HeaderText = "Contract Qty";
            CNQty.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "CNQty", "CNQty");
            CNQty.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            CNQty.HeaderStyle.CssClass = "headerQty";
            grdaccsize.Columns.Insert(1, CNQty);

            CNQty.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
            //  CNQty.HeaderStyle.CssClass = "headercolor";
            int iCount = 2;
            foreach (DataRow dr in DtAccName.Rows)
            {
                TemplateField AccName = new TemplateField();
                AccName.HeaderTemplate = new iKandi.Common.GridViewTemplate("AccessoryUnit", dr["TradeName"].ToString(), "txt" + "_" + iCount, dr["AccessoryworkingdetailId"].ToString() + "_" + dr["ID"].ToString());
                //AccName.HeaderTemplate = new iKandi.Common.GridViewTemplate("AccessoryUnit", dr["TradeName"].ToString(), "txt" + "_" + iCount, dr["AccessoryworkingdetailId"].ToString() + "_" + dr["ID"].ToString());

                AccName.ItemTemplate = new iKandi.Common.GridViewTemplate("iteamlable", "shrinkage_" + iCount, "shrinkage_" + iCount, dr["AccessoryMaster_Id"].ToString());
                AccName.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                grdaccsize.Columns.Insert(iCount, AccName);

                AccName.HeaderStyle.CssClass = "headercolor";
                AccName.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");

                iCount = iCount + 1;
                TotalWidth = TotalWidth + 150;
                if (iCount < 8)
                {
                    tblHeader.Attributes.Add("class", "toptable");
                }
                if (TaskStatus == 1)
                {
                    if (iCount >= 8)
                    {
                        tblHeader.Attributes.Add("class", "toptable tableWithTask");
                        widthdiv.Attributes.Add("class", "tableWithTask");
                    }
                }
                else
                {
                    if (iCount >= 8)
                    {
                        tblHeader.Attributes.Add("class", "toptable tableWith");
                        widthdiv.Attributes.Add("class", "tableWith");
                    }
                }
            }

            iCountloop = iCountloop + DtAccName.Rows.Count;
            grdaccsize.DataSource = DtContract;
            grdaccsize.DataBind();


            GridViewRow grdtotal = grdaccsize.Rows[(grdaccsize.Rows.Count) - 1];
            grdtotal.Cells[0].Font.Bold = true;
            grdtotal.Cells[0].ForeColor = System.Drawing.Color.Black;
            grdtotal.ForeColor = System.Drawing.Color.Black;

            //grdswatches.Height = 100;

            CalculateColSum();
            tblHeader.Style.Add("width", TotalWidth.ToString() + "px");
            grdaccsize.Width = TotalWidth;

        }

        public void CalculateColSum()
        {
            int Sum = 0;
            for (int i = 2; i <= iCountloop + 1; i++)
            {
                foreach (GridViewRow row in grdaccsize.Rows)
                {
                    Label Contarctno = (Label)row.FindControl("Contarctno");
                    Label lblQty = (Label)row.FindControl("shrinkage_" + i + "3");

                    if (Contarctno.Text.ToString() != "Total")
                    {
                        if (!string.IsNullOrEmpty(lblQty.Text))
                        {
                            Sum += Convert.ToInt32(lblQty.Text.Replace(",", ""));
                        }
                    }
                    if (Contarctno.Text.ToString() == "Total")
                    {
                        lblQty.Text = Convert.ToDecimal(Sum).ToString("N0");
                        Sum = 0;
                        break;
                    }
                }
            }

        }

        int AccessoryUnit, AccessoryWorkingDetailId;

        protected void grdaccsize_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                int x = 0;
                for (int i = 2; i <= iCountloop + 1; i++)
                {
                    string Shrinkage = DtAccName.Rows[x]["Shrinkage"].ToString() == "0" ? "" : DtAccName.Rows[x]["Shrinkage"].ToString() + " %";
                    string Wastage = DtAccName.Rows[x]["Wastage"].ToString() == "0" ? "" : DtAccName.Rows[x]["Wastage"].ToString() + " %";


                    string AccessoryName = DtAccName.Rows[x]["TradeName"].ToString() == "0" ? "" : DtAccName.Rows[x]["TradeName"].ToString();
                    string AccessDetail = "<span style='text-align:center;'>" + AccessoryName + "</span>";
                    AccessDetail = AccessDetail + "</br><span class='ShrnkSpan'>Shrnk: " + Shrinkage + "</span><span class='WastSpan'>Wastg: " + Wastage + "</span>";
                    AccessDetail = AccessDetail + "</br><span class='AvgSpan'>Avg</span><span class='UnitSpan'>Unit</span>";

                    Label lbltradename = new Label();
                    lbltradename.Text = AccessDetail;
                    e.Row.Cells[i].Controls.Add(lbltradename);

                    string AccID = DtAccName.Rows[x]["AccessoryworkingdetailId"].ToString();                                      


                    TextBox txt = (TextBox)(e.Row.Cells[i].FindControl("txt_" + i + "_TextBox_" + AccID + "_" + DtAccName.Rows[x]["ID"].ToString()));

                    txt.Attributes.Add("class", "FloatValue");
                    txt.Attributes.Add("autocomplete", "off");
                    txt.MaxLength = 5;
                    txt.Text = DtAccName.Rows[x]["Number"].ToString() == "0" ? "1" : DtAccName.Rows[x]["Number"].ToString();
                    txt.Style.Add("text-align", "center");
                    txt.Style.Add("color", "blue");

                    AccessoryWorkingDetailId = Convert.ToInt32(DtAccName.Rows[x]["AccessoryworkingdetailId"]);
                    decimal avg = Convert.ToDecimal(txt.Text);
                    txt.Attributes.Add("onchange", "javascript:return calculateAvgUnit(this)");

                    int GarmentUnit = DtAccName.Rows[x]["GarmentUnit"].ToString() == "" ? -1 : Convert.ToInt32(DtAccName.Rows[x]["GarmentUnit"]);


                    DataTable dtAccessoryUnit = new DataTable();
                    string AccMasterId = DtAccName.Rows[x]["AccessoryMaster_Id"].ToString();

                    dtAccessoryUnit = objwc.Get_AccessoryUnit_ForOrder(orderid, AccessoryWorkingDetailId);

                    DropDownList ddlAccessoryUnit = (DropDownList)(e.Row.Cells[i].FindControl("txt_" + i + "_DropDown_" + AccID + "_" + DtAccName.Rows[x]["ID"].ToString()));

                    foreach (DataRow row in dtAccessoryUnit.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["AccessoryUnit"].ToString()))
                        {
                            AccessoryUnit = Convert.ToInt32(row["AccessoryUnit"].ToString());
                        }
                    }

                    ddlAccessoryUnit.DataSource = dtAccessoryUnit;
                    ddlAccessoryUnit.DataValueField = "GroupUnitID";
                    ddlAccessoryUnit.DataTextField = "UnitName";
                    ddlAccessoryUnit.DataBind();

                    if (IsCheck == true)
                    {
                        ddlAccessoryUnit.Enabled = false;
                    }
                    else
                    {
                        ddlAccessoryUnit.Enabled = true;
                    }

                    if (IsCutting == true)
                    {
                        txt.Enabled = false;
                    }
                    else
                    {
                        txt.Enabled = true;
                    }


                    if (GarmentUnit > 0)
                        ddlAccessoryUnit.SelectedValue = GarmentUnit.ToString();
                    else
                        ddlAccessoryUnit.SelectedValue = AccessoryUnit.ToString();

                    ddlAccessoryUnit.Attributes.Add("onchange", "javascript:return calculateAvgUnit(this)");


                    //added by raghvinder on 22-10-2020 end

                    if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ACCESSORY_DETAIL_AVG))
                    {
                        txt.Attributes.Add("readonly", "true");
                    }

                    x = x + 1;

                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;
                Label Contarctno = e.Row.FindControl("Contarctno") as Label;
                Label CNQty = e.Row.FindControl("CNQty") as Label;

                if (drv.Row.ItemArray[0].ToString() != "Total")
                    //Contarctno.Text = "(sh %)    (wast %) " +"<span style='color:#000'>"+ (drv.Row.ItemArray[0] == DBNull.Value ? "" : drv.Row.ItemArray[0].ToString())+"</span>";
                    Contarctno.Text = "<span style='color:#000'>" + (drv.Row.ItemArray[0] == DBNull.Value ? "" : drv.Row.ItemArray[0].ToString());
                else
                    Contarctno.Text = (drv.Row.ItemArray[0] == DBNull.Value ? "" : drv.Row.ItemArray[0].ToString());

                CNQty.Text = (drv.Row.ItemArray[2] == DBNull.Value ? "" : Convert.ToInt32(drv.Row.ItemArray[2].ToString()).ToString("N0"));
                CNQty.Font.Bold = true;
                CNQty.ForeColor = System.Drawing.Color.Black;
                Contarctno.Attributes.Add("class", "floatleft");
                HiddenField hdnOrderDetailid = new HiddenField();
                hdnOrderDetailid.ID = "hdnorderdeailid";
                hdnOrderDetailid.Value = drv.Row.ItemArray[3].ToString();
                e.Row.Cells[0].Controls.Add(hdnOrderDetailid);
                e.Row.Cells[0].Attributes.Add("class", "ContWidth");
                e.Row.Cells[1].Attributes.Add("class", "QtyWidth");
                int x = 0;
                decimal d = 0;
                for (int i = 2; i <= iCountloop + 1; i++)
                {
                    e.Row.Cells[i].Attributes.Add("class", "ContentWidth");
                    Label shrinkage = e.Row.FindControl("shrinkage_" + i + "1") as Label;
                    Label wastgae = e.Row.FindControl("shrinkage_" + i + "2") as Label;
                    Label CalculatedQty = e.Row.FindControl("shrinkage_" + i + "3") as Label;
                    HiddenField hdnaccmasterid = e.Row.FindControl("shrinkage_" + i + "4") as HiddenField;
                    Label colorprint = e.Row.FindControl("shrinkage_" + i + "5") as Label;

                    HiddenField sizeno1 = e.Row.FindControl("sizeno1") as HiddenField;
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    ds = objacc.GetAccOrderShrinkage(3, orderid, Convert.ToInt32(hdnaccmasterid.Value));
                    dt = ds.Tables[0];
                    decimal Dshrinkage = 0;
                    decimal DWastage = 0;

                    DataTable dtcolor = new DataTable();
                    dtcolor = objacc.GetPrintNo(5, Convert.ToInt32(hdnOrderDetailid.Value), Convert.ToInt32(DtAccName.Rows[x]["AccessoryworkingdetailId"].ToString()));
                    if (dtcolor.Rows.Count > 0)
                    {
                        //wastgae.Text = "(" + (dt.Rows[0]["Wastage"].ToString()) + "%)";
                        if (dt.Rows[0]["Shrinkage"].ToString() != "")
                        {
                            shrinkage.Text = "(" + (dt.Rows[0]["Shrinkage"].ToString()) + "%)";
                            Dshrinkage = Convert.ToDecimal(dt.Rows[0]["Shrinkage"].ToString());
                        }
                        else
                        {
                            shrinkage.Text = "";
                            Dshrinkage = 0;
                        }

                        if (dt.Rows[0]["wastage"].ToString() != "")
                        {
                            wastgae.Text = "(" + (dt.Rows[0]["wastage"].ToString()) + "%)" + "<hr>";
                            DWastage = Convert.ToDecimal(dt.Rows[0]["wastage"].ToString());
                        }
                        else
                        {
                            wastgae.Text = "<hr>";
                            DWastage = 0;
                        }                        
                        colorprint.Text = dtcolor.Rows[0]["Color_Print"].ToString() == "0" ? "" : dtcolor.Rows[0]["Color_Print"].ToString();
                    }
                    CalculatedQty.Attributes.Add("class", "colorblack topalingcen");
                    colorprint.Attributes.Add("class", "colorblack topalingcen");
                    shrinkage.Attributes.Add("class", "topalingshrin");
                    wastgae.Attributes.Add("class", "topalingshrin");


                    decimal ShrinkageWastage = Dshrinkage + DWastage;
                    decimal number = 1;
                    if (DtAccName.Rows[x]["Number"].ToString() != "" || DtAccName.Rows[x]["Number"].ToString().ToString() != "0")
                        number = Convert.ToDecimal(DtAccName.Rows[x]["Number"].ToString().ToString());

                    number = number <= 0 ? 1 : number;
                    decimal Multiplyer = 0;
                    decimal total = 0;                    

                    Multiplyer = Convert.ToDecimal(CNQty.Text.Replace(",", "")) * number;
                    total = Math.Round((Convert.ToDecimal(Multiplyer * 100) / (100 - ShrinkageWastage)), 0);

                    CalculatedQty.Text = total.ToString("N0") + "  ";


                    d = d + Convert.ToDecimal(CalculatedQty.Text.Replace(",", "").Trim());

                    CalculatedQty.Font.Bold = false;
                    if (drv.Row.ItemArray[0].ToString() == "Total")
                    {
                        colorprint.Text = "";
                        shrinkage.Text = "";
                        wastgae.Text = "";                      
                        CalculatedQty.Text = d.ToString("N0");
                        CalculatedQty.Font.Bold = true;
                    }
                    
                    x = x + 1;

                }
                d = 0;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            WorkflowController instance = new WorkflowController();
            AccessoryWorkingController objAccessoryController = new AccessoryWorkingController();
            OrderPlaceController objOrderPlaceController = new OrderPlaceController();

            if ((chkboxAccountMgr.Checked) && (chkboxAccountMgr.Enabled))
            {
                objAccessoryController.Save_Accessory_Average("ACC_CHECK", 0, 0, orderid, -1, true, ApplicationHelper.LoggedInUser.UserData.UserID);
            }

            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;

            iKandi.Common.OrderPlace order = new Common.OrderPlace();
            order = objOrderPlaceController.Get_order_by_OrderId_ForOrderPlace(orderid, UserId);

            List<ContractDetails> orderDetailCollection = order.ContractDetail;

            for (int itemNo = 0; itemNo < orderDetailCollection.Count; itemNo++)
            {
                int OrderDetailId = Convert.ToInt32(orderDetailCollection[itemNo].OrderDetailId);
                if (OrderDetailId > 0)
                {
                    instance.Create_CloseWorkflowPostOrder(orderid, OrderDetailId, TaskMode.Create_Accessories, ApplicationHelper.LoggedInUser.UserData.UserID);

                    if ((chkboxAccountMgr.Checked) && (chkboxAccountMgr.Enabled))
                    {
                        instance.Create_CloseWorkflowPostOrder(orderid, OrderDetailId, TaskMode.Accessory_Approved, ApplicationHelper.LoggedInUser.UserData.UserID);
                        instance.Create_CloseWorkflowPostOrder(orderid, OrderDetailId, TaskMode.Create_Accessories, ApplicationHelper.LoggedInUser.UserData.UserID);
                    }
                }
            }
            Bindalloptiongrd();
            BindAccSizeGrd();
            CalculateColSum();

        }
    }
}