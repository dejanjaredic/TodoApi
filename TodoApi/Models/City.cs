using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Population { get; set; }
        public string Name { get; set; }
        /*
        public City(int id, string name, string population)
        {
            Id = id;
            Name = Name;
            Population = population;
        }
        */
    }

}
