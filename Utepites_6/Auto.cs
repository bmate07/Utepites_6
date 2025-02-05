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
        public int idealisAthaladasiIdoPercben;

        public Auto(int ora, int perc, int mp, int idealisAthaladasiIdoPercben, string irany)
        {
            this.ora = ora;
            this.perc = perc;
            this.mp = mp;
            this.idealisAthaladasiIdoPercben = idealisAthaladasiIdoPercben;
            this.irany = irany;
            this.belepesiIdopont = new TimeSpan(ora, perc, mp);
        }
    }
}