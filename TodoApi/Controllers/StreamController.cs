using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
   
    [Route("api/[controller]")]
    public class StreamController : Controller
    {
        /// <summary>
        /// Stream reader, cita text iz fajla
        /// </summary>
        /// <param name="filename">ime fajla za citanje</param>
        /// <returns>string</returns>
        [HttpGet("sream/{filename}")]
        public string SreamRead(string filename)
        {
            string path = @"C:\Users\Bild081\AppData\Local\Temp\Projects\" + filename+".txt";
            string result = "";
            using (StreamReader sr = System.IO.File.OpenText(path))
            {
                string s = "";
                
                while ((s = sr.ReadLine()) != null)
                {
                    result += s+"\n";
                }
            }

            return result;
        }
        /// <summary>
        /// Upisivanje novog texta u fajl i njegovo iscitavanje, ako fajl ne postoji onda ce se kreirati novi fajl
        /// </summary>
        /// <param name="filename">ime fajla u koji ubacujemo novi text</param>
        /// <param name="text">text koji dodajemo fajlu</param>
        /// <returns>string</returns>
        [HttpGet("streamwrite/{filename}/{text}")]
        public string WriteStream(string filename, string text)
        {
            string myText = text;
            string path = @"C:\Users\Bild081\AppData\Local\Temp\Projects\" + filename + ".txt";
            using (StreamWriter sr = System.IO.File.AppendText(path))
            {
                sr.WriteLine(myText);
                sr.Close();
            }

            string path2= @"C:\Users\Bild081\AppData\Local\Temp\Projects\" + filename+".txt";
            string lines;
            lines = System.IO.File.ReadAllText(path2);

            return lines;
        }
    }
}
