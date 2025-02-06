using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utepites_6
{
    internal class Auto
    {
        public int ora;
        public int perc;
        public int mp;
        public TimeSpan belepesiIdopont;
        public string irany;
        public int idealisAthaladasiIdoMasodPercben;
        public double sebesseg;

        public Auto(int ora, int perc, int mp, int idealisAthaladasiIdoMasodPercben, string irany)
        {
            this.ora = ora;
            this.perc = perc;
            this.mp = mp;
            this.idealisAthaladasiIdoMasodPercben = idealisAthaladasiIdoMasodPercben;
            this.irany = irany;
            this.belepesiIdopont = new TimeSpan(ora, perc, mp);
            this.sebesseg = SebessegSzamolo();
        }

        private double SebessegSzamolo()
        {
            double ut = 1000;
            double ido = idealisAthaladasiIdoMasodPercben;
            double sebesseg = ut / ido;
            return sebesseg;
        }
    }
}