using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Drawing;
using iKandi.BLL;
using iKandi.Web.Components;

//using iKandi.BLL;
namespace iKandi.Web.UserControls.Lists
{
    public partial class MOEtaPopup : BaseUserControl
    {



        public string Flag1
        {
            get;
            set;
        }


        public string Flag2
        {
            get;
            set;
        }
        public int StyleId
        {
            get;
            set;
        }
        public string Val1
        {
            get;
            set;
        }

        public string Val2
        {
            get;
            set;
        }
        public string SDate
        {
            get;
            set;
        }

        public string EDate
        {
            get;
            set;
        }
        public string Inhousepercent
        {
            get;
            set;
        }


        //public string remark
        //{
        //    get;
        //    set;
        //}
        public string SerialNumber
        {
            get;
            set;
        }
        public string Days
        {
            get;
            set;
        }

        public int OrderDetailId
        {
            get;
            set;
        }

        public int ColumnId
        {
            get;
            set;
        }

        public int AccworkingId
        {
            get;
            set;
        }
        //added by abhishek on 18/12/2015
        public int AccInhousePercent
        {
            get;
            set;
        }
        //end by abhishek on 18/12/2015

        string strAccessRemrak = "";
        string strRemarks = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            GetQueryString();
            if (!IsPostBack)
                BindControl();
        }

        public void GetQueryString()
        {
            if (null != Request.QueryString["Flag1"])
            {
                Flag1 = Request.QueryString["Flag1"].ToString();
            }
            if (null != Request.QueryString["Flag2"])
            {
                Flag2 = Request.QueryString["Flag2"].ToString();
            }
            if (null != Request.QueryString["StyleId"])
            {
                StyleId = Convert.ToInt32(Request.QueryString["StyleId"]);
            }
            if (null != Request.QueryString["AccID"])
            {
                AccworkingId = Convert.ToInt32(Request.QueryString["AccID"]);
            }

            if (null != Request.QueryString["Val1"])
            {
                Val1 = Request.QueryString["Val1"].ToString();
            }
            if (null != Request.QueryString["Val2"])
            {
                Val2 = Request.QueryString["Val2"].ToString();
            }

            if (null != Request.QueryString["SDate"])
            {
                SDate = Request.QueryString["SDate"].ToString();
            }
            if (null != Request.QueryString["EDate"])
            {
                EDate = Request.QueryString["EDate"].ToString();
            }
            //if (null != Request.QueryString["remark"])
            //{
            //    remark = Request.QueryString["remark"].ToString();
            //}
            if (null != Request.QueryString["SerialNumber"])
            {
                SerialNumber = Request.QueryString["SerialNumber"].ToString();
            }

            if (null != Request.QueryString["OrderDetailId"])
            {
                OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"]);
            }
            if (null != Request.QueryString["ColumnId"])
            {
                ColumnId = Convert.ToInt32(Request.QueryString["ColumnId"]);
            }
            if (null != Request.QueryString["Days"])
            {
                Days = (Request.QueryString["Days"]).ToString();
            }
            if (null != Request.QueryString["Inhousepercent"])
            {
                Inhousepercent = (Request.QueryString["Inhousepercent"]).ToString();
            }
            if (null != Request.QueryString["AccesoryInhouse"])
            {
                AccInhousePercent = Convert.ToInt32(Request.QueryString["AccesoryInhouse"]);
            }
        }

