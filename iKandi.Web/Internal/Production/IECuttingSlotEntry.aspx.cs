
using System.Collections.ObjectModel;
using System;
using System.Collections;
using System.Collections.Generic;
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
using iKandi.BLL.Production;
using iKandi.Common;
using iKandi.Web.Components;
using System.Text;
using System.IO;
using iKandi.Common.Entities;
using iKandi.BLL.Admin;


namespace iKandi.Web.Internal.Production
{
    public partial class IECuttingSlotEntry : System.Web.UI.Page
    {
        public int ProductionUnit
        {
            get;
            set;
        }
        public int SlotId
        {
            get;
            set;
        }
        public int LineNo
        {
            get;
            set;
        }
        public string StartDate
        {
            get;
            set;
        }
        public string Status
        {
            get;
            set;
        }
        public int OrderDetailId
        {
            get;
            set;
        }
        ProductionController objProductionController = new ProductionController();
        WorkflowController WorkflowControllerInstance = new WorkflowController();
        ClientController objClientController = new ClientController();
        AdminController objadminCon = new AdminController();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.btn_search.UniqueID;
            GetQueryString();
            if (!IsPostBack)
            {
                //GetSlot_LinePlanning_cutting();
                BindClient();
            }
        }


        private void GetQueryString()
        {
            if (null != Request.QueryString["ProductionUnit"])
            {
                ProductionUnit = Convert.ToInt32(Request.QueryString["ProductionUnit"].ToString());
                hdnProductionUnit.Value = ProductionUnit.ToString();
            }
            else
            {
                hdnProductionUnit.Value = "3";
            }
            if (null != Request.QueryString["StartDate"])
            {
                StartDate = Request.QueryString["StartDate"].ToString();
                hdnStartDate.Value = StartDate;
            }
            else
            {
                hdnStartDate.Value = DateTime.Now.Date.ToString("dd/MM/yyyy");
            }

            if (null != Request.QueryString["Status"])
            {
                Status = Request.QueryString["Status"].ToString();
                hdnStatus.Value = Status;
            }
            if (ProductionUnit == 3)
                lblFactory.Text = "Factory C 47";
            else if (ProductionUnit == 11)
                lblFactory.Text = "Factory C 45-46";
            else if (ProductionUnit == 96)
                lblFactory.Text = "Factory D 169";
            else if (ProductionUnit == 120)
                lblFactory.Text = "Factory C 52";            
            else
                lblFactory.Text = "";

        }

        private void BindClient()
        {
            List<iKandi.Common.Client> lstClient = objClientController.get_all_clients_Order(ProductionUnit);
            ddlClient.DataSource = lstClient;
            ddlClient.DataTextField = "CompanyName";
            ddlClient.DataValueField = "ClientId";
            ddlClient.DataBind();
            btnSubmit.Visible = false;
            btnSubmit2.Visible = false;
        }

        //private void GetFactoryName()
        //{
        //    ProductionUnit = Convert.ToInt32(hdnProductionUnit.Value);
        //    string FactoryName = objProductionController.GetFactoryName(ProductionUnit);
        //    lblFactory.Text = "Factory " + FactoryName.ToString();
        //}
        private void GetSlot_LinePlanning_cutting()
        {
            StartDate = hdnStartDate.Value;
            ProductionUnit = Convert.ToInt32(hdnProductionUnit.Value);
            int ClientId = Convert.ToInt32(ddlClient.SelectedValue);
            //if (ClientId > -1)
            //{
            int ClientDeptID = -1;
            if (ddlDepts.SelectedValue == "All")
            {
              ClientDeptID = -1;
            }
            else
            {
              ClientDeptID = Convert.ToInt32(ddlDepts.SelectedValue);
            }

            DataSet ds = objProductionController.GetSlot_LinePlanning_cutting(ProductionUnit, ClientId, ClientDeptID, txtsearch.Text.Trim());
              GetCuttingTargest(ds.Tables[1].Rows[0]["Targets"].ToString());

                gvIECuttingSlot.DataSource = ds.Tables[0];
                gvIECuttingSlot.DataBind();
                if (ds.Tables[0].Rows.Count < 1)
                {
                    btnSubmit.Visible = false;
                    btnSubmit2.Visible = false;
                    btnSubmit.ToolTip = "This button disable because all cut contract Qnty complete";
                }
                else
                {
                    tblHeading.Visible = true;
                    btnSubmit.Visible = true;
                    btnSubmit2.Visible = true;
                    btnSubmit.ToolTip = "";
                }
            //}
            //else
            //{
            //    tblHeading.Visible = false;
            //    btnSubmit.Visible = false;
            //    btnSubmit2.Visible = false;
            //    gvIECuttingSlot.DataSource = null;
            //    gvIECuttingSlot.DataBind();
            //}

        }

