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

        /// <summary>
        /// Akcija za izlistavanje svih osoba iz JSON Fajla
        /// </summary>
        /// <returns>Vraca osobe</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zadatak>>> GetPersons()
        {
            return await _context.Zadataks.ToListAsync();
        }
        /// <summary>
        /// Akcija koja pronalazi osobu po njenom Id-ju
        /// </summary>
        /// <param name="id">Id number</param>
        /// <returns>id</returns>
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

        
        /// <summary>
        /// Akcija koja Edituje(mijenja) odredjeni entitet date osobe, osoba je definisana Id jem
        /// </summary>
        /// <param name="id">Id number</param>
        /// <param name="zadatak"></param>
        /// <returns>id</returns>
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


        /// <summary>
        /// Akcija za Kreiranje NOve Osobe
        /// </summary>
        /// <param name="zadatak">Svi parametri</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Zadatak>> CreatePerson(Zadatak zadatak)
        {
            _context.Zadataks.Add(zadatak);
            await _context.SaveChangesAsync();
            return CreatedAtAction("CreatePerson", new { id = zadatak.Id }, zadatak);
        }

        /// <summary>
        /// Akcija za Brisanje odredjene osobe iz baze, definisana je Id jem
        /// </summary>
        /// <param name="id">id number</param>
        /// <returns></returns>
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
        /// <summary>
        /// Akcija pretrazuje osobu prema njenom imenu i preimenu
        /// </summary>
        /// <param name="name">ime</param>
        /// <param name="surname">prezime</param>
        /// <returns></returns>
       // [Route("pretrtaga")]
        [HttpGet("pretragaa/{name}/{surname}")]
        public async Task<ActionResult<List<Zadatak>>> GetByName(string name, string surname)
        {
            var person = await _context.Zadataks.Where(p => (p.Name == name && p.Prezime == surname)).ToListAsync();
            if (person != null)
            {
                return person;
            }
            return NotFound();
        }
        
        /// <summary>
        /// Akcija pretrazuje osobu prema njenom email-u
        /// </summary>
        /// <param name="email">email</param>
        /// <returns></returns>
        [HttpGet("pretraga/{email}")]
        public async Task<ActionResult<List<Zadatak>>> GetByEmail(string email)
        {
            var person = await _context.Zadataks.Where(p => (p.Email == email)).ToListAsync();
            
            if (person != null)
            {
                return person;
            }

            return NotFound();
        }
        /// <summary>
        /// Akcija za pretragu osobe prema njenom datumu i mjestu rodjenja
        /// </summary>
        /// <param name="date">datum</param>
        /// <param name="city">Grad</param>
        /// <returns></returns>
       // [Route("pretrtaga")]
        [HttpGet("pretraga/{date}/{city}")]
        public async Task<ActionResult<List<Zadatak>>> GetByCityAndDateOfBirth(DateTime date, string city)
        {
            
            var person = await _context.Zadataks.Where(p => ((DateTime.Compare(p.DatumRodjenja, date)) == 0 && p.MjestoRodjenja == city)).ToListAsync();

            if (person != null)
            {
                return person;
            }

            return NotFound();
        }
        /// <summary>
        /// Akcija za pretragu osoba prema datumu rodjenja
        /// </summary>
        /// <param name="date">datum</param>
        /// <returns></returns>
        [HttpGet("pretrage/{date}")]
        public async Task<ActionResult<List<Zadatak>>> GetByDate(DateTime date)
        {

            var person = await _context.Zadataks.Where(p => ((DateTime.Compare(p.DatumRodjenja, date)) == 0 )).ToListAsync();

            if (person != null)
            {
                return person;
            }

            return NotFound();
        }
        /*
        [HttpGet("prettraga/{id}")]
        public ActionResult<List<Zadatak>> GetByOneEntity(int id)
        {
            List<Zadatak> personName = new List<Zadatak>();
            var name = from n in personName
                where n.Id == id
                select n;
            return 
        }
        */




    }
}
