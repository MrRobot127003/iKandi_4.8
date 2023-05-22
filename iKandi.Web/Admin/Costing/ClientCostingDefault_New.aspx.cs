using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Common;
using System.Web.UI.HtmlControls;
using iKandi.Web.Components;


namespace iKandi.Web
{
    public partial class ClientCostingDefault_New : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        DataSet DsOHCheckValue = new DataSet();
        DataSet checkOhNull = new DataSet();
        AdminController adminControlInstance = new AdminController();
        Costing objCosting = new Costing();
        CostingController objCostingControler = new CostingController();
        public static int DdlselectedValue = 0;
        public static int ClientID = 0;
        public static int Public_Count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (null != Request.QueryString["search"])
            {
                DdlselectedValue = Convert.ToInt32(Request.QueryString["search"].ToString());
                BindControls(DdlselectedValue);
            }
            if (!IsPostBack)
            {
                BindControls(DdlselectedValue);
            }
        }
        protected void ddlClinetfilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindControls(Convert.ToInt32(ddlClinetfilter.SelectedValue));
            DdlselectedValue = Convert.ToInt32(ddlClinetfilter.SelectedValue);
            ClientID = Convert.ToInt32(ddlClinetfilter.SelectedValue); ;
            bindHeader(Convert.ToInt32(ClientID));
        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        protected void bindHeader(int ClientID = 0)
        {
            // dsMiddle = objadmin.GetHeaderPOUploadPendingMiddle();
            
            ds = adminControlInstance.GetClientCostingDefaults_New(ClientID);
            Public_Count = Convert.ToInt32(ds.Tables[1].Rows.Count);
            if (gvClientCostingDefaults.Columns.Count > 0)
            {
                gvClientCostingDefaults.Columns.Clear();

            }



            TemplateField Client = new TemplateField();
            Client.HeaderText = "Client";
            Client.HeaderStyle.CssClass = "HeaderStyle1 MinClientHeader";
            Client.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "ClientName", "ClientName");
            gvClientCostingDefaults.Columns.Insert(0, Client);
           // Client.HeaderStyle.Width = 100;
           // Client.ItemStyle.Width = 100;
            Client.ItemStyle.CssClass = "MinClientStyle";



            TemplateField Department = new TemplateField();
            Department.HeaderText = "Parent (Department)";
            Department.HeaderStyle.CssClass = "HeaderStyle1 ParentDepHeader";
            Department.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "DepartmentName", "DepartmentName");
            Department.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(1, Department);
           // Department.HeaderStyle.Width = 150;
          //  Department.ItemStyle.Width = 150;
            Department.ItemStyle.CssClass = "ParentDepStyle";

            TemplateField Convto = new TemplateField();
            Convto.HeaderText = "Conv to";
            Convto.HeaderStyle.CssClass = "HeaderStyle1 HeaderStyCom";
            Convto.ItemTemplate = new iKandi.Common.GridViewTemplate("Dropdown", "Convto", "Convto");
            Convto.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(2, Convto);
           // Convto.HeaderStyle.Width = 70;
            Convto.ItemStyle.CssClass = "minwidthComm";

            TemplateField CoffinBox = new TemplateField();
            CoffinBox.HeaderText = "Coffin box";
            CoffinBox.HeaderStyle.CssClass = "HeaderStyle1 HeaderStyCom";
            CoffinBox.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "CoffinBox", "CoffinBox");
            CoffinBox.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(3, CoffinBox);
           // CoffinBox.HeaderStyle.Width = 70;
            CoffinBox.ItemStyle.CssClass = "minwidthComm";

            TemplateField Lbltags = new TemplateField();
            Lbltags.HeaderText = "Lbl/tags";
            Lbltags.HeaderStyle.CssClass = "HeaderStyle1 HeaderStyCom";
            Lbltags.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "Lbltags", "Lbltags");
            Lbltags.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(4, Lbltags);
          //  Lbltags.HeaderStyle.Width = 60;
            Lbltags.ItemStyle.CssClass = "minwidthComm";

            TemplateField Test = new TemplateField();
            Test.HeaderText = "Test";
            Test.HeaderStyle.CssClass = "HeaderStyle1 HeaderStyCom";
            Test.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "Test", "Test");
            Test.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(5, Test);
           // Test.HeaderStyle.Width = 60;
            Test.ItemStyle.CssClass = "minwidthComm";

            TemplateField Hangers = new TemplateField();
            Hangers.HeaderText = "Hangers";
            Hangers.HeaderStyle.CssClass = "HeaderStyle1 HeaderStyCom";
            Hangers.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "Hangers", "Hangers");
            Hangers.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(6, Hangers);
           // Hangers.HeaderStyle.Width = 60;
            Hangers.ItemStyle.CssClass = "minwidthComm";

            TemplateField Hangerloops = new TemplateField();
            Hangerloops.HeaderText = "Hanger loops";
            Hangerloops.HeaderStyle.CssClass = "HeaderStyle1 HeaderStyCom";
            Hangerloops.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "Hangerloops", "Hangerloops");
            Hangerloops.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(7, Hangerloops);
           // Hangerloops.HeaderStyle.Width = 60;
            Hangerloops.ItemStyle.CssClass = "minwidthComm";

            //new code 06 feb 2020 start
            TemplateField IsCMT = new TemplateField();
            IsCMT.HeaderText = "Is CMT Open";
            IsCMT.HeaderStyle.CssClass = "HeaderStyle1 HeaderStyCom";
            IsCMT.ItemTemplate = new iKandi.Common.GridViewTemplate("checkbox", "IsCMT", "IsCMT");
            IsCMT.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(8, IsCMT);
           // IsCMT.HeaderStyle.Width = 60;
            IsCMT.ItemStyle.CssClass = "minwidthComm";
            //new code 06 feb 2020 end

            TemplateField MinCMT = new TemplateField();
            MinCMT.HeaderText = "Min CMT";
            MinCMT.HeaderStyle.CssClass = "HeaderStyle1 HeaderStyCom";
            MinCMT.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "MinCMT", "MinCMT");
            MinCMT.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(9, MinCMT);
           // MinCMT.HeaderStyle.Width = 60;
            MinCMT.ItemStyle.CssClass = "minwidthComm";


           

            TemplateField IsOH = new TemplateField();
            IsOH.HeaderText = "Is OH %";
            IsOH.HeaderStyle.CssClass = "HeaderStyle1 HeaderStyCom";
            IsOH.ItemTemplate = new iKandi.Common.GridViewTemplate("checkbox", "IsOH", "IsOH");
            IsOH.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(10, IsOH);
           // IsOH.HeaderStyle.Width = 60;
            IsOH.ItemStyle.CssClass = "minwidthComm";
            IsOH.Visible = false;


            TemplateField OHCostValue = new TemplateField();
            OHCostValue.HeaderText = "OH Cost Value";
            OHCostValue.HeaderStyle.CssClass = "HeaderStyle1 HeaderStyCom";
            OHCostValue.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "OHCostValue", "OHCostValue");
            OHCostValue.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(11, OHCostValue);  
           // OHCostValue.HeaderStyle.Width = 60;
            OHCostValue.ItemStyle.CssClass = "minwidthComm";
            OHCostValue.Visible = false;

            TemplateField OHCost = new TemplateField();
            OHCost.HeaderText = "OH Cost %";
            OHCost.HeaderStyle.CssClass = "HeaderStyle1 HeaderStyCom";
            OHCost.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "OHCost", "OHCost");
            OHCost.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(12, OHCost);
           // OHCost.HeaderStyle.Width = 60;
            OHCost.ItemStyle.CssClass = "minwidthComm";
            OHCost.Visible = false;


            TemplateField MinProfit_Percent = new TemplateField();
            MinProfit_Percent.HeaderText = "Min Profit %";
            MinProfit_Percent.HeaderStyle.CssClass = "HeaderStyle1 HeaderStyCom";
            MinProfit_Percent.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "MinProfit_Percent", "MinProfit_Percent");
            MinProfit_Percent.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(13, MinProfit_Percent);
            //MinProfit_Percent.HeaderStyle.Width = 60;
            MinProfit_Percent.ItemStyle.CssClass = "minwidthComm";

            TemplateField Profit_margin_Percent = new TemplateField();
            Profit_margin_Percent.HeaderText = "Profit margin %";
            Profit_margin_Percent.HeaderStyle.CssClass = "HeaderStyle1 HeaderStyCom";
            Profit_margin_Percent.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "Profit_margin_Percent", "Profit_margin_Percent");
            Profit_margin_Percent.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(14, Profit_margin_Percent);
            //Profit_margin_Percent.HeaderStyle.Width = 60;
            Profit_margin_Percent.ItemStyle.CssClass = "minwidthComm";

            TemplateField Commision_Percent = new TemplateField();
            Commision_Percent.HeaderText = "Commision %";
            Commision_Percent.HeaderStyle.CssClass = "HeaderStyle1 HeaderStyComComm";
            Commision_Percent.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "Commision_Percent", "Commision_Percent");
            Commision_Percent.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(15, Commision_Percent);
           // Commision_Percent.HeaderStyle.Width = 70;
            Commision_Percent.ItemStyle.CssClass = "minwidthCommComm";

            //TemplateField Discount_Percent = new TemplateField();
            //Discount_Percent.HeaderText = "Discount %";
            //Discount_Percent.HeaderStyle.CssClass = "HeaderStyle1";
            //Discount_Percent.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "Discount_Percent", "Discount_Percent");
            //Discount_Percent.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            //gvClientCostingDefaults.Columns.Insert(15, Discount_Percent);
            //Discount_Percent.HeaderStyle.Width = 70;

            TemplateField Payment_Days = new TemplateField();
            Payment_Days.HeaderText = "Payment Terms Days";
            Payment_Days.HeaderStyle.CssClass = "HeaderStyle1 HeaderStyCom";
            Payment_Days.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "Payment_Days", "Payment_Days");
            Payment_Days.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(16, Payment_Days);
           // Payment_Days.HeaderStyle.Width = 60;
            Payment_Days.ItemStyle.CssClass = "minwidthComm";

            TemplateField Expectedqty = new TemplateField();
            Expectedqty.HeaderText = "Expected qty.";
            Expectedqty.HeaderStyle.CssClass = "HeaderStyle1 HeaderStyComExQty";
            Expectedqty.ItemTemplate = new iKandi.Common.GridViewTemplate("Dropdown", "Expectedqty", "Expectedqty");
            Expectedqty.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(17, Expectedqty);
           // Expectedqty.HeaderStyle.Width = 110;
            Expectedqty.ItemStyle.CssClass = "minwidthCommExQty";

            TemplateField Frtuptoport = new TemplateField();
            Frtuptoport.HeaderText = "Customs, Doc & Platform";
            Frtuptoport.HeaderStyle.CssClass = "HeaderStyle1 HeaderStyCom";
            Frtuptoport.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "Frtuptoport", "Frtuptoport");
            Frtuptoport.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(18, Frtuptoport);
           // Frtuptoport.HeaderStyle.Width = 60;
            Frtuptoport.ItemStyle.CssClass = "minwidthComm";

            TemplateField SizeSet1 = new TemplateField();
            SizeSet1.HeaderText = "Size Set 1";
            SizeSet1.HeaderStyle.CssClass = "HeaderStyle1 HeaderStyComSelect";
            SizeSet1.ItemTemplate = new iKandi.Common.GridViewTemplate("Dropdown", "SizeSet1", "SizeSet1");
            SizeSet1.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(19, SizeSet1);
           // SizeSet1.HeaderStyle.Width = 80;
            SizeSet1.ItemStyle.CssClass = "minwidthCommSelect";

            TemplateField SizeSet2 = new TemplateField();
            SizeSet2.HeaderText = "Size Set 2";
            SizeSet2.HeaderStyle.CssClass = "HeaderStyle1 HeaderStyComSelect";
            SizeSet2.ItemTemplate = new iKandi.Common.GridViewTemplate("Dropdown", "SizeSet2", "SizeSet2");
            SizeSet2.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(20, SizeSet2);
          //  SizeSet2.HeaderStyle.Width = 80;
            SizeSet2.ItemStyle.CssClass = "minwidthCommSelect";

            TemplateField SizeSet3 = new TemplateField();
            SizeSet3.HeaderText = "Size Set 3";
            SizeSet3.HeaderStyle.CssClass = "HeaderStyle1 HeaderStyComSelect";
            SizeSet3.ItemTemplate = new iKandi.Common.GridViewTemplate("Dropdown", "SizeSet3", "SizeSet3");
            SizeSet3.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(21, SizeSet3);
           // SizeSet3.HeaderStyle.Width = 80;
            SizeSet3.ItemStyle.CssClass = "minwidthCommSelect";

            TemplateField SizeSet4 = new TemplateField();
            SizeSet4.HeaderText = "Size Set 4";
            SizeSet4.HeaderStyle.CssClass = "HeaderStyle1 HeaderStyComSelect";
            SizeSet4.ItemTemplate = new iKandi.Common.GridViewTemplate("Dropdown", "SizeSet4", "SizeSet4");
            SizeSet4.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(22, SizeSet4);
           // SizeSet4.HeaderStyle.Width = 80;
            SizeSet4.ItemStyle.CssClass = "minwidthCommSelect";

            TemplateField Duty_Percent = new TemplateField();
            Duty_Percent.HeaderText = "Duty %";
            Duty_Percent.HeaderStyle.CssClass = "HeaderStyle2 HeaderStyCom";
            Duty_Percent.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "Duty_Percent", "Duty_Percent");
            Duty_Percent.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(23, Duty_Percent);
            //Duty_Percent.HeaderStyle.Width = 60;
            Duty_Percent.ItemStyle.CssClass = "minwidthComm";

            TemplateField Handling = new TemplateField();
            Handling.HeaderText = "Handling";
            Handling.HeaderStyle.CssClass = "HeaderStyle2 HeaderStyCom";
            Handling.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "Handling", "Handling");
            Handling.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(24, Handling);
          //  Handling.HeaderStyle.Width = 60;
            Handling.ItemStyle.CssClass = "minwidthComm";

            TemplateField Delivery = new TemplateField();
            Delivery.HeaderText = "Delivery";
            Delivery.HeaderStyle.CssClass = "HeaderStyle2 HeaderStyCom";
            Delivery.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "Delivery", "Delivery");
            Delivery.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(25, Delivery);
            //Delivery.HeaderStyle.Width = 60;
            Delivery.ItemStyle.CssClass = "minwidthComm";


            TemplateField IkandiMargin = new TemplateField();
            IkandiMargin.HeaderText = "Ikandi Margin %";
            IkandiMargin.HeaderStyle.CssClass = "HeaderStyle2 HeaderStyCom";
            IkandiMargin.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "IkandiMargin", "IkandiMargin");
            IkandiMargin.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(26, IkandiMargin);
          //  IkandiMargin.HeaderStyle.Width = 60;
            IkandiMargin.ItemStyle.CssClass = "minwidthComm";

            TemplateField IkandiHaulage = new TemplateField();
            IkandiHaulage.HeaderText = "Haulage Charges";
            IkandiHaulage.HeaderStyle.CssClass = "HeaderStyle2 HeaderStyCom";
            IkandiHaulage.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "IkandiHaulage", "IkandiHaulage");
            IkandiHaulage.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvClientCostingDefaults.Columns.Insert(27, IkandiHaulage);
            //IkandiHaulage.HeaderStyle.Width = 60;
           // IkandiHaulage.ItemStyle.Width = 60;
            IkandiHaulage.ItemStyle.CssClass = "minwidthComm";


            int Count = Convert.ToInt32(ds.Tables[1].Rows.Count) - 1;
            if (Convert.ToInt32(ds.Tables[1].Rows.Count) > 0)
            {
                for (int i = 0; i <= Count; i++)
                {
                    TemplateField CODE = new TemplateField();
                    CODE.HeaderText = Convert.ToString(ds.Tables[1].Rows[i]["CODE"]);
                    CODE.HeaderStyle.CssClass = "HeaderStyle3";                   
                    CODE.ItemTemplate = new iKandi.Common.GridViewTemplate("checkbox", "CODE" + Convert.ToString(ds.Tables[1].Rows[i]["CODE"]), "CODE" + Convert.ToString(ds.Tables[1].Rows[i]["CODE"]));
                    // Exfactory.ItemStyle.CssClass = "accorforstyle14";
                    //CN.ItemStyle.Width = 80;
                    CODE.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    gvClientCostingDefaults.Columns.Insert(i + 28, CODE);
                     //CODE.HeaderStyle.Width = 60;
                    // CODE.ItemStyle.Width = 44;
                   //CODE.ItemStyle.CssClass = "Code_50";

                }

            }

            gvClientCostingDefaults.DataSource = ds.Tables[0];
            gvClientCostingDefaults.DataBind();
            //1890
            gvClientCostingDefaults.Width = 1870 + 56 * (Count + 1);
        }
        private void BindControls(int clintid = 0)
        {
            ds = adminControlInstance.GetClientCostingDefaults(clintid);
            ddlClinetfilter.DataSource = ds.Tables[3];
            ViewState["currency"] = ds.Tables[1];
            ViewState["Achievement"] = ds.Tables[2];
            ViewState["WastageRange"] = ds.Tables[4];
            ViewState["Size_Set"] = ds.Tables[5];
            ddlClinetfilter.DataTextField = "ClientName";
            ddlClinetfilter.DataValueField = "ClientId";
            ddlClinetfilter.DataBind();
            ddlClinetfilter.SelectedValue = clintid.ToString();
            DdlselectedValue = clintid;
            ClientID = Convert.ToInt32(ddlClinetfilter.SelectedValue);
            bindHeader(ClientID);

           

        }
        protected void gvClientCostingDefaults_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header) // If header created
            {
                GridView ProductGrid = (GridView)sender;

                // Creating a Row
                ////GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                //////Adding Year Column
                ////TableCell HeaderCell = new TableCell();

                //////Adding Audited By Column
                ////HeaderCell = new TableCell();
                ////HeaderCell.Text = "Bipl";
                ////HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                ////HeaderCell.ColumnSpan = 22;
                ////HeaderCell.CssClass = "HeaderStyle1";
                ////HeaderRow.Cells.Add(HeaderCell);

                //////Adding Revenue Column
                ////HeaderCell = new TableCell();
                ////HeaderCell.Text = "Buying House";
                ////HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                ////HeaderCell.ColumnSpan = 5 + Public_Count; // For merging three columns (Direct, Referral, Total)
                ////HeaderCell.CssClass = "HeaderStyle2";
                ////HeaderRow.Cells.Add(HeaderCell);

                //////Adding the Row at the 0th position (first row) in the Grid
                ////gvClientCostingDefaults.Controls[0].Controls.AddAt(0, HeaderRow);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //DataSet ds = new DataSet();
                //ds = adminControlInstance.GetClientCostingDefaults_New(ClientID);
                DataRowView drv = (DataRowView)e.Row.DataItem;

                string ClientName_Data = drv.Row.ItemArray[0] == DBNull.Value ? "" : drv.Row.ItemArray[0].ToString() == "0" ? "" : drv.Row.ItemArray[0].ToString();
                string ClientID_Data = drv.Row.ItemArray[1] == DBNull.Value ? "" : drv.Row.ItemArray[1].ToString() == "0" ? "" : drv.Row.ItemArray[1].ToString();
                string DepartmentName_Data = drv.Row.ItemArray[2] == DBNull.Value ? "" : drv.Row.ItemArray[2].ToString() == "0" ? "" : drv.Row.ItemArray[2].ToString();
                string DeptId_Data = drv.Row.ItemArray[3] == DBNull.Value ? "" : drv.Row.ItemArray[3].ToString() == "0" ? "" : drv.Row.ItemArray[3].ToString();
                string COMMISION_Data = drv.Row.ItemArray[4] == DBNull.Value ? "" : drv.Row.ItemArray[4].ToString() == "0" ? "" : drv.Row.ItemArray[4].ToString();
                string CONVERSIONTO_Data = drv.Row.ItemArray[5] == DBNull.Value ? "" : drv.Row.ItemArray[5].ToString() == "0" ? "" : drv.Row.ItemArray[5].ToString();
                string COFFIN_BOX_Data = drv.Row.ItemArray[6] == DBNull.Value ? "" : drv.Row.ItemArray[6].ToString() == "0" ? "" : drv.Row.ItemArray[6].ToString();
                string HANGERLOOPS_Data = drv.Row.ItemArray[7] == DBNull.Value ? "" : drv.Row.ItemArray[7].ToString() == "0" ? "" : drv.Row.ItemArray[7].ToString();
                string TAGS_Data = drv.Row.ItemArray[8] == DBNull.Value ? "" : drv.Row.ItemArray[8].ToString() == "0" ? "" : drv.Row.ItemArray[8].ToString();
                string OVERHEADCOST_Data = drv.Row.ItemArray[9] == DBNull.Value ? "" : drv.Row.ItemArray[9].ToString() == "0" ? "" : drv.Row.ItemArray[9].ToString();
                string PROFITMARGIN_data = drv.Row.ItemArray[10] == DBNull.Value ? "" : drv.Row.ItemArray[10].ToString() == "0" ? "" : drv.Row.ItemArray[10].ToString();
                string TEST_Data = drv.Row.ItemArray[11] == DBNull.Value ? "" : drv.Row.ItemArray[11].ToString() == "0" ? "" : drv.Row.ItemArray[11].ToString();
                string HANGERS_Data = drv.Row.ItemArray[12] == DBNull.Value ? "" : drv.Row.ItemArray[12].ToString() == "0" ? "" : drv.Row.ItemArray[12].ToString();
                string DESIGNCOMM_Data = drv.Row.ItemArray[13] == DBNull.Value ? "" : drv.Row.ItemArray[13].ToString() == "0" ? "" : drv.Row.ItemArray[13].ToString();
                string ACHIEVEMENT_Data = drv.Row.ItemArray[14] == DBNull.Value ? "" : drv.Row.ItemArray[14].ToString() == "0" ? "" : drv.Row.ItemArray[14].ToString();
                string EXPECTEDQTY_Data = drv.Row.ItemArray[15] == DBNull.Value ? "" : drv.Row.ItemArray[15].ToString() == "0" ? "" : drv.Row.ItemArray[15].ToString();
                string ExpectedID_Data = drv.Row.ItemArray[16] == DBNull.Value ? "" : drv.Row.ItemArray[16].ToString() == "0" ? "" : drv.Row.ItemArray[16].ToString();
                string FrightUptoPort_Data = drv.Row.ItemArray[17] == DBNull.Value ? "" : drv.Row.ItemArray[17].ToString() == "0" ? "" : drv.Row.ItemArray[17].ToString();
                string SizeSet1_Data = drv.Row.ItemArray[18] == DBNull.Value ? "" : drv.Row.ItemArray[18].ToString() == "0" ? "" : drv.Row.ItemArray[18].ToString();
                string SizeSet2_Data = drv.Row.ItemArray[19] == DBNull.Value ? "" : drv.Row.ItemArray[19].ToString() == "0" ? "" : drv.Row.ItemArray[19].ToString();
                string SizeSet3_Data = drv.Row.ItemArray[20] == DBNull.Value ? "" : drv.Row.ItemArray[20].ToString() == "0" ? "" : drv.Row.ItemArray[20].ToString();
                string SizeSet4_Data = drv.Row.ItemArray[21] == DBNull.Value ? "" : drv.Row.ItemArray[21].ToString() == "0" ? "" : drv.Row.ItemArray[21].ToString();
                string COSTINGWASTE_Data = drv.Row.ItemArray[22] == DBNull.Value ? "" : drv.Row.ItemArray[22].ToString() == "0" ? "" : drv.Row.ItemArray[22].ToString();
                string IkandiLAFFOBMode_Data = drv.Row.ItemArray[23] == DBNull.Value ? "" : drv.Row.ItemArray[23].ToString() == "0" ? "" : drv.Row.ItemArray[23].ToString();
                string IkandiLAHFOBMode_Data = drv.Row.ItemArray[24] == DBNull.Value ? "" : drv.Row.ItemArray[24].ToString() == "0" ? "" : drv.Row.ItemArray[24].ToString();
                string IkandiLSFFOBMode_Data = drv.Row.ItemArray[25] == DBNull.Value ? "" : drv.Row.ItemArray[25].ToString() == "0" ? "" : drv.Row.ItemArray[25].ToString();
                string IkandiLSHFOBMode_Data = drv.Row.ItemArray[26] == DBNull.Value ? "" : drv.Row.ItemArray[26].ToString() == "0" ? "" : drv.Row.ItemArray[26].ToString();
                string IkandidDirectMode_Data = drv.Row.ItemArray[27] == DBNull.Value ? "" : drv.Row.ItemArray[27].ToString() == "0" ? "" : drv.Row.ItemArray[27].ToString();
                string Gradingextra_Data = drv.Row.ItemArray[28] == DBNull.Value ? "" : drv.Row.ItemArray[28].ToString() == "0" ? "" : drv.Row.ItemArray[28].ToString();
                string MinOverHead_Data = drv.Row.ItemArray[29] == DBNull.Value ? "" : drv.Row.ItemArray[29].ToString() == "0" ? "" : drv.Row.ItemArray[29].ToString();
                string MinCMT_Data = drv.Row.ItemArray[30] == DBNull.Value ? "" : drv.Row.ItemArray[30].ToString() == "0" ? "" : drv.Row.ItemArray[30].ToString();
                string MaxOverHead_Data = drv.Row.ItemArray[31] == DBNull.Value ? "" : drv.Row.ItemArray[31].ToString() == "0" ? "" : drv.Row.ItemArray[31].ToString();
                string MinProfit_Data = drv.Row.ItemArray[32] == DBNull.Value ? "" : drv.Row.ItemArray[32].ToString() == "0" ? "" : drv.Row.ItemArray[32].ToString();
                string IsOHPercent_Data = drv.Row.ItemArray[33] == DBNull.Value ? "" : drv.Row.ItemArray[33].ToString() == "0" ? "" : drv.Row.ItemArray[33].ToString();
                string OHValue_Data = drv.Row.ItemArray[34] == DBNull.Value ? "" : drv.Row.ItemArray[34].ToString() == "0" ? "" : drv.Row.ItemArray[34].ToString();
                string Discount_Percent_Data = drv.Row.ItemArray[35] == DBNull.Value ? "" : drv.Row.ItemArray[35].ToString() == "0" ? "" : drv.Row.ItemArray[35].ToString();
                string Payment_Days_Data = drv.Row.ItemArray[36] == DBNull.Value ? "" : drv.Row.ItemArray[36].ToString() == "0" ? "" : drv.Row.ItemArray[36].ToString();
                string Duty_Percent_Data = drv.Row.ItemArray[37] == DBNull.Value ? "" : drv.Row.ItemArray[37].ToString() == "0" ? "" : drv.Row.ItemArray[37].ToString();
                string Handling_Data = drv.Row.ItemArray[38] == DBNull.Value ? "" : drv.Row.ItemArray[38].ToString() == "0" ? "" : drv.Row.ItemArray[38].ToString();
                string Delivery_Data = drv.Row.ItemArray[39] == DBNull.Value ? "" : drv.Row.ItemArray[39].ToString() == "0" ? "" : drv.Row.ItemArray[39].ToString();
                string IkandiMargin = drv.Row.ItemArray[40] == DBNull.Value ? "" : drv.Row.ItemArray[40].ToString() == "0" ? "" : drv.Row.ItemArray[40].ToString();
                string IkandiHaulage = drv.Row.ItemArray[41] == DBNull.Value ? "" : drv.Row.ItemArray[41].ToString() == "0" ? "" : drv.Row.ItemArray[41].ToString();

                //new Code 06 feb 2020 start
                string IsCMTOpen = drv.Row.ItemArray[42] == DBNull.Value ? "" : drv.Row.ItemArray[42].ToString() == "0" ? "" : drv.Row.ItemArray[42].ToString();
                //new Code 06 feb 2020 end


                //string PrevPendPO = drv.Row.ItemArray[1] == DBNull.Value ? "" : drv.Row.ItemArray[1].ToString();
                //string FiveWeekPend = drv.Row.ItemArray[2] == DBNull.Value ? "" : drv.Row.ItemArray[2].ToString();
                HiddenField hdnClientId = new HiddenField();
                hdnClientId.ID = "hdnClientId";
                
                Label ClientName = e.Row.FindControl("ClientName") as Label;
                ClientName.Text = ClientName_Data;
                ClientName.Style.Add("color", "blue");
               // e.Row.Cells[0].Width = 90;
                e.Row.Cells[0].Controls.Add(hdnClientId);
                hdnClientId.Value = ClientID_Data;
                ClientName.CssClass = "hdnclientid";

                HiddenField hdnDeptId = new HiddenField();
                hdnDeptId.ID = "hdnDeptId";
                Label DepartmentName = e.Row.FindControl("DepartmentName") as Label;
                DepartmentName.Text = DepartmentName_Data;
                DepartmentName.Style.Add("color", "blue");
               // e.Row.Cells[1].Width = 137;
                e.Row.Cells[1].Controls.Add(hdnDeptId);
                hdnDeptId.Value = DeptId_Data;

                DropDownList Convto = e.Row.FindControl("Convto") as DropDownList;
                BindCurrency(Convto, Convert.ToInt32(CONVERSIONTO_Data));
                Convto.SelectedValue = CONVERSIONTO_Data;
                Convto.Style.Add("color", "black");
               // e.Row.Cells[2].Width = 47;
                Convto.Attributes.Add("onchange", "javascript:return UpdateAchievement_ByClient(this,1)");
               // Convto.Attributes.Add("onchange", "javascript:return ConverCurrency(this)");


                TextBox CoffinBox = e.Row.FindControl("CoffinBox") as TextBox;
                CoffinBox.Text = COFFIN_BOX_Data;
                CoffinBox.Style.Add("color", "blue");
               // e.Row.Cells[3].Width = 49;
                CoffinBox.Attributes.Add("onchange", "javascript:return UpdateAchievement_ByClient(this,2)");


                TextBox Lbltags = e.Row.FindControl("Lbltags") as TextBox;
                Lbltags.Text = TAGS_Data;
                Lbltags.Style.Add("color", "blue");
               // e.Row.Cells[4].Width = 49;
                Lbltags.Attributes.Add("onchange", "javascript:return UpdateAchievement_ByClient(this,3)");

                TextBox Test = e.Row.FindControl("Test") as TextBox;
                Test.Text = TEST_Data;
                Test.Style.Add("color", "blue");
               // e.Row.Cells[5].Width = 49;
                Test.Attributes.Add("onchange", "javascript:return UpdateAchievement_ByClient(this,4)");


                TextBox Hangers = e.Row.FindControl("Hangers") as TextBox;
                Hangers.Text = HANGERS_Data;
                Hangers.Style.Add("color", "blue");
              //  e.Row.Cells[6].Width = 49;
                Hangers.Attributes.Add("onchange", "javascript:return UpdateAchievement_ByClient(this,5)");

                TextBox Hangerloops = e.Row.FindControl("Hangerloops") as TextBox;
                Hangerloops.Text = HANGERLOOPS_Data;
                Hangerloops.Style.Add("color", "blue");
              //  e.Row.Cells[7].Width = 49;
                Hangerloops.Attributes.Add("onchange", "javascript:return UpdateAchievement_ByClient(this,6)");

                TextBox MinCMT = e.Row.FindControl("MinCMT") as TextBox;
                MinCMT.Text = MinCMT_Data;
                MinCMT.Style.Add("color", "blue");
             //   e.Row.Cells[8].Width = 49;
                MinCMT.Attributes.Add("onchange", "javascript:return UpdateAchievement_ByClient(this,7)");

                //NEW CODE 06 FEB 2020 START
                CheckBox IsCMT = e.Row.FindControl("IsCMT") as CheckBox;
                IsCMT.Checked = Convert.ToBoolean(IsCMTOpen);
                IsCMT.Style.Add("color", "black");
               // e.Row.Cells[9].Width = 49;
                IsCMT.Attributes.Add("onclick", "javascript:UpdateClientCostingValues_ByClient_OverHead(this,'27','" + DataBinder.Eval(e.Row.DataItem, "ClientID").ToString() + "','" + DataBinder.Eval(e.Row.DataItem, "DeptId").ToString() + "')");
                //NEW CODE 06 FEB 2020 END

                CheckBox IsOH = e.Row.FindControl("IsOH") as CheckBox;
                IsOH.Checked = Convert.ToBoolean(IsOHPercent_Data);
                IsOH.Style.Add("color", "black");
               // e.Row.Cells[10].Width = 49;
                IsOH.Attributes.Add("onclick", "javascript:UpdateClientCostingValues_ByClient_OverHead(this,'8','" + DataBinder.Eval(e.Row.DataItem, "ClientID").ToString() + "','" + DataBinder.Eval(e.Row.DataItem, "DeptId").ToString() + "')");

                TextBox OHCostValue = e.Row.FindControl("OHCostValue") as TextBox;
                OHCostValue.Text = OHValue_Data;
                OHCostValue.Style.Add("color", "blue");
              //  e.Row.Cells[11].Width = 49;
                OHCostValue.Attributes.Add("onchange", "javascript:return UpdateAchievement_ByClient_IsChecked(this,9)");

                TextBox OHCost = e.Row.FindControl("OHCost") as TextBox;
                OHCost.Text = OVERHEADCOST_Data;
                OHCost.Style.Add("color", "blue");
              //  e.Row.Cells[12].Width = 49;
                OHCost.Attributes.Add("onchange", "javascript:return UpdateAchievement_ByClient(this,10)");

                TextBox MinProfit_Percent = e.Row.FindControl("MinProfit_Percent") as TextBox;
                MinProfit_Percent.Text = MinProfit_Data;
                MinProfit_Percent.Style.Add("color", "blue");
              //  e.Row.Cells[13].Width = 49;
                MinProfit_Percent.Attributes.Add("onchange", "javascript:return UpdateAchievement_ByClient(this,11)");


                TextBox Profit_margin_Percent = e.Row.FindControl("Profit_margin_Percent") as TextBox;
                Profit_margin_Percent.Text = PROFITMARGIN_data;
                Profit_margin_Percent.Style.Add("color", "blue");
              //  e.Row.Cells[14].Width = 49;
                Profit_margin_Percent.Attributes.Add("onchange", "javascript:return UpdateAchievement_ByClient(this,12)");

                TextBox Commision_Percent = e.Row.FindControl("Commision_Percent") as TextBox;
                Commision_Percent.Text = COMMISION_Data;
                Commision_Percent.Style.Add("color", "blue");
               // e.Row.Cells[15].Width = 59;
                Commision_Percent.Attributes.Add("onchange", "javascript:return UpdateAchievement_ByClient(this,13)");

                //TextBox Discount_Percent = e.Row.FindControl("Discount_Percent") as TextBox;
                //Discount_Percent.Text = Discount_Percent_Data;
                //Discount_Percent.Style.Add("color", "blue");
                //e.Row.Cells[15].Width = 50;
                //Discount_Percent.Attributes.Add("onchange", "javascript:return UpdateAchievement_ByClient(this,14)");

                TextBox Payment_Days = e.Row.FindControl("Payment_Days") as TextBox;
                Payment_Days.Text = Payment_Days_Data;
                Payment_Days.Style.Add("color", "blue");
              //  e.Row.Cells[16].Width = 49;
                Payment_Days.Attributes.Add("onchange", "javascript:return UpdateAchievement_ByClient(this,15)");

                DropDownList Expectedqty = e.Row.FindControl("Expectedqty") as DropDownList;
                WastageRange(Expectedqty, ExpectedID_Data);
                Expectedqty.SelectedValue = EXPECTEDQTY_Data;
                Expectedqty.Style.Add("color", "black");
                //e.Row.Cells[17].Width = 99;
                Expectedqty.Attributes.Add("onchange", "javascript:return UpdateAchievement_ByClient(this,16)");


                TextBox Frtuptoport = e.Row.FindControl("Frtuptoport") as TextBox;
                Frtuptoport.Text = FrightUptoPort_Data;
                Frtuptoport.Style.Add("color", "blue");
               // e.Row.Cells[18].Width = 49;
                Frtuptoport.Attributes.Add("onchange", "javascript:return UpdateAchievement_ByClient(this,17)");

                DropDownList SizeSet1 = e.Row.FindControl("SizeSet1") as DropDownList;
                //SizeSet1.SelectedIndex =Convert.ToInt32(SizeSet1_Data);
                SizeSet(SizeSet1, SizeSet1_Data);
                SizeSet1.Style.Add("color", "black");
               // e.Row.Cells[19].Width = 69;
                SizeSet1.Attributes.Add("onchange", "javascript:return UpdateSize_ByClient(this,18)");

                DropDownList SizeSet2 = e.Row.FindControl("SizeSet2") as DropDownList;
                //SizeSet2.SelectedValue = SizeSet2_Data;
                SizeSet(SizeSet2, SizeSet2_Data);
                SizeSet2.Style.Add("color", "black");
               // e.Row.Cells[20].Width = 69;
                SizeSet2.Attributes.Add("onchange", "javascript:return UpdateSize_ByClient(this,19)");

                DropDownList SizeSet3 = e.Row.FindControl("SizeSet3") as DropDownList;
                //SizeSet3.SelectedValue = SizeSet3_Data;
                SizeSet(SizeSet3, SizeSet3_Data);
                SizeSet3.Style.Add("color", "black");
               // e.Row.Cells[21].Width = 69;
                SizeSet3.Attributes.Add("onchange", "javascript:return UpdateSize_ByClient(this,20)");

                DropDownList SizeSet4 = e.Row.FindControl("SizeSet4") as DropDownList;
                //SizeSet4.SelectedValue = SizeSet4_Data;
                SizeSet(SizeSet4, SizeSet4_Data);
                SizeSet4.Style.Add("color", "black");
               // e.Row.Cells[22].Width = 69;
                SizeSet4.Attributes.Add("onchange", "javascript:return UpdateSize_ByClient(this,21)");

                TextBox Duty_Percent = e.Row.FindControl("Duty_Percent") as TextBox;
                Duty_Percent.Text = Duty_Percent_Data;
                Duty_Percent.Style.Add("color", "blue");
               // e.Row.Cells[23].Width = 49;
                Duty_Percent.Attributes.Add("onchange", "javascript:return UpdateSize_ByClient(this,22)");

                TextBox Handling = e.Row.FindControl("Handling") as TextBox;
                Handling.Text = Handling_Data;
                Handling.Style.Add("color", "blue");
               // e.Row.Cells[24].Width = 49;
                Handling.Attributes.Add("onchange", "javascript:return UpdateSize_ByClient(this,23)");

                TextBox Delivery = e.Row.FindControl("Delivery") as TextBox;
                Delivery.Text = Delivery_Data;
                Delivery.Style.Add("color", "blue");
              //  e.Row.Cells[25].Width = 49;
                Delivery.Attributes.Add("onchange", "javascript:return UpdateSize_ByClient(this,24)");


                TextBox IkandiMargins = e.Row.FindControl("IkandiMargin") as TextBox;
                IkandiMargins.Text = IkandiMargin;
                IkandiMargins.Style.Add("color", "blue");
               // e.Row.Cells[26].Width = 49;
                IkandiMargins.Attributes.Add("onchange", "javascript:return UpdateSize_ByClient(this,25)");

                TextBox IkandiHaulages = e.Row.FindControl("IkandiHaulage") as TextBox;
                IkandiHaulages.Text = IkandiHaulage;
                IkandiHaulages.Style.Add("color", "blue");
              //  e.Row.Cells[27].Width = 49;
                IkandiHaulages.Attributes.Add("onchange", "javascript:return UpdateSize_ByClient(this,26)");




                 int Count = Convert.ToInt32(ds.Tables[1].Rows.Count) - 1;
                 int Client = Convert.ToInt32(ds.Tables[0].Rows.Count);
                if (Convert.ToInt32(ds.Tables[1].Rows.Count) > 0)
                {
                    for (int i = 0; i <= Count; i++)
                    {
                        string ModeName = Convert.ToString(ds.Tables[1].Rows[i]["CODE"]);
                        string Code_Data = "CODE" + ModeName;
                        CheckBox IsModeCheck = e.Row.FindControl(Code_Data) as CheckBox;
                        if (Client > 0)
                        {
                            IsModeCheck.Checked = adminControlInstance.GetClientCostingDefaults_BreakDown_New(ClientID_Data, ModeName, DeptId_Data); // EFW.ToString();                                  
                            //IsModeCheck.Style.Add("width", "50px");
                        }
                         HiddenField HdnModeCheck = new HiddenField();
                         HdnModeCheck.Value = ModeName;
                         e.Row.Cells[i + 26].Controls.Add(HdnModeCheck);
                        IsModeCheck.Attributes.Add("onclick", "javascript:UpdateMode_ByClient_IsChecked(this,'" + ModeName + "')");
                    }

                }

                //Label POCount = e.Row.FindControl("POCount") as Label;
                //if (PrevPendPO == "0" || PrevPendPO == "")
                //{
                //    e.Row.Cells[1].CssClass = "Background-green";
                //    e.Row.Cells[1].Width = 70;

                //}
                //else
                //{
                //    POCount.Text = PrevPendPO;
                //    e.Row.Cells[1].CssClass = "Background-red";
                //    e.Row.Cells[1].Width = 70;
                //}

                //Label PONextFiveWeek = e.Row.FindControl("PONextFiveWeek") as Label;

                //if (FiveWeekPend == "0" || FiveWeekPend == "")
                //{
                //    e.Row.Cells[2].CssClass = "Background-green";
                //    e.Row.Cells[2].Width = 70;
                //}
                //else
                //{
                //    e.Row.Cells[2].CssClass = "Background-red";
                //    PONextFiveWeek.Text = FiveWeekPend;
                //    e.Row.Cells[2].Width = 70;
                //}

                //int Count = Convert.ToInt32(ds.Tables[1].Rows.Count);
                //string AMName = AM;
                //if (Convert.ToInt32(ds.Tables[1].Rows.Count) > 0)
                //{
                //    for (int iExfactory = 0; iExfactory < Count; iExfactory++)
                //    {
                //        string AMexFactor = Convert.ToString(ds.Tables[1].Rows[iExfactory]["Exfactory"]);
                //        HtmlTableCell exfactorynew = e.Row.FindControl("Exfactory" + Convert.ToString(ds.Tables[1].Rows[iExfactory]["Exfactory"])) as HtmlTableCell;
                //        Label exfactory = e.Row.FindControl("Exfactory" + Convert.ToString(ds.Tables[1].Rows[iExfactory]["Exfactory"])) as Label;
                //        exfactory.Text = objadmin.Get_POBreakDown(AMName, AMexFactor); // EFW.ToString();
                //        exfactory.Style.Add("width", "70px");
                //        // exfactory.Value = "2"; // EFW.ToString();                                      
                //        if (exfactory.Text == "0" || exfactory.Text == "")
                //        {
                //            e.Row.Cells[iExfactory + 3].CssClass = "Background-green";
                //            e.Row.Cells[iExfactory + 3].Width = 70;
                //            exfactory.Text = "";

                //        }
                //        else
                //        {
                //            e.Row.Cells[iExfactory + 3].CssClass = "Background-red";
                //            e.Row.Cells[iExfactory + 3].Width = 70;

                //        }

                //    }

                //}



                //-------------------------Backup Loop Row-----------------//

                

                //if (Client > 0)
                //{
                //    for (int i = 0; i < Client - 1; i++)
                //    {

                //        string Client_ID = Convert.ToString(ds.Tables[0].Rows[i]["ClientID"]);
                //        string Dept_ID = Convert.ToString(ds.Tables[0].Rows[i]["DeptId"]);
                //        if (Convert.ToInt32(ds.Tables[1].Rows.Count) > 0)
                //        {
                //            for (int iCount = 0; iCount < Count; iCount++)
                //            {

                //                string Code_Data = Convert.ToString(ds.Tables[1].Rows[iCount]["Code"]);
                //                CheckBox CODE = e.Row.FindControl("CODE" + Convert.ToString(ds.Tables[1].Rows[iCount]["CODE"])) as CheckBox;
                //                CODE.Checked = Convert.ToBoolean( adminControlInstance.GetClientCostingDefaults_BreakDown_New(Client_ID, Code_Data, Dept_ID)); // EFW.ToString();
                //                //CODE.Checked = true;
                //                CODE.Style.Add("width", "70px");


                //            }

                //        }
                //    }
                //}
                //-------------------------------End Loop-------------------------------------------------


                //----------------------End Of Loop----------------------//
                //string ElevenWeek = drv.Row.ItemArray[3] == DBNull.Value ? "" : drv.Row.ItemArray[3].ToString();
                //Label PONext11WeekToEnd = e.Row.FindControl("PONext11WeekToEnd") as Label;
                //// PONext11WeekToEnd.Value = ElevenWeek;
                //if (ElevenWeek == "" || ElevenWeek == "0")
                //{
                //    PONext11WeekToEnd.Text = "";
                //    e.Row.Cells[Count + 3].Width = 70;
                //}
                //else
                //{
                //    PONext11WeekToEnd.Text = ElevenWeek;
                //    e.Row.Cells[Count + 3].Width = 70;
                //}
                //string PoTotal = drv.Row.ItemArray[4] == DBNull.Value ? "" : drv.Row.ItemArray[4].ToString();
                //Label PendingTotal = e.Row.FindControl("PendingTotal") as Label;

                //if (PoTotal == "" || PoTotal == "0")
                //{
                //    PendingTotal.Text = "";
                //    e.Row.Cells[Count + 4].Width = 70;
                //}
                //else
                //{
                //    PendingTotal.Text = PoTotal;
                //    e.Row.Cells[Count + 4].Width = 70;
                //}


                //for (int i = 0; i <= 14; i++)
                //{
                //    int value = i + 1;
                //    var Option = "Option" + value;                    
                //    SizeSet1.Items.Insert(i, new ListItem(Option, value.ToString()));
                //    SizeSet2.Items.Insert(i, new ListItem(Option, value.ToString()));
                //    SizeSet3.Items.Insert(i, new ListItem(Option, value.ToString()));
                //    SizeSet4.Items.Insert(i, new ListItem(Option, value.ToString()));
                //}


            }
        }
        private void BindCurrency(DropDownList Convto, int CurrencyId)
        {
            DataTable dtCurrency = (DataTable)ViewState["currency"];
            Convto.DataSource = dtCurrency;
            Convto.DataTextField = "CurrencySymbol";
            Convto.DataValueField = "Id";
            Convto.DataBind();
            if (CurrencyId != -1)
            {
                Convto.SelectedValue = CurrencyId.ToString();
            }
        }

        private void WastageRange(DropDownList Expectedqty, string WastageRangeId)
        {
            DataTable dtWastageRange = (DataTable)ViewState["WastageRange"];

            Expectedqty.DataSource = dtWastageRange;
            Expectedqty.DataTextField = "EXPECTEDQTY";
            Expectedqty.DataValueField = "ExpectedID";
            Expectedqty.DataBind();
            if (WastageRangeId != "")
            {
                Expectedqty.SelectedValue = WastageRangeId.ToString();
            }
        }
        private void SizeSet(DropDownList sizeset, string SizeSet1_Data)
        {
            DataTable dtSizeSet = (DataTable)ViewState["Size_Set"];

            sizeset.DataSource = dtSizeSet;
            sizeset.DataTextField = "SizeValue";
            sizeset.DataValueField = "ID";
            sizeset.DataBind();
            if (SizeSet1_Data != "")
            {
                sizeset.SelectedValue = SizeSet1_Data.ToString();
            }
        }

    }
}
