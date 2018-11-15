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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.datos = new System.Windows.Forms.DataGridView();
            this.nombreEmbarcacion = new System.Windows.Forms.Label();
            this.propietario = new System.Windows.Forms.Label();
            this.totalAlistos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datos)).BeginInit();
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
            "Wilbert Jose",
            "Don Pedro",
            "Lady Liz"});
            this.comboBoxEmbarcacionpLiquidacion.Location = new System.Drawing.Point(12, 18);
            this.comboBoxEmbarcacionpLiquidacion.Name = "comboBoxEmbarcacionpLiquidacion";
            this.comboBoxEmbarcacionpLiquidacion.Size = new System.Drawing.Size(173, 21);
            this.comboBoxEmbarcacionpLiquidacion.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Embarcacion: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Propietario:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(346, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Saldo Pendiente:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(346, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Saldo Actual:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(392, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Hoja liquidacion y Alistos.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(16, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Total Alistos:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(346, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Total Abono:";
            // 
            // datos
            // 
            this.datos.BackgroundColor = System.Drawing.Color.White;
            this.datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datos.Location = new System.Drawing.Point(12, 176);
            this.datos.Name = "datos";
            this.datos.Size = new System.Drawing.Size(480, 213);
            this.datos.TabIndex = 27;
            // 
            // nombreEmbarcacion
            // 
            this.nombreEmbarcacion.AutoSize = true;
            this.nombreEmbarcacion.Location = new System.Drawing.Point(84, 56);
            this.nombreEmbarcacion.Name = "nombreEmbarcacion";
            this.nombreEmbarcacion.Size = new System.Drawing.Size(13, 13);
            this.nombreEmbarcacion.TabIndex = 28;
            this.nombreEmbarcacion.Text = "--";
            // 
            // propietario
            // 
            this.propietario.AutoSize = true;
            this.propietario.Location = new System.Drawing.Point(84, 92);
            this.propietario.Name = "propietario";
            this.propietario.Size = new System.Drawing.Size(13, 13);
            this.propietario.TabIndex = 29;
            this.propietario.Text = "--";
            // 
            // totalAlistos
            // 
            this.totalAlistos.AutoSize = true;
            this.totalAlistos.Location = new System.Drawing.Point(87, 133);
            this.totalAlistos.Name = "totalAlistos";
            this.totalAlistos.Size = new System.Drawing.Size(13, 13);
            this.totalAlistos.TabIndex = 30;
            this.totalAlistos.Text = "--";
            // 
            // PantallaLiquidaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(211)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(880, 450);
            this.Controls.Add(this.totalAlistos);
            this.Controls.Add(this.propietario);
            this.Controls.Add(this.nombreEmbarcacion);
            this.Controls.Add(this.datos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxEmbarcacionpLiquidacion);
            this.Controls.Add(this.botonBuscarLiquidacion);
            this.Name = "PantallaLiquidaciones";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.datos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonBuscarLiquidacion;
        private System.Windows.Forms.ComboBox comboBoxEmbarcacionpLiquidacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView datos;
        private System.Windows.Forms.Label nombreEmbarcacion;
        private System.Windows.Forms.Label propietario;
        private System.Windows.Forms.Label totalAlistos;
    }
}

