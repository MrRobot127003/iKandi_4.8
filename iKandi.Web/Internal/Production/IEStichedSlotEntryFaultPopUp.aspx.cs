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
using System.Globalization;
using System.Threading;
using System.Drawing;
using System.IO;
using iKandi.BLL;
using System.Collections.Generic;


namespace iKandi.Web.Internal.Production
{
    public partial class IEStichedSlotEntryFaultPopUp : System.Web.UI.Page
    {
        int DesignationID = ApplicationHelper.LoggedInUser.UserData.DesignationID;
        int Departmentid = ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID;
        OrderController objOrderController = new OrderController();
        public int LinePlanID
        {
            get;
            set;
        }
        public int UnitID
        {
            get;
            set;
        }
        public int OrderDetailId
        {
            get;
            set;
        }
        public static int AltSum
        {
            get;
            set;
        }
        public string Flag
        {
            get;
            set;
        }
        public string ControlID
        {
            get;
            set;
        }
        public string startdate
        {
            get;
            set;
        }
        string flag = "NO";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (null != Request.QueryString["hdnLinePlanningId"])
            {
                LinePlanID = Convert.ToInt32(Request.QueryString["hdnLinePlanningId"].ToString());

            }
            else
            {
                LinePlanID = 0;
            }
            if (null != Request.QueryString["ProductionUnit"])
            {
                UnitID = Convert.ToInt32(Request.QueryString["ProductionUnit"].ToString());

            }
            else
            {
                UnitID = 0;
            }
            if (null != Request.QueryString["OrderDetailId"])
            {
                OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"].ToString());

            }
            else
            {
                OrderDetailId = 0;
            }
            if (null != Request.QueryString["ID"])
            {
                ControlID = Request.QueryString["ID"].ToString();
                hdnControlId.Value = ControlID.ToString();

            }
            if (null != Request.QueryString["startdate"])
            {
                startdate = Request.QueryString["startdate"].ToString();

            }

            if (!IsPostBack)
            {
                getAltSum();
                BindControls();
            }
            //DataSet ds = this.objOrderController.GetStichedSlotAltSumFaultName(OrderDetailId, LinePlanID);
            //DataTable dt1 = ds.Tables[0];
            //DataTable dt2 = ds.Tables[1];

