using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    
    [Route("api/[controller]")]
    public class ZadatakController : Controller
    {

        private readonly TodoContext _context;

        public ZadatakController(TodoContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zadatak>>> GetPersons()
        {
            return await _context.Zadataks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Zadatak>> GetOnePerson(int id)
        {
            var zadatak = await _context.Zadataks.FindAsync(id);
            if (zadatak == null)
            {
                return NotFound();
            }
            return zadatak;
        }

        

        [HttpPut("{id}")]
        public async Task<ActionResult> EditPerson(int id, Zadatak zadatak)
        {
            if (id != zadatak.Id)
            {
                return BadRequest();
            }
            _context.Entry(zadatak).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }



        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Zadatak>> CreatePerson(Zadatak zadatak)
        {
            _context.Zadataks.Add(zadatak);
            await _context.SaveChangesAsync();
            return CreatedAtAction("CreatePerson", new { id = zadatak.Id }, zadatak);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Zadatak>> DeleteZadatak(int id)
        {
            var zadatak = await _context.Zadataks.FindAsync(id);
            if (zadatak == null)
            {
                return NotFound();
            }
            _context.Zadataks.Remove(zadatak);
            await _context.SaveChangesAsync();
            return zadatak;
        }



        /*
        [HttpGet("{id}")]
        public async Task<ActionResult<Zadatak>> GetZadatak(long id)
        {
            var zadatak = await _context.Zadataks.FindAsync(id);
            if (zadatak == null)
            {
                return NotFound();
            }
            return zadatak;
        }
        */

       


    }
}
