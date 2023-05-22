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
namespace iKandi.Web.Internal.Fabric
{
    public partial class FabricOrderPrintComments : System.Web.UI.Page
    {
        AccessoryQualityController objacc = new AccessoryQualityController();
        public int orderid
        {
            get;
            set;
        }
        FabricController objfab = new FabricController();
        static bool IsAvgChecked;
        static bool IsFMAvgChecked;
        protected void Page_Load(object sender, EventArgs e)
        {
            // orderid = 8983;
            //orderid = 9063;
            //orderid = 8545;

            if (Request.QueryString["orderid"] != null)
            {
                orderid = Convert.ToInt32(Request.QueryString["orderid"]);
            }
            //if (!Page.IsPostBack)
            //{
            Bindalloptiongrd();
            bindHeader();
            // }

        }
        int FabCount = 0;
        DataTable globaldt = new DataTable();
        DataTable globaldt2 = new DataTable();
        protected void bindHeader()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = objfab.GetFabricOrderPrint(orderid, 1);
            dt = ds.Tables[0];
            globaldt = ds.Tables[0];

            DataSet ds2 = new DataSet();
            DataTable dt2 = new DataTable();

            ds2 = objfab.GetFabricOrderPrint(orderid, 5);
            dt2 = ds2.Tables[0];
            globaldt2 = ds2.Tables[0];

            FabCount = Convert.ToInt32(dt.Rows[0]["seqID"].ToString());
            if (grdfabricOrderPrint.Columns.Count > 0)
            {
                grdfabricOrderPrint.Columns.Clear();

            }

            IsAvgChecked = dt.Rows[0]["IsApprovedAMForFabric"] == DBNull.Value ? false : Convert.ToBoolean(dt.Rows[0]["IsApprovedAMForFabric"]);
            chkboxAccountMgr.Checked = IsAvgChecked;
            //if (chkboxAccountMgr.Checked)
            //{          
            chkboxAccountMgr.Attributes.Add("onclick", "return false;");
            //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
            //}


            IsFMAvgChecked = dt.Rows[0]["ApprovedByFabricManager"] == DBNull.Value ? false : Convert.ToBoolean(dt.Rows[0]["ApprovedByFabricManager"]);
            chkboxFabricMgr.Checked = IsFMAvgChecked;
            //if (chkboxAccountMgr.Checked)
            //{          
            chkboxFabricMgr.Attributes.Add("onclick", "return false;");
            //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
            //}

            TemplateField OrderDeatil = new TemplateField();
            OrderDeatil.HeaderText = "OrderDeatils";
            OrderDeatil.HeaderStyle.CssClass = "HeaderStyle1";
            OrderDeatil.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "OrderDeatils", "OrderDeatils");
            grdfabricOrderPrint.Columns.Insert(0, OrderDeatil);
            OrderDeatil.HeaderStyle.Width = 100;
            OrderDeatil.ItemStyle.Height = 40;   /*updated by bharat 14 jan-19*/