        private void GetCuttingTargest(string targets)
        {

            string[] str = targets.Split(',');
            string workercount = str[0].ToString();

            lblworkerCout.Text = str[0].ToString();
            lblworkerCout.ForeColor = System.Drawing.Color.Blue;
            lblworkerCout.Font.Bold = true;

            lblTrget.Text = str[1].ToString();
            lblTrget.ForeColor = System.Drawing.Color.Blue;
            lblTrget.Font.Bold = true;
        }
        protected void gvIECuttingSlot_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //DataSet ds = objProductionController.GetSlot_LinePlanning_cutting(3);

          if (e.Row.RowType == DataControlRowType.Header)
          {
          //  GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
          //  GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

          //  TableHeaderCell headerTableCell = new TableHeaderCell();

          ////  headerTableCell.RowSpan = 2;
          //  headerTableCell.Text = lblFactory.Text;
          //  headerTableCell.ColumnSpan = 3;
          //  headerTableCell.Font.Bold = true;
          //  headerTableCell.Attributes.Add("style", "font-size:16px;");
          //  headerRow1.Controls.Add(headerTableCell);

          //  headerTableCell = new TableHeaderCell();
          //  headerTableCell.ColumnSpan =6;
          //  headerTableCell.Font.Bold = true;
          //  headerTableCell.Text = "Cutting";

          //  headerRow1.Controls.Add(headerTableCell);

          //  headerTableCell = new TableHeaderCell();
          //  headerTableCell.ColumnSpan = 2;
          //  // headerTableCell.ColumnSpan = 2;
          //  headerTableCell.Font.Bold = true;
          //  headerTableCell.Text = "Cut Ready";

          //  headerRow1.Controls.Add(headerTableCell);

          //  headerTableCell = new TableHeaderCell();
          //  headerTableCell.RowSpan = 2;
          //  headerTableCell.Text = "Cutting Complete";
          // // headerTableCell.Font.Bold = true;
          //  headerRow1.Controls.Add(headerTableCell);

          //  headerTableCell = new TableHeaderCell();
          //  headerTableCell.RowSpan = 2;
          //  headerTableCell.Text = "Almost Complete";
          // // headerTableCell.Font.Bold = true;
          //  headerRow1.Controls.Add(headerTableCell);

          //  headerRow1.Controls.Add(headerTableCell);

          //  TableHeaderCell headerCell1;
          //  TableHeaderCell headerCell2;
          //  TableHeaderCell headerCell3;
          //  TableHeaderCell headerCell4;
          //  TableHeaderCell headerCell5;
          //  TableHeaderCell headerCell6;
          //  TableHeaderCell headerCell7;
          //  TableHeaderCell headerCell8;
          //  TableHeaderCell headerCell9;
          //  TableHeaderCell headerCell10;
          //  TableHeaderCell headerCell11;
            
            

          //  headerCell1 = new TableHeaderCell();
          //  headerCell2 = new TableHeaderCell();
          //  headerCell3 = new TableHeaderCell();
          //  headerCell4 = new TableHeaderCell();
          //  headerCell5 = new TableHeaderCell();
          //  headerCell6 = new TableHeaderCell();
          //  headerCell7 = new TableHeaderCell();
          //  headerCell8 = new TableHeaderCell();
          //  headerCell9 = new TableHeaderCell();
          //  headerCell10 = new TableHeaderCell();
          //  headerCell11 = new TableHeaderCell();
           

          //  headerCell1.Text = "Thumbnail";
          //  headerCell2.Text = "Style No. (Client) <br/> Serial No./ Contract No. <br/> Print Color";
          //  headerCell3.Text = "Pcd Date <br/> Ex. Fact. Date <br/> Delivery Mode";

          //  headerCell4.Text = "Order Qty";
          //  headerCell5.Text = "Order Balance";
          //  headerCell6.Text = "Factory Qty";

          //  headerCell7.Text = "Factory Balance";
          //  headerCell8.Text = "Cut Pcs";
          //  headerCell9.Text = "Total Cut Qty";


          //  headerCell10.Text = "Balance";
          //  headerCell11.Text = "Cut Rdy Pcs";
           


          //  headerRow2.Controls.Add(headerCell1);
          //  headerRow2.Controls.Add(headerCell2);
          //  headerRow2.Controls.Add(headerCell3);

          //  headerRow2.Controls.Add(headerCell4);
          //  headerRow2.Controls.Add(headerCell5);
          //  headerRow2.Controls.Add(headerCell6);

          //  headerRow2.Controls.Add(headerCell7);
          //  headerRow2.Controls.Add(headerCell8);
          //  headerRow2.Controls.Add(headerCell9);

          //  headerRow2.Controls.Add(headerCell10);
          //  headerRow2.Controls.Add(headerCell11);

          //  gvIECuttingSlot.Controls[0].Controls.AddAt(0, headerRow1);
          //  gvIECuttingSlot.Controls[0].Controls.AddAt(0, headerRow2);
            
          }




            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblcontractQnty = (Label)e.Row.FindControl("lblcontractQnty");
                TextBox txtTotaltoCut = (TextBox)e.Row.FindControl("txtTotaltoCutQty");

