using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/")]
    public class BildController : Controller
    {
        /*
        [HttpGet]
        public IEnumerable<string> GetBild()
        {
            return new string[] {"bild value1", "bild value2" };
        }
        */
        /// <summary>
        /// Index method using diferrent paths
        /// </summary>
        /// <returns>string</returns>
        [HttpGet]
        [Route("")]
        [Route("Bild")]
        [Route("Bild/Index")]
        public IActionResult Index()
        {
            return Content("Index Method");
        }
        /// <summary>
        /// Basic method returns string
        /// </summary>
        /// <returns>string</returns>
        [HttpGet]
        [Route("Bild/About")]
        public IActionResult About()
        {
            return Content("About Method");
        }
        /// <summary>
        /// basic method 
        /// </summary>
        /// <returns>string</returns>
        [HttpGet]
        [Route("Bild/Content")]
        public IActionResult Content()
        {
            return Content("Index Content");
        }
        
    
        /*
        private readonly TodoContext _context;

        public BildController(TodoContext context)
        {
            _context = context;
        }
        */

    }
}
