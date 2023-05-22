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
using iKandi.Web.Components;

namespace iKandi.Web
{
    public partial class HolidayAdmin : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbInsert_Click(object sender, EventArgs e)
        {
            TextBox title = GridView1.FooterRow.FindControl("tbInsertTitle") as TextBox;
            TextBox description = GridView1.FooterRow.FindControl("tbInsertDescription") as TextBox;
            TextBox date = GridView1.FooterRow.FindControl("tbInsertDate") as TextBox;
            TextBox tillDate = GridView1.FooterRow.FindControl("tbInsertTillDate") as TextBox;
            DropDownList company = GridView1.FooterRow.FindControl("ddlInsertCompany") as DropDownList;
            DropDownList type = GridView1.FooterRow.FindControl("ddlInsertType") as DropDownList;

            iKandi.Common.Holiday holiday = new iKandi.Common.Holiday();
            holiday.Title = title.Text;
            holiday.Description = description.Text;
            holiday.Company = Convert.ToInt32(company.SelectedValue);
            holiday.Date = DateHelper.ParseDate(date.Text).Value;

            if (tillDate.Text == null || tillDate.Text.Trim() == string.Empty)
            {
                holiday.TillDate = holiday.Date;
            }
            else
            {
                holiday.TillDate = DateHelper.ParseDate(tillDate.Text).Value;
            }

            holiday.HolidayTypeID = Convert.ToInt32(type.SelectedValue);

            this.LeaveControllerInstance.InsertHoliday(holiday);

            title.Text = "";
            description.Text = "";
            date.Text = "";
            tillDate.Text = "";

            GridView1.DataBind();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            (GridView1.FooterRow.FindControl("tbInsertTitle") as TextBox).Text = "";
            (GridView1.FooterRow.FindControl("tbInsertDescription") as TextBox).Text = "";
            (GridView1.FooterRow.FindControl("tbInsertDate") as TextBox).Text = "";
            (GridView1.FooterRow.FindControl("tbInsertTillDate") as TextBox).Text = "";

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

    }
}
