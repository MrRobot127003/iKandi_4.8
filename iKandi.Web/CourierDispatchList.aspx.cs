using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.Common;
using iKandi.BLL;

namespace iKandi.Web
{
    public partial class CourierDispatchList : System.Web.UI.Page
    {
        NotificationController controller = new NotificationController();
        protected void Page_Load(object sender, EventArgs e)
        {            
              controller.SendCourierDispatchList(DateTime.Today);
            
        }        
    }
}