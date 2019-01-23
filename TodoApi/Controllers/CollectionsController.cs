using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class CollectionsController : Controller
    {
        
        [HttpGet("alist")]
        public string  AArray()
        {
            ArrayList a1 = new ArrayList();
            a1.Add(23);
            a1.Add("Nesto");
            a1.Add(true);

            return a1[0] + " " + a1[1] + " " + a1[2];
        }

        [HttpGet("stack")]
        public int SArray()
        {
            Stack st = new Stack();
            st.Push(1);
            st.Push(2);
            st.Push(3);
            st.Push(4);
            st.Push(5);

            foreach (Object obj in st)
            {
                Debug.WriteLine(obj);
            }

            return st.Count;
        }

        [HttpGet("queue")]
        public string QArray()
        {
            Queue qt = new Queue();
            qt.Enqueue("dejan");
            qt.Enqueue("marko");
            qt.Enqueue("janko");
            qt.Enqueue("jaksa");
            string result = "";
            foreach (Object obj in qt)
            {
                result += obj + " ";
            }

            return result;
        }
        /// <summary>
        /// Metod vraca listu clanova po njihovom kljuci preko foreachpetlje
        /// </summary>
        /// <returns>string</returns>
        [HttpGet("hashtable")]
        public string HArray()
        {
            Hashtable ht = new Hashtable();
            ht.Add("0", "Dejan");
            ht.Add("1", "Niksa");
            ht.Add("2", "Djuro");
            string result = "";
            ICollection keys = ht.Keys;
            foreach (String k in keys)
            {
                result += ht[k] +"\n";
            }

            return result;
        }


    }
}
