using CrearAnimales.EntitiesLayer.ConcretClass.Atmosphere.Enviroment.Terrains;
using CrearAnimales.EntitiesLayer.Interfaces;


namespace CrearAnimales.EntitiesLayer.ConcretClass.Atmosphere.Enviroment
{
    public class Ocean : IEnviroment
    {
        private int id;
        private string _name;

        public int Id { get => id; set => id = value; }
        public string Name { get => _name; set => _name = value; }

        public bool CanInhabit(ITerrains terrain)
        {
            return terrain is Water;
        }

        public IEnviroment getType()
        {
            return this;
        }
        public override string ToString()
        {
            return "Oceano";
        }
    }
}
