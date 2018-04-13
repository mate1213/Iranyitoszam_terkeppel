using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Irszkez
{
    class Irszam
    {
        public int Irsz { get; set; }

        public string Varos { get; set; }

        public string Megye { get; set; }
        public Irszam(int irsz, string varos, string megye)
        {
            Irsz = irsz;
            Varos = varos;
            Megye = megye;
        }
        public override string ToString()
        {
            string eredmeny = "";
            eredmeny += Irsz.ToString();
            eredmeny += " - ";
            eredmeny += Varos;
            eredmeny += " - ";
            eredmeny += Megye;
            return eredmeny;
        }
    }
    
}
