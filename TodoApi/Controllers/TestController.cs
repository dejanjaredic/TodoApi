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

        
        


        /*
        [Route("[controller]/[action]")] - 
        public IActionResult List()
        {
         return Content("List");
        }
        [Route("[controller]/[action]")]
        public IActionResult Edit(int id)
        {
        return Content("Bring id");
        }
        */

        // -----------------------------------------------------------------------------------------------------------



        /*


        public IActionResult List()
        {
            return Content("List");
        }

       
        

        [Route("")]
        [Route("Index")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["Message"] = "Home Index";
            var url = Url.Action("Index", "Home");
            ViewData["Message"] = "Home index" + "var url = Url.Action; = " + url;
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        */

        //------------------------------------------------------------------------------------------------------


        // GET api/<controller>/5
        /*
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        */
        // POST api/<controller>
        /*
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        */
        // PUT api/<controller>/5
        /*
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        */
        // DELETE api/<controller>/5
        /*
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
