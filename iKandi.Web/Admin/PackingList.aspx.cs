using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web.Admin
{
  public partial class PackingList : System.Web.UI.Page
  {
      int OrderDetailId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
      OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"]);

      OrderProcessController oOrderProcessController = new OrderProcessController();
      if (oOrderProcessController.GetPackingListSizeDetails(OrderDetailId).Rows.Count > 0)
      {
        FillPackingListDetails();
      }
      else
      {
        lblMessage.Visible = true;
      }
      oOrderProcessController = null;
    }

    private void FillPackingListDetails()
    {
      OrderProcessController oOrderProcessController = new OrderProcessController();
      TemplateField oTemplateField = new TemplateField();
      DataTable dtPackingListColoumn = dtPackingList();      

      if (dtPackingListColoumn.Columns.Count > 0)
      {
        for (int i = 0; i < dtPackingListColoumn.Columns.Count; i++)
        {
          oTemplateField = new TemplateField();
          oTemplateField.HeaderStyle.VerticalAlign = VerticalAlign.Middle;
          oTemplateField.HeaderText = dtPackingListColoumn.Columns[i].ToString();
          oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
          gvPackingList.Columns.Add(oTemplateField);
        }

        oTemplateField = null;
      }

      gvPackingList.DataSource = dtPackingList();
      gvPackingList.DataBind();

      oOrderProcessController = null;
    }

    protected void gvPackingList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        if (e.Row.RowIndex > 0)
        {
          e.Row.BackColor = System.Drawing.Color.FromName("#FFFFFF");
          e.Row.ForeColor = System.Drawing.Color.FromName("#7E7E7E");
          e.Row.Cells[0].BackColor = System.Drawing.Color.FromName("#989292");
          e.Row.Cells[0].ForeColor = System.Drawing.Color.FromName("#FFFFFF");
        }
        else
        {
          e.Row.BackColor = System.Drawing.Color.FromName("#405D99");
          e.Row.ForeColor = System.Drawing.Color.FromName("#FFFFFF");
        }
        if (dtPackingList().Columns.Count > 0)
        {
          for (int i = 0; i < dtPackingList().Columns.Count; i++)
          {
            Label lbl = new Label();
            lbl.ID = "lbl_" + DataBinder.Eval(e.Row.DataItem, dtPackingList().Columns[i].ToString()).ToString();
            lbl.Text = DataBinder.Eval(e.Row.DataItem, dtPackingList().Columns[i].ToString()).ToString();
            lbl.Font.Size = 10;
            lbl.CssClass = "txt";
            e.Row.Cells[i].Controls.Add(lbl);

            if (i > 0)
            {
              e.Row.Cells[i].Width = 39;
            }
            else
            {
              e.Row.Cells[i].Width = 105;
            }
          }
        }
      }
    }

    private DataTable dtPackingList()
    {
      OrderProcessController oOrderProcessController = new OrderProcessController();
      DataTable dtPackingListSizeDetails = oOrderProcessController.GetPackingListSizeDetails(OrderDetailId);

      DataTable dtPackingListSizeDetailsChangeOrder = new DataTable();
      for (int i = 0; i <= dtPackingListSizeDetails.Rows.Count; i++)
      {
        dtPackingListSizeDetailsChangeOrder.Columns.Add();
      }
      for (int i = 0; i < dtPackingListSizeDetails.Columns.Count; i++)
      {
        dtPackingListSizeDetailsChangeOrder.Rows.Add();
        dtPackingListSizeDetailsChangeOrder.Rows[i][0] = dtPackingListSizeDetails.Columns[i].ColumnName;
      }
      for (int i = 0; i < dtPackingListSizeDetails.Columns.Count; i++)
      {
        for (int j = 0; j < dtPackingListSizeDetails.Rows.Count; j++)
        {
          dtPackingListSizeDetailsChangeOrder.Rows[i][j + 1] = dtPackingListSizeDetails.Rows[j][i];
        }
      }

      DataTable dtPackingListQuantityDetails = oOrderProcessController.GetPackingListQuantityDetails(OrderDetailId);

      DataTable dtFinal = new DataTable();

      dtFinal = Union(dtPackingListSizeDetailsChangeOrder, dtPackingListQuantityDetails);

      return dtFinal;
    }

    public static DataTable Union(DataTable First, DataTable Second)
    {
      DataTable table = new DataTable("Union");
      DataColumn[] newcolumns = new DataColumn[First.Columns.Count];

      for (int i = 0; i < First.Columns.Count; i++)
      {
        newcolumns[i] = new DataColumn(
        First.Columns[i].ColumnName, First.Columns[i].DataType);
      }

      table.Columns.AddRange(newcolumns);
      table.BeginLoadData();

      foreach (DataRow row in First.Rows)
      {
        table.LoadDataRow(row.ItemArray, true);
      }

      foreach (DataRow row in Second.Rows)
      {
        table.LoadDataRow(row.ItemArray, true);
      }

      table.EndLoadData();
      return table;
    }
  }
}