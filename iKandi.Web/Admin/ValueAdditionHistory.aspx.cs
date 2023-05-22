using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Drawing;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web.Admin
{
  public partial class ValueAdditionHistory : System.Web.UI.Page
  {
    int OrderDetailId = 0;
    int UnitId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
      OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"]);
      UnitId = Convert.ToInt32(Request.QueryString["UnitId"]);

      OrderProcessController oOrderProcessController = new OrderProcessController();
      if (oOrderProcessController.GetPackingListSizeDetails(OrderDetailId).Rows.Count > 0)
      {
        lblUnit.Text = oOrderProcessController.GetUnitName(UnitId);
        FillValueAdditionDetails();
      }
      else
      {
        trMessage.Visible = true;
        lblMessage.Visible = true;
      }
      oOrderProcessController = null;
    }

    private void FillValueAdditionDetails()
    {
      OrderProcessController oOrderProcessController = new OrderProcessController();
      TemplateField oTemplateField = new TemplateField();
      DataTable dtValueAdditionColoumn = oOrderProcessController.GetPackingListSizeDetails(OrderDetailId);

     // hdnColumnCount.Value = dtValueAdditionColoumn.Rows.Count.ToString();
      //if (dtValueAdditionColoumn.Rows.Count > 0)
      //{
      //  for (int i = 0; i < dtValueAdditionColoumn.Rows.Count; i++)
      //  {
          oTemplateField = new TemplateField();
          //oTemplateField.HeaderStyle.VerticalAlign = VerticalAlign.Middle;
          oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
         // oTemplateField.HeaderStyle.Width = 39;
          gvValueAdditionHistory.Columns.Add(oTemplateField);
       // }

        //oTemplateField = new TemplateField();
        //oTemplateField.HeaderStyle.VerticalAlign = VerticalAlign.Middle;
        //oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        //gvValueAdditionHistory.Columns.Add(oTemplateField);

        oTemplateField = null;
      //}

      if (oOrderProcessController.GetValueAdditionHistoryDetails(OrderDetailId, UnitId).Rows.Count > 0)
      {
        gvValueAdditionHistory.DataSource = oOrderProcessController.GetValueAdditionHistoryDetails(OrderDetailId, UnitId);
        gvValueAdditionHistory.DataBind();
      }
      else
      {
        trMessage.Visible = true;
        lblMessage.Visible = true;
        lblMessage.Text = "There are no History Available for this Contrat.";
      }
      oOrderProcessController = null;
    }

    protected void gvValueAdditionHistory_DataBound(object sender, EventArgs e)
    {
      for (int i = gvValueAdditionHistory.Rows.Count - 1; i > 0; i--)
      {
        GridViewRow row = gvValueAdditionHistory.Rows[i];
        GridViewRow previousRow = gvValueAdditionHistory.Rows[i - 1];

        Label lblDate = (Label)row.Cells[1].FindControl("lblDate");
        Label lblPreviousDate = (Label)previousRow.Cells[1].FindControl("lblDate");

        if (lblDate.Text == lblPreviousDate.Text)
        {
          if (previousRow.Cells[1].RowSpan == 0)
          {
            if (row.Cells[1].RowSpan == 0)
            {
              previousRow.Cells[1].RowSpan += 2;
            }
            else
            {
              previousRow.Cells[1].RowSpan = row.Cells[1].RowSpan + 1;
            }
            row.Cells[1].Visible = false;
          }
        }

        Label lblFromStatus_ToStatus = (Label)row.Cells[1].FindControl("lblFromStatus_ToStatus");
        Label lblPreviousFromStatus_ToStatus = (Label)previousRow.Cells[1].FindControl("lblFromStatus_ToStatus");

        if (lblFromStatus_ToStatus.Text == lblPreviousFromStatus_ToStatus.Text)
        {
          if (previousRow.Cells[0].RowSpan == 0)
          {
            if (row.Cells[0].RowSpan == 0)
            {
              previousRow.Cells[0].RowSpan += 2;
            }
            else
            {
              previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
            }
            row.Cells[0].Visible = false;
          }
        }
      }
    }

    protected void gvValueAdditionHistory_RowCreated(object sender, GridViewRowEventArgs e)
    {
      OrderProcessController oOrderProcessController = new OrderProcessController();
      if (e.Row.RowType == DataControlRowType.Header)
      {
        GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

        TableCell Cell = new TableCell();
        Cell.Text = "From Stat - To Stat";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        // Cell.ColumnSpan = 1;
        Cell.Height = 25;
        Cell.Font.Size = 10;
        gvrow.Cells.Add(Cell);

       



        Cell = new TableCell();
        Cell.Text = "Date";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        // Cell.ColumnSpan = 1;
        Cell.Font.Size = 10;
        // Cell.RowSpan = 2;
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "VA Name";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        //Cell.ColumnSpan = 1;
        Cell.Font.Size = 10;
        //  Cell.RowSpan = 2;
        gvrow.Cells.Add(Cell);


        DataTable dtValueAdditionColoumn = oOrderProcessController.GetPackingListSizeDetails(OrderDetailId);
        if (dtValueAdditionColoumn.Rows.Count > 0)
        {
            Cell = new TableCell();
            Cell.Text = "Capacity Qty/Order Qty.";
            Cell.HorizontalAlign = HorizontalAlign.Center;
            Cell.Font.Bold = true;
            //  Cell.ColumnSpan = dtValueAdditionColoumn.Rows.Count;
            Cell.Font.Size = 10;
            gvrow.Cells.Add(Cell);
        }
        lbltotal.Text = "Total: " + "<span>" + dtValueAdditionColoumn.Rows[0]["TotalOredrQty"].ToString() + "</span>";
        //Cell = new TableCell();
        //Cell.Text = "Total" + "</br><span class='ValuQty'>" + dtValueAdditionColoumn.Rows[0]["TotalOredrQty"].ToString() + "</span>";
        //Cell.HorizontalAlign = HorizontalAlign.Center;
        //Cell.VerticalAlign = VerticalAlign.Bottom;
        //Cell.Font.Bold = true;
        //Cell.ColumnSpan = 1;
        //Cell.Font.Size = 10;
        //Cell.RowSpan = 2;
        //Cell.Width = 60;
        //gvrow.Cells.Add(Cell);

        gvValueAdditionHistory.Controls[0].Controls.AddAt(0, gvrow);
      }
      oOrderProcessController = null;
    }

    protected void gvValueAdditionHistory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      OrderProcessController oOrderProcessController = new OrderProcessController();
      if (e.Row.RowType == DataControlRowType.Header)
      {
        DataTable dtValueAdditionColoumn = oOrderProcessController.GetPackingListSizeDetails(OrderDetailId);

        e.Row.Cells[0].Visible = false;
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        //e.Row.Cells[dtValueAdditionColoumn.Rows.Count + 3].Visible = false;

        //for (int i = 3; i < gvValueAdditionHistory.Columns.Count; i++)
        //{
        //  HiddenField hdn = new HiddenField();
        //  Label lbl = new Label();

        //  if (gvValueAdditionHistory.Columns.Count - 1 != i)
        //  {
        //    hdn.ID = "hdnSizeId_" + i.ToString();
        //    hdn.Value = dtValueAdditionColoumn.Rows[i - 3]["SizeId"].ToString();
        //    lbl.ID = "lblSize_Qty_" + i.ToString();
        //    lbl.Text = dtValueAdditionColoumn.Rows[i - 3]["Size"].ToString() + "</br> <span class='ValuQty'>" + dtValueAdditionColoumn.Rows[i - 3]["Qty"].ToString() + "</span>";
        //  }
        //  e.Row.Cells[i].Controls.Add(hdn);
        //  e.Row.Cells[i].Controls.Add(lbl);
        //}
      }

      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        Label lblValueAdditionName = (Label)e.Row.FindControl("lblValueAdditionName");
        lblValueAdditionName.Text = lblValueAdditionName.Text.Substring(0, 1).ToUpper() + lblValueAdditionName.Text.Substring(1).ToLower();

        for (int i = 3; i < gvValueAdditionHistory.Columns.Count; i++)
        {
          Label lbl = new Label();
          lbl.CssClass = "txt";
          //if (gvValueAdditionHistory.Columns.Count - 1 == i)
          //{
          //  lbl.ID = "lblTotalValueAddQty_" + i.ToString();
          //  lbl.Width = 56;
          //  lbl.Font.Bold = true;
          //}
          //else
          //{
          //  HiddenField hdnSizeId = (HiddenField)gvValueAdditionHistory.HeaderRow.FindControl("hdnSizeId_" + i.ToString());
            lbl.ID = "lblValueAddQty_" + i.ToString();
            lbl.Text = oOrderProcessController.GetValueAddQtyHistory(OrderDetailId, Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ValueAdditionID")), Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "CreateDate")), UnitId).ToString();
            lbl.Text = lbl.Text == "0" ? "" : lbl.Text;
            lbl.Width = 35;
         // }
          e.Row.Cells[i].Controls.Add(lbl);
        }
      }
      oOrderProcessController = null;
    }
  }
}