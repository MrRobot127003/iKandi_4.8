using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.rtf.headerfooter;

namespace iKandi.Common
{
    public class PDFGenerator
    {
        #region Fields

        protected Document document;
        protected PdfWriter writer;
        protected bool isLandScape = true;
        protected Rectangle pageSize;
        private FileStream fileStream;

        #endregion


        #region Properties

        public string HeadingText
        {
            get;
            set;
        }
        //Added By Ashish on 1/6/2015
        public string HeaderQty
        {
            get;
            set;
        }
        public string HeaderDate
        {
            get;
            set;
        }
        public string HeaderText2
        {
            get;
            set;
        }
        //END
        public bool Success
        {
            get;
            set;
        }

        public string FilePath
        {
            get;
            set;
        }

        public Color Color
        {
            get;
            set;
        }

        public string Align
        {
            get;
            set;
        }

        public string PageName
        {
            get;
            set;
        }
        public Font HeaderFont
        {
            get;
            set;
        }

        public bool IsLandScape
        {
            get
            {
                return this.isLandScape;
            }
            set
            {
                this.isLandScape = value;
            }
        }

        public Rectangle DocumentPageSize
        {
            get
            {
                return this.pageSize;
            }
            set
            {
                this.pageSize = value;
            }
        }

        public int CellHeight
        {
            get;
            set;

        }

        public bool IsHeaderTable
        {
            get;
            set;
        }

        public int HeaderTableBodyHeight
        {
            get;
            set;
        }

        public int HeaderTableHeaderHeight
        {
            get;
            set;
        }

        //public int HeaderTableHeaderwidth  
        //{
        //    get;
        //    set;
        //}
        //public string param
        //{
        //    get;
        //    set;
        //}



        #endregion

        #region Ctor(s)

        public PDFGenerator(string PDFFilePath)
        {
            pageSize = PageSize.A2;
            this.FilePath = PDFFilePath;
        }

        public PDFGenerator(string PDFFilePath, string PDFHeadingText)
        {
            pageSize = PageSize.A2;
            this.FilePath = PDFFilePath;
            this.HeadingText = PDFHeadingText;

        }

        public PDFGenerator(string PDFFilePath, string PDFHeadingText, Color Color)
        {
            pageSize = PageSize.A2;
            this.FilePath = PDFFilePath;
            this.HeadingText = PDFHeadingText;
            this.Color = Color;
           
        }
        public PDFGenerator(string PDFFilePath, string PDFHeadingTexts, Color Color, int CellHeight)
        {
          pageSize = PageSize.A2;
          this.FilePath = PDFFilePath;
          this.HeadingText = PDFHeadingTexts;
          this.Color = Color;
          this.CellHeight = CellHeight;
          
        }
        public PDFGenerator(string PDFFilePath, string PDFHeadingText, Color Color, string PageName)
        {
            pageSize = PageSize.A2;
            this.FilePath = PDFFilePath;
            this.HeadingText = PDFHeadingText;
            this.Color = Color;
            this.PageName = PageName;
            //this.HeaderFont.Size = 15;
        }

        //Added By Ashish on 1/6/2015
        public PDFGenerator(string PDFFilePath, string HeaderQty, string PDFHeadingText, string HeaderText2, string HeaderDate, Color Color)
        {
            pageSize = PageSize.A2;
            this.FilePath = PDFFilePath;
            this.HeadingText = PDFHeadingText;
            this.HeaderText2 = HeaderText2;
            this.HeaderQty = HeaderQty;
            this.HeaderDate = HeaderDate;
            this.Color = Color;
          


        }
        //END

        #endregion

        #region Public Methods

        public bool GeneratePDF()
        {
            this.InitPDF();

            this.CreatePDFContent();

            this.FinishPDF();

            return true;
        }

        public bool GeneratePDF_MO()
        {
            this.InitPDF_MO();

            this.CreatePDFContent();

            this.FinishPDF();

            return true;
        }

        public bool GeneratePDF_Invoice()
        {
            this.InitPDF_Invoice();

            this.CreatePDFContent();

            this.FinishPDF();

            return true;
        }

        protected void InitPDF_Invoice()
        {
            document = new Document(((this.isLandScape) ? pageSize.Rotate() : pageSize), 25, 25, 25, 1);

            fileStream = new FileStream(this.FilePath, FileMode.Create);

            writer = PdfWriter.GetInstance(document, fileStream);

            document.Open();

            if (!string.IsNullOrEmpty(this.HeadingText))
            {

                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1257, BaseFont.NOT_EMBEDDED);

                PdfContentByte cb = writer.DirectContentUnder;
                cb.BeginText();
                //cb.SetTextMatrix(75, 1150);
                Color color = new Color(System.Drawing.ColorTranslator.FromHtml("#E91677"));
                cb.SetColorFill(color);
                cb.SetFontAndSize(bf, 25);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "", 650, 300, 0);
                cb.ShowText(this.HeadingText.ToUpper());

