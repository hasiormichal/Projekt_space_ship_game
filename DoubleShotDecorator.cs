using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class DoubleShotDecorator : WeaponsDecorator
    {
        public DoubleShotDecorator(Weapon _Ship, int _atack, int _weigth, float _health, float _reliable, int _cost)
            : base(_Ship, _atack, _weigth, _health, _reliable, _cost)
        {
            MyWeapon.BaseAtack = (int)(MyWeapon.BaseAtack * 0.7);
            MyWeapon.Cost = (int)(MyWeapon.Cost * 2.00);
            BaseAtack = (int)(BaseAtack * 0.7);
            Cost = (int)(Cost * 2.00);
        }

        public override int DamageShip(Ship TargetShip, int atack)
        {
            int TotalDamage = 0;
            for(int i = 0; i<2; i++)
            {
                TotalDamage += MyWeapon.DamageShip(TargetShip, MyWeapon.GetAtack(TargetShip));

            }
            return TotalDamage;
        }
        public override int GetAtack(Ship targegShip)
        {
            return MyWeapon.GetAtack(targegShip) * 2;
        }
        public override string Print()
        {
            return "Double Shot Upgrade | " + MyWeapon.Print();
        }
        public override string PrintName()
        {
            return "Double Shot Upgrade " + MyWeapon.PrintName();
        }
        public override int Repair()
        {
            return (int)((100.0 - BaseHealth) * Cost / 1000);
        }
    }
}
