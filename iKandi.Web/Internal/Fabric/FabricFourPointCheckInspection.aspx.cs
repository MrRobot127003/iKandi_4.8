//using System;
//using System.Collections;
//using System.Configuration;
//using System.Data;
//using System.Linq;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.HtmlControls;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Text;
//using System.Collections.Generic;
//using iKandi.BLL;
//using System.Text.RegularExpressions;
//using System.Web.Caching;
//using iKandi.Common;
//using iKandi.Web.Components;
//using System.Drawing;
//using System.Web.Services;

//namespace iKandi.Web.Internal.Fabric
//{
//    public partial class FabricFourPointCheckInspection : System.Web.UI.Page
//    {
//        FabricController fabobj = new FabricController();
//        public string Userid
//        {
//            get;
//            set;

//        }
//        public static int SrvID
//        {
//            get;
//            set;

//        }
//        public static int SupplierPoID
//        {
//            get;
//            set;

//        }
//        public int Fabric_QualityID
//        {
//            get;
//            set;

//        }
//        public int SRV_Id
//        {
//            get;
//            set;

//        }
//        public static int FourPointCheck_Id
//        {
//            get;
//            set;

//        }
//        public static int orderid
//        {
//            get;
//            set;
//        }
//        public static int OrderDetailID
//        {
//            get;
//            set;
//        }
//        #region FIELDS
//        int RollNumber = 0, DeitLotNumber = 0, Status = -1;
//        decimal ClaimedQty = 0, ActualLength = 0, Width_S = 0, Width_M = 0, Width_E = 0, Weaving_1 = 0, Weaving_2 = 0, Weaving_3 = 0, Weaving_4 = 0, total1 = 0, Patta = 0, Hole = 0, total2 = 0, PrintedDefectes_1 = 0, PrintedDefectes_2 = 0, PrintedDefectes_3 = 0, PrintedDefectes_4 = 0, total3 = 0, TotalPoints = 0, WeaPointsPerSquirdYards = 0;
//        string Statusstring = "";
//        #endregion
//        protected void Page_Load(object sender, EventArgs e)
//        {

//            Userid = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID.ToString();
//            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
//                Response.Redirect("~/public/Login.aspx");

//            if (!IsPostBack)
//            {
//                Session["viewGrddate"] = null;
//                txtdates.Text = DateTime.Today.ToString("dd MMM yy (ddd)");

//                getquerystring();
//                BindUnit();
//                BindBasicSectionFabric();
//                //SetPermission();
//                GetSum();

//                DataTable dtstatus = fabobj.GetRaisedPOWorkingDetails("GETPOSTATUS", "", SupplierPoID).Tables[0];
//                if (dtstatus.Rows[0]["postatus"].ToString() == "1" || dtstatus.Rows[0]["postatus"].ToString() == "2")
//                {
//                    ddlunitname.Enabled = false;
//                    grdfourpointcheck.Enabled = false;
                    
//                    foreach (Control c in Page.Controls)
//                    {
//                        foreach (Control ctrl in c.Controls)
//                        {
//                            if (ctrl is TextBox)
//                                ((TextBox)ctrl).Enabled = false;

//                        }
//                    }
//                }
//            }
//        }
//        private void BindUnit()
//        {
//            DropdownHelper.BindUnitReports(ddlunitname);
//        }

//        public void DisableForm(ControlCollection ctrls)
//        {
//            foreach (Control ctrl in ctrls)
//            {
//                if (ctrl is TextBox)
//                    ((TextBox)ctrl).Enabled = false;
//                if (ctrl is Button)
//                    ((Button)ctrl).Enabled = false;
//                else if (ctrl is DropDownList)
//                    ((DropDownList)ctrl).Enabled = false;
//                else if (ctrl is CheckBox)
//                    ((CheckBox)ctrl).Enabled = false;
//                else if (ctrl is RadioButton)
//                    ((RadioButton)ctrl).Enabled = false;
//                else if (ctrl is HtmlInputButton)
//                    ((HtmlInputButton)ctrl).Disabled = true;
//                else if (ctrl is HtmlInputText)
//                    ((HtmlInputText)ctrl).Disabled = true;
//                else if (ctrl is HtmlSelect)
//                    ((HtmlSelect)ctrl).Disabled = true;
//                else if (ctrl is HtmlInputCheckBox)
//                    ((HtmlInputCheckBox)ctrl).Disabled = true;
//                else if (ctrl is HtmlInputRadioButton)
//                    ((HtmlInputRadioButton)ctrl).Disabled = true;

//                grdfourpointcheck.Enabled = false;
//                btnSubmit.Enabled = false;



//            }
//        }
//        //public void SetPermission()
//        //{
//        //    ChkFabricQa.Enabled = false;
//        //    ChkFabricGM.Enabled = false;

//        //    if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_FabricQA)
//        //    {
//        //        ChkFabricQa.Enabled = true;
//        //    }
//        //    if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager)
//        //    {
//        //        if (ChkFabricQa.Checked == true)
//        //        {
//        //            ChkFabricGM.Enabled = true;
//        //        }
//        //        else
//        //        {
//        //            ChkFabricGM.Enabled = false;
//        //        }
//        //    }
//        //}
//        public string GetUnitName(string po)
//        {
//            DataTable dt = fabobj.GetUnitName();

//            //DataView dv = new DataView(dt);
//            //dv.RowFilter = "(PO_Number == " + po + ")";
//            DataRow[] dv = dt.Select("PO_Number = '" + po + "'");

//            return dv[0]["UnitsNames"].ToString();
//        }
//        public void BindBasicSectionFabric()
//        {
//            DataSet ds = new DataSet();
//            DataTable dt = new DataTable();

//            ds = fabobj.GetFabFourPointCheckInsepection("1", SrvID, SupplierPoID);
//            dt = ds.Tables[0];
//            if (dt.Rows.Count > 0)
//            {
//                if (!string.IsNullOrEmpty(dt.Rows[0]["FourPointCheck_Id"].ToString()))
//                    FourPointCheck_Id = Convert.ToInt32(dt.Rows[0]["FourPointCheck_Id"].ToString());
//                else
//                    FourPointCheck_Id = -1;
//                StringBuilder str9 = new StringBuilder();
//                str9.Append("<span style='color:blue'>" + dt.Rows[0]["Fabric"].ToString() + "</span> ");
//                str9.Append("<span style='color:gray'>(" + dt.Rows[0]["GSM"].ToString() + ")</span> ");
//                str9.Append("<span style='color:gray'>" + dt.Rows[0]["CC"].ToString() + "</span> ");
//                if (Convert.ToInt32(dt.Rows[0]["CutWidth"]) > 0)
//                    str9.Append("<span style='color:gray'>" + dt.Rows[0]["CutWidth"].ToString() + "&quot;</span>");


//                // str9.Append("<span>&quot;</span>");
//                lblfab.Text = str9.ToString();
//                lblPrintColor.Text = dt.Rows[0]["ColorPrint"].ToString();
//                SRVNo.Text = "F- " + dt.Rows[0]["SRVNo"].ToString();
//                lblSupplierName.Text = dt.Rows[0]["SupplierName"].ToString();
//                lblPONo.Text = dt.Rows[0]["PO_Number"].ToString();
//                txtCheckerName1.Text = dt.Rows[0]["CheckerName"].ToString();
//                txtcheckname2.Text = dt.Rows[0]["CheckerName"].ToString();
//                hdnCutWidth.Value = dt.Rows[0]["CutWidth"].ToString();  //new line 

//                string[] qcname = dt.Rows[0]["CheckerName"].ToString().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
//                if (qcname.Length == 1)
//                {
//                    txtCheckerName1.Text = qcname[0].ToString();
//                    txtcheckname2.Text = "";
//                }
//                else if (qcname.Length == 2)
//                {
//                    txtCheckerName1.Text = qcname[0].ToString();
//                    txtcheckname2.Text = qcname[1].ToString();
//                }

//                if (dt.Rows[0]["FourPointCheckDate"].ToString() != "")
//                {
//                    txtdates.Text = dt.Rows[0]["FourPointCheckDate"].ToString();
//                }
//                else
//                    txtdates.Text = DateTime.Today.ToString("dd MMM yy (ddd)");

//                if (dt.Rows[0]["ReceivedQty"].ToString() != "")
//                    lblQty.Text = Convert.ToDecimal(dt.Rows[0]["ReceivedQty"]).ToString("N0");

//                lblunitname.Text = " (" + GetUnitName(lblPONo.Text.Trim()) + ")";
//                //lblCheckedunit.Text = lblunitname.Text.Replace(" (", "").Replace(")", "");
//                //lblPassunit.Text = lblunitname.Text.Replace(" (", "").Replace(")", "");
//                //lblHoldunit.Text = lblunitname.Text.Replace(" (", "").Replace(")", "");
//                //lblFailunit.Text = lblunitname.Text.Replace(" (", "").Replace(")", "");
//                //lblReceivedunit.Text = lblunitname.Text.Replace(" (", "").Replace(")", "");

//                if (dt.Rows[0]["ReceivedUnit"].ToString() != "")
//                    ddlunitname.SelectedValue = dt.Rows[0]["ReceivedUnit"].ToString();

//                txtReceivedfourpoint.Text = dt.Rows[0]["ReceivedQtyfourpointcheck"].ToString();
//                txtchecedQtyfourpointchecK.Text = dt.Rows[0]["CheckedQty"].ToString();


//                string[] cmt = dt.Rows[0]["Commentes"].ToString().Split(new string[] { "$$" }, StringSplitOptions.RemoveEmptyEntries);
//                cmt = cmt.Select(x => x.Replace("<br />", "")).ToArray();
//                string[] q = cmt.Distinct().ToArray();
//                StringBuilder sb = new StringBuilder();
//                if (q.Length > 0)
//                {
//                    sb.AppendLine("<table cellspacing='0' cellpadding='0>");
//                    foreach (string str in q)
//                    {
//                        sb.AppendLine("<tr><td style='border:none !important;'>");
//                        sb.AppendLine(str);
//                        sb.AppendLine("</td></tr>");
//                    }
//                    sb.AppendLine("</table>");
//                }
//                lblcomments.Text = sb.ToString();
//                txtchecedQtyfourpointchecK.Text = dt.Rows[0]["CheckedQty"].ToString();
//                if (dt.Rows[0]["PassQty"].ToString() != "")
//                {
//                    if (Convert.ToDecimal(dt.Rows[0]["PassQty"].ToString()) > 0)
//                    {
//                        txtpassfourpointcheck.Text = dt.Rows[0]["PassQty"].ToString();
//                        if (FourPointCheck_Id > 0)
//                            hdnpassqty.Value = dt.Rows[0]["PassQty"].ToString();
//                    }
//                }
//                if (dt.Rows[0]["HoldQty"].ToString() != "")
//                {
//                    if (Convert.ToDecimal(dt.Rows[0]["HoldQty"].ToString()) > 0)
//                    {
//                        txtholdfourpointcheck.Text = dt.Rows[0]["HoldQty"].ToString();
//                    }
//                }
//                if (dt.Rows[0]["FailQty"].ToString() != "")
//                {
//                    if (Convert.ToDecimal(dt.Rows[0]["FailQty"].ToString()) > 0)
//                    {
//                        txtfailfourpointcheck.Text = dt.Rows[0]["FailQty"].ToString();
//                    }
//                }
//                if (txtReceivedfourpoint.Text != "")
//                {
//                    txtReceivedfourpoint.Text = Convert.ToDecimal(txtReceivedfourpoint.Text).ToString("N0");
//                }
//                if (txtchecedQtyfourpointchecK.Text != "")
//                {
//                    txtchecedQtyfourpointchecK.Text = Convert.ToDecimal(txtchecedQtyfourpointchecK.Text).ToString("N0");
//                }
//                if (txtpassfourpointcheck.Text != "")
//                {
//                    txtpassfourpointcheck.Text = Convert.ToDecimal(txtpassfourpointcheck.Text).ToString("N0");
//                }
//                if (txtfailfourpointcheck.Text != "")
//                {
//                    txtfailfourpointcheck.Text = Convert.ToDecimal(txtfailfourpointcheck.Text).ToString("N0");
//                }
//                if (txtholdfourpointcheck.Text != "")
//                {
//                    txtholdfourpointcheck.Text = Convert.ToDecimal(txtholdfourpointcheck.Text).ToString("N0");
//                }
//                ChkFabricQa.Checked = Convert.ToBoolean(dt.Rows[0]["IsFabricQA"].ToString());
//                // ChkCuttingQA.Checked = Convert.ToBoolean(dt.Rows[0]["IsCuttingQA"].ToString());
//                ChkFabricGM.Checked = Convert.ToBoolean(dt.Rows[0]["IsFabricGM"].ToString());

