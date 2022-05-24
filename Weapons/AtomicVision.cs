using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class AtomicVision : Weapon
    {
        private readonly float atackMultiplication;

        public AtomicVision(int atack, int weigth, float healt, float reliable, int cost, float _atackMultiplication) : base(atack, weigth, healt, reliable, cost)
        {
            if (_atackMultiplication < 0 || _atackMultiplication > 3)
            {
                throw new ArgumentException(String.Format("{0} is < 0 or > 3 in: {1}", _atackMultiplication, this.ToString()), "AtackMultiplication");
            }
            else
            {
                atackMultiplication = _atackMultiplication;
            }
        }

        public override int GetAtack(Ship TargetShip)
        {
            int atack;
            if (TargetShip.ShieldGenerator.BaseHealth > 0)
            {
                atack = ((int)(this.BaseAtack * atackMultiplication)) -( TargetShip.ShieldGenerator.Shield/100* (int)(this.BaseAtack * atackMultiplication)) - TargetShip.Hull.Armor;
            }
            else
            {
                atack = (int)(this.BaseAtack * atackMultiplication) - TargetShip.Hull.Armor;
            }
            return atack;
        }
        public override string Print()
        {
            return this.GetType() +"\nAtack Multiplicator: " + atackMultiplication + "\n"+ base.Print();
        }
    }
}
