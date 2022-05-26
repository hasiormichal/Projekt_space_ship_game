using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projekt
{
    class Laser : Weapon
    {
        private readonly int extraDamage  = 5;
        public Laser(int atack, int weigth,float healt, float reliable, int cost, int _extradamage ) : base(atack , weigth,healt, reliable, cost)
        {
            if (_extradamage < 0 || _extradamage > 10)
            {
                throw new ArgumentException(String.Format("{0} is < 0 or > 10 in: {1}", _extradamage, this.ToString()), "ExtraPower");
            }
            else
            {
                extraDamage = _extradamage;
            }
        }

        public override int GetAtack(Ship TargetShip)
        {
            int atack;
            if (TargetShip.ShieldGenerator.BaseHealth > 0)
            {
                atack = (this.BaseAtack + extraDamage) - ((this.BaseAtack + extraDamage)* TargetShip.ShieldGenerator.Shield/100) - TargetShip.Hull.Armor;
            }
            else
            {
                atack = this.BaseAtack + extraDamage - TargetShip.Hull.Armor;
            }
            return atack;
        }
        public override string Print()
        {
            return this.PrintName() + "\nExtra Damage: " + extraDamage + "\n" + base.Print();
        }
        public override string PrintName()
        {
            return "Laser";
        }
    }
}
