using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class ShieldDestroyer : WeaponsDecorator
    {
        public ShieldDestroyer(Weapon _Ship, int _atack, int _weigth, float _health, float _reliable, int _cost)
            : base(_Ship, _atack, _weigth, _health, _reliable, _cost)
        {
            MyWeapon.BaseAtack = (int)(MyWeapon.BaseAtack * 0.8);
            MyWeapon.Cost = (int)(MyWeapon.Cost * 2.5);
            BaseAtack = (int)(BaseAtack * 0.8);
            Cost = (int)(Cost * 2.5);
        }

        public override int DamageShip(Ship TargetShip, int atack)
        {
            float temp;
            if (TargetShip.Hull.Health - atack < 0)
            {
                TargetShip.Hull.Health = 0;
            }
            else if (TargetShip.Hull.Health - atack >= TargetShip.Hull.MaxHealth)
            {
                TargetShip.Hull.Health = TargetShip.Hull.MaxHealth;
            }
            else
            {
                TargetShip.Hull.Health -= atack;
            }
            for(int i=0; i<3; i++)
            {
                if (TargetShip.ShieldGenerator.BaseHealth > 0)
                {
                    temp = (float)(Math.Pow(atack*2, 2) / TargetShip.Hull.Health * 2.5 * (1 - Math.Pow(TargetShip.ShieldGenerator.BaseReliable, 2)));
                    if ((TargetShip.ShieldGenerator.BaseHealth - temp) < 0)
                    {
                        TargetShip.ShieldGenerator.BaseHealth = 0;
                    }
                    else
                    {
                        TargetShip.ShieldGenerator.BaseHealth -= temp;
                    }
                }
            }
            return 1;
        }
        public override int GetAtack(Ship targegShip)
        {
            return MyWeapon.GetAtack(targegShip);
        }
        public override string Print()
        {
            return "Shield Destroyer Upgrade | " + MyWeapon.Print();
        }
        public override string PrintName()
        {
            return MyWeapon.PrintName() + " Shield Destroyer Upgrade";
        }
        public override int Repair()
        {
            return (int)((100.0 - BaseHealth) * Cost / 1000);
        }
    }
}

