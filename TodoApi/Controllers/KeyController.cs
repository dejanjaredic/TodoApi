using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class KeyController : Controller
    {
        /// <summary>
        /// Just testing method
        /// </summary>
        /// <returns>bsaic string</returns>
        [HttpGet("test")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Basic get name and surname medhod
        /// </summary>
        /// <returns>name and surname string</returns>
        [HttpGet("name")]
        public IEnumerable<string> GetName()
        {
            return new string[] { "dejan", "jaredic" };
        }

        /// <summary>
        /// This will return my name and surname
        /// </summary>
        /// <remarks>Remarks Placeholder</remarks>
        /// <param name="name">The first name to search</param>
        /// <param name="surname">Second Name for searching</param>
        /// <returns>ame and surname</returns>
        [HttpGet("Name/{name}/surname{surname}", Name = "My_Stuff")]
        public string GetName(string name, string surname)
        {
            
            return "My name is " + " " + name + " and my surname is " + surname;
        }
        /// <summary>
        /// This Will return List using [actoin] simple demonstration app
        /// </summary>
        /// <returns>return string "list"</returns>
        [HttpGet]
        [Route("[action]")] 
        public IActionResult List()
        {
            return Content("List");
        }

        /// <summary>
        /// This is for edit and you have id to put in 
        /// </summary>
        /// <param name="id">Id parameta must be number</param>
        /// <returns>return number of Id</returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public ContentResult Edit(int id)
        {
            return Content("Bring id" + " " + id);
        }
    }
}
