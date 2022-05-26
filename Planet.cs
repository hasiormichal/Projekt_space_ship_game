using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class Planet
    {
        private string name;
        private int planetLvl;
        private int fuelCost;
        private int rocketCost;

        public Dictionary<string, int> TravelMap;

        private List<Weapon> weaponList;
        private Engine newEngine;
        private FuelTank newFuelTank;
        private ShieldGenerator newShieldGenerator;
        private Droid newDroid;
        private Hull newHull;

        public Engine NewEngine { get { return newEngine; } }
        public FuelTank NewFuelTank { get { return newFuelTank; }}
        public ShieldGenerator NewShieldGenerator { get { return newShieldGenerator; }}
        public  Droid NewDroid { get { return newDroid; }}
        public Hull NewHull { get { return newHull; }}
        public List <Weapon> WeaponList { get { return weaponList; } }

        public Planet (string _name, int _fuelCost , int _rocketCost,Dictionary<string,int> map ,  int _lvl = 1)
        {
            //TODO: add expatation for FuelCost and RocketCost value
            name = _name;
            TravelMap = map;
            fuelCost = _fuelCost;
            rocketCost = _rocketCost;
            planetLvl = _lvl;
            GenerateNewQE();
            GenerateNewWeapons();

        }
        public void GenerateNewQE()
        {
            RandomGenerator EQGenerator = new RandomGenerator();
            newEngine = (Engine)EQGenerator.RandomEQ(planetLvl, 1);
            newFuelTank = (FuelTank)EQGenerator.RandomEQ(planetLvl, 2);
            newShieldGenerator = (ShieldGenerator)EQGenerator.RandomEQ(planetLvl, 3);
            newDroid = (Droid)EQGenerator.RandomEQ(planetLvl, 4);
            newHull = EQGenerator.RandomHull(planetLvl);
        }

        public void GenerateNewWeapons()
        {
            RandomGenerator WeaponGenerator = new RandomGenerator();
            Random rand = new Random();
            int WeaponNumber = rand.Next(2, 5);
            List<Weapon> TempList = new List<Weapon>();
            for (int i = 0; i < WeaponNumber; i++)
            {
                TempList.Add(WeaponGenerator.RandomWeapon(planetLvl));
            }
            weaponList = TempList;
        }

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
