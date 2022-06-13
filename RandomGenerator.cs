using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class RandomGenerator
    {
        private Factory eqFactory = new Factory();
        private Random random = new Random();

        private readonly int lvl1Probability = 40;
        private readonly int lvl2Probability = 60;
        private readonly int lvl3Probability = 70;
        private readonly int lvl4Probability = 80;
        private readonly int lvl5Probability = 90;

        private readonly GeneratorConst BaseProbability = new GeneratorConst(); 

        private int SetLvl( int lvl)
        {
            int lvlSeed = 45;
            switch (lvl)
            {
                case 1:
                    lvlSeed = random.Next(0, 45);
                    break;
                case 2:
                    lvlSeed = random.Next(30, 63);
                    break;
                case 3:
                    lvlSeed = random.Next(50, 73);
                    break;
                case 4:
                    lvlSeed = random.Next(65, 83);
                    break;
                case 5:
                    lvlSeed = random.Next(75, 90);
                    break;
                default:
                    lvl = 45;
                    break;
            }
            
            if(lvlSeed < lvl1Probability)
            {
                return 1;
            }
            else if(lvlSeed > lvl1Probability && lvlSeed <= lvl2Probability)
            {
                return 2;
            }
            else if( lvlSeed > lvl2Probability && lvlSeed <= lvl3Probability)
            {
                return 3;
            }
            else if (lvlSeed > lvl3Probability && lvlSeed <= lvl4Probability)
            {
                return 4;
            }
            else if ( lvlSeed > lvl4Probability && lvlSeed <= lvl5Probability)
            {
                return 5;
            }
            else
            {
                return 1;
            }
        }
        public Weapon RandomWeapon (int lvl) 
        {
            int seed = random.Next(50-10*(5-lvl),50+10*lvl);
            
            if(seed <= BaseProbability.BaseFragmentaryCannonProbability)
            {
                return eqFactory.GenerateFragmentaryCannon(SetLvl(lvl));
            }
            else if(seed > BaseProbability.BaseFragmentaryCannonProbability && seed <= BaseProbability.BaseLaserProbability)
            {
                return eqFactory.GenerateLaser(SetLvl(lvl));
            }
            else if(seed > BaseProbability.BaseLaserProbability && seed <= BaseProbability.BaseRocketLuncherProbability)
            {
                return eqFactory.GenerateRocketLuncher(SetLvl(lvl));
            }
            else if(seed > BaseProbability.BaseRocketLuncherProbability && seed <= BaseProbability.BaseHeavyCannonProbability)
            {
                return eqFactory.GenerateHeavyCannon(SetLvl(lvl));
            }
            else if(seed > BaseProbability.BaseHeavyCannonProbability && seed <= BaseProbability.BaseVortexProbability)
            {
                return eqFactory.GenerateVortex(SetLvl(lvl));
            }
            else if(seed > BaseProbability.BaseVortexProbability && seed <= BaseProbability.BaseTetronikProbability)
            {
                return eqFactory.GenerateTetronik(SetLvl(lvl));
            }
            else if (seed > BaseProbability.BaseTetronikProbability && seed <= BaseProbability.BaseAtomicVisionProbability)
            {
                return eqFactory.GenerateAtomicVision(SetLvl(lvl));
            }
            else
            {
                return new Laser(1,50,100,99,0,3);
            }
        }
        public Equipment RandomEQ (int lvl, int ID)
        {
            switch (ID)
            {
                case 1:
                    return eqFactory.GenerateEngine(SetLvl(lvl));
                case 2:
                    return eqFactory.GeneratorFuelTank(SetLvl(lvl));
                case 3:
                    return eqFactory.GeneratorShieldGenerator(SetLvl(lvl));
                case 4:
                    return eqFactory.GenerateDroid(SetLvl(lvl));
                default: return new Droid(30, 100, 99, 0, 0);
            }
        }
        public Hull RandomHull (int lvl)
        {
            return eqFactory.GenerateHull(SetLvl(lvl));
        }

        public Player GeneratePlayer (Planet localization)
        {
            int lvl = localization.PlanetLvl;
            Hull TempHull = RandomHull(lvl);
            List <Weapon> WeaponList = new List <Weapon>();
            for(int i=0; i<TempHull.MaximumNumberOfWeapons; i++)
            {
                WeaponList.Add(RandomWeapon(lvl));
            }
            Ship TempShip = new Ship(TempHull, WeaponList, (Engine)RandomEQ(lvl, 1), (FuelTank)RandomEQ(lvl, 2),
                (ShieldGenerator)RandomEQ(lvl, 3), (Droid)RandomEQ(lvl, 4));

            int counter = 0;
            while (TempShip.GetCurrentWeigth() >= TempHull.MaxWeigth)
            {
                switch (counter)
                {
                    case 0:
                        Engine TempEngine = (Engine)RandomEQ(lvl, 1);
                        if(TempEngine.BaseWeigth < TempShip.Engine.BaseWeigth)
                        {
                            TempShip.Engine = TempEngine;
                        }
                        counter++;
                        break;
                    case 1:
                        FuelTank TempFuelTank = (FuelTank)(RandomEQ(lvl, 2));
                        if(TempFuelTank.BaseWeigth < TempShip.FuelTank.BaseWeigth)
                        {
                            TempShip.FuelTank = TempFuelTank;
                        }
                        counter++;
                        break;
                    case 2:
                        ShieldGenerator TempShieldGenerator = (ShieldGenerator)RandomEQ(lvl, 3);
                        if(TempShieldGenerator.BaseWeigth < TempShip.ShieldGenerator.BaseWeigth)
                        {
                            TempShip.ShieldGenerator = TempShieldGenerator;
                        }
                        counter++;
                        break;
                    case 3:
                        Droid TempDroid = (Droid)RandomEQ(lvl, 4);
                        if(TempDroid.BaseWeigth < TempShip.Droid.BaseWeigth)
                        {
                            TempShip.Droid = TempDroid;
                        }
                        counter++;
                        break;

                    //weapons now
                    case 4:
                        Weapon TempWeapon1 = RandomWeapon(lvl);
                        if(TempWeapon1.BaseWeigth < TempShip.Weapons[0].BaseWeigth)
                        {
                            TempShip.Weapons[0] = TempWeapon1;
                        }
                        counter++;
                        if(counter >= TempHull.MaximumNumberOfWeapons + 4) counter = 0;
                        break;
                    case 5:
                        Weapon TempWeapon2 = RandomWeapon(lvl);
                        if (TempWeapon2.BaseWeigth < TempShip.Weapons[1].BaseWeigth)
                        {
                            TempShip.Weapons[1] = TempWeapon2;
                        }
                        counter++;
                        if (counter >= TempHull.MaximumNumberOfWeapons + 4) counter = 0;
                        break;
                    case 6:
                        Weapon TempWeapon3 = RandomWeapon(lvl);
                        if (TempWeapon3.BaseWeigth < TempShip.Weapons[2].BaseWeigth)
                        {
                            TempShip.Weapons[2] = TempWeapon3;
                        }
                        counter++;
                        if (counter >= TempHull.MaximumNumberOfWeapons + 4) counter = 0;
                        break;
                    case 7:
                        Weapon TempWeapon4 = RandomWeapon(lvl);
                        if (TempWeapon4.BaseWeigth < TempShip.Weapons[3].BaseWeigth)
                        {
                            TempShip.Weapons[3] = TempWeapon4;
                        }
                        counter++;
                        if (counter >= TempHull.MaximumNumberOfWeapons + 4) counter = 0;
                        break;
                    case 8:
                        Weapon TempWeapon5 = RandomWeapon(lvl);
                        if (TempWeapon5.BaseWeigth < TempShip.Weapons[4].BaseWeigth)
                        {
                            TempShip.Weapons[4] = TempWeapon5;
                        }
                        counter =0;
                        break;
                    default:
                        throw new ArgumentException(String.Format("Generate switch invalid state: {0} Out of range (0,8)", lvl), "Generate random player");
                }
            }
            for(int i=0; i < 2; i++)
            {
                int upgradeChance = random.Next(lvl, (int)Math.Pow(lvl, 2));
                if (upgradeChance > 2 * lvl)
                {
                    int WeaponNumber = random.Next(0, WeaponList.Count);
                    int UpgradeNumber = random.Next(0, 7);
                    if (WeaponList[WeaponNumber].ToString() == "Projekt.RocketLauncher") continue;
                        switch (UpgradeNumber)
                    {
                        case 0:
                            WeaponList[WeaponNumber] = new ShieldDestroyer(WeaponList[WeaponNumber], WeaponList[WeaponNumber].BaseAtack,
                            WeaponList[WeaponNumber].BaseWeigth, WeaponList[WeaponNumber].BaseHealth, WeaponList[WeaponNumber].BaseReliable
                            , WeaponList[WeaponNumber].Cost);
                            break;
                        case 1:
                            WeaponList[WeaponNumber] = new HugeDamageUpgrade(WeaponList[WeaponNumber], WeaponList[WeaponNumber].BaseAtack,
                            WeaponList[WeaponNumber].BaseWeigth, WeaponList[WeaponNumber].BaseHealth, WeaponList[WeaponNumber].BaseReliable
                            , WeaponList[WeaponNumber].Cost);
                            break;
                        case 2:
                            WeaponList[WeaponNumber] = new DoubleShotDecorator(WeaponList[WeaponNumber], WeaponList[WeaponNumber].BaseAtack,
                            WeaponList[WeaponNumber].BaseWeigth, WeaponList[WeaponNumber].BaseHealth, WeaponList[WeaponNumber].BaseReliable
                            , WeaponList[WeaponNumber].Cost);
                            break;
                        case 3:
                            WeaponList[WeaponNumber] = new WeakWeaponUpgrade(WeaponList[WeaponNumber], WeaponList[WeaponNumber].BaseAtack,
                            WeaponList[WeaponNumber].BaseWeigth, WeaponList[WeaponNumber].BaseHealth, WeaponList[WeaponNumber].BaseReliable
                            , WeaponList[WeaponNumber].Cost, 2);
                            break;
                        case 4:
                            WeaponList[WeaponNumber] = new WeakWeaponUpgrade(WeaponList[WeaponNumber], WeaponList[WeaponNumber].BaseAtack,
                            WeaponList[WeaponNumber].BaseWeigth, WeaponList[WeaponNumber].BaseHealth, WeaponList[WeaponNumber].BaseReliable
                            , WeaponList[WeaponNumber].Cost, 3);
                            break;
                        default:
                            WeaponList[WeaponNumber] = new WeakWeaponUpgrade(WeaponList[WeaponNumber], WeaponList[WeaponNumber].BaseAtack,
                            WeaponList[WeaponNumber].BaseWeigth, WeaponList[WeaponNumber].BaseHealth, WeaponList[WeaponNumber].BaseReliable
                            , WeaponList[WeaponNumber].Cost, 1);
                            break;

                    }
                }
            
                TempShip.Weapons = WeaponList;
            }
            return new Player("Random "+random.Next(0,9999), TempShip , random.Next((int)(1700+600*Math.Pow(lvl, 2)), (int)(2300+800 * Math.Pow(lvl, 2))),localization );
        }
    }
}
