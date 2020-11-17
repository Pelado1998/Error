using System.Collections.Generic;
using PII_HTML_API;

namespace Bankbot
{
    public class HtmlPrinter : IPrinter
    {
        public HtmlPrinter()
        {
        }

        public void Print(List<Transaction> list)
        {
            HtmlDocument doc = new HtmlDocument("test.html", "Historial");
            doc.AddContent(new Span("Historial"));
            doc.AddContent(new Table(

                RenderHeader(list),

                RenderRows(list),

                new FooterRow(
                new List<FooterCell>() {
                    new FooterCell("")
                })
            ));
        }
        private HeaderRow RenderHeader(List<Transaction> list)
        {
            var header = new HeaderRow(
                    new List<HeaderCell>()
                    {
                        new HeaderCell("Currency"),
                        new HeaderCell("Amount"),
                        new HeaderCell("Date"),
                        new HeaderCell("Item")
                    });

            return header;
        }
        private List<Row> RenderRows(List<Transaction> list)
        {
            var rows = new List<Row>();
            foreach (var item in list)
            {
                var cell = new List<Cell>();

                cell.Add(new Cell(item.Currency.CodeISO));
                cell.Add(new Cell(item.Amount.ToString()));
                cell.Add(new Cell(item.Date.ToString("dd/MM/yyyy")));
                cell.Add(new Cell(item.Description));

                rows.Add(new Row(cell));
            }

            return rows;
        }
    }
}