using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;


namespace iKandi.Common
{
    public class ExcelGenerator
    {
        #region Fields

        private StringBuilder htmlString = null;

        #endregion


        #region Properties

        public string HeadingText
        {
            get;
            set;
        }

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

        public List<ExcelHeader> HeaderTableColumns
        {
            get;
            set;
        }

        public List<List<ExcelCell>> HeaderTableRows
        {
            get;
            set;
        }



        public List<ExcelHeader> Columns
        {
            get;
            set;
        }

        public List<List<ExcelCell>> Rows
        {
            get;
            set;
        }

        public List<float> TableColumnWidthCollection
        {
            get;
            set;
        }


        #endregion

        #region Ctor(s)

        public ExcelGenerator(string PDFFilePath)
        {

            this.FilePath = PDFFilePath;
            TableColumnWidthCollection = new List<float>();
        }

        public ExcelGenerator(string PDFFilePath, string PDFHeadingText)
        {

            this.FilePath = PDFFilePath;
            this.HeadingText = PDFHeadingText;
            TableColumnWidthCollection = new List<float>();

        }


        #endregion

        #region Public Methods

        public bool GenerateExcel()
        {
            this.InitExcel();

            this.CreateExcelContent();

            this.FinishExcel();

            return true;
        }

        public virtual void CreateExcelContent()
        {
            if (this.Columns == null)
                return;
            if (!string.IsNullOrEmpty(this.HeadingText))
            {
                htmlString.Append("<BR />");
                htmlString.Append("<DIV style=' width : 100 %; text-align :center; background-color :#FFFF99 ;'>");
                htmlString.Append(this.HeadingText.ToUpper());
                htmlString.Append("</DIV>");
            }
            htmlString.Append("<BR />");
            if (this.IsHeaderTable == true)
            {

                List<ExcelHeader> objHeaderTable = this.HeaderTableColumns;
                List<List<ExcelCell>> objHeaderRows = this.HeaderTableRows;


                this.CreateHeader(objHeaderTable, (int)TablePosition.BeforeMainTable);
                this.LoadData(objHeaderRows, (int)TablePosition.BeforeMainTable);


            }

            List<ExcelHeader> objMainHeader = this.Columns;
            List<List<ExcelCell>> objMainRows = this.Rows;

            this.CreateHeader(objMainHeader, (int)TablePosition.MainTable);
            this.LoadData(objMainRows, (int)TablePosition.MainTable);

        }

        #endregion

        #region Private/protected Method

        protected void InitExcel()
        {

            htmlString = new StringBuilder();


        }


        protected void FinishExcel()
        {

            File.WriteAllText(this.FilePath, htmlString.ToString());
        }




        private void CreateHeader(List<ExcelHeader> objPdfHeader, int Position)
        {

            htmlString.Append("<TABLE width=100% cellpadding=0 cellspacing=0 border=1>");
            htmlString.Append("<TR>");
            for (int col = 0; col < objPdfHeader.Count; col++)
            {
                htmlString.Append("<TH style='text-align :");
                
                // To Set Text alignment
                string align = Enum.GetName(typeof(TextAlignment), objPdfHeader[col].TextAlign) + " ;";
                htmlString.Append(align);

                // To Set BackGround Color
                if(! String.IsNullOrEmpty(objPdfHeader[col].BackGroundColor))
                {
                    string bg = "background-color : " + objPdfHeader[col].BackGroundColor + " ;";
                    htmlString.Append(bg);
                }

                // To Set Font Color
                if (!String.IsNullOrEmpty(objPdfHeader[col].FontColor))
                {
                    string fontColor = "color : " + objPdfHeader[col].FontColor + " ;";
                    htmlString.Append(fontColor);
                }

                // To Set Font size
                if (objPdfHeader[col].FontSize > 0)
                {
                    string fontSize = "font-size : " + objPdfHeader[col].FontSize + " ;";
                    htmlString.Append(fontSize);
                }


                // To Set Font weight
                if (objPdfHeader[col].Isbold  == true)
                {
                    string bold = "font-weight : bold;";
                    htmlString.Append(bold);
                }

                // To Set Column width
                if (objPdfHeader[col].Width > 0)
                {
                    string width = "width : " + objPdfHeader[col].Width + "% ;";
                    htmlString.Append(width);
                }

                // To Set Column padding
                if (objPdfHeader[col].Padding > 0)
                {
                    string padding = "padding : " + objPdfHeader[col].Padding + " ;";
                    htmlString.Append(padding);
                }

                htmlString.Append("'");
                htmlString.Append(">");
                
                // To Set Column width
                if (!String.IsNullOrEmpty(objPdfHeader[col].ColumnName))
                {
                    htmlString.Append(objPdfHeader[col].ColumnName.ToUpper());
                }

                htmlString.Append("</TH>");
            }
            
            htmlString.Append("</TR>");

        }


