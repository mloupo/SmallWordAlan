using CrearAnimales.EntitiesLayer.ConcretClass.EntityType;
using CrearAnimales.EntitiesLayer.Interfaces;
using EntitiesLayer.ConcretClass.Feed.Food;
using EntitiesLayer.ConcretClass.KingType;
using EntitiesLayer.Interfaces;

namespace CrearAnimales.EntitiesLayer.ConcretClass.DietTypes
{
    public class Omnivoro : IDiet
    {
        public bool canEat(IInteractuable food) // Esta implementacion va a devolver true si el alimento que recibe por parametro es vegetal o animal 
        {
            return food is Floors || food is Meat;
        }

        public override string ToString()
        {
            return "Omnivoro";
        }
    }
}
