using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Data;
using System.Collections;
using System.Reflection;
using System.ComponentModel;

namespace iKandi.Common
{
    public class PDFTableGenerator : PDFGenerator
    {
        
        #region Properties

        public List<PDFHeader> HeaderTableColumns
        {
            get;
            set;
        }

        public List<List<PDFCell>> HeaderTableRows
        {
            get;
            set;
        }



        public List<PDFHeader> Columns
        {
            get;
            set;
        }

        public List<List<PDFCell>> Rows
        {
            get;
            set;
        }

        //public List<PDFHeader> ColumnTitles
        //{
        //    get;
        //    set;
        //}

        //public List<List<PDFCell>> TitleRows
        //{
        //    get;
        //    set;
        //}

        public List<float> TableColumnWidthCollection
        {
            get;
            set;
        }

        public bool HideMainTableCellBorder
        {
            get;
            set;
        }

        public string CellBorderColor
        {
            get;
            set;
        }

        public int PaddingTop
        {
            get;
            set;
        }

        public int PaddingBottom
        {
            get;
            set;
        }

        #endregion

        #region Public Methods

        public PDFTableGenerator(string FilePath)
            : base(FilePath)
        {

        }
        public PDFTableGenerator(string FilePath, string HeaderText)
            : base(FilePath, HeaderText)
        {

        }
        public PDFTableGenerator(string FilePath, string HeaderText, Color HeaderColor)
          : base(FilePath, HeaderText, HeaderColor)
        {
            TableColumnWidthCollection = new List<float>();
        }
        public PDFTableGenerator(string FilePath, string HeaderTexts, Color HeaderColor, int  Hight)
          : base(FilePath, HeaderTexts, HeaderColor, Hight)
        {
          TableColumnWidthCollection = new List<float>();
        }
        public PDFTableGenerator(string FilePath, string HeaderText, Color HeaderColor, string PageName)
            : base(FilePath, HeaderText, HeaderColor, PageName)
        {
            TableColumnWidthCollection = new List<float>();
        }
        //Added By Ashish on 1/6/2015
        public PDFTableGenerator(string FilePath, string HeaderQty, string HeaderText, string HeaderText2, string HeaderDate, Color HeaderColor)
            : base(FilePath, HeaderQty, HeaderText, HeaderText2, HeaderDate, HeaderColor)
        {
            TableColumnWidthCollection = new List<float>();
        }
        //END
        //public override void CreatePDFContent()
        //{
        //    if (this.Columns == null)
        //        return;

        //    _pdfTable = new PdfPTable(this.Columns.Count);

        //    this.CreateHeader();
        //    this.LoadData();

        //    document.Add(_pdfTable);
        //}


        public override void CreatePDFContent()
        {
            if (this.Columns == null)
                return;

            Paragraph paraNewLine = new Paragraph("\n");
            document.Add(paraNewLine);
            document.Add(paraNewLine);

            if (this.IsHeaderTable == true)
            {

                List<PDFHeader> objHeaderTable = this.HeaderTableColumns;
                List<List<PDFCell>> objHeaderRows = this.HeaderTableRows;
                PdfPTable objPdfHeaderTable = null;

                if (objHeaderTable.Count > 0)
                {
                    objPdfHeaderTable = new PdfPTable(objHeaderTable.Count);

                    this.CreateHeader(objPdfHeaderTable, objHeaderTable, (int)TablePosition.BeforeMainTable);
                }
                else if (objHeaderRows.Count > 0)
                {
                    objPdfHeaderTable = new PdfPTable(objHeaderRows[0].Count);

                }

                if (objPdfHeaderTable != null)
                {
                    this.LoadData(objPdfHeaderTable, objHeaderRows, (int)TablePosition.BeforeMainTable);
                }

                document.Add(objPdfHeaderTable);
                document.Add(paraNewLine);
                document.Add(paraNewLine);
            }

            List<PDFHeader> objMainHeader = this.Columns;
            List<List<PDFCell>> objMainRows = this.Rows;

            PdfPTable ObjMainPdfTable = null;

            if (objMainHeader.Count > 0)
            {
                ObjMainPdfTable = new PdfPTable(objMainHeader.Count);


                this.CreateHeader(ObjMainPdfTable, objMainHeader, (int)TablePosition.MainTable);
            }
            else if (objMainRows.Count > 0)
            {
                ObjMainPdfTable = new PdfPTable(objMainRows[0].Count);
            }

            // TODO
            //ObjMainPdfTable.DefaultCell.BorderColor = new Color(System.Drawing.ColorTranslator.FromHtml("#ffffff"));
            // ObjMainPdfTable.DefaultCell.BorderWidth = 0;


            if (ObjMainPdfTable != null)
            {
                this.LoadData(ObjMainPdfTable, objMainRows, (int)TablePosition.MainTable);

                document.Add(ObjMainPdfTable);
            }

        }