        private void LoadData(List<List<ExcelCell>> objRows, int Position)
        {
            foreach (List<ExcelCell> row in objRows)
            {
                htmlString.Append("<TR>");

                for (int col = 0; col < row.Count; col++)
                {
                    htmlString.Append("<TD style='text-align :");

                    // To Set Text alignment
                    string align = Enum.GetName(typeof(TextAlignment), row[col].TextAlign) + " ; ";
                    htmlString.Append(align);

                    // To Set BackGround Color
                    if (!String.IsNullOrEmpty(row[col].BackGroundColor))
                    {
                        string bg = "background-color : " + row[col].BackGroundColor + " ; ";
                        htmlString.Append(bg);
                    }

                    // To Set Font Color
                    if (!String.IsNullOrEmpty(row[col].FontColor))
                    {
                        string fontColor = "color : " + row[col].FontColor + " ; ";
                        htmlString.Append(fontColor);
                    }

                    // To Set Font size
                    if (row[col].FontSize > 0)
                    {
                        string fontSize = "font-size : " + row[col].FontSize + " ; ";
                        htmlString.Append(fontSize);
                    }


                    // To Set Font weight
                    if (row[col].Isbold == true)
                    {
                        string bold = "font-weight : bold; ";
                        htmlString.Append(bold);
                    }

                    // To Set Column width
                    if (row[col].Width > 0)
                    {
                        string width = "width : " + row[col].Width + "% ; ";
                        htmlString.Append(width);
                    }

                    // To Set Column padding
                    if (row[col].Padding > 0)
                    {
                        string padding = "padding : " + row[col].Padding + " ; ";
                        htmlString.Append(padding);
                    }
                    htmlString.Append("'");
                    htmlString.Append(">");

                    // To Set Column width
                    if (!String.IsNullOrEmpty(row[col].CellText))
                    {
                        htmlString.Append(row[col].CellText.ToUpper());
                    }

                    htmlString.Append("</TD>");
                }

                htmlString.Append("</TR>");
            }

            htmlString.Append("</TABLE>");
        }

        #endregion

    }


    public class ExcelHeader
    {
        public ExcelHeader(string ColumnName)
        {
            this.ColumnName = ColumnName.ToUpper();
            this.TextAlign =  TextAlignment.center;
        }

        public ExcelHeader(string ColumnName, TextAlignment Alignment)
        {
            this.ColumnName = ColumnName.ToUpper();
            this.TextAlign = Alignment;
        }

        public ExcelHeader(string ColumnName, TextAlignment Alignment, int Width)
        {
            this.ColumnName = ColumnName.ToUpper();
            this.TextAlign = Alignment;
            this.Width = Width;
        }

        public ExcelHeader(string ColumnName, TextAlignment Alignment, int Width, int Padding)
        {
            this.ColumnName = ColumnName.ToUpper();
            this.TextAlign = Alignment;
            this.Width = Width;
            this.Padding = Padding;
        }

        public string ColumnName
        {
            get;
            set;
        }

        public TextAlignment TextAlign
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }

        public int Padding
        {
            get;
            set;
        }

        public string FontColor
        {
            get;
            set;
        }

        public int FontSize
        {
            get;
            set;
        }

        public bool Isbold
        {
            get;
            set;
        }

        public string BackGroundColor
        {
            get;
            set;
        }
    }

    public class ExcelCell
    {
        public ExcelCell(string cellText)
        {
            if (!string.IsNullOrEmpty(cellText))
            {
                this.CellText = cellText.ToUpper();
            }

            this.TextAlign = TextAlignment.center;
        }

        public ExcelCell(string cellText, TextAlignment Alignment)
        {
            if (!string.IsNullOrEmpty(cellText))
            {
                this.CellText = cellText.ToUpper();
            }
            this.TextAlign = Alignment;
        }

        public ExcelCell(string cellText, TextAlignment Alignment, int Width)
        {
            if (!string.IsNullOrEmpty(cellText))
            {
                this.CellText = cellText.ToUpper();
            }
            this.TextAlign = Alignment;
            this.Width = Width;
        }

        public string CellText
        {
            get;
            set;
        }

        public TextAlignment TextAlign
        {
            get;
            set;
        }

        public int Width
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

        public bool Isbold
        {
            get;
            set;
        }

        public string BackGroundColor
        {
            get;
            set;
        }

        public string ImageUrl
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

    }

    public enum TextAlignment
    {
        center = 1,
        left = 2,
        right = 3

    }

    public enum FontWeight
    {
        bold = 1,
        normal = 2  
    }





}
