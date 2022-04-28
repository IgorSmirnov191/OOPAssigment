using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetlat
{
    class Meetlat
    {
        private double lengteInMeter;
        public double BeginLengte { 
            set 
            { 
                this.lengteInMeter = value;
            } 
        }
        public double LengteInM
        {
            get { return this.lengteInMeter; }
        }
        public double LengteInCm
        {
            get { return this.lengteInMeter * 100; }
        }
        public double LengteInKm
        {
            get { return this.lengteInMeter /1000; }
        }
        public double LengteInVoet
        {
            get { return this.lengteInMeter / 3.2808; }
        }
        public Meetlat() { }

        public Meetlat(double lengteInMetet) 
        {
            this.lengteInMeter=lengteInMetet;
        }



    }
}
