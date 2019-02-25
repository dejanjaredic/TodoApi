using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

        [HttpGet("simplelambda/{val}")]
        public string SimpeLambda(int val)
        {
            int[] scores = {34, 65, 76, 23, 65, 98, 95, 34, 89};

            int highScore = scores.Where(n => n > val).Count();
            return highScore + "\n";
        }
        /// <summary>
        /// Metod za izlistavanje svih osoba sa svim parametrima iz baze podataka
        /// </summary>
        /// <returns>list</returns>
        [HttpGet("getlist")]
        public async Task<ActionResult<IEnumerable<Zadatak>>> GetPersons()
        {
            var zadatak = await _context.Zadataks.ToListAsync();
            IEnumerable<Zadatak> zadatakQuery =
                from z in zadatak
                select z;
            return zadatakQuery.ToList();
        }
        /// <summary>
        /// Metod za pronalazenje osobe po odredjenom Id-ju
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("examle1/{id}")]
        public IActionResult GetExampleById(int id)
        {
            
            var person = _context.Zadataks.ToList();
            IEnumerable<Zadatak> personQuery =
                from p in person
                where p.Id == id
                select p;

            return Ok(personQuery.ToList());

        }

        [HttpPut("exampleedit/{id}")]
        public IActionResult EditPersonById(int id, Zadatak input)
        {
            //var person = _context.Zadataks.ToList();
             _context.Entry(input).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();

        }
        /// <summary>
        /// Akcija za pretragu po imenu i prezimenu
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="surname">surname</param>
        /// <returns>list</returns>
        [HttpGet("getbyname/{name}/{surname}")]
        public IActionResult GetPersonByName(string name, string surname)
        {
            var person = _context.Zadataks.ToList();
            var personQuery =
                from p in person
                where p.Name == name && p.Prezime == surname
                select p;

            return Ok(personQuery.ToList());
        }
        /// <summary>
        /// Akcija sluzi da pronadje datu osobu po njenoj email adresi
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>list</returns>
        [HttpGet("getbyemail/{email}")]
        public IActionResult GetByEmail(string email)
        {
            var person = _context.Zadataks.ToList();
            var personQuery =
                from p in person
                where p.Email == email
                select p;

            return Ok(personQuery.ToList());
        }
        /// <summary>
        /// Akcija za pretragu osobe po njenom datumu i mjestu rodjenja
        /// </summary>
        /// <param name="date">date</param>
        /// <param name="place">place</param>
        /// <returns>List</returns>
        [HttpGet("getbydate/{date}/{place}")]
        public IActionResult GetByDateOfBirthday(DateTime date, string place)
        {
            var person = _context.Zadataks.ToList();
            var personQuery =
                from p in person
                where p.DatumRodjenja == date && p.MjestoRodjenja == place
                select p;

            return Ok(personQuery.ToList());
        }
        /// <summary>
        /// Akcija za pretragu osoba po datumu rodjenja
        /// </summary>
        /// <param name="date">date</param>
        /// <returns>list</returns>
        [HttpGet("getdate/{date}")]
        public IActionResult GetByDate(DateTime date)
        {
            var person = _context.Zadataks.ToList();
            var personQuery =
                from p in person
                where p.DatumRodjenja == date
                select p;

            return Ok(personQuery.ToList());
        }
        /// <summary>
        /// Grupisanje osoba po mjestu rodjenja
        /// </summary>
        /// <returns>list</returns>
        [HttpGet("groups")]
        public IActionResult GroupingPersons()
        {
           
            var person = _context.Zadataks.ToList();
            var personQuery =
                from p in person
                group p by p.MjestoRodjenja;
            List<string> result = new List<string>();
            foreach (var x in personQuery)
            {
                //Debug.WriteLine(x.Key);
                result.Add(x.Key);
                foreach (var y in x)
                {
                    //Debug.WriteLine(y.Name);
                    result.Add(" {0}"+y.Name);
                }
            }

            return Ok(result.ToList());
        }
        /// <summary>
        /// izbacuje imena kojih ima vise od broja koji unesemo 
        /// </summary>
        /// <param name="val">list</param>
        /// <returns></returns>
        [HttpGet("grups2/{val}")]
        public IActionResult GroupingPersons2(int val)
        {
            var person = _context.Zadataks.ToList();
            var personQuery =
                from p in person
                group p by p.Name
                into personName
                where personName.Count() > val
                orderby personName.Key
                select personName;

            return Ok(personQuery.ToList());
        }
        /// <summary>
        /// iscitavanje podataka iz classe PersonJob
        /// </summary>
        /// <returns>llist</returns>
        [HttpGet("readfromjob")]
        public IActionResult GetJobs()
        {
            var jobs = _context.PersonJobs.ToList();
            var jobsQuery =
                from job in jobs
                select job;
            return Ok(jobsQuery.ToList());
        }
        /// <summary>
        /// primjer pridruzivanja dvije tabele po mjestu rodjenja i gradu u kojem se nalazi posao, ako se podudaraju mjesto rodjenja i grad onda se toj osobi dodjeljuje taj posao
        /// </summary>
        /// <returns>list</returns>
        [HttpGet("joinexample")]
        public IActionResult JoinExample()
        {
            var persons = _context.Zadataks.ToList();
            var jobs = _context.PersonJobs.ToList();

            var joinQuery =
                from person in persons
                join job in jobs on person.MjestoRodjenja equals job.Town
                select new {Name = person.Name, MyJob = job.Job};

            return Ok(joinQuery.ToList());
        }
        /// <summary>
        /// sortiranje imena po karakteru i duzini imena
        /// </summary>
        /// <returns>list</returns>
        [HttpGet("sort")]
        public IActionResult SortByChar()
        {
            var persons = _context.Zadataks.ToList();
            var personsQuery =
                from person in persons
                orderby person.Name[0]
                group person by person.Name[0]
                into pName
                select new
                {
                    Chahr = pName.Key,
                    broj = pName.Count(),
                    Osobe = from p in pName 
                        orderby p.Name.Length
                            select p.Name

                };
            int count = personsQuery.Count();
            return Ok(personsQuery.ToList());

        }
        /// <summary>
        /// Akcija izlistava imena osoba koje se bave istim poslovima
        /// </summary>
        /// <returns>list</returns>
        [HttpGet("connectbyfk")]
        public IActionResult GetByFkAgain()
        {
            var persons = _context.Zadataks;
            var jobs = _context.PersonJobs;

            var joinQuery =
                from job in jobs
                join person in persons on job.Id equals person.JobId into jobPersons
                select new { Job = job.Job, Osobe = (from p in jobPersons select p.Name)};
                

            //return Ok(joinQuery.ToLookup(x => x.PersonJob, x => new {x.PersonName, x.PersonSurname}));
            return Ok(joinQuery.ToList());
        }
        
        [HttpGet("grupbytown")]
        public IActionResult GroupByCity()
        {
            var persons = _context.Zadataks;
            var personsQuery =
                from person in persons
                group person by person.MjestoRodjenja
                into cityGroup
                select new {City = cityGroup.Key, Osoba = (from p in cityGroup select (p.Name + " " +p.Prezime))};
            return Ok(personsQuery.ToList());


        }

        [HttpGet("groupbytovnlambda")]
        public IActionResult GroupByCityUsingLambda()
        {
            var peoples = _context.Zadataks;
            var peoplesQuery = peoples.GroupBy(people => people.MjestoRodjenja)
                .Select(p => new {FromCity = p.Key, Osoba = p.Select(n => n.Name+" "+n.Prezime)});
            return Ok(peoplesQuery.ToList());
        }
        
        [HttpGet("jobsgroups")]
        public IActionResult GetPersonJobs()
        {
            var persons = _context.Zadataks;
            var jobs = _context.PersonJobs;

            var lambdaQuery = jobs.Join(persons, x => x.Id, x => x.JobId,
                    (job, person) => new {Job = job.Job, Person = person.Name + " " + person.Prezime})
                .GroupBy(x => x.Job)
                .Select(x => new
                    {Job = x.Key, Users = x.Select(user => user.Person)});
            return Ok(lambdaQuery.ToList());
            ////var groupQuery =
            ////    from job in jobs
            ////    join person in persons on job.Id equals person.JobId
            ////    let jobPerson = new  {Job = job, Person = person }
            ////    group jobPerson by jobPerson.Job.Job
            ////    into myJob
            ////    select new
            ////    {
            ////        JobGroup = myJob.Key, Person = from i in myJob
            ////            select i.Person.Name
            ////    };

            ///    return Ok(lambdaQuery.ToList());
        }
        /*
        int prvaFunkcija(PersonJob x)
        {
            return x.Id;
        }

        public class PovratnaInfo
        {
            public string Job { get; set; }
            public string Person { get; set; }
        }

        PovratnaInfo DrugaFunkcija(PersonJob job, Zadatak person)
        {
            return new PovratnaInfo
                {Job = job.Job, Person = person.Name + " " + person.Prezime};
        }
        */
        /// <summary>
        /// Pretraga osobe po imenu i izbacivanje imena i prezimena te osobe Koriscenjem Lambda Expresion
        /// </summary>
        /// <param name="name">ime</param>
        /// <returns>List</returns>
        [HttpGet("lambdaexpresion/{name}")]
        public IActionResult LambdaExample(string name)
        {
            var persons = _context.Zadataks;
            var personsQuery = persons.Where(person => person.Name == name).Select(p => p.Name +" "+p.Prezime);
            return Ok(personsQuery.ToList());
        }
        /// <summary>
        /// Grupisanje osoba po prvom slovu imena i sortiranje po duzini njihovih imena pomocu Lambda Expresion
        /// </summary>
        /// <returns>List</returns>
        [HttpGet("getcharvithlambda")]
        public IActionResult GetNames()
        {
            var persons = _context.Zadataks;
            var personsQuery = persons.OrderBy(person => person.Name[0]).GroupBy(p => p.Name[0])
                .Select(p => new {Char = p.Key, Broj = p.Count(), User = p.Select(user => user.Name).OrderBy(o => o.Length)});
            return Ok(personsQuery.ToList());
        }

        /// <summary>
        /// Grupisanje imena po godini rodjenja
        /// </summary>
        /// <returns>List</returns>
        [HttpGet("SortByYear")]
        public IActionResult ByYear()
        {
            var persons = _context.Zadataks;
            var personsQuery =
                persons.GroupBy(n => n.DatumRodjenja)
                    .Select(x => new {Godina = x.Key, Zbir=x.Count(), Ime = x.Select(g => g.Name +" "+ g.Prezime).OrderBy(s => s.Length)});
            return Ok(personsQuery.ToList());
        }


    }

    
}
