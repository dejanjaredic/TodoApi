using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class DictionaryController : Controller
    {
        /// <summary>
        /// Metoda kreira dictionary sa 4 objekta i izlistava ih na ekranu
        /// </summary>
        /// <returns>string</returns>
        [HttpGet]
        public string DictionaryOne()
        {
            var dictionary = new Dictionary<string, int>();
            dictionary.Add("dog", 3);
            dictionary.Add("cat", 5);
            dictionary.Add("lion", 0);
            dictionary.Add("vulf", 2);

            string result = "";
            foreach (KeyValuePair<string, int> entry in dictionary)
            {
                result += entry.Key + " " + entry.Value + "\n";
            }

            return result+ "\n"+ $"You have {dictionary.Count} objects!!!";
        }
        /// <summary>
        /// Metoda kreira 4 objekta i dozvoljava pretragu po kljucnoj rijeci, npr ako kucamo dog daje nam broj pasa koji posjedjemo["dog","cat","lion", "vulf"]
        /// </summary>
        /// <param name="key">klljucna rijec</param>
        /// <returns>string</returns>
        [HttpGet("dictionary/{key}")]
        public string DictionaryTwo(string key)
        {
            
            var dictionary = new Dictionary<string, int>()
            {
                {"dog", 3},
                {"cat", 5},
                {"lion", 0},
                {"vulf", 2}
            };
            foreach (KeyValuePair<string, int> d in dictionary)
            {
                if (dictionary.ContainsKey(key))
                {
                    int value = dictionary[key];
                    return "I have " +value.ToString()+" "+ key;
                }
            }

            return "No mavhes";

        }
        /// <summary>
        /// Funkcija izbacuje zanimanje osobe iz dictionary, u suprotnom vraca no value
        /// </summary>
        /// <param name="value">Dejan, Janko, Gojko</param>
        /// <returns>string</returns>
        [HttpGet("dict/{value}")]
        public String TestValue(string value)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>()
            {
                {"Dejan", "programer"},
                {"Janko", "ekonomista"},
                {"Gojko", "pravnik"}
            };

            string test;
            if (dictionary.TryGetValue(value, out test))
            {
                return test;
            }

            return "No value";
        }
        
    }
}
