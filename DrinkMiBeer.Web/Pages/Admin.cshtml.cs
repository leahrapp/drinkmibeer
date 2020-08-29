using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrinkMiBeer.Web.Pages
{

[Route("api/[controller]")]
    public class AdminModel : PageModel
    {
        [HttpGet("[action]")]
        public void OnGet()
        {

        }
    }
}