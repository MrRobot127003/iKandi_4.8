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

using iKandi.Web.Components;
using iKandi.Common;

namespace iKandi.Web
{
    public partial class Categories : BaseUserControl
    {
        IList<iKandi.Common.Category> categories = new List<iKandi.Common.Category>();



        int TotalRowCount = 0;



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

        



        protected void Page_Load(object sender, EventArgs e)
        {
            tbCategoryCode.Attributes.Add("readonly", "readonly");
           
            string QueryString = string.Empty;
            if (!IsPostBack)
            {
                BindDropDownLists();
                //DataTable dt = new DataTable();
                //gvCategories.DataSource = dt;
                //gvCategories.DataBind();

                if (Request.QueryString["qst"] != null)
                {
                    Category searchCriteria = new Category();
                    searchCriteria.Type = Convert.ToInt32(Request.QueryString["qst"]);
                    searchCriteria.Parent = new Category() { CategoryID = Convert.ToInt32(Request.QueryString["qspc"]) };
                    searchCriteria.CategoryName = Convert.ToString(Request.QueryString["qscn"]);
                    Session["CategorySearchCriteria"] = searchCriteria;
                    gvCategories.PageIndex = Convert.ToInt16(Request.QueryString["qscp"]);
                    gvCategories.DataBind();
                }

                BindControls();
                //BindWeeks();
                if (CategoryID != -1)
                {
                    PopulateCategoryData();
                }
                //BindGridView(true);

                Session["CategorySearchCriteria"] = "";
            }
            if (Request.QueryString["qst"] == null)
            {
                Button btnPrint = (Button)this.FindControl("btnPrint");
                QueryString = "?qst=" + ddlTypes.SelectedValue;
                QueryString += "&qspc=" + ddlParentCategories.SelectedValue;
                QueryString += "&qscn=" + tbCategoryNames.Text;
                QueryString += "&qscp=" + gvCategories.PageIndex;
                btnPrint.Attributes.Add("onclick", "PrintPDFQueryString('','','','" + QueryString + "')");
            }
            // BindGridView(false);
           // addpnl.Visible = true;

            
           
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Category searchCriteria = new Category();
            searchCriteria.Type = Convert.ToInt32(ddlTypes.SelectedValue);
            searchCriteria.Parent = new Category() { CategoryID = Convert.ToInt32(ddlParentCategories.SelectedValue) };
            searchCriteria.CategoryName = tbCategoryNames.Text;
            Session["CategorySearchCriteria"] = searchCriteria;
            //BindGridView(true);
            gvCategories.DataBind();
            
          //  addpnl.Visible = false;
        }

        protected void ddlTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDDLParentCategories();

            if (ddlTypes.SelectedValue == "2")
            {

                tdwastageMeg.Visible = true;
                tdwastagetextbox.Visible = true;
            }
            else
            {

                tdwastageMeg.Visible = false;
                tdwastagetextbox.Visible = false;
            }
        }




        private void BindDropDownLists()
        {
            BindDDLTypes();
            BindDDLParentCategories();
        }

        private void BindDDLParentCategories()
        {
            ddlParentCategories.Items.Clear();
            DropdownHelper.BindCategories(ddlParentCategories as ListControl, Convert.ToInt32(ddlTypes.SelectedValue));
            ddlParentCategories.Items.Insert(0, new ListItem("All", "-1"));
            ddlParentCategories.Items.Insert(1, new ListItem("All Orphens", "-2"));
        }

        private void BindDDLTypes()
        {

            ddlTypes.Items.Clear();
            DropdownHelper.BindCategoryTypes(ddlTypes as ListControl);
            ddlTypes.Items.Insert(0, new ListItem("All", "-1"));
        }

