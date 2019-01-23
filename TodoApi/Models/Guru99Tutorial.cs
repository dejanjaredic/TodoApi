using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Guru99Tutorial : Guru99Interface
    {
        protected int TutorialId;
        protected string TutorialName;

        public void SetTutorial(int pId, string pName)
        {
            TutorialId = pId;
            TutorialName = pName;
        }

        public String GetTutorial()
        {
            return TutorialName;
        }
    }
}
