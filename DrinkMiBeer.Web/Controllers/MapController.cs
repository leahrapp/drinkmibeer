using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DrinkMiBeer.Web.Controllers
{ [Route("api/[controller]")]
    public class MapController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult GetAllMapPoints()
        {

            return View();
        }


        [HttpPost("[action]")]
     
        public IActionResult GetAccountMapPoint()
        {


            return View();

        }
    }
}