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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.comboBoxEmbarcacionpLiquidacion = new System.Windows.Forms.ComboBox();
            this.botonBuscarLiquidacion = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.todo = new System.Windows.Forms.RadioButton();
            this.individual = new System.Windows.Forms.RadioButton();
            this.datos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datos)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxEmbarcacionpLiquidacion
            // 
            this.comboBoxEmbarcacionpLiquidacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.comboBoxEmbarcacionpLiquidacion.Location = new System.Drawing.Point(239, 12);
            this.comboBoxEmbarcacionpLiquidacion.Name = "comboBoxEmbarcacionpLiquidacion";
            this.comboBoxEmbarcacionpLiquidacion.Size = new System.Drawing.Size(173, 21);
            this.comboBoxEmbarcacionpLiquidacion.TabIndex = 19;
            // 
            // botonBuscarLiquidacion
            // 
            this.botonBuscarLiquidacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.botonBuscarLiquidacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonBuscarLiquidacion.ForeColor = System.Drawing.Color.White;
            this.botonBuscarLiquidacion.Location = new System.Drawing.Point(432, 6);
            this.botonBuscarLiquidacion.Name = "botonBuscarLiquidacion";
            this.botonBuscarLiquidacion.Size = new System.Drawing.Size(117, 27);
            this.botonBuscarLiquidacion.TabIndex = 20;
            this.botonBuscarLiquidacion.Text = "Buscar";
            this.botonBuscarLiquidacion.UseVisualStyleBackColor = true;
            this.botonBuscarLiquidacion.Click += new System.EventHandler(this.botonBuscarLiquidacion_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 107);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "KG";
            series1.YValuesPerPoint = 6;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(700, 381);
            this.chart1.TabIndex = 21;
            this.chart1.Text = "chart1";
            // 
            // todo
            // 
            this.todo.AutoSize = true;
            this.todo.Location = new System.Drawing.Point(40, 15);
            this.todo.Name = "todo";
            this.todo.Size = new System.Drawing.Size(50, 17);
            this.todo.TabIndex = 22;
            this.todo.TabStop = true;
            this.todo.Text = "Todo";
            this.todo.UseVisualStyleBackColor = true;
            // 
            // individual
            // 
            this.individual.AutoSize = true;
            this.individual.Location = new System.Drawing.Point(132, 15);
            this.individual.Name = "individual";
            this.individual.Size = new System.Drawing.Size(70, 17);
            this.individual.TabIndex = 23;
            this.individual.TabStop = true;
            this.individual.Text = "Individual";
            this.individual.UseVisualStyleBackColor = true;
            // 
            // datos
            // 
            this.datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datos.Location = new System.Drawing.Point(754, 56);
            this.datos.Name = "datos";
            this.datos.Size = new System.Drawing.Size(92, 150);
            this.datos.TabIndex = 24;
            this.datos.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(286, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 25);
            this.label1.TabIndex = 25;
            this.label1.Text = "Datos.";
            // 
            // button1
            // 
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(742, 346);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 27);
            this.button1.TabIndex = 26;
            this.button1.Text = "Limpiar datos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PantallaDeFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(211)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(880, 500);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datos);
            this.Controls.Add(this.individual);
            this.Controls.Add(this.todo);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.botonBuscarLiquidacion);
            this.Controls.Add(this.comboBoxEmbarcacionpLiquidacion);
            this.Name = "PantallaDeFacturas";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxEmbarcacionpLiquidacion;
        private System.Windows.Forms.Button botonBuscarLiquidacion;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.RadioButton todo;
        private System.Windows.Forms.RadioButton individual;
        private System.Windows.Forms.DataGridView datos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}

