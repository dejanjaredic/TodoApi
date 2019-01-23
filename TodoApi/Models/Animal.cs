using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    /*
     * abstraktna klasa je bazna klasa i kad se definise nista se ne zna konkretno o njoj
     * npr ako je bazna klasa zivotinja mi nista ne znamo o toj zivotinji
     */
    abstract class Animal // keywor abstrakt definise abstraktnu klasu
    {
        public virtual void Set() // virtual znaci da metod ne moze biti promijenjen od strane child klase
        {

        }
    }

    /*
     * tek kad saznamo koja ce zivotinja to da bude onda se definise nova klasa koja nasljedjuje klasu zivotinja
     * poenta je u tome sto ova klasa ne moze da mijenja metod klase zivotinja, vec definise svoj sopstveni
     */
     class Dog : Animal //Klasa koja nasledjuje sve iz Animal klase
    {
        protected int Id { get; set; }
        protected string Description { get; set; }

        public void SetAnimal(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public string GetAnimal()
        {
            return Description;
        }
    }
}
