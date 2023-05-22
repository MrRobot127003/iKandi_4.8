using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Web.Components;
using iKandi.Common;
using System.Data;
using System.Web.UI.HtmlControls;

namespace iKandi.Web.UserControls.Forms
{
    public partial class CuttingFormNew : BaseUserControl
    {

        #region Properties
        iKandi.Common.Order order;
        DataSet ds = new DataSet();
        DataTable dtQty = new DataTable();
        string strODId1 = "";
        string strODId2 = "";
        string strODId3 = "";
        string strODId4 = "";
        string strODId19 = "";
        string strODId20 = "";


        int TotalQuantity1 = 0;
        int TotalQuantity2 = 0;
        int TotalQuantity3 = 0;
        int TotalQuantity4 = 0;
        int TotalQuantity5 = 0;
        int TotalQuantity6 = 0;
        int TotalQuantity7 = 0;
        int TotalQuantity8 = 0;
        int TotalQuantity9 = 0;
        int TotalQuantity10 = 0;
        int TotalQuantity11 = 0;
        int TotalQuantity12 = 0;
        int TotalQuantity13 = 0;
        int TotalQuantity14 = 0;
        int TotalQuantity15 = 0;

        //private int OrderID
        //{
        //    get
        //    {
        //        if (null != Request.QueryString["orderid"])
        //        {
        //            int orderid;

        //            if (int.TryParse(Request.QueryString["orderid"].ToString(), out orderid))
        //                return orderid;
        //        }