//                ds = fabobj.GetFabFourPointCheckInsepection("2", SrvID, SupplierPoID, FourPointCheck_Id);
//                dt = ds.Tables[0];

//                grdfourpointcheck.DataSource = ds.Tables[0];
//                grdfourpointcheck.DataBind();
//                Session["viewGrddate"] = ds.Tables[0];

//                if (ChkFabricQa.Checked == true && ChkFabricGM.Checked == true)
//                {
//                    DisableForm(Page.Controls);
//                }
//                if (txtholdfourpointcheck.Text != "")
//                {
//                    ChkFabricQa.Enabled = false;
//                    ChkFabricGM.Enabled = false;
//                }
//            }
//        }
//        public void RebindDataTable()
//        {
//            DataTable dtnew = (DataTable)(Session["viewGrddate"]);
//            dtnew.DefaultView.Sort = "ID ASC";


//            foreach (GridViewRow grv in grdfourpointcheck.Rows)
//            {
//                HiddenField hdnrowid = (HiddenField)grv.FindControl("hdnrowid");
//                Label lbltotal_item = (Label)grv.FindControl("lbltotal_item");
//                Label lblTotal2_item = (Label)grv.FindControl("lblTotal2_item");
//                Label lblTotal3_item = (Label)grv.FindControl("lblTotal3_item");
//                Label lblpointTotal_item = (Label)grv.FindControl("lblpointTotal_item");
//                Label lblweapointyard_item = (Label)grv.FindControl("lblweapointyard_item");
//                Label lblstatus_item = (Label)grv.FindControl("lblstatus_item");

//                decimal t1 = 0, t2 = 0, t3 = 0, t4 = 0, t5 = 0, t6 = 0;
//                if (lbltotal_item.Text != "")
//                {
//                    t1 = Convert.ToDecimal(lbltotal_item.Text);
//                }
//                if (lblTotal2_item.Text != "")
//                {
//                    t2 = Convert.ToDecimal(lblTotal2_item.Text);
//                }
//                if (lblTotal3_item.Text != "")
//                {
//                    t3 = Convert.ToDecimal(lblTotal3_item.Text);
//                }
//                if (lblpointTotal_item.Text != "")
//                {
//                    t4 = Convert.ToDecimal(lblpointTotal_item.Text);
//                }
//                if (lblweapointyard_item.Text != "")
//                {
//                    t5 = Convert.ToDecimal(lblweapointyard_item.Text);
//                }
//                if (lblweapointyard_item.Text != "")
//                {
//                    t6 = Convert.ToDecimal(lblweapointyard_item.Text);
//                }

//                foreach (DataRow dr in dtnew.Rows)
//                {
//                    if (dr["ID"].ToString() == hdnrowid.Value)
//                    {
//                        dr["total1"] = Math.Round(t1, 0);
//                        dr["total2"] = Math.Round(t2, 0);
//                        dr["total3"] = Math.Round(t3, 0);
//                        dr["TotalPoints"] = Math.Round(t4, 0);
//                        dr["WeaPointsPerSquirdYards"] = Math.Round(t5, 0);
//                        break;
//                    }
//                }
//                dtnew.AcceptChanges();
//                dtnew.DefaultView.Sort = "ID ASC";
//                Session["viewGrddate"] = dtnew;

//            }
//        }

//        public void Bindgrd()
//        {
//            DataTable dt = (DataTable)Session["viewGrddate"];
//            dt.DefaultView.Sort = "ID asc";
//            dt = dt.DefaultView.ToTable();

//            if (Session["viewGrddate"] != null)
//            {
//                grdfourpointcheck.DataSource = dt;
//                grdfourpointcheck.DataBind();
//            }
//        }
//        public void getquerystring()
//        {
//            if (Request.QueryString["SrvID"] != null)
//            {
//                SrvID = Convert.ToInt32(Request.QueryString["SrvID"].ToString());
//            }
//            if (Request.QueryString["SupplierPoID"] != null)
//            {
//                SupplierPoID = Convert.ToInt32(Request.QueryString["SupplierPoID"].ToString());
//            }
//            if (Request.QueryString["orderid"] != null && Request.QueryString["orderid"] != "undefined")

//                orderid = Convert.ToInt32(Request.QueryString["orderid"]);
//            else
//                orderid = -1;

//            if (Request.QueryString["OrderDetailID"] != null && Request.QueryString["OrderDetailID"] != "undefined")
//                OrderDetailID = Convert.ToInt32(Request.QueryString["OrderDetailID"]);
//            else
//                OrderDetailID = -1;
//        }

//        protected void btnAddFooter_Click(object sender, EventArgs e)
//        {
//            TextBox txtrollno_Footer = grdfourpointcheck.FooterRow.FindControl("txtrollno_Footer") as TextBox;
//            TextBox txtdeilot_Footer = grdfourpointcheck.FooterRow.FindControl("txtdeilot_Footer") as TextBox;
//            TextBox txtclaimedlength_Footer = grdfourpointcheck.FooterRow.FindControl("txtclaimedlength_Footer") as TextBox;    //new line
//            TextBox txtactlenght_Footer = grdfourpointcheck.FooterRow.FindControl("txtactlenght_Footer") as TextBox;
//            TextBox txtwidth_S_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_S_Footer") as TextBox;
//            TextBox txtwidth_M_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_M_Footer") as TextBox;
//            TextBox txtwidth_E_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_E_Footer") as TextBox;
//            TextBox txtwidth_weaving1_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_weaving1_Footer") as TextBox;
//            TextBox txtwidth_weaving2_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_weaving2_Footer") as TextBox;
//            TextBox txtwidth_weaving3_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_weaving3_Footer") as TextBox;
//            TextBox txtwidth_weaving4_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_weaving4_Footer") as TextBox;
//            TextBox txttotal_Footer = grdfourpointcheck.FooterRow.FindControl("txttotal_Footer") as TextBox;
//            TextBox txtpatta_Footer = grdfourpointcheck.FooterRow.FindControl("txtpatta_Footer") as TextBox;
//            TextBox txthole_Footer = grdfourpointcheck.FooterRow.FindControl("txthole_Footer") as TextBox;
//            TextBox txtTotal2_Footer = grdfourpointcheck.FooterRow.FindControl("txtTotal2_Footer") as TextBox;
//            TextBox txtprintdyeingdefacts1_Footer = grdfourpointcheck.FooterRow.FindControl("txtprintdyeingdefacts1_Footer") as TextBox;
//            TextBox txtprintdyeingdefacts2_Footer = grdfourpointcheck.FooterRow.FindControl("txtprintdyeingdefacts2_Footer") as TextBox;
//            TextBox txtprintdyeingdefacts3_Footer = grdfourpointcheck.FooterRow.FindControl("txtprintdyeingdefacts3_Footer") as TextBox;
//            TextBox txtprintdyeingdefacts4_Footer = grdfourpointcheck.FooterRow.FindControl("txtprintdyeingdefacts4_Footer") as TextBox;
//            TextBox txtweapointyard_Footer = grdfourpointcheck.FooterRow.FindControl("txtweapointyard_Footer") as TextBox;
//            DropDownList ddlstatus_Footer = grdfourpointcheck.FooterRow.FindControl("ddlstatus_Footer") as DropDownList;


//            DataTable dtnew = new DataTable();

//            if (txtrollno_Footer.Text != "")
//            {
//                RollNumber = Convert.ToInt32(txtrollno_Footer.Text);
//            }
//            if (txtdeilot_Footer.Text != "")
//            {
//                DeitLotNumber = Convert.ToInt32(txtdeilot_Footer.Text);
//            }

//            //new code start
//            if (txtclaimedlength_Footer.Text != "")
//            {
//                ClaimedQty = Convert.ToDecimal(txtclaimedlength_Footer.Text);
//            }
//            //new code end

//            if (txtactlenght_Footer.Text != "")
//            {
//                ActualLength = Convert.ToDecimal(txtactlenght_Footer.Text);
//            }
//            if (txtwidth_S_Footer.Text != "")
//            {
//                Width_S = Convert.ToDecimal(txtwidth_S_Footer.Text);
//            }
//            if (txtwidth_M_Footer.Text != "")
//            {
//                Width_M = Convert.ToDecimal(txtwidth_M_Footer.Text);
//            }
//            if (txtwidth_E_Footer.Text != "")
//            {
//                Width_E = Convert.ToDecimal(txtwidth_E_Footer.Text);
//            }
//            if (txtwidth_weaving1_Footer.Text != "")
//            {
//                Weaving_1 = Convert.ToDecimal(txtwidth_weaving1_Footer.Text);
//            }
//            if (txtwidth_weaving2_Footer.Text != "")
//            {
//                Weaving_2 = Convert.ToDecimal(txtwidth_weaving2_Footer.Text);
//            }
//            if (txtwidth_weaving3_Footer.Text != "")
//            {
//                Weaving_3 = Convert.ToDecimal(txtwidth_weaving3_Footer.Text);
//            }
//            if (txtwidth_weaving4_Footer.Text != "")
//            {
//                Weaving_4 = Convert.ToDecimal(txtwidth_weaving4_Footer.Text);
//            }
//            if (txtpatta_Footer.Text != "")
//            {
//                Patta = Convert.ToDecimal(txtpatta_Footer.Text);
//            }

//            if (txthole_Footer.Text != "")
//            {
//                Hole = Convert.ToDecimal(txthole_Footer.Text);
//            }

