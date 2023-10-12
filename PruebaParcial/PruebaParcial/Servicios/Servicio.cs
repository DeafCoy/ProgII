using PruebaParcial.Datos;
using PruebaParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaParcial.Servicios
{
    internal class Servicio : IServicio
    {
        private IDaoOrdenRetiro dao;
        public Servicio()
        {
            dao = new OrdenDao();
        }
        public bool CrearOrden(OrdenRetiro orden)
        {
            return dao.Crear(orden);
        }

        public List<Material> TraerMateriales()
        {
            return dao.TraerMateriales();
        }
    }
}
