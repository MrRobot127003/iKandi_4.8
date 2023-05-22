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

using iKandi.Web.Components;
using iKandi.Common;
namespace iKandi.Web
{
    public partial class CategoryForm : BaseUserControl
    {
        #region Properties

        public int CategoryID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["categoryid"]))
                {
                    return Convert.ToInt32(Request.QueryString["categoryid"]);
                }

                return -1;
            }
        }

        #endregion

        #region Event Handlers
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindControls();
                BindWeeks();
                if (CategoryID != -1)
                {
                    PopulateCategoryData();
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            CreateCategory();
            //pnlmain.Visible = true;
        }
        #endregion

        #region Private Methods
        private void BindControls()
        {
            DropdownHelper.BindCategoryTypes(ddlCategoryType as ListControl);
            DropdownHelper.BindCategories(ddlParentCategory as ListControl, Convert.ToInt32(ddlCategoryType.SelectedValue));
            //DropdownHelper.BindCategories(ddlweeks as ListControl, Convert.ToInt32(ddlweeks.SelectedValue));
            ddlParentCategory.Items.Insert(0, new ListItem("None", "-1"));
        }

        private void PopulateCategoryData()
        {
            Category category = this.AdminControllerInstance.GetCategoryById(CategoryID);
            if (category != null)
            {
                tbCategoryName.Text = category.CategoryName;
                tbCategoryCode.Text = category.CategoryCode;
                ddlCategoryType.SelectedValue = category.Type.ToString();
                ddlParentCategory.SelectedValue = category.Parent.CategoryID.ToString();
                ddlweeks.SelectedValue = category.Weeks.ToString();
            }
        }

        private void CreateCategory()
        {
            try
            {

                Category category = new Category();
                if (tbCategoryName.Text == "" )
                {
                    ShowAlert("Category Name is required");
                    return;
                }
                category.CategoryID = CategoryID;
                category.CategoryName = tbCategoryName.Text;
                category.CategoryCode = tbCategoryCode.Text;
                category.Type = Convert.ToInt32(ddlCategoryType.SelectedValue);
                category.Parent = new Category();
                category.Parent.CategoryID = Convert.ToInt32(ddlParentCategory.SelectedValue);
                category.Weeks = Convert.ToInt32(ddlweeks.SelectedValue);
                category = this.AdminControllerInstance.SaveCategory(category);

                if (category.CategoryID > 0)
                {
                  //  pnlForm.Visible = false;
                    //pnlMessage.Visible = true;
                    ShowAlert("Category have been saved into the system successfully!");
                   // pnlmain.Visible = true;
                }
                else
                {
                   // pnlForm.Visible = false;
                    //pnlError.Visible = true;
                    ShowAlert("Category has not been saved due to duplicate code or some error occurs into system while saving data!");
                    
                    //pnlmain.Visible = true;
                    return;
                  
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
        }
        #endregion

        protected void ddlCategoryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlParentCategory.Items.Clear();
            DropdownHelper.BindCategories(ddlParentCategory as ListControl, Convert.ToInt32(ddlCategoryType.SelectedValue));
            ddlParentCategory.Items.Insert(0, new ListItem("None", "-1"));
        }

        protected void BindWeeks()
        {
            int [] arr;
            arr = new int[11];
            arr[0] = 0;
            arr[1] = 1;
            arr[2] = 2;
            arr[3] = 3;
            arr[4] = 4;
            arr[5] = 5;
            arr[6] = 6;
            arr[7] = 7;
            arr[8] = 8;
            arr[9] = 9;
            arr[10] = 10;
            ddlweeks.DataSource = arr;
            ddlweeks.DataBind();
        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
    }
}