            //ViewState["Faultname"] = dt2;
            //getsum();
        }
        private void BindControls()
        {

            //int DesignationID = ApplicationHelper.LoggedInUser.UserData.DesignationID;
            //int Departmentid = ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID;

            DataSet ds = this.objOrderController.GetStichedSlotAltSumFaultName(OrderDetailId, LinePlanID);
            DataTable dt1 = ds.Tables[0];
            DataTable dt2 = ds.Tables[1];

            ViewState["Faultname"] = dt2;
            if (ViewState["datatable"] != null)
            {
                grdQafault.DataSource = (DataTable)ViewState["datatable"];
                grdQafault.DataBind();

            }
            else
            {
                if (dt1.Rows.Count > 0)
                {
                    grdQafault.DataSource = dt1;
                    grdQafault.DataBind();
                    ViewState["datatable"] = dt1;
                    grdQafault.Visible = true;
                }
                else
                {
                    grdQafault.DataSource = null;
                    grdQafault.DataBind();
                    ViewState["datatable"] = dt1;
                }
            }



        }
        public void getAltSum()
        {
            if (OrderDetailId != 0 && LinePlanID != 0 && UnitID != 0)
            {
                DataTable dt = this.objOrderController.GetAltAllSum(OrderDetailId, UnitID, LinePlanID, startdate);
               
                string g = dt.Rows[0]["AltSum"].ToString() == "0" ? "" : dt.Rows[0]["AltSum"].ToString();
                lblaltPcSum.Text = "Alt Sum " + g;
                AltSum = dt.Rows[0]["AltSum"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[0]["AltSum"].ToString());

                hdnIsDHU.Value = dt.Rows[0]["IsDHU"].ToString() == "" ? "0" : dt.Rows[0]["IsDHU"].ToString();
            }

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            int HasRecord = grdQafault.Rows.Count;
            string IsDHU = hdnIsDHU.Value;
            string sControlId = hdnControlId.Value;
            if (IsDHU == "1")
            {
                flag = "YES";
               
                ClientScript.RegisterStartupScript(GetType(), "startupscript", "javascript:CloseWindowa('" + flag + "', '" + ControlID + "');", true);
            }
            ////if (HasRecord == 0 || HasRecord <= 0)
            ////{
            ////    ScriptManager.RegisterStartupScript(Page, typeof(Page), "CloseWindow", "alert('Fill alt pcs deatils first.');", true);
            ////    grdQafault.Visible = true;
            ////    return;
            ////}

            // }
            int TotatCutQty = 0;
            foreach (GridViewRow row in grdQafault.Rows)
            {
                string txtqty = ((TextBox)row.FindControl("txtQnty")).Text;
                if (txtqty != "")
                {
                    if (txtqty == "0")
                    {
                        ShowAlert("please enter valid qty");
                        return;
                    }

                    TotatCutQty += Convert.ToInt32(((TextBox)row.FindControl("txtQnty")).Text.Trim());
                }

            }
            if (TotatCutQty > AltSum)
            {
                ShowAlert("Entered qty cannot be grather then alt pcs sum qty");
                return;

            }
            //if (TotatCutQty < AltSum)
            //{
            //    ShowAlert("Entered qty cannot be less then alt pcs sum qty");
            //    return;

            //}
            try
            {
              DataTable dtRecord;
              string Flasg = string.Empty;
              DataTable dtnewvalidate = new DataTable();
              dtnewvalidate = (DataTable)(ViewState["Faultname"]);
              int FualtsID = -1, SlotWiseFaultID = 0;
              if (ViewState["datatable"] != null)
              {
                dtRecord = (DataTable)ViewState["datatable"];


                if (dtRecord.Rows.Count > 0)
                {
                  foreach (DataRow row in dtRecord.Rows)
                  {
                    int.TryParse(row["FaultsID"].ToString(), out FualtsID);
                    int.TryParse(row["SlotWiseFaultID"].ToString(), out SlotWiseFaultID);

                    foreach (DataColumn col in dtRecord.Columns)
                    {
                      if (row["FaultName"].ToString() == string.Empty || row["FaultName"] == DBNull.Value)
                      {
                        ShowAlert("fault name could not be  blank");
                        return;
                      }
                      else if (row["FaultsQty"].ToString().Trim() == string.Empty || row["FaultsQty"] == DBNull.Value)
                      {
                        ShowAlert("Fault Qty could not be  blank");
                        return;
                      }

                    }

                    foreach (GridViewRow rows in grdQafault.Rows)
                    {
                      TextBox txtFaultname = (TextBox)rows.FindControl("txtFaultname");
                      TextBox txtQnty = (TextBox)rows.FindControl("txtQnty");
                      foreach (DataRow dr in dtnewvalidate.Rows)
                      {
                        if (dr["TextFields"].ToString().Trim() == txtFaultname.Text.Trim())
                        {
                          Flasg = "HAS";
                        }
                      }
                      if (Flasg == "HAS")
                      {

                      }
                      else
                      {
                        ShowAlert("You can select either fault or unaccounted only" + " (" + txtFaultname.Text + ") " + "not a valid");
                        return;
                      }
                      Flasg = "";

                    }

                  }

                  bool result;
                  ValidateduplicateRecird(out result);
                  if (result == false)
                  {
                    return;
                  }

                  int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                  int results = 0;

                  int IsDeletedOld = this.objOrderController.DeleteAddFualtDetails_IStitchedSlotEntry(LinePlanID, 0, OrderDetailId, "", "DELETE", startdate);

                  if (IsDeletedOld > 0)
                  {
                    getsum();
                    int qnty = 0;
                    string FaulName = string.Empty;
                    // string FlagIsDelete = "NO";
                    foreach (GridViewRow row in grdQafault.Rows)
                    {
                      TextBox txtFaultname = (TextBox)row.FindControl("txtFaultname");
                      TextBox txtQnty = (TextBox)row.FindControl("txtQnty");
                      FaulName = txtFaultname.Text.Trim();
                      qnty = Convert.ToInt32(txtQnty.Text.Trim());
                      int IsDeletedOldHistory = this.objOrderController.DeleteAddFualtDetails_History(LinePlanID, qnty, OrderDetailId, FaulName, "INSERT", startdate, FualtsID, SlotWiseFaultID);
                      results = this.objOrderController.DeleteAddFualtDetails_IStitchedSlotEntry(LinePlanID, qnty, OrderDetailId, FaulName, "NO", startdate);
                    }
                    if (results > 0)
                    {
                      flag = "YES";

                      ViewState["datatable"] = null;
                      BindControls();
                      //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript", "javascript:self.parent.Shadowbox.close();", true);

                      ClientScript.RegisterStartupScript(GetType(), "startupscript", "javascript:CloseWindowa('" + flag + "', '" + ControlID + "');", true);
                    }
                  }
                  // Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript", "javascript:self.parent.Shadowbox.close();", true);
                }
                else
                {
                  flag = "YES";
                  ClientScript.RegisterStartupScript(GetType(), "startupscript", "javascript:CloseWindowa('" + flag + "', '" + ControlID + "');", true);
                }             
              }
              
            }
            catch (Exception ex)
            {
              Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript", "alert(" + ex.Message.ToString()+ ");", true);
            }
        }
        protected void grdQafault_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdQafault.Rows[e.RowIndex];
            HiddenField hdnAutoincretment = (HiddenField)row.FindControl("hdnAutoincretment");
            HiddenField hdnfaultid = (HiddenField)row.FindControl("hdnfaultid");
            DataTable dtnew = new DataTable();
            int rowIdnex = e.RowIndex;
            if (ViewState["datatable"] != null)
            {
                dtnew = (DataTable)(ViewState["datatable"]);
                int SlotWiseFaultID=0,FualtID=0;
                if (hdnAutoincretment.Value != "0")
                {
                  int.TryParse((dtnew.Select("id=" + hdnfaultid.Value)[0]["SlotWiseFaultID"].ToString()), out SlotWiseFaultID);
                  int.TryParse((dtnew.Select("id=" + hdnfaultid.Value)[0]["FaultsID"].ToString()), out FualtID); 
                  dtnew.Rows.Remove(dtnew.Select("id=" + hdnfaultid.Value)[0]);
                }
                else
                {
                  int.TryParse((dtnew.Select("dataTableId=" + hdnfaultid.Value)[0]["SlotWiseFaultID"].ToString()), out SlotWiseFaultID);
                  int.TryParse((dtnew.Select("dataTableId=" + hdnfaultid.Value)[0]["FaultsID"].ToString()), out FualtID); 
                  dtnew.Rows.Remove(dtnew.Select("dataTableId=" + hdnfaultid.Value)[0]);
                }
                ViewState["datatable"] = dtnew;

                int IsDeletedOld = this.objOrderController.DeleteAddFualtDetails_History(LinePlanID, 0, OrderDetailId, "", "DELETE", startdate, FualtID,SlotWiseFaultID);
                if (IsDeletedOld > 0)
                {
                }
            }


