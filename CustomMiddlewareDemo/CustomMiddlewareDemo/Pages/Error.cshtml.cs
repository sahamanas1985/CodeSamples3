using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace CustomMiddlewareDemo.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        public string? ErrorMessage { get; set; }
        public string? StackTrace { get; set; }

        //public bool ShowRequestId => !string.IsNullOrEmpty(ErrorMessage);

        private readonly ILogger<ErrorModel> _logger;

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {            
            ErrorMessage = HttpContext.Session.GetString("errormsg") ?? "";
            StackTrace = HttpContext.Session.GetString("stacktrace") ?? "";
        }
    }
}