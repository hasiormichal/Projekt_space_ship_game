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
            {"Saturn" , 10}
        };
        readonly public Dictionary<string, int> Saturn = new Dictionary<string, int>()
        {
            {"Ziemia" , 30},
            {"Mars" , 20},
            {"Jupiter" , 10}
        };
    }
}
