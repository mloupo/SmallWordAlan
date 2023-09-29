using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrearAnimales.Model.foodType
{
    internal abstract class FoodMaster // Clase creada para asignarle un ID a cada alimento
    {
        private static int _contadorId = 0;
        private int _id;
        public FoodMaster()
        {
            _contadorId++;
            _id = _contadorId;
        }

    }
}
