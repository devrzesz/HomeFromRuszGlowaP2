using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFromRuszGlowaPart2
{
    abstract class Location
    {
        public Location(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
        public Location[] Exits { get; set; }

        public virtual string Desciption
        {
            get
            {
                string descritpion = "Stoisz w: " + Name + ".\r\nWidzisz wyjscia do nastepujacych lokalizacji: ";
                foreach (var item in Exits)
                {
                    descritpion += $"{item.Name}, ";
                }
                return descritpion += "\r\n";
            }
        }
    }
}
