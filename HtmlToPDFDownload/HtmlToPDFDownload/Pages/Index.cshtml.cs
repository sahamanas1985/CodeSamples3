using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PdfSharp.Pdf;
using System.Text;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace HtmlToPDFDownload.Pages
{
    public class IndexModel : PageModel
    {        

        public void OnGet()
        {

        }

        public IActionResult OnPostDownloadPdf()
        {
            /* Install following 3 Nuget Packages
            
            System.Drawing.Common
            HtmlRenderer.PdfSharp
            HtmlRenderer.Core

            */

            
            string HtmlString = @"<html>
            <body>
            <h3 style='color:Tomato;'>Hello World</h3>
            <p style='color:DodgerBlue;'>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p>
            <p style='color:MediumSeaGreen;'>Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat.</p>
            </body>
            </html>";
            

            // Convert HTML String to PDF using PdfSharp

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            PdfDocument pdfDoc = PdfGenerator.GeneratePdf(HtmlString, PdfSharp.PageSize.A4);

            byte[] fileContents = null;
            using (MemoryStream stream = new MemoryStream())
            {
                pdfDoc.Save(stream, true);
                fileContents = stream.ToArray();
            }

            return new FileStreamResult(new MemoryStream(fileContents), "application/pdf");

        }


    }
}