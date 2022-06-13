using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class WeakWeaponUpgrade : WeaponsDecorator
    {
        // Weak upgrade
        //  decision 1 -> Damage +10%
        //  decision 2 -> Weigth -20%
        //  decision 3 -> damage +5 , Weigth -5% , reliable + 10%;

        //Upgrade cost = 0.5*MyWeapon.Const   ==> so total cost is 1.5*MyWeapon.Const
        public WeakWeaponUpgrade(Weapon _Ship, int _atack, int _weigth, float _health, float _reliable, int _cost , int decision)
           : base(_Ship, _atack, _weigth, _health, _reliable, _cost)
        {
            switch (decision)
            {
                case 1:
                    MyWeapon.BaseAtack += (int)(MyWeapon.BaseAtack*0.10);
                    MyWeapon.Cost = (int)(MyWeapon.Cost * 1.5);
                    BaseAtack += (int)(BaseAtack * 0.10);
                    Cost = (int)(Cost * 1.5);
                    break;

                case 2:
                    MyWeapon.BaseWeigth -= (int)(MyWeapon.BaseWeigth * 0.20);
                    MyWeapon.Cost = (int)(MyWeapon.Cost * 1.5);
                    BaseWeigth -= (int)(BaseWeigth * 0.20);
                    Cost = (int)(Cost * 1.5);
                    break;

                case 3:
                    MyWeapon.BaseAtack += (int)(MyWeapon.BaseAtack * 0.05);
                    MyWeapon.BaseWeigth -= (int)(MyWeapon.BaseWeigth * 0.05);
                    BaseAtack += (int)(MyWeapon.BaseAtack * 0.05);
                    BaseWeigth -= (int)(BaseWeigth * 0.05);
                    if ((MyWeapon.BaseReliable + MyWeapon.BaseReliable * 0.1) > 0.99)
                    {
                        MyWeapon.BaseReliable = (float)0.99;
                    }
                    else
                    {
                        MyWeapon.BaseReliable += MyWeapon.BaseReliable / 10;
                    }

                    if ((BaseReliable + (float)(BaseReliable * 0.1)) > 0.99)
                    {
                        BaseReliable = (float)0.99;
                    }
                    else
                    {
                        BaseReliable += (float)(BaseReliable * 0.1);
                    }
                    Cost = (int)(Cost * 1.5);
                    MyWeapon.Cost = (int)(MyWeapon.Cost * 1.5);
                    break;

            }

        }
        public override string Print()
        {
            return "Weak Upgrade | " + MyWeapon.Print(); ;
        }
        public override string PrintName()
        {
            return "Weak upgrade " +MyWeapon.PrintName();
        }

    }
}