        #endregion

        #region Private Methods

        private void LoadData(PdfPTable objPdfTable, List<List<PDFCell>> objRows, int Position)
        {
            // If there is not header
            if (Position == (int)TablePosition.MainTable && this.Columns.Count == 0 && objRows.Count > 0)
            {
                float[] columnWidthInPct = new float[objRows[0].Count];

                for (int i = 0; i < objRows[0].Count; i++)
                {
                    columnWidthInPct[i] = 100f;
                }

                objPdfTable.WidthPercentage = 100; // percentage


                objPdfTable.SetTotalWidth(columnWidthInPct);

            }

            foreach (List<PDFCell> row in objRows)
            {
                for (int col = 0; col < row.Count; col++)
                {
                    PdfPCell cell;
                    if (row[col].PdfTable != null)
                        cell = new PdfPCell(row[col].PdfTable);
                    else if (row[col].PdfCell != null)
                        cell = new PdfPCell(row[col].PdfCell);
                    else if (row[col].PdfPhrase != null)
                        cell = new PdfPCell(row[col].PdfPhrase);
                    else
                    {
                        string text = row[col].CellText;
                        Chunk chunk = new Chunk(text);
                        Phrase phrase = new Phrase(chunk);

                        if (!string.IsNullOrEmpty(row[col].FontFamily))
                        {
                            chunk.Font = FontFactory.GetFont(row[col].FontFamily);
                        }
                        cell = new PdfPCell(phrase);
                        // For Font Relatex
                        if (row[col].FontSize > 0)
                        {
                            if (!string.IsNullOrEmpty(row[col].FontColor))
                            {
                                chunk.Font = new Font(chunk.Font.Family, (float)row[col].FontSize, Font.BOLD,
                                                      new Color(
                                                          System.Drawing.ColorTranslator.FromHtml(row[col].FontColor)));
                            }
                            else
                            {
                                chunk.Font = new Font(chunk.Font.Family, (float)row[col].FontSize);

                            }
                        }
                    }
                    // if(row[col].ColSpan!=0)
                    cell.Colspan = row[col].ColSpan;
                    if (this.HideMainTableCellBorder && Position == (int)TablePosition.MainTable)
                        cell.BorderWidth = 0;

                    if (!string.IsNullOrEmpty(this.CellBorderColor))
                        cell.BorderColor = new Color(System.Drawing.ColorTranslator.FromHtml(this.CellBorderColor));

                    if (Position == (int)TablePosition.MainTable)
                    {
                        if (row[col].HideBorderBottom)
                            cell.BorderWidthBottom = 0;

                        if (row[col].HideBorderTop)
                            cell.BorderWidthTop = 0;

                        if (row[col].HideBorderLeft)
                            cell.BorderWidthLeft = 0;

                        if (row[col].HideBorderRight)
                            cell.BorderWidthRight = 0;
                    }

                    // For cell Height

                    if (Position == (int)TablePosition.MainTable)
                    {
                        if (this.CellHeight > 0)
                        {
                            cell.FixedHeight = (float)this.CellHeight;
                        }
                    }
                    else if (Position == (int)TablePosition.BeforeMainTable)
                    {
                        if (this.HeaderTableBodyHeight > 0)
                        {
                            cell.FixedHeight = (float)this.HeaderTableBodyHeight;
                        }
                        else if (this.CellHeight > 0)
                        {
                            cell.FixedHeight = (float)this.CellHeight;
                        }
                    }


                    // for Padding

                    if (row[col].Padding > 0)
                    {
                        cell.Padding = (float)row[col].Padding;

                    }
                    else
                    {
                        //cell.PaddingLeft = 10;
                        //cell.PaddingRight = 10;
                        //cell.PaddingTop = 5;
                        //cell.PaddingBottom = 5;
                    }


                    // For Cell Alignmernt 

                    if (row[col].Alignment == ContentAlignment.Vertical)
                    {
                        cell.Rotation = 90;

                    }

                    // For Text Horizontal Alignment
                    if (row[col].TextHorizontalAlignment > -1)
                    {
                        cell.HorizontalAlignment = row[col].TextHorizontalAlignment;
                    }
                    else
                    {
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    }


                    // For Text Vertical Alignment
                    if (row[col].TextVerticalAlignment > -1)
                    {
                        cell.VerticalAlignment = row[col].TextVerticalAlignment;
                    }
                    else
                    {
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    }

                    // For Back Ground Color
                    if (!string.IsNullOrEmpty(row[col].BackGroundColor))
                    {
                        cell.BackgroundColor =
                            new Color(System.Drawing.ColorTranslator.FromHtml(row[col].BackGroundColor));
                    }


                    // For Image

                    if (!string.IsNullOrEmpty(row[col].ImageUrl))
                    {
                        Image jpeg = null;

                        try
                        {
                            jpeg = Image.GetInstance(row[col].ImageUrl);

                            //jpeg = Image.GetInstance(@"E:\Projects\iBoutique\SourceCode\iKandi\iKandi.Web\Uploads\style\SK 80019-FRONT.jpg");

                            row[col].ImageHeight = (row[col].ImageHeight == 0) ? 100f : row[col].ImageHeight;
                            row[col].ImageWidth = (row[col].ImageWidth == 0) ? 100f : row[col].ImageWidth;

                            jpeg.ScaleAbsolute(row[col].ImageWidth, row[col].ImageHeight);
                            jpeg.Alignment = Image.ALIGN_MIDDLE | Image.TEXTWRAP;

                            cell.AddElement(jpeg);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                            System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                            //eat
                        }

                    }

                    if (row[col].Height > 0)
                    {
                        cell.FixedHeight = row[col].Height;
                    }



                    objPdfTable.AddCell(cell);
                    //_pdfTable.AddCell(cell);
                }
            }
        }




