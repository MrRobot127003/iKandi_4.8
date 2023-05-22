using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;

namespace iKandi.Common
{
    public class PrintPDFGenerator : PDFGenerator
    {
        #region

        public PrintPDFGenerator(string FilePath): base(FilePath)
        {

        }

        #endregion

        #region Properties

        public string ImagePath
        {
            get;
            set;
        }

        #endregion

        #region Public Methods

        public override void CreatePDFContent()
        {
            document.SetMargins(5f, 5f, 5f, 5f);

            Image jpeg = Image.GetInstance(ImagePath);

            jpeg.Alignment = Image.ALIGN_CENTER;

            if (this.IsLandScape)
            {
                jpeg.ScaleToFit(PageSize.A4.Rotate().Width - 5, PageSize.A4.Rotate().Height - 5);
            }
            else
            {
                jpeg.ScaleToFit(PageSize.A4.Width - 5, PageSize.A4.Height - 5);
               
            }

            document.Add(jpeg);
           

            //iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
            //if (!this.IsLandScape)
            //    jpeg.ScalePercent(72f / jpeg.DpiX * 100);
            //else
            //    jpeg.ScalePercent(72f / jpeg.DpiY * 100);
           
            //jpeg.SetAbsolutePosition(0, 0);
            //cb.AddImage(jpeg);
            //document.NewPage(); 
            //document.Add(jpeg);

        }

        #endregion

    }
}
