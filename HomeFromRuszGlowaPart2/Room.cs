using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFromRuszGlowaPart2
{
    class Room : Location
    {
        private string decoration;

        public Room(string name, string decoration) : base(name)
        {
            this.decoration = decoration;
        }

        public override string Desciption
        {
            get
            {
                return base.Desciption + "Widzisz tutaj dekoracje: " + decoration + ".";
            }
        }
    }
}
