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

namespace iKandi.Web.Admin.ProductionAdmin
{
    public partial class WastageAdmin : System.Web.UI.Page
    {
        AdminController objadmincontroller = new AdminController();
        DataTable dtheader = new DataTable();
        DataTable dtss = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindGridViewValueadtion_Ws();

            bindgrd();
            BindGridViewCuttingWs();
        }

        public void BindGridViewCuttingWs()
        {
            DataSet ds = new DataSet();
            ds = objadmincontroller.GetWastageVAdetails();
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataTable dtVA = new DataTable();
            dtVA = ds.Tables[1];

            DataTable Temp = new DataTable();

            if (dtVA.Rows.Count > 0)
            {
                Temp = dtVA.AsEnumerable().Take(1).CopyToDataTable();


                dtVA = ds.Tables[1].DefaultView.ToTable(true, "Wastage_Id");
            }

            grdFoter.DataSource = (DataTable)Temp;

            dtss = ds.Tables[2];
            dtheader = ds.Tables[3];
            CreateHeader(dtss);
            if (dt.Rows.Count > 0)
            {
                grdWastgaeStatic.DataSource = dt;
                grdWastgaeStatic.DataBind();
            }
            if (Temp.Rows.Count > 0 && Temp != null)
            {
                grdVadynamic.DataSource = dtVA;
                grdVadynamic.DataBind();
            }
        }

