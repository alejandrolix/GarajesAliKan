namespace GarajesAliKan.Forms
{
    partial class FrmListados
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnImprimirClientes = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BtnImprFactRecibida = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnImprFactLavadero = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnImprFactGaraje = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.DtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.DtFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(178, 30);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2);
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(78, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Clientes";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BtnImprimirClientes);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 110);
            this.panel1.TabIndex = 2;
            // 
            // BtnImprimirClientes
            // 
            this.BtnImprimirClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BtnImprimirClientes.Location = new System.Drawing.Point(48, 54);
            this.BtnImprimirClientes.Name = "BtnImprimirClientes";
            this.BtnImprimirClientes.Size = new System.Drawing.Size(89, 34);
            this.BtnImprimirClientes.TabIndex = 1;
            this.BtnImprimirClientes.Text = "Imprimir";
            this.BtnImprimirClientes.UseVisualStyleBackColor = true;
            this.BtnImprimirClientes.Click += new System.EventHandler(this.BtnImprimirClientes_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(522, 30);
            this.panel3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(219, 3);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2);
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(84, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Facturas";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.BtnImprFactRecibida);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.BtnImprFactLavadero);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.BtnImprFactGaraje);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.DtFechaFin);
            this.panel4.Controls.Add(this.DtFechaInicio);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Location = new System.Drawing.Point(267, 34);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(530, 201);
            this.panel4.TabIndex = 4;
            // 
            // BtnImprFactRecibida
            // 
            this.BtnImprFactRecibida.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BtnImprFactRecibida.Location = new System.Drawing.Point(429, 156);
            this.BtnImprFactRecibida.Name = "BtnImprFactRecibida";
            this.BtnImprFactRecibida.Size = new System.Drawing.Size(75, 27);
            this.BtnImprFactRecibida.TabIndex = 6;
            this.BtnImprFactRecibida.Text = "Imprimir";
            this.BtnImprFactRecibida.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(325, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 33;
            this.label7.Text = "Recibidas";
            // 
            // BtnImprFactLavadero
            // 
            this.BtnImprFactLavadero.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BtnImprFactLavadero.Location = new System.Drawing.Point(429, 109);
            this.BtnImprFactLavadero.Name = "BtnImprFactLavadero";
            this.BtnImprFactLavadero.Size = new System.Drawing.Size(75, 27);
            this.BtnImprFactLavadero.TabIndex = 5;
            this.BtnImprFactLavadero.Text = "Imprimir";
            this.BtnImprFactLavadero.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(325, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 31;
            this.label6.Text = "Lavadero";
            // 
            // BtnImprFactGaraje
            // 
            this.BtnImprFactGaraje.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.BtnImprFactGaraje.Location = new System.Drawing.Point(429, 62);
            this.BtnImprFactGaraje.Name = "BtnImprFactGaraje";
            this.BtnImprFactGaraje.Size = new System.Drawing.Size(75, 27);
            this.BtnImprFactGaraje.TabIndex = 4;
            this.BtnImprFactGaraje.Text = "Imprimir";
            this.BtnImprFactGaraje.UseVisualStyleBackColor = true;
            this.BtnImprFactGaraje.Click += new System.EventHandler(this.BtnImprFactGaraje_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(325, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 29;
            this.label5.Text = "Garajes";
            // 
            // DtFechaFin
            // 
            this.DtFechaFin.CustomFormat = "dd/MM/yyyy";
            this.DtFechaFin.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DtFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.DtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtFechaFin.Location = new System.Drawing.Point(123, 115);
            this.DtFechaFin.Name = "DtFechaFin";
            this.DtFechaFin.Size = new System.Drawing.Size(122, 24);
            this.DtFechaFin.TabIndex = 3;
            this.DtFechaFin.Value = new System.DateTime(2018, 10, 5, 0, 0, 0, 0);
            // 
            // DtFechaInicio
            // 
            this.DtFechaInicio.CustomFormat = "dd/MM/yyyy";
            this.DtFechaInicio.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DtFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.DtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtFechaInicio.Location = new System.Drawing.Point(123, 60);
            this.DtFechaInicio.Name = "DtFechaInicio";
            this.DtFechaInicio.Size = new System.Drawing.Size(122, 24);
            this.DtFechaInicio.TabIndex = 2;
            this.DtFechaInicio.Value = new System.DateTime(2018, 10, 15, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(16, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Fecha Fin: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(16, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Inicio: ";
            // 
            // FrmListados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 324);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmListados";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listados";
            this.Load += new System.EventHandler(this.FrmListados_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnImprimirClientes;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DtFechaFin;
        private System.Windows.Forms.DateTimePicker DtFechaInicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnImprFactGaraje;
        private System.Windows.Forms.Button BtnImprFactLavadero;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnImprFactRecibida;
        private System.Windows.Forms.Label label7;
    }
}