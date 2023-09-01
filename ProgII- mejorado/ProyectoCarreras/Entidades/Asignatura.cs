using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCarreras.Entidades
{
    internal class Asignatura
    {

        public int AsignaturaNro { get; set; }
        public string Nombre { get; set; }
     

        public Asignatura()
        {
            AsignaturaNro = 0;
            Nombre = string.Empty;
        }
        public Asignatura(int asignaturanro, string nombre, double precio)
        {
            AsignaturaNro= asignaturanro;
            Nombre = nombre;
            
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
