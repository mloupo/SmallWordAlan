namespace CrearAnimales.EntitiesLayer.Interfaces
{
    public interface IAnimal
    {
        void Feed(IFood food);
        void Move();
        void Sleep();
        
    }
}
