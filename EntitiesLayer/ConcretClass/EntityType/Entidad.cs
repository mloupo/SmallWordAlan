using System;
using CrearAnimales.EntitiesLayer.Interfaces;
using EntitiesLayer.Interfaces;

namespace CrearAnimales.EntitiesLayer.ConcretClass.EntityType
{
    public class Entidad : IEnergy
    {
        #region Attributes
        private static int _contadorId = 0;
        private int _id; // ID automatico a cada animal idependientemente de que tipo sean
        private string _name;
        private IDiet _diet;
        private IEnviroment _enviroment;
        private Ikingdom _kingdom;
        private int _energiaActual;
        private int _energyMax;
        private int _vidaMaxima;
        private int _vidaActual;
        private int _atkPoint;
        private int _defPoint;
        private int _rangeAtk;
        private string edadString;
        private string pesoString;

        #endregion

        #region Properties
        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public int EnergiaActual { get => _energiaActual; set => _energiaActual = value; }
        public int EnergyMax { get => _energyMax; set => _energyMax = value; }
        public int VidaMaxima { get => _vidaMaxima; set => _vidaMaxima = value; }
        public int VidaActual { get => _vidaActual; set => _vidaActual = value; }
        public int AtkPoint { get => _atkPoint; set => _atkPoint = value; }
        public int DefPoint { get => _defPoint; set => _defPoint = value; }
        public int RangeAtk { get => _rangeAtk; set => _rangeAtk = value; }
        public IDiet Diet { get => _diet; set => _diet = value; }
        public IEnviroment Enviroment { get => _enviroment; set => _enviroment = value; }
        public Ikingdom Kingdom { get => _kingdom; set => _kingdom = value; }
        #endregion

        #region Builders
        public Entidad() { }

        public Entidad(string name, IDiet diet, IEnviroment enviroment, Ikingdom kingdom, int energyMax, int lifeMax, int atk, int def, int rangoAtk)
        {
            _contadorId++;
            Id = _contadorId;
            Name = name;
            Diet = diet;
            Enviroment = enviroment;
            Kingdom = kingdom;
            EnergyMax = energyMax;
            EnergiaActual = EnergyMax;
            VidaMaxima = lifeMax;
            VidaActual = VidaMaxima;
            AtkPoint = atk;
            DefPoint = def;
            RangeAtk = rangoAtk;
        }

        #endregion
         
        #region IEnergyRegion
        /// <summary>
        /// Obtiene la energia actual de la entidad
        /// </summary>
        /// <returns></returns>
        public int GetEnergy()
        {
            return EnergiaActual;
        }
        /// <summary>
        /// Aumenta la energia de la entidad
        /// </summary>
        /// <param name="energy"></param>
        public void SetEnergyPlus(int energy)
        {
            EnergiaActual += energy;
            if (EnergiaActual >= EnergyMax)
            {
                EnergiaActual = EnergyMax;
            }
        }
        /// <summary>
        /// Disminuye la energia de la entidad
        /// </summary>
        /// <param name="energy"></param>
        public void SetEnergyLess(int energy)
        {
            EnergiaActual -= energy;
            if (EnergiaActual <= 0)
            {
                EnergiaActual = 0;
            }
        }
        #endregion

        #region OverideToString
        public override string ToString()
        {
            return "Nombre: " + Name + "\n" +
                    "Reino: " + Kingdom + "\n" +
                    "Energia: " + EnergiaActual + "\n" +
                    "Dieta: " + Diet + "\n" +
                    "Habitat: " + Enviroment + "\n" +
                    "Ataque: " + AtkPoint + "\n" +
                    "Defensa: " + DefPoint;
        }


        #endregion

        #region Move
        /// <summary>
        /// Devuelve True si la entidad puede moverce por el terreno y tiene a energia suficiente
        /// </summary>
        /// <param name="terrains"></param>
        public void MoveThrough(ITerrains terrains)
        {
            // Consideramos que moverse gasta 50 de energia
            if (EnergiaActual >= 50)
            {
                if (Enviroment.CanInhabit(terrains))
                {
                    Console.WriteLine("Puede moverce por aqui...");
                }
                else
                {
                    Console.WriteLine("No puede moverce por ese terreno");
                }
            }
            else
            {
                Console.WriteLine("Energia insuficioente para moverce");
            }
        }

        #endregion

        #region Attack
        /// <summary>
        /// Envia sus puntos de ataque y si recibe algo de vuelta es que la defenza de la victima era mas grande
        /// </summary>
        /// <param name="victima"></param>
        public void Atacar(Entidad victima)
        {   // Atacar consume 50 de energy
            if (EnergiaActual >= 50)
            { 
                SetEnergyLess(50);
                if (victima.SerAtacado(this.AtkPoint) > 0)
                {
                    Console.WriteLine("Ataque exitoso");
                }
                else
                {
                    VidaActual -= victima.SerAtacado(this.AtkPoint);
                }
            }
            else
            {
                Console.WriteLine("Energia insuficiente: " +  EnergiaActual);
            }
        }
        /// <summary>
        /// Devuleve 0 si el ataque fue exitoso y mayor a 0 si el atacante debe restarse vida 
        /// </summary>
        /// <param name="AtkPoints"></param>
        /// <returns>Int</returns>
        public int SerAtacado(int AtkPoints)
        {
            int points = 0; // Si devuelve 0 el ataque fue exitoso
            if (DefPoint > AtkPoints)
            {
                points = DefPoint - AtkPoints;
            }
            else
            {
                VidaActual += DefPoint - AtkPoints;
            }
            return points;
        }
        #endregion

        #region Feed
        /// <summary>
        /// Interactua con el alimento, suma energia o lo rechaza por su dieta
        /// </summary>
        /// <param name="comida"></param>
        public void Feed(IInteractuable comida)
        {
            if (Diet.canEat(comida))
            {
                comida.Interact(this);
            }
            else
            {
                Console.WriteLine("La dieta de la Entidad no le permite comer eso.");
            }
        }
        #endregion

        #region Rest
        /// <summary>
        /// Pierde el turno, Recupera 50 de energia y 100 de vida
        /// </summary>
        public void Rest()
        {
            EnergiaActual += 50;
            VidaActual += 100;

            // Proximo turno no juega... Ver ese tema...
        }
        #endregion

        #region Die
        /// <summary>
        /// Elimina la entidad del mapa
        /// </summary>
        public void Die()
        {
            VidaActual = 0;
            // Eliminarla del mapa
        }
        #endregion
    }

}

