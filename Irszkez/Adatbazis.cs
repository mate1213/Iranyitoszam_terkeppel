using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Irszkez
{   
    class Adatbazis
    {
        public List<Irszam> IrSzamok { get; set; }

        public Adatbazis()
        {
            IrSzamok = new List<Irszam>();
        }

        public bool Beolvas(string ut)
        {
            try
            {
                using (StreamReader sr = new StreamReader(ut))
                {
                    while (!sr.EndOfStream)
                    {
                        string temp = sr.ReadLine();
                        string[] temp2 = temp.Split(';');
                        Irszam irsz = new Irszam(int.Parse(temp2[0]), temp2[1], temp2[2]);
                        IrSzamok.Add(irsz);
                    }
                }
                return true;
            }
            catch (IOException)
            {
                return false;
            }

            
        }

        public List<Irszam> KeresIrsz (int keresendo)
        {
            List<Irszam> temp = new List<Irszam>();
            foreach (Irszam item in IrSzamok)
            {
                
                if (item.Irsz == keresendo)
                {
                    temp.Add(item);
                }
            }
            return temp;
        }

        public List<Irszam> KeresMegye(string keresendo)
        {
            List<Irszam> temp = new List<Irszam>();
            foreach (Irszam item in IrSzamok)
            {

                if (item.Megye == keresendo)
                {
                    temp.Add(item);
                }
            }
            return temp;
        }


        public List<Irszam> KeresVaros(string keresendo)
        {
            List<Irszam> temp = new List<Irszam>();
            foreach (Irszam item in IrSzamok)
            {

                if (item.Varos.IndexOf(keresendo)!=-1)
                {
                    temp.Add(item);
                }
            }
            return temp;
        }
    }
}
