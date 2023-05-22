using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.Common;
using iKandi.BLL;
using System.IO;
using System.Web.Services;
using iKandi.Web.Components;
using System.Web.UI.HtmlControls;
using iKandi.Common;
using iKandi.Web.Components;
using iKandi.BLL;


namespace iKandi.Web.UserControls.Lists
{
  
    public partial class PairingCosting : BaseUserControl
    {
       // int sl = 0;
        public static int StyleID
        {
            get;
            set;
        }
        public static int costingid
        {
            get;
            set;


        }
        OrderController objOrderController = new OrderController();

        string TotalFilePath = "";  
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["StyleID"] != null)
                {
                    StyleID = Convert.ToInt32(Request.QueryString["StyleID"].ToString());
                }


                if (Request.QueryString["costingid"] != null)
                {
                    costingid = Convert.ToInt32(Request.QueryString["costingid"].ToString());
                }
                else
                {
                    costingid = 0;
                }
                SetInitialRow();
                Binddata();
            }
        }
         
        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
           
            dt.Columns.Add(new DataColumn("Id", typeof(string)));           

            dr = dt.NewRow();
           
            dr["Id"] = string.Empty;
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;

            GrdPairingCosting.DataSource = dt;
            GrdPairingCosting.DataBind();
        }

        protected void GrdPairingCosting_RowCommand(object sender, GridViewCommandEventArgs e)
        {
          //  string Username = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;

            if (e.CommandName == "addnew")
            {                
                int rowIndex = 0;
                    if (ViewState["CurrentTable"] != null)
                    {
                        Table tblGrdviewApplet = (Table)GrdPairingCosting.Controls[0];
                        GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];

                        DataTable dtnew = new DataTable();                      

                       dtnew = (DataTable)(ViewState["CurrentTable"]);
                        //ViewState["CurrentTable"] = GrdPairingCosting.Rows.Count;
                        //dtnew = (DataTable)(ViewState["CurrentTable"]);
                        DataRow drCurrentRow = null;
                        if (dtnew.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtnew.Rows.Count; i++)
                            {
                                TextBox Textbox = (TextBox)GrdPairingCosting.Rows[rowIndex].Cells[1].FindControl("txtPairingCosting");
                                drCurrentRow = dtnew.NewRow();
                               
                                dtnew.Rows[i]["Id"] = Textbox.Text;         

                                rowIndex++;
                                //dtnew.Rows[i]["txtPairingCosting"] = ((TextBox)GrdPairingCosting.Rows[i].FindControl("txtPairingCosting")).Text;
                            }

                            dtnew.Rows.Add(drCurrentRow);

                            ViewState["CurrentTable"] = dtnew;
                            GrdPairingCosting.DataSource = null;
                            GrdPairingCosting.DataBind();
                            GrdPairingCosting.DataSource = dtnew;
                            GrdPairingCosting.DataBind();

                        }                     
                    }
                    else
                    {
                        Response.Write("ViewState is null");
                    }
                    SetPreviousData();
                }              

            }
        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)GrdPairingCosting.Rows[rowIndex].Cells[1].FindControl("txtPairingCosting");
                        box1.Text = dt.Rows[i]["Id"].ToString();
                        rowIndex++;
                    }
                }
            }
        }


       
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            int Rows = GrdPairingCosting.Rows.Count;
                                 
            for (int i = 0; i < Rows; i++)
            {               
                TextBox Textbox = (TextBox)GrdPairingCosting.Rows[i].Cells[1].FindControl("txtPairingCosting");
                TotalFilePath += Textbox.Text + ",";
            }
            if (TotalFilePath.Length > 0)
            {
                TotalFilePath = TotalFilePath.Substring(0, TotalFilePath.Length - 1);
            }
            bool result;
            bool validation = false; ;
            validation = objOrderController.USP_GetValidationUniqueEntry(TotalFilePath,StyleID);

            //objOrderController.UpdateCostingPairing(3, "", 0);
            if (validation == true)
            {
                result = objOrderController.UpdateCostingPairing(StyleID, TotalFilePath);

                // return IsSave;
                // ShowAlert("Save Sucessfully");
                Response.Write("<script>alert('Save Sucessfully');</script>");
                Response.Write("<script> window.parent.Shadowbox.close();</script>");
            }
            else
            {
                Response.Write("<script>alert('Paired Number already exists');</script>");
            }
         
            
        }
    
        protected void Binddata()
        {
            DataTable dtnew = new DataTable();
            dtnew.Columns.Add("Id");

            DataTable dt = new DataTable();
            dt = objOrderController.GetCostingPairing(StyleID);
            if (dt.Rows.Count > 0)
            {
                string PairedID = dt.Rows[0]["PairedID"].ToString();
                string[] a = PairedID.Split(',');
                for (int i = 0; i < a.Length; i++)
                {
                    dtnew.Rows.Add(a[i].ToString());
                    // PlaceHolder1.Controls.Add(new_textbox);
                }

                GrdPairingCosting.DataSource = dtnew;
                GrdPairingCosting.DataBind();
                ViewState["CurrentTable"] = dtnew;
            }
            
        }
        public void InsertPairedCostingHistory()
        {
            DataTable dt=new DataTable();
            CommentHistory objCommentHistory = new Common.CommentHistory();
            dt = objOrderController.GetCostingPairing(StyleID);

            string x = "";

            if (dt.Rows.Count > 0)
            {
                x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                           + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + " Costing Sheet" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Paired costing Value " + " " + "</span>" + "<span style='font-size:10px !impotrant; color:#000000;'>" + dt.Rows[0]["PairedID"].ToString() + " " + "</span>"
                           + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Deleted by " + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToLower() + " " + "</span>"
                           + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "at " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + DateTime.Now.ToString("hh:mm tt") + "</span>";
                objCommentHistory.TypeFlag = 1119;
                objCommentHistory.CostingID = costingid;
                objCommentHistory.FieldName = "Paired costing history";
                objCommentHistory.OldValue = dt.Rows[0]["PairedID"].ToString();
                objCommentHistory.NewValue = "";
                objCommentHistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                objCommentHistory.UpdatedOn = DateTime.Now.ToString();
                objCommentHistory.DetailDescription = x;
                objCommentHistory.isBipl = true;
                objCommentHistory.isPriceQuote = true;

                objOrderController.InsertCommentHistory_New(objCommentHistory);
            }
           

        }
        protected void GrdPairingCosting_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            DataTable dt = ViewState["CurrentTable"] as DataTable;
            dt.Rows[index].Delete();
            ViewState["CurrentTable"] = dt;
            
            GrdPairingCosting.DataSource=dt;
            GrdPairingCosting.DataBind();
            InsertPairedCostingHistory();


           
        }
    }
}