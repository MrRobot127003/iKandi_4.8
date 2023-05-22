using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Common;
using System.Data;
using System.Web.UI.HtmlControls;
using iKandi.Web.Components;
using System.IO;
using System.Web.Services;


namespace iKandi.Web.Internal.Qc_Complience
{
    public partial class Line_Process_Audit_Comment_Decision1 : System.Web.UI.Page
    {
        public int ProcessType
        {
            get;
            set;
        }
        public int InternalAuditId
        {
            get;
            set;
        }
        public int UnitId
        {
            get;
            set;
        }
        public int QAcompilation
        {
            get;
            set;
        }
        public int ValueId
        {
            get;
            set;
        }
        public string LineNo
        {
            get;
            set;
        }
        public string CompareDate
        {
            get;
            set;
        }
        public string index { get; set; }
        public String ImageFile
        {
            get;
            set;
        }


        public string LineName
        {
            get;
            set;
        }

        
        int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
        AdminController odjadminController = new AdminController();
        protected void Page_Load(object sender, EventArgs e)
        {
            UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            if (!IsPostBack)
            {
                GetQueryString();
                if (CompareDate == "")
                {
                    CompareDate = DateTime.Today.ToString();
                }


                btnUpload1.Visible = false;
                Fldresolution.Visible = false;
                //if (DateTime.Today > DateTime.ParseExact(CompareDate, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture))
                int DateDiff = (DateTime.Today - Convert.ToDateTime(CompareDate)).Days;
                if (UnitId != -1 && ProcessType != -1)
                {
                    if (DateTime.Today > Convert.ToDateTime(CompareDate))
                    {
                        btnSubmit.Visible = false;
                        btnUpload1.Visible = false;
                        Fldresolution.Visible = false;
                        chkApplyAll.Enabled = false;
                        rdobtnStatus.Enabled = false;
                        textareaRemarks.Enabled = false;
                    }
                    else
                    {
                        btnSubmit.Visible = true;
                    }
                }
                else
                {
                    if (DateDiff < 4)
                    {
                        btnSubmit.Visible = true;
                    }
                    else
                    {
                        btnSubmit.Visible = false;
                    }
                }
                DataSet ds = odjadminController.GetLineProcessAuditdecision(UnitId, ProcessType, InternalAuditId, QAcompilation, ValueId, LineNo, CompareDate);
                DataTable dtLineProcessAuditdecision = ds.Tables[0];
                DataTable dtProcess_Factory = ds.Tables[1];
                DataTable IsActive = ds.Tables[2];
                if (UserId != 2)
                {
                    RadioButtonActive.SelectedValue = "0";
                    RadioButtonActive.Style.Add("display", "none");
                }
                else
                {
                    RadioButtonActive.Style.Add("display", "inline");
                }
                if (IsActive.Rows.Count > 0)
                {
                    if (IsActive.Rows[0]["IsActive"].ToString().Trim() == "False")
                    {
                        RadioButtonActive.SelectedValue = "0";                       
                        textareaRemarks.Visible = false;
                       rdobtnStatus.Visible = false;
                       chkApplyAll.Visible = false;
                      }
                    else
                    {
                        RadioButtonActive.SelectedValue = "1";
                        textareaRemarks.Visible = true;
                        rdobtnStatus.Visible = true;
                        chkApplyAll.Visible = true;
                    }
                }
                else
                {
                    RadioButtonActive.SelectedValue = "1";
                    textareaRemarks.Visible = true;
                    rdobtnStatus.Visible = true;
                }
            
                if (dtLineProcessAuditdecision.Rows.Count > 0)
                {
                    textareaRemarks.Text = dtLineProcessAuditdecision.Rows[0]["Remarks"].ToString().Trim();
                    ViewState["remarks"] = dtLineProcessAuditdecision.Rows[0]["Remarks"].ToString().Trim();
                    rdobtnStatus.SelectedValue = dtLineProcessAuditdecision.Rows[0]["Pass_Fail"].ToString().Trim();
                    txtOutHouseValue.Text = dtLineProcessAuditdecision.Rows[0]["Alternation_Operator_OnMachine"].ToString().Trim();
                    if (dtLineProcessAuditdecision.Rows[0]["ApplyToAll"].ToString() != "")
                    {
                        if (Convert.ToInt32(dtLineProcessAuditdecision.Rows[0]["ApplyToAll"]) == 1)
                        {
                            chkApplyAll.Checked = true;
                            hdnchkapplyall.Value = "1";
                        }
                        else
                        {
                            chkApplyAll.Checked = false;
                        }
                        if (rdobtnStatus.SelectedValue == "0" || rdobtnStatus.SelectedValue == "1")
                        {
                            chkApplyAll.Enabled = true;
                            btnUpload1.Visible = false;
                            Fldresolution.Visible = false;
                        }
                        else
                        {
                            chkApplyAll.Checked = false;
                            chkApplyAll.Enabled = false;
                            hdnchkapplyall.Value = "0";
                            btnUpload1.Visible = true;
                            Fldresolution.Visible = true;
                        }
                    }

                    DataTable dt = CreateTable();
                    if (dtLineProcessAuditdecision.Rows[0]["ImageFile"].ToString() != "")
                    {
                        hdnWholeFile.Value = dtLineProcessAuditdecision.Rows[0]["ImageFile"].ToString();
                        string[] File = hdnWholeFile.Value.Split('$');
                        for (int i = 0; i < File.Length; i++)
                        {
                            dt.Rows.Add(File[i]);
                        }
                        rptFile.DataSource = dt;
                        rptFile.DataBind();
                    }
                    else
                    {
                        rptFile.DataSource = null;
                        rptFile.DataBind();
                    }

                }
                if (dtProcess_Factory.Rows.Count > 0)
                {
                    
                    lblProcessName.Text = dtProcess_Factory.Rows[0]["ProcessName"].ToString().Trim();
                    ViewState["IsValueTxt"] = dtProcess_Factory.Rows[0]["IsValueTxt"].ToString();
                    if (dtProcess_Factory.Rows[0]["IsValueTxt"].ToString() == "1")
                    {
                        outhhouseCondition.Style.Add("display", "none");
                        rdobtnStatus.SelectedValue = "-1";
                        OuthouseTextshow.Style.Remove("display");
                        chkApplyAll.Checked = false;                       
                    }
                    if (UnitId != -1)
                    {
                        lblUnitName.Text = dtProcess_Factory.Rows[0]["Factory"].ToString().Trim();
                    }
                    else
                    {
                        lblUnitName.Text = "";
                    }
                }
                if (QAcompilation == 1)
                {
                    lblLineNumber.Text = "Line" + LineName.ToString().Trim().Replace("~", "&");
                }
                else if (QAcompilation == 2)
                {
                    lblLineNumber.Text = "Finishing Cluster " + LineName.ToString().Trim().Replace("~", "&");
                }
               
                else
                {
                    lblLineNumber.Text = LineName.ToString().Trim().Replace("~", "&");
                }
                Add();
            }
          

        }
        public void Add()
        {
          String QAcompliance = System.Configuration.ConfigurationManager.AppSettings["QAcompliance"];
          String IEcompliance = System.Configuration.ConfigurationManager.AppSettings["IEcompliance"];
          String HRCompliance = System.Configuration.ConfigurationManager.AppSettings["HRCompliance"];
          int DateDiff = 0;
          if (ProcessType == 2)
          {
            DateDiff = (DateTime.Today - (DateTime.Today.AddDays(-Convert.ToInt16(QAcompliance)))).Days;
            if (Convert.ToDateTime(CompareDate) <= DateTime.Today && Convert.ToDateTime(CompareDate) >= Convert.ToDateTime((DateTime.Today.AddDays(-Convert.ToInt32(QAcompliance)))))
            {
                btnSubmit.Visible = true;
                chkApplyAll.Enabled = true;
                rdobtnStatus.Enabled = true;
                textareaRemarks.Enabled = true;
              }
              else
              {
                btnSubmit.Visible = false;
                chkApplyAll.Enabled = false;
                rdobtnStatus.Enabled = false;
                textareaRemarks.Enabled = false;
              }
            
          }
          if (ProcessType == 1)
          {
            /// (DateTime.Today - Convert.ToDateTime(CompareDate)).Days;
            DateDiff = (DateTime.Today - (DateTime.Today.AddDays(-Convert.ToInt16(HRCompliance)))).Days;
            if (Convert.ToDateTime(CompareDate) <= DateTime.Today && Convert.ToDateTime(CompareDate) >= Convert.ToDateTime((DateTime.Today.AddDays(-Convert.ToInt32(HRCompliance)))))
            //if (HRCompliance == "2")//HR
            //{
            //  if (DateDiff <= 2)
            //  {
            {
              btnSubmit.Visible = true;
              chkApplyAll.Enabled = true;
              rdobtnStatus.Enabled = true;
              textareaRemarks.Enabled = true;
            }
            else
            {
              btnSubmit.Visible = false;
              chkApplyAll.Enabled = false;
              rdobtnStatus.Enabled = false;
              textareaRemarks.Enabled = false;
            }

          }
          if (ProcessType == -1)
          {
            DateDiff = (DateTime.Today - (DateTime.Today.AddDays(-Convert.ToInt16(IEcompliance)))).Days;
            if (Convert.ToDateTime(CompareDate) <= DateTime.Today && Convert.ToDateTime(CompareDate) >= Convert.ToDateTime((DateTime.Today.AddDays(-Convert.ToInt32(IEcompliance)))))
            {
              btnSubmit.Visible = true;
              chkApplyAll.Enabled = true;
              rdobtnStatus.Enabled = true;
              textareaRemarks.Enabled = true;
            }
            else
            {
              btnSubmit.Visible = false;
              chkApplyAll.Enabled = false;
              rdobtnStatus.Enabled = false;
              textareaRemarks.Enabled = false;
            }

          }
        }
        
        

