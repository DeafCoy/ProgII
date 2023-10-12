using PruebaParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaParcial.Servicios
{
    internal interface IServicio
    {
        List<Material> TraerMateriales();
        bool CrearOrden(OrdenRetiro orden);
    }
}
