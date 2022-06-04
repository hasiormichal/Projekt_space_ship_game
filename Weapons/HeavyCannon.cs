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
                atack = (this.BaseAtack / BulletCount) - (this.BaseAtack / BulletCount * TargetShip.ShieldGenerator.Shield/100) - (TargetShip.Hull.Armor - armorPenetration);
                if (atack <= 0) return 0;
                else return atack * BulletCount;
            }
            else
            {
               atack = this.BaseAtack / BulletCount - (TargetShip.Hull.Armor - armorPenetration);
                if (atack <= 0) return 0;
                else return atack * BulletCount;
            }
        }
        public override int DamageShip(Ship TargetShip , int atack)
        {
            int CannonAtack;
            if (TargetShip.ShieldGenerator.BaseHealth > 0)
            {
                CannonAtack = (this.BaseAtack / BulletCount) - (this.BaseAtack / BulletCount * TargetShip.ShieldGenerator.Shield / 100) - (TargetShip.Hull.Armor - armorPenetration);
                if (atack <= 0) CannonAtack= 0;
            }
            else
            {
                CannonAtack = this.BaseAtack / BulletCount - (TargetShip.Hull.Armor - armorPenetration);
                if (atack <= 0) CannonAtack =0;
            }

            for (int i = 0; i< BulletCount; i++)
            {
                base.DamageShip(TargetShip, CannonAtack);
            }

            return 1;
        }
        public override string Print()
        {
            return this.PrintName() + "\nArmor Penetration: " + armorPenetration + "\n" + base.Print();
        }
        public override string PrintName()
        {
            return "Heavy Cannon";
        }
    }
}
