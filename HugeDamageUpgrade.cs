using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class HugeDamageUpgrade : WeaponsDecorator
    {
        // Weak upgrade
        // +35%

        //Upgrade cost = 1.15*MyWeapon.Const   ==> so total cost is 2.15*MyWeapon.Const
        public HugeDamageUpgrade(Weapon _Ship, int _atack, int _weigth, float _health, float _reliable, int _cost)
           : base(_Ship, _atack, _weigth, _health, _reliable, _cost)
        {
            MyWeapon.BaseAtack += (int)(MyWeapon.BaseAtack * 0.35);
            MyWeapon.Cost = (int)(MyWeapon.Cost * 2.15);
            BaseAtack += (int)(BaseAtack * 0.35);
            Cost = (int)(Cost * 2.15);
        }
        public override string Print()
        {
            return "Huge Damage Upgrade | " + MyWeapon.Print();
        }
        public override string PrintName()
        {
            return MyWeapon.PrintName() + " Damage upgrade";
        }
    }
}

