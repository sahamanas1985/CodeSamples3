using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;


namespace OktaDotNetSix.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        [BindProperty]
        public Dictionary<string, string?> userinfo { get; set; }

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        //[Authorize]
        public void OnGet()
        {
            // check if user is authenticated

            if(User.Identity != null && User.Identity.IsAuthenticated)
            {
                // populate model and render page.

                ClaimsIdentity identity = (ClaimsIdentity) User.Identity;

                string? UserId = identity.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;
                string? given_name = identity.Claims.FirstOrDefault(x => x.Type == "given_name")?.Value;
                string? family_name = identity.Claims.FirstOrDefault(x => x.Type == "family_name")?.Value;

                userinfo = new Dictionary<string, string?>();
                userinfo.Add("IsAuthenticated", "true");
                userinfo.Add("UserId", UserId);
                userinfo.Add("FirstName", given_name);
                userinfo.Add("LastName", family_name);

            }
            else
            {
                // show Okta sign in page
                Response.Redirect("/Account/Login");
            }
                  

        }

    }
}