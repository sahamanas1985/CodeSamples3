using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CaptchaDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _config;

        [BindProperty]
        public string username { get; set; }
        [BindProperty]
        public string password { get; set; }
        public string CaptchaKey { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public void OnGet()
        {
            CaptchaKey = _config.GetSection("RecaptchaSiteKey").Value;
        }

        public void OnPost()
        {
            //  validate userid and password here from database
            string UsernameEntered = username;
            var PasswordEntered = password;
        }

    }
}