//            if (txtprintdyeingdefacts1_Footer.Text != "")
//            {
//                PrintedDefectes_1 = Convert.ToDecimal(txtprintdyeingdefacts1_Footer.Text);
//            }
//            if (txtprintdyeingdefacts2_Footer.Text != "")
//            {
//                PrintedDefectes_2 = Convert.ToDecimal(txtprintdyeingdefacts2_Footer.Text);
//            }
//            if (txtprintdyeingdefacts3_Footer.Text != "")
//            {
//                PrintedDefectes_3 = Convert.ToDecimal(txtprintdyeingdefacts3_Footer.Text);
//            }
//            if (txtprintdyeingdefacts4_Footer.Text != "")
//            {
//                PrintedDefectes_4 = Convert.ToDecimal(txtprintdyeingdefacts4_Footer.Text);
//            }
//            if (txtweapointyard_Footer.Text != "")
//            {
//                WeaPointsPerSquirdYards = Convert.ToDecimal(txtweapointyard_Footer.Text);
//            }
//            Status = Convert.ToInt32(ddlstatus_Footer.SelectedValue);
//            if (ddlstatus_Footer.SelectedValue == "1")
//            {
//                Statusstring = "pass";
//            }
//            else if (ddlstatus_Footer.SelectedValue == "2")
//            {
//                Statusstring = "fail";
//            }
//            else
//            {
//                Statusstring = "";
//            }

//            if (Session["viewGrddate"] != null)
//            {
//                dtnew = (DataTable)(Session["viewGrddate"]);
//                int i = 0;

//                for (; i < grdfourpointcheck.Rows.Count; i++)
//                {
//                    dtnew.Rows[i]["ID"] = i + 1;
//                    dtnew.Rows[i]["FourPointCheck_Parameter"] = -1;
//                    dtnew.Rows[i]["FourPointCheck_Id"] = -1;
//                    dtnew.Rows[i]["RollNumber"] = Convert.ToInt32(((Label)grdfourpointcheck.Rows[i].FindControl("lblrollno_item")).Text);
//                    dtnew.Rows[i]["DeitLotNumber"] = Convert.ToInt32(((Label)grdfourpointcheck.Rows[i].FindControl("lbldeilot_item")).Text);
//                    dtnew.Rows[i]["ClaimedQty"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblclaimedlength_item")).Text);    //new line
//                    dtnew.Rows[i]["ActualLength"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblactlenght_item")).Text);
//                    dtnew.Rows[i]["Width_S"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_S_item")).Text);
//                    dtnew.Rows[i]["Width_M"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_M_item")).Text);
//                    dtnew.Rows[i]["Width_E"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_E_item")).Text);
//                    dtnew.Rows[i]["Weaving_1"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving1_item")).Text);
//                    dtnew.Rows[i]["Weaving_2"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving2_item")).Text);
//                    dtnew.Rows[i]["Weaving_3"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving3_item")).Text);
//                    dtnew.Rows[i]["Weaving_4"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving4_item")).Text);
//                    dtnew.Rows[i]["Patta"] = ((Label)grdfourpointcheck.Rows[i].FindControl("lblpatta_item")).Text;
//                    dtnew.Rows[i]["Hole"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblhole_item")).Text);
//                    dtnew.Rows[i]["PrintedDefectes_1"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts1_item")).Text);
//                    dtnew.Rows[i]["PrintedDefectes_2"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts2_item")).Text);
//                    dtnew.Rows[i]["PrintedDefectes_3"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts3_item")).Text);
//                    dtnew.Rows[i]["PrintedDefectes_4"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts4_item")).Text);
//                    dtnew.Rows[i]["WeaPointsPerSquirdYards"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblweapointyard_item")).Text);
//                    string statuss = "";
//                    string statusnarration = "";
//                    if (((TextBox)grdfourpointcheck.Rows[i].FindControl("lblstatus_item")).Text == "pass")
//                    {
//                        statuss = "1";
//                        statusnarration = "pass";
//                    }
//                    else if (((TextBox)grdfourpointcheck.Rows[i].FindControl("lblstatus_item")).Text == "fail")
//                    {
//                        statuss = "2";
//                        statusnarration = "fail";
//                    }
//                    else
//                    {
//                        statuss = "-1";
//                    }
//                    dtnew.Rows[i]["Status"] = Convert.ToInt32(statuss);
//                    dtnew.Rows[i]["Statusstring"] = statusnarration;
//                }
//                dtnew.AcceptChanges();
//                dtnew.Rows.Add(i + 1, -1, -1, RollNumber, DeitLotNumber, ClaimedQty, ActualLength, Width_S, Width_M, Width_E, Weaving_1, Weaving_2, Weaving_3, Weaving_4, Patta, Hole, PrintedDefectes_1, PrintedDefectes_2, PrintedDefectes_3, PrintedDefectes_4, WeaPointsPerSquirdYards, Status, Statusstring);
//                Session["viewGrddate"] = dtnew;
//            }
//            Bindgrd();
//        }

//        protected void grdfourpointcheck_RowDeleting(object sender, GridViewDeleteEventArgs e)
//        {
//            GridViewRow row = grdfourpointcheck.Rows[e.RowIndex];
//            HiddenField hdnrowid = (HiddenField)row.FindControl("hdnrowid");
//            if (Session["viewGrddate"] != null)
//            {
//                DataTable dt = (DataTable)Session["viewGrddate"];
//                dt.DefaultView.Sort = "ID ASC";

//                for (int i = dt.Rows.Count - 1; i >= 0; i--)
//                {
//                    DataRow dr = dt.Rows[i];
//                    if (dr["ID"].ToString() == hdnrowid.Value)
//                        dr.Delete();
//                }
//                dt.AcceptChanges();
//                Session["viewGrddate"] = dt;
//            }
//            Bindgrd();
//        }

//        protected void grdfourpointcheck_RowDataBound(object sender, GridViewRowEventArgs e)
//        {

//            if (e.Row.RowType == DataControlRowType.Header)
//            {

//            }
//            if (e.Row.RowType == DataControlRowType.Footer)
//            {

//            }

//            if (e.Row.RowType == DataControlRowType.DataRow)
//            {

//                Label lblrollno_item = (Label)e.Row.FindControl("lblrollno_item");
//                if (lblrollno_item != null)
//                {
//                    Label lbldeilot_item = (Label)e.Row.FindControl("lbldeilot_item");
//                    Label lblclaimedlength_item = (Label)e.Row.FindControl("lblclaimedlength_item"); //new line
//                    Label lblactlenght_item = (Label)e.Row.FindControl("lblactlenght_item");
//                    Label lblwidth_S_item = (Label)e.Row.FindControl("lblwidth_S_item");
//                    Label lblwidth_M_item = (Label)e.Row.FindControl("lblwidth_M_item");
//                    Label lblwidth_E_item = (Label)e.Row.FindControl("lblwidth_E_item");
//                    Label lblwidth_weaving1_item = (Label)e.Row.FindControl("lblwidth_weaving1_item");
//                    Label lblwidth_weaving2_item = (Label)e.Row.FindControl("lblwidth_weaving2_item");
//                    Label lblwidth_weaving3_item = (Label)e.Row.FindControl("lblwidth_weaving3_item");
//                    Label lblwidth_weaving4_item = (Label)e.Row.FindControl("lblwidth_weaving4_item");
//                    Label lbltotal_item = (Label)e.Row.FindControl("lbltotal_item");
//                    Label lblpatta_item = (Label)e.Row.FindControl("lblpatta_item");
//                    Label lblhole_item = (Label)e.Row.FindControl("lblhole_item");
//                    Label lblTotal2_item = (Label)e.Row.FindControl("lblTotal2_item");
//                    Label lblprintdyeingdefacts1_item = (Label)e.Row.FindControl("lblprintdyeingdefacts1_item");
//                    Label lblprintdyeingdefacts2_item = (Label)e.Row.FindControl("lblprintdyeingdefacts2_item");
//                    Label lblprintdyeingdefacts3_item = (Label)e.Row.FindControl("lblprintdyeingdefacts3_item");
//                    Label lblprintdyeingdefacts4_item = (Label)e.Row.FindControl("lblprintdyeingdefacts4_item");
//                    Label lblTotal3_item = (Label)e.Row.FindControl("lblTotal3_item");
//                    Label lblpointTotal_item = (Label)e.Row.FindControl("lblpointTotal_item");
//                    Label lblweapointyard_item = (Label)e.Row.FindControl("lblweapointyard_item");
//                    Label lblstatus_item = (Label)e.Row.FindControl("lblstatus_item");
//                    HiddenField hdnrowid = (HiddenField)e.Row.FindControl("hdnrowid");

//                    //new code start
//                    if (lblrollno_item.Text != string.Empty)
//                    {
//                        totalThaan = totalThaan + Convert.ToInt32(lblrollno_item.Text);
//                        if (totalThaan == 0)
//                        {
//                            lblTotalThaans.Text = "";
//                        }
//                        else
//                        {
//                            lblTotalThaans.Text = totalThaan.ToString();
//                        }
//                        lblTotalThaans.Attributes.Add("style", "color:#000 !important");
//                    }
//                    if (lblactlenght_item.Text != string.Empty)
//                    {
//                        totalReceivedQty = totalReceivedQty + Convert.ToDecimal(lblactlenght_item.Text);
//                        if (totalReceivedQty == 0)
//                        {
//                            lblTotalActualLength.Text = "";
//                        }
//                        else
//                        {
//                            lblTotalActualLength.Text = totalReceivedQty.ToString("#,##0");
//                        }
//                        lblTotalActualLength.Attributes.Add("style", "color:#000 !important");
//                        int Quantity = Convert.ToInt32(lblQty.Text.Replace(",", ""));
//                        int totalActualQuantity = lblTotalActualLength.Text == "" ? 0 : Convert.ToInt32(lblTotalActualLength.Text.Replace(",", ""));
//                        if (Quantity > totalActualQuantity)
//                        {
//                            lblTotalActualLength.Attributes.Add("style", "background-color:#FDFD96");
//                        }
//                        else if (Quantity < totalActualQuantity)
//                        {
//                            lblTotalActualLength.Attributes.Add("style", "background-color:#FFB7B2");
//                        }
//                        else
//                        {
//                            lblTotalActualLength.Attributes.Add("style", "background-color:#fff");
//                        }
//                    }

//                    decimal smallWidth = lblwidth_S_item.Text != string.Empty ? Convert.ToDecimal(lblwidth_S_item.Text) : 0;
//                    decimal middleWidth = lblwidth_M_item.Text != string.Empty ? Convert.ToDecimal(lblwidth_M_item.Text) : 0;
//                    decimal endWidth = lblwidth_E_item.Text != string.Empty ? Convert.ToDecimal(lblwidth_E_item.Text) : 0;
//                    decimal cutWidth = hdnCutWidth.Value != string.Empty ? Convert.ToDecimal(hdnCutWidth.Value) : 0;

//                    if (smallWidth < cutWidth)
//                    {
//                        e.Row.Cells[5].Attributes.Add("style", "background-color:#FDFD96");
//                    }
//                    else if (smallWidth > cutWidth)
//                    {
//                        e.Row.Cells[5].Attributes.Add("style", "background-color:#FFB7B2");
//                    }
//                    else
//                    {
//                        e.Row.Cells[5].Attributes.Add("style", "background-color:#fff");
//                    }

//                    if (middleWidth < cutWidth)
//                    {
//                        e.Row.Cells[6].Attributes.Add("style", "background-color:#FDFD96");
//                    }
//                    else if (middleWidth > cutWidth)
//                    {
//                        e.Row.Cells[6].Attributes.Add("style", "background-color:#FFB7B2");
//                    }
//                    else
//                    {
//                        e.Row.Cells[6].Attributes.Add("style", "background-color:#fff");
//                    }

//                    if (endWidth < cutWidth)
//                    {
//                        e.Row.Cells[7].Attributes.Add("style", "background-color:#FDFD96");
//                    }
//                    else if (endWidth > cutWidth)
//                    {
//                        e.Row.Cells[7].Attributes.Add("style", "background-color:#FFB7B2");
//                    }
//                    else
//                    {
//                        e.Row.Cells[7].Attributes.Add("style", "background-color:#fff");
//                    }

