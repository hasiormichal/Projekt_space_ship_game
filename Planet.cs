using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class Planet
    {
        private int planetLvl =1;
        private readonly int fuelCost =10;
        private readonly int rocketCost =10;

        public int RocketCost { get { return rocketCost; } }
        public int FuelCost { get { return fuelCost; } }
        public  int PlanetLvl { 
            get { return planetLvl; } 
            set 
            {
                if (value < 0 && value >5)
                {
                    throw new ArgumentException(String.Format("{0} is < 0 or V 5in: {1}", value, this.ToString()), "Planet LvL");
                }
                else
                {
                    planetLvl = value;
                }
            }
        }
    }
}
