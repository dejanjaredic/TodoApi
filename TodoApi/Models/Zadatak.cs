using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace TodoApi.Models
{
  
    

    public class Zadatak
    {
        public static List<Zadatak> Zadataks
        {
            get
            {
                var jsonLoad = File.ReadAllText("users5.json");
                var list = JsonConvert.DeserializeObject<List<Zadatak>>(jsonLoad);
                return list;
            }
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Prezime { get; set; }

        public DateTime DatumRodjenja { get; set; }
        public string MjestoRodjenja { get; set; }
        public string Email { get; set; }
        public int JobId { get; set; }

        

    }

}
