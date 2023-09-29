using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer.Interfaces;

namespace EntitiesLayer.ConcretClass.KingType
{
    public class Vegetal : Ikingdom
    {
        string Ikingdom.GetType()
        {
            return GetType().Name;
        }

        public override string ToString()
        {
            return "Vegetal";
        }
    }
}
