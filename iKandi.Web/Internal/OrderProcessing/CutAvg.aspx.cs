using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.BLL;
using System.IO;
using System.Web.Services;
using System.Data;
namespace iKandi.Web.Internal.OrderProcessing
{
    public partial class CutAvg : System.Web.UI.Page
    {
        public int orderDetailID
        {
            get;
            set;
        }
        public int countFabric
        {
            get;
            set;
        }

        public int StyleId
        {
            get;
            set;
        }
        public String FabricName
        {
            get;
            set;
        }
        public int UnitId
        {
            get;
            set;
        }
        public double orderAvg
        {
            get;
            set;
        }
        public String print
        {
            get;
            set;
        }
        public int Quantity
        {
            get;
            set;
        }

        public int id
        {
            get;
            set;
        }

        public double FabricAvg
        {
            get;
            set;
        }

        public string Cutavg
        {
            get;
            set;
        }
        public string styleNumber
        {
            get;
            set;
        }
        public string CutAvgComment
        {
            get;
            set;
        }
        public string UserName
        {
            get;
            set;
        }
        public string Imgfile
        {
            get;
            set;
        }
        public string CutWidth
        {
            get;
            set;
        }
        bool result;
        double cutAvg1;
        string imagefile = string.Empty;
        int isall;
        double cutWidth;
        static string user = string.Empty;
        OrderController objOrderController = new OrderController();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            double DirectRepeatAvg = 0.0;
            if (!IsPostBack)
            {
                BindQueryString();
                lblordavg.Text = orderAvg.ToString();

                DirectRepeatAvg = objOrderController.GetDirectRepeatCut_Avg(StyleId, FabricName, id, print, orderDetailID);
                string imagepath = objOrderController.GetSketch(orderDetailID, "", id);
                string[] str = imagepath.Split('#');


                if (str[0].ToString() != "")
                {
                    img.ImageUrl = "~/Uploads/Photo/" + str[0].ToString();
                    img.AlternateText = str[0].ToString();
                    //img.Visible = true;

                    hlkViewMe.NavigateUrl = "~/Uploads/Photo/" + str[0].ToString();
                    hlkViewMe.ImageUrl = "~/Uploads/Photo/" + str[0].ToString();
                    hlkViewMe.Visible = true;
                  
                    
                }
                txtCutAvg.Text = str[1].ToString();
                txtWidth.Text = str[2].ToString();
                
                if (str[1] == "0")
                {
                    if (DirectRepeatAvg != 0.0)
                    {
                        lblDirectRepeat.Text = "This is the Direct Repeat Order,Latest Cut Avg with this style number was: " + DirectRepeatAvg;
                        lblDirectRepeat.Visible = true;
                    }
                }
                BindContractgrd();
            }
            
        }

