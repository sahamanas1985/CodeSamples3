using DocumentFormat.OpenXml.Packaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OpenXmlPowerTools;
using System.Xml.Linq;

namespace DocViewer.Pages
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

        public IActionResult OnPostHtmlFromWord(int docid)
        {

            var contentRootPath = (string)AppDomain.CurrentDomain.GetData("WebRootPath");
            string WordDocPath = Path.Combine(contentRootPath, "docs\\sampleword.docx");            
            string HtmlString = GetHtmlFromDocx(WordDocPath);            
            return new JsonResult(HtmlString);
        }


        private static string GetHtmlFromDocx(string Filepath)
        {
            byte[] byteArray = System.IO.File.ReadAllBytes(Filepath);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                memoryStream.Write(byteArray, 0, byteArray.Length);
                using (WordprocessingDocument doc = WordprocessingDocument.Open(memoryStream, true))
                {
                    HtmlConverterSettings settings = new HtmlConverterSettings()
                    {
                        PageTitle = "DTA Template",
                        FabricateCssClasses = true
                    };
                    XElement html = HtmlConverter.ConvertToHtml(doc, settings);

                    return html.ToStringNewLineOnAttributes();
                }
            }

        }


    }
}