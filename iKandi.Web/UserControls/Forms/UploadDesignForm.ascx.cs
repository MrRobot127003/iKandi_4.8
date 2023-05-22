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
using iKandi.Common;
using System.Collections.Generic;


namespace iKandi.Web
{
    public partial class UploadDesignForm : BaseUserControl
    {

        #region Properties

        public int StyleID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["styleid"]))
                {
                    return Convert.ToInt32(Request.QueryString["styleid"]);
                }

                return -1;
            }
        }

        #endregion

        #region Event Handlers
        protected void Page_Load(object sender, EventArgs e)
        {
            if (StyleID != -1)
                PopulateStyleData();

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            UpdateStyle();
        }

        #endregion

        #region Private Methods

        string oldMocks = string.Empty;
        string oldEmbellishment = string.Empty;
        string oldCad = string.Empty;
        string oldMCEmbellishment = string.Empty;

        private void PopulateStyleData()
        {
            iKandi.Common.Style s = this.StyleControllerInstance.GetStyleByStyleId(StyleID);

            string fileID1 = string.Empty;
            string fileID2 = string.Empty;
            string fileID3 = string.Empty;

            lblStyle.Text = s.StyleNumber.ToString();
            lblBuyer.Text = s.ClientName.ToString();
            //lblDept.Text = "Department: " + s.ClientDepartment.ToString();

            hdnStyleID.Value = StyleID.ToString();

            if (!string.IsNullOrEmpty(s.SampleImageURL1))
            {
                //Image1.Visible = true;
                //Image1.ImageUrl = ResolveUrl("~/Uploads/Style/" + s.SampleImageURL1);
                //CheckBoxStyleFront.Visible = true;
                Img1.Visible = true;
                Button1.Visible = true;
                hypSample1.NavigateUrl = ("~/Uploads/Style/" + s.SampleImageURL1);

            }

            if (!string.IsNullOrEmpty(s.SampleImageURL2))
            {
                //Image2.Visible = true;
                //Image2.ImageUrl = ResolveUrl("~/Uploads/Style/" + s.SampleImageURL2);
                //CheckBoxStyleBack.Visible = true;
                Img2.Visible = true;
                Button2.Visible = true;
                hypSample2.NavigateUrl = ("~/Uploads/Style/" + s.SampleImageURL2);
                hypSample2.Visible = true;
            }

            if (!string.IsNullOrEmpty(s.SampleImageURL3))
            {
                //  Image3.Visible = true;
                //  Image3.ImageUrl = ResolveUrl("~/Uploads/Style/" + s.SampleImageURL3);
                //CheckBoxStyleAdditional.Visible = true;
                Img3.Visible = true;
                Button3.Visible = true;
                hypSample3.NavigateUrl = ("~/Uploads/Style/" + s.SampleImageURL3);
                hypSample3.Visible = true;
            }

            List<StyleReferenceBlock> refBlocks = s.ReferenceBlocks.FindAll(delegate(StyleReferenceBlock st)
            {
                return st.Type == 3;
            });

            rptUploadEmbellishment.DataSource = refBlocks;
            rptUploadEmbellishment.DataBind();

            // for Mocks 
            List<StyleReferenceBlock> refMocks = s.ReferenceBlocks.FindAll(delegate(StyleReferenceBlock st)
            {
                return st.Type == 4;
            });

            rptUploadMocks.DataSource = refMocks;
            rptUploadMocks.DataBind();

            // for Cad 
            List<StyleReferenceBlock> refCad = s.ReferenceBlocks.FindAll(delegate(StyleReferenceBlock st)
            {
                return st.Type == 5;
            });

            rptUploadCad.DataSource = refCad;
            rptUploadCad.DataBind();

            // for Machine Embelleshment
            List<StyleReferenceBlock> refMCEMB = s.ReferenceBlocks.FindAll(delegate(StyleReferenceBlock st)
            {
                return st.Type == (int)ReferenceBlockType.MACHINE_EMBELLISHMENT;
            });

            rptUploadMCEmbellishment.DataSource = refMCEMB;
            rptUploadMCEmbellishment.DataBind();


        }

        private void UpdateStyle()
        {

            iKandi.Common.Style sOld = this.StyleControllerInstance.GetStyleByStyleId(StyleID);
            iKandi.Common.Style s = new iKandi.Common.Style();

            sOld.StyleID = this.StyleID;

            s.StyleID = this.StyleID;

            if (sOld.StyleID == -1)
            {
                sOld.StyleNumber = "New 1";
            }

            if (uploadImage1.HasFile)
                s.SampleImageURL1 = FileHelper.SaveFile(uploadImage1.PostedFile.InputStream, uploadImage1.FileName,
                                                        Constants.STYLE_FOLDER_PATH, true,
                                                        sOld.StyleNumber.Trim() + "-FRONT");
            else if (!String.IsNullOrEmpty(sOld.SampleImageURL1))
                s.SampleImageURL1 = sOld.SampleImageURL1;
            else
                s.SampleImageURL1 = "";

            if (uploadImage2.HasFile)
                s.SampleImageURL2 = FileHelper.SaveFile(uploadImage2.PostedFile.InputStream, uploadImage2.FileName,
                                                        Constants.STYLE_FOLDER_PATH, true,
                                                        sOld.StyleNumber.Trim() + "-BACK");
            else if (!String.IsNullOrEmpty(sOld.SampleImageURL2))
                s.SampleImageURL2 = sOld.SampleImageURL2;
            else
                s.SampleImageURL2 = "";


            if (uploadImage3.HasFile)
                s.SampleImageURL3 = FileHelper.SaveFile(uploadImage3.PostedFile.InputStream, uploadImage3.FileName,
                                                        Constants.STYLE_FOLDER_PATH, true,
                                                        sOld.StyleNumber.Trim() + "-ADDNL");
            else if (!String.IsNullOrEmpty(sOld.SampleImageURL3))
                s.SampleImageURL3 = sOld.SampleImageURL3;
            else
                s.SampleImageURL3 = "";

            this.StyleControllerInstance.UpdateUrls(s);

            s.ReferenceBlocks = new List<StyleReferenceBlock>();

            //System.Diagnostics.Debugger.Break();

            for (int i = 0; i < Request.Files.Count; i++)
            {
                StyleReferenceBlock StyleRef = new StyleReferenceBlock();
                if (Request.Files.AllKeys[i].EndsWith("uplodeMocks") || Request.Files.AllKeys[i].EndsWith("uplodeCad") ||
                    Request.Files.AllKeys[i].EndsWith("uplodeEmblesshment") ||
                    Request.Files.AllKeys[i].EndsWith("uploadStyleMCEmbellishment"))
                {
                    StyleRef.StyleID = StyleID;
                    if (Request.Files.AllKeys[i].EndsWith("uplodeMocks"))
                    {
                        StyleRef.Name = "Mocks";
                        StyleRef.Type = Convert.ToInt32(ReferenceBlockType.MOCKS);
                    }
                    else if (Request.Files.AllKeys[i].EndsWith("uplodeCad"))
                    {
                        StyleRef.Name = "Cad";
                        StyleRef.Type = Convert.ToInt32(ReferenceBlockType.CAD);
                    }
                    else if (Request.Files.AllKeys[i].EndsWith("uplodeEmblesshment"))
                    {
                        StyleRef.Name = "EMBELLISHMENT";
                        StyleRef.Type = Convert.ToInt32(ReferenceBlockType.EMBELLISHMENT);
                    }
                    else if (Request.Files.AllKeys[i].EndsWith("uploadStyleMCEmbellishment"))
                    {
                        StyleRef.Name = "MACHINCE EMBELLISHMENT";
                        StyleRef.Type = Convert.ToInt32(ReferenceBlockType.MACHINE_EMBELLISHMENT);
                    }
                    if (Request.Files != null && Request.Files[i].InputStream != null &&
                        Request.Files[i].InputStream.Length > 0)
                    {
                        string filepath = ("~/Uploads/Style/" + StyleRef.ImagePath);
                        string imageName = FileHelper.SaveFile(Request.Files[i].InputStream, Request.Files[i].FileName,
                                                               Constants.STYLE_FOLDER_PATH, true,
                                                               sOld.StyleNumber.Trim() + "-" + StyleRef.Name + i);
                        if (imageName != string.Empty)
                            StyleRef.ImagePath = imageName;
                        this.StyleControllerInstance.CreateStyleRefBlock(StyleRef);
                    }
                }
            }

            pnlForm.Visible = false;
            pnlMessage.Visible = true;
        }

        #endregion
    }
}