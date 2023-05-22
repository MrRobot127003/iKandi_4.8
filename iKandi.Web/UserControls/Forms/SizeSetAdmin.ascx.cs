using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common.Entities;
using iKandi.BLL.CmtAdmin;
using System.Data;

namespace iKandi.Web.UserControls.Forms
{
    public partial class SizeSetAdmin : System.Web.UI.UserControl
    {
        CmtAdminController prm_cmtAdmin = new CmtAdminController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSizeSet();
            }
        }

        public void BindSizeSet()
        {
            DataTable dt = new DataTable();

            dt = prm_cmtAdmin.GetSizeSet();
            ViewState["rowCount"] = dt.Rows.Count;
            grdSizeSet.DataSource = dt;
            grdSizeSet.DataBind();

        }

        protected void GetSizeList()
        {

            List<CMTSizeAdmin> ssc = new List<CMTSizeAdmin>();
            if (Request.Form["hdntotal"] != null)
            {
                int Result = 0;
                int Total = Convert.ToInt32(Request.Params["hdntotal"].Trim());
                for (int i = 1; i <= Total; i++)
                {
                    if (!string.IsNullOrEmpty(Request.Form["Option_" + i]))
                        continue;

                    CMTSizeAdmin prm_Sizeadmin = new CMTSizeAdmin();

                    //if (!string.IsNullOrEmpty(Request.Params["Option_" + i]))
                    //    prm_Sizeadmin.SizeOption = Convert.ToInt32(Request.Params["Option_" + i]);

                    prm_Sizeadmin.SizeOption = Convert.ToInt32(i);

                    if (!string.IsNullOrEmpty(Request.Form["txtSize1_" + i]))
                        prm_Sizeadmin.Size1 = Request.Params["txtSize1_" + i].Trim();

                    if (!string.IsNullOrEmpty(Request.Params["txtSize2_" + i].Trim()))
                        prm_Sizeadmin.Size2 = Request.Params["txtSize2_" + i].Trim();

                    if (!string.IsNullOrEmpty(Request.Form["txtSize3_" + i]))
                        prm_Sizeadmin.Size3 = Request.Params["txtSize3_" + i].Trim();

                    if (!string.IsNullOrEmpty(Request.Params["txtSize4_" + i].Trim()))
                        prm_Sizeadmin.Size4 = Request.Params["txtSize4_" + i].Trim();

                    if (!string.IsNullOrEmpty(Request.Form["txtSize5_" + i]))
                        prm_Sizeadmin.Size5 = Request.Params["txtSize5_" + i].Trim();

                    if (!string.IsNullOrEmpty(Request.Params["txtSize6_" + i].Trim()))
                        prm_Sizeadmin.Size6 = Request.Params["txtSize6_" + i].Trim();

                    if (!string.IsNullOrEmpty(Request.Form["txtSize7_" + i]))
                        prm_Sizeadmin.Size7 = Request.Params["txtSize7_" + i].Trim();

                    if (!string.IsNullOrEmpty(Request.Params["txtSize8_" + i].Trim()))
                        prm_Sizeadmin.Size8 = Request.Params["txtSize8_" + i].Trim();

                    if (!string.IsNullOrEmpty(Request.Params["txtSize9_" + i].Trim()))
                        prm_Sizeadmin.Size9 = Request.Params["txtSize9_" + i].Trim();

                    if (!string.IsNullOrEmpty(Request.Params["txtSize10_" + i].Trim()))
                        prm_Sizeadmin.Size10 = Request.Params["txtSize10_" + i].Trim();

                    if (!string.IsNullOrEmpty(Request.Params["txtSize11_" + i].Trim()))
                        prm_Sizeadmin.Size11 = Request.Params["txtSize11_" + i].Trim();

                    if (!string.IsNullOrEmpty(Request.Params["txtSize12_" + i].Trim()))
                        prm_Sizeadmin.Size12 = Request.Params["txtSize12_" + i].Trim();

                    if (!string.IsNullOrEmpty(Request.Params["txtSize13_" + i].Trim()))
                        prm_Sizeadmin.Size13 = Request.Params["txtSize13_" + i].Trim();

                    if (!string.IsNullOrEmpty(Request.Params["txtSize14_" + i].Trim()))
                        prm_Sizeadmin.Size14 = Request.Params["txtSize14_" + i].Trim();

                    if (!string.IsNullOrEmpty(Request.Params["txtSize15_" + i].Trim()))
                        prm_Sizeadmin.Size15 = Request.Params["txtSize15_" + i].Trim();


                    ssc.Add(prm_Sizeadmin);


                }
                Result = prm_cmtAdmin.InsertSizeSet(ssc);

                BindSizeSet();
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetSizeList();
        }

        protected void grdSizeSet_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.RowIndex % Convert.ToInt32(ViewState["rowCount"].ToString()) == 0)
                {
                    e.Row.Cells[2].Attributes.Add("rowspan", ViewState["rowCount"].ToString());

                }
                else
                {
                    e.Row.Cells[2].Visible = false;
                }

            }
        }

        protected void grdSizeSet_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}