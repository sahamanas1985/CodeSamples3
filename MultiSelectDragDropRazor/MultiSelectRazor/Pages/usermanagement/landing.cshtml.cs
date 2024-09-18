using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MultiSelectRazor.Pages.usermanagement
{
    public class landingModel : PageModel
    {
        public IConfiguration _config { get; set; }

        public landingModel(IConfiguration config)
        {
            _config = config;
        }

        public void OnGet(string? action)
        {
            //string aaa = _config.GetSection("vdmDBName").Value;
            
            //HttpContext.Session.SetString("logoutUrl", 
            //    Request.Scheme + "://" + Request.Host.Value + 
            //    "/usermanagement/landing?action=logout");
            //    


        }

        public void OnPost()
        {
            string Name = Request.Form["txtName"].ToString();
        }

    }
}
