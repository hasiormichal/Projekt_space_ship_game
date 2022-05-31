using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Ship
    {
        private Hull hull;
        private List<Weapon> weapons;
        private Engine engine;
        private FuelTank fuelTank;
        private ShieldGenerator shieldGenerator;
        private Droid droid;

        public Ship()
        {
            Hull = new Hull();
            Weapons = new List<Weapon>();
            Engine = new Engine();
            FuelTank = new FuelTank();
            ShieldGenerator = new ShieldGenerator();
            Droid = new Droid();
        }
        public Ship (Hull _hull, List<Weapon> _weapons, Engine _engine, 
                    FuelTank _fueltank, ShieldGenerator _shieldgenerator, Droid _droid)
        {
            Hull = _hull;
            Weapons = _weapons;
            Engine = _engine;
            FuelTank = _fueltank;
            ShieldGenerator = _shieldgenerator;
            Droid = _droid;
        }

        public Hull Hull
        {
            get { return hull; }
            set
            {
                hull = value;
            }
        }
        public List<Weapon> Weapons 
        { 
            get { return weapons; } 
            set 
            { 
                if(value.Count > this.hull.MaximumNumberOfWeapons)
                {
                    throw new ArgumentException(String.Format("{0} is > {1} in: {2}", value.Count, this.hull.MaximumNumberOfWeapons, this.ToString()), "Weapon List");
                }
                else
                {
                    weapons = value;
                }
            }
        }
        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }
        public FuelTank FuelTank
        {
            get { return fuelTank; }
            set { fuelTank = value; }
        }
        public ShieldGenerator ShieldGenerator
        {
            get { return shieldGenerator; }
            set { shieldGenerator = value; }
        }
        public Droid Droid
        {
            get { return droid; }
            set { droid = value; }
        }
        public string ShowShipStatus()
        {
            string status = hull.ToString() + " " + hull.Health + "/" + hull.MaxHealth + "   Repair cost: "+hull.Repair()+"\n";
            status += engine.ToString() + " " + engine.BaseHealth + "/100   Repair cost: " + engine.Repair() + "\n";
            status += fuelTank.ToString() + " " + fuelTank.BaseHealth + "/100   Repair cost: " + fuelTank.Repair() + "\n";
            status += shieldGenerator.ToString() + " " + shieldGenerator.BaseHealth + "/100   Repair cost: " + shieldGenerator.Repair() + "\n";
            status += droid.ToString() + " " + droid.BaseHealth + "/100   Repair cost: " + droid.Repair() + "\n";
            foreach(Weapon WeaponList in weapons)
            {
                status += WeaponList.ToString() + " " + WeaponList.BaseHealth + "/100   Repair cost: " + WeaponList.Repair() + "\n";
            }
            return status;
        }
        public string UseWeapons(Ship TargetShip)
        {
            string result = "Atack results:\n";
            int totalDamage = 0;
            foreach(Weapon MyWeapon in weapons)
            {
                MyWeapon.DamageShip(TargetShip, MyWeapon.GetAtack(TargetShip));
                result += MyWeapon.PrintName() + " deal: " + MyWeapon.GetAtack(TargetShip) + " dmg. \n";
                totalDamage += MyWeapon.GetAtack(TargetShip);

                //rocket launcher lost 3 rocket per atack
            }
            if(TargetShip.Droid.BaseHealth > 0)
            {
                if(TargetShip.hull.Health + TargetShip.droid.RepairPower >= TargetShip.hull.MaxHealth)
                {
                    TargetShip.hull.Health = TargetShip.hull.MaxHealth;
                }
                else
                {
                    TargetShip.hull.Health += TargetShip.droid.RepairPower;
                }
            }
            return result + "Total Damage: "+  totalDamage;
        }
        public int GetCurrentWeigth()
        {
            int CurrentWeigth =0;
            foreach (Weapon myweapon in weapons)
            {
                CurrentWeigth += myweapon.BaseWeigth;
            }
            return CurrentWeigth + engine.BaseWeigth + fuelTank.BaseWeigth + shieldGenerator.BaseWeigth + droid.BaseWeigth;
        }
    }
}
