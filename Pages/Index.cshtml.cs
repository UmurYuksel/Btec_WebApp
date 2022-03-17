using Btec_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Btec_WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        //Initials
        public float number1, number2, result;
        private bool isNumber1, isNumber2;
        public string operationType, message;

        //Properties.
        public bool HasData { get; set; } = false;
        public bool IsError { get; set; } = false;
        public List<SelectListItem> Options { get; set; } = new List<SelectListItem>() {
                new SelectListItem() { Text = "Add", Value = "Add" },
                new SelectListItem() { Text = "Multiply", Value = "Multiply" }
    };
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }


        public void OnGet()
        {
  
        }

        public void OnPost()
        {
            HasData = true;
            //Checking if the user provided correct types =>
            isNumber1 = float.TryParse(Request.Form["number1"], out number1);
            isNumber2 = float.TryParse(Request.Form["number2"], out number2);
            //is it Add or Multiply operation ? =>
            operationType = Request.Form["operation"];

            //if both numbers are ok =>
            if (isNumber1 && isNumber2)
            {
                //Calculation happens here =>
                Calculator calc = new Calculator(number1, number2, operationType);

                //If there is something wrong, return error message to the user =>
                if (calc.IsError)
                {
                    IsError = true;
                    message = calc.ErrorMessage;
                }
                //If everything is ok, return the result to the user.
                else
                {
                    result = calc.Result;
                }
            }
            //If input type is not ok. Return error message to the user=>
            else
            {
                IsError = true;
                message = "Please check your inputs";
            }

        }
    }
}