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

namespace iKandi.Web
{
    public partial class PrintFabricHistory : BaseUserControl
    {
        #region Properties

        public string PrintNumber
        {
            get;
            set;
        }

        public string StyleId
        {
            get;
            set;
        }

        public string StyleNumber
        {
            get;
            set;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(this.PrintNumber))
            {
              //grdFabricHistory.DataSource = this.FabricSmplingControllerInstance.GetSamplingFabricByPrintNumber(this.PrintNumber);
               grdFabricHistory.DataSource = this.FabricSmplingControllerInstance.GetSamplingFabricByPrintNumber_And_StyleId(this.PrintNumber, StyleId);
               //grdFabricHistory.DataSource = this.FabricSmplingControllerInstance.GetPrintFabricHistoryStyleId(this.PrintNumber, StyleId);
            
                
            }
            else
            {
                grdFabricHistory.DataSource = this.FabricSmplingControllerInstance.GetSamplingFabricByStyleNumber(this.StyleNumber);
            }
            bindGrd(StyleId);
            grdFabricHistory.DataBind();
        }
        /// <summary>
        /// Yaten : For Bind Grid 26 Apr
        /// </summary>
        /// <param name="intId"></param>
        public void bindGrd(string intId)
        {
            DataTable dt = this.FabricSmplingControllerInstance.Get_All_Solid_Special_BLL(intId);
                grdSolid.DataSource=dt;
            grdSolid.DataBind();
 
        }
        protected void grdFabricHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        //    $("td.style-fabric2", "#main_content").each(function() {
        //    var data = $(this).text();

        //    if (data == null || data == '')
        //        return;
        //    alert(data);
        //    var fabriArr1;
        //    var dataArr = data.split(",");
        //    alert("dataArr[0]" + dataArr[0]);
        //    alert("dataArr[1]" + dataArr[1]);
        //    var html = '';
        //    for (i = 0; i < dataArr.length; i++) {
        //        var fabriArr = dataArr[i].split("##");
        //        alert("fabriArr[0]" + fabriArr[0]);
        //        alert("fabriArr[1]" + fabriArr[1]);
        //        html += "<div><span class='Blue'>" + fabriArr[0] + ": " + "</span><br/>" + fabriArr[1] + "</div>";
        //        alert("html" + html); 
        //    }
        //    $(this).html(html);

        //});

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            SamplingFabric sf = e.Row.DataItem as SamplingFabric;
            
            e.Row.Cells[15].BackColor = System.Drawing.ColorTranslator.FromHtml(iKandi.Common.Constants.GetFabricStatusModeColor(sf.StatusReceving));
            string data = e.Row.Cells[6].Text;
            data = "<span class='Blue'>" + data.Replace("##", "</span><br/>");
            e.Row.Cells[6].Text = data;

        }
    }
}