//                    decimal claimedValue = lblclaimedlength_item.Text != string.Empty ? Convert.ToDecimal(lblclaimedlength_item.Text) : 0;
//                    decimal actualValue = lblactlenght_item.Text != string.Empty ? Convert.ToDecimal(lblactlenght_item.Text) : 0;
//                    if (claimedValue < actualValue)
//                    {
//                        e.Row.Cells[4].Attributes.Add("style", "background-color:#FFB7B2");
//                    }
//                    else if (claimedValue > actualValue)
//                    {
//                        e.Row.Cells[4].Attributes.Add("style", "background-color:#FDFD96");
//                    }
//                    else
//                    {
//                        e.Row.Cells[4].Attributes.Add("style", "background-color:#fff");
//                    }
//                    //new code end
//                    CheckEmpty(lblrollno_item);
//                    CheckEmpty(lbldeilot_item);
//                    CheckEmpty(lblclaimedlength_item);   //new line
//                    CheckEmpty(lblactlenght_item);
//                    CheckEmpty(lblwidth_S_item);
//                    CheckEmpty(lblwidth_M_item);
//                    CheckEmpty(lblwidth_E_item);
//                    CheckEmpty(lblwidth_weaving1_item);
//                    CheckEmpty(lblwidth_weaving2_item);
//                    CheckEmpty(lblwidth_weaving3_item);
//                    CheckEmpty(lblwidth_weaving4_item);
//                    CheckEmpty(lblpatta_item);
//                    CheckEmpty(lblhole_item);
//                    CheckEmpty(lblprintdyeingdefacts1_item);
//                    CheckEmpty(lblprintdyeingdefacts2_item);
//                    CheckEmpty(lblprintdyeingdefacts3_item);
//                    CheckEmpty(lblprintdyeingdefacts4_item);
//                    CheckEmpty(lblweapointyard_item);

//                    //new code 13 Jan 2021 start
//                    //if (Convert.ToInt32(lbltotal_item.Text) == 0)
//                    //{
//                    //    lbltotal_item.Text = "";
//                    //}
//                    //if (Convert.ToInt32(lblTotal2_item.Text) == 0)
//                    //{
//                    //    lblTotal2_item.Text = "";
//                    //}
//                    //if (Convert.ToInt32(lblTotal3_item.Text) == 0)
//                    //{
//                    //    lblTotal3_item.Text = "";
//                    //}
//                    //new code 13 Jan 2021 end
//                }
//                else
//                {
//                    TextBox txtrollno_Edit = e.Row.FindControl("txtrollno_Edit") as TextBox;
//                    TextBox txtdeilot_Edit = e.Row.FindControl("txtdeilot_Edit") as TextBox;
//                    TextBox txtclaimedlength_Edit = e.Row.FindControl("txtclaimedlength_Edit") as TextBox;  //new line
//                    TextBox txtactlenght_Edit = e.Row.FindControl("txtactlenght_Edit") as TextBox;
//                    TextBox txtwidth_S_Edit = e.Row.FindControl("txtwidth_S_Edit") as TextBox;
//                    TextBox txtwidth_M_Edit = e.Row.FindControl("txtwidth_M_Edit") as TextBox;
//                    TextBox txtwidth_E_Edit = e.Row.FindControl("txtwidth_E_Edit") as TextBox;
//                    TextBox txtwidth_weaving1_Edit = e.Row.FindControl("txtwidth_weaving1_Edit") as TextBox;
//                    TextBox txtwidth_weaving2_Edit = e.Row.FindControl("txtwidth_weaving2_Edit") as TextBox;
//                    TextBox txtwidth_weaving3_Edit = e.Row.FindControl("txtwidth_weaving3_Edit") as TextBox;
//                    TextBox txtwidth_weaving4_Editv = e.Row.FindControl("txtwidth_weaving4_Edit") as TextBox;
//                    TextBox txttotal_Edit = e.Row.FindControl("txttotal_Edit") as TextBox;
//                    TextBox txtpatta_Edit = e.Row.FindControl("txtpatta_Edit") as TextBox;
//                    TextBox txthole_Edit = e.Row.FindControl("txthole_Edit") as TextBox;
//                    TextBox txtTotal2_Edit = e.Row.FindControl("txtTotal2_Edit") as TextBox;
//                    TextBox txtprintdyeingdefacts1_Edit = e.Row.FindControl("txtprintdyeingdefacts1_Edit") as TextBox;
//                    TextBox txtprintdyeingdefacts2_Edit = e.Row.FindControl("txtprintdyeingdefacts2_Edit") as TextBox;
//                    TextBox txtprintdyeingdefacts3_Edit = e.Row.FindControl("txtprintdyeingdefacts3_Edit") as TextBox;
//                    TextBox txtprintdyeingdefacts4_Edit = e.Row.FindControl("txtprintdyeingdefacts4_Edit") as TextBox;
//                    TextBox txtTotal3_Edit = e.Row.FindControl("txtTotal3_Edit") as TextBox;
//                    TextBox txtpointTotal_Edit = e.Row.FindControl("txtpointTotal_Edit") as TextBox;
//                    TextBox txtweapointyard_Edit = e.Row.FindControl("txtweapointyard_Edit") as TextBox;
//                    DropDownList ddlstatus_Edit = e.Row.FindControl("ddlstatus_Edit") as DropDownList;
//                    HiddenField hdmrowidauto = e.Row.FindControl("hdmrowidauto") as HiddenField;

//                    CheckEmpty(txtrollno_Edit);
//                    CheckEmpty(txtdeilot_Edit);
//                    CheckEmpty(txtclaimedlength_Edit);  //new line
//                    CheckEmpty(txtactlenght_Edit);
//                    CheckEmpty(txtwidth_S_Edit);
//                    CheckEmpty(txtwidth_M_Edit);
//                    CheckEmpty(txtwidth_E_Edit);
//                    CheckEmpty(txtwidth_weaving1_Edit);
//                    CheckEmpty(txtwidth_weaving2_Edit);
//                    CheckEmpty(txtwidth_weaving3_Edit);
//                    CheckEmpty(txtwidth_weaving4_Editv);
//                    CheckEmpty(txtpatta_Edit);
//                    CheckEmpty(txthole_Edit);
//                    CheckEmpty(txtprintdyeingdefacts1_Edit);
//                    CheckEmpty(txtprintdyeingdefacts2_Edit);
//                    CheckEmpty(txtprintdyeingdefacts3_Edit);
//                    CheckEmpty(txtprintdyeingdefacts4_Edit);
//                    CheckEmpty(txtweapointyard_Edit);
                    
//                }

//            }

//            else if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
//            {
//                TextBox txtrollno_Edit = e.Row.FindControl("txtrollno_Edit") as TextBox;
//                TextBox txtdeilot_Edit = e.Row.FindControl("txtdeilot_Edit") as TextBox;
//                TextBox txtclaimedlength_Edit = e.Row.FindControl("txtclaimedlength_Edit") as TextBox;  //new line
//                TextBox txtactlenght_Edit = e.Row.FindControl("txtactlenght_Edit") as TextBox;
//                TextBox txtwidth_S_Edit = e.Row.FindControl("txtwidth_S_Edit") as TextBox;
//                TextBox txtwidth_M_Edit = e.Row.FindControl("txtwidth_M_Edit") as TextBox;
//                TextBox txtwidth_E_Edit = e.Row.FindControl("txtwidth_E_Edit") as TextBox;
//                TextBox txtwidth_weaving1_Edit = e.Row.FindControl("txtwidth_weaving1_Edit") as TextBox;
//                TextBox txtwidth_weaving2_Edit = e.Row.FindControl("txtwidth_weaving2_Edit") as TextBox;
//                TextBox txtwidth_weaving3_Edit = e.Row.FindControl("txtwidth_weaving3_Edit") as TextBox;
//                TextBox txtwidth_weaving4_Editv = e.Row.FindControl("txtwidth_weaving4_Edit") as TextBox;
//                TextBox txttotal_Edit = e.Row.FindControl("txttotal_Edit") as TextBox;
//                TextBox txtpatta_Edit = e.Row.FindControl("txtpatta_Edit") as TextBox;
//                TextBox txthole_Edit = e.Row.FindControl("txthole_Edit") as TextBox;
//                TextBox txtTotal2_Edit = e.Row.FindControl("txtTotal2_Edit") as TextBox;
//                TextBox txtprintdyeingdefacts1_Edit = e.Row.FindControl("txtprintdyeingdefacts1_Edit") as TextBox;
//                TextBox txtprintdyeingdefacts2_Edit = e.Row.FindControl("txtprintdyeingdefacts2_Edit") as TextBox;
//                TextBox txtprintdyeingdefacts3_Edit = e.Row.FindControl("txtprintdyeingdefacts3_Edit") as TextBox;
//                TextBox txtprintdyeingdefacts4_Edit = e.Row.FindControl("txtprintdyeingdefacts4_Edit") as TextBox;
//                TextBox txtTotal3_Edit = e.Row.FindControl("txtTotal3_Edit") as TextBox;
//                TextBox txtpointTotal_Edit = e.Row.FindControl("txtpointTotal_Edit") as TextBox;
//                TextBox txtweapointyard_Edit = e.Row.FindControl("txtweapointyard_Edit") as TextBox;
//                DropDownList ddlstatus_Edit = e.Row.FindControl("ddlstatus_Edit") as DropDownList;
//                HiddenField hdmrowidauto = e.Row.FindControl("hdmrowidauto") as HiddenField;

//                CheckEmpty(txtrollno_Edit);
//                CheckEmpty(txtdeilot_Edit);
//                CheckEmpty(txtclaimedlength_Edit);  //new line
//                CheckEmpty(txtactlenght_Edit);
//                CheckEmpty(txtwidth_S_Edit);
//                CheckEmpty(txtwidth_M_Edit);
//                CheckEmpty(txtwidth_E_Edit);
//                CheckEmpty(txtwidth_weaving1_Edit);
//                CheckEmpty(txtwidth_weaving2_Edit);
//                CheckEmpty(txtwidth_weaving3_Edit);
//                CheckEmpty(txtwidth_weaving4_Editv);
//                CheckEmpty(txtpatta_Edit);
//                CheckEmpty(txthole_Edit);
//                CheckEmpty(txtprintdyeingdefacts1_Edit);
//                CheckEmpty(txtprintdyeingdefacts2_Edit);
//                CheckEmpty(txtprintdyeingdefacts3_Edit);
//                CheckEmpty(txtprintdyeingdefacts4_Edit);
//                CheckEmpty(txtweapointyard_Edit);
//            }
//        }

//        public void CheckEmpty(Control c)
//        {
//            if (c is Label)
//            {
//                Label lbl = (Label)c;
//                if (lbl != null)
//                {
//                    if (!string.IsNullOrEmpty(lbl.Text))
//                    {                        
//                        lbl.Text = Convert.ToDecimal(lbl.Text) <= 0 ? "" : Convert.ToDecimal(lbl.Text).ToString("#,##0");
//                    }
//                }
//            }
//            if (c is TextBox)
//            {
//                TextBox lbl = (TextBox)c;
//                if (lbl != null)
//                {
//                    if (!string.IsNullOrEmpty(lbl.Text))
//                    {
//                        lbl.Text = Convert.ToDecimal(lbl.Text) <= 0 ? "" : Convert.ToDecimal(lbl.Text).ToString("#,##0");
//                    }
//                }
//            }
//        }