            grdQafault.EditIndex = -1;
            BindControls();
            getsum();

        }
        protected void grdQafault_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataTable dtnewvalidate = new DataTable();
            dtnewvalidate = (DataTable)(ViewState["Faultname"]);
            string Result = string.Empty;
            if (e.CommandName == "Insert")
            {
                TextBox txtfoterfaultname = grdQafault.FooterRow.FindControl("txtfoterfaultname") as TextBox;
                TextBox txtfoterqnty = grdQafault.FooterRow.FindControl("txtfoterqnty") as TextBox;
                HiddenField hdnIDfoter = grdQafault.FooterRow.FindControl("hdnAutoincretmentfoter") as HiddenField;
                LinkButton abtnAdd = grdQafault.FooterRow.FindControl("abtnAdd") as LinkButton;
                DataTable dtnew = new DataTable();

                string faultname = string.Empty;
                string qty = string.Empty;

                if (txtfoterfaultname != null && txtfoterfaultname.Text == string.Empty)
                {
                    ShowAlert("Enter fault name");
                    return;
                }
                else
                {
                    faultname = txtfoterfaultname.Text;
                }
                if (txtfoterqnty == null || txtfoterqnty.Text == string.Empty)
                {
                    ShowAlert("Enter qty");
                    return;
                }
                else
                {
                    qty = txtfoterqnty.Text;
                }

                if (ViewState["datatable"] != null)
                {
                    dtnew = (DataTable)(ViewState["datatable"]);
                    int i = 0;
                    for (; i < grdQafault.Rows.Count; i++)
                    {
                        dtnew.Rows[i]["id"] = i + 1;
                        dtnew.Rows[i]["SlotWiseFaultID"] = i + 1;
                        dtnew.Rows[i]["LinePlanningID"] = LinePlanID;
                        dtnew.Rows[i]["OrderDetailID"] = OrderDetailId;
                        dtnew.Rows[i]["FaultsID"] = i + 1;

                        dtnew.Rows[i]["FaultsQty"] = ((TextBox)grdQafault.Rows[i].FindControl("txtQnty")).Text.Trim();
                        dtnew.Rows[i]["FaultsID"] = i + 1;

                        foreach (DataRow dr in dtnewvalidate.Rows)
                        {
                            if (dr["TextFields"].ToString().Trim() == faultname.Trim())
                            {
                                Flag = "HAS";
                            }

                        }
                        if (Flag == "HAS")
                        {
                            dtnew.Rows[i]["FaultName"] = ((TextBox)grdQafault.Rows[i].FindControl("txtFaultname")).Text.Trim();
                        }
                        else
                        {
                            //ShowAlert("You can select either fault or unaccounted only" + " (" + ((TextBox)grdQafault.Rows[i].FindControl("txtFaultname")).Text + ") " + "not a valid");
                            ShowAlert("You can select either fault or unaccounted only " + " (" + faultname + ") " + "not a valid");
                            return;
                        }
                        Flag = "";

                        string sFaultName = ((TextBox)grdQafault.Rows[i].FindControl("txtFaultname")).Text.Trim();
                        if (txtfoterfaultname.Text.Trim() == sFaultName)
                        {
                            ShowAlert("Duplicate fault name found choose another fault name " + "(" + txtfoterfaultname.Text + ")");
                            txtfoterfaultname.Text = "";
                            return;
                        }

                    }


                    //dtnew.Rows[i]["SlotWiseFaultID"] = i + 1;
                    //dtnew.Rows[i]["LinePlanningID"] = LinePlanID;
                    //dtnew.Rows[i]["OrderDetailID"] = OrderDetailId;
                    //dtnew.Rows[i]["FaultsID"] = i + 1;

                    //dtnew.Rows[i]["FaultsQty"] = ((TextBox)grdQafault.Rows[i].FindControl("txtQnty")).Text;
                    //dtnew.Rows[i]["FaultID"] = i + 1;

                    DataRow row = dtnew.NewRow();

                    row["id"] = i + 1; ;
                    row["SlotWiseFaultID"] = i + 1; ;
                    row["LinePlanningID"] = LinePlanID;
                    row["OrderDetailID"] = OrderDetailId;
                    row["FaultsID"] = i + 1;
                    row["FaultsQty"] = txtfoterqnty.Text.Trim();
                    row["FaultsID"] = i + 1;

                    foreach (DataRow dr in dtnewvalidate.Rows)
                    {
                        if (dr["TextFields"].ToString().Trim() == txtfoterfaultname.Text.Trim())
                        {
                            Flag = "HAS";
                        }
                    }
                    if (Flag == "HAS")
                    {
                        row["FaultName"] = txtfoterfaultname.Text.Trim();
                    }
                    else
                    {
                        txtfoterfaultname.Text = "";
                        txtfoterqnty.Text = "";
                        ShowAlert("You can select either fault or unaccounted only" + " (" + faultname + ") " + "not a valid");
                        return;
                    }
                    Flag = "";

                    dtnew.Rows.Add(row);
                    dtnew.AcceptChanges();
                    ViewState["datatable"] = dtnew;

                }
                BindControls();


            }
            if (e.CommandName == "addnew")
            {

                //Table tblGrdviewApplet = (Table)grdQafault.Controls[0];
                //GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];

                Table table = (Table)grdQafault.Controls[0];
                TextBox txtemptyfaultname = (TextBox)table.Rows[0].FindControl("txtemptyfaultname");
                TextBox txtemptyqnty = (TextBox)table.Rows[0].FindControl("txtemptyqnty");

                //TextBox txtemptyfaultname = (TextBox)rows.FindControl("txtemptyfaultname");
                //TextBox txtemptyqnty = (TextBox)rows.FindControl("txtemptyqnty");
                if (txtemptyfaultname.Text.Trim() == "")
                {
                    ShowAlert("Fill fault name first!");
                    return;

                }
                if (txtemptyqnty.Text.Trim() == "")
                {
                    ShowAlert("Fill fault qty first!");
                    return;

                }
                if (Convert.ToInt32(txtemptyqnty.Text.Trim()) > AltSum)
                {
                    ShowAlert("Entered alt qty cannot be grater then actual alt sum");
                    return;
                }

                DataTable dtnew = new DataTable();

                string faultname = string.Empty;
                string qty = string.Empty;

                if (txtemptyfaultname != null && txtemptyfaultname.Text == string.Empty)
                {
                    ShowAlert("Enter fault name");
                    return;
                }
                else
                {
                    faultname = txtemptyfaultname.Text;
                }
                if (txtemptyqnty == null && txtemptyqnty.Text == string.Empty)
                {
                    ShowAlert("Enter qty");
                    return;
                }
                else
                {
                    qty = txtemptyqnty.Text.Trim();
                }


                if (ViewState["datatable"] != null)
                {
                    dtnew = (DataTable)(ViewState["datatable"]);

                    DataRow row = dtnew.NewRow();
                    row["id"] = 1;
                    row["SlotWiseFaultID"] = 0;
                    row["OrderDetailID"] = OrderDetailId;
                    row["LinePlanningID"] = LinePlanID;
                    row["FaultsID"] = 0;
                    row["FaultsQty"] = qty.Trim();
                    row["FaultName"] = faultname.Trim();
                    dtnew.Rows.Add(row);
                    dtnew.AcceptChanges();


                    ViewState["datatable"] = dtnew;
                }
                BindControls();
            }
            getsum();
        }
        protected void grdQafault_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            if (sum != AltSum)
            {
                flag = "NO";
            }
            else
            {
                flag = "YES";
            }

            // ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
            ClientScript.RegisterStartupScript(GetType(), "startupscript", "javascript:CloseWindowa('" + flag + "', '" + ControlID + "');", true);
        }
        public static int sum
        {
            get;
            set;
        }
        public void getsum()
        {
            sum = 0;
            foreach (GridViewRow row in grdQafault.Rows)
            {
                TextBox txtQnty = (TextBox)row.FindControl("txtQnty");
                if (txtQnty.Text != "")
                {
                    if (txtQnty != null)
                    {
                        txtQnty.Text = txtQnty.Text.Trim() == "" ? "0" : txtQnty.Text.Trim();


                        sum = sum + Convert.ToInt32(txtQnty.Text.Trim());



                    }
                }
            }
            if (sum <= AltSum)
            {
                entredsum.Text = sum.ToString().Trim();
            }

            if (sum != AltSum)
            {
                flag = "NO";
            }
        }

        public void ValidateduplicateRecird(out bool IsValid)
        {
            IsValid = true;
            int Count = 0;
            foreach (GridViewRow row in grdQafault.Rows)
            {
                TextBox txtFaultname = (TextBox)row.FindControl("txtFaultname");
                if (txtFaultname != null)
                {
                    Count = 0;
                    if (txtFaultname.Text.Trim() != "")
                    {
                        foreach (GridViewRow rows in grdQafault.Rows)
                        {
                            TextBox txtFaultname_nextrow = (TextBox)rows.FindControl("txtFaultname");
                            if (txtFaultname_nextrow != null)
                            {
                                if (txtFaultname_nextrow.Text.Trim() != "")
                                {
                                    if (txtFaultname.Text.Trim() == txtFaultname_nextrow.Text.Trim())
                                    {
                                        Count += 1;

                                        if (Count > 1)
                                        {
                                            txtFaultname_nextrow.BorderColor = Color.Red;
                                            txtFaultname_nextrow.BorderWidth = 1;
                                            ShowAlert("Duplicate fault name found");
                                            IsValid = false;
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        protected void txtQnty_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
            TextBox txtQntys = (TextBox)gvRow.FindControl("txtQnty");
            HiddenField hdnFualtqty = (HiddenField)gvRow.FindControl("hdnFualtqty");
            int valid;
            if (int.TryParse(txtQntys.Text, out valid))
            {

                int sums = 0;
                foreach (GridViewRow row in grdQafault.Rows)
                {
                    TextBox txtQnty = (TextBox)row.FindControl("txtQnty");
                    if (txtQnty.Text.Trim() != "")
                    {
                        if (txtQnty != null)
                        {
                            txtQnty.Text = txtQnty.Text.Trim() == "" ? "0" : txtQnty.Text.Trim();
                            sums = sums + Convert.ToInt32(txtQnty.Text);
                        }
                    }
                }
                if (sums > AltSum)
                {
                    ShowAlert("Entered Qnty greater than Alt Sum Qnty");
                    txtQntys.Text = hdnFualtqty.Value;
                    txtQntys.BorderColor = Color.Red;
                    txtQntys.Focus();
                }
                else
                {
                    txtQntys.BorderColor = System.Drawing.Color.Empty;
                    entredsum.Text = sum.ToString().Trim();
                }
            }
            else
            {
                ShowAlert("Entered valid Qnty");
                txtQntys.Text = hdnFualtqty.Value;
            }

            if (ViewState["datatable"] != null)
            {
               DataTable dtnew = (DataTable)(ViewState["datatable"]);
                int i = 0;
                for (; i < grdQafault.Rows.Count; i++)
                {
                    dtnew.Rows[i]["id"] = i + 1;
                    dtnew.Rows[i]["SlotWiseFaultID"] = i + 1;
                    dtnew.Rows[i]["LinePlanningID"] = LinePlanID;
                    dtnew.Rows[i]["OrderDetailID"] = OrderDetailId;
                    dtnew.Rows[i]["FaultsID"] = i + 1;

                    dtnew.Rows[i]["FaultsQty"] = ((TextBox)grdQafault.Rows[i].FindControl("txtQnty")).Text.Trim();
                    dtnew.Rows[i]["FaultsID"] = i + 1;
                }

                dtnew.AcceptChanges();
                ViewState["datatable"] = dtnew;
            }
        }
        //protected void txtFaultname_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txt = (TextBox)sender;
        //    GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;

        //    TextBox txtFaultnames = (TextBox)gvRow.FindControl("txtFaultname");
        //    HiddenField hdnfaultname = (HiddenField)gvRow.FindControl("hdnfaultname");

        //    int Count = 0;
        //    foreach (GridViewRow row in grdQafault.Rows)
        //    {
        //        TextBox txtFaultname = (TextBox)row.FindControl("txtFaultname");
        //        if (txtFaultname != null)
        //        {
        //            // Count = 0;
        //            if (txtFaultname.Text.Trim() != "")
        //            {
        //                foreach (GridViewRow rows in grdQafault.Rows)
        //                {
        //                    TextBox txtFaultname_nextrow = (TextBox)rows.FindControl("txtFaultname");
        //                    if (txtFaultname_nextrow != null)
        //                    {
        //                        if (txtFaultname_nextrow.Text != "")
        //                        {
        //                            if (txtFaultname.Text.Trim() == txtFaultname_nextrow.Text.Trim())
        //                            {
        //                                Count += 1;

        //                                if (Count > 1)
        //                                {
        //                                    // txtFaultnames.BorderColor = Color.Red;
        //                                    ShowAlert("Duplicate fault name found choose another fault name " + "(" + txtFaultname.Text + ")");
        //                                    //BindControls();
        //                                    txtFaultnames.Text = hdnfaultname.Value;
        //                                    break;

        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    //if (Count < 1)
        //    //{

        //    //    txtFaultnames.BorderColor = System.Drawing.Color.Empty;
        //    //}

        //    DataTable dtnewvalidates = new DataTable();
        //    dtnewvalidates = (DataTable)(ViewState["Faultname"]);
        //    if (ViewState["datatable"] != null)
        //    {
        //        foreach (DataRow dr in dtnewvalidates.Rows)
        //        {
        //            if (dr["TextFields"].ToString().Trim() == txtFaultnames.Text.Trim())
        //            {
        //                Flag = "HAS";
        //            }
        //        }
        //        if (Flag == "HAS")
        //        {

        //        }
        //        else
        //        {

        //            //ShowAlert("You can select either fault or unaccounted only" + " (" + ((TextBox)grdQafault.Rows[i].FindControl("txtFaultname")).Text + ") " + "not a valid");
        //            ShowAlert("You can select either fault or unaccounted only " + " (" + txtFaultnames + ") " + "not a valid");
        //            txtFaultnames.Text = hdnfaultname.Value;
        //            //return;
        //        }
        //        Flag = "";
        //    }

        //}
        //protected void TxtId_TextChanged(object sender, EventArgs e)
        //{
        //    //GridViewRow currentRow = (GridViewRow)((TextBox)sender).Parent.Parent.Parent.Parent;
        //    //TextBox txtfoterfaultname = (TextBox)currentRow.FindControl("txtfoterfaultname");
        //    // Int32 count = Convert.ToInt32(txt.Text);
        //    //txt.Text = Convert.ToString(count + 10);
        //    TextBox txtfoterfaultname = (TextBox)grdQafault.FooterRow.FindControl("txtfoterfaultname");
        //    int Count = 0;
        //    //foreach (GridViewRow row in grdQafault.Rows)
        //    //{
        //    //TextBox txtFaultname = (TextBox)row.FindControl("txtFaultname");
        //    //if (txtFaultname != null)
        //    //{
        //    Count = 0;
        //    //if (txtFaultname.Text.Trim() != "")
        //    //{
        //    foreach (GridViewRow rows in grdQafault.Rows)
        //    {
        //        TextBox txtFaultname_nextrow = (TextBox)rows.FindControl("txtFaultname");
        //        if (txtFaultname_nextrow != null)
        //        {
        //            if (txtFaultname_nextrow.Text.Trim() != "")
        //            {
        //                if (String.Equals((txtfoterfaultname.Text.Trim()), txtFaultname_nextrow.Text.Trim(), StringComparison.OrdinalIgnoreCase))
        //                {
        //                    Count += 1;

        //                    if (Count >= 1)
        //                    {
        //                        //txtfoterfaultname.BorderColor = Color.Red;
        //                        ShowAlert("Duplicate fault name found choose another fault name " + "(" + txtfoterfaultname.Text + ")");
        //                        //BindControls();
        //                        txtfoterfaultname.Text = "";
        //                        break;

        //                    }
        //                }
        //            }
        //        }
        //    }
        //    DataTable dtnewvalidates = new DataTable();
        //    dtnewvalidates = (DataTable)(ViewState["Faultname"]);
        //    if (ViewState["datatable"] != null)
        //    {
        //        foreach (DataRow dr in dtnewvalidates.Rows)
        //        {
        //            if (dr["TextFields"].ToString().Trim() == txtfoterfaultname.Text.Trim())
        //            {
        //                Flag = "HAS";
        //            }
        //        }
        //        if (Flag == "HAS")
        //        {

        //        }
        //        else
        //        {

        //            //ShowAlert("You can select either fault or unaccounted only" + " (" + ((TextBox)grdQafault.Rows[i].FindControl("txtFaultname")).Text + ") " + "not a valid");
        //            ShowAlert("You can select either fault or unaccounted only " + " (" + txtfoterfaultname.Text + ") " + "not a valid");
        //            txtfoterfaultname.Text = "";
        //            //return;
        //        }
        //        Flag = "";
        //    }
        //    //}
        //    // }
        //    //}

        //}
        //protected void txtfoterqnty_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txtfoterqnty = (TextBox)grdQafault.FooterRow.FindControl("txtfoterqnty");
        //    int valid;
        //    if (int.TryParse(txtfoterqnty.Text, out valid))
        //    {
        //        int sums = 0;
        //        foreach (GridViewRow row in grdQafault.Rows)
        //        {
        //            TextBox txtQnty = (TextBox)row.FindControl("txtQnty");
        //            if (txtQnty.Text.Trim() != "")
        //            {
        //                if (txtQnty != null)
        //                {
        //                    txtQnty.Text = txtQnty.Text.Trim() == "" ? "0" : txtQnty.Text.Trim();
        //                    sums = sums + Convert.ToInt32(txtQnty.Text);
        //                }
        //            }
        //        }
        //        if (sums + Convert.ToInt32(txtfoterqnty.Text.Trim()) > AltSum)
        //        {
        //            ShowAlert("Entered Qnty greater than Alt Sum Qnty");
        //            txtfoterqnty.Text = "";
        //            txtfoterqnty.Focus();
        //        }
        //    }
        //    else
        //    {
        //        ShowAlert("Entered valid Qnty");
        //        txtfoterqnty.Text = "";
        //    }
        //}

        //protected void btnSubmitHide_Click(object sender, EventArgs e)
        //{
        //    SaveData();
        //}
        
    }
}