        public void BindControl()
        {
            DataTable dtPermission = new DataTable();
            int desigId = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.Designation);
            int DeptId = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID);
            // int UserID = Convert.ToInt32(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID);

            //bool IsPermission = this.OrderControllerInstance.IscheckShippingRemarksPermission(desigId, DeptId, ColumnId);

            //if (IsPermission == true)
            //    btnSubmit1.Visible = true;
            //else
            //    btnSubmit1.Visible = false;
            //  Val1 = Val1.Replace("and", "&");
            // code add by sushil on date 20/3/2015
            Val1 = Val1.Replace("and", "&").Replace("hx", "#");

            //added by sushil on date 30/3/2015
            //if (Flag1 == "Fabric" && SDate != "" && Inhousepercent !="0")
            //{

            //    lblBIHStart.Enabled = false;
            //}
            //end by sushil on date 30/3/2015

            //added by abhishek on 18/12/2015
            if (Flag1 == "Fabric")
            {
                double inhouse = Convert.ToDouble(Inhousepercent);
                double minval = Convert.ToDouble(0);
                double maxval = Convert.ToDouble(100);
                if (inhouse > minval && inhouse < maxval)
                {
                    lblBIHStart.Enabled = false;
                }
                else if (inhouse >= maxval)
                {
                    lblBIHStart.Enabled = false;
                    lblBIHEnd.Enabled = false;
                }
                //Updated abhishek on 3/2/2016
                
                 DivFabricsatus.Attributes.Add("style", "display:block");
                //end by abhishek on 3/2/2016
            }
            if (Flag1 == "Access")
            {
                double inhouse = Convert.ToDouble(AccInhousePercent);
                double minval = Convert.ToDouble(0);
                double maxval = Convert.ToDouble(100);

                if (inhouse >= maxval)
                {
                    lblBIHEnd.Enabled = false;
                }

            }
            if ((Flag1 == "Fabric" && Convert.ToInt32(Inhousepercent) >= 100) || (Flag1 == "Access" && Convert.ToInt32(AccInhousePercent) >= 100))
            {
                btnSubmit1.Disabled = true;
                btnSubmit1.Attributes["class"] = "btn-disable";

            }

            //end by abhishek on 18/12/2015

            if (Flag1 != "Access")
            {
                strRemarks = this.OrderControllerInstance.GetMoETARemarks(Flag1, Flag2, StyleId, Val1, Val2, OrderDetailId);

                if (strRemarks != "")
                {
                    string[] separators = { "`" };
                    string[] words = strRemarks.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in words)
                    {
                        lblShowRemark.Text = lblShowRemark.Text + "</br>" + word;
                    }
                }
            }
            lblStyleNumber.Text = SerialNumber;
            lblBIHStart.Text = SDate;
            lblBIHEnd.Text = EDate;
            btnAccess.Visible = false;
            // sushil kumar code for stitched BIH end date + Days
            if (Flag1 == "Stitched")
            {
                DateTime ETASDate = DateTime.Now;
                DateTime ETANdate;

                if (SDate != "")
                {
                    ETASDate = DateTime.ParseExact(SDate, "dd MMM yy (ddd)", null);
                }


                ETANdate = ETASDate.AddDays(double.Parse(Days));
                lblBIHEnd.Text = ETANdate.ToString("dd MMM yy (ddd)");
            }

            lblName.Text = Val1;
            if (Flag1 != "Access")
            {
                lblPrint.Text = Val2;
            }
            if (Flag1 != "Fabric")
            {
                lblName.Text = Flag1;
            }
            hdnFlag1.Value = Flag1;
            hdnFlag2.Value = Flag2;
            hdnstyleid.Value = StyleId.ToString();

            if (Flag1 == "Emb")
            {
                lblVA.Text = "V.A.";
                lblName.Visible = false;
            }
            if (Flag1 == "Access")
            {
                lblBIHEnd.Visible = true;
                lblbihe.Visible = true;
                lblBIHStart.Visible = false;
                lblbihs.Visible = false;
                lblBIHEnd.Text = SDate;
                btnAccess.Visible = true;
                btnSubmit1.Visible = false;
                //gvNew.Columns[11].Visible = false;
                lblName.Text = Val1;
            }

            if (Flag1 == "Packed")
            {
                lblBIHEnd.Visible = false;
                lblbihe.Visible = false;
                lblBIHStart.Visible = true;
                lblbihs.Visible = true;
                lblName.Text = Flag1;
                lblbihs.Text = "END ETA";
            }
            if (Flag2 == "FitsETA")
            {
                lblBIHEnd.Visible = false;
                lblbihe.Visible = false;
                lblBIHStart.Visible = true;
                lblbihs.Visible = true;
                lblbihs.Text = "ETA DATE :";
                gvNew.Columns[7].Visible = true;

                if (Flag1 == "STCRequest")
                {
                    lblName.Text = "STC";
                }
                if (Flag1 == "PatternETA")
                {
                    lblName.Text = "Pattern Sample";
                }
                if (Flag1 == "TOPETA")
                {
                    lblName.Text = "TOP Sent";
                    
                }
                //Added By Ashish on 4/3/2015
                if (Flag1 == "FitsStatusETA")
                {
                    lblName.Text = "Fits";
                }
                //END
            }
            List<OrderDetail> ds = this.OrderControllerInstance.GetMoETAInfo(Flag1, Flag2, StyleId, Val1, Val2, AccworkingId);
            if (ds.Count > 0)
            {

                gvNew.DataSource = ds;
                gvNew.DataBind();
                gv.Visible = false;
                GvFitsETA.Visible = false;

                if (strAccessRemrak != "")
                {
                    string[] separators = { "`" };
                    string[] words = strAccessRemrak.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in words)
                    {
                        lblShowRemark.Text = lblShowRemark.Text + "</br>" + word;
                    }
                }
            }
            else
            {
                btnSubmit1.Visible = false;
                btnAccess.Visible = false;
            }
            //added by abhishek on 25/12/2015
            BindFabricETAStatus(Flag2, OrderDetailId);
            //end by abhishek on 25/12/2015

        }

        protected void gv_rowdatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            Label lblSDate = e.Row.FindControl("lblSDate") as Label;
            Label lblEDate = e.Row.FindControl("lblEDate") as Label;
            Label lblCalBIH = e.Row.FindControl("lblCalBIH") as Label;

            if (lblSDate != null)
            {
                DateTime dtSDate = Convert.ToDateTime(lblSDate.Text);
                if (dtSDate.ToString("dd-MM-yyyy") == "01-01-0001")
                {
                    lblSDate.Text = "";
                }
                else
                {
                    string strSDate = dtSDate.ToString("dd MMM yy (ddd)");
                    lblSDate.Text = strSDate;
                }
            }

            if (lblEDate != null)
            {
                DateTime dtEDate = Convert.ToDateTime(lblEDate.Text);
                if (dtEDate.ToString("dd-MM-yyyy") == "01-01-0001")
                {
                    lblEDate.Text = "";
                }
                else
                {
                    string strEDate = dtEDate.ToString("dd MMM yy (ddd)");
                    lblEDate.Text = strEDate;
                }
            }

            if (lblCalBIH != null)
            {
                DateTime dtBIH = Convert.ToDateTime(lblCalBIH.Text);
                if (dtBIH.ToString("dd-MM-yyyy") == "01-01-0001")
                {
                    lblCalBIH.Text = "";
                }
                else
                {
                    string strBIH = dtBIH.ToString("dd MMM yy (ddd)");
                    lblCalBIH.Text = strBIH;
                }
            }
        }

        //protected void CheckHeader_OnCheckedChanged(object sender, EventArgs e)
        //{

        //    for (int i = 0; i < gv.Rows.Count; i++)
        //    {
        //        CheckBox cb = (CheckBox)gv.Rows[i].FindControl("CheckBox1");
        //        cb.Checked = true;
        //    }
        //}

        protected void btnAccessSubmit_Click(object sender, EventArgs e)
        {
        }

        protected void gvNew_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            OrderDetail od = (e.Row.DataItem as OrderDetail);
            Label lblFabric1 = e.Row.FindControl("lblFabric1") as Label;
            Label lblFabric2 = e.Row.FindControl("lblFabric2") as Label;
            Label lblFabric3 = e.Row.FindControl("lblFabric3") as Label;
            Label lblFabric4 = e.Row.FindControl("lblFabric4") as Label;
            Label lblFabric5 = e.Row.FindControl("lblFabric5") as Label;
            Label lblFabric6 = e.Row.FindControl("lblFabric6") as Label;
            Label Fabric1Percent = e.Row.FindControl("lblFabric1Percent") as Label;
            Label Fabric2Percent = e.Row.FindControl("lblFabric2Percent") as Label;
            Label Fabric3Percent = e.Row.FindControl("lblFabric3Percent") as Label;
            Label Fabric4Percent = e.Row.FindControl("lblFabric4Percent") as Label;
            Label Fabric5Percent = e.Row.FindControl("lblFabric5Percent") as Label;
            Label Fabric6Percent = e.Row.FindControl("lblFabric6Percent") as Label;

            Label lblFabric1DetailsRef = e.Row.FindControl("lblFabric1DetailsRef") as Label;
            Label lblFabric2DetailsRef = e.Row.FindControl("lblFabric2DetailsRef") as Label;
            Label lblFabric3DetailsRef = e.Row.FindControl("lblFabric3DetailsRef") as Label;
            Label lblFabric4DetailsRef = e.Row.FindControl("lblFabric4DetailsRef") as Label;
            Label lblFabric5DetailsRef = e.Row.FindControl("lblFabric5DetailsRef") as Label;
            Label lblFabric6DetailsRef = e.Row.FindControl("lblFabric6DetailsRef") as Label;

            Label lblFabricStartETAdate1 = e.Row.FindControl("lblFabricStartETAdate1") as Label;
            Label lblFabricEndETAdate1 = e.Row.FindControl("lblFabricEndETAdate1") as Label;
            Label lblFabricStartETAdate2 = e.Row.FindControl("lblFabricStartETAdate2") as Label;
            Label lblFabricEndETAdate2 = e.Row.FindControl("lblFabricEndETAdate2") as Label;
            Label lblFabricStartETAdate3 = e.Row.FindControl("lblFabricStartETAdate3") as Label;
            Label lblFabricEndETAdate3 = e.Row.FindControl("lblFabricEndETAdate3") as Label;
            Label lblFabricStartETAdate4 = e.Row.FindControl("lblFabricStartETAdate4") as Label;
            Label lblFabricEndETAdate4 = e.Row.FindControl("lblFabricEndETAdate4") as Label;
            Label lblFabricStartETAdate5 = e.Row.FindControl("lblFabricStartETAdate5") as Label;
            Label lblFabricEndETAdate5 = e.Row.FindControl("lblFabricEndETAdate5") as Label;
            Label lblFabricStartETAdate6 = e.Row.FindControl("lblFabricStartETAdate6") as Label;
            Label lblFabricEndETAdate6 = e.Row.FindControl("lblFabricEndETAdate6") as Label;


            HtmlTableRow tbl1 = (HtmlTableRow)e.Row.FindControl("tbl1");
            HtmlTableRow tbl2 = (HtmlTableRow)e.Row.FindControl("tbl2");
            HtmlTableRow tbl3 = (HtmlTableRow)e.Row.FindControl("tbl3");
            HtmlTableRow tbl4 = (HtmlTableRow)e.Row.FindControl("tbl4");
            HtmlTableRow tbl5 = (HtmlTableRow)e.Row.FindControl("tbl5");
            HtmlTableRow tbl6 = (HtmlTableRow)e.Row.FindControl("tbl6");

            Label lvlCutReady = e.Row.FindControl("lvlCutReady") as Label;
            Label lblCutPercentInhouse = e.Row.FindControl("lblCutPercentInhouse") as Label;
            Label lblStitched = e.Row.FindControl("lblStitched") as Label;
            Label lblStitchedPercentInhouse = e.Row.FindControl("lblStitchedPercentInhouse") as Label;
            Label lvlVA = e.Row.FindControl("lvlVA") as Label;
            Label lblVAPercentInhouse = e.Row.FindControl("lblVAPercentInhouse") as Label;
            Label lblPacked = e.Row.FindControl("lblPacked") as Label;
            Label lblPackedPercentInhouse = e.Row.FindControl("lblPackedPercentInhouse") as Label;

            Label lblCutreadyENDETA = e.Row.FindControl("lblCutreadyENDETA") as Label;
            Label lblCutreadyStartETA = e.Row.FindControl("lblCutreadyStartETA") as Label;
            Label lblStichedStartETA = e.Row.FindControl("lblStichedStartETA") as Label;
            Label lblStichedENDETA = e.Row.FindControl("lblStichedENDETA") as Label;
            Label lblVAStartETA = e.Row.FindControl("lblVAStartETA") as Label;
            Label lblVAENDETA = e.Row.FindControl("lblVAENDETA") as Label;
            Label lblPackedETA = e.Row.FindControl("lblPackedETA") as Label;
            HtmlTableCell tdFabric1 = e.Row.FindControl("tdFabric1") as HtmlTableCell;
            HtmlTableCell tdprint1 = e.Row.FindControl("tdprint1") as HtmlTableCell;
            HtmlTableCell tdFabric1DetailsRef = e.Row.FindControl("tdFabric1DetailsRef") as HtmlTableCell;
            HtmlTableCell tdFabricStartETAdate1 = e.Row.FindControl("tdFabricStartETAdate1") as HtmlTableCell;
            HtmlTableCell tdFabricEndETAdate1 = e.Row.FindControl("tdFabricEndETAdate1") as HtmlTableCell;
            HtmlTableCell tdFabric2 = e.Row.FindControl("tdFabric2") as HtmlTableCell;
            HtmlTableCell tdFabric2Percent = e.Row.FindControl("tdFabric2Percent") as HtmlTableCell;
            HtmlTableCell tdFabric2DetailsRef = e.Row.FindControl("tdFabric2DetailsRef") as HtmlTableCell;
            HtmlTableCell tdFabricStartETAdate2 = e.Row.FindControl("tdFabricStartETAdate2") as HtmlTableCell;
            HtmlTableCell tdFabricEndETAdate2 = e.Row.FindControl("tdFabricEndETAdate2") as HtmlTableCell;
            HtmlTableCell tdFabric3 = e.Row.FindControl("tdFabric3") as HtmlTableCell;
            HtmlTableCell tdFabric3Percent = e.Row.FindControl("tdFabric3Percent") as HtmlTableCell;
            HtmlTableCell tdFabric3DetailsRef = e.Row.FindControl("tdFabric3DetailsRef") as HtmlTableCell;
            HtmlTableCell tdFabricStartETAdate3 = e.Row.FindControl("tdFabricStartETAdate3") as HtmlTableCell;
            HtmlTableCell tdFabricEndETAdate3 = e.Row.FindControl("tdFabricEndETAdate3") as HtmlTableCell;
            HtmlTableCell tdFabric4Percent = e.Row.FindControl("tdFabric4Percent") as HtmlTableCell;
            HtmlTableCell tdFabric4DetailsRef = e.Row.FindControl("tdFabric4DetailsRef") as HtmlTableCell;
            HtmlTableCell tdFabricStartETAdate4 = e.Row.FindControl("tdFabricStartETAdate4") as HtmlTableCell;
            HtmlTableCell tdFabricEndETAdate4 = e.Row.FindControl("tdFabricEndETAdate4") as HtmlTableCell;
            // --------------------------------------------
            HtmlTableCell tdCutReady = e.Row.FindControl("tdCutReady") as HtmlTableCell;
            HtmlTableCell tdCutPercentInhouse = e.Row.FindControl("tdCutPercentInhouse") as HtmlTableCell;
            HtmlTableCell tdCutreadyStartETA = e.Row.FindControl("tdCutreadyStartETA") as HtmlTableCell;
            HtmlTableCell tdCutreadyENDETA = e.Row.FindControl("tdCutreadyENDETA") as HtmlTableCell;
            HtmlTableCell tdStitched = e.Row.FindControl("tdStitched") as HtmlTableCell;
            HtmlTableCell tdStitchedPercentInhouse = e.Row.FindControl("tdStitchedPercentInhouse") as HtmlTableCell;
            HtmlTableCell tdStichedStartETA = e.Row.FindControl("tdStichedStartETA") as HtmlTableCell;
            HtmlTableCell tdStichedENDETA = e.Row.FindControl("tdStichedENDETA") as HtmlTableCell;
            HtmlTableCell tdVA = e.Row.FindControl("tdVA") as HtmlTableCell;
            HtmlTableCell tdVAPercentInhouse = e.Row.FindControl("tdVAPercentInhouse") as HtmlTableCell;
            HtmlTableCell tdVAStartETA = e.Row.FindControl("tdVAStartETA") as HtmlTableCell;
            HtmlTableCell tdVAENDETA = e.Row.FindControl("tdVAENDETA") as HtmlTableCell;
            HtmlTableCell tdlPacked = e.Row.FindControl("tdlPacked") as HtmlTableCell;
            HtmlTableCell tdPackedPercentInhouse = e.Row.FindControl("tdPackedPercentInhouse") as HtmlTableCell;
            HtmlTableCell tdPackedETA = e.Row.FindControl("tdPackedETA") as HtmlTableCell;
            //---------------------
            HtmlTableCell tdstc = e.Row.FindControl("tdstc") as HtmlTableCell;
            HtmlTableCell tdLabel6 = e.Row.FindControl("tdLabel6") as HtmlTableCell;
            HtmlTableCell tdPatternSample = e.Row.FindControl("tdPatternSample") as HtmlTableCell;
            HtmlTableCell tdPatternETA = e.Row.FindControl("tdPatternETA") as HtmlTableCell;
            HtmlTableCell tdtop = e.Row.FindControl("tdtop") as HtmlTableCell;
            HtmlTableCell tdTOPETA = e.Row.FindControl("tdTOPETA") as HtmlTableCell;



            CheckBox CheckCB = e.Row.FindControl("cb") as CheckBox;




            if (lblFabric1 != null)
            {
                if (lblFabric1.Text != "")
                {
                    tbl1.Visible = true;
                    // if (Convert.ToInt32(Fabric1Percent.Text) >= 100)
                    if (lblFabricStartETAdate1.Text != "" && lblFabricEndETAdate1.Text != "" && Convert.ToInt32(Fabric1Percent.Text) >= 100)
                    {
                        lblFabric1.ForeColor = Color.Gray;
                        Fabric1Percent.ForeColor = Color.Gray;
                        lblFabricStartETAdate1.ForeColor = Color.Gray;
                        lblFabricEndETAdate1.ForeColor = Color.Gray;
                        lblFabric1DetailsRef.ForeColor = Color.Gray;

                    }


                    // td3f1.Style.Add(" background-color", "#FF0000");

                }
            }
            if (lblFabric2 != null)
            {
                if (lblFabric2.Text != "")
                {
                    tbl2.Visible = true;
                    // if (Convert.ToInt32(Fabric2Percent.Text) >= 100)
                    if (lblFabricStartETAdate2.Text != "" && lblFabricEndETAdate2.Text != "" && Convert.ToInt32(Fabric2Percent.Text) >= 100)
                    {
                        lblFabric2.ForeColor = Color.Gray;
                        Fabric2Percent.ForeColor = Color.Gray;
                        lblFabricStartETAdate2.ForeColor = Color.Gray;
                        lblFabricEndETAdate2.ForeColor = Color.Gray;
                        lblFabric2DetailsRef.ForeColor = Color.Gray;
                    }

                }
            }
            if (lblFabric3 != null)
            {
                if (lblFabric3.Text != "")
                {
                    tbl3.Visible = true;
                    //if (Convert.ToInt32(Fabric3Percent.Text) >= 100)
                    if (lblFabricStartETAdate3.Text != "" && lblFabricEndETAdate3.Text != "" && Convert.ToInt32(Fabric3Percent.Text) >= 100)
                    {
                        lblFabric3.ForeColor = Color.Gray;
                        Fabric3Percent.ForeColor = Color.Gray;
                        lblFabricStartETAdate3.ForeColor = Color.Gray;
                        lblFabricEndETAdate3.ForeColor = Color.Gray;
                        lblFabric3DetailsRef.ForeColor = Color.Gray;
                    }

                }
            }
            if (lblFabric4 != null)
            {
                if (lblFabric4.Text != "")
                {
                    tbl4.Visible = true;
                    //if (Convert.ToInt32(Fabric4Percent.Text) >= 100)
                    if (lblFabricStartETAdate4.Text != "" && lblFabricEndETAdate4.Text != "" && Convert.ToInt32(Fabric4Percent.Text) >= 100)
                    {
                        lblFabric3.ForeColor = Color.Gray;
                        Fabric3Percent.ForeColor = Color.Gray;
                        lblFabricStartETAdate4.ForeColor = Color.Gray;
                        lblFabricEndETAdate4.ForeColor = Color.Gray;
                        lblFabric4DetailsRef.ForeColor = Color.Gray;
                    }


                }
            }
            if (lblFabric5 != null)
            {
                if (lblFabric5.Text != "")
                {
                    tbl5.Visible = true;
                    //if (Convert.ToInt32(Fabric4Percent.Text) >= 100)
                    if (lblFabricStartETAdate5.Text != "" && lblFabricEndETAdate5.Text != "" && Convert.ToInt32(Fabric5Percent.Text) >= 100)
                    {
                        lblFabric5.ForeColor = Color.Gray;
                        Fabric5Percent.ForeColor = Color.Gray;
                        lblFabricStartETAdate5.ForeColor = Color.Gray;
                        lblFabricEndETAdate5.ForeColor = Color.Gray;
                        lblFabric5DetailsRef.ForeColor = Color.Gray;
                    }


                }
            }
            if (lblFabric6 != null)
            {
                if (lblFabric6.Text != "")
                {
                    tbl6.Visible = true;
                    //if (Convert.ToInt32(Fabric4Percent.Text) >= 100)
                    if (lblFabricStartETAdate6.Text != "" && lblFabricEndETAdate6.Text != "" && Convert.ToInt32(Fabric6Percent.Text) >= 100)
                    {
                        lblFabric6.ForeColor = Color.Gray;
                        Fabric6Percent.ForeColor = Color.Gray;
                        lblFabricStartETAdate6.ForeColor = Color.Gray;
                        lblFabricEndETAdate6.ForeColor = Color.Gray;
                        lblFabric6DetailsRef.ForeColor = Color.Gray;
                    }


                }
            }


            if (lblCutPercentInhouse != null)
            {
                //if (Convert.ToInt32(lblCutPercentInhouse.Text) >= 100)
                if (lblCutreadyStartETA.Text != "" && lblCutreadyENDETA.Text != "" && Convert.ToInt32(lblCutPercentInhouse.Text) >= 100)
                {
                    lblCutPercentInhouse.ForeColor = Color.Gray;
                    lvlCutReady.ForeColor = Color.Gray;
                    lblCutreadyENDETA.ForeColor = Color.Gray;
                    lblCutreadyStartETA.ForeColor = Color.Gray;

                }
            }



            if (lblStitchedPercentInhouse != null)
            {
                //if (Convert.ToInt32(lblStitchedPercentInhouse.Text) >= 100)
                if (lblStichedStartETA.Text != "" && lblStichedENDETA.Text != "" && Convert.ToInt32(lblStitchedPercentInhouse.Text) >= 100)
                {
                    lblStitchedPercentInhouse.ForeColor = Color.Gray;
                    lblStitched.ForeColor = Color.Gray;
                    lblStichedStartETA.ForeColor = Color.Gray;
                    lblStichedENDETA.ForeColor = Color.Gray;

                }
            }

            if (lblVAPercentInhouse != null)
            {
                // if (Convert.ToInt32(lblVAPercentInhouse.Text) >= 100)
                if (lblVAStartETA.Text != "" && lblVAENDETA.Text != "" && Convert.ToInt32(lblVAPercentInhouse.Text) >= 100)
                {
                    lblVAPercentInhouse.ForeColor = Color.Gray;
                    lvlVA.ForeColor = Color.Gray;
                    lblVAStartETA.ForeColor = Color.Gray;
                    lblVAENDETA.ForeColor = Color.Gray;

                }
            }

            if (lblPackedPercentInhouse != null)
            {
                //  if (Convert.ToInt32(lblPackedPercentInhouse.Text) >= 100 )
                if (lblPackedETA.Text != "" && Convert.ToInt32(lblPackedPercentInhouse.Text) >= 100)
                {
                    lblPackedPercentInhouse.ForeColor = Color.Gray;
                    lblPacked.ForeColor = Color.Gray;
                    lblPackedETA.ForeColor = Color.Gray;

                }
            }

            Repeater rptAccessories = e.Row.FindControl("rptAccessories") as Repeater;
            if (od.AccessoriesETA != null)
            {
                if (od.AccessoriesETA.Count > 0)
                {
                    rptAccessories.DataSource = od.AccessoriesETA;
                    rptAccessories.DataBind();

                }
            }


            if (Flag1 == "Stitched")
            {
                //if (Convert.ToInt32(lblStitchedPercentInhouse.Text) >= 100)
                if (Convert.ToInt32(lblStitchedPercentInhouse.Text) >= 1)
                {
                    //CheckHeader.Enabled = false;
                    //CheckHeader.Checked = false;
                    CheckCB.Visible = false;
                }
                tdStitched.Style.Add("background-color", "#FFFF00");
                tdStitchedPercentInhouse.Style.Add("background-color", "#FFFF00");
                tdStichedStartETA.Style.Add("background-color", "#FFFF00");
                tdStichedENDETA.Style.Add("background-color", "#FFFF00");

            }
            //added by abhishek on 6/10/2015
            if (Flag1 == "Cut Ready")
            {
                // if (Convert.ToInt32(lblCutPercentInhouse.Text) >= 100)
                //if (lblCutreadyStartETA.Text != "" && lblCutreadyENDETA.Text != "" && Convert.ToInt32(lblCutPercentInhouse.Text) >= 100)//abhishek commented this line
                if (Convert.ToInt32(lblCutPercentInhouse.Text) >= 1)
                {
                    //CheckHeader.Enabled = false;
                    //CheckHeader.Checked = false;
                    CheckCB.Visible = false;
                }
                tdCutReady.Style.Add("background-color", "#FFFF00");
                tdCutPercentInhouse.Style.Add("background-color", "#FFFF00");
                tdCutreadyStartETA.Style.Add("background-color", "#FFFF00");
                tdCutreadyENDETA.Style.Add("background-color", "#FFFF00");
            }


            if (Flag1 == "Emb")
            {

                // if (Convert.ToInt32(lblVAPercentInhouse.Text) >= 100)
                //if (lblVAStartETA.Text != "" && lblVAENDETA.Text != "" && Convert.ToInt32(lblVAPercentInhouse.Text) >= 100)
                if (Convert.ToInt32(lblVAPercentInhouse.Text) >= 1)
                {
                    //CheckHeader.Enabled = false;
                    //CheckHeader.Checked = false;
                    CheckCB.Visible = false;
                }
                tdVA.Style.Add("background-color", "#FFFF00");
                tdVAPercentInhouse.Style.Add("background-color", "#FFFF00");
                tdVAStartETA.Style.Add("background-color", "#FFFF00");
                tdVAENDETA.Style.Add("background-color", "#FFFF00");

            }
            //end by abhishek on 6/10/2015

            if (Flag1 == "Packed")
            {
                //if (Convert.ToInt32(lblPackedPercentInhouse.Text) >= 100)
                if (Convert.ToInt32(lblPackedPercentInhouse.Text) >= 1)
                {
                    //CheckHeader.Enabled = false;
                    //CheckHeader.Checked = false;
                    CheckCB.Visible = false;
                }
                tdlPacked.Style.Add("background-color", "#FFFF00");
                tdPackedPercentInhouse.Style.Add("background-color", "#FFFF00");
                tdPackedETA.Style.Add("background-color", "#FFFF00");
            }



            if (Flag2 == "Fab1")
            {

                // if (Convert.ToInt32(Fabric1Percent.Text) >= 100)
                if (lblFabricStartETAdate1.Text != "" && lblFabricEndETAdate1.Text != "" && Convert.ToInt32(Fabric1Percent.Text) >= 100)
                {
                    //CheckHeader.Enabled = false;
                    //CheckHeader.Checked = false;
                    CheckCB.Visible = false;
                }
                tdFabric1.Style.Add("background-color", "#FFFF00");
                tdprint1.Style.Add("background-color", "#FFFF00");
                tdFabric1DetailsRef.Style.Add("background-color", "#FFFF00");
                tdFabricStartETAdate1.Style.Add("background-color", "#FFFF00");
                tdFabricEndETAdate1.Style.Add("background-color", "#FFFF00");

            }


            if (Flag2 == "Fab2")
            {
                //if (Convert.ToInt32(Fabric2Percent.Text) >= 100)
                if (lblFabricStartETAdate2.Text != "" && lblFabricEndETAdate2.Text != "" && Convert.ToInt32(Fabric2Percent.Text) >= 100)
                {
                    //CheckHeader.Enabled = false;
                    //CheckHeader.Checked = false;
                    CheckCB.Visible = false;
                }
                tdFabric2.Style.Add("background-color", "#FFFF00");
                tdFabric2Percent.Style.Add("background-color", "#FFFF00");
                tdFabric2DetailsRef.Style.Add("background-color", "#FFFF00");
                tdFabricStartETAdate2.Style.Add("background-color", "#FFFF00");
                tdFabricEndETAdate2.Style.Add("background-color", "#FFFF00");
            }


            if (Flag2 == "Fab3")
            {
                // if (Convert.ToInt32(Fabric3Percent.Text) >= 100)
                if (lblFabricStartETAdate3.Text != "" && lblFabricEndETAdate3.Text != "" && Convert.ToInt32(Fabric3Percent.Text) >= 100)
                {
                    //CheckHeader.Enabled = false;
                    //CheckHeader.Checked = false;
                    CheckCB.Visible = false;
                }
                tdFabric3.Style.Add("background-color", "#FFFF00");
                tdFabric3Percent.Style.Add("background-color", "#FFFF00");
                tdFabric3DetailsRef.Style.Add("background-color", "#FFFF00");
                tdFabricStartETAdate3.Style.Add("background-color", "#FFFF00");
                tdFabricEndETAdate3.Style.Add("background-color", "#FFFF00");
            }


            if (Flag2 == "Fab4")
            {
                //if (Convert.ToInt32(Fabric4Percent.Text) >= 100)
                if (lblFabricStartETAdate4.Text != "" && lblFabricEndETAdate4.Text != "" && Convert.ToInt32(Fabric4Percent.Text) >= 100)
                {
                    //CheckHeader.Enabled = false;
                    //CheckHeader.Checked = false;
                    CheckCB.Visible = false;
                }
                tdFabric4Percent.Style.Add("background-color", "#FFFF00");
                tdFabric4DetailsRef.Style.Add("background-color", "#FFFF00");
                tdFabricStartETAdate4.Style.Add("background-color", "#FFFF00");
                tdFabricEndETAdate4.Style.Add("background-color", "#FFFF00");

            }
            if (Flag1 == "STCRequest")
            {
                tdstc.Style.Add("background-color", "#FFFF00");
                tdLabel6.Style.Add("background-color", "#FFFF00");

            }
            if (Flag1 == "PatternETA")
            {
                tdPatternSample.Style.Add("background-color", "#FFFF00");
                tdPatternETA.Style.Add("background-color", "#FFFF00");

            }
            if (Flag1 == "TOPETA")
            {
                tdtop.Style.Add("background-color", "#FFFF00");
                tdTOPETA.Style.Add("background-color", "#FFFF00");
                CheckCB.Visible = true;


            }



        }

        protected void rptAccessories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string OrderDetailsID = (DataBinder.Eval(e.Item.DataItem, "OrderDetailsID").ToString());
                string AccessoriesName = (DataBinder.Eval(e.Item.DataItem, "AccessoriesName").ToString());


                Label lblAccessories = (Label)e.Item.FindControl("lblAccessories");
                Label lblPercentInHouse = (Label)e.Item.FindControl("lblPercentInHouse");
                Label lblAccessoriesETA = (Label)e.Item.FindControl("lblAccessoriesETA");
                Label txtQuantityAvail = (Label)e.Item.FindControl("txtQuantityAvail");
                Label txtRequired = (Label)e.Item.FindControl("txtRequired");

                HtmlGenericControl divAccessoriesName = (HtmlGenericControl)e.Item.FindControl("divAccessoriesName");
                HtmlGenericControl divpercentInHouse = (HtmlGenericControl)e.Item.FindControl("divpercentInHouse");
                HtmlGenericControl divAccesoriesETA = (HtmlGenericControl)e.Item.FindControl("divAccesoriesETA");
                HtmlGenericControl divQuantityAvail = (HtmlGenericControl)e.Item.FindControl("divQuantityAvail");
                HtmlGenericControl divRequired = (HtmlGenericControl)e.Item.FindControl("divRequired");

                if (divAccessoriesName != null)
                {
                    // if (Convert.ToInt32(lblPercentInHouse.Text) >= 100)
                    if (lblAccessoriesETA.Text != "" && Convert.ToInt32(lblPercentInHouse.Text) >= 100)
                    {
                        lblAccessories.ForeColor = Color.Gray;
                        lblPercentInHouse.ForeColor = Color.Gray;
                        lblAccessoriesETA.ForeColor = Color.Gray;
                        txtQuantityAvail.ForeColor = Color.Gray;
                        txtRequired.ForeColor = Color.Gray;
                    }

                }


                //Repeater chrow = (Repeater)GridView2.Parent.Parent;
                HiddenField hdnRemark = (HiddenField)e.Item.FindControl("hdnRemark");

                CheckBox CheckHeader = e.Item.Parent.Parent.FindControl("cb") as CheckBox;
                HiddenField hdnOrderDetailsID = (HiddenField)e.Item.Parent.Parent.FindControl("hdnOrderDetailsID");

                if (Flag1 == "Access")
                {
                    if (lblAccessories.Text == Val1)
                    {
                        // if (Convert.ToInt32(lblPercentInHouse.Text) >= 100)
                        if (OrderDetailId == Convert.ToInt32(hdnOrderDetailsID.Value))
                        {
                            if (hdnRemark != null)
                            {
                                if (hdnRemark.Value != "")
                                {
                                    strAccessRemrak = hdnRemark.Value;
                                }
                            }
                        }
                        if (lblAccessoriesETA.Text != "" && Convert.ToInt32(lblPercentInHouse.Text) >= 100)
                        {
                            CheckHeader.Visible = false;
                        }

                        divAccessoriesName.Style.Add("background-color", "#FFFF00");
                        divpercentInHouse.Style.Add("background-color", "#FFFF00");
                        divQuantityAvail.Style.Add("background-color", "#FFFF00");
                        divRequired.Style.Add("background-color", "#FFFF00");
                        divAccesoriesETA.Style.Add("background-color", "#FFFF00");
                        // lblAccessories.ForeColor = Color.Yellow;
                    }
                }


            }
        }

        protected void btnAccess_Click(object sender, EventArgs e)
        {
            //Val1 = Val1.Replace("and", "&");
            Val1 = Val1.Replace("and", "&").Replace("hx", "#");
            bool ibool = false;
            bool iCheckETAbool = false;
            OrderDetail.AccessoriesDetailsETA oda = new OrderDetail.AccessoriesDetailsETA();
            string str = txtremarks.Text.Trim(); ;
            string strMassage = str.Replace("\\s", "");

            string userName = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            string dateToday = DateTime.Today.ToString("dd MMM yy (ddd)");
            string NewRemarks = strMassage;
            int Isanycheck_true = 0;

            if (NewRemarks.Trim() != string.Empty)
            {
                NewRemarks = "Accessories ETA" + " : " + userName + " " + "(" + dateToday + ")" + " " + Val1 + " " + "BIH End (" + lblBIHEnd.Text.Trim() + ") " + " : " + strMassage + " ";
            }
            else
            {
                NewRemarks = string.Empty;
            }
            DateTime ETANdate;

            //ETASDate = DateTime.ParseExact(lblBIHStart.Text.Trim(), "dd MMM yy (ddd)", null);
            if (lblBIHEnd.Text == "")
            {
                iCheckETAbool = true;
            }
            else
            {
                ETANdate = DateTime.ParseExact(lblBIHEnd.Text.Trim(), "dd MMM yy (ddd)", null);

                foreach (GridViewRow gvr in gvNew.Rows)
                {

                    if (((CheckBox)gvr.FindControl("cb")).Checked)
                    {
                        CheckBox cb = (CheckBox)gvr.FindControl("cb");
                        if (cb.Visible)
                        {
                            Isanycheck_true = Isanycheck_true + 1;
                        }
                        HiddenField hdnOrderDetailsID = (HiddenField)gvr.FindControl("hdnOrderDetailsID");
                        if (hdnOrderDetailsID != null)
                        {
                            oda.OrderDetailsID = Convert.ToInt32(hdnOrderDetailsID.Value);
                        }

                        Repeater rptAccessories = gvr.FindControl("rptAccessories") as Repeater;

                        foreach (RepeaterItem item in rptAccessories.Items)
                        {
                            Label lblAccessories = (Label)item.FindControl("lblAccessories");
                            TextBox txtAccessoryWorkingDetailID = (TextBox)item.FindControl("txtAccessoryWorkingDetailID");
                            Label txtQuantityAvail = (Label)item.FindControl("txtQuantityAvail");
                            if (lblAccessories.Text == Val1)
                            {
                                if (txtAccessoryWorkingDetailID.Text != "")
                                {
                                    oda.AccessoryWorkingDetailID = Convert.ToInt32(txtAccessoryWorkingDetailID.Text);
                                }
                                if (txtQuantityAvail.Text != "")
                                {
                                    oda.QuantityAvail = txtQuantityAvail.Text;
                                }
                            }
                        }

                        ibool = this.OrderControllerInstance.UpdateAccessEtaRemarks(NewRemarks, Val1, oda.OrderDetailsID, ETANdate.ToString(), AccworkingId.ToString(), oda.QuantityAvail);

                    }
                }

            }
            if (iCheckETAbool == true)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "CloseWindow", "alert('Please Input ETA');", true);
            }
            if (Isanycheck_true == 0)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "CloseWindow", "alert('Please select atleast one contract');", true);
            }
            if (ibool == true)
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "CloseWindow", "CloseWindow();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "CloseWindow", "alert('Some error occured while saving');", true);
            }

        }


        //added by abhishek on 25/12/2015
        public void BindFabricETAStatus(string Flag, int OrderDetailsId)
        {
            string StrPrintQtyAppDate = string.Empty;
            string StrFabricAppDate = string.Empty;
            string StrIntialAppDat = string.Empty;
            string StrBulkAppDate = string.Empty;

            string StrPrintQtyApp_status = string.Empty;
            string StrFabricApp_status = string.Empty;
            string StrIntialApp_status = string.Empty;
            string StrBulkApp_status = string.Empty;


            DataSet ds = new DataSet();
            ds = this.OrderControllerInstance.GetMoFabricETA_Status(Flag, OrderDetailsId);
          if (ds.Tables.Count > 0)
          {
            DataTable dt = ds.Tables[0];
           
                foreach (DataRow row in dt.Rows)
                {
                    object value1 = row[0];
                    object value2 = row[1];
                    object value3 = row[2];
                    object value4 = row[3];
                    object value5 = row[4];
                    object value6 = row[5];
                    object value7 = row[6];
                    object value8 = row[7];

                    StrPrintQtyAppDate = value1 == DBNull.Value ? "" : Convert.ToDateTime(row[0].ToString()).ToString("dd MMM yy (ddd)");
                    StrFabricAppDate = value2 == DBNull.Value ? DateTime.Now.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(row[1].ToString()).ToString("dd MMM yy (ddd)");
                    StrIntialAppDat = value3 == DBNull.Value ? DateTime.Now.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(row[2].ToString()).ToString("dd MMM yy (ddd)");
                    StrBulkAppDate = value4 == DBNull.Value ? DateTime.Now.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(row[3].ToString()).ToString("dd MMM yy (ddd)");

                    //StrPrintQtyApp_status = value5 == DBNull.Value ? "true" : Convert.ToDateTime(row[4].ToString()).ToString("dd MMM yy (ddd)");
                    StrFabricApp_status = value6 == DBNull.Value ? "" : (row[5].ToString() == "1" ? "Sent for approval" : row[5].ToString() == "2" ? "Approved" : row[5].ToString() == "3" ? "Rejected" : "");
                    StrIntialApp_status = value7 == DBNull.Value ? "" : (row[6].ToString() == "1" ? "Sent for approval" : row[6].ToString() == "2" ? "Approved" : row[6].ToString() == "3" ? "Rejected" : "");
                    StrBulkApp_status = value8 == DBNull.Value ? "" : (row[7].ToString() == "1" ? "Sent for approval" : row[7].ToString() == "2" ? "Approved" : row[7].ToString() == "3" ? "Rejected" : "");


                    lblprintReveddate.Text = StrPrintQtyAppDate;

                    lblQntyAprddate.Text = StrFabricAppDate;
                    SpnFabricQntyApp.Text = StrFabricApp_status;

                    lblInitialdate.Text = StrIntialAppDat;
                    SpnInitialApp.Text = StrIntialApp_status;


                    lblBulkdate.Text = StrFabricAppDate;
                    SpnBulkApp.Text = StrBulkApp_status;





                }
            }
        }

        //end by abhishek on 25/12/2015
    }
}