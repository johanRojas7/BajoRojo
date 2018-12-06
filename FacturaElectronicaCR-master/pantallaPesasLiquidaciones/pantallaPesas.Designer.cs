namespace pantallaPesasLiquidaciones
{
    partial class pantallaPesas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pantallaPesas));
            this.comboBoxEmbarcacion = new System.Windows.Forms.ComboBox();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.datos = new System.Windows.Forms.DataGridView();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.MontoTotalPesasKg = new System.Windows.Forms.Label();
            this.MontoTotalDinero = new System.Windows.Forms.Label();
            this.datos2 = new System.Windows.Forms.DataGridView();
            this.pescado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPesa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datos2)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxEmbarcacion
            // 
            this.comboBoxEmbarcacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEmbarcacion.FormattingEnabled = true;
            this.comboBoxEmbarcacion.Items.AddRange(new object[] {
            "Don Emi",
            "Gemelo",
            "Santa Cruz",
            "Punta Blanca N",
            "La Tania",
            "Uzziel",
            "Dasnet",
            "Darien Lg",
            "Don Pedro",
            "Lady Liz",
            "Danny 2",
            "Bajo Rojo"});
            this.comboBoxEmbarcacion.Location = new System.Drawing.Point(16, 21);
            this.comboBoxEmbarcacion.Name = "comboBoxEmbarcacion";
            this.comboBoxEmbarcacion.Size = new System.Drawing.Size(173, 21);
            this.comboBoxEmbarcacion.TabIndex = 15;
            // 
            // botonBuscar
            // 
            this.botonBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.botonBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonBuscar.ForeColor = System.Drawing.Color.White;
            this.botonBuscar.Location = new System.Drawing.Point(195, 15);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(117, 27);
            this.botonBuscar.TabIndex = 16;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(619, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 27);
            this.button1.TabIndex = 18;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // datos
            // 
            this.datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datos.Location = new System.Drawing.Point(606, 262);
            this.datos.Name = "datos";
            this.datos.Size = new System.Drawing.Size(279, 81);
            this.datos.TabIndex = 19;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(372, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(104, 18);
            this.label18.TabIndex = 89;
            this.label18.Text = "Monto Total:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(636, 9);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(97, 18);
            this.label19.TabIndex = 90;
            this.label19.Text = "Pesas (Kg):";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(650, 40);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(0, 18);
            this.label20.TabIndex = 91;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(482, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(20, 18);
            this.label21.TabIndex = 92;
            this.label21.Text = "₡";
            // 
            // MontoTotalPesasKg
            // 
            this.MontoTotalPesasKg.AutoSize = true;
            this.MontoTotalPesasKg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MontoTotalPesasKg.Location = new System.Drawing.Point(730, 9);
            this.MontoTotalPesasKg.Name = "MontoTotalPesasKg";
            this.MontoTotalPesasKg.Size = new System.Drawing.Size(17, 18);
            this.MontoTotalPesasKg.TabIndex = 93;
            this.MontoTotalPesasKg.Text = "0";
            // 
            // MontoTotalDinero
            // 
            this.MontoTotalDinero.AutoSize = true;
            this.MontoTotalDinero.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MontoTotalDinero.Location = new System.Drawing.Point(508, 9);
            this.MontoTotalDinero.Name = "MontoTotalDinero";
            this.MontoTotalDinero.Size = new System.Drawing.Size(17, 18);
            this.MontoTotalDinero.TabIndex = 94;
            this.MontoTotalDinero.Text = "0";
            // 
            // datos2
            // 
            this.datos2.BackgroundColor = System.Drawing.Color.White;
            this.datos2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datos2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pescado,
            this.TotalPesa,
            this.Precio,
            this.TotalLinea});
            this.datos2.Location = new System.Drawing.Point(1, 78);
            this.datos2.Name = "datos2";
            this.datos2.Size = new System.Drawing.Size(460, 395);
            this.datos2.TabIndex = 95;
            this.datos2.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.datos2_CellValueChanged);
            // 
            // pescado
            // 
            this.pescado.HeaderText = "Tipo De Pescado";
            this.pescado.Name = "pescado";
            this.pescado.ReadOnly = true;
            // 
            // TotalPesa
            // 
            this.TotalPesa.HeaderText = "Total Pesa";
            this.TotalPesa.Name = "TotalPesa";
            this.TotalPesa.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            // 
            // TotalLinea
            // 
            this.TotalLinea.HeaderText = "Total de linea";
            this.TotalLinea.Name = "TotalLinea";
            this.TotalLinea.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(527, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 27);
            this.button2.TabIndex = 96;
            this.button2.Text = "Prueba";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pantallaPesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(211)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(913, 524);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.datos2);
            this.Controls.Add(this.MontoTotalDinero);
            this.Controls.Add(this.MontoTotalPesasKg);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.datos);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.botonBuscar);
            this.Controls.Add(this.comboBoxEmbarcacion);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "pantallaPesas";
            this.Text = "Pesas y liquidaciones";
            ((System.ComponentModel.ISupportInitialize)(this.datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datos2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxEmbarcacion;
        private System.Windows.Forms.Button botonBuscar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView datos;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label MontoTotalPesasKg;
        private System.Windows.Forms.Label MontoTotalDinero;
        private System.Windows.Forms.DataGridView datos2;
        private System.Windows.Forms.DataGridViewTextBoxColumn pescado;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPesa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalLinea;
        private System.Windows.Forms.Button button2;
    }
}