        public void GetQueryString()
        {

            if (Request.QueryString["ProcessType"] != null)
            {
                ProcessType = Convert.ToInt32(Request.QueryString["ProcessType"]);
                ViewState["ProcessType"] = ProcessType;
            }

            if (Request.QueryString["InternalAuditId"] != null)
            {
                InternalAuditId = Convert.ToInt32(Request.QueryString["InternalAuditId"]);
                ViewState["InternalAuditId"] = InternalAuditId;
            }

            if (Request.QueryString["UnitId"] != null)
            {
                UnitId = Convert.ToInt32(Request.QueryString["UnitId"]);
                ViewState["UnitId"] = UnitId;
            }
            if (Request.QueryString["QAcompilation"] != null)
            {
                QAcompilation = Convert.ToInt32(Request.QueryString["QAcompilation"]);
                ViewState["QAcompilation"] = QAcompilation;
            }

            if (Request.QueryString["ValueId"] != null)
            {
                ValueId = Convert.ToInt32(Request.QueryString["ValueId"]);
                ViewState["ValueId"] = ValueId;
            }
            if (Request.QueryString["LineNo"] != null)
            {
                LineNo = Request.QueryString["LineNo"].ToString();
                ViewState["LineNo"] = LineNo;
            }

            if (Request.QueryString["LineName"] != null)
            {
                LineName = Request.QueryString["LineName"].ToString();
                ViewState["LineName"] = LineName;
            }
            //if (Request.QueryString["CompareDate"] != null)
            //{
                CompareDate = Request.QueryString["CompareDate"].ToString();
                ViewState["CompareDate"] = CompareDate;
            //}

        }

