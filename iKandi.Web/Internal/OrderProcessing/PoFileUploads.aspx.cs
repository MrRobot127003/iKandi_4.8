using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.IO;
using System.Data;
using iKandi.Common;

namespace iKandi.Web.Internal.OrderProcessing
{
    public partial class PoFileUploads : System.Web.UI.Page
    {
        public int OrderID
        {
            get;
            set;
        }
        OrderController objOrderController = new OrderController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindQueryString();
                BindContractgrd();
            }
        }
        private void BindQueryString()
        {
            try
            {

                if (Request.QueryString["OrderID"] != null)
                {
                    OrderID = Convert.ToInt32(Request.QueryString["OrderID"].ToString());
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));

            }

        }
        public void BindContractgrd()
        {

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            //if (OrderID.ToString() != "" && OrderID != null)
            if (OrderID.ToString() != "")
            {
                //30159
                ds = objOrderController.GetPOUploadContract(OrderID, "GET");
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GrdPoUpload.DataSource = dt;
                    GrdPoUpload.DataBind();

                }
                else
                {
                    GrdPoUpload.DataSource = null;
                    GrdPoUpload.DataBind();
                }

            }
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            String Orderfolder = "~/" + System.Configuration.ConfigurationManager.AppSettings["order.folder"];
            try
            {
                if (ValidateContact() == false)
                {
                    ShowAlert("Select at least one contract");
                    return;
                }
                else
                {
                    foreach (GridViewRow row in GrdPoUpload.Rows)
                    {
                        CheckBox chkRow = (CheckBox)row.FindControl("chkRow");
                        FileUpload Uuploads1 = (FileUpload)row.FindControl("Uuploads1");
                        FileUpload Upload2 = (FileUpload)row.FindControl("Upload2");
                        FileUpload FileUpload3 = (FileUpload)row.FindControl("FileUpload3");
                        HiddenField hdnOrderDetailsID = (HiddenField)row.FindControl("hdnOrderDetailsID");
                        string fileName1 = "";
                        string fileName2 = "";
                        string fileName3 = "";
                        if (chkRow != null)
                        {
                            if (chkRow.Checked)
                            {
                                if (Uuploads1.HasFile || Upload2.HasFile || FileUpload3.HasFile)
                                {
                                    if (Uuploads1.HasFile)
                                    {
                                        Uuploads1.SaveAs(Server.MapPath(Orderfolder) + hdnOrderDetailsID.Value + "_" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + Uuploads1.FileName);
                                        fileName1 = hdnOrderDetailsID.Value + "_" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + Uuploads1.FileName;
                                    }
                                    if (Upload2.HasFile)
                                    {
                                        Upload2.SaveAs(Server.MapPath(Orderfolder) + hdnOrderDetailsID.Value + "_" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + Upload2.FileName);
                                        fileName2 = hdnOrderDetailsID.Value + "_" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + Upload2.FileName;
                                    }
                                    if (FileUpload3.HasFile)
                                    {
                                        FileUpload3.SaveAs(Server.MapPath(Orderfolder) + hdnOrderDetailsID.Value + "_" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + FileUpload3.FileName);
                                        fileName3 = hdnOrderDetailsID.Value + "_" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + FileUpload3.FileName;
                                    }



                                    int res = objOrderController.SaveMOOrderDetails(fileName1, fileName2, fileName3, Convert.ToInt32(hdnOrderDetailsID.Value));
                                    if (fileName1 != "" || fileName2 != "" || fileName3 != "")
                                    {
                                        objOrderController.UpdatePOUploadTask(Convert.ToInt32(hdnOrderDetailsID.Value), iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID);
                                    }
                                    if (res > 0)
                                    {
                                        ShowAlert("PO file updated successfully");
                                    }

                                }
                                else
                                {

                                    ShowAlert("Please select file");
                                    row.BorderColor = System.Drawing.Color.Red;
                                    row.BorderWidth = 1;
                                    return;
                                }
                            }


                        }
                    }
                }
            }

             // ScriptManager.RegisterStartupScript(this, GetType(), "myFunction", "confirm_proceed();", true);

            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }

        }
        public bool ValidateContact()
        {
            bool Result = false;
            int Count = 0;
            foreach (GridViewRow row in GrdPoUpload.Rows)
            {

                CheckBox chkRow = (CheckBox)row.FindControl("chkRow");

                if (chkRow != null)
                {
                    if (chkRow.Checked)
                        Count += 1;
                }
            }
            if (Count > 0)
                Result = true;
            else
                Result = false;
            return Result;
        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
    }
}