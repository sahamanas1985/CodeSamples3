using Microsoft.AspNetCore.Mvc;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Text;

namespace EditableTable.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        [BindProperty]
        public DataTable MyDataTable { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            IFormFile uploadedFile = Request.Form.Files[0];

            MyDataTable = GetDataTableFromExcel(uploadedFile);

        }


        private DataTable GetDataTableFromExcel(IFormFile UploadedFile)
        {
            // support characters from all encodings
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            DataTable dt = new DataTable();

            using (Stream stream = UploadedFile.OpenReadStream())
            {
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                DataSet result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

                dt = result.Tables[0];

            }

            return dt;
        }


    }
}