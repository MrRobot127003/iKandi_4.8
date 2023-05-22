using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using iKandi.Common;
using iKandi.Web.Components;
using iKandi.BLL;
using System.Data;


namespace iKandi.Web.Internal.Fabric
{
    public partial class frmFabricDebitNote : System.Web.UI.Page
    {
        iKandi.BLL.OrderProcessController obj_ProcessController = new BLL.OrderProcessController();
        InlinePPM inlinePPM = new InlinePPM();
        FabricController objFabricWorking = new FabricController();
        InlinePPMOrderContract DebitNotesDetails = new InlinePPMOrderContract();
        int sl = 0;
        // InlinePPMOrderContract inlinePPMContract = new InlinePPMOrderContract();
        // InlinePPMDebitNotesDetail DebitNotesDetails = new InlinePPMDebitNotesDetail();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetQueryString();
            if (!IsPostBack)
            {
                this.txtDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
                this.txtreturndate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
                BindDebitNotesSection();
                GetDebitNote();
                // IsertDebitNote();
                
                //this.txtDate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");
                
                //txtPodate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
                DataTable dt = objFabricWorking.Getbipladdress("BIPLAddress3");
                divbipladdress.InnerHtml = dt.Rows[0]["VALUE"].ToString();
            }
        }
        public int DebitNoteIdOut
        {
            get;
            set;
        }
        public int PO_id
        {
            get;
            set;
        }
        public int Debit_Note_ID
        {
            get;
            set;
        }
        public static string untisnames 
        {
            get;
            set;
        }
        private void GetQueryString()
        {
            if (null != Request.QueryString["PO_id"])
            {
                PO_id = Convert.ToInt32(Request.QueryString["PO_id"].ToString());
                //PO_id = 4;
            }
            else
            {
                PO_id = 4;
            }
            if (null != Request.QueryString["Debit_Note_ID"])
            {
                Debit_Note_ID = Convert.ToInt32(Request.QueryString["Debit_Note_ID"].ToString());
                //txtReturnChallan.Attributes.Add("onclick", "CallSupplierChallanForm('" + PO_id + "')");

            }
            else
            {
                Debit_Note_ID = 0;
            }
            hdnDebitnotid.Value = Debit_Note_ID.ToString(); // code added by bharat on 17-july
        }
        private void BindDebitNotesSection()
        {
            //InlinePPMOrderContract inlinePPMContract = new InlinePPMOrderContract();
            InlinePPM inlinePPM = new InlinePPM();
            DataTable dts = obj_ProcessController.Get_DebitChallan_details_id2(PO_id, 3, "Debit Type");
            if (dts.Rows.Count > 0)
            {
                untisnames = dts.Rows[0]["GarmentUnit"].ToString();
                lblSupllierName.Text = dts.Rows[0]["SupplierName"].ToString();
                txtPodate.Text = Convert.ToDateTime(dts.Rows[0]["debitPodate"]).ToString("dd MMM yy (ddd)");
            }
            if (Debit_Note_ID == 0)
            {
                inlinePPM = obj_ProcessController.Get_DebitChallan_details(PO_id, 1, "PO Type");

            }
            else
                inlinePPM = obj_ProcessController.Get_DebitChallan_details(Debit_Note_ID, 1, "Debit Type");

            if (inlinePPM.OrderContracts.Count > 0)
            {
                DebitNotesDetails = inlinePPM.OrderContracts[0];
                txtDebitNoteNumber.Text = DebitNotesDetails.DebitNoteNumber.ToString();
                txtDate.Text = DebitNotesDetails.DebitChallanDate.ToString("dd MMM yy (ddd)");
                txtAgainstBillNo.Text = DebitNotesDetails.DebitAgaistBillNo.ToString();
                txtReturnChallan.Text = DebitNotesDetails.DebitChallanReturnNo.ToString();
                txtreturndate.Text = DebitNotesDetails.FDebitChallanReturnDate.ToString("dd MMM yy (ddd)"); ;
                lblSupllierName.Text = DebitNotesDetails.DebitSupplierName.ToString();
                //lblPodate.Text = DebitNotesDetails.debitPodate.ToString("dd MMM yy (ddd)");
               // txtPodate.Text = DebitNotesDetails.debitPodate.ToString("dd MMM yy (ddd)");

                if (txtAgainstBillNo.Text != "")
                {
                    txtAgainstBillNo.Enabled = false;
                }
            }
            else
            {
                
                if (Debit_Note_ID <= 0)
                {
                    DataTable dt = obj_ProcessController.Get_DebitChallan_details_id(Debit_Note_ID, 1, "Debit Type");
                    untisnames = dts.Rows[0]["GarmentUnit"].ToString();
                    txtDebitNoteNumber.Text = dt.Rows[0]["DebitNoteNumber"].ToString();
                }
            }

        }
        protected void btnDebitNoteSave(object sender, EventArgs e)
        {
            int DebitNoteID = 0;
            InlinePPMOrderContract DebitNotesDetail = new InlinePPMOrderContract();

            //  InlinePPMDebitNotesDetail girdDebitNotesDetails = new InlinePPMDebitNotesDetail();
            DebitNotesDetail.DebitNoteNumber = txtDebitNoteNumber.Text;
            DebitNotesDetail.DebitChallanDate = txtDate.Text != "" ? DateTime.ParseExact(txtDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;
            DebitNotesDetail.DebitAgaistBillNo = txtAgainstBillNo.Text;
            DebitNotesDetail.DebitChallanReturnNo = txtReturnChallan.Text;
            DebitNotesDetail.FDebitChallanReturnDate = txtreturndate.Text != "" ? DateTime.ParseExact(txtreturndate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;
            DebitNotesDetail.PoBillDate = txtPodate.Text != "" ? DateTime.ParseExact(txtPodate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;
            if (Debit_Note_ID <= 0)
                this.obj_ProcessController.Save_FabricDebitNote(DebitNotesDetail, ref DebitNoteID, PO_id);
            else
            {
                this.obj_ProcessController.Update_FabricDebitNote(DebitNotesDetail, Debit_Note_ID);
                DebitNoteID = Debit_Note_ID;
            }
            DataTable dtnew = new DataTable();
            dtnew = (DataTable)(ViewState["datatable"]);
            ViewState["datatable"] = dtnew;
            foreach (GridViewRow row in grdFabricdabitnote.Rows)
            {
                if (row.RowType != DataControlRowType.DataRow) continue;

                Label lblFabricDebitParticur = row.FindControl("lblFabricDebitParticur") as Label;
                Label lblDebitQty = row.FindControl("lblDebitQty") as Label;
                Label lblDebitRate = row.FindControl("lblDebitRate") as Label;
                HiddenField Id = row.FindControl("Id") as HiddenField;
                
                DebitNotesDetails.Particulars = lblFabricDebitParticur.Text;
                DebitNotesDetails.Quantity = Convert.ToInt32(lblDebitQty.Text);
                DebitNotesDetails.Rate = Convert.ToDecimal(lblDebitRate.Text);
                if (Id.Value != "999999")
                {
                   // if (Debit_Note_ID <= 0)
                        this.obj_ProcessController.Save_FabricDebitNote_Particulers(DebitNotesDetails, DebitNoteID);
                    //else
                    //    this.obj_ProcessController.Update_FabricDebitNote_Particulers(DebitNotesDetails, Debit_Note_ID, Convert.ToInt32(Id.Value));
                }
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "CallMyFunction", "callparentpage();", true);
        }

        protected void grdFabricdabitnote_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int sumFooterValue = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblTotalAmount = e.Row.FindControl("lblTotalAmount") as Label;
                HiddenField Id = e.Row.FindControl("Id") as HiddenField;
                Label lblDebitQty = e.Row.FindControl("lblDebitQty") as Label;
                Label lblunits = e.Row.FindControl("lblunits") as Label;

                if (lblunits != null)
                    lblunits.Text =   Enum.GetName(typeof(FabricUnit), Convert.ToInt32(untisnames));
                
                
                if (Id.Value == "999999")
                {
                    e.Row.Cells[0].Text = "Total";
                    e.Row.Cells[0].ColumnSpan = 4;
                    e.Row.Cells[0].Attributes.Add("style", "text-align: right;");
                    e.Row.Cells[1].Visible = false;
                    e.Row.Cells[2].Visible = false;
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[5].Text = "";
                    e.Row.Cells[0].Font.Bold = true;
                    e.Row.Cells[4].Text = sumFooterValue.ToString();
                    if (lblTotalAmount.Text != "")
                    {
                        lblRupees.Text = NumWordsWrapper(Convert.ToDouble(lblTotalAmount.Text));
                    }
                }
                else
                {

                    int a = (e.Row.Cells[4].Text == "" ? 0 : Convert.ToInt32(e.Row.Cells[4].Text.Replace(",","")));
                    sumFooterValue += Convert.ToInt32(a);
                   
                }
            }
            //if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    Label FolblTotalAmount = (Label)e.Row.FindControl("FolblTotalAmount");
            //    HtmlGenericControl indianCurrS = (HtmlGenericControl)e.Row.FindControl("indianCurrS");

            //    if (Convert.ToString(FolblTotalAmount.Text) != "") {
            //        indianCurrS.Attributes.Add("class", "indianCurr");
            //    }
                
            //}

        }
        public void grd()
        {
            int sumFooterValue = 0;
            foreach (GridViewRow grv in grdFabricdabitnote.Rows)
            {
                Label lblTotalAmount = (Label)grv.FindControl("lblTotalAmount");
                HiddenField Id = (HiddenField)grv.FindControl("Id");
                Label lblDebitQty = (Label)grv.FindControl("lblDebitQty");
                Label lblDebitRate = (Label)grv.FindControl("lblDebitRate");

                //lblDebitQty.Text = lblDebitQty.Text + " " + untisnames;
                if (Id.Value == "999999")
                {

                    grv.Cells[4].Text = "<span style='color:green'>₹ </span>" + Convert.ToInt32(sumFooterValue.ToString()).ToString("N0");
                    //lblTotalAmount.Text = sumFooterValue.ToString();
                    lblRupees.Text = NumWordsWrapper(Convert.ToDouble(sumFooterValue.ToString()));
                }
                else
                {
                    int a = (lblTotalAmount.Text == "" ? 0 : Convert.ToInt32(lblTotalAmount.Text.Replace(",","")));
                    sumFooterValue += Convert.ToInt32(a);

                    

                }
            }
        }
        private void GetDebitNote()
        {
            if (ViewState["datatable"] != null)
            {
                DataTable dt = (DataTable)ViewState["datatable"];
                dt.DefaultView.Sort = "DebitNote_Particulers_Id asc";
                dt = dt.DefaultView.ToTable();

                grdFabricdabitnote.DataSource = dt;
                grdFabricdabitnote.DataBind();
            }
            else
            {
                DataTable dt1 = new DataTable();
                if (Debit_Note_ID == 0)
                    dt1 = obj_ProcessController.Get_DebitChallan_detailsTable(PO_id, 2, "PO Type");
                else
                    dt1 = obj_ProcessController.Get_DebitChallan_detailsTable(Debit_Note_ID, 2, "Debit Type");
                grdFabricdabitnote.DataSource = dt1;
                grdFabricdabitnote.DataBind();
                ViewState["datatable"] = dt1;                
            }
            grd();
            hdnrowcount.Value = grdFabricdabitnote.Rows.Count.ToString();
        }
        protected void grdFabricdabitnote_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("EmptyInsert"))
            {
                Table tblGrdviewDebitDetail = (Table)grdFabricdabitnote.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewDebitDetail.Controls[0];
                TextBox FbaricDebitParticular = (TextBox)rows.FindControl("txtFbaricDebitParticular");
                TextBox DebitQty = (TextBox)rows.FindControl("txtDebitQty");
                TextBox DebitRate = (TextBox)rows.FindControl("txtDebitRate");
                DataTable dtnew = new DataTable();
                string FbaricDebitParticular1 = Convert.ToString(FbaricDebitParticular.Text);
                int DebitQty1 = Convert.ToInt32(DebitQty.Text);
                decimal DebitRate1 = Convert.ToDecimal(DebitRate.Text);
                if (FbaricDebitParticular.Text == "")
                {
                    string message = "Please Enter the Fabric Debit Particulars !";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                    return;
                }

                if (Convert.ToString(DebitQty.Text) == "")
                {
                    string message = "Please Enter the Fabric Quantity !";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                    return;
                }
                if (Convert.ToString(DebitRate.Text) == "")
                {
                    string message = "Please Enter the Fabric Debit Rate !";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                    return;
                }
                else
                {
                    if (ViewState["datatable"] != null)
                    {
                        dtnew = (DataTable)(ViewState["datatable"]);
                        for (int i = 0; i < grdFabricdabitnote.Rows.Count; i++)
                        {
                            // dtnew.Rows[i]["Particulers"] = ((TextBox)grdFabricdabitnote.Rows[i].FindControl("lblFabricDebitParticur")).Text;
                            dtnew.Rows[i]["Particulars"] = ((Label)grdFabricdabitnote.Rows[i].FindControl("lblFabricDebitParticur")).Text;
                            dtnew.Rows[i]["Quantity"] = ((Label)grdFabricdabitnote.Rows[i].FindControl("lblDebitQty")).Text;
                            dtnew.Rows[i]["Rate"] = ((Label)grdFabricdabitnote.Rows[i].FindControl("lblDebitRate")).Text;
                            //dtnew.Rows[i]["Quantity"] = ((TextBox)grdFabricdabitnote.Rows[i].FindControl("txtEditQty")).Text;
                            //dtnew.Rows[i]["Rate"] = ((TextBox)grdFabricdabitnote.Rows[i].FindControl("txtEditRate")).Text;
                        }
                        //dtnew.GetDebitNote();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(sl + 1, FbaricDebitParticular1, DebitQty1, DebitRate1, DebitQty1 * DebitRate1);
                        dtnew.DefaultView.Sort = "DebitNote_Particulers_Id ASC";
                        dtnew.AcceptChanges();
                        ViewState["datatable"] = dtnew;
                        GetDebitNote();
                        grd();
                    }

                }

            }
            if (e.CommandName.Equals("Insert"))
            {
                TextBox FoFbaricDebitParticular = grdFabricdabitnote.FooterRow.FindControl("fo_txtFbaricDebitParticular") as TextBox;
                TextBox FoDebitQty = grdFabricdabitnote.FooterRow.FindControl("fo_txtFbaricDebitQty") as TextBox;
                TextBox FoDebitRate = grdFabricdabitnote.FooterRow.FindControl("fo_txtFabricDebitRate") as TextBox;
                HiddenField hdnId = (HiddenField)grdFabricdabitnote.FindControl("Id");
                string FoFbaricDebitParticular1 = Convert.ToString(FoFbaricDebitParticular.Text);

                DataTable dtnew = new DataTable();
                if (FoFbaricDebitParticular.Text == "")
                {
                    string message = "Please Enter the Fabric Debit Particulars !";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                    return;
                }
                if (Convert.ToString(FoDebitQty.Text) == "")
                {
                    string message = "Please Enter the Fabric Quantity !";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                    return;
                }
                if (Convert.ToString(FoDebitRate.Text) == "")
                {
                    string message = "Please Enter the Fabric Debit Rate !";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                    return;
                }

                else
                {
                    int FoDebitQty1 = Convert.ToInt32(FoDebitQty.Text);
                    decimal FoDebitRate1 = Convert.ToDecimal(FoDebitRate.Text);
                    if (ViewState["datatable"] != null)
                    {
                        dtnew = (DataTable)(ViewState["datatable"]);
                        dtnew.DefaultView.Sort = "DebitNote_Particulers_Id ASC";
                        for (int i = 0; i < grdFabricdabitnote.Rows.Count; i++)
                        {
                            foreach (DataRow dr in dtnew.Rows)
                            {
                                if (dr["DebitNote_Particulers_Id"].ToString() == ((HiddenField)grdFabricdabitnote.Rows[i].FindControl("Id")).Value)
                                {
                                    if (dtnew.Rows[i]["DebitNote_Particulers_Id"].ToString() != "999999")
                                    {

                                        dr["Particulers"] = ((Label)grdFabricdabitnote.Rows[i].FindControl("lblFabricDebitParticur")).Text;
                                        dr["Quantity"] = ((Label)grdFabricdabitnote.Rows[i].FindControl("lblDebitQty")).Text;
                                        dr["Rate"] = ((Label)grdFabricdabitnote.Rows[i].FindControl("lblDebitRate")).Text;

                                        break;
                                    }
                                }
                            }
                        }
                        dtnew.AcceptChanges();
                        sl = dtnew.Rows.Count;
                        dtnew.Rows.Add(sl + 1, FoFbaricDebitParticular1, FoDebitQty1, FoDebitRate1, FoDebitQty1 * FoDebitRate1);

                        dtnew.DefaultView.Sort = "DebitNote_Particulers_Id ASC";
                        dtnew.AcceptChanges();
                        ViewState["datatable"] = dtnew;
                        GetDebitNote();
                        grd();
                    }

                }
            }
        }
        protected void grdFabricdabitnote_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdFabricdabitnote.Rows[e.RowIndex];
            int index = Convert.ToInt32(e.RowIndex);
            HiddenField hdnDebitId = (HiddenField)row.FindControl("Id");
            DataTable dtnew = new DataTable();


            if (ViewState["datatable"] != null)
            {
                dtnew = (DataTable)(ViewState["datatable"]);

                for (int i = dtnew.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dtnew.Rows[i];
                    if (dr["DebitNote_Particulers_Id"].ToString() == hdnDebitId.Value)
                        dr.Delete();
                }
                dtnew.AcceptChanges();
                ViewState["datatable"] = dtnew;
                dtnew.DefaultView.Sort = "DebitNote_Particulers_Id ASC";
                grdFabricdabitnote.DataSource = (DataTable)ViewState["datatable"];
                grdFabricdabitnote.DataBind();
                grd();
            }
        }
        //else
        //{
        //  //if (hdnDebitId != null)
        //  //{
        //  //  int i = obj_ProcessController.DeleteDebinoteID(Convert.ToInt32(hdnDebitId.Value));
        //  //  if (i > 0)
        //  //  {
        //  //    string message = "Deleted Successfully !";
        //  //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
        //  //  }
        //  //}
        //  GetDebitNote();
        //  return;

        //}
        //}

        protected void grdFabricdabitnote_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdFabricdabitnote.EditIndex = e.NewEditIndex;
            GetDebitNote();
        }
        protected void grdFabricdabitnote_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = grdFabricdabitnote.Rows[e.RowIndex];
            TextBox txtEditParticulars = Rows.FindControl("txtEditParticulars") as TextBox;
            TextBox txtEditQty = Rows.FindControl("txtEditQty") as TextBox;
            TextBox txtEditRate = Rows.FindControl("txtEditRate") as TextBox;
            HiddenField hdnDebitnote = Rows.FindControl("hdnDebitnote") as HiddenField;
            HiddenField Id = Rows.FindControl("Id") as HiddenField;

            if (txtEditParticulars.Text == "")
            {
                string message = "Please Enter the Fabric Debit Particulars !";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                return;
            }

            if (Convert.ToString(txtEditQty.Text) == "")
            {
                string message = "Please Enter the Fabric Quantity !";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                return;
            }
            if (Convert.ToString(txtEditRate.Text) == "")
            {
                string message = "Please Enter the Fabric Debit Rate !";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                return;
            }
            int UPDebitQty = 0;
            decimal UPDebitRate = 0;
            if (txtEditQty.Text != "")
                UPDebitQty = Convert.ToInt32(txtEditQty.Text);

            if (txtEditRate.Text != "")
                UPDebitRate = Convert.ToDecimal(txtEditRate.Text);

            ////int ID = Convert.ToInt32(Id.Value);
            ////if (Debit_Note_ID == 0)
            ////  Result = obj_ProcessController.UpdateFabricDebitNote_Particulers(PO_id, Convert.ToString(txtEditParticulars.Text), UPDebitQty, UPDebitRate, ID, "PO Type");
            ////else
            ////  Result = obj_ProcessController.UpdateFabricDebitNote_Particulers(PO_id, Convert.ToString(txtEditParticulars.Text), UPDebitQty, UPDebitRate, ID, "Debit Note");

            //if (Result > 0)
            //{
            //    string message = "Your details has been Updated successfully.";
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);

            //}
            //else
            //{
            //    string message = "Duplicate record found!";
            //    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);

            //}
            DataTable dtnew = (DataTable)(ViewState["datatable"]);
            dtnew.DefaultView.Sort = "DebitNote_Particulers_Id ASC";

            foreach (DataRow dr in dtnew.Rows)
            {
                if (dr["DebitNote_Particulers_Id"].ToString() == Id.Value)
                {
                    dr["Particulers"] = txtEditParticulars.Text;
                    dr["Quantity"] = UPDebitQty;
                    dr["Rate"] = UPDebitRate;
                    decimal qty = Convert.ToDecimal(UPDebitQty) * Convert.ToDecimal(UPDebitRate);
                    dr["TotalAmt"]=Math.Round(qty, 0).ToString();
                    break;
                }
            }
            dtnew.AcceptChanges();
            grdFabricdabitnote.EditIndex = -1;
            dtnew.DefaultView.Sort = "DebitNote_Particulers_Id ASC";
            ViewState["datatable"] = dtnew;
            if (ViewState["datatable"] != null)
            {
                GetDebitNote();
            }
        }
        protected void grdFabricdabitnot_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdFabricdabitnote.EditIndex = -1;
            GetDebitNote();
        }
        protected void btn_AddDebitNote(object sender, EventArgs e)
        {

        }
        //added by abhishek==========================================================;;
        static String NumWordsWrapper(double n)
        {

            string words = "";
            double intPart;
            double decPart = 0;
            if (n == 0)
                return "zero";
            try
            {
                string[] splitter = n.ToString().Split('.');
                intPart = double.Parse(splitter[0]);
                decPart = double.Parse(splitter[1]);
            }
            catch
            {
                intPart = n;
            }

            words = NumWords(intPart);

            if (decPart > 0)
            {
                if (words != "")
                    words += " and ";
                int counter = decPart.ToString().Length;
                switch (counter)
                {
                    case 1: words += NumWords(decPart) + " tenths"; break;
                    case 2: words += NumWords(decPart) + " hundredths"; break;
                    case 3: words += NumWords(decPart) + " thousandths"; break;
                    case 4: words += NumWords(decPart) + " ten-thousandths"; break;
                    case 5: words += NumWords(decPart) + " hundred-thousandths"; break;
                    case 6: words += NumWords(decPart) + " millionths"; break;
                    case 7: words += NumWords(decPart) + " ten-millionths"; break;
                }
            }
            return words;
        }

        static String NumWords(double n) //converts double to words
        {
            string[] numbersArr = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tensArr = new string[] { "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninty" };
            string[] suffixesArr = new string[] { "thousand", "million", "billion", "trillion", "quadrillion", "quintillion", "sextillion", "septillion", "octillion", "nonillion", "decillion", "undecillion", "duodecillion", "tredecillion", "Quattuordecillion", "Quindecillion", "Sexdecillion", "Septdecillion", "Octodecillion", "Novemdecillion", "Vigintillion" };
            string words = "";

            bool tens = false;

            if (n < 0)
            {
                words += "negative ";
                n *= -1;
            }

            int power = (suffixesArr.Length + 1) * 3;

            while (power > 3)
            {
                double pow = Math.Pow(10, power);
                if (n >= pow)
                {
                    if (n % pow > 0)
                    {
                        words += NumWords(Math.Floor(n / pow)) + " " + suffixesArr[(power / 3) - 1] + ", ";
                    }
                    else if (n % pow == 0)
                    {
                        words += NumWords(Math.Floor(n / pow)) + " " + suffixesArr[(power / 3) - 1];
                    }
                    n %= pow;
                }
                power -= 3;
            }
            if (n >= 1000)
            {
                if (n % 1000 > 0) words += NumWords(Math.Floor(n / 1000)) + " thousand, ";
                else words += NumWords(Math.Floor(n / 1000)) + " thousand";
                n %= 1000;
            }
            if (0 <= n && n <= 999)
            {
                if ((int)n / 100 > 0)
                {
                    words += NumWords(Math.Floor(n / 100)) + " hundred";
                    n %= 100;
                }
                if ((int)n / 10 > 1)
                {
                    if (words != "")
                        words += " ";
                    words += tensArr[(int)n / 10 - 2];
                    tens = true;
                    n %= 10;
                }

                if (n < 20 && n > 0)
                {
                    if (words != "" && tens == false)
                        words += " ";
                    words += (tens ? "-" + numbersArr[(int)n - 1] : numbersArr[(int)n - 1]);
                    n -= Math.Floor(n);
                }
            }

            return words;

        }

    }
}