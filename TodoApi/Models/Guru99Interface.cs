using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public interface Guru99Interface
    {
        void SetTutorial(int pId, string pName);
        String GetTutorial();
    }


}
