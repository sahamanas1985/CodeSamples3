using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PdfToHtmlNet;

namespace PDFToHtml.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        [BindProperty]
        public string HtmlString { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string PdfPath = @"C:\Manas\FilePath\payload1.pdf";
            string HtmlPath = @"C:\Manas\FilePath\payload2.Html";
            Converter con = new Converter();
            con.ConvertToFile(PdfPath, HtmlPath);
           
            HtmlString = System.IO.File.ReadAllText(HtmlPath);

        }
    }
}