        protected void btnUpload1_Click(object sender, EventArgs e)
        {
            var filename = "";
            try
            {
                DataTable dt = CreateTable();

                foreach (RepeaterItem rptItem in rptFile.Items)
                {
                    HiddenField hdnFilePath = (HiddenField)rptItem.FindControl("hdnFilePath");
                    DataRow dr = dt.NewRow();
                    dr[0] = hdnFilePath.Value;
                    dt.Rows.Add(dr);
                }

                ImageFile = Fldresolution.FileName;
                string extension = Path.GetExtension(Fldresolution.FileName);
                bool isextension = checkExtension(extension);
                string Exten2 = System.IO.Path.GetExtension(Fldresolution.FileName);               
                DateTime now = DateTime.Now;
                string Day = now.ToString("dd");
                string Month = now.ToString("MMM");
               
                if (Fldresolution.HasFile)
                {
                    filename = lblLineNumber.Text + "_ProcessType" + Convert.ToInt32(ViewState["ProcessType"].ToString()) + "_unitId" + Convert.ToInt32(ViewState["UnitId"].ToString()) + "_" + Day + Month + "_" + ImageFile;
                    //filename = iKandi.Web.Components.FileHelper.SaveFile(Fldresolution.PostedFile.InputStream, Fldresolution.FileName, Constants.PROCESS_UPLOAD_FOLDER_PATH, false, string.Empty);
                   if (isextension)
                   {
                       Fldresolution.SaveAs(Server.MapPath("~/Uploads/OwnerRes/" + filename));
                   }                    
                    
                    DataRow dr1 = dt.NewRow();
                    dr1[0] = filename;
                    dt.Rows.Add(dr1);
                }
                rptFile.DataSource = dt;
                rptFile.DataBind();
            }
            catch { }

            //===============================================sec
            string TotalFilePath = "";
            hdnindex.Value = index;
            foreach (RepeaterItem rptItem in rptFile.Items)
            {
                HiddenField hdnFilePath = (HiddenField)rptItem.FindControl("hdnFilePath");
                TotalFilePath += hdnFilePath.Value + "$";
            }
            if (TotalFilePath.Length > 0)
            {
                TotalFilePath = TotalFilePath.Substring(0, TotalFilePath.Length - 1);
            }
            hdnWholeFile.Value = TotalFilePath;
            Session["FileDoc"] = hdnWholeFile.Value;              
        }

