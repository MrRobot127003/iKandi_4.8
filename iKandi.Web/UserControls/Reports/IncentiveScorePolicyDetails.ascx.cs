using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.Data;

namespace iKandi.Web.UserControls.Reports
{
    public partial class IncentiveScorePolicyDetails : System.Web.UI.UserControl
    {
        AdminController objadmin = new AdminController();
        CommonController objCommon = new CommonController();
        DateTime CommonDate;

        protected void Page_Load(object sender, EventArgs e)
        {
            CommonDate = objCommon.GetCommonRptDateOnPage();
            if (CommonDate.Day == 1)
            {
                CommonDate = CommonDate.AddDays(-1);
            }
            BindIncentiveScore();
        }
        protected void BindIncentiveScore()
        {
            DataSet dsIncentiveScore = new DataSet();
            dsIncentiveScore = objadmin.GetIncentiveScore();
            DataTable dtIncentiveScore = dsIncentiveScore.Tables[1];

            int Rows = dtIncentiveScore.Rows.Count;
            string str = "";

            str = "<table cellpadding='0' cellspacing='0' style='width:750px;' class='AddClass_Table' border='0'><tr><th colspan='6' style='font-size: 12px !important;border-right:1px solid gray !important;'>KPI Score (" + CommonDate.ToString("MMMM yyyy") + ")</th></tr>";
            str = str + "<tr><th style='width:80px' >Unit</th> <th >Policy 1 (Cutting)</th>  <th >Policy 2 (Stitching)</th> <th>Policy 3 (Floor Incharge/ FM/IE Dept)</th> <th >Policy 4 (Finishing)</th> <th >Policy 5 (CQDs)</th></tr>";            
            for (int j = 0; j < Rows; j++)
            {
                if (dtIncentiveScore.Rows[j]["Unit"].ToString() == "BIPL")
                    str = str + "<tr style='background: #c7d4f5;'>";
                else
                    str = str + "<tr>";
                if (dtIncentiveScore.Rows[j]["Unit"].ToString() == "C 45-46")
                    str = str + "<td style='background: #DDDFE4;'>" + dtIncentiveScore.Rows[j]["Unit"].ToString() + "</td>";
                else if (dtIncentiveScore.Rows[j]["Unit"].ToString() == "C 47")
                    str = str + "<td style='background: #DDDFE4;'>" + dtIncentiveScore.Rows[j]["Unit"].ToString() + "</td>";
                //else if (dtIncentiveScore.Rows[j]["Unit"].ToString() == "D 169")
                //    str = str + "<td style='background: #DDDFE4;'>" + dtIncentiveScore.Rows[j]["Unit"].ToString() + "</td>";
                //else if (dtIncentiveScore.Rows[j]["Unit"].ToString() == "C 52")
                //    str = str + "<td style='background: #DDDFE4;'>" + dtIncentiveScore.Rows[j]["Unit"].ToString() + "</td>";
                else
                    str = str + "<td>" + dtIncentiveScore.Rows[j]["Unit"].ToString() + "</td>";

                if (dtIncentiveScore.Rows[j]["Policy4_Cutting"] != DBNull.Value && Convert.ToInt32(dtIncentiveScore.Rows[j]["Policy4_Cutting"]) != 0)
                    str = str + "<td>" + dtIncentiveScore.Rows[j]["Policy4_Cutting"].ToString() + "%" + "</td>";
                else
                    str = str + "<td></td>";

                if (dtIncentiveScore.Rows[j]["Policy5_Stitching"] != DBNull.Value && Convert.ToInt32(dtIncentiveScore.Rows[j]["Policy5_Stitching"]) != 0)
                    str = str + "<td>" + dtIncentiveScore.Rows[j]["Policy5_Stitching"].ToString() + "%" + "</td>";
                else
                    str = str + "<td></td>";


                if (dtIncentiveScore.Rows[j]["Policy6_FIFMIE"] != DBNull.Value && Convert.ToInt32(dtIncentiveScore.Rows[j]["Policy6_FIFMIE"]) != 0)
                    str = str + "<td>" + dtIncentiveScore.Rows[j]["Policy6_FIFMIE"].ToString() + "%" + "</td>";
                else
                    str = str + "<td></td>";

                if (dtIncentiveScore.Rows[j]["Policy7_Finishing"] != DBNull.Value && Convert.ToInt32(dtIncentiveScore.Rows[j]["Policy7_Finishing"]) != 0)
                    str = str + "<td>" + dtIncentiveScore.Rows[j]["Policy7_Finishing"].ToString() + "%" + "</td>";
                else
                    str = str + "<td></td>";

                if (dtIncentiveScore.Rows[j]["Policy8_CQD"] != DBNull.Value && Convert.ToInt32(dtIncentiveScore.Rows[j]["Policy8_CQD"]) != 0)
                    str = str + "<td>" + dtIncentiveScore.Rows[j]["Policy8_CQD"].ToString() + "%" + "</td>";
                else
                    str = str + "<td></td>";


                //if (dtIncentiveScore.Rows[j]["Policy9_Linemen"] != DBNull.Value && Convert.ToInt32(dtIncentiveScore.Rows[j]["Policy9_Linemen"]) != 0)
                //    str = str + "<td>" + dtIncentiveScore.Rows[j]["Policy9_Linemen"].ToString() + "%" + "</td>";
                //else
                //    str = str + "<td></td>";

                //if (dtIncentiveScore.Rows[j]["Policy10_QC"] != DBNull.Value && Convert.ToInt32(dtIncentiveScore.Rows[j]["Policy10_QC"]) != 0)
                //    str = str + "<td>" + dtIncentiveScore.Rows[j]["Policy10_QC"].ToString() + "%" + "</td>";
                //else
                //    str = str + "<td></td>";                               

                str = str + "</tr>";
            }
            str = str + "</table>";
            IncentiveScorePolicyDetail.InnerHtml = str;
        }
    }
}