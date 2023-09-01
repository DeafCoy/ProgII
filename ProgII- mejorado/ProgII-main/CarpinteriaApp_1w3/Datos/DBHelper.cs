using CarpinteriaApp_1w3.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 

namespace CarpinteriaApp_1w3.Datos
{
    internal class DBHelper
    {
        private SqlConnection conexion;
        public DBHelper()
        {
            conexion = new SqlConnection(@"Data Source=172.16.10.196;Initial Catalog=Carpinteria_2023;User ID=alumno1w1;Password=alumno1w1");
        }
        public DataTable Cosultar1(string nombreSP,List<Parametro> lstParametros)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;
            foreach (Parametro p in lstParametros)
            {
                comando.Parameters.AddWithValue(p.Nombre, p.Valor);

            }
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;
        }
        public DataTable Cosultar(string nombreSP)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType= CommandType.StoredProcedure;
            comando.CommandText= nombreSP;
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;
        }
        public int ProximoPresupuesto()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_PROXIMO_ID";

            //configuro el parametro de salida del sp
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = "@next"; //nombre del parametro en sql server
            parametro.SqlDbType = SqlDbType.Int; //tipo del parametro 
            parametro.Direction = ParameterDirection.Output; //direccion del parametro
            //le mando el parametro al comando y lo ejecuto
            comando.Parameters.Add(parametro);
            comando.ExecuteNonQuery();

            conexion.Close();
            return (int)parametro.Value;
        }

        public bool ConfirmarPresupuesto(Presupuesto presupuesto)
        {
            bool resultado = true;// por que el metodo es bool
            SqlTransaction t = null;
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction(); // apenas abre la conexion empieza la transaccion
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.Transaction = t;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_INSERTAR_MAESTRO";
                //parametros de entrada
                comando.Parameters.AddWithValue("@cliente", presupuesto.Cliente);
                comando.Parameters.AddWithValue("@dto", presupuesto.Descuento);
                comando.Parameters.AddWithValue("@total", presupuesto.CalcularTotal());

                //configuro el parametro de salida del sp
                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = "@presupuesto_nro"; //nombre del parametro en sql server
                parametro.SqlDbType = SqlDbType.Int; //tipo del parametro 
                parametro.Direction = ParameterDirection.Output; //direccion del parametro
                                                                 //le mando el parametro al comando y lo ejecuto
                comando.Parameters.Add(parametro);
                comando.ExecuteNonQuery();

                int presupuestoNro = (int)parametro.Value;
                int detalleNro = 1;// el numero de detalle lo instanciamos nosotros
                SqlCommand cmdDetalle;

                foreach (DetallePresupuesto dp in presupuesto.Detalles) //la lista del presupuesto
                {
                    cmdDetalle = new SqlCommand("SP_INSETAR_DETALLE", conexion,t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@presupuesto_nro", presupuestoNro);
                    cmdDetalle.Parameters.AddWithValue("@detalle", detalleNro);
                    cmdDetalle.Parameters.AddWithValue("id_producto", dp.Producto.ProductoNro);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", dp.Cantidad);
                    cmdDetalle.ExecuteNonQuery();


                    detalleNro++;
                }
                t.Commit();
            }
            catch
            {
                t.Rollback();
                resultado = false;
            }
            finally//pase lo que pase
            {
                if(conexion!= null && conexion.State == ConnectionState.Open)
                conexion.Close();
            }

            return resultado;
        }
    }
    
}
