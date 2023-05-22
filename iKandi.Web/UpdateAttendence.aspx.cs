using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using iKandi.Common;
using System.IO;
using System.Text;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using iKandi.BLL;

namespace iKandi.Web
{
  public partial class UpdateAttendence : System.Web.UI.Page
  {
    public string Flag
    {
      get;
      set;
    }

  
   
    
   
    AdminController objadmin = new AdminController();
    UserController objusercon = new UserController();
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!string.IsNullOrEmpty(Request.QueryString["INTIME"]))
      {
        Flag = Request.QueryString["INTIME"].ToString();
      }
      if (!string.IsNullOrEmpty(Request.QueryString["OUTTIME"]))
      {
        Flag = Request.QueryString["OUTTIME"].ToString();
      }
      if (!string.IsNullOrEmpty(Flag))
      {
        if (Flag.ToLower() == "INTIME".ToLower())
        {
          UpdateEmployeIntimetime();
        }
        else if (Flag.ToLower() == "OUTTIME".ToLower())
        {
          UpdateEmployeOuttimetime();
        }
      }


      //UpdateEmployeIntimetime();
      //UpdateEmployeOuttimetime();


    }
    public DataSet GetExcel(string fileName)
    {
      DataSet ds = new DataSet();
      Application oXL;
      Workbook oWB;
      Worksheet oSheet;
      Range oRng;
      try
      {
        oXL = new Application();
        oWB = oXL.Workbooks.Open(fileName, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value);
        oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oWB.Sheets[1];
        System.Data.DataTable dt = new System.Data.DataTable("dtExcel");
        ds.Tables.Add(dt);
        DataRow dr;
        StringBuilder sb = new StringBuilder();
        int jValue = oSheet.UsedRange.Cells.Columns.Count;
        int iValue = oSheet.UsedRange.Cells.Rows.Count;

        for (int j = 1; j <= jValue; j++)
        {
          dt.Columns.Add("column" + j, System.Type.GetType("System.String"));
        }
        for (int i = 1; i <= iValue; i++)
        {
          dr = ds.Tables["dtExcel"].NewRow();
          for (int j = 1; j <= jValue; j++)
          {
            oRng = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[i, j];
            string strValue = oRng.Text.ToString();
            dr["column" + j] = strValue;
          }
          ds.Tables["dtExcel"].Rows.Add(dr);
        }

      }
      catch (Exception ex)
      {
          ShowAlert(ex.ToString());
      }
      finally
      {
        Dispose();
      }
      return ds;
    }
    public void ShowAlert(string stringAlertMsg)
    {
        string myStringVariable = string.Empty;
        myStringVariable = stringAlertMsg;
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
    }
    public void UpdateEmployeIntimetime()
    {
      DataSet ds = null;
      try
      {
        ds = GetExcel("D:\\NEW ATTENDANCE.xlsx");

        System.Data.DataTable dtempdetails = new System.Data.DataTable();
        dtempdetails.Clear();
        dtempdetails.Columns.Add("EmpCardNo", typeof(string));
        dtempdetails.Columns.Add("Intime", typeof(string));
        dtempdetails.Columns.Add("outtime", typeof(string));
        dtempdetails.Columns.Add("EmpName", typeof(string));

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
          DataRow row = dtempdetails.NewRow();
          row["EmpCardNo"] = dr["column2"];
          row["Intime"] = dr["column8"];
          row["outtime"] = dr["column9"];
          row["EmpName"] = dr["column3"];
          dtempdetails.Rows.Add(row);
        }
        dtempdetails.AcceptChanges();
        string[] ArrReportdate = ds.Tables[0].Rows[3]["column3"].ToString().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);//get report date
        DateTime Reportdate = DateTime.ParseExact(ArrReportdate[1].Trim(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

        System.Data.DataTable Finaldt = new System.Data.DataTable();
        Finaldt = dtempdetails.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is DBNull || string.IsNullOrEmpty(field as string))).CopyToDataTable();
        foreach (DataRow dr in Finaldt.Rows)
        {
          string EmpCardNo = dr["EmpCardNo"].ToString();
          string EmpIntime = dr["Intime"].ToString();
          string Empoutetime = dr["outtime"].ToString();
          if (EmpCardNo != "" && EmpCardNo != "Card No")
          {
            System.Data.DataTable dtemp = objusercon.GetAllUsersbyEmpCode(EmpCardNo.Substring(3));
            if (dtemp.Rows.Count > 0)
            {
              string DepartmentID = dtemp.Rows[0]["PrimaryGroupID"].ToString();
              string DesignationID = dtemp.Rows[0]["DesignationID"].ToString();
              string UserID = dtemp.Rows[0]["UserID"].ToString();
              int Updatedby = 637;
              int i = objadmin.UpdateIntimeUser(Convert.ToInt32(DepartmentID), Convert.ToInt32(DesignationID), Convert.ToInt32(UserID), EmpIntime, Updatedby, Reportdate);

            }
          }
        }

      }
      catch (Exception ex)
      {
          System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

          System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
      }
    }
    public void UpdateEmployeOuttimetime()
    {
      DataSet ds = null;
      try
      {
        ds = GetExcel("D:\\NEW ATTENDANCE.xlsx");//set out time excel path here 

        System.Data.DataTable dtempdetails = new System.Data.DataTable();
        dtempdetails.Clear();
        dtempdetails.Columns.Add("EmpCardNo", typeof(string));
        dtempdetails.Columns.Add("Intime", typeof(string));
        dtempdetails.Columns.Add("outtime", typeof(string));
        dtempdetails.Columns.Add("EmpName", typeof(string));

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
          DataRow row = dtempdetails.NewRow();
          row["EmpCardNo"] = dr["column2"];
          row["Intime"] = dr["column8"];
          row["outtime"] = dr["column9"];
          row["EmpName"] = dr["column3"];
          dtempdetails.Rows.Add(row);
        }
        dtempdetails.AcceptChanges();
        string[] ArrReportdate = ds.Tables[0].Rows[3]["column3"].ToString().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);//get report date
       // DateTime Reportdate = DateTime.ParseExact(ArrReportdate[1].Trim(), "dd/MM/yyyy", null);
        DateTime Reportdate = DateTime.ParseExact(ArrReportdate[1].Trim(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        System.Data.DataTable Finaldt = new System.Data.DataTable();
        Finaldt = dtempdetails.Rows.Cast<DataRow>().Where(row => !row.ItemArray.All(field => field is DBNull || string.IsNullOrEmpty(field as string))).CopyToDataTable();
        foreach (DataRow dr in Finaldt.Rows)
        {
          string EmpCardNo = dr["EmpCardNo"].ToString();
          string EmpIntime = dr["Intime"].ToString();
          string Empoutetime = dr["outtime"].ToString();
          if (EmpCardNo != "" && EmpCardNo != "Card No")
          {
            System.Data.DataTable dtemp = objusercon.GetAllUsersbyEmpCode(EmpCardNo.Substring(3));

            if (Empoutetime != "")
            {
              //check if extra time 
              string ExtraOuttime = "";
              string[] HH = Empoutetime.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
              if (Enumerable.Range(1, 6).Contains(Convert.ToInt32(HH[0])))
              {
                ExtraOuttime = "23:59";
              }
              if (dtemp.Rows.Count > 0)
              {
                string DepartmentID = dtemp.Rows[0]["PrimaryGroupID"].ToString();
                string DesignationID = dtemp.Rows[0]["DesignationID"].ToString();
                string UserID = dtemp.Rows[0]["UserID"].ToString();
                int Updatedby = 637;
                int i = objadmin.UpdateOuttimetimeUser(Convert.ToInt32(DepartmentID), Convert.ToInt32(DesignationID), Convert.ToInt32(UserID), EmpIntime, Updatedby, Reportdate, ExtraOuttime, Empoutetime);

              }
            }
          }
        }

      }
      catch (Exception ex)
      {
          System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

          System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
      }
    }

  }
}
