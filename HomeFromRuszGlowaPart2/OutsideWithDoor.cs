using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFromRuszGlowaPart2
{
    class OutsideWithDoor : Outside, IHasExteriorDoor
    {
        public OutsideWithDoor(bool hotOrNot, string name, string door) : base(hotOrNot, name)
        {
            DoorDescription = door;
        }

        public string DoorDescription { get; }

        public override string Desciption => base.Desciption + "\r\nNo i są tu drzwi: " + DoorDescription + ".";

        public Location DoorLocation { get; set; }

    }
}