        private void BindGridView(bool isFirstPage)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["PageIndex"]))
            {
                this.HyperLinkPager1.PageIndex = Convert.ToInt32(Request.QueryString["PageIndex"]);
            }
            else
            {
                this.HyperLinkPager1.PageIndex = 0;
            }
            if (isFirstPage)
            {
                this.HyperLinkPager1.PageIndex = 0;
            }

            // prepares the search critiera for searching the categories
            Category searchCriteria = new Category();
            searchCriteria.Type = Convert.ToInt32(ddlTypes.SelectedValue);
            searchCriteria.Parent = new Category() { CategoryID = Convert.ToInt32(ddlParentCategories.SelectedValue) };
            searchCriteria.CategoryName = tbCategoryNames.Text;
            // retreives the categories according to the search criteria
            categories = this.AdminControllerInstance.GetAllCategories(
                HyperLinkPager1.PageIndex, HyperLinkPager1.PageSize, out TotalRowCount, searchCriteria);

            gvCategories.DataSource = categories;
            gvCategories.DataBind();

            this.HyperLinkPager1.TotalRecords = TotalRowCount;
            int TotalPageCount = this.HyperLinkPager1.CalculateTotalPages();
        }



        protected void gvCategories_PageIndexChanged(object sender, EventArgs e)
        {
            string QueryString = string.Empty;
            if (Request.QueryString["qst"] == null)
            {
                Button btnPrint = (Button)this.FindControl("btnPrint");
                QueryString = "?qst=" + ddlTypes.SelectedValue;
                QueryString += "&qspc=" + ddlParentCategories.SelectedValue;
                QueryString += "&qscn=" + tbCategoryNames.Text;
                QueryString += "&qscp=" + gvCategories.PageIndex;
                btnPrint.Attributes.Add("onclick", "PrintPDFQueryString('','','','" + QueryString + "')");
            }
        }

        //another page code===============================================================//
        
        protected void btnadd_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/Admin/categories/CategoryListing.aspx", false);
           // BindControls();
            Response.Redirect("~/Admin/categories/CategoryListing.aspx", true);
            //PopulateCategoryDataEmpty();
            //addpnl.Visible = true;
            //this.CategoryID = -1;
          



        }
        protected void Submit_Click(object sender, EventArgs e)
        {

            CreateCategory();
            //pnlmain.Visible = true;
        }



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
                txtwastage.Text = category.wastage == 0 ? "" : category.wastage.ToString();
                //addpnl.Visible = true;
                if (category.Type.ToString() == "2")
                {

                    tdwastageMeg.Visible = true;
                    tdwastagetextbox.Visible = true;
                }
                else
                {

                    tdwastageMeg.Visible = false;
                    tdwastagetextbox.Visible = false;
                }

                //ddlweeks.SelectedValue = category.Weeks.ToString();

            }
        }
        private void PopulateCategoryDataEmpty()
        {
            //Category category = this.AdminControllerInstance.GetCategoryById(-1);
            //if (category != null)
            //{
            tbCategoryName.Text = "";
            tbCategoryCode.Text = "";
            ddlCategoryType.SelectedValue = "1";
            ddlParentCategory.SelectedValue = "-1";
            txtwastage.Text = "";
               // addpnl.Visible = true;
                //if (category.Type.ToString() == "2")
                //{

                //    tdwastageMeg.Visible = true;
                //    tdwastagetextbox.Visible = true;
                //}
                //else
                //{

                    tdwastageMeg.Visible = false;
                    tdwastagetextbox.Visible = false;
                //}

                //ddlweeks.SelectedValue = category.Weeks.ToString();
           // }
        }
        private void CreateCategory()
        {
            try
            {

                Category category = new Category();
                if (tbCategoryName.Text == "")
                {
                    ShowAlert("Group Name is required");
                    return;
                }


                category.CategoryID = CategoryID;
                category.CategoryName = tbCategoryName.Text;
                category.CategoryCode = tbCategoryCode.Text;
                category.Type = Convert.ToInt32(ddlCategoryType.SelectedValue);
                category.Parent = new Category();
                category.Parent.CategoryID = Convert.ToInt32(ddlParentCategory.SelectedValue);
                //category.Weeks = Convert.ToInt32(ddlweeks.SelectedValue);

                //if (ddlParentCategory.SelectedValue == "-1")
                //{
                //    ShowAlert("select parent category");
                //    return;

                //}
                if (tbCategoryCode.Text == "")
                {
                    ShowAlert("Category code is required");
                    return;
                }
                if (ddlCategoryType.SelectedValue == "2")
                {
                    if (txtwastage.Text == "")
                    {
                        ShowAlert("fill wastage value");
                        return;
                    }
                    else
                    {
                        category.wastage = Convert.ToSingle(txtwastage.Text);
                    }

                }
                else if (ddlCategoryType.SelectedValue == "1")
                {
                    category.wastage = -1;
                }

                category = this.AdminControllerInstance.SaveCategory(category);


                if (category.CategoryID > 0)
                {
                     pnlForm.Visible = false;
                   // pnlMessage.Visible = true;
                    //ShowAlert("Category have been saved into the system successfully!");
                    // pnlmain.Visible = true;
                    //addpnl.Visible = false;
                    pnlMessage.Visible = true;
                    //BindGridView(false);
                    //Response.Redirect("~/Admin/categories/CategoryListing.aspx", true);

                }
                else
                {
                    pnlForm.Visible = false;
                    pnlError.Visible = true;
                    //ShowAlert("Category has not been saved due to dublicate code or some error occurs into system while saving data!");

                    //pnlmain.Visible = true;
                    return;

                }
                
            }
            catch (Exception ex)
            {
                //this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }


        protected void ddlCategoryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlParentCategory.Items.Clear();
            DropdownHelper.BindCategories(ddlParentCategory as ListControl, Convert.ToInt32(ddlCategoryType.SelectedValue));
            ddlParentCategory.Items.Insert(0, new ListItem("None", "-1"));
            if (ddlCategoryType.SelectedValue == "2")
            {
                tdwastageMeg.Visible = true;
                tdwastagetextbox.Visible = true;

            }
            if (ddlCategoryType.SelectedValue == "1")
            {
                tdwastageMeg.Visible = false;
                tdwastagetextbox.Visible = false;

            }

        }

        //protected void BindWeeks()
        //{
        //    int [] arr;
        //    arr = new int[11];
        //    arr[0] = 0;
        //    arr[1] = 1;
        //    arr[2] = 2;
        //    arr[3] = 3;
        //    arr[4] = 4;
        //    arr[5] = 5;
        //    arr[6] = 6;
        //    arr[7] = 7;
        //    arr[8] = 8;
        //    arr[9] = 9;
        //    arr[10] = 10;
        //    ddlweeks.DataSource = arr;
        //    ddlweeks.DataBind();
        //}

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        //added by abhishek on 19/9/2016

        protected void tbCategoryName_TextChanged(object sender, EventArgs e)
        {
            string finalstring = string.Empty;
            if(tbCategoryName.Text.Length>0)
            {
                string[] value = tbCategoryName.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (value.Length == 1)
                {
                    finalstring += value[0].Substring(0, 3);

                }
                else
                {

                    foreach (string s in value)
                    {
                        finalstring += s.Substring(0, 1);

                    }
                }
                tbCategoryCode.Text = finalstring != string.Empty ? finalstring : "";
                tbCategoryCode.Text = tbCategoryCode.Text != "" ? tbCategoryCode.Text.ToUpper() : "";
            }
        }
        

    }
}