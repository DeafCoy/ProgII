using PruebaParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaParcial.Datos
{
    internal class OrdenDao : IDaoOrdenRetiro
    {
        public bool Actualizar(OrdenRetiro orden)
        {
            throw new NotImplementedException();
        }

        public bool Borrar(int numero)
        {
            throw new NotImplementedException();
        }

        public bool Crear(OrdenRetiro orden)
        {
            return HelperDao.ObetenerInstancia().Confirmar(orden);
        }

        public List<Material> TraerMateriales()
        {
            return HelperDao.ObetenerInstancia().TraerMateriales();
        }
    }
}