//        protected void grdfourpointcheck_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
//        {
//            grdfourpointcheck.EditIndex = -1;
//            Bindgrd();
//        }
//        protected void grdfourpointcheck_RowEditing(object sender, GridViewEditEventArgs e)
//        {
//            //RebindDataTable();
//            grdfourpointcheck.EditIndex = e.NewEditIndex;
//            Bindgrd();
//        }

//        protected void grdfourpointcheck_RowCommand(object sender, GridViewCommandEventArgs e)
//        {
//            if (ValidateSRVQty() == false)
//            {
//                //ShowAlert("Actual Length cannot be greater than total quantity");
//                //return;
//                ShowAlert("Please check actual length is greater than total quantity,You need to revise SRV first..");

//            }
//            //int FourPointCheck_Id = -1, RollNumber = 0, DeitLotNumber = 0, Status = -1;
//            // decimal ActualLength = 0, Width_S = 0, Width_M = 0, Width_E = 0, Weaving_1 = 0, Weaving_2 = 0, Weaving_3 = 0, Weaving_4 = 0, Patta = 0, Hole = 0, PrintedDefectes_1 = 0, PrintedDefectes_2 = 0, PrintedDefectes_3 = 0, PrintedDefectes_4 = 0, WeaPointsPerSquirdYards = 0;
//            string Statusstring = "";
//            if (e.CommandName == "Edit")
//            {
//            }
//            if (e.CommandName == "Insert")
//            {
//                TextBox txtrollno_Footer = grdfourpointcheck.FooterRow.FindControl("txtrollno_Footer") as TextBox;
//                TextBox txtdeilot_Footer = grdfourpointcheck.FooterRow.FindControl("txtdeilot_Footer") as TextBox;
//                TextBox txtclaimedlength_Footer = grdfourpointcheck.FooterRow.FindControl("txtclaimedlength_Footer") as TextBox;    //new line
//                TextBox txtactlenght_Footer = grdfourpointcheck.FooterRow.FindControl("txtactlenght_Footer") as TextBox;
//                TextBox txtwidth_S_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_S_Footer") as TextBox;
//                TextBox txtwidth_M_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_M_Footer") as TextBox;
//                TextBox txtwidth_E_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_E_Footer") as TextBox;
//                TextBox txtwidth_weaving1_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_weaving1_Footer") as TextBox;
//                TextBox txtwidth_weaving2_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_weaving2_Footer") as TextBox;
//                TextBox txtwidth_weaving3_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_weaving3_Footer") as TextBox;
//                TextBox txtwidth_weaving4_Footer = grdfourpointcheck.FooterRow.FindControl("txtwidth_weaving4_Footer") as TextBox;
//                TextBox txttotal_Footer = grdfourpointcheck.FooterRow.FindControl("txttotal_Footer") as TextBox;
//                TextBox txtpatta_Footer = grdfourpointcheck.FooterRow.FindControl("txtpatta_Footer") as TextBox;
//                TextBox txthole_Footer = grdfourpointcheck.FooterRow.FindControl("txthole_Footer") as TextBox;
//                TextBox txtTotal2_Footer = grdfourpointcheck.FooterRow.FindControl("txtTotal2_Footer") as TextBox;

//                TextBox txtprintdyeingdefacts1_Footer = grdfourpointcheck.FooterRow.FindControl("txtprintdyeingdefacts1_Footer") as TextBox;
//                TextBox txtprintdyeingdefacts2_Footer = grdfourpointcheck.FooterRow.FindControl("txtprintdyeingdefacts2_Footer") as TextBox;
//                TextBox txtprintdyeingdefacts3_Footer = grdfourpointcheck.FooterRow.FindControl("txtprintdyeingdefacts3_Footer") as TextBox;
//                TextBox txtprintdyeingdefacts4_Footer = grdfourpointcheck.FooterRow.FindControl("txtprintdyeingdefacts4_Footer") as TextBox;
//                TextBox txtTotal3_Footer = grdfourpointcheck.FooterRow.FindControl("txtTotal3_Footer") as TextBox;
//                TextBox txtpointTotal_Footer = grdfourpointcheck.FooterRow.FindControl("txtpointTotal_Footer") as TextBox;
//                TextBox txtweapointyard_Footer = grdfourpointcheck.FooterRow.FindControl("txtweapointyard_Footer") as TextBox;
//                DropDownList ddlstatus_Footer = grdfourpointcheck.FooterRow.FindControl("ddlstatus_Footer") as DropDownList;
//                HiddenField hdmrowidauto_foter = grdfourpointcheck.FooterRow.FindControl("hdmrowidauto_foter") as HiddenField;


//                DataTable dtnew = new DataTable();
//                FourPointCheck_Id = -1;
//                if (txtrollno_Footer.Text != "")
//                {
//                    RollNumber = Convert.ToInt32(txtrollno_Footer.Text);
//                }
//                if (txtdeilot_Footer.Text != "")
//                {
//                    DeitLotNumber = Convert.ToInt32(txtdeilot_Footer.Text);
//                }

//                //new code start
//                if (txtclaimedlength_Footer.Text != "")
//                {
//                    ClaimedQty = Convert.ToDecimal(txtclaimedlength_Footer.Text);
//                }
//                //new code end

//                if (txtactlenght_Footer.Text != "")
//                {
//                    ActualLength = Convert.ToDecimal(txtactlenght_Footer.Text);
//                }
//                if (txtwidth_S_Footer.Text != "")
//                {
//                    Width_S = Convert.ToDecimal(txtwidth_S_Footer.Text);
//                }
//                if (txtwidth_M_Footer.Text != "")
//                {
//                    Width_M = Convert.ToDecimal(txtwidth_M_Footer.Text);
//                }
//                if (txtwidth_E_Footer.Text != "")
//                {
//                    Width_E = Convert.ToDecimal(txtwidth_E_Footer.Text);
//                }
//                if (txtwidth_weaving1_Footer.Text != "")
//                {
//                    Weaving_1 = Convert.ToDecimal(txtwidth_weaving1_Footer.Text);
//                }
//                if (txtwidth_weaving2_Footer.Text != "")
//                {
//                    Weaving_2 = Convert.ToDecimal(txtwidth_weaving2_Footer.Text);
//                }
//                if (txtwidth_weaving3_Footer.Text != "")
//                {
//                    Weaving_3 = Convert.ToDecimal(txtwidth_weaving3_Footer.Text);
//                }
//                if (txtwidth_weaving4_Footer.Text != "")
//                {
//                    Weaving_4 = Convert.ToDecimal(txtwidth_weaving4_Footer.Text);
//                }
//                if (txttotal_Footer.Text != "")
//                {
//                    total1 = Convert.ToDecimal(txttotal_Footer.Text);
//                }
//                if (txtpatta_Footer.Text != "")
//                {
//                    Patta = Convert.ToDecimal(txtpatta_Footer.Text);
//                }

//                if (txthole_Footer.Text != "")
//                {
//                    Hole = Convert.ToDecimal(txthole_Footer.Text);
//                }
//                if (txtTotal2_Footer.Text != "")
//                {
//                    total2 = Convert.ToDecimal(txtTotal2_Footer.Text);
//                }
//                if (txtprintdyeingdefacts1_Footer.Text != "")
//                {
//                    PrintedDefectes_1 = Convert.ToDecimal(txtprintdyeingdefacts1_Footer.Text);
//                }
//                if (txtprintdyeingdefacts2_Footer.Text != "")
//                {
//                    PrintedDefectes_2 = Convert.ToDecimal(txtprintdyeingdefacts2_Footer.Text);
//                }
//                if (txtprintdyeingdefacts3_Footer.Text != "")
//                {
//                    PrintedDefectes_3 = Convert.ToDecimal(txtprintdyeingdefacts3_Footer.Text);
//                }
//                if (txtprintdyeingdefacts4_Footer.Text != "")
//                {
//                    PrintedDefectes_4 = Convert.ToDecimal(txtprintdyeingdefacts4_Footer.Text);
//                }
//                if (txtweapointyard_Footer.Text != "")
//                {
//                    WeaPointsPerSquirdYards = Convert.ToDecimal(txtweapointyard_Footer.Text);
//                }
//                if (txtTotal3_Footer.Text != "")
//                {
//                    total3 = Convert.ToDecimal(txtTotal3_Footer.Text);
//                }
//                if (txtpointTotal_Footer.Text != "")
//                {
//                    total3 = Convert.ToDecimal(txtpointTotal_Footer.Text);
//                }
//                Status = Convert.ToInt32(ddlstatus_Footer.SelectedValue);
//                if (ddlstatus_Footer.SelectedValue == "1")
//                {
//                    Statusstring = "pass";
//                }
//                else if (ddlstatus_Footer.SelectedValue == "2")
//                {
//                    Statusstring = "fail";
//                }
//                else
//                {
//                    Statusstring = "";
//                }

