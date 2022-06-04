using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class FragmentaryCannon : Weapon
    {
        private readonly int bulletCount;
        public FragmentaryCannon(int _atack, int _weigth, float _health, float _reliable, int _cost, int _bulletCount) : base(_atack, _weigth, _health, _reliable, _cost)
        {
            if (_bulletCount < 1 || _bulletCount > 10)
            {
                throw new ArgumentException(String.Format("{0} is < 4 or > 10 in: {1}", _bulletCount, this.ToString()), "BulletCount");
            }
            else
            {
                bulletCount = _bulletCount;
            }
        }
        public override int GetAtack(Ship TargetShip)
        {
            int atack;
            if (TargetShip.ShieldGenerator.BaseHealth > 0)
            {
                atack = (this.BaseAtack / bulletCount) -  (this.BaseAtack / bulletCount*TargetShip.ShieldGenerator.Shield/100) - TargetShip.Hull.Armor;
                if(atack <= 0) return 0;
                else return atack * bulletCount;
            }
            else
            {
                atack = this.BaseAtack / bulletCount - TargetShip.Hull.Armor;
                if (atack <= 0) return 0;
                else return atack * bulletCount;
            }
        }
        public override int DamageShip(Ship TargetShip, int atack)
        {
            int CannonAtack;
            if (TargetShip.ShieldGenerator.BaseHealth > 0)
            {
                CannonAtack = (this.BaseAtack / bulletCount) - (this.BaseAtack / bulletCount * TargetShip.ShieldGenerator.Shield / 100) - TargetShip.Hull.Armor;
                if (atack <= 0) CannonAtack =0;
            }
            else
            {
                CannonAtack = this.BaseAtack / bulletCount - TargetShip.Hull.Armor;
                if (atack <= 0) CannonAtack =0;
            }
            for (int i = 0; i < bulletCount; i++)
            {
                base.DamageShip(TargetShip, CannonAtack);
            }

            return 1;
        }
        public override string Print()
        {
            return this.PrintName() + "\nBulet Count: " + bulletCount + "\n" + base.Print();
        }
        public override string PrintName()
        {
            return "Fragmentary Cannon";
        }
    }
}
