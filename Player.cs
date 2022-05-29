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

            if(MyShip.Hull.Health > MyShip.Hull.MaxHealth)
            {
                MyShip.Hull.Health = MyShip.Hull.MaxHealth;
            }
            else
            {
                MyShip.Hull.Health += MyShip.Droid.RepairPower;
            }

            return TotalDamage;
        }
        public string Travel(Planet TargetPlanet)
        {
            if (Localization.TravelMap.ContainsKey(TargetPlanet.Name))
            {
                if (Localization.TravelMap[TargetPlanet.Name] > MyShip.Engine.JumpRange)
                {
                    return "Engine has not enougth jump power: " + MyShip.Engine.JumpRange + " | need: " + Localization.TravelMap[TargetPlanet.Name];
                }
                if(Localization.TravelMap[TargetPlanet.Name] > MyShip.FuelTank.Capacity)
                {
                    return "Fuel Tank has not enougth Fuel: " + MyShip.FuelTank.Capacity + " | need: " + Localization.TravelMap[TargetPlanet.Name];
                }
                MyShip.FuelTank.Capacity -= Localization.TravelMap[TargetPlanet.Name];
                Localization = TargetPlanet;
                return "Successful travel";
            }
            else
            {
                return "Error: Target planet " + TargetPlanet.Name + " does not exist!";
            }
        }
    }
}
