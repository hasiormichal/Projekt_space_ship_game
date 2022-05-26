using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class Player
    {
        public string Name;
        public Ship MyShip;
        public int MyMoney;
        public int Score;
        public Planet Localization;

        public Player(string _name , Ship _ship, int _money, Planet _localization, int _score = 0)
        {
            Name = _name;   
            MyShip = _ship;
            MyMoney = _money;
            Score = _score;
            Localization = _localization;
        }

        public int RepairAll()
        {
            int TotalCost = MyShip.Hull.Repair() + MyShip.Engine.Repair() + MyShip.FuelTank.Repair() + MyShip.ShieldGenerator.Repair()
                + MyShip.Droid.Repair();
            foreach (Weapon Weapons in MyShip.Weapons)
            {
                TotalCost += Weapons.Repair();
            }
            return TotalCost;
        }
        public int Atack (Ship TargetShip)
        {
            int TotalDamage = 0;
            foreach (Weapon Weapon in MyShip.Weapons)
            {
                TotalDamage += Weapon.GetAtack(TargetShip);
            }
            MyShip.Hull.Health += MyShip.Droid.RepairPower;
            if(MyShip.Hull.Health > MyShip.Hull.MaxHealth)
            {
                MyShip.Hull.Health = MyShip.Hull.MaxHealth;
            }

            return TotalDamage;
        }
        public int Travel(Planet TargetPlanet)
        {
            foreach (Dictionary<string,int> temp in Localization.TravelMap)
            {
                //TODO
            }
        }
    }
}