//                if (Session["viewGrddate"] != null)
//                {
//                    dtnew = (DataTable)(Session["viewGrddate"]);
//                    int i = 0;
//                    for (; i < grdfourpointcheck.Rows.Count; i++)
//                    {
//                        dtnew.Rows[i]["ID"] = i + 1;
//                        dtnew.Rows[i]["FourPointCheck_Parameter"] = -1;
//                        dtnew.Rows[i]["FourPointCheck_Id"] = -1;
//                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblrollno_item")).Text != "")
//                        {
//                            dtnew.Rows[i]["RollNumber"] = Convert.ToInt32(((Label)grdfourpointcheck.Rows[i].FindControl("lblrollno_item")).Text);
//                        }
//                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lbldeilot_item")).Text != "")
//                        {
//                            dtnew.Rows[i]["DeitLotNumber"] = Convert.ToInt32(((Label)grdfourpointcheck.Rows[i].FindControl("lbldeilot_item")).Text);
//                        }
//                        //new code start
//                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblclaimedlength_item")).Text != "")
//                        {
//                            dtnew.Rows[i]["ClaimedQty"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblclaimedlength_item")).Text);
//                        }
//                        //new code end
//                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblactlenght_item")).Text != "")
//                        {
//                            dtnew.Rows[i]["ActualLength"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblactlenght_item")).Text);
//                        }
//                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_S_item")).Text != "")
//                        {
//                            dtnew.Rows[i]["Width_S"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_S_item")).Text);
//                        }
//                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_M_item")).Text != "")
//                        {
//                            dtnew.Rows[i]["Width_M"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_M_item")).Text);
//                        }
//                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_E_item")).Text != "")
//                        {
//                            dtnew.Rows[i]["Width_E"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_E_item")).Text);
//                        }
//                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving1_item")).Text != "")
//                        {
//                            dtnew.Rows[i]["Weaving_1"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving1_item")).Text);
//                        }
//                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving2_item")).Text != "")
//                        {
//                            dtnew.Rows[i]["Weaving_2"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving2_item")).Text);
//                        }
//                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving3_item")).Text != "")
//                        {
//                            dtnew.Rows[i]["Weaving_3"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving3_item")).Text);
//                        }
//                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving4_item")).Text != "")
//                        {
//                            dtnew.Rows[i]["Weaving_4"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblwidth_weaving4_item")).Text);
//                        }
//                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lbltotal_item")).Text != "")
//                        {
//                            dtnew.Rows[i]["total1"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lbltotal_item")).Text);
//                        }
//                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblTotal2_item")).Text != "")
//                        {
//                            dtnew.Rows[i]["total2"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblTotal2_item")).Text);
//                        }
//                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblTotal3_item")).Text != "")
//                        {
//                            dtnew.Rows[i]["total3"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblTotal3_item")).Text);
//                        }
//                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblpointTotal_item")).Text != "")
//                        {
//                            dtnew.Rows[i]["TotalPoints"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblpointTotal_item")).Text);
//                        }
//                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblpatta_item")).Text != "")
//                        {
//                            dtnew.Rows[i]["Patta"] = ((Label)grdfourpointcheck.Rows[i].FindControl("lblpatta_item")).Text;
//                        }
//                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblhole_item")).Text != "")
//                        {
//                            dtnew.Rows[i]["Hole"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblhole_item")).Text);
//                        }
//                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts1_item")).Text != "")
//                        {
//                            dtnew.Rows[i]["PrintedDefectes_1"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts1_item")).Text);
//                        }
//                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts2_item")).Text != "")
//                        {
//                            dtnew.Rows[i]["PrintedDefectes_2"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts2_item")).Text);
//                        }
//                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts3_item")).Text != "")
//                        {
//                            dtnew.Rows[i]["PrintedDefectes_3"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts3_item")).Text);
//                        }
//                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts4_item")).Text != "")
//                        {
//                            dtnew.Rows[i]["PrintedDefectes_4"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblprintdyeingdefacts4_item")).Text);
//                        }
//                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblweapointyard_item")).Text != "")
//                        {
//                            dtnew.Rows[i]["WeaPointsPerSquirdYards"] = Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblweapointyard_item")).Text);
//                        }
//                        string statuss = "";
//                        string statusnarration = "";
//                        if (((Label)grdfourpointcheck.Rows[i].FindControl("lblstatus_item")).Text == "pass")
//                        {
//                            statuss = "1";
//                            statusnarration = "pass";
//                        }
//                        else if (((Label)grdfourpointcheck.Rows[i].FindControl("lblstatus_item")).Text == "fail")
//                        {
//                            statuss = "2";
//                            statusnarration = "fail";
//                        }
//                        else
//                        {
//                            statuss = "-1";
//                        }
//                        dtnew.Rows[i]["Status"] = Convert.ToInt32(statuss);
//                        dtnew.Rows[i]["Statusstring"] = statusnarration;
//                    }
//                    dtnew.AcceptChanges();

//                    int id = 0;
//                    if (dtnew.Rows.Count <= 0)
//                    {
//                        id = 1;
//                    }
//                    else
//                    {
//                        id = dtnew.Rows.Count + 1;
//                    }

//                    dtnew.Rows.Add(id, -1, -1, RollNumber, DeitLotNumber, ClaimedQty, ActualLength, Width_S, Width_M, Width_E, Weaving_1, Weaving_2, Weaving_3, Weaving_4, total1, Patta, Hole, total2, PrintedDefectes_1, PrintedDefectes_2, PrintedDefectes_3, PrintedDefectes_4, total3, TotalPoints, WeaPointsPerSquirdYards, Status, Statusstring);
//                    Session["viewGrddate"] = dtnew;
//                }
//                Bindgrd();
//            }
//            if (e.CommandName == "addnew")
//            {

//                Table tblGrdviewApplet = (Table)grdfourpointcheck.Controls[0];
//                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];
//                TextBox txtrollno_emptyrow = (TextBox)rows.FindControl("txtrollno_emptyrow");
//                TextBox txtdeilot_emptyrow = (TextBox)rows.FindControl("txtdeilot_emptyrow");
//                TextBox txtclaimedlength_emptyrow = (TextBox)rows.FindControl("txtclaimedlength_emptyrow"); //new line
//                TextBox txtactlenght_emptyrow = (TextBox)rows.FindControl("txtactlenght_emptyrow");
//                TextBox txtwithd_s_emptyrow = (TextBox)rows.FindControl("txtwithd_s_emptyrow");
//                TextBox txtwithd_M_emptyrow = (TextBox)rows.FindControl("txtwithd_M_emptyrow");
//                TextBox txtwithd_E_emptyrow = (TextBox)rows.FindControl("txtwithd_E_emptyrow");
//                TextBox txtweaving_1_emptyrow = (TextBox)rows.FindControl("txtweaving_1_emptyrow");
//                TextBox txtweaving_2_emptyrow = (TextBox)rows.FindControl("txtweaving_2_emptyrow");
//                TextBox txtweaving_3_emptyrow = (TextBox)rows.FindControl("txtweaving_3_emptyrow");
//                TextBox txtweaving_4_emptyrow = (TextBox)rows.FindControl("txtweaving_4_emptyrow");
//                TextBox txttotal1_emptyrow = (TextBox)rows.FindControl("txttotal1_emptyrow");
//                TextBox txtpatta_emptyrow = (TextBox)rows.FindControl("txtpatta_emptyrow");
//                TextBox txthole_emptyrow = (TextBox)rows.FindControl("txthole_emptyrow");
//                TextBox txttotal2_emptyrow = (TextBox)rows.FindControl("txttotal2_emptyrow");
//                TextBox txtprintdyeingdefacts1_emptyrow = (TextBox)rows.FindControl("txtprintdyeingdefacts1_emptyrow");
//                TextBox txtprintdyeingdefacts2_emptyrow = (TextBox)rows.FindControl("txtprintdyeingdefacts2_emptyrow");
//                TextBox txtprintdyeingdefacts3_emptyrow = (TextBox)rows.FindControl("txtprintdyeingdefacts3_emptyrow");
//                TextBox txtprintdyeingdefacts4_emptyrow = (TextBox)rows.FindControl("txtprintdyeingdefacts4_emptyrow");
//                TextBox txttotal3_emptyrow = (TextBox)rows.FindControl("txttotal3_emptyrow");
//                TextBox txttotalpoint_emptyrow = (TextBox)rows.FindControl("txttotalpoint_emptyrow");
//                TextBox txtweapointyard_emptyrow = (TextBox)rows.FindControl("txtweapointyard_emptyrow");
//                DropDownList ddlstatus_emptyrow = (DropDownList)rows.FindControl("ddlstatus_emptyrow");
//                HiddenField hdmrowidauto_empty = (HiddenField)rows.FindControl("hdmrowidauto_empty");
//                FourPointCheck_Id = -1;
//                if (txtrollno_emptyrow.Text != "")
//                {
//                    RollNumber = Convert.ToInt32(txtrollno_emptyrow.Text);
//                }
//                if (txtdeilot_emptyrow.Text != "")
//                {
//                    DeitLotNumber = Convert.ToInt32(txtdeilot_emptyrow.Text);
//                }

//                //new code start
//                if (txtclaimedlength_emptyrow.Text != "")
//                {
//                    ClaimedQty = Convert.ToDecimal(txtclaimedlength_emptyrow.Text);
//                }
//                //new code end

//                if (txtactlenght_emptyrow.Text != "")
//                {
//                    ActualLength = Convert.ToDecimal(txtactlenght_emptyrow.Text);
//                }
//                if (txtwithd_s_emptyrow.Text != "")
//                {
//                    Width_S = Convert.ToDecimal(txtwithd_s_emptyrow.Text);
//                }
//                if (txtwithd_M_emptyrow.Text != "")
//                {
//                    Width_M = Convert.ToDecimal(txtwithd_M_emptyrow.Text);
//                }
//                if (txtwithd_E_emptyrow.Text != "")
//                {
//                    Width_E = Convert.ToDecimal(txtwithd_E_emptyrow.Text);
//                }
//                if (txtweaving_1_emptyrow.Text != "")
//                {
//                    Weaving_1 = Convert.ToDecimal(txtweaving_1_emptyrow.Text);
//                }
//                if (txtweaving_2_emptyrow.Text != "")
//                {
//                    Weaving_2 = Convert.ToDecimal(txtweaving_2_emptyrow.Text);
//                }
//                if (txtweaving_3_emptyrow.Text != "")
//                {
//                    Weaving_3 = Convert.ToDecimal(txtweaving_3_emptyrow.Text);
//                }
//                if (txtweaving_4_emptyrow.Text != "")
//                {
//                    Weaving_4 = Convert.ToDecimal(txtweaving_4_emptyrow.Text);
//                }
//                if (txttotal1_emptyrow.Text != "")
//                {
//                    total1 = Convert.ToDecimal(txttotal1_emptyrow.Text);
//                }

//                if (txtpatta_emptyrow.Text != "")
//                {
//                    Patta = Convert.ToDecimal(txtpatta_emptyrow.Text);
//                }
//                if (txthole_emptyrow.Text != "")
//                {
//                    Hole = Convert.ToDecimal(txthole_emptyrow.Text);
//                }
//                if (txttotal2_emptyrow.Text != "")
//                {
//                    total2 = Convert.ToDecimal(txttotal2_emptyrow.Text);
//                }
//                if (txtprintdyeingdefacts1_emptyrow.Text != "")
//                {
//                    PrintedDefectes_1 = Convert.ToDecimal(txtprintdyeingdefacts1_emptyrow.Text);
//                }
//                if (txtprintdyeingdefacts2_emptyrow.Text != "")
//                {
//                    PrintedDefectes_2 = Convert.ToDecimal(txtprintdyeingdefacts2_emptyrow.Text);
//                }
//                if (txtprintdyeingdefacts3_emptyrow.Text != "")
//                {
//                    PrintedDefectes_3 = Convert.ToDecimal(txtprintdyeingdefacts3_emptyrow.Text);
//                }
//                if (txtprintdyeingdefacts4_emptyrow.Text != "")
//                {
//                    PrintedDefectes_4 = Convert.ToDecimal(txtprintdyeingdefacts4_emptyrow.Text);
//                }
//                if (txttotal3_emptyrow.Text != "")
//                {
//                    total3 = Convert.ToDecimal(txttotal3_emptyrow.Text);
//                }
//                if (txttotalpoint_emptyrow.Text != "")
//                {
//                    TotalPoints = Convert.ToDecimal(txttotalpoint_emptyrow.Text);
//                }
//                if (txtweapointyard_emptyrow.Text != "")
//                {
//                    WeaPointsPerSquirdYards = Convert.ToDecimal(txtweapointyard_emptyrow.Text);
//                }
//                Status = Convert.ToInt32(ddlstatus_emptyrow.SelectedValue);
//                if (ddlstatus_emptyrow.SelectedValue == "1")
//                {
//                    Statusstring = "pass";
//                }
//                else if (ddlstatus_emptyrow.SelectedValue == "2")
//                {
//                    Statusstring = "fail";
//                }
//                else
//                {
//                    Statusstring = "";
//                }
//                if (Session["viewGrddate"] != null)
//                {
//                    DataTable dtnew = (DataTable)(Session["viewGrddate"]);
//                    dtnew.AcceptChanges();

//                    int id = 0;
//                    if (dtnew.Rows.Count <= 0)
//                    {
//                        id = 1;
//                    }
//                    else
//                    {
//                        id = dtnew.Rows.Count + 1;
//                    }
//                    dtnew.Rows.Add(id, -1, -1, RollNumber, DeitLotNumber, ClaimedQty, ActualLength, Width_S, Width_M, Width_E, Weaving_1, Weaving_2, Weaving_3, Weaving_4, total1, Patta, Hole, total2, PrintedDefectes_1, PrintedDefectes_2, PrintedDefectes_3, PrintedDefectes_4, total3, TotalPoints, WeaPointsPerSquirdYards, Status, Statusstring);
//                    Session["viewGrddate"] = dtnew;