        private void CreateHeader(PdfPTable objPdfTable, List<PDFHeader> objPdfHeader, int Position)
        {
            // define the column headers, sizes, etc.
            objPdfTable.DefaultCell.Padding = 4;  //in Points

            float[] columnWidthInPct = new float[objPdfHeader.Count];

            for (int i = 0; i < objPdfHeader.Count; i++)
            {
                if ((float)objPdfHeader[i].Width == 0)
                    columnWidthInPct[i] = 150f;
                else
                    columnWidthInPct[i] = (float)objPdfHeader[i].Width;

            }

            // set the total width of the table

            objPdfTable.WidthPercentage = 100; // percentage

            //_pdfTable.SetWidths(columnWidthInPct);
            objPdfTable.SetTotalWidth(columnWidthInPct);

            // Set Column Header Cell Attributes
            //_pdfTable.DefaultCell.BackgroundColor = Color.PINK;
            objPdfTable.DefaultCell.BorderWidth = 1;
            objPdfTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            objPdfTable.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;

            for (int col = 0; col < objPdfHeader.Count; col++)
            {
                Chunk chunk = new Chunk(objPdfHeader[col].ColumnName);
                Phrase phrase = new Phrase(chunk);

                PdfPCell cell = new PdfPCell(phrase);


                if (objPdfHeader[col].Alignment == ContentAlignment.Vertical)
                {
                    cell.Rotation = 90;
                    cell.Padding = (float)objPdfHeader[col].Padding;
                }
                else
                {
                    if (Position == (int)TablePosition.MainTable)
                    {
                        cell.PaddingTop = 50;
                        cell.PaddingBottom = 50;
                    }
                    if (this.PaddingTop > 0)
                        cell.PaddingTop = this.PaddingTop;
                    if (this.PaddingBottom > 0)
                        cell.PaddingBottom = this.PaddingBottom;
                }

                if (Position == (int)TablePosition.MainTable)
                {
                    cell.VerticalAlignment = 1; //(int)Element.ALIGN_BOTTOM;
                    cell.HorizontalAlignment = 1; // (int)Element.ALIGN_BOTTOM;
                }
                else
                {
                    cell.VerticalAlignment = (int)Element.ALIGN_MIDDLE;
                    cell.HorizontalAlignment = (int)Element.ALIGN_CENTER;
                }

                cell.BackgroundColor = Color;

                if (!string.IsNullOrEmpty(this.CellBorderColor))
                    cell.BorderColor = new Color(System.Drawing.ColorTranslator.FromHtml(this.CellBorderColor));

                PdfContentByte ContentByte = writer.DirectContent;
                ContentByte.BeginText();

                if (Position == (int)TablePosition.BeforeMainTable)
                {
                    if (this.HeaderTableHeaderHeight > 0)
                    {
                        cell.FixedHeight = (float)this.HeaderTableHeaderHeight;
                    }
                }

                if (objPdfHeader[col].Height > 0)
                {
                    cell.FixedHeight = (float)objPdfHeader[col].Height;
                }

                //BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                //ContentByte.SetFontAndSize(bf, 10);
                ////ContentByte.SetTextMatrix(280, 590);
                //ContentByte.SetTextMatrix(PdfContentByte.ALIGN_CENTER,cell.h 250, 700, 0);
                //ContentByte.ShowText(this.Columns);
                //ContentByte.EndText();

                if (objPdfHeader[col].ColumnSpan > 1)
                {
                    cell.Colspan = objPdfHeader[col].ColumnSpan;
                }

                objPdfTable.AddCell(cell);

            }

            objPdfTable.HeaderRows = 1;
        }


