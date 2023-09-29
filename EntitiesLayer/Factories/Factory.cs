/*using EntitiesLayer.Interfaces;

namespace CrearAnimales.Model
{
    public abstract class Factory
    {
        public static IAnimal createAnimal(string especie, int edad, int peso, string tipoAnimal, string diet)
        {
            IAnimal animal = null;
            switch (tipoAnimal)
            {
                case "Air_GroundAnimal":
                    {
                        animal = new Air_GroundAnimal(especie,edad,peso,createDiet(diet));
                        break;
                    }
                case "AquaticAnimal":
                    {
                        animal = new AquaticAnimal(especie, edad, peso, createDiet(diet));
                        break;
                    }
                case "TerrestrialAnimal":
                    {
                        animal = new TerrestrialAnimal(especie, edad, peso, createDiet(diet));
                        break;
                    }
            }
            return animal;
        }

        public static IDiet createDiet(string tipoDieta)
        {
            IDiet dieta = null;
            switch (tipoDieta)
            {
                case "Carnivoro":
                    {
                        dieta = new Carnivoro();
                        break;
                    }
                case "Herbivoro":
                    {
                        dieta = new Herbivoro();
                        break;
                    }
                case "Omnivoro":
                    {
                        dieta = new Omnivoro();
                        break;
                    }
                case "Animal":
                    {
                        dieta = new Animal();
                        break;
                    }
                    
            }
            return dieta;
        }
    }
}*/
