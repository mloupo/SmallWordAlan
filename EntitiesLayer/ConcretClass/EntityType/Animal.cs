using System;
using System.ComponentModel.DataAnnotations;
using CrearAnimales.EntitiesLayer.Helpers;
using CrearAnimales.EntitiesLayer.Interfaces;

namespace CrearAnimales.EntitiesLayer.ConcretClass.EntityType
{
    public class Animal : IAnimal, IFood, IEnergy, IPositionable
    {
        #region Attributes
        private static int _contadorId = 0;
        private int _id; // ID automatico a cada animal idependientemente de que tipo sean
        private string _especie;
        private int _energy;
        private int _positionX;
        private int _positionY;
        private int _positionZ;
        private int _age;
        private int _weight;
        private IDiet _diet;
        private IEnviroment _enviroment;


        #endregion

        #region Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [Required(ErrorMessage = "El campo Especie es requerido")]
        [StringLength(20, ErrorMessage = "La especie debe tener como máximo 20 caracteres.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo Nombre solo permite letras")]
        public string Especie
        {
            get { return _especie; }
            set { _especie = value; }
        }

        [Required(ErrorMessage = "El campo Energía es requerido.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo Energía solo permite números del 0 al 9.")]
        [Range(0, 100, ErrorMessage = "La energía debe estar entre 0 y 100.")]
        public int Energy
        {
            get { return _energy; }
            set { _energy = value; }
        }

        [Required(ErrorMessage = "El campo Posición X es requerido.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo Posición X solo permite números del 0 al 9.")]
        [Range(0, 1000, ErrorMessage = "La posición X debe estar entre 0 y 1000.")]
        public int PositionX
        {
            get { return _positionX; }
            set { _positionX = value; }
        }

        [Required(ErrorMessage = "El campo Posición Y es requerido.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo Posición Y solo permite números del 0 al 9.")]
        [Range(0, 1000, ErrorMessage = "La posición Y debe estar entre 0 y 1000.")]
        public int PositionY
        {
            get { return _positionY; }
            set { _positionY = value; }
        }

        [Required(ErrorMessage = "El campo Posición Z es requerido.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo Posición Z solo permite números del 0 al 9.")]
        [Range(-100, 100, ErrorMessage = "La posición Z debe estar entre -100 y 100.")]
        public int PositionZ
        {
            get { return _positionZ; }
            set { _positionZ = value; }
        }

        [Required(ErrorMessage = "El campo Edad es requerido.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo Edad solo permite números del 0 al 9.")]
        [Range(0, 150, ErrorMessage = "La edad debe estar entre 0 y 150.")]
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        [Required(ErrorMessage = "El campo Peso es requerido.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo Peso solo permite números del 0 al 9.")]
        [Range(0, 9000, ErrorMessage = "El peso debe estar entre 0 y 9000.")]
        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        public IDiet Diet
        {
            get { return _diet; }
            set { _diet = value; }
        }

        public IEnviroment Enviroment
        {
            get { return _enviroment; }
            set { _enviroment = value; }
        }
        #endregion

        #region Builders
        public Animal() { }
        public Animal(string especie, int age, int weigth, IDiet diet, IEnviroment enviroment)
        {
            _contadorId++;
            Id = _contadorId;
            Especie = especie;
            Energy = 100;
            PositionX = 0;
            PositionY = 0;
            PositionZ = 0;
            Age = age;
            Weight = weigth;
            Diet = diet;
            Enviroment = enviroment;
        }
        #endregion

        #region IAnimalRegion

        public void Feed(IFood food)
        {
            if (!this.Equals(food)) // El animal NO puede comerce a si mismo...
            {
                if (Diet.canEat(food))
                {       // Pruebas Piloto
                    Console.WriteLine("La energia del animal " + Especie + " antes de comer es: " + Energy);
                    Console.WriteLine("El animal esta comiendo " + food.GetName());
                    SetEnergyPlus(food.getCalories());
                    Console.WriteLine("La energia del animal despues de comer es: " + Energy);
                }
                else
                {       // Pruebas Piloto
                    Console.WriteLine("La energia del animal antes de comer es: " + Energy);
                    Console.WriteLine("El animal no puede comer " + food.GetName());
                    Console.WriteLine("El animal pierde 10 de energia por cazar en vano");
                    SetEnergyLess(10);
                    Console.WriteLine("La energia del animal despues cazar en vano es: " + Energy);

                }
            }
            else 
            { 
                Console.WriteLine("El animal no puede comerce a si mismo"); 
            }
            
        }
        public void Move()
        {
            // Pruebas Piloto, moverse gasta 30 de energia, cazar un alimento que no puede comer gasta 10 de energia
            if (Energy >= 30)
            {
                Console.WriteLine("La posision del animal antes de moverse es: " + "X: " + PositionX + "  Y: " + PositionY);
                Console.WriteLine("La energia del animal antes de moverse es: " + Energy);
                setPositionX(NumberRandomGenerate.GenerateRandomNumber(0, 1000));
                setPositionY(NumberRandomGenerate.GenerateRandomNumber(0, 1000));
                SetEnergyLess(30);
                Console.WriteLine("La posision del animal despues de moverse es: " + "X: " + PositionX + "  Y: " + PositionY);
                Console.WriteLine("La energia del animal despues de moverse es: " + Energy);
            }
            else if (Energy < 30 && Energy >= 10)
            {
                Console.WriteLine("El animal notiene energia para moverse... nesecita cazar para alimentarce o dormir");
                Console.WriteLine("La energia del animal es de: " + Energy);
            }
            else
            {
                Console.WriteLine("El animal no tiene energia para moverse o cazar. Nesecita dormir ya o morira!!!");
            }
        }

        public void Sleep()
        {
            // Pruebas piloto
            Console.WriteLine("La energia del animal " + Especie + " antes de dormir es: " + Energy);
            Console.WriteLine("El animal esta durmiendo");
            SetEnergyPlus(50);
            Console.WriteLine("La energia del animal despues de dormir es: " + Energy);
        }
        #endregion

        #region IEnergyRegion
        public int GetEnergy()
        {
            return Energy;
        }

        public void SetEnergyPlus(int energy)
        {
            Energy += energy;
            if (Energy >= 100)
            {
                Energy = 100;
            }
        }

        public void SetEnergyLess(int energy)
        {
            Energy -= energy;
            if (Energy <= 0)
            {
                Energy = 0;
            }
        }
        #endregion

        #region IPositionableRegion
        public int getPositionX()
        {
            return PositionX;
        }

        public int getPositionY()
        {
            return PositionY;
        }

        public int getPositionZ()
        {
            return PositionZ;
        }

        public void setPositionX(int x)
        {
            PositionX = x;
        }

        public void setPositionY(int y)
        {
            PositionY = y;
        }

        public void setPositionZ(int z)
        {
            PositionZ = z;
        }
        #endregion

        #region IFoodRegion
        public string GetName()
        {
            return Especie;
        }
        IFood IFood.GetType()
        {
            return this;
        }

        public int getCalories()
        {
            return Energy;
        }
        #endregion

        #region OverideToString
        public override string ToString()
        {
            return  "Nombre: " + Especie + "\n" + 
                    "Energia: " + Energy + "\n" +
                    "Posicion: " + PositionX + " , " + PositionY + "\n" +
                    "Edad: " + Age + " Años" + "\n" + 
                    "Peso: " + Weight + " Kgs." + "\n" +
                    "Dieta: " + Diet + "\n" +
                    "Habitat: " + Enviroment;
        }


        #endregion

    }

}

