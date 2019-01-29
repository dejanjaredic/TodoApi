using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TodoApi.Models
{
    public class PersonJob
    {
        public static List<PersonJob> Jobs
        {
            get
            {
                var jsonLoad = File.ReadAllText("job6.json");
                var list = JsonConvert.DeserializeObject<List<PersonJob>>(jsonLoad);
                return list;
            }
        }
        public int Id { get; set; }
        public string Job { get; set; }
        public string Town { get; set; }
    }

}
