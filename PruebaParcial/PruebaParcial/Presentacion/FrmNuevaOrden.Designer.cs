namespace PruebaParcial
{
    partial class FrmNuevaOrden
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblFecha = new System.Windows.Forms.Label();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.TxtResponsable = new System.Windows.Forms.TextBox();
            this.CboMateriales = new System.Windows.Forms.ComboBox();
            this.DgvDetalles = new System.Windows.Forms.DataGridView();
            this.ColID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomMateriales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAcciones = new System.Windows.Forms.DataGridViewButtonColumn();
            this.NudCantidad = new System.Windows.Forms.NumericUpDown();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.LblReponsable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // LblFecha
            // 
            this.LblFecha.AutoSize = true;
            this.LblFecha.Location = new System.Drawing.Point(32, 33);
            this.LblFecha.Name = "LblFecha";
            this.LblFecha.Size = new System.Drawing.Size(40, 13);
            this.LblFecha.TabIndex = 0;
            this.LblFecha.Text = "Fecha:";
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(453, 115);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(137, 23);
            this.BtnAgregar.TabIndex = 1;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // DtpFecha
            // 
            this.DtpFecha.Location = new System.Drawing.Point(110, 33);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(200, 20);
            this.DtpFecha.TabIndex = 2;
            // 
            // TxtResponsable
            // 
            this.TxtResponsable.Location = new System.Drawing.Point(110, 79);
            this.TxtResponsable.Name = "TxtResponsable";
            this.TxtResponsable.Size = new System.Drawing.Size(328, 20);
            this.TxtResponsable.TabIndex = 3;
            // 
            // CboMateriales
            // 
            this.CboMateriales.FormattingEnabled = true;
            this.CboMateriales.Location = new System.Drawing.Point(35, 114);
            this.CboMateriales.Name = "CboMateriales";
            this.CboMateriales.Size = new System.Drawing.Size(247, 21);
            this.CboMateriales.TabIndex = 4;
            // 
            // DgvDetalles
            // 
            this.DgvDetalles.AllowUserToAddRows = false;
            this.DgvDetalles.AllowUserToDeleteRows = false;
            this.DgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColID,
            this.NomMateriales,
            this.ColStock,
            this.ColCantidad,
            this.ColAcciones});
            this.DgvDetalles.Location = new System.Drawing.Point(35, 144);
            this.DgvDetalles.Name = "DgvDetalles";
            this.DgvDetalles.ReadOnly = true;
            this.DgvDetalles.Size = new System.Drawing.Size(555, 163);
            this.DgvDetalles.TabIndex = 5;
            this.DgvDetalles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDetalles_CellContentClick);
            // 
            // ColID
            // 
            this.ColID.HeaderText = "ID";
            this.ColID.Name = "ColID";
            this.ColID.ReadOnly = true;
            this.ColID.Visible = false;
            // 
            // NomMateriales
            // 
            this.NomMateriales.HeaderText = "MATERIALES";
            this.NomMateriales.Name = "NomMateriales";
            this.NomMateriales.ReadOnly = true;
            this.NomMateriales.Width = 200;
            // 
            // ColStock
            // 
            this.ColStock.HeaderText = "STOCK";
            this.ColStock.Name = "ColStock";
            this.ColStock.ReadOnly = true;
            // 
            // ColCantidad
            // 
            this.ColCantidad.HeaderText = "CANTIDAD";
            this.ColCantidad.Name = "ColCantidad";
            this.ColCantidad.ReadOnly = true;
            // 
            // ColAcciones
            // 
            this.ColAcciones.HeaderText = "Acciones";
            this.ColAcciones.Name = "ColAcciones";
            this.ColAcciones.ReadOnly = true;
            this.ColAcciones.Text = "Quitar";
            this.ColAcciones.UseColumnTextForButtonValue = true;
            this.ColAcciones.Width = 110;
            // 
            // NudCantidad
            // 
            this.NudCantidad.Location = new System.Drawing.Point(301, 115);
            this.NudCantidad.Name = "NudCantidad";
            this.NudCantidad.Size = new System.Drawing.Size(137, 20);
            this.NudCantidad.TabIndex = 6;
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Location = new System.Drawing.Point(198, 326);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(84, 23);
            this.BtnAceptar.TabIndex = 7;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(337, 326);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(84, 23);
            this.BtnCancelar.TabIndex = 8;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // LblReponsable
            // 
            this.LblReponsable.AutoSize = true;
            this.LblReponsable.Location = new System.Drawing.Point(32, 82);
            this.LblReponsable.Name = "LblReponsable";
            this.LblReponsable.Size = new System.Drawing.Size(72, 13);
            this.LblReponsable.TabIndex = 9;
            this.LblReponsable.Text = "Responsable:";
            // 
            // FrmNuevaOrden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 366);
            this.Controls.Add(this.LblReponsable);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.NudCantidad);
            this.Controls.Add(this.DgvDetalles);
            this.Controls.Add(this.CboMateriales);
            this.Controls.Add(this.TxtResponsable);
            this.Controls.Add(this.DtpFecha);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.LblFecha);
            this.Name = "FrmNuevaOrden";
            this.Text = "Registrar Orden Retiro";
            this.Load += new System.EventHandler(this.FrmNuevaOrden_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblFecha;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.TextBox TxtResponsable;
        private System.Windows.Forms.ComboBox CboMateriales;
        private System.Windows.Forms.DataGridView DgvDetalles;
        private System.Windows.Forms.NumericUpDown NudCantidad;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Label LblReponsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomMateriales;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCantidad;
        private System.Windows.Forms.DataGridViewButtonColumn ColAcciones;
    }
}

