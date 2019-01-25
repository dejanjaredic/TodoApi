using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class LoopsController : Controller
    {
        /// <summary>
        /// Provjeravanje if petlje
        /// </summary>
        /// <param name="number1">prvi broj</param>
        /// <param name="number2">drugi broj</param>
        /// <returns>string</returns>
        [HttpGet("if/{number1}/{number2}")]
        public string IfStatement(int number1, int number2)
        {
            
            Boolean status = true;

            if (number1 == number2)
            {
                return "We are the same";
            }
            else if (number1 < number2)
            {
                return number2.ToString();
            } else if (number1 > number2)
            {
                return status.ToString();
            }
            else
            {
                return "something elser ";
            }
        }
        /// <summary>
        /// Provjera Switch petlje koja ima vrijednosti od 1 do 5, ako nije unijeta vrijedost od 1-5 onda vrati text da je vrijednost drugacija
        /// </summary>
        /// <param name="val1">broj za provjeru vrijednosti </param>
        /// <returns>string</returns>
        [HttpGet("switch/{val1}")]
        public string SwStatement(int val1)
        {
            

            switch (val1)
            {
                case 1: return "Value is 1";
                    break;
                case 2: return "Value is 2";
                    break;
                case 3: return "Value is 3";
                    break;
                case 4: return "Value is 4";
                    break;
                case 5: return "Value is 5;";
                    break;
                default: return "Value is different";
                    break;
            }
            
            
        }
        /// <summary>
        /// While petlja ce da vrti onliko krugova koliko joj zadate
        /// </summary>
        /// <param name="number">broj koliko ce krugova petlja da izvrsi</param>
        /// <returns>string</returns>
        [HttpGet("while{number}")]
        public string WhileLoop(int number)
        {
            Int32 i = 0;
            while (i < number)
            {
                Debug.WriteLine($"Loop nummber {i} ");
                i = i + 1;
            }

            return $"The loop is finished after {number} loops";
        }
        /// <summary>
        /// Provjeravanje For petlje koja vrti onoliko krugova koliko joj zadamo
        /// </summary>
        /// <param name="number">broj koliko ce petlja krugova da izvrti</param>
        /// <returns>sring</returns>
        [HttpGet("for/{number}")]
        public string ForLoop(int number)
        {
            for (Int32 i = 0; i < number; i++)
            {
                Debug.WriteLine($"For Loop will end after {number} loops");
            }

            return $"Number of loops {number}";
        }
        /// <summary>
        /// Akcija za pretragu imena Iz niza names ["Dejan", "Marko", "Janko", "Milos", "Gojko"]
        /// </summary>
        /// <param name="name">Ime</param>
        /// <returns>string</returns>
        [HttpGet("array/{name}")]
        public string ArrayExamples(string name)
        {
            
            string[] names;
            names = new string[5];
            names[0] = "Dejan";
            names[1] = "Marko";
            names[2] = "Janko";
            names[3] = "Milos";
            names[4] = "Gojko";
            
            
            for (Int32 i = 0; i < names.Length; i++)
            {
               
                
                if (names[i].ToString() == name)
                {
                    return $"Oh Hi {name}, we have your name";
                }
                else
                {
                    Debug.WriteLine($"sorry, the name {name} not exist");
                }
                
            }

            return $"sorry, the name {name} not exist";
        }


    }
}
