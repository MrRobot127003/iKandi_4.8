using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

namespace iKandi.Web.UserControls.Lists
{
    public partial class ClientCostingDefaultList_old : BaseUserControl
    {
        #region Fields

        DataSet ds;
        DataTable dtItems;
        DataTable dtClients;
        DataTable dtDepts;
        DataTable dt;
        DataTable data;

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindControls();
        }
        void change()
        {
            //Response.Write("hello");
        }

        protected void gvClientCostingDefaults_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 2; i < e.Row.Cells.Count; i = i + 1)
                {
                    e.Row.Cells[i].CssClass = "column_color text_align_left font_color_blue";
                        HtmlInputCheckBox chkbox = new HtmlInputCheckBox();
                        Label lblhead = new Label();
                        chkbox.Attributes.Add("style", "width:15px !important;text-align:left!important");
                        chkbox.Attributes.Add("title","Click Here To Replicate");
                        lblhead.Attributes.Add("style", "width:40px !important;text-align:right !important");
                        chkbox.ID = "chkbox" + (e.Row.RowIndex).ToString() + (i - 1).ToString();
                        chkbox.Name = "chkbox" + (e.Row.RowIndex).ToString() + (i - 1).ToString();
                        chkbox.Attributes.Add("onClick", "change(this)");
                        lblhead.Text = e.Row.Cells[i].Text.ToString();                        
                        e.Row.Cells[i].Controls.Add(lblhead);
                        e.Row.Cells[i].Controls.Add(chkbox);                 

                }
               
            }         

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
              
                e.Row.Cells[0].CssClass = "column_color text_align_left font_color_blue";
                e.Row.Cells[1].CssClass = "column_color text_align_left font_color_blue";

                DataRowView view = e.Row.DataItem as DataRowView;

                string ClientID = view["Client"].ToString();
                string DepartmentID = view["Department"].ToString();

                DataRow[] clientRow = dtClients.Select("ClientID=" + ClientID);

                if (clientRow.Length > 0)
                    e.Row.Cells[0].Text = clientRow[0]["CompanyName"].ToString();

                DataRow[] deptRow = dtDepts.Select("ID=" + DepartmentID);

                if (deptRow.Length > 0)
                    e.Row.Cells[1].Text = deptRow[0]["DepartmentName"].ToString();

                for (int i = 2; i < e.Row.Cells.Count; i = i + 1)
                {
                    string ItemID = dtItems.Rows[i - 2]["ID"].ToString();
                    string ItemName = dtItems.Rows[i - 2]["Name"].ToString();

                    HtmlInputHidden hidClientID = new HtmlInputHidden();
                    hidClientID.Value = ClientID;
                    hidClientID.ID = "hdnClientID" + (e.Row.RowIndex).ToString() + (i - 1).ToString();
                    hidClientID.Name = "hdnClientID" + (e.Row.RowIndex).ToString() + (i - 1).ToString();
                    e.Row.Cells[i].Controls.Add(hidClientID);

                    HtmlInputHidden hidDeptID = new HtmlInputHidden();
                    hidDeptID.Value = DepartmentID;
                    hidDeptID.ID = "hidDeptID" + (e.Row.RowIndex).ToString() + (i - 1).ToString();
                    hidDeptID.Name = "hidDeptID" + (e.Row.RowIndex).ToString() + (i - 1).ToString();
                    e.Row.Cells[i].Controls.Add(hidDeptID);

                    HtmlInputHidden hidItemID = new HtmlInputHidden();
                    hidItemID.Value = ItemID;
                    hidItemID.ID = "hdnItemID" + (e.Row.RowIndex).ToString() + (i - 1).ToString();
                    hidItemID.Name = "hdnItemID" + (e.Row.RowIndex).ToString() + (i - 1).ToString();
                    e.Row.Cells[i].Controls.Add(hidItemID);

                    DataRow[] dataRows = data.Select("ClientID=" + ClientID.ToString() + " AND DepartmentID=" + DepartmentID.ToString() + " AND ItemID=" + ItemID.ToString());

                    int ID = -1;

                    if (dataRows.Length > 0)
                    {
                        ID = Convert.ToInt32(dataRows[0]["ID"]);
                    }


                    HtmlInputHidden hidID = new HtmlInputHidden();
                    hidID.Value = ID.ToString();
                    hidID.ID = "hdnCCDID" + (e.Row.RowIndex).ToString() + (i - 1).ToString();
                    hidID.Name = "hdnCCDID" + (e.Row.RowIndex).ToString() + (i - 1).ToString();
                    e.Row.Cells[i].Controls.Add(hidID);

                    if (ItemName.ToUpper().IndexOf("ACHIEVE") > -1)
                    {
                        HtmlSelect ddlAchivement = new HtmlSelect();
                        ddlAchivement.ID = "txtValue" + (e.Row.RowIndex).ToString() + (i - 1).ToString();
                        ddlAchivement.Name = "txtValue" + (e.Row.RowIndex).ToString() + (i - 1).ToString();
                        DataTable dt = (DataTable)ViewState["Achievement"];
                        ////ddlAchivement.DataSource = dt;
                        ////ddlAchivement.DataValueField = "AchievementlabelsID";
                        ////ddlAchivement.DataTextField = "Achivementlabels";
                        ////ddlAchivement.DataBind();
                        for (int x = 0; x <= dt.Rows.Count - 1; x++)
                        {
                            ddlAchivement.Items.Add(new ListItem(Convert.ToString(dt.Rows[x]["Achivementlabels"]), Convert.ToString(dt.Rows[x]["AchievementlabelsID"])));
                        }
                        ddlAchivement.Style.Add("width", "50px");
                        ddlAchivement.Value = Convert.ToDouble(view[i]).ToString("N0");
                        ddlAchivement.Attributes.Add("class", "ACHIEVE");
                        e.Row.Cells[i].Controls.Add(ddlAchivement);
                    }

                    if (ItemName.ToUpper().IndexOf("CONVERSION") > -1)
                    {
                        HtmlSelect ddlCurrency = new HtmlSelect();
                        ddlCurrency.ID = "txtValue" + (e.Row.RowIndex).ToString() + (i - 1).ToString();
                        ddlCurrency.Name = "txtValue" + (e.Row.RowIndex).ToString() + (i - 1).ToString();
                        DataTable dt = (DataTable)ViewState["currency"];
                        for (int x = 0; x <= dt.Rows.Count - 1; x++)
                        {                          
                           if (Convert.ToInt32(dt.Rows[x]["Id"]) == 4)
                           {
                               ddlCurrency.Items.Add(new ListItem("€", Convert.ToString(dt.Rows[x]["Id"])));                               
                             
                            }
                           else
                                ddlCurrency.Items.Add(new ListItem(Convert.ToString(dt.Rows[x]["CurrencySymbol"]), Convert.ToString(dt.Rows[x]["Id"])));
                            
                        }                      
                        ddlCurrency.Style.Add("width", "50px");
                        ddlCurrency.Value = Convert.ToDouble(view[i]).ToString("N0");
                        ddlCurrency.Attributes.Add("class", "CONVERSION");              
                        e.Row.Cells[i].Controls.Add(ddlCurrency);
                    }
                    
                    else
                    {
                        HtmlInputText txtValue = new HtmlInputText();                        

                        if (view[i].ToString() == "0")
                            txtValue.Value = string.Empty;
                        else
                            txtValue.Value = view[i].ToString();
                        
                        txtValue.Attributes.Add("onKeyup", "uncheck(this)");
                        txtValue.ID = "txtValue" + (e.Row.RowIndex).ToString() + (i - 1).ToString();
                        txtValue.Name = "txtValue" + (e.Row.RowIndex).ToString() + (i - 1).ToString();               

                        Label lbl = new Label();

                        if (i == 2 || i == 7 || i == 8 || i == 11)
                        {
                            
                            lbl.Text = "%";

                            txtValue.Attributes.Add("style", "width:40px !important;text-align:right !important");
                            if (i == 2 || i == 8)
                            {
                                txtValue.Attributes.Add("class", "numeric-field-with-two-decimal-places commission1" + (i - 1).ToString());
                            }
                            else
                            {
                                decimal txtVal;
                                if (txtValue.Value == "")
                                    txtValue.Value = "0";
                                txtVal = Convert.ToDecimal(txtValue.Value);
                                txtValue.Value = txtVal.ToString("N0");
                                txtValue.Attributes.Add("class", "numeric-field-without-decimal-places commission1" + (i - 1).ToString()); 
                            }
                            e.Row.Cells[i].Controls.Add(txtValue);
                            e.Row.Cells[i].Controls.Add(lbl);
                        }
                        else if (i == 4 || i == 6 || i == 5 || i == 9 || i == 10)
                        {
                            decimal txtVal;
                            if (txtValue.Value == "")
                                txtValue.Value = "0";
                            txtVal = Convert.ToDecimal(txtValue.Value);                         
                            txtValue.Value = txtVal.ToString("N0");
                            //if (i != 12)
                            //{
                                lbl.Text = "Rs.";
                               
                            //}
                            txtValue.Attributes.Add("style", "width:40px !important;text-align:left !important");
                            txtValue.Attributes.Add("class", "numeric-field-without-decimal-places commission1" + (i - 1).ToString());
                            e.Row.Cells[i].Controls.Add(lbl);
                            e.Row.Cells[i].Controls.Add(txtValue);
                        }
                    }

                   

                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            SaveClientCostingDefault();
        }

        #endregion

        #region Private Method

        private void BindControls()
        {
            ds = this.AdminControllerInstance.GetClientCostingDefaults();
           // this.AdminControllerInstance.GetClientCostingDefaults();
            if(!IsPostBack)
                ViewState["currency"]=ds.Tables[5];
            ViewState["Achievement"] = ds.Tables[6];

            dt = new DataTable();

            dtItems = ds.Tables[1];
            dtClients = ds.Tables[0];
            data = ds.Tables[4];
            dtDepts = ds.Tables[3];

            dt.Columns.Add(@"Client");
            dt.Columns.Add(@"Department");

            foreach (DataRow row in dtItems.Rows)
            {
                dt.Columns.Add(row["Name"].ToString());
            }

            foreach (DataRow clientRow in dtClients.Rows)
            {
                int ClientID = Convert.ToInt32(clientRow["ClientID"]);

                DataRow[] depts = dtDepts.Select("ClientID=" + ClientID.ToString());

                foreach (DataRow deptRow in depts)
                {
                    int DepartmentID = Convert.ToInt32(deptRow["ID"]);

                    DataRow newRow = dt.NewRow();

                    // Add the ClientID here and then change it to name in rowdatabound event
                    newRow[@"Client"] = ClientID; //clientRow["CompanyName"].ToString();

                    // Add the DepartmentID here and then change it to name in rowdatabound event
                    newRow[@"Department"] = DepartmentID; //deptRow["DepartmentName"].ToString();

                    foreach (DataRow itemRow in dtItems.Rows)
                    {
                        //int count = 0;
                        int ItemID = Convert.ToInt32(itemRow["ID"]);
                        string itemName = itemRow["Name"].ToString();

                        DataRow[] dataRows = data.Select("ClientID=" + ClientID.ToString() + " AND DepartmentID=" + DepartmentID.ToString() + " AND ItemID=" + ItemID.ToString());

                        //if (newRow[itemName].ToString() == "PROFIT MARGIN")
                        //{
                        //    count++;
                        //}
                        if (dataRows.Length > 0)
                        {
                            newRow[itemName] = dataRows[0]["Value"];
                        }
                        else
                        {
                            // Use defaults        
                            switch (itemName)
                            {
                                case "FINISH": // coffin box
                                    newRow[itemName] = 0;
                                    break;
                                case "LBL/TAGS":
                                    newRow[itemName] = 20;
                                    break;
                                case "TEST":
                                    newRow[itemName] = 5;
                                    break;
                                case "HANGER LOOPS":
                                    newRow[itemName] = 2;
                                    break;
                                case "CONVERSION TO":
                                    newRow[itemName] = 2;
                                    break;
                                case "MARKUP ON UNIT CTC":
                                    newRow[itemName] = 7;
                                    break;
                                case "COMMISION":
                                    newRow[itemName] = 0;
                                    break;
                                case "Hang Over":
                                    newRow[itemName] = 0;
                                    break;
                                case "OVERHEAD COST":
                                    newRow[itemName] = 10;
                                    break;
                                case "PROFIT MARGIN":
                                    newRow[itemName] = 7;
                                    break;
                                case "DESIGN COMM":
                                    newRow[itemName] = 7;
                                    break;
                                case "ACHIEVEMENT":
                                    newRow[itemName] = 3;
                                    break;


                            }

                        }
                    }

                    dt.Rows.Add(newRow);
                }

            }
            dt.Columns["FINISH"].ColumnName = "COFFIN BOX";

            gvClientCostingDefaults.DataSource = dt;
            gvClientCostingDefaults.DataBind();

        }
      
        public void SaveClientCostingDefault()
        {
            iKandi.Common.ClientCostingDefault clientCostingDefault = new iKandi.Common.ClientCostingDefault();

            foreach (GridViewRow row in gvClientCostingDefaults.Rows)
            {
                for (int i = 1; i < row.Cells.Count; i++)
                {

                    for (int j = 0; j < Request.Params.AllKeys.Length; j++)
                    {
                        if (Request.Params.AllKeys[j].EndsWith("hdnItemID" + (row.RowIndex).ToString() + i.ToString()))
                            clientCostingDefault.ItemID = Convert.ToInt32(Request.Params[Request.Params.AllKeys[j]]);
                        if (Request.Params.AllKeys[j].EndsWith("hdnClientID" + (row.RowIndex).ToString() + i.ToString()))
                            clientCostingDefault.ClientID = Convert.ToInt32(Request.Params[Request.Params.AllKeys[j]]);
                        if (Request.Params.AllKeys[j].EndsWith("hidDeptID" + (row.RowIndex).ToString() + i.ToString()))
                            clientCostingDefault.DepartmentID = Convert.ToInt32(Request.Params[Request.Params.AllKeys[j]]);
                        if (Request.Params.AllKeys[j].EndsWith("hdnCCDID" + (row.RowIndex).ToString() + i.ToString()))
                            clientCostingDefault.ID = Convert.ToInt32(Request.Params[Request.Params.AllKeys[j]]);
                        if (Request.Params.AllKeys[j].EndsWith("txtValue" + (row.RowIndex).ToString() + i.ToString()))
                        {
                            string val = Request.Params[Request.Params.AllKeys[j]];

                            if (val == null || val.Trim() == "")
                                val = "0";

                            clientCostingDefault.Value = (float)Convert.ToDecimal(val);
                        }
                    }

                    this.AdminControllerInstance.SaveClientCostingDefault(clientCostingDefault);
                }
            }
            //for (int i = 0; i < gvClientCostingDefaults.Rows.Count; i++)
            //{
            //    clientCostingDefault.ItemID = 11;
            //    string ClientName = gvClientCostingDefaults.Rows[i].Cells[0].Text;
            //    string DeptName = gvClientCostingDefaults.Rows[i].Cells[1].Text;
            //    double Achievement = Convert.ToDouble(gvClientCostingDefaults.Rows[i].Cells[12].Text);


            //    //HiddenField hdnClientId = (HiddenField)gvClientCostingDefaults.Rows[i].Cells[12].FindControl("hdnClientID011");
            //    //if (hdnClientId != null)
            //    //{
            //    //    clientCostingDefault.ClientID = Convert.ToInt32(hdnClientId.Value);
            //    //}
            //    this.AdminControllerInstance.SaveClientCostingDefault_Achievement(ClientName, DeptName, clientCostingDefault.ItemID, Achievement);
            //}

            iKandi.BLL.BLLCache.ClearClientCostingDefaultsCache();

            BindControls();
        }

        #endregion
    }
}