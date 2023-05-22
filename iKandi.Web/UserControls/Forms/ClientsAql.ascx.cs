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
using System.Collections.Generic;

namespace iKandi.Web
{
    public partial class ClientsAql : BaseUserControl
    {
        #region fields

        DataSet dsClientsAql = null;
        DataTable dtClientsAql = null;
        int totalClients = 0;
        int totalUnits = 0;
        DataRowCollection clientRows;
        DataRowCollection clientUnitRows;
        DataRowCollection unitRows;


        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            string eventTarget = (this.Request["__EVENTTARGET"] == null) ? string.Empty : this.Request["__EVENTTARGET"];
            if (eventTarget.Contains("id1"))
            {
                CheckBox1_CheckedChanged(sender, new EventArgs());
            }
            if (!Page.IsPostBack)
            {
                BindControls();
            }
        }

        private void AssignMethod()
        {
            foreach (GridViewRow row in grdClientsAQL.Rows)
            {
                if (row.RowType == DataControlRowType.Header)
                {
                    CheckBox chk = (CheckBox)row.FindControl("id1");
                }
            }
        }

        protected void grdClientsAQL_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //for (int i = 1; i < e.Row.Cells.Count; i = i + 1)
                //{
                DataSet ds = (DataSet)ViewState["AllTable"];
                Label lbl1 = new Label();
                lbl1.ID = "lbl1";
                lbl1.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                Label lbl2 = new Label();
                lbl2.ID = "lbl2";
                lbl2.Text = ds.Tables[0].Rows[1]["Name"].ToString();
                Label lbl3 = new Label();
                lbl3.ID = "lbl3";
                lbl3.Text = ds.Tables[0].Rows[2]["Name"].ToString();
                Label lbl4 = new Label();
                lbl4.ID = "lbl4";
                lbl4.Text = ds.Tables[0].Rows[3]["Name"].ToString();
                Label lbl5 = new Label();
                lbl5.ID = "lbl5";
                lbl5.Text = ds.Tables[0].Rows[4]["Name"].ToString();
                Label lbl6 = new Label();
                lbl6.ID = "lbl6";
                lbl6.Text = ds.Tables[0].Rows[5]["Name"].ToString();
                Label lbl7 = new Label();
                lbl7.ID = "lbl7";
                lbl7.Text = ds.Tables[0].Rows[6]["Name"].ToString();
                Label lbl8 = new Label();
                lbl8.ID = "lbl8";
                lbl8.Text = ds.Tables[0].Rows[7]["Name"].ToString();
                Label lbl9 = new Label();
                lbl9.ID = "lbl9";
                lbl9.Text = ds.Tables[0].Rows[8]["Name"].ToString();

                CheckBox chk1 = new CheckBox();
                chk1.ID = "id1";
                // chk1.AutoPostBack = true;
                chk1.Attributes["onclick"] = string.Format
                                          (
                                             "javascript:ChildClick(this,'{0}');",
                                             chk1.ClientID
                                          );
                CheckBox chk2 = new CheckBox();
                chk2.ID = "id2";
                chk2.Attributes["onclick"] = string.Format
                                         (
                                            "javascript:ChildClick(this,'{0}');",
                                             chk2.ClientID
                                         );
                CheckBox chk3 = new CheckBox();
                chk3.ID = "id3";
                chk3.Attributes["onclick"] = string.Format
                                          (
                                             "javascript:ChildClick(this,'{0}');",
                                              chk3.ClientID
                                          );
                CheckBox chk4 = new CheckBox();
                chk4.ID = "id4";
                chk4.Attributes["onclick"] = string.Format
                                          (
                                             "javascript:ChildClick(this,'{0}');",
                                              chk4.ClientID
                                          );
                CheckBox chk5 = new CheckBox();
                chk5.ID = "id5";
                chk5.Attributes["onclick"] = string.Format
                                         (
                                            "javascript:ChildClick(this,'{0}');",
                                             chk5.ClientID
                                         );
                CheckBox chk6 = new CheckBox();
                chk6.ID = "id6";
                chk6.Attributes["onclick"] = string.Format
                                          (
                                             "javascript:ChildClick(this,'{0}');",
                                              chk6.ClientID
                                          );
                CheckBox chk7 = new CheckBox();
                chk7.ID = "id7";
                chk7.Attributes["onclick"] = string.Format
                                          (
                                             "javascript:ChildClick(this,'{0}');",
                                              chk7.ClientID
                                          );
               
