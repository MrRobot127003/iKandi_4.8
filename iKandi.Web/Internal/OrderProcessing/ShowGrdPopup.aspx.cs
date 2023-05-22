using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.BLL;

namespace iKandi.Web.Internal.OrderProcessing
{
    public partial class ShowGrdPopup : System.Web.UI.Page
    {
        OrderController obj_OrderController = new OrderController();
        public string StyleCode
        {
            get;
            set;
        }
        public int ClientId
        {
            get;
            set; 
        }
        public int DeptId
        {
            get;
            set;
        }
        public string Flag
        {
            get;
            set;
        }
        public int Garment
        {
            get;
            set;
        }
        public string GarmentName   
        {
            get;
            set;
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (null != Request.QueryString["StyleCode"])
            {
                StyleCode = Request.QueryString["StyleCode"].ToString();
            }
            if (null != Request.QueryString["ClientId"])
            {
                ClientId =Convert.ToInt32(Request.QueryString["ClientId"].ToString());
            }
            if (null != Request.QueryString["DeptId"])
            {
                DeptId = Convert.ToInt32(Request.QueryString["DeptId"].ToString());
            }
            if (null != Request.QueryString["Flag"])
            {
                Flag = Request.QueryString["Flag"].ToString();
            }
            if (null != Request.QueryString["Garment"])
            {
                Garment = Convert.ToInt32(Request.QueryString["Garment"].ToString());
            }
            if (null != Request.QueryString["GarmentName"])
            {
                GarmentName = Request.QueryString["GarmentName"].ToString();
            }

           

            if (!IsPostBack)
            {
                BindGrd();
            }
        }
         
        protected void BindGrd()
        {
            DataSet dtData = new DataSet();
            //GetOBData
            dtData = obj_OrderController.GetOBData(Flag, StyleCode, ClientId, DeptId, Garment);

            if (dtData.Tables[0].Rows.Count > 0)
            {
                tr1.Visible = true;
                lblGarmentName1.Text = GarmentName.ToString();
                grdOBCutting.DataSource = dtData.Tables[0];
                grdOBCutting.DataBind();
            }
            if (dtData.Tables[1].Rows.Count > 0)
            {
                tr2.Visible = true;
                //lblGarmentName2.Text = GarmentName.ToString();
                grdOBFront.DataSource = dtData.Tables[1];
                grdOBFront.DataBind();
            }
            if (dtData.Tables[2].Rows.Count > 0)
            {
                tr3.Visible = true;
                //lblGarmentName3.Text = GarmentName.ToString();
                grdOBBack.DataSource = dtData.Tables[2];
                grdOBBack.DataBind();
            }
            if (dtData.Tables[3].Rows.Count > 0)
            {
                tr4.Visible = true;
                //lblGarmentName4.Text = GarmentName.ToString();
                grdOBcoller.DataSource = dtData.Tables[3];
                grdOBcoller.DataBind();
            }
            if (dtData.Tables[4].Rows.Count > 0)
            {
                tr5.Visible = true;
                //lblGarmentName5.Text = GarmentName.ToString();
                grdOBsleep.DataSource = dtData.Tables[4];
                grdOBsleep.DataBind();
            }
            if (dtData.Tables[5].Rows.Count > 0)
            {
                tr6.Visible = true;
                //lblGarmentName6.Text = GarmentName.ToString();
                grdOBneck.DataSource = dtData.Tables[5];
                grdOBneck.DataBind();
            }
            if (dtData.Tables[6].Rows.Count > 0)
            {
                tr7.Visible = true;
                //lblGarmentName7.Text = GarmentName.ToString();
                grdOBLining.DataSource = dtData.Tables[6];
                grdOBLining.DataBind();
            }
            if (dtData.Tables[7].Rows.Count > 0)
            {
                tr8.Visible = true;
                //lblGarmentName8.Text = GarmentName.ToString();
                grdOBlower.DataSource = dtData.Tables[7];
                grdOBlower.DataBind();
            }
            if (dtData.Tables[8].Rows.Count > 0)
            {
                tr9.Visible = true;
                //lblGarmentName9.Text = GarmentName.ToString();
                grdOBbottom.DataSource = dtData.Tables[8];
                grdOBbottom.DataBind();
            }
            if (dtData.Tables[9].Rows.Count > 0)
            {
                tr10.Visible = true;
                //lblGarmentName10.Text = GarmentName.ToString();
                grdOBassembly.DataSource = dtData.Tables[9];
                grdOBassembly.DataBind();
            }
            if (dtData.Tables[10].Rows.Count > 0)
            {
                tr11.Visible = true;
                //lblGarmentName11.Text = GarmentName.ToString();
                grdOBFinishing.DataSource = dtData.Tables[10];
                grdOBFinishing.DataBind();
            }

            


            
        }
    }
}