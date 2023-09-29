using CrearAnimales.EntitiesLayer.Interfaces;


namespace CrearAnimales.EntitiesLayer.ConcretClass.EntityType
{
    public class Vegetable : IFood
    {
        private int _calories;
        private string _name;

        public int Calories { get => _calories; set => _calories = value; }
        public string Name { get => _name; set => _name = value; }
        public Vegetable(string name, int calorias)
        {
            Name = name;
            Calories = calorias;
        }

        public int getCalories()
        {
            return Calories;
        }

        public string GetName()
        {
            return Name;
        }

        IFood IFood.GetType()
        {
            return this;
        }
    }
}
