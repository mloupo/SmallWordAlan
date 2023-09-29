using CrearAnimales.EntitiesLayer.ConcretClass.EntityType;
using CrearAnimales.EntitiesLayer.Interfaces;
using EntitiesLayer.ConcretClass.Feed.Food;
using EntitiesLayer.ConcretClass.KingType;
using EntitiesLayer.Interfaces;

namespace CrearAnimales.EntitiesLayer.ConcretClass.DietTypes
{
    public class Herbivoro : IDiet
    {
        public bool canEat(IInteractuable food) // Esta implementacion va a devolver true si el alimento que recibe por parametro es vegetal 
        {
            return food is Floors;
        }

        public override string ToString()
        {
            return "Hervivoro";
        }
    }
}
