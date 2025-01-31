﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            Auto keresettAuto = autok[keresettAutoSorszama - 1];
            Console.WriteLine("\t\t-A {0} sorszámú autó {1} irányba halad", keresettAutoSorszama, keresettAuto.irany);
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
                int idealisAthaladasiIdoPercben = int.Parse(oszlopok[3]);
                string irany = oszlopok[4];

                autok.Add(new Auto(ora, perc, mp, idealisAthaladasiIdoPercben, irany));
            }
        }
    }
}