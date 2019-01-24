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
    public class Files : Controller
    {
        /*
        [HttpGet("folderexist")]
        public string FolderExist()
        {
            
            string path = @"C:\temp";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                return "Folder created";
            }
            else
            {
                return "Folder are created allready";
            }
        }
        */
        /*
        [HttpGet("filecreate/{name}")]
        public string CreateFile(string name)
        {
            string path = @"C:\Users\Bild081\Desktop\" + name + ".txt";
            if (!System.IO.File.Exists(path))
            {
                System.IO.File.Create(name + ".txt");
                return "File Created";
            }
            else
            {
                return "File exist";
            }

            return path;
        }
        */

        
        /// <summary>
        /// Metoda koja provjerava dal dati fajl postoji, ako ne postoji onda ga kreira na desktop
        /// </summary>
        /// <returns>string</returns>
        [HttpGet("file/{filename}")]
        public string FExist(string filename)
        {

            string path = @"C:\Users\Bild081\Desktop\" + filename+".txt";
            if (System.IO.File.Exists(path))
            {
                return "File exist";
            }
            else
            {
                System.IO.File.Create(path);
                return "Created";
            }


            return "Not created";
        }
        /// <summary>
        /// Metoda za citanje sadrzaja iz zadatog  fajla liniju po liniju preko foreach petlje
        /// </summary>
        /// <returns>string</returns>
        [HttpGet("readfileline")]
        public string ReadFileLine()
        {
            string path = @"C:\Users\Bild081\Desktop\test.txt";

            string[] lines;
            string result = "";
            lines = System.IO.File.ReadAllLines(path);
            foreach (String f in lines)
            {

                result += f + "\n";
            }

            return result;
        }
        /// <summary>
        /// Metoda cita kopletan text iz fajla pomocu System.IO.File.ReadAllText(path)
        /// </summary>
        /// <returns>string</returns>
        [HttpGet("readetext")]
        public string DeadAllFromFile()
        {
            string path = @"C:\Users\Bild081\Desktop\test.txt";
            string lines;
            lines = System.IO.File.ReadAllText(path);

            return lines;
        }
        /// <summary>
        /// metoda za kopiranje fajla pod drugim imenom
        /// </summary>
        /// <param name="filename">ime novog fajla</param>
        /// <returns>string</returns>
        [HttpGet("copyfile/{filename}")]
        public string CopyTheFile(string filename)
        {
            string path = @"C:\Users\Bild081\Desktop\test.txt";
            string copypath = @"C:\Users\Bild081\Desktop\" + filename+".txt";

            System.IO.File.Copy(path, copypath);

            return "File is Copyed";
        }
        /// <summary>
        /// metoda za brisanje fajla
        /// </summary>
        /// <param name="filename">ime fajla za brisanje</param>
        /// <returns></returns>
        [HttpGet("filedelete/{filename}")]
        public string FileDelete(string filename)
        {
            string path = @"C:\Users\Bild081\Desktop\" + filename + ".txt";
            System.IO.File.Delete(path);

            return "File is deleted";
        }


    }
}
