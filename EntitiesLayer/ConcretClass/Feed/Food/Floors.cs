using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrearAnimales.EntitiesLayer.ConcretClass.EntityType;
using CrearAnimales.EntitiesLayer.Interfaces;
using EntitiesLayer.Interfaces;

namespace EntitiesLayer.ConcretClass.Feed.Food
{
    public class Floors : IInteractuable
    {
        private string _name;
        private int _calories;

        public string Name { get => _name; set => _name = value; }
        public int Calories { get => _calories; set => _calories = value; }

        public Floors(string name, int calories)
        {
            Name = name;
            Calories = calories;
        }

        public void Interact(Entidad entidad)
        {
            entidad.SetEnergyPlus(Calories);
        }
    }
}
