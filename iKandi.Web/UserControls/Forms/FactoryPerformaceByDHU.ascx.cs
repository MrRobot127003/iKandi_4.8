using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.Data;

namespace iKandi.Web.UserControls.Forms
{
    public partial class FactoryPerformaceByDHU : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDHU();

            }

        }

        private void BindDHU()
        {
            Dictionary<string, int> Factory = new Dictionary<string, int>();
            int Unitid = 11;
            OrderController objOrderController = new OrderController();
            DataSet ds = new DataSet();
            ds = objOrderController.GetDHUDAYTA(Unitid);
            listline.DataSource = ds;
            listline.DataBind();
            listline.RepeatColumns = ds.Tables[0].Rows.Count;

            int Count = ds.Tables[0].Rows.Count;
            for (int i = 0; i < Count; i++)
            {
                Factory.Add(i.ToString(), 11);

            }

            datalist5.DataSource = Factory;
            datalist5.DataBind();
            datalist5.RepeatColumns = Count;
            Factory.Clear();

            ds = objOrderController.GetWeeklyData(Unitid);
            Datalistreport.RepeatColumns = Count;
            Datalistreport.DataSource = ds;
            Datalistreport.DataBind();

            Unitid = 3;
            ds = objOrderController.GetDHUDAYTA(Unitid);
            Datalistline1.DataSource = ds;
            Datalistline1.DataBind();
            Datalistline1.RepeatColumns = ds.Tables[0].Rows.Count;
             Count = ds.Tables[0].Rows.Count;


             for (int i = 0; i < Count; i++)
             {
                 Factory.Add(i.ToString(), 11);

             }

             datalist.DataSource = Factory;
             datalist.DataBind();
             datalist.RepeatColumns = Count;
             Factory.Clear();
            ds = objOrderController.GetWeeklyData(Unitid);
            Datalist2.RepeatColumns = Count;
            Datalist2.DataSource = ds;
            Datalist2.DataBind();


            Unitid = 12;
            ds = objOrderController.GetDHUDAYTA(Unitid);
            DataList3.DataSource = ds;
            DataList3.DataBind();
            DataList3.RepeatColumns = ds.Tables[0].Rows.Count;
            Count = ds.Tables[0].Rows.Count;

            for (int i = 0; i < Count; i++)
            {
                Factory.Add(i.ToString(), 11);

            }

            datalist1.DataSource = Factory;
            datalist1.DataBind();
            datalist1.RepeatColumns = Count;
            Factory.Clear();
            ds = objOrderController.GetWeeklyData(Unitid);
            Datalist3fact.RepeatColumns = Count;
            Datalist3fact.DataSource = ds;
            Datalist3fact.DataBind();

            Datalist4.DataSource = ds.Tables[1];
            Datalist4.DataBind();


        }

        protected void Datalistreport_ItemDataBound(object sender, DataListItemEventArgs e)
        {

            Label AVGEFF = (Label)e.Item.FindControl("lblAvg");
            Label AVGDHU = (Label)e.Item.FindControl("lblAch");
            Label lblDhu = (Label)e.Item.FindControl("lblDhu");
          
            if (AVGEFF.Text == "0")
            {
                AVGEFF.Text = "";
            }


            if (AVGDHU.Text == "0")
            {
                AVGDHU.Text = "";
            }

            if (lblDhu.Text == "0")
            {
                lblDhu.Text = "";
            }
        }

        protected void Datalist2_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label AVGEFF = (Label)e.Item.FindControl("lblAvg");
            Label AVGDHU = (Label)e.Item.FindControl("lblAch");
            Label lblDhu = (Label)e.Item.FindControl("lblDhu");
            if (AVGEFF.Text == "0")
            {
                AVGEFF.Text = "";
            }


            if (AVGDHU.Text == "0")
            {
                AVGDHU.Text = "";
            }

            if (lblDhu.Text == "0")
            {
                lblDhu.Text = "";
            }
        }

        protected void Datalist3fact_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label AVGEFF = (Label)e.Item.FindControl("lblAvg");
            Label AVGDHU = (Label)e.Item.FindControl("lblAch");
            Label lblDhu = (Label)e.Item.FindControl("lblDhu");
            if (AVGEFF.Text == "0")
            {
                AVGEFF.Text = "";
            }


            if (AVGDHU.Text == "0")
            {
                AVGDHU.Text = "";
            }

            if (lblDhu.Text == "0")
            {
                lblDhu.Text = "";
            }
        }

        protected void Datalist4_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label AVGEFF = (Label)e.Item.FindControl("lblAvg");
                Label AVGDHU = (Label)e.Item.FindControl("lblDhu");
                

                if (AVGEFF.Text == "0" )
                {
                    AVGEFF.Text = "";
                }


                if (AVGDHU.Text == "0")
                {
                    AVGDHU.Text = "";
                }
            }
        }
    }
}