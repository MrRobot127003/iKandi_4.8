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
using System.Text;
using System.Collections.Generic;
using iKandi.BLL;
using System.Text.RegularExpressions;
using System.Web.Caching;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web.Internal.Fabric
{
    public partial class PendingOrderSummary : System.Web.UI.Page
    {
        public static string CtlID;
        FabricController fabobj = new FabricController();
        QualityController Qcobj = new QualityController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            if (!Page.IsPostBack)
            {
                BindGrd();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Response.Redirect(Request.RawUrl);
            BindGrd();
        }
        public int OrderID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["OrderID"]))
                {
                    return Convert.ToInt32(Request.QueryString["OrderID"]);
                }
                return -1;
            }
        }
        public void BindGrd()
        {
            string FabricName = "";
            string printDetails = "";
            //  int OrderDetailID = -1;
            if (Request.Url.ToString().Contains("&"))
            {
                //string[] str = Request.Url.ToString().Split(new Char[] { ':', '/', '?', '=', '&' }, StringSplitOptions.RemoveEmptyEntries);
                //FabricName = str[10];
                //printDetails = str[7] + str[8];

                FabricName = Request.QueryString["TradeName"].ToString();
                printDetails = Request.QueryString["FabricDetails"].ToString();
                //  OrderDetailID = Convert.ToInt32(Request.QueryString["OrderDetailID"]);
                //  topheadermargin.Attributes.Add("class", "pending_order_heading HeaderMarginL");
            }
            //DataTable dt = fabobj.getpendingFabSummary("PENDINGORDERSUMMARY", FabricName, printDetails, OrderID, txtfabname.Text.Trim(), txtstylenumber.Text.Trim());
            DataTable dt = fabobj.getpendingFabSummary("PENDINGORDERSUMMARY", FabricName, printDetails, OrderID, txtfabname.Text.Trim());   //new code
            if (dt.Rows.Count > 0)
            {
                GrdFabric.DataSource = dt;
                GrdFabric.DataBind();
            }
            else
            {
                if (GrdFabric.DataSource == null)
                {
                    GrdFabric.DataSource = new string[] { };
                }
                GrdFabric.DataBind();
            }
            //foreach (GridViewRow row in GrdFabric.Rows)
            //{
            //    // string flag, string StagesCount, int OrderDetailID, int fabricMasterID, string ColorPrin, int Stagevalt, int FabricPending_Orders_Id
            //    QualityController Qcobj = new QualityController();
            //    string flag = "UPDATE";
            //    HiddenField hdnorderdetailid = row.FindControl("hdnorderdetailid") as HiddenField;
            //    HiddenField hdnfabmasterid = row.FindControl("hdnfabmasterid") as HiddenField;
            //    HiddenField hdnFabricPending_Orders_Id = row.FindControl("hdnFabricPending_Orders_Id") as HiddenField;
            //    DropDownList ddlStage1 = row.FindControl("ddlStage1") as DropDownList;
            //    DropDownList ddlStage2 = row.FindControl("ddlStage2") as DropDownList;
            //    Label lblcolorprint = row.FindControl("lblcolorprint") as Label;
            //    //bool result = Qcobj.PendingOrderSummaryUpdate(flag, "Stage1", Convert.ToInt32(hdnorderdetailid.Value), Convert.ToInt32(hdnfabmasterid.Value), lblcolorprint.Text, Convert.ToInt32(ddlStage1.SelectedValue), Convert.ToInt32(hdnFabricPending_Orders_Id.Value));
            //    //result = Qcobj.PendingOrderSummaryUpdate(flag, "Stage2", Convert.ToInt32(hdnorderdetailid.Value), Convert.ToInt32(hdnfabmasterid.Value), lblcolorprint.Text, Convert.ToInt32(ddlStage2.SelectedValue), Convert.ToInt32(hdnFabricPending_Orders_Id.Value));
            //}

        }
        public void MarginFabric()
        {

            //for (int i = GrdFabric.Rows.Count - 1; i > 0; i--)
            //{
            int MRowCnt = 0;
            int StyleRowCnt = 0;
            int SerialNoRowCnt = 0;
            for (int i = 1; i < GrdFabric.Rows.Count; i++)
            {
                GridViewRow row = GrdFabric.Rows[i];
                GridViewRow previousRow = GrdFabric.Rows[MRowCnt];
                Label lblFabricQuality = (Label)row.Cells[0].FindControl("lblFabricQuality");
                Label lblPreviousFabricQuality = (Label)previousRow.Cells[0].FindControl("lblFabricQuality");

                HiddenField hdnFabricQuality = (HiddenField)row.Cells[0].FindControl("hdnfab");
                HiddenField hdnfabPreviousFabricQuality = (HiddenField)previousRow.Cells[0].FindControl("hdnfab");

                Label lbllblgsm = (Label)row.Cells[0].FindControl("lblgsm");
                Label lblPreviouslblgsm = (Label)previousRow.Cells[0].FindControl("lblgsm");

                Label lbllblwidth = (Label)row.Cells[0].FindControl("lblwidth");
                Label lblPreviouslblwidth = (Label)previousRow.Cells[0].FindControl("lblwidth");

                Label lbllblcolorprint = (Label)row.Cells[0].FindControl("lblcolorprint");
                Label lblPreviouslblcolorprint = (Label)previousRow.Cells[0].FindControl("lblcolorprint");

                // Style Number
                GridViewRow Stylerow = GrdFabric.Rows[i];
                GridViewRow StylepreviousRow = GrdFabric.Rows[StyleRowCnt];

                Label lblFabriclblstylenumber = (Label)Stylerow.Cells[0].FindControl("lblstylenumber");
                Label lblPreviouslblstylenumber = (Label)StylepreviousRow.Cells[0].FindControl("lblstylenumber");

                // Serial Number
                GridViewRow SerialNorow = GrdFabric.Rows[i];
                GridViewRow SerialNopreviousRow = GrdFabric.Rows[SerialNoRowCnt];

                Label lblFabriclbllblSerialNor = (Label)SerialNorow.Cells[0].FindControl("lblSerialNo");
                Label lblPreviouslbllblSerialNo = (Label)SerialNopreviousRow.Cells[0].FindControl("lblSerialNo");

                HiddenField hdntradecount = (HiddenField)row.Cells[0].FindControl("hdntradecount");

                // Fabric Quality
                if (hdnFabricQuality.Value == hdnfabPreviousFabricQuality.Value)
                {
                    if (previousRow.Cells[0].RowSpan == 0)
                    {
                        previousRow.Cells[0].RowSpan += 2;
                    }
                    else
                    {
                        previousRow.Cells[0].RowSpan = previousRow.Cells[0].RowSpan + 1;

                    }
                    row.Cells[0].Visible = false;
                    // Style Number
                    if (lblFabriclblstylenumber.Text == lblPreviouslblstylenumber.Text)
                    {
                        if (StylepreviousRow.Cells[1].RowSpan == 0)
                        {
                            StylepreviousRow.Cells[1].RowSpan += 2;
                        }
                        else
                        {
                            StylepreviousRow.Cells[1].RowSpan = StylepreviousRow.Cells[1].RowSpan + 1;
                        }
                        Stylerow.Cells[1].Visible = false;
                        //Serial Number
                        if (lblFabriclbllblSerialNor.Text == lblPreviouslbllblSerialNo.Text)
                        {
                            if (SerialNopreviousRow.Cells[2].RowSpan == 0)
                            {
                                SerialNopreviousRow.Cells[2].RowSpan += 2;
                            }
                            else
                            {
                                SerialNopreviousRow.Cells[2].RowSpan = SerialNopreviousRow.Cells[2].RowSpan + 1;
                            }
                            SerialNorow.Cells[2].Visible = false;
                        }
                        else
                        {
                            SerialNoRowCnt = i;
                        }
                    }
                    else
                    {
                        StyleRowCnt = i;
                        SerialNoRowCnt = i;
                        //previousRow.Cells[1].RowSpan = 0;
                    }
                }
                else
                {
                    MRowCnt = i;
                    StyleRowCnt = i;
                    SerialNoRowCnt = i;
                    //previousRow.Cells[1].RowSpan = 0;
                    //previousRow.Cells[0].RowSpan = 0;
                }
            }






            //for (int i = GrdFabric.Rows.Count - 1; i > 0; i--)
            //{
            //  GridViewRow row = GrdFabric.Rows[i];
            //  GridViewRow previousRow = GrdFabric.Rows[i - 1];


            //  Label lblFabriclblstylenumber = (Label)row.Cells[0].FindControl("lblstylenumber");
            //  Label lblPreviouslblstylenumber = (Label)previousRow.Cells[0].FindControl("lblstylenumber");

            //  //HiddenField hdntradecount = (HiddenField)row.Cells[0].FindControl("hdntradecount");
            //  HiddenField hdncountstylenumber = (HiddenField)row.Cells[0].FindControl("hdncountstylenumber");

            //  //Label lblstylenumber = (Label)row.Cells[0].FindControl("lblstylenumber");

            //  if (lblFabriclblstylenumber.Text == lblPreviouslblstylenumber.Text)
            //  {
            //      if (previousRow.Cells[1].RowSpan == 0)
            //      {
            //          if (row.Cells[1].RowSpan == 0)
            //          {
            //              previousRow.Cells[1].RowSpan += 2;
            //          }
            //          else
            //          {
            //              previousRow.Cells[1].RowSpan = row.Cells[0].RowSpan + 1;
            //          }
            //          row.Cells[1].Visible = false;
            //      }

            //  }

            //}
            //for (int i = GrdFabric.Rows.Count - 1; i > 0; i--)
            //{
            //  GridViewRow row = GrdFabric.Rows[i];
            //  GridViewRow previousRow = GrdFabric.Rows[i - 1];


            //  Label lblFabriclbllblSerialNor = (Label)row.Cells[0].FindControl("lblSerialNo");
            //  Label lblPreviouslbllblSerialNo = (Label)previousRow.Cells[0].FindControl("lblSerialNo");
            //  HiddenField hdncountserialnumber = (HiddenField)row.Cells[0].FindControl("hdncountserialnumber");
            //  if (lblFabriclbllblSerialNor.Text == lblPreviouslbllblSerialNo.Text)
            //  {

            //      if (previousRow.Cells[2].RowSpan == 0)
            //      {
            //          if (row.Cells[2].RowSpan == 0)
            //          {
            //              previousRow.Cells[2].RowSpan += 2;
            //          }
            //          else
            //          {
            //              previousRow.Cells[2].RowSpan = row.Cells[2].RowSpan + 1;
            //          }
            //          row.Cells[2].Visible = false;
            //      }

            //  }


            //}

        }
        protected void GrdFabric_DataBound(object sender, EventArgs e)
        {
            MarginFabric();
        }

        protected void GrdFabric_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //DataRowView drv = e.Row.DataItem as DataRowView;


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnstageCol11 = (HiddenField)e.Row.FindControl("hdnstageCol11");
                HiddenField hdnstageCol12 = (HiddenField)e.Row.FindControl("hdnstageCol12");
                HiddenField hdnstageCol13 = (HiddenField)e.Row.FindControl("hdnstageCol13");
                HiddenField hdntradecount = (HiddenField)e.Row.FindControl("hdntradecount");
                HiddenField hdncountstylenumber = (HiddenField)e.Row.FindControl("hdncountstylenumber");
                HiddenField hdncountserialnumber = (HiddenField)e.Row.FindControl("hdncountserialnumber");
                HiddenField hdnintialapprovel = (HiddenField)e.Row.FindControl("hdnintialapprovel");
                DropDownList ddlStage1 = (DropDownList)e.Row.FindControl("ddlStage1");
                DropDownList ddlStage2 = (DropDownList)e.Row.FindControl("ddlStage2");
                DropDownList ddlStage3 = (DropDownList)e.Row.FindControl("ddlStage3");
                DropDownList ddlStage4 = (DropDownList)e.Row.FindControl("ddlStage4");
                CheckBox chkfinalised = (CheckBox)e.Row.FindControl("chkfinalised");
                Label lblFabricQty = (Label)e.Row.FindControl("lblFabricQty");
                Label lblContractNumber = (Label)e.Row.FindControl("lblContractNumber");
                HiddenField hdnfabmasterid = (HiddenField)e.Row.FindControl("hdnfabmasterid");
                HiddenField hdnIsSrvRecived = (HiddenField)e.Row.FindControl("hdnIsSrvRecived");
                HiddenField hdnIsSrvRecived2 = (HiddenField)e.Row.FindControl("hdnIsSrvRecived2");
                HiddenField hdnIsSrvRecived3 = (HiddenField)e.Row.FindControl("hdnIsSrvRecived3");
                HiddenField hdnIsSrvRecived4 = (HiddenField)e.Row.FindControl("hdnIsSrvRecived4");
                Label lblcolorprint = (Label)e.Row.FindControl("lblcolorprint");
                HiddenField hdnLockFabricPendingStages = (HiddenField)e.Row.FindControl("hdnLockFabricPendingStages");
                HiddenField hdnstage1 = (HiddenField)e.Row.FindControl("hdnstage1");
                HiddenField hdnstage2 = (HiddenField)e.Row.FindControl("hdnstage2");
                HiddenField hdnstage3 = (HiddenField)e.Row.FindControl("hdnstage3");
                HiddenField hdnstage4 = (HiddenField)e.Row.FindControl("hdnstage4");


                HiddenField hdns1lock = (HiddenField)e.Row.FindControl("hdns1lock");
                HiddenField hdns2lock = (HiddenField)e.Row.FindControl("hdns2lock");
                HiddenField hdns3lock = (HiddenField)e.Row.FindControl("hdns3lock");
                HiddenField hdns4lock = (HiddenField)e.Row.FindControl("hdns4lock");

                //DataTable dt = fabobj.getpendingFabSummary("STAGES1", "", "", 0, txtfabname.Text.Trim(), txtstylenumber.Text.Trim());
                //DataTable dt2 = fabobj.getpendingFabSummary("STAGES2", "", "", 0, txtfabname.Text.Trim(), txtstylenumber.Text.Trim());
                DataTable dt = fabobj.getpendingFabSummary("STAGES1", "", "", 0, txtfabname.Text.Trim());   //new code
                DataTable dt2 = fabobj.getpendingFabSummary("STAGES2", "", "", 0, txtfabname.Text.Trim());  //new code
                if (lblContractNumber.Text.Length > 28)
                {
                    lblContractNumber.Attributes.Add("data-title", lblContractNumber.Text);
                    lblContractNumber.Text = lblContractNumber.Text.Substring(0, 20) + "...";
                }
                if (dt.Rows.Count > 0)
                {
                    ddlStage1.DataSource = dt;
                    ddlStage1.DataTextField = "Name";
                    ddlStage1.DataValueField = "SupplierType_Id";
                    ddlStage1.DataBind();

                    ddlStage1.SelectedValue = DataBinder.Eval(e.Row.DataItem, "Stage1").ToString();

                }
                if (dt2.Rows.Count > 0)
                {
                    ddlStage2.DataSource = dt2;
                    ddlStage2.DataTextField = "Name";
                    ddlStage2.DataValueField = "SupplierType_Id";
                    ddlStage2.DataBind();
                    ddlStage2.SelectedValue = DataBinder.Eval(e.Row.DataItem, "Stage2").ToString();

                    ddlStage3.DataSource = dt2;
                    ddlStage3.DataTextField = "Name";
                    ddlStage3.DataValueField = "SupplierType_Id";
                    ddlStage3.DataBind();
                    ddlStage3.SelectedValue = DataBinder.Eval(e.Row.DataItem, "Stage3").ToString();
                    ddlStage3.Items.Remove(ddlStage3.Items.FindByValue("29"));

                    ddlStage4.DataSource = dt2;
                    ddlStage4.DataTextField = "Name";
                    ddlStage4.DataValueField = "SupplierType_Id";
                    ddlStage4.DataBind();
                    ddlStage4.SelectedValue = DataBinder.Eval(e.Row.DataItem, "Stage4").ToString();
                    ddlStage4.Items.Remove(ddlStage4.Items.FindByValue("29"));
                }
                if (chkfinalised.Checked)
                {
                    ddlStage1.Enabled = false;
                    ddlStage2.Enabled = false;
                    ddlStage3.Enabled = false;
                    ddlStage4.Enabled = false;
                }
                DataTable dts = fabobj.getpendingFabsStageValidation("STAGEVALIDATE", Convert.ToInt32(hdnfabmasterid.Value), lblcolorprint.Text.Trim(), Convert.ToInt32(ddlStage1.SelectedValue), Convert.ToInt32(ddlStage1.SelectedValue), Convert.ToInt32(ddlStage1.SelectedValue), Convert.ToInt32(ddlStage1.SelectedValue));
                if (dts.Rows.Count > 0)
                {
                    double Qty = (dts.Rows[0]["OverAllQty"].ToString() == "" ? 0 : Convert.ToDouble(dts.Rows[0]["OverAllQty"].ToString()));
                    if (lblFabricQty.Text != "")
                    {
                        if (Qty > 0)
                        {
                            if (Qty < (Convert.ToDouble(lblFabricQty.Text.Replace(",", ""))))
                            {
                                //chkfinalised.Enabled = false;
                            }
                        }
                    }
                }

                ////if (ddlStage1.SelectedValue == "1")
                ////{
                ////    ddlStage2.Enabled = true;
                ////}
                ////else if (ddlStage1.SelectedValue == "-1" || ddlStage1.SelectedValue == "10")
                ////{
                ////    ddlStage2.Attributes["disabled"] = "disabled";
                ////}

                Label lblFabricQuality = (Label)e.Row.FindControl("lblFabricQuality");
                //updated by code by bharat 14-feb
                Label lblContractQty = (Label)e.Row.FindControl("lblContractQty");
                lblContractQty.Style.Add("color", "#000");

                lblFabricQty.Style.Add("color", "#000");
                Label lblstylenumber = (Label)e.Row.FindControl("lblstylenumber");
                lblstylenumber.Style.Add("color", "#000");
                Label lblSerialNo = (Label)e.Row.FindControl("lblSerialNo");
                lblSerialNo.Style.Add("color", "#000");
                Label lblOrderDate = (Label)e.Row.FindControl("lblOrderDate");
                lblOrderDate.Style.Add("color", "#999999");
                Label lblgsm = (Label)e.Row.FindControl("lblgsm");
                string lbsgm = lblgsm.Text;
                string[] lbsgmstring = lbsgm.Split(new string[] { "-", " " }, StringSplitOptions.RemoveEmptyEntries);
                string newString = String.Join(" ", lbsgmstring);
                if (!string.IsNullOrEmpty(lblgsm.Text))
                {

                    lblgsm.Text = "(" + newString + ")";
                }

                lblgsm.Style.Add("color", "#999999");
                e.Row.Cells[0].Style.Add("color", "#000");
                Label lblwidth = (Label)e.Row.FindControl("lblwidth");
                lblwidth.Text = lblwidth.Text + '"';

                //Label lblcolorprint = (Label)e.Row.FindControl("lblcolorprint");
                string colorprint = lblcolorprint.Text;
                if (!string.IsNullOrEmpty(colorprint))
                {
                    lblcolorprint.Text = char.ToUpper(colorprint.First()) + colorprint.Substring(1).ToLower();
                }

                //end
                decimal DecTop = (Convert.ToDecimal(15) * Convert.ToDecimal(hdntradecount.Value)) / Convert.ToDecimal(2);
                lblFabricQuality.Style.Add("top", +DecTop + "px");
                lblgsm.Style.Add("top", +DecTop + "px");
                lblwidth.Style.Add("top", +DecTop + "px");
                lblcolorprint.Style.Add("top", +DecTop + "px");
                //style number
                decimal DecTopStylenumber = (Convert.ToDecimal(15) * Convert.ToDecimal(hdncountstylenumber.Value)) / Convert.ToDecimal(2);
                lblstylenumber.Style.Add("top", +DecTopStylenumber + "px");

                //serial number
                decimal DecTopSerialNo = (Convert.ToDecimal(15) * Convert.ToDecimal(hdncountserialnumber.Value)) / Convert.ToDecimal(2);
                lblSerialNo.Style.Add("top", +DecTopSerialNo + "px");
                lblOrderDate.Style.Add("top", +DecTopSerialNo + "px");
                //if (hdnintialapprovel.Value != "2")
                //{
                //    ddlStage1.Items.FindByValue("10").Attributes.Add("Disabled", "Disabled");
                //    ddlStage2.Attributes["disabled"] = "disabled";
                //}
                List<int> re = new List<int>();
                re.Add(2);
                re.Add(3);
                re.Add(29);
                re.Add(30);
                re.Add(31);

                if (lblcolorprint.Text.Trim().ToLower() == "Tbd".ToLower())
                {
                    lblcolorprint.Attributes.Add("style", "background-color: orange;");
                    lblcolorprint.ToolTip = "Color print not decided yet. Stage selection is limited only Greige or RFD can be selected!";

                    ddlStage3.Enabled = false;
                    ddlStage4.Enabled = false;
                    ddlStage1.Items.FindByValue("10").Attributes["disabled"] = "disabled";
                    foreach (int i in re)
                    {
                        if (ddlStage1.SelectedValue == "1")
                        {
                            if (i != 29)
                            {
                                ddlStage2.Items.FindByValue(i.ToString()).Attributes["disabled"] = "disabled";
                            }
                            //ddlStage2.Enabled = true;
                        }
                        else if (ddlStage1.SelectedValue == "29" || ddlStage1.SelectedValue == "-1")
                        {
                            ddlStage2.SelectedValue = "-1";
                            ddlStage2.Items.FindByValue(i.ToString()).Attributes["disabled"] = "disabled";
                            ddlStage2.Enabled = false;
                        }
                    }
                }



                if (ddlStage1.SelectedValue == "1")
                {
                    if (ddlStage2.SelectedValue != "-1")
                    {
                        if (ddlStage2.SelectedValue != "29")
                        {
                            ddlStage3.Items.FindByValue(ddlStage2.SelectedValue).Attributes["disabled"] = "disabled";
                            ddlStage4.Items.FindByValue(ddlStage2.SelectedValue).Attributes["disabled"] = "disabled";

                            ddlStage3.Items.FindByValue(ddlStage2.SelectedValue).Attributes["Class"] = "Unselected";
                            ddlStage4.Items.FindByValue(ddlStage2.SelectedValue).Attributes["Class"] = "Unselected";
                        }

                    }
                    if (ddlStage3.SelectedValue != "-1")
                    {
                        if (ddlStage3.SelectedValue != "29")
                        {
                            ddlStage4.Items.FindByValue(ddlStage3.SelectedValue).Attributes["disabled"] = "disabled";
                        }
                    }

                }

                else if (ddlStage1.SelectedValue == "10")
                {
                    if (dt2.Rows.Count > 0)
                    {

                        foreach (int i in re)
                        {
                            ddlStage2.Items.FindByValue(i.ToString()).Attributes["disabled"] = "disabled";
                            ddlStage2.Items.FindByValue(i.ToString()).Attributes["Class"] = "Unselected";

                            if (i.ToString() != "29")
                            {
                                ddlStage3.Items.FindByValue(i.ToString()).Attributes["disabled"] = "disabled";
                                ddlStage4.Items.FindByValue(i.ToString()).Attributes["disabled"] = "disabled";

                                ddlStage3.Items.FindByValue(i.ToString()).Attributes["Class"] = "Unselected";
                                ddlStage4.Items.FindByValue(i.ToString()).Attributes["Class"] = "Unselected";
                            }


                        }


                        if (ddlStage2.SelectedValue != "-1")
                        {
                            if (ddlStage2.SelectedValue != "29")
                            {
                                ddlStage3.Items.FindByValue(ddlStage2.SelectedValue).Attributes["disabled"] = "disabled";
                                ddlStage4.Items.FindByValue(ddlStage2.SelectedValue).Attributes["disabled"] = "disabled";

                                ddlStage3.Items.FindByValue(ddlStage2.SelectedValue).Attributes["Class"] = "Unselected";
                                ddlStage4.Items.FindByValue(ddlStage2.SelectedValue).Attributes["Class"] = "Unselected";
                            }
                        }
                        if (ddlStage3.SelectedValue != "-1")
                        {
                            ddlStage4.Items.FindByValue(ddlStage3.SelectedValue).Attributes["disabled"] = "disabled";
                            ddlStage4.Items.FindByValue(ddlStage2.SelectedValue).Attributes["Class"] = "Unselected";
                        }




                    }
                }


                ddlStage2.Items.FindByValue("2").Attributes["disabled"] = "disabled";
                ddlStage2.Items.FindByValue("3").Attributes["disabled"] = "disabled";

                ddlStage3.Items.FindByValue("2").Attributes["disabled"] = "disabled";
                ddlStage3.Items.FindByValue("3").Attributes["disabled"] = "disabled";

                ddlStage4.Items.FindByValue("2").Attributes["disabled"] = "disabled";
                ddlStage4.Items.FindByValue("3").Attributes["disabled"] = "disabled";


                ddlStage2.Items.FindByValue("2").Attributes["Class"] = "Unselected";
                ddlStage2.Items.FindByValue("3").Attributes["Class"] = "Unselected";

                ddlStage3.Items.FindByValue("2").Attributes["Class"] = "Unselected";
                ddlStage3.Items.FindByValue("3").Attributes["Class"] = "Unselected";

                ddlStage4.Items.FindByValue("2").Attributes["Class"] = "Unselected";
                ddlStage4.Items.FindByValue("3").Attributes["Class"] = "Unselected";



                if (ddlStage2.SelectedValue != "-1")
                {
                    if (ddlStage2.SelectedValue != "29")
                    {
                        ddlStage3.Items.FindByValue(ddlStage2.SelectedValue).Attributes["disabled"] = "disabled";
                        ddlStage4.Items.FindByValue(ddlStage2.SelectedValue).Attributes["disabled"] = "disabled";

                        ddlStage3.Items.FindByValue(ddlStage2.SelectedValue).Attributes["Class"] = "Unselected";
                        ddlStage4.Items.FindByValue(ddlStage2.SelectedValue).Attributes["Class"] = "Unselected";
                    }
                }
                if (ddlStage3.SelectedValue != "-1")
                {
                    if (ddlStage2.SelectedValue != "29")
                    {
                        ddlStage4.Items.FindByValue(ddlStage2.SelectedValue).Attributes["disabled"] = "disabled";
                        ddlStage4.Items.FindByValue(ddlStage2.SelectedValue).Attributes["Class"] = "Unselected";
                    }
                }

                if (ddlStage1.SelectedValue == "-1")
                {
                    ddlStage2.SelectedValue = "-1";
                    ddlStage3.SelectedValue = "-1";
                    ddlStage4.SelectedValue = "-1";
                }
                if (ddlStage2.SelectedValue == "-1")
                {
                    ddlStage3.SelectedValue = "-1";
                    ddlStage4.SelectedValue = "-1";


                }
                else
                {
                    if (ddlStage2.SelectedValue == "30" || ddlStage2.SelectedValue == "31")
                    {
                        //ddlStage3.Items.FindByValue("29").Attributes["disabled"] = "disabled";
                        //ddlStage4.Items.FindByValue("29").Attributes["disabled"] = "disabled";

                        //ddlStage3.Items.FindByValue("29").Attributes["Class"] = "Unselected";
                        //ddlStage4.Items.FindByValue("29").Attributes["Class"] = "Unselected";
                    }
                }
                if (ddlStage3.SelectedValue == "-1")
                {
                    ddlStage4.SelectedValue = "-1";
                }
                else
                {
                    if (ddlStage3.SelectedValue == "30" || ddlStage3.SelectedValue == "31")
                    {
                        //ddlStage4.Items.FindByValue("29").Attributes["disabled"] = "disabled";
                        //ddlStage4.Items.FindByValue("29").Attributes["Class"] = "Unselected";
                    }
                }

                //if (ddlStage1.SelectedValue == "1")
                //{
                //    DataTable dt1 = fabobj.CheckStageUpadteValidation("CHECKSTAGE", lblcolorprint.Text.Trim(), Convert.ToInt16(hdnfabmasterid.Value), 1);
                //    if (dt1.Rows.Count > 0)
                //    {
                //        if (dt1.Rows[0]["Result"].ToString() == "Exist")
                //        {
                //            ddlStage1.Attributes["disabled"] = "disabled";
                //            ddlStage1.ToolTip = "po raised for this quality " + lblcolorprint.Text.Trim();
                //        }
                //    }
                //}
                //else if (ddlStage1.SelectedValue == "10")
                //{
                //    DataTable dt1 = fabobj.CheckStageUpadteValidation("CHECKSTAGE", lblcolorprint.Text.Trim(), Convert.ToInt16(hdnfabmasterid.Value), 10);
                //    if (dt1.Rows.Count > 0)
                //    {
                //        if (dt1.Rows[0]["Result"].ToString() == "Exist")
                //        {
                //            ddlStage1.Attributes["disabled"] = "disabled";
                //            ddlStage1.ToolTip = "po raised for this quality " + lblcolorprint.Text.Trim();
                //        }
                //    }
                //}
                //if (ddlStage2.SelectedValue == "3")
                //{
                //    DataTable dt1 = fabobj.CheckStageUpadteValidation("CHECKSTAGE", lblcolorprint.Text.Trim(), Convert.ToInt16(hdnfabmasterid.Value), 3);
                //    if (dt1.Rows.Count > 0)
                //    {
                //        if (dt1.Rows[0]["Result"].ToString() == "Exist")
                //        {
                //            ddlStage2.Attributes["disabled"] = "disabled";
                //            ddlStage2.ToolTip = "po raised for this quality " + lblcolorprint.Text.Trim();
                //        }
                //    }
                //}
                //else if (ddlStage1.SelectedValue == "2")
                //{
                //    DataTable dt1 = fabobj.CheckStageUpadteValidation("CHECKSTAGE", lblcolorprint.Text.Trim(), Convert.ToInt16(hdnfabmasterid.Value), 2);
                //    if (dt1.Rows.Count > 0)
                //    {
                //        if (dt1.Rows[0]["Result"].ToString() == "Exist")
                //        {
                //            ddlStage2.Attributes["disabled"] = "disabled";
                //            ddlStage2.ToolTip = "po raised for this quality " + lblcolorprint.Text.Trim();
                //        }
                //    }
                //}
                if (Convert.ToInt32(hdnIsSrvRecived.Value) > 0)
                {

                    if (ddlStage1.SelectedValue != "-1")
                    {
                        ddlStage1.Attributes["disabled"] = "disabled";
                        ddlStage1.ToolTip = "srv revised " + lblcolorprint.Text.Trim();
                    }

                }
                if (Convert.ToInt32(hdnIsSrvRecived2.Value) > 0)
                {

                    if (ddlStage2.SelectedValue != "-1")
                    {
                        ddlStage2.Attributes["disabled"] = "disabled";
                        ddlStage2.ToolTip = "srv revised " + lblcolorprint.Text.Trim();
                    }

                }
                if (Convert.ToInt32(hdnIsSrvRecived3.Value) > 0)
                {
                    if (ddlStage3.SelectedValue != "-1")
                    {
                        ddlStage3.Attributes["disabled"] = "disabled";
                        ddlStage3.ToolTip = "srv revised " + lblcolorprint.Text.Trim();
                    }
                }
                if (Convert.ToInt32(hdnIsSrvRecived4.Value) > 0)
                {
                    if (ddlStage4.SelectedValue != "-1")
                    {
                        ddlStage4.Attributes["disabled"] = "disabled";
                        ddlStage4.ToolTip = "srv revised " + lblcolorprint.Text.Trim();
                    }
                }
                //abhishek if po raise and all selected stage will be disabled 24 dec 2020

                if (Convert.ToInt32(hdns1lock.Value) >0)
                {
                    ddlStage1.Attributes["disabled"] = "disabled";
                    ddlStage1.ToolTip = "Po raised cannot change " + lblcolorprint.Text.Trim();
                    e.Row.Cells[8].Attributes.Add("style", "background: #dddfe4;");
                }
                if (Convert.ToInt32(hdns2lock.Value) > 0)
                {
                    ddlStage2.Attributes["disabled"] = "disabled";
                    ddlStage2.ToolTip = "Po raised cannot change " + lblcolorprint.Text.Trim();
                    e.Row.Cells[9].Attributes.Add("style", "background: #dddfe4;");

                    ddlStage1.Attributes["disabled"] = "disabled";
                    ddlStage1.ToolTip = "Po raised cannot change " + lblcolorprint.Text.Trim();
                    e.Row.Cells[8].Attributes.Add("style", "background: #dddfe4;");

                }
                if (Convert.ToInt32(hdns3lock.Value) > 0)
                {
                    ddlStage3.Attributes["disabled"] = "disabled";
                    ddlStage3.ToolTip = "Po raised cannot change " + lblcolorprint.Text.Trim();
                    e.Row.Cells[10].Attributes.Add("style", "background: #dddfe4;");

                    ddlStage2.Attributes["disabled"] = "disabled";
                    ddlStage2.ToolTip = "Po raised cannot change " + lblcolorprint.Text.Trim();
                    e.Row.Cells[9].Attributes.Add("style", "background: #dddfe4;");

                    ddlStage1.Attributes["disabled"] = "disabled";
                    ddlStage1.ToolTip = "Po raised cannot change " + lblcolorprint.Text.Trim();
                    e.Row.Cells[8].Attributes.Add("style", "background: #dddfe4;");

                }
                if (Convert.ToInt32(hdns4lock.Value) > 0)
                {
                    ddlStage4.Attributes["disabled"] = "disabled";
                    ddlStage4.ToolTip = "Po raised cannot change " + lblcolorprint.Text.Trim();
                    e.Row.Cells[11].Attributes.Add("style", "background: #dddfe4;");

                    ddlStage3.Attributes["disabled"] = "disabled";
                    ddlStage3.ToolTip = "Po raised cannot change " + lblcolorprint.Text.Trim();
                    e.Row.Cells[10].Attributes.Add("style", "background: #dddfe4;");

                    ddlStage2.Attributes["disabled"] = "disabled";
                    ddlStage2.ToolTip = "Po raised cannot change " + lblcolorprint.Text.Trim();
                    e.Row.Cells[9].Attributes.Add("style", "background: #dddfe4;");

                    ddlStage1.Attributes["disabled"] = "disabled";
                    ddlStage1.ToolTip = "Po raised cannot change " + lblcolorprint.Text.Trim();
                    e.Row.Cells[8].Attributes.Add("style", "background: #dddfe4;");
                }

            }

        }

        protected void GrdFabric_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "StageChange")
            {
                Table tblgvDetail = (Table)GrdFabric.Controls[0];
                GridViewRow rows = (GridViewRow)tblgvDetail.Controls[0];

                DropDownList ddlStage1 = (DropDownList)rows.FindControl("ddlStage1");
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable dt = fabobj.getpendingFabSummary("STAGES1", "", "", 0, txtfabname.Text.Trim(), txtstylenumber.Text.Trim());
            //DataTable dt2 = fabobj.getpendingFabSummary("STAGES2", "", "", 0, txtfabname.Text.Trim(), txtstylenumber.Text.Trim());
            DataTable dt = fabobj.getpendingFabSummary("STAGES1", "", "", 0, txtfabname.Text.Trim());   //new code
            DataTable dt2 = fabobj.getpendingFabSummary("STAGES2", "", "", 0, txtfabname.Text.Trim());  //new code

            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.Parent.Parent;
            int idx = row.RowIndex;
            DropDownList ddlStage1 = (DropDownList)row.FindControl("ddlStage1");
            DropDownList ddlStage2 = (DropDownList)row.FindControl("ddlStage2");
            DropDownList ddlStage3 = (DropDownList)row.FindControl("ddlStage3");
            DropDownList ddlStage4 = (DropDownList)row.FindControl("ddlStage4");

            HiddenField hdnstage1 = (HiddenField)row.FindControl("hdnstage1");
            HiddenField hdnstage2 = (HiddenField)row.FindControl("hdnstage2");
            HiddenField hdnstage3 = (HiddenField)row.FindControl("hdnstage3");
            HiddenField hdnstage4 = (HiddenField)row.FindControl("hdnstage4");

            Label lblcolorprint = (Label)row.FindControl("lblcolorprint");


            //hdnstage1.Value = ddlStage1.SelectedValue;
            //hdnstage2.Value = ddlStage2.SelectedValue;
            //hdnstage3.Value = ddlStage3.SelectedValue;
            //hdnstage4.Value = ddlStage4.SelectedValue;

            List<int> re = new List<int>();
            re.Add(2);
            re.Add(3);
            re.Add(29);
            re.Add(30);
            re.Add(31);

            if (ddl.ID == "ddlStage1")
            {
                ddlStage2.SelectedValue = "-1";
                ddlStage3.SelectedValue = "-1";
                ddlStage4.SelectedValue = "-1";
            }
            else if (ddl.ID == "ddlStage2")
            {

                ddlStage3.SelectedValue = "-1";
                ddlStage4.SelectedValue = "-1";

            }
            else if (ddl.ID == "ddlStage3")
            {

                ddlStage4.SelectedValue = "-1";
            }
            //List<ListItem> _listGerige = null;
            if (ddlStage1.SelectedValue == "29")
            {
                ddlStage2.Items.FindByValue("29").Attributes["disabled"] = "disabled";

                //ddlStage3.Items.FindByValue("29").Attributes["disabled"] = "disabled";
                //ddlStage4.Items.FindByValue("29").Attributes["disabled"] = "disabled";

                ddlStage2.Items.FindByValue("29").Attributes["Class"] = "Unselected";
                ddlStage2.Items.FindByValue("29").Attributes["Class"] = "Unselected";
                ddlStage2.Items.FindByValue("29").Attributes["Class"] = "Unselected";
                if (ddlStage2.SelectedValue != "-1")
                {
                    if (ddlStage2.SelectedValue != "29")
                    {
                        ddlStage3.Items.FindByValue(ddlStage2.SelectedValue).Attributes["disabled"] = "disabled";
                        ddlStage4.Items.FindByValue(ddlStage2.SelectedValue).Attributes["disabled"] = "disabled";

                        ddlStage3.Items.FindByValue(ddlStage2.SelectedValue).Attributes["Class"] = "Unselected";
                        ddlStage4.Items.FindByValue(ddlStage2.SelectedValue).Attributes["Class"] = "Unselected";
                    }

                }
                if (ddlStage3.SelectedValue != "-1")
                {
                    ddlStage4.Items.FindByValue(ddlStage3.SelectedValue).Attributes["disabled"] = "disabled";
                }
            }

            if (ddlStage1.SelectedValue == "1")
            {
                if (ddlStage2.SelectedValue != "-1")
                {
                    if (ddlStage2.SelectedValue != "29")
                    {
                        ddlStage3.Items.FindByValue(ddlStage2.SelectedValue).Attributes["disabled"] = "disabled";
                        ddlStage4.Items.FindByValue(ddlStage2.SelectedValue).Attributes["disabled"] = "disabled";

                        ddlStage3.Items.FindByValue(ddlStage2.SelectedValue).Attributes["Class"] = "Unselected";
                        ddlStage4.Items.FindByValue(ddlStage2.SelectedValue).Attributes["Class"] = "Unselected";
                    }
                }
                if (ddlStage3.SelectedValue != "-1")
                {
                    if (ddlStage3.SelectedValue != "29")
                    {
                        ddlStage4.Items.FindByValue(ddlStage3.SelectedValue).Attributes["disabled"] = "disabled";
                    }
                }
            }
            else if (ddlStage1.SelectedValue == "10")
            {
                if (dt2.Rows.Count > 0)
                {

                    foreach (int i in re)
                    {
                        ddlStage2.Items.FindByValue(i.ToString()).Attributes["disabled"] = "disabled";


                        ddlStage2.Items.FindByValue(i.ToString()).Attributes["Class"] = "Unselected";


                        if (i.ToString() != "29")
                        {
                            ddlStage3.Items.FindByValue(i.ToString()).Attributes["disabled"] = "disabled";
                            ddlStage4.Items.FindByValue(i.ToString()).Attributes["disabled"] = "disabled";

                            ddlStage3.Items.FindByValue(i.ToString()).Attributes["Class"] = "Unselected";
                            ddlStage4.Items.FindByValue(i.ToString()).Attributes["Class"] = "Unselected";
                        }
                    }



                    if (ddlStage2.SelectedValue != "-1")
                    {
                        if (ddlStage2.SelectedValue != "29")
                        {
                            ddlStage3.Items.FindByValue(ddlStage2.SelectedValue).Attributes["disabled"] = "disabled";
                            ddlStage4.Items.FindByValue(ddlStage2.SelectedValue).Attributes["disabled"] = "disabled";

                            ddlStage3.Items.FindByValue(ddlStage2.SelectedValue).Attributes["Class"] = "Unselected";
                            ddlStage4.Items.FindByValue(ddlStage2.SelectedValue).Attributes["Class"] = "Unselected";
                        }
                    }
                    if (ddlStage3.SelectedValue != "-1")
                    {
                        if (ddlStage3.SelectedValue != "29")
                        {
                            ddlStage4.Items.FindByValue(ddlStage3.SelectedValue).Attributes["disabled"] = "disabled";
                            ddlStage4.Items.FindByValue(ddlStage3.SelectedValue).Attributes["Class"] = "Unselected";
                        }
                    }
                }
            }
            if (ddlStage1.SelectedValue == "-1")
            {
                ddlStage2.SelectedValue = "-1";
                ddlStage3.SelectedValue = "-1";
                ddlStage4.SelectedValue = "-1";
            }
            if (ddlStage2.SelectedValue == "-1")
            {
                ddlStage3.SelectedValue = "-1";
                ddlStage4.SelectedValue = "-1";


            }
            else
            {
                if (ddlStage2.SelectedValue == "30" || ddlStage2.SelectedValue == "31")
                {
                    //ddlStage3.Items.FindByValue("29").Attributes["disabled"] = "disabled";
                    //ddlStage4.Items.FindByValue("29").Attributes["disabled"] = "disabled";

                    //ddlStage3.Items.FindByValue("29").Attributes["Class"] = "Unselected";
                    //ddlStage4.Items.FindByValue("29").Attributes["Class"] = "Unselected";
                }
            }
            if (ddlStage3.SelectedValue == "-1")
            {
                ddlStage4.SelectedValue = "-1";
            }
            else
            {
                if (ddlStage3.SelectedValue == "30" || ddlStage3.SelectedValue == "31")
                {
                    //ddlStage4.Items.FindByValue("29").Attributes["disabled"] = "disabled";
                    //ddlStage4.Items.FindByValue("29").Attributes["Class"] = "Unselected";                   
                }
            }
            if (lblcolorprint.Text.Trim().ToLower() == "Tbd".ToLower())
            {
                ddlStage3.Enabled = false;
                ddlStage4.Enabled = false;
                ddlStage1.Items.FindByValue("10").Attributes["disabled"] = "disabled";            
                foreach (int i in re)
                {
                    if (ddlStage1.SelectedValue == "1")
                    {
                        if (i != 29)
                        {
                            ddlStage2.Items.FindByValue(i.ToString()).Attributes["disabled"] = "disabled";
                        }
                        ddlStage2.Enabled = true;
                    }
                    else if (ddlStage1.SelectedValue == "29" || ddlStage1.SelectedValue == "-1")
                    {
                        ddlStage2.SelectedValue = "-1";
                        ddlStage2.Items.FindByValue(i.ToString()).Attributes["disabled"] = "disabled";
                        ddlStage2.Enabled = false;
                    }
                }
            }
        }

        protected void chkfinalised_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox chkfinlized = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chkfinlized.Parent.Parent;
            int idx = row.RowIndex;
            hfScrollPosition.Value = chkfinlized.ClientID;

            DropDownList ddlStage1 = (DropDownList)row.FindControl("ddlStage1");
            DropDownList ddlStage2 = (DropDownList)row.FindControl("ddlStage2");
            DropDownList ddlStage3 = (DropDownList)row.FindControl("ddlStage3");
            DropDownList ddlStage4 = (DropDownList)row.FindControl("ddlStage4");

            List<int> re = new List<int>();
            re.Add(2);
            re.Add(3);
            re.Add(29);
            re.Add(30);
            re.Add(31);

            string flag = "UPDATE";
            HiddenField hdnorderdetailid = row.FindControl("hdnorderdetailid") as HiddenField;
            HiddenField hdnfabmasterid = row.FindControl("hdnfabmasterid") as HiddenField;
            HiddenField hdnFabricPending_Orders_Id = row.FindControl("hdnFabricPending_Orders_Id") as HiddenField;
            HiddenField hdnstyleid = row.FindControl("hdnstyleid") as HiddenField;
            Label lblcolorprint = row.FindControl("lblcolorprint") as Label;

            HiddenField hdnIsSrvRecived = (HiddenField)row.FindControl("hdnIsSrvRecived");
            HiddenField hdnIsSrvRecived2 = (HiddenField)row.FindControl("hdnIsSrvRecived2");
            HiddenField hdnIsSrvRecived3 = (HiddenField)row.FindControl("hdnIsSrvRecived3");
            HiddenField hdnIsSrvRecived4 = (HiddenField)row.FindControl("hdnIsSrvRecived4");
            HiddenField hdnLockFabricPendingStages = (HiddenField)row.FindControl("hdnLockFabricPendingStages");
            HiddenField hdnorderid = (HiddenField)row.FindControl("hdnorderid");
            HiddenField hdnFabricDetails = (HiddenField)row.FindControl("hdnFabricDetails");

            HiddenField hdnstage1 = (HiddenField)row.FindControl("hdnstage1");
            HiddenField hdnstage2 = (HiddenField)row.FindControl("hdnstage2");
            HiddenField hdnstage3 = (HiddenField)row.FindControl("hdnstage3");
            HiddenField hdnstage4 = (HiddenField)row.FindControl("hdnstage4");

           

          int NewSelectionStageNo1= -1, NewSelectionStageNo2 =-1, NewSelectionStageNo3= -1,NewSelectionStageNo4 =-1,OldSelectionStageNo1 =-1,OldSelectionStageNo2 =-1, OldSelectionStageNo3 =-1,OldSelectionStageNo4 =-1;
          NewSelectionStageNo1 = Convert.ToInt16(ddlStage1.SelectedValue);
          NewSelectionStageNo2 = Convert.ToInt16(ddlStage2.SelectedValue);
          NewSelectionStageNo3 = Convert.ToInt16(ddlStage3.SelectedValue);
          NewSelectionStageNo4 = Convert.ToInt16(ddlStage4.SelectedValue);


          OldSelectionStageNo1 = Convert.ToInt16(hdnstage1.Value);
          OldSelectionStageNo2 = Convert.ToInt16(hdnstage2.Value);
          OldSelectionStageNo3 = Convert.ToInt16(hdnstage3.Value);
          OldSelectionStageNo4 = Convert.ToInt16(hdnstage4.Value);
            string rowcurrent = "";
            if (chkfinlized.Checked)
            {
                //if (ddlStage1.SelectedValue != "-1")
                //{
                Boolean IsFin = chkfinlized.Checked;
                if (ddlStage1.SelectedValue == "-1" && ddlStage2.SelectedValue == "-1" && ddlStage3.SelectedValue == "-1" && ddlStage4.SelectedValue == "-1")
                {
                    IsFin = false;
                }
                rowcurrent = hdnfabmasterid.Value + hdnFabricDetails.Value + hdnorderid.Value;
                ddlStage1.Enabled = false;
                ddlStage2.Enabled = false;
                ddlStage3.Enabled = false;
                ddlStage4.Enabled = false;

               


                foreach (GridViewRow rows in GrdFabric.Rows)
                {
                    try
                    {

                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            string nextcurrent = "";


                            HiddenField hdnFabricDetails_next = (HiddenField)rows.FindControl("hdnFabricDetails");
                            HiddenField hdnorderid_next = (HiddenField)rows.FindControl("hdnorderid");
                            HiddenField hdnfabmasterid_next = (HiddenField)rows.FindControl("hdnfabmasterid");
                            HiddenField hdnFabricPending_Orders_Id_next = (HiddenField)rows.FindControl("hdnFabricPending_Orders_Id");
                            HiddenField hdnorderdetailid_next = (HiddenField)rows.FindControl("hdnorderdetailid");
                            nextcurrent = hdnfabmasterid_next.Value + hdnFabricDetails_next.Value + hdnorderid_next.Value;

                            DropDownList ddlStagenext1 = (DropDownList)rows.FindControl("ddlStage1");
                            DropDownList ddlStagenext2 = (DropDownList)rows.FindControl("ddlStage2");
                            DropDownList ddlStagenext3 = (DropDownList)rows.FindControl("ddlStage3");
                            DropDownList ddlStagenext4 = (DropDownList)rows.FindControl("ddlStage4");
                            CheckBox chkfinlizednext = (CheckBox)rows.FindControl("chkfinalised");

                            HiddenField hdnAllocateStock = (HiddenField)rows.FindControl("hdnAllocateStock");

                           

                            if (rowcurrent == nextcurrent)
                            {
                                if (NewSelectionStageNo1 != OldSelectionStageNo1 || NewSelectionStageNo2 != OldSelectionStageNo2 || NewSelectionStageNo3 != OldSelectionStageNo3 || NewSelectionStageNo4 != OldSelectionStageNo4)
                                {
                                    bool resultIschange = Qcobj.PendingOrderSummaryUpdateOnStagechange(flag, "", Convert.ToInt32(hdnorderdetailid_next.Value), Convert.ToInt32(hdnfabmasterid.Value), lblcolorprint.Text, NewSelectionStageNo1, NewSelectionStageNo2, NewSelectionStageNo3, NewSelectionStageNo4, OldSelectionStageNo1, OldSelectionStageNo2, OldSelectionStageNo3, OldSelectionStageNo4, Convert.ToInt32(hdnFabricPending_Orders_Id_next.Value), IsFin);
                                }


                                bool result = Qcobj.PendingOrderSummaryUpdate(flag, "Stage1", Convert.ToInt32(hdnorderdetailid_next.Value), Convert.ToInt32(hdnfabmasterid.Value), lblcolorprint.Text, Convert.ToInt32(ddlStage1.SelectedValue), Convert.ToInt32(hdnFabricPending_Orders_Id_next.Value), IsFin);
                                result = Qcobj.PendingOrderSummaryUpdate(flag, "Stage2", Convert.ToInt32(hdnorderdetailid_next.Value), Convert.ToInt32(hdnfabmasterid.Value), lblcolorprint.Text, Convert.ToInt32(ddlStage2.SelectedValue), Convert.ToInt32(hdnFabricPending_Orders_Id_next.Value), IsFin);
                                result = Qcobj.PendingOrderSummaryUpdate(flag, "Stage3", Convert.ToInt32(hdnorderdetailid_next.Value), Convert.ToInt32(hdnfabmasterid.Value), lblcolorprint.Text, Convert.ToInt32(ddlStage3.SelectedValue), Convert.ToInt32(hdnFabricPending_Orders_Id_next.Value), IsFin);
                                result = Qcobj.PendingOrderSummaryUpdate(flag, "Stage4", Convert.ToInt32(hdnorderdetailid_next.Value), Convert.ToInt32(hdnfabmasterid.Value), lblcolorprint.Text, Convert.ToInt32(ddlStage4.SelectedValue), Convert.ToInt32(hdnFabricPending_Orders_Id_next.Value), IsFin);
                                
                                // edit by surendra on 1-feb 2021 for auto allocation
                                if (hdnAllocateStock.Value == "1")
                                {
                                    bool result_Allocation = Qcobj.AutoAllocate_Fabric_From_Stock(Convert.ToInt32(hdnorderdetailid_next.Value), Convert.ToInt32(hdnfabmasterid.Value), lblcolorprint.Text, Convert.ToInt32(ddlStage1.SelectedValue), Convert.ToInt32(ddlStage2.SelectedValue), Convert.ToInt32(ddlStage3.SelectedValue), Convert.ToInt32(ddlStage4.SelectedValue), Convert.ToBoolean(chkfinlized.Checked));
                                }
                                //for prevent postback page 
                               

                                ddlStagenext1.SelectedValue = ddlStage1.SelectedValue;
                                ddlStagenext2.SelectedValue = ddlStage2.SelectedValue;
                                ddlStagenext3.SelectedValue = ddlStage3.SelectedValue;
                                ddlStagenext4.SelectedValue = ddlStage4.SelectedValue;

                                ddlStage1.Enabled = false;
                                ddlStage2.Enabled = false;
                                ddlStage3.Enabled = false;
                                ddlStage4.Enabled = false;

                                ddlStagenext1.Enabled = false;
                                ddlStagenext2.Enabled = false;
                                ddlStagenext3.Enabled = false;
                                ddlStagenext4.Enabled = false;
                                chkfinlizednext.Checked = IsFin;
                                //end

                            }
                            

                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

                BindGrd();

                //}
                //else
                //{
                //    ShowAlert("You must have to select stage1");
                //    chkfinlized.Checked = false;
                //    return;
                //}
                //if (ddlStage1.SelectedValue != "-1")
                //{
                //   // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func('" + hdnfabmasterid.Value + "','" + ddlStage1.SelectedValue + "','" + lblcolorprint.Text + "','" + 1 + "','" + -1 + "','" + 0 + "','" + hdnstyleid.Value + "')", true);
                //    for (int i = 0; i < 3; i++)
                //    {
                //       // Server.Execute("FrmFabricWastageEntry.aspx?FabricQualityID=20&amp;FabType=1&amp;FabricDetails=FabricDetails&amp;IsExecute=FABRICVIEW&amp;cutwastage=4.5");

                //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func('" + hdnfabmasterid.Value + "','" + ddlStage1.SelectedValue + "','" + lblcolorprint.Text + "','" + 1 + "','" + -1 + "','" + 0 + "','" + hdnstyleid.Value + "','" + ddlStage2.SelectedValue + "','" + ddlStage3.SelectedValue + "','" + ddlStage4.SelectedValue + "','" + hdnorderdetailid.Value + "')", true);
                //    }
                //}
                //--------------Edit by surendra on Lock down crona virus spread time for Auto stock Allocated.................
                // result = Qcobj.AutoAllocate_Fabric_From_Stock(Convert.ToInt32(hdnorderdetailid.Value), Convert.ToInt32(hdnfabmasterid.Value), lblcolorprint.Text, Convert.ToInt32(ddlStage1.SelectedValue), Convert.ToInt32(ddlStage2.SelectedValue), Convert.ToInt32(ddlStage3.SelectedValue), Convert.ToInt32(ddlStage4.SelectedValue));
                //---------------End by surendra on Lock down crona virus spread time for Auto stock Allocated.................
                //BindGrd();
            }
            else
            {
                // BindGrd();
                //chkfinlized.Checked = false;

                if (ddlStage1.SelectedValue == "1")
                {
                    if (ddlStage2.SelectedValue != "-1")
                    {
                        if (ddlStage2.SelectedValue != "29")
                        {
                            ddlStage3.Items.FindByValue(ddlStage2.SelectedValue).Attributes["disabled"] = "disabled";
                            ddlStage4.Items.FindByValue(ddlStage2.SelectedValue).Attributes["disabled"] = "disabled";

                            ddlStage3.Items.FindByValue(ddlStage2.SelectedValue).Attributes["Class"] = "Unselected";
                            ddlStage4.Items.FindByValue(ddlStage2.SelectedValue).Attributes["Class"] = "Unselected";
                        }

                    }
                    if (ddlStage3.SelectedValue != "-1")
                    {
                        ddlStage4.Items.FindByValue(ddlStage3.SelectedValue).Attributes["disabled"] = "disabled";
                    }

                }

                else if (ddlStage1.SelectedValue == "10")
                {
                    foreach (int i in re)
                    {
                        ddlStage2.Items.FindByValue(i.ToString()).Attributes["disabled"] = "disabled";
                        ddlStage2.Items.FindByValue(i.ToString()).Attributes["Class"] = "Unselected";

                        if (i.ToString() != "29")
                        {
                            ddlStage3.Items.FindByValue(i.ToString()).Attributes["disabled"] = "disabled";
                            ddlStage3.Items.FindByValue(i.ToString()).Attributes["Class"] = "Unselected";

                            ddlStage4.Items.FindByValue(i.ToString()).Attributes["disabled"] = "disabled";
                            ddlStage4.Items.FindByValue(i.ToString()).Attributes["Class"] = "Unselected";
                        }

                    }



                    if (ddlStage2.SelectedValue != "-1")
                    {
                        if (ddlStage2.SelectedValue != "29")
                        {
                            ddlStage3.Items.FindByValue(ddlStage2.SelectedValue).Attributes["disabled"] = "disabled";
                            ddlStage4.Items.FindByValue(ddlStage2.SelectedValue).Attributes["disabled"] = "disabled";

                            ddlStage3.Items.FindByValue(ddlStage2.SelectedValue).Attributes["Class"] = "Unselected";
                            ddlStage4.Items.FindByValue(ddlStage2.SelectedValue).Attributes["Class"] = "Unselected";
                        }
                    }
                    if (ddlStage3.SelectedValue != "-1")
                    {

                        ddlStage4.Items.FindByValue(ddlStage3.SelectedValue).Attributes["disabled"] = "disabled";
                        if (ddlStage2.SelectedValue != "29")
                        {
                            ddlStage4.Items.FindByValue(ddlStage2.SelectedValue).Attributes["Class"] = "Unselected";
                        }
                    }


                }
                if (ddlStage1.SelectedValue == "-1")
                {
                    ddlStage2.SelectedValue = "-1";
                    ddlStage3.SelectedValue = "-1";
                    ddlStage4.SelectedValue = "-1";
                }
                if (ddlStage2.SelectedValue == "-1")
                {
                    ddlStage3.SelectedValue = "-1";
                    ddlStage4.SelectedValue = "-1";
                }
                if (ddlStage3.SelectedValue == "-1")
                {
                    ddlStage4.SelectedValue = "-1";
                }

                ddlStage1.Enabled = true;
                ddlStage2.Enabled = true;
                ddlStage3.Enabled = true;
                ddlStage4.Enabled = true;

                

                if (hdnIsSrvRecived.Value != "")
                {
                    if (Convert.ToInt32(hdnIsSrvRecived.Value) > 0)
                    {
                        if (ddlStage1.SelectedValue != "-1")
                        {
                            ddlStage1.Attributes["disabled"] = "disabled";
                            ddlStage1.ToolTip = "srv revised " + lblcolorprint.Text.Trim();
                        }
                    }
                }
                if (hdnIsSrvRecived2.Value != "")
                {
                    if (Convert.ToInt32(hdnIsSrvRecived2.Value) > 0)
                    {
                        if (ddlStage2.SelectedValue != "-1")
                        {
                            ddlStage2.Attributes["disabled"] = "disabled";
                            ddlStage2.ToolTip = "srv revised " + lblcolorprint.Text.Trim();
                        }
                    }
                }
                if (hdnIsSrvRecived3.Value != "")
                {
                    if (Convert.ToInt32(hdnIsSrvRecived3.Value) > 0)
                    {
                        if (ddlStage3.SelectedValue != "-1")
                        {
                            ddlStage3.Attributes["disabled"] = "disabled";
                            ddlStage3.ToolTip = "srv revised " + lblcolorprint.Text.Trim();
                        }
                    }
                }
                if (hdnIsSrvRecived4.Value != "")
                {
                    if (Convert.ToInt32(hdnIsSrvRecived4.Value) > 0)
                    {
                        if (ddlStage4.SelectedValue != "-1")
                        {
                            ddlStage4.Attributes["disabled"] = "disabled";
                            ddlStage4.ToolTip = "srv revised " + lblcolorprint.Text.Trim();
                        }
                    }
                }
                bool result_Allocation = Qcobj.AutoAllocate_Fabric_From_Stock(Convert.ToInt32(hdnorderdetailid.Value), Convert.ToInt32(hdnfabmasterid.Value), lblcolorprint.Text, Convert.ToInt32(ddlStage1.SelectedValue), Convert.ToInt32(ddlStage2.SelectedValue), Convert.ToInt32(ddlStage3.SelectedValue), Convert.ToInt32(ddlStage4.SelectedValue), Convert.ToBoolean(chkfinlized.Checked));
            }
            if (lblcolorprint.Text.Trim().ToLower() == "Tbd".ToLower())
            {
                ddlStage3.Enabled = false;
                ddlStage4.Enabled = false;
                ddlStage1.Items.FindByValue("10").Attributes["disabled"] = "disabled";
                foreach (int i in re)
                {
                    if (ddlStage1.SelectedValue == "1")
                    {
                        if (i != 29)
                        {
                            ddlStage2.Items.FindByValue(i.ToString()).Attributes["disabled"] = "disabled";
                        }
                       // ddlStage2.Enabled = true;
                    }
                    else if (ddlStage1.SelectedValue == "29" || ddlStage1.SelectedValue == "-1")
                    {
                        ddlStage2.SelectedValue = "-1";
                        ddlStage2.Items.FindByValue(i.ToString()).Attributes["disabled"] = "disabled";
                        ddlStage2.Enabled = false;
                    }
                }
            }
        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrd();
        }

    }
}