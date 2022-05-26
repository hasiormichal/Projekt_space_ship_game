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
            string[] MainMenu = {"exit","Buy Fuel", "Buy Rockets", "engine", "fuel tank", "Shield generator", "droid", "hull", "weapon 1", "weapon 2",
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
                RocketLauncher tempRocket = new RocketLauncher(10,30,100,(float)0.9,100,30);
                foreach (Weapon weapons in player.MyShip.Weapons)
                {
                    if(weapons.GetType() == tempRocket.GetType())
                    {
                        tempRocket = (RocketLauncher)weapons;
                        Console.WriteLine("Rockets: " + tempRocket.MagazinSize + "/" + tempRocket.MaxMagazinSize);
                        TotalRocketCost += tempRocket.BuyRocket(player.Localization.RocketCost);
                    }

                }
                
                result = menu1.MenuToPrint();
                switch (result)
                {
                    case "Buy Fuel":
                        if (player.MyMoney - player.MyShip.FuelTank.FuelRefile(player.Localization.FuelCost) < 0)
                        {
                            Console.WriteLine("Not enougth money");
                            break;
                        }
                        else
                        {
                            player.MyMoney -= player.MyShip.FuelTank.FuelRefile(player.Localization.FuelCost);
                            player.MyShip.FuelTank.Capacity = player.MyShip.FuelTank.MaxCapacity;
                            break;
                        }
                    case "Buy Rockets":
                        if (player.MyMoney < TotalRocketCost)
                        {
                            Console.WriteLine("Not enougth money");
                            break;
                        }
                        else
                        {
                           for(int i=0; i<player.MyShip.Weapons.Count; i++)
                            {
                                if (player.MyShip.Weapons[i].GetType() == tempRocket.GetType())
                                {
                                    tempRocket = (RocketLauncher)player.MyShip.Weapons[i];
                                    tempRocket.MagazinSize = tempRocket.MaxMagazinSize;
                                    player.MyShip.Weapons[i] = tempRocket;
                                }
                            }
                            player.MyMoney -= TotalRocketCost;
                            break;
                        }
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
                int TotalRepaiCost = player.MyShip.Hull.Repair() + player.MyShip.Engine.Repair() + player.MyShip.FuelTank.Repair() +
                     player.MyShip.ShieldGenerator.Repair() + player.MyShip.Droid.Repair();
                foreach (Weapon RepairWeapon in player.MyShip.Weapons)
                {
                    TotalRepaiCost += RepairWeapon.Repair();
                }
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
            string[] MainMenu = { "exit", "refresh",  "engine", "fuel tank", "Shield generator", "droid", "hull" };
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
                string[] ChoiceMenu = { "Buy", "Exit" };
                string ChoiceResult;
                bool ChoiceExitFlag = true;
                PrintMenu menu2 = new PrintMenu();
                menu2._menu = ChoiceMenu;
                result = menu1.MenuToPrint();
                switch (result)
                {
                    case "refresh":
                        while (ChoiceExitFlag)
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n\n Refresh Cost: " + Math.Pow(CurrentPlanet.PlanetLvl,2)*100 + "$");
                            ChoiceResult = menu2.MenuToPrint();
                            switch (ChoiceResult)
                            {
                                case "Exit":
                                    ChoiceExitFlag = false;
                                    break;
                                case "Buy":
                                    if (CurrentPlayer.MyMoney - (int)(Math.Pow(CurrentPlanet.PlanetLvl, 2) * 100) < 0)
                                    {
                                        Console.WriteLine("Not Enougth Money");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        CurrentPlayer.MyMoney -= (int)(Math.Pow(CurrentPlanet.PlanetLvl, 2) * 100);
                                        ChoiceExitFlag = false;
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
                            }
                        }
                        break;
                    case "exit":
                        ExitFlag = false;
                        break;
                    case "engine":
                        while (ChoiceExitFlag)
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n\n--- My Engine: --- \n" + CurrentPlayer.MyShip.Engine.Print());
                            Console.WriteLine("Ship Weigth: " + CurrentPlayer.MyShip.GetCurrentWeigth() + " / " + CurrentPlayer.MyShip.Hull.MaxWeigth);
                            Console.WriteLine("Money: " + CurrentPlayer.MyMoney +"$  + (Sell old for: )" + (int)(CurrentPlayer.MyShip.Engine.Cost / 4)+"$");
                            Console.WriteLine("\n\n ##### New Engine ##### \n" + NewEngine.Print());
                            ChoiceResult = menu2.MenuToPrint();
                            switch (ChoiceResult)
                            {
                                case "Exit":
                                    ChoiceExitFlag = false;
                                    break;
                                case "Buy":
                                    if (CurrentPlayer.MyMoney+ (int)(CurrentPlayer.MyShip.Engine.Cost / 4) - NewEngine.Cost < 0)
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
                            Console.WriteLine("\n\n\n--- My Fuel Tank: --- \n" + CurrentPlayer.MyShip.FuelTank.Print());
                            Console.WriteLine("Ship Weigth: " + CurrentPlayer.MyShip.GetCurrentWeigth() + " / " + CurrentPlayer.MyShip.Hull.MaxWeigth);
                            Console.WriteLine("Money: " + CurrentPlayer.MyMoney + "$  + (Sell old for: )" + (int)(CurrentPlayer.MyShip.FuelTank.Cost / 4) + "$");
                            Console.WriteLine("\n\n ##### New Fuel Tank #####\n" + NewFuelTank.Print());
                            ChoiceResult = menu2.MenuToPrint();
                            switch (ChoiceResult)
                            {
                                case "Exit":
                                    ChoiceExitFlag = false;
                                    break;
                                case "Buy":
                                    if (CurrentPlayer.MyMoney+ (int)(CurrentPlayer.MyShip.FuelTank.Cost / 4) - NewFuelTank.Cost < 0)
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
                            Console.WriteLine("\n\n\n--- My Shield generator: --- \n" + CurrentPlayer.MyShip.ShieldGenerator.Print());
                            Console.WriteLine("Ship Weigth: " + CurrentPlayer.MyShip.GetCurrentWeigth() + " / " + CurrentPlayer.MyShip.Hull.MaxWeigth);
                            Console.WriteLine("Money: " + CurrentPlayer.MyMoney + "$  + (Sell old for: )" + (int)(CurrentPlayer.MyShip.ShieldGenerator.Cost / 4) + "$");
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
                            Console.WriteLine("\n\n\n--- My droid: --- \n" + CurrentPlayer.MyShip.Droid.Print());
                            Console.WriteLine("Ship Weigth: " + CurrentPlayer.MyShip.GetCurrentWeigth() + " / " + CurrentPlayer.MyShip.Hull.MaxWeigth);
                            Console.WriteLine("Money: " + CurrentPlayer.MyMoney + "$  + (Sell old for: )" + (int)(CurrentPlayer.MyShip.Droid.Cost / 4) + "$");
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
                            Console.WriteLine("\n\n\n--- My Hull: --- \n" + CurrentPlayer.MyShip.Hull.Print());
                            Console.WriteLine("Ship Weigth: " + CurrentPlayer.MyShip.GetCurrentWeigth() + " / " + CurrentPlayer.MyShip.Hull.MaxWeigth);
                            Console.WriteLine("Money: " + CurrentPlayer.MyMoney + "$  + (Sell old for: )" + (int)(CurrentPlayer.MyShip.Hull.Cost / 3) + "$");
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
            string[] MainMenu = { "exit", "refresh","weapon 1", "weapon 2",
                "weapon 3","weapon 4","weapon 5"};
            bool ExitFlag = true;
            string result;
            PrintMenu menu1 = new PrintMenu();
            string[] ShortList = new string[2 + player.MyShip.Hull.MaximumNumberOfWeapons];
            Array.Copy(MainMenu, ShortList, 2 + player.MyShip.Hull.MaximumNumberOfWeapons);
            menu1._menu = ShortList;

            List<Weapon> TempList = new List<Weapon>();
            TempList = player.Localization.WeaponList;

            while (ExitFlag)
            {
                for (int i = 0; i < 2 + player.MyShip.Hull.MaximumNumberOfWeapons; i++)
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
                    case "refresh":
                        string[] ChoiceMenu = { "Buy", "Exit" };
                        string ChoiceResult;
                        bool ChoiceExitFlag = true;
                        PrintMenu menu2 = new PrintMenu();
                        menu2._menu = ChoiceMenu;
                        while (ChoiceExitFlag)
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n\n Refresh Cost: " + Math.Pow(player.Localization.PlanetLvl, 2) * 100 + "$");
                            ChoiceResult = menu2.MenuToPrint();
                            switch (ChoiceResult)
                            {
                                case "Exit":
                                    ChoiceExitFlag = false;
                                    break;
                                case "Buy":
                                    if (player.MyMoney - (int)(Math.Pow(player.Localization.PlanetLvl, 2) * 100) < 0)
                                    {
                                        Console.WriteLine("Not Enougth Money");
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        player.MyMoney -= (int)(Math.Pow(player.Localization.PlanetLvl, 2) * 100);
                                        ChoiceExitFlag = false;
                                        player.Localization.GenerateNewWeapons();
                                        TempList = player.Localization.WeaponList;
                                        Console.WriteLine("Successful refresh");
                                        Console.Clear();
                                    }
                                    break;
                            }
                        }
                        break;
                    case "weapon 1":
                        PrintAvailableWeapon(player, TempList, 0);
                        break;
                    case "weapon 2":
                        PrintAvailableWeapon(player, TempList, 1);
                        break;
                    case "weapon 3":
                        PrintAvailableWeapon(player, TempList, 2);
                        break;
                    case "weapon 4":
                        PrintAvailableWeapon(player, TempList, 3);
                        break;
                    case "weapon 5":
                        PrintAvailableWeapon(player, TempList, 4);
                        break;

                }
            }
        }
        private void PrintWeaponList(List<Weapon> MyList)
        {
            foreach (Weapon weapon in MyList)
            {
                Console.WriteLine(weapon.Print() + "\n");
            }
        }
        private bool CheckWeponLimits(Player player, Weapon NewWeapon, int WeaponNumber)
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
        private bool SwitchWeapon(Player CurrentPlayer, Weapon NewWeapon, int WeaponNumber)
        {
            string[] ChoiceMenu = { "Buy", "Exit" };
            string ChoiceResult;
            PrintMenu menu2 = new PrintMenu();
            menu2._menu = ChoiceMenu;

            Console.Clear();
            Console.WriteLine("\n\n\n--- My Old Weapon: --- \n" + CurrentPlayer.MyShip.Weapons[WeaponNumber].Print());
            Console.WriteLine("Ship Weigth: " + CurrentPlayer.MyShip.GetCurrentWeigth() + " / " + CurrentPlayer.MyShip.Hull.MaxWeigth);
            Console.WriteLine("Money: " + CurrentPlayer.MyMoney + "$  + (Sell old for: )" + (int)(CurrentPlayer.MyShip.Weapons[WeaponNumber].Cost / 4) + "$");
            Console.WriteLine("\n\n ##### New Weapon ##### \n" + NewWeapon.Print());
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
        private void PrintAvailableWeapon(Player player, List<Weapon> NewList, int SelectedWeapon)
        {
            string[] SwitchWeaponMenu = { "exit","weapon 1", "weapon 2",
                "weapon 3","weapon 4","weapon 5"};
            bool SwitchWeaponFlag = true;
            string SwitchWeaponResult;

            PrintMenu MenuSwitchWeapon = new PrintMenu();

            while (SwitchWeaponFlag)
            {
                string[] ShortSwitchWeaponMenu = new string[1 + NewList.Count()];
                Array.Copy(SwitchWeaponMenu, ShortSwitchWeaponMenu, 1 + NewList.Count());
                MenuSwitchWeapon._menu = ShortSwitchWeaponMenu;
                for (int i = 0; i < 1 + NewList.Count; i++)
                {
                    Console.WriteLine("\n");
                }
                Console.WriteLine("\n##### New Weapon#####");
                PrintWeaponList(NewList);
                SwitchWeaponResult = MenuSwitchWeapon.MenuToPrint();
                switch (SwitchWeaponResult)
                {
                    case "exit":
                        SwitchWeaponFlag = false;
                        break;
                    case "weapon 1":
                        if (SwitchWeapon(player, NewList[0], SelectedWeapon))
                        {
                            NewList.RemoveAt(0);
                            break;
                        }
                        break;
                    case "weapon 2":
                        if (SwitchWeapon(player, NewList[1], SelectedWeapon))
                        {
                            NewList.RemoveAt(1);
                            break;
                        }
                        break;
                    case "weapon 3":
                        if (SwitchWeapon(player, NewList[2], SelectedWeapon))
                        {
                            NewList.RemoveAt(2);
                            break;
                        }
                        break; ;
                    case "weapon 4":
                        if (SwitchWeapon(player, NewList[3], SelectedWeapon))
                        {
                            NewList.RemoveAt(3);
                            break;
                        }
                        break;
                    case "weapon 5":
                        if (SwitchWeapon(player, NewList[4], SelectedWeapon))
                        {
                            NewList.RemoveAt(4);
                            break;
                        }
                        break;

                }
            }

        }
        public void MenuFigth( Player player1 , Player Enemy)
        {
            string[] ChoiceMenu = { "Exit", "Figth" };
            string ChoiceResult;
            PrintMenu menu2 = new PrintMenu();
            menu2._menu = ChoiceMenu;

            Console.WriteLine("\n\n\n ##### Enemy Ship #####");
            Console.WriteLine("Ship HP: " + Enemy.MyShip.Hull.Health + "/" + Enemy.MyShip.Hull.MaxHealth);
            Console.WriteLine("Droid: " + Enemy.MyShip.Droid.RepairPower);
            Console.WriteLine("Shield Generator: " + Enemy.MyShip.ShieldGenerator.Shield);
            Console.WriteLine("Armour: " + Enemy.MyShip.Hull.Armor);
            foreach(Weapon EnemyWeapon in Enemy.MyShip.Weapons)
            {
                Console.WriteLine(EnemyWeapon.GetType() + " Atack: " + EnemyWeapon.BaseAtack);
            }
           ChoiceResult = menu2.MenuToPrint();
            switch (ChoiceResult)
            {
                case "Exit":
                    break;
                case "Figth":
                    Console.Clear();
                    Figth(player1, Enemy);
                    break;
            }
        }
        private static void Figth(Player player1, Player player2)
        {
            string[] FigthMenu = {"Figth", "Leave"};
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
                switch (FigthResult)
                {
                    case "Figth":
                        //faster ship start figth
                        Console.WriteLine(" ============ Round {0} ============ ", round);
                        if (player1.MyShip.Engine.Speed > player2.MyShip.Engine.Speed)
                        {
                            results = player1.MyShip.UseWeapons(player2.MyShip);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("-----   " + player1.Name + "  -----\n" + results + " - " + player1.MyShip.Droid.RepairPower + "(Droid)");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(player2.Name + " HP: " + player2.MyShip.Hull.Health + "/" + player2.MyShip.Hull.MaxHealth + "\n");
                            if (player2.MyShip.Hull.Health <= 0)
                            {
                                //ship 2 lost 
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(player1.Name + " win the figth !!!");
                                player1.MyMoney += player2.MyMoney;
                                fightFlag = false;
                                continue;
                            }

                            results = player2.MyShip.UseWeapons(player1.MyShip);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("-----  " + player2.Name + "  -----\n" + results + " - " + player2.MyShip.Droid.RepairPower + "(Droid)");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(player1.Name + " HP: " + player1.MyShip.Hull.Health + "/" + player1.MyShip.Hull.MaxHealth + "\n");
                            if (player1.MyShip.Hull.Health <= 0)
                            {
                                //ship 1 lost 
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(player2.Name + " win the figth !!!");
                                player2.MyMoney += player1.MyMoney;
                                fightFlag = false;
                                continue;
                            }
                            round++;
                        }
                        else
                        {
                            results = player2.MyShip.UseWeapons(player1.MyShip);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("-----  " + player2.Name + "  -----\n" + results + " - " + player2.MyShip.Droid.RepairPower + "(Droid)");
                            ; Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(player1.Name + " HP: " + player1.MyShip.Hull.Health + "/" + player1.MyShip.Hull.MaxHealth + "\n");
                            if (player1.MyShip.Hull.Health <= 0)
                            {
                                //ship 1 lost 
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(player2.Name + " win the figth !!!");
                                player2.MyMoney += player1.MyMoney;
                                fightFlag = false;
                                continue;
                            }

                            results = player1.MyShip.UseWeapons(player2.MyShip);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("-----  " + player1.Name + "  -----\n" + results + " - " + player1.MyShip.Droid.RepairPower + "(Droid)");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(player2.Name + " HP: " + player2.MyShip.Hull.Health + "/" + player2.MyShip.Hull.MaxHealth + "\n");
                            if (player2.MyShip.Hull.Health <= 0)
                            {
                                //ship 2 lost 
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(player1.Name + " win the figth !!!");
                                player1.MyMoney += player2.MyMoney;
                                fightFlag = false;
                                continue;
                            }
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            round++;
                        }
                        break;
                    case "Leave":
                        fightFlag = false;
                        break;
                }
            }
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
                            if(temp == "Successful travel")
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
            //TODO
        }
    }
}
