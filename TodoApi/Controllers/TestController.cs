using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    /*[Route("[controller]/[action]")]*/
    [Route("api/Store")]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        /// <summary>
        /// [action] using for routhing
        /// </summary>
        /// <returns>string</returns>
        [HttpGet("[action]")]
        public IActionResult ListAll()
        {
            return Content("List - All");
        }

        /// <summary>
        /// post method
        /// </summary>
        [HttpPost("Buy")]
        [HttpPost("Checkout")]
        public void  Bay()
        {
           
        }
        
    }
}