        protected void imgRow_Click(object sender, EventArgs e)
        {
            RepeaterItem rptItem = (RepeaterItem)(((Control)sender).NamingContainer);
            DataTable dt = CreateTable();
            foreach (RepeaterItem rptItem1 in rptFile.Items)
            {
                HiddenField hdnFilePath = (HiddenField)rptItem1.FindControl("hdnFilePath");
                DataRow dr = dt.NewRow();
                dr[0] = hdnFilePath.Value;
                dt.Rows.Add(dr);
            }
            dt.Rows[rptItem.ItemIndex].Delete();

            rptFile.DataSource = dt;
            rptFile.DataBind();


        }

        private DataTable CreateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("FilePath", typeof(string)));
            return dt;
        }


        protected bool checkExtension(string file)
        {
            //check the Extension of Image File
            if ((file.ToLower() == ".jpg") || (file.ToLower() == ".jpeg") || (file.ToLower() == ".png"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            //if (rdobtnStatus.SelectedValue == "0" || rdobtnStatus.SelectedValue == "1")
            //{
            //    chkApplyAll.Enabled = true;
            //}
            //else
            //{
            //    chkApplyAll.Checked = false;
            //    chkApplyAll.Enabled = false;
            //    hdnchkapplyall.Value = "0";
            //}
            int rdobtnVal;
            string Remarks = textareaRemarks.Text.Trim();



            int applyValue, result = 0, IsClosed = 0,  IsActive = 1, OutHouseValue=0,flag=0;

            if (ViewState["IsValueTxt"].ToString() == "1")
            {
                if (txtOutHouseValue.Text != "")
                {
                    OutHouseValue = Convert.ToInt32(txtOutHouseValue.Text);
                }
                flag = 1;
               
            }
            //string ImageFile;
            if(RadioButtonActive.SelectedValue=="0")
            {
            IsActive=0;
            rdobtnVal = 0;
            }
            else
            {
                IsActive=1;
                rdobtnVal = Convert.ToInt32(rdobtnStatus.SelectedValue);
            }
           
            if (chkApplyAll.Checked)
            {
                applyValue = 1;
            }
            else
            {
                applyValue = 0;
            }
            if (chkIsclosed.Checked)
            {
                IsClosed = 1;
            }
            else{
                IsClosed=0;
            }

            //string TotalFilePath = "";
            //hdnindex.Value = index;
            //if (rdobtnVal == 2)
            //{
            //    foreach (RepeaterItem rptItem in rptFile.Items)
            //    {
            //        HiddenField hdnFilePath = (HiddenField)rptItem.FindControl("hdnFilePath");
            //        TotalFilePath += hdnFilePath.Value + "$";
            //    }
            //    if (TotalFilePath.Length > 0)
            //    {
            //        TotalFilePath = TotalFilePath.Substring(0, TotalFilePath.Length - 1);
            //    }
            //    hdnWholeFile.Value = TotalFilePath;

            //    Session["FileDoc"] = hdnWholeFile.Value;

            //    ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);

            //    if (Session["FileDoc"] != null)
            //    {
            //        ImageFile = Session["FileDoc"].ToString();
            //        hdnFldresolutionTestreport.Value = ImageFile;
            //    }
            //}
            //else
            //{
            //    ImageFile = "";
            //}
            if (hdnchkapplyall.Value == "1")
            {
                string comments = "";
                if (applyValue == 0)
                {
                    comments = ViewState["remarks"].ToString();
                    result = odjadminController.InsertUpdate_Line_Process_Audit_decision(Convert.ToInt32(ViewState["ProcessType"].ToString()), Convert.ToInt32(ViewState["UnitId"].ToString()), Convert.ToInt32(ViewState["InternalAuditId"].ToString()), Convert.ToInt32(ViewState["QAcompilation"].ToString()), Convert.ToInt32(ViewState["ValueId"].ToString()), rdobtnVal, Remarks, applyValue, UserId, ViewState["LineNo"].ToString(), IsClosed, ImageFile, IsActive, ViewState["CompareDate"].ToString(), OutHouseValue, flag);
                }
                else
                {
                    comments = Remarks;

                    DataSet dsProductQCpt = odjadminController.GetProductOccupationalAudit(Convert.ToInt32(ViewState["UnitId"].ToString()), Convert.ToInt32(ViewState["ProcessType"].ToString()));
                    DataTable dsProductQCptProcess = dsProductQCpt.Tables[0];
                    if (dsProductQCptProcess.Rows.Count > 0)
                    {
                        for (int i = 0; i < dsProductQCptProcess.Rows.Count; i++)
                        {
                            result = odjadminController.InsertUpdate_Line_Process_Audit_decision_All(Convert.ToInt32(dsProductQCptProcess.Rows[i]["ProcessType"].ToString()), Convert.ToInt32(ViewState["UnitId"].ToString()), Convert.ToInt32(dsProductQCptProcess.Rows[i]["Internal_Audit_ProcessID"].ToString()), Convert.ToInt32(ViewState["QAcompilation"].ToString()), Convert.ToInt32(ViewState["ValueId"].ToString()), rdobtnVal, comments, applyValue, UserId, ViewState["LineNo"].ToString(), ViewState["CompareDate"].ToString());
                        }
                    }
                }
            }
            else
            {
                result = odjadminController.InsertUpdate_Line_Process_Audit_decision(Convert.ToInt32(ViewState["ProcessType"].ToString()), Convert.ToInt32(ViewState["UnitId"].ToString()), Convert.ToInt32(ViewState["InternalAuditId"].ToString()), Convert.ToInt32(ViewState["QAcompilation"].ToString()), Convert.ToInt32(ViewState["ValueId"].ToString()), rdobtnVal, Remarks, applyValue, UserId, ViewState["LineNo"].ToString(), IsClosed, ImageFile, IsActive, ViewState["CompareDate"].ToString(),OutHouseValue,flag);
            }
        
            /*if (result > 0)
            {
                string script = "window.onload = function(){ ";
                script += "window.parent.CallRefresh(); self.parent.Shadowbox.close();};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
            else
            {
                string script = "window.onload = function(){ ";
                script += "window.parent.CallRefresh(); self.parent.Shadowbox.close();};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

            }*/
          if (result > 0)
           {
               string script = "window.onload = function(){ ";
               script += "self.parent.Shadowbox.close();};";
               ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
           }
           else
           {
               string script = "window.onload = function(){ ";
               script += "self.parent.Shadowbox.close();};";
               ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

           }
        }

        protected void rdobtnStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdobtnStatus.SelectedValue == "0" || rdobtnStatus.SelectedValue == "1")
            {
                chkApplyAll.Enabled = true;
                btnUpload1.Visible = false;
                Fldresolution.Visible = false;
            }
            else
            {
                chkApplyAll.Checked = false;
                chkApplyAll.Enabled = false;
                hdnchkapplyall.Value = "0";
                btnUpload1.Visible = true;
                Fldresolution.Visible = true;
            }
        }


        protected void RadioButtonActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonActive.SelectedValue == "0")
            {              
                textareaRemarks.Visible = false;
                rdobtnStatus.Visible = false;
                chkApplyAll.Checked = false;
                chkApplyAll.Visible = false;
            }
            else
            {
                textareaRemarks.Visible = true;
                rdobtnStatus.Visible = true;
                chkApplyAll.Visible = true;
                rdobtnStatus.SelectedValue = "1";
                chkApplyAll.Enabled = true;
            }
        }
    }
}