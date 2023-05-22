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
using iKandi.Common;
using iKandi.Web.Components;
using iKandi.BLL;

namespace iKandi.Web.UserControls.Forms
{
    public partial class CMTAdmin : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrd();
            }
        }

        public void BindGrd()
        {
            AdminController objAdminController = new AdminController();
            DataSet ds = objAdminController.GetCMTBAL();
            if (ds.Tables[0].Rows.Count > 0)
                txtDefaultValue.Text = ds.Tables[0].Rows[0]["ExQtyDefault"].ToString();
            else
                txtDefaultValue.Text = "0";
            GrdCTM.DataSource = ds.Tables[0];
            GrdCTM.DataBind();
        }

        protected void GrdCTM_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                TextBox txtsamFooter = GrdCTM.FooterRow.FindControl("txtsamFooter") as TextBox;
                TextBox txt499Footer = GrdCTM.FooterRow.FindControl("txt499Footer") as TextBox;
                TextBox txt999Footer = GrdCTM.FooterRow.FindControl("txt999Footer") as TextBox;
                TextBox txt1999Footer = GrdCTM.FooterRow.FindControl("txt1999Footer") as TextBox;
                TextBox txt2999Footer = GrdCTM.FooterRow.FindControl("txt2999Footer") as TextBox;
                TextBox txtabv4999Footer = GrdCTM.FooterRow.FindControl("txtabv4999Footer") as TextBox;
                TextBox txtabv9999Footer = GrdCTM.FooterRow.FindControl("txtabv9999Footer") as TextBox;
                TextBox txtabv14999Footer = GrdCTM.FooterRow.FindControl("txtabv14999Footer") as TextBox;
                TextBox txtabv19999Footer = GrdCTM.FooterRow.FindControl("txtabv19999Footer") as TextBox;
                TextBox txtabvAboveFooter = GrdCTM.FooterRow.FindControl("txtabvAboveFooter") as TextBox;
                AdminController objAdminController = new AdminController();
                objAdminController.UpdateCMTBAL(
                    /*
                    Convert.ToInt32(txtsamFooter.Text.Trim()), 0,
                          Convert.ToInt32(txt499Footer.Text.Trim()),
                          Convert.ToInt32(txt999Footer.Text.Trim()),
                          Convert.ToInt32(txt1999Footer.Text.Trim()),
                          Convert.ToInt32(txt2999Footer.Text.Trim()),
                          Convert.ToInt32(txtabv4999Footer.Text.Trim()),
                          Convert.ToInt32(txtabv9999Footer.Text.Trim()),
                          Convert.ToInt32(txtabv14999Footer.Text.Trim()),
                          Convert.ToInt32(txtabv19999Footer.Text.Trim()),
                          Convert.ToInt32(txtabvAboveFooter.Text.Trim())
                     */
                     TryToParse(txtsamFooter.Text.Trim()),
                          0,
                          TryToParse(txt499Footer.Text.Trim()),
                          TryToParse(txt999Footer.Text.Trim()),
                          TryToParse(txt1999Footer.Text.Trim()),
                          TryToParse(txt2999Footer.Text.Trim()),
                          TryToParse(txtabv4999Footer.Text.Trim()),
                          TryToParse(txtabv9999Footer.Text.Trim()),
                          TryToParse(txtabv14999Footer.Text.Trim()),
                          TryToParse(txtabv19999Footer.Text.Trim()),
                          TryToParse(txtabvAboveFooter.Text.Trim())
                          );

            }
            if (e.CommandName == "addnew")
            {
                Table tbl = (Table)GrdCTM.Controls[0];
                GridViewRow grv = (GridViewRow)tbl.Controls[0];
                TextBox txtsamFooter = (TextBox)grv.FindControl("txtSAMBlank") as TextBox;
                TextBox txt499Footer = (TextBox)grv.FindControl("txt499Blank") as TextBox;
                TextBox txt999Footer = (TextBox)grv.FindControl("txt999Blank") as TextBox;
                TextBox txt1999Footer = (TextBox)grv.FindControl("txt1999Blank") as TextBox;
                TextBox txt2999Footer = (TextBox)grv.FindControl("txt2999Blank") as TextBox;
                TextBox txtabv4999Footer = (TextBox)grv.FindControl("txt4999Blank") as TextBox;
                TextBox txtabv9999Footer = (TextBox)grv.FindControl("txt9999Blank") as TextBox;
                TextBox txtabv14999Footer = (TextBox)grv.FindControl("txt14999Blank") as TextBox;
                TextBox txtabv19999Footer = (TextBox)grv.FindControl("txt19999Blank") as TextBox;
                TextBox txtabvAboveFooter = (TextBox)grv.FindControl("txtAboveBlank") as TextBox;
                AdminController objAdminController = new AdminController();
                objAdminController.UpdateCMTBAL(
                    /*
                          Convert.ToInt32(txtsamFooter.Text.Trim()), 0,
                          Convert.ToInt32(txt499Footer.Text.Trim()),
                          Convert.ToInt32(txt999Footer.Text.Trim()),
                          Convert.ToInt32(txt1999Footer.Text.Trim()),
                          Convert.ToInt32(txt2999Footer.Text.Trim()),
                          Convert.ToInt32(txtabv4999Footer.Text.Trim()),
                          Convert.ToInt32(txtabv9999Footer.Text.Trim()),
                          Convert.ToInt32(txtabv14999Footer.Text.Trim()),
                          Convert.ToInt32(txtabv19999Footer.Text.Trim()),
                          Convert.ToInt32(txtabvAboveFooter.Text.Trim())
*/
                          TryToParse(txtsamFooter.Text.Trim()),
                          0,
                          TryToParse(txt499Footer.Text.Trim()),                        
                          TryToParse(txt999Footer.Text.Trim()),
                          TryToParse(txt1999Footer.Text.Trim()),
                          TryToParse(txt2999Footer.Text.Trim()),
                          TryToParse(txtabv4999Footer.Text.Trim()),
                          TryToParse(txtabv9999Footer.Text.Trim()),
                          TryToParse(txtabv14999Footer.Text.Trim()),
                          TryToParse(txtabv19999Footer.Text.Trim()),
                          TryToParse(txtabvAboveFooter.Text.Trim())

                          );
            }
            showMsg("Data save successfully!");
            BindGrd();
        }


        protected int  TryToParse(string value)
        {
            int number;
            bool result = Int32.TryParse(value, out number);
            return number;
            /*
            if (result)
            {
                Console.WriteLine("Converted '{0}' to {1}.", value, number);
            }
            else
            {
                if (value == null) value = "";
                Console.WriteLine("Attempted conversion of '{0}' failed.", value);
            }
             */
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AdminController objAdminController = new AdminController();
            foreach (GridViewRow row in GrdCTM.Rows)
            {


                TextBox txtsamFooter = (TextBox)row.FindControl("txtsam") as TextBox;
                HiddenField hdnId = (HiddenField)row.FindControl("ID") as HiddenField;
                TextBox txt499Footer = (TextBox)row.FindControl("txt499") as TextBox;
                TextBox txt999Footer = (TextBox)row.FindControl("txt999") as TextBox;
                TextBox txt1999Footer = (TextBox)row.FindControl("txt1999") as TextBox;
                TextBox txt2999Footer = (TextBox)row.FindControl("txt2999") as TextBox;
                TextBox txtabv4999Footer = (TextBox)row.FindControl("txtabv4999") as TextBox;
                TextBox txtabv9999Footer = (TextBox)row.FindControl("txtabv9999") as TextBox;
                TextBox txtabv14999Footer = (TextBox)row.FindControl("txtabv14999") as TextBox;
                TextBox txtabv19999Footer = (TextBox)row.FindControl("txtabv19999") as TextBox;
                TextBox txtabvAboveFooter = (TextBox)row.FindControl("txtabvAbove") as TextBox;

                objAdminController.UpdateCMTBAL(TryToParse(txtsamFooter.Text.Trim()),
                          // Convert.ToInt32(txtsamFooter.Text.Trim()),
                          TryToParse(hdnId.Value),
                          TryToParse(txt499Footer.Text.Trim()),
                         // Convert.ToInt32(txt499Footer.Text.Trim()),
                          TryToParse(txt999Footer.Text.Trim()),
                         TryToParse(txt1999Footer.Text.Trim()),
                         TryToParse(txt2999Footer.Text.Trim()),
                         TryToParse(txtabv4999Footer.Text.Trim()),
                         TryToParse(txtabv9999Footer.Text.Trim()),
                         TryToParse(txtabv14999Footer.Text.Trim()),
                         TryToParse(txtabv19999Footer.Text.Trim()),
                          TryToParse(txtabvAboveFooter.Text.Trim())
                          );
            }
            objAdminController.InsertUpdateCMTDefault(Convert.ToInt32(txtDefaultValue.Text.Trim()));

            BindGrd();
            showMsg("Data update successfully!");
        }

        public void showMsg(string Msg)
        {
            string script = string.Empty;
            script = "ShowHideMessageBox(true,' " + Msg + " ');";
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), script, true);
            return;
        }

        protected void GrdCTM_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int intKeyValue = int.Parse(GrdCTM.DataKeys[e.RowIndex].Value.ToString());
            AdminController objAdminController = new AdminController();
            objAdminController.DeleteCMTBAL(intKeyValue);
            BindGrd();
            showMsg("Data delete successfully!");
        }


    }
}