using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Super.SuperMarket.DAl.SQLServer.Model;

namespace Super.SuperMarket.InterFace.report
{
    public class PayReport
    {
        int _totalColumn = 3;
        Document _Document;
        Font _fontstyle;
        PdfPTable _PdfPTable = new PdfPTable(3);
        PdfPCell _PdfPCell;
        MemoryStream _MemoryStream = new MemoryStream();
        List<CartLine> _cartLines = new List<CartLine>();
        public byte[] PrepareReport (List<CartLine> cartLinesPram)
        {
            this._cartLines = cartLinesPram;

            _Document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _Document.SetPageSize(PageSize.A4);
            _Document.SetMargins(20f, 20f, 20f, 20f);
            _PdfPTable.WidthPercentage = 100;
            _PdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontstyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_Document, _MemoryStream);
            _Document.Open();
            _PdfPTable.SetWidths(new float[] { 20f, 150f, 100f });
            this.ReportHeader();
            this.ReportBody();
            _Document.Add(_PdfPTable);
            _Document.Close();
            return _MemoryStream.ToArray();


        }

        private void ReportBody()
        {
            _fontstyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _PdfPCell = new PdfPCell(new Phrase("Serial num ", _fontstyle));
            _PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _PdfPCell.ExtraParagraphSpace = 0;
            _PdfPTable.AddCell(_PdfPCell);

            _PdfPCell = new PdfPCell(new Phrase("Product name ", _fontstyle));
            _PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _PdfPCell.ExtraParagraphSpace = 0;
            _PdfPTable.AddCell(_PdfPCell);

            _PdfPCell = new PdfPCell(new Phrase("Quentity ", _fontstyle));
            _PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _PdfPCell.ExtraParagraphSpace = 0;
            _PdfPTable.AddCell(_PdfPCell);

            _PdfPCell = new PdfPCell(new Phrase("Total Price ", _fontstyle));
            _PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _PdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _PdfPCell.ExtraParagraphSpace = 0;
            _PdfPTable.AddCell(_PdfPCell);
            _PdfPTable.CompleteRow();


            _fontstyle = FontFactory.GetFont("Tahoma", 8f, 0);
            int serialNumber = 1;
            foreach (CartLine item in _cartLines)
            {
                _PdfPCell = new PdfPCell(new Phrase(serialNumber++.ToString(), _fontstyle));
                _PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                _PdfPTable.AddCell(_PdfPCell);

                _PdfPCell = new PdfPCell(new Phrase(item.Product.Name, _fontstyle));
                _PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                _PdfPTable.AddCell(_PdfPCell);

                _PdfPCell = new PdfPCell(new Phrase(item.Quantity.ToString(), _fontstyle));
                _PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                _PdfPTable.AddCell(_PdfPCell);

                _PdfPCell = new PdfPCell(new Phrase((item.Quantity*item.Product.SellingPrice).ToString(), _fontstyle));
                _PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _PdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _PdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                _PdfPTable.AddCell(_PdfPCell);
                _PdfPTable.CompleteRow();
            }

        }

        private void ReportHeader()
        {
            _fontstyle = FontFactory.GetFont("Tahoma",11f,1);
            _PdfPCell = new PdfPCell(new Phrase("My invoice ", _fontstyle));
            _PdfPCell.Colspan = _totalColumn;
            _PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfPCell.Border = 0;
            _PdfPCell.BackgroundColor = BaseColor.WHITE;
            _PdfPCell.ExtraParagraphSpace = 0;
            _PdfPTable.AddCell(_PdfPCell);
            _PdfPTable.CompleteRow();

            _fontstyle = FontFactory.GetFont("Tahoma", 11f, 1);
            _PdfPCell = new PdfPCell(new Phrase("Product list ", _fontstyle));
            _PdfPCell.Colspan = _totalColumn;
            _PdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _PdfPCell.Border = 0;
            _PdfPCell.BackgroundColor = BaseColor.WHITE;
            _PdfPCell.ExtraParagraphSpace = 0;
            _PdfPTable.AddCell(_PdfPCell);
            _PdfPTable.CompleteRow();

        }
    }
}