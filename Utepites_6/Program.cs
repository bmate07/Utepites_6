using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utepites_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fajl = "forgalom.txt";
            Utak utak = new Utak(fajl);

            Console.WriteLine("2. feladat");
            int tol = 1;
            int ig = utak.autok.Count;
            Console.Write("\tAdja meg a jármű sorszámát: {0}-{1} ", tol, ig);

            int keresettAutoSorszama = int.Parse(Console.ReadLine());
            utak.MelyikVarosFele(keresettAutoSorszama);

            Console.WriteLine("---------------------------------");

            Console.WriteLine("3. feladat");
            string irany = "A";
            utak.UtolsoKetJarmu(irany);

            Console.WriteLine("---------------------------------");

            Console.WriteLine("4. feladat");
            utak.OrankentIranyonkent();

            Console.WriteLine("---------------------------------");

            Console.WriteLine("5. feladat");
            utak.TizLeggyorsabb();

            Console.WriteLine("---------------------------------");

            // 6. Feladat
            utak.AdatokFajlba();

            Console.ReadLine();
        }
    }
}