        #region Comments Code

        //private void LoadData()
        //{
        //    foreach (List<PDFCell> row in this.Rows)
        //    {
        //        for (int col = 0; col < row.Count; col++)
        //        {
        //            string text = row[col].CellText;
        //            Chunk chunk = new Chunk(text);
        //            Phrase phrase = new Phrase(chunk);
        //            PdfPCell cell = new PdfPCell(phrase);

        //            // For cell Height
        //            if (this.CellHeight > 0)
        //            {
        //                cell.FixedHeight = (float)this.CellHeight;
        //            }



        //            // For Font Relatex
        //            if (row[col].FontSize > 0)
        //            {
        //                if (!string.IsNullOrEmpty(row[col].FontColor))
        //                {
        //                    chunk.Font = new Font(chunk.Font.Family, (float)row[col].FontSize, Font.BOLD, new Color(System.Drawing.ColorTranslator.FromHtml(row[col].FontColor)));
        //                }
        //                else
        //                {
        //                    chunk.Font = new Font(chunk.Font.Family, (float)row[col].FontSize);

        //                }
        //            }

        //            // for Padding

        //            if (row[col].Padding > 0)
        //            {
        //                cell.Padding = (float)row[col].Padding;

        //            }
        //            else
        //            {
        //                //cell.PaddingLeft = 10;
        //                //cell.PaddingRight = 10;
        //                //cell.PaddingTop = 5;
        //                //cell.PaddingBottom = 5;
        //            }


        //            // For Cell Alignmernt 

        //            if (row[col].Alignment == ContentAlignment.Vertical)
        //            {
        //                cell.Rotation = 90;

        //            }

        //            // For Text Horizontal Alignment
        //            if (row[col].TextHorizontalAlignment > -1)
        //            {
        //                cell.HorizontalAlignment = row[col].TextHorizontalAlignment;
        //            }
        //            else
        //            {
        //                cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //            }


