using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Vortex : Weapon
    {
        private readonly int shieldPenetration;

        public Vortex() : base()
        {
            shieldPenetration = 1;
        }
        public Vortex(int atack, int weigth, float healt, float reliable, int cost, int _shieldPenetration) : base(atack, weigth, healt, reliable, cost)
        {
            if (_shieldPenetration < 0 || _shieldPenetration > 35)
            {
                throw new ArgumentException(String.Format("{0} is < 0 or > 50 in: {1}", _shieldPenetration, this.ToString()), "ShieldPenetration");
            }
            else
            {
                shieldPenetration = _shieldPenetration;
            }
        }

        public override int GetAtack(Ship TargetShip)
        {
            int atack;
            if (TargetShip.ShieldGenerator.BaseHealth > 0)
            {
                if(TargetShip.ShieldGenerator.Shield - shieldPenetration > 0)
                {
                    atack = (this.BaseAtack) - (this.BaseAtack * (TargetShip.ShieldGenerator.Shield - shieldPenetration)/100) - TargetShip.Hull.Armor;
                }
                else
                {
                    atack = (this.BaseAtack)- TargetShip.Hull.Armor;
                }
            }
            else
            {
                atack = this.BaseAtack - TargetShip.Hull.Armor;
            }
            return atack;
        }
        public override string Print()
        {
            return this.PrintName() + "\nShield Penetration: " + shieldPenetration + "\n" + base.Print();
        }
        public override string PrintName()
        {
            return "Vortex";
        }
    }
}
