using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using iTextSharp.text.html;

namespace iKandi.Web
{
    public partial class DeparmentWiseIncentive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                CuttingIncentive();
                StitchingIncentive();
                FloorInchargeIncentive();
                FinishingIncentive();
                CQDIncentive();
                LinemenIncentive();
                QCsIncentive();
            }
        }

        protected void CuttingIncentive()
        {


            StringBuilder CuttingInSB = new StringBuilder();

            CuttingInSB.Append("<table border='0' cellspacing='0' cellpadding='0' class='CommoAdmin_Table'>");
            CuttingInSB.Append("<tr>");
            CuttingInSB.Append("<th colspan='4' style=' background: #e4e2e2; border: 1px solid #dbd8d8; border-collapse: collapse; font-size: 11px; font-weight: 500; padding: 3px 3px;text-align:center; color: #575759;'><b style='color:#000'>Policy 1. Cutting </b><br> (Incharge-Cutting, Executive-Cutting, Q.A.-Cutting, Master-Cutting, Cad Operator-Cutting, Assistant Cutting, Supervisor-Sticker, Supervisor-Cutting)</th>");
            CuttingInSB.Append("</tr>");
            CuttingInSB.Append("<tr>");

            CuttingInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'></td>");
            CuttingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>100%</td>");
            CuttingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>0%</td>");
            CuttingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Weight</td>");
            CuttingInSB.Append("</tr>");



            CuttingInSB.Append("<tr>");
            CuttingInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Cutting</td>");
            CuttingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>3.5</td>");
            CuttingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>6.5</td>");
            CuttingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>80%</td>");
            CuttingInSB.Append("</tr>");

            CuttingInSB.Append("<tr>");
            CuttingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Avg. Saving</td>");
            CuttingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>5%</td>");
            CuttingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>0%</td>");
            CuttingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>20%</td>");
            CuttingInSB.Append("</tr>");

            CuttingInSB.Append("<tr>");
            CuttingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'><b>Capacity</b></td>");
            CuttingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>125,000</td>");
            CuttingInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'><b>Actual</b></td>");
            CuttingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'></td>");
            CuttingInSB.Append("</tr>");

            CuttingInSB.Append("</table>");

            CuttingInCentiveid.InnerHtml = CuttingInSB.ToString();

        }


        protected void StitchingIncentive()
        {


            StringBuilder StitchingInSB = new StringBuilder();

            StitchingInSB.Append("<table border='0' cellspacing='0' cellpadding='0' class='CommoAdmin_Table'>");
            StitchingInSB.Append("<tr>");
            StitchingInSB.Append("<th colspan='4' style=' background: #e4e2e2; border: 1px solid #dbd8d8; border-collapse: collapse; font-size: 11px; font-weight: 500; padding: 3px 3px;text-align:center; color: #575759;'><b style='color:#000'>Policy 2. Stitching </b><br> (Incharge R&D, Designer-Embroidery, Master-Washing, Supervisor-Flat, Assistant-Sharp Tools, Incharge-Kaj Button, Assistant-Issue & Receiving, Supervisor-Dummies, Supervisor-TOP,  Supervisor-Outhouse, Assistant -Part Change, Assistant Supervisor-Flat, Incharge-Stitching, Assistant-Stitching.)</th>");
            StitchingInSB.Append("</tr>");
            StitchingInSB.Append("<tr>");

            StitchingInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'></td>");
            StitchingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>100%</td>");
            StitchingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>0%</td>");
            StitchingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Weight</td>");
            StitchingInSB.Append("</tr>");



            StitchingInSB.Append("<tr>");
            StitchingInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Achievement</td>");
            StitchingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>90%</td>");
            StitchingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>70%</td>");
            StitchingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>80%</td>");
            StitchingInSB.Append("</tr>");

            StitchingInSB.Append("<tr>");
            StitchingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Quality Audit</td>");
            StitchingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>100%</td>");
            StitchingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>80%</td>");
            StitchingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>10%</td>");
            StitchingInSB.Append("</tr>");

            StitchingInSB.Append("<tr>");
            StitchingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Compliance Audit</td>");
            StitchingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>100%</td>");
            StitchingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>80%</td>");
            StitchingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>10%</td>");
            StitchingInSB.Append("</tr>");

            StitchingInSB.Append("<tr>");
            StitchingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Rescan (Limiting)</td>");
            StitchingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>-15%</td>");
            StitchingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>0%</td>");
            StitchingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>15%</td>");
            StitchingInSB.Append("</tr>");


            StitchingInSB.Append("<tr>");
            StitchingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'><b>Capacity</b></td>");
            StitchingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>125,000</td>");
            StitchingInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'><b>Actual</b></td>");
            StitchingInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'></td>");
            StitchingInSB.Append("</tr>");

            StitchingInSB.Append("</table>");

            StitchingInSBInCentiveid.InnerHtml = StitchingInSB.ToString();

        }

        protected void FloorInchargeIncentive()
        {


            StringBuilder FloorInchargeInSB = new StringBuilder();

            FloorInchargeInSB.Append("<table border='0' cellspacing='0' cellpadding='0' class='CommoAdmin_Table'>");
            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<th colspan='4' style=' background: #e4e2e2; border: 1px solid #dbd8d8; border-collapse: collapse; font-size: 11px; font-weight: 500; padding: 3px 3px;text-align:center; color: #575759;'><b style='color:#000'>Policy 3. Floor Incharge/ FM/IE Dept.</b><br> (Manager-Factory, Manager-Stitching, Sr. Executive-I.E, Executive-I.E, Time Study Analyst.)</th>");
            FloorInchargeInSB.Append("</tr>");
            FloorInchargeInSB.Append("<tr>");

            FloorInchargeInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'></td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>100%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>0%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Weight</td>");
            FloorInchargeInSB.Append("</tr>");

            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Cutting</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>4.5</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>6.5</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>10%</td>");
            FloorInchargeInSB.Append("</tr>");

            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Achievement</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>90%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>70%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>60%</td>");
            FloorInchargeInSB.Append("</tr>");

            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Finish Rate</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>16</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>21</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>20%</td>");
            FloorInchargeInSB.Append("</tr>");

            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Quality Audit</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>100%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>80%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>5%</td>");
            FloorInchargeInSB.Append("</tr>");

            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Compliance Audit</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>100%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>80%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>5%</td>");
            FloorInchargeInSB.Append("</tr>");

            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Rescan (Limiting)</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>-15%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>0%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>15%</td>");
            FloorInchargeInSB.Append("</tr>");


            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'><b>Capacity</b></td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>125,000</td>");
            FloorInchargeInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'><b>Actual</b></td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'></td>");
            FloorInchargeInSB.Append("</tr>");

            FloorInchargeInSB.Append("</table>");

            FloorInchargeInCentiveid.InnerHtml = FloorInchargeInSB.ToString();

        }

        protected void FinishingIncentive()
        {


            StringBuilder FloorInchargeInSB = new StringBuilder();

            FloorInchargeInSB.Append("<table border='0' cellspacing='0' cellpadding='0' class='CommoAdmin_Table'>");
            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<th colspan='4' style=' background: #e4e2e2; border: 1px solid #dbd8d8; border-collapse: collapse; font-size: 11px; font-weight: 500; padding: 3px 3px;text-align:center; color: #575759;'><b style='color:#000'>Policy 4. Finishing</b><br> (Incharge-Finishing, Supervisor-Touching, Supervisor-Finishing, Incharge-Packing, Supervisor-Packing, Assistant-Touching)</th>");
            FloorInchargeInSB.Append("</tr>");
            FloorInchargeInSB.Append("<tr>");

            FloorInchargeInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'></td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>100%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>0%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Weight</td>");
            FloorInchargeInSB.Append("</tr>");

            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Finishing</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>16</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>21</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>100%</td>");
            FloorInchargeInSB.Append("</tr>");

            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Rescan (Limiting)</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>-15%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>0%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>15%</td>");
            FloorInchargeInSB.Append("</tr>");

            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'><b>Capacity</b></td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>125,000</td>");
            FloorInchargeInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'><b>Actual</b></td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'></td>");
            FloorInchargeInSB.Append("</tr>");

            FloorInchargeInSB.Append("</table>");

            FinishingInCentiveid.InnerHtml = FloorInchargeInSB.ToString();

        }

        protected void CQDIncentive()
        {


            StringBuilder FloorInchargeInSB = new StringBuilder();

            FloorInchargeInSB.Append("<table border='0' cellspacing='0' cellpadding='0' class='CommoAdmin_Table'>");
            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<th colspan='4' style=' background: #e4e2e2; border: 1px solid #dbd8d8; border-collapse: collapse; font-size: 11px; font-weight: 500; padding: 3px 3px;text-align:center; color: #575759;'><b style='color:#000'>Policy 5. CQDs</b><br> (CQD)</th>");
            FloorInchargeInSB.Append("</tr>");
            FloorInchargeInSB.Append("<tr>");

            FloorInchargeInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'></td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>100%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>0%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Weight</td>");
            FloorInchargeInSB.Append("</tr>");

       

            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Rescan (Limiting)</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>40%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>0%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>100%</td>");
            FloorInchargeInSB.Append("</tr>");

            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Total</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'></td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'></td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'></td>");
            FloorInchargeInSB.Append("</tr>");

            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'><b>Capacity</b></td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>125,000</td>");
            FloorInchargeInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'><b>Actual</b></td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'></td>");
            FloorInchargeInSB.Append("</tr>");

            FloorInchargeInSB.Append("</table>");

            CQDIInCentiveid.InnerHtml = FloorInchargeInSB.ToString();

        }

        protected void LinemenIncentive()
        {


            StringBuilder FloorInchargeInSB = new StringBuilder();

            FloorInchargeInSB.Append("<table border='0' cellspacing='0' cellpadding='0' class='CommoAdmin_Table'>");
            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<th colspan='4' style=' background: #e4e2e2; border: 1px solid #dbd8d8; border-collapse: collapse; font-size: 11px; font-weight: 500; padding: 3px 3px;text-align:center; color: #575759;'><b style='color:#000'>Policy 6.  Linemen</b><br> (Line-Man, Assistant Lineman.)</th>");
            FloorInchargeInSB.Append("</tr>");
            FloorInchargeInSB.Append("<tr>");

            FloorInchargeInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'></td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>100%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>0%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Weight</td>");
            FloorInchargeInSB.Append("</tr>");

            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Achievement</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>100%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>60%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>65%</td>");
            FloorInchargeInSB.Append("</tr>");

            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Quality Audit</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>100%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>80%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>10%</td>");
            FloorInchargeInSB.Append("</tr>");

            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Compliance Audit</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>100%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>80%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>10%</td>");
            FloorInchargeInSB.Append("</tr>");

            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Rescan (Limiting)</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>-15%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>0%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>15%</td>");
            FloorInchargeInSB.Append("</tr>");


            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'><b>Capacity (Ic)</b></td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>₹ 60</td>");
            FloorInchargeInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'><b>Actual (lc)</b></td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'></td>");
            FloorInchargeInSB.Append("</tr>");

            FloorInchargeInSB.Append("</table>");

            LinemenCentiveid.InnerHtml = FloorInchargeInSB.ToString();

        }

        protected void QCsIncentive()
        {


            StringBuilder FloorInchargeInSB = new StringBuilder();

            FloorInchargeInSB.Append("<table border='0' cellspacing='0' cellpadding='0' class='CommoAdmin_Table'>");
            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<th colspan='4' style=' background: #e4e2e2; border: 1px solid #dbd8d8; border-collapse: collapse; font-size: 11px; font-weight: 500; padding: 3px 3px;text-align:center; color: #575759;'><b style='color:#000'>Policy 7. QCs</b><br> (Q.A.-Cutting, Q.A.-Stitching, Q.A.-Finishing, Q.A.-R&D)</th>");
            FloorInchargeInSB.Append("</tr>");
            FloorInchargeInSB.Append("<tr>");

            FloorInchargeInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'></td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>100%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>0%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Weight</td>");
            FloorInchargeInSB.Append("</tr>");


            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Quality Audit</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>100%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>80%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>20%</td>");
            FloorInchargeInSB.Append("</tr>");

            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>Rescan (Limiting)</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>0%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #575759;'>10%</td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>80%</td>");
            FloorInchargeInSB.Append("</tr>");


            FloorInchargeInSB.Append("<tr>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'><b>Capacity</b></td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'>3,300</td>");
            FloorInchargeInSB.Append("<td style='width:100px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'><b>Actual</b></td>");
            FloorInchargeInSB.Append("<td style='width:80px;border: 1px solid #dbd8d8;font-size: 11px; padding: 3px 3px;text-align:center; color: #000;'></td>");
            FloorInchargeInSB.Append("</tr>");

            FloorInchargeInSB.Append("</table>");

            QCsInCentiveid.InnerHtml = FloorInchargeInSB.ToString();

        }


    }
}