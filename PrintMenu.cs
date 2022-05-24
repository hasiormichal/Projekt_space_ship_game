using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class PrintMenu
    {
        public string[] _menu;
        public string MenuToPrint()
        {
            var menu = new Menu(_menu);
            var menuPainter = new ConsoleMenuPainter(menu);

            bool done = false;

            do
            {
                menuPainter.Paint(0, 0);

                var keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow: menu.MoveUp(); break;
                    case ConsoleKey.DownArrow: menu.MoveDown(); break;
                    case ConsoleKey.Enter: done = true; break;
                }
            }
            while (!done);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.WriteLine("Selected option: " + (menu.SelectedOption ?? "(nothing)"));

            return menu.SelectedOption;
        }
    }
}
