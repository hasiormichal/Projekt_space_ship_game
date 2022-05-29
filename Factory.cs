using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class Factory
    {
        public Engine GenerateEngine(int lvl)
        {
            int weigth = 0;
            int Cost = 0;
            float Reliable = 0;
            Random random = new Random();

            switch (lvl)
            {
                case 1:
                    Reliable = (float)random.Next(51, 99) / 100;
                    weigth = random.Next(30, 70);
                    Cost = (int)(500*Math.Pow(Reliable, 2) + 500*(50/weigth)+ random.Next(100, 500));
                    return new Engine(weigth, 100, Reliable, Cost, random.Next(100, 400), random.Next(10, 30));
                case 2:
                    Reliable = (float)random.Next(55, 99) / 100;
                    weigth = random.Next(20, 60);
                    Cost = (int)(1000 * Math.Pow(Reliable, 2)*1.1 + 1000 * (50/weigth) + random.Next(300, 800));
                    return new Engine(weigth, 100, Reliable, Cost, random.Next(200, 600), random.Next(15, 40));
                case 3:
                    Reliable = (float)random.Next(60, 99) / 100;
                    weigth = random.Next(20, 50);
                    Cost = (int)(2000 * Math.Pow(Reliable, 2)*1.2 + 2000 * (50/weigth) + random.Next(1000, 2000));
                    return new Engine(weigth, 100, Reliable, Cost, random.Next(400, 800), random.Next(25, 50));
                case 4:
                    Reliable = (float)random.Next(70, 99) / 100;
                    weigth = random.Next(15, 50);
                    Cost = (int)(5000 * Math.Pow(Reliable, 2)*1.3 + 5000 * (50/weigth) + random.Next(1500, 3000));
                    return new Engine(weigth, 100, Reliable, Cost, random.Next(600, 900), random.Next(35, 60));
                case 5:
                    Reliable = (float)random.Next(75, 99) / 100;
                    weigth = random.Next(15, 30);
                    Cost = (int)(10000 * Math.Pow(Reliable, 2)*1.4 + 10000 * (50/weigth) + random.Next(3000, 5500));
                    return new Engine(weigth, 100, Reliable, Cost, random.Next(800, 1000), random.Next(50, 80));
                default:
                    throw new ArgumentException(String.Format("{0} is < 0 or > 5 in: {1}", lvl, this.ToString()), "Factory lvl Engine");
            }
        }
        public FuelTank GeneratorFuelTank(int lvl)
        {
            int weigth = 0;
            int Cost = 0;
            float Reliable = 0;
            Random random = new Random();

            switch (lvl)
            {
                case 1:
                    Reliable = (float)random.Next(51, 99) / 100;
                    weigth = random.Next(30, 70);
                    Cost = (int)(250 * Math.Pow(Reliable, 2) + 250 * (50/weigth) + random.Next(100, 500));
                    return new FuelTank(weigth, 100, Reliable, Cost, random.Next(20, 50));
                case 2:
                    Reliable = (float)random.Next(55, 99) / 100;
                    weigth = random.Next(20, 60);
                    Cost = (int)(1000 * Math.Pow(Reliable, 2) + 1000 * (50/weigth) + random.Next(300, 1000));
                    return new FuelTank(weigth, 100, Reliable, Cost, random.Next(30, 60));
                case 3:
                    Reliable = (float)random.Next(60, 99) / 100;
                    weigth = random.Next(20, 50);
                    Cost = (int)(1500 * Math.Pow(Reliable, 2)*1.1 + 1500 * (50/weigth) + random.Next(500, 2000));
                    return new FuelTank(weigth, 100, Reliable, Cost, random.Next(40, 70));
                case 4:
                    Reliable = (float)random.Next(70, 99) / 100;
                    weigth = random.Next(15, 50);
                    Cost = (int)(3000 * Math.Pow(Reliable, 2)*1.15 + 3000 * (50/weigth) + random.Next(2000, 3000));
                    return new FuelTank(weigth, 100, Reliable, Cost, random.Next(50, 100));
                case 5:
                    Reliable = (float)random.Next(75, 99) / 100;
                    weigth = random.Next(15, 30);
                    Cost = (int)(5000 * Math.Pow(Reliable, 2)*1.2 + 5000 * (50/weigth) + random.Next(3000, 4000));
                    return new FuelTank(weigth, 100, Reliable, Cost, random.Next(60, 130));
                default:
                    throw new ArgumentException(String.Format("{0} is < 0 or > 5 in: {1}", lvl, this.ToString()), "Factory lvl FuelTank");
            }
        }
        public ShieldGenerator GeneratorShieldGenerator(int lvl)
        {
            int weigth = 0;
            int Cost = 0;
            float Reliable = 0;
            int Shield = 0;
            Random random = new Random();

            switch (lvl)
            {
                case 1:
                    Reliable = (float)random.Next(51, 99) / 100;
                    weigth = random.Next(30, 70);
                    Cost = (int)(500 * Math.Pow(Reliable, 2) + 1000*Shield/25 + 500 * (50/weigth) + random.Next(750, 1000));
                    Shield = random.Next(5, 10);
                    return new ShieldGenerator(weigth, 100, Reliable, Cost, Shield);
                case 2:
                    Reliable = (float)random.Next(55, 99) / 100;
                    weigth = random.Next(20, 60);
                    Cost = (int)(1000 * Math.Pow(Reliable, 2) + 2000 * Shield / 25 + 1000 * (50 / weigth) + random.Next(1250, 1500));
                    Shield = random.Next(13, 17);
                    return new ShieldGenerator(weigth, 100, Reliable, Cost, random.Next(10, 15));
                case 3:
                    Reliable = (float)random.Next(60, 99) / 100;
                    weigth = random.Next(20, 50);
                    Shield = random.Next(20, 30);
                    Cost = (int)(1750 * Math.Pow(Reliable, 2) + 4000 * Shield / 25 + 1750 * (50 / weigth) + random.Next(2000, 2500));
                    return new ShieldGenerator(weigth, 100, Reliable, Cost, random.Next(15, 25));
                case 4:
                    Reliable = (float)random.Next(70, 99) / 100;
                    weigth = random.Next(15, 50);
                    Shield = random.Next(30, 40);
                    Cost = (int)(2500 * Math.Pow(Reliable, 2) + 8000 * Shield / 25 + 2500 * (50 / weigth) + random.Next(3000, 4000));
                    return new ShieldGenerator(weigth, 100, Reliable, Cost, random.Next(20, 35));
                case 5:
                    Reliable = (float)random.Next(75, 99) / 100;
                    weigth = random.Next(15, 30);
                    Shield = random.Next(40, 60);
                    Cost = (int)(3500 * Math.Pow(Reliable, 2) + 16000 * Shield / 25 + 3500 * (50 / weigth) + random.Next(4500, 5500));
                    return new ShieldGenerator(weigth, 100, Reliable, Cost, random.Next(30, 60));
                default:
                    throw new ArgumentException(String.Format("{0} is < 0 or > 5 in: {1}", lvl, this.ToString()), "Factory lvl ShieldGenerator");
            }
        }
        public Droid GenerateDroid(int lvl)
        {
            int weigth = 0;
            int Cost = 0;
            float Reliable = 0;
            int RepairPower = 0;
            Random random = new Random();

            switch (lvl)
            {
                case 1:
                    Reliable = (float)random.Next(51, 99) / 100;
                    weigth = random.Next(30, 70);
                    RepairPower = random.Next(5, 10);
                    Cost = (int)(500 * Math.Pow(Reliable, 2) + 500 * (50 / weigth)  + 1000*RepairPower/25 + random.Next(500, 750));
                    return new Droid(weigth, 100, Reliable, Cost,RepairPower );
                case 2:
                    Reliable = (float)random.Next(55, 99) / 100;
                    weigth = random.Next(20, 60);
                    RepairPower = random.Next(13, 20);
                    Cost = (int)(1000 * Math.Pow(Reliable, 2) + 2000 * RepairPower / 25 + 1000 * (50 / weigth) + random.Next(800,1200));
                    return new Droid(weigth, 100, Reliable, Cost, RepairPower);
                case 3:
                    Reliable = (float)random.Next(60, 99) / 100;
                    weigth = random.Next(20, 50);
                    RepairPower = random.Next(20, 30);
                    Cost = (int)(1500 * Math.Pow(Reliable, 2) + 4000 * RepairPower / 25 + 1500 * (50 / weigth) + random.Next(1200, 1600));
                    return new Droid(weigth, 100, Reliable, Cost, RepairPower);
                case 4:
                    Reliable = (float)random.Next(70, 99) / 100;
                    weigth = random.Next(15, 50);
                    RepairPower = random.Next(35,50);
                    Cost = (int)(2000 * Math.Pow(Reliable, 2) + 8000 * RepairPower / 25 + 2000 * (50 / weigth) + random.Next(1600, 2000));
                    return new Droid(weigth, 100, Reliable, Cost, RepairPower);
                case 5:
                    Reliable = (float)random.Next(75, 99) / 100;
                    weigth = random.Next(15, 30);
                    RepairPower = random.Next(50, 70);
                    Cost = (int)(4000 * Math.Pow(Reliable, 2) + 13000 * RepairPower / 25 + 40000 * (50 / weigth) + random.Next(1800, 2200));
                    return new Droid(weigth, 100, Reliable, Cost, RepairPower);
                default:
                    throw new ArgumentException(String.Format("{0} is < 0 or > 5 in: {1}", lvl, this.ToString()), "Factory lvl Droid");
            }
        }
        public Hull GenerateHull(int lvl)
        {
            int armor = 0;
            int hp = 0;
            int weigth = 0;
            int weaponNumber = 0;
            int Cost = 0;
            Random random = new Random();

            switch (lvl)
            {
                case 1:
                    armor = random.Next(1, 5);
                    hp = random.Next(400, 500);
                    weigth = random.Next(200, 400);
                    weaponNumber = random.Next(2, 3);
                    Cost =  3500 * (hp/700 + 600/weigth + weaponNumber / 3 + armor/12)+ random.Next(2500, 3000);
                    return new Hull(armor, hp, weigth, weaponNumber, Cost);
                case 2:
                    armor = random.Next(3, 8);
                    hp = random.Next(500, 650);
                    weigth = random.Next(250, 500);
                    weaponNumber = 3;
                    Cost = 6000 * (hp / 700 + 600/weigth + weaponNumber / 3 + armor / 12) + random.Next(5000, 7500);
                    return new Hull(armor, hp, weigth, weaponNumber, Cost);
                case 3:
                    armor = random.Next(5, 12);
                    hp = random.Next(650, 800);
                    weigth = random.Next(300, 600);
                    weaponNumber = random.Next(3, 4);
                    Cost = 12000 * (hp / 700 + 600/weigth + weaponNumber / 3 + armor / 12) + random.Next(10000, 13000);
                    return new Hull(armor, hp, weigth, weaponNumber, Cost);
                case 4:
                    armor = random.Next(10, 20);
                    hp = random.Next(800, 1000);
                    weigth = random.Next(400, 800);
                    weaponNumber = 4;
                    Cost = 22000 * (hp / 700 + 600/weigth + weaponNumber / 3 + armor / 12) + random.Next(20000, 25000);
                    return new Hull(armor, hp, weigth, weaponNumber, Cost);
                case 5:
                    armor = random.Next(15, 25);
                    hp = random.Next(1000, 1500);
                    weigth = random.Next(500, 900);
                    weaponNumber = random.Next(4, 5);
                    Cost = 44000 * (hp / 700 + 750/weigth + weaponNumber / 3 + armor / 12) + random.Next(45000, 65000);
                    return new Hull(armor, hp, weigth, weaponNumber, Cost);
                default:
                    throw new ArgumentException(String.Format("{0} is < 0 or > 5 in: {1}", lvl, this.ToString()), "Factory lvl Hull");
            }
        }
        public Laser GenerateLaser(int lvl)
        {
            int atack = 0;
            int weigth = 0;
            float Reliable = 0;
            int Cost = 0;  
            Random random = new Random();
            switch (lvl)
            {
                case 1:
                    Reliable = (float)random.Next(51, 99) / 100;
                    weigth = random.Next(20, 80);
                    atack = random.Next(20, 25);
                    Cost = (int)(250 * Math.Pow(Reliable, 2) + 250 * (45/weigth+ atack/27)  + random.Next(150, 300));
                    return new Laser(atack, weigth, 100, Reliable, Cost,3);
                case 2:
                    Reliable = (float)random.Next(55, 99) / 100;
                    weigth = random.Next(20, 60);
                    atack = random.Next(25, 31);
                    Cost = (int)(350 * Math.Pow(Reliable, 2) + 350 * (45 / weigth + atack /27)  +random.Next(300, 500));
                    return new Laser(atack, weigth, 100, Reliable, Cost, 4);
                case 3:
                    Reliable = (float)random.Next(60, 99) / 100;
                    weigth = random.Next(17, 45);
                    atack = random.Next(31, 38);
                    Cost = (int)(650 * Math.Pow(Reliable, 2) + 650 * (45 / weigth + atack /27) +random.Next(500, 800));
                    return new Laser(atack, weigth, 100, Reliable, Cost, 5);
                case 4:
                    Reliable = (float)random.Next(70, 99) / 100;
                    weigth = random.Next(15, 40);
                    atack = random.Next(38, 46);
                    Cost = (int)(1000 * Math.Pow(Reliable, 2) + 1250 * (45 / weigth + atack /27) +random.Next(1000, 1200));
                    return new Laser(atack, weigth, 100, Reliable, Cost, 6);
                case 5:
                    Reliable = (float)random.Next(75, 99) / 100;
                    weigth = random.Next(13, 30);
                    atack = random.Next(50, 55);
                    Cost = (int)(1500 * Math.Pow(Reliable, 2) + 2500 * (45 / weigth + atack /27) +random.Next(2000, 2500));
                    return new Laser(atack, weigth, 100, Reliable, Cost, 10);
                default:
                    throw new ArgumentException(String.Format("{0} is < 0 or > 5 in: {1}", lvl, this.ToString()), "Factory lvl Laser");
            }
        }
        public AtomicVision GenerateAtomicVision(int lvl)
        {
            int atack;
            int weigth;
            float Reliable;
            int Cost;
            float atackMultiplication;
            Random random = new Random();
            switch (lvl)
            {
                case 1:
                    Reliable = (float)random.Next(51, 99) / 100;
                    weigth = random.Next(60, 120);
                    atack = random.Next(25, 35);
                    atackMultiplication = (float)random.Next(110, 140) / 100;
                    Cost = (int)(750 * Math.Pow(Reliable, 2) + 1000 * (60/weigth + atack / 55)+ 1000*atackMultiplication +random.Next(1000, 2000));
                    return new AtomicVision(atack, weigth, 100, Reliable, Cost, atackMultiplication);
                case 2:
                    Reliable = (float)random.Next(55, 99) / 100;
                    weigth = random.Next(50, 100);
                    atack = random.Next(40, 52);
                    atackMultiplication = (float)random.Next(120, 160) / 100;
                    Cost = (int)(1000 * Math.Pow(Reliable, 2) + 3000 * (60 / weigth + atack / 55) + 3000 * atackMultiplication + random.Next(3000, 5000));
                    return new AtomicVision(atack, weigth, 100, Reliable, Cost, atackMultiplication);
                case 3:
                    Reliable = (float)random.Next(60, 99) / 100;
                    weigth = random.Next(40, 90);
                    atack = random.Next(55, 70);
                    atackMultiplication = (float)random.Next(140, 190) / 100;
                    Cost = (int)(2000 * Math.Pow(Reliable, 2) + 5000 * (60 / weigth + atack / 55) + 5000 * atackMultiplication + random.Next(5000,7000));
                    return new AtomicVision(atack, weigth, 100, Reliable, Cost, atackMultiplication);
                case 4:
                    Reliable = (float)random.Next(70, 99) / 100;
                    weigth = random.Next(30, 100);
                    atack = random.Next(70, 88);
                    atackMultiplication = (float)random.Next(150, 210) / 100;
                    Cost = (int)(4000 * Math.Pow(Reliable, 2) + 7500 * (70 / weigth + atack / 55) + 7500 * atackMultiplication + random.Next(7500,10000));
                    return new AtomicVision(atack, weigth, 100, Reliable, Cost, atackMultiplication);
                case 5:
                    Reliable = (float)random.Next(75, 99) / 100;
                    weigth = random.Next(20, 120);
                    atack = random.Next(90, 125);
                    atackMultiplication = (float)random.Next(175, 250) / 100;
                    Cost = (int)(6500 * Math.Pow(Reliable, 2) + 11250 * (80 / weigth + atack / 55) + 11250 * atackMultiplication + random.Next(10000, 13000));
                    return new AtomicVision(atack, weigth, 100, Reliable, Cost, atackMultiplication);
                default:
                    throw new ArgumentException(String.Format("{0} is < 0 or > 5 in: {1}", lvl, this.ToString()), "Factory lvl Atomic Vision");
            }
        }
        public FragmentaryCannon GenerateFragmentaryCannon(int lvl)
        {
            int atack;
            int weigth;
            float Reliable;
            int Cost;
            int bulletCount;
            Random random = new Random();
            switch (lvl)
            {
                case 1:
                    Reliable = (float)random.Next(51, 99) / 100;
                    weigth = random.Next(60, 120);
                    atack = random.Next(35, 45);
                    bulletCount = random.Next(5, 8);
                    Cost = (int)(500 * Math.Pow(Reliable, 2) + 500 * (60 / weigth + atack / 45) + random.Next(500, 1000));
                    return new FragmentaryCannon(atack, weigth, 100, Reliable, Cost, bulletCount);
                case 2:
                    Reliable = (float)random.Next(55, 99) / 100;
                    weigth = random.Next(50, 100);
                    atack = random.Next(45, 55);
                    bulletCount = random.Next(4, 7);
                    Cost = (int)(750 * Math.Pow(Reliable, 2) + 1000 * (60 / weigth + atack / 45) + random.Next(1000, 2000));
                    return new FragmentaryCannon(atack, weigth, 100, Reliable, Cost, bulletCount);
                case 3:
                    Reliable = (float)random.Next(60, 99) / 100;
                    weigth = random.Next(40, 80);
                    atack = random.Next(55, 70);
                    bulletCount = random.Next(3, 6);
                    Cost = (int)(1200 * Math.Pow(Reliable, 2) + 2000 * (60 / weigth + atack / 45) + random.Next(2000, 3000));
                    return new FragmentaryCannon(atack, weigth, 100, Reliable, Cost, bulletCount);
                case 4:
                    Reliable = (float)random.Next(70, 99) / 100;
                    weigth = random.Next(30, 60);
                    atack = random.Next(70, 85);
                    bulletCount = random.Next(3, 5);
                    Cost = (int)(2000 * Math.Pow(Reliable, 2) + 4000 * (60 / weigth + atack / 45) + random.Next(3000, 3500));
                    return new FragmentaryCannon(atack, weigth, 100, Reliable, Cost, bulletCount);
                case 5:
                    Reliable = (float)random.Next(75, 99) / 100;
                    weigth = random.Next(20, 40);
                    atack = random.Next(85, 100);
                    bulletCount = random.Next(3, 4);
                    Cost = (int)(3500 * Math.Pow(Reliable, 2) + 8000 * (60 / weigth + atack / 45) + random.Next(4500, 5500));
                    return new FragmentaryCannon(atack, weigth, 100, Reliable, Cost, bulletCount);
                default:
                    throw new ArgumentException(String.Format("{0} is < 0 or > 5 in: {1}", lvl, this.ToString()), "Factory lvl Fragmentary cannon");
            }
        }
        public HeavyCannon GenerateHeavyCannon(int lvl)
        {
            int atack;
            int weigth;
            float Reliable;
            int Cost;
            int penetration;
            Random random = new Random();
            switch (lvl)
            {
                case 1:
                    Reliable = (float)random.Next(51, 99) / 100;
                    weigth = random.Next(40, 100);
                    atack = random.Next(30, 45);
                    penetration = random.Next(1, 2);
                    Cost = (int)(1000 * Math.Pow(Reliable, 2) + 1000 * (80 / weigth + atack / 75) + 1000*penetration /9  + random.Next(500, 1000));
                    return new HeavyCannon(atack, weigth, 100, Reliable, Cost, penetration);
                case 2:
                    Reliable = (float)random.Next(55, 99) / 100;
                    weigth = random.Next(45, 90);
                    atack = random.Next(45, 60);
                    penetration = random.Next(2, 4);
                    Cost = (int)(1500 * Math.Pow(Reliable, 2) + 2000 * (80 / weigth + atack / 75) +2000* penetration / 9 + random.Next(1500,2500));
                    return new HeavyCannon(atack, weigth, 100, Reliable, Cost, penetration);
                case 3:
                    Reliable = (float)random.Next(60, 99) / 100;
                    weigth = random.Next(50, 70);
                    atack = random.Next(60, 75);
                    penetration = random.Next(4, 7);
                    Cost = (int)(2000 * Math.Pow(Reliable, 2) + 4000 * (80 / weigth + atack / 75) + 4000*penetration / 9 + random.Next(3000,4000));
                    return new HeavyCannon(atack, weigth, 100, Reliable, Cost, penetration);
                case 4:
                    Reliable = (float)random.Next(70, 99) / 100;
                    weigth = random.Next(60, 95);
                    atack = random.Next(75, 95);
                    penetration = random.Next(7, 11);
                    Cost = (int)(3500 * Math.Pow(Reliable, 2) + 6000 * (80 / weigth + atack / 75) + 6000*penetration / 9 + random.Next(5000,7000));
                    return new HeavyCannon(atack, weigth, 100, Reliable, Cost, penetration);
                case 5:
                    Reliable = (float)random.Next(75, 99) / 100;
                    weigth = random.Next(60, 130);
                    atack = random.Next(95, 120);
                    penetration = random.Next(11, 15);
                    Cost = (int)(5000 * Math.Pow(Reliable, 2) + 10000 * (80 / weigth + atack / 75) + 10000*penetration / 9 + random.Next(7000,10000));
                    return new HeavyCannon(atack, weigth, 100, Reliable, Cost, penetration);
                default:
                    throw new ArgumentException(String.Format("{0} is < 0 or > 5 in: {1}", lvl, this.ToString()), "Factory lvl Heavy Cannon");
            }
        }
        public RocketLauncher GenerateRocketLuncher(int lvl)
        {
            int atack;
            int weigth;
            float Reliable;
            int Cost;
            Random random = new Random();
            switch (lvl)
            {
                case 1:
                    Reliable = (float)random.Next(51, 99) / 100;
                    weigth = random.Next(40, 60);
                    atack = random.Next(30, 35);
                    Cost = (int)(750 * Math.Pow(Reliable, 2) + 750 * (40 / weigth + atack / 50) + random.Next(500, 1000));
                    return new RocketLauncher(atack, weigth, 100, Reliable, Cost, 30);
                case 2:
                    Reliable = (float)random.Next(55, 99) / 100;
                    weigth = random.Next(35, 55);
                    atack = random.Next(35, 45);
                    Cost = (int)(1000 * Math.Pow(Reliable, 2) + 1250 * (40 / weigth + atack / 50) + random.Next(750, 1500));
                    return new RocketLauncher(atack, weigth, 100, Reliable, Cost, 30);
                case 3:
                    Reliable = (float)random.Next(60, 99) / 100;
                    weigth = random.Next(30, 50);
                    atack = random.Next(45, 55);
                    Cost = (int)(1250 * Math.Pow(Reliable, 2) + 1750 * (40 / weigth + atack / 50) + random.Next(3000, 4000));
                    return new RocketLauncher(atack, weigth, 100, Reliable, Cost, 45);
                case 4:
                    Reliable = (float)random.Next(70, 99) / 100;
                    weigth = random.Next(25, 45);
                    atack = random.Next(55, 65);
                    Cost = (int)(1750 * Math.Pow(Reliable, 2) + 2500 * (40 / weigth + atack / 50) + random.Next(4000, 5000));
                    return new RocketLauncher(atack, weigth, 100, Reliable, Cost, 45);
                case 5:
                    Reliable = (float)random.Next(75, 99) / 100;
                    weigth = random.Next(20, 35);
                    atack = random.Next(70, 90);
                    Cost = (int)(2500 * Math.Pow(Reliable, 2) + 5000 * (40 / weigth + atack / 50) + random.Next(6000, 7000));
                    return new RocketLauncher(atack, weigth, 100, Reliable, Cost, 60);
                default:
                    throw new ArgumentException(String.Format("{0} is < 0 or > 5 in: {1}", lvl, this.ToString()), "Factory lvl Rocket Luncher");
            }
        }
        public Tetronik GenerateTetronik(int lvl)
        {
            int atack;
            int weigth;
            float Reliable;
            int Cost;
            float bonusDamage;
            Random random = new Random();
            switch (lvl)
            {
                case 1:
                    Reliable = (float)random.Next(51, 99) / 100;
                    weigth = random.Next(80, 140);
                    atack = random.Next(40, 50);
                    bonusDamage = (float)random.Next(0, 13) / 100;
                    Cost = (int)(750 * Math.Pow(Reliable, 2) + 1000 * (100 / weigth + atack / 100) + 1500*3*bonusDamage+ random.Next(1000, 2000));
                    return new Tetronik(atack, weigth, 100, Reliable, Cost, bonusDamage);
                case 2:
                    Reliable = (float)random.Next(55, 99) / 100;
                    weigth = random.Next(70, 130);
                    atack = random.Next(50, 60);
                    bonusDamage = (float)random.Next(7, 20) / 100;
                    Cost = (int)(1500 * Math.Pow(Reliable, 2) + 2000 * (100 / weigth + atack / 100) + 2500 * 3 * bonusDamage + random.Next(2000,3000));
                    return new Tetronik(atack, weigth, 100, Reliable, Cost, bonusDamage);
                case 3:
                    Reliable = (float)random.Next(60, 99) / 100;
                    weigth = random.Next(70, 120);
                    atack = random.Next(60, 80);
                    bonusDamage = (float)random.Next(13, 27) / 100;
                    Cost = (int)(2500 * Math.Pow(Reliable, 2) + 3000 * (100 / weigth + atack / 100) + 4000 * 3 * bonusDamage + random.Next(4000, 5000));
                    return new Tetronik(atack, weigth, 100, Reliable, Cost, bonusDamage);
                case 4:
                    Reliable = (float)random.Next(70, 99) / 100;
                    weigth = random.Next(65, 120);
                    atack = random.Next(85, 110);
                    bonusDamage = (float)random.Next(20, 37) / 100;
                    Cost = (int)(4000 * Math.Pow(Reliable, 2) + 5000 * (100 / weigth + atack / 100) + 9000 * 3 * bonusDamage + random.Next(7000, 8000));
                    return new Tetronik(atack, weigth, 100, Reliable, Cost, bonusDamage);
                case 5:
                    Reliable = (float)random.Next(75, 99) / 100;
                    weigth = random.Next(75, 130);
                    atack = random.Next(130, 170);
                    bonusDamage = (float)random.Next(25, 49) / 100;
                    Cost = (int)(6000 * Math.Pow(Reliable, 2) + 8000 * (100 / weigth + atack / 100) + 14000 * 3 * bonusDamage + random.Next(12000, 150000));
                    return new Tetronik(atack, weigth, 100, Reliable, Cost, bonusDamage);
                default:
                    throw new ArgumentException(String.Format("{0} is < 0 or > 5 in: {1}", lvl, this.ToString()), "Factory lvl Tetronik");
            }
        }
        public Vortex GenerateVortex(int lvl)
        {
            int atack;
            int weigth;
            float Reliable;
            int Cost;
            int shieldPenetration;
            Random random = new Random();
            switch (lvl)
            {
                case 1:
                    Reliable = (float)random.Next(51, 99) / 100;
                    weigth = random.Next(50, 100);
                    atack = random.Next(35, 45);
                    shieldPenetration = random.Next(0, 4);
                    Cost = (int)(500 * Math.Pow(Reliable, 2) + 750 * (50/ weigth + atack / 70) + 1500 * shieldPenetration/20 + random.Next(750, 1250));
                    return new Vortex(atack, weigth, 100, Reliable, Cost, shieldPenetration);
                case 2:
                    Reliable = (float)random.Next(55, 99) / 100;
                    weigth = random.Next(40, 80);
                    atack = random.Next(45, 60);
                    shieldPenetration = random.Next(4, 9);
                    Cost = (int)(1000 * Math.Pow(Reliable, 2) + 1250 * (50 / weigth + atack / 70) + 2500 * shieldPenetration / 20 + random.Next(1000, 2000));
                    return new Vortex(atack, weigth, 100, Reliable, Cost, shieldPenetration);
                case 3:
                    Reliable = (float)random.Next(60, 99) / 100;
                    weigth = random.Next(30, 60);
                    atack = random.Next(60, 80);
                    shieldPenetration = random.Next(8, 15);
                    Cost = (int)(1500 * Math.Pow(Reliable, 2) + 2500 * (50 / weigth + atack / 70) + 4000 * shieldPenetration / 20 + random.Next(2000, 2500));
                    return new Vortex(atack, weigth, 100, Reliable, Cost, shieldPenetration);
                case 4:
                    Reliable = (float)random.Next(70, 99) / 100;
                    weigth = random.Next(25, 50);
                    atack = random.Next(80, 105);
                    shieldPenetration = random.Next(13, 23);
                    Cost = (int)(2000 * Math.Pow(Reliable, 2) + 4000 * (50 / weigth + atack / 70) + 8000 * shieldPenetration / 20 + random.Next(3000, 4000));
                    return new Vortex(atack, weigth, 100, Reliable, Cost, shieldPenetration);
                case 5:
                    Reliable = (float)random.Next(75, 99) / 100;
                    weigth = random.Next(20, 40);
                    atack = random.Next(105, 135);
                    shieldPenetration = random.Next(20, 35);
                    Cost = (int)(4000 * Math.Pow(Reliable, 2) + 8000 * (50 / weigth + atack / 70) + 14000 * shieldPenetration / 20 + random.Next(6000, 8000));
                    return new Vortex(atack, weigth, 100, Reliable, Cost, shieldPenetration);
                default:
                    throw new ArgumentException(String.Format("{0} is < 0 or > 5 in: {1}", lvl, this.ToString()), "Factory lvl Vortex");
            }
        }
    }
}
