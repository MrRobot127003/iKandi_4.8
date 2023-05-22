using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;

namespace iKandi.Common
{
    public class MultiPagePrintPDFGenerator : PDFGenerator
    {
        #region

        public MultiPagePrintPDFGenerator(string FilePath)
            : base(FilePath)
        {

        }

        #endregion

        #region Properties

        public List<System.Drawing.Image> ImagePaths
        {
            get;
            set;
        }

        #endregion

        #region Public Methods

        public override void CreatePDFContent()
        {

            foreach (System.Drawing.Image Image in ImagePaths)
            {
                document.SetMargins(5f, 5f, 5f, 5f);

                iTextSharp.text.Image jpeg = iTextSharp.text.Image.GetInstance(Image, System.Drawing.Imaging.ImageFormat.Bmp);

                jpeg.Alignment = iTextSharp.text.Image.ALIGN_CENTER;

                if (this.IsLandScape)
                {
                    jpeg.ScaleToFit(PageSize.A4.Rotate().Width - 5, PageSize.A4.Rotate().Height - 5);
                }
                else
                {
                    jpeg.ScaleToFit(PageSize.A4.Width - 5, PageSize.A4.Height - 5);

                }

                document.NewPage();
                document.Add(jpeg);
            }
        }

        #endregion
    }
}
