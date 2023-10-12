using PruebaParcial.Datos;
using PruebaParcial.Entidades;
using PruebaParcial.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaParcial
{
    public partial class FrmNuevaOrden : Form
    {
        OrdenRetiro nueva;
        IServicio gestor;
        public FrmNuevaOrden()
        {
            InitializeComponent();
            gestor = new Servicio();
            nueva = new OrdenRetiro();
        }

        private void FrmNuevaOrden_Load(object sender, EventArgs e)
        {
            DtpFecha.Value = DateTime.Today;
            TxtResponsable.Text = "Nuevo Responsable";
            NudCantidad.Value = 0;
            CargarMateriales();

        }

        private void CargarMateriales()
        {
            CboMateriales.DataSource = gestor.TraerMateriales();
            CboMateriales.ValueMember = "Codigo";
            CboMateriales.DisplayMember = "Nombre";
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            //validacion
            if (string.IsNullOrEmpty(TxtResponsable.Text))
            {
                MessageBox.Show("Debe agregar un responsable!", "Control"
                    , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if(NudCantidad.Value == 0)
            {
                MessageBox.Show("Debe seleccionar una cantidad valida!", "Control"
                    , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            foreach (DataGridViewRow row in DgvDetalles.Rows)
            {
                if (row.Cells["NomMateriales"].Value.ToString().Equals(CboMateriales.Text))
                {
                    MessageBox.Show("Ese material ya fue agregado!", "Control"
                    , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }

            //DataRowView item = (DataRowView)CboMateriales.SelectedItem;
            //int codigo = Convert.ToInt32(item.Row.ItemArray[0]);
            //string nombre = item.Row.ItemArray[1].ToString();
            //double stock = Convert.ToDouble(item.Row.ItemArray[2]);
            //Material m = new Material(codigo,nombre,stock);
            Material m = (Material)CboMateriales.SelectedItem;

            int cantidad = Convert.ToInt32(NudCantidad.Value);
            DetalleOrden detalle = new DetalleOrden(m,cantidad);
            nueva.AgregarDetalle(detalle);
            //DgvDetalles.Rows.Add(new object[] {detalle.Material.Codigo,
            //detalle.Material.Nombre,
            //detalle.Material.Stock,
            //detalle.Cantidad});
            DgvDetalles.Rows.Add(new object[] { m.Codigo, m.Nombre, m.Stock, cantidad, "Quitar" });
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void DgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvDetalles.CurrentCell.ColumnIndex == 4)
            {
                nueva.QuitarDetalle(DgvDetalles.CurrentRow.Index);
                DgvDetalles.Rows.RemoveAt(DgvDetalles.CurrentRow.Index);
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            //validacion
            if (string.IsNullOrEmpty(TxtResponsable.Text))
            {
                MessageBox.Show("Debe ingresar un Responsable..", "Control",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (DgvDetalles.Rows.Count==0) 
            {
                MessageBox.Show("Debe ingresar un detalle", "Control",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //grabar
            GrabarPresupuesto();
        }

        private void GrabarPresupuesto()
        {
            nueva.Fecha = DtpFecha.Value;
            nueva.Responsable = TxtResponsable.Text;
            if (gestor.CrearOrden(nueva))
            {
                MessageBox.Show("Se registro con exito la orden..", "Control"
                    , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("No se pudo registrar la orden!", "Control"
                    , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
