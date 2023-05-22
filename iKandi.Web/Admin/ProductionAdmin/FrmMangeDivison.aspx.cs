using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using System.Data;
using System.Web.UI.HtmlControls;
using iKandi.BLL.Production;
using iKandi.BLL;
namespace iKandi.Web.Admin.ProductionAdmin
{
    public partial class FrmMangeDivison : System.Web.UI.Page
    {
        BuyingHouseController objBuyingHouseController = new BuyingHouseController();
        DataTable dtbuying = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrd();
                bindBuyingHouse();

            }
            if (chkIsact_insert.Checked == true)
            {
                IsActCheck(true);
            }
            else if (chkIsact_insert.Checked == false)
            {
                IsActCheck(false);
            }
            
        }
        public void bindBuyingHouse()
        {
            DataTable dt = new DataTable();
            dt = objBuyingHouseController.GetBuingHouseName();
            dtbuying = objBuyingHouseController.GetBuingHouseName();

            chkBuyingHouselist_insert.DataSource = dtbuying;
            chkBuyingHouselist_insert.DataTextField = "CompanyName";
            chkBuyingHouselist_insert.DataValueField = "id";
            chkBuyingHouselist_insert.DataBind();

            

        }
        public void bindBuyingHouse_grd(CheckBoxList grdchklist)
        {
            DataTable dt = new DataTable();
            dt = objBuyingHouseController.GetBuingHouseName();
            dtbuying = objBuyingHouseController.GetBuingHouseName();

            grdchklist.DataSource = dtbuying;
            grdchklist.DataTextField = "CompanyName";
            grdchklist.DataValueField = "id";
            grdchklist.DataBind();



        }
        public void BindGrd()
        {
            DataTable dt = new DataTable();
            dt = objBuyingHouseController.GetDivison_Details(0);
            grdMangeDivison.DataSource = dt;
            grdMangeDivison.DataBind();
 
        }
        ////protected void grdDivsionInsert_RowDataBound(object sender, GridViewRowEventArgs e)
        //{


        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {

        //        //DataRowView dr = e.Row.DataItem as DataRowView;


        //        CheckBoxList chkIsact = (CheckBoxList)e.Row.FindControl("chkBuyingHouselist_insert");

        //        chkIsact.DataSource = dtbuying;
        //        chkIsact.DataTextField = "CompanyName";
        //        chkIsact.DataValueField = "id";
        //        chkIsact.DataBind();

        //    }



        //}

       
        public void Alert(Page page, string message)
        {
            string jsString = "alert('" + message + "');";
            ScriptManager.RegisterStartupScript(page, page.GetType(),
                    "MyApplication",
                    jsString,
                    true);
        }

        protected void btninsert_Click(object sender, ImageClickEventArgs e)
        {
            string RetVal = string.Empty;
            string GroupName = string.Empty;
            string DivisionName = string.Empty;
            string DomainName = string.Empty;
            string buyinghouseId = string.Empty;
            bool IsAct = false;
            bool Is_ValidEntry = true;


            GroupName = txtgroupname_insert.Text.Trim();
            DivisionName = txtDivison_insert.Text.Trim();

            if (txtdomain_insert.Text.Trim().ToUpper().EndsWith(".IN"))
            {
                DomainName = txtdomain_insert.Text.Trim();
            }
            else
            {
                Alert(this, "insert proper domain name & it should be suffix end with (.in)");
                return;
            }

            if (chkIsact_insert.Checked == true)
            {
                IsAct = true;

            }
            else
            {
                IsAct = false;
            }

           

            string buyingid = string.Empty;
            foreach (ListItem item in chkBuyingHouselist_insert.Items)
            {
                if (item.Selected)
                {

                    buyingid = buyingid + item.Value + ",";
                }
            }

            if (IsAct == true)
            {
                if (string.IsNullOrEmpty(buyingid))
                {
                    Is_ValidEntry = false;
                    Alert(this, "Please select at least one Buying House");
                    return;
                }


            }
            else if (IsAct == false)
            {
                Is_ValidEntry = false;
                Alert(this, "Please select (Is Active) as active ");
                return;
            }
            if (!string.IsNullOrEmpty(buyingid) && buyingid != ",")
            {

                buyinghouseId = buyingid.Remove(buyingid.Length - 1);
            }
            if (Is_ValidEntry == true)
            {
                if (!string.IsNullOrEmpty(txtgroupname_insert.Text) && !string.IsNullOrEmpty(txtDivison_insert.Text) && !string.IsNullOrEmpty(txtdomain_insert.Text))
                {
                    RetVal = objBuyingHouseController.InsertUpdateManage_Divison(GroupName, DivisionName, IsAct, buyinghouseId, DomainName, 0);

                }
            }

           
            if (RetVal == "INSERTED")
            {
                RetSetControl();
                IsActCheck(false);
                BindGrd();
                Alert(this, "Record added successfully");
            }
            else if (RetVal == "NOTINSERTED")
            {
                RetSetControl();
                IsActCheck(false);
                Alert(this, "Entered group name already exist");

            }
            else
            {

                RetSetControl();
              
                Alert(this, "Record not save.!");
                return;
            }

        }
        public void RetSetControl()
        {
            txtgroupname_insert.Text = "";
            txtDivison_insert.Text = "";

            chkIsact_insert.Checked=false;
            chkBuyingHouselist_insert.ClearSelection();
            txtdomain_insert.Text = "";

        }
        public void IsActCheck(bool check)
        {
            if (check == false)
            {
                chkBuyingHouselist_insert.ClearSelection();
                chkBuyingHouselist_insert.Enabled = false;

            }
            else if (check == true)
            {
                chkBuyingHouselist_insert.Enabled = true;
 
            } 

 
        }
        protected void chkIsact_insert_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsact_insert.Checked == true)
            {
                IsActCheck(true);
            }
            else if (chkIsact_insert.Checked == false)
            {
                IsActCheck(false);
            }
        }

        protected void chkIsAct_CheckedChanged(object sender, EventArgs e)
        {
            int Index = ((GridViewRow)((sender as Control)).NamingContainer).RowIndex;
            GridViewRow gvr = grdMangeDivison.Rows[Index];

            CheckBoxList ChklistbuyingHouse = (CheckBoxList)gvr.FindControl("ChklistbuyingHouse");


            HiddenField hdnid = (HiddenField)gvr.FindControl("hdnid");

            CheckBox chkIsAct = (CheckBox)gvr.FindControl("chkIsAct");


            if (chkIsAct.Checked == true)
            {


                ChklistbuyingHouse.Enabled = true;

               
            }
            else if (chkIsAct.Checked == false)
            {
                string[] buyingHouseID = getBuyingName(Convert.ToInt32(hdnid.Value)).ToString().Split(',');



                if (!string.IsNullOrEmpty(buyingHouseID.ToString()))
                {
                    ChklistbuyingHouse.ClearSelection();
                    foreach (string buyingNameID in buyingHouseID)
                    {
                        try
                        {
                            ChklistbuyingHouse.Items.FindByValue(buyingNameID).Selected = true;
                        }
                        catch (Exception exp)
                        {
                            System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                            System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), exp.Message, exp.StackTrace));
                        }
                    }

                }

                ChklistbuyingHouse.Enabled = false;

            }
            
        }
        protected void grdMangeDivison_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    Label lblIsact = (Label)e.Row.FindControl("lblIsact");

                    CheckBox chkIsAct = (CheckBox)e.Row.FindControl("chkIsAct");
                    CheckBoxList ChklistbuyingHouse = (CheckBoxList)e.Row.FindControl("ChklistbuyingHouse");
                    Label lblBuyingHouse = (Label)e.Row.FindControl("lblBuyingHouse");
                         

                   

                    ChklistbuyingHouse.ClearSelection();
                    bindBuyingHouse_grd(ChklistbuyingHouse);
                    DataRowView dr = e.Row.DataItem as DataRowView;

                    string[] buyingHouseID= dr["BuyingHouseID"].ToString().Split(',');
                    
                   

                    if (!string.IsNullOrEmpty(buyingHouseID.ToString()))
                    {
                        foreach (string buyingID in buyingHouseID)
                        {
                            try
                            {
                                ChklistbuyingHouse.Items.FindByValue(buyingID).Selected = true;
                            }
                            catch (Exception exp)
                            {
                                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), exp.Message, exp.StackTrace));
                            }
                        }
 
                    }


                    if (dr["IsActive"].ToString() == "True")
                    {
                        chkIsAct.Checked = true;
                    }
                    else
                    {
                        chkIsAct.Checked = false;
                    }











                }
                else
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        DataRowView dr = e.Row.DataItem as DataRowView;
                        Label lblBuyingHouse = (Label)e.Row.FindControl("lblBuyingHouse");
                        HiddenField hdnBuyingHousename = (HiddenField)e.Row.FindControl("hdnBuyingHousename");
                        


                        Label lblIsact = (Label)e.Row.FindControl("lblIsact");

                        if (lblIsact.Text != null)
                        {
                            if (dr["IsActive"].ToString() == "True")
                            {
                                lblIsact.Text = "ACTIVE";
                            }
                            else
                            {
                                lblIsact.Text = "IN ACTIVE";
                            }
                        }


                        DataTable dts = new DataTable();

                        dts = objBuyingHouseController.GetBuingHouseName();
                        string[] id=dr["BuyingHouseID"].ToString().Split(',');

                        DataRow[] dt_buyinghouseName_=null;


                        string BuyingHouseName = string.Empty;
                            foreach (string buyid in id)
                            {
                                if (!string.IsNullOrEmpty(buyid))
                                {
                                    dt_buyinghouseName_ = dts.Select("id=" + buyid);
                                    foreach (DataRow row in dt_buyinghouseName_)
                                    {
                                        BuyingHouseName = BuyingHouseName + row["CompanyName"].ToString() + ",";
                                    }
                                }
                                
                            }


                            if (!string.IsNullOrEmpty(BuyingHouseName))
                            {
                                lblBuyingHouse.Text = BuyingHouseName.Remove(BuyingHouseName.Length - 1);
                                hdnBuyingHousename.Value = BuyingHouseName.Remove(BuyingHouseName.Length - 1); ;
 
                            }

                           
                        
                        

                    }



                }

            }

        }
        protected void grdMangeDivison_RowEditing(object sender, GridViewEditEventArgs e)
        {
            tblinsert.Visible = false;
            btninsert.Enabled = false;
            btninsert.ToolTip = "This Add button will be disable until you cancel editing";
  
            grdMangeDivison.EditIndex = e.NewEditIndex;

            BindGrd();

            GridViewRow Rows = grdMangeDivison.Rows[e.NewEditIndex];


            CheckBoxList ChklistbuyingHouse = (CheckBoxList)Rows.FindControl("ChklistbuyingHouse");


            HiddenField hdnid = (HiddenField)Rows.FindControl("hdnid");

            CheckBox chkIsAct = (CheckBox)Rows.FindControl("chkIsAct");
            if (chkIsAct.Checked == true)
            {
                ChklistbuyingHouse.Enabled = true;
            }
            else if (chkIsAct.Checked == false)
            {
                ChklistbuyingHouse.Enabled = false;
            }
            


        }
        protected void grdMangeDivison_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindGrd();
            grdMangeDivison.PageIndex = e.NewPageIndex;
            grdMangeDivison.DataBind();

        }

        protected void grdMangeDivison_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            tblinsert.Visible = true;//hide insert foter table 
            btninsert.Enabled = true;
            btninsert.ToolTip = "Add new entry";
            grdMangeDivison.EditIndex = -1;

            BindGrd();
        }
        //protected void grdMangeDivison_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    grdMangeDivison.EditIndex = e.NewEditIndex;

        //    BindGrd();

        //    GridViewRow Rows = grdMangeDivison.Rows[e.NewEditIndex];

        //}
        protected void grdMangeDivison_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            
            string buyingHouseID = string.Empty;
            string GroupName = string.Empty;
            string DivisonName = string.Empty;
            string DomainName = string.Empty;
            int RowID = -1;
            bool Is_ValidEntry = true;
            bool isAct_check = false;

            GridViewRow Rows = grdMangeDivison.Rows[e.RowIndex];

            HiddenField hdnid = Rows.FindControl("hdnid") as HiddenField;

           
               
            if (hdnid != null)
            {
                RowID = Convert.ToInt32(hdnid.Value);
            }

            TextBox txtGroupname_edit = Rows.FindControl("txtGroupname_edit") as TextBox;

            TextBox txtdvisionName_edit = Rows.FindControl("txtdvisionName_edit") as TextBox;

            TextBox txtdomain = Rows.FindControl("txtdomain") as TextBox;

            CheckBoxList ChklistbuyingHouse = Rows.FindControl("ChklistbuyingHouse") as CheckBoxList;

            CheckBox chkIsAct = Rows.FindControl("chkIsAct") as CheckBox;

           

            string buyingHouseID_ = string.Empty;

            foreach (ListItem item in ChklistbuyingHouse.Items)
            {
                if (item.Selected)
                {

                    buyingHouseID_ = buyingHouseID_ + item.Value + ",";
                }
            }

            if (!string.IsNullOrEmpty(buyingHouseID_) && buyingHouseID_ != ",")
            {

                buyingHouseID = buyingHouseID_.Remove(buyingHouseID_.Length - 1);
            }

           

            if (txtGroupname_edit != null)
            {
                GroupName = txtGroupname_edit.Text;
            }
            if (txtdvisionName_edit != null)
            {
                DivisonName = txtdvisionName_edit.Text;
            }
            if (txtdomain != null)
            {
                if (txtdomain.Text.Trim().ToUpper().EndsWith(".IN"))
                {
                    DomainName = txtdomain.Text.Trim();
                }
                else
                {
                    Is_ValidEntry = false;
                    Alert(this, "insert proper domain name & it should be suffix end with (.in)");
                    return;
                }
               
            }
            
            if (string.IsNullOrEmpty(buyingHouseID_) || buyingHouseID_ == ",")
            {
                Alert(this, "Select At least one Buying House.!");
                Is_ValidEntry = false;
                
            }

            if (chkIsAct.Checked == false)
            {
                string ids=getBuyingName(Convert.ToInt32(hdnid.Value));
                buyingHouseID = ids;
                //ChklistbuyingHouse.Enabled = false;
                isAct_check = false;
            }
            else
            {

                ChklistbuyingHouse.Enabled = true;
                if (!string.IsNullOrEmpty(buyingHouseID_) && buyingHouseID_ != ",")
                {

                    buyingHouseID = buyingHouseID_.Remove(buyingHouseID_.Length - 1);
                }
                isAct_check = true;
            }

            String RetVal=string.Empty;
            if (Is_ValidEntry == true)
            {
                RetVal = objBuyingHouseController.InsertUpdateManage_Divison(GroupName, DivisonName, isAct_check, buyingHouseID, DomainName, RowID);
            }
          
            
            if (RetVal == "UPDATED")
            {
                
                Alert(this,"Record update successfully");
                grdMangeDivison.EditIndex = -1;
                BindGrd();
                tblinsert.Visible = true;

            }
            else if (RetVal == "NOTUPDATED")
            {
               
                Alert(this, "Record already exists");
                grdMangeDivison.EditIndex = -1;
                BindGrd();
            }
            else
            {
                
                Alert(this, "Record not update check inserted value");
                //grdMangeDivison.EditIndex = -1;
                //BindGrd();

            }



        }
        public string getBuyingName(int id)
        {
            DataTable dt = new DataTable();
            dt = objBuyingHouseController.GetDivison_Details(id);

            string str = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                str = str + Convert.ToString(dr["id"]) +"," ;
            }
            string strActual=str.Remove(str.Length - 1);
            return str = strActual;
        }
        
        
    }
    
                  
}