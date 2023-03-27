using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FizzBuzzWeb.Forms;

namespace FizzBuzzWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public FizzBuzzForm FizzBuzz { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        public string Text { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = "User";
            }
           
        }
        public IActionResult OnPost()
        {
            if (FizzBuzz.Number % 3 == 0 & FizzBuzz.Number % 5==0)
            {
                Text = "FizzBuzz";
            }
            else if (FizzBuzz.Number % 3 == 0)
            {
                Text = "Fizz";
            }
            else if (FizzBuzz.Number % 5 == 0)
            {
                Text = "Buzz";
            }
            else
            {
                Text = "Liczba: " + FizzBuzz.Number + " nie spelnia kryteriow FizzBuzz";
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("./Privacy");
        }

    }
}