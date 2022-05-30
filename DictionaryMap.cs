using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class DictionaryMap
    {
        readonly public Dictionary<string, int> Earth = new Dictionary<string, int>()
        {
            {"Mars" , 10},
            {"Jupiter" , 20},
            {"Saturn" , 30}
        };

        readonly public Dictionary<string, int> Mars = new Dictionary<string, int>()
        {
            {"Ziemia" , 10},
            {"Jupiter" , 10},
            {"Saturn" , 20}
        };
        readonly public Dictionary<string, int> Jupiter = new Dictionary<string, int>()
        {
            {"Ziemia" , 20},
            {"Mars" , 10},
            {"Saturn" , 10},
            {"Alfa3825", 15 }
        };
        readonly public Dictionary<string, int> Saturn = new Dictionary<string, int>()
        {
            {"Ziemia" , 30},
            {"Mars" , 20},
            {"Jupiter" , 10},
            { "Alfa3825" , 15}
        };
        readonly public Dictionary<string, int> Alfa3825 = new Dictionary<string, int>()
        {
            {"Saturn" , 15},
            {"Jupiter" , 15},
            {"Pandora" , 20},
            {"Celestia",40 }
        };
        readonly public Dictionary<string, int> Pandora = new Dictionary<string, int>()
        {
            {"Alfa3825" ,20 },
            {"Celestia" , 30},
            {"Orion47" , 40}
        };
        readonly public Dictionary<string, int> Celestia = new Dictionary<string, int>()
        {
            {"Pandora" , 30},
            {"Alfa3825" , 40},
            {"Orion47" , 15},
            {"Envito",25 }
        };
        readonly public Dictionary<string, int> Orion47 = new Dictionary<string, int>()
        {
            {"Celestia" , 15},
            {"Pandora" , 40},
            {"Envito" , 20},
            {"LastPlanet",50 }
        };
        readonly public Dictionary<string, int> Envito = new Dictionary<string, int>()
        {
            {"Celestia" ,25},
            {"Orion47" , 20},
            {"LastPlanet",25 }
        };
        readonly public Dictionary<string, int> LastPlanet = new Dictionary<string, int>()
        {
            {"Envito" , 25},
            {"Orion47" , 50}
        };
    }
}