            TemplateField Qty = new TemplateField();
            Qty.HeaderText = "Qty";
            Qty.HeaderStyle.CssClass = "Qty";
            Qty.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "Qty", "Qty");
            Qty.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            grdfabricOrderPrint.Columns.Insert(1, Qty);
            Qty.HeaderStyle.Width = 100;

            int x = 1;
            int idchek = 0;
            if (FabCount > 0)
            {
                for (int i = 1; i <= FabCount; i++)
                {
                    int Z = (i - 1);
                    TemplateField ColorPrint = new TemplateField();
                    ColorPrint.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "lblColorPrint_" + globaldt2.Rows[Z]["SeqID"] + "_" + globaldt2.Rows[Z]["OrderDetailsID"], "lblColorPrint_" + globaldt2.Rows[Z]["SeqID"] + "_" + globaldt2.Rows[Z]["OrderDetailsID"]);
                    ColorPrint.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    grdfabricOrderPrint.Columns.Insert(idchek + 2, ColorPrint);
                    ColorPrint.HeaderStyle.Width = 50;

                    // x = FabCount;

                    TemplateField OrderCutAvg = new TemplateField();
                    OrderCutAvg.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "lblOrderCutAvg_" + globaldt2.Rows[Z]["SeqID"] + "_" + globaldt2.Rows[Z]["OrderDetailsID"], "lblOrderCutAvg_" + globaldt2.Rows[Z]["SeqID"] + "_" + globaldt2.Rows[Z]["OrderDetailsID"]);
                    OrderCutAvg.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    grdfabricOrderPrint.Columns.Insert(idchek + 3, OrderCutAvg);
                    OrderCutAvg.HeaderStyle.Width = 50;

                    // x = x + 1;


                    //new code start
                    TemplateField OrderCutWidth = new TemplateField();
                    OrderCutWidth.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "lblOrderCutWidth_" + globaldt2.Rows[Z]["SeqID"] + "_" + globaldt2.Rows[Z]["OrderDetailsID"], "lblOrderCutWidth_" + globaldt2.Rows[Z]["SeqID"] + "_" + globaldt2.Rows[Z]["OrderDetailsID"]);
                    OrderCutWidth.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    grdfabricOrderPrint.Columns.Insert(idchek + 4, OrderCutWidth);
                    OrderCutWidth.HeaderStyle.Width = 50;

                    //  x = x + 1;
                    //new code end

                    TemplateField Swatches = new TemplateField();
                    Swatches.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "lblSwatches_" + i.ToString(), "lblSwatches_" + i.ToString());
                    Swatches.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    grdfabricOrderPrint.Columns.Insert(idchek + 5, Swatches);
                    Swatches.HeaderStyle.Width = 100;

                    //  x = x + i;
                    idchek = idchek + 4;
                }

            }
            TemplateField Discription = new TemplateField();
            Discription.HeaderStyle.CssClass = "Discription";
            Discription.ItemTemplate = new iKandi.Common.GridViewTemplate("textmultiline", "txtDiscription", "txtDiscription");
            Discription.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            Discription.ControlStyle.CssClass = "textarea";
            grdfabricOrderPrint.Columns.Insert(idchek + 2, Discription);
            Discription.HeaderStyle.Width = 100;


            grdfabricOrderPrint.DataSource = dt;
            grdfabricOrderPrint.DataBind();

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
            lblDepartment.Text = DtOrderDetails.Rows[0]["DepartmentName"].ToString();
            lblstylenumber.Text = DtOrderDetails.Rows[0]["stylenumber"].ToString();
        }
        int ZZ = 0;
        protected void grdfabricOrderPrint_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                headerRow1.Attributes.Add("class", "HeaderClass");
                headerRow2.Attributes.Add("class", "HeaderClass");

                TableCell HeaderCell = new TableCell();
                //Adding the Row at the 0th position (first row) in the Grid
                HeaderCell = new TableCell();
                //HeaderCell.Text = "<table><tr><td>Contract No.</td></tr><tr><td>Line No.</td></tr><tr><td>Ex-Factory</td></tr></table>";  //commented to hide line number
                HeaderCell.Text = "<table><tr><td>Contract No.<br>BIH<br>Ex-Factory</td></tr></table>";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.RowSpan = 2;
                HeaderCell.Attributes.Add("class", "ColWidth1");
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Contract <br> Qty.";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.RowSpan = 2;
                HeaderCell.Attributes.Add("class", "ColWidth2");
                headerRow1.Cells.Add(HeaderCell);


                int FabSeqNo = 1;
                for (int Y = 0; Y < FabCount; Y++)
                {
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    if (globaldt2.Rows[Y] != null)
                    {
                        if (globaldt.Rows.Count > 0)
                        {

                            ds = objfab.GetFabricOrderPrint(orderid, 2, FabSeqNo, Convert.ToInt32(globaldt2.Rows[Y]["OrderDetailsID"].ToString()));
                            dt = ds.Tables[0];
                        }
                    }
                    HeaderCell = new TableCell();
                    //HeaderCell.Text = "<table><tr><td class='innertabletdLR'>" + dt.Rows[0]["TradeName"].ToString() + " " + dt.Rows[0]["CC"].ToString() +  "</td></tr></table>";
                    string valueAdd = dt.Rows[0]["ValueAddition"] == DBNull.Value ? "" : dt.Rows[0]["ValueAddition"].ToString();
                    string valueAddition;
                    //if(valueAdd.Length>0)
                    if (valueAdd.Contains(','))
                    {
                        valueAddition = valueAdd.Remove(valueAdd.LastIndexOf(","));
                    }
                    else
                    {
                        valueAddition = valueAdd;
                    }
                    //HeaderCell.Text = "<table><tr><td class='innertabletdLR'>" + dt.Rows[0]["TradeName"].ToString() + " " + dt.Rows[0]["CC"].ToString() + "</br>" + dt.Rows[0]["ValueAddition"].ToString() + "</td></tr></table>";
                    HeaderCell.Text = "<table><tr><td class='innertabletdLR'> <span style='color:blue'>" + dt.Rows[0]["TradeName"].ToString() + "</span><span style='color:gray'> " + dt.Rows[0]["CC"].ToString() +  valueAddition + "<span style='float:right'>" + dt.Rows[0]["UnitName"].ToString() + "</span></span></td></tr></table>";
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.ColumnSpan = 4;    //modified on 04-12-2020
                    headerRow1.Cells.Add(HeaderCell);
                    HeaderCell.Width = 50;
                    FabSeqNo = FabSeqNo + 1;

                    //row 2
                    HeaderCell = new TableCell();
                    HeaderCell.Text = "Color/Print";
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.Attributes.Add("class", "ColoPrintW");
                    headerRow2.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "Odr (Cut) Avg";
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.Attributes.Add("class", "cutAvgW");
                    headerRow2.Cells.Add(HeaderCell);

                    HeaderCell = new TableCell();
                    HeaderCell.Text = "Odr (Cut) Width";
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.Attributes.Add("class", "cutAvgW");
                    headerRow2.Cells.Add(HeaderCell);


                    HeaderCell = new TableCell();
                    HeaderCell.Text = "Swatch";
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.Attributes.Add("class", "cutAvgW");
                    headerRow2.Cells.Add(HeaderCell);
                }
                HeaderCell = new TableCell();
                HeaderCell.Text = "Description";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.RowSpan = 2;
                HeaderCell.Attributes.Add("class", "ColWidth1");

                headerRow1.Cells.Add(HeaderCell);
                grdfabricOrderPrint.Controls[0].Controls.AddAt(0, headerRow2);
                grdfabricOrderPrint.Controls[0].Controls.AddAt(0, headerRow1);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                DataRowView drv = (DataRowView)e.Row.DataItem;
                Label OrderDeatils = e.Row.FindControl("OrderDeatils") as Label;
                Label Qty = e.Row.FindControl("Qty") as Label;
                TextBox txtDiscription = e.Row.FindControl("txtDiscription") as TextBox;
                string d = "";
                if (globaldt.Rows[e.Row.RowIndex]["ContractNumber"].ToString() != "")
                {
                    char[] MyChar = { '/', '<', 'b', 'r', '>' };
                    string[] sdsd = globaldt.Rows[e.Row.RowIndex]["ContractNumber"].ToString().Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string s in sdsd)
                    {
                        string[] g = s.Split(new string[] { "$$" }, StringSplitOptions.RemoveEmptyEntries);
                        d = d + s + "/" + "<br>";
                    }
                    d = d.Remove(d.Length - 1).TrimEnd(MyChar);
                }

                string ContractDeatils = "<DIV>" + d + "</DIV>" +
                    //"<DIV>" + globaldt.Rows[e.Row.RowIndex]["LineItemNumber"].ToString() + "</DIV>" +   //commented to hide line number
                "<DIV class='exfact' style='color:#000;'>" + Convert.ToDateTime(globaldt.Rows[e.Row.RowIndex]["BulkFabricTarget"]).ToString("dd MMM yy (ddd)") + "</DIV>" +
                "<DIV class='exfact'>" + Convert.ToDateTime(globaldt.Rows[e.Row.RowIndex]["ExFactory"]).ToString("dd MMM yy (ddd)") + "</DIV>";
                txtDiscription.TextChanged += new EventHandler(textBox_TextChanged);
                txtDiscription.AutoPostBack = true;

                txtDiscription.Text = drv.Row.ItemArray[7].ToString();
                //txtDiscription.Text = drv.Row.Table.Columns["txtDiscription"].ToString();


                /*updated by bharat 14 jan-19*/
                Qty.Text = "<span style='color:gray;font-weight:600'> " + Convert.ToInt32(globaldt.Rows[e.Row.RowIndex]["Quantity"]).ToString("N0") + "</span>";  /*updated by bharat 14 jan-19*/
                HiddenField hdnorderdetailid = new HiddenField();
                hdnorderdetailid.ID = "hdnorderdetailids";
                hdnorderdetailid.Value = (drv.Row.ItemArray[5] == DBNull.Value ? "" : drv.Row.ItemArray[5].ToString());

                e.Row.Cells[0].Controls.Add(hdnorderdetailid);
                OrderDeatils.Text = ContractDeatils;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                if (globaldt2.Rows.Count > 0)
                {
                    if (FabCount > 0)
                    {
                        for (int i = 1; i <= FabCount; i++)
                        {
                            int Z = (i - 1);
                            ds = objfab.GetFabricOrderPrint(orderid, 2, Convert.ToInt32(globaldt2.Rows[ZZ]["SeqID"]), Convert.ToInt32(globaldt2.Rows[ZZ]["OrderDetailsID"].ToString()));
                            dt = ds.Tables[0];
                            Label lblColorPrint = e.Row.FindControl("lblColorPrint_" + globaldt2.Rows[Z]["SeqID"] + "_" + globaldt2.Rows[Z]["OrderDetailsID"].ToString()) as Label;
                            Label lblOrderCutAvg = e.Row.FindControl("lblOrderCutAvg_" + globaldt2.Rows[Z]["SeqID"] + "_" + globaldt2.Rows[Z]["OrderDetailsID"]) as Label;

                            Label lblOrderCutWidth = e.Row.FindControl("lblOrderCutWidth_" + globaldt2.Rows[Z]["SeqID"] + "_" + globaldt2.Rows[Z]["OrderDetailsID"]) as Label;
                            Label lblSwatches = e.Row.FindControl("lblSwatches_" + i.ToString()) as Label;

                            if (dt.Rows.Count > 0)
                            {
                                lblColorPrint.Text = dt.Rows[0]["colorprint"].ToString();
                                //lblOrderCutAvg.Text = "<DIV>" + dt.Rows[0]["OrderAvg"].ToString() + " (" + dt.Rows[0]["CutAvg"].ToString() + ")</DIV>" + "<DIV class='cutavqty'>" + dt.Rows[0]["UnitName"].ToString() + "</DIV>";  /*updated by bharat 15 jan-19*/
                                lblOrderCutAvg.Text = "<DIV>" + dt.Rows[0]["OrderAvg"].ToString() + " (" + dt.Rows[0]["CutAvg"].ToString() + ")</DIV>";  /*updated by bharat 15 jan-19*/

                                lblOrderCutWidth.Text = "<DIV>" + dt.Rows[0]["OrderWidth"].ToString() + " (" + dt.Rows[0]["CutWidth"].ToString() + ")</DIV>";
                                //lblSwatches.Text = "<DIV>" + dt.Rows[0]["OrderWidth"].ToString() + "</DIV>";
                                lblSwatches.Text = "";
                            }

                            ZZ = ZZ + 1;
                            /*updated by bharat 15 jan-19*/
                            lblColorPrint.Attributes.Add("class", "printcolortext");

                        }
                    }
                }
                int FabSeqNo = 1;
                FabSeqNo = FabSeqNo + 1;
                /*updated by bharat 15 jan-19*/
                Qty.Attributes.Add("class", "textcolorqty");
                int widthH = 275 + (360 * FabCount);
                string headerWi = widthH.ToString();
                Headerwidth.Attributes.Add("width", headerWi + "px");
                grdfabricOrderPrint.Width = widthH;
            }


        }
        protected void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            GridViewRow row = textbox.NamingContainer as GridViewRow;
            HiddenField hdnorderdetailids = (HiddenField)row.FindControl("hdnorderdetailids");

            if (textbox != null && hdnorderdetailids != null)
            {
                if (!string.IsNullOrEmpty(hdnorderdetailids.Value) && hdnorderdetailids.Value != "-1")
                {
                    objfab.UpdateFabricPrintMarchantComments(Convert.ToInt32(hdnorderdetailids.Value), textbox.Text);
                }
            }
            Response.Redirect(Request.RawUrl);

        }
    }
}