        private void BindQueryString()
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    id = Convert.ToInt32(Request.QueryString["id"].ToString());
                }

                if (Request.QueryString["ordAvg"] != null)
                {
                    orderAvg = Convert.ToDouble(Request.QueryString["ordAvg"].ToString());
                }

                if (Request.QueryString["styleid"] != null)
                {
                    StyleId = Convert.ToInt32(Request.QueryString["styleid"].ToString());
                }

                if (Request.QueryString["Fabricname"] != null)
                {
                    FabricName = Request.QueryString["Fabricname"].ToString();
                }

                if (Request.QueryString["print"] != null)
                {
                    print = Request.QueryString["print"].ToString();
                }

                if (Request.QueryString["quantity"] != null)
                {
                    Quantity = Convert.ToInt32(Request.QueryString["quantity"].ToString());
                }

                if (Request.QueryString["orderDetailID"] != null)
                {
                    orderDetailID = Convert.ToInt32(Request.QueryString["orderDetailID"].ToString());
                }

                if (Request.QueryString["unitid"] != null)
                {
                    UnitId = Convert.ToInt32(Request.QueryString["unitid"].ToString());
                }

                if (Request.QueryString["fabricavg"] != null)
                {
                    FabricAvg = Convert.ToDouble(Request.QueryString["fabricavg"].ToString());
                }

                if (Request.QueryString["cutavg"] != null)
                {
                    Cutavg = Request.QueryString["cutavg"].ToString();

                }
                if (Request.QueryString["styleNumber"] != null)
                {
                    styleNumber = Request.QueryString["styleNumber"].ToString();

                }
                CutAvgComment = txt_CommentBox.Text.Trim();
                UserName = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            }
            catch (Exception ex)
            {

                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }

        }
        public void BindContractgrd()
        {
           user=  iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            if (orderDetailID.ToString() != "" && StyleId.ToString() != "" && FabricName.ToString() != "")
            {
                ds = objOrderController.GetCutAvgDetails(orderDetailID, StyleId, FabricName,print,id);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GrdCutAvg.DataSource = dt;
                    GrdCutAvg.DataBind();
                    Checkbox();
                }
                else
                {
                    GrdCutAvg.DataSource = null;
                    GrdCutAvg.DataBind();
                }

            }
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            try
            {

                string UnitCaption = "";
                double cutAvg = 0, cutWidth = 0;
                if (UnitId == 1)
                    UnitCaption = "Kg";
                else
                    UnitCaption = "mtrs";
                if (txtCutAvg.Text == "")
                {
                    cutAvg = Convert.ToDouble(0);
                }
                else
                {
                    cutAvg = Convert.ToDouble(txtCutAvg.Text);
                }
                if (txtWidth.Text == "")
                {
                    cutWidth = Convert.ToDouble(0);
                }
                else
                {
                    cutWidth = Convert.ToDouble(txtWidth.Text);
                }

                BindQueryString();
                double Roundval = cutAvg - orderAvg;
                Roundval = Math.Round(Roundval, 2);



                if (file1.HasFile)
                {
                    // file1.Visible = false;
                    string extension = Path.GetExtension(file1.FileName);
                    bool isextension = checkExtension(extension);
                    if (isextension)
                    {

                        string Exten2 = System.IO.Path.GetExtension(file1.FileName);
                        string filename = string.Empty;

                        if (file1.HasFile)
                        {
                            //filename = 1 + "_" + DateTime.Now.ToString("hh.mm.ss.ffffff") + Exten2;

                            //filename = "CutAvg" + "_" + styleNumber + file1.FileName;
                            filename = "CutAvg" + "_" + styleNumber + DateTime.Now.ToString("hh.mm.ss.ffffff") + extension;
                        }


                        if (filename != "")
                        {
                            ViewState["ImageFile"] = filename;
                            file1.SaveAs(Server.MapPath("~/Uploads/Photo/" + filename));
                        }

                    }
                    else
                    {
                        // lblCatgImg.Text = "only Image .jpg|.gif|.jpeg|.png are allowed";
                        lblCatgImg.Text = "Upload Only JPG,JPEG,PNG File";
                        lblCatgImg.ForeColor = System.Drawing.Color.Red;

                        file1.Visible = true;
                        lblCatgImg.Focus();
                        lblCatgImg.Font.Bold = true;
                        return;
                    }
                }


                else if (img.AlternateText != "")
                {
                    //img.Visible = true;
                    hlkViewMe.Visible = true;
                }

                else
                {
                    lblmsg.Text = "Please Upload the File";
                    return;
                }
                if (cutAvg > 0 && cutWidth > 0)
                {
                    if (cutAvg > FabricAvg)
                    {
                        string summary = "Fall:" + Convert.ToInt32((cutAvg - orderAvg) * Quantity) + UnitCaption;
                        lblmsg.Text = "Fabric was ordered @" + FabricAvg + ' ' + "against cut avg" + ' ' + cutAvg + ' ' + "This will create shortfall of " + ' ' + summary + ".Please contact Fabric GM/Director to resolve";
                        lblmsg.Visible = false;
                        // lblmsg.ForeColor = System.Drawing.Color.Red;
                        string script2 = "alert('" + lblmsg.Text + "');";

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "UserSecurity", script2, true);

                        // return;

                    }
                    if (cutAvg < FabricAvg)
                    {
                        string summary = "Fall:" + Convert.ToInt32((cutAvg - orderAvg) * Quantity) + UnitCaption;
                        lblmsg.Text = "Fabric was ordered @" + FabricAvg + ' ' + "against cut avg" + ' ' + cutAvg + ' ' + "This will create excess of " + ' ' + summary + ".Please contact Fabric GM/Director to resolve";
                        lblmsg.Visible = false;
                        string script1 = "alert('" + lblmsg.Text + "');";

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "UserSecurity", script1, true);

                        // return;

                    }

                    ScriptManager.RegisterStartupScript(this, GetType(), "myFunction", "confirm_proceed();", true);
                }



            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }

        }
        public bool ValidateContact()
        {
            bool Result = false;
            int Count = 0;
            foreach (GridViewRow row in GrdCutAvg.Rows)
            {

                CheckBox Chkischeck = (CheckBox)row.FindControl("Chkischeck");

                if (Chkischeck != null)
                {
                    if (Chkischeck.Checked)
                    Count += 1;
                }
            }
            if (Count > 0)
                Result = true;
            else
                Result = false;
            return Result;
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

        public bool saveImg(int orderDetailID, string imagefile)
        {
            bool res = false;
            foreach (GridViewRow row in GrdCutAvg.Rows)
            {
                CheckBox Chkischeck = (CheckBox)row.FindControl("Chkischeck");
                HiddenField hdnOrderDetailsID = (HiddenField)row.FindControl("hdnOrderDetailsID");
                if (Chkischeck != null && hdnOrderDetailsID!=null)
                {
                    if (Chkischeck.Checked == true)
                    {
                        res = objOrderController.UpdateSketch(Convert.ToInt32(hdnOrderDetailsID.Value), imagefile, id);

                    }
                }
            }
            return res;
            
        }
        protected void btnback_Click(object sender, EventArgs e)
        {
            
           
            BindQueryString();
            
            

            isall = Convert.ToInt32(hdnAll.Value);
            cutAvg1 = Convert.ToDouble(txtCutAvg.Text);
            if (txtWidth.Text != "." && txtWidth.Text != "")
            {

                 cutWidth = Convert.ToDouble(txtWidth.Text);


                if (ViewState["ImageFile"] != null)
                {
                    imagefile = ViewState["ImageFile"].ToString();
                    Imgfile = ViewState["ImageFile"].ToString();
                    //result = objOrderController.UpdateSketch(orderDetailID, imagefile, id);
                    result = saveImg(orderDetailID, imagefile);
                }
                else if (img.AlternateText != "")
                {
                    imagefile = img.AlternateText;
                    Imgfile = img.AlternateText;

                    //result = objOrderController.UpdateSketch(orderDetailID, imagefile, id);
                    result = saveImg(orderDetailID, imagefile);
                }
                if (ValidateContact() == false)
                {

                    lblmsg.Text = "Select at least one contract";
                    lblmsg.Visible = false;
                    string script3 = "alert('" + lblmsg.Text + "');";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "UserSecurity", script3, true);

                    return;

                }

                result = SaveDate();
                if (result)
                {
                    //lblmsg.Visible = true;

                    //lblmsg.Text = " Cut Avg and Cut Width has been saved successfully!";
                    //lblmsg.ForeColor = System.Drawing.Color.Green;
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "ShowMsg", "childFunc();", true);
                    //Page.ClientScript.RegisterStartupScript(typeof(Page), "ShowMsg", "childFunc();", true);
                    String x = "<script type='text/javascript'>self.close();</script>";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", x, false);
                }
                
            }
            else
            {
                lblmsg.Text = " Please Correct Input value!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }


        }
       
        public bool SaveDate()//abhishek 28/12/2016
        {
            bool IsSave = true;
            foreach (GridViewRow row in GrdCutAvg.Rows)
            {
                try
                {
                    CheckBox Chkischeck = (CheckBox)row.FindControl("Chkischeck");
                    HiddenField hdnOrderDetailsID = (HiddenField)row.FindControl("hdnOrderDetailsID");
                    if (Chkischeck != null)
                    {
                        if (Chkischeck.Checked)
                        {
                            result = objOrderController.UpdateCutAvg(Convert.ToInt32(hdnOrderDetailsID.Value), cutAvg1, id, StyleId, FabricName, print, isall, imagefile, user, cutWidth, txt_CommentBox.Text.Trim());
                            IsSave = result;
                        }
                    }
                }
                catch(Exception ex)
                {
                    string script3 = "alert('" + ex .ToString()+ "');";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "UserSecurity", script3, true);
                }

            }
            return IsSave;
        }
        public void Checkbox()
        {
            int count = 0;
            
                CheckBox ChkBoxHeader = (CheckBox)GrdCutAvg.HeaderRow.FindControl("chkboxSelectAll");
                if (ChkBoxHeader != null)
                {


                    foreach (GridViewRow row in GrdCutAvg.Rows)
                    {
                        CheckBox Chkischeck = (CheckBox)row.FindControl("Chkischeck");
                        if (Chkischeck != null)
                        {
                            
                                if (Chkischeck.Checked == true)
                                    count += 1;
                            
                        }
                    }
                    if (count > 0)
                        ChkBoxHeader.Checked = true;
                    else
                        ChkBoxHeader.Checked = false;
                }
            
        }
       
        protected void Chkischeck_CheckedChanged(object sender, EventArgs e)
        {
                  
            Checkbox();
        }
        protected void chkboxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            
            CheckBox ChkBoxHeader = (CheckBox)GrdCutAvg.HeaderRow.FindControl("chkboxSelectAll");
            
                if (ChkBoxHeader != null)
                {
                    foreach (GridViewRow row in GrdCutAvg.Rows)
                    {
                        CheckBox Chkischeck = (CheckBox)row.FindControl("Chkischeck");
                        if (Chkischeck != null)
                        {
                            if (ChkBoxHeader.Checked == true)
                            {
                                if (Chkischeck.Enabled)
                                {
                                    Chkischeck.Checked = true;
                                }
                                
                            }
                            else
                            {
                                if (Chkischeck.Enabled)
                                {
                                    Chkischeck.Checked = false;
                                }
                            }
                        }
                    }
                }
            
        }
        protected void GrdCutAvg_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                    HiddenField hdnOrderDetailsID = (HiddenField)e.Row.FindControl("hdnOrderDetailsID");
                    if (hdnOrderDetailsID != null)
                    {
                        if (string.Equals(hdnOrderDetailsID.Value, orderDetailID.ToString()))
                        {
                            //e.Row.BackColor = System.Drawing.Color.Gray;

                            CheckBox Chkischeck = (CheckBox)e.Row.FindControl("Chkischeck");
                            e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#DCDCDC");
                            Chkischeck.Enabled = false;
                        }
                    }
            }

        }


    
    }
}