//                    grdfourpointcheck.DataSource = dtnew;
//                    grdfourpointcheck.DataBind();
//                }
//                // Bindgrd();
//            }
//        }
//        protected void grdfourpointcheck_RowUpdating(object sender, GridViewUpdateEventArgs e)
//        {
//            RollNumber = 0;
//            DeitLotNumber = 0;
//            ClaimedQty = 0; //new line
//            ActualLength = 0;
//            Width_S = 0;
//            Width_M = 0;
//            Width_E = 0;
//            Weaving_1 = 0;
//            Weaving_2 = 0;
//            Weaving_3 = 0;
//            Weaving_4 = 0;
//            Patta = 0;
//            Hole = 0;
//            PrintedDefectes_1 = 0;
//            PrintedDefectes_2 = 0;
//            PrintedDefectes_3 = 0;
//            PrintedDefectes_4 = 0;
//            WeaPointsPerSquirdYards = 0;

//            GridViewRow Rows = grdfourpointcheck.Rows[e.RowIndex];
//            TextBox txtrollno_Edit = Rows.FindControl("txtrollno_Edit") as TextBox;
//            TextBox txtdeilot_Edit = Rows.FindControl("txtdeilot_Edit") as TextBox;
//            TextBox txtclaimedlength_Edit = Rows.FindControl("txtclaimedlength_Edit") as TextBox;   //new line
//            TextBox txtactlenght_Edit = Rows.FindControl("txtactlenght_Edit") as TextBox;
//            TextBox txtwidth_S_Edit = Rows.FindControl("txtwidth_S_Edit") as TextBox;
//            TextBox txtwidth_M_Edit = Rows.FindControl("txtwidth_M_Edit") as TextBox;
//            TextBox txtwidth_E_Edit = Rows.FindControl("txtwidth_E_Edit") as TextBox;
//            TextBox txtwidth_weaving1_Edit = Rows.FindControl("txtwidth_weaving1_Edit") as TextBox;
//            TextBox txtwidth_weaving2_Edit = Rows.FindControl("txtwidth_weaving2_Edit") as TextBox;
//            TextBox txtwidth_weaving3_Edit = Rows.FindControl("txtwidth_weaving3_Edit") as TextBox;
//            TextBox txtwidth_weaving4_Editv = Rows.FindControl("txtwidth_weaving4_Edit") as TextBox;
//            TextBox txttotal_Edit = Rows.FindControl("txttotal_Edit") as TextBox;
//            TextBox txtpatta_Edit = Rows.FindControl("txtpatta_Edit") as TextBox;
//            TextBox txthole_Edit = Rows.FindControl("txthole_Edit") as TextBox;
//            TextBox txtTotal2_Edit = Rows.FindControl("txtTotal2_Edit") as TextBox;
//            TextBox txtprintdyeingdefacts1_Edit = Rows.FindControl("txtprintdyeingdefacts1_Edit") as TextBox;
//            TextBox txtprintdyeingdefacts2_Edit = Rows.FindControl("txtprintdyeingdefacts2_Edit") as TextBox;
//            TextBox txtprintdyeingdefacts3_Edit = Rows.FindControl("txtprintdyeingdefacts3_Edit") as TextBox;
//            TextBox txtprintdyeingdefacts4_Edit = Rows.FindControl("txtprintdyeingdefacts4_Edit") as TextBox;
//            TextBox txtTotal3_Edit = Rows.FindControl("txtTotal3_Edit") as TextBox;
//            TextBox txtpointTotal_Edit = Rows.FindControl("txtpointTotal_Edit") as TextBox;
//            TextBox txtweapointyard_Edit = Rows.FindControl("txtweapointyard_Edit") as TextBox;
//            DropDownList ddlstatus_Edit = Rows.FindControl("ddlstatus_Edit") as DropDownList;
//            HiddenField hdmrowidauto = Rows.FindControl("hdmrowidauto") as HiddenField;

//            FourPointCheck_Id = -1;
//            if (txtrollno_Edit.Text != "")
//            {
//                RollNumber = Convert.ToInt32(txtrollno_Edit.Text);
//            }
//            if (txtdeilot_Edit.Text != "")
//            {
//                DeitLotNumber = Convert.ToInt32(txtdeilot_Edit.Text);
//            }
//            //new code start
//            if (txtclaimedlength_Edit.Text != "")
//            {
//                ClaimedQty = Convert.ToDecimal(txtclaimedlength_Edit.Text);
//            }
//            //new code end
//            if (txtactlenght_Edit.Text != "")
//            {
//                ActualLength = Convert.ToDecimal(txtactlenght_Edit.Text);
//            }
//            if (txtwidth_S_Edit.Text != "")
//            {
//                Width_S = Convert.ToDecimal(txtwidth_S_Edit.Text);
//            }
//            if (txtwidth_M_Edit.Text != "")
//            {
//                Width_M = Convert.ToDecimal(txtwidth_M_Edit.Text);
//            }
//            if (txtwidth_E_Edit.Text != "")
//            {
//                Width_E = Convert.ToDecimal(txtwidth_E_Edit.Text);
//            }
//            if (txtwidth_weaving1_Edit.Text != "")
//            {
//                Weaving_1 = Convert.ToDecimal(txtwidth_weaving1_Edit.Text);
//            }
//            if (txtwidth_weaving2_Edit.Text != "")
//            {
//                Weaving_2 = Convert.ToDecimal(txtwidth_weaving2_Edit.Text);
//            }
//            if (txtwidth_weaving3_Edit.Text != "")
//            {
//                Weaving_3 = Convert.ToDecimal(txtwidth_weaving3_Edit.Text);
//            }
//            if (txtwidth_weaving4_Editv.Text != "")
//            {
//                Weaving_4 = Convert.ToDecimal(txtwidth_weaving4_Editv.Text);
//            }
//            if (txtpatta_Edit.Text != "")
//            {
//                Patta = Convert.ToDecimal(txtpatta_Edit.Text);
//            }
//            if (txthole_Edit.Text != "")
//            {
//                Hole = Convert.ToDecimal(txthole_Edit.Text);
//            }

//            if (txtprintdyeingdefacts1_Edit.Text != "")
//            {
//                PrintedDefectes_1 = Convert.ToDecimal(txtprintdyeingdefacts1_Edit.Text);
//            }
//            if (txtprintdyeingdefacts2_Edit.Text != "")
//            {
//                PrintedDefectes_2 = Convert.ToDecimal(txtprintdyeingdefacts2_Edit.Text);
//            }
//            if (txtprintdyeingdefacts3_Edit.Text != "")
//            {
//                PrintedDefectes_3 = Convert.ToDecimal(txtprintdyeingdefacts3_Edit.Text);
//            }
//            if (txtprintdyeingdefacts4_Edit.Text != "")
//            {
//                PrintedDefectes_4 = Convert.ToDecimal(txtprintdyeingdefacts4_Edit.Text);
//            }
//            if (txtweapointyard_Edit.Text != "")
//            {
//                WeaPointsPerSquirdYards = Convert.ToDecimal(txtweapointyard_Edit.Text);
//            }
//            Status = Convert.ToInt32(ddlstatus_Edit.SelectedValue);
//            if (ddlstatus_Edit.SelectedValue == "1")
//            {
//                Statusstring = "pass";
//            }
//            else if (ddlstatus_Edit.SelectedValue == "2")
//            {
//                Statusstring = "fail";
//            }
//            else
//            {
//                Statusstring = "";
//            }
//            DataTable dtnew = (DataTable)(Session["viewGrddate"]);
//            dtnew.DefaultView.Sort = "ID ASC";



//            foreach (DataRow dr in dtnew.Rows)
//            {
//                if (dr["ID"].ToString() == hdmrowidauto.Value)
//                {
//                    dr["FourPointCheck_Parameter"] = -1;
//                    dr["FourPointCheck_Id"] = -1;
//                    dr["RollNumber"] = Convert.ToInt32(RollNumber);
//                    dr["DeitLotNumber"] = Convert.ToInt32(DeitLotNumber);
//                    dr["ClaimedQty"] = ClaimedQty;  //new line
//                    dr["ActualLength"] = ActualLength;
//                    dr["Width_S"] = Width_S;
//                    dr["Width_M"] = Width_M;
//                    dr["Width_E"] = Width_E;
//                    dr["Weaving_1"] = Weaving_1;
//                    dr["Weaving_2"] = Weaving_2;
//                    dr["Weaving_3"] = Weaving_3;
//                    dr["Weaving_4"] = Weaving_4;
//                    dr["Patta"] = Patta;
//                    dr["Hole"] = Hole;
//                    dr["PrintedDefectes_1"] = PrintedDefectes_1;
//                    dr["PrintedDefectes_2"] = PrintedDefectes_2;
//                    dr["PrintedDefectes_3"] = PrintedDefectes_3;
//                    dr["PrintedDefectes_4"] = PrintedDefectes_4;
//                    dr["WeaPointsPerSquirdYards"] = WeaPointsPerSquirdYards;
//                    dr["Status"] = Convert.ToInt32(Status);
//                    dr["Statusstring"] = Statusstring;
//                    break;
//                }
//            }
//            dtnew.AcceptChanges();
//            grdfourpointcheck.EditIndex = -1;
//            dtnew.DefaultView.Sort = "ID ASC";
//            Session["viewGrddate"] = dtnew;
//            if (Session["viewGrddate"] != null)
//            {
//                Bindgrd();

//            }
//        }

//        #region "METHOD FOR SHOW ALERT"
//        public void ShowAlert(string stringAlertMsg)
//        {
//            string myStringVariable = string.Empty;
//            myStringVariable = stringAlertMsg;
//            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
//        }
//        #endregion

//        protected void btncallback_Click(object sender, EventArgs e)
//        {
//            RebindDataTable();

//        }
//        public void GetSum()
//        {
//            DataTable dtnew = (DataTable)(Session["viewGrddate"]);
//            dtnew.DefaultView.Sort = "ID ASC";
//            foreach (GridViewRow grv in grdfourpointcheck.Rows)
//            {

//                Label lblrollno_item = (Label)grv.FindControl("lblrollno_item");
//                if (lblrollno_item != null)
//                {

