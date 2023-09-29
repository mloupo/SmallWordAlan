using System.Collections.Generic;
using CrearAnimales.EntitiesLayer.ConcretClass.Atmosphere.Enviroment;
using CrearAnimales.EntitiesLayer.ConcretClass.DietTypes;
using CrearAnimales.EntitiesLayer.ConcretClass.EntityType;

namespace CrearAnimales.DataAccesLayer
{
    public class AnimalStore
    {
        //private List<Entidad> animals = new List<Entidad>();
        private List<Entidad> animals = new List<Entidad> // Harcodeada para pruebas
        {

        };
        private static AnimalStore instance;

        private AnimalStore() { }

        public static AnimalStore GetInstance()
        {
            if (instance == null)
            {
                instance = new AnimalStore();
            }
            return instance;
        }

        public void AddAnimal(Entidad animal)
        {
            animals.Add(animal);
        }

        public List<Entidad> GetAllAnimals()
        {
            // Retornar una copia de la lista para evitar modificaciones externas
            return animals;
        }

        public Entidad AlterAnimal(Entidad animal)
        {
            // Realizar las operaciones necesarias para alterar el animal
            if (animals.Contains(animal))
            {
                int index = animals.IndexOf(animal); // Obtener el índice del animal en la lista
                animals[index] = animal; // Reemplazar el objeto existente con el objeto modificado
            }
            return animal;
        }


        public void DeleteAnimal(Entidad animal)
        {
            if (animals.Contains(animal))
            {
                animals.Remove(animal);
            }
        }
    }
}
