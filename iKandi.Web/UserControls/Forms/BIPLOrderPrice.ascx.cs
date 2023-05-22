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
using iKandi.BLL;
using iKandi.Web.Components;
using System.Collections.Generic;
using iKandi.Common;

namespace iKandi.Web.UserControls.Forms
{
  public partial class BIPLOrderPrice : BaseUserControl
  {
    public int StyleId
    {
      get;
      set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      FillBIPLOrderPriceDetails();
    }

    private void FillBIPLOrderPriceDetails()
    {
      CostingController oCostingController = new CostingController();
      gvBIPLOrderPrice.DataSource = oCostingController.GetBIPLOrderPriceDetails(this.StyleId);
      gvBIPLOrderPrice.DataBind();
      oCostingController = null;
    }
  }
}