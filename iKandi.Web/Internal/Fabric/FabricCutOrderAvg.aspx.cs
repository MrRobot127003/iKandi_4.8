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
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace iKandi.Web.Internal.Fabric
{
    public partial class FabricCutOrderAvg : System.Web.UI.Page
    {

        FabricController objfabric = new FabricController();
        AccessoryWorkingController objwc = new AccessoryWorkingController();
        WorkflowController WorkflowControllerInstance = new WorkflowController();
        AccessoryQualityController objacc = new AccessoryQualityController();

        String ProductionFolderPath = "~/" + System.Configuration.ConfigurationManager.AppSettings["photo.folder"];

        public static int OrderID
        {
            get;
            set;
        }
        public static int FabQualityID
        {
            get;
            set;
        }
        public static string FabDetails
        {
            get;
            set;
        }
        public static int OrderDetailID
        {
            get;
            set;
        }
        public static int FabCount
        {
            get;
            set;
        }
        public static int OrderTabCloseDetailID
        {
            get;
            set;
        }
        public static int TaskStatus
        {
            get;
            set;
        }
        public static string Alltexthistory
        {
            get;
            set;
        }
        //public static string SerialNumber
        //{
        //    get;
        //    set;
        //}

        static bool IsAvgChecked;

        static bool IsPageRefresh;
        protected void Page_Load(object sender, EventArgs e)
        {
            IsPageRefresh = false;
            if (!Page.IsPostBack)
            {
                GetQueryString();
                BindGrid();
                Bindalloptiongrd();

                ViewState["postGuids"] = System.Guid.NewGuid().ToString();
                Session["postGuid"] = ViewState["postGuids"].ToString();
            }
            else
            {
                if (ViewState["postGuids"].ToString() != Session["postGuid"].ToString())
                {
                    IsPageRefresh = true;
                    BindGrid();
                }
                Session["postGuid"] = System.Guid.NewGuid().ToString();
                ViewState["postGuids"] = Session["postGuid"].ToString();
            }

            // lblHistory.Text = Alltexthistory;
        }
        public void GetQueryString()
        {
            if (Request.QueryString["OrderID"] != null)
                OrderID = Convert.ToInt32(Request.QueryString["OrderID"]);
            else
            {
                //OrderID = 7182; //1fab
                //OrderID = 9063; //4feb                 
                OrderID = -1;
                //OrderID = 8983; //2feb
                //SerialNumber = string.IsNullOrEmpty(Request.QueryString["SerialNumber"]) ? "" : Request.QueryString["SerialNumber"].ToString();
            }
            if (Request.QueryString["OrderDetailID"] != null)
                OrderDetailID = Convert.ToInt32(Request.QueryString["OrderDetailID"]);
            else
                OrderDetailID = -1;

            if (Request.QueryString["FabQualityID"] != null)
                FabQualityID = Convert.ToInt32(Request.QueryString["FabQualityID"]);
            else
                FabQualityID = -1;

            if (Request.QueryString["FabDetails"] != null)
                FabDetails = Request.QueryString["FabDetails"].ToString();
            else
                FabDetails = null;
            if (Request.QueryString["TaskStatus"] != null)
            {
                TaskStatus = Convert.ToInt32(Request.QueryString["TaskStatus"]);
            }
            else
            {
                TaskStatus = -1;
            }

            hdnorderTabClose.Value = TaskStatus.ToString();
            hdnOrderID.Value = OrderID.ToString();
            hdnUserId.Value = ApplicationHelper.LoggedInUser.UserData.UserID.ToString();

        }
        public DateTime GetFirstDateFromString(string input)
        {

            DateTime dateTime = DateTime.Now;

            if (!string.IsNullOrEmpty(input))
            {
                dateTime = DateTime.ParseExact(input, "dd MMM yy (ddd) h:mm:ss tt", CultureInfo.CurrentCulture);

            }
            return dateTime;
        }

        public string bidh(string txt)
        {
            string finalhistorytext = "";         
            string[] sdsd = txt.Split(new string[] { "<br>" }, StringSplitOptions.RemoveEmptyEntries);

            //  DateTime sss = GetFirstDateFromString(sdsd[0]);

            DataTable dts = new DataTable();
            dts.Clear();
            dts.Columns.Add("date", typeof(DateTime));
            dts.Columns.Add("name", typeof(string));
            foreach (string s in sdsd)
            {
                string[] g = s.Split(new string[] { "$$" }, StringSplitOptions.RemoveEmptyEntries);

                //string date = s.Substring(28, 15);
                //DateTime datet = GetFirstDateFromString(date);
                DataRow _filter = dts.NewRow();
                _filter["name"] = g[0];
                if (g.Length == 2)
                {

                   // _filter["date"] = DateTime.ParseExact(g[1], "dd MMM yy (ddd) h:mm:ss tt", CultureInfo.CurrentCulture);
                    _filter["date"] = Convert.ToDateTime(g[1], CultureInfo.InvariantCulture);
                }

                dts.Rows.Add(_filter);
            }



            string strSort = "date DESC";

            DataView dtview = new DataView(dts);
            dtview.Sort = strSort;
            DataTable dtsorted = dtview.ToTable();

            // lblHistory.Text = "";
            foreach (DataRow re in dtsorted.Rows)
            {
                finalhistorytext = finalhistorytext + "<ul style='margin-top:1px;'><li>" + re[1].ToString() + "</li></ul>";
            }
            return finalhistorytext;
        }
        public void BindGrid()
        {
            DataTable dt = objfabric.GetFabricCutOrderAvg(OrderID, 1, OrderDetailID, FabQualityID, FabDetails);
            if (dt.Rows.Count > 0)
            {

                //foreach (DataRow row in dt.Rows)
                //{
                //    lblHistory.Text += dt.Rows[0]["TextHistory"] == DBNull.Value ? "" : dt.Rows[0]["TextHistory"].ToString().Replace("###", "<br>");
                //    //lblHistory.Text = '</br>';

                //}

                IsAvgChecked = dt.Rows[0]["IsApprovedAMForFabric"] == DBNull.Value ? false : Convert.ToBoolean(dt.Rows[0]["IsApprovedAMForFabric"]);
                chkboxAccountMgr.Checked = IsAvgChecked;
                if (chkboxAccountMgr.Checked)
                {
                    chkboxAccountMgr.Enabled = false;
                    //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                    //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
                }

                FabCount = dt.Rows[0]["FabricCount"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["FabricCount"]);
                hdnFabricCount.Value = FabCount.ToString();
                grdcutavg.DataSource = dt;
                grdcutavg.DataBind();
                ManageFabric();
                if (chkboxAccountMgr.Checked)
                {
                    lnkHistory.Visible = lblHistory.Text == "" ? false : true;
                }
                else
                {
                    lnkHistory.Visible = false;
                }
                string[] sdsd = lblHistory.Text.Split(new string[] { "<br>" }, StringSplitOptions.RemoveEmptyEntries);

                //  DateTime sss = GetFirstDateFromString(sdsd[0]);

                DataTable dts = new DataTable();
                dts.Clear();
                dts.Columns.Add("date", typeof(DateTime));
                dts.Columns.Add("name", typeof(string));
                foreach (string s in sdsd)
                {
                    string[] g = s.Split(new string[] { "$$" }, StringSplitOptions.RemoveEmptyEntries);

                    //string date = s.Substring(28, 15);
                    //DateTime datet = GetFirstDateFromString(date);
                    DataRow _filter = dts.NewRow();
                    _filter["name"] = g[0];
                    if (g.Length == 2)
                    {
                        _filter["date"] = Convert.ToDateTime(g[1],CultureInfo.InvariantCulture);
                    }

                    dts.Rows.Add(_filter);
                }



                string strSort = "date DESC";

                DataView dtview = new DataView(dts);
                dtview.Sort = strSort;
                DataTable dtsorted = dtview.ToTable();

                lblHistory.Text = "";
                foreach (DataRow re in dtsorted.Rows)
                {
                    lblHistory.Text = lblHistory.Text + "<ul style='margin-top:1px;'><li>" + re[1].ToString() + "</li></ul>";
                }



            }
            else
            {
                grdcutavg.DataSource = new string[] { };
            }

            if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_DETAIL_AVG_CHECKED))
            {
                //if (chkboxAccountMgr.Checked)
                chkboxAccountMgr.Enabled = false;
                //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
            }
            //else
            //{
            //    if (chkboxAccountMgr.Checked)
            //    {
            //        chkboxAccountMgr.Enabled = false;
            //    }
            //    else
            //    {
            //        chkboxAccountMgr.Enabled = true;
            //    }
            //}
        }

        public void Bindalloptiongrd()
        {
            DataTable DtOrderDetails = new DataTable();
            DataSet ds = new DataSet();
            DataTable dtsizeoptioncount = new DataTable();

            ds = objacc.GetAccessoryOrderSizedeatils("1", OrderID, "");

            DtOrderDetails = ds.Tables[2];
            lblacname.Text = DtOrderDetails.Rows[0]["AcName"].ToString();
            lblserialno.Text = DtOrderDetails.Rows[0]["serialno"].ToString();
            lblstylenumber.Text = DtOrderDetails.Rows[0]["stylenumber"].ToString();
        }

        protected void grdcutavg_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = grdcutavg.Rows[grdcutavg.SelectedIndex];
            FileUpload uploderavgfile1 = (FileUpload)row.FindControl("uploderavgfile1");
        }

        protected void Upload(object sender, EventArgs e)
        {

            //SaveData();

        }
        public void SaveData()
        {
            try
            {
                int Isave = 0;

                foreach (GridViewRow rows in grdcutavg.Rows)
                {
                    HiddenField hdnOderDetailIDBase = (HiddenField)rows.FindControl("hdnOderDetailID");
                    int OrderDetailId = Convert.ToInt32(hdnOderDetailIDBase.Value.Split(',')[0]);

                    bool OrderAvgExistInAllFabric = true;

                    for (int i = 1; i <= FabCount; i++)
                    {
                        string strhistory = "";
                        decimal CutAvgVal = 0;
                        string cutAvgfiles = "";

                        decimal OrderAvgVal = 0;
                        decimal OrderWidthValue = 0;
                        decimal CostWidthValue = 0;
                        decimal CutWidthValue = 0;
                        string OrderAvgFile = "";
                        int CutAVgunit = 0;


                        HiddenField hdnOderDetailID = (HiddenField)rows.FindControl("hdnOderDetailID" + i.ToString());
                        DataTable dthistory = objfabric.GetFabricAvg(Convert.ToInt32(hdnOderDetailID.Value), 2, i).Tables[0];
                        TextBox txtorderavg = (TextBox)rows.FindControl("txtorderavg" + i.ToString());

                        //TextBox txtorderavg = (TextBox)grdcutavg.HeaderRow.Cells[0].FindControl("txtorderavg" + i.ToString());

                        FileUpload uploderavgfile = (FileUpload)grdcutavg.HeaderRow.Cells[0].FindControl("uploderavgfile" + i.ToString());

                        DropDownList ddlcutAvg_Unit = (DropDownList)grdcutavg.HeaderRow.Cells[0].FindControl("ddlcutAvg_Unit" + i.ToString());

                        TextBox txtcutavg = (TextBox)rows.FindControl("txtcutavg" + i.ToString());
                        FileUpload cutAvgfile = (FileUpload)rows.FindControl("cutAvgfile" + i.ToString());

                        HiddenField hdnCostingID = (HiddenField)rows.FindControl("hdnCostingID" + i.ToString());
                        TextBox txtCostWidth = (TextBox)rows.FindControl("txtCostWidth" + i.ToString());
                        TextBox txtOrderWidth = (TextBox)rows.FindControl("txtOrderWidth" + i.ToString());
                        TextBox txtCutWidth = (TextBox)rows.FindControl("txtCutWidth" + i.ToString());

                        Label lblContactNo = (Label)rows.FindControl("lblContactNo");
                        HiddenField hdncc = (HiddenField)rows.FindControl("hdncc");

                        string cc = lblContactNo.Text;
                        //if (lblContactNo.Text.Length > 14)
                        //{

                        //}

                        OrderAvgVal = (string.IsNullOrEmpty(txtorderavg.Text) ? 0 : Convert.ToDecimal(txtorderavg.Text));
                        if (OrderAvgVal == 0)
                            OrderAvgExistInAllFabric = false;

                        CutAvgVal = (string.IsNullOrEmpty(txtcutavg.Text) ? 0 : Convert.ToDecimal(txtcutavg.Text));

                        OrderWidthValue = (string.IsNullOrEmpty(txtOrderWidth.Text) ? 0 : Convert.ToDecimal(txtOrderWidth.Text));
                        CostWidthValue = (string.IsNullOrEmpty(txtCostWidth.Text) ? 0 : Convert.ToDecimal(txtCostWidth.Text));
                        CutWidthValue = (string.IsNullOrEmpty(txtCutWidth.Text) ? 0 : Convert.ToDecimal(txtCutWidth.Text));
                        //added by abhishek on 21 oct 2020
                        Label lblFabricName = grdcutavg.HeaderRow.Cells[i + 1].FindControl("lblFabricName" + i) as Label;
                        Label lblCCgsm = grdcutavg.HeaderRow.Cells[i + 1].FindControl("lblCCgsm" + i) as Label;
                        CutAVgunit = Convert.ToInt32(ddlcutAvg_Unit.SelectedValue);
                        if (lblFabricName != null)
                        {
                            //string one = DateTime
                            //string two = "2:35:10 PM";

                            //DateTime dt = Convert.ToDateTime(one + " " + two);
                            //DateTime dt1 = DateTime.ParseExact(one + " " + two, "dd/MM/yy h:mm:ss tt", CultureInfo.InvariantCulture);

                            string todaydate = DateTime.Now.ToString("dd MMM yy (ddd)");
                            string username = ApplicationHelper.LoggedInUser.UserData.FirstName + ' ' + ApplicationHelper.LoggedInUser.UserData.LastName;
                            if (IsAvgChecked)
                            {
                                if (dthistory.Rows.Count > 0)
                                {
                                    if (OrderAvgVal.ToString() != dthistory.Rows[0]["OrderAvg"].ToString())
                                    {
                                        //strhistory = strhistory + "###" + "<span style='color:#7d7c7c'>" + todaydate + "</span>" + " " + "<b>" + "Order Avg." + "</b>" + " " + "<span style='color:#7d7c7c'>Changed by</span>" + " " + username + " " + "<span style='color:#197ec6'>" + txtorderavg.Text + "</span>" + " " + "Was" + " " + dthistory.Rows[0]["OrderAvg"].ToString() + " <span style='color:#7d7c7c'>for contract</span>" + " " + hdncc.Value + " <span style='color:#7d7c7c'>and fabric</span> " + lblFabricName.Text + " (" + lblCCgsm.Text + ")" + "$$" + DateTime.Now;
                                        strhistory = strhistory + "###" + "<span style='color:#7d7c7c'>" + todaydate + "</span>" + " " + "<b>" + "Order Avg." + "</b>" + " " + "<span style='color:#7d7c7c'>Changed by</span>" + " " + username + " " + "<span style='color:#197ec6'>" + txtorderavg.Text + "</span>" + " " + "Was" + " " + dthistory.Rows[0]["OrderAvg"].ToString() + " <span style='color:#7d7c7c'>for contract</span>" + " " + hdncc.Value + " <span style='color:#7d7c7c'>and fabric</span> " + lblFabricName.Text + "$$" + DateTime.Now;
                                    }
                                    if (CutAvgVal.ToString() != dthistory.Rows[0]["CutAvg"].ToString())
                                    {
                                        strhistory = strhistory + "###" + "<span style='color:#7d7c7c'>" + todaydate + "</span>" + " " + "<b>" + "Cut Avg." + "</b>" + " " + "<span style='color:#7d7c7c'>Changed by</span>" + " " + username + " " + "<span style='color:#197ec6'>" + txtcutavg.Text + "</span>" + " " + "Was" + " " + dthistory.Rows[0]["CutAvg"].ToString() + " <span style='color:#7d7c7c'>for contract</span>" + " " + hdncc.Value + " <span style='color:#7d7c7c'>and fabric</span> " + lblFabricName.Text + "$$" + DateTime.Now;
                                    }
                                    if (CostWidthValue.ToString() != dthistory.Rows[0]["costwidth"].ToString())
                                    {
                                        strhistory = strhistory + "###" + "<span style='color:#7d7c7c'>" + todaydate + "</span>" + " " + "<b>" + "Cost Width." + "</b>" + " " + "<span style='color:#7d7c7c'>Changed by</span>" + " " + username + " " + "<span style='color:#197ec6'>" + txtCostWidth.Text + "</span>" + " " + "Was" + " " + dthistory.Rows[0]["costwidth"].ToString() + " <span style='color:#7d7c7c'>for contract</span>" + " " + hdncc.Value + " <span style='color:#7d7c7c'>and fabric</span> " + lblFabricName.Text + "$$" + DateTime.Now;
                                    }
                                    if (OrderWidthValue.ToString() != dthistory.Rows[0]["OrderWidth"].ToString())
                                    {
                                        strhistory = strhistory + "###" + "<span style='color:#7d7c7c'>" + todaydate + "</span>" + " " + "<b>" + "Order Width." + "</b>" + " " + "<span style='color:#7d7c7c'>Changed by</span>" + " " + username + " " + "<span style='color:#197ec6'>" + txtOrderWidth.Text + "</span>" + " " + "Was" + " " + dthistory.Rows[0]["OrderWidth"].ToString() + " <span style='color:#7d7c7c'>for contract</span>" + " " + hdncc.Value + " <span style='color:#7d7c7c'>and fabric</span> " + lblFabricName.Text + "$$" + DateTime.Now;
                                    }
                                    if (ddlcutAvg_Unit.SelectedValue != dthistory.Rows[0]["Unit"].ToString())
                                    {
                                        int unit=Convert.ToInt32(dthistory.Rows[0]["Unit"].ToString());
      

                                        strhistory = strhistory + "###" + "<span style='color:#7d7c7c'>" + todaydate + "</span>" + " " + "<b>" + "Unit" + "</b>" + " " + "<span style='color:#7d7c7c'>Changed by</span>" + " " + username + " " + "<span style='color:#197ec6'>" + ddlcutAvg_Unit.SelectedItem.Text + "</span>" + " " + "Was" + " " + Enum.GetName(typeof(FabricUnit), Convert.ToInt32(dthistory.Rows[0]["Unit"].ToString())) + " <span style='color:#7d7c7c'>for contract</span>" + " " + hdncc.Value + " <span style='color:#7d7c7c'>and fabric</span> " + lblFabricName.Text + "$$" + DateTime.Now;
                                    }
                                    if (CutWidthValue.ToString() != dthistory.Rows[0]["CutWidth"].ToString())
                                    {
                                        strhistory = strhistory + "###" + "<span style='color:#7d7c7c'>" + todaydate + "</span>" + " " + "<b>" + "Cut Width." + "</b>" + " " + "<span style='color:#7d7c7c'>Changed by</span>" + " " + username + " " + "<span style='color:#197ec6'>" + txtCutWidth.Text + "</span>" + " " + "Was" + " " + dthistory.Rows[0]["CutWidth"].ToString() + " <span style='color:#7d7c7c'>for contract</span>" + " " + hdncc.Value + " <span style='color:#7d7c7c'>and fabric</span> " + lblFabricName.Text + "$$" + DateTime.Now;
                                    }

                                }
                            }
                        }
                        //end
                        DateTime dt = DateTime.Now;
                        string s = String.Format("{0:G}", dt);
                        s = s.Replace(" ", "_");
                        s = s.Replace(':', '/');
                        s = s.Replace('/', '-');
                        string Fabric = "Fabric" + i.ToString();


                        if (uploderavgfile.HasFile)
                        {
                            string Exten = System.IO.Path.GetExtension(uploderavgfile.FileName);
                            string ActualfileName = Fabric + "_Odr_" + s + "_" + uploderavgfile.FileName;
                            string Name = ActualfileName.Substring(0, ActualfileName.LastIndexOf('.'));
                            OrderAvgFile = FileHelper.SaveFile(uploderavgfile.PostedFile.InputStream, uploderavgfile.FileName, Constants.PHOTO_FOLDER_PATH, true, Name);

                            //OrderAvgFile = FileHelper.SaveFile(uploderavgfile.PostedFile.InputStream, uploderavgfile.FileName, Constants.PHOTO_FOLDER_PATH, false, string.Empty);
                        }
                        if (cutAvgfile.HasFile)
                        {
                            string Exten = System.IO.Path.GetExtension(cutAvgfile.FileName);
                            string ActualfileName = Fabric + "_Cut_" + s + "_" + cutAvgfile.FileName;
                            string Name = ActualfileName.Substring(0, ActualfileName.LastIndexOf('.'));
                            cutAvgfiles = FileHelper.SaveFile(cutAvgfile.PostedFile.InputStream, cutAvgfile.FileName, Constants.PHOTO_FOLDER_PATH, true, Name);

                        }
                        Isave = objfabric.UpdateFabricCutprint(Convert.ToInt32(hdnOderDetailID.Value), (hdnCostingID.Value == "" ? 0 : Convert.ToInt32(hdnCostingID.Value)), CutAvgVal, cutAvgfiles, OrderAvgVal, OrderAvgFile, i, OrderWidthValue, CostWidthValue, CutWidthValue, OrderID, Convert.ToInt32(chkboxAccountMgr.Checked), CutAVgunit, strhistory);

                    }

                    if (OrderAvgExistInAllFabric == true)
                    {
                        WorkflowControllerInstance.Create_CloseWorkflowPostOrder(OrderID, OrderDetailId, TaskMode.Create_Fabric, ApplicationHelper.LoggedInUser.UserData.UserID);
                    }

                    if (chkboxAccountMgr.Checked)
                    {
                        WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(OrderID, OrderDetailId, TaskMode.Fabric_Approved, ApplicationHelper.LoggedInUser.UserData.UserID);
                        instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(OrderID, OrderDetailId, TaskMode.Create_Fabric, ApplicationHelper.LoggedInUser.UserData.UserID);
                    }

                }

                if (Isave > 0)
                {
                    //   ShowAlert("Saved successfully!");
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "closeAccesButtion();", true);                  
                    BindGrid();
                }
            }
            catch (Exception exc)
            {
                ShowAlert(exc.Message);
            }

        }


        protected void grdcutavg_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                HiddenField hdnOderDetailID = (HiddenField)e.Row.FindControl("hdnOderDetailID");
                HiddenField hdnfab1 = (HiddenField)e.Row.FindControl("hdnfab1");
                HiddenField hdnfab2 = (HiddenField)e.Row.FindControl("hdnfab2");
                HiddenField hdnfab3 = (HiddenField)e.Row.FindControl("hdnfab3");
                HiddenField hdnfab4 = (HiddenField)e.Row.FindControl("hdnfab4");
                HiddenField hdnfab5 = (HiddenField)e.Row.FindControl("hdnfab5");
                HiddenField hdnfab6 = (HiddenField)e.Row.FindControl("hdnfab6");
                //Label lblserialno = (Label)e.Row.FindControl("lblserialno");

                HiddenField hdnFileUpload1 = (HiddenField)e.Row.FindControl("hdnFileUpload1");
                HiddenField hdnFileUpload2 = (HiddenField)e.Row.FindControl("hdnFileUpload2");
                HiddenField hdnFileUpload3 = (HiddenField)e.Row.FindControl("hdnFileUpload3");
                HiddenField hdnFileUpload4 = (HiddenField)e.Row.FindControl("hdnFileUpload4");
                HiddenField hdnFileUpload5 = (HiddenField)e.Row.FindControl("hdnFileUpload5");
                HiddenField hdnFileUpload6 = (HiddenField)e.Row.FindControl("hdnFileUpload6");

                HyperLink hyplwithtext1 = (HyperLink)e.Row.FindControl("hyplwithtext1");
                HyperLink hyplwithtext2 = (HyperLink)e.Row.FindControl("hyplwithtext2");
                HyperLink hyplwithtext3 = (HyperLink)e.Row.FindControl("hyplwithtext3");
                HyperLink hyplwithtext4 = (HyperLink)e.Row.FindControl("hyplwithtext4");
                HyperLink hyplwithtext5 = (HyperLink)e.Row.FindControl("hyplwithtext5");
                HyperLink hyplwithtext6 = (HyperLink)e.Row.FindControl("hyplwithtext6");


                //TextBox txtorderavg1 = (TextBox)e.Row.FindControl("txtorderavg1");
                //TextBox txtorderavg2 = (TextBox)e.Row.FindControl("txtorderavg2");
                //TextBox txtorderavg3 = (TextBox)e.Row.FindControl("txtorderavg3");
                //TextBox txtorderavg4 = (TextBox)e.Row.FindControl("txtorderavg4");
                //TextBox txtorderavg5 = (TextBox)e.Row.FindControl("txtorderavg5");
                //TextBox txtorderavg6 = (TextBox)e.Row.FindControl("txtorderavg6");

                //HiddenField hdnOrderAvg1 = (HiddenField)e.Row.FindControl("hdnOrderAvg1");
                //HiddenField hdnOrderAvg2 = (HiddenField)e.Row.FindControl("hdnOrderAvg2");
                //HiddenField hdnOrderAvg3 = (HiddenField)e.Row.FindControl("hdnOrderAvg3");
                //HiddenField hdnOrderAvg4 = (HiddenField)e.Row.FindControl("hdnOrderAvg4");
                //HiddenField hdnOrderAvg5 = (HiddenField)e.Row.FindControl("hdnOrderAvg5");
                //HiddenField hdnOrderAvg6 = (HiddenField)e.Row.FindControl("hdnOrderAvg6");




                if (!string.IsNullOrEmpty(hdnfab1.Value))
                {
                    if (hdnfab1.Value == "1")
                    {
                        string valueAdd = "";
                        Label lblFabricName1 = (Label)e.Row.FindControl("lblFabricName1");
                        Label lblValueAddition1 = (Label)e.Row.FindControl("lblValueAddition1");
                        Label lblCCgsm1 = (Label)e.Row.FindControl("lblCCgsm1");


                        DataTable dt = objfabric.GetFabricCutOrderAvg(OrderID, 1, OrderDetailID, FabQualityID, FabDetails, Convert.ToInt32(hdnfab1.Value));
                        lblFabricName1.Text = dt.Rows[0]["FabricName"].ToString();
                        lblFabricName1.ForeColor = System.Drawing.Color.Blue;
                        lblCCgsm1.Text = dt.Rows[0]["Printdetails"].ToString();
                        lblCCgsm1.ForeColor = System.Drawing.Color.Gray;
                        //lblserialno.Text = dt.Rows[0]["SerialNumber"].ToString();
                        valueAdd = dt.Rows[0]["ValueAddition"] == DBNull.Value ? "" : dt.Rows[0]["ValueAddition"].ToString();
                        //if(valueAdd.Length>0)
                        if (valueAdd.Contains(','))
                        {
                            lblValueAddition1.Text = valueAdd.Remove(valueAdd.LastIndexOf(","));
                            lblValueAddition1.ForeColor = System.Drawing.Color.Black;
                        }
                        else
                        {
                            lblValueAddition1.Text = valueAdd;
                            lblValueAddition1.ForeColor = System.Drawing.Color.Black;
                        }

                        //added by raghvinder on 25-11-2020 start


                        FileUpload uploderavgfile1 = (FileUpload)e.Row.FindControl("uploderavgfile1");
                        HyperLink hyporderavgfile1 = (HyperLink)e.Row.FindControl("hyporderavgfile1");
                        int orderDetailID1 = dt.Rows[0]["orderdetailid"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["orderdetailid"].ToString());

                        DataSet ds = new DataSet();
                        DataTable dt1 = new DataTable();
                        DataTable dtUnit1 = new DataTable();
                        if (orderDetailID1 > 0)
                        {
                            ds = objfabric.GetFabricAvg(orderDetailID1, 2, 1);
                            dt1 = ds.Tables[0];
                            dtUnit1 = ds.Tables[1];
                            if (dt1.Rows.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(dt1.Rows[0]["OrderavgFile"].ToString()))
                                {
                                    hyporderavgfile1.NavigateUrl = "~/Uploads/Photo/" + dt1.Rows[0]["OrderavgFile"].ToString();
                                    hdnFileUpload1.Value = "1";
                                }
                                else
                                {
                                    hyporderavgfile1.Visible = false;
                                    hdnFileUpload1.Value = "0";
                                }
                            }
                        }

                        DropDownList ddlcutAvg_Unit1 = (DropDownList)e.Row.FindControl("ddlcutAvg_Unit1");
                        DataTable dtFabricUnit = new DataTable();

                        //new code start
                        //string OrderAvg1 = dt1.Rows[0]["OrderAvg"] == DBNull.Value ? "" : dt1.Rows[0]["OrderAvg"].ToString();
                        //string CutAvg1 = dt1.Rows[0]["CutAvg"] == DBNull.Value ? "0" : dt1.Rows[0]["CutAvg"].ToString();
                        //hdnCostingAvg.Value = dt1.Rows[0]["CostAvg"] == DBNull.Value ? "" : dt1.Rows[0]["CostAvg"].ToString();
                        //hdnCostingAvg1.Value = dt1.Rows[0]["CostAvg"] == DBNull.Value ? "" : dt1.Rows[0]["CostAvg"].ToString();
                        //if (OrderAvg1 == "0")
                        //{
                        //    txtorderavg1.Text = "";                            
                        //}
                        //else
                        //{
                        //    txtorderavg1.Text = OrderAvg1;
                        //    hdnOrderAvg1.Value = OrderAvg1;
                        //    //if (dt1.Rows[0]["CutAvg"].ToString() != "" || dt1.Rows[0]["CutAvg"].ToString() != "0")
                        //    if (CutAvg1 != "0")
                        //    {
                        //        txtorderavg1.Attributes.Add("readonly", "readonly");
                        //    }
                        //}
                        //new code end
                        int FabricQualityID = -1;
                        if (dt1.Rows.Count > 0)
                        {
                            FabricQualityID = dt1.Rows[0]["FabricQualityID"] == DBNull.Value ? -1 : Convert.ToInt32(dt1.Rows[0]["FabricQualityID"].ToString());
                        }
                        dtFabricUnit = objwc.Get_FabricUnit_ForOrder(orderDetailID1, FabricQualityID);
                        int FabricUnit = 0, GarmentUnit = 0;
                        if (dt1.Rows.Count > 0)
                        {
                            GarmentUnit = dt1.Rows[0]["Unit"].ToString() == "" ? -1 : Convert.ToInt32(dt1.Rows[0]["Unit"]);
                        }

                        if (dtFabricUnit.Rows.Count > 0)
                        {
                            FabricUnit = dtFabricUnit.Rows[0]["FabricUnit"].ToString() == "" ? -1 : Convert.ToInt32(dtFabricUnit.Rows[0]["FabricUnit"].ToString());
                        }

                        if (!string.IsNullOrEmpty(dtUnit1.Rows[0]["UnitName"].ToString()))
                        {
                            ddlcutAvg_Unit1.DataSource = dtUnit1;
                            ddlcutAvg_Unit1.DataTextField = "UnitName";
                            ddlcutAvg_Unit1.DataValueField = "GroupUnitID";
                            ddlcutAvg_Unit1.DataBind();
                        }
                        if (GarmentUnit > 0)
                        {
                            ddlcutAvg_Unit1.SelectedValue = GarmentUnit.ToString();
                            if (chkboxAccountMgr.Checked == true)
                            {
                                ddlcutAvg_Unit1.Enabled = false;
                            }
                        }
                        else
                        {
                            ddlcutAvg_Unit1.SelectedValue = FabricUnit.ToString();
                            if (chkboxAccountMgr.Checked == true)
                            {
                                ddlcutAvg_Unit1.Enabled = false;
                            }
                        }
                        //added by raghvinder on 25-11-2020 end

                    }
                }
                if (!string.IsNullOrEmpty(hdnfab2.Value))
                {
                    if (hdnfab2.Value == "2")
                    {
                        string valueAdd = "";
                        Label lblFabricName2 = (Label)e.Row.FindControl("lblFabricName2");
                        Label lblValueAddition2 = (Label)e.Row.FindControl("lblValueAddition2");
                        Label lblCCgsm2 = (Label)e.Row.FindControl("lblCCgsm2");



                        DataTable dt = objfabric.GetFabricCutOrderAvg(OrderID, 1, OrderDetailID, FabQualityID, FabDetails, Convert.ToInt32(hdnfab2.Value));
                        lblFabricName2.Text = dt.Rows[0]["FabricName"].ToString();
                        lblFabricName2.ForeColor = System.Drawing.Color.Blue;
                        lblCCgsm2.Text = dt.Rows[0]["Printdetails"].ToString();
                        lblCCgsm2.ForeColor = System.Drawing.Color.Gray;
                        valueAdd = dt.Rows[0]["ValueAddition"] == DBNull.Value ? "" : dt.Rows[0]["ValueAddition"].ToString();
                        if (valueAdd.Contains(','))
                        {
                            lblValueAddition2.Text = valueAdd.Remove(valueAdd.LastIndexOf(","));
                            lblValueAddition2.ForeColor = System.Drawing.Color.Black;
                        }
                        else
                        {
                            lblValueAddition2.Text = valueAdd;
                            lblValueAddition2.ForeColor = System.Drawing.Color.Black;
                        }

                        //added by raghvinder on 25-11-2020 start

                        FileUpload uploderavgfile = (FileUpload)e.Row.FindControl("uploderavgfile2");
                        HyperLink hyporderavgfile2 = (HyperLink)e.Row.FindControl("hyporderavgfile2");

                        int orderDetailID2 = dt.Rows[0]["orderdetailid"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["orderdetailid"].ToString());
                        DataSet ds = new DataSet();
                        DataTable dt2 = new DataTable();
                        DataTable dtUnit2 = new DataTable();
                        if (orderDetailID2 > 0)
                        {
                            ds = objfabric.GetFabricAvg(orderDetailID2, 2, 2);
                            dt2 = ds.Tables[0];
                            dtUnit2 = ds.Tables[1];
                            if (dt2.Rows.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(dt2.Rows[0]["OrderavgFile"].ToString()))
                                {
                                    hyporderavgfile2.NavigateUrl = ProductionFolderPath + dt2.Rows[0]["OrderavgFile"].ToString();
                                    hdnFileUpload2.Value = "1";
                                }

                                else
                                {
                                    hyporderavgfile2.Visible = false;
                                    hdnFileUpload2.Value = "0";
                                }
                            }
                        }


                        DropDownList ddlcutAvg_Unit2 = (DropDownList)e.Row.FindControl("ddlcutAvg_Unit2");
                        DataTable dtFabricUnit = new DataTable();

                        //new code start
                        //string OrderAvg2 = dt2.Rows[0]["OrderAvg"] == DBNull.Value ? "" : dt2.Rows[0]["OrderAvg"].ToString();
                        //string CutAvg2 = dt2.Rows[0]["CutAvg"] == DBNull.Value ? "0" : dt2.Rows[0]["CutAvg"].ToString();
                        //hdnCostingAvg2.Value = dt2.Rows[0]["CostAvg"] == DBNull.Value ? "" : dt2.Rows[0]["CostAvg"].ToString();
                        //if (OrderAvg2 == "0")
                        //{
                        //    txtorderavg2.Text = "";
                        //}
                        //else
                        //{
                        //    txtorderavg2.Text = OrderAvg2;
                        //    hdnOrderAvg2.Value = OrderAvg2;
                        //    //if (dt2.Rows[0]["CutAvg"].ToString() != "" || dt2.Rows[0]["CutAvg"].ToString()=="0")
                        //    if (CutAvg2 != "0")
                        //    {
                        //        txtorderavg2.Attributes.Add("readonly", "readonly");
                        //    }
                        //}
                        //new code end

                        int FabricQualityID = -1;
                        if (dt2.Rows.Count > 0)
                        {
                            FabricQualityID = dt2.Rows[0]["FabricQualityID"] == DBNull.Value ? -1 : Convert.ToInt32(dt2.Rows[0]["FabricQualityID"].ToString());
                        }
                        dtFabricUnit = objwc.Get_FabricUnit_ForOrder(orderDetailID2, FabricQualityID);
                        int FabricUnit = 0, GarmentUnit = 0;
                        if (dt2.Rows.Count > 0)
                        {
                            GarmentUnit = dt2.Rows[0]["Unit"].ToString() == "" ? -1 : Convert.ToInt32(dt2.Rows[0]["Unit"]);
                        }

                        if (dtFabricUnit.Rows.Count > 0)
                        {
                            FabricUnit = dtFabricUnit.Rows[0]["FabricUnit"].ToString() == "" ? -1 : Convert.ToInt32(dtFabricUnit.Rows[0]["FabricUnit"].ToString());
                        }

                        if (!string.IsNullOrEmpty(dtUnit2.Rows[0]["UnitName"].ToString()))
                        {
                            ddlcutAvg_Unit2.DataSource = dtUnit2;
                            ddlcutAvg_Unit2.DataTextField = "UnitName";
                            ddlcutAvg_Unit2.DataValueField = "GroupUnitID";
                            ddlcutAvg_Unit2.DataBind();
                        }

                        if (GarmentUnit > 0)
                        {
                            ddlcutAvg_Unit2.SelectedValue = GarmentUnit.ToString();
                            if (chkboxAccountMgr.Checked == true)
                            {
                                ddlcutAvg_Unit2.Enabled = false;
                            }
                        }
                        else
                        {
                            ddlcutAvg_Unit2.SelectedValue = FabricUnit.ToString();
                            if (chkboxAccountMgr.Checked == true)
                            {
                                ddlcutAvg_Unit2.Enabled = false;
                            }
                        }
                        //added by raghvinder on 25-11-2020 end
                    }
                }
                if (!string.IsNullOrEmpty(hdnfab3.Value))
                {
                    if (hdnfab3.Value == "3")
                    {
                        string valueAdd = "";
                        Label lblFabricName3 = (Label)e.Row.FindControl("lblFabricName3");
                        Label lblValueAddition3 = (Label)e.Row.FindControl("lblValueAddition3");
                        Label lblCCgsm3 = (Label)e.Row.FindControl("lblCCgsm3");

                        DataTable dt = objfabric.GetFabricCutOrderAvg(OrderID, 1, OrderDetailID, FabQualityID, FabDetails, Convert.ToInt32(hdnfab3.Value));
                        lblFabricName3.Text = dt.Rows[0]["FabricName"].ToString();
                        lblFabricName3.ForeColor = System.Drawing.Color.Blue;
                        lblCCgsm3.Text = dt.Rows[0]["Printdetails"].ToString();
                        lblCCgsm3.ForeColor = System.Drawing.Color.Gray;
                        valueAdd = dt.Rows[0]["ValueAddition"] == DBNull.Value ? "" : dt.Rows[0]["ValueAddition"].ToString();
                        if (valueAdd.Contains(','))
                        {
                            lblValueAddition3.Text = valueAdd.Remove(valueAdd.LastIndexOf(","));
                            lblValueAddition3.ForeColor = System.Drawing.Color.Black;
                        }
                        else
                        {
                            lblValueAddition3.Text = valueAdd;
                            lblValueAddition3.ForeColor = System.Drawing.Color.Black;
                        }

                        //added by raghvinder on 25-11-2020 start                        
                        FileUpload uploderavgfile = (FileUpload)e.Row.FindControl("uploderavgfile3");
                        HyperLink hyporderavgfile3 = (HyperLink)e.Row.FindControl("hyporderavgfile3");
                        int orderDetailID3 = dt.Rows[0]["orderdetailid"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["orderdetailid"].ToString());

                        DataSet ds = new DataSet();
                        DataTable dt3 = new DataTable();
                        DataTable dtUnit3 = new DataTable();
                        if (orderDetailID3 > 0)
                        {
                            ds = objfabric.GetFabricAvg(orderDetailID3, 2, 3);
                            dt3 = ds.Tables[0];
                            dtUnit3 = ds.Tables[1];
                            //DataTable dt1 = objfabric.GetFabricAvg(hdnOderDetailID.Value == "" ? -1 : Convert.ToInt32(hdnOderDetailID.Value), 2, 1).Tables[0];

                            if (dt3.Rows.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(dt3.Rows[0]["OrderavgFile"].ToString()))
                                {
                                    hyporderavgfile3.NavigateUrl = ProductionFolderPath + dt3.Rows[0]["OrderavgFile"].ToString();
                                    hdnFileUpload3.Value = "1";
                                }
                                else
                                {
                                    hyporderavgfile3.Visible = false;
                                    hdnFileUpload3.Value = "0";
                                }
                            }
                        }


                        DropDownList ddlcutAvg_Unit3 = (DropDownList)e.Row.FindControl("ddlcutAvg_Unit3");
                        DataTable dtFabricUnit = new DataTable();

                        //new code start
                        //string OrderAvg3 = dt3.Rows[0]["OrderAvg"] == DBNull.Value ? "" : dt3.Rows[0]["OrderAvg"].ToString();
                        //string CutAvg3 = dt3.Rows[0]["CutAvg"] == DBNull.Value ? "0" : dt3.Rows[0]["CutAvg"].ToString();
                        //hdnCostingAvg3.Value = dt3.Rows[0]["CostAvg"] == DBNull.Value ? "" : dt3.Rows[0]["CostAvg"].ToString();
                        //if (OrderAvg3 == "0")
                        //{
                        //    txtorderavg3.Text = "";
                        //}
                        //else
                        //{
                        //    txtorderavg3.Text = OrderAvg3;
                        //    hdnOrderAvg3.Value = OrderAvg3;

                        //    //if (dt3.Rows[0]["CutAvg"].ToString() != "" || dt3.Rows[0]["CutAvg"].ToString() == "0")
                        //    if(CutAvg3 != "0")
                        //    {
                        //        txtorderavg3.Attributes.Add("readonly", "readonly");
                        //    }
                        //}
                        //new code end

                        int FabricQualityID = -1;
                        if (dt3.Rows.Count > 0)
                        {
                            FabricQualityID = dt3.Rows[0]["FabricQualityID"] == DBNull.Value ? -1 : Convert.ToInt32(dt3.Rows[0]["FabricQualityID"].ToString());
                        }
                        dtFabricUnit = objwc.Get_FabricUnit_ForOrder(orderDetailID3, FabricQualityID);
                        int FabricUnit = 0, GarmentUnit = 0;
                        if (dt3.Rows.Count > 0)
                        {
                            GarmentUnit = dt3.Rows[0]["Unit"].ToString() == "" ? -1 : Convert.ToInt32(dt3.Rows[0]["Unit"]);
                        }

                        if (dtFabricUnit.Rows.Count > 0)
                        {
                            FabricUnit = dtFabricUnit.Rows[0]["FabricUnit"].ToString() == "" ? -1 : Convert.ToInt32(dtFabricUnit.Rows[0]["FabricUnit"].ToString());
                        }

                        if (!string.IsNullOrEmpty(dtUnit3.Rows[0]["UnitName"].ToString()))
                        {
                            ddlcutAvg_Unit3.DataSource = dtUnit3;
                            ddlcutAvg_Unit3.DataTextField = "UnitName";
                            ddlcutAvg_Unit3.DataValueField = "GroupUnitID";
                            ddlcutAvg_Unit3.DataBind();
                        }
                        if (GarmentUnit > 0)
                        {
                            ddlcutAvg_Unit3.SelectedValue = GarmentUnit.ToString();
                            if (chkboxAccountMgr.Checked == true)
                            {
                                ddlcutAvg_Unit3.Enabled = false;
                            }

                        }
                        else
                        {
                            ddlcutAvg_Unit3.SelectedValue = FabricUnit.ToString();
                            if (chkboxAccountMgr.Checked == true)
                            {
                                ddlcutAvg_Unit3.Enabled = false;
                            }
                        }
                        //added by raghvinder on 25-11-2020 end
                    }
                }
                if (!string.IsNullOrEmpty(hdnfab4.Value))
                {
                    if (hdnfab4.Value == "4")
                    {
                        string valueAdd = "";
                        Label lblFabricName4 = (Label)e.Row.FindControl("lblFabricName4");
                        Label lblValueAddition4 = (Label)e.Row.FindControl("lblValueAddition4");
                        Label lblCCgsm4 = (Label)e.Row.FindControl("lblCCgsm4");

                        DataTable dt = objfabric.GetFabricCutOrderAvg(OrderID, 1, OrderDetailID, FabQualityID, FabDetails, Convert.ToInt32(hdnfab4.Value));
                        lblFabricName4.Text = dt.Rows[0]["FabricName"].ToString();
                        lblFabricName4.ForeColor = System.Drawing.Color.Blue;
                        lblCCgsm4.Text = dt.Rows[0]["Printdetails"].ToString();
                        lblCCgsm4.ForeColor = System.Drawing.Color.Gray;
                        valueAdd = dt.Rows[0]["ValueAddition"] == DBNull.Value ? "" : dt.Rows[0]["ValueAddition"].ToString();
                        if (valueAdd.Contains(','))
                        {
                            lblValueAddition4.Text = valueAdd.Remove(valueAdd.LastIndexOf(","));
                            lblValueAddition4.ForeColor = System.Drawing.Color.Black;
                        }
                        else
                        {
                            lblValueAddition4.Text = valueAdd;
                            lblValueAddition4.ForeColor = System.Drawing.Color.Black;
                        }

                        //added by raghvinder on 25-11-2020 start

                        FileUpload uploderavgfile = (FileUpload)e.Row.FindControl("uploderavgfile4");
                        HyperLink hyporderavgfile4 = (HyperLink)e.Row.FindControl("hyporderavgfile4");
                        int orderDetailID4 = dt.Rows[0]["orderdetailid"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["orderdetailid"].ToString());

                        DataSet ds = new DataSet();
                        DataTable dt4 = new DataTable();
                        DataTable dtUnit4 = new DataTable();
                        if (orderDetailID4 > 0)
                        {
                            ds = objfabric.GetFabricAvg(orderDetailID4, 2, 4);
                            dt4 = ds.Tables[0];
                            dtUnit4 = ds.Tables[1];
                            //DataTable dt1 = objfabric.GetFabricAvg(hdnOderDetailID.Value == "" ? -1 : Convert.ToInt32(hdnOderDetailID.Value), 2, 1).Tables[0];

                            if (dt4.Rows.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(dt4.Rows[0]["OrderavgFile"].ToString()))
                                {
                                    hyporderavgfile4.NavigateUrl = ProductionFolderPath + dt4.Rows[0]["OrderavgFile"].ToString();
                                    hdnFileUpload4.Value = "1";
                                }

                                else
                                {
                                    hyporderavgfile4.Visible = false;
                                    hdnFileUpload4.Value = "0";
                                }
                            }
                        }

                        DropDownList ddlcutAvg_Unit4 = (DropDownList)e.Row.FindControl("ddlcutAvg_Unit4");
                        DataTable dtFabricUnit = new DataTable();

                        //new code start
                        //string OrderAvg4 = dt4.Rows[0]["OrderAvg"] == DBNull.Value ? "" : dt4.Rows[0]["OrderAvg"].ToString();
                        //string CutAvg4 = dt4.Rows[0]["CutAvg"] == DBNull.Value ? "0" : dt4.Rows[0]["CutAvg"].ToString();
                        //hdnCostingAvg4.Value = dt4.Rows[0]["CostAvg"] == DBNull.Value ? "" : dt4.Rows[0]["CostAvg"].ToString();
                        //if (OrderAvg4 == "0")
                        //{
                        //    txtorderavg4.Text = "";
                        //}
                        //else
                        //{
                        //    txtorderavg4.Text = OrderAvg4;
                        //    hdnOrderAvg4.Value = OrderAvg4;

                        //    //if (dt4.Rows[0]["CutAvg"].ToString() != "" || dt4.Rows[0]["CutAvg"].ToString() == "0")
                        //    if(CutAvg4 !="0")
                        //    {
                        //        txtorderavg4.Attributes.Add("readonly", "readonly");
                        //    }
                        //}
                        //new code end

                        int FabricQualityID = -1;
                        if (dt4.Rows.Count > 0)
                        {
                            FabricQualityID = dt4.Rows[0]["FabricQualityID"] == DBNull.Value ? -1 : Convert.ToInt32(dt4.Rows[0]["FabricQualityID"].ToString());
                        }
                        dtFabricUnit = objwc.Get_FabricUnit_ForOrder(orderDetailID4, FabricQualityID);
                        int FabricUnit = 0, GarmentUnit = 0;
                        if (dt4.Rows.Count > 0)
                        {
                            GarmentUnit = dt4.Rows[0]["Unit"].ToString() == "" ? -1 : Convert.ToInt32(dt4.Rows[0]["Unit"]);
                        }

                        if (dtFabricUnit.Rows.Count > 0)
                        {
                            FabricUnit = dtFabricUnit.Rows[0]["FabricUnit"].ToString() == "" ? -1 : Convert.ToInt32(dtFabricUnit.Rows[0]["FabricUnit"].ToString());
                        }

                        if (!string.IsNullOrEmpty(dtUnit4.Rows[0]["UnitName"].ToString()))
                        {
                            ddlcutAvg_Unit4.DataSource = dtUnit4;
                            ddlcutAvg_Unit4.DataTextField = "UnitName";
                            ddlcutAvg_Unit4.DataValueField = "GroupUnitID";
                            ddlcutAvg_Unit4.DataBind();
                        }
                        if (GarmentUnit > 0)
                        {
                            ddlcutAvg_Unit4.SelectedValue = GarmentUnit.ToString();
                            if (chkboxAccountMgr.Checked == true)
                            {
                                ddlcutAvg_Unit4.Enabled = false;
                            }
                        }
                        else
                        {
                            ddlcutAvg_Unit4.SelectedValue = FabricUnit.ToString();
                            if (chkboxAccountMgr.Checked == true)
                            {
                                ddlcutAvg_Unit4.Enabled = false;
                            }
                        }
                        //added by raghvinder on 25-11-2020 end
                    }
                }
                if (!string.IsNullOrEmpty(hdnfab5.Value))
                {
                    if (hdnfab5.Value == "5")
                    {
                        string valueAdd = "";
                        Label lblFabricName5 = (Label)e.Row.FindControl("lblFabricName5");
                        Label lblValueAddition5 = (Label)e.Row.FindControl("lblValueAddition5");
                        Label lblCCgsm5 = (Label)e.Row.FindControl("lblCCgsm5");


                        DataTable dt = objfabric.GetFabricCutOrderAvg(OrderID, 1, OrderDetailID, FabQualityID, FabDetails, Convert.ToInt32(hdnfab5.Value));
                        lblFabricName5.Text = dt.Rows[0]["FabricName"].ToString();
                        lblFabricName5.ForeColor = System.Drawing.Color.Blue;
                        lblCCgsm5.Text = dt.Rows[0]["Printdetails"].ToString();
                        lblCCgsm5.ForeColor = System.Drawing.Color.Gray;
                        valueAdd = dt.Rows[0]["ValueAddition"] == DBNull.Value ? "" : dt.Rows[0]["ValueAddition"].ToString();
                        if (valueAdd.Contains(','))
                        {
                            lblValueAddition5.Text = valueAdd.Remove(valueAdd.LastIndexOf(","));
                            lblValueAddition5.ForeColor = System.Drawing.Color.Black;
                        }
                        else
                        {
                            lblValueAddition5.Text = valueAdd;
                            lblValueAddition5.ForeColor = System.Drawing.Color.Black;
                        }

                        //added by raghvinder on 25-11-2020 start

                        FileUpload uploderavgfile = (FileUpload)e.Row.FindControl("uploderavgfile5");
                        HyperLink hyporderavgfile5 = (HyperLink)e.Row.FindControl("hyporderavgfile5");

                        int orderDetailID5 = dt.Rows[0]["orderdetailid"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["orderdetailid"].ToString());

                        DataSet ds = new DataSet();
                        DataTable dt5 = new DataTable();
                        DataTable dtUnit5 = new DataTable();
                        if (orderDetailID5 > 0)
                        {

                            ds = objfabric.GetFabricAvg(orderDetailID5, 2, 5);
                            dt5 = ds.Tables[0];
                            dtUnit5 = ds.Tables[1];
                            //DataTable dt1 = objfabric.GetFabricAvg(hdnOderDetailID.Value == "" ? -1 : Convert.ToInt32(hdnOderDetailID.Value), 2, 1).Tables[0];

                            if (dt5.Rows.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(dt5.Rows[0]["OrderavgFile"].ToString()))
                                {
                                    hyporderavgfile5.NavigateUrl = ProductionFolderPath + dt5.Rows[0]["OrderavgFile"].ToString();
                                    hdnFileUpload5.Value = "1";
                                }

                                else
                                {
                                    hyporderavgfile5.Visible = false;
                                    hdnFileUpload5.Value = "0";
                                }
                            }
                        }

                        DropDownList ddlcutAvg_Unit5 = (DropDownList)e.Row.FindControl("ddlcutAvg_Unit5");
                        DataTable dtFabricUnit = new DataTable();

                        //new code start
                        //string OrderAvg5 = dt5.Rows[0]["OrderAvg"] == DBNull.Value ? "" : dt5.Rows[0]["OrderAvg"].ToString();
                        //string CutAvg5 = dt5.Rows[0]["CutAvg"] == DBNull.Value ? "0" : dt5.Rows[0]["CutAvg"].ToString();
                        //hdnCostingAvg5.Value = dt5.Rows[0]["CostAvg"] == DBNull.Value ? "" : dt5.Rows[0]["CostAvg"].ToString();
                        //if (OrderAvg5 == "0")
                        //{
                        //    txtorderavg5.Text = "";
                        //}
                        //else
                        //{
                        //    txtorderavg5.Text = OrderAvg5;
                        //    hdnOrderAvg5.Value = OrderAvg5;

                        //    //if (dt5.Rows[0]["CutAvg"].ToString() != "" || dt5.Rows[0]["CutAvg"].ToString() == "0")
                        //    if(CutAvg5 != "0")
                        //    {
                        //        txtorderavg5.Attributes.Add("readonly", "readonly");
                        //    }
                        //}
                        //new code end

                        int FabricQualityID = -1;
                        if (dt5.Rows.Count > 0)
                        {
                            FabricQualityID = dt5.Rows[0]["FabricQualityID"] == DBNull.Value ? -1 : Convert.ToInt32(dt5.Rows[0]["FabricQualityID"].ToString());
                        }
                        dtFabricUnit = objwc.Get_FabricUnit_ForOrder(orderDetailID5, FabricQualityID);
                        int FabricUnit = 0, GarmentUnit = 0;
                        if (dt5.Rows.Count > 0)
                        {
                            GarmentUnit = dt5.Rows[0]["Unit"].ToString() == "" ? -1 : Convert.ToInt32(dt5.Rows[0]["Unit"]);
                        }

                        if (dtFabricUnit.Rows.Count > 0)
                        {
                            FabricUnit = dtFabricUnit.Rows[0]["FabricUnit"].ToString() == "" ? -1 : Convert.ToInt32(dtFabricUnit.Rows[0]["FabricUnit"].ToString());
                        }

                        if (!string.IsNullOrEmpty(dtUnit5.Rows[0]["UnitName"].ToString()))
                        {
                            ddlcutAvg_Unit5.DataSource = dtUnit5;
                            ddlcutAvg_Unit5.DataTextField = "UnitName";
                            ddlcutAvg_Unit5.DataValueField = "GroupUnitID";
                            ddlcutAvg_Unit5.DataBind();
                        }
                        if (GarmentUnit > 0)
                        {
                            ddlcutAvg_Unit5.SelectedValue = GarmentUnit.ToString();
                            if (chkboxAccountMgr.Checked == true)
                            {
                                ddlcutAvg_Unit5.Enabled = false;
                            }
                        }
                        else
                        {
                            ddlcutAvg_Unit5.SelectedValue = FabricUnit.ToString();
                            if (chkboxAccountMgr.Checked == true)
                            {
                                ddlcutAvg_Unit5.Enabled = false;
                            }
                        }

                        //added by raghvinder on 25-11-2020 end
                    }
                }
                if (!string.IsNullOrEmpty(hdnfab6.Value))
                {
                    if (hdnfab6.Value == "6")
                    {
                        string valueAdd = "";
                        Label lblFabricName6 = (Label)e.Row.FindControl("lblFabricName6");
                        Label lblValueAddition6 = (Label)e.Row.FindControl("lblValueAddition6");
                        Label lblCCgsm6 = (Label)e.Row.FindControl("lblCCgsm6");

                        DataTable dt = objfabric.GetFabricCutOrderAvg(OrderID, 1, OrderDetailID, FabQualityID, FabDetails, Convert.ToInt32(hdnfab6.Value));
                        lblFabricName6.Text = dt.Rows[0]["FabricName"].ToString();
                        lblFabricName6.ForeColor = System.Drawing.Color.Blue;
                        lblCCgsm6.Text = dt.Rows[0]["Printdetails"].ToString();
                        lblCCgsm6.ForeColor = System.Drawing.Color.Gray;
                        valueAdd = dt.Rows[0]["ValueAddition"] == DBNull.Value ? "" : dt.Rows[0]["ValueAddition"].ToString();
                        if (valueAdd.Contains(','))
                        {
                            lblValueAddition6.Text = valueAdd.Remove(valueAdd.LastIndexOf(","));
                            lblValueAddition6.ForeColor = System.Drawing.Color.Black;
                        }
                        else
                        {
                            lblValueAddition6.Text = valueAdd;
                            lblValueAddition6.ForeColor = System.Drawing.Color.Black;
                        }

                        //added by raghvinder on 25-11-2020 start                        
                        FileUpload uploderavgfile = (FileUpload)e.Row.FindControl("uploderavgfile6");
                        HyperLink hyporderavgfile6 = (HyperLink)e.Row.FindControl("hyporderavgfile6");
                        int orderDetailID6 = dt.Rows[0]["orderdetailid"] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0]["orderdetailid"].ToString());

                        DataSet ds = new DataSet();
                        DataTable dt6 = new DataTable();
                        DataTable dtUnit6 = new DataTable();
                        if (orderDetailID6 > 0)
                        {

                            ds = objfabric.GetFabricAvg(orderDetailID6, 2, 6);
                            dt6 = ds.Tables[0];
                            dtUnit6 = ds.Tables[1];
                            //DataTable dt1 = objfabric.GetFabricAvg(hdnOderDetailID.Value == "" ? -1 : Convert.ToInt32(hdnOderDetailID.Value), 2, 1).Tables[0];

                            if (dt6.Rows.Count > 0)
                            {
                                if (!string.IsNullOrEmpty(dt6.Rows[0]["OrderavgFile"].ToString()))
                                {
                                    hyporderavgfile6.NavigateUrl = ProductionFolderPath + dt6.Rows[0]["OrderavgFile"].ToString();
                                    hdnFileUpload6.Value = "1";
                                }

                                else
                                {
                                    hyporderavgfile6.Visible = false;
                                    hdnFileUpload6.Value = "0";
                                }
                            }
                        }

                        DropDownList ddlcutAvg_Unit6 = (DropDownList)e.Row.FindControl("ddlcutAvg_Unit6");
                        DataTable dtFabricUnit = new DataTable();

                        //new code start
                        //string OrderAvg6 = dt6.Rows[0]["OrderAvg"] == DBNull.Value ? "" : dt6.Rows[0]["OrderAvg"].ToString();
                        //string CutAvg6 = dt6.Rows[0]["CutAvg"] == DBNull.Value ? "0" : dt6.Rows[0]["CutAvg"].ToString();
                        //hdnCostingAvg6.Value = dt6.Rows[0]["CostAvg"] == DBNull.Value ? "" : dt6.Rows[0]["CostAvg"].ToString();
                        //if (OrderAvg6 == "0")
                        //{
                        //    txtorderavg6.Text = "";
                        //}
                        //else
                        //{
                        //    txtorderavg6.Text = OrderAvg6;
                        //    hdnOrderAvg6.Value = OrderAvg6;

                        //    //if (dt6.Rows[0]["CutAvg"].ToString() != "" || dt6.Rows[0]["CutAvg"].ToString() == "0")
                        //    if(CutAvg6 != "0")
                        //    {
                        //        txtorderavg6.Attributes.Add("readonly", "readonly");
                        //    }
                        //}
                        //new code end

                        int FabricQualityID = -1;
                        if (dt6.Rows.Count > 0)
                        {
                            FabricQualityID = dt6.Rows[0]["FabricQualityID"] == DBNull.Value ? -1 : Convert.ToInt32(dt6.Rows[0]["FabricQualityID"].ToString());
                        }
                        dtFabricUnit = objwc.Get_FabricUnit_ForOrder(orderDetailID6, FabricQualityID);
                        int FabricUnit = 0, GarmentUnit = 0;
                        if (dt6.Rows.Count > 0)
                        {
                            GarmentUnit = dt6.Rows[0]["Unit"].ToString() == "" ? -1 : Convert.ToInt32(dt6.Rows[0]["Unit"]);
                        }

                        if (dtFabricUnit.Rows.Count > 0)
                        {
                            FabricUnit = dtFabricUnit.Rows[0]["FabricUnit"].ToString() == "" ? -1 : Convert.ToInt32(dtFabricUnit.Rows[0]["FabricUnit"].ToString());
                        }

                        if (!string.IsNullOrEmpty(dtUnit6.Rows[0]["UnitName"].ToString()))
                        {
                            ddlcutAvg_Unit6.DataSource = dtUnit6;
                            ddlcutAvg_Unit6.DataTextField = "UnitName";
                            ddlcutAvg_Unit6.DataValueField = "GroupUnitID";
                            ddlcutAvg_Unit6.DataBind();
                        }
                        if (GarmentUnit > 0)
                        {
                            ddlcutAvg_Unit6.SelectedValue = GarmentUnit.ToString();
                            if (chkboxAccountMgr.Checked == true)
                            {
                                ddlcutAvg_Unit6.Enabled = false;
                            }
                        }
                        else
                        {
                            ddlcutAvg_Unit6.SelectedValue = FabricUnit.ToString();
                            if (chkboxAccountMgr.Checked == true)
                            {
                                ddlcutAvg_Unit6.Enabled = false;
                            }
                        }
                        //added by raghvinder on 25-11-2020 end

                    }
                }

                // CREATE PERMISSION FOR FABRIC ORDER AVG FILE
                if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_DETAIL_ORDER_AVG_FILE))
                {
                    hyplwithtext1.Style.Add("display", "none");
                    hyplwithtext2.Style.Add("display", "none");
                    hyplwithtext3.Style.Add("display", "none");
                    hyplwithtext4.Style.Add("display", "none");
                    hyplwithtext5.Style.Add("display", "none");
                    hyplwithtext6.Style.Add("display", "none");
                }

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                HiddenField hdnOderDetailID = (HiddenField)e.Row.FindControl("hdnOderDetailID");
                HiddenField hdnFabCount = (HiddenField)e.Row.FindControl("hdnFabCount");
                //add code by bharat on 1-sep-20  
                TextBox txtorderavg1 = (TextBox)e.Row.FindControl("txtorderavg1");
                TextBox txtorderavg2 = (TextBox)e.Row.FindControl("txtorderavg2");
                TextBox txtorderavg3 = (TextBox)e.Row.FindControl("txtorderavg3");
                TextBox txtorderavg4 = (TextBox)e.Row.FindControl("txtorderavg4");
                TextBox txtorderavg5 = (TextBox)e.Row.FindControl("txtorderavg5");
                TextBox txtorderavg6 = (TextBox)e.Row.FindControl("txtorderavg6");

                HiddenField hdnOrderAvg1 = (HiddenField)e.Row.FindControl("hdnOrderAvg1");
                HiddenField hdnOrderAvg2 = (HiddenField)e.Row.FindControl("hdnOrderAvg2");
                HiddenField hdnOrderAvg3 = (HiddenField)e.Row.FindControl("hdnOrderAvg3");
                HiddenField hdnOrderAvg4 = (HiddenField)e.Row.FindControl("hdnOrderAvg4");
                HiddenField hdnOrderAvg5 = (HiddenField)e.Row.FindControl("hdnOrderAvg5");
                HiddenField hdnOrderAvg6 = (HiddenField)e.Row.FindControl("hdnOrderAvg6");

                Label lblContactNo = (Label)e.Row.FindControl("lblContactNo");
                Label lblExFactory = (Label)e.Row.FindControl("lblExFactory");
                lblExFactory.Text = DateTime.Parse(lblExFactory.Text).ToString("dd MMM yy (ddd)");




                int index1 = lblContactNo.Text.IndexOf('/');
                lblContactNo.ToolTip = lblContactNo.Text;
                string cc = lblContactNo.Text;



                if (cc.Contains("/"))
                {
                    char[] MyChar = { '/', '<', 'b', 'r', '>' };
                    string[] sdsd = lblContactNo.Text.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                    lblContactNo.Text = "";
                    foreach (string s in sdsd)
                    {
                        string[] g = s.Split(new string[] { "$$" }, StringSplitOptions.RemoveEmptyEntries);
                        lblContactNo.Text = lblContactNo.Text + s + "/" + "<br>";

                    }

                    lblContactNo.Text = lblContactNo.Text.Remove(lblContactNo.Text.Length - 1).TrimEnd(MyChar);
                }
                //4679854/<br>31548787/<br>87544154/<br>

                if (Convert.ToInt32(hdnFabCount.Value) > 6)
                {
                    FabCount = Convert.ToInt32("6");
                }
                else
                {
                    FabCount = Convert.ToInt32(hdnFabCount.Value);
                }
                //end
                // this code added by bhrarat on 24-jun
                if (FabCount == 1)
                {
                    DynamicHeaderWidth.Attributes.Add("class", "DynamicHeader");
                    if (TaskStatus == 1)
                    {
                        widthdiv.Attributes.Add("class", "DynamicHeader");
                    }
                    else
                    {
                        DynamicTableWidth.Attributes.Add("class", "DynamicFab1");
                        // Fab1Left.Attributes.Add("class", "FabMarLeft");
                    }

                }
                if (FabCount == 2)
                {
                    if (TaskStatus == 1)
                    {
                        DynamicHeaderWidth.Attributes.Add("class", "DynamicHeaderTaks");
                        widthdiv.Attributes.Add("class", "DynamicHeader1");
                    }
                    else
                    {
                        DynamicHeaderWidth.Attributes.Add("class", "DynamicHeader1");
                        DynamicTableWidth.Attributes.Add("class", "DynamicHeader1");
                    }
                }
                if (FabCount == 3)
                {
                    // DynamicTableWidth.Attributes.Add("class", "DynamicTable3");
                    // DynamicHeaderWidth.Attributes.Add("class", "DynamicHeader2");
                    if (TaskStatus == 1)
                    {
                        DynamicHeaderWidth.Attributes.Add("class", "DynamicHeaderTask");
                        widthdiv.Attributes.Add("class", "DynamicHeader3");
                    }
                    else
                    {
                        DynamicHeaderWidth.Attributes.Add("class", "DynamicHeader2");
                    }
                }
                if (FabCount == 4)
                {
                    if (TaskStatus == 1)
                    {
                        DynamicHeaderWidth.Attributes.Add("class", "DynamicHeaderTask");
                        widthdiv.Attributes.Add("class", "DynamicHeader3");
                    }
                    else
                    {
                        DynamicHeaderWidth.Attributes.Add("class", "DynamicHeader2");
                    }
                }
                if (FabCount == 5)
                {
                    if (TaskStatus == 1)
                    {
                        DynamicHeaderWidth.Attributes.Add("class", "DynamicHeaderTask");
                        widthdiv.Attributes.Add("class", "DynamicHeader3");
                    }
                    else
                    {
                        DynamicHeaderWidth.Attributes.Add("class", "DynamicHeader2");
                    }
                }
                if (FabCount == 6)
                {

                    if (TaskStatus == 1)
                    {
                        DynamicHeaderWidth.Attributes.Add("class", "DynamicHeaderTask");
                        widthdiv.Attributes.Add("class", "DynamicHeader3");
                        // grdcutavg.CssClass = "fab_avg_table";
                    }
                    else
                    {
                        DynamicHeaderWidth.Attributes.Add("class", "DynamicHeader2");
                    }

                }
                //end

                //fab1
                Label lblColorprintNo1 = (Label)e.Row.FindControl("lblColorprintNo1");
                Label lblCostAvgFile1 = (Label)e.Row.FindControl("lblCostAvgFile1");
                HyperLink hyplCostAvgFile1 = (HyperLink)e.Row.FindControl("hyplCostAvgFile1");
                //TextBox txtorderavg1 = (TextBox)e.Row.FindControl("txtorderavg1");       
                //HyperLink hyporderavgfile1 = (HyperLink)e.Row.FindControl("hyporderavgfile1");
                TextBox txtcutavg1 = (TextBox)e.Row.FindControl("txtcutavg1");
                HyperLink HyViewCutAvgFile1 = (HyperLink)e.Row.FindControl("HyViewCutAvgFile1");
                TextBox txtCostWidth1 = (TextBox)e.Row.FindControl("txtCostWidth1");
                TextBox txtOrderWidth1 = (TextBox)e.Row.FindControl("txtOrderWidth1");
                TextBox txtCutWidth1 = (TextBox)e.Row.FindControl("txtCutWidth1");
                HyperLink hyplwithtext1 = (HyperLink)e.Row.FindControl("hyplwithtext1");
                HyperLink HyclickCutAvgFile1 = (HyperLink)e.Row.FindControl("HyclickCutAvgFile1");
                HtmlAnchor lnkhistoryshow1 = (HtmlAnchor)e.Row.FindControl("lnkhistoryshow1");
                Label lblh1 = (Label)e.Row.FindControl("lblh1");

                HiddenField hdnCutAvg1 = (HiddenField)e.Row.FindControl("hdnCutAvg1");//new code



                //added by raghvinder on 19-08-2020 start
                //DropDownList ddlcutAvg_Unit1 = (DropDownList)e.Row.FindControl("ddlcutAvg_Unit1");
                //added by raghvinder on 19-08-2020 end

                //DataTable dt = objfabric.GetFabricAvg(Convert.ToInt32(hdnOderDetailID.Value), 2, 1);
                DataSet ds = objfabric.GetFabricAvg(Convert.ToInt32(hdnOderDetailID.Value), 2, 1);
                DataTable dt = ds.Tables[0];
                //DataTable dtUnit1 = ds.Tables[1];

                //int FabricQualityID = -1;
                //if (dt.Rows.Count > 0)
                //{
                //    FabricQualityID = Convert.ToInt32(dt.Rows[0]["FabricQualityID"].ToString());
                //}

                if (dt.Rows.Count > 0)
                {
                    //lblh1.Text = dt.Rows[0]["TextHistory"].ToString();
                    //string[] sdsd = dt.Rows[0]["TextHistory"].ToString().Replace("###", "<br>").Split(new string[] { "$$" }, StringSplitOptions.RemoveEmptyEntries);
                    //if (sdsd.Length > 0)
                    //{                      
                    //    lblh1.Text = lblh1.Text + sdsd[0].ToString();
                    //}
                    if (dt.Rows[0]["TextHistory"].ToString() != "")
                    {
                        lblh1.Text = bidh(dt.Rows[0]["TextHistory"].ToString().Replace("###", "<br>"));
                    }


                    //lblh1.Text = dt.Rows[0]["TextHistory"].ToString().Replace("###", "<br>");
                    lblHistory.Text += dt.Rows[0]["TextHistory"].ToString().Replace("###", "<br>");
                    //Alltexthistory += dt.Rows[0]["TextHistory"].ToString().Replace("###", "<br>");
                    if (dt.Rows[0]["TextHistory"].ToString() == "")
                    {
                        lnkhistoryshow1.Visible = false;
                    }

                    //lnkhistoryshow1.Attributes.Add("OnClick", "javaScript: return showhistory('block',this);");

                    string ColorPrint = dt.Rows[0]["colorprint"].ToString();
                    if (ColorPrint.Length > 10)
                    {
                        lblColorprintNo1.Text = ColorPrint.Substring(0, 10);
                        lblColorprintNo1.ToolTip = ColorPrint;
                    }
                    else
                    {
                        lblColorprintNo1.Text = ColorPrint;
                    }
                    //add code by bharat on 02-sep-20
                    string CostAvg1 = dt.Rows[0]["CostAvg"].ToString();

                    if (CostAvg1 == "0")
                    {
                        lblCostAvgFile1.Text = "";
                        hdnCostingAvg1.Value = "0";
                    }
                    else
                    {
                        lblCostAvgFile1.Text = CostAvg1;
                        hdnCostingAvg1.Value = CostAvg1;
                    }
                    //end
                    if (!string.IsNullOrEmpty(dt.Rows[0]["CostingAvgFile"].ToString()))
                        hyplCostAvgFile1.NavigateUrl = ProductionFolderPath + dt.Rows[0]["CostingAvgFile"].ToString();
                    else
                        hyplCostAvgFile1.Visible = false;

                    string OrderAvg1 = dt.Rows[0]["OrderAvg"].ToString();
                    if (OrderAvg1 == "0")
                    {
                        txtorderavg1.Text = "";
                    }
                    else
                    {
                        txtorderavg1.Text = OrderAvg1;
                        hdnOrderAvg1.Value = OrderAvg1;
                    }
                    //add code by bharat on 1-sep-20
                    //if (FabCount == 1)
                    //{
                    //    if (txtorderavg1.Text != "")
                    //    {
                    //        chkboxAccountMgr.Enabled = true;
                    //        messageHide.Attributes.Add("style", "display:none");
                    //    }
                    //}


                    //end
                    //if (!string.IsNullOrEmpty(dt.Rows[0]["OrderavgFile"].ToString()))
                    //    hyporderavgfile1.NavigateUrl = ProductionFolderPath + dt.Rows[0]["OrderavgFile"].ToString();
                    //else
                    //    hyporderavgfile1.Visible = false;

                    // txtcutavg1.Text = dt.Rows[0]["CutAvg"].ToString();
                    string cutAvg1 = dt.Rows[0]["CutAvg"] == DBNull.Value ? "" : dt.Rows[0]["CutAvg"].ToString();
                    if (cutAvg1 == "0" || cutAvg1 == "")
                    {
                        txtcutavg1.Text = "";
                    }
                    else
                    {
                        txtcutavg1.Text = cutAvg1;
                        //txtorderavg1.Attributes.Add("readonly", "readonly");
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["CutAvgFile"].ToString()))
                    {
                        HyViewCutAvgFile1.NavigateUrl = ProductionFolderPath + dt.Rows[0]["CutAvgFile"].ToString();
                        hdnCutAvg1.Value = "1";
                    }
                    else
                        HyViewCutAvgFile1.Visible = false;


                    if (!string.IsNullOrEmpty(dt.Rows[0]["costwidth"].ToString()))
                    {
                        txtCostWidth1.Text = dt.Rows[0]["costwidth"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[0]["OrderWidth"].ToString()) && dt.Rows[0]["OrderWidth"].ToString() != "0")
                    {
                        txtOrderWidth1.Text = dt.Rows[0]["OrderWidth"].ToString();
                    }

                    if (!string.IsNullOrEmpty(dt.Rows[0]["CutWidth"].ToString()) && dt.Rows[0]["CutWidth"].ToString() != "0")
                    {
                        txtCutWidth1.Text = dt.Rows[0]["CutWidth"].ToString();
                    }


                    // DataTable dtFabricUnit = new DataTable();
                    // dtFabricUnit = objwc.Get_FabricUnit_ForOrder(Convert.ToInt32(hdnOderDetailID.Value), FabricQualityID);
                    // int FabricUnit = 0, GarmentUnit = 0;
                    // if (dt.Rows.Count > 0)
                    // {
                    //     GarmentUnit = dt.Rows[0]["Unit"].ToString() == "" ? -1 : Convert.ToInt32(dt.Rows[0]["Unit"]);
                    // }

                    //if (dtFabricUnit.Rows.Count > 0)
                    //{
                    //    FabricUnit = Convert.ToInt32(dtFabricUnit.Rows[0]["FabricUnit"].ToString());
                    //}

                    // if (!string.IsNullOrEmpty(dtUnit1.Rows[0]["UnitName"].ToString()))
                    // {
                    //     ddlcutAvg_Unit1.DataSource = dtUnit1;
                    //     ddlcutAvg_Unit1.DataTextField = "UnitName";
                    //     ddlcutAvg_Unit1.DataValueField = "GroupUnitID";
                    //     ddlcutAvg_Unit1.DataBind();
                    //  //   ddlcutAvg_Unit1.SelectedValue = dt.Rows[0]["Unit"].ToString();
                    // }
                    // if (GarmentUnit > 0)
                    //     ddlcutAvg_Unit1.SelectedValue = GarmentUnit.ToString();
                    // else
                    //     ddlcutAvg_Unit1.SelectedValue = FabricUnit.ToString();

                    //23-09-2020 end
                    //added by raghvinder on 19-08-2020 end

                    //added by raghvinder on 27-10-2020 start
                    DataTable dtChecked = ds.Tables[2];
                    DataTable dtCutting = ds.Tables[3];

                    bool IsCheck = dtChecked.Rows[0]["IsApprovedAMForFabric"].ToString() == "" ? false : Convert.ToBoolean(dtChecked.Rows[0]["IsApprovedAMForFabric"]);
                    bool IsCutting = dtCutting.Rows[0]["IsCutting"].ToString() == "" ? false : Convert.ToBoolean(dtCutting.Rows[0]["IsCutting"]);

                    //if (IsCheck == true)
                    //{
                    //    ddlcutAvg_Unit1.Enabled = false;
                    //}
                    //else
                    //{
                    //    ddlcutAvg_Unit1.Enabled = true;
                    //}

                    if (IsCutting == true)
                    {
                        txtcutavg1.Enabled = false;
                        txtCostWidth1.Enabled = false;
                        txtOrderWidth1.Enabled = false;
                        txtCutWidth1.Enabled = false;
                        txtCostWidth1.Enabled = false;
                        txtorderavg1.Enabled = false;
                    }
                    else
                    {
                        txtcutavg1.Enabled = true;
                        txtCostWidth1.Enabled = true;
                        txtOrderWidth1.Enabled = true;
                        txtCutWidth1.Enabled = true;
                        txtCostWidth1.Enabled = true;
                        txtorderavg1.Enabled = true;
                    }
                    //added by raghvinder on 27-10-2020 end

                }
                else
                {
                    hyplCostAvgFile1.Visible = false;
                    //hyporderavgfile1.Visible = false;
                    HyViewCutAvgFile1.Visible = false;
                }

                //fab2
                Label lblColorprintNo2 = (Label)e.Row.FindControl("lblColorprintNo2");
                Label lblCostAvgFile2 = (Label)e.Row.FindControl("lblCostAvgFile2");
                HyperLink hyplCostAvgFile2 = (HyperLink)e.Row.FindControl("hyplCostAvgFile2");
                // TextBox txtorderavg2 = (TextBox)e.Row.FindControl("txtorderavg2");        
                //HyperLink hyporderavgfile2 = (HyperLink)e.Row.FindControl("hyporderavgfile2");
                TextBox txtcutavg2 = (TextBox)e.Row.FindControl("txtcutavg2");
                HyperLink HyViewCutAvgFile2 = (HyperLink)e.Row.FindControl("HyViewCutAvgFile2");
                TextBox txtCostWidth2 = (TextBox)e.Row.FindControl("txtCostWidth2");
                TextBox txtOrderWidth2 = (TextBox)e.Row.FindControl("txtOrderWidth2");
                TextBox txtCutWidth2 = (TextBox)e.Row.FindControl("txtCutWidth2");
                HyperLink hyplwithtext2 = (HyperLink)e.Row.FindControl("hyplwithtext2");
                HyperLink HyclickCutAvgFile2 = (HyperLink)e.Row.FindControl("HyclickCutAvgFile2");

                HiddenField hdnCutAvg2 = (HiddenField)e.Row.FindControl("hdnCutAvg2");//new code

                //added by raghvinder on 19-08-2020 start
                //DropDownList ddlcutAvg_Unit2 = (DropDownList)e.Row.FindControl("ddlcutAvg_Unit2");
                //added by raghvinder on 19-08-2020 end

                DataSet ds2 = objfabric.GetFabricAvg(Convert.ToInt32(hdnOderDetailID.Value), 2, 2);
                DataTable dt2 = ds2.Tables[0];
                // DataTable dtUnit2 = ds2.Tables[1];

                //int FabricQualityID2 = -1;
                //if (dt.Rows.Count > 0)
                //{
                //    FabricQualityID2 = Convert.ToInt32(dt.Rows[0]["FabricQualityID"].ToString());
                //}

                if (dt2.Rows.Count > 0)
                {
                    if (dt2.Rows[0]["TextHistory"].ToString() != "")
                    {
                        //lblh1.Text = dt2.Rows[0]["TextHistory"].ToString();
                        lblh1.Text = lblh1.Text + bidh(dt2.Rows[0]["TextHistory"].ToString().Replace("###", "<br>"));
                    }
                    //string[] sdsd = dt2.Rows[0]["TextHistory"].ToString().Replace("###", "<br>").Split(new string[] { "$$" }, StringSplitOptions.RemoveEmptyEntries);
                    //if (sdsd.Length > 0)
                    //{
                    //    lblh1.Text = lblh1.Text + sdsd[0].ToString();
                    //}

                    lblHistory.Text += dt2.Rows[0]["TextHistory"].ToString().Replace("###", "<br>");
                    // Alltexthistory += dt2.Rows[0]["TextHistory"].ToString().Replace("###", "<br>");
                    //if (dt.Rows[0]["TextHistory"].ToString() == "")
                    //{
                    //    lnkhistoryshow1.Visible = false;
                    //}
                    //lnkhistoryshow1.Attributes.Add("OnClick", "javaScript: return showhistory('block',1);");

                    //lblColorprintNo2.Text = dt2.Rows[0]["colorprint"].ToString();
                    string ColorPrint2 = dt2.Rows[0]["colorprint"].ToString();
                    if (ColorPrint2.Length > 10)
                    {
                        lblColorprintNo2.Text = ColorPrint2.Substring(0, 10);
                        lblColorprintNo2.ToolTip = ColorPrint2;
                    }
                    else
                    {
                        lblColorprintNo2.Text = ColorPrint2;
                    }
                    lblCostAvgFile2.Text = dt2.Rows[0]["CostAvg"].ToString();
                    hdnCostingAvg2.Value = dt2.Rows[0]["CostAvg"].ToString();
                    if (!string.IsNullOrEmpty(dt2.Rows[0]["CostingAvgFile"].ToString()))
                        hyplCostAvgFile2.NavigateUrl = ProductionFolderPath + dt2.Rows[0]["CostingAvgFile"].ToString();
                    else
                        hyplCostAvgFile2.Visible = false;

                    string OrderAvg2 = dt2.Rows[0]["OrderAvg"].ToString();
                    if (OrderAvg2 == "0")
                    {
                        txtorderavg2.Text = "";
                    }
                    else
                    {
                        txtorderavg2.Text = OrderAvg2;
                        hdnOrderAvg2.Value = OrderAvg2;
                    }
                    ////add code by bharat on 1-sep-20
                    //if (FabCount == 2)
                    //{

                    //    if ((txtorderavg1.Text != "0" && txtorderavg1.Text != "") && (txtorderavg2.Text != "0" && txtorderavg2.Text != ""))
                    //    {
                    //        chkboxAccountMgr.Enabled = true;
                    //        messageHide.Attributes.Add("style", "display:none");
                    //    }

                    //}
                    //end
                    //if (!string.IsNullOrEmpty(dt2.Rows[0]["OrderavgFile"].ToString()))
                    //    hyporderavgfile2.NavigateUrl = ProductionFolderPath + dt2.Rows[0]["OrderavgFile"].ToString();
                    //else
                    //    hyporderavgfile2.Visible = false;

                    // txtcutavg2.Text = dt2.Rows[0]["CutAvg"].ToString();
                    string cutAvg2 = dt2.Rows[0]["CutAvg"] == DBNull.Value ? "" : dt2.Rows[0]["CutAvg"].ToString();
                    if (cutAvg2 == "0" || cutAvg2 == "")
                    {
                        txtcutavg2.Text = "";
                    }
                    else
                    {
                        txtcutavg2.Text = cutAvg2;
                        // txtorderavg2.Attributes.Add("readonly", "readonly");
                    }
                    if (!string.IsNullOrEmpty(dt2.Rows[0]["CutAvgFile"].ToString()))
                    {
                        HyViewCutAvgFile2.NavigateUrl = ProductionFolderPath + dt2.Rows[0]["CutAvgFile"].ToString();
                        hdnCutAvg2.Value = "1";
                    }
                    else
                        HyViewCutAvgFile2.Visible = false;

                    if (!string.IsNullOrEmpty(dt2.Rows[0]["costwidth"].ToString()))
                    {
                        txtCostWidth2.Text = dt2.Rows[0]["costwidth"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt2.Rows[0]["OrderWidth"].ToString()) && dt2.Rows[0]["OrderWidth"].ToString() != "0")
                    {
                        txtOrderWidth2.Text = dt2.Rows[0]["OrderWidth"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt2.Rows[0]["CutWidth"].ToString()) && dt2.Rows[0]["CutWidth"].ToString() != "0")
                    {
                        txtCutWidth2.Text = dt2.Rows[0]["CutWidth"].ToString();
                    }

                    //added by raghvinder on 19-08-2020 start
                    //if (!string.IsNullOrEmpty(dt2.Rows[0]["Unit"].ToString()))
                    //{
                    //    ddlcutAvg_Unit2.SelectedValue = dt2.Rows[0]["Unit"].ToString();              
                    //}

                    //DataTable dtFabricUnit = new DataTable();
                    //dtFabricUnit = objwc.Get_FabricUnit_ForOrder(Convert.ToInt32(hdnOderDetailID.Value), FabricQualityID2);
                    //int FabricUnit = 0, GarmentUnit = 0;
                    //if (dtFabricUnit.Rows.Count > 0)
                    //{
                    //    //GarmentUnit = dt.Rows[0]["Unit"].ToString() == "" ? -1 : Convert.ToInt32(dt.Rows[0]["Unit"]);
                    //    GarmentUnit = dt2.Rows[0]["Unit"].ToString() == "" ? -1 : Convert.ToInt32(dt2.Rows[0]["Unit"]);

                    //}

                    //if (dtFabricUnit.Rows.Count > 0)
                    //{
                    //    FabricUnit = Convert.ToInt32(dtFabricUnit.Rows[0]["FabricUnit"].ToString());
                    //}
                    //if (!string.IsNullOrEmpty(dtUnit2.Rows[0]["UnitName"].ToString()))
                    //{
                    //    ddlcutAvg_Unit2.DataSource = dtUnit2;
                    //    ddlcutAvg_Unit2.DataTextField = "UnitName";
                    //    ddlcutAvg_Unit2.DataValueField = "GroupUnitID";
                    //    ddlcutAvg_Unit2.DataBind();
                    //    //ddlcutAvg_Unit2.SelectedValue = dt2.Rows[0]["Unit"].ToString();
                    //}

                    //if (GarmentUnit > 0)
                    //    ddlcutAvg_Unit2.SelectedValue = GarmentUnit.ToString();
                    //else
                    //    ddlcutAvg_Unit2.SelectedValue = FabricUnit.ToString();
                    //added by raghvinder on 19-08-2020 end

                    //added by raghvinder on 27-10-2020 start
                    DataTable dtChecked2 = ds.Tables[2];
                    DataTable dtCutting2 = ds.Tables[3];

                    bool IsCheck2 = dtChecked2.Rows[0]["IsApprovedAMForFabric"].ToString() == "" ? false : Convert.ToBoolean(dtChecked2.Rows[0]["IsApprovedAMForFabric"]);
                    bool IsCutting2 = dtCutting2.Rows[0]["IsCutting"].ToString() == "" ? false : Convert.ToBoolean(dtCutting2.Rows[0]["IsCutting"]);

                    //if (IsCheck2 == true)
                    //{
                    //    ddlcutAvg_Unit2.Enabled = false;
                    //}
                    //else
                    //{
                    //    ddlcutAvg_Unit2.Enabled = true;
                    //}

                    if (IsCutting2 == true)
                    {
                        txtcutavg2.Enabled = false;
                        txtCostWidth2.Enabled = false;
                        txtOrderWidth2.Enabled = false;
                        txtCutWidth2.Enabled = false;
                        txtCostWidth2.Enabled = false;
                        txtorderavg2.Enabled = false;
                    }
                    else
                    {
                        txtcutavg2.Enabled = true;
                        txtCostWidth2.Enabled = true;
                        txtOrderWidth2.Enabled = true;
                        txtCutWidth2.Enabled = true;
                        txtCostWidth2.Enabled = true;
                        txtorderavg2.Enabled = true;
                    }
                    //added by raghvinder on 27-10-2020 end
                }
                else
                {
                    hyplCostAvgFile2.Visible = false;
                    //hyporderavgfile2.Visible = false;
                    HyViewCutAvgFile2.Visible = false;
                }
                //fab3
                Label lblColorprintNo3 = (Label)e.Row.FindControl("lblColorprintNo3");
                Label lblCostAvgFile3 = (Label)e.Row.FindControl("lblCostAvgFile3");
                HyperLink hyplCostAvgFile3 = (HyperLink)e.Row.FindControl("hyplCostAvgFile3");
                //   TextBox txtorderavg3 = (TextBox)e.Row.FindControl("txtorderavg3");        
                //HyperLink hyporderavgfile3 = (HyperLink)e.Row.FindControl("hyporderavgfile3");
                TextBox txtcutavg3 = (TextBox)e.Row.FindControl("txtcutavg3");
                HyperLink HyViewCutAvgFile3 = (HyperLink)e.Row.FindControl("HyViewCutAvgFile3");
                TextBox txtCostWidth3 = (TextBox)e.Row.FindControl("txtCostWidth3");
                TextBox txtOrderWidth3 = (TextBox)e.Row.FindControl("txtOrderWidth3");
                TextBox txtCutWidth3 = (TextBox)e.Row.FindControl("txtCutWidth3");
                HyperLink hyplwithtext3 = (HyperLink)e.Row.FindControl("hyplwithtext3");
                HyperLink HyclickCutAvgFile3 = (HyperLink)e.Row.FindControl("HyclickCutAvgFile3");

                HiddenField hdnCutAvg3 = (HiddenField)e.Row.FindControl("hdnCutAvg3");//new code

                //added by raghvinder on 19-08-2020 start
                //DropDownList ddlcutAvg_Unit3 = (DropDownList)e.Row.FindControl("ddlcutAvg_Unit3");
                //added by raghvinder on 19-08-2020 end

                //DataTable dt3 = objfabric.GetFabricAvg(Convert.ToInt32(hdnOderDetailID.Value), 2, 3);
                DataSet ds3 = objfabric.GetFabricAvg(Convert.ToInt32(hdnOderDetailID.Value), 2, 3);
                DataTable dt3 = ds3.Tables[0];
                //DataTable dtUnit3 = ds3.Tables[1];

                //int FabricQualityID3 = -1;
                //if (dt.Rows.Count > 0)
                //{
                //    FabricQualityID3 = Convert.ToInt32(dt.Rows[0]["FabricQualityID"].ToString());
                //}

                if (dt3.Rows.Count > 0)
                {
                    if (dt3.Rows[0]["TextHistory"].ToString() != "")
                    {
                        //lblh1.Text = dt3.Rows[0]["TextHistory"].ToString();
                        lblh1.Text = lblh1.Text + bidh(dt3.Rows[0]["TextHistory"].ToString().Replace("###", "<br>"));
                    }
                    //string[] sdsd = dt3.Rows[0]["TextHistory"].ToString().Replace("###", "<br>").Split(new string[] { "$$" }, StringSplitOptions.RemoveEmptyEntries);
                    //if (sdsd.Length > 0)
                    //{
                    //    lblh1.Text = lblh1.Text + sdsd[0].ToString();
                    //}

                    //  lblh1.Text = lblh1.Text + dt3.Rows[0]["TextHistory"].ToString().Replace("###", "<br>");
                    lblHistory.Text += dt3.Rows[0]["TextHistory"].ToString().Replace("###", "<br>");
                    //Alltexthistory += dt3.Rows[0]["TextHistory"].ToString().Replace("###", "<br>");
                    //lblh1.Text = dt3.Rows[0]["TextHistory"].ToString().Replace("###", "<br>");
                    //if (dt.Rows[0]["TextHistory"].ToString() == "")
                    //{
                    //    lnkhistoryshow1.Visible = false;
                    //}
                    //lnkhistoryshow1.Attributes.Add("OnClick", "javaScript: return showhistory('block',1);");
                    //lblColorprintNo3.Text = dt3.Rows[0]["colorprint"].ToString();
                    string ColorPrint3 = dt3.Rows[0]["colorprint"].ToString();
                    if (ColorPrint3.Length > 10)
                    {
                        lblColorprintNo3.Text = ColorPrint3.Substring(0, 10);
                        lblColorprintNo3.ToolTip = ColorPrint3;
                    }
                    else
                    {
                        lblColorprintNo3.Text = ColorPrint3;
                    }

                    lblCostAvgFile3.Text = dt3.Rows[0]["CostAvg"].ToString();
                    hdnCostingAvg3.Value = dt3.Rows[0]["CostAvg"].ToString();
                    if (!string.IsNullOrEmpty(dt3.Rows[0]["CostingAvgFile"].ToString()))
                        hyplCostAvgFile3.NavigateUrl = ProductionFolderPath + dt3.Rows[0]["CostingAvgFile"].ToString();
                    else
                        hyplCostAvgFile3.Visible = false;


                    string OrderAvg3 = dt3.Rows[0]["OrderAvg"].ToString();
                    if (OrderAvg3 == "0")
                    {
                        txtorderavg3.Text = "";
                    }
                    else
                    {
                        txtorderavg3.Text = OrderAvg3;
                        hdnOrderAvg3.Value = OrderAvg3;
                    }
                    ////add code by bharat on 1-sep-20
                    //if (FabCount == 3)
                    //{
                    //    if (txtorderavg1.Text != "" && txtorderavg2.Text != "" && txtorderavg3.Text != "")
                    //    {
                    //        chkboxAccountMgr.Enabled = true;
                    //        messageHide.Attributes.Add("style", "display:none");
                    //    }
                    //}
                    //end
                    //if (!string.IsNullOrEmpty(dt3.Rows[0]["OrderavgFile"].ToString()))
                    //    hyporderavgfile3.NavigateUrl = ProductionFolderPath + dt3.Rows[0]["OrderavgFile"].ToString();
                    //else
                    //    hyporderavgfile3.Visible = false;

                    // txtcutavg3.Text = dt3.Rows[0]["CutAvg"].ToString();
                    string cutAvg3 = dt3.Rows[0]["CutAvg"] == DBNull.Value ? "" : dt3.Rows[0]["CutAvg"].ToString();
                    if (cutAvg3 == "0" || cutAvg3 == "")
                    {
                        txtcutavg3.Text = "";
                    }
                    else
                    {
                        txtcutavg3.Text = cutAvg3;
                        //   txtorderavg3.Attributes.Add("readonly", "readonly");
                    }

                    if (!string.IsNullOrEmpty(dt3.Rows[0]["CutAvgFile"].ToString()))
                    {
                        HyViewCutAvgFile3.NavigateUrl = ProductionFolderPath + dt3.Rows[0]["CutAvgFile"].ToString();
                        hdnCutAvg3.Value = "1";
                    }
                    else
                        HyViewCutAvgFile3.Visible = false;

                    if (!string.IsNullOrEmpty(dt3.Rows[0]["costwidth"].ToString()))
                    {
                        txtCostWidth3.Text = dt3.Rows[0]["costwidth"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt3.Rows[0]["OrderWidth"].ToString()) && dt3.Rows[0]["OrderWidth"].ToString() != "0")
                    {
                        txtOrderWidth3.Text = dt3.Rows[0]["OrderWidth"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt3.Rows[0]["CutWidth"].ToString()) && dt3.Rows[0]["CutWidth"].ToString() != "0")
                    {
                        txtCutWidth3.Text = dt3.Rows[0]["CutWidth"].ToString();
                    }

                    //added by raghvinder on 19-08-2020 start
                    //if (!string.IsNullOrEmpty(dt3.Rows[0]["Unit"].ToString()))
                    //{
                    //    ddlcutAvg_Unit3.SelectedValue = dt3.Rows[0]["Unit"].ToString();
                    //}

                    //DataTable dtFabricUnit = new DataTable();
                    //dtFabricUnit = objwc.Get_FabricUnit_ForOrder(Convert.ToInt32(hdnOderDetailID.Value), FabricQualityID3);
                    //int FabricUnit = 0, GarmentUnit = 0;
                    //if (dtFabricUnit.Rows.Count > 0)
                    //{
                    //    //GarmentUnit = dt.Rows[0]["Unit"].ToString() == "" ? -1 : Convert.ToInt32(dt.Rows[0]["Unit"]);
                    //    GarmentUnit = dt3.Rows[0]["Unit"].ToString() == "" ? -1 : Convert.ToInt32(dt3.Rows[0]["Unit"]);
                    //}

                    //if (dtFabricUnit.Rows.Count > 0)
                    //{
                    //    FabricUnit = Convert.ToInt32(dtFabricUnit.Rows[0]["FabricUnit"].ToString());
                    //}

                    //if (!string.IsNullOrEmpty(dtUnit3.Rows[0]["UnitName"].ToString()))
                    //{
                    //    ddlcutAvg_Unit3.DataSource = dtUnit3;
                    //    ddlcutAvg_Unit3.DataTextField = "UnitName";
                    //    ddlcutAvg_Unit3.DataValueField = "GroupUnitID";
                    //    ddlcutAvg_Unit3.DataBind();
                    //    //ddlcutAvg_Unit3.SelectedValue = dt3.Rows[0]["Unit"].ToString();
                    //}

                    //if (GarmentUnit > 0)
                    //    ddlcutAvg_Unit3.SelectedValue = GarmentUnit.ToString();
                    //else
                    //    ddlcutAvg_Unit3.SelectedValue = FabricUnit.ToString();
                    //added by raghvinder on 19-08-2020 end

                    //added by raghvinder on 27-10-2020 start
                    DataTable dtChecked3 = ds.Tables[2];
                    DataTable dtCutting3 = ds.Tables[3];

                    bool IsCheck3 = dtChecked3.Rows[0]["IsApprovedAMForFabric"].ToString() == "" ? false : Convert.ToBoolean(dtChecked3.Rows[0]["IsApprovedAMForFabric"]);
                    bool IsCutting3 = dtCutting3.Rows[0]["IsCutting"].ToString() == "" ? false : Convert.ToBoolean(dtCutting3.Rows[0]["IsCutting"]);

                    //if (IsCheck3 == true)
                    //{
                    //    ddlcutAvg_Unit3.Enabled = false;
                    //}
                    //else
                    //{
                    //    ddlcutAvg_Unit3.Enabled = true;
                    //}

                    if (IsCutting3 == true)
                    {
                        txtcutavg3.Enabled = false;
                        txtCostWidth3.Enabled = false;
                        txtOrderWidth3.Enabled = false;
                        txtCutWidth3.Enabled = false;
                        txtCostWidth3.Enabled = false;
                        txtorderavg3.Enabled = false;
                    }
                    else
                    {
                        txtcutavg3.Enabled = true;
                        txtCostWidth3.Enabled = true;
                        txtOrderWidth3.Enabled = true;
                        txtCutWidth3.Enabled = true;
                        txtCostWidth3.Enabled = true;
                        txtorderavg3.Enabled = true;
                    }
                    //added by raghvinder on 27-10-2020 end
                }

                else
                {
                    hyplCostAvgFile3.Visible = false;
                    //hyporderavgfile3.Visible = false;
                    HyViewCutAvgFile3.Visible = false;
                }
                //fab4
                Label lblColorprintNo4 = (Label)e.Row.FindControl("lblColorprintNo4");
                Label lblCostAvgFile4 = (Label)e.Row.FindControl("lblCostAvgFile4");
                HyperLink hyplCostAvgFile4 = (HyperLink)e.Row.FindControl("hyplCostAvgFile4");
                //TextBox txtorderavg4 = (TextBox)e.Row.FindControl("txtorderavg4");        
                //HyperLink hyporderavgfile4 = (HyperLink)e.Row.FindControl("hyporderavgfile4");
                TextBox txtcutavg4 = (TextBox)e.Row.FindControl("txtcutavg4");
                HyperLink HyViewCutAvgFile4 = (HyperLink)e.Row.FindControl("HyViewCutAvgFile4");
                TextBox txtCostWidth4 = (TextBox)e.Row.FindControl("txtCostWidth4");
                TextBox txtOrderWidth4 = (TextBox)e.Row.FindControl("txtOrderWidth4");
                TextBox txtCutWidth4 = (TextBox)e.Row.FindControl("txtCutWidth4");
                HyperLink hyplwithtext4 = (HyperLink)e.Row.FindControl("hyplwithtext4");
                HyperLink HyclickCutAvgFile4 = (HyperLink)e.Row.FindControl("HyclickCutAvgFile4");

                HiddenField hdnCutAvg4 = (HiddenField)e.Row.FindControl("hdnCutAvg4");//new code

                //added by raghvinder on 19-08-2020 start
                //DropDownList ddlcutAvg_Unit4 = (DropDownList)e.Row.FindControl("ddlcutAvg_Unit4");
                //added by raghvinder on 19-08-2020 end

                //DataTable dt4 = objfabric.GetFabricAvg(Convert.ToInt32(hdnOderDetailID.Value), 2, 4);
                DataSet ds4 = objfabric.GetFabricAvg(Convert.ToInt32(hdnOderDetailID.Value), 2, 4);
                DataTable dt4 = ds4.Tables[0];
                //DataTable dtUnit4 = ds4.Tables[1];

                //int FabricQualityID4 = -1;
                //if (dt.Rows.Count > 0)
                //{
                //    FabricQualityID4 = Convert.ToInt32(dt.Rows[0]["FabricQualityID"].ToString());
                //}

                if (dt4.Rows.Count > 0)
                {
                    if (dt4.Rows[0]["TextHistory"].ToString() != "")
                    {
                        //lblh1.Text = dt4.Rows[0]["TextHistory"].ToString();
                        lblh1.Text = lblh1.Text + bidh(dt4.Rows[0]["TextHistory"].ToString().Replace("###", "<br>"));
                    }
                    //string[] sdsd = dt4.Rows[0]["TextHistory"].ToString().Replace("###", "<br>").Split(new string[] { "$$" }, StringSplitOptions.RemoveEmptyEntries);
                    //if (sdsd.Length > 0)
                    //{
                    //    lblh1.Text = lblh1.Text + sdsd[0].ToString();
                    //}

                    // lblh1.Text = lblh1.Text + dt4.Rows[0]["TextHistory"].ToString().Replace("###", "<br>");
                    lblHistory.Text += dt4.Rows[0]["TextHistory"].ToString().Replace("###", "<br>");
                    // Alltexthistory += dt4.Rows[0]["TextHistory"].ToString().Replace("###", "<br>");
                    //lblh1.Text = dt4.Rows[0]["TextHistory"].ToString().Replace("###", "<br>");
                    //if (dt.Rows[0]["TextHistory"].ToString() == "")
                    //{
                    //    lnkhistoryshow1.Visible = false;
                    //}
                    //lnkhistoryshow1.Attributes.Add("OnClick", "javaScript: return showhistory('block',1);");

                    // lblColorprintNo4.Text = dt4.Rows[0]["colorprint"].ToString();
                    string ColorPrint4 = dt4.Rows[0]["colorprint"].ToString();
                    if (ColorPrint4.Length > 10)
                    {
                        lblColorprintNo4.Text = ColorPrint4.Substring(0, 10);
                        lblColorprintNo4.ToolTip = ColorPrint4;
                    }
                    else
                    {
                        lblColorprintNo4.Text = ColorPrint4;
                    }

                    lblCostAvgFile4.Text = dt4.Rows[0]["CostAvg"].ToString();
                    hdnCostingAvg4.Value = dt4.Rows[0]["CostAvg"].ToString();
                    if (!string.IsNullOrEmpty(dt4.Rows[0]["CostingAvgFile"].ToString()))
                        hyplCostAvgFile4.NavigateUrl = ProductionFolderPath + dt4.Rows[0]["CostingAvgFile"].ToString();
                    else
                        hyplCostAvgFile4.Visible = false;

                    // txtorderavg4.Text = dt4.Rows[0]["OrderAvg"].ToString();
                    string OrderAvg4 = dt4.Rows[0]["OrderAvg"].ToString();
                    if (OrderAvg4 == "0")
                    {
                        txtorderavg4.Text = "";
                    }
                    else
                    {
                        txtorderavg4.Text = OrderAvg4;
                        hdnOrderAvg4.Value = OrderAvg4;
                    }
                    ////add code by bharat on 1-sep-20
                    //if (FabCount == 4)
                    //{
                    //    if (txtorderavg1.Text != "" && txtorderavg2.Text != "" && txtorderavg3.Text != "" && txtorderavg4.Text != "")
                    //    {
                    //        chkboxAccountMgr.Enabled = true;
                    //        messageHide.Attributes.Add("style", "display:none");
                    //    }
                    //}
                    //end
                    //if (!string.IsNullOrEmpty(dt4.Rows[0]["OrderavgFile"].ToString()))
                    //    hyporderavgfile4.NavigateUrl = ProductionFolderPath + dt4.Rows[0]["OrderavgFile"].ToString();
                    //else
                    //    hyporderavgfile4.Visible = false;

                    // txtcutavg4.Text = dt4.Rows[0]["CutAvg"].ToString();
                    string cutAvg4 = dt4.Rows[0]["CutAvg"] == DBNull.Value ? "" : dt4.Rows[0]["CutAvg"].ToString();
                    if (cutAvg4 == "0" || cutAvg4 == "")
                    {
                        txtcutavg4.Text = "";
                    }
                    else
                    {
                        txtcutavg4.Text = cutAvg4;
                        //  txtorderavg4.Attributes.Add("readonly", "readonly");
                    }
                    if (!string.IsNullOrEmpty(dt4.Rows[0]["CutAvgFile"].ToString()))
                    {
                        HyViewCutAvgFile4.NavigateUrl = ProductionFolderPath + dt4.Rows[0]["CutAvgFile"].ToString();
                        hdnCutAvg4.Value = "1";
                    }
                    else
                        HyViewCutAvgFile4.Visible = false;

                    if (!string.IsNullOrEmpty(dt4.Rows[0]["costwidth"].ToString()))
                    {
                        txtCostWidth4.Text = dt4.Rows[0]["costwidth"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt4.Rows[0]["OrderWidth"].ToString()) && dt4.Rows[0]["OrderWidth"].ToString() != "0")
                    {
                        txtOrderWidth4.Text = dt4.Rows[0]["OrderWidth"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt4.Rows[0]["CutWidth"].ToString()) && dt4.Rows[0]["CutWidth"].ToString() != "0")
                    {
                        txtCutWidth4.Text = dt4.Rows[0]["CutWidth"].ToString();
                    }

                    //added by raghvinder on 19-08-2020 start
                    //if (!string.IsNullOrEmpty(dt4.Rows[0]["Unit"].ToString()))
                    //{
                    //    ddlcutAvg_Unit4.SelectedValue = dt4.Rows[0]["Unit"].ToString();
                    //}
                    //DataTable dtFabricUnit = new DataTable();
                    //dtFabricUnit = objwc.Get_FabricUnit_ForOrder(Convert.ToInt32(hdnOderDetailID.Value), FabricQualityID4);
                    //int FabricUnit = 0, GarmentUnit = 0;
                    //if (dtFabricUnit.Rows.Count > 0)
                    //{
                    //    //GarmentUnit = dt.Rows[0]["Unit"].ToString() == "" ? -1 : Convert.ToInt32(dt.Rows[0]["Unit"]);
                    //    GarmentUnit = dt4.Rows[0]["Unit"].ToString() == "" ? -1 : Convert.ToInt32(dt4.Rows[0]["Unit"]);
                    //}

                    //if (dtFabricUnit.Rows.Count > 0)
                    //{
                    //    FabricUnit = Convert.ToInt32(dtFabricUnit.Rows[0]["FabricUnit"].ToString());
                    //}
                    //if (!string.IsNullOrEmpty(dtUnit4.Rows[0]["UnitName"].ToString()))
                    //{
                    //    ddlcutAvg_Unit4.DataSource = dtUnit4;
                    //    ddlcutAvg_Unit4.DataTextField = "UnitName";
                    //    ddlcutAvg_Unit4.DataValueField = "GroupUnitID";
                    //    ddlcutAvg_Unit4.DataBind();
                    //    //ddlcutAvg_Unit4.SelectedValue = dt4.Rows[0]["Unit"].ToString();
                    //}

                    //if (GarmentUnit > 0)
                    //    ddlcutAvg_Unit4.SelectedValue = GarmentUnit.ToString();
                    //else
                    //    ddlcutAvg_Unit4.SelectedValue = FabricUnit.ToString();
                    //added by raghvinder on 19-08-2020 end

                    //added by raghvinder on 27-10-2020 start
                    DataTable dtChecked4 = ds.Tables[2];
                    DataTable dtCutting4 = ds.Tables[3];

                    bool IsCheck4 = dtChecked4.Rows[0]["IsApprovedAMForFabric"].ToString() == "" ? false : Convert.ToBoolean(dtChecked4.Rows[0]["IsApprovedAMForFabric"]);
                    bool IsCutting4 = dtCutting4.Rows[0]["IsCutting"].ToString() == "" ? false : Convert.ToBoolean(dtCutting4.Rows[0]["IsCutting"]);

                    //if (IsCheck4 == true)
                    //{
                    //    ddlcutAvg_Unit4.Enabled = false;
                    //}
                    //else
                    //{
                    //    ddlcutAvg_Unit4.Enabled = true;
                    //}

                    if (IsCutting4 == true)
                    {
                        txtcutavg4.Enabled = false;
                        txtCostWidth4.Enabled = false;
                        txtOrderWidth4.Enabled = false;
                        txtCutWidth4.Enabled = false;
                        txtCostWidth4.Enabled = false;
                        txtorderavg4.Enabled = false;
                    }
                    else
                    {
                        txtcutavg4.Enabled = true;
                        txtCostWidth4.Enabled = true;
                        txtOrderWidth4.Enabled = true;
                        txtCutWidth4.Enabled = true;
                        txtCostWidth4.Enabled = true;
                        txtorderavg4.Enabled = true;
                    }
                    //added by raghvinder on 27-10-2020 end

                }
                else
                {
                    hyplCostAvgFile4.Visible = false;
                    //hyporderavgfile4.Visible = false;
                    HyViewCutAvgFile4.Visible = false;
                }
                //fab5
                Label lblColorprintNo5 = (Label)e.Row.FindControl("lblColorprintNo5");
                Label lblCostAvgFile5 = (Label)e.Row.FindControl("lblCostAvgFile5");
                HyperLink hyplCostAvgFile5 = (HyperLink)e.Row.FindControl("hyplCostAvgFile5");
                //  TextBox txtorderavg5 = (TextBox)e.Row.FindControl("txtorderavg5");        
                //HyperLink hyporderavgfile5 = (HyperLink)e.Row.FindControl("hyporderavgfile5");
                TextBox txtcutavg5 = (TextBox)e.Row.FindControl("txtcutavg5");
                HyperLink HyViewCutAvgFile5 = (HyperLink)e.Row.FindControl("HyViewCutAvgFile5");
                TextBox txtCostWidth5 = (TextBox)e.Row.FindControl("txtCostWidth5");
                TextBox txtOrderWidth5 = (TextBox)e.Row.FindControl("txtOrderWidth5");
                TextBox txtCutWidth5 = (TextBox)e.Row.FindControl("txtCutWidth5");
                HyperLink hyplwithtext5 = (HyperLink)e.Row.FindControl("hyplwithtext5");
                HyperLink HyclickCutAvgFile5 = (HyperLink)e.Row.FindControl("HyclickCutAvgFile5");

                HiddenField hdnCutAvg5 = (HiddenField)e.Row.FindControl("hdnCutAvg5");//new code

                //added by raghvinder on 19-08-2020 start
                //DropDownList ddlcutAvg_Unit5 = (DropDownList)e.Row.FindControl("ddlcutAvg_Unit5");
                //added by raghvinder on 19-08-2020 end

                //DataTable dt5 = objfabric.GetFabricAvg(Convert.ToInt32(hdnOderDetailID.Value), 2, 5);

                DataSet ds5 = objfabric.GetFabricAvg(Convert.ToInt32(hdnOderDetailID.Value), 2, 5);
                DataTable dt5 = ds5.Tables[0];
                //DataTable dtUnit5 = ds5.Tables[1];

                //int FabricQualityID5 = -1;
                //if (dt.Rows.Count > 0)
                //{
                //    FabricQualityID5 = Convert.ToInt32(dt.Rows[0]["FabricQualityID"].ToString());
                //}

                if (dt5.Rows.Count > 0)
                {
                    //lblh1.Text = lblh1.Text + dt5.Rows[0]["TextHistory"].ToString().Replace("###", "<br>");
                    if (dt5.Rows[0]["TextHistory"].ToString() != "")
                    {
                        //lblh1.Text = dt5.Rows[0]["TextHistory"].ToString();
                        lblh1.Text = lblh1.Text + bidh(dt5.Rows[0]["TextHistory"].ToString().Replace("###", "<br>"));
                    }
                    string[] sdsd = dt5.Rows[0]["TextHistory"].ToString().Replace("###", "<br>").Split(new string[] { "$$" }, StringSplitOptions.RemoveEmptyEntries);
                    if (sdsd.Length > 0)
                    {
                        lblh1.Text = lblh1.Text + sdsd[0].ToString();
                    }

                    lblHistory.Text += dt5.Rows[0]["TextHistory"].ToString().Replace("###", "<br>");
                    // Alltexthistory += dt5.Rows[0]["TextHistory"].ToString().Replace("###", "<br>");
                    // lblColorprintNo5.Text = dt5.Rows[0]["colorprint"].ToString();
                    //lblh1.Text = dt5.Rows[0]["TextHistory"].ToString().Replace("###", "<br>");
                    //if (dt.Rows[0]["TextHistory"].ToString() == "")
                    //{
                    //    lnkhistoryshow1.Visible = false;
                    //}
                    //lnkhistoryshow1.Attributes.Add("OnClick", "javaScript: return showhistory('block',1);");
                    string ColorPrint5 = dt5.Rows[0]["colorprint"].ToString();
                    if (ColorPrint5.Length > 10)
                    {
                        lblColorprintNo5.Text = ColorPrint5.Substring(0, 10);
                        lblColorprintNo5.ToolTip = ColorPrint5;
                    }
                    else
                    {
                        lblColorprintNo5.Text = ColorPrint5;
                    }
                    lblCostAvgFile5.Text = dt5.Rows[0]["CostAvg"].ToString();
                    hdnCostingAvg5.Value = dt5.Rows[0]["CostAvg"].ToString();
                    if (!string.IsNullOrEmpty(dt5.Rows[0]["CostingAvgFile"].ToString()))
                        hyplCostAvgFile5.NavigateUrl = ProductionFolderPath + dt5.Rows[0]["CostingAvgFile"].ToString();
                    else
                        hyplCostAvgFile5.Visible = false;

                    //  txtorderavg5.Text = dt5.Rows[0]["OrderAvg"].ToString();
                    string OrderAvg5 = dt5.Rows[0]["OrderAvg"].ToString();
                    if (OrderAvg5 == "0")
                    {
                        txtorderavg5.Text = "";
                    }
                    else
                    {
                        txtorderavg5.Text = OrderAvg5;
                        hdnOrderAvg5.Value = OrderAvg5;
                    }
                    ////add code by bharat on 1-sep-20
                    //if (FabCount == 5)
                    //{
                    //    if (txtorderavg1.Text != "" && txtorderavg2.Text != "" && txtorderavg3.Text != "" && txtorderavg4.Text != "" && txtorderavg5.Text != "")
                    //    {
                    //        chkboxAccountMgr.Enabled = true;
                    //        messageHide.Attributes.Add("style", "display:none");
                    //    }
                    //}
                    //end
                    //if (!string.IsNullOrEmpty(dt5.Rows[0]["OrderavgFile"].ToString()))
                    //    hyporderavgfile5.NavigateUrl = ProductionFolderPath + dt5.Rows[0]["OrderavgFile"].ToString();
                    //else
                    //    hyporderavgfile5.Visible = false;

                    // txtcutavg5.Text = dt5.Rows[0]["CutAvg"].ToString();
                    string cutAvg5 = dt5.Rows[0]["CutAvg"] == DBNull.Value ? "" : dt5.Rows[0]["CutAvg"].ToString();
                    if (cutAvg5 == "0" || cutAvg5 == "")
                    {
                        txtcutavg5.Text = "";
                    }
                    else
                    {
                        txtcutavg5.Text = cutAvg5;
                        // txtorderavg5.Attributes.Add("readonly", "readonly");
                    }
                    if (!string.IsNullOrEmpty(dt5.Rows[0]["CutAvgFile"].ToString()))
                    {
                        HyViewCutAvgFile5.NavigateUrl = ProductionFolderPath + dt5.Rows[0]["CutAvgFile"].ToString();
                        hdnCutAvg5.Value = "1";
                    }
                    else
                        HyViewCutAvgFile5.Visible = false;

                    if (!string.IsNullOrEmpty(dt5.Rows[0]["costwidth"].ToString()))
                    {
                        txtCostWidth5.Text = dt5.Rows[0]["costwidth"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt5.Rows[0]["OrderWidth"].ToString()) && dt5.Rows[0]["OrderWidth"].ToString() != "0")
                    {
                        txtOrderWidth5.Text = dt5.Rows[0]["OrderWidth"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt5.Rows[0]["CutWidth"].ToString()) && dt5.Rows[0]["CutWidth"].ToString() != "0")
                    {
                        txtCutWidth5.Text = dt5.Rows[0]["CutWidth"].ToString();
                    }

                    //added by raghvinder on 19-08-2020 start
                    //if (!string.IsNullOrEmpty(dt5.Rows[0]["Unit"].ToString()))
                    //{
                    //    ddlcutAvg_Unit5.SelectedValue = dt5.Rows[0]["Unit"].ToString();
                    //}

                    //DataTable dtFabricUnit = new DataTable();
                    //dtFabricUnit = objwc.Get_FabricUnit_ForOrder(Convert.ToInt32(hdnOderDetailID.Value), FabricQualityID5);
                    //int FabricUnit = 0, GarmentUnit = 0;
                    //if (dtFabricUnit.Rows.Count > 0)
                    //{
                    //    //GarmentUnit = dt.Rows[0]["Unit"].ToString() == "" ? -1 : Convert.ToInt32(dt.Rows[0]["Unit"]);
                    //    GarmentUnit = dt5.Rows[0]["Unit"].ToString() == "" ? -1 : Convert.ToInt32(dt5.Rows[0]["Unit"]);
                    //}

                    //if (dtFabricUnit.Rows.Count > 0)
                    //{
                    //    FabricUnit = Convert.ToInt32(dtFabricUnit.Rows[0]["FabricUnit"].ToString());
                    //}

                    //if (!string.IsNullOrEmpty(dtUnit5.Rows[0]["UnitName"].ToString()))
                    //{
                    //    ddlcutAvg_Unit5.DataSource = dtUnit5;
                    //    ddlcutAvg_Unit5.DataTextField = "UnitName";
                    //    ddlcutAvg_Unit5.DataValueField = "GroupUnitID";
                    //    ddlcutAvg_Unit5.DataBind();
                    //    //ddlcutAvg_Unit5.SelectedValue = dt5.Rows[0]["Unit"].ToString();
                    //}

                    //if (GarmentUnit > 0)
                    //    ddlcutAvg_Unit5.SelectedValue = GarmentUnit.ToString();
                    //else
                    //    ddlcutAvg_Unit5.SelectedValue = FabricUnit.ToString();
                    //added by raghvinder on 19-08-2020 end

                    //added by raghvinder on 27-10-2020 start
                    DataTable dtChecked5 = ds.Tables[2];
                    DataTable dtCutting5 = ds.Tables[3];

                    bool IsCheck5 = dtChecked5.Rows[0]["IsApprovedAMForFabric"].ToString() == "" ? false : Convert.ToBoolean(dtChecked5.Rows[0]["IsApprovedAMForFabric"]);
                    bool IsCutting5 = dtCutting5.Rows[0]["IsCutting"].ToString() == "" ? false : Convert.ToBoolean(dtCutting5.Rows[0]["IsCutting"]);

                    //if (IsCheck5 == true)
                    //{
                    //    ddlcutAvg_Unit5.Enabled = false;
                    //}
                    //else
                    //{
                    //    ddlcutAvg_Unit5.Enabled = true;
                    //}

                    if (IsCutting5 == true)
                    {
                        txtcutavg5.Enabled = false;
                        txtCostWidth5.Enabled = false;
                        txtOrderWidth5.Enabled = false;
                        txtCutWidth5.Enabled = false;
                        txtCostWidth5.Enabled = false;
                        txtorderavg5.Enabled = false;
                    }
                    else
                    {
                        txtcutavg5.Enabled = true;
                        txtCostWidth5.Enabled = true;
                        txtOrderWidth5.Enabled = true;
                        txtCutWidth5.Enabled = true;
                        txtCostWidth5.Enabled = true;
                        txtorderavg5.Enabled = true;
                    }
                    //added by raghvinder on 27-10-2020 end

                }
                else
                {
                    hyplCostAvgFile5.Visible = false;
                    //hyporderavgfile5.Visible = false;
                    HyViewCutAvgFile5.Visible = false;
                }
                //fab6
                Label lblColorprintNo6 = (Label)e.Row.FindControl("lblColorprintNo6");
                Label lblCostAvgFile6 = (Label)e.Row.FindControl("lblCostAvgFile6");
                HyperLink hyplCostAvgFile6 = (HyperLink)e.Row.FindControl("hyplCostAvgFile6");
                //  TextBox txtorderavg6 = (TextBox)e.Row.FindControl("txtorderavg6");        
                //HyperLink hyporderavgfile6 = (HyperLink)e.Row.FindControl("hyporderavgfile6");
                TextBox txtcutavg6 = (TextBox)e.Row.FindControl("txtcutavg6");
                HyperLink HyViewCutAvgFile6 = (HyperLink)e.Row.FindControl("HyViewCutAvgFile6");
                TextBox txtCostWidth6 = (TextBox)e.Row.FindControl("txtCostWidth6");
                TextBox txtOrderWidth6 = (TextBox)e.Row.FindControl("txtOrderWidth6");
                TextBox txtCutWidth6 = (TextBox)e.Row.FindControl("txtCutWidth6");
                HyperLink hyplwithtext6 = (HyperLink)e.Row.FindControl("hyplwithtext6");
                HyperLink HyclickCutAvgFile6 = (HyperLink)e.Row.FindControl("HyclickCutAvgFile6");

                HiddenField hdnCutAvg6 = (HiddenField)e.Row.FindControl("hdnCutAvg6");

                //added by raghvinder on 19-08-2020 start
                // DropDownList ddlcutAvg_Unit6 = (DropDownList)e.Row.FindControl("ddlcutAvg_Unit6");
                //added by raghvinder on 19-08-2020 end

                //DataTable dt6 = objfabric.GetFabricAvg(Convert.ToInt32(hdnOderDetailID.Value), 2, 6);
                DataSet ds6 = objfabric.GetFabricAvg(Convert.ToInt32(hdnOderDetailID.Value), 2, 6);
                DataTable dt6 = ds6.Tables[0];
                //DataTable dtUnit6 = ds6.Tables[1];

                //int FabricQualityID6 = -1;
                //if (dt.Rows.Count > 0)
                //{
                //    FabricQualityID6 = Convert.ToInt32(dt.Rows[0]["FabricQualityID"].ToString());
                //}

                if (dt6.Rows.Count > 0)
                {
                    // lblh1.Text = lblh1.Text + dt6.Rows[0]["TextHistory"].ToString().Replace("###", "<br>");
                    if (dt6.Rows[0]["TextHistory"].ToString() != "")
                    {
                        //lblh1.Text = dt6.Rows[0]["TextHistory"].ToString();
                        lblh1.Text = lblh1.Text + bidh(dt6.Rows[0]["TextHistory"].ToString().Replace("###", "<br>"));
                    }
                    //string[] sdsd = dt6.Rows[0]["TextHistory"].ToString().Replace("###", "<br>").Split(new string[] { "$$" }, StringSplitOptions.RemoveEmptyEntries);
                    //if (sdsd.Length > 0)
                    //{
                    //    lblh1.Text = lblh1.Text + sdsd[0].ToString();
                    //}


                    lblHistory.Text += dt6.Rows[0]["TextHistory"].ToString().Replace("###", "<br>");
                    //Alltexthistory += dt6.Rows[0]["TextHistory"].ToString().Replace("###", "<br>");
                    //lblh1.Text = dt6.Rows[0]["TextHistory"].ToString().Replace("###", "<br>");
                    //if (dt.Rows[0]["TextHistory"].ToString() == "")
                    //{
                    //    lnkhistoryshow1.Visible = false;
                    //}
                    //lnkhistoryshow1.Attributes.Add("OnClick", "javaScript: return showhistory('block',1);");

                    // lblColorprintNo6.Text = dt6.Rows[0]["colorprint"].ToString();

                    string ColorPrint6 = dt6.Rows[0]["colorprint"].ToString();
                    if (ColorPrint6.Length > 10)
                    {
                        lblColorprintNo6.Text = ColorPrint6.Substring(0, 10);
                        lblColorprintNo6.ToolTip = ColorPrint6;
                    }
                    else
                    {
                        lblColorprintNo6.Text = ColorPrint6;
                    }
                    lblCostAvgFile6.Text = dt6.Rows[0]["CostAvg"].ToString();
                    hdnCostingAvg6.Value = dt6.Rows[0]["CostAvg"].ToString();
                    if (!string.IsNullOrEmpty(dt6.Rows[0]["CostingAvgFile"].ToString()))
                        hyplCostAvgFile6.NavigateUrl = ProductionFolderPath + dt6.Rows[0]["CostingAvgFile"].ToString();
                    else
                        hyplCostAvgFile6.Visible = false;

                    //  txtorderavg6.Text = dt6.Rows[0]["OrderAvg"].ToString();

                    string OrderAvg6 = dt6.Rows[0]["OrderAvg"].ToString();
                    if (OrderAvg6 == "0")
                    {
                        txtorderavg6.Text = "";
                    }
                    else
                    {
                        txtorderavg6.Text = OrderAvg6;
                        hdnOrderAvg6.Value = OrderAvg6;
                    }
                    ////add code by bharat on 1-sep-20
                    //if (FabCount == 6)
                    //{
                    //    if (txtorderavg1.Text != "" && txtorderavg2.Text != "" && txtorderavg3.Text != "" && txtorderavg4.Text != "" && txtorderavg5.Text != "" && txtorderavg6.Text != "")
                    //    {
                    //        chkboxAccountMgr.Enabled = true;
                    //        messageHide.Attributes.Add("style", "display:none");
                    //    }
                    //}
                    //end
                    //if (!string.IsNullOrEmpty(dt6.Rows[0]["OrderavgFile"].ToString()))
                    //    hyporderavgfile6.NavigateUrl = ProductionFolderPath + dt6.Rows[0]["OrderavgFile"].ToString();
                    //else
                    //    hyporderavgfile6.Visible = false;

                    //   txtcutavg6.Text = dt6.Rows[0]["CutAvg"].ToString();
                    string cutAvg6 = dt6.Rows[0]["CutAvg"] == DBNull.Value ? "" : dt6.Rows[0]["CutAvg"].ToString();
                    if (cutAvg6 == "0" || cutAvg6 == "")
                    {
                        txtcutavg6.Text = "";
                    }
                    else
                    {
                        txtcutavg6.Text = cutAvg6;
                        // txtorderavg6.Attributes.Add("readonly", "readonly");  Commented by Shubhendu on 23/11/2021
                    }
                    if (!string.IsNullOrEmpty(dt6.Rows[0]["CutAvgFile"].ToString()))
                    {
                        HyViewCutAvgFile6.NavigateUrl = ProductionFolderPath + dt6.Rows[0]["CutAvgFile"].ToString();
                        hdnCutAvg6.Value = "1";
                    }
                    else
                        HyViewCutAvgFile6.Visible = false;

                    if (!string.IsNullOrEmpty(dt6.Rows[0]["costwidth"].ToString()))
                    {
                        txtCostWidth6.Text = dt6.Rows[0]["costwidth"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt6.Rows[0]["OrderWidth"].ToString()) && dt6.Rows[0]["OrderWidth"].ToString() != "0")
                    {
                        txtOrderWidth6.Text = dt6.Rows[0]["OrderWidth"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dt6.Rows[0]["CutWidth"].ToString()) && dt6.Rows[0]["CutWidth"].ToString() != "0")
                    {
                        txtCutWidth6.Text = dt6.Rows[0]["CutWidth"].ToString();
                    }

                    //added by raghvinder on 19-08-2020 start
                    //if (!string.IsNullOrEmpty(dt6.Rows[0]["Unit"].ToString()))
                    //{
                    //    ddlcutAvg_Unit6.SelectedValue = dt6.Rows[0]["Unit"].ToString();              
                    //}

                    //DataTable dtFabricUnit = new DataTable();
                    //dtFabricUnit = objwc.Get_FabricUnit_ForOrder(Convert.ToInt32(hdnOderDetailID.Value), FabricQualityID6);
                    //int FabricUnit = 0, GarmentUnit = 0;
                    //if (dtFabricUnit.Rows.Count > 0)
                    //{
                    //    //GarmentUnit = dt.Rows[0]["Unit"].ToString() == "" ? -1 : Convert.ToInt32(dt.Rows[0]["Unit"]);
                    //    GarmentUnit = dt6.Rows[0]["Unit"].ToString() == "" ? -1 : Convert.ToInt32(dt6.Rows[0]["Unit"]);
                    //}

                    //if (dtFabricUnit.Rows.Count > 0)
                    //{
                    //    FabricUnit = Convert.ToInt32(dtFabricUnit.Rows[0]["FabricUnit"].ToString());
                    //}

                    //if (!string.IsNullOrEmpty(dtUnit6.Rows[0]["UnitName"].ToString()))
                    //{
                    //    ddlcutAvg_Unit6.DataSource = dtUnit6;
                    //    ddlcutAvg_Unit6.DataTextField = "UnitName";
                    //    ddlcutAvg_Unit6.DataValueField = "GroupUnitID";
                    //    ddlcutAvg_Unit6.DataBind();
                    //    //ddlcutAvg_Unit6.SelectedValue = dt6.Rows[0]["Unit"].ToString();
                    //}

                    //if (GarmentUnit > 0)
                    //    ddlcutAvg_Unit6.SelectedValue = GarmentUnit.ToString();
                    //else
                    //    ddlcutAvg_Unit6.SelectedValue = FabricUnit.ToString();
                    ////added by raghvinder on 19-08-2020 end

                    //added by raghvinder on 27-10-2020 start
                    DataTable dtChecked6 = ds.Tables[2];
                    DataTable dtCutting6 = ds.Tables[3];

                    bool IsCheck6 = dtChecked6.Rows[0]["IsApprovedAMForFabric"].ToString() == "" ? false : Convert.ToBoolean(dtChecked6.Rows[0]["IsApprovedAMForFabric"]);
                    bool IsCutting6 = dtCutting6.Rows[0]["IsCutting"].ToString() == "" ? false : Convert.ToBoolean(dtCutting6.Rows[0]["IsCutting"]);

                    //if (IsCheck6 == true)
                    //{
                    //    ddlcutAvg_Unit6.Enabled = false;
                    //}
                    //else
                    //{
                    //    ddlcutAvg_Unit6.Enabled = true;
                    //}

                    if (IsCutting6 == true)
                    {
                        txtcutavg6.Enabled = false;
                        txtCostWidth6.Enabled = false;
                        txtOrderWidth6.Enabled = false;
                        txtCutWidth6.Enabled = false;
                        txtCostWidth6.Enabled = false;
                        txtorderavg6.Enabled = false;
                    }
                    else
                    {
                        txtcutavg6.Enabled = true;
                        txtCostWidth6.Enabled = true;
                        txtOrderWidth6.Enabled = true;
                        txtCutWidth6.Enabled = true;
                        txtCostWidth6.Enabled = true;
                        txtorderavg6.Enabled = true;
                    }
                    //added by raghvinder on 27-10-2020 end
                }
                else
                {
                    hyplCostAvgFile6.Visible = false;
                    //hyporderavgfile6.Visible = false;
                    HyViewCutAvgFile6.Visible = false;
                }

                //new code 03-12-2020 start
                if (FabCount == 1)
                {
                    if (chkboxAccountMgr.Checked != true)
                    {
                        if (txtorderavg1.Text != "")
                        {
                            chkboxAccountMgr.Enabled = true;
                            messageHide.Attributes.Add("style", "display:none");
                        }
                        else
                        {
                            messageHide.Attributes.Add("style", "color:red");
                            chkboxAccountMgr.Enabled = false;
                            //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                            //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
                        }
                    }
                    else
                    {
                        if (txtorderavg1.Text != "")
                        {
                            chkboxAccountMgr.Enabled = false;
                            //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                            //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
                            messageHide.Attributes.Add("style", "display:none");
                        }
                    }

                }
                if (FabCount == 2)
                {
                    if (chkboxAccountMgr.Checked != true)
                    {
                        if (txtorderavg1.Text != "" && txtorderavg2.Text != "")
                        {
                            chkboxAccountMgr.Enabled = true;
                            messageHide.Attributes.Add("style", "display:none");
                        }
                        else
                        {
                            messageHide.Attributes.Add("style", "color:red");
                            chkboxAccountMgr.Enabled = false;
                            //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                            //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
                        }
                    }
                    else
                    {
                        if (txtorderavg1.Text != "" && txtorderavg2.Text != "")
                        {
                            chkboxAccountMgr.Enabled = false;
                            //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                            //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
                            messageHide.Attributes.Add("style", "display:none");
                        }
                    }

                }
                if (FabCount == 3)
                {
                    if (chkboxAccountMgr.Checked != true)
                    {
                        if (txtorderavg1.Text != "" && txtorderavg2.Text != "" && txtorderavg3.Text != "")
                        {
                            chkboxAccountMgr.Enabled = true;
                            messageHide.Attributes.Add("style", "display:none");
                        }
                        else
                        {
                            messageHide.Attributes.Add("style", "color:red");
                            chkboxAccountMgr.Enabled = false;
                            //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                            //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
                        }
                    }
                    else
                    {
                        if (txtorderavg1.Text != "" && txtorderavg2.Text != "" && txtorderavg3.Text != "")
                        {
                            chkboxAccountMgr.Enabled = false;
                            //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                            //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
                            messageHide.Attributes.Add("style", "display:none");
                        }
                    }

                }
                if (FabCount == 4)
                {
                    if (chkboxAccountMgr.Checked != true)
                    {
                        if (txtorderavg1.Text != "" && txtorderavg2.Text != "" && txtorderavg3.Text != "" && txtorderavg4.Text != "")
                        {
                            chkboxAccountMgr.Enabled = true;
                            messageHide.Attributes.Add("style", "display:none");
                        }
                        else
                        {
                            messageHide.Attributes.Add("style", "color:red");
                            chkboxAccountMgr.Enabled = false;
                            //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                            //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
                        }
                    }
                    else
                    {
                        if (txtorderavg1.Text != "" && txtorderavg2.Text != "" && txtorderavg3.Text != "" && txtorderavg4.Text != "")
                        {
                            chkboxAccountMgr.Enabled = false;
                            //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                            //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
                            messageHide.Attributes.Add("style", "display:none");
                        }
                    }

                }
                if (FabCount == 5)
                {
                    if (chkboxAccountMgr.Checked != true)
                    {
                        if (txtorderavg1.Text != "" && txtorderavg2.Text != "" && txtorderavg3.Text != "" && txtorderavg4.Text != "" && txtorderavg5.Text != "")
                        {
                            chkboxAccountMgr.Enabled = true;
                            messageHide.Attributes.Add("style", "display:none");
                        }
                        else
                        {
                            messageHide.Attributes.Add("style", "color:red");
                            chkboxAccountMgr.Enabled = false;
                            //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                            //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
                        }
                    }
                    else
                    {
                        if (txtorderavg1.Text != "" && txtorderavg2.Text != "" && txtorderavg3.Text != "" && txtorderavg4.Text != "" && txtorderavg5.Text != "")
                        {
                            chkboxAccountMgr.Enabled = false;
                            //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                            //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
                            messageHide.Attributes.Add("style", "display:none");
                        }
                    }

                }
                if (FabCount == 6)
                {
                    if (chkboxAccountMgr.Checked != true)
                    {
                        if (txtorderavg1.Text != "" && txtorderavg2.Text != "" && txtorderavg3.Text != "" && txtorderavg4.Text != "" && txtorderavg5.Text != "" && txtorderavg6.Text != "")
                        {
                            chkboxAccountMgr.Enabled = true;
                            messageHide.Attributes.Add("style", "display:none");
                        }
                        else
                        {
                            messageHide.Attributes.Add("style", "color:red");
                            chkboxAccountMgr.Enabled = false;
                            //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                            //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
                        }
                    }
                    else
                    {
                        if (txtorderavg1.Text != "" && txtorderavg2.Text != "" && txtorderavg3.Text != "" && txtorderavg4.Text != "" && txtorderavg5.Text != "" && txtorderavg6.Text != "")
                        {
                            chkboxAccountMgr.Enabled = false;
                            //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                            //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
                            messageHide.Attributes.Add("style", "display:none");
                        }
                    }

                }
                //new code 03-12-2020 end


                txtCostWidth1.Attributes.Add("readonly", "true");
                txtCostWidth2.Attributes.Add("readonly", "true");
                txtCostWidth3.Attributes.Add("readonly", "true");
                txtCostWidth4.Attributes.Add("readonly", "true");
                txtCostWidth5.Attributes.Add("readonly", "true");
                txtCostWidth6.Attributes.Add("readonly", "true");

                // CREATE PERMISSION FOR FABRIC ORDER AVG
                if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_DETAIL_ORDER_AVG))
                {
                    //txtorderavg1.Attributes.Add("readonly", "true");
                    //txtorderavg2.Attributes.Add("readonly", "true");
                    //txtorderavg3.Attributes.Add("readonly", "true");
                    //txtorderavg4.Attributes.Add("readonly", "true");
                    //txtorderavg5.Attributes.Add("readonly", "true");
                    //txtorderavg6.Attributes.Add("readonly", "true");
                }

                // CREATE PERMISSION FOR FABRIC ORDER AVG FILE
                //if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_DETAIL_ORDER_AVG_FILE))
                //{
                //    hyplwithtext1.Style.Add("display", "none");
                //    hyplwithtext2.Style.Add("display", "none");
                //    hyplwithtext3.Style.Add("display", "none");
                //    hyplwithtext4.Style.Add("display", "none");
                //    hyplwithtext5.Style.Add("display", "none");
                //    hyplwithtext6.Style.Add("display", "none");
                //}

                // CREATE PERMISSION FOR FABRIC CUT AVG
                if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_DETAIL_CUT_AVG))
                {
                    txtcutavg1.Attributes.Add("readonly", "true");
                    txtcutavg2.Attributes.Add("readonly", "true");
                    txtcutavg3.Attributes.Add("readonly", "true");
                    txtcutavg4.Attributes.Add("readonly", "true");
                    txtcutavg5.Attributes.Add("readonly", "true");
                    txtcutavg6.Attributes.Add("readonly", "true");
                }
                // CREATE PERMISSION FOR FABRIC CUT AVG FILE
                if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_DETAIL_CUT_AVG_FILE))
                {
                    HyclickCutAvgFile1.Style.Add("display", "none");
                    HyclickCutAvgFile2.Style.Add("display", "none");
                    HyclickCutAvgFile3.Style.Add("display", "none");
                    HyclickCutAvgFile4.Style.Add("display", "none");
                    HyclickCutAvgFile5.Style.Add("display", "none");
                    HyclickCutAvgFile6.Style.Add("display", "none");
                }
                // CREATE PERMISSION FOR FABRIC ORDER WIDTH
                if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_DETAIL_ORDER_WIDTH))
                {
                    txtOrderWidth1.Attributes.Add("readonly", "true");
                    txtOrderWidth2.Attributes.Add("readonly", "true");
                    txtOrderWidth3.Attributes.Add("readonly", "true");
                    txtOrderWidth4.Attributes.Add("readonly", "true");
                    txtOrderWidth5.Attributes.Add("readonly", "true");
                    txtOrderWidth6.Attributes.Add("readonly", "true");
                }

                // CREATE PERMISSION FOR FABRIC CUT WIDTH
                if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.FABRIC_DETAIL_CUT_WIDTH))
                {
                    txtCutWidth1.Attributes.Add("readonly", "true");
                    txtCutWidth2.Attributes.Add("readonly", "true");
                    txtCutWidth3.Attributes.Add("readonly", "true");
                    txtCutWidth4.Attributes.Add("readonly", "true");
                    txtCutWidth5.Attributes.Add("readonly", "true");
                    txtCutWidth6.Attributes.Add("readonly", "true");
                }

            }

        }
        public void ManageFabric()
        {
            try
            {
                switch (FabCount)
                {
                    case 1:

                        grdcutavg.Columns[3].Visible = false;
                        grdcutavg.Columns[4].Visible = false;
                        grdcutavg.Columns[5].Visible = false;
                        grdcutavg.Columns[6].Visible = false;
                        grdcutavg.Columns[7].Visible = false;
                        break;

                    case 2:
                        grdcutavg.Columns[4].Visible = false;
                        grdcutavg.Columns[5].Visible = false;
                        grdcutavg.Columns[6].Visible = false;
                        grdcutavg.Columns[7].Visible = false;
                        break;
                    case 3:
                        grdcutavg.Columns[5].Visible = false;
                        grdcutavg.Columns[6].Visible = false;
                        grdcutavg.Columns[7].Visible = false;
                        break;
                    case 4:
                        grdcutavg.Columns[6].Visible = false;
                        grdcutavg.Columns[7].Visible = false;
                        break;
                    case 5:
                        grdcutavg.Columns[7].Visible = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!IsPageRefresh) //only perform the button click actions if page has not been refreshed
            {
                //add code by bharat on 1-sep-20
                //GridViewRow row = grdcutavg.HeaderRow;                        
                //HyperLink hyporderavgfile1 = (HyperLink)row.FindControl("hyporderavgfile1");
                //HyperLink hyporderavgfile2 = (HyperLink)row.FindControl("hyporderavgfile2");
                //HyperLink hyporderavgfile3 = (HyperLink)row.FindControl("hyporderavgfile3");
                //HyperLink hyporderavgfile4 = (HyperLink)row.FindControl("hyporderavgfile4");
                //HyperLink hyporderavgfile5 = (HyperLink)row.FindControl("hyporderavgfile5");
                //HyperLink hyporderavgfile6 = (HyperLink)row.FindControl("hyporderavgfile6");

                //FileUpload uploderavgfile1 = (FileUpload)row.FindControl("uploderavgfile1");
                //FileUpload uploderavgfile2 = (FileUpload)row.FindControl("uploderavgfile2");
                //FileUpload uploderavgfile3 = (FileUpload)row.FindControl("uploderavgfile3");
                //FileUpload uploderavgfile4 = (FileUpload)row.FindControl("uploderavgfile4");
                //FileUpload uploderavgfile5 = (FileUpload)row.FindControl("uploderavgfile5");
                //FileUpload uploderavgfile6 = (FileUpload)row.FindControl("uploderavgfile6");


                if (hdnchkboxAccountMgr.Value == "1" || chkboxAccountMgr.Checked == true)
                {
                    chkboxAccountMgr.Checked = true;
                }
                else
                {
                    chkboxAccountMgr.Checked = false;
                }



                foreach (GridViewRow rows in grdcutavg.Rows)
                {
                    lblHistory.Text = string.Empty;
                    TextBox txtorderavg1 = (TextBox)rows.FindControl("txtorderavg1");
                    TextBox txtorderavg2 = (TextBox)rows.FindControl("txtorderavg2");
                    TextBox txtorderavg3 = (TextBox)rows.FindControl("txtorderavg3");
                    TextBox txtorderavg4 = (TextBox)rows.FindControl("txtorderavg4");
                    TextBox txtorderavg5 = (TextBox)rows.FindControl("txtorderavg5");
                    TextBox txtorderavg6 = (TextBox)rows.FindControl("txtorderavg6");

                    if (FabCount == 1)
                    {
                        if (chkboxAccountMgr.Checked != true)
                        {
                            if (txtorderavg1.Text != "")
                            {
                                chkboxAccountMgr.Enabled = true;
                                messageHide.Attributes.Add("style", "display:none");
                            }
                            else
                            {
                                messageHide.Attributes.Add("style", "color:red");
                                chkboxAccountMgr.Enabled = false;
                                //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                                //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
                            }
                        }
                        else
                        {
                            if (txtorderavg1.Text != "")
                            {
                                chkboxAccountMgr.Enabled = false;
                                //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                                //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
                                messageHide.Attributes.Add("style", "display:none");
                            }
                        }

                    }
                    if (FabCount == 2)
                    {
                        if (chkboxAccountMgr.Checked != true)
                        {
                            if (txtorderavg1.Text != "" && txtorderavg2.Text != "")
                            {
                                chkboxAccountMgr.Enabled = true;
                                messageHide.Attributes.Add("style", "display:none");
                            }
                            else
                            {
                                messageHide.Attributes.Add("style", "color:red");
                                chkboxAccountMgr.Enabled = false;
                                //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                                //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
                            }
                        }
                        else
                        {
                            if (txtorderavg1.Text != "" && txtorderavg2.Text != "")
                            {
                                chkboxAccountMgr.Enabled = false;
                                //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                                //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
                                messageHide.Attributes.Add("style", "display:none");
                            }
                        }

                    }
                    if (FabCount == 3)
                    {
                        if (chkboxAccountMgr.Checked != true)
                        {
                            if (txtorderavg1.Text != "" && txtorderavg2.Text != "" && txtorderavg3.Text != "")
                            {
                                chkboxAccountMgr.Enabled = true;
                                messageHide.Attributes.Add("style", "display:none");
                            }
                            else
                            {
                                messageHide.Attributes.Add("style", "color:red");
                                chkboxAccountMgr.Enabled = false;
                                //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                                //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
                            }
                        }
                        else
                        {
                            if (txtorderavg1.Text != "" && txtorderavg2.Text != "" && txtorderavg3.Text != "")
                            {
                                chkboxAccountMgr.Enabled = false;
                                //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                                //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
                                messageHide.Attributes.Add("style", "display:none");
                            }
                        }

                    }
                    if (FabCount == 4)
                    {
                        if (chkboxAccountMgr.Checked != true)
                        {
                            if (txtorderavg1.Text != "" && txtorderavg2.Text != "" && txtorderavg3.Text != "" && txtorderavg4.Text != "")
                            {
                                chkboxAccountMgr.Enabled = true;
                                messageHide.Attributes.Add("style", "display:none");
                            }
                            else
                            {
                                messageHide.Attributes.Add("style", "color:red");
                                chkboxAccountMgr.Enabled = false;
                                //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                                //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
                            }
                        }
                        else
                        {
                            if (txtorderavg1.Text != "" && txtorderavg2.Text != "" && txtorderavg3.Text != "" && txtorderavg4.Text != "")
                            {
                                chkboxAccountMgr.Enabled = false;
                                //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                                //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
                                messageHide.Attributes.Add("style", "display:none");
                            }
                        }

                    }
                    if (FabCount == 5)
                    {
                        if (chkboxAccountMgr.Checked != true)
                        {
                            if (txtorderavg1.Text != "" && txtorderavg2.Text != "" && txtorderavg3.Text != "" && txtorderavg4.Text != "" && txtorderavg5.Text != "")
                            {
                                chkboxAccountMgr.Enabled = true;
                                messageHide.Attributes.Add("style", "display:none");
                            }
                            else
                            {
                                messageHide.Attributes.Add("style", "color:red");
                                chkboxAccountMgr.Enabled = false;
                                //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                                //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
                            }
                        }
                        else
                        {
                            if (txtorderavg1.Text != "" && txtorderavg2.Text != "" && txtorderavg3.Text != "" && txtorderavg4.Text != "" && txtorderavg5.Text != "")
                            {
                                chkboxAccountMgr.Enabled = false;
                                //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                                //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
                                messageHide.Attributes.Add("style", "display:none");
                            }
                        }

                    }
                    if (FabCount == 6)
                    {
                        if (chkboxAccountMgr.Checked != true)
                        {
                            if (txtorderavg1.Text != "" && txtorderavg2.Text != "" && txtorderavg3.Text != "" && txtorderavg4.Text != "" && txtorderavg5.Text != "" && txtorderavg6.Text != "")
                            {
                                chkboxAccountMgr.Enabled = true;
                                messageHide.Attributes.Add("style", "display:none");
                            }
                            else
                            {
                                messageHide.Attributes.Add("style", "color:red");
                                chkboxAccountMgr.Enabled = false;
                                //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                                //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");                            
                            }
                        }
                        else
                        {
                            if (txtorderavg1.Text != "" && txtorderavg2.Text != "" && txtorderavg3.Text != "" && txtorderavg4.Text != "" && txtorderavg5.Text != "" && txtorderavg6.Text != "")
                            {
                                chkboxAccountMgr.Enabled = false;
                                //chkboxAccountMgr.Attributes.Add("onclick", "return false;");
                                //chkboxAccountMgr.Attributes.Add("style", "opacity:0.5");
                                messageHide.Attributes.Add("style", "display:none");
                            }
                        }

                    }

                }
                SaveData();
                if (chkboxAccountMgr.Checked)
                {
                    // ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
                    // ClientScript.RegisterStartupScript(typeof(Page), "closePage", "<script type='text/JavaScript'>window.close();</script>"); 
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "checkpage", "CloseWin();", true);
                }
                //BindGrid();
            }
        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
    }


}