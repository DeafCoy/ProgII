using CarpinteriaApp_1w3.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarpinteriaApp_1w3.Presentacion
{
    public partial class FrmConsultarPresupuesto : Form
    {
        DBHelper gestor;
        public FrmConsultarPresupuesto()
        {
            gestor= new DBHelper();
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmConsultarPresupuesto_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now.AddDays(-7);
            dtpHasta.Value = DateTime.Now;

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //validar datos de entrada 
            List<Parametro> lista = new List<Parametro>();
            lista.Add(new Parametro("@fecha_desde", dtpDesde.Value.ToString("yyy/MM/dd")));
            lista.Add(new Parametro("@fecha_hasta", dtpHasta.Value.ToString("yyy/MM/dd")));
            lista.Add(new Parametro("@cliente", txtCliente.Text));
            DataTable tabla = new DBHelper().Cosultar1("SP_CONSULTAR_PRESUPUESTO", lista);
            dgvPresupuesto.Rows.Clear();//limpiamos las filas
            foreach (DataRow fila in tabla.Rows)
            {
                dgvPresupuesto.Rows.Add(new object[]
                {
                    fila["presupuesto_nro"].ToString(),
                    fila["fecha"].ToString(),
                    fila["cliente"].ToString(),
                    fila["total"].ToString()
                });
            }
        }
    }
}
