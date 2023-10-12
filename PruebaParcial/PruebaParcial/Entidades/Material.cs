using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaParcial.Entidades
{
    public class Material
    {
        public int Codigo {  get; set; }
        public string Nombre { get; set; }
        public double Stock { get; set; }
        public Material()
        {
            Codigo = 0;
            Nombre = string.Empty;
            Stock = 0;
        }
        public Material(int codigo, string nombre, double stock)
        {
            Codigo = codigo;
            Nombre = nombre;
            Stock = stock;
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