//                    Label lbldeilot_item = (Label)grv.FindControl("lbldeilot_item");
//                    Label lblclaimedlength_item = (Label)grv.FindControl("lblclaimedlength_item"); //new line
//                    Label lblactlenght_item = (Label)grv.FindControl("lblactlenght_item");
//                    Label lblwidth_S_item = (Label)grv.FindControl("lblwidth_S_item");
//                    Label lblwidth_M_item = (Label)grv.FindControl("lblwidth_M_item");
//                    Label lblwidth_E_item = (Label)grv.FindControl("lblwidth_E_item");
//                    Label lblwidth_weaving1_item = (Label)grv.FindControl("lblwidth_weaving1_item");
//                    Label lblwidth_weaving2_item = (Label)grv.FindControl("lblwidth_weaving2_item");
//                    Label lblwidth_weaving3_item = (Label)grv.FindControl("lblwidth_weaving3_item");
//                    Label lblwidth_weaving4_item = (Label)grv.FindControl("lblwidth_weaving4_item");
//                    Label lbltotal_item = (Label)grv.FindControl("lbltotal_item");
//                    Label lblpatta_item = (Label)grv.FindControl("lblpatta_item");
//                    Label lblhole_item = (Label)grv.FindControl("lblhole_item");
//                    Label lblTotal2_item = (Label)grv.FindControl("lblTotal2_item");
//                    Label lblprintdyeingdefacts1_item = (Label)grv.FindControl("lblprintdyeingdefacts1_item");
//                    Label lblprintdyeingdefacts2_item = (Label)grv.FindControl("lblprintdyeingdefacts2_item");
//                    Label lblprintdyeingdefacts3_item = (Label)grv.FindControl("lblprintdyeingdefacts3_item");
//                    Label lblprintdyeingdefacts4_item = (Label)grv.FindControl("lblprintdyeingdefacts4_item");
//                    Label lblTotal3_item = (Label)grv.FindControl("lblTotal3_item");
//                    Label lblpointTotal_item = (Label)grv.FindControl("lblpointTotal_item");
//                    Label lblweapointyard_item = (Label)grv.FindControl("lblweapointyard_item");
//                    Label lblstatus_item = (Label)grv.FindControl("lblstatus_item");


//                    HiddenField hdnrowid = (HiddenField)grv.FindControl("hdnrowid");
//                    decimal w1 = 1;
//                    decimal w2 = 2;
//                    decimal w3 = 3;
//                    decimal w4 = 4;
//                    decimal pattamultiplier = 4;
//                    decimal holemultiplier = 4;

//                    decimal Defectsmultiplier1 = 1;
//                    decimal Defectsmultiplier2 = 2;
//                    decimal Defectsmultiplier3 = 3;
//                    decimal Defectsmultiplier4 = 4;

//                    decimal firsttotal = 0;
//                    decimal pattaholetotal = 0;
//                    decimal thridtotal = 0;

//                    decimal widths = 0;
//                    if (lblwidth_S_item.Text != "")
//                    {
//                        widths = Convert.ToDecimal(lblwidth_S_item.Text);
//                    }
//                    lbltotal_item.Text = "";
//                    lblTotal2_item.Text = "";
//                    lblTotal3_item.Text = "";
//                    lblpointTotal_item.Text = "";
//                    decimal weaving1 = (lblwidth_weaving1_item.Text == "" ? 0 : Convert.ToDecimal(lblwidth_weaving1_item.Text));
//                    decimal weaving2 = (lblwidth_weaving2_item.Text == "" ? 0 : Convert.ToDecimal(lblwidth_weaving2_item.Text));
//                    decimal weaving3 = (lblwidth_weaving3_item.Text == "" ? 0 : Convert.ToDecimal(lblwidth_weaving3_item.Text));
//                    decimal weaving4 = (lblwidth_weaving4_item.Text == "" ? 0 : Convert.ToDecimal(lblwidth_weaving4_item.Text));
//                    decimal pattaval = (lblpatta_item.Text == "" ? 0 : Convert.ToDecimal(lblpatta_item.Text));
//                    decimal holeval = (lblhole_item.Text == "" ? 0 : Convert.ToDecimal(lblhole_item.Text));
//                    firsttotal = (((weaving1 * w1) + (weaving2 * w2)) + ((weaving3) * w3) + ((weaving4) * w4));
//                    if (firsttotal <= 0)
//                    {
//                        lbltotal_item.Text = "";
//                        //txttotalqty.Text = "";
//                    }
//                    else
//                    {
//                        lbltotal_item.Text = Math.Round(firsttotal).ToString();
//                    }

//                    pattaholetotal = ((pattaval * pattamultiplier) + (holeval * holemultiplier));
//                    if (pattaholetotal <= 0)
//                    {
//                        lblTotal2_item.Text = "";
//                    }
//                    else
//                    {
//                        lblTotal2_item.Text = Math.Round(pattaholetotal).ToString();
//                    }

//                    decimal defacts1 = (lblprintdyeingdefacts1_item.Text == "" ? 0 : Convert.ToDecimal(lblprintdyeingdefacts1_item.Text));
//                    decimal defacts2 = (lblprintdyeingdefacts2_item.Text == "" ? 0 : Convert.ToDecimal(lblprintdyeingdefacts2_item.Text));
//                    decimal defacts3 = (lblprintdyeingdefacts3_item.Text == "" ? 0 : Convert.ToDecimal(lblprintdyeingdefacts3_item.Text));
//                    decimal defacts4 = (lblprintdyeingdefacts4_item.Text == "" ? 0 : Convert.ToDecimal(lblprintdyeingdefacts4_item.Text));

//                    thridtotal = ((defacts1 * (Defectsmultiplier1)) + ((defacts2 * Defectsmultiplier2)) + ((defacts3 * Defectsmultiplier3)) + ((defacts4) * Defectsmultiplier4));
//                    if (thridtotal <= 0)
//                    {
//                        lblTotal3_item.Text = "";
//                    }
//                    else
//                    {
//                        lblTotal3_item.Text = Math.Round(thridtotal).ToString();
//                    }

//                    //3 Total Points============================================================================== 
//                    decimal t1 = (lbltotal_item.Text == "" ? 0 : Convert.ToDecimal(lbltotal_item.Text));
//                    decimal t2 = (lblTotal2_item.Text == "" ? 0 : Convert.ToDecimal(lblTotal2_item.Text));
//                    decimal t3 = (lblTotal3_item.Text == "" ? 0 : Convert.ToDecimal(lblTotal3_item.Text));

//                    decimal subtotal = (t1 + t2 + t3);
//                    if (subtotal <= 0)
//                    {
//                        lblpointTotal_item.Text = "";
//                    }
//                    else
//                    {
//                        lblpointTotal_item.Text = Math.Round(subtotal).ToString();
//                    }
//                    decimal rollvalue = (lblrollno_item.Text == "" ? 0 : Convert.ToDecimal(lblrollno_item.Text));
//                    decimal ClaimedQty = (lblclaimedlength_item.Text == "" ? 0 : Convert.ToDecimal(lblclaimedlength_item.Text));   //new line 
//                    decimal actuallengh = (lblactlenght_item.Text == "" ? 0 : Convert.ToDecimal(lblactlenght_item.Text));
//                    decimal with_sw = (lblwidth_S_item.Text == "" ? 0 : Convert.ToDecimal(lblwidth_S_item.Text));
//                    if ((actuallengh) > 0 && (with_sw) > 0)
//                    {
//                        decimal finalvalues = ((subtotal * 3600) / (with_sw * actuallengh));
//                        if (finalvalues <= 0)
//                        {
//                            lblweapointyard_item.Text = "";
//                        }
//                        else
//                        {
//                            if (finalvalues <= 40)
//                            {
//                                //lblstatus_item.Text = "pass";
//                            }
//                            else
//                            {
//                                //lblstatus_item.Text = "fail";
//                            }
//                            lblweapointyard_item.Text = Math.Round(finalvalues).ToString();
//                        }
//                    }
//                    decimal tt1 = 0, tt2 = 0, tt3 = 0, tt4 = 0, tt5 = 0; // tt6 = 0;
//                    if (lbltotal_item.Text != "")
//                    {
//                        tt1 = Convert.ToDecimal(lbltotal_item.Text);
//                    }
//                    if (lblTotal2_item.Text != "")
//                    {
//                        tt2 = Convert.ToDecimal(lblTotal2_item.Text);
//                    }
//                    if (lblTotal3_item.Text != "")
//                    {
//                        tt3 = Convert.ToDecimal(lblTotal3_item.Text);
//                    }
//                    if (lblpointTotal_item.Text != "")
//                    {
//                        tt4 = Convert.ToDecimal(lblpointTotal_item.Text);
//                    }
//                    if (lblweapointyard_item.Text != "")
//                    {
//                        tt5 = Convert.ToDecimal(lblweapointyard_item.Text);
//                    }
//                    foreach (DataRow dr in dtnew.Rows)
//                    {
//                        if (dr["ID"].ToString() == hdnrowid.Value)
//                        {
//                            dr["total1"] = Math.Round(t1, 0);
//                            dr["total2"] = Math.Round(t2, 0);
//                            dr["total3"] = Math.Round(t3, 0);
//                            dr["TotalPoints"] = Math.Round(tt4, 0);
//                            dr["WeaPointsPerSquirdYards"] = Math.Round(tt5, 0);
//                            //if (dr["Statusstring"].ToString().ToLower() == "pass")
//                            //{
//                            //  dr["Status"] = 1;
//                            //  dr["Statusstring"] = "Pass";
//                            //}
//                            //else if (dr["Statusstring"].ToString().ToLower() == "fail")
//                            //{
//                            //  dr["Status"] = Convert.ToInt32(2);
//                            //  dr["Statusstring"] = "fail";
//                            //}
//                            //else
//                            //{
//                            //  dr["Status"] = Convert.ToInt32(-1);
//                            //}
//                            break;
//                        }
//                    }
//                    dtnew.AcceptChanges();
//                    dtnew.DefaultView.Sort = "ID ASC";
//                    Session["viewGrddate"] = dtnew;
//                }
//                else
//                {
//                    break;
//                }


//            }

//        }
//        public bool ValidateSRVQty()
//        {
//            Decimal ActualLength = 0;
//            Boolean res = true;

//            int i = 0;
//            for (; i < grdfourpointcheck.Rows.Count; i++)
//            {
//                if (((Label)grdfourpointcheck.Rows[i].FindControl("lblactlenght_item")) != null)
//                {
//                    if (((Label)grdfourpointcheck.Rows[i].FindControl("lblactlenght_item")).Text != "")
//                    {
//                        ActualLength = ActualLength + Convert.ToDecimal(((Label)grdfourpointcheck.Rows[i].FindControl("lblactlenght_item")).Text);
//                    }
//                }
//            }


//            if (grdfourpointcheck.Rows.Count == 0)
//            {
//                TextBox txtactlenght_emptyrow = grdfourpointcheck.Controls[0].Controls[0].FindControl("txtactlenght_emptyrow") as TextBox; ;
//                if (txtactlenght_emptyrow.Text != "")
//                {
//                    ActualLength = ActualLength + Convert.ToDecimal(txtactlenght_emptyrow.Text);
//                }
//            }
//            else
//            {
//                TextBox txtactlenght_Footer = grdfourpointcheck.FooterRow.FindControl("txtactlenght_Footer") as TextBox;
//                if (txtactlenght_Footer.Text != "")
//                {
//                    ActualLength = ActualLength + Convert.ToDecimal(txtactlenght_Footer.Text);
//                }

//            }
//            if (ActualLength > Convert.ToDecimal(lblQty.Text.Replace(",", "")))
//            {
//                res = false;
//            }
//            return res;
//        }
//        protected void btnok_Click(object sender, EventArgs e)
//        {
//            DataTable dt = fabobj.GetFabFourPointexcessqty(SupplierPoID, FourPointCheck_Id, 1, Convert.ToInt32(lblqtys.Text));
//            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('FrmWorkingOnRaisedPO.aspx');", true);

//        }
//        protected void Btncancel_Click(object sender, EventArgs e)
//        {
//            DataTable dt = fabobj.GetFabFourPointexcessqty(SupplierPoID, FourPointCheck_Id, 0, Convert.ToInt32(lblqtys.Text));
//            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('FrmWorkingOnRaisedPO.aspx');", true);

//        }
//    }
//}