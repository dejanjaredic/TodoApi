using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace TodoApi.Models
{
    public class Tutorial
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /*
        kada se modifier stavi na protect samo tad chilld class- a moze da koristi polja parent classe
        protected int Id { get; set; }
        protected string Name { get; set; }
        */
        /// <summary>
        /// Kreiranje Construktora koji za Id i name ima defaultne vrijednosti ako nije pozvana odredjena akcija npr u ovom slucaju SetTutorial
        /// </summary>
        public Tutorial()
        {
            Id = 0;
            Name = "Default";
        }
        /// <summary>
        /// SetTutorijal akcija dodjeljuje Id i Name classi Tutorijal
        /// </summary>
        /// <param name="pId">id</param>
        /// <param name="pName">Name</param>
        public void SetTutorial(int pId, String pName)
        {
            Id = pId;
            Name = pName;
        }

        public String GetTutorial()
        {
            return Name;
        }


    }
    /// <summary>
    /// Class Guru99Tutorijal nasljeduje property klasse Tutorijal
    /// </summary>
    public class Guru99Tutoriall : Tutorial
    {
        public void RenameTutoriall(String pNewName)
        {
            Name = pNewName;
        }

        /*
         * What is Polymorphism in C#
         *
         *Polimarfizam nam sluzi da mozemo koristiti metod istog imena al koje imaju razlicit property,
         * u zavisnosti od toga koje podatke pozovemo prilikom akcije
         * C# ce da izvrsi Akciju
         * npr:
         *      Tutorial pTutorial = new Tutorial();
         *      p.Tutorial.SetTutorial(1, "First Tutorial") ce da pozove prvi metod
         *      p.Tutorial.SetTutorial("First Tutorial") ce da pozove drugi metod
         */
        public void SetTutorial(int pId, String pName)
        {
            Id = pId;
            Name = pName;

        }

        public void SetTutorial(String pName)
        {
            Name = pName;
        }
    }


}