                cb.EndText();
            }

        }
        //Added By Ashish on 28/5/2015
        protected void InitPDF_MO()
        {
            document = new Document(((this.isLandScape) ? pageSize.Rotate() : pageSize), 25, 25, 25, 25);

            fileStream = new FileStream(this.FilePath, FileMode.Create);
          
            writer = PdfWriter.GetInstance(document, fileStream);

            document.Open();

            if (!string.IsNullOrEmpty(this.HeadingText))
            {

                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1257, BaseFont.NOT_EMBEDDED);

                PdfContentByte cb = writer.DirectContentUnder;
                cb.BeginText();
                //cb.SetTextMatrix(75, 1150);
                Color color = new Color(System.Drawing.ColorTranslator.FromHtml("#E91677"));
                cb.SetColorFill(color);
                cb.SetFontAndSize(bf, 25);
                //cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "", 350, 1150, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 530, 1150, 0);
                cb.ShowText(this.HeadingText.ToUpper());
                cb.EndText();
            }

            if (!string.IsNullOrEmpty(this.HeaderText2))
            {

                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1257, BaseFont.NOT_EMBEDDED);

                PdfContentByte cb = writer.DirectContentUnder;
                cb.BeginText();
                //cb.SetTextMatrix(75, 1150);
                Color color = new Color(System.Drawing.ColorTranslator.FromHtml("#0000FF"));
                cb.SetColorFill(color);
                cb.SetFontAndSize(bf, 15);
                //cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "", 350, 1150, 0);
                cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 870, 1150, 0);
                cb.ShowText(this.HeaderText2.ToUpper());

                cb.EndText();
            }


            if (!string.IsNullOrEmpty(this.HeaderQty))
            {

                BaseFont bf1 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1257, BaseFont.NOT_EMBEDDED);

                PdfContentByte cb1 = writer.DirectContentUnder;
                cb1.BeginText();
                //cb.SetTextMatrix(75, 1150);
                Color color = new Color(System.Drawing.ColorTranslator.FromHtml("#0000FF"));
                cb1.SetColorFill(color);
                cb1.SetFontAndSize(bf1, 25);
                //cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "", 650, 1150, 0);
                cb1.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "", 30, 1150, 0);
                cb1.ShowText(this.HeaderQty.ToUpper());

                cb1.EndText();
            }
            if (!string.IsNullOrEmpty(this.HeaderDate))
            {

                BaseFont bf2 = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1257, BaseFont.NOT_EMBEDDED);

                PdfContentByte cb2 = writer.DirectContentUnder;
                cb2.BeginText();
                //cb.SetTextMatrix(75, 1150);
                Color color = new Color(System.Drawing.ColorTranslator.FromHtml("#0000FF"));
                cb2.SetColorFill(color);
                cb2.SetFontAndSize(bf2, 15);
                //cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "", 650, 1150, 0);
                cb2.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "", 1520, 1150, 0);
                cb2.ShowText(this.HeaderDate.ToUpper());

                cb2.EndText();
            }

        }
        //END

        public virtual void CreatePDFContent()
        {
            document.Add(new Paragraph("iKandi PDF"));
        }

        #endregion

        #region Private/protected Method

        protected void InitPDF()
        {
            document = new Document(((this.isLandScape) ? pageSize.Rotate() : pageSize), 25, 25, 25, 25);

            fileStream = new FileStream(this.FilePath, FileMode.Create);

            writer = PdfWriter.GetInstance(document, fileStream);

            document.Open();

            if (!string.IsNullOrEmpty(this.HeadingText))
            {

                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1257, BaseFont.NOT_EMBEDDED);

                PdfContentByte cb = writer.DirectContentUnder;
                cb.BeginText();
                //cb.SetTextMatrix(75, 1150);
                Color color = new Color(System.Drawing.ColorTranslator.FromHtml("#E91677"));
                cb.SetColorFill(color);
                cb.SetFontAndSize(bf, 25);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "", 650, 1150, 0);
                cb.ShowText(FirstLetterToUpper(this.HeadingText));

                cb.EndText();
            }

        }

        public string FirstLetterToUpper(string word)
        {
          return word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
        }


        protected void FinishPDF()
        {
            document.Close();
            document = null;
            writer = null;

            if (fileStream != null)
                fileStream.Dispose();

            fileStream = null;
        }

        #endregion

    }




}