        //            // For Text Vertical Alignment
        //            if (row[col].TextVerticalAlignment > -1)
        //            {
        //                cell.VerticalAlignment = row[col].TextVerticalAlignment;
        //            }
        //            else
        //            {
        //                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
        //            }

        //            // For Back Ground Color
        //            if (!string.IsNullOrEmpty(row[col].BackGroundColor))
        //            {
        //                cell.BackgroundColor = new Color(System.Drawing.ColorTranslator.FromHtml(row[col].BackGroundColor));
        //            }

        //            // For Image

        //            if (!string.IsNullOrEmpty(row[col].ImageUrl))
        //            {
        //                Image jpeg = null;

        //                jpeg = Image.GetInstance(row[col].ImageUrl);

        //                //Image jpeg = Image.GetInstance(@"D:\Projects\iKandi\iKandi.Web\Uploads\Style\tp 83084 a.jpg");
        //                //Image jpeg = Image.GetInstance(@"D:\Projects\iKandi\iKandi.Web\Uploads\Style\thumb -74446280-a5f9-4a93-9db7-f15f0a5bc646.jpeg");

        //                jpeg.ScaleAbsolute(100f, 100f);
        //                jpeg.Alignment = Image.ALIGN_MIDDLE | Image.TEXTWRAP;

        //                cell.AddElement(jpeg);

        //            }

        //            _pdfTable.AddCell(cell);
        //        }
        //    }
        //}

        /*private void LoadData(IListSource dTable)
        {
            foreach (DataRow row in (dTable as DataTable).Rows)
            {
                for (int col = 0; col < this.Columns.Count; col++)
                {
                    string text = (row[col] == DBNull.Value) ? string.Empty : row[col].ToString();
                    Chunk chunk = new Chunk(text);
                    Phrase phrase = new Phrase(chunk);
                    _pdfTable.AddCell(phrase);
                }
            }
        }

        private void LoadData(ICollection dataList)
        {
            IEnumerator enumerator = dataList.GetEnumerator();

            while (enumerator.MoveNext())
            {
                foreach (PropertyInfo property in enumerator.Current.GetType().GetProperties())
                {
                    string text = property.GetValue(enumerator.Current, null).ToString();
                    Chunk chunk = new Chunk(text);
                    Phrase phrase = new Phrase(chunk);
                    _pdfTable.AddCell(phrase);
                }
            }
        }*/

        //private void CreateHeader()
        //{
        //    // define the column headers, sizes, etc.
        //    _pdfTable.DefaultCell.Padding = 4;  //in Points

        //    float[] columnWidthInPct = new float[this.Columns.Count];

        //    for (int i = 0; i < this.Columns.Count; i++)
        //    {
        //        if ((float)this.Columns[i].Width == 0)
        //            columnWidthInPct[i] = 150f;
        //        else
        //            columnWidthInPct[i] = (float)this.Columns[i].Width;
        //    }

        //    // set the total width of the table

        //    _pdfTable.WidthPercentage = 100; // percentage
        //    //_pdfTable.SetWidths(columnWidthInPct);
        //    _pdfTable.SetTotalWidth(columnWidthInPct);


        //    // Set Column Header Cell Attributes
        //    //_pdfTable.DefaultCell.BackgroundColor = Color.PINK;
        //    _pdfTable.DefaultCell.BorderWidth = 1;
        //    _pdfTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
        //    _pdfTable.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;


        //    for (int col = 0; col < this.Columns.Count; col++)
        //    {
        //        Chunk chunk = new Chunk(this.Columns[col].ColumnName);
        //        Phrase phrase = new Phrase(chunk);

        //        PdfPCell cell = new PdfPCell(phrase);

        //        if (this.Columns[col].Alignment == ContentAlignment.Vertical)
        //        {
        //            cell.Rotation = 90;
        //            cell.Padding = (float)this.Columns[col].Padding;


        //        }
        //        else
        //        {
        //            cell.PaddingTop = 50;
        //            cell.PaddingBottom = 50;

        //        }



        //        cell.VerticalAlignment = 1;

