using System;
using System.Collections;
using System.Collections.Generic;
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
using iKandi.Web.Components;
using iKandi.Common;
using System.IO;
using System.Globalization;

namespace iKandi.Web.UserControls.Forms
{
    public partial class SeasonForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCleintV.Text = "";
            if (!IsPostBack)
            {
                BindDropDownList(!IsPostBack, ddlMonthFrom, ddlDateFrom);
                BindDropDownList(!IsPostBack, ddlMonthTo, ddlDateTo);
            }
            if (!IsPostBack)
            {
                if (Convert.ToInt32(Request.QueryString["cid"]) > 0)
                {
                    int intrr = Convert.ToInt32(Request.QueryString["cid"]);
                    hdnIdStatus.Value = Request.QueryString["cid"];
                    ClientController obj = new ClientController();
                    DataSet ds = obj.GetAllSeasonUpdateBAL(intrr);//
                    chkAllClient.DataSource = ds.Tables[1];
                    chkAllClient.RepeatColumns = 4;
                    chkAllClient.DataTextField = "officialname";
                    chkAllClient.DataValueField = "ClientId";
                    chkAllClient.DataBind();
                    for (int i = 0; i <= chkAllClient.Items.Count - 1; i++)
                        if (Convert.ToInt32(ds.Tables[1].Rows[i]["Status"]) == 1)
                            chkAllClient.Items[i].Selected = true;
                    txtSeasonName.Text = Convert.ToString(ds.Tables[0].Rows[0]["SeasonName"]);

                    ddlMonthFrom.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["StartMonth"]);

                    ddlDateFrom.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["StartDate"]);
                    //
                    ddlMonthTo.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["EndMonth"]);

                    ddlDateTo.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["EndDate"]);

                    // txtSeasonStartDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["SeasonStartDate"]);
                    // txtSeasonEndDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["SeasonEndDate"]);
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"]) == true)
                        chkIsActivate.Checked = true;
                    else
                        chkIsActivate.Checked = false;


                }
            }
            if (!IsPostBack)
                if (Request.QueryString["cid"] == null || Convert.ToInt32(Request.QueryString["cid"]) == 0)
                    bindClients();


        }

        public void bindClients()
        {
            ClientController obj = new ClientController();
            chkAllClient.DataSource = obj.GetAllClientBAL();
            chkAllClient.RepeatColumns = 7;
            chkAllClient.DataTextField = "officialname";
            chkAllClient.DataValueField = "ClientId";
            chkAllClient.DataBind();

        }

        public string getCheckedClient()
        {
            string strXML = "<Table>";
            for (int i = 0; i <= chkAllClient.Items.Count - 1; i++)
                if (chkAllClient.Items[i].Selected == true)
                {
                    strXML = strXML + "<ClientID>" + chkAllClient.Items[i].Value + "</clientID>";
                    strXML = strXML + "<id></id>";
                }
            strXML = strXML + "</Table>";
            return strXML;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (chkIsActivate.Checked)
                i = 1;
            ClientController obj = new ClientController();
            // if (Convert.ToInt32(Request.QueryString["cid"]) > 0)
            //  if(CheckClient())
            int[] SeasonDates = new int[4];
            SeasonDates[0] = Convert.ToInt32(ddlMonthFrom.SelectedValue);
            SeasonDates[1] = Convert.ToInt32(ddlDateFrom.SelectedValue);
            SeasonDates[2] = Convert.ToInt32(ddlMonthTo.SelectedValue);
            SeasonDates[3] = Convert.ToInt32(ddlDateTo.SelectedValue);

            if (CheckDate(SeasonDates))
            {
                obj.InsertSeasonBAL(SeasonDates, Convert.ToInt32(hdnIdStatus.Value), txtSeasonName.Text.Trim(), (DateTime)DateHelper.ParseDate(txtSeasonStartDate.Text.Trim()), (DateTime)DateHelper.ParseDate(txtSeasonEndDate.Text.Trim()), getCheckedClient(), i);
                Page page = HttpContext.Current.Handler as Page;
                String script = string.Empty; string stringMSG = "";
                if (Convert.ToInt32(Request.QueryString["cid"]) > 0)
                {
                    stringMSG = "Season Updated Successfully.";
                }
                else
                    stringMSG = "New Season created Successfully.";
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + stringMSG + "');", true);
            }


        }

        public bool CheckDate(int[] SeasonDates)
        {
            ClientController obj = new ClientController();
            if (Request.QueryString["cid"] == "" || Convert.ToInt32(Request.QueryString["cid"]) <= 0)
                if (obj.CheckDuplicateSeasonBAL(txtSeasonName.Text.Trim(), Convert.ToInt32(hdnIdStatus.Value)) > 0)
                {
                    Page page = HttpContext.Current.Handler as Page;
                    String script = string.Empty;
                    string stringMSG = "Season Already created.";
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg",
                                                        "alert('" + stringMSG + "');", true);
                    return false;
                }

            if (Convert.ToInt32(Request.QueryString["cid"]) > 0)
            {
                //if (obj.CheckDuplicateSeasonBAL(txtSeasonName.Text.Trim(), Convert.ToInt32(hdnIdStatus.Value)) > 0)
                //{
                //    Page page = HttpContext.Current.Handler as Page;
                //    String script = string.Empty;
                //    string stringMSG = "Season Already created.";
                //    ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg",
                //                                        "alert('" + stringMSG + "');", true);
                //    return false;
                //}


                //for (int z = 0; z <= chkAllClient.Items.Count - 1; z++)
                //    if (chkAllClient.Items[z].Selected == false || chkAllClient.Items[z].Selected == true)
                //        if (
                //            obj.CheckClientStatusBAL(Convert.ToInt32(hdnIdStatus.Value),
                //                                     Convert.ToInt32(chkAllClient.Items[z].Value)) > 0)
                //        {
                //            chkIsActivate.Checked = true;
                //            Page page = HttpContext.Current.Handler as Page;
                //            String script = string.Empty;
                //            string stringMSG = "Season already tagged some Style.";
                //            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg",
                //                                                "alert('" + stringMSG + "');", true);
                //            return false;
                //        }
            }



            int s = 0;
            for (int x = 0; x <= chkAllClient.Items.Count - 1; x++)
                if (chkAllClient.Items[x].Selected == false)
                    s = s + 1;
            int temp = s;
            if (temp == chkAllClient.Items.Count)
            {
                lblCleintV.Text = "Select Client.";
                return false;
            }
            for (int j = 0; j <= chkAllClient.Items.Count - 1; j++)
                if (chkAllClient.Items[j].Selected == true)
                    if (obj.CheckDateStatusBAL(SeasonDates, Convert.ToInt32(hdnIdStatus.Value), (DateTime)DateHelper.ParseDate(txtSeasonStartDate.Text.Trim()), (DateTime)DateHelper.ParseDate(txtSeasonEndDate.Text.Trim()), Convert.ToInt32(chkAllClient.Items[j].Value)) >= 1)
                    {
                        Page page = HttpContext.Current.Handler as Page;
                        String script = string.Empty;
                        string stringMSG = "Client " + Convert.ToString(chkAllClient.Items[j].Text) + " Already have season with these dates.";
                        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + stringMSG + "');", true);
                        return false;
                    }
            return true;

        }

        protected void ddlMonthFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropDownList(!IsPostBack, ddlMonthFrom, ddlDateFrom);
        }

        protected void ddlMonthTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropDownList(!IsPostBack, ddlMonthTo, ddlDateTo);
        }
        public void BindDropDownList(bool status, DropDownList ddlM, DropDownList ddlD)
        {
            DateTimeFormatInfo info = new DateTimeFormatInfo();
            string[] ss = info.MonthNames;
            DataTable dt = new DataTable();
            DataColumn dataColMonth = new DataColumn("Month", typeof(string));
            DataColumn dataColMonthId = new DataColumn("Id", typeof(int));
            dt.Columns.Add(dataColMonth);
            dt.Columns.Add(dataColMonthId);
            DataRow dr;
            for (int i = 0; i <= 11; i++)
            {
                dr = dt.NewRow();
                dt.Rows.Add(dr);
                dt.Rows[i][dataColMonth] = ss[i].Substring(0, 3);
                dt.Rows[i][dataColMonthId] = i + 1;
            }
            if (status == true)
            {
                ddlM.DataSource = dt;
                ddlM.DataValueField = "Id";
                ddlM.DataTextField = "Month";
                ddlM.DataBind();
                //   ddlM.SelectedValue = Convert.ToString(DateTime.Now.Month);
            }
            DataTable dtDate = new DataTable();
            DataColumn colDate = new DataColumn("Date", typeof(int));
            dtDate.Columns.Add(colDate);
            DataRow drDate;
            for (int x = 0; x <= DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(ddlM.SelectedValue)) - 1; x++)
            {
                drDate = dtDate.NewRow();
                dtDate.Rows.Add(drDate);
                dtDate.Rows[x][colDate] = x + 1;
            }
            ddlD.DataSource = dtDate;
            ddlD.DataValueField = "Date";
            ddlD.DataTextField = "Date";
            ddlD.DataBind();
            // if (Convert.ToInt32(Request.QueryString["cid"]) > 0)
            //  if (status == true)
            //    ddlD.SelectedValue = Convert.ToString(DateTime.Now.Day);

        }

       




    }
}