        private void BindGridViewValueadtion_Ws()
        {
            OrderProcessController oOrderProcessController = new OrderProcessController();
            DataSet ds = new DataSet();
            ds = objadmincontroller.GetWastageVAdetails();
            DataTable dt = new DataTable();
            dt = ds.Tables[2];

            TemplateField oTemplateField = new TemplateField();
            hdnCountColoumn.Value = dt.Rows.Count.ToString();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    oTemplateField = new TemplateField();
                    oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    oTemplateField.ItemStyle.Width = 55;
                    grdVadynamic.Columns.Add(oTemplateField);
                }
                oTemplateField = new TemplateField();
                oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                oTemplateField.ItemStyle.Width = 55;
                grdVadynamic.Columns.Add(oTemplateField);
                oTemplateField = null;
            }

            if (dt.Rows.Count > 0)
            {
                oTemplateField = new TemplateField();
                oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                oTemplateField.ItemStyle.CssClass = "QtyFooter";
                grdFoter.Columns.Add(oTemplateField);

                oTemplateField = new TemplateField();
                oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                oTemplateField.ItemStyle.CssClass = "WastegeFooter";
                grdFoter.Columns.Add(oTemplateField);

                oTemplateField = new TemplateField();
                oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                oTemplateField.ItemStyle.CssClass = "WastegeFooter";
                grdFoter.Columns.Add(oTemplateField);

                oTemplateField = new TemplateField();
                oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                oTemplateField.ItemStyle.CssClass = "WastegeFooter";
                grdFoter.Columns.Add(oTemplateField);

                oTemplateField = new TemplateField();
                oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                oTemplateField.ItemStyle.CssClass = "WastegeFooter";
                grdFoter.Columns.Add(oTemplateField);

                oTemplateField = new TemplateField();
                oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                oTemplateField.ItemStyle.CssClass = "WastegeFooter";

                grdFoter.Columns.Add(oTemplateField); oTemplateField = new TemplateField();
                oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                oTemplateField.ItemStyle.CssClass = "WastegeFooter";

                grdFoter.Columns.Add(oTemplateField); oTemplateField = new TemplateField();
                oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                oTemplateField.ItemStyle.CssClass = "WastegeFooter";
                grdFoter.Columns.Add(oTemplateField);

                grdFoter.Columns.Add(oTemplateField); oTemplateField = new TemplateField();
                oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                oTemplateField.ItemStyle.CssClass = "WastegeFooter";
                grdFoter.Columns.Add(oTemplateField);


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    oTemplateField = new TemplateField();
                    oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    oTemplateField.ItemStyle.CssClass = "VaueNameFooter";
                    grdFoter.Columns.Add(oTemplateField);
                }

                oTemplateField = new TemplateField();
                oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                oTemplateField.ItemStyle.CssClass = "VaueNameFooter";
                grdFoter.Columns.Add(oTemplateField);
                oTemplateField = null;
            }

        }

        public void bindgrd()
        {
            DataSet ds = new DataSet();
            ds = objadmincontroller.GetWastageVAdetails();
            DataTable dt = new DataTable();
            dt = ds.Tables[2];
            var Temp = dt.AsEnumerable().Take(1).CopyToDataTable();

            grdFoter.DataSource = (DataTable)Temp;
            grdFoter.DataBind();

        }

        protected void grdWastgaeStatic_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtcuttingWastage = (TextBox)e.Row.FindControl("txtcuttingWastage");
                TextBox txtOrderingWastage = (TextBox)e.Row.FindControl("txtOrderingWastage");

                TextBox txtCutCMT = (TextBox)e.Row.FindControl("txtCutCMT");
                TextBox txtStitchCMT = (TextBox)e.Row.FindControl("txtStitchCMT");
                TextBox txtFinishCMT = (TextBox)e.Row.FindControl("txtFinishCMT");
                TextBox txtCMTOH = (TextBox)e.Row.FindControl("txtCMTOH");
                TextBox txtoverhead = (TextBox)e.Row.FindControl("txtoverhead");

                TextBox txtleadtimeday = (TextBox)e.Row.FindControl("txtleadtimeday");
                TextBox txtaccessoryWastage = (TextBox)e.Row.FindControl("txtaccessoryWastage");
                TextBox txtfabricWastage = (TextBox)e.Row.FindControl("txtfabricWastage");
                HiddenField hdnRowID = (HiddenField)e.Row.FindControl("hdnRowID");

                txtcuttingWastage.Attributes.Add("onkeypress", "return isNumberKeyWithdecimal(event)");
                txtOrderingWastage.Attributes.Add("onkeypress", "return isNumberKeyWithdecimal(event)");
                txtcuttingWastage.Attributes.Add("onchange", "UpdateVaWastageCutting(this," + 1 + "," + hdnRowID.Value + ");");
                txtOrderingWastage.Attributes.Add("onchange", "UpdateVaWastageOdering(this," + 2 + "," + hdnRowID.Value + ");");

                txtCutCMT.Attributes.Add("onchange", "UpdateCutCMT(this," + 3 + "," + hdnRowID.Value + ");");

                txtStitchCMT.Attributes.Add("onchange", "UpdateStitchCMT(this," + 4 + "," + hdnRowID.Value + ");");

                txtFinishCMT.Attributes.Add("onchange", "UpdateFinishCMT(this," + 5 + "," + hdnRowID.Value + ");");

                txtCMTOH.Attributes.Add("onchange", "UpdateCMTOH(this," + 6 + "," + hdnRowID.Value + ");");                

                txtoverhead.Attributes.Add("onchange", "UpdateOverHead(this," + 7 + "," + hdnRowID.Value + ");");

                txtleadtimeday.Attributes.Add("onchange", "UpdateLeadTime(this," + 8 + "," + hdnRowID.Value + ");");
            }
        }

        protected void grdVadynamic_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataSet ds = new DataSet();
            ds = objadmincontroller.GetWastageVAdetails();
            DataTable dt = new DataTable();
            dt = ds.Tables[2];
            try
            {
                OrderProcessController oOrderProcessController = new OrderProcessController();

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int i_count = 1;
                    DataSet dtva = new DataSet();
                    DataTable dts = new DataTable();

                    int WastageID = Convert.ToInt32((DataBinder.Eval(e.Row.DataItem, "Wastage_Id")).ToString());

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox txt = new TextBox();
                        HiddenField hdnVAId = new HiddenField();
                        HiddenField hdnwastageId = new HiddenField();

                        dtva = objadmincontroller.getVAWastageDetails_byID(Convert.ToInt32(dt.Rows[i]["ValueAdditionID"].ToString()), WastageID);
                        dts = dtva.Tables[0];

                        hdnVAId.ID = "hdnVAId_" + dt.Rows[i]["ValueAdditionID"].ToString();
                        try
                        {

                            hdnVAId.Value = dt.Rows[i]["ValueAdditionID"].ToString();
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                            System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                            hdnVAId.Value = dt.Rows[i]["ValueAdditionID"].ToString();
                            txt.ToolTip = dt.Rows[i]["ValueAdditionName"].ToString();

                        }


                        hdnwastageId.ID = "hdnwastageId_" + i.ToString();
                        hdnwastageId.Value = (DataBinder.Eval(e.Row.DataItem, "Wastage_Id")).ToString();

                        txt.CssClass = "Textalign";
                        txt.ID = "txtValueAddQty_" + i.ToString();
                        txt.Width = 45;
                        txt.MaxLength = 3;
                        txt.CssClass = "numeric-field-without-decimal-places Textalign";
                        txt.Attributes.Add("onkeypress", "return isNumberKeyWithdecimal(event)");
                        txt.Attributes.Add("onchange", "UpdateVaWastage(this," + hdnVAId.Value + "," + hdnwastageId.Value + ");");
                        try
                        {

                            txt.Text = dts.Rows[0]["ValueAdditionWastage"].ToString();
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                            System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                            txt.Text = "";
                        }
                        e.Row.Cells[i].Controls.Add(txt);
                        e.Row.Cells[i].Controls.Add(hdnVAId);
                        e.Row.Cells[i].Controls.Add(hdnwastageId);

                        i_count = i;

                    }
                    LinkButton lnkView = new LinkButton();
                    lnkView.ID = "lnkView";
                    lnkView.CssClass = "imagelinkDelete";
                    lnkView.ToolTip = "Delete record";
                    lnkView.Click += ViewDetails;
                    lnkView.OnClientClick = "return confirmation();";

                    lnkView.CommandArgument = (DataBinder.Eval(e.Row.DataItem, "Wastage_Id")).ToString();
                    e.Row.Cells[i_count + 1].Controls.Add(lnkView);
                }
                oOrderProcessController = null;
            }
            catch (Exception ex)
            {
                ShowAlert(ex.ToString());
            }
        }

        protected void ViewDetails(object sender, EventArgs e)
        {
            LinkButton lnkView = (sender as LinkButton);
            GridViewRow row = (lnkView.NamingContainer as GridViewRow);
            string id = lnkView.CommandArgument;

            int result = objadmincontroller.DeleteVAWastage(Convert.ToInt32(id));
            if (result > 0)
            {
                ShowAlert("Record Deleted.!");
                Response.Redirect("~/Admin/ProductionAdmin/WastageAdmin.aspx");
            }
        }

        protected void grdFoter_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int i_count = 0;
            DataSet ds = new DataSet();
            ds = objadmincontroller.GetWastageVAdetails();
            DataTable dt = new DataTable();
            dt = ds.Tables[2];

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txts = new TextBox();
                txts.ID = "txtfromQtyfoter";
                txts.Attributes.Add("Style", "width:50px !important");
                txts.MaxLength = 6;
                txts.ToolTip = "Qty Range from";

                Label lbld = new Label();
                lbld.ID = "dd";
                lbld.Text = " - ";

                txts.Attributes.Add("onkeypress", "return isNumberKey(event)");
                txts.CssClass = "numeric-field-without-decimal-places Textalign";
                e.Row.Cells[0].Controls.Add(txts);
                e.Row.Cells[0].Controls.Add(lbld);

                TextBox txtsto = new TextBox();
                txtsto.ID = "txttoQtyfoter";
                txtsto.Attributes.Add("Style", "width:45px !important");
                txtsto.MaxLength = 6;
                txtsto.ToolTip = "Qty Range from";
                txtsto.Attributes.Add("onkeypress", "return isNumberKey(event)");
                txtsto.CssClass = "numeric-field-without-decimal-places Textalign";
                e.Row.Cells[0].Controls.Add(txtsto);

                TextBox txtscutting = new TextBox();
                txtscutting.ID = "txtcuttingWastagefoter";
                txtscutting.Width = 45;
                txtscutting.MaxLength = 5;
                txtscutting.ToolTip = "Costing Wastage (%)";
                txtscutting.Attributes.Add("onkeypress", "return isNumberKeyWithdecimal(event)");
                txtscutting.CssClass = "numeric-field-with-decimal-places Textalign";
                e.Row.Cells[1].Controls.Add(txtscutting);

                TextBox txtOrdering = new TextBox();
                txtOrdering.ID = "txtOrderingWastagefoter";
                txtOrdering.Width = 45;
                txtOrdering.MaxLength = 5;
                txtOrdering.ToolTip = "Ordering Cut Wastage (%)";
                txtOrdering.Attributes.Add("onkeypress", "return isNumberKeyWithdecimal(event)");
                txtOrdering.CssClass = "numeric-field-with-decimal-places Textalign";
                e.Row.Cells[2].Controls.Add(txtOrdering);

                TextBox txtCutCMTT = new TextBox();
                txtCutCMTT.ID = "txtCutCMTfoter";
                txtCutCMTT.Width = 45;
                txtCutCMTT.MaxLength = 5;
                txtCutCMTT.ToolTip = "CutCMT";
                txtCutCMTT.Attributes.Add("onkeypress", "return isNumberKeyWithdecimal(event)");
                txtCutCMTT.CssClass = "numeric-field-with-decimal-places Textalign";
                e.Row.Cells[3].Controls.Add(txtCutCMTT);

                TextBox txtStitchCMTT = new TextBox();
                txtStitchCMTT.ID = "txtStitchCMTfoter";
                txtStitchCMTT.Width = 45;
                txtStitchCMTT.MaxLength = 5;
                txtStitchCMTT.ToolTip = "Stitch CMT";
                txtStitchCMTT.Attributes.Add("onkeypress", "return isNumberKeyWithdecimal(event)");
                txtStitchCMTT.CssClass = "numeric-field-with-decimal-places Textalign";
                e.Row.Cells[4].Controls.Add(txtStitchCMTT);

                TextBox txtFinishCMTT = new TextBox();
                txtFinishCMTT.ID = "txtFinishCMTfoter";
                txtFinishCMTT.Width = 45;
                txtFinishCMTT.MaxLength = 5;
                txtFinishCMTT.ToolTip = "FinishCMTfoter";
                txtFinishCMTT.Attributes.Add("onkeypress", "return isNumberKeyWithdecimal(event)");
                txtFinishCMTT.CssClass = "numeric-field-with-decimal-places Textalign";
                e.Row.Cells[5].Controls.Add(txtFinishCMTT);

                TextBox txtCMTOHH = new TextBox();
                txtCMTOHH.ID = "txtCMTOHfoter";
                txtCMTOHH.Width = 45;
                txtCMTOHH.MaxLength = 5;
                txtCMTOHH.ToolTip = "FinishCMTfoter";
                txtCMTOHH.Attributes.Add("onkeypress", "return isNumberKeyWithdecimal(event)");
                txtCMTOHH.CssClass = "numeric-field-with-decimal-places Textalign";
                e.Row.Cells[6].Controls.Add(txtCMTOHH);

                TextBox txtoverheadd = new TextBox();
                txtoverheadd.ID = "txtOverheadfoter";
                txtoverheadd.Width = 45;
                txtoverheadd.MaxLength = 5;
                txtoverheadd.ToolTip = "Overheadfoter";
                txtoverheadd.Attributes.Add("onkeypress", "return isNumberKeyWithdecimal(event)");
                txtoverheadd.CssClass = "numeric-field-with-decimal-places Textalign";
                e.Row.Cells[7].Controls.Add(txtoverheadd);

                TextBox txtleadday = new TextBox();
                txtleadday.ID = "txtleaddayfoter";
                txtleadday.Width = 45;
                txtleadday.MaxLength = 2;
                txtleadday.ToolTip = "lead time day (%)";
                txtleadday.Attributes.Add("onkeypress", "return isNumberKeyWithdecimal(event)");
                txtleadday.CssClass = "numeric-field-without-decimal-places Textalign";
                e.Row.Cells[8].Controls.Add(txtleadday);


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox txt = new TextBox();
                    HiddenField hdnVAIdfoter = new HiddenField();
                    hdnVAIdfoter.ID = "hdnVAId_" + dt.Rows[i]["ValueAdditionID"].ToString();
                    hdnVAIdfoter.Value = dt.Rows[i]["ValueAdditionID"].ToString();
                    txt.ToolTip = dt.Rows[i]["ValueAdditionName"].ToString();
                    txt.ID = "txtValueAddQtyfoter_" + dt.Rows[i]["ValueAdditionID"].ToString();
                    txt.Width = 45;
                    txt.MaxLength = 3;
                    txt.Attributes.Add("onkeypress", "return isNumberKey(event)");
                    txt.TextChanged += AddDetails;
                    txt.CssClass = "numeric-field-without-decimal-places Textalign";

                    e.Row.Cells[i + 9].Controls.Add(txt);
                    e.Row.Cells[i + 9].Controls.Add(hdnVAIdfoter);

                    i_count = i + 10;
                }

                LinkButton lnkViewADD = new LinkButton();
                lnkViewADD.ID = "lnkView";
                lnkViewADD.CssClass = "imagelinkAdd";
                lnkViewADD.ToolTip = "Add record";
                lnkViewADD.Click += AddDetails;
                e.Row.Cells[i_count].Controls.Add(lnkViewADD);
            }

        }

        public void updateVaWastage(object sender, EventArgs e)
        {
            LinkButton lnkView = (sender as LinkButton);
            GridViewRow row = (lnkView.NamingContainer as GridViewRow);
            string id = lnkView.CommandArgument;
        }

        public static int ToInt32(String value)
        {
            if (String.IsNullOrEmpty(value))
                return 0;
            return Int32.Parse(value, CultureInfo.CurrentCulture);
        }

        protected void AddDetails(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkView = (sender as LinkButton);

                foreach (GridViewRow row in grdFoter.Rows)
                {
                    int Result;
                    TextBox txtfromQtyfoter = (TextBox)row.FindControl("txtfromQtyfoter");
                    TextBox txttoQtyfoter = (TextBox)row.FindControl("txttoQtyfoter");
                    TextBox txtcuttingWastagefoter = (TextBox)row.FindControl("txtcuttingWastagefoter");
                    TextBox txtOrderingWastagefoter = (TextBox)row.FindControl("txtOrderingWastagefoter");

                    TextBox txtCutCMTfoter = (TextBox)row.FindControl("txtCutCMTfoter");

                    TextBox txtStitchCMTfoter = (TextBox)row.FindControl("txtStitchCMTfoter");

                    TextBox txtFinishCMTfoter = (TextBox)row.FindControl("txtFinishCMTfoter");

                    TextBox txtCMTOHfoter = (TextBox)row.FindControl("txtCMTOHfoter");

                    TextBox txtOverheadfoter = (TextBox)row.FindControl("txtOverheadfoter");

                    TextBox txtleaddayfoter = (TextBox)row.FindControl("txtleaddayfoter");

                    //TextBox txtAccWastageFooter = (TextBox)row.FindControl("txtAccWastageFooter");
                    //TextBox txtFabricWastageFooter = (TextBox)row.FindControl("txtFabricWastageFooter");


                    if (txtfromQtyfoter.Text == "")
                    {
                        ShowAlert("Enter from qnty.");
                        return;
                    }
                    if (txttoQtyfoter.Text == "")
                    {
                        ShowAlert("Enter to qnty.");
                        return;
                    }
                    if (txtcuttingWastagefoter.Text == "")
                    {
                        ShowAlert("Enter Costing wastage qnty.");
                        return;
                    }

                    if (txtOrderingWastagefoter.Text == "")
                    {
                        ShowAlert("Enter Ordering Cut wastage qnty.");
                        return;
                    }

                    if (txtCutCMTfoter.Text == "")
                    {
                        ShowAlert("Enter CutCMT Value.");
                        return;
                    }

                    if (txtStitchCMTfoter.Text == "")
                    {
                        ShowAlert("Enter StitchCMT Value.");
                        return;
                    }

                    if (txtFinishCMTfoter.Text == "")
                    {
                        ShowAlert("Enter Finish Value.");
                        return;
                    }

                    if (txtCMTOHfoter.Text == "")
                    {
                        ShowAlert("Enter CMTOH Value.");
                        return;
                    }

                    if (txtOverheadfoter.Text == "")
                    {
                        ShowAlert("Enter Overhead Value.");
                        return;
                    }

                    if (txtleaddayfoter.Text == "")
                    {
                        ShowAlert("Enter lead day Value.");
                        return;
                    }
                    //if (txtAccWastageFooter.Text == "")
                    //{
                    //    ShowAlert("Enter accessory wastage Value.");
                    //    return;
                    //} if (txtFabricWastageFooter.Text == "")
                    //{
                    //    ShowAlert("Enter fabric wastage Value.");
                    //    return;
                    //}
                    int from = ToInt32(txtfromQtyfoter.Text);
                    int to = ToInt32(txttoQtyfoter.Text);

                    if (from > to)
                    {
                        ShowAlert("Enter from qnty and to qnty in sequence .");
                        return;
                    }
                    if (from < 1 || to < 0)
                    {
                        ShowAlert("Enter valid from qnty and to qnty  .");
                        return;
                    }
                    int ResultVA;
                    int WastageID;
                    bool flag;
                    Result = objadmincontroller.InsertVaWatageDetails(Convert.ToInt32(txtfromQtyfoter.Text), Convert.ToInt32(txttoQtyfoter.Text), Convert.ToDecimal(txtcuttingWastagefoter.Text), Convert.ToDecimal(txtOrderingWastagefoter.Text), Convert.ToDecimal(txtCutCMTfoter.Text), Convert.ToDecimal(txtStitchCMTfoter.Text), Convert.ToDecimal(txtFinishCMTfoter.Text), Convert.ToDecimal(txtCMTOHfoter.Text), Convert.ToDecimal(txtOverheadfoter.Text), Convert.ToInt32(txtleaddayfoter.Text), "CUTTINGWASTAGE", out WastageID);


                    if (Result > 0)
                    {

                        ShowAlert("Details Saved Succefully.");
                        flag = true;

                    }
                    else if (Result == -1)
                    {
                        ShowAlert("Enterd wastage from and to qty value already exist");
                        flag = false;
                        return;
                    }
                    else
                    {
                        ShowAlert("Record not check please check in");
                        flag = false;
                        return;
                    }

                    for (int i = 0; i < grdFoter.Columns.Count - 6; i++)
                    {
                        string wastage = "";
                        string VdID = dtss.Rows[i]["ValueAdditionID"].ToString();
                        TextBox txt = ((TextBox)row.FindControl("txtValueAddQtyfoter_" + VdID));
                        HiddenField hdVAID = ((HiddenField)row.FindControl("hdnVAId_" + VdID));
                        if (txt.Text == "")
                        {
                            wastage = "0";
                        }
                        else
                        {
                            wastage = Convert.ToSingle(txt.Text).ToString();
                            if (WastageID > 0 && Convert.ToInt32(hdVAID.Value) > 0)
                            {
                                ResultVA = objadmincontroller.InsertVaWatageDetails_VA(WastageID, Convert.ToInt32(hdVAID.Value), Convert.ToSingle(wastage), "CUTTINGWASTAGE_VA");

                            }

                        }


                    }
                    if (flag == true)
                    {
                        Response.Redirect("~/Admin/ProductionAdmin/WastageAdmin.aspx",true);
                    }

                }

            }
            catch (Exception ex)
            {
                ShowAlert(ex.ToString());
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        public void CreateHeader(DataTable dt)
        {            
            int Width = 390 + dt.Rows.Count * 55 + 56;
            tblMain.Width = Width.ToString();
            grdFoter.Attributes.Add("style", "width:" + Width + "px");
            var html = "";
            html += "<table class='item_list' cellpadding='0' cellspacing='0' style='min-width:" + Width + "px;',max-width:" + Width + "px;'>";
            html += "<thead>";
            html += "<tr>";
            html += "<th rowspan='3'  style='text-transform:capitalize;min-width:150px;max-width:150px;'>" + "Qty Range" + "</th>";
            html += "<th rowspan='3'  style='text-transform:capitalize;min-width:60px;max-width:60px;'>" + "Costing Cut Wastage (%)" + "</th>";
            html += "<th rowspan='3'  style='text-transform:capitalize;min-width:60px;max-width:60px;'>" + "Ordering Cut Wastage (%)" + "</th>";
            html += "<th rowspan='3' style='text-transform:capitalize;min-width:60px;max-width:60px;'>" + "Cut CMT" + "</th>";
            html += "<th rowspan='3' style='text-transform:capitalize;min-width:60px;max-width:60px;'>" + "Stitch CMT" + "</th>";
            html += "<th rowspan='3' style='text-transform:capitalize;min-width:60px;max-width:60px;'>" + "Finish CMT" + "</th>";
            html += "<th rowspan='3' style='text-transform:capitalize;min-width:60px;max-width:60px;'>" + "CMT OH" + "</th>";
            html += "<th rowspan='3' style='text-transform:capitalize;min-width:60px;max-width:60px;'>" + "Overhead" + "</th>";
            html += "<th rowspan='3' style='text-transform:capitalize;min-width:60px;max-width:60px;'>" + "PCD Lead time(Day)" + "</th>";    
            html += "<th style='text-transform:capitalize;' colspan='" + dt.Rows.Count + "'>" + "VA Wastage %" + "</th>";
            html += "<th style='text-transform:capitalize;min-width:56px;max-width:56px' rowspan='3'>" + "Action" + "</th>";
            html += "</tr>";
            html += "<tr>";

            foreach (DataRow dtRow in dtheader.Rows)
            {
                html += "<th style='text-transform:capitalize; min-width:55px;max-width:55px;'  colspan='" + dtRow["grpcount"].ToString() + "' class='boldCell'>" + dtRow["StatusName"].ToString() + "</th>";
            }
            html += "<tr>";

            foreach (DataRow dtRow in dt.Rows)
            {
                html += "<th style='text-transform:capitalize; min-width:55px;max-width:55px;word-wrap: break-word;' class='boldCell'>" + dtRow["ValueAdditionName"].ToString() + "</th>";
            }

            html += "</tr>";
            html += "</thead>";
            html += "</table>";
            lbld.Text = html;
        }
    }
}