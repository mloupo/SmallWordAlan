using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrearAnimales.EntitiesLayer.ConcretClass.EntityType;

namespace EntitiesLayer.Interfaces
{
    public interface IInteractuable
    {
        void Interact(Entidad entidad);
    }
}
