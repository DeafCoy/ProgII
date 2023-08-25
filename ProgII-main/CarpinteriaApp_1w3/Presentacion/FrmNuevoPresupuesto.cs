using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CarpinteriaApp_1w3.Entidades;

namespace CarpinteriaApp_1w3.Presentacion
{
    public partial class FrmNuevoPresupuesto : Form
    {
        Presupuesto nuevo = new Presupuesto();
        public FrmNuevoPresupuesto()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dgbDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgbDetalles.CurrentCell.ColumnIndex == 4) //es el boton quitar??
            {
                nuevo.QuitarDetalle(dgbDetalles.CurrentRow.Index);
                dgbDetalles.Rows.RemoveAt(dgbDetalles.CurrentRow.Index);
                CalcularTotales();
            }
            //if (e.ColumnIndex == 4) //es el boton quitar??
            //{
            //    nuevo.QuitarDetalle(e.RowIndex);
            //    dgbDetalles.Rows.RemoveAt(e.RowIndex);
            //    CalcularTotales();
            //}
        }

        private void FrmNuevoPresupuesto_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Today.ToString();
            txtCliente.Text = "Consumidor Final";
            txtDescuento.Text = "0";
            txtCantidad.Text = "1";
            ProximoPresupuesto();
            CargarProductos();
        }

        private void CargarProductos()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = @"Data Source=172.16.10.196;Initial Catalog=Carpinteria_2023;User ID=alumno1w1;Password=alumno1w1";
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_CONSULTAR_PRODUCTOS";
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());         
                    

            conexion.Close();
            cboProducto.DataSource = tabla;
            cboProducto.ValueMember = tabla.Columns[0].ColumnName;
            cboProducto.DisplayMember = tabla.Columns[1].ColumnName;

            //cboProducto.ValueMember = "id_producto";
            //cboProducto.DisplayMember = "n_producto"; 
            //son los nombres de las filas de sql

        }

        private void ProximoPresupuesto()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = @"Data Source=172.16.10.196;Initial Catalog=Carpinteria_2023;User ID=alumno1w1;Password=alumno1w1";
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
            lblPresupuestoNro.Text = lblPresupuestoNro.Text + "  " + parametro.Value.ToString(); //el parametro configurado antes
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //validacion!!
            if (cboProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un producto...",
                    "Control",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            if(string.IsNullOrEmpty(txtCantidad.Text)|| !int.TryParse(txtCantidad.Text,out _))//la segunda parte indica si no es numerico
            {
                MessageBox.Show("Debe ingresar una cantidad valida...",
                    "Control",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            foreach (DataGridViewRow fila in dgbDetalles.Rows) //controla que no este repetido, el foreach se hace sobre la grilla 
            {
                if (fila.Cells["ColProducto"].Value.ToString().Equals(cboProducto.Text))
                {
                    MessageBox.Show("Este producto ya esta presupuestado!...",
                   "Control",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Exclamation);
                    return;
                }
            }

            DataRowView item = (DataRowView)cboProducto.SelectedItem;//covierte el item del combo a datarowview
            int nro = Convert.ToInt32(item.Row.ItemArray[0]);//columna 0 el nro del producto
            string nom = item.Row.ItemArray[1].ToString();//nombre
            double pre = Convert.ToDouble(item.Row.ItemArray[2]);//precio
            //instancio un producto
            Producto p = new Producto(nro,nom,pre);//le paso los atributos por parametro
            int cant = Convert.ToInt32(txtCantidad.Text);
            //instancion un detalle
            DetallePresupuesto detalle = new DetallePresupuesto(p,cant);//tambien le paso los atributos por parametro

            nuevo.AgregarDetalle(detalle); //agrego el detalle al presupuesto
            dgbDetalles.Rows.Add(detalle.Producto.ProductoNro,
                detalle.Producto.Nombre,
                detalle.Producto.Precio,
                detalle.Cantidad,
                "Quitar");

            CalcularTotales();
            

        }

        private void CalcularTotales()
        {
            double total = nuevo.CalcularTotal();
            txtSubTotal.Text = total.ToString();
            double dto = total * Convert.ToDouble(txtDescuento.Text)/100;
            txtTotal.Text = (total - dto).ToString();

        }
    }
}
