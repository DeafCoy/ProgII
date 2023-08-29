using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCarreras.Entidades
{
    internal class Carrera
    {
        public int IdCarrera { get; set; }
        public string TituloCarrera { get; set; }
        public List<DetalleCarrera> Detalles { get; set; }

        public Carrera()
        {
            Detalles = new List<DetalleCarrera>();
        }

        public void AgregarDetalle(DetalleCarrera detalle)
        {
            Detalles.Add(detalle);
        }
        public void QuitarDetalles(int posicion)
        {
            Detalles.RemoveAt(posicion);
        }

        
    }
}
