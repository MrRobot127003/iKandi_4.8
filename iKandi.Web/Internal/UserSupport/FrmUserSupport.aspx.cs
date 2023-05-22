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
using System.Web.Services;

namespace iKandi.Web.Internal.UserSupport
{
  public partial class FrmUserSupport : System.Web.UI.Page
  {
    CommonController ObjComm = new CommonController();
    OrderController objordercon = new OrderController();
    Button btn = null;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnOB_Click(object sender, EventArgs e)
    {
      btn = (Button)sender;
      UpdateStatus(btn.CommandArgument);
    }
    protected void btnrisk_Click(object sender, EventArgs e)
    {
      btn = (Button)sender;
      UpdateStatus(btn.CommandArgument);
    }
    protected void btnhoppm_Click(object sender, EventArgs e)
    {
      btn = (Button)sender;
      UpdateStatus(btn.CommandArgument);
    }
    protected void btnremovefitcycle_Click(object sender, EventArgs e)
    {
      btn = (Button)sender;
      UpdateStatus(btn.CommandArgument);
    }
    protected void btnpendingdelay_Click(object sender, EventArgs e)
    {
      //btn = (Button)sender;
      //UpdateStatus(btn.CommandArgument);
      //ObjectDataSource1.UpdateParameters["StatusMode_id"].DefaultValue = ddltaskstatus.SelectedValue;
    }
    protected void ObjectDataSource1_OnUpdating(object sender, ObjectDataSourceMethodEventArgs e)
    {
      e.InputParameters["StatusMode_id"] = ddltaskstatus.SelectedValue;
    }
    public void UpdateStatus(string flag)
    {
      try
      {
        int isave = ObjComm.UpdateTaskSupportIssue(flag, txtSerialNo.Text.Trim());
        if (isave > 0)
        {
          ShowAlert("Updated successfully !");
          txtSerialNo.Text = "";
        }
      }
      catch (Exception ec)
      {
        ShowAlert(ec.Message);
      }
    }
    public void ShowAlert(string stringAlertMsg)
    {
      string myStringVariable = string.Empty;
      myStringVariable = stringAlertMsg;
      ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
    }

    protected void btnClost_Click(object sender, EventArgs e)
    {
      try
      {
        string po_number = string.Empty;
        po_number = TextBox1.Text.Trim();
        string status = DropDownList1.SelectedItem.ToString();
        int Cancel_Status = ObjComm.UpdateStatus(po_number, status.ToString(), "Fabric");

        if (Cancel_Status > 0)
        {
            ShowAlert("Updated successfully !");
            txtSerialNo.Text = "";
        }
      }
         catch (Exception ec)
         {
             ShowAlert(ec.Message);
         }

    }

    protected void btnAcc_Close_Click(object sender, EventArgs e)
    {
        try
        {
            string po_number = string.Empty;
            po_number = TextBox1.Text.Trim();
            int status = Convert.ToInt32(DropDownList1.SelectedValue);
            int Cancel_Status = ObjComm.UpdateStatus(po_number, status.ToString(), "Acc");
            if (Cancel_Status > 0)
            {
                ShowAlert("Updated successfully !");
                txtSerialNo.Text = "";
            }
        }
        catch (Exception ec)
        {
            ShowAlert(ec.Message);
        }
    }
    //[WebMethod]
    //public static List<iKandi.Common.QCFormSupport> UpdateSupportIssue(string Flag, int OrderdetailID, string createdon, int QAtype)
    //{

    //  List<iKandi.Common.QCFormSupport> SupportIssue = objordercon.UpdateSupportIssue(Flag, OrderdetailID, createdon, QAtype);
    //  return SupportIssue;
    //} 
  }
}