using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class ListExample
    {
        public int Id { get; set; }
    }

    public class Second : ListExample
    {
        public string Name { get; set; }
    }


    public class Example
    {

        public static void GiveList()
        {
            List<ListExample> list = new List<ListExample>();
            list.Add(new Second
            {
                Id = 1, Name = "dejan"
            });
            foreach (var b in list)
            {
                var ex = b as Second;
                if (ex == null)
                {
                    // exception
                }
            }
           
        }
    }
}
