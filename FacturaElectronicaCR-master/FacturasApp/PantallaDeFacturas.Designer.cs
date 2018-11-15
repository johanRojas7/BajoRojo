namespace FacturasApp
{
    partial class PantallaDeFacturas
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
            this.comboBoxEmbarcacionpLiquidacion = new System.Windows.Forms.ComboBox();
            this.botonBuscarLiquidacion = new System.Windows.Forms.Button();
            this.dt = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Embarcacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ii = new System.Windows.Forms.DataGridViewButtonColumn();
            this.datos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datos)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxEmbarcacionpLiquidacion
            // 
            this.comboBoxEmbarcacionpLiquidacion.FormattingEnabled = true;
            this.comboBoxEmbarcacionpLiquidacion.Items.AddRange(new object[] {
            "Don Emi",
            "Gemelo",
            "Santa Cruz",
            "Punta Blanca N",
            "La Tania",
            "Uzziel",
            "Dasnet",
            "Wilbert Jose",
            "Don Pedro",
            "Lady Liz"});
            this.comboBoxEmbarcacionpLiquidacion.Location = new System.Drawing.Point(12, 31);
            this.comboBoxEmbarcacionpLiquidacion.Name = "comboBoxEmbarcacionpLiquidacion";
            this.comboBoxEmbarcacionpLiquidacion.Size = new System.Drawing.Size(173, 21);
            this.comboBoxEmbarcacionpLiquidacion.TabIndex = 19;
            // 
            // botonBuscarLiquidacion
            // 
            this.botonBuscarLiquidacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.botonBuscarLiquidacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonBuscarLiquidacion.ForeColor = System.Drawing.Color.White;
            this.botonBuscarLiquidacion.Location = new System.Drawing.Point(191, 25);
            this.botonBuscarLiquidacion.Name = "botonBuscarLiquidacion";
            this.botonBuscarLiquidacion.Size = new System.Drawing.Size(117, 27);
            this.botonBuscarLiquidacion.TabIndex = 20;
            this.botonBuscarLiquidacion.Text = "Buscar";
            this.botonBuscarLiquidacion.UseVisualStyleBackColor = true;
            this.botonBuscarLiquidacion.Click += new System.EventHandler(this.botonBuscarLiquidacion_Click);
            // 
            // dt
            // 
            this.dt.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(211)))), ((int)(((byte)(255)))));
            this.dt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dt.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dt.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Fecha,
            this.Embarcacion,
            this.ii});
            this.dt.Location = new System.Drawing.Point(12, 70);
            this.dt.Name = "dt";
            this.dt.Size = new System.Drawing.Size(567, 292);
            this.dt.TabIndex = 21;
            this.dt.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_CellClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 60;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 150;
            // 
            // Embarcacion
            // 
            this.Embarcacion.HeaderText = "Embarcacion";
            this.Embarcacion.Name = "Embarcacion";
            this.Embarcacion.ReadOnly = true;
            this.Embarcacion.Width = 200;
            // 
            // ii
            // 
            this.ii.HeaderText = "Imprimir";
            this.ii.Name = "ii";
            this.ii.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ii.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // datos
            // 
            this.datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datos.Location = new System.Drawing.Point(585, 31);
            this.datos.Name = "datos";
            this.datos.Size = new System.Drawing.Size(82, 21);
            this.datos.TabIndex = 22;
            this.datos.Visible = false;
            // 
            // PantallaDeFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(211)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(880, 421);
            this.Controls.Add(this.datos);
            this.Controls.Add(this.dt);
            this.Controls.Add(this.botonBuscarLiquidacion);
            this.Controls.Add(this.comboBoxEmbarcacionpLiquidacion);
            this.Name = "PantallaDeFacturas";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxEmbarcacionpLiquidacion;
        private System.Windows.Forms.Button botonBuscarLiquidacion;
        private System.Windows.Forms.DataGridView dt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Embarcacion;
        private System.Windows.Forms.DataGridViewButtonColumn ii;
        private System.Windows.Forms.DataGridView datos;
    }
}

