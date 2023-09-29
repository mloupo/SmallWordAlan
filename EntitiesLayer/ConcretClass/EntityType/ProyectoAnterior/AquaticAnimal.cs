using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrearAnimales.Helpers;
using CrearAnimales.Interfaces;

namespace CrearAnimales.Model.animalsType
{
    internal class AquaticAnimal : Animal , IAnimal
    {
        private IDiet _diet;

        public IDiet Diet
        {
            get { return _diet; }
            set { _diet = value; }
        }


        public AquaticAnimal(string especie, int age, int weight, IDiet diet) :
            base(especie, age, weight)
        {
            _diet = diet;
        }

        public AquaticAnimal()
        {
        }

        public void Feed(IFood food)
        {
            if (_diet.canEat(food))
            {       // Pruebas Piloto
                Console.WriteLine("La energia del animal antes de comer es: " + base._energy);
                Console.WriteLine("El animal esta comiendo " + food.getName());
                base.setEnergyPlus(food.getCalories());
                Console.WriteLine("La energia del animal despues de comer es: " + base._energy);
            }
            else
            {       // Pruebas Piloto
                Console.WriteLine("La energia del animal antes de comer es: " + base._energy);
                Console.WriteLine("El animal no puede comer " + food.getName());
                Console.WriteLine("El animal pierde 10 de energia por cazar en vano");
                base.setEnergyLess(10);
                Console.WriteLine("La energia del animal despues cazar en vano es: " + base._energy);
            }
        }

        public void Move()
        {       // Pruebas Piloto, moverse gasta 30 de energia, cazar un alimento que no puede comer gasta 10 de energia
            if (_energy >= 30)
            {
                Console.WriteLine("La posision del animal antes de moverse es: " + "X: " + base._positionX + "  Y: " + base._positionY);
                Console.WriteLine("La energia del animal antes de moverse es: " + base._energy);
                int min = NumberRandomGenerate.GenerateRandomNumber(0, 1000);
                int max = NumberRandomGenerate.GenerateRandomNumber(0, 1000);
                base.setPosition(min, max);
                base.setEnergyLess(30);
                Console.WriteLine("La posision del animal despues de moverse es: " + "X: " + base._positionX + "  Y: " + base._positionY);
                Console.WriteLine("La energia del animal despues de moverse es: " + base._energy);
            }
            else if (_energy < 30 && _energy >= 10)
            {
                Console.WriteLine("El animal notiene energia para moverse... nesecita cazar para alimentarce o dormir");
                Console.WriteLine("La energia del animal es de: " + _energy);
            }
            else
            {
                Console.WriteLine("El animal no tiene energia para moverse o cazar. Nesecita dormir ya o morira!!!");
            }
        }

        public void Sleep()
        {       // Pruebas piloto
            Console.WriteLine("La energia del animal antes de dormir es: " + base._energy);
            Console.WriteLine("El animal esta durmiendo");
            base.setEnergyPlus(50);
            Console.WriteLine("La energia del animal despues de dormir es: " + base._energy);
        }
        public override string ToString()
        {
            return base._especie +
                    base._age +
                    base._weight +
                    _diet.ToString();
        }
        public Type animalIs()
        {
            return this.GetType();
        }

        public IAnimal animalCreate()
        {
            return new AquaticAnimal();
        }
    }
}
