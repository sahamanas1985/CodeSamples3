using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace ExportExcelTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            // Create a dummy data table
            DataSet ds = MakeDummyDataSet();
            
            //Export Excel via Memory Stream
            MemoryStream ms = ExportDataSetViaMemoryStream(ds);
            return new FileStreamResult(ms, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
                

        public IActionResult OnPostAjaxExport(string somedata)
        {
            // Create a dummy data table
            DataSet ds = MakeDummyDataSet();

            //Export Excel via Memory Stream
            MemoryStream ms = ExportDataSetViaMemoryStream(ds);
            return new FileStreamResult(ms, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }


        public IActionResult OnPostDownloadPreGeneratedFile(string filetype)
        {
            string FilePath = "";
            string ContentType = "";
            
            //read file from Path
            if(filetype == "pdf")
            {
                FilePath = @"C:\Manas\FilePath\DownloadTest\payload1.pdf";
                ContentType = "application/pdf";
            }
            else if(filetype == "excel")
            {
                FilePath = @"C:\Manas\FilePath\DownloadTest\payload2.xlsx";
                ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            }
           
            var stream = new FileStream(FilePath, FileMode.Open);
            return new FileStreamResult(stream, ContentType);                        
        }

                   
      

        public static DataSet MakeDummyDataSet()
        {

            // Manas: Create a dummy data table.

            DataTable dt = new DataTable();

            dt.Columns.Add("Name");
            dt.Columns.Add("Gender");
            dt.Columns.Add("Job");
            dt.Columns.Add("Age");

            dt.Rows.Add(new object[] { "Rachel Green", "Female", "Assistant Buyer", "30" });
            dt.Rows.Add(new object[] { "Ross Geller", "Male", "Paleontologist", "32" });
            dt.Rows.Add(new object[] { "Chandler Bing", "Male", "Accountant", "32" });
            dt.Rows.Add(new object[] { "Monica Geller", "Female", "Chef", "30" });
            dt.Rows.Add(new object[] { "Pheobe Buffey", "Female", "Singer", "34" });
            dt.Rows.Add(new object[] { "Joey Tribbiani", "Male", "Actor", "31" });
            dt.Rows.Add(new object[] { "Gunther", "Male", "Waiter", "33" });
            dt.Rows.Add(new object[] { "Janice", "Female", "Stock Broker", "30" });
            
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);

            return ds;
        }

               
        private MemoryStream ExportDataSetViaMemoryStream(DataSet ds)
        {
            MemoryStream memoryStream = new MemoryStream();

            using (var workbook = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = workbook.AddWorkbookPart();

                workbook.WorkbookPart.Workbook = new Workbook();

                workbook.WorkbookPart.Workbook.Sheets = new Sheets();

                foreach (DataTable table in ds.Tables)
                {

                    var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                    var sheetData = new SheetData();
                    sheetPart.Worksheet = new Worksheet(sheetData);

                    Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<Sheets>();
                    string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);

                    uint sheetId = 1;
                    if (sheets.Elements<Sheet>().Count() > 0)
                    {
                        sheetId =
                            sheets.Elements<Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                    }

                    Sheet sheet = new Sheet() { Id = relationshipId, SheetId = sheetId, Name = table.TableName };
                    sheets.Append(sheet);

                    Row headerRow = new Row();

                    List<string> columns = new List<string>();
                    foreach (DataColumn column in table.Columns)
                    {
                        columns.Add(column.ColumnName);

                        Cell cell = new Cell();
                        cell.DataType = CellValues.String;
                        cell.CellValue = new CellValue(column.ColumnName);
                        headerRow.AppendChild(cell);
                    }


                    sheetData.AppendChild(headerRow);

                    foreach (DataRow dsrow in table.Rows)
                    {
                        Row newRow = new Row();
                        foreach (string col in columns)
                        {
                            Cell cell = new Cell();
                            cell.DataType = CellValues.String;
                            cell.CellValue = new CellValue(dsrow[col].ToString());
                            newRow.AppendChild(cell);
                        }

                        sheetData.AppendChild(newRow);
                    }

                }                

            }

            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream;

        }



    }
}