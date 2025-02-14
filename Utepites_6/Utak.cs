using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Utepites_6
{
    internal class Utak
    {
        private string fajl;
        public List<Auto> autok = new List<Auto>();

        public Utak(string fajl)
        {
            this.fajl = fajl;
            Beolvas();
        }

        internal void MelyikVarosFele(int keresettAutoSorszama)
        {
            int min = 1;
            int max = autok.Count;

            if (min <= keresettAutoSorszama && keresettAutoSorszama <= max)
            {
                Auto keresettAuto = autok[keresettAutoSorszama - 1];
                string ellenkezoIrany = keresettAuto.irany == "A" ? "F" : "A";

                Console.WriteLine("\t\t-A(z) {0} sorszámú autó \"{1}\" irányba halad.", keresettAutoSorszama, ellenkezoIrany);
            }
            else
            {
                Console.WriteLine("A sorszám nem megfelelő!");
            }
        }

        private void Beolvas()
        {
            string[] sorok = File.ReadAllLines(fajl);

            for (int i = 1; i < sorok.Length; i++)
            {
                string[] oszlopok = sorok[i].Split(' ');
                int ora = int.Parse(oszlopok[0]);
                int perc = int.Parse(oszlopok[1]);
                int mp = int.Parse(oszlopok[2]);
                int idealisAthaladasiIdoMasodPercben = int.Parse(oszlopok[3]);
                string irany = oszlopok[4];

                autok.Add(new Auto(ora, perc, mp, idealisAthaladasiIdoMasodPercben, irany));
            }
        }

        internal void UtolsoKetJarmu(string irany)
        {
            var lekerdezes =
                (from auto in autok
                 where auto.irany == irany
                 select auto).ToList();

            Auto utolsoAuto = lekerdezes[lekerdezes.Count - 1];
            Auto utolsoElottiAuto = lekerdezes[lekerdezes.Count - 2];

            TimeSpan idokulonbseg = utolsoAuto.belepesiIdopont - utolsoElottiAuto.belepesiIdopont;
            Console.WriteLine("\t-A két utolsó autó közötti időkülönbség {0} mp \"{1}\" irányban.", idokulonbseg.TotalSeconds, irany);
        }

        internal void TizLeggyorsabb()
        {
            List<string> iranyok = new List<string>() { "A", "F" };

            foreach (string irany in iranyok)
            {
                Console.WriteLine("\n\t-Irány: {0}", irany);
                var lekerdezes =
                    (from auto in autok
                     where auto.irany == irany
                     orderby auto.sebesseg descending
                     select auto).Take(10);

                foreach (var sor in lekerdezes)
                {
                    Console.WriteLine("\t\t-{0:0.0} m/s, {1}", sor.sebesseg, sor.belepesiIdopont);
                }
            }
        }

        internal void OrankentIranyonkent()
        {
            var lekerdezes =
                    autok
                    .GroupBy(b => (b.belepesiIdopont.Hours, b.irany))
                    .Select(g => new
                    {
                        Ora = g.Key.Hours,
                        Irany = g.Key.irany,
                        Mennyiseg = g.Count()
                    });

            foreach (var sor in lekerdezes)
            {
                Console.WriteLine("\t-Óra: {0} Irány: {1} Mennyiség: {2}", sor.Ora, sor.Irany, sor.Mennyiseg);
            }
        }

        internal void AdatokFajlba()
        {
            //string nev = "also2.txt";
            //List<string> adatok = new List<string>();

            //foreach (var auto in autok)
            //{
            //    if (auto.irany == "A")
            //    {
            //        string sor = auto.belepesiIdopont.Hours.ToString("D2")
            //            + " " + auto.belepesiIdopont.Minutes.ToString("D2")
            //            + " " + auto.belepesiIdopont.Seconds.ToString("D2");

            //        adatok.Add(sor);
            //    }
            //}
            //Console.WriteLine("\t-Az idők kiírása a txt fájlba megtörtént.");

            //File.WriteAllLines(nev, adatok);

            List<Auto> alsoFele = autok.Where(j => j.irany == "A").ToList();
            List<string> kilepesek = new List<string>();
            DateTime utolsoKilepes = DateTime.MinValue;

            foreach (var auto in alsoFele)
            {
                DateTime kilepesIdo = auto.belepesiIdo.AddSeconds(auto.ora);
                if (kilepesIdo < utolsoKilepes)
                    kilepesIdo = utolsoKilepes;

                utolsoKilepes = kilepesIdo;
                kilepesek.Add($"{kilepesIdo.Hour} {kilepesIdo.Minute} {kilepesIdo.Second}");
            }

            File.WriteAllLines("also.txt", kilepesek);
            Console.WriteLine("\t-Kilépési idők kiírva az also.txt fájlba.");
        }
    }
}