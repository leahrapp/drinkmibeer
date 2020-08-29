using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DrinkMiBeer.Web.Controllers
{
    [Route("api/[controller]")]
    public class AccountManagementController : Controller
    {

        
        [HttpPost("[action]")]
        public IActionResult Login()
        {

            return View();
        }

    [HttpPost("[action]")]
    public IActionResult Logout()
        {


            return View();
        }

        [HttpPost("[action]")]
        public IActionResult Register()
        {

            return View(); 
        }

        [HttpPost("[action]")]
        public IActionResult DeleteAccount()
        {
            return View(); 
        }
    }
}
