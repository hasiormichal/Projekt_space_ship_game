using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public abstract class Weapon : IFWeapon
    {
        private int baseAtack;
        private int baseWeigth;
        private float baseHealth;
        private float baseReliable;
        private int cost;

        public Weapon()
        {
            baseAtack = 1;
            baseWeigth = 1;
            BaseHealth = 100;
            baseReliable = (float)0.99;
            cost = 1;
        }
        public Weapon(int _atack, int _weigth, float _health, float _reliable, int _cost)
        {
            BaseAtack = _atack;
            BaseWeigth = _weigth;
            BaseHealth = _health;
            BaseReliable = _reliable;
            Cost = _cost;
        }
        public int BaseAtack
        {
            get { return baseAtack; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(String.Format("{0} is < 0 in: {1}", value, this.ToString()), "Atack");
                }
                else
                {
                    baseAtack = value;
                }
            }
        }
        public int BaseWeigth
        {
            get { return baseWeigth; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(String.Format("{0} is < 0 in: {1}", value, this.ToString()), "Weigth");
                }
                else
                {
                    baseWeigth = value;
                }
            }
        }
        public float BaseHealth
        {
            get { return baseHealth; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(String.Format("{0} is < 0 or > 100 in {1}", value, this.ToString()), "Health");
                }
                else
                {
                    baseHealth = value;
                }
            }
        }   
        public float BaseReliable
        {
            get { return baseReliable; }
            set
            {
                if (value < 0.5 || value > 1)
                {
                    throw new ArgumentException(String.Format("{0} is < 0.5 or > 1 in: {1}", value, this.ToString()), "Reliable");
                }
                else
                {
                    baseReliable = value;
                }
            }
        }    
        public int Cost
        {
            get { return cost; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(String.Format("{0} is < 0 in: {1}", value, this.ToString()), "Cost");
                }
                else
                {
                    cost = value;
                }
            }
        }

        public virtual int GetAtack(Ship TargetShip)
        {
            int atack = this.BaseAtack / TargetShip.ShieldGenerator.Shield - TargetShip.Hull.Armor;
            return atack;
        }
        virtual public int DamageShip(Ship TargetShip, int atack)
        {
            // retun int for optional error codes
            //----------------------  Eq damage -----------------------------
            float temp;
            if(TargetShip.Hull.Health - atack < 0)
            {
                TargetShip.Hull.Health = 0;
            }
            else
            {
                TargetShip.Hull.Health -= atack;
            }
            if (TargetShip.ShieldGenerator.BaseHealth > 0)
            {
                temp = (float)(Math.Pow(atack, 2) / TargetShip.Hull.Health * 2.5 * (1- Math.Pow(TargetShip.ShieldGenerator.BaseReliable,2)));
                if((TargetShip.ShieldGenerator.BaseHealth - temp) < 0)
                {
                    TargetShip.ShieldGenerator.BaseHealth = 0;
                }
                else
                {
                    TargetShip.ShieldGenerator.BaseHealth -= temp;
                }
            }

            if (TargetShip.Droid.BaseHealth > 0)
            {
                temp = (float)(Math.Pow(atack, 2) / TargetShip.Hull.Health * 2.5 * (1 - Math.Pow(TargetShip.Droid.BaseReliable, 2)));
                if ((TargetShip.Droid.BaseHealth - temp) < 0)
                {
                    TargetShip.Droid.BaseHealth = 0;
                }
                else
                {
                    TargetShip.Droid.BaseHealth -= temp;
                }
            }

            if (TargetShip.Engine.BaseHealth > 0)
            {
                temp = (float)(Math.Pow(atack, 2) / TargetShip.Hull.Health * 2.5 * (1 - Math.Pow(TargetShip.Engine.BaseReliable, 2)));
                if ((TargetShip.Engine.BaseHealth - temp) < 0)
                {
                    TargetShip.Engine.BaseHealth = 0;
                }
                else
                {
                    TargetShip.Engine.BaseHealth -= temp;
                }
            }

            if (TargetShip.FuelTank.BaseHealth > 0)
            {
                temp = (float)(Math.Pow(atack, 2) / TargetShip.Hull.Health * 2.5 * (1 - Math.Pow(TargetShip.FuelTank.BaseReliable, 2)));
                if ((TargetShip.FuelTank.BaseHealth - temp) < 0)
                {
                    TargetShip.FuelTank.BaseHealth = 0;
                }
                else
                {
                    TargetShip.FuelTank.BaseHealth -= temp;
                }
            }

            // -------------------------- weapon damage ---------------------------
            foreach (Weapon CurentWeapon in TargetShip.Weapons)
            {
                if (CurentWeapon.BaseHealth > 0)
                {
                    temp = (float)(Math.Pow(atack, 2) / TargetShip.Hull.Health * 2.5 * (1 - Math.Pow(CurentWeapon.BaseReliable, 2)));
                    if ((CurentWeapon.BaseHealth - temp) < 0)
                    {
                        CurentWeapon.BaseHealth = 0;
                    }
                    else
                    {
                        CurentWeapon.BaseHealth -= temp;
                    }
                }
            }
            return 1;
        }
        public virtual int Repair()
        {
            return (int)((100.0 - BaseHealth) * Cost / 1000);
        }
        public virtual string Print()
        {
            string temp = "Atack: " + baseAtack + "\n";
            temp += "Weigth: " + baseWeigth + " | ";
            temp += "Health: " + baseHealth + " | ";
            temp += "Reliable: " + baseReliable + " ||| ";
            temp += "Cost: " + cost + "\n";
            return temp;
        }
        public virtual string PrintName() 
        {
            return "Weapon";
        }
    }
}
