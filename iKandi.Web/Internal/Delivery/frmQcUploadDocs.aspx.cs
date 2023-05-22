using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.Common;
using iKandi.BLL;
using System.IO;
using System.Web.Services;
using iKandi.Web.Components;
using System.Web.UI.HtmlControls;

namespace iKandi.Web.Internal.Delivery
{
    public partial class frmQcUploadDocs : System.Web.UI.Page
    {
        public string index { get; set; }

        public static int OrderId
        {
            get;
            set;
        }
        public static int OrderDetailID
        {
            get;
            set;
        }


        OrderController objOrderController = new OrderController();
        bool permission = false;
        bool Imagepermission = false;
        bool Ishsipeed = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["OrderId"] != null)
            {
                OrderId = Convert.ToInt32(Request.QueryString["OrderId"].ToString());
            }
            if (Request.QueryString["OrderDetailsId"] != null)
            {
                OrderDetailID = Convert.ToInt32(Request.QueryString["OrderDetailsId"].ToString());
            }

            if (!IsPostBack)
            {

                GetUploadFile();

                permission = objOrderController.QCUploadFaultsSubmit(Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID), 133);
              
                Imagepermission = objOrderController.QCUploadFaultsSubmit(Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID), 134);
                if (permission == false)
                {
                    btnSubmit.Visible = false;
                }
                else
                {
                    btnSubmit.Visible = true;
                    Ishsipeed = objOrderController.CheckShippedOrder(OrderDetailID);
                    if (Ishsipeed == true)
                        btnSubmit.Visible = false;
                    else
                        btnSubmit.Visible = true;
                  
                }

                // check is shipped
              
            }
        }

        private void GetUploadFile()
        {
            DataSet ds = new DataSet();
            ds = objOrderController.GetQcUploadFile(OrderDetailID, OrderId);
            DataTable dtFirst = ds.Tables[0];
            DataTable dt10 = ds.Tables[1];
            DataTable dt50 = ds.Tables[2];
            DataTable dtInline = ds.Tables[3];
            DataTable dtMidline = ds.Tables[4];
            DataTable dtFinal = ds.Tables[5];
            DataTable mid = ds.Tables[6];
            if (dtFirst.Rows.Count > 0)
            {
                rptFile1.DataSource = dtFirst;
                rptFile1.DataBind();
            }
            if (dt10.Rows.Count > 0)
            {
                rtpFile10.DataSource = dt10;
                rtpFile10.DataBind();
            }
            if (dt50.Rows.Count > 0)
            {
                rtpFile50.DataSource = dt50;
                rtpFile50.DataBind();
            }
            if (dtInline.Rows.Count > 0)
            {
                rtpFileInline.DataSource = dtInline;
                rtpFileInline.DataBind();
            }
            if (dtMidline.Rows.Count > 0)
            {
                rtpFileMidline.DataSource = dtMidline;
                rtpFileMidline.DataBind();
            }
            if (dtFinal.Rows.Count > 0)
            {
                rtpFileFinal.DataSource = dtFinal;
                rtpFileFinal.DataBind();
            }
            //Added by abhishek
            if (mid.Rows.Count > 0)
            {
                ddlpassfailinline.SelectedValue = mid.Rows[0]["IsCQDInlie"].ToString();
                ddlpassfailmidline.SelectedValue = mid.Rows[0]["IsCQDMidline"].ToString();
                ddlpassfailfinal.SelectedValue = mid.Rows[0]["IsCQDFinal"].ToString();

                ddlFirstPcs.SelectedValue = mid.Rows[0]["IsCQDFirstPcs"].ToString();
                ddlFirst10Pcs.SelectedValue = mid.Rows[0]["IsCQDFirst10Pcs"].ToString();
                ddlFirst50Pcs.SelectedValue = mid.Rows[0]["IsCQDFirst50Pcs"].ToString();

                if (mid.Rows[0]["CQDInlieDate"].ToString() != "")
                {
                    DateTime date = Convert.ToDateTime(mid.Rows[0]["CQDInlieDate"].ToString());
                    txtcqddateInline.Text = date.ToString("dd MMM yy (ddd)");
                }
                if (mid.Rows[0]["CQDMidlineDate"].ToString() != "")
                {
                    DateTime date = Convert.ToDateTime(mid.Rows[0]["CQDMidlineDate"].ToString());
                    txtMidline.Text = date.ToString("dd MMM yy (ddd)");
                }
                if (mid.Rows[0]["CQDFinalDate"].ToString() != "")
                {
                    DateTime date = Convert.ToDateTime(mid.Rows[0]["CQDFinalDate"].ToString());
                    txtcqddatefinal.Text = date.ToString("dd MMM yy (ddd)");
                }

                if (mid.Rows[0]["CQDFirstPcsDate"].ToString() != "")
                {
                  DateTime date = Convert.ToDateTime(mid.Rows[0]["CQDFirstPcsDate"].ToString());
                  txtFirstPcs.Text = date.ToString("dd MMM yy (ddd)");
                }
                if (mid.Rows[0]["CQDFirst10Pcs"].ToString() != "")
                {
                  DateTime date = Convert.ToDateTime(mid.Rows[0]["CQDFirst10Pcs"].ToString());
                  txtFirst10Pcs.Text = date.ToString("dd MMM yy (ddd)");
                }
                if (mid.Rows[0]["CQDFirst50PcsDate"].ToString() != "")
                {
                  DateTime date = Convert.ToDateTime(mid.Rows[0]["CQDFirst50PcsDate"].ToString());
                  txtFirst50Pcs.Text = date.ToString("dd MMM yy (ddd)");
                }
                if (ApplicationHelper.LoggedInUser.UserData.Designation != Designation.BIPL_QA_QA)//CQD
                {
                    ddlpassfailinline.Enabled = false;
                    ddlpassfailmidline.Enabled = false;
                    ddlpassfailfinal.Enabled = false;
                    txtcqddateInline.Enabled = false;
                    txtMidline.Enabled = false;
                    txtcqddatefinal.Enabled = false;

                    ddlFirstPcs.Enabled = false;
                    ddlFirst10Pcs.Enabled = false;
                    ddlFirst50Pcs.Enabled = false;
                    txtFirstPcs.Enabled = false;
                    txtFirst10Pcs.Enabled = false;
                    txtFirst50Pcs.Enabled = false;

                    ddlpassfailinline.ToolTip = "you don't have permission to change";
                    ddlpassfailmidline.ToolTip = "you don't have permission to change";
                    ddlpassfailfinal.ToolTip = "you don't have permission to change";
                    txtcqddateInline.ToolTip = "you don't have permission to change";
                    txtMidline.ToolTip = "you don't have permission to change";
                    txtcqddatefinal.ToolTip = "you don't have permission to change";

                    ddlFirstPcs.ToolTip = "you don't have permission to change";
                    ddlFirst10Pcs.ToolTip = "you don't have permission to change";
                    ddlFirst50Pcs.ToolTip = "you don't have permission to change";
                    txtFirstPcs.ToolTip = "you don't have permission to change";
                    txtFirst10Pcs.ToolTip = "you don't have permission to change";
                    txtFirst50Pcs.ToolTip = "you don't have permission to change";

                }

            }
            //end
        }


        public void GetFilepath(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {

                rptFile1.DataSource = dt;
                rptFile1.DataBind();
            }
        }
        public void GetFilepath10(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {

                rtpFile10.DataSource = dt;
                rtpFile10.DataBind();
            }
        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        protected void rptFile1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HyperLink imgfile1 = (HyperLink)e.Item.FindControl("imgfile1");
            HiddenField hdnFilePath1 = (HiddenField)e.Item.FindControl("hdnFilePath1");
            ImageButton imgDelete1 = (ImageButton)e.Item.FindControl("imgDelete1");
            string strFilePath = hdnFilePath1.Value;
            if (Path.GetExtension(strFilePath) == ".pdf" || Path.GetExtension(strFilePath) == ".Pdf")
            {
                imgfile1.ImageUrl = "../../images/pdf.png";
            }
            bool IsExist = objOrderController.CheckQCUploadFile(OrderDetailID, strFilePath, 1);
            if (IsExist == true)
            {
                imgDelete1.Visible = false;
            }
        }
        protected void rtpFile10_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HyperLink imgfile10 = (HyperLink)e.Item.FindControl("imgfile10");
            HiddenField hdnFilePath10 = (HiddenField)e.Item.FindControl("hdnFilePath10");
            ImageButton imgDelete10 = (ImageButton)e.Item.FindControl("imgDelete10");
            string strFilePath = hdnFilePath10.Value;
            if (Path.GetExtension(strFilePath) == ".pdf" || Path.GetExtension(strFilePath) == ".Pdf")
            {
                imgfile10.ImageUrl = "../../images/pdf.png";
            }
            bool IsExist = objOrderController.CheckQCUploadFile(OrderDetailID, strFilePath, 2);
            if (IsExist == true)
            {
                imgDelete10.Visible = false;
            }
        }
        protected void rtpFile50_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HyperLink imgfile50 = (HyperLink)e.Item.FindControl("imgfile50");
            HiddenField hdnFilePath50 = (HiddenField)e.Item.FindControl("hdnFilePath50");
            ImageButton imgDelete50 = (ImageButton)e.Item.FindControl("imgDelete50");
            string strFilePath = hdnFilePath50.Value;
            if (Path.GetExtension(strFilePath) == ".pdf" || Path.GetExtension(strFilePath) == ".Pdf")
            {
                imgfile50.ImageUrl = "../../images/pdf.png";
            }
            bool IsExist = objOrderController.CheckQCUploadFile(OrderDetailID, strFilePath, 3);
            if (IsExist == true)
            {
                imgDelete50.Visible = false;
            }
        }
        protected void rtpFileInline_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HyperLink imgfileInline = (HyperLink)e.Item.FindControl("imgfileInline");
            HiddenField hdnFilePathInline = (HiddenField)e.Item.FindControl("hdnFilePathInline");
            ImageButton imgDeleteInline = (ImageButton)e.Item.FindControl("imgDeleteInline");
            string strFilePath = hdnFilePathInline.Value;
            if (Path.GetExtension(strFilePath) == ".pdf" || Path.GetExtension(strFilePath) == ".Pdf")
            {
                imgfileInline.ImageUrl = "../../images/pdf.png";
            }
            bool IsExist = objOrderController.CheckQCUploadFile(OrderDetailID, strFilePath, 4);
            if (IsExist == true)
            {
                imgDeleteInline.Visible = false;
            }
        }
        protected void rtpFileMidline_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HyperLink imgfileMidline = (HyperLink)e.Item.FindControl("imgfileMidline");
            HiddenField hdnFilePathMidline = (HiddenField)e.Item.FindControl("hdnFilePathMidline");
            ImageButton imgDeleteMidline = (ImageButton)e.Item.FindControl("imgDeleteMidline");
            string strFilePath = hdnFilePathMidline.Value;
            if (Path.GetExtension(strFilePath) == ".pdf" || Path.GetExtension(strFilePath) == ".Pdf")
            {
                imgfileMidline.ImageUrl = "../../images/pdf.png";
            }
            bool IsExist = objOrderController.CheckQCUploadFile(OrderDetailID, strFilePath, 5);
            if (IsExist == true)
            {
                imgDeleteMidline.Visible = false;
            }
        }
        protected void rtpFileFinal_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HyperLink imgfileFinal = (HyperLink)e.Item.FindControl("imgfileFinal");
            HiddenField hdnFilePathFinal = (HiddenField)e.Item.FindControl("hdnFilePathFinal");
            ImageButton imgDeleteFinal = (ImageButton)e.Item.FindControl("imgDeleteFinal");
            string strFilePath = hdnFilePathFinal.Value;
            if (Path.GetExtension(strFilePath) == ".pdf" || Path.GetExtension(strFilePath) == ".Pdf")
            {
                imgfileFinal.ImageUrl = "../../images/pdf.png";
            }
            bool IsExist = objOrderController.CheckQCUploadFile(OrderDetailID, strFilePath, 6);
            if (IsExist == true)
            {
                imgDeleteFinal.Visible = false;
            }
        }
        //Upload Top 1
        protected void btnUploadFirst_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = CreateTable();

                foreach (RepeaterItem rptItem in rptFile1.Items)
                {
                    HiddenField hdnFilePath1 = (HiddenField)rptItem.FindControl("hdnFilePath1");
                    DataRow dr = dt.NewRow();
                    dr[0] = hdnFilePath1.Value;
                    dt.Rows.Add(dr);
                }
                if (FileUpldFirst.HasFile)
                {
                   FileUpldFirst.Attributes["class"] = "NoError";
                    string filename = Path.GetFileName(FileUpldFirst.FileName);
                    var path = Path.Combine(Constants.QUALITY_FOLDER_PATH, filename);
                    FileUpldFirst.SaveAs(path);

                    DataRow dr1 = dt.NewRow();
                    dr1[0] = filename;
                    dt.Rows.Add(dr1);
                }
                rptFile1.DataSource = dt;
                rptFile1.DataBind();
            }
            catch { }
        }

        protected void imgDelete1_Click(object sender, EventArgs e)
        {
            RepeaterItem rptItem = (RepeaterItem)(((Control)sender).NamingContainer);
            DataTable dt = CreateTable();
            foreach (RepeaterItem rptItem1 in rptFile1.Items)
            {
                HiddenField hdnFilePath1 = (HiddenField)rptItem1.FindControl("hdnFilePath1");
                DataRow dr = dt.NewRow();
                dr[0] = hdnFilePath1.Value;
                dt.Rows.Add(dr);
            }
            dt.Rows[rptItem.ItemIndex].Delete();

            rptFile1.DataSource = dt;
            rptFile1.DataBind();

        }

        // Upload top 10
        protected void btnUpload10_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = CreateTable();

                foreach (RepeaterItem rptItem in rtpFile10.Items)
                {
                    HiddenField hdnFilePath10 = (HiddenField)rptItem.FindControl("hdnFilePath10");
                    DataRow dr = dt.NewRow();
                    dr[0] = hdnFilePath10.Value;
                    dt.Rows.Add(dr);
                }
                if (FileUpldFirst10.HasFile)
                {
                    FileUpldFirst10.Attributes["class"] = "NoError";
                    string filename = Path.GetFileName(FileUpldFirst10.FileName);
                    var path = Path.Combine(Constants.QUALITY_FOLDER_PATH, filename);
                    FileUpldFirst10.SaveAs(path);

                    DataRow dr1 = dt.NewRow();
                    dr1[0] = filename;
                    dt.Rows.Add(dr1);
                }
                rtpFile10.DataSource = dt;
                rtpFile10.DataBind();
            }
            catch { }
        }
        protected void imgDelete10_Click(object sender, EventArgs e)
        {
            RepeaterItem rptItem = (RepeaterItem)(((Control)sender).NamingContainer);
            DataTable dt = CreateTable();
            foreach (RepeaterItem rptItem1 in rtpFile10.Items)
            {
                HiddenField hdnFilePath10 = (HiddenField)rptItem1.FindControl("hdnFilePath10");
                DataRow dr = dt.NewRow();
                dr[0] = hdnFilePath10.Value;
                dt.Rows.Add(dr);
            }
            dt.Rows[rptItem.ItemIndex].Delete();

            rtpFile10.DataSource = dt;
            rtpFile10.DataBind();
        }

        // Upload top 50
        protected void btnUpload50_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = CreateTable();

                foreach (RepeaterItem rptItem in rtpFile50.Items)
                {
                    HiddenField hdnFilePath50 = (HiddenField)rptItem.FindControl("hdnFilePath50");
                    DataRow dr = dt.NewRow();
                    dr[0] = hdnFilePath50.Value;
                    dt.Rows.Add(dr);
                }
                if (FileUpldFirst50.HasFile)
                {
                  FileUpldFirst50.Attributes["class"] = "NoError";
                    string filename = Path.GetFileName(FileUpldFirst50.FileName);
                    var path = Path.Combine(Constants.QUALITY_FOLDER_PATH, filename);
                    FileUpldFirst50.SaveAs(path);

                    DataRow dr1 = dt.NewRow();
                    dr1[0] = filename;
                    dt.Rows.Add(dr1);
                }
                rtpFile50.DataSource = dt;
                rtpFile50.DataBind();
            }
            catch { }
        }
        protected void imgDelete50_Click(object sender, EventArgs e)
        {
            RepeaterItem rptItem = (RepeaterItem)(((Control)sender).NamingContainer);
            DataTable dt = CreateTable();
            foreach (RepeaterItem rptItem1 in rtpFile50.Items)
            {
                HiddenField hdnFilePath50 = (HiddenField)rptItem1.FindControl("hdnFilePath50");
                DataRow dr = dt.NewRow();
                dr[0] = hdnFilePath50.Value;
                dt.Rows.Add(dr);
            }
            dt.Rows[rptItem.ItemIndex].Delete();

            rtpFile50.DataSource = dt;
            rtpFile50.DataBind();
        }

        // Upload Inline
        protected void btnUploadInline_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = CreateTable();

                foreach (RepeaterItem rptItem in rtpFileInline.Items)
                {
                    HiddenField hdnFilePathInline = (HiddenField)rptItem.FindControl("hdnFilePathInline");
                    DataRow dr = dt.NewRow();
                    dr[0] = hdnFilePathInline.Value;
                    dt.Rows.Add(dr);
                }
                if (FileUpldInline.HasFile)
                {
                    FileUpldInline.Attributes["class"] = "NoError";
                    //string time = DateTime.Now.ToString("dd MMM yyy hh-mm-ss");
                    //string Fullfilename = Path.GetFileName(FileUpldInline.FileName);
                    //string[] ext = Fullfilename.Split('.');
                    //filename = ext[0] + "_" + time + "." + ext[1];
                    //var path = Path.Combine(Constants.STYLE_FOLDER_PATH, filename);
                    //FileUpldInline.SaveAs(path);
                    string filename = Path.GetFileName(FileUpldInline.FileName);
                    var path = Path.Combine(Constants.QUALITY_FOLDER_PATH, filename);
                    FileUpldInline.SaveAs(path);

                    DataRow dr1 = dt.NewRow();
                    dr1[0] = filename;
                    dt.Rows.Add(dr1);
                }
                rtpFileInline.DataSource = dt;
                rtpFileInline.DataBind();
            }
            catch { }
        }
        protected void imgDeleteInline_Click(object sender, EventArgs e)
        {
            RepeaterItem rptItem = (RepeaterItem)(((Control)sender).NamingContainer);
            DataTable dt = CreateTable();
            foreach (RepeaterItem rptItem1 in rtpFileInline.Items)
            {
                HiddenField hdnFilePathInline = (HiddenField)rptItem1.FindControl("hdnFilePathInline");
                DataRow dr = dt.NewRow();
                dr[0] = hdnFilePathInline.Value;
                dt.Rows.Add(dr);
            }
            dt.Rows[rptItem.ItemIndex].Delete();

            rtpFileInline.DataSource = dt;
            rtpFileInline.DataBind();
        }

        // Upload Midline
        protected void btnUploadMidline_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = CreateTable();

                foreach (RepeaterItem rptItem in rtpFileMidline.Items)
                {
                    HiddenField hdnFilePathMidline = (HiddenField)rptItem.FindControl("hdnFilePathMidline");
                    DataRow dr = dt.NewRow();
                    dr[0] = hdnFilePathMidline.Value;
                    dt.Rows.Add(dr);
                }
                if (FileUpldMidline.HasFile)
                {
                    FileUpldMidline.Attributes["class"] = "NoError";
                    string filename = Path.GetFileName(FileUpldMidline.FileName);
                    var path = Path.Combine(Constants.QUALITY_FOLDER_PATH, filename);
                    FileUpldMidline.SaveAs(path);

                    DataRow dr1 = dt.NewRow();
                    dr1[0] = filename;
                    dt.Rows.Add(dr1);
                }
                rtpFileMidline.DataSource = dt;
                rtpFileMidline.DataBind();
            }
            catch { }
        }
        protected void imgDeleteMidline_Click(object sender, EventArgs e)
        {
            RepeaterItem rptItem = (RepeaterItem)(((Control)sender).NamingContainer);
            DataTable dt = CreateTable();
            foreach (RepeaterItem rptItem1 in rtpFileMidline.Items)
            {
                HiddenField hdnFilePathMidline = (HiddenField)rptItem1.FindControl("hdnFilePathMidline");
                DataRow dr = dt.NewRow();
                dr[0] = hdnFilePathMidline.Value;
                dt.Rows.Add(dr);
            }
            dt.Rows[rptItem.ItemIndex].Delete();

            rtpFileMidline.DataSource = dt;
            rtpFileMidline.DataBind();
        }

        // Upload Final
        protected void btnUploadFinal_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = CreateTable();

                foreach (RepeaterItem rptItem in rtpFileFinal.Items)
                {
                    HiddenField hdnFilePathFinal = (HiddenField)rptItem.FindControl("hdnFilePathFinal");
                    DataRow dr = dt.NewRow();
                    dr[0] = hdnFilePathFinal.Value;
                    dt.Rows.Add(dr);
                }
                if (FileUpldFinal.HasFile)
                {
                  FileUpldFinal.Attributes["class"] = "NoError";
                    string filename = Path.GetFileName(FileUpldFinal.FileName);
                    var path = Path.Combine(Constants.QUALITY_FOLDER_PATH, filename);
                    FileUpldFinal.SaveAs(path);

                    DataRow dr1 = dt.NewRow();
                    dr1[0] = filename;
                    dt.Rows.Add(dr1);
                }
                rtpFileFinal.DataSource = dt;
                rtpFileFinal.DataBind();
            }
            catch { }
        }
        protected void imgDeleteFinal_Click(object sender, EventArgs e)
        {
            RepeaterItem rptItem = (RepeaterItem)(((Control)sender).NamingContainer);
            DataTable dt = CreateTable();
            foreach (RepeaterItem rptItem1 in rtpFileFinal.Items)
            {
                HiddenField hdnFilePathFinal = (HiddenField)rptItem1.FindControl("hdnFilePathFinal");
                DataRow dr = dt.NewRow();
                dr[0] = hdnFilePathFinal.Value;
                dt.Rows.Add(dr);
            }
            dt.Rows[rptItem.ItemIndex].Delete();

            rtpFileFinal.DataSource = dt;
            rtpFileFinal.DataBind();
        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("FilePath", typeof(string)));
            return dt;
        }
        string TotalFile1 = "";
        string TotalFile10 = "";
        string TotalFile50 = "";
        string TotalFileInline = "";
        string TotalFileMidline = "";
        string TotalFileFinal = "";
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

           

            //Added by abhishek 
            DateTime CQDInlieDate = DateTime.MinValue; DateTime CQDMidlineDate = DateTime.MinValue; DateTime CQDFinalDate = DateTime.MinValue; int IsCQDInlie = 0; int IsCQDMidline = 0; int IsCQDFinal = 0;
            DateTime CQDFirstPcsDate = DateTime.MinValue; DateTime CQDFirst10Pcs = DateTime.MinValue; DateTime CQDFirst50PcsDate = DateTime.MinValue; int IsCQDFirstPcs = 0; int IsCQDFirst10Pcs = 0; int IsCQDFirst50Pcs = 0;
            if (txtcqddateInline.Text != "")
            {
                CQDInlieDate = Convert.ToDateTime(txtcqddateInline.Text.Trim().Substring(0, 9));
                //if (ddlpassfailinline.SelectedValue == "-1")
                //{
                //    ShowAlert("Select at least Pass/Fail!");
                //    return;
                //}
            }

            if (txtMidline.Text != "")
            {
                CQDMidlineDate = Convert.ToDateTime(txtMidline.Text.Trim().Substring(0, 9));
                //if (ddlpassfailmidline.SelectedValue == "-1")
                //{
                //    ShowAlert("Select at least Pass/Fail!");
                //    return;
                //}
            }

            if (txtcqddatefinal.Text != "")
            {
                CQDFinalDate = Convert.ToDateTime(txtcqddatefinal.Text.Trim().Substring(0, 9));
                //if (ddlpassfailfinal.SelectedValue == "-1")
                //{
                //    ShowAlert("Select at least Pass/Fail!");
                //    return;
                //}
            }
            if (ddlpassfailinline.SelectedValue != "-1")
            {
                IsCQDInlie = Convert.ToInt32(ddlpassfailinline.SelectedValue);
            }
            if (ddlpassfailmidline.SelectedValue != "-1")
            {
                IsCQDMidline = Convert.ToInt32(ddlpassfailmidline.SelectedValue);
            }
            if (ddlpassfailfinal.SelectedValue != "-1")
            {
                IsCQDFinal = Convert.ToInt32(ddlpassfailfinal.SelectedValue);
            }




            if (txtFirstPcs.Text != "")
            {
              CQDFirstPcsDate = Convert.ToDateTime(txtFirstPcs.Text.Trim().Substring(0, 9));
              //if (ddlFirstPcs.SelectedValue == "-1")
              //{
              //  ShowAlert("Select at least Pass/Fail!");
              //  return;
              //}
            }

            if (txtFirst10Pcs.Text != "")
            {
              CQDFirst10Pcs = Convert.ToDateTime(txtFirst10Pcs.Text.Trim().Substring(0, 9));
              //if (ddlFirst10Pcs.SelectedValue == "-1")
              //{
              //  ShowAlert("Select at least Pass/Fail!");
              //  return;
              //}
            }

            if (txtFirst50Pcs.Text != "")
            {
              CQDFirst50PcsDate = Convert.ToDateTime(txtFirst50Pcs.Text.Trim().Substring(0, 9));
              //if (ddlFirst50Pcs.SelectedValue == "-1")
              //{
              //  ShowAlert("Select at least Pass/Fail!");
              //  return;
              //}
            }
            if (ddlFirstPcs.SelectedValue != "-1")
            {
              IsCQDFirstPcs = Convert.ToInt32(ddlFirstPcs.SelectedValue);
            }
            if (ddlFirst10Pcs.SelectedValue != "-1")
            {
              IsCQDFirst10Pcs = Convert.ToInt32(ddlFirst10Pcs.SelectedValue);
            }
            if (ddlFirst50Pcs.SelectedValue != "-1")
            {
              IsCQDFirst50Pcs = Convert.ToInt32(ddlFirst50Pcs.SelectedValue);
            }
            if (rptFile1.Items.Count > 0)
            {
                foreach (RepeaterItem rptItem in rptFile1.Items)
                {
                    HiddenField hdnFilePath1 = (HiddenField)rptItem.FindControl("hdnFilePath1");
                    TotalFile1 += hdnFilePath1.Value + "$";
                }
                TotalFile1 = TotalFile1.TrimEnd('$');
            }
            if (rtpFile10.Items.Count > 0)
            {
                foreach (RepeaterItem rptItem in rtpFile10.Items)
                {
                    HiddenField hdnFilePath10 = (HiddenField)rptItem.FindControl("hdnFilePath10");
                    TotalFile10 += hdnFilePath10.Value + "$";
                }
                TotalFile10 = TotalFile10.TrimEnd('$');
            }
            if (rtpFile50.Items.Count > 0)
            {
                foreach (RepeaterItem rptItem in rtpFile50.Items)
                {
                    HiddenField hdnFilePath50 = (HiddenField)rptItem.FindControl("hdnFilePath50");
                    TotalFile50 += hdnFilePath50.Value + "$";
                }
                TotalFile50 = TotalFile50.TrimEnd('$');
            }
            if (rtpFileInline.Items.Count > 0)
            {
                foreach (RepeaterItem rptItem in rtpFileInline.Items)
                {
                    HiddenField hdnFilePathInline = (HiddenField)rptItem.FindControl("hdnFilePathInline");
                    TotalFileInline += hdnFilePathInline.Value + "$";
                }
                TotalFileInline = TotalFileInline.TrimEnd('$');
            }
            if (rtpFileMidline.Items.Count > 0)
            {
                foreach (RepeaterItem rptItem in rtpFileMidline.Items)
                {
                    HiddenField hdnFilePathMidline = (HiddenField)rptItem.FindControl("hdnFilePathMidline");
                    TotalFileMidline += hdnFilePathMidline.Value + "$";
                }
                TotalFileMidline = TotalFileMidline.TrimEnd('$');
            }
            if (rtpFileFinal.Items.Count > 0)
            {
                foreach (RepeaterItem rptItem in rtpFileFinal.Items)
                {
                    HiddenField hdnFilePathFinal = (HiddenField)rptItem.FindControl("hdnFilePathFinal");
                    TotalFileFinal += hdnFilePathFinal.Value + "$";
                }
                TotalFileFinal = TotalFileFinal.TrimEnd('$');
            }
            string StrError = "";
            Validate(out StrError);
            if (StrError != "")
            {
              ShowAlert(StrError);
              return;
            }
            if ((TotalFile1 != "") || (TotalFile10 != "") || (TotalFile50 != "") || (TotalFileInline != "") || (TotalFileMidline != "") || (TotalFileFinal != "") || (CQDInlieDate != DateTime.MinValue) || (CQDMidlineDate != DateTime.MinValue) || (CQDFinalDate != DateTime.MinValue))
            {
                int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                int iResult = objOrderController.UpdateQcUploadFile(OrderDetailID, TotalFile1, TotalFile10, TotalFile50, TotalFileInline, TotalFileMidline, TotalFileFinal, UserId, CQDInlieDate, CQDMidlineDate, CQDFinalDate, IsCQDInlie, IsCQDMidline, IsCQDFinal, CQDFirstPcsDate ,  CQDFirst10Pcs,CQDFirst50PcsDate,IsCQDFirstPcs,IsCQDFirst10Pcs,IsCQDFirst50Pcs);
                if (iResult > 0)
                {
                    ShowAlert("Data Saved successfully.");
                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "setTimeout(function(){ window.parent.Shadowbox.close();}, 100);", true);
                }
            }
            else
            {
                ShowAlert("Upload at least one file!");
            }

        }
        public void Validate(out string Mag)
        {
          Mag = "";
          //if (TotalFile1 != "" || txtFirstPcs.Text != "" || ddlFirstPcs.SelectedValue != "-1")
          //{
          //  if (TotalFile1 == "")
          //  {
          //    Mag = "Upload at least one file!";
          //    FileUpldFirst.Attributes["class"] = "HasError";
          //    return;
          //  }
          //  else if (txtFirstPcs.Text == "")
          //  {
          //    Mag = "Select Date!";
          //    txtFirstPcs.Attributes.Add("style", "border:1px solid red !important;float: left;"); 
                 
          //    return;
          //  }
          //  else if (ddlFirstPcs.SelectedValue == "-1")
          //  {
                 
          //    ddlFirstPcs.Attributes.Add("class", "HasError");  
          //    Mag = "Select at least Pass/Fail!";
          //    return;
          //  }
          //}
          //if (TotalFile10 != "" || txtFirst10Pcs.Text != "" || ddlFirst10Pcs.SelectedValue != "-1")
          //{
          //  if (TotalFile10 == "")
          //  {
          //    FileUpldFirst10.Attributes["class"] = "HasError";
          //    Mag = "Upload at least one file!";
          //    return;
          //  }
          //  else if (txtFirst10Pcs.Text == "")
          //  {
          //    txtFirst10Pcs.Attributes.Add("style", "border:1px solid red !important;float: left;"); 
          //    Mag = "Select Date!";
          //    return;
          //  }
          //  else if (ddlFirst10Pcs.SelectedValue == "-1")
          //  {
          //    ddlFirst10Pcs.Attributes["class"] = "HasError";
          //    Mag = "Select  Pass/Fail!";
          //    return;
          //  }
          //}
          //if (TotalFile50 != "" || txtFirst50Pcs.Text != "" || ddlFirst50Pcs.SelectedValue != "-1")
          //{
          //  if (TotalFile50 == "")
          //  {
          //    FileUpldFirst50.Attributes["class"] = "HasError";
          //    Mag = "Upload at least one file!";
          //    return;
          //  }
          //  else if (txtFirst50Pcs.Text == "")
          //  {
          //    txtFirst50Pcs.Attributes.Add("style", "border:1px solid red !important;float: left;"); 
          //    Mag = "Select  Date!";
          //    return;
          //  }
          //  else if (ddlFirst50Pcs.SelectedValue == "-1")
          //  {
          //    ddlFirst50Pcs.Attributes["class"] = "HasError";
          //    Mag = "Select at least Pass/Fail!";
          //    return;
          //  }
          //}
          //if (TotalFileInline != "" || txtcqddateInline.Text != "" || ddlpassfailinline.SelectedValue != "-1")
          //{
          //  if (TotalFileInline == "")
          //  {
          //    FileUpldInline.Attributes["class"] = "HasError";
          //    Mag = "Upload at least one file!";
          //    return;
          //  }
          //  else if (txtcqddateInline.Text == "")
          //  {
          //    txtcqddateInline.Attributes.Add("style", "border:1px solid red !important;float: left;"); 
          //    Mag = "Select  Date!";
          //    return;
          //  }
          //  else if (ddlpassfailinline.SelectedValue == "-1")
          //  {
          //    ddlpassfailinline.Attributes["class"] = "HasError";
          //    Mag = "Select at least Pass/Fail!";
          //    return;
          //  }
          //}
          //if (TotalFileMidline != "" || txtMidline.Text != "" || ddlpassfailmidline.SelectedValue != "-1")
          //{
          //  if (TotalFileMidline == "")
          //  {
          //    FileUpldMidline.Attributes["class"] = "HasError";
          //    Mag = "Upload at least one file!";
          //    return;
          //  }
          //  else if (txtMidline.Text == "")
          //  {
          //    txtMidline.Attributes.Add("style", "border:1px solid red !important;float: left;"); 
          //    Mag = "Select  Date!";
          //    return;
          //  }
          //  else if (ddlpassfailmidline.SelectedValue == "-1")
          //  {
          //    ddlpassfailmidline.Attributes["class"] = "HasError";
          //    Mag = "Select at least Pass/Fail!";
          //    return;
          //  }
          //}
          //if (TotalFileFinal != "" || txtcqddatefinal.Text != "" || ddlpassfailfinal.SelectedValue != "-1")
          //{
          //  if (TotalFileFinal == "")
          //  {
          //    FileUpldFinal.Attributes["class"] = "HasError";
          //    Mag = "Upload at least one file!";
          //    return;
          //  }
          //  else if (txtcqddatefinal.Text == "")
          //  {
          //    txtcqddatefinal.Attributes.Add("style", "border:1px solid red !important;float: left;"); 
          //    Mag = "Select  Date!";
          //    return;
          //  }
          //  else if (ddlpassfailfinal.SelectedValue == "-1")
          //  {
          //    ddlpassfailfinal.Attributes["class"] = "HasError";
          //    Mag = "Select at least Pass/Fail!";
          //    return;
          //  }
          //}
 
        }
    }
}