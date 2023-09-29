
namespace CrearAnimales.EntitiesLayer.Interfaces
{
    public interface IEnviroment
    {

        IEnviroment getType();

        bool CanInhabit(ITerrains terrain); // Puede habitar? 
    }
}
