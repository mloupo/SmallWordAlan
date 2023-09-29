using CrearAnimales.EntitiesLayer.ConcretClass.Atmosphere.Terrains;
using CrearAnimales.EntitiesLayer.Interfaces;

namespace CrearAnimales.EntitiesLayer.ConcretClass.Atmosphere.Enviroment
{
    public class Underground : IEnviroment
    {

        private int id;
        private string _name;

        public int Id { get => id; set => id = value; }
        public string Name { get => _name; set => _name = value; }
        public bool CanInhabit(ITerrains terrain)
        {
            return terrain is Land;
        }

        public IEnviroment getType()
        {
            return this;
        }
        public override string ToString()
        {
            return "Subterraneo";
        }
    }
    
}
