namespace LiquidacionesApp
{
    partial class PantallaLiquidaciones
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
            this.botonBuscarLiquidacion = new System.Windows.Forms.Button();
            this.comboBoxEmbarcacionpLiquidacion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.datos = new System.Windows.Forms.DataGridView();
            this.totalAlistos = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.combo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.datos2 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.procedencia = new System.Windows.Forms.TextBox();
            this.detalle = new System.Windows.Forms.TextBox();
            this.monto = new System.Windows.Forms.TextBox();
            this.totalAbonos = new System.Windows.Forms.Label();
            this.montoEconomico = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.botonMonto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.datosAbono = new System.Windows.Forms.DataGridView();
            this.totalPagar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datos)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datos2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datosAbono)).BeginInit();
            this.SuspendLayout();
            // 
            // botonBuscarLiquidacion
            // 
            this.botonBuscarLiquidacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.botonBuscarLiquidacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonBuscarLiquidacion.ForeColor = System.Drawing.Color.White;
            this.botonBuscarLiquidacion.Location = new System.Drawing.Point(208, 12);
            this.botonBuscarLiquidacion.Name = "botonBuscarLiquidacion";
            this.botonBuscarLiquidacion.Size = new System.Drawing.Size(117, 27);
            this.botonBuscarLiquidacion.TabIndex = 17;
            this.botonBuscarLiquidacion.Text = "Buscar";
            this.botonBuscarLiquidacion.UseVisualStyleBackColor = true;
            this.botonBuscarLiquidacion.Click += new System.EventHandler(this.botonBuscarPesa_Click);
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
            "Darien Lg",
            "Don Pedro",
            "Lady Liz",
            "Danny 2"});
            this.comboBoxEmbarcacionpLiquidacion.Location = new System.Drawing.Point(12, 18);
            this.comboBoxEmbarcacionpLiquidacion.Name = "comboBoxEmbarcacionpLiquidacion";
            this.comboBoxEmbarcacionpLiquidacion.Size = new System.Drawing.Size(173, 21);
            this.comboBoxEmbarcacionpLiquidacion.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(346, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Total Abonos:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(346, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Total a pagar:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Total Alistos:";
            // 
            // datos
            // 
            this.datos.BackgroundColor = System.Drawing.Color.White;
            this.datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datos.Location = new System.Drawing.Point(12, 92);
            this.datos.Name = "datos";
            this.datos.Size = new System.Drawing.Size(173, 63);
            this.datos.TabIndex = 27;
            this.datos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datos_CellDoubleClick);
            // 
            // totalAlistos
            // 
            this.totalAlistos.AutoSize = true;
            this.totalAlistos.Location = new System.Drawing.Point(84, 54);
            this.totalAlistos.Name = "totalAlistos";
            this.totalAlistos.Size = new System.Drawing.Size(13, 13);
            this.totalAlistos.TabIndex = 30;
            this.totalAlistos.Text = "--";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(38, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(232, 20);
            this.label8.TabIndex = 31;
            this.label8.Text = "Crear nueva hoja de alistos.";
            // 
            // combo
            // 
            this.combo.FormattingEnabled = true;
            this.combo.Items.AddRange(new object[] {
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
            "Danny 2"});
            this.combo.Location = new System.Drawing.Point(97, 41);
            this.combo.Name = "combo";
            this.combo.Size = new System.Drawing.Size(173, 21);
            this.combo.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(3, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 33;
            this.label9.Text = "Embarcacion";
            // 
            // button1
            // 
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(97, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 27);
            this.button1.TabIndex = 34;
            this.button1.Text = "Crear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.combo);
            this.panel1.Location = new System.Drawing.Point(558, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 156);
            this.panel1.TabIndex = 35;
            // 
            // datos2
            // 
            this.datos2.BackgroundColor = System.Drawing.Color.White;
            this.datos2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datos2.Location = new System.Drawing.Point(12, 161);
            this.datos2.Name = "datos2";
            this.datos2.Size = new System.Drawing.Size(373, 150);
            this.datos2.TabIndex = 36;
            // 
            // button2
            // 
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(111, 454);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 27);
            this.button2.TabIndex = 37;
            this.button2.Text = "Guardar Datos";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(9, 324);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Procedencia";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(9, 359);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "Detalle: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(12, 400);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Monto:";
            // 
            // procedencia
            // 
            this.procedencia.Location = new System.Drawing.Point(87, 317);
            this.procedencia.Name = "procedencia";
            this.procedencia.Size = new System.Drawing.Size(168, 20);
            this.procedencia.TabIndex = 41;
            // 
            // detalle
            // 
            this.detalle.Location = new System.Drawing.Point(87, 352);
            this.detalle.Name = "detalle";
            this.detalle.Size = new System.Drawing.Size(168, 20);
            this.detalle.TabIndex = 42;
            // 
            // monto
            // 
            this.monto.Location = new System.Drawing.Point(87, 393);
            this.monto.Name = "monto";
            this.monto.Size = new System.Drawing.Size(168, 20);
            this.monto.TabIndex = 43;
            // 
            // totalAbonos
            // 
            this.totalAbonos.AutoSize = true;
            this.totalAbonos.Location = new System.Drawing.Point(425, 57);
            this.totalAbonos.Name = "totalAbonos";
            this.totalAbonos.Size = new System.Drawing.Size(13, 13);
            this.totalAbonos.TabIndex = 47;
            this.totalAbonos.Text = "--";
            // 
            // montoEconomico
            // 
            this.montoEconomico.Location = new System.Drawing.Point(43, 50);
            this.montoEconomico.Name = "montoEconomico";
            this.montoEconomico.Size = new System.Drawing.Size(172, 20);
            this.montoEconomico.TabIndex = 48;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.botonMonto);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.montoEconomico);
            this.panel2.Location = new System.Drawing.Point(558, 241);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(293, 145);
            this.panel2.TabIndex = 49;
            // 
            // botonMonto
            // 
            this.botonMonto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.botonMonto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonMonto.ForeColor = System.Drawing.Color.White;
            this.botonMonto.Location = new System.Drawing.Point(68, 92);
            this.botonMonto.Name = "botonMonto";
            this.botonMonto.Size = new System.Drawing.Size(117, 27);
            this.botonMonto.TabIndex = 35;
            this.botonMonto.Text = "Agregar monto";
            this.botonMonto.UseVisualStyleBackColor = true;
            this.botonMonto.Click += new System.EventHandler(this.botonMonto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(39, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 20);
            this.label1.TabIndex = 35;
            this.label1.Text = "Agregar nuevo abono";
            // 
            // datosAbono
            // 
            this.datosAbono.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datosAbono.Location = new System.Drawing.Point(312, 334);
            this.datosAbono.Name = "datosAbono";
            this.datosAbono.Size = new System.Drawing.Size(53, 14);
            this.datosAbono.TabIndex = 50;
            this.datosAbono.Visible = false;
            // 
            // totalPagar
            // 
            this.totalPagar.AutoSize = true;
            this.totalPagar.Location = new System.Drawing.Point(425, 92);
            this.totalPagar.Name = "totalPagar";
            this.totalPagar.Size = new System.Drawing.Size(13, 13);
            this.totalPagar.TabIndex = 51;
            this.totalPagar.Text = "--";
            // 
            // PantallaLiquidaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(211)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(880, 521);
            this.Controls.Add(this.totalPagar);
            this.Controls.Add(this.datosAbono);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.totalAbonos);
            this.Controls.Add(this.monto);
            this.Controls.Add(this.detalle);
            this.Controls.Add(this.procedencia);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.datos2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.totalAlistos);
            this.Controls.Add(this.datos);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxEmbarcacionpLiquidacion);
            this.Controls.Add(this.botonBuscarLiquidacion);
            this.Name = "PantallaLiquidaciones";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.datos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datos2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datosAbono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonBuscarLiquidacion;
        private System.Windows.Forms.ComboBox comboBoxEmbarcacionpLiquidacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView datos;
        private System.Windows.Forms.Label totalAlistos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox combo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView datos2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox procedencia;
        private System.Windows.Forms.TextBox detalle;
        private System.Windows.Forms.TextBox monto;
        private System.Windows.Forms.Label totalAbonos;
        private System.Windows.Forms.TextBox montoEconomico;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botonMonto;
        private System.Windows.Forms.DataGridView datosAbono;
        private System.Windows.Forms.Label totalPagar;
    }
}

