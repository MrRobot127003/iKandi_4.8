using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web.UserControls.Forms
{
    public partial class ReAllcationForm : BaseUserControl
    {
        public int styleId
        {
            get;
            set;
        }

        public string remark
        {
            get;
            set;
        }
        public string exfactorydate
        {
            get;
            set;
        }
        public string stylenumber
        {
            get;
            set;
        }
        public int OrderDetailId
        {
            get;
            set;
        }

        iKandi.BLL.OrderController ord = new BLL.OrderController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (null != Request.QueryString["styleId"])
            {
                styleId = Convert.ToInt32(Request.QueryString["styleId"]);
            }
            if (null != Request.QueryString["OrderDetailId"])
            {
                OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"]);
            }
            if (null != Request.QueryString["exfactorydate"])
            {
                exfactorydate = Request.QueryString["exfactorydate"].ToString();
            }
            if (null != Request.QueryString["stylenumber"])
            {
                stylenumber = Request.QueryString["stylenumber"].ToString();
            }
            if (!IsPostBack)
            {
                BindControl();
            }
        }

        public void BindControl()
        {
            List<MoShippingDetail> ds = this.OrderControllerInstance.GetReAllocationDetails(styleId, 0, 59);
            lblStyleNumber.Text = ds.Count > 0 ? ds[0].StyleNumber.ToString() : "";
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].Remarks.ToString() != "")
                {
                    lblShowRemark.Text += ds[i].Remarks.ToString() + ",<br />";
                }
            }
            lblShowRemark.Text = lblShowRemark.Text.TrimEnd('>').TrimEnd('/').TrimEnd(' ').TrimEnd('r').TrimEnd('b').TrimEnd('<').TrimEnd(',');
            lblShowRemark.Text = lblShowRemark.Text.Replace("~", "<br />");
            gvReAllocation.DataSource = ds;
            gvReAllocation.DataBind();
        }

        protected void gvReAllocation_rowdatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            gvReAllocation.HeaderRow.Cells[10].Text = "<table cellpadding='0' cellspacing='0' width='100%' style='height:100%;'><tr><th style='border-right:1px solid white; color:#FFFFFF; font-Size: 12px; font-family: Arial; width:19%;' height='100%'>Factory</th><th style='border-right:1px solid white; color:#FFFFFF; font-Size: 12px; font-family: Arial; width:19%;' height='100%'>Not Loaded</th><th style='border-right:1px solid white; font-Size: 12px; color:#FFFFFF; font-family: Arial; width:19%;' height='100%'>Cutting</th><th style='border-right:1px solid white; color:#FFFFFF; font-Size: 12px; font-family: Arial; width:19%;' height='100%'>Stitching</th><th style='border-right:1px solid white; font-Size: 12px; color:#FFFFFF; font-family: Arial; width:19%;' height='100%'>Finishing</th><th style='border-right:0px solid black; width:5%;' height='100%'></th></tr></table>";

            MoShippingDetail od = (e.Row.DataItem as MoShippingDetail);
            e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml(od.ExFactoryColor);
            GridView gvChildReallocation = (GridView)e.Row.FindControl("gvChildReallocation");
            ImageButton imgbtnAdd = (ImageButton)e.Row.FindControl("imgbtnAdd");
            RadioButtonList rbtnPartialFull = (RadioButtonList)e.Row.FindControl("rbtnPartialFull");
            HiddenField hdnOrderDetailsId = (HiddenField)e.Row.FindControl("hdnOrderDetailsId");
            CheckBox cb = (CheckBox)e.Row.FindControl("cb");

            HtmlAnchor txtQuantity = (HtmlAnchor)e.Row.FindControl("txtQuantity");
            DropDownList ddlchecker = (DropDownList)e.Row.FindControl("ddlchecker");
            int OrderDetailsId = 0;

            DataSet dsAllocation = new DataSet();
            OrderDetailsId = Convert.ToInt32(hdnOrderDetailsId.Value);
            dsAllocation = ord.GetReAllocationDetailsById(OrderDetailsId, 0);

           

            txtQuantity.HRef = "/Internal/Merchandising/AllocatedWithFactory.aspx?OrderDetailId=" + OrderDetailsId + "&StyleId=" + styleId;

            gvChildReallocation.DataSource = dsAllocation.Tables[0];
            gvChildReallocation.DataBind();

            DataTable dtQcChecker = dsAllocation.Tables[8];
            ViewState["dtQcChecker"] = dtQcChecker;

            if (ViewState["dtQcChecker"] != null)
            {
                dtQcChecker = (DataTable)ViewState["dtQcChecker"];
                if (dtQcChecker.Rows.Count > 0)
                {
                    ddlchecker.DataSource = dtQcChecker;
                    ddlchecker.DataTextField = "firstname";
                    ddlchecker.DataValueField = "UserID";
                    ddlchecker.DataBind();
                }
            }
                 


            if (dsAllocation.Tables[1].Rows.Count > 0)
            {
                bool IsPartialOrFull = Convert.ToBoolean(dsAllocation.Tables[1].Rows[0]["IsPartialOrFull"]);
                bool IsRealocationFull = Convert.ToBoolean(dsAllocation.Tables[1].Rows[0]["IsRealocationFull"]);
                if (IsPartialOrFull == true)
                {
                    rbtnPartialFull.SelectedValue = "1";
                    imgbtnAdd.Visible = true;
                }
                else
                {
                    rbtnPartialFull.SelectedValue = "0";
                    imgbtnAdd.Visible = false;
                }
                if (IsRealocationFull == true)
                {
                    cb.Checked = true;
                }
                else
                {
                    cb.Checked = false;
                }
            }
            else
            {
                rbtnPartialFull.SelectedValue = "0";
                cb.Checked = false;
                imgbtnAdd.Visible = false;
            }

            if (cb.Checked == false)
            {
                imgbtnAdd.Enabled = false;
                rbtnPartialFull.Enabled = false;
                gvChildReallocation.Enabled = false;
                for (int i = 0; i < gvChildReallocation.Rows.Count; i++)
                {
                    HtmlAnchor txtStitching1 = (HtmlAnchor)gvChildReallocation.Rows[i].FindControl("txtStitching1");
                    txtStitching1.Attributes.Add("class", "disable");
                }
            }
            else
            {
                imgbtnAdd.Enabled = true;
                rbtnPartialFull.Enabled = true;
                gvChildReallocation.Enabled = true;
                for (int i = 0; i < gvChildReallocation.Rows.Count; i++)
                {
                    HtmlAnchor txtStitching1 = (HtmlAnchor)gvChildReallocation.Rows[i].FindControl("txtStitching1");
                    txtStitching1.Attributes.Add("class", "enable");
                }
            }
        }

        protected void gvReAllocation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddNew")
            {
                bool IsStichingunallocated = false;
                DataTable dtReAllocationUnit = ord.GetReAllocationUnit(0, 0).Tables[0];
                int id = int.Parse(e.CommandArgument.ToString());
                GridView gvChildReallocation = (GridView)gvReAllocation.Rows[id].FindControl("gvChildReallocation");

                for (int i = 0; i < gvChildReallocation.Rows.Count; i++)
                {
                    DropDownList ddlFactory = (DropDownList)gvChildReallocation.Rows[i].FindControl("ddlFactory");
                    TextBox txtCutting = (TextBox)gvChildReallocation.Rows[i].FindControl("txtCutting");
                    TextBox txtStitching = (TextBox)gvChildReallocation.Rows[i].FindControl("txtStitching");
                    TextBox txtFinishing = (TextBox)gvChildReallocation.Rows[i].FindControl("txtFinishing");
                    TextBox txtStichingunallocated = (TextBox)gvChildReallocation.Rows[i].FindControl("txtStichingunallocated");
                    HiddenField hdnReAllocation = (HiddenField)gvChildReallocation.Rows[i].FindControl("hdnReAllocation");
                    HiddenField hdnlineQty = (HiddenField)gvChildReallocation.Rows[i].FindControl("hdnlineQty");
                    HiddenField hdnorderdetail = (HiddenField)gvChildReallocation.Rows[i].FindControl("hdnorderdetail");
                    HiddenField hdnunitid = (HiddenField)gvChildReallocation.Rows[i].FindControl("hdnunitid");
                    HiddenField hdnStitching = (HiddenField)gvChildReallocation.Rows[i].FindControl("hdnStitching");

                    if (Convert.ToInt32(txtStichingunallocated.Text) == 0 && IsStichingunallocated == false)
                    {
                        Page page = HttpContext.Current.Handler as Page;
                        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('You cannot add row because Unallocated Quantity is empty. ');", true);
                        return;
                    }
                    else
                    {
                        IsStichingunallocated = true;
                    }

                    if (txtCutting.Text == "" && txtStitching.Text == "" && txtFinishing.Text == "")
                    {
                        Page page = HttpContext.Current.Handler as Page;
                        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Blank row need to be filled first.');", true);
                        return;
                    }
                }

                if ((dtReAllocationUnit.Rows.Count - 1) == gvChildReallocation.Rows.Count)
                {
                    Page page = HttpContext.Current.Handler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('You cannot add rows more than Factory count.');", true);
                    return;
                }
                else
                {
                    DataTable dtnew = new DataTable();
                    DataTable dtmerge = new DataTable();

                    dtnew = gridTable(gvChildReallocation);
                    DataRow newrow = dtnew.NewRow();
                    dtnew.Rows.Add(newrow);
                    dtmerge = dtnew;

                    gvChildReallocation.DataSource = dtmerge;
                    gvChildReallocation.DataBind();
                }
            }
        }

        private DataTable gridTable(GridView grdTable)
        {
            DataTable dtChildReallocation = new DataTable();

            dtChildReallocation.Columns.Add("Factory");
            dtChildReallocation.Columns.Add("UnAllocatedQty");
            dtChildReallocation.Columns.Add("Cutting");
            dtChildReallocation.Columns.Add("Stitching");
            dtChildReallocation.Columns.Add("Finishing");
            dtChildReallocation.Columns.Add("ReallocationID");
            dtChildReallocation.Columns.Add("LineQty");
            dtChildReallocation.Columns.Add("OrderDetailID");
            dtChildReallocation.Columns.Add("UnitID");
            dtChildReallocation.Columns.Add("DoneStitching");

            foreach (GridViewRow row in grdTable.Rows)
            {
                DataRow dr = dtChildReallocation.NewRow();

                DropDownList ddlFactory = (DropDownList)row.Cells[0].FindControl("ddlFactory");
                TextBox txtStichingunallocated = (TextBox)row.Cells[1].FindControl("txtStichingunallocated");
                TextBox txtCutting = (TextBox)row.Cells[2].FindControl("txtCutting");
                TextBox txtStitching = (TextBox)row.Cells[3].FindControl("txtStitching");
                HtmlAnchor txtStitching1 = (HtmlAnchor)row.Cells[3].FindControl("txtStitching1");
                //TextBox txtStitching1 = (TextBox)row.Cells[3].FindControl("txtStitching1");
                TextBox txtFinishing = (TextBox)row.Cells[4].FindControl("txtFinishing");
                HiddenField hdnReAllocation = (HiddenField)row.Cells[4].FindControl("hdnReAllocation");
                HiddenField hdnlineQty = (HiddenField)row.Cells[4].FindControl("hdnlineQty");
                HiddenField hdnorderdetail = (HiddenField)row.Cells[4].FindControl("hdnorderdetail");
                HiddenField hdnunitid = (HiddenField)row.Cells[4].FindControl("hdnunitid");
                HiddenField hdnStitching = (HiddenField)row.Cells[4].FindControl("hdnStitching");

                string sStitching = txtStitching1.InnerHtml.Replace("<div align=\"center\" style=\"width:98%; height:100%; background-color:#A8D9A1;\">", "").Replace("</div>", "").Trim();

                dr["Factory"] = ddlFactory.Text;
                dr["UnAllocatedQty"] = txtStichingunallocated.Text;

                dr["Cutting"] = txtCutting.Text;
                if (txtStitching.Visible)
                {
                    dr["Stitching"] = txtStitching.Text;
                }
                else
                {
                    dr["Stitching"] = sStitching;
                }
                dr["Finishing"] = txtFinishing.Text;
                dr["ReallocationID"] = hdnReAllocation.Value;
                dr["LineQty"] = hdnlineQty.Value;
                dr["OrderDetailID"] = hdnorderdetail.Value;
                dr["UnitID"] = hdnunitid.Value;
                dr["DoneStitching"] = hdnStitching.Value;

                dtChildReallocation.Rows.Add(dr);
            }
            return dtChildReallocation;
        }

        protected void rbtnPartialFull_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((RadioButtonList)sender).NamingContainer as GridViewRow;
            GridView gvChildReallocation = (GridView)row.FindControl("gvChildReallocation");
            RadioButtonList rbtnPartialFull = (RadioButtonList)row.FindControl("rbtnPartialFull");
            ImageButton imgbtnAdd = (ImageButton)row.FindControl("imgbtnAdd");
            int radiobuttonVal = Convert.ToInt32(rbtnPartialFull.SelectedValue);

            if (radiobuttonVal == 1)
            {
                imgbtnAdd.Visible = true;
            }
            if (radiobuttonVal == 0)
            {
                if (gvChildReallocation.Rows.Count > 1)
                {
                    rbtnPartialFull.SelectedValue = "1";
                    Page page = HttpContext.Current.Handler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('You cannot select Full because it is already divided into two or more than factories.');", true);
                }
                else
                {
                    imgbtnAdd.Visible = false;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvReAllocation.Rows.Count; i++)
                {
                    CheckBox CheckHeader = (CheckBox)gvReAllocation.HeaderRow.FindControl("CheckHeader");

                    RadioButtonList rbtnPartialFull = (RadioButtonList)gvReAllocation.Rows[i].FindControl("rbtnPartialFull");
                    HiddenField hdnOrderDetailsId = (HiddenField)gvReAllocation.Rows[i].FindControl("hdnOrderDetailsId");
                    GridView gvChildReallocation = (GridView)gvReAllocation.Rows[i].FindControl("gvChildReallocation");
                    CheckBox cb = (CheckBox)gvReAllocation.Rows[i].FindControl("cb");
                    ImageButton imgbtnAdd = (ImageButton)gvReAllocation.Rows[i].FindControl("imgbtnAdd");

                    //TextBox txtbconqty = (TextBox)gvReAllocation.Rows[i].Cells[3].FindControl("txtQuantity");
                    HtmlAnchor txtQuantity = (HtmlAnchor)gvReAllocation.Rows[i].Cells[3].FindControl("txtQuantity");
                    string sQuantity = txtQuantity.InnerHtml.Replace("<div style=\"width:95%; height:100%;\">", "").Replace("</div>", "").Trim();
                    bool Validate = Validation(gvChildReallocation, Convert.ToInt32(sQuantity));

                    int RedioListVal = Convert.ToInt32(rbtnPartialFull.SelectedValue);
                    bool RedioVal = false;

                    int OrderDetailsId = 0;
                    if (hdnOrderDetailsId != null)
                    {
                        OrderDetailsId = Convert.ToInt32(hdnOrderDetailsId.Value);
                    }

                    if (RedioListVal == 1)
                    {
                        RedioVal = true;
                    }
                    bool IsRealocationFull = false;
                    if (cb.Checked == true)
                    {
                        IsRealocationFull = true;
                    }

                    if (Validate)
                    {
                        Response.Write(Validate);
                        int UserID = ApplicationHelper.LoggedInUser.UserData.UserID;
                        ord.SaveReAllocationPartialOrFull(OrderDetailsId, RedioVal, IsRealocationFull);
                        for (int j = 0; j < gvChildReallocation.Rows.Count; j++)
                        {
                            DropDownList ddlFactory = (DropDownList)gvChildReallocation.Rows[j].FindControl("ddlFactory");
                            TextBox txtCutting = (TextBox)gvChildReallocation.Rows[j].FindControl("txtCutting");
                            TextBox txtStitching = (TextBox)gvChildReallocation.Rows[j].FindControl("txtStitching");
                            TextBox txtFinishing = (TextBox)gvChildReallocation.Rows[j].FindControl("txtFinishing");
                            HiddenField hdnReAllocation = (HiddenField)gvChildReallocation.Rows[j].FindControl("hdnReAllocation");
                            HtmlAnchor txtStitching1 = (HtmlAnchor)gvChildReallocation.Rows[j].FindControl("txtStitching1");
                            //TextBox txtStitching1 = (TextBox)gvChildReallocation.Rows[j].FindControl("txtStitching1");
                            TextBox txtStichingUnallocated = (TextBox)gvChildReallocation.Rows[j].FindControl("txtStichingunallocated");

                            int FactoryId = 0, Cutting = 0, Stitching = 0, Finishing = 0, ReAllocationId = 0;

                            string sStitching = txtStitching1.InnerHtml.Replace("<div align=\"center\" style=\"width:98%; height:100%; background-color:#A8D9A1;\">", "").Replace("</div>", "").Trim();

                            if (hdnReAllocation != null)
                            {
                                if (hdnReAllocation.Value != "")
                                {
                                    ReAllocationId = Convert.ToInt32(hdnReAllocation.Value);
                                }
                            }

                            if (ddlFactory.SelectedValue != "-1")
                            {
                                FactoryId = Convert.ToInt32(ddlFactory.SelectedValue);
                            }
                            if (txtCutting.Text != "")
                            {
                                Cutting = Convert.ToInt32(txtCutting.Text.Trim());
                            }

                            txtStichingUnallocated.Text = txtStichingUnallocated.Text == "" ? "0" : txtStichingUnallocated.Text;

                            if (txtStitching.Text != "" && txtStitching.Visible && !(txtStitching1.Visible))
                            {
                                Stitching = Stitching + Convert.ToInt32(txtStitching.Text.Trim());
                            }
                            else if (sStitching != "" && !(txtStitching.Visible) && txtStitching1.Visible)
                            {
                                Stitching = Stitching + Convert.ToInt32(sStitching);
                                //if (Convert.ToInt32(txtStichingUnallocated.Text.Trim()) > 0 && sStitching != txtStichingUnallocated.Text.Trim() && gvChildReallocation.Rows.Count == 1)
                                //{
                                //  Stitching = Stitching + (Convert.ToInt32(sStitching) - Convert.ToInt32(txtStichingUnallocated.Text.Trim()));
                                //}
                                //else if (Convert.ToInt32(txtStichingUnallocated.Text.Trim()) > 0)
                                //{
                                //  Stitching = Stitching + (Convert.ToInt32(sStitching) - Convert.ToInt32(txtStichingUnallocated.Text.Trim()));
                                //}
                                //else
                                //{
                                //  Stitching = Stitching + Convert.ToInt32(sStitching);
                                //}
                            }
                            if (txtFinishing.Text != "")
                            {
                                Finishing = Convert.ToInt32(txtFinishing.Text.Trim());
                            }
                            //-----------Add By Prabhaker-----------------------//

                            TextBox txtTdyCutReady = (TextBox)gvChildReallocation.Rows[j].FindControl("txtTdyCutReady");
                            TextBox txtTdyCutIssueOutHouse = (TextBox)gvChildReallocation.Rows[j].FindControl("txtTdyCutIssueOutHouse");
                            //TextBox txtOutHouseManpower = (TextBox)gvChildReallocation.Rows[j].FindControl("txtOutHouseManpower");
                           // TextBox txtOutHouseQc = (TextBox)gvChildReallocation.Rows[j].FindControl("txtOutHouseQc");
                            //TextBox txtOutHouseQcChecker = (TextBox)gvChildReallocation.Rows[j].FindControl("txtOutHouseQcChecker");
                            DropDownList ddlchecker = (DropDownList)gvChildReallocation.Rows[j].FindControl("ddlchecker");
                            CheckBox chkIsOHStitchComplete = (CheckBox)gvChildReallocation.Rows[j].FindControl("chkIsOHStitchComplete");


                            int TdyCutReady = 0, TdyCutIssueOutHouse = 0;
                            bool IsOHStitchComplete = false;
                            // string OutHouseQc, OutHouseQcChecker;

                            if (txtTdyCutReady.Text != "")
                                TdyCutReady = Convert.ToInt32(txtTdyCutReady.Text);
                            if (txtTdyCutIssueOutHouse.Text != "")
                                TdyCutIssueOutHouse = Convert.ToInt32(txtTdyCutIssueOutHouse.Text);
                            //if (txtOutHouseManpower.Text != "")
                            //    OutHouseManpower = Convert.ToInt32(txtOutHouseManpower.Text);

                            //if (!string.IsNullOrEmpty(txtOutHouseQc.Text))
                            //string OutHouseQc = txtOutHouseQc.Text;
                            // if (!string.IsNullOrEmpty(txtOutHouseQcChecker.Text))
                            //string OutHouseQcChecker = txtOutHouseQcChecker.Text;
                            int QCOutHouseQcChecker = ddlchecker.SelectedIndex;
                            //------------End Of Code-----------------------//
                            if (chkIsOHStitchComplete.Checked)
                            {
                                IsOHStitchComplete = true;
                            }
                            ord.InsertUpdatePartialOrFullAllocation(OrderDetailsId, FactoryId, Cutting, Stitching, Finishing, ReAllocationId, TdyCutReady, TdyCutIssueOutHouse, true, IsOHStitchComplete,"",UserID);
                        }
                        ord.UpdateCheckDelete(styleId, OrderDetailsId,UserID);
                    }
                    else
                    {
                        return;
                    }
                }
                Response.Redirect("/Internal/Merchandising/ReAllocationForm.aspx?styleId=" + styleId);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        private bool Validation(GridView gvChildReallocation, int Quantity)
        {
            bool Validate = true;
            int FactoryId = 0;
            int Cutting = 0;
            int Stitching = 0;
            int Finishing = 0;

            for (int j = 0; j < gvChildReallocation.Rows.Count; j++)
            {
                DropDownList ddlFactory = (DropDownList)gvChildReallocation.Rows[j].FindControl("ddlFactory");
                TextBox txtCutting = (TextBox)gvChildReallocation.Rows[j].FindControl("txtCutting");
                TextBox txtStitching = (TextBox)gvChildReallocation.Rows[j].FindControl("txtStitching");
                HiddenField hdnStitching = (HiddenField)gvChildReallocation.Rows[j].FindControl("hdnStitching");
                TextBox txtFinishing = (TextBox)gvChildReallocation.Rows[j].FindControl("txtFinishing");
                HiddenField hdnUnAlloctedQty = (HiddenField)gvChildReallocation.Rows[j].FindControl("hdnUnAlloctedQty");
                HiddenField StitchingValueOriginal = (HiddenField)gvChildReallocation.Rows[j].FindControl("StitchingValueOriginal");
                HtmlAnchor txtStitching1 = (HtmlAnchor)gvChildReallocation.Rows[j].FindControl("txtStitching1");
                //TextBox txtStitching1 = (TextBox)gvChildReallocation.Rows[j].FindControl("txtStitching1");
                TextBox txtStichingUnallocated = (TextBox)gvChildReallocation.Rows[j].FindControl("txtStichingunallocated");
                HiddenField hdnlineQty = (HiddenField)gvChildReallocation.Rows[j].FindControl("hdnlineQty");

                string sStitching = txtStitching1.InnerHtml.Replace("<div align=\"center\" style=\"width:98%; height:100%; background-color:#A8D9A1;\">", "").Replace("</div>", "").Trim();
                if (ddlFactory.SelectedValue != "-1")
                {
                    txtCutting.Text = txtCutting.Text == "" ? "0" : txtCutting.Text;
                    txtStichingUnallocated.Text = txtStichingUnallocated.Text == "" ? "0" : txtStichingUnallocated.Text;
                    txtStitching.Text = txtStitching.Text == "" ? "0" : txtStitching.Text;
                    sStitching = sStitching == "" ? "0" : sStitching;
                    txtFinishing.Text = txtFinishing.Text == "" ? "0" : txtFinishing.Text;
                    FactoryId = Convert.ToInt32(ddlFactory.SelectedValue);
                    if (txtCutting.Text != "")
                    {
                        Cutting = Cutting + Convert.ToInt32(txtCutting.Text.Trim());
                    }
                    if (txtStitching.Text != "" && txtStitching.Visible && !(txtStitching1.Visible))
                    {
                        Stitching = Stitching + Convert.ToInt32(txtStitching.Text.Trim());
                    }
                    else if (sStitching != "" && !(txtStitching.Visible) && txtStitching1.Visible)
                    {
                        Stitching = Stitching + Convert.ToInt32(sStitching);
                        //if (Convert.ToInt32(txtStichingUnallocated.Text.Trim()) > 0 && sStitching != txtStichingUnallocated.Text.Trim() && gvChildReallocation.Rows.Count == 1)
                        //{
                        //  Stitching = Stitching + (Convert.ToInt32(txtStitching1.Text.Trim()) - Convert.ToInt32(txtStichingUnallocated.Text.Trim()));
                        //}
                        //else if (Convert.ToInt32(txtStichingUnallocated.Text.Trim()) > 0)
                        //{
                        //  Stitching = Stitching + (Convert.ToInt32(txtStitching1.Text.Trim()) - Convert.ToInt32(txtStichingUnallocated.Text.Trim()));
                        //}
                        //else
                        //{
                        //  Stitching = Stitching + Convert.ToInt32(txtStitching1.Text.Trim());
                        //}
                    }
                    if (txtFinishing.Text != "")
                    {
                        Finishing = Finishing + Convert.ToInt32(txtFinishing.Text.Trim());
                    }

                    if (Convert.ToInt32(txtCutting.Text) == 0 && Convert.ToInt32(txtStitching.Text) == 0 && Convert.ToInt32(txtFinishing.Text) == 0)
                    {
                        Page page = HttpContext.Current.Handler as Page;
                        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Please enter some value atleast one of Cutting, Stitching and Finishing.');", true);
                        Validate = false;
                    }

                    if (hdnlineQty.Value != "")
                    {
                        if ((Convert.ToInt32(txtStitching.Text) < Convert.ToInt32(hdnlineQty.Value)))
                        {

                            Page page = HttpContext.Current.Handler as Page;
                            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Please enter Stiching Quantity Cannot be less then Unallocated Quantity.');", true);
                            Validate = false;
                        }
                    }

                    if (hdnStitching.Value != "")
                    {
                        if (Convert.ToInt32(txtStitching.Text.Trim()) < Convert.ToInt32(hdnStitching.Value))
                        {
                            Page page = HttpContext.Current.Handler as Page;
                            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Stitching Qty cannot be less than complete Stitching Qty.');", true);
                            Validate = false;
                        }
                    }
                }
                else
                {
                    Page page = HttpContext.Current.Handler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Please select a Factory.');", true);
                    Validate = false;
                }
            }
            if (Validate)
            {
                if (Quantity < Cutting || Quantity < Stitching || Quantity < Finishing)
                {
                    Page page = HttpContext.Current.Handler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Total Cutting, Stitching or Finishing cannot be greater then Quantity. Please Check.');", true);
                    Validate = false;
                }
                if (Quantity > Cutting || Quantity > Stitching || Quantity > Finishing)
                {
                    Page page = HttpContext.Current.Handler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Total Cutting, Stitching or Finishing cannot be less then Quantity. Please Check.');", true);
                    Validate = false;
                }
            }
            return Validate;
        }

        protected void gvChildReallocation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            HiddenField hdnOrderDetailsId = (HiddenField)e.Row.Parent.Parent.Parent.FindControl("hdnOrderDetailsId");
            DropDownList ddlFactory = (DropDownList)e.Row.FindControl("ddlFactory");
            HiddenField hdnReAllocation = (HiddenField)e.Row.FindControl("hdnReAllocation");
            TextBox txtCutting = (TextBox)e.Row.FindControl("txtCutting");
            TextBox txtStitching = (TextBox)e.Row.FindControl("txtStitching");
            HtmlAnchor txtStitching1 = (HtmlAnchor)e.Row.FindControl("txtStitching1");
            //TextBox txtStitching1 = (TextBox)e.Row.FindControl("txtStitching1");
            HiddenField hdnUnAlloctedQty = (HiddenField)e.Row.FindControl("hdnUnAlloctedQty");

            TextBox txtFinishing = (TextBox)e.Row.FindControl("txtFinishing");

            int OrderDetailsId = 0;
            int ReAllocationId = 0;
            if (hdnOrderDetailsId != null)
            {
                OrderDetailsId = Convert.ToInt32(hdnOrderDetailsId.Value);
            }
            if (hdnReAllocation != null)
            {
                if (hdnReAllocation.Value != "")
                {
                    ReAllocationId = Convert.ToInt32(hdnReAllocation.Value);
                }
                else
                {
                    ReAllocationId = 0;
                }
            }

            DataSet dtReAllocationUnit = new DataSet();
            dtReAllocationUnit = ord.GetReAllocationUnit(OrderDetailsId, ReAllocationId);

            ddlFactory.DataSource = dtReAllocationUnit.Tables[0];
            ddlFactory.DataValueField = "UnitID";
            ddlFactory.DataTextField = "UnitName";
            ddlFactory.DataBind();

            if (dtReAllocationUnit.Tables[1].Rows.Count > 1)
            {
                int unitId = Convert.ToInt32(dtReAllocationUnit.Tables[1].Rows[1]["UnitID"].ToString());
                ddlFactory.SelectedValue = unitId.ToString();

                txtStitching1.HRef = "/Internal/Merchandising/LinewithFactory.aspx?OrderDetailId=" + OrderDetailsId + "&unitid=" + Convert.ToInt32(ddlFactory.SelectedValue) + "&StyleId=" + styleId;
                txtStitching1.Disabled = true;

                string sStitching = txtStitching1.InnerHtml.Replace("<div align=\"center\" style=\"width:98%; height:100%; background-color:#A8D9A1;\">", "").Replace("</div>", "").Trim();

                if (Convert.ToInt32(ddlFactory.SelectedValue) > 0)
                {
                    DataTable dt = ord.CheckCutting_FinishingActive(Convert.ToInt32(ddlFactory.SelectedValue));
                    DataSet slotpass = ord.GetSumAltpluspasspcs(OrderDetailsId, Convert.ToInt32(ddlFactory.SelectedValue));
                    hdnUnAlloctedQty.Value = hdnUnAlloctedQty.Value == "" ? "0" : hdnUnAlloctedQty.Value;

                    if (Convert.ToInt32(hdnUnAlloctedQty.Value) > 0)
                    {
                        txtStitching1.Visible = false;
                        txtStitching.Visible = true;
                    }
                    else
                    {

                        txtStitching1.Visible = true;
                        txtStitching.Visible = false;
                    }
                    if (slotpass.Tables[1].Rows.Count > 0)
                    {
                        txtStitching1.Visible = true;
                        txtStitching.Visible = false;
                    }
                    else
                    {
                        txtStitching1.Visible = false;
                        txtStitching.Visible = true;
                    }

                    if (Convert.ToBoolean(dt.Rows[0]["Cutting_Active"]) == true)
                    {
                        txtCutting.Enabled = true;
                    }
                    else
                    {
                        txtCutting.Enabled = false;
                    }

                    if (Convert.ToBoolean(dt.Rows[0]["Finishing_Active"]) == true)
                    {
                        txtFinishing.Enabled = true;
                    }
                    else
                    {
                        txtFinishing.Enabled = false;
                    }
                    txtStitching.Enabled = true;

                }
                else
                {
                    txtCutting.Enabled = false;
                    txtStitching.Enabled = false;
                    txtFinishing.Enabled = false;
                    txtStitching1.Visible = false;
                }
                txtCutting.Text = txtCutting.Text == "0" ? "" : txtCutting.Text;
                txtStitching.Text = txtStitching.Text == "0" ? "" : txtStitching.Text;
                sStitching = sStitching == "0" ? "" : sStitching;
                txtFinishing.Text = txtFinishing.Text == "0" ? "" : txtFinishing.Text;
            }
        }

        protected void gvChildReallocation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gv = sender as GridView;
            GridViewRow gvRow = gv.NamingContainer as GridViewRow;
            int rowIndex = gvRow.RowIndex;

            GridView gvChildReallocation = (GridView)gvReAllocation.Rows[rowIndex].FindControl("gvChildReallocation");

            DataTable dtChildReallocation = new DataTable();

            dtChildReallocation.Columns.Add("Factory");
            dtChildReallocation.Columns.Add("UnAllocatedQty");
            dtChildReallocation.Columns.Add("Cutting");
            dtChildReallocation.Columns.Add("Stitching");
            dtChildReallocation.Columns.Add("Finishing");
            dtChildReallocation.Columns.Add("ReallocationID");
            dtChildReallocation.Columns.Add("LineQty");
            dtChildReallocation.Columns.Add("OrderDetailID");
            dtChildReallocation.Columns.Add("UnitID");
            dtChildReallocation.Columns.Add("DoneStitching");

            foreach (GridViewRow row in gvChildReallocation.Rows)
            {
                DataRow dr = dtChildReallocation.NewRow();

                DropDownList ddlFactory = (DropDownList)row.Cells[0].FindControl("ddlFactory");
                TextBox txtStichingunallocated = (TextBox)row.Cells[1].FindControl("txtStichingunallocated");
                TextBox txtCutting = (TextBox)row.Cells[2].FindControl("txtCutting");
                TextBox txtStitching = (TextBox)row.Cells[3].FindControl("txtStitching");
                HtmlAnchor txtStitching1 = (HtmlAnchor)row.Cells[3].FindControl("txtStitching1");
                //TextBox txtStitching1 = (TextBox)row.Cells[3].FindControl("txtStitching1");
                TextBox txtFinishing = (TextBox)row.Cells[4].FindControl("txtFinishing");
                HiddenField hdnReAllocation = (HiddenField)row.Cells[4].FindControl("hdnReAllocation");
                HiddenField hdnlineQty = (HiddenField)row.Cells[4].FindControl("hdnlineQty");
                HiddenField hdnorderdetail = (HiddenField)row.Cells[4].FindControl("hdnorderdetail");
                HiddenField hdnunitid = (HiddenField)row.Cells[4].FindControl("hdnunitid");
                HiddenField hdnStitching = (HiddenField)row.Cells[4].FindControl("hdnStitching");

                string sStitching = txtStitching1.InnerHtml.Replace("<div align=\"center\" style=\"width:98%; height:100%; background-color:#A8D9A1;\">", "").Replace("</div>", "").Trim();

                dr["Factory"] = ddlFactory.Text;
                dr["UnAllocatedQty"] = txtStichingunallocated.Text;

                dr["Cutting"] = txtCutting.Text;
                if (txtStitching.Visible)
                {
                    dr["Stitching"] = txtStitching.Text;
                }
                else
                {
                    dr["Stitching"] = sStitching;
                }
                dr["Finishing"] = txtFinishing.Text;
                dr["ReallocationID"] = hdnReAllocation.Value;
                dr["LineQty"] = hdnlineQty.Value;
                dr["OrderDetailID"] = hdnorderdetail.Value;
                dr["UnitID"] = hdnunitid.Value;
                dr["DoneStitching"] = hdnStitching.Value;

                dtChildReallocation.Rows.Add(dr);
            }

            int index = Convert.ToInt32(e.RowIndex);
            DataTable dtCurrentChildReallocation = dtChildReallocation;

            if (dtCurrentChildReallocation.Rows.Count > 1)
            {
                dtCurrentChildReallocation.Rows.RemoveAt(index);
            }
            else
            {
                Page page = HttpContext.Current.Handler as Page;
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Atleast one Entry need to be added.');", true);
                return;
            }

            gvChildReallocation.DataSource = dtCurrentChildReallocation;
            gvChildReallocation.DataBind();
        }

        protected void ddlFactory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            GridViewRow row = ddl.NamingContainer as GridViewRow;
            GridViewRow parentRow = ddl.NamingContainer.Parent.Parent.Parent.Parent as GridViewRow;
            int rowIndex = row.RowIndex;
            int parentRowIndex = parentRow.RowIndex;

            GridView gvChildReallocation = (GridView)gvReAllocation.Rows[parentRowIndex].FindControl("gvChildReallocation");
            DropDownList ddlFactory = (DropDownList)gvChildReallocation.Rows[rowIndex].FindControl("ddlFactory");
            TextBox txtCutting = (TextBox)gvChildReallocation.Rows[rowIndex].FindControl("txtCutting");
            TextBox txtStitching = (TextBox)gvChildReallocation.Rows[rowIndex].FindControl("txtStitching");
            TextBox txtFinishing = (TextBox)gvChildReallocation.Rows[rowIndex].FindControl("txtFinishing");

            if (Convert.ToInt32(ddlFactory.SelectedValue) > 0)
            {
                DataTable dt = ord.CheckCutting_FinishingActive(Convert.ToInt32(ddlFactory.SelectedValue));
                if (Convert.ToBoolean(dt.Rows[0]["Cutting_Active"]) == true)
                {
                    txtCutting.Enabled = true;
                }
                else
                {
                    txtCutting.Enabled = false;
                }

                if (Convert.ToBoolean(dt.Rows[0]["Finishing_Active"]) == true)
                {
                    txtFinishing.Enabled = true;
                }
                else
                {
                    txtFinishing.Enabled = false;
                }
                txtStitching.Enabled = true;
            }
            else
            {
                txtCutting.Enabled = false;
                txtStitching.Enabled = false;
                txtFinishing.Enabled = false;
            }

            for (int j = 0; j < gvChildReallocation.Rows.Count; j++)
            {
                DropDownList ddlCheckFactory = (DropDownList)gvChildReallocation.Rows[j].FindControl("ddlFactory");

                if (ddlCheckFactory.SelectedValue == ddlFactory.SelectedValue && j != rowIndex && ddlFactory.SelectedValue != "-1")
                {
                    ddlFactory.SelectedValue = "-1";
                    Page page = HttpContext.Current.Handler as Page;
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('You can not select this factory because it is already selected.');", true);
                    return;
                }
            }
        }

        protected void CheckHeader_CheckedChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((CheckBox)sender).NamingContainer as GridViewRow;
            CheckBox CheckHeader = (CheckBox)row.FindControl("CheckHeader");
            for (int i = 0; i < gvReAllocation.Rows.Count; i++)
            {
                RadioButtonList rbtnPartialFull = (RadioButtonList)gvReAllocation.Rows[i].FindControl("rbtnPartialFull");
                GridView gvChildReallocation = (GridView)gvReAllocation.Rows[i].FindControl("gvChildReallocation");
                ImageButton imgbtnAdd = (ImageButton)gvReAllocation.Rows[i].FindControl("imgbtnAdd");

                if (CheckHeader.Checked == true)
                {
                    rbtnPartialFull.Enabled = true;
                    imgbtnAdd.Enabled = true;
                }
                else
                {
                    rbtnPartialFull.Enabled = false;
                    imgbtnAdd.Enabled = false;
                }
                for (int j = 0; j < gvChildReallocation.Rows.Count; j++)
                {
                    if (CheckHeader.Checked == true)
                    {
                        gvChildReallocation.Enabled = true;
                        for (int k = 0; k < gvChildReallocation.Rows.Count; k++)
                        {
                            HtmlAnchor txtStitching1 = (HtmlAnchor)gvChildReallocation.Rows[k].FindControl("txtStitching1");
                            txtStitching1.Attributes.Add("class", "enable");
                        }
                    }
                    else
                    {
                        gvChildReallocation.Enabled = false;
                        for (int k = 0; k < gvChildReallocation.Rows.Count; k++)
                        {
                            HtmlAnchor txtStitching1 = (HtmlAnchor)gvChildReallocation.Rows[k].FindControl("txtStitching1");
                            txtStitching1.Attributes.Add("class", "disable");
                        }
                    }

                }
            }
        }

        protected void cb_CheckedChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((CheckBox)sender).NamingContainer as GridViewRow;
            GridView gvChildReallocation = (GridView)row.FindControl("gvChildReallocation");
            RadioButtonList rbtnPartialFull = (RadioButtonList)row.FindControl("rbtnPartialFull");

            CheckBox cb = (CheckBox)row.FindControl("cb");
            ImageButton imgbtnAdd = (ImageButton)row.FindControl("imgbtnAdd");

            if (cb.Checked == true)
            {
                gvChildReallocation.Enabled = true;
                for (int i = 0; i < gvChildReallocation.Rows.Count; i++)
                {
                    HtmlAnchor txtStitching1 = (HtmlAnchor)gvChildReallocation.Rows[i].FindControl("txtStitching1");
                    txtStitching1.Attributes.Add("class", "enable");
                }
                rbtnPartialFull.Enabled = true;
                imgbtnAdd.Enabled = true;
            }
            else
            {
                gvChildReallocation.Enabled = false;
                for (int i = 0; i < gvChildReallocation.Rows.Count; i++)
                {
                    HtmlAnchor txtStitching1 = (HtmlAnchor)gvChildReallocation.Rows[i].FindControl("txtStitching1");
                    txtStitching1.Attributes.Add("class", "disable");
                }
                rbtnPartialFull.Enabled = false;
                imgbtnAdd.Enabled = false;
            }
        }
    }
}