        //        return -1;
        //    }
        //}
        private int OrderID
        {
            get;
            set;
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            getquerystring();
            if (!IsPostBack)
            {
                BindSeriralNoTab();
                if (OrderID > 0)
                {
                    BindControls();
                }
                else
                {

                    pnlserialdetail.Visible = false;
                }
                //grdCuttingOption1.Visible=false;
                //grdCuttinOption2.Visible = false;
                //grdCuttingOption3.Visible=false;
                //grdCuttingOption4.Visible = false;
            }
            //hdnbackcol.Value = OrderID.ToString();
        }
        public void getquerystring()
        {
            if (null != Request.QueryString["orderid"])
            {
                int orderid;

                if (int.TryParse(Request.QueryString["orderid"].ToString(), out orderid))
                    OrderID = Convert.ToInt32(Request.QueryString["orderid"]);

            }
            else
            {
                DataTable dt = this.OrderControllerInstance.GetCuttingSheettabs(System.Web.HttpContext.Current.Session.SessionID, Convert.ToInt32(Session["OrderDetailId_CuttingSheet"]));
                OrderID = Convert.ToInt32(dt.Rows[0]["OrderID"].ToString());
            }
        }
        public void BindSeriralNoTab()
        {
            DataTable dt = this.OrderControllerInstance.GetCuttingSheettabs(System.Web.HttpContext.Current.Session.SessionID, Convert.ToInt32(Session["OrderDetailId_CuttingSheet"]));
            if (dt.Rows.Count > 0)
            {
                //int orderid = Convert.ToInt32(dt.Rows[0]["OrderID"].ToString());
                //Response.Redirect("../Fabric/CuttingSheet.aspx?OrderID=" + orderid);

                repeaterCuttingSheet.DataSource = dt;
                repeaterCuttingSheet.DataBind();



            }
        }
        protected void repeaterCuttingSheet_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField hdnorderid = (HiddenField)e.Item.FindControl("hdnorderid");
            HtmlGenericControl spanid = (HtmlGenericControl)e.Item.FindControl("spanid");
            if (hdnorderid != null)
            {
                if (hdnorderid.Value == OrderID.ToString())
                {
                    spanid.Attributes["class"] = "costing-sheet activeback";
                }
            }
        }
        protected void GridHeader()
        {
            //if (e.Row.RowType != DataControlRowType.Header)
            //    return;
            //GridView HeaderGrid = (GridView)sender;

            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            for (int i = 1; i <= 12; i++)
            {
                TemplateField Size = new TemplateField();
                Size.HeaderText = i.ToString();
                Size.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "lblSize" + i, "lblSize" + i);
                Size.ItemStyle.CssClass = "accorforstyle14";
                //Extra.ItemStyle.Width = 80;
                Size.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                grdCuttingOption1.Columns.Insert(4 + i, Size);
                grdCuttingOption1.HeaderStyle.Height = 59;



            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            SaveCuttingData();
        }
        private void SaveCuttingData()
        {
            Cutting cutting = new Cutting();

            Cutting cuttingOld = this.CuttingControllerInstance.GetCuttingByOrderID(OrderID);

            cutting.order = new iKandi.Common.Order();

            cutting.order.OrderID = OrderID;

            if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager))
            {
                cutting.ApprovedByFabricHead = Convert.ToInt32(Convert.ToBoolean(chkboxFabricHead.Checked));

                cutting.ApprovedByProductionHead = cuttingOld.ApprovedByProductionHead;
                cutting.ApprovedByProductionHeadOn = cuttingOld.ApprovedByProductionHeadOn;
                cutting.ApprovedByMerchant = cuttingOld.ApprovedByMerchant;
                cutting.ApprovedByMerchantOn = cuttingOld.ApprovedByMerchantOn;

                if ((chkboxFabricHead.Checked) == true)
                    if (cuttingOld.ApprovedByFabricHead == 0)
                        cutting.ApprovedByFabricHeadOn = Convert.ToDateTime(hiddenFab.Value);
                    else
                        cutting.ApprovedByFabricHeadOn = cuttingOld.ApprovedByFabricHeadOn;
            }

            if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Production_Manager))
            {
                cutting.ApprovedByProductionHead = Convert.ToInt32(Convert.ToBoolean(chkboxProductionHead.Checked));

                cutting.ApprovedByFabricHead = cuttingOld.ApprovedByFabricHead;
                cutting.ApprovedByFabricHeadOn = cuttingOld.ApprovedByFabricHeadOn;
                cutting.ApprovedByMerchant = cuttingOld.ApprovedByMerchant;
                cutting.ApprovedByMerchantOn = cuttingOld.ApprovedByMerchantOn;

                if ((chkboxProductionHead.Checked) == true)
                    if (cuttingOld.ApprovedByProductionHead == 0)
                        cutting.ApprovedByProductionHeadOn = Convert.ToDateTime(hiddenProd.Value);
                    else
                        cutting.ApprovedByProductionHeadOn = cuttingOld.ApprovedByProductionHeadOn;
            }

            if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_AccountManager))
            {
                cutting.ApprovedByMerchant = Convert.ToInt32(Convert.ToBoolean(chkboxMerchant.Checked));


                cutting.ApprovedByFabricHead = cuttingOld.ApprovedByFabricHead;
                cutting.ApprovedByFabricHeadOn = cuttingOld.ApprovedByFabricHeadOn;
                cutting.ApprovedByProductionHead = cuttingOld.ApprovedByProductionHead;
                cutting.ApprovedByProductionHeadOn = cuttingOld.ApprovedByProductionHeadOn;

                if ((chkboxMerchant.Checked) == true)
                    if (cuttingOld.ApprovedByMerchant == 0)
                        cutting.ApprovedByMerchantOn = Convert.ToDateTime(hiddenAccount.Value);
                    else
                        cutting.ApprovedByMerchantOn = cuttingOld.ApprovedByMerchantOn;
            }

            if (OrderID == cuttingOld.order.OrderID)
            {
                cutting.Id = cuttingOld.Id;
                this.CuttingControllerInstance.UpdateCutting(cutting);
            }
            else
                this.CuttingControllerInstance.InsertCutting(cutting);
        }

        private void PopulateCuttingData()
        {
            Cutting cutting = this.CuttingControllerInstance.GetCuttingByOrderID(OrderID);

            //if (Convert.ToDateTime(cutting.order.Style.InLineCutDate) == DateTime.MinValue)
            //    lblInlineCutDate.Text = string.Empty;
            //else
            //    lblInlineCutDate.Text = cutting.order.Style.InLineCutDate.ToString("dd MMM yy (ddd) ");

            if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager))
            {
                chkboxFabricHead.Enabled = true;
                chkboxMerchant.Enabled = false;
                chkboxProductionHead.Enabled = false;
            }

            else if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Production_Manager))
            {
                chkboxFabricHead.Enabled = false;
                chkboxMerchant.Enabled = false;
                chkboxProductionHead.Enabled = true;
            }

            else if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_AccountManager))
            {
                chkboxFabricHead.Enabled = false;
                chkboxMerchant.Enabled = true;
                chkboxProductionHead.Enabled = false;
            }
            else
            {
                chkboxFabricHead.Enabled = false;
                chkboxMerchant.Enabled = false;
                chkboxProductionHead.Enabled = false;
            }

            if (OrderID == cutting.order.OrderID)
            {
                if (cutting.ApprovedByMerchant == 1)
                {
                    chkboxMerchant.Checked = true;
                    chkboxMerchant.Enabled = false;
                }

                if (cutting.ApprovedByFabricHead == 1)
                {
                    chkboxFabricHead.Checked = true;
                    chkboxFabricHead.Enabled = false;
                }

                if (cutting.ApprovedByProductionHead == 1)
                {
                    chkboxProductionHead.Checked = true;
                    chkboxProductionHead.Enabled = false;
                }

            }

        }

        private void BindControls()
        {



            if (OrderID != -1)
            {
                lblIssueDate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");
                if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager))
                {
                    //chkboxFabricHead.Enabled = true;
                    chkboxMerchant.Enabled = false;
                    //chkboxProductionHead.Enabled = false;
                }

                else if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Production_Manager))
                {
                    //chkboxFabricHead.Enabled = false;
                    chkboxMerchant.Enabled = false;
                    //chkboxProductionHead.Enabled = true;
                }

                else if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_AccountManager))
                {
                    // chkboxFabricHead.Enabled = false;
                    chkboxMerchant.Enabled = true;
                    //chkboxProductionHead.Enabled = false;
                }
                else
                {
                    //chkboxFabricHead.Enabled = false;
                    chkboxMerchant.Enabled = false;
                    //chkboxProductionHead.Enabled = false;
                }
                order = this.OrderControllerInstance.GetOrder(OrderID);
                lblSerial.Text = order.SerialNumber.ToString();
                lblStyleNo.Text = order.Style.StyleNumber.ToString();
                lblBuyer.Text = order.Style.client.CompanyName;
                lblDepartment.Text = order.Style.cdept.Name;






                //hiddenFab.Value = DateTime.Now.ToShortDateString();
                hiddenAccount.Value = DateTime.Now.ToShortDateString();
                //hiddenProd.Value = DateTime.Now.ToShortDateString();

                DateTime dtPatternSampleDate = Convert.ToDateTime(order.PatternSampleDate.ToString());
                string Checkvalue = "";
                if (dtPatternSampleDate.ToString("dd-MM-yyyy") == "01-01-0001")
                {
                    // lblPCD1.Text = "";
                    Checkvalue = "";

                }

                else
                {
                    //string strPatternSampleDate = dtPatternSampleDate.ToString("dd MMM yy (ddd)");
                    //lblPatternSample.Text = order.PatternSampleDate.ToString("dd MMM yy (ddd)");
                    Checkvalue = order.PatternSampleDate.ToString("dd MMM (ddd)");

                }
                if (order.ProductionFileDate.ToString("dd-MM-yyyy") == "01-01-0001")
                {
                    lblProdctionFile.Text = "";
                }
                else
                {
                    lblProdctionFile.Text = order.ProductionFileDate.ToString("dd MMM (ddd)");
                }
                lblPCD1.Text = order.PCDDate.ToString("dd MMM (ddd)");

                if (Checkvalue == "" && lblProdctionFile.Text == "")
                {
                    lblProdctionFile.Text = "";
                }
                else if (lblProdctionFile.Text == "")
                {
                    lblProdctionFile.Text = Checkvalue;
                }
                else if (Checkvalue == "")
                {
                    lblProdctionFile.Text = lblProdctionFile.Text;
                }
                else
                {
                    lblProdctionFile.Text = Checkvalue + " " + "And" + " " + lblProdctionFile.Text;
                }
                lblOrderQty.Text = Convert.ToDouble(order.TotalQuantity).ToString();
                //if (order.StichedStartDate.ToString("dd-MM-yyyy") == "01-01-0001")
                //{
                //    lblOrderQty.Text = "";
                //}
                //else
                //{
                //    lblOrderQty.Text = Convert.ToDouble(order.TotalQuantity).ToString();
                //}
                if (order.StichedStartDate.ToString("dd-MM-yyyy") == "01-01-0001")
                {
                    lblStichedDate.Text = "";
                }
                else
                {
                    lblStichedDate.Text = order.StichedStartDate.ToString("dd MMM (ddd)");
                }



                //order.style = this.StyleControllerInstance.GetStyleByStyleId(order.style.StyleID);
                if (!string.IsNullOrEmpty(order.Style.SampleImageURL1))
                {
                    img1.Visible = true;
                    img1.ImageUrl = "~/Uploads/Style/thumb-" + order.Style.SampleImageURL1;
                }
                else
                    img1.Visible = false;
                if (!string.IsNullOrEmpty(order.Style.SampleImageURL2))
                {
                    img2.Visible = true;
                    img2.ImageUrl = "~/Uploads/Style/thumb-" + order.Style.SampleImageURL2;
                }
                else
                    img2.Visible = false;

                foreach (OrderDetail od in order.OrderBreakdown)
                {
                    ViewState["exFacroty"] = od.ExFactoryColor;
                    //Label lblFabDetails1 = e.Row.FindControl("lblFabDetails1") as Label;

                    //lblFabric1.Text = od.Fabric1 + "(" + od.Fabric1Details + ")";
                }

                PopulateCuttingData();

            }


            //DataSet ds = new DataSet();
            ds = this.OrderControllerInstance.GetCuttingDetails(OrderID, System.Web.HttpContext.Current.Session.SessionID);

            //List<OrderDetail> order=new List<OrderDetail> ();
            //order =this.OrderControllerInstance.GetOrderDetailByOrderId(OrderID);

            int count = ds.Tables[0].Rows.Count;



            if (ds.Tables[1].Rows.Count > 0)
            {
                grdCuttingOption1.DataSource = ds.Tables[1];
                grdCuttingOption1.DataBind();
                //AddGridview(ds.Tables[2], grdCuttingOption1);
                grdCuttingOption1.Visible = true;
                td1.Visible = true;

            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                grdCuttinOption2.DataSource = ds.Tables[2];
                grdCuttinOption2.DataBind();
                grdCuttinOption2.Visible = true;
                td2.Visible = true;
                //AddGridview(ds.Tables[4], grdCuttinOption2);
            }


            if (ds.Tables[3].Rows.Count > 0)
            {
                grdCuttingOption3.DataSource = ds.Tables[3];
                grdCuttingOption3.DataBind();
                grdCuttingOption3.Visible = true;
                td3.Visible = true;
                //AddGridview(ds.Tables[6], grdCuttingOption3);
            }

            if (ds.Tables[4].Rows.Count > 0)
            {
                grdCuttingOption4.DataSource = ds.Tables[4];
                grdCuttingOption4.DataBind();
                grdCuttingOption4.Visible = true;
                td4.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }


            if (ds.Tables[5].Rows.Count > 0)
            {
                grdCuttingOption5.DataSource = ds.Tables[5];
                grdCuttingOption5.DataBind();
                grdCuttingOption5.Visible = true;
                td5.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }



            if (ds.Tables[6].Rows.Count > 0)
            {
                grdCuttingOption6.DataSource = ds.Tables[6];
                grdCuttingOption6.DataBind();
                grdCuttingOption6.Visible = true;
                td6.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }


            if (ds.Tables[7].Rows.Count > 0)
            {
                grdCuttingOption7.DataSource = ds.Tables[7];
                grdCuttingOption7.DataBind();
                grdCuttingOption7.Visible = true;
                td7.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }


            if (ds.Tables[8].Rows.Count > 0)
            {
                grdCuttingOption8.DataSource = ds.Tables[8];
                grdCuttingOption8.DataBind();
                grdCuttingOption8.Visible = true;
                td8.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }


            if (ds.Tables[9].Rows.Count > 0)
            {
                grdCuttingOption9.DataSource = ds.Tables[9];
                grdCuttingOption9.DataBind();
                grdCuttingOption9.Visible = true;
                td9.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }


            if (ds.Tables[10].Rows.Count > 0)
            {
                grdCuttingOption10.DataSource = ds.Tables[10];
                grdCuttingOption10.DataBind();
                grdCuttingOption10.Visible = true;
                td10.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }


            if (ds.Tables[11].Rows.Count > 0)
            {
                grdCuttingOption11.DataSource = ds.Tables[11];
                grdCuttingOption11.DataBind();
                grdCuttingOption11.Visible = true;
                td11.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }


            if (ds.Tables[12].Rows.Count > 0)
            {
                grdCuttingOption12.DataSource = ds.Tables[12];
                grdCuttingOption12.DataBind();
                grdCuttingOption12.Visible = true;
                td12.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }


            if (ds.Tables[13].Rows.Count > 0)
            {
                grdCuttingOption13.DataSource = ds.Tables[13];
                grdCuttingOption13.DataBind();
                grdCuttingOption13.Visible = true;
                td13.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }


            if (ds.Tables[14].Rows.Count > 0)
            {
                grdCuttingOption14.DataSource = ds.Tables[14];
                grdCuttingOption14.DataBind();
                grdCuttingOption14.Visible = true;
                td14.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }


            if (ds.Tables[15].Rows.Count > 0)
            {
                grdCuttingOption15.DataSource = ds.Tables[15];
                grdCuttingOption15.DataBind();
                grdCuttingOption15.Visible = true;
                td15.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }
            if (ds.Tables[16].Rows.Count > 0)
            {
                grdCuttingOption16.DataSource = ds.Tables[16];
                grdCuttingOption16.DataBind();
                grdCuttingOption16.Visible = true;
                td16.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }
            if (ds.Tables[17].Rows.Count > 0)
            {
                grdCuttingOption17.DataSource = ds.Tables[17];
                grdCuttingOption17.DataBind();
                grdCuttingOption17.Visible = true;
                td17.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }
            if (ds.Tables[18].Rows.Count > 0)
            {
                grdCuttingOption18.DataSource = ds.Tables[18];
                grdCuttingOption18.DataBind();
                grdCuttingOption18.Visible = true;
                td18.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }
            if (ds.Tables[19].Rows.Count > 0)
            {
                grdCuttingOption19.DataSource = ds.Tables[19];
                grdCuttingOption19.DataBind();
                grdCuttingOption19.Visible = true;
                td19.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }

            if (ds.Tables[20].Rows.Count > 0)
            {
                grdCuttingOption20.DataSource = ds.Tables[20];
                grdCuttingOption20.DataBind();
                grdCuttingOption20.Visible = true;
                td20.Visible = true;
                //AddGridview(ds.Tables[8], grdCuttingOption4);
            }

        }


        public void AddGridview(DataTable dt, GridView gv)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string colName = dt.Rows[i]["Size"].ToString();
                    gv.HeaderRow.Cells[5 + i].Text = colName;

                }
            }
        }

        protected void grdCuttingOption1_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //   OrderDetail od = (e.Row.DataItem as OrderDetail);
                // MOOrderDetails od = (e.Row.DataItem as MOOrderDetails);


                string x = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[10].ToString();
                if (x == "True")
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc");
                }
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId1");
                HiddenField hndSize1 = (HiddenField)e.Row.FindControl("hndSize1");
                HiddenField hndSize2 = (HiddenField)e.Row.FindControl("hndSize2");
                HiddenField hndSize3 = (HiddenField)e.Row.FindControl("hndSize3");
                HiddenField hndSize4 = (HiddenField)e.Row.FindControl("hndSize4");
                HiddenField hndSize5 = (HiddenField)e.Row.FindControl("hndSize5");
                HiddenField hndSize6 = (HiddenField)e.Row.FindControl("hndSize6");
                HiddenField hndSize7 = (HiddenField)e.Row.FindControl("hndSize7");
                HiddenField hndSize8 = (HiddenField)e.Row.FindControl("hndSize8");
                HiddenField hndSize9 = (HiddenField)e.Row.FindControl("hndSize9");
                HiddenField hndSize10 = (HiddenField)e.Row.FindControl("hndSize10");
                HiddenField hndSize11 = (HiddenField)e.Row.FindControl("hndSize11");
                HiddenField hndSize12 = (HiddenField)e.Row.FindControl("hndSize12");
                HiddenField hdnIsshipped = (HiddenField)e.Row.FindControl("hdnIsshipped");

                string ss = hdnOdId1.Value.ToString();

                Label lblMinsize1 = (Label)e.Row.FindControl("lblMinsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblMinsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblMinsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblMinsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblMinsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblMinsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblMinsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblMinsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblMinsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblMinsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblMinsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblMinsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblMinsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblMinsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblMinsize15");

                Label lblMaxSize1 = (Label)e.Row.FindControl("lblMaxSize1");
                Label lblMaxSize2 = (Label)e.Row.FindControl("lblMaxSize2");
                Label lblMaxSize3 = (Label)e.Row.FindControl("lblMaxSize3");
                Label lblMaxSize4 = (Label)e.Row.FindControl("lblMaxSize4");
                Label lblMaxSize5 = (Label)e.Row.FindControl("lblMaxSize5");
                Label lblMaxSize6 = (Label)e.Row.FindControl("lblMaxSize6");
                Label lblMaxSize7 = (Label)e.Row.FindControl("lblMaxSize7");
                Label lblMaxSize8 = (Label)e.Row.FindControl("lblMaxSize8");
                Label lblMaxSize9 = (Label)e.Row.FindControl("lblMaxSize9");
                Label lblMaxSize10 = (Label)e.Row.FindControl("lblMaxSize10");
                Label lblMaxSize11 = (Label)e.Row.FindControl("lblMaxSize11");
                Label lblMaxSize12 = (Label)e.Row.FindControl("lblMaxSize12");

                Label lblMaxSize13 = (Label)e.Row.FindControl("lblMaxSize13");
                Label lblMaxSize14 = (Label)e.Row.FindControl("lblMaxSize14");
                Label lblMaxSize15 = (Label)e.Row.FindControl("lblMaxSize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblMinTotal1");
                Label lblMaxTotal1 = (Label)e.Row.FindControl("lblMaxTotal1");




                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);

                HtmlGenericControl divexFactory = (HtmlGenericControl)e.Row.FindControl("exFactory1");
                string excolor = ViewState["exFacroty"].ToString();

                // e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml(excolor);

                //if (ds.Tables[2].Rows.Count > 0)
                //{ 
                //    if (hndSize1 != null)
                //    {
                //        hndSize1.Value = (ds.Tables[2].Rows[0]["Size"] == DBNull.Value ? "" : ds.Tables[2].Rows[0]["Size"]).ToString();
                //    }
                //    if (hndSize2 != null)
                //    {
                //        hndSize2.Value = (ds.Tables[2].Rows[1]["Size"] == DBNull.Value ? "" : ds.Tables[2].Rows[1]["Size"]).ToString();
                //    }
                //    if (hndSize3 != null)
                //    {
                //        hndSize3.Value = (ds.Tables[2].Rows[2]["Size"] == DBNull.Value ? "" : ds.Tables[2].Rows[2]["Size"]).ToString();
                //    }
                //    if (hndSize4 != null)
                //    {
                //        hndSize4.Value = (ds.Tables[2].Rows[3]["Size"] == DBNull.Value ? "" : ds.Tables[2].Rows[3]["Size"]).ToString();
                //    }

                //    if (hndSize5 != null)
                //    {
                //        hndSize5.Value = (ds.Tables[2].Rows[4]["Size"] == DBNull.Value ? "" : ds.Tables[2].Rows[4]["Size"]).ToString();
                //    }
                //    if (hndSize6 != null)
                //    {
                //        hndSize6.Value = (ds.Tables[2].Rows[5]["Size"] == DBNull.Value ? "" : ds.Tables[2].Rows[5]["Size"]).ToString();
                //    }
                //    if (hndSize7 != null)
                //    {
                //        hndSize7.Value = (ds.Tables[2].Rows[6]["Size"] == DBNull.Value ? "" : ds.Tables[2].Rows[6]["Size"]).ToString();
                //    }
                //    if (hndSize8 != null)
                //    {
                //        hndSize8.Value = (ds.Tables[2].Rows[7]["Size"] == DBNull.Value ? "" : ds.Tables[2].Rows[7]["Size"]).ToString();
                //    }
                //    if (hndSize9 != null)
                //    {
                //        hndSize9.Value = (ds.Tables[2].Rows[8]["Size"] == DBNull.Value ? "" : ds.Tables[2].Rows[8]["Size"]).ToString();
                //    }
                //    if (hndSize10 != null)
                //    {
                //        hndSize10.Value = (ds.Tables[2].Rows[9]["Size"] == DBNull.Value ? "" : ds.Tables[2].Rows[9]["Size"]).ToString();
                //    }
                //    if (hndSize11 != null)
                //    {
                //        hndSize11.Value = (ds.Tables[2].Rows[10]["Size"] == DBNull.Value ? "" : ds.Tables[2].Rows[10]["Size"]).ToString();
                //    }
                //    if (hndSize12 != null)
                //    {
                //        hndSize12.Value = (ds.Tables[2].Rows[11]["Size"] == DBNull.Value ? "" : ds.Tables[2].Rows[11]["Size"]).ToString();
                //    }
                //}
                if (lblMinsize1 != null)
                {


                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 1);


                    if (strODId1 == "")
                    {
                        strODId1 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId1 = strODId1 + "," + OrderDetailId.ToString();
                    }
                    //strODId = strODId + ',' + strODId;
                    if (dtQty.Rows.Count > 0)
                    {

                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        lblMaxSize1.Text = Math.Round(Convert.ToDecimal(lblMinsize1.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize1.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption1.HeaderRow.Cells[3].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        lblMaxSize2.Text = Math.Round(Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize2.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption1.HeaderRow.Cells[4].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        lblMaxSize3.Text = Math.Round(Convert.ToDecimal(lblMinsize3.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize3.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption1.HeaderRow.Cells[5].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        lblMaxSize4.Text = Math.Round(Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize4.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption1.HeaderRow.Cells[6].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        lblMaxSize5.Text = Math.Round(Convert.ToDecimal(lblMinsize5.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize5.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption1.HeaderRow.Cells[7].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        lblMaxSize6.Text = Math.Round(Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize6.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption1.HeaderRow.Cells[8].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        lblMaxSize7.Text = Math.Round(Convert.ToDecimal(lblMinsize7.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize7.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption1.HeaderRow.Cells[9].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        lblMaxSize8.Text = Math.Round(Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize8.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption1.HeaderRow.Cells[10].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        lblMaxSize9.Text = Math.Round(Convert.ToDecimal(lblMinsize9.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize9.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption1.HeaderRow.Cells[11].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        lblMaxSize10.Text = Math.Round(Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize10.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption1.HeaderRow.Cells[12].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        lblMaxSize11.Text = Math.Round(Convert.ToDecimal(lblMinsize11.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize11.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption1.HeaderRow.Cells[13].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        lblMaxSize12.Text = Math.Round(Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize12.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption1.HeaderRow.Cells[14].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();


                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        lblMaxSize13.Text = Math.Round(Convert.ToDecimal(lblMinsize13.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize13.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption1.HeaderRow.Cells[15].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();

                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        lblMaxSize14.Text = Math.Round(Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize14.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption1.HeaderRow.Cells[16].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        lblMaxSize15.Text = Math.Round(Convert.ToDecimal(lblMinsize15.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize15.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption1.HeaderRow.Cells[17].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();
                        hdnIsshipped.Value = (dtQty.Rows[0]["Shipped"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Shipped"])).ToString();


                        if (hdnIsshipped.Value == "1")
                        {
                            e.Row.CssClass = "IsShipped borderbottom";
                        }
                        else
                        {
                            e.Row.CssClass = "borderbottom";
                        }

                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));

                        if (MinTotal != 0 || MinTotal != Convert.ToDecimal(0.0))
                            lblMinTotal1.Text = MinTotal.ToString();

                        decimal MaxTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMaxSize1.Text)
                                            + Convert.ToDecimal(lblMaxSize2.Text) + Convert.ToDecimal(lblMaxSize3.Text)
                                            + Convert.ToDecimal(lblMaxSize4.Text) + Convert.ToDecimal(lblMaxSize5.Text)
                                            + Convert.ToDecimal(lblMaxSize6.Text) + Convert.ToDecimal(lblMaxSize7.Text)
                                            + Convert.ToDecimal(lblMaxSize8.Text) + Convert.ToDecimal(lblMaxSize9.Text)
                                            + Convert.ToDecimal(lblMaxSize10.Text) + Convert.ToDecimal(lblMaxSize11.Text)
                                            + Convert.ToDecimal(lblMaxSize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));

                        if (MaxTotal != 0 || MaxTotal != Convert.ToDecimal(0.0))
                            lblMaxTotal1.Text = MaxTotal.ToString();

                        if (Convert.ToInt32(dtQty.Rows[0]["Quantity"]) == 0)
                        {
                            lblMinsize1.Text = "";
                            lblMaxSize1.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[1]["Quantity"]) == 0)
                        {
                            lblMinsize2.Text = "";
                            lblMaxSize2.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[2]["Quantity"]) == 0)
                        {
                            lblMinsize3.Text = "";
                            lblMaxSize3.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[3]["Quantity"]) == 0)
                        {
                            lblMinsize4.Text = "";
                            lblMaxSize4.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[4]["Quantity"]) == 0)
                        {
                            lblMinsize5.Text = "";
                            lblMaxSize5.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[5]["Quantity"]) == 0)
                        {
                            lblMinsize6.Text = "";
                            lblMaxSize6.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[6]["Quantity"]) == 0)
                        {
                            lblMinsize7.Text = "";
                            lblMaxSize7.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[7]["Quantity"]) == 0)
                        {
                            lblMinsize8.Text = "";
                            lblMaxSize8.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[8]["Quantity"]) == 0)
                        {
                            lblMinsize9.Text = "";
                            lblMaxSize9.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[9]["Quantity"]) == 0)
                        {
                            lblMinsize10.Text = "";
                            lblMaxSize10.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[10]["Quantity"]) == 0)
                        {
                            lblMinsize11.Text = "";
                            lblMaxSize11.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[11]["Quantity"]) == 0)
                        {
                            lblMinsize12.Text = "";
                            lblMaxSize12.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[12]["Quantity"]) == 0)
                        {
                            lblMinsize13.Text = "";
                            lblMaxSize13.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[13]["Quantity"]) == 0)
                        {
                            lblMinsize14.Text = "";
                            lblMaxSize14.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[14]["Quantity"]) == 0)
                        {
                            lblMinsize15.Text = "";
                            lblMaxSize15.Text = "";
                        }

                    }


                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");

                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");

                dtTotalSize = this.OrderControllerInstance.GetTotalSizeByContract(strODId1);

                //lblTotalSize1.Text = (dtTotalSize.Tables[0].Rows[0]["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize.Tables[0].Rows[0]["TotalQuantity"])).ToString();
                //lblTotalSize2.Text = (dtTotalSize.Tables[0].Rows[1]["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize.Tables[0].Rows[1]["TotalQuantity"])).ToString();
                //lblTotalSize3.Text = (dtTotalSize.Tables[0].Rows[2]["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize.Tables[0].Rows[2]["TotalQuantity"])).ToString();
                //lblTotalSize4.Text = (dtTotalSize.Tables[0].Rows[3]["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize.Tables[0].Rows[3]["TotalQuantity"])).ToString();
                //lblTotalSize5.Text = (dtTotalSize.Tables[0].Rows[4]["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize.Tables[0].Rows[4]["TotalQuantity"])).ToString();
                //lblTotalSize6.Text = (dtTotalSize.Tables[0].Rows[5]["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize.Tables[0].Rows[5]["TotalQuantity"])).ToString();
                //lblTotalSize7.Text = (dtTotalSize.Tables[0].Rows[6]["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize.Tables[0].Rows[6]["TotalQuantity"])).ToString();
                //lblTotalSize8.Text = (dtTotalSize.Tables[0].Rows[7]["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize.Tables[0].Rows[7]["TotalQuantity"])).ToString();
                //lblTotalSize9.Text = (dtTotalSize.Tables[0].Rows[8]["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize.Tables[0].Rows[8]["TotalQuantity"])).ToString();
                //lblTotalSize10.Text = (dtTotalSize.Tables[0].Rows[9]["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize.Tables[0].Rows[9]["TotalQuantity"])).ToString();
                //lblTotalSize11.Text = (dtTotalSize.Tables[0].Rows[10]["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize.Tables[0].Rows[10]["TotalQuantity"])).ToString();
                //lblTotalSize12.Text = (dtTotalSize.Tables[0].Rows[11]["TotalQuantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtTotalSize.Tables[0].Rows[11]["TotalQuantity"])).ToString();

                if (TotalQuantity1 != 0)
                    lblTotalSize1.Text = TotalQuantity1.ToString();
                if (TotalQuantity2 != 0)
                    lblTotalSize2.Text = TotalQuantity2.ToString();
                if (TotalQuantity3 != 0)
                    lblTotalSize3.Text = TotalQuantity3.ToString();
                if (TotalQuantity4 != 0)
                    lblTotalSize4.Text = TotalQuantity4.ToString();
                if (TotalQuantity5 != 0)
                    lblTotalSize5.Text = TotalQuantity5.ToString();
                if (TotalQuantity6 != 0)
                    lblTotalSize6.Text = TotalQuantity6.ToString();
                if (TotalQuantity7 != 0)
                    lblTotalSize7.Text = TotalQuantity7.ToString();
                if (TotalQuantity8 != 0)
                    lblTotalSize8.Text = TotalQuantity8.ToString();
                if (TotalQuantity9 != 0)
                    lblTotalSize9.Text = TotalQuantity9.ToString();
                if (TotalQuantity10 != 0)
                    lblTotalSize10.Text = TotalQuantity10.ToString();
                if (TotalQuantity11 != 0)
                    lblTotalSize11.Text = TotalQuantity11.ToString();
                if (TotalQuantity12 != 0)
                    lblTotalSize12.Text = TotalQuantity12.ToString();
                if (TotalQuantity13 != 0)
                    lblTotalSize13.Text = TotalQuantity13.ToString();
                if (TotalQuantity14 != 0)
                    lblTotalSize14.Text = TotalQuantity14.ToString();
                if (TotalQuantity15 != 0)
                    lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;

                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;

            }

        }

        protected void grdCuttinOption2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //return;

                string x = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[10].ToString();
                if (x == "True")
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc");
                }

                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId2");
                HiddenField hdnIsshipped = (HiddenField)e.Row.FindControl("hdnIsshipped2");

                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP2Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP2Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP2Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP2Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP2Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP2Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP2Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP2Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP2Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP2Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP2Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP2Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP2Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP2Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP2Minsize15");

                Label lblMaxSize1 = (Label)e.Row.FindControl("lblOP2MaxSize1");
                Label lblMaxSize2 = (Label)e.Row.FindControl("lblOP2MaxSize2");
                Label lblMaxSize3 = (Label)e.Row.FindControl("lblOP2MaxSize3");
                Label lblMaxSize4 = (Label)e.Row.FindControl("lblOP2MaxSize4");
                Label lblMaxSize5 = (Label)e.Row.FindControl("lblOP2MaxSize5");
                Label lblMaxSize6 = (Label)e.Row.FindControl("lblOP2MaxSize6");
                Label lblMaxSize7 = (Label)e.Row.FindControl("lblOP2MaxSize7");
                Label lblMaxSize8 = (Label)e.Row.FindControl("lblOP2MaxSize8");
                Label lblMaxSize9 = (Label)e.Row.FindControl("lblOP2MaxSize9");
                Label lblMaxSize10 = (Label)e.Row.FindControl("lblOP2MaxSize10");
                Label lblMaxSize11 = (Label)e.Row.FindControl("lblOP2MaxSize11");
                Label lblMaxSize12 = (Label)e.Row.FindControl("lblOP2MaxSize12");

                Label lblMaxSize13 = (Label)e.Row.FindControl("lblOP2MaxSize13");
                Label lblMaxSize14 = (Label)e.Row.FindControl("lblOP2MaxSize14");
                Label lblMaxSize15 = (Label)e.Row.FindControl("lblOP2MaxSize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP2MinTotal1");
                Label lblMaxTotal1 = (Label)e.Row.FindControl("lblOP2MaxTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);

                HtmlGenericControl divexFactory = (HtmlGenericControl)e.Row.FindControl("exFactory2");
                string excolor = ViewState["exFacroty"].ToString();
                //  e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml(excolor);
                //e.Row.CssClass = "IsShipped borderbottom"; 
                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 2);
                    if (strODId2 == "")
                    {
                        strODId2 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId2 = strODId2 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        lblMaxSize1.Text = Math.Round(Convert.ToDecimal(lblMinsize1.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize1.Text) * (4.4 / 100)))).ToString();
                        grdCuttinOption2.HeaderRow.Cells[3].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        lblMaxSize2.Text = Math.Round(Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize2.Text) * (4.4 / 100)))).ToString();
                        grdCuttinOption2.HeaderRow.Cells[4].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        lblMaxSize3.Text = Math.Round(Convert.ToDecimal(lblMinsize3.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize3.Text) * (4.4 / 100)))).ToString();
                        grdCuttinOption2.HeaderRow.Cells[5].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        lblMaxSize4.Text = Math.Round(Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize4.Text) * (4.4 / 100)))).ToString();
                        grdCuttinOption2.HeaderRow.Cells[6].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        lblMaxSize5.Text = Math.Round(Convert.ToDecimal(lblMinsize5.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize5.Text) * (4.4 / 100)))).ToString();
                        grdCuttinOption2.HeaderRow.Cells[7].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        lblMaxSize6.Text = Math.Round(Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize6.Text) * (4.4 / 100)))).ToString();
                        grdCuttinOption2.HeaderRow.Cells[8].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        lblMaxSize7.Text = Math.Round(Convert.ToDecimal(lblMinsize7.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize7.Text) * (4.4 / 100)))).ToString();
                        grdCuttinOption2.HeaderRow.Cells[9].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        lblMaxSize8.Text = Math.Round(Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize8.Text) * (4.4 / 100)))).ToString();
                        grdCuttinOption2.HeaderRow.Cells[10].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        lblMaxSize9.Text = Math.Round(Convert.ToDecimal(lblMinsize9.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize9.Text) * (4.4 / 100)))).ToString();
                        grdCuttinOption2.HeaderRow.Cells[11].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        lblMaxSize10.Text = Math.Round(Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize10.Text) * (4.4 / 100)))).ToString();
                        grdCuttinOption2.HeaderRow.Cells[12].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        lblMaxSize11.Text = Math.Round(Convert.ToDecimal(lblMinsize11.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize11.Text) * (4.4 / 100)))).ToString();
                        grdCuttinOption2.HeaderRow.Cells[13].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        lblMaxSize12.Text = Math.Round(Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize12.Text) * (4.4 / 100)))).ToString();
                        grdCuttinOption2.HeaderRow.Cells[14].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();


                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        lblMaxSize13.Text = Math.Round(Convert.ToDecimal(lblMinsize13.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize13.Text) * (4.4 / 100)))).ToString();
                        grdCuttinOption2.HeaderRow.Cells[15].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();

                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        lblMaxSize14.Text = Math.Round(Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize14.Text) * (4.4 / 100)))).ToString();
                        grdCuttinOption2.HeaderRow.Cells[16].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        lblMaxSize15.Text = Math.Round(Convert.ToDecimal(lblMinsize15.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize15.Text) * (4.4 / 100)))).ToString();
                        grdCuttinOption2.HeaderRow.Cells[17].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();

                        hdnIsshipped.Value = (dtQty.Rows[0]["Shipped"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Shipped"])).ToString();


                        if (hdnIsshipped.Value == "1")
                        {
                            e.Row.CssClass = "IsShipped borderbottom";
                        }
                        else
                        {
                            e.Row.CssClass = "borderbottom";
                        }

                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MinTotal != 0 || MinTotal != Convert.ToDecimal(0.0))
                            lblMinTotal1.Text = MinTotal.ToString();

                        decimal MaxTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMaxSize1.Text)
                                            + Convert.ToDecimal(lblMaxSize2.Text) + Convert.ToDecimal(lblMaxSize3.Text)
                                            + Convert.ToDecimal(lblMaxSize4.Text) + Convert.ToDecimal(lblMaxSize5.Text)
                                            + Convert.ToDecimal(lblMaxSize6.Text) + Convert.ToDecimal(lblMaxSize7.Text)
                                            + Convert.ToDecimal(lblMaxSize8.Text) + Convert.ToDecimal(lblMaxSize9.Text)
                                            + Convert.ToDecimal(lblMaxSize10.Text) + Convert.ToDecimal(lblMaxSize11.Text)
                                            + Convert.ToDecimal(lblMaxSize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MaxTotal != 0 || MaxTotal != Convert.ToDecimal(0.0))
                            lblMaxTotal1.Text = MaxTotal.ToString();

                        if (Convert.ToInt32(dtQty.Rows[0]["Quantity"]) == 0)
                        {
                            lblMinsize1.Text = "";
                            lblMaxSize1.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[1]["Quantity"]) == 0)
                        {
                            lblMinsize2.Text = "";
                            lblMaxSize2.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[2]["Quantity"]) == 0)
                        {
                            lblMinsize3.Text = "";
                            lblMaxSize3.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[3]["Quantity"]) == 0)
                        {
                            lblMinsize4.Text = "";
                            lblMaxSize4.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[4]["Quantity"]) == 0)
                        {
                            lblMinsize5.Text = "";
                            lblMaxSize5.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[5]["Quantity"]) == 0)
                        {
                            lblMinsize6.Text = "";
                            lblMaxSize6.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[6]["Quantity"]) == 0)
                        {
                            lblMinsize7.Text = "";
                            lblMaxSize7.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[7]["Quantity"]) == 0)
                        {
                            lblMinsize8.Text = "";
                            lblMaxSize8.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[8]["Quantity"]) == 0)
                        {
                            lblMinsize9.Text = "";
                            lblMaxSize9.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[9]["Quantity"]) == 0)
                        {
                            lblMinsize10.Text = "";
                            lblMaxSize10.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[10]["Quantity"]) == 0)
                        {
                            lblMinsize11.Text = "";
                            lblMaxSize11.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[11]["Quantity"]) == 0)
                        {
                            lblMinsize12.Text = "";
                            lblMaxSize12.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[12]["Quantity"]) == 0)
                        {
                            lblMinsize13.Text = "";
                            lblMaxSize13.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[13]["Quantity"]) == 0)
                        {
                            lblMinsize14.Text = "";
                            lblMaxSize14.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[14]["Quantity"]) == 0)
                        {
                            lblMinsize15.Text = "";
                            lblMaxSize15.Text = "";
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");

                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");
                dtTotalSize = this.OrderControllerInstance.GetTotalSizeByContract(strODId2);

                if (TotalQuantity1 != 0)
                    lblTotalSize1.Text = TotalQuantity1.ToString();
                if (TotalQuantity2 != 0)
                    lblTotalSize2.Text = TotalQuantity2.ToString();
                if (TotalQuantity3 != 0)
                    lblTotalSize3.Text = TotalQuantity3.ToString();
                if (TotalQuantity4 != 0)
                    lblTotalSize4.Text = TotalQuantity4.ToString();
                if (TotalQuantity5 != 0)
                    lblTotalSize5.Text = TotalQuantity5.ToString();
                if (TotalQuantity6 != 0)
                    lblTotalSize6.Text = TotalQuantity6.ToString();
                if (TotalQuantity7 != 0)
                    lblTotalSize7.Text = TotalQuantity7.ToString();
                if (TotalQuantity8 != 0)
                    lblTotalSize8.Text = TotalQuantity8.ToString();
                if (TotalQuantity9 != 0)
                    lblTotalSize9.Text = TotalQuantity9.ToString();
                if (TotalQuantity10 != 0)
                    lblTotalSize10.Text = TotalQuantity10.ToString();
                if (TotalQuantity11 != 0)
                    lblTotalSize11.Text = TotalQuantity11.ToString();
                if (TotalQuantity12 != 0)
                    lblTotalSize12.Text = TotalQuantity12.ToString();
                if (TotalQuantity13 != 0)
                    lblTotalSize13.Text = TotalQuantity13.ToString();
                if (TotalQuantity14 != 0)
                    lblTotalSize14.Text = TotalQuantity14.ToString();
                if (TotalQuantity15 != 0)
                    lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;

                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;

            }
        }

        protected void grdCuttingOption3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // return;

                string x = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[10].ToString();
                if (x == "True")
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc");
                }

                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId3");
                HiddenField hdnIsshipped = (HiddenField)e.Row.FindControl("hdnIsshipped3");

                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP3Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP3Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP3Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP3Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP3Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP3Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP3Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP3Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP3Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP3Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP3Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP3Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP3Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP3Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP3Minsize15");

                Label lblMaxSize1 = (Label)e.Row.FindControl("lblOP3MaxSize1");
                Label lblMaxSize2 = (Label)e.Row.FindControl("lblOP3MaxSize2");
                Label lblMaxSize3 = (Label)e.Row.FindControl("lblOP3MaxSize3");
                Label lblMaxSize4 = (Label)e.Row.FindControl("lblOP3MaxSize4");
                Label lblMaxSize5 = (Label)e.Row.FindControl("lblOP3MaxSize5");
                Label lblMaxSize6 = (Label)e.Row.FindControl("lblOP3MaxSize6");
                Label lblMaxSize7 = (Label)e.Row.FindControl("lblOP3MaxSize7");
                Label lblMaxSize8 = (Label)e.Row.FindControl("lblOP3MaxSize8");
                Label lblMaxSize9 = (Label)e.Row.FindControl("lblOP3MaxSize9");
                Label lblMaxSize10 = (Label)e.Row.FindControl("lblOP3MaxSize10");
                Label lblMaxSize11 = (Label)e.Row.FindControl("lblOP3MaxSize11");
                Label lblMaxSize12 = (Label)e.Row.FindControl("lblOP3MaxSize12");

                Label lblMaxSize13 = (Label)e.Row.FindControl("lblOP3MaxSize13");
                Label lblMaxSize14 = (Label)e.Row.FindControl("lblOP3MaxSize14");
                Label lblMaxSize15 = (Label)e.Row.FindControl("lblOP3MaxSize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP3MinTotal1");
                Label lblMaxTotal1 = (Label)e.Row.FindControl("lblOP3MaxTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);

                HtmlGenericControl divexFactory = (HtmlGenericControl)e.Row.FindControl("exFactory3");
                string excolor = ViewState["exFacroty"].ToString();
                //  e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml(excolor);

                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 3);
                    if (strODId3 == "")
                    {
                        strODId3 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId3 = strODId3 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        lblMaxSize1.Text = Math.Round(Convert.ToDecimal(lblMinsize1.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize1.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption3.HeaderRow.Cells[3].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        lblMaxSize2.Text = Math.Round(Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize2.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption3.HeaderRow.Cells[4].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        lblMaxSize3.Text = Math.Round(Convert.ToDecimal(lblMinsize3.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize3.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption3.HeaderRow.Cells[5].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        lblMaxSize4.Text = Math.Round(Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize4.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption3.HeaderRow.Cells[6].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        lblMaxSize5.Text = Math.Round(Convert.ToDecimal(lblMinsize5.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize5.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption3.HeaderRow.Cells[7].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        lblMaxSize6.Text = Math.Round(Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize6.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption3.HeaderRow.Cells[8].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        lblMaxSize7.Text = Math.Round(Convert.ToDecimal(lblMinsize7.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize7.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption3.HeaderRow.Cells[9].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        lblMaxSize8.Text = Math.Round(Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize8.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption3.HeaderRow.Cells[10].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        lblMaxSize9.Text = Math.Round(Convert.ToDecimal(lblMinsize9.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize9.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption3.HeaderRow.Cells[11].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        lblMaxSize10.Text = Math.Round(Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize10.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption3.HeaderRow.Cells[12].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        lblMaxSize11.Text = Math.Round(Convert.ToDecimal(lblMinsize11.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize11.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption3.HeaderRow.Cells[13].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        lblMaxSize12.Text = Math.Round(Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize12.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption3.HeaderRow.Cells[14].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        lblMaxSize13.Text = Math.Round(Convert.ToDecimal(lblMinsize13.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize13.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption3.HeaderRow.Cells[15].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();

                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        lblMaxSize14.Text = Math.Round(Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize14.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption3.HeaderRow.Cells[16].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        lblMaxSize15.Text = Math.Round(Convert.ToDecimal(lblMinsize15.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize15.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption3.HeaderRow.Cells[17].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();


                        hdnIsshipped.Value = (dtQty.Rows[0]["Shipped"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Shipped"])).ToString();


                        if (hdnIsshipped.Value == "1")
                        {
                            e.Row.CssClass = "IsShipped borderbottom";
                        }
                        else
                        {
                            e.Row.CssClass = "borderbottom";
                        }


                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MinTotal != 0 || MinTotal != Convert.ToDecimal(0.0))
                            lblMinTotal1.Text = MinTotal.ToString();

                        decimal MaxTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMaxSize1.Text)
                                            + Convert.ToDecimal(lblMaxSize2.Text) + Convert.ToDecimal(lblMaxSize3.Text)
                                            + Convert.ToDecimal(lblMaxSize4.Text) + Convert.ToDecimal(lblMaxSize5.Text)
                                            + Convert.ToDecimal(lblMaxSize6.Text) + Convert.ToDecimal(lblMaxSize7.Text)
                                            + Convert.ToDecimal(lblMaxSize8.Text) + Convert.ToDecimal(lblMaxSize9.Text)
                                            + Convert.ToDecimal(lblMaxSize10.Text) + Convert.ToDecimal(lblMaxSize11.Text)
                                            + Convert.ToDecimal(lblMaxSize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MaxTotal != 0 || MaxTotal != Convert.ToDecimal(0.0))
                            lblMaxTotal1.Text = MaxTotal.ToString();

                        if (Convert.ToInt32(dtQty.Rows[0]["Quantity"]) == 0)
                        {
                            lblMinsize1.Text = "";
                            lblMaxSize1.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[1]["Quantity"]) == 0)
                        {
                            lblMinsize2.Text = "";
                            lblMaxSize2.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[2]["Quantity"]) == 0)
                        {
                            lblMinsize3.Text = "";
                            lblMaxSize3.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[3]["Quantity"]) == 0)
                        {
                            lblMinsize4.Text = "";
                            lblMaxSize4.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[4]["Quantity"]) == 0)
                        {
                            lblMinsize5.Text = "";
                            lblMaxSize5.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[5]["Quantity"]) == 0)
                        {
                            lblMinsize6.Text = "";
                            lblMaxSize6.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[6]["Quantity"]) == 0)
                        {
                            lblMinsize7.Text = "";
                            lblMaxSize7.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[7]["Quantity"]) == 0)
                        {
                            lblMinsize8.Text = "";
                            lblMaxSize8.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[8]["Quantity"]) == 0)
                        {
                            lblMinsize9.Text = "";
                            lblMaxSize9.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[9]["Quantity"]) == 0)
                        {
                            lblMinsize10.Text = "";
                            lblMaxSize10.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[10]["Quantity"]) == 0)
                        {
                            lblMinsize11.Text = "";
                            lblMaxSize11.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[11]["Quantity"]) == 0)
                        {
                            lblMinsize12.Text = "";
                            lblMaxSize12.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[12]["Quantity"]) == 0)
                        {
                            lblMinsize13.Text = "";
                            lblMaxSize13.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[13]["Quantity"]) == 0)
                        {
                            lblMinsize14.Text = "";
                            lblMaxSize14.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[14]["Quantity"]) == 0)
                        {
                            lblMinsize15.Text = "";
                            lblMaxSize15.Text = "";
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");

                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");

                dtTotalSize = this.OrderControllerInstance.GetTotalSizeByContract(strODId3);

                if (TotalQuantity1 != 0)
                    lblTotalSize1.Text = TotalQuantity1.ToString();
                if (TotalQuantity2 != 0)
                    lblTotalSize2.Text = TotalQuantity2.ToString();
                if (TotalQuantity3 != 0)
                    lblTotalSize3.Text = TotalQuantity3.ToString();
                if (TotalQuantity4 != 0)
                    lblTotalSize4.Text = TotalQuantity4.ToString();
                if (TotalQuantity5 != 0)
                    lblTotalSize5.Text = TotalQuantity5.ToString();
                if (TotalQuantity6 != 0)
                    lblTotalSize6.Text = TotalQuantity6.ToString();
                if (TotalQuantity7 != 0)
                    lblTotalSize7.Text = TotalQuantity7.ToString();
                if (TotalQuantity8 != 0)
                    lblTotalSize8.Text = TotalQuantity8.ToString();
                if (TotalQuantity9 != 0)
                    lblTotalSize9.Text = TotalQuantity9.ToString();
                if (TotalQuantity10 != 0)
                    lblTotalSize10.Text = TotalQuantity10.ToString();
                if (TotalQuantity11 != 0)
                    lblTotalSize11.Text = TotalQuantity11.ToString();
                if (TotalQuantity12 != 0)
                    lblTotalSize12.Text = TotalQuantity12.ToString();
                if (TotalQuantity13 != 0)
                    lblTotalSize13.Text = TotalQuantity13.ToString();
                if (TotalQuantity14 != 0)
                    lblTotalSize14.Text = TotalQuantity14.ToString();
                if (TotalQuantity15 != 0)
                    lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
            }
        }

        protected void grdCuttingOption4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;
            {
                string x = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[10].ToString();
                if (x == "True")
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc");
                }
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId4");
                HiddenField hdnIsshipped = (HiddenField)e.Row.FindControl("hdnIsshipped4");

                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP4Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP4Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP4Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP4Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP4Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP4Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP4Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP4Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP4Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP4Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP4Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP4Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP4Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP4Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP4Minsize15");

                Label lblMaxSize1 = (Label)e.Row.FindControl("lblOP4MaxSize1");
                Label lblMaxSize2 = (Label)e.Row.FindControl("lblOP4MaxSize2");
                Label lblMaxSize3 = (Label)e.Row.FindControl("lblOP4MaxSize3");
                Label lblMaxSize4 = (Label)e.Row.FindControl("lblOP4MaxSize4");
                Label lblMaxSize5 = (Label)e.Row.FindControl("lblOP4MaxSize5");
                Label lblMaxSize6 = (Label)e.Row.FindControl("lblOP4MaxSize6");
                Label lblMaxSize7 = (Label)e.Row.FindControl("lblOP4MaxSize7");
                Label lblMaxSize8 = (Label)e.Row.FindControl("lblOP4MaxSize8");
                Label lblMaxSize9 = (Label)e.Row.FindControl("lblOP4MaxSize9");
                Label lblMaxSize10 = (Label)e.Row.FindControl("lblOP4MaxSize10");
                Label lblMaxSize11 = (Label)e.Row.FindControl("lblOP4MaxSize11");
                Label lblMaxSize12 = (Label)e.Row.FindControl("lblOP4MaxSize12");

                Label lblMaxSize13 = (Label)e.Row.FindControl("lblOP4MaxSize13");
                Label lblMaxSize14 = (Label)e.Row.FindControl("lblOP4MaxSize14");
                Label lblMaxSize15 = (Label)e.Row.FindControl("lblOP4MaxSize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP4MinTotal1");
                Label lblMaxTotal1 = (Label)e.Row.FindControl("lblOP4MaxTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);

                HtmlGenericControl divexFactory = (HtmlGenericControl)e.Row.FindControl("exFactory4");
                string excolor = ViewState["exFacroty"].ToString();
                // e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml(excolor);

                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 4);
                    if (strODId4 == "")
                    {
                        strODId4 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId4 = strODId4 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        lblMaxSize1.Text = Math.Round(Convert.ToDecimal(lblMinsize1.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize1.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption4.HeaderRow.Cells[3].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        lblMaxSize2.Text = Math.Round(Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize2.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption4.HeaderRow.Cells[4].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        lblMaxSize3.Text = Math.Round(Convert.ToDecimal(lblMinsize3.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize3.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption4.HeaderRow.Cells[5].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        lblMaxSize4.Text = Math.Round(Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize4.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption4.HeaderRow.Cells[6].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        lblMaxSize5.Text = Math.Round(Convert.ToDecimal(lblMinsize5.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize5.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption4.HeaderRow.Cells[7].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        lblMaxSize6.Text = Math.Round(Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize6.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption4.HeaderRow.Cells[8].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        lblMaxSize7.Text = Math.Round(Convert.ToDecimal(lblMinsize7.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize7.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption4.HeaderRow.Cells[9].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        lblMaxSize8.Text = Math.Round(Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize8.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption4.HeaderRow.Cells[10].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        lblMaxSize9.Text = Math.Round(Convert.ToDecimal(lblMinsize9.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize9.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption4.HeaderRow.Cells[11].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        lblMaxSize10.Text = Math.Round(Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize10.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption4.HeaderRow.Cells[12].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        lblMaxSize11.Text = Math.Round(Convert.ToDecimal(lblMinsize11.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize11.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption4.HeaderRow.Cells[13].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        lblMaxSize12.Text = Math.Round(Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize12.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption4.HeaderRow.Cells[14].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        lblMaxSize13.Text = Math.Round(Convert.ToDecimal(lblMinsize13.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize13.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption4.HeaderRow.Cells[15].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();

                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        lblMaxSize14.Text = Math.Round(Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize14.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption4.HeaderRow.Cells[16].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        lblMaxSize15.Text = Math.Round(Convert.ToDecimal(lblMinsize15.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize15.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption4.HeaderRow.Cells[17].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();


                        hdnIsshipped.Value = (dtQty.Rows[0]["Shipped"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Shipped"])).ToString();


                        if (hdnIsshipped.Value == "1")
                        {
                            e.Row.CssClass = "IsShipped borderbottom";
                        }
                        else
                        {
                            e.Row.CssClass = "borderbottom";
                        }


                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MinTotal != 0 || MinTotal != Convert.ToDecimal(0.0))
                            lblMinTotal1.Text = MinTotal.ToString();

                        decimal MaxTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMaxSize1.Text)
                                            + Convert.ToDecimal(lblMaxSize2.Text) + Convert.ToDecimal(lblMaxSize3.Text)
                                            + Convert.ToDecimal(lblMaxSize4.Text) + Convert.ToDecimal(lblMaxSize5.Text)
                                            + Convert.ToDecimal(lblMaxSize6.Text) + Convert.ToDecimal(lblMaxSize7.Text)
                                            + Convert.ToDecimal(lblMaxSize8.Text) + Convert.ToDecimal(lblMaxSize9.Text)
                                            + Convert.ToDecimal(lblMaxSize10.Text) + Convert.ToDecimal(lblMaxSize11.Text)
                                            + Convert.ToDecimal(lblMaxSize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MaxTotal != 0 || MaxTotal != Convert.ToDecimal(0.0))
                            lblMaxTotal1.Text = MaxTotal.ToString();

                        if (Convert.ToInt32(dtQty.Rows[0]["Quantity"]) == 0)
                        {
                            lblMinsize1.Text = "";
                            lblMaxSize1.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[1]["Quantity"]) == 0)
                        {
                            lblMinsize2.Text = "";
                            lblMaxSize2.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[2]["Quantity"]) == 0)
                        {
                            lblMinsize3.Text = "";
                            lblMaxSize3.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[3]["Quantity"]) == 0)
                        {
                            lblMinsize4.Text = "";
                            lblMaxSize4.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[4]["Quantity"]) == 0)
                        {
                            lblMinsize5.Text = "";
                            lblMaxSize5.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[5]["Quantity"]) == 0)
                        {
                            lblMinsize6.Text = "";
                            lblMaxSize6.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[6]["Quantity"]) == 0)
                        {
                            lblMinsize7.Text = "";
                            lblMaxSize7.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[7]["Quantity"]) == 0)
                        {
                            lblMinsize8.Text = "";
                            lblMaxSize8.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[8]["Quantity"]) == 0)
                        {
                            lblMinsize9.Text = "";
                            lblMaxSize9.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[9]["Quantity"]) == 0)
                        {
                            lblMinsize10.Text = "";
                            lblMaxSize10.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[10]["Quantity"]) == 0)
                        {
                            lblMinsize11.Text = "";
                            lblMaxSize11.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[11]["Quantity"]) == 0)
                        {
                            lblMinsize12.Text = "";
                            lblMaxSize12.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[12]["Quantity"]) == 0)
                        {
                            lblMinsize13.Text = "";
                            lblMaxSize13.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[13]["Quantity"]) == 0)
                        {
                            lblMinsize14.Text = "";
                            lblMaxSize14.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[14]["Quantity"]) == 0)
                        {
                            lblMinsize15.Text = "";
                            lblMaxSize15.Text = "";
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");

                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");

                dtTotalSize = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                if (TotalQuantity1 != 0)
                    lblTotalSize1.Text = TotalQuantity1.ToString();
                if (TotalQuantity2 != 0)
                    lblTotalSize2.Text = TotalQuantity2.ToString();
                if (TotalQuantity3 != 0)
                    lblTotalSize3.Text = TotalQuantity3.ToString();
                if (TotalQuantity4 != 0)
                    lblTotalSize4.Text = TotalQuantity4.ToString();
                if (TotalQuantity5 != 0)
                    lblTotalSize5.Text = TotalQuantity5.ToString();
                if (TotalQuantity6 != 0)
                    lblTotalSize6.Text = TotalQuantity6.ToString();
                if (TotalQuantity7 != 0)
                    lblTotalSize7.Text = TotalQuantity7.ToString();
                if (TotalQuantity8 != 0)
                    lblTotalSize8.Text = TotalQuantity8.ToString();
                if (TotalQuantity9 != 0)
                    lblTotalSize9.Text = TotalQuantity9.ToString();
                if (TotalQuantity10 != 0)
                    lblTotalSize10.Text = TotalQuantity10.ToString();
                if (TotalQuantity11 != 0)
                    lblTotalSize11.Text = TotalQuantity11.ToString();
                if (TotalQuantity12 != 0)
                    lblTotalSize12.Text = TotalQuantity12.ToString();
                if (TotalQuantity13 != 0)
                    lblTotalSize13.Text = TotalQuantity13.ToString();
                if (TotalQuantity14 != 0)
                    lblTotalSize14.Text = TotalQuantity14.ToString();
                if (TotalQuantity15 != 0)
                    lblTotalSize15.Text = TotalQuantity15.ToString();


                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
            }
        }



        protected void grdCuttingOption5_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;
            {
                string x = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[10].ToString();
                if (x == "True")
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc");
                }
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId5");
                HiddenField hdnIsshipped = (HiddenField)e.Row.FindControl("hdnIsshipped5");

                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP5Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP5Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP5Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP5Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP5Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP5Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP5Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP5Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP5Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP5Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP5Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP5Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP5Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP5Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP5Minsize15");

                Label lblMaxSize1 = (Label)e.Row.FindControl("lblOP5MaxSize1");
                Label lblMaxSize2 = (Label)e.Row.FindControl("lblOP5MaxSize2");
                Label lblMaxSize3 = (Label)e.Row.FindControl("lblOP5MaxSize3");
                Label lblMaxSize4 = (Label)e.Row.FindControl("lblOP5MaxSize4");
                Label lblMaxSize5 = (Label)e.Row.FindControl("lblOP5MaxSize5");
                Label lblMaxSize6 = (Label)e.Row.FindControl("lblOP5MaxSize6");
                Label lblMaxSize7 = (Label)e.Row.FindControl("lblOP5MaxSize7");
                Label lblMaxSize8 = (Label)e.Row.FindControl("lblOP5MaxSize8");
                Label lblMaxSize9 = (Label)e.Row.FindControl("lblOP5MaxSize9");
                Label lblMaxSize10 = (Label)e.Row.FindControl("lblOP5MaxSize10");
                Label lblMaxSize11 = (Label)e.Row.FindControl("lblOP5MaxSize11");
                Label lblMaxSize12 = (Label)e.Row.FindControl("lblOP5MaxSize12");

                Label lblMaxSize13 = (Label)e.Row.FindControl("lblOP5MaxSize13");
                Label lblMaxSize14 = (Label)e.Row.FindControl("lblOP5MaxSize14");
                Label lblMaxSize15 = (Label)e.Row.FindControl("lblOP5MaxSize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP5MinTotal1");
                Label lblMaxTotal1 = (Label)e.Row.FindControl("lblOP5MaxTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);
                //
                HtmlGenericControl divexFactory = (HtmlGenericControl)e.Row.FindControl("exFactory5");
                string excolor = ViewState["exFacroty"].ToString();
                // e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml(excolor);

                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 5);
                    if (strODId4 == "")
                    {
                        strODId4 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId4 = strODId4 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        lblMaxSize1.Text = Math.Round(Convert.ToDecimal(lblMinsize1.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize1.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption5.HeaderRow.Cells[3].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        lblMaxSize2.Text = Math.Round(Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize2.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption5.HeaderRow.Cells[4].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        lblMaxSize3.Text = Math.Round(Convert.ToDecimal(lblMinsize3.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize3.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption5.HeaderRow.Cells[5].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        lblMaxSize4.Text = Math.Round(Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize4.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption5.HeaderRow.Cells[6].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        lblMaxSize5.Text = Math.Round(Convert.ToDecimal(lblMinsize5.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize5.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption5.HeaderRow.Cells[7].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        lblMaxSize6.Text = Math.Round(Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize6.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption5.HeaderRow.Cells[8].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        lblMaxSize7.Text = Math.Round(Convert.ToDecimal(lblMinsize7.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize7.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption5.HeaderRow.Cells[9].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        lblMaxSize8.Text = Math.Round(Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize8.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption5.HeaderRow.Cells[10].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        lblMaxSize9.Text = Math.Round(Convert.ToDecimal(lblMinsize9.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize9.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption5.HeaderRow.Cells[11].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        lblMaxSize10.Text = Math.Round(Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize10.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption5.HeaderRow.Cells[12].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        lblMaxSize11.Text = Math.Round(Convert.ToDecimal(lblMinsize11.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize11.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption5.HeaderRow.Cells[13].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        lblMaxSize12.Text = Math.Round(Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize12.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption5.HeaderRow.Cells[14].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        lblMaxSize13.Text = Math.Round(Convert.ToDecimal(lblMinsize13.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize13.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption5.HeaderRow.Cells[15].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();

                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        lblMaxSize14.Text = Math.Round(Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize14.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption5.HeaderRow.Cells[16].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        lblMaxSize15.Text = Math.Round(Convert.ToDecimal(lblMinsize15.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize15.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption5.HeaderRow.Cells[17].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();

                        hdnIsshipped.Value = (dtQty.Rows[0]["Shipped"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Shipped"])).ToString();


                        if (hdnIsshipped.Value == "1")
                        {
                            e.Row.CssClass = "IsShipped borderbottom";
                        }
                        else
                        {
                            e.Row.CssClass = "borderbottom";
                        }

                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MinTotal != 0 || MinTotal != Convert.ToDecimal(0.0))
                            lblMinTotal1.Text = MinTotal.ToString();

                        decimal MaxTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMaxSize1.Text)
                                            + Convert.ToDecimal(lblMaxSize2.Text) + Convert.ToDecimal(lblMaxSize3.Text)
                                            + Convert.ToDecimal(lblMaxSize4.Text) + Convert.ToDecimal(lblMaxSize5.Text)
                                            + Convert.ToDecimal(lblMaxSize6.Text) + Convert.ToDecimal(lblMaxSize7.Text)
                                            + Convert.ToDecimal(lblMaxSize8.Text) + Convert.ToDecimal(lblMaxSize9.Text)
                                            + Convert.ToDecimal(lblMaxSize10.Text) + Convert.ToDecimal(lblMaxSize11.Text)
                                            + Convert.ToDecimal(lblMaxSize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MaxTotal != 0 || MaxTotal != Convert.ToDecimal(0.0))
                            lblMaxTotal1.Text = MaxTotal.ToString();

                        if (Convert.ToInt32(dtQty.Rows[0]["Quantity"]) == 0)
                        {
                            lblMinsize1.Text = "";
                            lblMaxSize1.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[1]["Quantity"]) == 0)
                        {
                            lblMinsize2.Text = "";
                            lblMaxSize2.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[2]["Quantity"]) == 0)
                        {
                            lblMinsize3.Text = "";
                            lblMaxSize3.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[3]["Quantity"]) == 0)
                        {
                            lblMinsize4.Text = "";
                            lblMaxSize4.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[4]["Quantity"]) == 0)
                        {
                            lblMinsize5.Text = "";
                            lblMaxSize5.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[5]["Quantity"]) == 0)
                        {
                            lblMinsize6.Text = "";
                            lblMaxSize6.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[6]["Quantity"]) == 0)
                        {
                            lblMinsize7.Text = "";
                            lblMaxSize7.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[7]["Quantity"]) == 0)
                        {
                            lblMinsize8.Text = "";
                            lblMaxSize8.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[8]["Quantity"]) == 0)
                        {
                            lblMinsize9.Text = "";
                            lblMaxSize9.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[9]["Quantity"]) == 0)
                        {
                            lblMinsize10.Text = "";
                            lblMaxSize10.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[10]["Quantity"]) == 0)
                        {
                            lblMinsize11.Text = "";
                            lblMaxSize11.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[11]["Quantity"]) == 0)
                        {
                            lblMinsize12.Text = "";
                            lblMaxSize12.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[12]["Quantity"]) == 0)
                        {
                            lblMinsize13.Text = "";
                            lblMaxSize13.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[13]["Quantity"]) == 0)
                        {
                            lblMinsize14.Text = "";
                            lblMaxSize14.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[14]["Quantity"]) == 0)
                        {
                            lblMinsize15.Text = "";
                            lblMaxSize15.Text = "";
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");

                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");
                dtTotalSize = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                if (TotalQuantity1 != 0)
                    lblTotalSize1.Text = TotalQuantity1.ToString();
                if (TotalQuantity2 != 0)
                    lblTotalSize2.Text = TotalQuantity2.ToString();
                if (TotalQuantity3 != 0)
                    lblTotalSize3.Text = TotalQuantity3.ToString();
                if (TotalQuantity4 != 0)
                    lblTotalSize4.Text = TotalQuantity4.ToString();
                if (TotalQuantity5 != 0)
                    lblTotalSize5.Text = TotalQuantity5.ToString();
                if (TotalQuantity6 != 0)
                    lblTotalSize6.Text = TotalQuantity6.ToString();
                if (TotalQuantity7 != 0)
                    lblTotalSize7.Text = TotalQuantity7.ToString();
                if (TotalQuantity8 != 0)
                    lblTotalSize8.Text = TotalQuantity8.ToString();
                if (TotalQuantity9 != 0)
                    lblTotalSize9.Text = TotalQuantity9.ToString();
                if (TotalQuantity10 != 0)
                    lblTotalSize10.Text = TotalQuantity10.ToString();
                if (TotalQuantity11 != 0)
                    lblTotalSize11.Text = TotalQuantity11.ToString();
                if (TotalQuantity12 != 0)
                    lblTotalSize12.Text = TotalQuantity12.ToString();
                if (TotalQuantity13 != 0)
                    lblTotalSize13.Text = TotalQuantity13.ToString();
                if (TotalQuantity14 != 0)
                    lblTotalSize14.Text = TotalQuantity14.ToString();
                if (TotalQuantity15 != 0)
                    lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
            }
        }


        protected void grdCuttingOption6_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;
            {
                string x = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[10].ToString();
                if (x == "True")
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc");
                }
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId6");
                HiddenField hdnIsshipped = (HiddenField)e.Row.FindControl("hdnIsshipped6");

                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP6Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP6Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP6Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP6Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP6Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP6Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP6Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP6Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP6Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP6Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP6Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP6Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP6Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP6Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP6Minsize15");

                Label lblMaxSize1 = (Label)e.Row.FindControl("lblOP6MaxSize1");
                Label lblMaxSize2 = (Label)e.Row.FindControl("lblOP6MaxSize2");
                Label lblMaxSize3 = (Label)e.Row.FindControl("lblOP6MaxSize3");
                Label lblMaxSize4 = (Label)e.Row.FindControl("lblOP6MaxSize4");
                Label lblMaxSize5 = (Label)e.Row.FindControl("lblOP6MaxSize5");
                Label lblMaxSize6 = (Label)e.Row.FindControl("lblOP6MaxSize6");
                Label lblMaxSize7 = (Label)e.Row.FindControl("lblOP6MaxSize7");
                Label lblMaxSize8 = (Label)e.Row.FindControl("lblOP6MaxSize8");
                Label lblMaxSize9 = (Label)e.Row.FindControl("lblOP6MaxSize9");
                Label lblMaxSize10 = (Label)e.Row.FindControl("lblOP6MaxSize10");
                Label lblMaxSize11 = (Label)e.Row.FindControl("lblOP6MaxSize11");
                Label lblMaxSize12 = (Label)e.Row.FindControl("lblOP6MaxSize12");

                Label lblMaxSize13 = (Label)e.Row.FindControl("lblOP6MaxSize13");
                Label lblMaxSize14 = (Label)e.Row.FindControl("lblOP6MaxSize14");
                Label lblMaxSize15 = (Label)e.Row.FindControl("lblOP6MaxSize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP6MinTotal1");
                Label lblMaxTotal1 = (Label)e.Row.FindControl("lblOP6MaxTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);

                HtmlGenericControl divexFactory = (HtmlGenericControl)e.Row.FindControl("exFactory6");
                string excolor = ViewState["exFacroty"].ToString();
                // e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml(excolor);

                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 6);
                    if (strODId4 == "")
                    {
                        strODId4 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId4 = strODId4 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        lblMaxSize1.Text = Math.Round(Convert.ToDecimal(lblMinsize1.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize1.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption6.HeaderRow.Cells[3].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        lblMaxSize2.Text = Math.Round(Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize2.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption6.HeaderRow.Cells[4].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        lblMaxSize3.Text = Math.Round(Convert.ToDecimal(lblMinsize3.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize3.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption6.HeaderRow.Cells[5].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        lblMaxSize4.Text = Math.Round(Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize4.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption6.HeaderRow.Cells[6].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        lblMaxSize5.Text = Math.Round(Convert.ToDecimal(lblMinsize5.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize5.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption6.HeaderRow.Cells[7].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        lblMaxSize6.Text = Math.Round(Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize6.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption6.HeaderRow.Cells[8].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        lblMaxSize7.Text = Math.Round(Convert.ToDecimal(lblMinsize7.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize7.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption6.HeaderRow.Cells[9].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        lblMaxSize8.Text = Math.Round(Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize8.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption6.HeaderRow.Cells[10].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        lblMaxSize9.Text = Math.Round(Convert.ToDecimal(lblMinsize9.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize9.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption6.HeaderRow.Cells[11].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        lblMaxSize10.Text = Math.Round(Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize10.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption6.HeaderRow.Cells[12].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        lblMaxSize11.Text = Math.Round(Convert.ToDecimal(lblMinsize11.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize11.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption6.HeaderRow.Cells[13].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        lblMaxSize12.Text = Math.Round(Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize12.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption6.HeaderRow.Cells[14].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        lblMaxSize13.Text = Math.Round(Convert.ToDecimal(lblMinsize13.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize13.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption6.HeaderRow.Cells[15].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();

                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        lblMaxSize14.Text = Math.Round(Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize14.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption6.HeaderRow.Cells[16].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        lblMaxSize15.Text = Math.Round(Convert.ToDecimal(lblMinsize15.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize15.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption6.HeaderRow.Cells[17].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();


                        hdnIsshipped.Value = (dtQty.Rows[0]["Shipped"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Shipped"])).ToString();


                        if (hdnIsshipped.Value == "1")
                        {
                            e.Row.CssClass = "IsShipped borderbottom";
                        }
                        else
                        {
                            e.Row.CssClass = "borderbottom";
                        }


                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MinTotal != 0 || MinTotal != Convert.ToDecimal(0.0))
                            lblMinTotal1.Text = MinTotal.ToString();

                        decimal MaxTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMaxSize1.Text)
                                            + Convert.ToDecimal(lblMaxSize2.Text) + Convert.ToDecimal(lblMaxSize3.Text)
                                            + Convert.ToDecimal(lblMaxSize4.Text) + Convert.ToDecimal(lblMaxSize5.Text)
                                            + Convert.ToDecimal(lblMaxSize6.Text) + Convert.ToDecimal(lblMaxSize7.Text)
                                            + Convert.ToDecimal(lblMaxSize8.Text) + Convert.ToDecimal(lblMaxSize9.Text)
                                            + Convert.ToDecimal(lblMaxSize10.Text) + Convert.ToDecimal(lblMaxSize11.Text)
                                            + Convert.ToDecimal(lblMaxSize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MaxTotal != 0 || MaxTotal != Convert.ToDecimal(0.0))
                            lblMaxTotal1.Text = MaxTotal.ToString();

                        if (Convert.ToInt32(dtQty.Rows[0]["Quantity"]) == 0)
                        {
                            lblMinsize1.Text = "";
                            lblMaxSize1.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[1]["Quantity"]) == 0)
                        {
                            lblMinsize2.Text = "";
                            lblMaxSize2.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[2]["Quantity"]) == 0)
                        {
                            lblMinsize3.Text = "";
                            lblMaxSize3.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[3]["Quantity"]) == 0)
                        {
                            lblMinsize4.Text = "";
                            lblMaxSize4.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[4]["Quantity"]) == 0)
                        {
                            lblMinsize5.Text = "";
                            lblMaxSize5.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[5]["Quantity"]) == 0)
                        {
                            lblMinsize6.Text = "";
                            lblMaxSize6.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[6]["Quantity"]) == 0)
                        {
                            lblMinsize7.Text = "";
                            lblMaxSize7.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[7]["Quantity"]) == 0)
                        {
                            lblMinsize8.Text = "";
                            lblMaxSize8.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[8]["Quantity"]) == 0)
                        {
                            lblMinsize9.Text = "";
                            lblMaxSize9.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[9]["Quantity"]) == 0)
                        {
                            lblMinsize10.Text = "";
                            lblMaxSize10.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[10]["Quantity"]) == 0)
                        {
                            lblMinsize11.Text = "";
                            lblMaxSize11.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[11]["Quantity"]) == 0)
                        {
                            lblMinsize12.Text = "";
                            lblMaxSize12.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[12]["Quantity"]) == 0)
                        {
                            lblMinsize13.Text = "";
                            lblMaxSize13.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[13]["Quantity"]) == 0)
                        {
                            lblMinsize14.Text = "";
                            lblMaxSize14.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[14]["Quantity"]) == 0)
                        {
                            lblMinsize15.Text = "";
                            lblMaxSize15.Text = "";
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");

                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");
                dtTotalSize = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                if (TotalQuantity1 != 0)
                    lblTotalSize1.Text = TotalQuantity1.ToString();
                if (TotalQuantity2 != 0)
                    lblTotalSize2.Text = TotalQuantity2.ToString();
                if (TotalQuantity3 != 0)
                    lblTotalSize3.Text = TotalQuantity3.ToString();
                if (TotalQuantity4 != 0)
                    lblTotalSize4.Text = TotalQuantity4.ToString();
                if (TotalQuantity5 != 0)
                    lblTotalSize5.Text = TotalQuantity5.ToString();
                if (TotalQuantity6 != 0)
                    lblTotalSize6.Text = TotalQuantity6.ToString();
                if (TotalQuantity7 != 0)
                    lblTotalSize7.Text = TotalQuantity7.ToString();
                if (TotalQuantity8 != 0)
                    lblTotalSize8.Text = TotalQuantity8.ToString();
                if (TotalQuantity9 != 0)
                    lblTotalSize9.Text = TotalQuantity9.ToString();
                if (TotalQuantity10 != 0)
                    lblTotalSize10.Text = TotalQuantity10.ToString();
                if (TotalQuantity11 != 0)
                    lblTotalSize11.Text = TotalQuantity11.ToString();
                if (TotalQuantity12 != 0)
                    lblTotalSize12.Text = TotalQuantity12.ToString();
                if (TotalQuantity13 != 0)
                    lblTotalSize13.Text = TotalQuantity13.ToString();
                if (TotalQuantity14 != 0)
                    lblTotalSize14.Text = TotalQuantity14.ToString();
                if (TotalQuantity15 != 0)
                    lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
            }
        }


        protected void grdCuttingOption7_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;
            {
                string x = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[10].ToString();
                if (x == "True")
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc");
                }
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId7");
                HiddenField hdnIsshipped = (HiddenField)e.Row.FindControl("hdnIsshipped7");

                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP7Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP7Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP7Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP7Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP7Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP7Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP7Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP7Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP7Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP7Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP7Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP7Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP7Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP7Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP7Minsize15");

                Label lblMaxSize1 = (Label)e.Row.FindControl("lblOP7MaxSize1");
                Label lblMaxSize2 = (Label)e.Row.FindControl("lblOP7MaxSize2");
                Label lblMaxSize3 = (Label)e.Row.FindControl("lblOP7MaxSize3");
                Label lblMaxSize4 = (Label)e.Row.FindControl("lblOP7MaxSize4");
                Label lblMaxSize5 = (Label)e.Row.FindControl("lblOP7MaxSize5");
                Label lblMaxSize6 = (Label)e.Row.FindControl("lblOP7MaxSize6");
                Label lblMaxSize7 = (Label)e.Row.FindControl("lblOP7MaxSize7");
                Label lblMaxSize8 = (Label)e.Row.FindControl("lblOP7MaxSize8");
                Label lblMaxSize9 = (Label)e.Row.FindControl("lblOP7MaxSize9");
                Label lblMaxSize10 = (Label)e.Row.FindControl("lblOP7MaxSize10");
                Label lblMaxSize11 = (Label)e.Row.FindControl("lblOP7MaxSize11");
                Label lblMaxSize12 = (Label)e.Row.FindControl("lblOP7MaxSize12");

                Label lblMaxSize13 = (Label)e.Row.FindControl("lblOP7MaxSize13");
                Label lblMaxSize14 = (Label)e.Row.FindControl("lblOP7MaxSize14");
                Label lblMaxSize15 = (Label)e.Row.FindControl("lblOP7MaxSize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP7MinTotal1");
                Label lblMaxTotal1 = (Label)e.Row.FindControl("lblOP7MaxTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);

                HtmlGenericControl divexFactory = (HtmlGenericControl)e.Row.FindControl("exFactory7");
                string excolor = ViewState["exFacroty"].ToString();
                // e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml(excolor);

                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 7);
                    if (strODId4 == "")
                    {
                        strODId4 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId4 = strODId4 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        lblMaxSize1.Text = Math.Round(Convert.ToDecimal(lblMinsize1.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize1.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption7.HeaderRow.Cells[3].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        lblMaxSize2.Text = Math.Round(Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize2.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption7.HeaderRow.Cells[4].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        lblMaxSize3.Text = Math.Round(Convert.ToDecimal(lblMinsize3.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize3.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption7.HeaderRow.Cells[5].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        lblMaxSize4.Text = Math.Round(Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize4.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption7.HeaderRow.Cells[6].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        lblMaxSize5.Text = Math.Round(Convert.ToDecimal(lblMinsize5.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize5.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption7.HeaderRow.Cells[7].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        lblMaxSize6.Text = Math.Round(Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize6.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption7.HeaderRow.Cells[8].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        lblMaxSize7.Text = Math.Round(Convert.ToDecimal(lblMinsize7.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize7.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption7.HeaderRow.Cells[9].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        lblMaxSize8.Text = Math.Round(Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize8.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption7.HeaderRow.Cells[10].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        lblMaxSize9.Text = Math.Round(Convert.ToDecimal(lblMinsize9.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize9.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption7.HeaderRow.Cells[11].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        lblMaxSize10.Text = Math.Round(Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize10.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption7.HeaderRow.Cells[12].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        lblMaxSize11.Text = Math.Round(Convert.ToDecimal(lblMinsize11.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize11.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption7.HeaderRow.Cells[13].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        lblMaxSize12.Text = Math.Round(Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize12.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption7.HeaderRow.Cells[14].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        lblMaxSize13.Text = Math.Round(Convert.ToDecimal(lblMinsize13.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize13.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption7.HeaderRow.Cells[15].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();

                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        lblMaxSize14.Text = Math.Round(Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize14.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption7.HeaderRow.Cells[16].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        lblMaxSize15.Text = Math.Round(Convert.ToDecimal(lblMinsize15.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize15.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption7.HeaderRow.Cells[17].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();



                        hdnIsshipped.Value = (dtQty.Rows[0]["Shipped"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Shipped"])).ToString();


                        if (hdnIsshipped.Value == "1")
                        {
                            e.Row.CssClass = "IsShipped borderbottom";
                        }
                        else
                        {
                            e.Row.CssClass = "borderbottom";
                        }


                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MinTotal != 0 || MinTotal != Convert.ToDecimal(0.0))
                            lblMinTotal1.Text = MinTotal.ToString();

                        decimal MaxTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMaxSize1.Text)
                                            + Convert.ToDecimal(lblMaxSize2.Text) + Convert.ToDecimal(lblMaxSize3.Text)
                                            + Convert.ToDecimal(lblMaxSize4.Text) + Convert.ToDecimal(lblMaxSize5.Text)
                                            + Convert.ToDecimal(lblMaxSize6.Text) + Convert.ToDecimal(lblMaxSize7.Text)
                                            + Convert.ToDecimal(lblMaxSize8.Text) + Convert.ToDecimal(lblMaxSize9.Text)
                                            + Convert.ToDecimal(lblMaxSize10.Text) + Convert.ToDecimal(lblMaxSize11.Text)
                                            + Convert.ToDecimal(lblMaxSize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MaxTotal != 0 || MaxTotal != Convert.ToDecimal(0.0))
                            lblMaxTotal1.Text = MaxTotal.ToString();

                        if (Convert.ToInt32(dtQty.Rows[0]["Quantity"]) == 0)
                        {
                            lblMinsize1.Text = "";
                            lblMaxSize1.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[1]["Quantity"]) == 0)
                        {
                            lblMinsize2.Text = "";
                            lblMaxSize2.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[2]["Quantity"]) == 0)
                        {
                            lblMinsize3.Text = "";
                            lblMaxSize3.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[3]["Quantity"]) == 0)
                        {
                            lblMinsize4.Text = "";
                            lblMaxSize4.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[4]["Quantity"]) == 0)
                        {
                            lblMinsize5.Text = "";
                            lblMaxSize5.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[5]["Quantity"]) == 0)
                        {
                            lblMinsize6.Text = "";
                            lblMaxSize6.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[6]["Quantity"]) == 0)
                        {
                            lblMinsize7.Text = "";
                            lblMaxSize7.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[7]["Quantity"]) == 0)
                        {
                            lblMinsize8.Text = "";
                            lblMaxSize8.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[8]["Quantity"]) == 0)
                        {
                            lblMinsize9.Text = "";
                            lblMaxSize9.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[9]["Quantity"]) == 0)
                        {
                            lblMinsize10.Text = "";
                            lblMaxSize10.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[10]["Quantity"]) == 0)
                        {
                            lblMinsize11.Text = "";
                            lblMaxSize11.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[11]["Quantity"]) == 0)
                        {
                            lblMinsize12.Text = "";
                            lblMaxSize12.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[12]["Quantity"]) == 0)
                        {
                            lblMinsize13.Text = "";
                            lblMaxSize13.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[13]["Quantity"]) == 0)
                        {
                            lblMinsize14.Text = "";
                            lblMaxSize14.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[14]["Quantity"]) == 0)
                        {
                            lblMinsize15.Text = "";
                            lblMaxSize15.Text = "";
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");
                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");
                dtTotalSize = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                if (TotalQuantity1 != 0)
                    lblTotalSize1.Text = TotalQuantity1.ToString();
                if (TotalQuantity2 != 0)
                    lblTotalSize2.Text = TotalQuantity2.ToString();
                if (TotalQuantity3 != 0)
                    lblTotalSize3.Text = TotalQuantity3.ToString();
                if (TotalQuantity4 != 0)
                    lblTotalSize4.Text = TotalQuantity4.ToString();
                if (TotalQuantity5 != 0)
                    lblTotalSize5.Text = TotalQuantity5.ToString();
                if (TotalQuantity6 != 0)
                    lblTotalSize6.Text = TotalQuantity6.ToString();
                if (TotalQuantity7 != 0)
                    lblTotalSize7.Text = TotalQuantity7.ToString();
                if (TotalQuantity8 != 0)
                    lblTotalSize8.Text = TotalQuantity8.ToString();
                if (TotalQuantity9 != 0)
                    lblTotalSize9.Text = TotalQuantity9.ToString();
                if (TotalQuantity10 != 0)
                    lblTotalSize10.Text = TotalQuantity10.ToString();
                if (TotalQuantity11 != 0)
                    lblTotalSize11.Text = TotalQuantity11.ToString();
                if (TotalQuantity12 != 0)
                    lblTotalSize12.Text = TotalQuantity12.ToString();
                if (TotalQuantity13 != 0)
                    lblTotalSize13.Text = TotalQuantity13.ToString();
                if (TotalQuantity14 != 0)
                    lblTotalSize14.Text = TotalQuantity14.ToString();
                if (TotalQuantity15 != 0)
                    lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
            }
        }



        protected void grdCuttingOption8_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return; 
            {
                string x = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[10].ToString();
                if (x == "True")
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc");
                }
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId8");
                HiddenField hdnIsshipped = (HiddenField)e.Row.FindControl("hdnIsshipped8");

                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP8Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP8Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP8Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP8Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP8Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP8Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP8Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP8Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP8Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP8Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP8Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP8Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP8Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP8Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP8Minsize15");

                Label lblMaxSize1 = (Label)e.Row.FindControl("lblOP8MaxSize1");
                Label lblMaxSize2 = (Label)e.Row.FindControl("lblOP8MaxSize2");
                Label lblMaxSize3 = (Label)e.Row.FindControl("lblOP8MaxSize3");
                Label lblMaxSize4 = (Label)e.Row.FindControl("lblOP8MaxSize4");
                Label lblMaxSize5 = (Label)e.Row.FindControl("lblOP8MaxSize5");
                Label lblMaxSize6 = (Label)e.Row.FindControl("lblOP8MaxSize6");
                Label lblMaxSize7 = (Label)e.Row.FindControl("lblOP8MaxSize7");
                Label lblMaxSize8 = (Label)e.Row.FindControl("lblOP8MaxSize8");
                Label lblMaxSize9 = (Label)e.Row.FindControl("lblOP8MaxSize9");
                Label lblMaxSize10 = (Label)e.Row.FindControl("lblOP8MaxSize10");
                Label lblMaxSize11 = (Label)e.Row.FindControl("lblOP8MaxSize11");
                Label lblMaxSize12 = (Label)e.Row.FindControl("lblOP8MaxSize12");

                Label lblMaxSize13 = (Label)e.Row.FindControl("lblOP8MaxSize13");
                Label lblMaxSize14 = (Label)e.Row.FindControl("lblOP8MaxSize14");
                Label lblMaxSize15 = (Label)e.Row.FindControl("lblOP8MaxSize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP8MinTotal1");
                Label lblMaxTotal1 = (Label)e.Row.FindControl("lblOP8MaxTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);

                HtmlGenericControl divexFactory = (HtmlGenericControl)e.Row.FindControl("exFactory8");
                string excolor = ViewState["exFacroty"].ToString();
                //  e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml(excolor);

                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 8);
                    if (strODId4 == "")
                    {
                        strODId4 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId4 = strODId4 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        lblMaxSize1.Text = Math.Round(Convert.ToDecimal(lblMinsize1.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize1.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption8.HeaderRow.Cells[3].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        lblMaxSize2.Text = Math.Round(Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize2.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption8.HeaderRow.Cells[4].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        lblMaxSize3.Text = Math.Round(Convert.ToDecimal(lblMinsize3.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize3.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption8.HeaderRow.Cells[5].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        lblMaxSize4.Text = Math.Round(Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize4.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption8.HeaderRow.Cells[6].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        lblMaxSize5.Text = Math.Round(Convert.ToDecimal(lblMinsize5.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize5.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption8.HeaderRow.Cells[7].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        lblMaxSize6.Text = Math.Round(Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize6.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption8.HeaderRow.Cells[8].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        lblMaxSize7.Text = Math.Round(Convert.ToDecimal(lblMinsize7.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize7.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption8.HeaderRow.Cells[9].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        lblMaxSize8.Text = Math.Round(Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize8.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption8.HeaderRow.Cells[10].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        lblMaxSize9.Text = Math.Round(Convert.ToDecimal(lblMinsize9.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize9.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption8.HeaderRow.Cells[11].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        lblMaxSize10.Text = Math.Round(Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize10.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption8.HeaderRow.Cells[12].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        lblMaxSize11.Text = Math.Round(Convert.ToDecimal(lblMinsize11.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize11.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption8.HeaderRow.Cells[13].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        lblMaxSize12.Text = Math.Round(Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize12.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption8.HeaderRow.Cells[14].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        lblMaxSize13.Text = Math.Round(Convert.ToDecimal(lblMinsize13.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize13.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption8.HeaderRow.Cells[15].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();

                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        lblMaxSize14.Text = Math.Round(Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize14.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption8.HeaderRow.Cells[16].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        lblMaxSize15.Text = Math.Round(Convert.ToDecimal(lblMinsize15.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize15.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption8.HeaderRow.Cells[17].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();


                        hdnIsshipped.Value = (dtQty.Rows[0]["Shipped"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Shipped"])).ToString();


                        if (hdnIsshipped.Value == "1")
                        {
                            e.Row.CssClass = "IsShipped borderbottom";
                        }
                        else
                        {
                            e.Row.CssClass = "borderbottom";
                        }
                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MinTotal != 0 || MinTotal != Convert.ToDecimal(0.0))
                            lblMinTotal1.Text = MinTotal.ToString();

                        decimal MaxTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMaxSize1.Text)
                                            + Convert.ToDecimal(lblMaxSize2.Text) + Convert.ToDecimal(lblMaxSize3.Text)
                                            + Convert.ToDecimal(lblMaxSize4.Text) + Convert.ToDecimal(lblMaxSize5.Text)
                                            + Convert.ToDecimal(lblMaxSize6.Text) + Convert.ToDecimal(lblMaxSize7.Text)
                                            + Convert.ToDecimal(lblMaxSize8.Text) + Convert.ToDecimal(lblMaxSize9.Text)
                                            + Convert.ToDecimal(lblMaxSize10.Text) + Convert.ToDecimal(lblMaxSize11.Text)
                                            + Convert.ToDecimal(lblMaxSize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MaxTotal != 0 || MaxTotal != Convert.ToDecimal(0.0))
                            lblMaxTotal1.Text = MaxTotal.ToString();

                        if (Convert.ToInt32(dtQty.Rows[0]["Quantity"]) == 0)
                        {
                            lblMinsize1.Text = "";
                            lblMaxSize1.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[1]["Quantity"]) == 0)
                        {
                            lblMinsize2.Text = "";
                            lblMaxSize2.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[2]["Quantity"]) == 0)
                        {
                            lblMinsize3.Text = "";
                            lblMaxSize3.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[3]["Quantity"]) == 0)
                        {
                            lblMinsize4.Text = "";
                            lblMaxSize4.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[4]["Quantity"]) == 0)
                        {
                            lblMinsize5.Text = "";
                            lblMaxSize5.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[5]["Quantity"]) == 0)
                        {
                            lblMinsize6.Text = "";
                            lblMaxSize6.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[6]["Quantity"]) == 0)
                        {
                            lblMinsize7.Text = "";
                            lblMaxSize7.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[7]["Quantity"]) == 0)
                        {
                            lblMinsize8.Text = "";
                            lblMaxSize8.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[8]["Quantity"]) == 0)
                        {
                            lblMinsize9.Text = "";
                            lblMaxSize9.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[9]["Quantity"]) == 0)
                        {
                            lblMinsize10.Text = "";
                            lblMaxSize10.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[10]["Quantity"]) == 0)
                        {
                            lblMinsize11.Text = "";
                            lblMaxSize11.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[11]["Quantity"]) == 0)
                        {
                            lblMinsize12.Text = "";
                            lblMaxSize12.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[12]["Quantity"]) == 0)
                        {
                            lblMinsize13.Text = "";
                            lblMaxSize13.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[13]["Quantity"]) == 0)
                        {
                            lblMinsize14.Text = "";
                            lblMaxSize14.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[14]["Quantity"]) == 0)
                        {
                            lblMinsize15.Text = "";
                            lblMaxSize15.Text = "";
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");
                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");
                dtTotalSize = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                if (TotalQuantity1 != 0)
                    lblTotalSize1.Text = TotalQuantity1.ToString();
                if (TotalQuantity2 != 0)
                    lblTotalSize2.Text = TotalQuantity2.ToString();
                if (TotalQuantity3 != 0)
                    lblTotalSize3.Text = TotalQuantity3.ToString();
                if (TotalQuantity4 != 0)
                    lblTotalSize4.Text = TotalQuantity4.ToString();
                if (TotalQuantity5 != 0)
                    lblTotalSize5.Text = TotalQuantity5.ToString();
                if (TotalQuantity6 != 0)
                    lblTotalSize6.Text = TotalQuantity6.ToString();
                if (TotalQuantity7 != 0)
                    lblTotalSize7.Text = TotalQuantity7.ToString();
                if (TotalQuantity8 != 0)
                    lblTotalSize8.Text = TotalQuantity8.ToString();
                if (TotalQuantity9 != 0)
                    lblTotalSize9.Text = TotalQuantity9.ToString();
                if (TotalQuantity10 != 0)
                    lblTotalSize10.Text = TotalQuantity10.ToString();
                if (TotalQuantity11 != 0)
                    lblTotalSize11.Text = TotalQuantity11.ToString();
                if (TotalQuantity12 != 0)
                    lblTotalSize12.Text = TotalQuantity12.ToString();
                if (TotalQuantity13 != 0)
                    lblTotalSize13.Text = TotalQuantity13.ToString();
                if (TotalQuantity14 != 0)
                    lblTotalSize14.Text = TotalQuantity14.ToString();
                if (TotalQuantity15 != 0)
                    lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
            }
        }



        protected void grdCuttingOption9_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return; 
            {
                string x = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[10].ToString();
                if (x == "True")
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc");
                }
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId9");
                HiddenField hdnIsshipped = (HiddenField)e.Row.FindControl("hdnIsshipped9");

                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP9Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP9Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP9Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP9Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP9Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP9Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP9Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP9Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP9Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP9Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP9Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP9Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP9Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP9Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP9Minsize15");

                Label lblMaxSize1 = (Label)e.Row.FindControl("lblOP9MaxSize1");
                Label lblMaxSize2 = (Label)e.Row.FindControl("lblOP9MaxSize2");
                Label lblMaxSize3 = (Label)e.Row.FindControl("lblOP9MaxSize3");
                Label lblMaxSize4 = (Label)e.Row.FindControl("lblOP9MaxSize4");
                Label lblMaxSize5 = (Label)e.Row.FindControl("lblOP9MaxSize5");
                Label lblMaxSize6 = (Label)e.Row.FindControl("lblOP9MaxSize6");
                Label lblMaxSize7 = (Label)e.Row.FindControl("lblOP9MaxSize7");
                Label lblMaxSize8 = (Label)e.Row.FindControl("lblOP9MaxSize8");
                Label lblMaxSize9 = (Label)e.Row.FindControl("lblOP9MaxSize9");
                Label lblMaxSize10 = (Label)e.Row.FindControl("lblOP9MaxSize10");
                Label lblMaxSize11 = (Label)e.Row.FindControl("lblOP9MaxSize11");
                Label lblMaxSize12 = (Label)e.Row.FindControl("lblOP9MaxSize12");

                Label lblMaxSize13 = (Label)e.Row.FindControl("lblOP9MaxSize13");
                Label lblMaxSize14 = (Label)e.Row.FindControl("lblOP9MaxSize14");
                Label lblMaxSize15 = (Label)e.Row.FindControl("lblOP9MaxSize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP9MinTotal1");
                Label lblMaxTotal1 = (Label)e.Row.FindControl("lblOP9MaxTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);

                HtmlGenericControl divexFactory = (HtmlGenericControl)e.Row.FindControl("exFactory9");
                string excolor = ViewState["exFacroty"].ToString();
                // e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml(excolor);

                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 9);
                    if (strODId4 == "")
                    {
                        strODId4 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId4 = strODId4 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        lblMaxSize1.Text = Math.Round(Convert.ToDecimal(lblMinsize1.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize1.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption9.HeaderRow.Cells[3].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        lblMaxSize2.Text = Math.Round(Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize2.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption9.HeaderRow.Cells[4].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        lblMaxSize3.Text = Math.Round(Convert.ToDecimal(lblMinsize3.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize3.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption9.HeaderRow.Cells[5].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        lblMaxSize4.Text = Math.Round(Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize4.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption9.HeaderRow.Cells[6].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        lblMaxSize5.Text = Math.Round(Convert.ToDecimal(lblMinsize5.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize5.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption9.HeaderRow.Cells[7].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        lblMaxSize6.Text = Math.Round(Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize6.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption9.HeaderRow.Cells[8].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        lblMaxSize7.Text = Math.Round(Convert.ToDecimal(lblMinsize7.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize7.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption9.HeaderRow.Cells[9].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        lblMaxSize8.Text = Math.Round(Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize8.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption9.HeaderRow.Cells[10].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        lblMaxSize9.Text = Math.Round(Convert.ToDecimal(lblMinsize9.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize9.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption9.HeaderRow.Cells[11].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        lblMaxSize10.Text = Math.Round(Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize10.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption9.HeaderRow.Cells[12].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        lblMaxSize11.Text = Math.Round(Convert.ToDecimal(lblMinsize11.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize11.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption9.HeaderRow.Cells[13].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        lblMaxSize12.Text = Math.Round(Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize12.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption9.HeaderRow.Cells[14].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        lblMaxSize13.Text = Math.Round(Convert.ToDecimal(lblMinsize13.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize13.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption9.HeaderRow.Cells[15].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();

                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        lblMaxSize14.Text = Math.Round(Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize14.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption9.HeaderRow.Cells[16].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        lblMaxSize15.Text = Math.Round(Convert.ToDecimal(lblMinsize15.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize15.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption9.HeaderRow.Cells[17].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();


                        hdnIsshipped.Value = (dtQty.Rows[0]["Shipped"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Shipped"])).ToString();


                        if (hdnIsshipped.Value == "1")
                        {
                            e.Row.CssClass = "IsShipped borderbottom";
                        }
                        else
                        {
                            e.Row.CssClass = "borderbottom";
                        }
                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MinTotal != 0 || MinTotal != Convert.ToDecimal(0.0))
                            lblMinTotal1.Text = MinTotal.ToString();

                        decimal MaxTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMaxSize1.Text)
                                            + Convert.ToDecimal(lblMaxSize2.Text) + Convert.ToDecimal(lblMaxSize3.Text)
                                            + Convert.ToDecimal(lblMaxSize4.Text) + Convert.ToDecimal(lblMaxSize5.Text)
                                            + Convert.ToDecimal(lblMaxSize6.Text) + Convert.ToDecimal(lblMaxSize7.Text)
                                            + Convert.ToDecimal(lblMaxSize8.Text) + Convert.ToDecimal(lblMaxSize9.Text)
                                            + Convert.ToDecimal(lblMaxSize10.Text) + Convert.ToDecimal(lblMaxSize11.Text)
                                            + Convert.ToDecimal(lblMaxSize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MaxTotal != 0 || MaxTotal != Convert.ToDecimal(0.0))
                            lblMaxTotal1.Text = MaxTotal.ToString();

                        if (Convert.ToInt32(dtQty.Rows[0]["Quantity"]) == 0)
                        {
                            lblMinsize1.Text = "";
                            lblMaxSize1.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[1]["Quantity"]) == 0)
                        {
                            lblMinsize2.Text = "";
                            lblMaxSize2.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[2]["Quantity"]) == 0)
                        {
                            lblMinsize3.Text = "";
                            lblMaxSize3.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[3]["Quantity"]) == 0)
                        {
                            lblMinsize4.Text = "";
                            lblMaxSize4.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[4]["Quantity"]) == 0)
                        {
                            lblMinsize5.Text = "";
                            lblMaxSize5.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[5]["Quantity"]) == 0)
                        {
                            lblMinsize6.Text = "";
                            lblMaxSize6.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[6]["Quantity"]) == 0)
                        {
                            lblMinsize7.Text = "";
                            lblMaxSize7.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[7]["Quantity"]) == 0)
                        {
                            lblMinsize8.Text = "";
                            lblMaxSize8.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[8]["Quantity"]) == 0)
                        {
                            lblMinsize9.Text = "";
                            lblMaxSize9.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[9]["Quantity"]) == 0)
                        {
                            lblMinsize10.Text = "";
                            lblMaxSize10.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[10]["Quantity"]) == 0)
                        {
                            lblMinsize11.Text = "";
                            lblMaxSize11.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[11]["Quantity"]) == 0)
                        {
                            lblMinsize12.Text = "";
                            lblMaxSize12.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[12]["Quantity"]) == 0)
                        {
                            lblMinsize13.Text = "";
                            lblMaxSize13.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[13]["Quantity"]) == 0)
                        {
                            lblMinsize14.Text = "";
                            lblMaxSize14.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[14]["Quantity"]) == 0)
                        {
                            lblMinsize15.Text = "";
                            lblMaxSize15.Text = "";
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");
                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");

                dtTotalSize = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                if (TotalQuantity1 != 0)
                    lblTotalSize1.Text = TotalQuantity1.ToString();
                if (TotalQuantity2 != 0)
                    lblTotalSize2.Text = TotalQuantity2.ToString();
                if (TotalQuantity3 != 0)
                    lblTotalSize3.Text = TotalQuantity3.ToString();
                if (TotalQuantity4 != 0)
                    lblTotalSize4.Text = TotalQuantity4.ToString();
                if (TotalQuantity5 != 0)
                    lblTotalSize5.Text = TotalQuantity5.ToString();
                if (TotalQuantity6 != 0)
                    lblTotalSize6.Text = TotalQuantity6.ToString();
                if (TotalQuantity7 != 0)
                    lblTotalSize7.Text = TotalQuantity7.ToString();
                if (TotalQuantity8 != 0)
                    lblTotalSize8.Text = TotalQuantity8.ToString();
                if (TotalQuantity9 != 0)
                    lblTotalSize9.Text = TotalQuantity9.ToString();
                if (TotalQuantity10 != 0)
                    lblTotalSize10.Text = TotalQuantity10.ToString();
                if (TotalQuantity11 != 0)
                    lblTotalSize11.Text = TotalQuantity11.ToString();
                if (TotalQuantity12 != 0)
                    lblTotalSize12.Text = TotalQuantity12.ToString();
                if (TotalQuantity13 != 0)
                    lblTotalSize13.Text = TotalQuantity13.ToString();
                if (TotalQuantity14 != 0)
                    lblTotalSize14.Text = TotalQuantity14.ToString();
                if (TotalQuantity15 != 0)
                    lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
            }
        }


        protected void grdCuttingOption10_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return; 
            {
                string x = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[10].ToString();
                if (x == "True")
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc");
                }
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId10");
                HiddenField hdnIsshipped = (HiddenField)e.Row.FindControl("hdnIsshipped10");

                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP10Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP10Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP10Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP10Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP10Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP10Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP10Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP10Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP10Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP10Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP10Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP10Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP10Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP10Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP10Minsize15");

                Label lblMaxSize1 = (Label)e.Row.FindControl("lblOP10MaxSize1");
                Label lblMaxSize2 = (Label)e.Row.FindControl("lblOP10MaxSize2");
                Label lblMaxSize3 = (Label)e.Row.FindControl("lblOP10MaxSize3");
                Label lblMaxSize4 = (Label)e.Row.FindControl("lblOP10MaxSize4");
                Label lblMaxSize5 = (Label)e.Row.FindControl("lblOP10MaxSize5");
                Label lblMaxSize6 = (Label)e.Row.FindControl("lblOP10MaxSize6");
                Label lblMaxSize7 = (Label)e.Row.FindControl("lblOP10MaxSize7");
                Label lblMaxSize8 = (Label)e.Row.FindControl("lblOP10MaxSize8");
                Label lblMaxSize9 = (Label)e.Row.FindControl("lblOP10MaxSize9");
                Label lblMaxSize10 = (Label)e.Row.FindControl("lblOP10MaxSize10");
                Label lblMaxSize11 = (Label)e.Row.FindControl("lblOP10MaxSize11");
                Label lblMaxSize12 = (Label)e.Row.FindControl("lblOP10MaxSize12");

                Label lblMaxSize13 = (Label)e.Row.FindControl("lblOP10MaxSize13");
                Label lblMaxSize14 = (Label)e.Row.FindControl("lblOP10MaxSize14");
                Label lblMaxSize15 = (Label)e.Row.FindControl("lblOP10MaxSize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP10MinTotal1");
                Label lblMaxTotal1 = (Label)e.Row.FindControl("lblOP10MaxTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);

                HtmlGenericControl divexFactory = (HtmlGenericControl)e.Row.FindControl("exFactory10");
                string excolor = ViewState["exFacroty"].ToString();
                //e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml(excolor);

                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 10);
                    if (strODId4 == "")
                    {
                        strODId4 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId4 = strODId4 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        lblMaxSize1.Text = Math.Round(Convert.ToDecimal(lblMinsize1.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize1.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption10.HeaderRow.Cells[3].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        lblMaxSize2.Text = Math.Round(Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize2.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption10.HeaderRow.Cells[4].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        lblMaxSize3.Text = Math.Round(Convert.ToDecimal(lblMinsize3.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize3.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption10.HeaderRow.Cells[5].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        lblMaxSize4.Text = Math.Round(Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize4.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption10.HeaderRow.Cells[6].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        lblMaxSize5.Text = Math.Round(Convert.ToDecimal(lblMinsize5.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize5.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption10.HeaderRow.Cells[7].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        lblMaxSize6.Text = Math.Round(Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize6.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption10.HeaderRow.Cells[8].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        lblMaxSize7.Text = Math.Round(Convert.ToDecimal(lblMinsize7.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize7.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption10.HeaderRow.Cells[9].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        lblMaxSize8.Text = Math.Round(Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize8.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption10.HeaderRow.Cells[10].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        lblMaxSize9.Text = Math.Round(Convert.ToDecimal(lblMinsize9.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize9.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption10.HeaderRow.Cells[11].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        lblMaxSize10.Text = Math.Round(Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize10.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption10.HeaderRow.Cells[12].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        lblMaxSize11.Text = Math.Round(Convert.ToDecimal(lblMinsize11.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize11.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption10.HeaderRow.Cells[13].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        lblMaxSize12.Text = Math.Round(Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize12.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption10.HeaderRow.Cells[14].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        lblMaxSize13.Text = Math.Round(Convert.ToDecimal(lblMinsize13.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize13.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption10.HeaderRow.Cells[15].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();

                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        lblMaxSize14.Text = Math.Round(Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize14.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption10.HeaderRow.Cells[16].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        lblMaxSize15.Text = Math.Round(Convert.ToDecimal(lblMinsize15.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize15.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption10.HeaderRow.Cells[17].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();


                        hdnIsshipped.Value = (dtQty.Rows[0]["Shipped"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Shipped"])).ToString();


                        if (hdnIsshipped.Value == "1")
                        {
                            e.Row.CssClass = "IsShipped borderbottom";
                        }
                        else
                        {
                            e.Row.CssClass = "borderbottom";
                        }
                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MinTotal != 0 || MinTotal != Convert.ToDecimal(0.0))
                            lblMinTotal1.Text = MinTotal.ToString();

                        decimal MaxTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMaxSize1.Text)
                                            + Convert.ToDecimal(lblMaxSize2.Text) + Convert.ToDecimal(lblMaxSize3.Text)
                                            + Convert.ToDecimal(lblMaxSize4.Text) + Convert.ToDecimal(lblMaxSize5.Text)
                                            + Convert.ToDecimal(lblMaxSize6.Text) + Convert.ToDecimal(lblMaxSize7.Text)
                                            + Convert.ToDecimal(lblMaxSize8.Text) + Convert.ToDecimal(lblMaxSize9.Text)
                                            + Convert.ToDecimal(lblMaxSize10.Text) + Convert.ToDecimal(lblMaxSize11.Text)
                                            + Convert.ToDecimal(lblMaxSize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MaxTotal != 0 || MaxTotal != Convert.ToDecimal(0.0))
                            lblMaxTotal1.Text = MaxTotal.ToString();

                        if (Convert.ToInt32(dtQty.Rows[0]["Quantity"]) == 0)
                        {
                            lblMinsize1.Text = "";
                            lblMaxSize1.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[1]["Quantity"]) == 0)
                        {
                            lblMinsize2.Text = "";
                            lblMaxSize2.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[2]["Quantity"]) == 0)
                        {
                            lblMinsize3.Text = "";
                            lblMaxSize3.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[3]["Quantity"]) == 0)
                        {
                            lblMinsize4.Text = "";
                            lblMaxSize4.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[4]["Quantity"]) == 0)
                        {
                            lblMinsize5.Text = "";
                            lblMaxSize5.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[5]["Quantity"]) == 0)
                        {
                            lblMinsize6.Text = "";
                            lblMaxSize6.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[6]["Quantity"]) == 0)
                        {
                            lblMinsize7.Text = "";
                            lblMaxSize7.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[7]["Quantity"]) == 0)
                        {
                            lblMinsize8.Text = "";
                            lblMaxSize8.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[8]["Quantity"]) == 0)
                        {
                            lblMinsize9.Text = "";
                            lblMaxSize9.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[9]["Quantity"]) == 0)
                        {
                            lblMinsize10.Text = "";
                            lblMaxSize10.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[10]["Quantity"]) == 0)
                        {
                            lblMinsize11.Text = "";
                            lblMaxSize11.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[11]["Quantity"]) == 0)
                        {
                            lblMinsize12.Text = "";
                            lblMaxSize12.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[12]["Quantity"]) == 0)
                        {
                            lblMinsize13.Text = "";
                            lblMaxSize13.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[13]["Quantity"]) == 0)
                        {
                            lblMinsize14.Text = "";
                            lblMaxSize14.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[14]["Quantity"]) == 0)
                        {
                            lblMinsize15.Text = "";
                            lblMaxSize15.Text = "";
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");
                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");
                dtTotalSize = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                if (TotalQuantity1 != 0)
                    lblTotalSize1.Text = TotalQuantity1.ToString();
                if (TotalQuantity2 != 0)
                    lblTotalSize2.Text = TotalQuantity2.ToString();
                if (TotalQuantity3 != 0)
                    lblTotalSize3.Text = TotalQuantity3.ToString();
                if (TotalQuantity4 != 0)
                    lblTotalSize4.Text = TotalQuantity4.ToString();
                if (TotalQuantity5 != 0)
                    lblTotalSize5.Text = TotalQuantity5.ToString();
                if (TotalQuantity6 != 0)
                    lblTotalSize6.Text = TotalQuantity6.ToString();
                if (TotalQuantity7 != 0)
                    lblTotalSize7.Text = TotalQuantity7.ToString();
                if (TotalQuantity8 != 0)
                    lblTotalSize8.Text = TotalQuantity8.ToString();
                if (TotalQuantity9 != 0)
                    lblTotalSize9.Text = TotalQuantity9.ToString();
                if (TotalQuantity10 != 0)
                    lblTotalSize10.Text = TotalQuantity10.ToString();
                if (TotalQuantity11 != 0)
                    lblTotalSize11.Text = TotalQuantity11.ToString();
                if (TotalQuantity12 != 0)
                    lblTotalSize12.Text = TotalQuantity12.ToString();
                if (TotalQuantity13 != 0)
                    lblTotalSize13.Text = TotalQuantity13.ToString();
                if (TotalQuantity14 != 0)
                    lblTotalSize14.Text = TotalQuantity14.ToString();
                if (TotalQuantity15 != 0)
                    lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
            }
        }



        protected void grdCuttingOption11_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return; 
            {
                string x = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[10].ToString();
                if (x == "True")
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc");
                }
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId11");
                HiddenField hdnIsshipped = (HiddenField)e.Row.FindControl("hdnIsshipped11");

                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP11Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP11Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP11Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP11Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP11Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP11Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP11Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP11Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP11Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP11Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP11Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP11Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP11Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP11Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP11Minsize15");

                Label lblMaxSize1 = (Label)e.Row.FindControl("lblOP11MaxSize1");
                Label lblMaxSize2 = (Label)e.Row.FindControl("lblOP11MaxSize2");
                Label lblMaxSize3 = (Label)e.Row.FindControl("lblOP11MaxSize3");
                Label lblMaxSize4 = (Label)e.Row.FindControl("lblOP11MaxSize4");
                Label lblMaxSize5 = (Label)e.Row.FindControl("lblOP11MaxSize5");
                Label lblMaxSize6 = (Label)e.Row.FindControl("lblOP11MaxSize6");
                Label lblMaxSize7 = (Label)e.Row.FindControl("lblOP11MaxSize7");
                Label lblMaxSize8 = (Label)e.Row.FindControl("lblOP11MaxSize8");
                Label lblMaxSize9 = (Label)e.Row.FindControl("lblOP11MaxSize9");
                Label lblMaxSize10 = (Label)e.Row.FindControl("lblOP11MaxSize10");
                Label lblMaxSize11 = (Label)e.Row.FindControl("lblOP11MaxSize11");
                Label lblMaxSize12 = (Label)e.Row.FindControl("lblOP11MaxSize12");

                Label lblMaxSize13 = (Label)e.Row.FindControl("lblOP11MaxSize13");
                Label lblMaxSize14 = (Label)e.Row.FindControl("lblOP11MaxSize14");
                Label lblMaxSize15 = (Label)e.Row.FindControl("lblOP11MaxSize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP11MinTotal1");
                Label lblMaxTotal1 = (Label)e.Row.FindControl("lblOP11MaxTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);

                HtmlGenericControl divexFactory = (HtmlGenericControl)e.Row.FindControl("exFactory11");
                string excolor = ViewState["exFacroty"].ToString();
                //  e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml(excolor);

                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 11);
                    if (strODId4 == "")
                    {
                        strODId4 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId4 = strODId4 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        lblMaxSize1.Text = Math.Round(Convert.ToDecimal(lblMinsize1.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize1.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption11.HeaderRow.Cells[3].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        lblMaxSize2.Text = Math.Round(Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize2.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption11.HeaderRow.Cells[4].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        lblMaxSize3.Text = Math.Round(Convert.ToDecimal(lblMinsize3.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize3.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption11.HeaderRow.Cells[5].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        lblMaxSize4.Text = Math.Round(Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize4.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption11.HeaderRow.Cells[6].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        lblMaxSize5.Text = Math.Round(Convert.ToDecimal(lblMinsize5.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize5.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption11.HeaderRow.Cells[7].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        lblMaxSize6.Text = Math.Round(Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize6.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption11.HeaderRow.Cells[8].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        lblMaxSize7.Text = Math.Round(Convert.ToDecimal(lblMinsize7.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize7.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption11.HeaderRow.Cells[9].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        lblMaxSize8.Text = Math.Round(Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize8.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption11.HeaderRow.Cells[10].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        lblMaxSize9.Text = Math.Round(Convert.ToDecimal(lblMinsize9.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize9.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption11.HeaderRow.Cells[11].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        lblMaxSize10.Text = Math.Round(Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize10.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption11.HeaderRow.Cells[12].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        lblMaxSize11.Text = Math.Round(Convert.ToDecimal(lblMinsize11.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize11.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption11.HeaderRow.Cells[13].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        lblMaxSize12.Text = Math.Round(Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize12.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption11.HeaderRow.Cells[14].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        lblMaxSize13.Text = Math.Round(Convert.ToDecimal(lblMinsize13.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize13.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption11.HeaderRow.Cells[15].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();

                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        lblMaxSize14.Text = Math.Round(Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize14.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption11.HeaderRow.Cells[16].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        lblMaxSize15.Text = Math.Round(Convert.ToDecimal(lblMinsize15.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize15.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption11.HeaderRow.Cells[17].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();


                        hdnIsshipped.Value = (dtQty.Rows[0]["Shipped"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Shipped"])).ToString();


                        if (hdnIsshipped.Value == "1")
                        {
                            e.Row.CssClass = "IsShipped borderbottom";
                        }
                        else
                        {
                            e.Row.CssClass = "borderbottom";
                        }
                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MinTotal != 0 || MinTotal != Convert.ToDecimal(0.0))
                            lblMinTotal1.Text = MinTotal.ToString();

                        decimal MaxTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMaxSize1.Text)
                                            + Convert.ToDecimal(lblMaxSize2.Text) + Convert.ToDecimal(lblMaxSize3.Text)
                                            + Convert.ToDecimal(lblMaxSize4.Text) + Convert.ToDecimal(lblMaxSize5.Text)
                                            + Convert.ToDecimal(lblMaxSize6.Text) + Convert.ToDecimal(lblMaxSize7.Text)
                                            + Convert.ToDecimal(lblMaxSize8.Text) + Convert.ToDecimal(lblMaxSize9.Text)
                                            + Convert.ToDecimal(lblMaxSize10.Text) + Convert.ToDecimal(lblMaxSize11.Text)
                                            + Convert.ToDecimal(lblMaxSize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MaxTotal != 0 || MaxTotal != Convert.ToDecimal(0.0))
                            lblMaxTotal1.Text = MaxTotal.ToString();

                        if (Convert.ToInt32(dtQty.Rows[0]["Quantity"]) == 0)
                        {
                            lblMinsize1.Text = "";
                            lblMaxSize1.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[1]["Quantity"]) == 0)
                        {
                            lblMinsize2.Text = "";
                            lblMaxSize2.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[2]["Quantity"]) == 0)
                        {
                            lblMinsize3.Text = "";
                            lblMaxSize3.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[3]["Quantity"]) == 0)
                        {
                            lblMinsize4.Text = "";
                            lblMaxSize4.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[4]["Quantity"]) == 0)
                        {
                            lblMinsize5.Text = "";
                            lblMaxSize5.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[5]["Quantity"]) == 0)
                        {
                            lblMinsize6.Text = "";
                            lblMaxSize6.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[6]["Quantity"]) == 0)
                        {
                            lblMinsize7.Text = "";
                            lblMaxSize7.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[7]["Quantity"]) == 0)
                        {
                            lblMinsize8.Text = "";
                            lblMaxSize8.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[8]["Quantity"]) == 0)
                        {
                            lblMinsize9.Text = "";
                            lblMaxSize9.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[9]["Quantity"]) == 0)
                        {
                            lblMinsize10.Text = "";
                            lblMaxSize10.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[10]["Quantity"]) == 0)
                        {
                            lblMinsize11.Text = "";
                            lblMaxSize11.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[11]["Quantity"]) == 0)
                        {
                            lblMinsize12.Text = "";
                            lblMaxSize12.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[12]["Quantity"]) == 0)
                        {
                            lblMinsize13.Text = "";
                            lblMaxSize13.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[13]["Quantity"]) == 0)
                        {
                            lblMinsize14.Text = "";
                            lblMaxSize14.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[14]["Quantity"]) == 0)
                        {
                            lblMinsize15.Text = "";
                            lblMaxSize15.Text = "";
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");
                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");
                dtTotalSize = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                if (TotalQuantity1 != 0)
                    lblTotalSize1.Text = TotalQuantity1.ToString();
                if (TotalQuantity2 != 0)
                    lblTotalSize2.Text = TotalQuantity2.ToString();
                if (TotalQuantity3 != 0)
                    lblTotalSize3.Text = TotalQuantity3.ToString();
                if (TotalQuantity4 != 0)
                    lblTotalSize4.Text = TotalQuantity4.ToString();
                if (TotalQuantity5 != 0)
                    lblTotalSize5.Text = TotalQuantity5.ToString();
                if (TotalQuantity6 != 0)
                    lblTotalSize6.Text = TotalQuantity6.ToString();
                if (TotalQuantity7 != 0)
                    lblTotalSize7.Text = TotalQuantity7.ToString();
                if (TotalQuantity8 != 0)
                    lblTotalSize8.Text = TotalQuantity8.ToString();
                if (TotalQuantity9 != 0)
                    lblTotalSize9.Text = TotalQuantity9.ToString();
                if (TotalQuantity10 != 0)
                    lblTotalSize10.Text = TotalQuantity10.ToString();
                if (TotalQuantity11 != 0)
                    lblTotalSize11.Text = TotalQuantity11.ToString();
                if (TotalQuantity12 != 0)
                    lblTotalSize12.Text = TotalQuantity12.ToString();
                if (TotalQuantity13 != 0)
                    lblTotalSize13.Text = TotalQuantity13.ToString();
                if (TotalQuantity14 != 0)
                    lblTotalSize14.Text = TotalQuantity14.ToString();
                if (TotalQuantity15 != 0)
                    lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
            }
        }


        protected void grdCuttingOption12_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;  
            {
                string x = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[10].ToString();
                if (x == "True")
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc");
                }
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId12");
                HiddenField hdnIsshipped = (HiddenField)e.Row.FindControl("hdnIsshipped12");

                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP12Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP12Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP12Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP12Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP12Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP12Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP12Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP12Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP12Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP12Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP12Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP12Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP12Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP12Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP12Minsize15");

                Label lblMaxSize1 = (Label)e.Row.FindControl("lblOP12MaxSize1");
                Label lblMaxSize2 = (Label)e.Row.FindControl("lblOP12MaxSize2");
                Label lblMaxSize3 = (Label)e.Row.FindControl("lblOP12MaxSize3");
                Label lblMaxSize4 = (Label)e.Row.FindControl("lblOP12MaxSize4");
                Label lblMaxSize5 = (Label)e.Row.FindControl("lblOP12MaxSize5");
                Label lblMaxSize6 = (Label)e.Row.FindControl("lblOP12MaxSize6");
                Label lblMaxSize7 = (Label)e.Row.FindControl("lblOP12MaxSize7");
                Label lblMaxSize8 = (Label)e.Row.FindControl("lblOP12MaxSize8");
                Label lblMaxSize9 = (Label)e.Row.FindControl("lblOP12MaxSize9");
                Label lblMaxSize10 = (Label)e.Row.FindControl("lblOP12MaxSize10");
                Label lblMaxSize11 = (Label)e.Row.FindControl("lblOP12MaxSize11");
                Label lblMaxSize12 = (Label)e.Row.FindControl("lblOP12MaxSize12");

                Label lblMaxSize13 = (Label)e.Row.FindControl("lblOP12MaxSize13");
                Label lblMaxSize14 = (Label)e.Row.FindControl("lblOP12MaxSize14");
                Label lblMaxSize15 = (Label)e.Row.FindControl("lblOP12MaxSize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP12MinTotal1");
                Label lblMaxTotal1 = (Label)e.Row.FindControl("lblOP12MaxTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);

                HtmlGenericControl divexFactory = (HtmlGenericControl)e.Row.FindControl("exFactory12");
                string excolor = ViewState["exFacroty"].ToString();
                //   e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml(excolor);

                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 12);
                    if (strODId4 == "")
                    {
                        strODId4 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId4 = strODId4 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        lblMaxSize1.Text = Math.Round(Convert.ToDecimal(lblMinsize1.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize1.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption12.HeaderRow.Cells[3].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        lblMaxSize2.Text = Math.Round(Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize2.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption12.HeaderRow.Cells[4].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        lblMaxSize3.Text = Math.Round(Convert.ToDecimal(lblMinsize3.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize3.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption12.HeaderRow.Cells[5].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        lblMaxSize4.Text = Math.Round(Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize4.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption12.HeaderRow.Cells[6].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        lblMaxSize5.Text = Math.Round(Convert.ToDecimal(lblMinsize5.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize5.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption12.HeaderRow.Cells[7].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        lblMaxSize6.Text = Math.Round(Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize6.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption12.HeaderRow.Cells[8].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        lblMaxSize7.Text = Math.Round(Convert.ToDecimal(lblMinsize7.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize7.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption12.HeaderRow.Cells[9].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        lblMaxSize8.Text = Math.Round(Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize8.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption12.HeaderRow.Cells[10].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        lblMaxSize9.Text = Math.Round(Convert.ToDecimal(lblMinsize9.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize9.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption12.HeaderRow.Cells[11].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        lblMaxSize10.Text = Math.Round(Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize10.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption12.HeaderRow.Cells[12].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        lblMaxSize11.Text = Math.Round(Convert.ToDecimal(lblMinsize11.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize11.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption12.HeaderRow.Cells[13].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        lblMaxSize12.Text = Math.Round(Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize12.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption12.HeaderRow.Cells[14].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        lblMaxSize13.Text = Math.Round(Convert.ToDecimal(lblMinsize13.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize13.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption12.HeaderRow.Cells[15].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();

                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        lblMaxSize14.Text = Math.Round(Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize14.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption12.HeaderRow.Cells[16].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        lblMaxSize15.Text = Math.Round(Convert.ToDecimal(lblMinsize15.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize15.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption12.HeaderRow.Cells[17].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();

                        hdnIsshipped.Value = (dtQty.Rows[0]["Shipped"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Shipped"])).ToString();


                        if (hdnIsshipped.Value == "1")
                        {
                            e.Row.CssClass = "IsShipped borderbottom";
                        }
                        else
                        {
                            e.Row.CssClass = "borderbottom";
                        }
                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MinTotal != 0 || MinTotal != Convert.ToDecimal(0.0))
                            lblMinTotal1.Text = MinTotal.ToString();

                        decimal MaxTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMaxSize1.Text)
                                            + Convert.ToDecimal(lblMaxSize2.Text) + Convert.ToDecimal(lblMaxSize3.Text)
                                            + Convert.ToDecimal(lblMaxSize4.Text) + Convert.ToDecimal(lblMaxSize5.Text)
                                            + Convert.ToDecimal(lblMaxSize6.Text) + Convert.ToDecimal(lblMaxSize7.Text)
                                            + Convert.ToDecimal(lblMaxSize8.Text) + Convert.ToDecimal(lblMaxSize9.Text)
                                            + Convert.ToDecimal(lblMaxSize10.Text) + Convert.ToDecimal(lblMaxSize11.Text)
                                            + Convert.ToDecimal(lblMaxSize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MaxTotal != 0 || MaxTotal != Convert.ToDecimal(0.0))
                            lblMaxTotal1.Text = MaxTotal.ToString();

                        if (Convert.ToInt32(dtQty.Rows[0]["Quantity"]) == 0)
                        {
                            lblMinsize1.Text = "";
                            lblMaxSize1.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[1]["Quantity"]) == 0)
                        {
                            lblMinsize2.Text = "";
                            lblMaxSize2.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[2]["Quantity"]) == 0)
                        {
                            lblMinsize3.Text = "";
                            lblMaxSize3.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[3]["Quantity"]) == 0)
                        {
                            lblMinsize4.Text = "";
                            lblMaxSize4.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[4]["Quantity"]) == 0)
                        {
                            lblMinsize5.Text = "";
                            lblMaxSize5.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[5]["Quantity"]) == 0)
                        {
                            lblMinsize6.Text = "";
                            lblMaxSize6.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[6]["Quantity"]) == 0)
                        {
                            lblMinsize7.Text = "";
                            lblMaxSize7.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[7]["Quantity"]) == 0)
                        {
                            lblMinsize8.Text = "";
                            lblMaxSize8.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[8]["Quantity"]) == 0)
                        {
                            lblMinsize9.Text = "";
                            lblMaxSize9.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[9]["Quantity"]) == 0)
                        {
                            lblMinsize10.Text = "";
                            lblMaxSize10.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[10]["Quantity"]) == 0)
                        {
                            lblMinsize11.Text = "";
                            lblMaxSize11.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[11]["Quantity"]) == 0)
                        {
                            lblMinsize12.Text = "";
                            lblMaxSize12.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[12]["Quantity"]) == 0)
                        {
                            lblMinsize13.Text = "";
                            lblMaxSize13.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[13]["Quantity"]) == 0)
                        {
                            lblMinsize14.Text = "";
                            lblMaxSize14.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[14]["Quantity"]) == 0)
                        {
                            lblMinsize15.Text = "";
                            lblMaxSize15.Text = "";
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");
                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");
                dtTotalSize = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                if (TotalQuantity1 != 0)
                    lblTotalSize1.Text = TotalQuantity1.ToString();
                if (TotalQuantity2 != 0)
                    lblTotalSize2.Text = TotalQuantity2.ToString();
                if (TotalQuantity3 != 0)
                    lblTotalSize3.Text = TotalQuantity3.ToString();
                if (TotalQuantity4 != 0)
                    lblTotalSize4.Text = TotalQuantity4.ToString();
                if (TotalQuantity5 != 0)
                    lblTotalSize5.Text = TotalQuantity5.ToString();
                if (TotalQuantity6 != 0)
                    lblTotalSize6.Text = TotalQuantity6.ToString();
                if (TotalQuantity7 != 0)
                    lblTotalSize7.Text = TotalQuantity7.ToString();
                if (TotalQuantity8 != 0)
                    lblTotalSize8.Text = TotalQuantity8.ToString();
                if (TotalQuantity9 != 0)
                    lblTotalSize9.Text = TotalQuantity9.ToString();
                if (TotalQuantity10 != 0)
                    lblTotalSize10.Text = TotalQuantity10.ToString();
                if (TotalQuantity11 != 0)
                    lblTotalSize11.Text = TotalQuantity11.ToString();
                if (TotalQuantity12 != 0)
                    lblTotalSize12.Text = TotalQuantity12.ToString();
                if (TotalQuantity13 != 0)
                    lblTotalSize13.Text = TotalQuantity13.ToString();
                if (TotalQuantity14 != 0)
                    lblTotalSize14.Text = TotalQuantity14.ToString();
                if (TotalQuantity15 != 0)
                    lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
            }
        }


        protected void grdCuttingOption13_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;  
            {
                string x = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[10].ToString();
                if (x == "True")
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc");
                }
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId13");
                HiddenField hdnIsshipped = (HiddenField)e.Row.FindControl("hdnIsshipped13");

                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP13Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP13Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP13Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP13Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP13Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP13Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP13Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP13Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP13Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP13Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP13Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP13Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP13Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP13Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP13Minsize15");

                Label lblMaxSize1 = (Label)e.Row.FindControl("lblOP13MaxSize1");
                Label lblMaxSize2 = (Label)e.Row.FindControl("lblOP13MaxSize2");
                Label lblMaxSize3 = (Label)e.Row.FindControl("lblOP13MaxSize3");
                Label lblMaxSize4 = (Label)e.Row.FindControl("lblOP13MaxSize4");
                Label lblMaxSize5 = (Label)e.Row.FindControl("lblOP13MaxSize5");
                Label lblMaxSize6 = (Label)e.Row.FindControl("lblOP13MaxSize6");
                Label lblMaxSize7 = (Label)e.Row.FindControl("lblOP13MaxSize7");
                Label lblMaxSize8 = (Label)e.Row.FindControl("lblOP13MaxSize8");
                Label lblMaxSize9 = (Label)e.Row.FindControl("lblOP13MaxSize9");
                Label lblMaxSize10 = (Label)e.Row.FindControl("lblOP13MaxSize10");
                Label lblMaxSize11 = (Label)e.Row.FindControl("lblOP13MaxSize11");
                Label lblMaxSize12 = (Label)e.Row.FindControl("lblOP13MaxSize12");

                Label lblMaxSize13 = (Label)e.Row.FindControl("lblOP13MaxSize13");
                Label lblMaxSize14 = (Label)e.Row.FindControl("lblOP13MaxSize14");
                Label lblMaxSize15 = (Label)e.Row.FindControl("lblOP13MaxSize15");


                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP13MinTotal1");
                Label lblMaxTotal1 = (Label)e.Row.FindControl("lblOP13MaxTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);

                HtmlGenericControl divexFactory = (HtmlGenericControl)e.Row.FindControl("exFactory13");
                string excolor = ViewState["exFacroty"].ToString();
                // e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml(excolor);

                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 13);
                    if (strODId4 == "")
                    {
                        strODId4 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId4 = strODId4 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        lblMaxSize1.Text = Math.Round(Convert.ToDecimal(lblMinsize1.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize1.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption13.HeaderRow.Cells[3].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        lblMaxSize2.Text = Math.Round(Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize2.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption13.HeaderRow.Cells[4].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        lblMaxSize3.Text = Math.Round(Convert.ToDecimal(lblMinsize3.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize3.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption13.HeaderRow.Cells[5].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        lblMaxSize4.Text = Math.Round(Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize4.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption13.HeaderRow.Cells[6].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        lblMaxSize5.Text = Math.Round(Convert.ToDecimal(lblMinsize5.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize5.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption13.HeaderRow.Cells[7].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        lblMaxSize6.Text = Math.Round(Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize6.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption13.HeaderRow.Cells[8].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        lblMaxSize7.Text = Math.Round(Convert.ToDecimal(lblMinsize7.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize7.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption13.HeaderRow.Cells[9].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        lblMaxSize8.Text = Math.Round(Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize8.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption13.HeaderRow.Cells[10].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        lblMaxSize9.Text = Math.Round(Convert.ToDecimal(lblMinsize9.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize9.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption13.HeaderRow.Cells[11].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        lblMaxSize10.Text = Math.Round(Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize10.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption13.HeaderRow.Cells[12].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        lblMaxSize11.Text = Math.Round(Convert.ToDecimal(lblMinsize11.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize11.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption13.HeaderRow.Cells[13].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        lblMaxSize12.Text = Math.Round(Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize12.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption13.HeaderRow.Cells[14].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        lblMaxSize13.Text = Math.Round(Convert.ToDecimal(lblMinsize13.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize13.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption13.HeaderRow.Cells[15].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();

                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        lblMaxSize14.Text = Math.Round(Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize14.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption13.HeaderRow.Cells[16].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        lblMaxSize15.Text = Math.Round(Convert.ToDecimal(lblMinsize15.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize15.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption13.HeaderRow.Cells[17].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();


                        hdnIsshipped.Value = (dtQty.Rows[0]["Shipped"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Shipped"])).ToString();


                        if (hdnIsshipped.Value == "1")
                        {
                            e.Row.CssClass = "IsShipped borderbottom";
                        }
                        else
                        {
                            e.Row.CssClass = "borderbottom";
                        }
                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MinTotal != 0 || MinTotal != Convert.ToDecimal(0.0))
                            lblMinTotal1.Text = MinTotal.ToString();

                        decimal MaxTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMaxSize1.Text)
                                            + Convert.ToDecimal(lblMaxSize2.Text) + Convert.ToDecimal(lblMaxSize3.Text)
                                            + Convert.ToDecimal(lblMaxSize4.Text) + Convert.ToDecimal(lblMaxSize5.Text)
                                            + Convert.ToDecimal(lblMaxSize6.Text) + Convert.ToDecimal(lblMaxSize7.Text)
                                            + Convert.ToDecimal(lblMaxSize8.Text) + Convert.ToDecimal(lblMaxSize9.Text)
                                            + Convert.ToDecimal(lblMaxSize10.Text) + Convert.ToDecimal(lblMaxSize11.Text)
                                            + Convert.ToDecimal(lblMaxSize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MaxTotal != 0 || MaxTotal != Convert.ToDecimal(0.0))
                            lblMaxTotal1.Text = MaxTotal.ToString();

                        if (Convert.ToInt32(dtQty.Rows[0]["Quantity"]) == 0)
                        {
                            lblMinsize1.Text = "";
                            lblMaxSize1.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[1]["Quantity"]) == 0)
                        {
                            lblMinsize2.Text = "";
                            lblMaxSize2.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[2]["Quantity"]) == 0)
                        {
                            lblMinsize3.Text = "";
                            lblMaxSize3.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[3]["Quantity"]) == 0)
                        {
                            lblMinsize4.Text = "";
                            lblMaxSize4.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[4]["Quantity"]) == 0)
                        {
                            lblMinsize5.Text = "";
                            lblMaxSize5.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[5]["Quantity"]) == 0)
                        {
                            lblMinsize6.Text = "";
                            lblMaxSize6.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[6]["Quantity"]) == 0)
                        {
                            lblMinsize7.Text = "";
                            lblMaxSize7.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[7]["Quantity"]) == 0)
                        {
                            lblMinsize8.Text = "";
                            lblMaxSize8.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[8]["Quantity"]) == 0)
                        {
                            lblMinsize9.Text = "";
                            lblMaxSize9.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[9]["Quantity"]) == 0)
                        {
                            lblMinsize10.Text = "";
                            lblMaxSize10.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[10]["Quantity"]) == 0)
                        {
                            lblMinsize11.Text = "";
                            lblMaxSize11.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[11]["Quantity"]) == 0)
                        {
                            lblMinsize12.Text = "";
                            lblMaxSize12.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[12]["Quantity"]) == 0)
                        {
                            lblMinsize13.Text = "";
                            lblMaxSize13.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[13]["Quantity"]) == 0)
                        {
                            lblMinsize14.Text = "";
                            lblMaxSize14.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[14]["Quantity"]) == 0)
                        {
                            lblMinsize15.Text = "";
                            lblMaxSize15.Text = "";
                        }

                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");
                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");
                dtTotalSize = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                if (TotalQuantity1 != 0)
                    lblTotalSize1.Text = TotalQuantity1.ToString();
                if (TotalQuantity2 != 0)
                    lblTotalSize2.Text = TotalQuantity2.ToString();
                if (TotalQuantity3 != 0)
                    lblTotalSize3.Text = TotalQuantity3.ToString();
                if (TotalQuantity4 != 0)
                    lblTotalSize4.Text = TotalQuantity4.ToString();
                if (TotalQuantity5 != 0)
                    lblTotalSize5.Text = TotalQuantity5.ToString();
                if (TotalQuantity6 != 0)
                    lblTotalSize6.Text = TotalQuantity6.ToString();
                if (TotalQuantity7 != 0)
                    lblTotalSize7.Text = TotalQuantity7.ToString();
                if (TotalQuantity8 != 0)
                    lblTotalSize8.Text = TotalQuantity8.ToString();
                if (TotalQuantity9 != 0)
                    lblTotalSize9.Text = TotalQuantity9.ToString();
                if (TotalQuantity10 != 0)
                    lblTotalSize10.Text = TotalQuantity10.ToString();
                if (TotalQuantity11 != 0)
                    lblTotalSize11.Text = TotalQuantity11.ToString();
                if (TotalQuantity12 != 0)
                    lblTotalSize12.Text = TotalQuantity12.ToString();
                if (TotalQuantity13 != 0)
                    lblTotalSize13.Text = TotalQuantity13.ToString();
                if (TotalQuantity14 != 0)
                    lblTotalSize14.Text = TotalQuantity14.ToString();
                if (TotalQuantity15 != 0)
                    lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
            }
        }


        protected void grdCuttingOption14_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;  
            {
                string x = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[10].ToString();
                if (x == "True")
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc");
                }
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId14");
                HiddenField hdnIsshipped = (HiddenField)e.Row.FindControl("hdnIsshipped14");

                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP14Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP14Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP14Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP14Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP14Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP14Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP14Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP14Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP14Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP14Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP14Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP14Minsize12");

                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP14Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP14Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP14Minsize15");

                Label lblMaxSize1 = (Label)e.Row.FindControl("lblOP14MaxSize1");
                Label lblMaxSize2 = (Label)e.Row.FindControl("lblOP14MaxSize2");
                Label lblMaxSize3 = (Label)e.Row.FindControl("lblOP14MaxSize3");
                Label lblMaxSize4 = (Label)e.Row.FindControl("lblOP14MaxSize4");
                Label lblMaxSize5 = (Label)e.Row.FindControl("lblOP14MaxSize5");
                Label lblMaxSize6 = (Label)e.Row.FindControl("lblOP14MaxSize6");
                Label lblMaxSize7 = (Label)e.Row.FindControl("lblOP14MaxSize7");
                Label lblMaxSize8 = (Label)e.Row.FindControl("lblOP14MaxSize8");
                Label lblMaxSize9 = (Label)e.Row.FindControl("lblOP14MaxSize9");
                Label lblMaxSize10 = (Label)e.Row.FindControl("lblOP14MaxSize10");
                Label lblMaxSize11 = (Label)e.Row.FindControl("lblOP14MaxSize11");
                Label lblMaxSize12 = (Label)e.Row.FindControl("lblOP14MaxSize12");

                Label lblMaxSize13 = (Label)e.Row.FindControl("lblOP14MaxSize13");
                Label lblMaxSize14 = (Label)e.Row.FindControl("lblOP14MaxSize14");
                Label lblMaxSize15 = (Label)e.Row.FindControl("lblOP14MaxSize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP14MinTotal1");
                Label lblMaxTotal1 = (Label)e.Row.FindControl("lblOP14MaxTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);

                HtmlGenericControl divexFactory = (HtmlGenericControl)e.Row.FindControl("exFactory14");
                string excolor = ViewState["exFacroty"].ToString();
                //  e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml(excolor);

                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 14);
                    if (strODId4 == "")
                    {
                        strODId4 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId4 = strODId4 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        lblMaxSize1.Text = Math.Round(Convert.ToDecimal(lblMinsize1.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize1.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption14.HeaderRow.Cells[3].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        lblMaxSize2.Text = Math.Round(Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize2.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption14.HeaderRow.Cells[4].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        lblMaxSize3.Text = Math.Round(Convert.ToDecimal(lblMinsize3.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize3.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption14.HeaderRow.Cells[5].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        lblMaxSize4.Text = Math.Round(Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize4.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption14.HeaderRow.Cells[6].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        lblMaxSize5.Text = Math.Round(Convert.ToDecimal(lblMinsize5.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize5.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption14.HeaderRow.Cells[7].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        lblMaxSize6.Text = Math.Round(Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize6.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption14.HeaderRow.Cells[8].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        lblMaxSize7.Text = Math.Round(Convert.ToDecimal(lblMinsize7.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize7.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption14.HeaderRow.Cells[9].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        lblMaxSize8.Text = Math.Round(Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize8.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption14.HeaderRow.Cells[10].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        lblMaxSize9.Text = Math.Round(Convert.ToDecimal(lblMinsize9.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize9.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption14.HeaderRow.Cells[11].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        lblMaxSize10.Text = Math.Round(Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize10.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption14.HeaderRow.Cells[12].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        lblMaxSize11.Text = Math.Round(Convert.ToDecimal(lblMinsize11.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize11.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption14.HeaderRow.Cells[13].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        lblMaxSize12.Text = Math.Round(Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize12.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption14.HeaderRow.Cells[14].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        lblMaxSize13.Text = Math.Round(Convert.ToDecimal(lblMinsize13.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize13.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption14.HeaderRow.Cells[15].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();

                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        lblMaxSize14.Text = Math.Round(Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize14.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption14.HeaderRow.Cells[16].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        lblMaxSize15.Text = Math.Round(Convert.ToDecimal(lblMinsize15.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize15.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption14.HeaderRow.Cells[17].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();


                        hdnIsshipped.Value = (dtQty.Rows[0]["Shipped"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Shipped"])).ToString();


                        if (hdnIsshipped.Value == "1")
                        {
                            e.Row.CssClass = "IsShipped borderbottom";
                        }
                        else
                        {
                            e.Row.CssClass = "borderbottom";
                        }
                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MinTotal != 0 || MinTotal != Convert.ToDecimal(0.0))
                            lblMinTotal1.Text = MinTotal.ToString();

                        decimal MaxTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMaxSize1.Text)
                                            + Convert.ToDecimal(lblMaxSize2.Text) + Convert.ToDecimal(lblMaxSize3.Text)
                                            + Convert.ToDecimal(lblMaxSize4.Text) + Convert.ToDecimal(lblMaxSize5.Text)
                                            + Convert.ToDecimal(lblMaxSize6.Text) + Convert.ToDecimal(lblMaxSize7.Text)
                                            + Convert.ToDecimal(lblMaxSize8.Text) + Convert.ToDecimal(lblMaxSize9.Text)
                                            + Convert.ToDecimal(lblMaxSize10.Text) + Convert.ToDecimal(lblMaxSize11.Text)
                                            + Convert.ToDecimal(lblMaxSize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MaxTotal != 0 || MaxTotal != Convert.ToDecimal(0.0))
                            lblMaxTotal1.Text = MaxTotal.ToString();

                        if (Convert.ToInt32(dtQty.Rows[0]["Quantity"]) == 0)
                        {
                            lblMinsize1.Text = "";
                            lblMaxSize1.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[1]["Quantity"]) == 0)
                        {
                            lblMinsize2.Text = "";
                            lblMaxSize2.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[2]["Quantity"]) == 0)
                        {
                            lblMinsize3.Text = "";
                            lblMaxSize3.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[3]["Quantity"]) == 0)
                        {
                            lblMinsize4.Text = "";
                            lblMaxSize4.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[4]["Quantity"]) == 0)
                        {
                            lblMinsize5.Text = "";
                            lblMaxSize5.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[5]["Quantity"]) == 0)
                        {
                            lblMinsize6.Text = "";
                            lblMaxSize6.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[6]["Quantity"]) == 0)
                        {
                            lblMinsize7.Text = "";
                            lblMaxSize7.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[7]["Quantity"]) == 0)
                        {
                            lblMinsize8.Text = "";
                            lblMaxSize8.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[8]["Quantity"]) == 0)
                        {
                            lblMinsize9.Text = "";
                            lblMaxSize9.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[9]["Quantity"]) == 0)
                        {
                            lblMinsize10.Text = "";
                            lblMaxSize10.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[10]["Quantity"]) == 0)
                        {
                            lblMinsize11.Text = "";
                            lblMaxSize11.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[11]["Quantity"]) == 0)
                        {
                            lblMinsize12.Text = "";
                            lblMaxSize12.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[12]["Quantity"]) == 0)
                        {
                            lblMinsize13.Text = "";
                            lblMaxSize13.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[13]["Quantity"]) == 0)
                        {
                            lblMinsize14.Text = "";
                            lblMaxSize14.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[14]["Quantity"]) == 0)
                        {
                            lblMinsize15.Text = "";
                            lblMaxSize15.Text = "";
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");
                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");
                dtTotalSize = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                if (TotalQuantity1 != 0)
                    lblTotalSize1.Text = TotalQuantity1.ToString();
                if (TotalQuantity2 != 0)
                    lblTotalSize2.Text = TotalQuantity2.ToString();
                if (TotalQuantity3 != 0)
                    lblTotalSize3.Text = TotalQuantity3.ToString();
                if (TotalQuantity4 != 0)
                    lblTotalSize4.Text = TotalQuantity4.ToString();
                if (TotalQuantity5 != 0)
                    lblTotalSize5.Text = TotalQuantity5.ToString();
                if (TotalQuantity6 != 0)
                    lblTotalSize6.Text = TotalQuantity6.ToString();
                if (TotalQuantity7 != 0)
                    lblTotalSize7.Text = TotalQuantity7.ToString();
                if (TotalQuantity8 != 0)
                    lblTotalSize8.Text = TotalQuantity8.ToString();
                if (TotalQuantity9 != 0)
                    lblTotalSize9.Text = TotalQuantity9.ToString();
                if (TotalQuantity10 != 0)
                    lblTotalSize10.Text = TotalQuantity10.ToString();
                if (TotalQuantity11 != 0)
                    lblTotalSize11.Text = TotalQuantity11.ToString();
                if (TotalQuantity12 != 0)
                    lblTotalSize12.Text = TotalQuantity12.ToString();
                if (TotalQuantity13 != 0)
                    lblTotalSize13.Text = TotalQuantity13.ToString();
                if (TotalQuantity14 != 0)
                    lblTotalSize14.Text = TotalQuantity14.ToString();
                if (TotalQuantity15 != 0)
                    lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
            }
        }



        protected void grdCuttingOption15_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;  
            {
                string x = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[10].ToString();
                if (x == "True")
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc");
                }
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId15");
                HiddenField hdnIsshipped = (HiddenField)e.Row.FindControl("hdnIsshipped15");

                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP15Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP15Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP15Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP15Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP15Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP15Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP15Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP15Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP15Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP15Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP15Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP15Minsize12");
                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP15Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP15Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP15Minsize15");

                Label lblMaxSize1 = (Label)e.Row.FindControl("lblOP15MaxSize1");
                Label lblMaxSize2 = (Label)e.Row.FindControl("lblOP15MaxSize2");
                Label lblMaxSize3 = (Label)e.Row.FindControl("lblOP15MaxSize3");
                Label lblMaxSize4 = (Label)e.Row.FindControl("lblOP15MaxSize4");
                Label lblMaxSize5 = (Label)e.Row.FindControl("lblOP15MaxSize5");
                Label lblMaxSize6 = (Label)e.Row.FindControl("lblOP15MaxSize6");
                Label lblMaxSize7 = (Label)e.Row.FindControl("lblOP15MaxSize7");
                Label lblMaxSize8 = (Label)e.Row.FindControl("lblOP15MaxSize8");
                Label lblMaxSize9 = (Label)e.Row.FindControl("lblOP15MaxSize9");
                Label lblMaxSize10 = (Label)e.Row.FindControl("lblOP15MaxSize10");
                Label lblMaxSize11 = (Label)e.Row.FindControl("lblOP15MaxSize11");
                Label lblMaxSize12 = (Label)e.Row.FindControl("lblOP15MaxSize12");

                Label lblMaxSize13 = (Label)e.Row.FindControl("lblOP15MaxSize13");
                Label lblMaxSize14 = (Label)e.Row.FindControl("lblOP15MaxSize14");
                Label lblMaxSize15 = (Label)e.Row.FindControl("lblOP15MaxSize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP15MinTotal1");
                Label lblMaxTotal1 = (Label)e.Row.FindControl("lblOP15MaxTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);

                HtmlGenericControl divexFactory = (HtmlGenericControl)e.Row.FindControl("exFactory15");
                string excolor = ViewState["exFacroty"].ToString();
                //e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml(excolor);


                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 15);
                    if (strODId4 == "")
                    {
                        strODId4 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId4 = strODId4 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        lblMaxSize1.Text = Math.Round(Convert.ToDecimal(lblMinsize1.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize1.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption15.HeaderRow.Cells[3].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        lblMaxSize2.Text = Math.Round(Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize2.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption15.HeaderRow.Cells[4].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        lblMaxSize3.Text = Math.Round(Convert.ToDecimal(lblMinsize3.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize3.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption15.HeaderRow.Cells[5].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        lblMaxSize4.Text = Math.Round(Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize4.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption15.HeaderRow.Cells[6].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        lblMaxSize5.Text = Math.Round(Convert.ToDecimal(lblMinsize5.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize5.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption15.HeaderRow.Cells[7].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        lblMaxSize6.Text = Math.Round(Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize6.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption15.HeaderRow.Cells[8].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        lblMaxSize7.Text = Math.Round(Convert.ToDecimal(lblMinsize7.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize7.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption15.HeaderRow.Cells[9].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        lblMaxSize8.Text = Math.Round(Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize8.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption15.HeaderRow.Cells[10].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        lblMaxSize9.Text = Math.Round(Convert.ToDecimal(lblMinsize9.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize9.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption15.HeaderRow.Cells[11].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        lblMaxSize10.Text = Math.Round(Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize10.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption15.HeaderRow.Cells[12].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        lblMaxSize11.Text = Math.Round(Convert.ToDecimal(lblMinsize11.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize11.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption15.HeaderRow.Cells[13].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        lblMaxSize12.Text = Math.Round(Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize12.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption15.HeaderRow.Cells[14].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        lblMaxSize13.Text = Math.Round(Convert.ToDecimal(lblMinsize13.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize13.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption15.HeaderRow.Cells[15].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();

                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        lblMaxSize14.Text = Math.Round(Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize14.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption15.HeaderRow.Cells[16].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        lblMaxSize15.Text = Math.Round(Convert.ToDecimal(lblMinsize15.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize15.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption15.HeaderRow.Cells[17].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();


                        hdnIsshipped.Value = (dtQty.Rows[0]["Shipped"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Shipped"])).ToString();


                        if (hdnIsshipped.Value == "1")
                        {
                            e.Row.CssClass = "IsShipped borderbottom";
                        }
                        else
                        {
                            e.Row.CssClass = "borderbottom";
                        }
                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MinTotal != 0 || MinTotal != Convert.ToDecimal(0.0))
                            lblMinTotal1.Text = MinTotal.ToString();

                        decimal MaxTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMaxSize1.Text)
                                            + Convert.ToDecimal(lblMaxSize2.Text) + Convert.ToDecimal(lblMaxSize3.Text)
                                            + Convert.ToDecimal(lblMaxSize4.Text) + Convert.ToDecimal(lblMaxSize5.Text)
                                            + Convert.ToDecimal(lblMaxSize6.Text) + Convert.ToDecimal(lblMaxSize7.Text)
                                            + Convert.ToDecimal(lblMaxSize8.Text) + Convert.ToDecimal(lblMaxSize9.Text)
                                            + Convert.ToDecimal(lblMaxSize10.Text) + Convert.ToDecimal(lblMaxSize11.Text)
                                            + Convert.ToDecimal(lblMaxSize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MaxTotal != 0 || MaxTotal != Convert.ToDecimal(0.0))
                            lblMaxTotal1.Text = MaxTotal.ToString();

                        if (Convert.ToInt32(dtQty.Rows[0]["Quantity"]) == 0)
                        {
                            lblMinsize1.Text = "";
                            lblMaxSize1.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[1]["Quantity"]) == 0)
                        {
                            lblMinsize2.Text = "";
                            lblMaxSize2.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[2]["Quantity"]) == 0)
                        {
                            lblMinsize3.Text = "";
                            lblMaxSize3.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[3]["Quantity"]) == 0)
                        {
                            lblMinsize4.Text = "";
                            lblMaxSize4.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[4]["Quantity"]) == 0)
                        {
                            lblMinsize5.Text = "";
                            lblMaxSize5.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[5]["Quantity"]) == 0)
                        {
                            lblMinsize6.Text = "";
                            lblMaxSize6.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[6]["Quantity"]) == 0)
                        {
                            lblMinsize7.Text = "";
                            lblMaxSize7.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[7]["Quantity"]) == 0)
                        {
                            lblMinsize8.Text = "";
                            lblMaxSize8.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[8]["Quantity"]) == 0)
                        {
                            lblMinsize9.Text = "";
                            lblMaxSize9.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[9]["Quantity"]) == 0)
                        {
                            lblMinsize10.Text = "";
                            lblMaxSize10.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[10]["Quantity"]) == 0)
                        {
                            lblMinsize11.Text = "";
                            lblMaxSize11.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[11]["Quantity"]) == 0)
                        {
                            lblMinsize12.Text = "";
                            lblMaxSize12.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[12]["Quantity"]) == 0)
                        {
                            lblMinsize13.Text = "";
                            lblMaxSize13.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[13]["Quantity"]) == 0)
                        {
                            lblMinsize14.Text = "";
                            lblMaxSize14.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[14]["Quantity"]) == 0)
                        {
                            lblMinsize15.Text = "";
                            lblMaxSize15.Text = "";
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");
                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");
                dtTotalSize = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                if (TotalQuantity1 != 0)
                    lblTotalSize1.Text = TotalQuantity1.ToString();
                if (TotalQuantity2 != 0)
                    lblTotalSize2.Text = TotalQuantity2.ToString();
                if (TotalQuantity3 != 0)
                    lblTotalSize3.Text = TotalQuantity3.ToString();
                if (TotalQuantity4 != 0)
                    lblTotalSize4.Text = TotalQuantity4.ToString();
                if (TotalQuantity5 != 0)
                    lblTotalSize5.Text = TotalQuantity5.ToString();
                if (TotalQuantity6 != 0)
                    lblTotalSize6.Text = TotalQuantity6.ToString();
                if (TotalQuantity7 != 0)
                    lblTotalSize7.Text = TotalQuantity7.ToString();
                if (TotalQuantity8 != 0)
                    lblTotalSize8.Text = TotalQuantity8.ToString();
                if (TotalQuantity9 != 0)
                    lblTotalSize9.Text = TotalQuantity9.ToString();
                if (TotalQuantity10 != 0)
                    lblTotalSize10.Text = TotalQuantity10.ToString();
                if (TotalQuantity11 != 0)
                    lblTotalSize11.Text = TotalQuantity11.ToString();
                if (TotalQuantity12 != 0)
                    lblTotalSize12.Text = TotalQuantity12.ToString();
                if (TotalQuantity13 != 0)
                    lblTotalSize13.Text = TotalQuantity13.ToString();
                if (TotalQuantity14 != 0)
                    lblTotalSize14.Text = TotalQuantity14.ToString();
                if (TotalQuantity15 != 0)
                    lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
            }
        }
        protected void grdCuttingOption16_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;  
            {
                string x = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[10].ToString();
                if (x == "True")
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc");
                }
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId16");
                HiddenField hdnIsshipped = (HiddenField)e.Row.FindControl("hdnIsshipped16");

                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP16Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP16Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP16Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP16Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP16Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP16Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP16Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP16Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP16Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP16Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP16Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP16Minsize12");
                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP16Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP16Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP16Minsize15");

                Label lblMaxSize1 = (Label)e.Row.FindControl("lblOP16MaxSize1");
                Label lblMaxSize2 = (Label)e.Row.FindControl("lblOP16MaxSize2");
                Label lblMaxSize3 = (Label)e.Row.FindControl("lblOP16MaxSize3");
                Label lblMaxSize4 = (Label)e.Row.FindControl("lblOP16MaxSize4");
                Label lblMaxSize5 = (Label)e.Row.FindControl("lblOP16MaxSize5");
                Label lblMaxSize6 = (Label)e.Row.FindControl("lblOP16MaxSize6");
                Label lblMaxSize7 = (Label)e.Row.FindControl("lblOP16MaxSize7");
                Label lblMaxSize8 = (Label)e.Row.FindControl("lblOP16MaxSize8");
                Label lblMaxSize9 = (Label)e.Row.FindControl("lblOP16MaxSize9");
                Label lblMaxSize10 = (Label)e.Row.FindControl("lblOP16MaxSize10");
                Label lblMaxSize11 = (Label)e.Row.FindControl("lblOP16MaxSize11");
                Label lblMaxSize12 = (Label)e.Row.FindControl("lblOP16MaxSize12");

                Label lblMaxSize13 = (Label)e.Row.FindControl("lblOP16MaxSize13");
                Label lblMaxSize14 = (Label)e.Row.FindControl("lblOP16MaxSize14");
                Label lblMaxSize15 = (Label)e.Row.FindControl("lblOP16MaxSize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP16MinTotal1");
                Label lblMaxTotal1 = (Label)e.Row.FindControl("lblOP16MaxTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);

                HtmlGenericControl divexFactory = (HtmlGenericControl)e.Row.FindControl("exFactory16");
                string excolor = ViewState["exFacroty"].ToString();
                //e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml(excolor);


                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 16);
                    if (strODId4 == "")
                    {
                        strODId4 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId4 = strODId4 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        lblMaxSize1.Text = Math.Round(Convert.ToDecimal(lblMinsize1.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize1.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption16.HeaderRow.Cells[3].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        lblMaxSize2.Text = Math.Round(Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize2.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption16.HeaderRow.Cells[4].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        lblMaxSize3.Text = Math.Round(Convert.ToDecimal(lblMinsize3.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize3.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption16.HeaderRow.Cells[5].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        lblMaxSize4.Text = Math.Round(Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize4.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption16.HeaderRow.Cells[6].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        lblMaxSize5.Text = Math.Round(Convert.ToDecimal(lblMinsize5.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize5.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption16.HeaderRow.Cells[7].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        lblMaxSize6.Text = Math.Round(Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize6.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption16.HeaderRow.Cells[8].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        lblMaxSize7.Text = Math.Round(Convert.ToDecimal(lblMinsize7.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize7.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption16.HeaderRow.Cells[9].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        lblMaxSize8.Text = Math.Round(Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize8.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption16.HeaderRow.Cells[10].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        lblMaxSize9.Text = Math.Round(Convert.ToDecimal(lblMinsize9.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize9.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption16.HeaderRow.Cells[11].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        lblMaxSize10.Text = Math.Round(Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize10.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption16.HeaderRow.Cells[12].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        lblMaxSize11.Text = Math.Round(Convert.ToDecimal(lblMinsize11.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize11.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption16.HeaderRow.Cells[13].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        lblMaxSize12.Text = Math.Round(Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize12.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption16.HeaderRow.Cells[14].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        lblMaxSize13.Text = Math.Round(Convert.ToDecimal(lblMinsize13.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize13.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption16.HeaderRow.Cells[15].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();

                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        lblMaxSize14.Text = Math.Round(Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize14.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption16.HeaderRow.Cells[16].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        lblMaxSize15.Text = Math.Round(Convert.ToDecimal(lblMinsize15.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize15.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption16.HeaderRow.Cells[17].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();


                        hdnIsshipped.Value = (dtQty.Rows[0]["Shipped"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Shipped"])).ToString();


                        if (hdnIsshipped.Value == "1")
                        {
                            e.Row.CssClass = "IsShipped borderbottom";
                        }
                        else
                        {
                            e.Row.CssClass = "borderbottom";
                        }
                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MinTotal != 0 || MinTotal != Convert.ToDecimal(0.0))
                            lblMinTotal1.Text = MinTotal.ToString();

                        decimal MaxTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMaxSize1.Text)
                                            + Convert.ToDecimal(lblMaxSize2.Text) + Convert.ToDecimal(lblMaxSize3.Text)
                                            + Convert.ToDecimal(lblMaxSize4.Text) + Convert.ToDecimal(lblMaxSize5.Text)
                                            + Convert.ToDecimal(lblMaxSize6.Text) + Convert.ToDecimal(lblMaxSize7.Text)
                                            + Convert.ToDecimal(lblMaxSize8.Text) + Convert.ToDecimal(lblMaxSize9.Text)
                                            + Convert.ToDecimal(lblMaxSize10.Text) + Convert.ToDecimal(lblMaxSize11.Text)
                                            + Convert.ToDecimal(lblMaxSize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MaxTotal != 0 || MaxTotal != Convert.ToDecimal(0.0))
                            lblMaxTotal1.Text = MaxTotal.ToString();

                        if (Convert.ToInt32(dtQty.Rows[0]["Quantity"]) == 0)
                        {
                            lblMinsize1.Text = "";
                            lblMaxSize1.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[1]["Quantity"]) == 0)
                        {
                            lblMinsize2.Text = "";
                            lblMaxSize2.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[2]["Quantity"]) == 0)
                        {
                            lblMinsize3.Text = "";
                            lblMaxSize3.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[3]["Quantity"]) == 0)
                        {
                            lblMinsize4.Text = "";
                            lblMaxSize4.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[4]["Quantity"]) == 0)
                        {
                            lblMinsize5.Text = "";
                            lblMaxSize5.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[5]["Quantity"]) == 0)
                        {
                            lblMinsize6.Text = "";
                            lblMaxSize6.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[6]["Quantity"]) == 0)
                        {
                            lblMinsize7.Text = "";
                            lblMaxSize7.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[7]["Quantity"]) == 0)
                        {
                            lblMinsize8.Text = "";
                            lblMaxSize8.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[8]["Quantity"]) == 0)
                        {
                            lblMinsize9.Text = "";
                            lblMaxSize9.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[9]["Quantity"]) == 0)
                        {
                            lblMinsize10.Text = "";
                            lblMaxSize10.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[10]["Quantity"]) == 0)
                        {
                            lblMinsize11.Text = "";
                            lblMaxSize11.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[11]["Quantity"]) == 0)
                        {
                            lblMinsize12.Text = "";
                            lblMaxSize12.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[12]["Quantity"]) == 0)
                        {
                            lblMinsize13.Text = "";
                            lblMaxSize13.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[13]["Quantity"]) == 0)
                        {
                            lblMinsize14.Text = "";
                            lblMaxSize14.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[14]["Quantity"]) == 0)
                        {
                            lblMinsize15.Text = "";
                            lblMaxSize15.Text = "";
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");
                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");
                dtTotalSize = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                if (TotalQuantity1 != 0)
                    lblTotalSize1.Text = TotalQuantity1.ToString();
                if (TotalQuantity2 != 0)
                    lblTotalSize2.Text = TotalQuantity2.ToString();
                if (TotalQuantity3 != 0)
                    lblTotalSize3.Text = TotalQuantity3.ToString();
                if (TotalQuantity4 != 0)
                    lblTotalSize4.Text = TotalQuantity4.ToString();
                if (TotalQuantity5 != 0)
                    lblTotalSize5.Text = TotalQuantity5.ToString();
                if (TotalQuantity6 != 0)
                    lblTotalSize6.Text = TotalQuantity6.ToString();
                if (TotalQuantity7 != 0)
                    lblTotalSize7.Text = TotalQuantity7.ToString();
                if (TotalQuantity8 != 0)
                    lblTotalSize8.Text = TotalQuantity8.ToString();
                if (TotalQuantity9 != 0)
                    lblTotalSize9.Text = TotalQuantity9.ToString();
                if (TotalQuantity10 != 0)
                    lblTotalSize10.Text = TotalQuantity10.ToString();
                if (TotalQuantity11 != 0)
                    lblTotalSize11.Text = TotalQuantity11.ToString();
                if (TotalQuantity12 != 0)
                    lblTotalSize12.Text = TotalQuantity12.ToString();
                if (TotalQuantity13 != 0)
                    lblTotalSize13.Text = TotalQuantity13.ToString();
                if (TotalQuantity14 != 0)
                    lblTotalSize14.Text = TotalQuantity14.ToString();
                if (TotalQuantity15 != 0)
                    lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
            }
        }
        protected void grdCuttingOption17_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;  
            {
                string x = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[10].ToString();
                if (x == "True")
                {
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffcccc");
                }
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId17");
                HiddenField hdnIsshipped = (HiddenField)e.Row.FindControl("hdnIsshipped17");

                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP17Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP17Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP17Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP17Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP17Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP17Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP17Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP17Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP17Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP17Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP17Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP17Minsize12");
                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP17Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP17Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP17Minsize15");

                Label lblMaxSize1 = (Label)e.Row.FindControl("lblOP17MaxSize1");
                Label lblMaxSize2 = (Label)e.Row.FindControl("lblOP17MaxSize2");
                Label lblMaxSize3 = (Label)e.Row.FindControl("lblOP17MaxSize3");
                Label lblMaxSize4 = (Label)e.Row.FindControl("lblOP17MaxSize4");
                Label lblMaxSize5 = (Label)e.Row.FindControl("lblOP17MaxSize5");
                Label lblMaxSize6 = (Label)e.Row.FindControl("lblOP17MaxSize6");
                Label lblMaxSize7 = (Label)e.Row.FindControl("lblOP17MaxSize7");
                Label lblMaxSize8 = (Label)e.Row.FindControl("lblOP17MaxSize8");
                Label lblMaxSize9 = (Label)e.Row.FindControl("lblOP17MaxSize9");
                Label lblMaxSize10 = (Label)e.Row.FindControl("lblOP17MaxSize10");
                Label lblMaxSize11 = (Label)e.Row.FindControl("lblOP17MaxSize11");
                Label lblMaxSize12 = (Label)e.Row.FindControl("lblOP17MaxSize12");

                Label lblMaxSize13 = (Label)e.Row.FindControl("lblOP17MaxSize13");
                Label lblMaxSize14 = (Label)e.Row.FindControl("lblOP17MaxSize14");
                Label lblMaxSize15 = (Label)e.Row.FindControl("lblOP17MaxSize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP17MinTotal1");
                Label lblMaxTotal1 = (Label)e.Row.FindControl("lblOP17MaxTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);

                HtmlGenericControl divexFactory = (HtmlGenericControl)e.Row.FindControl("exFactory17");
                string excolor = ViewState["exFacroty"].ToString();
                //e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml(excolor);


                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 17);
                    if (strODId4 == "")
                    {
                        strODId4 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId4 = strODId4 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        lblMaxSize1.Text = Math.Round(Convert.ToDecimal(lblMinsize1.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize1.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption17.HeaderRow.Cells[3].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        lblMaxSize2.Text = Math.Round(Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize2.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption17.HeaderRow.Cells[4].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        lblMaxSize3.Text = Math.Round(Convert.ToDecimal(lblMinsize3.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize3.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption17.HeaderRow.Cells[5].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        lblMaxSize4.Text = Math.Round(Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize4.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption17.HeaderRow.Cells[6].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        lblMaxSize5.Text = Math.Round(Convert.ToDecimal(lblMinsize5.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize5.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption17.HeaderRow.Cells[7].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        lblMaxSize6.Text = Math.Round(Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize6.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption17.HeaderRow.Cells[8].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        lblMaxSize7.Text = Math.Round(Convert.ToDecimal(lblMinsize7.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize7.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption17.HeaderRow.Cells[9].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        lblMaxSize8.Text = Math.Round(Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize8.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption17.HeaderRow.Cells[10].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        lblMaxSize9.Text = Math.Round(Convert.ToDecimal(lblMinsize9.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize9.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption17.HeaderRow.Cells[11].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        lblMaxSize10.Text = Math.Round(Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize10.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption17.HeaderRow.Cells[12].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        lblMaxSize11.Text = Math.Round(Convert.ToDecimal(lblMinsize11.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize11.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption17.HeaderRow.Cells[13].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        lblMaxSize12.Text = Math.Round(Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize12.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption17.HeaderRow.Cells[14].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        lblMaxSize13.Text = Math.Round(Convert.ToDecimal(lblMinsize13.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize13.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption17.HeaderRow.Cells[15].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();

                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        lblMaxSize14.Text = Math.Round(Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize14.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption17.HeaderRow.Cells[16].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        lblMaxSize15.Text = Math.Round(Convert.ToDecimal(lblMinsize15.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize15.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption17.HeaderRow.Cells[17].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();


                        hdnIsshipped.Value = (dtQty.Rows[0]["Shipped"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Shipped"])).ToString();


                        if (hdnIsshipped.Value == "1")
                        {
                            e.Row.CssClass = "IsShipped borderbottom";
                        }
                        else
                        {
                            e.Row.CssClass = "borderbottom";
                        }
                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MinTotal != 0 || MinTotal != Convert.ToDecimal(0.0))
                            lblMinTotal1.Text = MinTotal.ToString();

                        decimal MaxTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMaxSize1.Text)
                                            + Convert.ToDecimal(lblMaxSize2.Text) + Convert.ToDecimal(lblMaxSize3.Text)
                                            + Convert.ToDecimal(lblMaxSize4.Text) + Convert.ToDecimal(lblMaxSize5.Text)
                                            + Convert.ToDecimal(lblMaxSize6.Text) + Convert.ToDecimal(lblMaxSize7.Text)
                                            + Convert.ToDecimal(lblMaxSize8.Text) + Convert.ToDecimal(lblMaxSize9.Text)
                                            + Convert.ToDecimal(lblMaxSize10.Text) + Convert.ToDecimal(lblMaxSize11.Text)
                                            + Convert.ToDecimal(lblMaxSize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MaxTotal != 0 || MaxTotal != Convert.ToDecimal(0.0))
                            lblMaxTotal1.Text = MaxTotal.ToString();

                        if (Convert.ToInt32(dtQty.Rows[0]["Quantity"]) == 0)
                        {
                            lblMinsize1.Text = "";
                            lblMaxSize1.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[1]["Quantity"]) == 0)
                        {
                            lblMinsize2.Text = "";
                            lblMaxSize2.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[2]["Quantity"]) == 0)
                        {
                            lblMinsize3.Text = "";
                            lblMaxSize3.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[3]["Quantity"]) == 0)
                        {
                            lblMinsize4.Text = "";
                            lblMaxSize4.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[4]["Quantity"]) == 0)
                        {
                            lblMinsize5.Text = "";
                            lblMaxSize5.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[5]["Quantity"]) == 0)
                        {
                            lblMinsize6.Text = "";
                            lblMaxSize6.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[6]["Quantity"]) == 0)
                        {
                            lblMinsize7.Text = "";
                            lblMaxSize7.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[7]["Quantity"]) == 0)
                        {
                            lblMinsize8.Text = "";
                            lblMaxSize8.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[8]["Quantity"]) == 0)
                        {
                            lblMinsize9.Text = "";
                            lblMaxSize9.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[9]["Quantity"]) == 0)
                        {
                            lblMinsize10.Text = "";
                            lblMaxSize10.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[10]["Quantity"]) == 0)
                        {
                            lblMinsize11.Text = "";
                            lblMaxSize11.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[11]["Quantity"]) == 0)
                        {
                            lblMinsize12.Text = "";
                            lblMaxSize12.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[12]["Quantity"]) == 0)
                        {
                            lblMinsize13.Text = "";
                            lblMaxSize13.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[13]["Quantity"]) == 0)
                        {
                            lblMinsize14.Text = "";
                            lblMaxSize14.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[14]["Quantity"]) == 0)
                        {
                            lblMinsize15.Text = "";
                            lblMaxSize15.Text = "";
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");
                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");
                dtTotalSize = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                if (TotalQuantity1 != 0)
                    lblTotalSize1.Text = TotalQuantity1.ToString();
                if (TotalQuantity2 != 0)
                    lblTotalSize2.Text = TotalQuantity2.ToString();
                if (TotalQuantity3 != 0)
                    lblTotalSize3.Text = TotalQuantity3.ToString();
                if (TotalQuantity4 != 0)
                    lblTotalSize4.Text = TotalQuantity4.ToString();
                if (TotalQuantity5 != 0)
                    lblTotalSize5.Text = TotalQuantity5.ToString();
                if (TotalQuantity6 != 0)
                    lblTotalSize6.Text = TotalQuantity6.ToString();
                if (TotalQuantity7 != 0)
                    lblTotalSize7.Text = TotalQuantity7.ToString();
                if (TotalQuantity8 != 0)
                    lblTotalSize8.Text = TotalQuantity8.ToString();
                if (TotalQuantity9 != 0)
                    lblTotalSize9.Text = TotalQuantity9.ToString();
                if (TotalQuantity10 != 0)
                    lblTotalSize10.Text = TotalQuantity10.ToString();
                if (TotalQuantity11 != 0)
                    lblTotalSize11.Text = TotalQuantity11.ToString();
                if (TotalQuantity12 != 0)
                    lblTotalSize12.Text = TotalQuantity12.ToString();
                if (TotalQuantity13 != 0)
                    lblTotalSize13.Text = TotalQuantity13.ToString();
                if (TotalQuantity14 != 0)
                    lblTotalSize14.Text = TotalQuantity14.ToString();
                if (TotalQuantity15 != 0)
                    lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
            }
        }
        protected void grdCuttingOption18_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;  
            {
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId18");
                HiddenField hdnIsshipped = (HiddenField)e.Row.FindControl("hdnIsshipped18");

                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP18Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP18Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP18Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP18Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP18Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP18Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP18Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP18Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP18Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP18Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP18Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP18Minsize12");
                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP18Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP18Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP18Minsize15");

                Label lblMaxSize1 = (Label)e.Row.FindControl("lblOP18MaxSize1");
                Label lblMaxSize2 = (Label)e.Row.FindControl("lblOP18MaxSize2");
                Label lblMaxSize3 = (Label)e.Row.FindControl("lblOP18MaxSize3");
                Label lblMaxSize4 = (Label)e.Row.FindControl("lblOP18MaxSize4");
                Label lblMaxSize5 = (Label)e.Row.FindControl("lblOP18MaxSize5");
                Label lblMaxSize6 = (Label)e.Row.FindControl("lblOP18MaxSize6");
                Label lblMaxSize7 = (Label)e.Row.FindControl("lblOP18MaxSize7");
                Label lblMaxSize8 = (Label)e.Row.FindControl("lblOP18MaxSize8");
                Label lblMaxSize9 = (Label)e.Row.FindControl("lblOP18MaxSize9");
                Label lblMaxSize10 = (Label)e.Row.FindControl("lblOP18MaxSize10");
                Label lblMaxSize11 = (Label)e.Row.FindControl("lblOP18MaxSize11");
                Label lblMaxSize12 = (Label)e.Row.FindControl("lblOP18MaxSize12");

                Label lblMaxSize13 = (Label)e.Row.FindControl("lblOP18MaxSize13");
                Label lblMaxSize14 = (Label)e.Row.FindControl("lblOP18MaxSize14");
                Label lblMaxSize15 = (Label)e.Row.FindControl("lblOP18MaxSize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP18MinTotal1");
                Label lblMaxTotal1 = (Label)e.Row.FindControl("lblOP18MaxTotal1");

                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);

                HtmlGenericControl divexFactory = (HtmlGenericControl)e.Row.FindControl("exFactory18");
                string excolor = ViewState["exFacroty"].ToString();
                //e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml(excolor);


                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 18);
                    if (strODId4 == "")
                    {
                        strODId4 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId4 = strODId4 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        lblMaxSize1.Text = Math.Round(Convert.ToDecimal(lblMinsize1.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize1.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption18.HeaderRow.Cells[3].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        lblMaxSize2.Text = Math.Round(Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize2.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption18.HeaderRow.Cells[4].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        lblMaxSize3.Text = Math.Round(Convert.ToDecimal(lblMinsize3.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize3.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption18.HeaderRow.Cells[5].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        lblMaxSize4.Text = Math.Round(Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize4.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption18.HeaderRow.Cells[6].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        lblMaxSize5.Text = Math.Round(Convert.ToDecimal(lblMinsize5.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize5.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption18.HeaderRow.Cells[7].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        lblMaxSize6.Text = Math.Round(Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize6.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption18.HeaderRow.Cells[8].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        lblMaxSize7.Text = Math.Round(Convert.ToDecimal(lblMinsize7.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize7.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption18.HeaderRow.Cells[9].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        lblMaxSize8.Text = Math.Round(Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize8.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption18.HeaderRow.Cells[10].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        lblMaxSize9.Text = Math.Round(Convert.ToDecimal(lblMinsize9.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize9.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption18.HeaderRow.Cells[11].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        lblMaxSize10.Text = Math.Round(Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize10.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption18.HeaderRow.Cells[12].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        lblMaxSize11.Text = Math.Round(Convert.ToDecimal(lblMinsize11.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize11.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption18.HeaderRow.Cells[13].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        lblMaxSize12.Text = Math.Round(Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize12.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption18.HeaderRow.Cells[14].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        lblMaxSize13.Text = Math.Round(Convert.ToDecimal(lblMinsize13.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize13.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption18.HeaderRow.Cells[15].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();

                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        lblMaxSize14.Text = Math.Round(Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize14.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption18.HeaderRow.Cells[16].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        lblMaxSize15.Text = Math.Round(Convert.ToDecimal(lblMinsize15.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize15.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption18.HeaderRow.Cells[17].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();


                        hdnIsshipped.Value = (dtQty.Rows[0]["Shipped"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Shipped"])).ToString();


                        if (hdnIsshipped.Value == "1")
                        {
                            e.Row.CssClass = "IsShipped borderbottom";
                        }
                        else
                        {
                            e.Row.CssClass = "borderbottom";
                        }
                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MinTotal != 0 || MinTotal != Convert.ToDecimal(0.0))
                            lblMinTotal1.Text = MinTotal.ToString();

                        decimal MaxTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMaxSize1.Text)
                                            + Convert.ToDecimal(lblMaxSize2.Text) + Convert.ToDecimal(lblMaxSize3.Text)
                                            + Convert.ToDecimal(lblMaxSize4.Text) + Convert.ToDecimal(lblMaxSize5.Text)
                                            + Convert.ToDecimal(lblMaxSize6.Text) + Convert.ToDecimal(lblMaxSize7.Text)
                                            + Convert.ToDecimal(lblMaxSize8.Text) + Convert.ToDecimal(lblMaxSize9.Text)
                                            + Convert.ToDecimal(lblMaxSize10.Text) + Convert.ToDecimal(lblMaxSize11.Text)
                                            + Convert.ToDecimal(lblMaxSize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)));
                        if (MaxTotal != 0 || MaxTotal != Convert.ToDecimal(0.0))
                            lblMaxTotal1.Text = MaxTotal.ToString();

                        if (Convert.ToInt32(dtQty.Rows[0]["Quantity"]) == 0)
                        {
                            lblMinsize1.Text = "";
                            lblMaxSize1.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[1]["Quantity"]) == 0)
                        {
                            lblMinsize2.Text = "";
                            lblMaxSize2.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[2]["Quantity"]) == 0)
                        {
                            lblMinsize3.Text = "";
                            lblMaxSize3.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[3]["Quantity"]) == 0)
                        {
                            lblMinsize4.Text = "";
                            lblMaxSize4.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[4]["Quantity"]) == 0)
                        {
                            lblMinsize5.Text = "";
                            lblMaxSize5.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[5]["Quantity"]) == 0)
                        {
                            lblMinsize6.Text = "";
                            lblMaxSize6.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[6]["Quantity"]) == 0)
                        {
                            lblMinsize7.Text = "";
                            lblMaxSize7.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[7]["Quantity"]) == 0)
                        {
                            lblMinsize8.Text = "";
                            lblMaxSize8.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[8]["Quantity"]) == 0)
                        {
                            lblMinsize9.Text = "";
                            lblMaxSize9.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[9]["Quantity"]) == 0)
                        {
                            lblMinsize10.Text = "";
                            lblMaxSize10.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[10]["Quantity"]) == 0)
                        {
                            lblMinsize11.Text = "";
                            lblMaxSize11.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[11]["Quantity"]) == 0)
                        {
                            lblMinsize12.Text = "";
                            lblMaxSize12.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[12]["Quantity"]) == 0)
                        {
                            lblMinsize13.Text = "";
                            lblMaxSize13.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[13]["Quantity"]) == 0)
                        {
                            lblMinsize14.Text = "";
                            lblMaxSize14.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[14]["Quantity"]) == 0)
                        {
                            lblMinsize15.Text = "";
                            lblMaxSize15.Text = "";
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");
                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");
                dtTotalSize = this.OrderControllerInstance.GetTotalSizeByContract(strODId4);

                if (TotalQuantity1 != 0)
                    lblTotalSize1.Text = TotalQuantity1.ToString();
                if (TotalQuantity2 != 0)
                    lblTotalSize2.Text = TotalQuantity2.ToString();
                if (TotalQuantity3 != 0)
                    lblTotalSize3.Text = TotalQuantity3.ToString();
                if (TotalQuantity4 != 0)
                    lblTotalSize4.Text = TotalQuantity4.ToString();
                if (TotalQuantity5 != 0)
                    lblTotalSize5.Text = TotalQuantity5.ToString();
                if (TotalQuantity6 != 0)
                    lblTotalSize6.Text = TotalQuantity6.ToString();
                if (TotalQuantity7 != 0)
                    lblTotalSize7.Text = TotalQuantity7.ToString();
                if (TotalQuantity8 != 0)
                    lblTotalSize8.Text = TotalQuantity8.ToString();
                if (TotalQuantity9 != 0)
                    lblTotalSize9.Text = TotalQuantity9.ToString();
                if (TotalQuantity10 != 0)
                    lblTotalSize10.Text = TotalQuantity10.ToString();
                if (TotalQuantity11 != 0)
                    lblTotalSize11.Text = TotalQuantity11.ToString();
                if (TotalQuantity12 != 0)
                    lblTotalSize12.Text = TotalQuantity12.ToString();
                if (TotalQuantity13 != 0)
                    lblTotalSize13.Text = TotalQuantity13.ToString();
                if (TotalQuantity14 != 0)
                    lblTotalSize14.Text = TotalQuantity14.ToString();
                if (TotalQuantity15 != 0)
                    lblTotalSize15.Text = TotalQuantity15.ToString();

                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
            }
        }
        protected void grdCuttingOption19_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;  
            {
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId19");
                HiddenField hdnIsshipped = (HiddenField)e.Row.FindControl("hdnIsshipped19");

                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP19Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP19Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP19Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP19Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP19Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP19Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP19Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP19Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP19Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP19Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP19Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP19Minsize12");
                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP19Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP19Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP19Minsize15");

                Label lblMaxSize1 = (Label)e.Row.FindControl("lblOP19MaxSize1");
                Label lblMaxSize2 = (Label)e.Row.FindControl("lblOP19MaxSize2");
                Label lblMaxSize3 = (Label)e.Row.FindControl("lblOP19MaxSize3");
                Label lblMaxSize4 = (Label)e.Row.FindControl("lblOP19MaxSize4");
                Label lblMaxSize5 = (Label)e.Row.FindControl("lblOP19MaxSize5");
                Label lblMaxSize6 = (Label)e.Row.FindControl("lblOP19MaxSize6");
                Label lblMaxSize7 = (Label)e.Row.FindControl("lblOP19MaxSize7");
                Label lblMaxSize8 = (Label)e.Row.FindControl("lblOP19MaxSize8");
                Label lblMaxSize9 = (Label)e.Row.FindControl("lblOP19MaxSize9");
                Label lblMaxSize10 = (Label)e.Row.FindControl("lblOP19MaxSize10");
                Label lblMaxSize11 = (Label)e.Row.FindControl("lblOP19MaxSize11");
                Label lblMaxSize12 = (Label)e.Row.FindControl("lblOP19MaxSize12");

                Label lblMaxSize13 = (Label)e.Row.FindControl("lblOP19MaxSize13");
                Label lblMaxSize14 = (Label)e.Row.FindControl("lblOP19MaxSize14");
                Label lblMaxSize15 = (Label)e.Row.FindControl("lblOP19MaxSize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP19MinTotal1");
                Label lblMaxTotal1 = (Label)e.Row.FindControl("lblOP19MaxTotal1");


                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);

                HtmlGenericControl divexFactory = (HtmlGenericControl)e.Row.FindControl("exFactory19");
                string excolor = ViewState["exFacroty"].ToString();
                //e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml(excolor);


                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 19);
                    if (strODId19 == "")
                    {
                        strODId19 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId19 = strODId19 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        lblMaxSize1.Text = Math.Round(Convert.ToDecimal(lblMinsize1.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize1.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption19.HeaderRow.Cells[3].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        lblMaxSize2.Text = Math.Round(Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize2.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption19.HeaderRow.Cells[4].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        lblMaxSize3.Text = Math.Round(Convert.ToDecimal(lblMinsize3.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize3.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption19.HeaderRow.Cells[5].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        lblMaxSize4.Text = Math.Round(Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize4.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption19.HeaderRow.Cells[6].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        lblMaxSize5.Text = Math.Round(Convert.ToDecimal(lblMinsize5.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize5.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption19.HeaderRow.Cells[7].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        lblMaxSize6.Text = Math.Round(Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize6.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption19.HeaderRow.Cells[8].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        lblMaxSize7.Text = Math.Round(Convert.ToDecimal(lblMinsize7.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize7.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption19.HeaderRow.Cells[9].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        lblMaxSize8.Text = Math.Round(Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize8.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption19.HeaderRow.Cells[10].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        lblMaxSize8.Text = Math.Round(Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize8.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption19.HeaderRow.Cells[10].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        lblMaxSize9.Text = Math.Round(Convert.ToDecimal(lblMinsize9.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize9.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption19.HeaderRow.Cells[11].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        lblMaxSize10.Text = Math.Round(Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize10.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption19.HeaderRow.Cells[12].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        lblMaxSize11.Text = Math.Round(Convert.ToDecimal(lblMinsize11.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize11.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption19.HeaderRow.Cells[13].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        lblMaxSize12.Text = Math.Round(Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize12.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption19.HeaderRow.Cells[14].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        lblMaxSize13.Text = Math.Round(Convert.ToDecimal(lblMinsize13.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize13.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption19.HeaderRow.Cells[15].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();

                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        lblMaxSize14.Text = Math.Round(Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize14.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption19.HeaderRow.Cells[16].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        lblMaxSize15.Text = Math.Round(Convert.ToDecimal(lblMinsize15.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize15.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption19.HeaderRow.Cells[17].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();

                        hdnIsshipped.Value = (dtQty.Rows[0]["Shipped"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Shipped"])).ToString();
                        

                        if (hdnIsshipped.Value == "1")
                        {
                            e.Row.CssClass = "IsShipped borderbottom";
                        }
                        else
                        {
                            e.Row.CssClass = "borderbottom";
                        }
                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)
                                            ));
                        if (MinTotal != 0 || MinTotal != Convert.ToDecimal(0.0))
                            lblMinTotal1.Text = MinTotal.ToString();

                        decimal MaxTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMaxSize1.Text)
                                            + Convert.ToDecimal(lblMaxSize2.Text) + Convert.ToDecimal(lblMaxSize3.Text)
                                            + Convert.ToDecimal(lblMaxSize4.Text) + Convert.ToDecimal(lblMaxSize5.Text)
                                            + Convert.ToDecimal(lblMaxSize6.Text) + Convert.ToDecimal(lblMaxSize7.Text)
                                            + Convert.ToDecimal(lblMaxSize8.Text) + Convert.ToDecimal(lblMaxSize9.Text)
                                            + Convert.ToDecimal(lblMaxSize10.Text) + Convert.ToDecimal(lblMaxSize11.Text)
                                            + Convert.ToDecimal(lblMaxSize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)
                                            ));
                        if (MaxTotal != 0 || MaxTotal != Convert.ToDecimal(0.0))
                            lblMaxTotal1.Text = MaxTotal.ToString();

                        if (Convert.ToInt32(dtQty.Rows[0]["Quantity"]) == 0)
                        {
                            lblMinsize1.Text = "";
                            lblMaxSize1.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[1]["Quantity"]) == 0)
                        {
                            lblMinsize2.Text = "";
                            lblMaxSize2.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[2]["Quantity"]) == 0)
                        {
                            lblMinsize3.Text = "";
                            lblMaxSize3.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[3]["Quantity"]) == 0)
                        {
                            lblMinsize4.Text = "";
                            lblMaxSize4.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[4]["Quantity"]) == 0)
                        {
                            lblMinsize5.Text = "";
                            lblMaxSize5.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[5]["Quantity"]) == 0)
                        {
                            lblMinsize6.Text = "";
                            lblMaxSize6.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[6]["Quantity"]) == 0)
                        {
                            lblMinsize7.Text = "";
                            lblMaxSize7.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[7]["Quantity"]) == 0)
                        {
                            lblMinsize8.Text = "";
                            lblMaxSize8.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[8]["Quantity"]) == 0)
                        {
                            lblMinsize9.Text = "";
                            lblMaxSize9.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[9]["Quantity"]) == 0)
                        {
                            lblMinsize10.Text = "";
                            lblMaxSize10.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[10]["Quantity"]) == 0)
                        {
                            lblMinsize11.Text = "";
                            lblMaxSize11.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[11]["Quantity"]) == 0)
                        {
                            lblMinsize12.Text = "";
                            lblMaxSize12.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[12]["Quantity"]) == 0)
                        {
                            lblMinsize13.Text = "";
                            lblMaxSize13.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[13]["Quantity"]) == 0)
                        {
                            lblMinsize14.Text = "";
                            lblMaxSize14.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[14]["Quantity"]) == 0)
                        {
                            lblMinsize15.Text = "";
                            lblMaxSize15.Text = "";
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");
                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");
                dtTotalSize = this.OrderControllerInstance.GetTotalSizeByContract(strODId19);

                if (TotalQuantity1 != 0)
                    lblTotalSize1.Text = TotalQuantity1.ToString();
                if (TotalQuantity2 != 0)
                    lblTotalSize2.Text = TotalQuantity2.ToString();
                if (TotalQuantity3 != 0)
                    lblTotalSize3.Text = TotalQuantity3.ToString();
                if (TotalQuantity4 != 0)
                    lblTotalSize4.Text = TotalQuantity4.ToString();
                if (TotalQuantity5 != 0)
                    lblTotalSize5.Text = TotalQuantity5.ToString();
                if (TotalQuantity6 != 0)
                    lblTotalSize6.Text = TotalQuantity6.ToString();
                if (TotalQuantity7 != 0)
                    lblTotalSize7.Text = TotalQuantity7.ToString();
                if (TotalQuantity8 != 0)
                    lblTotalSize8.Text = TotalQuantity8.ToString();          
                if (TotalQuantity9 != 0)
                    lblTotalSize9.Text = TotalQuantity9.ToString();
                if (TotalQuantity10 != 0)
                    lblTotalSize10.Text = TotalQuantity10.ToString();
                if (TotalQuantity11 != 0)
                    lblTotalSize11.Text = TotalQuantity11.ToString();
                if (TotalQuantity12 != 0)
                    lblTotalSize12.Text = TotalQuantity12.ToString();
                if (TotalQuantity13 != 0)
                    lblTotalSize13.Text = TotalQuantity13.ToString();
                if (TotalQuantity14 != 0)
                    lblTotalSize14.Text = TotalQuantity14.ToString();
                if (TotalQuantity15 != 0)
                    lblTotalSize15.Text = TotalQuantity15.ToString();
                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0; 
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
            }
        }

        protected void grdCuttingOption20_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            // return;  
            {
                HiddenField hdnOdId1 = (HiddenField)e.Row.FindControl("hdnOdId20");
                HiddenField hdnIsshipped = (HiddenField)e.Row.FindControl("hdnIsshipped20");

                Label lblMinsize1 = (Label)e.Row.FindControl("lblOP20Minsize1");
                Label lblMinsize2 = (Label)e.Row.FindControl("lblOP20Minsize2");
                Label lblMinsize3 = (Label)e.Row.FindControl("lblOP20Minsize3");
                Label lblMinsize4 = (Label)e.Row.FindControl("lblOP20Minsize4");
                Label lblMinsize5 = (Label)e.Row.FindControl("lblOP20Minsize5");
                Label lblMinsize6 = (Label)e.Row.FindControl("lblOP20Minsize6");
                Label lblMinsize7 = (Label)e.Row.FindControl("lblOP20Minsize7");
                Label lblMinsize8 = (Label)e.Row.FindControl("lblOP20Minsize8");
                Label lblMinsize9 = (Label)e.Row.FindControl("lblOP20Minsize9");
                Label lblMinsize10 = (Label)e.Row.FindControl("lblOP20Minsize10");
                Label lblMinsize11 = (Label)e.Row.FindControl("lblOP20Minsize11");
                Label lblMinsize12 = (Label)e.Row.FindControl("lblOP20Minsize12");
                Label lblMinsize13 = (Label)e.Row.FindControl("lblOP20Minsize13");
                Label lblMinsize14 = (Label)e.Row.FindControl("lblOP20Minsize14");
                Label lblMinsize15 = (Label)e.Row.FindControl("lblOP20Minsize15");

                Label lblMaxSize1 = (Label)e.Row.FindControl("lblOP20MaxSize1");
                Label lblMaxSize2 = (Label)e.Row.FindControl("lblOP20MaxSize2");
                Label lblMaxSize3 = (Label)e.Row.FindControl("lblOP20MaxSize3");
                Label lblMaxSize4 = (Label)e.Row.FindControl("lblOP20MaxSize4");
                Label lblMaxSize5 = (Label)e.Row.FindControl("lblOP20MaxSize5");
                Label lblMaxSize6 = (Label)e.Row.FindControl("lblOP20MaxSize6");
                Label lblMaxSize7 = (Label)e.Row.FindControl("lblOP20MaxSize7");
                Label lblMaxSize8 = (Label)e.Row.FindControl("lblOP20MaxSize8");
                Label lblMaxSize9 = (Label)e.Row.FindControl("lblOP20MaxSize9");
                Label lblMaxSize10 = (Label)e.Row.FindControl("lblOP20MaxSize10");
                Label lblMaxSize11 = (Label)e.Row.FindControl("lblOP20MaxSize11");
                Label lblMaxSize12 = (Label)e.Row.FindControl("lblOP20MaxSize12");

                Label lblMaxSize13 = (Label)e.Row.FindControl("lblOP20MaxSize13");
                Label lblMaxSize14 = (Label)e.Row.FindControl("lblOP20MaxSize14");
                Label lblMaxSize15 = (Label)e.Row.FindControl("lblOP20MaxSize15");

                Label lblMinTotal1 = (Label)e.Row.FindControl("lblOP20MinTotal1");
                Label lblMaxTotal1 = (Label)e.Row.FindControl("lblOP20MaxTotal1");


                int OrderDetailId = Convert.ToInt32(hdnOdId1.Value);

                HtmlGenericControl divexFactory = (HtmlGenericControl)e.Row.FindControl("exFactory20");
                string excolor = ViewState["exFacroty"].ToString();
                //e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml(excolor);


                if (lblMinsize1 != null)
                {
                    dtQty = this.OrderControllerInstance.GetSizeQuantity(OrderDetailId, 20);
                    if (strODId20 == "")
                    {
                        strODId20 = OrderDetailId.ToString();
                    }
                    else
                    {
                        strODId20 = strODId20 + "," + OrderDetailId.ToString();
                    }
                    if (dtQty.Rows.Count > 0)
                    {
                        lblMinsize1.Text = (dtQty.Rows[0]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[0]["Quantity"])).ToString();
                        TotalQuantity1 = TotalQuantity1 + Convert.ToInt32(lblMinsize1.Text);
                        lblMaxSize1.Text = Math.Round(Convert.ToDecimal(lblMinsize1.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize1.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption20.HeaderRow.Cells[3].Text = (dtQty.Rows[0]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Size"])).ToString();

                        lblMinsize2.Text = (dtQty.Rows[1]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[1]["Quantity"])).ToString();
                        TotalQuantity2 = TotalQuantity2 + Convert.ToInt32(lblMinsize2.Text);
                        lblMaxSize2.Text = Math.Round(Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize2.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption20.HeaderRow.Cells[4].Text = (dtQty.Rows[1]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[1]["Size"])).ToString();

                        lblMinsize3.Text = (dtQty.Rows[2]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[2]["Quantity"])).ToString();
                        TotalQuantity3 = TotalQuantity3 + Convert.ToInt32(lblMinsize3.Text);
                        lblMaxSize3.Text = Math.Round(Convert.ToDecimal(lblMinsize3.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize3.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption20.HeaderRow.Cells[5].Text = (dtQty.Rows[2]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[2]["Size"])).ToString();

                        lblMinsize4.Text = (dtQty.Rows[3]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[3]["Quantity"])).ToString();
                        TotalQuantity4 = TotalQuantity4 + Convert.ToInt32(lblMinsize4.Text);
                        lblMaxSize4.Text = Math.Round(Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize4.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption20.HeaderRow.Cells[6].Text = (dtQty.Rows[3]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[3]["Size"])).ToString();

                        lblMinsize5.Text = (dtQty.Rows[4]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[4]["Quantity"])).ToString();
                        TotalQuantity5 = TotalQuantity5 + Convert.ToInt32(lblMinsize5.Text);
                        lblMaxSize5.Text = Math.Round(Convert.ToDecimal(lblMinsize5.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize5.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption20.HeaderRow.Cells[7].Text = (dtQty.Rows[4]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[4]["Size"])).ToString();

                        lblMinsize6.Text = (dtQty.Rows[5]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[5]["Quantity"])).ToString();
                        TotalQuantity6 = TotalQuantity6 + Convert.ToInt32(lblMinsize6.Text);
                        lblMaxSize6.Text = Math.Round(Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize6.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption20.HeaderRow.Cells[8].Text = (dtQty.Rows[5]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[5]["Size"])).ToString();

                        lblMinsize7.Text = (dtQty.Rows[6]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[6]["Quantity"])).ToString();
                        TotalQuantity7 = TotalQuantity7 + Convert.ToInt32(lblMinsize7.Text);
                        lblMaxSize7.Text = Math.Round(Convert.ToDecimal(lblMinsize7.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize7.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption20.HeaderRow.Cells[9].Text = (dtQty.Rows[6]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[6]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        lblMaxSize8.Text = Math.Round(Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize8.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption20.HeaderRow.Cells[10].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize8.Text = (dtQty.Rows[7]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[7]["Quantity"])).ToString();
                        TotalQuantity8 = TotalQuantity8 + Convert.ToInt32(lblMinsize8.Text);
                        lblMaxSize8.Text = Math.Round(Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize8.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption20.HeaderRow.Cells[10].Text = (dtQty.Rows[7]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[7]["Size"])).ToString();

                        lblMinsize9.Text = (dtQty.Rows[8]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[8]["Quantity"])).ToString();
                        TotalQuantity9 = TotalQuantity9 + Convert.ToInt32(lblMinsize9.Text);
                        lblMaxSize9.Text = Math.Round(Convert.ToDecimal(lblMinsize9.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize9.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption20.HeaderRow.Cells[11].Text = (dtQty.Rows[8]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[8]["Size"])).ToString();

                        lblMinsize10.Text = (dtQty.Rows[9]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[9]["Quantity"])).ToString();
                        TotalQuantity10 = TotalQuantity10 + Convert.ToInt32(lblMinsize10.Text);
                        lblMaxSize10.Text = Math.Round(Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize10.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption20.HeaderRow.Cells[12].Text = (dtQty.Rows[9]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[9]["Size"])).ToString();

                        lblMinsize11.Text = (dtQty.Rows[10]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[10]["Quantity"])).ToString();
                        TotalQuantity11 = TotalQuantity11 + Convert.ToInt32(lblMinsize11.Text);
                        lblMaxSize11.Text = Math.Round(Convert.ToDecimal(lblMinsize11.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize11.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption20.HeaderRow.Cells[13].Text = (dtQty.Rows[10]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[10]["Size"])).ToString();

                        lblMinsize12.Text = (dtQty.Rows[11]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[11]["Quantity"])).ToString();
                        TotalQuantity12 = TotalQuantity12 + Convert.ToInt32(lblMinsize12.Text);
                        lblMaxSize12.Text = Math.Round(Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize12.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption20.HeaderRow.Cells[14].Text = (dtQty.Rows[11]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[11]["Size"])).ToString();

                        lblMinsize13.Text = (dtQty.Rows[12]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[12]["Quantity"])).ToString();
                        TotalQuantity13 = TotalQuantity13 + Convert.ToInt32(lblMinsize13.Text);
                        lblMaxSize13.Text = Math.Round(Convert.ToDecimal(lblMinsize13.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize13.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption20.HeaderRow.Cells[15].Text = (dtQty.Rows[12]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[12]["Size"])).ToString();

                        lblMinsize14.Text = (dtQty.Rows[13]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[13]["Quantity"])).ToString();
                        TotalQuantity14 = TotalQuantity14 + Convert.ToInt32(lblMinsize14.Text);
                        lblMaxSize14.Text = Math.Round(Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize14.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption20.HeaderRow.Cells[16].Text = (dtQty.Rows[13]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[13]["Size"])).ToString();

                        lblMinsize15.Text = (dtQty.Rows[14]["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(dtQty.Rows[14]["Quantity"])).ToString();
                        TotalQuantity15 = TotalQuantity15 + Convert.ToInt32(lblMinsize15.Text);
                        lblMaxSize15.Text = Math.Round(Convert.ToDecimal(lblMinsize15.Text) + Convert.ToDecimal((Convert.ToInt32(lblMinsize15.Text) * (4.4 / 100)))).ToString();
                        grdCuttingOption20.HeaderRow.Cells[17].Text = (dtQty.Rows[14]["Size"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[14]["Size"])).ToString();

                        hdnIsshipped.Value = (dtQty.Rows[0]["Shipped"] == DBNull.Value ? "" : Convert.ToString(dtQty.Rows[0]["Shipped"])).ToString();


                        if (hdnIsshipped.Value == "1")
                        {
                            e.Row.CssClass = "IsShipped borderbottom";
                        }
                        else
                        {
                            e.Row.CssClass = "borderbottom";
                        }
                        decimal MinTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMinsize1.Text)
                                            + Convert.ToDecimal(lblMinsize2.Text) + Convert.ToDecimal(lblMinsize3.Text)
                                            + Convert.ToDecimal(lblMinsize4.Text) + Convert.ToDecimal(lblMinsize5.Text)
                                            + Convert.ToDecimal(lblMinsize6.Text) + Convert.ToDecimal(lblMinsize7.Text)
                                            + Convert.ToDecimal(lblMinsize8.Text) + Convert.ToDecimal(lblMinsize9.Text)
                                            + Convert.ToDecimal(lblMinsize10.Text) + Convert.ToDecimal(lblMinsize11.Text)
                                            + Convert.ToDecimal(lblMinsize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)
                                            ));
                        if (MinTotal != 0 || MinTotal != Convert.ToDecimal(0.0))
                            lblMinTotal1.Text = MinTotal.ToString();

                        decimal MaxTotal = Math.Round(Convert.ToDecimal(Convert.ToDecimal(lblMaxSize1.Text)
                                            + Convert.ToDecimal(lblMaxSize2.Text) + Convert.ToDecimal(lblMaxSize3.Text)
                                            + Convert.ToDecimal(lblMaxSize4.Text) + Convert.ToDecimal(lblMaxSize5.Text)
                                            + Convert.ToDecimal(lblMaxSize6.Text) + Convert.ToDecimal(lblMaxSize7.Text)
                                            + Convert.ToDecimal(lblMaxSize8.Text) + Convert.ToDecimal(lblMaxSize9.Text)
                                            + Convert.ToDecimal(lblMaxSize10.Text) + Convert.ToDecimal(lblMaxSize11.Text)
                                            + Convert.ToDecimal(lblMaxSize12.Text) + Convert.ToDecimal(lblMinsize13.Text)
                                            + Convert.ToDecimal(lblMinsize14.Text) + Convert.ToDecimal(lblMinsize15.Text)
                                            ));
                        if (MaxTotal != 0 || MaxTotal != Convert.ToDecimal(0.0))
                            lblMaxTotal1.Text = MaxTotal.ToString();

                        if (Convert.ToInt32(dtQty.Rows[0]["Quantity"]) == 0)
                        {
                            lblMinsize1.Text = "";
                            lblMaxSize1.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[1]["Quantity"]) == 0)
                        {
                            lblMinsize2.Text = "";
                            lblMaxSize2.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[2]["Quantity"]) == 0)
                        {
                            lblMinsize3.Text = "";
                            lblMaxSize3.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[3]["Quantity"]) == 0)
                        {
                            lblMinsize4.Text = "";
                            lblMaxSize4.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[4]["Quantity"]) == 0)
                        {
                            lblMinsize5.Text = "";
                            lblMaxSize5.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[5]["Quantity"]) == 0)
                        {
                            lblMinsize6.Text = "";
                            lblMaxSize6.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[6]["Quantity"]) == 0)
                        {
                            lblMinsize7.Text = "";
                            lblMaxSize7.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[7]["Quantity"]) == 0)
                        {
                            lblMinsize8.Text = "";
                            lblMaxSize8.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[8]["Quantity"]) == 0)
                        {
                            lblMinsize9.Text = "";
                            lblMaxSize9.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[9]["Quantity"]) == 0)
                        {
                            lblMinsize10.Text = "";
                            lblMaxSize10.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[10]["Quantity"]) == 0)
                        {
                            lblMinsize11.Text = "";
                            lblMaxSize11.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[11]["Quantity"]) == 0)
                        {
                            lblMinsize12.Text = "";
                            lblMaxSize12.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[12]["Quantity"]) == 0)
                        {
                            lblMinsize13.Text = "";
                            lblMaxSize13.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[13]["Quantity"]) == 0)
                        {
                            lblMinsize14.Text = "";
                            lblMaxSize14.Text = "";
                        }
                        if (Convert.ToInt32(dtQty.Rows[14]["Quantity"]) == 0)
                        {
                            lblMinsize15.Text = "";
                            lblMaxSize15.Text = "";
                        }
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataSet dtTotalSize = new DataSet();
                Label lblTotalSize1 = (Label)e.Row.FindControl("lblTotalSize1");
                Label lblTotalSize2 = (Label)e.Row.FindControl("lblTotalSize2");
                Label lblTotalSize3 = (Label)e.Row.FindControl("lblTotalSize3");
                Label lblTotalSize4 = (Label)e.Row.FindControl("lblTotalSize4");
                Label lblTotalSize5 = (Label)e.Row.FindControl("lblTotalSize5");
                Label lblTotalSize6 = (Label)e.Row.FindControl("lblTotalSize6");
                Label lblTotalSize7 = (Label)e.Row.FindControl("lblTotalSize7");
                Label lblTotalSize8 = (Label)e.Row.FindControl("lblTotalSize8");
                Label lblTotalSize9 = (Label)e.Row.FindControl("lblTotalSize9");
                Label lblTotalSize10 = (Label)e.Row.FindControl("lblTotalSize10");
                Label lblTotalSize11 = (Label)e.Row.FindControl("lblTotalSize11");
                Label lblTotalSize12 = (Label)e.Row.FindControl("lblTotalSize12");
                Label lblTotalSize13 = (Label)e.Row.FindControl("lblTotalSize13");
                Label lblTotalSize14 = (Label)e.Row.FindControl("lblTotalSize14");
                Label lblTotalSize15 = (Label)e.Row.FindControl("lblTotalSize15");
                dtTotalSize = this.OrderControllerInstance.GetTotalSizeByContract(strODId20);

                if (TotalQuantity1 != 0)
                    lblTotalSize1.Text = TotalQuantity1.ToString();
                if (TotalQuantity2 != 0)
                    lblTotalSize2.Text = TotalQuantity2.ToString();
                if (TotalQuantity3 != 0)
                    lblTotalSize3.Text = TotalQuantity3.ToString();
                if (TotalQuantity4 != 0)
                    lblTotalSize4.Text = TotalQuantity4.ToString();
                if (TotalQuantity5 != 0)
                    lblTotalSize5.Text = TotalQuantity5.ToString();
                if (TotalQuantity6 != 0)
                    lblTotalSize6.Text = TotalQuantity6.ToString();
                if (TotalQuantity7 != 0)
                    lblTotalSize7.Text = TotalQuantity7.ToString();
                if (TotalQuantity8 != 0)
                    lblTotalSize8.Text = TotalQuantity8.ToString();
                if (TotalQuantity9 != 0)
                    lblTotalSize9.Text = TotalQuantity9.ToString();
                if (TotalQuantity10 != 0)
                    lblTotalSize10.Text = TotalQuantity10.ToString();
                if (TotalQuantity11 != 0)
                    lblTotalSize11.Text = TotalQuantity11.ToString();
                if (TotalQuantity12 != 0)
                    lblTotalSize12.Text = TotalQuantity12.ToString();
                if (TotalQuantity13 != 0)
                    lblTotalSize13.Text = TotalQuantity13.ToString();
                if (TotalQuantity14 != 0)
                    lblTotalSize14.Text = TotalQuantity14.ToString();
                if (TotalQuantity15 != 0)
                    lblTotalSize15.Text = TotalQuantity15.ToString();
                TotalQuantity1 = 0;
                TotalQuantity2 = 0;
                TotalQuantity3 = 0;
                TotalQuantity4 = 0;
                TotalQuantity5 = 0;
                TotalQuantity6 = 0;
                TotalQuantity7 = 0;
                TotalQuantity8 = 0;
                TotalQuantity9 = 0;
                TotalQuantity10 = 0;
                TotalQuantity11 = 0;
                TotalQuantity12 = 0;
                TotalQuantity13 = 0;
                TotalQuantity14 = 0;
                TotalQuantity15 = 0;
            }
        }


        protected void grdCuttingOption1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

