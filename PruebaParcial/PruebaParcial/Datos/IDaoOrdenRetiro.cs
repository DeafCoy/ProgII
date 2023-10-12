using PruebaParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaParcial.Datos
{
    internal interface IDaoOrdenRetiro
    {
        bool Crear(OrdenRetiro orden);
        bool Actualizar(OrdenRetiro orden);
        bool Borrar(int numero);
        List<Material> TraerMateriales();
    }
}
