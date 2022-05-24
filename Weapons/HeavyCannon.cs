using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class HeavyCannon : Weapon
    {
        private int armorPenetration;
        private int BulletCount = 5;

        public HeavyCannon(int _atack,int _weigth, float _health, float _reliable, int _cost, int _armorPenetration) : base(_atack,_weigth, _health, _reliable, _cost)
        {
            if (_armorPenetration < 0 || _armorPenetration > 25)
            {
                throw new ArgumentException(String.Format("{0} is < 0 or > 20 in: {1}", _armorPenetration, this.ToString()), "armorPenetration");
            }
            else
            {
                armorPenetration = _armorPenetration;
            }
        }
        public override int GetAtack(Ship TargetShip)
        {
            int atack;
            if (TargetShip.ShieldGenerator.BaseHealth > 0)
            {
                atack = (this.BaseAtack / BulletCount) - (this.BaseAtack / 5* TargetShip.ShieldGenerator.Shield/100) - (TargetShip.Hull.Armor - armorPenetration);
            }
            else
            {
               atack = this.BaseAtack / BulletCount - (TargetShip.Hull.Armor - armorPenetration);
            }
            return atack;
        }
        public override int DamageShip(Ship TargetShip , int atack)
        {
            for (int i = 0; i< BulletCount; i++)
            {
                if (TargetShip.Hull.Health - GetAtack(TargetShip) < 0)
                {
                    TargetShip.Hull.Health = 0;
                }
                else
                {
                    TargetShip.Hull.Health -= GetAtack(TargetShip);
                }
                base.DamageShip(TargetShip, GetAtack(TargetShip));
            }

            return 1;
        }
        public override string Print()
        {
            return this.GetType() + "\nArmor Penetration: " + armorPenetration + "\n" + base.Print();
        }
    }
}
