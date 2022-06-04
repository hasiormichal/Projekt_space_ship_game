using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class Tetronik : Weapon
    {
        private readonly float bonusDamage;
        public Tetronik(int atack, int weigth, float healt, float reliable, int cost, float _bonusDamage) : base(atack, weigth, healt, reliable, cost)
        {
            if (_bonusDamage < 0 || _bonusDamage > 0.49)
            {
                throw new ArgumentException(String.Format("{0} is < 0 or > 0.49 in: {1}", _bonusDamage, this.ToString()), "BonusDamage");
            }
            else
            {
                bonusDamage = _bonusDamage;
            }
        }

        public override int GetAtack(Ship TargetShip)
        {
            int atack;
            if (TargetShip.ShieldGenerator.BaseHealth > 0)
            {
                atack = this.BaseAtack - (this.BaseAtack * TargetShip.ShieldGenerator.Shield/100) - TargetShip.Hull.Armor;
            }
            else
            {
                atack = this.BaseAtack - TargetShip.Hull.Armor;
            }
            return atack;
        }


        public override int DamageShip(Ship TargetShip, int atack)
        {
            // retun int for optional error codes
            //----------------------  Eq damage -----------------------------
            float temp;
            if (TargetShip.Hull.Health - atack < 0)
            {
                TargetShip.Hull.Health = 0;
            }
            else
            {
                TargetShip.Hull.Health -= atack;
            }
            if (TargetShip.ShieldGenerator.BaseHealth > 0)
            {
                temp = (float)(Math.Pow(atack, 2) / TargetShip.Hull.Health * 2.5 * (1 - Math.Pow(TargetShip.ShieldGenerator.BaseReliable-bonusDamage, 2)));
                if ((TargetShip.ShieldGenerator.BaseHealth - temp) < 0)
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
                temp = (float)(Math.Pow(atack, 2) / TargetShip.Hull.Health * 2.5 * (1 - Math.Pow(TargetShip.Droid.BaseReliable - bonusDamage, 2)));
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
                temp = (float)(Math.Pow(atack, 2) / TargetShip.Hull.Health * 2.5 * (1 - Math.Pow(TargetShip.Engine.BaseReliable - bonusDamage, 2)));
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
                temp = (float)(Math.Pow(atack, 2) / TargetShip.Hull.Health * 2.5 * (1 - Math.Pow(TargetShip.FuelTank.BaseReliable - bonusDamage, 2)));
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
                    temp = (float)(Math.Pow(atack, 2) / TargetShip.Hull.Health * 2.5 * (1 - Math.Pow(CurentWeapon.BaseReliable - bonusDamage, 2)));
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
        public override string Print()
        {
            return this.PrintName() + "\nBonus EQ damage: " + bonusDamage + "\n" + base.Print();
        }
        public override string PrintName()
        {
            return "Tetronik";
        }
    }
}
