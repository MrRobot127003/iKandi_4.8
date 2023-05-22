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
using System.Collections.Generic;
using System.Text;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;
using System.Web.Services;


namespace iKandi.Web.Internal.Qc_Complience
{
    public partial class ProductOccupationalSafetyAudit : System.Web.UI.Page
    {

        int UnitId;
        int processType;
        DateTime now = DateTime.Now;
        AdminController objadmin = new AdminController();
        string failname;
        string floorType = "floor";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["UnitId"] != null)
            {
                UnitId = Convert.ToInt32(Request.QueryString["UnitId"].ToString());
                Session["UnitId"] = UnitId;
            }
            if (Request.QueryString["ProcessType"] != null)
            {
                processType = Convert.ToInt32(Request.QueryString["ProcessType"].ToString());
                Session["ProcessType"] = processType;
            }
            //Session["Selecteddate"] = dateSelect.Text;
            if (!IsPostBack)
            {
              if (Session["UnitId"].ToString() == "-1" && Session["ProcessType"].ToString() == "-1")
              {
                dateSelect.Text = DateTime.Today.AddDays(-1).ToString("dd MMM yy");// DateTime.Now.ToString("dd MMM yy")-1;
              }
              else
              {
                dateSelect.Text = DateTime.Now.ToString("dd MMM yy");
              }
            }
            BindTableProductQCpt();
        }
        protected void btnRefresh_Click(object sender, EventArgs e) 
        {
          ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "DoPostBack", "__doPostBack(sender, e)", true);
          //Response.Redirect(Request.RawUrl);

        }
        protected void BindTableProductQCpt()
        {
            string remarks = "";
            int PassFail = 5;
            int countFail;            
            DataSet dsvalue = new DataSet();
            DataSet resultValue = new DataSet();
            DataSet dsProductQCpt = new DataSet();
            dsProductQCpt = objadmin.GetProductOccupationalAudit(Convert.ToInt32(Session["UnitId"].ToString()), Convert.ToInt32(Session["ProcessType"].ToString()));
            DataTable dsProductQCptProcess = dsProductQCpt.Tables[0];
            DataTable dsProductQCptLine = dsProductQCpt.Tables[1];
            DataTable dsProductQCptTypeAdmin = dsProductQCpt.Tables[2];
            DataTable dsProductQCptCluster = dsProductQCpt.Tables[3];
            DataTable dsUnitNAme = dsProductQCpt.Tables[4];
            DataTable dsOutHouseFactory = dsProductQCpt.Tables[5];

            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            string IsActive="";
            int LineNo = dsProductQCptLine.Rows.Count;
            string ImageFile = "";
            int TypeAdmin = dsProductQCptTypeAdmin.Rows.Count;
            int ClusterCount = dsProductQCptCluster.Rows.Count;
            int QCptProcess = dsProductQCptProcess.Rows.Count;
            int columnSpan = LineNo + TypeAdmin + ClusterCount + 1;
            int width = 350 + LineNo * 60 + TypeAdmin * 60 + ClusterCount * 60;
            int OutHouseFactory = dsOutHouseFactory.Rows.Count;

            string str = "";
            if (QCptProcess > 0)
            {
                if (Convert.ToInt32(Session["ProcessType"].ToString()) == -1)
                {
                    width = 350 + OutHouseFactory * 70;
                    lblProcessName.Text = "Out House Audit Report";
                        mainhead.Attributes.Add("style", "width:" + width + "px");
                        str = "<table cellpadding='0' cellspacing='0' style='width:100%; margin:0px auto;' border='0' class='AddClass_Table headertopfixed'><tr><th>Product/ Occupational Safety (<span style='color:green'> Pass</span> / <span style='color:red'> Fail </span>)</th>";
                }
                else
                {
                    if (Convert.ToInt32(Session["ProcessType"].ToString()) == 1)
                    {
                        lblProcessName.Text = dsUnitNAme.Rows[0]["Name"] + "&nbsp; Product/ Occupational Safety Audit and Lines Process Audit Report (Compliance)";
                        mainhead.Attributes.Add("style", "width:" + width + "px");
                        //str = "<table cellpadding='0' cellspacing='0' style='width:" + width + "px; margin:0px auto;' border='1' class='item_list1'><tr><th colspan='" + columnSpan + "' style='font-size: 12px !important;'>" + dsUnitNAme.Rows[0]["Name"] + " Product/ Occupational Safety Audit and Lines Process Audit Report (Compliance)</th></tr><tr><th>Product/ Occupational Safety (<span style='color:green'> Pass</span> / <span style='color:red'> Fail </span>) </th>";
                        str = "<table cellpadding='0' cellspacing='0' style='width:100%; margin:0px auto;' border='0' class='AddClass_Table headertopfixed'><tr><th>Product/ Occupational Safety (<span style='color:green'> Pass</span> / <span style='color:red'> Fail </span>) </th>";
                    }
                    else
                    {
                        lblProcessName.Text = dsUnitNAme.Rows[0]["Name"] + "&nbsp; Quality Audit Report";
                        mainhead.Attributes.Add("style", "width:" + width + "px");
                        //str = "<table cellpadding='0' cellspacing='0' style='width:" + width + "px; margin:0px auto;' border='1' class='item_list1'><tr><th colspan='" + columnSpan + "' style='font-size: 12px !important;'><div style='float:left;'><input type='date'>&nbsp; <input type='button' name='Go' value='Go' class='submit'></div>" + dsUnitNAme.Rows[0]["Name"] + " Inline Process Audit Report (Quality Audit)</th></tr><tr><th>Process Audit Report (<span style='color:green'> Pass</span> / <span style='color:red'> Fail </span>) </th>";
                        str = "<table cellpadding='0' cellspacing='0' style='width:100%; margin:0px auto;' border='0' class='AddClass_Table headertopfixed'><tr><th>Process Audit Report (<span style='color:green'> Pass</span> / <span style='color:red'> Fail </span>) </th>";
                    }
                }
                if (LineNo > 0)
                {
                    for (int i = 0; i < LineNo; i++)
                    {
                        str = str + "<th> Line " + dsProductQCptLine.Rows[i].ItemArray[0].ToString() + "</th>";
                    }
                }
                if (ClusterCount > 0)
                {
                    for (int j = 0; j < ClusterCount; j++)
                    {
                        str = str + "<th> Fin Clstr " + dsProductQCptCluster.Rows[j].ItemArray[0].ToString() + "</th>";
                    }
                }
                if (TypeAdmin > 0)
                {
                    for (int Ab = 0; Ab < TypeAdmin; Ab++)
                    {
                        str = str + "<th>" + dsProductQCptTypeAdmin.Rows[Ab].ItemArray[1].ToString() + "</th>";
                    }
                }

                if (Convert.ToInt32(Session["ProcessType"].ToString()) == -1)
                {
                    if (OutHouseFactory > 0)
                    {
                        for (int OH = 0; OH < OutHouseFactory; OH++)
                        {
                            str = str + "<th>" + dsOutHouseFactory.Rows[OH].ItemArray[0].ToString() + "</th>";
                        }
                    }
                }

                // str = str + "<th>" + dsProductQCptTypeAdmin.Rows[1].ItemArray[1].ToString() + "</th> </tr>";

                for (int k = 0; k < QCptProcess; k++)
                {
                    str = str + "<tr><td style='width:350px; text-align:left;'>" + dsProductQCptProcess.Rows[k].ItemArray[1].ToString() + "</td>";
                    if (LineNo > 0)
                    {
                        for (int l = 0; l < LineNo; l++)
                        {

                            dsvalue = objadmin.GetLineProcessValue(Convert.ToInt32(Session["UnitId"].ToString()), Convert.ToInt32(dsProductQCptProcess.Rows[k].ItemArray[2].ToString()), Convert.ToInt32(dsProductQCptProcess.Rows[k].ItemArray[0].ToString()), 1, Convert.ToInt32(dsProductQCptLine.Rows[l].ItemArray[0].ToString()), dsProductQCptLine.Rows[l].ItemArray[0].ToString().Replace("&", "~"), dateSelect.Text,false);

                            if (dsvalue.Tables[2].Rows.Count > 0)
                            {
                                IsActive = dsvalue.Tables[2].Rows[0]["IsActive"].ToString();
                            }
                            else
                            {
                                IsActive = "True";
                            }
                            if (dsvalue.Tables[0].Rows.Count > 0)
                            {
                                remarks = dsvalue.Tables[0].Rows[0]["Remarks"].ToString();
                                if (dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString() != "")
                                {
                                    PassFail = Convert.ToInt32(dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString());
                                }
                                else
                                {
                                    PassFail = 5;
                                }
                                //ApplyToAll = Convert.ToInt32(dsvalue.Tables[0].Rows[0]["ApplyToAll"].ToString());
                                ImageFile = dsvalue.Tables[0].Rows[0]["ImageFile"].ToString();
                            }
                            else
                            {
                                remarks = "";
                                PassFail = 5;
                                ImageFile = "";
                            }
                            if (PassFail == 1)
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='background:green; width:60px;'>";
                            }
                            else if (PassFail == 2)
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='background:red;width:60px;'>";
                                if (ImageFile != "")
                                {
                                    failname = failname + "~" + dsProductQCptProcess.Rows[k].ItemArray[1].ToString() + " (Line No " + dsProductQCptLine.Rows[l].ItemArray[0].ToString() + ")=" + remarks + "=" + ImageFile;
                                }
                                else
                                {
                                    failname = failname + "~" + dsProductQCptProcess.Rows[k].ItemArray[1].ToString() + " (Line No " + dsProductQCptLine.Rows[l].ItemArray[0].ToString() + ")=" + remarks;
                                }
                            }
                            else if (PassFail == 0)
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:60px;'>Closed";
                            }
                            else if (IsActive == "False" && UserId != 2)
                            {

                                str = str + "<td title='" + remarks + "' style='width:60px; background:#f2f2f2;'>";
                            }
                            else if (IsActive == "False" && UserId == 2)
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:60px;background:#f2f2f2;'>";
                            }
                            else
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:60px;'>";
                            }

                            str = str + "<input type='hidden' class='InternalAuditId' value=" + dsProductQCptProcess.Rows[k].ItemArray[0].ToString() + ">";
                            str = str + "<input type='hidden' class='UnitId' value=" + Convert.ToInt32(Session["UnitId"].ToString()) + ">";
                            //str = str + "<input type='hidden' class='ProcessType' value=" + dsProductQCptProcess.Rows[k].ItemArray[2].ToString() + ">";
                            str = str + "<input type='hidden' class='ProcessType' value=" + Convert.ToInt32(Session["ProcessType"].ToString()) + ">";
                            str = str + "<input type='hidden' class='QAcompilation' value='1'>";
                            str = str + "<input type='hidden' class='ValueId' value='" + dsProductQCptLine.Rows[l].ItemArray[0].ToString() + "'>";
                            str = str + "<input type='hidden' class='LineNo' value=" + dsProductQCptLine.Rows[l].ItemArray[0].ToString().Replace("&", "~") + ">";
                            str = str + "<input type='hidden' class='LineName' value='" + dsProductQCptLine.Rows[l].ItemArray[0].ToString().Replace("&", "~") + "'>";
                            str = str + "<span style='display:none'  class='CompareDate'> " + dateSelect.Text + "</span>";
                            str = str + "</td>";

                        }
                    }

                    if (ClusterCount > 0)
                    {
                        for (int m = 0; m < ClusterCount; m++)
                        {
                            dsvalue = objadmin.GetLineProcessValue(Convert.ToInt32(Session["UnitId"].ToString()), Convert.ToInt32(dsProductQCptProcess.Rows[k].ItemArray[2].ToString()), Convert.ToInt32(dsProductQCptProcess.Rows[k].ItemArray[0].ToString()), 2, Convert.ToInt32(dsProductQCptCluster.Rows[m].ItemArray[1].ToString()), dsProductQCptCluster.Rows[m].ItemArray[0].ToString().Replace("&", "~"), dateSelect.Text,false);
                            if (dsvalue.Tables[2].Rows.Count > 0)
                            {
                                IsActive = dsvalue.Tables[2].Rows[0]["IsActive"].ToString();
                            }
                            else
                            {
                                IsActive = "True";
                            }
                            if (dsvalue.Tables[0].Rows.Count > 0)
                            {
                                remarks = dsvalue.Tables[0].Rows[0]["Remarks"].ToString();
                               
                                   // PassFail = Convert.ToInt32(dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString());
                                    if (dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString() != "")
                                    {
                                        PassFail = Convert.ToInt32(dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString());
                                    }
                                    else
                                    {
                                        PassFail = 5;
                                    }
                                ImageFile = dsvalue.Tables[0].Rows[0]["ImageFile"].ToString();
                            }
                            else
                            {
                                remarks = "";
                                PassFail = 5;
                                ImageFile = "";
                            }
                            if (PassFail == 1)
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='background:green; width:60px;'>";
                            }
                            else if (PassFail == 2)
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='background:red;width:60px;'>";
                                if (ImageFile != "")
                                {
                                    failname = failname + "~" + dsProductQCptProcess.Rows[k].ItemArray[1].ToString() + " (Cluster " + dsProductQCptCluster.Rows[m].ItemArray[0].ToString() + ")=" + remarks + "=" + ImageFile;
                                }
                                else
                                {
                                    failname = failname + "~" + dsProductQCptProcess.Rows[k].ItemArray[1].ToString() + " (Cluster " + dsProductQCptCluster.Rows[m].ItemArray[0].ToString() + ")=" + remarks;
                                }
                            }
                            else if (PassFail == 0)
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:60px;'>Closed";
                            }
                            else if (IsActive == "False" && UserId != 2)
                            {

                                str = str + "<td title='" + remarks + "' style='width:60px; background:#f2f2f2;'>";
                            }
                            else if (IsActive == "False" && UserId == 2)
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:60px;background:#f2f2f2;'>";
                            }
                            else
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:60px;'>";
                            }

                            str = str + "<input type='hidden' class='InternalAuditId' value=" + dsProductQCptProcess.Rows[k].ItemArray[0].ToString() + ">";
                            str = str + "<input type='hidden' class='UnitId' value=" + Convert.ToInt32(Session["UnitId"].ToString()) + ">";
                            //str = str + "<input type='hidden' class='ProcessType' value=" + dsProductQCptProcess.Rows[k].ItemArray[2].ToString() + ">";
                            str = str + "<input type='hidden' class='ProcessType' value=" + Convert.ToInt32(Session["ProcessType"].ToString()) + ">";
                            str = str + "<input type='hidden' class='QAcompilation' value='2'>";
                            str = str + "<input type='hidden' class='ValueId' value='" + dsProductQCptCluster.Rows[m].ItemArray[1].ToString() + "'>";
                            str = str + "<input type='hidden' class='LineNo' value=" + dsProductQCptCluster.Rows[m].ItemArray[0].ToString().Replace("&", "~") + ">";
                            str = str + "<input type='hidden' class='LineName' value='" + dsProductQCptCluster.Rows[m].ItemArray[0].ToString().Replace("&", "~") + "'>";
                            str = str + "<span style='display:none'  class='CompareDate'> " + dateSelect.Text + "</span>";
                            str = str + "</td>";
                        }
                    }
                    if (TypeAdmin > 0)
                    {
                        for (int BI = 0; BI < TypeAdmin; BI++)
                        {
                            dsvalue = objadmin.GetLineProcessValue(Convert.ToInt32(Session["UnitId"].ToString()), Convert.ToInt32(dsProductQCptProcess.Rows[k].ItemArray[2].ToString()), Convert.ToInt32(dsProductQCptProcess.Rows[k].ItemArray[0].ToString()), Convert.ToInt32(dsProductQCptTypeAdmin.Rows[BI].ItemArray[0].ToString()), Convert.ToInt32(dsProductQCptTypeAdmin.Rows[BI].ItemArray[0].ToString()), dsProductQCptTypeAdmin.Rows[BI].ItemArray[1].ToString().Replace("&", "~"), dateSelect.Text,false);
                            if (dsvalue.Tables[2].Rows.Count > 0)
                            {
                                IsActive = dsvalue.Tables[2].Rows[0]["IsActive"].ToString();
                            }
                            else
                            {
                                IsActive = "True";
                            }
                            if (dsvalue.Tables[0].Rows.Count > 0)
                            {
                                remarks = dsvalue.Tables[0].Rows[0]["Remarks"].ToString();
                                if (dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString() != "")
                                {
                                    PassFail = Convert.ToInt32(dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString());
                                }
                                else
                                {
                                    PassFail = 5;
                                }
                                //    PassFail = Convert.ToInt32(dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString());
                               
                                ImageFile = dsvalue.Tables[0].Rows[0]["ImageFile"].ToString();
                            }
                            else
                            {
                                remarks = "";
                                PassFail = 5;
                                ImageFile = "";
                            }
                            if (PassFail == 1)
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='background:green; width:60px;'>";
                            }
                            else if (PassFail == 2)
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='background:red;width:60px;'>";
                                if (ImageFile != "")
                                {
                                    failname = failname + "~" + dsProductQCptProcess.Rows[k].ItemArray[1].ToString() + " (" + dsProductQCptTypeAdmin.Rows[BI].ItemArray[1].ToString() + ")=" + remarks + "=" + ImageFile;
                                }
                                else
                                {
                                    failname = failname + "~" + dsProductQCptProcess.Rows[k].ItemArray[1].ToString() + " (" + dsProductQCptTypeAdmin.Rows[BI].ItemArray[1].ToString() + ")=" + remarks;
                                }
                            }
                            else if (PassFail == 0)
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:60px;'>Closed";
                            }
                            else if (IsActive == "False" && UserId != 2)
                            {

                                str = str + "<td title='" + remarks + "' style='width:60px; background:#f2f2f2;'>";
                            }
                            else if (IsActive == "False" && UserId == 2)
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:60px;background:#f2f2f2;'>";
                            }
                            else
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:60px;'>";
                            }

                            str = str + "<input type='hidden' class='InternalAuditId' value=" + dsProductQCptProcess.Rows[k].ItemArray[0].ToString() + ">";
                            str = str + "<input type='hidden' class='UnitId' value=" + Convert.ToInt32(Session["UnitId"].ToString()) + ">";
                            //str = str + "<input type='hidden' class='ProcessType' value=" + dsProductQCptProcess.Rows[k].ItemArray[2].ToString() + ">";
                            str = str + "<input type='hidden' class='ProcessType' value=" + Convert.ToInt32(Session["ProcessType"].ToString()) + ">";
                            str = str + "<input type='hidden' class='QAcompilation' value='" + dsProductQCptTypeAdmin.Rows[BI].ItemArray[0].ToString() + "'>";
                            str = str + "<input type='hidden' class='ValueId' value='" + dsProductQCptTypeAdmin.Rows[BI].ItemArray[0].ToString() + "'>";
                            str = str + "<input type='hidden' class='LineNo' value='" + dsProductQCptTypeAdmin.Rows[BI].ItemArray[1].ToString().Replace("&", "~") + "'>";
                            str = str + "<input type='hidden' class='LineName' value='" + dsProductQCptTypeAdmin.Rows[BI].ItemArray[1].ToString().Replace("&", "~") + "'>";
                            str = str + "<span style='display:none'  class='CompareDate'> " + dateSelect.Text + "</span>";
                            str = str + "</td>";
                        }
                    }
                    if (Convert.ToInt32(Session["ProcessType"].ToString()) == -1)
                    {
                        if (OutHouseFactory > 0)
                        {
                            for (int OH = 0; OH < OutHouseFactory; OH++)
                            {
                                dsvalue = objadmin.GetLineProcessValue(Convert.ToInt32(Session["UnitId"].ToString()), Convert.ToInt32(dsProductQCptProcess.Rows[k].ItemArray[2].ToString()), Convert.ToInt32(dsProductQCptProcess.Rows[k].ItemArray[0].ToString()), 9998, 9999, dsOutHouseFactory.Rows[OH].ItemArray[1].ToString().Replace("&", "~"), dateSelect.Text,false);
                                if (dsvalue.Tables[2].Rows.Count > 0)
                                {
                                    IsActive = dsvalue.Tables[2].Rows[0]["IsActive"].ToString();
                                }
                                else
                                {
                                    IsActive = "True";
                                }
                                if (dsvalue.Tables[0].Rows.Count > 0)
                                {
                                    remarks = dsvalue.Tables[0].Rows[0]["Remarks"].ToString();
                                    if (dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString() != "")
                                    {
                                        PassFail = Convert.ToInt32(dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString());
                                    }
                                    else
                                    {
                                        PassFail = 5;
                                    }
                                    //    PassFail = Convert.ToInt32(dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString());

                                }
                                else
                                {
                                    remarks = "";
                                    PassFail = 5;
                                    ImageFile = "";
                                }


                                //Add For get text value//                                
                                if (dsProductQCptProcess.Rows[k].ItemArray[3].ToString() == "1")
                                {
                                    if (dsvalue.Tables[3].Rows.Count > 0)
                                    {
                                        if (dsvalue.Tables[3].Rows[0]["Alternation_Operator_OnMachine"].ToString() != "")
                                        {
                                            if (dsvalue.Tables[3].Rows[0]["Alternation_Operator_OnMachine"].ToString() == "0")
                                            {
                                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' style='width:70px; background:#dbdbd3;'>&nbsp;";
                                            }
                                            else
                                            {
                                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' style='width:70px;background:#dbdbd3'>" + dsvalue.Tables[3].Rows[0]["Alternation_Operator_OnMachine"].ToString();
                                            }
                                        }
                                        else
                                        {
                                            str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' style='width:70px;'>&nbsp;";
                                        }
                                    }
                                    else
                                    {
                                        str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' style='width:70px;'>&nbsp;";
                                    }
                                }

                                //end

                                else
                                {

                                    if (PassFail == 1)
                                    {
                                        str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='background:green; width:70px;'>";
                                    }
                                    else if (PassFail == 2)
                                    {
                                        str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='background:red;width:70px;'>";
                                        if (ImageFile != "")
                                        {
                                            failname = failname + "~" + dsProductQCptProcess.Rows[k].ItemArray[1].ToString() + "℥(" + dsOutHouseFactory.Rows[OH].ItemArray[0].ToString() + ")=" + remarks + "=" + ImageFile;
                                        }
                                        else
                                        {
                                            failname = failname + "~" + dsProductQCptProcess.Rows[k].ItemArray[1].ToString() + "℥(" + dsOutHouseFactory.Rows[OH].ItemArray[0].ToString() + ")=" + remarks;
                                        }
                                    }
                                    else if (PassFail == 0)
                                    {
                                        str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:70px;'>Closed";
                                    }
                                    else if (IsActive == "False" && UserId != 2)
                                    {

                                        str = str + "<td title='" + remarks + "' style='width:70px; background:#f2f2f2;'>";
                                    }
                                    else if (IsActive == "False" && UserId == 2)
                                    {
                                        str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:70px;background:#f2f2f2;'>";
                                    }
                                    else
                                    {
                                        str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:70px;'>";
                                    }
                                }
                                str = str + "<input type='hidden' class='InternalAuditId' value=" + dsProductQCptProcess.Rows[k].ItemArray[0].ToString() + ">";
                                str = str + "<input type='hidden' class='UnitId' value=" + Convert.ToInt32(Session["UnitId"].ToString()) + ">";
                                //str = str + "<input type='hidden' class='ProcessType' value=" + dsProductQCptProcess.Rows[k].ItemArray[2].ToString() + ">";
                                str = str + "<input type='hidden' class='ProcessType' value=" + Convert.ToInt32(Session["ProcessType"].ToString()) + ">";
                                str = str + "<input type='hidden' class='QAcompilation' value='9998'>";
                                str = str + "<input type='hidden' class='ValueId' value='9999'>";
                                str = str + "<input type='hidden' class='LineNo' value='" + dsOutHouseFactory.Rows[OH].ItemArray[1].ToString().Replace("&", "~") + "'>";
                                str = str + "<input type='hidden' class='LineName' value='" + dsOutHouseFactory.Rows[OH].ItemArray[0].ToString().Replace("&", "~") + "'>";
                                str = str + "<span style='display:none'  class='CompareDate'> " + dateSelect.Text + "</span>";
                                str = str + "</td>";
                            }
                        }

                    }
                    str = str + "</tr>";
                }

                // Start Pass Fail Footer

                str = str + "<tr><td style='width:350px; text-align:left;'> <b> Result:- </b>( <font color='green'> Pass </font>/<font color='red'> Fail </font>) </td>";
                if (LineNo > 0)
                {
                    for (int O = 0; O < LineNo; O++)
                    {
                        resultValue = objadmin.GetProductOccuptionResult(Convert.ToInt32(Session["UnitId"].ToString()), 1, Convert.ToInt32(dsProductQCptLine.Rows[O].ItemArray[0].ToString()), Convert.ToInt32(Session["ProcessType"].ToString()), dateSelect.Text, floorType,false);
                        if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 2)
                        {
                            str = str + "<td style='background:red; width:60px;'></td>";
                        }
                        else if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 0)
                        {
                            str = str + "<td style='background:white; width:60px;'></td>";
                        }
                        else
                        {
                            str = str + "<td style='background:green; width:60px;'></td>";
                        }
                    }
                }

                if (ClusterCount > 0)
                {
                    for (int P = 0; P < ClusterCount; P++)
                    {
                        resultValue = objadmin.GetProductOccuptionResult(Convert.ToInt32(Session["UnitId"].ToString()), 2, Convert.ToInt32(dsProductQCptCluster.Rows[P].ItemArray[1].ToString()), Convert.ToInt32(Session["ProcessType"].ToString()), dateSelect.Text, floorType,false);
                        if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 2)
                        {
                            str = str + "<td style='background:red; width:60px;'></td>";
                        }
                        else if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 0)
                        {
                            str = str + "<td style='background:white; width:60px;'></td>";
                        }
                        else
                        {
                            str = str + "<td style='background:green; width:60px;'></td>";
                        }
                    }
                }
                if (TypeAdmin > 0)
                {
                    for (int BP = 0; BP < TypeAdmin; BP++)
                    {

                        resultValue = objadmin.GetProductOccuptionResult(Convert.ToInt32(Session["UnitId"].ToString()), Convert.ToInt32(dsProductQCptTypeAdmin.Rows[BP].ItemArray[0].ToString()), Convert.ToInt32(dsProductQCptTypeAdmin.Rows[BP].ItemArray[0].ToString()), Convert.ToInt32(Session["ProcessType"].ToString()), dateSelect.Text, floorType,false);
                        if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 2)
                        {
                            str = str + "<td style='background:red; width:60px;'></td>";
                        }
                        else if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 0)
                        {
                            str = str + "<td style='background:white; width:60px;'></td>";
                        }
                        else
                        {
                            str = str + "<td style='background:green; width:60px;'></td>";
                        }
                    }

                }
                if (Convert.ToInt32(Session["ProcessType"].ToString()) == -1)
                {
                    if (OutHouseFactory > 0)
                    {
                        for (int OH = 0; OH < OutHouseFactory; OH++)
                        {
                            resultValue = objadmin.GetProductOccuptionResult(Convert.ToInt32(Session["UnitId"].ToString()), 9998, 9999, Convert.ToInt32(Session["ProcessType"].ToString()), dateSelect.Text,dsOutHouseFactory.Rows[OH].ItemArray[1].ToString().Replace("&", "~"),false);
                            if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 2)
                            {
                                str = str + "<td style='background:red; width:60px;'></td>";
                            }
                            else if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 0)
                            {
                                str = str + "<td style='background:white; width:60px;'></td>";
                            }
                            else
                            {
                                str = str + "<td style='background:green; width:60px;'></td>";
                            }
                        }
                    }
                }
                str = str + "</tr>";
                //End Of Pass Fail Footer


                if (failname != null)
                {
                    if (Convert.ToInt32(Session["ProcessType"].ToString()) == -1)
                    {
                        columnSpan = OutHouseFactory + 1;
                    }
                    str = str + "<tr><th colspan='" + columnSpan + "' style='font-size: 12px !important;'>Remarks:-</th></tr>";
                    string[] FailRemark = failname.Split('~');
                    countFail = FailRemark.Length;
                    for (int n = 1; n < countFail; n++)
                    {
                        string[] FailRemarkUpdated = FailRemark[n].Split('=');
                        
                        if (FailRemarkUpdated.Length == 3)
                        {
                            string[] FailRemarkImage = FailRemarkUpdated[2].Split('$');
                            string[] failunit = FailRemarkUpdated[0].Split('℥');
                            if (Convert.ToInt32(Session["ProcessType"].ToString()) == -1)
                            {
                                str = str + "<tr><td colspan='" + columnSpan + "' style='font-size: 12px !important;text-align:left;'><span style='color:gray'>" + failunit[0] + "</span><span style='color:black'>&nbsp;" + failunit[1] + "</span>:-&nbsp;&nbsp;" + FailRemarkUpdated[1] + "&nbsp; &nbsp;";
                            }
                            else
                            {
                                str = str + "<tr><td colspan='" + columnSpan + "' style='font-size: 12px !important;text-align:left;'><span style='color:gray'>" + FailRemarkUpdated[0] + ":-</span>&nbsp; &nbsp;" + FailRemarkUpdated[1] + "&nbsp; &nbsp;";
                            }
                            for (int img = 0; img < FailRemarkImage.Length; img++)
                            {
                                string imageFullPath = "http://localhost:3220/uploads/OwnerRes/" + FailRemarkImage[img];
                                str = str + "<img src=" + imageFullPath + " style='float:right;height:25px;width:25px;' class='preview' />";
                            }
                            str = str + "</td></tr>";
                        }
                        else
                        {
                            if (FailRemarkUpdated.Length == 2)
                            {
                                string[] failunit = FailRemarkUpdated[0].Split('℥');
                                if (Convert.ToInt32(Session["ProcessType"].ToString()) == -1)
                                {
                                    str = str + "<tr><td colspan='" + columnSpan + "' style='font-size: 12px !important;text-align:left;'><span style='color:gray'>" + failunit[0] + "</span><span style='color:black'>&nbsp;" + failunit[1] + "</span>:-&nbsp;&nbsp;" + FailRemarkUpdated[1] + "</td></tr>";
                                }
                                else
                                {
                                    str = str + "<tr><td colspan='" + columnSpan + "' style='font-size: 12px !important;text-align:left;'><span style='color:gray'>" + FailRemarkUpdated[0] + ":-</span>&nbsp; &nbsp;" + FailRemarkUpdated[1] + "</td></tr>";
                                }
                            }
                            else
                            {
                                 string[] failunit = FailRemarkUpdated[0].Split('℥');
                                 if (Convert.ToInt32(Session["ProcessType"].ToString()) == -1)
                                 {
                                     str = str + "<tr><td colspan='" + columnSpan + "' style='font-size: 12px !important;text-align:left;'><span style='color:gray'>" + failunit[0] + "</span><span style='color:black'>&nbsp;" + failunit[1] + "</span></td></tr>";
                                 }
                                 else
                                 {
                                     str = str + "<tr><td colspan='" + columnSpan + "' style='font-size: 12px !important;text-align:left;'><span style='color:gray'>" + FailRemarkUpdated[0] + ":-</span></td></tr>";
                                 }
                            }
                        }
                    }
                    if (Convert.ToInt32(Session["ProcessType"].ToString()) == -1)
                    {
                        str = str + "<tr><th colspan='" + columnSpan + "' style='font-size: 12px !important;'>Audit By BIPL</th></tr>";
                    }
                    else
                    {
                        if (Convert.ToInt32(Session["ProcessType"].ToString()) == 1)
                        {
                            str = str + "<tr><th colspan='" + columnSpan + "' style='font-size: 12px !important;'>Audit By - HR & Compliance</th></tr>";
                        }
                        else
                        {
                            str = str + "<tr><th colspan='" + columnSpan + "' style='font-size: 12px !important;'>Audit By CQD- " + ApplicationHelper.LoggedInUser.UserData.FirstName + "</th></tr>";
                        }
                    }
                }
                str = str + "</table>";
                ProductOccuPational.InnerHtml = str;
            }
        }

        protected void Go_Click(object sender, EventArgs e)
        {           
            BindTableProductQCpt();
        }


        [WebMethod]
        public static string CallRefresh(string ProcessType, string Unitid, string newDate)
        {
            string str = "";
            str = BindTableProductQCpt1(Convert.ToInt32(ProcessType), Convert.ToInt32(Unitid), newDate);
            return str;
        }

        protected static string BindTableProductQCpt1(int ProcessType, int Unitid, string newDate)
        {
            HttpContext.Current.Session["UnitId"] = Unitid;
            HttpContext.Current.Session["ProcessType"] = ProcessType;
            HttpContext.Current.Session["newdate"] = newDate;
            string Div = "";
            AdminController objadmin = new AdminController();
            string ImageFile = "";
            string failname = "";
            string remarks = "";
            int PassFail = 5;
            int countFail;
            string IsActive="";
            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;             
            DataSet dsvalue = new DataSet();
            DataSet resultValue = new DataSet();
            DataSet dsProductQCpt = new DataSet();
            dsProductQCpt = objadmin.GetProductOccupationalAudit(Convert.ToInt32(HttpContext.Current.Session["UnitId"].ToString()), Convert.ToInt32(HttpContext.Current.Session["ProcessType"].ToString()));
            DataTable dsProductQCptProcess = dsProductQCpt.Tables[0];
            DataTable dsProductQCptLine = dsProductQCpt.Tables[1];
            DataTable dsProductQCptTypeAdmin = dsProductQCpt.Tables[2];
            DataTable dsProductQCptCluster = dsProductQCpt.Tables[3];

            DataTable dsUnitNAme = dsProductQCpt.Tables[4];
            DataTable dsOutHouseFactory = dsProductQCpt.Tables[5];
            int OutHouseFactory = dsOutHouseFactory.Rows.Count;
            int LineNo = dsProductQCptLine.Rows.Count;
            int TypeAdmin = dsProductQCptTypeAdmin.Rows.Count;
            int ClusterCount = dsProductQCptCluster.Rows.Count;
            int QCptProcess = dsProductQCptProcess.Rows.Count;
            int columnSpan = LineNo + TypeAdmin + ClusterCount + 1;
            int width = 350 + LineNo * 60 + TypeAdmin * 60 + ClusterCount * 60;

            string str = "";
            if (QCptProcess > 0)
            {
                if (Convert.ToInt32(HttpContext.Current.Session["ProcessType"].ToString()) == -1)
                {
                    width = 350 + OutHouseFactory * 70;

                    str = "<table cellpadding='0' cellspacing='0' style='width:100%; margin:0px auto;' border='0' class='AddClass_Table headertopfixed'><tr><th>Product/ Occupational Safety (<span style='color:green'> Pass</span> / <span style='color:red'> Fail </span>) </th>";
                }
                else
                {
                    if (Convert.ToInt32(HttpContext.Current.Session["ProcessType"].ToString()) == 1)
                    {
                        //str = "<table cellpadding='0' cellspacing='0' style='width:" + width + "px; margin:0px auto;' border='1' class='item_list1'><tr><th colspan='" + columnSpan + "' style='font-size: 12px !important;'>" + dsUnitNAme.Rows[0]["Name"] + " Product/ Occupational Safety Audit and Lines Process Audit Report (Compliance)</th></tr><tr><th>Product/ Occupational Safety (<span style='color:green'> Pass</span> / <span style='color:red'> Fail </span>) </th>";
                        str = "<table cellpadding='0' cellspacing='0' style='width:100%; margin:0px auto;' border='0' class='AddClass_Table headertopfixed'><tr><th>Product/ Occupational Safety (<span style='color:green'> Pass</span> / <span style='color:red'> Fail </span>) </th>";
                    }
                    else
                    {
                        // str = "<table cellpadding='0' cellspacing='0' style='width:" + width + "px; margin:0px auto;' border='1' class='item_list1'><tr><th colspan='" + columnSpan + "' style='font-size: 12px !important;'>" + dsUnitNAme.Rows[0]["Name"] + " Inline Process Audit Report (Quality Audit)</th></tr><tr><th>Process Audit Report (<span style='color:green'> Pass</span> / <span style='color:red'> Fail </span>) </th>";
                        str = "<table cellpadding='0' cellspacing='0' style='width:100%; margin:0px auto;' border='0' class='AddClass_Table headertopfixed'><tr><th>Process Audit Report (<span style='color:green'> Pass</span> / <span style='color:red'> Fail </span>) </th>";
                    }
                }
                if (LineNo > 0)
                {
                    for (int i = 0; i < LineNo; i++)
                    {
                        str = str + "<th> Line " + dsProductQCptLine.Rows[i].ItemArray[0].ToString() + "</th>";
                    }
                }
                if (ClusterCount > 0)
                {
                    for (int j = 0; j < ClusterCount; j++)
                    {
                        str = str + "<th> Fin Clstr " + dsProductQCptCluster.Rows[j].ItemArray[0].ToString() + "</th>";
                    }
                }
                if (TypeAdmin > 0)
                {
                    for (int Ab = 0; Ab < TypeAdmin; Ab++)
                    {
                        str = str + "<th>" + dsProductQCptTypeAdmin.Rows[Ab].ItemArray[1].ToString() + "</th>";
                    }
                }


                if (Convert.ToInt32(HttpContext.Current.Session["ProcessType"].ToString()) == -1)
                {
                    if (OutHouseFactory > 0)
                    {
                        for (int OH = 0; OH < OutHouseFactory; OH++)
                        {
                            str = str + "<th>" + dsOutHouseFactory.Rows[OH].ItemArray[0].ToString() + "</th>";
                        }
                    }
                }
                // str = str + "<th>" + dsProductQCptTypeAdmin.Rows[1].ItemArray[1].ToString() + "</th> </tr>";

                for (int k = 0; k < QCptProcess; k++)
                {
                    str = str + "<tr><td style='width:350px; text-align:left;'>" + dsProductQCptProcess.Rows[k].ItemArray[1].ToString() + "</td>";
                    if (LineNo > 0)
                    {
                        for (int l = 0; l < LineNo; l++)
                        {
                            dsvalue = objadmin.GetLineProcessValue(Convert.ToInt32(HttpContext.Current.Session["UnitId"].ToString()), Convert.ToInt32(dsProductQCptProcess.Rows[k].ItemArray[2].ToString()), Convert.ToInt32(dsProductQCptProcess.Rows[k].ItemArray[0].ToString()), 1, Convert.ToInt32(dsProductQCptLine.Rows[l].ItemArray[0].ToString()), dsProductQCptLine.Rows[l].ItemArray[0].ToString().Replace("&", "~"), HttpContext.Current.Session["newdate"].ToString(),false);
                            if (dsvalue.Tables[2].Rows.Count > 0)
                            {
                                IsActive = dsvalue.Tables[2].Rows[0]["IsActive"].ToString();
                            }
                            else
                            {
                                IsActive = "True";
                            }
                            if (dsvalue.Tables[0].Rows.Count > 0)
                            {
                                remarks = dsvalue.Tables[0].Rows[0]["Remarks"].ToString();
                               // PassFail = Convert.ToInt32(dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString());
                                if (dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString() != "")
                                {
                                    PassFail = Convert.ToInt32(dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString());
                                }
                                else
                                {
                                    PassFail = 5;
                                }
                                //ApplyToAll = Convert.ToInt32(dsvalue.Tables[0].Rows[0]["ApplyToAll"].ToString());
                                ImageFile = dsvalue.Tables[0].Rows[0]["ImageFile"].ToString();
                            }
                            else
                            {
                                remarks = "";
                                PassFail = 5;
                                ImageFile = "";
                            }
                            if (PassFail == 1)
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='background:green; width:60px;'>";
                            }
                            else if (PassFail == 2)
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='background:red;width:60px;'>";
                                if (ImageFile != "")
                                {
                                    failname = failname + "~" + dsProductQCptProcess.Rows[k].ItemArray[1].ToString() + " (Line No " + dsProductQCptLine.Rows[l].ItemArray[0].ToString() + ")=" + remarks + "=" + ImageFile;
                                }
                                else
                                {
                                    failname = failname + "~" + dsProductQCptProcess.Rows[k].ItemArray[1].ToString() + " (Line No " + dsProductQCptLine.Rows[l].ItemArray[0].ToString() + ")=" + remarks;
                                }
                            }
                            else if (PassFail == 0)
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:60px;'>Closed";
                            }
                            else if (IsActive == "False" && UserId != 2)
                            {

                                str = str + "<td title='" + remarks + "' style='width:60px; background:#f2f2f2;'>";
                            }
                            else if (IsActive == "False" && UserId == 2)
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:60px;background:#f2f2f2;'>";
                            }
                            else
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:60px;'>";
                            }
                            str = str + "<input type='hidden' class='InternalAuditId' value=" + dsProductQCptProcess.Rows[k].ItemArray[0].ToString() + ">";
                            str = str + "<input type='hidden' class='UnitId' value=" + Convert.ToInt32(HttpContext.Current.Session["UnitId"].ToString()) + ">";
                            //str = str + "<input type='hidden' class='ProcessType' value=" + dsProductQCptProcess.Rows[k].ItemArray[2].ToString() + ">";
                            str = str + "<input type='hidden' class='ProcessType' value=" + Convert.ToInt32(HttpContext.Current.Session["ProcessType"].ToString()) + ">";
                            str = str + "<input type='hidden' class='QAcompilation' value='1'>";
                            str = str + "<input type='hidden' class='ValueId' value='" + dsProductQCptLine.Rows[l].ItemArray[0].ToString() + "'>";
                            str = str + "<input type='hidden' class='LineNo' value=" + dsProductQCptLine.Rows[l].ItemArray[0].ToString().Replace("&", "~") + ">";
                            str = str + "<input type='hidden' class='LineName' value='" + dsProductQCptLine.Rows[l].ItemArray[0].ToString().Replace("&", "~") + "'>";
                            str = str + "<span style='display:none'  class='CompareDate'> " + HttpContext.Current.Session["newdate"].ToString() + "</span>";
                            str = str + "</td>";

                        }
                    }

                    if (ClusterCount > 0)
                    {
                        for (int m = 0; m < ClusterCount; m++)
                        {
                            dsvalue = objadmin.GetLineProcessValue(Convert.ToInt32(HttpContext.Current.Session["UnitId"].ToString()), Convert.ToInt32(dsProductQCptProcess.Rows[k].ItemArray[2].ToString()), Convert.ToInt32(dsProductQCptProcess.Rows[k].ItemArray[0].ToString()), 2, Convert.ToInt32(dsProductQCptCluster.Rows[m].ItemArray[1].ToString()), dsProductQCptCluster.Rows[m].ItemArray[0].ToString().Replace("&", "~"), HttpContext.Current.Session["newdate"].ToString(),false);
                            if (dsvalue.Tables[2].Rows.Count > 0)
                            {
                                IsActive = dsvalue.Tables[2].Rows[0]["IsActive"].ToString();
                            }
                            else
                            {
                                IsActive = "True";
                            }
                            if (dsvalue.Tables[0].Rows.Count > 0)
                            {
                                remarks = dsvalue.Tables[0].Rows[0]["Remarks"].ToString();
                                if (dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString() != "")
                                {
                                    PassFail = Convert.ToInt32(dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString());
                                }
                                else
                                {
                                    PassFail = 5;
                                }
                               // PassFail = Convert.ToInt32(dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString());
                                ImageFile = dsvalue.Tables[0].Rows[0]["ImageFile"].ToString();
                            }
                            else
                            {
                                remarks = "";
                                PassFail = 5;
                                ImageFile = "";
                            }
                            if (PassFail == 1)
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='background:green; width:60px;'>";
                            }
                            else if (PassFail == 2)
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='background:red;width:60px;'>";
                                if (ImageFile != "")
                                {
                                    failname = failname + "~" + dsProductQCptProcess.Rows[k].ItemArray[1].ToString() + " (Cluster " + dsProductQCptCluster.Rows[m].ItemArray[0].ToString() + ")=" + remarks + "=" + ImageFile;
                                }
                                else
                                {
                                    failname = failname + "~" + dsProductQCptProcess.Rows[k].ItemArray[1].ToString() + " (Cluster " + dsProductQCptCluster.Rows[m].ItemArray[0].ToString() + ")=" + remarks;
                                }
                            }
                            else if (PassFail == 0)
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:60px;'>Closed";
                            }
                            else if (IsActive == "False" && UserId != 2)
                            {

                                str = str + "<td title='" + remarks + "' style='width:60px; background:#f2f2f2;'>";
                            }
                            else if (IsActive == "False" && UserId == 2)
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:60px;background:#f2f2f2;'>";
                            }
                            else
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:60px;'>";
                            }
                            str = str + "<input type='hidden' class='InternalAuditId' value=" + dsProductQCptProcess.Rows[k].ItemArray[0].ToString() + ">";
                            str = str + "<input type='hidden' class='UnitId' value=" + Convert.ToInt32(HttpContext.Current.Session["UnitId"].ToString()) + ">";
                            //str = str + "<input type='hidden' class='ProcessType' value=" + dsProductQCptProcess.Rows[k].ItemArray[2].ToString() + ">";
                            str = str + "<input type='hidden' class='ProcessType' value=" + Convert.ToInt32(HttpContext.Current.Session["ProcessType"].ToString()) + ">";
                            str = str + "<input type='hidden' class='QAcompilation' value='2'>";
                            str = str + "<input type='hidden' class='ValueId' value='" + dsProductQCptCluster.Rows[m].ItemArray[1].ToString() + "'>";
                            str = str + "<input type='hidden' class='LineNo' value=" + dsProductQCptCluster.Rows[m].ItemArray[0].ToString().Replace("&", "~") + ">";
                            str = str + "<input type='hidden' class='LineName' value='" + dsProductQCptCluster.Rows[m].ItemArray[0].ToString().Replace("&", "~") + "'>";
                            str = str + "<span style='display:none'  class='CompareDate'> " + HttpContext.Current.Session["newdate"].ToString() + "</span>";
                            str = str + "</td>";
                        }
                    }
                    if (TypeAdmin > 0)
                    {
                        for (int BI = 0; BI < TypeAdmin; BI++)
                        {
                            dsvalue = objadmin.GetLineProcessValue(Convert.ToInt32(HttpContext.Current.Session["UnitId"].ToString()), Convert.ToInt32(dsProductQCptProcess.Rows[k].ItemArray[2].ToString()), Convert.ToInt32(dsProductQCptProcess.Rows[k].ItemArray[0].ToString()), Convert.ToInt32(dsProductQCptTypeAdmin.Rows[BI].ItemArray[0].ToString()), Convert.ToInt32(dsProductQCptTypeAdmin.Rows[BI].ItemArray[0].ToString()), dsProductQCptTypeAdmin.Rows[BI].ItemArray[1].ToString().Replace("&", "~"), HttpContext.Current.Session["newdate"].ToString(),false);
                            if (dsvalue.Tables[2].Rows.Count > 0)
                            {
                                IsActive = dsvalue.Tables[2].Rows[0]["IsActive"].ToString();
                            }
                            else
                            {
                                IsActive = "True";
                            }
                            if (dsvalue.Tables[0].Rows.Count > 0)
                            {
                                remarks = dsvalue.Tables[0].Rows[0]["Remarks"].ToString();
                                if (dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString() != "")
                                {
                                    PassFail = Convert.ToInt32(dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString());
                                }
                                else
                                {
                                    PassFail = 5;
                                }
                                //PassFail = Convert.ToInt32(dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString());
                                ImageFile = dsvalue.Tables[0].Rows[0]["ImageFile"].ToString();
                            }
                            else
                            {
                                remarks = "";
                                PassFail = 5;
                                ImageFile = "";
                            }
                            if (PassFail == 1)
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='background:green; width:60px;'>";
                            }
                            else if (PassFail == 2)
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='background:red;width:60px;'>";
                                if (ImageFile != "")
                                {
                                    failname = failname + "~" + dsProductQCptProcess.Rows[k].ItemArray[1].ToString() + " (" + dsProductQCptTypeAdmin.Rows[BI].ItemArray[1].ToString() + ")=" + remarks + "=" + ImageFile;
                                }
                                else
                                {
                                    failname = failname + "~" + dsProductQCptProcess.Rows[k].ItemArray[1].ToString() + " (" + dsProductQCptTypeAdmin.Rows[BI].ItemArray[1].ToString() + ")=" + remarks;
                                }
                            }
                            else if (PassFail == 0)
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:60px;'>Closed";
                            }
                            else if (IsActive == "False" && UserId != 2)
                            {

                                str = str + "<td title='" + remarks + "' style='width:60px; background:#f2f2f2;'>";
                            }
                            else if (IsActive == "False" && UserId == 2)
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:60px;background:#f2f2f2;'>";
                            }
                            else
                            {
                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:60px;'>";
                            }

                            str = str + "<input type='hidden' class='InternalAuditId' value=" + dsProductQCptProcess.Rows[k].ItemArray[0].ToString() + ">";
                            str = str + "<input type='hidden' class='UnitId' value=" + Convert.ToInt32(HttpContext.Current.Session["UnitId"].ToString()) + ">";
                            //str = str + "<input type='hidden' class='ProcessType' value=" + dsProductQCptProcess.Rows[k].ItemArray[2].ToString() + ">";
                            str = str + "<input type='hidden' class='ProcessType' value=" + Convert.ToInt32(HttpContext.Current.Session["ProcessType"].ToString()) + ">";
                            str = str + "<input type='hidden' class='QAcompilation' value='" + dsProductQCptTypeAdmin.Rows[BI].ItemArray[0].ToString() + "'>";
                            str = str + "<input type='hidden' class='ValueId' value='" + dsProductQCptTypeAdmin.Rows[BI].ItemArray[0].ToString() + "'>";
                            str = str + "<input type='hidden' class='LineNo' value='" + dsProductQCptTypeAdmin.Rows[BI].ItemArray[1].ToString().Replace("&", "~") + "'>";
                            str = str + "<input type='hidden' class='LineName' value='" + dsProductQCptTypeAdmin.Rows[BI].ItemArray[1].ToString().Replace("&", "~") + "'>";
                            str = str + "<span style='display:none'  class='CompareDate'> " + HttpContext.Current.Session["newdate"].ToString() + "</span>";
                            str = str + "</td>";
                        }
                    }



                    if (Convert.ToInt32(HttpContext.Current.Session["ProcessType"].ToString()) == -1)
                    {
                        if (OutHouseFactory > 0)
                        {
                            for (int OH = 0; OH < OutHouseFactory; OH++)
                            {
                                dsvalue = objadmin.GetLineProcessValue(Convert.ToInt32(HttpContext.Current.Session["UnitId"].ToString()), Convert.ToInt32(dsProductQCptProcess.Rows[k].ItemArray[2].ToString()), Convert.ToInt32(dsProductQCptProcess.Rows[k].ItemArray[0].ToString()), 9998, 9999, dsOutHouseFactory.Rows[OH].ItemArray[1].ToString().Replace("&", "~"), HttpContext.Current.Session["newdate"].ToString(),false);
                                if (dsvalue.Tables[2].Rows.Count > 0)
                                {
                                    IsActive = dsvalue.Tables[2].Rows[0]["IsActive"].ToString();
                                }
                                else
                                {
                                    IsActive = "True";
                                }
                                if (dsvalue.Tables[0].Rows.Count > 0)
                                {
                                    remarks = dsvalue.Tables[0].Rows[0]["Remarks"].ToString();
                                    if (dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString() != "")
                                    {
                                        PassFail = Convert.ToInt32(dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString());
                                    }
                                    else
                                    {
                                        PassFail = 5;
                                    }
                                    //    PassFail = Convert.ToInt32(dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString());

                                }
                                else
                                {
                                    remarks = "";
                                    PassFail = 5;
                                    ImageFile = "";
                                }

                                //Add For get text value//                                
                                if (dsProductQCptProcess.Rows[k].ItemArray[3].ToString() == "1")
                                {
                                    if (dsvalue.Tables[3].Rows.Count > 0)
                                    {
                                        if (dsvalue.Tables[3].Rows[0]["Alternation_Operator_OnMachine"].ToString() != "")
                                        {
                                            if (dsvalue.Tables[3].Rows[0]["Alternation_Operator_OnMachine"].ToString() == "0")
                                            {
                                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' style='width:70px; background:#dbdbd3'>&nbsp;";
                                            }
                                            else
                                            {
                                                str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' style='width:70px;background:#dbdbd3'>" + dsvalue.Tables[3].Rows[0]["Alternation_Operator_OnMachine"].ToString();
                                            }
                                        }
                                        else
                                        {
                                            str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' style='width:70px;'>&nbsp;";
                                        }
                                    }
                                    else
                                    {
                                        str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' style='width:70px;'>&nbsp;";
                                    }
                                }

                                //end


                                else
                                {
                                    if (PassFail == 1)
                                    {
                                        str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='background:green; width:70px;'>";
                                    }
                                    else if (PassFail == 2)
                                    {
                                        str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='background:red;width:70px;'>";
                                        if (ImageFile != "")
                                        {
                                            failname = failname + "~" + dsProductQCptProcess.Rows[k].ItemArray[1].ToString() + "℥(" + dsOutHouseFactory.Rows[OH].ItemArray[0].ToString() + ")=" + remarks + "=" + ImageFile;
                                        }
                                        else
                                        {
                                            failname = failname + "~" + dsProductQCptProcess.Rows[k].ItemArray[1].ToString() + "℥(" + dsOutHouseFactory.Rows[OH].ItemArray[0].ToString() + ")=" + remarks;
                                        }
                                    }
                                    else if (PassFail == 0)
                                    {
                                        str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:70px;'>Closed";
                                    }
                                    else if (IsActive == "False" && UserId != 2)
                                    {

                                        str = str + "<td title='" + remarks + "' style='width:70px; background:#f2f2f2;'>";
                                    }
                                    else if (IsActive == "False" && UserId == 2)
                                    {
                                        str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:70px;background:#f2f2f2;'>";
                                    }
                                    else
                                    {
                                        str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:70px;'>";
                                    }
                                }
                                str = str + "<input type='hidden' class='InternalAuditId' value=" + dsProductQCptProcess.Rows[k].ItemArray[0].ToString() + ">";
                                str = str + "<input type='hidden' class='UnitId' value=" + Convert.ToInt32(HttpContext.Current.Session["UnitId"].ToString()) + ">";
                                //str = str + "<input type='hidden' class='ProcessType' value=" + dsProductQCptProcess.Rows[k].ItemArray[2].ToString() + ">";
                                str = str + "<input type='hidden' class='ProcessType' value=" + Convert.ToInt32(HttpContext.Current.Session["ProcessType"].ToString()) + ">";
                                str = str + "<input type='hidden' class='QAcompilation' value='9998'>";
                                str = str + "<input type='hidden' class='ValueId' value='9999'>";
                                str = str + "<input type='hidden' class='LineNo' value='" + dsOutHouseFactory.Rows[OH].ItemArray[1].ToString().Replace("&", "~") + "'>";
                                str = str + "<input type='hidden' class='LineName' value='" + dsOutHouseFactory.Rows[OH].ItemArray[0].ToString().Replace("&", "~") + "'>";
                                str = str + "<span style='display:none'  class='CompareDate'> " + HttpContext.Current.Session["newdate"].ToString() + "</span>";
                                str = str + "</td>";
                            }
                        }

                    }
                    //    dsvalue = objadmin.GetLineProcessValue(UnitId, Convert.ToInt32(dsProductQCptProcess.Rows[k].ItemArray[2].ToString()), Convert.ToInt32(dsProductQCptProcess.Rows[k].ItemArray[0].ToString()), 4, -1, "Cutting");
                    //    if (dsvalue.Tables[0].Rows.Count > 0)
                    //    {
                    //        remarks = dsvalue.Tables[0].Rows[0]["Remarks"].ToString();
                    //        PassFail = Convert.ToInt32(dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString());
                    //    }
                    //    else
                    //    {
                    //        remarks = "";
                    //        PassFail = 5;
                    //    }
                    //    if (PassFail == 1)
                    //    {
                    //        str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='background:green; width:60px;'>";
                    //    }
                    //    else if (PassFail == 2)
                    //    {
                    //        str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='background:red;width:60px;'>";

                    //        failname = failname + "$Cutting/Fabfric Store_" + remarks;
                    //    }
                    //    else if (PassFail == 0)
                    //    {
                    //        str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:60px;'>Closed";
                    //    }
                    //    else
                    //    {
                    //        str = str + "<td onclick='javascript:OpenLineProcessAudit(this)' title='" + remarks + "' style='width:60px;'>";
                    //    }
                    //    str = str + "<input type='hidden' class='InternalAuditId' value=" + dsProductQCptProcess.Rows[k].ItemArray[0].ToString() + ">";
                    //    str = str + "<input type='hidden' class='UnitId' value=" + UnitId + ">";
                    //    //str = str + "<input type='hidden' class='ProcessType' value=" + dsProductQCptProcess.Rows[k].ItemArray[2].ToString() + ">";
                    //    str = str + "<input type='hidden' class='ProcessType' value=" + processType + ">";
                    //    str = str + "<input type='hidden' class='QAcompilation' value='4'>";
                    //    str = str + "<input type='hidden' class='ValueId' value='-1'>";
                    //    str = str + "<input type='hidden' class='LineNo' value='Cutting'>";
                    //    str = str + "</td>";
                    str = str + "</tr>";
                }

                // Start Pass Fail Footer

                str = str + "<tr><td style='width:350px; text-align:left;'> <b> Result:- </b>( <font color='green'> Pass </font>/<font color='red'> Fail </font>) </td>";
                if (LineNo > 0)
                {
                    for (int O = 0; O < LineNo; O++)
                    {
                        resultValue = objadmin.GetProductOccuptionResult(Convert.ToInt32(HttpContext.Current.Session["UnitId"].ToString()), 1, Convert.ToInt32(dsProductQCptLine.Rows[O].ItemArray[0].ToString()), Convert.ToInt32(HttpContext.Current.Session["ProcessType"].ToString()), HttpContext.Current.Session["newdate"].ToString(), "floorType",false);
                        if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 2)
                        {
                            str = str + "<td style='background:red; width:60px;'></td>";
                        }
                        else if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 0)
                        {
                            str = str + "<td style='background:white; width:60px;'></td>";
                        }
                        else
                        {
                            str = str + "<td style='background:green; width:60px;'></td>";
                        }
                    }
                }

                if (ClusterCount > 0)
                {
                    for (int P = 0; P < ClusterCount; P++)
                    {
                        resultValue = objadmin.GetProductOccuptionResult(Convert.ToInt32(HttpContext.Current.Session["UnitId"].ToString()), 2, Convert.ToInt32(dsProductQCptCluster.Rows[P].ItemArray[1].ToString()), Convert.ToInt32(HttpContext.Current.Session["ProcessType"].ToString()), HttpContext.Current.Session["newdate"].ToString(),"floorType",false);
                        if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 2)
                        {
                            str = str + "<td style='background:red; width:60px;'></td>";
                        }
                        else if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 0)
                        {
                            str = str + "<td style='background:white; width:60px;'></td>";
                        }
                        else
                        {
                            str = str + "<td style='background:green; width:60px;'></td>";
                        }
                    }
                }
                if (TypeAdmin > 0)
                {
                    for (int BP = 0; BP < TypeAdmin; BP++)
                    {

                        resultValue = objadmin.GetProductOccuptionResult(Convert.ToInt32(HttpContext.Current.Session["UnitId"].ToString()), Convert.ToInt32(dsProductQCptTypeAdmin.Rows[BP].ItemArray[0].ToString()), Convert.ToInt32(dsProductQCptTypeAdmin.Rows[BP].ItemArray[0].ToString()), Convert.ToInt32(HttpContext.Current.Session["ProcessType"].ToString()), HttpContext.Current.Session["newdate"].ToString(),"floorType",false);
                        if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 2)
                        {
                            str = str + "<td style='background:red; width:60px;'></td>";
                        }
                        else if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 0)
                        {
                            str = str + "<td style='background:white; width:60px;'></td>";
                        }
                        else
                        {
                            str = str + "<td style='background:green; width:60px;'></td>";
                        }
                    }

                }


                if (Convert.ToInt32(HttpContext.Current.Session["ProcessType"].ToString()) == -1)
                {
                    if (OutHouseFactory > 0)
                    {
                        for (int OH = 0; OH < OutHouseFactory; OH++)
                        {
                            resultValue = objadmin.GetProductOccuptionResult(Convert.ToInt32(HttpContext.Current.Session["UnitId"].ToString()), 9998, 9999, Convert.ToInt32(HttpContext.Current.Session["ProcessType"].ToString()), HttpContext.Current.Session["newdate"].ToString(),dsOutHouseFactory.Rows[OH].ItemArray[1].ToString().Replace("&", "~"),false);
                            if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 2)
                            {
                                str = str + "<td style='background:red; width:60px;'></td>";
                            }
                            else if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 0)
                            {
                                str = str + "<td style='background:white; width:60px;'></td>";
                            }
                            else
                            {
                                str = str + "<td style='background:green; width:60px;'></td>";
                            }
                        }
                    }
                }
                //resultValue = objadmin.GetProductOccuptionResult(UnitId, 4, -1, processType);
                //if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 1)
                //{
                //    str = str + "<td style='background:red; width:60px;'></td>";
                //}
                //else
                //{
                //    str = str + "<td style='background:green; width:60px;'></td>";
                //}
                str = str + "</tr>";
                //End Of Pass Fail Footer


                if (failname != null)
                {
                    if (Convert.ToInt32(HttpContext.Current.Session["ProcessType"].ToString()) == -1)
                    {
                        columnSpan = OutHouseFactory + 1;
                    }
                    str = str + "<tr><th colspan='" + columnSpan + "' style='font-size: 12px !important;'>Remarks:-</th></tr>";
                    string[] FailRemark = failname.Split('~');
                    countFail = FailRemark.Length;
                    for (int n = 1; n < countFail; n++)
                    {
                        string[] FailRemarkUpdated = FailRemark[n].Split('=');
                        if (FailRemarkUpdated.Length == 3)
                        {
                            string[] FailRemarkImage = FailRemarkUpdated[2].Split('$');
                            string[] failunit = FailRemarkUpdated[0].Split('℥');
                            if (Convert.ToInt32(HttpContext.Current.Session["ProcessType"].ToString()) == -1)
                            {
                                str = str + "<tr><td colspan='" + columnSpan + "' style='font-size: 12px !important;text-align:left;'><span style='color:gray'>" + failunit[0] + "</span><span style='color:black'>&nbsp;" + failunit[1] + "</span>:-&nbsp;&nbsp;" + FailRemarkUpdated[1] + "&nbsp; &nbsp;";
                            }
                            else
                            {
                                str = str + "<tr><td colspan='" + columnSpan + "' style='font-size: 12px !important;text-align:left;'><span style='color:gray'>" + FailRemarkUpdated[0] + ":-</span>&nbsp; &nbsp;" + FailRemarkUpdated[1] + "&nbsp; &nbsp;";
                            }
                            for (int img = 0; img < FailRemarkImage.Length; img++)
                            {
                                string imageFullPath = "http://localhost:3220/uploads/OwnerRes/" + FailRemarkImage[img];
                                str = str + "<img src=" + imageFullPath + " style='float:right;height:25px;width:25px;' class='preview' />";
                            }
                            str = str + "</td></tr>";
                        }
                        else
                        {
                            if (FailRemarkUpdated.Length == 2)
                            {
                                string[] failunit = FailRemarkUpdated[0].Split('℥');
                                if (Convert.ToInt32(HttpContext.Current.Session["ProcessType"].ToString()) == -1)
                                {
                                    str = str + "<tr><td colspan='" + columnSpan + "' style='font-size: 12px !important;text-align:left;'><span style='color:gray'>" + failunit[0] + "</span><span style='color:black'>&nbsp;" + failunit[1] + "</span>:-&nbsp;&nbsp;" + FailRemarkUpdated[1] + "</td></tr>";
                                }
                                else
                                {
                                    str = str + "<tr><td colspan='" + columnSpan + "' style='font-size: 12px !important;text-align:left;'><span style='color:gray'>" + FailRemarkUpdated[0] + ":-</span>&nbsp; &nbsp;" + FailRemarkUpdated[1] + "</td></tr>";
                                }
                            }
                            else
                            {
                                string[] failunit = FailRemarkUpdated[0].Split('℥');
                                if (Convert.ToInt32(HttpContext.Current.Session["ProcessType"].ToString()) == -1)
                                {
                                    str = str + "<tr><td colspan='" + columnSpan + "' style='font-size: 12px !important;text-align:left;'><span style='color:gray'>" + failunit[0] + "</span><span style='color:black'>&nbsp;" + failunit[1] + "</span></td></tr>";
                                }
                                else
                                {
                                    str = str + "<tr><td colspan='" + columnSpan + "' style='font-size: 12px !important;text-align:left;'><span style='color:gray'>" + FailRemarkUpdated[0] + ":-</span></td></tr>";
                                }
                            }
                        }
                    }
                    if (Convert.ToInt32(HttpContext.Current.Session["ProcessType"].ToString()) == -1)
                    {
                        str = str + "<tr><th colspan='" + columnSpan + "' style='font-size: 12px !important;'>Audit By BIPL</th></tr>";
                    }
                    else
                    {
                        if (Convert.ToInt32(HttpContext.Current.Session["ProcessType"].ToString()) == 1)
                        {
                            str = str + "<tr><th colspan='" + columnSpan + "' style='font-size: 12px !important;'>Audit By - HR & Compliance</th></tr>";
                        }
                        else
                        {
                            str = str + "<tr><th colspan='" + columnSpan + "' style='font-size: 12px !important;'>Audit By CQD- " + ApplicationHelper.LoggedInUser.UserData.FirstName + "</th></tr>";
                        }
                    }
                }
                str = str + "</table>";
                Div = str;
            }
            return Div;
        }
    }
}