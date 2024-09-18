using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace ClientApp.Pages
{
    public class IndexModel : PageModel
    {
        IConfiguration config;
        string BaseURL;

        public IndexModel(IConfiguration _config)
        {
            config = _config;
            BaseURL = config.GetValue<string>("ApiBaseUrl");
        }


        [BindProperty]
        public List<Employee> employees { get; set; }

       
        public void OnGet()
        {
            // call API to get employee list

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, BaseURL + "GetAllEmployees");

            // string payloadJson = JsonConvert.SerializeObject(payload);
            //request.Content = new StringContent(payloadJson, Encoding.UTF8, "application/json");

            var response = client.SendAsync(request).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                //process output
                string result = response.Content.ReadAsStringAsync().Result;

                //deserialize result into return object
                employees =  JsonSerializer.Deserialize<List<Employee>>(result);               

            }
        }
    }
}