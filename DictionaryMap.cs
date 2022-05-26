using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal class DictionaryMap
    {
        readonly public Dictionary<string, int> Ziemia = new Dictionary<string, int>()
        {
            {"Mars" , 10}
        };

        readonly public Dictionary<string, int> Mars = new Dictionary<string, int>()
        {
            {"Ziemia" , 10}
        };
    }
}
