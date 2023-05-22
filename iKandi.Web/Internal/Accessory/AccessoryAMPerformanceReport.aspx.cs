using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.Common;
using iKandi.BLL;

namespace iKandi.Web.Internal.Accessory
{
    public partial class AccessoryAMPerformanceReport : System.Web.UI.Page
    {
        public int AccworkingWorkingDetailID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["AccworkingWorkingDetailID"]))
                {
                    return Convert.ToInt32(Request.QueryString["AccworkingWorkingDetailID"]);
                }
                return -1;
            }
        }
        public int OrderDetailId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["OrderDetailId"]))
                {
                    return Convert.ToInt32(Request.QueryString["OrderDetailId"]);
                }
                return -1;
            }
        }
        public string AccessoryName
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["AccessoryName"]))
                {
                    return Request.QueryString["AccessoryName"].ToString();
                }
                return "";
            }
        }
        public string Size
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Size"]))
                {
                    return Request.QueryString["Size"].ToString();
                }
                return "";
            }
        }
        public string ColorPrint
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ColorPrint"]))
                {
                    return Request.QueryString["ColorPrint"].ToString();
                }
                return "";
            }
        }

        AccessoryWorkingController objAccessoryController = new AccessoryWorkingController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            if (!IsPostBack)
                BindData();
        }

        private void BindData()
        {
            string PO_Type = "";

            string Accessory = "";
            if (Size != "")
                Accessory = AccessoryName + " <span style='color:gray'>(" + Size + ")</span>";
            else
                Accessory = AccessoryName;

            Accessory = "<span style='color:blue'>" + Accessory + "</span> <span style='color:#000;font-weight:600'>" + ColorPrint + "</span>";

            DataSet ds = objAccessoryController.GetAccessory_AMPerformanceReport(AccworkingWorkingDetailID, OrderDetailId);
            DataTable dtGetFinished = ds.Tables[0];
            DataTable dtPOType = ds.Tables[1];
            int columnHeader = dtGetFinished.Columns.Count - 2;

            PO_Type = Convert.ToString(dtPOType.Rows[0]["Po_Type"]);
            if (dtGetFinished.Rows.Count > 0)
            {
                if (PO_Type == "")
                {
                    grdFinish.DataSource = dtGetFinished;
                    grdFinish.DataBind();
                    grdFinish.HeaderRow.Cells[0].Text = Accessory;
                }
                if (PO_Type == "Finished" || PO_Type == "Griege")
                {
                    grdFinish.DataSource = dtGetFinished;
                    grdFinish.DataBind();
                    if (PO_Type == "Finished")
                        grdFinish.HeaderRow.Cells[1].Text = "Finished";
                    else
                        grdFinish.HeaderRow.Cells[1].Text = "Greige";

                    grdFinish.HeaderRow.Cells[0].Text = Accessory;

                    for (int i = 0; i < grdFinish.Rows.Count; i++)
                    {
                        Label lblFinishount = (Label)grdFinish.Rows[i].Cells[1].FindControl("lblFinishValue");
                        if (lblFinishount.Text != "")
                        {
                            string str1 = "";
                            string str2 = "";
                            string[] strArr = lblFinishount.Text.Split('{');
                            str1 = strArr[0].ToString();
                            if (strArr.Length > 1)
                            {
                                str2 = lblFinishount.Text.Split('{')[1].ToString();
                                if (str2 == "<span>0</span>)")
                                {
                                    lblFinishount.Text = str1;
                                }
                                else
                                {
                                    lblFinishount.Text = str1 + " (" + str2;
                                    lblFinishount.Text = lblFinishount.Text.Replace("{", "(").Replace("}", ")");
                                }
                            }
                            else
                            {
                                lblFinishount.Text = str1;
                            }
                        }

                        Label lblTitle = (Label)grdFinish.Rows[i].Cells[0].FindControl("lblTitle");
                        if (lblTitle.Text == "Stock Moved Qty")
                        {
                            grdFinish.Rows[i].Style.Add("background-color", "#FFFF99");
                        }

                        //if (i == 3)
                        //{

                        //    Label lblFinishValue = (Label)grdFinish.Rows[i].Cells[1].FindControl("lblFinishValue");
                        //    if (lblFinishValue.Text != "")
                        //    {
                        //        if (lblFinishValue.Text != "0")
                        //        {
                        //            lblFinishValue.Text = lblFinishValue.Text + "%";
                        //        }
                        //        else
                        //        {
                        //            lblFinishValue.Text = "";
                        //        }
                        //    }
                        //}
                    }
                }

                if (PO_Type == "Griege_Print" || PO_Type == "Griege_Dyed")
                {
                    grdGriegePrintDyed.DataSource = dtGetFinished;
                    grdGriegePrintDyed.DataBind();

                    if (PO_Type == "Griege_Print")
                        grdGriegePrintDyed.Columns[2].HeaderText = "Process";
                    else
                        grdGriegePrintDyed.Columns[2].HeaderText = "Dyed";

                    grdGriegePrintDyed.HeaderRow.Cells[0].Text = Accessory;
                    //grdGriegePrintDyed.Rows[0].Cells[1].Attributes.Add("colspan", "2");
                    grdGriegePrintDyed.Rows[5].Cells[1].Attributes.Add("colspan", "2");
                    grdGriegePrintDyed.Rows[5].Cells[2].Visible = false;


                    //grdGriegePrintDyed.Rows[0].Cells[2].Visible = false;
                  //  grdGriegePrintDyed.Rows[5].Cells[1].Attributes.Add("colspan", "1");
                   // grdGriegePrintDyed.Rows[5].Cells[2].Visible = false;
                    //Add code by Bharat On 4-6-20   
                    //for (int i = 0; i < grdGriegePrintDyed.Rows.Count; i++)
                    //{
                    //    Label lblGriegeProcess = (Label)grdGriegePrintDyed.Rows[i].Cells[2].FindControl("lblGriegePrint");
                    //    Label lblGriegeCount = (Label)grdGriegePrintDyed.Rows[i].Cells[1].FindControl("lblGriege");
                    //    if (lblGriegeCount.Text != "")
                    //    {
                    //        string str1 = "";
                    //        string str2 = "";
                    //        string[] strArr = lblGriegeCount.Text.Split('(');
                    //        str1 = strArr[0].ToString();
                    //        if (strArr.Length > 1)
                    //        {
                    //            str2 = lblGriegeCount.Text.Split('(')[1].ToString();
                    //            if (str2 == "<span>0</span>)")
                    //            {
                    //                lblGriegeCount.Text = str1;
                    //            }
                    //            else
                    //            {
                    //                lblGriegeCount.Text = str1 + " (" + str2;
                    //                lblGriegeCount.Text = lblGriegeCount.Text.Replace("{", "(").Replace("}", ")");
                    //            }
                    //        }
                    //        else
                    //        {
                    //            lblGriegeCount.Text = str1;
                    //        }

                    //    }
                    //    if (lblGriegeProcess.Text != "")
                    //    {
                    //        string str1 = "";
                    //        string str2 = "";
                    //        string[] strArr = lblGriegeProcess.Text.Split('(');
                    //        str1 = strArr[0].ToString();
                    //        if (strArr.Length > 1)
                    //        {
                    //            str2 = lblGriegeProcess.Text.Split('(')[1].ToString();
                    //            if (str2 == "<span>0</span>)")
                    //            {
                    //                lblGriegeProcess.Text = str1;
                    //            }
                    //            else
                    //            {
                    //                lblGriegeProcess.Text = str1 + " (" + str2;
                    //                lblGriegeProcess.Text = lblGriegeProcess.Text.Replace("{", "(").Replace("}", ")");
                    //            }
                    //        }
                    //        else
                    //        {
                    //            lblGriegeProcess.Text = str1;
                    //        }

                    //    }

                        //if (i == 3)
                        //{
                        //    Label lblGriegePrint = (Label)grdGriegePrintDyed.Rows[i].Cells[2].FindControl("lblGriegePrint");
                        //    Label lblGriege = (Label)grdGriegePrintDyed.Rows[i].Cells[1].FindControl("lblGriege");
                        //    if (lblGriege.Text != "")
                        //    {
                        //        if (lblGriege.Text != "0")
                        //        {
                        //            lblGriege.Text = lblGriege.Text + "%";
                        //        }
                        //        else
                        //        {
                        //            lblGriege.Text = "";
                        //        }
                        //    }

                        //    if (lblGriegePrint.Text != "")
                        //    {
                        //        if (lblGriegePrint.Text != "")
                        //        {
                        //            lblGriegePrint.Text = lblGriegePrint.Text + "%";
                        //        }
                        //        else
                        //        {
                        //            lblGriegePrint.Text = "";
                        //        }
                        //    }

                        //}

                    //}
                    //end

                }

            }

        }

    }
}