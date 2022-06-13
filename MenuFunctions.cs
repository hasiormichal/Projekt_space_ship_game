
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class MenuFunctions
    {
        public List<Planet> PlanetList;
        public void MenuChoicePrintShip(Player player)
        {
            string[] MainMenu = {"exit","engine", "fuel tank", "Shield generator", "droid", "hull", "weapon 1", "weapon 2",
                "weapon 3","weapon 4","weapon 5"};
            bool ExitFlag = true;
            string result;
            PrintMenu menu1 = new PrintMenu();
            menu1._menu = MainMenu;
            while (ExitFlag)
            {
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n My money: " + player.MyMoney + "$");
                Console.WriteLine("Fuel:" + player.MyShip.FuelTank.Capacity + "/" + player.MyShip.FuelTank.MaxCapacity +
                    "| Refile cost: " + player.MyShip.FuelTank.FuelRefile(player.Localization.FuelCost));
                int TotalRocketCost = 0;
                RocketLauncher tempRocket = new RocketLauncher(10, 30, 100, (float)0.9, 100, 30);
                foreach (Weapon weapons in player.MyShip.Weapons)
                {
                    if (weapons.GetType() == tempRocket.GetType())
                    {
                        tempRocket = (RocketLauncher)weapons;
                        Console.WriteLine("Rockets: " + tempRocket.MagazinSize + "/" + tempRocket.MaxMagazinSize);
                        TotalRocketCost += tempRocket.BuyRocket(player.Localization.RocketCost);
                    }

                }

                result = menu1.MenuToPrint();
                switch (result)
                {
                    case "engine":
                        Console.WriteLine(player.MyShip.Engine.Print());
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "fuel tank":
                        Console.WriteLine(player.MyShip.FuelTank.Print());
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "Shield generator":
                        Console.WriteLine(player.MyShip.ShieldGenerator.Print());
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "droid":
                        Console.WriteLine(player.MyShip.Droid.Print());
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "hull":
                        Console.WriteLine(player.MyShip.Hull.Print());
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "weapon 1":
                        if (player.MyShip.Weapons.Count >= 1)
                        {
                            Console.WriteLine(player.MyShip.Weapons[0].Print());
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Ship do not 1 weapon slot");
                            Console.ReadKey();
                            Console.Clear();
                        }

                        break;
                    case "weapon 2":
                        if (player.MyShip.Weapons.Count >= 2)
                        {
                            Console.WriteLine(player.MyShip.Weapons[1].Print());
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Ship do not 2 weapon slot");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "weapon 3":
                        if (player.MyShip.Weapons.Count >= 3)
                        {
                            Console.WriteLine(player.MyShip.Weapons[2].Print());
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Ship do not 3 weapon slot");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "weapon 4":
                        if (player.MyShip.Weapons.Count >= 4)
                        {
                            Console.WriteLine(player.MyShip.Weapons[3].Print());
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Ship do not 4 weapon slot");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "weapon 5":
                        if (player.MyShip.Weapons.Count >= 5)
                        {
                            Console.WriteLine(player.MyShip.Weapons[4].Print());
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Ship do not 5 weapon slot");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "exit":
                        ExitFlag = false;
                        break;
                }
            }
        }
        public void MenuChoicePrintRepair(Player player)
        {
            string[] MainMenu = { "exit", "all" ,"engine", "fuel tank", "Shield generator", "droid", "hull", "weapon 1", "weapon 2",
                "weapon 3","weapon 4","weapon 5" };
            bool ExitFlag = true;
            string result;
            PrintMenu menu1 = new PrintMenu();
            string[] ShortList = new string[7 + player.MyShip.Hull.MaximumNumberOfWeapons];
            Array.Copy(MainMenu, ShortList, 7 + player.MyShip.Hull.MaximumNumberOfWeapons);
            menu1._menu = ShortList;

            while (ExitFlag)
            {
                int TotalRepaiCost = player.RepairAll();
                Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\nAll repair cost: " + TotalRepaiCost);
                Console.WriteLine("Hull repair cost: " + player.MyShip.Hull.Repair());
                Console.WriteLine("Engine repair cost: " + player.MyShip.Engine.Repair());
                Console.WriteLine("Fuel Tank repair cost: " + player.MyShip.FuelTank.Repair());
                Console.WriteLine("Shield Generator repair cost: " + player.MyShip.ShieldGenerator.Repair());
                Console.WriteLine("Droid repair cost: " + player.MyShip.Droid.Repair());
                for (int i = 0; i < player.MyShip.Weapons.Count; i++)
                {
                    Console.WriteLine("Weapon nr. " + i + " repair cost: " + player.MyShip.Weapons[i].Repair());
                }
                Console.WriteLine("\nMy money: " + player.MyMoney);
                result = menu1.MenuToPrint();

                switch (result)
                {
                    case "all":
                        if (TotalRepaiCost == 0)
                        {
                            Console.WriteLine("Nothhing to repair");
                            Console.Clear();
                        }
                        if (player.MyMoney - TotalRepaiCost < 0)
                        {
                            Console.WriteLine("Not Enougth Money");
                            Console.Clear();
                        }
                        else
                        {
                            player.MyMoney -= TotalRepaiCost;
                            player.MyShip.Hull.Health = player.MyShip.Hull.MaxHealth;
                            player.MyShip.Engine.BaseHealth = 100;
                            player.MyShip.FuelTank.BaseHealth = 100;
                            player.MyShip.ShieldGenerator.BaseHealth = 100;
                            player.MyShip.Droid.BaseHealth = 100;
                            foreach (Weapon weapons in player.MyShip.Weapons)
                            {
                                weapons.BaseHealth = 100;
                            }
                            Console.Clear();
                        }
                        break;
                    case "engine":
                        if (player.MyMoney - player.MyShip.Engine.Repair() < 0)
                        {
                            Console.WriteLine("Not Enougth Money");
                            Console.Clear();
                        }
                        else
                        {
                            player.MyMoney -= player.MyShip.Engine.Repair();
                            player.MyShip.Engine.BaseHealth = 100;
                            Console.Clear();
                        }
                        break;
                    case "fuel tank":
                        if (player.MyMoney - player.MyShip.FuelTank.Repair() < 0)
                        {
                            Console.WriteLine("Not Enougth Money");
                            Console.Clear();
                        }
                        else
                        {
                            player.MyMoney -= player.MyShip.FuelTank.Repair();
                            player.MyShip.FuelTank.BaseHealth = 100;
                            Console.Clear();
                        }
                        break;
                    case "Shield generator":
                        if (player.MyMoney - player.MyShip.ShieldGenerator.Repair() < 0)
                        {
                            Console.WriteLine("Not Enougth Money");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            player.MyMoney -= player.MyShip.ShieldGenerator.Repair();
                            player.MyShip.ShieldGenerator.BaseHealth = 100;
                            Console.Clear();
                        }
                        break;
                    case "droid":
                        if (player.MyMoney - player.MyShip.Droid.Repair() < 0)
                        {
                            Console.WriteLine("Not Enougth Money");
                            Console.Clear();
                        }
                        else
                        {
                            player.MyMoney -= player.MyShip.Droid.Repair();
                            player.MyShip.Droid.BaseHealth = 100;
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "hull":
                        if (player.MyMoney - player.MyShip.Hull.Repair() < 0)
                        {
                            Console.WriteLine("Not Enougth Money");
                            Console.Clear();
                        }
                        else
                        {
                            player.MyMoney -= player.MyShip.Hull.Repair();
                            player.MyShip.Hull.Health = player.MyShip.Hull.MaxHealth;
                            Console.Clear();
                        }
                        break;
                    case "weapon 1":
                        if (player.MyMoney - player.MyShip.Weapons[0].Repair() < 0)
                        {
                            Console.WriteLine("Not Enougth Money");
                            Console.Clear();
                        }
                        else
                        {
                            player.MyMoney -= player.MyShip.Weapons[0].Repair();
                            player.MyShip.Weapons[0].BaseHealth = 100;
                            Console.Clear();
                        }
                        break;
                    case "weapon 2":
                        if (player.MyMoney - player.MyShip.Weapons[1].Repair() < 0)
                        {
                            Console.WriteLine("Not Enougth Money");
                            Console.Clear();
                        }
                        else
                        {
                            player.MyMoney -= player.MyShip.Weapons[1].Repair();
                            player.MyShip.Weapons[1].BaseHealth = 100;
                            Console.Clear();
                        }
                        break;
                    case "weapon 3":
                        if (player.MyMoney - player.MyShip.Weapons[2].Repair() < 0)
                        {
                            Console.WriteLine("Not Enougth Money");
                            Console.Clear();
                        }
                        else
                        {
                            player.MyMoney -= player.MyShip.Weapons[2].Repair();
                            player.MyShip.Weapons[2].BaseHealth = 100;
                            Console.Clear();
                        }
                        break;
                    case "weapon 4":
                        if (player.MyMoney - player.MyShip.Weapons[3].Repair() < 0)
                        {
                            Console.WriteLine("Not Enougth Money");
                            Console.Clear();
                        }
                        else
                        {
                            player.MyMoney -= player.MyShip.Weapons[3].Repair();
                            player.MyShip.Weapons[3].BaseHealth = 100;
                            Console.Clear();
                        }
                        break;
                    case "weapon 5":
                        if (player.MyMoney - player.MyShip.Weapons[4].Repair() < 0)
                        {
                            Console.WriteLine("Not Enougth Money");
                            Console.Clear();
                        }
                        else
                        {
                            player.MyMoney -= player.MyShip.Weapons[4].Repair();
                            player.MyShip.Weapons[4].BaseHealth = 100;
                            Console.Clear();
                        }
                        break;
                    case "exit":
                        ExitFlag = false;
                        break;
                }
            }
        }
        public void MenuBuyEQ(Planet CurrentPlanet, Player CurrentPlayer)
        {
            string[] MainMenu = { "exit", "refresh", "engine", "fuel tank", "Shield generator", "droid", "hull" };
            bool ExitFlag = true;
            string result;
            PrintMenu menu1 = new PrintMenu();
            menu1._menu = MainMenu;

            Engine NewEngine = CurrentPlanet.NewEngine;
            FuelTank NewFuelTank = CurrentPlanet.NewFuelTank;
            ShieldGenerator NewShieldGenerator = CurrentPlanet.NewShieldGenerator;
            Droid NewDroid = CurrentPlanet.NewDroid;
            Hull NewHull = CurrentPlanet.NewHull;


            while (ExitFlag)
            {
                string[] ChoiceMenu = { "Exit", "Buy" };
                string ChoiceResult;
                bool ChoiceExitFlag = true;
                PrintMenu menu2 = new PrintMenu();
                menu2._menu = ChoiceMenu;
                Console.WriteLine("\n          | Cost: " + Math.Pow(CurrentPlanet.PlanetLvl, 2) * 100 + "$");
                result = menu1.MenuToPrint();
                switch (result)
                {
                    case "refresh":
                        if (CurrentPlayer.MyMoney - (int)(Math.Pow(CurrentPlanet.PlanetLvl, 2) * 100) < 0)
                        {
                            Console.WriteLine("Not Enougth Money");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            CurrentPlayer.MyMoney -= (int)(Math.Pow(CurrentPlanet.PlanetLvl, 2) * 100);
                            CurrentPlanet.GenerateNewQE();
                            NewEngine = CurrentPlanet.NewEngine;
                            NewFuelTank = CurrentPlanet.NewFuelTank;
                            NewShieldGenerator = CurrentPlanet.NewShieldGenerator;
                            NewDroid = CurrentPlanet.NewDroid;
                            NewHull = CurrentPlanet.NewHull;
                            Console.WriteLine("Successful refresh");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "exit":
                        ExitFlag = false;
                        break;
                    case "engine":
                        while (ChoiceExitFlag)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n\n\n--- My Engine: --- \n" + CurrentPlayer.MyShip.Engine.Print());
                            Console.WriteLine("Ship Weigth: " + CurrentPlayer.MyShip.GetCurrentWeigth() + " / " + CurrentPlayer.MyShip.Hull.MaxWeigth);
                            Console.WriteLine("Money: " + CurrentPlayer.MyMoney + "$  + (Sell old for: )" + (int)(CurrentPlayer.MyShip.Engine.Cost / 4) + "$");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("\n\n ##### New Engine ##### \n" + NewEngine.Print());
                            ChoiceResult = menu2.MenuToPrint();
                            switch (ChoiceResult)
                            {
                                case "Exit":
                                    ChoiceExitFlag = false;
                                    break;
                                case "Buy":
                                    if (CurrentPlayer.MyMoney + (int)(CurrentPlayer.MyShip.Engine.Cost / 4) - NewEngine.Cost < 0)
                                    {
                                        Console.WriteLine("Not Enougth Money");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    if (CurrentPlayer.MyShip.GetCurrentWeigth() - CurrentPlayer.MyShip.Engine.BaseWeigth + NewEngine.BaseWeigth >= CurrentPlayer.MyShip.Hull.MaxWeigth)
                                    {
                                        Console.WriteLine("Not Enougth Ship Weigth");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        CurrentPlayer.MyMoney += (int)(CurrentPlayer.MyShip.Engine.Cost / 4);
                                        CurrentPlayer.MyShip.Engine = NewEngine;
                                        CurrentPlayer.MyMoney -= NewEngine.Cost;
                                        ChoiceExitFlag = false;
                                        Console.WriteLine("Successful purchase");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    break;
                            }
                        }
                        break;
                    case "fuel tank":
                        while (ChoiceExitFlag)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n\n\n--- My Fuel Tank: --- \n" + CurrentPlayer.MyShip.FuelTank.Print());
                            Console.WriteLine("Ship Weigth: " + CurrentPlayer.MyShip.GetCurrentWeigth() + " / " + CurrentPlayer.MyShip.Hull.MaxWeigth);
                            Console.WriteLine("Money: " + CurrentPlayer.MyMoney + "$  + (Sell old for: )" + (int)(CurrentPlayer.MyShip.FuelTank.Cost / 4) + "$");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("\n\n ##### New Fuel Tank #####\n" + NewFuelTank.Print());
                            ChoiceResult = menu2.MenuToPrint();
                            switch (ChoiceResult)
                            {
                                case "Exit":
                                    ChoiceExitFlag = false;
                                    break;
                                case "Buy":
                                    if (CurrentPlayer.MyMoney + (int)(CurrentPlayer.MyShip.FuelTank.Cost / 4) - NewFuelTank.Cost < 0)
                                    {
                                        Console.WriteLine("Not Enougth Money");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    if (CurrentPlayer.MyShip.GetCurrentWeigth() - CurrentPlayer.MyShip.Engine.BaseWeigth + NewFuelTank.BaseWeigth >= CurrentPlayer.MyShip.Hull.MaxWeigth)
                                    {
                                        Console.WriteLine("Not Enougth Ship Weigth");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        CurrentPlayer.MyMoney += (int)(CurrentPlayer.MyShip.FuelTank.Cost / 4);
                                        CurrentPlayer.MyShip.FuelTank = NewFuelTank;
                                        CurrentPlayer.MyMoney -= NewFuelTank.Cost;
                                        ChoiceExitFlag = false;
                                        Console.WriteLine("Successful purchase");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    break;
                            }
                        }
                        break;
                    case "Shield generator":
                        while (ChoiceExitFlag)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n\n\n--- My Shield generator: --- \n" + CurrentPlayer.MyShip.ShieldGenerator.Print());
                            Console.WriteLine("Ship Weigth: " + CurrentPlayer.MyShip.GetCurrentWeigth() + " / " + CurrentPlayer.MyShip.Hull.MaxWeigth);
                            Console.WriteLine("Money: " + CurrentPlayer.MyMoney + "$  + (Sell old for: )" + (int)(CurrentPlayer.MyShip.ShieldGenerator.Cost / 4) + "$");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("\n\n ##### New Shield generator #####\n" + NewShieldGenerator.Print());
                            ChoiceResult = menu2.MenuToPrint();
                            switch (ChoiceResult)
                            {
                                case "Exit":
                                    ChoiceExitFlag = false;
                                    break;
                                case "Buy":
                                    if (CurrentPlayer.MyMoney + (int)(CurrentPlayer.MyShip.ShieldGenerator.Cost / 4) - NewShieldGenerator.Cost < 0)
                                    {
                                        Console.WriteLine("Not Enougth Money");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    if (CurrentPlayer.MyShip.GetCurrentWeigth() - CurrentPlayer.MyShip.ShieldGenerator.BaseWeigth + NewShieldGenerator.BaseWeigth >= CurrentPlayer.MyShip.Hull.MaxWeigth)
                                    {
                                        Console.WriteLine("Not Enougth Ship Weigth");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        CurrentPlayer.MyMoney += (int)(CurrentPlayer.MyShip.ShieldGenerator.Cost / 4);
                                        CurrentPlayer.MyShip.ShieldGenerator = NewShieldGenerator;
                                        CurrentPlayer.MyMoney -= NewShieldGenerator.Cost;
                                        ChoiceExitFlag = false;
                                        Console.WriteLine("Successful purchase");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    break;
                            }
                        }
                        break;
                    case "droid":
                        while (ChoiceExitFlag)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n\n\n--- My droid: --- \n" + CurrentPlayer.MyShip.Droid.Print());
                            Console.WriteLine("Ship Weigth: " + CurrentPlayer.MyShip.GetCurrentWeigth() + " / " + CurrentPlayer.MyShip.Hull.MaxWeigth);
                            Console.WriteLine("Money: " + CurrentPlayer.MyMoney + "$  + (Sell old for: )" + (int)(CurrentPlayer.MyShip.Droid.Cost / 4) + "$");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("\n\n ##### New My droid #####\n" + NewDroid.Print());
                            ChoiceResult = menu2.MenuToPrint();
                            switch (ChoiceResult)
                            {
                                case "Exit":
                                    ChoiceExitFlag = false;
                                    break;
                                case "Buy":
                                    if (CurrentPlayer.MyMoney + (int)(CurrentPlayer.MyShip.Droid.Cost / 4) - NewDroid.Cost < 0)
                                    {
                                        Console.WriteLine("Not Enougth Money");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    if (CurrentPlayer.MyShip.GetCurrentWeigth() - CurrentPlayer.MyShip.Droid.BaseWeigth + NewDroid.BaseWeigth >= CurrentPlayer.MyShip.Hull.MaxWeigth)
                                    {
                                        Console.WriteLine("Not Enougth Ship Weigth");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        CurrentPlayer.MyMoney += (int)(CurrentPlayer.MyShip.Droid.Cost / 4);
                                        CurrentPlayer.MyShip.Droid = NewDroid;
                                        CurrentPlayer.MyMoney -= NewDroid.Cost;
                                        ChoiceExitFlag = false;
                                        Console.WriteLine("Successful purchase");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    break;
                            }
                        }
                        break;
                    case "hull":
                        while (ChoiceExitFlag)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n\n\n--- My Hull: --- \n" + CurrentPlayer.MyShip.Hull.Print());
                            Console.WriteLine("Ship Weigth: " + CurrentPlayer.MyShip.GetCurrentWeigth() + " / " + CurrentPlayer.MyShip.Hull.MaxWeigth);
                            Console.WriteLine("Money: " + CurrentPlayer.MyMoney + "$  + (Sell old for: )" + (int)(CurrentPlayer.MyShip.Hull.Cost / 3) + "$");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("\n\n ##### New Hull ##### \n" + NewHull.Print());
                            ChoiceResult = menu2.MenuToPrint();
                            switch (ChoiceResult)
                            {
                                case "Exit":
                                    ChoiceExitFlag = false;
                                    break;
                                case "Buy":
                                    if (CurrentPlayer.MyMoney + (int)(CurrentPlayer.MyShip.Hull.Cost / 3) - NewHull.Cost < 0)
                                    {
                                        Console.WriteLine("Not Enougth Money");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    if (CurrentPlayer.MyShip.GetCurrentWeigth() >= NewHull.MaxWeigth)
                                    {
                                        Console.WriteLine("Not Enougth Ship Weigth");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        CurrentPlayer.MyMoney += (int)(CurrentPlayer.MyShip.Hull.Cost / 3);
                                        CurrentPlayer.MyShip.Hull = NewHull;
                                        CurrentPlayer.MyMoney -= NewHull.Cost;
                                        ChoiceExitFlag = false;
                                        Console.WriteLine("Successful purchase");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    break;
                            }
                        }
                        break;
                }
            }
        }

        public void MenuBuyWeapon(Player player)
        {
            string[] MainMenu = { "exit","weapon 1", "weapon 2",
                "weapon 3","weapon 4","weapon 5"};
            bool ExitFlag = true;
            string result;
            PrintMenu menu1 = new PrintMenu();
            string[] ShortList = new string[1 + player.MyShip.Hull.MaximumNumberOfWeapons];
            Array.Copy(MainMenu, ShortList, 1 + player.MyShip.Hull.MaximumNumberOfWeapons);
            menu1._menu = ShortList;


            while (ExitFlag)
            {
                for (int i = 0; i < player.MyShip.Weapons.Count; i++)
                {
                    Console.WriteLine("\n");
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n ----- select a weapon to change from your weapons ----- ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                PrintWeaponList(player.MyShip.Weapons);
                result = menu1.MenuToPrint();
                switch (result)
                {
                    case "exit":
                        ExitFlag = false;
                        break;

                    case "weapon 1":
                        PrintAvailableWeapon(player, 0);
                        break;
                    case "weapon 2":
                        PrintAvailableWeapon(player, 1);
                        break;
                    case "weapon 3":
                        PrintAvailableWeapon(player, 2);
                        break;
                    case "weapon 4":
                        PrintAvailableWeapon(player, 3);
                        break;
                    case "weapon 5":
                        PrintAvailableWeapon(player, 4);
                        break;

                }
            }
        }
        private void PrintWeaponList(List<Weapon> MyList)
        {
            int i = 1;
            foreach (Weapon weapon in MyList)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Weapon nr. {0}", i);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(weapon.Print() + "\n");
                i++;
            }
        }
        private bool CheckWeponLimits(Player player, Weapon NewWeapon, int WeaponNumber)
        {
            if (WeaponNumber == -1)
            {
                if (player.MyMoney - NewWeapon.Cost < 0)
                {
                    Console.WriteLine("Not Enougth Money");
                    Console.ReadKey();
                    Console.Clear();
                    return false;
                }
                if (player.MyShip.GetCurrentWeigth() + NewWeapon.BaseWeigth >= player.MyShip.Hull.MaxWeigth)
                {
                    Console.WriteLine("Not Enougth Ship Weigth");
                    Console.ReadKey();
                    Console.Clear();
                    return false;
                }
                return true;
            }
            else if (WeaponNumber >= 0 && WeaponNumber <= 4)
            {
                if (player.MyMoney + (int)(player.MyShip.Weapons[WeaponNumber].Cost / 4) - NewWeapon.Cost < 0)
                {
                    Console.WriteLine("Not Enougth Money");
                    Console.ReadKey();
                    Console.Clear();
                    return false;
                }
                if (player.MyShip.GetCurrentWeigth() - player.MyShip.Weapons[WeaponNumber].BaseWeigth + NewWeapon.BaseWeigth >= player.MyShip.Hull.MaxWeigth)
                {
                    Console.WriteLine("Not Enougth Ship Weigth");
                    Console.ReadKey();
                    Console.Clear();
                    return false;
                }
                return true;
            }
            else
            {
                throw new ArgumentException(String.Format("weapon number is {0}", WeaponNumber, this.ToString()), "MenuFunctions, CheckWeponLimits");
            }
        }
        private bool SwitchWeapon(Player CurrentPlayer, Weapon NewWeapon, int WeaponNumber)
        {
            string[] ChoiceMenu = { "Exit", "Buy" };
            string ChoiceResult;
            PrintMenu menu2 = new PrintMenu();
            menu2._menu = ChoiceMenu;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\n##### My Old Weapon: #####");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(CurrentPlayer.MyShip.Weapons[WeaponNumber].Print());
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Ship Weigth: " + CurrentPlayer.MyShip.GetCurrentWeigth() + " / " + CurrentPlayer.MyShip.Hull.MaxWeigth);
            Console.WriteLine("Money: " + CurrentPlayer.MyMoney + "$  + (Sell old for: )" + (int)(CurrentPlayer.MyShip.Weapons[WeaponNumber].Cost / 4) + "$");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\n##### New Weapon #####");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(NewWeapon.Print());
            ChoiceResult = menu2.MenuToPrint();
            switch (ChoiceResult)
            {
                case "Exit":
                    return false;
                case "Buy":
                    if (CheckWeponLimits(CurrentPlayer, NewWeapon, WeaponNumber))
                    {
                        CurrentPlayer.MyMoney += (int)(CurrentPlayer.MyShip.Weapons[WeaponNumber].Cost / 4);
                        CurrentPlayer.MyShip.Weapons[WeaponNumber] = NewWeapon;
                        CurrentPlayer.MyMoney -= NewWeapon.Cost;
                        Console.WriteLine("Successful purchase");
                        Console.ReadKey();
                        Console.Clear();
                        return true;
                    }
                    return false;
            }
            return false;


        }
        private bool BuyNewWeapon(Player CurrentPlayer, Weapon NewWeapon)
        {
            string[] ChoiceMenu = { "Exit", "Buy" };
            string ChoiceResult;
            PrintMenu menu2 = new PrintMenu();
            menu2._menu = ChoiceMenu;
            Console.Clear();
            Console.WriteLine("\n\n ##### New Weapon ##### \n" + NewWeapon.Print());
            ChoiceResult = menu2.MenuToPrint();
            switch (ChoiceResult)
            {
                case "Exit":
                    return false;
                case "Buy":
                    if (CheckWeponLimits(CurrentPlayer, NewWeapon, -1)) //-1 mean no Weapon
                    {
                        CurrentPlayer.MyShip.Weapons.Add(NewWeapon);
                        CurrentPlayer.MyMoney -= NewWeapon.Cost;
                        Console.WriteLine("Successful purchase");
                        Console.ReadKey();
                        Console.Clear();
                        return true;
                    }
                    return false;
            }
            return false;
        }
        private void PrintAvailableWeapon(Player player, int SelectedWeapon)
        {
            string[] SwitchWeaponMenu = { "exit", "refresh","weapon 1", "weapon 2",
                "weapon 3","weapon 4","weapon 5"};
            bool SwitchWeaponFlag = true;
            string SwitchWeaponResult;

            PrintMenu MenuSwitchWeapon = new PrintMenu();

            while (SwitchWeaponFlag)
            {

                List<Weapon> PlanetWeapon = new List<Weapon>();
                PlanetWeapon = player.Localization.WeaponList;

                string[] ShortSwitchWeaponMenu = new string[2 + PlanetWeapon.Count()];
                Array.Copy(SwitchWeaponMenu, ShortSwitchWeaponMenu, 2 + PlanetWeapon.Count());
                MenuSwitchWeapon._menu = ShortSwitchWeaponMenu;
                Console.WriteLine("\n          | Cost: " + Math.Pow(player.Localization.PlanetLvl, 2) * 100 + "$");

                for (int i = 2; i < 1 + PlanetWeapon.Count; i++)
                {
                    Console.WriteLine("\n");
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n##### select a new Weapon from shop #####");
                Console.ForegroundColor = ConsoleColor.Cyan;
                PrintWeaponList(PlanetWeapon);
                SwitchWeaponResult = MenuSwitchWeapon.MenuToPrint();
                //Console.ForegroundColor= ConsoleColor.DarkYellow;
                switch (SwitchWeaponResult)
                {
                    case "exit":
                        SwitchWeaponFlag = false;
                        break;
                    case "refresh":
                        if (player.MyMoney - (int)(Math.Pow(player.Localization.PlanetLvl, 2) * 100) < 0)
                        {
                            Console.WriteLine("Not Enougth Money");
                            Console.Clear();
                        }
                        else
                        {
                            player.MyMoney -= (int)(Math.Pow(player.Localization.PlanetLvl, 2) * 100);
                            player.Localization.GenerateNewWeapons(); //generate list of wenpon base on players localization
                            PlanetWeapon = player.Localization.WeaponList; //every planet have own weapon list
                            Console.WriteLine("Successful refresh");
                            Console.Clear();
                        }
                        break;
                    case "weapon 1":
                        if (SelectedWeapon + 1 > player.MyShip.Weapons.Count()) //+1 cause selectexWeapon is an index but Count return number of weapon(not intex of lastest weapon)
                        {
                            if (BuyNewWeapon(player, PlanetWeapon[0]))
                            {
                                PlanetWeapon.RemoveAt(0);
                                break;
                            }
                        }
                        else
                        {
                            if (SwitchWeapon(player, PlanetWeapon[0], SelectedWeapon))
                            {
                                PlanetWeapon.RemoveAt(0);
                                break;
                            }
                        }
                        break;
                    case "weapon 2":
                        if (SelectedWeapon + 1 > player.MyShip.Weapons.Count())
                        {
                            if (BuyNewWeapon(player, PlanetWeapon[1]))
                            {
                                PlanetWeapon.RemoveAt(1);
                                break;
                            }
                        }
                        else
                        {
                            if (SwitchWeapon(player, PlanetWeapon[1], SelectedWeapon))
                            {
                                PlanetWeapon.RemoveAt(1);
                                break;
                            }
                        }
                        break;
                    case "weapon 3":
                        if (SelectedWeapon + 1 > player.MyShip.Weapons.Count())
                        {
                            if (BuyNewWeapon(player, PlanetWeapon[2]))
                            {
                                PlanetWeapon.RemoveAt(2);
                                break;
                            }
                        }
                        else
                        {
                            if (SwitchWeapon(player, PlanetWeapon[2], SelectedWeapon))
                            {
                                PlanetWeapon.RemoveAt(2);
                                break;
                            }
                        }
                        break; ;
                    case "weapon 4":
                        if (SelectedWeapon + 1 > player.MyShip.Weapons.Count())
                        {
                            if (BuyNewWeapon(player, PlanetWeapon[3]))
                            {
                                PlanetWeapon.RemoveAt(3);
                                break;
                            }
                        }
                        else
                        {
                            if (SwitchWeapon(player, PlanetWeapon[3], SelectedWeapon))
                            {
                                PlanetWeapon.RemoveAt(3);
                                break;
                            }
                        }
                        break;
                    case "weapon 5":
                        if (SelectedWeapon + 1 > player.MyShip.Weapons.Count())
                        {
                            if (BuyNewWeapon(player, PlanetWeapon[4]))
                            {
                                PlanetWeapon.RemoveAt(4);
                                break;
                            }
                        }
                        else
                        {
                            if (SwitchWeapon(player, PlanetWeapon[4], SelectedWeapon))
                            {
                                PlanetWeapon.RemoveAt(4);
                                break;
                            }
                        }
                        break;

                }
            }

        }
        public void MenuFigth(Player player1)
        {
            RandomGenerator TempGenerator = new RandomGenerator();
            string ChoiceResult;
            bool ExitFlag = true;
            while (ExitFlag)
            {
                int i = 1;
                int TotalRocketCost = 0;
                string[] ChoiceMenu = { "Exit", "Repair all + rockets", "Figth enemy 1", "Figth enemy 2", "Figth enemy 3", "Figth enemy 4", "Figth enemy 5" };
                string[] ShortList = new string[2 + player1.Localization.EnemyPlayer.Count];
                Array.Copy(ChoiceMenu, ShortList, 2 + player1.Localization.EnemyPlayer.Count);
                PrintMenu menu2 = new PrintMenu();
                menu2._menu = ShortList;
                RocketLauncher tempRocket = new RocketLauncher(10, 30, 100, (float)0.9, 100, 30);
                foreach (Weapon weapons in player1.MyShip.Weapons)
                {
                    if (weapons.GetType() == tempRocket.GetType())
                    {
                        tempRocket = (RocketLauncher)weapons;
                        TotalRocketCost += tempRocket.BuyRocket(player1.Localization.RocketCost);
                    }

                }

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n                     Total cost: {0}$", player1.RepairAll());
                Console.WriteLine("\n\n\n\n\n");
                int MaxDamage =0;
                foreach (Weapon weapons in player1.MyShip.Weapons)
                {
                    MaxDamage += weapons.BaseAtack;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("My Ship: Max Damage: {0} \nHp: {1}/{2} | Shield: {3} | Droid Power: {4}\n", MaxDamage, player1.MyShip.Hull.Health,
                    player1.MyShip.Hull.MaxHealth, player1.MyShip.ShieldGenerator.Shield, player1.MyShip.Droid.RepairPower);
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (Player Enemy in player1.Localization.EnemyPlayer)
                {
                    Enemy.MyShip.Hull.Health = Enemy.MyShip.Hull.MaxHealth;
                    Enemy.MyShip.Engine.BaseHealth = 100;
                    Enemy.MyShip.FuelTank.BaseHealth = 100;
                    Enemy.MyShip.ShieldGenerator.BaseHealth = 100;
                    Enemy.MyShip.Droid.BaseHealth = 100;
                    foreach (Weapon weapons in Enemy.MyShip.Weapons)
                    {
                        weapons.BaseHealth = 100;
                    }
                    Console.WriteLine("##### Enemy Ship nr. {0} #####", i);
                    Console.WriteLine("Ship HP: " + Enemy.MyShip.Hull.Health + "/" + Enemy.MyShip.Hull.MaxHealth + " | " + "Droid: " + Enemy.MyShip.Droid.RepairPower
                        + " | " + "Shield Generator: " + Enemy.MyShip.ShieldGenerator.Shield + " | " + "Armour: " + Enemy.MyShip.Hull.Armor);
                    foreach (Weapon EnemyWeapon in Enemy.MyShip.Weapons)
                    {
                        Console.WriteLine(EnemyWeapon.PrintName() + " Atack: " + EnemyWeapon.BaseAtack);
                    }
                    i++;
                    Console.WriteLine("\n");
                }
                if (player1.MyShip.Hull.Health <=0)
                {
                    ExitFlag = false;
                    continue;
                }
                ChoiceResult = menu2.MenuToPrint();
                switch (ChoiceResult)
                {
                    case "Exit":
                        ExitFlag = false;
                        break;
                    case "Repair all + rockets":
                        if (player1.MyMoney - (player1.RepairAll() + TotalRocketCost) < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Not enougth money !!!");
                            Console.ReadKey();
                        }
                        else
                        {
                            player1.MyMoney -= player1.RepairAll();
                            player1.MyShip.Hull.Health = player1.MyShip.Hull.MaxHealth;
                            player1.MyShip.Engine.BaseHealth = 100;
                            player1.MyShip.FuelTank.BaseHealth = 100;
                            player1.MyShip.ShieldGenerator.BaseHealth = 100;
                            player1.MyShip.Droid.BaseHealth = 100;
                            foreach (Weapon weapons in player1.MyShip.Weapons)
                            {
                                weapons.BaseHealth = 100;
                            }
                            for (int ii = 0; ii < player1.MyShip.Weapons.Count; ii++)
                            {
                                if (player1.MyShip.Weapons[ii].GetType() == tempRocket.GetType())
                                {
                                    tempRocket = (RocketLauncher)player1.MyShip.Weapons[ii];
                                    tempRocket.MagazinSize = tempRocket.MaxMagazinSize;
                                    player1.MyShip.Weapons[ii] = tempRocket;
                                }
                            }
                        }
                        break;
                    case "Figth enemy 1":
                        Figth(player1, player1.Localization.EnemyPlayer[0]);
                        if(player1.Localization.EnemyPlayer[0].MyShip.Hull.Health <= 0)
                        {
                            player1.Localization.EnemyPlayer[0] = TempGenerator.GeneratePlayer(player1.Localization);
                        }
                        Console.ReadKey();
                        break;
                    case "Figth enemy 2":
                        Figth(player1, player1.Localization.EnemyPlayer[1]);
                        if (player1.Localization.EnemyPlayer[1].MyShip.Hull.Health <= 0)
                        {
                            player1.Localization.EnemyPlayer[1] = TempGenerator.GeneratePlayer(player1.Localization);
                        }
                        Console.ReadKey();
                        break;
                    case "Figth enemy 3":
                        Figth(player1, player1.Localization.EnemyPlayer[2]);
                        if (player1.Localization.EnemyPlayer[2].MyShip.Hull.Health <= 0)
                        {
                            player1.Localization.EnemyPlayer[2] = TempGenerator.GeneratePlayer(player1.Localization);
                        }
                        Console.ReadKey();
                        break;
                    case "Figth enemy 4":
                        Figth(player1, player1.Localization.EnemyPlayer[3]);
                        if (player1.Localization.EnemyPlayer[3].MyShip.Hull.Health <= 0)
                        {
                            player1.Localization.EnemyPlayer[3] = TempGenerator.GeneratePlayer(player1.Localization);
                        }
                        Console.ReadKey();
                        break;
                    case "Figth enemy 5":
                        Figth(player1, player1.Localization.EnemyPlayer[4]);
                        if (player1.Localization.EnemyPlayer[4].MyShip.Hull.Health <= 0)
                        {
                            player1.Localization.EnemyPlayer[4] = TempGenerator.GeneratePlayer(player1.Localization);
                        }
                        Console.ReadKey();
                        break;
                }
            }

        }
        private static void Figth(Player player1, Player player2)
        {
            string[] FigthMenu = { "Leave", "Figth", "skip" };
            string FigthResult;
            PrintMenu FigthPrintMenu = new PrintMenu();
            FigthPrintMenu._menu = FigthMenu;

            int round = 1;
            bool fightFlag = true;
            string results;
            while (fightFlag)
            {

                FigthResult = FigthPrintMenu.MenuToPrint();
                Console.WriteLine("\n\n");
                if (player2.MyShip.Hull.Health <= 0 || player1.MyShip.Hull.Health <= 0)
                {
                    fightFlag = false;
                }
                switch (FigthResult)
                {
                    case "Figth":
                        //faster ship start figth
                        Console.WriteLine(" ============ Round {0} ============ ", round);
                        if (player1.MyShip.Engine.Speed > player2.MyShip.Engine.Speed)
                        {
                            //results = player1.MyShip.UseWeapons(player2.MyShip);
                            results = CheckWin(player1, player2);
                            if (player2.MyShip.Hull.Health <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(results);
                                fightFlag = false;
                                continue;
                            }
                            else
                            {
                                PrintFigthResult(player1, player2, results);
                            }

                            results = CheckWin(player2, player1);
                            if (player1.MyShip.Hull.Health <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(results);
                                fightFlag = false;
                                continue;
                            }
                            else
                            {
                                PrintFigthResult(player2, player1, results);
                            }
                            round++;
                        }

                        else
                        {
                            results = CheckWin(player2, player1);
                            if (player2.MyShip.Hull.Health <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(results);
                                fightFlag = false;
                                continue;
                            }
                            else
                            {
                                PrintFigthResult(player2, player1, results);
                            }

                            results = CheckWin(player1, player2);
                            if (player2.MyShip.Hull.Health <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(results);
                                fightFlag = false;
                                continue;
                            }
                            else
                            {
                                PrintFigthResult(player1, player2, results);
                            }
                            round++;
                        }
                        break;
                    case "skip":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        while (player2.MyShip.Hull.Health > 0 && player1.MyShip.Hull.Health > 0)
                        {
                            if (player1.MyShip.Engine.Speed > player2.MyShip.Engine.Speed)
                            {

                                results = CheckWin(player1, player2);
                                if (player2.MyShip.Hull.Health <= 0)
                                {
                                    Console.WriteLine(results);
                                    continue;
                                }
                                else
                                    results = CheckWin(player2, player1);
                                if (player1.MyShip.Hull.Health <= 0)
                                {
                                    Console.WriteLine(results);
                                    continue;
                                }
                            }
                            else
                            {
                                results = CheckWin(player2, player1);
                                if (player1.MyShip.Hull.Health <= 0)
                                {
                                    Console.WriteLine(results);
                                    continue;
                                }
                                results = CheckWin(player1, player2);
                                if (player2.MyShip.Hull.Health <= 0)
                                {
                                    Console.WriteLine(results);
                                    continue;
                                }
                            }
                        }
                        //Console.ReadKey();
                        fightFlag = false;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case "Leave":
                        fightFlag = false;
                        break;
                }
            }
        }
        private static string CheckWin(Player faster, Player slower)
        {
            string TempString = faster.MyShip.UseWeapons(slower.MyShip);
            if (slower.MyShip.Hull.Health <= 0)
            {
                TempString = faster.Name + " win the figth !!!\nEarned " + slower.MyMoney + "$";
                faster.MyMoney += slower.MyMoney;
                faster.Score += slower.MyMoney;
                return TempString;

            }
            return TempString;
        }
        private static void PrintFigthResult(Player faster, Player slower, string result)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-----   " + faster.Name + "  -----\n" + result + " ( -" + slower.MyShip.Droid.RepairPower + " Droid)");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(slower.Name + " HP: " + slower.MyShip.Hull.Health + "/" + slower.MyShip.Hull.MaxHealth + "\n");
        }
        public void MenuTravel(Player player)
        {
            string[] AllMap = new string[20];
            AllMap[0] = "exit";
            bool ExitFlag = true;
            string result;
            int i = 1;
            foreach (string PlanetName in player.Localization.TravelMap.Keys)
            {
                AllMap[i] = PlanetName;
                i++;
            }

            PrintMenu menu1 = new PrintMenu();
            menu1._menu = AllMap;
            while (ExitFlag)
            {
                Console.Clear();
                result = menu1.MenuToPrint();
                if (result == "exit")
                {
                    ExitFlag = false;
                }
                else
                {
                    foreach (Planet planet in PlanetList)
                    {
                        if (planet.Name == result)
                        {
                            string temp = player.Travel(planet);
                            if (temp == "Successful travel")
                            {
                                Console.Clear();
                                Console.WriteLine(temp);
                                Console.ReadKey();
                                ExitFlag = false;
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(temp);
                                Console.ReadKey();
                            }

                        }
                    }
                }
            }
        }
        public void MenuUpgradeWeapon(Player player)
        {
            string[] MainMenu = { "exit","weapon 1", "weapon 2",
                "weapon 3","weapon 4","weapon 5"};
            bool ExitFlag = true;
            string result;
            PrintMenu menu1 = new PrintMenu();
            string[] ShortList = new string[1 + player.MyShip.Hull.MaximumNumberOfWeapons];
            Array.Copy(MainMenu, ShortList, 1 + player.MyShip.Hull.MaximumNumberOfWeapons);
            menu1._menu = ShortList;

            List<Weapon> TempList = new List<Weapon>();
            TempList = player.Localization.WeaponList;

            while (ExitFlag)
            {
                for (int i = 0; i < 1 + player.MyShip.Hull.MaximumNumberOfWeapons; i++)
                {
                    Console.WriteLine("\n");
                }
                Console.WriteLine("\n ----- My Weapons ----- ");
                PrintWeaponList(player.MyShip.Weapons);
                result = menu1.MenuToPrint();
                switch (result)
                {
                    case "exit":
                        ExitFlag = false;
                        break;
                    case "weapon 1":
                        UpgradeWeapon(player, 0);
                        break;
                    case "weapon 2":
                        UpgradeWeapon(player, 1);
                        break;
                    case "weapon 3":
                        UpgradeWeapon(player, 2);
                        break;
                    case "weapon 4":
                        UpgradeWeapon(player, 3);
                        break;
                    case "weapon 5":
                        UpgradeWeapon(player, 4);
                        break;

                }
            }
        }
        private void UpgradeWeapon(Player player, int weaponNumber)
        {
            if (player.MyShip.Weapons[weaponNumber].ToString() == "Projekt.WeakWeaponUpgrade" || player.MyShip.Weapons[weaponNumber].ToString() == "Projekt.HugeDamageUpgrade" ||
                player.MyShip.Weapons[weaponNumber].ToString() == "Projekt.DoubleShotDecorator" || player.MyShip.Weapons[weaponNumber].ToString() == "Projekt.ShieldDestroyer")
            {
                Console.WriteLine(player.MyShip.Weapons[weaponNumber].Print() + " !!! have alleady upgrade !!! ");
                Console.ReadKey();
                Console.Clear();
            }
            else if (player.MyShip.Weapons[weaponNumber].ToString() == "Projekt.RocketLauncher")
            {
                Console.WriteLine(player.MyShip.Weapons[weaponNumber].Print() + " !!! Can not upgrade Rocket laucher !!! ");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                string[] UpgradeMenu = { "exit","Huge Damage", "Damage",
                "Weigth","universal" , "Double shot" , "Shield Destroyer"};
                bool UpgradeMenuExitFlag = true;
                string UpgradeMenuResult;
                PrintMenu menu1 = new PrintMenu();

                string[] ChoiceMenu = { "Exit", "Buy upgrade" };
                string ChoiceResult;
                PrintMenu menu2 = new PrintMenu();
                menu2._menu = ChoiceMenu;


                menu1._menu = UpgradeMenu;
                while (UpgradeMenuExitFlag)
                {
                    Console.Clear();
                    UpgradeMenuResult = menu1.MenuToPrint();
                    switch (UpgradeMenuResult)
                    {
                        case "exit":
                            UpgradeMenuExitFlag = false;
                            break;
                        case "Shield Destroyer":
                            Console.Clear();
                            Console.WriteLine("\n\n\n Upgrade cost: " + (int)(player.MyShip.Weapons[weaponNumber].Cost * 2.5) + "$");
                            ChoiceResult = menu2.MenuToPrint();
                            switch (ChoiceResult)
                            {
                                case "Exit":
                                    break;
                                case "Buy upgrade":
                                    if (player.MyMoney - (int)(player.MyShip.Weapons[weaponNumber].Cost * 2.5) < 0)
                                    {
                                        Console.WriteLine("Not Enougth Money");
                                    }
                                    else
                                    {
                                        player.MyMoney -= (int)(player.MyShip.Weapons[weaponNumber].Cost * 2.5);
                                        player.MyShip.Weapons[weaponNumber] = new ShieldDestroyer(player.MyShip.Weapons[weaponNumber], player.MyShip.Weapons[weaponNumber].BaseAtack,
                                            player.MyShip.Weapons[weaponNumber].BaseWeigth, player.MyShip.Weapons[weaponNumber].BaseHealth, player.MyShip.Weapons[weaponNumber].BaseReliable
                                            , player.MyShip.Weapons[weaponNumber].Cost);
                                    }
                                    UpgradeMenuExitFlag = false;
                                    break;
                            }
                            break;
                        case "Double shot":
                            Console.Clear();
                            Console.WriteLine("\n\n\n Upgrade cost: " + (int)(player.MyShip.Weapons[weaponNumber].Cost * 2.00) + "$");
                            ChoiceResult = menu2.MenuToPrint();
                            switch (ChoiceResult)
                            {
                                case "Exit":
                                    break;
                                case "Buy upgrade":
                                    if (player.MyMoney - (int)(player.MyShip.Weapons[weaponNumber].Cost * 2.00) < 0)
                                    {
                                        Console.WriteLine("Not Enougth Money");
                                    }
                                    else
                                    {
                                        player.MyMoney -= (int)(player.MyShip.Weapons[weaponNumber].Cost * 2.00);
                                        player.MyShip.Weapons[weaponNumber] = new DoubleShotDecorator(player.MyShip.Weapons[weaponNumber], player.MyShip.Weapons[weaponNumber].BaseAtack,
                                            player.MyShip.Weapons[weaponNumber].BaseWeigth, player.MyShip.Weapons[weaponNumber].BaseHealth, player.MyShip.Weapons[weaponNumber].BaseReliable
                                            , player.MyShip.Weapons[weaponNumber].Cost);
                                    }
                                    UpgradeMenuExitFlag = false;
                                    break;
                            }
                            break;
                        case "Huge Damage":
                            Console.Clear();
                            Console.WriteLine("\n\n\n Upgrade cost: " + (int)(player.MyShip.Weapons[weaponNumber].Cost * 1.15) + "$");
                            ChoiceResult = menu2.MenuToPrint();
                            switch (ChoiceResult)
                            {
                                case "Exit":
                                    break;
                                case "Buy upgrade":
                                    if (player.MyMoney - (int)(player.MyShip.Weapons[weaponNumber].Cost * 1.15) < 0)
                                    {
                                        Console.WriteLine("Not Enougth Money");
                                    }
                                    else
                                    {
                                        player.MyMoney -= (int)(player.MyShip.Weapons[weaponNumber].Cost * 1.15);
                                        player.MyShip.Weapons[weaponNumber] = new HugeDamageUpgrade(player.MyShip.Weapons[weaponNumber], player.MyShip.Weapons[weaponNumber].BaseAtack,
                                            player.MyShip.Weapons[weaponNumber].BaseWeigth, player.MyShip.Weapons[weaponNumber].BaseHealth, player.MyShip.Weapons[weaponNumber].BaseReliable
                                            , player.MyShip.Weapons[weaponNumber].Cost);
                                    }
                                    UpgradeMenuExitFlag = false;
                                    break;
                            }
                            break;
                        case "Damage":
                            Console.Clear();
                            Console.WriteLine("\n\n\n Upgrade cost: " + (int)(player.MyShip.Weapons[weaponNumber].Cost * 0.5) + "$");
                            ChoiceResult = menu2.MenuToPrint();
                            switch (ChoiceResult)
                            {
                                case "Exit":
                                    break;
                                case "Buy upgrade":
                                    if (player.MyMoney - (int)(player.MyShip.Weapons[weaponNumber].Cost * 0.5) < 0)
                                    {
                                        Console.WriteLine("Not Enougth Money");
                                    }
                                    else
                                    {
                                        player.MyMoney -= (int)(player.MyShip.Weapons[weaponNumber].Cost * 0.5);
                                        player.MyShip.Weapons[weaponNumber] = new WeakWeaponUpgrade(player.MyShip.Weapons[weaponNumber], player.MyShip.Weapons[weaponNumber].BaseAtack,
                                             player.MyShip.Weapons[weaponNumber].BaseWeigth, player.MyShip.Weapons[weaponNumber].BaseHealth, player.MyShip.Weapons[weaponNumber].BaseReliable
                                             , player.MyShip.Weapons[weaponNumber].Cost, 1);
                                    }
                                    UpgradeMenuExitFlag = false;
                                    break;
                            }
                            break;
                        case "Weigth":
                            Console.Clear();
                            Console.WriteLine("\n\n\n Upgrade cost: " + (int)(player.MyShip.Weapons[weaponNumber].Cost * 0.5) + "$");
                            ChoiceResult = menu2.MenuToPrint();
                            switch (ChoiceResult)
                            {
                                case "Exit":
                                    break;
                                case "Buy upgrade":
                                    if (player.MyMoney - (int)(player.MyShip.Weapons[weaponNumber].Cost * 0.5) < 0)
                                    {
                                        Console.WriteLine("Not Enougth Money");
                                    }
                                    else
                                    {
                                        player.MyMoney -= (int)(player.MyShip.Weapons[weaponNumber].Cost * 0.5);
                                        player.MyShip.Weapons[weaponNumber] = new WeakWeaponUpgrade(player.MyShip.Weapons[weaponNumber], player.MyShip.Weapons[weaponNumber].BaseAtack,
                                             player.MyShip.Weapons[weaponNumber].BaseWeigth, player.MyShip.Weapons[weaponNumber].BaseHealth, player.MyShip.Weapons[weaponNumber].BaseReliable
                                             , player.MyShip.Weapons[weaponNumber].Cost, 2);
                                    }
                                    UpgradeMenuExitFlag = false;
                                    break;
                            }
                            break;
                        case "universal":
                            Console.Clear();
                            Console.WriteLine("\n\n\n Upgrade cost: " + (int)(player.MyShip.Weapons[weaponNumber].Cost * 0.5) + "$");
                            ChoiceResult = menu2.MenuToPrint();
                            switch (ChoiceResult)
                            {
                                case "Exit":
                                    break;
                                case "Buy upgrade":
                                    if (player.MyMoney - (int)(player.MyShip.Weapons[weaponNumber].Cost * 0.5) < 0)
                                    {
                                        Console.WriteLine("Not Enougth Money");
                                    }
                                    else
                                    {
                                        player.MyMoney -= (int)(player.MyShip.Weapons[weaponNumber].Cost * 0.5);
                                        player.MyShip.Weapons[weaponNumber] = new WeakWeaponUpgrade(player.MyShip.Weapons[weaponNumber], player.MyShip.Weapons[weaponNumber].BaseAtack,
                                             player.MyShip.Weapons[weaponNumber].BaseWeigth, player.MyShip.Weapons[weaponNumber].BaseHealth, player.MyShip.Weapons[weaponNumber].BaseReliable
                                                 , player.MyShip.Weapons[weaponNumber].Cost, 3);
                                    }
                                    UpgradeMenuExitFlag = false;
                                    break;
                            }
                            break;
                    }
                }
            }

        }
    }
}