namespace GarajesAliKan.Forms
{
    partial class FrmSeleccionMesOAnio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSeleccionMesOAnio));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RbMes = new System.Windows.Forms.RadioButton();
            this.RbAnio = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CbMeses = new System.Windows.Forms.ComboBox();
            this.CbAnios = new System.Windows.Forms.ComboBox();
            this.BtnMostrarResultados = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RbAnio);
            this.groupBox1.Controls.Add(this.RbMes);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.groupBox1.Location = new System.Drawing.Point(12, 190);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // RbMes
            // 
            this.RbMes.AutoSize = true;
            this.RbMes.Checked = true;
            this.RbMes.Location = new System.Drawing.Point(13, 26);
            this.RbMes.Name = "RbMes";
            this.RbMes.Size = new System.Drawing.Size(55, 22);
            this.RbMes.TabIndex = 1;
            this.RbMes.TabStop = true;
            this.RbMes.Text = "Mes";
            this.RbMes.UseVisualStyleBackColor = true;
            this.RbMes.CheckedChanged += new System.EventHandler(this.RbMes_CheckedChanged);
            // 
            // RbAnio
            // 
            this.RbAnio.AutoSize = true;
            this.RbAnio.Location = new System.Drawing.Point(105, 26);
            this.RbAnio.Name = "RbAnio";
            this.RbAnio.Size = new System.Drawing.Size(52, 22);
            this.RbAnio.TabIndex = 2;
            this.RbAnio.Text = "Año";
            this.RbAnio.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(94, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mes:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(94, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Año:";
            // 
            // CbMeses
            // 
            this.CbMeses.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.CbMeses.FormattingEnabled = true;
            this.CbMeses.Location = new System.Drawing.Point(143, 59);
            this.CbMeses.Name = "CbMeses";
            this.CbMeses.Size = new System.Drawing.Size(158, 26);
            this.CbMeses.TabIndex = 3;
            // 
            // CbAnios
            // 
            this.CbAnios.Enabled = false;
            this.CbAnios.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.CbAnios.FormattingEnabled = true;
            this.CbAnios.Location = new System.Drawing.Point(143, 114);
            this.CbAnios.Name = "CbAnios";
            this.CbAnios.Size = new System.Drawing.Size(122, 26);
            this.CbAnios.TabIndex = 4;
            // 
            // BtnMostrarResultados
            // 
            this.BtnMostrarResultados.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BtnMostrarResultados.Location = new System.Drawing.Point(253, 203);
            this.BtnMostrarResultados.Name = "BtnMostrarResultados";
            this.BtnMostrarResultados.Size = new System.Drawing.Size(100, 48);
            this.BtnMostrarResultados.TabIndex = 5;
            this.BtnMostrarResultados.Text = "Mostrar Resultados";
            this.BtnMostrarResultados.UseVisualStyleBackColor = true;
            this.BtnMostrarResultados.Click += new System.EventHandler(this.BtnMostrarResultados_Click);
            // 
            // FrmSeleccionMesOAnio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 262);
            this.Controls.Add(this.BtnMostrarResultados);
            this.Controls.Add(this.CbAnios);
            this.Controls.Add(this.CbMeses);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmSeleccionMesOAnio";
            this.ShowInTaskbar = false;
            this.Text = "Seleccionar Mes o Año";
            this.Load += new System.EventHandler(this.FrmSeleccionMesOAnio_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RbAnio;
        private System.Windows.Forms.RadioButton RbMes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CbMeses;
        private System.Windows.Forms.ComboBox CbAnios;
        private System.Windows.Forms.Button BtnMostrarResultados;
    }
}