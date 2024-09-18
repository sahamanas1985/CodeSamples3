using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text;
using System.Text.Json;

namespace ClientApp.Pages
{
    public class PrivacyModel : PageModel
    {
        IConfiguration config;
        string BaseURL;

        public PrivacyModel(IConfiguration _config)
        {
            config = _config;
            BaseURL = config.GetValue<string>("ApiBaseUrl");
        }        

        [BindProperty]
        public Employee emp { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // call API to get employee list
                        
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, BaseURL + "AddNewEmployee");

            string payloadJson = JsonSerializer.Serialize(emp);
            request.Content = new StringContent(payloadJson, Encoding.UTF8, "application/json");

            var response = client.SendAsync(request).Result;

            
            return RedirectToPage("/Index");
            
        }
    }
}