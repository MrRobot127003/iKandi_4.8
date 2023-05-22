using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Web.Components;
using iKandi.Common;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace iKandi.Web
{
    public partial class VirtualShowroom : BaseUserControl
    {
        static string series = string.Empty;
        static string rmvbtnvisibl = string.Empty;
        bool addflag = true;

        bool delcheck = true;


        DataTable dt = new DataTable();
        List<iKandi.Common.ShowroomCosting> items = new List<iKandi.Common.ShowroomCosting>();
        iKandi.Common.ShowroomCosting costing1 = new iKandi.Common.ShowroomCosting();
        #region Properties

        // 0 for Style, 1 for Print
        public int Mode
        {
            get
            {
                return Convert.ToInt32(hdnMode.Value);
            }
            set
            {
                hdnMode.Value = value.ToString();
            }
        }


        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {

            if (this.Mode == 0)
            {
                if (addflag)
                {
                    dt.Rows.Clear();
                    dt.AcceptChanges();
                    rmvbtnvisibl = string.Empty;
                    HyperLinkPager1.Visible = true;
                }
                if (Convert.ToString(ViewState["ValAdded"]) != "Y")
                {
                    BindStylesControls(false, false);
                    HyperLinkPager1.Visible = true;
                }
            }
            else
            {
                if (Convert.ToString(ViewState["printsearch"]) != "Y")
                {
                    BindPrintControls(false);
                }

            }
            if (addflag == false)
                addflag = true;
            if (delcheck == false)
                delcheck = true;
            PageHelper.AddJScriptVariable("hdnSelectedStyleClientID", "'" + hdnSelectedStyles.ClientID + "'");
            PageHelper.AddJScriptVariable("hdnSelectedPrintClientID", "'" + hdnSelectedPrints.ClientID + "'");

            if (!IsPostBack)
            {
                series = string.Empty;
                BindControls();//showroom us
                //DropdownHelper.BindAllClients(ddlClients);
                DropdownHelper.BindAllClients(cbListClients);

                //DropdownHelper.BindGarmentTypes(ddlGarmentType);
                DropdownHelper.BindGarmentTypes(cbListGarmentType);

                DropdownHelper.BindUsedRegisteredFabric(lstTradeNames);

                DropdownHelper.BindAllClients(ddlPrintClients);
                DropdownHelper.BindAllPrintTypes(ddlPrintType);
                DropdownHelper.BindSeason(ddlseason);
                DropdownHelper.BindSeason(ddlSeasonPrint);

            }

            foreach (ListItem li in cbListClients.Items)
            {
                li.Attributes.Add("mainValue", li.Value);
                li.Attributes.Add("onclick", "OnClientClick(this)");
            }
            lblerrormsg.Text = string.Empty;
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {

            txtSty.Text = string.Empty;
            txtVer.Text = string.Empty;
            txtMark.Text = string.Empty;
            txtComm.Text = string.Empty;
            lblmsg.Text = string.Empty;
            lblerrormsg.Text = string.Empty;
            rmvbtnvisibl = string.Empty;
            HyperLinkPager1.Visible = true;
            //HyperLinkPager1.PageIndex = 0;
            //Request.QueryString["PageIndex"] = "0";
            ViewState["ValAdded"] = "N";
            BindStylesControls(true, true);
            //txtStartDate.Text = string.Empty;
            //txtEndDate.Text = string.Empty;
            //txtBIPLPriceFrom.Text = string.Empty;
            //txtBIPLPriceTo.Text = string.Empty;
            //cbListClients.ClearSelection();
            //cbListGarmentType.ClearSelection();
            dt.Rows.Clear();
            dt.AcceptChanges();

        }

        protected void btnPrintGo_Click(object sender, EventArgs e)
        {

            BindPrintControls(true);
            ViewState["printsearch"] = "N";
            //txtPrintStartDate.Text = string.Empty;
            //txtPrintEndDate.Text = string.Empty;
            //ddlPrintClients.ClearSelection();
            //ddlPrintType.ClearSelection();
            dt.Rows.Clear();
            dt.AcceptChanges();

        }
        //working here
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            addflag = false;
            RetriveSelectedPrints();
            RetriveSelectedStyles();
            string styleIDs = hdnSelectedStyles.Value;
            string printIDs = hdnSelectedPrints.Value;
            //Edit By Ashish
            string strHeading;
            int Logo;
            int Moq;
            int Price;
            if (ddlHeading.SelectedValue == "1")
            {
                strHeading = "BOUTIQUE INTERNATIONAL PVT. LTD. FASHION RANGE PRESENTATION";
                Logo = 1;
            }
            else
            {
                strHeading = "IKANDI Fashion & Design Limited";
                Logo = 2;
            }

            if (chkIsMoq.Checked == true)
            {
                Moq = 1;
            }
            else
            {
                Moq = 2;
            }
            if (chkIsprice.Checked == true)
            {
                Price = 1;
            }
            else
            {
                Price = 2;
            }
            //
            if (string.IsNullOrEmpty(styleIDs) && string.IsNullOrEmpty(printIDs))
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Please Check any check box from Styles.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);

            }
            else
            {
                List<iKandi.Common.ShowroomCosting> showroomStyles = this.StyleControllerInstance.GetShowroomStyleDetails_Print(styleIDs);
                List<iKandi.Common.Print> showroomPrints = this.PrintControllerInstance.GetShowroomPrintDetails(printIDs);
                string PDFfile = this.PDFControllerInstance.GenerateShowroomPDF(showroomStyles, showroomPrints, strHeading, Logo, Moq, Price); //this.PDFControllerInstance.GenerateShowroomCostingPDF(showroomStyles, txtHeading.Text);
                this.RenderFile(PDFfile, "Virtual-Showroom.PDF", Constants.CONTENT_TYPE_PDF);
            }
        }

        protected void lnkBtnStyles_Click(object sender, EventArgs e)
        {
            Mode = 0;
            dt.Rows.Clear();
            dt.AcceptChanges();
            lblmsg.Text = string.Empty;
            series = string.Empty;
            lnkBtnStyles.CssClass = "selectedTabs";
            lnkBtnPrints.CssClass = "";

            pnlPrints.Visible = false;
            pnlStyles.Visible = true;

            RetriveSelectedPrints();
            BindStylesControls(true, false);


        }

        protected void lnkBtnPrints_Click(object sender, EventArgs e)
        {
            Mode = 1;
            dt.Rows.Clear();
            dt.AcceptChanges();
            series = string.Empty;
            lblmsg.Text = string.Empty;
            lnkBtnStyles.CssClass = "";
            lnkBtnPrints.CssClass = "selectedTabs";

            pnlPrints.Visible = true;
            pnlStyles.Visible = false;

            RetriveSelectedStyles();
            BindPrintControls(true);

        }



        #endregion



        private void BindStylesControls(Boolean IsFirstPage, Boolean IsSearch)
        {
            List<string> IDs = RetriveSelectedStyles();

            DateTime startDate = DateHelper.ParseDate(txtStartDate.Text).Value;
            DateTime endDate = DateHelper.ParseDate(txtEndDate.Text).Value;
            double priceFrom = 0;
            double priceTo = 0;

            if (!string.IsNullOrEmpty(txtBIPLPriceFrom.Text))
                priceFrom = Convert.ToDouble(txtBIPLPriceFrom.Text);

            if (!string.IsNullOrEmpty(txtBIPLPriceTo.Text))
                priceTo = Convert.ToDouble(txtBIPLPriceTo.Text);
            else
                priceTo = -1;

            string tradeNames = string.Empty;

            foreach (ListItem item in lstTradeNames.Items)
            {
                if (item.Selected)
                    tradeNames += item.Text + ",";
            }

            tradeNames = tradeNames.TrimEnd(new char[] { ',' });

            if (!string.IsNullOrEmpty(Request.QueryString["PageIndex"]))
            {
                this.HyperLinkPager1.PageIndex = Convert.ToInt32(Request.QueryString["PageIndex"]);
                //Response.Redirect("~/VirualShowroomReport.aspx?PageIndex=" + Request.QueryString["PageIndex"]);
            }
            else
            {
                this.HyperLinkPager1.PageIndex = 0;
            }

            if (IsFirstPage)
            {
                this.HyperLinkPager1.PageIndex = 0;
            }
            int TotalRowCount = 0;

            string clientIds = string.Empty; // (cbListClients.SelectedValue == null || cbListClients.SelectedValue == string.Empty) ? -1 : Convert.ToInt32(cbListClients.SelectedValue);

            foreach (ListItem item in cbListClients.Items)
            {
                if (item.Selected)
                {
                    if (clientIds == string.Empty)
                        clientIds = item.Value;
                    else
                        clientIds += "," + item.Value;
                }
            }

            if (clientIds == string.Empty)
                clientIds = "-1";

            hiddenDeptId.Value = Request.Params["cbListDepartmentID"];

            if (hiddenDeptId.Value == null || hiddenDeptId.Value == string.Empty)
                hiddenDeptId.Value = "-1";

            string garmentTypes = string.Empty; // (cbListClients.SelectedValue == null || cbListClients.SelectedValue == string.Empty) ? -1 : Convert.ToInt32(cbListClients.SelectedValue);

            foreach (ListItem item in cbListGarmentType.Items)
            {
                if (item.Selected)
                {
                    if (garmentTypes == string.Empty)
                        garmentTypes = item.Value;
                    else
                        garmentTypes += "," + item.Value;
                }
            }
            string seasonname = string.Empty;
            //seasonname=(ddlseason.SelectedIndex==-1) ? "" : ddlseason.SelectedItem.Text;

            List<iKandi.Common.ShowroomCosting> styles = this.StyleControllerInstance.SearchShowroomStyles(HyperLinkPager1.PageSize, this.HyperLinkPager1.PageIndex, out TotalRowCount, clientIds,
                hiddenDeptId.Value, garmentTypes, Convert.ToInt32(rdDateType.SelectedValue), startDate, endDate,
                Convert.ToInt32(rdIsBestSeller.SelectedValue), priceFrom, priceTo, tradeNames, Convert.ToInt32(rdOrderPlaced.SelectedValue), ddlseason.SelectedItem.Text, ShippedminValue.Text == "" || ShippedminValue.Text == "MIN" ? 1 : Convert.ToInt64(ShippedminValue.Text), ShippedmaxValue.Text == "" || ShippedmaxValue.Text == "MAX" ? 1 : Convert.ToInt64(ShippedmaxValue.Text));

            foreach (iKandi.Common.ShowroomCosting SC in styles)
            {
                if (IDs.Contains(SC.StyleID.ToString()))
                    SC.IsSelected = true;

                hdnShippedMaxValue.Value = Convert.ToString(SC.ShippedMaxValue);
            }

            dlStyles.DataSource = styles;
            dlStyles.DataBind();
            this.HyperLinkPager1.TotalRecords = TotalRowCount;
            if (styles.Count == 0 && IsSearch == true)
            {
                addflag = false;

                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Search pattern not found.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
            }

        }

        private void BindPrintControls(Boolean IsFirstPage)
        {

            List<string> IDs = RetriveSelectedPrints();

            DateTime startDate = DateHelper.ParseDate(txtPrintStartDate.Text).Value;
            DateTime endDate = DateHelper.ParseDate(txtPrintEndDate.Text).Value;

            if (!string.IsNullOrEmpty(Request.QueryString["PageIndex"]))
            {
                this.HyperLinkPager2.PageIndex = Convert.ToInt32(Request.QueryString["PageIndex"]);
            }
            else
            {
                this.HyperLinkPager2.PageIndex = 0;
            }

            if (IsFirstPage)
            {
                this.HyperLinkPager2.PageIndex = 0;
            }
            int TotalRowCount = 0;

            string clientIds = string.Empty; // (cbListClients.SelectedValue == null || cbListClients.SelectedValue == string.Empty) ? -1 : Convert.ToInt32(cbListClients.SelectedValue);
            foreach (ListItem item in ddlPrintClients.Items)
            {
                if (item.Selected)
                {
                    if (clientIds == string.Empty)
                        clientIds = item.Value;
                    else
                        clientIds += "," + item.Value;
                }
            }

            if (clientIds == string.Empty)
                clientIds = "-1";

            string printTypes = string.Empty; // (cbListClients.SelectedValue == null || cbListClients.SelectedValue == string.Empty) ? -1 : Convert.ToInt32(cbListClients.SelectedValue);

            foreach (ListItem item in ddlPrintType.Items)
            {
                if (item.Selected)
                {
                    if (printTypes == string.Empty)
                        printTypes = item.Value;
                    else
                        printTypes += "," + item.Value;
                }
            }

            if (printTypes == string.Empty)
                printTypes = "-1";

            List<iKandi.Common.Print> prints = this.PrintControllerInstance.SearchShowroomPrints(HyperLinkPager2.PageSize, this.HyperLinkPager2.PageIndex, out TotalRowCount, clientIds,
                "", printTypes, startDate, endDate, Convert.ToInt32(rdStatus.SelectedValue));

            foreach (iKandi.Common.Print P in prints)
            {
                if (IDs.Contains(P.PrintID.ToString()))
                    P.IsSelected = true;
            }

            dlPrints.DataSource = prints;
            dlPrints.DataBind();

            this.HyperLinkPager2.TotalRecords = TotalRowCount;
            if (prints.Count == 0 && dlStyles.Items.Count <= 0 && TotalRowCount == 0)
            {
                //selectedprintcount = true;
                //ViewState["printsearch"] = "Y";

                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Search pattern not found.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
            }
        }

        private List<string> RetriveSelectedStyles()
        {
            string preSelectedStyles = hdnSelectedStyles.Value;

            List<string> styleIds = new List<string>();
            styleIds.AddRange(preSelectedStyles.Split(new char[] { ',' }));


            foreach (DataListItem item in dlStyles.Items)
            {
                CheckBox chkBox = item.FindControl("chkCheckBox") as CheckBox;

                if (chkBox.Checked)
                {
                    HiddenField hdnStyleID = item.FindControl("hdnStyleID") as HiddenField;

                    if (!styleIds.Contains(hdnStyleID.Value))
                        styleIds.Add(hdnStyleID.Value);
                }
            }

            hdnSelectedStyles.Value = String.Join(",", styleIds.ToArray()).TrimStart(new char[] { ',' });

            return styleIds;
        }

        private List<string> RetriveSelectedPrints()
        {

            string preSelectedPrints = hdnSelectedPrints.Value;

            List<string> printIds = new List<string>();
            printIds.AddRange(preSelectedPrints.Split(new char[] { ',' }));


            foreach (DataListItem item in dlPrints.Items)
            {
                CheckBox chkBox = item.FindControl("chkCheckBox") as CheckBox;

                if (chkBox.Checked)
                {
                    HiddenField hdnPrintID = item.FindControl("hdnPrintID") as HiddenField;

                    if (!printIds.Contains(hdnPrintID.Value))
                        printIds.Add(hdnPrintID.Value);
                }
            }

            hdnSelectedPrints.Value = String.Join(",", printIds.ToArray()).TrimStart(new char[] { ',' });
            return printIds;
        }
        /// <summary>
        /// Adding new or exist style and version for printing.
        /// Us  
        /// </summary>
        protected void btnAdd1_Click(object sender, EventArgs e)
        {
            if (addflag == true)
            {
                addflag = false;
            }
            HyperLinkPager1.Visible = false;
            ViewState["ValAdded"] = "Y";
            rmvbtnvisibl = "added";
            List<iKandi.Common.ShowroomCosting> showroomStyles1 = null;
            if (Mode != 0)
            {
                Mode = 0;
                lnkBtnStyles.CssClass = "selectedTabs";
                lnkBtnPrints.CssClass = "";

                pnlPrints.Visible = false;
                pnlStyles.Visible = true;

                RetriveSelectedPrints();
                BindStylesControls(true, false);
            }
            HyperLinkPager1.Visible = false;
            if (txtSty.Text == string.Empty)
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, '<b>Please select a Style.</b>');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                return;
            }
            //if (txtSty.Text.Trim().Length > 8 && txtVer.Text != string.Empty)
            //{
            //    string script = string.Empty;
            //    script = "ShowHideMessageBox(true, '<b>Version can not be created.Please select a style number without it version.</b>');";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
            //    return;
            //}


            string stylenumberver = string.Empty;
            if (txtVer.Text.ToString().Trim() != "")
            {
                string[] str = txtSty.Text.Split(' ');
                if (str.Length == 3)
                {
                    stylenumberver = str[0].ToString() + " " + str[1].ToString() + " " + txtVer.Text.ToString().Trim();
                }
                else if (str.Length == 2)
                {
                    if (str[0].Length == 2)
                    {
                        stylenumberver = txtSty.Text.Trim() + " " + txtVer.Text.ToString().Trim();
                    }
                    else
                    {
                        stylenumberver = str[0].ToString() + " " + txtVer.Text.ToString().Trim();
                    }
                }
                else if (str.Length == 1)
                {
                    stylenumberver = txtSty.Text.Trim() + " " + txtVer.Text.ToString().Trim();
                }

                //stylenumberver = txtSty.Text.Trim().Substring(0, 8) + " " + txtVer.Text.ToString().Trim();
            }
            else
                stylenumberver = txtSty.Text.Trim();
            if (txtVer.Text.ToString().Trim() != "")
            {
                if (this.StyleControllerInstance.CheckStyleVersion(stylenumberver) == "Y")
                {
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Style Number Already Exists.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                    return;
                }
            }

            List<iKandi.Common.ShowroomCosting> existingItems = GetAddedStyles(txtSty.Text.ToString());
            iKandi.Common.ShowroomCosting existingItem = existingItems.Find(delegate(iKandi.Common.ShowroomCosting sc) { return sc.StyleNumber.ToLower().Trim() == stylenumberver.ToLower().Trim(); });
            iKandi.Common.ShowroomCosting existingItemforclone = existingItems.Find(delegate(iKandi.Common.ShowroomCosting sc) { return sc.StyleNumber.ToLower().Trim() == txtSty.Text.ToLower().Trim(); });
            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("ID");
            }

            lblmsg.Text = String.Empty;
            string StyleIDs = string.Empty;
            string PDFfile = string.Empty;
            try
            {
                List<iKandi.Common.ShowroomCosting> styleitems = new List<iKandi.Common.ShowroomCosting>();
                if (existingItem == null && existingItemforclone == null)
                {
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, '<b>Style has not been costed.Please Add costed Style here.OR You have not select an exist style Number.</b>');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                    showroomStyles1 = this.StyleControllerInstance.GetShowroomStyleDetails_Print(series);
                    dlStyles.DataSource = showroomStyles1;
                    dlStyles.DataBind();
                }
                else
                {
                    if (existingItem == null)
                    {
                        styleitems.Add(existingItemforclone);
                        //lblmsg.Text = "Version has been created.";
                    }
                    else
                    {
                        styleitems.Add(existingItem);
                        //lblmsg.Text = "Style is already Exist and added to the List.";
                    }
                    StyleIDs = this.StyleControllerInstance.CloneStyleNumbers(styleitems);
                    DataRow dr = dt.NewRow();
                    dr["ID"] = StyleIDs;
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                    int i = 0;
                    foreach (DataRow dr11 in dt.Rows)
                    {
                        if (i == 0)
                        {
                            series += "," + dr11["ID"].ToString();
                        }
                        else series = series + "," + dr11["ID"].ToString();
                        i++;
                    }
                    showroomStyles1 = this.StyleControllerInstance.GetShowroomStyleDetails_Print(series);
                    dlStyles.DataSource = showroomStyles1;
                    dlStyles.DataBind();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                lblerrormsg.Text = "Some error occured while creating Style & Costing Sheet Version(s), please try again";
                showroomStyles1 = this.StyleControllerInstance.GetShowroomStyleDetails_Print(series);
                dlStyles.DataSource = showroomStyles1;
                dlStyles.DataBind();
                //this.NotificationControllerInstance.SendErrorEmail(ex.Message + " " + ex.StackTrace);
                return;
            }


            txtSty.Text = string.Empty;
            //txtVer.Text = string.Empty;
            //txtMark.Text = string.Empty;
            //txtComm.Text = string.Empty;
            Label1.Text = string.Empty;
            rmvbtnvisibl = string.Empty;
        }
        /// <summary>
        /// For getting exist style number.
        /// Us  
        /// </summary>
        /// 
        private List<iKandi.Common.ShowroomCosting> GetAddedStyles(string style)
        {
            List<iKandi.Common.ShowroomCosting> items = new List<iKandi.Common.ShowroomCosting>();
            string stylequery = "SELECT * FROM style st JOIN costing co ON st.id=co.styleid where stylenumber='" + style + "'";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalMySqlServer"].ConnectionString);
            SqlDataAdapter styleda = new SqlDataAdapter(stylequery, con);
            DataSet styleds = new DataSet();
            styleda.Fill(styleds);
            for (int i = 0; i < styleds.Tables[0].Rows.Count; i++)
            {
                iKandi.Common.ShowroomCosting costing = new iKandi.Common.ShowroomCosting();
                int styleid = Convert.ToInt32(styleds.Tables[0].Rows[i]["Id"].ToString());
                string stylenumber = styleds.Tables[0].Rows[i]["StyleNumber"].ToString();
                int costingid = Convert.ToInt32(styleds.Tables[0].Rows[i]["CostingId"]);
                costing.StyleNumber = stylenumber.ToString();//txtSty.Text.ToString().Trim();

                if (!string.IsNullOrEmpty(styleid.ToString()))
                    costing.StyleID = styleid;

                if (txtMark.Text == "")
                    costing.Markup = -1;
                else
                    costing.Markup = Convert.ToInt16(txtMark.Text);// Convert.ToDecimal(styleds.Tables[0].Rows[i]["MarkUpOnUnitCTC"].ToString());

                if (txtComm.Text == "")
                    costing.Commission = -1;
                else
                    costing.Commission = Convert.ToInt16(txtComm.Text);//Convert.ToDecimal(styleds.Tables[0].Rows[i]["CommisionPercent"].ToString());

                costing.Currency = (iKandi.Common.Currency)Convert.ToInt32(ddlCurr.SelectedValue);

                if (txtVer.Text.Trim() != "")
                    costing.VersionCode = txtVer.Text.Trim();
                else
                    costing.VersionCode = "";

                costing.CostingID = costingid;
                if (styleds.Tables[0].Rows[i]["PriceQuoted"] != DBNull.Value)
                {
                    costing.PriceQuoted = Convert.ToDouble(styleds.Tables[0].Rows[i]["PriceQuoted"]);
                }
                items.Add(costing);
            }
            return items;
        }
        private void BindControls()
        {
            DropdownHelper.BindCurrency(ddlCurr);
            ddlCurr.SelectedValue = ((int)Currency.GBP).ToString();
        }
        /// <summary>
        /// For button command execution.
        /// Us  
        /// </summary>
        protected void dlStyles_click1(object sender, CommandEventArgs e)
        {
            lblmsg.Text = string.Empty;
            string styleIDs = e.CommandArgument.ToString();
            ImageButton btn = dlStyles.FindControl("btnRemove") as ImageButton;
            if (e.CommandName == "RemoveStyle")
            {
                HyperLinkPager1.Visible = false;
                delcheck = false;
                rmvbtnvisibl = "added";
                series = series.Replace(styleIDs, "");
                List<iKandi.Common.ShowroomCosting> showroomStyles11 = this.StyleControllerInstance.GetShowroomStyleDetails(series);
                dt.Rows.Clear();
                dt.AcceptChanges();
                ViewState["costing1"] = dt;//if (costing != null)
                dt.Columns.Add("ID");
                dt.AcceptChanges();
                dlStyles.DataSource = showroomStyles11;
                dlStyles.DataBind();

            }

        }
        /// <summary>
        /// For item bound in datalist and shows delete button.
        /// Us  
        /// </summary>
        protected void dlStyles_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (rmvbtnvisibl == "added")
            {
                //CheckBox chk = (CheckBox)e.Item.FindControl("chkCheckBox");
                //chk.Checked = true;
                ImageButton imgbtn = (ImageButton)e.Item.FindControl("btnRemove");
                imgbtn.Visible = true;
            }

        }

    }
}