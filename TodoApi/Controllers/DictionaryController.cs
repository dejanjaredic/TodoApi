using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

            return result + "\n" + $"You have {dictionary.Count} objects!!!";
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
                    return "I have " + value.ToString() + " " + key;
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
        /// <summary>
        /// Funkcija vraca vrijednost iz dictionary po zadatom kljucu, A ili c
        /// </summary>
        /// <param name="value">A, c</param>
        /// <returns>string</returns>
        [HttpGet("dicti/{value}")]
        public string TestValueSyntzx2(string value)
        {
            var values = new Dictionary<string, string>();
            values.Add("A", "Uppercase letter A");
            values.Add("c", "lowercase letter C");

            if (values.TryGetValue(value, out string description))
            {
                return description;
            }

            return "";
        }
        /// <summary>
        /// Funkcija izbacuje podatke iz dictionary
        /// </summary>
        /// <returns>strting</returns>
        [HttpGet("checkdic")]
        public string CheckDictionary()
        {
            string first = "", second = "";
            Dictionary<string, int> data = new Dictionary<string, int>()
            {
                {"cat", 2},
                {"dog", 1},
                {"llama", 0},
                {"iguana", -1}
            };
            // Loop over pairs with foreach.
            foreach (KeyValuePair<string, int> pair in data)
            {
                //Debug.WriteLine("FOREACH KEYVALUEPAIR: {0}, {1}", pair.Key, pair.Value);
                first += ("FOREACH KEYVALUEPAIR: {0}, {1}", pair.Key, pair.Value) + "\n";
            }
            // Use var keyword to enumerate Dictionary.
            foreach (var pair in data)
            {
                //Debug.WriteLine("FOREACH VAR: {0}, {1}", pair.Key, pair.Value);
                second += ("FOREACH VAR: {0}, {1}", pair.Key, pair.Value) + "\n";
            }

            return first + "\n" + second;
        }
        /// <summary>
        /// Metod koji konvertuje disctionary u listu
        /// </summary>
        /// <returns></returns>
        [HttpGet("dictconvert")]
        public string ConvertToList()
        {
            string result = "";
            var data = new Dictionary<string, int>()
            {
                {"cat", 2},
                {"dog", 1},
                {"llama", 0},
                {"iguana", -1}
            };
            var list = new List<string>(data.Keys);
            foreach (string key in list)
            {
                result += ("KEY FROM LIST: " + key) + "\n";
            }

            return result;
        }
        /// <summary>
        /// Provjerava dal neki objekat sadrzi trazeni key
        /// </summary>
        /// <param name="key">key 100 ili 200 za 'true' </param>
        /// <returns>string</returns>
        [HttpGet("dictionaryexaple/{key}")]
        public string CheckKey(int key)
        {
            string result = "";
            var data = new Dictionary<int, string>();
            data.Add(100, "color");
            data.Add(200, "fabric");

            if (data.ContainsKey(key))
            {
                result = $"CONTAINS KEY {key}";
            }
            else
            {
                result = $"Not contains key {key}";
            }

            return result;
        }

        [HttpGet("dictwithlinq")]
        public string DictionaryWithLinq()
        {
            string getresult = "";
            string[] values = new string[]
            {
                "One",
                "Two"
            };

            var result = values.ToDictionary(item => item, item => true);
            foreach (var pair in result)
            {
                getresult += ("RESULT PAIR: {0}, {1}", pair.Key, pair.Value).ToString() + "\n";
            }

            return getresult;

        }
        /// <summary>
        /// Jednostavna provjera funkcije Remove koja izbacuje element iz dictionary ako postoji
        /// </summary>
        /// <returns>string</returns>
        [HttpGet("deleteremove")]
        public string DeleteOrRemove()
        {
            string result = "";
            var data = new Dictionary<string, int>();
            data.Add("cat", 1);
            data.Add("dog", 2);

            result += "Count: " + data.Count + "\n";

            data.Remove("cat");
            result += "Count: " + data.Count + "\n";

            data.Remove("something");
            result += "Count: " + data.Count + "\n";

            return result;

        }

        private const int _max = 10000000;
        /// <summary>
        /// Funkcija koja koristi StringCompare.Original  i testira brzinu prettrage
        /// </summary>
        /// <returns>string</returns>
        [HttpGet("stopwatch")]
        public string DictionaryCompare()
        {
            string result = "";
            var data1 = new Dictionary<string, bool>();
            data1["Las Vegas"] = true;
            var data2 = new Dictionary<string, bool>(StringComparer.Ordinal);
            data2["Las Vegas"] = true;

            Stopwatch s1 = Stopwatch.StartNew();
            for (int i = 0; i < _max; i++)
            {
                if (!data1.ContainsKey("Las Vegas"))
                {
                    return "";
                }
            }
            s1.Stop();
            Stopwatch s2 = Stopwatch.StartNew();
            for (int i = 0; i < _max; i++)
            {
                if (!data2.ContainsKey("Las Vegas"))
                {
                    return "";
                }
            }
            s2.Stop();
            result += (((double)(s1.Elapsed.TotalMilliseconds * 10000000)/
                             _max).ToString("0.00 ns"))+" -> default compare \n";
            result += (((double)(s2.Elapsed.TotalMilliseconds * 10000000) /
                             _max).ToString("0.00 ns"))+" -> StringCompare.Original";
            return result;
        }
        /// <summary>
        /// Metoda testira jel brze koristiti foreach petlju direktno na dictionary ili preko Keys pa tek onda da pristupi vrijednosti
        /// </summary>
        /// <returns></returns>
        [HttpGet("compareloops")]
        public string CompareLoops()
        {
            string result = "";
            var test = new Dictionary<string, int>();
            test["bird"] = 10;
            test["frog"] = 20;
            test["cat"] = 60;
            int sum = 0;
            const int _max = 10000000;

            var s1 = Stopwatch.StartNew();
            for (int i = 0; i < _max; i++)
            {
                foreach (var pair in test)
                {
                    sum += pair.Value;
                }
            }
            s1.Stop();

            var s2 = Stopwatch.StartNew();
            for (int i = 0; i < _max; i++)
            {
                foreach (var key in test.Keys)
                {
                    sum += test[key];
                }
            }
            s2.Stop();
            result += (s1.Elapsed.TotalMilliseconds).ToString()+" -> Koristi foreach petlju direktno na dictionary \n";
            result += (s2.Elapsed.TotalMilliseconds).ToString()+" -> Koristi foreach petlj ma Keys, onda pristupa vrijednosti";

            return result;
        }
        /// <summary>
        /// Metod koji sortira dictionary po kljucu, s obzirom da se dictioary ne moze sortirati direktno prebacuje se u list pa se list sortira po kljucu
        /// </summary>
        /// <returns></returns>
        [HttpGet("sort")]
        public string SortDictionary()
        {
            string result = "";
            var dictionary = new Dictionary<string, int>();
            dictionary["car"] = 2;
            dictionary["apple"] = 1;
            dictionary["zebra"] = 0;
            dictionary["mouse"] = 5;
            dictionary["year"] = 3;

            var list = dictionary.Keys.ToList();
            list.Sort();
            foreach (var key in list)
            {
                result +=  (key, dictionary[key])+"\n";
            }

            return result;
        }
        /// <summary>
        /// Method sortira dictionary koristeci Linq po vrijednostima
        /// </summary>
        /// <returns>string</returns>
        [HttpGet("sortbyvalue")]
        public string SortByValue()
        {
            string result = "";
            var dictionary = new Dictionary<string, int>(5);
            dictionary.Add("cat", 1);
            dictionary.Add("dog", 0);
            dictionary.Add("mouse", 5);
            dictionary.Add("eel", 3);
            dictionary.Add("programmer", 2);

            var items = from pair in dictionary
                orderby pair.Value ascending
                select pair;

            foreach (KeyValuePair<string, int> pair in items)
            {
                result += pair.Key + " " + pair.Value + "\n";
            }

            return result;


        }
        /// <summary>
        /// CaseInsensitive dictionary, bez obzira dal je key napisan velikim il malim slovima pronalazi vrijednost tog kljuca [dog, Cat, BIRD]
        /// </summary>
        /// <param name="key">dog, Cat, BIRD</param>
        /// <returns></returns>
        [HttpGet("caseinsensitive/{key}")]
        public string CaseInsensitveDic(string key)
        {
            string result = "";
            var dictionary = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            dictionary["dog"] = 2;
            dictionary["Cat"] = 4;
            dictionary["BIRD"] = 6;
            if (!dictionary.ContainsKey(key))
            {
                return "Not in dictionary";
            }
            result += $"Value of {key} is: "+dictionary[key] + "\n";
            

            if (dictionary.ContainsKey(key))
            {
                result +=  "Contain dog. \n";
            }

            foreach (var pair in dictionary)
            {
                result += pair.ToString() + "\n";
            }

            return result;

        }



    }
    


}