                CheckBox chkMarkAsCut = (CheckBox)e.Row.FindControl("chkMarkAsCut");

                /*this code for check if total to cut pcs equal to Contract Qnty are equal then Mark as complete checkbox will be Freez*/
                if (!string.IsNullOrEmpty(lblcontractQnty.Text) && !string.IsNullOrEmpty(txtTotaltoCut.Text))
                {
                    int TotalQnty = Convert.ToInt32(lblcontractQnty.Text);
                    int Tocutqnty = Convert.ToInt32(txtTotaltoCut.Text);

                    if ((((TotalQnty - Tocutqnty) * 100) / TotalQnty) >= 90)
                    {
                        chkMarkAsCut.Enabled = true;
                    }
                    else
                    {
                        chkMarkAsCut.Enabled = false;
                    }
                }
                CheckBox chkalmostcomplete = (CheckBox)e.Row.FindControl("chkalmostcomplete");
                chkalmostcomplete.Enabled = chkalmostcomplete.Checked == true ? false : true;
                txtTotaltoCut.Attributes.Add("readonly", "readonly");
            }
        }
        private void Save()
        {
            StartDate = hdnStartDate.Value;
            ProductionUnit = Convert.ToInt32(hdnProductionUnit.Value);

            foreach (GridViewRow gvr in gvIECuttingSlot.Rows)
            {
                HiddenField hdnStyleId = (HiddenField)gvr.FindControl("hdnStyleId");
                HiddenField hdnOrderId = (HiddenField)gvr.FindControl("hdnOrderId");
                HiddenField hdnOrderDetailId = (HiddenField)gvr.FindControl("hdnOrderDetailId");
                TextBox txtSlotPass = (TextBox)gvr.FindControl("txtSlotPass");
                TextBox txtTotaltoCut = (TextBox)gvr.FindControl("txtTotaltoCutQty");
                CheckBox chkMarkAsCut = (CheckBox)gvr.FindControl("chkMarkAsCut");
                HiddenField hdnContactQnty = (HiddenField)gvr.FindControl("hdnContactQnty");
                HiddenField hdnOrderQuantity = (HiddenField)gvr.FindControl("hdnOrderQuantity");
                HiddenField hdnOrderTotalCut = (HiddenField)gvr.FindControl("hdnOrderTotalCut");
                HiddenField hdnOrderStitchedQty = (HiddenField)gvr.FindControl("hdnOrderStitchedQty");
                TextBox txtCutReady = (TextBox)gvr.FindControl("txtCutReady");
                CheckBox chkalmostcomplete = (CheckBox)gvr.FindControl("chkalmostcomplete");
                bool Markchk = false; int chkalmost;
                if (chkMarkAsCut != null && chkMarkAsCut.Checked == true)
                {
                    Markchk = true;
                }
                else
                {
                    Markchk = false;
                }
                if (chkalmostcomplete != null && chkalmostcomplete.Checked == true)
                {
                    chkalmost = 1;
                }
                else
                {
                    chkalmost = 0;
                }
                int StyleId = 0, OderID = 0, OrderDetailsID = 0, CutValue = 0, txtLeftContractQnty = 0, UnitId = 0, CutReady = 0;

                StyleId = hdnStyleId == null ? -1 : Convert.ToInt32(hdnStyleId.Value);
                OderID = hdnOrderId == null ? -1 : Convert.ToInt32(hdnOrderId.Value);
                OrderDetailsID = hdnOrderDetailId == null ? -1 : Convert.ToInt32(hdnOrderDetailId.Value);
                txtLeftContractQnty = txtTotaltoCut.Text == "" ? 0 : Convert.ToInt32(txtTotaltoCut.Text);
                CutValue = txtSlotPass.Text == "" ? 0 : Convert.ToInt32(txtSlotPass.Text);
                CutReady = txtCutReady.Text == "" ? 0 : Convert.ToInt32(txtCutReady.Text);
                UnitId = Convert.ToInt32(ProductionUnit);

                int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

                if ((CutValue != 0) || (CutReady != 0) || (Markchk == true) || (chkalmost == 1))
                {
                    int iSave = objProductionController.InsertUpdateCuttingSlotpass(StartDate, OrderDetailsID, OderID, UnitId, txtLeftContractQnty, Markchk, CutValue, CutReady, UserId, chkalmost);

                    // create task
                    if (txtSlotPass.Text != "")
                    {
                        if (hdnOrderTotalCut != null)
                        {
                            int TotalQuantity = Convert.ToInt32(hdnOrderQuantity.Value);

                            int CurrentCut = txtSlotPass.Text == "" ? 0 : Convert.ToInt32(txtSlotPass.Text);

                            int TotalCut = CurrentCut + Convert.ToInt32(hdnOrderTotalCut.Value);

                            if (TotalCut > 0)
                            {
                                WorkflowInstance instance = WorkflowControllerInstance.Create_CloseInlineCut_PostOrder(OderID, OrderDetailsID, TaskMode.INLINE_CUT, UserId);
                            }
                            if ((((TotalCut) * 100) / TotalQuantity) >= 5)
                            {
                                WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(OderID, OrderDetailsID, TaskMode.Cutting, UserId);
                            }

                            if (hdnOrderStitchedQty != null)
                            {
                                int StitchedQty = Convert.ToInt32(hdnOrderStitchedQty.Value);

                                if ((((StitchedQty * 100) / TotalQuantity) >= 5) && (((TotalCut * 100) / TotalQuantity) >= 90))
                                {
                                    WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(OderID, OrderDetailsID, TaskMode.Stitching, UserId);
                                }
                            }
                        }
                    }
                }

                OrderDetailsID = 0;
                OderID = 0;
                UnitId = 0;
                txtLeftContractQnty = 0;
                Markchk = false;
                CutValue = 0;
            } 
        }
        protected void btn_search_Click(object sender, EventArgs e)
        {
          GetSlot_LinePlanning_cutting(); 
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Save();
            GetSlot_LinePlanning_cutting();
            //Response.Redirect(Request.Url.ToString(), false);
        }

        protected void btnSubmit2_Click(object sender, EventArgs e)
        {
            Save();
            GetSlot_LinePlanning_cutting();
            //Response.Redirect(Request.Url.ToString(), false);
        }

        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
          ClientController objClientController = new ClientController(ApplicationHelper.LoggedInUser);
        

          if (ddlClient.SelectedValue != "-1")
          {
            
            List<iKandi.Common.Client> BindDeptListAgainstCliets = objadminCon.BindDeptListAgainstCliets(Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID), Convert.ToInt32(ddlClient.SelectedValue), -1);

            if (BindDeptListAgainstCliets.Count > 0)
            {
              
              ddlDepts.Items.Clear();
              ddlDepts.DataSource = BindDeptListAgainstCliets;
              ddlDepts.DataTextField = "CompanyName";
              ddlDepts.DataValueField = "ClientID";
              ddlDepts.DataBind();
            }
          }


          else
          {
            ddlDepts.Items.Clear();
            ddlDepts.Items.Insert(0, "All");
            ddlDepts.Items.Clear();
            ddlDepts.Items.Insert(0, "All");
          }
            //GetSlot_LinePlanning_cutting();
            //if (ddlClient.SelectedValue != "-1")
            //{
            //    GetSlot_LinePlanning_cutting();
            //}
            //else
            //{

            //}
        }

                
      
    }
}