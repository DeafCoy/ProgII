using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using PruebaParcial.Entidades;

namespace PruebaParcial.Datos
{
    public class HelperDao
    {
        private static HelperDao Instance;
        public SqlConnection Connection;
        public HelperDao() 
        {
            Instance = null;
            Connection = new SqlConnection(@"Data Source=DESKTOP-MGDK5OM;Initial Catalog=db_ordenes;Integrated Security=True");
        }
        public static HelperDao ObetenerInstancia()
        {
            if(Instance == null)
            {
                Instance= new HelperDao();
            }
            return Instance;
        }

        public List<Material> TraerMateriales()
        {
            DataTable table = new DataTable();
            Connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_CONSULTAR_MATERIALES";
            table.Load(cmd.ExecuteReader());
            

            Connection.Close();
            List<Material> materials = new List<Material>();
            foreach (DataRow row in table.Rows)
            {
                int codigo = int.Parse(row["codigo"].ToString());
                string nombre = row["nombre"].ToString();
                double stock = double.Parse(row["stock"].ToString());
                Material m = new Material(codigo,nombre,stock);
                materials.Add(m);

            }

            return materials;
        }
        public bool Confirmar(OrdenRetiro orden)
        {
            bool resultado = true;
            SqlTransaction t = null;
            try
            {
                Connection.Open();
                t = Connection.BeginTransaction();
                SqlCommand comando = new SqlCommand();
                comando.Connection = Connection;
                comando.Transaction = t;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "SP_INSERTAR_ORDEN";
                //parametro entrada
                comando.Parameters.AddWithValue("@responsable",orden.Responsable);

                //parametro salida
                SqlParameter salida = new SqlParameter();
                salida.ParameterName = "@nro";
                salida.SqlDbType = SqlDbType.Int;
                salida.Direction = ParameterDirection.Output;
                comando.Parameters.Add(salida);

                comando.ExecuteNonQuery();

                int nroOrden = (int)salida.Value;
                int nroDetalle = 1;
                SqlCommand cmdDetalle;

                //insert detalles
                foreach(DetalleOrden det in orden.Detalles)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLES", Connection, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@nro_orden", nroOrden);
                    cmdDetalle.Parameters.AddWithValue("@detalle", nroDetalle);
                    cmdDetalle.Parameters.AddWithValue("@codigo", det.Material.Codigo);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", det.Cantidad);
                    cmdDetalle.ExecuteNonQuery();
                    nroDetalle++;
                }
                t.Commit();
            }
            catch
            {
                if(t!=null)
                    t.Rollback();
                resultado = false;
            }
            finally
            {
                if(Connection != null && Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
            return resultado;
        }
    }
}
