using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class LinqController : Controller
    {
        protected readonly TodoContext _context;
        private ActionResult<IEnumerable<Zadatak>> z;

        public LinqController(TodoContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        [HttpGet("linq")]
        public string GetLinqBasics()
        {
            string result = "";
            int[] scores = new int[]{ 97, 92, 81, 60 };
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;

            foreach (int i in scoreQuery)
            {
                result += i + "\n";
            }

            return result;
        }

        [HttpGet("getall")]
        public string  GetAllData()
        {

            string result = "";

            string[] peoples= new string[]{"Dejan", "Marko", "Zana", "Dajana"};

            IEnumerable<string> queryPeople =
                from p in peoples
                orderby p descending 
                select p;

            foreach (string i in queryPeople)
            {
                result += i + "\n";
            }

            return result;
        }

        [HttpGet("midle/{val1}/{val2}")]
        public string GetBetvene(int val1, int val2)
        {
            string result = "";
            int[] numbers = new int[]{1,2,3,4,5,6,7,8,9,10};
            IEnumerable<int> getBetvene =
                from number in numbers
                where number > val1 && number < val2
                orderby number descending
                select number;

            foreach (var n in getBetvene)
            {
                result += n + "\n";
            }

            return result;
        }

        [HttpGet("getcount")]
        public int GetCount()
        {
            int[] numbers = new int[]{1,2,3,4,5,6,7,8,9};
            IEnumerable<int> numbersQuery =
                from number in numbers
                select number;

            int getCountNumber = numbersQuery.Count();

            return getCountNumber;
        }

        [HttpGet("highscore")]
        public int GetHighScore()
        {
            string result = "";
            int[] scores = new int[]{98,45,65,45,23,12,54,56};

            IEnumerable<int> scoreQuery =
                from score in scores
                select score;

            int highScore = scoreQuery.Max();


            return highScore;
        }
        
        
        [HttpGet("getlist")]
        public async Task<ActionResult<IEnumerable<Zadatak>>> GetPersons()
        {
            var zadatak = await _context.Zadataks.ToListAsync();

            IEnumerable<Zadatak> zadatakQuery =
                from z in zadatak
                select z;

           

           return zadatakQuery.ToList();

        }

        [HttpGet("citytest/{name}")]
        public List<String> GetCity(string name)
        {
           List<String> City = new List<string>();
            City.Add("Herceg Novi");
            City.Add("Tivat");
            City.Add("Kotor");
            City.Add("Podgorica");
            
                IEnumerable<String> cityQuery =
                    from c in City
                    where c == name
                    select c;

                return cityQuery.ToList();
        }

        [HttpGet("split")]
        public string SplitArray()
        {
            string result = "";
            string[] names = new string[]{"Dejan Jaredic", "Djole Djolic", "Sanja Sanjic", "Ivana Ivanovic", "Ana Antic"};
            IEnumerable<string> gueryFirstName =
                from name in names
                let firstName = name.Split((' '))[0]
                select firstName;

            foreach (var n in gueryFirstName)
            {
                result += n + "\n";
            }

            return result;
        }

        [HttpGet("numbers/{num}/{val}")]
        public string GetNumbersDevidedBy2(int num, int val)
        {
            string result = "";
            int[] numbers = Enumerable.Range(0, 100).ToArray();
            var numbersQuery =
                from number in numbers
                where (number % val) == 0
                select number;

            foreach (var n in numbersQuery)
            {
                result += n + "\n";
            }

            return result;
        }

        [HttpGet("city")]
        public IActionResult getFromTableCity()
        {
            
            List<City> city = new List<City>()
            {
                new City
                {
                    Id = 1,
                    Name = "Herceg Novi",
                    Population = "Novljani"
                },
                new City
                {
                    Id = 2,
                    Name = "Tivat",
                    Population = "Tivcani"
                },
                new City
                {
                    Id = 3,
                    Name = "Kotor",
                    Population = "Kotorani"
                },
                new City
                {
                    Id = 4,
                    Name = "Budva",
                    Population = "Budvani"
                },

            };
                var  cities =
                from c in city
                where c.Name == "Herceg Novi"
                select new {Population = c.Population};
                
            

            return Ok(cities.ToList());
        }



    }

    
}
