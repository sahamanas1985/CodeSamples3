using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiSelectRazor.Models;

namespace MultiSelectRazor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<SelectListItem> CountryNames { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string[] countryNamesDB = new string[] { "Select a Country", "India", "USA", "Australia", "Canada", "Italy" };

            CountryNames = new List<SelectListItem>();

            foreach (string country in countryNamesDB)
            {
                bool isSelected = false;
                
                CountryNames.Add(new SelectListItem
                {
                    Text = country,
                    Value = country,
                    Selected = isSelected
                });
            }


            HttpContext.Session.SetString("TestKey", "TestValue");
        }

        public JsonResult OnPostGetCityList([FromBody] CountryModel country)
        {
            string[] citynames = new string[] { };
            
            switch (country.CountryName){
                case "India":
                    citynames = new string[] { "Delhi", "Mumbai", "Kolkata", "Chennai", "Bangalore" };
                    break;
                case "USA":
                    citynames = new string[] { "New York", "Chicago", "Washington", "Los Angeles", "Boston" };
                    break;
                case "Australia":
                    citynames = new string[] { "Melborne", "Adeilede", "Parth" };
                    break;
                case "Canada":
                    citynames = new string[] { "Toronto", "Vancuver" };
                    break;
                case "Italy":
                    citynames = new string[] { "Rome", "Florence", "Venice", "Milan" };
                    break;
            }

            return new JsonResult(citynames.ToList());

        }



    }

    
}