namespace pantallaReportes
{
    partial class reportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reportes));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioIndividual = new System.Windows.Forms.RadioButton();
            this.radioTodas = new System.Windows.Forms.RadioButton();
            this.comboBoxEm = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Serif Lao", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(224, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 35);
            this.label1.TabIndex = 7;
            this.label1.Text = "Bajo Rojo del Pacífico";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.Location = new System.Drawing.Point(185, 14);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(33, 33);
            this.pictureBox5.TabIndex = 14;
            this.pictureBox5.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(38, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Graficas por: ";
            // 
            // radioIndividual
            // 
            this.radioIndividual.AutoSize = true;
            this.radioIndividual.ForeColor = System.Drawing.Color.White;
            this.radioIndividual.Location = new System.Drawing.Point(137, 67);
            this.radioIndividual.Name = "radioIndividual";
            this.radioIndividual.Size = new System.Drawing.Size(134, 17);
            this.radioIndividual.TabIndex = 16;
            this.radioIndividual.TabStop = true;
            this.radioIndividual.Text = "Embarcacion individual";
            this.radioIndividual.UseVisualStyleBackColor = true;
            this.radioIndividual.CheckedChanged += new System.EventHandler(this.radioIndividual_CheckedChanged);
            // 
            // radioTodas
            // 
            this.radioTodas.AutoSize = true;
            this.radioTodas.ForeColor = System.Drawing.Color.White;
            this.radioTodas.Location = new System.Drawing.Point(287, 67);
            this.radioTodas.Name = "radioTodas";
            this.radioTodas.Size = new System.Drawing.Size(55, 17);
            this.radioTodas.TabIndex = 17;
            this.radioTodas.TabStop = true;
            this.radioTodas.Text = "Todas";
            this.radioTodas.UseVisualStyleBackColor = true;
            this.radioTodas.CheckedChanged += new System.EventHandler(this.radioTodas_CheckedChanged);
            // 
            // comboBoxEm
            // 
            this.comboBoxEm.FormattingEnabled = true;
            this.comboBoxEm.Items.AddRange(new object[] {
            "Don Emi",
            "Gemelo",
            "Santa Cruz",
            "Punta Blanca N",
            "La Tania",
            "Uzziel",
            "Dasnet",
            "Wilbert Jose",
            "Don Pedro",
            "Lady Liz",
            "Pangas Tavo"});
            this.comboBoxEm.Location = new System.Drawing.Point(358, 63);
            this.comboBoxEm.Name = "comboBoxEm";
            this.comboBoxEm.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEm.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(499, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Mostrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(211)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxEm);
            this.Controls.Add(this.radioTodas);
            this.Controls.Add(this.radioIndividual);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "reportes";
            this.Text = "Reportes";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioIndividual;
        private System.Windows.Forms.RadioButton radioTodas;
        private System.Windows.Forms.ComboBox comboBoxEm;
        private System.Windows.Forms.Button button1;
    }
}

