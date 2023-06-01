using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {

        static List<Nobel> adatok = new List<Nobel>();
        static List<string> adatsorok = new List<string>();
        static void Main(string[] args)
        {
            Beolvasas();
            Console.WriteLine($"4. feladat: {adatok.Where(x => x.Evszam == 2017 && x.Tipus == "irodalmi").First().Keresztnev} {adatok.Where(x => x.Evszam == 2017 && x.Tipus == "irodalmi").First().Vezeteknev}");
            Console.WriteLine(adatok.Where(x => x.Vezeteknev.Contains("Curie")).ToString());
            Mentes();
            Console.ReadLine();
        }


        static void Beolvasas()
        {
            StreamReader sr = new StreamReader("nobel.csv");
            sr.ReadLine(); // kihagyja az elso sort
            while (!sr.EndOfStream)
            {
                string adatsor = sr.ReadLine();
                string[] adat = adatsor.Split(';');

                adatsorok.Add(adatsor);
                adatok.Add(new Nobel(int.Parse(adat[0]), adat[1], adat[2], adat[3]));
            }
            while (!sr.EndOfStream)
            {
                adatsorok.Add(sr.ReadLine());
            }
            sr.Close();
        }





        static void Mentes()
        {
            StreamWriter sw = new StreamWriter("orvosi.txt");
            for (int i = 0; i < adatsorok.Count; i++)
            {
                string[] adat = adatsorok[i].ToString().Split(';');
                if (adat[1] == "orvosi")
                {
                    sw.WriteLine(adatsorok[i]);
                }
            }
            sw.Close();
          
        }
    }
}
