using EntitiesLayer.Interfaces;

namespace CrearAnimales.EntitiesLayer.Interfaces
{
    public interface IDiet
    {
        bool canEat(IInteractuable food);
    }
}
