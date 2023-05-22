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
    public partial class MonthlyProductionDetails : System.Web.UI.UserControl
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
            BindTable();
        }

        protected void BindTable()
        {
            DataSet dsProductionDetails = new DataSet();
            dsProductionDetails = objadmin.GetProductionDetails("Monthly");
            DataTable dtProductionDetails = dsProductionDetails.Tables[0];

            int Rows = dtProductionDetails.Rows.Count;
            string str = "";

            str = "<table cellpadding='0' cellspacing='0' style='width:750px;' class='AddClass_Table' border='0'><tr><th colspan='14' style='font-size: 12px !important;border-right:1px solid gray !important;'>Monthly Production Details (" + CommonDate.ToString("MMMM yyyy") + ")</th></tr>";
            str = str + "<tr><th style='width:80px' rowspan='2'>Unit</th> <th colspan='3'>Cutting</th>  <th colspan='3'>Stitching</th> <th colspan='2'>Finishing</th> <th rowspan='2'>CQD Pass</th> <th rowspan='2'>Fault Packed</th> <th rowspan='2'>Rescan</th> <th rowspan='2'>Quality Audit</th> <th rowspan='2'>Compliance Audit</th> </tr>";
            str = str + "<tr><th  style='width:60px'>Rate</th><th  style='width:60px'>Qty.</th><th style='width:60px'>Fabric Avg. Saving</th><th>Achievement</th><th>Efficiency</th><th style='width:60px'>Qty.</th><th style='width:60px'>Rate</th><th style='width:60px'>Qty.</th></tr>";
            for (int j = 0; j < Rows; j++)
            {
                if (dtProductionDetails.Rows[j]["Unit"].ToString() == "BIPL")
                    str = str + "<tr style='background: #c7d4f5;'>";
                else
                    str = str + "<tr>";
                if (dtProductionDetails.Rows[j]["Unit"].ToString() == "C 45-46")
                    str = str + "<td style='background: #DDDFE4;'>" + dtProductionDetails.Rows[j]["Unit"].ToString() + "</td>";
                else if (dtProductionDetails.Rows[j]["Unit"].ToString() == "C 47")
                    str = str + "<td style='background: #DDDFE4;'>" + dtProductionDetails.Rows[j]["Unit"].ToString() + "</td>";
                //else if (dtProductionDetails.Rows[j]["Unit"].ToString() == "D 169")
                //    str = str + "<td style='background: #DDDFE4;'>" + dtProductionDetails.Rows[j]["Unit"].ToString() + "</td>";
                //else if (dtProductionDetails.Rows[j]["Unit"].ToString() == "C 52")
                //    str = str + "<td style='background: #DDDFE4;'>" + dtProductionDetails.Rows[j]["Unit"].ToString() + "</td>";
                else
                    str = str + "<td>" + dtProductionDetails.Rows[j]["Unit"].ToString() + "</td>";

                if (dtProductionDetails.Rows[j]["CutRate"] != DBNull.Value && Convert.ToInt32(dtProductionDetails.Rows[j]["CutRate"]) != 0)
                    str = str + "<td>" + dtProductionDetails.Rows[j]["CutRate"].ToString() + "</td>";
                else
                    str = str + "<td></td>";
                string CutTy = dtProductionDetails.Rows[j]["CutQty"].ToString();
                string CutQTy = "";
                if (CutTy != "0 k" && CutTy != "")
                {
                    CutQTy = dtProductionDetails.Rows[j]["CutQty"].ToString();
                }
                else
                {
                    CutQTy = "";
                }
                str = str + "<td>" + CutQTy + "</td>";
                //added by raghvinder on 04-03-2020 start
                if (dtProductionDetails.Rows[j]["FabricSaving"] != DBNull.Value && Convert.ToDecimal(dtProductionDetails.Rows[j]["FabricSaving"]) != 0)
                    str = str + "<td>" + Math.Round(Convert.ToDecimal(dtProductionDetails.Rows[j]["FabricSaving"]), 1).ToString() + "%" + "</td>";
                else
                    str = str + "<td></td>";
                //added by raghvinder on 04-03-2020 end

                if (dtProductionDetails.Rows[j]["Achievement"] != DBNull.Value && Convert.ToInt32(dtProductionDetails.Rows[j]["Achievement"]) != 0)
                    str = str + "<td>" + dtProductionDetails.Rows[j]["Achievement"].ToString() + "%" + "</td>";
                else
                    str = str + "<td></td>";

                if (dtProductionDetails.Rows[j]["StitchingEfficiency"] != DBNull.Value && Convert.ToInt32(dtProductionDetails.Rows[j]["StitchingEfficiency"]) != 0)
                    str = str + "<td>" + dtProductionDetails.Rows[j]["StitchingEfficiency"].ToString() + "%" + "</td>";
                else
                    str = str + "<td></td>";
                string stiqty = dtProductionDetails.Rows[j]["StitchedQty"].ToString();
                string stitchQty = "";
                if (stiqty != "0 k" && stiqty != "")
                {
                    stitchQty = dtProductionDetails.Rows[j]["StitchedQty"].ToString();
                }
                else
                {
                    stitchQty = "";
                }
                str = str + "<td>" + stitchQty + "</td>";


                if (dtProductionDetails.Rows[j]["FinishedRate"] != DBNull.Value && Convert.ToInt32(dtProductionDetails.Rows[j]["FinishedRate"]) != 0)
                    str = str + "<td>" + dtProductionDetails.Rows[j]["FinishedRate"].ToString() + "</td>";
                else
                    str = str + "<td></td>";
                string FinQty = dtProductionDetails.Rows[j]["FinishedQty"].ToString();
                string FiniQty = "";
                if (FinQty != "0 k" && FinQty != "")
                {
                    FiniQty = dtProductionDetails.Rows[j]["FinishedQty"].ToString();
                }
                else
                {
                    FiniQty = "";
                }
                str = str + "<td>" + FiniQty + "</td>";


                if (Convert.ToInt32(dtProductionDetails.Rows[j]["CQDPass"]) != 0)
                    str = str + "<td>" + dtProductionDetails.Rows[j]["CQDPass"].ToString() + "%" + "</td>";
                else
                    str = str + "<td></td>";

                if (dtProductionDetails.Rows[j]["FaultsPacked"] != DBNull.Value)
                    str = str + "<td>" + dtProductionDetails.Rows[j]["FaultsPacked"].ToString() + "%" + "</td>";
                else
                    str = str + "<td></td>";

                if (dtProductionDetails.Rows[j]["Rescan"] != DBNull.Value)
                    str = str + "<td>" + dtProductionDetails.Rows[j]["Rescan"].ToString() + "%" + "</td>";
                else
                    str = str + "<td></td>";

                if (Convert.ToInt32(dtProductionDetails.Rows[j]["QualityAudit"]) != 0)
                    str = str + "<td>" + dtProductionDetails.Rows[j]["QualityAudit"].ToString() + "%" + "</td>";
                else
                    str = str + "<td></td>";

                if (Convert.ToInt32(dtProductionDetails.Rows[j]["ComplianceAudit"]) != 0)
                    str = str + "<td>" + dtProductionDetails.Rows[j]["ComplianceAudit"].ToString() + "%" + "</td>";
                else
                    str = str + "<td></td>";

                str = str + "</tr>";
            }
            str = str + "</table>";
            MonthlyProductionDetail.InnerHtml = str;
        }

    }
}