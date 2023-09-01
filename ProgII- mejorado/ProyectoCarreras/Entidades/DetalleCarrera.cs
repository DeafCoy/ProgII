using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCarreras.Entidades
{
    internal class DetalleCarrera
    {
        public Asignatura Asignatura { get; set; }
        public string AnioCurso { get; set; }
        public string Cuatrimestre { get; set; }
        public DetalleCarrera(Asignatura asignatura,string anioCurso,string cuatrimestre)
        {
           Asignatura = asignatura;
           AnioCurso = anioCurso;
           Cuatrimestre = cuatrimestre;
        }
    }
}
