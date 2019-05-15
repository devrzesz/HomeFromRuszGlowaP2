using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFromRuszGlowaPart2
{
    class Outside : Location
    {

        public Outside(bool hotOrNot, string name):base(name)
        {
            if (hotOrNot)
                hot = true;
            else
                hot = false;
        }

        private bool hot;

        public override string Desciption
        {
            get
            {
                string description = base.Desciption;
                if (hot)
                    return description += "Tu jest bardzo gorąco.";
                return description;
            }
        }
    }
}