                CheckBox chk8 = new CheckBox();
                chk8.ID = "id8";
                chk8.Attributes["onclick"] = string.Format
                                          (
                                             "javascript:ChildClick(this,'{0}');",
                                              chk8.ClientID
                                          );
            
                CheckBox chk9 = new CheckBox();
                chk9.ID = "id9";
                chk9.Attributes["onclick"] = string.Format
                                          (
                                             "javascript:ChildClick(this,'{0}');",
                                              chk9.ClientID
                                          );
              

                e.Row.Cells[0].Attributes.Add("style", "text-align:left");
                e.Row.Cells[1].Controls.Add(chk1);
                e.Row.Cells[1].Controls.Add(lbl1);
                e.Row.Cells[2].Controls.Add(chk2);
                e.Row.Cells[2].Controls.Add(lbl2);
                e.Row.Cells[3].Controls.Add(chk3);
                e.Row.Cells[3].Controls.Add(lbl3);
                e.Row.Cells[4].Controls.Add(chk4);
                e.Row.Cells[4].Controls.Add(lbl4);
                e.Row.Cells[5].Controls.Add(chk5);
                e.Row.Cells[5].Controls.Add(lbl5);
                e.Row.Cells[6].Controls.Add(chk6);
                e.Row.Cells[6].Controls.Add(lbl6);
                e.Row.Cells[7].Controls.Add(chk7);
                e.Row.Cells[7].Controls.Add(lbl7);
                e.Row.Cells[8].Controls.Add(chk8);
                e.Row.Cells[8].Controls.Add(lbl8);
                e.Row.Cells[9].Controls.Add(chk9);
                e.Row.Cells[9].Controls.Add(lbl9);
                //}

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Cells[0].CssClass = "column_color text_align_left font_color_blue";
            





                String UnitID = "-1";
                String ClientID = "-1";
                e.Row.Cells[0].Attributes.Add("style", "text-align:left");
                string divTag = "<div>";
                divTag += "<div style='float:left'>";
                divTag += e.Row.Cells[0].Text;
                divTag += "</div>";
                divTag += "<div style='float:right'>";
                int index = e.Row.RowIndex + 1;
                string chkName = "rchk" + index;
                divTag += "<input type='checkbox' name='" + chkName + "' id='" + chkName + "'";
                divTag += " onclick=\"javascript:SelectAllCol('" + chkName + "'," + index + ");\" />";
                divTag += "</div>";
                divTag += "</div>";
                e.Row.Cells[0].Text = divTag;







