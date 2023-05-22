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

namespace iKandi.Web
{
    public partial class EmailTemplateForm : BaseUserControl
    {
        iKandi.Common.EmailTemplate objEmailTemplate = null;

        #region Properties

        public int EmailTemplateID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["emailtemplateid"]))
                {
                    return Convert.ToInt32(Request.QueryString["emailtemplateid"]);
                }
                return -1;
            }
        }
        #endregion

        # region EventHandler

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindControls();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            iKandi.Common.EmailTemplate objEmailTemplate = new iKandi.Common.EmailTemplate();
            objEmailTemplate.EmailTemplateID = this.EmailTemplateID;
            objEmailTemplate.Title = txtTitle.Text;
            objEmailTemplate.Subject = txtSubject.Text;
            objEmailTemplate.Description = txtDescription.Text;
            //objEmailTemplate.Content = txtContent.Value;
            objEmailTemplate.EmailTemplateID = this.EmailTemplateID;

            objEmailTemplate.DesignationIDs = string.Empty;
            objEmailTemplate.DepartmentIDs = string.Empty;

            foreach (RepeaterItem item in rptDepartments.Items)
            {
                CheckBox chkDepartment = item.FindControl("chkDepartment") as CheckBox;
                HiddenField hdnDepartmentID = item.FindControl("hdnDepartmentID") as HiddenField;
                Repeater rptDesignations = item.FindControl("rptDesignations") as Repeater;


                if (chkDepartment.Checked)
                {
                    if (objEmailTemplate.DepartmentIDs == string.Empty)
                        objEmailTemplate.DepartmentIDs = hdnDepartmentID.Value;
                    else
                        objEmailTemplate.DepartmentIDs += "," + hdnDepartmentID.Value;
                }

                foreach (RepeaterItem itemDes in rptDesignations.Items)
                {
                    CheckBox chkDesignation = itemDes.FindControl("chkDesignation") as CheckBox;
                    HiddenField hdnDesignationID = itemDes.FindControl("hdnDesignationID") as HiddenField;

                    if (chkDesignation.Checked)
                    {
                        if (objEmailTemplate.DesignationIDs == string.Empty)
                            objEmailTemplate.DesignationIDs = hdnDesignationID.Value;
                        else
                            objEmailTemplate.DesignationIDs += "," + hdnDesignationID.Value;
                    }

                }

            }

            this.AdminControllerInstance.UpdateEmailTemplate(objEmailTemplate);
            pnlEmailTemplateForm.Visible = false;
            pnlMessage.Visible = true;

        }

        # endregion

        #region Private MethodF

        private void BindControls()
        {
            if (EmailTemplateID != -1)
            {
                objEmailTemplate = this.AdminControllerInstance.GetEmailTemplateById(EmailTemplateID);
                txtTitle.Text = objEmailTemplate.Title;
                txtSubject.Text = objEmailTemplate.Subject;
                txtDescription.Text = objEmailTemplate.Description;
                //txtContent.Value = objEmailTemplate.Content;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("DepartmentID");
            dt.Columns.Add("DepartmentName");

            Group[] values = (Group[])Enum.GetValues(typeof(Group));
            IEnumerable<Group> sorted = values.OrderBy(v => v.ToString());

            foreach (Group grp in sorted)
            {
                if (grp == Group.BIPL_TopManagement || grp == Group.iKandi_TopManagement)
                    continue;

                DataRow row = dt.NewRow();
                row[0] = ((int)grp).ToString();
                row[1] = Constants.GetGroupName((int)grp);

                dt.Rows.Add(row);
            }

            rptDepartments.DataSource = dt;
            rptDepartments.DataBind();

        }

        protected void rptDepartments_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;

            DataRowView row = e.Item.DataItem as DataRowView;

            HiddenField hdnDepartmentID = e.Item.FindControl("hdnDepartmentID") as HiddenField;
            int deptID = Convert.ToInt32(hdnDepartmentID.Value);

            CheckBox chkDepartment = e.Item.FindControl("chkDepartment") as CheckBox;

            if (objEmailTemplate != null && ("," + this.objEmailTemplate.DepartmentIDs + ",").IndexOf("," + deptID + ",") > -1)
                chkDepartment.Checked = true;
            else
                chkDepartment.Checked = false;

            Repeater rptDesignations = e.Item.FindControl("rptDesignations") as Repeater;

            List<UserDesignation> desList = this.DesignationControllerInstance.GetDesignationsByDepartment(deptID);

            UserDesignation partner = desList.Find(delegate(UserDesignation UD) { return (UD.DesignationID == (int)Designation.Partner); });

            if (partner != null)
                desList.Remove(partner);

            rptDesignations.DataSource = desList;
            rptDesignations.DataBind();
        }

        protected void rptDesignations_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;

            UserDesignation userDesignation = e.Item.DataItem as UserDesignation;

            HiddenField hdnDesignationID = e.Item.FindControl("hdnDesignationID") as HiddenField;

            int desID = Convert.ToInt32(hdnDesignationID.Value);

            CheckBox chkDesignation = e.Item.FindControl("chkDesignation") as CheckBox;

            if (objEmailTemplate != null && ("," + this.objEmailTemplate.DesignationIDs + ",").IndexOf("," + desID + ",") > -1)
                chkDesignation.Checked = true;
            else
                chkDesignation.Checked = false;
        }

        # endregion

    }
}