        //        //Color cellColor = new Color(System.Drawing.ColorTranslator.FromHtml("#F9DDF4"));
        //        //cell.BackgroundColor = cellColor;

        //        cell.BackgroundColor = Color;
        //        cell.HorizontalAlignment = 1;


        //        PdfContentByte ContentByte = writer.DirectContent;
        //        ContentByte.BeginText();

        //        //BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        //        //ContentByte.SetFontAndSize(bf, 10);
        //        ////ContentByte.SetTextMatrix(280, 590);
        //        //ContentByte.SetTextMatrix(PdfContentByte.ALIGN_CENTER,cell.h 250, 700, 0);
        //        //ContentByte.ShowText(this.Columns);
        //        //ContentByte.EndText();


        //        _pdfTable.AddCell(cell);

        //    }

        //    _pdfTable.HeaderRows = 1;
        //}
        #endregion

        #endregion

    }


    public class PDFHeader
    {       
        public PDFHeader(string ColumnName)
        {
            this.ColumnName = ColumnName.ToUpper();
            this.Alignment = ContentAlignment.Horizontal;
        }
        public PDFHeader(string ColumnName, string Capetlize)
        {
          this.ColumnName = Capitalize(ColumnName);
          this.Alignment = ContentAlignment.Horizontal;
        }

        public PDFHeader(string ColumnName, ContentAlignment Alignment)
        {
            this.ColumnName = ColumnName.ToUpper();
            this.Alignment = Alignment;
        }
        public PDFHeader(string ColumnName, ContentAlignment Alignment, int Width, string Capetlize)
        {
          this.ColumnName = Capitalize(ColumnName);
          this.Alignment = Alignment;
          this.Width = Width;
          this.FontSize = 12;
        }

        public string Capitalize(string word)
        {
          return word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
        }

        public PDFHeader(string ColumnName, ContentAlignment Alignment, int Width)
        {
            this.ColumnName = ColumnName.ToUpper();
            this.Alignment = Alignment;
            this.Width = Width;
        }

        public PDFHeader(string ColumnName, ContentAlignment Alignment, int Width, int Padding)
        {
            this.ColumnName = ColumnName.ToUpper();
            this.Alignment = Alignment;
            this.Width = Width;
            this.Padding = Padding;
        }
        public PDFHeader(string ColumnName, ContentAlignment Alignment, int Width, int Padding,int height,int FontSize)
        {
          this.ColumnName = ColumnName.ToUpper();
          this.Alignment = Alignment;
          this.Width = Width;
          this.Padding = Padding;
          this.Height = height;
          this.FontSize = FontSize;
          
        }
        public PDFHeader(string ColumnName, ContentAlignment Alignment, int Width, int Padding, Color BorderColor)
        {
            this.ColumnName = ColumnName.ToUpper();
            this.Alignment = Alignment;
            this.Width = Width;
            this.Padding = Padding;
            this.BorderColor = BorderColor;
          
          
        }

        public Color BorderColor
        {
            get;
            set;
        }

        public int ColumnSpan
        {
            get;
            set;
        }

        public int FontSize
        {
          get;
          set;
        }

        public string ColumnName
        {
            get;
            set;
        }

        public ContentAlignment Alignment
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public int Padding
        {
            get;
            set;
        }

        public int PaddingTop
        {
            get;
            set;
        }

        public int PaddingBottom
        {
            get;
            set;
        }
    }

    public class PDFCell
    {
        public Color BorderColor
        {
            get;
            set;
        }

        private int p;
        private ContentAlignment contentAlignment;
        private double p_2;

        public PDFCell(string cellText)
        {
            if (!string.IsNullOrEmpty(cellText))
            {
                this.CellText = cellText.ToUpper();
            }

            this.Alignment = ContentAlignment.Horizontal;
            this.ColSpan = 0;
        }

        public PDFCell(PdfPTable pdfTable)
        {
            if (pdfTable != null)
            {
                this.PdfTable = pdfTable;
            }
        }

        public PDFCell(PdfPCell pdfCell)
        {
            if (pdfCell != null)
            {
                this.PdfCell = pdfCell;
            }
        }