                for (int i = 1; i < e.Row.Cells.Count; i = i + 1)
                {
                    UnitID = unitRows[i - 1]["Id"].ToString();

                    ClientID = clientRows[e.Row.RowIndex]["ClientId"].ToString();

                    HtmlInputHidden hidClientID = new HtmlInputHidden();
                    hidClientID.Value = ClientID;
                    hidClientID.ID = "hdnClientID" + (e.Row.RowIndex).ToString() + (i).ToString();
                    hidClientID.Name = "hdnClientID" + (e.Row.RowIndex).ToString() + (i).ToString();
                    e.Row.Cells[i].Controls.Add(hidClientID);

                    HtmlInputHidden hidUnitID = new HtmlInputHidden();
                    hidUnitID.Value = UnitID;
                    hidUnitID.ID = "hdnUnitID" + (e.Row.RowIndex).ToString() + (i).ToString();
                    hidUnitID.Name = "hdnUnitID" + (e.Row.RowIndex).ToString() + (i).ToString();
                    e.Row.Cells[i].Controls.Add(hidUnitID);

                    string str1 = "ClientID =" + ClientID + " and UnitID=" + UnitID; ;
                    DataRow[] dr1 = dsClientsAql.Tables[2].Select(str1);

                    HtmlSelect ddl = new HtmlSelect();
                    ddl.ID = "ddl" + (e.Row.RowIndex).ToString() + (i).ToString();
                    ddl.Name = "ddl" + (e.Row.RowIndex).ToString() + (i).ToString();
                    Bindddl(ddl, Convert.ToInt32(ClientID));
                    // ddl.Items.Add(new ListItem("1.5", "1.5"));
                    // ddl.Items.Add(new ListItem("2.5", "2.5"));
                    ddl.Style.Add("width", "50px");
                    if (dr1.Length > 0)
                        if (dr1[0]["AQLValue"].ToString() == "4")
                        {
                            ddl.Value = "4.0";
                        }
                        else
                        {
                            ddl.Value = (dr1[0]["AQLValue"] == DBNull.Value) ? "2.5" : (dr1[0]["AQLValue"].ToString());
                        }
                        else
                            ddl.Value = "2.5";
                    e.Row.Cells[i].Controls.Add(ddl);
                }
            }
        }
        protected void chk1_CheckedChanged(object sender, EventArgs e)
        {
            // CheckBox box = (CheckBox)sender;

            //    
            //    DataGridItem container = (DataGridItem) box.NamingContainer;

            //    // get our values
            //    sqlUpdateCommand1.Parameters["@Object_id"].Value
            //                                = int.Parse(container.Cells[0].Text);
            //    sqlUpdateCommand1.Parameters["@Boolean"].Value = box.Checked;

            //...

        }
        //public void Bindddl(HtmlSelect ddl)
        //{
        //    ddl.DataSource = this.QualityControllerInstance.GetAllAqlStanderdBAL();
        //    ddl.DataTextField = "AQLType";
        //    ddl.DataValueField = "AQLType";
        //    ddl.DataBind();
        //}
        public void Bindddl(HtmlSelect ddl, int ClientID)
        {
            ddl.DataSource = this.QualityControllerInstance.GetAllAqlStanderdBAL(ClientID);
            ddl.DataTextField = "AQLType";
            ddl.DataValueField = "AQLType";
            ddl.DataBind();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;
            SaveClientAQL();
        }

        #endregion

        #region Private Methods

        public void BindControls()
        {
            dsClientsAql = this.AdminControllerInstance.GetClientsAQL();
            ViewState["AllTable"] = dsClientsAql;
            dtClientsAql = new DataTable();

            totalClients = dsClientsAql.Tables[1].Rows.Count;
            unitRows = dsClientsAql.Tables[0].Rows;
            clientRows = dsClientsAql.Tables[1].Rows;
            clientUnitRows = dsClientsAql.Tables[2].Rows;

            if (dsClientsAql.Tables[1].Rows.Count == 0)
                return;

            if (dsClientsAql.Tables.Count > 0 && dsClientsAql.Tables[0].Rows.Count > 0)
            {
                totalUnits = dsClientsAql.Tables[0].Rows.Count;
            }

            dtClientsAql.Columns.Add("Client\\Unit");

            for (int i = 0; i < totalUnits; i++)
            {
                String unitName = dsClientsAql.Tables[0].Rows[i]["Name"].ToString();
                dtClientsAql.Columns.Add(unitName);
            }

            for (int rows = 0; rows < totalClients; rows++)
            {
                DataRow drClientsAql = dtClientsAql.NewRow();

                for (int i = 0; i < totalUnits; i++)
                {
                    string str1 = "ClientID =" + clientRows[rows]["ClientId"];
                    DataRow[] dr1 = dsClientsAql.Tables[1].Select(str1);

                    if (dr1.Length > 0)
                    {
                        drClientsAql["Client\\Unit"] = dr1[0]["CompanyName"].ToString();
                    }
                }

                dtClientsAql.Rows.Add(drClientsAql);
            }

            grdClientsAQL.DataSource = dtClientsAql;
            grdClientsAQL.DataBind();
        }

        public void SaveClientAQL()
        {
            //System.Diagnostics.Debugger.Break();
            List<ClientAQL> clientsAQL = new List<ClientAQL>();

            foreach (GridViewRow row in grdClientsAQL.Rows)
            {
                for (int i = 1; i < row.Cells.Count; i++)
                {
                    ClientAQL cAql = new ClientAQL();

                    for (int j = 0; j < Request.Params.AllKeys.Length; j++)
                    {
                        if (Request.Params.AllKeys[j].EndsWith("hdnUnitID" + (row.RowIndex).ToString() + i.ToString()))
                            cAql.UnitID = Convert.ToInt32(Request.Params[Request.Params.AllKeys[j]]);
                        if (Request.Params.AllKeys[j].EndsWith("hdnClientID" + (row.RowIndex).ToString() + i.ToString()))
                            cAql.ClientID = Convert.ToInt32(Request.Params[Request.Params.AllKeys[j]]);
                        if (Request.Params.AllKeys[j].EndsWith("ddl" + (row.RowIndex).ToString() + i.ToString()))
                            cAql.AQLValue = Request.Params[Request.Params.AllKeys[j]];
                    }

                    if (cAql.UnitID > 0 && cAql.ClientID > 0 && !string.IsNullOrEmpty(cAql.AQLValue))
                        clientsAQL.Add(cAql);
                }
            }

            if (clientsAQL.Count > 0)
                this.AdminControllerInstance.InsertClientsAQL(clientsAQL);

            BindControls();

        }

        #endregion

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}