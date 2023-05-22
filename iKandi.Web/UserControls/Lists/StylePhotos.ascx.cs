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
using System.Collections.Generic;
using iKandi.Common;

namespace iKandi.Web
{
    public partial class StylePhotos : BaseUserControl
    {
        #region Properties

        public int StyleID
        {
            get;
            set;
        }

        public int OrderID
        {
            get;
            set;
        }

        public int OrderDetailID
        {
            get;
            set;
        }

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindControls();
        }

        private void BindControls()
        {
           // System.Diagnostics.Debugger.Break();

            DataSet ds = this.StyleControllerInstance.GetAllStylePhotos(this.StyleID, this.OrderID, this.OrderDetailID);

            List<iKandi.Common.StyleReferenceBlock> refs = new List<iKandi.Common.StyleReferenceBlock>();

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                if ((row["SketchUrl"] != DBNull.Value) && !string.IsNullOrEmpty(row["SketchUrl"].ToString()))
                {
                    StyleReferenceBlock refBlock = new StyleReferenceBlock();

                    refBlock.Name = "Sketch";
                    refBlock.ImagePath = ResolveUrl("~/uploads/style/thumb-" + row["SketchUrl"].ToString());

                    refs.Add(refBlock);
                }

                if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                {
                    foreach (DataRow row1 in ds.Tables[2].Rows)
                    {
                        if ((row1["ReferenceBlockURL"] != DBNull.Value) && !string.IsNullOrEmpty(row1["ReferenceBlockURL"].ToString()))
                        {
                            StyleReferenceBlock refBlock = new StyleReferenceBlock();
                            refBlock.Name = (row1["ReferenceBlockURL"] != DBNull.Value) ? row1["Name"].ToString() : string.Empty;

                            if (row1["Type"].ToString() == "1")
                                refBlock.ImagePath = ResolveUrl("~/uploads/style/thumb-" + row1["ReferenceBlockURL"].ToString());
                            else
                                refBlock.ImagePath = ResolveUrl("~/uploads/INDBlock/thumb-" + row1["ReferenceBlockURL"].ToString());

                            refs.Add(refBlock);
                        }
                    }
                }

               if (ds.Tables.Count > 5 && ds.Tables[5].Rows.Count > 0)
                {
                    foreach (DataRow cadRow in ds.Tables[5].Rows)
                    {
                        if ((cadRow["ReferenceBlockURL"] != DBNull.Value) && !string.IsNullOrEmpty(cadRow["ReferenceBlockURL"].ToString()))
                        {
                            StyleReferenceBlock refBlock = new StyleReferenceBlock();
                            refBlock.Name = (cadRow["ReferenceBlockURL"] != DBNull.Value) ? cadRow["Name"].ToString() : string.Empty;
                            refBlock.ImagePath = ResolveUrl("~/uploads/style/thumb-" + cadRow["ReferenceBlockURL"].ToString());
                            refs.Add(refBlock);
                        }
                    }
                }


                if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow printRow in ds.Tables[1].Rows)
                    {
                        if ((printRow["ImageUrl"] != DBNull.Value) && !string.IsNullOrEmpty(printRow["ImageUrl"].ToString()))
                        {
                            StyleReferenceBlock refBlock = new StyleReferenceBlock();
                            refBlock.Name = "PRD " + printRow["PrintNumber"].ToString();
                            refBlock.ImagePath = ResolveUrl("~/uploads/print/thumb-" + printRow["ImageUrl"].ToString());
                            refs.Add(refBlock);
                        }
                    }
                }

                if ((row["SampleImageURL1"] != DBNull.Value) && !string.IsNullOrEmpty(row["SampleImageURL1"].ToString()))
                {
                    StyleReferenceBlock refBlock = new StyleReferenceBlock();

                    refBlock.Name = "Front";
                    refBlock.ImagePath = ResolveUrl("~/uploads/style/thumb-" + row["SampleImageURL1"].ToString());

                    refs.Add(refBlock);
                }

                if ((row["SampleImageURL2"] != DBNull.Value) && !string.IsNullOrEmpty(row["SampleImageURL2"].ToString()))
                {
                    StyleReferenceBlock refBlock = new StyleReferenceBlock();

                    refBlock.Name = "Back";
                    refBlock.ImagePath = ResolveUrl("~/uploads/style/thumb-" + row["SampleImageURL2"].ToString());

                    refs.Add(refBlock);
                }

                if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                {
                    foreach (DataRow embellishmentRow in ds.Tables[3].Rows)
                    {
                        if ((embellishmentRow["ReferenceBlockURL"] != DBNull.Value) && !string.IsNullOrEmpty(embellishmentRow["ReferenceBlockURL"].ToString()))
                        {
                            StyleReferenceBlock refBlock = new StyleReferenceBlock();
                            refBlock.Name = (embellishmentRow["ReferenceBlockURL"] != DBNull.Value) ? embellishmentRow["Name"].ToString() : string.Empty;
                            refBlock.ImagePath = ResolveUrl("~/uploads/style/thumb-" + embellishmentRow["ReferenceBlockURL"].ToString());
                            refs.Add(refBlock);
                        }
                    }
                }

                if (ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
                {
                    foreach (DataRow mocksRow in ds.Tables[4].Rows)
                    {
                        if ((mocksRow["ReferenceBlockURL"] != DBNull.Value) && !string.IsNullOrEmpty(mocksRow["ReferenceBlockURL"].ToString()))
                        {
                            StyleReferenceBlock refBlock = new StyleReferenceBlock();
                            refBlock.Name = (mocksRow["ReferenceBlockURL"] != DBNull.Value) ? mocksRow["Name"].ToString() : string.Empty;
                            refBlock.ImagePath = ResolveUrl("~/uploads/style/thumb-" + mocksRow["ReferenceBlockURL"].ToString());
                            refs.Add(refBlock);
                        }
                    }
                }

                if ((row["SampleImageURL3"] != DBNull.Value) && !string.IsNullOrEmpty(row["SampleImageURL3"].ToString()))
                {
                    StyleReferenceBlock refBlock = new StyleReferenceBlock();

                    refBlock.Name = "Additional";
                    refBlock.ImagePath = ResolveUrl("~/uploads/style/thumb-" + row["SampleImageURL3"].ToString());

                    refs.Add(refBlock);
                }
            }

            rptImages.DataSource = refs;
            rptImages.DataBind();

        }
    }
}