using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class SerializationController : Controller
    {

        /// <summary>
        /// Serialization & Deserialization
        /// </summary>
        /// <returns></returns>
        [HttpGet("serial/{filename}")]
        public string TestSerialization(string filename)
        {
            
            Serialization obj = new Serialization();
            obj.Id = 1;
            obj.Name = "Dejan";

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("C:\\Users\\Bild081\\Desktop\\"+filename+".txt", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, obj);
            stream.Close();

            stream = new FileStream("C:\\Users\\Bild081\\Desktop\\"+filename+".txt", FileMode.Open, FileAccess.Read);
            Serialization objnew = (Serialization) formatter.Deserialize(stream);

            return objnew.Id.ToString() + " " + objnew.Name;

        }
    }
}