        public PDFCell(Phrase phrase)
        {
            if (phrase != null)
            {
                this.PdfPhrase = phrase;
            }
        }

        public PDFCell(Phrase phrase, Color BorderColor)
        {
            if (phrase != null)
            {
                this.PdfPhrase = phrase;
            }
            this.BorderColor = BorderColor;
        }

        public PDFCell(Phrase phrase, int border)
        {
            if (phrase != null)
            {
                this.PdfPhrase = phrase;
            }
            this.Border = border;
        }
        public PDFCell(Phrase phrase, int border, int width, PdfCell PdfCell)//abhishek
        {
          if (phrase != null)
          {
            this.PdfPhrase = phrase;
            this.PdfCell.Width = width;
          }
          //this.Border = border;
        }

        public PDFCell(string cellText, ContentAlignment Alignment)
        {
            if (!string.IsNullOrEmpty(cellText))
            {
                this.CellText = FirstLetterToUpper(cellText);
            }
            this.Alignment = Alignment;
            this.ColSpan = 0;
        }

        public PDFCell(string cellText, ContentAlignment Alignment, int Width)
        {
            if (!string.IsNullOrEmpty(cellText))
            {
                this.CellText = cellText.ToUpper();
            }

            this.Alignment = Alignment;
            this.Width = Width;
            this.ColSpan = 0;
        }
      //abhishek 17/12/18
        //public PDFCell(string cellText, int border, int Width)
        //{
        //  if (!string.IsNullOrEmpty(cellText))
        //  {
        //    this.CellText = cellText.ToUpper();
        //  }
        //  this.Width = Width;
        //  this.ColSpan = 0;
        //  //this.Border = border;
        //}
      //end
        public PDFCell(string cellText, ContentAlignment Alignment, string Header)
        {
            if (!string.IsNullOrEmpty(cellText))
            {
                this.CellText = cellText;
            }
            this.Alignment = Alignment;
            this.ColSpan = 0;
        }

        public PDFCell(int p, ContentAlignment contentAlignment)
        {
            // TODO: Complete member initialization
            this.p = p;
            this.contentAlignment = contentAlignment;
        }

        public PDFCell(double p_2, ContentAlignment contentAlignment)
        {
            // TODO: Complete member initialization
            this.p_2 = p_2;
            this.contentAlignment = contentAlignment;
        }

        public string FirstLetterToUpper(string word)
        {
          return word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
        }


        public string FontFamily
        {
            get;
            set;
        }

        public string CellText
        {
            get;
            set;
        }

        public ContentAlignment Alignment
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }

        public float Height
        {
            get;
            set;
        }

        public int FontSize
        {
            get;
            set;
        }

        public string FontColor
        {
            get;
            set;
        }

        public string BackGroundColor
        {
            get;
            set;
        }

        public int Border
        {
            get;
            set;
        }

        public string ImageUrl
        {
            get;
            set;
        }

        public float ImageHeight
        {
            get;
            set;
        }

        public float ImageWidth
        {
            get;
            set;
        }

        public int Padding
        {
            get;
            set;
        }

        public int TextHorizontalAlignment
        {
            get;
            set;
        }

        public int TextVerticalAlignment
        {
            get;
            set;
        }

        public bool HideBorderTop
        {
            get;
            set;
        }

        public bool HideBorderLeft
        {
            get;
            set;
        }

        public bool HideBorderRight
        {
            get;
            set;
        }

        public bool HideBorderBottom
        {
            get;
            set;
        }

        public int ColSpan
        {
            get;
            set;
        }

        public PdfPTable PdfTable
        {
            get;
            set;
        }

        public PdfPCell PdfCell
        {
            get;
            set;
        }

        public Phrase PdfPhrase
        {
            get;
            set;
        }
    }


    public enum ContentAlignment
    {
        Horizontal = 1,
        Vertical = 2,
        Left = 3,
        Right = 4

    }

    public enum TablePosition
    {
        BeforeMainTable = 1,
        MainTable = 2
    }
}
